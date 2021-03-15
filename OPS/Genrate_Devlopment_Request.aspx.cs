using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.IO;

public partial class Genrate_Devlopment_Request : System.Web.UI.Page
{
    string qry;
    Functions ObjFun = new Functions();
    Connection obj = new Connection();
    SqlCommand cmd;
    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            GetSalePersons();
        }

    }

    protected void CmdSearch_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con = obj.Connection();
        string st = txtsort.Text.Split('~')[1].ToString();
        string EnqNo = txtsort.Text.Split('~')[2].ToString();

        SqlCommand cmd = new SqlCommand("jct_ops_get_fabric_param", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@sort", SqlDbType.Int).Value = st;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetailsortnosrch.DataSource = ds.Tables[0];
        grdDetailsortnosrch.DataBind();

        ds.Clear();
        SqlCommand cmd2 = new SqlCommand("jct_ops_get_count_detail", con);
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.Parameters.Add("@sort", SqlDbType.Int).Value = st;
        //cmd2.Parameters.Add("@enq", SqlDbType.Int).Value = EnqNo;
        SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        grdDetailsortsrch.DataSource = ds1.Tables[0];
        grdDetailsortsrch.DataBind();
    }

    protected void cmdApply_Click(object sender, EventArgs e)
    {
        string script;
        try
        {
            String CustCode, CustName;
            String Sort, EnquiryNo, DevlopmentNo;
            CustCode="";
            CustName="";
            Sort="";
            EnquiryNo = "";
            DevlopmentNo = "";
            if (txtcustomer.Text.IndexOf("~") == -1 && ddlProspectCust.SelectedItem.Text=="No")
            {
                script = "alert('Invalid Customer...' );";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }


            if (grdDetailsortnosrch.Rows.Count==0 && grdDetailsortsrch.Rows.Count==0)
            {
                script = "alert('No Sort/Devlopment Number selected...Please choose any devlopment number or sort number from list and then CLICK Search Button' );";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }


            if (ddlProspectCust.SelectedItem.Text == "Yes")
            {
                CustCode = txtProspectCust.Text;
                CustName = txtProspectCust.Text;


            }
            else
            {
                CustCode = txtcustomer.Text.Split('~')[1].ToString();
                CustName = txtcustomer.Text.Split('~')[0].ToString();
            }
            String st2 = txtsort.Text.Split('~')[1].ToString();
            String EnqNo1 = txtsort.Text.Split('~')[2].ToString();
            String devno = txtsort.Text.Split('~')[3].ToString();
            
            

            qry = "exec Jct_Ops_Generate_Devlopment_Request '" + Session["Empcode"] + "','" + DdlSalePerson.SelectedItem.Value + "','" + txtdescptn.Text + "','" + ddlPlant.SelectedItem.Text + "','" + CustCode + "','" + CustName + "','" + ddlProspectCust.SelectedItem.Text.Substring(0, 1) + "','" + txtProspectCust.Text + "','" + txtProspectCustAddr.Text + "','" + txtReqMtrs.Text + "','" + txtNo_of_shades.Text + "','" + txtEndUse.Text + "','" + ddlSegment.SelectedItem.Text + "','" + txtDevlopment.Text + "','" + ddlFinish.SelectedItem.Value + "','" + Sort + "','" + EnquiryNo + "','" + DevlopmentNo + "','" + txtRequiredOn.Text + "','" + ddlSampleAttached.SelectedItem.Text + "','" + Request.ServerVariables["REMOTE_ADDR"] + "'";
           // ObjFun.InsertRecord(qry);
            cmd = new SqlCommand(qry, obj.Connection());
            cmd.ExecuteNonQuery();

            String TransactionID;
            String EmpName;
            EmpName = "";
            TransactionID = ObjFun.FetchValue("SELECT MAX(RequestID) FROM Jct_Ops_Devlopment_Request WHERE UserCode='" + Session["Empcode"] + "'").ToString();


            String fromEmail;
            fromEmail = "";
            //------------------New
            //qry = "SELECT MAX(RequestID),E_MailID,name AS EmpName FROM Jct_Ops_Devlopment_Request a,MISTEL b  WHERE UserCode='" + Session["Empcode"] + "'  and a.UserCode=b.empcode GROUP BY E_MailID,name";
            //qry = "SELECT MAX(RequestID),E_MailID,name AS EmpName FROM Jct_Ops_Devlopment_Request a,MISTEL b,jct_ops_sales_team_hierarchy c  WHERE UserCode='A-00098'   AND c.Sale_Person_Code =REPLACE('A-00098','-','')  AND c.HOD = REPLACE(b.empcode,'-','') AND REPLACE(a.UserCode,'-','')=c.Sale_Person_Code  and c.status='A' GROUP BY E_MailID,name ";// GROUP BY E_MailID,name";
            qry = "SELECT  MAX(RequestID) ,b.E_MailID + ',' + d.E_MailID ,  b.name + '~' + d.name  AS EmpName FROM    Jct_Ops_Devlopment_Request a ,MISTEL b ,jct_ops_sales_team_hierarchy c,mistel d WHERE   UserCode = '" + Session["Empcode"] + "' AND c.Sale_Person_Code = REPLACE('" + Session["Empcode"] + "', '-', '') AND c.HOD = REPLACE(b.empcode, '-', '') AND REPLACE(a.UserCode, '-', '') = c.Sale_Person_Code AND c.status = 'A' AND a.UserCode=d.empcode GROUP BY b.E_MailID + ',' + d.E_MailID,  b.name + '~' + d.name  ";
            cmd = new SqlCommand(qry, obj.Connection());
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                fromEmail = dr[1].ToString();
                TransactionID = dr[0].ToString();
                EmpName = dr[2].ToString();
            }
            dr.Close();
            //------------------------



            lblID.Text = TransactionID;
            script = "alert('Record Saved Scuessfully...Your Request No is :-" + TransactionID + "  ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            Sendmail1(TransactionID, fromEmail, EmpName.Split('~')[0].ToString(),EmpName.Split('~')[1].ToString());


        }
         catch(Exception ex)
        {
             script = "alert('Error Occured.." + ex.Message.ToString() + "' );";
             
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
                
    }
    protected void chkSelf_CheckedChanged(object sender, EventArgs e)
    {
        if(chkSelf.Checked==true)
        {
            String EmpName;
            EmpName = ObjFun.FetchValue("SELECT empname FROM dbo.JCT_EmpMast_Base WHERE empcode='" + Session["Empcode"] + "' AND Active='Y'").ToString();
            DdlSalePerson.Enabled = false;
            DdlSalePerson.Items.Clear();
            Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
            item.Value = Session["Empcode"].ToString();
            item.Text = EmpName;
            DdlSalePerson.Items.Add(item);
        }
        else
        {
            DdlSalePerson.Enabled = true;
            GetSalePersons();
        }

    }

    private void GetSalePersons()
    {
        DdlSalePerson.Items.Clear();
        qry = "SELECT  'A-00098' as group_desc,'Ashish Sharma'   as group_no union Select  '' as group_desc, '' as group_no Union Select rtrim(LEFT(group_no,1)+'-'+RIGHT(group_no,LEN(group_no)-1)),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group, dbo.JCT_EmpMast_Base  WHERE group_TYPE='SALESP' AND status ='o' AND group_no=REPLACE(empcode,'-','') AND Active='Y' ORDER BY group_desc";
        cmd = new SqlCommand(qry, obj.Connection());
        dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Telerik.Web.UI.RadComboBoxItem Li = new Telerik.Web.UI.RadComboBoxItem();
                    Li.Value = dr[0].ToString();
                    Li.Text = dr[1].ToString();
                    DdlSalePerson.Items.Add(Li);
                }
            }
    }
    protected void ddlProspectCust_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (ddlProspectCust.SelectedItem.Text.Substring(0, 1) == "Y")
            Panel3.Visible = true;
        else
            Panel3.Visible = false;

    }
    protected string GetPage(string page_name)
    {

        WebClient myclient = new WebClient();
        string myPageHTML = null;
        byte[] requestHTML = null;
        string currentPageUrl = null;

        //byte[] requestHTML;
        //string currentPageUrl = "http://www.yahoo.com"; //Request.Url.ToString();
        //currentPageUrl = "http://localhost:52841/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=QT/004014/2014";

        //currentPageUrl = "http://misdev/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=" & lblQuotationNo.Text

        //currentPageUrl = page_path;
        currentPageUrl = Request.Url.AbsoluteUri;

        currentPageUrl = currentPageUrl.Replace("Generate_Devlopment_Request.aspx", page_name);


        UTF8Encoding utf8 = new UTF8Encoding();

        //UTF8Encoding utf8 = new UTF8Encoding();

        requestHTML = myclient.DownloadData(currentPageUrl);
        myPageHTML = utf8.GetString(requestHTML);

        //Response.Write(myPageHTML)

        return myPageHTML;

    }

    protected void Sendmail1(string transID,string ToEmailID,String pendingEmpName,String raisedByEmpName)
    {
        string from, to, subject, body,bcc;
        bcc = "ashish@jctltd.com,rbaksshi@jctltd.com";
        from = "devlopment@jctltd.com";

        to = ToEmailID;
        subject = "Request Generated  " + transID;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<html>");
        
        sb.AppendLine("<head>");
        sb.AppendLine("<h3>Your Devlopment Request has been genrated scuessfully. Your RequestID is " + transID + " </h3><br>");
        sb.AppendLine("<h4>This Devlopment Request is raised by  " + raisedByEmpName + " </h3>");
        //raisedByEmpName
        sb.AppendLine("<h4>And it is pending at " + pendingEmpName + " for authorization. </h4>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");


        sb.AppendLine("With Description :- ");

        sb.AppendLine("" + txtdescptn.Text);
        sb.AppendLine("<hr>");
        sb.AppendLine("With Detail<br/>");
        sb.AppendLine("</head>");
        sb.AppendLine("<hr>");

        //sb.AppendLine("<table border width=1px>");
        sb.AppendLine("<table class=gridtable>");
        sb.AppendLine("<tr><th><b>Parameter</b></th><th><b>Value</b></th> </tr>");

        sb.AppendLine("<td><b>Plant </b></td><td> " + ddlPlant.Text  + "</tr>");

        sb.AppendLine("<td><b>Sales Person </b></td><td> " + DdlSalePerson.Text + " </td></tr>");

        sb.AppendLine("<td><b>Customer  </b></td><td>" + txtcustomer.Text + " </td></tr>");

        sb.AppendLine("<td><b>Prospect Customer  </b></td><td>" + ddlProspectCust.Text + " </td></tr>");

        sb.AppendLine("<td><b>No. Of Shades  </b></td><td>" + txtNo_of_shades.Text + " </td></tr>");

        sb.AppendLine("<td><b>Required Meters  </b></td><td>" + txtReqMtrs.Text + " </td></tr>");

        sb.AppendLine("<td><b>Segment  </b></td><td>" + ddlSegment.Text + " </td></tr>");

        sb.AppendLine("<td><b>End Use(If Known)  </b></td><td>" + txtEndUse.Text + " </td></tr>");

        sb.AppendLine("<td><b>Devlopment  </b></td><td>" + txtDevlopment.Text + " </td></tr>");

        sb.AppendLine("<td><b>Finish  </b></td><td>" + ddlFinish.Text + " </td></tr>");

        sb.AppendLine("<td><b>Sort No / Enq No  </b></td><td>" + txtsort.Text + " </td></tr>");

        sb.AppendLine("<td><b>Required On  </b></td><td>" + txtRequiredOn.Text + " </td></tr>");

        sb.AppendLine("<td><b>Sample Attached  </b></td><td>" + ddlSampleAttached.Text + " </td></tr>");

        sb.AppendLine("</table>");
        sb.AppendLine("<br /><br/>");
        sb.Append("<a href='http://misdev/fusionapps/OPS/Genrate_Devlopment_Request.aspx'> Click here to view detail... </a><br />");

        //sb.AppendLine("</table><br /><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");
        body = sb.ToString();
     //
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
        mail.To.Add(new MailAddress(to));
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




        //if (!string.IsNullOrEmpty(cc))
        //{
        //    if (cc.Contains(","))
        //    {
        //        string[] ccs = cc.Split(',');
        //        for (int i = 0; i <= ccs.Length - 1; i++)
        //        {
        //            mail.CC.Add(new MailAddress(ccs[i]));
        //        }
        //    }
        //    else
        //    {
        //        mail.CC.Add(new MailAddress(cc));
        //    }
        //}

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;



        string script = "alert('Record saved sucessfully.!! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        return;
    }

}