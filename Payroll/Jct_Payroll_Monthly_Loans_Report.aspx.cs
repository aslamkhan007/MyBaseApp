using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_Monthly_Loans_Report : System.Web.UI.Page
{
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {          
            Plantbind();
            Locationbind();         
            ddlComponentType_SelectedIndexChanged(sender, e);
        }
    }


    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecord();
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

    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
    }


    public void FetchRecord()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Loans_Advance_Master_List";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;                
        Cmd.Parameters.Add("@Componentname", SqlDbType.VarChar, 20).Value = ddlReportType.SelectedItem.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;

        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
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

    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Monthly_Loans_Report.aspx");
    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void ddlComponentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Componentlist();
    }
    private void Componentlist()
    {
        string sql = "Jct_Payroll_Salary_LoansReportParameterList";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@component_type", SqlDbType.VarChar, 15).Value = ddlComponentType.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlReportType.DataSource = ds;
        ddlReportType.DataTextField = "ComponentName";
        ddlReportType.DataValueField = "SrNo";
        ddlReportType.DataBind();
    }

   
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
}