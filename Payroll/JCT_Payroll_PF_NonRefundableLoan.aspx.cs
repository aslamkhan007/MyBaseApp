using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;

public partial class Payroll_JCT_Payroll_PF_NonRefundableLoan : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string cardno;
    string empcode;
    string FlagCheck = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();
            Locationbind();
        }
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
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
    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Current_FIYear";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodate.Text = dr["FIYear"].ToString();
            }
            dr.Close();
        }
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
            FetchRecord();
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void clear()
    {
        txtefffrm.Text = "";
        SadvRequiredAmt.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        lblEmpname.Text = "";
        lblDept.Text = "";
        lbldesig.Text = "";
        lblGross.Text = "";
        txtEmployee.Text = "";     
        
        
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecordInsert();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("JCT_Payroll_PF_NonRefundableLoan_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@FYPeriod", SqlDbType.VarChar, 10).Value = txttodate.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            lblEmpname.Text = dr[0].ToString();
            lblDept.Text = dr[1].ToString();
            lbldesig.Text = dr[2].ToString();
            lblGross.Text = dr[3].ToString();
        }
        else
        {
            string script = "alert('No Record Found.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        dr.Close();
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    public void FetchRecordInsert()
    {
        try
        {
            sql = "JCT_Payroll_PF_NonRefundableLoan_Apply";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FYPeriod", SqlDbType.VarChar, 7).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            cmd.Parameters.Add("@SanctionNo", SqlDbType.VarChar, 6).Value = SadvRequiredAmt.Text;
            cmd.Parameters.Add("@SanctionDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);

            cmd.Parameters.Add("@OwnLoanAmt", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(TextBox1.Text);
            cmd.Parameters.Add("@EmpLoanAmt", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(TextBox2.Text);
            cmd.Parameters.Add("@OwnIntAmt", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(TextBox3.Text);
            cmd.Parameters.Add("@EmpIntAmt", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(TextBox4.Text);
            cmd.Parameters.Add("@VPFAmt", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(TextBox5.Text);
            cmd.Parameters.Add("@VPFInt", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(TextBox6.Text);
            //cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
            cmd.ExecuteNonQuery();
            string script = "alert('Record  Saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            clear();
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_PF_NonRefundableLoan.aspx");
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_PF_NonRefundableLoan_Report.aspx");
    }
}