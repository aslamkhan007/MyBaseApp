using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_JCT_Payroll_Employee_PayDays_Report : System.Web.UI.Page
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
            Locationbind();
            Departmentbind();
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
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
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

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;           
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void Departmentbind()
    {
      
        SqlCommand sqlCmd = new SqlCommand("SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by Department_long_Description", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddl1.Items.Clear();
        ddl1.DataSource = ds;
        ddl1.DataTextField = "DepartmentLongDescription";
        ddl1.DataValueField = "DepartmentCode";
        ddl1.DataBind();      
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "JCT_Payroll_Employee_PayDays_Report";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@FromYrMth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@ToYrMth", SqlDbType.Int).Value = TextBox1.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@Deptcode", SqlDbType.VarChar, 15).Value = ddl1.SelectedItem.Value;            
            if (txtEmployee.Text != "")
            {
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            }
            else
            {
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "All";
            }
            //SELECT   6998+68657+ 83201+86464+ 19597 
            //SELECT   2584 + 6857
            //SELECT   258 - 685
            //SELECT   12548 - 91103
            //SELECT   61209 - 29977
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
        Response.Redirect("JCT_Payroll_Employee_PayDays_Report.aspx");
    }
    //protected void lnkexcel_Click(object sender, EventArgs e)
    //{
    //    GridViewExportUtil.Export("XL.xls", grdDetail);

    //}
    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {                                                                                                             
        if (ddldedtype.SelectedItem.Value == "BloodGroup")
        {
            Response.Redirect("JCT_Payroll_Employee_BloodGroup_Report.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "JobTypeWise Attendance")
        {
            Response.Redirect("JCT_Payroll_JobTypeWise_Attendance_Report.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "AreaWise Attendance")
        {
            Response.Redirect("JCT_Payroll_AreaWise_Attendance_Report.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "DepartmentWise Attendance")
        {
            Response.Redirect("JCT_Payroll_DepartmentWise_Attendance_Report.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "ShiftWise Attendance")
        {
            Response.Redirect("JCT_Payroll_ShiftWise_Attendance_Report.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Employee PayDays")
        {
            Response.Redirect("JCT_Payroll_Employee_PayDays_Report.aspx");
        }
        if (ddldedtype.SelectedItem.Value == "ShortDuty")
        {
            Response.Redirect("JCT_Payroll_Employee_ShortDuties_Report.aspx");
        }

    }

}