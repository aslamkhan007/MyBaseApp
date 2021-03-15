using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Payroll_Payroll_Salary_Bank_Advice : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ddlCategory.SelectedItem.Value == "CarAllowance" || ddlCategory.SelectedItem.Value == "ScooterAllowance" || ddlCategory.SelectedItem.Value == "Salary")
            {
                lbldesignation.Visible = true;
                ddldesignation.Visible = true;
            }
            else
            {
                lbldesignation.Visible = false;
                ddldesignation.Visible = false;
            }

            dojtypehideshow();

            Plantbind();
            Locationbind();
            BankList();
            Departmentbind();
            Designationbind();
            ExgratiaDate();
        }
    }


    public void Designationbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        //SqlCommand sqlCmd = new SqlCommand("SELECT Designation_code,Desg_Long_Description FROM JCT_payroll_designation_master WHERE  STATUS='A' order by Desg_Long_Description", con);
        SqlCommand sqlCmd = new SqlCommand("SELECT 'All'  as Designation_code,'All' as Desg_Long_Description union SELECT Designation_code,Desg_Long_Description FROM JCT_payroll_designation_master WHERE  STATUS='A' order by Desg_Long_Description", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldesignation.Items.Clear();
        ddldesignation.DataSource = ds;
        ddldesignation.DataTextField = "Desg_Long_Description";
        ddldesignation.DataValueField = "Designation_code";
        ddldesignation.DataBind();
        con.Close();
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Salary_Bank_Advice.aspx");
    }
    //protected void lnkPrint_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Payroll_Salary_Bank_Advice.aspx?PlantCode=" + ddlplant.SelectedItem.Value + "&BankCode=" + ddlbank.SelectedItem.Value + "&LocationCode=" + ddlLocation.SelectedItem.Value + "&YearMonth=" + txtMonth.Text);
    //}
    protected void LnkExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    public void ExgratiaDate()
    {
        string sqlqry = "Jct_Payroll_SalaryCal_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txtMonth.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }
    private void bindgrid()
    {
        sql = "Jct_Payroll_Salary_BankAdvice_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PlantCode", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@YearMonth", SqlDbType.VarChar, 12).Value = txtMonth.Text;
        cmd.Parameters.Add("@BankCode", SqlDbType.VarChar, 10).Value = ddlbank.SelectedItem.Value;
        cmd.Parameters.Add("@LocationCode", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@Category", SqlDbType.VarChar, 20).Value = ddlCategory.SelectedItem.Value;
        cmd.Parameters.Add("@Department", SqlDbType.VarChar, 10).Value = ddldepartment.SelectedItem.Value;
        if (ddldesignation.Visible == true)
        {
            cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 10).Value = ddldesignation.SelectedItem.Value;
        }
        else
        {
            cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 10).Value = "All";
        }
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["Empcode"];

        if (ddldojtype.Visible == true)
        {
            cmd.Parameters.Add("@Dojtype", SqlDbType.VarChar, 100).Value = ddldojtype.SelectedItem.Text;
        }

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables.Count > 0)
        {
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            LnkExcel.Enabled = true;
        }
        else
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            string script = "alert('No Record Found.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
                       
    }

    public void Departmentbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("select 'All' as DepartmentCode , 'All' as DepartmentLongDescription union  SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by DepartmentLongDescription", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "DepartmentLongDescription";
        ddldepartment.DataValueField = "DepartmentCode";
        ddldepartment.DataBind();
        con.Close();
    }


    private void BankList()
    {
        sql = "Jct_Payroll_Banklist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@plant_code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@location_code", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbank.DataSource = ds;
        ddlbank.DataTextField = "Description";
        ddlbank.DataValueField = "BankCode";
        ddlbank.DataBind();
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

    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
        BankList();
    }
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        BankList();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedItem.Value == "CarAllowance" || ddlCategory.SelectedItem.Value == "ScooterAllowance" || ddlCategory.SelectedItem.Value == "Salary")
        {
            lbldesignation.Visible = true;
            ddldesignation.Visible = true;
        }
        else
        {
            lbldesignation.Visible = false;
            ddldesignation.Visible = false; 
        }

        dojtypehideshow();
  

    }

    public void dojtypehideshow()
    {
        if (ddlCategory.SelectedItem.Value == "ScooterAllowance" || ddlCategory.SelectedItem.Value == "Salary")
        {
            Label1.Visible = true;
            ddldojtype.Visible = true;
        }
        else
        {
            Label1.Visible = false;
            ddldojtype.Visible = false;
        }
    }
}