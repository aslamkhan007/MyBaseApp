using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_QuotationPlanningReport : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString;
    SqlConnection con;

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

        con = new SqlConnection(ConStr);
        con.Open();
        string sql = "JCT_OPS_QUOTATION_PLANNING_REPORT";
        //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlCommand cmd = new SqlCommand(sql, con);
        //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar,30).Value = Convert.ToString(txtDateFrom.SelectedDate.ToString() == "" ? "": Convert.ToDateTime(txtDateFrom.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 30).Value = Convert.ToString(txtDateTo.SelectedDate.ToString()=="" ? "" : Convert.ToDateTime(txtDateTo.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@QuotationDtFrom", SqlDbType.VarChar, 30).Value = Convert.ToString(txtQuotDateFrom.SelectedDate.ToString()==""? "" :  Convert.ToDateTime(txtQuotDateFrom.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@QuotationDtTo", SqlDbType.VarChar, 30).Value = Convert.ToString( txtQuotDateTo.SelectedDate.ToString()==""?"" : Convert.ToDateTime(txtQuotDateTo.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@QuotationNo", SqlDbType.VarChar, 30).Value = txtQuotationNo.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 30).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = radDDLPlant.SelectedItem.Text ;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 10).Value = txtSortNo.Text;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        RadGrid1.DataSource = ds.Tables[0];
        RadGrid1.DataBind();
    }
}