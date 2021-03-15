using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_ShortfallStatus : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    GridViewExportUtil ex = new GridViewExportUtil();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {


     //String   script = "alert('Data under updation');";
     //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //sql = "JCT_OPS_SHORTFALL_REPORT1";
        //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 20).Value = txtdatefrom.Text;
        //cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 20).Value = txtdateto.Text;
        //cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
        //cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
        //cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        //cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Text;
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //grdShortfall.DataSource = ds.Tables[0];
        //grdShortfall.DataBind();
        if (chbAll.Checked == false)
        {

            //JCT_OPS_SHORTFALL_NOT_COMPLETED_createdby_jatin 
            //sql = "JCT_OPS_SHORTFALL_cancelled_shweta";
            sql = "JCT_OPS_SHORTFALL_NOT_COMPLETED";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdShortfall.DataSource = ds.Tables[0];
            grdShortfall.DataBind();
        }
        else
        {
            sql = "JCT_OPS_SHORTFALL_COMPLETED";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdShortfall.DataSource = ds.Tables[0];
            grdShortfall.DataBind();
        }

    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (chbAll.Checked == false)
        {
            //JCT_OPS_SHORTFALL_NOT_COMPLETED_createdby_jatin 
            //sql = "JCT_OPS_SHORTFALL_cancelled_shweta";
            sql = "JCT_OPS_SHORTFALL_NOT_COMPLETED";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];

        }
        else
        {
           
            sql = "JCT_OPS_SHORTFALL_COMPLETED";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];

        }



        string attachment = "attachment; filename=Authorized_Shortfall_Requests.xls";
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
    protected void chbAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chbAll.Checked == true)
        {
            //sql = "JCT_OPS_SHORTFALL_REPORT";
            //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 20).Value = txtdatefrom.Text;
            //cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 20).Value = txtdateto.Text;
            //cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            //cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            //cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            //cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Text;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //grdShortfall.DataSource = ds.Tables[0];
            //grdShortfall.DataBind();

            sql = "JCT_OPS_SHORTFALL_COMPLETED";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdShortfall.DataSource = ds.Tables[0];
            grdShortfall.DataBind();
        }
        else
        {
            //JCT_OPS_SHORTFALL_NOT_COMPLETED_createdby_jatin 
            //sql = "JCT_OPS_SHORTFALL_cancelled_shweta";
            sql = "JCT_OPS_SHORTFALL_NOT_COMPLETED";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdShortfall.DataSource = ds.Tables[0];
            grdShortfall.DataBind();
            //sql = "JCT_OPS_SHORTFALL_REPORT1";
            //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 20).Value = txtdatefrom.Text;
            //cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 20).Value = txtdateto.Text;
            //cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            //cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            //cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            //cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = ddlStatus.SelectedItem.Text;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //grdShortfall.DataSource = ds.Tables[0];
            //grdShortfall.DataBind();
        }
      
    }
}