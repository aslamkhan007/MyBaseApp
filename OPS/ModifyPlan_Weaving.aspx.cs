using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_ModifyPlan_Weaving : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql,script;

    #region Variables
    string gvUniqueID = String.Empty;
    int gvNewPageIndex = 0;
    int gvEditIndex = -1;
    string gvSortExpr = String.Empty;
    Decimal TotalOrderQty = 0, TotalGreighReq = 0, TotalGreighAdj = 0, TotalGreighRem = 0, TotalSizing = 0;

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

    //  Child Grid Filled through SqlDataSource but now its been handles in grdParent_RowDataBound event

    //private SqlDataSource ChildDataSource(string orderno, string strSort)
    //{
    //    string strQRY = "";
    //    SqlDataSource dsTemp = new SqlDataSource();
    //    dsTemp.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;

    //    //strQRY = "SELECT  TransNo AS ID, order_no AS OrderNo,item_no AS SortNo,order_srl_no AS lineitem,Weaving_Sort AS WeavingSort,req_qty AS OrderQty,Casetype,Greigh_Req AS GreighReq,Grey_Adjustment AS GreighAdj,Greigh_Req-Grey_Adjustment AS GreighRem,Grey_Remaining AS Sizing,CASE WHEN Mode='Freezed' THEN 'F' WHEN Mode IS NULL THEN 'U' END AS Status  FROM dbo.JCT_OPS_MONTHLY_PLANNING_jatin WHERE order_no='" + orderno + "' AND Weaving_Sort='" + ViewState["Item"] + "' AND status IS NULL " + strSort ;
    //    strQRY = "JCT_OPS_MONTHLY_PLAN_MODIFY_DETAIL";
    //    SqlCommand cmd = new SqlCommand(sql);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = orderno;
    //    cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = ViewState["Item"];
    //    dsTemp.SelectCommand = strQRY;
    //    return dsTemp;
    //}

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        grdParentFill();

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
        ViewState["Item"] = string.Empty;
        GridView gv = new GridView();
        gv = (GridView)row.FindControl("GridView2");
        Label item = (Label)row.FindControl("lblSortNo");
        Label OrderNo = (Label)row.FindControl("lblOrderNo");
        ViewState.Add("Item", item.Text);
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

        //Prepare the query for Child GridView by passing the Order NO of the parent row

        sql = "JCT_OPS_MONTHLY_PLAN_MODIFY_DETAIL";
        // obj1.FillGrid(sql, ref gv);
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = item.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        gv.DataSource = ds.Tables[0];  //ChildDataSource(((DataRowView)e.Row.DataItem)["OrderNo"].ToString(), strSort);//
        gv.DataBind();
        TotalOrderQty = 0;
        TotalGreighReq = 0;
        TotalGreighAdj = 0;
        TotalGreighRem = 0;
        TotalSizing = 0;
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
        //grdParent.DataBind();

        grdParentFill();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
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
                TextBox WeavingSort = (TextBox)gvRow.FindControl("txtWeavingSort");
                TextBox GreighReq = (TextBox)gvRow.FindControl("txtGreighReq");
                TextBox GreighAdj = (TextBox)gvRow.FindControl("txtGreighAdj");
                TextBox Sizing = (TextBox)gvRow.FindControl("txtSizing");
                TextBox GreighRem = (TextBox)gvRow.FindControl("txtGreighRem");

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
                        GreighReq.Text = "";
                        GreighAdj.Text = "";
                        GreighRem.Text = "";
                        Sizing.Text = "";
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
          //  grdParent.DataBind();

            grdParentFill();
        }

        catch (Exception ex) {

            script = "alert('"+  ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
     
    }

    private void grdParentFill()
    {
        sql = "JCT_OPS_SIZING_REPORT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;

        cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 10).Value = txtSortNo.Text;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdParent.DataSource = ds;
            grdParent.DataBind();
        }
        else
        {
            script = "alert('No Record present for selected options..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void GridView2_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        gvUniqueID = gvTemp.UniqueID;
        gvEditIndex = -1;
        //grdParent.DataBind();
        grdParentFill();
   
    }

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridView gvTemp = (GridView)sender;
            gvUniqueID = gvTemp.UniqueID;

            //Get the values stored in the text boxes

            Label ID = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblID");
            Label OrderNo = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblOrderNo");
            Label SortNo = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblSortNo");
            Label LineItem = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblLineItem");
            TextBox WeavingSort = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtWeavingSort");
            Label OrderQty = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblOrderQty");
            DropDownList CaseType = (DropDownList)gvTemp.Rows[e.RowIndex].FindControl("ddlCaseType");
            TextBox GreighReq = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtGreighReq");
            TextBox GreighAdj = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtGreighAdj");
            TextBox GreighRem = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtGreighRem");
            TextBox Sizing = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtSizing");

            //Label ID = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblID");
            //Label OrderNo = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblOrderNo");
            //Label SortNo = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblSortNo");
            //Label LineItem = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblLineItem");
            //TextBox WeavingSort = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtWeavingSort");
            //Label OrderQty = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblOrderQty");
            //DropDownList CaseType = (DropDownList)gvTemp.Rows[e.RowIndex].FindControl("ddlCaseType");
            //TextBox GreighReq = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtGreighReq");
            //TextBox GreighAdj = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtGreighAdj");
            //TextBox GreighRem = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtGreighRem");
            //TextBox Sizing = (TextBox)gvTemp.Rows[e.RowIndex].FindControl("txtSizing");


            //sql = "JCT_OPS_PLANNING_MODIFY_WEAVING_PLAN";
            //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = ID.Text;
            //cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = OrderNo.Text;
            //cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = SortNo.Text;
            //cmd.Parameters.Add("@LineItem", SqlDbType.VarChar, 30).Value = LineItem.Text;
            //cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 30).Value = WeavingSort.Text;
            //cmd.Parameters.Add("@OrderQty", SqlDbType.VarChar, 30).Value = OrderQty.Text;
            //cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            //cmd.Parameters.Add("@GreighReq", SqlDbType.VarChar, 30).Value = GreighReq.Text;
            //cmd.Parameters.Add("@GreighAdj", SqlDbType.VarChar, 30).Value = GreighAdj.Text;
            //cmd.Parameters.Add("@GreighRem", SqlDbType.VarChar, 30).Value = GreighRem.Text;
            //cmd.Parameters.Add("@Sizing", SqlDbType.VarChar, 30).Value = Sizing.Text;
            //cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"].ToString();
            //cmd.ExecuteNonQuery();

            sql = "JCT_OPS_PLANNING_MODIFY_WEAVING_PLAN";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = ID.Text;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = OrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = SortNo.Text;
            cmd.Parameters.Add("@LineItem", SqlDbType.VarChar, 30).Value = LineItem.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 30).Value = WeavingSort.Text;
            cmd.Parameters.Add("@OrderQty", SqlDbType.VarChar, 30).Value = OrderQty.Text;
            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@GreighReq", SqlDbType.VarChar, 30).Value = GreighReq.Text;
            cmd.Parameters.Add("@GreighAdj", SqlDbType.VarChar, 30).Value = GreighAdj.Text;
            cmd.Parameters.Add("@GreighRem", SqlDbType.VarChar, 30).Value = GreighRem.Text;
            cmd.Parameters.Add("@Sizing", SqlDbType.VarChar, 30).Value = Sizing.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"].ToString();
            cmd.ExecuteNonQuery();

            //Prepare the Update Command of the DataSource control
            //SqlDataSource dsTemp = new SqlDataSource();
            //dsTemp.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
            //dsTemp.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
            //dsTemp.UpdateCommand = "JCT_OPS_PLANNING_MODIFY_WEAVING_PLAN";
            //dsTemp.UpdateParameters.Add("@ID",ID.Text);
            //dsTemp.UpdateParameters.Add("@OrderNo",OrderNo.Text);
            //dsTemp.UpdateParameters.Add("@SortNo", SortNo.Text);
            //dsTemp.UpdateParameters.Add("@LineItem",LineItem.Text);
            //dsTemp.UpdateParameters.Add("@WeavingSort", WeavingSort.Text);
            //dsTemp.UpdateParameters.Add("@OrderQty", OrderQty.Text);
            //dsTemp.UpdateParameters.Add("@CaseType", CaseType.SelectedItem.Text);
            //dsTemp.UpdateParameters.Add("@GreighReq", GreighReq.Text);
            //dsTemp.UpdateParameters.Add("@GreighAdj", GreighAdj.Text);
            //dsTemp.UpdateParameters.Add("@GreighRem", GreighRem.Text);
            //dsTemp.UpdateParameters.Add("@Sizing", Sizing.Text) ;
            //dsTemp.UpdateParameters.Add("@EmpCode", Session["EmpCode"].ToString());
            //dsTemp.Update();

            script = "alert('Order updated successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            

            //Reset Edit Index
            gvEditIndex = -1;

            //grdParent.DataBind();

            grdParentFill();
        }
        catch (Exception ex) {

            script = "alert('"+ ex.Message +"');";
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

            string lastTwoChars = order_no.Substring(order_no.Length - 2);
            if (lastTwoChars == "/S")
            {
                sql = "UPDATE  JCT_OPS_SHORTFALL_ORDER_REQUEST_AUTHORIZED SET status='D',MODIFY_Dt=GETDATE() ,Modified_By=@EmpCode WHERE TransNo=@ID";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = ID;
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                cmd.ExecuteNonQuery();
                script = "alert('Shortfall Order Deleted Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                sql = "UPDATE  dbo.JCT_OPS_MONTHLY_PLANNING SET status='D',modify_date=GETDATE(),REVISION_DT=GETDATE(),REVISED_BY=@EmpCode WHERE TransNo=@ID";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = ID;
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                cmd.ExecuteNonQuery();
                script = "alert('Order Deleted Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

            //Reset Edit Index
            gvEditIndex = -1;

            //grdParent.DataBind();

            grdParentFill();
        }
        catch (Exception ex) {

            script = "alert('"+ ex.Message +"');";
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
            if (((DataRowView)e.Row.DataItem)["ID"].ToString() == String.Empty) e.Row.Visible = false;

            string order_no = ((Label)e.Row.FindControl("lblOrderNo")).Text;
            int LineItem = Convert.ToInt16(((Label)e.Row.FindControl("lblLineItem")).Text);

            sql = "Select isnull(Mode,'') from JCT_OPS_MONTHLY_PLANNING WHERE ORDER_NO='" + order_no + "' and order_srl_no=" + LineItem + " and Status is null ";
            SqlDataReader dr = obj1.FetchReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0].ToString() == "")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Red;
                        //e.Row.BackColor = System.Drawing.Color.Aqua;
                    }
                }
            }
            dr.Close();
        }
        //Label ID = (Label)e.Row.FindControl("lblID");
        //Label OrderNo = (Label)e.Row.FindControl("lblOrderNo");
        //Label SortNo = (Label)e.Row.FindControl("lblSortNo");
        //Label LineItem = (Label)e.Row.FindControl("lblLineItem");
        //Label WeavingSort = (Label)e.Row.FindControl("lblWeavingSort");
        //Label OrderQty = (Label)e.Row.FindControl("lblOrderQty");
        //Label GreighReq = (Label)e.Row.FindControl("lblGreighReq");
        //Label GreighAdj = (Label)e.Row.FindControl("lblGreighAdj");
        //Label GreighRem = (Label)e.Row.FindControl("lblGreighRem");
        //Label Sizing = (Label)e.Row.FindControl("lblSizing");

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    TotalOrderQty = TotalOrderQty + Convert.ToDecimal(OrderQty.Text);
        //    TotalGreighReq = TotalGreighReq + Convert.ToDecimal(GreighReq.Text);
        //    TotalGreighAdj = TotalGreighAdj + Convert.ToDecimal(GreighAdj.Text);
        //    TotalGreighRem = TotalGreighRem + Convert.ToDecimal(GreighRem.Text);
        //    TotalSizing = TotalSizing + Convert.ToDecimal(Sizing.Text);
        //}
        //else if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    e.Row.Cells[6].Text = "Total";
        //    e.Row.Cells[7].Text = TotalOrderQty.ToString();
        //    e.Row.Cells[9].Text = TotalGreighReq.ToString();
        //    e.Row.Cells[10].Text = TotalGreighAdj.ToString();
        //    e.Row.Cells[11].Text = TotalGreighRem.ToString();
        //    e.Row.Cells[12].Text = TotalSizing.ToString();
        //}
       
    }

    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        gvUniqueID = gvTemp.UniqueID;
        gvSortExpr = e.SortExpression;
       // grdParent.DataBind();

        grdParentFill();
    }

    protected void ddlCaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList CaseType = (DropDownList)sender;
        GridViewRow gridRow = (GridViewRow)CaseType.Parent.Parent;

        Label ID = (Label)gridRow.FindControl("lblID");
        Label OrderNo = (Label)gridRow.FindControl("lblOrderNo");
        Label SortNo = (Label)gridRow.FindControl("lblSortNo");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
        Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
        TextBox GreighReq = (TextBox)gridRow.FindControl("txtGreighReq");
        TextBox GreighAdj = (TextBox)gridRow.FindControl("txtGreighAdj");
        TextBox GreighRem = (TextBox)gridRow.FindControl("txtGreighRem");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");

        if (CaseType.SelectedIndex == 1)
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr[0].ToString();
                    double greighRem = double.Parse(GreighReq.Text);
                    greighRem = Math.Round(greighRem, 2);
                    GreighRem.Text = greighRem.ToString();
                    GreighReq.Text = greighRem.ToString();
                    GreighAdj.Text = "0";
                }
            }
            dr.Close();

            sql = "EXEC JCT_OPS_WEAVING_SIZING " + GreighRem.Text + ",  '" + WeavingSort.Text + "','" + OrderNo.Text + "'," + LineItem.Text + ",'N'";
            Sizing.Text = obj1.FetchValue(sql).ToString();
            Decimal Remaining = Convert.ToDecimal(GreighReq.Text) - Convert.ToDecimal(GreighAdj.Text);
            GreighRem.Text = Remaining.ToString();
        }
        else
        {

            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr[0].ToString();
                    double greighRem = double.Parse(GreighReq.Text);
                    greighRem = Math.Round(greighRem, 2);
                    GreighRem.Text = greighRem.ToString();
                    GreighReq.Text = greighRem.ToString();
                    GreighAdj.Text = "0";
                }
            }
            dr.Close();


            sql = "EXEC JCT_OPS_WEAVING_SIZING " + GreighRem.Text + ", '" + WeavingSort.Text + "','" + OrderNo.Text + "'," + LineItem.Text + ",'N'";
            Sizing.Text = obj1.FetchValue(sql).ToString();
            Decimal Remaining = Convert.ToDecimal(GreighReq.Text) - Convert.ToDecimal(GreighAdj.Text);
            GreighRem.Text = Remaining.ToString();

        }
     
       
    }

    protected void txtGreighAdj_TextChanged(object sender, EventArgs e)
    {
        TextBox GreighAdj = (TextBox)sender;
        GridViewRow gridRow = (GridViewRow)GreighAdj.Parent.Parent;

        Label ID = (Label)gridRow.FindControl("lblID");
        Label OrderNo = (Label)gridRow.FindControl("lblOrderNo");
        Label SortNo = (Label)gridRow.FindControl("lblSortNo");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
        Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
        TextBox GreighReq = (TextBox)gridRow.FindControl("txtGreighReq");
        TextBox GreighRem = (TextBox)gridRow.FindControl("txtGreighRem");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList CaseType = (DropDownList)gridRow.FindControl("ddlCaseType");

        if (GreighReq.Text != "0")
        {

            if (CaseType.SelectedIndex == 1)
            {

                sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
                cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
                cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GreighReq.Text = dr[0].ToString();
                    }
                }
                dr.Close();

                decimal f = decimal.Parse(GreighReq.Text) - decimal.Parse(GreighAdj.Text);
                f = Math.Round(f, 2);
                GreighRem.Text = f.ToString();
                float Rem = float.Parse(GreighRem.Text);
                Sizing.Text = Rem.ToString();
                sql = "EXEC JCT_OPS_WEAVING_SIZING " + Sizing.Text + ",  '" + WeavingSort.Text + "','" + OrderNo.Text + "'," + LineItem.Text + ",'N'";
                Sizing.Text = obj1.FetchValue(sql).ToString();
                Sizing.Text = Sizing.Text;


            }
            else
            {

                sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
                cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
                cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(OrderQty.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GreighReq.Text = dr[0].ToString();
                    }
                }
                dr.Close();

                decimal f = decimal.Parse(GreighReq.Text) - decimal.Parse(GreighAdj.Text);
                f = Math.Round(f, 2);
                GreighRem.Text = f.ToString();
                float Rem = float.Parse(GreighRem.Text);
                Sizing.Text = Rem.ToString();
                sql = "EXEC JCT_OPS_WEAVING_SIZING " + Sizing.Text + ",  '" + WeavingSort.Text + "','" + OrderNo.Text + "'," + LineItem.Text + ",'N'";
                Sizing.Text = obj1.FetchValue(sql).ToString();
                Sizing.Text = Sizing.Text;
               
            }
           

        }
       
    }
    protected void grdParent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdParent.PageIndex = e.NewPageIndex;
        grdParentFill();
    }
}