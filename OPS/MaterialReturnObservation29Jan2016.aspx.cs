﻿using System;
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



public partial class OPS_MaterialReturnObservation : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions objFun = new Functions();
    string qry;
    string sql;
    SqlConnection con;
    Connection cn;
    string shpConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["jctdevConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(shpConnectionString);
        cn = new Connection(shpConnectionString);
        if( Session["empcode"].ToString() == "")
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack == true)
        {
            ddlObservationType_SelectedIndexChanged(sender, e);

            HtmlForm frm = new HtmlForm();
            frm = (HtmlForm)this.Master.FindControl("form1");
            frm.Enctype = "multipart/form-data";

        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlObservationType.SelectedItem.Text == "Normal Return")
        {
            ViewState["SanctionID"] = null;
            ViewState["SanctionID"] = GridView1.SelectedRow.Cells[2].Text;
        }
        else if (ddlObservationType.SelectedItem.Text == "Excess Return")
        {
            //ViewState["SanctionID"] = null;
            //ViewState["SanctionID"] = GridView1.SelectedRow.Cells[5].Text;

            ViewState["SanctionID"] = null;
            ViewState["SanctionID"] = GridView1.SelectedRow.Cells[2].Text;
        }

        if (ddlObservationType.SelectedItem.Text == "Short Return")
        {
            ViewState["SanctionID"] = null;
            ViewState["SanctionID"] = GridView1.SelectedRow.Cells[2].Text;
        }


        qry = "JCT_OPS_MR_FOLDING_OBSERVATION ' " + ViewState["SanctionID"] + "',' ' ";  //Procedure changed )3 Dec 2015

        objFun.FillGrid(qry, ref Grdinvoices);
        Grdinvoices.Visible = true;





    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        if (ddlObservationType.SelectedItem.Text == "Excess Return")
        {
            qry = "JCT_OPS_Mr_Folding_Observation_Excess_Fetch  '01/01/2014','01/01/2020','',1014,'" + txtID.Text + "','',''";
            objFun.FillGrid(qry, ref GridView1);
            ViewState["SanctionID"] = null;
            ViewState["SanctionID"] = txtID.Text;
        }

    }

    protected void ddlObservationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lblMr.Visible = false;
        txtID.Visible = false;
        LinkButton3.Visible = false;
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (ddlObservationType.SelectedItem.Text == "Normal Return")
        {
            string AreaName;
            AreaName = string.Empty;

            AreaName = "Material Return";

            qry = "Jct_Ops_Mr_Folding_Observation_Fetch '" + Session["Empcode"].ToString() + "','" + AreaName + "'";
            //objFun.FillGrid(qry, GridView1)
            objFun.FillGrid(qry, ref GridView1);
        }

        //if (ddlObservationType.SelectedItem.Text == "Excess Return")
        //{
        //    //lblMr.Visible = true;
        //    txtID.Visible = true;
        //    LinkButton3.Visible = true;


        //}

        if (ddlObservationType.SelectedItem.Text == "Excess Return")
        {
            string AreaName;
            AreaName = string.Empty;

            AreaName = "Material Return";

            qry = "Jct_Ops_Mr_Folding_Observation_Fetch '" + Session["Empcode"].ToString() + "','" + AreaName + "'";
            //objFun.FillGrid(qry, GridView1)
            objFun.FillGrid(qry, ref GridView1);


        }



        if (ddlObservationType.SelectedItem.Text == "Short Return")
        {
            string AreaName;
            AreaName = string.Empty;

            AreaName = "Material Return";

            qry = "Jct_Ops_Mr_Folding_Observation_Fetch '" + Session["Empcode"].ToString() + "','" + AreaName + "'";
            //objFun.FillGrid(qry, GridView1)
            objFun.FillGrid(qry, ref GridView1);
        }


        GridView2.Visible = false;
        GridView2.DataSource = null;
        GridView2.DataBind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlTransaction tran = default(SqlTransaction);

        string script = string.Empty;
        string str = string.Empty;
        string str1, str2;
        double mtrs = 0;
        string shade, packing, type, observation, reason, returntype;
        string NotifyEmailGroup = string.Empty;
        SqlCommand cmd = new SqlCommand();
        string id = ViewState["SanctionID"].ToString().Trim();

        string invoice = Grdinvoices.SelectedRow.Cells[1].Text;
        string order = Grdinvoices.SelectedRow.Cells[2].Text;
        string sort = Grdinvoices.SelectedRow.Cells[3].Text;
        double invoiceqty = Convert.ToDouble(Grdinvoices.SelectedRow.Cells[4].Text);
        double returnqty = Convert.ToDouble(Grdinvoices.SelectedRow.Cells[5].Text);

        if (ViewState["SanctionID"] != null)
        {

            foreach (GridViewRow gvRow in GridView2.Rows)
            {
                TextBox TxtMeters = (TextBox)gvRow.FindControl("txtMeters");
                mtrs = mtrs + Convert.ToDouble(TxtMeters.Text);
                //if (mtrs + 50 > returnqty)
                //{
                //    script = "alert('Observed Mtrs Exceeded Return Quanity');";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //    return;
                //}
                //str = "Select SUM(meters) from Jct_Ops_Folding_Observation_Detail where SanctionNoteID='" + id + "' and InvoiceNo='"+invoice+"'";

                //cmd = new SqlCommand(str, cn.Connection());

                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
              

            }
            try
            {
                con = new SqlConnection(shpConnectionString);
                con.Open();
                tran = con.BeginTransaction();
               foreach (GridViewRow gvRow in GridView2.Rows)
                {

                    TextBox TxtShade = (TextBox)gvRow.FindControl("txtShade");
                    DropDownList DdlPackingType = (DropDownList)gvRow.FindControl("ddlPackingType");
                    TextBox TxtMeters = (TextBox)gvRow.FindControl("txtMeters");
                    DropDownList DdlType = (DropDownList)gvRow.FindControl("ddlType");
                    TextBox TxtObservation = (TextBox)gvRow.FindControl("txtObservation");
                    DropDownList DdlReason = (DropDownList)gvRow.FindControl("ddlReason");
                    mtrs = Convert.ToDouble(TxtMeters.Text);
                    shade = TxtShade.Text;
                    packing = DdlPackingType.SelectedItem.Text;
                    type = DdlType.SelectedItem.Text;
                    observation = TxtObservation.Text;
                    reason = DdlReason.SelectedItem.Text;
                    returntype = ddlObservationType.SelectedItem.Text;
                    string host = Request.ServerVariables["REMOTE_ADDR"];
                    string createdby = Session["EmpCode"].ToString();

                    str1 = "insert into Jct_Ops_Folding_Observation_Detail(OrderNo,SortNo,Shade,PackingType,Meters,Types,Observation,Created_dt,Created_By,HostIp,Status,SanctionNoteID, ReturnType ,InvoiceNo ,InvoiceQty  )";
                    str2 = " values('" + Grdinvoices.SelectedRow.Cells[2].Text + "','" + sort + "','" + shade + "','" + packing + "'," + mtrs + ",'" + type + "','" + observation + "','" + DateTime.Now + "','" + createdby + "','" + host + "',NULL,'" + id + "','" + returntype + "','" + invoice + "'," + invoiceqty + ")";
                    str1 = str1 + str2;
                    cmd.Transaction = tran;
                    cmd.CommandText = str1;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    script = "alert('Details saved!!');";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);



                }
                tran.Commit();
                UpdateStatus();


                qry = "JCT_OPS_MR_FOLDING_OBSERVATION ' " + ViewState["SanctionID"] + "',' ' "; 
                Grdinvoices.DataSource = null;
                Grdinvoices.DataBind();
                objFun.FillGrid(qry, ref Grdinvoices);
                Grdinvoices.Visible = false;


                //ddlObservationType_SelectedIndexChanged(sender, e);
                GridView1.DataSource = null;
                GridView1.DataBind();
               ddlObservationType_SelectedIndexChanged(sender, e);


                NotifyEmailGroup = "Noreply@jctltd.com";
                cmd = new SqlCommand("Jct_MrClosure_Notify_Users_Mr", obj.Connection());
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



                sendmail(Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "hitesh@jctltd.com,hiren@jctltd.com,sandeepr@jctltd.com");

                //ViewState["SanctionID"] = null;  commented by sandeep


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
        }

    }

    public void UpdateStatus()
    {



        using (SqlConnection con = new SqlConnection(shpConnectionString))
        {

            using (SqlCommand cmd = new SqlCommand("Jct_Ops_Folding_Observation_Status", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@RequestId", SqlDbType.VarChar).Value = ViewState["SanctionID"]; 
             
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
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
                //subject = "Material Return observation" + "    " + "To" + "   " + too + "cc" + "    " + NotifyEmailGroup + "   " + "Bcc" + " " + bccc;
                subject = "Material Return observation";

                querystring = "SanctionID=" + ViewState["SanctionID"];
                querystring1 = Session["Empcode"].ToString();
                querystring2 = ddlObservationType.SelectedItem.Text.ToString();

            }


            //  url = "http://localhost:1733/FusionApps/ops/MrFoldingObservationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;
            // url = "http://test2k/FusionApps/ops/MrFoldingObservationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;
            url = "http://testerp/FusionApps/ops/MrFoldingObservationMail.aspx?" + querystring + "&Empcode=" + querystring1 + "&Returntype=" + querystring2;




            if (ddlObservationType.SelectedItem.Text == "Excess Return")
            {
                @from = "ExcessStock@jctltd.com";

            }
            else if (ddlObservationType.SelectedItem.Text == "Short Return")
            {
                @from = "ShortStock@jctltd.com";

            }
            else
            {
                @from = "Noreply@jctltd.com";
            }


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
        Response.Redirect("MaterialReturnObservation.aspx");
    }

    protected void uploadDoc(int i, string Sanctionid)
    {
        try
        {
            HttpPostedFile PostedFile = Request.Files[i];
            if (PostedFile.ContentLength > 0)
            {
                string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                string filepath = Server.MapPath("Upload\\FoldingObservation\\") + Sanctionid + "\\";
                //PostedFile.SaveAs(Server.MapPath(filepath));
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                FileName = FileName.Replace("#", "");
                FileName = FileName.Replace("@", "");
                FileName = FileName.Replace("$", "");
                FileName = FileName.Replace("&", "");
                FileName = FileName.Replace("^", "");
                FileName = FileName.Replace("%", "");
                FileName = FileName.Replace("..", ".");
                PostedFile.SaveAs(filepath + FileName.Replace(" ", ""));
                //}
            }
        }
        catch
        {
            throw new Exception();
        }
    }

    protected void btnUpload_Click(object sender, ImageClickEventArgs e)
    {
        SqlTransaction tran = default(SqlTransaction);
        try
        {
            int i = 0;

          

            if (  ViewState["SanctionID"]== null)
            {
                string script1 = "alert('Please Select Request ID !!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
                return;
            }
            string sanctionid = ViewState["SanctionID"].ToString();
            tran = obj.Connection().BeginTransaction();
            for (i = 0; i <= Request.Files.Count - 1; i++)
            {
                HttpPostedFile PostedFile = Request.Files[i];
                string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                FileName = FileName.Replace("#", "");
                FileName = FileName.Replace("@", "");
                FileName = FileName.Replace("$", "");
                FileName = FileName.Replace("&", "");
                FileName = FileName.Replace("^", "");
                FileName = FileName.Replace("%", "");
                FileName = FileName.Replace("..", ".");
                string filepath = "\\OPS\\Upload\\FoldingObservation\\" + sanctionid + "\\";

                if (!string.IsNullOrEmpty(FileName) & !string.IsNullOrEmpty(filepath))
                {
                    SqlCommand cmd = new SqlCommand("Jct_Ops_Folding_Observation_Doc_Insert", obj.Connection(), tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("BaseDocNo", SqlDbType.VarChar, 20).Value = sanctionid;
                    cmd.Parameters.Add("RefDocFilePath", SqlDbType.VarChar, 2000).Value = filepath;
                    cmd.Parameters.Add("RefDocActFileName", SqlDbType.VarChar, 500).Value = FileName.Replace(" ", "");
                    string[] ext = PostedFile.FileName.Split('.');
                    //[PostedFile.FileName.LastIndexOf('.') + 1];
                    string fileext = ext[ext.Length - 1];
                    cmd.Parameters.Add("RefDocFileExt", SqlDbType.VarChar, 4).Value = fileext;
                    cmd.Parameters.Add("UserId", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
                    cmd.Parameters.Add("HostId", SqlDbType.VarChar, 50).Value = Request.UserHostName;
                    cmd.ExecuteNonQuery();
                    uploadDoc(i, sanctionid);

                    string message = "alert('UPloading File Done . Now Click On Apply To Save')";
                    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);

                }
                else
                {
                    string message = "alert('Please try again .File Uploading not completed.')";
                    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);

                }
            }
            tran.Commit();
            BindUploadedDocs(sanctionid);
        }

        catch (Exception ex)
        {


            if (ViewState["SanctionID"] == null)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);

                //string message1 = "alert('Please Select Observation Type')";
                //ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message1, true);

            }
            else
            {
                tran.Rollback();
            }

        }

    }


    public void BindUploadedDocs(string sanctionid)
    {
        qry = "jct_ops_get_Mr_Observation_docs";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DocNo", SqlDbType.VarChar, 20).Value = sanctionid;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        DataList2.DataSource = dt;
        DataList2.DataBind();
    }


    private void fun2()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (GridView2.Rows.Count > 0)
            {
                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {


                    //TextBox TxtOrderNo = (TextBox)GridView2.Rows[i].Cells[0].FindControl("Invoice_No");
                    //TextBox TxtSort = (TextBox)GridView2.Rows[i].Cells[1].FindControl("txtSort");
                    TextBox TxtShade = (TextBox)GridView2.Rows[i].Cells[2].FindControl("txtShade");
                    DropDownList DdlPackingType = (DropDownList)GridView2.Rows[i].Cells[3].FindControl("ddlPackingType");
                    Label LblShowText = (Label)GridView2.Rows[i].Cells[3].FindControl("lblShowText");
                    TextBox TxtMeters = (TextBox)GridView2.Rows[i].Cells[4].FindControl("txtMeters");
                    DropDownList DdlType = (DropDownList)GridView2.Rows[i].Cells[5].FindControl("ddlType");
                    TextBox TxtObservation = (TextBox)GridView2.Rows[i].Cells[6].FindControl("txtObservation");
                    DropDownList DdlReason = (DropDownList)GridView2.Rows[i].Cells[7].FindControl("ddlReason");

                    //dtCurrentTable.Rows[i]["OrderNo"] = TxtOrderNo.Text.ToString();
                    //dtCurrentTable.Rows[i]["SortNo"] = TxtSort.Text.ToString();
                    dtCurrentTable.Rows[i]["Shade"] = TxtShade.Text.ToString();
                    dtCurrentTable.Rows[i]["PackingType"] = DdlPackingType.SelectedItem.Text;
                    dtCurrentTable.Rows[i]["Meters"] = TxtMeters.Text.ToString() == "" ? "0" : TxtMeters.Text.ToString();
                    dtCurrentTable.Rows[i]["Type"] = DdlType.SelectedItem.Text.ToString();
                    dtCurrentTable.Rows[i]["Observation"] = TxtObservation.Text.ToString();
                    dtCurrentTable.Rows[i]["Reason"] = DdlReason.SelectedItem.Text.ToString();

                }
                drCurrentRow = dtCurrentTable.NewRow();
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                GridView2.DataSource = dtCurrentTable;
                GridView2.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

    }

    protected void lnkaddrow_Click(object sender, EventArgs e)
    {
        fun2();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "deleterow")
            {
                int rowIndex = 0;
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    rowIndex = gvr.RowIndex;
                    dt.Rows.RemoveAt(rowIndex);
                    //GridView2.DataSource = dt;
                    //GridView2.DataBind();
                    //SetPreviousData();


                    SetPreviousData();
                }

            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            int Rowindex = e.Row.RowIndex;
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlPackingType");
            DropDownList DdlReason = (DropDownList)e.Row.FindControl("ddlReason");
            if ((dt != null) && (Rowindex >= 0) && dt.Rows.Count > 1)
            {
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(dt.Rows[Rowindex]["PackingType"].ToString()));
                DdlReason.SelectedIndex = DdlReason.Items.IndexOf(DdlReason.Items.FindByText(dt.Rows[Rowindex]["Reason"].ToString()));
            }



        }


    }

    private void SetPreviousData()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtcurrenttable1 = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtcurrenttable1.Rows.Count > 0)
            {
                for (int i = 0; i <= dtcurrenttable1.Rows.Count - 1; i++)
                {

                    //TextBox TxtOrderNo = (TextBox)GridView2.Rows[i].Cells[0].FindControl("txtOrderNo");
                    //TextBox TxtSort = (TextBox)GridView2.Rows[i].Cells[1].FindControl("txtSort");
                    TextBox TxtShade = (TextBox)GridView2.Rows[i].Cells[2].FindControl("txtShade");
                    DropDownList DdlPackingType = (DropDownList)GridView2.Rows[i].Cells[3].FindControl("ddlPackingType");
                    Label LblShowText = (Label)GridView2.Rows[i].Cells[3].FindControl("lblShowText");
                    TextBox TxtMeters = (TextBox)GridView2.Rows[i].Cells[4].FindControl("txtMeters");
                    DropDownList DdlType = (DropDownList)GridView2.Rows[i].Cells[5].FindControl("ddlType");
                    TextBox TxtObservation = (TextBox)GridView2.Rows[i].Cells[6].FindControl("txtObservation");
                    DropDownList DdlReason = (DropDownList)GridView2.Rows[i].Cells[7].FindControl("ddlReason");

                    //dtcurrenttable1.Rows[i]["OrderNo"] = TxtOrderNo.Text.ToString();
                    //dtcurrenttable1.Rows[i]["SortNo"] = TxtSort.Text.ToString();
                    dtcurrenttable1.Rows[i]["Shade"] = TxtShade.Text.ToString();
                    dtcurrenttable1.Rows[i]["PackingType"] = DdlPackingType.SelectedItem.Text;
                    dtcurrenttable1.Rows[i]["Meters"] = TxtMeters.Text.ToString();
                    dtcurrenttable1.Rows[i]["Type"] = DdlType.SelectedItem.Text.ToString();
                    dtcurrenttable1.Rows[i]["Observation"] = TxtObservation.Text.ToString();
                    dtcurrenttable1.Rows[i]["Reason"] = DdlReason.SelectedItem.Text.ToString();

                }
                //dtcurrenttable1.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtcurrenttable1;
                GridView2.DataSource = dtcurrenttable1;
                GridView2.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

    }



    protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            string filepath = Server.MapPath("Upload\\FoldingObservation\\") + ViewState["SanctionID"] + "\\";

            string strFileName = "";
            strFileName = e.CommandArgument.ToString();

            Response.Redirect("QutationDownloadFile.aspx?filepath=" + filepath + "&FileName=" + strFileName);

        }
    }
    protected void Grdinvoices_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ViewState["SanctionID"].ToString().Trim();

        string invoice = Grdinvoices.SelectedRow.Cells[1].Text;
        invoice = invoice.Trim();

        //qry = "JCT_OPS_MR_FOLDING_OBSERVATION ' " + id + "',' " + invoice + "'";  //Procedure changed )3 Dec 2015

        //objFun.FillGrid(qry, ref GridView2);

        //GridView2.Visible = true;


        qry = "JCT_OPS_MR_FOLDING_OBSERVATION";

        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@RequestId", SqlDbType.VarChar, 20).Value = id;
        cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 30).Value = invoice;

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
        ViewState["CurrentTable"] = dt;
        GridView2.Visible = true;




    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ddlObservationType_SelectedIndexChanged(sender, e);
        Grdinvoices.DataSource = null;
        Grdinvoices.DataBind();
    }
}