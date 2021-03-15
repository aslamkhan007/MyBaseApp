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

public partial class Payroll_Jct_Payroll_TaxDeclaration_Entry : System.Web.UI.Page
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
            AttendenceDate();
        }
    }

    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Current_FIYear";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodate.Text = dr["FIYear"].ToString();
            }
            dr.Close();
        }
    }

    //private void CurrencyList(DropDownList e)
    //{
    //    sql = "Jct_Payroll_Plantlist_Fetch";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    (e as DropDownList).DataSource = ds;
    //    (e as DropDownList).DataTextField = "LongDescription";
    //    (e as DropDownList).DataValueField = "PlantCode";
    //    (e as DropDownList).DataBind();
    //}

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
            FetchRecord();
            Panel4.Visible = true;
            Panel1.Visible = true;
            lnkapply.Enabled = true;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("JCt_Payroll_TaxComputation_Entry_DataFormation", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 10).Value = txttodate.Text;
        cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        FlagCheck = cmd.Parameters["@Flag"].Value.ToString();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();

        if (FlagCheck == "Old")
        {
            lnkapply.Text = "Update";
        }
        else if (FlagCheck == "New")
        {
            lnkapply.Text = "Save";
            string script = "alert('No Record Found.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                string bank = gvRow.Cells[0].Text;

                TextBox txt1 = (TextBox)gvRow.FindControl("txtAccnum");
                TextBox HandicapEmployee = (TextBox)gvRow.FindControl("txtHandicapEmployee");
                TextBox HandicapDependent = (TextBox)gvRow.FindControl("txtHandicapDependent");
                TextBox PublicProvidentFund = (TextBox)gvRow.FindControl("txtPublicProvidentFund");
                TextBox LifeInsuranceCorporation = (TextBox)gvRow.FindControl("txtLifeInsuranceCorporation");
                TextBox NationalSavingCertificate8 = (TextBox)gvRow.FindControl("txtNationalSavingCertificate8");
                TextBox HouseingLoanPayment = (TextBox)gvRow.FindControl("txtHouseingLoanPayment");
                TextBox INFRA = (TextBox)gvRow.FindControl("txtINFRA");
                TextBox UNITLN = (TextBox)gvRow.FindControl("txtUNITLN");
                TextBox Medical_Insurance = (TextBox)gvRow.FindControl("txtMedical_Insurance");
                TextBox SENIOR = (TextBox)gvRow.FindControl("txtSENIOR");
                TextBox NPS = (TextBox)gvRow.FindControl("txtNPS");
                TextBox PrimeMinisterFund = (TextBox)gvRow.FindControl("txtPrimeMinisterFund");
                TextBox HigherEduction = (TextBox)gvRow.FindControl("txtHigherEduction");
                TextBox SchoolFees = (TextBox)gvRow.FindControl("txtSchoolFees");
                TextBox OtherIncome = (TextBox)gvRow.FindControl("txtOtherIncome");
                TextBox ER_LeaveEncashment = (TextBox)gvRow.FindControl("txtER_LeaveEncashment");
                TextBox ER_CarInsurance = (TextBox)gvRow.FindControl("txtER_CarInsurance");
                TextBox ER_Bonus = (TextBox)gvRow.FindControl("txtER_Bonus");
                TextBox ER_LTATaxable = (TextBox)gvRow.FindControl("txtER_LTATaxable");
                TextBox ER_LTANonTaxable = (TextBox)gvRow.FindControl("txtER_LTANonTaxable");
                TextBox EntertainmentAllowance = (TextBox)gvRow.FindControl("txtEntertainmentAllowance");
                TextBox LTADATE = (TextBox)gvRow.FindControl("txtLTADATE");
                TextBox LTA_IT = (TextBox)gvRow.FindControl("txtLTA_IT");
                //TextBox Income = (TextBox)gvRow.FindControl("txtIncome");

                //TextBox TaxableAmount = (TextBox)gvRow.FindControl("txtTaxableAmount");
                //TextBox TaxTotal = (TextBox)gvRow.FindControl("txtTaxTotal");
                //TextBox Cess = (TextBox)gvRow.FindControl("txtCess");
                //TextBox SH_Cess = (TextBox)gvRow.FindControl("txtSH_Cess");
                //TextBox Taxded = (TextBox)gvRow.FindControl("txtTaxded");
                //TextBox IncomeTax = (TextBox)gvRow.FindControl("txtIncomeTax");
                //TextBox Taxslab = (TextBox)gvRow.FindControl("txtTaxslab");
                //TextBox Taxrefund = (TextBox)gvRow.FindControl("txtTaxrefund");
                //TextBox Taxinst = (TextBox)gvRow.FindControl("txtTaxinst");
                //TextBox CesInst = (TextBox)gvRow.FindControl("txtCesInst");
                //TextBox SH_CesInst = (TextBox)gvRow.FindControl("txtSH_CesInst");
                //TextBox Rebate_87A = (TextBox)gvRow.FindControl("txtRebate_87A");

                TextBox Amedical = (TextBox)gvRow.FindControl("txtAmedical");
                TextBox ALeave = (TextBox)gvRow.FindControl("txtALeave");
                TextBox Agratuity = (TextBox)gvRow.FindControl("txtAgratuity");
                TextBox AllowSer = (TextBox)gvRow.FindControl("txtAllowSer");
                TextBox LeaveTax = (TextBox)gvRow.FindControl("txtLeaveTax");
                TextBox WomenRebate = (TextBox)gvRow.FindControl("txtWomenRebate");
                TextBox PensionFund = (TextBox)gvRow.FindControl("txtPensionFund");
                //TextBox Mth_Cal = (TextBox)gvRow.FindControl("txtMth_Cal");
                //TextBox Aret_Comp = (TextBox)gvRow.FindControl("txtAret_Comp");
                TextBox CashIncentive = (TextBox)gvRow.FindControl("txtCashIncentive");
                TextBox ER_FinalLvEncash = (TextBox)gvRow.FindControl("txtER_FinalLvEncash");
                //CurrencyList(rblChoices);
                //ParamFields(bank, txt1, HandicapEmployee, HandicapDependent, PublicProvidentFund, LifeInsuranceCorporation, NationalSavingCertificate8, HouseingLoanPayment, INFRA, UNITLN, Medical_Insurance, SENIOR, NPS, PrimeMinisterFund, HigherEduction, SchoolFees, OtherIncome, ER_LeaveEncashment, ER_CarInsurance, ER_Bonus, ER_LTATaxable, ER_LTANonTaxable, EntertainmentAllowance, LTADATE,LTA_IT,Income, TaxableAmount, TaxTotal, Cess, SH_Cess, Taxded, IncomeTax, Taxslab, Taxrefund, Taxinst, CesInst, SH_CesInst, Rebate_87A, Amedical, ALeave, Agratuity, AllowSer, LeaveTax, WomenRebate, PensionFund, Mth_Cal, Aret_Comp, CashIncentive, ER_FinalLvEncash);
                ParamFields(bank, txt1, HandicapEmployee, HandicapDependent, PublicProvidentFund, LifeInsuranceCorporation, NationalSavingCertificate8, HouseingLoanPayment, INFRA, UNITLN, Medical_Insurance, SENIOR, NPS, PrimeMinisterFund, HigherEduction, SchoolFees, OtherIncome, ER_LeaveEncashment, ER_CarInsurance, ER_Bonus, ER_LTATaxable, ER_LTANonTaxable, EntertainmentAllowance, LTADATE, LTA_IT, Amedical, ALeave, Agratuity, AllowSer, LeaveTax, WomenRebate, PensionFund, CashIncentive, ER_FinalLvEncash);
            }
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    //public void ParamFields(string Empcode, TextBox b, TextBox HandicapEmployee, TextBox HandicapDependent, TextBox PublicProvidentFund, TextBox LifeInsuranceCorporation, TextBox NationalSavingCertificate8, TextBox HouseingLoanPayment, TextBox INFRA, TextBox UNITLN, TextBox Medical_Insurance, TextBox SENIOR, TextBox NPS, TextBox PrimeMinisterFund, TextBox HigherEduction, TextBox SchoolFees, TextBox OtherIncome, TextBox ER_LeaveEncashment, TextBox ER_CarInsurance, TextBox ER_Bonus, TextBox ER_LTATaxable, TextBox ER_LTANonTaxable, TextBox EntertainmentAllowance, TextBox LTADATE, TextBox LTA_IT, TextBox Income, TextBox TaxableAmount, TextBox TaxTotal, TextBox Cess, TextBox SH_Cess, TextBox Taxded, TextBox IncomeTax, TextBox Taxslab, TextBox Taxrefund, TextBox Taxinst, TextBox CesInst, TextBox SH_CesInst, TextBox Rebate_87A, TextBox Amedical, TextBox ALeave, TextBox Agratuity, TextBox AllowSer, TextBox LeaveTax, TextBox WomenRebate, TextBox PensionFund, TextBox Mth_Cal, TextBox Aret_Comp, TextBox CashIncentive, TextBox ER_FinalLvEncash)
    public void ParamFields(string Empcode, TextBox b, TextBox HandicapEmployee, TextBox HandicapDependent, TextBox PublicProvidentFund, TextBox LifeInsuranceCorporation, TextBox NationalSavingCertificate8, TextBox HouseingLoanPayment, TextBox INFRA, TextBox UNITLN, TextBox Medical_Insurance, TextBox SENIOR, TextBox NPS, TextBox PrimeMinisterFund, TextBox HigherEduction, TextBox SchoolFees, TextBox OtherIncome, TextBox ER_LeaveEncashment, TextBox ER_CarInsurance, TextBox ER_Bonus, TextBox ER_LTATaxable, TextBox ER_LTANonTaxable, TextBox EntertainmentAllowance, TextBox LTADATE, TextBox LTA_IT, TextBox Amedical, TextBox ALeave, TextBox Agratuity, TextBox AllowSer, TextBox LeaveTax, TextBox WomenRebate, TextBox PensionFund, TextBox CashIncentive, TextBox ER_FinalLvEncash)
    {
        SqlCommand cmd = new SqlCommand("JCt_Payroll_TaxComputation_Entry_DataFormation", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 10).Value = txttodate.Text;
        cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                (b as TextBox).Text = dr["HouseRentAffidevt"].ToString();
                (HandicapEmployee as TextBox).Text = dr["HandicapEmployee"].ToString();
                (HandicapDependent as TextBox).Text = dr["HandicapDependent"].ToString();
                (PublicProvidentFund as TextBox).Text = dr["PublicProvidentFund"].ToString();
                (LifeInsuranceCorporation as TextBox).Text = dr["LifeInsuranceCorporation"].ToString();
                (NationalSavingCertificate8 as TextBox).Text = dr["NationalSavingCertificate8"].ToString();
                (HouseingLoanPayment as TextBox).Text = dr["HouseingLoanPayment"].ToString();
                (INFRA as TextBox).Text = dr["INFRA"].ToString();
                (UNITLN as TextBox).Text = dr["UNITLN"].ToString();
                (Medical_Insurance as TextBox).Text = dr["Medical_Insurance"].ToString();
                (SENIOR as TextBox).Text = dr["SENIOR"].ToString();
                (NPS as TextBox).Text = dr["NPS"].ToString();
                (PrimeMinisterFund as TextBox).Text = dr["PrimeMinisterFund"].ToString();
                (HigherEduction as TextBox).Text = dr["HigherEduction"].ToString();
                (SchoolFees as TextBox).Text = dr["SchoolFees"].ToString();
                (OtherIncome as TextBox).Text = dr["OtherIncome"].ToString();
                (ER_LeaveEncashment as TextBox).Text = dr["ER_LeaveEncashment"].ToString();
                (ER_CarInsurance as TextBox).Text = dr["ER_CarInsurance"].ToString();
                (ER_Bonus as TextBox).Text = dr["ER_Bonus"].ToString();
                (ER_LTATaxable as TextBox).Text = dr["ER_LTATaxable"].ToString();
                (ER_LTANonTaxable as TextBox).Text = dr["ER_LTANonTaxable"].ToString();
                (EntertainmentAllowance as TextBox).Text = dr["EntertainmentAllowance"].ToString();
                (LTADATE as TextBox).Text = dr["LTADATE"].ToString();
                (LTA_IT as TextBox).Text = dr["LTA_IT"].ToString();
                //(Income as TextBox).Text = dr["Income"].ToString();

                //(TaxableAmount as TextBox).Text = dr["TaxableAmount"].ToString();
                //(TaxTotal as TextBox).Text = dr["TaxTotal"].ToString();
                //(Cess as TextBox).Text = dr["Cess"].ToString();
                //(SH_Cess as TextBox).Text = dr["SH_Cess"].ToString();
                //(Taxded as TextBox).Text = dr["Taxded"].ToString();
                //(IncomeTax as TextBox).Text = dr["IncomeTax"].ToString();
                //(Taxslab as TextBox).Text = dr["Taxslab"].ToString();
                //(Taxrefund as TextBox).Text = dr["Taxrefund"].ToString();
                //(Taxinst as TextBox).Text = dr["Taxinst"].ToString();
                //(CesInst as TextBox).Text = dr["CesInst"].ToString();
                //(SH_CesInst as TextBox).Text = dr["SH_CesInst"].ToString();
                //(Rebate_87A as TextBox).Text = dr["Rebate_87A"].ToString();

                (Amedical as TextBox).Text = dr["Amedical"].ToString();
                (ALeave as TextBox).Text = dr["ALeave"].ToString();
                (Agratuity as TextBox).Text = dr["Agratuity"].ToString();
                (AllowSer as TextBox).Text = dr["AllowSer"].ToString();
                (LeaveTax as TextBox).Text = dr["LeaveTax"].ToString();
                (PensionFund as TextBox).Text = dr["PensionFund"].ToString();
                (WomenRebate as TextBox).Text = dr["WomenRebate"].ToString();
                //(Mth_Cal as TextBox).Text = dr["Mth_Cal"].ToString();
                //(Aret_Comp as TextBox).Text = dr["Aret_Comp"].ToString();
                (CashIncentive as TextBox).Text = dr["CashIncentive"].ToString();
                (ER_FinalLvEncash as TextBox).Text = dr["ER_FinalLvEncash"].ToString();
            }
        }
        dr.Close();
    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                //TextBox txt1 = (TextBox)rw.FindControl("txtAccnum");
                TextBox txt1 = (TextBox)gvRow.FindControl("txtAccnum");
                TextBox HandicapEmployee = (TextBox)gvRow.FindControl("txtHandicapEmployee");
                TextBox HandicapDependent = (TextBox)gvRow.FindControl("txtHandicapDependent");
                TextBox PublicProvidentFund = (TextBox)gvRow.FindControl("txtPublicProvidentFund");
                TextBox LifeInsuranceCorporation = (TextBox)gvRow.FindControl("txtLifeInsuranceCorporation");
                TextBox NationalSavingCertificate8 = (TextBox)gvRow.FindControl("txtNationalSavingCertificate8");
                TextBox HouseingLoanPayment = (TextBox)gvRow.FindControl("txtHouseingLoanPayment");
                TextBox INFRA = (TextBox)gvRow.FindControl("txtINFRA");
                TextBox UNITLN = (TextBox)gvRow.FindControl("txtUNITLN");
                TextBox Medical_Insurance = (TextBox)gvRow.FindControl("txtMedical_Insurance");
                TextBox SENIOR = (TextBox)gvRow.FindControl("txtSENIOR");
                TextBox NPS = (TextBox)gvRow.FindControl("txtNPS");
                TextBox PrimeMinisterFund = (TextBox)gvRow.FindControl("txtPrimeMinisterFund");
                TextBox HigherEduction = (TextBox)gvRow.FindControl("txtHigherEduction");
                TextBox SchoolFees = (TextBox)gvRow.FindControl("txtSchoolFees");
                TextBox OtherIncome = (TextBox)gvRow.FindControl("txtOtherIncome");
                TextBox ER_LeaveEncashment = (TextBox)gvRow.FindControl("txtER_LeaveEncashment");
                TextBox ER_CarInsurance = (TextBox)gvRow.FindControl("txtER_CarInsurance");
                TextBox ER_Bonus = (TextBox)gvRow.FindControl("txtER_Bonus");
                TextBox ER_LTATaxable = (TextBox)gvRow.FindControl("txtER_LTATaxable");
                TextBox ER_LTANonTaxable = (TextBox)gvRow.FindControl("txtER_LTANonTaxable");
                TextBox EntertainmentAllowance = (TextBox)gvRow.FindControl("txtEntertainmentAllowance");
                TextBox LTADATE = (TextBox)gvRow.FindControl("txtLTADATE");
                TextBox LTA_IT = (TextBox)gvRow.FindControl("txtLTA_IT");
                //TextBox Income = (TextBox)gvRow.FindControl("txtIncome");

                //TextBox TaxableAmount = (TextBox)gvRow.FindControl("txtTaxableAmount");
                //TextBox TaxTotal = (TextBox)gvRow.FindControl("txtTaxTotal");
                //TextBox Cess = (TextBox)gvRow.FindControl("txtCess");
                //TextBox SH_Cess = (TextBox)gvRow.FindControl("txtSH_Cess");
                //TextBox Taxded = (TextBox)gvRow.FindControl("txtTaxded");
                //TextBox IncomeTax = (TextBox)gvRow.FindControl("txtIncomeTax");
                //TextBox Taxslab = (TextBox)gvRow.FindControl("txtTaxslab");
                //TextBox Taxrefund = (TextBox)gvRow.FindControl("txtTaxrefund");
                //TextBox Taxinst = (TextBox)gvRow.FindControl("txtTaxinst");
                //TextBox CesInst = (TextBox)gvRow.FindControl("txtCesInst");
                //TextBox SH_CesInst = (TextBox)gvRow.FindControl("txtSH_CesInst");
                //TextBox Rebate_87A = (TextBox)gvRow.FindControl("txtRebate_87A");

                TextBox Amedical = (TextBox)gvRow.FindControl("txtAmedical");
                TextBox ALeave = (TextBox)gvRow.FindControl("txtALeave");
                TextBox Agratuity = (TextBox)gvRow.FindControl("txtAgratuity");
                TextBox AllowSer = (TextBox)gvRow.FindControl("txtAllowSer");
                TextBox LeaveTax = (TextBox)gvRow.FindControl("txtLeaveTax");
                TextBox WomenRebate = (TextBox)gvRow.FindControl("txtWomenRebate");
                TextBox PensionFund = (TextBox)gvRow.FindControl("txtPensionFund");
                //TextBox Mth_Cal = (TextBox)gvRow.FindControl("txtMth_Cal");
                //TextBox Aret_Comp = (TextBox)gvRow.FindControl("txtAret_Comp");
                TextBox CashIncentive = (TextBox)gvRow.FindControl("txtCashIncentive");
                TextBox ER_FinalLvEncash = (TextBox)gvRow.FindControl("txtER_FinalLvEncash");
                if (string.IsNullOrEmpty(txt1.Text))
                {
                    string script = "alert('Please Enter Account Number.!! ');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }
                else
                {
                    sql = "JCt_Payroll_TaxComputation_Entry_Insert";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                    cmd.Parameters.Add("@HouseRentAffidevt", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txt1.Text);
                    cmd.Parameters.Add("@HandicapEmployee", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(HandicapEmployee.Text);
                    cmd.Parameters.Add("@HandicapDependent", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(HandicapDependent.Text);
                    cmd.Parameters.Add("@PublicProvidentFund", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(PublicProvidentFund.Text);
                    cmd.Parameters.Add("@LifeInsuranceCorporation", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(LifeInsuranceCorporation.Text);
                    cmd.Parameters.Add("@NationalSavingCertificate8", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(NationalSavingCertificate8.Text);
                    cmd.Parameters.Add("@HouseingLoanPayment", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(HouseingLoanPayment.Text);
                    cmd.Parameters.Add("@INFRA", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(INFRA.Text);
                    cmd.Parameters.Add("@UNITLN", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(UNITLN.Text);
                    cmd.Parameters.Add("@Medical_Insurance", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(Medical_Insurance.Text);
                    cmd.Parameters.Add("@SENIOR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(SENIOR.Text);
                    cmd.Parameters.Add("@NPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(NPS.Text);
                    cmd.Parameters.Add("@PrimeMinisterFund", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(PrimeMinisterFund.Text);
                    cmd.Parameters.Add("@HigherEduction", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(HigherEduction.Text);
                    cmd.Parameters.Add("@SchoolFees", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(SchoolFees.Text);
                    cmd.Parameters.Add("@OtherIncome", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(OtherIncome.Text);
                    cmd.Parameters.Add("@ER_LeaveEncashment", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(ER_LeaveEncashment.Text);
                    cmd.Parameters.Add("@ER_CarInsurance", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(ER_CarInsurance.Text);
                    cmd.Parameters.Add("@ER_Bonus", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(ER_Bonus.Text);
                    cmd.Parameters.Add("@ER_LTATaxable", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(ER_LTATaxable.Text);
                    cmd.Parameters.Add("@ER_LTANonTaxable", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(ER_LTANonTaxable.Text);
                    cmd.Parameters.Add("@EntertainmentAllowance", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(EntertainmentAllowance.Text);
                    cmd.Parameters.Add("@LTADATE ", SqlDbType.DateTime).Value = Convert.ToDateTime(LTADATE.Text);
                    cmd.Parameters.Add("@LTA_IT", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(LTA_IT.Text);
                    //cmd.Parameters.Add("@Income", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(Income.Text);
                    //cmd.Parameters.Add("@TaxableAmount", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(TaxableAmount.Text);
                    //cmd.Parameters.Add("@TaxTotal", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(TaxTotal.Text);
                    //cmd.Parameters.Add("@Cess", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(Cess.Text);
                    //cmd.Parameters.Add("@SH_Cess", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(SH_Cess.Text);
                    //cmd.Parameters.Add("@Taxded", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(Taxded.Text);
                    //cmd.Parameters.Add("@IncomeTax", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(IncomeTax.Text);
                    //cmd.Parameters.Add("@Taxslab", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(Taxslab.Text);
                    //cmd.Parameters.Add("@Taxrefund", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(Taxrefund.Text);
                    //cmd.Parameters.Add("@Taxinst", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(Taxinst.Text);
                    //cmd.Parameters.Add("@CesInst", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(CesInst.Text);
                    //cmd.Parameters.Add("@SH_CesInst", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(SH_CesInst.Text);
                    //cmd.Parameters.Add("@Rebate_87A", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(Rebate_87A.Text);
                    cmd.Parameters.Add("@Amedical", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(Amedical.Text);
                    cmd.Parameters.Add("@ALeave", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(ALeave.Text);
                    cmd.Parameters.Add("@Agratuity", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(Agratuity.Text);
                    cmd.Parameters.Add("@AllowSer", SqlDbType.Decimal, 7).Value = Convert.ToDecimal(AllowSer.Text);
                    cmd.Parameters.Add("@LeaveTax", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(LeaveTax.Text);
                    cmd.Parameters.Add("@WomenRebate", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(WomenRebate.Text);
                    cmd.Parameters.Add("@PensionFund ", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(PensionFund.Text);
                    //cmd.Parameters.Add("@Mth_Cal", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(Mth_Cal.Text);
                    //cmd.Parameters.Add("@Aret_Comp", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(Aret_Comp.Text);
                    cmd.Parameters.Add("@CashIncentive", SqlDbType.Decimal, 6).Value = Convert.ToDecimal(CashIncentive.Text);
                    cmd.Parameters.Add("@ER_FinalLvEncash", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(ER_FinalLvEncash.Text);
                    cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 10).Value = txttodate.Text;
                    cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                    cmd.ExecuteNonQuery();
                    //bindgrid();
                    if (lnkapply.Text == "Save")
                    {
                        string script = "alert('Record  Saved.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        //lnkapply.Enabled = false;
                    }
                    else if (lnkapply.Text == "Update")
                    {
                        string script = "alert('Record  Updated.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        //lnkapply.Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_TaxDeclaration_Entry.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        Excel();
    }

    public void Excel()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "JCt_Payroll_TaxComputation_ExportData";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; filename=Employee.xls";
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
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Taxdeclaration_Report.aspx");
    }
}