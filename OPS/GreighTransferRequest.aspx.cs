using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_GreighTransferRequest : System.Web.UI.Page
{
    public Connection obj = new Connection();
    Functions obj1 = new Functions();
    SaleOrderDetail so_detail = new SaleOrderDetail();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             
        }
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        bool issueOrder = false;

        var saleOrder = so_detail.GetSaleOrderDetails(txtSaleOrder.Text);

        if (saleOrder == null)
            return;

        // check if the new sale order is issued or not, if not then no request is to be generated
        issueOrder = CheckForIssuedOrder(txtNewSaleOrder.Text);

        if (issueOrder == true)
        {
            string script = "alert('Already issued against same orderno.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

        grdOrignalSaleOrder.DataSource = so_detail.GetSOTable(txtSaleOrder.Text);
        grdOrignalSaleOrder.DataBind();

        grdNewSaleOrder.DataSource = so_detail.GetSOTable(txtNewSaleOrder.Text);
        grdNewSaleOrder.DataBind();

    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        bool checkSort =false;
        bool checkQty = false;
        bool chkgrdSelection = false;
        bool issueOrder = false;

        // check if record is selected 
           chkgrdSelection = CheckGridSelection(grdOrignalSaleOrder);

           if (chkgrdSelection == false)
           {
               string script = "alert('No record selected..!!');";
               ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
               return;
           }

           chkgrdSelection = CheckGridSelection(grdNewSaleOrder);

        if (chkgrdSelection == false)
        {
            string script = "alert('No record selected..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

        // check if the original sale order is issued or not, if not then no request is to be generated
           issueOrder = CheckForIssuedOrder(txtSaleOrder.Text);

           if (issueOrder == false)
               return;

           // check if the new sale order is issued or not, if not then no request is to be generated
           issueOrder = CheckForIssuedOrder(txtNewSaleOrder.Text);

           if (issueOrder == true)
               return;

      
        // Check for same sort to be transfered
        //   checkSort = CheckSort();

        //if (checkSort == false)
        //    return;

        // Check if the Transfer From Qty and Transfer To Qty is same or less
           checkQty = CheckQty();

        if (checkQty == false)
           {
               string script = "alert('Check quantity to transfer..!!');";
               ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
               return;
           }

        // Generate the SanctionID
           GenerateSanctionID();

        // Save the request for selected items.
           SaveRequest();

        // Modify the sale order grids
           ReloadGrids();
    }

    private bool CheckForIssuedOrder(string order_no)
    {
        bool issue=false;
        string sql = string.Empty;

        sql = "select * from production..jct_process_issue_gry_det where po_num='" + order_no + "' and status<>'D'";
        if (!obj1.CheckRecordExistInTransaction(sql))
            issue = false;
        else
            issue = true;

        return issue;
    }

    private void ReloadGrids()
    {
        grdOrignalSaleOrder.DataSource = so_detail.GetSOTable(txtSaleOrder.Text);
        grdOrignalSaleOrder.DataBind();

        grdNewSaleOrder.DataSource = so_detail.GetSOTable(txtNewSaleOrder.Text);
        grdNewSaleOrder.DataBind();
    }

    private bool CheckForDyedOrder(string order_no,int line_no)
    {
        bool chk = false;
        string sql = "SELECT SUM(meters) FROM production..jct_process_prod_entries WHERE process IN (SELECT Process_Code FROM production..Jct_Process_Prod_Checks_With_Process WHERE Area='Processing' AND STATUS='A' and isdyeing='Y') AND po_number='"+ order_no +"' AND po_litem_no="+ line_no +"";
        //if (obj1.CheckRecordExistInTransaction(sql))
        if (!string.IsNullOrEmpty(obj1.FetchValue(sql).ToString()))
            chk = true;
        else
            chk = false;

        return chk;
    }

    private bool CheckGridSelection(GridView grd)
    {
        bool grd_selection = false;

        foreach (GridViewRow gvRow in grd.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            if (chk.Checked)
            {
                grd_selection = true;
                return grd_selection;
            }
            else
            { 
                grd_selection = false;
            }
        }

        return grd_selection;
    }

    private bool CheckSort()
    {
        bool compare;

        List<string> lst_sort = new List<string>();
        List<string> lst_sortnew = new List<string>();

        foreach (GridViewRow gvRow in grdOrignalSaleOrder.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            Label sort_no = (Label)gvRow.FindControl("lblsort_no");
            if(chk.Checked)
                lst_sort.Add(sort_no.Text);
        }

        foreach (GridViewRow gvRow in grdNewSaleOrder.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            Label sort_no = (Label)gvRow.FindControl("lblsort_no");

            var sort = Regex.Match(sort_no.Text, @"\d+").Value;

            if(chk.Checked)
                lst_sortnew.Add(sort.ToString());
        }

        //List<string> result = lst_sort.Except(lst_sortnew).ToList();

        compare = CompareLists2(lst_sort, lst_sortnew);

        return compare;
    }

    public bool CompareLists2(List<string> list1, List<string> list2)
    {
        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i].ToString() != list2[i].ToString())
                return false;
        }
        return true;
    }

    private bool CheckQty()
    {
        decimal qty = 0;
        decimal new_qty = 0;

        foreach (GridViewRow gvRow in grdOrignalSaleOrder.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            Label sort_no = (Label)gvRow.FindControl("lblsort_no");
            Label greigh_issued = (Label)gvRow.FindControl("lblgreigh_issued");
            Label greigh_transfered = (Label)gvRow.FindControl("lblgreigh_transfered");

            if(chk.Checked)
                qty += Convert.ToDecimal(greigh_issued.Text) - Convert.ToDecimal(greigh_transfered.Text);
        }

        foreach (GridViewRow gvRow in grdNewSaleOrder.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            Label sort_no = (Label)gvRow.FindControl("lblsort_no");
            TextBox to_transfer = (TextBox)gvRow.FindControl("txtto_transfer");

            if (chk.Checked)
                new_qty += Convert.ToDecimal(to_transfer.Text);
        }

        if (qty >= new_qty)
            return true;
        else
            return false;
    }

    private void GenerateSanctionID()
    {
        string sql = "JCT_OPS_SanctionNote_SanctionID";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["SanctionID"] = dr[0].ToString();
            }
        }
        dr.Close();
    }

    private void SaveRequest()
    {
        bool result=false;
        bool chkDyedOrder = false;

        SqlTransaction transaction;

        transaction = obj.Connection().BeginTransaction();

        foreach (GridViewRow gvRow in grdOrignalSaleOrder.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            Label order_no = (Label)gvRow.FindControl("lblorder_no");
            Label sort_no = (Label)gvRow.FindControl("lblsort_no");
            Label line_no = (Label)gvRow.FindControl("lblline_no");
            Label shade = (Label)gvRow.FindControl("lblshade");
            Label order_qty = (Label)gvRow.FindControl("lblorder_qty");
            Label sale_price = (Label)gvRow.FindControl("lblsale_price");
            Label greigh_requested = (Label)gvRow.FindControl("lblgreigh_requested");
            Label greigh_issued = (Label)gvRow.FindControl("lblgreigh_issued");
            Label greigh_transfered = (Label)gvRow.FindControl("lblgreigh_transfered");
            Label plant = (Label)gvRow.FindControl("lblplant");

            try
            {
                if (chk.Checked)
                {
                    // check for source order has been dyed or not.
                    // todo
                    chkDyedOrder = CheckForDyedOrder(order_no.Text, Convert.ToInt16(line_no.Text));

                    if (chkDyedOrder == true)
                    {
                        result = false;
                        // todo error msg
                        return;
                    }
                    else
                    {
                        string sql = "jct_ops_greigh_transfer_request_insert";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection(), transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@sanction_id", SqlDbType.VarChar, 50).Value = ViewState["SanctionID"];
                        cmd.Parameters.Add("@order_no", SqlDbType.VarChar, 50).Value = order_no.Text;
                        cmd.Parameters.Add("@sort_no", SqlDbType.VarChar, 50).Value = sort_no.Text;
                        cmd.Parameters.Add("@line_no", SqlDbType.Int).Value = line_no.Text;
                        if (shade.Text != null)
                        {
                            cmd.Parameters.Add("@shade", SqlDbType.VarChar, 100).Value = shade.Text;
                        }

                        cmd.Parameters.Add("@order_qty", SqlDbType.Decimal).Value = Convert.ToDecimal(order_qty.Text);
                        cmd.Parameters.Add("@sale_price", SqlDbType.Decimal).Value = Convert.ToDecimal(sale_price.Text);
                        cmd.Parameters.Add("@greigh_requested", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_requested.Text);
                        cmd.Parameters.Add("@greigh_issued", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_issued.Text);
                        cmd.Parameters.Add("@greigh_transfered", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_transfered.Text);
                        cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = plant.Text;
                        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                        cmd.Parameters.Add("@source_flag", SqlDbType.Char, 1).Value = 'Y'; // source_fla='Y' for source order and 'N' for transfer order no

                        cmd.ExecuteNonQuery();

                        result = true;
                    }
                }
            }
            catch (SqlException)
            {
                transaction.Rollback();
                result = false;
                return;
            }
            catch (Exception)
            {
                transaction.Rollback();
                result = false;
                return;
            }
        }

        foreach (GridViewRow gvRow in grdNewSaleOrder.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            Label order_no = (Label)gvRow.FindControl("lblorder_no");
            Label sort_no = (Label)gvRow.FindControl("lblsort_no");
            Label line_no = (Label)gvRow.FindControl("lblline_no");
            Label shade = (Label)gvRow.FindControl("lblshade");
            Label order_qty = (Label)gvRow.FindControl("lblorder_qty");
            Label sale_price = (Label)gvRow.FindControl("lblsale_price");
            Label greigh_requested = (Label)gvRow.FindControl("lblgreigh_requested");
            Label greigh_issued = (Label)gvRow.FindControl("lblgreigh_issued");
            Label greigh_transfered = (Label)gvRow.FindControl("lblgreigh_transfered");
            TextBox to_transfer = (TextBox)gvRow.FindControl("txtto_transfer");
            Label plant = (Label)gvRow.FindControl("lblplant");

            try
            {
                if (chk.Checked)
                {
                    string sql = "jct_ops_greigh_transfer_request_insert";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection(),transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sanction_id", SqlDbType.VarChar, 50).Value = ViewState["SanctionID"];
                    cmd.Parameters.Add("@order_no", SqlDbType.VarChar, 50).Value = order_no.Text;
                    cmd.Parameters.Add("@sort_no", SqlDbType.VarChar, 50).Value = sort_no.Text;
                    cmd.Parameters.Add("@line_no", SqlDbType.Int).Value = line_no.Text;
                    cmd.Parameters.Add("@shade", SqlDbType.VarChar, 100).Value = shade.Text == null ? string.Empty : shade.Text;
                    if (order_qty.Text != "")
                    { 
                        cmd.Parameters.Add("@order_qty", SqlDbType.Decimal).Value = Convert.ToDecimal(order_qty.Text);
                    }
                    if (sale_price.Text != "")
                    {
                        cmd.Parameters.Add("@sale_price", SqlDbType.Decimal).Value = Convert.ToDecimal(sale_price.Text);
                    }
                    if (greigh_requested.Text != "")
                    {
                        cmd.Parameters.Add("@greigh_requested", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_requested.Text);
                    }
                    if (greigh_issued.Text != "")
                    {
                        cmd.Parameters.Add("@greigh_issued", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_issued.Text);
                    }

                    if (greigh_transfered.Text != "")
                    {
                        cmd.Parameters.Add("@greigh_transfered", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_transfered.Text);
                    }

                    if (to_transfer.Text != "")
                    {
                        cmd.Parameters.Add("@to_transfer", SqlDbType.Decimal).Value = Convert.ToDecimal(to_transfer.Text);
                    }
                    cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = plant.Text;
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                    
                    if (txtRemarks.Text != "")
                    {
                        cmd.Parameters.Add("@remarks",SqlDbType.VarChar,2000).Value = txtRemarks.Text;
                    }

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    result = true;

                    // generate mail
                    SendMail();
                }
            }
            catch (SqlException)
            {
                transaction.Rollback();
                result = false;
                return;
            }
            catch (Exception)
            {
                transaction.Rollback();
                result = false;
                return;
            }
        }

        if (result == true)
        {
            string script = "alert('Request submitted ...');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else
        {
            string script = "alert('Request aborted ...');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    private void SendMail()
    {
        string from = string.Empty;
        string to = string.Empty;
        string cc = string.Empty;
        string bcc = string.Empty;
        string body = string.Empty;
        string sql = string.Empty;
        string EMail_LoggedinUser = string.Empty;
        string RequestBy = string.Empty;
        string remarks = string.Empty;
        string subject = string.Empty;

        SqlDataReader dr;
        SqlCommand cmd;
        StringBuilder sb = new StringBuilder();

        sql = "Select empname from jct_empmast_base where empcode='J-01945'";//'" + Session["EmpCode"] + "'";
        RequestBy = obj1.FetchValue(sql).ToString();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");
        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Greigh transfer request generated.<br/><br/>");

        foreach (GridViewRow gvRow in grdOrignalSaleOrder.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            Label order_no = (Label)gvRow.FindControl("lblorder_no");
            Label sort_no = (Label)gvRow.FindControl("lblsort_no");
            Label line_no = (Label)gvRow.FindControl("lblline_no");
            Label shade = (Label)gvRow.FindControl("lblshade");
            Label order_qty = (Label)gvRow.FindControl("lblorder_qty");
            Label sale_price = (Label)gvRow.FindControl("lblsale_price");
            Label greigh_requested = (Label)gvRow.FindControl("lblgreigh_requested");
            Label greigh_issued = (Label)gvRow.FindControl("lblgreigh_issued");
            Label greigh_transfered = (Label)gvRow.FindControl("lblgreigh_transfered");
            Label plant = (Label)gvRow.FindControl("lblplant");

            if (chk.Checked)
            { 
                // find order detail
                sql = "Select e_mailid from mistel where empcode='J-01945'";//'" + Session["EmpCode"] + "'";
                EMail_LoggedinUser = obj1.FetchValue(sql).ToString();

                sql = "JCT_OPS_GET_SALE_PERSON_EMAIL";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = order_no.Text;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViewState["ActualOrder_EmailID"] = dr[0].ToString();
                    }
                }
                dr.Close();
            }
        }

        foreach (GridViewRow gvRow in grdNewSaleOrder.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("chkSelect");
            Label order_no = (Label)gvRow.FindControl("lblorder_no");
            Label sort_no = (Label)gvRow.FindControl("lblsort_no");
            Label line_no = (Label)gvRow.FindControl("lblline_no");
            Label shade = (Label)gvRow.FindControl("lblshade");
            Label order_qty = (Label)gvRow.FindControl("lblorder_qty");
            Label sale_price = (Label)gvRow.FindControl("lblsale_price");
            Label greigh_requested = (Label)gvRow.FindControl("lblgreigh_requested");
            Label greigh_issued = (Label)gvRow.FindControl("lblgreigh_issued");
            Label greigh_transfered = (Label)gvRow.FindControl("lblgreigh_transfered");
            TextBox to_transfer = (TextBox)gvRow.FindControl("txtto_transfer");
            Label plant = (Label)gvRow.FindControl("lblplant");

            if (chk.Checked)
            {
                sql = "JCT_OPS_GET_SALE_PERSON_EMAIL";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = order_no.Text;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViewState["Adjusted_EmailID"] = dr[0].ToString();
                    }
                }
                dr.Close();
            }
        }

        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> SanctionID</th> <th>OrderNo</th> <th>SortNo</th> <th>LineItem</th> <th>Shade</th> <th>Qty</th><th>GreighTransfered</th><th>GreighTransfered</th><th>GreighTransfered</th><th>Greigh Issued</th><th>Transfer Mtrs</th><th>Source order</th></tr>");
        sql = "select Sanction_id as SanctionID,order_no as OrderNo,sort_no as SortNo,line_no as LineItem,Shade,order_qty as Qty,Greigh_Transfered as GreighTransfered,greigh_issued as GreighIssued,to_transfered as TransferMtrs,source_flag as SourceFlag from jct_ops_greigh_transfer where sanction_id='"+ ViewState["SanctionID"] +"'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr><td>  " + dr["SanctionID"].ToString() + " </td> <td>  " + dr["OrderNo"].ToString() + " </td>  <td> " + dr["SortNo"].ToString() + "</td>  <td> " + dr["LineItem"].ToString() + "</td>  <td> " + dr["Shade"].ToString() + "</td>  <td>" + dr["Qty"].ToString() + "</td><td>" + dr["GreighTransfered"].ToString() + "</td> <td>" + dr["GreighIssued"].ToString() + "</td> <td>" + dr["TransferMtrs"].ToString() + "</td> <td>" + dr["SourceFlag"].ToString() + "</td></tr>");
            }
        }
        dr.Close();
        sb.AppendLine("</table>");
        sb.AppendLine("<br /><br />");
        sb.AppendLine("Request generated by :" + RequestBy);
        sb.AppendLine("<br /><br />");

        sql = "Select distinct isnull(remarks,'') as remarks from jct_ops_greigh_transfer where sanction_id ='" + ViewState["SanctionID"] + "' and status='P'";
        cmd = new SqlCommand(sql, obj.Connection());
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                remarks = dr["remarks"].ToString();
            }
        }
        else
        {
            remarks = string.Empty;
        }
        dr.Close();

        //remarks = obj1.FetchValue(sql).ToString();

        sb.AppendLine("Remarks :" + remarks);
        sb.AppendLine("<br /><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        //to = "jatindutta@jctltd.com";
        if (!string.IsNullOrEmpty(EMail_LoggedinUser))
        {
            to = "neeraj@jctltd.com,karanjitsaini@jctltd.com,bipansharma@jctltd.com," + ViewState["ActualOrder_EmailID"] + "," + ViewState["Adjusted_EmailID"] + " , " + EMail_LoggedinUser + " ";   //Email Address of Receiver
        }
        else
        {
            to = "neeraj@jctltd.com,karanjitsaini@jctltd.com,bipansharma@jctltd.com," + ViewState["ActualOrder_EmailID"] + "," + ViewState["Adjusted_EmailID"];   //Email Address of Receiver
        }

        to = "jatindutta@jctltd.com";
        //bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        //cc = "sobti@jctltd.com";
        subject = "Request - Greigh Transfer";
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
    }

    private void SourceOrderEmailData(string order_no, int line_no)
    {
        string sql = "";
    }

    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow gvRow = (GridViewRow)chk.Parent.Parent;

        if (chk.Checked)
        {
            // Disable all other rows
            DisableGridRows(grdOrignalSaleOrder, gvRow);
        }
        else
        { 
            // Enable all rows
            EnableGridRows(grdOrignalSaleOrder, gvRow);
        }
    }

    private void EnableGridRows(GridView grd, GridViewRow gvRow)
    {
        foreach (GridViewRow gridRow in grd.Rows)
        {
                gridRow.Enabled = true;
        }
    }

    private void DisableGridRows(GridView grd, GridViewRow gvRow)
    {
        foreach (GridViewRow gridRow in grd.Rows)
        {
            if (gridRow != gvRow)
                gridRow.Enabled = false;
        }
    }

    protected void ChkSelectedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow gvRow = (GridViewRow)chk.Parent.Parent;

        if (chk.Checked)
        {
            // Disable all other rows
            DisableGridRows(grdNewSaleOrder, gvRow);
        }
        else
        {
            // Enable all rows
            EnableGridRows(grdNewSaleOrder, gvRow);
        }
    }

    protected void grdOrignalSaleOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        bool chk = false;
        bool chk_qty = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label orderno = (Label)e.Row.FindControl("lblorder_no");
            Label lineno = (Label)e.Row.FindControl("lblline_no");

            // Check for the previous requests of greigh transfer against the order no
            chk = so_detail.CheckOrderData(orderno.Text, Convert.ToInt16(lineno.Text));

            if (chk == true)
                // Check for the previous request order qty // todo - not working
                chk_qty = so_detail.CheckOrderQty(orderno.Text, Convert.ToInt16(lineno.Text));
            else
                return;

            if (chk_qty == true)
                e.Row.Enabled = true;
            else
                e.Row.Enabled = false;
        }
    }

    protected void grdNewSaleOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        bool chk = false;
        bool chk_qty = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label orderno = (Label)e.Row.FindControl("lblorder_no");
            Label lineno = (Label)e.Row.FindControl("lblline_no");

            // Check for the previous requests of greigh transfer against the order no
            chk = so_detail.CheckOrderData(orderno.Text, Convert.ToInt16(lineno.Text));

            if (chk == true)
                // Check for the previous request order qty // todo - not working
                chk_qty = so_detail.CheckOrderQty(orderno.Text, Convert.ToInt16(lineno.Text));
            else
                return;

            if (chk_qty == true)
                e.Row.Enabled = true;
            else
                e.Row.Enabled = false;
        }
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/GreighTransferRequest.aspx");
    }

    protected void lnkModify_Click(object sender, EventArgs e)
    {
        // find records for the enetered sale order
        FindSavedRequest(txtSaleOrder.Text);
    }

    private void FindSavedRequest(string order_no)
    {
        string sql = string.Empty;

        sql = "select sanction_id as ID,order_no,sort_no,line_no,shade,order_qty,sale_price,greigh_issued,greigh_transfered from jct_ops_greigh_transfer where status in ('P','A') and order_no='" + order_no + "' and source_flag='Y'";
        obj1.FillGrid(sql, ref grdModify);
    }

    protected void grdModify_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string sql = string.Empty;

        GridView grdChild = (GridView)e.Row.FindControl("grdChildModify");

        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = grdModify.DataKeys[e.Row.RowIndex].Values[0].ToString();

            sql = "select * from jct_ops_greigh_transfer where sanction_id='"+ id +"' and status='A'";
            if (obj1.CheckRecordExistInTransaction(sql))
                e.Row.Enabled = false;

            // find child records for the selected id
            FindSavedRequestChildGird(id, grdChild);
         }
    }

    private void FindSavedRequestChildGird(string id,GridView gv)
    {
        string sql = string.Empty;

        sql = "select sanction_id as ID,order_no,sort_no,line_no,shade,order_qty,sale_price,isnull(greigh_issued,0) as greigh_issued,greigh_transfered,to_transfered as to_transfer from jct_ops_greigh_transfer where status='A'  and source_flag is null  and sanction_id='" + id + "'";
        obj1.FillGrid(sql, ref gv);
    }

    protected void grdModify_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sql = string.Empty;

        if (e.CommandName == "Delete")
        {
            //int rowIndex = int.Parse(e.CommandArgument.ToString());
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int rowIndex = gvr.RowIndex;

            string id = (string)this.grdModify.DataKeys[rowIndex]["ID"];

            sql = "Update jct_ops_greigh_transfer set status='D' where sanction_id='"+ id +"' and status='P'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.ExecuteNonQuery();

            FindSavedRequest(txtSaleOrder.Text);

            string script = "alert('Record deleted ...');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else if (e.CommandName == "Authorize")
        {
            //int rowIndex = int.Parse(e.CommandArgument.ToString());
           

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int rowIndex = gvr.RowIndex;

            string id = (string)this.grdModify.DataKeys[rowIndex]["ID"];

            sql = "jct_ops_greigh_transfer_request_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sanctionid", SqlDbType.VarChar, 20).Value = id;
            cmd.ExecuteNonQuery();

            FindSavedRequest(txtSaleOrder.Text);

            string script = "alert('Record authorized ...');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

}

