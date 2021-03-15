using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Drawing;

public partial class Payroll_Payroll_Manualentry_Attandence : System.Web.UI.Page
{

    Connection obj = new Connection();
    string qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
        }
    }

    public void AttendenceDate()
    {
        DateTime origDT = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        origDT = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(-1);
        txtfromdate.Text = Convert.ToDateTime(origDT).ToShortDateString();
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txttodate_CalendarExtender.SelectedDate = lastDate;
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        if (ddlReporttype.SelectedItem.Text == "Salary")
        {
            try
            {
                ViewState["lnkSave"] = lnkSave.Text;
                if (ViewState["lnkSave"].ToString() == "Save".ToString())
                {
                    qry = "jct_payroll_attendence_data_Ins";
                }
                else if (ViewState["lnkSave"].ToString() == "Update".ToString())
                {
                    qry = "jct_payroll_attendence_data_Upd";
                }
                SqlCommand cmd = new SqlCommand(qry, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empcd", SqlDbType.VarChar, 20).Value = txtCardNo.Text;
                if (txtPresentDays.Text != string.Empty)
                {
                    cmd.Parameters.Add("@mpre", SqlDbType.Decimal, 18).Value = txtPresentDays.Text;
                }
                if (txtHolidays.Text != string.Empty)
                {
                    cmd.Parameters.Add("@mhld", SqlDbType.Decimal, 18).Value = txtHolidays.Text;
                }
                if (txtAbsent.Text != string.Empty)
                {
                    cmd.Parameters.Add("@mabs", SqlDbType.Decimal, 18).Value = txtAbsent.Text;
                }
                if (txtCL.Text != string.Empty)
                {
                    cmd.Parameters.Add("@L1_cl", SqlDbType.Decimal, 18).Value = txtCL.Text;
                }
                if (txtPL.Text != string.Empty)
                {
                    cmd.Parameters.Add("@L2_pl", SqlDbType.Decimal, 18).Value = txtPL.Text;
                }
                if (txtSL.Text != string.Empty)
                {
                    cmd.Parameters.Add("@L3_slp", SqlDbType.Decimal, 18).Value = txtSL.Text;
                }
                if (txtWithoutPay.Text != string.Empty)
                {
                    cmd.Parameters.Add("@L4_lwp", SqlDbType.Decimal, 18).Value = txtWithoutPay.Text;
                }
                if (txtPayDays.Text != string.Empty)
                {
                    cmd.Parameters.Add("@mpaydays", SqlDbType.Decimal, 18).Value = txtPayDays.Text;
                }
                cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
                cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);

                if (txtworkfromhome.Text != string.Empty)
                {
                    cmd.Parameters.Add("@wfhdays", SqlDbType.Decimal, 18).Value = txtworkfromhome.Text;
                }
                
                cmd.ExecuteNonQuery();

                if (ViewState["lnkSave"].ToString() == "Save".ToString())
                {
                    string script = "alert('Record saved.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    EmptyControls();
                }
                else if (ViewState["lnkSave"].ToString() == "Update".ToString())
                {
                    string script = "alert('Record Updated.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    EmptyControls();
                }
                //bindgrid();                                
            }
            catch (Exception ex)
            {
                string script = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }

        if (ddlReporttype.SelectedItem.Text == "Seprate Voucher")
        {
            try
            {
                ViewState["lnkSave"] = lnkSave.Text;
                if (ViewState["lnkSave"].ToString() == "Save".ToString())
                {
                    qry = "Jct_Payroll_Attendence_Data_Ins_SepVoc";
                }
                else if (ViewState["lnkSave"].ToString() == "Update".ToString())
                {
                    qry = "Jct_Payroll_Attendence_Data_Upd_SepVoc";
                }
                SqlCommand cmd = new SqlCommand(qry, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empcd", SqlDbType.VarChar, 20).Value = txtCardNo.Text;
                if (txtPresentDays.Text != string.Empty)
                {
                    cmd.Parameters.Add("@mpre", SqlDbType.Decimal, 18).Value = txtPresentDays.Text;
                }
                if (txtHolidays.Text != string.Empty)
                {
                    cmd.Parameters.Add("@mhld", SqlDbType.Decimal, 18).Value = txtHolidays.Text;
                }
                if (txtAbsent.Text != string.Empty)
                {
                    cmd.Parameters.Add("@mabs", SqlDbType.Decimal, 18).Value = txtAbsent.Text;
                }
                if (txtCL.Text != string.Empty)
                {
                    cmd.Parameters.Add("@L1_cl", SqlDbType.Decimal, 18).Value = txtCL.Text;
                }
                if (txtPL.Text != string.Empty)
                {
                    cmd.Parameters.Add("@L2_pl", SqlDbType.Decimal, 18).Value = txtPL.Text;
                }
                if (txtSL.Text != string.Empty)
                {
                    cmd.Parameters.Add("@L3_slp", SqlDbType.Decimal, 18).Value = txtSL.Text;
                }
                if (txtWithoutPay.Text != string.Empty)
                {
                    cmd.Parameters.Add("@L4_lwp", SqlDbType.Decimal, 18).Value = txtWithoutPay.Text;
                }
                if (txtPayDays.Text != string.Empty)
                {
                    cmd.Parameters.Add("@mpaydays", SqlDbType.Decimal, 18).Value = txtPayDays.Text;
                }
                cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
                cmd.Parameters.Add("@EntryBy ", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);

                if (txtworkfromhome.Text != string.Empty)
                {
                    cmd.Parameters.Add("@wfhdays", SqlDbType.Decimal, 18).Value = txtworkfromhome.Text;
                }

                cmd.ExecuteNonQuery();

                if (ViewState["lnkSave"].ToString() == "Save".ToString())
                {
                    string script = "alert('Record saved.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    EmptyControls();
                }
                else if (ViewState["lnkSave"].ToString() == "Update".ToString())
                {
                    string script = "alert('Record Updated.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    EmptyControls();
                }
                //bindgrid();                                
            }
            catch (Exception ex)
            {
                string script = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }

    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Manualentry_Attandence.aspx");
    }

    public void disable()
    {
        txtPL.Enabled = false;
        txtWithoutPay.Enabled = false;
        txtPayDays.Enabled = false;
        txtCL.Enabled = false;
        txtSL.Enabled = false;
        txtHolidays.Enabled = false;
        txtAbsent.Enabled = false;
        txtCardNo.Enabled = false;
        txtPresentDays.Enabled = false;
        txtworkfromhome.Enabled = false; 
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[21].Text.Trim() == "A".ToString())
            {
                e.Row.BackColor = System.Drawing.Color.Green;
            }
        }
    }

    public void EmptyControls()
    {
        txtPayDays.Text = "";
        txtAbsent.Text = "";
        txtCL.Text = "";
        txtPL.Text = "";
        txtSL.Text = "";
        txtWithoutPay.Text = "";
        txtHolidays.Text = "";
        txtPresentDays.Text = "";
        txtCardNo.Text = "";
        lbldepartment.Text = "";
        lblDesignation.Text = "";
        txtworkfromhome.Text = ""; 

    }

    protected void txtCardNo_TextChanged(object sender, EventArgs e)
    {
        if (ddlReporttype.SelectedItem.Text == "Salary")
        {

            try
            {
                //Query for Checking Existing Record..            
                string sqlqry = "jct_Payroll_Manual_Attendence_CheckExistingRecord";
                SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empcd", SqlDbType.VarChar, 20).Value = txtCardNo.Text;
                cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    sqlqry = "jct_Payroll_PayDays_calc_ManualFetch";
                    cmd = new SqlCommand(sqlqry, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empcd", SqlDbType.VarChar, 20).Value = txtCardNo.Text;
                    cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            lblDesignation.Text = dr["Desg_Long_Description"].ToString();
                            lbldepartment.Text = dr["Department_Short_Description"].ToString();
                            txtPayDays.Text = dr["mpaydays"].ToString();
                            txtAbsent.Text = dr["mabs"].ToString();
                            txtCL.Text = dr["L1_cl"].ToString();
                            txtPL.Text = dr["L2_pl"].ToString();
                            txtSL.Text = dr["L3_slp"].ToString();
                            txtWithoutPay.Text = dr["L4_lwp"].ToString();
                            txtHolidays.Text = dr["mhld"].ToString();
                            txtPresentDays.Text = dr["mpre"].ToString();
                            txtworkfromhome.Text = dr["WfH"].ToString(); 
                        }
                        dr.Close();
                        lnkSave.Text = "Update";
                    }
                }
                else
                {
                    sqlqry = "jct_Payroll_PayDays_Calc_ManualFetch_RecordNotFound";
                    cmd = new SqlCommand(sqlqry, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empcd", SqlDbType.VarChar, 20).Value = txtCardNo.Text;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            lblDesignation.Text = dr["Desg_Long_Description"].ToString();
                            lbldepartment.Text = dr["Department_Short_Description"].ToString();
                        }
                        dr.Close();
                        lnkSave.Text = "Save";
                    }
                    else
                    {
                        string script = "alert('Record Not Found In EmployeeMaster.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        lnkSave.Text = "Save";
                        EmptyControls();
                    }
                }
            }
            catch (Exception exception)
            {
                string script = "alert('" + exception.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }

        if (ddlReporttype.SelectedItem.Text == "Seprate Voucher")
        {

            try
            {
                //Query for Checking Existing Record..            
                string sqlqry = "jct_Payroll_Manual_Attendence_CheckExistingRecord_SepVoc";
                SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empcd", SqlDbType.VarChar, 20).Value = txtCardNo.Text;
                cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    sqlqry = "jct_Payroll_PayDays_calc_ManualFetch_SepVoc";
                    cmd = new SqlCommand(sqlqry, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empcd", SqlDbType.VarChar, 20).Value = txtCardNo.Text;
                    cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txttodate.Text;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            lblDesignation.Text = dr["Desg_Long_Description"].ToString();
                            lbldepartment.Text = dr["Department_Short_Description"].ToString();
                            txtPayDays.Text = dr["mpaydays"].ToString();
                            txtAbsent.Text = dr["mabs"].ToString();
                            txtCL.Text = dr["L1_cl"].ToString();
                            txtPL.Text = dr["L2_pl"].ToString();
                            txtSL.Text = dr["L3_slp"].ToString();
                            txtWithoutPay.Text = dr["L4_lwp"].ToString();
                            txtHolidays.Text = dr["mhld"].ToString();
                            txtPresentDays.Text = dr["mpre"].ToString();
                            txtworkfromhome.Text = dr["WfH"].ToString(); 
                        }
                        dr.Close();
                        lnkSave.Text = "Update";
                    }
                }
                else
                {
                    sqlqry = "jct_Payroll_PayDays_Calc_ManualFetch_RecordNotFound";
                    cmd = new SqlCommand(sqlqry, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empcd", SqlDbType.VarChar, 20).Value = txtCardNo.Text;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            lblDesignation.Text = dr["Desg_Long_Description"].ToString();
                            lbldepartment.Text = dr["Department_Short_Description"].ToString();
                        }
                        dr.Close();
                        lnkSave.Text = "Save";
                    }
                    else
                    {
                        string script = "alert('Record Not Found In EmployeeMaster.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        lnkSave.Text = "Save";
                        EmptyControls();
                    }
                }
            }
            catch (Exception exception)
            {
                string script = "alert('" + exception.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }


    }
    protected void txtfromdate_TextChanged(object sender, EventArgs e)
    {
        DateTime origDT = Convert.ToDateTime(txtfromdate.Text);
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txttodate_CalendarExtender.SelectedDate = lastDate;
    }
    protected void ddlReporttype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}