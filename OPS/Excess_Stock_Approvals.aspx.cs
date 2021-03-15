using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_Excess_Stock_Approvals : System.Web.UI.Page
{
    string query;
    Functions objFun = new Functions();
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;

    GridViewExportUtil export = new GridViewExportUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            query = "Select '' AS empcode,'' AS empname union  SELECT empcode,empname FROM dbo.JCT_EmpMast_Base WHERE empcode IN ('u-04002','s-13741','r-01111') ORDER BY empname";
            objFun.FillList(ddlAuthBy,query);

        }
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_SANCTION_REPORT_Excess_Stock_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtDateFrom.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtDateTo.Text;
        cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = txtSanctionID.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlStatus.SelectedItem.Value;
        cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = 1041;
        cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 10).Value = txtRequestBy.Text;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdMaster.DataSource = ds;
        grdMaster.DataBind();
    }
    protected void lnkSummary_Click(object sender, EventArgs e)
    {

    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {

    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {

    }
    protected void txtRequestBy_TextChanged(object sender, EventArgs e)
    {

    }
    protected void grdMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
              String  SanctionID = grdMaster.SelectedRow.Cells[5].Text;
              sql = "Jct_Ops_ODS_Transfer_Sell_Items_Fetch_Report '" + SanctionID + "','','','','N','Y'";
         //objFun.FillGrid(sql, grdRequestDetail);

         objFun.FillGrid(sql,ref grdRequestDetail);

         sql = "Jct_Ops_ODS_Transfer_Sell_Items_Fetch_Report '" + SanctionID + "','','','','Y',''";
            SqlDataAdapter da ;
            da =new SqlDataAdapter(sql, obj.Connection());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DtlListSummary.DataSource = ds;
            DtlListSummary.DataBind();
         sql="jctgen..Jct_Ops_Excess_Stock_Head_To_Head_Comparision '" + SanctionID + "'";
         objFun.FillGrid(sql, ref grdComparision);
        

        //sql = "Jct_Ops_Pending_Authorization_Fetch_Detail";// '" + grdMaster.SelectedRow.Cells[4].Text + "','" + ddlArea.SelectedItem.Value + "'";
        //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@ID", SqlDbType.VarChar, 10).Value = SanctionID;
        //cmd.Parameters.Add("@Areacode", SqlDbType.VarChar, 10).Value = ddlArea.SelectedItem.Value;
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //grdChild.DataSource = ds;
        //grdChild.DataBind();
    }
    protected void grdMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            grdMaster.DataKeyNames.Equals("SanctionID");
            String SanctionID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionID"));

            GridView GridViewNested = (GridView)e.Row.FindControl("nestedGridView");
            GridViewNested.DataKeyNames.Equals("Description");
            sql = "Select Description from Jct_Ops_SanctionNote_HDR_test where sanctionNoteID='" + SanctionID + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridViewNested.DataSource = ds.Tables[0];
            GridViewNested.DataBind();


        }
    }
  
    
  
}