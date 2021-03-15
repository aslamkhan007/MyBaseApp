using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Payroll_Jct_Payroll_DeptToCostHierEntry_Report : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Plantbind();
            Departmentbind();
        }
    }

    public void Departmentbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        //SqlCommand sqlCmd = new SqlCommand("SELECT 'All' as Department_code,'All' as Department_long_Description union   SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by Department_long_Description", con);
        SqlCommand sqlCmd = new SqlCommand("select 'All' as Department_code, 'All' as Department_long_Description union   SELECT Department_code ,Department_long_Description FROM JCT_payroll_department_master WHERE  STATUS='A'  order by Department_long_Description", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.Items.Clear();
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "Department_long_Description";
        ddldepartment.DataValueField = "Department_code";
        ddldepartment.DataBind();
        con.Close();
    }

    public void Plantbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "Plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("Jct_Payroll_HR_DeptCost_Report_Serial_FetchReport", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;

            cmd.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 40).Value = ddldepartment.SelectedItem.Text;

            cmd.Parameters.Add("@ReportGroup", SqlDbType.VarChar, 10).Value = ddldedtype.SelectedItem.Value;

            if (txtdedamount.Text != "")
            {
                cmd.Parameters.Add("@ReportSerial", SqlDbType.Decimal).Value = txtdedamount.Text;
            }
            else
            {
                cmd.Parameters.Add("@ReportSerial", SqlDbType.Decimal).Value = 0;
            }

            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Da.Fill(dt);
            grdDetail.DataSource = dt;
            grdDetail.DataBind();           
            Panel1.Visible = true;           
            if (dt.Rows.Count == 0)
            {
                string script = "alert('No Record Found !!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);                
                Panel1.Visible = false;
            }            
            con.Close();
            
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void clearcontrols()
    {
        txtdedamount.Text = "";
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_DeptToCostHierEntry_Report.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }


    protected void lnkreset0_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_DeptToCostHierEntry.aspx");
    }
}