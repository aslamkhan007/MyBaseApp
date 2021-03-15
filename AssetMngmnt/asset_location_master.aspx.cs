using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_location_master : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
    string empcode = string.Empty;
    string dept = string.Empty;
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
                    dept = Dr[1].ToString();


                    if (dept == "MIS" && (empcode.ToString() == "M-02467" || empcode.ToString() == "m-02467" || empcode.ToString() == "a-00098" || empcode.ToString() == "A-00098"))
                    {
                        ViewState["dept"] = "GEN";
                        dlabel.Visible = true;
                        ddlloc.Visible = true;
                        txtlab.Text = "Sub Location";
                    }
                    else if (dept == "MIS")
                    {
                        ViewState["dept"] = dept;
                        dlabel.Visible = false;
                        ddlloc.Visible = false;
                    }
                    else
                    {
                        ViewState["dept"] = "GEN";
                        dlabel.Visible = true;
                        ddlloc.Visible = true;
                        txtlab.Text = "Sub Location";
                    }

                }
                Dr.Close();
                Bindgrid();
            }
            else
            {
                //no record found redirect
            }
        }





            //        if (empcode.ToString() == "M-02467" || empcode.ToString() == "m-02467" || empcode.ToString() == "a-00098" || empcode.ToString() == "A-00098")
            //        {
            //            dept = "GEN";
            //            ViewState["dept"] = dept;
            //            dlabel.Visible = true;
            //            ddlloc.Visible = true;

            //            txtlab.Text = "Sub Location";
            //        }
            //        else
            //        {
                       
            //            if (dept != "MIS")
            //            {
            //                dept = "GEN";
            //                ViewState["dept"] = dept;
            //                dlabel.Visible = true;
            //                ddlloc.Visible = true;

            //                txtlab.Text = "Sub Location";
            //            }
            //            else
            //           ViewState["dept"] = dept;
            //            dlabel.Visible = false;
            //            ddlloc.Visible = false;
             
                  
            //        }
                

            //    }

            //}
            //Dr.Close();

       

             

        }
       
       
    protected void LnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "jct_asset_location_master_insert_del_upd";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@main_location", SqlDbType.VarChar, 100).Value = ddlloc.SelectedItem.Text;

            if (ddlHousetypes.Visible != false)
            {
                cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = ddlHousetypes.SelectedItem.Text + " - " +txtlcation.Text;               
            }            
            else
            {
                cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = txtlcation.Text;
            }
            
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 100).Value = "add";
            cmd.Parameters.Add("@createdby", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
           
            cmd.ExecuteNonQuery();
            Bindgrid();

             string script = "alert('Record saved!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "jct_asset_location_master_insert_del_upd";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@main_location", SqlDbType.VarChar, 100).Value = ddlloc.SelectedItem.Text;
            //cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = txtlcation.Text;

            if (ddlHousetypes.Visible != false)
            {
                cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = ddlHousetypes.SelectedItem.Text + " - " + txtlcation.Text;
            }
            else
            {
                cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = txtlcation.Text;
            }

            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 100).Value = "Upd";
            //cmd.Parameters.Add("@Id", SqlDbType.VarChar, 100).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@createdby", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

            cmd.ExecuteNonQuery();
            Bindgrid();

            string script = "alert('Record updated!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            //script = "alert('" + ex.Message + "');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            script = "alert('please select a record!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "jct_asset_location_master_insert_del_upd";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@main_location", SqlDbType.VarChar, 100).Value = ddlloc.SelectedItem.Text;
            //cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = txtlcation.Text;

            if (ddlHousetypes.Visible != false)
            {
                cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = ddlHousetypes.SelectedItem.Text + " - " + txtlcation.Text;
            }
            else
            {
                cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = txtlcation.Text;
            }


            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 100).Value = "del";
            //cmd.Parameters.Add("@Id", SqlDbType.VarChar, 100).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@createdby", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

            cmd.ExecuteNonQuery();
            Bindgrid();

            string script = "alert('Record deleted!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }



    }
    protected void Bindgrid()
    {

        sql = "SELECT ID,location,b.empname as CreatedBy FROM jct_asset_location_master a JOIN dbo.JCT_EmpMast_Base b ON  a.createdby=b.empcode where a.status='A' and  b.active='Y' and module_usedby='" + ViewState["dept"] + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            FilteredTextBoxExtender1.Enabled = false;
  
        if (ddlloc.Visible == true)
        {
            sql = "SELECT ID,location,b.empname CreatedBy FROM jct_asset_location_master a JOIN dbo.JCT_EmpMast_Base b ON  a.createdby=b.empcode where a.status='A' and  b.active='Y' and main_location='" + ddlloc.SelectedItem.Text + "' and module_usedby='" + ViewState["dept"] + "'";
             cmd = new SqlCommand(sql, obj.Connection());
             da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            FilteredTextBoxExtender1.Enabled = true;
        }
  
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlloc.Visible == true)
        {
            if (ddlloc.SelectedItem.Text == "Colony")
            {
                FilteredTextBoxExtender1.Enabled = true;
                ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindByText(ddlloc.SelectedItem.Text));
                ViewState["ID"] = grdDetail.SelectedRow.Cells[1].Text;
                txtlcation.Text = grdDetail.SelectedRow.Cells[2].Text.Split('-')[1].ToString();

            }
            else
            {
                FilteredTextBoxExtender1.Enabled = false;
                ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindByText(ddlloc.SelectedItem.Text));
                ViewState["ID"] = grdDetail.SelectedRow.Cells[1].Text;
                txtlcation.Text = grdDetail.SelectedRow.Cells[2].Text;
            }

        }
        else
        {
            ViewState["ID"] = grdDetail.SelectedRow.Cells[1].Text;
            txtlcation.Text = grdDetail.SelectedRow.Cells[2].Text;
        }
    }
    protected void ddlloc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlloc.Visible == true)
        {

            if (ddlloc.SelectedItem.Text == "Colony")
            {
                ddlHousetypes.Visible = true;
                lblHousetype.Visible = true;
                FilteredTextBoxExtender1.Enabled = true;
            }
            else
            {
                ddlHousetypes.Visible = false;
                lblHousetype.Visible = false;
                FilteredTextBoxExtender1.Enabled = false;
            }


            txtlcation.Text = "";
            //'sql = "SELECT ID,location,b.empname as CreatedBy FROM jct_asset_location_master a JOIN dbo.JCT_EmpMast_Base b ON  a.createdby=b.empcode where a.status='A' and main_location='" + ddlloc.SelectedItem.Text + "' and module_usedby='" + ViewState["dept"] + "'";
            sql = "exec Jct_Asset_Location_Fetch '" + ddlloc.SelectedItem.Text + "' ,'" + ViewState["dept"] + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        }
  

    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("asset_location_master.aspx");

    }
}