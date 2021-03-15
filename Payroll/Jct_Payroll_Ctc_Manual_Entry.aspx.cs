using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_Ctc_Manual_Entry : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //AttendenceDate();
            //  Plantbind();                      
        }
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {

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
            ClearRecords();
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }

    public void CheckDesignation()
    {
        string sql = "Jct_Payroll_TaxHra_Exemption_Designation_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblEmployeeName.Text = dr[1].ToString();
                lbldept.Text = dr[2].ToString();
            }
            dr.Close();
            BindGrid();
        }
    }

    public void Save()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Ctc_Mannual_Insert";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 20).Value = txtEmployee.Text;
        Cmd.Parameters.Add("@PayAmount", SqlDbType.Int).Value = Convert.ToInt32(txtBasic.Text);        
        Cmd.Parameters.Add("@CreatedBy ", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);        
        Cmd.ExecuteNonQuery();
        string script11 = "alert('Saved Successfully..');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script11, true);
        BindGrid();
        Panel1.Visible = true;
        ClearRecords();
    }

    public void BindGrid()
    {
        grdDetail.DataSource = null;
        grdDetail.DataBind();
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Ctc_Mannual_AutoBind";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 20).Value = txtEmployee.Text;
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


    public void ClearRecords()
    {
        lblEmployeeName.Text = "";
        lbldept.Text = "";
        txtEmployee.Text = "";
        txtBasic.Text = "";
       
    }


    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            Save();
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
        Response.Redirect("Jct_Payroll_Ctc_Manual_Entry.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    //protected void lnkreset0_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Jct_Payroll_Ctc_Manual_Entry_Report.aspx");
    //}
}