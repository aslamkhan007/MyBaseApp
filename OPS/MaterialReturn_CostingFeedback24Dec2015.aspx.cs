using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

public partial class OPS_MaterialReturn_CostingFeedback : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    string script;
    SqlCommand cmd;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdApply_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Jct_opS_MR_Costing_Feedback_Insert '" + Session["empcode"] + "','" + grdDetail.SelectedRow.Cells[1].Text + "','" + txtRemarks.Text + "','" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "' ";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.ExecuteNonQuery();
            script = "alert('Feedback Updated..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            SendMail(grdDetail.SelectedRow.Cells[1].Text);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message.ToString() + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    private void SendMail(String sanctionNoteID)
    {
        string from, to, bcc, cc, subject, body;
        body=string.Empty;
        subject = "Material Return Costing Feedback against ID :-" + sanctionNoteID;
        from = "noreply@jctltd.com";   //Email Address of Sender








        string NotifyEmailGroup = "ashish@jctltd.com";
        string RaisedByMail=string.Empty;
        //qry = "SELECT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='1590'";
        cmd = new SqlCommand("Jct_MrClosure_Notify_Users", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        //cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = ViewState["SanctionID"];
        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = grdDetail.SelectedRow.Cells[1].Text;

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                if (dr[1].ToString() == "UserType")
                { RaisedByMail = dr[0].ToString(); }
                NotifyEmailGroup = NotifyEmailGroup + "," + dr[0];
            }
        }
        dr.Close();



        string Genratedby_Email = string.Empty;
        sql = "SELECT E_MailID FROM  mistel  WHERE  empcode  = '" + Session["EmpCode"].ToString() + "' ";
        cmd = new SqlCommand(sql, obj.Connection());
        dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                Genratedby_Email = dr[0].ToString();
            }
        }
        dr.Close();
        //to = RaisedByMail;
        //cc = NotifyEmailGroup + "," + Genratedby_Email;
        to = "ashish@jctltd.com";
        cc = "ashish@jctltd.com";
        bcc = "ashish@jctltd.com";
        body = "<b>Costing Feedback Against Material Return ID :- " + sanctionNoteID + " has been given by Mr.Sunil Jain</b><br/><br/><hr> With Following Remarks<br/> <b> " + txtRemarks.Text + "<br/><br/><hr><i> This is a user generated email please donot reply </i>" ;

        //body = body; //+ " " + NotifyEmailGroup + "," + Genratedby_Email;
        MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                if (to.Contains(","))
                {
                    string[] tos = to.Split(',');
                    for (int i = 0; i < tos.Length; i++)
                    {
                        mail.To.Add(new MailAddress(tos[i]));
                    }
                }
                else
                {
                    mail.To.Add(new MailAddress(to));
                }

                if (!string.IsNullOrEmpty(bcc))
                {
                    if (bcc.Contains(","))
                    {
                        string[] bccs = bcc.Split(',');
                        for (int i = 0; i < bccs.Length; i++)
                        {
                            mail.Bcc.Add(new MailAddress(bccs[i]));
                        }
                    }
                    else
                    {
                        mail.Bcc.Add(new MailAddress(bcc));
                    }
                }
                if (!string.IsNullOrEmpty(cc))
                {
                    if (cc.Contains(","))
                    {
                        string[] ccs = cc.Split(',');
                        for (int i = 0; i < ccs.Length; i++)
                        {
                            mail.CC.Add(new MailAddress(ccs[i]));
                        }
                    }
                    else
                    {
                        mail.CC.Add(new MailAddress(bcc));
                    }
                    mail.CC.Add(new MailAddress(cc));
                }

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpClient SmtpMail = new SmtpClient("exchange2k7");

                //SmtpMail.SmtpServer = "exchange2007";
                SmtpMail.Send(mail);

        //sendmail();

      

    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "exec Jct_Ops_Mr_Folding_Observation_Excess_Fetch_Ashish '" + grdDetail.SelectedRow.Cells[1].Text + "'";
        //sql = "exec Jct_Ops_Mr_Folding_Observation_Excess_Fetch_Ashish '1929'";
        obj1.FillGrid(sql, ref grdFoldingObservation);
    }
}