using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net.Mail;

public partial class OPS_AuthorizeSanctionNote10 : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    String script;

    protected void Page_Load(object sender, EventArgs e)
    {

          
        if (!IsPostBack)
        { 
            
                    GridView4.DataSource = SqlDataSource3;
                    GridView4.DataBind();
        }

    }

    protected void DataList1_ItemCommand1(object source, DataListCommandEventArgs e)
    {

        string AreaName = "";
        if (e.CommandName == "Select")
        {
            AreaName = ((LinkButton)e.Item.FindControl("cmdArea")).Text;
            if (AreaName == "Greigh Transfer" || AreaName == "Greigh Transfer Taffeta")
            {
                GridView4.DataSource = null;
                GridView4.DataBind();
                //sql = "SELECT a.SanctionNoteID as SanctionID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" + AreaName + "'";
                sql = "JCT_OPS_PLANNING_GET_SANCTION_DETAIL_HIERARCHY_WISE";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                SqlDataAdapter   da  =new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView4.DataSource=ds.Tables[0];
                GridView4.DataBind();
                //obj1.FillGrid(sql, ref GridView1);

            }
            else
            {
                Response.Redirect("AuthorizeSanction_Note.aspx?AreaName=" + AreaName.Replace(" ", "%20"));
            }
        }
    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView4.DataKeyNames.Equals("SanctionID");
            String SanctionID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionID"));

            GridView GridViewNested = (GridView)e.Row.FindControl("nestedGridView");
            GridViewNested.DataKeyNames.Equals("Remarks");
            sql = "SELECT ISNULL(Remarks,'No Remarks Given..!!') AS Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT  WHERE SanctionID='" + SanctionID + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridViewNested.DataSource = ds.Tables[0];
            GridViewNested.DataBind();
        }
    }
   
    protected void GrdAuthHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView4.DataKeyNames.Equals("SanctionID");
            String SanctionID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionID"));
            String UserLevel = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserLevel"));
            
            GridView GridViewNested = (GridView)e.Row.FindControl("nestedRemarks");
            GridViewNested.DataKeyNames.Equals("Remarks");
            sql = "JCT_OPS_GREIGH_TRANSFER_AUTH_DETAILS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 20).Value = SanctionID;
            cmd.Parameters.Add("@UserLevel", SqlDbType.VarChar, 10).Value = UserLevel;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridViewNested.DataSource = ds.Tables[0];
            GridViewNested.DataBind();
        }
    }

    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label SanctionID = (Label)GridView4.SelectedRow.FindControl("lblSanctionID");
        ViewState["SanctionID"] = SanctionID.Text;
        sql = "JCT_OPS_GREIGH_TRANSFER_DETAILS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("SanctionID", SqlDbType.VarChar, 20).Value = SanctionID.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GrdSanctionNoteDetail.DataSource = ds.Tables[0];
        GrdSanctionNoteDetail.DataBind();


        sql = "Jct_Ops_SanctionNote_Authrization_Detail_Greigh_Transfer";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("SanctionNote", SqlDbType.VarChar, 20).Value =SanctionID.Text;
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        GrdAuthHistory.DataSource = ds.Tables[0];
        GrdAuthHistory.DataBind();


    }

    protected void lnkApply_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddlAction.SelectedItem.Text.Substring(0, 1) == "A")
            {
                sql = "JCT_OPS_GREIGH_TRANSFER_AUTHORIZATION";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SANCTIONID", SqlDbType.VarChar, 20).Value = ViewState["SanctionID"];
                cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 4000).Value = txtRemarks.Text;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = ddlAction.SelectedItem.Text.Substring(0, 1);
                cmd.ExecuteNonQuery();



                sql = "SELECT FlagAuth,LastAuthBy FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT   WHERE SanctionID='" + ViewState["SanctionID"] + "'";
                cmd = new SqlCommand(sql, obj.Connection());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViewState["PendingAt"] = dr[0].ToString();
                        ViewState["Auth_By"] = dr[1].ToString();

                    }

                }
                dr.Close();

                SendMail_Authorization();



                // Fill GridView 4

                sql = "JCT_OPS_PLANNING_GET_SANCTION_DETAIL_HIERARCHY_WISE";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView4.DataSource = ds.Tables[0];
                GridView4.DataBind();


                // Fill GridView Auth


                GrdAuthHistory.DataSource = null;
                GrdAuthHistory.DataBind();


                // Fill GridView Details

                GrdSanctionNoteDetail.DataSource = null;
                GrdSanctionNoteDetail.DataBind();



                String Scrpt = "alert('Greigh Transfer Authorized Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
            }
            else if (ddlAction.SelectedItem.Text.Substring(0, 1) == "C")
            {
                sql = "JCT_OPS_GREIGH_TRANSFER_AUTHORIZATION";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SANCTIONID", SqlDbType.VarChar, 20).Value = ViewState["SanctionID"];
                cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 4000).Value = txtRemarks.Text;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = ddlAction.SelectedItem.Text.Substring(0, 1);
                cmd.ExecuteNonQuery();



                sql = "SELECT FlagAuth,isnull(LastAuthBy,0) as Auth_By FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT   WHERE SanctionID='"+ ViewState["SanctionID"] +"'";
                cmd = new SqlCommand(sql, obj.Connection());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViewState["PendingAt"] = dr[0].ToString();
                        ViewState["Auth_By"] = dr[1].ToString();

                    }

                }
                dr.Close();

                SendMail_Cancellation();


                // Fill GridView 4

                sql = "JCT_OPS_PLANNING_GET_SANCTION_DETAIL_HIERARCHY_WISE";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView4.DataSource = ds.Tables[0];
                GridView4.DataBind();


                // Fill GridView Auth


                GrdAuthHistory.DataSource = null;
                GrdAuthHistory.DataBind();


                // Fill GridView Details

                GrdSanctionNoteDetail.DataSource = null;
                GrdSanctionNoteDetail.DataBind();


            }
          
        }

        catch (Exception ex)
        { 
             String Scrpt   = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this,this.GetType(), "ServerControlScript", Scrpt, true);
        }
       
    }

    protected void SendMail_Authorization()
    {
        string @from = null;
        string body = null;
        string Reason = null;
        string sql = null;
        string Subject=null;
        string Auth = null;
        string to="",bcc="",cc="";
        StringBuilder sb = new StringBuilder();
        string SenderEmail = "", PendingAt_Email = "", PendingAt_Name = "", AuthBy_Email = "", AuthBy_Name = "", SanctionNoteBy_Name = "", SanctionNoteBy_Email= "";


        sql = "Select Name,e_mailid from mistel a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON a.empcode=b.EMPCODE WHERE b.USERLEVEL=@UserLevel AND b.ID=@SanctionID";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr;

        if (ViewState["PendingAt"] != "")
        {
            cmd.Parameters.Add("@userLevel", SqlDbType.VarChar, 10).Value = ViewState["PendingAt"];
            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 20).Value = ViewState["SanctionID"];
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    PendingAt_Name = dr[0].ToString();
                    PendingAt_Email = dr[1].ToString();
                }
            }

            dr.Close();
        }
        else
        {
                    PendingAt_Name = "";
                    PendingAt_Email = "";

        }

       

        sql = "Select Name,e_mailid from mistel a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON a.empcode=b.EMPCODE WHERE b.USERLEVEL=@UserLevel AND b.ID=@SanctionID and Auth_Datetime is not null ";
         cmd = new SqlCommand(sql, obj.Connection());
         cmd.Parameters.Add("@userLevel", SqlDbType.VarChar, 10).Value =  ViewState["Auth_By"];
        cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 20).Value = ViewState["SanctionID"];
         dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                AuthBy_Name = dr[0].ToString();
                AuthBy_Email = dr[1].ToString();
            }
        }

        dr.Close();


        sql = "SELECT  Name , e_mailid FROM    mistel a INNER JOIN dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT b ON a.empcode = b.ENTRYBY WHERE  b.SanctionID = @SanctionID ";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 20).Value = ViewState["SanctionID"];
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                SanctionNoteBy_Name = dr[0].ToString();
                SanctionNoteBy_Email = dr[1].ToString();
            }
        }

        dr.Close();


            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
            sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");

           
        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Greigh Trasnfer Request has been Authorized By : " + AuthBy_Name + " with Sanction ID : "+ ViewState["SanctionID"] +"<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Order No</th> <th> Sort</th> <th> Weaving Sort</th> <th> Quantity</th> <th> Greigh Required</th> <th> Adjusted Qty</th>  <th> Remarks</th><th> Pending At </th> </tr>");
        sql = "SELECT ACTUAL_SALEORDER AS [OrderNo],ACTUAL_SORT AS [Sort],ACTUAL_WEAVINGSORT AS [WeavingSort],ACTUAL_QTY AS [QTY],ACTUAL_GREIGHREQ AS [GreighReq],ISNULL(AdjustedQty,0) AS [AdjustedQty],Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE SanctionID ='" + ViewState["SanctionID"] + "'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td> <td>"+ PendingAt_Name +"</td>  </tr> ");

            }
        }

        sb.AppendLine("</table>");
        sb.AppendLine("<br />");
        sb.AppendLine("Greigh Transferred in Order : <br/>");
        dr.Close();
        sb.AppendLine("<table class=\"gridtable\"><tr><th> Order No</th> <th> Sort</th> <th> Line Item</th> <th> Shade</th> <th>QTY</th> <th>  Greigh Req</th>  <th>Adjusted Qty</th> <th> Authorized Qty</th>   </tr> ");
        sql = "SELECT SALEORDER AS [OrderNo],SORT,LineItem,Shade,QTY,GREIGHREQ as [Greigh Req],AdjustedQty as [Adjusted Qty],ISNULL(Authorized_Adjusted_Qty,AdjustedQty) as [Qty Adjusted By Planning] FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTED_ORDERS  WHERE SanctionID ='" + ViewState["SanctionID"] + "' ";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td><td>" + dr[7].ToString() + "</td> </tr> ");

            }
        }

        sb.AppendLine("</table><br />");

   
            sb.AppendLine("<br/><br />");

            sb.AppendLine("Last Authorized By  : " + AuthBy_Name + "<br /><br/>");

            sb.AppendLine("Last Authorization Remarks : " + txtRemarks.Text);


            sb.AppendLine("<br/><br />");
            sb.Append("<a href='http://misdev/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details... </a><br /><br />");
            sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
            sb.AppendLine("Thank you<br />");
            sb.AppendLine("</html>");


            body = sb.ToString();
            @from = "noreply@jctltd.com";

            if (!string.IsNullOrEmpty(SanctionNoteBy_Email))
            {
                if(!string.IsNullOrEmpty(AuthBy_Email))
                {
                       if(!string.IsNullOrEmpty(PendingAt_Email))
                       {
                            to = PendingAt_Email +"," +  AuthBy_Email +"," + SanctionNoteBy_Email;
                       }
                       else

                       {
                        to = SanctionNoteBy_Email +"," +  AuthBy_Email ;
                       }
                }
                else
                {
                    to = SanctionNoteBy_Email;
                }
            }
            else
            {
                to="jatindutta@jctltd.com";
            }

            bcc = "jatindutta@jctltd.com,ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";


            if (ddlAction.SelectedItem.Text.Substring(0,1) == "A")
            {
                Subject = " Greigh Transfer Request - Authorized";


            }
            else if  (ddlAction.SelectedItem.Text.Substring(0,1) == "C")
            {
                Subject = " Greigh Transfer Request - Cancelled";


            }
            else
            {
                Subject =  " Greigh Transfer Request - " + ddlAction.SelectedItem.Text;

            }


        
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

        mail.Subject = Subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");
        SmtpMail.Send(mail);

        }

    protected void SendMail_Cancellation()
    {
        string @from = null;
        string body = null;
        string sql = null;
        string Subject = null;
        string to = "", bcc = "", cc = "";
        StringBuilder sb = new StringBuilder();
        string   CancelBy_Email = "", CancelBy_Name = "", SanctionNoteBy_Name = "", SanctionNoteBy_Email = "";

        sql = "Select Name,e_mailid from mistel a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON a.empcode=b.EMPCODE WHERE b.USERLEVEL=@UserLevel AND b.ID=@SanctionID and Auth_Datetime is  null ";
        SqlCommand cmd   = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@UserLevel", SqlDbType.VarChar, 10).Value = ViewState["Auth_By"];
        cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 20).Value = ViewState["SanctionID"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                CancelBy_Name = dr[0].ToString();
                CancelBy_Email = dr[1].ToString();
            }
        }

        dr.Close();


        sql = "SELECT  Name , e_mailid FROM  mistel a INNER JOIN dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT b ON a.empcode = b.ENTRYBY WHERE  b.SanctionID = @SanctionID ";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 20).Value = ViewState["SanctionID"];
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                SanctionNoteBy_Name = dr[0].ToString();
                SanctionNoteBy_Email = dr[1].ToString();
            }
        }

        dr.Close();


        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");


        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Greigh Trasnfer Request has been Cancelled By : " + CancelBy_Name + "<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Order No</th> <th> Sort</th> <th> Weaving Sort</th> <th> Quantity</th> <th> Greigh Required</th> <th> Adjusted Qty</th>  <th> Remarks</th> </tr>");
        sql = "SELECT ACTUAL_SALEORDER AS [OrderNo],ACTUAL_SORT AS [Sort],ACTUAL_WEAVINGSORT AS [WeavingSort],ACTUAL_QTY AS [QTY],ACTUAL_GREIGHREQ AS [GreighReq],ISNULL(AdjustedQty,0) AS [AdjustedQty],Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE SanctionID ='" + ViewState["SanctionID"] + "'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td>  </tr> ");

            }
        }

        sb.AppendLine("</table>");
        sb.AppendLine("<br />");
        sb.AppendLine("Greigh Transferred in Order : <br/>");
        dr.Close();
        sb.AppendLine("<table class=\"gridtable\"><tr><th> Order No</th> <th> Sort</th> <th> Line Item</th> <th> Shade</th> <th>QTY</th> <th>  Greigh Req</th>  <th>Adjusted Qty</th> <th> Cancel Qty</th>   </tr> ");
        sql = "SELECT SALEORDER AS [OrderNo],SORT,LineItem,Shade,QTY,GREIGHREQ as [Greigh Req],AdjustedQty as [Adjusted Qty],ISNULL(Authorized_Adjusted_Qty,AdjustedQty) as [Qty Adjusted By Planning] FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTED_ORDERS  WHERE SanctionID ='" + ViewState["SanctionID"] + "' ";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td><td>" + dr[7].ToString() + "</td>  </tr> ");

            }
        }

        sb.AppendLine("</table><br />");


        sb.AppendLine("<br/><br />");

        sb.AppendLine("Cancelled By  : " + CancelBy_Name + "<br /><br/>");

        sb.AppendLine("Cancellation Remarks : " + txtRemarks.Text);


        sb.AppendLine("<br/><br />");
        sb.Append("<a href='http://misdev/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details... </a><br /><br />");
        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "noreply@jctltd.com";

       
            if (!string.IsNullOrEmpty(CancelBy_Email))
            {
                if (!string.IsNullOrEmpty(SanctionNoteBy_Email))
                {
                    to = CancelBy_Email + "," + SanctionNoteBy_Email;
                }
                else
                {
                    to = CancelBy_Email;
                }
            }
            else
            {
                to = "jatindutta@jctltd.com";
            }
       

           bcc = "jatindutta@jctltd.com,ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";

            Subject = " Greigh Transfer Request - Cancelled";


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

        mail.Subject = Subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");
        SmtpMail.Send(mail);

    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/AuthorizeSanctionNote10.aspx");
    }
}