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


public partial class Payroll_Jct_Payroll_Tax_NewEmployee : System.Web.UI.Page
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
        string sqlqry = "Jct_Payroll_Current_FIYear";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodate.Text = dr["FIYear"].ToString();
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
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_NewEmployee_Creation_IncomTax", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@FYPeriod", SqlDbType.VarChar, 10).Value = txttodate.Text;
        cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        //cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
        string script10 = "alert('Employee Addition Successfull');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script10, true);
        if (dt.Rows.Count == 0)
        {
            string script = "alert('No Record Found.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
       

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Tax_NewEmployee.aspx");
    }

  
}