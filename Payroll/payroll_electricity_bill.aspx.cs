using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PayRoll_payroll_electricity_bill : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();
            HouseTypebind();
            //sql = "Jct_Payroll_Electricity_Accomodation_List";
            //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.ExecuteNonQuery();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //ddlhousetype.DataSource = ds;
            //ddlhousetype.DataTextField = "AccmType";
            //ddlhousetype.DataValueField = "SrNo";
            //ddlhousetype.DataBind();

            string sql1 = "Jct_Payroll_Electricity_Code_List";
            SqlCommand cmd1 = new SqlCommand(sql1, obj.Connection());
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    string Deduction_code;
                    Deduction_code = dr1["ComponentCode"].ToString();
                    lblElectricityBill.Text = Deduction_code;
                }
            }
            dr1.Close();

        }
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_electricity_bill.aspx");
    }

    public void AttendenceDate()
    {
        DateTime origDT = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        origDT = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(-1);
        txtfromdate.Text = Convert.ToDateTime(origDT).ToShortDateString();
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txttodate_CalendarExtender.SelectedDate = lastDate;
    }

    protected void txtfromdate_TextChanged(object sender, EventArgs e)
    {
        DateTime origDT = Convert.ToDateTime(txtfromdate.Text);
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txttodate_CalendarExtender.SelectedDate = lastDate;
    }

    public void Plantbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
    }

    public void HouseTypebind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT AccmType,Start_HouseNo,End_HouseNo FROM Jct_Payroll_Accomdation_Master WHERE  STATUS='A'and plant='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlhousetype.DataSource = ds;
        ddlhousetype.DataTextField = "AccmType";
        ddlhousetype.DataValueField = "AccmType";
        ddlhousetype.DataBind();
    }

    public void Fetch_Employee_Wise()
    {
        string employeecode = string.Empty;
        if (txtEmployee.Text == "")
        {
            return;
        }
        else
        {
            employeecode = txtEmployee.Text.Split('|')[1].ToString();
        }

        sql = "Jct_Payroll_EmployeeWIse_Pending_Bill";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = employeecode;
        if (!string.IsNullOrEmpty(txtEmployee.Text))
        {
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = txtEmployee.Text.Split('|')[1].ToString();
        }
        cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    public void Fetch_Location_Employee_Wise()
    {
        sql = "jct_payroll_ECE_bill";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@house_type", SqlDbType.VarChar).Value = ddlhousetype.SelectedItem.Text;
        //if (!string.IsNullOrEmpty(txtEmployee.Text))
        //{
        //    cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = txtEmployee.Text.Split('|')[1].ToString();
        //}
        cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    private void BindgridSelected()
    {
        sql = "Jct_Payroll_Entered_Bill_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@House_type", SqlDbType.VarChar, 20).Value = ddlhousetype.SelectedItem.Text;
        cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetailList.DataSource = ds.Tables[0];
        grdDetailList.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblShowDetail.Visible = true;
            lnkUpdate.Visible = true;
            Panel2.Visible = true;
        }
        else
        {
            lblShowDetail.Visible = false;
            lnkUpdate.Visible = false;
        }
        Panel1.Visible = true;
    }

    public void RebindLocation()
    {
        sql = "Jct_Payroll_Monthly_WageSummery_CrystalReport_Truncate";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text.Split('|')[1].ToString();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlhousetype.SelectedIndex = ddlhousetype.Items.IndexOf(ddlhousetype.Items.FindByText(dr["AccmType"].ToString()));
            }
        }
        dr.Close();
        //
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlhousetype.Items.Clear();
        HouseTypebind();
    }

    protected void ddlhousetype_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Fetch_Location_Employee_Wise();
        BindgridSelected();
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void chksel_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox sel = (CheckBox)grdDetail.HeaderRow.FindControl("chksel");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkbx");

            if (cb != null)
            {
                if (sel.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
    }

    protected void chkall1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkall = (CheckBox)grdDetailList.HeaderRow.FindControl("chkall1");
        foreach (GridViewRow row in grdDetailList.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");

            if (cb != null)
            {
                if (chkall.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
    }

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkall = (CheckBox)grdDetail.HeaderRow.FindControl("chkall");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");

            if (cb != null)
            {

                if (chkall.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
    }

    protected void txtunits_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");
            if (cb.Checked == true)
            {
                TextBox amount = (TextBox)(row.Cells[8].FindControl("txtamount"));
                TextBox unitrate = (TextBox)(row.Cells[7].FindControl("txtunitrate"));
                TextBox units = (TextBox)(row.Cells[6].FindControl("txtunits"));
                //if (string.IsNullOrEmpty(units.Text))
                //{
                //    string script = "alert('Please Enter Units For This Month.!! ');";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //    return;
                //}
                //if (string.IsNullOrEmpty(unitrate.Text))
                //{
                //    string script = "alert('Please Enter Units Rate For This Record.!! ');";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //    return;
                //}
                if (units.Text != "")
                {
                    amount.Text = Convert.ToDecimal(Convert.ToDecimal(unitrate.Text) * Convert.ToDecimal(units.Text)).ToString();
                }
            }
        }
    }

    protected void txtunits1_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdDetailList.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");
            //if (cb.Checked == true)
            //{
                TextBox amount = (TextBox)(row.Cells[8].FindControl("txtamount"));
                TextBox unitrate = (TextBox)(row.Cells[7].FindControl("txtunitrate"));
                TextBox units = (TextBox)(row.Cells[6].FindControl("txtunits1"));

                //if (string.IsNullOrEmpty(units.Text))
                //{
                //    string script = "alert('Please Enter Units For This Month.!! ');";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //    return;
                //}

                //if (string.IsNullOrEmpty(unitrate.Text))
                //{
                //    string script = "alert('Please Enter Units Rate For This Record.!! ');";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //    return;
                //}
                    if (units.Text != "")
                {
                amount.Text = Convert.ToDecimal(Convert.ToDecimal(unitrate.Text) * Convert.ToDecimal(units.Text)).ToString();
                }
            //}
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Fetch_Employee_Wise();
    }

    protected void ddlhousetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "Jct_Payroll_Monthly_WageSummery_CrystalReport_Truncate";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
      
        if (!string.IsNullOrEmpty(txtEmployee.Text))
        {
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = txtEmployee.Text.Split('|')[1].ToString();
        }
        cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Fetch_Employee_Wise();
            RebindLocation();
            BindgridSelected();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string OK = string.Empty;
            foreach (GridViewRow gvRow1 in grdDetail.Rows)
            {
                CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chk");
                if (chkRemove1.Checked == true)
                {
                    OK = "OK";
                }
            }
            if (OK == "OK")
            {
                foreach (GridViewRow row in grdDetail.Rows)
                {
                    CheckBox cb = (CheckBox)row.FindControl("chk");
                    if (cb.Checked == true)
                    {
                        TextBox amount = (TextBox)(row.Cells[8].FindControl("txtamount"));
                        TextBox unitrate = (TextBox)(row.Cells[7].FindControl("txtunitrate"));
                        TextBox units = (TextBox)(row.Cells[6].FindControl("txtunits"));
                       
                        SqlCommand cmd = new SqlCommand("Jct_Payroll_Monthly_WageSummery_CrystalReport_Truncate", obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                       
                        cmd.ExecuteNonQuery();
                        Fetch_Location_Employee_Wise();
                        BindgridSelected();
                        string script1 = "alert('Record Saved Sucesfully.!! ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
                    }
                }
            }
            else
            {
                string script2 = "alert('Please Select The Record First.!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
             

    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string OK = string.Empty;
            foreach (GridViewRow gvRow1 in grdDetailList.Rows)
            {
                CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chk");
                if (chkRemove1.Checked == true)
                {
                    OK = "OK";
                }
            }
            if (OK == "OK")
            {
                foreach (GridViewRow row in grdDetailList.Rows)
                {
                    CheckBox cb = (CheckBox)row.FindControl("chk");
                    if (cb.Checked == true)
                    {
                        TextBox amount = (TextBox)(row.Cells[8].FindControl("txtamount"));
                        TextBox unitrate = (TextBox)(row.Cells[7].FindControl("txtunitrate"));
                        TextBox units = (TextBox)(row.Cells[6].FindControl("txtunits1"));
                        SqlCommand cmd = new SqlCommand("Jct_Payroll_Monthly_WageSummery_CrystalReport_Truncate", obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.Add("@deduction_code", SqlDbType.VarChar, 20).Value = lblElectricityBill.Text;
                        cmd.Parameters.Add("@House_type", SqlDbType.VarChar, 20).Value = (row.Cells[5].Text.Replace("&nbsp;", ""));
                        cmd.Parameters.Add("@House_no", SqlDbType.VarChar, 20).Value = (row.Cells[6].Text.Replace("&nbsp;", null));
                        cmd.Parameters.Add("@units", SqlDbType.Decimal).Value = units.Text;
                        cmd.Parameters.Add("@unitrate", SqlDbType.Decimal, 2).Value = unitrate.Text;
                        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                        cmd.Parameters.Add("@amount", SqlDbType.Decimal, 2).Value = amount.Text;
                        cmd.Parameters.Add("@employee_code", SqlDbType.VarChar, 20).Value = (row.Cells[1].Text);
                        cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
                        cmd.ExecuteNonQuery();
                        Fetch_Location_Employee_Wise();
                        BindgridSelected();
                        string script = "alert('Record Updated Sucesfully.!! ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
            }
            else
            {
                string script2 = "alert('Please Select The Record First.!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void LnkAuth_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_payroll_electricity_bill_FreezeStatus", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);        
        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];        
        cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
        cmd.ExecuteNonQuery();                
        string script = "alert('Record Freezed Sucesfully.!! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);       
    }

    protected void lnkReset0_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_electricity_Report.aspx");
    }
}
