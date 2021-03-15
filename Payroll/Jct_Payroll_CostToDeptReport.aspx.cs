using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_CostToDeptReport : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //AttendenceDate();
            Plantbind();

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




    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            // sql = "jct_payroll_attendence_data_fetch_sh";
            //sql = "jct_pay_days_cal_shweta";
            sql = "JCt_HR_Department_Cost";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@ReportType", SqlDbType.VarChar, 20).Value = ddlplant0.SelectedItem.Value;            
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


    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_CostToDeptReport.aspx");
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }
}