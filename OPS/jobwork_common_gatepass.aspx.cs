using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Data;
using System.IO;

public partial class OPS_jobwork_common_gatepass : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if(!IsPostBack)
        {
            bindgrid();
          
           
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    private void bindgrid()
    {
        sql = "jct_ops_jobwork_common_select_invoice";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    private void bindgrid2()
    {
        sql = "SELECT requestid,gatepass,challanno,convert(varchar(10),challanDt,103) as [challanDt] ,qtyrecvd FROM jct_ops_jobwork_common_gatepass WHERE STATUS='A' AND challandt IS NOT null and requestid= '" + ViewState["RequestID"] + "'";
          SqlCommand cmd = new SqlCommand(sql, obj.Connection());
         cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail2.DataSource = ds.Tables[0];
        grdDetail2.DataBind();
        Panel3.Visible = true;
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
       

        //GridViewRow row = grdDetail.Rows[grdDetail.SelectedIndex];
        //TextBox tgate = (TextBox)row.FindControl("txtgate");

        ViewState["RequestID"] = grdDetail.SelectedRow.Cells[2].Text;

        bindgrid2();

        sql = "Select gatepass from jct_ops_jobwork_common_gatepass where status='A' and requestID= '" + ViewState["RequestID"] + "'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lbgate.Visible = true;
                txtgate.Text = dr[0].ToString();
                txtgate.Enabled = false;
                txtgate.Visible = true;
                txtqty.Visible = true;
                txtchallnno.Visible = true;
                txtchalandt.Visible = true;
                lbchlnno.Visible = true;
                lbchalandt.Visible = true;
                lbqty.Visible = true;
                lnkFinish.Visible = true;
            }
         
        }
        else
        {
            lbgate.Visible = true;
            txtgate.Visible = true;
            txtgate.Enabled = true;
        
        }
    }



    protected void lnkadd_Click(object sender, EventArgs e)
    {
             DateTime? jbDt = null;
             if (txtchalandt.Text != "")
             {
                 sql = "SELECT jbcontractDt FROM dbo.jct_ops_jobwork_common WHERE RequestID= '" + ViewState["RequestID"] + "'";
                 SqlCommand cmd = new SqlCommand(sql, obj.Connection());

                 SqlDataReader dr;
                 dr = cmd.ExecuteReader();
                 if (dr.HasRows)
                 {
                     while (dr.Read())
                     {
                         jbDt = Convert.ToDateTime(dr[0].ToString());
                     }
                 }
                 dr.Close();
                 if (Convert.ToDateTime(txtchalandt.Text) < jbDt)
                 {
                     string script = "alert( challan date should be graeter than jobcontractdate!!');";
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                     return;

                 }
             }
     
         sql = "jct_ops_jobwork_common_gatepass_insert";
         SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
        cmd1.Parameters.Add("@gatepass", SqlDbType.VarChar, 30).Value = txtgate.Text;
        cmd1.Parameters.Add("@challanNo", SqlDbType.VarChar, 30).Value = txtchallnno.Text;
        cmd1.Parameters.Add("@challanDt", SqlDbType.DateTime).Value = txtchalandt.Text == "" ? null : txtchalandt.Text;
      
        cmd1.Parameters.Add("@qtyRecvd", SqlDbType.VarChar, 20).Value = txtqty.Text;
        cmd1.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];

        cmd1.ExecuteNonQuery();
     
        bindgrid2();
        SendMail();
        
       
        string script2 = "alert('Record Saved.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

    }
    protected void lnkFinish_Click(object sender, EventArgs e)
    {

   
        sql = "jct_ops_jobwork_common_gatepass_freeze";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];


        cmd.ExecuteNonQuery();
        bindgrid();
        string script = "alert('Record Freezed.!!');";
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

        //sb.AppendLine("Hello " + RequestBy + ",<br/><br/>");
        sb.AppendLine("Challan has been made for jobwork requestID " + ViewState["RequestID"] + " <br/><br/>");
        sb.AppendLine("Details are :<br/><br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th>RequestID</th> <th>Gatepass</th><th>challanDt</th> <th> challanNo</th> <th>QtyReceived</th> </tr>");

        sql = "Select RequestId,gatepass,challanDt,challanNo,qtyRecvd,sr_no AS Sr_no  from jct_ops_jobwork_common_gatepass where status='A'  and challanDt IS NOT NULL and   status='A' and sr_no = (Select max(sr_no) AS Sr_no  from jct_ops_jobwork_common_gatepass where status='A'  and challanDt IS NOT NULL and   status='A' )  ";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
     
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr> <td>  " + dr["RequestID"] + " </td> <td>  " + dr["gatepass"] + " </td>  <td>  " + dr["challanDt"] + " </td> <td> " + dr["challanNo"] + "</td> <td> " + dr["qtyRecvd"] + "</td> </tr> ");
            }
        }
        dr.Close();
        sql = "SELECT plant  FROM jct_ops_jobwork_common where status='A' and requestID= '" + ViewState["RequestID"] + "'";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
       
        dr = cmd.ExecuteReader();
       
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (dr["plant"] == "Cotton")
                {
                    //to = "opminhas@jctltd.com,pkchhabra@jctltd.com,rajkumars@jctltd.com";
                    to = "shwetaloria@jctltd.com";
                }
                else
                {
                   // to = "chandwani@jctltd.com,whg@jctltd.com";
                    to = "shwetaloria@jctltd.com";
                }
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
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("jobwork_common_gatepass.aspx");
    }
}