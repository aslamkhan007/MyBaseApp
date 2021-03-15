using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_PL_Encashment : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string loantype;
    string eleccode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
        }
    }

    public void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CheckDesignation();
            CheckExistingRecords();
        }
        catch (Exception exception)
        {
            lbdept.Text = "";
            lbdesign.Text = "";            
            lblEmployeeName.Text = "";
            txtBasic.Text = "";
            txtBankAccount.Text = "";
            txtPlBalnace.Text = "";   
            txtEmployee.Text = "";
            txtencashmentdays.Text = "";
            lblLastencashment.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckDesignation()
    {
        SqlCommand cmd = new SqlCommand("JCT_Payroll_Initalise_LeaveBalance_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        //cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
        //cmd.ExecuteNonQuery();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {                
                lbdesign.Text = dr[0].ToString();
                lbdept.Text = dr[1].ToString();
                lblEmployeeName.Text = dr[2].ToString();
                txtEmployee.Text = dr[3].ToString();                
                txtBasic.Text = dr[4].ToString();
                txtBankAccount.Text = dr[5].ToString();
                txtPlBalnace.Text = dr[6].ToString();
                lblLastencashment.Text = dr[7].ToString();  
                lbdesign.Visible = true;
                lbdept.Visible = true;
                lblEmployeeName.Visible = true;                                
            }
            dr.Close();
        }
    }

    public void CheckExistingRecords()
    {
        try
        {            
            string employeecode = txtEmployee.Text.ToString();
            txtEmployee.Text = employeecode;
            string sql = "Jct_Payroll_PL_Encashment_ExistingFetch";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;                        
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtEmployee.Text = dr[0].ToString();
                    txtPlBalnace.Text = dr[1].ToString();
                    txtencashmentdays.Text = dr[2].ToString();
                    txttodate.Text = dr[3].ToString();
                    lblLastencashment.Text = dr[4].ToString();                    
                    lnkUpdate.Visible = true;
                }
            }
            else
            {                              
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

    public void ClearControls()
    {
        lbdept.Text = "";
        lbdesign.Text = "";        
        lblEmployeeName.Text = "";     
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {            
            string employeecode = txtEmployee.Text.ToString();
            txtEmployee.Text = employeecode;
            SqlCommand cmd = new SqlCommand("Jct_Payroll_PL_Encashment_Insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = employeecode;
            cmd.Parameters.Add("@PlBalance", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtPlBalnace.Text);
            if (lblLastencashment.Text != "")
            {
                cmd.Parameters.Add("@LastEncashment", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(lblLastencashment.Text);
            }                        
            cmd.Parameters.Add("@EncasmentDays", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtencashmentdays.Text);
            cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Saved Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_PL_Encashment.aspx");
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
                txttodate.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }

    protected void lnkUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.ToString();
            txtEmployee.Text = employeecode;
            SqlCommand cmd = new SqlCommand("Jct_Payroll_PL_Encashment_Update", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = employeecode;
            cmd.Parameters.Add("@PlBalance", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtPlBalnace.Text);
            if (lblLastencashment.Text != "")
            {
                cmd.Parameters.Add("@LastEncashment", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(lblLastencashment.Text);
            }
            cmd.Parameters.Add("@EncasmentDays", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtencashmentdays.Text);
            cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Updated Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lnkUpdate.Enabled = false;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
}