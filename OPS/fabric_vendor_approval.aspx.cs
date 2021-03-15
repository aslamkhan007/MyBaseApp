using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class OPS_fabric_vendor_approval : System.Web.UI.Page
{
    //SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["testjctgen"].ConnectionString);
    //SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["test"].ConnectionString);

    SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_vendr_shrtlst", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            con.Close();
        }
       
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON_FAB", conjctgen);
            cmd.CommandType = CommandType.StoredProcedure;
            conjctgen.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail2.DataSource = ds.Tables[0];
            grdDetail2.DataBind();
            conjctgen.Close();

            cmd = new SqlCommand("select distinct vendor, isnull(approved ,'n') as approved from jct_ops_out_fab_vendor   a INNER JOIN dbo.jct_ops_outsrd_dyed_fab b ON a.requestID=b.RequestID where a.requestid=@requestid", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
            ViewState["RequestID"] = grdDetail.SelectedRow.Cells[1].Text;

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            chklist.DataSource = ds.Tables[0];

            chklist.DataTextField = "vendor";
            chklist.DataValueField = "vendor";
            chklist.DataBind();

            con.Close();
            //grdDetail2.DataSource = ds.Tables[0];
            //grdDetail2.DataBind();
            //conjctgen.Close();
            lbcomp.Visible = true;
            lbvendlst.Visible = true;


            string sql = "select distinct isnull(b.status_log,'') as status_log from jct_ops_out_fab_vendor a INNER JOIN dbo.jct_ops_outsrd_dyed_fab b ON a.requestID=b.RequestID where a.requestid='" + grdDetail.SelectedRow.Cells[1].Text + "'";
            string status_log = obj1.FetchValue(sql).ToString();
            ViewState["status_log"] = status_log;

            sql = "select distinct plant from dbo.jct_ops_outsrd_dyed_fab where requestid='" + grdDetail.SelectedRow.Cells[1].Text + "'";
            ViewState["Plant"] = obj1.FetchValue(sql).ToString();
            

            if (status_log == "RMAuth")
            {
                chklist.Enabled = false;

            }
            else if (status_log == "FinalAuth")
            {
                chklist.Enabled = true;
            }
            else if (status_log == "FinalCancel")
            {
                chklist.Enabled = false;
            }
            else
            { 
            
            }
 
            for (int i = 0; i <= chklist.Items.Count - 1; i++)
            {
                string vndrlist;
                vndrlist = chklist.Items[i].Text;
                cmd = new SqlCommand("jct_ops_fab_vndr_list", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 10).Value = vndrlist;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                con.Close();
                string output = cmd.Parameters["@flag"].Value.ToString();
                if (output == "1")
                {
                    chklist.Items[i].Selected = true;
                }
            }
        }
        catch(Exception ex)
        {
            string script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
    }

    protected void lnkapprove_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        try
        {
            if (ViewState["status_log"].ToString() == "RMAuth")
            {
                cmd = new SqlCommand("jct_ops_fab_apprvals", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
                cmd.Parameters.Add("@approvedby", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                cmd.Parameters.Add("@approveRmk", SqlDbType.VarChar, 200).Value = txtRemarks.Text;

                cmd.ExecuteNonQuery();
                con.Close();
                //SendMailYarn();
                string script = "alert('Record Saved Successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else if (ViewState["status_log"].ToString() == "FinalAuth")
            {
                for (int i = 0; i <= chklist.Items.Count - 1; i++)
                {
                    if (chklist.Items[i].Selected == true)
                    {
                        cmd = new SqlCommand("jct_ops_fab_apprvals", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
                        cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 30).Value = chklist.Items[i].Text;
                        cmd.Parameters.Add("@approvedby", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                        cmd.Parameters.Add("@approveRmk", SqlDbType.VarChar, 200).Value = txtRemarks.Text;

                        cmd.ExecuteNonQuery();
                        //con.Close();
                        //SendMailYarn();
                        string script = "alert('Record Saved Successfully.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }

                // float and freeze request here ..

                cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_freeze", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@freezeby", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                cmd.ExecuteNonQuery();

                // insert authorization 

                cmd = new SqlCommand("Jct_Ops_SanctionNote_InsertDynamic_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SanctionNote", SqlDbType.VarChar, 15).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                cmd.Parameters.Add("@Areacode", SqlDbType.Int).Value = 1042;
                cmd.Parameters.Add("@StartID", SqlDbType.SmallInt).Value = 0;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ViewState["Plant"];
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
            sendmailVendor();
        }
        catch(Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        

       
    }

    protected void lnkreject_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow rw in grdDetail2.Rows)
            {
                SqlCommand cmd = new SqlCommand("jct_ops_fab_apprvals_rej", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = rw.Cells[1].Text;
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 100).Value = rw.Cells[2].Text;
                cmd.Parameters.Add("@approvedby", SqlDbType.VarChar, 10).Value = Session["Empcode"].ToString();
                cmd.Parameters.Add("@approveRmk", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
            sendmailVendor();
        }
        catch
        { 
        
        }
       
    }

    private void sendmailVendor()
    {
        try
        {
            string sql = string.Empty;
            string to = string.Empty;
            string from = string.Empty;
            string bcc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;

            sql = "jct_ops_fab_vendor_freeze_mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = ViewState["RequestID"].ToString();
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    to = dr["sendtomail"].ToString();
                    body = dr["email_body"].ToString();
                    subject = dr["subject"].ToString();
                }
            }
            else
            {

            }

            @from = "Outsourcing@jctltd.com";

            bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com,jatindutta@jctltd.com";

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

            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
            SmtpMail.Send(mail);
        }
        catch
        {

        }
    }

    protected void chklist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}