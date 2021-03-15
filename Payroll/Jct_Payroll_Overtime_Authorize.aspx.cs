using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Net;

public partial class Payroll_Jct_Payroll_Overtime_Authorize : System.Web.UI.Page
{
    Connection obj = new Connection();
    public HelpDeskClass ob = new HelpDeskClass();
    public SqlCommand cmd = new SqlCommand();
    public string qry;
    private int i;
    public SqlDataReader dr;
    private string[] cl = new string[71];    
    string Empcode = string.Empty;
    string usercode = string.Empty;
    string sql = string.Empty;
    string to = string.Empty;
    string from = string.Empty;
    string bcc = string.Empty;
    string cc = string.Empty;
    string subject = string.Empty;
    string body = string.Empty;
    string url = string.Empty;
    int check1;
    
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            this.PnlExtTasks.Collapsed = true;
            MyTasks();
        }
    }

    public void MyTasks()
    {
        if (DrpLvStatus.SelectedItem.Text == "Pending")
            FetchRecordPending();
        else if (DrpLvStatus.SelectedItem.Text == "Authorized")
            FetchRecordAuthorized();
        else if (DrpLvStatus.SelectedItem.Text == "Cancelled")
            FetchRecordCancelled();
    }

    public void FetchRecordPending()
    {
        EnableControls();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Overtime_Auto_PendingRecords";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];       
        //Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "R-03339";
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        GridExtTask.DataSource = ds.Tables[0];
        GridExtTask.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
    }

    public void FetchRecordAuthorized()
    {
        DisableControls();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Overtime_Auto_FreezedRecords";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];       
        //Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "R-03339";
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        GridExtTask.DataSource = ds.Tables[0];
        GridExtTask.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
    }

    public void FetchRecordCancelled()
    {
        DisableControls();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Overtime_Auto_CancelRecords";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];       
        //Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "R-03339";
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        GridExtTask.DataSource = ds.Tables[0];
        GridExtTask.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
    }

    protected void DrpLvStatus_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        MyTasks();
    }

    public void DisableControls()
    {
        lnkConfirmAll.Enabled = false;
        LnkCancel.Enabled = false;
    }

    public void EnableControls()
    {
        lnkConfirmAll.Enabled = true;
        LnkCancel.Enabled = true;
    }

    protected void lnkConfirmAll_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in GridExtTask.Rows)
            {
                CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
                if (chkRemove.Checked == true)
                {
                    int rowIndex = (int)gvRow.RowIndex;
                    string Empcode = gvRow.Cells[3].Text.Replace("&nbsp;", "");
                    string OvertimeDt = gvRow.Cells[1].Text.Replace("&nbsp;", "");
                    string OvertimeReason = gvRow.Cells[8].Text.Replace("&nbsp;", "");
                    string StartTime = gvRow.Cells[5].Text.Replace("&nbsp;", "");
                    string EndTime = gvRow.Cells[6].Text.Replace("&nbsp;", "");
                    string OvertimeHours = gvRow.Cells[7].Text.Replace("&nbsp;", "");
                    //string EnterBy = gvRow.Cells[7].Text.Replace("&nbsp;", "");
                    string sql = "Jct_Payroll_Overtime_Detail_AutoInsert";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Empcode;
                    cmd.Parameters.Add("@OvertimeDate", SqlDbType.DateTime).Value = Convert.ToDateTime(OvertimeDt);
                    //cmd.Parameters.Add("@OvertimeDate", SqlDbType.DateTime).Value = OvertimeDt;
                    cmd.Parameters.Add("@OvertimeReason", SqlDbType.VarChar, 50).Value = OvertimeReason;
                    //cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = StartTime;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = Convert.ToDateTime(StartTime);
                    //cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = StartTime;
                    //cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = EndTime;
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = Convert.ToDateTime(EndTime); ;
                    cmd.Parameters.Add("@OvertimeHrs", SqlDbType.VarChar, 10).Value = OvertimeHours + ":0";
                    //cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
                    cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
                    cmd.ExecuteNonQuery();
                }
            }
            MyTasks();
            string script1 = "Overtime has been Authorized";
            //sendmail(script1);
            string script = "alert('Overtime Authorized');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void ChkOrderSelAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)GridExtTask.HeaderRow.FindControl("ChkOrderSelAll");
        foreach (GridViewRow row in GridExtTask.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkCheck");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
    }
    
    protected void LnkCancel_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in GridExtTask.Rows)
            {
                CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
                if (chkRemove.Checked == true)
                {
                    int rowIndex = (int)gvRow.RowIndex;
                    string Empcode = gvRow.Cells[3].Text.Replace("&nbsp;", "");
                    string OvertimeDt = gvRow.Cells[1].Text.Replace("&nbsp;", "");
                    string OvertimeReason = gvRow.Cells[8].Text.Replace("&nbsp;", "");
                    string StartTime = gvRow.Cells[5].Text.Replace("&nbsp;", "");
                    string EndTime = gvRow.Cells[6].Text.Replace("&nbsp;", "");
                    string OvertimeHours = gvRow.Cells[7].Text.Replace("&nbsp;", "");
                    //string EnterBy = gvRow.Cells[7].Text.Replace("&nbsp;", "");
                    string sql = "Jct_Payroll_Overtime_Detail_AuthCancel";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Empcode;
                    cmd.Parameters.Add("@OvertimeDate", SqlDbType.DateTime).Value = Convert.ToDateTime(OvertimeDt);
                    //cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
                    cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
                    cmd.ExecuteNonQuery();
                    check1 = 0;
                }
            }
            MyTasks();
            string script1 = "Overtime has been Cancelled";
            //sendmail(script1);
            string script = "alert('Overtime Cancelled');";
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Overtime_Authorize.aspx");
    }


    private void sendmail(string s)
    {
        try
        {
            sql = string.Empty;
            to = string.Empty;
            from = string.Empty;
            bcc = string.Empty;
            cc = string.Empty;
            subject = string.Empty;
            body = string.Empty;
            url = string.Empty;            
            string Body = string.Empty;

            sql = "Select a.empname,b.e_mailid as email from  jct_empmast_base a left outer join  mistel b on a.empcode=b.empcode where a.empcode='" + Session["EmpCode"] + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                    string emailStore;
                    emailStore = ds.Tables[0].Rows[0]["email"].ToString();                
                    //ViewState["RequestBy"] = usercode;
                    //ViewState["RequestByEmail"] = "aslam@jctltd.com,ashish@jctltd.com,kamal@jctltd.com,rbaksshi@jctltd.com";
                    //Body = "<html><body><Table><tr><td>The Following User</td></tr><BR /><tr><td>EmployeeCode " + UserCode + "</td></tr><BR /><tr><td>EmployeeName : " + ds.Tables[0].Rows[0]["empname"].ToString() + " </td> </tr><BR /><tr><td>Location : " + location + "</td></tr><Br/><tr><td>Sublocation: " + Sublocation + "</td></tr><Br/>  <tr><td>Does Not Have Email Id</td></table></body></html>";
                    Body = "<html><body><Table><tr><td>Hi</td></tr><tr><td>Dear User</td></tr><tr><td>'"+ s +"'</td></tr><BR /><tr><td>This is system Generated Mail Sent Thorough Payroll Application.Please Don't reply over this..</td></tr></table></body></html>";
                    to = emailStore;
                

                //else if (emailid == 1)
                //{
                //    ViewState["RequestBy"] = ds.Tables[0].Rows[0]["empname"].ToString();
                //    ViewState["RequestByEmail"] = ds.Tables[0].Rows[0]["email"].ToString();
                //    querystring = "requestid=" + ViewState["RequestiD"];
                //    // url = "http://test2k/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail.aspx?" + querystring;
                //    //  url = "http://localhost:1733/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail.aspx?" + querystring;
                //    url = "http://testerp/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail.aspx?" + querystring;
                //    Body = GetPage(url);
                //    to = ViewState["RequestByEmail"].ToString();

                //}
                //else if (emailid > 1)
                //{
                //    ViewState["RequestBy"] = ds.Tables[0].Rows[0]["empname"].ToString();
                //    ViewState["RequestByEmail"] = ds.Tables[0].Rows[0]["email"].ToString();
                //    querystring = "requestid=" + ViewState["RequestiD"];
                //    // url = "http://test2k/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail_Common.aspx?" + querystring;
                //    //  url = "http://localhost:1733/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail_Common.aspx?" + querystring;
                //    url = "http://testerp/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail_Common.aspx?" + querystring;
                //    Body = GetPage(url);
                //    to = ViewState["RequestByEmail"].ToString();
                //}
            }

            @from = "noreply@jctltd.com";
            //subject = "Furniture Asset Allocate Intimation" + " " + to;
            subject = "Overtime Auhtorization" + " " + to;
            to=  "aslam@jctltd.com";
            bcc = "aslam@jctltd.com";
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
                    mail.CC.Add(new MailAddress(cc));
                }
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
            mail.Body = Body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
            SmtpMail.Send(mail);
            //string script = "alert('Mail  Sent!!');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            obj.ConClose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return;
        }
        finally
        {

        }
    }

    protected string GetPage(string page_name)
    {
        WebClient myclient = new WebClient();
        string myPageHTML = null;
        byte[] requestHTML = null;
        string currentPageUrl = null;

        currentPageUrl = Request.Url.AbsoluteUri;
        currentPageUrl = page_name;

        UTF8Encoding utf8 = new UTF8Encoding();
        requestHTML = myclient.DownloadData(currentPageUrl);
        myPageHTML = utf8.GetString(requestHTML);
        //Response.Write(myPageHTML);
        return myPageHTML;
    }

}
