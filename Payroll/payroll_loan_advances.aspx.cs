using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PayRoll_payroll_loan_advances : System.Web.UI.Page
{
    Connection obj = new Connection();
    string loantype;
    string deductioncode;
    string CheckValue = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoanTypeList();
            if (ddlLoanType.SelectedItem.Value != null || ddlLoanType.SelectedItem.Value != "")
            {
            }
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

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
            SqlCommand cmd = new SqlCommand("jct_payroll_loans_advance_deatil_insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoanType", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 20).Value = employeecode;
            cmd.Parameters.Add("@LoanSanctionDate", SqlDbType.DateTime).Value = txtloandt.Text;
            cmd.Parameters.Add("@LoanSanctionNo", SqlDbType.Int).Value = txtSanctionNo.Text;
            cmd.Parameters.Add("@SanctionLoanAmount", SqlDbType.Decimal, 18).Value = txtSanctionAmount.Text;
            cmd.Parameters.Add("@InstalmentAmount", SqlDbType.Decimal, 18).Value = txtinstalmnt.Text;
            //cmd.Parameters.Add("@Tot_no_of_inst", SqlDbType.Int).Value = txtno_of_inst.Text;

            //if (txtCompletedate.Text != string.Empty)
            //{
            //    cmd.Parameters.Add("@LoanCompletionDate", SqlDbType.DateTime).Value = txtCompletedate.Text;
            //}

            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Saved Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextbox();
            lbdept.Text = "";
            lbdesign.Text = "";
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
        Response.Redirect("payroll_loan_advances.aspx");
    }

    protected void txtEmployeeCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            cleartextbox();
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

            if (ddlLoanType.SelectedItem.Value != null || ddlLoanType.SelectedItem.Value != "")
            {
                CheckValue = ddlLoanType.SelectedItem.Value;

            }
            CheckParameter();
            CheckRecordExisting();
        }
        catch (Exception exception)
        {
            lbdept.Text = "";
            lbdesign.Text = "";
            txtEmployeeCode.Text = "";
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
        SqlPass = "jct_payroll_loans_advance_deatil_FetchMultipleRecrods";
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
        sql = "SELECT DISTINCT EmployeeCode,LoanType,LoanSanctionDate,InstalmentAmount,TotalInstalment,LoanCompletionDate,Amount_Due,InstalmentLeft,LoanSanctionNo,SanctionAmount FROM  jct_payroll_loans_advance_deatil WHERE  EmployeeCode ='" + employeecode + "' AND LoanType = '" + ddlLoanType.Text + "'  AND STATUS = 'A'";


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
                txtno_of_inst.Text = dr["TotalInstalment"].ToString();
                txtCompletedate.Text = dr["LoanCompletionDate"].ToString();
                txtSanctionNo.Text = dr["LoanSanctionNo"].ToString();
                txtSanctionAmount.Text = dr["SanctionAmount"].ToString();
            }
        }
        else
        {
            cleartextbox();
            txtloandt.Text = System.DateTime.Now.ToShortDateString();
        }
        dr.Close();

    }

    public void cleartextbox()
    {
        txtloandt.Text = "";
        txtinstalmnt.Text = "";
        txtno_of_inst.Text = "";
        txtCompletedate.Text = "";
        txtSanctionNo.Text = "";
        txtSanctionAmount.Text = "";
    }

    protected void lnkModify_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_loan_advances_Modify.aspx");
    }

    protected void ddlLoanType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbdept.Text = "";
        lbdesign.Text = "";
        txtEmployeeCode.Text = "";
        cleartextbox();
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
            SqlCommand cmd = new SqlCommand("jct_payroll_loans_advance_deatil_Change", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoanType", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 20).Value = employeecode;
            cmd.Parameters.Add("@LoanSanctionDate", SqlDbType.DateTime).Value = txtloandt.Text;
            cmd.Parameters.Add("@LoanSanctionNo", SqlDbType.Int).Value = txtSanctionNo.Text;
            cmd.Parameters.Add("@SanctionLoanAmount", SqlDbType.Decimal, 18).Value = txtSanctionAmount.Text;
            cmd.Parameters.Add("@InstalmentAmount", SqlDbType.Decimal, 18).Value = txtinstalmnt.Text;
            //cmd.Parameters.Add("@Tot_no_of_inst", SqlDbType.Int).Value = txtno_of_inst.Text;
            //if (txtCompletedate.Text != string.Empty)
            //{
            //    cmd.Parameters.Add("@LoanCompletionDate", SqlDbType.DateTime).Value = txtCompletedate.Text;
            //}
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Updated Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextbox();
            lbdept.Text = "";
            lbdesign.Text = "";
            txtEmployeeCode.Text = "";
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void txtinstalmnt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //Int32 value = (Convert.ToInt32(txtSanctionAmount.Text));
            //int instalamts = Convert.ToInt32(txtinstalmnt.Text);

            //if ((value % instalamts) > 0)
            //{
            //    string script = "alert('Invalid Installment Number.');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //    txtno_of_inst.Text = "";
            //    txtCompletedate.Text = "";
            //    return;
            //}
            //else
            //{
            //    int instalno = (value) / instalamts;
            //    txtno_of_inst.Text = Convert.ToString(instalno);
            //    DateTime completiondate = Convert.ToDateTime(txtloandt.Text);
            //    int subtractMonth = Convert.ToInt32(txtno_of_inst.Text);
            //    txtCompletedate.Text = Convert.ToDateTime(completiondate.AddMonths(Convert.ToInt16(subtractMonth - 1)).ToString()).ToString();
            //}
        }
        catch (Exception exception)
        {
            txtinstalmnt.Text = "";
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void txtSanctionAmount_TextChanged(object sender, EventArgs e)
    {

    }
}