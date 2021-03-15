using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_Overtime_Bank_Advice_Issue : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //PlantList();
        //LocationList();

        if (!IsPostBack)
        {
            Plantbind();
            Locationbind();
            BankList();

            ExgratiaDate();
        }
    }


    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Overtime_Bank_Advice_Issue.aspx");
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Overtime_BankAdvice.aspx?PlantCode=" + ddlplant.SelectedItem.Value + "&BankCode=" + ddlbank.SelectedItem.Value + "&LocationCode=" + ddlLocation.SelectedItem.Value + "&YearMonth=" + txtMonth.Text);
    }
    protected void LnkExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
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
    private void bindgrid()
    {
        sql = "Jct_Payroll_Overtime_BankAdvice_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PlantCode", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
         cmd.Parameters.Add("@YearMonth", SqlDbType.VarChar, 10).Value = txtMonth.Text;
        cmd.Parameters.Add("@BankCode", SqlDbType.VarChar, 10).Value = ddlbank.SelectedItem.Value;
        cmd.Parameters.Add("@LocationCode", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;

        LnkExcel.Enabled = true;
    }
    //private void PlantList()
    //{
    //    sql = "Jct_Payroll_Plantlist_Fetch";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlplant.DataSource = ds;
    //    ddlplant.DataTextField = "LongDescription";
    //    ddlplant.DataValueField = "PlantCode";
    //    ddlplant.DataBind();
    //}
    private void BankList()
    {
        sql = "Jct_Payroll_Banklist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@plant_code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@location_code", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbank.DataSource = ds;
        ddlbank.DataTextField = "Description";
        ddlbank.DataValueField = "BankCode";
        ddlbank.DataBind();
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
    //    private void LocationList()
    //{
    //    sql = "Jct_Payroll_Locationlist_Fetch";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@plant_code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlLocation.DataSource = ds;
    //    ddlLocation.DataTextField = "LocationDescription";
    //    ddlLocation.DataValueField = "LocationCode";
    //    ddlLocation.DataBind();
    //}
        protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
        {
            Locationbind();
            BankList();
        }
        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankList();
        }
}