using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using System.Net.Mail;
using System.Net;
public partial class AssetMngmnt_AssetFurnitureLocMapping : System.Web.UI.Page
{
    string script = string.Empty;
    string sql = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindlocation();
            bindsublocation();
            ddlloc_SelectedIndexChanged(sender, null);
            Bindgrid();
            //CalendarExtender2.SelectedDate = Convert.ToDateTime("01/01/2050");
        }
        if (ddlloc.SelectedItem.Text == "Colony" || ddlloc.SelectedItem.Text == "colony")
        {
            ReqtxtEmpCode.Enabled = true;        
        }
        else
        {
            ReqtxtEmpCode.Enabled = false;            
        }
    }

    public void bindlocation()
    {
        SqlCommand cmd = new SqlCommand("SELECT distinct main_location FROM jct_asset_location_master WHERE STATUS='A' AND main_location IS not null and module_usedby = 'GEN'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlloc.DataSource = ds;
        ddlloc.DataTextField = "main_location";
        ddlloc.DataValueField = "main_location";
        ddlloc.DataBind();
    }

    public void bindsublocation()
    {        
        //sql = "Jct_Asset_Furdetail_Sublocation_Fetch";
        sql = "Jct_Asset_Locationmap_Sublocation_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //SqlCommand cmd = new SqlCommand("SELECT  location  FROM dbo.jct_asset_location_master where status='A' AND main_location ='" + ddlloc.SelectedItem.Text + "' ORDER BY LEFT(location,1)", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlSubloc.DataSource = ds;
        ddlSubloc.DataTextField = "location";
        ddlSubloc.DataValueField = "location";
        ddlSubloc.DataBind();
    }
    protected void lnkApply_Click(object sender, EventArgs e)
    {
        ViewState["usercode"] = null;
        ViewState["Sublocation"] = null;
        //ViewState["sr_id"] = "";

        string script = string.Empty;
        string empcode = string.Empty;
        string usercode = string.Empty;
        try
        {
            SqlCommand cmd = new SqlCommand("jct_asset_Employee_Location_map_insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 15).Value = ddlloc.SelectedItem.Text;
            cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;

            if (ddlloc.SelectedItem.Text == "Colony" || ddlloc.SelectedItem.Text == "colony")
            {
                if (txtEmpCode.Text.Contains('|'))
                {
                    empcode = txtEmpCode.Text.Split('|')[1].ToString();
                    ViewState["usercode"] = empcode.Split('~')[0].ToString();
                  
                    string empcode1 = txtEmpCode.Text.Split('|')[0].ToString();
                    cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 30).Value = empcode1.ToString();
                }
                else
                {
                    script = "alert('Invalid EmployeeCode!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }
            }

            else
            {
                if (txtEmpCode.Text.Contains('|'))
                {
                    empcode = txtEmpCode.Text.Split('|')[1].ToString();
                    ViewState["usercode"] = empcode.Split('~')[0].ToString();
                    //ViewState["Sublocation"] = ddlSubloc.SelectedItem.Text;
                    string empcode1 = txtEmpCode.Text.Split('|')[0].ToString();
                    cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 30).Value = empcode1.ToString();
                }
                else
                {
                    cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 30).Value = "";
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 30).Value = "";
                }

            }
            ViewState["Sublocation"] = ddlSubloc.SelectedItem.Text;

            cmd.Parameters.Add("@STATUS", SqlDbType.Char, 20).Value = "A";
            cmd.Parameters.Add("@Created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 100).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 100).Value = "GEN";
            cmd.Parameters.Add("@Eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrom.Text);
            cmd.Parameters.Add("@Eff_To", SqlDbType.DateTime).Value = Convert.ToDateTime("01/01/2050");
            cmd.ExecuteNonQuery();
            script = "alert('Record Mapped!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            Bindgrid();

            sendmail();
        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }

    protected void Bindgrid()
    {
        sql = "jct_asset_Employee_Location_map_fetch_All";
        //sql = "jct_asset_Employee_Location_map_fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Value;
        cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Value; 
        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "Gen";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }

    protected void lnkDel_Click(object sender, EventArgs e)
    {
        string script = string.Empty;
        string empcode = string.Empty;
        if (lblSrnoID.Text == "")
        {
            script = "alert('Please select a record to Delete.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        try
        {
            SqlCommand cmd = new SqlCommand("jct_asset_Employee_Location_map_Del", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = lblSrnoID.Text;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 15).Value = ddlloc.SelectedItem.Text;
            cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 30).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@STATUS", SqlDbType.Char, 20).Value = "D";
            cmd.Parameters.Add("@Deleted_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@Deleted_ip", SqlDbType.VarChar, 100).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 100).Value = "GEN";
            cmd.ExecuteNonQuery();
            script = "alert('Record Deleted Successfully!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            Bindgrid();
            lnkDel.Visible = false; 
            lblid.Visible = false;
            lblSrnoID.Visible = false;
        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {     
        lblSrnoID.Text = GridView1.SelectedRow.Cells[2].Text;
        ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindItemByValue(GridView1.SelectedRow.Cells[3].Text.Replace("&nbsp;", "")));
        ddlSubloc.SelectedIndex = ddlSubloc.Items.IndexOf(ddlSubloc.Items.FindItemByValue(GridView1.SelectedRow.Cells[4].Text.Replace("&nbsp;", "")));
        txtEmpCode.Text = GridView1.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        txtefffrom.Text = GridView1.SelectedRow.Cells[7].Text;
        //txtEffTo.Text = GridView1.SelectedRow.Cells[7].Text;
        lnkDel.Visible = true;
        lblid.Visible = true;
        lblSrnoID.Visible = true;
        ddlloc.Enabled = false;
        ddlSubloc.Enabled = false;
        txtEmpCode.Enabled = false;
        txtefffrom.Enabled = false;
        lnkApply.Enabled = false;
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetFurnitureLocMapping.aspx");
    }
    protected void ddlloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        bindsublocation();
        Bindgrid();
    }
    protected void ddlSubloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Bindgrid();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmployeeName"));
            //identifying the control in gridview
            ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ImgDelRows");
            //raising javascript confirmationbox whenver user clicks on link button 
            lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");
        }
    }

    protected void ImgDelRows_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;        
        //TextBox Unmapdate = (TextBox)row.FindControl("txtunmapdate");
        //var a = Unmapdate.Text;
        //DateTime UnMapDateValue = Convert.ToDateTime(Unmapdate.Text);
        int srno = Convert.ToInt32(row.Cells[2].Text);
        ViewState["sr_id"] = srno;
        string Location = row.Cells[3].Text;
        string Sublocation = row.Cells[4].Text;
        string usercode = row.Cells[5].Text;
        string EmployeeName = row.Cells[6].Text;
        DateTime eff_from = Convert.ToDateTime(row.Cells[7].Text);

        string script = string.Empty;
        string empcode = string.Empty;

        try
        {
            TextBox Unmapdate = (TextBox)row.FindControl("txtunmapdate");
            if (Unmapdate.Text != "")
            {
                DateTime UnMapDateValue = Convert.ToDateTime(Unmapdate.Text);
                SqlCommand cmd = new SqlCommand("jct_asset_Employee_Location_map_Update", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@ID", SqlDbType.Int).Value = lblSrnoID.Text;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = srno;
                //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 15).Value = Location;
                //cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = Sublocation;
                //cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 30).Value = txtEmpCode.Text;
                cmd.Parameters.Add("@STATUS", SqlDbType.Char, 20).Value = "U";
                cmd.Parameters.Add("@Updated_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 100).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 100).Value = "GEN";
                cmd.Parameters.Add("@Eff_from", SqlDbType.DateTime).Value = eff_from;
                cmd.Parameters.Add("@Eff_To", SqlDbType.DateTime).Value = UnMapDateValue;
                cmd.ExecuteNonQuery();
                //script = "alert('Record Unmapped!!');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                Bindgrid();
                //Displaying alert message after successfully deletion of user
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('" + EmployeeName + " Unmapped successfully')", true);
                sendmail();
            }
            else
            {
                script = "alert('Effective ToDate Cannot Be Empty!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
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
            string querystring1 = string.Empty;
            string querystring2 = string.Empty;

            if (ViewState["sr_id"] != null)
            {
                querystring = "sr_id=" + ViewState["sr_id"].ToString();

            }
            else if (ViewState["usercode"] != null)
            {
                querystring1 = "usercode=" + ViewState["usercode"].ToString();

            }
            else if (ViewState["Sublocation"] != null)
            {
                querystring2 = "Sublocation=" + ViewState["Sublocation"].ToString();
            }

            
            if (ViewState["sr_id"] != null)
            {
                subject = "Employee Unmapped On" + "  " + DateTime.Now;
                //url = "http://localhost:4055/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring;
                //url = "http://test2k/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring;
                url = "http://testerp/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring;
                ViewState["sr_id"] = null;
            }
            else if (ViewState["usercode"] != null)
            {
                subject = "Employee Mapped On" + " " + DateTime.Now;
                //url = "http://localhost:4055/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring1;
                //url = "http://test2k/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring1;
                url = "http://testerp/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring1;
            }
            else if (ViewState["Sublocation"] != null)
            {
                subject = "Employee Mapped On" + " " + DateTime.Now;
                //url = "http://localhost:4055/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring2;
                //url = "http://test2k/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring2;
                url = "http://testerp/FusionApps/AssetMngmnt/AssetMngtEmpMappingMail.aspx?" + querystring2;
            }

            @from = "noreply@jctltd.com";

            to = "aslam@jctltd.com,ashish@jctltd.com,shwetaloria@jctltd.com";
            //to = "aslam@jctltd.com";
            //bcc = "ashish@jctltd.com";

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
    protected void lnkViewAll_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    sql = "jct_asset_Employee_Location_map_fetch_All";
        //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Value;
        //    cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Value; 
        //    cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "Gen";
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    GridView1.DataSource = ds.Tables[0];
        //    GridView1.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //    return;
        //}
    }
}
