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


public partial class Payroll_Payroll_Official_Detail : System.Web.UI.Page
{
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Image4.ImageUrl = "~\\EmployeePortal\\empimages\\2Old.JPG";
            Plantbind();
            if (ddlhousetype.SelectedValue == "")
            {
                lblShared.Visible = false;
                lblhouseno.Visible = false;
                ddlhouseShared.Visible = false;
                txtHouseNo.Visible = false;
            }
            else
            {
                lblShared.Visible = true;
                lblhouseno.Visible = true;
                ddlhouseShared.Visible = true;
                txtHouseNo.Visible = true;
            }

            string Check = ddlbonus.SelectedItem.Text;
            if (Check == "Yes")
            {
                ddlbonusCategory.Visible = true;
                lblBonusCategory.Visible = true;
            }
            else
            {
                ddlbonusCategory.Visible = false;
                lblBonusCategory.Visible = false;
            }

            Locationbind();
            Departmentbind();
            Designationbind();
            HouseTypebind();
            HrBind();
            //costcenterbind();
            bloodlist();

            if (!string.IsNullOrEmpty(Request.QueryString["cardno"])) // code to again fill the textboxes on redirect mode..
            {
                txtSearchEmployecode.Text = Request.QueryString["empcode"].ToString();
                //cmdSearch_Click(sender, e);
                searchlist();

            }
        }
    }

    protected void ddlhousetype_SelectedIndexChanged(object sender, EventArgs e)
    {        
        if (ddlhousetype.SelectedValue == "")
        {
            lblShared.Visible = false;
            lblhouseno.Visible = false;
            ddlhouseShared.Visible = false;
            txtHouseNo.Visible = false;
            txtHouseNo.Text = "";
            //ddlhouseShared.SelectedValue = "NO";
            ddlhouseShared.SelectedIndex = 0;
        }
        else
        {
            lblShared.Visible = true;
            lblhouseno.Visible = true;
            ddlhouseShared.Visible = true;
            txtHouseNo.Visible = true;
        }        
    }
   
    protected void ddljobtype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("JCT_payroll_employees_master_INSERT_UPDATE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Active", SqlDbType.VarChar, 3).Value = ddlstatus.SelectedItem.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployeecode.Text;
            cmd.Parameters.Add("@NewEmployeeCode", SqlDbType.VarChar, 10).Value = txtNewEmployeeCode.Text;
            cmd.Parameters.Add("@CardNo", SqlDbType.VarChar, 10).Value = txtSaviorcardno.Text;
            cmd.Parameters.Add("@MaritalStatus", SqlDbType.VarChar, 10).Value = ddlMaritalStatus.SelectedItem.Value;
            cmd.Parameters.Add("@BloodGroup", SqlDbType.VarChar, 3).Value = ddlbloodgroup.SelectedItem.Text;
            cmd.Parameters.Add("@Gender", SqlDbType.Char, 1).Value = rdbgender.SelectedItem.Value;
            cmd.Parameters.Add("@Salutation", SqlDbType.VarChar, 8).Value = ddlSalutaion.SelectedItem.Value;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = txtfirstname.Text;
            cmd.Parameters.Add("@MiddleName", SqlDbType.VarChar, 20).Value = txtMiddleName.Text;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = txtLastName.Text;
            cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 65).Value = lbemployeename.Text;
            cmd.Parameters.Add("@FatherHusbandName", SqlDbType.VarChar, 30).Value = txtfathername.Text;
            cmd.Parameters.Add("@Shift", SqlDbType.VarChar,10).Value = ddlshift.SelectedItem.Text;
            cmd.Parameters.Add("@SalaryType", SqlDbType.VarChar, 10).Value = ddlSalaryType.SelectedItem.Text;
            cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 30).Value = ddldesignation.SelectedItem.Value;
            cmd.Parameters.Add("@JobType", SqlDbType.VarChar, 15).Value = ddljobtype.SelectedItem.Value;
            cmd.Parameters.Add("@citizen", SqlDbType.VarChar, 15).Value = ddlCitizenship.SelectedItem.Text;
            cmd.Parameters.Add("@Area", SqlDbType.VarChar, 30).Value = ddlArea.SelectedItem.Value;
            cmd.Parameters.Add("@Religion", SqlDbType.VarChar, 15).Value = ddlreligion.SelectedItem.Value;
            cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = txtdateofbirth.Text;
            if (txtjoiningdate.Text == string.Empty)
            {
                cmd.Parameters.Add("@DOJ", SqlDbType.VarChar, 10).Value = txtjoiningdate.Text;              
            }
            else
            {
                cmd.Parameters.Add("@DOJ", SqlDbType.DateTime).Value = Convert.ToDateTime(txtjoiningdate.Text);
            }

            if (txtconfirmationdate.Text == string.Empty)
            {
                cmd.Parameters.Add("@DOConfirmation", SqlDbType.VarChar, 10).Value = txtconfirmationdate.Text;
            }
            else
            {
                cmd.Parameters.Add("@DOConfirmation", SqlDbType.DateTime).Value = txtconfirmationdate.Text;
            }
            if (TxtAnniversaryDate.Text == string.Empty)
            {
                cmd.Parameters.Add("@DOAnniversary", SqlDbType.VarChar, 10).Value = TxtAnniversaryDate.Text;
            }
            else
            {
                cmd.Parameters.Add("@DOAnniversary", SqlDbType.DateTime).Value = TxtAnniversaryDate.Text;
            }
            if (txtleavingdate.Text == string.Empty)
            {
                cmd.Parameters.Add("@DOLeaving", SqlDbType.VarChar, 10).Value = txtleavingdate.Text;
            }
            else
            {
                cmd.Parameters.Add("@DOLeaving", SqlDbType.DateTime).Value = txtleavingdate.Text;
            }
            cmd.Parameters.Add("@Leaving_reason", SqlDbType.VarChar, 100).Value = ddlleavingreason.SelectedItem.Value;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 30).Value = ddldepartment.SelectedItem.Value;
            if (ddlsubdepartment.Items.Count > 0)
            {
                cmd.Parameters.Add("@Subdepartment", SqlDbType.VarChar, 50).Value = ddlsubdepartment.SelectedItem.Value;
            }
            else
            {
                cmd.Parameters.Add("@Subdepartment", SqlDbType.VarChar, 50).Value = "null";
            }
            cmd.Parameters.Add("@extensionNo", SqlDbType.VarChar, 5).Value = txtextension.Text;
            cmd.Parameters.Add("@HouseType", SqlDbType.VarChar, 10).Value = ddlhousetype.SelectedItem.Value;
            cmd.Parameters.Add("@Shared", SqlDbType.VarChar, 3).Value = ddlhouseShared.SelectedItem.Value;
            cmd.Parameters.Add("@HouseNo", SqlDbType.VarChar,5).Value = txtHouseNo.Text;
            cmd.Parameters.Add("@Overtime", SqlDbType.VarChar, 3).Value = ddlpaidovertime.SelectedItem.Text;
            cmd.Parameters.Add("@Compensatory", SqlDbType.VarChar, 3).Value = ddlcompensatory.SelectedItem.Text;
            cmd.Parameters.Add("@Bonus", SqlDbType.VarChar, 3).Value = ddlbonus.SelectedItem.Value;
            cmd.Parameters.Add("@Memberpf", SqlDbType.VarChar, 3).Value = ddlpf.SelectedItem.Text;
            cmd.Parameters.Add("@MemberESI", SqlDbType.VarChar, 3).Value = ddlESI.SelectedItem.Text;
            cmd.Parameters.Add("@MemberClub", SqlDbType.VarChar, 3).Value = ddlclub.SelectedItem.Text;
            cmd.Parameters.Add("@SeniorCitizen", SqlDbType.VarChar, 3).Value = ddlSeniorCitizen.SelectedItem.Text;
            cmd.Parameters.Add("@PfNo", SqlDbType.VarChar,10).Value = txtPfNo.Text;
            cmd.Parameters.Add("@FpfNo", SqlDbType.VarChar,10).Value = txtfpfno.Text;
            cmd.Parameters.Add("@ESINo", SqlDbType.VarChar,15).Value = txtEsiNo.Text;
            cmd.Parameters.Add("@SocietyNo", SqlDbType.VarChar,10).Value = txtSocietyNo.Text;
            cmd.Parameters.Add("@UanNo", SqlDbType.VarChar,15).Value = txtUANNo.Text;
            cmd.Parameters.Add("@GratuityNo", SqlDbType.VarChar, 30).Value = txtGratuityyno.Text;
            cmd.Parameters.Add("@SuperAnnuationCurrent", SqlDbType.VarChar,15).Value = TxtAnnuationCurrent.Text;
            cmd.Parameters.Add("@SuperAnnuationPrevious", SqlDbType.VarChar,15).Value = TxtAnnuationPrevious.Text;
            cmd.Parameters.Add("@PanNo", SqlDbType.VarChar,12).Value = txtpancardno.Text;
            cmd.Parameters.Add("@AddharNo", SqlDbType.VarChar,12).Value = txtAddharNo.Text;
            cmd.Parameters.Add("@EmployeeFileNo", SqlDbType.VarChar,20).Value = TxtEmpFileNo.Text;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@image", SqlDbType.VarChar,20).Value = txtSaviorcardno.Text;
            cmd.Parameters.Add("@message", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CostCenter", SqlDbType.VarChar, 15).Value = txtCostCenter.Text;
            cmd.Parameters.Add("@BankLoanAccNo", SqlDbType.VarChar, 30).Value = txtBankLoanAccNo.Text;

            /*
             
             
            
             */

            if (ddlbonusCategory.Visible== true)
            {
                cmd.Parameters.Add("@BonusCategory", SqlDbType.VarChar, 30).Value = ddlbonusCategory.SelectedItem.Text;     
            }
            else
            {
                cmd.Parameters.Add("@BonusCategory", SqlDbType.VarChar, 30).Value = "";
            }

            cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 10).Value = Textmob.Text;
            cmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 35).Value = TxtEmailID.Text;

            cmd.Parameters.Add("@Hr", SqlDbType.VarChar, 50).Value = ddlHr.SelectedItem.Value;
            cmd.Parameters.Add("@MemberSuperAnnuationCat", SqlDbType.VarChar, 20).Value = ddlmemberSuperannuationcat.SelectedItem.Text; 

            cmd.ExecuteNonQuery();
            con.Close();
            string message = cmd.Parameters["@message"].Value.ToString();
            if (message == "0")
            {
                string script = "alert('Record saved.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                Image4.ImageUrl = "~\\EmployeePortal\\empimages\\2Old.JPG";
            }

            else if (message == "1")
            {
                string script = "alert('Record Updated.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                Image4.ImageUrl = "~\\EmployeePortal\\empimages\\2Old.JPG";
            }

        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }

        string querystring = "cardno=" + txtSaviorcardno.Text + "&empcode=" + txtEmployeecode.Text;

        //string url = "http://localhost:3405/FusionApps/PayRoll/payroll_personal_detail.aspx?" + querystring;
        // url = "http://test2k/FusionApps/OPS/MailContentPages/excessbudgetmail.aspx?" + querystring;
    }

    protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubdepartment.Items.Count > 0)
        {
            ddlsubdepartment.DataSource = null;
            ddlsubdepartment.DataBind();
        }
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("select '' as SubDepartment_code ,'' as subdepartment_long_description Union SELECT  DISTINCT SubDepartment_code ,subdepartment_long_description FROM JCT_payroll_subdepartment_master   WHERE Department_code LIKE '" + ddldepartment.SelectedItem.Value + "' and  STATUS='A'", con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlsubdepartment.DataSource = ds;
        ddlsubdepartment.DataTextField = "subdepartment_long_description";
        ddlsubdepartment.DataValueField = "SubDepartment_code";
        ddlsubdepartment.DataBind();
        con.Close();
    }

    //protected void cmdSearch_Click(object sender, EventArgs e)
    //{
    //    searchlist();
    //}

   
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Official_Detail.aspx");
    }

    protected void ImageOfficial_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Payroll_Official_Detail.aspx?cardno=" + txtSaviorcardno.Text + "&empcode=" + txtEmployeecode.Text);
    }

    protected void ImagePersonal_Click(object sender, ImageClickEventArgs e)
    {
       
        Response.Redirect("payroll_personal_detail.aspx?cardno=" + txtSaviorcardno.Text + "&empcode=" + txtEmployeecode.Text);
    }

    protected void ImageEarnings_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("payroll_emp_earnings.aspx?cardno=" + txtSaviorcardno.Text + "&empcode=" + txtEmployeecode.Text);
    }

    protected void ImageDeductions_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("payroll_emp_Deductions.aspx?empcode=" + txtEmployeecode.Text + "&cardno=" + txtSaviorcardno.Text);
    }

    public void Plantbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.Items.Clear();
        ddlplant.DataSource = ds;        
        ddlplant.DataTextField = "plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
        con.Close();
    }

    public void Locationbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.Items.Clear();
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
        con.Close();
    }

    public void Departmentbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by Department_long_Description", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.Items.Clear();
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "DepartmentLongDescription";
        ddldepartment.DataValueField = "DepartmentCode";
        ddldepartment.DataBind();
        con.Close();
    }


    public void HrBind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by Department_long_Description", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlHr.Items.Clear();
        ddlHr.DataSource = ds;
        ddlHr.DataTextField = "DepartmentLongDescription";
        ddlHr.DataValueField = "DepartmentCode";
        ddlHr.DataBind();
        con.Close();
    }

    public void Designationbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT Designation_code,Desg_Long_Description FROM JCT_payroll_designation_master WHERE  STATUS='A' order by Desg_Long_Description", con);
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

    public void HouseTypebind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT '' AS AccmType , '' AS Start_HouseNo, '' AS End_HouseNo UNION   SELECT AccmType,Start_HouseNo,End_HouseNo FROM Jct_Payroll_Accomdation_Master WHERE  STATUS='A'and plant='" + ddlplant.SelectedItem.Value + "'", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlhousetype.Items.Clear();
        ddlhousetype.DataSource = ds;
        ddlhousetype.DataTextField = "AccmType";
        ddlhousetype.DataValueField = "AccmType";
        ddlhousetype.DataBind();
        con.Close();
    }

    public void bloodlist()
    {
        string sql = "SELECT DISTINCT group_name FROM JCT_payroll_blood_master where status='A' order by group_name ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbloodgroup.Items.Clear();
        ddlbloodgroup.DataSource = ds;
        ddlbloodgroup.DataTextField ="group_name";
        ddlbloodgroup.DataValueField ="group_name";
        ddlbloodgroup.DataBind();
    }
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //NewSubLocation_PFESINo();
    }
    protected void imgbtnportmaster_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Payroll_Change_Plant_Loc.aspx?cardno=" + txtSaviorcardno.Text + "&empcode=" + txtEmployeecode.Text);
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
        HouseTypebind();
    }
    protected void txtHouseNo_TextChanged(object sender, EventArgs e)
    {
        string qry = "SELECT * FROM Jct_Payroll_Accomdation_Master WHERE status='A' and Start_HouseNo<='" + txtHouseNo.Text + "' AND End_HouseNo>='" + txtHouseNo.Text + "' AND AccmType='" + ddlhousetype.SelectedItem.Value + "'";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr != null && dr.HasRows)
        {

        }
        else
        {
           string script = "alert('House No Does not exist for this house type.!!');";
           ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
    }
    protected void txtMiddleName_TextChanged(object sender, EventArgs e)
    {
       
        lbemployeename.Text = txtfirstname.Text + " " + txtMiddleName.Text + " " + txtLastName.Text;
       
    }
    protected void txtLastName_TextChanged(object sender, EventArgs e)
    {
      
        lbemployeename.Text = txtfirstname.Text + " " + txtMiddleName.Text + " " + txtLastName.Text;
        
    }
    private void searchlist()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string empcode = txtSearchEmployecode.Text;
        ViewState["empcode"] = txtSearchEmployecode.Text;
        SqlCommand cmd = new SqlCommand("JCT_payroll_employees_master_Fetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@Savior_CardNo", SqlDbType.VarChar, 10).Value = txtsearchcardno.Text;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = empcode;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                ddlstatus.SelectedIndex = ddlstatus.Items.IndexOf(ddlstatus.Items.FindByText(dr["Active"].ToString()));
                ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByText(dr["PlantName"].ToString()));
                Locationbind();
                HouseTypebind();
                ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByText(dr["LocationDescription"].ToString()));
                txtEmployeecode.Text = dr["EmployeeCode"].ToString();
                txtNewEmployeeCode.Text = dr["NewEmployeeCode"].ToString();
                txtSaviorcardno.Text = dr["CardNo"].ToString();
                ddlMaritalStatus.SelectedIndex = ddlMaritalStatus.Items.IndexOf(ddlMaritalStatus.Items.FindByText(dr["MaritalStatus"].ToString()));
                ddlbloodgroup.SelectedIndex = ddlbloodgroup.Items.IndexOf(ddlbloodgroup.Items.FindByText(dr["BloodGroup"].ToString()));
                rdbgender.SelectedIndex = rdbgender.Items.IndexOf(rdbgender.Items.FindByText(dr["Gender"].ToString()));              
                ddlSalutaion.SelectedIndex = ddlSalutaion.Items.IndexOf(ddlSalutaion.Items.FindByText(dr["Salutation"].ToString()));
                txtfirstname.Text = dr["FirstName"].ToString();
                txtMiddleName.Text = dr["MiddleName"].ToString();
                txtLastName.Text = dr["LastName"].ToString();
                lbemployeename.Text = dr["EmployeeName"].ToString();
                txtfathername.Text = dr["FatherHusbandName"].ToString();
                ddlshift.SelectedIndex = ddlshift.Items.IndexOf(ddlshift.Items.FindByText(dr["Shift"].ToString()));
                ddlSalaryType.SelectedIndex = ddlSalaryType.Items.IndexOf(ddlSalaryType.Items.FindByText(dr["SalaryType"].ToString()));
                ddldesignation.SelectedIndex = ddldesignation.Items.IndexOf(ddldesignation.Items.FindByText(dr["DesignationDescription"].ToString()));
                ddljobtype.SelectedIndex = ddljobtype.Items.IndexOf(ddljobtype.Items.FindByText(dr["JobType"].ToString()));
                ddlCitizenship.SelectedIndex = ddlCitizenship.Items.IndexOf(ddlCitizenship.Items.FindByText(dr["Citizen"].ToString()));
                ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(dr["Area"].ToString()));
                ddlreligion.SelectedIndex = ddlreligion.Items.IndexOf(ddlreligion.Items.FindByText(dr["Religion"].ToString()));
                if (dr["DOB"].ToString() == "01/01/1900")
                {
                    txtdateofbirth.Text = "";
                }
                else
                {
                    txtdateofbirth.Text = dr["DOB"].ToString();
                }
                if (dr["DOJ"].ToString() == "01/01/1900")
                {
                    txtjoiningdate.Text = "";
                }
                else
                {
                    txtjoiningdate.Text = dr["DOJ"].ToString();
                }
                if (dr["DOConfirmation"].ToString() == "01/01/1900")
                {
                    txtconfirmationdate.Text = "";
                }
                else
                {
                    txtconfirmationdate.Text = dr["DOConfirmation"].ToString();
                }
                if (dr["DOAnniversary"].ToString() == "01/01/1900")
                {
                    TxtAnniversaryDate.Text = "";
                }
                else
                {
                    TxtAnniversaryDate.Text = dr["DOAnniversary"].ToString();
                }
                if (dr["DOLeaving"].ToString() == "01/01/1900")
                {
                    txtleavingdate.Text = "";
                }
                else
                {
                    txtleavingdate.Text = dr["DOLeaving"].ToString();
                }
               
                //txtleavingreason.Text = dr["LeavingReason"].ToString();
                ddlleavingreason.SelectedIndex = ddlleavingreason.Items.IndexOf(ddlleavingreason.Items.FindByText(dr["LeavingReason"].ToString()));
                ddldepartment.SelectedIndex = ddldepartment.Items.IndexOf(ddldepartment.Items.FindByText(dr["DepartmentDescription"].ToString()));
                if (ddlsubdepartment.Items.Count > 0)
                {
                    ddlsubdepartment.SelectedIndex = ddlsubdepartment.Items.IndexOf(ddlsubdepartment.Items.FindByText(dr["SubdepartmentDescription"].ToString()));
                }
                txtextension.Text = dr["ExtensionNo"].ToString();
                ddlhousetype.SelectedIndex = ddlhousetype.Items.IndexOf(ddlhousetype.Items.FindByText(dr["HouseType"].ToString()));
                if (dr["HouseType"].ToString() == "")
                {
                    txtHouseNo.Text = "";
                    ddlhouseShared.SelectedIndex = 0;
                    txtHouseNo.Visible = false;
                    ddlhouseShared.Visible = false;
                }
                else
                {
                    txtHouseNo.Text = dr["HouseNo"].ToString();
                    ddlhouseShared.SelectedIndex = ddlhouseShared.Items.IndexOf(ddlhouseShared.Items.FindByText(dr["Shared"].ToString()));
                    lblhouseno.Visible = true;
                    lblShared.Visible = true;
                    txtHouseNo.Visible = true;
                    ddlhouseShared.Visible = true;
                }

                ddlpaidovertime.SelectedIndex = ddlpaidovertime.Items.IndexOf(ddlpaidovertime.Items.FindByText(dr["Overtime"].ToString().Trim()));
                ddlcompensatory.SelectedIndex = ddlcompensatory.Items.IndexOf(ddlcompensatory.Items.FindByText(dr["Compensatory"].ToString().Trim()));
                ddlbonus.SelectedIndex=ddlbonus.Items.IndexOf(ddlbonus.Items.FindByText(dr["Bonus"].ToString().Trim()));
                ddlpf.SelectedIndex = ddlpf.Items.IndexOf(ddlpf.Items.FindByText(dr["MemberPf"].ToString()));
                ddlESI.SelectedIndex = ddlESI.Items.IndexOf(ddlESI.Items.FindByText(dr["MemberESI"].ToString()));
                ddlclub.SelectedIndex = ddlclub.Items.IndexOf(ddlclub.Items.FindByText(dr["MemberClub"].ToString()));
                ddlSeniorCitizen.SelectedIndex = ddlSeniorCitizen.Items.IndexOf(ddlSeniorCitizen.Items.FindByText(dr["SeniorCitizen"].ToString().Trim()));
                txtPfNo.Text = dr["PfNo"].ToString();
                txtfpfno.Text = dr["FpfNo"].ToString();
                txtEsiNo.Text = dr["ESINo"].ToString();
                txtSocietyNo.Text = dr["SocietyNo"].ToString();
                txtUANNo.Text = dr["UanNo"].ToString();
                txtGratuityyno.Text = dr["GratuityNo"].ToString();
                TxtAnnuationCurrent.Text = dr["SuperAnnuationCurrent"].ToString();
                TxtAnnuationPrevious.Text = dr["SuperAnnuationPrevious"].ToString();
                txtpancardno.Text = dr["PanNo"].ToString();
                txtAddharNo.Text = dr["AddharNo"].ToString();
                TxtEmpFileNo.Text = dr["EmployeeFileNo"].ToString();
                txtCostCenter.Text = dr["CostCenter"].ToString();
                txtBankLoanAccNo.Text = dr["BankLoanAccNo"].ToString();

                Textmob.Text = dr["MobileNo"].ToString();
                TxtEmailID.Text = dr["EmailID"].ToString();

                
                ddlHr.SelectedIndex = ddlHr.Items.IndexOf(ddlHr.Items.FindByValue(dr["Hr"].ToString().Trim()));
                ddlmemberSuperannuationcat.SelectedIndex = ddlmemberSuperannuationcat.Items.IndexOf(ddlmemberSuperannuationcat.Items.FindByValue(dr["MemberSuperAnnuationCat"].ToString().Trim()));
                

                if (dr["Bonus"].ToString() == "No")
                {                    
                    lblBonusCategory.Visible = false;
                    ddlbonusCategory.Visible = false;
                }
                else
                {
                    lblBonusCategory.Visible = true;
                    ddlbonusCategory.Visible = true;
                    ddlbonusCategory.SelectedIndex = ddlbonusCategory.Items.IndexOf(ddlbonusCategory.Items.FindByText(dr["BonusCategory"].ToString()));     
                }

                string fPath = Server.MapPath("~\\EmployeePortal\\empimages\\" + txtSaviorcardno.Text + ".jpg");
                System.IO.FileInfo fInfo = new System.IO.FileInfo(fPath);
                if (fInfo.Exists)
                {
                    Image4.ImageUrl = "~\\EmployeePortal\\empimages\\" + txtSaviorcardno.Text + ".jpg";
                }
                else
                {
                    Image4.ImageUrl = "EmpImages/2.gif";
                    Image4.ToolTip = "No Image Found";
                }
            }
            lnkadd.Text = "Update";
        }
        else
        {
            string script = "alert('Record Not Found.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        dr.Close();
        con.Close();
    }
    protected void txtSearchEmployecode_TextChanged(object sender, EventArgs e)
    {
        searchlist();
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlsubdepartment_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlhouseShared_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlpf_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Check = ddlpf.SelectedItem.Text;
        if (Check == "Yes")
        {
            txtPfNo.Enabled = true;
            txtfpfno.Enabled = true;
        }
        else
        {
            txtPfNo.Enabled = false;
            txtfpfno.Enabled = false; 
        }
    }
    protected void ddlESI_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Check =ddlESI.SelectedItem.Text;
        if (Check == "Yes")
        {
            txtEsiNo.Enabled = true;
        }
        else
        {
            txtEsiNo.Enabled = false;
        }
    }
    protected void ddlbonus_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Check = ddlbonus.SelectedItem.Text;
        if (Check == "Yes")
        {
            ddlbonusCategory.Visible = true;
            lblBonusCategory.Visible = true;
        }
        else
        {
            ddlbonusCategory.Visible = false;
            lblBonusCategory.Visible = false;
        }
    }
    protected void txtfirstname_TextChanged(object sender, EventArgs e)
    {
        lbemployeename.Text = txtfirstname.Text + " " + txtMiddleName.Text + " " + txtLastName.Text;
    }
}