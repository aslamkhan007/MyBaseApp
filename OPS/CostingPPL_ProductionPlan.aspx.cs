using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

public partial class OPS_CostingPPL_ProductionPlan : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    string script;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            script = "alert('You have not selected Plan or missing some parameter. Please check or consult IT..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void BindData()
    {
        
        //sql = "JCT_OPS_PLANNING_COSTINGPPL_REPORT_FETCH";
        sql = "JCT_OPS_PLANNING_COSTING_PPL_REPORT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = chbPlan.SelectedItem.Value;
        //cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, 100).Value = txtCustomer.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar,20).Value = txtWeavingSort.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdPPL.DataSource = ds.Tables[0];
        grdPPL.DataBind();
    }

    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        try
        {
            //grdPPL.ExportSettings.ExportOnlyData = true;
            //grdPPL.ExportSettings.IgnorePaging = true;
            //grdPPL.ExportSettings.OpenInNewWindow = true;
            //grdPPL.ExportSettings.UseItemStyles = true;
            //grdPPL.MasterTableView.ExportToExcel();

            //sql = "JCT_OPS_PLANNING_COSTINGPPL_REPORT_FETCH";
            sql = "JCT_OPS_PLANNING_COSTING_PPL_REPORT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = chbPlan.SelectedItem.Value;
            //cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, 100).Value = txtCustomer.Text;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = txtWeavingSort.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];


            string attachment = "attachment; filename=ProductionPlanPPL.xls";
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

           
        }
        catch (Exception ex)
        {
            script = "alert('You have not selected Plan or missing some parameter. Please check or consult IT..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        obj.ConClose();
        
    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtCustomer.Text = txtCustomer.Text.Split('~')[1].ToString();
        }
        catch
        { 
        
        }
    }
    
    protected void grdPPL_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        // Added when Excel button was added inside RadGrid in MasterTableView Section.
        //if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
        //{
        //    grdPPL.ExportSettings.ExportOnlyData = true;
        //    grdPPL.ExportSettings.IgnorePaging = true;
        //    grdPPL.ExportSettings.OpenInNewWindow = true;
        //    grdPPL.ExportSettings.UseItemStyles = true;
        //    grdPPL.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
        //    grdPPL.MasterTableView.ExportToExcel();
        //}
    }
}