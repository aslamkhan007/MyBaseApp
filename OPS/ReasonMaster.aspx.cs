using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_ReasonMaster : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    String script;
  //public   OPS_ReasonMaster()
  //  {
  //      obj = new Connection();
  //      obj1 = new Functions();
  //  }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdReason.DataSourceID = "SqlDataSource3";
            grdReason.DataBind();
        }
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (lnkSave.Text == "Save")
            {
                sql = "JCT_OPS_REASON_MASTER_INSERT";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@ReasonShortDesc", SqlDbType.VarChar, 100).Value = txtReasonShortDesc.Text;
                cmd.Parameters.Add("@ReasonLongDesc", SqlDbType.VarChar, 500).Value = txtReasonLongDesc.Text;
                cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = ddlArea.SelectedItem.Value;
                cmd.Parameters.Add("@SubArea", SqlDbType.VarChar, 10).Value = ddlSubArea.SelectedItem.Value;
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 10).Value = lnkSave.Text;
                cmd.ExecuteNonQuery();
                grdReason.DataSourceID = "SqlDataSource3";
                grdReason.DataBind();
                script = "alert('Record Added Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else if (lnkSave.Text == "Update")
            {
                sql = "JCT_OPS_REASON_MASTER_INSERT";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@ReasonCode", SqlDbType.Int).Value =Convert.ToInt16(lblReasonCode.Text);
                cmd.Parameters.Add("@ReasonShortDesc", SqlDbType.VarChar, 100).Value = txtReasonShortDesc.Text;
                cmd.Parameters.Add("@ReasonLongDesc", SqlDbType.VarChar, 500).Value = txtReasonLongDesc.Text;
                cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = ddlArea.SelectedItem.Value;
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 10).Value = lnkSave.Text;
                cmd.ExecuteNonQuery();
                grdReason.DataSourceID = "SqlDataSource3";
                grdReason.DataBind();
                script = "alert('Record Updated Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

           
        }

        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
     
    }
    protected void grdReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkSave.Text = "Update";
        lblReasonCode.Text = grdReason.SelectedRow.Cells[1].Text;
        txtReasonShortDesc.Text = grdReason.SelectedRow.Cells[2].Text;
        txtReasonLongDesc.Text = grdReason.SelectedRow.Cells[3].Text;
        ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByValue(grdReason.SelectedRow.Cells[4].Text));
        
    }
    protected void grdReason_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdReason.SelectedIndex = e.NewPageIndex;
        grdReason.DataSourceID = "SqlDataSource3";
        grdReason.DataBind();
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReasonMaster.aspx");
    }
}