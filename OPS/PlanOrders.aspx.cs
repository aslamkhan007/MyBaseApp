using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net.Mail;
using Telerik.Web.UI;

public partial class OPS_PlanOrders : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;

    #region Variables

    int flag = 0;
    string gvUniqueID = String.Empty;
    int gvNewPageIndex = 0;
    int gvEditIndex = -1;
    string gvSortExpr = String.Empty;
    string script = "";

    private string gvSortDir
    {

        get { return ViewState["SortDirection"] as string ?? "ASC"; }

        set { ViewState["SortDirection"] = value; }

    }
    #endregion

    private string GetSortDirection()
    {
        switch (gvSortDir)
        {
            case "ASC":
                gvSortDir = "DESC";
                break;

            case "DESC":
                gvSortDir = "ASC";
                break;
        }
        return gvSortDir;
    }

    protected void grdParent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            GridViewRow row = e.Row;
            string strSort = string.Empty;

            // Make sure we aren't in header/footer rows
            if (row.DataItem == null)
            {
                return;
            }

            //Find Child GridView control
            //ViewState["Item"] = string.Empty;
            GridView gv = new GridView();
            gv = (GridView)row.FindControl("GridView2");
            TextBox GreighReq = (TextBox)row.FindControl("txtGreighReq");
            Label SortNo = (Label)row.FindControl("lblSortNo");
            //DropDownList Shed = (DropDownList)row.FindControl("Shed");
            //int IndexIs = Shed.Items.IndexOf(((ListItem)Shed.Items.FindByText("Bob")));
          
            
            Label OrderNo = (Label)row.FindControl("lblOrderNo");
            
            //Check if any additional conditions (Paging, Sorting, Editing, etc) to be applied on child GridView
            if (gv.UniqueID == gvUniqueID)
            {
                gv.PageIndex = gvNewPageIndex;
                gv.EditIndex = gvEditIndex;
                //Check if Sorting used
                if (gvSortExpr != string.Empty)
                {
                    GetSortDirection();
                    strSort = " ORDER BY " + string.Format("{0} {1}", gvSortExpr, gvSortDir);
                }
                //Expand the Child gridl
                ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + ((DataRowView)e.Row.DataItem)["OrderNo"].ToString() + "--" + ((DataRowView)e.Row.DataItem)["SortNo"].ToString() + "','one');</script>");
            }

            //Prepare the query for Child GridView by passing the Order No of the parent row

            //sql = "JCT_OPS_PLANNING_ORDER_DETAILS";
            sql = "JCT_OPS_PLANNING_ORDER_DETAILS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = SortNo.Text;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gv.DataSource = ds.Tables[0];  
            gv.DataBind();
        }

        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        GridView gvTemp = (GridView)sender;
        gvUniqueID = gvTemp.UniqueID;
        gvNewPageIndex = e.NewPageIndex;

        grdParentFill(txtOrderNo.Text,"");
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="Plan")
        {
            GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            HtmlAnchor a = (HtmlAnchor)row.FindControl("btnShowSimple");
            Button btn = (Button)row.FindControl("Button1");
            string   scrpt = " <script type=\"text/javascript\"> $(document).ready(function () {$(\"#btnShowSimple\").click(function (e) {  ShowDialog(false);  e.preventDefault();   }); $(\"#btnShowModal\").click(function (e) {  ShowDialog(true); e.preventDefault();}); $(\"#btnClose\").click(function (e) {  HideDialog();  e.preventDefault();   });   $(\"#btnSubmit\").click(function (e) {  var brand = $(\"#brands input:radio:checked\").val(); $(\"#output\").html(\"<b>Your favorite mobile brand: </b>\" + brand);  HideDialog();   e.preventDefault();  });});  function ShowDialog(modal) {$(\"#overlay\").show();  $(\"#dialog\").fadeIn(300);   if (modal) {     $(\"#overlay\").unbind(\"click\"); }   else {     $(\"#overlay\").click(function (e) {        HideDialog();       });       } } function HideDialog() { $(\"#overlay\").hide();   $(\"#dialog\").fadeOut(300);  } </script>"; 

            ClientScriptManager script = Page.ClientScript;
            script.RegisterClientScriptBlock(this.GetType(), "PopUp", scrpt);
        }

        if (e.CommandName == "Refresh")
        {
            try
            {
                GridView gvTemp = (GridView)sender;
                gvUniqueID = gvTemp.UniqueID;

                GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                //int RowIndex = gvRow.RowIndex;
                ////Get the values stored in the text boxes


                Label ID = (Label)gvRow.FindControl("lblID"); ;
                Label OrderNo = (Label)gvRow.FindControl("lblOrderNo");
                Label SortNo = (Label)gvRow.FindControl("lblSortNo");
                Label LineItem = (Label)gvRow.FindControl("lblLineItem");
                Label OrderQty = (Label)gvRow.FindControl("lblOrderQty");
                
                

                sql = "JCT_OPS_PLANNING_UPDATE_ORDER_QTY";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 30).Value = OrderNo.Text;
                cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = LineItem.Text;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        OrderQty.Text = dr[0].ToString();
                        SortNo.Text = dr[1].ToString();
                      
                    }
                }
                dr.Read();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
            }
        }

    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView gvTemp = (GridView)sender;
            gvUniqueID = gvTemp.UniqueID;
            gvEditIndex = e.NewEditIndex;
            grdParentFill(txtOrderNo.Text,txtSortNo.Text);

        }

        catch (Exception ex)
        {

            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    private void grdParentFill(string orderno, string itemno)
    {
        //sql = "JCT_OPS_PLANNING_ORDER_ITEMS";

        ViewState["OrderNo"] = orderno;
        ViewState["ItemNo"] = itemno;
        ViewState["PlanID"] = ddlPlanID.SelectedItem.Value;
        btnPopUp_Click(null, null);
       
    }

    protected void GridView2_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        gvUniqueID = gvTemp.UniqueID;
        gvEditIndex = -1;
        grdParentFill(txtOrderNo.Text,txtSortNo.Text);

    }

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridView gvTemp = (GridView)sender;
            gvUniqueID = gvTemp.UniqueID;

            //Get the values stored in the text boxes
            Label OrderNo = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblOrderNo");
            Label SortNo = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblSortNo");
            Label LineItem = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblLineItem");
            TextBox WeavingSort = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtWeavingSort");
            Label OrderQty = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblOrderQty");
            TextBox PlanQty = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtPlanQty");
            DropDownList CaseType = (DropDownList)gvTemp.Rows[e.RowIndex].FindControl("ddlCaseType");
            TextBox GreighReq = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtGreighReq");
            TextBox DeliveryDt = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtDeliveryDt");
            Label Shade = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblShade");
            Label Split = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblSplit");
            Label IndividualPlan = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblIPlan");
            Label ID = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblID");
            TextBox sizing = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtSizing");
            TextBox greigh_adj = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtGreighAdj");
            CheckBox Peach = (CheckBox)gvTemp.Rows[e.RowIndex].FindControl("chkPeach");

            GridViewRow gvRow = (GridViewRow)gvTemp.Parent.Parent;
            Label ParentID = (Label)gvRow.FindControl("lblID");

             
            
            //sql = "JCT_OPS_PLANING_ORDER_ITEMS_INSERT";
            sql = "JCT_OPS_PLANING_ORDER_ITEMS_INSERT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = OrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = SortNo.Text;
            cmd.Parameters.Add("@LineItem", SqlDbType.VarChar, 30).Value = LineItem.Text;
            cmd.Parameters.Add("@Qty", SqlDbType.VarChar, 30).Value = OrderQty.Text;
            cmd.Parameters.Add("@PlanQty", SqlDbType.VarChar, 30).Value = PlanQty.Text;
            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@GreighReq", SqlDbType.VarChar, 30).Value = GreighReq.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@Plan_ID", SqlDbType.VarChar, 20).Value = ddlPlanID.SelectedItem.Value;
            cmd.Parameters.Add("@DeliveryDt", SqlDbType.VarChar, 50).Value = DeliveryDt.Text;
            cmd.Parameters.Add("@Shade1", SqlDbType.VarChar, 50).Value = Shade.Text;
            cmd.Parameters.Add("@Split", SqlDbType.Char,1).Value = Split.Text;
            cmd.Parameters.Add("@IndividualPlan", SqlDbType.Char, 1).Value = IndividualPlan.Text;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(ID.Text);
            cmd.Parameters.Add("@ParentID", SqlDbType.Char,20).Value =  ParentID.Text;

            if (sizing.Text != string.Empty)
            {
                cmd.Parameters.Add("@sizing", SqlDbType.Decimal).Value = Convert.ToDecimal(sizing.Text);
            }
            else
            {
                return;
            }

            if (greigh_adj.Text != string.Empty)
            {
                cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_adj.Text);
            }
            if (Peach.Checked)
            {
                cmd.Parameters.Add("@Peach", SqlDbType.Char, 1).Value = 'Y';
            }
            
            cmd.ExecuteNonQuery();
        

            script = "alert('Order updated successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);


            //Reset Edit Index
            gvEditIndex = -1;

            //grdParent.DataBind();

            grdParentFill(OrderNo.Text,"");
        }
        catch (Exception ex)
        {

            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //Check if there is any exception while deleting
        if (e.Exception != null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
            e.ExceptionHandled = true;
        }
    }

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        gvUniqueID = gvTemp.UniqueID;

        //Get the value        
        string ID = ((Label)gvTemp.Rows[e.RowIndex].FindControl("lblID")).Text;

        //Prepare the Update Command of the DataSource control

        try
        {

            string order_no = ((Label)gvTemp.Rows[e.RowIndex].FindControl("lblOrderNo")).Text;

            string id = ((Label)gvTemp.Rows[e.RowIndex].FindControl("lblID")).Text;

            string Lineitem= ((Label)gvTemp.Rows[e.RowIndex].FindControl("lblLineItem")).Text;

            sql = "JCT_OPS_PLANNING_ORDER_DELETE_ITEM";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = order_no;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Lineitem;
            cmd.ExecuteNonQuery();

          

            script = "alert('Item Deleted Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            //Reset Edit Index
            gvEditIndex = -1;

            //grdParent.DataBind();

            grdParentFill(order_no,"");
        }
        catch (Exception ex)
        {

            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }

    protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        //Check if there is any exception while deleting
        if (e.Exception != null)
        {

            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
            e.ExceptionHandled = true;
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Check if this is our Blank Row being databound, if so make the row invisible
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>function expandcollapse1(obj, row) { var div = document.getElementById(obj); var img = document.getElementById('img' + obj);if (div.style.display== 'none') { div.style.display = 'none'; } else { div.style.display = 'block'; } } </script>");
            //if (((DataRowView)e.Row.DataItem)["ID"].ToString() == String.Empty) e.Row.Visible = false;
        }



    }

    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        gvUniqueID = gvTemp.UniqueID;
        gvSortExpr = e.SortExpression;
        // grdParent.DataBind();

        grdParentFill(txtOrderNo.Text,"");
    }

    protected void ddlCaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList CaseType = (DropDownList)sender;
        GridViewRow gridRow = (GridViewRow)CaseType.Parent.Parent;

        
        Label OrderNo = (Label)gridRow.FindControl("lblOrderNo");
        Label SortNo = (Label)gridRow.FindControl("lblSortNo");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
        TextBox PlanQty = (TextBox)gridRow.FindControl("txtPlanQty");
        TextBox GreighReq = (TextBox)gridRow.FindControl("txtGreighReq");
        TextBox sizing = (TextBox)gridRow.FindControl("txtSizing");
        TextBox greigh_adj = (TextBox)gridRow.FindControl("txtGreighAdj");
        CheckBox Peach = (CheckBox)gridRow.FindControl("chkPeach");

        if (CaseType.SelectedIndex == 1)
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(PlanQty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            if (Peach.Checked)
            {
                cmd.Parameters.Add("@Peach", SqlDbType.Char, 1).Value = 'Y';
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr["Greigh"].ToString();
                    sizing.Text = dr["Sizing"].ToString();
                    greigh_adj.Text = "0.0";
                }
            }
            dr.Close();

        }
        else
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(PlanQty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            if (Peach.Checked)
            {
                cmd.Parameters.Add("@Peach", SqlDbType.Char, 1).Value = 'Y';
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr["Greigh"].ToString();
                    sizing.Text = dr["Sizing"].ToString();
                    greigh_adj.Text = "0.0";
                }
            }
            dr.Close();
        }
    }

    protected void chkPeach_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox Peach = (CheckBox)sender;
        GridViewRow gridRow = (GridViewRow)Peach.Parent.Parent;

        Label OrderNo = (Label)gridRow.FindControl("lblOrderNo");
        Label SortNo = (Label)gridRow.FindControl("lblSortNo");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
        TextBox PlanQty = (TextBox)gridRow.FindControl("txtPlanQty");
        TextBox GreighReq = (TextBox)gridRow.FindControl("txtGreighReq");
        TextBox sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList CaseType = (DropDownList)gridRow.FindControl("ddlcaseType");
        TextBox greigh_adj = (TextBox)gridRow.FindControl("txtGreighAdj");

        if (CaseType.SelectedIndex == 1)
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(PlanQty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_adj.Text);
            if (Peach.Checked)
            {
                cmd.Parameters.Add("@Peach", SqlDbType.Char, 1).Value = 'Y';
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr["Greigh"].ToString();
                    sizing.Text = dr["Sizing"].ToString();
                }
            }
            dr.Close();

        }
        else
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(PlanQty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_adj.Text);
            if (Peach.Checked)
            {
                cmd.Parameters.Add("@Peach", SqlDbType.Char, 1).Value = 'Y';
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr["Greigh"].ToString();
                    sizing.Text = dr["Sizing"].ToString();

                }
            }
            dr.Close();
        }
    }

    protected void grdParent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdParent.PageIndex = e.NewPageIndex;
        grdParentFill(txtOrderNo.Text,"");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Attributes.Add("onclick", "return PopUp();");

        if (!IsPostBack)
        {
            if (Request.QueryString["OrderNo"] != null)
            {
                txtOrderNo.Text = Request.QueryString["OrderNo"];
                //ddlPlanID.DataSourceID = "SqlDataSource2";
                //ddlPlanID.DataTextField = "PlanID";
                //ddlPlanID.DataValueField = "PlanID";
                //ddlPlanID.DataBind();
                sql = "SELECT PLANID,UPPER(Description) as Description FROM  dbo.JCT_OPS_PLANNING_GENERATE_PLANID WHERE STATUS='A' AND Plant='" + ddlPlant.SelectedItem.Text + "' order by planid desc";
                obj1.FillList(ddlPlanID, sql);
                grdParentFill(Request.QueryString["OrderNo"],"");
            }
            else
            {
                sql = "SELECT PLANID,UPPER(Description) as Description FROM  dbo.JCT_OPS_PLANNING_GENERATE_PLANID WHERE STATUS='A'  AND Plant='" + ddlPlant.SelectedItem.Text + "' order by planid desc";
                obj1.FillList(ddlPlanID, sql);
                //ddlPlanID.DataSourceID = "SqlDataSource2";
                //ddlPlanID.DataTextField = "PlanID";
                //ddlPlanID.DataValueField = "PlanID";
                //ddlPlanID.DataBind();
            }
        }

    }
   
    protected void lnkReset_Click(object sender, EventArgs e)
    {

    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        grdParentFill(txtOrderNo.Text,txtSortNo.Text);
        //GrdDetail_fill();

    }

    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow row = e.Row;
           
            Image img = (Image)row.FindControl("imgStatus");
            //Label GreighReq = (Label)row.FindControl("lblGreighReq");
            String GreighReq = (String)row.Cells[11].Text;
            String CaseType = (String)row.Cells[10].Text;

            //if (CaseType != "")
            //{
            //    img.ImageUrl = "../Image/Availabilitytrue.png";
            //}
            //else
            //{
            //    img.ImageUrl = "../Image/AvailabilityFalse.png";
            //}

           // string id = GreighReq.ClientID;
            //string uniqueid = gv.UniqueID;


            //e.Row.Attributes.Add("onmouseover", "this.className='SelectedRow'");
            //e.Row.Attributes.Add("onmouseout", "this.className='GridItem'");

            
            //if (flag == 0)
            //{
            //    flag = 1;
            //    string jquery = "  $(document).ready(function () { var droppedItemIndex = -1; $('.GridItem').draggable({ helper: \"clone\",   cursor: \"move\" }); $('#" + ViewState["GridView2ID"] + "').droppable({ drop: function (ev, ui) {  accept: '.GridItem',  droppedItemIndex = $(ui.draggable).index();  var droppedItem = $(\"#grdParent tr\").eq(droppedItemIndex); index = -1;  $(\"[id*=grdParent] #" + ViewState["GreighReq"] + "\").html(droppedItem.find(\"#"+ id +"\").html());} }); });";

            //    ClientScript.RegisterStartupScript(typeof(Page), "a key",
            //     "<script type=\"text/javascript\">" + jquery + "</script>"
            //     );

            //}
        }
    }

    protected void lblGreyReqdt_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void lblReqdt1_TextChanged(object sender, EventArgs e)
    {
        TextBox ReqDt = sender as TextBox;
        GridViewRow gridRow = (GridViewRow)ReqDt.Parent.Parent;
        TextBox GreighReqDt = (TextBox)gridRow.FindControl("lblGreyReqdt");
        Label WvgDays = (Label)gridRow.FindControl("lblWvgDays");
        TextBox Looms = (TextBox)gridRow.FindControl("txtLooms");

        sql = "Select Convert(varchar,Convert(DAtetime,'" + ReqDt.Text + "',103) - 15,103) ";
        GreighReqDt.Text = obj1.FetchValue(sql).ToString();
    }
    
    protected void txtGreighAdj_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox GreighAdj = (TextBox)sender;
            GridViewRow gridRow = (GridViewRow)GreighAdj.Parent.Parent;

            Label ID = (Label)gridRow.FindControl("lblID");
            Label OrderNo = (Label)gridRow.FindControl("lblOrderNo");
            Label SortNo = (Label)gridRow.FindControl("lblSortNo");
            TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
            Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
            TextBox PlanQty = (TextBox)gridRow.FindControl("txtPlanQty");
            TextBox GreighReq = (TextBox)gridRow.FindControl("txtGreighReq");
            TextBox GreighRem = (TextBox)gridRow.FindControl("txtGreighRem");
            TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");


            if (GreighReq.Text != "0")
            {
                decimal f = decimal.Parse(GreighReq.Text) - decimal.Parse(GreighAdj.Text);
                f = Math.Round(f, 2);
                GreighRem.Text = f.ToString();
                float Rem = float.Parse(GreighRem.Text);
                Sizing.Text = Rem.ToString();
                sql = "JCT_OPS_PLANNING_CALC_SIZING";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Greigh_Req", SqlDbType.Decimal).Value = GreighRem.Text;
                cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 20).Value = WeavingSort.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Sizing.Text = dr[0].ToString();
                        Sizing.Text = Sizing.Text;

                    }
                }
                dr.Close();
                obj.ConClose();

            }
        }

        catch
        { 
        
        }
        
    }

    protected void ddlShed_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList Shed = (DropDownList)sender;
            GridViewRow gridRow = (GridViewRow)Shed.Parent.Parent;
            TextBox Plan_Qty = (TextBox)gridRow.FindControl("txtPlanQty");
            Label Orderno = (Label)gridRow.FindControl("lblOrderno");
            TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
            TextBox GreighReq = (TextBox)gridRow.FindControl("txtGreighReq");
            TextBox GreighRem = (TextBox)gridRow.FindControl("txtGreighRem");
            Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
            TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");

            Label WvgDays = (Label)gridRow.FindControl("lblWvgCompletionDt");
            TextBox Looms = (TextBox)gridRow.FindControl("txtLoomAllot");
            TextBox RPM = (TextBox)gridRow.FindControl("txtRPM");
            TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");

          

            sql = "SELECT loom_rpm,efficiency FROM production..jct_fabric_dev_hdr WHERE loom_sec=left('" + Shed.SelectedItem.Value + "',1) AND sort_no='" + WeavingSort.Text + "' AND rev_no =(SELECT MAX(rev_no) FROM production..jct_fabric_dev_hdr where loom_sec=left('" + Shed.SelectedItem.Value + "',1) AND sort_no='" + WeavingSort.Text + "' )";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    RPM.Text = dr[0].ToString();
                    Efficiency.Text = dr[1].ToString();
                }
            }
            dr.Close();

            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(WeavingSort.Text);
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(Efficiency.Text=="" ? 0 : Convert.ToDecimal(Efficiency.Text));
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(RPM.Text =="" ? 0 : Convert.ToDecimal(RPM.Text));
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(Looms.Text=="" ? 1 : Convert.ToDecimal(Looms.Text));
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighRem.Text=="" ? 0: Convert.ToDecimal(GreighRem.Text));
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    WvgDays.Text = dr[6].ToString();
                    if (WvgDays.Text == "0")
                    {
                        script = "alert('No data found for this sort to be weaved in Selected Loom Shed.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }

                    RPM.Text = dr[1].ToString();
                    Efficiency.Text = dr[4].ToString();
                    Looms.Text = "1";
                }
            }
            else
            {
                WvgDays.Text = "0";
                script = "alert('No data found for sortno - "+ WeavingSort.Text +" to be weaved in "+ Shed.SelectedItem.Text +" Loom Shed.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
                //RPM.Text = "0";
                // Efficiency.Text = "0";

            }
            dr.Close();

           

        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }

    protected void txtLoomAllot_TextChanged(object sender, EventArgs e)
    {
        try
        {

            TextBox Looms = (TextBox)sender;

            GridViewRow gridRow = (GridViewRow)Looms.Parent.Parent;
            TextBox Plan_Qty = (TextBox)gridRow.FindControl("txtPlanQty");
            TextBox Greigh = (TextBox)gridRow.FindControl("txtGreighReq");
            TextBox GreighAjdustment = (TextBox)gridRow.FindControl("txtGreighAdj");
            Label Orderno = (Label)gridRow.FindControl("lblOrderNo");
            TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
            DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
            TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
            TextBox Grey_Remaining = (TextBox)gridRow.FindControl("txtGreighRem");
            TextBox RPM = (TextBox)gridRow.FindControl("txtRPM");
            TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");
            Label WvgDays = (Label)gridRow.FindControl("lblWvgCompletionDt");

            if (decimal.Parse(Looms.Text) != 0)
            {

                float GreighReq = float.Parse(Greigh.Text);
                float GreighAjd = float.Parse(GreighAjdustment.Text);
                float GreighRem = float.Parse(Grey_Remaining.Text);
               
               

                sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(WeavingSort.Text);
                cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
                cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(Efficiency.Text == "" ? 0 : Convert.ToDecimal(Efficiency.Text));
                cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(RPM.Text == "" ? 0 : Convert.ToDecimal(RPM.Text));
                cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(Looms.Text == "" ? 1 : Convert.ToDecimal(Looms.Text));
                cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(Grey_Remaining.Text == "" ? 0 : Convert.ToDecimal(Grey_Remaining.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        WvgDays.Text = dr[6].ToString();
                    }
                }
                else
                {
                    WvgDays.Text = "0";
                    script = "alert('No data found for sortno - " + WeavingSort.Text + " to be weaved in " + Shed.SelectedItem.Text + " Loom Shed.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }
                dr.Close();

            }
            else
            {


            }
        }
        catch (Exception ex)
        {
            string script = string.Format("alert('{0}');", "Please Select Shed Name First..!!");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
            return;
        }

    }

    protected void txtEfficiency_TextChanged(object sender, EventArgs e)
    {
        TextBox Efficiency = (TextBox)sender;

        GridViewRow gridRow = (GridViewRow)Efficiency.Parent.Parent;


        TextBox Plan_Qty = (TextBox)gridRow.FindControl("txtPlanQty");
        TextBox Greigh = (TextBox)gridRow.FindControl("txtGreighReq");
        TextBox GreighAjdustment = (TextBox)gridRow.FindControl("txtGreighAdj");
        Label Orderno = (Label)gridRow.FindControl("lblOrderNo");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
        TextBox Grey_Remaining = (TextBox)gridRow.FindControl("txtGreighRem");
        TextBox RPM = (TextBox)gridRow.FindControl("txtRPM");
        TextBox Looms = (TextBox)gridRow.FindControl("txtLoomAllot");
        Label WvgDays = (Label)gridRow.FindControl("lblWvgCompletionDt");


        if (decimal.Parse(Looms.Text) != 0)
        {
            float GreighReq = float.Parse(Greigh.Text);
            float GreighAjd = float.Parse(GreighAjdustment.Text);
            //float GreighRem = float.Parse(Sizing.Text) - GreighAjd;
            float GreighRem = float.Parse(Grey_Remaining.Text);
            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(WeavingSort.Text);
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(Efficiency.Text == "" ? 0 : Convert.ToDecimal(Efficiency.Text));
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(RPM.Text == "" ? 0 : Convert.ToDecimal(RPM.Text));
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(Looms.Text == "" ? 1 : Convert.ToDecimal(Looms.Text));
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(Grey_Remaining.Text == "" ? 0 : Convert.ToDecimal(Grey_Remaining.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    WvgDays.Text = dr[6].ToString();
                }
            }
            else
            {
                WvgDays.Text = "0";
                script = "alert('No data found for sortno - " + WeavingSort.Text + " to be weaved in " + Shed.SelectedItem.Text + " Loom Shed.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
            dr.Close();

        }
    }

    protected void txtRPM_TextChanged(object sender, EventArgs e)
    {
        TextBox RPM = (TextBox)sender;
        GridViewRow gridRow = (GridViewRow)RPM.Parent.Parent;


        TextBox Plan_Qty = (TextBox)gridRow.FindControl("txtPlanQty");
        TextBox Greigh = (TextBox)gridRow.FindControl("txtGreighReq");
        TextBox GreighAjdustment = (TextBox)gridRow.FindControl("txtGreighAdj");
        Label Orderno = (Label)gridRow.FindControl("lblOrderNo");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
        TextBox Grey_Remaining = (TextBox)gridRow.FindControl("txtGreighRem");
        TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");
        TextBox Looms = (TextBox)gridRow.FindControl("txtLoomAllot");
        Label WvgDays = (Label)gridRow.FindControl("lblWvgCompletionDt");


        if (decimal.Parse(Looms.Text) != 0)
        {
            float GreighReq = float.Parse(Greigh.Text);
            float GreighAjd = float.Parse(GreighAjdustment.Text);
            //float GreighRem = float.Parse(Sizing.Text) - GreighAjd;
            float GreighRem = float.Parse(Grey_Remaining.Text);
            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(WeavingSort.Text);
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(Efficiency.Text == "" ? 0 : Convert.ToDecimal(Efficiency.Text));
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(RPM.Text == "" ? 0 : Convert.ToDecimal(RPM.Text));
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(Looms.Text == "" ? 1 : Convert.ToDecimal(Looms.Text));
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(Grey_Remaining.Text == "" ? 0 : Convert.ToDecimal(Grey_Remaining.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    WvgDays.Text = dr[6].ToString();
                }
            }
            else
            {
                WvgDays.Text = "0";
                script = "alert('No data found for sortno - " + WeavingSort.Text + " to be weaved in " + Shed.SelectedItem.Text + " Loom Shed.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
            dr.Close();

        }
    }

    protected void lnkSaveRow_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton Save = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)Save.Parent.Parent;

            string Orderno = ((Label)gvRow.FindControl("lblOrderNo")).Text;
            string Sortno = ((Label)gvRow.FindControl("lblSortNo")).Text;
            string WeavingSort = ((TextBox)gvRow.FindControl("txtWeavingSort")).Text;
            string OrderQty = ((Label)gvRow.FindControl("lblOrderQty")).Text;
            string PlanQty = ((TextBox)gvRow.FindControl("txtPlanQty")).Text;
            string DeliveryDt = ((Label)gvRow.FindControl("lblDeliveryDt")).Text;
            string ExpectedDeliveryDt = ((TextBox)gvRow.FindControl("lblReqdt1")).Text;
            string GreighReqDt = ((TextBox)gvRow.FindControl("lblGreyReqdt")).Text;
            string GreighReq = ((TextBox)gvRow.FindControl("txtGreighReq")).Text;
            string GreighAdj = ((TextBox)gvRow.FindControl("txtGreighAdj")).Text;
            string GreighRem = ((TextBox)gvRow.FindControl("txtGreighRem")).Text;
            string Sizing = ((TextBox)gvRow.FindControl("txtSizing")).Text;
            string Shed = ((DropDownList)gvRow.FindControl("ddlShed")).Text;
            string Efficiency = ((TextBox)gvRow.FindControl("txtEfficiency")).Text;
            string RPM = ((TextBox)gvRow.FindControl("txtRPM")).Text;
            string Looms = ((TextBox)gvRow.FindControl("txtLoomAllot")).Text;
            string WvgDays = ((Label)gvRow.FindControl("lblWvgCompletionDt")).Text;
            string ID = ((Label)gvRow.FindControl("lblID")).Text;

            sql = "JCT_OPS_PLANNING_ORDER_INSERT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Char, 10).Value = ID;
            cmd.Parameters.Add("@PLANID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
            cmd.Parameters.Add("@Orderno", SqlDbType.VarChar, 25).Value = Orderno;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 25).Value = Sortno;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.Int).Value = WeavingSort;
            cmd.Parameters.Add("@OrderQty", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty);
            cmd.Parameters.Add("@PlanQty", SqlDbType.Decimal).Value = Convert.ToDecimal(PlanQty);
            cmd.Parameters.Add("@DeliveryDt", SqlDbType.VarChar, 20).Value = DeliveryDt;
            cmd.Parameters.Add("@ExpectedDeliveryDt", SqlDbType.VarChar, 20).Value = ExpectedDeliveryDt;
            cmd.Parameters.Add("@GreighReqDt", SqlDbType.VarChar, 20).Value = @GreighReqDt;
            cmd.Parameters.Add("@GreighReq", SqlDbType.Decimal).Value = Convert.ToDecimal(@GreighReq);
            cmd.Parameters.Add("@GreighAdj", SqlDbType.Decimal).Value = Convert.ToDecimal((@GreighAdj=="" ? 0: Convert.ToDecimal(@GreighAdj)));
            cmd.Parameters.Add("@GreighRem", SqlDbType.Decimal).Value = Convert.ToDecimal(@GreighRem);
            cmd.Parameters.Add("@Sizing", SqlDbType.Decimal).Value = Convert.ToDecimal(@Sizing);
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = @Shed;
            cmd.Parameters.Add("@Efficiency", SqlDbType.Int).Value = Convert.ToInt16(@Efficiency);
            cmd.Parameters.Add("@RPM", SqlDbType.Int).Value = Convert.ToInt16(@RPM);
            cmd.Parameters.Add("@Looms", SqlDbType.Decimal).Value = Convert.ToDecimal(@Looms);
            cmd.Parameters.Add("@WvgDays", SqlDbType.Decimal).Value = Convert.ToDecimal((@WvgDays == "" ? 0 : Convert.ToDecimal(@WvgDays)));
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@LineItem", SqlDbType.VarChar, 10).Value = "";

            cmd.ExecuteNonQuery();
            grdParentFill(Orderno,"");
            script = "alert('Order Planned..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton Delete = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)Delete.Parent.Parent;

            string ID = ((Label)gvRow.FindControl("lblID")).Text;
            string Orderno = ((Label)gvRow.FindControl("lblOrderNo")).Text;

            sql = "JCT_OPS_PLANNING_ORDER_DELETE";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Char, 10).Value = ID;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];

            cmd.ExecuteNonQuery();
            grdParentFill(Orderno, "");
            script = "alert('Order item Deleted..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }

    protected void txtWeavingSort_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox WeavingSort = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)WeavingSort.Parent.Parent;

            string GreighRem = ((TextBox)gvRow.FindControl("txtGreighRem")).Text;
            string Sizing = ((TextBox)gvRow.FindControl("txtSizing")).Text;

            sql = "JCT_OPS_PLANNING_CALC_SIZING";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Greigh_Req", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighRem);
            cmd.Parameters.Add("@Item_No", SqlDbType.VarChar,20).Value = WeavingSort.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Sizing = dr[0].ToString();
                }
            }
            dr.Close();
            obj.ConClose();
        }
        catch
        { 
            
        }
       
    }

    protected void lnkPlan_Click(object sender, EventArgs e)
    {
        LinkButton PlanItem = sender as LinkButton;

        GridViewRow gvrow = (GridViewRow)PlanItem.NamingContainer;
    }

    protected void txtPlanQty_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox PlanQty = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)PlanQty.Parent.Parent;

            Label Split = (Label)gvRow.FindControl("lblSplit");
            Label IndividualPlan = (Label)gvRow.FindControl("lblIPlan");
            decimal OrderQty = Convert.ToDecimal(((Label)gvRow.FindControl("lblOrderQty")).Text);

            decimal planQty = Convert.ToDecimal(PlanQty.Text);

            if (OrderQty > planQty)
            {
              
                Split.Text = "Y";
               
                
                //IndividualPlan.Text = "Y";
            }
            else if (OrderQty == planQty)
            {
                if (Split.Text == "Y")
                {
                    Split.Text = "N";
                }
               // IndividualPlan.Text = "N";
            }
            else if (OrderQty < planQty)
            {
                PlanQty.Text = "";
                script = "alert('PlanQty is greater than Order Qty..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
         
        }
        catch
        {

        }
    }

    protected void ddlPlant_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "SELECT PLANID,Description   FROM  dbo.JCT_OPS_PLANNING_GENERATE_PLANID WHERE STATUS='A' AND Plant='" + ddlPlant.SelectedItem.Text + "' order by planid desc";
        obj1.FillList(ddlPlanID, sql);
    }

    protected void lnkExcel_Click(object sender, EventArgs e)
    {

        //sql = "JCT_OPS_PLANNING_WEAVEPLAN_EXCEL";
        sql = "JCT_OPS_PLANNING_FREEZED_PLAN_DETAILS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable dt = ds.Tables[0];


        string attachment = "attachment; filename=Freezed_ProductionPlan.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

        obj.ConClose();
    }

    protected void txtSizing_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox Sizing = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)Sizing.Parent.Parent;
           
            Label SRem = (Label)gvRow.FindControl("lblSizingRem");

            string SizingDone = ((Label)gvRow.FindControl("lblSizingDone")).Text;
            string SizingRem = ((Label)gvRow.FindControl("lblSizingRem")).Text;

            decimal SzgDone = Convert.ToDecimal(SizingDone == "" ? 0 : Convert.ToDecimal(SizingDone));
            decimal SzgRem = Convert.ToDecimal(SizingDone == "" ? 0 : Convert.ToDecimal(SizingRem));

            SzgRem = Convert.ToDecimal(Sizing.Text) - SzgDone;
            SRem.Text = Convert.ToString(SzgRem);
        }
        catch {

            script = "alert('Sizing Remaining Not updated..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPlant.SelectedItem.Text == "Cotton")
            {
                sql = "JCT_OPS_PLANNING_COSTINGPPL_REPORT";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
                cmd.ExecuteNonQuery();
                SendMailCotton();
                script = "alert('PPL Generated..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else if (ddlPlant.SelectedItem.Text == "Taffeta")
            {
                sql = "JCT_OPS_PLANNING_COSTINGPPL_REPORT";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
cmd.CommandTimeout = 10000000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
                cmd.ExecuteNonQuery();
                SendMailTaffeta();
                script = "alert('PPL Generated..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);  
            }
           
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
    }

    private void SendMailCotton()
    {


        string from, to, bcc, cc, subject, body;

       

        to = "skj@jctltd.com,nsaini@jctltd.com,jagjit@jctltd.com,sanjay@jctltd.com";
        cc = "karanjitsaini@jctltd.com,sobti@jctltd.com,arvindsharma@jctltd.com";
        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("</head>");

        // sb.Append("<head>");
        sb.AppendLine("Hello, <br/><br/>");
        sb.AppendLine("Production Plan (" + ddlPlanID.SelectedItem.Text + ") has been freezed and PPL has been generated for " + ddlPlant.SelectedItem.Text + " Plant. Please go to PPL report to view all data.<br/><br/>");
        
        sb.AppendLine("This is a system generated mail, please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";
 
        subject = "Production Plan PPL Generated..!!";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);



        if (to.Contains(","))
        {
            string[] tos = to.Split(',');
            for (int i = 0; i < tos.Length; i++)
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
                for (int i = 0; i < ccs.Length; i++)
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
                for (int i = 0; i < bccs.Length; i++)
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
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");
        SmtpMail.Send(mail);

    }

    private void SendMailTaffeta()
    {


        string from, to, bcc, cc, subject, body;



        to = "skj@jctltd.com,nsaini@jctltd.com,jagjit@jctltd.com,sanjay@jctltd.com";
        cc = "trivendermehta@jctltd.com,nandi@jctltd.com,husanlal@jctltd.com,arvindsharma@jctltd.com";
        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("</head>");

        // sb.Append("<head>");
        sb.AppendLine("Hello, <br/><br/>");
        sb.AppendLine("Production Plan (" + ddlPlanID.SelectedItem.Text + ") has been freezed and PPL has been generated for "+ ddlPlant.SelectedItem.Text +" Plant. Please go to PPL report to view all data.<br/><br/>");

        sb.AppendLine("This is a system generated mail, please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";

        subject = "Production Plan PPL Generated..!!";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);



        if (to.Contains(","))
        {
            string[] tos = to.Split(',');
            for (int i = 0; i < tos.Length; i++)
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
                for (int i = 0; i < ccs.Length; i++)
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
                for (int i = 0; i < bccs.Length; i++)
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
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");
        SmtpMail.Send(mail);

    }

    protected void ddlPlanID_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "SELECT CASE WHEN Activated='N' THEN 'N' when Activated is null then 'NULL' when Activated='Y' then 'Y' END AS Status  FROM dbo.JCT_OPS_PLANNING_GENERATE_PLANID WHERE PLANID=@PlanID AND STATUS='A' ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@PlanID", SqlDbType.VarChar, 10).Value = ddlPlanID.SelectedItem.Value;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (dr["Status"].ToString() == "N")
                {
                    //lnkFetch.Enabled = false;
                    lblStatus.Text = "Completed";
                    lblStatus.ForeColor = System.Drawing.Color.MediumBlue ;
                    script = "alert('Plan has been completed. Cannot open or modify..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                else if (dr["Status"].ToString() == "NULL")
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Not Started";
                }
                else
                {
                    lnkFetch.Enabled = true;
                    lblStatus.Text = "Activated";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
    }


    protected void btnPopUp_Click(object sender, EventArgs e)
    {
        //string WeavingSort = "", OrderQty = "", PlanQty = "", SizingReq = "", SizingDone = "", GreighRem = "", ProductionDone = "";
      //  sql = "SELECT ISNULL(MAX( Plan_ID ),0) FROM dbo.jct_ops_planning_order_item_detail WHERE order_no='" + ViewState["OrderNo"] + "' AND STATUS='A'   and PLan_id not in (" + ViewState["PlanID"] + ")";

        sql = "SELECT isnull(case when Max(Plan_ID) = " + ddlPlanID.SelectedItem.Value + " then 0 else max(Plan_ID) end,0) as PlanID  FROM dbo.jct_ops_planning_order_item_detail WHERE order_no='" + ViewState["OrderNo"] + "' AND STATUS='A' ";//  and PLan_id not in (" + ViewState["PlanID"] + ")";
        string Plan = obj1.FetchValue(sql).ToString();
        if (Plan!="0")
        {
            string PlanID = obj1.FetchValue(sql).ToString();
            sql = "SELECT  DATENAME(month, PLANSTARTDATE) AS [MONTH] FROM dbo.JCT_OPS_PLANNING_GENERATE_PLANID WHERE PLANID=" + PlanID + "";
            string PlanMonth = obj1.FetchValue(sql).ToString();

            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "PopUp", "PopUp();", true);

            //sql = "JCT_OPS_PLANNING_CHECK_ORDER_STATUS";
            //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 30).Value = txtOrderNo.Text;
            //cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = Convert.ToInt16(PlanID);

            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);

            //grdPopUp.DataSource = ds.Tables[0];
            //grdPopUp.DataBind();

            //RadWindow1.OpenerElementID = btnPopUp.ClientID;
            // grdPopUp.DataBind();



            //string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true); 


        }
        else
        {
            sql = "JCT_OPS_PLANNING_ORDER_ITEMS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 25).Value = ViewState["OrderNo"];
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = ViewState["ItemNo"];
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdParent.DataSource = ds.Tables[0];
                grdParent.DataBind();
            }
            else
            {
                script = "alert('No Record present for selected options..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        //if (e.Argument == "Rebind")
        //{
        //    grdPopUp.MasterTableView.SortExpressions.Clear();
        //    grdPopUp.MasterTableView.GroupByExpressions.Clear();
        //    grdPopUp.Rebind();
        //}
        //else if (e.Argument == "RebindAndNavigate")
        //{
        //    grdPopUp.MasterTableView.SortExpressions.Clear();
        //    grdPopUp.MasterTableView.GroupByExpressions.Clear();
        //    grdPopUp.MasterTableView.CurrentPageIndex = grdPopUp.MasterTableView.PageCount - 1;
        //    grdPopUp.Rebind();
        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
     
       
    }

    protected void lnkHelp_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "OrderSummary", "OrderSummary();", true);
    }
    protected void greighAdj_TextChanged(object sender, EventArgs e)
    {
        TextBox GreighAdj = (TextBox)sender;
        GridViewRow gridRow = (GridViewRow)GreighAdj.Parent.Parent;


        Label OrderNo = (Label)gridRow.FindControl("lblOrderNo");
        Label SortNo = (Label)gridRow.FindControl("lblSortNo");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");

        Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
        TextBox PlanQty = (TextBox)gridRow.FindControl("txtPlanQty");
        TextBox GreighReq = (TextBox)gridRow.FindControl("txtGreighReq");
        TextBox sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList CaseType = (DropDownList)gridRow.FindControl("ddlcaseType");
        TextBox greigh_adj = (TextBox)gridRow.FindControl("txtGreighAdj");


        if (CaseType.SelectedIndex == 1)
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(PlanQty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_adj.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr["Greigh"].ToString();
                    sizing.Text = dr["Sizing"].ToString();
                }
            }
            dr.Close();

        }
        else
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(PlanQty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(greigh_adj.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr["Greigh"].ToString();
                    sizing.Text = dr["Sizing"].ToString();

                }
            }
            dr.Close();
        }
    }

    private void GrdDetail_fill()
    {

        sql = "JCT_OPS_PLANNING_FREEZED_PLAN_NewPlan";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 180;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "";
        // cmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value =yearMonth();
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
        cmd.Parameters.Add("@CustNo", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@SalesPersonCode", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@SalesTeam", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }



    protected void LinkViewDetail_Click(object sender, EventArgs e)
    {
        GrdDetail_fill();
    }
}