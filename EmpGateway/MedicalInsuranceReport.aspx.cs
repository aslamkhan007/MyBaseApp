using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class EmpGateway_MedicalInsuranceReport : System.Web.UI.Page
{
    string sql;
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    string script;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/login.aspx");
            
        }
        if (!IsPostBack)
        {
            RadGrid1.DataSourceID = "SqlDataSource2";
            RadGrid1.DataBind();    
        }
        
    }
    
    
    protected void radAutoUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            sql = "JCT_MEDICAL_INSURANCE_AUTOUPDATE";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FinYear", SqlDbType.VarChar, 20).Value = ddlFinYear.SelectedItem.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.ExecuteNonQuery();
            RadGrid1.DataSourceID = "SqlDataSource2";
            RadGrid1.DataBind();
            script = "alert('Data Updated Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        catch (SqlException ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }
    protected void radFetch_Click(object sender, EventArgs e)
    {
        RadGrid1.DataSourceID = "SqlDataSource2";
        RadGrid1.DataBind();
    }
    protected void radExcel_Click(object sender, EventArgs e)
    {
        //sql = "Select a.ecode as [Salary Code],b.deptcode as [Dept],a.Name as [Name],a.Designation,a.DOB as [DOB] ,a.Age as [Age],a.Relation as [Relationship] from GMEIS2 a Left Outer join deptmast b on a.dept=b.deptcode and a.status='A' and a.mode='Submit'  AND FinancialYear='"+ ddlFinYear.SelectedItem.Text +"' ";

        sql = "JCT_MEDICAL_INSURANCE_DETAILS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.Add("@FinYear", SqlDbType.VarChar, 20).Value = ddlFinYear.SelectedItem.Text;
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        string attachment = "attachment; filename=MedicalInsurance.xls";
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

        obj.ConClose();
    }
}