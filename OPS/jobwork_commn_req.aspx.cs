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

public partial class OPS_jobwork_commn_req : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            bindgrid();
         
        }
    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDateTime(txtdelivdate.Text) < Convert.ToDateTime(txtjbcntrctdt.Text))
            {
                string script1 = "alert('Delivery date shoulb be greater than JobContractDate.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
                return;
            }

            GenerateCode();
            sql = "jct_ops_jobwork_common_insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Text;
            cmd.Parameters.Add("@jbcontractno", SqlDbType.VarChar, 130).Value = txtjbctrctno.Text;
            cmd.Parameters.Add("@jbcontractDt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtjbcntrctdt.Text);
            cmd.Parameters.Add("@JobRate", SqlDbType.VarChar, 50).Value = txtjbrate.Text;
            cmd.Parameters.Add("@jobtype", SqlDbType.VarChar, 30).Value = txtjbtype.Text;
            cmd.Parameters.Add("@nature_of_jb", SqlDbType.VarChar, 30).Value = txtnature.Text;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Sort_no", SqlDbType.VarChar, 30).Value = txtsort.Text;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtqty.Text);
            cmd.Parameters.Add("@FabRate", SqlDbType.Decimal).Value = Convert.ToDecimal(txtfabrate.Text);
            cmd.Parameters.Add("@value", SqlDbType.Decimal).Value = Convert.ToDecimal(txtvalue.Text);
            cmd.Parameters.Add("@Construction", SqlDbType.VarChar, 100).Value = txtconstruction.Text;
            cmd.Parameters.Add("@freight_chrg", SqlDbType.VarChar, 20).Value = ddlfreight.SelectedItem.Text;
            cmd.Parameters.Add("@Vendor", SqlDbType.VarChar, 100).Value = txtvendor.Text;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdelivdate.Text);
            cmd.Parameters.Add("@Elongation_bearer", SqlDbType.VarChar, 30).Value = txtelong.Text;
            cmd.Parameters.Add("@elongation_percnt", SqlDbType.VarChar, 10).Value = ddlelong.SelectedItem.Text;
            cmd.Parameters.Add("@shrinkage_bearer ", SqlDbType.VarChar, 30).Value = ddlshrink.Text;
            cmd.Parameters.Add("@shrinkage_percnt", SqlDbType.VarChar, 10).Value = txtshrink.Text;
            cmd.Parameters.Add("@shade_no", SqlDbType.VarChar, 30).Value = txtshade.Text;
            cmd.Parameters.Add("@mkt_ref", SqlDbType.VarChar, 30).Value = txtmkt.Text;


            cmd.ExecuteNonQuery();
          
            bindgrid();
            string script = "alert('Record Saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lbreqid.Visible = true;
            lbid.Text = ViewState["RequestID"].ToString();
            lbid.Visible = true;
            SendMail();

        }
        catch (Exception ex)
        {
            string script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;



        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");


        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(RequestID),CHARINDEX('-',max(RequestID))+1,len(max(RequestID))+3) from jct_ops_jobwork_common", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["RequestID"] = "100";
                    ViewState["RequestID"] = "JWC-" + ViewState["RequestID"];
                }
                else
                {
                    ViewState["RequestID"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["RequestID"] = "JWC-" + ViewState["RequestID"];
                }
            }

        }

        dr.Close();
        //con.Close();

        #endregion
    }
    protected void txtfabrate_TextChanged(object sender, EventArgs e)
    {
        decimal value;
        value = Convert.ToDecimal(txtqty.Text) * Convert.ToDecimal(txtfabrate.Text);

        txtvalue.Text = Math.Round(value).ToString();
    }
    protected void txtsort_TextChanged(object sender, EventArgs e)
    {
        string sql = ("select  DISTINCT Convert(varchar(50),blend_p+'%'+blends)+'-'+Convert(varchar(50),b.fabric_desc) as construction from misdev.production.dbo.jct_warp_weft_dtl a , misdev.production.dbo.jct_fabric_dev_hdr b where a.sort_no = '"+txtsort.Text+"' and code in ( 'W','F') and a.sort_no = b.sort_no");
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtconstruction.Text = dr[0].ToString();
            }
        }
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDateTime(txtdelivdate.Text) < Convert.ToDateTime(txtjbcntrctdt.Text))
            {
                string script1 = "alert('Delivery date shoulb be greater than JobContractDate.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
                return;
            }

            sql = " jct_ops_jobwork_common_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Text;
            cmd.Parameters.Add("@jbcontractno", SqlDbType.VarChar, 130).Value = txtjbctrctno.Text;
            cmd.Parameters.Add("@jbcontractDt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtjbcntrctdt.Text);
            cmd.Parameters.Add("@JobRate", SqlDbType.VarChar, 50).Value = txtjbrate.Text;
            cmd.Parameters.Add("@jobtype", SqlDbType.VarChar, 30).Value = txtjbtype.Text;
            cmd.Parameters.Add("@nature_of_jb", SqlDbType.VarChar, 30).Value = txtnature.Text;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Sort_no", SqlDbType.VarChar, 30).Value = txtsort.Text;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = txtqty.Text; ;
            cmd.Parameters.Add("@FabRate", SqlDbType.Int).Value = txtfabrate.Text;
            cmd.Parameters.Add("@value", SqlDbType.Int).Value = txtvalue.Text;
            cmd.Parameters.Add("@Construction", SqlDbType.VarChar, 100).Value = txtconstruction.Text;
            cmd.Parameters.Add("@freight_chrg", SqlDbType.VarChar, 20).Value = ddlfreight.SelectedItem.Text;
            cmd.Parameters.Add("@Vendor", SqlDbType.VarChar, 100).Value = txtvendor.Text;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = txtdelivdate.Text;
            cmd.Parameters.Add("@Elongation_bearer", SqlDbType.VarChar, 30).Value = txtelong.Text;
            cmd.Parameters.Add("@elongation_percnt", SqlDbType.VarChar, 10).Value = ddlelong.SelectedItem.Text;
            cmd.Parameters.Add("@shrinkage_bearer ", SqlDbType.VarChar, 30).Value = ddlshrink.Text;
            cmd.Parameters.Add("@shrinkage_percnt", SqlDbType.VarChar, 10).Value = txtshrink.Text;
            cmd.Parameters.Add("@shade_no", SqlDbType.VarChar, 30).Value = txtshade.Text;
            cmd.Parameters.Add("@mkt_ref", SqlDbType.VarChar, 30).Value = txtmkt.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script2 = "alert('Record updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            lbreqid.Visible = true;
            lbid.Text = grdDetail.SelectedRow.Cells[1].Text;
            lbid.Visible = true;
 


        }
        catch (Exception ex)
        {
            string script = "alert('Please select a record !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_ops_jobwork_common_delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.ExecuteNonQuery();
            string script2 = "alert('Record deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            bindgrid();
        }
        catch(Exception ex)
        {
            string script = "alert('Please select a record !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkadd.Enabled = false;
        lbid.Text = grdDetail.SelectedRow.Cells[1].Text;
        lbid.Visible = true;
        lbreqid.Visible = true;
        ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text));
        txtjbctrctno.Text = grdDetail.SelectedRow.Cells[3].Text;
        txtjbcntrctdt.Text = grdDetail.SelectedRow.Cells[4].Text;
        txtjbrate.Text = grdDetail.SelectedRow.Cells[5].Text;

        txtjbtype.Text = grdDetail.SelectedRow.Cells[6].Text;
        txtnature.Text= grdDetail.SelectedRow.Cells[7].Text;
        txtsort.Text = grdDetail.SelectedRow.Cells[8].Text;
        txtqty.Text = grdDetail.SelectedRow.Cells[9].Text;
        txtfabrate.Text= grdDetail.SelectedRow.Cells[10].Text;
        txtvalue.Text = grdDetail.SelectedRow.Cells[11].Text;
        txtconstruction.Text = grdDetail.SelectedRow.Cells[12].Text;
        ddlfreight.SelectedIndex = ddlfreight.Items.IndexOf(ddlfreight.Items.FindByText(grdDetail.SelectedRow.Cells[13].Text));
        txtvendor.Text = grdDetail.SelectedRow.Cells[14].Text;
        txtdelivdate.Text = grdDetail.SelectedRow.Cells[15].Text;
        ddlelong.SelectedIndex = ddlelong.Items.IndexOf(ddlelong.Items.FindByText(grdDetail.SelectedRow.Cells[16].Text));
        txtelong.Text= grdDetail.SelectedRow.Cells[17].Text;
        ddlshrink.SelectedIndex = ddlshrink.Items.IndexOf(ddlshrink.Items.FindByText(grdDetail.SelectedRow.Cells[18].Text));
        txtshrink.Text = grdDetail.SelectedRow.Cells[19].Text;
       txtmkt.Text = grdDetail.SelectedRow.Cells[20].Text;
    


    }
    private void bindgrid()
    {
        //jct_ops_jobwork_common_select
        sql = "jct_ops_jobwork_common_select";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;

    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("jobwork_commn_req.aspx");
    }
    private void SendMail()
    {
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string Subject = null;
        string body = null;
        string empcode = Session["EmpCode"].ToString();
        string RequestBy_Email = string.Empty;
        string RequestBy = string.Empty;


        sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = @empcode and company_code ='JCT00LTD'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = empcode;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                RequestBy_Email = dr[0].ToString();
            }
        }
        else
        {
            RequestBy_Email = "shwetaloria@jctltd.com";
        }
        dr.Close();

        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"].ToString() + "' and active='Y'";

        try
        {
            RequestBy = obj1.FetchValue(sql).ToString();
        }
        catch { }

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");

        sb.AppendLine("Hello " + RequestBy + ",<br/><br/>");
        sb.AppendLine("Job Work Request made in system.<br/><br/>");
        sb.AppendLine("Details are :<br/><br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> RequestID </th> <th> Job Contract No </th><th> Contract Date </th> <th> Sort No </th> <th> Qty </th> <th> Nature of Job  </th> <th> Job Type </th>  <th> Job Rate</th>  <th> Fab Rate</th><th>Value</th> <th>Construction</th><th>Vendor</th><th>Elongation Bearer</th><th>Elongation Percent</th><th>Shrinkage Percent</th> <th>Delivery Dt</th><th>Freight Charges By</th></tr>");

        sql = "jct_ops_jobwork_common_select";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"];
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr> <td>  " + dr["RequestID"] + " </td> <td>  " + dr["jbcontractno"] + " </td>  <td>  " + dr["jbcontractDt"] + " </td> <td> " + dr["Sort_no"] + "</td>  <td> " + dr["Qty"] + "</td>  <td> " + dr["nature_of_jb"] + "</td>  <td> " + dr["jobtype"] + " </td><td>" + dr["JobRate"] + "</td> <td>" + dr["FabRate"] + "</td> <td>" + dr["value"] + "</td><td>" + dr["Construction"] + "</td><td>" + dr["Vendor"] + "</td><td>" + dr["Elongation_bearer"] + "</td><td>" + dr["Elongation%"] + "</td><td>" + dr["shrinkage%"] + "</td><td>" + dr["DeliveryDate"] + "</td><td>" + dr["freight_chrg"] + "</td> </tr> ");
            }
        }


        sb.AppendLine("</table>");
        sb.AppendLine("<br/><br/>");
        sb.AppendLine("This is a system generated mail, please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");

        Subject = "Outsourced Job Work Request - " + ViewState["RequestID"];


        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";
         //to = "'" +  RequestBy_Email + "'  + rajgopal@jctltd.com";
        to = "shwetaloria@jctltd.com";
        bcc = "shwetaloria@jctltd.com,jatindutta@jctltd.com,rajan@jctltd.com";
        Subject = "Outsourced Job Work Request - " + ViewState["RequestID"];
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

        mail.Subject = Subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");
        SmtpMail.Send(mail);
    }

}

