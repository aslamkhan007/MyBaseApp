using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_Overtime_Entry_Wages : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string qry;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            TxtOvertimeDate.Text = DateTime.Now.ToString();
        }

    }
    protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    {
        LblDept.Visible = true;
        LblDeptname.Visible = true;
        LblDesg.Visible = true;
        LblDesgName.Visible = true;
        CheckDesignation();

    }
    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            //int x;
            //x = timecalculate();
            //if (x == 1)
            //{
                string sql = "Jct_Payroll_Overtime_Detail_Insert_Wages";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
                cmd.Parameters.Add("@OvertimeDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtOvertimeDate.Text);
                //cmd.Parameters.Add("@OvertimeReason", SqlDbType.VarChar, 50).Value = TxtOvertimeReason.Text;
                //cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = txttimefrom.SelectedTime;
                //cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = TxtTimeTo.SelectedTime;
                cmd.Parameters.Add("@OvertimeHrs", SqlDbType.VarChar, 10).Value = TxtOvertimeHours.Text;
                cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
                bindgrid();
                string script = "alert('Record saved.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //CalculateTotalHrs();

                ClearTextBoxes();


            //}
            //else
            //{
            //    string script = "alert('Overtime hours should be more than 1.!!');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //}
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            //int x;
            //x = timecalculate();
            //if (x == 1)
            //{

                string sql = "Jct_Payroll_Overtime_Detail_Update_Wage";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
                cmd.Parameters.Add("@OvertimeDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtOvertimeDate.Text);
                //cmd.Parameters.Add("@OvertimeReason", SqlDbType.VarChar, 50).Value = TxtOvertimeReason.Text;
                //cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = txttimefrom.SelectedTime;
                //cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = TxtTimeTo.SelectedTime;
                cmd.Parameters.Add("@OvertimeHrs", SqlDbType.VarChar, 10).Value = TxtOvertimeHours.Text;
                cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
                cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
                bindgrid();
                string script = "alert('Record updated.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //CalculateTotalHrs();

                ClearTextBoxes();
            //}
            //else
            //{
            //    string script = "alert('Overtime hours should be more than 1.!!');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //}
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Overtime_Detail_Delete_Wage";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('some error occurred!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Overtime_Entry_Wages.aspx");
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkupdate.Enabled = true;
        lnkdelete.Enabled = true;
        SrCode.Visible = true;
        SrId.Visible = true;
        SrId.Text = grdDetail.SelectedRow.Cells[1].Text;
        txtEmpCode.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[2].Text);
        LblDesgName.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[3].Text);
        LblDeptname.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[4].Text);
        TxtOvertimeDate.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[5].Text);
        //TxtOvertimeReason.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[6].Text);
        //txttimefrom.SelectedTime = Convert.ToDateTime(HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[7].Text));
        //TxtTimeTo.SelectedTime = Convert.ToDateTime(HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[8].Text));
        TxtOvertimeHours.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[9].Text);
    }
    public void CheckDesignation()
    {
        string employeecode = txtEmpCode.Text;
        string sql = "Jct_Payroll_Overtime_Entitlement_Detail";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = employeecode;
        //SqlDataReader dr = cmd.ExecuteReader();
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                string designation;
                string department;
                string overtime;
                overtime = dr["Overtime"].ToString();
                designation = dr["Desg_Long_Description"].ToString();
                department = dr["Department_Long_Description"].ToString();
                LblDeptname.Text = department;
                LblDesgName.Text = designation;

                if (overtime.Equals("Yes"))
                {
                    lnkapply.Enabled = true;

                }
                else
                {
                    string script = "alert('You are not entitled for overtime!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
            }
        }
        bindgrid();
    }
    private void bindgrid()
    {
        sql = "Jct_Payroll_Overtime_Details_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
    private void ClearTextBoxes()
    {
        txtEmpCode.Text = "";
        //TxtOvertimeDate.Text = "";
        TxtOvertimeHours.Text = "";
        TxtOvertimeReason.Text = "";
        txttimefrom.Text = "";
        TxtTimeTo.Text = "";
        LblDept.Visible = false;
        LblDeptname.Visible = false;
        LblDesg.Visible = false;
        LblDesgName.Visible = false;
        SrCode.Visible = false;
        SrId.Visible = false;
        lnkupdate.Enabled = false;
        lnkdelete.Enabled = false;
    }

    protected void TxtTimeTo_TimeChanged(object sender, EventArgs e)
    {
        sql = "Jct_Payroll_Overtime_Hrs_Calculate";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = txttimefrom.SelectedTime;
        cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = TxtTimeTo.SelectedTime;
        SqlDataReader DR = cmd.ExecuteReader();
        if (DR.Read())
        {
            TxtOvertimeHours.Text = DR["CalculatedTime"].ToString();
        }
        DR.Close();
    }
    protected int timecalculate()
    {
        DateTime t1 = Convert.ToDateTime("1:00:00");
        DateTime t2 = Convert.ToDateTime(TxtOvertimeHours.Text);
        int i = DateTime.Compare(t2, t1);
        if (i > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    //protected void CalculateTotalHrs()
    //{
    //        string sql = "Jct_Payroll_Overtime_Total_Hrs_Calculation";
    //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
    //        cmd.Parameters.Add("@OvertimeDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtOvertimeDate.Text);
    //        cmd.ExecuteNonQuery();

    //}
}