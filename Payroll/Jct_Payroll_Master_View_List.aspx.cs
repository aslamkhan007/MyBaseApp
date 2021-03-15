using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Payroll_Jct_Payroll_Master_View_List : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string loantype;
    string eleccode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Plantbind();
        }
    }

    public void Plantbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT MenuName,MenuName FROM Jct_Payroll_Master_Menu WHERE  STATUS='A' ORDER BY MenuName", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "MenuName";
        ddlplant.DataValueField = "MenuName";
        ddlplant.DataBind();
    }    
   
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Master_View_List.aspx");
    }
  
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecord();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    public void FetchRecord()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Master_Listing";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@MasterName", SqlDbType.VarChar, 25).Value = ddlplant.SelectedItem.Value;        
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }        
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlplant.SelectedItem.Text == "Employee Address"))
        {
            Response.Redirect("JCT_Payroll_Employee_Address_List.aspx");
        }
    }
}