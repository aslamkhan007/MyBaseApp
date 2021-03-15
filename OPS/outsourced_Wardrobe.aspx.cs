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

public partial class OPS_outsourced_Wardrobe : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Empcode"] == "")
            {
                Response.Redirect("~/Login.aspx");

            }
            fun1();
        }
    }

    private void fun1()
    {


        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SortNo/DesignsNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Shade", typeof(string)));
        dt.Columns.Add(new DataColumn("TOTQty(mts)", typeof(string)));
        dt.Columns.Add(new DataColumn("Rate per(mts)", typeof(string)));
        dt.Columns.Add(new DataColumn("SalePer(mts)", typeof(string)));
        dt.Columns.Add(new DataColumn("SupplierName", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dt.Columns.Add(new DataColumn("PaymentTerms", typeof(string)));
        dt.Columns.Add(new DataColumn("FreightPaidBy", typeof(string)));
        dr = dt.NewRow();
        dr["SortNo/DesignsNo"] = string.Empty;
        dr["Shade"] = string.Empty;
        dr["TOTQty(mts)"] = string.Empty;
        dr["Rate per(mts)"] = string.Empty;
        dr["SalePer(mts)"] = string.Empty;
        dr["SupplierName"] = string.Empty;
        dr["Remarks"] = string.Empty;
        dr["PaymentTerms"] = string.Empty;
        dr["FreightPaidBy"] = string.Empty;
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        ViewState["CurrentTable"] = dt;
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
    }


    private void fun2()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values

                    TextBox box2 = (TextBox)grdDetail.Rows[rowIndex].Cells[0].FindControl("txtsort");
                    TextBox box3 = (TextBox)grdDetail.Rows[rowIndex].Cells[1].FindControl("txtshade");
                    TextBox box4 = (TextBox)grdDetail.Rows[rowIndex].Cells[2].FindControl("txttotqty");
                    TextBox box5 = (TextBox)grdDetail.Rows[rowIndex].Cells[3].FindControl("txtrate");
                    TextBox box6 = (TextBox)grdDetail.Rows[rowIndex].Cells[4].FindControl("txtsale");
                    TextBox box7 = (TextBox)grdDetail.Rows[rowIndex].Cells[5].FindControl("txtsuppplr");
                    TextBox box8 = (TextBox)grdDetail.Rows[rowIndex].Cells[6].FindControl("txtremarks");
                    TextBox box9 = (TextBox)grdDetail.Rows[rowIndex].Cells[7].FindControl("txtpayterm");
                    DropDownList box1 = (DropDownList)grdDetail.Rows[rowIndex].Cells[8].FindControl("ddlfreight");
                   


                    //Label TransNo = (Label)grdDetail.Rows[rowIndex].Cells[0].FindControl("lblTransNo");
                    drCurrentRow = dtCurrentTable.NewRow();
                    //  drCurrentRow["RowNumber"] = i + 1;
  

                    dtCurrentTable.Rows[i - 1]["SortNo/DesignsNo"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Shade"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["TOTQty(mts)"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["Rate per(mts)"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["SalePer(mts)"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["SupplierName"] = box7.Text;
                    dtCurrentTable.Rows[i - 1]["Remarks"] = box8.Text;
                    dtCurrentTable.Rows[i - 1]["PaymentTerms"] = box9.Text;
                    dtCurrentTable.Rows[i - 1]["FreightPaidBy"] = box1.Text;
 
                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                grdDetail.DataSource = dtCurrentTable;
                grdDetail.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
        fun3();
    }

    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox Sort = (TextBox)grdDetail.Rows[rowIndex].Cells[1].FindControl("txtsort");
                    TextBox Shade = (TextBox)grdDetail.Rows[rowIndex].FindControl("txtshade");
                    TextBox Qty = (TextBox)grdDetail.Rows[rowIndex].FindControl("txttotqty");
                    TextBox Rate = (TextBox)grdDetail.Rows[rowIndex].FindControl("txtrate");
                    TextBox Sale = (TextBox)grdDetail.Rows[rowIndex].FindControl("txtsale");
                    TextBox Supplier = (TextBox)grdDetail.Rows[rowIndex].FindControl("txtsuppplr");
                    TextBox Remarks = (TextBox)grdDetail.Rows[rowIndex].FindControl("txtremarks");
                    TextBox payterm = (TextBox)grdDetail.Rows[rowIndex].FindControl("txtpayterm");
                    DropDownList freight = (DropDownList)grdDetail.Rows[rowIndex].FindControl("ddlfreight");
                    Sort.Text = dt.Rows[i]["SortNo/DesignsNo"].ToString();
                    Shade.Text = dt.Rows[i]["Shade"].ToString();
                    Qty.Text = dt.Rows[i]["TOTQty(mts)"].ToString();
                    Rate.Text = dt.Rows[i]["Rate per(mts)"].ToString();
                    Sale.Text = dt.Rows[i]["SalePer(mts)"].ToString();
                    Supplier.Text = dt.Rows[i]["SupplierName"].ToString();
                    Remarks.Text = dt.Rows[i]["Remarks"].ToString();
                    payterm.Text = dt.Rows[i]["PaymentTerms"].ToString();
                    freight.Text = dt.Rows[i]["FreightPaidBy"].ToString();
                    rowIndex++;
                }
            }
        }
    }

    protected void lnkaddrw_Click(object sender, EventArgs e)
    {
        fun2();
    }


    private void fun3()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box2 = (TextBox)grdDetail.Rows[rowIndex].Cells[0].FindControl("txtsort");
                    TextBox box3 = (TextBox)grdDetail.Rows[rowIndex].Cells[1].FindControl("txtshade");
                    TextBox box4 = (TextBox)grdDetail.Rows[rowIndex].Cells[2].FindControl("txttotqty");
                    TextBox box5 = (TextBox)grdDetail.Rows[rowIndex].Cells[3].FindControl("txtrate");
                    TextBox box6 = (TextBox)grdDetail.Rows[rowIndex].Cells[4].FindControl("txtsale");
                    TextBox box7 = (TextBox)grdDetail.Rows[rowIndex].Cells[5].FindControl("txtsuppplr");
                    TextBox box8 = (TextBox)grdDetail.Rows[rowIndex].Cells[5].FindControl("txtremarks");
                    TextBox box9 = (TextBox)grdDetail.Rows[rowIndex].Cells[7].FindControl("txtpayterm");
                    DropDownList box1 = (DropDownList)grdDetail.Rows[rowIndex].Cells[8].FindControl("ddlfreight");
                   
                    rowIndex++;
                }
            }
        }
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (rdlst.SelectedIndex == 1)
        {

            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        }
    }
    protected void rdlst_SelectedIndexChanged(object sender, EventArgs e)
    {
       

            fun1();
        

    }
    protected void lnk_Click(object sender, EventArgs e)
    {
        TextBox txt = new TextBox();
        TextBox txt2 = new TextBox();
        TextBox txt3 = new TextBox();
        TextBox txt4 = new TextBox();
        TextBox txt5 = new TextBox();
        TextBox txt6 = new TextBox();
        TextBox txt7 = new TextBox();
        TextBox txt8 = new TextBox();
        DropDownList ddl = new DropDownList();
        GenerateCode();
        foreach (GridViewRow rw in grdDetail.Rows)
        {

            txt = (TextBox)rw.FindControl("txtsort");
            txt2 = (TextBox)rw.FindControl("txtshade");
            txt3 = (TextBox)rw.FindControl("txttotqty");
            txt4 = (TextBox)rw.FindControl("txtrate");
            txt5 = (TextBox)rw.FindControl("txtsale");
            txt6 = (TextBox)rw.FindControl("txtsuppplr");
            txt7 = (TextBox)rw.FindControl("txtremarks");
            txt8 = (TextBox)rw.FindControl("txtpayterm");
            ddl = (DropDownList)rw.FindControl("ddlfreight");
            if (rdlst.SelectedIndex == 0 &&( txt4.Text == "" || txt5.Text == ""))
            {
                 string script1 = "alert('please enter rate and sale price ');";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
 
            }

            else
            {
                SqlCommand cmd = new SqlCommand("jct_ops_outsourced_wardrobe_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 50).Value = rdlst.SelectedItem.Value;
                cmd.Parameters.Add("@sort_no", SqlDbType.VarChar, 30).Value = txt.Text;
                cmd.Parameters.Add("@Shade ", SqlDbType.VarChar, 100).Value = txt2.Text;
                cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Value = txt7.Text;
                cmd.Parameters.Add("@payterms", SqlDbType.VarChar, 100).Value = txt8.Text;
                cmd.Parameters.Add("@freightby", SqlDbType.VarChar, 100).Value = ddl.Text;

                cmd.Parameters.Add("@totqty", SqlDbType.Decimal).Value = Convert.ToDecimal(txt3.Text == "" ? 0 : Convert.ToDecimal(txt3.Text));
                cmd.Parameters.Add("@sale_per_mts ", SqlDbType.Decimal).Value = Convert.ToDecimal(txt5.Text == "" ? 0 : Convert.ToDecimal(txt5.Text));
                cmd.Parameters.Add("@supplier ", SqlDbType.VarChar, 100).Value = txt6.Text;
                cmd.Parameters.Add("@rate ", SqlDbType.Decimal).Value = Convert.ToDecimal(txt4.Text == "" ? 0 : Convert.ToDecimal(txt4.Text));
                cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@enteredby", SqlDbType.VarChar, 10).Value = Session["EMPCODE"];
                cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = "cotton";

                cmd.ExecuteNonQuery();
                con.Close();

                string script = "alert(' record saved sucesfully.!please press clear button! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                lnksave.Enabled = false;
                lbID.Text = ViewState["RequestID"].ToString();
                lbID.Visible = true;
                lbreq.Visible = true;
                
            }
        }
        try
        {
            SendMail();
        }
        catch
        {
        }
    }

    protected void lnkclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("outsourced_Wardrobe.aspx");
    }

    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;



        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        con.Open();

        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(reqid),CHARINDEX('-',max( reqid))+1,len(max(reqid))+2) from jct_ops_outsourced_wardrobe", con);
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
                    ViewState["RequestID"] = "WR-" + ViewState["RequestID"];
                }
                else
                {
                    ViewState["RequestID"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["RequestID"] = "WR-" + ViewState["RequestID"];
                }
            }

        }

        dr.Close();
        con.Close();

        #endregion
    }

   

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        if (rdlst.SelectedIndex == 1)
        {
            //SendMailraw();

        }

        //SendMail();
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
        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        con.Open();
        string sql = "SELECT b.EMPCODE,c.empname,d.E_MailID AS Email FROM jct_ops_outsourced_wardrobe a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON CONVERT(VARCHAR,a.Reqid) = b.ID AND a.pending_at=CONVERT(VARCHAR,b.USERLEVEL) INNER JOIN dbo.JCT_EmpMast_Base c ON c.empcode=b.EMPCODE LEFT OUTER JOIN dbo.MISTEL d on d.empcode=b.EMPCODE where CONVERT(VARCHAR,a.Reqid) ='" + ViewState["RequestID"] + "'";
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
        sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");

        sql = "jct_ops_outsourced_select";
        cmd = new SqlCommand(sql, con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"].ToString();
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while ((Dr.Read()))
            {

                sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
                sb.AppendLine("<tr><td colspan='4'> GENERAL MANAGER - MARKETING</td></tr> ");
                sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED DYED FABRIC</td> </tr>");
                sb.AppendLine("<tr><td> CONSTRUCTION</td>  <td>   </tr>");
                sb.AppendLine("<tr><td>RequestID </td> <td>" + Dr["reqid"].ToString() + "</td>  </tr>");
                sb.AppendLine("<tr><td>Purchase By </td> <td>" + Dr["purchase_by"].ToString() + "</td>  </tr>");
                sb.AppendLine("<tr><td>Sort no/td> <td> " + Dr["sort_no"].ToString() + "</td> </tr>");
                sb.AppendLine("<tr><td> Designs no</td><td> " + Dr["Designs_no"].ToString() + "</td> </tr>");
                sb.AppendLine("<tr><td> Totqty</td><td>" + Dr["totqty"].ToString() + "</td> </tr>");
                //sb.AppendLine("<tr> <td>Rate(per_mts)</td> <td> " + Dr["rateper_mts"].ToString() + "</td> </tr>");
                //sb.AppendLine("<tr><td>Sale(Per_mts)</td><td>" + Dr["sale_per_mts"].ToString() + "</td> </tr>");
                //sb.AppendLine("<tr> <td>Supplier</td><td> " + Dr["supplier"] + "</td> </tr>");
                //    sb.AppendLine("<tr><td>  DELIVERY UPTO</td><td> </td> <td>" + Dr["DeliveryTerm"].ToString() + "</td>  <td>&nbsp;</td> </tr>");
                //    sb.AppendLine("<tr><td>JCT PARALLEL SORT NO. (IF ANY)</td> <td> " + Dr["ParallelSort"].ToString() + "</td><td>&nbsp;</td><td>&nbsp;</td> </tr>");
                //    sb.AppendLine("<tr> <td> ANY SPECIAL SPECIFICATION</td><td> &nbsp;</td> <td>  &nbsp;</td> <td>  &nbsp;</td></tr>");
                //    sb.AppendLine("<tr><td colspan='2'>   PURCHASE</td> <td colspan='2'>" + Dr["Purchase"].ToString() + "</td></tr>");
                //    sb.AppendLine("<tr><td colspan='2'>FINISH SALE PRICE</td><td colspan='2'>" + Dr["FinishSalePrice"].ToString() + "</td></tr>");

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

        //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
        bcc = "shwetaloria@jctltd.com";//jatindutta@jctltd.com
        subject = "Outsourced Fabric Request - " + ViewState["RequestID"];
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
        #endregion

    }

    protected void grdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                rowIndex = gvr.RowIndex;

                dt.Rows.RemoveAt(rowIndex);
                grdDetail.DataSource = dt;
                grdDetail.DataBind();
                SetPreviousData();
                ViewState["CurrentTable"] = dt;

            }
           
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

        con.Open();
        //string sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
        //SqlCommand cmd = new SqlCommand(sql, con);
        //SqlDataReader Dr = cmd.ExecuteReader();
        //if (Dr.HasRows)
        //{
        //    while (Dr.Read())
        //    {
        //        ViewState["RequestBy"] = Dr["empname"].ToString();
        //        ViewState["RequestByEmail"] = Dr["email"].ToString();
        //    }
        //}
        //Dr.Close();

        string sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
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
                //sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
                //sb.AppendLine("<tr><td colspan='4'> GENERAL MANAGER - MARKETING</td></tr> ");
                //sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED DYED FABRIC</td> </tr>");
                //sb.AppendLine("<tr><td> CONSTRUCTION</td>  <td>   </tr>");
                //sb.AppendLine("<tr><td>RequestID </td> <td>" + Dr["reqid"].ToString() + "</td>  </tr>");
                //sb.AppendLine("<tr><td>Purchase By </td> <td>" + Dr["purchase_by"].ToString() + "</td>  </tr>");
                //sb.AppendLine("<tr><td>Sortno/DesignNo</td> <td> " + Dr["sort_no"].ToString() + "</td> </tr>");
                //sb.AppendLine("<tr> <td>Shade</td><td> " + Dr["shade"] + "</td> </tr>");
                //sb.AppendLine("<tr><td> Totqty</td><td>" + Dr["totqty"].ToString() + "</td> </tr>");
                //sb.AppendLine("<tr> <td>Rate(per_mts)</td> <td> " + Dr["rateper_mts"].ToString() + "</td> </tr>");
                //sb.AppendLine("<tr><td>Sale(Per_mts)</td><td>" + Dr["sale_per_mts"].ToString() + "</td> </tr>");
                //sb.AppendLine("<tr> <td>Supplier</td><td> " + Dr["supplier"] + "</td> </tr>");
                //sb.AppendLine("<tr> <td>Remarks</td><td> " + Dr["remarks"] + "</td> </tr>");
                //sb.AppendLine("<tr> <td>PaymentTerms</td><td> " + Dr["payterms"] + "</td> </tr>");
                //sb.AppendLine("<tr> <td>FreightPaidBy</td><td> " + Dr["Freightby"] + "</td> </tr>");

            }
        }

        Dr.Close();
        con.Close();
        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");

        sb.Append("<a href='http://testerp/fusionapps/OPS/float and freeze.aspx'> Request has been sent for float anf freeze..!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "outsourcing@jctltd.com";

        to = ViewState["RequestByEmail"].ToString();
        //to = "shwetalorai@jctltd.com";
        //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
        bcc = "shwetaloria@jctltd.com,jatindutta@jctltd.com";
        subject = "Outsourced WardRobe Request - " + ViewState["RequestID"];
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
}




