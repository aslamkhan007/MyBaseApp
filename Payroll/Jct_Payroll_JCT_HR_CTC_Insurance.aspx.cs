using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_Jct_Payroll_JCT_HR_CTC_Insurance : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Plantbind();
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

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("Jct_Payroll_JCT_HR_CTC_Insurance_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;

            //cmd.Parameters.Add("@NewEmployeeCode", SqlDbType.VarChar, 10).Value = txtSapcode.Text;

            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtemployeecode.Text;

            cmd.Parameters.Add("@E_GME", SqlDbType.Decimal).Value = txtGME.Text;

            cmd.Parameters.Add("@E_GPA", SqlDbType.Decimal).Value = txtGPA.Text;

            cmd.Parameters.Add("@E_GroupTermPolicy", SqlDbType.Decimal).Value = txtGrouppolicy.Text;

            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 15).Value = (Session["Empcode"]);

            cmd.ExecuteNonQuery();
            string script = "alert('Record Saved .!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            con.Close();
            clearcontrols();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_JCT_HR_CTC_Insurance.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }


    protected void txtSapcode_TextChanged(object sender, EventArgs e)
    {
       
       
    }

    public void searchcode()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string empcode = txtemployeecode.Text;
        SqlCommand cmd = new SqlCommand("Jct_Payroll_JCT_HR_CTC_Insurance_FetchName", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = empcode;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                lbemployeename.Text = dr["EmployeeName"].ToString();
            }
        }
        else
        {
            clearcontrols();
            string script = "alert('Record Not Found.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        dr.Close();
        con.Close();
    }

    public void clearcontrols()
    {
        txtemployeecode.Text = "";
        txtGME.Text = "";
        txtGPA.Text = "";
        txtGrouppolicy.Text = "";
        //txtSapcode.Text = "";   
        lbemployeename.Text = "";
    }
    protected void lnkreset0_Click(object sender, EventArgs e)
    {
       
        
    }
    protected void lnkreset0_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_JCT_HR_CTC_Insurance_Report.aspx");
    }
    protected void txtemployeecode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            searchcode();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
}