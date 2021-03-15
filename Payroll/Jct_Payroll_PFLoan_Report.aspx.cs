using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Payroll_Jct_Payroll_PFLoan_Report : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Componentlist();
            DropdownEnableDisable();
            PlantList();
            Locationbind();
            //Departmentbind();
            //Locationbind();
        }

    }
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
    protected void txtefffrm_TextChanged(object sender, EventArgs e)
    {
        //DateTime origDT = Convert.ToDateTime(txtefffrm.Text);
        //DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        //txteffto_CalendarExtender.SelectedDate = lastDate;
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

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
    public void Departmentbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by DepartmentLongDescription", obj.Connection());
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
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_PFLoan_Withdrawal_Report";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@Fromdate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@LoanType", SqlDbType.VarChar, 40).Value = ddl1.SelectedItem.Value;

            if (DropDownList1.Visible == true)
            {
                cmd.Parameters.Add("@LoanPurposes", SqlDbType.VarChar, 40).Value = DropDownList1.SelectedItem.Value;
            }
            else
            {
                cmd.Parameters.Add("@LoanPurposes", SqlDbType.VarChar, 40).Value = "All";
            }

            if (txtEmployee.Text != "")
            {
                cmd.Parameters.Add("@Employeecode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            }
            else
            {
                cmd.Parameters.Add("@Employeecode", SqlDbType.VarChar, 10).Value = "All";
            }
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = DropDownList2.SelectedItem.Value;

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
        Response.Redirect("Jct_Payroll_PFLoan_Report.aspx");
    }
    //protected void lnkexcel_Click(object sender, EventArgs e)
    //{
    //    GridViewExportUtil.Export("XL.xls", grdDetail);

    //}
    //protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddldedtype.SelectedItem.Value == "BloodGroup")
    //    {
    //        Response.Redirect("JCT_Payroll_Employee_BloodGroup_Report.aspx");
    //    }

    //    if (ddldedtype.SelectedItem.Value == "JobTypeWise Attendance")
    //    {
    //        Response.Redirect("JCT_Payroll_JobTypeWise_Attendance_Report.aspx");
    //    }

    //    if (ddldedtype.SelectedItem.Value == "AreaWise Attendance")
    //    {
    //        Response.Redirect("JCT_Payroll_AreaWise_Attendance_Report.aspx");
    //    }

    //    if (ddldedtype.SelectedItem.Value == "DepartmentWise Attendance")
    //    {
    //        Response.Redirect("JCT_Payroll_DepartmentWise_Attendance_Report.aspx");
    //    }

    //    if (ddldedtype.SelectedItem.Value == "ShiftWise Attendance")
    //    {
    //        Response.Redirect("JCT_Payroll_ShiftWise_Attendance_Report.aspx");
    //    }

    //    if (ddldedtype.SelectedItem.Value == "Employee PayDays")
    //    {
    //        Response.Redirect("JCT_Payroll_Employee_PayDays_Report.aspx");
    //    }

    //    if (ddldedtype.SelectedItem.Value == "ShortDuty")
    //    {
    //        Response.Redirect("JCT_Payroll_Employee_ShortDuties_Report.aspx");
    //    }
    //}

    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropdownEnableDisable();
    }
    public void DropdownEnableDisable()
    {
        if (ddl1.Text == "Nonrefundable (Advance)")
        {
            DropDownList1.Visible = true;
            lblUANNo.Visible = true;
        }
        else
        {
            DropDownList1.Visible = false;
            lblUANNo.Visible = false;
        }
       
    }
}