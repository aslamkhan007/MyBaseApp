using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class PayRoll_Payroll_location_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlantList();
            txteffto_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
        }
        
    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateCode();
            sql = "JCT_payroll_location_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location_code", SqlDbType.VarChar, 10).Value = ViewState["locCode"];
            cmd.Parameters.Add("@Location_description", SqlDbType.VarChar, 40).Value = txtlocdesc.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar,60).Value = txtaddress.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = txtcity.Text;
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 30).Value = txtstate.Text;
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = 0;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lbloctext.Visible = true;
            lbcodeid.Text = ViewState["locCode"].ToString();
            lbcodeid.Visible = true;
        }
        catch (Exception ex)
        {
            string script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_payroll_location_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location_code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Location_description", SqlDbType.VarChar, 40).Value = txtlocdesc.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 60).Value = txtaddress.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = txtcity.Text;
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = txteffto.Text;
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 30).Value = txtstate.Text;
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = lblocid.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('Please select a record !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_payroll_location_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location_code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Location_description", SqlDbType.VarChar, 40).Value = txtlocdesc.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 60).Value = txtaddress.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = txtcity.Text;
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 30).Value = txtstate.Text;
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = lblocid.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('Please select a record !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_location_master.aspx");
    }
    private void bindgrid()
    {
        sql = "Jct_Payroll_Locationlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
       
    }

    private void PlantList()
    {
        sql = "Jct_Payroll_Plantlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "LongDescription";
        ddlplant.DataValueField = "PlantCode";
        ddlplant.DataBind();
        bindgrid();
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblocid.Text = grdDetail.SelectedRow.Cells[1].Text;
        ddlplant.SelectedIndex=ddlplant.Items.IndexOf(ddlplant.Items.FindByValue(grdDetail.SelectedRow.Cells[2].Text));
         txtstate.Text=grdDetail.SelectedRow.Cells[6].Text;
        //ddlstate_SelectedIndexChanged(sender, null);
        txtcity.Text=grdDetail.SelectedRow.Cells[7].Text;
        //ddlcity_SelectedIndexChanged(sender, null);
        txtefffrm.Text = grdDetail.SelectedRow.Cells[8].Text;
        txteffto.Text = grdDetail.SelectedRow.Cells[9].Text;
        txtaddress.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[5].Text);
        txtlocdesc.Text = grdDetail.SelectedRow.Cells[4].Text;
        lbcodeid.Text = grdDetail.SelectedRow.Cells[3].Text;
        lbcodeid.Visible = true;
        lblCode.Visible = true;
        lblocid.Visible = true;
        lbloctext.Visible = true;
    }

    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;
        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(Location_code),CHARINDEX('-',max(Location_code))+1,len(max(Location_code))+3) from JCT_payroll_location_master", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["locCode"] = "100";
                    ViewState["locCode"] = "LOC-" + ViewState["locCode"];
                }
                else
                {
                    ViewState["locCode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["locCode"] = "LOC-" + ViewState["locCode"];
                }
            }

        }

        dr.Close();
        //con.Close();
       
        #endregion
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
        ClearTextBoxes();

    }

    private void ClearTextBoxes()
    {
        txtefffrm.Text = "";
        txteffto.Text = "";
        lbcodeid.Visible = false;
        lblCode.Visible = false;
        lblocid.Visible = false;
        lbloctext.Visible = false;
        txtstate.Text = "";
        txtcity.Text = "";
        txtaddress.Text = "";
        txtlocdesc.Text = "";
    }
}