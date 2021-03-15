using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;

public partial class OPS_DevelopmentRequestAttachments : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sqlStr = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //sqlStr = "SELECT RequestID,RequestedBy,DESCRIPTION,ProspectCust,ProspectCustName,SortNo,Req_Mtrs,Finish,no_of_shades,EndUse,Segment,Devlopment,EnquiryNo,DevlopmentNo,RequiredOn FROM dbo.Jct_Ops_Devlopment_Request WHERE Auth_Status='P'";
            sqlStr = "Jct_Ops_Get_Devlopment_Request";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, obj.Connection());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@Parameter", SqlDbType.VarChar, 50).Value = "Authorize Request";
            sqlCommand.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = "A-00098";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            RadGrid1.DataSource = dataSet.Tables[0];
            RadGrid1.DataBind();
        }
    }

    protected void grid_request_fill()
    {

        sqlStr = "Jct_Ops_Get_Devlopment_Request";
        SqlCommand sqlCommand = new SqlCommand(sqlStr, obj.Connection());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@Parameter", SqlDbType.VarChar, 50).Value = "Authorize Request";
        sqlCommand.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = "A-00098";
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);

        RadGrid1.DataSource = dataSet.Tables[0];
         

    }

    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (!IsPostBack && e.Item is GridFilteringItem)
        {
            //e.Item.Style["RequestID"] = "none";
            //e.Item.Style["DESCRIPTION"] = "none";
            //e.Item.Style["Devlopment"] = "none";
            //e.Item.Style["Req_Mtrs"] = "none";
        }


        if (e.Item is GridDataItem)
        {
           // LinkButton PopUp = (LinkButton)e.Item.FindControl("lnkPopUp");

            //PopUp.Attributes["href"] = "javascript:void(0);";
            //PopUp.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}','{2}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RequestID"], e.Item.ItemIndex, "link");
   
        }
    }

    //protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    //{
    //    if (e.Argument == "Rebind")
    //    {
    //        RadGrid1.MasterTableView.SortExpressions.Clear();
    //        RadGrid1.MasterTableView.GroupByExpressions.Clear();
    //        RadGrid1.Rebind();
    //    }
    //    else if (e.Argument == "RebindAndNavigate")
    //    {
    //        RadGrid1.MasterTableView.SortExpressions.Clear();
    //        RadGrid1.MasterTableView.GroupByExpressions.Clear();
    //        RadGrid1.MasterTableView.CurrentPageIndex = RadGrid1.MasterTableView.PageCount - 1;
    //        RadGrid1.Rebind();
    //    }
    //}

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        grid_request_fill();
    }

    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        //GridItem commandItem = RadGrid1.MasterTableView.GetItems(GridItemType.CommandItem)[0];
        //CheckBox cbox = (CheckBox)commandItem.FindControl("chb_AllRequest");
        //if (ViewState["CheckBox"] == "true")
        //    cbox.Checked = true;
        //else
        //    cbox.Checked = false;
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridCommandItem)
        //{
        //    GridCommandItem cmditm = (GridCommandItem)e.Item;
        //    LinkButton lnkbtn1 = (LinkButton)cmditm.FindControl("InitInsertButton");
        //    lnkbtn1.Visible = false;  
        //}

        if (e.Item is GridDataItem)
        {
            //GridDataItem dataitem = e.Item as GridDataItem;
            //Image img = (Image)dataitem.FindControl("img_Ok");
            //HyperLink hlkLink = (HyperLink)dataitem.FindControl("EditLink");
            //HyperLink hlkTaskStatus = (HyperLink)dataitem.FindControl("EditTaskStatus");

            //if (img.ImageUrl == "~/Image/AvailabilityFalse.png")
            //{
            //    e.Item.Cells[11].Visible = false;
            //    hlkTaskStatus.Visible = false;
            //}
            //else if (img.ImageUrl == "~/Image/AvailabilityTrue.png")
            //{
            //    e.Item.Cells[11].Visible = true;
            //    hlkTaskStatus.Visible = true;
            //}

        }

        if (e.Item is GridFooterItem)
        {

        }

    }

    protected void ButtonSubmitClick(object sender, EventArgs e)
    {
        try
        {

            if (ViewState["RequestID"] != string.Empty || ViewState["RequestID"] != null)
            {
                foreach (UploadedFile file in AsyncUpload1.UploadedFiles)
                {
                    string FileName = System.IO.Path.GetFileName(file.FileName);
                    //file.SaveAs(Server.MapPath("Attached_Files\\") + FileName);
                    //file.Add(FileName);

                    string ext = Path.GetExtension(FileName);
                    string contenttype = String.Empty;

                    //Set the contenttype based on File Extension
                    switch (ext)
                    {
                        case ".doc":
                            contenttype = "application/vnd.ms-word";
                            break;
                        case ".docx":
                            contenttype = "application/vnd.ms-word";
                            break;
                        case ".xls":
                            contenttype = "application/vnd.ms-excel";
                            break;
                        case ".xlsx":
                            contenttype = "application/vnd.ms-excel";
                            break;
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;
                        case ".eml":
                            contenttype = "application/eml";
                            break;
                        case ".htm":
                            contenttype = "application/htm";
                            break;
                        case ".html":
                            contenttype = "application/html";
                            break;
                    }


                    Stream fs = file.InputStream;//PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                    if (contenttype != String.Empty)
                    {
                        //insert the file into database
                        //string strQuery = "insert into tblFiles(Name, ContentType, Data)" +
                        //   " values (@Name, @ContentType, @Data)";

                        string strQuery = "jct_ops_development_request_attach_files";
                        SqlCommand cmd = new SqlCommand(strQuery, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState["RequestID"];
                        cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName;
                        cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype;
                        cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                        cmd.ExecuteNonQuery();//InsertUpdateData(cmd);
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "File Uploaded Successfully";
                    }
                    else
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "File format not recognised." +
                        " Upload Image/Word/PDF/Excel formats";
                        return;
                    }
                }


            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select record to attach files.";
                return;
            }

        }
       
        catch(Exception ex)
        { 
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "No File uploaded : " + ex.Message ;
                return;
        }
    }
    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
            var dataItem = RadGrid1.SelectedItems[0] as GridDataItem; 

            if (dataItem != null) 
	        { 
                ViewState["RequestID"]= dataItem["RequestID"].Text; 
	        }
    }
}
