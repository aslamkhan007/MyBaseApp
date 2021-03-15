using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PayRoll_payroll_unitrate_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {        
            Plantbind();            
            bindgrid();
            txteffto_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
        }
    }

    public void Plantbind()
    {              
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();      
    }

    private void bindgrid()
    {
        sql = "Jct_Payroll_unitrate_fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lnksave.Enabled = false;
            Panel1.Visible = true;
        }
        else
        {
            lnksave.Enabled = true;
            Panel1.Visible = true;
        }
        lnkupd.Enabled = false;
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        string sql = "jct_payroll_unitrate_master_insert";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@UnitRate", SqlDbType.Decimal, 2).Value = txtunitrate.Text;
        cmd.Parameters.Add("@effective_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
        cmd.Parameters.Add("@effective_to", SqlDbType.DateTime).Value = txteffto.Text;
        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
        cmd.Parameters.Add("@sr_no", SqlDbType.Int).Value = 0;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;        
        cmd.ExecuteNonQuery();
        bindgrid();
        string script = "alert('Record saved.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }

    protected void lnkupd_Click(object sender, EventArgs e)
    {
        string sql = "jct_payroll_unitrate_master_update";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@UnitRate", SqlDbType.Decimal, 2).Value = txtunitrate.Text;
        cmd.Parameters.Add("@effective_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
        cmd.Parameters.Add("@effective_to", SqlDbType.DateTime).Value = txteffto.Text;
        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
        cmd.Parameters.Add("@sr_no", SqlDbType.Int).Value = SrId.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;        
        cmd.ExecuteNonQuery();
        bindgrid();
        string script = "alert('Record updated.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        string sql = "jct_payroll_unitrate_master_delete";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@sr_no", SqlDbType.Int).Value = SrId.Text;
        cmd.ExecuteNonQuery();
        bindgrid();
        string script = "alert('Record deleted.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        ClearTextBoxes();
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnksave.Enabled = false;
        txtunitrate.Text = grdDetail.SelectedRow.Cells[2].Text;
        txtefffrm.Text = grdDetail.SelectedRow.Cells[3].Text;
        txteffto.Text = grdDetail.SelectedRow.Cells[4].Text;
        SrId.Text = grdDetail.SelectedRow.Cells[1].Text;
        SrCode.Visible = true;
        SrId.Visible = true;
        lnkupd.Enabled = true;
    }
   
    private void ClearTextBoxes()
    {
        txtefffrm.Text = "";
        txteffto.Text = "";
        txtunitrate.Text = "";
        SrCode.Visible = false;
        SrId.Visible = false;
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_unitrate_master.aspx");
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
}