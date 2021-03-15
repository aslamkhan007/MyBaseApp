using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using Telerik.Web.UI;
using System.Text;
using System.Net.Mail;


public partial class OPS_AuthorizationRemarks : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    AuthorizationList authorizedlist;
    List<AuthorizationList> authorizedEmployees = new List<AuthorizationList>();

    string sql;
    public DataTable Approvedlist;
    public int countMails=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
             //lblAction.Text = Request.QueryString["Action"];
             //lblEmpCode.Text = Request.QueryString["EmpCode"];

             // ReadEmail();
            ReadMailContent();
            //string Body = GetPage("http://localhost:1883/FusionApps1/OPS/AuthorizationRemarks.aspx");//GetPage("http://misdev/FusionApps/OPS/AuthorizationRemarks.aspx");

            if (countMails > 0)
            {
                SendMail(Approvedlist);
            }

            Response.Write("<script type='text/javascript'>");
            Response.Write("window.opener=null;");
            Response.Write("window.open('','_top');");
            Response.Write("window.top.close();</");
            Response.Write("script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "scr", "<script type=text/javascript>window.close()</script>");
            
        }
    }

    // Create the callback to validate the redirection URL.
    static bool RedirectionUrlValidationCallback(String redirectionUrl)
    {
        // Perform validation.
       //return (redirectionUrl == "https://exchange2k7.jct.com/EWS/Exchange.asmx");
        return (redirectionUrl == "https://exchange2k7.jct.com/EWS/Exchange.asmx");
    
    }

    //protected void ReadEmail()
    //{
        
    //    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
        
    //    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
 
    
      //  service.Credentials = new WebCredentials("approvals", "pass@123","jct");

    //    service.AutodiscoverUrl("approvals@jctltd.com", RedirectionUrlValidationCallback);
 
    //    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(10));
    //    foreach (Item item in findResults.Items)
    //    {

    //        string subject = item.Subject;
           

    //        PropertySet psPropset = new PropertySet();
    //        psPropset.RequestedBodyType = BodyType.Text;
    //        psPropset.BasePropertySet = BasePropertySet.FirstClassProperties;

    //        EmailMessage email = EmailMessage.Bind(service, item.Id);
    //        string senderemail = email.Sender.Address;
    //        string sendername = email.Sender.Name;
    //        string emailsentdate = email.DateTimeSent.ToString();
    //        string empcode = "";
           
          
    //            string sql1 = "Select empcode from mistel where E_MailID='" + senderemail + "' ";
    //            if (obj1.CheckRecordExistInTransaction(sql1))
    //            {
    //                empcode = obj1.FetchValue(sql1).ToString();
    //            }
    //            else
    //            {
    //                empcode = sendername;
    //            }

    //        MessageBody msgBody = new MessageBody();
    //        msgBody = email.Body;

 
            
    //        string textBody = msgBody.Text; 
            

    //        //string sql = "INSERT INTO JCT_OPS_EXCHANGE_EMAILS(EMPCODE ,NAME  ,EMAIL  ,SUBJECT ,BODY,Email_Date )VALUES(@EMPCODE ,@NAME  ,@EMAIL  ,@SUBJECT ,@BODY,@Email_SentDateTime )";
    //        sql = "JCT_OPS_EXCHANGE_EMAILS_INSERT";
    //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = empcode;
    //        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value =sendername;
    //        cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 100).Value = senderemail;
    //        cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 100).Value = subject;
    //        cmd.Parameters.Add("Email_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(emailsentdate);
    //        cmd.Parameters.Add("@BODY", SqlDbType.VarChar, 80000).Value = textBody;
    //        cmd.ExecuteNonQuery();
            
    //        string script = "alert('Record Added Successfully..!!');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);


           
    //    }
         
    //}

    protected void btnClick_Click(object sender, EventArgs e)
    {
         ReadMailContent();
    }

    //protected void  ReadMailContent()
    //{
    //    List<string> mailContentList = new List<string>();
    //    Approvedlist = new DataTable();
    //    DataRow dataRow;

    //    DtColumns(Approvedlist);
       

    //    try
    //    {
          
    //        string MailAddress = "approvals@jctltd.com";

    //        // mail username
    //        string Username = "approvals";
    //        // mail password
    //        string Password = "pass@123";
    //        // domain
    //        string domain = "jct";
    //        // mail filter subject to read
 
    //        //init service with exchange version
    //        ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
    //        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

    //        //find the mail inbox
    //        service.AutodiscoverUrl(MailAddress, RedirectionUrlValidationCallback);

    //        //put credentials
    //        service.Credentials = new WebCredentials(Username, Password, domain);
  
    //        int unreadEmailCount = 0;

    //        SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

    //        ItemView view = new ItemView(999);

    //        FindItemsResults<Item> findMails = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
    //        unreadEmailCount = findMails.Items.Count;

    //        countMails +=  unreadEmailCount;

    //        // list of authorized employees with employee code.

    //        authorizedlist = new AuthorizationList();
    //        authorizedlist.EmpName = "UMRAO SHER SINGH UPPAL";
    //        //authorizedlist.EmpName = "Uppal BlackBerry";
    //        authorizedlist.EmpCode = "U-04002";
    //        authorizedEmployees.Add(authorizedlist);
 
    //        authorizedlist = new AuthorizationList();
    //        authorizedlist.EmpName = "Rohit Seru";
    //        authorizedlist.EmpCode = "R-01111";
    //        authorizedEmployees.Add(authorizedlist);

    //        authorizedlist = new AuthorizationList();
    //        authorizedlist.EmpName = "Sunil Joshi";
    //        authorizedlist.EmpCode = "S-13741";
    //        authorizedEmployees.Add(authorizedlist);
        
    //        foreach (Item item in findMails.Items)
    //        {

    //            //init mail properties
    //            ExtendedPropertyDefinition htmlBodyProperty = new ExtendedPropertyDefinition(0x1013, MapiPropertyType.Binary);
    //            PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties, htmlBodyProperty);

    //            //load message with its properties
    //            EmailMessage message = EmailMessage.Bind(service, item.Id, propertySet);
    //            DateTime EMAILDATETIME = message.DateTimeReceived;
    //            EmailAddress EMAILFROM = message.From;

    //            MessageBody messageBody = new MessageBody();
    //            messageBody.BodyType = Microsoft.Exchange.WebServices.Data.BodyType.Text;

    //            messageBody = message.Body.Text;

    //            dataRow = Approvedlist.NewRow();

    //            dataRow["Sender"] = EMAILFROM.Name;
    //            dataRow["EmailDateTime"] = EMAILDATETIME;
                
 
    //            try
    //            {
    //                string subject = message.Subject;

    //                dataRow["Subject"] = subject;

    //                int bodyLocation = messageBody.Text.IndexOf("<body");
    //                int fromLocation = messageBody.Text.IndexOf("From:</span>");
    //                int actualBodyLength = fromLocation - bodyLocation;
    //                string htmlMessage = message.Body.Text.Substring(bodyLocation, actualBodyLength);
    //                Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
    //                string actualMessage = reg.Replace(htmlMessage, "");

    //                foreach (AuthorizationList lst in authorizedEmployees)
    //                {
    //                    if (actualMessage.IndexOf(lst.EmpName) != -1)
    //                    {
    //                        string content = actualMessage.Substring(0, actualMessage.IndexOf(lst.EmpName));
                          
    //                        try
    //                        {
    //                            sql = "JCT_OPS_AUTHORIZE_SANCTIONNOTE_EXECUTIVE_DIRECTOR_EMAIL";
    //                            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //                            cmd.CommandType = CommandType.StoredProcedure;
    //                            cmd.Parameters.Add("@CONTENT", SqlDbType.VarChar, 1000).Value = content;
    //                            cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 500).Value = subject;
    //                            cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = "1014";
    //                            cmd.Parameters.Add("@EMAILDATETIME", SqlDbType.DateTime).Value = EMAILDATETIME;
    //                            cmd.Parameters.Add("@EMAILFROM", SqlDbType.VarChar, 100).Value = Convert.ToString(EMAILFROM.Address);
    //                            cmd.ExecuteNonQuery();

    //                            dataRow["Content"] = content;
    //                            dataRow["ActionTaken"] = "Approved";

    //                            Approvedlist.Rows.Add(dataRow);

    //                            //mark found mails as read
    //                            message.IsRead = true;
    //                            message.Update(ConflictResolutionMode.AlwaysOverwrite);
    //                        }

    //                        catch (Exception ex)
    //                        {
    //                            dataRow["Content"] = content;
    //                            dataRow["ActionTaken"] = ex.Message;
    //                            Approvedlist.Rows.Add(dataRow);

    //                            //message.IsRead = true;
    //                           //message.Update(ConflictResolutionMode.AlwaysOverwrite);
    //                        }
      
    //                        //string script = "alert('Sanction notes updated successfully..!!');";
    //                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //                    }

    //                }
    //            }
    //            catch(Exception ex)
    //            {
    //                dataRow["Content"] = messageBody;
    //                dataRow["ActionTaken"] = ex.Message ;
    //                Approvedlist.Rows.Add(dataRow);

    //                //message.IsRead = true;
    //                //message.Update(ConflictResolutionMode.AlwaysOverwrite);
                  
    //            }

    //            int count = Approvedlist.Rows.Count;

    //        }

    //        ViewState["ApprovedList"] = Approvedlist;
    //        radGridActionList.Visible = true;
    //        radGridActionList.DataSource = Approvedlist;
    //        radGridActionList.DataBind();
         
    //    }

    //    catch (Exception ex)
    //    {
    //        //string script = "alert('"+ ex.Message +"');";
    //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }
       
    //}

    protected void ReadMailContent()
    {
        List<string> mailContentList = new List<string>();
        Approvedlist = new DataTable();
        DataRow dataRow;
        int unreadEmailCount = 0;
        int bodyLocation = 0;
        int fromLocation = 0;
        int actualBodyLength = 0;
        string htmlMessage = string.Empty;
        string actualMessage = string.Empty;

        DtColumns(Approvedlist);


        try
        {

            string MailAddress = "approvals@jctltd.com";

            // mail username
            string Username = "approvals";
            // mail password
            string Password = "pass@123";
            // domain
            string domain = "jct";
            // mail filter subject to read

            //init service with exchange version
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            //find the mail inbox
            service.AutodiscoverUrl(MailAddress, RedirectionUrlValidationCallback);

            //put credentials
            service.Credentials = new WebCredentials(Username, Password, domain);

            SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

            ItemView view = new ItemView(999);

            FindItemsResults<Item> findMails = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
            unreadEmailCount = findMails.Items.Count;

            countMails += unreadEmailCount;

            // list of authorized employees with employee code.

            authorizedlist = new AuthorizationList();
            authorizedlist.EmpName = "UMRAO SHER SINGH UPPAL";
            //authorizedlist.EmpName = "Uppal BlackBerry";
            authorizedlist.EmpCode = "U-04002";
            authorizedEmployees.Add(authorizedlist);

            authorizedlist = new AuthorizationList();
            authorizedlist.EmpName = "Rohit Seru";
            authorizedlist.EmpCode = "R-01111";
            authorizedEmployees.Add(authorizedlist);

            //authorizedlist = new AuthorizationList();
           // authorizedlist.EmpName = "Sunil Joshi";
            //authorizedlist.EmpCode = "S-13741";
            //authorizedEmployees.Add(authorizedlist);

            //authorizedlist = new AuthorizationList();
           // authorizedlist.EmpName = "UMESH PRASAD MATHUR";
           // authorizedlist.EmpCode = "U-04005";
           // authorizedEmployees.Add(authorizedlist);

            authorizedlist = new AuthorizationList();
            authorizedlist.EmpName = "R K Kapoor";
            authorizedlist.EmpCode = "R-03470";
            authorizedEmployees.Add(authorizedlist);

            foreach (Item item in findMails.Items)
            {

                //init mail properties
                ExtendedPropertyDefinition htmlBodyProperty = new ExtendedPropertyDefinition(0x1013, MapiPropertyType.Binary);
                PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties, htmlBodyProperty);

                //load message with its properties
                EmailMessage message = EmailMessage.Bind(service, item.Id, propertySet);
                DateTime EMAILDATETIME = message.DateTimeReceived;
                EmailAddress EMAILFROM = message.From;

                MessageBody messageBody = new MessageBody();
                messageBody.BodyType = Microsoft.Exchange.WebServices.Data.BodyType.Text;
                messageBody = message.Body.Text;

                dataRow = Approvedlist.NewRow();
                dataRow["Sender"] = EMAILFROM.Name;
                dataRow["EmailDateTime"] = EMAILDATETIME;

                try
                {
                    string subject = message.Subject;

                    dataRow["Subject"] = subject;

                    if (!messageBody.Text.Contains("<div>Uppal BlackBerry® on Airtel</div>")  && !messageBody.Text.Contains("Sent from my iPhone</div>"))
                    {
                        if (messageBody.Text.Contains("<body ocsi"))
                        {
                            bodyLocation = messageBody.Text.IndexOf("<div>");
                            fromLocation = messageBody.Text.IndexOf("</font></span>");
                        }
                        else
                        {
                            bodyLocation = messageBody.Text.IndexOf("<body");
                            fromLocation = messageBody.Text.IndexOf("From:</span>");
                        }


                        actualBodyLength = fromLocation - bodyLocation;
                        htmlMessage = message.Body.Text.Substring(bodyLocation, actualBodyLength);
                        Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                        actualMessage = reg.Replace(htmlMessage, "");

                        foreach (AuthorizationList lst in authorizedEmployees)
                        {
                            if (actualMessage.IndexOf(lst.EmpName) != -1)
                            {
                                string content = actualMessage.Substring(0, actualMessage.IndexOf(lst.EmpName));

                                try
                                {
                                    sql = "JCT_OPS_AUTHORIZE_SANCTIONNOTE_EXECUTIVE_DIRECTOR_EMAIL";
                                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@CONTENT", SqlDbType.VarChar, 1000).Value = content;
                                    cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 500).Value = subject;
                                    cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = "1014";
                                    cmd.Parameters.Add("@EMAILDATETIME", SqlDbType.DateTime).Value = EMAILDATETIME;
                                    cmd.Parameters.Add("@EMAILFROM", SqlDbType.VarChar, 100).Value = Convert.ToString(EMAILFROM.Address);
                                    cmd.ExecuteNonQuery();

                                    dataRow["Content"] = content;
                                    dataRow["ActionTaken"] = "Approved";

                                    Approvedlist.Rows.Add(dataRow);

                                    //mark found mails as read
                                    message.IsRead = true;
                                    message.Update(ConflictResolutionMode.AlwaysOverwrite);
                                }
                                catch (Exception ex)
                                {
                                    dataRow["Content"] = content;
                                    dataRow["ActionTaken"] = ex.Message;
                                    Approvedlist.Rows.Add(dataRow);
                                }

                                string script = "alert('Sanction notes updated successfully..!!');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                            }
                        }
                    }

                    else if (messageBody.Text.Contains("Sent from my iPhone</div>"))
                    {
                        if (messageBody.Text.Contains("<body dir"))
                        {
                            bodyLocation = messageBody.Text.IndexOf("<div>");
                            fromLocation = messageBody.Text.IndexOf("<br>");
                        }
                        else
                        {
                            //bodyLocation = messageBody.Text.IndexOf("<body");
                            //fromLocation = messageBody.Text.IndexOf("From:</span>");
                        }

                        actualBodyLength = fromLocation - bodyLocation;
                        htmlMessage = message.Body.Text.Substring(bodyLocation, actualBodyLength);
                        Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                        actualMessage = reg.Replace(htmlMessage, "");

                        string content = actualMessage;

                        try
                        {
                            sql = "JCT_OPS_AUTHORIZE_SANCTIONNOTE_EXECUTIVE_DIRECTOR_EMAIL";
                            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CONTENT", SqlDbType.VarChar, 1000).Value = content;
                            cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 500).Value = subject;
                            cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = "1014";
                            cmd.Parameters.Add("@EMAILDATETIME", SqlDbType.DateTime).Value = EMAILDATETIME;
                            cmd.Parameters.Add("@EMAILFROM", SqlDbType.VarChar, 100).Value = Convert.ToString(EMAILFROM.Address);
                            cmd.ExecuteNonQuery();

                            dataRow["Content"] = content;
                            dataRow["ActionTaken"] = "Approved";

                            Approvedlist.Rows.Add(dataRow);

                            //mark found mails as read
                            message.IsRead = true;
                            message.Update(ConflictResolutionMode.AlwaysOverwrite);
                        }
                        catch (Exception ex)
                        {
                            message.IsRead = true;
                            message.Update(ConflictResolutionMode.AlwaysOverwrite);
                            dataRow["Content"] = content;
                            dataRow["ActionTaken"] = ex.Message;
                            Approvedlist.Rows.Add(dataRow);
                        }

                        string script = "alert('Sanction notes updated successfully..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                    }

                    else
                    {
                        bodyLocation = messageBody.Text.IndexOf("</style>");
                        //fromLocation = messageBody.Text.IndexOf("<div>Uppal BlackBerry® on Airtel</div>");
                        fromLocation = messageBody.Text.IndexOf("<div>Sent from BlackBerry® on Airtel</div>");

                        actualBodyLength = fromLocation - bodyLocation;
                        htmlMessage = message.Body.Text.Substring(bodyLocation, actualBodyLength);
                        Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                        actualMessage = reg.Replace(htmlMessage, "");


                        string content = actualMessage;

                        try
                        {
                            sql = "JCT_OPS_AUTHORIZE_SANCTIONNOTE_EXECUTIVE_DIRECTOR_EMAIL";
                            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CONTENT", SqlDbType.VarChar, 1000).Value = content;
                            cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 500).Value = subject;
                            cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = "1014";
                            cmd.Parameters.Add("@EMAILDATETIME", SqlDbType.DateTime).Value = EMAILDATETIME;
                            cmd.Parameters.Add("@EMAILFROM", SqlDbType.VarChar, 100).Value = Convert.ToString(EMAILFROM.Address);
                            cmd.ExecuteNonQuery();

                            dataRow["Content"] = content;
                            dataRow["ActionTaken"] = "Approved";

                            Approvedlist.Rows.Add(dataRow);

                            //mark found mails as read
                            message.IsRead = true;
                            message.Update(ConflictResolutionMode.AlwaysOverwrite);
                        }
                        catch (Exception ex)
                        {
                            message.IsRead = true;
                            message.Update(ConflictResolutionMode.AlwaysOverwrite);
                            dataRow["Content"] = content;
                            dataRow["ActionTaken"] = ex.Message;
                            Approvedlist.Rows.Add(dataRow);
                        }

                        string script = "alert('Sanction notes updated successfully..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }



                }
                catch (Exception ex)
                {
                    dataRow["Content"] = messageBody;
                    dataRow["ActionTaken"] = ex.Message;
                    Approvedlist.Rows.Add(dataRow);
                }

                int count = Approvedlist.Rows.Count;

            }

            ViewState["ApprovedList"] = Approvedlist;
            radGridActionList.Visible = true;
            radGridActionList.DataSource = Approvedlist;
            radGridActionList.DataBind();
        }

        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void DtColumns(DataTable dt)
    {
        dt.Columns.Add("Sender", typeof(string));
        dt.Columns.Add("Subject", typeof(string));
        dt.Columns.Add("Content", typeof(string));
        dt.Columns.Add("ActionTaken", typeof(string));
        dt.Columns.Add("EmailDateTime", typeof(DateTime));
    }

    public class AuthorizationList
    {
        private string _empName;

        public string EmpName
        {
            get { return _empName; }
            set { _empName = value; }
        }

        private string _empCode;

        public string EmpCode
        {
            get { return _empCode; }
            set { _empCode = value; }
        }
        
        
    }

    //protected void readEmail()
    //{



    //      List<string> mailContentList = new List<string>();
    //    string MailAddress = "approvals@jctltd.com";

    //    // mail username
    //    string Username = "approvals";
    //    // mail password
    //    string Password = "pass@123";
    //    // domain
    //    // who doesn't know what it is: in command line enter 'whoami' , result x/y:           (x-domain, y-username)
    //    string domain = "jct";
    //    // mail filter subject to read
    //    string mailFilterSubject = "RE: Material Return Request  - NIKKU RAM & CO (DLH) with ID - 1061";


    //    //init service with exchange version
    //    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

    //    //find the mail inbox
    //    service.AutodiscoverUrl(MailAddress);

    //    //put credentials
    //    service.Credentials = new WebCredentials(Username, Password, domain);

    //    service.AutodiscoverUrl(MailAddress);

    //    Folder searchInboxFolder = Folder.Bind(service, WellKnownFolderName.Inbox);
    //    ItemView view = new ItemView(10);
    //    // Identify the Subject, DateTimeReceived properties to return.
    //    // Indicate that the base property will be the item identifier
    //    view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject, ItemSchema.DateTimeReceived);
    //    // Order the search results by the DateTimeReceived in Ascending order.
    //    view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Ascending);
    //    // Set the traversal to shallow.
    //    view.Traversal = ItemTraversal.Shallow;
    //    // Add a search filter that searches on the UnRead Mails.
    //    SearchFilter.SearchFilterCollection unReadEmailSearchCollection = new SearchFilter.SearchFilterCollection(LogicalOperator.And);
    //    unReadEmailSearchCollection.Add(new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

    //    // Send the request to search the Inbox and get the results.
    //    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, unReadEmailSearchCollection, view);
    //    service.LoadPropertiesForItems(findResults, new PropertySet(ItemSchema.ConversationId, ItemSchema.Body, ItemSchema.Subject, ItemSchema.DateTimeReceived));
    //}

    protected void radGridActionList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem dataitem = e.Item as GridDataItem;
            string Action = dataitem["ActionTaken"].Text;
            if (Action != "Approved")
            {
                dataitem.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void radGridActionList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        radGridActionList.DataSource = ViewState["ApprovedList"];
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ReadAllMails();
    }

    protected void ReadAllMails()
    {
        string MailAddress = "approvals@jctltd.com";

        // mail username
        string Username = "approvals";
        // mail password
        string Password = "pass@123";
        // domain
        string domain = "jct";
        // mail filter subject to read

        //init service with exchange version
        ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

        //find the mail inbox
        service.AutodiscoverUrl(MailAddress, RedirectionUrlValidationCallback);

        //put credentials
        service.Credentials = new WebCredentials(Username, Password, domain);

        int unreadEmailCount = 0;

        SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

        ItemView view = new ItemView(999);

        FindItemsResults<Item> findMails = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
        unreadEmailCount = findMails.Items.Count;

        foreach (Item item in findMails.Items)
        {
            //init mail properties
            ExtendedPropertyDefinition htmlBodyProperty = new ExtendedPropertyDefinition(0x1013, MapiPropertyType.Binary);
            PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties, htmlBodyProperty);

            //load message with its properties
            EmailMessage message = EmailMessage.Bind(service, item.Id, propertySet);

            message.IsRead = true;
            message.Update(ConflictResolutionMode.AlwaysOverwrite);
        }

        radGridActionList.DataSource = null;
        radGridActionList.DataBind();
        
        string script = "alert('All Mails marked as Read..!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

    }

    protected string GetPage(string page_name)
    {

        WebClient myclient = new WebClient();
        string myPageHTML = null;
        byte[] requestHTML = null;
        string currentPageUrl = null;

        currentPageUrl = Request.Url.AbsoluteUri;

        //currentPageUrl = currentPageUrl.Replace("AuthorizationRemarks.aspx", page_name);

        UTF8Encoding utf8 = new UTF8Encoding();

 
        requestHTML = myclient.DownloadData(currentPageUrl);
        myPageHTML = utf8.GetString(requestHTML);

        //Response.Write(myPageHTML)

        return myPageHTML;

    }

    private void SendMail(DataTable dt)
    {

        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        //string body = null;
 
        //con.Close();
      
        @from = "approvals@jctltd.com";

        to = "hitesh@jctltd.com,hiren@jctltd.com,harendra@jctltd.com,sandeepr@jctltd.com";

        StringBuilder myBuilder = new StringBuilder();

        myBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
        myBuilder.Append("style='border: solid 1px Silver; font-size: x-small;'>");

        myBuilder.Append("<tr align='left' valign='top'>");
        foreach (DataColumn myColumn in dt.Columns)
        {
            myBuilder.Append("<td align='left' valign='top'>");
            myBuilder.Append(myColumn.ColumnName);
            myBuilder.Append("</td>");
        }
        myBuilder.Append("</tr>");

        foreach (DataRow myRow in dt.Rows)
        {
            myBuilder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn myColumn in dt.Columns)
            {
                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(myRow[myColumn.ColumnName].ToString());
                myBuilder.Append("</td>");
            }
            myBuilder.Append("</tr>");
        }
        myBuilder.Append("</table>");

        subject = "List of Authorization through Mail";
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

        if (dt.Rows.Count > 0)
        {
            mail.Subject = subject;
            mail.Body = myBuilder.ToString();
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
            SmtpMail.Send(mail);
        }
        else
        {
            mail.Subject = subject;
            mail.Body = "No Record updated. Please check the email account to check if any record is to be updated..!!"; //myBuilder.ToString();
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
            SmtpMail.Send(mail);
        }

        //mail.Subject = subject;
        //mail.Body = myBuilder.ToString(); ;
        //mail.IsBodyHtml = true;
        //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        //SmtpClient SmtpMail = new SmtpClient("exchange2007");
        //SmtpMail.Send(mail);
    }

}