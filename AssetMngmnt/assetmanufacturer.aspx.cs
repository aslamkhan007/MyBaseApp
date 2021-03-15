using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AssetMngmnt_assetmanufacturer : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
    string dept = string.Empty;
    string empcode = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == string.Empty)
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
       {
            sql = "SELECT  empcode,b.deptcode FROM jct_empmast_base  a JOIN dbo.DEPTMAST  b ON a.deptcode=b.DEPTCODE WHERE  a.empcode= '" + Session["EmpCode"] + "'";
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
                    {
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

            }


        

            Dr.Close();
            bindgrid();

        }
    }

    private void bindgrid()
    {
        con.Open();
        sql = " SELECT [ID],name,description,CONVERT(VARCHAR(10),effective_from,101) AS EffectiveFrom,CONVERT(VARCHAR(10),effective_to,101) AS EffectiveTo,e_mail,ADDRESS,contact_num FROM jct_asset_manufacturer_master WHERE type ='" + ddltype.SelectedItem.Text + "' and module_usedby='" + ViewState["dept"] + "' and   status='A'";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        con.Close();
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
        sql = "jct_asset_manufacturer_master_insert";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@type", SqlDbType.VarChar, 100).Value = ddltype.SelectedItem.Text;
        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = txtmanfactname.Text;
        cmd.Parameters.Add("@manufacturer_desc", SqlDbType.VarChar, 100).Value = txtmanufactdesc.Text;
        cmd.Parameters.Add("@contact", SqlDbType.VarChar, 15).Value = txtcontactnum.Text;
        cmd.Parameters.Add("@address", SqlDbType.VarChar, 1000).Value = txtaddress.Text;
        cmd.Parameters.Add("@email ", SqlDbType.VarChar, 100).Value = txtemail.Text;
        if (txtefffrm.Text != string.Empty)
        {
            cmd.Parameters.Add("@eff_frm", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
        }

        if (txteffto.Text != string.Empty)

        {
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
        }
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 120).Value = Session["EmpCode"];
        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
        cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
        
        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

        //cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 200).Value = txtvendor.Text;
        //cmd.Parameters.Add("@vendoraddress", SqlDbType.VarChar, 200).Value = txtvendoraddres.Text;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        bindgrid();

        string script = "alert('Record saved.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
            
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        try
        {
        sql = "jct_asset_manufacturer_master_delete";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = txtmanfactname.Text;
        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = lblmanufactureid.Text;
        cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        bindgrid();

        string script = "alert('Record deleted.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
        sql = "jct_asset_manufacturer_master_update";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@type", SqlDbType.VarChar, 100).Value = ddltype.SelectedItem.Text;
        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = txtmanfactname.Text;
        cmd.Parameters.Add("@manufacturer_desc", SqlDbType.VarChar, 100).Value = txtmanufactdesc.Text;
        cmd.Parameters.Add("@contact", SqlDbType.VarChar, 15).Value = txtcontactnum.Text;
        cmd.Parameters.Add("@address", SqlDbType.VarChar, 1000).Value = txtaddress.Text;
        cmd.Parameters.Add("@email ", SqlDbType.VarChar, 100).Value = txtemail.Text;
        if (txtefffrm.Text != string.Empty)
        {
            cmd.Parameters.Add("@eff_frm", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
        }

        if (txteffto.Text != string.Empty)
        {
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
        }
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 120).Value = Session["EmpCode"];
        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = lblmanufactureid.Text;
        cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        bindgrid();

        string script = "alert('Record updated.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("assetmanufacturer.aspx");
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmanufactureid.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        txtmanfactname.Text = grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", ""); ;
        txtmanufactdesc.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", ""); ;
        txtefffrm.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""); ;
        txteffto.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", ""); ;
        txtemail.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", ""); ;
        txtaddress.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", ""); ;
        txtcontactnum.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", ""); ;
        lnkadd.Enabled = false;
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
}