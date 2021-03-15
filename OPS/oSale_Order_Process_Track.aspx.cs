using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class OPS_Sale_Order_Process_Track : System.Web.UI.Page
{
    string ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ReportDBConnectionString"].ConnectionString;
    SqlConnection sqlCon ;

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void radbtnFetch_Click(object sender, EventArgs e)
    {
        try
        {
        sqlCon = new SqlConnection(ConnectionString);
        sqlCon.Open();
        sql = "jct_ops_get_sale_order_process_track";
        SqlCommand cmd = new SqlCommand(sql, sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;

        cmd.Parameters.Add("@Start_Dt", SqlDbType.DateTime).Value = radDtPckrStartFrom.SelectedDate;
        cmd.Parameters.Add("@End_Dt", SqlDbType.DateTime).Value = radDtEndDate.SelectedDate;

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        RadGrid1.DataSource = ds.Tables[0];
        RadGrid1.DataBind();

        sqlCon.Close();
        }

        catch
        {

        }
    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            sql = "jct_ops_get_sale_order_process_track";
            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            cmd.Parameters.Add("@Start_Dt", SqlDbType.DateTime).Value = radDtPckrStartFrom.SelectedDate;
            cmd.Parameters.Add("@End_Dt", SqlDbType.DateTime).Value = radDtEndDate.SelectedDate;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            RadGrid1.DataSource = ds.Tables[0];

            sqlCon.Close();
        }

        catch
        {

        }
    }

    protected void radbtnExcel_Click(object sender, EventArgs e)
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;
        RadGrid1.MasterTableView.ExportToExcel();
    }
}