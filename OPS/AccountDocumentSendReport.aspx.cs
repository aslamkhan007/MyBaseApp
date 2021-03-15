using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_AccountDocumentSendReport : System.Web.UI.Page
{
    string shpConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shpConnectionString"].ConnectionString;
    String sql;
    Connection cn;
    string str = string.Empty;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new Connection(shpConnectionString);
    }
    protected void radbtnFetch_Click(object sender, EventArgs e)
    {
        Gridbind();
    }


    public void Gridbind()
    {
        DateTime dt = Convert.ToDateTime(radDtPckrStartFrom.SelectedDate);
        string temp = dt.ToShortDateString();
        if (temp == "1/1/0001")
        {
            temp = "";
        }
        DateTime dt1 = Convert.ToDateTime(radDtEndDate.SelectedDate);
        string temp1 = dt1.ToShortDateString();
        if (temp1 == "1/1/0001")
        {
            temp1 = "";
        }
        str = "SELECT DocumentId,InvoiceNo,Line_no, CONVERT(VARCHAR(11), InvoiceDate )AS InvoiceDate , GrNo , GrDate , ItemGroup , Quantity ,Customer, CustomerName ,SpCode ,SalePerson ,ItemNo ,ActionPerformed ,DocumentSendTo ,CONVERT(VARCHAR(11), DocumentSendDate )AS DocumentSendDate,CASE WHEN DocumentReceive='Y' THEN 'Received' WHEN DocumentReceive='N' THEN 'Not Received' ELSE 'Pending' END AS DocumentReceive  ,CONVERT(VARCHAR(11), DocumentreceiveDate )AS DocumentreceiveDate FROM    dbo.tblAccountDocumentSend WHERE   CONVERT (VARCHAR(11), DocumentSendDate, 120) BETWEEN CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), '" + temp + "')) AND     CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), '" + temp1 + "')) ";
        cmd = new SqlCommand(str, cn.Connection());
        cmd.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();
        da.Fill(ds);

        RadGrid1.DataSource = null;
        RadGrid1.DataSource = ds;
        RadGrid1.Visible = true;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (Convert.ToDateTime(radDtPckrStartFrom.SelectedDate).ToShortDateString() == "1/1/0001")
        {
          
        }
        Gridbind();
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        Gridbind();
       RadGrid1.MasterTableView.GridLines =GridLines.Both;
       RadGrid1.ExportSettings.IgnorePaging = true;
       RadGrid1.ExportSettings.OpenInNewWindow = true;
       RadGrid1.MasterTableView.ExportToExcel();
    }
    //public void ConfigureExport()
    //{
    //    RadGrid1.ExportSettings.ExportOnlyData = true;
    //    RadGrid1.ExportSettings.ExportOnlyData = true;
    //    RadGrid1.ExportSettings.IgnorePaging = true;
    //    RadGrid1.ExportSettings.OpenInNewWindow = true;
    //}


    //protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    //{
    //    ConfigureExport();
    //}
    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        RadGrid1.ExportSettings.OpenInNewWindow = true;
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.MasterTableView.ExportToExcel();
    }
    protected void RadButton2_Click(object sender, EventArgs e)
    {
        Gridbind();
    }
}