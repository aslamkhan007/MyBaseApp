using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_DepartmentWise_Overtime : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            ExgratiaDate();
            plantList();
            LocationList();
            Departmentbind();
        }
    }
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        LocationList();
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_DepartmentWise_Overtime.aspx");
    }
    protected void LocationList()
    {
        sql = "Jct_Payroll_Locationlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "LocationDescription";
        ddlLocation.DataValueField = "LocationCode";
        ddlLocation.DataBind();
    }
    public void plantList()
    {
        sql = "Jct_Payroll_Plantlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "LongDescription";
        ddlplant.DataValueField = "PlantCode";
        ddlplant.DataBind();
    }
    public void Departmentbind()
    {
        sql = "SELECT 'All' AS Department_code , 'All' AS Department_long_Description UNION SELECT Department_code,Department_long_Description FROM JCT_payroll_department_master WHERE  STATUS='A'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "Department_long_Description";
        ddldepartment.DataValueField = "Department_code";
        ddldepartment.DataBind(); 
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        //lnkexcel.Enabled = true;
        bindgrid();
    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    private void bindgrid()
    {
        sql = "Jct_Payroll_Departmentwise_overtime";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Department", SqlDbType.VarChar, 10).Value = ddldepartment.SelectedItem.Value;
        cmd.Parameters.Add("@PlantCode", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@LocationCode", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@YearMonth", SqlDbType.VarChar, 12).Value = txtMonth.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        
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
    protected void ddlReporttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReporttype.SelectedItem.Text == "Summary")
           Response.Redirect("Jct_Payroll_DepartmentWise_Overtime.aspx");
        else if (ddlReporttype.SelectedItem.Text == "Detail")
             Response.Redirect("Jct_Payroll_Monthly_Exgratia.aspx");
    }
}