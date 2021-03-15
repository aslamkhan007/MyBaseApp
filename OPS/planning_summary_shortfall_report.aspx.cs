using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_planning_summary_shortfall_report : System.Web.UI.Page
{

    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void lnkfetch_Click(object sender, EventArgs e)
    {

        string sql = "jct_ops_planning_shortfall";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
      
        cmd.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(txtreqid.Text))
        {
            cmd.Parameters.Add("@transno", SqlDbType.VarChar,20).Value = txtreqid.Text;
        }
        if (!string.IsNullOrEmpty(ddlstatus.SelectedItem.Value))
        {
            cmd.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
        }

        if (!string.IsNullOrEmpty(ddlreason.SelectedItem.Value))
        {
            cmd.Parameters.Add("@reason", SqlDbType.VarChar, 50).Value = ddlreason.SelectedItem.Value;
        }
        if (!string.IsNullOrEmpty(txtDateFrom.Text))
        {
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value =Convert.ToDateTime(txtDateFrom.Text);
        }
        if (!string.IsNullOrEmpty(txtdateto.Text))
        {
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdateto.Text);
        }
        if (!string.IsNullOrEmpty(ddlplant.SelectedItem.Text))
        {
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Text;
        }


        cmd.ExecuteNonQuery();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
   
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
}