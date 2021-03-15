using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Net;

public partial class Payroll_Payroll_Medical_Reimbursement_Authorization : System.Web.UI.Page
{
    Connection obj = new Connection();
    string YearMonth = string.Empty;
    string EmployeeCode = string.Empty;
    decimal BalanceAmount;
    decimal RaisedAmount;
    decimal AuthorizedAmount;
    string Remarks = string.Empty;
    string sql = string.Empty;
    string to = string.Empty;
    string from = string.Empty;
    string bcc = string.Empty;
    string cc = string.Empty;
    string subject = string.Empty;
    string body = string.Empty;
    string url = string.Empty;
    string querystring = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();
            Locationbind();
            bindgrid();
            bindgrid1();
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
        SqlCommand sqlCmd = new SqlCommand("SELECT '' as Location_description , '' as Location_code Union SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        //SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
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
        string sqlqry = "Jct_Payroll_Medical_Attendence_Month";
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

    private void bindgrid()
    {
        SqlCommand cmd2 = new SqlCommand("Jct_Payroll_MedicalFile_Sanction_Fetch", obj.Connection());
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd2.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlplant.SelectedItem.Value;
        cmd2.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        grdDetail.DataSource = ds2.Tables[0];
        grdDetail.DataBind();
    }

    private void bindgrid1()
    {
        SqlCommand cmd2 = new SqlCommand("Jct_Payroll_MedicalFile_Sanction_FetchAuthorized", obj.Connection());
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd2.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlplant.SelectedItem.Value;
        cmd2.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        GridView1.DataSource = ds2.Tables[0];
        GridView1.DataBind();
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
        bindgrid();
        bindgrid1();
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
        bindgrid1();
    }

    protected void ChkOrderSelAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)grdDetail.HeaderRow.FindControl("ChkOrderSelAll");
        foreach (GridViewRow row in grdDetail.Rows)
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

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Medical_Reimbursement_Authorization.aspx");
    }

    protected void ImgSaveRecord_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        YearMonth = row.Cells[2].Text;
        EmployeeCode = row.Cells[3].Text;
        BalanceAmount = Convert.ToDecimal(row.Cells[7].Text);
        RaisedAmount = Convert.ToDecimal(row.Cells[8].Text);
        TextBox Unmapdate = (TextBox)row.FindControl("txtunmapdate");

        if (Unmapdate.Text != "")
        {

            AuthorizedAmount = Convert.ToDecimal(Unmapdate.Text);
            TextBox txtRemarkss = (TextBox)row.FindControl("txtRemarks");
            Remarks = txtRemarkss.Text;
        }
        else
        {
            string script = "alert('Authorize Amount ?!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        try
        {
            if (Unmapdate.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Jct_Payroll_MedicalFile_Sanction_Authorize", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = YearMonth;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = EmployeeCode;
                cmd.Parameters.Add("@BalanceAmount", SqlDbType.Decimal, 2).Value = BalanceAmount;
                cmd.Parameters.Add("@RaisedAmount", SqlDbType.Decimal, 2).Value = RaisedAmount;
                cmd.Parameters.Add("@AuthorizedAmount", SqlDbType.Decimal, 2).Value = AuthorizedAmount;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 150).Value = Remarks;
                cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 20).Value = (Session["Empcode"]);
                cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
                string script = "alert('Record Authorized Successfully!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                bindgrid();
                bindgrid1();
                ClearControls();
            }
            else
            {
                string script = "alert('Authorize Amount ?!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    public void ClearControls()
    {
        string YearMonth = string.Empty;
        string EmployeeCode = string.Empty;
        BalanceAmount = Convert.ToDecimal("0.0");
        RaisedAmount = Convert.ToDecimal("0.0");
        AuthorizedAmount = Convert.ToDecimal("0.0");
        string Remarks = string.Empty;
    }

    //protected void lnkConfirmAll_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        foreach (GridViewRow gvRow in grdDetail.Rows)
    //        {
    //            CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
    //            if (chkRemove.Checked == true)
    //            {
    //                ImageButton lnkbtn = sender as ImageButton;
    //                YearMonth = gvRow.Cells[2].Text;
    //                EmployeeCode = gvRow.Cells[3].Text;
    //                BalanceAmount = Convert.ToDecimal(gvRow.Cells[7].Text);
    //                RaisedAmount = Convert.ToDecimal(gvRow.Cells[8].Text);                    

    //                TextBox Unmapdate = (TextBox)gvRow.FindControl("txtunmapdate");
    //                AuthorizedAmount = Convert.ToDecimal(Unmapdate.Text);
    //                TextBox txtRemarkss = (TextBox)gvRow.FindControl("txtRemarks");
    //                Remarks = txtRemarkss.Text;
    //                SqlCommand cmd = new SqlCommand("Jct_Payroll_MedicalFile_Sanction_Authorize", obj.Connection());
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = YearMonth;
    //                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = EmployeeCode;
    //                cmd.Parameters.Add("@BalanceAmount", SqlDbType.Decimal, 2).Value = BalanceAmount;
    //                cmd.Parameters.Add("@RaisedAmount", SqlDbType.Decimal, 2).Value = RaisedAmount;
    //                cmd.Parameters.Add("@AuthorizedAmount", SqlDbType.Decimal, 2).Value = AuthorizedAmount;
    //                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 150).Value = Remarks;
    //                cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 20).Value = (Session["Empcode"]);
    //                cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 25).Value = Request.ServerVariables["REMOTE_ADDR"];
    //                cmd.ExecuteNonQuery();
    //                string script = "alert('Records Authorized !!');";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //            }
    //        }
    //        bindgrid();
    //        bindgrid1();
    //        ClearControls();
    //    }
    //    catch (Exception ex)
    //    {
    //        string script2 = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
    //        return;
    //    }
    //}
}