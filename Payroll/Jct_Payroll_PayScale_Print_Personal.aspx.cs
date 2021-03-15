using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Services;

public partial class Payroll_Jct_Payroll_PayScale_Print_Personal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public class TableComon
    {
        public string Allowance { get; set; }
        public string Amount { get; set; }
        public string PerAnnum { get; set; }
    }

    public class OtherDetails
    {
        public string EmployeeName { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string ProbationPd { get; set; }
        public string Dateofjoining { get; set; }
        public string OfferAccepted { get; set; }
        public string YearOFPassing { get; set; }
        public string Plant { get; set; }
    }

    [System.Web.Services.WebMethod]
    //[ScriptMethod(UseHttpGet = true)]
    public static MyViewModel Fetch(string code, string name)
    {
        MyViewModel user = new MyViewModel();
        user.TableEarning = AllowanceDetail(code);
        user.TableContribution = ContributionDetail(code);
        user.OtherDetails = MyOtherDetails(name);
        return user;
    }

    public static List<TableComon> AllowanceDetail(string code)
    {
        DataTable dt = new DataTable();
        List<TableComon> AllowanceDetail = new List<TableComon>();
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Print_AllowancesFetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SeriesCode", SqlDbType.VarChar, 10).Value = code;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dtrow in dt.Rows)
        {
            TableComon abc = new TableComon();
            abc.Allowance = dtrow["Allowance"].ToString();
            abc.Amount = dtrow["Amount"].ToString();
            abc.PerAnnum = dtrow["PerAnnum"].ToString();
            AllowanceDetail.Add(abc);
        }
        con.Close();
        return AllowanceDetail;
    }

    public static List<TableComon> ContributionDetail(string code)
    {
        DataTable dt = new DataTable();
        List<TableComon> ContributionDetail = new List<TableComon>();
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Print_ContributionFetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SeriesCode", SqlDbType.VarChar, 10).Value = code;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dtrow in dt.Rows)
        {
            TableComon abc = new TableComon();
            abc.Allowance = dtrow["Allowance"].ToString();
            abc.Amount = dtrow["Amount"].ToString();
            abc.PerAnnum = dtrow["PerAnnum"].ToString();
            ContributionDetail.Add(abc);
        }
        con.Close();
        return ContributionDetail;
    }

    public static OtherDetails MyOtherDetails(string names)
    {
        DataTable dt = new DataTable();
        OtherDetails OtherDetailshas = new OtherDetails();
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Print_HeaderFetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50).Value = names;
        //cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 10).Value = "raj";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dtrow in dt.Rows)
        {
            OtherDetailshas.EmployeeName = dtrow["EmployeeName"].ToString();
            OtherDetailshas.Qualification = dtrow["Qualification"].ToString();
            OtherDetailshas.Experience = dtrow["Experience"].ToString();
            OtherDetailshas.Designation = dtrow["Designation"].ToString();
            OtherDetailshas.Department = dtrow["Department"].ToString();
            OtherDetailshas.ProbationPd = dtrow["ProbationPd"].ToString();
            OtherDetailshas.Dateofjoining = dtrow["Dateofjoining"].ToString();
            //OtherDetailshas.OfferAccepted = dtrow["OfferAccepted"].ToString();
            OtherDetailshas.YearOFPassing = dtrow["YearOFPassing"].ToString();
            OtherDetailshas.Plant = dtrow["plant"].ToString();
        }
        con.Close();
        return OtherDetailshas;
    }

    public class MyViewModel
    {
        public List<TableComon> TableEarning { get; set; }
        public List<TableComon> TableContribution { get; set; }
        public OtherDetails OtherDetails { get; set; }

    }
}