using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class OPS_CustomerBaleInspectionAccept : System.Web.UI.Page
{
    string shpConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shpConnectionString"].ConnectionString;
    string prodConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["prodConnectionString"].ConnectionString;
    Connection cn;
    Connection cn1;
    Functions obj1 = new Functions();
    String sql;
    DataTable dt;
    public DataTable datatable = new DataTable();
    SqlConnection con;
    string str;
    string empcode;
    SqlCommand cmd;
    SqlDataReader dr;
    public string sKey = string.Empty;

    public string strParameter = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new Connection(shpConnectionString);

        cn1 = new Connection(prodConnectionString);
        if (!Page.IsPostBack)
        {

            BindGridviewData();
            GetBalesToSend();
            GetReturnAcceptanceBales();

        }



    }
    protected void BindGridviewData()
    {

        str = "Select Distinct FRequest,OrderNo,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate,Custcode,Sort,Variant from tblBalesInspection where LAcceptance is NULL Order By FRequest desc ";
        cmd = new SqlCommand(str, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            Panel2.Visible = true;
        }
        else
        {
            Panel2.Visible = false;
            lblPendingBales.Visible = true;
        }



    }
    protected void LnkFetch_Click(object sender, EventArgs e)
    {


        if (txtReqID.Text == "")
            str = "Select Distinct FRequest,OrderNo,Custcode,Sort,Variant,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate from tblBalesInspection where LAcceptance is NULL  Order By FRequest desc";
        else
            str = "Select Distinct FRequest,OrderNo,Custcode,Sort,Variant,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate from tblBalesInspection where LAcceptance is NULL and FRequest=" + txtReqID.Text + "  Order By FRequest desc ";

        cmd = new SqlCommand(str, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        GridView1.DataSource = null;
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow row = GridView1.SelectedRow;
        sKey = GridView1.SelectedDataKey.Value.ToString();

        str = "Select Distinct FRequest,BaleNo,CONVERT(VARCHAR(20),FRequestDate,110) as FRequestDate,Meters,OrderNo,Custcode,Sort,Variant,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate from tblBalesInspection where LAcceptance is NULL and FRequest=" + sKey + " Order By BaleNo";
        cmd = new SqlCommand(str, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            GridView2.DataSource = null;
            GridView2.DataSource = ds;
            GridView2.DataBind();
            datatable = dt;
            Panel1.Visible = true;
            lnkSave.Visible = true;

        }
        else
        {
            Panel1.Visible = false;
            lblBaleDetail.Visible = true;
        }
        //GridView1.SelectedRow.BackColor = Color.LightGreen;


    }
    public void GetBalesToSend()
    {
        str = "Select Distinct FRequest,BaleNo,CONVERT(VARCHAR(20),FRequestDate,110) as FRequestDate,Meters,OrderNo,Custcode,Sort,Variant,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate  from tblBalesInspection where LAcceptance IS NOT NULL AND LAcceptance<>'R' and LSEND IS NULL  Order By FRequest desc ";

        cmd = new SqlCommand(str, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        GridView4.DataSource = null;
        GridView4.DataSource = ds;
        GridView4.DataBind();

    }
    public void GetReturnAcceptanceBales()
    {
        str = "Select Distinct FRequest,BaleNo,CONVERT(VARCHAR(20),FRequestDate,110) as FRequestDate,OrderNo,Meters,Custcode,Sort,Variant,InvoiceNo, CONVERT(VARCHAR(20),InvoiceDate,110) as InvoiceDate  from tblBalesInspection where LAcceptance IS NOT NULL and FAcceptance IS NOT NULL and FReturn = 'Y' and LReturnAcceptance IS NULL  Order By FRequest desc ";

        cmd = new SqlCommand(str, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        GridView3.DataSource = null;
        GridView3.DataSource = ds;
        GridView3.DataBind();
    }
    protected void lnkSave_Click(object sender, EventArgs e)
    {
        strParameter = "BalesAcceptByLogistic";

        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;
        string str;

        //**************************************************************************

        string ActionValue = String.Empty;
        string Remarks = String.Empty;
        string Bale = string.Empty;
        string RequestId = string.Empty;
        int ReqId = 0;
        DataTable dt = new DataTable();

        dt.Columns.Add("BaleNo");
        dt.Columns.Add("ActionName");
        dt.Columns.Add("FRequest");
        dt.Columns.Add("LARemarks");


        foreach (GridViewRow row in GridView2.Rows)
        {
            ActionValue = ((DropDownList)row.FindControl("chk")).SelectedItem.Value;
            Bale = row.Cells[1].Text;
            RequestId = row.Cells[2].Text;
            Remarks = ((TextBox)row.FindControl("txtRemarks")).Text;


            DataRow dr = dt.NewRow();


            dr["BaleNo"] = Bale;
            dr["ActionName"] = ActionValue;
            dr["FRequest"] = RequestId;
            dr["LARemarks"] = Remarks;
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
                str = "Update tblBalesInspection set LAcceptance='" + dt.Rows[i][1] + "', LAcceptanceDate='" + DateTime.Now + "' , LAcceptRemarks = '" + dt.Rows[i][3].ToString() + "'  where BaleNo ='" + dt.Rows[i][0].ToString() + "'";
                command.Transaction = CommonTrans;
                command.CommandText = str;
                command.Connection = con;
                command.ExecuteNonQuery();


            }
            CommonTrans.Commit();

            BindGridviewData();
            GetBalesToSend();
            GetReturnAcceptanceBales();
            GridView2.DataSource = null;
            GridView2.DataBind();

            string final = "Bales Accepted By Logistic";
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(final);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());

            SendMail(ReqId);
            con.Close();

        }
        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }


    }

    private void SendMail(int id)
    {
        //sql = "JCT_BALES_INSPECTION_MAIL_NOTIFICATION ";
        //SqlCommand cmd = new SqlCommand(sql, cn1.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 180;
        //cmd.Parameters.Add("@FID", SqlDbType.Int, 20).Value = 8; //ViewState["RequestId"];
        //cmd.Parameters.Add("@Parameter", SqlDbType.VarChar, 20).Value = "BalesAcceptByLogistic";
        //cmd.ExecuteNonQuery();

        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["prodConnectionString"].ConnectionString;

        using (SqlConnection con = new SqlConnection(strcon))
        {

            using (SqlCommand cmd = new SqlCommand("JCT_BALES_INSPECTION_MAIL_NOTIFICATION", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FID", SqlDbType.VarChar).Value = ViewState["RequestId"];
                cmd.Parameters.Add("@Parameter", SqlDbType.VarChar).Value = strParameter; //"BalesAcceptByLogistic";

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }


    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string Remarks = String.Empty;
        string RequestId = string.Empty;
        int ReqId = 0;
        strParameter = "BalesSendByLogistic";

        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;
        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();

        try
        {

            foreach (GridViewRow row in GridView4.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                    Remarks = ((TextBox)row.FindControl("txtSendRemarks")).Text;

                    if (chkRow.Checked)
                    {
                        RequestId = row.Cells[1].Text;
                        str = "UPDATE tblBalesInspection set LSend='Y', LSendDate='" + DateTime.Now + "' , LsendRemarks='" + Remarks + "'  WHERE BaleNo ='" + row.Cells[2].Text + "'";
                        command.Transaction = CommonTrans;
                        command.CommandText = str;
                        command.Connection = con;
                        command.ExecuteNonQuery();
                    }
                }
            }

            ReqId = Convert.ToInt32(RequestId);
            ViewState["RequestId"] = null;
            ViewState["RequestId"] = RequestId;

            CommonTrans.Commit();

            GetBalesToSend();
            GetReturnAcceptanceBales();
            string final = "Bales Send To Folding ";
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(final);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
            SendMail(ReqId);
            con.Close();
        }
        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        strParameter = "BalesRetAcceptByLogistic";
        string RequestId = string.Empty;
        int ReqId = 0;

        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;
        con = new SqlConnection(shpConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();

        string Remarks = String.Empty;
        try
        {

            foreach (GridViewRow row in GridView3.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("ChkReturn") as CheckBox);
                    Remarks = ((TextBox)row.FindControl("txtReturnRemarks")).Text;
                    if (chkRow.Checked)
                    {
                        RequestId = row.Cells[1].Text;
                        str = "Update tblBalesInspection set LReturnAcceptance='Y', LReturnAcceptanceDate='" + DateTime.Now + "' , LRetacceptRemarks ='" + Remarks + "'  WHERE  BaleNo ='" + row.Cells[2].Text + "'";
                        command.Transaction = CommonTrans;
                        command.CommandText = str;
                        command.Connection = con;
                        command.ExecuteNonQuery();
                    }
                }

            }

            ReqId = Convert.ToInt32(RequestId);
            ViewState["RequestId"] = null;
            ViewState["RequestId"] = RequestId;

            CommonTrans.Commit();

            GetReturnAcceptanceBales();
            string final = "Returned Bales Accepted By Logistic  ";
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(final);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
         
            SendMail(ReqId);
            con.Close();

        }
        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }
    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.FindControl("allchk")).Attributes.Add("onclick",
                "javascript:SelectAll('" +
                ((CheckBox)e.Row.FindControl("allchk")).ClientID + "')");
        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.FindControl("allchk1")).Attributes.Add("onclick",
                "javascript:SelectAllChk('" +
                ((CheckBox)e.Row.FindControl("allchk1")).ClientID + "')");
        }
    }



    protected void CheckedChanged(object sender, EventArgs e)
    {

        CheckBox chkAcceptRej = (CheckBox)sender;
        DropDownList ddlRow;

        if (chkAcceptRej.Checked == true)
        {

            foreach (GridViewRow row in GridView2.Rows)
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

            foreach (GridViewRow row in GridView2.Rows)
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



}