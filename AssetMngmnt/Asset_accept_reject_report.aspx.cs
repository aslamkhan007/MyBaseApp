using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class AssetMngmnt_Asset_accept_reject_report : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGetUsers();
        }
    }

    public void BindGetUsers()
    {
        // earlier Report  procedure : jct_asset_accept_reject_reprt
        string empcodeserc = null;
        SqlCommand cmd = new SqlCommand("Jct_Asset_Aceeptance_Status", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        if (!string.IsNullOrEmpty(txtempname.Text))
        {
            if (txtempname.Text.Contains('|'))
            {
                empcodeserc = txtempname.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@User", SqlDbType.VarChar, 20).Value = empcodeserc.Trim();
                cmd.Parameters.Add("@AuthStatus", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
                cmd.Parameters.Add("@DetailReport", SqlDbType.Char, 1).Value = 'N';
            }
        }
        else
        {
            cmd.Parameters.Add("@User", SqlDbType.VarChar, 20).Value = "All";
            cmd.Parameters.Add("@AuthStatus", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
            cmd.Parameters.Add("@DetailReport", SqlDbType.Char, 1).Value = 'N';
        }

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        sql = "Jct_Asset_Aceeptance_Status";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        string empcodeserc = null;
        if (!string.IsNullOrEmpty(txtempname.Text))
        {
            if (txtempname.Text.Contains('|'))
            {
                empcodeserc = txtempname.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@User", SqlDbType.VarChar, 20).Value = empcodeserc.Trim();
                cmd.Parameters.Add("@AuthStatus", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
                cmd.Parameters.Add("@DetailReport", SqlDbType.Char, 1).Value = 'Y';
            }
        }
        else
        {
            cmd.Parameters.Add("@User", SqlDbType.VarChar, 20).Value = "All";
            cmd.Parameters.Add("@AuthStatus", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
            cmd.Parameters.Add("@DetailReport", SqlDbType.Char, 1).Value = 'Y';
        }

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();


    }
    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string empcodeserc = null;

        sql = "Jct_Asset_Aceeptance_Status";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;



        if (!string.IsNullOrEmpty(txtempname.Text))
        {
            if (txtempname.Text.Contains('|'))
            {
                empcodeserc = txtempname.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@User", SqlDbType.VarChar, 20).Value = empcodeserc.Trim();
                cmd.Parameters.Add("@AuthStatus", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
                cmd.Parameters.Add("@DetailReport", SqlDbType.Char, 1).Value = 'N';
            }
        }
        else
        {
            cmd.Parameters.Add("@User", SqlDbType.VarChar, 20).Value = "All";
            cmd.Parameters.Add("@AuthStatus", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
            cmd.Parameters.Add("@DetailReport", SqlDbType.Char, 1).Value = 'N';
        }


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();


        DataTable dt = ds.Tables[0];
        string attachment = "attachment; Status.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }

        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();


    }
    protected void LinkButton2_Click1(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
}