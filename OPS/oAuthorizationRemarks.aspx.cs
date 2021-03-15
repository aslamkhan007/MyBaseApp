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

 
public partial class OPS_AuthorizationRemarks : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    AuthorizationList authorizedlist;
    List<AuthorizationList> authorizedEmployees = new List<AuthorizationList>();

    string sql;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        


        if (!Page.IsPostBack)
        {
            //lblAction.Text = Request.QueryString["Action"];
            //lblEmpCode.Text = Request.QueryString["EmpCode"];

          // ReadEmail();
          

        }
    }

    // Create the callback to validate the redirection URL.
    static bool RedirectionUrlValidationCallback(String redirectionUrl)
    {
        // Perform validation.
       return (redirectionUrl == "https://exchange2007.jct.com/EWS/Exchange.asmx");
   
    }

    //protected void ReadEmail()
    //{
        
    //    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
        
    //    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
 
    
    //    service.Credentials = new WebCredentials("approvals", "pass@123","jct");

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

    protected void ReadMailContent()
    {
        List<string> mailContentList = new List<string>();
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

            int unreadEmailCount = 0;

            SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

            ItemView view = new ItemView(999);

            FindItemsResults<Item> findMails = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
            unreadEmailCount = findMails.Items.Count;

            // list of authorized employees with employee code.

            authorizedlist = new AuthorizationList();
            //authorizedlist.EmpName = "Uppal BlackBerry";
            authorizedlist.EmpName = "UMRAO SHER SINGH UPPAL";
            authorizedlist.EmpCode = "U-04002";
            authorizedEmployees.Add(authorizedlist);

            authorizedlist = new AuthorizationList();
            authorizedlist.EmpName = "Rohit Seru";
            authorizedlist.EmpCode = "R-01111";
            authorizedEmployees.Add(authorizedlist);

            authorizedlist = new AuthorizationList();
            authorizedlist.EmpName = "Sunil Joshi";
            authorizedlist.EmpCode = "S-13741";
            authorizedEmployees.Add(authorizedlist);


            foreach (Item item in findMails.Items)
            {

                //init mail properties
                ExtendedPropertyDefinition htmlBodyProperty = new ExtendedPropertyDefinition(0x1013, MapiPropertyType.Binary);
                PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties, htmlBodyProperty);

                //load message with its properties
                EmailMessage message = EmailMessage.Bind(service, item.Id, propertySet);


                MessageBody messageBody = new MessageBody();
                messageBody.BodyType = Microsoft.Exchange.WebServices.Data.BodyType.Text;

                messageBody = message.Body.Text;

                string subject = message.Subject;
                int bodyLocation = messageBody.Text.IndexOf("<body");
                int fromLocation = messageBody.Text.IndexOf("From:</span>");
                int actualBodyLength = fromLocation - bodyLocation;
                string htmlMessage = message.Body.Text.Substring(bodyLocation, actualBodyLength);
                Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                string actualMessage = reg.Replace(htmlMessage, "");

                foreach (AuthorizationList lst in authorizedEmployees)
                {
                    if (actualMessage.IndexOf(lst.EmpName) != -1)
                    {
                        string content = actualMessage.Substring(0, actualMessage.IndexOf(lst.EmpName));
                        DateTime EMAILDATETIME = message.DateTimeReceived;
                        EmailAddress EMAILFROM = message.From;

                        sql = "JCT_OPS_AUTHORIZE_SANCTIONNOTE_EXECUTIVE_DIRECTOR_EMAIL";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CONTENT", SqlDbType.VarChar, 1000).Value = content;
                        cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 500).Value = subject;
                        cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = "1014";
                        cmd.Parameters.Add("@EMAILDATETIME", SqlDbType.DateTime).Value = EMAILDATETIME;
                        cmd.Parameters.Add("@EMAILFROM", SqlDbType.VarChar, 100).Value = Convert.ToString(EMAILFROM.Address);
                        cmd.ExecuteNonQuery();

                        //mark found mails as read
                        message.IsRead = true;
                        message.Update(ConflictResolutionMode.AlwaysOverwrite);

                        string script = "alert('Sanction notes updated successfully..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }

                }

                //string content = actualMessage.Substring(0, actualMessage.IndexOf("Jatin Dutta"));

                //string script = "alert('Sanction notes updated successfully..!!');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //add mail content to list
                // mailContentList.Add(message.Body.Text); // also message.Subject,    message.Body.Text
            }

        }

        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

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

    //protected void  ReadMailContent()
    //{
    //    List<string> mailContentList = new List<string>();
    //    try
    //    {
          
    //        string MailAddress = "approvals@jctltd.com";

    //        // mail username
    //        string Username = "approvals";
    //        // mail password
    //        string Password = "pass@123";
    //        // domain
    //        // who doesn't know what it is: in command line enter 'whoami' , result x/y:           (x-domain, y-username)
    //        string domain = "jct";
    //        // mail filter subject to read
 
    //        //init service with exchange version
    //        ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
    //        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

    //        //find the mail inbox
    //        service.AutodiscoverUrl(MailAddress, RedirectionUrlValidationCallback);

    //        //put credentials
    //        service.Credentials = new WebCredentials(Username, Password, domain);
 

    //        //filter all unread message with subject "possible subject to looking for"
    //        // here I entered 2 cases: 1.IsEqualTo, 2.ContainsSubstring (it's optional)
    //        //SearchFilter filter = new SearchFilter.SearchFilterCollection(LogicalOperator.And,
    //        //                            new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false),
    //        //                            new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, mailFilterSubject));

    //        ////get messages with filter
    //        //FindItemsResults<Item> findMails = service.FindItems(WellKnownFolderName.Inbox, filter, new ItemView(int.MaxValue));


    //        int unreadEmailCount = 0;

    //        SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

    //        ItemView view = new ItemView(999);

    //        FindItemsResults<Item> findMails = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
    //        unreadEmailCount = findMails.Items.Count;


    //        foreach (Item item in findMails.Items)
    //        {

    //            //init mail properties
    //            ExtendedPropertyDefinition htmlBodyProperty = new ExtendedPropertyDefinition(0x1013, MapiPropertyType.Binary);
    //            PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties, htmlBodyProperty);

    //            //load message with its properties
    //            EmailMessage message = EmailMessage.Bind(service, item.Id, propertySet);


    //            MessageBody messageBody = new MessageBody();
    //            messageBody.BodyType = Microsoft.Exchange.WebServices.Data.BodyType.Text;

    //            messageBody = message.Body.Text;

    //            string subject = message.Subject;
    //            int bodyLocation = messageBody.Text.IndexOf("<body");
    //            int fromLocation = messageBody.Text.IndexOf("From:</span>");
    //            int actualBodyLength = fromLocation - bodyLocation;
    //            string htmlMessage = message.Body.Text.Substring(bodyLocation, actualBodyLength);
    //            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
    //            string actualMessage = reg.Replace(htmlMessage, "");
    //            string content = actualMessage.Substring(0, actualMessage.IndexOf("Rohit Seru"));
    //            DateTime EMAILDATETIME = message.DateTimeReceived;
    //            EmailAddress EMAILFROM = message.From;

    //            sql = "JCT_OPS_AUTHORIZE_SANCTIONNOTE_EXECUTIVE_DIRECTOR_EMAIL";
    //            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.Add("@CONTENT", SqlDbType.VarChar, 1000).Value = content;
    //            cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 500).Value = subject;
    //            cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = "1014";
    //            cmd.Parameters.Add("@EMAILDATETIME", SqlDbType.DateTime).Value = EMAILDATETIME;
    //            cmd.Parameters.Add("@EMAILFROM", SqlDbType.VarChar, 100).Value = Convert.ToString(EMAILFROM.Address);
    //            cmd.ExecuteNonQuery();


    //            //mark found mails as read
    //            message.IsRead = true;
    //            message.Update(ConflictResolutionMode.AlwaysOverwrite);

    //            string script = "alert('Sanction notes updated successfully..!!');";
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //            //add mail content to list
    //           // mailContentList.Add(message.Body.Text); // also message.Subject,    message.Body.Text
    //        }
         
    //    }

    //    catch (Exception ex)
    //    {
    //        string script = "alert('"+ ex.Message +"');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }
       
    //}


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

}