using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_fur_new_report : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    string empcode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SqlCommand cmd = new SqlCommand("SELECT distinct  main_location as location FROM dbo.jct_asset_location_master WHERE STATUS='A' AND module_usedby='GEN'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds1 = new DataSet();
            ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(ds1);
            ddlloc.DataSource = ds1;
            ddlloc.DataTextField = "location";
            ddlloc.DataBind();


            cmd = new SqlCommand("  SELECT '' as location  UNION SELECT  location  FROM dbo.jct_asset_location_master where status='A' AND main_location ='" + ddlloc.SelectedItem.Text + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ddlsublocation.DataSource = ds;
            ddlsublocation.DataTextField = "location";
            ddlsublocation.DataBind();
        }

    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {

            if (!string.IsNullOrEmpty(txtEmpCode.Text))
            {
                SqlCommand cmd = new SqlCommand("jct_asset_fur_history_report", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;

                if (txtEmpCode.Text.Contains('|'))
                {
                    if (ddlloc.SelectedItem.Text == "Company Items")
                    {
                        empcode = txtEmpCode.Text.Split('|')[0].ToString();
                        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode;
                        cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
                        if (ddlsublocation.SelectedItem.Text != string.Empty)
                        {
                            cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 30).Value = ddlsublocation.SelectedItem.Text;
                        }
                    }

                    else
                    {
                        empcode = txtEmpCode.Text.Split('|')[1].ToString();
                        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
                        cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
                        cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 30).Value = ddlsublocation.SelectedItem.Text;

                    }

                    //cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 50).Value = "";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    grdDetail.DataSource = ds;
                    grdDetail.DataBind();

                }
            }


            else
            {

                SqlCommand cmd = new SqlCommand("jct_asset_fur_history_report", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = txtEmpCode.Text;
                cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
                //if (ddlsublocation.SelectedItem.Text != string.Empty)
                //{
                cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 30).Value = ddlsublocation.SelectedItem.Text;

                // }


                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                grdDetail.DataSource = ds;
                grdDetail.DataBind();
            }

        }

        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }


    protected void ddlloc_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand(" SELECT '' as location  UNION SELECT  location  FROM dbo.jct_asset_location_master where status='A' AND main_location ='" + ddlloc.SelectedItem.Text + "'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlsublocation.DataSource = ds;
        ddlsublocation.DataTextField = "location";

        ddlsublocation.DataBind();

    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
        //if (!string.IsNullOrEmpty(txtEmpCode.Text))
        //{
        //    SqlCommand cmd = new SqlCommand("jct_asset_fur_history_report", obj.Connection());
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    if (txtEmpCode.Text.Contains('|'))
        //    {
        //        if (ddlloc.SelectedItem.Text == "Company Items")
        //        {
        //            empcode = txtEmpCode.Text.Split('|')[0].ToString();
        //            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode;
        //            cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
        //            if (ddlsublocation.SelectedItem.Text != string.Empty)
        //            {
        //                cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 30).Value = ddlsublocation.SelectedItem.Text;
        //            }
        //        }

        //        else
        //        {
        //            empcode = txtEmpCode.Text.Split('|')[1].ToString();
        //            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
        //            cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
        //            cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 30).Value = ddlsublocation.SelectedItem.Text;

        //        }

        //        //cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 50).Value = "";
        //        cmd.ExecuteNonQuery();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);

        //        grdDetail.DataSource = ds;
        //        grdDetail.DataBind();



        //        //GridViewExportUtil.Export("XL.xls", grdDetail);

        //        DataTable dt = ds.Tables[0];
        //        string attachment = "attachment; jct_asset_fur_history_report.xls";
        //        Response.ClearContent();
        //        Response.AddHeader("content-disposition", attachment);
        //        Response.ContentType = "application/vnd.ms-excel";
        //        string tab = "";
        //        foreach (DataColumn dc in dt.Columns)
        //        {
        //            Response.Write(tab + dc.ColumnName);
        //            tab = "\t";
        //        }
        //        Response.Write("\n");
        //        int i;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            tab = "";
        //            for (i = 0; i < dt.Columns.Count; i++)
        //            {
        //                Response.Write(tab + dr[i].ToString());
        //                tab = "\t";
        //            }
        //            Response.Write("\n");
        //        }
        //        Response.End();


        //    }
        //}


        //    else
        //    {

        //        SqlCommand cmd = new SqlCommand("jct_asset_fur_history_report", obj.Connection());
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = txtEmpCode.Text;
        //        cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
        //        if (ddlsublocation.SelectedItem.Text != string.Empty)
        //        {
        //            cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 30).Value = ddlsublocation.SelectedItem.Text;
        //        }
        //        cmd.ExecuteNonQuery();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);

        //        grdDetail.DataSource = ds;
        //        grdDetail.DataBind();

        //        //GridViewExportUtil.Export("XL.xls", grdDetail);
        //        DataTable dt = ds.Tables[0];
        //        string attachment = "attachment; jct_asset_fur_history_report.xls";
        //        Response.ClearContent();
        //        Response.AddHeader("content-disposition", attachment);
        //        Response.ContentType = "application/vnd.ms-excel";
        //        string tab = "";
        //        foreach (DataColumn dc in dt.Columns)
        //        {
        //            Response.Write(tab + dc.ColumnName);
        //            tab = "\t";
        //        }
        //        Response.Write("\n");
        //        int i;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            tab = "";
        //            for (i = 0; i < dt.Columns.Count; i++)
        //            {
        //                Response.Write(tab + dr[i].ToString());
        //                tab = "\t";
        //            }
        //            Response.Write("\n");
        //        }
        //        Response.End();


        //    }




        }

    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
  
}