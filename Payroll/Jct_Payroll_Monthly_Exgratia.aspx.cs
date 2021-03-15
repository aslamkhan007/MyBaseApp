using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_Monthly_Exgratia : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            ExgratiaDate();
            PlantList();
            Locationbind();
        }
    }
    private void PlantList()
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
        //lnkexcel.Enabled = true;
        bindgrid();
    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Monthly_Exgratia.aspx");
    }
    private void bindgrid()
    {
        if (ddlReporttype.SelectedItem.Text == "Summary")
        {
            sql = "Jct_Payroll_MonthlyExgratia_Fetch_Wage";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReportType", SqlDbType.VarChar, 10).Value = ddlReporttype.SelectedItem.Text;
            cmd.Parameters.Add("@YearMonth", SqlDbType.VarChar, 10).Value = txtMonth.Text;
            cmd.Parameters.Add("@PlantCode", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                Panel1.Visible = true;
            }
            else
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
        }
        if (ddlReporttype.SelectedItem.Text == "Detail")
        {
            sql = "Jct_Payroll_MonthlyExgratia_Fetch_Wage";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReportType", SqlDbType.VarChar, 10).Value = ddlReporttype.SelectedItem.Text;
            cmd.Parameters.Add("@YearMonth", SqlDbType.VarChar, 10).Value = txtMonth.Text;
            cmd.Parameters.Add("@PlantCode", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                Panel1.Visible = true;
            }
            else
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }

        }

        if (ddlReporttype.SelectedItem.Text == "CashPayment")
        {
            sql = "Jct_Payroll_MonthlyExgratia_Fetch_Wage";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReportType", SqlDbType.VarChar, 10).Value = ddlReporttype.SelectedItem.Text;
            cmd.Parameters.Add("@YearMonth", SqlDbType.VarChar, 10).Value = txtMonth.Text;
            cmd.Parameters.Add("@PlantCode", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                Panel1.Visible = true;
            }
            else
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
                        
        }
    }
    public void ExgratiaDate()
    {
        string sqlqry = "Jct_Payroll_SalaryCal_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txtMonth.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
    protected void ddlReporttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlReporttype.SelectedItem.Text == "Summary")
        //    Response.Redirect("Jct_Payroll_DepartmentWise_Overtime.aspx");
        //else if (ddlReporttype.SelectedItem.Text == "Detail")
        //    Response.Redirect("Jct_Payroll_Monthly_Exgratia.aspx");
        //else if (ddlReporttype.SelectedItem.Text == "CashPayment")
        //    Response.Redirect("Jct_Payroll_Monthly_Exgratia.aspx");
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }
}