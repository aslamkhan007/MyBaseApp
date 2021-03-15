using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Payroll_Jct_Payroll_PayScaleMapping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod]
    public static string[] GetCustomers(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select EmployeeName, EmployeeName from Jct_Payroll_PayScale_Master_Mapping where " +
                "EmployeeName like @SearchText + '%' and status = 'A' ";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}-{1}", sdr["EmployeeName"], sdr["EmployeeName"]));
                    }
                }
                conn.Close();
            }
            return customers.ToArray();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class SaveParameters
    {
        public string txtSearchEmployecode { get; set; }
        public string txtSeriesCode { get; set; }
        public string txtEmployeeName { get; set; }
        public string txtQualification { get; set; }
        public string txtExperience { get; set; }
        public string txtDesignation { get; set; }
        public string txtDepartment { get; set; }
        public string txtProbationPd { get; set; }
        public string txtDateofjoining { get; set; }
        public string txtOfferAccepted { get; set; }
        public string txtYearofPassing { get; set; }
        public string txtPlant { get; set; }
    }

    [System.Web.Services.WebMethod]
    public static string Save(string txtSeriesCode, string txtEmployeeName, string txtQualification, string txtExperience, string txtDesignation, string txtDepartment, string txtProbationPd, string txtDateofjoining, string txtOfferAccepted, string txtYearofPassing, string txtPlant)
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();

        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Master_Mapping_Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;


        if (txtSeriesCode != "")
        {
            cmd.Parameters.Add("@SeriesCode", SqlDbType.VarChar, 50).Value = txtSeriesCode;
        }

        if (txtEmployeeName != "")
        {
            cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50).Value = txtEmployeeName;
        }

        if (txtQualification != "")
        {
            cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 50).Value = txtQualification;
        }


        if (txtExperience != "")
        {
            cmd.Parameters.Add("@Experience", SqlDbType.VarChar, 50).Value = txtExperience;
        }


        if (txtDesignation != "")
        {
            cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 50).Value = txtDesignation;
        }


        if (txtDepartment != "")
        {
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50).Value = txtDepartment;
        }


        if (txtProbationPd != "")
        {
            cmd.Parameters.Add("@ProbationPd", SqlDbType.VarChar, 50).Value = txtProbationPd;
        }
      
        if (txtDateofjoining != "")
        {
            cmd.Parameters.Add("@Dateofjoining", SqlDbType.VarChar, 50).Value = txtDateofjoining;
        }

        if (txtOfferAccepted != "")
        {
            cmd.Parameters.Add("@OfferAccepted", SqlDbType.VarChar, 50).Value = txtOfferAccepted;
        }
        cmd.Parameters.Add("@HostId", SqlDbType.VarChar, 15).Value = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 10).Value = HttpContext.Current.Session["EmpCode"].ToString();

        if (txtYearofPassing != "")
        {
            cmd.Parameters.Add("@YearOFPassing", SqlDbType.VarChar, 50).Value = txtYearofPassing;
        }

        if (txtPlant != "")
        {
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = txtPlant;
        }

        cmd.ExecuteNonQuery();
        con.Close();
        return "ok";
    }

    [System.Web.Services.WebMethod]
    public static SaveParameters FetchExisting(string txtSearchEmployecode)
    {
        DataTable dt = new DataTable();
        SaveParameters ExistingRecord = new SaveParameters();
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Master_Mapping_Fetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50).Value = txtSearchEmployecode;        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dtrow in dt.Rows)
        {
            ExistingRecord.txtSeriesCode = dtrow["seriescode"].ToString();
            ExistingRecord.txtEmployeeName = dtrow["EmployeeName"].ToString();
            ExistingRecord.txtQualification = dtrow["Qualification"].ToString();
            ExistingRecord.txtExperience = dtrow["Experience"].ToString();
            ExistingRecord.txtDesignation = dtrow["Designation"].ToString();
            ExistingRecord.txtDepartment = dtrow["Department"].ToString();
            ExistingRecord.txtProbationPd = dtrow["ProbationPd"].ToString();
            ExistingRecord.txtDateofjoining = dtrow["Dateofjoining"].ToString();
            ExistingRecord.txtOfferAccepted = dtrow["OfferAccepted"].ToString();
            ExistingRecord.txtYearofPassing = dtrow["YearOFPassing"].ToString();
            ExistingRecord.txtPlant = dtrow["Plant"].ToString();           
        }
        con.Close();
        return ExistingRecord;
    }

}