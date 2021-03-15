using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Payroll_Jct_Payroll_Loan_Rate_Master : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string CheckValue = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            txteff_to_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
            LoanTypeList();
            CalMethod();            
        }
    }

    public void CalMethod()
    {
        string sql = "SELECT ShortDesc,LongDesc  FROM Jct_Payroll_Calculation_MethodType";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlCalculationMethod.DataSource = ds;
        ddlCalculationMethod.DataTextField = "ShortDesc";
        ddlCalculationMethod.DataValueField = "LongDesc";
        ddlCalculationMethod.DataBind();

        if (ddlCalculationMethod.SelectedItem.Text == "Fixed")
        {
            txtRate.Text = "0";
            txtRate.Enabled = false;
        }
        else
        {
            txtRate.Enabled = true;
        }
    }

    public void LoanTypeList()
    {
        string sql = "Jct_Payroll_Loans_Advance_List";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLoanType.DataSource = ds;
        ddlLoanType.DataTextField = "ComponentName";
        ddlLoanType.DataValueField = "ComponentCode";
        ddlLoanType.DataBind();
    }


    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_payroll_LoanRate_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoanCode ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            cmd.Parameters.Add("@LoansDescription ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Text;       
            cmd.Parameters.Add("@CalcuationMethod", SqlDbType.VarChar, 30).Value = ddlCalculationMethod.SelectedItem.Text;
            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = txtRate.Text;
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.VarChar, 50).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record Saved !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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
            string sql = "JCT_payroll_LoanRate_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoanCode ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            cmd.Parameters.Add("@LoansDescription ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Text;
            cmd.Parameters.Add("@CalcuationMethod", SqlDbType.VarChar, 30).Value = ddlCalculationMethod.SelectedItem.Text;
            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = txtRate.Text;
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.VarChar, 50).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record Updated !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('some error occurred!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_payroll_LoanRate_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoanCode ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            cmd.Parameters.Add("@LoansDescription ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Text;
            cmd.Parameters.Add("@CalcuationMethod", SqlDbType.VarChar, 30).Value = ddlCalculationMethod.SelectedItem.Text;
            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = txtRate.Text;
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.VarChar, 50).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record Deleted !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('some error occurred!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Loan_Rate_Master.aspx");
    }

    private void bindgrid()
    {
        //sql = "SELECT  [LoanType_code] AS [LoanType code] ,[LoanType_ShortDescription] [LoanType],BankName,Calcuation_Method  AS [Calcuation Method] ,[Rate] AS  [Rate] ,Effective_From ,Effective_To FROM    JCT_payroll_LoanRate_master WHERE   STATUS = 'A'";
        sql = "Jct_Payroll_LoanRate_GridList";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLoanType.SelectedIndex = ddlLoanType.Items.IndexOf(ddlLoanType.Items.FindByValue(grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "")));    
        txtRate.Text = grdDetail.SelectedRow.Cells[4].Text;
        ddlCalculationMethod.SelectedIndex = ddlCalculationMethod.Items.IndexOf(ddlCalculationMethod.Items.FindByValue(grdDetail.SelectedRow.Cells[3].Text));        
        txteff_from.Text = grdDetail.SelectedRow.Cells[5].Text;
        txteff_to.Text = grdDetail.SelectedRow.Cells[6].Text;
        if (ddlCalculationMethod.SelectedItem.Text == "Fixed")
        {
            txtRate.Text = "0";
            txtRate.Enabled = false;
        }
        else
        {
            txtRate.Enabled = true;
        }
    }

    protected void ddlLoanType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCalculationMethod.SelectedItem.Text == "Fixed")
        {
            txtRate.Text = "0";
            txtRate.Enabled = false;
        }
        else
        {
            txtRate.Enabled = true;
        }
    }

    protected void ddlCalculationMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCalculationMethod.SelectedItem.Text == "Fixed")
        {
            txtRate.Text = "0";
            txtRate.Enabled = false;
        }
        else
        {
            txtRate.Enabled = true;
        }
    }

}