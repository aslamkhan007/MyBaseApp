using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_Reimbursement_Entry : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            AttendenceDate1();
            Componentlist();
        }
    }

    public void ClearControls()
    {
        lbdept.Text = "";
        lbdesign.Text = "";
        //lbldedamount.Text = "";
        lblEmployeeName.Text = "";
        lblCompanyname.Text = "";
    }

    public void Componentlist()
    {
        string sql = "Jct_Payroll_Reimbursement_ParameterList";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldedtype.DataSource = ds;
        ddldedtype.DataTextField = "ComponentName";
        ddldedtype.DataValueField = "ComponentCode";
        ddldedtype.DataBind();
    }

    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Reimbursement_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodate.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }


    public void AttendenceDate1()
    {
        //DateTime origDT = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        //origDT = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(-1);
        //txtfromdate.Text = Convert.ToDateTime(origDT).ToShortDateString();
        //DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        //txttodate_CalendarExtender.SelectedDate = lastDate;
        string sqlqry = "Jct_Payroll_Reimbursement_Current_Period";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txtfromdate.Text = dr["FromDate"].ToString();
                TextBox1.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }

    public void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            CheckDesignation();
        }
        catch (Exception exception)
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            lbdept.Text = "";
            lbdesign.Text = "";
            lblCompanyname.Text = "";
            lblEmployeeName.Text = "";
            txtEmployee.Text = "";
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        try
        {
            CheckExistingRecords();
            //BindGrid();
            if (ddldedtype.SelectedItem.Value == "COM-114")
            {
                txtCity.Visible = true;
                Label9.Visible = true;
            }
            else
            {
                txtCity.Visible = false;
                Label9.Visible = false;
            }
        }
        catch (Exception exception)
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            lbdept.Text = "";
            lbdesign.Text = "";
            lblCompanyname.Text = "";
            lblEmployeeName.Text = "";
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckDesignation()
    {
        string employeecode = txtEmployee.Text.Split('|')[1].ToString();
        txtEmployee.Text = employeecode;
        string sql = "Jct_Payroll_Reimbursement_Designation_Detail_WithoutParam";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@ReimbursementType", SqlDbType.VarChar, 25).Value = ddldedtype.SelectedItem.Value;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                string desigination;
                string department;
                desigination = dr["Desg_Long_Description"].ToString();
                department = dr["Department_Long_Description"].ToString();
                lblCompanyname.Text = dr["Plant_description"].ToString();
                lblEmployeeName.Text = dr["EmployeeName"].ToString();
                lbdesign.Visible = true;
                lbdept.Visible = true;
                lblEmployeeName.Visible = true;
                lblCompanyname.Visible = true;
                lbdept.Text = department;
                lbdesign.Text = desigination;
            }
            dr.Close();
        }
    }

    public void CheckDesignation1()
    {
        string employeecode = txtEmployee.Text.ToString();
        txtEmployee.Text = employeecode;
        string sql = "Jct_Payroll_Reimbursement_Designation_Detail";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ReimbursementType", SqlDbType.VarChar, 25).Value = ddldedtype.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = txtfromdate.Text;
        cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = TextBox1.Text;
        cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                string desigination;
                string department;
                desigination = dr["Desg_Long_Description"].ToString();
                department = dr["Department_Long_Description"].ToString();
                lblCompanyname.Text = dr["Plant_description"].ToString();
                lblEmployeeName.Text = dr["EmployeeName"].ToString();
                //lbldedamount.Text = dr["ComponentValue"].ToString();
                //lblMonths.Text = dr["Monthdiff"].ToString();
                //txtdedamount.Text = "0";
                lbdesign.Visible = true;
                lbdept.Visible = true;
                lblEmployeeName.Visible = true;
                lblCompanyname.Visible = true;
                lbdept.Text = department;
                lbdesign.Text = desigination;
            }
            dr.Close();
        }
    }

    public void CheckExistingRecords()
    {
        try
        {
            //lbldedamount.Text = "";
            //lblMonths.Text = "";
            string employeecode = txtEmployee.Text.ToString();
            txtEmployee.Text = employeecode;
            string sql = "Jct_Payroll_Converyance_Reimbursement_Fetch";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@ReimbursementType", SqlDbType.VarChar, 25).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //lbldedamount.Text = dr[0].ToString();
                    txtCity.Text = dr[0].ToString();
                    txtfromdate.Text = dr[1].ToString();
                    TextBox1.Text = dr[2].ToString();
                    //lblMonths.Text = dr[4].ToString();
                    //lnkUpdate.Visible = true;
                    BindGrid();
                }
            }
            else
            {
                CheckDesignation1();
            }
            dr.Close();
        }
        catch (Exception exception)
        {
            lbdept.Text = "";
            lbdesign.Text = "";
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmployee.Text = "";
        ClearControls();
        //lnkUpdate.Visible = false;
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.ToString();
            txtEmployee.Text = employeecode;
            SqlCommand cmd = new SqlCommand("Jct_Payroll_Converyance_Reimbursement_Insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@ReimbursementType", SqlDbType.VarChar, 25).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = employeecode;
            cmd.Parameters.Add("@EntertainedPersonName", SqlDbType.VarChar, 25).Value = lblEmployeeName.Text;
            cmd.Parameters.Add("@EntertainedPersonDesignation", SqlDbType.VarChar, 25).Value = lbdesign.Text;
            cmd.Parameters.Add("@EntertainedPersonCompanyName", SqlDbType.VarChar, 30).Value = lblCompanyname.Text;
            cmd.Parameters.Add("@PlaceofEntertainment", SqlDbType.VarChar, 25).Value = txtCity.Text;
            //if (lbldedamount.Text != "")
            //{
            //    cmd.Parameters.Add("@Amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(lbldedamount.Text);
            //}
            //else
            //{
            //    cmd.Parameters.Add("@Amount", SqlDbType.Decimal, 2).Value = 0.00;
            //}
            cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = txtfromdate.Text;
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = TextBox1.Text;
            cmd.ExecuteNonQuery();
            string script = "alert('Record Saved Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            BindGrid();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    //protected void lnkUpdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string employeecode = txtEmployee.Text.ToString();
    //        txtEmployee.Text = employeecode;
    //        SqlCommand cmd = new SqlCommand("Jct_Payroll_Converyance_Reimbursement_Update", obj.Connection());
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
    //        cmd.Parameters.Add("@ReimbursementType", SqlDbType.VarChar, 25).Value = ddldedtype.SelectedItem.Value;
    //        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = employeecode;
    //        cmd.Parameters.Add("@EntertainedPersonName", SqlDbType.VarChar, 25).Value = lblEmployeeName.Text;
    //        cmd.Parameters.Add("@EntertainedPersonDesignation", SqlDbType.VarChar, 25).Value = lbdesign.Text;
    //        cmd.Parameters.Add("@EntertainedPersonCompanyName", SqlDbType.VarChar, 30).Value = lblCompanyname.Text;
    //        cmd.Parameters.Add("@PlaceofEntertainment", SqlDbType.VarChar, 25).Value = txtCity.Text;
    //        //cmd.Parameters.Add("@Amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(lbldedamount.Text);
    //        cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
    //        cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
    //        cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = txtfromdate.Text;
    //        cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = TextBox1.Text;
    //        cmd.ExecuteNonQuery();
    //        string script = "alert('Record Updated Successfully.');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //        lnkUpdate.Enabled = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        string script = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }
    //}

    public void BindGrid()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Converyance_Reimbursement_BindGrid";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        if (txtEmployee.Text != "")
        {
            Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
        }
        Cmd.Parameters.Add("@ReimbursementType", SqlDbType.VarChar, 25).Value = ddldedtype.SelectedItem.Value;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Reimbursement_Entry.aspx");
    }
}