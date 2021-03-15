using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Payroll_Jct_Payroll_Gratuity_Calculation : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string CheckValue = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            AttendenceDate1();
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

    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Gratuity_Cal_Freeze_Wage";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
            cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            string scripts = "alert('Calculation Freezed');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", scripts, true);
            return;

        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    public void AttendenceDate1()
    {
        DateTime origDT = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        origDT = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(-1);
        txtfromdate.Text = Convert.ToDateTime(origDT).ToShortDateString();
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Gratuity_Calculation.aspx");
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
        string sql = "Jct_Payroll_Gratuity_Calculation";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;

        if (txtfromdate.Text != "")
        {
            cmd.Parameters.Add("@DOleaving", SqlDbType.DateTime).Value = txtfromdate.Text;
        }
        //else
        //{
        //    cmd.Parameters.Add("@DOleaving", SqlDbType.DateTime).Value = "";            
        //}
       
        cmd.Parameters.Add("@LeavingReason", SqlDbType.VarChar, 50).Value = txtRemarks.Text;
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

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
}