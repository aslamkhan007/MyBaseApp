using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_BeamSaleOrderMapping : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    String script;
    DataTable dt = new DataTable();
    string gvUniqueID = String.Empty;
    int gvNewPageIndex = 0;
    int gvEditIndex = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        lnkSave.Attributes.Add("OnClientClick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(lnkSave, null) + ";");
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        try
        {
            FillData();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void FillData()
    {
        try
        {
            sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING_FETCH_DATA_FROM_WEAVING";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateFrom.Text);
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text);
            cmd.Parameters.Add("@Sort", SqlDbType.VarChar, 10).Value = txtSort.Text;
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Text;
            cmd.Parameters.Add("@IssueNo", SqlDbType.Char, 10).Value = txtIssueNo.Text;
            cmd.Parameters.Add("@Type", SqlDbType.Char, 1).Value = ddlType.SelectedItem.Value;

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataRow drow = dt.NewRow();
                    drow["iss_no"] = dr["iss_no"].ToString();
                    drow["split"] = dr["SPLIT"].ToString();
                    drow["Flag"] = dr["Flag"].ToString();
                    drow["date"] = dr["date"].ToString();
                    drow["sort_no"] = dr["sort_no"].ToString();
                    drow["mc_type"] = dr["mc_type"].ToString();
                    drow["beam_no"] = dr["beam_no"].ToString();
                    drow["Type"] = "";
                    drow["order_no"] = dr["order_no"].ToString();
                    drow["LeftLength"] = dr["LeftLength"].ToString();
                    drow["length"] = dr["length"].ToString();

                    dt.Rows.Add(drow);
                    if (ViewState["data"] == null)
                    {
                        ViewState["data"] = dt;
                    }
                    else
                    {
                        ViewState.Add("data", dt);
                    }
                }
            }
            else
            {
                script = "alert('No Record Present for the selected options.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                grdDetail.DataSource = null;
                grdDetail.DataBind();
                return;
            }
            dr.Close();
          
            grdDetail.DataSource = ViewState["data"];
            grdDetail.DataBind();
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void DataTable()
    {
       
        dt.Columns.Add("iss_no");
        dt.Columns.Add("split");
        dt.Columns.Add("Flag");
        dt.Columns.Add("date");
        dt.Columns.Add("sort_no");
        dt.Columns.Add("mc_type");
        dt.Columns.Add("beam_no");
        dt.Columns.Add("type");
        dt.Columns.Add("order_no");
        dt.Columns.Add("LeftLength");
        dt.Columns.Add("length");
      
       
        
    }

    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdDetail.PageIndex = e.NewPageIndex;
            FillData();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        CheckBox cbHeader = (CheckBox)grdSaleOrder.HeaderRow.FindControl("chbHeader");
        if (cbHeader.Checked == true)
        {
            float Length;
            float BeamLength =float.Parse(ViewState["LeftLength"].ToString());
            for (int i = 0; i <= grdSaleOrder.Rows.Count - 1; i++)
            {
                Label orderno = (Label)grdSaleOrder.Rows[i].FindControl("lblOrderNo");
                TextBox Allocatedlength = (TextBox)grdSaleOrder.Rows[i].FindControl("txtSizingDone");
                Label Sort = (Label)grdSaleOrder.Rows[i].FindControl("lblSort");
                Length = float.Parse(Allocatedlength.Text);
                Label SizingLeft = (Label)grdSaleOrder.Rows[i].FindControl("lblSizingLeft");
                float Left = float.Parse(SizingLeft.Text);

                if (Left + 300 >= float.Parse(Allocatedlength.Text))    // Changed 500 mtrs to 300 mtrs on August 1 2014
                {
                if (Length > BeamLength)
                {
                    script = "alert('Allocated length cannot be greater than Beam Length of Beam : " + ViewState["beam_no"] + ". Please check the record before saving data.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING_INSERT";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@iss_no", SqlDbType.Char, 10).Value = ViewState["iss_no"];
                    cmd.Parameters.Add("@Flag", SqlDbType.Char, 10).Value = ViewState["Flag"];
                    cmd.Parameters.Add("@split", SqlDbType.Char, 1).Value = ViewState["split"];
                    cmd.Parameters.Add("@sort_no", SqlDbType.Int).Value = ViewState["sort_no"];
                    cmd.Parameters.Add("@mc_type", SqlDbType.VarChar, 3).Value = ViewState["mc_type"];
                    cmd.Parameters.Add("@beam_no", SqlDbType.SmallInt).Value = ViewState["beam_no"];
                    cmd.Parameters.Add("@type", SqlDbType.VarChar, 1).Value = ViewState["type"];
                    cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 18).Value = orderno.Text;
                    cmd.Parameters.Add("@AllocatedLength", SqlDbType.Float).Value = Length;
                    cmd.Parameters.Add("@Length", SqlDbType.Float).Value = float.Parse(ViewState["Length"].ToString());
                    cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                    cmd.ExecuteNonQuery();
                    BeamLength = BeamLength - Length;
                }
                }
                else
                {
                    script = "alert('Cannot save more than 300 mtrs extra in order qauntity..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                   
             
            }
                    FillData();
                    FetchNewRowData();
                    Decimal sort = Convert.ToDecimal(ViewState["sort_no"].ToString());
                    float len = float.Parse(ViewState["Length"].ToString());
                    FillSaleOrderGrid(sort, len);
          
            script = "alert('Record Added Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else
        {
            try
            {
              
                for (int i = 0; i <= grdSaleOrder.Rows.Count - 1; i++)
                    {

                        if (grdSaleOrder.Rows[i].RowType != DataControlRowType.Header)
                        {
                            CheckBox cb = (CheckBox)grdSaleOrder.Rows[i].FindControl("chbRow");
                            if (cb.Checked == true)
                            {
                                Label orderno = (Label)grdSaleOrder.Rows[i].FindControl("lblOrderNo");
                                TextBox Allocatedlength = (TextBox)grdSaleOrder.Rows[i].FindControl("txtSizingDone");
                                float Length = float.Parse(Allocatedlength.Text);
                                float BeamLength = float.Parse(ViewState["LeftLength"].ToString());
                                Label SizingLeft = (Label)grdSaleOrder.Rows[i].FindControl("lblSizingLeft");
                                float Left = float.Parse(SizingLeft.Text);
                                if (Left + 300 >= float.Parse(Allocatedlength.Text)) // Changed 500 mtrs to 300 mtrs on August 1 2014
                                {

                                if (float.Parse(Allocatedlength.Text) > BeamLength)
                                {
                                    script = "alert('Allocated length cannot be greater than Beam Length of Beam : " + ViewState["beam_no"] + ". Please check the record before saving data.');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                                }
                                else
                                { 
                                InsertRecord(orderno.Text, Length);
                                script = "alert('Record Added Successfully..!!');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                                }
                                }

                                else
                                {
                                    script = "alert('Cannot save more than 300 mtrs extra in order qauntity..!!');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                                }
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
    }

    protected void FetchNewRowData()
    { 
        //GridViewRow gvrow =(GridViewRow)grdSaleOrder.Rows[0]      
        int index = Convert.ToInt16(ViewState["index"].ToString()); 
        Label sort_no = (Label)grdDetail.Rows[index].FindControl("lblsort_no");
        Label LeftLength = (Label)grdDetail.Rows[index].FindControl("lblLeftLength");
        Label Length = (Label)grdDetail.Rows[index].FindControl("lblLength");
        Label iss_no = (Label)grdDetail.Rows[index].FindControl("lbliss_no");
        Label Flag = (Label)grdDetail.Rows[index].FindControl("lblFlag");
        Label split = (Label)grdDetail.Rows[index].FindControl("lblsplit");
        Label date = (Label)grdDetail.Rows[index].FindControl("lbldate");
        Label mc_type = (Label)grdDetail.Rows[index].FindControl("lblmc_type");
        Label beam_no = (Label)grdDetail.Rows[index].FindControl("lblbeam_no");
       // Label type = (Label)grdDetail.Rows[index].FindControl("lbltype");
        ViewState["sort_no"] = sort_no.Text;
        ViewState["Length"] = Length.Text;
        ViewState["LeftLength"] = LeftLength.Text;
        ViewState["iss_no"] = iss_no.Text;
        ViewState["Flag"] = Flag.Text;
        ViewState["split"] = split.Text;
        ViewState["date"] = date.Text;
        ViewState["mc_type"] = mc_type.Text;
        ViewState["beam_no"] = beam_no.Text;
        ViewState["type"] = "";
    }

    protected void InsertRecord(String OrderNo,float AllocatedLength)
    {
        try
        {
            float BeamLength = float.Parse(ViewState["LeftLength"].ToString());
            if (AllocatedLength > BeamLength)
            {
                script = "alert('Allocated length cannot be greater than Beam Length of Beam : "+ ViewState["beam_no"] +". Please check the record before saving data.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            { 
                sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING_INSERT";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iss_no", SqlDbType.Char, 10).Value = ViewState["iss_no"];
                cmd.Parameters.Add("@Flag", SqlDbType.Char, 10).Value = ViewState["Flag"];
                cmd.Parameters.Add("@split", SqlDbType.Char, 1).Value = ViewState["split"];
                cmd.Parameters.Add("@sort_no", SqlDbType.Int).Value =ViewState["sort_no"];
                cmd.Parameters.Add("@mc_type", SqlDbType.VarChar, 3).Value = ViewState["mc_type"];
                cmd.Parameters.Add("@beam_no", SqlDbType.SmallInt).Value = ViewState["beam_no"];
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 1).Value = ViewState["type"];
                cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 18).Value = OrderNo;
                cmd.Parameters.Add("@AllocatedLength", SqlDbType.Float).Value = AllocatedLength;
                cmd.Parameters.Add("@Length", SqlDbType.Float).Value = float.Parse(ViewState["Length"].ToString());
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value =Session["EmpCode"];
                cmd.ExecuteNonQuery();

            
                FillData();
                FetchNewRowData();
                Decimal sort = Convert.ToDecimal(ViewState["sort_no"].ToString());
                float len = float.Parse(ViewState["Length"].ToString());
                FillSaleOrderGrid(sort, len);

            }
       
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
   }
   
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void grdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                pnlSaleOrder.Visible = true;
                LinkButton lnk = (LinkButton)e.CommandSource;
                GridViewRow gvrow = (GridViewRow)lnk.Parent.Parent;
                ViewState["index"] = gvrow.RowIndex;
                Label sort_no = (Label)gvrow.FindControl("lblsort_no");
                Label Length = (Label)gvrow.FindControl("lblLength");
                Label LeftLength = (Label)gvrow.FindControl("lblLeftLength");
                Label iss_no = (Label)gvrow.FindControl("lbliss_no");
                Label Flag = (Label)gvrow.FindControl("lblFlag");
                Label split = (Label)gvrow.FindControl("lblsplit");
                Label date = (Label)gvrow.FindControl("lbldate");
                Label mc_type = (Label)gvrow.FindControl("lblmc_type");
                Label beam_no = (Label)gvrow.FindControl("lblbeam_no");
                Label type = (Label)gvrow.FindControl("lbltype");
                ViewState["sort_no"] = sort_no.Text;
                ViewState["Length"] = Length.Text;
                ViewState["LeftLength"] = LeftLength.Text;
                ViewState["iss_no"] = iss_no.Text;
                ViewState["Flag"] = Flag.Text;
                ViewState["split"] = split.Text;
                ViewState["date"] = date.Text;
                ViewState["mc_type"] = mc_type.Text;
                ViewState["beam_no"] = beam_no.Text;
                ViewState["type"] = "";
                Decimal sort = Convert.ToDecimal(sort_no.Text);
                float len = float.Parse(Length.Text);
                FillSaleOrderGrid(sort,len);

            }
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
       
    }

    protected void FillSaleOrderGrid(Decimal sort_no,float Length)
    {
        sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING_FETCH_ORDERS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SortNo", SqlDbType.Decimal).Value = sort_no;
        cmd.Parameters.Add("@Length", SqlDbType.Float).Value = Length;
        //cmd.Parameters.Add("@Year", SqlDbType.Decimal).Value = Convert.ToDecimal(ddlYear.SelectedItem.Text);
        //cmd.Parameters.Add("@Month", SqlDbType.Decimal).Value = Convert.ToDecimal(ddlMonth.SelectedItem.Value);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdSaleOrder.DataSource = ds;
        grdSaleOrder.DataBind();
    }

    protected void chbHeader_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbHeader = (CheckBox)grdSaleOrder.HeaderRow.FindControl("chbHeader");
        if (cbHeader.Checked == true)
        {
            for (int k = 0; k <= grdSaleOrder.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)grdSaleOrder.Rows[k].FindControl("chbRow");
                myCheckBox.Checked = true;
            }
        }
        else if (cbHeader.Checked == false)
        {
            for (int k = 0; k <= grdSaleOrder.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)grdSaleOrder.Rows[k].FindControl("chbRow");
                myCheckBox.Checked = false;
            }
        }
    }

    protected void grdSaleOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label order_no = (Label)e.Row.FindControl("lblOrderNo");

            string lastTwoChars = order_no.Text.Substring(order_no.Text.Length - 2);
            if (lastTwoChars == "/S")
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            for (int r = 0; r <= grdSaleOrder.Rows.Count -1; r++)
            {
                if (grdSaleOrder.Rows[r].RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (CheckBox)grdSaleOrder.Rows[r].FindControl("chbRow");
                    cb.Attributes.Add("onclick", "setRowBackColor(this,'" + grdSaleOrder.Rows[r].RowState.ToString() + "');");
                }
            }
        }
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("BeamSaleOrderMapping.aspx");
    }

    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        //GridViewExportUtil.Export("BeamList.xls", grdDetail);

        sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING_FETCH_DATA_FROM_WEAVING";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateFrom.Text);
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text);
        cmd.Parameters.Add("@Sort", SqlDbType.VarChar, 10).Value = txtSort.Text;
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Text;
        cmd.Parameters.Add("@IssueNo", SqlDbType.Char, 10).Value = txtIssueNo.Text;
        cmd.Parameters.Add("@Type", SqlDbType.Char, 1).Value = ddlType.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        CreateExcelFile(dt);
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("BeamsList.xls")));
        Response.AppendHeader("Content-Disposition", "attachment; filename=BeamsList.xls");
        Response.TransmitFile(Server.MapPath("BeamsList.xls"));
        Response.End();
        obj.ConClose();


    }

    public bool CreateExcelFile(DataTable dt)
    {
        bool bFileCreated = false;
        string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Freezed Plan</TH></TR>";
        string sTableEnd = "</TABLE></BODY></HTML>";
        string sTableData = "";
        int nRow = 0;
        int nCol;
        sTableData += "<TR>";
        for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
        {
            sTableData += "<TD><B>" + dt.Columns[nCol].ColumnName + "</B></TD>";
        }
        sTableData += "</TR>";
        for (nRow = 0; nRow <= dt.Rows.Count - 1; nRow++)
        {
            sTableData += "<TR>";
            for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
            {
                sTableData += "<TD>" + dt.Rows[nRow][nCol].ToString() + "</TD>";
            }
            sTableData += "</TR>";
        }
        string sTable = sTableStart + sTableData + sTableEnd;
        System.IO.StreamWriter oExcelWrite = null;
        string sExcelFile = Server.MapPath("BeamsList.xls");
        oExcelWrite = System.IO.File.CreateText(sExcelFile);
        oExcelWrite.WriteLine(sTable);
        oExcelWrite.Close();
        bFileCreated = true;
        return bFileCreated;

    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            grdFill();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdEdit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridView gvTemp = (GridView)sender;
        gvUniqueID = gvTemp.UniqueID;

        //Get the value        
        string ID = (gvTemp.Rows[e.RowIndex].Cells[1].Text);

        sql = "UPDATE  JCT_OPS_BEAM_SALEORDER_MAPPING SET status='D', Deleted_Dt=GETDATE(),Deleted_By=@DeletedBy  WHERE TransNo=@ID";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = ID;
        cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
        cmd.ExecuteNonQuery();
        script = "alert('Record Deleted Successfully..!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        //Reset Edit Index
        gvEditIndex = -1;


        grdFill();
    }
    protected void grdEdit_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        //Check if there is any exception while deleting
        if (e.Exception != null)
        {

            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
            e.ExceptionHandled = true;
        }
    }

    protected void grdEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdEdit.PageIndex = e.NewPageIndex;
        //grdParent.DataBind();

        grdFill();
    }

    protected void grdFill()
    {
        sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING_EDIT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtDateFrom.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtDateTo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 10).Value = txtSort.Text;
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Value;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdEdit.DataSource = ds.Tables[0];
        grdEdit.DataBind();
    }
}