using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_Jct_Payroll_Upload_WorkerPfPortal : System.Web.UI.Page
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
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' and plant_code <> 'pln-100' ORDER BY plant_code", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Upload_WorkerPfPortal.aspx");
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
        string qry = ConfigurationManager.ConnectionStrings["misupload"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string SqlPass = null;

        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_payroll_XL_DB_Upload_Data_WorkerPFportal";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@MonthRemarks", SqlDbType.VarChar, 17).Value = txtOtherRequest.Text;
        //Cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

        Cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Data Successfully Uploaded .!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}