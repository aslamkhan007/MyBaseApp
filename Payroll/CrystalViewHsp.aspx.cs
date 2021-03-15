using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Sql;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.Reporting.WebControls;


public partial class Payroll_CrystalViewHsp : System.Web.UI.Page
{
    ReportDocument rpt = new ReportDocument();


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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rpt.Dispose();
            rpt.Close();
            AttendenceDate1();
            Plantbind();
            Locationbind();
            turncateTable();
            Departmentbind();
            // CrystalReportViewer1.AllowedExportFormats = (int)CrystalDecisions.Shared.ViewerExportFormats.WordFormat;
            CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
            //ConfigureCrystalReports();
            //CrystalReportViewer1.ReportSource = rpt;
            // CrystalReportViewer1.HasExportButton = false;

        }
        FetchRecord();
    }


    public void Departmentbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT 'All'  as DepartmentCode,'All' as  DepartmentLongDescription union SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by DepartmentLongDescription", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.Items.Clear();
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "DepartmentLongDescription";
        ddldepartment.DataValueField = "DepartmentCode";
        ddldepartment.DataBind();
        con.Close();
    }

    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    //AttendenceDate1();
    //    //Plantbind();
    //    //Locationbind(); 
    //    //AttendenceDate1();
    //    //Plantbind();
    //    //Locationbind();  

    //    //string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
    //    //SqlConnection con = new SqlConnection(qry);
    //    //con.Open();
    //    //con.Close();

    //    if (!IsPostBack)
    //    {
    //        AttendenceDate1();
    //        Plantbind();
    //        Locationbind();

    //    }
    //    //FetchConnection();
    //    FetchRecord();  
    //}



    //private void ConfigureCrystalReports()
    //{
    //    rpt = new ReportDocument();
    //    rpt.Load(Server.MapPath("Payroll_Salary_Sheet.rpt"));
    //    rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctgen");
    //    CrystalReportViewer1.ReportSource = rpt;
    //    //string reportPath = Server.MapPath("reportname.rpt");
    //    //rpt.Load(reportPath);
    //    //ConnectionInfo connectionInfo = new ConnectionInfo();
    //    //connectionInfo.DatabaseName = "Northwind";
    //    //connectionInfo.UserID = "sa";
    //    //connectionInfo.Password = "pwd";
    //    //SetDBLogonForReport(connectionInfo, rpt);
    //    //CrystalReportViewer1.ReportSource = rpt;
    //}


    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("CrystalViewHsp.aspx");
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        FetchRecord();

    }


    public void FetchRecord()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        //SqlPass = "Jct_Payroll_Salary_Sheet_Cal";
        SqlPass = "Jct_Payroll_Monthly_Salary_Process_Print_Hsp";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        //Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = "PLN-101";
        //Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = "LOC-111";
        //Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = 201801;
        //if (ddlplant.SelectedItem.Value == null)
        //{

        //}
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;

        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;

        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);

        Cmd.Parameters.Add("@Department", SqlDbType.VarChar, 30).Value = ddldepartment.SelectedItem.Text;
        Cmd.Parameters.Add("@PaymentMode", SqlDbType.VarChar, 30).Value = ddlPaymode.SelectedItem.Text;

        //ReportDocument report = new ReportDocument();
        //BAgent bAgent = new BAgent();
        //DataSet dsStatus = new DataSet();
        //dsStatus = bAgent.GetStatus();

        //string reportPath = Server.MapPath("/Agent/Reports/GetStatusRpt.rpt");
        //report.Load(reportPath);
        //report.SetDataSource(dsStatus.Tables[0]);
        //CrystalReportViewer1.ReportSource = report;
        //CrystalReportViewer1.DataBind();
        //CrystalReportViewer1.RefreshReport();  

        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        rpt.Load(Server.MapPath("Payroll_Salary_Sheet_HSP.rpt"));
        rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctgen");
        rpt.SetDataSource(ds.Tables[0]);
        rpt.SetDataSource(ds);
        CrystalReportViewer1.ReportSource = rpt;
        ds.Clear();
        con.Close();
    }


    public void turncateTable()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlPass = "Jct_Payroll_Monthly_Salary_Process_Print_Truncate";
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

    public void AttendenceDate1()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string sqlqry = "Jct_Payroll_SalaryCal_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, con);
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
        con.Close();
    }

    //public void AttendenceDate()
    //{
    //    string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
    //    SqlConnection con = new SqlConnection(qry);
    //    con.Open();
    //    string sqlqry = "Jct_Payroll_Attendence_Month";
    //    SqlCommand cmd = new SqlCommand(sqlqry, con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    if (dr.HasRows == true)
    //    {
    //        while (dr.Read())
    //        {
    //            txtfromdate.Text = dr["FromDate"].ToString();
    //            txttodate.Text = dr["ToDate"].ToString();
    //        }
    //        dr.Close();
    //    }
    //    con.Close();
    //}

    //protected void txtfromdate_TextChanged(object sender, EventArgs e)
    //{
    //    DateTime origDT = Convert.ToDateTime(txtfromdate.Text);
    //    DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
    //    txttodate_CalendarExtender.SelectedDate = lastDate;
    //}


    public void Plantbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
        con.Close();
    }

    public void Locationbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT '' Location_description,'' Location_code union SELECT  Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
        con.Close();
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocation.SelectedItem.Value == "PLN-100")
        {
            Response.Redirect("CrystalView.aspx");
        }
        else
        {
 
        }        
        Locationbind();
        //FetchRecord();
    }

    /*     

contempt
scorn; disdain; ADJ. contemptuous; CF. contemptible
contend
struggle; compete; assert earnestly; state strongly
contention
assertion; claim; thesis; struggling; competition
contentious
quarrelsome; controversial; likely to cause arguments
contest
dispute; argue about the rightness of; compete for; try to win; Ex. contest the election results; Ex. contest a seat in Parliament; N.
context
writings preceding and following the passage quoted; circumstance in which an event occurs
contiguous
adjacent to; touching upon
    
        */

    protected void ExportPDF(object sender, EventArgs e)
    {
        //ReportDocument crystalReport = new ReportDocument();
        //BindReport(crystalReport);
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlPass = "Jct_Payroll_Salary_Sheet_Cal";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@MONTHYEAR", SqlDbType.DateTime).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        rpt.Load(Server.MapPath("Payroll_Salary_Sheet.rpt"));
        rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctdev");
        rpt.SetDataSource(ds.Tables[0]);
        rpt.SetDataSource(ds);
        CrystalReportViewer1.ReportSource = rpt;
        ds.Clear();
        con.Close();

        //rpt.PrintOptions.PaperSize = PaperSize.
        //ExportFormatType formatType = ExportFormatType.NoFormat;
        //switch (rbFormat.SelectedItem.Value)
        //{
        //    case "Word":
        //        formatType = ExportFormatType.WordForWindows;
        //        break;
        //    case "PDF":
        //        formatType = ExportFormatType.PortableDocFormat;
        //        break;
        //    case "Excel":
        //        formatType = ExportFormatType.Excel;
        //        break;

        //    case "Text":
        //        formatType = ExportFormatType.Text;
        //        break;
        //}
        //rpt.ExportToHttpResponse(formatType, Response, true, "Crystal");       
        //Response.End();
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocation.SelectedItem.Text == "Nylon Plant")
        {
            Response.Redirect("CrystalViewHsp.aspx");
        }
    }
}