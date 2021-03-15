using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_SalaryAdvanceApply : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    string strTo;
    string strFrom;
    string strSubject;
    string SqlPass;
    string Sqlpass1;
    string EmailTO, EmailTO1, EmailFrom, EmailCc, EmailBcc, EmailBcc1, Checkflag, Checkflag1;
    bool CheckError = false;
    bool CheckRecord = false;
    bool CheckDate = false;
    Int64 Auto1;
    int Difference;
    int CountMail = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)

            if (Session["Empcode"] == "")
            {
                Response.Redirect("~/Login.aspx");
            }
        SqlCommand cmd = new SqlCommand("Jct_Payroll_SalaryAdvance_EmployeeInfo_Fetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
        //cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "9000000537";                      
        con.Open();
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            lblEmpname.Text = dr[2].ToString();
            lblDept.Text = dr[1].ToString();
            lbldesig.Text = dr[0].ToString();
            lblGross.Text = dr[3].ToString();
        }
        else
        {
            string script = "alert('You are not allowed to Apply Salary Advance!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        dr.Close();
        con.Close();
    }

    private void gencode()
    {
        try
        {
            string str;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(isnull(Autoid,1000000)) from Jct_Payroll_OnLine_Request", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    str = dr[0].ToString();
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                    {
                        string script = "alert('Something Went Wrong !! ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        ViewState["ID"] = int.Parse(dr[0].ToString()) + 1;
                        ViewState["ID"] = ViewState["ID"];
                    }
                }

            }
            dr.Close();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        finally
        {
            con.Close();
        }
    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            gencode();
            SqlCommand cmd = new SqlCommand("Jct_Payroll_SalaryAdvance_EmployeeInfo_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            cmd.Parameters.Add("@autoid", SqlDbType.Int).Value = Convert.ToInt32(ViewState["ID"]);
            cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
            cmd.Parameters.Add("@SadvGrossSal", SqlDbType.Decimal, 7).Value = lblGross.Text;
            cmd.Parameters.Add("@SadvRequiredAmt", SqlDbType.Decimal, 6).Value = SadvRequiredAmt.Text;
            cmd.Parameters.Add("@SadvRequiredDt", SqlDbType.DateTime).Value = txtefffrm.Text;
            cmd.Parameters.Add("@SadvSanctionAmt", SqlDbType.Decimal, 6).Value = SanctionAmount.Text;
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = txtpurpose.Text;
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            //Sendmail();
            //string script = "alert('Salary Advance Applied Successfully.!! ');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        finally
        {
            con.Close();
        }
    }

    public void Sendmail()
    {
        try
        {
            System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient();
            System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
            // ------------------------------------------------------------------------------------------------------------------------------            
            // Severe Name & Prot number
            // ------------------------------------------------------------------------------------------------------------------------------

            Client.Host = "EXCHANGE2k7";
            Client.Port = 25;

            // ------------------------------------------------------------------------------------------------------------------------------
            //if (EmailFrom != "")
            //{
            //    System.Net.Mail.MailAddress From = new System.Net.Mail.MailAddress(EmailFrom);
            //    Message.From = From;
            //}

            System.Net.Mail.MailAddress From = new System.Net.Mail.MailAddress("noreply@jctltd.com");
            Message.From = From;
            // ------------------------------------------------------------------------------------------------------------------------------
            // Send message for To
            // ------------------------------------------------------------------------------------------------------------------------------
            var SqlPass = "Jct_Payroll_Co_MailTo '" + Session["EmpCode"] + "'";
            SqlDataReader Dr = obj.FetchReader(SqlPass);
            try
            {
                if (Dr.HasRows == true)
                {
                    while (Dr.Read())
                    {
                        if (Dr != null && Dr.HasRows)
                        {
                            EmailTO = Dr["EmailID"].ToString();
                            //Message.CC.Add(ViewState["EmployeeFrom"].ToString());
                            Message.CC.Add("aslam@jctltd.com");
                            Message.To.Add(EmailTO);
                        }
                    }
                    Dr.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                obj.ConClose();
            }
            Message.IsBodyHtml = true;
            Message.Priority = System.Net.Mail.MailPriority.High;
            //Message.Body = "" + txtemp.Text + "," + " " + " " + "has applied for Compensatory Leave" + " " + "For Date " + " " + txtdate.Text + " " + "for" + " " + (txtdays.Text) + " " + "day" + "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email is generated Payroll Employee Portal. <br/><br />Kindly do not reply . <br /> Thank You..!!";
            Message.Subject = "Application for Salary Advance :- " + Convert.ToInt32(ViewState["ID"]);

            if (EmailTO != "" & EmailFrom != "" & CheckError == false)
                Client.Send(Message);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Por", "<script language = javascript>alert('LSalary Advance Applied Successfully.!!.')</script>");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "hhh", "<script language = javascript>alert('Error Coming.')</script>");
        }

        finally
        {
        }
    }

    public void EmailIDFrom()
    {
        var SqlPass = "SELECT TOP ( 1 ) a.EmailID FROM    Jct_Payroll_Emp_Address_Detail AS a INNER JOIN dbo.JCT_payroll_employees_master AS b ON a.EmployeeCode = b.EmployeeCode WHERE   b.NewEmployeeCode = '" + Session["Empcode"] + "' AND b.STATUS = 'A' AND b.Active = 'Y' ";
        SqlDataReader Dr = obj.FetchReader(SqlPass);
        try
        {
            if (Dr.HasRows == true)
            {
                while (Dr.Read())
                {
                    if (Dr != null && Dr.HasRows)
                    {
                        EmailFrom = Dr["EmailID"].ToString();
                        ViewState["EmployeeFrom"] = EmailFrom;
                    }
                    else
                        EmailFrom = "dummy@jctltd.com";
                }
                Dr.Close();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            obj.ConClose();
        }
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SalaryAdvanceApply.aspx");
    }
}