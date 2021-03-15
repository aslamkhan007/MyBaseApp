using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;

public partial class OPS_AccountDocumentsReceived : System.Web.UI.Page
{
    string shpConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shpConnectionString"].ConnectionString;
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["jctdevConnectionString"].ConnectionString;
    Connection cn;
    string str = string.Empty;
    SqlCommand cmd;
    DataTable dt;
    static string InvoiceNo;
    SqlConnection con;
    Connection cn1;
    static string invoicecollection = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new Connection(shpConnectionString);
        cn1 = new Connection(jctdevConnectionString);

        radtxtfrominvoice.Visible = true;
        radtxttoinvoice.Visible = true;
        radDtPckrStartFrom.Visible = false;
        radDtEndDate.Visible = false;

        lblParty.Visible = false;
        if (!Page.IsPostBack)
        {
            RadPartycode.Text = "";
            RadPartycode.Visible = false;
            //  Gridbind();
        }

        //  Gridbind();
    }
    public void Gridbind()
    {
        try
        {
            str = "SELECT  InvoiceNo ,CustomerName,CONVERT(VARCHAR(20), InvoiceDate, 6) AS InvoiceDate ,GrNo ,GrDate ,ItemGroup ,Quantity ,Customer ,SalePerson ,OrderNo ,ItemNo ,ActionPerformed ,DocumentSendTo ,CONVERT(VARCHAR(20), DocumentSendDate, 6) AS DocumentSendDate FROM tblAccountDocumentSend WHERE DocumentReceive IS NULL";

            cmd = new SqlCommand(str, cn.Connection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            RadGrid1.DataSource = null;
            RadGrid1.DataBind();
            RadGrid1.DataSource = ds;
            RadGrid1.DataBind();


        }

        catch
        {

        }

    }


    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var dataItem = RadGrid1.SelectedItems[0] as GridDataItem;
            if (dataItem != null)
            {
                InvoiceNo = dataItem["InvoiceNo"].Text;
                lblinvoiceselected.Text = "";
                lblinvoiceselected.Text = InvoiceNo;
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        RadGrid1.CurrentPageIndex = e.NewPageIndex;

        //Gridbind();
        //  RadGrid1.Rebind();
    }
    protected void RadButtonApply_Click(object sender, EventArgs e)
    {
        string i = InvoiceNo;
        Boolean flag = false;
        string item1 = radComboAction.SelectedValue.ToString();
        invoicecollection = "";
        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;
        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();

        if (item1 == "Received")
        {
            item1 = "Y";
        }
        if (item1 == "Not Received")
        {
            item1 = "N";
        }

        try
        {

            foreach (GridDataItem item in RadGrid1.Items)
            {
                CheckBox chk = (CheckBox)item["ClientSelectColumn1"].Controls[0];

                if (chk.Checked.ToString() == "True")
                {
                    flag = true;
                    if (invoicecollection == "")
                    {
                        invoicecollection = item["InvoiceNo"].Text;
                    }
                    else
                    {
                        invoicecollection = invoicecollection + '-' + item["InvoiceNo"].Text;
                    }
                    str = "UPDATE tblAccountDocumentSend SET DocumentReceive='" + item1 + "', DocumentreceiveDate='" + DateTime.Now + "' , Remarks ='" + txtRemarks.Text + "' WHERE  InvoiceNo ='" + item["InvoiceNo"].Text + "' AND Line_no=" + item["Line_no"].Text + "";
                    command.Transaction = CommonTrans;
                    command.CommandText = str;
                    command.Connection = con;
                    command.ExecuteNonQuery();
                }

            }

            CommonTrans.Commit();
            con.Close();
            if (flag == true)
            {
                if (item1 == "Y")
                {
                    item1 = "Received";
                }
                if (item1 == "N")
                {
                    item1 = "Not Received";
                }
                RadWindowManager1.RadAlert(" <b>Document " + item1 + "</b><br />", 200, 100, "Data Saved Message", "callBackFn");
                AccountDocumentsSend(invoicecollection);
            }
            if (flag == false)
            {
                RadWindowManager1.RadAlert(" <b>Please Select Invoice First</b><br />", 200, 100, "Error Message", "callBackFn");
            }


            RadGrid1.DataSource = null;
            RadGrid1.Rebind();
            //Gridbind();

        }

        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }

    }
    public void AccountDocumentsSend(string invoicecollection)
    {
        string sql = "jct_ops_AccountDocumentSend";
        con = new SqlConnection(jctdevConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar, 1000).Value = invoicecollection;
        cmd.Parameters.Add("@Department", SqlDbType.VarChar, 20).Value = "Logistic";
        cmd.ExecuteNonQuery();
        con.Close();

    }
    protected void radselect_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (radselect.SelectedValue == "InvoiceWise")
        {
            radtxtfrominvoice.Visible = true;
            radtxttoinvoice.Visible = true;
            radDtPckrStartFrom.Visible = false;
            radDtEndDate.Visible = false;

            RadPartycode.Text = "";
            RadPartycode.Visible = false;
            lblParty.Visible = false;
        }
        if (radselect.SelectedValue == "DateWise")
        {
            radDtPckrStartFrom.Visible = true;
            radDtEndDate.Visible = true;
            radtxtfrominvoice.Visible = false;
            radtxttoinvoice.Visible = false;

            RadPartycode.Visible = true;
            lblParty.Visible = true;
        }
    }

    protected void radbtnFetch_Click(object sender, EventArgs e)
    {
        RadGrid1.DataSource = null;
        RadGrid1.DataBind();

        if (radselect.SelectedValue == "InvoiceWise")
        {
            GridbindInvoiceWise();
        }


        if (radselect.SelectedValue == "DateWise")
        {
            if (radDtPckrStartFrom.SelectedDate > radDtEndDate.SelectedDate)
            {
                RadWindowManager1.RadAlert(" <b>From Date Should Less Than To date</b><br />", 200, 100, "Error", "callBackFn");
                return;
            }
            GridbindDateWise();

        }
		
		  if (radtxtDocId.Text != "")
        {
            GridbindDocId();
        }
    }
	
	  public void GridbindDocId()
    {
        try
        {

            str = "SELECT  InvoiceNo ,CustomerName,Line_no,CONVERT(VARCHAR(20), InvoiceDate, 6) AS InvoiceDate ,GrNo ,GrDate ,ItemGroup ,Quantity ,Customer ,SalePerson ,OrderNo ,ItemNo ,ActionPerformed ,DocumentSendTo ,CONVERT(VARCHAR(20), DocumentSendDate, 6) AS DocumentSendDate FROM tblAccountDocumentSend WHERE DocumentId = '" + radtxtDocId.Text + "'   AND  DocumentReceive IS NULL";
            cmd = new SqlCommand(str, cn.Connection());
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            RadGrid1.DataSource = null;
            RadGrid1.DataSource = ds;


        }

        catch
        {

        }
    }
	
    public void GridbindInvoiceWise()
    {
        try
        {

            str = "SELECT  InvoiceNo ,CustomerName,Line_no,CONVERT(VARCHAR(20), InvoiceDate, 6) AS InvoiceDate ,GrNo ,GrDate ,ItemGroup ,Quantity ,Customer ,SalePerson ,OrderNo ,ItemNo ,ActionPerformed ,DocumentSendTo ,CONVERT(VARCHAR(20), DocumentSendDate, 6) AS DocumentSendDate FROM tblAccountDocumentSend WHERE InvoiceNo BETWEEN '" + radtxtfrominvoice.Text + "' AND '" + radtxttoinvoice.Text + "'  AND SUBSTRING(InvoiceNo,12,5)= SUBSTRING('" + radtxttoinvoice.Text + "',12,5) AND  DocumentReceive IS NULL";
            cmd = new SqlCommand(str, cn.Connection());
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            RadGrid1.DataSource = null;
            RadGrid1.DataSource = ds;


        }

        catch
        {

        }
    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

        if (radselect.SelectedValue == "InvoiceWise")
        {
            GridbindInvoiceWise();
        }


        if (radselect.SelectedValue == "DateWise")
        {
            GridbindDateWise();
        }
		
		  if (radtxtDocId.Text != "")
        {
            GridbindDocId();
        }
		
		
    }
    public void GridbindDateWise()
    {
        try
        {
            string partycode = string.Empty;

            partycode = RadPartycode.Text;

            int index = partycode.LastIndexOf("~");
            index = index + 1;
            partycode = partycode.Substring(index, partycode.Length - index);


            //str = "SELECT  InvoiceNo ,Line_no,CONVERT(VARCHAR(20), InvoiceDate, 6) AS InvoiceDate ,GrNo ,GrDate ,ItemGroup ,Quantity ,Customer,CustomerName ,SalePerson ,OrderNo ,ItemNo ,ActionPerformed ,DocumentSendTo ,CONVERT(VARCHAR(20), DocumentSendDate, 6) AS DocumentSendDate FROM tblAccountDocumentSend WHERE InvoiceDate BETWEEN '" + radDtPckrStartFrom.SelectedDate + "' AND '" + radDtEndDate.SelectedDate + "' AND  DocumentReceive IS NULL";
            //str = "SELECT  InvoiceNo ,Line_no,CONVERT(VARCHAR(20), InvoiceDate, 6) AS InvoiceDate ,GrNo ,GrDate ,ItemGroup ,Quantity ,Customer,CustomerName ,SalePerson ,OrderNo ,ItemNo ,ActionPerformed ,DocumentSendTo ,CONVERT(VARCHAR(20), DocumentSendDate, 6) AS DocumentSendDate FROM tblAccountDocumentSend WHERE InvoiceDate BETWEEN '" + radDtPckrStartFrom.SelectedDate + "' AND '" + radDtEndDate.SelectedDate + "' AND  DocumentReceive IS NULL AND  ( customer = '" + partycode + " ' OR '" + partycode + " ' = '')  ";
str = "SELECT  InvoiceNo ,CustomerName,Line_no,CONVERT(VARCHAR(20), InvoiceDate, 6) AS InvoiceDate ,GrNo ,GrDate ,ItemGroup ,Quantity ,Customer, CustomerName ,SalePerson ,OrderNo ,ItemNo ,ActionPerformed ,DocumentSendTo ,CONVERT(VARCHAR(20), DocumentSendDate, 6) AS DocumentSendDate FROM tblAccountDocumentSend WHERE InvoiceDate BETWEEN '" + radDtPckrStartFrom.SelectedDate + "' AND '" + radDtEndDate.SelectedDate + "' AND  DocumentReceive IS NULL AND  ( customer = '" + partycode + " ' OR '" + partycode + " ' = '')  ORDER BY DocumentSendDate DESC ";            
cmd = new SqlCommand(str, cn.Connection());
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            RadGrid1.DataSource = null;
            RadGrid1.DataSource = ds;


        }

        catch
        {

        }
    }

}