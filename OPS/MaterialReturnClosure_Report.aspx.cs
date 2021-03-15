﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class OPS_MaterialReturnClosure_Report : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    float Sum = 0;
    float Total;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void BindGridIndividual()
    {
        sql = "Jct_Ops_MR_Closure_Fetch_Report";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        if (string.IsNullOrEmpty(txtFrom.Text))
        {
            txtFrom.Text = "";
        }
        else
        {
            cmd.Parameters.Add("@DATEFROM", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
        }
        if (string.IsNullOrEmpty(txtTo.Text))
        {
            txtTo.Text = "";
        }
        else
        {
            cmd.Parameters.Add("@DATETO", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
        }
        
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 15).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = txtSancitonNOte.Text;        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandTimeout = 100000;
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        BindGridIndividual();
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", GridView1);
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaterialReturnClosure_Report.aspx");
    }
}