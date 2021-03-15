using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class OPS_DevelopmentFeedback : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sqlStr = string.Empty;
    bool chk_Select = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //sqlStr = "SELECT RequestID,RequestedBy,DESCRIPTION,ProspectCust,ProspectCustName,SortNo,Req_Mtrs,Finish,no_of_shades,EndUse,Segment,Devlopment,EnquiryNo,DevlopmentNo,RequiredOn FROM dbo.Jct_Ops_Devlopment_Request WHERE Auth_Status='P'";
            sqlStr = "jct_ops_development_request_select";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, obj.Connection());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@chk_record_exist", SqlDbType.Bit).Value = chk_Select == false ? 0 : 1 ;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            RadGrid1.DataSource = dataSet.Tables[0];
            RadGrid1.DataBind();
        }
    }

    protected void grid_request_fill()
    {
        bool a = chk_Select;

        sqlStr = "jct_ops_development_request_select";
        SqlCommand sqlCommand = new SqlCommand(sqlStr, obj.Connection());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@chk_record_exist", SqlDbType.Bit).Value = chk_Select == false ? 0 : 1;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);

        RadGrid1.DataSource = dataSet.Tables[0];
        
    }

         protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (!IsPostBack && e.Item is GridFilteringItem)
            {
                e.Item.Style["RequestID"] = "none";
                e.Item.Style["DESCRIPTION"] = "none";
                e.Item.Style["Devlopment"] = "none";
                e.Item.Style["Req_Mtrs"] = "none";
            }  


            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                HyperLink editTaskStatus = (HyperLink)e.Item.FindControl("EditTaskStatus");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}','{2}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RequestID"], e.Item.ItemIndex,"link");

                editTaskStatus.Attributes["href"] = "javascript:void(0);";
                editTaskStatus.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}','{2}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RequestID"], e.Item.ItemIndex, "taskstatus");
            }
        }

    
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {
                RadGrid1.MasterTableView.SortExpressions.Clear();
                RadGrid1.MasterTableView.GroupByExpressions.Clear();
                RadGrid1.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                RadGrid1.MasterTableView.SortExpressions.Clear();
                RadGrid1.MasterTableView.GroupByExpressions.Clear();
                RadGrid1.MasterTableView.CurrentPageIndex = RadGrid1.MasterTableView.PageCount - 1;
                RadGrid1.Rebind();
            }
        }
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            grid_request_fill();
        }
        protected void chb_AllRequest_CheckedChanged(object sender, EventArgs e)
        {
           
            CheckBox chkbox =(CheckBox)sender; 
 
            if (chkbox.Checked) 
            {
                chk_Select = true;
                ViewState["CheckBox"] = "true"; 
            } 
            else 
            {
                chk_Select = false;
                ViewState["CheckBox"] = "false"; 
            }

            grid_request_fill();
            RadGrid1.Rebind();
   
        }
        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            GridItem commandItem = RadGrid1.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            CheckBox cbox = (CheckBox)commandItem.FindControl("chb_AllRequest");
            if (ViewState["CheckBox"] == "true")
                cbox.Checked = true;
            else
                cbox.Checked = false; 
        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataitem = e.Item as GridDataItem;
                    Image img = (Image)dataitem.FindControl("img_Ok");
                    HyperLink hlkLink = (HyperLink)dataitem.FindControl("EditLink");
                    HyperLink hlkTaskStatus = (HyperLink)dataitem.FindControl("EditTaskStatus");

                    if (img.ImageUrl == "~/Image/AvailabilityFalse.png")
                    {
                        e.Item.Cells[11].Visible = false;
                        hlkTaskStatus.Visible = false;
                    }
                    else if (img.ImageUrl == "~/Image/AvailabilityTrue.png")
                    {
                        e.Item.Cells[11].Visible = true;
                        hlkTaskStatus.Visible = true;
                    }
                    
                }
 
                if (e.Item is GridFooterItem)
                {

                }

        }
}
