using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
//using System.Web.Mail;
using System.Text;
using System.Net.Mail;
using System.Configuration;
public partial class OPS_ShortFall : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    String script;
    String mon;
    SendMail Sm = new SendMail();




    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //sql = "Select distinct order_no from jct_ops_monthly_planning where status is null and mode='Freezed'  ";
            //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            sql = "JCT_OPS_MONTHLY_FREEZED_ORDERS ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    rblSaleOrder.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
        }
    }

    //protected int yearMonth()
    //  {
    //      sql = "Select month('" + txtDateFrom.Text + "')";
    //      mon = obj1.FetchValue(sql).ToString();
    //      int mon1 = int.Parse(mon);
    //      if (mon1 < 10)
    //      {
    //          mon = "0" + mon;
    //      }
    //      sql = "Select year('" + txtDateFrom.Text + "')";
    //      String year = obj1.FetchValue(sql).ToString();
    //      String yearmonth = year + mon;
    //      int year_month = int.Parse(yearmonth);
    //      return year_month;
    //  }

    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        rblSaleOrder.Items.Clear();
        //sql = "JCT_OPS_PLANNING_SHORTFALL_SEARCH_ORDER";
        sql = "JCT_OPS_PLANNING_SHORTFALL_SEARCH_ORDER_NewPlan";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 16).Value = txtOrderNo.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                rblSaleOrder.Items.Add(dr[0].ToString());
            }
        }
        dr.Close();
        try
        {
            // FetchRecord();
        }
        catch (Exception ex)
        {

        }
      

    }

    protected void FetchRecord()
    {
        try
        {
           // ddlSortNo.Items.Clear();
            lblSortNo.Text = "";
            lblLineItem.Text = "";

            //ddlLineItem.Items.Clear();
            //sql = "JCT_OPS_Planning_Shortfall_Order_Fetch";
            sql = "JCT_OPS_Planning_Shortfall_Order_Fetch_NewPlan";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblCustomer.Text = dr[1].ToString();
                }
            }
            dr.Close();

            ////sql = "JCT_OPS_SHORTFALL_ORDERS ";
            //sql = "JCT_OPS_SHORTFALL_ORDERS_NewPlan";
            //cmd = new SqlCommand(sql, obj.Connection());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandTimeout = 0;
            //cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //GridView1.DataSource = ds;
            //GridView1.DataBind();

           // sql = "JCT_OPS_Planning_Shortfall_Order_Items";
            /*
            sql = "JCT_OPS_Planning_Shortfall_Order_Items_NEWPLAN";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 16).Value = txtOrderNo.Text;
            SqlDataReader dr1;
            //  ListItem li = new ListItem();
            dr1 = cmd.ExecuteReader();

            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    //li.Value = dr1[0].ToString();
                    //li.Text = dr1[0].ToString();
                    ddlSortNo.Items.Add(dr1[0].ToString());
                }
            }

            dr1.Close();
             
             -----------To showe all sorts of paritcualer order in Gri
             */

            //sql = "JCT_OPS_Planning_Shortfall_Order_LineItem";
            /* 
            sql = "JCT_OPS_Planning_Shortfall_Order_LineItem_NEWPLAN";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 16).Value = txtOrderNo.Text;
            SqlDataReader dr3;
            // ListItem LineItem = new ListItem();
            dr3 = cmd.ExecuteReader();

            if (dr3.HasRows)
            {
                while (dr3.Read())
                {
                    lblLineItem.Text=dr3[0].ToString();
                    //ddlLineItem.Items.Add(dr3[0].ToString());
                }
            }
            //ddlLineItem.Items[0].Selected = true;
            dr3.Close();

           // sql = "JCT_OPS_Planning_Shortfall_Order_Shade";
            sql = "JCT_OPS_Planning_Shortfall_Order_Shade_NewPlan";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@itemno", SqlDbType.VarChar, 20).Value = lblSortNo.Text;
            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value =lblLineItem.Text;
            SqlDataReader dr2;
            ListItem li2 = new ListItem();
            dr2 = cmd.ExecuteReader();

            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    lblPlanMtrs.Text = dr2[0].ToString();
                    lblShade.Text = dr2[1].ToString();
                }
            }
            dr2.Close();
             */
        }

        catch (Exception ex)
        {
            script = "alert('The order is not considered in the planning for the period defined by you. Please choose a different month or contact Planning department to resolve the issue.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void ddlSortNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "JCT_OPS_Planning_Shortfall_Order_Shade";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@ItemNo", SqlDbType.VarChar, 20).Value = lblSortNo.Text;
        cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = lblLineItem.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblPlanMtrs.Text = dr[0].ToString();
                lblShade.Text = dr[1].ToString();
            }
        }

    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        string SalesPerson_Email = string.Empty;

        if ( lblLineItem.Text !=""    )
        {


            try
            {
                // sql = " SELECT DISTINCT LOCATION FROM dbo.JCT_OPS_MONTHLY_PLANNING WHERE order_no='"+ txtOrderNo.Text +"' AND status IS NULL AND mode='Freezed' ";
                //sql = " SELECT DISTINCT LOCATION FROM dbo.JCT_OPS_PLANNING_ORDER WHERE order_no='" + txtOrderNo.Text + "' AND status ='A' ";
                sql = "SELECT  DISTINCT CASE WHEN LEFT(item_group_no, 3) IN (    'NOL', 'POL' ) THEN 'TAFFETA'   ELSE 'COTTON'  END AS Plant   FROM     miserp.SOM.dbo.m_item_mapping   WHERE    item_no = ( SELECT TOP 1      item_no  FROM    miserp.som.dbo.t_order_line_nos  WHERE   order_no = '" + txtOrderNo.Text + "'      )  AND group_type = 'SBITEM'";
                String Plant = obj1.FetchValue(sql).ToString();
                if (Plant == "COTTON")
                {
                    sql = "JCT_OPS_SHORTFALL_ORDER_REQUEST_INSERT";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
                    cmd.Parameters.Add("@order_Srl_No", SqlDbType.Int).Value = Convert.ToInt16(lblLineItem.Text);
                    cmd.Parameters.Add("@Item_No", SqlDbType.VarChar, 20).Value = lblSortNo.Text;
                    cmd.Parameters.Add("@ShortFall_Mtrs", SqlDbType.Decimal).Value = Convert.ToDecimal(txtReplanMtrs.Text);
                    cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.VarChar, 20).Value = Session["CompanyCode"];
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'P';
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
                    cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 30).Value = ddlReason.SelectedItem.Text;
                    cmd.Parameters.Add("@RequestID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Damage_At", SqlDbType.VarChar, 40).Value = ddlDamage.SelectedItem.Text;

                    cmd.ExecuteNonQuery();

                    string requestid = cmd.Parameters["@RequestID"].Value.ToString(); // cmd.Parameters("@RequestID ").Value;
                    String body = "<p>Hello ,</p> <p>ShortFall request has been generated. Please see the details below : </p><p> <H3>Request ID : " + requestid + "</H3></p><p> <H3>Customer Name : " + lblCustomer.Text + "</H3></p> </p> <H3>Order No. :" + txtOrderNo.Text + " </H3> </p> <p> <H3> Sort No. : " + lblSortNo.Text + "</H3></p> <p> <H3> Shade : " + lblShade.Text + "</H3>  </p><p><H3>Actual Greigh Quantity Planned :  " + lblPlanMtrs.Text + "</H3> </p><p> <H3>Greigh Produced : 0 </H3></p><p> <H3>Shortfall request : " + txtReplanMtrs.Text + "</H3></p><p> <H3>Reason for Shortfall : " + ddlReason.SelectedItem.Text + "</H3></p><p> <H3>Remarks : " + txtRemarks.Text + "</H3></p></br><p>This request is generated  by " + obj1.FetchValue("Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and active='Y'") + ".</p> Please contact concerned person for any other additional details.</br></br>This mail is a system generated mail and sent through OPS online mail management system. Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";

                    //String body = "<p>Hello ,</p> <p>ShortFall request has been generated. Please see the details below : </p><p> <H3>Customer Name : " + lblCustomer.Text + "</H3></p> </p> <H3>Order No. :" + txtOrderNo.Text + " </H3> </p> <p> <H3> Sort No. : " + ddlSortNo.SelectedItem.Text + "</H3>  </p><p><H3>Actual Greigh Quantity Planned :  " + lblPlanMtrs.Text + "</H3> </p><p> <H3>Greigh Produced : 0 </H3></p><p> <H3>Shortfall request : " + txtReplanMtrs.Text + "</H3></p><p> <H3>Reason for Shortfall : " + ddlReason.SelectedItem.Text + "</H3></p><p> <H3>Remarks : " + txtRemarks.Text + "</H3></p></br> Please contact concerned person for any other additional details.</br></br>This mail is a system generated mail and sent through OPS online mail management system. Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                    // String body = "test mail";

                    sql = "SELECT  Isnull(K.E_MailID,'') as [SalesPerson_Email] FROM    miserp.som.dbo.t_order_hdr x LEFT OUTER JOIN miserp.som.dbo.m_cust_mapping y ON x.ord_cust_no = y.cust_no  LEFT OUTER JOIN MISERP.som.dbo.m_cust_group z ON z.group_no = y.group_no AND z.group_type = y.group_type  LEFT OUTER JOIN miserp.som.dbo.jct_team_saleperson_mapping x1 ON x1.sale_person_code = y.group_no  LEFT OUTER JOIN dbo.MISTEL K ON K.empcode = SUBSTRING(x1.sale_person_code,  1, 1) + '-' + SUBSTRING(x1.sale_person_code,2, 7) WHERE   z.status = 'O' AND y.group_type = 'SalesP' AND x.order_no='" + txtOrderNo.Text + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        SalesPerson_Email = obj1.FetchValue(sql).ToString();
                    }
                    else
                    {
                        SalesPerson_Email = "jatindutta@jctltd.com";
                    }

                    SendMailToPlanning_Cotton(body, SalesPerson_Email);
                    ClearAll();
                    script = "alert('Request For ShortFall has been generated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }

                else if (Plant == "TAFFETA")
                {
                    sql = "JCT_OPS_SHORTFALL_ORDER_REQUEST_INSERT";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
                    cmd.Parameters.Add("@order_Srl_No", SqlDbType.Int).Value = Convert.ToInt16(lblLineItem.Text);
                    cmd.Parameters.Add("@Item_No", SqlDbType.VarChar, 20).Value = lblSortNo.Text;
                    cmd.Parameters.Add("@ShortFall_Mtrs", SqlDbType.Decimal).Value = Convert.ToDecimal(txtReplanMtrs.Text);
                    cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.VarChar, 20).Value = Session["CompanyCode"];
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'P';
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
                    cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 30).Value = ddlReason.SelectedItem.Text;
                    cmd.Parameters.Add("@RequestID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Damage_At", SqlDbType.VarChar, 40).Value = ddlDamage.SelectedItem.Text;

                    cmd.ExecuteNonQuery();

                    string requestid = cmd.Parameters["@RequestID"].Value.ToString(); // cmd.Parameters("@RequestID ").Value;
                    String body = "<p>Hello ,</p> <p>ShortFall request has been generated. Please see the details below : </p><p> <H3>Request ID : " + requestid + "</H3></p><p> <H3>Customer Name : " + lblCustomer.Text + "</H3></p> </p> <H3>Order No. :" + txtOrderNo.Text + " </H3> </p> <p> <H3> Sort No. : " + lblSortNo.Text + "</H3> </p> <p> <H3> Shade : " + lblShade.Text + "</H3>   </p><p><H3>Actual Greigh Quantity Planned :  " + lblPlanMtrs.Text + "</H3> </p><p> <H3>Greigh Produced : 0 </H3></p><p> <H3>Shortfall request : " + txtReplanMtrs.Text + "</H3></p><p> <H3>Reason for Shortfall : " + ddlReason.SelectedItem.Text + "</H3></p><p> <H3>Remarks : " + txtRemarks.Text + "</H3></p></br><p>This request is generated  by " + obj1.FetchValue("Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and active='Y'") + ".</p> Please contact concerned person for any other additional details.</br></br>This mail is a system generated mail and sent through OPS online mail management system. Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";

                    //String body = "<p>Hello ,</p> <p>ShortFall request has been generated. Please see the details below : </p><p> <H3>Customer Name : " + lblCustomer.Text + "</H3></p> </p> <H3>Order No. :" + txtOrderNo.Text + " </H3> </p> <p> <H3> Sort No. : " + ddlSortNo.SelectedItem.Text + "</H3>  </p><p><H3>Actual Greigh Quantity Planned :  " + lblPlanMtrs.Text + "</H3> </p><p> <H3>Greigh Produced : 0 </H3></p><p> <H3>Shortfall request : " + txtReplanMtrs.Text + "</H3></p><p> <H3>Reason for Shortfall : " + ddlReason.SelectedItem.Text + "</H3></p><p> <H3>Remarks : " + txtRemarks.Text + "</H3></p></br> Please contact concerned person for any other additional details.</br></br>This mail is a system generated mail and sent through OPS online mail management system. Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                    // String body = "test mail";

                    sql = "SELECT  Isnull(K.E_MailID,'') as [SalesPerson_Email] FROM    miserp.som.dbo.t_order_hdr x LEFT OUTER JOIN miserp.som.dbo.m_cust_mapping y ON x.ord_cust_no = y.cust_no  LEFT OUTER JOIN MISERP.som.dbo.m_cust_group z ON z.group_no = y.group_no AND z.group_type = y.group_type  LEFT OUTER JOIN miserp.som.dbo.jct_team_saleperson_mapping x1 ON x1.sale_person_code = y.group_no  LEFT OUTER JOIN dbo.MISTEL K ON K.empcode = SUBSTRING(x1.sale_person_code,  1, 1) + '-' + SUBSTRING(x1.sale_person_code,2, 7) WHERE   z.status = 'O' AND y.group_type = 'SalesP' AND x.order_no='" + txtOrderNo.Text + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        SalesPerson_Email = obj1.FetchValue(sql).ToString();
                    }
                    else
                    {
                        SalesPerson_Email = "jatindutta@jctltd.com";
                    }

                    SendMailToPlanning_Taffeta(body, SalesPerson_Email);
                    ClearAll();
                    script = "alert('Request For ShortFall has been generated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
            }

            catch (Exception ex)
            {
                script = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        else {

            script = "alert(' Please Select Line Number and shade ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                
        
        
        }

    }

    protected void ClearAll()
    {
        txtOrderNo.Text = "";
        lblCustomer.Text = "";
        lblSortNo.Text = "";
        lblShade.Text = "";
        lblPlanMtrs.Text = "";
        txtReplanMtrs.Text = "";
        txtRemarks.Text = "";
        ddlReason.SelectedIndex = 0;
    }

    //protected void SendMailToPlanning(String body)
    //{
    //            Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("neeraj@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("sobti@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("karanjitsaini@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("rashpal@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("harendra@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("rbaksshi@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("ashish@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("sobti@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("kvsmurty@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("nandksharma@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("rajivmehra@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("sudhirarora@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("vinaypuri@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("rkkapoor@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("mikeops@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //            Sm.SendMail("graeme@jctltd.com", "noreply@jctltd.com", "Shortfall Request Generated For Order No - " + txtOrderNo.Text, body);
    //}


    //protected void SendMailToPlanning(String Body)
    //{

    //    MailMessage mailMessage = new MailMessage();
    //    mailMessage.From = "noreply@jctltd.com";
    //    mailMessage.To = "neeraj@jctltd.com";
    //    mailMessage.To = "jatindutta@jctltd.com";
    //    mailMessage.To = "karanjitsaini@jctltd.com";
    //    mailMessage.To = "rahuljindal@jctltd.com";
    //    mailMessage.Cc = "sobti@jctltd.com";
    //    mailMessage.Cc = "rashpal@jctltd.com";
    //    mailMessage.Bcc = "jatindutta@jctltd.com";
    //    mailMessage.Bcc = "harendra@jctltd.com";
    //    mailMessage.Bcc = "rbaksshi@jctltd.com";
    //    mailMessage.BodyFormat = MailFormat.Html;
    //    mailMessage.Subject = "Request for Shortfall - " + txtOrderNo.Text;
    //    mailMessage.Body = Body;
    //    SmtpMail.SmtpServer = "exchange2007";
    //    SmtpMail.Send(mailMessage);

    //}

    private void SendMailToPlanning_Cotton(String Body, String SalesPerson_Email)
    {
        string from, to, bcc, cc, subject, body;
        from = "noreply@jctltd.com";   //Email Address of Sender
        if (SalesPerson_Email == "")
        {
            to = "neeraj@jctltd.com,sundeepw@jctltd.com, chandermohan@jctltd.com,santoshkumar@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,pkchhabra@jctltd.com,rajkumars@jctltd.com,karunarora@jctltd.com,bhola@jctltd.com,rahuljindal@jctltd.com,sukhvendersingh@jctltd.com,chandermohans@jctltd.com,bipansharma@jctltd.com,kkjha@jctltd.com,rajivmehra@jctltd.com,lakhbir@jctltd.com,rajeshsahni@jcttld.com,priteep@jctltd.com";   //Email Address of Receiver
        }
        else
        {
            to = "neeraj@jctltd.com,sundeepw@jctltd.com,chandermohan@jctltd.com,santoshkumar@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,pkchhabra@jctltd.com,rajkumars@jctltd.com,karunarora@jctltd.com,rahuljindal@jctltd.com,sukhvendersingh@jctltd.com,bipansharma@jctltd.com,chandermohans@jctltd.com,kkjha@jctltd.com,rajivmehra@jctltd.com,lakhbir@jctltd.com,rajeshsahni@jctltd.com,priteep@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
        }

    
        //to = "harendra@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
        bcc = "harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com";
        cc = "rlsharma@jctltd.com,ashokkumar2@jctltd.com,sobti@jctltd.com,rajeshkapoor@jctltd.com,rkkapoor@jctltd.com,arvindsharma@jctltd.com,nandksharma@jctltd.com";
        //bcc = "";
        //cc = "";
        subject = "Shortfall Request Generated For Order No - " + txtOrderNo.Text;

        //StringBuilder sb = new StringBuilder();
        //sb.Append("Hi,<br/>");
        //sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
        //sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
        //sb.Append("<br/>");
        //sb.Append("Thanking you<br/>");
        //sb.Append("IT");

        body = Body;

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
        //return mail;
    }

    private void SendMailToPlanning_Taffeta(String Body, String SalesPerson_Email)
    {
        string from, to, bcc, subject, body;
        string cc = string.Empty;
        SalesPerson_Email = "";
        //if (SalesPerson_Email == "")
        //{
        //    to = "harendra@jctltd.com,jatindutta@jctltd.com,harshsoni@jctltd.com,jaswal@jctltd.com";   //Email Address of Receiver
        //}
        //else
        //{
        //    to = "harendra@jctltd.com,jatindutta@jctltd.com,harshsoni@jctltd.com,jaswal@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
        //}
        from = "noreply@jctltd.com";   //Email Address of Sender
        ////to = "harendra@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
        ////to = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,"+ SalesPerson_Email;   //Email Address of Receiver
        ////bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com";
        ////cc = "sobti@jctltd.com,rkkapoor@jctltd.com,mikeops@jctltd.com,graeme@jctltd.com";
        //to = "harendra@jctltd.com,jatindutta@jctltd.com,harshsoni@jctltd.com,jaswal@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
        //bcc = "harendra@jctltd.com,hitesh@jctltd.com,jatindutta@jctltd.com";
        //cc = "ashish@jctltd.com,hitesh@jctltd.com,rajan@jctltd.com,harshsoni@jctltd.com,jatindutta@jctltd.com";
        //bcc = "";
        //cc = "";

        if (SalesPerson_Email == "")
        {
            to = "trivendermehta@jctltd.com,umeshrana@jctltd.com,nandi@jctltd.com,chandwani@jctltd.com,ramanbehal@jctltd.com,husanlal@jctltd.com,ramjiban@jctltd.com,chandermohans@jctltd.com";   //Email Address of Receiver
        }
        else
        {
            to = "trivendermehta@jctltd.com,umeshrana@jctltd.com,nandi@jctltd.com,chandwani@jctltd.com,ramanbehal@jctltd.com,husanlal@jctltd.com,ramjiban@jctltd.com,chandermohans@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
        }


        //to = "harendra@jctltd.com," + SalesPerson_Email;   //Email Address of Receiver
        bcc = "manishk@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com";
        //cc = "mikeops@jctltd.com";
        subject = "Shortfall Request Generated For Order No - " + txtOrderNo.Text;

        //StringBuilder sb = new StringBuilder();
        //sb.Append("Hi,<br/>");
        //sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
        //sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
        //sb.Append("<br/>");
        //sb.Append("Thanking you<br/>");
        //sb.Append("IT");

        body = Body;

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
        //return mail;
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/ShortFall.aspx");
    }
    protected void rblSaleOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtOrderNo.Text = rblSaleOrder.SelectedItem.Text;
        FetchRecord();
        bindGrid();
    }

    /* Commented by manish  July 08 2015
    protected void ddlLineItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "JCT_OPS_Planning_Shortfall_Order_Shade";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@itemno", SqlDbType.VarChar, 20).Value = ddlSortNo.SelectedItem.Text;
        cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = ddlLineItem.SelectedItem.Text;
        SqlDataReader dr2;
        ListItem li2 = new ListItem();
        dr2 = cmd.ExecuteReader();

        if (dr2.HasRows)
        {
            while (dr2.Read())
            {
                lblPlanMtrs.Text = dr2[0].ToString();
                lblShade.Text = dr2[1].ToString();
            }
        }
        dr2.Close();
    }
    */
    protected void lnkAllRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShortfallStatus.aspx");
        //if (txtDateFrom.Text == "" || txtDateTo.Text == "")
        //{
        //    script = "alert('Please Select Date for which request has been generated..!!');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //}
        //else
        //{
        //    sql = "JCT_OPS_GET_SHORTFALL_REQUESTS";
        //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@DATEFROM", txtDateFrom.Text);
        //    cmd.Parameters.AddWithValue("@DATETO", txtDateTo.Text);
        //    cmd.Parameters.AddWithValue("@Plant", txtDateTo.Text);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    GridView1.DataSource = ds;
        //    GridView1.DataBind();
        //}


    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
             lblSortNo.Text= grdDetail.SelectedRow.Cells[1].Text;
             lblLineItem.Text = grdDetail.SelectedRow.Cells[2].Text;
             lblShade.Text = grdDetail.SelectedRow.Cells[3].Text;
             //lblPlanMtrs.Text = grdDetail.SelectedRow.Cells[4].Text;
             sql = "JCT_OPS_Planning_Shortfall_Order_Shade";
             SqlCommand cmd = new SqlCommand(sql, obj.Connection());
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
             cmd.Parameters.Add("@ItemNo", SqlDbType.VarChar, 20).Value = lblSortNo.Text;
             cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = lblLineItem.Text;
             SqlDataReader dr = cmd.ExecuteReader();
             if (dr.HasRows)
             {
                 while (dr.Read())
                 {
                     lblPlanMtrs.Text = dr[0].ToString();
                     //lblShade.Text = dr[1].ToString();
                 }
             }
          
    }

    private void bindGrid()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["productionConnectionString1"].ConnectionString);
        
        if ((con.State == System.Data.ConnectionState.Closed))
        {
            con.Open();
        }
        string sql = "jct_Get_PO_Detail";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("order_no", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count != 0) 
        {
            grdDetail.DataSource = ds;
            grdDetail.DataBind();
        }
      con.Close();

    }


    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetail.PageIndex = e.NewPageIndex;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["productionConnectionString1"].ConnectionString);

        if ((con.State == System.Data.ConnectionState.Closed))
        {
            con.Open();
        }
        string sql = "jct_Get_PO_Detail";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("order_no", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count != 0)
        {
            grdDetail.DataSource = ds;
            grdDetail.DataBind();
        }
        con.Close();


    }
    
}