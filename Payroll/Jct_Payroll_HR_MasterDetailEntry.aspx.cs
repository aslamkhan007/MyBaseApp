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

public partial class Payroll_Jct_Payroll_HR_MasterDetailEntry : System.Web.UI.Page
{
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblContractorCompletionDt.Visible = false;
            txtConfirmationcompletetionDate.Visible = false;
            HrBind();
            Image4.ImageUrl = "~\\EmployeePortal\\empimages\\2Old.JPG";
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("JCT_Payroll_Employees_Master_HR_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtSearchEmployecode.Text;
            cmd.Parameters.Add("@Hr", SqlDbType.VarChar, 50).Value = ddlHr.Text;
            cmd.Parameters.Add("@MemberSuperAnnuationCat", SqlDbType.VarChar, 20).Value = ddlmemberSuperannuationcat.Text;
            cmd.Parameters.Add("@EmployeeFileNo", SqlDbType.VarChar, 20).Value = TxtEmpFileNo.Text;
            cmd.Parameters.Add("@SuperAnnuationCurrent", SqlDbType.VarChar, 15).Value = TxtAnnuationCurrent.Text;
            cmd.Parameters.Add("@SuperAnnuationPrevious", SqlDbType.VarChar, 15).Value = TxtAnnuationPrevious.Text;
            cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 10).Value = Textmob.Text;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@HostName", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

            //if (txtConfirmationValues.Text != "")
            //{
            //    cmd.Parameters.Add("@ContractorCompletionVal", SqlDbType.Int).Value = txtConfirmationValues.Text;
            //}

            if (txtConfirmationcompletetionDate.Visible != false)
            {
                if (txtConfirmationcompletetionDate.Text != "")
                {
                    cmd.Parameters.Add("@ContractorCompletionDate", SqlDbType.DateTime).Value = txtConfirmationcompletetionDate.Text;
                }
            }

            if (txtconfirmationdate.Visible != false)
            {
                if (txtconfirmationdate.Text != "")
                {
                    cmd.Parameters.Add("@ConfirmationDate", SqlDbType.DateTime).Value = txtconfirmationdate.Text;
                }
            }

            if (ddlnotice.Visible != false)
            {
                if (ddlnotice.SelectedItem.Value != "")
                {
                    cmd.Parameters.Add("@NoticePeriod", SqlDbType.VarChar, 50).Value = ddlnotice.SelectedItem.Value;
                }
            }

