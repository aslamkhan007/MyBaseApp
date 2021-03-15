using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.Reporting.WebControls;
using CrystalDecisions.ReportAppServer.ClientDoc;
using CrystalDecisions.CrystalReports.Engine;

public partial class Payroll_Payroll_Salary_Bank_Advice_Crystal : System.Web.UI.Page
{
    ReportDocument rpt = new ReportDocument();
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Plantbind();
            Locationbind();
            // BankList();
            Departmentbind();
            Designationbind();
            ExgratiaDate();
            BankList();
            Visible();
			turncateTable();
        }
        bindgrid();
    }

    public void Visible()
    {
        Label1.Visible = false;
        TxtOvertimeDate.Visible = false;
        Label10.Visible = false;
        TxtOvertimeReason.Visible = false;
    }
	
	    public void turncateTable()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlPass = "Jct_Payroll_BankAdvise_Print_Truncate";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.ExecuteNonQuery();
        //SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        //DataSet ds = new DataSet();
        //Da.Fill(ds);
        //rpt.Load(Server.MapPath("Payroll_Salary_Sheet.rpt"));
        //rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctgen");
        //rpt.SetDataSource(ds.Tables[0]);
        //rpt.SetDataSource(ds);
        //CrystalReportViewer1.ReportSource = rpt;
        //ds.Clear();
        con.Close();
    }
	
    protected void Page_Unload(object sender, System.EventArgs e)
    {
        if (((rpt != null)))
        {
            if (rpt.IsLoaded == true)
            {
                rpt.Close();
                rpt.Dispose();
            }
        }
    }

    public void Designationbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Jct_Payroll_WorkerGroupCategory_Report", con);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlGroupCategory.DataSource = ds;
        ddlGroupCategory.DataTextField = "Category";
        ddlGroupCategory.DataValueField = "Category";
        ddlGroupCategory.DataBind();
        con.Close();
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Salary_Bank_Advice_Crystal.aspx");
    }

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
        //sql = "Jct_Payroll_Salary_BankAdvice_Fetch";
        sql = "Jct_Payroll_Salary_BankAdvice_Fetch_New";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txtMonth.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@ActionArea", SqlDbType.VarChar, 12).Value = ddlActionArea.SelectedItem.Value;
        cmd.Parameters.Add("@PayCategory", SqlDbType.VarChar, 20).Value = ddlCategory.SelectedItem.Value;
        cmd.Parameters.Add("@BankCode", SqlDbType.VarChar, 10).Value = ddlbank.SelectedItem.Value;
        cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50).Value = ddldepartment.SelectedItem.Text;
        cmd.Parameters.Add("@GroupCategory", SqlDbType.VarChar, 1).Value = ddlGroupCategory.SelectedItem.Text;
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = "";
        cmd.Parameters.Add("@AdviceDate", SqlDbType.VarChar, 10).Value ="";
        ////cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["Empcode"];        
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //if (ds.Tables.Count > 0)
        //{
        //    grdDetail.DataSource = ds.Tables[0];
        //    grdDetail.DataBind();
        //    Panel1.Visible = true;
        //    LnkExcel.Enabled = true;
        //}
        //else
        //{
        //    grdDetail.DataSource = null;
        //    grdDetail.DataBind();
        //    string script = "alert('No Record Found.!!');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //}

        SqlDataAdapter Da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        rpt.Load(Server.MapPath("BankAdvise.rpt"));
        rpt.SetDatabaseLogon("itdev", "power", "Test2k", "jctdev");
        rpt.SetDataSource(ds.Tables[0]);
        rpt.SetDataSource(ds);
        CrystalReportViewer1.ReportSource = rpt;

        ds.Clear();
    
    }


    public void Departmentbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT DeptSubdeptGrp,Srno FROM  Jct_Payroll_WageSummery_Grouping", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.Items.Clear();
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "DeptSubdeptGrp";
        ddldepartment.DataValueField = "Srno";
        ddldepartment.DataBind();
        con.Close();
    }


    private void BankList()
    {
        sql = "Jct_Payroll_Banklist_Fetch_Crystal";
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
        SqlCommand sqlCmd = new SqlCommand("SELECT '' Location_description,'' Location_code union SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
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
        //if (ddlCategory.SelectedItem.Value == "CarAllowance" || ddlCategory.SelectedItem.Value == "ScooterAllowance")
        //{
        //    lbldesignation.Visible = true;
        //    ddldesignation.Visible = true;
        //}
        //else
        //{
        //    lbldesignation.Visible = false;
        //    ddldesignation.Visible = false; 
        //}
    }
    protected void ddlActionArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlActionArea.SelectedItem.Value == "AdviceDetail")
        {
            Response.Redirect("Payroll_Salary_Bank_Advice_Crystal.aspx");
        }
        else 
        {
            Response.Redirect("Payroll_Salary_Bank_Advice.aspx");
        }
    }
}