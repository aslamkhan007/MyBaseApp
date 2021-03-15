using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_payroll_Trust_Report : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
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
            }
            dr.Close();
        }
    }


    //public void Locationbind()
    //{
    //    SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
    //    sqlCmd.CommandType = CommandType.Text;
    //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlLocation.DataSource = ds;
    //    ddlLocation.DataTextField = "Location_description";
    //    ddlLocation.DataValueField = "Location_code";
    //    ddlLocation.DataBind();
    //}


    protected void lnkfetch_Click(object sender, EventArgs e)
    {

        if (ddlcat.SelectedItem.Text == "Refundable Loan")
        {

            try
            {

                grdDetail.DataSource = null;
                grdDetail.DataBind();
                // sql = "jct_payroll_attendence_data_fetch_sh";
                //sql = "jct_pay_days_cal_shweta";
                sql = "JCT_Payroll_Trust_RefLoan";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Text;
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

        if (ddlcat.SelectedItem.Text == "NonRefundable Loan")
        {

            try
            {

                grdDetail.DataSource = null;
                grdDetail.DataBind();
                // sql = "jct_payroll_attendence_data_fetch_sh";
                //sql = "jct_pay_days_cal_shweta";
                sql = "JCT_Payroll_Trust_NonRefLoan";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Text;
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
        Response.Redirect("Jct_Payroll_Attendence_Report.aspx");
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }
}