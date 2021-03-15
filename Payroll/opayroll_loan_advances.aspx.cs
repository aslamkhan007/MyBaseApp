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

    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
            SqlCommand cmd = new SqlCommand("jct_payroll_loans_advance_deatil_insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@loan_type", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedValue;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 20).Value = employeecode;
            cmd.Parameters.Add("@LoanSanctionDate", SqlDbType.DateTime).Value = txtloandt.Text;
            cmd.Parameters.Add("@LoanAmount", SqlDbType.Decimal,18).Value = txttotamt.Text;
            cmd.Parameters.Add("@InstalmentAmount", SqlDbType.Decimal, 18).Value = txtinstalmnt.Text;
            cmd.Parameters.Add("@Tot_no_of_inst", SqlDbType.Decimal, 18).Value = txtno_of_inst.Text;

            // passing null parameters in case of empty records in the following 6 cases  
            if (txtno_of_ins_paid.Text != string.Empty)
            {
                cmd.Parameters.Add("@No_of_insta_Paid", SqlDbType.Decimal, 18).Value = txtno_of_ins_paid.Text;
            }

            if (txtins_left.Text != string.Empty)
            {
                cmd.Parameters.Add("@No_of_insta_left", SqlDbType.Decimal, 18).Value = txtins_left.Text;
            }

            if (txtins_amt_paid.Text != string.Empty)
            {
                cmd.Parameters.Add("@Inst_Amt_Paid", SqlDbType.Decimal, 18).Value = txtins_amt_paid.Text;
            }

            if (txtamtdue.Text != string.Empty)
            {
                cmd.Parameters.Add("@Amount_Due", SqlDbType.Decimal, 18).Value = txtamtdue.Text;
            }

            if (txtInterest.Text != string.Empty)
            {
                cmd.Parameters.Add("@Interest", SqlDbType.Decimal, 18).Value = txtInterest.Text;
            }

            if (txtCompletedate.Text != string.Empty)
            {
                cmd.Parameters.Add("@LoanCompletionDate", SqlDbType.DateTime).Value = txtCompletedate.Text;
            }                                   
     
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Saved Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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
            // TO FILL TEXTBOXE WITH EMPLOYEECODE AND EMPLOYEENAME WITH AUTOCOMPLETE SERVICE AND FILL THE LABLES(lbldesign,lbldepartment)
            string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
            string sql = "SELECT b.Desg_Long_Description,c.Department_Long_Description FROM dbo.JCT_payroll_employees_master a JOIN dbo.JCT_payroll_designation_master b ON a.Designation=b.Designation_code JOIN  dbo.JCT_payroll_department_master c ON a.Department=c.Department_code  WHERE a.Active='Y' and a.Employee_Code='" + employeecode + "'";
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
    
        // QUERY TO CHECK EXISTING RECORD AGAINST EMPLOYEECODE ,LOAN TYPE AND FILLING THE CORROSPONDING CONTROL
        sql = "SELECT DISTINCT a.empcode,b.Deduction_Short_description,a.LoanSanctionDate,a.LoanAmount,a.InstalmentAmount,a.Tot_no_of_inst,a.LoanCompletionDate  FROM  jct_payroll_loans_advance_deatil as a INNER JOIN  JCT_payroll_deduction_master as b  ON a.loan_type = b.Deduction_Code WHERE  empcode='" + employeecode + "' AND a.loan_type = '"+ddlLoanType.SelectedValue+"'  AND a.STATUS = 'A' AND b.status = 'A'";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlLoanType.SelectedIndex = ddlLoanType.Items.IndexOf(ddlLoanType.Items.FindByText(dr["Deduction_Short_description"].ToString()));
                txtloandt.Text = dr["LoanSanctionDate"].ToString();
                txttotamt.Text = dr["LoanAmount"].ToString();
                txtinstalmnt.Text = dr["InstalmentAmount"].ToString();
                txtno_of_inst.Text = dr["Tot_no_of_inst"].ToString();
                txtCompletedate.Text = dr["LoanCompletionDate"].ToString();
                lnkupd.Enabled = true;
                lnksave.Enabled = false;
            }
        }
        else
        {
            //cleartextbox();
        }
        dr.Close();

        }
      catch (Exception exception)
        {
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);        
        }
    }


    protected void lnkupd_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployeeCode.Text.Split('|')[1].ToString();
            SqlCommand cmd = new SqlCommand("jct_payroll_loans_advance_deatil_Update", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@loan_type", SqlDbType.VarChar, 30).Value = ddlLoanType.SelectedValue;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 20).Value = employeecode;
            cmd.Parameters.Add("@LoanSanctionDate", SqlDbType.DateTime).Value = txtloandt.Text;
            cmd.Parameters.Add("@LoanAmount", SqlDbType.Decimal, 18).Value = txttotamt.Text;
            cmd.Parameters.Add("@InstalmentAmount", SqlDbType.Decimal, 18).Value = txtinstalmnt.Text;
            cmd.Parameters.Add("@Tot_no_of_inst", SqlDbType.Decimal, 18).Value = txtno_of_inst.Text;

            // passing null parameters in case of empty records in the following 6 cases  
            if (txtno_of_ins_paid.Text != string.Empty)
            {
                cmd.Parameters.Add("@No_of_insta_Paid", SqlDbType.Decimal, 18).Value = txtno_of_ins_paid.Text;
            }

            if (txtins_left.Text != string.Empty)
            {
                cmd.Parameters.Add("@No_of_insta_left", SqlDbType.Decimal, 18).Value = txtins_left.Text;
            }

            if (txtins_amt_paid.Text != string.Empty)
            {
                cmd.Parameters.Add("@Inst_Amt_Paid", SqlDbType.Decimal, 18).Value = txtins_amt_paid.Text;
            }

            if (txtamtdue.Text != string.Empty)
            {
                cmd.Parameters.Add("@Amount_Due", SqlDbType.Decimal, 18).Value = txtamtdue.Text;
            }

            if (txtInterest.Text != string.Empty)
            {
                cmd.Parameters.Add("@Interest", SqlDbType.Decimal, 18).Value = txtInterest.Text;
            }

            if (txtCompletedate.Text != string.Empty)
            {
                cmd.Parameters.Add("@LoanCompletionDate", SqlDbType.DateTime).Value = txtCompletedate.Text;
            }

            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Updated Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void ddlLoanType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmployeeCode.Text = "";
        cleartextbox();
     
    }
    protected void txtinstalmnt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal  instalno =  Math.Round(Convert.ToDecimal(Convert.ToDecimal(txttotamt.Text) / Convert.ToDecimal(txtinstalmnt.Text)),2);
            txtno_of_inst.Text = instalno.ToString();
        }
        catch (Exception exception)
        {
            txtinstalmnt.Text = "";
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void txttotamt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtinstalmnt.Text = "";
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void cleartextbox()
    {
        lbdept.Text = "";
        lbdesign.Text = "";
        txtloandt.Text = "";
        txttotamt.Text = "";
        txtinstalmnt.Text = "";
        txtno_of_inst.Text = "";
        txtCompletedate.Text = "";
        txtno_of_ins_paid.Text = "";
        txtins_left.Text = "";
        txtins_amt_paid.Text = "";
        txtno_of_ins_paid.Text = "";
        txtamtdue.Text = "";
        txtInterest.Text = "";   
    }

}