using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class PayRoll_payroll_accommodation_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            PlantList();
            bindgrid();
            txteff_to_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
        }

    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_payroll_accomodation_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@plant_code ", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Accomodation_Type ", SqlDbType.VarChar,15).Value = txtaccomodation.Text;
            cmd.Parameters.Add("@Start_HouseNo", SqlDbType.Int).Value = txtstart.Text;
            cmd.Parameters.Add("@End_HouseNo", SqlDbType.Int).Value = txtend.Text;
            cmd.Parameters.Add("@Effective_From", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@Effective_To", SqlDbType.DateTime).Value = txteff_to.Text;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@accomodation_description", SqlDbType.VarChar,50).Value = DescText.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record Saved !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
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
            string sql = "JCT_payroll_accomodation_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@plant_code ", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;         
            cmd.Parameters.Add("@Accomodation_Type ", SqlDbType.VarChar,15).Value = txtaccomodation.Text;
            cmd.Parameters.Add("@Start_HouseNo", SqlDbType.Int).Value = txtstart.Text;
            cmd.Parameters.Add("@End_HouseNo", SqlDbType.Int).Value = txtend.Text;
            cmd.Parameters.Add("@Effective_From", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@Effective_To", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
            cmd.Parameters.Add("@accomodation_description", SqlDbType.VarChar,50).Value = DescText.Text;
            cmd.ExecuteNonQuery();
            bindgrid();

            string script = "alert('Record updated !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('some error occurred!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_payroll_accomodation_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@plant_code ", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Accomodation_Type ", SqlDbType.VarChar,15).Value = txtaccomodation.Text;
            cmd.Parameters.Add("@Start_HouseNo", SqlDbType.Int).Value = txtstart.Text;
            cmd.Parameters.Add("@End_HouseNo", SqlDbType.Int).Value = txtend.Text;
            cmd.Parameters.Add("@Effective_From", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@Effective_To", SqlDbType.DateTime).Value = txteff_to.Text;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
            cmd.Parameters.Add("@accomodation_description", SqlDbType.VarChar,50).Value = DescText.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record deleted !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('some error occurred!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_accommodation_master.aspx");
    }

    private void bindgrid()
    {

        string sql = "Jct_Payroll_Accomodationlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@plant_code ", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    public void PlantList()
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
        SrId.Text = grdDetail.SelectedRow.Cells[1].Text;
        plantid.Text = grdDetail.SelectedRow.Cells[2].Text;
        ddlplant.Items.IndexOf(ddlplant.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text));
        txtaccomodation.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[3].Text);
        DescText.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[4].Text);
        txtstart.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[5].Text);
        txtend.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[6].Text);
        txteff_from.Text = grdDetail.SelectedRow.Cells[7].Text;
        txteff_to.Text = grdDetail.SelectedRow.Cells[8].Text;
        PlantCode.Visible = true;
        plantid.Visible = true;
        SrCode.Visible = true;
        SrId.Visible = true;
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
        ClearTextBoxes();
    }
    private void ClearTextBoxes()
    {
        //ddlplant.ClearSelection();
        txteff_from.Text = "";
        txteff_to.Text = "";
        txtstart.Text = "";
        txtend.Text = "";
        txtaccomodation.Text = "";
        PlantCode.Visible = false;
        plantid.Visible = false;
        SrCode.Visible = false;
        SrId.Visible = false;
        DescText.Text = "";
     
    }
}