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
public partial class OPS_po_job_work : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
            if (Session["Empcode"] == "")
            {
                Response.Redirect("~/Login.aspx");

            }
        
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_po_select", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        }

    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow rw in grdDetail.Rows)
            {

                CheckBox chk1 = (CheckBox)rw.FindControl("chk");
                TextBox txtPO = (TextBox)rw.FindControl("txtpo");
                TextBox txtwaste = (TextBox)rw.FindControl("txtwaste");
                TextBox txtGatePass = (TextBox)rw.FindControl("txtgatepass");

                if (chk1.Checked == true)
                {
                    ViewState["RequestID"] = rw.Cells[4].Text;
                    if (txtPO.Text != "")
                    {
                        string sql = "select * from miserp.pomdb.dbo.pur_po_header where po_date >= '2014-03-01 00:00:00.000' and  left(po_no,2) = @po_no ";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@po_no", SqlDbType.VarChar, 20).Value = txtPO.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if ((dr.HasRows))
                        {
                            cmd = new SqlCommand("jct_ops_outsourced_job_work_po_gen", con);
                            con.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = rw.Cells[4].Text;
                            cmd.Parameters.Add("@po_no", SqlDbType.VarChar, 30).Value = txtPO.Text;
                            cmd.Parameters.Add("@po_enterby", SqlDbType.VarChar, 30).Value = "S-13823"; //Session["Empcode"];
                            cmd.ExecuteNonQuery();

                            dr.Close();
                            string script2 = "alert(' record saved sucesfully.!! ');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                            SendMail();

                        }

                        else
                        {
                            string script2 = "alert(' please Check the PONo');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

                        }
                        con.Close();
                    }
                    txtGatePass.Enabled = true;
                    if (txtGatePass.Text != "")
                    {

                        string sql = "select * from jctdev..jct_gatepass_header where gatepass_date >= '2014-04-01 00:00:00.000'and left(gatepass_no,3) = @gatepassno and gatepass_status = 'A'";
                        SqlCommand cmd = new SqlCommand(sql, con);
                         con.Open();
                         cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@gatepassno", SqlDbType.VarChar, 20).Value = txtGatePass.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if ((dr.HasRows))
                        {
                            cmd = new SqlCommand("jct_ops_outsourced_job_work_gate_pass", con);
                            con.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = rw.Cells[4].Text;
                            cmd.Parameters.Add("@gatepassno", SqlDbType.VarChar, 50).Value = txtGatePass.Text;
                            cmd.ExecuteNonQuery();
                            dr.Close();
                            string script2 = "alert(' record saved sucesfully.!! ');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                            SendMail();

                        }
                        else
                        {
                            string script2 = "alert(' please Check the GatepassNo!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

                        }
                        con.Close();
                      
                    }

                    if (txtwaste.Text != "")
                    {

                        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_actual_waste", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = rw.Cells[4].Text;
                        cmd.Parameters.Add("@actualwaste", SqlDbType.VarChar, 50).Value = txtwaste.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        string script2 = "alert(' record saved sucesfully.!! ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                        SendMail();

                    }

                }
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('Please verify Pono or  GatepassNo.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true); 
        }
    }
       
        
    
    protected void lnkclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("po_job_work.aspx");
    }
   
    protected void chksel_CheckedChanged1(object sender, EventArgs e)
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

    private void SendMail()
    {
        // to be edited accordingly
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;
        string sql = null;


         sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
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
        sb.AppendLine("Outsourced jobWork Request has been generated in OPS by : " + ViewState["RequestBy"] + "<br/><br/>");

        sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
        sb.AppendLine("Po has been generayed <br/><br/>");

        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");
        sb.AppendLine("<tr><th> RequestID  </th> <th>RequiredQty</th> <th>Sortno</th> <th>MarketingExecutive</th> <th> DeliveryDate </th><th> Remarks </th>  <th> PONo </th><th> GatePassNo </th><th> ActualWaste </th></tr> ");
          sql = "jct_ops_outsourced_jobwork_mail_content";
        cmd = new SqlCommand(sql, con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar).Value = ViewState["RequestID"];
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while ((Dr.Read()))
            {
                sb.AppendLine("<tr> <td>  " + Dr["reqid"].ToString() + " </td> <td>  " + Dr["Qtyreq"].ToString() + " </td>  <td> " + Dr["sortno"].ToString() + "</td>  <td> " + Dr["mkt_exe"] + "</td>  <td> " + Dr["deliveryDate"].ToString() + "</td><td> " + Dr["remarks"].ToString() + "</td>  <td> " + Dr["po_no"].ToString() + "</td><td> " + Dr["gatepassno"].ToString() + "</td><td> " + Dr["actualwaste"].ToString() + "</td></tr> ");

            }
        }

        Dr.Close();
        con.Close();
        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");
        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";
       to = "shwetaloria@jctltd.com";
       //to = ViewState["RequestByEmail"].ToString() +","+ ViewState["By"] +",amit@jctltd.com";

        bcc = "shwetaloria@jctltd.com,jatindutta@jctltd.com,rajan@jctltd.com";
        subject = "Outsourced JobWork RequestId - " + ViewState["RequestID"];
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


        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");


        SmtpMail.Send(mail);

    }

}