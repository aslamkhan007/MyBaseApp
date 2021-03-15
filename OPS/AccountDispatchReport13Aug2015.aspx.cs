using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_AccountDispatchReport : System.Web.UI.Page
{

    Connection cn;
    string sql;
    String script;
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shpConnectionString"].ConnectionString;
    DataTable dt;
    DateTime dtFrom, dtNow, dtTo;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new Connection(jctdevConnectionString);

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        dtFrom = DateTime.Parse(txt_FromDate.Text);
        dtTo = DateTime.Parse(txt_ToDate.Text);

        if (dtFrom.Date > dtTo)
        {
            Message.Text = "From Date should not be greater than To Date";
            return;
        }
        else
        {
            Message.Text = "";
        }

        sql = "JCT_Account_Dispatch_Report";
        SqlCommand cmd = new SqlCommand(sql, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;

        cmd.Parameters.Add("@sdate", SqlDbType.VarChar, 20).Value = txt_FromDate.Text;
        cmd.Parameters.Add("@edate", SqlDbType.VarChar, 10).Value = txt_ToDate.Text;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];

        grdView.DataSource = ds;
        grdView.DataBind();



    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        dtFrom = DateTime.Parse(txt_FromDate.Text);
        dtTo = DateTime.Parse(txt_ToDate.Text);
        string strCustCode = "";
        strCustCode = txtCustomer.Text;
        int len = strCustCode.Length;
        int index = strCustCode.IndexOf("~") + 1;
        strCustCode = strCustCode.Substring(index, len - index);

        if (dtFrom.Date > dtTo)
        {
            Message.Text = "From Date should not be greater than To Date";
            return;
        }
        else
        {
            Message.Text = "";
        }
        sql = "JCT_Account_Dispatch_Report";
        SqlCommand cmd = new SqlCommand(sql, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;

        cmd.Parameters.Add("@sdate", SqlDbType.VarChar, 20).Value = txt_FromDate.Text;
        cmd.Parameters.Add("@edate", SqlDbType.VarChar, 10).Value = txt_ToDate.Text;
        cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, 10).Value = strCustCode;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        string attachment = "attachment; filename=AccountDispatchReport.xls";
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
    protected void lnkGRDetailToExcel_Click(object sender, EventArgs e)
    {
        dtFrom = DateTime.Parse(txt_FromDate.Text);
        dtTo = DateTime.Parse(txt_ToDate.Text);

        string strCustCode = "";
        strCustCode = txtCustomer.Text;
        int len = strCustCode.Length;
        int index = strCustCode.IndexOf("~") + 1;
        strCustCode = strCustCode.Substring(index,len-index);

        if (dtFrom.Date > dtTo)
        {
            Message.Text = "From Date should not be greater than To Date";
            return;
        }
        else
        {
            Message.Text = "";
        }
        sql = "JCT_GRDATA_Report";
        SqlCommand cmd = new SqlCommand(sql, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;

        cmd.Parameters.Add("@sdate", SqlDbType.VarChar, 20).Value = txt_FromDate.Text;
        cmd.Parameters.Add("@edate", SqlDbType.VarChar, 10).Value = txt_ToDate.Text;
        cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, 10).Value = strCustCode;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        string attachment = "attachment; filename=GRDataReport.xls";
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