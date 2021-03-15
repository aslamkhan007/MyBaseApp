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


public partial class Payroll_Jct_Payroll_Leave_Cancel : System.Web.UI.Page
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
            Locationbind();
        }
    }
 
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecord();

        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("Jct_Payroll_LeaveCancellList", obj.Connection());
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@cat", SqlDbType.VarChar, 15).Value = Drpcat.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Drpaction.Items.Clear();
        Drpaction.DataSource = ds;
        Drpaction.DataTextField = "SName";
        Drpaction.DataValueField = "NAME";
        Drpaction.DataBind();
    }

    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("JCT_Payroll_Manual_Leave_Cancel_Auth_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ActionType", SqlDbType.VarChar, 15).Value = Drpcat.SelectedItem.Value;
        cmd.Parameters.Add("@Action", SqlDbType.VarChar, 15).Value = Drpaction.SelectedItem.Value;
        cmd.Parameters.Add("@Autoid", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 25).Value = Session["Empcode"];
        cmd.ExecuteNonQuery();        
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
        Panel4.Visible = true;
        Panel1.Visible = true;
        lnkapply.Enabled = true;

        if (dt.Rows.Count == 0)
        {
            string script = "alert('No Record Found !!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            Panel4.Visible = false;
            Panel1.Visible = false;
                       
        }   
    }
 
    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            //foreach (GridViewRow gvRow in grdDetail.Rows)
            //{
                    sql = "JCT_Payroll_Manual_Leave_Cancel_Auth_Update";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ActionType", SqlDbType.VarChar, 15).Value = Drpcat.SelectedItem.Value;
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar, 15).Value = Drpaction.SelectedItem.Value;
                    cmd.Parameters.Add("@Autoid", SqlDbType.Int).Value = txtEmployee.Text; 
                    //cmd.Parameters.Add("@ActionBy", SqlDbType.VarChar, 25).Value = Session["Empcode"];
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = txtReasonForCancel.Text;               
                    cmd.ExecuteNonQuery();
                                      
                    if (Drpaction.SelectedItem.Value == "Authorise")
                    {
                        string script = "alert('Leave Authorization Successfull.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        string script1 = "alert('Leave Cancellation Successfull.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
                    }                                                                                  
                //}            
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        FetchRecord();  
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Leave_Cancel.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    protected void Drpcat_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (Drpcat.SelectedItem.Value == "AdminAuthrize")
        {
            Response.Redirect("Jct_Payroll_Leave_Auth_Admin.aspx");
        }

        if (Drpcat.SelectedItem.Value != "AdminAuthrize")
        {
            Locationbind();
        }

       
    }
}