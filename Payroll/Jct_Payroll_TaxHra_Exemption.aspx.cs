using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_TaxHra_Exemption : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
          //  Plantbind();                      
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

    //public void Plantbind()
    //{
    //    SqlCommand sqlCmd = new SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection());
    //    sqlCmd.CommandType = CommandType.Text;
    //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlplant.DataSource = ds;
    //    ddlplant.DataTextField = "plant_description";
    //    ddlplant.DataValueField = "plant_code";
    //    ddlplant.DataBind();
    //}

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtype.SelectedItem.Value == "Tax Salary Details")
        {
            Response.Redirect("JCT_Payroll_Tax_Master_Update.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Comparision")
        {
            Response.Redirect("JCT_Payroll_Tax_Master_Update_Comparision.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "HRA Affidavit")
        {
            Response.Redirect("Jct_Payroll_TaxHra_Exemption.aspx");
        }

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
        SqlPass = "Jct_Payroll_TaxHra_Exemption_Insert";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 20).Value = txttodate.Text;        
        //Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlplant.SelectedItem.Value;        
        //if (txtEmployee.Visible == true)
        //{
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
        //}                        
        Cmd.Parameters.Add("@Amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtBasic.Text);

        Cmd.Parameters.Add("@CreatedBy ", SqlDbType.VarChar, 20).Value = (Session["Empcode"]);
        Cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
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
        SqlPass = "Jct_Payroll_TaxHra_Exemption_AutoBind";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 20).Value = txttodate.Text;
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
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
        Response.Redirect("Jct_Payroll_TaxHra_Exemption.aspx");
    }
   
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

}