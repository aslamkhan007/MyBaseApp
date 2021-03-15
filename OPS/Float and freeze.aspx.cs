using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Text;
using System.Net.Mail;

public partial class OPS_Float_and_freeze : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["test"].ConnectionString);
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Functions objFun = new Functions();
    Connection obj = new Connection();
    string qry = null;
 
    SqlTransaction Tran;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_float_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@flag", SqlDbType.Char, 1).Value = "c";
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();

            cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_float_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@flag", SqlDbType.Char, 1).Value = "i";
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            grdDetailIn.DataSource = ds.Tables[0];
            grdDetailIn.DataBind();
            grdDetailIn.Visible = true;
        }
    }
    protected void btnTransfer_Click(object sender, EventArgs e)
   
         {
        ListItem  litem ;
        
        for(int i=0; i <=ChkEmpList.Items.Count-1;i++)
        { 
            if(ChkEmpList.Items[i].Selected==true)
            {
        
            litem= new ListItem(ChkEmpList.Items[i].Text,ChkEmpList.Items[i].Value);
                ChkDynamicListing.Items.Add(litem);
            }
        }
        
         }
    
    protected void cmdCC_Click(object sender, EventArgs e)
    {
        ListItem litem;

        for (int i = 0; i <= ChkEmpList.Items.Count - 1; i++)
        {
            if (ChkEmpList.Items[i].Selected == true)
            {

                litem = new ListItem(ChkEmpList.Items[i].Text, ChkEmpList.Items[i].Value);
                chkNotify.Items.Add(litem);

            }


        }
    }
    protected void imgRemoveItem_Click(object sender, EventArgs e)
    {

        int i = 0;
        int CountItems = ChkDynamicListing.Items.Count;
        for (i = 0; i == CountItems - 1; i++)
        {
            if (CountItems > 0)
            {
                if (ChkDynamicListing.Items[i].Selected == true)
                {
                    ChkDynamicListing.Items.RemoveAt(i);
                    CountItems -= 1;

                }


            }
        }
        CountItems = 0;
        CountItems = chkNotify.Items.Count;
        for (i = 0; i == CountItems - 1; i++)
        {
            if (CountItems > 0)
            {
                if (chkNotify.Items[i].Selected == true)
                {
                    chkNotify.Items.RemoveAt(i);
                    CountItems -= 1;


                }


            }
        }

    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
      
        SqlCommand cmd = new SqlCommand("SELECT a.empcode,(a.empname+'~'+b.DEPTNAME) as [desc] FROM JCT_EmpMast_Base a,DEPTMAST b WHERE empname LIKE '%" + txtEmployee.Text + "%' AND Active='y' AND a.deptcode=b.DEPTCODE ORDER BY empname", con);
        cmd.CommandType = CommandType.Text;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ChkEmpList.DataSource = ds.Tables[0];
        ChkEmpList.DataTextField = "desc";
        ChkEmpList.DataValueField = "empcode";
        ChkEmpList.DataBind();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdlst.SelectedIndex == 0)
        {
       
                
                SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_float_select", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Char, 1).Value = "c";
                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
        
               cmd= new SqlCommand("jct_ops_outsrd_dyed_fab_float_select", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Char, 1).Value = "i";

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                grdDetailIn.DataSource = ds.Tables[0];
                grdDetailIn.DataBind();
              



            }

          if (rdlst.SelectedIndex == 1)
          {

              lbreq.Visible = false;

                SqlCommand cmd = new SqlCommand("jct_ops_float_wrdrobe", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Char, 1).Value = "c";
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                grdDetailyr.Visible = true;

                cmd = new SqlCommand("jct_ops_float_wrdrobe", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Char, 1).Value = "i";
                 

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                grdDetailIn.DataSource = ds.Tables[0];
                grdDetailIn.DataBind();
                grdDetailyr.Visible = true;
        



             
          }
          if (rdlst.SelectedIndex == 2)
          {
             
              SqlCommand cmd = new SqlCommand("jct_ops_yarn_select_freeze", con);
              con.Open();
              cmd.CommandType = CommandType.StoredProcedure;
              //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = lbid.Text;
              cmd.ExecuteNonQuery();
              con.Close();
              SqlDataAdapter da = new SqlDataAdapter(cmd);
              DataSet ds = new DataSet();
              da.Fill(ds);
              grdDetail.DataSource = ds.Tables[0];
              grdDetail.DataBind();
              grdDetailIn.Visible = false;
              lbreq.Visible = false;


           


          }

    }
    protected void cmdApply_Click(object sender, EventArgs e)
    {
        //SqlCommand cmd1 = new SqlCommand(" select top 1 id  from jct_ops_sanctionnote_authorization_listing where id='yr-107'", con);
        //cmd1.CommandType = CommandType.Text;
        //cmd1.ExecuteScalar();

      
        int userlevel = 0;
     
        SqlCommand cmd;
       
        con.Open();
         
        try
        {

            Tran = con.BeginTransaction();
            for (int i = 0; i <= ChkDynamicListing.Items.Count - 1; i++)
            {
                if (ChkDynamicListing.Items[i].Selected == true)
                {
                  
                    userlevel = 0;
                    userlevel = i + 1;
                    cmd = new SqlCommand("jct_ops_outsor_level", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 20).Value = ViewState["requestID"];
                    cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                    cmd.Parameters.Add("@areacode", SqlDbType.VarChar, 20).Value = ViewState["AreaCode"];
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = ChkDynamicListing.Items[1].Value;
                    cmd.Parameters.Add("@userlevel", SqlDbType.Int).Value = userlevel;
                    cmd.Transaction = Tran;
                    cmd.ExecuteNonQuery();
                }
            }

            if (rdlst.SelectedIndex == 0)
            {

                cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_freeze", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@freezeby", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                cmd.Transaction = Tran;
                cmd.ExecuteNonQuery();
       


            }
            if (rdlst.SelectedIndex == 1)
            {
              
                cmd = new SqlCommand("jct_ops_outsrd_wardrobe_freeze", con);
         
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@reqid", SqlDbType.VarChar,10).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@freeze_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                cmd.Transaction = Tran;
                cmd.ExecuteNonQuery();
          
            }
            if (rdlst.SelectedIndex == 2)
            {
                cmd = new SqlCommand("jct_ops_yarn_freeze", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@freeze_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
               // cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 30).Value = ViewState["vendername"];

                cmd.Transaction = Tran;
                cmd.ExecuteNonQuery();

            }



            cmd = new SqlCommand("Jct_Ops_SanctionNote_InsertDynamic_User", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionNote", SqlDbType.VarChar,15).Value = ViewState["RequestID"];
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
            cmd.Parameters.Add("@Areacode", SqlDbType.Int).Value = ViewState["AreaCode"];
            cmd.Parameters.Add("@StartID", SqlDbType.SmallInt).Value = ChkDynamicListing.Items.Count;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ViewState["plant"];
            //if (rdlst.SelectedIndex == 0)
            //{
            //    cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ViewState["plant"];
            //}
            //if (rdlst.SelectedIndex == 1)
            //{
            //    cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ViewState["plant"];
            //}
            
            cmd.Transaction = Tran;
            cmd.ExecuteNonQuery();


            Tran.Commit();
           
            string script2 = "alert(' record saved sucesfully.!!! please press clear to add new record !! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            con.Close();
            SendMail();
           // if (rdlst.SelectedIndex == 1)
           // {
           //     SendMailraw();
           // }
           //if(rdlst.SelectedIndex == 0)
          
           // {
           //     SendMail();
           // }

           //if (rdlst.SelectedIndex == 2)
           //{

           //    SendMailYarn();
           //}
        }
        catch (Exception ex)
        {
            Tran.Rollback();
            string script2 = "alert('error occured!!! " + ex.Message +" ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

        }
        finally
        {
            con.Close();
        }
        
       
    }


    private void SendMail()
    {
        try
        {
            string @from = null;
            string to = null;
            string bcc = null;
            string cc = null;
            string subject = null;
            string body = null;


            con.Open();


            SqlCommand cmd = new SqlCommand("jct_ops_out_freeze_float_mail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"];
            SqlDataReader Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    ViewState["PendingAtName"] = Dr["empname"].ToString();
                    ViewState["PendingAtEmpCode"] = Dr["empcode"].ToString();
                    ViewState["PendingAtEmail"] = Dr["Email"].ToString();
                }
            }
            Dr.Close();
            //con.Close();
           string  sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
            cmd = new SqlCommand(sql, con);
            Dr = cmd.ExecuteReader();
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

            sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + ViewState["usercode"].ToString() + "'";
            cmd = new SqlCommand(sql, con);
           
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    ViewState["sendto"] = Dr["empname"].ToString();
                    ViewState["mailsendto"] = Dr["email"].ToString();
                }
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
            sb.AppendLine("Outsourced Fabric/Yarn Request has been generated in OPS by : " + ViewState["RequestBy"] + "<br/><br/>");
            sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
            sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
            sb.AppendLine("Details are Shown below : <br/><br/>");
            sb.AppendLine("<table class=gridtable>");
            sb.AppendLine("<tr><th> RequestID  td</th> <th>Purchase By</th> <th>Sortno/DesignNo</th> <th> Shade</th> <th> Totqty </th>  <th> Rate(per_mts)</th>  <th>Sale(Per_mts)</th> <th>Supplier</th> <th>Remarks</th><th>PaymentTerms</th> <th>FreightPaidby</th>  </tr> ");
            sql = "jct_ops_outsourced_select";
            cmd = new SqlCommand(sql, con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"].ToString();
            Dr = cmd.ExecuteReader();
            if ((Dr.HasRows))
            {
                while ((Dr.Read()))
                {
                    sb.AppendLine("<tr> <td>  " + Dr["reqid"].ToString() + " </td> <td>  " + Dr["purchase_by"].ToString() + " </td>  <td> " + Dr["sort_no"].ToString() + "</td>  <td> " + Dr["shade"] + "</td>  <td> " + Dr["totqty"].ToString() + "</td>  <td>" + Dr["rateper_mts"].ToString() + "</td> <td>" + Dr["sale_per_mts"].ToString() + "</td> <td>" + Dr["supplier"] + "</td> <td>" + Dr["remarks"] + "</td> <td>" + Dr["payterms"] + "</td><td>" + Dr["Freightby"] + "</td></tr> ");
                }
            }

            Dr.Close();
            con.Close();
            sb.AppendLine("</table>");

            sb.AppendLine("<br /><br/>");

            sb.Append("<a href='http://testerp/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details and authorize the request...!! </a><br />");

            sb.AppendLine("</table><br />");

            sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
            sb.AppendLine("Thank you<br />");
            sb.AppendLine("</html>");


            body = sb.ToString();
            @from = "outsourcing@jctltd.com";

            to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString() +","+ ViewState["mailsendto"].ToString();
            // to = "shwetaloria@jctltd.com";
            //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
            bcc = "jatindutta@jctltd.com,shwetaloria@jctltd.com";
            subject = "Outsourced Fabric/Yarn Request " + ViewState["RequestID"];
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
        catch (Exception ex)
        {
            string script2 = "alert('error occured!!unable to send mail);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

        }
    }

    

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;
   
        ViewState["AreaCode"] = grdDetail.SelectedDataKey.Values["AreaCode"].ToString();
        ViewState["plant"] = grdDetail.SelectedDataKey.Values["plant"].ToString();
        ViewState["usercode"] = grdDetail.SelectedDataKey.Values["usercode"].ToString();

        //if (rdlst.SelectedIndex == 2)
        //{
        //    ViewState["vendername"] = grdDetail.SelectedRow.Cells[2].Text;
        //}
        //if (rdlst.SelectedIndex == 0)
        //{
        //    ViewState["vendername"] = grdDetail.SelectedRow.Cells[2].Text;
        //}


        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        SqlCommand cmd1 = new SqlCommand(" SELECT a.empname,b.userlevel FROM dbo.Jct_Ops_SanctioNote_Area_Emp_Auth_Listing b join jct_empmast_base a on a.empcode=b.empcode where areacode='1042' and plant =@plant order by userlevel", con);
        //cmd1.CommandType = CommandType.Text;
        cmd1.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ViewState["plant"];
        //if (rdlst.SelectedIndex == 0)
        //{
        //    cmd1.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ViewState["plant"];
        //}
        //if (rdlst.SelectedIndex == 1)
        //{
        //    cmd1.Parameters.Add("@plant", SqlDbType.VarChar,10).Value = ViewState["plant"];
        //}
        //if (rdlst.SelectedIndex == 2)
        //{
        //    cmd1.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ViewState["plant"];
        //}
          con.Open();
           
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        GrdEmployee.DataSource = ds1.Tables[0];

        GrdEmployee.DataBind();
            con.Close();

            if (rdlst.SelectedIndex == 2)
            {
                SqlCommand cmd = new SqlCommand("select vendername as[vendor],offerqty,offerquality,convert(varchar,deliveryDt,103) as [DeliveryDt],PayTerms,Ratetype,BasicRate,landedRate from jct_ops_yarn_mat_tb where requestid=@requestid  and approved='y' ", con);
                con.Open();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = ViewState["RequestID"];
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetailyr.DataSource = ds.Tables[0];
                grdDetailyr.DataBind();
          

                con.Close();
            }
            if (rdlst.SelectedIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("select vendor as[vendor],ends_inch ,picks_inch , weft_count ,warp_count,width_inch ,blend   ,  weave  ,weave_on ,piece_length , weight_gsm  ,size_percnt   from jct_ops_out_fab_vendor where requestid=@requestid and status='a' and approved='y' ", con);
                con.Open();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = ViewState["RequestID"];
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetailyr.DataSource = ds.Tables[0];
                grdDetailyr.DataBind();

                con.Close();
              
            }

        if (rdlst.SelectedIndex == 1)

            {
                SqlCommand cmd = new SqlCommand("select sort_no,shade,totqty, rateper_mts,sale_per_mts,supplier,remarks  FROM    jct_ops_outsourced_wardrobe a  where reqid='" + ViewState["RequestID"].ToString() + "' ", con);     
                                     
                 con.Open();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = ViewState["RequestID"];
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetailyr.DataSource = ds.Tables[0];
                grdDetailyr.DataBind();

                con.Close();



        }

   
    }


    private void SendMailraw()
    {

        #region mail wen raw mat pursahse

        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;
        
        con.Open();
        string sql = "SELECT b.EMPCODE,c.empname,d.E_MailID AS Email FROM jct_ops_outsourced_wardrobe a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON CONVERT(VARCHAR,a.Reqid) = b.ID AND a.pending_at=CONVERT(VARCHAR,b.USERLEVEL) INNER JOIN dbo.JCT_EmpMast_Base c ON c.empcode=b.EMPCODE LEFT OUTER JOIN dbo.MISTEL d on d.empcode=b.EMPCODE where CONVERT(VARCHAR,a.Reqid) ='" + ViewState["requestID"] + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                ViewState["PendingAtName"] = Dr["empname"].ToString();
                ViewState["PendingAtEmpCode"] = Dr["empcode"].ToString();
                ViewState["PendingAtEmail"] = Dr["Email"].ToString();
            }
        }
        Dr.Close();

        sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
        cmd = new SqlCommand(sql, con);
        Dr = cmd.ExecuteReader();
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
            ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
        }

        Dr.Close();
        //con.Close();
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
        sb.AppendLine("RequestID for your request is : " + ViewState["requestID"] + " <br/><br/>");
        sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");

        sql = "jct_ops_outsourced_select";
        cmd = new SqlCommand(sql, con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 10).Value = ViewState["requestID"].ToString();
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while ((Dr.Read()))
            {

                sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
                sb.AppendLine("<tr><td colspan='4'> GENERAL MANAGER - MARKETING</td></tr> ");
                sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED DYED FABRIC</td> </tr>");
                sb.AppendLine("<tr><td> CONSTRUCTION</td>  <td>   </tr>");
                sb.AppendLine("<tr><td>requestID </td> <td>" + Dr["reqid"].ToString() + "</td>  </tr>");
                sb.AppendLine("<tr><td>Purchase By </td> <td>" + Dr["purchase_by"].ToString() + "</td>  </tr>");
                sb.AppendLine("<tr><td>Sort no <td> " + Dr["sort_no"].ToString() + "</td> </tr>");
                sb.AppendLine("<tr><td> Designs no</td><td> " + Dr["Designs_no"].ToString() + "</td> </tr>");
                sb.AppendLine("<tr><td> Totqty</td><td>" + Dr["totqty"].ToString() + "</td> </tr>");
                sb.AppendLine("<tr> <td>Rate(per_mts)</td> <td> " + Dr["rateper_mts"].ToString() + "</td> </tr>");
                sb.AppendLine("<tr><td>Sale(Per_mts)</td><td>" + Dr["sale_per_mts"].ToString() + "</td> </tr>");
                sb.AppendLine("<tr> <td>Supplier</td><td> " + Dr["supplier"] + "</td> </tr>");
           

            }
        }

        Dr.Close();
        con.Close();
        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");

        sb.Append("<a href='http://misdev/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details and authorize the request...!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "noreply@jctltd.com";

        to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString();
 
        bcc = "shwetaloria@jctltd.com"; 
        subject = "Outsourced Fabric Request - " + ViewState["requestID"];
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
        #endregion

    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("float and freeze.aspx");
    }


    private void SendMailYarn()
    {

        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;

        con.Open();
        string sql = "SELECT b.EMPCODE,c.empname,d.E_MailID AS Email FROM jct_ops_yarn_purchase a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON CONVERT(VARCHAR,a.Requestid) = b.ID AND a.pending_at=CONVERT(VARCHAR,b.USERLEVEL) INNER JOIN dbo.JCT_EmpMast_Base c ON c.empcode=b.EMPCODE LEFT OUTER JOIN dbo.MISTEL d on d.empcode=b.EMPCODE where CONVERT(VARCHAR,a.Requestid) ='" + ViewState["requestID"] + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                ViewState["PendingAtName"] = Dr["empname"].ToString();
                ViewState["PendingAtEmpCode"] = Dr["empcode"].ToString();
                ViewState["PendingAtEmail"] = Dr["Email"].ToString();
            }
        }
        Dr.Close();

        sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
        cmd = new SqlCommand(sql, con);
        Dr = cmd.ExecuteReader();
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
            ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
        }

        Dr.Close();
        //con.Close();
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
        sb.AppendLine("RequestID for your request is : " + ViewState["requestID"] + " <br/><br/>");
        sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");

        sql = "jct_ops_yarn_mail_content ";
        cmd = new SqlCommand(sql, con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Requestid", SqlDbType.VarChar, 10).Value = ViewState["requestID"].ToString();
        cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 10).Value = ViewState["vendername"].ToString();

        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while ((Dr.Read()))
            {

                 sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
                 sb.AppendLine("<tr><td colspan='4'> GENERAL MANAGER - MARKETING</td></tr> ");
                 sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED DYED FABRIC</td> </tr>");
                 sb.AppendLine("<tr><td> CONSTRUCTION</td>  <td>   </tr>");
                 sb.AppendLine("<tr><td>requestID </td> <td>" + Dr["requestid"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>Vendorname </td> <td>" + Dr["vendername"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>OfferQuantity </td> <td>" + Dr["offerqty"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>OfferQuality </td> <td>" + Dr["offerquality"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>UOM </td> <td>" + Dr["UOM"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>PayTerms</td> <td>" + Dr["payterms"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>RateType</td> <td>" + Dr["ratetype"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>BasicRate </td> <td>" + Dr["basicrate"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>LandedRate</td> <td>" + Dr["landedrate"].ToString() + "</td>  </tr>");
                 sb.AppendLine("<tr><td>Actual(count/Denier)</td><td>" + Dr["actual_count_denier"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>Count CV </td> <td> " + Dr["count_cv"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>CSP</td> <td> " + Dr["CSP"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>U%</td> <td> " + Dr["U_percnt"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>IPI</td> <td> " + Dr["IPI"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>Hairiness</td> <td> " + Dr["Hairiness"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>TPI</td> <td> " + Dr["TPI"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr><td>ClassimateFaults</td><td>" + Dr["classimate_faults"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>AllFaults</td><td> " + Dr["all_faults"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr><td> MajorShortThick</td><td> " + Dr["Major_short_Thick"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr><td> ShortThick</td><td>" + Dr["Short_Thick"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>MajorThin</td> <td> " + Dr["Major_Thin"].ToString() + "</td> </tr>");
                 sb.AppendLine("<tr> <td>Plant</td><td> " + Dr["plant"].ToString()+ "</td> </tr>");
                  



            }
        }

        Dr.Close();
        con.Close();
        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");

        sb.Append("<a href='http://testerp/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details and authorize the request...!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "noreply@jctltd.com";

        to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString();

        bcc = "shwetaloria@jctltd.com";
        subject = "Outsourced Yarn Request - " + ViewState["requestID"];
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




    }

}
