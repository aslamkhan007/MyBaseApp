using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_PortalLeaveReports : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            PlantList();            
        }

    }
    protected void txtefffrm_TextChanged(object sender, EventArgs e)
    {
        //DateTime origDT = Convert.ToDateTime(txtefffrm.Text);
        //DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        //txteffto_CalendarExtender.SelectedDate = lastDate;
    }
    private void PlantList()
    {
        string sql = "Jct_Payroll_Plantlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "LongDescription";
        ddlplant.DataValueField = "PlantCode";
        ddlplant.DataBind();

    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_Payroll_Portal_Leave_Report";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);

            cmd.Parameters.Add("@AuthFromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TextBox1.Text);
            cmd.Parameters.Add("@AuthToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TextBox2.Text);

            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlStatus.SelectedItem.Value;
            cmd.Parameters.Add("@LeaveNature", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value; 
            cmd.Parameters.Add("@EmployeeCode ", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            //cmd.Parameters.Add("@EmployeeCode ", SqlDbType.VarChar, 30).Value = "9000000040";
            cmd.ExecuteNonQuery();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            //if( a == 1)
            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }

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


    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("PortalLeaveReports.aspx");
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddldedtype.SelectedItem.Value == "Leave")
        //{
        //    Response.Redirect("PortalLeaveReports.aspx");
        //}

        //if (ddldedtype.SelectedItem.Value == "EarnedLeave")
        //{
        //    Response.Redirect("PortalCoLeaveReports.aspx");
        //}
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Value == "Leave")
        {
            Response.Redirect("PortalLeaveReports.aspx");
        }

        if (DropDownList1.SelectedItem.Value == "EarnedLeave")
        {
            Response.Redirect("PortalCoLeaveReports.aspx");
        }
    }
}