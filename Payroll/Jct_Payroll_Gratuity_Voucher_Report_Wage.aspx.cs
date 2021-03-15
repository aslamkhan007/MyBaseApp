using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_Gratuity_Voucher_Report_Wage : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string CheckValue = string.Empty;
    int CheckEligile = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecord();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    public void FetchRecord()
    {
        string sql = "Jct_Payroll_Gratuity_Voucher_Print";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        if (txtEmployee.Text != "")
        {
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        }
        //else
        //{
        //    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "All";
        //}
        cmd.ExecuteNonQuery();
        SqlDataAdapter Da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
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

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Gratuity_Voucher_Report_Wage.aspx");
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        //CheckEligibility();
        Response.Redirect("Jct_Payroll_Gratuity_Voucher_Print_Wage.aspx?YEARMONTH=" + txttodate.Text + "&empcode=" + txtEmployee.Text);
    }

    public void CheckEligibility()
    {
        try
        {
            string sql = "Jct_Payroll_Designation_Wise_Voucher";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (Convert.ToString(dr["status"]) == "Yes")
                    {
                        dr.Close();
                        Response.Redirect("Jct_Payroll_Conveyance_Voucher_Print.aspx?YEARMONTH=" + txttodate.Text + "&empcode=" + txtEmployee.Text);
                    }
                    if (Convert.ToString(dr["status"]) == "No")
                    {
                        dr.Close();
                        string script = "alert('You Are Not Entitled For This');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }
                }
            }
            dr.Close();
        }
        catch (Exception ex)
        {
            CheckEligile = 1;
            string Scrpt = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
        }
    }
}