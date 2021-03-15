﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_IncomeTaxReturn_ChallanDeductDetail : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //ExgratiaDate();
            PlantList();
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

    protected void ddlReporttypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        visibleExtra();
    }

    public void visibleExtra()
    {

        if ((ddlReporttypes.SelectedItem.Text == "FileBatch"))
        {
            Response.Redirect("Jct_Payroll_IncomeTaxReturn_FileBatchHeader.aspx");
        }

        else if ((ddlReporttypes.SelectedItem.Text == "ChallanDed"))
        {
            Response.Redirect("Jct_Payroll_IncomeTaxReturn_ChallanDeductDetail.aspx");
        }

        else if ((ddlReporttypes.SelectedItem.Text == "Annexture"))
        {
            Response.Redirect("Jct_Payroll_IncomeTaxReturn_Annexture.aspx");
        }

        else if ((ddlReporttypes.SelectedItem.Text == "TaxReturn"))
        {
            Response.Redirect("Jct_Payroll_IncomeTaxReturn_TaxReturn.aspx");
        }

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
        Response.Redirect("Jct_Payroll_IncomeTaxReturn_ChallanDeductDetail.aspx");
    }
    private void bindgrid()
    {
        sql = "JCT_Payroll_Tax_Return_FileHeader_BatchHeader";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txtMonth.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        //cmd.Parameters.Add("@ChallanRunningNo", SqlDbType.notepadVarChar, 2).Value = ddlRecordNo.SelectedItem.Value;

        cmd.Parameters.Add("@ChallanRunningNo", SqlDbType.VarChar, 2).Value = txtRecordNo.Text; 
        cmd.Parameters.Add("@ChallanSrNo", SqlDbType.Int).Value = txtChallanSrNo.Text;
        cmd.Parameters.Add("@BranchCode", SqlDbType.VarChar, 7).Value = txtBranchCode.Text;
        cmd.Parameters.Add("@ChallanDt", SqlDbType.DateTime).Value = txtChallanDate.Text;
        cmd.Parameters.Add("@LateFee", SqlDbType.Decimal, 2).Value = txtLateFee.Text;

        SqlDataReader abc = new SqlDataReader();

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
                //txtMonth.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

   
}