public class SaleOrder
{
    public string order_no { get; set; }

    public string sort_no { get; set; }

    public int line_no { get; set; }

    public string shade { get; set; }

    public decimal sale_price { get; set; }

    public decimal order_qty { get; set; }

    public decimal greigh_requested { get; set; }

    public decimal greigh_issued { get; set; }

    public decimal greigh_transfered { get; set; }

    public string plant { get; set; }
}

public class SaleOrderDetail
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;

    public SaleOrder GetSaleOrderDetails(string sale_order)
    {
        SaleOrder so = new SaleOrder();

        sql = "jct_ops_get_issued_order_detail";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType =CommandType.StoredProcedure;
        cmd.Parameters.Add("@order_no",SqlDbType.VarChar,30).Value=sale_order;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                so.order_no = dr["order_no"].ToString();
                so.line_no = Convert.ToInt16(dr["line_no"].ToString());
                so.shade = dr["shade"].ToString();

                if (dr["sale_price"] == null)
                    so.sale_price = Convert.ToDecimal(dr["sale_price"].ToString());
                else
                    so.sale_price = 0;

                so.sort_no = dr["sort_no"].ToString();

                if (dr["greigh_requested"] == null)
                    so.greigh_requested = Convert.ToDecimal(dr["greigh_requested"].ToString());
                else
                    so.greigh_requested = 0;

                if (dr["greigh_transfered"] == null)
                    so.greigh_transfered = Convert.ToDecimal(dr["greigh_transfered"].ToString());
                else
                    so.greigh_transfered = 0;

                if (dr["greigh_issued"] == null)
                    so.greigh_issued = Convert.ToDecimal(dr["greigh_issued"].ToString());
                else
                    so.greigh_issued = 0;

                so.plant = dr["plant"].ToString();

                if (dr["order_qty"] == null)
                    so.order_qty = Convert.ToDecimal(dr["order_qty"].ToString());
                else
                    so.order_qty = 0;
            }
        }
        dr.Close();
        return so;
    }

    public DataTable GetSOTable(string sale_order)
    {
        SaleOrder so = new SaleOrder();

        sql = "jct_ops_get_issued_order_detail";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@order_no", SqlDbType.VarChar, 30).Value = sale_order;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds.Tables[0];
    }

    public bool CheckOrderData(string sale_order, int line_no)
    {
        bool chk=false;

        sql = "select * from jct_ops_greigh_transfer where status in ('P','A') and source_flag='Y' and order_no='"+ sale_order +"' and line_no ="+ line_no +"";
        if (obj1.CheckRecordExistInTransaction(sql))
            chk = true;
        else
            chk = false;

        return chk;
    }
    public bool CheckOrderQty(string sale_order, int line_no)
    {
        bool chk = false;
        int i;

        sql = "jct_ops_greigh_transfer_order_check_request_qty";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@order_no", SqlDbType.VarChar, 30).Value = sale_order;
        cmd.Parameters.Add("@line_no", SqlDbType.Int).Value = line_no;
        cmd.Parameters.Add("@ret_val", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();

        i = (int) cmd.Parameters["@ret_val"].Value;

        if (i == 1)
            chk = true;
        else
            chk = false;

        return chk;
    }

}