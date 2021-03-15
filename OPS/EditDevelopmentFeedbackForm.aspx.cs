using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

public partial class OPS_EditDevelopmentFeedbackForm : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sqlStr= string.Empty;
    string requestID = string.Empty;
    string label = string.Empty;
 
    protected RequiredFieldValidator rfvQCRemarks = new RequiredFieldValidator();
    protected RequiredFieldValidator rfvRemarks = new RequiredFieldValidator();

    protected void Page_Load(object sender, EventArgs e)
    {
        string RequestID = string.Empty;
        RequestID = Request.QueryString["RequestID"].ToString();
        label = Request.QueryString["link"].ToString();

        if (!this.IsPostBack)
        {
            if (label == "link")
            {
                pnllabel.Visible = true;
                pnlTaskStatus.Visible = false;

                sqlStr = "SELECT RequestID , YarnAvailability , LoomAllocation , Greige , SPL , Dyed , ProdCycle ,QCReference , ExpectedDate , QCRemarks , Remarks  FROM jct_ops_development_request_feedback WHERE RequestID = " + RequestID;
                SqlCommand sqlCommand = new SqlCommand(sqlStr, obj.Connection());
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        YarnAvailablityDD.SelectedIndex = YarnAvailablityDD.Items.IndexOf(YarnAvailablityDD.Items.FindByValue(sqlDataReader["YarnAvailability"].ToString()));
                        LoomAllocationDD.SelectedIndex = LoomAllocationDD.Items.IndexOf(LoomAllocationDD.Items.FindByValue(sqlDataReader["LoomAllocation"].ToString()));
                        GreigeDD.SelectedIndex = GreigeDD.Items.IndexOf(GreigeDD.Items.FindByValue(sqlDataReader["Greige"].ToString()));
                        SPLDD.SelectedIndex = SPLDD.Items.IndexOf(SPLDD.Items.FindByValue(sqlDataReader["SPL"].ToString()));
                        DyedDD.SelectedIndex = DyedDD.Items.IndexOf(DyedDD.Items.FindByValue(sqlDataReader["Dyed"].ToString()));
                        ProdCycleDD.SelectedIndex = ProdCycleDD.Items.IndexOf(ProdCycleDD.Items.FindByValue(sqlDataReader["ProdCycle"].ToString()));
                        QCReferenceDD.SelectedIndex = QCReferenceDD.Items.IndexOf(QCReferenceDD.Items.FindByValue(sqlDataReader["QCReference"].ToString()));
                        txt_ExpectedDate.SelectedDate = Convert.ToDateTime(sqlDataReader["ExpectedDate"].ToString());
                        txt_QCRemarks.Text = sqlDataReader["QCRemarks"].ToString();
                        txt_Remarks.Text = sqlDataReader["Remarks"].ToString();

                        if (QCReferenceDD.SelectedValue == "Y")
                        {
                            tr_QCRemarks.Visible = true;
                        }
                        else if (QCReferenceDD.SelectedValue == "N")
                        {
                            tr_QCRemarks.Visible = false;
                        }

                    }
                }
                sqlDataReader.Close();
                obj.ConClose();
            }
            else if (label == "taskstatus")
            {
                pnllabel.Visible = false;
                pnlTaskStatus.Visible = true;

                sqlStr = "SELECT Remarks FROM Jct_Ops_Devlopment_Request WHERE RequestID = " + RequestID;
                SqlCommand sqlCommand = new SqlCommand(sqlStr, obj.Connection());
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    { 
                        radTextboxRemarks.Text = sqlDataReader["Remarks"].ToString();
                    }
                }
                sqlDataReader.Close();
                obj.ConClose();
            }
         
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Request.QueryString["RequestID"] == null)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "closeScript", "CloseWindow('');", true);
        }
        else
        {
            //DetailsView1.DefaultMode = DetailsViewMode.Edit;
        }

        this.Page.Title = "Development Request Feedback";
    }

  
    protected void QCReferenceDD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (QCReferenceDD.SelectedIndex == 0)
        {
            tr_QCRemarks.Visible = true;
            rfvQCRemarks.ControlToValidate = txt_QCRemarks.ID;
            rfvQCRemarks.ValidationGroup = "Group1";
            rfvQCRemarks.Display = ValidatorDisplay.Dynamic;
            rfvQCRemarks.ErrorMessage = "Please Enter QC Remarks !";
            rfvQCRemarks.ForeColor = System.Drawing.Color.Red;
            txt_QCRemarks.CausesValidation = true;
            this.Page.Controls.Add(rfvQCRemarks);

            rfvRemarks.ControlToValidate = txt_Remarks.ID;
            rfvRemarks.ValidationGroup = "Group1";
            rfvRemarks.Display = ValidatorDisplay.Dynamic;
            rfvRemarks.ErrorMessage = "Please Enter Remarks !";
            rfvRemarks.ForeColor = System.Drawing.Color.Red;
            txt_Remarks.CausesValidation = true;
            this.Page.Controls.Add(rfvRemarks);
        }
        else 
        {
            tr_QCRemarks.Visible = false;
        }
    }

    protected void btn_Close_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "closeScript", "CloseWindow('');", true);
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            sqlStr = "jct_ops_development_request_feedback_insert";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, obj.Connection());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@requestid", SqlDbType.Int).Value = Request.QueryString["RequestID"];
            sqlCommand.Parameters.Add("@yarnavailability", SqlDbType.Char, 1).Value = YarnAvailablityDD.SelectedValue;
            sqlCommand.Parameters.Add("@loomallocation", SqlDbType.Char, 1).Value = LoomAllocationDD.SelectedValue;
            sqlCommand.Parameters.Add("@greige", SqlDbType.Char, 1).Value = GreigeDD.SelectedValue;
            sqlCommand.Parameters.Add("@spl", SqlDbType.Char, 1).Value = SPLDD.SelectedValue;
            sqlCommand.Parameters.Add("@dyed", SqlDbType.Char, 1).Value = DyedDD.SelectedValue;
            sqlCommand.Parameters.Add("@prodcycle", SqlDbType.Char, 1).Value = ProdCycleDD.SelectedValue;
            sqlCommand.Parameters.Add("@qcreference", SqlDbType.Char, 1).Value = QCReferenceDD.SelectedValue;
            //sqlCommand.Parameters.Add("@expecteddate", SqlDbType.DateTime).Value = Convert.ToDateTime(txt_ExpectedDate.SelectedDate);
            sqlCommand.Parameters.Add("@expecteddate", SqlDbType.DateTime).Value = txtExpectedDt.Text == "" ? null : txtExpectedDt.Text;
            sqlCommand.Parameters.Add("@qcremarks", SqlDbType.VarChar, 255).Value = txt_QCRemarks.Text;
            sqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar, 255).Value = txt_Remarks.Text;
            sqlCommand.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            sqlCommand.ExecuteNonQuery();

            sendmail();
            this.lbl_Message.Visible = true;
            this.lbl_Message.Text = "Record inserted !";
        }
        catch(Exception ex)
        {
            this.lbl_Message.Visible = true;
            this.lbl_Message.Text = "No Record Inserted : " + ex.Message;
        }
    }
    protected void btnTaskStatusSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            sqlStr = "jct_ops_development_request_completion_remarks";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, obj.Connection());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@request_id", SqlDbType.Int).Value = Request.QueryString["RequestID"];
            sqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar, 1000).Value = radTextboxRemarks.Text;
            sqlCommand.Parameters.Add("@completed_by", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            sqlCommand.ExecuteNonQuery();
            sendmail_authorize();
            this.lbl_StatusMessage.Visible = true;
            this.lbl_StatusMessage.Text = "Task Completed !";
        }
        catch (Exception ex)
        {
            this.lbl_StatusMessage.Visible = true;
            this.lbl_StatusMessage.Text = "Task not completed : " + ex.Message;
        }
        
    }
    protected void btnTaskStatusCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "closeScript", "CloseWindow('');", true);
    }

    private void sendmail()
    {
        string @from = string.Empty;
        string to = string.Empty;
        string bcc = string.Empty;
        string cc = string.Empty;
        string subject = string.Empty;
        string body = string.Empty;
        string requestByEmail = string.Empty;
        string feedbackByEmail = string.Empty;
     

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
     
        sb.AppendLine("RequestID : " + Request.QueryString["RequestID"] + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");

        sqlStr = "SELECT b.empname,Plant,DESCRIPTION,CustomerName,ProspectCust,ProspectCustName,Req_Mtrs,no_of_shades,EndUse,Segment,Devlopment, Finish,SortNo,EnquiryNo,DevlopmentNo,RequiredOn FROM dbo.Jct_Ops_Devlopment_Request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.RequestedBy=b.empcode WHERE RequestID = @RequestID";
        
        SqlCommand cmd = new SqlCommand(sqlStr, obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = Request.QueryString["RequestID"];
        SqlDataReader Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while (Dr.Read())
            { 
               
                sb.AppendLine("<tr><td colspan='4'>SUBJECT - DEVELOPMENT REQUEST </td></tr>");
                sb.AppendLine("<tr><td> Request Made By</td> <td>" + Dr["empname"].ToString() + "</td><td></td><td></td></tr>");
                sb.AppendLine("<tr><td> Plant</td> <td>" + Dr["Plant"].ToString() + "</td><td> Sort No</td><td>" + Dr["SortNo"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> DESCRIPTION</td> <td>" + Dr["DESCRIPTION"].ToString() + "</td><td> Customer Name </td><td>" + Dr["CustomerName"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> Prospect Customer</td> <td>" + Dr["ProspectCust"].ToString() + "</td> <td> ProspectCustomer Name</td><td>" + Dr["ProspectCustName"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> REQUIRED Mtrs</td> <td>" + Dr["Req_Mtrs"].ToString() + "</td><td>Shades</td><td>" + Dr["no_of_shades"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> EndUse</td> <td>" + Dr["EndUse"].ToString() + "</td><td>Segment</td><td>" + Dr["Segment"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> Development</td> <td>" + Dr["Devlopment"].ToString() + "</td><td>Finish</td><td>" + Dr["Finish"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> Enquiry No </td> <td>" + Dr["EnquiryNo"].ToString() + "</td><td>DevlopmentNo</td><td>" + Dr["DevlopmentNo"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> RequiredOn</td><td>" + Dr["RequiredOn"].ToString() + "</td><td></td><td></td></tr>");
                
            }
        }
        Dr.Close();
        
        sb.AppendLine("</table>");

        sb.AppendLine("<br />");

        sb.AppendLine("FeedBack Details : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");

        sqlStr = "SELECT b.empname,YarnAvailability,LoomAllocation,Greige,SPL,Dyed,ProdCycle,QCReference,QCReference,Remarks FROM dbo.jct_ops_development_request_feedback a INNER JOIN dbo.JCT_EmpMast_Base b ON a.EntryBy=b.empcode  WHERE STATUS='A' AND RequestID = " + Request.QueryString["RequestID"];

        cmd = new SqlCommand(sqlStr, obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = Request.QueryString["RequestID"];
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while (Dr.Read())
            {
                sb.AppendLine("<tr><td colspan='4'>SUBJECT - DEVELOPMENT REQUEST FEEDBACK </td> </tr>");
                sb.AppendLine("<tr><td> FeedBack Given By</td> <td>" + Dr["empname"].ToString() + "</td><td> Yarn Availability</td><td>" + Dr["YarnAvailability"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> Loom Allocation</td> <td>" + Dr["LoomAllocation"].ToString() + "</td><td> Greige </td><td>" + Dr["Greige"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> SPL</td> <td>" + Dr["SPL"].ToString() + "</td> <td> Dyed </td><td>" + Dr["Dyed"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> ProdCycle</td> <td>" + Dr["ProdCycle"].ToString() + "</td><td></td><td></td></tr>");
                sb.AppendLine("<tr><td> QC Remarks</td> <td>" + Dr["QCReference"].ToString() + "</td><td> </td><td> </td></tr>");
                sb.AppendLine("<tr><td> Remarks</td> <td>" + Dr["Remarks"].ToString() + "</td><td> </td><td> </td></tr>");
            }
        }
        Dr.Close();

        sb.AppendLine("</table>");
        sb.AppendLine("</br>");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");

        sqlStr="  SELECT b.E_MailID AS EmailID FROM Jct_Ops_Devlopment_Request a INNER JOIN dbo.MISTEL b ON a.RequestedBy=b.empcode WHERE RequestID =" + Request.QueryString["RequestID"] ;
        try
        {
             requestByEmail = obj1.FetchValue(sqlStr).ToString();
        }
        catch
        {
            requestByEmail = "jatindutta@jctltd.com";
        }

        sqlStr = "SELECT b.E_MailID AS EmailID FROM dbo.jct_ops_development_request_feedback a INNER JOIN dbo.MISTEL b ON a.EntryBy=b.empcode WHERE a.STATUS='A' AND  RequestID = " + Request.QueryString["RequestID"];
        try
        {
            feedbackByEmail = obj1.FetchValue(sqlStr).ToString();
        }
        catch
        {
            feedbackByEmail = "jatindutta@jctltd.com";
        }

        body = sb.ToString();
        @from = "noreply@jctltd.com";
        to = requestByEmail +","+ feedbackByEmail;
 
        bcc ="jatindutta@jctltd.com,ashish@jctltd.com";
        subject = "Development Request - " + Request.QueryString["RequestID"];
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
 
        SmtpMail.Send(mail);
 
    }

    private void sendmail_authorize()
    {
        string @from = string.Empty;
        string to = string.Empty;
        string bcc = string.Empty;
        string cc = string.Empty;
        string subject = string.Empty;
        string body = string.Empty;
        string requestByEmail = string.Empty;
        string feedbackByEmail = string.Empty;
        string completion_rmarks = string.Empty;
        string task_completed_by = string.Empty;
        DateTime? completion_date = System.DateTime.Now;

        StringBuilder sb = new StringBuilder();

        sqlStr = "SELECT Remarks,TaskCompletion_Dt,b.empname FROM dbo.Jct_Ops_Devlopment_Request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.task_Completed_by = b.empcode WHERE   Remarks IS NOT NULL AND TaskCompletion_Dt IS NOT NULL AND task_Completed_by IS NOT NULL and RequestID =" + Request.QueryString["RequestID"];

        SqlCommand cmd = new SqlCommand(sqlStr, obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = Request.QueryString["RequestID"];
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            if (Dr.Read())
            {
                completion_rmarks = Dr["Remarks"].ToString();
                completion_date = Convert.ToDateTime(Dr["TaskCompletion_Dt"]);
                task_completed_by = Dr["empname"].ToString();
            }
        }

        Dr.Close();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");

        sb.AppendLine("Hi,<br/>");

        sb.AppendLine("RequestID : " + Request.QueryString["RequestID"] + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");

        sb.AppendLine("Task Completion Details : ");

        sb.AppendLine("<table class=gridtable>");
  
        sb.AppendLine("<tr><td colspan='4'>SUBJECT - DEVELOPMENT REQUEST COMPLETION DETAILS </td></tr>");
        sb.AppendLine("<tr><td> TASK COMPLETED BY</td> <td>" + task_completed_by + "</td> </tr>");
        sb.AppendLine("<tr><td> TASK COMPLETION REMARKS</td> <td>" + completion_rmarks + "</td> </tr>");
        sb.AppendLine("<tr><td> COMPLETED DATE</td> <td>" + completion_date + "</td> </tr>");
       
        sb.AppendLine("</table>");

        sb.AppendLine("<br />");

        sb.AppendLine("Development Request Details : <br/><br/>");

        sb.AppendLine("<table class=gridtable>");

        sqlStr = "SELECT b.empname,Plant,DESCRIPTION,CustomerName,ProspectCust,ProspectCustName,Req_Mtrs,no_of_shades,EndUse,Segment,Devlopment, Finish,SortNo,EnquiryNo,DevlopmentNo,RequiredOn FROM dbo.Jct_Ops_Devlopment_Request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.RequestedBy=b.empcode WHERE RequestID = @RequestID";

        cmd = new SqlCommand(sqlStr, obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = Request.QueryString["RequestID"];
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while (Dr.Read())
            {

                sb.AppendLine("<tr><td colspan='4'>SUBJECT - DEVELOPMENT REQUEST </td></tr>");
                sb.AppendLine("<tr><td> Request Made By</td> <td>" + Dr["empname"].ToString() + "</td><td></td><td></td></tr>");
                sb.AppendLine("<tr><td> Plant</td> <td>" + Dr["Plant"].ToString() + "</td><td> Sort No</td><td>" + Dr["SortNo"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> DESCRIPTION</td> <td>" + Dr["DESCRIPTION"].ToString() + "</td><td> Customer Name </td><td>" + Dr["CustomerName"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> Prospect Customer</td> <td>" + Dr["ProspectCust"].ToString() + "</td> <td> ProspectCustomer Name</td><td>" + Dr["ProspectCustName"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> REQUIRED Mtrs</td> <td>" + Dr["Req_Mtrs"].ToString() + "</td><td>Shades</td><td>" + Dr["no_of_shades"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> EndUse</td> <td>" + Dr["EndUse"].ToString() + "</td><td>Segment</td><td>" + Dr["Segment"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> Development</td> <td>" + Dr["Devlopment"].ToString() + "</td><td>Finish</td><td>" + Dr["Finish"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> Enquiry No </td> <td>" + Dr["EnquiryNo"].ToString() + "</td><td>DevlopmentNo</td><td>" + Dr["DevlopmentNo"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> RequiredOn</td><td>" + Dr["RequiredOn"].ToString() + "</td><td></td><td></td></tr>");

            }
        }
        Dr.Close();

        sb.AppendLine("</table>");

        sb.AppendLine("<br />");

        sb.AppendLine("FeedBack Details : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");

        sqlStr = "SELECT b.empname,YarnAvailability,LoomAllocation,Greige,SPL,Dyed,ProdCycle,QCReference,QCReference,Remarks FROM dbo.jct_ops_development_request_feedback a INNER JOIN dbo.JCT_EmpMast_Base b ON a.EntryBy=b.empcode  WHERE STATUS='A' AND RequestID = " + Request.QueryString["RequestID"];

        cmd = new SqlCommand(sqlStr, obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = Request.QueryString["RequestID"];
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while (Dr.Read())
            {
                sb.AppendLine("<tr><td colspan='4'>SUBJECT - DEVELOPMENT REQUEST FEEDBACK </td> </tr>");
                sb.AppendLine("<tr><td> FeedBack Given By</td> <td>" + Dr["empname"].ToString() + "</td><td> Yarn Availability</td><td>" + Dr["YarnAvailability"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> Loom Allocation</td> <td>" + Dr["LoomAllocation"].ToString() + "</td><td> Greige </td><td>" + Dr["Greige"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> SPL</td> <td>" + Dr["SPL"].ToString() + "</td> <td> Dyed </td><td>" + Dr["Dyed"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td> ProdCycle</td> <td>" + Dr["ProdCycle"].ToString() + "</td><td></td><td></td></tr>");
                sb.AppendLine("<tr><td> QC Remarks</td> <td>" + Dr["QCReference"].ToString() + "</td><td> </td><td> </td></tr>");
                sb.AppendLine("<tr><td> Remarks</td> <td>" + Dr["Remarks"].ToString() + "</td><td> </td><td> </td></tr>");
            }
        }
        Dr.Close();

        sb.AppendLine("</table>");
        sb.AppendLine("</br>");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");

        sqlStr = "  SELECT b.E_MailID AS EmailID FROM Jct_Ops_Devlopment_Request a INNER JOIN dbo.MISTEL b ON a.RequestedBy=b.empcode WHERE RequestID =" + Request.QueryString["RequestID"];
        try
        {
            requestByEmail = obj1.FetchValue(sqlStr).ToString();
        }
        catch
        {
            requestByEmail = "jatindutta@jctltd.com";
        }

        sqlStr = "SELECT b.E_MailID AS EmailID FROM dbo.jct_ops_development_request_feedback a INNER JOIN dbo.MISTEL b ON a.EntryBy=b.empcode WHERE a.STATUS='A' AND  RequestID = " + Request.QueryString["RequestID"];
        try
        {
            feedbackByEmail = obj1.FetchValue(sqlStr).ToString();
        }
        catch
        {
            feedbackByEmail = "jatindutta@jctltd.com";
        }

        body = sb.ToString();
        @from = "noreply@jctltd.com";
        to = requestByEmail + "," + feedbackByEmail;

        bcc = "jatindutta@jctltd.com,ashish@jctltd.com";
        subject = "Development Request - " + Request.QueryString["RequestID"];
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

        SmtpMail.Send(mail);

    }
}