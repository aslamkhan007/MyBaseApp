using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Text;
using Telerik.Web.UI;
using System.Net.Mail;

public partial class OPS_Authorize_Devlopment_Request : System.Web.UI.Page
{
    SqlCommand cmd;
    String qry;
    Connection obj = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ddlAuthorizationType.SelectedItem.Text == "Authorize Request")
            {
                RequiredFieldValidator1.Enabled = true;                
            }
            else
            {
                RequiredFieldValidator1.Enabled = false;                
            }
        }

    }
    protected void cmdApply_Click(object sender, EventArgs e)
    {
        SqlTransaction tran;
        string qry;
        String NextAuthPerson;
        NextAuthPerson = "";
        string script;
        if (RadGrid1.SelectedValue == null)
        {
            script = "alert('Please Select a valid RequestNo from the list .....');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

        SqlConnection con;
        con = obj.Connection();
        tran = con.BeginTransaction();
        try
        {

            String requestID;
            requestID = RadGrid1.SelectedValues["RequestID"].ToString();

            qry = "exec Jct_Ops_Devlopment_Request_Status_Update '" + ddlAuthorizationType.SelectedItem.Text + "','" + Session["Empcode"].ToString() + "','" + requestID + "','" + ddlAction.SelectedItem.Text + "','" + txtRemarks.Text + "','" + Request.ServerVariables["REMOTE_ADDR"] + "'";
            // @Parameter,@Usercode,@RequestID ,@Action,@Remarks"
            cmd = new SqlCommand("Jct_Ops_Devlopment_Request_Status_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = tran;

            cmd.Parameters.AddWithValue("@Parameter", ddlAuthorizationType.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Usercode", Session["Empcode"].ToString());
            cmd.Parameters.AddWithValue("@RequestID", requestID);
            cmd.Parameters.AddWithValue("@Action", ddlAction.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
            cmd.Parameters.AddWithValue("@HostIPAddr", Request.ServerVariables["REMOTE_ADDR"]);
            //SqlParameter NxtAuthEmp;
            //NxtAuthEmp = cmd.Parameters.Add("@NxtAuthEmp", SqlDbType.VarChar);
            //NxtAuthEmp.Size = 1000;
            cmd.Parameters.Add("@NxtAuthEmp", SqlDbType.VarChar, 1000);
            cmd.Parameters["@NxtAuthEmp"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            NextAuthPerson = cmd.Parameters["@NxtAuthEmp"].Value.ToString();
            //tran.rollback();
            tran.Commit();
            script = "alert('Your Request No :-" + requestID + " is " + ddlAction.SelectedItem.Text + " ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            try
            {
                Sendmail1(RadGrid1.SelectedValues["RequestID"].ToString(), "ashish@jctltd.com", NextAuthPerson);
                //string script = "alert('Message " + s.Substring(s.IndexOf("~") + 1, (s.IndexOf("!") - 2) - s.IndexOf("~") + 1) + "   ok' );";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            catch (Exception ex1)
            {
                script = "alert('Unable to Deliver E-Mail .....');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        catch (Exception ex)
        {
            script = "alert('Record Cannot be Saved...Please Try Again...  ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            tran.Rollback();

        }
        RadGrid1.Rebind();

    }
    protected void ddlAuthorizationType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {


        if (ddlAuthorizationType.SelectedItem.Text == "Authorize Request")
        {

            ddlAction.Items.Clear();
            Telerik.Web.UI.RadComboBoxItem Li = new Telerik.Web.UI.RadComboBoxItem();

            Li.Value = "Authorize";
            Li.Text = "Authorize";
            ddlAction.Items.Add(Li);
            Li = new Telerik.Web.UI.RadComboBoxItem();
            Li.Value = "Cancel";
            Li.Text = "Cancel";
            ddlAction.Items.Add(Li);
            RequiredFieldValidator1.Enabled = true;
            //RequiredFieldValidator1.
        }
        else
        {
            RequiredFieldValidator1.Enabled = false;
            ddlAction.Items.Clear();
            Telerik.Web.UI.RadComboBoxItem Li = new Telerik.Web.UI.RadComboBoxItem();
            Li.Value = "Accept";
            Li.Text = "Accept";
            ddlAction.Items.Add(Li);
            Li = new Telerik.Web.UI.RadComboBoxItem();
            Li.Value = "Reject";
            Li.Text = "Reject";
            ddlAction.Items.Add(Li);
        }
    }

    protected void Sendmail1(string transID, string sendMailTo, String requestDEtail)
    {
        string from, to, subject, body, bcc, cc;
        bcc = "ashish@jctltd.com,rbaksshi@jctltd.com";
        from = "Devlopment@jctltd.com";
        //requestDEtail.Substring(requestDEtail.IndexOf("~"), requestDEtail.IndexOf("MailTo"));

        cc = requestDEtail.Substring(requestDEtail.IndexOf("~") + 1, (requestDEtail.IndexOf("!") - 2) - requestDEtail.IndexOf("~") + 1); //Put the user in CC field
        //to = sendMailTo;
        to = requestDEtail.Substring(requestDEtail.IndexOf("*") + 1, requestDEtail.Length - requestDEtail.IndexOf("*") - 1);//, (requestDEtail.IndexOf("!")-2) - requestDEtail.IndexOf("~")+1) //Retreive To list
        subject = "Request No:- " + transID + " has been  " + ddlAuthorizationType.SelectedItem.Text;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<html>");


        sb.AppendLine("<head>");
        sb.AppendLine("<b> Hello..... </B><br/><br/>");
        sb.AppendLine("Category <B>" + ddlAuthorizationType.SelectedItem.Text + "</B><br/><br/>");
        sb.AppendLine("Request ID <B>" + RadGrid1.SelectedValues["RequestID"].ToString() + "</B> has been <B>" + ddlAction.SelectedItem.Text + " </B><br/><br/>");
        sb.AppendLine("" + requestDEtail.Substring(0, requestDEtail.IndexOf("~")));


        //sb.AppendLine("<h5>Action Taken " +  ddlAction.SelectedItem.Text + "  </h5><br>");
        //sb.AppendLine("<h3>Devlopment Request No " + RadGrid1.SelectedValues["RequestID"].ToString() + " has been " + ddlAction.SelectedItem.Text + "  </h3><br>");

        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");


        sb.AppendLine("Request contains the following details:- <br/><br/>");




        //sb.AppendLine("<head>");
        //sb.AppendLine("<style type=\"text/css\">");
        //sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        //sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        //sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        //sb.AppendLine("</style>");
        sb.AppendLine("</head>");


        sb.AppendLine("<table class=gridtable>");
        string GridHeader = "";
        string Q = "";
        Int16 J = 0;
        //Int16 i= 0;
        string body1 = "";
        SqlDataReader dr;
        //var _with1 = GrdSanctionNoteDetail;

        //RadGrid1.
        //foreach(GridDataItem grditem in RadGrid1.Items)
        //{
        //}




        GridHeader += "<tr><th>RequestID</th>";
        GridHeader += "<th>RequestedBy</th>";
        GridHeader += "<th>DESCRIPTION</th>";
        GridHeader += "<th>ProspectCust</th>";
        GridHeader += "<th>ProspectCustName</th>";
        GridHeader += "<th>SortNo</th>";
        GridHeader += "<th>Finish</th>";
        GridHeader += "<th>No Of Shades</th>";
        GridHeader += "<th>EndUse</th>";

        GridHeader += "<th>Segment</th>";

        GridHeader += "<th>Devlopment</th>";

        GridHeader += "<th>EnquiryNo</th>";

        GridHeader += "<th>DevlopmentNo</th>";
        GridHeader += "<th>RequiredOn</th></tr>";
        qry = "exec Jct_Ops_Get_Devlopment_Request '" + ddlAuthorizationType.SelectedItem.Text + "','" + Session["Empcode"] + "'," + Convert.ToInt32(RadGrid1.SelectedValues["RequestID"].ToString()) + "";
        cmd = new SqlCommand(qry, obj.Connection());
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            GridHeader += "<tr><td> " + dr["RequestID"].ToString() + "</td>";
            GridHeader += "<td> " + dr["RequestedBy"].ToString() + "</td>";
            GridHeader += "<td> " + dr["DESCRIPTION"].ToString() + "</td>";
            GridHeader += "<td> " + dr["ProspectCust"].ToString() + "</td>";
            GridHeader += "<td> " + dr["ProspectCustName"].ToString() + "</td>";
            GridHeader += "<td> " + dr["SortNo"].ToString() + "</td>";
            GridHeader += "<td> " + dr["Finish"].ToString() + "</td>";
            GridHeader += "<td> " + dr["no_of_shades"].ToString() + "</td>";
            GridHeader += "<td> " + dr["EndUse"].ToString() + "</td>";
            GridHeader += "<td> " + dr["Segment"].ToString() + "</td>";
            GridHeader += "<td> " + dr["Devlopment"].ToString() + "</td>";
            GridHeader += "<td> " + dr["EnquiryNo"].ToString() + "</td>";
            GridHeader += "<td> " + dr["DevlopmentNo"].ToString() + "</td>";
            GridHeader += "<td> " + dr["RequiredOn"].ToString() + "</td></tr>";
        }
        dr.Close();

        body1 = body1 + GridHeader + " </tr>";


        ////This loops feteches data from each cell of grid
        ////.Columns.Count
        //for (J = 0; J <= 1; J++)
        //{
        //    if (i == 0)
        //    {
        //        //query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
        //        GridHeader += "<th> " + GrdSanctionNoteDetail.HeaderRow.Cells(J).Text + "</th>";
        //    }
        //    Q += "<td>" + GrdSanctionNoteDetail.Rows(i).Cells(J).Text + "</td>";
        //}
        body1 = body1 + Q + " </tr>";


        sb.AppendLine("" + body1);
        //Sb.AppendLine("<table class=gridtable>")
        //Sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



        sb.AppendLine("</table>");
        sb.AppendLine("<br/><br/>");

        sb.AppendLine("With Remakrs :- <b>" + txtRemarks.Text + "</b>");

        sb.AppendLine("<br /><br/>");
        sb.Append("<a href='http://misdev/fusionapps/OPS/Authorize_Devlopment_Request.aspx'> Click here to view detail... </a><br /><br/>");

        //sb.AppendLine("</table><br /><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");
        body = sb.ToString();

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
        mail.To.Add(new MailAddress(to));
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

        if (!string.IsNullOrEmpty(cc))
        {
            if (cc.Contains(","))
            {
                string[] ccs = cc.Split(',');
                for (int i = 0; i <= ccs.Length - 1; i++)
                {
                    //mail.cc.Add(new MailAddress(ccs[i]));
                    mail.CC.Add(new MailAddress(ccs[i]));
                }
            }
            else
            {
                mail.CC.Add(new MailAddress(cc));
            }
        }


        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;



        string script = "alert('Mail Sent sucessfully.!! Please check your Inbox ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        return;
    }
    protected void cmdApply0_Click(object sender, EventArgs e)
    {
        String s;
        s = "The Devlopment Request no <b> 7052 </b>  has been Authorized By <b> MR RAJEEV BAKSSHI~RBaksshi@jctltd.com! MailTo  ^ashish@jctltd.com,jagdeep@jctltd.com,RBaksshi@jctltd.com";

        Sendmail1(RadGrid1.SelectedValues["RequestID"].ToString(), "ashish@jctltd.com", s);
        string script = "alert('Message " + s.Substring(s.IndexOf("~") + 1, (s.IndexOf("!") - 2) - s.IndexOf("~") + 1) + "   ok' );";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
}