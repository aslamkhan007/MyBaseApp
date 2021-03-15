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

    public int MyProperty { get; set; }
  

    string shpConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["jctdevConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == "")
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

        string qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_Fetch '" + ViewState["SanctionID"] + "' , 'FOLDING'  ";
        objFun.FillGrid(qry, ref grdViewFolding);


        //qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_Fetch '" + ViewState["SanctionID"] + "' , 'Costing'  ";
        //objFun.FillGrid(qry, ref grdViewCosting);



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

                if (OK != "OK")
                {
                    string script2 = "alert('Please Select The Orders And Push For Sale!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                    return;
                }
                //if (OK == "OK")
                //{

                foreach (GridViewRow gvRow in GridView2.Rows)
                {
                    CheckBox chkRemove1 = (CheckBox)gvRow.FindControl("chkRemove");
                    if (chkRemove1.Checked == true)
                    {
                        Label lblInvoiceNo = (Label)gvRow.FindControl("lblInvoiceNo");
                        Label lblSortNo = (Label)gvRow.FindControl("lblSortNo");
                        Label lblShade = (Label)gvRow.FindControl("lblShade");
                        Label lblMeters = (Label)gvRow.FindControl("lblMeters");
                        Label lblVariant = (Label)gvRow.FindControl("lblVariant");
                        CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
                        RadNumericTextBox txtQty = (RadNumericTextBox)gvRow.FindControl("txtQty");
                        Label lblPendingQty = (Label)gvRow.FindControl("lblPendingQty");
                        //28Jan 2016
                        TextBox txtPrice = (TextBox)gvRow.FindControl("txtPrice");

                        string party = txtPartycode.Text;
                        int index = party.LastIndexOf("~");
                        index = index + 1;
                        party = party.Substring(index, party.Length - index);
                        //28Jan 2016
                        int iPendQty = Convert.ToInt32(lblPendingQty.Text);
                        int itxtQty = Convert.ToInt32(txtQty.Text);

                        if (itxtQty > iPendQty)
                        {
                            string script2 = "alert('Quantity Can not Greater Than Pending Qty!!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                            return;
                        }

                        if (chkRemove.Checked == true)
                        {

                            cmd = new SqlCommand("Jct_Ops_Mr_Mkt_Notification_Insert", obj.Connection(), tran);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 30).Value = lblInvoiceNo.Text;
                            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 30).Value = lblSortNo.Text;
                            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = lblShade.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = txtQty.Text;
                            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
                            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                            cmd.Parameters.Add("@HostIp", SqlDbType.VarChar, 15).Value = Session["EmpCode"].ToString();
                            cmd.Parameters.Add("@Types", SqlDbType.VarChar, 30).Value = lblVariant.Text;
                            //28Jan 2016
                            cmd.Parameters.Add("@Price", SqlDbType.VarChar, 30).Value = txtPrice.Text;
                            cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 30).Value = party;
                            //28Jan 2016
                            cmd.ExecuteNonQuery();
                            script = "alert('Order Pushed For Sale Order!!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        }
                    }
                }
                tran.Commit();
                UpdateStatus();
                bindHeaderGrid();

              GridView2.DataSource = null;
                GridView2.DataBind();

                GridView2.Visible = false;

                grdViewFolding.DataSource = null;
                grdViewFolding.DataBind();

                grdViewFolding.Visible = false;

                //qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_GridEdit_Fetch '" + ViewState["SanctionID"] + "'";
                //objFun.FillGrid(qry, ref GridView2);

                txtPartycode.Text = " ";
                

                txtRemarks.Text = " ";

              //  GridView1_SelectedIndexChanged(null, null);

                #region RestCode

                string NotifyEmailGroup = "hitesh@jctltd.com";
                cmd = new SqlCommand("Jct_Pushby_Mkt_Notify_Users", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];
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
                sendmail(Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "hiren@jctltd.com,sandeepr@jctltd.com");

                #endregion

                ViewState["SanctionID"] = null;

                //}
                //else
                //{
                //    string script2 = "alert('Please Select The Orders And Push For Sale!!');";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                //}

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
            return;
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
                querystring = "SanctionID=" + ViewState["SanctionID"];
                querystring1 = Session["Empcode"].ToString();

            }

            url = "http://testerp/FusionApps/ops/MaterialReturnPushBymktMail.aspx?" + querystring + "&Empcode=" + querystring1;
        //    url = "http://localhost:1084/FusionApps/ops/MaterialReturnPushBymktMail.aspx?" + querystring + "&Empcode=" + querystring1;



            @from = "noreply@jctltd.com";
            to = too;

            bcc = bccc;

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
        Response.Redirect("MaterialReturnPushByMarketing.aspx");
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
                //TextBox txtCode = (TextBox)e.Row.FindControl("txtPartycode");
                //string strValue = txtCode.Text;
            }
            else
            {
                rfv.Enabled = false;
            }


            //       WebService service = new WebService();
            //       TextBox txtParty = (TextBox)e.Row.FindControl("txtPartycode");
            //       string value = txtParty.Text;
            //service.OPS_Customer(txtParty.Text, 20).ToString();


        }
    }


    public void UpdateStatus()
    {

        using (SqlConnection con = new SqlConnection(shpConnectionString))
        {

            using (SqlCommand cmd = new SqlCommand("JCT_OPS_MR_STATUS", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@RequestId", SqlDbType.VarChar).Value = ViewState["SanctionID"];

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }


    }


}