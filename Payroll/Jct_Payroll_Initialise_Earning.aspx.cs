using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Net;

public partial class Payroll_Jct_Payroll_Initialise_Earning : System.Web.UI.Page
{
    Connection obj = new Connection();
    public HelpDeskClass ob = new HelpDeskClass();
    public SqlCommand cmd = new SqlCommand();
    public string qry;
    private int i;
    public SqlDataReader dr;
    private string[] cl = new string[71];
    string Empcode = string.Empty;
    string usercode = string.Empty;
    string sql = string.Empty;
    string to = string.Empty;
    string from = string.Empty;
    string bcc = string.Empty;
    string cc = string.Empty;
    string subject = string.Empty;
    string body = string.Empty;
    string url = string.Empty;
    int check1;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {           
            Plantbind();
            Locationbind();
            //FetchRecordCancelled();
            //this.PnlExtTasks.Collapsed = true;         
        }
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        FetchRecordCancelled();        
    }

    public void FetchRecordCancelled()
    {    
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "jct_Payroll_Master_Initilization";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        //Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "R-03339";
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        GridExtTask.DataSource = ds.Tables[0];
        GridExtTask.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            lnkConfirmAll.Visible = true;
        }
        else
        {
            lnkConfirmAll.Visible = false;
        }
    }

    public void DisableControls()
    {
        lnkConfirmAll.Visible = false;       
    }

    public void EnableControls()
    {
        lnkConfirmAll.Visible = true;
        
    }

    protected void lnkConfirmAll_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in GridExtTask.Rows)
            {
                CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
                if (chkRemove.Checked == true)
                {
                    int rowIndex = (int)gvRow.RowIndex;
                    string Empcode = gvRow.Cells[1].Text.Replace("&nbsp;", "");
                    string Empname = gvRow.Cells[2].Text.Replace("&nbsp;", "");
                    string dept = gvRow.Cells[3].Text.Replace("&nbsp;", "");
                    string comcode = gvRow.Cells[4].Text.Replace("&nbsp;", "");
                    string comname = gvRow.Cells[5].Text.Replace("&nbsp;", "");
                    string comvalue= gvRow.Cells[6].Text.Replace("&nbsp;", "");                                                            
                    string sql = "jct_Payroll_Master_Initilization_Insert";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Empcode;
                    cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar,30).Value = Empname;
                    cmd.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 40).Value = dept;
                    cmd.Parameters.Add("@ComponentCode", SqlDbType.VarChar, 10).Value = comcode;
                    cmd.Parameters.Add("@EarlerComponentValue",SqlDbType.Decimal,8).Value =Convert.ToDecimal(comvalue);                                                                                
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                    cmd.ExecuteNonQuery();
                    
                }
            }           
            string script = "alert('Records Updated.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);                      
            //Authrecords();
            FetchRecordCancelled();
            return;  
            
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }



    //public void Authrecords()
    //{
    //    string SqlPass = null;
    //    SqlCommand Cmd = new SqlCommand();
    //    SqlPass = "jct_Payroll_Master_Initilization_InsertForMonth ";
    //    Cmd = new SqlCommand(SqlPass, obj.Connection());
    //    Cmd.CommandType = CommandType.StoredProcedure;
    //    Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
    //    Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
    //    //Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "R-03339";
    //    SqlDataAdapter Da = new SqlDataAdapter(Cmd);
    //    DataSet ds = new DataSet();
    //    Da.Fill(ds);
    //    GridExtTask.DataSource = ds.Tables[0];
    //    GridExtTask.DataBind();
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        string script = "alert('No Record Found');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //        return;
    //    }
    //    if (ds.Tables[0].Rows.Count != 0)
    //    {
    //        lnkConfirmAll.Visible = true;
    //    }
    //    else
    //    {
    //        lnkConfirmAll.Visible = false;
    //    }
    //}



    protected void ChkOrderSelAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)GridExtTask.HeaderRow.FindControl("ChkOrderSelAll");
        foreach (GridViewRow row in GridExtTask.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkCheck");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
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
        ddllocation.DataSource = ds;
        ddllocation.DataTextField = "Location_description";
        ddllocation.DataValueField = "Location_code";
        ddllocation.DataBind();
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Initialise_Earning.aspx");
    }
    protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FetchRecordCancelled();
    }
}
