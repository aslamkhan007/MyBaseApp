using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

public partial class OPS_SaleOrderAdjustment10 : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    String script;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("~/Coming_Soon.aspx");
        if (!IsPostBack)
        {
            
            txtSubject.Text = Request.QueryString["Type"].ToString();
        }
    }

    protected void GenerateCode(string dept)
    {
        #region Serial No. Code

       
        sql = "JCT_OPS_SanctionNote_GENERATE_CODE";
        SqlCommand cmd = new SqlCommand(sql);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["Code"] = dr[0].ToString();
            }
        }

      

        #endregion
    }

    private void SetInitialRow()
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Sort", typeof(string)));
            dt.Columns.Add(new DataColumn("LineItem", typeof(string)));
            dt.Columns.Add(new DataColumn("Shade", typeof(string)));
            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new DataColumn("SalesPrice", typeof(string)));
            dt.Columns.Add(new DataColumn("GreighReq", typeof(string)));
            dt.Columns.Add(new DataColumn("GreighAdjust", typeof(string)));
            dr = dt.NewRow();
            dr["OrderNo"] = string.Empty;
            dr["Sort"] = string.Empty;
            dr["LineItem"] = string.Empty;
            dr["Shade"] = string.Empty;
            dr["Qty"] = string.Empty;
            dr["SalesPrice"] = string.Empty;
            dr["GreighReq"] = string.Empty;
            dr["GreighAdjust"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            GridView1.DataSource = ViewState["CurrentTable"];
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    private void AddNewRowToGrid()
    {

        try
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtCurrentTable.Rows.Count - 1; i++)
                    {

                        TextBox OrderNo = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txtOrdNo");
                        Label Sort = (Label)GridView1.Rows[rowIndex].Cells[2].FindControl("lblSort");
                        Label LineItem = (Label)GridView1.Rows[rowIndex].Cells[3].FindControl("lblLineItem");
                        Label Shade = (Label)GridView1.Rows[rowIndex].Cells[4].FindControl("lblShade");
                        Label SalesPrice = (Label)GridView1.Rows[rowIndex].Cells[5].FindControl("lblSalesPrice");
                        Label Qty = (Label)GridView1.Rows[rowIndex].Cells[6].FindControl("lblQty");
                        DropDownList CaseType = (DropDownList)GridView1.Rows[rowIndex].Cells[7].FindControl("ddlCaseType");
                        Label GreighReq = (Label)GridView1.Rows[rowIndex].Cells[8].FindControl("lblGreighReq");
                        TextBox GreighAdjust = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtAdjust");

                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i]["OrderNo"] = OrderNo.Text;
                        dtCurrentTable.Rows[i]["Sort"] = Sort.Text;
                        dtCurrentTable.Rows[i]["LineItem"] = LineItem.Text;
                        dtCurrentTable.Rows[i]["Shade"] = Shade.Text;
                        dtCurrentTable.Rows[i]["Qty"] = Qty.Text;
                        dtCurrentTable.Rows[i]["SalesPrice"] = SalesPrice.Text;
                        dtCurrentTable.Rows[i]["GreighReq"] = GreighReq.Text;
                        dtCurrentTable.Rows[i]["GreighAdjust"] = GreighAdjust.Text;
                        rowIndex++;

                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    ViewState["RefreshTable"] = ViewState["CurrentTable"];


                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();

        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }

    private void SetPreviousData()
    {
        try
        {
            int rowIndex = 0;
            if (ViewState["RefreshTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["RefreshTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox OrderNo = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txtOrdNo");
                        Label Sort = (Label)GridView1.Rows[rowIndex].Cells[2].FindControl("lblSort");
                        Label LineItem = (Label)GridView1.Rows[rowIndex].Cells[3].FindControl("lblLineItem");
                        Label Shade = (Label)GridView1.Rows[rowIndex].Cells[4].FindControl("lblShade");
                        Label SalesPrice = (Label)GridView1.Rows[rowIndex].Cells[5].FindControl("lblSalesPrice");
                        Label Qty = (Label)GridView1.Rows[rowIndex].Cells[6].FindControl("lblQty");
                        DropDownList CaseType = (DropDownList)GridView1.Rows[rowIndex].Cells[7].FindControl("ddlCaseType");
                        Label GreighReq = (Label)GridView1.Rows[rowIndex].Cells[8].FindControl("lblGreighReq");
                        TextBox GreighAdjust = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtAdjust");

                        OrderNo.Text = dt.Rows[i]["OrderNo"].ToString();
                        Sort.Text = dt.Rows[i]["Sort"].ToString();
                        LineItem.Text = dt.Rows[i]["LineItem"].ToString();
                        Shade.Text = dt.Rows[i]["Shade"].ToString();
                        SalesPrice.Text = dt.Rows[i]["SalesPrice"].ToString();
                        Qty.Text = dt.Rows[i]["Qty"].ToString();
                        GreighReq.Text = dt.Rows[i]["GreighReq"].ToString();
                        GreighAdjust.Text = dt.Rows[i]["GreighAdjust"].ToString();
                        rowIndex++;
                    }
                }
            }
          
        }

        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

            TextBox OrderNo = (TextBox)GridView1.Rows[RowIndex].Cells[1].FindControl("txtOrdNo");
            Label Sort = (Label)GridView1.Rows[RowIndex].Cells[2].FindControl("lblSort");
            Label LineItem = (Label)GridView1.Rows[RowIndex].Cells[3].FindControl("lblLineItem");
            Label Shade = (Label)GridView1.Rows[RowIndex].Cells[4].FindControl("lblShade");
            Label SalesPrice = (Label)GridView1.Rows[RowIndex].Cells[5].FindControl("lblSalesPrice");
            Label Qty = (Label)GridView1.Rows[RowIndex].Cells[6].FindControl("lblQty");
            DropDownList CaseType = (DropDownList)GridView1.Rows[RowIndex].Cells[7].FindControl("ddlCaseType");
            Label GreighReq = (Label)GridView1.Rows[RowIndex].Cells[8].FindControl("lblGreighReq");
            TextBox GreighAdjust = (TextBox)GridView1.Rows[RowIndex].Cells[9].FindControl("txtAdjust");

            if (e.CommandName == "Remove")
            {
                if (OrderNo.Text == "" || Sort.Text == "" || Qty.Text == "" || GreighAdjust.Text == "")
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    dt.Rows.RemoveAt(RowIndex);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    ViewState["data"] = dt;
                }
                else
                {
                    sql = "Select * from JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE NEW_SALEORDER=@SALEORDER AND NEW_SORT=@SORT AND NEW_QTY =@QTY AND STATUS='P'   ";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                    cmd.Parameters.Add("@Sort", SqlDbType.VarChar, 10).Value = Sort.Text;
                    cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            sql = "Update JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT set Status='D',DeletedBy=@EmpCode ,Deleteddate=getdate() where  NEW_SALEORDER=@SALEORDER AND NEW_SORT=@SORT AND NEW_QTY =@QTY AND STATUS='P'";
                            cmd = new SqlCommand(sql, obj.Connection());
                            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                            cmd.Parameters.Add("@Sort", SqlDbType.VarChar, 10).Value = Sort.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
                            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                            cmd.ExecuteNonQuery();
                            script = "alert('Record Deleted.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        }
                    }
                    else
                    {
                        DataTable dt = (DataTable)ViewState["CurrentTable"];
                        dt.Rows.RemoveAt(RowIndex);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        ViewState["data"] = dt;
                    }
                }
            }


            else if (e.CommandName == "Refresh")
            {
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                    DataRow drCurrentRow = null;

                    sql = "Select Count(*) from miserp.som.dbo.t_order_line_nos where order_no ='"+ OrderNo.Text +"'";
                    int count = Convert.ToInt32(obj1.FetchValue(sql).ToString());
                    sql = "JCT_OPS_FETCH_NEW_SALEORDER_DETAILS";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = OrderNo.Text;

                    //cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
                    //dt.Columns.Add(new DataColumn("Sort", typeof(string)));
                    //dt.Columns.Add(new DataColumn("LineItem", typeof(string)));
                    //dt.Columns.Add(new DataColumn("Shade", typeof(string)));
                    //dt.Columns.Add(new DataColumn("Qty", typeof(string)));
                    //dt.Columns.Add(new DataColumn("SalesPrice", typeof(string)));
                    //dt.Columns.Add(new DataColumn("GreighReq", typeof(string)));
                    //dt.Columns.Add(new DataColumn("GreighAdjust", typeof(string)));
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            
                            //DataRow drow = null;
                            //drow = dt.NewRow();
                            //drow["OrderNo"] = dr[0].ToString();
                            //drow["Sort"] = dr[1].ToString();
                            //drow["LineItem"] = dr[2].ToString();
                            //drow["Shade"] = dr[3].ToString();
                            //drow["Qty"] = dr[4].ToString();
                            //drow["SalesPrice"] = dr[5].ToString();
                            //drow["GreighReq"] = string.Empty;
                            //drow["GreighAdjust"] = string.Empty;
                            //dt.Rows.Add(drow);
                            //var loop = dr.Read();

                            //if (!loop)
                            //{
                            //    int rowindex = dtCurrentTable.Rows.Count - 1;
                            //    dtCurrentTable.Rows[rowindex].BeginEdit();
                            //    dtCurrentTable.Rows[rowindex]["OrderNo"] = dr[0].ToString();
                            //    dtCurrentTable.Rows[rowindex]["Sort"] = dr[1].ToString();
                            //    dtCurrentTable.Rows[rowindex]["LineItem"] = dr[2].ToString();
                            //    dtCurrentTable.Rows[rowindex]["Shade"] = dr[3].ToString();
                            //    dtCurrentTable.Rows[rowindex]["Qty"] = dr[4].ToString();
                            //    dtCurrentTable.Rows[rowindex]["SalesPrice"] = dr[5].ToString();
                            //    dtCurrentTable.Rows[rowindex]["GreighReq"] = string.Empty;
                            //    dtCurrentTable.Rows[rowindex]["GreighAdjust"] = string.Empty;
                            //    dtCurrentTable.Rows[rowindex].EndEdit();
                            //    dtCurrentTable.AcceptChanges();

                              
                            //}

                            //else
                            //{
                                int rowindex = dtCurrentTable.Rows.Count - 1;
                                dtCurrentTable.Rows[rowindex].BeginEdit();
                                dtCurrentTable.Rows[rowindex]["OrderNo"] = dr["orderNo"].ToString();
                                dtCurrentTable.Rows[rowindex]["Sort"] = dr["Sort"].ToString();
                                dtCurrentTable.Rows[rowindex]["LineItem"] = dr["Line Item"].ToString();
                                dtCurrentTable.Rows[rowindex]["Shade"] = dr["Shade"].ToString();
                                dtCurrentTable.Rows[rowindex]["Qty"] = dr["Qty"].ToString();
                                dtCurrentTable.Rows[rowindex]["SalesPrice"] = dr["SalesPrice"].ToString();
                                dtCurrentTable.Rows[rowindex]["GreighReq"] = string.Empty;
                                dtCurrentTable.Rows[rowindex]["GreighAdjust"] = string.Empty;
                                dtCurrentTable.Rows[rowindex].EndEdit();
                                dtCurrentTable.AcceptChanges();
                                count = count - 1;
                                if (count > 0)
                                {       // Add New Row In Datatable
                                        drCurrentRow = dtCurrentTable.NewRow();
                                        drCurrentRow["OrderNo"] = string.Empty;
                                        drCurrentRow["Sort"] = string.Empty;
                                        drCurrentRow["LineItem"] = string.Empty;
                                        drCurrentRow["Shade"] = string.Empty;
                                        drCurrentRow["Qty"] = string.Empty;
                                        drCurrentRow["SalesPrice"] = string.Empty;
                                        drCurrentRow["GreighReq"] = string.Empty;
                                        drCurrentRow["GreighAdjust"] = string.Empty;
                                        dtCurrentTable.Rows.Add(drCurrentRow);
                                }
                              
                            

                             
                            //}
                         
                            //dr = dt.NewRow();
                            //Store the DataTable in ViewState

                            //ViewState["RefreshTable"] = null;
                            //if (ViewState["RefreshTable"] == null)
                            //{
                            //    ViewState["RefreshTable"] = dt;
                            //}
                            //else
                            //{
                            //    ViewState.Add("RefreshTable", dt);
                            //    //Response.Write(ViewState["RefreshTable"]);
                            //}

                        }
                    }
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds);
                    //ViewState.Add("CurrentTable", ViewState["RefreshTable"]);
                    //GridView1.DataSource = ViewState["RefreshTable"];
                    GridView1.DataSource = ViewState["CurrentTable"];
                    GridView1.DataBind(); 
                }

            }


        }


        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

    //        int RowIndex = gvr.RowIndex;

    //        TextBox OrderNo = (TextBox)GridView1.Rows[RowIndex].Cells[1].FindControl("txtOrdNo");
    //        Label Sort = (Label)GridView1.Rows[RowIndex].Cells[2].FindControl("lblSort");
    //        Label LineItem = (Label)GridView1.Rows[RowIndex].Cells[3].FindControl("lblLineItem");
    //        Label Shade = (Label)GridView1.Rows[RowIndex].Cells[4].FindControl("lblShade");
    //        Label SalesPrice = (Label)GridView1.Rows[RowIndex].Cells[5].FindControl("lblSalesPrice");
    //        Label Qty = (Label)GridView1.Rows[RowIndex].Cells[6].FindControl("lblQty");
    //        DropDownList CaseType = (DropDownList)GridView1.Rows[RowIndex].Cells[7].FindControl("ddlCaseType");
    //        Label GreighReq = (Label)GridView1.Rows[RowIndex].Cells[8].FindControl("lblGreighReq");
    //        TextBox GreighAdjust = (TextBox)GridView1.Rows[RowIndex].Cells[9].FindControl("txtAdjust");

    //        if (e.CommandName == "Remove")
    //        {
    //            if (OrderNo.Text == "" || Sort.Text == "" || Qty.Text == "" || GreighAdjust.Text == "")
    //            {
    //                DataTable dt = (DataTable)ViewState["CurrentTable"];
    //                dt.Rows.RemoveAt(RowIndex);
    //                GridView1.DataSource = dt;
    //                GridView1.DataBind();
    //                ViewState["data"] = dt;
    //            }
    //            else
    //            {
    //                sql = "Select * from JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE NEW_SALEORDER=@SALEORDER AND NEW_SORT=@SORT AND NEW_QTY =@QTY AND STATUS='P'   ";
    //                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //                cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
    //                cmd.Parameters.Add("@Sort", SqlDbType.VarChar, 10).Value = Sort.Text;
    //                cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
    //                SqlDataReader dr = cmd.ExecuteReader();
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        sql = "Update JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT set Status='D',DeletedBy=@EmpCode ,Deleteddate=getdate() where  NEW_SALEORDER=@SALEORDER AND NEW_SORT=@SORT AND NEW_QTY =@QTY AND STATUS='P'";
    //                        cmd = new SqlCommand(sql, obj.Connection());
    //                        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
    //                        cmd.Parameters.Add("@Sort", SqlDbType.VarChar, 10).Value = Sort.Text;
    //                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
    //                        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
    //                        cmd.ExecuteNonQuery();
    //                        script = "alert('Record Deleted.');";
    //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //                    }
    //                }
    //                else
    //                {
    //                    DataTable dt = (DataTable)ViewState["CurrentTable"];
    //                    dt.Rows.RemoveAt(RowIndex);
    //                    GridView1.DataSource = dt;
    //                    GridView1.DataBind();
    //                    ViewState["data"] = dt;
    //                }
    //            }
    //        }


    //        else if (e.CommandName == "Refresh")
    //        {
    //            sql = "JCT_OPS_FETCH_NEW_SALEORDER_DETAILS";
    //            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = OrderNo.Text;

    //            //cmd.ExecuteNonQuery();
    //            SqlDataReader dr = cmd.ExecuteReader();


    //            DataTable dt = new DataTable();
    //            dt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
    //            dt.Columns.Add(new DataColumn("Sort", typeof(string)));
    //            dt.Columns.Add(new DataColumn("LineItem", typeof(string)));
    //            dt.Columns.Add(new DataColumn("Shade", typeof(string)));
    //            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
    //            dt.Columns.Add(new DataColumn("SalesPrice", typeof(string)));
    //            dt.Columns.Add(new DataColumn("GreighReq", typeof(string)));
    //            dt.Columns.Add(new DataColumn("GreighAdjust", typeof(string)));


    //            if (dr.HasRows)
    //            {
    //                while (dr.Read())
    //                {
    //                    DataRow drow = null;
    //                    drow = dt.NewRow();
    //                    drow["OrderNo"] = dr[0].ToString();
    //                    drow["Sort"] = dr[1].ToString();
    //                    drow["LineItem"] = dr[2].ToString();
    //                    drow["Shade"] = dr[3].ToString();
    //                    drow["Qty"] = dr[4].ToString();
    //                    drow["SalesPrice"] = dr[5].ToString();
    //                    drow["GreighReq"] = string.Empty;
    //                    drow["GreighAdjust"] = string.Empty;
    //                    dt.Rows.Add(drow);

    //                    if (ViewState["RefreshTable"] == null)
    //                    {
    //                        ViewState["RefreshTable"] = dt;
    //                    }
    //                    else
    //                    {
    //                        ViewState.Add("RefreshTable", dt);
    //                    }

    //                }
    //            }

    //            GridView1.DataSource = ViewState["RefreshTable"];
    //            GridView1.DataBind();




    //        }


    //    }


    //    catch (Exception ex)
    //    {
    //        script = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }

    //}

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        try
        {
            pnlCheckStatus.Visible = false;
           // sql = "Select * from JCT_OPS_MONTHLY_PLANNING WHERE YEARMONTH =(SELECT MAX(YEARMONTH) FROM JCT_OPS_MONTHLY_PLANNING WHERE ORDER_NO='" + txtOrderNo.Text + "' AND STATUS IS NULL) AND ORDER_NO='" + txtOrderNo.Text + "' AND STATUS IS NULL ";
            if (txtSubject.Text == "Greigh Transfer" || txtSubject.Text == "Greigh Transfer Taffeta")
                //sql = "Select * from JCT_OPS_MONTHLY_PLANNING WHERE mode='Freezed' and YEARMONTH =(SELECT MAX(YEARMONTH) FROM JCT_OPS_MONTHLY_PLANNING WHERE ORDER_NO='" + txtOrderNo.Text + "' AND STATUS IS NULL) AND ORDER_NO='" + txtOrderNo.Text + "' AND STATUS IS NULL ";

                sql = "Select * from JCT_OPS_PLANNING_ORDER WHERE ORDER_NO='" + txtOrderNo.Text + "' AND STATUS ='A' ";
            
            else
                sql = "SELECT c.cust_name AS CustomerName ,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'), '', 'N.A') AS SalePerson ,b.order_no AS OrderNo ,attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,CONVERT(NUMERIC(8), Req_Qty) AS OrderQty ,CONVERT(VARCHAR(10), f.req_dt,101) AS ReqDate FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no LEFT OUTER JOIN MISERP.SOM.dbo.m_cust_group g ( NOLOCK ) ON g.group_no = d.sale_person_code WHERE b.order_no='" + txtOrderNo.Text + "' ORDER BY b.order_no ASC ,e.line_no ASC      ";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                sql = "JCT_OPS_FETCH_ORDER_SALEORDER_ADJUSTMENT_NEWPLAN";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 30).Value = txtSubject.Text;
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grd.DataSource = ds;
                grd.DataBind();
            }
            else
            {
                script = "alert('Your Order is not planned yet. Please contact Planning Deptt. for status of this order no..!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
       
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    //protected void lnkSave_Click(object sender, EventArgs e)
    //{
    //    //try
    //    //{
    //    //    // int flag = 0;
            
    //    //    CheckQty();

    //    //    if (Convert.ToDecimal(ViewState["TotalQty"]) <= Convert.ToDecimal(ViewState["Qty"]))
    //    //    {
    //    //        List<String> list = new List<String>();
    //    //        String empcode;
    //    //        sql = "JCT_OPS_SanctionNote_SanctionID";
    //    //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    //        cmd.CommandType = CommandType.StoredProcedure;
    //    //        SqlDataReader dr = cmd.ExecuteReader();
    //    //        if (dr.HasRows)
    //    //        {
    //    //            while (dr.Read())
    //    //            {
    //    //                ViewState["SanctionID"] = dr[0].ToString();
    //    //            }
    //    //        }
    //    //        dr.Close();

    //    //        sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
    //    //        if (obj1.CheckRecordExistInTransaction(sql))
    //    //        {
    //    //            empcode = obj1.FetchValue(sql).ToString();
    //    //            sql = "JCT_OPS_SanctionNote_INSERT_DYNAMIC_MAPPING";
    //    //            SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
    //    //            cmd1.CommandType = CommandType.StoredProcedure;
    //    //            cmd1.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
    //    //            cmd1.Parameters.Add("@USERCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
    //    //            cmd1.Parameters.Add("@AUTH_EMPCODE", SqlDbType.VarChar, 10).Value = empcode;
    //    //            cmd1.Parameters.Add("@AREACODE", SqlDbType.VarChar, 10).Value = "1006";
    //    //            cmd1.ExecuteNonQuery();
    //    //        }
    //    //        else
    //    //        {
    //    //            script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
    //    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    //            return;
    //    //        }


    //    //        sql = "Select UserLevel from  dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE ID='" + ViewState["SanctionID"] + "'";
    //    //        cmd = new SqlCommand(sql, obj.Connection());
    //    //        dr = cmd.ExecuteReader();
    //    //        if (dr.HasRows)
    //    //        {
    //    //            while (dr.Read())
    //    //            {
    //    //                list.Add(dr[0].ToString());

    //    //            }
    //    //        }
    //    //        dr.Close();

    //    //        String Flag = String.Join("-", list.ToArray());

    //    //        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
    //    //        {
    //    //            TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
    //    //            Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
    //    //            Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
    //    //            Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
    //    //            Label SalesPrice = (Label)GridView1.Rows[i].Cells[5].FindControl("lblSalesPrice");
    //    //            Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
    //    //            DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[7].FindControl("ddlCaseType");
    //    //            Label Greigh = (Label)GridView1.Rows[i].Cells[8].FindControl("lblGreighReq");
    //    //            TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");

    //    //            ViewState["AdjustedOrderNo"] = OrderNo.Text;

    //    //            sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["AdjustedOrderNo"] + "'";
    //    //            if (obj1.CheckRecordExistInTransaction(sql))
    //    //            {
    //    //                // empcode = obj1.FetchValue(sql).ToString();

    //    //                if (CaseType.SelectedIndex != 0)
    //    //                {

    //    //                    sql = "Select UserLevel from  dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE ID='" + ViewState["SanctionID"] + "'";
    //    //                    cmd = new SqlCommand(sql, obj.Connection());
    //    //                    dr = cmd.ExecuteReader();
    //    //                    if (dr.HasRows)
    //    //                    {
    //    //                        while (dr.Read())
    //    //                        {
    //    //                            list.Add(dr[0].ToString());

    //    //                        }
    //    //                    }
    //    //                    dr.Close();
    //    //                    String FlagAuth = String.Join("-", list.ToArray());

    //    //                    sql = "JCT_OPS_PLANNING_SALEORDER_ADJUSTEMENT_INSERT";
    //    //                    cmd = new SqlCommand(sql, obj.Connection());
    //    //                    cmd.CommandType = CommandType.StoredProcedure;
    //    //                    cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
    //    //                    cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
    //    //                    cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = ViewState["Sort"];
    //    //                    cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Qty"]);
    //    //                    cmd.Parameters.Add("@ACTUAL_WEAVINGSORT", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["WeavingSort"]);
    //    //                    cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["GreighReq"]);
    //    //                    cmd.Parameters.Add("@New_SALEORDER", SqlDbType.VarChar, 20).Value = OrderNo.Text;
    //    //                    cmd.Parameters.Add("@New_SORT", SqlDbType.VarChar, 10).Value = Sort.Text;
    //    //                    cmd.Parameters.Add("@New_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
    //    //                    cmd.Parameters.Add("@New_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(Greigh.Text);
    //    //                    cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
    //    //                    cmd.Parameters.Add("@RePlan", SqlDbType.Char, 1).Value = 'N';
    //    //                    cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
    //    //                    cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
    //    //                    cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
    //    //                    cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 30).Value = Flag;
    //    //                    cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);
    //    //                    cmd.Parameters.Add("@AreaCode", SqlDbType.Decimal).Value = 1006;
    //    //                    cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = txtSubject.Text;
    //    //                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
    //    //                    cmd.ExecuteNonQuery();
    //    //                }
    //    //                else
    //    //                {
    //    //                    script = "alert('Please select type greigh cloth required from drop down..!!');";
    //    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    //                }
    //    //            }
    //    //            else
    //    //            {
    //    //                script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
    //    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    //                return;
    //    //            }

    //    //        }
    //    //        ClearForm();
    //    //        SendMail_SaleOrderAdjustment();

    //    //        script = "alert('Request Sent Successfully..!!');";
    //    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    //    }
    //    //    else
    //    //    {
    //    //        script = "alert('Total Quantity adjusted is greater than actual quantity..!! Please make sure that the quantity you are adjusting is less than the quantity of order from which you are transfering greigh..!!');";
    //    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    //    }
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    script = "alert('" + ex.Message + "');";
    //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    //}

    //    try
    //    {
    //        if (txtSubject.Text == "Greigh Transfer")
    //        {
    //            CheckQty();

    //            if (Convert.ToDecimal(ViewState["TotalQty"]) <= Convert.ToDecimal(ViewState["Qty"]))
    //            {
    //                // int flag = 0;
    //                List<String> list = new List<String>();
    //                String empcode;
    //                sql = "JCT_OPS_SanctionNote_SanctionID";
    //                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                SqlDataReader dr = cmd.ExecuteReader();
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        ViewState["SanctionID"] = dr[0].ToString();
    //                    }
    //                }
    //                dr.Close();

    //                sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
    //                if (obj1.CheckRecordExistInTransaction(sql))
    //                {
    //                    empcode = obj1.FetchValue(sql).ToString();
    //                    sql = "JCT_OPS_SanctionNote_INSERT_DYNAMIC_MAPPING";
    //                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
    //                    cmd1.CommandType = CommandType.StoredProcedure;
    //                    cmd1.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
    //                    cmd1.Parameters.Add("@USERCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
    //                    cmd1.Parameters.Add("@AUTH_EMPCODE", SqlDbType.VarChar, 10).Value = empcode;
    //                    cmd1.Parameters.Add("@AREACODE", SqlDbType.VarChar, 10).Value = "1006";
    //                    cmd1.ExecuteNonQuery();
    //                }
    //                else
    //                {
    //                    script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //                    return;
    //                }

    //                sql = "Select UserLevel from  dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE ID='" + ViewState["SanctionID"] + "'";
    //                cmd = new SqlCommand(sql, obj.Connection());
    //                dr = cmd.ExecuteReader();
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        list.Add(dr[0].ToString());

    //                    }
    //                }
    //                dr.Close();

    //                String Flag = String.Join("-", list.ToArray());

    //                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
    //                {
    //                    TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
    //                    Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
    //                    Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
    //                    Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
    //                    Label SalesPrice = (Label)GridView1.Rows[i].Cells[5].FindControl("lblSalesPrice");
    //                    Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
    //                    DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[7].FindControl("ddlCaseType");
    //                    Label Greigh = (Label)GridView1.Rows[i].Cells[8].FindControl("lblGreighReq");
    //                    TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");

    //                    ViewState["AdjustedOrderNo"] = OrderNo.Text;

    //                    sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
    //                    if (obj1.CheckRecordExistInTransaction(sql))
    //                    {
    //                        // empcode = obj1.FetchValue(sql).ToString();

    //                        if (CaseType.SelectedIndex != 0)
    //                        {



    //                            sql = "JCT_OPS_PLANNING_SALEORDER_ADJUSTEMENT_INSERT";
    //                            cmd = new SqlCommand(sql, obj.Connection());
    //                            cmd.CommandType = CommandType.StoredProcedure;
    //                            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
    //                            cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
    //                            cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = ViewState["Sort"];
    //                            cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Qty"]);
    //                            cmd.Parameters.Add("@ACTUAL_WEAVINGSORT", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["WeavingSort"]);
    //                            cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["GreighReq"]);
    //                            cmd.Parameters.Add("@New_SALEORDER", SqlDbType.VarChar, 20).Value = OrderNo.Text;
    //                            cmd.Parameters.Add("@New_SORT", SqlDbType.VarChar, 10).Value = Sort.Text;
    //                            cmd.Parameters.Add("@New_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
    //                            cmd.Parameters.Add("@New_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(Greigh.Text);
    //                            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
    //                            cmd.Parameters.Add("@RePlan", SqlDbType.Char, 1).Value = 'N';
    //                            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
    //                            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
    //                            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
    //                            cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 30).Value = Flag;
    //                            cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);
    //                            cmd.Parameters.Add("@AreaCode", SqlDbType.Decimal).Value = 1006;
    //                            cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = txtSubject.Text;
    //                            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
    //                            cmd.ExecuteNonQuery();
    //                        }
    //                        else
    //                        {
    //                            script = "alert('Please select type greigh cloth required from drop down..!!');";
    //                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
    //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //                        return;
    //                    }

    //                }
    //                ClearForm();
    //                SendMail_SaleOrderAdjustment();

    //                script = "alert('Request Sent Successfully..!!');";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //            }
    //            else
    //            {
    //                script = "alert('Total Quantity adjusted is greater than actual quantity..!! Please make sue that the quantity you are adjusting is less than the quantity of order from which you are transfering greigh..!!');";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //            }
    //        }
    //        else if (txtSubject.Text == "PHouse Greigh Transfer")
    //        {
    //            CheckQty();
    //            if (Convert.ToDecimal(ViewState["TotalQty"]) <= Convert.ToDecimal(ViewState["Qty"]))
    //            {
    //                // int flag = 0;
    //                List<String> list = new List<String>();
    //                String empcode;
    //                sql = "JCT_OPS_SanctionNote_SanctionID";
    //                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                SqlDataReader dr = cmd.ExecuteReader();
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        ViewState["SanctionID"] = dr[0].ToString();
    //                    }
    //                }
    //                dr.Close();

    //                sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
    //                if (obj1.CheckRecordExistInTransaction(sql))
    //                {
    //                    empcode = obj1.FetchValue(sql).ToString();
    //                    sql = "JCT_OPS_SanctionNote_INSERT_DYNAMIC_MAPPING";
    //                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
    //                    cmd1.CommandType = CommandType.StoredProcedure;
    //                    cmd1.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
    //                    cmd1.Parameters.Add("@USERCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
    //                    cmd1.Parameters.Add("@AUTH_EMPCODE", SqlDbType.VarChar, 10).Value = empcode;
    //                    cmd1.Parameters.Add("@AREACODE", SqlDbType.VarChar, 10).Value = "1006";
    //                    cmd1.ExecuteNonQuery();
    //                }
    //                else
    //                {
    //                    script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //                    return;
    //                }

    //                sql = "Select UserLevel from  dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE ID='" + ViewState["SanctionID"] + "'";
    //                cmd = new SqlCommand(sql, obj.Connection());
    //                dr = cmd.ExecuteReader();
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        list.Add(dr[0].ToString());

    //                    }
    //                }
    //                dr.Close();

    //                String Flag = String.Join("-", list.ToArray());

    //                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
    //                {
    //                    TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
    //                    Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
    //                    Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
    //                    Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
    //                    Label SalesPrice = (Label)GridView1.Rows[i].Cells[5].FindControl("lblSalesPrice");
    //                    Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
    //                    DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[7].FindControl("ddlCaseType");
    //                    Label Greigh = (Label)GridView1.Rows[i].Cells[8].FindControl("lblGreighReq");
    //                    TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");

    //                    ViewState["AdjustedOrderNo"] = OrderNo.Text;

    //                    sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
    //                    if (obj1.CheckRecordExistInTransaction(sql))
    //                    {
    //                        // empcode = obj1.FetchValue(sql).ToString();

    //                        if (CaseType.SelectedIndex != 0)
    //                        {



    //                            sql = "JCT_OPS_PLANNING_SALEORDER_ADJUSTEMENT_INSERT";
    //                            cmd = new SqlCommand(sql, obj.Connection());
    //                            cmd.CommandType = CommandType.StoredProcedure;
    //                            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
    //                            cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
    //                            cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = ViewState["Sort"];
    //                            cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Qty"]);
    //                            cmd.Parameters.Add("@ACTUAL_WEAVINGSORT", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["WeavingSort"]);
    //                            cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["GreighReq"]);
    //                            cmd.Parameters.Add("@New_SALEORDER", SqlDbType.VarChar, 20).Value = OrderNo.Text;
    //                            cmd.Parameters.Add("@New_SORT", SqlDbType.VarChar, 10).Value = Sort.Text;
    //                            cmd.Parameters.Add("@New_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
    //                            cmd.Parameters.Add("@New_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(Greigh.Text);
    //                            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
    //                            cmd.Parameters.Add("@RePlan", SqlDbType.Char, 1).Value = 'N';
    //                            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
    //                            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
    //                            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
    //                            cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 30).Value = Flag;
    //                            cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);
    //                            cmd.Parameters.Add("@AreaCode", SqlDbType.Decimal).Value = 1006;
    //                            cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = txtSubject.Text;
    //                            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
    //                            if (String.IsNullOrEmpty(ViewState["LineItem"].ToString()))
    //                            {
    //                                ViewState["LineItem"] = "";
    //                            }

    //                            cmd.Parameters.Add("@Actual_LineItem", SqlDbType.VarChar, 2).Value = ViewState["LineItem"];
    //                            cmd.ExecuteNonQuery();
    //                        }
    //                        else
    //                        {
    //                            script = "alert('Please select type greigh cloth required from drop down..!!');";
    //                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
    //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //                        return;
    //                    }

    //                }
    //                ClearForm();
    //                SendMail_SaleOrderAdjustment();

    //                script = "alert('Request Sent Successfully..!!');";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //            }
    //            else
    //            {
    //                script = "alert('Total Quantity adjusted is greater than actual quantity..!! Please make sue that the quantity you are adjusting is less than the quantity of order from which you are transfering greigh..!!');";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        script = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }



    //}

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
           // sql = "Select distinct Location from jct_ops_monthly_planning where order_no='" + txtOrderNo.Text + "' and status is null and mode='Freezed'";

            sql = "Select distinct Location from jct_ops_planning_order where order_no='" + txtOrderNo.Text + "' and status ='A'";
            //if (obj1.CheckRecordExistInTransaction(sql))
            //{
                String Plant = obj1.FetchValue(sql).ToString();
                if (Plant == "COTTON")
                {
                    PlantCotton();
                }
                else if (Plant == "TAFFETA")
                {
                    PlantTaffeta();
                }
            //}
            //else
            //{
            //    script = "alert('Selected Order in not present in planned orders..!!');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //}


        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }

    protected void PlantCotton()
    {

        if (txtSubject.Text == "Greigh Transfer")
        {


            CheckQty();

            if (Convert.ToDecimal(ViewState["TotalQty"]) <= Convert.ToDecimal(ViewState["Greigh"]))
            {
                // int flag = 0;
                List<String> list = new List<String>();
                String empcode;
                sql = "JCT_OPS_SanctionNote_SanctionID";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViewState["SanctionID"] = dr[0].ToString();
                    }
                }
                dr.Close();

                sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    empcode = obj1.FetchValue(sql).ToString();
                    sql = "JCT_OPS_SanctionNote_INSERT_DYNAMIC_MAPPING";
                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
                    cmd1.Parameters.Add("@USERCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                    cmd1.Parameters.Add("@AUTH_EMPCODE", SqlDbType.VarChar, 10).Value = empcode;
                    cmd1.Parameters.Add("@AREACODE", SqlDbType.VarChar, 10).Value = "1006";
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }
                String Flag = ""; //String.Join("-", list.ToArray());
                sql = "Select min(UserLevel) from  dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE status is null and Auth_dateTime is null and  ID='" + ViewState["SanctionID"] + "'";
                cmd = new SqlCommand(sql, obj.Connection());
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Flag = dr[0].ToString();

                    }
                }
                dr.Close();

                //String Flag = String.Join("-", list.ToArray());

                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
                    Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
                    Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
                    Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
                    Label SalesPrice = (Label)GridView1.Rows[i].Cells[5].FindControl("lblSalesPrice");
                    Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
                    DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[7].FindControl("ddlCaseType");
                    Label Greigh = (Label)GridView1.Rows[i].Cells[8].FindControl("lblGreighReq");
                    TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");

                    ViewState["AdjustedOrderNo"] = OrderNo.Text;

                    sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        // empcode = obj1.FetchValue(sql).ToString();

                        if (CaseType.SelectedIndex != 0)
                        {



                            sql = "JCT_OPS_PLANNING_SALEORDER_ADJUSTEMENT_INSERT";
                            cmd = new SqlCommand(sql, obj.Connection());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
                            cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
                            cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = ViewState["Sort"];
                            cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Qty"]);
                            cmd.Parameters.Add("@ACTUAL_WEAVINGSORT", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["WeavingSort"]);
                            cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["GreighReq"]);
                            cmd.Parameters.Add("@New_SALEORDER", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                            cmd.Parameters.Add("@New_SORT", SqlDbType.VarChar, 10).Value = Sort.Text;
                            cmd.Parameters.Add("@New_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
                            cmd.Parameters.Add("@New_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(Greigh.Text);
                            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                            cmd.Parameters.Add("@RePlan", SqlDbType.Char, 1).Value = 'N';
                            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
                            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
                            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
                            cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 30).Value = Flag;
                            cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);
                            cmd.Parameters.Add("@AreaCode", SqlDbType.Decimal).Value = 1006;
                            cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = txtSubject.Text;
                            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            script = "alert('Please select type greigh cloth required from drop down..!!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        }
                    }
                    else
                    {
                        script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }

                }
                ClearForm();
                SendMail_SaleOrderAdjustment();

                script = "alert('Request Sent Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                script = "alert('Total Quantity adjusted is greater than actual quantity..!! Please make sue that the quantity you are adjusting is less than the quantity of order from which you are transfering greigh..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        else if (txtSubject.Text == "PHouse Greigh Transfer")
        {
            CheckQty();
            if (Convert.ToDecimal(ViewState["TotalQty"]) <= Convert.ToDecimal(ViewState["Greigh"]))
            {
                // int flag = 0;
                List<String> list = new List<String>();
                String empcode;
                sql = "JCT_OPS_SanctionNote_SanctionID";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViewState["SanctionID"] = dr[0].ToString();
                    }
                }
                dr.Close();

                sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    empcode = obj1.FetchValue(sql).ToString();
                    sql = "JCT_OPS_SanctionNote_INSERT_DYNAMIC_MAPPING";
                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
                    cmd1.Parameters.Add("@USERCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                    cmd1.Parameters.Add("@AUTH_EMPCODE", SqlDbType.VarChar, 10).Value = empcode;
                    cmd1.Parameters.Add("@AREACODE", SqlDbType.VarChar, 10).Value = "1006";
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }

                String Flag = ""; //String.Join("-", list.ToArray());
                sql = "Select min(UserLevel) from  dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE status is null and Auth_dateTime is null and  ID='" + ViewState["SanctionID"] + "'";
                cmd = new SqlCommand(sql, obj.Connection());
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Flag = dr[0].ToString();

                    }
                }
                dr.Close();

                //String Flag = String.Join("-", list.ToArray());


                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
                    Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
                    Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
                    Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
                    Label SalesPrice = (Label)GridView1.Rows[i].Cells[5].FindControl("lblSalesPrice");
                    Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
                    DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[7].FindControl("ddlCaseType");
                    Label Greigh = (Label)GridView1.Rows[i].Cells[8].FindControl("lblGreighReq");
                    TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");

                    ViewState["AdjustedOrderNo"] = OrderNo.Text;

                    sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        // empcode = obj1.FetchValue(sql).ToString();

                        if (CaseType.SelectedIndex != 0)
                        {



                            sql = "JCT_OPS_PLANNING_SALEORDER_ADJUSTEMENT_INSERT";
                            cmd = new SqlCommand(sql, obj.Connection());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
                            cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
                            cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = ViewState["Sort"];
                            cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Qty"]);
                            cmd.Parameters.Add("@ACTUAL_WEAVINGSORT", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Sort"]);
                            cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["GreighIssued"]);
                            cmd.Parameters.Add("@New_SALEORDER", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                            cmd.Parameters.Add("@New_SORT", SqlDbType.VarChar, 10).Value = Sort.Text;
                            cmd.Parameters.Add("@New_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
                            cmd.Parameters.Add("@New_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(Greigh.Text);
                            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                            cmd.Parameters.Add("@RePlan", SqlDbType.Char, 1).Value = 'N';
                            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
                            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
                            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
                            cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 30).Value = Flag;
                            cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);
                            cmd.Parameters.Add("@AreaCode", SqlDbType.Decimal).Value = 1013;
                            cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = txtSubject.Text;
                            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
                            if (String.IsNullOrEmpty(ViewState["LineItem"].ToString()))
                            {
                                ViewState["LineItem"] = "";
                            }

                            cmd.Parameters.Add("@Actual_LineItem", SqlDbType.VarChar, 2).Value = ViewState["LineItem"];
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            script = "alert('Please select type greigh cloth required from drop down..!!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        }
                    }
                    else
                    {
                        script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }

                }
                ClearForm();
                SendMail_SaleOrderAdjustment();

                script = "alert('Request Sent Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                script = "alert('Total Quantity adjusted is greater than actual quantity..!! Please make sue that the quantity you are adjusting is less than the quantity of order from which you are transfering greigh..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }


    }

    protected void PlantTaffeta()
    {

        if (txtSubject.Text == "Greigh Transfer Taffeta")
        {


            CheckQty();

            if (Convert.ToDecimal(ViewState["TotalQty"]) <= Convert.ToDecimal(ViewState["Greigh"]))
            {
                // int flag = 0;
                List<String> list = new List<String>();
                String empcode;
                sql = "JCT_OPS_SanctionNote_SanctionID";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViewState["SanctionID"] = dr[0].ToString();
                    }
                }
                dr.Close();

                sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    empcode = obj1.FetchValue(sql).ToString();
                    sql = "JCT_OPS_SanctionNote_INSERT_DYNAMIC_MAPPING";
                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
                    cmd1.Parameters.Add("@USERCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                    cmd1.Parameters.Add("@AUTH_EMPCODE", SqlDbType.VarChar, 10).Value = empcode;
                    cmd1.Parameters.Add("@AREACODE", SqlDbType.VarChar, 10).Value = "1005";
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }

                String Flag = ""; //String.Join("-", list.ToArray());
                sql = "Select min(UserLevel) from  dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE status is null and Auth_dateTime is null and ID='" + ViewState["SanctionID"] + "'";
                cmd = new SqlCommand(sql, obj.Connection());
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Flag = dr[0].ToString();

                    }
                }
                dr.Close();

                //String Flag = String.Join("-", list.ToArray());

                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
                    Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
                    Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
                    Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
                    Label SalesPrice = (Label)GridView1.Rows[i].Cells[5].FindControl("lblSalesPrice");
                    Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
                    DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[7].FindControl("ddlCaseType");
                    Label Greigh = (Label)GridView1.Rows[i].Cells[8].FindControl("lblGreighReq");
                    TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");

                    ViewState["AdjustedOrderNo"] = OrderNo.Text;

                    sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        // empcode = obj1.FetchValue(sql).ToString();

                        if (CaseType.SelectedIndex != 0)
                        {



                            sql = "JCT_OPS_PLANNING_SALEORDER_ADJUSTEMENT_INSERT";
                            cmd = new SqlCommand(sql, obj.Connection());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
                            cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
                            cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = ViewState["Sort"];
                            cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Qty"]);
                            cmd.Parameters.Add("@ACTUAL_WEAVINGSORT", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["WeavingSort"]);
                            cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["GreighReq"]);
                            cmd.Parameters.Add("@New_SALEORDER", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                            cmd.Parameters.Add("@New_SORT", SqlDbType.VarChar, 10).Value = Sort.Text;
                            cmd.Parameters.Add("@New_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
                            cmd.Parameters.Add("@New_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(Greigh.Text);
                            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                            cmd.Parameters.Add("@RePlan", SqlDbType.Char, 1).Value = 'N';
                            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
                            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
                            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
                            cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 30).Value = Flag;
                            cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);
                            cmd.Parameters.Add("@AreaCode", SqlDbType.Decimal).Value = 1005;
                            cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = txtSubject.Text;
                            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            script = "alert('Please select type greigh cloth required from drop down..!!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        }
                    }
                    else
                    {
                        script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }

                }
                ClearForm();
               // SendMail_SaleOrderAdjustment_Taffeta();

                script = "alert('Request Sent Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                script = "alert('Total Quantity adjusted is greater than actual quantity..!! Please make sue that the quantity you are adjusting is less than the quantity of order from which you are transfering greigh..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        else if (txtSubject.Text == "PHouse Greigh Transfer")
        {
            CheckQty();
            if (Convert.ToDecimal(ViewState["TotalQty"]) <= Convert.ToDecimal(ViewState["Greigh"]))
            {
                // int flag = 0;
                List<String> list = new List<String>();
                String empcode;
                sql = "JCT_OPS_SanctionNote_SanctionID";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViewState["SanctionID"] = dr[0].ToString();
                    }
                }
                dr.Close();

                sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    empcode = obj1.FetchValue(sql).ToString();
                    sql = "JCT_OPS_SanctionNote_INSERT_DYNAMIC_MAPPING";
                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
                    cmd1.Parameters.Add("@USERCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                    cmd1.Parameters.Add("@AUTH_EMPCODE", SqlDbType.VarChar, 10).Value = empcode;
                    cmd1.Parameters.Add("@AREACODE", SqlDbType.VarChar, 10).Value = "1013";
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }

                String Flag = ""; //String.Join("-", list.ToArray());
                sql = "Select min(UserLevel) from  dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE status is null and Auth_dateTime is null ID='" + ViewState["SanctionID"] + "'";
                cmd = new SqlCommand(sql, obj.Connection());
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Flag = dr[0].ToString();

                    }
                }
                dr.Close();

                //String Flag = String.Join("-", list.ToArray());


                

                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
                    Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
                    Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
                    Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
                    Label SalesPrice = (Label)GridView1.Rows[i].Cells[5].FindControl("lblSalesPrice");
                    Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
                    DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[7].FindControl("ddlCaseType");
                    Label Greigh = (Label)GridView1.Rows[i].Cells[8].FindControl("lblGreighReq");
                    TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");

                    ViewState["AdjustedOrderNo"] = OrderNo.Text;

                    sql = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" + ViewState["orderno"] + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        // empcode = obj1.FetchValue(sql).ToString();

                        if (CaseType.SelectedIndex != 0)
                        {



                            sql = "JCT_OPS_PLANNING_SALEORDER_ADJUSTEMENT_INSERT";
                            cmd = new SqlCommand(sql, obj.Connection());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = ViewState["SanctionID"];
                            cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
                            cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = ViewState["Sort"];
                            cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Qty"]);
                            cmd.Parameters.Add("@ACTUAL_WEAVINGSORT", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Sort"]);
                            cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["GreighIssued"]);
                            cmd.Parameters.Add("@New_SALEORDER", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                            cmd.Parameters.Add("@New_SORT", SqlDbType.VarChar, 10).Value = Sort.Text;
                            cmd.Parameters.Add("@New_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
                            cmd.Parameters.Add("@New_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(Greigh.Text);
                            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                            cmd.Parameters.Add("@RePlan", SqlDbType.Char, 1).Value = 'N';
                            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
                            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
                            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
                            cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 30).Value = Flag;
                            cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);
                            cmd.Parameters.Add("@AreaCode", SqlDbType.Decimal).Value = 1013;
                            cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = txtSubject.Text;
                            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
                            if (String.IsNullOrEmpty(ViewState["LineItem"].ToString()))
                            {
                                ViewState["LineItem"] = "";
                            }

                            cmd.Parameters.Add("@Actual_LineItem", SqlDbType.VarChar, 2).Value = ViewState["LineItem"];
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            script = "alert('Please select type greigh cloth required from drop down..!!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        }
                    }
                    else
                    {
                        script = "alert('No Sale Person Mapped with this sale order in RAMCO while generating sale order..!! No Greigh Transfer is possible in this case..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }

                }
                ClearForm();
               // SendMail_SaleOrderAdjustment_Taffeta();

                script = "alert('Request Sent Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                script = "alert('Total Quantity adjusted is greater than actual quantity..!! Please make sue that the quantity you are adjusting is less than the quantity of order from which you are transfering greigh..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }


    }

    protected void lnkAddRow_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void lnkPopUp_Click(object sender, EventArgs e)
    {
       
        lnkPopUp_ModalPopupExtender.Show();


    }

    protected void grd_SelectedIndexChanged1(object sender, EventArgs e)
    {

        if (txtSubject.Text == "Greigh Transfer" || txtSubject.Text == "Greigh Transfer Taffeta")
        {
            ViewState["orderno"] = grd.SelectedRow.Cells[1].Text;
            ViewState["Sort"] = grd.SelectedRow.Cells[2].Text;
            ViewState["WeavingSort"] = grd.SelectedRow.Cells[3].Text;
            ViewState["Qty"] = grd.SelectedRow.Cells[4].Text;
            ViewState["Greigh"] = grd.SelectedRow.Cells[6].Text;
            ViewState["GreighAdj"] = grd.SelectedRow.Cells[5].Text;
            ViewState["GreighProduced"] = grd.SelectedRow.Cells[9].Text;

            if (String.IsNullOrEmpty(grd.SelectedRow.Cells[10].Text))
            {
                ViewState["Adjusted"] = 0;
            }
            else
            {
                ViewState["Adjusted"] = grd.SelectedRow.Cells[10].Text;
            }

            if (String.IsNullOrEmpty(grd.SelectedRow.Cells[5].Text))
            {
                ViewState["GreighReq"] = Convert.ToDecimal(ViewState["GreighAdj"]) + Convert.ToDecimal(ViewState["Greigh"]);
            }
            else
            {
                ViewState["GreighReq"] = Convert.ToDecimal(ViewState["Greigh"]);
            }
            SetInitialRow();
            pnlButtons.Visible = true;

        }
        else if (txtSubject.Text == "PHouse Greigh Transfer")
        {
            ViewState["orderno"] = grd.SelectedRow.Cells[1].Text;
            ViewState["Sort"] = grd.SelectedRow.Cells[2].Text;
            ViewState["LineItem"] = grd.SelectedRow.Cells[3].Text;
            ViewState["Shade"] = grd.SelectedRow.Cells[4].Text;
            ViewState["Qty"] = grd.SelectedRow.Cells[7].Text;
            ViewState["GreighIssued"] = grd.SelectedRow.Cells[9].Text;

            SetInitialRow();
            pnlButtons.Visible = true;
        }
    }

    protected void ClearForm()
    {
        txtOrderNo.Text = "";
        ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue("00"));
        pnlButtons.Visible = false;
        Panel1.Visible = false;
        Panel2.Visible = false;
    }

    private void SendMail_SaleOrderAdjustment()
    {


        string from, to, bcc, cc, subject, body;


        StringBuilder sb = new StringBuilder();

        sql = "JCT_OPS_GET_SALE_PERSON_EMAIL ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["ActualOrder_EmailID"] = dr[0].ToString();
            }
        }
        dr.Close();

        sql = "JCT_OPS_GET_SALE_PERSON_EMAIL ";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ViewState["AdjustedOrderNo"];
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["Adjusted_EmailID"] = dr[0].ToString();
            }
        }
        dr.Close();


        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");



        // sb.Append("<head>");
        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Sale Order Adjustment Request has been generated in OPS  with Sanction ID : " + ViewState["SanctionID"] + "<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Order No</th> <th> Sort</th> <th> Weaving Sort</th> <th> Quantity</th> <th> Greigh Required</th> <th> Adjusted Qty</th>  <th> Remarks</th> </tr>");
        sql = "SELECT ACTUAL_SALEORDER AS [OrderNo],ACTUAL_SORT AS [Sort],ACTUAL_WEAVINGSORT AS [WeavingSort],ACTUAL_QTY AS [QTY],ACTUAL_GREIGHREQ AS [GreighReq],ISNULL(AdjustedQty,0) AS [AdjustedQty],Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE SanctionID ='" + ViewState["SanctionID"] + "'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td>  </tr> ");

            }
        }
        sb.AppendLine("</table>");
        sb.AppendLine("<br />");
        sb.AppendLine("Adjusted Order Details : <br/>");
        dr.Close();
        sb.AppendLine("<table class=\"gridtable\"><tr><th> Order No</th> <th> Sort</th> <th> Line Item</th> <th> Shade</th> <th>QTY</th> <th>  Greigh Req</th>  <th>Adjusted Qty</th>   </tr> ");
        sql = "SELECT SALEORDER AS [OrderNo],SORT,LineItem,Shade,QTY,GREIGHREQ,AdjustedQty FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTED_ORDERS  WHERE SanctionID ='" + ViewState["SanctionID"] + "'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td>  </tr> ");

            }
        }

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        //to = "jatindutta@jctltd.com";
        to = "neeraj@jctltd.com,karanjitsaini@jctltd.com,bipansharma@jctltd.com," + ViewState["ActualOrder_EmailID"] + "," + ViewState["Adjusted_EmailID"];   //Email Address of Receiver
        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        cc = "sobti@jctltd.com,rajeshkapoor@jctltd.com,rkkapoor@jctltd.com,mikeops@jctltd.com";
        subject = "Request - Greigh Transfer";
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
                mail.CC.Add(new MailAddress(bcc));
            }
            mail.CC.Add(new MailAddress(cc));
        }

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;
    }

    private void SendMail_SaleOrderAdjustment_Taffeta()
    {
        string from, to, bcc, cc, subject, body;


        StringBuilder sb = new StringBuilder();

        sql = "JCT_OPS_GET_SALE_PERSON_EMAIL ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["ActualOrder_EmailID"] = dr[0].ToString();
            }
        }
        else
        {
            ViewState["ActualOrder_EmailID"] = "";
        }

        dr.Close();

        sql = "JCT_OPS_GET_SALE_PERSON_EMAIL";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ViewState["AdjustedOrderNo"];
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ViewState["Adjusted_EmailID"] = dr[0].ToString();
            }
        }
        else
        {
            ViewState["Adjusted_EmailID"] = "";
        }
        dr.Close();


        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");



        // sb.Append("<head>");
        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Sale Order Adjustment Request has been generated in OPS with Sanction ID : " + ViewState["SanctionID"] + "<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Order No</th> <th> Sort</th> <th> Weaving Sort</th> <th> Quantity</th> <th> Greigh Required</th> <th> Adjusted Qty</th>  <th> Remarks</th> </tr>");
        sql = "SELECT ACTUAL_SALEORDER AS [OrderNo],ACTUAL_SORT AS [Sort],ACTUAL_WEAVINGSORT AS [WeavingSort],ACTUAL_QTY AS [QTY],ACTUAL_GREIGHREQ AS [GreighReq],ISNULL(AdjustedQty,0) AS [AdjustedQty],Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE SanctionID ='" + ViewState["SanctionID"] + "'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td>  </tr> ");

            }
        }
        sb.AppendLine("</table>");
        sb.AppendLine("<br />");
        sb.AppendLine("Adjusted Order Details : <br/>");
        dr.Close();
        sb.AppendLine("<table class=\"gridtable\"><tr><th> Order No</th> <th> Sort</th> <th> Line Item</th> <th> Shade</th> <th>QTY</th> <th>  Greigh Req</th>  <th>Adjusted Qty</th>   </tr> ");
        sql = "SELECT SALEORDER AS [OrderNo],SORT,LineItem,Shade,QTY,GREIGHREQ,AdjustedQty FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTED_ORDERS  WHERE SanctionID ='" + ViewState["SanctionID"] + "'";
        dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                sb.AppendLine("<tr> <td>  " + dr[0].ToString() + " </td> <td>  " + dr[1].ToString() + " </td>  <td> " + dr[2].ToString() + "</td>  <td> " + dr[3].ToString() + "</td>  <td> " + dr[4].ToString() + "</td>  <td>" + dr[5].ToString() + "</td><td>" + dr[6].ToString() + "</td>  </tr> ");

            }
        }

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> ");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        if (ViewState["ActualOrder_EmailID"].ToString() == "" || ViewState["ActualOrder_EmailID"].ToString() == "")
        {
            to = "trivendermehta@jctltd.com,nandi@jctltd.com";   //Email Address of Receiver
            bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
            cc = "husanlal@jctltd.com,mikeops@jctltd.com";
        }
        else
        {
            to = "trivendermehta@jctltd.com,nandi@jctltd.com," + ViewState["ActualOrder_EmailID"] + "," + ViewState["Adjusted_EmailID"];   //Email Address of Receiver
            bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
            cc = "husanlal@jctltd.com,mikeops@jctltd.com";
        }
        //to = "jatindutta@jctltd.com";
        //to = "trivendermehta@jctltd.com,nandi@jctltd.com," + ViewState["ActualOrder_EmailID"] + "," + ViewState["Adjusted_EmailID"];   //Email Address of Receiver
        //bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        //cc = "birendra@jctltd.com,mikeops@jctltd.com";
        subject = "Request - Greigh Transfer";
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
                mail.CC.Add(new MailAddress(bcc));
            }
            mail.CC.Add(new MailAddress(cc));
        }

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/SaleOrderAdjustment.aspx");
    }

    protected void ddlGreigh_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList CaseType = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)CaseType.Parent.Parent;

        TextBox OrderNo = (TextBox)gvRow.FindControl("txtOrdNo");
        Label Sort = (Label)gvRow.FindControl("lblSort");
        Label LineItem = (Label)gvRow.FindControl("lblLineItem");
        Label Shade = (Label)gvRow.FindControl("lblShade");
        Label SalesPrice = (Label)gvRow.FindControl("lblSalesPrice");
        Label Qty = (Label)gvRow.FindControl("lblQty");
        Label GreighReq = (Label)gvRow.FindControl("lblGreighReq");
        TextBox GreighAdjust = (TextBox)gvRow.FindControl("txtAdjust");
            if (Sort.Text != "")
        {
        if (CaseType.SelectedIndex == 1)
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr[0].ToString();
                }
            }
            dr.Close();

        }
        else
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    GreighReq.Text = dr[0].ToString();
                }
            }
            dr.Close();
        }
        }
            else
            {
                script = "alert('Please Refresh the order to fetch details..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
    }

    protected void lnkCheckStatus_Click(object sender, EventArgs e)
    {
        pnlCheckStatus.Visible = true;
        sql = "JCT_OPS_FETCH_SANCTION_NOTE_DETAIL_REPORT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdCheckStatus.DataSource = ds;
        grdCheckStatus.DataBind();
    }

    //protected void CheckQty()
    //{
    //    Decimal TotalQty = 0;
    //    for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
    //    {
    //        Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
    //        if (Qty.Text == "")
    //        {

    //        }
    //        else
    //        {
    //            TotalQty = TotalQty + Convert.ToDecimal(Qty.Text);
    //        }
    //        ViewState["TotalQty"] = TotalQty;
         
    //        ViewState["TotalQty"] = Convert.ToDecimal(ViewState["TotalQty"]) + Convert.ToDecimal(ViewState["Adjusted"]);

    //    }
    //}

    protected void CheckQty()
    {
        Decimal TotalQty = 0;

        if (txtSubject.Text == "Greigh Transfer")
        {

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                TextBox Qty = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");
                if (Qty.Text == "")
                {

                }
                else
                {
                    TotalQty = TotalQty + Convert.ToDecimal(Qty.Text);
                }
                ViewState["TotalQty"] = TotalQty;
            }
            ViewState["TotalQty"] = Convert.ToDecimal(ViewState["TotalQty"]) + Convert.ToDecimal(ViewState["Adjusted"]);
        }
        else if (txtSubject.Text == "PHouse Greigh Transfer")
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                TextBox Qty = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");
                if (Qty.Text == "")
                {

                }
                else
                {
                    TotalQty = TotalQty + Convert.ToDecimal(Qty.Text);
                }
                ViewState["TotalQty"] = TotalQty;
            }
            ViewState["TotalQty"] = Convert.ToDecimal(ViewState["TotalQty"]) + Convert.ToDecimal(ViewState["GreighIssued"]);
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_GREIGE_TRANSFER_SEARCH_ORDER";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@sortno", SqlDbType.VarChar, 10).Value = txtSortNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdSearchOrders.DataSource = ds.Tables[0];
        grdSearchOrders.DataBind();
    }

    protected void grdSearchOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtOrderNo.Text = grdSearchOrders.SelectedRow.Cells[1].Text;
        pnlSearchorders.Visible = false;
    }

}