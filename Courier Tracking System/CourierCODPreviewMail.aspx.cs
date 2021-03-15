using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net.Mail;

public partial class Courier_Tracking_System_CourierCODPreviewMail : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string datefrom = Request.QueryString["from"];
            string dateto = Request.QueryString["to"];
            string awbno = Request.QueryString["awbno"];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
            sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
            sb.AppendLine("</style>");

            sb.AppendLine("</head>");
            sb.AppendLine("Hi,<br /><br />");
            sb.AppendLine("Forwarding the cheques received from the parties towards COD payment of yardages of fabrics sent to them through couriers as mentioned against each :- <br/><br/>");
            sb.AppendLine("Please refer below data for further detail : <br/><br/>");

            sb.AppendLine("<table class=gridtable>");
            sb.AppendLine("<tr><th> Invoice No</th> <th> AWBNo</th> <th>Carrier</th> <th>CheckNo</th> <th>Check Amount</th> <th>Check Date</th>  <th>Customer </th> <th>  Shipping </th> <th>Billing</th><th>Invoice/COD Amount</th></tr>");
        
            sql = "JCT_COURIER_COD_CASH_COLLECTION_SENDMAIL_DATA";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AWBNO", SqlDbType.VarChar, 50).Value = awbno;
            cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 50).Value = datefrom ;
            cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 50).Value = dateto ;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    sb.AppendLine("<tr><td>"+ dr["InvoiceNo"] +"</td> <td>"+ dr["AWBNo"] +"</td> <td>"+ dr["Carrier"] +"</td> <td>"+ dr["CheckNo"] +"</td> <td>"+ dr["CheckAmt"] +"</td> <td>"+ dr["CheckDate"] +"</td>  <td>"+ dr["Customer"] +" </td> <td> "+ dr["SHIP_TO_CUST"] +" </td> <td>"+ dr["BILL_TO_CUST"] +"</td><td>"+ dr["INVOICE_AMOUNT"] +"</td></tr>");   
                }
            }

            sb.AppendLine("</table><br />");

           
            //sql = "Select empname from jct_empmast_base where empcode ='"+ Session["EmpCode"] +"' and active='Y'";
            //string empname = obj1.FetchValue(sql).ToString();
            //sb.AppendLine("Detail Entered by "+ empname +" <br /><br />");

            sb.AppendLine("Please note the above cheques will be handed over to Mr Pushp Raj Jain,Asstt Manager ( Mktg),for onward submission to Accounts Deptt.for adjustment of their proceeds.<br /><br />");

            sb.AppendLine("Regards,<br /><br />");

            sb.AppendLine("This is a system generated mail, please do not reply.!!<br /><br />");

            sb.AppendLine("Thank You ..!!<br /><br />");
            sb.AppendLine("</html>");

            lblContent.Text = sb.ToString();
        }
    }

    protected void radbtnSendMail_Click(object sender, EventArgs e)
    {
        string script = "";

        if (chbEmailIDTo.Items.Count <= 0)
        {
            script = "alert('Please enter valid email address..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

        string body="",@from,bcc="";
        body = lblContent.Text ;
        @from = "noreply@jctltd.com";
        bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(@from);

        if (chbEmailIDTo.Items.Count > 0)
        {
            for (int i = 0; i <= chbEmailIDTo.Items.Count -1; i++)
            {
                mail.To.Add(new MailAddress(chbEmailIDTo.Items[i].Text));
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

        if (chbEmailIDCC.Items.Count > 0)
        {
            for (int i = 0; i <= chbEmailIDCC.Items.Count - 1; i++)
            {
                mail.To.Add(new MailAddress(chbEmailIDCC.Items[i].Text));
            }
        }

        mail.Subject = "Courier COD Cheques Received...!";
        mail.Body=body ;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");
        SmtpMail.Send(mail);

        script = "alert('Email Sent Successfully..!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);


    }

    

 
    protected void txtTo1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtTo1.Text = txtTo1.Text.Split('~')[2].ToString();
            sql = "Select e_mailid from mistel where empcode='" + txtTo1.Text + "'";
            txtTo1.Text = obj1.FetchValue(sql).ToString().Trim();
            if (!string.IsNullOrEmpty(txtTo1.Text))
            {
                chbEmailIDTo.Items.Add(txtTo1.Text);
            }
            else
            {
                string script = "alert('No Email address present.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
            for (int i = 0; i <= chbEmailIDTo.Items.Count - 1; i++)
            {
                chbEmailIDTo.Items[i].Selected = true;
            }
            txtTo1.Text = "";
            txtTo1.Focus();
        }
        catch (Exception ex)
        { }
    }
    protected void txtCC1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtCC1.Text = txtCC1.Text.Split('~')[2].ToString();
            sql = "Select e_mailid from mistel where empcode='" + txtCC1.Text + "'";
            txtCC1.Text = obj1.FetchValue(sql).ToString().Trim();
            if (!string.IsNullOrEmpty(txtCC1.Text))
            {
                chbEmailIDCC.Items.Add(txtCC1.Text);
            }
            else
            {
                string script = "alert('No Email address present.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }

            for (int i = 0; i <= chbEmailIDCC.Items.Count - 1; i++)
            {
                chbEmailIDCC.Items[i].Selected = true;
            }
            txtCC1.Text = "";
            txtCC1.Focus();
        }
        catch (Exception ex)
        { }
    }
    protected void chbEmailIDTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= chbEmailIDTo.Items.Count - 1; i++)
        {
            if (chbEmailIDTo.Items[i].Selected == false)
            {
                chbEmailIDTo.Items.RemoveAt(i);
            }
        }
    }
    protected void chbEmailIDCC_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= chbEmailIDCC.Items.Count - 1; i++)
        {
            if (chbEmailIDCC.Items[i].Selected == false)
            {
                chbEmailIDCC.Items.RemoveAt(i);
            }
        }
    }
}