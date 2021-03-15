using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
public partial class OPS_AccountDocumentSend : System.Web.UI.Page
{
    string shpConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shpConnectionString"].ConnectionString;
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["jctdevConnectionString"].ConnectionString;

    Connection cn;
    Connection cn1;

    SqlConnection con;
    SqlCommand cmd;
    DataTable dt;
    string str = string.Empty;
    static DataTable data=null;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new Connection(shpConnectionString);
        cn1 = new Connection(jctdevConnectionString);

        if (!Page.IsPostBack)
        {
            Gridbind();
            RadGrid2.Visible = false;
        }
        else
        {
          // Gridbind();
        }
  
    }
    protected void radbtnFetch_Click(object sender, EventArgs e)
    {
        if (radDtPckrStartFrom.SelectedDate > radDtEndDate.SelectedDate)
        {
            RadWindowManager1.RadAlert(" <b>From Date Should Less Than To date</b><br />", 200, 100, "Error", "callBackFn");
        }
        
            else
        {
            Gridbind();
        }

    }
    public void Gridbind()
    {
        try
        {

            str = "SELECT invoice_no AS InvoiceNo ,CONVERT(VARCHAR(20), invoice_dt, 6) AS InvoiceDate ,item_group_no AS ItemGroup ,CONVERT(REAL,invoice_qty,0) AS Qty ,customer AS Customer";
            str = str + ", SalePerson AS SalePerson ,OrderNo ,ItemNo ,CustomerName ,OrderDate ,RTRIM(GRFIRSTNO) + ' - ' + GRSECONDNO AS GRFIRSTNO  ";
            str = str + ",  CONVERT(VARCHAR(20), GRFIRSTDATE, 6) + ' - '+ CONVERT(VARCHAR(20), GRLASTDATE, 6) AS GRFIRSTDATE FROM JCT_DISPATCH_TABLE_BI_RBIL WHERE  invoice_dt BETWEEN '" + radDtPckrStartFrom.SelectedDate + "' AND '" + radDtEndDate.SelectedDate + "' AND GRFIRSTNO IS NOT NULL AND invoice_no NOT IN(SELECT InvoiceNo FROM tblAccountDocumentSend) order by InvoiceNo ";

            cmd = new SqlCommand(str, cn.Connection());
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            RadGrid1.DataSource = null;
            RadGrid1.DataSource = ds;
            RadGrid1.DataBind();
            // RadButtonApply.Visible = true;

        }

        catch
        {

        }
    }
    protected void RadButtonApply_Click(object sender, EventArgs e)
    {

        SqlTransaction CommonTrans;
        SqlCommand command = new SqlCommand();
        string str1 = string.Empty;
        string str2 = string.Empty;
        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();

        try
        {
            foreach (GridDataItem dataItem in RadGrid1.Items)
            {

                string txt1 = dataItem["InvoiceNo"].Text;
                string txt = ((dataItem["chkbox"].FindControl("radddlAction") as RadComboBox).SelectedValue).ToString();
                str1 = "insert into tblAccountDocumentSend(InvoiceNo,InvoiceDate,GrNo,GrDate,ItemGroup,Quantity,Customer,SalePerson,OrderNo,ItemNo,DocumentSend,DocumentSendDate,ActionPerformed,DocumentSendTo)";
                str2 = " values('" + dataItem["InvoiceNo"].Text + "','" + dataItem["InvoiceDate"].Text + "','" + dataItem["GRFIRSTNO"].Text + "','" + dataItem["GRFIRSTDATE"].Text + "','" + dataItem["ItemGroup"].Text + "'," + dataItem["Qty"].Text + ",'";
                str2 = str2 + dataItem["Customer"].Text + "','" + dataItem["SalePerson"].Text + "','" + dataItem["OrderNo"].Text + "','" + dataItem["ItemNo"].Text + "','Y','" + System.DateTime.Now + "','" + ((dataItem["chkbox"].FindControl("radddlAction") as RadComboBox).SelectedValue).ToString() + "','" + ((dataItem["CheckBoxCol"].FindControl("radddlsend") as RadComboBox).SelectedValue).ToString() + "')";
                str1 = str1 + str2;
                command.Transaction = CommonTrans;
                command.CommandText = str1;
                command.Connection = con;
                command.ExecuteNonQuery();


            }
            CommonTrans.Commit();
            con.Close();

            RadGrid1.DataSource = null;
            RadGrid1.Rebind();
            //AccountDocumentsSend();
            RadWindowManager1.RadAlert(" <b>Document Send</b><br />", 200, 100, "Saved", "callBackFn");



        }
        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }


    }

   

    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("InvoiceNo");
        dt.Columns.Add("Action");
        dt.Columns.Add("Send");
        dt.Columns.Add("InvoiceDate");
        dt.Columns.Add("GRFIRSTNO");
        dt.Columns.Add("GRFIRSTDATE");
        dt.Columns.Add("ItemGroup");
        dt.Columns.Add("OrderNo");
        dt.Columns.Add("Qty");
        dt.Columns.Add("Customer");
        dt.Columns.Add("SalePerson");
        dt.Columns.Add("ItemNo");

        try
        {
            var dataItem = RadGrid1.SelectedItems[0] as GridDataItem;
            if (dataItem != null)
            {
                string invoice = dataItem["InvoiceNo"].Text;
                string action = ((dataItem["chkbox"].FindControl("radddlAction") as RadComboBox).SelectedValue).ToString();
                string sendselection = ((dataItem["CheckBoxCol"].FindControl("radddlsend") as RadComboBox).SelectedValue).ToString();
                DataRow dr = dt.NewRow();

                dr["InvoiceNo"] = invoice;
                dr["Action"] = action;
                dr["Send"] = sendselection;
                dr["InvoiceDate"] = dataItem["InvoiceDate"].Text;
                dr["GRFIRSTNO"] = dataItem["GRFIRSTNO"].Text;
                dr["GRFIRSTDATE"] = dataItem["GRFIRSTDATE"].Text;
                dr["ItemGroup"] = dataItem["ItemGroup"].Text;
                dr["Qty"] = dataItem["Qty"].Text;
                dr["Customer"] = dataItem["CustomerName"].Text;
                dr["SalePerson"] = dataItem["SalePerson"].Text;
                dr["ItemNo"] = dataItem["ItemNo"].Text;

                dr["OrderNo"] = dataItem["OrderNo"].Text;



                dt.Rows.Add(dr);
                invoice = "";

            }
            RadGrid2.Visible = true;
            RadGrid2.DataSource = dt;
            data = null;
            data = dt;
            RadGrid2.DataBind();
          
        }
        catch (Exception ex)
        {

        }
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {

        SqlTransaction CommonTrans;
        SqlCommand command = new SqlCommand();
        string str1 = string.Empty;
        string str2 = string.Empty;
        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();
        string invoice = string.Empty;

       
        try
        {
            if (data == null)
            {
                RadWindowManager1.RadAlert(" <b>Select Invoice....!!!!</b><br />", 200, 100, "Saved", "callBackFn");
                RadGrid2.DataSource = null;
                RadGrid2.Rebind();
                RadGrid2.Visible = false;
            }
            else
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string custname = data.Rows[i][9].ToString();
                    custname = custname.Replace("'", "''");
                    invoice = data.Rows[i][0].ToString();

                    str1 = "insert into tblAccountDocumentSend(InvoiceNo,InvoiceDate,GrNo,GrDate,ItemGroup,Quantity,Customer,SalePerson,OrderNo,ItemNo,DocumentSend,DocumentSendDate,ActionPerformed,DocumentSendTo)";
                    str2 = " values('" + data.Rows[i][0].ToString() + "','" + data.Rows[i][3].ToString() + "','" + data.Rows[i][4].ToString() + "','" + data.Rows[i][5].ToString() + "','" + data.Rows[i][6].ToString() + "'," + data.Rows[i][8].ToString() + ",'";
                    str2 = str2 + custname + "','" + data.Rows[i][10].ToString() + "','" + data.Rows[i][7].ToString() + "','" + data.Rows[i][11].ToString() + "','Y','" + System.DateTime.Now + "','" + data.Rows[i][1].ToString() + "','" + data.Rows[i][2].ToString() + "')";
                    str1 = str1 + str2;
                    command.Transaction = CommonTrans;
                    command.CommandText = str1;
                    command.Connection = con;
                    command.ExecuteNonQuery();


                }

                CommonTrans.Commit();
                con.Close();

                RadGrid1.DataSource = null;
                Gridbind();
                RadGrid1.Rebind();
                RadGrid2.DataSource = null;
                RadGrid2.Rebind();
                RadGrid2.Visible = false;

                AccountDocumentsSend(invoice);
                RadWindowManager1.RadAlert(" <b>Document And Mail Send</b><br />", 200, 100, "Saved", "callBackFn");

            }

        }
        catch (Exception ex)
        {
            CommonTrans.Rollback();
            throw new Exception(ex.Message);

        }

    }


    public void AccountDocumentsSend(string invoice)
    {
        string sql = "jct_ops_AccountDocumentSend";
        con = new SqlConnection(jctdevConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar, 20).Value = invoice;
        cmd.Parameters.Add("@Department", SqlDbType.VarChar, 20).Value ="Accounts";
        cmd.ExecuteNonQuery();
        con.Close();


    }


    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        RadGrid1.CurrentPageIndex = e.NewPageIndex;
        RadGrid2.DataSource = null;
        RadGrid2.Rebind();
        //Gridbind();
      //  RadGrid1.Rebind();
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        Gridbind();
        RadGrid2.DataSource = null;
        RadGrid2.Rebind();

    }
}