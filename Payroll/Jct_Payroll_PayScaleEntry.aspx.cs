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
using System.Web.Script.Serialization;
using System.Runtime.Remoting.Contexts;

public partial class Payroll_Jct_Payroll_PayScaleEntry : System.Web.UI.Page
{
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Designationbind();
            GenerateCode();
        }
    }

    [System.Web.Services.WebMethod]
    public static int GetCurrentTime(string name)
    {
        //System.Threading.Thread.Sleep(5000);
        int result = 0;
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Master_CheckDesignation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DesgCode", SqlDbType.VarChar, 10).Value = name;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                result = Convert.ToInt16(dr["res"]);
            }
        }
        dr.Close();
        con.Close();
        return result;
    }


    [System.Web.Services.WebMethod]
    //public static Employee def(string txtSearchEmployecode, string txtbasic, string txtHra, string txtColonyAllowance, string txtSpecialAllowance, string txtPersonelAllowance, string txtStablity, string txtJoiningAllowance, string txtTelePhoneAllowance, string txtScooterAllowance, string txtCarAllowance, string txtAdditionalAllowance, string txtUniformAllowance, string txtDriverAllowance, string txtEntertainmentAllowance, string txtTotal1, string ddlHraValue)
    public static Employee def(string txtSearchEmployecode, string txtbasic, string txtHra, string txtColonyAllowance, string txtSpecialAllowance, string txtPersonelAllowance, string txtStablity, string txtJoiningAllowance, string txtTelePhoneAllowance, string txtScooterAllowance, string txtCarAllowance, string txtAdditionalAllowance, string txtUniformAllowance, string txtDriverAllowance, string txtEntertainmentAllowance, string txtTotal1, string ddlHraValue, string txtltaallw, string txtFurAllw, string ddldesignation, string txtCarInsurance)
    {
        Employee employee = new Employee();
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Master_CalFetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SeriesCode", SqlDbType.VarChar, 10).Value = txtSearchEmployecode;
        if (txtbasic != "")
        {
            cmd.Parameters.Add("@Basic", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtbasic);
        }
        else
        {
            cmd.Parameters.Add("@Basic", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtHra != "")
        {
            cmd.Parameters.Add("@Hra", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtHra);
        }
        else
        {
            cmd.Parameters.Add("@Hra", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtColonyAllowance != "")
        {
            cmd.Parameters.Add("@ColonyAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtColonyAllowance);
        }
        else
        {
            cmd.Parameters.Add("@ColonyAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtSpecialAllowance != "")
        {
            cmd.Parameters.Add("@SpecialAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtSpecialAllowance);
        }
        else
        {
            cmd.Parameters.Add("@SpecialAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtPersonelAllowance != "")
        {
            cmd.Parameters.Add("@PersonelAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtPersonelAllowance);
        }
        else
        {
            cmd.Parameters.Add("@PersonelAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtStablity != "")
        {
            cmd.Parameters.Add("@Stability", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtStablity);
        }
        else
        {
            cmd.Parameters.Add("@Stability", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtJoiningAllowance != "")
        {
            cmd.Parameters.Add("@JoiningAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtJoiningAllowance);
        }
        else
        {
            cmd.Parameters.Add("@JoiningAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtTelePhoneAllowance != "")
        {
            cmd.Parameters.Add("@TelephoneAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtTelePhoneAllowance);
        }
        else
        {
            cmd.Parameters.Add("@TelephoneAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtScooterAllowance != "")
        {
            cmd.Parameters.Add("@ScooterAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtScooterAllowance);
        }
        else
        {
            cmd.Parameters.Add("@ScooterAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtCarAllowance != "")
        {
            cmd.Parameters.Add("@CarAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtCarAllowance);
        }
        else
        {
            cmd.Parameters.Add("@CarAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtAdditionalAllowance != "")
        {
            cmd.Parameters.Add("@AdditionalAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtAdditionalAllowance);
        }
        else
        {
            cmd.Parameters.Add("@AdditionalAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtUniformAllowance != "")
        {
            cmd.Parameters.Add("@UniformAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtUniformAllowance);
        }
        else
        {
            cmd.Parameters.Add("@UniformAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtDriverAllowance != "")
        {
            cmd.Parameters.Add("@DriverAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtDriverAllowance);
        }
        else
        {
            cmd.Parameters.Add("@DriverAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtEntertainmentAllowance != "")
        {
            cmd.Parameters.Add("@EntertainmentAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtEntertainmentAllowance);
        }
        else
        {
            cmd.Parameters.Add("@EntertainmentAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtTotal1 != "")
        {
            cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtTotal1);
        }
        else
        {
            cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (ddlHraValue != "")
        {
            cmd.Parameters.Add("@HraPer", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(ddlHraValue);
        }
        else
        {
            cmd.Parameters.Add("@HraPer", SqlDbType.Decimal, 10).Value = 0.0;
        }

        if (txtltaallw != "")
        {
            cmd.Parameters.Add("@LtaAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtltaallw);
        }
        else
        {
            cmd.Parameters.Add("@LtaAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }


        if (txtFurAllw != "")
        {
            cmd.Parameters.Add("@FurAllw", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtFurAllw);
        }
        else
        {
            cmd.Parameters.Add("@FurAllw", SqlDbType.Decimal, 10).Value = 0.0;
        }


        if (ddldesignation != "")
        {
            cmd.Parameters.Add("@Desg", SqlDbType.VarChar, 50).Value = ddldesignation;
        }


        if (txtCarInsurance != "")
        {
            cmd.Parameters.Add("@CarIns", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtCarInsurance);
        }
        else
        {
            cmd.Parameters.Add("@CarIns", SqlDbType.Decimal, 10).Value = 0.0;
        }


        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                if (dr["seriescode"] != "")
                {
                    employee.txtSearchEmployecode = dr["seriescode"].ToString();
                }

                if (dr["PF"] is DBNull == false)
                {
                    if (dr["PF"] != "")
                    {
                        employee.txtPF = Convert.ToDecimal(dr["PF"]);
                    }
                }

                if (dr["ESI"] is DBNull == false)
                {
                    if (dr["ESI"] != "")
                    {

                        employee.txtESI = Convert.ToDecimal(dr["ESI"]);
                    }
                }

                if (dr["Gratuity"] is DBNull == false)
                {
                    if (dr["Gratuity"] != "")
                    {

                        employee.txtGratuity = Convert.ToDecimal(dr["Gratuity"]);
                    }
                }

                if (dr["LTA"] is DBNull == false)
                {
                    if (dr["LTA"] != "")
                    {
                        employee.txtLTA = Convert.ToDecimal(dr["LTA"]);
                    }
                }

                if (dr["Bonus"] is DBNull == false)
                {
                    if (dr["Bonus"] != "")
                    {
                        employee.txtBONUS = Convert.ToDecimal(dr["Bonus"]);
                    }
                }

                if (dr["SuperAnnuation"] is DBNull == false)
                {
                    if (dr["SuperAnnuation"] != "")
                    {
                        employee.txtSuperAnnuation = Convert.ToDecimal(dr["SuperAnnuation"]);
                    }
                }

                if (dr["EarnedLeave"] is DBNull == false)
                {
                    if (dr["EarnedLeave"] != "")
                    {
                        employee.txtEarnedLeave = Convert.ToDecimal(dr["EarnedLeave"]);
                    }
                }

                if (dr["EDLI"] is DBNull == false)
                {
                    if (dr["EDLI"] != "")
                    {
                        employee.txtEDLI = Convert.ToDecimal(dr["EDLI"]);
                    }
                }

                if (dr["GMI"] is DBNull == false)
                {
                    if (dr["GMI"] != "")
                    {
                        employee.txtGroupMedicalInsurance = Convert.ToDecimal(dr["GMI"]);
                    }
                }

                if (dr["GroupAccident"] is DBNull == false)
                {
                    if (dr["GroupAccident"] != "")
                    {
                        employee.txtGroupPerAcceridted = Convert.ToDecimal(dr["GroupAccident"]);
                    }
                }

                if (dr["GTP"] is DBNull == false)
                {
                    if (dr["GTP"] != "")
                    {
                        employee.txtGroupPerPlus = Convert.ToDecimal(dr["GTP"]);
                    }
                }

                if (dr["CTC"] is DBNull == false)
                {
                    if (dr["CTC"] != "")
                    {
                        employee.txtCTC = Convert.ToDecimal(dr["CTC"]);
                    }
                }

                if (dr["HraPer"] is DBNull == false)
                {
                    if (dr["HraPer"] != "")
                    {
                        employee.ddlHraValue = Convert.ToDecimal(dr["HraPer"]);
                    }
                }

                if (dr["CTCAm"] is DBNull == false)
                {
                    if (dr["CTCAm"] != "")
                    {
                        employee.txtctcam = Convert.ToDecimal(dr["CTCAm"]);
                    }
                }

                if (dr["VariableEarning"] is DBNull == false)
                {
                    if (dr["VariableEarning"] != "")
                    {
                        employee.txtvariableearning = Convert.ToDecimal(dr["VariableEarning"]);
                    }
                }                
            }
        }
        dr.Close();
        con.Close();
        return employee;
    }


    public class Employee
    {
        public string txtSearchEmployecode { get; set; }
        public decimal txtPF { get; set; }
        public decimal txtESI { get; set; }
        public decimal txtGratuity { get; set; }
        public decimal txtLTA { get; set; }
        public decimal txtBONUS { get; set; }
        public decimal txtSuperAnnuation { get; set; }
        public decimal txtEarnedLeave { get; set; }
        public decimal txtEDLI { get; set; }
        public decimal txtGroupMedicalInsurance { get; set; }
        public decimal txtGroupPerAcceridted { get; set; }
        public decimal txtGroupPerPlus { get; set; }
        public decimal txtCTC { get; set; }
        public decimal ddlHraValue { get; set; }
        public decimal txtctcam { get; set; }
        public decimal txtvariableearning { get; set; }        
    }


    [System.Web.Services.WebMethod]
    public static FullParameters search(string code)
    {
        FullParameters employee = new FullParameters();
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Master_CalFetch_Existing", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@SeriesCode", SqlDbType.VarChar, 10).Value = code;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                if (dr["seriescode"] != "")
                {
                    employee.txtSearchEmployecode = dr["seriescode"].ToString();
                }

                if (dr["Basic"] is DBNull == false)
                {
                    if (dr["Basic"] != "")
                    {

                        employee.txtbasic = Convert.ToDecimal(dr["Basic"]);
                    }
                }

                if (dr["Hra"] is DBNull == false)
                {
                    if (dr["Hra"] != "")
                    {

                        employee.txtHra = Convert.ToDecimal(dr["Hra"]);
                    }
                }

                if (dr["ColonyAllw"] is DBNull == false)
                {
                    if (dr["ColonyAllw"] != "")
                    {

                        employee.txtColonyAllowance = Convert.ToDecimal(dr["ColonyAllw"]);
                    }
                }

                if (dr["SpecialAllw"] is DBNull == false)
                {
                    if (dr["SpecialAllw"] != "")
                    {

                        employee.txtSpecialAllowance = Convert.ToDecimal(dr["SpecialAllw"]);
                    }
                }

                if (dr["PersonelAllw"] is DBNull == false)
                {
                    if (dr["PersonelAllw"] != "")
                    {

                        employee.txtPersonelAllowance = Convert.ToDecimal(dr["PersonelAllw"]);
                    }
                }

                if (dr["Stability"] is DBNull == false)
                {
                    if (dr["Stability"] != "")
                    {

                        employee.txtStablity = Convert.ToDecimal(dr["Stability"]);
                    }
                }

                if (dr["JoiningAllw"] is DBNull == false)
                {
                    if (dr["JoiningAllw"] != "")
                    {

                        employee.txtJoiningAllowance = Convert.ToDecimal(dr["JoiningAllw"]);
                    }
                }

                if (dr["TelephoneAllw"] is DBNull == false)
                {
                    if (dr["TelephoneAllw"] != "")
                    {

                        employee.txtTelePhoneAllowance = Convert.ToDecimal(dr["TelephoneAllw"]);
                    }
                }

                if (dr["ScooterAllw"] is DBNull == false)
                {
                    if (dr["ScooterAllw"] != "")
                    {

                        employee.txtScooterAllowance = Convert.ToDecimal(dr["ScooterAllw"]);
                    }
                }

                if (dr["CarAllw"] is DBNull == false)
                {
                    if (dr["CarAllw"] != "")
                    {

                        employee.txtCarAllowance = Convert.ToDecimal(dr["CarAllw"]);
                    }
                }


                if (dr["AdditionalAllw"] is DBNull == false)
                {
                    if (dr["AdditionalAllw"] != "")
                    {

                        employee.txtAdditionalAllowance = Convert.ToDecimal(dr["AdditionalAllw"]);
                    }
                }


                if (dr["UniformAllw"] is DBNull == false)
                {
                    if (dr["UniformAllw"] != "")
                    {

                        employee.txtUniformAllowance = Convert.ToDecimal(dr["UniformAllw"]);
                    }
                }

                if (dr["DriverAllw"] is DBNull == false)
                {
                    if (dr["DriverAllw"] != "")
                    {

                        employee.txtDriverAllowance = Convert.ToDecimal(dr["DriverAllw"]);
                    }
                }


                if (dr["EntertainmentAllw"] is DBNull == false)
                {
                    if (dr["EntertainmentAllw"] != "")
                    {

                        employee.txtEntertainmentAllowance = Convert.ToDecimal(dr["EntertainmentAllw"]);
                    }
                }


                if (dr["SubTotal"] is DBNull == false)
                {
                    if (dr["SubTotal"] != "")
                    {

                        employee.txtTotal1 = Convert.ToDecimal(dr["SubTotal"]);
                    }
                }

                if (dr["PF"] is DBNull == false)
                {
                    if (dr["PF"] != "")
                    {
                        employee.txtPF = Convert.ToDecimal(dr["PF"]);
                    }
                }

                if (dr["ESI"] is DBNull == false)
                {
                    if (dr["ESI"] != "")
                    {

                        employee.txtESI = Convert.ToDecimal(dr["ESI"]);
                    }
                }

                if (dr["Gratuity"] is DBNull == false)
                {
                    if (dr["Gratuity"] != "")
                    {

                        employee.txtGratuity = Convert.ToDecimal(dr["Gratuity"]);
                    }
                }

                if (dr["LTA"] is DBNull == false)
                {
                    if (dr["LTA"] != "")
                    {
                        employee.txtLTA = Convert.ToDecimal(dr["LTA"]);
                    }
                }

                if (dr["Bonus"] is DBNull == false)
                {
                    if (dr["Bonus"] != "")
                    {
                        employee.txtBONUS = Convert.ToDecimal(dr["Bonus"]);
                    }
                }

                if (dr["SuperAnnuation"] is DBNull == false)
                {
                    if (dr["SuperAnnuation"] != "")
                    {
                        employee.txtSuperAnnuation = Convert.ToDecimal(dr["SuperAnnuation"]);
                    }
                }

                if (dr["EarnedLeave"] is DBNull == false)
                {
                    if (dr["EarnedLeave"] != "")
                    {
                        employee.txtEarnedLeave = Convert.ToDecimal(dr["EarnedLeave"]);
                    }
                }

                if (dr["EDLI"] is DBNull == false)
                {
                    if (dr["EDLI"] != "")
                    {
                        employee.txtEDLI = Convert.ToDecimal(dr["EDLI"]);
                    }
                }

                if (dr["GMI"] is DBNull == false)
                {
                    if (dr["GMI"] != "")
                    {
                        employee.txtGroupMedicalInsurance = Convert.ToDecimal(dr["GMI"]);
                    }
                }

                if (dr["GroupAccident"] is DBNull == false)
                {
                    if (dr["GroupAccident"] != "")
                    {
                        employee.txtGroupPerAcceridted = Convert.ToDecimal(dr["GroupAccident"]);
                    }
                }

                if (dr["GTP"] is DBNull == false)
                {
                    if (dr["GTP"] != "")
                    {
                        employee.txtGroupPerPlus = Convert.ToDecimal(dr["GTP"]);
                    }
                }

                if (dr["CTC"] is DBNull == false)
                {
                    if (dr["CTC"] != "")
                    {
                        employee.txtCTC = Convert.ToDecimal(dr["CTC"]);
                    }
                }

                if (dr["HraPer"] is DBNull == false)
                {
                    if (dr["HraPer"] != "")
                    {
                        employee.ddlHraValue = Convert.ToDecimal(dr["HraPer"]);
                    }
                }

                if (dr["VariableEarning"] is DBNull == false)
                {
                    if (dr["VariableEarning"] != "")
                    {
                        employee.txtvariableearning = Convert.ToDecimal(dr["VariableEarning"]);

                    }
                }

                if (dr["CTCAm"] is DBNull == false)
                {
                    if (dr["CTCAm"] != "")
                    {
                        employee.txtctcam = Convert.ToDecimal(dr["CTCAm"]);
                    }
                }


                if (dr["LtaAllw"] is DBNull == false)
                {
                    if (dr["LtaAllw"] != "")
                    {
                        employee.txtltaallw = Convert.ToDecimal(dr["LtaAllw"]);
                    }
                }

                if (dr["FurAllw"] is DBNull == false)
                {
                    if (dr["FurAllw"] != "")
                    {
                        employee.txtFurAllw = Convert.ToDecimal(dr["FurAllw"]);
                    }
                }


                if (dr["Designation"] is DBNull == false)
                {
                    if (dr["Designation"] != "")
                    {
                        employee.ddldesignation = dr["Designation"].ToString(); 
                    }
                }


                if (dr["CarIns"] is DBNull == false)
                {
                    if (dr["CarIns"] != "")
                    {
                        employee.txtCarInsurance = Convert.ToDecimal(dr["CarIns"]);
                    }
                }
            }
        }
        dr.Close();
        con.Close();
        return employee;
    }


    public class FullParameters
    {
        public string txtSearchEmployecode { get; set; }
        public decimal txtbasic { get; set; }
        public decimal txtHra { get; set; }
        public decimal txtColonyAllowance { get; set; }
        public decimal txtSpecialAllowance { get; set; }
        public decimal txtPersonelAllowance { get; set; }
        public decimal txtStablity { get; set; }
        public decimal txtJoiningAllowance { get; set; }
        public decimal txtTelePhoneAllowance { get; set; }
        public decimal txtScooterAllowance { get; set; }
        public decimal txtCarAllowance { get; set; }
        public decimal txtAdditionalAllowance { get; set; }
        public decimal txtUniformAllowance { get; set; }
        public decimal txtDriverAllowance { get; set; }
        public decimal txtEntertainmentAllowance { get; set; }
        public decimal txtTotal1 { get; set; }

        public decimal txtPF { get; set; }
        public decimal txtESI { get; set; }
        public decimal txtGratuity { get; set; }
        public decimal txtLTA { get; set; }
        public decimal txtBONUS { get; set; }
        public decimal txtSuperAnnuation { get; set; }
        public decimal txtEarnedLeave { get; set; }
        public decimal txtEDLI { get; set; }
        public decimal txtGroupMedicalInsurance { get; set; }
        public decimal txtGroupPerAcceridted { get; set; }
        public decimal txtGroupPerPlus { get; set; }
        public decimal txtCTC { get; set; }
        public decimal ddlHraValue { get; set; }
        public string ddldesignation { get; set; }

        public decimal txtvariableearning { get; set; }
        public decimal txtctcam { get; set; }

        public decimal txtltaallw { get; set; }
        public decimal txtFurAllw { get; set; }

        public decimal txtCarInsurance { get; set; }

    }

    protected void GenerateCode()
    {
        #region Serial No. Code
        txtSearchEmployecode.Text = "";

        string str;
        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(SeriesCode),CHARINDEX('-',max(SeriesCode))+1,len(max(SeriesCode))+3) from Jct_Payroll_PayScale_Master ", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["GrpCode"] = "100";
                    ViewState["GrpCode"] = "EMP-" + ViewState["GrpCode"];
                    txtSearchEmployecode.Text = ViewState["GrpCode"].ToString();
                }
                else
                {
                    ViewState["GrpCode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["GrpCode"] = "EMP-" + ViewState["GrpCode"];
                    txtSearchEmployecode.Text = ViewState["GrpCode"].ToString();
                }
            }
        }
        dr.Close();
        #endregion
    }

    public void Designationbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT Designation_code,Desg_Long_Description FROM [JCT_payroll_designation_master_Payscale] WHERE  STATUS='A' order by Desg_Long_Description", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldesignation.Items.Clear();
        ddldesignation.DataSource = ds;
        ddldesignation.DataTextField = "Desg_Long_Description";
        ddldesignation.DataValueField = "Designation_code";
        ddldesignation.DataBind();
        con.Close();
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();

            SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Master_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SeriesCode", SqlDbType.VarChar, 10).Value = txtSearchEmployecode.Text;

            cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 50).Value = ddldesignation.SelectedItem.Value;

            if (txtbasic.Text != "")
            {
                cmd.Parameters.Add("@Basic", SqlDbType.Decimal, 10).Value = txtbasic.Text;
            }

            if (txtHra.Text != "")
            {
                cmd.Parameters.Add("@Hra", SqlDbType.Decimal, 10).Value = txtHra.Text;
            }

            if (txtColonyAllowance.Text != "")
            {
                cmd.Parameters.Add("@ColonyAllw", SqlDbType.Decimal, 10).Value = txtColonyAllowance.Text;
            }

            if (txtSpecialAllowance.Text != "")
            {
                cmd.Parameters.Add("@SpecialAllw", SqlDbType.Decimal, 10).Value = txtSpecialAllowance.Text;
            }

            if (txtPersonelAllowance.Text != "")
            {
                cmd.Parameters.Add("@PersonelAllw", SqlDbType.Decimal, 10).Value = txtPersonelAllowance.Text;
            }

            if (txtStablity.Text != "")
            {
                cmd.Parameters.Add("@Stability", SqlDbType.Decimal, 10).Value = txtStablity.Text;
            }

            if (txtJoiningAllowance.Text != "")
            {
                cmd.Parameters.Add("@JoiningAllw", SqlDbType.Decimal, 10).Value = txtJoiningAllowance.Text;
            }

            if (txtTelePhoneAllowance.Text != "")
            {
                cmd.Parameters.Add("@TelephoneAllw", SqlDbType.Decimal, 10).Value = txtTelePhoneAllowance.Text;
            }

            //if (ddlScooterAllowance.Visible == true)
            if (txtScooterAllowance.Visible == true)
            {
                if (txtScooterAllowance.Text != "")
                {
                    cmd.Parameters.Add("@ScooterAllw", SqlDbType.Decimal, 10).Value = txtScooterAllowance.Text;
                }
            }

            if (txtCarAllowance.Visible == true)
            {
                if (txtCarAllowance.Text != "")
                {
                    cmd.Parameters.Add("@CarAllw", SqlDbType.Decimal, 10).Value = txtCarAllowance.Text;
                }
            }

            if (txtAdditionalAllowance.Visible == true)
            {
                if (txtAdditionalAllowance.Text != "")
                {
                    cmd.Parameters.Add("@AdditionalAllw", SqlDbType.Decimal, 10).Value = txtAdditionalAllowance.Text;
                }
            }

            if (txtUniformAllowance.Visible == true)
            {
                if (txtUniformAllowance.Text != "")
                {
                    cmd.Parameters.Add("@UniformAllw", SqlDbType.Decimal, 10).Value = txtUniformAllowance.Text;
                }
            }

            if (txtDriverAllowance.Visible == true)
            {
                if (txtDriverAllowance.Text != "")
                {
                    cmd.Parameters.Add("@DriverAllw", SqlDbType.Decimal, 10).Value = txtDriverAllowance.Text;
                }
            }

            if (txtEntertainmentAllowance.Visible == true)
            {
                if (txtEntertainmentAllowance.Text != "")
                {
                    cmd.Parameters.Add("@EntertainmentAllw", SqlDbType.Decimal, 10).Value = txtEntertainmentAllowance.Text;
                }
            }

            if (Request.Form["txtTotal1"] != "")
            {
                cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal, 10).Value = Request.Form["txtTotal1"];
            }

            if (Request.Form["txtPF"] != "")
            {
                cmd.Parameters.Add("@PF", SqlDbType.Decimal, 10).Value = Request.Form["txtPF"];
            }

            if (Request.Form["txtESI"] != "")
            {
                cmd.Parameters.Add("@ESI", SqlDbType.Decimal, 10).Value = Request.Form["txtESI"];
            }

            if (Request.Form["txtGratuity"] != "")
            {
                cmd.Parameters.Add("@Gratuity", SqlDbType.Decimal, 10).Value = Request.Form["txtGratuity"];
            }

            if (Request.Form["txtLTA"] != "")
            {
                cmd.Parameters.Add("@LTA", SqlDbType.Decimal, 10).Value = Request.Form["txtLTA"];
            }

            if (Request.Form["txtBONUS"] != "")
            {
                cmd.Parameters.Add("@Bonus", SqlDbType.Decimal, 10).Value = Request.Form["txtBONUS"];
            }

            if (Request.Form["txtSuperAnnuation"] != "")
            {
                cmd.Parameters.Add("@SuperAnnuation", SqlDbType.Decimal, 10).Value = Request.Form["txtSuperAnnuation"];
            }

            if (Request.Form["txtEarnedLeave"] != "")
            {
                cmd.Parameters.Add("@EarnedLeave", SqlDbType.Decimal, 10).Value = Request.Form["txtEarnedLeave"];
            }

            //if (Request.Form["txtEDLI"] != "")
            //{
            //    cmd.Parameters.Add("@EDLI", SqlDbType.Decimal, 10).Value = Request.Form["txtEDLI"];
            //}

            if (txtEDLI.Text != "")
            {
                cmd.Parameters.Add("@EDLI", SqlDbType.Decimal, 10).Value = txtEDLI.Text; 
            }


            if (txtGroupMedicalInsurance.Text != "")
            {
                cmd.Parameters.Add("@GMI", SqlDbType.Decimal, 10).Value = txtGroupMedicalInsurance.Text;
            }

            if (txtGroupPerAcceridted.Text != "")
            {
                cmd.Parameters.Add("@GroupAccident", SqlDbType.Decimal, 10).Value = txtGroupPerAcceridted.Text;
            }

            if (txtGroupPerPlus.Text != "")
            {
                cmd.Parameters.Add("@GTP", SqlDbType.Decimal, 10).Value = txtGroupPerPlus.Text;
            }

            if (Request.Form["txtCTC"] != "")
            {
                cmd.Parameters.Add("@CTC", SqlDbType.Decimal, 10).Value = Request.Form["txtCTC"];
            }


            cmd.Parameters.Add("@HostName", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];

            if (ddlHraValue.SelectedItem.Value != "")
            {
                cmd.Parameters.Add("@hraper", SqlDbType.Decimal, 10).Value = ddlHraValue.SelectedItem.Value;
            }
            if (txtvariableearning.Text != "")
            {
                cmd.Parameters.Add("@VariableEarning", SqlDbType.Decimal, 10).Value = txtvariableearning.Text;
            }

            if (Request.Form["txtctcam"] != "")
            {
                cmd.Parameters.Add("@CTCAm", SqlDbType.Decimal, 10).Value = Request.Form["txtctcam"];
            }

            if (txtltaallw.Text != "")
            {
                cmd.Parameters.Add("@LtaAllw", SqlDbType.Decimal, 10).Value = txtltaallw.Text;
            }

            if (txtFurAllw.Text != "")
            {
                cmd.Parameters.Add("@FurAllw", SqlDbType.Decimal, 10).Value = txtFurAllw.Text;
            }

            if (txtCarInsurance.Text != "")
            {
                cmd.Parameters.Add("@CarIns", SqlDbType.Decimal, 10).Value = txtCarInsurance.Text;
            }


            cmd.ExecuteNonQuery();
            con.Close();
            string script = "";
            script = "alert('Record Saved Succussfully.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            clearcontrols();
            txtSearchEmployecode.Text = "";
            Designationbind();
            GenerateCode();
            txtSearchEmployecode0.Text = "";
            
            //lnkUpdate.Visible = false;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_PayScaleEntry.aspx");
    }

    public void clearcontrols()
    {
        txtbasic.Text = "";
        txtHra.Text = "";
        txtColonyAllowance.Text = "";
        txtSpecialAllowance.Text = "";
        txtPersonelAllowance.Text = "";
        txtStablity.Text = "";
        txtJoiningAllowance.Text = "";
        txtTelePhoneAllowance.Text = "";
        txtScooterAllowance.Text = "";
        txtCarAllowance.Text = "";
        txtAdditionalAllowance.Text = "";
        txtUniformAllowance.Text = "";
        txtDriverAllowance.Text = "";
        txtEntertainmentAllowance.Text = "";
        //txtTotal1.Text = "";
        //txtPF.Text = "";
        //txtESI.Text = "";
        //txtGratuity.Text = "";
        //txtLTA.Text = "";
        //txtBONUS.Text = "";
        //txtSuperAnnuation.Text = "";
        //txtEarnedLeave.Text = "";
        //txtEDLI.Text = "";

        txtEDLI.Text = "";
        txtGroupMedicalInsurance.Text = "";
        txtGroupPerAcceridted.Text = "";
        txtGroupPerPlus.Text = "";

        //txtCTC.Text = "";
        txtvariableearning.Text = "";
        //Request.Form["txtESI"] = "";

        txtltaallw.Text = "";
        txtFurAllw.Text = "";

        txtCarInsurance.Text = ""; 

    }



    protected void txtSearchEmployecode_TextChanged(object sender, EventArgs e)
    {
        //searchlist();
    }

    //protected void lnkFetch_Click(object sender, EventArgs e)
    //{
    //    searchlist();
    //}
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();

            SqlCommand cmd = new SqlCommand("Jct_Payroll_PayScale_Master_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SeriesCode", SqlDbType.VarChar, 10).Value = txtSearchEmployecode0.Text;

            cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 50).Value = ddldesignation.SelectedItem.Value;

            if (txtbasic.Text != "")
            {
                cmd.Parameters.Add("@Basic", SqlDbType.Decimal, 10).Value = txtbasic.Text;
            }

            if (txtHra.Text != "")
            {
                cmd.Parameters.Add("@Hra", SqlDbType.Decimal, 10).Value = txtHra.Text;
            }

            if (txtColonyAllowance.Text != "")
            {
                cmd.Parameters.Add("@ColonyAllw", SqlDbType.Decimal, 10).Value = txtColonyAllowance.Text;
            }

            if (txtSpecialAllowance.Text != "")
            {
                cmd.Parameters.Add("@SpecialAllw", SqlDbType.Decimal, 10).Value = txtSpecialAllowance.Text;
            }

            if (txtPersonelAllowance.Text != "")
            {
                cmd.Parameters.Add("@PersonelAllw", SqlDbType.Decimal, 10).Value = txtPersonelAllowance.Text;
            }

            if (txtStablity.Text != "")
            {
                cmd.Parameters.Add("@Stability", SqlDbType.Decimal, 10).Value = txtStablity.Text;
            }

            if (txtJoiningAllowance.Text != "")
            {
                cmd.Parameters.Add("@JoiningAllw", SqlDbType.Decimal, 10).Value = txtJoiningAllowance.Text;
            }

            if (txtTelePhoneAllowance.Text != "")
            {
                cmd.Parameters.Add("@TelephoneAllw", SqlDbType.Decimal, 10).Value = txtTelePhoneAllowance.Text;
            }

            //if (ddlScooterAllowance.Visible == true)
            if (txtScooterAllowance.Visible == true)
            {
                if (txtScooterAllowance.Text != "")
                {
                    cmd.Parameters.Add("@ScooterAllw", SqlDbType.Decimal, 10).Value = txtScooterAllowance.Text;
                }
            }

            if (txtCarAllowance.Visible == true)
            {
                if (txtCarAllowance.Text != "")
                {
                    cmd.Parameters.Add("@CarAllw", SqlDbType.Decimal, 10).Value = txtCarAllowance.Text;
                }
            }

            if (txtAdditionalAllowance.Visible == true)
            {
                if (txtAdditionalAllowance.Text != "")
                {
                    cmd.Parameters.Add("@AdditionalAllw", SqlDbType.Decimal, 10).Value = txtAdditionalAllowance.Text;
                }
            }

            if (txtUniformAllowance.Visible == true)
            {
                if (txtUniformAllowance.Text != "")
                {
                    cmd.Parameters.Add("@UniformAllw", SqlDbType.Decimal, 10).Value = txtUniformAllowance.Text;
                }
            }

            if (txtDriverAllowance.Visible == true)
            {
                if (txtDriverAllowance.Text != "")
                {
                    cmd.Parameters.Add("@DriverAllw", SqlDbType.Decimal, 10).Value = txtDriverAllowance.Text;
                }
            }

            if (txtEntertainmentAllowance.Visible == true)
            {
                if (txtEntertainmentAllowance.Text != "")
                {
                    cmd.Parameters.Add("@EntertainmentAllw", SqlDbType.Decimal, 10).Value = txtEntertainmentAllowance.Text;
                }
            }

            if (Request.Form["txtTotal1"] != "")
            {
                cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal, 10).Value = Request.Form["txtTotal1"];
            }

            if (Request.Form["txtPF"] != "")
            {
                cmd.Parameters.Add("@PF", SqlDbType.Decimal, 10).Value = Request.Form["txtPF"];
            }

            if (Request.Form["txtESI"] != "")
            {
                cmd.Parameters.Add("@ESI", SqlDbType.Decimal, 10).Value = Request.Form["txtESI"];
            }

            if (Request.Form["txtGratuity"] != "")
            {
                cmd.Parameters.Add("@Gratuity", SqlDbType.Decimal, 10).Value = Request.Form["txtGratuity"];
            }

            if (Request.Form["txtLTA"] != "")
            {
                cmd.Parameters.Add("@LTA", SqlDbType.Decimal, 10).Value = Request.Form["txtLTA"];
            }

            if (Request.Form["txtBONUS"] != "")
            {
                cmd.Parameters.Add("@Bonus", SqlDbType.Decimal, 10).Value = Request.Form["txtBONUS"];
            }

            if (Request.Form["txtSuperAnnuation"] != "")
            {
                cmd.Parameters.Add("@SuperAnnuation", SqlDbType.Decimal, 10).Value = Request.Form["txtSuperAnnuation"];
            }

            if (Request.Form["txtEarnedLeave"] != "")
            {
                cmd.Parameters.Add("@EarnedLeave", SqlDbType.Decimal, 10).Value = Request.Form["txtEarnedLeave"];
            }

            //if (Request.Form["txtEDLI"] != "")
            //{
            //    cmd.Parameters.Add("@EDLI", SqlDbType.Decimal, 10).Value = Request.Form["txtEDLI"];
            //}

            if (txtEDLI.Text != "")
            {
                cmd.Parameters.Add("@EDLI", SqlDbType.Decimal, 10).Value = txtEDLI.Text; 
            }


            if (txtGroupMedicalInsurance.Text != "")
            {
                cmd.Parameters.Add("@GMI", SqlDbType.Decimal, 10).Value = txtGroupMedicalInsurance.Text;
            }

            if (txtGroupPerAcceridted.Text != "")
            {
                cmd.Parameters.Add("@GroupAccident", SqlDbType.Decimal, 10).Value = txtGroupPerAcceridted.Text;
            }

            if (txtGroupPerPlus.Text != "")
            {
                cmd.Parameters.Add("@GTP", SqlDbType.Decimal, 10).Value = txtGroupPerPlus.Text;
            }

            if (Request.Form["txtCTC"] != "")
            {
                cmd.Parameters.Add("@CTC", SqlDbType.Decimal, 10).Value = Request.Form["txtCTC"];
            }


            cmd.Parameters.Add("@HostName", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];

            if (ddlHraValue.SelectedItem.Value != "")
            {
                cmd.Parameters.Add("@hraper", SqlDbType.Decimal, 10).Value = ddlHraValue.SelectedItem.Value;
            }
            if (txtvariableearning.Text != "")
            {
                cmd.Parameters.Add("@VariableEarning", SqlDbType.Decimal, 10).Value = txtvariableearning.Text;
            }

            if (Request.Form["txtctcam"] != "")
            {
                cmd.Parameters.Add("@CTCAm", SqlDbType.Decimal, 10).Value = Request.Form["txtctcam"];
            }

            if (txtltaallw.Text != "")
            {
                cmd.Parameters.Add("@LtaAllw", SqlDbType.Decimal, 10).Value = txtltaallw.Text;
            }

            if (txtFurAllw.Text != "")
            {
                cmd.Parameters.Add("@FurAllw", SqlDbType.Decimal, 10).Value = txtFurAllw.Text;
            }

            if (txtCarInsurance.Text != "")
            {
                cmd.Parameters.Add("@CarIns", SqlDbType.Decimal, 10).Value = txtCarInsurance.Text;
            }

            cmd.ExecuteNonQuery();
            con.Close();

            string script = "";
            script = "alert('Record Updated Succussfully.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            clearcontrols();
            txtSearchEmployecode.Text = "";
            Designationbind();
            GenerateCode();
            txtSearchEmployecode0.Text = "";
        
            //lnkUpdate.Visible = false;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }


    [System.Web.Services.WebMethod]
    public static List<CountryList> GetCountriesName(string code)
    {
        List<CountryList> lst = new List<CountryList>();
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("JCT_payroll_PayScale_Category_University_Fetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Code", SqlDbType.VarChar, 10).Value = code;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {                
                lst.Add(new CountryList {
                    CountryId = dr["CountryId"].ToString(),
                    CountryName = dr["CountryName"].ToString()
                });                
            }
        }
        dr.Close();
        con.Close();
        return lst;

    }

    public class CountryList
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
    }


    [System.Web.Services.WebMethod]
    public static string GetMaxCtc(string code, string Uni)
    {
        string result = "";
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("JCT_payroll_PayScale_Category_University_MaxCtc", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Code", SqlDbType.VarChar, 10).Value = code;
        cmd.Parameters.Add("@Uni", SqlDbType.VarChar, 100).Value = Uni;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {

                result = dr["Ctc"].ToString();                             
            }
        }
        dr.Close();
        con.Close();
        return result;
    }

    protected void lblVarpay_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Variablepay_Payment.aspx");        
    }
    protected void lnkctcenty_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Ctc_Manual_Entry.aspx");     
    }
}