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
    protected void Page_Load(object sender, EventArgs e)
    {

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
            sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING";
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
                    drow["iss_no"] = dr[0].ToString();
                    drow["split"] = dr[1].ToString();
                    drow["date"] = dr[2].ToString();
                    drow["sort_no"] = dr[3].ToString();
                    drow["mc_type"] = dr[4].ToString();
                    drow["beam_no"] = dr[5].ToString();
                    drow["Type"] = dr[6].ToString();
                    drow["order_no"] = dr[7].ToString();
                    drow["LeftLength"] = dr[9].ToString();
                    drow["length"] = dr[8].ToString();

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
            Decimal Length;
            Decimal BeamLength = Convert.ToDecimal(ViewState["Length"].ToString());
            for (int i = 0; i <= grdSaleOrder.Rows.Count - 1; i++)
            {
                Label orderno = (Label)grdSaleOrder.Rows[i].FindControl("lblOrderNo");
                TextBox Allocatedlength = (TextBox)grdSaleOrder.Rows[i].FindControl("txtSizingDone");
                Label Sort = (Label)grdSaleOrder.Rows[i].FindControl("lblSort");
                Length = Convert.ToDecimal(Allocatedlength.Text);
               
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
                    cmd.Parameters.Add("@split", SqlDbType.Char, 1).Value = ViewState["split"];
                    cmd.Parameters.Add("@sort_no", SqlDbType.Int).Value = ViewState["sort_no"];
                    cmd.Parameters.Add("@mc_type", SqlDbType.VarChar, 3).Value = ViewState["mc_type"];
                    cmd.Parameters.Add("@beam_no", SqlDbType.SmallInt).Value = ViewState["beam_no"];
                    cmd.Parameters.Add("@type", SqlDbType.VarChar, 1).Value = ViewState["type"];
                    cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 18).Value = orderno.Text;
                    cmd.Parameters.Add("@AllocatedLength", SqlDbType.Decimal).Value = Length;
                    cmd.Parameters.Add("@Length", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Length"].ToString());
                    cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                    cmd.ExecuteNonQuery();
                    BeamLength = BeamLength - Length;
                    
                }
             
            }
                    FillData();
                    FetchNewRowData();
                    Decimal sort = Convert.ToDecimal(ViewState["sort_no"].ToString());
                    Decimal len = Convert.ToDecimal(ViewState["Length"].ToString());
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
                                Decimal Length = Convert.ToDecimal(Allocatedlength.Text);
                                InsertRecord(orderno.Text, Length);
                                script = "alert('Record Added Successfully..!!');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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
        Label Length = (Label)grdDetail.Rows[index].FindControl("lblLeftLength");
        Label iss_no = (Label)grdDetail.Rows[index].FindControl("lbliss_no");
        Label split = (Label)grdDetail.Rows[index].FindControl("lblsplit");
        Label date = (Label)grdDetail.Rows[index].FindControl("lbldate");
        Label mc_type = (Label)grdDetail.Rows[index].FindControl("lblmc_type");
        Label beam_no = (Label)grdDetail.Rows[index].FindControl("lblbeam_no");
        Label type = (Label)grdDetail.Rows[index].FindControl("lbltype");
        ViewState["sort_no"] = sort_no.Text;
        ViewState["Length"] = Length.Text;
        ViewState["iss_no"] = iss_no.Text;
        ViewState["split"] = split.Text;
        ViewState["date"] = date.Text;
        ViewState["mc_type"] = mc_type.Text;
        ViewState["beam_no"] = beam_no.Text;
        ViewState["type"] = type.Text;
    }

    protected void InsertRecord(String OrderNo,Decimal AllocatedLength)
    {
        try
        {
            Decimal BeamLength = Convert.ToDecimal(ViewState["Length"].ToString());
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
                cmd.Parameters.Add("@split", SqlDbType.Char, 1).Value = ViewState["split"];
                cmd.Parameters.Add("@sort_no", SqlDbType.Int).Value =ViewState["sort_no"];
                cmd.Parameters.Add("@mc_type", SqlDbType.VarChar, 3).Value = ViewState["mc_type"];
                cmd.Parameters.Add("@beam_no", SqlDbType.SmallInt).Value = ViewState["beam_no"];
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 1).Value = ViewState["type"];
                cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 18).Value = OrderNo;
                cmd.Parameters.Add("@AllocatedLength", SqlDbType.Decimal).Value = AllocatedLength;
                cmd.Parameters.Add("@Length", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["Length"].ToString());
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value =Session["EmpCode"];
                cmd.ExecuteNonQuery();

            
                FillData();
                FetchNewRowData();
                Decimal sort = Convert.ToDecimal(ViewState["sort_no"].ToString());
                Decimal len = Convert.ToDecimal(ViewState["Length"].ToString());
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
                Label Length = (Label)gvrow.FindControl("lblLeftLength");
                Label iss_no = (Label)gvrow.FindControl("lbliss_no");
                Label split = (Label)gvrow.FindControl("lblsplit");
                Label date = (Label)gvrow.FindControl("lbldate");
                Label mc_type = (Label)gvrow.FindControl("lblmc_type");
                Label beam_no = (Label)gvrow.FindControl("lblbeam_no");
                Label type = (Label)gvrow.FindControl("lbltype");
                ViewState["sort_no"] = sort_no.Text;
                ViewState["Length"] = Length.Text;
                ViewState["iss_no"] = iss_no.Text;
                ViewState["split"] = split.Text;
                ViewState["date"] = date.Text;
                ViewState["mc_type"] = mc_type.Text;
                ViewState["beam_no"] = beam_no.Text;
                ViewState["type"] = type.Text;
                Decimal sort = Convert.ToDecimal(sort_no.Text);
                Decimal len = Convert.ToDecimal(Length.Text);
                FillSaleOrderGrid(sort,len);

            }
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
       
    }

    protected void FillSaleOrderGrid(Decimal sort_no,Decimal Length)
    {
        sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING_FETCH_ORDERS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SortNo", SqlDbType.Decimal).Value = sort_no;
        cmd.Parameters.Add("@Length", SqlDbType.Decimal).Value = Length;
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
}