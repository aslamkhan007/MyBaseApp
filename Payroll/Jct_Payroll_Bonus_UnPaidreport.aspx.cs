using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_Jct_Payroll_Bonus_UnPaidreport : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Plantbind();
            Locationbind();
            AttendenceDates();
        }
    }

    public void AttendenceDates()
    {
        string sqlqry = "Jct_Payroll_Current_FIYear";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodates.Text = dr["FIYear"].ToString();
            }
            dr.Close();
        }
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

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Bonus_UnPaidreport.aspx");
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        sql = "Jct_Payroll_Bonus_Left_Report";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@FyPd", SqlDbType.VarChar, 10).Value = txttodates.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@user", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        else
        {
            grdDetail.DataSource = ds;
            grdDetail.DataBind();
            Panel1.Visible = true;
        }
        con.Close();
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }

    protected void ddlLocation_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}