using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_SalarySheet_View : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            AttendenceDate();
            Plantbind();
            Locationbind();                   
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

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }


    //public void txtEmployee_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string employeecode = txtEmployee.Text.Split('|')[1].ToString();
    //        txtEmployee.Text = employeecode;
    //    }
    //    catch (Exception exception)
    //    {
    //        txtEmployee.Text = "";
    //        string script = "alert('Please Select Record From List');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }
    //}


    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_SalarySheet_View.aspx");
    }

    /*
Please Note : UseDefaultFiles must be called before UseStaticFiles to serve the default file. 
UseDefaultFiles is a URL rewriter that doesn't actually serve the file. It simply rewrites the URL to the default document which will then be served by
the Static Files Middleware. The URL displayed in the address bar still reflects the root URL and not the rewritten URL.
    
The following are the default files which UseDefaultFiles middleware looks for
index.htm
index.html
default.htm
default.html     
     */

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
            {
                sql = "Jct_Payroll_SalarySheet_View";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];             
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }
                else
                {
                    grdDetail.DataSource = ds.Tables[0];
                    grdDetail.DataBind();
                    Panel1.Visible = true;
                }              
            }
            catch (Exception ex)
            {
                string script2 = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                return;
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

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
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

    protected void ddlLocation_SelectedIndexChanged1(object sender, EventArgs e)
    {       
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }
}