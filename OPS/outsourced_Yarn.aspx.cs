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

public partial class OPS_outsourced_Yarn : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
           
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        SqlCommand cmd = new SqlCommand("jct_ops_yarn_select_req", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = lbid.Text;
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GrdDetail.DataSource = ds.Tables[0];
        GrdDetail.DataBind();
    }

    private void gencode()
    {


        string str;



        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        con.Open();

        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(requestid),CHARINDEX('-',max( requestid))+1,len(max(requestid))+2) from jct_ops_yarn_purchase", con);
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["RequestID"] = "100";
                    ViewState["RequestID"] = "YR-" + ViewState["RequestID"];
                }
                else
                {
                    ViewState["RequestID"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["RequestID"] = "YR-" + ViewState["RequestID"];
                }
            }

        }

        dr.Close();
        con.Close();
    }

    private void insert()
    {


        if (txtreqqty.Text == "" || txtquality.Text == "")
        {
            string script = "alert(' Error Occured!  some data may be missing.. please fill!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }

        try
        {
            SqlCommand cmd = new SqlCommand("jct_ops_yarn_purchase_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = Session["empcode"];
            cmd.Parameters.Add("@Quality", SqlDbType.VarChar, 20).Value = txtquality.Text;
            cmd.Parameters.Add("@sort_no", SqlDbType.VarChar, 20).Value = txtSortno.Text;
            cmd.Parameters.Add("@Sale_order", SqlDbType.VarChar, 20).Value = txtso.Text;
            cmd.Parameters.Add("@req_Qty", SqlDbType.VarChar, 20).Value = txtreqqty.Text;
            cmd.Parameters.Add("@UOM", SqlDbType.VarChar, 20).Value = ddluom.SelectedItem.Text;
            cmd.Parameters.Add("@req_date", SqlDbType.VarChar, 20).Value = txtreqdt.Text;
            cmd.Parameters.Add("@yarn_req", SqlDbType.VarChar, 20).Value = ddlyarn.SelectedItem.Text;
            cmd.Parameters.Add("@end_use", SqlDbType.VarChar, 20).Value = txtend.Text;
            cmd.Parameters.Add("@plant ", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Text;
            cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 10).Value = "";
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 30).Value = txtremarks.Text;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lbid.Text = ViewState["RequestID"].ToString();

            string script = "alert(' record saved sucesfully.!!  please press clear button!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lnksave.Enabled = false;
            sendmail();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    protected void lnksave_Click(object sender, EventArgs e)
    {
        gencode();
        insert();
        SqlCommand cmd = new SqlCommand("jct_ops_yarn_select_req", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = lbid.Text;
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GrdDetail.DataSource = ds.Tables[0];
        GrdDetail.DataBind();
        lbid.Visible = true;


    }
    protected void lnkclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("outsourced_Yarn.aspx");
    }
    protected void rdlist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
         lbid.Text = GrdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
         txtquality.Text= GrdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
         txtSortno.Text= GrdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
         txtso.Text= GrdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
         txtreqqty.Text= GrdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
         txtreqdt.Text= GrdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
         txtend.Text = GrdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
         ddlplant.Text=GrdDetail.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
         ddluom.Text=GrdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
         ddlyarn.Text=GrdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
         txtremarks.Text =GrdDetail.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
    }

    protected void lnkUpt_Click(object sender, EventArgs e)
    {


        if (txtreqqty.Text == "" || txtquality.Text == "")
        {
            string script = "alert(' Error Occured!  some data may be missing.. please fill!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }

        try
        {
            SqlCommand cmd = new SqlCommand("jct_ops_yarn_purchase_update", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = lbid.Text;
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = Session["empcode"];
            cmd.Parameters.Add("@Quality", SqlDbType.VarChar, 20).Value = txtquality.Text;
            cmd.Parameters.Add("@sort_no", SqlDbType.VarChar, 20).Value = txtSortno.Text;
            cmd.Parameters.Add("@Sale_order", SqlDbType.VarChar, 20).Value = txtso.Text;
            cmd.Parameters.Add("@req_Qty", SqlDbType.VarChar, 20).Value = txtreqqty.Text;
            cmd.Parameters.Add("@UOM", SqlDbType.VarChar, 20).Value = ddluom.SelectedItem.Text;
            cmd.Parameters.Add("@req_date", SqlDbType.VarChar, 20).Value = txtreqdt.Text;
            cmd.Parameters.Add("@yarn_req", SqlDbType.VarChar, 20).Value = ddlyarn.SelectedItem.Text;
            cmd.Parameters.Add("@end_use", SqlDbType.VarChar, 20).Value = txtend.Text;
            cmd.Parameters.Add("@plant ", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Text;
            cmd.Parameters.Add("@areacode", SqlDbType.VarChar, 10).Value = "1044";
            cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 10).Value = "";
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 30).Value = txtremarks.Text;
          
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            string script = "alert(' Record update sucesfully.!!  please press clear button!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkdel_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_yarn_purchase_delete", con);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = GrdDetail.SelectedRow.Cells[1].Text;

          con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string script = "alert(' Record deleted sucesfully.!!  please press clear button!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }



    private void sendmail()
    {
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;

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
        sb.AppendLine("Outsourced Yarn Request has been generated in OPS by : " + ViewState["RequestBy"] + "<br/><br/>");

        sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
       // sb.AppendLine("Request is Pending at R&D for approval. <br/><br/>");

        //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");

        sql = "jct_ops_yarn_purchase_select_req ";
        con.Open();
        cmd = new SqlCommand(sql, con);


        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while ((Dr.Read()))
            {

                sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
                sb.AppendLine("<tr><td colspan='4'> R & D DEPT</td></tr> ");
                sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED YARN  REQUEST </td> </tr>");
                sb.AppendLine("<tr><td colspan='4'> CONSTRUCTION</td> </tr>");
                sb.AppendLine("<tr><td colspan='2'> QUANTITY REQUIRED</td> <td colspan='2'>" + Dr["ReqQty"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> UOM</td> <td colspan='2'>" + Dr["UOM"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> SORTNO</td> <td colspan='2'>" + Dr["SortNo"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'>QUALITY</td> <td colspan='2'>" + Dr["Quality"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> REQUIRED DATE</td> <td colspan='2'>" + Dr["Reqdate"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> YARN REQ</td> <td colspan='2'>" + Dr["YarnReq"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> ENDUSE</td> <td colspan='2'>" + Dr["EndUse"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> SALE ORDER </td> <td colspan='2'>" + Dr["SaleOrder"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> REMARKS</td><td colspan='2'>" + Dr["remarks"].ToString() + "</td></tr>");

            }

        }
        Dr.Close();
        con.Close();
        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");

        sb.AppendLine("Please fill the specification against this Request.<br/> <br/>");

        sb.Append("<a href='http://testerp/FusionApps/OPS/yarnspecs.aspx'> Click here to fill specifications..!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";
        to = ViewState["RequestByEmail"] + ",kartarsingh@jctltd.com,sanjeevj@jctltd.com,arvindsharma@jctltd.com,laxman@jctltd.com,sobti@jctltd.com";

        //to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString();

        //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
        bcc = "shwetaloria@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com,rajan@jctltd.com";
        subject = "Outsourced Yarn Request - " + ViewState["RequestID"];
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
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;



    }
}
