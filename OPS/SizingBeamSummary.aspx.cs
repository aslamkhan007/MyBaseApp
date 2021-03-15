using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;

public partial class OPS_SizingBeamSummary : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void radFetch_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        sql = "jct_ops_szg_beam_summary";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@month", SqlDbType.Int).Value = Convert.ToInt16(radDDLMonth.SelectedItem.Value);
        cmd.Parameters.Add("@year", SqlDbType.Int).Value = Convert.ToInt16(radDDLYear.SelectedItem.Text);
        cmd.Parameters.Add("@section", SqlDbType.VarChar, 10).Value = radDDLSection.SelectedItem.Text;
        cmd.Parameters.Add("@stock", SqlDbType.VarChar, 10).Value = radDDLStock.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        RadGrid1.DataSource = ds.Tables[0];
        RadGrid1.DataBind();
    }
    protected void radExcel_Click(object sender, EventArgs e)
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;
        RadGrid1.MasterTableView.ExportToExcel();
    }
    protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        RadGrid1.CurrentPageIndex = e.NewPageIndex;
        sql = "jct_ops_szg_beam_summary";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@month", SqlDbType.Int).Value = Convert.ToInt16(radDDLMonth.SelectedItem.Value);
        cmd.Parameters.Add("@year", SqlDbType.Int).Value = Convert.ToInt16(radDDLYear.SelectedItem.Text);
        cmd.Parameters.Add("@section", SqlDbType.VarChar, 10).Value = radDDLSection.SelectedItem.Value;
        cmd.Parameters.Add("@stock", SqlDbType.VarChar, 10).Value = radDDLStock.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        RadGrid1.DataSource = ds.Tables[0];
        RadGrid1.DataBind();
    }
    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{

        //    RadGrid1.MasterTableView.FilterExpression = "([BOOLEAN] = \'0\') ";
        //    GridColumn column = RadGrid1.MasterTableView.GetColumnSafe("BOOLEAN");
        //    column.CurrentFilterFunction = GridKnownFunction.EqualTo;
        //    column.CurrentFilterValue = "0";

        //    sql = "jct_ops_szg_beam_summary";
        //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@month", SqlDbType.Int).Value = Convert.ToInt16(radDDLMonth.SelectedItem.Value);
        //    cmd.Parameters.Add("@year", SqlDbType.Int).Value = Convert.ToInt16(radDDLYear.SelectedItem.Text);
        //    cmd.Parameters.Add("@section", SqlDbType.VarChar, 10).Value = radDDLSection.SelectedItem.Value;
        //    cmd.Parameters.Add("@stock", SqlDbType.VarChar, 10).Value = radDDLStock.SelectedItem.Value;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    RadGrid1.DataSource = ds.Tables[0];
        //    RadGrid1.DataBind();
        //}
    }
    protected void RadGrid1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
    {
        try
        {

            RadGrid1.PageSizeChanged -= new GridPageSizeChangedEventHandler(RadGrid1_PageSizeChanged);
            RadGrid1.PageSize = e.NewPageSize;

            RadGrid1.PageSizeChanged += new GridPageSizeChangedEventHandler(RadGrid1_PageSizeChanged);

            sql = "jct_ops_szg_beam_summary";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@month", SqlDbType.Int).Value = Convert.ToInt16(radDDLMonth.SelectedItem.Value);
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = Convert.ToInt16(radDDLYear.SelectedItem.Text);
            cmd.Parameters.Add("@section", SqlDbType.VarChar, 10).Value = radDDLSection.SelectedItem.Value;
            cmd.Parameters.Add("@stock", SqlDbType.VarChar, 10).Value = radDDLStock.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            RadGrid1.DataSource = ds.Tables[0];
            RadGrid1.DataBind();
        }
        catch (Exception ex)
        {
            string  script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

       
    }

    protected void radReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SizingBeamSummary.aspx");
    }

protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
       sql = "jct_ops_szg_beam_summary";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@month", SqlDbType.Int).Value = Convert.ToInt16(radDDLMonth.SelectedItem.Value);
        cmd.Parameters.Add("@year", SqlDbType.Int).Value = Convert.ToInt16(radDDLYear.SelectedItem.Text);
        cmd.Parameters.Add("@section", SqlDbType.VarChar, 10).Value = radDDLSection.SelectedItem.Text;
        cmd.Parameters.Add("@stock", SqlDbType.VarChar, 10).Value = radDDLStock.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        RadGrid1.DataSource = ds.Tables[0];
       
    }
}