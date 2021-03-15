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

public partial class OPS_AuthorizeSanctionNote : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    String script;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

  
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
        if (e.CommandName == "Select")
        {
           
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Panel2.Visible = true;
            int RowIndex = gvRow.RowIndex;

            Label SanctionID = (Label)gvRow.FindControl("lblSanctionID");
            Label OrderNo = (Label)gvRow.FindControl("lblOrderNo");
            Label Sort = (Label)gvRow.FindControl("lblSort");
            Label Qty = (Label)gvRow.FindControl("lblQty");
            Label SalesPrice = (Label)gvRow.FindControl("lblSalesPrice");
            Label GreighReq = (Label)gvRow.FindControl("lblGreighReq");
            Label GreighProd = (Label)gvRow.FindControl("lblGreighProd");
            Label RequestBy = (Label)gvRow.FindControl("lblRequestBy");


            sql = "JCT_OPS_PLANNING_FETCH_GREIGH_TRANSFER_SANCTION_RECORDS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = SanctionID.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }

        else if (e.CommandName == "Authorize")
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvRow.RowIndex;

            Label SanctionID = (Label)gvRow.FindControl("lblSanctionID");
            Label OrderNo = (Label)gvRow.FindControl("lblOrderNo");
            Label Sort = (Label)gvRow.FindControl("lblSort");
            Label Qty = (Label)gvRow.FindControl("lblQty");
            Label SalesPrice = (Label)gvRow.FindControl("lblSalesPrice");
            Label GreighReq = (Label)gvRow.FindControl("lblGreighReq");
            Label GreighProd = (Label)gvRow.FindControl("lblGreighProd");
            Label RequestBy = (Label)gvRow.FindControl("lblRequestBy");
            ViewState["Orderno"] = OrderNo.Text;
            ViewState["SanctionID"] = SanctionID.Text;
            for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
            {
                Label OrderNo1 = (Label)GridView2.Rows[i].Cells[0].FindControl("lblOrderNo1");
                Label Sort1= (Label)GridView2.Rows[i].Cells[1].FindControl("lblSort1");
                Label Shade = (Label)GridView2.Rows[i].Cells[2].FindControl("lblShade1");
                Label LineItem = (Label)GridView2.Rows[i].Cells[3].FindControl("lblLineItem1");
                Label Qty1 = (Label)GridView2.Rows[i].Cells[4].FindControl("lblQty1");
                Label SalesPrice1 = (Label)GridView2.Rows[i].Cells[5].FindControl("lblSalesPrice1");
                Label GreighReq1 = (Label)GridView2.Rows[i].Cells[6].FindControl("lblGreighReq1");
                TextBox GreighAdjusted = (TextBox)GridView2.Rows[i].Cells[7].FindControl("txtGreighAdjusted1");
                sql = "JCT_OPS_PLANNING_Authorize_GREIGH_TRANSFER_SANCTION_RECORD";
              
                SqlCommand cmd = new SqlCommand(sql,obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CommandName", SqlDbType.VarChar, 20).Value = e.CommandName;
                cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = SanctionID.Text;
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjusted.Text);
                cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
                cmd.ExecuteNonQuery();
            }

            GridView1.DataSourceID="SqlDataSource1";
            GridView1.DataBind();
            Panel2.Visible = false;
           
            SendMail_SaleOrderAdjustment();
            script = "alert('Authorization Successfull..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        else if (e.CommandName == "Cancel")
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvRow.RowIndex;

            Label SanctionID = (Label)gvRow.FindControl("lblSanctionID");
            Label OrderNo = (Label)gvRow.FindControl("lblOrderNo");
            Label Sort = (Label)gvRow.FindControl("lblSort");
            Label Qty = (Label)gvRow.FindControl("lblQty");
            Label SalesPrice = (Label)gvRow.FindControl("lblSalesPrice");
            Label GreighReq = (Label)gvRow.FindControl("lblGreighReq");
            Label GreighProd = (Label)gvRow.FindControl("lblGreighProd");
            Label RequestBy = (Label)gvRow.FindControl("lblRequestBy");
            ViewState["Orderno"] = OrderNo.Text;
            ViewState["SanctionID"] = SanctionID.Text;
            for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
            {
                Label OrderNo1 = (Label)GridView2.Rows[i].Cells[0].FindControl("lblOrderNo1");
                Label Sort1 = (Label)GridView2.Rows[i].Cells[1].FindControl("lblSort1");
                Label Shade = (Label)GridView2.Rows[i].Cells[2].FindControl("lblShade1");
                Label LineItem = (Label)GridView2.Rows[i].Cells[3].FindControl("lblLineItem1");
                Label Qty1 = (Label)GridView2.Rows[i].Cells[4].FindControl("lblQty1");
                Label SalesPrice1 = (Label)GridView2.Rows[i].Cells[5].FindControl("lblSalesPrice1");
                Label GreighReq1 = (Label)GridView2.Rows[i].Cells[6].FindControl("lblGreighReq1");
                TextBox GreighAdjusted = (TextBox)GridView2.Rows[i].Cells[7].FindControl("txtGreighAdjusted1");

                ViewState["AdjustedOrderNo"] = OrderNo1.Text;

                sql = "JCT_OPS_PLANNING_Authorize_GREIGH_TRANSFER_SANCTION_RECORD";

                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CommandName", SqlDbType.VarChar, 20).Value = e.CommandName;
                cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = SanctionID.Text;
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjusted.Text);
                cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
                cmd.ExecuteNonQuery();
            }


            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
            Panel2.Visible = false;
            
            SendMail_Cancellation();
            script = "alert('Cancelled Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }

        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
     



    }

    private void SendMail_SaleOrderAdjustment()
    {
        string from, to, bcc, cc, subject, body;


        StringBuilder sb = new StringBuilder();

        sql = "JCT_OPS_GET_SALE_PERSON_EMAIL";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ViewState["Orderno"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["ActualOrder_EmailID"] = dr[0].ToString();
            }
        }
        dr.Close();

        sql = "JCT_OPS_GET_SALE_PERSON_EMAIL";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ViewState["Orderno"];
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["AdjustedOrder_EmailID"] = dr[0].ToString();
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



        // sb.Append("<head>");
        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Sale Order Adjustment Request has been Authorized in OPS.<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Order No</th> <th> Sort</th> <th> Weaving Sort</th> <th> Quantity</th> <th> Greigh Required</th> <th> Adjusted Qty</th>  <th> Remarks</th> </tr>");
        sql = "SELECT ACTUAL_SALEORDER AS [OrderNo],ACTUAL_SORT AS [Sort],ACTUAL_WEAVINGSORT AS [WeavingSort],ACTUAL_QTY AS [QTY],ACTUAL_GREIGHREQ AS [GreighReq],ISNULL(AdjustedQty,0) AS [AdjustedQty],Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE SanctionID ='" + ViewState["SanctionID"] + "' and status='A'";
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
        sb.AppendLine("Adjusted Order Details : <br/>");
        dr.Close();
        sb.AppendLine("<table class=\"gridtable\"><tr><th> Order No</th> <th> Sort</th> <th> Line Item</th> <th> Shade</th> <th>QTY</th> <th>  Greigh Req</th>  <th>Adjusted Qty</th> <th> Authorized Qty</th>   </tr> ");
        sql = "SELECT SALEORDER AS [OrderNo],SORT,LineItem,Shade,QTY,GREIGHREQ as [Greigh Req],AdjustedQty as [Adjusted Qty],Authorized_Adjusted_Qty as [Qty Adjusted By Planning] FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTED_ORDERS  WHERE SanctionID ='" + ViewState["SanctionID"] + "' and status='A'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td><td>" + dr[7].ToString() + "</td>  </tr> ");

            }
        }

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. ");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        //to = "jatindutta@jctltd.com,harendra@jctltd.com";
        to = "neeraj@jctltd.com,karanjitsaini@jctltd.com," + ViewState["ActualOrder_EmailID"] + "," + ViewState["AdjustedOrder_EmailID"];   //Email Address of Receiver
        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        cc = "sobti@jctltd.com,rkkapoor@jctltd.com,mikeops@jctltd.com";
        subject = "Authorized - Sale Order Adjustment";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
        if (to.Contains(","))
        {
            string[] tos = to.Split(',');
            for (int i = 0; i < tos.Length; i++)
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
                for (int i = 0; i < bccs.Length; i++)
                {
                    mail.Bcc.Add(new MailAddress(bccs[i]));
                }
            }
            else
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
        }
        if (!string.IsNullOrEmpty(cc))
        {
            if (cc.Contains(","))
            {
                string[] ccs = cc.Split(',');
                for (int i = 0; i < ccs.Length; i++)
                {
                    mail.CC.Add(new MailAddress(ccs[i]));
                }
            }
            else
            {
                mail.CC.Add(new MailAddress(bcc));
            }
            mail.CC.Add(new MailAddress(cc));
        }

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;
    }

    private void SendMail_Cancellation()
    {
        string from, to, bcc, cc, subject, body;


        StringBuilder sb = new StringBuilder();

        sql = "JCT_OPS_GET_SALE_PERSON_EMAIL";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ViewState["Orderno"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["ActualOrder_EmailID"] = dr[0].ToString();
            }
        }
        dr.Close();

        sql = "JCT_OPS_GET_SALE_PERSON_EMAIL";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ViewState["Orderno"];
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["AdjustedOrder_EmailID"] = dr[0].ToString();
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



        // sb.Append("<head>");
        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Sale Order Adjustment Request has been Cancelled in OPS.<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Order No</th> <th> Sort</th> <th> Weaving Sort</th> <th> Quantity</th> <th> Greigh Required</th> <th> Adjusted Qty</th>  <th> Remarks</th> </tr>");
        sql = "SELECT ACTUAL_SALEORDER AS [OrderNo],ACTUAL_SORT AS [Sort],ACTUAL_WEAVINGSORT AS [WeavingSort],ACTUAL_QTY AS [QTY],ACTUAL_GREIGHREQ AS [GreighReq],ISNULL(AdjustedQty,0) AS [AdjustedQty],Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE SanctionID ='" + ViewState["SanctionID"] + "' and status='C'";
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
        sb.AppendLine("Adjusted Order Details : <br/>");
        dr.Close();
        sb.AppendLine("<table class=\"gridtable\"><tr><th> Order No</th> <th> Sort</th> <th> Line Item</th> <th> Shade</th> <th>QTY</th> <th>  Greigh Req</th>  <th>Adjusted Qty</th>   </tr> ");
        sql = "SELECT SALEORDER AS [OrderNo],SORT,LineItem,Shade,QTY,GREIGHREQ as [Greigh Req],AdjustedQty as [Adjusted Qty] FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTED_ORDERS  WHERE SanctionID ='" + ViewState["SanctionID"] + "' and status='C'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td> </tr> ");

            }
        }

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. ");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        //to = "jatindutta@jctltd.com,harendra@jctltd.com";
        to = "neeraj@jctltd.com,karanjitsaini@jctltd.com," + ViewState["ActualOrder_EmailID"] + "," + ViewState["AdjustedOrder_EmailID"];  //Email Address of Receiver
        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        cc = "sobti@jctltd.com,rkkapoor@jctltd.com,mikeops@jctltd.com";
        subject = "Cancellation - Sale Order Adjustment";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
        if (to.Contains(","))
        {
            string[] tos = to.Split(',');
            for (int i = 0; i < tos.Length; i++)
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
                for (int i = 0; i < bccs.Length; i++)
                {
                    mail.Bcc.Add(new MailAddress(bccs[i]));
                }
            }
            else
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
        }
        if (!string.IsNullOrEmpty(cc))
        {
            if (cc.Contains(","))
            {
                string[] ccs = cc.Split(',');
                for (int i = 0; i < ccs.Length; i++)
                {
                    mail.CC.Add(new MailAddress(ccs[i]));
                }
            }
            else
            {
                mail.CC.Add(new MailAddress(bcc));
            }
            mail.CC.Add(new MailAddress(cc));
        }

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