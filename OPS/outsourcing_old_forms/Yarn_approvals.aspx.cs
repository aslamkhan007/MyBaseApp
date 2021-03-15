using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using System.Net;

public partial class OPS_Yarn_approvals : System.Web.UI.Page
{

    SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    sendmail();
        //}

        if (!IsPostBack)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("jct_ops_yarn_enq", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                cmd.ExecuteNonQuery();

                con.Close();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
            }
            catch (Exception ex)
            {
                string script = "alert('Data Not Processed !');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        
    }

    protected void lnkApproved_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;

        for (int i = 0; i <= chklist.Items.Count - 1; i++)
        {
            if (chklist.Items[i].Selected == true)
            {
                cmd = new SqlCommand("jct_ops_yarn_apprvals", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
                cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 30).Value = chklist.Items[i].Text;
                cmd.Parameters.Add("@approvedby", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                cmd.Parameters.Add("@approveRmk", SqlDbType.VarChar, 200).Value = txtRemarks.Text;

                cmd.ExecuteNonQuery();
                //con.Close();
                
                string script = "alert('Vendors Accepted !');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }

        // float and freeze yarn request
        cmd = new SqlCommand("jct_ops_yarn_freeze", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"];
        cmd.Parameters.Add("@freeze_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
        //con.Open();
        cmd.ExecuteNonQuery();

        // insert final authorization hierarchy

        cmd = new SqlCommand("Jct_Ops_SanctionNote_InsertDynamic_User", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SanctionNote", SqlDbType.VarChar, 15).Value = ViewState["RequestID"];
        cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
        cmd.Parameters.Add("@Areacode", SqlDbType.Int).Value = 1044;
        cmd.Parameters.Add("@StartID", SqlDbType.SmallInt).Value = 0;
        cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ViewState["Plant"];
        cmd.ExecuteNonQuery();
     
        // send mail for authorization to hierarchy 

        //sendmailVendor();
        sendmail();
        con.Close();
    }

    //private void SendMailYarn()
    //{

    //    string @from = null;
    //    string to = null;
    //    string bcc = null;
    //    string cc = null;
    //    string subject = null;
    //    string body = null;

    //    con.Open();
    //    string sql = "SELECT b.EMPCODE,c.empname,d.E_MailID AS Email FROM jct_ops_yarn_purchase a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON CONVERT(VARCHAR,a.Requestid) = b.ID AND a.pending_at=CONVERT(VARCHAR,b.USERLEVEL) INNER JOIN dbo.JCT_EmpMast_Base c ON c.empcode=b.EMPCODE LEFT OUTER JOIN dbo.MISTEL d on d.empcode=b.EMPCODE where CONVERT(VARCHAR,a.Requestid) ='" + ViewState["requestID"] + "'";
    //    SqlCommand cmd = new SqlCommand(sql, con);
    //    SqlDataReader Dr = cmd.ExecuteReader();
    //    if (Dr.HasRows)
    //    {
    //        while (Dr.Read())
    //        {
    //            ViewState["PendingAtName"] = Dr["empname"].ToString();
    //            ViewState["PendingAtEmpCode"] = Dr["empcode"].ToString();
    //            ViewState["PendingAtEmail"] = Dr["Email"].ToString();
    //        }
    //    }
    //    Dr.Close();

    //    sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
    //    cmd = new SqlCommand(sql, con);
    //    Dr = cmd.ExecuteReader();
    //    if (Dr.HasRows)
    //    {
    //        while (Dr.Read())
    //        {
    //            ViewState["RequestBy"] = Dr["empname"].ToString();
    //            ViewState["RequestByEmail"] = Dr["email"].ToString();
    //        }
    //    }
    //    else
    //    {
    //        ViewState["RequestBy"] = "";
    //        ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
    //    }

    //    Dr.Close();
    //    //con.Close();
    //    StringBuilder sb = new StringBuilder();

    //    sb.AppendLine("<html>");
    //    sb.AppendLine("<head>");
    //    sb.AppendLine("<style type=\"text/css\">");
    //    sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
    //    sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
    //    sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
    //    sb.AppendLine("</style>");
    //    sb.AppendLine("</head>");

    //    sb.AppendLine("Hi,<br/>");
    //    sb.AppendLine("Outsourced Yarn Request has been generated in OPS by : " + ViewState["RequestBy"] + "<br/><br/>");
    //    sb.AppendLine("RequestID for your request is : " + ViewState["requestID"] + " <br/><br/>");
    //    sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
    //    sb.AppendLine("Details are Shown below : <br/><br/>");
    //    sb.AppendLine("<table class=gridtable>");

    //    sql = "jct_ops_yarn_mail_content ";
    //    cmd = new SqlCommand(sql, con);

    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@Requestid", SqlDbType.VarChar, 10).Value = ViewState["requestID"].ToString();
    //    Dr = cmd.ExecuteReader();
    //    if ((Dr.HasRows))
    //    {
    //        while ((Dr.Read()))
    //        {

    //            sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
    //            sb.AppendLine("<tr><td colspan='4'> GENERAL MANAGER - MARKETING</td></tr> ");
    //            sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED DYED FABRIC</td> </tr>");
    //            sb.AppendLine("<tr><td> CONSTRUCTION</td>  <td>   </tr>");
    //            sb.AppendLine("<tr><td>requestID </td> <td>" + Dr["requestid"].ToString() + "</td>  </tr>");
    //            sb.AppendLine("<tr><td>Purchase By </td> <td>" + Dr["purchaseby"].ToString() + "</td>  </tr>");
    //            sb.AppendLine("<tr><td>Sort no <td> " + Dr["SortNo"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr><td>Quality</td><td>" + Dr["Quality"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr> <td>SaleOrder</td><td> " + Dr["SaleOrder"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr> <td>ReqQty</td><td> " + Dr["ReqQty"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr> <td>YarnReq</td><td> " + Dr["YarnReq"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr><td>Actual(count/Denier)</td><td>" + Dr["Actual(count/Denier)"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr> <td>Blend%</td> <td> " + Dr["Blend %"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr><td>ClassimateFaults</td><td>" + Dr["ClassimateFaults"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr> <td>AllFaults</td><td> " + Dr["AllFaults"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr><td> MajorShortThick</td><td> " + Dr["MajorShortThick"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr><td> ShortThick</td><td>" + Dr["ShortThick"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr> <td>MajorThin</td> <td> " + Dr["MajorThin"].ToString() + "</td> </tr>");
    //            sb.AppendLine("<tr> <td>Plant</td><td> " + Dr["plant"].ToString() + "</td> </tr>");




    //        }
    //    }

    //    Dr.Close();
    //    con.Close();
    //    sb.AppendLine("</table>");

    //    sb.AppendLine("<br /><br/>");

    //    sb.Append("<a href='http://misdev/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details and authorize the request...!! </a><br />");

    //    sb.AppendLine("</table><br />");

    //    sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
    //    sb.AppendLine("Thank you<br />");
    //    sb.AppendLine("</html>");


    //    body = sb.ToString();
    //    @from = "noreply@jctltd.com";

    //    to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString();

    //    bcc = "shwetaloria@jctltd.com";
    //    subject = "Outsourced Yarn Request - " + ViewState["requestID"];
    //    MailMessage mail = new MailMessage();
    //    mail.From = new MailAddress(@from);
    //    if (to.Contains(","))
    //    {
    //        string[] tos = to.Split(',');
    //        for (int i = 0; i <= tos.Length - 1; i++)
    //        {
    //            mail.To.Add(new MailAddress(tos[i]));
    //        }
    //    }
    //    else
    //    {
    //        mail.To.Add(new MailAddress(to));
    //    }

    //    if (!string.IsNullOrEmpty(bcc))
    //    {
    //        if (bcc.Contains(","))
    //        {
    //            string[] bccs = bcc.Split(',');
    //            for (int i = 0; i <= bccs.Length - 1; i++)
    //            {
    //                mail.Bcc.Add(new MailAddress(bccs[i]));
    //            }
    //        }
    //        else
    //        {
    //            mail.Bcc.Add(new MailAddress(bcc));
    //        }
    //    }
    //    //If Not String.IsNullOrEmpty(cc) Then
    //    //    If cc.Contains(",") Then
    //    //        Dim ccs As String() = cc.Split(","c)
    //    //        For i As Integer = 0 To ccs.Length - 1
    //    //            mail.CC.Add(New MailAddress(ccs(i)))
    //    //        Next
    //    //    Else
    //    //        mail.CC.Add(New MailAddress(bcc))
    //    //    End If
    //    //    mail.CC.Add(New MailAddress(cc))
    //    //End If

    //    mail.Subject = subject;
    //    mail.Body = body;
    //    mail.IsBodyHtml = true;
    //    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //    SmtpClient SmtpMail = new SmtpClient("exchange2007");

    //    //SmtpMail.SmtpServer = "exchange2007";
    //    SmtpMail.Send(mail);




    //}

    private void sendmailVendor()
    {
        try
        {
            string sql = string.Empty;
            string to = string.Empty;
            string from = string.Empty;
            string bcc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;

            sql = "jct_ops_fab_vendor_freeze_mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    to = dr["sendtomail"].ToString();
                    body = dr["email_body"].ToString();
                    subject = dr["subject"].ToString();
                }
            }
            else
            {

            }

            @from = "Outsourcing@jctltd.com";

            bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";

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

            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("exchange2007");
            SmtpMail.Send(mail);
        }
        catch
        {

        }
    }

    protected void lnkreject_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow rw in grdDetail2.Rows)
        {
            SqlCommand cmd = new SqlCommand("jct_ops_yarn_apprvals_rej", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = rw.Cells[1].Text;
            cmd.Parameters.Add("@approveby", SqlDbType.Int).Value = Session["Empcode"];
            cmd.Parameters.Add("@vendernamre", SqlDbType.Int).Value = rw.Cells[2].Text;
            cmd.Parameters.Add("@approveRmk", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
            cmd.ExecuteNonQuery();

            con.Close();
            sendmailVendor();
            //SendMailYarn();
            string script = "alert('Yarn Vendors Rejected !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;
            ViewState["Plant"] = grdDetail.DataKeys[grdDetail.SelectedIndex].Value;


            SqlCommand cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON", conjctgen);
            cmd.CommandType = CommandType.StoredProcedure;
            conjctgen.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail2.DataSource = ds.Tables[0];
            grdDetail2.DataBind();
            conjctgen.Close();

            cmd = new SqlCommand("select distinct vendername from jct_ops_yarn_mat_tb  where requestid=@requestid", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;


            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            chklist.DataSource = ds.Tables[0];

            chklist.DataTextField = "vendername";
            chklist.DataValueField = "vendername";
            chklist.DataBind();

            con.Close();

            lbcomp.Visible = true;
            lbvendlst.Visible = true;

            //string sql = "select isnull(a.status_log,'') as status_log from jct_ops_yarn_purchase a where a.requestid='" + grdDetail.SelectedRow.Cells[1].Text + "'";
            //string status_log = obj1.FetchValue(sql).ToString();
            //if (status_log == "RMAuth")
            //{
            //    chklist.Enabled = false;
            //}
            //else if (status_log == "FinalAuth")
            //{
            //    chklist.Enabled = true;
            //}
            //else if (status_log == "FinalCancel")
            //{
            //    chklist.Enabled = false;
            //}
            //else
            //{

            //}

            for (int i = 0; i <= chklist.Items.Count - 1; i++)
            {
                string vndrlist;
                vndrlist = chklist.Items[i].Text;
                cmd = new SqlCommand("jct_ops_yarn_vndr_list", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
                cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 10).Value = vndrlist;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                con.Close();
                string output = cmd.Parameters["@flag"].Value.ToString();
                if (output == "1")
                {
                    chklist.Items[i].Selected = true;
                }

            }
        }
        catch
        { 
        
        }
       
    }

    private void sendmail()
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

            subject = "Outsource Yarn Request " + ViewState["RequestID"];
            //querystring = "RequestID=" + ViewState["RequestID"];
            querystring = "EmpCode=" + Session["EmpCode"].ToString() + ",RequestID=" + ViewState["RequestID"];

            //url = "http://localhost:4297/FusionApps1/OPS/MailContentPages/outsource_vendor_comparison.aspx?" + querystring;
            //url = "http://misdev/FusionApps/OPS/MailContentPages/outsource_vendor_comparison.aspx?" + querystring;

            url = "http://misdev/FusionApps/OPS/MailContentPages/outsource_vendor_comparison.aspx?" + querystring;

            @from = "Outsourcing@jctltd.com";
             
            sql = "SELECT b.E_MailID FROM dbo.jct_ops_yarn_purchase a INNER JOIN dbo.MISTEL b ON a.usercode=b.empcode WHERE a.RequestID='"+ ViewState["RequestID"] +"' AND status='F'";
            try
            {
                to = obj1.FetchValue(sql).ToString();
            }
            catch { to = ""; return; }

            //to = "jatindutta@jctltd.com";
            //bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
            bcc = "jatindutta@jctltd.com,shwetaloria@jctltd.com,rajan@jctltd.com,rbaksshi@jctltd.com";
            cc = "laxman@jctltd.com,arvindsharma@jctltd.com,dpbadhwar@jctltd.com";

            string Body = GetPage(url);//GetPage("http://misdev/FusionApps/OPS/AuthorizationRemarks.aspx");

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
            SmtpClient SmtpMail = new SmtpClient("exchange2007");
            SmtpMail.Send(mail);
        }
        catch(Exception ex)
        {
            lblError.Text = "Error : " + ex.Message;
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

        //currentPageUrl = currentPageUrl.Replace("http://localhost:4297/FusionApps1/OPS/yarn_approvals.aspx", page_name);

        //currentPageUrl = currentPageUrl.Replace("http://misdev/FusionApps/OPS/yarn_approvals.aspx", page_name);

        currentPageUrl = page_name;

        UTF8Encoding utf8 = new UTF8Encoding();

        requestHTML = myclient.DownloadData(currentPageUrl);
        myPageHTML = utf8.GetString(requestHTML);

        //Response.Write(myPageHTML)

        return myPageHTML;

    }
}
