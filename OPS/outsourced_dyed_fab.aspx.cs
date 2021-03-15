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

public partial class OPS_outsourced_dyed_fab : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
   
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            rdlst_SelectedIndexChanged(sender, e);
            Panel2.Visible = true;
            ModalPopUp_PageLoad.Show();
        }
    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {
 
    }


    private void funinsert()
    {


        if (txtqtyreq.Text == "" || txtmkt.Text == "" || ddlgrp.SelectedItem.Text == "")
            {
                string script = "alert(' Error Occured!  some data may be missing.. please fill!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
        if (Convert.ToDecimal(txtDnv.Text) >  Convert.ToDecimal(txtfinishsale.Text))
        {
            string script = "alert(' Finish Sale Price Cannot be less than the DNV Cost!!!! Please Check ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }
            try
            {
                SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_insert_modified", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@enteredBy", SqlDbType.VarChar, 10).Value = Session["empcode"];
                cmd.Parameters.Add("@product_type", SqlDbType.VarChar, 20).Value = "fabric";
                cmd.Parameters.Add("@qty_req ", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtqtyreq.Text == "" ? 0 : Convert.ToDecimal(txtqtyreq.Text));//Convert.ToDecimal(txtqtyreq.Text);
                cmd.Parameters.Add("@delivery_remarks", SqlDbType.VarChar, 100).Value = txtdeli.Text;
                cmd.Parameters.Add("@delivery_dt", SqlDbType.DateTime).Value = txtdelivdt.Text == "" ? null : txtdelivdt.Text;
                cmd.Parameters.Add("@parallel_sort", SqlDbType.VarChar, 20).Value = txtsort.Text;
                cmd.Parameters.Add("@finish_fab_cust_name", SqlDbType.VarChar, 200).Value = txtcust.Text;
                cmd.Parameters.Add("@ref_mkt_exec", SqlDbType.VarChar, 30).Value = txtmkt.Text.Split('~')[0].ToString();
                cmd.Parameters.Add("@ref_mkt_code", SqlDbType.VarChar, 30).Value = txtmkt.Text.Split('~')[1].ToString(); 
                cmd.Parameters.Add("@enduse", SqlDbType.VarChar, 100).Value = txtspecial.Text;
                cmd.Parameters.Add("@purchase", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtpurchase.Text == "" ? 0 : Convert.ToDecimal(txtpurchase.Text));
                cmd.Parameters.Add("@sale_order ", SqlDbType.VarChar, 20).Value = txtso.Text;
                cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 500).Value = txtremark.Text;
                cmd.Parameters.Add("@number", SqlDbType.VarChar, 5).Value = txtnum.Text;
                cmd.Parameters.Add("@costing_memo ", SqlDbType.VarChar, 50).Value = txtcostmemo.Text;
                cmd.Parameters.Add("@memo_date", SqlDbType.DateTime, 50).Value = txtmemodate.Text == "" ? null : txtmemodate.Text;
                cmd.Parameters.Add("@DNV_cost ", SqlDbType.VarChar, 50).Value = txtDnv.Text;
                cmd.Parameters.Add("@Std_remarks", SqlDbType.VarChar, 50).Value = txtStdRemarks.Text;
                //cmd.Parameters.Add("@finish_sale_price", SqlDbType.VarChar, 50).Value = txtfinishsale.Text;
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 10).Value = "non Wardrobe";
                cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState["RequestID"];

            if (rdlst.SelectedIndex==0)
            {
                cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value =rdlst.SelectedItem.Value;
            }
            //if (rdlst.SelectedIndex == 1)
            //{
            //    cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            //}

            //if (rdlst.SelectedIndex ==2)
            //{
            //    cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            //}

            cmd.Parameters.Add("@pack_detail", SqlDbType.VarChar, 10).Value = ddlpack.Text;
            cmd.Parameters.Add("@Freight_chrgs", SqlDbType.VarChar, 10).Value = ddlfreight.Text;
            cmd.Parameters.Add("@paymnt_deliv_term", SqlDbType.VarChar, 100).Value = txtpayment.Text;
            cmd.Parameters.Add("@finish_sale_price", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtfinishsale.Text == "" ? 0 : Convert.ToDecimal(txtfinishsale.Text));
           
            cmd.Parameters.Add("@plant", SqlDbType.VarChar,20).Value = ddlplant.Text;
            cmd.Parameters.Add("@fbtype", SqlDbType.VarChar, 20).Value = txtfbtype.Text;
            cmd.Parameters.Add("@groupname", SqlDbType.VarChar, 100).Value = ddlgrp.SelectedItem.Text;


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lbid.Text = ViewState["RequestID"].ToString();
            lbid.Visible = true;
           

      
            string script = "alert(' record saved sucesfully.!!  please press clear button!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //lnkapply.Visible = true;
            lnksave.Enabled = false;
            //ViewState.Remove("RequestID");
            SendMail();
             
        }
        catch (Exception ex1)
        {
            throw ex1;
        }
    }

    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        // wardrobe
        if (rdlst.SelectedIndex==1) 
        {

            Response.Redirect("outsourced_Wardrobe.aspx");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e) //clear
    {
        Response.Redirect("outsourced_dyed_fab.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)  //save 
    {
        GenerateCode();
        funinsert();
        
        if (rdlst.SelectedIndex == 0)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select_modified", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        }
        //if (rdlst.SelectedIndex == 1)
        //{
        //    //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        //    SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select", con);
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    grdDetail.DataSource = ds.Tables[0];
        //    grdDetail.DataBind();
           

        //}
        //if (rdlst.SelectedIndex == 2)
        //{
        //    //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        //    SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select", con);
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    grdDetail.DataSource = ds.Tables[0];
        //    grdDetail.DataBind();
           
        //}


    }

    protected void LinkButton2_Click(object sender, EventArgs e) //del
    {

        if (txtqtyreq.Text == "" || txtmkt.Text == "" || txtcust.Text=="" )
        {
            string script = "alert(' please select the data to be deleted!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

              
        SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@deletedBy", SqlDbType.VarChar, 10).Value = Session["empcode"];
        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        
        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select_modified", con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 20).Value = rdlst.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        //Response.Redirect("outsourced_dyed_fab.aspx");

        string script2 = "alert(' record deleted sucesfully.!!! please press clear to add new record !! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        

    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)   //select 
    {
        if (rdlst.SelectedIndex == 0)
        {

            lbid.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txtqtyreq.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
       
            txtdeli.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", ""); ;
            txtdelivdt.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", ""); ;
            txtsort.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", ""); ;
            txtspecial.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", ""); ;
            txtcust.Text = grdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", ""); ;
            txtmkt.Text = grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", ""); ;
            txtso.Text = grdDetail.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            txtpurchase.Text = grdDetail.SelectedRow.Cells[20].Text.Replace("&nbsp;", ""); ;
            //txtfinishsale.Text=grdDetail.SelectedRow.Cells[].Text;
            ddlfreight.Text = grdDetail.SelectedRow.Cells[18].Text.Replace("&nbsp;", ""); ;
            ddlpack.Text = grdDetail.SelectedRow.Cells[17].Text.Replace("&nbsp;", ""); ;
            //ddlprod.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""); ;
            txtremark.Text = grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", ""); ;
            txtfinishsale.Text = grdDetail.SelectedRow.Cells[21].Text.Replace("&nbsp;", ""); ;
            txtpayment.Text = grdDetail.SelectedRow.Cells[19].Text.Replace("&nbsp;", ""); ;
            txtnum.Text = grdDetail.SelectedRow.Cells[23].Text.Replace("&nbsp;", ""); ;
            txtfbtype.Text = grdDetail.SelectedRow.Cells[22].Text.Replace("&nbsp;", ""); ;
            txtDnv.Text = grdDetail.SelectedRow.Cells[26].Text.Replace("&nbsp;", ""); ;
            txtcostmemo.Text = grdDetail.SelectedRow.Cells[25].Text.Replace("&nbsp;", ""); ;
            lnksave.Enabled = false;

            lnksave.Enabled = false;
        }
      
        }

    
    protected void LinkButton3_Click(object sender, EventArgs e)  //update 
    {
        if (txtqtyreq.Text == ""  || txtmkt.Text == "")
        {
            string script = "alert('Please select the data to be updated!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        try
        {
            //SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_update_modified", con);
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_update_modified", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@enteredBy", SqlDbType.VarChar, 10).Value = Session["empcode"];
            cmd.Parameters.Add("@product_type", SqlDbType.VarChar, 20).Value = "fabric";
            cmd.Parameters.Add("@qty_req ", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtqtyreq.Text == "" ? 0 : Convert.ToDecimal(txtqtyreq.Text));//Convert.ToDecimal(txtqtyreq.Text);
            cmd.Parameters.Add("@delivery_remarks", SqlDbType.VarChar, 100).Value = txtdeli.Text;
            cmd.Parameters.Add("@delivery_dt", SqlDbType.DateTime).Value = txtdelivdt.Text == "" ? null : txtdelivdt.Text;
            cmd.Parameters.Add("@parallel_sort", SqlDbType.VarChar, 20).Value = txtsort.Text.Trim();
            cmd.Parameters.Add("@finish_fab_cust_name", SqlDbType.VarChar, 200).Value = txtcust.Text.Trim();
            cmd.Parameters.Add("@ref_mkt_exec", SqlDbType.VarChar, 30).Value = txtmkt.Text.Split('~')[0].ToString().Trim();
            cmd.Parameters.Add("@ref_mkt_code", SqlDbType.VarChar, 30).Value = txtmkt.Text.Split('~')[1].ToString().Trim(); 
            cmd.Parameters.Add("@enduse", SqlDbType.VarChar, 100).Value = txtspecial.Text;
            cmd.Parameters.Add("@purchase", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtpurchase.Text == "" ? 0 : Convert.ToDecimal(txtpurchase.Text));
            cmd.Parameters.Add("@sale_order ", SqlDbType.VarChar, 20).Value = txtso.Text.Trim();
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 500).Value = txtremark.Text.Trim();
            cmd.Parameters.Add("@number", SqlDbType.VarChar, 5).Value = txtnum.Text.Trim();
            cmd.Parameters.Add("@category", SqlDbType.VarChar, 10).Value = "non Wardrobe";
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[1].Text.Trim();
            if (rdlst.SelectedIndex == 0)
            {
                cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            }
            //cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            cmd.Parameters.Add("@pack_detail", SqlDbType.VarChar, 10).Value = ddlpack.Text.Trim();
            cmd.Parameters.Add("@Freight_chrgs", SqlDbType.VarChar, 10).Value = ddlfreight.Text.Trim();
            cmd.Parameters.Add("@paymnt_deliv_term", SqlDbType.VarChar, 100).Value = txtpayment.Text.Trim();
            cmd.Parameters.Add("@finish_sale_price", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtfinishsale.Text == "" ? 0 : Convert.ToDecimal(txtfinishsale.Text));
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = ddlplant.Text.Trim();
            cmd.Parameters.Add("@fbtype", SqlDbType.VarChar, 20).Value = txtfbtype.Text.Trim();
            cmd.Parameters.Add("@groupname", SqlDbType.VarChar, 100).Value = ddlgrp.SelectedItem.Text;
            cmd.Parameters.Add("@costing_memo ", SqlDbType.VarChar, 50).Value = txtcostmemo.Text.Trim();
            cmd.Parameters.Add("@memo_date", SqlDbType.DateTime).Value = txtmemodate.Text == "" ? null : txtmemodate.Text;
            cmd.Parameters.Add("@DNV_cost ", SqlDbType.VarChar, 50).Value = txtDnv.Text.Trim();
            cmd.Parameters.Add("@Std_remarks", SqlDbType.VarChar, 50).Value = txtStdRemarks.Text.Trim();

            //string s = "";
            //s = "exec jct_ops_outsrd_dyed_fab_update_modified '" + Session["empcode"] + "','fabric', '" + txtqtyreq.Text + "','" + txtdeli.Text + "','" + txtdelivdt.Text + "','" + txtsort.Text + "','" + txtcust.Text + "','" + txtmkt.Text.Split('~')[0].ToString() + "','" + txtmkt.Text.Split('~')[1].ToString() + "','" + txtspecial.Text + "','" + txtpurchase.Text + "','" + txtso.Text + "','" + txtremark.Text + "','non Wardrobe','" + grdDetail.SelectedRow.Cells[1].Text + "','" + rdlst.SelectedItem.Value + "','" + ddlpack.Text + "','" + ddlfreight.Text + "','" + txtpayment.Text + "','" + txtfinishsale.Text + " ','" + ddlplant.Text + "','" + txtfbtype.Text + "','" + ddlgrp.SelectedItem.Text + "'";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string script = "alert('Record updated successfully.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lnkupd.Enabled = false;

            cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void GenerateCode()
    {
        #region Serial No. Code


        con.Open();
        sql = " SELECT max(RequestID) as RequestID FROM jct_ops_outsrd_dyed_fab ";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (string.IsNullOrEmpty(dr["RequestID"].ToString()))
                {
                    ViewState["RequestID"] = 9000000;
                }
                else
                {
                    ViewState["RequestID"] = int.Parse(dr["RequestID"].ToString()) + 1;
                }
            }
        }

        dr.Close();
        con.Close();

        #endregion
    }
    

    private void SendMail()
    {
        string @from = null;
        string to = null;
        string bcc = null;
        string cc = null;
        string subject = null;
        string body = null;

        //con.Open();
        //sql = "SELECT b.EMPCODE,c.empname,d.E_MailID AS Email FROM jct_ops_outsrd_dyed_fab a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON CONVERT(VARCHAR,a.RequestID) = b.ID AND a.pending_at=CONVERT(VARCHAR,b.USERLEVEL) INNER JOIN dbo.JCT_EmpMast_Base c ON c.empcode=b.EMPCODE LEFT OUTER JOIN dbo.MISTEL d on d.empcode=b.EMPCODE where CONVERT(VARCHAR,a.RequestID) =" + ViewState["RequestID"] + "";
        //SqlCommand cmd = new SqlCommand(sql, con);
        //SqlDataReader Dr = cmd.ExecuteReader();
        //if (Dr.HasRows)
        //{
        //    while (Dr.Read())
        //    {
        //        ViewState["PendingAtName"] = Dr["empname"].ToString();
        //        ViewState["PendingAtEmpCode"] = Dr["empcode"].ToString();
        //        ViewState["PendingAtEmail"] = Dr["Email"].ToString();
        //    }
        //}
        //Dr.Close();

        sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                ViewState["RequestBy"] = Dr["empname"].ToString();
                ViewState["RequestByEmail"] = Dr["email"].ToString();
            }
        }
        else
        {
            ViewState["RequestBy"] = "";
            ViewState["RequestByEmail"] = "jatindutta@jctltd.com";
        }

        Dr.Close();
        con.Close();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");

        sb.AppendLine("Hi,<br/>");
        sb.AppendLine("Outsourced Fabric Request has been generated in OPS by : " + ViewState["RequestBy"] + "<br/><br/>");

        sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
        //sb.AppendLine("Request is Pending at R&D Dept <br/><br/>");

        //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
        sb.AppendLine("Details are Shown below : <br/><br/>");
        sb.AppendLine("<table class=gridtable>");

        sql = "jct_ops_outsrd_dyed_fab_mail_content";
        cmd = new SqlCommand(sql, con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState["RequestID"];
        Dr = cmd.ExecuteReader();
        if ((Dr.HasRows))
        {
            while ((Dr.Read()))
            {
                sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
                sb.AppendLine("<tr><td colspan='4'> R & D DEPT</td></tr> ");
                sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED DYED FABRIC</td> </tr>");
                sb.AppendLine("<tr><td colspan='4'> CONSTRUCTION</td> </tr>");
                sb.AppendLine("<tr><td colspan='2'> QUANTITY REQUIRED</td> <td colspan='2'>" + Dr["QuantityRequired"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'>  FINISH FABRIC CUST NAME</td> <td colspan='2'>" + Dr["CustName"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'>  REFERENCE MKT EXEC</td> <td colspan='2'>" + Dr["MarkExec"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'>  DELIVERYDATE</td> <td colspan='2'>" + Dr["DeliveryDate"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> PAYMENTTERMS</td> <td colspan='2'>" + Dr["PaymentTerms"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> ENDUSE</td> <td colspan='2'>" + Dr["enduse"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> ParallelSort</td> <td colspan='2'>" + Dr["ParallelSort"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'> PURCHASE QTY</td> <td colspan='2'>" + Dr["Purchase"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'>FINISH SALE PRICE</td><td colspan='2'>" + Dr["FinishSalePrice"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'>DELIVERY REMARKS</td><td colspan='2'>" + Dr["Delivery Remarks"].ToString() + "</td></tr>");
                sb.AppendLine("<tr><td colspan='2'>DNV Cost</td><td colspan='2'>" + Dr["DNV Cost"].ToString() + "</td></tr>");
            }
        }

        Dr.Close();
        con.Close();
        sb.AppendLine("</table>");

        sb.AppendLine("<br /><br/>");

        //sb.AppendLine("Please fill the specifications against this Request.<br/> <br/>");

        //sb.Append("<a href='http://misdev/FusionApps/OPS/outsourced_fab_specs.aspx'> Click here to fill specifications..!! </a><br />");

        sb.AppendLine("</table><br />");

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        @from = "Outsourcing@jctltd.com";

        //if (ddlplant.SelectedItem.Text == "Cotton")
        //{
        //    to = ViewState["RequestByEmail"].ToString() + ",dpbadhwar@jctltd.com,skpalta@jctltd.com,rajgopal@jctltd.com,sanjeevj@jctltd.com,laxman@jctltd.com";
        //}
        //if (ddlplant.SelectedItem.Text == "Taffeta")
        //{
        //    to = ViewState["RequestByEmail"].ToString()+",dpbadhwar@jctltd.com,sanjeevj@jctltd.com,laxman@jctltd.com";
        //}

       // to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString()+ " ";
        to = ViewState["RequestByEmail"].ToString() + ",skpalta@jctltd.com,rajgopal@jctltd.com,sobti@jctltd.com";
        //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";

        bcc = "shwetaloria@jctltd.com,rbaksshi@jctltd.com,rajan@jctltd.com";
        subject = "Outsourced Fabric Request - " + ViewState["RequestID"];
        MailMessage mail = new MailMessage();
        //to = "shwetaloria@jctltd.com,ashish@jctltd.com";
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
        //If Not String.IsNullOrEmpty(cc) Then
        //    If cc.Contains(",") Then
        //        Dim ccs As String() = cc.Split(","c)
        //        For i As Integer = 0 To ccs.Length - 1
        //            mail.CC.Add(New MailAddress(ccs(i)))
        //        Next
        //    Else
        //        mail.CC.Add(New MailAddress(bcc))
        //    End If
        //    mail.CC.Add(New MailAddress(cc))
        //End If

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;
    }

    protected void rdlst_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rdlst.SelectedIndex == 0)
        {
            lbfinshprice.Visible = true;
            lbprchse.Visible = false;
            txtpurchase.Visible = false;
            txtfinishsale.Visible = true;
            chkpur.Visible = false;
  
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select_modified", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        }

        //if(rdlst.SelectedIndex==1)
        //{
        //    lbfinshprice.Visible = true;
        //    lbprchse.Visible = false;
        //    txtpurchase.Visible = false;
        //    txtfinishsale.Visible = true;
        //    chkpur.Visible = false;

        //    SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select", con);
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    grdDetail.DataSource = ds.Tables[0];
        //    grdDetail.DataBind();

        //}

        //if (rdlst.SelectedIndex == 2)
        //{

        //    lbprchse.Visible = true;
        //    txtpurchase.Visible = true;
        //    lbfinshprice.Visible = false;
        //    txtfinishsale.Visible = false;
        //    chkpur.Visible = false;

        //    SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select ", con);
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@purchaseby", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    grdDetail.DataSource = ds.Tables[0];
        //    grdDetail.DataBind();

        //}

        if (rdlst.SelectedIndex == 1)
        {
            Response.Redirect("outsourced_wardrobe.aspx");
        }


    }

    protected void lnkfreez_Click(object sender, EventArgs e)
    {

        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_freeze ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        cmd.Parameters.Add("@freezeby", SqlDbType.VarChar, 20).Value = Session["empcode"];

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert(' record freezed sucesfully.!! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);


    }

    protected void cmdSearch_Click(object sender, EventArgs e)
    {
    //       //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
    //      SqlCommand cmd = new SqlCommand ("SELECT empcode,empname+'~'+b.DEPTNAME FROM JCT_EmpMast_Base a,DEPTMAST b WHERE empname LIKE '%" + txtEmployee.Text + "%' AND Active='y' AND a.deptcode=b.DEPTCODE ORDER BY empname",con);
    //     cmd.CommandType = CommandType.Text;

    //      SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //    ChkEmpList.DataSource=ds.Tables[0];
    //    ChkEmpList.DataBind();

    }
    protected void btnTransfer_Click(object sender, EventArgs e)//level
    {
    //    ListItem  litem ;
        
    //    for(int i=0; i <=ChkEmpList.Items.Count-1;i++)
    //    { 
    //        if(ChkEmpList.Items[i].Selected==true)
    //        {
        
    //        litem= new ListItem(ChkEmpList.Items[i].Text,ChkEmpList.Items[i].Value);
    //            ChkDynamicListing.Items.Add(litem);
    //        }
    //    }
        
  
    //    //For i As Int16 = 0 To ChkEmpList1.Items.Count - 1;
    //    //    If ChkEmpList.Items(i).Selected = True Then
    //    //        litem = New ListItem(ChkEmpList.Items(i).Text, ChkEmpList.Items(i).Value)
    //    //        ChkDynamicListing.Items.Add(litem)
    //    //    End If
    //    //Next
    }
    protected void cmdCC_Click(object sender, EventArgs e)//notify
    {
    //     ListItem  litem ;

    //      for(int i=0; i <=ChkEmpList.Items.Count-1;i++)
    //      {
    //          if(ChkEmpList.Items[i].Selected==true)
    //          {
                          
    //        litem= new ListItem(ChkEmpList.Items[i].Text,ChkEmpList.Items[i].Value);
    //               chkNotify.Items.Add(litem);

    //          }


    //      }



    //    // Dim litem As ListItem
    //    //For i As Int16 = 0 To ChkEmpList.Items.Count - 1
    //    //    If ChkEmpList.Items(i).Selected = True Then
    //    //        litem = New ListItem(ChkEmpList.Items(i).Text, ChkEmpList.Items(i).Value)
    //    //        chkNotify.Items.Add(litem)
    //    //    End If
    }
    protected void imgRemoveItem_Click(object sender, EventArgs e)
    {
    //                int i= 0;
    //                int CountItems = ChkDynamicListing.Items.Count;
    //                for (i = 0; i==CountItems-1; i++)
    //                {
    //                    if (CountItems > 0)
    //                    {
    //                        if (ChkDynamicListing.Items[1].Selected == true)
    //                        {
    //                            ChkDynamicListing.Items.RemoveAt(i);
    //                            CountItems -= 1;
                 
    //                        }

                      
    //                    }
    //                }
    //  CountItems = 0;
    //  CountItems = chkNotify.Items.Count;
    //  for (i = 0; i == CountItems - 1; i++)
    //  {
    //      if (CountItems > 0)
    //      {
    //          if (chkNotify.Items[i].Selected  == true)
    //          {
    //              chkNotify.Items.RemoveAt(i);
    //              CountItems -= 1;
             

    //          }


    //      }
    //  }


   

    }
   
    protected void lnkbutton_Click(object sender, EventArgs e)
    {
        if (rblType.SelectedIndex == 0)
        {
            ModalPopUp_PageLoad.Hide();
            ////Response.Redirect("outsourced_dyed_fab.aspx");
            //ViewState["Type"] = rblType.SelectedItem.Text;
               

        }
        if(rblType.SelectedIndex == 1)
        {
            Response.Redirect("outsourced_yarn.aspx");

        }
        if (rblType.SelectedIndex ==2)
        {
            //Response.Redirect("outsourced_job_work_req.aspx");
            Response.Redirect("jobwork_commn_req.aspx");

        }
    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdlst.SelectedIndex == 1)
        {
            Response.Redirect("outsoured_Yarn.aspx");
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (chkpur.Checked == true)
        {
            txtpurchase.Text = txtqtyreq.Text;
            txtpurchase.Enabled = false;
        }
       
    }
    protected void LinkButton3_Click1(object sender, EventArgs e)
    {


                SqlCommand cmd = new SqlCommand(" SELECT paymnt_deliv_term,fbtype,delivery_dt,parallel_sort,sale_order,number,finish_fab_cust_name,ref_mkt_exec,GroupName,Freight_chrgs,pack_detail,EndUse FROM jct_ops_outsrd_dyed_fab WHERE RequestID= '" + txtrequestid.Text + "'",con );
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {       
      txtpayment.Text=dr[0].ToString();
       txtfbtype.Text=dr[1].ToString();
      txtdelivdt.Text=dr[2].ToString();
    txtsort.Text =dr[3].ToString();
     txtso.Text=dr[4].ToString();
    txtnum.Text=dr[5].ToString();
       txtcust.Text=dr[6].ToString();
      txtmkt.Text=dr[7].ToString();
                      ddlgrp.SelectedItem.Text= dr[8].ToString();
                    ddlfreight.SelectedItem.Text= dr[9].ToString();
                    ddlpack.SelectedItem.Text=dr[10].ToString();
       txtspecial.Text=dr[11].ToString();
    
     


      //  txtcostmemo.Text=dr[0].ToString();
      // txtmemodate.Text =dr[0].ToString();
  
      //txtStdRemarks.Text=dr[0].ToString();
      //txtfinishsale.Text=dr[0].ToString();
    
                    

                
                dr.Close();
                con.Close();
    }
}
















}




   