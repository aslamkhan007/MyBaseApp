using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_JCT_Payroll_Employee_Search : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {                      
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

 
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_Payroll_Employee_Search";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;            
            //if (txtEmployee.Text != "")
            //{
            //    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            //}
            //else
            //{
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            //}
            
            cmd.ExecuteNonQuery();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            //if( a == 1)
            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_Employee_Search.aspx");
    }
}