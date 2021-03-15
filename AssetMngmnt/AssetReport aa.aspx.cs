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


public partial class AssetManagment_AssetReport : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    GridView gv = new GridView();

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    SqlConnection conJctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);


    protected override void OnPreRender(EventArgs e)
    {
        //The following line is required, otherwise you get "Extender controls
        //may not be registered before PreRender."
        base.OnPreRender(e);

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (this.DesignMode == true)
        {
            this.EnsureChildControls();
        }
        this.Page.RegisterRequiresControlState(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == string.Empty)
        {
            Response.Redirect("~/login.aspx");
        }
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        bindgrid();

    }

    protected void ddlAssetType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //RadComboBox AssetType = (RadComboBox)sender;
        //GridViewRow gridRow = (GridViewRow)AssetType.Parent.Parent;

        //RadComboBox AssetCatg = (RadComboBox)gridRow.FindControl("ddlAssetCatg");
        //SqlDataSource sqlDs = (SqlDataSource)gridRow.FindControl("SqlDataSource2");

        ddlAssetCatg.DataSource = null;
        ddlAssetCatg.DataBind();
        SqlDataSource2.SelectParameters["ASSET_ID"].DefaultValue = ddlAssetType.SelectedValue;
        ddlAssetCatg.DataBind();
    }

    protected void ddlAssetCatg_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //RadComboBox AssetCatg = (RadComboBox)sender;
        //GridViewRow gridRow = (GridViewRow)AssetCatg.Parent.Parent;

        //RadComboBox ItemDesc = (RadComboBox)gridRow.FindControl("ddlItemDesc");
        //SqlDataSource sqlDs = (SqlDataSource)gridRow.FindControl("SqlDataSource");

        SqlDataSource4.SelectParameters["ASSET_TYPE_ID"].DefaultValue = ddlAssetCatg.SelectedValue;
        ddlItemDesc.DataBind();
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string requestid = grdDetail.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView grdDetailchild = e.Row.FindControl("nestedGridView") as GridView;
            string asset_name = e.Row.Cells[5].Text;

            if (asset_name != "Printer" && asset_name != "Scanner" && asset_name != "Conference Phone")
            {
                //sql = "SELECT asset_type_name,item_desc,asset_id,asset_type_id FROM  dbo.jct_asset_type_item_detail WHERE request_id= " + requestid + " AND status='A'";
                sql = "SELECT asset_type_name,item_desc,asset_id,asset_type_id FROM  dbo.jct_asset_type_item_detail WHERE request_id= " + requestid + " AND status='A' union select asset_type as asset_type_name,case when printer_type is null then  description else printer_type end as item_desc,asset_id,asset_type_id as asset_type_id from jct_asset_printer_scanner_network where status='A' and jct_machine_id=(SELECT jctsr_no FROM  dbo.jct_asset_item_details WHERE item_id= " + requestid + " AND status='A')";
                SqlCommand cmd = new SqlCommand(sql, con);
                //con.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                grdDetailchild.DataSource = ds.Tables[0];
                grdDetailchild.DataBind();
                //con.Close();
            }
            else
            {
                e.Row.Cells[0].Enabled = false;
                e.Row.Cells[1].Enabled = false;
                e.Row.Cells[2].Enabled = false;
                e.Row.Cells[3].Enabled = false;

            }

        }
    }

    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=AssetReport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gv.AllowPaging = false;
            this.bindgrid();

            gv.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gv.HeaderRow.Cells)
            {
                cell.BackColor = gv.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gv.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gv.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gv.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gv.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    //protected void lnkExcel_Click(object sender, EventArgs e)
    //{
    //    SqlCommand cmd = new SqlCommand("jct_ops_asset_report", conJctgen);
    //    conJctgen.Open();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    //cmd.Parameters.Add("@dept", SqlDbType.VarChar, 100).Value = ddldept.SelectedValue;
    //    //cmd.Parameters.Add("@jctSR_NO", SqlDbType.VarChar, 100).Value = txtsrno.Text;
    //    //cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = txtcompname.Text;
    //    //cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 100).Value = txtempcode.Text;
    //    //cmd.Parameters.Add("@shared", SqlDbType.VarChar, 100).Value = ddlshared.SelectedItem.Text;
    //    //cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 100).Value = txtitemname.Text;
    //    //cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 100).Value = ddlAssetType.SelectedValue;
    //    //cmd.Parameters.Add("@asset_state", SqlDbType.VarChar, 100).Value = ddlassetstae.SelectedValue;
    //    //cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 10).Value = ddlmanufacturer.SelectedValue;
    //    //cmd.Parameters.Add("@modelno", SqlDbType.VarChar, 10).Value = txtmodelno.Text;
    //    //cmd.Parameters.Add("@asset_id", SqlDbType.VarChar, 20).Value = ddlAssetType.SelectedValue;
    //    //cmd.Parameters.Add("@asset_type_id", SqlDbType.VarChar, 20).Value = ddlAssetCatg.SelectedValue;
    //    //if (!string.IsNullOrEmpty(ddlComputerType.SelectedItem.Text))
    //    //{
    //    //    cmd.Parameters.Add("@computer_type", SqlDbType.VarChar, 30).Value = ddlComputerType.SelectedItem.Value;
    //    //}
    //    //cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 50).Value = ddlItemDesc.SelectedItem.Text;

    //    if (!string.IsNullOrEmpty(ddldept.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@dept", SqlDbType.VarChar, 100).Value = ddldept.SelectedValue;
    //    }

    //    cmd.Parameters.Add("@jctSR_NO", SqlDbType.VarChar, 100).Value = txtsrno.Text;
    //    cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = txtcompname.Text;
    //    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 100).Value = txtempcode.Text;

    //    if (!string.IsNullOrEmpty(ddlshared.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@shared", SqlDbType.VarChar, 100).Value = ddlshared.SelectedItem.Text;
    //    }


    //    cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 100).Value = txtitemname.Text;

    //    if (!string.IsNullOrEmpty(ddlAssetType.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 100).Value = ddlAssetType.SelectedValue;
    //    }
    //    if (!string.IsNullOrEmpty(ddlassetstae.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@asset_state", SqlDbType.VarChar, 100).Value = ddlassetstae.SelectedValue;
    //    }
    //    if (!string.IsNullOrEmpty(ddlmanufacturer.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 10).Value = ddlmanufacturer.SelectedValue;
    //    }


    //    cmd.Parameters.Add("@modelno", SqlDbType.VarChar, 10).Value = txtmodelno.Text;

    //    if (!string.IsNullOrEmpty(ddlAssetType.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@asset_id", SqlDbType.VarChar, 20).Value = ddlAssetType.SelectedValue;
    //    }

    //    if (!string.IsNullOrEmpty(ddlAssetCatg.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@asset_type_id", SqlDbType.VarChar, 20).Value = ddlAssetCatg.SelectedValue;
    //    }

    //    if (ddlItemDesc.Items.Count > 0)
    //    {
    //        if (!string.IsNullOrEmpty(ddlItemDesc.SelectedItem.Text))
    //        {
    //            cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 100).Value = ddlItemDesc.SelectedItem.Text;
    //        }
    //    }


    //    if (!string.IsNullOrEmpty(ddlCapitalItem.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@capital_item", SqlDbType.VarChar, 20).Value = ddlCapitalItem.SelectedItem.Value;
    //    }
    //    if (!string.IsNullOrEmpty(ddlComputerType.SelectedItem.Text))
    //    {
    //        cmd.Parameters.Add("@computer_type", SqlDbType.VarChar, 30).Value = ddlComputerType.SelectedItem.Value;
    //    }

    //    cmd.ExecuteNonQuery();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    grdDetail.DataSource = ds.Tables[0];
    //    grdDetail.DataBind();

    //    DataTable dt = ds.Tables[0];
    //    string attachment = "attachment; AssetReport.xls";
    //    Response.ClearContent();
    //    Response.AddHeader("content-disposition", attachment);
    //    Response.ContentType = "application/vnd.ms-excel";
    //    string tab = "";
    //    foreach (DataColumn dc in dt.Columns)
    //    {
    //        Response.Write(tab + dc.ColumnName);
    //        tab = "\t";
    //    }

    //    Response.Write("\n");
    //    int i;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        tab = "";
    //        for (i = 0; i < dt.Columns.Count; i++)
    //        {
    //            Response.Write(tab + dr[i].ToString());
    //            tab = "\t";
    //        }
    //        Response.Write("\n");
    //    }
    //    Response.End();

    //}

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
           
            if (e.CommandName == "Delete")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = (int)gvr.RowIndex;
                //int requestid = (int)this.grdDetail.DataKeys[rowIndex][0];

                SqlCommand cmd = new SqlCommand("jct_asset_item_details_delete", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 100).Value = grdDetail.DataKeys[rowIndex][0].ToString(); //requestid;
                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 100).Value = Session["EmpCode"];
                cmd.ExecuteNonQuery();
                con.Close();
                string script = "alert('Record Deleted!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                bindgrid();
            }


            if (e.CommandName == "Sendmail")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = (int)gvr.RowIndex;

                //int requestid = (int)this.grdDetail.DataKeys[rowIndex][0];

                int id = int.Parse(e.CommandArgument.ToString());
                //GridViewRow row = grdValidations.Rows[];

                LinkButton name = (LinkButton)gvr.FindControl("lnkemail");
                if(Session["EmpCode"]=="k-02064")
                {
                    name.Enabled = true;
                }
                


                ViewState["RequestiD"] = grdDetail.DataKeys[rowIndex][0].ToString(); //requestid;
                sendmail();

            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('Error!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }
    }

    private void bindgrid()
    {

        SqlCommand cmd = new SqlCommand("jct_ops_asset_report", conJctgen);
        conJctgen.Open();
        cmd.CommandType = CommandType.StoredProcedure;

        if (!string.IsNullOrEmpty(ddldept.SelectedItem.Text))
        {
            cmd.Parameters.Add("@dept", SqlDbType.VarChar, 100).Value = ddldept.SelectedItem.Text;
        }
        if (!string.IsNullOrEmpty(txtsrno.Text))
        {
            cmd.Parameters.Add("@jctSR_NO", SqlDbType.VarChar, 100).Value = txtsrno.Text;
        }
        if (!string.IsNullOrEmpty(txtcompname.Text))
        {
            cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = txtcompname.Text;
        }
        if (!string.IsNullOrEmpty(txtempcode.Text))
        {
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 100).Value = txtempcode.Text;
        }
        if (!string.IsNullOrEmpty(ddlshared.SelectedItem.Text))
        {
            cmd.Parameters.Add("@shared", SqlDbType.VarChar, 100).Value = ddlshared.SelectedItem.Text;
        }

        if (!string.IsNullOrEmpty(txtitemname.Text))
        {
            cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 100).Value = txtitemname.Text;
        }

        if (!string.IsNullOrEmpty(ddlAssetType.SelectedItem.Text))
        {
            cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 100).Value = ddlAssetType.SelectedValue;
        }
        if (!string.IsNullOrEmpty(ddlassetstae.SelectedItem.Text))
        {
            cmd.Parameters.Add("@asset_state", SqlDbType.VarChar, 100).Value = ddlassetstae.SelectedValue;
        }
        if (!string.IsNullOrEmpty(ddlmanufacturer.SelectedItem.Text))
        {
            cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 10).Value = ddlmanufacturer.SelectedValue;
        }

        if (!string.IsNullOrEmpty(txtmodelno.Text))
        {
            cmd.Parameters.Add("@modelno", SqlDbType.VarChar, 10).Value = txtmodelno.Text;
        }
        if (!string.IsNullOrEmpty(ddlAssetType.SelectedItem.Text))
        {
            cmd.Parameters.Add("@asset_id", SqlDbType.VarChar, 20).Value = ddlAssetType.SelectedValue;
        }

        if (!string.IsNullOrEmpty(ddlAssetCatg.SelectedItem.Text))
        {
            cmd.Parameters.Add("@asset_type_id", SqlDbType.VarChar, 20).Value = ddlAssetCatg.SelectedValue;
        }

        if (ddlItemDesc.Items.Count > 0)
        {
            if (!string.IsNullOrEmpty(ddlItemDesc.SelectedItem.Text))
            {
                cmd.Parameters.Add("@item_desc", SqlDbType.Int).Value = ddlItemDesc.SelectedItem.Value;
            }
        }
        if (!string.IsNullOrEmpty(ddlCapitalItem.SelectedItem.Text))
        {
            cmd.Parameters.Add("@capital_item", SqlDbType.VarChar, 20).Value = ddlCapitalItem.SelectedItem.Value;
        }
        if (!string.IsNullOrEmpty(ddlComputerType.SelectedItem.Text))
        {
            cmd.Parameters.Add("@computer_type", SqlDbType.VarChar, 30).Value = ddlComputerType.SelectedItem.Value;
        }


        if (txtFrom.SelectedDate != null)
        {
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtFrom.SelectedDate.Value;
        }

        if (txtFrom.SelectedDate != null)
        {
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtTo.SelectedDate.Value;
        }

        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        grdDetail.DataSource = null;
        grdDetail.DataBind();

        if (ds.Tables.Count > 0)
        {
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();

            gv.DataSource = ds.Tables[0];
            gv.DataBind();
        }

        con.Close();

    }

    protected void grdDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void lnkApproval_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "update jct_asset_item_details set display='Y',display_to='" + txtempcode.Text + "' where jctsr_no='" + txtsrno.Text + "' and status='A'";
            obj1.UpdateRecord(sql);

            string script = "alert('Record activated.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('Error occured. Unable to process.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        finally
        {

        }
    }

    protected void txtempcode_TextChanged(object sender, EventArgs e)
    {
        txtempcode.Text = txtempcode.Text.Split('~')[0].ToString().Split('|')[1].ToString();
    }

    protected void lnkmail_Click(object sender, EventArgs e)
    {

    }




    private void sendmail()
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


            sql = ("SELECT usercode FROM dbo.jct_asset_item_details WHERE item_id= '" + ViewState["RequestiD"] + "' AND status='A' and module_usedby='MIS'");
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

           
            sql = "Select a.empname,b.e_mailid as email from  misdev.jctdev.dbo.jct_empmast_base a left outer join  misdev.jctdev.dbo.mistel b on a.empcode=b.empcode where a.empcode='" + usercode + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    ViewState["RequestBy"] = Dr["empname"].ToString();
                    ViewState["RequestByEmail"] = Dr["email"].ToString();
                }
            }
            else
            {
                ViewState["RequestBy"] = "";
                ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
            }

            Dr.Close();
      

            subject = "PC Configurations";// + lblBudgetID.Text;// ddlsubdept.SelectedItem.Value;//ViewState["budgetID"];
            //querystring = "RequestID=" + ViewState["RequestID"];
            querystring = "requestid=" + ViewState["RequestiD"];
            url = "http://localhost:4052/FusionApps/OPS/MailContentPages/asset_sendmail_new.aspx?" + querystring;
            // url = "http://test2k/FusionApps/OPS/MailContentPages/asset_sendmail_new.aspx?" + querystring;

           //  url = "http://misdev/FusionApps/OPS/MailContentPages/asset_sendmail_new.aspx?" + querystring;

            @from = "it.helpdesk@jctltd.com";

            to = ViewState["RequestByEmail"].ToString();

            bcc = "shwetaloria@jctltd.com,it.helpdesk@jctltd.com";

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


    protected void lnkemail_Click(object sender, EventArgs e)
    {

    }
}