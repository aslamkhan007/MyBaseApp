using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Payroll_Loan_Rate_Master : System.Web.UI.Page
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
            //ddlCalcuationMethodBind();

            //if (ddlLoanType.SelectedItem.Value != null || ddlLoanType.SelectedItem.Value != "")
            //{
            //    CheckValue = ddlLoanType.SelectedItem.Value;

            //    if (CheckValue == "DED-110")
            //    {
            //        lblBankName.Visible = true;
            //        ddlBankName.Visible = true;                    
            //    }                   
            //}

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
        string sql = "SELECT  Deduction_code ,Deduction_Long_Description FROM    dbo.JCT_payroll_deduction_master WHERE   STATUS = 'A' AND Deduction_Type = 'loan' Order by Deduction_Long_Description";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLoanType.DataSource = ds;
        ddlLoanType.DataTextField = "Deduction_Long_Description";
        ddlLoanType.DataValueField = "Deduction_code";
        ddlLoanType.DataBind();
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_payroll_LoanRate_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoanCode ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            cmd.Parameters.Add("@LoansDescription ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Text;
            //if (ddlBankName.Visible == true)
            //{
            //    cmd.Parameters.Add("@BankName", SqlDbType.VarChar, 30).Value = ddlBankName.SelectedItem.Text;
            //}
            //if (ddlBankName.Visible == true)
            //{
            //    cmd.Parameters.Add("@Bank_Code", SqlDbType.VarChar, 30).Value = ddlBankName.SelectedItem.Value;
            //}
            cmd.Parameters.Add("@CalcuationMethod", SqlDbType.VarChar, 30).Value = ddlCalculationMethod.SelectedItem.Text;
            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = txtRate.Text;
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.VarChar, 50).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
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
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoanCode ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            cmd.Parameters.Add("@LoansDescription ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Text;

            //if (ddlBankName.Visible == true)
            //{
            //    cmd.Parameters.Add("@BankName", SqlDbType.VarChar, 30).Value = ddlBankName.SelectedItem.Text;
            //}
            //if (ddlBankName.Visible == true)
            //{
            //    cmd.Parameters.Add("@Bank_Code", SqlDbType.VarChar, 30).Value = ddlBankName.SelectedItem.Value;
            //}

            cmd.Parameters.Add("@CalcuationMethod", SqlDbType.VarChar, 30).Value = ddlCalculationMethod.SelectedItem.Text;
            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = txtRate.Text;
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.VarChar, 50).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record updated !');";
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
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoanCode ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            cmd.Parameters.Add("@LoansDescription ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Text;

            //if (ddlBankName.Visible == true)
            //{
            //    cmd.Parameters.Add("@BankName", SqlDbType.VarChar, 30).Value = ddlBankName.SelectedItem.Text;
            //}
            //if (ddlBankName.Visible == true)
            //{
            //    cmd.Parameters.Add("@Bank_Code", SqlDbType.VarChar, 30).Value = ddlBankName.SelectedItem.Value;
            //}

            cmd.Parameters.Add("@CalcuationMethod", SqlDbType.VarChar, 30).Value = ddlCalculationMethod.SelectedItem.Text;
            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = txtRate.Text;
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.VarChar, 50).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record deleted !');";
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
        Response.Redirect("Loan_Rate_Master.aspx");
    }

    private void bindgrid()
    {
        //sql = "SELECT  [LoanType_code] AS [LoanType code] ,[LoanType_ShortDescription] [LoanType],BankName,Calcuation_Method  AS [Calcuation Method] ,[Rate] AS  [Rate] ,Effective_From ,Effective_To FROM    JCT_payroll_LoanRate_master WHERE   STATUS = 'A'";
        sql = "SELECT  [LoanCode] AS LoanCode , LoansDescription LoansDescription ,CalcuationMethod  ,[Rate] AS [Rate] ,CONVERT(VARCHAR,EffectiveFrom,101)  AS EffectiveFrom  ,CONVERT(VARCHAR,EffectiveTo,101) AS EffectiveTo FROM    JCT_payroll_LoanRate_master WHERE   STATUS = 'A'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
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


        //string CheckBankTypeCode =  grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        //if (CheckBankTypeCode == "DED-110")
        //{
        //    ddlBankName.Visible = true;
        //    lblBankName.Visible = true;
        //    ddlBankName.SelectedIndex = ddlBankName.Items.IndexOf(ddlBankName.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "")));
        //}
        //else
        //{
        //    ddlBankName.Visible = false;
        //    lblBankName.Visible = false;
        //}        
        txtRate.Text = grdDetail.SelectedRow.Cells[4].Text;

        ddlCalculationMethod.SelectedIndex = ddlCalculationMethod.Items.IndexOf(ddlCalculationMethod.Items.FindByValue(grdDetail.SelectedRow.Cells[3].Text));
        //txtRate.Text = grdDetail.SelectedRow.Cells[4].Text;
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
        //if (ddlLoanType.SelectedItem.Value != null || ddlLoanType.SelectedItem.Value != "")
        //{
        //    CheckValue = ddlLoanType.SelectedItem.Value;

        //    if (CheckValue == "DED-110")
        //    {
        //        lblBankName.Visible = true;
        //        ddlBankName.Visible = true;
        //    }
        //    else
        //    {
        //        lblBankName.Visible = false;
        //        ddlBankName.Visible = false;
        //    }
        //}

        //ddlCalcuationMethodBind();
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

    //public void ddlCalcuationMethodBind()
    //{
    //    string sql = "jct_payroll_loans_advance_Fixed_Reducing";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@LoanType_code ", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlCalculationMethod.DataSource = ds;
    //    ddlCalculationMethod.DataTextField = "Calculation_Method";
    //    ddlCalculationMethod.DataValueField = "Calculation_Method";
    //    ddlCalculationMethod.DataBind();
       
    //}

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