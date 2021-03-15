using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Payroll_Jct_Payroll_Skill_Detail : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TechnologyList();
            SkillList();
        } 
    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Skill_Detail_Insert ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@Skill", SqlDbType.VarChar, 10).Value = ddlskill.SelectedItem.Value;
            cmd.Parameters.Add("@Technology", SqlDbType.VarChar, 10).Value = ddlTechnology.SelectedItem.Value;
            cmd.Parameters.Add("@ExpYrs", SqlDbType.Int).Value = TxtExpYears.Text;
            cmd.Parameters.Add("@ExpMnths", SqlDbType.Int).Value = TxtExpMonths.Text;
            cmd.Parameters.Add("@LastUsed", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtLastUsed.Text);
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 80).Value = TxtRemarks.Text;
            cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record saved.!!');";
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
            string sql = "Jct_Payroll_Skill_Detail_Update ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@Skill", SqlDbType.VarChar, 10).Value = ddlskill.SelectedItem.Value;
            cmd.Parameters.Add("@Technology", SqlDbType.VarChar, 10).Value = ddlTechnology.SelectedItem.Value;
            cmd.Parameters.Add("@ExpYrs", SqlDbType.Int).Value = TxtExpYears.Text;
            cmd.Parameters.Add("@ExpMnths", SqlDbType.Int).Value = TxtExpMonths.Text;
            cmd.Parameters.Add("@LastUsed", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtLastUsed.Text);
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 80).Value = TxtRemarks.Text;
            cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Skill_Detail_Delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 7).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record deleted.!!');";
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
        Response.Redirect("Jct_Payroll_Skill_Detail.aspx");
    }
    private void SkillList()
    {
        sql = "Jct_Payroll_Skill_List";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlskill.DataSource = ds;
        ddlskill.DataTextField = "LongDescription";
        ddlskill.DataValueField = "Skill_Code";
        ddlskill.DataBind();
    }
    private void TechnologyList()
    {
        sql = "Jct_Payroll_Technology_List";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlTechnology.DataSource = ds;
        ddlTechnology.DataTextField = "LongDescription";
        ddlTechnology.DataValueField = "Tech_Code";
        ddlTechnology.DataBind();
    }
    private void bindgrid()
    {
        sql = "Jct_Payroll_Skill_Details_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
    private void ClearTextBoxes()
    {
        txtEmpCode.Text = "";
        TxtLastUsed.Text = "";
        TxtRemarks.Text = "";
        ddlskill.ClearSelection();
        ddlTechnology.ClearSelection();
        TxtExpYears.Text = "";
        TxtExpMonths.Text = "";
        SrCode.Visible = false;
        SrId.Visible = false;
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        SrCode.Visible = true;
        SrId.Visible = true;
        SrId.Text = grdDetail.SelectedRow.Cells[1].Text;
        txtEmpCode.Text = grdDetail.SelectedRow.Cells[2].Text;
        ddlskill.SelectedIndex = ddlskill.Items.IndexOf(ddlskill.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text));
        ddlTechnology.SelectedIndex = ddlTechnology.Items.IndexOf(ddlTechnology.Items.FindByText(grdDetail.SelectedRow.Cells[4].Text));
        TxtExpYears.Text = grdDetail.SelectedRow.Cells[5].Text;
        TxtExpMonths.Text = grdDetail.SelectedRow.Cells[6].Text;
        TxtLastUsed.Text = grdDetail.SelectedRow.Cells[7].Text;
        TxtRemarks.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[8].Text);
        lnkupdate.Enabled = true;

    }
    protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
}