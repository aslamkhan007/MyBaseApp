using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using System.Net.Mail;
using System.Net;
public partial class Courier_Tracking_System_Cancel_Courier_Pending_Request : System.Web.UI.Page
{
    string sql = string.Empty;
    string script = string.Empty;
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            ViewState["ID"] = Request.QueryString["CourierID"].ToString();
            bindHeader();
        }
        
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_COURIER_CANCEL_PENDING_REQ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = ViewState["ID"];
            cmd.Parameters.Add("@Cancel_Remarks", SqlDbType.VarChar, 600).Value = txtReasonForCancel.Text;
            cmd.Parameters.Add("@CancelForCourierId", SqlDbType.VarChar, 20).Value = txtOriginalCourierID.Text;
            cmd.Parameters.Add("@Cancel_Standard_reason", SqlDbType.VarChar, 50).Value = ddlCancelReason.SelectedItem.Text;
            cmd.Parameters.Add("@Cancel_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"];   
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

            cmd.ExecuteNonQuery();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('" + ViewState["ID"] + " Cancelled successfully')", true);

            string msg = "alert('Request " + ViewState["ID"] + " Cancelled Successfully.');window.location ='Search_Courier_Pending_Request.aspx';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", msg, true);

            sendmail();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    public void bindHeader()
    {
        try
        {
            sql = "JCT_COURIER_Courier_Id_Detail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@COURIERID", SqlDbType.VarChar, 20).Value = ViewState["ID"];
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    courierid.Text = dr["Serial_No"].ToString();
                    partyname.Text = dr["Party_Name"].ToString();
                    courierType.Text = dr["Courier_Service"].ToString();
                    Deliverytype.Text = dr["Delivery_Type"].ToString();
                    Requestby.Text = dr["Request_By"].ToString();
                    Address.Text = dr["Address"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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
            querystring = "SerialNo=" + ViewState["ID"];
            string Cancel_By = string.Empty;
                 
            sql = ("Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = '" + Session["Empcode"].ToString() + "' ");
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cancel_By = dr[0].ToString();
                }
            }
            dr.Close();

            //url = "http://localhost:4055/FusionApps/Courier Tracking System/Cancel_Pending_Courier_mail.aspx?" + querystring ;

            //url = "http://test2k/FusionApps/Courier Tracking System/Cancel_Pending_Courier_mail.aspx?" + querystring;

            url = "http://testerp/FusionApps/Courier Tracking System/Cancel_Pending_Courier_mail.aspx?" + querystring;
          
            @from = "noreply@jctltd.com";
            subject = "Pending Courier Request Cancelled With Courier ID '" + ViewState["ID"] + "' at '"+System.DateTime.Now+"' ";
            //to = "aslam@jctltd.com,ashish@jctltd.com,shwetaloria@jctltd.com";
            to = Cancel_By;
            //bcc = "aslam@jctltd.com,ashish@jctltd.com,shwetaloria@jctltd.com";
            bcc = "aslam@jctltd.com,ashish@jctltd.com,shwetaloria@jctltd.com";
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

        //Response.Write(myPageHTML);

        return myPageHTML;

    }

    protected void imb_close_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Search_Courier_Pending_Request.aspx");
    }
    protected void imgPreviewReport_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Cancelled_Courier_Pending_Request.aspx");
    }
}