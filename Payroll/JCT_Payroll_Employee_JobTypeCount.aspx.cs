using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Payroll_JCT_Payroll_Employee_JobTypeCount : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Componentlist();

            PlantList();
            Locationbind();
            //Locationbind();
        }

    }
    private void PlantList()
    {
        string sql = "Jct_Payroll_Plantlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "LongDescription";
        ddlplant.DataValueField = "PlantCode";
        ddlplant.DataBind();

    }

    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("Select 'All' as Location_description ,'All' as Location_code union SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
        ddlLocation.SelectedIndex = 2;
    }

    //public void Componentlist()
    //{
    //    string sql = "Jct_Payroll_Reimbursement_ParameterList_Calculation";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddldedtype.DataSource = ds;
    //    ddldedtype.DataTextField = "ComponentName";
    //    ddldedtype.DataValueField = "ComponentCode";
    //    ddldedtype.DataBind();
    //}




    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_Payroll_Employee_JobTypeCount_Query";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@ReportType", SqlDbType.VarChar, 15).Value = ddl1.SelectedItem.Value;
            cmd.Parameters.Add("@JobType", SqlDbType.VarChar, 20).Value = ddl2.SelectedItem.Value;
            cmd.ExecuteNonQuery();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            //if( a == 1)
            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }

            //string scripts = "alert('Calculation Completed');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", scripts, true);
            //return;

        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    //public void BindGrid()
    //{
    //    string SqlPass = null;
    //    SqlCommand Cmd = new SqlCommand();
    //    SqlPass = "Jct_Payroll_Converyance_Reimbursement_BindGrid";
    //    Cmd = new SqlCommand(SqlPass, obj.Connection());
    //    Cmd.CommandType = CommandType.StoredProcedure;
    //    Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;

    //    Cmd.Parameters.Add("@ReimbursementType", SqlDbType.VarChar, 25).Value = ddldedtype.SelectedItem.Value;
    //    SqlDataAdapter Da = new SqlDataAdapter(Cmd);
    //    DataSet ds = new DataSet();
    //    Da.Fill(ds);
    //    grdDetail.DataSource = ds.Tables[0];
    //    grdDetail.DataBind();
    //    Panel1.Visible = true;
    //}
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

    //public void Locationbind()
    //{
    //    SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
    //    sqlCmd.CommandType = CommandType.Text;
    //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddllocation.DataSource = ds;
    //    ddllocation.DataTextField = "Location_description";
    //    ddllocation.DataValueField = "Location_code";
    //    ddllocation.DataBind();
    //}

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_Employee_JobTypeCount.aspx");
    }
    //protected void lnkexcel_Click(object sender, EventArgs e)
    //{
    //    GridViewExportUtil.Export("XL.xls", grdDetail);

    //}
    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtype.SelectedItem.Value == "PlantLocationCount")
        {
            Response.Redirect("JCT_Payroll_Employee_PlantLocationCount.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "JobTypeCount")
        {
            Response.Redirect("JCT_Payroll_Employee_JobTypeCount.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "ReligionCount")
        {
            Response.Redirect("JCT_Payroll_Employee_ReligionCount.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "WorkAreaCount")
        {
            Response.Redirect("JCT_Payroll_Employee_WorkAreaCount.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "SalaryTypeCount")
        {
            Response.Redirect("JCT_Payroll_Employee_SalaryTypeCount.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "GenderCount")
        {
            Response.Redirect("JCT_Payroll_Employee_GenderCount.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "DepartmentCount")
        {
            Response.Redirect("JCT_Payroll_Employee_DepartmentCount.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "DesignationCount")
        {
            Response.Redirect("JCT_Payroll_Employee_DesignationCount.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "EmployeeDetail")
        {
            Response.Redirect("JCT_Payroll_Employee_Detail.aspx");

        }
    }
}