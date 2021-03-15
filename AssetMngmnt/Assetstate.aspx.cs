using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_Assetstate : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
    string dept = string.Empty;
    string empcode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == string.Empty)
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            sql = "SELECT distinct  empcode,b.deptcode FROM jct_empmast_base  a JOIN dbo.DEPTMAST  b ON a.deptcode=b.DEPTCODE WHERE  a.empcode= '" + Session["EmpCode"] + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    empcode = Dr[0].ToString();
                    if (empcode.ToString() == "M-02467" || empcode.ToString() == "m-02467" || empcode.ToString() == "a-00098" || empcode.ToString() == "A-00098")
                    {
                        dept = "GEN";
                        ViewState["dept"] = dept;
                    }
                    else
                   
                    dept = Dr[1].ToString();
                    if (dept != "MIS")
                    {
                        dept = "GEN";
                        ViewState["dept"] = dept;

                    }
                    else
                    {
                        ViewState["dept"] = dept;
                    }
                }

            }
            Dr.Close();            
        }
        Bindgrid();
    }

    protected void Bindgrid()
    {
        sql = "jct_asset_state_master_select";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdStateDetail.DataSource = ds.Tables[0];
        grdStateDetail.DataBind();
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_state_master_insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@state_name", SqlDbType.VarChar, 100).Value = txtstate.Text;
            cmd.Parameters.Add("@state_desc", SqlDbType.VarChar, 500).Value = txtassetdesc.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@Created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
              

            cmd.ExecuteNonQuery();

            Bindgrid();

            script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetState.aspx");
    }

    protected void grdStateDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtstate.Text = grdStateDetail.SelectedRow.Cells[1].Text;
        txtassetdesc.Text = grdStateDetail.SelectedRow.Cells[2].Text;
        //lblassetstateid.Text = grdStateDetail.SelectedRow.Cells[3].Text;
        ViewState["state_id"] = grdStateDetail.SelectedRow.Cells[3].Text;
    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_state_master_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@state_name", SqlDbType.VarChar, 100).Value = txtstate.Text;
            cmd.Parameters.Add("@state_desc", SqlDbType.VarChar, 500).Value = txtassetdesc.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            //cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = lblassetstateid.Text;
            cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ViewState["state_id"];
            cmd.Parameters.Add("@Created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            Bindgrid();

            script = "alert('Record updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_state_master_delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ViewState["state_id"];
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.ExecuteNonQuery();
            Bindgrid();

            script = "alert('Record Deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
}