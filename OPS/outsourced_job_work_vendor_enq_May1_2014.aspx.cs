using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;


public partial class OPS_outsourced_job_work_vendor_enq : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_select_vendor", con);
        con.Open();

        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();


        
       
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_vendor_enq_insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 20).Value = lbid.Text;
        cmd.Parameters.Add("@entrdby", SqlDbType.VarChar, 20).Value = "s-13823";//Session["empcode"];
        //cmd.Parameters.Add("@Vendorname ", SqlDbType.VarChar, 50).Value = txtvendor.Text;
        if (txtvendor.Text.Contains('~'))
        {
            cmd.Parameters.Add("@Vendorname", SqlDbType.VarChar, 200).Value = txtvendor.Text.Split('~')[0];
            cmd.Parameters.Add("@vendorcode", SqlDbType.VarChar, 10).Value = txtvendor.Text.Split('~')[1] == "" ? "" : txtvendor.Text.Split('~')[1];
        }
        else
        {
            cmd.Parameters.Add("@Vendorname", SqlDbType.VarChar, 200).Value = txtvendor.Text;
            cmd.Parameters.Add("@vendorcode", SqlDbType.VarChar, 10).Value = "";
        }

        cmd.Parameters.Add("@rate", SqlDbType.VarChar, 20).Value = txtrate.Text;
        cmd.Parameters.Add("@uom", SqlDbType.VarChar, 20).Value = ddluom.SelectedItem.Text;
        cmd.Parameters.Add("@consumption", SqlDbType.VarChar, 20).Value = txtconsumption.Text;
        cmd.Parameters.Add("@waste", SqlDbType.VarChar, 20).Value = txtwaste.Text;
        cmd.Parameters.Add("@agent", SqlDbType.VarChar, 30).Value = txtagent.Text;
        cmd.Parameters.Add("@validationDate", SqlDbType.DateTime).Value = txtvaliddate.Text;
        cmd.Parameters.Add("@producttype", SqlDbType.VarChar, 20).Value = ddlproducttype.SelectedItem.Text;
        cmd.Parameters.Add("@paymentterms", SqlDbType.VarChar, 100).Value = txtpayterms.Text;
        cmd.Parameters.Add("@deliverydt", SqlDbType.DateTime).Value = txtdeliverydate.Text;
        cmd.Parameters.Add("@packingdetail", SqlDbType.VarChar, 20).Value = ddlpacking.SelectedItem.Text;
        cmd.Parameters.Add("@jobcharges", SqlDbType.VarChar, 20).Value = txtjobchrg.Text;
        cmd.Parameters.Add("@freightcharges", SqlDbType.VarChar, 20).Value = ddlfreight.SelectedItem.Text;
        cmd.Parameters.Add("@wastequantity", SqlDbType.Decimal, 2).Value = txtwasteqty.Text;
       
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();


        string script2 = "alert(' record saved sucesfully.!!!  !! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        sendmail();

    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbreqid.Visible = true;
        lbid.Visible = true;
        lbid.Text = grdDetail.SelectedRow.Cells[1].Text;
        SqlCommand cmd = new SqlCommand("SELECT AVG(consumption) FROM jct_ops_outsourced_job_work WHERE ReqStatus='A' AND Reqid=@reqid ", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@reqid", SqlDbType.VarChar).Value = grdDetail.SelectedRow.Cells[1].Text;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        dr.Read();
        if (dr.HasRows == true)
        {
            string avgval;

            avgval = dr[0].ToString();
            txtconsumption.Text = avgval;
        }
        txtconsumption.Enabled = false;
        ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;

    }
    protected void txtwaste_TextChanged(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("SELECT SUM(CONVERT(NUMERIC(12,2),QtyReq)) FROM dbo.jct_ops_outsourced_job_work WHERE ReqStatus='A' AND Reqid=@reqid", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@reqid", SqlDbType.VarChar).Value = grdDetail.SelectedRow.Cells[1].Text;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        dr.Read();
        if (dr.HasRows == true)
        {
            string cal;

            cal = dr[0].ToString();
            //string wastepercnt = txtwaste.Text;
            decimal wasteqty = (Convert.ToDecimal(txtwaste.Text) * (Convert.ToDecimal(cal))/100);
          
            txtwasteqty.Text = wasteqty.ToString();
            txtwasteqty.Enabled = false;

           
        }
    }



    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("outsourced_job_work_vendor_enq.aspx");
    }
    private void sendmail()
    {

        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;
        string By = string.Empty;

        string sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";

        SqlCommand cmd = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                ViewState["RequestBy"] = Dr["empname"].ToString();
                ViewState["RequestByEmail"] = Dr["email"].ToString();
            }
        }
        else
        {
            ViewState["RequestBy"] = "";
            ViewState["RequestByEmail"] = "jatindutta@jctltd.com";
        }

        Dr.Close();
        con.Close();
        sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode JOIN dbo.jct_ops_outsourced_job_work  c ON a.empcode=c.entryby where c.STATUS='A' AND c.Reqid=  '" + ViewState["RequestID"] + "'";


        cmd = new SqlCommand(sql, con);
        con.Open();
        Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                ViewState["By"] = Dr["empname"].ToString();
                ViewState["ByEmail"] = Dr["email"].ToString();
            }
        }
        else
        {
            ViewState["RequestBy"] = "";
            ViewState["RequestByEmail"] = "jatindutta@jctltd.com";
        }

        Dr.Close();
        con.Close();

      



        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");

        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Outsourced JobWork has been generated in OPS : " + ViewState["By"] + " <br/><br/>");

        sb.AppendLine("Job Work RequestID : " + ViewState["RequestID"] + "   <br/><br/>");
    
        sb.AppendLine("Vendors has been freezed by : " + ViewState["RequestBy"] + "<br/><br/>");
        sb.AppendLine("<tr><th> RequestID  </th> <th>Vendor</th> <th>Rate</th>  <th> DeliveryDate </th><th>consumption </th> <th>Jobcharges</th></tr> ");
        sql = "jct_ops_outsourced_jobwork_mail_content_vendor";
        cmd = new SqlCommand(sql, con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar).Value = ViewState["RequestID"];
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while ((Dr.Read()))
            {
                sb.AppendLine("<tr> <td>  " + Dr["reqid"].ToString() + " </td> <td>  " + Dr["Vendorname"].ToString() + " </td>  <td> " + Dr["rate"].ToString() + "</td>  <td> " + Dr["deliverydt"] + "</td>  <td> " + Dr["jobcharges"].ToString() + "</td></tr> ");

            }
        }

        //b.reqid,a.Vendorname,a.rate,a.deliverydt,a.consumption,a.jobcharges
        Dr.Close();
        con.Close();
     
       
        sb.AppendLine("Please Authorize the Request For PO Generation <br/><br/");
        sb.AppendLine("<br /><br/>");

      

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");

        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";

        to = "shwetaloria@jctltd.com,jatindutta@jctltd.com,rajan@jctltd.com";
        to =  ViewState["RequestByEmail"] + ","+ ViewState["ByEmail"] +",amit@jctltd.com";


        //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
        bcc = "shwetaloria@jctltd.com,jatindutta@jctltd.com,rajan@jctltd.com";
        subject = "Outsourced JobWork RequestID - " + ViewState["RequestID"];
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
        //If Not String.IsNullOrEmpty(cc) Then
        //    If cc.Contains(",") Then
        //        Dim ccs As String() = cc.Split(","c)
        //        For i As Integer = 0 To ccs.Length - 1
        //            mail.CC.Add(New MailAddress(ccs(i)))
        //        Next
        //    Else
        //        mail.CC.Add(New MailAddress(bcc))
        //    End If
        //    mail.CC.Add(New MailAddress(cc))
        //End If

        mail.Subject = subject;

        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;


    }
}