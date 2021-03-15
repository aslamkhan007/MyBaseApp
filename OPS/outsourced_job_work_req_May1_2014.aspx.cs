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

public partial class OPS_outsourced_job_work_req : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Empcode"] == "")
            {
                Response.Redirect("~/Login.aspx");

            }
        }
        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_select", con);
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

        //if ((Convert.ToDecimal(txtdnv.Text) > (Convert.ToDecimal(txtfinishsaleprice.Text))
        //{
        //    string script = "alert(' Finish Sale Price Cannot be less than the DNV Cost!!!! Please Check ');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        //    return;
        //}
        GenerateCode();
        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
        cmd.Parameters.Add("@entryBy", SqlDbType.VarChar, 20).Value = "s-13823";//Session["empcode"];
        cmd.Parameters.Add("@QtyReq", SqlDbType.VarChar, 20).Value = txtqtyreq.Text;
        cmd.Parameters.Add("@Sortno", SqlDbType.VarChar, 20).Value = txtsort.Text;
        cmd.Parameters.Add("@ProductType", SqlDbType.VarChar, 20).Value = ddlproducttype.SelectedItem.Text;
        cmd.Parameters.Add("@Paymentterms", SqlDbType.VarChar, 100).Value = txtpayterms.Text;
        cmd.Parameters.Add("@uom", SqlDbType.VarChar, 20).Value = ddluom.SelectedItem.Text;
        cmd.Parameters.Add("@Mkt_exe", SqlDbType.VarChar, 30).Value = txtmkt.Text;
        cmd.Parameters.Add("@Freight_charges", SqlDbType.VarChar, 20).Value = ddlfreight.SelectedItem.Text;
        cmd.Parameters.Add("@Finish_sale_price", SqlDbType.VarChar, 30).Value = txtfinishsaleprice.Text;
        cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = "cotton";
        cmd.Parameters.Add("@Delivery_upto", SqlDbType.VarChar, 20).Value = txtdeliupto.Text;
        cmd.Parameters.Add("@Deliverydate", SqlDbType.VarChar, 20).Value = txtdeliverydt.Text;
        cmd.Parameters.Add("@packingdetail", SqlDbType.VarChar, 20).Value = ddlpacking.SelectedItem.Text;
        cmd.Parameters.Add("@dnvcost", SqlDbType.VarChar, 20).Value = txtdnv.Text;
        cmd.Parameters.Add("@size", SqlDbType.VarChar, 20).Value = txtsize.Text;
        cmd.Parameters.Add("@style", SqlDbType.VarChar, 20).Value = ddlstyle.SelectedItem.Text;
        cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 200).Value = txtremarks.Text;
        cmd.Parameters.Add("@Memo_date", SqlDbType.VarChar, 20).Value = txtmemo.Text;
        cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 100).Value = txtdesc.Text;
     
        cmd.Parameters.Add("@fabrictype", SqlDbType.VarChar, 20).Value = txtfabtype.Text;
        cmd.Parameters.Add("@production", SqlDbType.VarChar, 20).Value = ddlprod.SelectedItem.Text;
        cmd.Parameters.Add("@consumption", SqlDbType.Int).Value = txtconsumption.Text;
      
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
     
        
        string script2 = "alert(' record saved sucesfully.!!!d !! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        lbid.Text = ViewState["RequestID"].ToString();
        lbid.Visible = true;
        SendMail();

         cmd = new SqlCommand("jct_ops_outsourced_job_work_select", con);
        con.Open();

        cmd.ExecuteNonQuery();
        con.Close();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();


    }
    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;



        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        con.Open();

        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(reqid),CHARINDEX('-',max( reqid))+1,len(max(reqid))+2) from jct_ops_outsourced_job_work", con);
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
                    ViewState["RequestID"] = "JW-" + ViewState["RequestID"];
                }
                else
                {
                    ViewState["RequestID"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["RequestID"] = "JW-" + ViewState["RequestID"];
                }
            }
         

        }

        dr.Close();
        con.Close();

        #endregion
    }
    protected void lnk_Click(object sender, EventArgs e)
    {
        
        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_insert_temp", con);
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
        cmd.Parameters.Add("@entryBy", SqlDbType.VarChar, 20).Value = "s-13823";//Session["empcode"];
        cmd.Parameters.Add("@QtyReq", SqlDbType.VarChar, 20).Value = txtqtyreq.Text;
        cmd.Parameters.Add("@Sortno", SqlDbType.VarChar, 20).Value = txtsort.Text;
        cmd.Parameters.Add("@ProductType", SqlDbType.VarChar, 20).Value = ddlproducttype.SelectedItem.Text;
        cmd.Parameters.Add("@Paymentterms", SqlDbType.VarChar, 100).Value = txtpayterms.Text;
        cmd.Parameters.Add("@uom", SqlDbType.VarChar, 20).Value = ddluom.SelectedItem.Text;
        cmd.Parameters.Add("@Mkt_exe", SqlDbType.VarChar, 30).Value = txtmkt.Text;
        cmd.Parameters.Add("@Freight_charges", SqlDbType.VarChar, 20).Value = ddlfreight.SelectedItem.Text;
        cmd.Parameters.Add("@Finish_sale_price", SqlDbType.VarChar, 30).Value = txtfinishsaleprice.Text;
        cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = "cotton";
        cmd.Parameters.Add("@Delivery_upto", SqlDbType.VarChar, 20).Value = txtdeliupto.Text;
        cmd.Parameters.Add("@Deliverydate", SqlDbType.VarChar, 20).Value = txtdeliverydt.Text;
        cmd.Parameters.Add("@packingdetail", SqlDbType.VarChar, 20).Value = ddlpacking.SelectedItem.Text;
        cmd.Parameters.Add("@dnvcost", SqlDbType.VarChar, 20).Value = txtdnv.Text;
        cmd.Parameters.Add("@size", SqlDbType.VarChar, 20).Value = txtsize.Text;
        cmd.Parameters.Add("@style", SqlDbType.VarChar, 20).Value = ddlstyle.SelectedItem.Text;
        cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 200).Value = txtremarks.Text;
        cmd.Parameters.Add("@Memo_date", SqlDbType.VarChar, 20).Value = txtmemo.Text;
        cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 20).Value = txtdesc.Text;

        cmd.Parameters.Add("@fabrictype", SqlDbType.VarChar, 20).Value = txtfabtype.Text;
        cmd.Parameters.Add("@production", SqlDbType.VarChar, 20).Value = ddlprod.SelectedItem.Text;
        cmd.Parameters.Add("@consumption", SqlDbType.Int).Value = txtconsumption.Text;

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        string script2 = "alert(' record saved sucesfully.!!!Click Addnew to enter another Record for the same ID!! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

         //ViewState["RequestID"];
       //Session["empcode"];
       txtqtyreq.Text="";
       txtsort.Text="";
       //ddlproducttype.SelectedItem.Text="";
       txtpayterms.Text="";
   ddluom.SelectedItem.Text="";
        txtmkt.Text="";
       //ddlfreight.SelectedItem.Text="";
       txtfinishsaleprice.Text="";
      //ddlplant.SelectedItem.Text="";
       txtdeliupto.Text="";
        txtdeliverydt.Text="";
        //ddlpacking.SelectedItem.Text="";
    txtdnv.Text="";
        txtsize.Text="";
       //txtstyle.Text="";
         txtremarks.Text="";
         txtmemo.Text="";
      txtdesc.Text="";
      txtfabtype.Text = "";
      lnksave.Visible = true;

    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
     
        lbid.Visible = true;
        lbid.Text = grdDetail.SelectedRow.Cells[1].Text;
        txtqtyreq.Text = grdDetail.SelectedRow.Cells[3].Text;
        txtsort.Text = grdDetail.SelectedRow.Cells[4].Text;
        txtpayterms.Text = grdDetail.SelectedRow.Cells[6].Text;
        txtmkt.Text = grdDetail.SelectedRow.Cells[7].Text;
        txtmemo.Text = grdDetail.SelectedRow.Cells[9].Text;
        txtfinishsaleprice.Text =grdDetail.SelectedRow.Cells[10].Text;
        txtdesc.Text = grdDetail.SelectedRow.Cells[11].Text;
        txtremarks.Text = grdDetail.SelectedRow.Cells[13].Text;
        txtdnv.Text = grdDetail.SelectedRow.Cells[15].Text;

   
     
        //txtfabtype.Text = grdDetail.SelectedRow.Cells[1].Text;
        //ddlplant.SelectedItem.Text="";
        //txtdeliupto.Text =grdDetail.SelectedRow.Cells[1].Text;
        //txtdeliverydt.Text =grdDetail.SelectedRow.Cells[1].Text;
        //ddlpacking.SelectedItem.Text;
        //txtsize.Text = grdDetail.SelectedRow.Cells[1].Text;
        //txtstyle.Text = grdDetail.SelectedRow.Cells[1].Text;
        //ddlproducttype.SelectedItem.Text="";
        //ddlfreight.SelectedItem.Text=""
        //ddluom.SelectedItem.Text= ""

    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_update", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;
        cmd.Parameters.Add("@entryBy", SqlDbType.VarChar, 20).Value = "s-13823";//Session["empcode"];
        cmd.Parameters.Add("@QtyReq", SqlDbType.VarChar, 20).Value = txtqtyreq.Text;
        cmd.Parameters.Add("@Sortno", SqlDbType.VarChar, 20).Value = txtsort.Text;
        cmd.Parameters.Add("@ProductType", SqlDbType.VarChar, 20).Value = ddlproducttype.SelectedItem.Text;
        cmd.Parameters.Add("@Paymentterms", SqlDbType.VarChar, 100).Value = txtpayterms.Text;
        cmd.Parameters.Add("@uom", SqlDbType.VarChar, 20).Value = ddluom.SelectedItem.Text;
        cmd.Parameters.Add("@Mkt_exe", SqlDbType.VarChar, 30).Value = txtmkt.Text;
        cmd.Parameters.Add("@Freight_charges", SqlDbType.VarChar, 20).Value = ddlfreight.SelectedItem.Text;
        cmd.Parameters.Add("@Finish_sale_price", SqlDbType.VarChar, 30).Value = txtfinishsaleprice.Text;
        cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = "cotton";
        cmd.Parameters.Add("@Delivery_upto", SqlDbType.VarChar, 20).Value = txtdeliupto.Text;
        cmd.Parameters.Add("@Deliverydate", SqlDbType.VarChar, 20).Value = txtdeliverydt.Text;
        cmd.Parameters.Add("@packingdetail", SqlDbType.VarChar, 20).Value = ddlpacking.SelectedItem.Text;
        cmd.Parameters.Add("@dnvcost", SqlDbType.VarChar, 20).Value = txtdnv.Text;
        cmd.Parameters.Add("@size", SqlDbType.VarChar, 20).Value = txtsize.Text;
        cmd.Parameters.Add("@style", SqlDbType.VarChar, 20).Value = ddlstyle.SelectedItem.Text;
        cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 200).Value = txtremarks.Text;
        cmd.Parameters.Add("@Memo_date", SqlDbType.VarChar, 20).Value = txtmemo.Text;
        cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 100).Value = txtdesc.Text;

        cmd.Parameters.Add("@fabrictype", SqlDbType.VarChar, 20).Value = txtfabtype.Text;
        cmd.Parameters.Add("@production", SqlDbType.VarChar, 20).Value = ddlprod.SelectedItem.Text;
        cmd.Parameters.Add("@consumption", SqlDbType.Int).Value = txtconsumption.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[18].Text;

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();


        string script2 = "alert(' record updated sucesfully.!!!d !! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("outsourced_job_work_req.aspx");
    }
    protected void ddluom_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void lnkdel_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;
        cmd.Parameters.Add("@entryBy", SqlDbType.VarChar, 20).Value = "s-13823";//Session["empcode"];
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[18].Text;

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void txtsort_TextChanged(object sender, EventArgs e)
    {

    }
    private void SendMail()
    {
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;



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
        //sb.AppendLine("Request is Pending at R&D Dept <br/><br/>");

        //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");
        sb.AppendLine("<tr><th> RequestID  </th> <th>RequiredQty</th> <th>Sortno</th> <th>MarketingExecutive</th> <th> DeliveryDate </th><th> Remarks </th> </tr> ");
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
                sb.AppendLine("<tr> <td>  " + Dr["reqid"].ToString() + " </td> <td>  " + Dr["Qtyreq"].ToString() + " </td>  <td> " + Dr["sortno"].ToString() + "</td>  <td> " + Dr["mkt_exe"] + "</td>  <td> " + Dr["deliveryDate"].ToString() + "</td><td> " + Dr["remarks"].ToString() + "</td> </tr> ");

            }
        }

        Dr.Close();
        con.Close();
        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");

        //sb.AppendLine("Please fill the specifications against this Request.<br/> <br/>");

        //sb.Append("<a href='http://misdev/FusionApps/OPS/outsourced_fab_specs.aspx'> Click here to fill specifications..!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";



        to = ViewState["RequestByEmail"].ToString() + ",shwetaloria@jctltd.com ";
       // to = ViewState["RequestByEmail"].ToString() + ",amit@jctltd.com";
        

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