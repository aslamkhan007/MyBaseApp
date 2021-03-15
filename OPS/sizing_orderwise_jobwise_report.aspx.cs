using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class OPS_Sizing_Orderwise_Jobwise_report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void lnkBtnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            string constring = "Data Source=misdev;Initial Catalog=production;User ID=itgrp;Password=power";
            SqlConnection con = new SqlConnection(constring);
            con.Open();            
            string fromdate = txtFromDate.Text;
            string todate = txtToDate.Text;
            string sortno = txtSortNo.Text;
            string orderno = txtOrderNo.Text;
            DateTime a = Convert.ToDateTime(fromdate);
            DateTime b = Convert.ToDateTime(todate);
            if (a > b)
            {
                string script = "alert('FROM DATE cannot be greater than TO DATE');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                grdjobwisereport.Visible = false;
                grdorderwisereport.Visible = false;
            }
            else if (sortno != string.Empty)
            {
                string strqry = "jct_ops_sizing_jobwise_report";
                SqlCommand cmd = new SqlCommand(strqry, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = Convert.ToDateTime(fromdate);
                cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = Convert.ToDateTime(todate);
                cmd.Parameters.Add("@sortno", SqlDbType.Int).Value = Convert.ToInt32(sortno);
                cmd.Parameters.Add("@orderno", SqlDbType.VarChar).Value = orderno;
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                grdjobwisereport.DataSource = ds;
                grdjobwisereport.DataBind();
                grdjobwisereport.Visible = true;
                grdorderwisereport.Visible = true;
                string strqry1 = "jct_ops_sizing_orderwise_report";
                cmd = new SqlCommand(strqry1, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = Convert.ToDateTime(fromdate);
                cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = Convert.ToDateTime(todate);
                cmd.Parameters.Add("@sortno", SqlDbType.Int).Value = Convert.ToInt32(sortno);
                cmd.Parameters.Add("@orderno", SqlDbType.VarChar).Value = orderno;
                cmd.ExecuteNonQuery();
                adp = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adp.Fill(ds);
                grdorderwisereport.DataSource = ds;
                grdorderwisereport.DataBind();
                grdjobwisereport.Visible = true;
                grdorderwisereport.Visible = true;
            }

            else if (sortno == string.Empty)
            {
                string strqry = "jct_ops_sizing_jobwise_report";
                SqlCommand cmd = new SqlCommand(strqry, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = Convert.ToDateTime(fromdate);
                cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = Convert.ToDateTime(todate);
                cmd.Parameters.Add("@sortno", SqlDbType.VarChar).Value = (sortno);
                cmd.Parameters.Add("@orderno", SqlDbType.VarChar).Value = orderno;
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                grdjobwisereport.DataSource = ds;
                grdjobwisereport.DataBind();
                grdjobwisereport.Visible = true;
                grdorderwisereport.Visible = true;
                string strqry1 = "jct_ops_sizing_orderwise_report";
                cmd = new SqlCommand(strqry1, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = Convert.ToDateTime(fromdate);
                cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = Convert.ToDateTime(todate);
                cmd.Parameters.Add("@sortno", SqlDbType.VarChar).Value = (sortno);
                cmd.Parameters.Add("@orderno", SqlDbType.VarChar).Value = orderno;
                cmd.ExecuteNonQuery();
                adp = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adp.Fill(ds);
                grdorderwisereport.DataSource = ds;
                grdorderwisereport.DataBind();
                grdjobwisereport.Visible = true;
                grdorderwisereport.Visible = true;
            }
            con.Close();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
}