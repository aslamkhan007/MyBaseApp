using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_BeamRewinding : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    string script;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkFetch_Click1(object sender, EventArgs e)
    {
        sql = "JCT_OPS_WEAVING_BEAM_SALEORDER_MAPPING_FETCH_DATA_FROM_WEAVING_REWINDING";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDate.Text);
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDate.Text);
        cmd.Parameters.Add("@Sort", SqlDbType.VarChar, 10).Value = txtSortNo.Text;
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@IssueNo", SqlDbType.Char, 10).Value = txtIssueNo.Text;
        cmd.Parameters.Add("@Type", SqlDbType.Char, 1).Value = "";//ddlType.SelectedItem.Value;
        cmd.Parameters.Add("@BeamNo", SqlDbType.VarChar, 10).Value = txtBeamNo.Text;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
       
        grdBeam.DataSource = ds.Tables[0];
        grdBeam.DataBind();

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            { 
                ViewState["IssueNo"]= dr["iss_no"];
                ViewState["BeamNo"] = dr["beam_no"];
                ViewState["SortNo"] = dr["sort_no"];
            }
        }
        dr.Close();
    }
    protected void grdBeam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        if (row.DataItem == null)
        {
            return;
        }

        Label BeamLength = null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            BeamLength = (Label)e.Row.FindControl("lblLength");
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("IssueNo", typeof(string)));
            dt.Columns.Add(new DataColumn("BeamNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Length", typeof(string)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));

            dr = dt.NewRow();
            dr["IssueNo"] = string.Empty;
            dr["BeamNo"] = string.Empty;
            dr["Length"] = string.Empty;
            dr["Remarks"] = string.Empty;

            dt.Rows.Add(dr);
            ViewState["BeamLength"] = BeamLength.Text;
            ViewState["CurrentTable"] = dt;

            grdRewindBeam.DataSource = ViewState["CurrentTable"];
            grdRewindBeam.DataBind();       
        }

     

        
    }
 
    protected void grdRewindBeam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox BeamLength = (TextBox) e.Row.FindControl("txtLength");

                BeamLength.Text = ViewState["BeamLength"].ToString();
            }
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void grdRewindBeam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Save")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                TextBox IssueNo = (TextBox)row.FindControl("txtIssueNo");
                TextBox BeamNo = (TextBox)row.FindControl("txtBeamNo");
                TextBox BeamLength = (TextBox)row.FindControl("txtLength");
                TextBox Remarks = (TextBox)row.FindControl("txtRemarks");

                if (!string.IsNullOrEmpty(Remarks.Text))
                {
                    sql = "JCT_OPS_BEAM_REWINDING_INSERT";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OLD_ISSUENO", SqlDbType.VarChar, 20).Value = ViewState["IssueNo"];
                    cmd.Parameters.Add("@OLD_BEAMNO", SqlDbType.VarChar, 20).Value = ViewState["BeamNo"];
                    cmd.Parameters.Add("@OLD_SORTNO", SqlDbType.VarChar, 20).Value = ViewState["SortNo"];
                    cmd.Parameters.Add("@NEW_ISSUENO", SqlDbType.VarChar, 20).Value = IssueNo.Text;
                    cmd.Parameters.Add("@NEW_BEAMNO", SqlDbType.VarChar, 20).Value = BeamNo.Text;
                    cmd.Parameters.Add("@ENTRYBY", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                    cmd.Parameters.Add("@NEW_BEAMLENGTH", SqlDbType.Decimal).Value = Convert.ToDecimal(BeamLength.Text);
                    cmd.Parameters.Add("@REMARKS", SqlDbType.VarChar, 500).Value = Remarks.Text;
                    cmd.ExecuteNonQuery();
                    grdBeam.Visible = false;
                    grdRewindBeam.Visible = false;

                    script = "alert('Beam Rewinded Successfully..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    script = "alert('Please enter remarks ..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                
            }
        }
        catch(Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/BeamRewinding.aspx");
    }
}