using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Data;

public partial class OPS_MaterialReturnFinalAuth : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql = "SELECT Count(*) FROM JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION  WHERE STATUS='A' AND AuthStatus='P'";
            lblrequests.Text = obj1.FetchValue(sql).ToString();
            grdDetail.DataSourceID = "SqlDataSource1";
            grdDetail.DataBind();
    
        }
        
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Session["EmpCode"] == "R-03481" || Session["EmpCode"] == "P-03055" || Session["EmpCode"] =="J-01945")
        //{ 
        pnlEdit.Visible = true;
        sql = "SELECT distinct a.RequestID,a.customer,a.invoice_no,a.item_no,Convert(numeric(12,2),a.invoice_qty) as invoice_qty,a.ret_qty ,a.bales,b.FreightPaidby,isnull(b.GrNo,'') as GrNo,Case When b.GrDate is null then isnull(b.GrDate,Null) when b.GrDate='' then '' else Convert(varchar,b.GrDate,101) End as GrDate,b.EnClosures,ISNULL(a.FreightValue,0) as FreightValue FROM dbo.jct_ops_material_request a inner join JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION b on a.requestid=b.requestid  WHERE b.status='A' and  a.RequestID=" + grdDetail.SelectedRow.Cells[2].Text;
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblTitle.Text = "Details of Material Return Request for Customer : " + dr[1].ToString();
                lblRequestID.Text = dr[0].ToString();
                lblCustomer.Text = dr[1].ToString();
                lblInvoiceNo.Text = dr[2].ToString();
                lblItemNo.Text = dr[3].ToString();
                lblInvoiceQty.Text = dr[4].ToString();
                txtReturnQty.Text = dr[5].ToString();
                txtBales.Text = dr[6].ToString();
                lblFreightBy.Text = dr[7].ToString();
                ddlFreight.SelectedIndex = ddlFreight.Items.IndexOf(((ListItem)ddlFreight.Items.FindByText(dr[7].ToString())));
                txtGrNo.Text = dr[8].ToString();
                txtGrDate.Text = dr[9].ToString();
                lbLEnclosures.Text = dr[10].ToString();
                txtAmount.Text = dr[11].ToString();
                sql = "Select Convert(varchar,Convert(datetime,'"+ dr[9].ToString() +"',101),101)";
                txtGrDate.Text = obj1.FetchValue(sql).ToString();

            }
        }
        dr.Close();
        sql = "SELECT distinct invoice_no FROM dbo.jct_ops_material_request WHERE RequestID=" + grdDetail.SelectedRow.Cells[2].Text + "";
        obj1.FillList(ddlInvoiceNo, sql);
        //sql = "SELECT  item_no ,CONVERT(NUMERIC(15,2),invoice_qty) AS invoice_qty , ret_qty ,bales , Freight_by FROM    dbo.jct_ops_material_request WHERE   RequestID = " + grdDetail.SelectedRow.Cells[2].Text + " AND invoice_no='" + ddlInvoiceNo.SelectedItem.Text + "'";
        sql = "SELECT  item_no ,CONVERT(NUMERIC(15,2),invoice_qty) AS invoice_qty , SUM(ret_qty) AS ret_qty , SUM(bales) AS bales , Freight_by FROM    dbo.jct_ops_material_request WHERE   RequestID = " + grdDetail.SelectedRow.Cells[2].Text + " AND invoice_no='" + ddlInvoiceNo.SelectedItem.Text + "' GROUP BY item_no,invoice_qty,Freight_by";
        cmd = new SqlCommand(sql, obj.Connection());
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        { 
            while(dr.Read())
            {
                lblItemNo.Text = dr["item_no"].ToString();
                lblInvoiceQty.Text = dr["invoice_qty"].ToString();
                txtReturnQty.Text = dr["ret_qty"].ToString();
                txtBales.Text = dr["bales"].ToString();
                lblFreightBy.Text = dr["Freight_by"].ToString();
            }
        }


       // }
      
    }

    protected void lnkAuthorize_Click(object sender, EventArgs e)
    {
        decimal amount = 0;
        try
        {
            sql = "JCT_OPS_MATERIAL_REQUEST_AUTHORIZATION_PROC";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@REQUESTID", SqlDbType.VarChar, 20).Value = lblRequestID.Text;
            cmd.Parameters.Add("@MrNo", SqlDbType.VarChar, 20).Value = txtMrNo.Text;
            cmd.Parameters.Add("@GrNo", SqlDbType.VarChar, 30).Value = txtGrNo.Text;
            cmd.Parameters.Add("@GrDate", SqlDbType.VarChar, 20).Value = (txtGrDate.Text == "" ? null : txtGrDate.Text);
            cmd.Parameters.Add("@Transport", SqlDbType.VarChar, 500).Value = txtTransport.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000).Value =txtRemarks.Text;
            cmd.Parameters.Add("@Bales", SqlDbType.Int).Value = Convert.ToInt16(txtBales.Text);
            cmd.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtReturnQty.Text);
            cmd.Parameters.Add("@FreightPaidBy", SqlDbType.VarChar,30).Value = ddlFreight.SelectedItem.Text;

            if (Decimal.TryParse(txtAmount.Text, out amount))
            {
                cmd.Parameters.Add("@FreightValue", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmount.Text);
            }

            cmd.ExecuteNonQuery();

            SendMail();
            pnlEdit.Visible = false;
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            String Script = "alert('Request Authorized. You can take print out from Print Preview Screen..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Script, true);
        }
        catch (Exception ex)
        {
            String Script = "alert('Error Occured..!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Script, true);
        }
      
       
    }

    private void SendMail()
    {
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");

        // sb.Append("<head>");
        sb.AppendLine("Hi,<br/><br/>");
        sb.AppendLine("Material Return Request has been Authorized.<br/><br/>");
        sb.AppendLine("RequestID for your request is : " + lblRequestID.Text + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");
        sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th><th> Invoice Qty</th><th> No. of Bales/Rolls</th> <th> Return Qty</th>  <th> Status</th> </tr>");
        //Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")
        sql = "Select invoice_no,item_no,customer,invoice_qty,bales,ret_qty from JCT_OPS_MATERIAL_REQUEST WHERE REQUESTID=" + lblRequestID.Text;
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr> <td> " + dr[0].ToString() + " </td> <td> " + dr[1].ToString() + "  </td>  <td> " + dr[2].ToString() + "</td>  <td>" + dr[3].ToString() + " </td>  <td>" + dr[4].ToString() + " </td>  <td>" + dr[5].ToString() + " </td> <td>Authorized </td> </tr> ");
            }
        }

        dr.Close();

        sb.AppendLine("</table>");
        sb.AppendLine("<br/><br/>");

        sb.AppendLine("<table class=gridtable>");
        sb.AppendLine("<tr><th> Freight Paid By </th><th> Gr No </th> <th> Gr Date </th><th> Freight Value </th> </tr>");
        //Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")

        sb.AppendLine("<tr> <td> " + lblFreightBy.Text + "</td>  <td> " + txtGrNo.Text + " </td> <td> " + txtGrDate.Text + "  </td>  <td>" + txtAmount.Text + " </td>  </tr> ");


        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");
        sb.Append("<a href='http://testerp/fusionapps/OPS/MaterialRequestPreview.aspx'> Click here to view detail... </a><br />");

        sb.AppendLine("</table><br /><br />");

        //sql = "Select empname from jct_empmast_base where empcode='"+ Session["EmpCode"] +"' and active='Y'";
        //sb.AppendLine("Authorized by : "+ obj1.FetchValue(sql).ToString() );

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "noreply@jctltd.com";
        sql = "SELECT isnull(b.E_MailID,'jatindutta@jctltd.com') as email FROM dbo.jct_ops_material_request a INNER JOIN dbo.MISTEL b ON a.userid=b.empcode WHERE  a.RequestID= " + lblRequestID.Text + "";
        to = "" + obj1.FetchValue(sql).ToString() + "";
        cc = "pgmohan@jctltd.com,ranjitsaini@jctltd.com,rameshs@jctltd.com,skj@jctltd.com,pkchhabra@jctltd.com,maingate@jctltd.com,mrsood@jctltd.com";
        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com";
        //to = ("jatindutta@jctltd.com");
        //Email Address of Receiver
        //cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
        subject = " Material Return Request Authorized- " + lblCustomer.Text;
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
        if (!string.IsNullOrEmpty(cc))
        {
            if (cc.Contains(","))
            {
                string[] ccs = cc.Split(',');
                for (int i = 0; i <= ccs.Length - 1; i++)
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
        body = sb.ToString();
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");

        //SmtpMail.SmtpServer = "exchange2k7";
        SmtpMail.Send(mail);
        //return mail;
    }

    //private void SendMail()
    //{
    //    string @from = null;
    //    string to = null;
    //    string bcc = null;
    //    string cc = null;
    //    string subject = null;
    //    string body = null;


    //    StringBuilder sb = new StringBuilder();




    //    sb.AppendLine("<html>");
    //    sb.AppendLine("<head>");
    //    sb.AppendLine("<style type=\"text/css\">");
    //    sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
    //    sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
    //    sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
    //    sb.AppendLine("</style>");
    //    sb.AppendLine("</head>");



    //    // sb.Append("<head>");
    //    sb.AppendLine("Hi,<br/><br/>");
    //    sb.AppendLine("Material Return Request has been Authorized.<br/><br/>");
    //    sb.AppendLine("RequestID for your request is : " + lblRequestID.Text + " <br/><br/>");
    //    sb.AppendLine("Details are Shown below : <br/><br/>");
    //    sb.AppendLine("<table class=gridtable>");
    //    sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th><th> Invoice Qty</th><th> No. of Bales/Rolls</th> <th> Return Qty</th>  <th> Status</th> </tr>");
    //    //Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")
    //    sql = "Select invoice_no,item_no,customer,invoice_qty,bales,ret_qty from JCT_OPS_MATERIAL_REQUEST WHERE REQUESTID=" + lblRequestID.Text;
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    if (dr.HasRows)
    //    {
    //        while (dr.Read())
    //        {
    //            sb.AppendLine("<tr> <td> " + dr[0].ToString() + " </td> <td> " + dr[1].ToString() + "  </td>  <td> " + dr[2].ToString() + "</td>  <td>" + dr[3].ToString() + " </td>  <td>" + dr[4].ToString() + " </td>  <td>" + dr[5].ToString() + " </td> <td>Authorized </td> </tr> ");
    //        }
    //    }

    //    dr.Close();

    //    sb.AppendLine("</table>");
    //    sb.AppendLine("<br/><br/>");

    //    sb.AppendLine("<table class=gridtable>");
    //    sb.AppendLine("<tr></th> Freight Paid By <th><th> Gr No </th> <th> Gr Date  Freight Value </th><th> Freight Value </th> </tr>");
    //    //Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")

    //    sb.AppendLine("<tr> <td> " + lblFreightBy.Text + "</td>  <td> " + txtGrNo.Text + " </td> <td> " + txtGrDate.Text + "  </td>  <td>" + txtAmount.Text + " </td>  </tr> ");


    //    sb.AppendLine("</table>");

    //    sb.AppendLine("<br /><br/>");
    //    sb.Append("<a href='http://testerp/fusionapps/OPS/MaterialRequestPreview.aspx'> Click here to view detail... </a><br />");

    //    sb.AppendLine("</table><br /><br />");

    //    //sql = "Select empname from jct_empmast_base where empcode='"+ Session["EmpCode"] +"' and active='Y'";
    //    //sb.AppendLine("Authorized by : "+ obj1.FetchValue(sql).ToString() );

    //    sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
    //    sb.AppendLine("Thank you<br />");
    //    sb.AppendLine("</html>");


    //    body = sb.ToString();
    //    @from = "noreply@jctltd.com";
    //    sql = "SELECT isnull(b.E_MailID,'jatindutta@jctltd.com') as email FROM dbo.jct_ops_material_request a INNER JOIN dbo.MISTEL b ON a.userid=b.empcode WHERE  a.RequestID= " + lblRequestID.Text + "";
    //    to = "" + obj1.FetchValue(sql).ToString() + "";
    //    cc = "pgmohan@jctltd.com,ranjitsaini@jctltd.com,rameshs@jctltd.com,skj@jctltd.com,pkchhabra@jctltd.com,maingate@jctltd.com,mrsood@jctltd.com";
    //    bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com";
    //    //to = ("jatindutta@jctltd.com");
    //    //Email Address of Receiver
    //    //cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
    //    subject = " Material Return Request Authorized- " + lblCustomer.Text;
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
    //    //if (!string.IsNullOrEmpty(cc))
    //    //{
    //    //    if (cc.Contains(","))
    //    //    {
    //    //        string[] ccs = cc.Split(',');
    //    //        for (int i = 0; i <= ccs.Length - 1; i++)
    //    //        {
    //    //            mail.CC.Add(new MailAddress(ccs[i]));
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        mail.CC.Add(new MailAddress(bcc));
    //    //    }
    //    //    mail.CC.Add(new MailAddress(cc));
    //    //}
    //    body = sb.ToString();
    //    mail.Subject = subject;
    //    mail.Body = body;
    //    mail.IsBodyHtml = true;
    //    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //    SmtpClient SmtpMail = new SmtpClient("exchange2007");

    //    //SmtpMail.SmtpServer = "exchange2007";
    //    SmtpMail.Send(mail);
    //    //return mail;
    //}

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        grdDetail.DataSourceID = "SqlDataSource1";
        grdDetail.DataBind();
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            grdDetail.DataKeyNames.Equals("RequestID");
            String SanctionID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RequestID"));


            GridView GridViewNested_MultipleID = (GridView)e.Row.FindControl("nestedGridView_MultipleID");
            GridViewNested_MultipleID.DataKeyNames.Equals("SanctionNoteID");
            sql = "SELECT COUNT(*) AS count FROM dbo.jct_ops_material_request WHERE RequestID='" + SanctionID + "'";
            Int16 i = Convert.ToInt16(obj1.FetchValue(sql).ToString());

            if (i > 1)
            {
                Label lbl = (Label)e.Row.FindControl("lbl");
                lbl.Visible = true;
                lbl.ToolTip = "More than one invoices are in this request number. Expand to view Details..!!";
                sql = " SELECT invoice_no AS Invoice,item_no AS Sort,customer AS Customer,b.empname AS SalesPerson,invoice_qty AS InvoiceQty,ret_qty AS ReturnQty,reason AS Reason FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person = REPLACE(b.empcode, '-', '')   WHERE RequestID='" + SanctionID + "' ";
               SqlCommand cmd = new SqlCommand(sql, obj.Connection());
               SqlDataAdapter  da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridViewNested_MultipleID.DataSource = ds.Tables[0];
                GridViewNested_MultipleID.DataBind();
            }
            else
            {
                GridViewNested_MultipleID.DataSource = null;
                GridViewNested_MultipleID.DataBind();
            }


        }
    }

    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            sql = "  UPDATE  dbo.jct_ops_material_request SET bales='" + txtBales.Text + "',ret_qty='" + txtReturnQty.Text + "' WHERE RequestID= '" + lblRequestID.Text + "' AND invoice_no='" + ddlInvoiceNo.SelectedItem.Text + "'";
            obj1.UpdateRecord(sql);
            String Script = "alert('Record Updated..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Script, true);
        }

        catch (Exception ex)
        {
            String Script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Script, true);
        }
        
    }

    protected void ddlInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
    {
       // sql = "SELECT  item_no ,CONVERT(NUMERIC(15,2),invoice_qty) AS invoice_qty , ret_qty ,bales , Freight_by FROM    dbo.jct_ops_material_request WHERE   RequestID = " + lblRequestID.Text + " AND invoice_no='" + ddlInvoiceNo.SelectedItem.Text + "'";
        sql = "SELECT  item_no ,CONVERT(NUMERIC(15,2),invoice_qty) AS invoice_qty , Sum(ret_qty) as ret_qty ,Sum(bales) as bales , Freight_by FROM    dbo.jct_ops_material_request WHERE   RequestID = " + lblRequestID.Text + " AND invoice_no='" + ddlInvoiceNo.SelectedItem.Text + "' group by item_no,Freight_by,invoice_qty";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblItemNo.Text = dr["item_no"].ToString();
                lblInvoiceQty.Text = dr["invoice_qty"].ToString();
                txtReturnQty.Text = dr["ret_qty"].ToString();
                txtBales.Text = dr["bales"].ToString();
                lblFreightBy.Text = dr["Freight_by"].ToString();
            }
        }
    }
   
}