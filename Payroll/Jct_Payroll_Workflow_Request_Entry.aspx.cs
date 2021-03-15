using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_Jct_Payroll_Workflow_Request_Entry : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Plantbind();
            Locationbind();
            AreaBind();
            LevelBind();
            if (DropDownList1.SelectedItem.Value == "Leave" || DropDownList1.SelectedItem.Value == "WorkFromHome")
            {
                VisibleControls();
            }
            else
            {
                NotVisibleControls();
            }
            BindItemListGridview();
        }
    }

    protected void chkRemove_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow gridRow = (GridViewRow)(sender as Control).Parent.Parent;
        RequiredFieldValidator RequiredFieldValidator1 = (RequiredFieldValidator)gridRow.FindControl("RequiredFieldValidator1");
        CheckBox checkbox = (CheckBox)gridRow.FindControl("chkRemove");
        if (checkbox.Checked == true)
        {
            checkbox.Checked = true;
        }
        else
        {
            checkbox.Checked = false;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("chkRemoveALL");
            CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
            TextBox txtAut1 = (TextBox)gvRow.FindControl("txtAut");
            TextBox txtReq1 = (TextBox)gvRow.FindControl("txtReq");

            if (DropDownList1.SelectedItem.Value == "Leave" || DropDownList1.SelectedItem.Value == "WorkFromHome")
            {
                txtAut1.Enabled = true;
                chkRemove.Checked = false;
                chkRemove.Enabled = true;
                ChkBoxHeader.Enabled = true;
            }
            else
            {
                txtAut1.Enabled = false;
                chkRemove.Checked = true;
                chkRemove.Enabled = false;
                ChkBoxHeader.Enabled = false;
            }
            txtReq1.Enabled = false;
        }
    }

    protected void chkRemoveALL_CheckedChanged(object sender, EventArgs e)
    {
        if (DataControlRowType.DataRow == DataControlRowType.DataRow)
        {
            CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("chkRemoveALL");
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("chkRemove");
                if (ChkBoxHeader.Checked == true)
                {
                    checkbox.Checked = true;
                }
                else
                {
                    checkbox.Checked = false;
                }
            }

        }
    }

    public void AreaBind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Name,Description FROM Jct_PayrollPortal_AreaCategory WHERE  STATUS='A' union Select 'WorkfromHome' as Name,'WorkfromHome' as Description  UNION SELECT  'PF' AS Name , 'PF' AS Description ORDER BY Description", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "Description";
        DropDownList1.DataValueField = "Name";
        DropDownList1.DataBind();
    }

    public void LevelBind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Level,Level FROM Jct_PayrollPortal_LevelMaster WHERE  STATUS='A' ORDER BY Level", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "Level";
        DropDownList2.DataValueField = "Level";
        DropDownList2.DataBind();
    }

    public void Plantbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "Plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
    }

    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
        BindItemListGridview();
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
            ClearControls();
            CheckDesignation();
            BindItemListGridview();
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckDesignation()
    {
        string sql = "Jct_Payroll_CommonDetail_Employee_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblEmployeeName.Text = dr[1].ToString();
            }
            dr.Close();
        }
    }

    public void CheckDesignation1()
    {
        string sql = "Jct_Payroll_CommonDetail_Employee_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = TextBox1.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Label2.Text = dr[1].ToString();
            }
            dr.Close();
        }
    }

    public void BindItemListGridview()
    {
        string sql = "Jct_Payroll_WorkFlowGridview_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@RequsterCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@AreaApply", SqlDbType.VarChar, 50).Value = DropDownList1.SelectedItem.Value;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    public void ClearControls()
    {
        lblEmployeeName.Text = "";
    }

    public void ClearControls1()
    {
        Label2.Text = "";
    }

    public void VisibleControls()
    {
        lblauthname.Visible = true;
        LlbAuthname1.Visible = true;
        lblLevel.Visible = true;

        DropDownList2.Visible = true;
        TextBox1.Visible = true;
        LlbAuthname1.Visible = true;
    }

    public void NotVisibleControls()
    {
        lblauthname.Visible = false;
        LlbAuthname1.Visible = false;
        lblLevel.Visible = false;

        DropDownList2.Visible = false;
        TextBox1.Visible = false;
        LlbAuthname1.Visible = false;
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        try
        {
            cmd = new SqlCommand("Jct_Payroll_WorkFlowGridview_Insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            if (DropDownList2.Visible == true)
            {
                cmd.Parameters.Add("@Level", SqlDbType.Int).Value = DropDownList2.SelectedItem.Value;
            }
            else
            {
                cmd.Parameters.Add("@Level", SqlDbType.Int).Value = 0;
            }
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@RequsterCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
            if (DropDownList2.Visible == true)
            {
                cmd.Parameters.Add("@AuthCode", SqlDbType.VarChar, 30).Value = TextBox1.Text;
            }
            else
            {
                cmd.Parameters.Add("@AuthCode", SqlDbType.VarChar, 30).Value = "";
            }
            cmd.Parameters.Add("@AreaApply", SqlDbType.VarChar, 40).Value = DropDownList1.SelectedItem.Value;
            cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            string script = "alert('Records Saved Successfully !!!!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
        BindItemListGridview();
    }

    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        try
        {
            string OK = string.Empty;
            foreach (GridViewRow gvRow1 in GridView1.Rows)
            {
                CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chkRemove");
                if (chkRemove1.Checked == true)
                {
                    OK = "OK";
                }
            }

            if (OK == "OK")
            {
                string sql1 = "Jct_Payroll_WorkFlowGridview_CheckParam_Fetch";
                SqlCommand cmd1 = new SqlCommand(sql1, obj.Connection());
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@AreaApply", SqlDbType.VarChar, 40).Value = DropDownList1.SelectedItem.Value;
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr[0].ToString() == "1")
                    {
                        foreach (GridViewRow gvRow in GridView1.Rows)
                        {
                            CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
                            TextBox txtReq1 = (TextBox)gvRow.FindControl("txtReq");
                            TextBox txtAut1 = (TextBox)gvRow.FindControl("txtAut");
                            Label lblSrNo = (Label)gvRow.FindControl("lblSrNo");

                            if (chkRemove.Checked == true)
                            {
                                cmd = new SqlCommand("Jct_Payroll_WorkFlowGridview_Update", obj.Connection());
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@Level", SqlDbType.Int).Value = Convert.ToInt16(lblSrNo.Text);
                                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
                                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
                                cmd.Parameters.Add("@RequsterCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
                                cmd.Parameters.Add("@AuthCode", SqlDbType.VarChar, 30).Value = txtAut1.Text;
                                cmd.Parameters.Add("@AreaApply", SqlDbType.VarChar, 40).Value = DropDownList1.SelectedItem.Value;
                                cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
                                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                                cmd.ExecuteNonQuery();

                            }
                        }

                    }
                    else
                    {
                        foreach (GridViewRow gvRow in GridView1.Rows)
                        {
                            if (gvRow.RowIndex == 1)
                            {
                                CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
                                TextBox txtReq1 = (TextBox)gvRow.FindControl("txtReq");
                                TextBox txtAut1 = (TextBox)gvRow.FindControl("txtAut");
                                Label lblSrNo = (Label)gvRow.FindControl("lblSrNo");

                                if (chkRemove.Checked == true)
                                {
                                    cmd = new SqlCommand("Jct_Payroll_WorkFlowGridview_Update", obj.Connection());
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@Level", SqlDbType.Int).Value = Convert.ToInt16(lblSrNo.Text);
                                    cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
                                    cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
                                    cmd.Parameters.Add("@RequsterCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
                                    cmd.Parameters.Add("@AuthCode", SqlDbType.VarChar, 30).Value = txtAut1.Text;
                                    cmd.Parameters.Add("@AreaApply", SqlDbType.VarChar, 40).Value = DropDownList1.SelectedItem.Value;
                                    cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
                                    cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                                    cmd.ExecuteNonQuery();

                                }
                            }
                        }

                    }
                    dr.Close();
                }
                string script = "alert('Records Updated Successfully !!!!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                string script2 = "alert('Please Select The Record To Update!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }
            BindItemListGridview();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Workflow_Request_Entry.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", GridView1);
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = TextBox1.Text.Split('|')[1].ToString();
            TextBox1.Text = employeecode;
            ClearControls1();
            CheckDesignation1();
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void txtReq_TextChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                TextBox txtReq = (TextBox)gvRow.FindControl("txtReq");
                if (txtReq.Text.Contains("|"))
                {
                    if (txtReq.Text != "")
                    {
                        string employeecode = txtReq.Text.Split('|')[1].ToString();
                        txtReq.Text = employeecode;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void txtAut_TextChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                TextBox txtAut = (TextBox)gvRow.FindControl("txtAut");
                if (txtAut.Text.Contains("|"))
                {
                    if (txtAut.Text != "")
                    {
                        string employeecode = txtAut.Text.Split('|')[1].ToString();
                        txtAut.Text = employeecode;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkFreeze0_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Workflow_CommonRequest_Entry.aspx");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Value == "Leave" || DropDownList1.SelectedItem.Value.ToLower() == "workfromhome")
        {
            VisibleControls();
        }
        else
        {
            NotVisibleControls();
        }
        BindItemListGridview();
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindItemListGridview();
    }
    protected void lnkFreeze1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        try
        {
            cmd = new SqlCommand("Jct_Payroll_WorkFlowGridview_Deactivate", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@RequsterCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
            cmd.Parameters.Add("@AreaApply", SqlDbType.VarChar, 40).Value = DropDownList1.SelectedItem.Value;
            cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            string script = "alert('Records Deactivated Successfully !!!!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
        BindItemListGridview();
    }
    protected void lnkFreeze2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Workflow_RequestDeptwise_Report.aspx");
    }
    protected void lnkFreeze3_Click(object sender, EventArgs e)
    {
        Response.Redirect("PortalAutoRights.aspx");
    }
    protected void LinkButton1del_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        try
        {
            string OK = string.Empty;
            foreach (GridViewRow gvRow1 in GridView1.Rows)
            {
                CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chkRemove");
                if (chkRemove1.Checked == true)
                {
                    OK = "OK";
                }
            }

            if (OK == "OK")
            {

                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
                    TextBox txtReq1 = (TextBox)gvRow.FindControl("txtReq");
                    TextBox txtAut1 = (TextBox)gvRow.FindControl("txtAut");
                    Label lblSrNo = (Label)gvRow.FindControl("lblSrNo");
                    if (chkRemove.Checked == true)
                    {
                        cmd = new SqlCommand("Jct_Payrollportal_Remove_Top_Hierarchy", obj.Connection());
                        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                        cmd.Parameters.Add("@HodCode", SqlDbType.VarChar, 10).Value = txtAut1.Text;
                        cmd.ExecuteNonQuery();
                    }
                }

                string script = "alert('Records Deleted Successfully !!!!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                string script2 = "alert('Please Select The Record To Delete!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }
            BindItemListGridview();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }
}