using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Payroll_Arear_Increment_Entry : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Designationbind();
            Plantbind();
            Locationbind();
        }
    }

    public void AttendenceDate()
    {
        DateTime origDT = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        origDT = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(-1);
        txtefffrm.Text = Convert.ToDateTime(origDT).ToShortDateString();
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txteffto_CalendarExtender.SelectedDate = lastDate;
    }

    public void Plantbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "Plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
    }

    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
    }

    public void Designationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Designation_code,Desg_Long_Description FROM JCT_payroll_designation_master WHERE  STATUS='A'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldesignation.DataSource = ds;
        ddldesignation.DataTextField = "Desg_Long_Description";
        ddldesignation.DataValueField = "Designation_code";
        ddldesignation.DataBind();     
    }

    protected void txtefffrm_TextChanged(object sender, EventArgs e)
    {
        DateTime origDT = Convert.ToDateTime(txtefffrm.Text);
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txteffto_CalendarExtender.SelectedDate = lastDate;
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
       
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {           
            SqlCommand cmd = new SqlCommand("jct_payroll_variable_deduction_insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@deduction_type", SqlDbType.VarChar, 10).Value = ddldedtype.SelectedItem.Value;            
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Saved Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtype.SelectedItem.Value == "PayDays")
        {
            Response.Redirect("Payroll_Arear_PayDay_Entry.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Fda")
        {
            Response.Redirect("Payroll_Arear_Fda_Entry.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Increment")
        {
            Response.Redirect("Payroll_Arear_Increment_Entry.aspx");
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Arear_Increment_Entry.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

}