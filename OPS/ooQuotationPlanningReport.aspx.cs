using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_QuotationPlanningReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void radExcel_Click(object sender, EventArgs e)
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;
        RadGrid1.MasterTableView.ExportToExcel();
    }
    protected void radReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/QuotationPlanningReport.aspx");
    }
    protected void radFetch_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        //RadGrid1.DataSourceID ="SqlDataSource1";
        //RadGrid1.DataBind();
    }
}