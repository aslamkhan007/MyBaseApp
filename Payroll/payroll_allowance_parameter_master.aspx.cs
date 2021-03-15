using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class PayRoll_payroll_allowance_parameter_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            txteff_to_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
        }
    }

    protected void GenerateCode()
    {
        #region Serial No. Code
        string str;
        SqlCommand cmd = new SqlCommand("SELECT  SUBSTRING(MAX(ComponentCode), CHARINDEX('-', MAX(ComponentCode)) + 1,LEN(MAX(ComponentCode)) + 3) FROM    dbo.Jct_Payroll_Components ", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {

                    ViewState["ComCode"] = "100";
                    ViewState["ComCode"] = "COM-" + ViewState["ComCode"];
                }
                else
                {
                    ViewState["ComCode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["ComCode"] = "COM-" + ViewState["ComCode"];
                }
            }
        }
        dr.Close();
        #endregion
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateCode();
            sql = "Jct_Payroll_Component_Insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComponentCode", SqlDbType.VarChar, 40).Value = ViewState["ComCode"];
            cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 100).Value = txtdesc.Text;
            cmd.Parameters.Add("@ComponentDescription", SqlDbType.VarChar, 50).Value = txtshortdesc.Text;
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.DateTime).Value = txteff_frm.Text;
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = txteff_to.Text;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@ComponentType", SqlDbType.VarChar, 20).Value = ddlAlloawanceType.SelectedItem.Text;
            cmd.Parameters.Add("@ComponentNatureType", SqlDbType.VarChar, 20).Value = ddlComponentNature.SelectedItem.Value;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  Saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextboxes();
        }
        catch (Exception ex)
        {
            string script = "alert('error occurred!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }              
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Jct_Payroll_Component_Update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComponentCode", SqlDbType.VarChar, 40).Value = lbcodeid.Text;            
            cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 100).Value = txtdesc.Text;
            cmd.Parameters.Add("@ComponentDescription", SqlDbType.VarChar, 50).Value = txtshortdesc.Text;
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_frm.Text);
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value =  Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@ComponentType", SqlDbType.VarChar, 20).Value = ddlAlloawanceType.SelectedItem.Text;
            cmd.Parameters.Add("@ComponentNatureType", SqlDbType.VarChar, 20).Value = ddlComponentNature.SelectedItem.Value;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextboxes();
        }
        catch (Exception ex)
        {
            string script = "alert('error occurred!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Jct_Payroll_Components_Delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SrNo", SqlDbType.Int).Value = Convert.ToInt32(grdDetail.SelectedRow.Cells[9].Text);
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  Deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextboxes();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_allowance_parameter_master.aspx");
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbcodeid.Text = grdDetail.SelectedRow.Cells[1].Text;
        txtdesc.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[2].Text);
        txtshortdesc.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[3].Text);
        ddlAlloawanceType.SelectedIndex = ddlAlloawanceType.Items.IndexOf(ddlAlloawanceType.Items.FindByText(grdDetail.SelectedRow.Cells[4].Text));
        ddlComponentNature.SelectedIndex = ddlComponentNature.Items.IndexOf(ddlComponentNature.Items.FindByText(grdDetail.SelectedRow.Cells[5].Text));   
        txteff_frm.Text = grdDetail.SelectedRow.Cells[6].Text;
        txteff_to.Text = grdDetail.SelectedRow.Cells[7].Text;    
        lbcodeid.Visible = true;
        lblSrCode.Visible = true;
    }

    private  void bindgrid()
    {
        sql = "Jct_Payroll_Components_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ComponentType", SqlDbType.VarChar, 20).Value = ddlAlloawanceType.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
    private void cleartextboxes()
    {
        txtdesc.Text = "";
        txtshortdesc.Text = "";
        txteff_frm.Text = "";
        txteff_to.Text = "";
        lbcodeid.Visible = false;
        lblSrCode.Visible = false;
    
    }
    protected void ddlAlloawanceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
}