            if (ddlProbatioPd.Visible != false)
            {
                if (ddlProbatioPd.SelectedItem.Value != "")
                {
                    cmd.Parameters.Add("@ProbPeriod", SqlDbType.VarChar, 50).Value = ddlProbatioPd.SelectedItem.Value;
                }
            }

            
            cmd.Parameters.Add("@TYPE", SqlDbType.VarChar, 50).Value = RadioButtonList1.SelectedItem.Value;                                   
            cmd.ExecuteNonQuery();
            con.Close();
            string script = "alert('Record Updated Succussfully.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            clearcontrols();
            txtSearchEmployecode.Text = "";
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }        
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_HR_MasterDetailEntry.aspx");
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


    public void clearcontrols()
    {
        lbemployeename.Text = "";
        txtfathername.Text = "";
        ddldesignation.Text = "";
        ddldepartment.Text = "";
        txtSaviorcardno.Text = "";
        TxtAnnuationCurrent.Text = "";
        TxtAnnuationPrevious.Text = "";
        Textmob.Text = "";
        TxtEmpFileNo.Text = "";
        Image4.ImageUrl = "~\\EmployeePortal\\empimages\\2Old.JPG";

        //txtConfirmationValues.Text = "";
        txtConfirmationcompletetionDate.Text = "";
        txtconfirmationdate.Text = "";
        ddlnotice.Text = "0 Days";
        ddlProbatioPd.Text = "0 Days";
    }

    private void searchlist()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand cmd = new SqlCommand("JCT_Payroll_Employees_Master_HR_Fetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtSearchEmployecode.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {                
                lbemployeename.Text = dr["EmployeeName"].ToString();
                txtfathername.Text = dr["FatherHusbandName"].ToString();
                //ddldesignation.SelectedIndex = ddldesignation.Items.IndexOf(ddldesignation.Items.FindByText(dr["DesignationDescription"].ToString()));
                //ddldepartment.SelectedIndex = ddldepartment.Items.IndexOf(ddldepartment.Items.FindByText(dr["DepartmentDescription"].ToString()));
                ddldesignation.Text = dr["DesignationDescription"].ToString();
                ddldepartment.Text = dr["DepartmentDescription"].ToString();
                txtSaviorcardno.Text = dr["cardno"].ToString();
                TxtEmpFileNo.Text = dr["EmployeeFileNo"].ToString();

                TxtAnnuationCurrent.Text = dr["SuperAnnuationCurrent"].ToString();
                TxtAnnuationPrevious.Text = dr["SuperAnnuationPrevious"].ToString();
                Textmob.Text = dr["MobileNo"].ToString();
                ddlHr.SelectedIndex = ddlHr.Items.IndexOf(ddlHr.Items.FindByValue(dr["Hr"].ToString().Trim()));
                ddlmemberSuperannuationcat.SelectedIndex = ddlmemberSuperannuationcat.Items.IndexOf(ddlmemberSuperannuationcat.Items.FindByValue(dr["MemberSuperAnnuationCat"].ToString().Trim()));
                string fPath = Server.MapPath("~\\EmployeePortal\\empimages\\" + txtSaviorcardno.Text + ".jpg");
                System.IO.FileInfo fInfo = new System.IO.FileInfo(fPath);
                if (fInfo.Exists)
                {
                    Image4.ImageUrl = "~\\EmployeePortal\\empimages\\" + txtSaviorcardno.Text + ".jpg";
                }
                else
                {
                    //Image4.ImageUrl = "EmpImages/2.gif";
                    //Image4.ImageUrl = "~/EmployeePortal/EmpImages/2Old.JPG";
                    Image4.ImageUrl = "~\\EmployeePortal\\empimages\\2Old.JPG";                    
                    Image4.ToolTip = "No Image Found";
                }
                if (dr["TYPE"].ToString() == "Contract")
                {

                    txtConfirmationcompletetionDate.Visible = true;
                    lblContractorCompletionDt.Visible = true;
                    //ContractorCompletionDate.
                    txtConfirmationcompletetionDate.Text = dr["ContractorCompletionDate"].ToString();

                    lblNoticePeriod.Visible = false;
                    ddlnotice.Visible = false;

                    lblProbationPeriod.Visible = false;
                    ddlProbatioPd.Visible = false;

                    txtconfirmationdate.Visible = false;
                    lblConfirmationdate.Visible = false;

                    txtconfirmationdate.Text = "";
                    ddlnotice.Text = "0 Days";
                    ddlProbatioPd.Text = "0 Days";
                  
                }
                else
                {

                    txtConfirmationcompletetionDate.Visible = false;
                    lblContractorCompletionDt.Visible = false;

                    txtConfirmationcompletetionDate.Text = "";

                    lblNoticePeriod.Visible = true;
                    ddlnotice.Visible = true;

                    lblProbationPeriod.Visible = true;
                    ddlProbatioPd.Visible = true;

                    txtconfirmationdate.Visible = true;
                    lblConfirmationdate.Visible = true;

                    txtconfirmationdate.Text = dr["ConfirmationDate"].ToString();
                    ddlnotice.SelectedIndex = ddlnotice.Items.IndexOf(ddlnotice.Items.FindByValue(dr["NoticePeriod"].ToString().Trim()));
                    ddlProbatioPd.SelectedIndex = ddlProbatioPd.Items.IndexOf(ddlProbatioPd.Items.FindByValue(dr["ProbPeriod"].ToString().Trim())); 

                }                
                
            }
        }
        else
        {
            clearcontrols();
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

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonList1.SelectedItem.Value == "Contract")
        {

            txtConfirmationcompletetionDate.Visible = true;
            lblContractorCompletionDt.Visible = true;


            lblNoticePeriod.Visible = false;
            ddlnotice.Visible = false;

            lblProbationPeriod.Visible = false;
            ddlProbatioPd.Visible = false;

            txtconfirmationdate.Visible = false;
            lblConfirmationdate.Visible = false;

            txtconfirmationdate.Text = "";
            ddlnotice.Text = "0 Days";
            ddlProbatioPd.Text = "0 Days";
            //ContractorCompletionDate.
            txtConfirmationcompletetionDate.Text = "";

        }
        else
        {

            txtConfirmationcompletetionDate.Visible = false;
            lblContractorCompletionDt.Visible = false;

            txtConfirmationcompletetionDate.Text = "";

            lblNoticePeriod.Visible = true;
            ddlnotice.Visible = true;

            lblProbationPeriod.Visible = true;
            ddlProbatioPd.Visible = true;

            txtconfirmationdate.Visible = true;
            lblConfirmationdate.Visible = true;

            txtconfirmationdate.Text = "";
            ddlnotice.Text = "0 Days";
            ddlProbatioPd.Text = "0 Days";

        }  
    }
}