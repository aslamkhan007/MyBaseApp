using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Payroll_payroll_emp_Deduction_Mapping : System.Web.UI.Page
{ 
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindchecklist();
        }
    }
    public void bindchecklist()        // function to bind Checklist on Load Event..
    {
        SqlCommand cmd = new SqlCommand("SELECT Deduction_Code,Deduction_Long_Description FROM JCT_payroll_deduction_master WHERE STATUS = 'A' AND Deduction_Type = 'Fixed' order by Deduction_Long_Description", obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        chklist.DataSource = ds.Tables[0];
        chklist.DataBind();
        Panel1.Visible = true;    
    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (lnkadd.Text == "Update")  // code will run to update existing deductions records against any employeecode..
            {
                string employeecode = txtEmployeeName.Text.Split('|')[1].ToString();
                string Employeename = txtEmployeeName.Text.Split('|')[0].ToString();
                SqlCommand cmd = new SqlCommand("JCT_payroll_emp_Deduction_Map_master_Update", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Employee_code", SqlDbType.VarChar, 10).Value = employeecode;
                cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                cmd.ExecuteNonQuery();                               
                for (int i = 0; i <= chklist.Items.Count - 1; i++)
                {
                    if (chklist.Items[i].Selected == true)
                    {
                        cmd = new SqlCommand("JCT_payroll_emp_Deduction_Map_master_Insert", obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar, 10).Value = employeecode;
                        cmd.Parameters.Add("@Employee_Name", SqlDbType.VarChar, 50).Value = Employeename;
                        cmd.Parameters.Add("@Deduction_code", SqlDbType.VarChar, 10).Value = chklist.Items[i].Value;
                        cmd.Parameters.Add("@Deduction_Long_Description", SqlDbType.VarChar, 100).Value = chklist.Items[i].Text;
                        cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                        cmd.ExecuteNonQuery();
                    }
                }
                string script = "alert('Record Updated Successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else  // code will work on saving the record for the first time..
            {
                string employeecode = txtEmployeeName.Text.Split('|')[1].ToString();
                string Employeename = txtEmployeeName.Text.Split('|')[0].ToString();
                for (int i = 0; i <= chklist.Items.Count - 1; i++)                 // Loop Saving Checklist Selected Records On Save Event..
                {
                    if (chklist.Items[i].Selected == true)
                    {
                        SqlCommand cmd = new SqlCommand("JCT_payroll_emp_Deduction_Map_master_Insert", obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar, 10).Value = employeecode;
                        cmd.Parameters.Add("@Employee_Name", SqlDbType.VarChar, 50).Value = Employeename;
                        cmd.Parameters.Add("@Deduction_code", SqlDbType.VarChar, 10).Value = chklist.Items[i].Value;
                        cmd.Parameters.Add("@Deduction_Long_Description", SqlDbType.VarChar, 100).Value = chklist.Items[i].Text;
                        cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                        cmd.ExecuteNonQuery();
                    }
                }
                lnkadd.Text = "Update";
                string script = "alert('Record Saved Successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }   
    }    
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_emp_Deduction_Mapping.aspx");
    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        serachEmployeeWise();
    }

    public void serachEmployeeWise()
    {
        try
        {
            string employeecode = txtEmployeeName.Text.Split('|')[1].ToString();          // To Split Txtemployee text into two parts..
            string Employeename = txtEmployeeName.Text.Split('|')[0].ToString();

            for (int i = 0; i <= chklist.Items.Count - 1; i++)    // loop to check already selected deductions record and make checkbox list checked on fetch event ..
            {
                string deductionlist;
                deductionlist = chklist.Items[i].ToString();
                string sqlqry = "JCT_payroll_emp_Deduction_Map_master_Fetch";
                SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar, 10).Value = employeecode;
                cmd.Parameters.Add("@Employee_Name", SqlDbType.VarChar, 50).Value = Employeename;
                cmd.Parameters.Add("@Deduction_code", SqlDbType.VarChar, 10).Value = chklist.Items[i].Value;
                cmd.Parameters.Add("@Deduction_Long_Description", SqlDbType.VarChar, 100).Value = chklist.Items[i].Text;
                cmd.Parameters.Add("@FLAG", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string output = cmd.Parameters["@FLAG"].Value.ToString();

                if (output == "1")
                {
                    chklist.Items[i].Selected = true;
                    lnkadd.Text = "Update";
                }
                else
                {
                    chklist.Items[i].Selected = false;
                }
            }
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void txtEmployeeName_TextChanged(object sender, EventArgs e)
    {
        serachEmployeeWise();

    }
}