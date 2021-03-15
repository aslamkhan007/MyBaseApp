using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_JCT_Payroll_Worker_Portal_PF : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string loantype;
    string eleccode;

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

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_Worker_Portal_PF.aspx");
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        try
        {
            Attendance();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    public void Attendance()
    {
        string sql = "JCT_Payroll_Worker_Portal_PF";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@MonthRemarks", SqlDbType.VarChar, 17).Value = txtOtherRequest.Text;
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

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
}