using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Data;
using System.IO;
public partial class OPS_jct_ops_jobwork_common : System.Web.UI.Page
{
    Connection obj = new Connection();
    SqlConnection con = new SqlConnection(@"Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp ;password=power");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string sqlPass = "Select  distinct requestid from jct_ops_jobwork_common where authflag= 'A' and INVstatus = 'N' ";
            SqlCommand cmd = new SqlCommand(sqlPass, obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();            
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {                    
                    ddlrequestid.Items.Add(dr[0].ToString());                   
                }
            }
            dr.Close();
            //con.Close();
       
        }
    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
        GenerateCode();

        if (ddlrequestid.SelectedItem.Text == "")
        {
            string script = "alert('Please Select RequestID');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
          
        }
        else
        {
            //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string qry = "jct_ops_jobwork_common_Invoice_Insert";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RequestId", SqlDbType.VarChar, 20).Value = ddlrequestid.SelectedItem.Text;
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20).Value = ViewState["InvCode"];
            cmd.Parameters.Add("@Trans_mode", SqlDbType.VarChar, 100).Value = ddlTransportMode.SelectedItem.Text;
            cmd.Parameters.Add("@Rolls", SqlDbType.VarChar, 100).Value = txtRolls.Text;
            cmd.Parameters.Add("@ExciseRollNo", SqlDbType.VarChar, 50).Value = txtExciseRollNo.Text;
            cmd.Parameters.Add("@Tarif_Class_No", SqlDbType.VarChar, 50).Value = txtTariffClassficationNo.Text;
            cmd.Parameters.Add("@GrossWt", SqlDbType.Decimal, 18).Value = txtGrossWt.Text;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lblInvoiceNoCode.Visible = true;
            lblInvoiceNoCode.Text = ViewState["InvCode"].ToString();
            lblInvoiceNo.Visible = true;
            //lblInvoiceNoCode.Visible = true;
            //lblInvoiceNo.Visible = true;
            generatemail();
        }
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    private void bindgrid()
    {
        //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
        //SqlConnection con = new SqlConnection(qry);
        //con.Open();
        string qry = " SELECT RequestId ,InvoiceNo , Trans_mode , Rolls ,ExciseRollNo ,Tarif_Class_No , GrossWt , Remark  FROM jct_ops_jobwork_common_Invoice WHERE  status='A'";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        //con.Close();
    }
    //protected void lnkupdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
    //        SqlConnection con = new SqlConnection(qry);
    //        con.Open();
    //        qry = "jct_ops_jobwork_common_Invoice_Update";
    //        SqlCommand cmd = new SqlCommand(qry, con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@RequestId", SqlDbType.VarChar, 20).Value = ddlrequestid.SelectedItem.Text;
    //        cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20).Value = lblInvoiceNoCode.Text;
    //        cmd.Parameters.Add("@Trans_mode", SqlDbType.VarChar, 100).Value = ddlTransportMode.SelectedItem.Text;
    //        cmd.Parameters.Add("@Rolls", SqlDbType.VarChar, 100).Value = txtRolls.Text;
    //        cmd.Parameters.Add("@ExciseRollNo", SqlDbType.VarChar, 50).Value = txtExciseRollNo.Text;
    //        cmd.Parameters.Add("@Tarif_Class_No", SqlDbType.VarChar, 50).Value = txtTariffClassficationNo.Text;
    //        cmd.Parameters.Add("@GrossWt", SqlDbType.Decimal, 18).Value = txtGrossWt.Text;
    //        cmd.Parameters.Add("@Remark", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
    //        cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];      
    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //        bindgrid();
    //        string script = "alert('Record  Updated.!!');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }
    //    catch (Exception exception)
    //    {
    //        string script = "alert('" + exception.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }
    //}
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string qry = "jct_ops_jobwork_common_Invoice_delete";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20).Value = lblInvoiceNoCode.Text;
            cmd.Parameters.Add("@RequestId", SqlDbType.VarChar, 20).Value = ddlrequestid.Text;
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlrequestid.Items.Clear();
        ddlrequestid.Items.Add(grdDetail.SelectedRow.Cells[1].Text); //ddlrequestid.Items.IndexOf(ddlrequestid.Items.FindByText(grdDetail.SelectedRow.Cells[1].Text));
        lblInvoiceNoCode.Text = grdDetail.SelectedRow.Cells[2].Text;
        ddlTransportMode.SelectedIndex = ddlTransportMode.Items.IndexOf(ddlTransportMode.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text));
        txtRolls.Text = grdDetail.SelectedRow.Cells[4].Text;
        txtExciseRollNo.Text = grdDetail.SelectedRow.Cells[5].Text;
        txtTariffClassficationNo.Text = grdDetail.SelectedRow.Cells[6].Text;
        txtGrossWt.Text = grdDetail.SelectedRow.Cells[7].Text;
        txtRemarks.Text = grdDetail.SelectedRow.Cells[8].Text;
        lblInvoiceNoCode.Visible = true;
        lblInvoiceNo.Visible = true;
    }

    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;

        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
        //SqlConnection con = new SqlConnection(qry);
        //con.Open();

        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(InvoiceNo),CHARINDEX('-',max(InvoiceNo))+1,len(max(InvoiceNo))+3) from jct_ops_jobwork_common_Invoice ", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["InvCode"] = "100";
                    ViewState["InvCode"] = "JWCINV-" + ViewState["InvCode"];
                }
                else
                {
                    ViewState["InvCode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["InvCode"] = "JWCINV-" + ViewState["InvCode"];
                }
            }

        }

        dr.Close();
        //con.Close();

        #endregion
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("jct_ops_jobwork_common.aspx");
    }


    public void generatemail()
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
            string querystring1 = string.Empty;
            string querystring2 = string.Empty;
            string indent_no = string.Empty;
            SqlDataReader dr;
            subject = " Jobwork Common Invoice ";
            
            //@from = "aslam@jctltd.com";


            //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string sqlPass = "select InvoiceNo , Requestid from jct_ops_jobwork_common_Invoice  WHERE InvoiceNo  = '" + lblInvoiceNoCode.Text + "' ";

            SqlCommand cmd = new SqlCommand(sqlPass, obj.Connection());
            cmd.CommandType = CommandType.Text;

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ViewState["InvoiceNo"] = dr[0].ToString();
                    ViewState["Requestid"] = dr[1].ToString();
                }
            }
            dr.Close();
            //con.Close();



            subject = "Jobwork Common Invoice Generation";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
            sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("Hi,<br/>");
            sb.AppendLine("Your New Invoice '" +lblInvoiceNoCode.Text +"' Againt the Request Id '" + ddlrequestid.SelectedItem.Text +"' has been generated <br/><br/>");

            //con.Close();
            sb.AppendLine("</table>");

            sb.AppendLine("<br /><br/>");

            

            sb.AppendLine("</table><br />");

            body = sb.ToString();
            @from = "noreply@jctltd.com";
            to = "aslam@jctltd.com";
            //to = "mrsood@jctltd.com,arvindsharma@jctltd.com,ashutoshtiwari@jctltd.com,pgmohan@jctltd.com,skpalta@jctltd.com,vinaydogra@jctltd.com,skj@jctltd.com,ashokjoshi@jctltd.com,rajgopal@jctltd.com";
            //to = "aslam@jctltd.com,shwetaloria@jctltd.com";
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
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("exchange2007");     
            SmtpMail.Send(mail);     
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return;
        }
    
    }

    protected void ddlrequestid_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
        //SqlConnection con = new SqlConnection(qry);
        //con.Open();
        string sqlPass = "SELECT mkt_ref AS Mkt,sort_no AS SortNo ,qty AS Quantity,Construction  FROM  jct_ops_jobwork_common WHERE requestID=  '" + ddlrequestid.SelectedItem.Text + "' ";

        SqlCommand cmd = new SqlCommand(sqlPass, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblmktref.Text = dr[0].ToString();                
                lblSortNo.Text = dr[1].ToString();
                lblQuantity.Text = dr[2].ToString();
                lblConstruction.Text = dr[3].ToString();
            }
        }
        dr.Close();
        //con.Close();

        mkt.Visible = true;
        sort.Visible = true;
        Quantity.Visible = true;
        Construction.Visible = true;

        lblmktref.Visible = true;
        lblSortNo.Visible = true;
        lblQuantity.Visible = true;
        lblConstruction.Visible = true;
 
    }
}