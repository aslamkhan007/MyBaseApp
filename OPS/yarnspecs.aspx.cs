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

public partial class OPS_yarnspecs : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("jct_ops_yarn_comp_req_select", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = req;
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
 
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_yarn_comp_req_srch", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = txtreq.Text;
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        string req = grdDetail.SelectedRow.Cells[1].Text;
        ViewState["usercode"] = grdDetail.SelectedRow.Cells[2].Text;
        ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;
        ViewState["Sort_no"] = grdDetail.SelectedRow.Cells[5].Text;

        SqlCommand cmd = new SqlCommand("jct_ops_yarn_specs_autofil", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@sort_no", SqlDbType.VarChar, 50).Value = ViewState["Sort_no"];
        cmd.ExecuteNonQuery();

        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {

            txtcount.Text = dr[1].ToString();
            txtcountcv.Text = dr[2].ToString();
            txtelongation.Text = dr[3].ToString();
            txtOPU.Text = dr[4].ToString();
            txtnip.Text = dr[5].ToString();
            txtBWS.Text = dr[6].ToString();
            txtCSP.Text = dr[7].ToString();
            txtu.Text = dr[8].ToString();
            txtIPI.Text = dr[9].ToString();
            txtHair.Text = dr[10].ToString();
            txtTPI.Text = dr[11].ToString();
            txtBlend.Text = dr[12].ToString();
            txtclassimate.Text = dr[13].ToString();
            txtallfaults.Text = dr[14].ToString();
            txtmajorthick.Text = dr[15].ToString();
            txtmajorthin.Text = dr[16].ToString();
            txtshortthick.Text = dr[17].ToString();
            txtlngthick.Text = dr[18].ToString();
            txtthinfaults.Text = dr[19].ToString();
            txtmajorthin.Text = dr[20].ToString();
        }

        dr.Close();
        con.Close();
          
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {


        if (txtcount.Text == "" || txtcountname.Text == "")
        {
            string script = "alert(' Error Occured!  some data may be missing.. please fill!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }
        try
        {

            string req = grdDetail.SelectedRow.Cells[1].Text;
            SqlCommand cmd = new SqlCommand("jct_ops_yarn_purchase_specs", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = req;
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = Session["empcode"];
            cmd.Parameters.Add("@areacode", SqlDbType.VarChar, 10).Value = "1044";
            cmd.Parameters.Add("@actual_count_denier", SqlDbType.VarChar, 30).Value = txtcount.Text;
            cmd.Parameters.Add("@count_cv ", SqlDbType.VarChar, 20).Value = txtcountcv.Text;
            cmd.Parameters.Add("@tenacity", SqlDbType.VarChar, 20).Value = Txttenacity.Text;
            cmd.Parameters.Add("@elongation", SqlDbType.VarChar, 20).Value = txtelongation.Text;
            cmd.Parameters.Add("@OPU", SqlDbType.VarChar, 20).Value = txtOPU.Text;
            cmd.Parameters.Add("@nip_mtr", SqlDbType.VarChar, 20).Value = txtnip.Text;
            cmd.Parameters.Add("@BWS ", SqlDbType.VarChar, 20).Value = txtBWS.Text;
            cmd.Parameters.Add("@CSP ", SqlDbType.VarChar, 20).Value = txtCSP.Text;
            cmd.Parameters.Add("@U_percnt", SqlDbType.VarChar, 20).Value = txtu.Text;
            cmd.Parameters.Add("@IPI", SqlDbType.VarChar, 20).Value = txtIPI.Text;
            cmd.Parameters.Add("@Hairiness", SqlDbType.VarChar, 20).Value = txtHair.Text;
            cmd.Parameters.Add("@TPI ", SqlDbType.VarChar, 20).Value = txtTPI.Text;
            cmd.Parameters.Add("@Blend_per", SqlDbType.VarChar, 30).Value = txtBlend.Text;
            cmd.Parameters.Add("@classimate_faults ", SqlDbType.VarChar, 30).Value = txtclassimate.Text;
            cmd.Parameters.Add("@all_faults", SqlDbType.VarChar, 30).Value = txtallfaults.Text;
            cmd.Parameters.Add("@Major_short_Thick", SqlDbType.VarChar, 30).Value = txtmajorthick.Text;
            cmd.Parameters.Add("@short_thick", SqlDbType.VarChar, 20).Value = txtshortthick.Text;
            cmd.Parameters.Add("@long_thick ", SqlDbType.VarChar, 20).Value = txtlngthick.Text;
            cmd.Parameters.Add("@Thin_faults", SqlDbType.VarChar, 20).Value = txtthinfaults.Text;
            cmd.Parameters.Add("@Major_thin", SqlDbType.VarChar, 20).Value = txtmajorthin.Text;

            cmd.Parameters.Add("@lusture", SqlDbType.VarChar, 10).Value = txtlust.Text;
            cmd.Parameters.Add("@countname", SqlDbType.VarChar, 50).Value = txtcountname.Text;
            cmd.Parameters.Add("@lycra_spandex", SqlDbType.VarChar, 20).Value = txtlycrapercnt.Text;

            cmd.Parameters.Add("@lycra_spandex_denier", SqlDbType.VarChar, 20).Value = txtlycradenier.Text;
            cmd.ExecuteNonQuery();
            con.Close();




            string script = "alert(' record saved sucesfully.!!  please press clear button!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lnkapply.Enabled = false;


           // cmd = new SqlCommand("jct_ops_yarn_comp_req", con);

            cmd = new SqlCommand("jct_ops_yarn_enq", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = req;
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail2.DataSource = ds.Tables[0];
            grdDetail2.DataBind();
            sendmail();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void lnkclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("yarnspecs.aspx");
    }
    protected void lnkdel_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("delete", con);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = lbid.Text;
    }
    protected void lnkUpt_Click(object sender, EventArgs e)
    {
        string req = grdDetail.SelectedRow.Cells[1].Text;
        SqlCommand cmd = new SqlCommand("jct_ops_yarn_purchase_specs_update", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();

        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = req;
        cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = Session["empcode"];
        cmd.Parameters.Add("@areacode", SqlDbType.VarChar, 10).Value = "1044";
        cmd.Parameters.Add("@actual_count_denier", SqlDbType.VarChar, 30).Value = txtcount.Text;
        cmd.Parameters.Add("@count_cv ", SqlDbType.VarChar, 20).Value = txtcountcv.Text;
        cmd.Parameters.Add("@tenacity", SqlDbType.VarChar, 20).Value = Txttenacity.Text;
        cmd.Parameters.Add("@elongation", SqlDbType.VarChar, 20).Value = txtelongation.Text;
        cmd.Parameters.Add("@OPU", SqlDbType.VarChar, 20).Value = txtOPU.Text;
        cmd.Parameters.Add("@nip_mtr", SqlDbType.VarChar, 20).Value = txtnip.Text;
        cmd.Parameters.Add("@BWS ", SqlDbType.VarChar, 20).Value = txtBWS.Text;
        cmd.Parameters.Add("@CSP ", SqlDbType.VarChar, 20).Value = txtCSP.Text;
        cmd.Parameters.Add("@U_percnt", SqlDbType.VarChar, 20).Value = txtu.Text;
        cmd.Parameters.Add("@IPI", SqlDbType.VarChar, 20).Value = txtIPI.Text;
        cmd.Parameters.Add("@Hairiness", SqlDbType.VarChar, 20).Value = txtHair.Text;
        cmd.Parameters.Add("@TPI ", SqlDbType.VarChar, 20).Value = txtTPI.Text;
        cmd.Parameters.Add("@Blend_per", SqlDbType.VarChar, 30).Value = txtBlend.Text;
        cmd.Parameters.Add("@classimate_faults ", SqlDbType.VarChar, 30).Value = txtclassimate.Text;
        cmd.Parameters.Add("@all_faults", SqlDbType.VarChar, 30).Value = txtallfaults.Text;
        cmd.Parameters.Add("@Major_short_Thick", SqlDbType.VarChar, 30).Value = txtmajorthick.Text;
        cmd.Parameters.Add("@short_thick", SqlDbType.VarChar, 20).Value = txtshortthick.Text;
        cmd.Parameters.Add("@long_thick ", SqlDbType.VarChar, 20).Value = txtlngthick.Text;
        cmd.Parameters.Add("@Thin_faults", SqlDbType.VarChar, 20).Value = txtthinfaults.Text;
        cmd.Parameters.Add("@Major_thin", SqlDbType.VarChar, 20).Value = txtmajorthin.Text;

        cmd.Parameters.Add("@lusture", SqlDbType.VarChar, 10).Value = txtlust.Text;
        cmd.Parameters.Add("@countname", SqlDbType.VarChar, 50).Value = txtcountname.Text;
        cmd.Parameters.Add("@lycra_spandex", SqlDbType.VarChar, 20).Value = txtlycrapercnt.Text;

        cmd.Parameters.Add("@lycra_spandex_denier", SqlDbType.VarChar, 20).Value = txtlycradenier.Text;
        cmd.ExecuteNonQuery();
        con.Close();

        string script = "alert(' record updated sucesfully.!!  please press clear button!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        lnkUpt.Enabled = false;

        cmd = new SqlCommand("jct_ops_yarn_enq", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = req;
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail2.DataSource = ds.Tables[0];
        grdDetail2.DataBind();
    }

    protected void grdDetail2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtreq.Text = grdDetail2.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

        txtcount.Text = grdDetail2.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
        txtcountcv.Text = grdDetail2.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        txtcountname.Text = grdDetail2.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
        txtCSP.Text = grdDetail2.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
        txtu.Text = grdDetail2.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        txtIPI.Text = grdDetail2.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
        txtHair.Text = grdDetail2.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
        txtTPI.Text = grdDetail2.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
        txtBlend.Text = grdDetail2.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
        txtclassimate.Text = grdDetail2.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
        txtallfaults.Text = grdDetail2.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
        txtmajorthick.Text = grdDetail2.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
        txtshortthick.Text = grdDetail2.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
        txtlngthick.Text = grdDetail2.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
        txtthinfaults.Text = grdDetail2.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
        txtmajorthin.Text = grdDetail2.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
        txtlycrapercnt.Text = grdDetail2.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
        txtlycradenier.Text = grdDetail2.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");

        txtlust.Text = grdDetail2.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");
    }

    private void sendmail()
    {

        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;
        string By =string.Empty;

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
        sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + ViewState["usercode"] + "'";

        cmd = new SqlCommand(sql, con);
        con.Open();
        Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                ViewState["sendto"] = Dr["empname"].ToString();
                ViewState["sendtoEmail"] = Dr["email"].ToString();
            }
        }

        Dr.Close();
        con.Close();

        sql = "Select empname from jct_empmast_base where empcode='" + ViewState["usercode"] + "'";
        
        try{
                 By= obj1.FetchValue(sql).ToString();
            }
        catch
            {
            }

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
        sb.AppendLine("Outsourced Yarn Request has been generated in OPS by : " + By + "<br/><br/>");

        sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
        sb.AppendLine("Yarn Specifications has been entered by " + ViewState["RequestBy"] + ".<br/><br/>");
        sb.AppendLine("Raw Material Dept have to proceed futher for the vendor against these specification");
        //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");

        sb.AppendLine("<br /><br/>");

        sb.Append("<a href='http://misdev/FusionApps/OPS/yarn_enquiry.aspx'> Click here  to enter the vendors againt these specifcation..!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");

        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";
        // to = ViewState["usercode"].ToString() +","+ ViewState["Requestby"].ToString()+",dpbadhwar@jctltd.com";//"Spinning@jctltd.com"
        // to="shwetaloria@jctltd.com";
        to = ViewState["sendtoEmail"] + "," + ViewState["RequestByEmail"] + ",dpbadhwar@jctltd.com,laxman@jctltd.com,vinaydogra@jctltd.com,rajgopal@jctltd.com,sanjeevj@jctltd.com,skpalta@jctltd.com,somdutt@jctltd.com,kartarsingh@jctltd.com";//"Spinning@jctltd.com"
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



