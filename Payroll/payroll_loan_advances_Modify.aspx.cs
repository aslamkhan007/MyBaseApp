using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Payroll_payroll_loan_advances_Modify : System.Web.UI.Page
{
    Connection obj = new Connection();
    string loantype;
    string deductioncode;
    string CheckValue = string.Empty;
    string bancode;
    string calcode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoanTypeList();
            //Plantbind();
            //Locationbind();

            //ddlCalcuationMethodBind();
            //if (ddlLoanType.SelectedItem.Value != null || ddlLoanType.SelectedItem.Value != "")
            //{
            //    CheckValue = ddlLoanType.SelectedItem.Value;

            //    if (CheckValue == "COM-130")
            //    {
            //        lblBank.Visible = true;
            //        ddlBankLIst.Visible = true;
            //        BankListSelected();
            //    }
            //    else
            //    {
            //        lblBank.Visible = false;
            //        ddlBankLIst.Visible = false;
            //    }
            //}
        }
    }

    public void LoanTypeList()
    {
        string sql = "Jct_Payroll_Loans_Advance_List_Wages";
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

    //public void Plantbind()
    //{
    //    SqlCommand sqlCmd = new SqlCommand("SELECT plant_name,plant_code FROM   jct_payroll_Plant_Master WHERE  STATUS='A'", obj.Connection());
    //    sqlCmd.CommandType = CommandType.Text;
    //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlplant.DataSource = ds;
    //    ddlplant.DataTextField = "plant_name";
    //    ddlplant.DataValueField = "plant_code";
    //    ddlplant.DataBind();

    //}

    //public void Locationbind()
    //{
    //    SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM   JCT_payroll_location_master WHERE  STATUS='A'", obj.Connection());
    //    sqlCmd.CommandType = CommandType.Text;
    //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlLocation.DataSource = ds;
    //    ddlLocation.DataTextField = "Location_description";
    //    ddlLocation.DataValueField = "Location_code";
    //    ddlLocation.DataBind();
    //}

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_loan_advances.aspx");
    }

    //public void ddlCalcuationMethodBind()
    //{
    //    string sql = "SELECT distinct  CalcuationMethod FROM    JCT_payroll_LoanRate_master WHERE   STATUS = 'A' AND Loancode = '" + ddlLoanType.SelectedItem.Value + "'";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlCalcuationMethod.DataSource = ds;
    //    ddlCalcuationMethod.DataTextField = "CalcuationMethod";
    //    ddlCalcuationMethod.DataValueField = "CalcuationMethod";
    //    ddlCalcuationMethod.DataBind();
    //}

    protected void txtEmployeeCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            // TO FILL TEXTBOXE WITH EMPLOYEECODE AND EMPLOYEENAME WITH AUTOCOMPLETE SERVICE AND FILL THE LABLES(lbldesign,lbldepartment)
            string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
            string sql = "SELECT DISTINCT b.Desg_Long_Description,c.Department_Long_Description FROM dbo.JCT_payroll_employees_master a JOIN dbo.JCT_payroll_designation_master b ON a.Designation=b.Designation_code JOIN  dbo.JCT_payroll_department_master c ON a.Department=c.Department_code  WHERE a.Active='Y' and a.status = 'A' and a.EmployeeCode='" + employeecode + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string desigination;
                    string department;
                    desigination = dr["Desg_Long_Description"].ToString();
                    department = dr["Department_Long_Description"].ToString();
                    lbdesign.Visible = true;
                    lbdept.Visible = true;
                    lbdept.Text = department;
                    lbdesign.Text = desigination;
                }
            }
            dr.Close();

            //PlantLocFetch();
            if (ddlLoanType.SelectedItem.Value != null || ddlLoanType.SelectedItem.Value != "")
            {
                CheckValue = ddlLoanType.SelectedItem.Value;

                //if (CheckValue == "COM-130")
                //{
                //    lblBank.Visible = true;
                //    ddlBankLIst.Visible = true;
                //    ddlBankLIst.Items.Clear();
                //    BankListSelected();
                //}
                //else
                //{
                //    lblBank.Visible = false;
                //    ddlBankLIst.Visible = false;
                //}
            }
            // QUERY TO CHECK EXISTING RECORD AGAINST EMPLOYEECODE ,LOAN TYPE AND FILLING THE CORROSPONDING CONTROL
            CheckParameter();
            CheckRecordExisting();
        }
        catch (Exception exception)
        {
            lbdept.Text = "";
            lbdesign.Text = "";
            txtloandt.Text = System.DateTime.Now.ToShortDateString();
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    public void CheckParameter()
    {

        string CheckValue1 = string.Empty;
        string subparam = subparamtr(CheckValue1);
        if (subparam == "1")
        {
            grdDetail.Visible = true;
            FetchRecord();
        }
        else
        {
            grdDetail.Visible = false;
        }
    }


    public string subparamtr(string AllowanceId)
    {
        string sparameter = string.Empty;
        string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
        SqlCommand cmd = new SqlCommand("jct_payroll_loans_advance_deatil_CheckExistingLoan", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@LoanType", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 20).Value = employeecode;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if ((dr["value"].ToString() == "0"))
                {
                    return sparameter;
                }
                else
                {
                    sparameter = dr["value"].ToString();
                }
            }
        }
        dr.Close();
        return sparameter;
    }


    public void FetchRecord()
    {
        string SqlPass = null;
        string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_payroll_loans_advance_deatil_FetchMultipleRecrods_Modify";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@LoanType", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 20).Value = employeecode;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        if (ds.Tables[0].Rows.Count == 0)
        {
            //string script = "alert('No Record Found');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //return;
        }
    }


    //public void BankListSelected()
    //{
    //    string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
    //    string sql = "Jct_Payroll_Loans_EmployeeWise_BankList";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = employeecode;
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlBankLIst.DataSource = ds;
    //    ddlBankLIst.DataTextField = "description";
    //    ddlBankLIst.DataValueField = "Bank_code";
    //    ddlBankLIst.DataBind();
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        string script = "alert('Bank List Empty');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //        return;
    //    }
    //}

    public void CheckRecordExisting()
    {
        string sql = string.Empty;
        string employeecode = string.Empty;
        if (txtEmployeeCode.Text == "")
        {
            return;
        }
        else
        {
            employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
        }
        // QUERY TO CHECK EXISTING RECORD AGAINST EMPLOYEECODE ,LOAN TYPE AND FILLING THE CORROSPONDING CONTROL       
        //if (ddlLoanType.SelectedItem.Value == "COM-130")
        //{
        //    sql = "SELECT DISTINCT EmployeeCode,LoanType,LoanSanctionDate,InstalmentAmount,LoanCompletionDate,Amount_Due,InstalmentLeft,LoanSanctionNo,SanctionAmount,BankName,Remarks FROM  jct_payroll_loans_advance_deatil WHERE  EmployeeCode ='" + employeecode + "' AND LoanType = '" + ddlLoanType.Text + "'   and Bank_Code = '" + ddlBankLIst.SelectedItem.Value + "'   AND STATUS = 'A'";
        //}
        //else
        //{
        sql = "SELECT DISTINCT EmployeeCode,LoanType,LoanSanctionDate,InstalmentAmount,LoanCompletionDate,Amount_Due,InstalmentLeft,LoanSanctionNo,SanctionAmount,Remarks FROM  jct_payroll_loans_advance_deatil WHERE  EmployeeCode ='" + employeecode + "' AND LoanType = '" + ddlLoanType.Text + "'    AND STATUS = 'A'";
        //}
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlLoanType.ClearSelection();
                ddlLoanType.SelectedIndex = ddlLoanType.Items.IndexOf(ddlLoanType.Items.FindByValue(dr["LoanType"].ToString()));
                txtloandt.Text = dr["LoanSanctionDate"].ToString();
                txtinstalmnt.Text = dr["InstalmentAmount"].ToString();
                //txtno_of_inst.Text = dr["InstalmentLeft"].ToString();
                txtno_of_inst.Text = "0".ToString();
                txtCompletedate.Text = dr["LoanCompletionDate"].ToString();
                txtSanctionNo.Text = dr["LoanSanctionNo"].ToString();
                txtSanctionAmount.Text = dr["SanctionAmount"].ToString();
                txtAmountDue.Text = dr["Amount_Due"].ToString();
                txtRemarks.Text = dr["Remarks"].ToString();
                //if (ddlLoanType.SelectedItem.Value == "COM-130")
                //{
                //    lblBank.Visible = true;
                //    ddlBankLIst.SelectedIndex = ddlBankLIst.Items.IndexOf(ddlBankLIst.Items.FindByText(dr["BankName"].ToString()));
                //}
                //ddlCalcuationMethod.SelectedIndex = ddlCalcuationMethod.Items.IndexOf(ddlCalcuationMethod.Items.FindByText(dr["Calcuation_Method"].ToString()));
            }
        }
        else
        {
            cleartextbox();
            txtloandt.Text = System.DateTime.Now.ToShortDateString();
            //string script = "alert('Currently No Loans or advances are due for this employee.Add new Record! ');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        dr.Close();
    }

    protected void ddlLoanType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbdept.Text = "";
        lbdesign.Text = "";
        txtEmployeeCode.Text = "";
        cleartextbox();
        //if (ddlLoanType.SelectedItem.Value != null || ddlLoanType.SelectedItem.Value != "")
        //{
        //    CheckValue = ddlLoanType.SelectedItem.Value;
        //    if (CheckValue == "COM-130")
        //    {
        //        lblBank.Visible = true;
        //        ddlBankLIst.Visible = true;
        //        BankListSelected();
        //    }
        //    else
        //    {
        //        lblBank.Visible = false;
        //        ddlBankLIst.Visible = false;

        //    }
        //}
        ////ddlCalcuationMethod.Items.Clear();
        ////ddlCalcuationMethodBind();
        //if (checkEmptyRecords() == true)
        //{
        //    CheckRecordExisting();
        //}
    }

    public bool checkEmptyRecords()
    {
        string sql = "SELECT distinct CalcuationMethod FROM    JCT_payroll_LoanRate_master WHERE   STATUS = 'A' AND Loancode = '" + ddlLoanType.SelectedItem.Value + "'";

        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                return true;
            }
        } dr.Close();
        return false;

    }

    public void cleartextbox()
    {
        txtloandt.Text = "";
        txtinstalmnt.Text = "";
        txtno_of_inst.Text = "";
        txtCompletedate.Text = "";
        txtRemarks.Text = "";
        txtAmountDue.Text = "";
        txtSanctionNo.Text = "";
        txtSanctionAmount.Text = "";
    }

    protected void txtno_of_inst_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //decimal value = (Convert.ToDecimal(txtAmountDue.Text)) - (Convert.ToDecimal(txtRemarks.Text));            
            //DateTime completiondate = Convert.ToDateTime(txtloandt.Text);
            //int subtractMonth = Convert.ToInt32(txtno_of_inst.Text);
            //txtCompletedate.Text = Convert.ToDateTime(completiondate.AddMonths(Convert.ToInt16(subtractMonth - 1)).ToString()).ToString();
        }
        catch (Exception exception)
        {
            txtinstalmnt.Text = "";
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
            SqlCommand cmd = new SqlCommand("jct_payroll_loans_advance_deatil_Update", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@LoanType", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            //if (ddlBankLIst.Visible == true)
            //{
            //    cmd.Parameters.Add("@BankName", SqlDbType.VarChar, 30).Value = ddlBankLIst.SelectedItem.Text;
            //}
            //if (ddlBankLIst.Visible == true)
            //{
            //    cmd.Parameters.Add("@Bank_Code", SqlDbType.VarChar, 30).Value = ddlBankLIst.SelectedItem.Value;
            //}
            //cmd.Parameters.Add("@Calcuation_Method", SqlDbType.VarChar, 30).Value = ddlCalcuationMethod.SelectedItem.Text;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 20).Value = employeecode;
            cmd.Parameters.Add("@LoanSanctionDate", SqlDbType.DateTime).Value = txtloandt.Text;
            cmd.Parameters.Add("@LoanSanctionNo", SqlDbType.Int).Value = txtSanctionNo.Text;
            cmd.Parameters.Add("@SanctionLoanAmount", SqlDbType.Decimal, 18).Value = txtSanctionAmount.Text;
            cmd.Parameters.Add("@Amount_Due", SqlDbType.Decimal, 18).Value = txtAmountDue.Text;
            cmd.Parameters.Add("@InstalmentAmount", SqlDbType.Decimal, 18).Value = txtinstalmnt.Text;
            cmd.Parameters.Add("@Tot_no_of_inst_Left", SqlDbType.Int).Value = txtno_of_inst.Text;
            if (txtCompletedate.Text != string.Empty)
            {
                cmd.Parameters.Add("@LoanCompletionDate", SqlDbType.DateTime).Value = txtCompletedate.Text;
            }
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 60).Value = txtRemarks.Text;
            cmd.ExecuteNonQuery();
            string script = "alert('Loan Closed Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextbox();
            lbdept.Text = "";
            lbdesign.Text = "";
            txtEmployeeCode.Text = "";
            grdDetail.DataSource = null;
            grdDetail.DataBind();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    //public void PlantLocFetch()
    //{
    //    try
    //    {
    //        string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
    //        string sql = "jct_payroll_loans_Plant_Fetch";
    //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar, 30).Value = employeecode;
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        if (dr.HasRows)
    //        {
    //            while (dr.Read())
    //            {
    //                ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByText(dr["Plant_Name"].ToString()));
    //                ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByText(dr["Location_description"].ToString()));
    //            }
    //        }
    //        dr.Close();

    //    }
    //    catch (Exception exception)
    //    {
    //        cleartextbox();
    //        txtEmployeeCode.Text = "";
    //        string script = "alert('" + exception.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }

    //}

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_loan_advances_Modify.aspx");
    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_loan_advances.aspx");
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmployeeCode.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        ddlLoanType.SelectedIndex = ddlLoanType.Items.IndexOf(ddlLoanType.Items.FindByValue(grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "")));
        lbdept.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        lbdesign.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
        txtloandt.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
        txtSanctionNo.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        txtSanctionAmount.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
        txtinstalmnt.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
        txtAmountDue.Text = grdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
        txtno_of_inst.Text = grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
        txtCompletedate.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
        txtRemarks.Text = grdDetail.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
    }
}