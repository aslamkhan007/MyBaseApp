using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

public partial class Payroll_Payroll_Change_Plant_Loc : System.Web.UI.Page
{
    string cardno = string.Empty;
    string empcode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cardno = Request.QueryString["cardno"].ToString();
            empcode = Request.QueryString["empcode"].ToString();
            Plantbind();
            Locationbind();
            BindOnLoad();
        }
    }

    public void Plantbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_name,plant_code FROM   jct_payroll_Plant_Master WHERE  STATUS='A'", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "plant_name";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
        con.Close();
    }

    public void Locationbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM   JCT_payroll_location_master WHERE  STATUS='A'", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
        con.Close();
    }

    public void BindOnLoad()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_Plant_Loc_Change_Fetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Savior_CardNo", SqlDbType.VarChar, 20).Value = cardno;
        cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar, 20).Value = empcode;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByValue(dr["Plant"].ToString()));
                ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByValue(dr["Location"].ToString()));
                lblCardNo.Text = dr["Savior_CardNo"].ToString();
                lblEmployeeCode.Text = dr["Employee_Code"].ToString();
                lblName.Text = dr["Employee_Name"].ToString();
            }
        }
        else
        {
            string script = "alert('Record Not Found.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        dr.Close();
        con.Close();


    }

    protected void lnkChange_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("Jct_Payroll_Plant_Loc_Change", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Savior_CardNo", SqlDbType.VarChar, 20).Value = lblCardNo.Text;
            cmd.Parameters.Add("@Employee_Code", SqlDbType.VarChar, 20).Value = lblEmployeeCode.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@hostid", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

            cmd.ExecuteNonQuery();
            string script = "alert('Record Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            con.Close();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    //protected void lnkreset_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Payroll_Change_Plant_Loc.aspx");
    //}
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}