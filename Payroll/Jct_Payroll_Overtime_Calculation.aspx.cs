using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Payroll_Jct_Payroll_Overtime_Calculation : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();                            
        }

    }

  
    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Reimbursement_Attendence_Month";
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


    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }
   
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Overtime_Hrs_Calculate_Wage";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;            
            cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }

            string scripts = "alert('Calculation Completed');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", scripts, true);
            return;

        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }  

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Overtime_Calculation.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Overtime_Hrs_Calculate_Freeze_Wage";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
            cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            string scripts = "alert('Calculation Freezed');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", scripts, true);
            return;
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }
}