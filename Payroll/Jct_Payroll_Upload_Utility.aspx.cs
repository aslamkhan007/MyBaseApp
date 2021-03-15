using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Payroll_Jct_Payroll_Upload_Utility : System.Web.UI.Page
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
            Plantbind();
            Locationbind();
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

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Upload_Utility.aspx");
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPaymode.SelectedItem.Text == "Attendance")
            {
                Attendance();
            }
            else
            if (ddlPaymode.SelectedItem.Text == "ElectricityConsumption")
            {
                ElectricityConsumption();
            }
            else
            if (ddlPaymode.SelectedItem.Text == "MessMeal")
            {
                MessMeal();
            }
            else
            if (ddlPaymode.SelectedItem.Text == "MedicineExp")
            {
                MedicineExp();
            }
            else
            if (ddlPaymode.SelectedItem.Text == "IncrementArrear")
            {
                IncrementArrear();
            }

            else
                if (ddlPaymode.SelectedItem.Text == "TaxDeclaration")
                {
                    TaxDeclaration();
                }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


    public void TaxDeclaration()
    {
        string qry = ConfigurationManager.ConnectionStrings["misupload"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_payroll_XL_DB_Upload_Data_TaxDeclaration";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        Cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 15).Value = ddlPaymode.SelectedItem.Text;
        Cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Data Successfully Uploaded .!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }


    public void Attendance()
    {
        string qry = ConfigurationManager.ConnectionStrings["misupload"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_payroll_XL_DB_Upload_Data_Attendance";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        Cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 15).Value = ddlPaymode.SelectedItem.Text; 
        Cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Data Successfully Uploaded .!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    public void ElectricityConsumption()
    {
        string qry = ConfigurationManager.ConnectionStrings["misupload"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_payroll_XL_DB_Upload_Data_Electricity";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        Cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 15).Value = ddlPaymode.SelectedItem.Text; 
        Cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Data Successfully Uploaded .!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    public void MessMeal()
    {
        string qry = ConfigurationManager.ConnectionStrings["misupload"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_payroll_XL_DB_Upload_Data_MessMeal";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        Cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 15).Value = ddlPaymode.SelectedItem.Text; 
        Cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Data Successfully Uploaded .!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    public void MedicineExp()
    {
        string qry = ConfigurationManager.ConnectionStrings["misupload"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_payroll_XL_DB_Upload_Data_MedicineExp";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        Cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 15).Value = ddlPaymode.SelectedItem.Text; 
        Cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Data Successfully Uploaded .!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    public void IncrementArrear()
    {
        string qry = ConfigurationManager.ConnectionStrings["misupload"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_payroll_XL_DB_Upload_Data_Increment";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        Cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 15).Value = ddlPaymode.SelectedItem.Text; 
        Cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Data Successfully Uploaded .!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
   
    protected void lnkreset0_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Upload_Reset.aspx");
    }
    protected void lnkresetatt_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            string SqlPass = null;
            SqlCommand Cmd = new SqlCommand();
            SqlPass = "Jct_Payroll_Upload_Reset";
            Cmd = new SqlCommand(SqlPass, con);
            Cmd.CommandType = CommandType.StoredProcedure;            
            Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddllocation.SelectedItem.Value;
            Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            Cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            Cmd.ExecuteNonQuery();
            con.Close();
            string script = "alert('Data Reset successfull.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }
}