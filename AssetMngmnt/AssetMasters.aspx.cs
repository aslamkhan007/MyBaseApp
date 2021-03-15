using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AssetMngmnt_AssetMasters : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
    string dept = string.Empty;
    string empcode= string.Empty;

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
                        lbmanufac.Visible = false;
                        ddlmanufacturer.Visible = false;
                        lbvendor.Visible = false;
                        ddlvendor.Visible = false;
                        lbfurcodeid.Visible = true;
                        lbfurcode.Visible = true;
                    }
                    else
                    {
                        dept = Dr[1].ToString();
                        if (dept != "MIS")
                        {
                            dept = "GEN";
                            ViewState["dept"] = dept;
                            ddlcapital.SelectedIndex = 1;
                            lbmanufac.Visible = false;
                            ddlmanufacturer.Visible = false;
                            lbvendor.Visible = false;
                            ddlvendor.Visible = false;
                            lbfurcodeid.Visible = true;
                            lbfurcode.Visible = true;

                        }
                         else
                    {
                        ViewState["dept"] = dept;
                    }
                    
                    
                    }
                }

            }

      
            Dr.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT description,id FROM dbo.jct_asset_manufacturer_master WHERE [TYPE]='Manufacturer'  AND status='A' AND module_usedby ='" + dept + "'", obj.Connection());
            cmd2.CommandType = CommandType.Text;
            DataSet ds2 = new DataSet();
            ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds2);
            ddlmanufacturer.DataSource = ds2;
            ddlmanufacturer.DataTextField = "description";
            ddlmanufacturer.DataValueField = "id";
            ddlmanufacturer.DataBind();


            cmd = new SqlCommand("SELECT  item_name,asset_id FROM dbo.jct_asset_master where status='A' and module_usedby ='" + dept + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ddlasssetcat.DataSource = ds;
            ddlasssetcat.DataTextField = "item_name";
            ddlasssetcat.DataValueField = "asset_id";
            ddlasssetcat.DataBind();
            ddlasssetcat_SelectedIndexChanged(sender, null);

            bindgrid();


            // comment by aslam
            sql = "SELECT state_name,state_id FROM dbo.jct_asset_state_master WHERE status='A' AND module_usedby =  '" + ViewState["dept"] + "'";
            cmd = new SqlCommand(sql, obj.Connection());
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            ddlstate.DataSource = ds;
            ddlstate.DataTextField = "state_name";
            ddlstate.DataValueField = "state_id";
            ddlstate.DataBind();

        }
                        
    }
    protected void ddlasssetcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //SqlCommand cmd = new SqlCommand("SELECT  item_name,asset_id FROM dbo.jct_asset_master where status='A' and module_usedby ='" + dept + "'", obj.Connection());
            //cmd.CommandType = CommandType.Text;
            //DataSet ds = new DataSet();
            //ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);
            //ddlassettype.DataSource = ds;
            //ddlasssetcat.DataTextField = "item_name";
            //ddlasssetcat.DataValueField = "asset_id";
            //ddlasssetcat.DataBind();
            
            //SqlCommand  cmd = new SqlCommand(" SELECT   asset_type_desc,asset_type_id FROM jct_asset_type_master WHERE  STATUS='A' and module_usedby ='" + dept + "' and asset_id='" + ddlasssetcat.SelectedItem.Value + "'", obj.Connection());
            SqlCommand cmd = new SqlCommand(" SELECT   asset_type_desc,asset_type_id FROM jct_asset_type_master WHERE  STATUS='A' and module_usedby ='" + ViewState["dept"] + "' and asset_id='" + ddlasssetcat.SelectedItem.Value + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
           ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ddlassettype.DataSource = ds;
            ddlassettype.DataTextField = "asset_type_desc";
            ddlassettype.DataValueField = "asset_type_id";
            ddlassettype.DataBind();

            cmd = new SqlCommand("jct_asset_masters_fetch",obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
            da = new SqlDataAdapter(cmd);
             ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
            }
            con.Close();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            //sql = "SELECT  empcode,b.deptcode FROM jct_empmast_base  a JOIN dbo.DEPTMAST  b ON a.deptcode=b.DEPTCODE WHERE  a.empcode= '" + Session["EmpCode"] + "'";
            //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //SqlDataReader Dr = cmd.ExecuteReader();
            //if (Dr.HasRows)
            //{
            //    while (Dr.Read())
            //    {
            //        dept = Dr[1].ToString();
                    //if (ViewState["dept"].ToString() == "MIS")
                    //{
                    //    //Dr.Close();

                    //    String code=  GenerateCode();
                                             
                    //    sql = "jct_asset_masters_insert";
                    //    SqlCommand  cmd = new SqlCommand(sql, obj.Connection());
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
                    //    cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
                    //    cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = ddlassettype.SelectedItem.Text;
                    //    cmd.Parameters.Add("@type_name", SqlDbType.VarChar, 100).Value = txtassetname.Text;
                    //    cmd.Parameters.Add("@type_description", SqlDbType.VarChar, 1000).Value = txtassetdesc.Text;
                    //    cmd.Parameters.Add("@warranty", SqlDbType.VarChar, 100).Value = txtwarranty.Text;
                    //    cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];


                    //    if (txtDOP.Text != string.Empty)
                    //    {
                    //        cmd.Parameters.Add("@dop", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
                    //    }

                    //    if (txtacquisitiondt.Text != string.Empty)
                    //    {
                    //        cmd.Parameters.Add("@acquisition_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtacquisitiondt.Text);
                    //    }

                    //    if (ddlmanufacturer.SelectedItem.Text != string.Empty)
                    //    {
                    //        cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedItem.Value;
                    //    }

                    //    cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ddlstate.SelectedValue;
                    //    cmd.Parameters.Add("@capital_id", SqlDbType.VarChar, 20).Value = ddlcapital.SelectedValue;
                    //    cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                    //    cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 90).Value = ddlvendor.SelectedItem.Text;
                    //    if (ddlPrinterType.Visible == true)
                    //    {
                    //        cmd.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = ddlPrinterType.SelectedItem.Text;
                    //    }

                    //    cmd.Parameters.Add("@fur_code", SqlDbType.VarChar, 20).Value = ViewState["furCode"];
                    //    cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                    //    cmd.ExecuteNonQuery();
         
                    //}                     
                    //else
                    //{
                        //Dr.Close();
                        sql = "jct_asset_masters_insert";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
                        cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
                        cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = ddlassettype.SelectedItem.Text;
                        cmd.Parameters.Add("@type_name", SqlDbType.VarChar, 100).Value = txtassetname.Text;
                        cmd.Parameters.Add("@type_description", SqlDbType.VarChar, 1000).Value = txtassetdesc.Text;
                        cmd.Parameters.Add("@warranty", SqlDbType.VarChar, 100).Value = txtwarranty.Text;
                        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];


                        if (txtDOP.Text != string.Empty)
                        {
                            cmd.Parameters.Add("@dop", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
                        }

                        if (txtacquisitiondt.Text != string.Empty)
                        {
                            cmd.Parameters.Add("@acquisition_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtacquisitiondt.Text);
                        }

                            if (ViewState["dept"].ToString() == "MIS")
                            {

                                if (ddlmanufacturer.SelectedItem.Text == "")
                                {
                                    cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedItem.Value;
                                }
                            }
                            else
                            {
                                cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedItem.Value;
                            }

                        cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ddlstate.SelectedValue;
                        cmd.Parameters.Add("@capital_id", SqlDbType.VarChar, 20).Value = ddlcapital.SelectedValue;
                        cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                        cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 90).Value = ddlvendor.SelectedItem.Text;
                        if (ddlPrinterType.Visible == true)
                        {
                            cmd.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = ddlPrinterType.SelectedItem.Text;
                        }

                        cmd.Parameters.Add("@fur_code", SqlDbType.VarChar, 20).Value = ViewState["furCode"];
                        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                        cmd.ExecuteNonQuery();
                      
                     

                    //}
                    bindgrid();
                    script = "alert('Record saved.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //    }
            //}
        }



        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //script = "alert('Please check the details!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // comment by aslam
        if (ViewState["dept"].ToString() == "GEN")
        //if (dept == "MIS")
        {
            //lbfurcode.Visible = true;
            lbassetnameID.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            ddlassettype.SelectedIndex = ddlassettype.Items.IndexOf(ddlassettype.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "")));
            ddlasssetcat.SelectedIndex = ddlasssetcat.Items.IndexOf(ddlasssetcat.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "")));
            txtassetname.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtassetdesc.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txtDOP.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            ddlmanufacturer.SelectedIndex = ddlmanufacturer.Items.IndexOf(ddlmanufacturer.Items.FindByValue(grdDetail.SelectedRow.Cells[7].Text));
            ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByText(grdDetail.SelectedRow.Cells[7].Text));
            //ddlcapital.SelectedIndex = ddlcapital.Items.IndexOf(ddlcapital.Items.FindByText(grdDetail.SelectedRow.Cells[10].Text));

            if (ddlPrinterType.Visible == true)
            {
                ddlPrinterType.SelectedIndex = ddlPrinterType.Items.IndexOf(ddlPrinterType.Items.FindByText(grdDetail.SelectedRow.Cells[9].Text));
            }
        }
        else
        {
            //lbfurcode.Visible = true;
            lbassetnameID.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            ddlassettype.SelectedIndex = ddlassettype.Items.IndexOf(ddlassettype.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "")));
            ddlasssetcat.SelectedIndex = ddlasssetcat.Items.IndexOf(ddlasssetcat.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "")));
            txtassetname.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtassetdesc.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txtDOP.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            //ddlmanufacturer.SelectedIndex = ddlmanufacturer.Items.IndexOf(ddlmanufacturer.Items.FindByText(grdDetail.SelectedRow.Cells[7].Text));
            ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByText(grdDetail.SelectedRow.Cells[8].Text));
            //ddlcapital.SelectedIndex = ddlcapital.Items.IndexOf(ddlcapital.Items.FindByText(grdDetail.SelectedRow.Cells[10].Text));

            if (ddlPrinterType.Visible == true)
            {
                ddlPrinterType.SelectedIndex = ddlPrinterType.Items.IndexOf(ddlPrinterType.Items.FindByText(grdDetail.SelectedRow.Cells[9].Text));
            }

        }



    }

    protected void ddlassettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            bindgrid();
            if (ddlassettype.SelectedItem.Text == "Printer")
            {
                lblPrinterType.Visible = true;
                ddlPrinterType.Visible = true;
            }
            else
            {
                lblPrinterType.Visible = false;
                ddlPrinterType.Visible = false;
            }
        }
        catch(Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        finally
        {
            con.Close();
        }
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        if (lbassetnameID.Text == "")
        {
            script = "alert('Please select a record.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        try
        {
            sql = "jct_asset_masters_delete";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = lbassetnameID.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["Empcode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();

            script = "alert('Record Deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {


        if (lbassetnameID.Text == "")
        {
            script = "alert('Please select a record.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        try
        {
            string code = GenerateCode();
            sql = "jct_asset_masters_update";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = lbassetnameID.Text;
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = ddlassettype.SelectedItem.Text;
            cmd.Parameters.Add("@type_name", SqlDbType.VarChar, 100).Value = txtassetname.Text;
            cmd.Parameters.Add("@type_description", SqlDbType.VarChar, 1000).Value = txtassetdesc.Text;
            cmd.Parameters.Add("@warranty", SqlDbType.VarChar, 100).Value = txtwarranty.Text;
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar,20).Value = ViewState["dept"];

            if (txtDOP.Text != string.Empty)
            {
                cmd.Parameters.Add("@dop", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
            }

            if (txtacquisitiondt.Text != string.Empty)
            {
                cmd.Parameters.Add("@acquisition_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtacquisitiondt.Text);
            }


                if (ViewState["dept"].ToString() == "MIS")
                {

                    if (ddlmanufacturer.SelectedItem.Text == "")
                    {
                        cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = "0";
                    }
                    else
                    {
                        cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedItem.Value;
                    }
                }
                else
                {
                    cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedItem.Value;
                }



            //cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedItem.Value;
            cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ddlstate.SelectedValue;
            cmd.Parameters.Add("@capital_id", SqlDbType.VarChar, 20).Value = ddlcapital.SelectedValue;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
            cmd.Parameters.Add("@vendor", SqlDbType.VarChar,90).Value = ddlvendor.SelectedItem.Text;
            if (ddlPrinterType.Visible == true)
            {
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = ddlPrinterType.SelectedItem.Text;
            }
            if (code!=null)
            {
                cmd.Parameters.Add("@fur_code", SqlDbType.VarChar, 20).Value = code;
            }
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
           
        
            script = "alert('Record updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            bindgrid();
           
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        //if (dept == "MIS")
        //{
        //    if (lbassetnameID.Text == "")
        //    {
        //        script = "alert('Please select a record.!!');";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //    }
        //    try
        //    {
        //        string code = GenerateCode();
        //        sql = "jct_asset_masters_update";
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@id", SqlDbType.Int).Value = lbassetnameID.Text;
        //        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
        //        cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
        //        cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = ddlassettype.SelectedItem.Text;
        //        cmd.Parameters.Add("@type_name", SqlDbType.VarChar, 100).Value = txtassetname.Text;
        //        cmd.Parameters.Add("@type_description", SqlDbType.VarChar, 1000).Value = txtassetdesc.Text;
        //        cmd.Parameters.Add("@warranty", SqlDbType.VarChar, 100).Value = txtwarranty.Text;
        //        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];

        //        if (txtDOP.Text != string.Empty)
        //        {
        //            cmd.Parameters.Add("@dop", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
        //        }

        //        if (txtacquisitiondt.Text != string.Empty)
        //        {
        //            cmd.Parameters.Add("@acquisition_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtacquisitiondt.Text);
        //        }

        //        cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedItem.Value;
        //        cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ddlstate.SelectedValue;
        //        cmd.Parameters.Add("@capital_id", SqlDbType.VarChar, 20).Value = ddlcapital.SelectedValue;
        //        cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
        //        cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 90).Value = ddlvendor.SelectedItem.Text;
        //        if (ddlPrinterType.Visible == true)
        //        {
        //            cmd.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = ddlPrinterType.SelectedItem.Text;
        //        }
        //        if (code != null)
        //        {
        //            cmd.Parameters.Add("@fur_code", SqlDbType.VarChar, 20).Value = code;
        //        }
        //        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();


        //        script = "alert('Record updated.!!');";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //        bindgrid();

        //    }
        //    catch (Exception ex)
        //    {
        //        script = "alert('" + ex.Message + "');";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //    }

        //}
        
    }

    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grdDetail.PageIndex = e.NewPageIndex;
        //bindgrid();
    }

    protected void lnkresest_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetMasters.aspx");
    }

    private void bindgrid()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("jct_asset_masters_fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            con.Open();
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            if (ddlasssetcat.SelectedValue != string.Empty && ddlassettype.Items.Count > 0)
            {
                cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;

            }
            if (ddlassettype.SelectedValue != string.Empty && ddlassettype.Items.Count > 0)
            {
                cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;

            }
            if (ddlPrinterType.Visible == true)
            {
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 100).Value = ddlPrinterType.SelectedItem.Text;

            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            con.Close();
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlPrinterType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlasssetcat.DataSourceID = "SqlDataSource1";
        //ddlasssetcat.DataTextField = "item_name";
        //ddlasssetcat.DataValueField = "asset_id";
        //ddlasssetcat.DataBind();

        //ddlassettype.DataSourceID = "SqlDataSource4";
        //SqlDataSource4.SelectParameters["asset_id"].DefaultValue = ddlasssetcat.SelectedValue;
        //ddlassettype.DataTextField = "asset_type_name";
        //ddlassettype.DataValueField = "asset_type_id";
        //ddlassettype.DataBind();

        SqlCommand cmd = new SqlCommand("SELECT  item_name,asset_id FROM dbo.jct_asset_master where status='A' and module_usedby ='" + dept + "'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlasssetcat.DataSource = ds;
        ddlasssetcat.DataTextField = "item_name";
        ddlasssetcat.DataValueField = "asset_id";
        ddlasssetcat.DataBind();
        cmd = new SqlCommand("  SELECT   asset_type_desc,asset_type_id FROM jct_asset_type_master WHERE  STATUS='A' and module_usedby ='" + dept + "'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        ds = new DataSet();
        ds = new DataSet();
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlassettype.DataSource = ds;
        ddlassettype.DataTextField = "item_name";
        ddlassettype.DataValueField = "asset_id";
        ddlassettype.DataBind();

        bindgrid();
    }

private string  GenerateCode () 
    {
        #region Serial No. Code

        string str;
        string codes;
        codes = String.Empty;
        
        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(fur_code),CHARINDEX('-',max(fur_code))+1,len(max(fur_code))+3) from jct_asset_type_master_detail ", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
             
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    //ViewState["furCode"] = "001";
                    //ViewState["furCode"] = "FUR-001";// + ViewState["furCode"];

                    codes = "FUR-001";
                    //return codes;
                //    dr.Close();
                   
                }
                else
                {
                  //  ViewState["furCode"] = int.Parse(dr[0].ToString()) + 1;
                    //ViewState["furCode"] = "FUR-" + ViewState["furCode"];
                    if ((int.Parse(dr[0].ToString()) + 1)<10)
                    {
                    codes = "FUR-00" + (int.Parse(dr[0].ToString()) + 1).ToString();
                    }
                    else
                    if (((int.Parse(dr[0].ToString()) + 1)>=10) && ((int.Parse(dr[0].ToString()) + 1)<100))
                    {
                    codes = "FUR-0" + (int.Parse(dr[0].ToString()) + 1).ToString();
                    }
                    else
                    {
                        codes = "FUR-" + (int.Parse(dr[0].ToString()) + 1).ToString();
                    }

                }
              
                
            }
            dr.Close();
           
         

        }
return codes;
     
      
        //con.Close();

        #endregion
    }


protected void txtDOP_TextChanged(object sender, EventArgs e)
{
    if (dept.ToString() != "MIS" && ViewState["dept"].ToString() != "MIS")
    {
        txtacquisitiondt.Text = txtDOP.Text;
    }
    else
    {
    }
}
}
