using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mail;

public partial class OPS_ShortFall_Plan : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    String script;
    String mon;
    Char Flag;
    SendMail Sm = new SendMail();
    DropDownList ddlRevisionNo = new DropDownList();
    float sumLooms = 0;
    float LoomsperDayTotal = 0;
    float ToatalWvgDays = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //FillGrid();
        }
    }

    protected void FillGrid()
    {
        sql = "JCT_OPS_FETCH_SHORTFALL_MTRS_FOR_PLANNING";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdShortfall.DataSource = ds;
        grdShortfall.DataBind();
    }

    protected int yearMonth()
    {
        sql = "Select month('" + txtEffecFrom.Text + "')";
        mon = obj1.FetchValue(sql).ToString();
        int mon1 = int.Parse(mon);
        if (mon1 < 10)
        {
            mon = "0" + mon;
        }
        sql = "Select year('" + txtEffecTo.Text + "')";
        String year = obj1.FetchValue(sql).ToString();
        String yearmonth = year + mon;
        int year_month = int.Parse(yearmonth);
        return year_month;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/OPS/Final_Plan2.aspx");
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
       
        FillGrid();
    }

    //protected void RePlan_SendMail(String To, String CC, String BCC, String Subject, String Body)
    //{
        
    //    MailMessage mailMessage = new MailMessage();
    //    mailMessage.From = "noreply@jctltd.com";
    //    mailMessage.To = To;
    //    mailMessage.BodyFormat = MailFormat.Html;


    //    mailMessage.Cc = CC;
    //    mailMessage.Subject = Subject;
    //    mailMessage.Bcc=BCC;
    //    mailMessage.Body = Body;

     
    //        SmtpMail.SmtpServer = "exchange2007";
    //        SmtpMail.Send(mailMessage);
        
     
    //}

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/OPS/SetPriority_WeavePlan.aspx");
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
      
    }


    protected void grdShortfall_RowCommand(object sender, GridViewCommandEventArgs e)
    {   
        //if (e.CommandName == "Select")
        //{
          
          

        //}
    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
   {

        try
        {
            Label orderno = (Label)frvShortfall.FindControl("lblOrder");
            Label Sort = (Label)frvShortfall.FindControl("lblSort");
            Label WeavingSort = (Label)frvShortfall.FindControl("lblWeavingSort");
            Label Req_Dt = (Label)frvShortfall.FindControl("lblDeliveryDate");
            Label LineItem = (Label)frvShortfall.FindControl("lblLineItem");
            Label Req_Qty = (Label)frvShortfall.FindControl("lblOrderQty");
            TextBox Sizing = (TextBox)frvShortfall.FindControl("txtSizing");
            TextBox Expected_Delivery_Dt = (TextBox)frvShortfall.FindControl("txtExpectedDelivery");
            DropDownList Shed = (DropDownList)frvShortfall.FindControl("ddlShed");
            TextBox MtrsReProduced = (TextBox)frvShortfall.FindControl("txtMtrsReProduced");
            Label Greigh_Produced = (Label)frvShortfall.FindControl("lblGreighProduced");
            TextBox LoomAllot = (TextBox)frvShortfall.FindControl("txtLooms");
            Label WvgCompletionDt = (Label)frvShortfall.FindControl("lblWvgDays");
            TextBox Grey_ReqDt = (TextBox)frvShortfall.FindControl("txtGreighDate");
            TextBox Grey_Adj = (TextBox)frvShortfall.FindControl("txtGreighAdj");
            TextBox TotalGreighRequired = (TextBox)frvShortfall.FindControl("txtTotalGreighRequired");
            TextBox Shortfall = (TextBox)frvShortfall.FindControl("txtMtrsReProduced");
          

            sql = "SELECT CONVERT(DATETIME,'" + txtEffecFrom.Text + "',103)";
            String dt1 = obj1.FetchValue(sql).ToString();
            sql = "SELECT CONVERT(DATETIME,'" + txtEffecFrom.Text + "',103)";
            String dt2 = obj1.FetchValue(sql).ToString();
            sql = "SELECT CONVERT(DATETIME,'" + Req_Dt.Text + "',103)";
            String dt3 = obj1.FetchValue(sql).ToString();
            sql = "SELECT CONVERT(DATETIME,'" + Grey_ReqDt.Text + "',103)";
            String dt4 = obj1.FetchValue(sql).ToString();
            sql = "SELECT CONVERT(DATETIME,'" + Expected_Delivery_Dt.Text + "',103)";
            String dt5 = obj1.FetchValue(sql).ToString();

            sql = "JCT_OPS_AUTHORIZE_SHORTFALL_REQUEST";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(dt1).Date;
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(dt2).Date;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 30).Value = orderno.Text;
            cmd.Parameters.Add("@sort", SqlDbType.VarChar, 15).Value = Sort.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.Decimal).Value = WeavingSort.Text;
            cmd.Parameters.Add("@ORDER_QTY", SqlDbType.Float).Value = Req_Qty.Text;
            cmd.Parameters.Add("@ORDER_REQ_DT", SqlDbType.DateTime).Value = Convert.ToDateTime(dt3).Date;
            cmd.Parameters.Add("@lineitem", SqlDbType.Int).Value = LineItem.Text;
            cmd.Parameters.Add("@GREY_PRODUCED", SqlDbType.Float).Value = Greigh_Produced.Text;
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
            cmd.Parameters.Add("@LoomAllot", SqlDbType.Float).Value = LoomAllot.Text;
            cmd.Parameters.Add("@CompletionDays", SqlDbType.Float).Value = WvgCompletionDt.Text;
            cmd.Parameters.Add("@ShortFall_Mtrs", SqlDbType.Float).Value = Shortfall.Text;
            cmd.Parameters.Add("@Grey_ReqDt", SqlDbType.DateTime).Value = Convert.ToDateTime(dt4).Date;
            cmd.Parameters.Add("@Grey_Adjustment", SqlDbType.Float).Value = Grey_Adj.Text;
            cmd.Parameters.Add("@Grey_Remaining", SqlDbType.Float).Value = TotalGreighRequired.Text;
            cmd.Parameters.Add("@Expected_Delivery_Dt", SqlDbType.DateTime).Value = Convert.ToDateTime(dt5).Date;
            cmd.Parameters.Add("@USERCODE", SqlDbType.VarChar, 7).Value = Session["EmpCode"];//Session["EmpCode"];
            //cmd.Parameters.Add("@COMPANYCODE", SqlDbType.VarChar, 10).Value = Session["CompanyCode"];//Session["CompanyCode"];
            cmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value = yearMonth();
            cmd.Parameters.Add("@Sizing", SqlDbType.Decimal).Value = Convert.ToDecimal(Sizing.Text);
            cmd.ExecuteNonQuery();
            String Body;
            String To;
            //SendMail
            sql = "JCT_OPS_SEND_MAIL_ON_AUTHROIZATION_OF_SHORTFALL_REQUEST";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 30).Value = orderno.Text;
            cmd.Parameters.Add("@order_srl_no", SqlDbType.Int).Value = LineItem.Text;
            cmd.Parameters.Add("@item_no", SqlDbType.VarChar, 15).Value = Sort.Text;
            cmd.Parameters.Add("@ShortFall_Mtrs", SqlDbType.Float).Value = Shortfall.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 15).Value =Session["EmpCode"];
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
            cmd.Parameters.Add("@yearmonth", SqlDbType.Decimal).Value = yearMonth();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    Body = "<p>Hello ,</p> <p>Your Shortfall request has been authorized, details of which are shown below :</p> <h3>Customer Name : "+ dr[0].ToString() +"</h3> <H3>Order No. :" + orderno.Text + " </H3> </p> <p> <H3> Sort No. : " + Sort.Text + "</H3>  </p> <p><h3>Shade : " + dr[4].ToString() + " </h3></p><p><h3> Order Required Date :  " + Req_Dt.Text + "</h3></p><p><h3>Greigh Produced :  " + Greigh_Produced.Text + "</h3></p><p><h3>Greigh ShortFall Mtrs :  " + Shortfall.Text + "</h3></p><p><H3> Planned Shortfall Mtrs:  " + Shortfall.Text + "</H3> </p><p> <H3>Planned By : " + obj1.FetchValue("Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and active='Y'") + "</H3></p><p> <H3> Expected Delivery Date : " + Expected_Delivery_Dt.Text + "</H3></p><p> <H3> Expected Greigh Delivery Date : " + dr[13].ToString() + "</H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                    SendMailToPlanning(Body,orderno.Text);
                }
            }
            dr.Close();
           
            pnlShortfall.Visible = false;
        }
        catch (Exception ex)
        { 
                      script = "alert('" + ex.Message + "');";
                      ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }


    protected void SendMailToPlanning(String body, String OrderNo)
    {

        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("neeraj@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("sobti@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("karanjitsaini@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("rashpal@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("harendra@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("rbaksshi@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("ashish@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("sobti@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("kvsmurty@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("nandksharma@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("rajivmehra@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("sudhirarora@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
                Sm.SendMail("vinaypuri@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
               

            }
        }
        dr.Close();
    }
    //protected void SendMailToPlanning(String Body,String OrderNo)
    //{

    //    MailMessage mailMessage = new MailMessage();
    //    mailMessage.From = "noreply@jctltd.com";
    //    //mailMessage.To = "jatindutta@jctltd.com";
    //    mailMessage.To = "karanjitsaini@jctltd.com";
    //    mailMessage.To = "neeraj@jctltd.com";
    //    mailMessage.To = "rahuljindal@jctltd.com";
    //    mailMessage.To = "kvsmurty@jctltd.com";
    //    mailMessage.To = "nandksharma@jctltd.com";
    //    mailMessage.To = "rajivmehra@jctltd.com";
    //    mailMessage.To = "sudhirarora@jctltd.com";
    //    mailMessage.To = "vinaypuri@jctltd.com";
    //    mailMessage.Cc = "sobti@jctltd.com";
    //    mailMessage.Cc = "rashpal@jctltd.com";
    //    mailMessage.Bcc = "jatindutta@jctltd.com";
    //    mailMessage.Bcc = "harendra@jctltd.com";
    //    mailMessage.Bcc = "ashish@jctltd.com";
    //    mailMessage.Bcc = "rbaksshi@jctltd.com";
    //    mailMessage.BodyFormat = MailFormat.Html;
    //    mailMessage.Subject = "Authorized Shortfall Request - " + OrderNo;
    //    mailMessage.Body = Body;
    //    SmtpMail.SmtpServer = "exchange2007";
    //    SmtpMail.Send(mailMessage);

    //}
    
    protected void txtExpectedDelivery_TextChanged(object sender, EventArgs e)
    {
        TextBox ReqDt = sender as TextBox;
        FormViewRow FormRow = (FormViewRow)ReqDt.Parent.Parent;
        TextBox GreighReqDt = (TextBox)FormRow.FindControl("txtGreighDate");
        Label lblWvgCompletionDt = (Label)FormRow.FindControl("lblWvgCompletionDays");
        TextBox Looms = (TextBox)FormRow.FindControl("txtLooms");

        sql = "SELECT CONVERT(VARCHAR,CONVERT(DATETIME,'" + ReqDt.Text + "',101) -15,101)  ";
        GreighReqDt.Text = obj1.FetchValue(sql).ToString();
    }

    protected void txtGreighAdj_TextChanged(object sender, EventArgs e)
    {
        TextBox GreighAdj = sender as TextBox;
        FormViewRow FormRow = (FormViewRow)GreighAdj.Parent.Parent;
        TextBox GreighReqDt = (TextBox)FormRow.FindControl("txtGreighDate");
        
        TextBox Looms = (TextBox)FormRow.FindControl("txtLooms");
        DropDownList Shed = (DropDownList)FormRow.FindControl("ddlShed");
        TextBox MtrsReProduced = (TextBox)FormRow.FindControl("txtMtrsReProduced");
        TextBox Sizing =(TextBox)FormRow.FindControl("txtSizing");
        Label OrderNo = (Label)FormRow.FindControl("lblOrder");
        Label WeavingSort = (Label)FormRow.FindControl("lblWeavingSort");
        Label LineItem = (Label)FormRow.FindControl("lblLineItem");
        TextBox TotalGreighRequired = (TextBox)FormRow.FindControl("txtTotalGreighRequired");
        if (GreighAdj.Text != "")
        {
            float i = float.Parse(MtrsReProduced.Text) - float.Parse(GreighAdj.Text);
            TotalGreighRequired.Text = i.ToString();
            sql = "EXEC JCT_OPS_WEAVING_SIZING " + TotalGreighRequired.Text + ",  '" + WeavingSort.Text + "','" + OrderNo.Text + "'," + LineItem.Text + ",'N'";
            Sizing.Text = obj1.FetchValue(sql).ToString();
            if (Sizing.Text == "0")
            {
                Looms.Text = "0";
            }
            else
            {
                Looms.Text = "1";
            }
            float GreighReq = float.Parse(TotalGreighRequired.Text);
            Label lblWvgCompletionDt = (Label)FormRow.FindControl("lblWvgDays");
            sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + Looms.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + Looms.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE   sort_no = "+ WeavingSort.Text +" and loom_sec=Substring('" + Shed.SelectedItem.Text + "',1,1) and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE loom_sec=Substring('" + Shed.SelectedItem.Text + "',1,1)  and  sort_no ="+ WeavingSort.Text +" )";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                if (obj1.FetchValue(sql).ToString() != null)
                {
                  
                    lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
                }
                else
                {
                    sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + Looms.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + Looms.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE    sort_no = "+ WeavingSort.Text +"  and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE  sort_no = "+ WeavingSort.Text +")";
                    lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
                }

            }
            else
            {
                sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + Looms.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + Looms.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE    sort_no = " + WeavingSort.Text + "  and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE  sort_no = " + WeavingSort.Text + ")";
                lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
            }
        }
    }

    protected void txtLooms_TextChanged(object sender, EventArgs e)
    {
        try
        {

            TextBox txtLoomAllot = (TextBox)sender;

            FormViewRow FormRow = (FormViewRow)txtLoomAllot.Parent.Parent;
            TextBox Greigh = (TextBox)FormRow.FindControl("txtMtrsReProduced");
            TextBox GreighAjdustment = (TextBox)FormRow.FindControl("txtGreighAdj");
            Label Orderno = (Label)FormRow.FindControl("lblOrder");
            TextBox Sizing = (TextBox)FormRow.FindControl("txtSizing");
            DropDownList Shed = (DropDownList)FormRow.FindControl("ddlShed");
            Label Sort = (Label)FormRow.FindControl("lblSort");
            Label WeavingSort = (Label)FormRow.FindControl("lblWeavingSort");
            Label LineItem = (Label)FormRow.FindControl("lblLineItem");
            TextBox lblReqdt = (TextBox)FormRow.FindControl("txtExpectedDelivery");
            TextBox Grey_Remaining = (TextBox)FormRow.FindControl("txtTotalGreighRequired");
            // Label WvgCompletionDays = (Label)gridRow.FindControl("lblWvgCompletionDt");
            if (decimal.Parse(txtLoomAllot.Text) != 0)
            {

                float GreighReq = float.Parse(Greigh.Text);
                float GreighAjd = float.Parse(GreighAjdustment.Text);
                //float GreighRem = float.Parse(Sizing.Text) - GreighAjd;
                float GreighRem = float.Parse(Grey_Remaining.Text);
                // Greigh.Text = GreighRem.ToString();
                Label lblWvgCompletionDt = (Label)FormRow.FindControl("lblWvgDays");
                sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + txtLoomAllot.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + txtLoomAllot.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE   sort_no = "+ WeavingSort.Text +" and loom_sec=Substring('" + Shed.SelectedItem.Text + "',1,1) and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE loom_sec=Substring('" + Shed.SelectedItem.Text + "',1,1)  and  sort_no = "+ WeavingSort.Text +")";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    if (obj1.FetchValue(sql).ToString() != null)
                    {
                        lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
                    }
                    else
                    {
                        sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + txtLoomAllot.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + txtLoomAllot.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE     sort_no = " + WeavingSort.Text + "  and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE  sort_no = " + WeavingSort.Text + ")";
                        lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
                    }

                }
                else
                {
                    sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + txtLoomAllot.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + txtLoomAllot.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE     sort_no = " + WeavingSort.Text + "  and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE  sort_no = " + WeavingSort.Text + ")";
                    lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
                }
           
            }
        }
        catch (Exception ex)
        {

        }

    }

    protected void ddlShed_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList Shed = (DropDownList)sender;
            FormViewRow FormRow = (FormViewRow)Shed.Parent.Parent;
            TextBox Greigh = (TextBox)FormRow.FindControl("txtMtrsReProduced");
            TextBox GreighAjdustment = (TextBox)FormRow.FindControl("txtGreighAdj");
            Label Orderno = (Label)FormRow.FindControl("lblOrder");
            TextBox Sizing = (TextBox)FormRow.FindControl("txtSizing");
            TextBox txtLoomAllot = (TextBox)FormRow.FindControl("txtLooms");
            Label Sort = (Label)FormRow.FindControl("lblSort");
            Label WeavingSort = (Label)FormRow.FindControl("lblWeavingSort");
            Label LineItem = (Label)FormRow.FindControl("lblLineItem");
            TextBox lblReqdt = (TextBox)FormRow.FindControl("txtExpectedDelivery");
            TextBox Grey_Remaining = (TextBox)FormRow.FindControl("txtTotalGreighRequired");
            Label WvgCompletionDays = (Label)FormRow.FindControl("lblWvgDays");
            sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + Greigh.Text + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + txtLoomAllot.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + txtLoomAllot.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE   sort_no = '" + WeavingSort.Text + "' and loom_sec=Substring('" + Shed.SelectedItem.Text + "',1,1) and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE loom_sec=Substring('" + Shed.SelectedItem.Text + "',1,1)  and  sort_no = '" + WeavingSort.Text + "')";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                if (obj1.FetchValue(sql).ToString() != null)
                {
                    WvgCompletionDays.Text = obj1.FetchValue(sql).ToString();
                }
                else
                {
                    sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + Greigh.Text + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + txtLoomAllot.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + txtLoomAllot.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE    sort_no = '" + WeavingSort.Text + "' and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE  sort_no = '" + WeavingSort.Text + "'";
                    WvgCompletionDays.Text = obj1.FetchValue(sql).ToString();
                }

            }
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
       
    }

    protected void txtMtrsReProduced_TextChanged(object sender, EventArgs e)
    {
        TextBox MtrsReProduced = sender as TextBox;
        FormViewRow FormRow = (FormViewRow)MtrsReProduced.Parent.Parent;
        TextBox GreighReqDt = (TextBox)FormRow.FindControl("txtGreighDate");
        TextBox Looms = (TextBox)FormRow.FindControl("txtLooms");
        DropDownList Shed = (DropDownList)FormRow.FindControl("ddlShed");
        TextBox GreighAdj = (TextBox)FormRow.FindControl("txtGreighAdj");
        TextBox Sizing = (TextBox)FormRow.FindControl("txtSizing");
        Label OrderNo = (Label)FormRow.FindControl("lblOrder");
        Label WeavingSort = (Label)FormRow.FindControl("lblWeavingSort");
        Label LineItem = (Label)FormRow.FindControl("lblLineItem");
        TextBox TotalGreighRequired = (TextBox)FormRow.FindControl("txtTotalGreighRequired");


        if (GreighAdj.Text != "")
        {
            float i = float.Parse(MtrsReProduced.Text) - float.Parse(GreighAdj.Text);
            TotalGreighRequired.Text = i.ToString();
            sql = "EXEC JCT_OPS_WEAVING_SIZING " + TotalGreighRequired.Text + ",  '" + WeavingSort.Text + "','" + OrderNo.Text + "'," + LineItem.Text + ",'N'";
            Sizing.Text = obj1.FetchValue(sql).ToString();
            if (Sizing.Text == "0")
            {
                Looms.Text = "0";
            }
            else
            {
                Looms.Text = "1";
            }
            float GreighReq = float.Parse(TotalGreighRequired.Text);
            Label lblWvgCompletionDt = (Label)FormRow.FindControl("lblWvgDays");
            sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + Looms.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + Looms.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE   sort_no = " + WeavingSort.Text + " and loom_sec=Substring('" + Shed.SelectedItem.Text + "',1,1) and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE loom_sec=Substring('" + Shed.SelectedItem.Text + "',1,1)  and  sort_no =" + WeavingSort.Text + " )";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                if (obj1.FetchValue(sql).ToString() != null)
                {

                    lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
                }
                else
                {
                    sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + Looms.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + Looms.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE    sort_no = " + WeavingSort.Text + "  and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE  sort_no = " + WeavingSort.Text + ")";
                    lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
                }

            }
            else
            {
                sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + GreighReq + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + Looms.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + Looms.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE    sort_no = " + WeavingSort.Text + "  and rev_no = (Select Max(rev_no) from  production..jct_fab_results WHERE  sort_no = " + WeavingSort.Text + ")";
                lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
            }
        }

    }

    protected void lnkSelect_Click(object sender, EventArgs e)
    {
        LinkButton LnkSeletedRow = sender as LinkButton;
        pnlShortfall.Visible = true;
        GridViewRow grv = LnkSeletedRow.NamingContainer as GridViewRow;
        Label Customer = (Label)grv.FindControl("lblCustomer");
        Label OrderNo = (Label)grv.FindControl("lblOrderno");
        Label LineItem = (Label)grv.FindControl("lblLineItem");
        Label WeavingSort = (Label)grv.FindControl("lblWeavingSort");
        Label Sort = (Label)grv.FindControl("lblSort");
        Label OrderQty = (Label)grv.FindControl("lblOrderQty");
        Label Shortfall = (Label)grv.FindControl("txtShortfall");
        Image img = (Image)grv.FindControl("img");

        sql = "JCT_OPS_FETCH_SHORTFALL_PLANNING_ORDERS_DETAIL";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Shortfall", SqlDbType.Decimal).Value = Convert.ToDecimal(Shortfall.Text);
        cmd.Parameters.Add("@ITEM_NO", SqlDbType.VarChar, 20).Value = WeavingSort.Text;
        cmd.Parameters.Add("@Order_no", SqlDbType.VarChar, 20).Value = OrderNo.Text;
        cmd.Parameters.Add("@LINEITEM", SqlDbType.Int).Value = Convert.ToInt32(LineItem.Text);
        cmd.Parameters.Add("@RePlan", SqlDbType.Char).Value = 'Y';
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        frvShortfall.DataSource = ds;
        frvShortfall.DataBind();
        img.ImageUrl = "~/Image/AvailabilityTrue.png";
    }
}