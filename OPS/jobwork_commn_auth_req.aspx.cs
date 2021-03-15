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

public partial class OPS_jobwork_commn_auth_req : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
        }
    }
    private void bindgrid()
    {
        //jct_ops_jobwork_common_select
        sql = "jct_ops_jobwork_common_select_auth";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;

    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        string requestid = grdDetail.SelectedRow.Cells[1].Text;
        ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        sql = "jct_ops_jobwork_common_req_auth";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@requestId", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;
        cmd.ExecuteNonQuery();
        string script = "alert('Request has been authorize.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        

    }
    private void SendMail()
    {
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string Subject = null;
        string body = null;
        string empcode = Session["EmpCode"].ToString();
        string RequestBy_Email = string.Empty;
        string RequestBy = string.Empty;


        sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = @empcode and company_code ='JCT00LTD'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = empcode;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                RequestBy_Email = dr[0].ToString();
            }
        }
        else
        {
            RequestBy_Email = "shwetaloria@jctltd.com";
        }
        dr.Close();

        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"].ToString() + "' and active='Y'";

        try
        {
            RequestBy = obj1.FetchValue(sql).ToString();
        }
        catch { }

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");

        sb.AppendLine("Hello " + RequestBy + ",<br/><br/>");
        sb.AppendLine("Job Work Request made in system.<br/><br/>");
        sb.AppendLine("Details are :<br/><br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> RequestID </th> <th> Job Contract No </th><th> Contract Date </th> <th> Sort No </th> <th> Qty </th> <th> Nature of Job  </th> <th> Job Type </th>  <th> Job Rate</th>  <th> Fab Rate</th><th>Value</th> <th>Construction</th><th>Vendor</th><th>Elongation Bearer</th><th>Elongation Percent</th><th>Shrinkage Percent</th> <th>Delivery Dt</th><th>Freight Charges By</th></tr>");

        sql = "jct_ops_jobwork_common_select";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"];
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr> <td>  " + dr["RequestID"] + " </td> <td>  " + dr["jbcontractno"] + " </td>  <td>  " + dr["jbcontractDt"] + " </td> <td> " + dr["Sort_no"] + "</td>  <td> " + dr["Qty"] + "</td>  <td> " + dr["nature_of_jb"] + "</td>  <td> " + dr["jobtype"] + " </td><td>" + dr["JobRate"] + "</td> <td>" + dr["FabRate"] + "</td> <td>" + dr["value"] + "</td><td>" + dr["Construction"] + "</td><td>" + dr["Vendor"] + "</td><td>" + dr["Elongation_bearer"] + "</td><td>" + dr["Elongation%"] + "</td><td>" + dr["shrinkage%"] + "</td><td>" + dr["DeliveryDate"] + "</td><td>" + dr["freight_chrg"] + "</td> </tr> ");
            }
        }


        sb.AppendLine("</table>");
        sb.AppendLine("<br/><br/>");
        sb.AppendLine("This is a system generated mail, please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");

        Subject = "Outsourced Job Work Request - " + ViewState["RequestID"];


        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";
        //to = "mrsood@jctltd.com,arvindsharma@jctltd.com,ashutoshtiwari@jctltd.com,pgmohan@jctltd.com,skpalta@jctltd.com,vinaydogra@jctltd.com,skj@jctltd.com,ashokjoshi@jctltd.com,'" + RequestBy_Email + "' ";
        to = "shwetaloria@jctltd.com";
        bcc = "shwetaloria@jctltd.com,jatindutta@jctltd.com,rajan@jctltd.com";
        Subject = "Outsourced Job Work Request - " + ViewState["RequestID"];
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

        mail.Subject = Subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");
        SmtpMail.Send(mail);
    }
}