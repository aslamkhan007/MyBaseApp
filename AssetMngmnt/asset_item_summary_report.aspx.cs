using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_item_summary_report : System.Web.UI.Page
{
   Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
      string   sql = "jct_asset_type_summary_report";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        sql = "jct_asset_type_summary_report_desktop_server ";
         cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
         da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        grdDetail2.DataSource = ds.Tables[0];
        grdDetail2.DataBind();

    }
}