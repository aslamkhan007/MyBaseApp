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

public partial class OPS_po_outsorced : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["test"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void fetch_Click(object sender, EventArgs e)
    {
      
        SqlCommand cmd = new SqlCommand("jct_ops_rm_rcvd_outsorc_material_select", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdatefrm.Text);

        cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = Convert.ToDateTime(txttodate.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Lnkapply.Visible = true;

    }
    protected void Lnkapply_Click(object sender, EventArgs e)
    {



        SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["test"].ConnectionString);
        SqlCommand cmd = new SqlCommand("jct_ops_rm_rcvd_outsorc_material_insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        foreach (GridViewRow rw in grdDetail.Rows)
        {
            TextBox txtchno = (TextBox)rw.FindControl("txtchallanno");
            TextBox txtchdt = (TextBox)rw.FindControl("txtchallandt");
            TextBox txtaltsort = (TextBox)rw.FindControl("txtaltersort");
            TextBox txtsort = (TextBox)rw.FindControl("txtSortno");
            TextBox txtmtr = (TextBox)rw.FindControl("txtmtr");
            TextBox txtshrtage = (TextBox)rw.FindControl("txtShortage");
            TextBox txthook = (TextBox)rw.FindControl("txtHook");
            TextBox txtreject = (TextBox)rw.FindControl("txtrejct");
            TextBox txtremrks = (TextBox)rw.FindControl("txtremarks");
            if (txtchdt.Text != string.Empty)
            {

                cmd.Parameters.Add("@challan_no", SqlDbType.VarChar, 20).Value = txtchno.Text;
                cmd.Parameters.Add("@challan_dt ", SqlDbType.DateTime).Value = Convert.ToDateTime(txtchdt.Text);
                cmd.Parameters.Add("@alternate_sort", SqlDbType.VarChar, 20).Value = txtaltsort.Text;
                cmd.Parameters.Add("@mtr_ok ", SqlDbType.VarChar, 20).Value = txtmtr.Text;
                cmd.Parameters.Add("@Shortage ", SqlDbType.VarChar, 20).Value = txtshrtage.Text;
                cmd.Parameters.Add("@hooktom", SqlDbType.VarChar, 20).Value = txthook.Text;
                cmd.Parameters.Add("@Rejection", SqlDbType.VarChar, 20).Value = txtreject.Text;
                cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Value = txtremrks.Text;
                cmd.Parameters.Add("@sort_no", SqlDbType.VarChar, 100).Value = txtsort.Text;
                cmd.Parameters.Add("@unloadNo", SqlDbType.Char, 18).Value = rw.Cells[14].Text;
                cmd.Parameters.Add("@entryno", SqlDbType.SmallInt).Value = rw.Cells[16].Text;

                cmd.ExecuteNonQuery();
                con.Close();
                sendmail();
            }


        }



    }

    private void sendmail()
    {

        string from, to, subject, body;
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");
        // sb.Append("<head>");
        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Outsourced Material Recieved: <br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");


        //sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
        //sb.AppendLine("<tr><td> stockName</td><td> VendotNamw </td><td> QtyRecieved </td><td>Approved </td><td> Unapproved </td></tr> ");
        sb.AppendLine("<tr><th rowspan=2> StockName </th> <th rowspan=2>Vendor</th><th rowspan=2>Qty Recieved </th> <th rowspan=2> Approved mtr</th> <th colspan=3> Unapproved</th> </tr>");
        sb.AppendLine("<tr><th>Shortage</th><th>HookTom</th><th>Rejection</th> </tr>");
        foreach (GridViewRow rw in grdDetail.Rows)
        {
            TextBox txtchno = (TextBox)rw.FindControl("txtchallanno");
            TextBox txtchdt = (TextBox)rw.FindControl("txtchallandt");
            TextBox txtaltsort = (TextBox)rw.FindControl("txtaltersort");
            TextBox txtsort = (TextBox)rw.FindControl("txtSortno");
            TextBox txtmtr = (TextBox)rw.FindControl("txtmtr");
            TextBox txtshrtage = (TextBox)rw.FindControl("txtShortage");
            TextBox txthook = (TextBox)rw.FindControl("txtHook");
            TextBox txtreject = (TextBox)rw.FindControl("txtrejct");
            TextBox txtremrks = (TextBox)rw.FindControl("txtremarks");

            String vendr = rw.Cells[1].Text;
            String qtyrcvd = rw.Cells[5].Text;
            String stockname = rw.Cells[0].Text;

            if(txtaltsort.Text != "" || txtchdt.Text != "" || txtchno.Text!= ""  || txthook.Text !="" || txtmtr.Text!= "" || txtreject.Text!="" ||txtremrks.Text!=""|| txtshrtage.Text!="" ||txtsort.Text!="" )
           
            sb.AppendLine(" <tr><td>" + stockname + "</td><td>" + vendr + "</td><td> " + qtyrcvd + "</td> <td>" + txtmtr.Text + "</td><td>" + txtshrtage.Text + " </td><td>" + txthook.Text + " </td> <td>" + txtreject.Text + " </td></tr>");
            //   sb.AppendLine("<tr><td align='center' colspan='3'><td> Mtr ok</td><td> Shortage </td><td>HookTom</td><td> Rejection</td></tr> ");
            //sb.AppendLine("<tr><td> "+ stockname +"</td><td> "+ vendr +" </td><td>   " + qtyrcvd + "</td><td align='center' colspan='2 '><td></tr> ");
            //   sb.AppendLine("<tr><td align='center' colspan='3'><td> Mtr ok</td><td> Shortage </td><td>HookTom</td><td> Rejection</td></tr> ");
        }

            sb.AppendLine("</table>");
            sb.AppendLine("<br />");

            //dr.Close();
            sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. <br />");
            sb.AppendLine("Thank you<br />");
            sb.AppendLine("</html>");
        
          
            //return mail;

        
        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        to = "shwetaloria@jctltd.com";
        //to = "pkchhabra@jctltd.com,dpbadhwar@jctltd.com,skpalta@jctltd.com,rajgopal@jctltd.com";
        subject = "outsourced Material Recieved ";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
        mail.To.Add(new MailAddress(to));
        mail = new MailMessage();
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

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    //    sendmail();

    }
}
