using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
public partial class OPS_reportsecond : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
       // string str = "Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;Password=trainee";
       //SqlConnection con = new SqlConnection(str);
       //  con.Open();
        SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_select", obj.Connection());
        //SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_select", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetails.DataSource = ds;
        //grdDetails.DataSource = ds;
        grdDetails.DataBind();
        cmd.ExecuteNonQuery();
        grdDetails.DataBind();
        cmd.ExecuteNonQuery();
        //con.Close();
        //obj.Connection();
       
    }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblid.Text = grdDetails.SelectedRow.Cells[1].Text;
        txtDate.Text = grdDetails.SelectedRow.Cells[2].Text;
        txtMachineNo.Text = grdDetails.SelectedRow.Cells[3].Text;
        txtCountNo.Text = grdDetails.SelectedRow.Cells[4].Text;
        txtSource.Text = grdDetails.SelectedRow.Cells[5].Text;
        txtTestedLen.Text = grdDetails.SelectedRow.Cells[6].Text;
        txtTestedWeight.Text = grdDetails.SelectedRow.Cells[7].Text;
        txtAddFdFaults.Text = grdDetails.SelectedRow.Cells[8].Text;
        txtAllfdCUTS.Text = grdDetails.SelectedRow.Cells[9].Text;
        txtVegMatter.Text = grdDetails.SelectedRow.Cells[10].Text;
        txtDarkColoredMatter.Text = grdDetails.SelectedRow.Cells[11].Text;
        txtVisualObserv.Text = grdDetails.SelectedRow.Cells[12].Text;
        txtRemark.Text = grdDetails.SelectedRow.Cells[13].Text;
       

    }

    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            //string txtvalue = txtMachineNo.Text;
            //string id;
            //if (!string.TryParse(txtvalue, out id)) 
            //{
            //    throw new ApplicationException("please enter correct machine no.");

            //}

            string testedlentxt = txtTestedLen.Text;
            decimal testlenid;
            if (!decimal.TryParse(testedlentxt, out testlenid))
            //if (!     .TryParse(testedlentxt, out testlenid))
            {
                throw new ApplicationException("please enter correct Tested Length no.");

            }

            string testedweighttxt = txtTestedWeight.Text;
            decimal testedweightid;
            if (!decimal.TryParse(testedweighttxt, out testedweightid))
            {
                throw new ApplicationException("please enter correct Tested Weight no.");

            }



            string AddFdFaultstxt = txtAddFdFaults.Text;
            decimal AddFdFaultsId;
            if (!decimal.TryParse(AddFdFaultstxt, out AddFdFaultsId))
            {
                throw new ApplicationException("please enter correct Fd Faults no.");

            }

            string AllfdCUTStxt = txtAllfdCUTS.Text;
            decimal AllfdCUTSId;
            if (!decimal.TryParse(AllfdCUTStxt, out AllfdCUTSId))
            {
                throw new ApplicationException("please enter correct Fd Cuts no.");

            }

            string MatterVeg = txtVegMatter.Text;
            int MatterVegid;
            if (!int.TryParse(MatterVeg, out MatterVegid))
            {
                throw new ApplicationException("please enter correct Veg Matter Value.");

            }

            string darkmatter = txtDarkColoredMatter.Text;
            int darkmatterid;
            if (!int.TryParse(darkmatter, out darkmatterid))
            {
                throw new ApplicationException(" please enter correct dark colored matter.");
            }

            //string str = "Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;Password=trainee";
            //SqlConnection con = new SqlConnection(str);
            //con.Open();

            // create the connection an opened  for usage

            //SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_INSERT",obj.Connection());
            SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_INSERT", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = txtDate.Text;
            cmd.Parameters.Add("@MachineNo", SqlDbType.VarChar, 30).Value = txtMachineNo.Text;
            cmd.Parameters.Add("@CountNo", SqlDbType.VarChar, 30).Value = txtCountNo.Text;
            cmd.Parameters.Add("@Source", SqlDbType.VarChar, 30).Value = txtSource.Text;
            cmd.Parameters.Add("@Tested_Len", SqlDbType.Decimal, 8).Value = txtTestedLen.Text.ToString();
            cmd.Parameters.Add("@Tested_Weight", SqlDbType.Decimal, 8).Value = txtTestedWeight.Text.ToString();
            cmd.Parameters.Add("@Fd_Faults_per_100km", SqlDbType.Decimal,8).Value = txtAddFdFaults.Text.ToString();
            cmd.Parameters.Add("@Fd_Cuts_per_100KM", SqlDbType.Decimal, 8).Value = txtAllfdCUTS.Text.ToString();
            cmd.Parameters.Add("@Visual_Observe", SqlDbType.VarChar, 30).Value = txtVisualObserv.Text;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar, 100).Value = txtRemark.Text;
            cmd.Parameters.Add("@Veg_Matters", SqlDbType.Int, 9).Value = txtVegMatter.Text;
            cmd.Parameters.Add("@DARK_COLORED_FD_MATTERS", SqlDbType.Int, 9).Value = txtDarkColoredMatter.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetails.DataSource = ds;
            //grdDetails.DataSource = ds;
            //grdDetails.DataBind();
            //cmd.ExecuteNonQuery();
            grdDetails.DataBind();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //obj.Connection();
           // Response.Write("<script>alert('record sucessfully inserted');</script>");
            txtDate.Text = "";
            txtMachineNo.Text = "";
            txtCountNo.Text = "";
            txtSource.Text = "";
            txtTestedLen.Text = "";
            txtTestedWeight.Text = " ";
            txtAddFdFaults.Text = " ";
            txtAllfdCUTS.Text = " ";
            txtVisualObserv.Text = " ";
            txtRemark.Text = " ";
            txtDarkColoredMatter.Text = "";
            txtVegMatter.Text = "";

            string script = "alert('record sucessfully inserted');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch (ApplicationException exception)
        {
            //Response.Write("<script>alert('" + exception.Message + "');</script>");

            lblErrMachineNo.Message = exception.Message;

            lblErrMachineNo.Display();

            

        }

    }

    protected void ImgBtnDel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //string txtvalue = txtMachineNo.Text;
            //int id;
            //if (!Int32.TryParse(txtvalue, out id))
            //{
            //    throw new ApplicationException("please enter correct machine no.");

            //}





            string testedlentxt = txtTestedLen.Text;
            decimal testlenid;
            if (!decimal.TryParse(testedlentxt, out testlenid))
            //if (!     .TryParse(testedlentxt, out testlenid))
            {
                throw new ApplicationException("please enter correct Tested Length no.");

            }

            string testedweighttxt = txtTestedWeight.Text;
            decimal testedweightid;
            if (!decimal.TryParse(testedweighttxt, out testedweightid))
            {
                throw new ApplicationException("please enter correct Tested Weight no.");

            }



            string AddFdFaultstxt = txtAddFdFaults.Text;
            decimal AddFdFaultsId;
            if (!decimal.TryParse(AddFdFaultstxt, out AddFdFaultsId))
            {
                throw new ApplicationException("please enter correct Fd Faults no.");

            }

            string AllfdCUTStxt = txtAllfdCUTS.Text;
            decimal AllfdCUTSId;
            if (!decimal.TryParse(AllfdCUTStxt, out AllfdCUTSId))
            {
                throw new ApplicationException("please enter correct Fd Cuts no.");

            }
            string MatterVeg = txtVegMatter.Text;
            int MatterVegid;
            if (!int.TryParse(MatterVeg, out MatterVegid))
            {
                throw new ApplicationException("please enter correct Veg Matter Value.");

            }

            string darkmatter = txtDarkColoredMatter.Text;
            int darkmatterid;
            if (!int.TryParse(darkmatter, out darkmatterid))
            {
                throw new ApplicationException(" please enter correct dark colored matter.");
            }



           // string str = "Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;Password=trainee";
           // SqlConnection con = new SqlConnection(str);
           // con.Open();

            // create the connection an opened  for usage

            //SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_delete", obj.Connection());
            SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_delete", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Sr_No", SqlDbType.Int).Value = lblid.Text.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetails.DataSource = ds;
            //grdDetails.DataSource = ds;
            //grdDetails.DataBind();
            //cmd.ExecuteNonQuery();
            grdDetails.DataBind();
            cmd.ExecuteNonQuery();
           // con.Close();
            //obj.Connection();
            //Response.Write("<script>alert('record sucessfully demarked');</script>");
            string script = "alert('record sucessfully demarked');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            txtDate.Text = "";
            txtMachineNo.Text = "";
            txtCountNo.Text = "";
            txtSource.Text = "";
            txtTestedLen.Text = "";
            txtTestedWeight.Text = " ";
            txtAddFdFaults.Text = " ";
            txtAllfdCUTS.Text = " ";
            txtVisualObserv.Text = " ";
            txtRemark.Text = " ";
            txtDarkColoredMatter.Text = "";
            txtVegMatter.Text = "";
        }
        catch (ApplicationException exception)
        {
            //Response.Write("<script>alert('" + exception.Message + "');</script>");

            lblErrMachineNo.Message = exception.Message;

            lblErrMachineNo.Display();



        }


    }

    protected void ImgBtnAuthorize_Click(object sender, ImageClickEventArgs e)
    {
       // string str = "Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;Password=trainee";
        //SqlConnection con = new SqlConnection(str);
        //con.Open();

        //SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_Authorize", obj.Connection());
        SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_Authorize", obj.Connection());
        cmd.Parameters.Add("@Sr_No", SqlDbType.Int).Value = lblid.Text.ToString();
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetails.DataSource = ds;
        //grdDetails.DataSource = ds;
        //grdDetails.DataBind();
        //cmd.ExecuteNonQuery();
        grdDetails.DataBind();
        //cmd.ExecuteNonQuery();
        //con.Close();
        //obj.Connection();

        // THIS CODING WAS DONE BEFORE THE SECOND FUNCTION WAS USED 
        //sendmailSendMessage("subject", "hiiiii", "aslam@jctltd.com", "aslam@jctltd.com");
        SendMail();
     //   Response.Write("<script>alert('record sucessfully Authorized and Mail has been generated ');</script>");
        txtDate.Text = "";
        txtMachineNo.Text = "";
        txtCountNo.Text = "";
        txtSource.Text = "";
        txtTestedLen.Text = "";
        txtTestedWeight.Text = " ";
        txtAddFdFaults.Text = " ";
        txtAllfdCUTS.Text = " ";
        txtVisualObserv.Text = " ";
        txtRemark.Text = " ";
        txtDarkColoredMatter.Text = "";
        txtVegMatter.Text = "";
        string script = "alert('record sucessfully Authorized and Mail has been generated');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

    }


    protected void ImgBtnModify_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            //string txtvalue = txtMachineNo.Text;
            //int id;
            //if (!Int32.TryParse(txtvalue, out id))
            //{
            //    throw new ApplicationException("please enter correct machine no.");

            //}
            string testedlentxt = txtTestedLen.Text;
            decimal testlenid;
            if (!decimal.TryParse(testedlentxt, out testlenid))
            //if (!     .TryParse(testedlentxt, out testlenid))
            {
                throw new ApplicationException("PLEASE ENTER CORRECT TESTED LENGTH NO.");

            }

            string testedweighttxt = txtTestedWeight.Text;
            decimal testedweightid;
            if (!decimal.TryParse(testedweighttxt, out testedweightid))
            {
                throw new ApplicationException("PLEASE ENTER CORRECT TESTED WEIGHT NO.");

            }



            string AddFdFaultstxt = txtAddFdFaults.Text;
            decimal AddFdFaultsId;
            if (!decimal.TryParse(AddFdFaultstxt, out AddFdFaultsId))
            {
                throw new ApplicationException("PLEASE ENTER CORRECT FAULTS NO.");

            }

            string AllfdCUTStxt = txtAllfdCUTS.Text;
            decimal AllfdCUTSId;
            if (!decimal.TryParse(AllfdCUTStxt, out AllfdCUTSId))
            {
                throw new ApplicationException("PLEASE ENTER CORRECT FD CUTS NO.");

            }

            string MatterVeg = txtVegMatter.Text;
            int MatterVegid;
            if (!int.TryParse(MatterVeg, out MatterVegid))
            {
                throw new ApplicationException("please enter correct Veg Matter Value.");

            }

            string darkmatter = txtDarkColoredMatter.Text;
            int darkmatterid;
            if (!int.TryParse(darkmatter, out darkmatterid))
            {
                throw new ApplicationException(" please enter correct dark colored matter.");
            }


            //string str = "Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;Password=trainee";
            //SqlConnection con = new SqlConnection(str);
            //con.Open();

            // create the connection an opened  for usage

            //SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_update", obj.Connection());
            SqlCommand cmd = new SqlCommand("jct_ops_classimate_fd_update", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = txtDate.Text;
            cmd.Parameters.Add("@MachineNo", SqlDbType.VarChar, 30).Value = txtMachineNo.Text;
            cmd.Parameters.Add("@CountNo", SqlDbType.VarChar, 30).Value = txtCountNo.Text;
            cmd.Parameters.Add("@Source", SqlDbType.VarChar, 30).Value = txtSource.Text;
            cmd.Parameters.Add("@Tested_Len", SqlDbType.Decimal, 8).Value = txtTestedLen.Text.ToString();
            cmd.Parameters.Add("@Tested_Weight", SqlDbType.Decimal, 8).Value = txtTestedWeight.Text.ToString();
            cmd.Parameters.Add("@Fd_Faults_per_100km", SqlDbType.Decimal).Value = txtAddFdFaults.Text.ToString();
            cmd.Parameters.Add("@Fd_Cuts_per_100KM", SqlDbType.Decimal, 8).Value = txtAllfdCUTS.Text.ToString();
            cmd.Parameters.Add("@Visual_Observe", SqlDbType.VarChar, 30).Value = txtVisualObserv.Text;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar, 100).Value = txtRemark.Text;
            cmd.Parameters.Add("@Sr_No", SqlDbType.Int).Value = lblid.Text.ToString();
            cmd.Parameters.Add("@Veg_Matters", SqlDbType.Int, 9).Value = txtVegMatter.Text;
            cmd.Parameters.Add("@DARK_COLORED_FD_MATTERS", SqlDbType.Int, 9).Value = txtDarkColoredMatter.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetails.DataSource = ds;
            //grdDetails.DataSource = ds;
            //grdDetails.DataBind();
            //cmd.ExecuteNonQuery();
            grdDetails.DataBind();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //obj.Connection();
            //Response.Write("<script>alert('record sucessfully updated');</script>");
            txtDate.Text = "";
            txtMachineNo.Text = "";
            txtCountNo.Text = "";
            txtSource.Text = "";
            txtTestedLen.Text = "";
            txtTestedWeight.Text = " ";
            txtAddFdFaults.Text = " ";
            txtAllfdCUTS.Text = " ";
            txtVisualObserv.Text = " ";
            txtRemark.Text = " ";
            txtDarkColoredMatter.Text = "";
            txtVegMatter.Text = "";

            string script = "alert('Record Successfully Updated');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }

        catch (ApplicationException exception)
        {
            //Response.Write("<script>alert('" + exception.Message + "');</script>");

            lblErrMachineNo.Message = exception.Message;

            lblErrMachineNo.Display();



        }

    }




    // THIS CODING WAS WORKING BEFORE USING THE SECOND FUNCTION 
    //private void sendmailSendMessage(string subject, string messageBody, string toAddress, string ccAddress)
    //{

    //    MailMessage message = new MailMessage();
    //    SmtpClient client = new SmtpClient();
    //    message.From = new MailAddress("aslam@jctltd.com");
    //    if (toAddress.Trim().Length > 0)
    //    {
    //        foreach (string addr in toAddress.Split(';'))
    //        {
    //            message.To.Add(new MailAddress(addr));
    //        }
    //        if (ccAddress.Trim().Length > 0)
    //        {
    //            foreach (string addr in ccAddress.Split(';'))
    //            {
    //                message.CC.Add(new MailAddress(addr));
    //            }
    //        }
    //        message.Subject = subject;
    //        message.Body = messageBody;
    //        client.Host = "exchange2007";
    //        client.Send(message);
    //    }

    //}




    protected void SendMail()
    {



        StringBuilder sb = new StringBuilder();



        //sb.AppendLine("<html>");
        //sb.AppendLine("<head>");
        //sb.AppendLine("<table>");
        //sb.AppendLine("<style type=\"text/css\">");
        //sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        //sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        //sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        //sb.AppendLine("</style>");
        //sb.AppendLine("</head>");
        //sb.AppendLine("<table class=\"gridtable\">");
        //sb.AppendLine("<tr><th> Order No</th> <th> Sort</th> <th> Weaving Sort</th> <th> Quantity</th> <th> Greigh Required</th> <th> Adjusted Qty</th>  <th> Remarks</th> </tr>");
        //sb.AppendLine("<tr> <td>   </td> <td>  </td>  <td></td>  <td></td>  <td></td>  <td></td> <td></td> <td> </td> <td> </td> <td></td> <td></td> <td>  </td> </tr> ");
        //sb.AppendLine("</table>");


        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<table>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr>       <th> Date</th>                     <th> MachineNo</th>                  <th> CountNo</th>                    <th> Source</th>                <th> Tested_Len(Km)</th>                  <th> Tested_Weight(Kg)</th>         <th> Veg Matter</th>     <th>Dark Colored Matter </th>           <th>All FdFaults/100km</th>           <th>Coloured FdCuts/100KM</th>              <th> Visual_Observe</th>            <th> Remark</th>  </tr>");
        sb.AppendLine("<tr> <td> " + txtDate.Text + " </td> <td>  " + txtMachineNo.Text + " </td>  <td> " + txtCountNo.Text + "  </td> <td>  " + txtSource.Text + " </td>  <td> " + txtTestedLen.Text + " </td> <td>  " + txtTestedWeight.Text + " </td> <td>" + txtVegMatter.Text + " </td> <td>" + txtDarkColoredMatter.Text + " </td> <td> " + txtAddFdFaults.Text + " </td> <td>" + txtAllfdCUTS.Text + "  </td>    <td> " + txtVisualObserv.Text + " </td> <td>" + txtRemark.Text + "</td>     </tr> ");
   



        string fromAddress;

        string to;
        string bcc;

        string body = sb.ToString();
        fromAddress = "noreply@jctltd.com";   //Email Address of Sender
        to = "rd@jctltd.com,kartarsingh@jctltd.com,arwinder@jctltd.com,rameshd@jctltd.com";
        bcc = "aslam@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        string subject = "classimat test result";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromAddress);
      //  mail.To.Add(new MailAddress(toAddress));

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

        // smtp settings;ii
        var smtp = new System.Net.Mail.SmtpClient();
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");


        smtp.Host = "exchange2k7";

        smtp.Send(mail);
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("classimat_test.aspx");
    }
}