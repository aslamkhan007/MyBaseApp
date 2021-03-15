﻿using System;
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

            try
            {
                SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@enteredBy", SqlDbType.VarChar, 10).Value = Session["empcode"];
                cmd.Parameters.Add("@product_type", SqlDbType.VarChar, 20).Value = "fabric";
                cmd.Parameters.Add("@qty_req ", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtqtyreq.Text == "" ? 0 : Convert.ToDecimal(txtqtyreq.Text));//Convert.ToDecimal(txtqtyreq.Text);
                cmd.Parameters.Add("@delivery_remarks", SqlDbType.VarChar, 100).Value = txtdeli.Text;
                cmd.Parameters.Add("@delivery_dt", SqlDbType.DateTime).Value = txtdelivdt.Text == "" ? null : txtdelivdt.Text;
                cmd.Parameters.Add("@parallel_sort", SqlDbType.VarChar, 10).Value = txtsort.Text;
                cmd.Parameters.Add("@finish_fab_cust_name", SqlDbType.VarChar, 20).Value = txtcust.Text;
                cmd.Parameters.Add("@ref_mkt_exec", SqlDbType.VarChar, 30).Value = txtmkt.Text;
                cmd.Parameters.Add("@enduse", SqlDbType.VarChar, 100).Value = txtspecial.Text;
                cmd.Parameters.Add("@purchase", SqlDbType.Decimal, 2).Value = (txtpurchase.Text == "" ? Convert.ToDecimal(txtqtyreq.Text) : Convert.ToDecimal(txtpurchase.Text));
                cmd.Parameters.Add("@sale_order ", SqlDbType.VarChar, 20).Value = txtso.Text;
                cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 500).Value = txtremark.Text;
                cmd.Parameters.Add("@number", SqlDbType.VarChar, 5).Value = txtnum.Text;

            cmd.Parameters.Add("@category", SqlDbType.VarChar, 10).Value = "non Wardrobe";

            if (rdlst.SelectedIndex==0)
            {
                cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value =rdlst.SelectedItem.Value;
            }
            if (rdlst.SelectedIndex == 1)
            {
                cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            }

            if (rdlst.SelectedIndex ==2)
            {
                cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            }

            cmd.Parameters.Add("@pack_detail", SqlDbType.VarChar, 10).Value = ddlpack.Text;
            cmd.Parameters.Add("@Freight_chrgs", SqlDbType.VarChar, 10).Value = ddlfreight.Text;
            cmd.Parameters.Add("@paymnt_deliv_term", SqlDbType.VarChar, 100).Value = txtpayment.Text;
            cmd.Parameters.Add("@finish_sale_price", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtfinishsale.Text == "" ? 0 : Convert.ToDecimal(txtfinishsale.Text));
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState["RequestID"];
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
        if (rdlst.SelectedIndex==2) 
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
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select", con);
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
        if (rdlst.SelectedIndex == 1)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select", con);
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
        if (rdlst.SelectedIndex == 2)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select", con);
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
        cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select ", con);


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
            //txtends.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", ""); ;
            //txtpicks.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", ""); ;
            //txtwarp.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", ""); ;
            //txtweft.Text = grdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", ""); ;
            //txtwidth.Text = grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", ""); ;
            //txtwgt.Text = grdDetail.SelectedRow.Cells[15].Text.Replace("&nbsp;", ""); ;
            //txtblend.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", ""); ;
            //txtsize.Text = grdDetail.SelectedRow.Cells[16].Text.Replace("&nbsp;", ""); ;
            //txtweave.Text = grdDetail.SelectedRow.Cells[12].Text.Replace("&nbsp;", ""); ;
            //txtweaveon.Text = grdDetail.SelectedRow.Cells[13].Text.Replace("&nbsp;", ""); ;
            //txtpiece.Text = grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", ""); ;
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
            lnksave.Enabled = false;

            lnksave.Enabled = false;
        }
        if (rdlst.SelectedIndex == 1)
        {
            lbid.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txtqtyreq.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            //txtends.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", ""); ;
            //txtpicks.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", ""); ;
            //txtwarp.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", ""); ;
            //txtweft.Text = grdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", ""); ;
            //txtwidth.Text = grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", ""); ;
            //txtwgt.Text = grdDetail.SelectedRow.Cells[15].Text.Replace("&nbsp;", ""); ;
            //txtblend.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", ""); ;
            //txtsize.Text = grdDetail.SelectedRow.Cells[16].Text.Replace("&nbsp;", ""); ;
            //txtweave.Text = grdDetail.SelectedRow.Cells[12].Text.Replace("&nbsp;", ""); ;
            //txtweaveon.Text = grdDetail.SelectedRow.Cells[13].Text.Replace("&nbsp;", ""); ;
            //txtpiece.Text = grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", ""); ;
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
            lnksave.Enabled = false;

        }

    }
    protected void LinkButton3_Click(object sender, EventArgs e)  //update 
    {
        if (txtqtyreq.Text == ""  || txtmkt.Text == "")
        {
            string script = "alert(' please select the data to be updated!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }


        try
        {
            
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@enteredBy", SqlDbType.VarChar, 10).Value = Session["empcode"];
            cmd.Parameters.Add("@product_type", SqlDbType.VarChar, 20).Value = "fabric";

            cmd.Parameters.Add("@qty_req ", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtqtyreq.Text == "" ? 0 : Convert.ToDecimal(txtqtyreq.Text));//Convert.ToDecimal(txtqtyreq.Text);
            //cmd.Parameters.Add("@ends_inch", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtends.Text == "" ? 0 : Convert.ToDecimal(txtends.Text));//Convert.ToDecimal(txtends.Text);
            //cmd.Parameters.Add("@picks_inch", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtpicks.Text == "" ? 0 : Convert.ToDecimal(txtpicks.Text));//Convert.ToDecimal(txtpicks.Text);
            //cmd.Parameters.Add("@warp_count", SqlDbType.VarChar, 10).Value = txtwarp.Text;
            //cmd.Parameters.Add("@weft_count", SqlDbType.VarChar, 10).Value = txtweft.Text;
            //cmd.Parameters.Add("@width_inch", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtwidth.Text == "" ? 0 : Convert.ToDecimal(txtwidth.Text));//Convert.ToDecimal(txtwidth.Text);
            //cmd.Parameters.Add("@blend", SqlDbType.VarChar, 20).Value = txtblend.Text;
            //cmd.Parameters.Add("@weave", SqlDbType.VarChar, 20).Value = txtweave.Text;
            //cmd.Parameters.Add("@weave_on", SqlDbType.VarChar, 20).Value = txtweaveon.Text;
            //cmd.Parameters.Add("@piece_length", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtpiece.Text == "" ? 0 : Convert.ToDecimal(txtpiece.Text));//Convert.ToDecimal(txtpiece.Text);
            //cmd.Parameters.Add("@weight_gsm", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtwgt.Text == "" ? 0 : Convert.ToDecimal(txtwgt.Text));//Convert.ToDecimal(txtwgt.Text);
            //cmd.Parameters.Add("@size_percnt", SqlDbType.VarChar, 5).Value = txtsize.Text;
            cmd.Parameters.Add("@delivery_remarks", SqlDbType.VarChar, 100).Value = txtdeli.Text;
            cmd.Parameters.Add("@delivery_dt", SqlDbType.DateTime).Value = txtdelivdt.Text == "" ? null : txtdelivdt.Text;
            cmd.Parameters.Add("@parallel_sort", SqlDbType.VarChar, 5).Value = txtsort.Text;
            cmd.Parameters.Add("@finish_fab_cust_name", SqlDbType.VarChar, 20).Value = txtcust.Text;
            cmd.Parameters.Add("@ref_mkt_exec", SqlDbType.VarChar, 30).Value = txtmkt.Text;
            cmd.Parameters.Add("@enduse", SqlDbType.VarChar, 100).Value = txtspecial.Text;
            cmd.Parameters.Add("@purchase", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtpurchase.Text == "" ? 0 : Convert.ToDecimal(txtpurchase.Text));//Convert.ToDecimal(txtpurchase.Text);
            cmd.Parameters.Add("@sale_order ", SqlDbType.VarChar, 20).Value = txtso.Text;
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Value = txtremark.Text;
            cmd.Parameters.Add("@number", SqlDbType.VarChar, 5).Value = txtnum.Text;
            cmd.Parameters.Add("@category", SqlDbType.VarChar, 10).Value = " non Wardrobe";

           if (rdlst.SelectedIndex == 0)
            {
                cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value =rdlst.SelectedItem.Value;
            }
            if (rdlst.SelectedIndex == 1)
            {
                cmd.Parameters.Add("@purchaseBy", SqlDbType.VarChar, 30).Value = rdlst.SelectedItem.Value;
            }
            cmd.Parameters.Add("@pack_detail", SqlDbType.VarChar, 10).Value = ddlpack.Text;
            cmd.Parameters.Add("@Freight_chrgs", SqlDbType.VarChar, 10).Value = ddlfreight.Text;
            cmd.Parameters.Add("@paymnt_deliv_term", SqlDbType.VarChar, 100).Value = txtpayment.Text;
            cmd.Parameters.Add("@finish_sale_price", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtfinishsale.Text == "" ? 0 : Convert.ToDecimal(txtfinishsale.Text));
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar,10).Value = ddlplant.Text;
            cmd.Parameters.Add("@fbType", SqlDbType.VarChar, 10).Value = txtfbtype.Text;


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
   
          
         
            string script = "alert(' record updated sucesfully.!! ');";
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
    //private void SendMail()
    //{
    //    string @from = null;
    //    string to = null;
    //    string bcc = null;
    //    string cc = null;
    //    string subject = null;
    //    string body = null;
 
    //    sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
    //    SqlCommand cmd = new SqlCommand(sql, con);
    //    con.Open();
    //    SqlDataReader Dr = cmd.ExecuteReader();
    //    if (Dr.HasRows)
    //    {
    //        while (Dr.Read())
    //        {
    //            ViewState["RequestBy"] = Dr["empname"].ToString();
    //            ViewState["RequestByEmail"] = Dr["email"].ToString();
    //        }
    //    }
    //    else
    //    {
    //        ViewState["RequestBy"] = "";
    //        ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
    //    }

    //    Dr.Close();
    //    con.Close();

    //    StringBuilder sb = new StringBuilder();

    //    sb.AppendLine("<html>");
    //    sb.AppendLine("<head>");
    //    sb.AppendLine("<style type=\"text/css\">");
    //    sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
    //    sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
    //    sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
    //    sb.AppendLine("</style>");
    //    sb.AppendLine("</head>");

    //    sb.AppendLine("Hi,<br/>");
    //    sb.AppendLine("Outsourced Fabric Request has been generated in OPS by : " + ViewState["RequestBy"] + "<br/><br/>");

    //    sb.AppendLine("RequestID for your request is : " + ViewState["RequestID"] + " <br/><br/>");
    //    sb.AppendLine("Request is Pending at R&D for approval.<br/><br/>");

    //    //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
    //    sb.AppendLine("Details are Shown below : <br/><br/>");
    //    sb.AppendLine("<table class=gridtable>");

    //    sql = "jct_ops_outsrd_dyed_fab_mail_content";
    //    cmd = new SqlCommand(sql, con);
    //    con.Open();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState["RequestID"];
    //    Dr = cmd.ExecuteReader();
    //    if ((Dr.HasRows))
    //    {
    //        while ((Dr.Read()))
    //        {

    //            sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
    //            sb.AppendLine("<tr><td colspan='4'> R & D DEPT</td></tr> ");
    //            sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED DYED FABRIC</td> </tr>");
    //            sb.AppendLine("<tr><td colspan='4'> CONSTRUCTION</td> </tr>");
         

    //            sb.AppendLine("<tr><td colspan='2'> QUANTITY REQUIRED</td> <td colspan='2'>" + Dr["QuantityRequired"].ToString() + "</td></tr>");
    //            sb.AppendLine("<tr><td colspan='2'> Sort No</td> <td colspan='2'>" + Dr["SortNo"].ToString() + "</td></tr>");
    //            sb.AppendLine("<tr><td colspan='2'>  FINISH FABRIC CUST NAME</td> <td colspan='2'>" + Dr["CustName"].ToString() + "</td></tr>");
    //            sb.AppendLine("<tr><td colspan='2'>  REFERENCE MKT EXEC</td> <td colspan='2'>" + Dr["MarkExec"].ToString() + "</td></tr>");
    //            sb.AppendLine("<tr><td colspan='2'>  DELIVERYDATE</td> <td colspan='2'>" + Dr["DeliveryDate"].ToString() + "</td></tr>");
    //            sb.AppendLine("<tr><td colspan='2'> PAYMENTTERMS</td> <td colspan='2'>" + Dr["PaymentTerms"].ToString() + "</td></tr>");
    //            sb.AppendLine("<tr><td colspan='2'> ENDUSE</td> <td colspan='2'>" + Dr["enduse"].ToString() + "</td></tr>");

    //            sb.AppendLine("<tr><td colspan='2'> PURCHASE QTY</td> <td colspan='2'>" + Dr["Purchase"].ToString() + "</td></tr>");
    //            sb.AppendLine("<tr><td colspan='2'>FINISH SALE PRICE</td><td colspan='2'>" + Dr["FinishSalePrice"].ToString() + "</td></tr>");
    //            sb.AppendLine("<tr><td colspan='2'>DELIVERY REMARKS</td><td colspan='2'>" + Dr["Delivery Remarks"].ToString() + "</td></tr>");
    //        }
    //    }

    //    Dr.Close();
    //    con.Close();
    //    sb.AppendLine("</table>");

    //    sb.AppendLine("<br /><br/>");

    //    sb.AppendLine("Please fill the specifications against this Request.<br/> <br/>");

    //    sb.Append("<a href='http://misdev/FusionApps/OPS/outsourced_fab_specs.aspx'> Click here to fill specifications..!! </a><br />");

    //    sb.AppendLine("</table><br />");

    //    sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
    //    sb.AppendLine("Thank you<br />");
    //    sb.AppendLine("</html>");


    //    body = sb.ToString();
    //    @from = "Outsourcing@jctltd.com";
    //    //to = "shwetaloria@jctltd.com";//"sandeepjalota@jctltd.com"

    //    if (ddlplant.SelectedItem.Text == "Cotton")
    //    {
    //        to = "sandeepjalota@jctltd.com,skpalta@jctltd.com,rajgopal@jctltd.com,arvindsharma@jctltd.com,kartarsingh@jctltd.com,karanjitsaini@jctltd.com" + "," + ViewState["RequestByEmail"].ToString();
    //    }
    //    if (ddlplant.SelectedItem.Text == "Taffeta")
    //    {
    //        to = "sanjeevj@jctltd.com,sandeepjalota@jctltd.com,vinaydogra@jctltd.com,arvindsharma@jctltd.com,kartarsingh@jctltd.com,karanjitsaini@jctltd.com" + "," + ViewState["RequestByEmail"].ToString();
    //    }

    //    //to = "sandeepjalota@jctltd.com"+ "," + ViewState["RequestByEmail"].ToString();

    //    //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
    //    bcc = "shwetaloria@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com,rajan@jctltd.com";
    //    subject = "Outsourced Fabric Request - " + ViewState["RequestID"];
    //    MailMessage mail = new MailMessage();
    //    mail.From = new MailAddress(@from);
    //    if (to.Contains(","))
    //    {
    //        string[] tos = to.Split(',');
    //        for (int i = 0; i <= tos.Length - 1; i++)
    //        {
    //            mail.To.Add(new MailAddress(tos[i]));
    //        }
    //    }
    //    else
    //    {
    //        mail.To.Add(new MailAddress(to));
    //    }

    //    if (!string.IsNullOrEmpty(bcc))
    //    {
    //        if (bcc.Contains(","))
    //        {
    //            string[] bccs = bcc.Split(',');
    //            for (int i = 0; i <= bccs.Length - 1; i++)
    //            {
    //                mail.Bcc.Add(new MailAddress(bccs[i]));
    //            }
    //        }
    //        else
    //        {
    //            mail.Bcc.Add(new MailAddress(bcc));
    //        }
    //    }
    //    //If Not String.IsNullOrEmpty(cc) Then
    //    //    If cc.Contains(",") Then
    //    //        Dim ccs As String() = cc.Split(","c)
    //    //        For i As Integer = 0 To ccs.Length - 1
    //    //            mail.CC.Add(New MailAddress(ccs(i)))
    //    //        Next
    //    //    Else
    //    //        mail.CC.Add(New MailAddress(bcc))
    //    //    End If
    //    //    mail.CC.Add(New MailAddress(cc))
    //    //End If

    //    mail.Subject = subject;
    //    mail.Body = body;
    //    mail.IsBodyHtml = true;
    //    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //    SmtpClient SmtpMail = new SmtpClient("exchange2007");

    //    //SmtpMail.SmtpServer = "exchange2007";
    //    SmtpMail.Send(mail);
    //    //return mail;
    //}

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

        if (ddlplant.SelectedItem.Text == "Cotton")
        {
            to = ViewState["RequestByEmail"].ToString() + ",dpbadhwar@jctltd.com,skpalta@jctltd.com,rajgopal@jctltd.com,sanjeevj@jctltd.com,laxman@jctltd.com";
        }
        if (ddlplant.SelectedItem.Text == "Taffeta")
        {
            to = ViewState["RequestByEmail"].ToString()+",dpbadhwar@jctltd.com,sanjeevj@jctltd.com,laxman@jctltd.com";
        }

        //to = ViewState["PendingAtEmail"].ToString() + "," + ViewState["RequestByEmail"].ToString();
        //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";

        bcc = "shwetaloria@jctltd.com,rbaksshi@jctltd.com,rajan@jctltd.com";
        subject = "Outsourced Fabric Request - " + ViewState["RequestID"];
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
        SmtpClient SmtpMail = new SmtpClient("exchange2007");

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
            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select ", con);
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

        if(rdlst.SelectedIndex==1)
        {

            lbfinshprice.Visible = false;
            txtfinishsale.Visible = false;
            lbpurchase.Visible = false;
            txtpurchase.Visible = false;
            chkpur.Visible = false;

            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select", con);
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

        if (rdlst.SelectedIndex == 2)
        {

            lbprchse.Visible = true;
            txtpurchase.Visible = true;
            lbfinshprice.Visible = false;
            txtfinishsale.Visible = false;
            chkpur.Visible = false;

            SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select ", con);
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

        if (rdlst.SelectedIndex == 3)
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
}




   