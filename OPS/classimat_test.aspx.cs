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

public partial class OPS_classimat_test : System.Web.UI.Page
{
   // SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=Trainee;User ID=trainee ;password=trainee");
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        select();
     
    }
    protected void ADD_Click(object sender, EventArgs e)
    {
   
        SqlCommand cmd = new SqlCommand("jct_ops_classimat_insert", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = txtdate.Text;
        cmd.Parameters.Add("@userid", SqlDbType.VarChar, 10).Value = Session["empcode"];
        cmd.Parameters.Add("@Host_IP", SqlDbType.VarChar, 30).Value = Request.ServerVariables["REMOTE_ADDR"];
        cmd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
        cmd.Parameters.Add("@weight", SqlDbType.Decimal,4).Value = txtweight.Text;
        cmd.Parameters.Add("@length", SqlDbType.Decimal,4) .Value= txtlength.Text;
        cmd.Parameters.Add("@allfaultperkg", SqlDbType.Decimal,4).Value = txtallfault.Text;
        cmd.Parameters.Add("@majorshotthick", SqlDbType.Decimal,4).Value = txtmajorshot.Text;
        cmd.Parameters.Add("@longshotthick", SqlDbType.Decimal,4) .Value= txtlongthick.Text;
        cmd.Parameters.Add("@shortshotthick", SqlDbType.Decimal,4).Value = txtshortthick.Text;
        cmd.Parameters.Add("@thinfault", SqlDbType.Decimal, 4).Value = txtthinfault.Text;
        cmd.Parameters.Add("@majorthinfault", SqlDbType.Decimal, 4).Value = txtmajorthin.Text;
        cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 30).Value = txtremarks.Text;
        cmd.Parameters.Add("@machineno", SqlDbType.VarChar, 10).Value = txtmachine.Text;
        //con.Open();
        cmd.ExecuteNonQuery();
        //con.Close();
        select();
       
        

    }
    protected void reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("classimat_test.aspx");
    }
    protected void update_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_classimat_update", obj.Connection());
        
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = lbid.Text; 
        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = txtdate.Text;
        cmd.Parameters.Add("@userid", SqlDbType.VarChar, 10).Value = Session["empcode"];
        cmd.Parameters.Add("@Host_IP", SqlDbType.VarChar, 30).Value = Request.ServerVariables["REMOTE_ADDR"];
        cmd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
        cmd.Parameters.Add("@weight", SqlDbType.Decimal,9).Value = txtweight.Text;
        cmd.Parameters.Add("@length", SqlDbType.Decimal,9).Value = txtlength.Text;
        cmd.Parameters.Add("@allfaultperkg", SqlDbType.Decimal, 9).Value = txtallfault.Text;
        cmd.Parameters.Add("@majorshotthick", SqlDbType.Decimal,9).Value = txtmajorshot.Text;
        cmd.Parameters.Add("@longshotthick", SqlDbType.Decimal,9).Value = txtlongthick.Text;
        cmd.Parameters.Add("@shortshotthick", SqlDbType.Decimal,9).Value = txtshortthick.Text;
        cmd.Parameters.Add("@thinfault", SqlDbType.Decimal, 9).Value = txtthinfault.Text;
        cmd.Parameters.Add("@majorthinfault", SqlDbType.VarChar).Value = txtmajorthin.Text;
        cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 30).Value = txtremarks.Text;
        cmd.Parameters.Add("@machineno", SqlDbType.VarChar, 10).Value = txtmachine.Text;
        //con.Open();
        cmd.ExecuteNonQuery();
        //con.Close();
        select();



    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        


        txtallfault.Text = grdDetail.SelectedRow.Cells[7].Text;
        txtcount.Text = grdDetail.SelectedRow.Cells[1].Text;
        lbid.Text = grdDetail.SelectedRow.Cells[2].Text;
        txtdate.Text = grdDetail.SelectedRow.Cells[3].Text;
        txtlength.Text = grdDetail.SelectedRow.Cells[5].Text;
        txtlongthick.Text = grdDetail.SelectedRow.Cells[10].Text;
        txtmajorshot.Text = grdDetail.SelectedRow.Cells[8].Text;
        txtmajorthin.Text = grdDetail.SelectedRow.Cells[12].Text;
        txtshortthick.Text = grdDetail.SelectedRow.Cells[9].Text;
        txtsource.Text = grdDetail.SelectedRow.Cells[4].Text;
        txtweight.Text = grdDetail.SelectedRow.Cells[6].Text;
     
        txtremarks.Text =  grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");

        txtmachine.Text = grdDetail.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
        txtthinfault.Text = grdDetail.SelectedRow.Cells[11].Text;
        

    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_classimat_delete", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@userid", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = lbid.Text; 
        cmd.Parameters.Add("@Host_IP", SqlDbType.VarChar, 30).Value = Request.ServerVariables["REMOTE_ADDR"];
        //con.Open();
        cmd.ExecuteNonQuery();
        //con.Close();
        select();
 }
    private void  sendmail()
    {
        ////SqlCommand cmd = new SqlCommand("jct_ops_classimat_select", con);
        ////cmd.CommandType = CommandType.StoredProcedure;
        //SqlDataReader reader = cmd.ExecuteReader();
        //while (reader.Read())
        //{
        //    rollno = reader.GetInt32(0);
        //    name = reader.GetString(1);
        //   address = reader.GetString(2);
        //}

        //var fromAddress = "shwetaloria@jctltd.com";

        //var toAddress = "shwetaloria@jctltd.com";


        //string subject = "   ";
        //string body = "date: " + txtdate.Text + "\n";
        //body += "count: " + txtcount.Text + "\n";
        //body += "length: " + txtlength.Text+ "\n";
        //body += "longthick: \n" +txtlongthick.Text+ "\n";
        //body += "majorshot " + txtmajorshot.Text + "\n";
        //body += "remarks" + txtremarks.Text + "\n";
        //body += "shortthick" + txtshortthick.Text + "\n";
        //body += "source" + txtsource.Text + "\n";
        //body += "thinfault" + txtthinfault.Text + "\n";
        //body += "weight" + txtweight.Text + "\n";
        //body += "allfault" + txtallfault.Text + "\n";
        //body += "majorthin" + txtmajorthin.Text + "\n";

       
        //con.Close();

        //// smtp settings
        //var smtp = new System.Net.Mail.SmtpClient();

        //smtp.Host = "exchange2007";

        //smtp.Send(fromAddress, toAddress, subject, body);
           
        
    }

    private void select()
    {
       SqlCommand cmd = new SqlCommand("jct_ops_classimat_select", obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("jct_ops_classimat_insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = txtdate.Text;
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 10).Value = Session["empcode"];
            cmd.Parameters.Add("@Host_IP", SqlDbType.VarChar, 30).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
            cmd.Parameters.Add("@weight", SqlDbType.Decimal, 9).Value = txtweight.Text;
            cmd.Parameters.Add("@length", SqlDbType.Decimal, 9).Value = txtlength.Text;
            cmd.Parameters.Add("@allfaultperkg", SqlDbType.Int).Value = txtallfault.Text;
            cmd.Parameters.Add("@majorshotthick", SqlDbType.Decimal, 9).Value = txtmajorshot.Text;
            cmd.Parameters.Add("@longshotthick", SqlDbType.Decimal, 9).Value = txtlongthick.Text;
            cmd.Parameters.Add("@shortshotthick", SqlDbType.Decimal, 9).Value = txtshortthick.Text;
            cmd.Parameters.Add("@thinfault", SqlDbType.Decimal, 9).Value = txtthinfault.Text;
            cmd.Parameters.Add("@majorthinfault", SqlDbType.Decimal, 9).Value = txtmajorthin.Text;
            cmd.Parameters.Add("@machineno", SqlDbType.VarChar, 10).Value = txtmachine.Text;
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 30).Value = txtremarks.Text;
           // con.Open();
            cmd.ExecuteNonQuery();
            //con.Close();
            //SendMail_classimat();
            txtallfault.Text = "";
            txtcount.Text = "";
            txtdate.Text = "";
            txtlength.Text = "";
            txtlongthick.Text = "";
            txtmajorshot.Text = "";
            txtmajorthin.Text = "";
            txtremarks.Text = "";
            txtsource.Text = "";
            txtthinfault.Text = "";
            txtweight.Text = "";
            txtshortthick.Text = "";
            txtmachine.Text = "";
            select();
            string script = "alert('Record Added..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch
        {

           string script = "alert(' Error Occured! Please click Refresh button to add details before saving data..!! ');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }


    }
    protected void imgdelete_Click(object sender, ImageClickEventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_classimat_delete", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@userid", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = lbid.Text;
        cmd.Parameters.Add("@Host_IP", SqlDbType.VarChar, 30).Value = Request.ServerVariables["REMOTE_ADDR"];
        //con.Open();
        cmd.ExecuteNonQuery();
        //con.Close();
       // Response.Write("<script>alert('record sucessfully deleted');</script>");
        txtallfault.Text = "";
        txtcount.Text = "";
        txtdate.Text = "";
        txtlength.Text = "";
        txtlongthick.Text = "";
        txtmajorshot.Text = "";
        txtmajorthin.Text = "";
        txtremarks.Text = "";
        txtsource.Text = "";
        txtthinfault.Text = "";
        txtweight.Text = "";
        txtshortthick.Text = "";
        txtmachine.Text = "";
        select();
        string script = "alert('record sucessfully deleted');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    protected void imgupdate_Click(object sender, ImageClickEventArgs e)
    {

        SqlCommand cmd = new SqlCommand("jct_ops_classimat_update", obj.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = lbid.Text;
        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = txtdate.Text;
        cmd.Parameters.Add("@userid", SqlDbType.VarChar, 10).Value = Session["empcode"];
        cmd.Parameters.Add("@Host_IP", SqlDbType.VarChar, 30).Value = Request.ServerVariables["REMOTE_ADDR"];
        cmd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
        cmd.Parameters.Add("@weight", SqlDbType.Decimal, 9).Value = txtweight.Text;
        cmd.Parameters.Add("@length", SqlDbType.Decimal, 9).Value = txtlength.Text;
        cmd.Parameters.Add("@allfaultperkg", SqlDbType.Decimal, 9).Value = txtallfault.Text;
        cmd.Parameters.Add("@majorshotthick", SqlDbType.Decimal, 9).Value = txtmajorshot.Text;
        cmd.Parameters.Add("@longshotthick", SqlDbType.Decimal, 9).Value = txtlongthick.Text;
        cmd.Parameters.Add("@shortshotthick", SqlDbType.Decimal, 9).Value = txtshortthick.Text;
        cmd.Parameters.Add("@thinfault", SqlDbType.Decimal, 9).Value = txtthinfault.Text;
        cmd.Parameters.Add("@majorthinfault", SqlDbType.VarChar).Value = txtmajorthin.Text;
        cmd.Parameters.Add("@machineno", SqlDbType.VarChar, 10).Value = txtmachine.Text;
        cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 30).Value = txtremarks.Text;
        //con.Open();
        cmd.ExecuteNonQuery();
        //con.Close();
        select();
    }
    protected void imgreset_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("classimat_test.aspx");
    }
    protected void mail_Click(object sender, EventArgs e)
    {
        SendMail_classimat();
    }

    private void SendMail_classimat()
    {
       
   
        //string sql;

        string from,to, subject, body;
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
        sb.AppendLine("Classimat Test Results : " + lbid.Text + "<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Count</th> <th>Date</th> <th> Source</th> <th> Length (kms)</th> <th> Weight (kgs)</th>  <th> AllNSFaults/100 km (A1+A2+A3+A4+ B1+B2+B3+B4+ C1+C2+C3+C4+ D1+D2+D3+D4)</th>  <th>Major objectionable Short Thick   (A4+B4+C3+C4+D3+D4)</th> <th>Objectionable  Short Thick  (A3+B3+C2+D2)</th> <th> LongThickPlace (E+F+G)</th> <th> ThinFault (H1)</th> <th>MajorThinFault (H2+I1+I2)</th><th> MachineNo</th> <th>Remarks</th></tr> ");
       // sql = "select count_1 as[Count], convert(varchar,date, 101) as [Date],source as [Source],length as[Length],weight as[Weight],allfaultperkg as[AllFaultPerkg ] ,majorshotthick as [MajorShotThick],shortshotthick as [ShortShotThick ],longshotthick as [LongShotThick],Thinfault as [Thinfault],majorthinfault as [MajorThinFault],remarks as [Remarks] from jct_ops_classimat  WHERE ID =" + lbid.Text + "";
       // SqlCommand cmd = new SqlCommand(sql, con);
       // con.Open();
       // SqlDataReader dr = cmd.ExecuteReader();
       // dr.Read();
       
       //if (dr.HasRows)       
       // {
           
       //     while (dr.Read())
       //     {
                sb.AppendLine("<tr> <td>  " + txtcount.Text + " </td> <td>  " + txtdate.Text+ " </td>  <td> " + txtsource.Text+ "</td>  <td> " + txtlength.Text + "</td>  <td> " + txtweight.Text + "</td>  <td>" + txtallfault.Text+ "</td> <td>" + txtmajorshot.Text + "</td> <td>" + txtshortthick.Text+" </td> <td> " +txtlongthick.Text+" </td> <td>"+txtthinfault.Text+" </td> <td>"+txtmajorthin.Text+"</td> <td>" +txtmachine.Text+"</td> <td> "+txtremarks.Text+" </td> </tr> ");

        //    }
        //}
        sb.AppendLine("</table>");
        sb.AppendLine("<br />");
       
        //dr.Close();
        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");
        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        to = "sanjeevkumar@jctltd.com,rameshd@jctltd.com,rd@jctltd.com,kartarsingh@jctltd.com";
        //to = "jatindutta@jctltd.com";
       // string bcc = "shweta@jctltd.com";
        string bcc = "harendra@jctltd.com,rbaksshi@jctltd.com";
        subject = "Classimat Test Result";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
      //  mail.To.Add(new MailAddress(to));

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
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;
    }

   

    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        if
    (  txtcount.Text == "" || txtmachine.Text == "")
        //(txtallfault.Text == "" || txtcount.Text == "" ||
        //txtdate.Text == "" ||
        //txtlength.Text == "" ||
        //txtlongthick.Text == "" ||
        //txtmajorshot.Text == "" ||
        //txtmajorthin.Text == "" ||
        //txtremarks.Text == "" ||
        //txtsource.Text == "" ||
        //txtthinfault.Text == "" ||
        //txtweight.Text == "" ||
        //txtmachine.Text == "" ||
        //txtshortthick.Text == "")

     

        {
            string script = "alert('Something missing! Please click Refresh button to add details  then Confirm');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        else
        {
            SqlCommand cmd = new SqlCommand("update jct_ops_classimat set status='A' where id = '" + lbid.Text + "' ", obj.Connection());
            SendMail_classimat();
        }
    }
    protected void report_Click(object sender, EventArgs e)
    {

    }
    protected void lnkpage_Click(object sender, EventArgs e)
    {
        Response.Redirect("classimat_test_2.aspx");
    }

    public class EMSWebService : System.Web.Services.WebService
    {
      
        
    }



    protected void lnkreport_Click(object sender, EventArgs e)
    {
        Response.Redirect("classimat_test_2.aspx");
    }
}
