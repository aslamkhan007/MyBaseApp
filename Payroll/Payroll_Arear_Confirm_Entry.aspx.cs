using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Payroll_Payroll_Arear_Confirm_Entry : System.Web.UI.Page
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

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
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
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckDesignation()
    {
        string sql = "Jct_Payroll_CommonDetail_Employee_Fetch";
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

    public void ClearControls()
    {
        lblEmployeeName.Text = "";
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("Jct_Payroll_Confirm_Arrear_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ArrearType", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
            cmd.Parameters.Add("@BASIC", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtdedamount.Text);
            cmd.Parameters.Add("@HRA", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(TextBox1.Text);
            cmd.Parameters.Add("@ColonyAllowance", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(TextBox2.Text);
            cmd.Parameters.Add("@PersonalAllowance", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(TextBox3.Text);            
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            con.Close();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtype.SelectedItem.Value == "PayDays")
        {
            Response.Redirect("Payroll_Arear_PayDay_Entry.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Fda")
        {
            Response.Redirect("Payroll_Arear_Fda_Entry.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Increment")
        {
            Response.Redirect("Payroll_Arear_Increment_Entry.aspx");
        }
        if (ddldedtype.SelectedItem.Value == "Confirm")
        {
            Response.Redirect("Payroll_Arear_Confirm_Entry.aspx");
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Arear_Confirm_Entry.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }



    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("Jct_Payroll_Confirm_Arrear_Fetch_Freeze", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ArrearType", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    public void Excel()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_Confirm_Arrear_Fetch_confirmtable", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ArrearType", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter Da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; AssetReport.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }

        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }

}