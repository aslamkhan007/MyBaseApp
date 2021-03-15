using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Payroll_Jct_Payroll_OvertimeEntry_New : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string qry;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();            
        }
    }

    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_SalaryCal_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                TxtOvertimeDate.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }

    protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    {
        //ClearTextBoxes();
        //Label2.Visible = true;
        //Label4.Visible = true;
        //Label6.Visible = true;    

        //Label5.Visible = true;
        //Label3.Visible = true;
        ////Label1.Visible = true;          
        //LblDept.Visible = true;
        //LblDeptname.Visible = true;
        //LblDesg.Visible = true;
        //LblDesgName.Visible = true;
        CheckDesignation();
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_Payroll_Overtime_Update_New";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = TxtOvertimeDate.Text;
            cmd.Parameters.Add("@Paycode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@Overtime", SqlDbType.Decimal, 10).Value = TxtOvertimeHours.Text;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = Label2.Text;
            cmd.Parameters.Add("@Dept", SqlDbType.VarChar, 100).Value = LblDeptname.Text;
            cmd.Parameters.Add("@SubDept", SqlDbType.VarChar, 100).Value = LblDesgName.Text;
            //cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            //cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
            //cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            string script = "alert('Record Inserted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //ClearTextBoxes();   
            txtEmpCode.Text = "";
            lnkupdate.Enabled = false;
            Label2.Text = "";
            LblDeptname.Text = "";            
            LblDesgName.Text = "";            
            TxtOvertimeHours.Text = "";
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_OvertimeEntry_New.aspx");
    }

    public void CheckDesignation()
    {

        string employeecode = txtEmpCode.Text;

        Label2.Text = "";
        LblDeptname.Text = "";
        
        LblDesgName.Text = "";
        
        TxtOvertimeHours.Text = "";
        string sql = "JCT_Payroll_Overtime_Fetch_New";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Date", SqlDbType.Int).Value = TxtOvertimeDate.Text;
        cmd.Parameters.Add("@Paycode", SqlDbType.VarChar, 10).Value = employeecode;
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                string designation;
                string department;
                string overtime;
                overtime = dr["OvertimeHrs"].ToString();
                TxtOvertimeHours.Text = overtime;
                Label2.Text = dr["EmployeeName"].ToString();
                
                designation = dr["Subdepartment"].ToString();
                department = dr["Department"].ToString();
                LblDeptname.Text = department;
                LblDesgName.Text = designation;
                lnkupdate.Enabled = true;
                if (overtime.Equals("Yes"))
                {

                }
                else
                {
                    //string script = "alert('No Record Found!!');";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
            }
        }
    }

    //private void ClearTextBoxes()
    //{

    //    Label1.Text = "";
    //    Label4.Text = "";
    //    Label6.Text = "";
    //    //txtEmpCode.Text = "";        
    //    TxtOvertimeHours.Text = "";
    //    //TxtOvertimeReason.Text = "";      
    //    LblDept.Visible = false;
    //    LblDeptname.Visible = false;
    //    LblDesg.Visible = false;
    //    LblDesgName.Visible = false;
    //    SrCode.Visible = false;
    //    SrId.Visible = false;
    //    lnkupdate.Enabled = false;        
    //}     
    protected void TxtOvertimeDate_TextChanged(object sender, EventArgs e)
    {
        CheckDesignation();
    }
}