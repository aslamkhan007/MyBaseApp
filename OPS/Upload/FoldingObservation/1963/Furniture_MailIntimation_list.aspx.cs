using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Net;

public partial class AssetMngmnt_Furniture_MailIntimation_list : System.Web.UI.Page
{
    Connection obj = new Connection();
    string location = string.Empty;
    string Sublocation = string.Empty;
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
    string querystring = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            bindgrid1();
        }
    }

    private void bindgrid()
    {
        SqlCommand cmd2 = new SqlCommand("jct_asset_Pending_Mail_List", obj.Connection());
        cmd2.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        grdDetail.DataSource = ds2.Tables[0];
        grdDetail.DataBind();
    }

    private void bindgrid1()
    {
        SqlCommand cmd2 = new SqlCommand("jct_asset_Send_Mail_List", obj.Connection());
        cmd2.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        GridView1.DataSource = ds2.Tables[0];
        GridView1.DataBind();
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "lnkConfirm")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = (int)gvr.RowIndex;
                location = gvr.Cells[5].Text;
                Sublocation = gvr.Cells[6].Text;
                Empcode = gvr.Cells[7].Text;              
                SqlCommand cmd = new SqlCommand("jct_asset_Send_Mail_List_Insert", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Empcode;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = location;
                cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = Sublocation;
                cmd.Parameters.Add("@request_id", SqlDbType.VarChar, 100).Value = grdDetail.DataKeys[rowIndex][0].ToString(); //requestid;
                cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
                string script = "alert('Mail  Confirmed!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                bindgrid();
                bindgrid1();
            }
          
            if (e.CommandName == "Sendmail")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = (int)gvr.RowIndex;
                location = gvr.Cells[5].Text;
                Sublocation = gvr.Cells[6].Text;
                Empcode = gvr.Cells[7].Text;
                ViewState["RequestiD"] = grdDetail.DataKeys[rowIndex][0].ToString(); //requestid;
                sendmail();
            }

            if (e.CommandName == "lnkByPass")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = (int)gvr.RowIndex;
                location = gvr.Cells[5].Text;
                Sublocation = gvr.Cells[6].Text;
                Empcode = gvr.Cells[7].Text;
                ViewState["RequestiD"] = grdDetail.DataKeys[rowIndex][0].ToString(); 
                SqlCommand cmd = new SqlCommand("jct_asset_Send_Mail_List_ByPass", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Empcode;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = location;
                cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = Sublocation;
                cmd.Parameters.Add("@request_id", SqlDbType.VarChar, 100).Value = grdDetail.DataKeys[rowIndex][0].ToString(); 
                cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
                string script = "alert('Mail  ByPassed!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                bindgrid();
                bindgrid1();               
            }
            location = null;
            Sublocation = null;
            Empcode = null;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    private void sendmail()
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
            querystring = string.Empty;
            string Body = string.Empty;





            sql = ("SELECT DISTINCT Usercode FROM  dbo.jct_asset_Employee_Location_map WHERE  Usercode = '" + Empcode + "' AND Location = '" + location + "' AND Sublocation = '" + Sublocation + "' AND module_usedby = 'Gen' AND STATUS = 'A' ");
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usercode = dr[0].ToString();
                }
            }
            dr.Close();

            int emailid = 0;
            sql = "Select a.empname,b.e_mailid as email from  jct_empmast_base a left outer join  mistel b on a.empcode=b.empcode where a.empcode='" + usercode + "'";
            cmd = new SqlCommand(sql, obj.Connection());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                string emailStore;
                if (ds.Tables[0].Rows[0]["email"].ToString() == "")
                {
                    emailStore = "0";
                }
                else
                {
                    emailStore = ds.Tables[0].Rows[0]["email"].ToString();
                }
                emailid = checkmailcount(emailStore);
                if (emailid == 0)
                {
                    ViewState["RequestBy"] = usercode;
                    ViewState["RequestByEmail"] = "aslam@jctltd.com,ashish@jctltd.com";
                    Body = "<html><body><Table><tr><td>The Following User</td></tr><BR /><tr><td>EmployeeCode " + usercode + "</td></tr><BR /><tr><td>EmployeeName : " + ds.Tables[0].Rows[0]["empname"].ToString() + " </td> </tr><BR /><tr><td>Location : " + location + "</td></tr><Br/><tr><td>Sublocation: " + Sublocation + "</td></tr><Br/>  <tr><td>Does Not Have Email Id</td></table></body></html>";
                    to = "ashish@jctltd.com";
                }
                else if (emailid == 1)
                {
                    ViewState["RequestBy"] = ds.Tables[0].Rows[0]["empname"].ToString();
                    ViewState["RequestByEmail"] = ds.Tables[0].Rows[0]["email"].ToString();
                    querystring = "requestid=" + ViewState["RequestiD"];
                    //url = "http://test2k/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail.aspx?" + querystring;
                    url = "http://localhost:1409/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail.aspx?" + querystring;
                    Body = GetPage(url);
                    to = ViewState["RequestByEmail"].ToString();

                }
                else if (emailid > 1)
                {
                    ViewState["RequestBy"] = ds.Tables[0].Rows[0]["empname"].ToString();
                    ViewState["RequestByEmail"] = ds.Tables[0].Rows[0]["email"].ToString();
                    querystring = "requestid=" + ViewState["RequestiD"];
                    //url = "http://test2k/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail_Common.aspx?" + querystring;
                    url = "http://localhost:1409/FusionApps/AssetMngmnt/Asset_Alloc_Intimate_Mail_Common.aspx?" + querystring;
                    Body = GetPage(url);
                    to = ViewState["RequestByEmail"].ToString();
                }
            }

            @from = "it.helpdesk@jctltd.com";

            subject = "Furniture Asset Allocate Intimation" + " " + to;
            bcc = "aslam@jctltd.com";
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(@from);
            //if (to.Contains(","))
            //{
            //    string[] tos = to.Split(',');
            //    for (int i = 0; i <= tos.Length - 1; i++)
            //    {
            //        mail.To.Add(new MailAddress(tos[i]));
            //    }
            //}
            //else
            //{
            //    mail.To.Add(new MailAddress(to));
            //}

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
            string script = "alert('Mail  Sent!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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

    public int checkmailcount(string emailid)
    {
        int count = 0;
        if (emailid != "0")
        {
            String sql1 = "Select count(*) from   mistel  where e_mailid='" + emailid + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, obj.Connection());
            SqlDataReader Dr1 = cmd1.ExecuteReader();
            if (Dr1.HasRows)
            {
                while (Dr1.Read())
                {
                    count = Convert.ToInt16(Dr1[0]);
                }
            }
        }
        else
        {
            count = 0;
        }
        return count;
    }

    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ChkOrderSelAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)grdDetail.HeaderRow.FindControl("ChkOrderSelAll");
        foreach (GridViewRow row in grdDetail.Rows)
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

    //protected void lnkAction_Click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow gvRow in grdDetail.Rows)
    //    {
    //        CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
    //        TextBox AllocationDate = (TextBox)gvRow.FindControl("txtAllocationDate");
    //        if (chkRemove.Checked == true)
    //        {
               
    //        }
    //    }

    //}

    protected void lnkConfirmAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in grdDetail.Rows)
        {
            CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");            
            if (chkRemove.Checked == true)
            {
                int rowIndex = (int)gvRow.RowIndex;
                location = gvRow.Cells[5].Text;
                Sublocation = gvRow.Cells[6].Text;
                Empcode = gvRow.Cells[7].Text;
                SqlCommand cmd = new SqlCommand("jct_asset_Send_Mail_List_Insert", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Empcode;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = location;
                cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = Sublocation;
                cmd.Parameters.Add("@request_id", SqlDbType.VarChar, 100).Value = grdDetail.DataKeys[rowIndex][0].ToString(); //requestid;
                cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
                string script = "alert('Mail  Confirmed!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);                              
            }
             
        }
        bindgrid();
        bindgrid1(); 

    }
    protected void lnkByPassAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in grdDetail.Rows)
        {
            CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
            if (chkRemove.Checked == true)
            {
                int rowIndex = (int)gvRow.RowIndex;
                location = gvRow.Cells[5].Text;
                Sublocation = gvRow.Cells[6].Text;
                Empcode = gvRow.Cells[7].Text;
                ViewState["RequestiD"] = grdDetail.DataKeys[rowIndex][0].ToString();
                SqlCommand cmd = new SqlCommand("jct_asset_Send_Mail_List_ByPass", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Empcode;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = location;
                cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = Sublocation;
                cmd.Parameters.Add("@request_id", SqlDbType.VarChar, 100).Value = grdDetail.DataKeys[rowIndex][0].ToString();
                cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
                string script = "alert('Mails  ByPassed!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }
        bindgrid();
        bindgrid1(); 


    }
    protected void lnkEmailAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in grdDetail.Rows)
        {
              CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
              if (chkRemove.Checked == true)
              {
                  int rowIndex = (int)gvRow.RowIndex;
                  location = gvRow.Cells[5].Text;
                  Sublocation = gvRow.Cells[6].Text;
                  Empcode = gvRow.Cells[7].Text;
                  ViewState["RequestiD"] = grdDetail.DataKeys[rowIndex][0].ToString(); //requestid;
                  sendmail();
              }
        }
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {

    }
}