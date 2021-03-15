using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class OPS_BeamRewindingReport : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_BEAM_REWINDING_REPORT_FETCH";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 20).Value = txtEntryDateFrom.Text;
        cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 20).Value = txtEntryDateTo.Text;
        cmd.Parameters.Add("@ISSUENO", SqlDbType.VarChar, 20).Value = txtIssueNo.Text;
        cmd.Parameters.Add("@BEAMNO", SqlDbType.Int).Value = (txtBeamNo.Text=="" ? 0 : Convert.ToInt16(txtBeamNo.Text));
        cmd.Parameters.Add("@SORTNO", SqlDbType.Int).Value = (txtSortNo.Text == "" ? 0 : Convert.ToInt16(txtSortNo.Text));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdBeamRewinding.DataSource = ds.Tables[0];
        grdBeamRewinding.DataBind();
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_BEAM_REWINDING_REPORT_FETCH";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 20).Value = txtEntryDateFrom.Text;
        cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 20).Value = txtEntryDateTo.Text;
        cmd.Parameters.Add("@ISSUENO", SqlDbType.VarChar, 20).Value = txtIssueNo.Text;
        cmd.Parameters.Add("@BEAMNO", SqlDbType.Int).Value = (txtBeamNo.Text == "" ? 0 : Convert.ToInt16(txtBeamNo.Text));
        cmd.Parameters.Add("@SORTNO", SqlDbType.Int).Value = (txtSortNo.Text == "" ? 0 : Convert.ToInt16(txtSortNo.Text));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable dt = ds.Tables[0];


        string attachment = "attachment; filename=RewindedBeamsList.xls";
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
}