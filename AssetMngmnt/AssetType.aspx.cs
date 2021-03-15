using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_AssetType : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string dept = string.Empty;
    string empcode= string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == string.Empty)
        {
            Response.Redirect("~/login.aspx");
        }

        if(!IsPostBack)
        {

            sql = "SELECT DISTINCT  empcode,b.deptcode FROM jct_empmast_base  a JOIN dbo.DEPTMAST  b ON a.deptcode=b.DEPTCODE WHERE  a.empcode= '" + Session["EmpCode"] + "'";
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
                        lblMoveable.Visible = true;
                        ddlMoveable.Visible = true;
                    }
                    else
                    {
                        dept = Dr[1].ToString();
                        if (dept != "MIS")
                        {
                            dept = "GEN";
                            ViewState["dept"] = dept;
                            lblMoveable.Visible = true;
                            ddlMoveable.Visible = true;
                        }
// modified by aslam
                        else
                        {
                            ViewState["dept"] = dept;
                            lblMoveable.Visible = false;
                            ddlMoveable.Visible = false;
                        }
// modified by aslam
                                                
                    }

                }

            }
            Dr.Close();

            Dr.Close();
            cmd = new SqlCommand("SELECT  item_name,asset_id FROM dbo.jct_asset_master where status='A' and module_usedby ='" + dept + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ddlassettype.DataSource = ds;
            ddlassettype.DataTextField = "item_name";
            ddlassettype.DataValueField = "asset_id";
            ddlassettype.DataBind();

          }
        bindgrid();                    
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
        sql = "jct_asset_type_insert";
        SqlCommand cmd = new SqlCommand(sql,con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlassettype.SelectedValue;


        if (ddlMoveable.SelectedItem.Text=="Y")
        {
            cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 500).Value = "Moveable" + " " + txtasset.Text ;                        
        }
        else
        {
            cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 500).Value = txtasset.Text;
        }


        if (ddlMoveable.SelectedItem.Text == "Y")
        {
            cmd.Parameters.Add("@asset_type_desc", SqlDbType.VarChar, 500).Value = "Moveable" + " " + txtdesc.Text;            
        }
        else
        {
            cmd.Parameters.Add("@asset_type_desc", SqlDbType.VarChar, 500).Value = txtdesc.Text;
        }

        //cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 500).Value =txtasset.Text;
        //cmd.Parameters.Add("@asset_type_desc", SqlDbType.VarChar, 500).Value = txtdesc.Text;
        cmd.Parameters.Add("@creted_by", SqlDbType.VarChar, 500).Value = Session["EmpCode"];
        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Record saved!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        bindgrid();

                }
        catch (Exception ex)
        {
             string  script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetType.aspx");
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_type_delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 500).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string script = "alert('Record Deleted!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            bindgrid();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    private void bindgrid()
    {

        //sql = "SELECT  a.asset_type_id as [Asset type id],a.asset_type_name as [Asset type name],a.asset_type_desc as [Asset type desc]from jct_asset_type_master a inner join jct_asset_master b on a.asset_id=b.asset_id where a.STATUS=b.status and   a.asset_id='" + ddlassettype.SelectedItem.Value + "'  ";
        sql = "SELECT  a.asset_type_id as [Asset type id],a.asset_type_name as [Asset type name],a.asset_type_desc as [Asset type desc]from jct_asset_type_master a inner join jct_asset_master b on a.asset_id=b.asset_id where a.STATUS=b.status and   a.asset_id='" + ddlassettype.SelectedItem.Value + "' and a.status = 'A' and b.status = 'A'  ";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtasset.Text = grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
        txtdesc.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_type_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlassettype.SelectedValue;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.VarChar, 50).Value = grdDetail.SelectedRow.Cells[1].Text;
            //cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 50).Value = txtasset.Text;
            //cmd.Parameters.Add("@asset_type_desc", SqlDbType.VarChar, 50).Value = txtdesc.Text;

            if (ddlMoveable.SelectedItem.Text == "Y")
            {
                cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 50).Value = "Moveable" + " " + txtasset.Text;
            }
            else
            {
                cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 50).Value = txtasset.Text;
            }


            if (ddlMoveable.SelectedItem.Text == "Y")
            {
                cmd.Parameters.Add("@asset_type_desc", SqlDbType.VarChar, 50).Value = "Moveable" + " " + txtdesc.Text;
            }
            else
            {
                cmd.Parameters.Add("@asset_type_desc", SqlDbType.VarChar, 50).Value = txtdesc.Text;
            }


            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string script = "alert('Record updtae!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            bindgrid();
        }
        catch (Exception ex)
        {
            string script = "alert('Please select a record!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetType.aspx");
    }
    protected void ddlassettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    
    }

   
}