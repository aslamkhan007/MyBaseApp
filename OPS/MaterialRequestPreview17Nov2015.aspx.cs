using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_MaterialRequestPreview : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_MATERIAL_RETURN_Report";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = txtID.Text;
        //cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtRequestFrom.Text;
        //cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtRequestTo.Text;
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

            if (i > 1)
            {
                Label lbl = (Label)e.Row.FindControl("lbl");
                lbl.Visible = true;
                lbl.ToolTip = "More than one invoices are in this request number. Expand to view Details..!!";
                sql = " SELECT invoice_no AS Invoice,item_no AS Sort,customer AS Customer,b.empname AS SalesPerson,invoice_qty AS InvoiceQty,ret_qty AS ReturnQty,reason AS Reason FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person = REPLACE(b.empcode, '-', '')   WHERE RequestID='" + SanctionID + "' ";
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
}