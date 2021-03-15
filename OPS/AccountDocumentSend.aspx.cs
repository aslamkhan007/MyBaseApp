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
    static string invoicecollection = string.Empty;
    Connection cn;
    Connection cn1;

    SqlConnection con;
    SqlCommand cmd;
    DataTable dt;
    string str = string.Empty;
    static DataTable data = null;
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
            // GridbindInvoiceWise();
            RadPartycode.Text = "";
            RadPartycode.Visible = false;
        }
        else
        {
            // Gridbind();
        }

    }
    protected void radbtnFetch_Click(object sender, EventArgs e)
    {



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

            Gridbind();
        }


    }
    public void GridbindInvoiceWise()
    {
        try
        {

            //str = "SELECT invoice_no AS InvoiceNo ,line_no,CONVERT(VARCHAR(20), invoice_dt, 6) AS InvoiceDate ,item_group_no AS ItemGroup ,CONVERT(REAL,invoice_qty,0) AS Qty ,customer AS Customer";
            //str = str + ", SalePerson AS SalePerson ,OrderNo ,ItemNo ,CustomerName ,OrderDate ,RTRIM(GRFIRSTNO) + ' - ' + GRSECONDNO AS GRFIRSTNO  ";
            //str = str + ",  CONVERT(VARCHAR(20), GRFIRSTDATE, 6) + ' - '+ CONVERT(VARCHAR(20), GRLASTDATE, 6) AS GRFIRSTDATE FROM JCT_DISPATCH_TABLE_BI_RBIL WHERE  invoice_no BETWEEN '" + radtxtfrominvoice.Text + "' AND '" + radtxttoinvoice.Text + "' AND GRFIRSTNO IS NOT NULL AND SUBSTRING(invoice_no,12,5)= SUBSTRING('" + radtxttoinvoice.Text + "',12,5) AND invoice_no NOT IN(SELECT InvoiceNo FROM tblAccountDocumentSend) order by InvoiceNo ";


            str = "SELECT invoice_no AS InvoiceNo ,line_no,CONVERT(VARCHAR(20), invoice_dt, 6) AS InvoiceDate ,item_group_no AS ItemGroup ,CONVERT(REAL,invoice_qty,0) AS Qty ,customer AS Customer";
            str = str + ",SpCode, SalePerson AS SalePerson ,OrderNo ,ItemNo ,CustomerName ,OrderDate ,RTRIM(GRFIRSTNO) + ' - ' + GRSECONDNO AS GRFIRSTNO  ";
            str = str + ",  CONVERT(VARCHAR(20), GRFIRSTDATE, 6) + ' - '+ CONVERT(VARCHAR(20), GRLASTDATE, 6) AS GRFIRSTDATE FROM JCT_DISPATCH_TABLE_BI_RBIL WHERE  invoice_no BETWEEN '" + radtxtfrominvoice.Text + "' AND '" + radtxttoinvoice.Text + "' AND GRFIRSTNO IS NOT NULL AND SUBSTRING(invoice_no,12,5)= SUBSTRING('" + radtxttoinvoice.Text + "',12,5)         AND invoice_no + '' + CONVERT(VARCHAR(10), line_no) NOT IN (SELECT  InvoiceNo + '' + CONVERT(VARCHAR(10), Line_no) FROM tblAccountDocumentSend ) order by InvoiceNo ";

            cmd = new SqlCommand(str, cn.Connection());
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            RadGrid1.DataSource = null;
            RadGrid1.DataSource = ds;
            //  RadGrid1.DataBind();
            // RadButtonApply.Visible = true;

        }

        catch
        {

        }
    }
    public void Gridbind()
    {
        string partycode = string.Empty;
       
        partycode = RadPartycode.Text;

        int index = partycode.LastIndexOf("~");
        index = index + 1;
        partycode = partycode.Substring(index, partycode.Length - index);

        try
        {

            str = "SELECT invoice_no AS InvoiceNo ,line_no,CONVERT(VARCHAR(20), invoice_dt, 6) AS InvoiceDate ,item_group_no AS ItemGroup ,CONVERT(REAL,invoice_qty,0) AS Qty ,customer AS Customer";
            str = str + ",SpCode, SalePerson AS SalePerson ,OrderNo ,ItemNo ,CustomerName ,OrderDate ,RTRIM(GRFIRSTNO) + ' - ' + GRSECONDNO AS GRFIRSTNO  ";
            str = str + ",  CONVERT(VARCHAR(20), GRFIRSTDATE, 6) + ' - '+ CONVERT(VARCHAR(20), GRLASTDATE, 6) AS GRFIRSTDATE FROM JCT_DISPATCH_TABLE_BI_RBIL WHERE  invoice_dt BETWEEN '" + radDtPckrStartFrom.SelectedDate + "' AND '" + radDtEndDate.SelectedDate + "' AND GRFIRSTNO IS NOT NULL  AND ( customer = '"+partycode+"' OR '"+partycode+"' = '') AND invoice_no + '' + CONVERT(VARCHAR(10), line_no) NOT IN (SELECT  InvoiceNo + '' + CONVERT(VARCHAR(10), Line_no) FROM tblAccountDocumentSend ) order by InvoiceNo ";

            cmd = new SqlCommand(str, cn.Connection());
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            RadGrid1.DataSource = null;
            RadGrid1.DataSource = ds;
            //  RadGrid1.DataBind();
            RadButtonApply.Visible = true;

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
        string invoice = string.Empty;
        invoicecollection = "";
        Boolean flag = false;

        string action = radaction.SelectedValue.ToString();
        string document = raddocumentsend.SelectedValue.ToString();
        Boolean select = false;
        foreach (GridDataItem dataItem in RadGrid1.Items)
        {
            CheckBox chk = (CheckBox)dataItem["ClientSelectColumn1"].Controls[0];

            if (chk.Checked.ToString() == "True")
            {
                select = true;
            }
        }
        if (select == false)
        {
            RadWindowManager1.RadAlert(" <b>Select Invoice First Before Click On Apply Button</b><br />", 200, 100, "Message", "callBackFn");
            return;
        }
        else
        {
            con = new SqlConnection(shpConnectionString);
            con.Open();
            CommonTrans = con.BeginTransaction();
            SqlDataReader dr = null;
            string strReqID = null;
            int DocId = 1000;

            try
            {

                strReqID = "SELECT  ISNULL(MAX(DocumentId), 0) FROM tblAccountDocumentSend";
                command.Transaction = CommonTrans;
                command.CommandText = strReqID;
                command.Connection = con;
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        DocId = Convert.ToInt32(dr[0].ToString());
                        if (DocId == 0)
                            DocId = 1000;
                        DocId = DocId + 1;
                    }

                }
                else
                {
                    DocId = 1000;
                }
                dr.Close();

                ViewState["DocumentId"] = null;
                ViewState["DocumentId"] = DocId;



                foreach (GridDataItem dataItem in RadGrid1.Items)
                {
                    CheckBox chk = (CheckBox)dataItem["ClientSelectColumn1"].Controls[0];

                    if (chk.Checked.ToString() == "True")
                    {
                        flag = true;
                        if (invoicecollection == "")
                        {
                            invoicecollection = dataItem["InvoiceNo"].Text;
                        }
                        else
                        {
                            invoicecollection = invoicecollection + '-' + dataItem["InvoiceNo"].Text;
                        }
                        string txt1 = dataItem["InvoiceNo"].Text;

                        str1 = "insert into tblAccountDocumentSend(InvoiceNo,Line_no,InvoiceDate,GrNo,GrDate,ItemGroup,Quantity,Customer,SalePerson,OrderNo,ItemNo,DocumentSend,DocumentSendDate,ActionPerformed,DocumentSendTo,CustomerName,SpCode,DocumentId)";
                        str2 = " values('" + dataItem["InvoiceNo"].Text + "'," + dataItem["Line_no"].Text + ",'" + dataItem["InvoiceDate"].Text + "','" + dataItem["GRFIRSTNO"].Text + "','" + dataItem["GRFIRSTDATE"].Text + "','" + dataItem["ItemGroup"].Text + "'," + dataItem["Qty"].Text + ",'";
                        //str2 = str2 + dataItem["Customer"].Text + "','" + dataItem["SalePerson"].Text + "','" + dataItem["OrderNo"].Text + "','" + dataItem["ItemNo"].Text + "','Y','" + System.DateTime.Now + "','" + action + "','" + document + "','" + dataItem["CustomerName"].Text + "','" + dataItem["Spcode"].Text + "'," + DocId + ")";
str2 = str2 + dataItem["Customer"].Text + "','" + dataItem["SalePerson"].Text + "','" + dataItem["OrderNo"].Text + "','" + dataItem["ItemNo"].Text + "','Y','" + System.DateTime.Now + "','" + action + "','" + document + "','" + dataItem["CustomerName"].Text.Replace("'", "") + "','" + dataItem["Spcode"].Text + "'," + DocId + ")";
                        str1 = str1 + str2;
                        command.Transaction = CommonTrans;
                        command.CommandText = str1;
                        command.Connection = con;
                        command.ExecuteNonQuery();
                    }

                }
                CommonTrans.Commit();
                con.Close();
                AccountDocumentsSend(invoicecollection);

                RadGrid1.DataSource = null;
                RadGrid1.Rebind();

                RadWindowManager1.RadAlert(" <b>Document Send</b><br />", 200, 100, "Saved", "callBackFn");



            }
            catch (Exception ex)
            {
                CommonTrans.Rollback();
                con.Close();
                throw new Exception(ex.Message);

            }
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
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar, 1000).Value = invoice;
        cmd.Parameters.Add("@Department", SqlDbType.VarChar, 20).Value = "Accounts";
        cmd.ExecuteNonQuery();
        con.Close();


    }


    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        RadGrid1.CurrentPageIndex = e.NewPageIndex;

        //Gridbind();
        //  RadGrid1.Rebind();
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
            RadPartycode.Visible = true;
            lblParty.Visible = true;
           
            radtxtfrominvoice.Visible = false;
            radtxttoinvoice.Visible = false;
        }
    }
    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

        if (radselect.SelectedValue == "InvoiceWise")
        {
            GridbindInvoiceWise();
        }


        if (radselect.SelectedValue == "DateWise")
        {
            Gridbind();
        }

    }
}