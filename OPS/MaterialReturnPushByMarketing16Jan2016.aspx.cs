using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Text;
using Telerik.Web.UI;

public partial class OPS_MaterialReturnPushByMarketing : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions objFun = new Functions();
    string qry;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == string.Empty)
        {
            Response.Redirect("~/login.aspx");
        }

        if (!IsPostBack == true)
        {         
            bindHeaderGrid();
        }
    }
    public void bindHeaderGrid()
    {
        string qry = "Jct_Ops_Mr_Mkt_Nofification_Fetch '" + Session["Empcode"].ToString() + "'";
        objFun.FillGrid(qry, ref GridView1);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["SanctionID"] = null;
        ViewState["SanctionID"] = GridView1.SelectedRow.Cells[2].Text;

        string qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_Fetch '" + ViewState["SanctionID"] + "'";
        objFun.FillGrid(qry, ref GridView3);

        //qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_Fetch '" + ViewState["SanctionID"] + "'";
        qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_GridEdit_Fetch '" + ViewState["SanctionID"] + "'";
        objFun.FillGrid(qry, ref GridView2);
        //lblFoldingobservation.Visible = true;
        lblFoldingobservation.Visible = true;

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        if (ViewState["SanctionID"] != null)
        {

            string script = string.Empty;
            SqlTransaction tran = default(SqlTransaction);
            tran = obj.Connection().BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            try
            {
               string OK = string.Empty;
               foreach (GridViewRow gvRow1 in GridView2.Rows)
            {
                CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chkRemove");
                if (chkRemove1.Checked == true)
                {
                    OK = "OK";
                }
            }

            if (OK == "OK")
            {

                foreach (GridViewRow gvRow in GridView2.Rows)
                {
                    Label lblSortNo = (Label)gvRow.FindControl("lblSortNo");
                    Label lblShade = (Label)gvRow.FindControl("lblShade");
                    Label lblMeters = (Label)gvRow.FindControl("lblMeters");
                    Label lblVariant = (Label)gvRow.FindControl("lblVariant");
                    CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
                    RadNumericTextBox txtQty = (RadNumericTextBox)gvRow.FindControl("txtQty");
                               
                    //TextBox txtQty = (TextBox)gvRow.FindControl("txtQty");
                    if (chkRemove.Checked == true)
                    {

                        cmd = new SqlCommand("Jct_Ops_Mr_Mkt_Notification_Insert", obj.Connection(), tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];
                        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 30).Value = lblSortNo.Text;
                        cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = lblShade.Text;
                        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = txtQty.Text;
                        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
                        cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                        cmd.Parameters.Add("@HostIp", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                        cmd.Parameters.Add("@Types", SqlDbType.VarChar, 30).Value = lblVariant.Text;

                        cmd.ExecuteNonQuery();
                        script = "alert('Order Pushed For Sale Order!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
                tran.Commit();         
                bindHeaderGrid();

                #region RestCode

                string NotifyEmailGroup = "Noreply@jctltd.com";
                cmd = new SqlCommand("Jct_Pushby_Mkt_Notify_Users", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];
                //cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = "1590";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        NotifyEmailGroup = NotifyEmailGroup + "," + dr[0];
                    }
                }
                dr.Close();



                string Genratedby_Email = string.Empty;
                qry = "SELECT E_MailID FROM  mistel  WHERE  empcode  = '" + Session["EmpCode"].ToString() + "' ";
                cmd = new SqlCommand(qry, obj.Connection());
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        Genratedby_Email = dr[0].ToString();
                    }
                }
                dr.Close();
                sendmail(Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "hitesh@jctltd.com,hiren@jctltd.com,sandeepr@jctltd.com");  
 
                #endregion

                ViewState["SanctionID"] = null;

            }
            else
            {
                string script2 = "alert('Please Select The Orders And Push For Sale!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }

            }
            catch (Exception ex)
            {
                script = string.Empty;
                tran.Rollback();
                script = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }

        else
        {
            string script1 = "alert('Please Save the SanctionNoteid And then Save !!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
        }

    }

    public void sendmail(string SalesPerson_Email, string too, string NotifyEmailGroup, string bccc)
    {
        try
        {
            string sql = string.Empty;
            string to = string.Empty;
            string from = string.Empty;
            string bcc = string.Empty;
            string cc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;
            string url = string.Empty;
            string querystring = string.Empty;
            string usercode = string.Empty;
            string querystring1 = string.Empty;
            string querystring2 = string.Empty;

            if (ViewState["SanctionID"] != null)
            {
                subject = "Material Return Pushby Marketing";
                //subject = "Material Return Pushby Marketing" + "    " + "To" + "   " + too + "cc" + "    " + NotifyEmailGroup + "   " + "Bcc" + " " + bccc;     
                querystring = "SanctionID=" + ViewState["SanctionID"];
                querystring1 = Session["Empcode"].ToString();

            }

            //url = "http://Test2k/FusionApps/ops/Material_Return_ClosureMail.aspx?" + querystring + "&Empcode=" + querystring1;
            url = "http://misdev/FusionApps/ops/Material_Return_ClosureMail.aspx?" + querystring + "&Empcode=" + querystring1;
            //url = "http://localhost:1733/FusionApps/ops/MaterialReturnPushBymktMail.aspx?" + querystring + "&Empcode=" + querystring1;
            //url = "http://misdev/FusionApps/ops/Material_Return_ClosureMail.aspx?" + querystring + "&Empcode=" + querystring1;


            @from = "noreply@jctltd.com";
            //to = "aslam@jctltd.com,ashish@jctltd.com";
            to = too;

            //bcc = "ashish@jctltd.com";
            bcc = bccc;

            //cc = "ashish@jctltd.com";
            cc = NotifyEmailGroup;

            string Body = GetPage(url);

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
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return;
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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaterialReturnClosure.aspx");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        string qry = "Jct_Ops_Mr_Mkt_Nofification_Fetch '" + Session["Empcode"].ToString() + "'";
        objFun.FillGrid(qry, ref GridView1);
    }

    protected void chkRemove_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow gridRow = (GridViewRow)(sender as Control).Parent.Parent;        
        RequiredFieldValidator RequiredFieldValidator1 = (RequiredFieldValidator)gridRow.FindControl("RequiredFieldValidator1");
        CheckBox checkbox = (CheckBox)gridRow.FindControl("chkRemove");
        
        if (checkbox.Checked == true)
        {
            RequiredFieldValidator1.Enabled = true;
        }
        else
        {
            RequiredFieldValidator1.Enabled = false;
        }	   

    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chk = (CheckBox)e.Row.FindControl("chkRemove");
            RequiredFieldValidator rfv = (RequiredFieldValidator)e.Row.FindControl("RequiredFieldValidator1");

            if (chk.Checked == true)
            {
                rfv.Enabled = true;       
            }
            else
            {
                rfv.Enabled = false;
            }
        }
    }


}