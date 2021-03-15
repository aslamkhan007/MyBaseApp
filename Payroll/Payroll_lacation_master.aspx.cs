using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class PayRoll_Payroll_lacation_master : System.Web.UI.Page
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
            //JCT_payroll_location_master
            sql = "JCT_payroll_location_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location_code", SqlDbType.VarChar, 10).Value = ViewState["locCode"];
            cmd.Parameters.Add("@Location_description", SqlDbType.VarChar, 100).Value = txtlocdesc.Text;
            cmd.Parameters.Add("@PFNo", SqlDbType.VarChar, 30).Value = txtPFNo.Text;
            cmd.Parameters.Add("@ESINo", SqlDbType.VarChar, 30).Value = txtEsiNo.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 15).Value = txtaddress.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = ddlcity.SelectedItem.Text;
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 30).Value = ddlstate.SelectedItem.Text;
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = 0;
            cmd.ExecuteNonQuery();
              
            //con.Close();
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
            //JCT_payroll_location_master
            sql = "JCT_payroll_location_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location_code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Location_description", SqlDbType.VarChar, 100).Value = txtlocdesc.Text;
            cmd.Parameters.Add("@PFNo", SqlDbType.VarChar, 30).Value = txtPFNo.Text;
            cmd.Parameters.Add("@ESINo", SqlDbType.VarChar, 30).Value = txtEsiNo.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 15).Value = txtaddress.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = ddlcity.SelectedItem.Text;
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = txteffto.Text;//Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = "s-13823";
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 30).Value = ddlstate.SelectedItem.Text;
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
            //JCT_payroll_location_master
            sql = "JCT_payroll_location_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location_code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Location_description", SqlDbType.VarChar, 100).Value = txtlocdesc.Text;
            cmd.Parameters.Add("@PFNo", SqlDbType.VarChar, 30).Value = txtPFNo.Text;
            cmd.Parameters.Add("@ESINo", SqlDbType.VarChar, 30).Value = txtEsiNo.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 15).Value = txtaddress.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = ddlcity.SelectedItem.Text;
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = "s-13823";
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 30).Value = ddlstate.SelectedItem.Text;
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
        Response.Redirect("Payroll_lacation_master.aspx");
    }
    //changed query
    private void bindgrid()
    {
        sql = " SELECT SRNO,Plant_Code,state,city,location_code,Location_description ,Address ,eff_from AS EffectiveFrom,eff_to AS EffectiveTo,PFNo ,ESINo FROM JCT_payroll_location_master WHERE  status='A'and plant_code='" + ddlplant.SelectedItem.Value + "'and state='" + ddlstate.SelectedItem.Value + "'and city='" + ddlcity.SelectedItem.Value + "'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
       
    }
    //included functions for binding dropdown lists
    private void StateList()
    {
        string sql = "SELECT DISTINCT state FROM JCTGEN..JCT_EPOR_STATE_MASTER order by state";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlstate.DataSource = ds;
        ddlstate.DataTextField = "State";
        ddlstate.DataValueField = "State";
        ddlstate.DataBind();
    }
    private void PlantList()
    {
        string sql = "SELECT Plant_Code,Plant_Description FROM dbo.jctpayroll_PlantMaster WHERE STATUS = 'A'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "Plant_Description";
        ddlplant.DataValueField = "Plant_Code";
        ddlplant.DataBind();
    }
    //changed the way of filling dropdowns
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblocid.Text = grdDetail.SelectedRow.Cells[1].Text;
        ddlplant.Items.IndexOf(ddlplant.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text));
        ddlstate.Items.IndexOf(ddlstate.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text));
        ddlplant.Items.IndexOf(ddlplant.Items.FindByText(grdDetail.SelectedRow.Cells[4].Text));
        txtefffrm.Text= grdDetail.SelectedRow.Cells[8].Text;
        txteffto.Text=grdDetail.SelectedRow.Cells[9].Text;
        txtaddress.Text=grdDetail.SelectedRow.Cells[7].Text;
        txtlocdesc.Text=grdDetail.SelectedRow.Cells[6].Text;
        lbcodeid.Text = grdDetail.SelectedRow.Cells[5].Text;
        txtPFNo.Text = grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
        txtEsiNo.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
        lbcodeid.Visible = true;
        lblCode.Visible = true;
        lblocid.Visible = true;
        lbloctext.Visible = true;
    }

    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;



        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
    

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
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        CityList();
    }
    private void CityList()
    {
        SqlCommand cmd = new SqlCommand("SELECT  DISTINCT City FROM JCTGEN..JCT_EPOR_STATE_MASTER   WHERE state  like'" + ddlstate.SelectedItem.Value + "'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlcity.DataSource = ds;
        ddlcity.DataTextField = "City";
        ddlcity.DataValueField = "City";
        ddlcity.DataBind();
    }
    //included events
    //changed front layout added validations on dropdowns
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        StateList();
    }
    protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
    private void ClearTextBoxes()
    {
        txtefffrm.Text = "";
        txteffto.Text = "";
        txtPFNo.Text = "";
        txtEsiNo.Text = "";
        lbcodeid.Visible = false;
        lblCode.Visible = false;
        lblocid.Visible = false;
        lbloctext.Visible = false;
        ddlstate.ClearSelection();
        ddlcity.ClearSelection();
        txtaddress.Text = "";
        txtlocdesc.Text = "";
        //grdDetail.DataSource = null;
        //grdDetail.DataBind();
       

    }
}