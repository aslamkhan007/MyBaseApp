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

public partial class OPS_SaleOrderAdjustment : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    String script;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
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
                        //extract the TextBox values

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
                        //  drCurrentRow["RowNumber"] = i + 1;

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
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
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


                sql = "JCT_OPS_FETCH_NEW_SALEORDER_DETAILS";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = OrderNo.Text;

                //cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
                dt.Columns.Add(new DataColumn("Sort", typeof(string)));
                dt.Columns.Add(new DataColumn("LineItem", typeof(string)));
                dt.Columns.Add(new DataColumn("Shade", typeof(string)));
                dt.Columns.Add(new DataColumn("Qty", typeof(string)));
                dt.Columns.Add(new DataColumn("SalesPrice", typeof(string)));
                dt.Columns.Add(new DataColumn("GreighReq", typeof(string)));
                dt.Columns.Add(new DataColumn("GreighAdjust", typeof(string)));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DataRow drow = null;
                        drow = dt.NewRow();
                        drow["OrderNo"] = dr[0].ToString();
                        drow["Sort"] = dr[1].ToString();
                        drow["LineItem"] = dr[2].ToString();
                        drow["Shade"] = dr[3].ToString();
                        drow["Qty"] = dr[4].ToString();
                        drow["SalesPrice"] = dr[5].ToString();
                        drow["GreighReq"] = string.Empty;
                        drow["GreighAdjust"] = string.Empty;
                        dt.Rows.Add(drow);
                        //dr = dt.NewRow();
                        //Store the DataTable in ViewState

                        //ViewState["RefreshTable"] = null;
                        if (ViewState["RefreshTable"] == null)
                        {
                            ViewState["RefreshTable"] = dt;
                        }
                        else
                        {
                            ViewState.Add("RefreshTable", dt);
                            Response.Write(ViewState["RefreshTable"]);
                        }

                    }
                }
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                ViewState.Add("CurrentTable", ViewState["RefreshTable"]);
                GridView1.DataSource = ViewState["RefreshTable"];
                GridView1.DataBind();
            }


        }


        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    private void Bindgrid()
    {

    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Select * from JCT_OPS_MONTHLY_PLANNING WHERE YEARMONTH =(SELECT MAX(YEARMONTH) FROM JCT_OPS_MONTHLY_PLANNING WHERE ORDER_NO='" + txtOrderNo.Text + "' AND STATUS IS NULL) AND ORDER_NO='" + txtOrderNo.Text + "' AND STATUS IS NULL ";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                sql = "JCT_OPS_FETCH_ORDER_SALEORDER_ADJUSTMENT";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
                //cmd.Parameters.Add("@YEAR", SqlDbType.Decimal).Value = Convert.ToDecimal(ddlYear.SelectedItem.Text);
                //cmd.Parameters.Add("@MONTH", SqlDbType.Decimal).Value = Convert.ToDecimal(ddlMonth.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grd.DataSource = ds;
                grd.DataBind();
            }
            else
            {
                script = "alert('Order is not considered in planning. Please enter order no which is planned..!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
       
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
       
     
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
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
                Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
                Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
                Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
                Label SalesPrice = (Label)GridView1.Rows[i].Cells[5].FindControl("lblSalesPrice");
                Label Qty = (Label)GridView1.Rows[i].Cells[6].FindControl("lblQty");
                DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[7].FindControl("ddlCaseType");
                Label GreighReq = (Label)GridView1.Rows[i].Cells[8].FindControl("lblGreighReq");
                TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[9].FindControl("txtAdjust");

                ViewState["AdjustedOrderNo"] = OrderNo.Text;

                if (CaseType.SelectedIndex != 0)
                {
                    int flag = 0;
                    List<String> list = new List<String>();
                    sql = "Select UserLevel from  dbo.Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='1006' and Status='A'";
                     cmd = new SqlCommand(sql, obj.Connection());
                     dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());

                        }
                    }
                    dr.Close();
                    String FlagAuth = String.Join("-", list.ToArray());

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
                    cmd.Parameters.Add("@New_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighReq.Text);
                    cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value =  Session["EmpCode"];
                    cmd.Parameters.Add("@RePlan", SqlDbType.Char, 1).Value = 'N';
                    cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
                    cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
                    cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
                    cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 30).Value = FlagAuth;
                    cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);
                    cmd.Parameters.Add("@AreaCode", SqlDbType.Decimal).Value = 1006;
                    cmd.Parameters.Add("@Subject", SqlDbType.VarChar,50).Value = txtSubject.Text;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar,500).Value = txtRemarks.Text;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    script = "alert('Please select type greigh cloth required from drop down..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
             
            }
            ClearForm();
            SendMail_SaleOrderAdjustment();
            script = "alert('Request Sent Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }

    protected void lnkAddRow_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
    //        {
    //            TextBox OrderNo = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtOrdNo");
    //            Label Sort = (Label)GridView1.Rows[i].Cells[2].FindControl("lblSort");
    //            Label LineItem = (Label)GridView1.Rows[i].Cells[3].FindControl("lblLineItem");
    //            Label Shade = (Label)GridView1.Rows[i].Cells[4].FindControl("lblShade");
    //            Label Qty = (Label)GridView1.Rows[i].Cells[5].FindControl("lblQty");
    //            DropDownList CaseType = (DropDownList)GridView1.Rows[i].Cells[6].FindControl("ddlCaseType");
    //            Label GreighReq = (Label)GridView1.Rows[i].Cells[7].FindControl("lblGreighReq");
    //            TextBox GreighAdjust = (TextBox)GridView1.Rows[i].Cells[8].FindControl("txtAdjust");

    //            sql = "JCT_OPS_PLANNING_SALEORDER_ADJUSTEMENT_INSERT";
    //            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = ViewState["orderno"];
    //            cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = ViewState["Sort"];
    //            cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Qty"]);
    //            cmd.Parameters.Add("@ACTUAL_WEAVINGSORT", SqlDbType.VarChar, 10).Value = Convert.ToDecimal(ViewState["WeavingSort"]);
    //            cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighReq.Text);
    //            cmd.Parameters.Add("@ACTUAL_SALEORDER", SqlDbType.VarChar, 20).Value = OrderNo.Text;
    //            cmd.Parameters.Add("@ACTUAL_SORT", SqlDbType.VarChar, 10).Value = Sort.Text;
    //            cmd.Parameters.Add("@ACTUAL_QTY", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.Text);
    //            cmd.Parameters.Add("@ACTUAL_GREIGHREQ", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighReq.Text);
    //            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem.Text);
    //            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = CaseType.SelectedItem.Text;
    //            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30).Value = Shade.Text;
    //            cmd.Parameters.Add("@AdjustedQty", SqlDbType.Decimal).Value = Convert.ToDecimal(GreighAdjust.Text);

    //            cmd.ExecuteNonQuery();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        script = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }


    //}

    protected void lnkPopUp_Click(object sender, EventArgs e)
    {
       
        lnkPopUp_ModalPopupExtender.Show();


    }

    protected void grd_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ViewState["orderno"] = grd.SelectedRow.Cells[1].Text;
        ViewState["Sort"] = grd.SelectedRow.Cells[2].Text;
        ViewState["WeavingSort"] = grd.SelectedRow.Cells[3].Text;
        ViewState["Qty"] = grd.SelectedRow.Cells[4].Text;
        ViewState["GreighReq"] = grd.SelectedRow.Cells[6].Text;
        ViewState["GreighProduced"] = grd.SelectedRow.Cells[8].Text;
        SetInitialRow();
        pnlButtons.Visible = true;

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
            while(dr.Read())
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
        sb.AppendLine("Sale Order Adjustment Request has been generated in OPS.<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Order No</th> <th> Sort</th> <th> Weaving Sort</th> <th> Quantity</th> <th> Greigh Required</th> <th> Adjusted Qty</th>  <th> Remarks</th> </tr>");
        sql = "SELECT ACTUAL_SALEORDER AS [OrderNo],ACTUAL_SORT AS [Sort],ACTUAL_WEAVINGSORT AS [WeavingSort],ACTUAL_QTY AS [QTY],ACTUAL_GREIGHREQ AS [GreighReq],ISNULL(AdjustedQty,0) AS [AdjustedQty],Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE SanctionID ='"+ ViewState["SanctionID"] +"'";
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

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. ");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");
     

        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        //to = "jatindutta@jctltd.com";
        to = "neeraj@jctltd.com,karanjitsaini@jctltd.com," + ViewState["ActualOrder_EmailID"] + "," + ViewState["Adjusted_EmailID"];   //Email Address of Receiver
        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        cc = "sobti@jctltd.com,rkkapoor@jctltd.com,mikeops@jctltd.com";
        subject = "Request - Sale Order Adjustment";
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

    //protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton img = (ImageButton)sender;
    //    GridViewRow gvRow = (GridViewRow)img.NamingContainer;
    //    TextBox OrderNo = (TextBox)gvRow.FindControl("txtOrdNo");
    //    Label Sort = (Label)gvRow.FindControl("lblSort");
    //    Label LineItem = (Label)gvRow.FindControl("lblLineItem");
    //    Label Shade = (Label)gvRow.FindControl("lblShade");
    //    Label Qty = (Label)gvRow.FindControl("lblQty");
    //    DropDownList CaseType = (DropDownList)gvRow.FindControl("ddlCaseType");
    //    TextBox GreighReq = (TextBox)gvRow.FindControl("lblGreighReq");
    //    TextBox GreighAdjust = (TextBox)gvRow.FindControl("txtAdjust");

    //    sql = "JCT_OPS_FETCH_NEW_SALEORDER_DETAILS";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = OrderNo.Text;

    //    //cmd.ExecuteNonQuery();
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    DataTable dt = new DataTable();
    //    dt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
    //    dt.Columns.Add(new DataColumn("Sort", typeof(string)));
    //    dt.Columns.Add(new DataColumn("LineItem", typeof(string)));
    //    dt.Columns.Add(new DataColumn("Shade", typeof(string)));
    //    dt.Columns.Add(new DataColumn("Qty", typeof(string)));
    //    dt.Columns.Add(new DataColumn("GreighReq", typeof(string)));
    //    dt.Columns.Add(new DataColumn("GreighAdjust", typeof(string)));
    //    if (dr.HasRows)
    //    {
    //        while (dr.Read())
    //        {
    //            DataRow drow = null;
    //            drow = dt.NewRow();
    //            drow["OrderNo"] = dr[0].ToString();
    //            drow["Sort"] = dr[1].ToString();
    //            drow["LineItem"] = dr[2].ToString();
    //            drow["Shade"] = dr[3].ToString();
    //            drow["Qty"] = dr[4].ToString();
    //            drow["GreighReq"] = string.Empty;
    //            drow["GreighAdjust"] = string.Empty;
    //            dt.Rows.Add(drow);
    //            //dr = dt.NewRow();
    //            //Store the DataTable in ViewState

    //            //ViewState["RefreshTable"] = null;
    //            if (ViewState["RefreshTable"] == null)
    //            {
    //                ViewState["RefreshTable"] = dt;
    //            }
    //            else
    //            {
    //                ViewState.Add("RefreshTable", dt);
    //            }

    //        }
    //   }
    //    //SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    //DataSet ds = new DataSet();
    //    //da.Fill(ds);
    //    ViewState.Add("CurrentTable", ViewState["RefreshTable"]);
    //    GridView1.DataSource = ViewState["RefreshTable"];
    //    GridView1.DataBind();


    //    //try
    //    //{
    //    //    int rowIndex = 0;

    //    //    if (ViewState["CurrentTable"] != null)
    //    //    {
    //    //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
    //    //        DataRow drCurrentRow = null;
    //    //        if (dtCurrentTable.Rows.Count > 0)
    //    //        {
    //    //            for (int i = 0; i <= dtCurrentTable.Rows.Count - 1; i++)
    //    //            {
    //    //                //extract the TextBox values

    //    //                 OrderNo = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txtOrdNo");
    //    //                 Sort = (Label)GridView1.Rows[rowIndex].Cells[2].FindControl("lblSort");
    //    //                 LineItem = (Label)GridView1.Rows[rowIndex].Cells[3].FindControl("lblLineItem");
    //    //                 Shade = (Label)GridView1.Rows[rowIndex].Cells[4].FindControl("lblShade");
    //    //                 Qty = (Label)GridView1.Rows[rowIndex].Cells[5].FindControl("lblQty");
    //    //                 CaseType = (DropDownList)GridView1.Rows[rowIndex].Cells[6].FindControl("ddlCaseType");
    //    //                 GreighReq = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("lblGreighReq");
    //    //                 GreighAdjust = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtAdjust");

    //    //                drCurrentRow = dtCurrentTable.NewRow();
    //    //                //  drCurrentRow["RowNumber"] = i + 1;

    //    //                dtCurrentTable.Rows[i]["OrderNo"] = OrderNo.Text;
    //    //                dtCurrentTable.Rows[i]["Sort"] = Sort.Text;
    //    //                dtCurrentTable.Rows[i]["LineItem"] = LineItem.Text;
    //    //                dtCurrentTable.Rows[i]["Shade"] = Shade.Text;
    //    //                dtCurrentTable.Rows[i]["Qty"] = Qty.Text;
    //    //                dtCurrentTable.Rows[i]["GreighReq"] = GreighReq.Text;
    //    //                dtCurrentTable.Rows[i]["GreighAdjust"] = GreighAdjust.Text;
    //    //                rowIndex++;

    //    //            }
    //    //            dtCurrentTable.Rows.Add(drCurrentRow);
    //    //            ViewState["CurrentTable"] = dtCurrentTable;
    //    //            ViewState.Add("CurrentTable", ViewState["RefreshTable"]);


    //    //            GridView1.DataSource = ViewState["CurrentTable"];
    //    //            GridView1.DataBind();
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        Response.Write("ViewState is null");
    //    //    }

    //    //    //Set Previous Data on Postbacks
    //    //    SetPreviousData();

    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    script = "alert('" + ex.Message + "');";
    //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    //}





    //}

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
}