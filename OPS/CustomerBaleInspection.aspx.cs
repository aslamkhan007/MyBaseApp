using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

public partial class OPS_CustomerBaleInspection : System.Web.UI.Page
{
    string shpConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shpConnectionString"].ConnectionString;
    string prodConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["prodConnectionString"].ConnectionString;
    Connection cn;
    Connection cn1;
    Functions obj1 = new Functions();
    String sql;
    DataTable dt;
    DataTable datatable = new DataTable();
    public string strParameter = "";
    SqlConnection con;
    string str;
    SqlCommand cmd;
    string empcode;

    public static int bindagain = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new Connection(shpConnectionString);
        cn1 = new Connection(prodConnectionString);
        lnkFsendReq.Visible = false;

        if (!Page.IsPostBack)
        {

            //BindGridviewData();
            GetPendingBales();
            GetReturnBales();


        }

    }
    protected void BindGridviewData()
    {


        sql = "BalesInspectionDetail";
        SqlCommand cmd = new SqlCommand(sql, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;
        cmd.Parameters.Add("@BaleFrom", SqlDbType.VarChar, 20).Value = txtBaleFrom.Text;
        cmd.Parameters.Add("@BaleTo", SqlDbType.VarChar, 20).Value = txtBaleTo.Text;
        cmd.Parameters.Add("@InvoiceFrom", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@InvoiceTo", SqlDbType.VarChar, 20).Value = "";
        if (dropdownBales.SelectedValue == "B")
            cmd.Parameters.Add("@Parameter", SqlDbType.VarChar, 20).Value = "BaleWise";
        else
            cmd.Parameters.Add("@Parameter", SqlDbType.VarChar, 20).Value = "OrderWise";

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No Records Found";
        }
        else
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }

    public void GetPendingBales()
    {
        str = "Select Distinct FRequest,OrderNo,Custcode,Sort,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate   from tblBalesInspection where LAcceptance IS NOT NULL and LSend IS NOT NULL and FAcceptance IS NULL  AND LAcceptance='A' Order By FRequest desc ";

        cmd = new SqlCommand(str, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        GridView2.DataSource = null;
        GridView2.DataSource = ds;
        GridView2.DataBind();

    }

    public void GetReturnBales()
    {
        str = "Select Distinct FRequest,BaleNo,Meters,CONVERT(VARCHAR(20),FRequestDate,110) as FRequestDate ,OrderNo,Custcode,Sort,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate  from tblBalesInspection where LAcceptance IS NOT NULL and FAcceptance IS NOT NULL AND FReturn IS NULL AND  FAcceptance <>'R' Order By FRequest desc ";

        cmd = new SqlCommand(str, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        GridView4.DataSource = null;
        GridView4.DataSource = ds;
        GridView4.DataBind();
        if (dt.Rows.Count > 0)
            LinkButton3.Visible = true;
        else
            LinkButton3.Visible = false;
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void LnkfrstFetch_Click(object sender, EventArgs e)
    {
        if (dropdownBales.SelectedValue == "B")
        {
            BindGridviewData();

        }
        if (dropdownBales.SelectedValue == "I")
        {
            BindGridInvoiceData();
        }
        if (dropdownBales.SelectedValue == "O")
        {
            BindGridviewData();
        }

        lnkFsendReq.Visible = true;


    }
    protected void BindGridInvoiceData()
    {
        sql = "BalesInspectionDetail";
        SqlCommand cmd = new SqlCommand(sql, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;
        cmd.Parameters.Add("@BaleFrom", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@BaleTo", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@InvoiceFrom", SqlDbType.VarChar, 20).Value = txtBaleFrom.Text;
        cmd.Parameters.Add("@InvoiceTo", SqlDbType.VarChar, 20).Value = txtBaleTo.Text;
        cmd.Parameters.Add("@Parameter", SqlDbType.VarChar, 20).Value = "InvoiceWise";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No Records Found";
        }
        else
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
    protected void lnksecfetch_Click(object sender, EventArgs e)
    {
        bindagain = 2;
        BindGridInvoiceData();
    }

    protected void lnkFsendReq_Click(object sender, EventArgs e)
    {
        strParameter = "BalesRequestedByFolding";

        datatable.Columns.Add("Bale");
        datatable.Columns.Add("Meters");
        datatable.Columns.Add("Order");
        datatable.Columns.Add("Cust");
        datatable.Columns.Add("Sort");
        datatable.Columns.Add("Variant");
        datatable.Columns.Add("InvoiceNo");
        datatable.Columns.Add("InvoiceDate");



        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                if (chkRow.Checked)
                {
                    string bale = row.Cells[1].Text;
                    Double meters = Convert.ToDouble(row.Cells[2].Text);
                    string sort = row.Cells[3].Text;
                    string grade = row.Cells[4].Text;
                    string order = row.Cells[5].Text.ToString();
                    if (order == "&nbsp;")
                    {
                        order = " ";
                    }
                    string customer = row.Cells[6].Text;
                    string invoiceno = row.Cells[7].Text;
                    string invoicedate = row.Cells[8].Text;

                    datatable.Rows.Add(bale, meters, order, customer, sort, grade, invoiceno, invoicedate);
                }
            }

        }

        insertdata();
        if (bindagain == 1)
        {
            BindGridviewData();
        }

        if (bindagain == 2)
        {
            BindGridInvoiceData();
        }


    }

    public void insertdata()
    {
        SqlCommand command = new SqlCommand();
        string str1, str2;
        string checkBale = null;
        SqlDataReader dr = null;
        string strReqID = null;
        int ReqId = 0;
        SqlTransaction CommonTrans;

        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();

        try
        {
            strReqID = "SELECT  ISNULL(MAX(FRequest), 0) FROM tblBalesInspection";
            command.Transaction = CommonTrans;
            command.CommandText = strReqID;
            command.Connection = con;
            dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    ReqId = Convert.ToInt32(dr[0].ToString());
                    ReqId = ReqId + 1;
                }

            }
            else
            {
                ReqId = 1;
            }
            dr.Close();

            ViewState["RequestId"] = null;
            ViewState["RequestId"] = ReqId;

            for (int i = 0; i < datatable.Rows.Count; i++)
            {

                //checkBale = "Select * from tblBalesInspection where BaleNo='" + datatable.Rows[i][0].ToString() + "'";
checkBale = "Select * from tblBalesInspection where LReturnAcceptance IS NULL and  BaleNo='" + datatable.Rows[i][0].ToString() + "'";
                command.Transaction = CommonTrans;
                command.CommandText = checkBale;
                command.Connection = con;
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    string message = "Bale already send" + datatable.Rows[i][0].ToString();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    dr.Close();
                    CommonTrans.Rollback();
                    con.Close();
                    return;

                }
                dr.Close();
                string InvoiceNo = datatable.Rows[i][6].ToString();
                if (datatable.Rows[i][6].ToString() == "&nbsp;")
                {
                    InvoiceNo = "";
                }
                string p = datatable.Rows[i][7].ToString();
                string Invoicedate;
                if (datatable.Rows[i][7].ToString() == "&nbsp;")
                {
                    Invoicedate = null;

                }
                else
                {
                    Invoicedate = datatable.Rows[i][7].ToString();
                }

                str1 = "insert into tblBalesInspection(BaleNo,FRequest,FRequestDate,Custcode,OrderNo,Meters,Sort,Variant,InvoiceNo,InvoiceDate)";
                str2 = " values('" + datatable.Rows[i][0].ToString() + "','" + ReqId + "','" + DateTime.Now + "','" + datatable.Rows[i][3].ToString() + "','" + datatable.Rows[i][2].ToString() + "'," + datatable.Rows[i][1].ToString() + ",'" + datatable.Rows[i][4].ToString() + "','" + datatable.Rows[i][5].ToString() + "','" + InvoiceNo + "','" + Invoicedate + "')";
                str1 = str1 + str2;
                command.Transaction = CommonTrans;
                command.CommandText = str1;
                command.Connection = con;
                command.ExecuteNonQuery();



            }
            CommonTrans.Commit();
            con.Close();
            string final = "Bales send succesfully";
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(final);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());

            SendMail(ReqId);
            if (dropdownBales.SelectedValue == "B")
            {
                BindGridviewData();

            }
            if (dropdownBales.SelectedValue == "I")
            {
                BindGridInvoiceData();
            }
            if (dropdownBales.SelectedValue == "O")
            {
                BindGridviewData();
            }

            lnkFsendReq.Visible = true;

            // ClearControls();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);

        }

        return;

    }

    private void SendMail(int id)
    {

        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["prodConnectionString"].ConnectionString;

        using (SqlConnection con = new SqlConnection(strcon))
        {

            using (SqlCommand cmd = new SqlCommand("JCT_BALES_INSPECTION_MAIL_NOTIFICATION", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FID", SqlDbType.VarChar).Value = ViewState["RequestId"];
                cmd.Parameters.Add("@Parameter", SqlDbType.VarChar).Value = strParameter;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }

    private void ClearControls()
    {
        txtBaleFrom.Text = "";
        txtBaleTo.Text = "";
        GridView1.DataSource = null;
        GridView1.Rows[0].Cells.Clear();

    }


    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView2.SelectedRow;

        string sKey = GridView2.SelectedDataKey.Value.ToString();

        str = "Select FRequest,BaleNo,Meters,CONVERT(VARCHAR(20),FRequestDate,110) as FRequestDate ,OrderNo,Custcode,Sort,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate  from tblBalesInspection where   FRequest=" + sKey + "  AND LAcceptance='A' AND LSEND IS NOT NULL AND FAcceptance IS NULL AND FReturn IS NULL  Order By InvoiceNo";
        cmd = new SqlCommand(str, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        GridView3.DataSource = null;
        GridView3.DataSource = ds;
        GridView3.DataBind();
        datatable = dt;


    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        strParameter = "BalesReturnByFolding";
        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;
        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();

        try
        {
            string RequestId = string.Empty;
            int ReqId = 0;
            string ReturnRemarks = string.Empty;

            foreach (GridViewRow row in GridView4.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkReturn") as CheckBox);
                    if (chkRow.Checked)
                    {
                        if (RequestId == "")
                        {
                            RequestId = row.Cells[1].Text;
                        }
                        else
                        {
                            RequestId = RequestId + "-" + row.Cells[1].Text;
                        }

                        //  RequestId = row.Cells[1].Text;
                        ReturnRemarks = ((TextBox)row.FindControl("txtReturnRemarks")).Text;

                        str = "Update tblBalesInspection set FReturn='Y', FReturnDate='" + DateTime.Now + "', FReturnRemarks='" + ReturnRemarks + "' where BaleNo ='" + row.Cells[2].Text + "'";
                        command.Transaction = CommonTrans;
                        command.CommandText = str;
                        command.Connection = con;
                        command.ExecuteNonQuery();
                    }
                }


            }
            // ReqId = Convert.ToInt32(RequestId);
            ViewState["RequestId"] = null;
            ViewState["RequestId"] = RequestId;

            CommonTrans.Commit();
            con.Close();
            GetReturnBales();
            string final = "Bales Returned";
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(final);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
            //SendMail(ReqId);
            SendMailSalePerson(RequestId);

        }
        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }

    }

    protected void lnkAccept_Click(object sender, EventArgs e)
    {
        strParameter = "BalesAcceptedByFolding";

        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;

        //**************************************************************************

        string ActionValue = String.Empty;
        string Bale = string.Empty;
        string RequestId = string.Empty;
        string RemarksValue = string.Empty;
        int ReqId = 0;

        DataTable dt = new DataTable();
        dt.Columns.Add("BaleNo");
        dt.Columns.Add("ActionName");
        dt.Columns.Add("FRequest");
        dt.Columns.Add("Remarks");

        foreach (GridViewRow row in GridView3.Rows)
        {
            ActionValue = ((DropDownList)row.FindControl("chk")).SelectedItem.Value;
            RemarksValue = ((TextBox)row.FindControl("txtRemarks")).Text;
            Bale = row.Cells[2].Text;
            RequestId = row.Cells[1].Text;

            DataRow dr = dt.NewRow();

            dr["BaleNo"] = Bale;
            dr["ActionName"] = ActionValue;
            dr["Remarks"] = RemarksValue;
            dr["FRequest"] = RequestId;
            dt.Rows.Add(dr);
        }
        ReqId = Convert.ToInt32(dt.Rows[0][2].ToString());
        ViewState["RequestId"] = null;
        ViewState["RequestId"] = dt.Rows[0][2].ToString();


        //**************************************************************************
        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();


        try
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str = "Update tblBalesInspection set FAcceptance='" + dt.Rows[i][1] + "', FAcceptanceDate='" + DateTime.Now + "', FAcceptRemarks='" + dt.Rows[i][3] + "' where BaleNo ='" + dt.Rows[i][0].ToString() + "'";
                command.Transaction = CommonTrans;
                command.CommandText = str;
                command.Connection = con;
                command.ExecuteNonQuery();

            }
            CommonTrans.Commit();
            con.Close();
            GetPendingBales();
            GetReturnBales();
            GridView3.DataSource = null;
            GridView3.DataBind();
            string final = "Bales Accepted By Folding";
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(final);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
            SendMail(ReqId);

        }
        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.FindControl("allchk")).Attributes.Add("onclick",
                "javascript:SelectAll('" +
                ((CheckBox)e.Row.FindControl("allchk")).ClientID + "')");
        }
    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.FindControl("allchk1")).Attributes.Add("onclick",
                "javascript:SelectAllChk('" +
                ((CheckBox)e.Row.FindControl("allchk1")).ClientID + "')");
        }
    }
    protected void dropdownBales_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (dropdownBales.SelectedValue == "I" || dropdownBales.SelectedValue == "O")
        {
            txtBaleFrom.MaxLength = 16;
        }
        if (dropdownBales.SelectedValue == "B")
        {
            txtBaleFrom.MaxLength = 11;
        }

    }


    protected void CheckedChanged(object sender, EventArgs e)
    {

        CheckBox chkAcceptRej = (CheckBox)sender;
        DropDownList ddlRow;

        if (chkAcceptRej.Checked == true)
        {

            foreach (GridViewRow row in GridView3.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chkAcceptRej.Checked == true)
                    {
                        ddlRow = (row.Cells[0].FindControl("Chk") as DropDownList);
                        ddlRow.SelectedValue = "A";
                    }


                }
            }
        }

        if (chkAcceptRej.Checked == false)
        {

            foreach (GridViewRow row in GridView3.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chkAcceptRej.Checked == false)
                    {
                        ddlRow = (row.Cells[0].FindControl("Chk") as DropDownList);
                        ddlRow.SelectedValue = "R";
                    }


                }
            }
        }

    }

    protected void lnkNotReturn_Click(object sender, EventArgs e)
    {
        strParameter = "BalesNotReturnByFolding";
        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;
        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();

        try
        {
            string RequestId = string.Empty;
            int ReqId = 0;
            string ReturnRemarks = string.Empty;

            foreach (GridViewRow row in GridView4.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkReturn") as CheckBox);
                    if (chkRow.Checked)
                    {
                        if (RequestId == "")
                        {
                            RequestId = row.Cells[1].Text;
                        }
                        else
                        {
                            RequestId = RequestId + "-" + row.Cells[1].Text;
                        }
                        ReturnRemarks = ((TextBox)row.FindControl("txtReturnRemarks")).Text;

                        str = "Update tblBalesInspection set FReturn='N', FReturnDate='" + DateTime.Now + "', FReturnRemarks='" + ReturnRemarks + "' where BaleNo ='" + row.Cells[2].Text + "'";
                        command.Transaction = CommonTrans;
                        command.CommandText = str;
                        command.Connection = con;
                        command.ExecuteNonQuery();
                    }
                }


            }


            ViewState["RequestId"] = null;
            ViewState["RequestId"] = RequestId;

            CommonTrans.Commit();
            con.Close();
            GetReturnBales();
            string final = "Bales Not Returned";
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(final);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
            SendMailSalePerson(RequestId);

        }
        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }

    }
    private void SendMailSalePerson(string id)
    {

        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["prodConnectionString"].ConnectionString;

        using (SqlConnection con = new SqlConnection(strcon))
        {

            using (SqlCommand cmd = new SqlCommand("JCT_BALES_INSPECTION_MAIL_NotReturned", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FID", SqlDbType.VarChar).Value = ViewState["RequestId"];
                cmd.Parameters.Add("@Parameter", SqlDbType.VarChar).Value = strParameter;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }

}
