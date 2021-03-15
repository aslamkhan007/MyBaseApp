using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_Current_budget_vs_Indent : System.Web.UI.Page
{
    Connection obj = new Connection();
    SqlConnection con = new SqlConnection("Data Source=miserp;Initial Catalog=POMDB;User ID= itgrp;Password= power");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindlocation();
        }

    }


    protected void lnkbtnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = true;
            //string qry = ConfigurationManager.ConnectionStrings["testerp"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "jct_balance_budget_vs_indents";
            SqlCommand cmd = new SqlCommand(strqry, con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dept", SqlDbType.VarChar,50).Value = DropDownList1.SelectedItem.Text.Split('-')[0].ToString();
            cmd.Parameters.Add("@group", SqlDbType.VarChar, 15).Value = DropDownList1.SelectedItem.Text.Split('-')[1].ToString();
            //cmd.ExecuteNonQuery();                       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandTimeout = 1000000;
             
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grdfreezedate.DataSource = ds;
            Grdfreezedate.DataBind();
            con.Close();   
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    public void bindlocation()
    {

        //sql = "Jct_Asset_Furdetail_Sublocation_Fetch";
        string sql = "jct_budget_department";
        SqlCommand cmd = new SqlCommand(sql, con);
        con.Open();
        //SqlCommand cmd = new SqlCommand("SELECT  location  FROM dbo.jct_asset_location_master where status='A' AND main_location ='" + ddlloc.SelectedItem.Text + "' ORDER BY LEFT(location,1)", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "group";
        DropDownList1.DataValueField = "group";
        DropDownList1.DataBind();
        con.Close();
    }
    protected void lnkbtnexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", Grdfreezedate);
    }
}