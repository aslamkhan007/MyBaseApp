using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Text;

public partial class AssetMngmnt_Furniture_Accept : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string location = string.Empty;
    string Sublocation = string.Empty;
    string Empcode = string.Empty;
    string usercode = string.Empty;
    string to = string.Empty;
    string from = string.Empty;
    string bcc = string.Empty;
    string cc = string.Empty;
    string subject = string.Empty;
    string body = string.Empty;
    string url = string.Empty;
    string querystring = string.Empty;
    string querystring1 = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == string.Empty)
        {
            Response.Redirect("~/login.aspx");
        }
       
        if (!IsPostBack)
        {
            Loadaction();
            
        }
    }

    public void Loadaction()
    {
        string subloc;

        ViewState["requestID"] = null;

        BindLocation();
        BindSubLocation();
     

        if (ddlSublocation.Items.Count > 0)
        {
            subloc = ddlSublocation.SelectedItem.Text;
        }
        else
        {
            subloc = string.Empty;
        }




        //sql = "Jct_Asset_Accept_GetUserRequestID";
        sql = "Jct_Asset_Accept_GetUserRequestID1";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];


        cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = subloc; // string.IsNullOrEmpty(ddlSublocation.SelectedItem.Text) : '' ? ddlSublocation.SelectedItem.Text ;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddllocation.SelectedItem.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["requestID"] = dr[0].ToString();
            }
        }
        dr.Close();

        if (ViewState["requestID"] != null)
        {

            BindRecordStatus();
            BindGetUsers();

            sql = "Jct_Asset_Accept_RequestId_Header";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState["requestID"];
            cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Location.Text = dr["Location"].ToString();
                    //Sublocation.Text = dr["Sublocation"].ToString();

                    ddllocation.SelectedItem.Text = dr["Location"].ToString();
                    ddlSublocation.SelectedItem.Text = dr["Sublocation"].ToString();
                    Department.Text = dr["Department"].ToString();
                    EmployeeCode.Text = dr["UserCode"].ToString();
                    IssuedTo.Text = dr["UserName"].ToString();
                    RequestId.Text = dr["RequestId"].ToString();
                }
            }
            else
            {
                string script = "alert(No data available!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            dr.Close();
            BindItemListGridview();
        }
        else
        {
            //string script = "alert(This User Has Not Been Maaped In System !!');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                if (ddllocation.Items.Count == 1)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "You are not Authorized . Please Contact Admin for any Query";
            }


        }
    }

    public void SelectedIndexaction()
    {
        ViewState["requestID"] = null;
        string subloc;
        if (ddlSublocation.Items.Count > 0)
        {
            subloc = ddlSublocation.SelectedItem.Text;
        }
        else
        {
            subloc = string.Empty;
        }


        //sql = "Jct_Asset_Accept_GetUserRequestID";
        sql = "Jct_Asset_Accept_GetUserRequestID1";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
        //cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = ddlSublocation.SelectedItem.Text;
        cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = subloc;
        
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddllocation.SelectedItem.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["requestID"] = dr[0].ToString();
            }
        }
        dr.Close();

        if (ViewState["requestID"] != null)
        {

            BindRecordStatus();
            BindGetUsers();

            sql = "Jct_Asset_Accept_RequestId_Header";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState["requestID"];
            cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Location.Text = dr["Location"].ToString();
                    //Sublocation.Text = dr["Sublocation"].ToString();

                    ddllocation.SelectedItem.Text = dr["Location"].ToString();
                    ddlSublocation.SelectedItem.Text = dr["Sublocation"].ToString();
                    Department.Text = dr["Department"].ToString();
                    EmployeeCode.Text = dr["UserCode"].ToString();
                    IssuedTo.Text = dr["UserName"].ToString();
                    RequestId.Text = dr["RequestId"].ToString();
                }
            }
            else
            {
                string script = "alert(No data available!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            dr.Close();
            BindItemListGridview();
        }
        else
        {


                DataList1.DataSource = null;
                DataList1.DataBind();
                GrdRecordstatus.DataSource = null;
                GrdRecordstatus.DataBind();
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblMessage.Visible = true;
                lblMessage.Text = "You are not Authorized . Please Contact Admin for any Query";
            

            //string script = "alert(This User Has Not Been Maaped In System !!');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);


        }
    }



    public void BindLocation()
    {
        sql = "Jct_Asset_Accept_GetUserLocation";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddllocation.DataSource = ds;
        ddllocation.DataTextField = "Location";
        ddllocation.DataValueField = "Location";
        ddllocation.DataBind();
    }


    public void BindSubLocation()
    {
        sql = "Jct_Asset_Accept_GetUserSublocation";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddllocation.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlSublocation.DataSource = ds;
        ddlSublocation.DataTextField = "Sublocation";
        ddlSublocation.DataValueField = "Sublocation";
        ddlSublocation.DataBind();
    }

    public void BindItemListGridview()
    {
        sql = "Jct_Asset_Accept_Fetch_GridDetail";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Request_id", SqlDbType.VarChar, 50).Value = ViewState["requestID"];
        //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = Location.Text;
        //cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 50).Value = Sublocation.Text;

        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddllocation.SelectedItem.Text;
        cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 50).Value = ddlSublocation.SelectedItem.Text;

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();    
    }

    public void BindRecordStatus()
    {
        sql = "Jct_Asset_Accept_RecordStatus";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState["requestID"];
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        GrdRecordstatus.DataSource = ds;
        GrdRecordstatus.DataBind();        
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView gv = (GridView)e.Item.FindControl("GridAccepted");
            Label Username = (Label)e.Item.FindControl("LabeUserName");
            Label lbh = (Label)e.Item.FindControl("Labelhead");
                                  
            if (gv != null)
            {                
                string  qry = "Jct_Asset_ItemWise_Total_vs_Accepted_qty_List";
                SqlCommand cmd = new SqlCommand(qry, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Request_id", SqlDbType.Int).Value = ViewState["requestID"];
                cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = lbh.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.DataSource = ds.Tables[0];
                gv.DataBind();

            }
        }
    }

    public void BindGetUsers()
    {
        SqlCommand cmd = new SqlCommand("Jct_Asset_Accept_GetUsers", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Request_id", SqlDbType.Int).Value = ViewState["requestID"];
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        DataList1.DataSource = dt;
        DataList1.DataBind();             
    }

    protected void lnkaccept_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        SqlTransaction tran;
        tran = obj.Connection().BeginTransaction();
        try
        {
            string OK = string.Empty;
            foreach (GridViewRow gvRow1 in GridView1.Rows)
            {
                CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chkRemove"); 
                if (chkRemove1.Checked == true)
                {
                    OK = "OK";
                }
            }

            if (OK == "OK")
            {
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
                    RadNumericTextBox AcceptedNo = (RadNumericTextBox)gvRow.FindControl("txtNoOfItems");
                    TextBox Remarks = (TextBox)gvRow.FindControl("txtRemarks");
                    //Label TransNo = (Label)gvRow.FindControl("lblTransNo");
                    Label SrNo = (Label)gvRow.FindControl("lblSrNo");
                    
                    Label Location = (Label)gvRow.FindControl("lblLocation");
                    Label Sublocation = (Label)gvRow.FindControl("lblSubLocation");

                    

                    HiddenField asset_id = (HiddenField)gvRow.FindControl("H1asset_id");
                    HiddenField H1item_desc_value = (HiddenField)gvRow.FindControl("H1item_desc_value");
                    Label asset_type_id = (Label)gvRow.FindControl("lblAssetType");
                    Label ItemDescription = (Label)gvRow.FindControl("lblItemDescription");
             

                    //Label AcceptedQty = (Label)gvRow.FindControl("lblAcceptedQty");                    
                    //Label PendingQty = (Label)gvRow.FindControl("lblPendingQty");

                    Label ManufactureName = (Label)gvRow.FindControl("lblManufacturer");
                    HiddenField H1manufacture = (HiddenField)gvRow.FindControl("manufactureId");
                                      

                    if (chkRemove.Checked == true)
                    {
                        cmd = new SqlCommand("Jct_Asset_Accept_Insert_GridDetail", obj.Connection(), tran);
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = Convert.ToInt16(RequestId.Value);
                        cmd.Parameters.Add("@requestID", SqlDbType.Int).Value = ViewState["requestID"];
                        cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
                        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = Location.Text;
                        cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 50).Value = Sublocation.Text;
                        //cmd.Parameters.Add("@SrNo", SqlDbType.Int).Value = SrNo.Text;



                        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = asset_id.Value;
                        cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = asset_type_id.ToolTip;
                        cmd.Parameters.Add("@item_desc_id", SqlDbType.Int).Value = ItemDescription.ToolTip;
                        cmd.Parameters.Add("@item_desc_value", SqlDbType.Int).Value = H1item_desc_value.Value;
                        cmd.Parameters.Add("@manufacture", SqlDbType.Int).Value = ManufactureName.ToolTip;
                        cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = asset_type_id.Text;
                        cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 200).Value = ItemDescription.Text;



                        cmd.Parameters.Add("@Items_Accepted_No", SqlDbType.Int).Value = Convert.ToInt16(AcceptedNo.Text);
                        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = Remarks.Text;
                        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                        cmd.ExecuteNonQuery();
                        string script = "alert('Items Accepted Successfully !!!!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
                tran.Commit();
                sendmail(Empcode);

            }
            else
            {
                string script2 = "alert('Please Check The Items And Accept!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }
            BindGetUsers();
            BindRecordStatus();
            BindItemListGridview();
        }

        catch (Exception ex)
        {
            tran.Rollback();
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {       
            RadNumericTextBox txtbox = (RadNumericTextBox)e.Row.FindControl("txtNoOfItems");

            sql = "Jct_Asset_Accept_disable_Textbox";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = ddlSublocation.SelectedItem.Text;
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1 != null)
            {
                var a = Convert.ToInt16(ds1.Tables[0].Rows[0][0].ToString());
                //var a = ds1.Tables.[0]["result"];
                if (a > 1)
                {
                    txtbox.Enabled = true;
                }
            }
          

            GridView InnerGridview = e.Row.FindControl("InnerGridview") as GridView;
            Label asset_type_id = (Label)e.Row.FindControl("lblAssetType");

            Label ItemDescription = (Label)e.Row.FindControl("lblItemDescription");
            HiddenField H1item_desc_value = (HiddenField)e.Row.FindControl("H1item_desc_value");
            Label ManufactureName = (Label)e.Row.FindControl("lblManufacturer");
                                    
            cmd = new SqlCommand("Jct_Asset_Accept_Fetch_GridDetail_AllocationDateWise", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Request_id", SqlDbType.Int).Value = ViewState["requestID"];
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddllocation.SelectedItem.Text;
            cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 60).Value = ddlSublocation.SelectedItem.Text;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = asset_type_id.ToolTip;


            cmd.Parameters.Add("@item_desc_id", SqlDbType.Int).Value = ItemDescription.ToolTip;
            cmd.Parameters.Add("@item_desc_value", SqlDbType.Int).Value = H1item_desc_value.Value;
            cmd.Parameters.Add("@manufacture", SqlDbType.Int).Value = ManufactureName.ToolTip;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            InnerGridview.DataSource = ds;
            InnerGridview.DataBind();




            // for enable disable validation
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
    protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        BindSubLocation();
        SelectedIndexaction();
    }

    private void sendmail(string UserCode)
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

            int emailid = 0;
            sql = "Select a.empname,b.e_mailid as email from  jct_empmast_base a left outer join  mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
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
                    ViewState["RequestByEmail"] = "aslam@jctltd.com,ashish@jctltd.com,kamal@jctltd.com";
                    Body = "<html><body><Table><tr><td>The Following User</td></tr><BR /><tr><td>EmployeeCode " + UserCode + "</td></tr><BR /><tr><td>EmployeeName : " + ds.Tables[0].Rows[0]["empname"].ToString() + " </td> </tr><BR /><tr><td>Location : " + location + "</td></tr><Br/><tr><td>Sublocation: " + Sublocation + "</td></tr><Br/>  <tr><td>Does Not Have Email Id</td></table></body></html>";
                    to = "ashish@jctltd.com";
                }
                else if (emailid == 1)
                {
                    ViewState["RequestBy"] = ds.Tables[0].Rows[0]["empname"].ToString();
                    ViewState["RequestByEmail"] = ds.Tables[0].Rows[0]["email"].ToString();
                    querystring = "requestid=" + ViewState["requestID"]; 
                    querystring1 = Session["Empcode"].ToString();
                    //url = "http://test2k/FusionApps/AssetMngmnt/asset_accept_AcceptedMail.aspx?" + querystring + "&Empcode=" + querystring1;
                    //url = "http://localhost:1733/FusionApps/AssetMngmnt/asset_accept_AcceptedMail.aspx?" + querystring + "&Empcode=" + querystring1;
                    url = "http://testerp/FusionApps/AssetMngmnt/asset_accept_AcceptedMail.aspx?" + querystring + "&Empcode=" + querystring1;
                    Body = GetPage(url);
                    to = ViewState["RequestByEmail"].ToString();

                }
                else if (emailid > 1)
                {
                    ViewState["RequestBy"] = usercode;
                    ViewState["RequestByEmail"] = "aslam@jctltd.com,ashish@jctltd.com";
                    Body = "<html><body><Table><tr><td>The Following User</td></tr><BR /><tr><td>EmployeeCode " + UserCode + "</td></tr><BR /><tr><td>EmployeeName : " + ds.Tables[0].Rows[0]["empname"].ToString() + " </td> </tr><BR /><tr><td>Location : " + location + "</td></tr><Br/><tr><td>Sublocation: " + Sublocation + "</td></tr><Br/>  <tr><td>Does Not Have Email Id</td></table></body></html>";
                    to = "ashish@jctltd.com";
                }
            }

            @from = "noreply@jctltd.com";

            //subject = "Furniture Asset Acceptance" + " " + to;
            subject = "Furniture Asset Acceptance";
            bcc = "aslam@jctltd.com,ashish@jctltd.com";
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
            string script = "alert('Mail  Sent!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            obj.ConClose();
            BindGetUsers();
            BindRecordStatus();
            BindItemListGridview();
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
    protected void GrdRecordstatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkresest_Click(object sender, EventArgs e)
    {
        Response.Redirect("Furniture_Accept.aspx");
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

    protected void chkRemoveALL_CheckedChanged(object sender, EventArgs e)
    {
        if (DataControlRowType.DataRow == DataControlRowType.DataRow)
        {
            CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("chkRemoveALL");
            foreach (GridViewRow row in GridView1.Rows)
            {                
                CheckBox checkbox = (CheckBox)row.FindControl("chkRemove");
                if (ChkBoxHeader.Checked == true)
                {
                    checkbox.Checked = true;
                }
                else
                {
                    checkbox.Checked = false;
                }
            }
           
        }
    }
    protected void lnkRaiseConcern_Click(object sender, EventArgs e)
    {

        string OK = string.Empty;
        foreach (GridViewRow gvRow1 in GridView1.Rows)
        {
            CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chkRemove");
            if (chkRemove1.Checked == true)
            {
                OK = "OK";
            }
        }

        if (OK == "OK")
        {

            try
            {
               
                string sql = string.Empty;
                string to = string.Empty;               
                string bcc = string.Empty;
                string cc = string.Empty;
                string subject = string.Empty;
                string body = string.Empty;
                string url = string.Empty;
                string querystring = string.Empty;
                string usercode = string.Empty;
                string querystring1 = string.Empty;
                string querystring2 = string.Empty;

                string @from = string.Empty;
                StringBuilder sb = new StringBuilder();
                @from = "noreply@jctltd.com";
                SqlDataAdapter da = default(SqlDataAdapter);
                DataTable Dt = new DataTable();

                //bcc = "aslam@jctltd.com";
                bcc = "aslam@jctltd.com,ashish@jctltd.com,rbaksshi@jctltd.com";

                MailMessage mail = new MailMessage();

                sb.AppendLine("<html>");
                sb.AppendLine("<br/><br/>");
                sb.AppendLine("Dear User<br/> <br/>");
                sb.AppendLine("You Have Raised Concern Over Following Furniture Asset Items..<br/> <br/>");


                sb.AppendLine(": <br/><br/>");
                sb.AppendLine("<head>");
                sb.AppendLine("<style type=\"text/css\">");
                sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
                sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
                sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
                sb.AppendLine("</style>");
                sb.AppendLine("</head>");

                sb.AppendLine("<table class=gridtable>");
                string GridHeader = "";
                string Q = "";
                Int16 J = 0;
                string body1 = "";
                var _with1 = GridView1;
                //int k = 0;

                for (int k = 0; k <= GridView1.Rows.Count - 1 ; k++)
                {                    
                    CheckBox chkRemove = (CheckBox)GridView1.Rows[k].FindControl("chkRemove");                    
                    Label SrNo = (Label)GridView1.Rows[k].FindControl("lblSrNo");
                    Label Location = (Label)GridView1.Rows[k].FindControl("lblLocation");
                    Label Sublocation = (Label)GridView1.Rows[k].FindControl("lblSubLocation");
                    Label asset_type_id = (Label)GridView1.Rows[k].FindControl("lblAssetType");
                    Label ItemDescription = (Label)GridView1.Rows[k].FindControl("lblItemDescription");
                    Label TotalQty = (Label)GridView1.Rows[k].FindControl("lblTotalQty");
                    Label AcceptedQty = (Label)GridView1.Rows[k].FindControl("lblAcceptedQty");
                    Label PendingQty = (Label)GridView1.Rows[k].FindControl("lblPendingQty");
                    Label ManufactureName = (Label)GridView1.Rows[k].FindControl("lblManufacturer");
                    RadNumericTextBox AcceptedNo = (RadNumericTextBox)GridView1.Rows[k].FindControl("txtNoOfItems");
                    TextBox Remarks = (TextBox)GridView1.Rows[k].FindControl("txtRemarks");                     

                        Q = "<tr>";
                        //This if is used to Fetch Header from Gridview
                        if (k == 0)
                        {
                            for (J = 0; J <= GridView1.Columns.Count - 1; J++)
                            {
                                GridHeader += "<th> " + _with1.HeaderRow.Cells[J].Text + "</th>";
                            }
                            body1 = body1 + GridHeader + " </tr>";
                        }

                        if (chkRemove.Checked == true)
                        {
                            if (string.IsNullOrEmpty(Remarks.Text))
                            {                                
                                throw new Exception("Remarks Cannot Be Empty!!");
                            }

                            Q += "<td>" + "" + "</td>" + "<td>" + SrNo.Text + "</td>" + "<td>" + Location.Text + "</td>" + "<td>" + Sublocation.Text + "</td>" + "<td>" + asset_type_id.Text + "</td>" + "<td>" + ItemDescription.Text + "</td>" + "<td>" + TotalQty.Text + "</td>" + "<td>" + AcceptedQty.Text + "</td>" + "<td>" + PendingQty.Text + "</td>" + "<td>" + ManufactureName.Text + "</td>" + "<td>" + AcceptedNo.Text + "</td>" + "<td>" + Remarks.Text + "</td>";

                            body1 = body1 + Q + " </tr>";
                        }
                    
                    
                }




                string Genratedby_Email = string.Empty;
                string  qry = "SELECT E_MailID FROM  mistel  WHERE  empcode  = '" + Session["EmpCode"].ToString() + "' ";
                SqlCommand cmd = new SqlCommand(qry, obj.Connection());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        Genratedby_Email = dr[0].ToString();
                    }
                }
                dr.Close();



                sb.AppendLine("" + body1);

                mail.Body = sb.ToString();

                //string Body = GetPage(url);       
                mail.From = new MailAddress(@from);
                to = "aslam@jctltd.com" + "," + Genratedby_Email; 
                //to = too;

                bcc = "aslam@jctltd.com";
                //bcc = bccc;

                cc = "ashish@jctltd.com";
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

                mail.Subject = "Raise Concern Mail";

                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpClient SmtpMail = new SmtpClient("exchange2k7");

                SmtpMail.Send(mail);
                string script = "alert('Your Asset Regarding Concern sucessfully raised!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                
            }


            catch (Exception ex)
            {
                string Scrpt = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
            }
        }
        else
        {
            string script2 = "alert('Please Check The Items And Then Raise Concern!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }
    }
                                    
       
}