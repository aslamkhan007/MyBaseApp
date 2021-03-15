using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

public partial class PayRoll_Payroll_attendence_data : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();            
            Locationbind();
        }
    }

    public void AttendenceDate()
    {        
        DateTime origDT = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        origDT = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(-1);
        txtfromdate.Text = Convert.ToDateTime(origDT).ToShortDateString();
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txttodate_CalendarExtender.SelectedDate = lastDate;
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

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {
            // sql = "jct_payroll_attendence_data_fetch_sh";
            //sql = "jct_pay_days_cal_shweta";
            sql = "jct_Payroll_PayDays_Autocal_Fetch";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtfromdate.Text;
            cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = txttodate.Text;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {

        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    //protected void chkall_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox chkall = (CheckBox)grdDetail.HeaderRow.FindControl("chkall");

    //    foreach (GridViewRow row in grdDetail.Rows)
    //    {
    //        CheckBox cb = (CheckBox)row.FindControl("chk");

    //        if (cb != null)
    //        {

    //            if (chkall.Checked)
    //            {
    //                cb.Checked = true;
    //            }
    //            else
    //            {
    //                cb.Checked = false;
    //            }
    //        }
    //    }
    //}

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Manualentry_Attandence.aspx");

    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[9].Text == "32.00".ToString())
            {
                e.Row.BackColor = Color.Cyan;
            }
        }
    }

    protected void txtfromdate_TextChanged(object sender, EventArgs e)
    {
        DateTime origDT = Convert.ToDateTime(txtfromdate.Text);
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txttodate_CalendarExtender.SelectedDate = lastDate;
    }

    //protected void lnkSalarySheet_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("CrystalView.aspx");
    //}
    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            // sql = "jct_payroll_attendence_data_fetch_sh";
            //sql = "jct_pay_days_cal_shweta";
            sql = "jct_Payroll_PayDays_Autocal_Fetch_Freeze";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtfromdate.Text;
            cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = txttodate.Text;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.ExecuteNonQuery();                
        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_attendence_data.aspx");
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();        
    }
}