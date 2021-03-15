using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Data;
using System.Net;
using System.Text;

public partial class OPS_MRPPCAuthorization : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    string script;
    SqlConnection con;
    SqlCommand cmd;
    Connection cn;
    DataTable dt;
    string ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["jctdevConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new Connection(ConnectionString);

        if (Session["empcode"].ToString() == "")
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            HtmlForm frm = new HtmlForm();
            frm = (HtmlForm)this.Master.FindControl("form1");
            frm.Enctype = "multipart/form-data";
            BindGrid();
            BindFirstGrid();
        }
        BindGrid();
        BindFirstGrid();
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {

    }
    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            grdDetail.DataKeyNames.Equals("RequestID");
            String SanctionID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RequestID"));


            GridView GridViewNested_MultipleID = (GridView)e.Row.FindControl("nestedGridView_MultipleID");
            GridViewNested_MultipleID.DataKeyNames.Equals("SanctionNoteID");
            sql = "SELECT COUNT(*) AS count FROM dbo.jct_ops_material_request WHERE RequestID='" + SanctionID + "'";
            Int16 i = Convert.ToInt16(obj1.FetchValue(sql).ToString());

            if (i >= 1)
            {
                Label lbl = (Label)e.Row.FindControl("lbl");
                lbl.Visible = true;
                lbl.ToolTip = "More than one invoices are in this request number. Expand to view Details..!!";
                sql = "Jct_Ops_Mr_PPCMR_Detail";

                SqlCommand cmd = new SqlCommand(sql, cn.Connection());

                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 180;
                cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 14).Value = SanctionID;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                GridViewNested_MultipleID.DataSource = dt;
                GridViewNested_MultipleID.DataBind();
                //sql = " SELECT invoice_no AS Invoice,item_no AS Sort,customer AS Customer,b.empname AS SalesPerson,invoice_qty AS InvoiceQty,ret_qty AS ReturnQty,reason AS Reason FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person = REPLACE(b.empcode, '-', '')   WHERE RequestID='" + SanctionID + "' ";
                //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //GridViewNested_MultipleID.DataSource = ds.Tables[0];
                //GridViewNested_MultipleID.DataBind();
            }
            else
            {
                GridViewNested_MultipleID.DataSource = null;
                GridViewNested_MultipleID.DataBind();
            }


        }
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlEdit.Visible = true;
        GridViewRow row = grdDetail.SelectedRow;

        string sKey = grdDetail.SelectedDataKey.Value.ToString();
        txtMrNo.Text = sKey;
        txtcategory.Text = "";
        ddlAction.SelectedValue = "Select";
        ViewState["SanctionID"] = sKey;

    }
    protected void lnkAuthorize_Click(object sender, EventArgs e)
    {
        string status = string.Empty;

        if (txtMrNo.Text == "")
        {
            script = "alert('Please Select MR Number.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        if (ddlAction.SelectedValue == "Select")
        {
            script = "alert('Please Select Action.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

        if (ddlAction.SelectedValue == "A")
        {
            status = "PPCOPEN";
        }
        if (ddlAction.SelectedValue == "C")
        {
            status = "C";
        }
        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;
        string str1;
        con = new SqlConnection(ConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();
        try
        {

            str1 = "INSERT INTO jct_ops_MRPPC(RequestID,Category,ReqSO,PPCStatus,ReqSoDate,CreatedBy,CreatedDate) VALUES('" + txtMrNo.Text + "','" + txtcategory.Text + "','Y','" + status + "','" + DateTime.Now + "','" + Session["empcode"].ToString() + "','" + DateTime.Now + "')";

            command.Transaction = CommonTrans;
            command.CommandText = str1;
            command.Connection = con;
            command.ExecuteNonQuery();
            script = "alert('MR Authorized/Canceled');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            CommonTrans.Commit();
            con.Close();
            sendmail("BackOffice");

            BindGrid();
            BindFirstGrid();
            pnlEdit.Visible = false;
            txtMrNo.Text = "";
            txtcategory.Text = "";
            ddlAction.SelectedValue = "Select";



        }


        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }

    }
    public void sendmail(string Parameter)
    {
        string NotifyEmailGroup = string.Empty;
        string qry = string.Empty;
        NotifyEmailGroup = "Noreply@jctltd.com";
        SqlDataReader dr;
        if (Parameter == "BackOffice")
        {
            cmd = new SqlCommand("JCT_OPS_MR_PPC_PUSH_MAIL", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];
            cmd.Parameters.Add("@Parameter", SqlDbType.VarChar, 14).Value = Parameter;


            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    NotifyEmailGroup = NotifyEmailGroup + "," + dr[0];
                }
            }
            dr.Close();
        }
        if (Parameter == "Logistics")
        {
            cmd = new SqlCommand("JCT_OPS_MR_PPC_PUSH_MAIL", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];
            cmd.Parameters.Add("@Parameter", SqlDbType.VarChar, 14).Value = Parameter;

            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    NotifyEmailGroup = NotifyEmailGroup + "," + dr[0];
                }
            }
            dr.Close();
        }



        string Genratedby_Email = string.Empty;
        qry = "SELECT E_MailID FROM  mistel  WHERE  empcode  = '" + Session["EmpCode"].ToString() + "' ";
        cmd = new SqlCommand(qry, obj.Connection());
        dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                Genratedby_Email = dr[0].ToString();
            }
        }
        dr.Close();



        sendmail(Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "hitesh@jctltd.com,hiren@jctltd.com,sandeepr@jctltd.com", Parameter);
    }
    public void sendmail(string SalesPerson_Email, string too, string NotifyEmailGroup, string bccc, string parameter)
    {
      
        try
        {
            string sql = string.Empty;
            string to = string.Empty;
            string from = string.Empty;
            string bcc = string.Empty;
            string cc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;
            string url = string.Empty;
            string querystring = string.Empty;
            string usercode = string.Empty;
            string querystring1 = string.Empty;
            string querystring2 = string.Empty;



            if (ViewState["SanctionID"] != null)
            {
                if (parameter == "BackOffice")
                {
                    subject = "MR PPC Authorization For MR (BackOffice)" + ViewState["SanctionID"];
                    querystring = "SanctionID=" + ViewState["SanctionID"];
                    querystring1 = Session["Empcode"].ToString();
                    url = "http://testerp/FusionApps/ops/MRPPCAuthorizationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;
                    //url = "http://localhost:1084/FusionApps/ops/MRPPCAuthorizationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;
                }
                if (parameter == "Logistics")
                {
                    subject = "MR PPC Authorization For MR (Logistics) " + ViewState["SanctionID"];
                    querystring = "SanctionID=" + ViewState["SanctionID"];
                    querystring1 = Session["Empcode"].ToString();
                  //  url = "http://localhost:1084/FusionApps/ops/MRPPCAuthLogisticMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;
                    url = "http://testerp/FusionApps/ops/MRPPCAuthLogisticMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;
                    
                }

               


            }



            // url = "http://test2k/FusionApps/ops/MrFoldingObservationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;
            //  url = "http://testerp/FusionApps/ops/MrFoldingObservationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;

            @from = "Noreply@jctltd.com";



            to = too;
            bcc = bccc;

            cc = NotifyEmailGroup;

            string Body = GetPage(url);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(@from);
            if (to.Contains(","))
            {
                string[] tos = to.Split(',');
                for (int i = 0; i <= tos.Length - 1; i++)
                {
                    mail.To.Add(new MailAddress(tos[i]));
                }
            }
            else
            {
                mail.To.Add(new MailAddress(to));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                if (cc.Contains(","))
                {
                    string[] ccs = cc.Split(',');
                    for (int i = 0; i <= ccs.Length - 1; i++)
                    {
                        mail.CC.Add(new MailAddress(ccs[i]));
                    }
                }
                else
                {
                    mail.CC.Add(new MailAddress(cc));
                }
            }

            if (!string.IsNullOrEmpty(bcc))
            {
                if (bcc.Contains(","))
                {
                    string[] bccs = bcc.Split(',');
                    for (int i = 0; i <= bccs.Length - 1; i++)
                    {
                        mail.Bcc.Add(new MailAddress(bccs[i]));
                    }
                }
                else
                {
                    mail.Bcc.Add(new MailAddress(bcc));
                }
            }

            mail.Subject = subject;

            mail.Body = Body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("EXCHANGE2K7");
            SmtpMail.Send(mail);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return;
        }

    }
    protected string GetPage(string page_name)
    {
        WebClient myclient = new WebClient();
        string myPageHTML = null;
        byte[] requestHTML = null;
        string currentPageUrl = null;

        currentPageUrl = Request.Url.AbsoluteUri;
        currentPageUrl = page_name;

        UTF8Encoding utf8 = new UTF8Encoding();

        requestHTML = myclient.DownloadData(currentPageUrl);
        myPageHTML = utf8.GetString(requestHTML);

        //Response.Write(myPageHTML);

        return myPageHTML;

    }
    public void BindFirstGrid()
    {
        sql = "JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION_DETAILS";
        SqlCommand cmd = new SqlCommand(sql, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            grdDetail.DataSource = ds;
            grdDetail.DataBind();
            int columncount = grdDetail.Rows[0].Cells.Count;
            grdDetail.Rows[0].Cells.Clear();
            grdDetail.Rows[0].Cells.Add(new TableCell());
            grdDetail.Rows[0].Cells[0].ColumnSpan = columncount;
            grdDetail.Rows[0].Cells[0].Text = "No Records Found";
        }
        else
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            grdDetail.DataSource = ds;
            grdDetail.DataBind();
        }
    }
    public void BindGrid()
    {
        string str1;
        str1 = "SELECT RequestID ,Category ,ReqSO    FROM jct_ops_MRPPC WHERE PPCStatus='PPCOPEN' ORDER BY AuthDate DESC";
        cmd = new SqlCommand(str1, cn.Connection());

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        grdPending.DataSource = null;
        grdPending.DataSource = ds;
        grdPending.DataBind();
        grdPending.Visible = true;
    }
    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetail.PageIndex = e.NewPageIndex;
    }
    protected void grdPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPending.PageIndex = e.NewPageIndex;
    }
    protected void grdPending_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnllogsend.Visible = true;
        GridViewRow row = grdPending.SelectedRow;
        string sKey = grdPending.SelectedDataKey.Value.ToString();
        txtMRNumber.Text = sKey;

    }


    protected void lnkSend_Click(object sender, EventArgs e)
    {

        if (txtMRNumber.Text == "")
        {
            script = "alert('Please Select MR Number.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        if (txtOrderNo.Text == "")
        {
            script = "alert('Please Enter Order Number.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        if (txtRemarks.Text == "")
        {
            script = "alert('Please Enter Remarks.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }



        SqlCommand command = new SqlCommand();
        SqlTransaction CommonTrans;
        string str1;
        con = new SqlConnection(ConnectionString);
        con.Open();
        CommonTrans = con.BeginTransaction();
        try
        {

            str1 = "UPDATE jct_ops_MRPPC SET OrderNo='" + txtOrderNo.Text + "', PPCStatus='PPCAuth',LogisticSend='" + DateTime.Now + "',LogisticStatus='P' WHERE RequestID='" + txtMRNumber.Text + "'";

            command.Transaction = CommonTrans;
            command.CommandText = str1;
            command.Connection = con;
            command.ExecuteNonQuery();
            script = "alert('MR Send To Logistics');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            CommonTrans.Commit();


            grdPending.DataSource = null;
            grdPending.DataBind();

            BindGrid();
            BindFirstGrid();
            sendmail("Logistics");
            pnlEdit.Visible = false;
            txtMrNo.Text = "";
            txtcategory.Text = "";
            ddlAction.SelectedValue = "Select";
            txtOrderNo.Text = "";
            txtMRNumber.Text = "";
            txtRemarks.Text = "";
            con.Close();

        }


        catch (Exception ex)
        {
            CommonTrans.Rollback();
            con.Close();
            throw new Exception(ex.Message);

        }

    }
}