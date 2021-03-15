using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
//using System.Web.Mail;
using System.Net.Mail;
using System.Text;

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
        //sql = "JCT_OPS_FETCH_SHORTFALL_MTRS_FOR_PLANNING";
        sql = "JCT_OPS_FETCH_SHORTFALL_MTRS_FOR_PLANNING_NEWPLAN";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar,20).Value = ddlPlant.SelectedItem.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value =txtOrderNo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value =txtSortNo.Text;
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
            TextBox WeavingSort = (TextBox)frvShortfall.FindControl("txtWeavingSort");
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
            TextBox GreighReq = (TextBox)frvShortfall.FindControl("txtMtrsReProduced");
            Label Shortfall = (Label)frvShortfall.FindControl("lblShortfall");
            DropDownList CaseType = (DropDownList)frvShortfall.FindControl("ddlGreigh");


            sql = "JCT_OPS_AUTHORIZE_SHORTFALL_REQUEST";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar,20).Value = txtEffecFrom.Text;
            //cmd.Parameters.Add("@DateTo", SqlDbType.VarChar,20).Value = txtEffecTo.Text;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 30).Value = orderno.Text;
            cmd.Parameters.Add("@sort", SqlDbType.VarChar, 15).Value = Sort.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.Decimal).Value = WeavingSort.Text == "" ? 0 : Convert.ToDecimal(WeavingSort.Text);
            cmd.Parameters.Add("@ORDER_QTY", SqlDbType.Decimal).Value = Req_Qty.Text == "" ? 0 : Convert.ToDecimal(Req_Qty.Text);
            cmd.Parameters.Add("@ORDER_REQ_DT", SqlDbType.VarChar, 22).Value = Req_Dt.Text;
            cmd.Parameters.Add("@lineitem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
            //cmd.Parameters.Add("@GREY_PRODUCED", SqlDbType.Decimal).Value =Greigh_Produced.Text==""?0: Convert.ToDecimal(Greigh_Produced.Text);
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
            cmd.Parameters.Add("@LoomAllot", SqlDbType.Decimal).Value = Convert.ToDecimal(LoomAllot.Text);
            cmd.Parameters.Add("@CompletionDays", SqlDbType.Decimal).Value = Convert.ToDecimal(WvgCompletionDt.Text);
            cmd.Parameters.Add("@ShortFall_Mtrs", SqlDbType.Decimal).Value = Shortfall.Text == "" ? 0 : Convert.ToDecimal(Shortfall.Text);
            cmd.Parameters.Add("@Grey_ReqDt", SqlDbType.VarChar, 22).Value = Grey_ReqDt.Text;
            cmd.Parameters.Add("@Grey_Adjustment", SqlDbType.Decimal).Value = Grey_Adj.Text == "" ? 0 : Convert.ToDecimal(Grey_Adj.Text);
            cmd.Parameters.Add("@Grey_Remaining", SqlDbType.Decimal).Value = TotalGreighRequired.Text == "" ? 0 : Convert.ToDecimal(TotalGreighRequired.Text);
            cmd.Parameters.Add("@Expected_Delivery_Dt", SqlDbType.VarChar, 22).Value = Expected_Delivery_Dt.Text;
            cmd.Parameters.Add("@USERCODE", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            //cmd.Parameters.Add("@COMPANYCODE", SqlDbType.VarChar, 10).Value = Session["CompanyCode"];//Session["CompanyCode"];
            //cmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value = yearMonth();
            cmd.Parameters.Add("@Sizing", SqlDbType.Decimal).Value = Sizing.Text == "" ? 0 : Convert.ToDecimal(Sizing.Text);
            cmd.Parameters.Add("@TransID", SqlDbType.Int).Value = ViewState["TransID"];
            cmd.Parameters.Add("@GreighReq", SqlDbType.Decimal).Value = GreighReq.Text == "" ? 0 : Convert.ToDecimal(GreighReq.Text);
            //cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 50).Value = CaseType.SelectedItem.Text;
            cmd.ExecuteNonQuery();
            String Body;
            String To;
            //SendMail

            //sql = "JCT_OPS_SEND_MAIL_ON_AUTHROIZATION_OF_SHORTFALL_REQUEST";
            sql = "JCT_OPS_SEND_MAIL_ON_AUTHROIZATION_OF_SHORTFALL_REQUEST_NEWPLAN";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 30).Value = orderno.Text;
            cmd.Parameters.Add("@order_srl_no", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
            cmd.Parameters.Add("@item_no", SqlDbType.VarChar, 15).Value = Sort.Text;
            cmd.Parameters.Add("@ShortFall_Mtrs", SqlDbType.Decimal).Value = Convert.ToDecimal(Shortfall.Text);
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 15).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
            //cmd.Parameters.Add("@yearmonth", SqlDbType.Decimal).Value = yearMonth();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    //Body = "<p>Hello ,</p> <p>Shortfall request has been authorized, details of which are shown below :</p> <h3>Customer Name : " + dr[0].ToString() + "</h3> <H3>Order No. :" + orderno.Text + " </H3> </p> <p> <H3> Sort No. : " + Sort.Text + "</H3>  </p> <p><h3>Shade : " + dr[4].ToString() + " </h3></p><p><h3> Order Required Date :  " + Req_Dt.Text + "</h3></p><p><h3>Greigh Produced :  " + Greigh_Produced.Text + "</h3></p><p><h3>Greigh ShortFall Mtrs :  " + Shortfall.Text + "</h3></p><p><H3> Planned Shortfall Mtrs:  " + Shortfall.Text + "</H3> </p><p><H3>Sizing Required:  " + dr[14].ToString() + "</H3> </p><p><H3>Reason for Shortfall :  " + dr[18].ToString() + "</H3> </p><p><H3>Remarks :  " + dr[17].ToString() + "</H3> </p><p> <H3>Planned By : " + obj1.FetchValue("Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and active='Y'") + "</H3></p><p> <H3> Expected Delivery Date : " + Expected_Delivery_Dt.Text + "</H3></p><p> <H3> Expected Greigh Delivery Date : " + dr[13].ToString() + "</H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                    Body = "<p>Hello ,</p> <p>Shortfall request has been authorized, details of which are shown below :</p><h3> Request ID : " + ViewState["TransID"] +"</h3> <h3>Customer Name : " + dr[0].ToString() + "</h3> <H3>Order No. :" + orderno.Text + " </H3> </p> <p> <H3> Sort No. : " + Sort.Text + "</H3>  </p><p> <H3> Weaving Sort : " + dr["WeavingSort"].ToString() + "</H3>  </p> <p><h3>Shade : " + dr[4].ToString() + " </h3></p><p><h3> Order Required Date :  " + Req_Dt.Text + "</h3></p><p><h3>Greigh Produced :  " + Greigh_Produced.Text + "</h3></p><p><h3>Greigh ShortFall Mtrs :  " + Shortfall.Text + "</h3></p><p><H3> Planned Shortfall Mtrs:  " + Shortfall.Text + "</H3> </p><p><H3>Sizing Required:  " + dr[14].ToString() + "</H3> </p><p><H3>Reason for Shortfall :  " + dr[18].ToString() + "</H3> </p><p><H3>Remarks :  " + dr[17].ToString() + "</H3> </p><p> <H3> Expected Delivery Date : " + Expected_Delivery_Dt.Text + "</H3></p><p> <H3> Expected Greigh Delivery Date : " + dr[13].ToString() + "</H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                    SendMailToPlanning(Body, orderno.Text, dr[16].ToString());
                    //BuildMail();
                    goto Request;
                }
            }
            dr.Close();

        Request: pnlShortfall.Visible = false;
            script = "alert('Shortfall Authorized..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        { 
                      script = "alert('" + ex.Message + "');";
                      ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }


    //protected void SendMailToPlanning(String body, String OrderNo)
    //{

    //    SqlDataReader dr = obj1.FetchReader(sql);
    //    if (dr.HasRows)
    //    {
    //        while (dr.Read())
    //        {
    //            Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("neeraj@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("sobti@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("karanjitsaini@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("rashpal@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("harendra@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("rbaksshi@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("ashish@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("sobti@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("kvsmurty@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("nandksharma@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("rajivmehra@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("sudhirarora@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
    //            Sm.SendMail("vinaypuri@jctltd.com", "noreply@jctltd.com", "Authorized Shortfall Request - " + OrderNo, body);
               

    //        }
    //    }
    //    dr.Close();
    //}


    private void SendMailToPlanning(String Body, String OrderNo, String SalesPerson_Email)
    {
        string from, to, bcc, cc, subject, body;

        from = "noreply@jctltd.com";   //Email Address of Sender
        //sql = " SELECT DISTINCT LOCATION FROM dbo.jct_ops_planning_order WHERE order_no='" + OrderNo + "' AND status ='A'";
        //sql = " SELECT DISTINCT Upper(LOCATION) as Location FROM dbo.jct_ops_planning_order WHERE order_no='" + OrderNo + "' AND status ='A' Union SELECT Upper(Plant) as Location FROM production..jct_process_issue_finish_folding WHERE po_number='" + OrderNo + "'";
        sql = "SELECT DISTINCT Upper(LOCATION) as Location FROM dbo.jct_ops_planning_order WHERE order_no='" + OrderNo + "' AND status ='A' and location is not null Union SELECT Upper(Plant) as Location FROM production..jct_process_issue_finish_folding WHERE plant is not null and po_number='" + OrderNo + "'";
            String Plant = obj1.FetchValue(sql).ToString();
            if (Plant == "COTTON")
            {
                //to = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,WeavingGroup@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
                //bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com";
                //cc = "sobti@jctltd.com,rkkapoor@jctltd.com,mikeops@jctltd.com,graeme@jctltd.com";
                if (SalesPerson_Email == "")
                {
                    to = "neeraj@jctltd.com,chandermohan@jctltd.com,santoshkumar@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,sukhvendersingh@jctltd.com,bipansharma@jctltd.com,nandksharma@jctltd.com";   //Email Address of Receiver
                }
                else
                {
                    to = "neeraj@jctltd.com,chandermohan@jctltd.com,santoshkumar@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,sukhvendersingh@jctltd.com,bipansharma@jctltd.com,nandksharma@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
                }
                
                bcc = "ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com";
                cc = "rlsharma@jctltd.com,ashokkumar2@jctltd.com,sobti@jctltd.com,rkkapoor@jctltd.com,rajivmehra@jctltd.com,arvindsharma@jctltd.com";
                subject = "Authorized Shortfall Request - " + OrderNo;

                body = Body;

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
                SmtpClient SmtpMail = new SmtpClient("exchange2k7");

                //SmtpMail.SmtpServer = "exchange2007";
                SmtpMail.Send(mail);
                //return mail;
            }
            else if (Plant == "TAFFETA")
            {

                to = "trivendermehta@jctltd.com,umeshrana@jctltd.com,ramanbehal@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
                //to = "harendra@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
                bcc = "ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com";
                cc = "harendra@jctltd.com";

                subject = "Authorized Shortfall Request - " + OrderNo;

                //StringBuilder sb = new StringBuilder();
                //sb.Append("Hi,<br/>");
                //sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
                //sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
                //sb.Append("<br/>");
                //sb.Append("Thanking you<br/>");
                //sb.Append("IT");

                body = Body;

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
                SmtpClient SmtpMail = new SmtpClient("exchange2k7");

                //SmtpMail.SmtpServer = "exchange2007";
                SmtpMail.Send(mail);
                //return mail;
            }

      
        
      
    
    }


    //private void BuildMail()
    //{
    //    string from, to, bcc, cc, subject, body;
    //    from = "noreply@jctltd.com";   //Email Address of Sender
    //    to = "harendra@jctltd.com,jatindutta@jctltd.com,harshsoni@jctltd.com,jaswal@jctltd.com";   //Email Address of Receiver
    //    bcc = "harendra@jctltd.com,rbaksshi@jctltd.com,hitesh@jctltd.com,jatindutta@jctltd.com";
    //    cc = "ashish@jctltd.com,hitesh@jctltd.com,rajan@jctltd.com,harshsoni@jctltd.com,jatindutta@jctltd.com";
    //    subject = "This is a test email. I am just checking whether email client is working properly.";

    //    StringBuilder sb = new StringBuilder();
    //    sb.Append("Hi,<br/>");
    //    sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
    //    sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
    //    sb.Append("<br/>");
    //    sb.Append("Thanking you<br/>");
    //    sb.Append("OPS");

    //    body = sb.ToString();

    //    MailMessage mail = new MailMessage();
    //    mail.From = new MailAddress(from);
    //    if (to.Contains(","))
    //    {
    //        string[] tos = to.Split(',');
    //        for (int i = 0; i < tos.Length; i++)
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
    //            for (int i = 0; i < bccs.Length; i++)
    //            {
    //                mail.Bcc.Add(new MailAddress(bccs[i]));
    //            }
    //        }
    //        else
    //        {
    //            mail.Bcc.Add(new MailAddress(bcc));
    //        }
    //    }
    //    if (!string.IsNullOrEmpty(cc))
    //    {
    //        if (cc.Contains(","))
    //        {
    //            string[] ccs = cc.Split(',');
    //            for (int i = 0; i < ccs.Length; i++)
    //            {
    //                mail.CC.Add(new MailAddress(ccs[i]));
    //            }
    //        }
    //        else
    //        {
    //            mail.CC.Add(new MailAddress(bcc));
    //        }
    //        mail.CC.Add(new MailAddress(cc));
    //    }

    //    mail.Subject = subject;
    //    mail.Body = body;
    //    mail.IsBodyHtml = true;
    //    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //    SmtpClient SmtpMail = new SmtpClient("exchange2007");

    //    //SmtpMail.SmtpServer = "exchange2007";
    //    SmtpMail.Send(mail);
    //    //return mail;
    //}
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
        TextBox WeavingSort = (TextBox)FormRow.FindControl("txtWeavingSort");
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
            TextBox WeavingSort = (TextBox)FormRow.FindControl("txtWeavingSort");
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
            TextBox WeavingSort = (TextBox)FormRow.FindControl("txtWeavingSort");
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
        TextBox WeavingSort = (TextBox)FormRow.FindControl("txtWeavingSort");
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
        Label TransID = (Label)grv.FindControl("lblTransID");
        ViewState["TransID"] = TransID.Text;
        Image img = (Image)grv.FindControl("img");

        //sql = "JCT_OPS_FETCH_SHORTFALL_PLANNING_ORDERS_DETAIL";
        sql = "JCT_OPS_FETCH_SHORTFALL_PLANNING_ORDERS_DETAIL_NewPlan";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@Shortfall", SqlDbType.Decimal).Value = Convert.ToDecimal(Shortfall.Text);
        //cmd.Parameters.Add("@ITEM_NO", SqlDbType.VarChar, 20).Value = WeavingSort.Text;
        //cmd.Parameters.Add("@Order_no", SqlDbType.VarChar, 20).Value = OrderNo.Text;
        //cmd.Parameters.Add("@LINEITEM", SqlDbType.Int).Value = LineItem.Text=="" ? 0: Convert.ToInt32(LineItem.Text);
        //cmd.Parameters.Add("@RePlan", SqlDbType.Char).Value = 'Y';
        cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = TransID.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        frvShortfall.DataSource = ds;
        frvShortfall.DataBind();
        img.ImageUrl = "~/Image/AvailabilityTrue.png";
    }

    protected void frvShortfall_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {
            pnlShortfall.Visible = false;
        }   
    }

    protected void ddlGreigh_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList GreighReq = (DropDownList)sender;

        FormViewRow FormRow = (FormViewRow)GreighReq.Parent.Parent;
        Label Shortfall = (Label)FormRow.FindControl("lblShortfall");
        Label Orderno = (Label)FormRow.FindControl("lblOrder");
        Label Sort = (Label)FormRow.FindControl("lblSort");
        TextBox WeavingSort = (TextBox)FormRow.FindControl("txtWeavingSort");
        Label LineItem = (Label)FormRow.FindControl("lblLineItem");
        TextBox GreighAdj = (TextBox)FormRow.FindControl("txtGreighAdj");
        TextBox Greigh = (TextBox)FormRow.FindControl("txtMtrsReProduced");
        TextBox GreighRem = (TextBox)FormRow.FindControl("txtTotalGreighRequired");
        TextBox Sizing = (TextBox)FormRow.FindControl("txtSizing");
        Label WvgCompletionDays = (Label)FormRow.FindControl("lblWvgDays");
        TextBox txtLoomAllot = (TextBox)FormRow.FindControl("txtLooms");

        if (GreighReq.SelectedIndex == 1)
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Shortfall.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = GreighReq.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Shortfall.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Greigh.Text = dr[0].ToString();
                    double greighRem = double.Parse(Greigh.Text);
                    greighRem = Math.Round(greighRem, 2);

                    GreighRem.Text = greighRem.ToString();
                    Decimal g = Convert.ToDecimal(GreighRem.Text) - Convert.ToDecimal(GreighAdj.Text);
                    GreighRem.Text = g.ToString();
                    Greigh.Text = greighRem.ToString();
                }
            }
            dr.Close();

            sql = "EXEC JCT_OPS_WEAVING_SIZING " + GreighRem.Text + ",  '" + WeavingSort.Text + "','" + Orderno.Text + "'," + LineItem.Text + ",'N'";
            Sizing.Text = obj1.FetchValue(sql).ToString();
            GreighRem.Text = Sizing.Text;    
            txtLoomAllot.Text = "0";

        }
        else
        {

            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Shortfall.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = GreighReq.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Shortfall.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Greigh.Text = dr[0].ToString();
                    double greighRem = double.Parse(Greigh.Text);
                    greighRem = Math.Round(greighRem, 2);
                    GreighRem.Text = greighRem.ToString();
                    Decimal g = (GreighRem.Text=="" ? 0 : Convert.ToDecimal(GreighRem.Text)) - (GreighAdj.Text==""?0: Convert.ToDecimal(GreighAdj.Text));
                    GreighRem.Text = g.ToString();
                    Greigh.Text = greighRem.ToString();
                }
            }
            dr.Close();

  
            sql = "EXEC JCT_OPS_WEAVING_SIZING " + GreighRem.Text + ", '" + WeavingSort.Text + "','" + Orderno.Text + "'," + LineItem.Text + ",'N'";
            Sizing.Text = obj1.FetchValue(sql).ToString();
            GreighRem.Text = Sizing.Text;
            txtLoomAllot.Text = "0";
     
        }
    }

    protected void img_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        
        ImageButton img = sender as ImageButton;
        GridViewRow gridRow = (GridViewRow)img.Parent.Parent;
        Label Customer = (Label)gridRow.FindControl("lblCustomer");
        Label orderNo = (Label)gridRow.FindControl("lblOrderno");
        Label Shade = (Label)gridRow.FindControl("lblShade");
        Label Sort = (Label)gridRow.FindControl("lblSort");
        Label Shortfall = (Label)gridRow.FindControl("txtShortfall");
        Label TransNo = (Label)gridRow.FindControl("lblTransID");

        if (img.ImageUrl == "~/Image/AvailabilityFalse.png")
        {
            sql = "JCT_OPS_SHORTFALL_CANCEL";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = TransNo.Text;
            cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.ExecuteNonQuery();
            string Body = Body = "<p>Hello ,</p> <p>Shortfall request has been Cancelled, details of which are shown below :</p> <h3>Customer Name : " + Customer.Text + "</h3> <H3>Order No. :" + orderNo.Text + " </H3> </p> <p> <H3> Sort No. : " + Sort.Text + "</H3>  </p> <p><h3>Shade : " + Shade.Text + " </h3></p><p><h3>ShortFall Mtrs :  " + Shortfall.Text + "</h3></p><p><h3>Request Made By :  " + obj1.FetchValue("SELECT DISTINCT b.empname FROM dbo.JCT_OPS_SHORTFALL_ORDER_REQUEST a INNER JOIN dbo.JCT_EmpMast_Base b ON a.UserCode=b.empcode  WHERE TransNo="+ TransNo.Text +"") + "</h3></p><br/><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
            SendMailToPlanning(Body, orderNo.Text, "");
            FillGrid();
            script = "alert('Shortfall Cancelled Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        else if (img.ImageUrl == "~/Image/AvailabilityTrue.png")
        {
            script = "alert('Please plan shortfall with details..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

          }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdShortfall_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdShortfall.PageIndex = e.NewPageIndex;
        FillGrid();
    }
}