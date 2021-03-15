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
using CrystalDecisions.ReportAppServer.ClientDoc;

//using CrystalDecisions.ReportAppServer.Controllers.PrintOutputController;

public partial class CrystalviewHspWageSlip : System.Web.UI.Page
{
    //Dim poc As CrystalDecisions.ReportAppServer.Controllers.PrintOutputController

     //CrystalDecisions.ReportAppServer

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




   //public void abc()
   //{
   //    //rpt = new ReportDocument();
   //    PageMargins customPageMargin = rpt.PrintOptions.PageMargins;
   //    rpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
   //    //rpt.PrintOptions.PaperSize = PaperSize.cus
   //    //rpt.PrintToPrinter()
   //    //customPageMargin.
   //    customPageMargin.le
   //    customPageMargin.rightMargin = 0.13;
   //    customPageMargin.topMargin = 0.17;
   //    customPageMargin.bottomMargin = 0.17;
   //    rpt.PrintOptions.ApplyPageMargins(customPageMargin);

   //}



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
           //'CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
          //CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.
          

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


   protected void lnkreset_Click(object sender, System.EventArgs e)
   {
       Response.Redirect("CrystalviewHspWageSlip.aspx");
   }

   protected void lnkFetch_Click(object sender, System.EventArgs e)
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
       SqlPass = "Jct_Payroll_MonthlyWage_Salary_Print";
       Cmd = new SqlCommand(SqlPass, con);
       Cmd.CommandType = CommandType.StoredProcedure;
       //Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = "PLN-101";
       //Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = "LOC-111";
       //Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Va1lue = 201801;
       //if (ddlplant.SelectedItem.Value == null)
       //{
       //}
       Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
       Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
       Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
       Cmd.Parameters.Add("@Department", SqlDbType.VarChar, 30).Value = ddldepartment.SelectedItem.Text;

       //Cmd.Parameters.Add("@SumryType", SqlDbType.VarChar, 10).Value = ddlPaymode.SelectedItem.Text;
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

       //CrystalDecisions.CrystalReports,PageMargins
       SqlDataAdapter Da = new SqlDataAdapter(Cmd);
       DataSet ds = new DataSet();
       Da.Fill(ds);
       //rpt.PrintOptions.ApplyPageMargins[PageMargins]
       rpt.Load(Server.MapPath("HspWageSlip.rpt"));
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
       SqlPass = "Jct_Payroll_MonthlyWage_Salary_Print_Truncate";
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
       //if (ddlPaymode.SelectedItem.Value == "Earning")
       //{
       //    Response.Redirect("CrystalViewHSPWAGES.aspx");
       //    // ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByValue(dr["PLN-100"].ToString().Trim()));
       //    // Plantbind();
       //    ddlPaymode.SelectedItem.Value = "Earning";
       //}
       //else
       //{

       //}
       Locationbind();
       //FetchRecord();
   }   
}
    