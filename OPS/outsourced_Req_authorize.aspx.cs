using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using System.Reflection;
using System.Net;

public partial class OPS_outsourced_Req_authorize : System.Web.UI.Page
{
    Functions objFun = new Functions();
    Connection obj = new Connection();
    SqlConnection con=new SqlConnection();
    bool color = false;

    SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            string AreaName = "";
            string qry = "";

            if ((string.IsNullOrEmpty(Request.QueryString["AreaName"]) == false))
            {
                AreaName = Request.QueryString["AreaName"];
                GrdSanctionNoteDetail.DataSource = null;
                GrdSanctionNoteDetail.DataBind();
                //qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "' and a.UserCode='" & Session("Empcode") & "'"
                qry = "Jct_Ops_Pending_Authorization_Fetch '" + Session["Empcode"] + "','" + AreaName + "'";
                objFun.FillGrid(qry, ref GridView1);

                // remove query string value

                PropertyInfo isreadonly =
                  typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                  "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove("AreaName");
            }
        }
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
  
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            string AreaName = "";
            GrdSanctionNoteDetail.DataSource = null;
            GrdSanctionNoteDetail.DataBind();

            if ((string.IsNullOrEmpty(Request.QueryString["AreaName"]) == false) || AreaName == "JobWork")
            {
                AreaName = Request.QueryString["AreaName"];

                if (string.IsNullOrEmpty(Request.QueryString["AreaName"]) == true)
                {
                    AreaName = ((LinkButton)e.Item.FindControl("cmdArea")).Text;
                }

                GrdSanctionNoteDetail.DataSource = null;
                GrdSanctionNoteDetail.DataBind();
                 
                string qry = "Jct_Ops_Pending_Authorization_Fetch '" + Session["Empcode"] + "','" + AreaName + "'";

                objFun.FillGrid(qry, ref GridView1);
                objFun.FillGrid(qry, ref GridView1);
 
                GrdAuthHistory.DataSource = null;
                GrdAuthHistory.DataBind();

                Request.QueryString.Clear();

            }
            else
            {
                if (e.CommandName == "Select")
                {
                    AreaName = ((LinkButton)e.Item.FindControl("cmdArea")).Text;
                    if (!string.IsNullOrEmpty(AreaName) & AreaName != "Greigh Transfer" & AreaName != "ODS Request")
                    {
                        Response.Redirect("AuthorizeSanction_Note.aspx?AreaName=" + AreaName);
                    //    GridView1.DataSource = null;
                    //    GridView1.DataBind();
                    //    GridView1.SelectedIndex = -1;
                    //    GrdSanctionNoteDetail.DataSource = null;
                    //    GrdSanctionNoteDetail.DataBind();
                      
                    //    string qry = "Jct_Ops_Pending_Authorization_Fetch '" + Session["Empcode"] + "','" + AreaName + "'";
                    //    objFun.FillGrid(qry, ref GridView1);
                    }
                    else if (AreaName == "ODS Request")
                    {
                        Response.Redirect("ODS_Costing_Auth.aspx");
                    }
                    else
                    {
                        Response.Redirect("AuthorizeSanctionNote10.aspx");
                    }
                }

            }

        }
        catch  
        {

        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            string qry;
            string sql;
            objFun = new Functions();
            obj = new Connection();

            if (GridView1.SelectedRow.Cells[3].Text == "1042")
            {
                ViewState["RequestID"] = GridView1.SelectedRow.Cells[2].Text.Trim();
                ViewState["AreaCode"] = GridView1.SelectedRow.Cells[3].Text;

                GrdVendorDetail.DataSource = null;
                GrdVendorDetail.DataBind();
                sql = ("SELECT distinct  b.EmpCode FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN Jct_Ops_SanctioNote_Area_Emp_Auth_Listing b ON a.EMPCODE = b.EmpCode WHERE   ID = '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "' AND a.AUTH_DATETIME IS NULL AND a.Remarks IS NULL AND b.AreaCode = 1042  ");

                if (objFun.CheckRecordExistInTransaction(sql))
                {

                    if (Session["EmpCode"] == objFun.FetchValue(sql))
                    {

                        pnlReProcessingCost.Visible = true;
                        ViewState["Cst_Cost"] = "1";
                    }

                    qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail'" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
                    objFun.FillGrid(qry, ref GrdSanctionNoteDetail);
                    qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
                    objFun.FillGrid(qry, ref GrdAuthHistory);


                       // Show Vendor's List Comparison
 
                    try
                    {
                        string reqid = string.Empty;
                        SqlCommand cmd;
                        SqlDataAdapter da;
                        DataSet ds;
 
                        reqid = GridView1.SelectedRow.Cells[2].Text.Trim();
                        if (IsNumeric(reqid.ToString()))
                        {
                            cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON_FAB", conjctgen);
                            cmd.CommandType = CommandType.StoredProcedure;
                            conjctgen.Open();
                            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

                            da = new SqlDataAdapter(cmd);
                            ds = new DataSet();
                            da.Fill(ds);
                            GrdVendorDetail.DataSource = ds.Tables[0];
                            GrdVendorDetail.DataBind();
                        }
                        else
                        {
                            cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON", conjctgen);
                            cmd.CommandType = CommandType.StoredProcedure;
                            conjctgen.Open();
                            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

                            da = new SqlDataAdapter(cmd);
                            ds = new DataSet();
                            da.Fill(ds);
                            GrdVendorDetail.DataSource = ds.Tables[0];
                            GrdVendorDetail.DataBind();
                        }
                        conjctgen.Close();
                    }
                    catch
                    {

                    }


                    qry = "SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
                    SqlCommand cmd1 = new SqlCommand(qry, obj.Connection());
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    dtlAttachment.DataSource = ds1.Tables[0];
                    dtlAttachment.DataBind();
                }

                //SELECT  vendername AS VendorName ,offerqty AS QtyOffered,UOM ,offerquality AS QualityOffered ,deliveryDt AS ExpectedDlvryDate,payterms AS PayTerms ,Ratetype ,Basicrate ,Landedrate,approved  from jct_ops_yarn_mat_tb where requestid='YR-103' AND status='F' 

                else
                {
                    if (pnlReProcessingCost.Visible == true)
                    {

                        pnlReProcessingCost.Visible = false;
                    }


                    qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
                    objFun.FillGrid(qry, ref GrdSanctionNoteDetail);
                    qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
                    objFun.FillGrid(qry, ref GrdAuthHistory);
                    qry = "   SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
                    SqlCommand cmd3 = new SqlCommand(qry, obj.Connection());
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    dtlAttachment.DataSource = ds3.Tables[0];
                    dtlAttachment.DataBind();


                }
            }
            else if (GridView1.SelectedRow.Cells[3].Text == "1044")
            {
                ViewState["RequestID"] = GridView1.SelectedRow.Cells[2].Text.Trim();
                ViewState["AreaCode"] = GridView1.SelectedRow.Cells[3].Text;
           
                qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
                objFun.FillGrid(qry, ref GrdSanctionNoteDetail);
                qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
                objFun.FillGrid(qry, ref GrdAuthHistory);

                // Show Vendor's List Comparison

                try
                {
                    string reqid = string.Empty;
                    SqlCommand cmd;
                    SqlDataAdapter da;
                    DataSet ds;

                    reqid = GridView1.SelectedRow.Cells[2].Text.Trim();
                    if (IsNumeric(reqid.ToString()))
                    {
                        cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON_FAB", conjctgen);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conjctgen.Open();
                        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        GrdVendorDetail.DataSource = ds.Tables[0];
                        GrdVendorDetail.DataBind();
                    }
                    else
                    {
                        cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON", conjctgen);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conjctgen.Open();
                        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        GrdVendorDetail.DataSource = ds.Tables[0];
                        GrdVendorDetail.DataBind();
                    }
                    conjctgen.Close();
                }
                catch
                {
                }

                qry = "SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
                SqlCommand cmd2 = new SqlCommand(qry, obj.Connection());
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dtlAttachment.DataSource = ds2.Tables[0];
                dtlAttachment.DataBind();

            }

            else if (GridView1.SelectedRow.Cells[3].Text == "1057")
            {
                ViewState["RequestID"] = GridView1.SelectedRow.Cells[2].Text.Trim();
                ViewState["AreaCode"] = GridView1.SelectedRow.Cells[3].Text;

                qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
                objFun.FillGrid(qry, ref GrdSanctionNoteDetail);
                qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
                objFun.FillGrid(qry, ref GrdAuthHistory);

            }

            ddlvendors.DataSource = null;
            ddlvendors.DataBind();

            // add vendors in change vendor dropdown
            sql = "SELECT distinct [vendername] FROM [jct_ops_yarn_mat_tb] WHERE (([RequestID] = '" + ViewState["RequestID"] + "') AND ([status] = 'A'))";
            objFun.FillList(ddlvendors, sql);

            ddlvendors.SelectedIndex = ddlvendors.Items.IndexOf(ddlvendors.Items.FindByText(ViewState["VendorName"].ToString()));
           

        }

        catch (Exception ex)
        {

        }
    }

    public static System.Boolean IsNumeric(System.Object Expression)
    {
        if (Expression == null || Expression is DateTime)
            return false;

        if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
            return true;

        try
        {
            if (Expression is string)
                Double.Parse(Expression as string);
            else
                Double.Parse(Expression.ToString());
            return true;
        }
        catch { } // just dismiss errors but return false
        return false;
    }

    protected void CmdAuthorize_Click(object sender, EventArgs e)
    {
        objFun = new Functions();
        obj = new Connection();
        string qry;
        SqlTransaction Tran;
        if (ViewState["AreaCode"].Equals("1057")) // For Job Work
        {

            //SqlCommand cmd = new SqlCommand("UPDATE  JCT_OPS_SanctionNote_AUTHORIZATION_LISTING SET AUTH_DATETIME=GETDATE(),remarks='" + txtRemarks.Text + "' WHERE ID='" + ViewState["RequestID"] + "'  AND AREACODE='1057'", conjctgen);
            //cmd.CommandType = CommandType.Text;
            //conjctgen.Open();
            //cmd.ExecuteNonQuery();


            //cmd = new SqlCommand("UPDATE  jct_ops_outsourced_job_work SET authflag='A' ,authon=GETDATE() WHERE reqid='" + ViewState["RequestID"] + "'  AND areacode='1057' AND ReqStatus='A' AND  vendorstatus='A'", conjctgen);
            //cmd.CommandType = CommandType.Text;
            //conjctgen.Open();
            //cmd.ExecuteNonQuery();

            qry = "jct_ops_outsourced_jobwork_authorise";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"];
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
            cmd.ExecuteNonQuery();

            SendMailJobWork();

            qry = "Jct_Ops_Pending_Authorization_Fetch '" + Session["Empcode"] + "','" + ViewState["AreaName"] + "'";
            objFun.FillGrid(qry, ref GridView1);

            GrdAuthHistory.DataSource = null;
            GrdAuthHistory.DataBind();

            GrdSanctionNoteDetail.DataSource = null;
            GrdSanctionNoteDetail.DataBind();

            return;
            
        }
        else
        {
            try
            {
                String NextAuthLevel, AreaCode, SanctionNote, SalePersonCode;
                String MaxAuthLevel, CurrentUserLevel;
                NextAuthLevel = "None";
                MaxAuthLevel = "None";
                CurrentUserLevel = "";
                AreaCode = "";
                SanctionNote = "";
                SalePersonCode = "";
                String SalePersonEmail = "ashish@jctltd.com";
                String Body = "";
                String Body3 = "";
                String AuthorizedBy = null;
                String SendMailTo = null;
                String Shade = null;
                Int16 Lineno = 0;
                String Subject = "";
                Int32 Qty = 0;
                String Reqd_Date = "";
                String Area = "";
                String CurrentUserName = "";
                String RaisedByUserName = "";
                String Scrpt = "";
                String AuthMob = "";
                String Empcode;
                Empcode = Session["Empcode"].ToString();
                bool OutOfOffice = false;
                txtRemarks.Text = txtRemarks.Text.Replace("'", "''");
                SanctionNote = GridView1.SelectedRow.Cells[2].Text;
                AreaCode = GridView1.SelectedRow.Cells[3].Text;
                Subject = GridView1.SelectedRow.Cells[6].Text;

                CurrentUserName = objFun.FetchValue("Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','CurrentUserName','" + Empcode + "','',''").ToString();
                AuthorizedBy = objFun.FetchValue("Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','AuthorizedByEmail','" + Empcode + "','',''").ToString();
                if (AuthMob == null)
                {
                    AuthMob = "0";
                }

                String FinalNotify = "";
                SendMailTo = "";
                Shade = "";
                Lineno = 0;

                qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','RaisedBy','" + SanctionNote + "','',''";
                RaisedByUserName = objFun.FetchValue(qry).ToString();

                qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','AreaName','" + AreaCode + "','',''";
                Area = objFun.FetchValue(qry).ToString();
                ViewState["ID"] = SanctionNote;



                Tran = obj.Connection().BeginTransaction();
                try
                {
                    if (GridView1.SelectedIndex > -1)
                    {
                        if (GridView1.SelectedRow.Cells[1].Text != "" || GridView1.Rows.Count >= 1)
                        {

                            con = obj.Connection();

                            qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','FinalNotifyEmail','" + SanctionNote + "','',''";
                            FinalNotify = objFun.FetchValue(qry, con, Tran).ToString();

                            qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','CurrentUserLevel','" + SanctionNote + "','" + Session["Empcode"] + "',''";
                            try
                            {
                                CurrentUserLevel = objFun.FetchValue(qry, con, Tran).ToString();
                            }
                            catch
                            {

                            }


                            if (CurrentUserLevel == null) CurrentUserLevel = "None";

                            if (CurrentUserLevel != "None")
                            {

                                qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','NextAuthLevel','" + SanctionNote + "','" + Session["Empcode"] + "','" + CurrentUserLevel + "'";
                                if (objFun.CheckRecordExistInTransaction(qry))
                                {
                                    NextAuthLevel = objFun.FetchValue(qry, con, Tran).ToString();
                                }
                                else
                                {
                                    NextAuthLevel = "";
                                }

                            }
                            else
                            {
                                objFun.Alert("Unable to Your Authorize...!!!");
                                Tran.Rollback();
                                return;
                            }

                            qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','SendMailTo','" + SanctionNote + "','" + Session["Empcode"] + "','" + CurrentUserLevel + "'";
                            try
                            { SendMailTo = objFun.FetchValue(qry, obj.Connection(), Tran).ToString(); }
                            catch { }

                            qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','MaxAuthLevel','" + SanctionNote + "','',''";
                            try { MaxAuthLevel = objFun.FetchValue(qry, con, Tran).ToString(); }
                            catch { }

                            if (NextAuthLevel == null & MaxAuthLevel == null)
                            {
                                NextAuthLevel = "None";
                                objFun.Alert("Unable to Peform Action...!!!");
                                Tran.Rollback();
                                return;
                            }
                            else if (NextAuthLevel != "None" && CurrentUserLevel != MaxAuthLevel && ddlAction.SelectedItem.Text.Substring(0, 1) == "A")
                            {
                                string NxtAuthEmp = "";
                                qry = "SELECT isnull(EMPCODE,'') FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE id='" + SanctionNote + "' AND USERLEVEL=" + NextAuthLevel + " AND STATUS IS null ";
                                try { NxtAuthEmp = objFun.FetchValue(qry).ToString(); }
                                catch { }

                                //  qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='P',PendingAt='" + NextAuthLevel + "',LastAuthBy='" + CurrentUserLevel + "',LastAuthOn=getdate() where SanctionNoteID='" + SanctionNote + "' and status='A' and AuthFlag='P'";
                                qry = "Exec Jct_Ops_OutSourced_Fabric_Authorization '" + SanctionNote + "','" + AreaCode + "','" + CurrentUserLevel + "','" + MaxAuthLevel + "','" + ddlAction.SelectedItem.Text.Substring(0, 1).ToString() + "','" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "','" + txtRemarks.Text + "','" + NextAuthLevel + "'";
                                objFun.UpdateRecord(qry, Tran, con);

                                qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" + Request.ServerVariables["REMOTE_ADDR"] + "',remarks='" + txtRemarks.Text + "' WHERE ID='" + SanctionNote + "' AND EMPCODE='" + Session["Empcode"] + "' AND AREACODE='" + AreaCode + "' AND USERLEVEL= '" + CurrentUserLevel + "' and status is null";
                                objFun.UpdateRecord(qry, Tran, con);

                                if (CurrentUserLevel == MaxAuthLevel)
                                {
                                    Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " + SanctionNote + " Is " + ddlAction.SelectedItem.Text + " </h3></b> By <b> " + CurrentUserName + " ";
                                }
                                else
                                {
                                    Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " + SanctionNote + " Is " + ddlAction.SelectedItem.Text + " </h3></b> By <b> " + CurrentUserName + " and is now Pending for your Approval";
                                }
                                // Else part will be executed in case when either maxauthlevel is achevied or some one wants to cancel any sanctionnote
                            }
                            else
                            {

                                qry = "Exec Jct_Ops_OutSourced_Fabric_Authorization '" + SanctionNote + "','" + AreaCode + "','" + CurrentUserLevel + "','" + MaxAuthLevel + "','" + ddlAction.SelectedItem.Text.Substring(0, 1).ToString() + "','" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "','" + txtRemarks.Text + "','" + NextAuthLevel + "'";
                                objFun.UpdateRecord(qry, Tran, con);
                                if (ddlAction.SelectedItem.Text.Substring(0, 1) == "A")
                                {
                                    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" + Request.ServerVariables["REMOTE_ADDR"] + "',remarks='" + txtRemarks.Text + "' WHERE ID='" + SanctionNote + "' AND EMPCODE='" + Session["Empcode"] + "' AND AREACODE='" + AreaCode + "' AND USERLEVEL= '" + CurrentUserLevel + "' and status is null";
                                    objFun.InsertRecord(qry, Tran, con);
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(SendMailTo))
                                    {
                                        string Sp = null;
                                        Sp = "";
                                        qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" + AreaCode + "'  and id='" + SanctionNote + "' and a.status is null and a.Usercode=b.empcode order by userlevel";
                                        Sp = objFun.FetchValue(qry, obj.Connection(), Tran).ToString();
                                        if (Sp == null)
                                            Sp = "";
                                        if (!string.IsNullOrEmpty(Sp))
                                            SendMailTo = SendMailTo + "," + Sp;
                                    }
                                    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" + Request.ServerVariables["REMOTE_ADDR"] + "',remarks='" + txtRemarks.Text + "' WHERE ID='" + SanctionNote + "' AND EMPCODE='" + Session["Empcode"] + "' AND AREACODE='" + AreaCode + "' AND USERLEVEL= '" + CurrentUserLevel + "' and status is null";
                                    objFun.InsertRecord(qry, Tran, con);

                                }
                                Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " + SanctionNote + " Is " + ddlAction.SelectedItem.Text + " </h3></b> By <b> " + CurrentUserName + " ";
                            }


                            Tran.Commit();
                            if ((ddlAction.SelectedItem.Text.Substring(0, 1) == "A"))
                            {
                                Scrpt = "alert('SanctionNote has been Authorized..!!');";
                            }
                            else
                            {
                                Scrpt = "alert('SanctionNote has been Cancelled..!!');";
                            }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
                            if ((ddlAction.SelectedItem.Text.Substring(0, 1) == "A"))
                            {
                                objFun.Alert("SanctionNote has been Authorized..!!");
                            }
                            else
                            {
                                objFun.Alert("SanctionNote has been Cancelled..!!");
                            }

                            try
                            {
                                //SendMail sm = new SendMail();

                            }
                            catch (Exception ex)
                            {
                                Scrpt = "alert('Unable to Send SMS Alert...!!!');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
                            }
                            if (AreaCode == "9999")
                            {

                            }
                            else
                            {
                                try
                                {
                                    qry = "SELECT DESCRIPTION FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" + SanctionNote + "' AND STATUS='A'";
                                    string Body1 = "Subject Mentioned :- " + Subject + " <hr><br><br> Under Area :-" + Area + " <BR> <HR> <b>With below detailed Info :-</b>" + objFun.FetchValue(qry) + " <hr>";
                                    string Val1 = "";
                                    string ParmName = "";
                                    for (int i = 0; i <= GrdSanctionNoteDetail.Rows.Count - 1; i++)
                                    {
                                        ParmName = GrdSanctionNoteDetail.Rows[i].Cells[0].Text;
                                        Val1 = GrdSanctionNoteDetail.Rows[i].Cells[1].Text;
                                        Body1 = Body1 + "<p> <b>" + ParmName + " :-</b> " + Val1 + " </p> ";
                                    }
                                    Body3 = "<br/><a href='http://testerp/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";


                                }
                                catch (Exception ex)
                                {
                                    Scrpt = "alert('Unable to Send E-Mail Alert...!!!');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
                                }
                            }
                            RefreshLists();
                        }
                        else
                        {
                            Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
                            objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!");
                            return;
                        }
                    }
                    else
                    {
                        Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
                        objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    //ashish
                    Tran.Rollback();
                    Scrpt = "alert('Unable to Complete Transaction...');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
                    objFun.Alert("Unable to Complete Transaction...");
                    // ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)

                }
            }
            catch (Exception ex)
            {
                string Scrpt = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
            }

            sendmail();
        }
    }

    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        string qry;
    //        string sql;
    //        objFun = new Functions();
    //        obj = new Connection();

    //        if (GridView1.SelectedRow.Cells[3].Text == "1042")
    //        {

    //            GrdVendorDetail.DataSource = null;
    //            GrdVendorDetail.DataBind();
    //            sql = ("SELECT distinct  b.EmpCode FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN Jct_Ops_SanctioNote_Area_Emp_Auth_Listing b ON a.EMPCODE = b.EmpCode WHERE   ID = '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "' AND a.AUTH_DATETIME IS NULL AND a.Remarks IS NULL AND b.AreaCode = 1042  ");

    //            if (objFun.CheckRecordExistInTransaction(sql))
    //            {

    //                if (Session["EmpCode"] == objFun.FetchValue(sql))
    //                {

    //                    pnlReProcessingCost.Visible = true;
    //                    ViewState["Cst_Cost"] = "1";
    //                }

    //                qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail'" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
    //                objFun.FillGrid(qry, ref GrdSanctionNoteDetail);
    //                qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
    //                objFun.FillGrid(qry, ref GrdAuthHistory);
    //                qry = "SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
    //                SqlCommand cmd = new SqlCommand(qry, obj.Connection());
    //                SqlDataAdapter da = new SqlDataAdapter(cmd);
    //                DataSet ds = new DataSet();
    //                da.Fill(ds);
    //                dtlAttachment.DataSource = ds.Tables[0];
    //                dtlAttachment.DataBind();
    //            }
                
    //            //SELECT  vendername AS VendorName ,offerqty AS QtyOffered,UOM ,offerquality AS QualityOffered ,deliveryDt AS ExpectedDlvryDate,payterms AS PayTerms ,Ratetype ,Basicrate ,Landedrate,approved  from jct_ops_yarn_mat_tb where requestid='YR-103' AND status='F' 

    //            else
    //            {
    //                if (pnlReProcessingCost.Visible == true)
    //                {

    //                    pnlReProcessingCost.Visible = false;
    //                }


    //                qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
    //                objFun.FillGrid(qry, ref GrdSanctionNoteDetail);
    //                qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
    //                objFun.FillGrid(qry, ref GrdAuthHistory);
    //                qry = "   SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
    //                SqlCommand cmd = new SqlCommand(qry, obj.Connection());
    //                SqlDataAdapter da = new SqlDataAdapter(cmd);
    //                DataSet ds = new DataSet();
    //                da.Fill(ds);
    //                dtlAttachment.DataSource = ds.Tables[0];
    //                dtlAttachment.DataBind();


    //            }
    //        }
    //        else if (GridView1.SelectedRow.Cells[3].Text == "1044")
    //        {
    //            qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
    //            objFun.FillGrid(qry, ref GrdSanctionNoteDetail);
    //            qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
    //            objFun.FillGrid(qry, ref GrdAuthHistory);
    //            qry = "SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + GridView1.SelectedRow.Cells[2].Text.Trim() + "'";
    //            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
    //            DataSet ds = new DataSet();
    //            da.Fill(ds);
    //            dtlAttachment.DataSource = ds.Tables[0];
    //            dtlAttachment.DataBind();

    //            //qry = "SELECT  vendername AS VendorName ,offerqty AS QtyOffered,UOM ,offerquality AS QualityOffered ,deliveryDt AS ExpectedDlvryDate,payterms AS PayTerms ,Ratetype ,Basicrate ,Landedrate,approved  from jct_ops_yarn_mat_tb where requestid='" + GridView1.SelectedRow.Cells[2].Text.Trim() + "' AND status='F' ";//"Exec Jct_Ops_Pending_Authorization_Fetch_Detail_test'" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
    //            qry = "SELECT  vendername AS VendorName ,offerqty AS QtyOffered,UOM ,offerquality AS QualityOffered ,deliveryDt AS ExpectedDlvryDate,payterms AS PayTerms ,Ratetype ,Basicrate ,Landedrate,approved  from jct_ops_yarn_mat_tb where requestid='Yr-103' AND status='F' ";//"Exec Jct_Ops_Pending_Authorization_Fetch_Detail_test'" + GridView1.SelectedRow.Cells[2].Text.Trim() + "','" + GridView1.SelectedRow.Cells[3].Text.Trim() + "'";
    //            objFun.FillGrid(qry, ref GrdVendorDetail);
    //        }
    //    }




    //    catch (Exception ex)
    //    {

    //    }



    //}

    //protected void CmdAuthorize_Click(object sender, EventArgs e)
    //{
    //    objFun = new Functions();
    //    obj = new Connection();
    //    string qry;
    //    SqlTransaction Tran;
    //    try
    //    {
    //        String NextAuthLevel, AreaCode, SanctionNote, SalePersonCode;
    //        String MaxAuthLevel, CurrentUserLevel;
    //        NextAuthLevel = "None";
    //        MaxAuthLevel = "None";
    //        CurrentUserLevel = "";
    //        AreaCode = "";
    //        SanctionNote = "";
    //        SalePersonCode = "";
    //        String SalePersonEmail = "ashish@jctltd.com";
    //        String Body = "";
    //        String Body3 = "";
    //        String AuthorizedBy = null;
    //        String SendMailTo = null;
    //        String Shade = null;
    //        Int16 Lineno = 0;
    //        String Subject = "";
    //        Int32 Qty = 0;
    //        String Reqd_Date = "";
    //        String Area = "";
    //        String CurrentUserName = "";
    //        String RaisedByUserName = "";
    //        String Scrpt = "";
    //        String AuthMob = "";
    //        String Empcode;
    //        Empcode = Session["Empcode"].ToString();
    //        bool OutOfOffice = false;
    //        txtRemarks.Text = txtRemarks.Text.Replace("'", "''");
    //        SanctionNote = GridView1.SelectedRow.Cells[2].Text;
    //        AreaCode = GridView1.SelectedRow.Cells[3].Text;
    //        Subject = GridView1.SelectedRow.Cells[6].Text;
          
    //        CurrentUserName = objFun.FetchValue("Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','CurrentUserName','" + Empcode + "','',''").ToString();
    //        AuthorizedBy = objFun.FetchValue("Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','AuthorizedByEmail','" + Empcode + "','',''").ToString();
    //        if (AuthMob == null)
    //        {
    //            AuthMob = "0";
    //        }

    //        String FinalNotify = "";
    //        SendMailTo = "";
    //        Shade = "";
    //        Lineno = 0;
 
    //        qry= "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','RaisedBy','" + SanctionNote + "','',''";
    //        RaisedByUserName = objFun.FetchValue(qry).ToString();
         
    //        qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','AreaName','" + AreaCode + "','',''";
    //        Area = objFun.FetchValue(qry).ToString();
    //        ViewState["ID"] = SanctionNote;



    //        Tran = obj.Connection().BeginTransaction();
    //        try
    //        {
    //            if (GridView1.SelectedIndex > -1)
    //            {
    //                if (GridView1.SelectedRow.Cells[1].Text != "" || GridView1.Rows.Count >= 1)
    //                {
                         
    //                    con = obj.Connection();
                       
    //                    qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','FinalNotifyEmail','" + SanctionNote + "','',''";
    //                    FinalNotify = objFun.FetchValue(qry, con, Tran).ToString();
                       
    //                    qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','CurrentUserLevel','" + SanctionNote + "','" + Session["Empcode"] + "',''";
                       
    //                    try
    //                    {
    //                        CurrentUserLevel = objFun.FetchValue(qry, con, Tran).ToString();
    //                    }
    //                    catch
    //                    {

    //                    }
                        

    //                    if (CurrentUserLevel == null) CurrentUserLevel = "None";

    //                    if (CurrentUserLevel != "None")
    //                    {
                         
    //                        qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','NextAuthLevel','" + SanctionNote + "','" + Session["Empcode"] + "','" + CurrentUserLevel + "'";
    //                        if (objFun.CheckRecordExistInTransaction(qry))
    //                        {
    //                            NextAuthLevel = objFun.FetchValue(qry, con, Tran).ToString();
    //                        }
    //                        else
    //                        {
    //                            NextAuthLevel = "";
    //                        }
                            
    //                    }
    //                    else
    //                    {
    //                        objFun.Alert("Unable to Your Authorize...!!!");
    //                        Tran.Rollback();
    //                        return;
    //                    }
 
    //                    qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','SendMailTo','" + SanctionNote + "','" + Session["Empcode"] + "','" + CurrentUserLevel + "'";
    //                    SendMailTo = objFun.FetchValue(qry, obj.Connection(), Tran).ToString();
 
    //                    qry = "Exec Jct_Ops_Get_Outsourced_Info '" + AreaCode + "','MaxAuthLevel','" + SanctionNote + "','',''";
    //                    MaxAuthLevel = objFun.FetchValue(qry, con, Tran).ToString();

    //                    if (NextAuthLevel == null & MaxAuthLevel == null)
    //                    {
    //                        NextAuthLevel = "None";
    //                        objFun.Alert("Unable to Peform Action...!!!");
    //                        Tran.Rollback();
    //                        return;
    //                    }
    //                    else if (NextAuthLevel != "None" && CurrentUserLevel != MaxAuthLevel && ddlAction.SelectedItem.Text.Substring(0,1) == "A")
    //                    {
    //                        string NxtAuthEmp = "";
    //                        qry = "SELECT isnull(EMPCODE,'') FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE id='" + SanctionNote + "' AND USERLEVEL=" + NextAuthLevel + " AND STATUS IS null ";
    //                        NxtAuthEmp = objFun.FetchValue(qry).ToString();

    //                        //  qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='P',PendingAt='" + NextAuthLevel + "',LastAuthBy='" + CurrentUserLevel + "',LastAuthOn=getdate() where SanctionNoteID='" + SanctionNote + "' and status='A' and AuthFlag='P'";
    //                        qry = "Exec Jct_Ops_OutSourced_Fabric_Authorization '" + SanctionNote + "','" + AreaCode + "','" + CurrentUserLevel + "','" + MaxAuthLevel + "','" + ddlAction.SelectedItem.Text.Substring(0, 1).ToString() + "','" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "','" + txtRemarks.Text + "','" + NextAuthLevel + "'";
    //                        objFun.UpdateRecord(qry, Tran, con);

    //                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" + Request.ServerVariables["REMOTE_ADDR"] + "',remarks='" + txtRemarks.Text + "' WHERE ID='" + SanctionNote + "' AND EMPCODE='" + Session["Empcode"] + "' AND AREACODE='" + AreaCode + "' AND USERLEVEL= '" + CurrentUserLevel + "' and status is null";
    //                        objFun.UpdateRecord(qry, Tran, con);

    //                        if (CurrentUserLevel == MaxAuthLevel)
    //                        {
    //                            Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " + SanctionNote + " Is " + ddlAction.SelectedItem.Text + " </h3></b> By <b> " + CurrentUserName + " ";
    //                        }
    //                        else
    //                        {
    //                            Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " + SanctionNote + " Is " + ddlAction.SelectedItem.Text + " </h3></b> By <b> " + CurrentUserName + " and is now Pending for your Approval";
    //                        }
    //                        // Else part will be executed in case when either maxauthlevel is achevied or some one wants to cancel any sanctionnote
    //                    }
    //                    else
    //                    {
                           
    //                        qry = "Exec Jct_Ops_OutSourced_Fabric_Authorization '" + SanctionNote + "','" + AreaCode + "','" + CurrentUserLevel + "','" + MaxAuthLevel + "','" + ddlAction.SelectedItem.Text.Substring(0, 1).ToString() + "','" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "','" + txtRemarks.Text + "','" + NextAuthLevel + "'";
    //                        objFun.UpdateRecord(qry, Tran, con);
    //                        if (ddlAction.SelectedItem.Text.Substring(0,1) == "A")
    //                        {
    //                            qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" + Request.ServerVariables["REMOTE_ADDR"] + "',remarks='" + txtRemarks.Text + "' WHERE ID='" + SanctionNote + "' AND EMPCODE='" + Session["Empcode"] + "' AND AREACODE='" + AreaCode + "' AND USERLEVEL= '" + CurrentUserLevel + "' and status is null";
    //                            objFun.InsertRecord(qry, Tran, con);
    //                        }
    //                        else
    //                        {
    //                            if (!string.IsNullOrEmpty(SendMailTo))
    //                            {
    //                                string Sp = null;
    //                                Sp = "";
    //                                qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" + AreaCode + "'  and id='" + SanctionNote + "' and a.status is null and a.Usercode=b.empcode order by userlevel";
    //                                Sp = objFun.FetchValue(qry, obj.Connection(), Tran).ToString();
    //                                if (Sp == null)
    //                                    Sp = "";
    //                                if (!string.IsNullOrEmpty(Sp))
    //                                    SendMailTo = SendMailTo + "," + Sp;
    //                            }
    //                            qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" + Request.ServerVariables["REMOTE_ADDR"] + "',remarks='" + txtRemarks.Text + "' WHERE ID='" + SanctionNote + "' AND EMPCODE='" + Session["Empcode"] + "' AND AREACODE='" + AreaCode + "' AND USERLEVEL= '" + CurrentUserLevel + "' and status is null";
    //                            objFun.InsertRecord(qry, Tran, con);
                             
    //                        }
    //                        Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " + SanctionNote + " Is " + ddlAction.SelectedItem.Text + " </h3></b> By <b> " + CurrentUserName + " ";
    //                    }

                        
    //                    Tran.Commit();
    //                    if ((ddlAction.SelectedItem.Text.Substring(0,1) == "A"))
    //                    {
    //                        Scrpt = "alert('SanctionNote has been Authorized..!!');";
    //                    }
    //                    else
    //                    {
    //                        Scrpt = "alert('SanctionNote has been Cancelled..!!');";
    //                    }
    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
    //                    if ((ddlAction.SelectedItem.Text.Substring(0,1) == "A"))
    //                    {
    //                        objFun.Alert("SanctionNote has been Authorized..!!");
    //                    }
    //                    else
    //                    {
    //                        objFun.Alert("SanctionNote has been Cancelled..!!");
    //                    }
 
    //                    try
    //                    {
    //                        SendMail sm = new SendMail();
                            
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        Scrpt = "alert('Unable to Send SMS Alert...!!!');";
    //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
    //                    }
    //                    if (AreaCode == "9999")
    //                    {
 
    //                    }
    //                    else
    //                    {
    //                        try
    //                        {
    //                            qry = "SELECT DESCRIPTION FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" + SanctionNote + "' AND STATUS='A'";
    //                            string Body1 = "Subject Mentioned :- " + Subject + " <hr><br><br> Under Area :-" + Area + " <BR> <HR> <b>With below detailed Info :-</b>" + objFun.FetchValue(qry) + " <hr>";
    //                            string Val1 = "";
    //                            string ParmName = "";
    //                            for (int i = 0; i <= GrdSanctionNoteDetail.Rows.Count - 1; i++)
    //                            {
    //                                ParmName = GrdSanctionNoteDetail.Rows[i].Cells[0].Text;
    //                                Val1 = GrdSanctionNoteDetail.Rows[i].Cells[1].Text;
    //                                Body1 = Body1 + "<p> <b>" + ParmName + " :-</b> " + Val1 + " </p> ";
    //                            }
    //                            Body3 = "<br/><a href='http://misdev/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";

                         
    //                        }
    //                        catch (Exception ex)
    //                        {
    //                            Scrpt = "alert('Unable to Send E-Mail Alert...!!!');";
    //                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
    //                        }
    //                    }
    //                    RefreshLists();
    //                }
    //                else
    //                {
    //                    Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');";
    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
    //                    objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!");
    //                    return;
    //                }
    //            }
    //            else
    //            {
    //                Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
    //                objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!");
    //                return;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            //ashish
    //            Tran.Rollback();
    //            Scrpt = "alert('Unable to Complete Transaction...');";
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
    //            objFun.Alert("Unable to Complete Transaction...");
    //            // ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
               
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string Scrpt = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
    //    }

    //}

    private void SendMail(string Body__1, string Body2, string body3, string RaisedBy_Email, string to, string cc, string bcc, string Subject, string SanctionNote, String CurrentLevel, String MaxLevel, string NotifyAllList, string Action)
    {
        try
        {
            string @from = null;
            StringBuilder sb = new StringBuilder();
            @from = "outsourcing@jctltd.com";
            string query = "";
            string SenderEmail = "";
            SqlDataAdapter da = default(SqlDataAdapter);
            DataTable Dt = new DataTable();
            if (RaisedBy_Email == null)
            {
                RaisedBy_Email = "";
            }

            //query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
            SenderEmail = to;
            //objFun.FetchValue(query)
            if (SenderEmail == null)
                SenderEmail = "";


            if (!string.IsNullOrEmpty(SenderEmail))
            {
                //Email Address of Receiver
                to = SenderEmail;
              
            }
            else
            {
                to = RaisedBy_Email;
                
            }
            if (CurrentLevel == MaxLevel & Convert.ToInt16(CurrentLevel) > 0 & Action == "Authorize")
            {
                to = NotifyAllList;
               
            }

            bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com,rajan@jctltd.com,william@jctltd.com";
           
            MailMessage mail = new MailMessage();
         
            string Desc = null;
           
            Desc = objFun.FetchValue("Exec Jct_Ops_Get_Outsourced_Info '1044','RequestDesc','" + SanctionNote + "','',''").ToString();

            sb.AppendLine("<html>");
            sb.AppendLine("<br/><br/>");

            if (Desc == null)
                Desc = "";
            if (to == "rohits@jctltd.com" || to == "jatindutta@jctltd.com")
            {
                @from = "outsourcing@jctltd.com";
                sb.AppendLine("Please reply this email with 'YES'  to authorise and  'NO' to cancel and 'REMARKS'.<br/> <br/>");
            }
            else
                @from = "outsourcing@jctltd.com";
            cc = NotifyAllList;


            sb.AppendLine(Body__1 + " <br/>");

            if (!string.IsNullOrEmpty(Desc))
                sb.AppendLine("<hr><br/><b>Description :-</b>" + Desc + "<br/> <hr><br/>");



            sb.AppendLine("Sanction Note was Genrated with the following parameters: <br/><br/>");
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
            //var _with1 = GrdSanctionNoteDetail;


            Int16 i;
            i = 0;
            for (i = 0; i <= GrdSanctionNoteDetail.Rows.Count - 1; i++)
            {
                Q = "<tr>";
                //This if is used to Fetch Header from Gridview
                if (i == 0)
                {
                    //.Columns.Count
                    for (J = 0; J < 16; J++)
                    {

                        GridHeader += "<th> " + GrdSanctionNoteDetail.HeaderRow.Cells[J].Text + "</th>";

                    }
                    body1 = body1 + GridHeader + " </tr>";
                }

                //This loops feteches data from each cell of grid
                //.Columns.Count
                for (J = 0; J < 16; J++)
                {
                    if (i == 0)
                    {
                        //query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                        GridHeader += "<th> " + GrdSanctionNoteDetail.HeaderRow.Cells[J].Text + "</th>";
                    }
                    Q += "<td>" + GrdSanctionNoteDetail.Rows[i].Cells[J].Text + "</td>";
                }
                body1 = body1 + Q + " </tr>";

            }
            sb.AppendLine("" + body1);
            //Sb.AppendLine("<table class=gridtable>")
            //Sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



            sb.AppendLine("</table>");
            sb.AppendLine("<br />");


            sb.AppendLine("</table><br />");





            sb.AppendLine("Authorization Remarks are Shown below: <br/><br/>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
            sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");


            sb.AppendLine("<table class=gridtable>");

            GridHeader = "";
            Q = "";
            J = 0;
            body1 = "";
            //var _with2 = GrdAuthHistory;



            for (i = 0; i <= GrdAuthHistory.Rows.Count - 2; i++)
            {
                Q = "<tr>";
                //This if is used to Fetch Header from Gridview
                if (i == 0)
                {
                    //.Columns.Count
                    for (J = 1; J < 6; J++)
                    {

                        GridHeader += "<th> " + GrdAuthHistory.HeaderRow.Cells[J].Text + "</th>";

                    }
                    body1 = body1 + GridHeader + " </tr>";
                }

                //This loops feteches data from each cell of grid
                //.Columns.Count
                for (J = 1; J < 6; J++)
                {
                    if (i == 0)
                    {
                        //query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                        GridHeader += "<th> " + GrdAuthHistory.HeaderRow.Cells[J].Text + "</th>";
                    }
                    Q += "<td>" + GrdAuthHistory.Rows[i].Cells[J].Text + "</td>";
                }
                body1 = body1 + Q + " </tr>";

            }
            sb.AppendLine("" + body1);
            //Sb.AppendLine("<table class=gridtable>")
            //Sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



            sb.AppendLine("</table>");
            sb.AppendLine("<br />");


            sb.AppendLine("</table><br />");
            sb.AppendLine("<br/><a href='http://misdev/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p><br>");
            // Sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
            sb.AppendLine("Thank you<br />");
            sb.AppendLine("</html>");
            mail.Body = sb.ToString();

            //}
            //else
            //{
            //    mail.Body = Body__1 + " " + Body2 + " " + body3;

            //}


            mail.From = new MailAddress(@from);
            if (to.Contains(","))
            {
                string[] tos = to.Split(',');
                for (int k = 0; k <= tos.Length - 1; k++)
                {
                    mail.To.Add(new MailAddress(tos[k]));
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
                    for (int k = 0; k <= bccs.Length - 1; k++)
                    {
                        mail.Bcc.Add(new MailAddress(bccs[k]));
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
                    for (int k = 0; k <= ccs.Length - 1; k++)
                    {
                        mail.CC.Add(new MailAddress(ccs[k]));
                    }
                    //Else
                    //    mail.CC.Add(New MailAddress(bcc))
                }
                mail.CC.Add(new MailAddress(cc));
            }

            mail.Subject = Subject;

            //Sb.a()
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //       MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
            ///* Attach the newly created email attachment */      
            //mailMessage.Attachments.Add(attach);
            String qry;
            SqlCommand cmd;
            SqlDataReader dr;
            if (CurrentLevel == MaxLevel & Convert.ToInt16(CurrentLevel) > 0 & Action == "Authorize")
            {
                qry = "SELECT ImgName FROM Jct_Ops_SanctionNote_Attachments WHERE STATUS='A' AND SanctionNoteID='" + SanctionNote + "'";
                cmd = new SqlCommand(qry, obj.Connection());
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {

                        Attachment Atchment = new Attachment(Server.MapPath("~\\OPS\\Upload\\") + dr[0]); //+ dr.Item(0));
                        mail.Attachments.Add(Atchment);
                    }
                }
                dr.Close();

            }

            SmtpClient SmtpMail = new SmtpClient("exchange2k7");

            //SmtpMail.Send(mail);
        }
        catch (Exception ex)
        {
            string Scrpt = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
        }
    }

    private void RefreshLists()
    {
        DataList1.DataSource = null;
        DataBind();

        DataList1.DataSourceID = "SqlDataSource2";
        DataBind();

        GridView1.DataSource = null;
        GridView1.DataBind();

        GrdSanctionNoteDetail.DataSource = null;
        GrdSanctionNoteDetail.DataBind();
    }

    protected void GrdVendorDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string sql = string.Empty;

        if (e.Row.RowType == DataControlRowType.Header)
        {
            try
            {
                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    sql = "SELECT * FROM dbo.jct_ops_yarn_mat_tb where RequestID='" + ViewState["RequestID"] + "'";
                    if (objFun.CheckRecordExistInTransaction(sql))
                    {
                        sql = "SELECT * FROM dbo.jct_ops_yarn_mat_tb  WHERE vendername='" + e.Row.Cells[i + 3].Text + "' AND approved='Y' AND RequestID='" + ViewState["RequestID"] + "' ";
                        if (objFun.CheckRecordExistInTransaction(sql))
                        {
                            color = true;
                            ViewState["CellNumber"] = i + 3;
                            //e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                        }
                    }
                    else
                    {
                        sql = "SELECT * FROM dbo.jct_ops_out_fab_vendor WHERE vendor='" + e.Row.Cells[i + 3].Text + "' AND approved='Y' AND RequestID='" + ViewState["RequestID"] + "' ";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                color = true;
                                ViewState["CellNumber"] = i + 3;
                                //e.Row.Cells[i + 2].ForeColor = System.Drawing.Color.Green;
                            }
                        }
                        else
                        {
                            color=false;
                        }
                        dr.Close();
                    }
                }
 
            }
            catch(Exception ex)
            { 
                //string script = "alert('Error : '"+ ex.Message +"' ');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }


        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (color == true)
            {
                e.Row.Cells[Convert.ToInt32(ViewState["CellNumber"])].ForeColor = System.Drawing.Color.Green;
            }

        }
    }

    protected void lnkChangeVendor_Click(object sender, EventArgs e)
    {
        if (pnlChangeVendor.Visible == true)
        {
            pnlChangeVendor.Visible = false;
        }
        else
        {
            pnlChangeVendor.Visible = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        string reqid = string.Empty;

        try
        {
            if (ViewState["AreaCode"].ToString() == "1042")
            {
                cmd = new SqlCommand("jct_ops_fab_apprvals", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"].ToString();
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 100).Value = ddlvendors.SelectedItem.Text;
                cmd.Parameters.Add("@approvedby", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                cmd.Parameters.Add("@approveRmk", SqlDbType.VarChar, 200).Value = txtvendorRemarks.Text;
                cmd.ExecuteNonQuery();

                // populate fabric vendrs list grid

                reqid = ViewState["RequestID"].ToString();

                if (IsNumeric(reqid.ToString()))
                {
                    cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON_FAB", conjctgen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conjctgen.Open();
                    cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    GrdVendorDetail.DataSource = ds.Tables[0];
                    GrdVendorDetail.DataBind();
                }
                else
                {
                    cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON", conjctgen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conjctgen.Open();
                    cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    GrdVendorDetail.DataSource = ds.Tables[0];
                    GrdVendorDetail.DataBind();
                }
                conjctgen.Close();

            }
            else if (ViewState["AreaCode"].ToString() == "1044")
            {
                cmd = new SqlCommand("jct_ops_yarn_apprvals", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = ViewState["RequestID"].ToString();
                cmd.Parameters.Add("@vendername", SqlDbType.VarChar, 100).Value = ddlvendors.SelectedItem.Text;
                cmd.Parameters.Add("@approvedby", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                cmd.Parameters.Add("@approveRmk", SqlDbType.VarChar, 200).Value = txtvendorRemarks.Text;
                cmd.ExecuteNonQuery();

                // populate yarn vendrs list grid

                reqid = ViewState["RequestID"].ToString();

                if (IsNumeric(reqid.ToString()))
                {
                    cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON_FAB", conjctgen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conjctgen.Open();
                    cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    GrdVendorDetail.DataSource = ds.Tables[0];
                    GrdVendorDetail.DataBind();
                }
                else
                {
                    cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON", conjctgen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conjctgen.Open();
                    cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    GrdVendorDetail.DataSource = ds.Tables[0];
                    GrdVendorDetail.DataBind();
                }

                conjctgen.Close();

            }
            else
            {
            }

            string script = "alert('Vendor updated.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('Error - " + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        pnlChangeVendor.Visible = false;

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
            string Body = string.Empty;

            sql = "jct_ops_check_outsource_areaname";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = ViewState["ID"];
            cmd.Parameters.Add("@area", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            string AreaName = cmd.Parameters["@area"].Value.ToString();
            querystring = "EmpCode=" + Session["EmpCode"].ToString() + "&RequestID=" + ViewState["RequestID"];

            if (AreaName == "Outsource Yarn")
            {
                #region Outsource yarn mail

                subject = "Outsource Yarn Request " + ViewState["RequestID"];
                //querystring = "RequestID=" + ViewState["RequestID"];

                //url = "http://localhost:4297/FusionApps1/OPS/MailContentPages/outsource_vendor_comparison.aspx?" + querystring;

                url = "http://testerp/FusionApps/OPS/MailContentPages/outsource_vendor_comparison.aspx?" + querystring;

                @from = "Outsourcing@jctltd.com";

                sql = "SELECT b.E_MailID FROM dbo.jct_ops_yarn_purchase a INNER JOIN dbo.MISTEL b ON a.usercode=b.empcode WHERE a.RequestID='" + ViewState["ID"] + "' AND status='F'";
                try
                {
                    to = objFun.FetchValue(sql).ToString();
                }
                catch { to = ""; return; }

                //to = "jatindutta@jctltd.com";
                bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
                //bcc = "jatindutta@jctltd.com,shwetaloria@jctltd.com,rajan@jctltd.com";
                cc = "laxman@jctltd.com,arvindsharma@jctltd.com,dpbadhwar@jctltd.com";

                Body = GetPage(url);//GetPage("http://testerp/FusionApps/OPS/AuthorizationRemarks.aspx");


                #endregion
            }
            else if (AreaName == "Outsource Fabric")
            {
                #region Outsource Fabric mail

                subject = "Outsource Fabric Request " + ViewState["RequestID"];
                //querystring = "RequestID=" + ViewState["RequestID"];

                url = "http://testerp/FusionApps/OPS/MailContentPages/outsource_vendor_comparison.aspx?" + querystring;

                @from = "Outsourcing@jctltd.com";

                //sql = "SELECT b.E_MailID FROM dbo.jct_ops_yarn_purchase a INNER JOIN dbo.MISTEL b ON a.usercode=b.empcode WHERE a.RequestID='" + ViewState["ID"] + "' AND status='F'";

                sql = "SELECT b.E_MailID FROM dbo.jct_ops_outsrd_dyed_fab a INNER JOIN dbo.MISTEL b ON a.enteredby=b.empcode WHERE a.RequestID='" + ViewState["ID"] + "' AND status='F'";
                try
                {
                    to = objFun.FetchValue(sql).ToString();
                }
                catch { to = "jatindutta@jctltd.com"; }

                //to = "jatindutta@jctltd.com";
                bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com,jatindutta@jctltd.com";
                //bcc = "jatindutta@jctltd.com,shwetaloria@jctltd.com,rajan@jctltd.com";
                //cc = "laxman@jctltd.com,arvindsharma@jctltd.com,dpbadhwar@jctltd.com,ypsharma@jctltd.com";

                cc = "ypsharma@jctltd.com,rajgopal@jctltd.com,skpalta@jctltd.com,dpbadhwar@jctltd.com";

                Body = GetPage(url);//GetPage("http://tetserp/FusionApps/OPS/AuthorizationRemarks.aspx");


                #endregion
            }
            else if (AreaName == "Outsource Wardrobe")
            {
                #region Outsource Wardrobe mail

                subject = "Outsource Wardrobe Request " + ViewState["RequestID"];
                //querystring = "RequestID=" + ViewState["RequestID"];

                url = "http://testerp/FusionApps/OPS/MailContentPages/outsource_wardrobe_mail.aspx?" + querystring;

                @from = "Outsourcing@jctltd.com";

                sql = "SELECT DISTINCT b.E_MailID FROM dbo.jct_ops_outsourced_wardrobe a INNER JOIN dbo.MISTEL b ON a.enteredby=b.empcode WHERE a.reqid='" + ViewState["ID"] + "'";
                try
                {
                    to = objFun.FetchValue(sql).ToString();
                }
                catch (Exception ex) { to = "ashish@jctltd.com,shwetaloria@jctltd.com"; Body = ex.Message; }

                //to = "jatindutta@jctltd.com";
                bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com,ashish@jctltd.com";
                //bcc = "jatindutta@jctltd.com,shwetaloria@jctltd.com,rajan@jctltd.com";
                cc = "skpalta@jctltd.com,arvindsharma@jctltd.com,dpbadhwar@jctltd.com";

                Body = Body + GetPage(url);//GetPage("http://testerp/FusionApps/OPS/AuthorizationRemarks.aspx");


                #endregion
            }
            else if (AreaName == "JobWork")
            {
                #region Outsource JobWork mail

                subject = "Outsource JobWork  Request " + ViewState["RequestID"];
                //querystring = "RequestID=" + ViewState["RequestID"];

               // url = "http://testerp/FusionApps/OPS/MailContentPages/outsourced_jobwork.aspx?" + querystring;

                @from = "Outsourcing@jctltd.com";

                sql = "SELECT b.E_MailID FROM dbo.jct_ops_outsourced_wardrobe a INNER JOIN dbo.MISTEL b ON a.enteredby=b.empcode WHERE a.reqid='" + ViewState["ID"] + "'";
                try
                {
                    to = objFun.FetchValue(sql).ToString();
                }
                catch { to = "jatindutta@jctltd.com,shwetaloria@jctltd.com"; }

                to = "shwetaloria@jctltd.com";
              //  bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com,jatindutta@jctltd.com";
                //bcc = "jatindutta@jctltd.com,shwetaloria@jctltd.com,rajan@jctltd.com";
                //cc = "skpalta@jctltd.com,arvindsharma@jctltd.com,dpbadhwar@jctltd.com";

                Body = GetPage(url);//GetPage("http://testerp/FusionApps/OPS/AuthorizationRemarks.aspx");


                #endregion
            }
   
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
            //lblError.Text = "Error : " + ex.Message;
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

        //currentPageUrl = currentPageUrl.Replace("http://localhost:4297/FusionApps1/OPS/yarn_approvals.aspx", page_name);

        currentPageUrl = page_name;

        UTF8Encoding utf8 = new UTF8Encoding();

        requestHTML = myclient.DownloadData(currentPageUrl);
        myPageHTML = utf8.GetString(requestHTML);

        //Response.Write(myPageHTML)

        return myPageHTML;

    }

    protected void SendMailJobWork()
    {
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;
        string sql = string.Empty;


        sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //con.Open();
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                ViewState["AuthorisedBy"] = Dr["empname"].ToString();
                ViewState["AuthorisedByEmail"] = Dr["email"].ToString();
            }
        }
        else
        {
            ViewState["AuthorisedBy"] = "";
            ViewState["AuthorisedByEmail"] = "jatindutta@jctltd.com";
        }

        Dr.Close();
       // con.Close();

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
        sb.AppendLine("Outsourced jobWork Request Authorised.<br/><br/>");


        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");
        sb.AppendLine("<tr><th> RequestID  </th> <th>RequiredQty</th> <th>Sortno</th> <th>MarketingExecutive</th> <th> DeliveryDate </th><th> Remarks </th><th> Request By </th> <th> Entry Date </th> <th> Authorised By </th> <th> Plant </th> </tr> ");
        sql = "jct_ops_outsourced_jobwork_mail_content";
        cmd = new SqlCommand(sql, obj.Connection());
        //con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Reqid", SqlDbType.VarChar).Value = ViewState["RequestID"];
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while ((Dr.Read()))
            {
                sb.AppendLine("<tr> <td>  " + Dr["reqid"].ToString() + " </td> <td>  " + Dr["Qtyreq"].ToString() + " </td>  <td> " + Dr["sortno"].ToString() + "</td>  <td> " + Dr["mkt_exe"] + "</td>  <td> " + Dr["deliveryDate"].ToString() + "</td><td> " + Dr["remarks"].ToString() + "</td><td> " + Dr["RequestBy"].ToString() + "</td><td> " + Dr["EntryDt"].ToString() + "</td><td> " + ViewState["AuthorisedBy"] + "</td><td> " + Dr["Plant"].ToString() + "</td> </tr> ");
            }
        }

        Dr.Close();
        //con.Close();
        sb.AppendLine("</table>");
        sb.AppendLine("<br /><br/>");
        sb.AppendLine("</table><br />");

        sb.AppendLine("PO can be genereted for this request.<br/><br />");
        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";

        to = ViewState["AuthorisedByEmail"].ToString();
        //to = "jatindutta@jctltd.com";
        // to = ViewState["RequestByEmail"].ToString() + ",amit@jctltd.com";

        bcc = "shwetaloria@jctltd.com,jatindutta@jctltd.com,rajan@jctltd.com";
        subject = "Outsourced JobWork RequestId - " + ViewState["RequestID"];
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
        //If Not String.IsNullOrEmpty(cc) Then
        //    If cc.Contains(",") Then
        //        Dim ccs As String() = cc.Split(","c)
        //        For i As Integer = 0 To ccs.Length - 1
        //            mail.CC.Add(New MailAddress(ccs(i)))
        //        Next
        //    Else
        //        mail.CC.Add(New MailAddress(bcc))
        //    End If
        //    mail.CC.Add(New MailAddress(cc))
        //End If

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



