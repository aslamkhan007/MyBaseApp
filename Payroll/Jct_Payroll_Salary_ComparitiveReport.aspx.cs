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

public partial class Payroll_Jct_Payroll_Salary_ComparitiveReport : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();
            Locationbind();
            Departmentbind();
        }
    }

    public void Departmentbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT 'All' as DepartmentCode,'All' as Department_long_Description union SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by Department_long_Description", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.Items.Clear();
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "Department_long_Description";
        ddldepartment.DataValueField = "DepartmentCode";
        ddldepartment.DataBind();
        con.Close();
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

    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddllocation.DataSource = ds;
        ddllocation.DataTextField = "Location_description";
        ddllocation.DataValueField = "Location_code";
        ddllocation.DataBind();
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        try
        {
            sql = "Jct_Payroll_Comparitive_Salary_Variation";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            if (txtEmployee.Text != "")
            {
                string employeecode = txtEmployee.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 12).Value = employeecode;
            }
            else
            {
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 12).Value = "All";
            }
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Loc", SqlDbType.VarChar, 15).Value = ddllocation.SelectedItem.Value;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50).Value = ddldepartment.SelectedItem.Value;
            cmd.Parameters.Add("@Diffflag", SqlDbType.VarChar, 20).Value = ddldepartment0.SelectedItem.Value; 
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            con.Close();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
        finally
        {
            con.Close();
        }
    }

    public void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    //public void SalaryTally()
    //{
    //    try
    //    {
    //        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
    //        SqlConnection con = new SqlConnection(qry);
    //        con.Open();
    //        sql = "SalaryCheck";
    //        SqlCommand cmd = new SqlCommand(sql, con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandTimeout = 0;
    //        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
    //        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
    //        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
    //        cmd.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        grdDetail.DataSource = ds.Tables[0];
    //        grdDetail.DataBind();
    //        Panel1.Visible = true;
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        string script2 = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
    //        return;
    //    }
    //}

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Salary_ComparitiveReport.aspx");
    }
}