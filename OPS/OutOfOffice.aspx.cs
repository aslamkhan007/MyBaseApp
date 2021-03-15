﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;

public partial class OPS_OutOfOffice : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    string script = "";
    string areacode;
    List<String> AreaCodes = new List<String>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grd.Visible = true;
            sql = "SELECT [SrNo], [UserCode], Convert(varchar,[DateFrom],103) as DateFrom, Convert(varchar,[DateTo],103) as DateTo, [STATUS], [REMARKS] FROM [JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE] WHERE (([STATUS] = 'A') AND ([EntryBy] = '"+ Session["EmpCode"] +"'))";
            obj1.FillGrid(sql, ref grd);

            //grd.DataSource = SqlDataSource2;
            //grd.DataBind();
        }
        
    }
    protected void lnkApply_Click(object sender, EventArgs e)
    {
        AreaCodesList();
        try
        {
            sql = " Exec JCT_OPS_COUNT_PENDING_SANCTION_NOTES '" + txtEmployee.Text.Split('|')[1].ToString() + "'";
            int count = Convert.ToInt16(obj1.FetchValue(sql).ToString());

            if (count > 0)
            {
                script = "alert('Some Sanction Notes are found pending at " + txtEmployee.Text.Split('|')[0].ToString() + ". Please get them authorized first in order to complete this transaction..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                sql = "JCT_OPS_SANCTIONNOTE_OUT_OFFICE_INSERT";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 10).Value = txtEmployee.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 25).Value = txtDateFrom.Text;
                cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 25).Value = txtDateTo.Text;
                cmd.Parameters.Add("@REMARKS", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
                cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 500).Value = areacode;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlPlant.SelectedItem.Text;
                cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                cmd.ExecuteNonQuery();
                sql = "SELECT [SrNo], [UserCode], Convert(varchar,[DateFrom],103) as DateFrom, Convert(varchar,[DateTo],103) as DateTo, [STATUS], [REMARKS] FROM [JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE] WHERE (([STATUS] = 'A') AND ([UserCode] = '" + Session["EmpCode"] + "'))";
                obj1.FillGrid(sql, ref grd);
                SendMail();
                script = "alert('Record Submitted Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        //sql = "JCT_OPS_SANCTIONNOTE_OUT_OFFICE_INSERT";
        //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 10).Value =txtEmployee.Text;
        //cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 25).Value = txtDateFrom.Text;
        //cmd.Parameters.Add("@DATETO", SqlDbType.VarChar ,25).Value = txtDateTo.Text;
        //cmd.Parameters.Add("@REMARKS", SqlDbType.VarChar, 500).Value = txtRemarks.Text ;
        //cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 500).Value = areacode;
        //cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlPlant.SelectedItem.Text;
        //cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        //cmd.ExecuteNonQuery();
        //sql = "SELECT [SrNo], [UserCode], Convert(varchar,[DateFrom],103) as DateFrom, Convert(varchar,[DateTo],103) as DateTo, [STATUS], [REMARKS] FROM [JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE] WHERE (([STATUS] = 'A') AND ([UserCode] = '" + Session["EmpCode"] + "'))";
        //obj1.FillGrid(sql, ref grd);
        //SendMail();
        //script = "alert('Record Submitted Successfully..!!');";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch {
            script = "alert('Some Error Occured While Submitting Record..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
       
    }


    protected void AreaCodesList()
    {

        for (int i = 0; i <= chbArea.Items.Count - 1; i++)
        {
            if (chbArea.Items[i].Selected == true)
            { 
                
         
                AreaCodes.Add(chbArea.Items[i].Value);
         

            }
        }

        areacode = string.Join(",", AreaCodes.ToArray());
    }

    protected void chbArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
   if (chbArea.SelectedItem.Text == "All")
        {
            for (int i = 0; i <= chbArea.Items.Count - 1; i++)
            {
                chbArea.Items[i].Selected = true;

                if (chbArea.SelectedItem.Text != "All")
                {
                    AreaCodes.Add(chbArea.Items[i].Value);
                }

            }

          
            
        }
        }

        catch

        { 
        
        }
     
        
        
    }
    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtEmployee.Text = txtEmployee.Text.Split('~')[1].ToString();
        }
        catch { }
        
    }

    private void SendMail()
    {


        string from, to, bcc, cc, subject, body;

        string RequestBy = "";

        sql = "Select e_mailid from mistel where empcode='" + txtEmployee.Text.Split('|')[1].ToString() + "'";
        to = obj1.FetchValue(sql).ToString();
        sql = "Select e_mailid from mistel where empcode='" + Session["EmpCode"] + "'";
        cc = obj1.FetchValue(sql).ToString();

        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
        RequestBy = obj1.FetchValue(sql).ToString();


        sql = "Select empname from jct_empmast_base where empcode='" + txtEmployee.Text.Split('|')[1].ToString() + "'";
        string Employee = obj1.FetchValue(sql).ToString();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("</head>");

        // sb.Append("<head>");
        sb.AppendLine("Hello " + Employee + ",<br/><br/>");
        sb.AppendLine("This mail is just to notify you that you will not be present in JCT Ltd, Phagwara from " + txtDateFrom.Text + " to " + txtDateTo.Text + ". So, within this period all the sanction notes doesnt require your approval.<br/><br/>");
        sb.AppendLine("Out of office transaction has been made by " + RequestBy + "<br/><br/>");

        sb.AppendLine(" Remarks : " + txtRemarks.Text + "<br/>");
        sb.AppendLine("<br />");
        sb.AppendLine("This is a system generated mail, please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";
        if (!string.IsNullOrEmpty(to))
        {
            to = to + ',' + cc;
        }
        else
        {

        }

        bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        subject = "Out of Office..!! ";
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


        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");
        SmtpMail.Send(mail);

    }
    protected void grd_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDateFrom.Text = grd.SelectedRow.Cells[3].ToString();
        txtDateTo.Text = grd.SelectedRow.Cells[4].ToString();

    }
}