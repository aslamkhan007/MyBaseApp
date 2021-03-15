using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mail;

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

            sql = "Select distinct order_no from jct_ops_monthly_planning where   status is null and mode='Freezed'  ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
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

    protected int yearMonth()
    {
        sql = "Select month('" + txtDateFrom.Text + "')";
        mon = obj1.FetchValue(sql).ToString();
        int mon1 = int.Parse(mon);
        if (mon1 < 10)
        {
            mon = "0" + mon;
        }
        sql = "Select year('" + txtDateFrom.Text + "')";
        String year = obj1.FetchValue(sql).ToString();
        String yearmonth = year + mon;
        int year_month = int.Parse(yearmonth);
        return year_month;
    }

    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        rblSaleOrder.Items.Clear();
        sql = "Select distinct order_no from jct_ops_monthly_planning where yearmonth="+ yearMonth() +" and  status is null and mode='Freezed'  and order_no like @OrderNo  ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.AddWithValue("@OrderNo",txtOrderNo.Text +"%");
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
            FetchRecord();
        }
        catch (Exception ex)
        { 
        
        }
       
    }

    protected void FetchRecord()
    {
        try
        {
            ddlSortNo.Items.Clear();
            ddlLineItem.Items.Clear();
            sql = "SELECT DISTINCT a.order_no , " +
             "c.cust_name " +
             "FROM    dbo.JCT_OPS_MONTHLY_PLANNING a " +
             "INNER JOIN miserp.som.dbo.t_order_hdr b ON a.order_no = b.order_no " +
             "INNER JOIN miserp.som.dbo.m_customer c ON c.cust_no = b.ord_cust_no " +
             "WHERE a.yearmonth=" + yearMonth() + " and    a.status IS NULL " +
             " AND a.order_no=@orderno";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
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

            sql = "JCT_OPS_SHORTFALL_ORDERS ";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();



            sql = "Select distinct item_no from JCT_OPS_MONTHLY_PLANNING where yearmonth=" + yearMonth() + " and  order_no = @orderno and status is null";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
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
            ddlSortNo.Items[0].Selected = true;
            dr1.Close();
            sql = "Select distinct order_srl_no from JCT_OPS_MONTHLY_PLANNING where yearmonth=" + yearMonth() + " and  order_no = @orderno and mode='Freezed' and status is null order by order_srl_no";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            SqlDataReader dr3;
           // ListItem LineItem = new ListItem();
            dr3 = cmd.ExecuteReader();

            if (dr3.HasRows)
            {
                while (dr3.Read())
                {
                    
                    ddlLineItem.Items.Add(dr3[0].ToString());
                }
            }
            ddlLineItem.Items[0].Selected = true;
            dr3.Close();

            sql = "Select distinct plan_qty from JCT_OPS_MONTHLY_PLANNING where yearmonth=" + yearMonth() + " and  order_no = @orderno and item_no=@itemno and order_srl_no=@LineItem and mode='Freezed' and status is null";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@itemno", SqlDbType.VarChar, 20).Value = ddlSortNo.SelectedItem.Text;
            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value =ddlLineItem.SelectedItem.Text;
            SqlDataReader dr2;
            ListItem li2 = new ListItem();
            dr2 = cmd.ExecuteReader();

            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    lblPlanMtrs.Text = dr2[0].ToString();
                }
            }
            dr2.Close();
        }

        catch (Exception ex)
        {

        }

    }

    protected void ddlSortNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "SELECT distinct Plan_Qty  FROM dbo.JCT_OPS_MONTHLY_PLANNING WHERE yearmonth=" + yearMonth() + " and  order_no=@OrderNo AND item_no=@ItemNo and mode='Freezed' and status is null";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@ItemNo", SqlDbType.VarChar, 20).Value = ddlSortNo.SelectedItem.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblPlanMtrs.Text = dr[0].ToString();
            }
        }

    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        try
        {
        sql = "JCT_OPS_SHORTFALL_ORDER_REQUEST_INSERT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@order_Srl_No", SqlDbType.VarChar, 20).Value = ddlLineItem.SelectedItem.Text;
        cmd.Parameters.Add("@Item_No", SqlDbType.VarChar, 20).Value = ddlSortNo.SelectedItem.Text;
        cmd.Parameters.Add("@ShortFall_Mtrs", SqlDbType.Float).Value = txtReplanMtrs.Text;
        cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
        cmd.Parameters.Add("@CompanyCode", SqlDbType.VarChar, 20).Value = Session["CompanyCode"];
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'P';
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
        cmd.Parameters.Add("@yearmonth", SqlDbType.Decimal).Value = yearMonth();
        cmd.ExecuteNonQuery();
        String body = "<p>Hello ,</p> <p>ShortFall request has been generated. Please see the details below : </p><p> <H3>Customer Name : " + lblCustomer.Text + "</H3></p> </p> <H3>Order No. :" + txtOrderNo.Text + " </H3> </p> <p> <H3> Sort No. : " + ddlSortNo.SelectedItem.Text + "</H3>  </p><p><H3>Actual Greigh Quantity Planned :  " + lblPlanMtrs.Text + "</H3> </p><p> <H3>Greigh Produced : 0 </H3></p><p> <H3>Shortfall request : " + txtReplanMtrs.Text + "</H3></p><p> <H3>Reason for Shortfall : " + ddlReason.SelectedItem.Text + "</H3></p></br><p>This request is generated  by " + obj1.FetchValue("Select empname from jct_empmast_base where empcode='"+ Session["EmpCode"] +"' and active='Y'") + ".</p> Please contact concerned person for any other additional details.</br></br>This mail is a system generated mail and sent through OPS online mail management system. Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
        SendMailToPlanning(body);
        script = "alert('Request For ShortFall has been generated successfully.');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
      
        
    }

    //protected void SendMailToPlanning(String body)
    //{
        
    //    SqlDataReader dr = obj1.FetchReader(sql);
    //    if (dr.HasRows)
    //    {
    //        while (dr.Read())
    //        {
    //            sql = "Select isnull(E_MailID,'') as email from mistel where empcode='"+ Session["EmpCode"].ToString() +"'";
    //            string mail = obj1.FetchValue(sql).ToString();
    //            //String email = dr[2].ToString();
    //          //  String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>ShortFall request has been generated. Please see the details below : </p><p> <H3>Customer Name : " + dr[8].ToString() + "</H3></p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3>Actual Greigh Quantity Planned :  " + dr[7].ToString() + "</H3> </p><p> <H3>Greigh Produced : " + dr[8].ToString() + "</H3></p><p> <H3>Shortfall request : " + dr[8].ToString() + "</H3></p><p> <H3>Reason for Shortfall : " + dr[8].ToString() + "</H3></p></br><p>This request is generated  by "+ dr[8].ToString() +". Please contact him for any other additional details.</br></br>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
    //               Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Request for Shortfall" , body);
    //               Sm.SendMail("neeraj@jctltd.com", "noreply@jctltd.com", "Request for Shortfall", body);
    //               Sm.SendMail("sobti@jctltd.com", "noreply@jctltd.com", "Request for Shortfall", body);
    //               Sm.SendMail(mail, "noreply@jctltd.com", "Request for Shortfall", body);
    //               Sm.SendMail(mail, "noreply@jctltd.com", "Request for Shortfall", body);
    //        }
    //    }
    //    dr.Close();
    //}


    protected void SendMailToPlanning(String Body)
    {
     
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = "noreply@jctltd.com";
        mailMessage.To = "neeraj@jctltd.com";
        mailMessage.Cc = "sobti@jctltd.com";
        mailMessage.Cc="rashpal@jctltd.com";
        mailMessage.Bcc = "jatindutta@jctltd.com";
        mailMessage.Bcc = "harendra@jctltd.com";
        mailMessage.Bcc = "rbaksshi@jctltd.com";
        mailMessage.BodyFormat = MailFormat.Html;
        mailMessage.Subject = "Request for Shortfall - " + txtOrderNo.Text;
        mailMessage.Body = Body;
        SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mailMessage);

    }
    


    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/ShortFall.aspx");
    }
    protected void rblSaleOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtOrderNo.Text = rblSaleOrder.SelectedItem.Text;
        FetchRecord();
    }
    protected void ddlLineItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "Select distinct plan_qty from JCT_OPS_MONTHLY_PLANNING where yearmonth=" + yearMonth() + " and  order_no = @orderno and item_no=@itemno and mode='Freezed' and order_srl_no=@LineItem and status is null";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
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
            }
        }
        dr2.Close();
    }
    protected void lnkAllRequests_Click(object sender, EventArgs e)
    {
        sql = "JCT_COURIER_GET_SHORYFALL_REQUESTS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATEFROM", txtDateFrom.Text);
        cmd.Parameters.AddWithValue("@DATETO", txtDateTo.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
}