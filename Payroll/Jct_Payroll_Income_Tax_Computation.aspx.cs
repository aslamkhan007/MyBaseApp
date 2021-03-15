using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Payroll_Jct_Payroll_Income_Tax_Computation : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();           
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

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    Response.ContentType = "application/pdf";
    //    Response.AddHeader("content-disposition", "application;filename=report.pdf");
    //    //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    StringWriter sw = new StringWriter();
    //    HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    pnlPerson.RenderControl(hw);
    //    StringReader sr = new StringReader(sw.ToString());
    //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
    //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //    pdfDoc.Open();
    //    htmlparser.Parse(sr);
    //    pdfDoc.Close();
    //    Response.Write(pdfDoc);
    //    Response.End();
    //}
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

    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("JCt_Payroll_TaxComputation_view", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        //cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = "r-03339";   
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;                 
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                Label1.Text = dr["YearlySalary"].ToString();
                Label2.Text = dr["OtherAlw"].ToString();
                Label3.Text = dr["HouseRent"].ToString();
                Label4.Text = dr["EntAlw"].ToString();
                Label6.Text = dr["Total6"].ToString();
                Label7.Text = dr["HouseRent1"].ToString();
                Label8.Text = dr["RentPaid"].ToString();
                //Label8.Text = dr[8].ToString();
                Label9.Text = dr["Salary10"].ToString();
                Label10.Text = dr["Agg10"].ToString();

                Label11.Text = dr["Hra4050"].ToString();
                Label12.Text = dr["HRAexempted"].ToString();

                //Label14.Text = dr["YearlyUniAlow"].ToString();
                //Label15.Text = dr["Total7"].ToString();
                Label16.Text = dr["Total8"].ToString();
                Label17.Text = dr["Accom75"].ToString();
                Label18.Text = dr["Furinture"].ToString();
                //Label19.Text = dr[17].ToString();
                Label20.Text = dr["Water"].ToString();
                //Label21.Text = dr[19].ToString();
                Label22.Text = dr["LTA"].ToString();


                Label24.Text = dr["Conveyance"].ToString();
                Label25.Text = dr["CarInsurance"].ToString();
                Label26.Text = dr["GratuityIntrestDiff"].ToString();
                Label27.Text = dr["TotalPerks"].ToString();

                //Label28.Text = dr["TotalPerks1"].ToString();

                Label29.Text = dr["Total10"].ToString();
                Label30.Text = dr["Otherincome"].ToString();
                Label31.Text = dr["StdDed"].ToString();
                Label32.Text = dr["Total13"].ToString();

                Label50248.Text = dr["lic"].ToString();
                Label33.Text = dr["Units"].ToString();
                Label34.Text = dr["PFVPF"].ToString();
                Label35.Text = dr["PPF"].ToString();
                // Label36.Text = dr["nsc8"].ToString();
                Label37.Text = dr["nsc8"].ToString();
                Label38.Text = dr["SENIOR"].ToString();
                Label39.Text = dr["HLA"].ToString();
                Label40.Text = dr["Infra"].ToString();
                Label50249.Text = dr["PensionFund"].ToString();

                Label41.Text = dr["SchoolFees"].ToString();
                Label42.Text = dr["Total15"].ToString();
                Label43.Text = dr["Total16"].ToString();
                Label44.Text = dr["test1"].ToString();

                Label45.Text = dr["MedicalInsurance"].ToString();
                Label46.Text = dr["HandiDep"].ToString();
                Label47.Text = dr["HigherEduc"].ToString();
                Label48.Text = dr["PMFund"].ToString();
                Label49.Text = dr["HandiEmp"].ToString();
                Label50.Text = dr["NPS"].ToString();
                Label51.Text = dr["Total23"].ToString();
                Label52.Text = dr["TaxableIncome24"].ToString();

                Label53.Text = dr["TaxableIncome"].ToString();
                Label54.Text = dr["Reb87A"].ToString();
                Label55.Text = dr["cess4per"].ToString();
                Label71.Text = dr["SURCHARGE"].ToString();
                Label56.Text = dr["TotalTaxCess"].ToString();
                Label57.Text = dr["Comput_29TotIncomeTaxAmt"].ToString();
                Label58.Text = dr["Comput_29ATaxDeducted"].ToString();
                Label59.Text = dr["Balance"].ToString();
                Label60.Text = dr["TaxInstallment"].ToString();
                Label61.Text = dr["CessInstalment"].ToString();
                Label62.Text = dr["refund"].ToString();
                Label63.Text = dr["EMPTAX"].ToString();   
             
                //Label64.Text = dr[59].ToString();
                Label67.Text = dr["Empcode"].ToString();
                Label66.Text = dr["FYPeriod"].ToString();
                Label68.Text = dr["EmployeeName"].ToString();
                Label69.Text = dr["Designation"].ToString();
                Label70.Text = dr["Department"].ToString();
                


                // New Additions Added for New tx calcuation 
                Label5001.Text = dr["Total6N"].ToString();
                Label5002.Text = dr["Total8N"].ToString();
                Label5003.Text = dr["ConveyanceN"].ToString();
                Label5004.Text = dr["Total10N"].ToString();


                Label5005.Text = dr["StdDedN"].ToString();
                Label5006.Text = dr["Total13N"].ToString();
                Label5007.Text = dr["Total15N"].ToString();
                Label5008.Text = dr["Total16N"].ToString();

                Label5009.Text = dr["Total23N"].ToString();

                //Label5010.Text = dr["TotPFSupAmtN"].ToString();

                Label5011.Text = dr["TaxablePFSupN"].ToString();

                Labelrepeat.Text = dr["TaxablePFSupN"].ToString();

                /// new 

                Label5012.Text = dr["TaxableIncomen"].ToString();

                Label5013.Text = dr["Reb87An"].ToString();

                Label5014.Text = dr["cess4pern"].ToString();

                Label5015.Text = dr["SURCHARGEn"].ToString();

                Label5016.Text = dr["TotalTaxCessn"].ToString();

                Label5017.Text = dr["Comput_29TotIncomeTaxAmtn"].ToString();

                Label5018.Text = dr["Comput_29ATaxDeductedn"].ToString();

                Label5019.Text = dr["Balancen"].ToString();

                Label5020.Text = dr["TaxInstallmentn"].ToString();

                Label5021.Text = dr["CessInstalmentn"].ToString();

                Label5022.Text = dr["refundn"].ToString();
                //Label5023.Text = dr["EMPTAXn"].ToString();  14 dec 2020 by lovelesh

                Label50241.Text = dr["GratuityIntrestDiff"].ToString();
                Label50242.Text = dr["Accom75"].ToString();
                Label50243.Text = dr["Furinture"].ToString();
                Label50244.Text = dr["Water"].ToString();
                Label50245.Text = dr["LTA"].ToString();
                Label50246.Text = dr["CarInsurance"].ToString();

                Label50247.Text = dr["TotalPerksN"].ToString();

                //Label14.Text = dr[41].ToString();
                //Label14.Text = dr[42].ToString();
                //Label7.Text = dr[43].ToString();
                //Label8.Text = dr[44].ToString();
                //Label9.Text = dr[45].ToString();
                //Label10.Text = dr[46].ToString();
                //Label11.Text = dr[47].ToString();
                //Label12.Text = dr[48].ToString();
                //Label14.Text = dr[49].ToString();
                //Label14.Text = dr[50].ToString();


                //Label15.Text = dr[51].ToString();
                //Label15.Text = dr[52].ToString();
                //Label7.Text = dr[53].ToString();
                //Label8.Text = dr[54].ToString();
                //Label9.Text = dr[55].ToString();
                //Label10.Text = dr[56].ToString();
                //Label11.Text = dr[57].ToString();
                //Label12.Text = dr[58].ToString();
                //Label15.Text = dr[59].ToString();
                //Label15.Text = dr[60].ToString();




                //Label1.Text = dr["YearlySalary"].ToString();
                //Label2.Text = dr["OtherAlw"].ToString();
                //Label3.Text = dr["HouseRent"].ToString();
                //Label4.Text = dr["EntertainmentAllowance"].ToString();
                //Label6.Text = dr["Comput_Sr6"].ToString();
                //Label7.Text = dr["YearlyHraAlow"].ToString();
                //Label8.Text = dr["Comput_RentPaid"].ToString();
                ////Label9.Text = dr["rent"].ToString();
                //Label10.Text = dr["Comput_HRA4050Per"].ToString();

                ////Label11.Text = dr["EmployeeName"].ToString();
                //Label12.Text = dr["YearlyTrptAlw"].ToString();
                //Label13.Text = dr["YearlyUniAlow"].ToString();
                //Label14.Text = dr["Comput_Sr8"].ToString();
                //Label15.Text = dr["Comput_AccomdationAmt"].ToString();
                //Label16.Text = dr["Perk_furniture"].ToString();
                ////Label17.Text = dr["EmployeeName"].ToString();
                //Label18.Text = dr["Comput_WaterAmt"].ToString();
                ////Label19.Text = dr["EmployeeName"].ToString();
                //Label20.Text = dr["ER_LTATaxable"].ToString();

                ////Label21.Text = dr["EmployeeName"].ToString();
                //Label22.Text = dr["Comput_ConveyanceAmt"].ToString();
                //Label23.Text = dr["ER_CarInsurance"].ToString();
                ////Label24.Text = dr["EmployeeName"].ToString();
                //Label25.Text = dr["Comput_Sr10GrossIncome"].ToString();
                ////Label26.Text = dr["EmployeeName"].ToString();
                ////Label27.Text = dr["EmployeeName"].ToString();
                ////Label28.Text = dr["EmployeeName"].ToString();
                ////Label29.Text = dr["EmployeeName"].ToString();
                ////Label30.Text = dr["EmployeeName"].ToString();

                ////Label31.Text = dr["EmployeeName"].ToString();
                ////Label32.Text = dr["EmployeeName"].ToString();
                ////Label33.Text = dr["EmployeeName"].ToString();
                //Label34.Text = dr["LifeInsuranceCorporation"].ToString();
                //Label35.Text = dr["UNITLN"].ToString();
                ////Label36.Text = dr["EmployeeName"].ToString();
                //Label37.Text = dr["PublicProvidentFund"].ToString();
                //Label38.Text = dr["NationalSavingCertificate8"].ToString();
                ////Label39.Text = dr["EmployeeName"].ToString();
                ////Label40.Text = dr["EmployeeName"].ToString();

                //Label41.Text = dr["HouseingLoanPayment"].ToString();
                //Label42.Text = dr["INFRA"].ToString();
                //Label43.Text = dr["SchoolFees"].ToString();
                //Label44.Text = dr["PensionFund"].ToString();
                //Label45.Text = dr["Comput_Sr15TotDeclaration"].ToString();
                //Label46.Text = dr["Comput_Sr16DeclarationAmt"].ToString();
                //Label47.Text = dr["Infra"].ToString();
                //Label48.Text = dr["Medical_Insurance"].ToString();
                //Label49.Text = dr["HandicapDependent"].ToString();
                //Label50.Text = dr["HigherEduction"].ToString();

                //Label51.Text = dr["PrimeMinisterFund"].ToString();
                //Label52.Text = dr["HandicapEmployee"].ToString();
                ////Label53.Text = dr["EmployeeName"].ToString();
                //Label54.Text = dr["Comput_Sr23AdmisableDed"].ToString();
                //Label55.Text = dr["Comput_Sr24NetTaxIncome"].ToString();
                //Label56.Text = dr["Comput_Sr24iReb87A"].ToString();
                //Label57.Text = dr["Comput_IncomeTaxAmt"].ToString();
                //Label58.Text = dr["Comput_EcessAmt"].ToString();
                //Label59.Text = dr["Comput_HcessAmt"].ToString();
                //Label60.Text = dr["Comput_29TotIncomeTaxAmt"].ToString();

                //Label61.Text = dr["Comput_29TotIncomeTaxAmt"].ToString();
                //Label62.Text = dr["Comput_29ATaxDeducted"].ToString();
                //Label63.Text = dr["Comput_29BBalafterTaxDeducted"].ToString();
                //Label64.Text = dr["Comput_29DITInstallment"].ToString();
                //Label65.Text = dr["Comput_29EInstallmentCess"].ToString();
                //Label66.Text = dr["Comput_29FInstallmentHcess"].ToString();
                ////Label67.Text = dr["EmployeeName"].ToString();
                ////Label68.Text = dr["EmployeeName"].ToString();
            }
        }
        dr.Close();
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Income_Tax_Computation.aspx");
    }
}