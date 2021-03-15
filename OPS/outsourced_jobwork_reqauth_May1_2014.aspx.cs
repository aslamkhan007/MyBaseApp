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

public partial class OPS_outsourced_jobwork_reqauth : System.Web.UI.Page
{

     SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

 if (!IsPostBack)
 {
     if (Session["Empcode"] == "")
     {
         Response.Redirect("~/Login.aspx");
     }
 }
    }
    protected void lnkauth_Click(object sender, EventArgs e)
    {
         foreach (GridViewRow rw in grdDetail.Rows)
            {
                CheckBox chk1 = (CheckBox)rw.FindControl("chk");
           
                if (chk1.Checked)
                {

                  SqlCommand cmd1 = new SqlCommand("jct_ops_outsourced_job_work_req_auth", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd1.Parameters.Add("@reqid", SqlDbType.VarChar, 30).Value = rw.Cells[1].Text;
                    cmd1.Parameters.Add("@ID", SqlDbType.Int).Value = rw.Cells[18].Text;
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    string script2 = "alert(' record saved sucesfully.!! ');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                    sendmail();
   
                    }
                }
         }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_select_on_Req", con);
  
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 30).Value = ddlreqid.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        con.Close();
        ViewState["RequestID"] = ddlreqid.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        lnkauth.Visible = true;
    }
    protected void chksel_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox sel = (CheckBox)grdDetail.HeaderRow.FindControl("chksel");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");



            if (cb != null)
            {

                if (sel.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
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
        sb.AppendLine("Outsourced JobWork has been generated in OPS by : " + ViewState["By"] + "<br/><br/>");

        sb.AppendLine("Job Work RequestID : " + ViewState["RequestID"] + " has been finalised By " + ViewState["RequestBy"] + "  <br/><br/>");
        //sb.AppendLine("Yarn Specifications has been entered by " + ViewState["RequestBy"] + ".<br/><br/>");
        sb.AppendLine("Raw Material Dept have to proceed futher for the vendor against these ");
        //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");

        sb.AppendLine("<br /><br/>");

       // sb.Append("<a href='http://misdev/FusionApps/OPS/yarn_enquiry.aspx'> Click here  to enter the vendors againt these specifcation..!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");

        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";
    
         to="shwetaloria@jctltd.com";
       //to =  ViewState["RequestByEmail"] + ", " +  ViewState["RequestByEmail"] + ",dpbadhwar@jctltd.com,,skpalta@jctltd.com";
      

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