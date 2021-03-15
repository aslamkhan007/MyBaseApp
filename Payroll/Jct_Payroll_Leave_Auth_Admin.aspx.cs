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

public partial class Payroll_Jct_Payroll_Leave_Auth_Admin : System.Web.UI.Page
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
            FetchRecordPending();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void ChkOrderSelAll_CheckedChanged(object sender, EventArgs e)
    {
        Boolean Chk_Status = false;
        CheckBox ChkBoxHeader = (CheckBox)GridExtTask.HeaderRow.FindControl("ChkOrderSelAll");
        Chk_Status = ChkBoxHeader.Checked;
        foreach (GridViewRow row in GridExtTask.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkCheck");
            ChkBoxRows.Checked = Chk_Status;
        }
    }

    public void Locationbind()
    {
        //SqlCommand sqlCmd = new SqlCommand("SELECT Name,SName FROM Jct_PayrollPortal_ActionCategory  WHERE STATUS = 'A' AND NAME IN ('Compensatory','Leave','Leave1')  ORDER BY NAME ", obj.Connection());
        SqlCommand sqlCmd = new SqlCommand("SELECT Name,SName FROM Jct_PayrollPortal_ActionCategory  WHERE STATUS = 'A' AND NAME IN ('Leave','Leave1')  ORDER BY NAME ", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DrpLvStatus.Items.Clear();
        DrpLvStatus.DataSource = ds;
        DrpLvStatus.DataTextField = "SName";
        DrpLvStatus.DataValueField = "NAME";
        DrpLvStatus.DataBind();
    }

    public void FetchRecordPending()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Leave_Authorisation";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        Cmd.Parameters.Add("@Param", SqlDbType.VarChar, 20).Value = DrpLvStatus.SelectedItem.Value;
        Cmd.Parameters.Add("@Param1", SqlDbType.VarChar, 20).Value = DrpLvStatus.SelectedItem.Text;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataTable dt = new DataTable();
        Da.Fill(dt);
        GridExtTask.DataSource = dt;
        GridExtTask.DataBind();
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

    //public void FetchRecord()
    //{
    //    SqlCommand cmd = new SqlCommand("Jct_Payroll_Leave_Authorisation", obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@ActionType", SqlDbType.VarChar, 15).Value = Drpcat.SelectedItem.Value;
    //    cmd.Parameters.Add("@Action", SqlDbType.VarChar, 15).Value = Drpaction.SelectedItem.Value;
    //    cmd.Parameters.Add("@Autoid", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
    //    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 25).Value = Session["Empcode"];
    //    cmd.ExecuteNonQuery();
    //    DataTable dt = new DataTable();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(dt);
    //    grdDetail.DataSource = dt;
    //    grdDetail.DataBind();
    //    Panel4.Visible = true;
    //    Panel1.Visible = true;
    //    lnkapply.Enabled = true;

    //    if (dt.Rows.Count == 0)
    //    {
    //        string script = "alert('No Record Found !!');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //        Panel4.Visible = false;
    //        Panel1.Visible = false;

    //    }
    //}

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            Boolean RecordInsertStatus = false;
            foreach (GridViewRow gvRow in GridExtTask.Rows)
            {
                string AutoID = string.Empty;
                string RequestAmt = string.Empty;
                CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
                if (chkRemove.Checked == true)
                {
                    int rowIndex = (int)gvRow.RowIndex;
                    //RequestAmt = gvRow.Cells[6].Text.Replace("&nbsp;", "");
                    AutoID = gvRow.Cells[1].Text.Replace("&nbsp;", "");
                    string sql = "Jct_Payroll_Authrisation_Update_Admin";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Autoid", SqlDbType.Int).Value = Convert.ToInt32(AutoID);
                    cmd.Parameters.Add("@AuthorisedBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                    cmd.Parameters.Add("@AuthFlag", SqlDbType.Char).Value = 'A';
                    cmd.Parameters.Add("@Param", SqlDbType.VarChar, 20).Value = DrpLvStatus.SelectedItem.Value;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = txtReasonForCancel.Text;
                    cmd.Parameters.Add("@PendingAt", SqlDbType.VarChar, 50).Value = txtEmployee.Text; 
                    
                    cmd.ExecuteNonQuery();
                    string script1 = DrpLvStatus.SelectedItem.Value + "Authorized";
                    RecordInsertStatus = true;

                    //if (DrpLvStatus.SelectedItem.Value == "Leave" || DrpLvStatus.SelectedItem.Value == "Compensatory" || DrpLvStatus.SelectedItem.Value == "Leave1")
                    //{
                    //    try
                    //    {
                    //        sendmail(script1, Convert.ToInt32(AutoID));
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        string script = "alert('" + ex.Message + ". Unable To Send Email" + "');";
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    //    }
                    //}  
                }
            }

            if (RecordInsertStatus == true)
            {
                string script = "alert('" + DrpLvStatus.SelectedItem.Value + " Authorized');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            }
            else
            {
                string script = "alert('No Record Selected for the Action...!!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            FetchRecordPending();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        finally
        {
            obj.ConClose();
        }

        //try
        //{
        //    //foreach (GridViewRow gvRow in grdDetail.Rows)
        //    //{
        //    sql = "JCT_Payroll_Manual_Leave_Cancel_Auth_Update";
        //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@ActionType", SqlDbType.VarChar, 15).Value = Drpcat.SelectedItem.Value;
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar, 15).Value = Drpaction.SelectedItem.Value;
        //    cmd.Parameters.Add("@Autoid", SqlDbType.Int).Value = txtEmployee.Text;
        //    //cmd.Parameters.Add("@ActionBy", SqlDbType.VarChar, 25).Value = Session["Empcode"];
        //    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = txtReasonForCancel.Text;
        //    cmd.ExecuteNonQuery();

        //    if (Drpaction.SelectedItem.Value == "Authorise")
        //    {
        //        string script = "alert('Leave Authorization Successfull.!!');";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //    }
        //    else
        //    {
        //        string script1 = "alert('Leave Cancellation Successfull.!!');";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
        //    }
        //    //}            
        //}
        //catch (Exception ex)
        //{
        //    string script = "alert('" + ex.Message + "');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //}

        //FetchRecordPending();
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Leave_Auth_Admin.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", GridExtTask);
    }

    protected void Drpcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Locationbind();
        if (Drpcat.SelectedItem.Value == "AdminAuthrize")
        {
            Response.Redirect("Jct_Payroll_Leave_Auth_Admin.aspx");
        }

        if (Drpcat.SelectedItem.Value != "AdminAuthrize")
        {
            Response.Redirect("Jct_Payroll_Leave_Cancel.aspx");
        }
    }


    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;          
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

}