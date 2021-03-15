using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;

public partial class Payroll_Jct_Payroll_Salary_Wage_Correction : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string cardno;
    string empcode;
    string FlagCheck = string.Empty;

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

            Panel1.Visible = true;
            lnkapply.Enabled = true;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_Salary_Wage_Correction_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Yearmonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
        if (dt.Rows.Count == 0)
        {
            string script = "alert('No Record Found.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            string OK = string.Empty;

            foreach (GridViewRow gvRow1 in grdDetail.Rows)
            {
                CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chk");
                if (chkRemove1.Checked == true)
                {
                    OK = "OK";
                }
            }

            if (OK == "OK")
            {
                foreach (GridViewRow gvRow in grdDetail.Rows)
                {
                    CheckBox chkRemove2 = (CheckBox)gvRow.FindControl("chk");
                    if (chkRemove2.Checked == true)
                    {

                        String Yearmonth = gvRow.Cells[2].Text;
                        String EmployeeCode = gvRow.Cells[3].Text;
                        String ComponentName = gvRow.Cells[4].Text;
                        String ComponentValue = gvRow.Cells[5].Text;
                        TextBox txtAPRPF = (TextBox)gvRow.FindControl("txtAPRPF");

                        sql = "Jct_Payroll_Salary_Wage_Correction_Update";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Yearmonth", SqlDbType.Int).Value = Convert.ToInt32(Yearmonth);
                        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                        cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 30).Value = ComponentName;
                        cmd.Parameters.Add("@ComponentValue", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(ComponentValue);
                        cmd.Parameters.Add("@RevisedValue", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAPRPF.Text);
                        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                        cmd.ExecuteNonQuery();
                        string script = "alert('Record  Updated.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }

                }
            }
            else
            {
                string script1 = "alert('Please Select The Record First.!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Input string was not in a correct format.")
            {
                string script1 = "alert('Error,Some Field Left Blank.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
            }
            else
            {
                string script = "alert(''" + ex.Message + "'');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Salary_Wage_Correction.aspx");
    }
    protected void LnkAuth_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_Salary_Wage_Correction_Update_Freeze", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.Add("@Yearmonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
        cmd.ExecuteNonQuery();
        string script = "alert('Record Freezed Sucesfully.!! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
}