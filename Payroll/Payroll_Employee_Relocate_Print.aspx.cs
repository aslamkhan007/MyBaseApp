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

public partial class Payroll_Payroll_Employee_Relocate_Print : System.Web.UI.Page
{
    Connection obj = new Connection();
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
            AttendenceDate();
        }
         //FetchRecord();
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Employee_Relocate_Print.aspx");
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        FetchRecord();
    }

    public void FetchRecord()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Employee_Relocate_Print";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@MONTHYEAR", SqlDbType.DateTime).Value = txtfromdate.Text;
        Cmd.Parameters.Add("@ENDMONTHYEAR", SqlDbType.DateTime).Value = txttodate.Text;
        Cmd.Parameters.Add("@CardNo", SqlDbType.VarChar, 50).Value = txtSaviorcardno.Text;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);

        rpt.Load(Server.MapPath("Payroll_Salary_Employee_Relocate.rpt"));
        //    rpt.Load(Server.MapPath("Payroll_Salary_Loans.rpt"));
        //    rpt.Load(Server.MapPath("Payroll_Salary_Deductions.rpt"));
        rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctdev");
        rpt.SetDataSource(ds.Tables[0]);
        rpt.SetDataSource(ds);
        CrystalReportViewer1.ReportSource = rpt;
        ds.Clear();
    }

    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txtfromdate.Text = dr["FromDate"].ToString();
                txttodate.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }

    protected void txtfromdate_TextChanged(object sender, EventArgs e)
    {
        DateTime origDT = Convert.ToDateTime(txtfromdate.Text);
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txttodate_CalendarExtender.SelectedDate = lastDate;
    }

}