using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Payroll_MedicalFile_Creation : System.Web.UI.Page
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
            HideControls();
        }
    }

    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Medical_FIYear";
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
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }

    public void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
            ClearControls();
            CheckDesignation();
        }
        catch (Exception exception)
        {
            lblEmployeeName.Text = "";
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckDesignation()
    {
        string sql = "Jct_Payroll_MedicalFile_Detail_Employee_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblEmployeeName.Text = dr[1].ToString();
            }
            dr.Close();
        }
    }

    public void BindGrid()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_MedicalFile_Header_Fetch";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 20).Value = txttodate.Text;
        Cmd.Parameters.Add("@Employeetype", SqlDbType.VarChar, 20).Value = ddlemployeetype.SelectedItem.Value;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        if (txtEmployee.Visible == true)
        {
            Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
        }
        else
        {
            Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "";
        }
        if (txtBasic.Visible == true)
        {
            if (txtBasic.Text != "")
            {
                Cmd.Parameters.Add("@MedicalBasic", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtBasic.Text);
            }
            else
            {
                Cmd.Parameters.Add("@MedicalBasic", SqlDbType.Decimal, 2).Value = 0.0;
            }
        }

        Cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 20).Value = (Session["Empcode"]);
        Cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];

        SqlDataReader dr = Cmd.ExecuteReader();
        string check = string.Empty;
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                check = dr["a"].ToString();
            }
        }
        if (check == "1")
        {
            BindGridFromTable();
            string script = "alert('Data Already Freezed For Current Financial Year');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        else if (check == "2")
        {
            BindGridFromTable();
            string script = "alert('Data Already Freezed For This Employee For Current Financial Year');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else
        {
            BindGridFromTable();
        }
    }

    public void BindGridFromTable()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_MedicalFile_Header_Fetch_GridBind";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 20).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        Cmd.Parameters.Add("@Employeetype", SqlDbType.VarChar, 20).Value = ddlemployeetype.SelectedItem.Value;
        if (txtEmployee.Visible == true)
        {
            Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
        }
        else
        {
            Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "";
        }
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    public void FreezedBindGrid()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_MedicalFile_Header_FetchFreeze";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 20).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        if (txtEmployee.Visible == true)
        {
            Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
        }
        else
        {
            Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "";
        }
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    public void ClearControls()
    {
        lblEmployeeName.Text = "";
    }

    public void HideControls()
    {
        lblSearchEmployeeName.Visible = false;
        lblEmployeeName.Visible = false;
        txtEmployee.Visible = false;
        employeename.Visible = false;
        lblamount.Visible = false;
        txtBasic.Visible = false;
    }

    public void ShowControls()
    {
        lblSearchEmployeeName.Visible = true;
        lblEmployeeName.Visible = true;
        txtEmployee.Visible = true;
        employeename.Visible = true;
        lblamount.Visible = true;
        txtBasic.Visible = true;
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
        }
        catch (Exception ex)
        {
            grdDetail.DataBind();
            grdDetail.DataSource = null;
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_MedicalFile_Creation.aspx");
    }

    protected void ddlemployeetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlemployeetype.SelectedItem.Text == "All")
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            HideControls();
        }
        else
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            ShowControls();
        }
    }

    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_MedicalFile_Header_Freeze";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 20).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@Employeetype", SqlDbType.VarChar, 20).Value = ddlemployeetype.SelectedItem.Value;
            if (txtEmployee.Visible == true)
            {
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
            }
            else
            {
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "";
            }
            cmd.ExecuteNonQuery();
            string script = "alert('Records Freezed.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            FreezedBindGrid();
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

}