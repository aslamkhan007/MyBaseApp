using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

public partial class OPS_outsourced_fab_specs : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");

    Connection con = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_spec_select ", con.Connection());
            con.ConOpen();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            con.ConClose();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        }

    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {

        if (txtends.Text == "" || txtpicks.Text == "")
        {
          string script = "alert(' Error Occured!  some data may be missing.. please fill!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }
        try
        {
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_specs", con.Connection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@specs_add_by", SqlDbType.VarChar, 5).Value = Session["Empcode"];
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@ends_inch", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtends.Text == "" ? 0 : Convert.ToDecimal(txtends.Text));//Convert.ToDecimal(txtends.Text);
            cmd.Parameters.Add("@picks_inch", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtpicks.Text == "" ? 0 : Convert.ToDecimal(txtpicks.Text));//Convert.ToDecimal(txtpicks.Text);
            cmd.Parameters.Add("@warp_count", SqlDbType.VarChar, 10).Value = txtwarp.Text;
            cmd.Parameters.Add("@weft_count", SqlDbType.VarChar, 10).Value = txtweft.Text;
            cmd.Parameters.Add("@width_inch", SqlDbType.VarChar, 20).Value = txtwidth.Text; //Convert.ToDecimal(txtwidth.Text == "" ? 0 : Convert.ToDecimal(txtwidth.Text));//Convert.ToDecimal(txtwidth.Text);
            cmd.Parameters.Add("@blend", SqlDbType.VarChar, 20).Value = txtblend.Text;
            cmd.Parameters.Add("@weave", SqlDbType.VarChar, 20).Value = txtweave.Text;
            cmd.Parameters.Add("@weave_on", SqlDbType.VarChar, 20).Value = txtweaveon.Text;
            cmd.Parameters.Add("@piece_length", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtpiece.Text == "" ? 0 : Convert.ToDecimal(txtpiece.Text));//Convert.ToDecimal(txtpiece.Text);
            cmd.Parameters.Add("@weight_gsm", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtwgt.Text == "" ? 0 : Convert.ToDecimal(txtwgt.Text));//Convert.ToDecimal(txtwgt.Text);
            cmd.Parameters.Add("@size_percnt", SqlDbType.VarChar, 5).Value = txtsize.Text;

            cmd.Parameters.Add("@bs_weft", SqlDbType.VarChar, 20).Value = txtBSweft.Text;
            cmd.Parameters.Add("@bs_warp", SqlDbType.VarChar, 20).Value = txtBSwarp.Text;
            cmd.Parameters.Add("@ts_weft", SqlDbType.VarChar, 20).Value = txtTSweft.Text;
            cmd.Parameters.Add("@ts_warp", SqlDbType.VarChar, 20).Value = txtwarp.Text;
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




            con.ConOpen();
            cmd.ExecuteNonQuery();
            con.ConClose();
            string script = "alert(' record saved sucesfully.!!  please press clear button!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);


            cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_comp_req", con.Connection());
            con.ConOpen();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            con.ConClose();
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
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByText(grdDetail.SelectedRow.Cells[6].Text)); //ddlplant.Items.FindByText(grdDetail.SelectedRow.Cells[6].Text).Value;
        txtfbtype.Text  = grdDetail.SelectedRow.Cells[7].Text;
        ViewState["usercode"] = grdDetail.SelectedRow.Cells[2].Text;
        ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;
          

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //jct_ops_outsrd_dyed_fab_srch_selct  

        SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_srch_select", con.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("requestid", SqlDbType.VarChar, 10).Value = txtreq.Text;

        con.ConOpen();
        cmd.ExecuteNonQuery();
        con.ConClose();

    }
    protected void grdDetail2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtends.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", ""); ;
        txtpicks.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", ""); ;
        txtwarp.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", ""); ;
        txtweft.Text = grdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", ""); ;
        txtwidth.Text = grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", ""); ;
        txtwgt.Text = grdDetail.SelectedRow.Cells[15].Text.Replace("&nbsp;", ""); ;
        txtblend.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", ""); ;
        txtsize.Text = grdDetail.SelectedRow.Cells[16].Text.Replace("&nbsp;", ""); ;
        txtweave.Text = grdDetail.SelectedRow.Cells[12].Text.Replace("&nbsp;", ""); ;
        txtweaveon.Text = grdDetail.SelectedRow.Cells[13].Text.Replace("&nbsp;", ""); ;
        txtpiece.Text = grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", ""); ;
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
       
        SqlCommand cmd = new SqlCommand(sql, con.Connection());
        con.ConOpen();
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
        con.ConClose();
        sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + ViewState["usercode"] + "'";

       cmd = new SqlCommand(sql, con.Connection());
       con.ConOpen();
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
        con.ConClose();
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
        sb.AppendLine(" Fabric Specifications has been entered by " + ViewState["RequestBy"] + ".<br/><br/>");
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

        to = ViewState["sendtoEmail"] + "," + ViewState["RequestByEmail"] + ",dpbadhwar@jctltd.com,laxman@jctltd.com,vinaydogra@jctltd.com,rajgopal@jctltd.com,sanjeevj@jctltd.com,skpalta@jctltd.com,kartarsingh@jctltd.com,somdutt@jctltd.com";//"Spinning@jctltd.com"
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
}