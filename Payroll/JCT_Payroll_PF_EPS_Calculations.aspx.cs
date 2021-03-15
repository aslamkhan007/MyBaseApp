using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Payroll_JCT_Payroll_PF_EPS_Calculations : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

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
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_PF_Contribution_Report.aspx");
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_Payroll_PF_EPS_Calculations";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@yearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddllocation.SelectedItem.Value;            
            cmd.ExecuteNonQuery();
            //SqlDataAdapter Da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //Da.Fill(ds);
            //grdDetail.DataSource = ds.Tables[0];
            //grdDetail.DataBind();
            //Panel1.Visible = true;
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    string script = "alert('No Record Found');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //    return;
            //}
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
        Response.Redirect("JCT_Payroll_PF_EPS_Calculations.aspx");
    }

    protected void ddldedtypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtypes.SelectedItem.Value == "PF EPS Calculation")
        {
            Response.Redirect("JCT_Payroll_PF_EPS_Calculations.aspx");
        }

        if (ddldedtypes.SelectedItem.Value == "PF Transfer")
        {
            Response.Redirect("JCT_Payroll_PF_EPS_transfer.aspx");
        }

    }
}