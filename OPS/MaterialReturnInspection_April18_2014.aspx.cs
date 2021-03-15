using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Data;
using System.IO;

public partial class OPS_MaterialReturnInspection : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql = "jct_ops_material_return_inspection_data";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdInspection.DataSource = ds.Tables[0];
            grdInspection.DataBind();
        }
    }

    protected void grdInspection_SelectedIndexChanged(object sender, EventArgs e)
    {
        int transid = Convert.ToInt16(grdInspection.SelectedRow.Cells[1].Text);
        int requestid = Convert.ToInt16(grdInspection.SelectedRow.Cells[2].Text);
        lblRequestID.Text = requestid.ToString() ;

        sql = "SELECT REASON FROM JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS WHERE STATUS='A'  and Plant = 'COTTON' order by Sr_No";
        obj1.FillList(ddlReason_ins, sql);

        sql = "jct_ops_material_return_inspection_select";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@sr_no", SqlDbType.Int).Value =transid;
        cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = requestid;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                // Request Data Fill
                lblPartyName.Text = dr["Customer"].ToString();
                lblInvoiceNo.Text = dr["invoice_no"].ToString();
                lblSortNo.Text = dr["item_no"].ToString();
                lblShade.Text = dr["shade"].ToString();
                lblInvoiceQty.Text = dr["invoice_qty"].ToString();
                lblReturnQty.Text = dr["Logistics_ReturnQty"].ToString();
                lblRolls.Text = dr["Logistics_BaleNo"].ToString();
                lblReason.Text = dr["Reason"].ToString();
                lblInvoiceDate.Text = dr["invoice_date"].ToString();
                lblSalesPerson.Text = dr["sales_person"].ToString();
                lblPlant.Text = dr["plant"].ToString();
                lblFreightPaidBy.Text = dr["freightpaidby"].ToString();
                lblFreightValue.Text = dr["freightvalue"].ToString();

                // Inspection Data Fill

                lblPartyName_ins.Text = dr["customer"].ToString();
                lblInvoiceNo_ins.Text = dr["invoice_no"].ToString();
                lblSortNo_ins.Text = dr["item_no"].ToString();
                lblShade_ins.Text = dr["shade"].ToString();
                lblInvoiceQty_ins.Text = dr["invoice_qty"].ToString();
                txtReturnQty_ins.Text = dr["Logistics_ReturnQty"].ToString();
                txtRolls_ins.Text = dr["Logistics_BaleNo"].ToString();
                lbmrno.Text = dr["MrNo"].ToString();
                //lblReason_ins.Text = dr["Reason"].ToString();

                ddlReason_ins.SelectedIndex= ddlReason_ins.Items.IndexOf(ddlReason_ins.Items.FindByText(dr["Reason"].ToString()));

                lblInvoiceDate_ins.Text = dr["invoice_date"].ToString();
                lblSalesPerson_ins.Text = dr["sales_person"].ToString();
                lblPlant_ins.Text = dr["plant"].ToString();
                lblFreightPaidBy_ins.Text = dr["freightpaidby"].ToString();
                lblFreightValue_ins.Text = dr["freightvalue"].ToString();

            }
        }
        dr.Close();
        obj.ConClose();

        sql = "Select b.empname as AuthorizedBy,a.userlevel,a.auth_dateTime as AuthorizedDate,a.Remarks from jct_ops_sanctionnote_authorization_listing a inner join jct_empmast_base b on a.empcode=b.empcode where a.id='" + grdInspection.SelectedRow.Cells[2].Text + "' order by userlevel";
        obj1.FillGrid(sql, ref grdAuthorizationHistory);

        sql = "Select empname from jct_empmast_base where empcode='J-01945'";//'"+ Session["EmpCode"].ToString() +"'";
        lblInspectionDoneBy_ins.Text = obj1.FetchValue(sql).ToString();

    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaterialReturnInspection.aspx");
    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {

        int transid = Convert.ToInt16(grdInspection.SelectedRow.Cells[1].Text);
        int requestid = Convert.ToInt16(grdInspection.SelectedRow.Cells[2].Text);
        SqlCommand cmd = new SqlCommand("jct_ops_material_return_inspection_insert", obj.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@transid", SqlDbType.VarChar, 20).Value = transid;
        cmd.Parameters.Add("@REQUESTID  ", SqlDbType.VarChar, 10).Value = requestid;
        //cmd.Parameters.Add("@MrNo", SqlDbType.VarChar, 10).Value = Session["empcode"];
        //cmd.Parameters.Add("@GrNo", SqlDbType.VarChar, 10).Value = Session["empcode"];
        //cmd.Parameters.Add("@GrDate", SqlDbType.VarChar, 10).Value = Session["empcode"];
        cmd.Parameters.Add("@FreightValue", SqlDbType.VarChar, 10).Value = lblFreightValue.Text;
        cmd.Parameters.Add("@FreightPaidby", SqlDbType.VarChar, 10).Value = lblFreightPaidBy.Text;
        cmd.Parameters.Add("@ROLLS", SqlDbType.VarChar, 10).Value = txtRolls_ins.Text;
        cmd.Parameters.Add("@RETURN_QTY", SqlDbType.VarChar, 10).Value = txtReturnQty_ins.Text;
        cmd.Parameters.Add("@SHADE", SqlDbType.VarChar, 10).Value = lblShade_ins.Text;
        cmd.Parameters.Add("@REASON", SqlDbType.VarChar, 10).Value =  lblReason.Text;
        cmd.Parameters.Add("@REASON_DESCRIPTION", SqlDbType.VarChar, 10).Value = txtInspectionRemarks.Text;
        cmd.Parameters.Add("@EnteredBy", SqlDbType.VarChar, 10).Value = Session["empcode"];
        //cmd.Parameters.Add("@Transport", SqlDbType.VarChar, 10).Value = 
   
        cmd.ExecuteNonQuery();


        string script = "alert(' record saved sucesfully.!!  please press clear button!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        sendmail();
        // table name - select * from JCT_OPS_MATERIAL_RETURN_INSPECTION
        // send mail code
    }
     


    private void sendmail()
    {
        try
        {

            int transid = Convert.ToInt16(grdInspection.SelectedRow.Cells[1].Text);
            int requestid = Convert.ToInt16(grdInspection.SelectedRow.Cells[2].Text);
            string sql = string.Empty;
            string to = string.Empty;
            string from = string.Empty;
            string bcc = string.Empty;
            string cc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;
            string url = string.Empty;
            string querystring = string.Empty;
        

            //subject = "Material Return Inspection" + requestid;//ViewState["budgetID"];
            //querystring = "RequestID=" + ViewState["RequestID"];
            querystring = "transid=" + transid + "&requestid=" + requestid ;

            //url = "http://localhost:1291/FusionApps/OPS/MailContentPages/materialReturnMail.aspx?" + querystring;

            url = "http://localhost:1291/FusionApps/OPS/MailContentPages/materialReturnMail.aspx?" + querystring;
            // url = "http://test2k/FusionApps/OPS/MailContentPages/excessbudgetmail.aspx?" + querystring;

            //url = "http://misdev/FusionApps/OPS/MailContentPages/excessbudgetmail.aspx?" + querystring;

            @from = "noreply@jctltd.com";

            //sql = "SELECT b.E_MailID FROM dbo.jct_ops_excess_bdget_amt a INNER JOIN dbo.MISTEL b ON a.entry_by=b.empcode WHERE a.budgetID='" + ViewState["budgetID"] + "' AND status='A'";
      
            try
            {
                //to = obj1.FetchValue(sql).ToString();
               // to = "jatindutta@jctltd.com,shwetaloria@jctltd.com";
                to = "shwetaloria@jctltd.com";
            }
            catch { to = ""; }
            to = "shwetaloria@jctltd.com";
            //to = "jatindutta@jctltd.com,shwetaloria@jctltd.com";
            // bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
            // bcc = "jatindutta@jctltd.com,shwetaloria@jctltd.com,rajan@jctltd.com,rbaksshi@jctltd.com";
            // cc = "laxman@jctltd.com,arvindsharma@jctltd.com,dpbadhwar@jctltd.com";

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
            SmtpClient SmtpMail = new SmtpClient("exchange2007");
            SmtpMail.Send(mail);
        }
        catch (Exception ex)
        {
            //lblError.Text = "Error : " + ex.Message;
            //return;
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
        //Response.Write(myPageHTML)
        return myPageHTML;

    }
}