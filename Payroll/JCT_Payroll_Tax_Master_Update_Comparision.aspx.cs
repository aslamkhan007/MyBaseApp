using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_JCT_Payroll_Tax_Master_Update_Comparision : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();

        }
    }

    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_SalaryCal_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodate.Text = dr["ToDate"].ToString();
                txttodates.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
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




    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            // sql = "jct_payroll_attendence_data_fetch_sh";
            //sql = "jct_pay_days_cal_shweta";
            sql = "JCT_Payroll_Salary_Tax_Compersion";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@FromYearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@ToYearMonth", SqlDbType.Int).Value = txttodates.Text;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
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


    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_Tax_Master_Update_Comparision.aspx");
    }



    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtype.SelectedItem.Value == "Tax Salary Details")
        {
            Response.Redirect("JCT_Payroll_Tax_Master_Update.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Comparision")
        {
            Response.Redirect("JCT_Payroll_Tax_Master_Update_Comparision.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "HRA Affidavit")
        {
            Response.Redirect("Jct_Payroll_TaxHra_Exemption.aspx");
        }

    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }
}