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

public partial class OPS_outsrcd_fab_enquiry : System.Web.UI.Page
{

    //SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["test"].ConnectionString);
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");

        }

        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_comp_req", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = lbid.Text;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            con.Close();
        }
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["usercode"] = grdDetail.SelectedRow.Cells[2].Text;

        ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;
        txtends.Text = grdDetail.SelectedRow.Cells[27].Text.Replace("&nbsp;", ""); ;
        txtpicks.Text = grdDetail.SelectedRow.Cells[28].Text.Replace("&nbsp;", ""); ;
        txtwarp.Text = grdDetail.SelectedRow.Cells[30].Text.Replace("&nbsp;", ""); ;
        txtweft.Text = grdDetail.SelectedRow.Cells[29].Text.Replace("&nbsp;", ""); ;
        //txtwidth.Text = grdDetail.SelectedRow.Cells[31].Text.Replace("&nbsp;", ""); ;
        txtwgt.Text = grdDetail.SelectedRow.Cells[36].Text.Replace("&nbsp;", ""); ;
        txtblend.Text = grdDetail.SelectedRow.Cells[32].Text.Replace("&nbsp;", ""); ;
        //txtsize.Text = grdDetail.SelectedRow.Cells[37].Text.Replace("&nbsp;", ""); ;
        txtweave.Text = grdDetail.SelectedRow.Cells[33].Text.Replace("&nbsp;", ""); ;
        txtweaveon.Text = grdDetail.SelectedRow.Cells[34].Text.Replace("&nbsp;", ""); ;
        txtpiece.Text = grdDetail.SelectedRow.Cells[35].Text.Replace("&nbsp;", ""); ;
        txtAbrasion.Text = grdDetail.SelectedRow.Cells[47].Text.Replace("&nbsp;", ""); ;
        txtabsorbency.Text = grdDetail.SelectedRow.Cells[46].Text.Replace("&nbsp;", ""); ;
        txtBSwarp.Text = grdDetail.SelectedRow.Cells[38].Text.Replace("&nbsp;", ""); ;
        txtBSweft.Text = grdDetail.SelectedRow.Cells[39].Text.Replace("&nbsp;", ""); ;
        txtCIE.Text = grdDetail.SelectedRow.Cells[45].Text.Replace("&nbsp;", ""); ;
        txtcust.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", ""); ;
        txtdeli.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", ""); ;
        txtdelivdt.Text = grdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", ""); ;
        txtends.Text = grdDetail.SelectedRow.Cells[27].Text.Replace("&nbsp;", ""); ;
        txtfinishsale.Text = grdDetail.SelectedRow.Cells[23].Text.Replace("&nbsp;", ""); ;
        txtgrabwarp.Text = grdDetail.SelectedRow.Cells[43].Text.Replace("&nbsp;", ""); ;
        txtgrabweft.Text = grdDetail.SelectedRow.Cells[42].Text.Replace("&nbsp;", ""); ;
        txtmkt.Text = grdDetail.SelectedRow.Cells[12].Text.Replace("&nbsp;", ""); ;
        txtMPS.Text = grdDetail.SelectedRow.Cells[44].Text.Replace("&nbsp;", ""); ;
        txtnum.Text = grdDetail.SelectedRow.Cells[25].Text.Replace("&nbsp;", ""); ;
        txtpayment.Text = grdDetail.SelectedRow.Cells[21].Text.Replace("&nbsp;", ""); ;
        txtpH.Text = grdDetail.SelectedRow.Cells[48].Text.Replace("&nbsp;", ""); ;
        txtpiece.Text = grdDetail.SelectedRow.Cells[35].Text.Replace("&nbsp;", ""); ;
        txtpoint.Text = grdDetail.SelectedRow.Cells[50].Text.Replace("&nbsp;", ""); ;
        txtpurchase.Text = grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", ""); ;
        txtqtyreq.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", ""); ;
        txtremark.Text = grdDetail.SelectedRow.Cells[16].Text.Replace("&nbsp;", ""); ;
        txtshrnkwarp.Text = grdDetail.SelectedRow.Cells[51].Text.Replace("&nbsp;", ""); ;
        txtshrnkweft.Text = grdDetail.SelectedRow.Cells[52].Text.Replace("&nbsp;", ""); ;
        txttegewa.Text = grdDetail.SelectedRow.Cells[49].Text.Replace("&nbsp;", ""); ;
        txtTSwarp.Text = grdDetail.SelectedRow.Cells[40].Text.Replace("&nbsp;", ""); ;
        txtTSweft.Text = grdDetail.SelectedRow.Cells[41].Text.Replace("&nbsp;", ""); ;

        txtso.Text = grdDetail.SelectedRow.Cells[15].Text.Replace("&nbsp;", ""); ;
        txtsort.Text = grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", ""); ;
        txtspecial.Text = grdDetail.SelectedRow.Cells[13].Text.Replace("&nbsp;", ""); ;


        txtfbtype.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", ""); ;

        ddlfreight.SelectedIndex = ddlfreight.Items.IndexOf(ddlfreight.Items.FindByText(grdDetail.SelectedRow.Cells[20].Text));
        ddlpack.SelectedIndex = ddlpack.Items.IndexOf(ddlpack.Items.FindByText(grdDetail.SelectedRow.Cells[19].Text));
        ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByText(grdDetail.SelectedRow.Cells[6].Text));

        SqlCommand cmd = new SqlCommand("select vendor from jct_ops_out_fab_vendor  where requestid=@requestid and status='a'", con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        RDlst.DataSource = ds.Tables[0];

        RDlst.DataTextField = "vendor";
        RDlst.DataValueField = "vendor";
        RDlst.DataBind();

        con.Close();


        for (int i = 0; i <= RDlst.Items.Count - 1; i++)
        {
            string vndrlist;
            vndrlist = RDlst.Items[i].Text;
            cmd = new SqlCommand("jct_ops_fab_vndr_list", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 10).Value = vndrlist;
            cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            con.Close();
            string output = cmd.Parameters["@flag"].Value.ToString();
            if (output == "1")
            {
                RDlst.Items[i].Selected = false;
            }

        }
    }

    //protected void  lnkclr_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("outsrcd_fab_enquiry.aspx");
    //}

    protected void lnkclr_Click(object sender, EventArgs e)
    {
        Response.Redirect("outsrcd_fab_enquiry.aspx");
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        //jct_ops_outsrd_dyed_fab_vendor

        if (txtvendor.Text == "" && txtrate.Text == "")
        {
            string script = "alert(' Error Occured!  Please enter a vendor and Rate per mtr !! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }


        SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_vendor_modified", con);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = Session["Empcode"];

        cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;
        if (txtvendor.Text.Contains('~'))
        {
            cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 200).Value = txtvendor.Text.Split('~')[0];
            cmd.Parameters.Add("@vendorcode", SqlDbType.VarChar, 10).Value = txtvendor.Text.Split('~')[1] == "" ? "" : txtvendor.Text.Split('~')[1];
        }
        else
        {
            cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 200).Value = txtvendor.Text;
            cmd.Parameters.Add("@vendorcode", SqlDbType.VarChar, 10).Value = "";
        }
        cmd.Parameters.Add("@ends_inch", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtends.Text == "" ? 0 : Convert.ToDecimal(txtends.Text));//Convert.ToDecimal(txtends.Text);
        cmd.Parameters.Add("@picks_inch", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtpicks.Text == "" ? 0 : Convert.ToDecimal(txtpicks.Text));//Convert.ToDecimal(txtpicks.Text);
        cmd.Parameters.Add("@warp_count", SqlDbType.VarChar, 10).Value = txtwarp.Text;
        cmd.Parameters.Add("@weft_count", SqlDbType.VarChar, 10).Value = txtweft.Text;
        //cmd.Parameters.Add("@width_inch", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtwidth.Text == "" ? 0 : Convert.ToDecimal(txtwidth.Text));//Convert.ToDecimal(txtwidth.Text);
        cmd.Parameters.Add("@blend", SqlDbType.VarChar, 20).Value = txtblend.Text;
        cmd.Parameters.Add("@weave", SqlDbType.VarChar, 20).Value = txtweave.Text;
        cmd.Parameters.Add("@weave_on", SqlDbType.VarChar, 20).Value = txtweaveon.Text;
        cmd.Parameters.Add("@piece_length", SqlDbType.Decimal).Value = Convert.ToDecimal(txtpiece.Text == "" ? 0 : Convert.ToDecimal(txtpiece.Text));//Convert.ToDecimal(txtpiece.Text);
        cmd.Parameters.Add("@weight_gsm", SqlDbType.Decimal).Value = Convert.ToDecimal(txtwgt.Text == "" ? 0 : Convert.ToDecimal(txtwgt.Text));//Convert.ToDecimal(txtwgt.Text);
       // cmd.Parameters.Add("@size_percnt", SqlDbType.VarChar, 5).Value = txtsize.Text;

        cmd.Parameters.Add("@bs_weft", SqlDbType.VarChar, 20).Value = txtBSweft.Text;
        cmd.Parameters.Add("@bs_warp", SqlDbType.VarChar, 20).Value = txtBSwarp.Text;
        cmd.Parameters.Add("@ts_weft", SqlDbType.VarChar, 20).Value = txtTSweft.Text;
        cmd.Parameters.Add("@ts_warp", SqlDbType.VarChar, 20).Value = txtTSwarp.Text;
        cmd.Parameters.Add("@Grab_weft", SqlDbType.VarChar, 20).Value = txtgrabweft.Text;
        cmd.Parameters.Add("@Grab_warp", SqlDbType.VarChar, 20).Value = txtgrabwarp.Text;
        cmd.Parameters.Add("@MPS", SqlDbType.VarChar, 20).Value = txtMPS.Text;
        cmd.Parameters.Add("@CIE", SqlDbType.VarChar, 20).Value = txtCIE.Text;

        cmd.Parameters.Add("@absorbency", SqlDbType.VarChar, 20).Value = txtabsorbency.Text;
        cmd.Parameters.Add("@Abrasion", SqlDbType.VarChar, 20).Value = txtAbrasion.Text;
        cmd.Parameters.Add("@pH ", SqlDbType.VarChar, 20).Value = txtpH.Text;
        cmd.Parameters.Add("@Tegawa", SqlDbType.VarChar, 20).Value = txttegewa.Text;
        cmd.Parameters.Add("@points", SqlDbType.VarChar, 20).Value = txtpoint.Text;
        cmd.Parameters.Add("@shrnkweft", SqlDbType.VarChar, 20).Value = txtshrnkweft.Text;
        cmd.Parameters.Add("@shrnkwarp", SqlDbType.VarChar, 20).Value = txtshrnkwarp.Text;
        cmd.Parameters.Add("@rate_per_mtr", SqlDbType.Decimal).Value =Convert.ToDecimal(txtrate.Text);

        cmd.Parameters.Add("@qty_req", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtqtyreq.Text);
        cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Text;
        cmd.Parameters.Add("@fbtype", SqlDbType.VarChar, 20).Value = txtfbtype.Text;
        cmd.Parameters.Add("@delivery_remarks", SqlDbType.VarChar, 255).Value = txtdeli.Text;
        //cmd.Parameters.Add("@delivery_dt", SqlDbType.VarChar, 20).Value = txtdelivdt.Text == "" ? null : txtdelivdt.Text;

        if (txtdelivdt.Text != string.Empty)
        {
            cmd.Parameters.Add("@delivery_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdelivdt.Text);
        }

        cmd.Parameters.Add("@parallel_sort", SqlDbType.VarChar, 10).Value = txtsort.Text;
        cmd.Parameters.Add("@finish_fab_cust_name", SqlDbType.VarChar, 255).Value = txtcust.Text;
        cmd.Parameters.Add("@ref_mkt_exec", SqlDbType.VarChar, 255).Value = txtmkt.Text;
        cmd.Parameters.Add("@purchase", SqlDbType.Decimal).Value = txtpurchase.Text == "" ? 0 : Convert.ToDecimal(txtpurchase.Text);
        cmd.Parameters.Add("@sale_order", SqlDbType.VarChar, 50).Value = txtso.Text;
        cmd.Parameters.Add("@pack_detail", SqlDbType.VarChar, 255).Value = ddlpack.SelectedItem.Text;
        cmd.Parameters.Add("@Freight_chrgs", SqlDbType.VarChar, 50).Value = ddlfreight.SelectedItem.Text;
        cmd.Parameters.Add("@paymnt_deliv_term", SqlDbType.VarChar, 100).Value = txtpayment.Text;
        cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 200).Value = txtremark.Text;
        cmd.Parameters.Add("@selvage", SqlDbType.VarChar, 20).Value = txtselvage.Text;
        cmd.Parameters.Add("@greywidth", SqlDbType.VarChar, 20).Value = txtgreywidth.Text;
        cmd.Parameters.Add("@finishwidth", SqlDbType.VarChar, 20).Value = txtfinishwidth.Text;
        cmd.Parameters.Add("@ratetype", SqlDbType.VarChar, 20).Value = ddlratetype.SelectedItem.Text;
        cmd.Parameters.Add("@agent", SqlDbType.VarChar, 20).Value = txtagent.Text;
        if (txtvaliddate.Text != string.Empty)
        {
            cmd.Parameters.Add("@valid_dt", SqlDbType.VarChar, 20).Value = Convert.ToDateTime(txtvaliddate.Text);
        }
        



        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        string script3 = "alert(' record saved sucesfully.!!  please press clear button!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script3, true);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtvendor.Text == "" && txtrate.Text == "")
            {
                string script = "alert('Please enter vendor and Rate per Mtr !!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                return;
            }

            SqlCommand cmd = new SqlCommand("jct_ops_fab_vendor_freeze", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
            cmd.ExecuteNonQuery();
            con.Close();

            string script2 = "alert(' Vendors are freezed against this Request !! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

            //sendmail();
            sendmailVendor();
        }
        catch
        { 
        
        }
        
    }



    //private void sendmail()
    //{

    //    string @from = null;
    //    string to = null;
    //    string bcc = null;
    //    string cc = null;
    //    string subject = null;
    //    string body = null;



    //    string sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";

    //    SqlCommand cmd = new SqlCommand(sql, con);
    //    con.Open();
    //    SqlDataReader Dr = cmd.ExecuteReader();
    //    if (Dr.HasRows)
    //    {
    //        while (Dr.Read())
    //        {
    //            ViewState["RequestBy"] = Dr["empname"].ToString();
    //            ViewState["RequestByEmail"] = Dr["email"].ToString();
    //        }
    //    }
    //    else
    //    {
    //        ViewState["RequestBy"] = "";
    //        ViewState["RequestByEmail"] = "jatindutta@jctltd.com";
    //    }

    //    Dr.Close();
    //    con.Close();
    //    sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + ViewState["usercode"] + "'";

    //    cmd = new SqlCommand(sql, con);
    //    con.Open();
    //    Dr = cmd.ExecuteReader();
    //    if (Dr.HasRows)
    //    {
    //        while (Dr.Read())
    //        {
    //            ViewState["sendto"] = Dr["empname"].ToString();
    //            ViewState["sendtoEmail"] = Dr["email"].ToString();
    //        }
    //    }


    //    Dr.Close();
    //    con.Close();
    //    StringBuilder sb = new StringBuilder();

    //    sb.AppendLine("<html>");
    //    sb.AppendLine("<head>");
    //    sb.AppendLine("<style type=\"text/css\">");
    //    sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
    //    sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
    //    sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
    //    sb.AppendLine("</style>");
    //    sb.AppendLine("</head>");

    //    sb.AppendLine("Hi,<br/>");
    //    sb.AppendLine("Outsourced Fabric Request has been generated in OPS by : " + ViewState["RequestBy"] + "<br/><br/>");

    //    sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
    //    sb.AppendLine("Vendors have been shortlisted, Please finalize the vendor for the same <br/><br/>");
    //    //sb.AppendLine("Please finalize the vendor for the same");
    //    //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");




    //    sb.AppendLine("<br /><br/>");



    //    sb.Append("<a href='http://testerp/FusionApps/OPS/outsrcd_fab_enquiry.aspx'> Click here  to select the vendors.!! </a><br />");

    //    sb.AppendLine("</table><br />");

    //    sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
    //    sb.AppendLine("Thank you<br />");
    //    sb.AppendLine("</html>");


    //    body = sb.ToString();
    //    @from = "Outsourcing@jctltd.com";
    //    // to = ViewState["usercode"].ToString() +","+ ViewState["Requestby"].ToString()+",dpbadhwar@jctltd.com";//"Spinning@jctltd.com"
    //    // to="shwetaloria@jctltd.com";
    //    to = ViewState["sendtoEmail"] + "," + ViewState["RequestByEmail"];//"Spinning@jctltd.com"
    //    //to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString();

    //    //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
    //    bcc = "shwetaloria@jctltd.com";
    //    subject = "Outsourced Yarn Request - " + ViewState["RequestID"];
    //    MailMessage mail = new MailMessage();
    //    mail.From = new MailAddress(@from);
    //    if (to.Contains(","))
    //    {
    //        string[] tos = to.Split(',');
    //        for (int i = 0; i <= tos.Length - 1; i++)
    //        {
    //            mail.To.Add(new MailAddress(tos[i]));
    //        }
    //    }
    //    else
    //    {
    //        mail.To.Add(new MailAddress(to));
    //    }

    //    if (!string.IsNullOrEmpty(bcc))
    //    {
    //        if (bcc.Contains(","))
    //        {
    //            string[] bccs = bcc.Split(',');
    //            for (int i = 0; i <= bccs.Length - 1; i++)
    //            {
    //                mail.Bcc.Add(new MailAddress(bccs[i]));
    //            }
    //        }
    //        else
    //        {
    //            mail.Bcc.Add(new MailAddress(bcc));
    //        }
    //    }
    //    //If Not String.IsNullOrEmpty(cc) Then
    //    //    If cc.Contains(",") Then
    //    //        Dim ccs As String() = cc.Split(","c)
    //    //        For i As Integer = 0 To ccs.Length - 1
    //    //            mail.CC.Add(New MailAddress(ccs(i)))
    //    //        Next
    //    //    Else
    //    //        mail.CC.Add(New MailAddress(bcc))
    //    //    End If
    //    //    mail.CC.Add(New MailAddress(cc))
    //    //End If

    //    mail.Subject = subject;

    //    mail.Body = body;
    //    mail.IsBodyHtml = true;
    //    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //    SmtpClient SmtpMail = new SmtpClient("exchange2007");

    //    //SmtpMail.SmtpServer = "exchange2007";
    //    SmtpMail.Send(mail);
    //    //return mail;


    //}

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
        sb.AppendLine("Outsourced Fabric Request has been generated in OPS by : " + ViewState["RequestBy"] + "<br/><br/>");

        sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
        sb.AppendLine("Vendors have been shortlisted, Please finalize the vendor for the same.<br/><br/>");
        //sb.AppendLine("Please finalize the vendor for the same");
        sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");




        sb.AppendLine("<br /><br/>");



        sb.Append("<a href='http://testerp/FusionApps/OPS/outsrcd_fab_enquiry.aspx'> Click here  to select the vendors.!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";
        to = ViewState["sendtoEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString() + ",dpbadhwar@jctltd.com";//"Spinning@jctltd.com"
        // to="shwetaloria@jctltd.com";
        //to = ViewState["sendtoEmail"] + "," + ViewState["RequestByEmail"];//"Spinning@jctltd.com"
        //to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString();

        bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
        //bcc = "shwetaloria@jctltd.com";
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

    private void sendmailVendor()
    {
        try
        {
            string sql = string.Empty;
            string to = string.Empty;
            string from = string.Empty;
            string bcc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;

            sql = "jct_ops_fab_vendor_freeze_mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //to = "shwetaloria@jctltd.com,jatindutta@jctltd.com";
                    to = dr["sendtomail"].ToString();
                    body = dr["email_body"].ToString();
                    subject = dr["subject"].ToString();
                }
            }
            else
            {

            }


            @from = "Outsourcing@jctltd.com";

            bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";

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
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
            SmtpMail.Send(mail);
        }
        catch
        {

        }
    }


    protected void RDlst_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = "jct_ops_vendor_details_fab";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 200).Value = RDlst.SelectedItem.Text;
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;

        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {

                   txtvendor.Text=Dr["vendor"].ToString();
                   txtends.Text = Dr["ends_inch"].ToString();
                   txtpicks.Text = Dr["picks_inch"].ToString();
                   txtwarp.Text = Dr["warp_count"].ToString();
                   txtweft.Text = Dr["weft_count"].ToString();
                  // txtwidth.Text = Dr["width_inch"].ToString();
                   txtblend.Text = Dr["blend"].ToString();
                   txtweave.Text = Dr["weave"].ToString();
                   txtweaveon.Text = Dr["weave_on"].ToString();
                   txtpiece.Text = Dr["piece_length"].ToString();
                   txtwgt.Text = Dr["weight_gsm"].ToString();
                  // txtsize.Text = Dr["size_percnt"].ToString();
                   txtBSweft.Text = Dr["bs_weft"].ToString();
                   txtBSwarp.Text = Dr["bs_warp"].ToString();
                   txtTSweft.Text = Dr["ts_weft"].ToString();
                   txtTSwarp.Text= Dr["ts_warp"].ToString();
                   txtgrabweft.Text = Dr["Grab_weft"].ToString();
                   txtgrabwarp.Text = Dr["Grab_warp"].ToString();
                   txtMPS.Text = Dr["MPS"].ToString();
                   txtCIE.Text = Dr["CIE"].ToString();
                   txtabsorbency.Text = Dr["absorbency"].ToString();
                   txtAbrasion.Text = Dr["Abrasion"].ToString();
                   txtpH.Text = Dr["pH"].ToString();
                   txttegewa.Text = Dr["Tegawa"].ToString();
                   txtpoint.Text = Dr["points"].ToString();
                   txtshrnkweft.Text = Dr["shrnkweft"].ToString();
                   txtshrnkwarp.Text = Dr["shrnkwarp"].ToString();
                   txtrate.Text = Dr["rate_per_mtr"].ToString();
                   txtqtyreq.Text = Dr["qty_req"].ToString();
                   ddlplant.Text=Dr["plant"].ToString();
                   txtfbtype.Text = Dr["fbtype"].ToString();
                   txtpayment.Text = Dr["paymnt_deliv_term"].ToString();
                   txtdelivdt.Text = Dr["delivery_dt"].ToString();
                   txtsort.Text = Dr["parallel_sort"].ToString();
                   txtcust.Text = Dr["finish_fab_cust_name"].ToString();
                   txtmkt.Text = Dr["ref_mkt_exec"].ToString();
                   txtpurchase.Text = Dr["purchase"].ToString();
                   txtso.Text = Dr["sale_order"].ToString();
                   ddlpack.Text = Dr["pack_detail"].ToString();
                   ddlfreight.Text = Dr["Freight_chrgs"].ToString();
  
            }
        }

    }
   
}
