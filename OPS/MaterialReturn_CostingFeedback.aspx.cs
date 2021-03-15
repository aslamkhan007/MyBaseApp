using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Text;

public partial class OPS_MaterialReturn_CostingFeedback : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    Functions objFun = new Functions();
    String sql;
    string script;
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"].ToString() == "")
        {
            Response.Redirect("~/login.aspx");
        }
        gridbind();
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack == true)
        {
            gridbind();
        }
    }
    protected void cmdApply_Click(object sender, EventArgs e)
    {
        ViewState["SanctionID"] = grdDetail.SelectedRow.Cells[1].Text;

        try
        {
            sql = "Jct_opS_MR_Costing_Feedback_Insert '" + Session["empcode"] + "','" + grdDetail.SelectedRow.Cells[1].Text + "'," + Convert.ToDouble(txtRefinishLoss.Text) + "," + Convert.ToDouble(txtRefinishMtrs.Text) + "," + Convert.ToDouble(txttotalloss.Text) + ",'" + txtRemarks.Text + "','" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "' ";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.ExecuteNonQuery();

            script = "alert('Feedback Updated..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            gridbind();
            grdFoldingObservation.DataSource = null;
            grdFoldingObservation.DataBind();
            grdFoldingObservation.Visible = false;
            txtRefinishLoss.Text = "";
            txtRefinishMtrs.Text = "";
            txttotalloss.Text = "";
            txtRemarks.Text = "";
            SendMail(grdDetail.SelectedRow.Cells[1].Text);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message.ToString() + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    public void gridbind()
    {
        grdDetail.DataSource = null;
        grdDetail.DataBind();
        sql = "exec Jct_Ops_MR_Costing_Pending_Authorization_Fetch";
        obj1.FillGrid(sql, ref grdDetail);

    }
    private void SendMail(String sanctionNoteID)
    {
        string from, to, bcc, cc, subject, body;
        body = string.Empty;
        subject = "Material Return Costing Feedback against ID :-" + sanctionNoteID;
        from = "noreply@jctltd.com";   //Email Address of Sender

        string NotifyEmailGroup = "hitesh@jctltd.com";
        string RaisedByMail = string.Empty;
        //qry = "SELECT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='1590'";
        cmd = new SqlCommand("Jct_MrClosure_Notify_Users", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        //cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];
        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = grdDetail.SelectedRow.Cells[1].Text;

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                if (dr[1].ToString() == "UserType")
                { RaisedByMail = dr[0].ToString(); }
                NotifyEmailGroup = NotifyEmailGroup + "," + dr[0];
            }
        }
        dr.Close();



        string Genratedby_Email = string.Empty;
        sql = "SELECT E_MailID FROM  mistel  WHERE  empcode  = '" + Session["EmpCode"].ToString() + "' ";
        cmd = new SqlCommand(sql, obj.Connection());
        dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                Genratedby_Email = dr[0].ToString();
            }
        }
        dr.Close();
        //to = RaisedByMail;
        //cc = NotifyEmailGroup + "," + Genratedby_Email;
        to = RaisedByMail;
       


        sendmail(Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "hitesh@jctltd.com,hiren@jctltd.com,sandeepr@jctltd.com");




    }


    public void sendmail(string SalesPerson_Email, string too, string NotifyEmailGroup, string bccc)
    {
        //SalesPerson_Email = "sandeepr@jctltd.com";
        //too = "hiren@jctltd.com";
        //NotifyEmailGroup = "sandeepr@jctltd.com";
        //bccc = "sandeepr@jctltd.com";

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

                subject = "Costing FeedBack";

                querystring = "SanctionID=" + ViewState["SanctionID"];
                querystring1 = Session["Empcode"].ToString();


            }


            url = " http://testerp/FusionApps/ops/MRCostingFeedBackMail.aspx?" + querystring + "&Empcode=" + querystring1;
           // url = "http://test2k/FusionApps/ops/MrFoldingObservationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;
         //   url = "http://testerp/FusionApps/ops/MrFoldingObservationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;





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
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
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

     

        return myPageHTML;

    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "exec Jct_Ops_Mr_Folding_ObservationFetch '" + grdDetail.SelectedRow.Cells[1].Text + "'";
        obj1.FillGrid(sql, ref grdFoldingObservation);
        StatusLabel.Text = "";
    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string status = string.Empty;
        string id = grdDetail.SelectedRow.Cells[1].Text;
        string Qry = string.Empty;
        if (id == null)
        {
            script = "alert('Please Select MR Number.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else
        {
            try
            {
                HttpPostedFile objHttpPostedFile = uploadProfilePic.PostedFile;
                string fileName = uploadProfilePic.PostedFile.FileName;

                string filepath = Server.MapPath("Upload\\MRCostingFeedBack\\");

                uploadProfilePic.SaveAs(filepath + " " + id + "-" + uploadProfilePic.FileName);

                fileName = " " + id + "-" + uploadProfilePic.FileName;
                Qry = "INSERT INTO Jct_ops_MRCostingFeedback_Attachments( RequestID ,ImgName ,STATUS ,UploadedOn) VALUES  ( '" + grdDetail.SelectedRow.Cells[1].Text + "','" + fileName + "','A',GETDATE()" + ")";
                cmd = new SqlCommand(Qry, obj.Connection());
                cmd.ExecuteNonQuery();
                status = uploadProfilePic.FileName;
                script = "alert('File Uploaded!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                StatusLabel.Text = StatusLabel.Text + "Upload Status : " + id + status + ",";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }

        }
    }
    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetail.PageIndex = e.NewPageIndex;
    }
}