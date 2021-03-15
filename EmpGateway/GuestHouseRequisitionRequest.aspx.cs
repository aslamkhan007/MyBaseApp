using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmpGateway_GuestHouseRequisitionRequest : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        
        }
    }

    protected List<String> chkMeals()
    {
        List<String> checkList = new List<String>();
        
        foreach (ListItem item in chkMealsServed.Items)
        {
            if (item.Selected)
            {
                checkList.Add(item.Value);
            }
            
        }

        return checkList;
    }
  
    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            List<String> meals = chkMeals();
            string Mealitem = string.Join("|", meals.ToArray());

            sql = "jct_emp_guesthouse_request_insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = txtGuestName.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 500).Value = txtGuestAddress.Text;
            cmd.Parameters.Add("@PersonNo", SqlDbType.Int).Value = txtNoOfPerson.Text;
            cmd.Parameters.Add("@ToCharge", SqlDbType.VarChar, 1).Value = ddlCharges.SelectedItem.Value;
            cmd.Parameters.Add("@StayRequired", SqlDbType.VarChar, 1).Value = rblStayRequired.SelectedItem.Value;

            if (rblStayRequired.SelectedItem.Text == "No")
            {
                cmd.Parameters.Add("@Meals", SqlDbType.VarChar, 100).Value = Mealitem;//chkMealsServed.SelectedItem.Text;
                cmd.Parameters.Add("@ServeDrinks", SqlDbType.VarChar, 1).Value = ddlDrinksServed1.SelectedItem.Value;
                cmd.Parameters.Add("@PersonAccName", SqlDbType.VarChar, 100).Value = txtPersonAccompained.Text;
                cmd.Parameters.Add("@Accomodation", SqlDbType.VarChar, 100).Value = ddlAccomodateStay.SelectedItem.Text;
                cmd.Parameters.Add("@StDurationFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateofStay.Text);
                cmd.Parameters.Add("@StDurationTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateofStay.Text);
                cmd.Parameters.Add("@Food", SqlDbType.VarChar, 50).Value = ddlFoodStay.SelectedItem.Text;
            }
            else if (rblStayRequired.SelectedItem.Text == "Yes")
            {
                cmd.Parameters.Add("@ServeDrinks", SqlDbType.VarChar, 1).Value = ddlDrinksServed.SelectedItem.Value;
                cmd.Parameters.Add("@PersonAccName", SqlDbType.VarChar, 100).Value = txtPersonAccompained0.Text;
                cmd.Parameters.Add("@StDurationFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtFrom.Text);
                cmd.Parameters.Add("@StDurationTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtTo.Text);
                cmd.Parameters.Add("@Accomodation", SqlDbType.VarChar, 100).Value = ddlAccomodate.SelectedItem.Text;
                cmd.Parameters.Add("@Food", SqlDbType.VarChar, 50).Value = ddlFood.SelectedItem.Text;
            }

            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"].ToString();
            cmd.ExecuteNonQuery();
            SendMail();

            String Script = "alert('Request Submitted.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Script, true);
        }
        catch (Exception ex)
        {
            String Script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Script, true);
        }
    }

    protected void rblStayRequired_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblStayRequired.SelectedItem.Text == "Yes")
        {
            pnlStayYes.Visible = true;
            pnlStayNo.Visible = false;
        }
        else if (rblStayRequired.SelectedItem.Text == "No")
        {
            txtDateofStay_CalendarExtender.SelectedDate = DateTime.Now;
            pnlStayNo.Visible = true;
            pnlStayYes.Visible = false;
        }
    }


    private void SendMail()
    {
        try
        {
            string sql = string.Empty;
            string to = string.Empty;
            string from = string.Empty;
            string bcc = string.Empty;
            string cc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;
            string url = string.Empty;
            string querystring = string.Empty;
            string Body = string.Empty;

            subject = "Guest House Requisition";
            Body = "Guest House Requisition has been submitted.";
            to = "saini@jctltd.com";
            bcc = "jatindutta@jctltd.com";
            @from = "noreply@jctltd.com";

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
            SmtpClient SmtpMail = new SmtpClient("exchange2007");
            SmtpMail.Send(mail);
        }
        catch (Exception ex)
        {
            //lblError.Text = "Error : " + ex.Message;
            return;
        }

    }
}