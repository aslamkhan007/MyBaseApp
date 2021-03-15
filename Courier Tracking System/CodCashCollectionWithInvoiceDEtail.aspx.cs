using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;

public partial class Courier_Tracking_System_CodCashCollectionWithInvoiceDEtail : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void radbtnFetch_Click(object sender, EventArgs e)
    {
        sql = "JCT_COURIER_COD_CASH_COLLECTION_WithInvoice";

        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        //cmd.Parameters.Add("@AWBNO", SqlDbType.VarChar, 50).Value = radAwbNo.Text;
        cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 30).Value = Convert.ToString(radDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateFrom.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 50).Value = Convert.ToString(radDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateTo.SelectedDate).ToShortDateString());
        //cmd.Parameters.Add("@CARRIER", SqlDbType.VarChar, 500).Value = RadComboBox1.SelectedItem.Text;
        //cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 30).Value = radtxtInvoiceNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        
    }



    protected void radbtnExcel_Click(object sender, EventArgs e)
    {
        string sql = "JCT_COURIER_COD_CASH_COLLECTION_Excel";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        if (!string.IsNullOrEmpty(radDateTo.SelectedDate.ToString()))
        {
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToString(radDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateFrom.SelectedDate).ToShortDateString());
        }
        if (!string.IsNullOrEmpty(radDateTo.SelectedDate.ToString()))
        {
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToString(radDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateTo.SelectedDate).ToShortDateString());
        }
        //if (!string.IsNullOrEmpty(radAwbNo.Text))
        //{
        //    cmd.Parameters.Add("@AWBNo", SqlDbType.VarChar, 30).Value = radAwbNo.Text;
        //}
        //if (!string.IsNullOrEmpty(RadComboBox1.SelectedItem.Text))
        //{
        //    cmd.Parameters.Add("@Carrier", SqlDbType.VarChar, 100).Value = RadComboBox1.SelectedItem.Text;
        //}


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; filename=CODCourier.xls";
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

        //obj.Close();
    }



    






}