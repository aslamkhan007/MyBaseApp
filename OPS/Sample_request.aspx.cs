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

public partial class OPS_Sample_request : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    string qry;
    Functions ObjFun = new Functions();
    Connection obj = new Connection();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(LEFT(group_no,1)+'-'+RIGHT(group_no,LEN(group_no)-1)),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group, dbo.JCT_EmpMast_Base  WHERE group_TYPE='SALESP' AND status ='o' AND group_no=REPLACE(empcode,'-','') AND Active='Y' ORDER BY group_desc";
                ObjFun.FillList(DdlSalePerson, qry);
            }
        }
    

    protected void lnkgen_Click(object sender, EventArgs e)
    {
        {
            string st2 = txtsort.Text.Split('~')[1].ToString();
            string EnqNo1 = txtsort.Text.Split('~')[2].ToString();
            string devno = txtsort.Text.Split('~')[3].ToString();
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
            //string SanctionID;
            //   qry = "SELECT TOP 1 Num FROM JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL";

            //   SanctionID = ObjFun.FetchValue(qry).ToString();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("jct_ops_detail_sample_insert", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sanctionid", SqlDbType.Int).Value = "678";//SanctionID;
                cmd.Parameters.Add("@sampleorder", SqlDbType.VarChar, 10).Value = txtsample.Text;
                cmd.Parameters.Add("@sortno", SqlDbType.VarChar, 10).Value = st2;
                cmd.Parameters.Add("@proposed_DNV", SqlDbType.VarChar, 10).Value = txtDNV.Text;
                cmd.Parameters.Add("@selling_price", SqlDbType.VarChar, 10).Value = txtsellinprice.Text;
                cmd.Parameters.Add("@customer", SqlDbType.VarChar, 10).Value = txtcustomer.Text;
                cmd.Parameters.Add("@paidByClient ", SqlDbType.Char, 1).Value = ddlclient.Text;
                cmd.Parameters.Add("@salesPerson", SqlDbType.VarChar, 10).Value = DdlSalePerson.Text;
                cmd.Parameters.Add("@ReqdMeter ", SqlDbType.SmallInt).Value = txtReqMtrs.Text;
                cmd.Parameters.Add("@no_of_shades ", SqlDbType.TinyInt).Value = txt_No_of_shades.Text;
                cmd.Parameters.Add("@finish ", SqlDbType.VarChar, 10).Value = ddlFinish.Text;
                cmd.Parameters.Add("@enquiry ", SqlDbType.Int).Value = EnqNo1;
                cmd.Parameters.Add("@development_no", SqlDbType.Int).Value = devno;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Jct_Ops_SanctionNote_Insert_HDR_SampleRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                cmd.Parameters.Add("@areacode", SqlDbType.Int).Value = "9099";
                cmd.Parameters.Add("@subject", SqlDbType.VarChar, 50).Value = txtsubject.Text;
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = txtdescptn.Text;
                cmd.Parameters.Add("@HostIP", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 10).Value = "777";
                cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ddlplant.Text;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Jct_Ops_SanctionNote_InsertDynamic_User_Sample", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SanctionNote", SqlDbType.VarChar, 10).Value = "777";
                cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                cmd.Parameters.Add("@areacode", SqlDbType.Int).Value = "9099";
                cmd.Parameters.Add("@startID", SqlDbType.Int).Value = "0";
                cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ddlplant.Text;
               
                cmd.ExecuteNonQuery();
                con.Close();
                sendmail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} exception caught.", ex);
            }
        }
    }
    protected void lnkclr_Click(object sender, EventArgs e)
    {
        txt_No_of_shades.Text = "";
        txtcustomer.Text = "";
        txtdescptn.Text = "";
        txtDNV.Text = "";
        txtReqMtrs.Text = "";
        txtsample.Text = "";
        txtsellinprice.Text = "";
        txtsort.Text = "";
        txtsubject.Text = "";
        ddlclient.Text = "";
        ddlFinish.Text = "";
        ddlplant.Text = "";
        DdlSalePerson.Text = "";
        ddlAOD.Text = "";
        
    }


    protected void lnksrch_Click(object sender, EventArgs e)
    {
    }
    protected void CmdSearch_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp ;password=power");
        string st = txtsort.Text.Split('~')[1].ToString();
        string EnqNo =txtsort.Text.Split('~')[2].ToString();
       
        SqlCommand cmd = new SqlCommand("jct_ops_get_fabric_param",con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@sort", SqlDbType.Int).Value = st;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        ds.Clear();
        SqlCommand cmd2 = new SqlCommand("jct_ops_get_count_detail", con);
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.Parameters.Add("@sort", SqlDbType.Int).Value = st;
        cmd2.Parameters.Add("@enq", SqlDbType.Int).Value = EnqNo;
        SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        grdDetail2.DataSource = ds1.Tables[0];
        grdDetail2.DataBind();
    }
    protected void lnksearch_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp ;password=power");
        string st = txtsort.Text.Split('~')[1].ToString();
        SqlCommand cmd3 = new SqlCommand("jct_sample_test2", con);
        cmd3.CommandType = CommandType.StoredProcedure;
        cmd3.Parameters.Add("item_no", SqlDbType.VarChar,10).Value = st;
        cmd3.Parameters.Add("@order_no", SqlDbType.VarChar, 30).Value = txtsample.Text;
        SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        grdDetail3.DataSource = ds2.Tables[0];
        grdDetail3.DataBind();
    }

    private void sendmail()
    {   
        //string sql;
        string st2 = txtsort.Text.Split('~')[1].ToString();
   
        string EnqNo1 = txtsort.Text.Split('~')[2].ToString();
        string devno = txtsort.Text.Split('~')[3].ToString();
        string from,to, subject, body;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");
     
        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Sample detail of sort no : " + st2 + "<br/><br/>");
        sb.AppendLine("Details are Shown below : <br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th>SanctionID</th> <th>Sampleorder</th> <th>Sortno</th> <th> ProposedDNV</th> <th> SellingPrice</th>  <th> Customer</th>  <th>PaidByClient</th> <th>SalesPerson</th> <th> ReqMeter</th> <th> No.Of.Shades</th><th> Finish</th> <th>Enquiry</th> <th>Development.No</th><th>Subject</th><th>description</th><th>Plant</th>    </tr> ");
       // sql = "select count_1 as[Count], convert(varchar,date, 101) as [Date],source as [Source],length as[Length],weight as[Weight],allfaultperkg as[AllFaultPerkg ] ,majorshotthick as [MajorShotThick],shortshotthick as [ShortShotThick ],longshotthick as [LongShotThick],Thinfault as [Thinfault],majorthinfault as [MajorThinFault],remarks as [Remarks] from jct_ops_classimat  WHERE ID =" + lbid.Text + "";
       // SqlCommand cmd = new SqlCommand(sql, con);
       // con.Open();
       // SqlDataReader dr = cmd.ExecuteReader();
       // dr.Read();
       
       //if (dr.HasRows)       
       // {
           
       //     while (dr.Read())
       //     {
        sb.AppendLine("<tr> <td>  " + 777 + " </td> <td>  " + txtsample.Text + " </td>  <td> " + st2 + "</td>  <td> " + txtDNV.Text + "</td>  <td> " + txtsellinprice.Text + "</td>  <td>" + txtcustomer.Text + "</td> <td>" + ddlclient.Text + "</td> <td>" + DdlSalePerson.Text + " </td> <td> " + txtReqMtrs.Text + " </td> <td>" + txt_No_of_shades.Text + " </td> <td>" + ddlFinish.Text + "</td> <td>" + txtsort.Text + "</td> <td> " + devno + " </td> <td> "+ txtsubject.Text+" </td> <td> " + txtdescptn.Text + " </td> <td> " +ddlplant.Text + " </td> </tr> ");

        //    }
        //}
        sb.AppendLine("</table>");
        sb.AppendLine("<br />");
       
        //dr.Close();
        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");
        body = sb.ToString();
        from = "noreply@jctltd.com";   //Email Address of Sender
        to = "shwetaloria@jctltd.com";
        subject = "Sample detail";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
        mail.To.Add(new MailAddress(to));

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;
    }

    
}








