using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_Bonus_RateMaster : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            bindgrid();            
        }
    }

    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Current_FIYear";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txtfypd.Text = dr["FIYear"].ToString();
            }
            dr.Close();
        }
    }
   
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Jct_Payroll_Bonus_Rate_Insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FyPeriod", SqlDbType.VarChar, 10).Value = txtfypd.Text;
            cmd.Parameters.Add("@FromYearMonth", SqlDbType.Int).Value = txtFromPeriod.Text;
            cmd.Parameters.Add("@ToYearMonth", SqlDbType.Int).Value = txtToPeriod.Text;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar, 40).Value = ddlCategory.SelectedItem.Value;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal, 10).Value = txtrate.Text;
            cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];            
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  Saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextboxes();
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
            sql = "Jct_Payroll_Bonus_Rate_Update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FyPeriod", SqlDbType.VarChar, 10).Value = txtfypd.Text;
            cmd.Parameters.Add("@FromYearMonth", SqlDbType.Int).Value = txtFromPeriod.Text;
            cmd.Parameters.Add("@ToYearMonth", SqlDbType.Int).Value = txtToPeriod.Text;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar, 40).Value = ddlCategory.SelectedItem.Value;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal, 10).Value = txtrate.Text;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];       
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  Updated.!!');";
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
        Response.Redirect("Jct_Payroll_Bonus_RateMaster.aspx");
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lbcodeid.Text = grdDetail.SelectedRow.Cells[1].Text;
        //txtfypd.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[1].Text);
        txtfypd.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        txtFromPeriod.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[2].Text);
        txtToPeriod.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[3].Text);
        ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(grdDetail.SelectedRow.Cells[4].Text));
        txtrate.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[5].Text);        
        //txtshortdesc.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[3].Text);
        //ddlAlloawanceType.SelectedIndex = ddlAlloawanceType.Items.IndexOf(ddlAlloawanceType.Items.FindByText(grdDetail.SelectedRow.Cells[4].Text));
        //ddlComponentNature.SelectedIndex = ddlComponentNature.Items.IndexOf(ddlComponentNature.Items.FindByText(grdDetail.SelectedRow.Cells[5].Text));
        //txteff_frm.Text = grdDetail.SelectedRow.Cells[6].Text;
        //txteff_to.Text = grdDetail.SelectedRow.Cells[7].Text;
        //lbcodeid.Visible = true;
        //lblSrCode.Visible = true;
    }

    private void bindgrid()
    {
        sql = "Jct_Payroll_Bonus_Rate_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@ComponentType", SqlDbType.VarChar, 20).Value = ddlAlloawanceType.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    private void cleartextboxes()
    {
        txtfypd.Text = "";
        txtFromPeriod.Text = "";
        txtToPeriod.Text = "";
        txtrate.Text = "";       
    }
    protected void ddlAlloawanceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }

}