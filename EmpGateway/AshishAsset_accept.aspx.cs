using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

public partial class AssetMngmnt_Asset_accept : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string requestID;
    string jctsr_no;
    string usercode;
    string sql;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == string.Empty)
        {
            Response.Redirect("~/login.aspx");
        }



        if (!IsPostBack)
        {
          
             sql = ("SELECT  TOP 1 item_id  FROM dbo.jct_asset_item_details WHERE  usercode= '" + Session["EmpCode"] + "' AND status='A' and   (acceptance_by_email is NULL OR  acceptance_by_email <>'A' ) and module_usedby='MIS'");
             SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    requestID = dr[0].ToString();
                    ViewState["ItemID"] = dr[0].ToString();

                }
              
            }
          
            else
            {
           
                Response.Redirect("Default_asset.aspx");
         
               //return;
                //string script2 = "alert('No mare Assets available to Accept!');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

           
            }
            dr.Close();

          
         
     
            sql = ("SELECT jctSR_NO FROM dbo.jct_asset_item_details WHERE item_id= '" + requestID + "' AND status='A' and module_usedby='MIS'");
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    jctsr_no = dr[0].ToString();
                    lblsrno.Text = dr[0].ToString();
                    ViewState["jctsr_no"] = dr[0].ToString();

                }
            }
            dr.Close();
            //select acceptance from jct_asset_acceptance  where  accepted_by='s-13823'

            sql = ("select acceptance from jct_asset_acceptance WHERE  accepted_by= '" + Session["EmpCode"] + "' and item_id='" + ViewState["ItemID"] + "'");
             cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
        dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string acceptance = dr[0].ToString();
                    if (acceptance == "R")
                    {
                        lnkreject.Enabled = false;

                        //Response.Redirect("Asset_accept.aspx");
                    }
                    if (acceptance == "A")
                    {
                        lnkaccept.Enabled = false;
                        string script = "alert('Assets already accepted  !!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                       
                        //Response.Redirect("Default.aspx");

                    }


                }
            
                //Response.Redirect("Default.aspx");
            }
            dr.Close();





                BindDataList();
                printerConfig();


                sql = "jct_asset_item_detail_print";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState["ItemID"];

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lblcomptype.Text = dr["computer_type"].ToString();
                        lblCurrentDate.Text = dr["Dated"].ToString();
                        lblissuedto.Text = dr["IssueTo"].ToString();
                        lbldept.Text = dr["Department"].ToString();
                        lblmodelno.Text = dr["ModelNo"].ToString();
                        //lblsrno.Text = dr["jctSR_NO"].ToString();

                    }

                }
                else
                {
                    string script = "alert(No data available!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);


                }

                dr.Close();


                sql = "jct_asset_item_detail_print2";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState["ItemID"];


                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lblitemname.Text = dr["item_name"].ToString();
                        //lblDop.Text = dr["DOP"].ToString();
                        //lblipaddress.Text = dr["IP_address"].ToString();

                    }

                }
                dr.Close();


            
        }
    }
    public void BindDataList()
    {
        SqlCommand cmd = new SqlCommand("SELECT  DISTINCT c.item_name,c.asset_id   FROM jct_asset_item_details  a  JOIN  jct_asset_type_item_detail b ON a.item_id=b.request_id  JOIN jct_asset_master c ON b.asset_id=c.asset_id  WHERE a.jctSR_NO= '" + jctsr_no + "' AND a.status='a' ", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DataList2.DataSource = ds;
        DataList2.DataBind();
        
    }
  
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Cells[0].Width = new Unit("200px");
            e.Row.Cells[1].Width = new Unit("400px");



        }
    }
    protected void DataList2_ItemDataBound1(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView gv = (GridView)e.Item.FindControl("GridView1");
            Label lbh = (Label)e.Item.FindControl("Labelhead");

            int asset_id = (int)DataList2.DataKeys[e.Item.ItemIndex];
            if (gv != null)
            {

                string qry = "  SELECT  a.asset_type_name AS [Components], a.item_desc AS [Description]   FROM dbo.jct_asset_type_item_detail  a JOIN  dbo.jct_asset_item_details b  ON b.item_id=a.request_id   JOIN  dbo.jct_asset_master c ON a.asset_id=c.asset_id   WHERE   b.status='A' AND jctSR_NO= '" + jctsr_no + "' AND c.asset_id='" + asset_id + "'";
                SqlCommand cmd = new SqlCommand(qry, obj.Connection());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.DataSource = ds.Tables[0];
                gv.DataBind();

            }

        }

    }
    protected void lnkreject_Click(object sender, EventArgs e)
    {
        SqlTransaction Tran;
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = obj.Connection().ConnectionString.ToString();
        con2.Open();
        Tran = con2.BeginTransaction();
       
        try
        {

            string sql = "jct_asset_acceptance_insert";
            SqlCommand cmd = new SqlCommand(sql, con2, Tran);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("accepted_by", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = lblitemname.Text;
            cmd.Parameters.Add("@JctsrNo", SqlDbType.Int).Value = ViewState["jctsr_no"];
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 100).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 10).Value = 'R';
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 400).Value = txtremarks.Text;
            cmd.Parameters.Add("@item_id", SqlDbType.VarChar, 100).Value = ViewState["ItemID"];
            cmd.ExecuteNonQuery();

            sql = "jct_asset_acceptance_update_bymail";
            cmd = new SqlCommand(sql, con2, Tran);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Item_id", SqlDbType.VarChar, 10).Value = ViewState["ItemID"];
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 1000).Value = 'R';
            cmd.ExecuteNonQuery();
            Tran.Commit();

        }
        catch (Exception ex2)
        {
            string script = "alert(Error occurred!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


        string script2 = "alert('Assets Reject  !!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        SendMail_reject();
    }
    protected void lnkaccept_Click(object sender, EventArgs e)
    {
        //jct_asset_acceptance_insert
        SqlTransaction Tran;
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = obj.Connection().ConnectionString.ToString();
        con2.Open();
        Tran = con2.BeginTransaction();

        try
        {

            string sql = "jct_asset_acceptance_insert";
            SqlCommand cmd = new SqlCommand(sql, con2, Tran);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("accepted_by", SqlDbType.VarChar, 100).Value = Session["EmpCode"];
            cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = lblitemname.Text;
            cmd.Parameters.Add("@JctsrNo", SqlDbType.Int).Value = ViewState["jctsr_no"];
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 100).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 1000).Value = 'A';
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 400).Value = txtremarks.Text;
            cmd.Parameters.Add("@item_id", SqlDbType.VarChar, 100).Value = ViewState["ItemID"];
            cmd.ExecuteNonQuery();

            sql = "jct_asset_acceptance_update_bymail";
            cmd = new SqlCommand(sql, con2, Tran);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Item_id", SqlDbType.VarChar, 10).Value = ViewState["ItemID"];
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 1000).Value = 'A';
            cmd.ExecuteNonQuery();

            Tran.Commit();
          
            string sql2 = ("SELECT top 1  item_id  FROM dbo.jct_asset_item_details WHERE  usercode= '" + Session["EmpCode"] + "' AND status='A' and   (acceptance_by_email IS NULL OR acceptance_by_email='R' )and module_usedby='MIS'");
            SqlCommand cmd2 = new SqlCommand(sql2, obj.Connection());
            cmd2.CommandType = CommandType.Text;
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.HasRows)
            {
                //while (dr.Read())
                {
                    string script2 = "alert('Assets Accepted.!! You have more assets to Accept Please click Refresh to Accept Again !!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

                }
                dr.Close();
                lnkaccept.Enabled = false;
                lnkreject.Enabled = false;
                SendMail_accept();
              
          

            }
            else
            {
  
                string script2 = "alert('Assets Accepted sucessfully !!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                dr.Close();
                lnkaccept.Enabled = false;
                lnkreject.Enabled = false;
                SendMail_accept();
            }



        }
        catch (Exception ex)
        {
            Tran.Rollback();
            string script = "alert(Error occurred!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        finally
        {
            con2.Close();


        }
   
    }



     private void printerConfig()
    {
        string qry = "SELECT  asset_type AS [TYPE], printer_type  AS [Components] , model   AS [Description] FROM dbo.jct_asset_printer_scanner_network WHERE module_usedby='MIS'AND status='A' AND jct_machine_ID= '" + ViewState["jctsr_no"] + "' ";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetailprinter.DataSource = ds.Tables[0];
       grdDetailprinter.DataBind();

    }

     protected void LinkButton1_Click(object sender, EventArgs e)
     {


         Response.Redirect("Asset_accept.aspx");
         //Response.Redirect("~/emp_home.aspx");
     }
     private void SendMail_accept()
     {
         string @from = null;
         string to = null;
         string bcc = null;
         string cc = null;
         string subject = null;
         string body = null;


         string sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
         SqlCommand cmd = new SqlCommand(sql, obj.Connection());
         
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
             ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
         }

         Dr.Close();
         sql = " select JctsrNo,remarks  FROM  jct_asset_acceptance  where accepted_by='" + Session["Empcode"].ToString() + "' ' and JctsrNo = '" + ViewState["jctsr_no"] + "'";
         cmd = new SqlCommand(sql, obj.Connection());

         Dr = cmd.ExecuteReader();
         if (Dr.HasRows)
         {
             while (Dr.Read())
             {
                 ViewState["Jctsrno"] = Dr["JctsrNo"].ToString();
                 ViewState["Remarks"] = Dr["remarks"].ToString();
             }
         }


         Dr.Close();


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
         sb.AppendLine("Assets with AssetID :" + ViewState["Jctsrno"] + " has been Accepted By : " + ViewState["RequestBy"] + "<br/><br/>");
         //sb.AppendLine("JctSrNo  :" + ViewState["Jctsrno"] + " <br/><br/>");
         sb.AppendLine("Remarks  :" + ViewState["Remarks"] + " <br/><br/>");

         //sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
         //sb.AppendLine("Request is Pending at R&D Dept <br/><br/>");

         //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
         //sb.AppendLine("Details are Shown below : <br/><br/>");
         sb.AppendLine("<table class=gridtable>");



         Dr.Close();

         sb.AppendLine("</table>");

         sb.AppendLine("<br /><br/>");

         ////sb.AppendLine("Please fill the specifications against this Request.<br/> <br/>");

         ////sb.Append("<a href='http://misdev/FusionApps/OPS/outsourced_fab_specs.aspx'> Click here to fill specifications..!! </a><br />");

         sb.AppendLine("</table><br />");

         sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
         sb.AppendLine("Thank you<br />");
         sb.AppendLine("</html>");


         body = sb.ToString();
         @from = "noreply@jctltd.com";

        
         
         to = ViewState["RequestByEmail"].ToString();
         bcc = "it.helpdesk@jctltd.com,shwetaloria@jctltd.com";
         //cc = "it.helpdesk@jctltd.com";
         //bcc = "shwetaloria@jctltd.com,rbaksshi@jctltd.com,rajan@jctltd.com";
         subject = "Acceptance of I.T Assets.  AssetID " + ViewState["Jctsrno"];
         MailMessage mail = new MailMessage();
         //to = "shwetaloria@jctltd.com,ashish@jctltd.com";
         mail.From = new MailAddress(@from);
         if (to.Contains(","))
         {
             cc = "it.helpdesk@jctltd.com";
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
         cc = "it.helpdesk@jctltd.com";
         mail.Subject = subject;
         mail.Body = body;
         mail.IsBodyHtml = true;
         mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
         SmtpClient SmtpMail = new SmtpClient("exchange2k7");

         //SmtpMail.SmtpServer = "exchange2007";
         SmtpMail.Send(mail);
     }




     private void SendMail_reject()
     {
         string @from = null;
         string to = null;
         string bcc = null;
         string cc = null;
         string subject = null;
         string body = null;


         string sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
         SqlCommand cmd = new SqlCommand(sql, obj.Connection());

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
             ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
         }

         Dr.Close();
         sql = " select JctsrNo,remarks  FROM  jct_asset_acceptance  where accepted_by='" + Session["Empcode"].ToString() + "' ' and JctsrNo = '" + ViewState["jctsr_no"] + "'";
         cmd = new SqlCommand(sql, obj.Connection());

         Dr = cmd.ExecuteReader();
         if (Dr.HasRows)
         {
             while (Dr.Read())
             {
                 ViewState["Jctsrno"] = Dr["JctsrNo"].ToString();
                 ViewState["Remarks"] = Dr["remarks"].ToString();
             }
         }


         Dr.Close();
   

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
         sb.AppendLine("Assets with AssetID :" + ViewState["Jctsrno"] + " has been Rejected By : " + ViewState["RequestBy"] + "<br/><br/>");
         //sb.AppendLine("JctSrNo  :" + ViewState["Jctsrno"] + " <br/><br/>");
         sb.AppendLine("Reason to Reject  :"+ ViewState["Remarks"] + " <br/><br/>");

         //sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
         //sb.AppendLine("Request is Pending at R&D Dept <br/><br/>");

         //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
         //sb.AppendLine("Details are Shown below : <br/><br/>");
         sb.AppendLine("<table class=gridtable>");



         Dr.Close();

         sb.AppendLine("</table>");

         sb.AppendLine("<br /><br/>");

         ////sb.AppendLine("Please fill the specifications against this Request.<br/> <br/>");

         ////sb.Append("<a href='http://misdev/FusionApps/OPS/outsourced_fab_specs.aspx'> Click here to fill specifications..!! </a><br />");

         sb.AppendLine("</table><br />");

         sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
         sb.AppendLine("Thank you<br />");
         sb.AppendLine("</html>");


         body = sb.ToString();
         @from = "noreply@jctltd.com";

         //if (ddlplant.SelectedItem.Text == "Cotton")
         //{
         //    to = ViewState["RequestByEmail"].ToString() + ",dpbadhwar@jctltd.com,skpalta@jctltd.com,rajgopal@jctltd.com,sanjeevj@jctltd.com,laxman@jctltd.com";
         //}
         //if (ddlplant.SelectedItem.Text == "Taffeta")
         //{
         //    to = ViewState["RequestByEmail"].ToString()+",dpbadhwar@jctltd.com,sanjeevj@jctltd.com,laxman@jctltd.com";
         //}

         // to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString()+ " ";
         to = ViewState["RequestByEmail"].ToString();
         bcc = "it.helpdesk@jctltd.com,shwetaloria@jctltd.com";
         cc = "it.helpdesk@jctltd.com";
         //bcc = "shwetaloria@jctltd.com,rbaksshi@jctltd.com,rajan@jctltd.com";
         subject = "Rejection of I.T Assets.  AssetID " + ViewState["Jctsrno"] + " ";
         MailMessage mail = new MailMessage();
         //to = "shwetaloria@jctltd.com,ashish@jctltd.com";
         mail.From = new MailAddress(@from);
         if (to.Contains(","))
         {cc = "it.helpdesk@jctltd.com";
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
         cc = "it.helpdesk@jctltd.com";
         mail.Subject = subject;
         mail.Body = body;
         mail.IsBodyHtml = true;
         mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
         SmtpClient SmtpMail = new SmtpClient("exchange2k7");

         //SmtpMail.SmtpServer = "exchange2007";
         SmtpMail.Send(mail);
         //return mail;
     }
     protected void nextbtn_Click(object sender, EventArgs e)
     {
         //Response.Redirect("assset_accept2.aspx");
     }
}