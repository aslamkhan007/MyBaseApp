using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_Jct_Payroll_Tax_Correction : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

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
                txttodate.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
            ClearControls();
            CheckDesignation();
            CheckRecord();
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
        string sql = "Jct_Payroll_Tax_Employee_Fetch";
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


    public void CheckRecord()
    {
        string sql = "Jct_Payroll_Tax_Correction_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Yearmonth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtdedamount.Text = dr[0].ToString();
                TextBox1.Text = dr[1].ToString();
                TextBox2.Text = dr[2].ToString();
            }
            dr.Close();
        }
    }


    public void ClearControls()
    {
        lblEmployeeName.Text = "";
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("Jct_Payroll_Tax_Correction", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Yearmonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            cmd.Parameters.Add("@Tax", SqlDbType.Int).Value = Convert.ToInt32(txtdedamount.Text);
            cmd.Parameters.Add("@Cess", SqlDbType.Int).Value = Convert.ToInt32(TextBox1.Text);
            cmd.Parameters.Add("@ProfTax", SqlDbType.Int).Value = Convert.ToInt32(TextBox2.Text);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Updated Successfully.');";
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
        Response.Redirect("Jct_Payroll_Tax_Correction.aspx");
    }
}