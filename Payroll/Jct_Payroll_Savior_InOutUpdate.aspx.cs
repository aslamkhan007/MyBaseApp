using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_Savior_InOutUpdate : System.Web.UI.Page
{
    Connection obj = new Connection();
    string loantype;
    string deductioncode;
    string CheckValue = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
                      
        }
    }        
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployeeCode.Text;
            string sql = "JCT_Payroll_Punch_Update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //SqlCommand cmd = new SqlCommand("JCT_Payroll_Punch_Update", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = txtefffrm.Text;
            cmd.Parameters.Add("@Paycode", SqlDbType.VarChar, 20).Value = employeecode;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar,30).Value = lblName.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 6).Value = Label5.Text;
            cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = lblshift.Text;
            cmd.Parameters.Add("@ShiftAttend", SqlDbType.VarChar, 3).Value = lblshift.Text;
            cmd.Parameters.Add("@In", SqlDbType.VarChar, 5).Value = txtIn1.Text;
            cmd.Parameters.Add("@LunchOut", SqlDbType.VarChar, 5).Value = txtOut1.Text;
            cmd.Parameters.Add("@LunchIn", SqlDbType.VarChar, 5).Value = txtIn2.Text;
            cmd.Parameters.Add("@Out", SqlDbType.VarChar, 5).Value = txtOut2.Text;
            cmd.Parameters.Add("@Hourswork", SqlDbType.VarChar, 3).Value = txtHours.Text;
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = (Session["Empcode"]);
            cmd.Parameters.Add("@ip", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            string script = "alert('Record Updated Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextbox();
            lblName.Text = "";
            lblshift.Text = "";
            txtEmployeeCode.Text = "";
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Savior_InOutUpdate.aspx");
    }

    protected void txtEmployeeCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            cleartextbox();
            string employeecode = txtEmployeeCode.Text;
            string sql = "JCT_Payroll_Punch_Fetch";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = txtefffrm.Text;
            cmd.Parameters.Add("@Paycode", SqlDbType.VarChar, 20).Value = employeecode;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblName.Text = dr["EmployeeName"].ToString();
                    sshit.Text = dr["SHIFT"].ToString();
                    lblshift.Text = dr["SHIFTATTENDED"].ToString();
                    Label5.Text = dr["STATUS"].ToString();
                    txtIn1.Text = dr["In"].ToString();
                    txtOut1.Text = dr["LunchOut"].ToString();
                    txtIn2.Text = dr["LunchIn"].ToString();
                    txtOut2.Text = dr["Out"].ToString();
                    txtHours.Text = dr["HOURSWORKED"].ToString();                
                }
            }
            dr.Close();
        }
        catch (Exception exception)
        {
            lblName.Text = "";
            lblshift.Text = "";
            txtEmployeeCode.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }   
    public void cleartextbox()
    {
        txtIn1.Text = "";
        txtOut1.Text = "";
        txtIn2.Text = "";        
        txtOut2.Text = "";
        txtHours.Text = "";
        lblshift.Text = "";
        Label5.Text  = "";
        lblName.Text = "";
        sshit.Text = "";
    }
    protected void lnkreset0_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Savior_Punch_Transfer.aspx");
    }
}