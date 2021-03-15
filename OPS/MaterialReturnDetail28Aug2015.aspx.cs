using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

public partial class OPS_MaterialReturnDetail : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    String enclosureslist;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdDetail.DataSourceID = "SqlDataSource1";
            grdDetail.DataBind();
        }
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        grdDetail.DataSourceID = "SqlDataSource1";
        grdDetail.DataBind();
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlEdit.Visible = true;
        sql = "SELECT RequestID,customer,invoice_no,item_no,Convert(numeric(12,2),invoice_qty) as invoice_qty,ret_qty ,bales,Freight_by FROM dbo.jct_ops_material_request WHERE RequestID=" + grdDetail.SelectedRow.Cells[1].Text;
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblTitle.Text = "Details of Material Return Request for Customer : " + dr[1].ToString();
                lblRequestID.Text = dr[0].ToString();
                lblCustomer.Text = dr[1].ToString();
                lblInvoiceNo.Text = dr[2].ToString();
                lblItemNo.Text = dr[3].ToString();
                lblInvoiceQty.Text = dr[4].ToString();
                lblReturnQty.Text = dr[5].ToString();
                lblBales.Text = dr[6].ToString();
                lblFreightBy.Text = dr[7].ToString();
                
            }
        }
    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string list = ListOfElcosures(chbEnclosures, txtEnclosures);
            sql = "JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION_Proc";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = Convert.ToInt16(lblRequestID.Text);
            cmd.Parameters.Add("@GrNo", SqlDbType.VarChar, 30).Value = txtGrNo.Text;
            cmd.Parameters.Add("@GrDate", SqlDbType.VarChar, 20).Value = (txtGrDate.Text == "" ? null : txtGrDate.Text);
            cmd.Parameters.Add("@FreightValue", SqlDbType.Decimal).Value = Convert.ToDecimal((txtAmount.Text == "" ? "0" : txtAmount.Text));
            cmd.Parameters.Add("@FreightPaidBy", SqlDbType.VarChar, 50).Value = lblFreightBy.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@PendingAt", SqlDbType.VarChar, 50).Value = "R-03481,P-03055";
            cmd.Parameters.Add("@Enclosures", SqlDbType.VarChar, 500).Value = list;
            cmd.ExecuteNonQuery();
            SendMail();
            pnlEdit.Visible = false;
            grdDetail.DataSourceID = "SqlDataSource1";
            grdDetail.DataBind();

            String Script = "alert('Request Sent for Finaly Authorization to PG Mohanan. Please send all the required documents to Logistics department for further action..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Script, true);
        }
        catch (Exception ex)
        {
            String Script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Script, true);
        }
     
    }


    protected string ListOfElcosures(CheckBoxList chb, TextBox txt)
    {

        List<string> enclosures = new List<string>();

        for (int i = 0; i <= chbEnclosures.Items.Count - 1; i++)
        {

            if (chb.Items[i].Selected)
            {

                if (chb.Items[i].Text == "Other")
                {
                    enclosures.Add(txt.Text);

                }
                else
                {
                    enclosures.Add(chb.Items[i].Text);

                }


            }


        }

        //enclosureslist.Join(",", enclosures.ToArray)
        enclosureslist = string.Join(",", new List<string>(enclosures).ToArray());

        return enclosureslist;

    }

    protected void chbEnclosures_SelectedIndexChanged(object sender, System.EventArgs e)
{
	for (int i = 0; i <= chbEnclosures.Items.Count - 1; i++) {

		if (chbEnclosures.Items[i].Selected) {

			if (chbEnclosures.Items[i].Text == "Other") {
				txtEnclosures.Visible = true;
			}


		} else {

			if (chbEnclosures.Items[i].Text == "Other") {
				txtEnclosures.Visible = false;

			}

		}
	}


}

    protected void chbEnclosures_SelectedIndexChanged1(object sender, EventArgs e)
    {
        for (int i = 0; i <= chbEnclosures.Items.Count - 1; i++)
        {

            if (chbEnclosures.Items[i].Selected)
            {

                if (chbEnclosures.Items[i].Text == "Other")
                {
                    txtEnclosures.Visible = true;
                }

            }
            else
            {

                if (chbEnclosures.Items[i].Text == "Other")
                {
                    txtEnclosures.Visible = false;

                }

            }
        }
    }

    private void SendMail()
    {
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;


        StringBuilder sb = new StringBuilder();




        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");



        // sb.Append("<head>");
        sb.AppendLine("Hi,<br/><br/>");
        sb.AppendLine("Material Return Request is pending at your end. Please follow details below :<br/><br/>");
        sb.AppendLine("RequestID for your request is : " + lblRequestID.Text + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");
        sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th><th> Invoice Qty</th><th> No. of Bales/Rolls</th> <th> Return Qty</th>  <th> Status</th> </tr>");
        //Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")



        sb.AppendLine("<tr> <td> " + lblInvoiceNo.Text + " </td> <td> " + lblItemNo.Text + "  </td>  <td> " + lblCustomer.Text + "</td>  <td>" + lblInvoiceQty.Text + " </td>  <td>" + lblBales.Text + " </td>  <td>" + lblReturnQty.Text + " </td><td> Authorized </td> </tr> ");
        sb.AppendLine("</table>");
        sb.AppendLine("<br/><br/>");

        sb.AppendLine("<table class=gridtable>");
        sb.AppendLine("<tr><th> Freight Paid By </th><th> Gr No </th> <th> Gr Date </th><th> Freight Value </th> </tr>");
        //Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")

        sb.AppendLine("<tr> <td> " + lblFreightBy.Text + "</td>  <td> " + txtGrNo.Text + " </td> <td> " + txtGrDate.Text + "  </td>  <td>" + txtAmount.Text + " </td>  </tr> ");


        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");
        sb.Append("<a href='http://misdev/fusionapps/OPS/MaterialReturnFinalAuth.aspx'> Click here to view detail... </a><br />");

        sb.AppendLine("</table><br /><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");



        @from = "noreply@jctltd.com";
        sql = "SELECT isnull(b.E_MailID,'jatindutta@jctltd.com') as email FROM dbo.jct_ops_material_request a INNER JOIN dbo.MISTEL b ON a.userid=b.empcode WHERE  a.RequestID= " + lblRequestID.Text + "";
        cc = "" + obj1.FetchValue(sql).ToString() + "";
        to = "pgmohan@jctltd.com,ranjitsaini@jctltd.com";
        //to = "jatindutta@jctltd.com";
        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com";
        //[to] = ("jatindutta@jctltd.com")
        //Email Address of Receiver
        //cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
        subject = " Material Return Request Authorized- " + lblCustomer.Text;
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
            mail.CC.Add(new MailAddress(cc));
        }
        body = sb.ToString();
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;
    }
}