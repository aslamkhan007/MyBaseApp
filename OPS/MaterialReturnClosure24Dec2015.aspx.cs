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

public partial class OPS_MaterialReturnClosure : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions objFun = new Functions();
    string qry;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack == true)
        {
            CreateNumberofRows();
            bindHeaderGrid();
        }
    }
    protected void ddlObservationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        CreateNumberofRows();
    }

    public void CreateNumberofRows()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SrNo", typeof(Int16)));
        dt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        //dt.Columns[0].DefaultValue = 0;
        dt.Columns[0].AutoIncrement = true;
        dt.Columns[0].AutoIncrementSeed = 1;
        dt.Columns[0].AutoIncrementStep = 1;

        for (Int16 i = 1; i <= (Convert.ToInt16(DropDownList1.SelectedItem.Text)); i++)
        {

            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
        }

        GridView2.DataSource = dt;
        GridView2.DataBind();

    }

    public void bindHeaderGrid()
    {                        
        string qry = "Jct_Ops_Mr_Closure_Fetch '" + Session["Empcode"].ToString() + "'";        
        objFun.FillGrid(qry, ref GridView1);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {       
            ViewState["SanctionID"] = null;
            ViewState["SanctionID"] = GridView1.SelectedRow.Cells[2].Text;

            string qry = "Jct_Ops_Mr_Costing_Excess_Fetch_Ashish '" + ViewState["SanctionID"] + "'";
            objFun.FillGrid(qry, ref GrdCosting);

            qry = "Jct_Ops_Mr_Notification_Fetch_Ashish '" + ViewState["SanctionID"] + "'";
            objFun.FillGrid(qry, ref grdPushbyMarketing);

            qry = "Jct_Ops_Mr_Folding_Observation_Excess_Fetch_Ashish '" + ViewState["SanctionID"] + "'";
            objFun.FillGrid(qry, ref grdFolding);
      
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {        
        if (ViewState["SanctionID"] != null)
        {
            string script = string.Empty;
            SqlTransaction tran = default(SqlTransaction);
            try
            {
                tran = obj.Connection().BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                foreach (GridViewRow gvRow in GridView2.Rows)
                {
                    TextBox TxtOrderNo = (TextBox)gvRow.FindControl("txtOrderNo");
                    TextBox txtComments = (TextBox)gvRow.FindControl("txtComments");

                    cmd = new SqlCommand("Jct_Ops_Material_Return_Closure_Insert", obj.Connection(), tran);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 15).Value = TxtOrderNo.Text;
                    cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 200).Value = txtComments.Text;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
                    cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                    cmd.Parameters.Add("@HostIp", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                    cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];

                    cmd.ExecuteNonQuery();
                    script = "alert('Details saved!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                tran.Commit();                
                bindHeaderGrid();


                string NotifyEmailGroup = "Noreply@jctltd.com";                
                cmd = new SqlCommand("Jct_MrClosure_Notify_Users_Mr_Closure", obj.Connection());
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
                sendmail(Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "aslam@jctltd.com,ashish@jctltd.com");                
                ViewState["SanctionID"] = null;
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
            string  script1 = "alert('Please Save the SanctionNoteid And then Save !!');";
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
                subject = "Material Return Closure";
               // subject = "Material Return Closure" + "    " + "To" + "   " + too + "cc" + "    " + NotifyEmailGroup + "   " + "Bcc" + " " + bccc;                
                querystring = "SanctionID=" + ViewState["SanctionID"];
                querystring1 = Session["Empcode"].ToString();               
            }

            //url = "http://localhost:1733/FusionApps/ops/Material_Return_ClosureMail.aspx?" + querystring + "&Empcode=" + querystring1;
            //url = "http://Test2k/FusionApps/ops/Material_Return_ClosureMail.aspx?" + querystring + "&Empcode=" + querystring1;
            url = "http://misdev/FusionApps/ops/Material_Return_ClosureMail.aspx?" + querystring + "&Empcode=" + querystring1;
            
                        

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
 
}