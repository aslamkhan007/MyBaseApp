using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.IO;

public partial class OPS_PartyBankReport : System.Web.UI.Page
{
    public BankParty cc;
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["productionConnectionString1"].ConnectionString;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime d1 = DateTime.Now;
        
        cc = new BankParty(jctdevConnectionString);
        if (!IsPostBack)
        {
            txt_FromDate.Text = "";
            txt_ToDate.Text = "";
            BindReportData();
            txt_FromDate.Text = d1.ToShortDateString();
            txt_ToDate.Text = d1.ToShortDateString();
        }
    
       
    }

    private void BindReportData()
    {
        grdView.DataSource = null;
        dt = cc.BindReportData();
        grdView.DataSource = dt;
        grdView.DataBind();

    }
    protected void lnkBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/PartyBankDetail.aspx");
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        cc.FromDate = txt_FromDate.Text;
        cc.ToDate = txt_ToDate.Text;
        BindReportData();
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        BindReportData();

        string attachment = "attachment; filename=DailyCollection.xls";
        Response.Clear();
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
      
  
      Response.End();


    }
}