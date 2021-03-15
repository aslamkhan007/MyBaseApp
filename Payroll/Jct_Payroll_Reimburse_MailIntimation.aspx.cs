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

public partial class Payroll_Jct_Payroll_Reimburse_MailIntimation : System.Web.UI.Page
{
    Connection obj = new Connection();
    string location = string.Empty;
    string Sublocation = string.Empty;
    string Empcode = string.Empty;
    string usercode = string.Empty;
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
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddllocation.DataSource = ds;
        ddllocation.DataTextField = "Location_description";
        ddllocation.DataValueField = "Location_code";
        ddllocation.DataBind();
    }
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }

    private void bindgrid()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_ReimbursePending_List", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        grdDetail.DataSource = ds2.Tables[0];
        grdDetail.DataBind();
    }

    private void bindgrid1()
    {
        SqlCommand cmd2 = new SqlCommand("Jct_Payroll_ReimburseSent_List", obj.Connection());
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        cmd2.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        cmd2.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        GridView1.DataSource = ds2.Tables[0];
        GridView1.DataBind();
    }

    private void sendmail(string UserCode)
    {
        try
        {
            sql = string.Empty;
            to = string.Empty;
            from = string.Empty;
            bcc = string.Empty;
            cc = string.Empty;
            subject = string.Empty;
            body = string.Empty;
            url = string.Empty;
            querystring = string.Empty;
            string Body = string.Empty;            
            sql = "SELECT DISTINCT EmailID AS email , EmployeeName AS empname FROM  dbo.JCT_payroll_employees_master WHERE NewEmployeeCode  = '" + UserCode + "' and status = 'A' and active = 'Y' ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                string emailStore;
                if (ds.Tables[0].Rows[0]["email"].ToString() == "")
                {
                    emailStore = "aslam@jctltd.com";
                }
                else
                {
                    emailStore = ds.Tables[0].Rows[0]["email"].ToString();
                }
                to = emailStore;
                //Body = "<html><body><Table><tr><td>Dear User</td></tr><BR /><tr><td>EmployeeCode : " + UserCode + "</td></tr><BR /><tr><td>EmployeeName : " + ds.Tables[0].Rows[0]["empname"].ToString() + " </td> </tr><Br/><tr><td>Please Apply For Reimbursement For The Month Of : " + txttodate.Text.ToString() + " "+" In Employee Portal System "+" </td></tr><Br/>  <tr><td><b>This is System Generated Mail . Please Do Not Reply..</b></td></table></body></html>";
                Body = "<html><body><Table><tr><td>Dear User,</td></tr><BR /><tr><td>EmployeeCode : " + UserCode + "</td></tr><BR /><tr><td>EmployeeName : " + ds.Tables[0].Rows[0]["empname"].ToString() + " </td> </tr><Br/><tr><td>Please Apply For Reimbursement For The Month Of : " + txttodate.Text.ToString() + " " + " In Employee Portal System " + " </td></tr><Br/> <tr><td>Please Ignore This Mail If Already Applied</td></tr>  <Br/><tr><td><b>This is System Generated Mail .So Do Not Reply..</b></td></table></body></html>";
            }
            @from = "noreply@jctltd.com";
            subject = "Conveyance Reimbursement Apply Intimation";
            bcc = "aslam@jctltd.com,rajan@jctltd.com";
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(@from);

            if (to.Contains(","))
            {
                string[] tos = to.Split(',');
                for (int i = 0; i <= tos.Length - 1; i++)
                {
                    mail.To.Add(new MailAddress(tos[i]));
                }
            }
            else
            {
                mail.To.Add(new MailAddress(to));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                if (cc.Contains(","))
                {
                    string[] ccs = cc.Split(',');
                    for (int i = 0; i <= ccs.Length - 1; i++)
                    {
                        mail.CC.Add(new MailAddress(ccs[i]));
                    }
                }
                else
                {
                    mail.CC.Add(new MailAddress(cc));
                }
            }

            if (!string.IsNullOrEmpty(bcc))
            {
                if (bcc.Contains(","))
                {
                    string[] bccs = bcc.Split(',');
                    for (int i = 0; i <= bccs.Length - 1; i++)
                    {
                        mail.Bcc.Add(new MailAddress(bccs[i]));
                    }
                }
                else
                {
                    mail.Bcc.Add(new MailAddress(bcc));
                }
            }

            mail.Subject = subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
            SmtpMail.Send(mail);
            //string script = "alert('Mail  Sent!!');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            obj.ConClose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return;
        }
        finally
        {

        }
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

    protected void lnkConfirmAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in grdDetail.Rows)
        {
            CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkCheck");
            if (chkRemove.Checked == true)
            {
                int rowIndex = (int)gvRow.RowIndex;
                Empcode = gvRow.Cells[2].Text;
                location = gvRow.Cells[3].Text;
                SqlCommand cmd = new SqlCommand("Jct_Payroll_Reimburse_InsertList", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddllocation.SelectedItem.Value;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Empcode;
                cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 30).Value = location;                
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
                sendmail(Empcode);
            }
        }
        bindgrid();
        bindgrid1();
        string script = "alert('Mail Sending Completed !!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Reimburse_MailIntimation.aspx");
    }
    protected void lnkEmailAll_Click(object sender, EventArgs e)
    {
        try
        {
            bindgrid();
            bindgrid1();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return;
        }

    }
}