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
using System.Configuration;

public partial class Payroll_Jct_Payroll_FullAndFinal_Entry : System.Web.UI.Page
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


    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            clearAll();
            CheckRecord();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckEnteredRecord()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string sql = "Jct_Payroll_FullAndFinalCal_CheckRecord";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (dr["Result"].ToString() == "Open")
                {
                    AlreadyRecord();
                    Panel3.Visible = true;
                    Panel4.Visible = true;
                    lnkCheck.Enabled = true;
                    lnkFreeze.Enabled = true;
                    lnkapply.Enabled = false;

                    lnkdel.Visible = true;
                    lnkdel.Enabled = true;
                    lnkUnfreeze.Enabled = false;
                    txttodays.Enabled = true;
                    txtPaydays.Enabled = true;
                }
                else
                    if (dr["Result"].ToString() == "Freeze")
                    {
                        AlreadyRecord();
                        //lnkCheck.Enabled = true;
                        Panel3.Visible = true;
                        Panel4.Visible = true;
                        lnkCheck.Enabled = false;
                        lnkapply.Enabled = false;
                        lnkFreeze.Enabled = false;
                        txttodays.Enabled = false;
                        txtPaydays.Enabled = false;
                        lnkUnfreeze.Enabled = true;
                        lnkdel.Visible = false;
                        lnkdel.Enabled = false;

                    }               
            }
            dr.Close();
        }
        con.Close();
    }


    public void CheckRecord()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string sql = "Jct_Payroll_FullAndFinalCal_CheckRecord";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while(dr.Read())
            {
            //if (dr["Result"].ToString() == "Open")
            //{
            //    AlreadyRecord();
            //    Panel3.Visible = true;
            //    Panel4.Visible = true;
            //    lnkCheck.Enabled = true;
            //}
            //else
                if (dr["Result"].ToString() == "Freeze")
                {
                    AlreadyRecord();
                    //lnkCheck.Enabled = true;
                    Panel3.Visible = true;
                    Panel4.Visible = true;
                    txttodays.Enabled = false;
                    txtPaydays.Enabled = false;
                    lnkUnfreeze.Enabled = true;
                    lnkdel.Visible = false;
                    lnkdel.Enabled = false;
                }
                else
                {
                    FetchRecordNew();
                    Panel3.Visible = true;
                    Panel4.Visible = true;
                    lnkCheck.Enabled = true;
                    lnkUnfreeze.Enabled = false;
                    txttodays.Enabled = true;
                    txtPaydays.Enabled = true;
                    lnkdel.Visible = true;
                    lnkdel.Enabled = true;
                }

                
                lnkapply.Enabled = false;
                lnkFreeze.Enabled = false;
                                

            //if (dr["Result"].ToString() == "New")
            //{
            //    FetchRecordNew();
            //    Panel3.Visible = true;
            //    Panel4.Visible = true;
            //    lnkCheck.Enabled = true;
            //}
            }
            dr.Close();
        }
        con.Close();
    }


    public void FetchRecordNew()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_FullAndFinalCal_Fetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@Days", SqlDbType.Decimal, 18).Value = txttodays.Text;
        cmd.Parameters.Add("@PayDays", SqlDbType.Decimal, 18).Value = txtPaydays.Text;
        cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["Empcode"];
        cmd.Parameters.Add("@netsal", SqlDbType.Decimal, 20).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Grat", SqlDbType.Decimal, 20).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@LeaveNoss", SqlDbType.Decimal, 20).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@pfs", SqlDbType.Decimal, 20).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@esis", SqlDbType.Decimal, 20).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@lvamt", SqlDbType.Decimal, 20).Direction = ParameterDirection.Output;
        //cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();

        string netsals = cmd.Parameters["@netsal"].Value.ToString();
        string Grat = cmd.Parameters["@Grat"].Value.ToString();
        string leavenoss = cmd.Parameters["@LeaveNoss"].Value.ToString();
        string pfss = cmd.Parameters["@pfs"].Value.ToString();
        string esiss = cmd.Parameters["@esis"].Value.ToString();
        string lvamtss = cmd.Parameters["@lvamt"].Value.ToString();

        lblGratiuity.Text = Grat;
        lblNetSalary.Text = netsals;
        txtLeaveNo.Text = leavenoss;
        txtLeaveAmount.Text = lvamtss;

        lblpfd.Text = pfss;
        lblesid.Text = esiss;

        /*                
         */            
        con.Close();

    }

    public void AlreadyRecord()
    {
        bindGridForAlreadyRecord();
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string sql = "Jct_Payroll_FullAndFinalCal_AlreadyRecord";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblNetSalary.Text = dr["NetSalaryPaid"].ToString();
                lblGratiuity.Text = dr["Gratiuity"].ToString();
                txtLeaveNo.Text = dr["LeaveNo"].ToString();
                txtLeaveAmount.Text = dr["LeaveAmount"].ToString();
                txtNoticePeriodAdd.Text = dr["NoticePeriodAdd"].ToString();
                txtNoticePeriodMinus.Text = dr["NoticePeriodMinus"].ToString();
                lblFullAndFinalAmount.Text = dr["FullAndFinalAmount"].ToString();
                lblpfd.Text = dr["PFPaid"].ToString();
                lblesid.Text = dr["EsiPaid"].ToString();

                txttodays.Text = dr["TotDays"].ToString();
                txtPaydays.Text = dr["PaidDays"].ToString();



                txtpfpay.Text = dr["pfpay"].ToString();
                txtesipay.Text = dr["esipay"].ToString();
                txtStationary.Text = dr["Stationary"].ToString();
                txtTWCC.Text = dr["TWCC"].ToString();
                txtNoticePd.Text = dr["NoticePd"].ToString();
                txtPowerConsumed.Text = dr["PowerConsumed"].ToString();
                txtGMI.Text = dr["GMI"].ToString();
                txtQuaterMaintenece.Text = dr["QuaterMaintenece"].ToString();
                txtAdvanceStaff.Text = dr["AdvanceStaff"].ToString();
                txtStaffAdvanceExpense.Text = dr["StaffAdvanceExpense"].ToString();

                txtLtastaff.Text = dr["Ltastaff"].ToString();
                txtTDSpay.Text = dr["TDSpay"].ToString();

            }
            dr.Close();
        }
        con.Close();
    }


    public void bindGridForAlreadyRecord()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_FullAndFinalCal_AlreadyRecord", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
        con.Close();
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        try
        {
            sql = "Jct_Payroll_FullAndFinalCal_Update";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empcode1", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
            cmd.Parameters.Add("@Gratiuity", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(lblGratiuity.Text);
            cmd.Parameters.Add("@LeaveNo", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtLeaveNo.Text);
            cmd.Parameters.Add("@LeaveAmount", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtLeaveAmount.Text);
            cmd.Parameters.Add("@NoticePeriodAdd", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtNoticePeriodAdd.Text);
            cmd.Parameters.Add("@NoticePeriodMinus", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtNoticePeriodMinus.Text);
            cmd.Parameters.Add("@FullAndFinalAmount", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(lblFullAndFinalAmount.Text);
            cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["Empcode"];


            cmd.Parameters.Add("@pfpay", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtpfpay.Text);
            cmd.Parameters.Add("@esipay", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtesipay.Text);
            cmd.Parameters.Add("@Stationary", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtStationary.Text);
            cmd.Parameters.Add("@TWCC", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtTWCC.Text);
            cmd.Parameters.Add("@NoticePd", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtNoticePd.Text);
            cmd.Parameters.Add("@PowerConsumed", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtPowerConsumed.Text);
            cmd.Parameters.Add("@GMI", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtGMI.Text);
            cmd.Parameters.Add("@QuaterMaintenece", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtQuaterMaintenece.Text);
            cmd.Parameters.Add("@AdvanceStaff", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtAdvanceStaff.Text);
            cmd.Parameters.Add("@StaffAdvanceExpense", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtStaffAdvanceExpense.Text);
            cmd.Parameters.Add("@Ltastaff", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtLtastaff.Text);
            cmd.Parameters.Add("@TDSpay", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtTDSpay.Text);

            cmd.ExecuteNonQuery();
            string script = "alert('Record  Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            clearAll();
            lnkFreeze.Enabled = true;
            txttodays.Text = "";
            txtPaydays.Text = "";
            txtEmployee.Text = "";

        }
        catch (Exception ex)
        {

            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        con.Close();
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_FullAndFinal_Entry.aspx");
    }

   

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Jct_Payroll_FullAndFinal_Entry_ReportFirst.aspx");
    //}

    protected void txtLeaveNo_TextChanged(object sender, EventArgs e)
    {        
        clearcon();
        calculateLeaveAmount();
        txtNoticePeriodAdd.Text = "0";
        txtNoticePeriodMinus.Text = "0";
    }

    public void calculateLeaveAmount()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string sql = "Jct_Payroll_FullAndFinalCal_CalLeaveAmount";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@Days", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtLeaveNo.Text);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtLeaveAmount.Text = dr["Amt"].ToString();
            }
            dr.Close();
        }
        con.Close();
    }

    public void caltotfullandfinal()
    {

        if (string.IsNullOrEmpty(lblNetSalary.Text))
        {
            lblNetSalary.Text = "0";
        }

        if (string.IsNullOrEmpty(lblGratiuity.Text))
        {
            lblGratiuity.Text = "0";
        }

        if (string.IsNullOrEmpty(txtLeaveAmount.Text))
        {
            txtLeaveAmount.Text = "0";
        }

        if (string.IsNullOrEmpty(txtNoticePeriodAdd.Text))
        {
            txtNoticePeriodAdd.Text = "0";
        }

        if (string.IsNullOrEmpty(txtNoticePeriodMinus.Text))
        {
            txtNoticePeriodMinus.Text = "0";
        }

        if (string.IsNullOrEmpty(lblpfd.Text))
        {
            lblpfd.Text = "0";
        }

        if (string.IsNullOrEmpty(lblesid.Text))
        {
            lblesid.Text = "0";
        }


       if (string.IsNullOrEmpty(txtpfpay.Text))
        {
            txtpfpay.Text = "0";
        }

        if (string.IsNullOrEmpty(txtesipay.Text))
        {
            txtesipay.Text = "0";
        }

        if (string.IsNullOrEmpty(txtStationary.Text))
        {
            txtStationary.Text = "0";
        }

        if (string.IsNullOrEmpty(txtTWCC.Text))
        {
            txtTWCC.Text = "0";
        }

        if (string.IsNullOrEmpty(txtNoticePd.Text))
        {
            txtNoticePd.Text = "0";
        }

        if (string.IsNullOrEmpty(txtPowerConsumed.Text))
        {
            txtPowerConsumed.Text = "0";
        }

        if (string.IsNullOrEmpty(txtGMI.Text))
        {
            txtGMI.Text = "0";
        }

        if (string.IsNullOrEmpty(txtQuaterMaintenece.Text))
        {
            txtQuaterMaintenece.Text = "0";
        }

        if (string.IsNullOrEmpty(txtAdvanceStaff.Text))
        {
            txtAdvanceStaff.Text = "0";
        }

        if (string.IsNullOrEmpty(txtStaffAdvanceExpense.Text))
        {
            txtStaffAdvanceExpense.Text = "0";
        }


        if (string.IsNullOrEmpty(txtLtastaff.Text))
        {
            txtLtastaff.Text = "0";
        }

        if (string.IsNullOrEmpty(txtTDSpay.Text))
        {
            txtTDSpay.Text = "0";
        }


        //lblFullAndFinalAmount.Text = ((Convert.ToDecimal(lblNetSalary.Text) + Convert.ToDecimal(lblGratiuity.Text) + Convert.ToDecimal(txtLeaveAmount.Text)
        //    + Convert.ToDecimal(txtNoticePeriodAdd.Text)) - (Convert.ToDecimal(txtNoticePeriodMinus.Text) +
        //    Convert.ToDecimal(lblpfd.Text) +
        //    Convert.ToDecimal(lblesid.Text)
        //    )).ToString();
        //lnkapply.Enabled = true;

        lblFullAndFinalAmount.Text = ((Convert.ToDecimal(lblNetSalary.Text) + Convert.ToDecimal(lblGratiuity.Text) + Convert.ToDecimal(txtLeaveAmount.Text)
    + Convert.ToDecimal(txtNoticePeriodAdd.Text)) - (Convert.ToDecimal(txtNoticePeriodMinus.Text) +
    Convert.ToDecimal(lblpfd.Text) +
    Convert.ToDecimal(lblesid.Text) +

    Convert.ToDecimal(txtpfpay.Text) +
    Convert.ToDecimal(txtesipay.Text) +
    Convert.ToDecimal(txtStationary.Text) +
    Convert.ToDecimal(txtTWCC.Text) +
    Convert.ToDecimal(txtNoticePd.Text) +
    Convert.ToDecimal(txtPowerConsumed.Text) +
    Convert.ToDecimal(txtGMI.Text) +
    Convert.ToDecimal(txtQuaterMaintenece.Text) +
    Convert.ToDecimal(txtAdvanceStaff.Text) +
    Convert.ToDecimal(txtStaffAdvanceExpense.Text) +
    Convert.ToDecimal(txtLtastaff.Text) +
    Convert.ToDecimal(txtTDSpay.Text) 
    )).ToString();
        lnkapply.Enabled = true;
    }

    protected void lnkCheck_Click(object sender, EventArgs e)
    {     
        if (string.IsNullOrEmpty(lblNetSalary.Text))
        {
            string script = "alert('Net Salary Cannot Be Blank.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;            
        }        
        caltotfullandfinal();
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    public void clearcon()
    {
        lblFullAndFinalAmount.Text = ""; 
        //lblNetSalary.Text = "";
        //lblGratiuity.Text = ""; 
        txtLeaveAmount.Text = "";
        txtLeaveNo.Text = "";
        txtNoticePeriodAdd.Text = "";
        txtNoticePeriodMinus.Text = "";

        txtpfpay.Text = "";
        txtesipay.Text = "";
        txtStationary.Text = "";
        txtTWCC.Text = "";
        txtNoticePd.Text = "";
        txtPowerConsumed.Text = "";
        txtGMI.Text = "";
        txtQuaterMaintenece.Text = "";
        txtAdvanceStaff.Text = "";
        txtStaffAdvanceExpense.Text = "";

        txtLtastaff.Text = "";
        txtTDSpay.Text = "";


    

        //lblpfd.Text=""; 
        //lblesid.Text="";           
    }

    public void clearAll()
    {
        Panel3.Visible = false;
        Panel4.Visible = false;
        grdDetail.DataSource = null;
        grdDetail.DataBind();
        lblFullAndFinalAmount.Text = "";
        lblNetSalary.Text = "";
        lblGratiuity.Text = ""; 
        txtLeaveAmount.Text = "";
        txtLeaveNo.Text = "";
        txtNoticePeriodAdd.Text = "";
        txtNoticePeriodMinus.Text = "";
        lblpfd.Text = "";
        lblesid.Text = "";

        txtpfpay.Text = "";
        txtesipay.Text = "";
        txtStationary.Text = "";
        txtTWCC.Text = "";
        txtNoticePd.Text = "";
        txtPowerConsumed.Text = "";
        txtGMI.Text = "";
        txtQuaterMaintenece.Text = "";
        txtAdvanceStaff.Text = "";
        txtStaffAdvanceExpense.Text = "";

        txtLtastaff.Text = "";
        txtTDSpay.Text = "";
    }

    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        try
        {
            sql = "Jct_Payroll_FullAndFinalCal_Freeze";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empcode1", SqlDbType.VarChar, 30).Value = txtEmployee.Text;            
            cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["Empcode"];
            cmd.ExecuteNonQuery();
            string script = "alert('Record  Freezed Successfully.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            clearAll();
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            txttodays.Text = "";
            txtPaydays.Text = "";
            txtEmployee.Text = "";
        }
        catch (Exception ex)
        {           
            string script = "alert('Record  Not Freezed.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        con.Close();
    }

    protected void txtEmployee_TextChanged1(object sender, EventArgs e)
    {
        try
        {
            clearAll();
            CheckEnteredRecord();
            //txttodays.Text = "";
            //txtPaydays.Text = "";
            
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    protected void lnkdel_Click(object sender, EventArgs e)
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        try
        {
            sql = "Jct_Payroll_FullAndFinalCal_Del";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empcode1", SqlDbType.VarChar, 30).Value = txtEmployee.Text;            
            cmd.ExecuteNonQuery();
            string script = "alert('Record  Deleted Successfully.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            clearAll();
            lnkCheck.Enabled = false;
            lnkapply.Enabled = false;
            lnkFreeze.Enabled = false;
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            txttodays.Text = "";
            txtPaydays.Text = "";
            txtEmployee.Text = "";
          
        }
        catch (Exception ex)
        {

            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        con.Close();
    }

    protected void lnkUnfreeze_Click(object sender, EventArgs e)
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        try
        {
            sql = "Jct_Payroll_FullAndFinalCal_UnFreeze";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empcode1", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
            cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["Empcode"];
            cmd.ExecuteNonQuery();
            string script = "alert('Record UnFreezed Successfully.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            clearAll();
            grdDetail.DataSource = null;
            grdDetail.DataBind();
            txttodays.Text = "";
            txtPaydays.Text = "";
            txtEmployee.Text = "";
        }
        catch (Exception ex)
        {
            string script = "alert('Record  Not UnFreezed.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        con.Close();
    }
}