﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

public partial class OPS_Yarn_Enquiry : System.Web.UI.Page
{

    //SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["test"].ConnectionString);
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        //SqlCommand cmd = new SqlCommand("jct_ops_yarn_enq", con);
        SqlCommand cmd = new SqlCommand("jct_ops_yarn_request", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
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
        //ViewState["requestid"] = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        ViewState["usercode"] = grdDetail.SelectedRow.Cells[2].Text;
        ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;

        txtcount.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        txtcountcv.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
        txtcountname.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
        txtCSP.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        txtu.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
        txtIPI.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
        txtHair.Text = grdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
        txtTPI.Text = grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
        txtBlend.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
        txtclassimate.Text = grdDetail.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
        txtallfaults.Text = grdDetail.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
        txtmajorthick.Text = grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
        txtshortthick.Text = grdDetail.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
        txtlngthick.Text = grdDetail.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
        txtthinfaults.Text = grdDetail.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
        txtmajorthin.Text = grdDetail.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
        txtlycrapercnt.Text = grdDetail.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");
        txtlycradenier.Text = grdDetail.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");

        txtlust.Text = grdDetail.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");
        Txttenacity.Text = grdDetail.SelectedRow.Cells[31].Text.Replace("&nbsp;", "");
        txtelongation.Text = grdDetail.SelectedRow.Cells[32].Text.Replace("&nbsp;", "");
        txtOPU.Text = grdDetail.SelectedRow.Cells[33].Text.Replace("&nbsp;", "");
        txtnip.Text = grdDetail.SelectedRow.Cells[34].Text.Replace("&nbsp;", "");
        txtBWS.Text = grdDetail.SelectedRow.Cells[35].Text.Replace("&nbsp;", "");


        SqlCommand cmd = new SqlCommand("select vendername from jct_ops_yarn_mat_tb  where requestid=@requestid", con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            RDlst.DataSource = ds.Tables[0];
            RDlst.DataTextField = "vendername";
            RDlst.DataValueField = "vendername";
            RDlst.DataBind();
            lnkcomparision.Visible = true;

        }
        else
        {
            RDlst.DataSource = ds.Tables[0];
            RDlst.DataBind();
            lnkcomparision.Visible = false;
        }

        con.Close();


        for (int i = 0; i <= RDlst.Items.Count - 1; i++)
        {
            string vndrlist;
            vndrlist = RDlst.Items[i].Text;
            cmd = new SqlCommand("jct_ops_yarn_vndr_list", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 10).Value = vndrlist;
            cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            string output = cmd.Parameters["@flag"].Value.ToString();
            if (output == "1")
            {
                RDlst.Items[i].Selected = false;
            }
            con.Close();
        }
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
       
        if (txtvender.Text == "")
        {
            string script = "alert(' Error Occured!  Please enter a vendor !! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }
        try
        {
            SqlCommand cmd = new SqlCommand("jct_ops_yarn_mat_enq", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = Session["empcode"];
            //cmd.Parameters.Add("@areacode", SqlDbType.VarChar, 10).Value = "1044";
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
            //cmd.Parameters.Add("@lusture", SqlDbType.VarChar, 10).Value = txtlust.Text;
            //cmd.Parameters.Add("@countname", SqlDbType.VarChar, 50).Value = txtcountname.Text;
            //cmd.Parameters.Add("@lycra_spandex", SqlDbType.VarChar, 20).Value = txtlycrapercnt.Text;

            //cmd.Parameters.Add("@lycra_spandex_denier", SqlDbType.VarChar, 20).Value = txtlycradenier.Text;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[17].Text;



            cmd.Parameters.Add("@basicrate", SqlDbType.VarChar, 20).Value = txtbasic.Text;
            cmd.Parameters.Add("@deliveryDt", SqlDbType.VarChar, 20).Value = txtdlidt.Text == "" ? null : txtdlidt.Text;

            cmd.Parameters.Add("@landedrate", SqlDbType.VarChar, 20).Value = txtlandrate.Text;

            if (txtvender.Text.Contains('~'))
            {
                cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 200).Value = txtvender.Text.Split('~')[0];
                cmd.Parameters.Add("@vendorcode", SqlDbType.VarChar, 10).Value = txtvender.Text.Split('~')[1] == "" ? "" : txtvender.Text.Split('~')[1];
            }
            else
            {
                cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 200).Value = txtvender.Text;
                cmd.Parameters.Add("@vendorcode", SqlDbType.VarChar, 10).Value = "";
            }

            cmd.Parameters.Add("@offerquality", SqlDbType.VarChar, 20).Value = txtoffrquqlity.Text;

            cmd.Parameters.Add("@offerqty", SqlDbType.VarChar, 20).Value = txtqty.Text;

            cmd.Parameters.Add("@UOM", SqlDbType.VarChar, 20).Value = ddluom.Text;
            cmd.Parameters.Add("@ratetype", SqlDbType.VarChar, 20).Value = ddlrate.Text;
            cmd.Parameters.Add("@payterms", SqlDbType.VarChar, 20).Value = txtpaytrm.Text;
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Value = "";
            //cmd.Parameters.Add("@lusture", SqlDbType.VarChar, 10).Value = txtlust.Text;
            //cmd.Parameters.Add("@countname", SqlDbType.VarChar, 50).Value = txtcountname.Text;
            cmd.Parameters.Add("@lycra_spandex", SqlDbType.VarChar, 20).Value = txtlycrapercnt.Text;

            cmd.Parameters.Add("@lycra_spandex_denier", SqlDbType.VarChar, 20).Value = txtlycradenier.Text;


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



            string script = "alert(' record saved sucesfully.!!  please press clear button!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //lnkSave.Enabled = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {

    }
    protected void Lnkclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("Yarn_Enquiry.aspx");
    }
    protected void lnkfrezvend_Click(object sender, EventArgs e)
    {

        if (txtvender.Text == "")
        {
            string script = "alert(' Error Occured!  Please enter a vendor !! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }
        {
            SqlCommand cmd = new SqlCommand("jct_ops_yarn_vendor_freeze", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
            cmd.ExecuteNonQuery();
            con.Close();

            string script = "alert(' Vendors are freezed against this Request !! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        sendmail();
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
        else
        {
            ViewState["sendto"] = "";
            ViewState["sendtoEmail"] = "jatindutta@jctltd.com";
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
        sb.AppendLine("Outsourced Yarn Request has been generated in OPS by : " + ViewState["sendto"] + "<br/><br/>");
        sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
        sb.AppendLine("Vendors have been shortlisted by - " + ViewState["RequestBy"] + ", Please finalize the vendor for the same.<br/><br/>");

        sb.AppendLine("<br /><br/>");



        sb.Append("<a href='http://misdev/FusionApps/OPS/yarn_approvals.aspx'> Click here  to select the vendors.!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";
        to = ViewState["sendtoEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString();
        //",dpbadhwar@jctltd.com";//"Spinning@jctltd.com"

        //to="shwetaloria@jctltd.com";
        //to = ViewState["sendtoEmail"] + "," + ViewState["RequestByEmail"];//"Spinning@jctltd.com"
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
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;


    }

    protected void RDlst_SelectedIndexChanged(object sender, EventArgs e)
    {

        string sql = "jct_ops_vendor_details";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd .CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 200).Value = RDlst.SelectedItem.Text;
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;

        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                txtcount.Text = Dr["Actual(count/Denier)"].ToString();
                txtcountcv.Text = Dr["CountCV"].ToString();
                Txttenacity.Text = Dr["tenacity"].ToString();
                txtelongation.Text = Dr["elongation"].ToString();
                txtOPU.Text = Dr["OPU"].ToString();
                txtnip.Text = Dr["nip_mtr"].ToString();
                txtBWS.Text = Dr["BWS"].ToString();
                txtCSP.Text = Dr["CSP"].ToString();
                txtu.Text = Dr["u%"].ToString();
                txtIPI.Text = Dr["IPI"].ToString();
                txtHair.Text = Dr["Hairiness"].ToString();
                txtTPI.Text = Dr["TPI"].ToString();
                txtBlend.Text = Dr["Blend%"].ToString();
                txtclassimate.Text = Dr["ClassimateFaults"].ToString();
                txtallfaults.Text = Dr["AllFaults"].ToString();
                txtmajorthick.Text = Dr["MajorShortThick"].ToString();
                txtshortthick.Text = Dr["ShortThick"].ToString();
                txtlngthick.Text = Dr["LongThick"].ToString();
                txtthinfaults.Text = Dr["ThinFaults"].ToString();
                txtmajorthin.Text = Dr["MajorThin"].ToString();
                txtbasic.Text = Dr["basicrate"].ToString();
                txtdlidt.Text = Dr["deliveryDt"].ToString();
                txtlandrate.Text = Dr["landedrate"].ToString();
                txtvender.Text = Dr["vendername"].ToString();
                txtoffrquqlity.Text = Dr["offerquality"].ToString();
                txtqty.Text = Dr["offerqty"].ToString();
                ddluom.Text = Dr["uom"].ToString();
                ddlrate.Text = Dr["ratetype"].ToString();
                txtpaytrm.Text = Dr["payterms"].ToString();
                txtlycrapercnt.Text = Dr["lycraspandex"].ToString();
                txtlycradenier.Text = Dr["lycraspandexdenier"].ToString();
                txtcountname.Text = Dr["Countname"].ToString();


            }
        }
    }

    protected void lnkcomparision_Click(object sender, EventArgs e)
    {
        string url = "Popup.aspx?reqid=" + ViewState["RequestID"] + "";
        string s = "window.open('" + url + "', 'popup_window', 'width=400,height=200,left=100,top=100,resizable=yes,scrollbars=1');";
        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
    }
}


