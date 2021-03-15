using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Web.Mail;
using System.Text;

public partial class OPS_Gst_Hsn_Sac_Detail : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string emailid;
    string RequesterBy;
    SqlConnection con = new SqlConnection(@"Data Source=Miserp;Initial Catalog=Common;User ID=itgrp ;password=power");

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //Bindgrid();
            //con.Open();
            //sql = "Jct_Gst_Hsn_Sac_Detail_AutoFetch";

            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 20).Value = ViewState["empcode"];
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //grdDetail.DataSource = ds.Tables[0];
            //grdDetail.DataBind();
            //con.Close();
        }

    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string a = txtItem.Text.Split('/')[0].ToString();
            string b = txtItem.Text.Split('/')[1].ToString();
            con.Open();
            sql = "Jct_Gst_Hsn_Sac_Detail_Insert";
            SqlCommand cmd = new SqlCommand(sql, con);
           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@item", SqlDbType.VarChar, 100).Value = a;
            cmd.Parameters.Add("@Varient", SqlDbType.VarChar, 100).Value = b;
            cmd.Parameters.Add("@Stock_Desc", SqlDbType.VarChar, 100).Value = txtStockDesc.Text;
            cmd.Parameters.Add("@Varient_Desc", SqlDbType.VarChar, 100).Value = txtVarientDesc.Text;
            cmd.Parameters.Add("@Gst_Class", SqlDbType.VarChar, 100).Value = ddlGstClass.SelectedItem.Text;
            cmd.Parameters.Add("@Hsn_Sac_No", SqlDbType.VarChar, 100).Value = txtHsnSacNo.Text;
            cmd.Parameters.Add("@Hsn_Sac", SqlDbType.VarChar, 100).Value = txtlocdesc0.Text;
            cmd.Parameters.Add("@Rerverse_Charge", SqlDbType.Char, 1).Value = ddlReverseCharge.SelectedItem.Text;       
            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
            //cmd.ExecuteNonQuery();
            con.Close();


            string   sql1 = "Select Name  from   mistel WHERE empcode ='" + Session["Empcode"].ToString() + "'";

            SqlCommand cmd1 = new SqlCommand(sql1, obj.Connection());
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);

            if (ds1.Tables.Count > 0)
            {               
                RequesterBy = ds1.Tables[0].Rows[0]["Name"].ToString();
            }



            //String msg = "<html><body><Table><tr><td>Dear,</td></tr><tr><td>Please  Fill  The  Inventory Detail in Path.</td></tr><tr><td>Inventory / Master / ItemDetail  /Gst EDK Screen</td></tr><tr></tr></tr></tr> <tr><td>Thanks..!!<br/><br/></td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";
            String msg = "<html><body><Table><tr><td>Dear,</td></tr><tr><td>Please  Fill  The  Inventory Detail in Path.</td></tr><tr><td>Inventory / Master / ItemDetail  /Gst EDK Screen</td></tr><tr> <td>Request By : " + RequesterBy + "  </td></tr> <tr> <td>Stock no  : " + a + "  </td></tr>  <tr> <td>Varient  : " + b + "  </td></tr>  <tr> <td>Stock Desc  : " + txtStockDesc.Text + "  </td></tr>  <tr> <td>Varient Desc  : " + txtVarientDesc.Text + "  </td></tr>   <tr> <td>Gst Class  : " + ddlGstClass.SelectedItem.Text + "  </td></tr>  <tr> <td>HSN/SAC No  : " + txtHsnSacNo.Text + "  </td></tr>  <tr> <td>HSN/SAC DESC  : " + txtlocdesc0.Text + "  </td></tr>  <tr> <td>Reverse Charges  : " + ddlReverseCharge.SelectedItem.Text + "  </td></tr>   <tr></tr></tr></tr> <tr><td>Thanks..!!<br/><br/></td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";
            SendMailWithAttachments(msg);

            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
          
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }


    //public void Bindgrid()
    //{
    //    con.Open();
    //    sql = " SELECT b.Location_description AS location ,Accomdation_Type,Start_HouseNo,End_HouseNo,Effective_From,Effective_To FROM JCT_payroll_accomdation_master a JOIN dbo.JCT_payroll_location_master b ON a.Location_code=b.Location_code WHERE a.STATUS='A'";
    //    SqlCommand cmd = new SqlCommand(sql, con);
    //    cmd.CommandType = CommandType.Text;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    grdDetail.DataSource = ds.Tables[0];
    //    grdDetail.DataBind();
    //    con.Close();

    //    //con.Open();
    //    //sql = "Jct_Gst_Hsn_Sac_Detail_AutoFetch";
       
    //    //SqlCommand cmd = new SqlCommand(sql, con);        
    //    //cmd.CommandType = CommandType.StoredProcedure;
    //    //cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 20).Value = ViewState["empcode"];
    //    //cmd.CommandType = CommandType.StoredProcedure;
    //    //SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    //DataSet ds = new DataSet();
    //    //da.Fill(ds);
    //    //grdDetail.DataSource = ds.Tables[0];
    //    //grdDetail.DataBind();
    //    //con.Close();
    //}

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Gst_Hsn_Sac_Detail.aspx");
    }

    protected void txtItem_TextChanged(object sender, EventArgs e)
    {
        string a = txtItem.Text.Split('/')[0].ToString();
        string b = txtItem.Text.Split('/')[1].ToString();
        string sqlPass = "SELECT  a.description 'stock_description' ,b.description 'variant_description' FROM    miserp.common.dbo.ims_stock_master a , miserp.common.dbo.ims_variant_master b WHERE   a.stock_type NOT IN ( '2', '3','0' ) AND a.stock_no = b.stock_no AND a.stock_no = '" + a + "'  AND    b.variant_no = '" + b + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(sqlPass, con);
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                this.txtStockDesc.Text = dr[0].ToString();
                this.txtVarientDesc.Text = dr[1].ToString();

            }
        }
        dr.Close();
        con.Close();
    }

    protected void SendMailWithAttachments(String Body)
    {
            
            sql = "Select E_MailID,Name  from   mistel WHERE empcode ='" + Session["Empcode"].ToString() + "'";
            
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                emailid = ds.Tables[0].Rows[0]["E_MailID"].ToString();
                RequesterBy = ds.Tables[0].Rows[0]["Name"].ToString();
            }


        /* Create a new blank MailMessage */
        MailMessage mailMessage = new MailMessage();
        String MailCC = "";
        mailMessage.From = "gstitemdetail@jctltd.com";
        mailMessage.BodyFormat = MailFormat.Html;
        mailMessage.To = emailid;
        mailMessage.To = "nakra@jctltd.com,sanjivseth@jctltd.com";
        //mailMessage.Bcc = "aslam@jctltd.com";
        mailMessage.Cc = emailid + ',' + "ranjeetk@jctltd.com";
        mailMessage.Subject =  " (GST Item Detail)";
        mailMessage.Body = Body;
        SmtpMail.SmtpServer = "exchange2k7";
        SmtpMail.Send(mailMessage);

    }
}