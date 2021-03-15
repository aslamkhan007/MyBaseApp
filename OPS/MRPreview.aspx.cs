using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_MRPreview : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        grdMaterialRequest.DataSource = null;
        grdMaterialRequest.DataBind();

        grdHistory.DataSource = null;
        grdHistory.DataBind();

        grdFoldingObservation.DataSource = null;
        grdFoldingObservation.DataBind();

        grdPPCandLogAuth.DataSource = null;
        grdPPCandLogAuth.DataBind();

        sql = "JCT_OPS_MR_Preview_Report";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = txtID.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdMaterialRequest.DataSource = ds;
        grdMaterialRequest.DataBind();

    }
    protected void grdMaterialRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            grdMaterialRequest.DataKeyNames.Equals("RequestID");
            String SanctionID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RequestID"));


            GridView GridViewNested_MultipleID = (GridView)e.Row.FindControl("nestedGridView_MultipleID");
            GridViewNested_MultipleID.DataKeyNames.Equals("ID");
            sql = "SELECT COUNT(*) AS count FROM dbo.jct_ops_material_request WHERE RequestID='" + SanctionID + "'";
            Int16 i = Convert.ToInt16(obj1.FetchValue(sql).ToString());

            if (i >= 1)
            {


                sql = " SELECT invoice_no AS Invoice,item_no AS Sort,customer AS Customer,b.empname AS SalesPerson,invoice_qty AS InvoiceQty,ret_qty AS ReturnQty,reason AS Reason,isnull(salePrice,0) SalePrice,isnull(ValueInvolved,0) ValueInvolved FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person = REPLACE(b.empcode, '-', '')   WHERE RequestID='" + SanctionID + "' ";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridViewNested_MultipleID.DataSource = ds.Tables[0];
                GridViewNested_MultipleID.DataBind();
            }
            else
            {
                GridViewNested_MultipleID.DataSource = null;
                GridViewNested_MultipleID.DataBind();
            }


        }
    }

    protected void grdMaterialRequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt = new DataTable();
        sql = "SELECT a.USERLEVEL, Upper(b.empname) as AuthorizedBy,Case when STATUS is null Then 'Authorized' Else 'Cancelled' End As Status,CONVERT(VARCHAR,AUTH_DATETIME,103) AS [Authorized Date],Remarks FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN dbo.JCT_EmpMast_Base b ON a.EMPCODE=b.empcode WHERE ID='" + grdMaterialRequest.SelectedValue.ToString() + "' and Auth_DateTime is not null order by UserLevel Asc ";
        obj1.FillGrid(sql, ref grdHistory);
        grdHistory.Visible = true;


        sql = "JCT_OPS_MR_PPC_Status_Report";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 20).Value = grdMaterialRequest.SelectedValue.ToString();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            grdPPCandLogAuth.DataSource = ds;
            grdPPCandLogAuth.DataBind();
            int columncount = grdPPCandLogAuth.Rows[0].Cells.Count;
            grdPPCandLogAuth.Rows[0].Cells.Clear();
            grdPPCandLogAuth.Rows[0].Cells.Add(new TableCell());
            grdPPCandLogAuth.Rows[0].Cells[0].ColumnSpan = columncount;
            grdPPCandLogAuth.Rows[0].Cells[0].Text = "No Records Found";
        }
        else
        {
            grdPPCandLogAuth.DataSource = ds;
            grdPPCandLogAuth.DataBind();
            grdPPCandLogAuth.Visible = true;
        }

        sql = "Jct_Ops_Mr_Folding_Observation_Report";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 20).Value = grdMaterialRequest.SelectedValue.ToString();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            grdFoldingObservation.DataSource = ds;
            grdFoldingObservation.DataBind();
            int columncount = grdFoldingObservation.Rows[0].Cells.Count;
            grdFoldingObservation.Rows[0].Cells.Clear();
            grdFoldingObservation.Rows[0].Cells.Add(new TableCell());
            grdFoldingObservation.Rows[0].Cells[0].ColumnSpan = columncount;
            grdFoldingObservation.Rows[0].Cells[0].Text = "No Records Found";
        }
        else
        {
            grdFoldingObservation.DataSource = ds;
            grdFoldingObservation.DataBind();
            grdFoldingObservation.Visible = true;
        }
        sql = "JCT_OPS_MR_SaleOrder";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 20).Value = grdMaterialRequest.SelectedValue.ToString();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            grdOrderDetail.DataSource = ds;
            grdOrderDetail.DataBind();
            int columncount = grdOrderDetail.Rows[0].Cells.Count;
            grdOrderDetail.Rows[0].Cells.Clear();
            grdOrderDetail.Rows[0].Cells.Add(new TableCell());
            grdOrderDetail.Rows[0].Cells[0].ColumnSpan = columncount;
            grdOrderDetail.Rows[0].Cells[0].Text = "No Records Found";
        }
        else
        {
            grdOrderDetail.DataSource = ds;
            grdOrderDetail.DataBind();
            grdOrderDetail.Visible = true;
        }
    }
    protected void lnkPreview_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/MRPreviewPrintReport.aspx?ID="+txtID.Text);
    }
}