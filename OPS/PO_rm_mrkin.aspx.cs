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
public partial class OPS_PO_rm_mrkin : System.Web.UI.Page
{

    //SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["test"].ConnectionString);

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("select deptcode from jct_empmast_base where empcode=@empcode", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = Session["Empcode"];
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string code = dr[0].ToString();
            dr.Close();
            //if (code.ToUpper() == "SAL")
            //{
            //rdlst.Items[2].Enabled = true;
            //rdlst.Items[0].Enabled = false;
            //rdlst.Items[1].Enabled = false;
            lnksave.Visible = true;
            lnkclr.Visible = true;
            lnkaccept.Visible = false;
            lnkreject.Visible = false;


            // }
            //else if (code.ToUpper() == "MIS")
            //{
            //    //rdlst.Items[2].Enabled = true;
            // rdlst.Items[0].Enabled = true;
            //rdlst.Items[1].Enabled = true;

            // }



            RadioButtonList1_SelectedIndexChanged(sender, e);

        }
    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        if (rdlst.SelectedIndex == 2)
        {

            //SendMail();

        }



    }

    protected void lnkclr_Click(object sender, EventArgs e)
    {
        Response.Redirect("PO_rm_mrkin.aspx");
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        //if (rdlst.SelectedIndex == 0)
        //{
        //    foreach (GridViewRow rw in grdDetail3.Rows)
        //    {
        //        if (rw.RowType == DataControlRowType.DataRow)
        //        {
        //            CheckBox chk1 = (CheckBox)rw.FindControl("chk");
        //            TextBox txt = (TextBox)rw.FindControl("purchase");
        //            TextBox txt2 = (TextBox)rw.FindControl("saleprice");
        //            TextBox txt3 = (TextBox)rw.FindControl("txtpo");
        //            if (chk1.Checked == true)
        //            {
        //                SqlCommand cmd = new SqlCommand("jct_ops_po_raw_mat_insert", con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                con.Open();
        //                cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = rw.Cells[4].Text;
        //                cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 10).Value = Session["Empcode"].ToString();
        //                cmd.Parameters.Add("@purchase_mts", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txt.Text);
        //                cmd.Parameters.Add("@sale_price", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txt2.Text);
        //                //cmd.Parameters.Add("@ip_host", SqlDbType.VarChar, 20).Value = Request.ServerVariables["REMOTE_ADDR"];

        //                cmd.ExecuteNonQuery();
        //                con.Close();

        //                string script = "alert(' record saved sucesfully.!! ');";
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //            }
        //        }
        //    }
            //foreach (GridViewRow rm in grdDetail2.Rows)
            //{

            //    if (rm.RowType == DataControlRowType.DataRow)
            //    {

            //        CheckBox chk2 = (CheckBox)rm.FindControl("CheckBox1");
            //        TextBox txt4 = (TextBox)rm.FindControl("txtsale");
            //        TextBox txt5 = (TextBox)rm.FindControl("txtrate");

            //        TextBox txt6 = (TextBox)rm.FindControl("txtsupplr");
            //        if (chk2.Checked)
            //        {
            //            SqlCommand cmd = new SqlCommand("jct_ops_pending_rate_wardrode_insert", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            con.Open();

            //            cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = rm.Cells[5].Text;
            //            cmd.Parameters.Add("@sale_per_mts", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txt4.Text);
            //            cmd.Parameters.Add("@supplier", SqlDbType.VarChar, 100).Value = txt6.Text;
            //            cmd.Parameters.Add("@rateper_mts", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txt5.Text);
 
            //            cmd.ExecuteNonQuery();
            //            con.Close();
            //        }
            //        string script = "alert(' record saved sucesfully.!! ');";
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //    }
            //}
    //}



        if (rdlst.SelectedIndex == 0)
        {
            foreach (GridViewRow rw in grdDetail3.Rows)
            {
                CheckBox chk1 = (CheckBox)rw.FindControl("chk");
                TextBox txt = (TextBox)rw.FindControl("purchase");
                TextBox txt2 = (TextBox)rw.FindControl("saleprice");
                TextBox txt3 = (TextBox)rw.FindControl("txtpo");
                if (chk1.Checked)
                {

                    txt3.Enabled = true;

                    SqlCommand cmd1 = new SqlCommand("jct_ops_outsrced_po_no ", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd1.Parameters.Add("@requestid", SqlDbType.Int).Value = rw.Cells[4].Text;
                    cmd1.Parameters.Add("@po_addedby", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                    cmd1.Parameters.Add("@po_no", SqlDbType.VarChar, 30).Value = txt3.Text;
                    cmd1.Parameters.Add("@purchase_mts", SqlDbType.VarChar, 30).Value = txt.Text;
                        cmd1.Parameters.Add("@sale_price ", SqlDbType.VarChar, 30).Value = txt2.Text;
            
                    
    

                    cmd1.ExecuteNonQuery();
                    con.Close();
                    string script = "alert(' record saved sucesfully.!! ');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         
                    //SendMail();
                    SqlCommand cmd = new SqlCommand("jct_ops_outsrced_select_for_po_gen ", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    grdDetail3.DataSource = ds.Tables[0];
                    grdDetail3.DataBind();
                }
            }
            foreach (GridViewRow rm in grdDetail2.Rows)
            {



                CheckBox chk2 = (CheckBox)rm.FindControl("CheckBox1");
                TextBox txt4 = (TextBox)rm.FindControl("txtsale");
                TextBox txt5 = (TextBox)rm.FindControl("txtrate");
                TextBox txt6 = (TextBox)rm.FindControl("txtsupplr");
                TextBox txt7 = (TextBox)rm.FindControl("txtwdrbPO");
                if (chk2.Checked)
                {
                    txt7.Enabled = true;
                    SqlCommand cmd1 = new SqlCommand("jct_ops_wardrobe_po_no ", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd1.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = rm.Cells[5].Text;
                    cmd1.Parameters.Add("@po_creatdby", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                    cmd1.Parameters.Add("@po_no", SqlDbType.VarChar, 30).Value = txt7.Text;
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    string script = "alert(' record saved sucesfully.!! ');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    //SendMail2();
                    SqlCommand cmd = new SqlCommand("jct_ops_wdrb_select_for_po_gen ", con);
                    //cmd = new SqlCommand("Exec jct_ops_pending_rate_wardrode '" + Session["EmpCode"].ToString() + "'", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    grdDetail2.DataSource = ds.Tables[0];
                    grdDetail2.DataBind();

                }
            }

        }
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        ////SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        //SqlCommand cmd = new SqlCommand("jct_ops_outsrd_dyed_fab_select_raw_search ", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //con.Open();

        //cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = txtreqid.Text;
        //cmd.Parameters.Add("@date_from", SqlDbType.DateTime).Value = (txtdtfrom.Text == "" ? "01/01/2010" : (txtdtfrom.Text));
        //cmd.Parameters.Add("@date_to", SqlDbType.DateTime).Value = (txtdateto.Text == "" ? "01/01/2030" : (txtdateto.Text));

        //cmd.ExecuteNonQuery();
        //con.Close();

        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //grdDetail.DataSource = ds.Tables[0];
        //grdDetail.DataBind();
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdlst.SelectedIndex == 1)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
            //SqlCommand cmd = new SqlCommand("Exec jct_ops_outsrd_dyed_fab_select_raw '" + Session["EmpCode"].ToString() + "'", con);

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //grdDetail3.DataSource = ds.Tables[0];
            //grdDetail3.DataBind();



            //cmd = new SqlCommand("Exec jct_ops_pending_rate_wardrode '" + Session["EmpCode"].ToString() + "'", con);
            //SqlCommand cmd = new SqlCommand("Exec jct_ops_pending_rate_wardrode", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //grdDetail2.DataSource = ds.Tables[0];
            //grdDetail2.DataBind();
 
        }
        if (rdlst.SelectedIndex == 0)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_outsrced_select_for_po_gen ", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail3.DataSource = ds.Tables[0];
            grdDetail3.DataBind();

            cmd = new SqlCommand("jct_ops_wdrb_select_for_po_gen ", con);
            //cmd = new SqlCommand("Exec jct_ops_pending_rate_wardrode '" + Session["EmpCode"].ToString() + "'", con);

            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            grdDetail2.DataSource = ds.Tables[0];
            grdDetail2.DataBind();







        }
    


    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt3 = (TextBox)e.Row.FindControl("txtpo");
            //if (rdlst.SelectedIndex == 0)
            //{
            //    txt3.Enabled = true;
            //}
            if (rdlst.SelectedIndex == 0)
            {
                txt3.Enabled = true;
            }
            if (rdlst.SelectedIndex == 0)
            {
                TextBox txt = (TextBox)e.Row.FindControl("purchase");
                TextBox txt2 = (TextBox)e.Row.FindControl("Saleprice");
                txt.Enabled = false;
                txt2.Enabled = false;

            }
            if (rdlst.SelectedIndex == 1)
            {
                //TextBox txt = (TextBox)e.Row.FindControl("purchase");
                //TextBox txt2 = (TextBox)e.Row.FindControl("saleprice");
                //txt.Enabled = false;
                //txt2.Enabled = true;

            }




        }



    }

    protected void lnkaccept_Click(object sender, EventArgs e)
    {
        if (rdlst.SelectedIndex == 2)
        {
            foreach (GridViewRow rw in grdDetail3.Rows)
            {
                CheckBox chk1 = (CheckBox)rw.FindControl("chk");
                TextBox txt = (TextBox)rw.FindControl("purchase");
                TextBox txt2 = (TextBox)rw.FindControl("saleprice");
                TextBox txt3 = (TextBox)rw.FindControl("txtpo");
                if (chk1.Checked)
                {

                    SqlCommand cmd = new SqlCommand("jct_ops_po_raw_mkt_approval_yes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = rw.Cells[4].Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //SendMail();
                    string script = "alert(' record saved sucesfully. and Mail has been sent to float and freeze the same!! ');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
            }
            foreach (GridViewRow rm in grdDetail2.Rows)
            {

                CheckBox chk2 = (CheckBox)rm.FindControl("CheckBox1");
                TextBox txt4 = (TextBox)rm.FindControl("txtsale");
                TextBox txt5 = (TextBox)rm.FindControl("txtrate");
                TextBox txt6 = (TextBox)rm.FindControl("txtsupplr");
                if (chk2.Checked)
                {
                    SqlCommand cmd = new SqlCommand("jct_ops_outscrd_wdrb_mkt_approval_yes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = rm.Cells[5].Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //SendMail2();
                    string script = "alert(' record saved sucesfully. and Mail has been sent to float and freeze the same!! ');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                }

            }

        }
    }



    protected void lnkreject_Click(object sender, EventArgs e)
    {
        if (rdlst.SelectedIndex == 2)
        {
            foreach (GridViewRow rw in grdDetail3.Rows)
            {
                CheckBox chk1 = (CheckBox)rw.FindControl("chk");
                TextBox txt = (TextBox)rw.FindControl("purchase");
                TextBox txt2 = (TextBox)rw.FindControl("FinishSalePrice");
                TextBox txt3 = (TextBox)rw.FindControl("txtpo");
                if (chk1.Checked)
                {

                    SqlCommand cmd = new SqlCommand("jct_ops_po_raw_mkt_approval_no", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = rw.Cells[4].Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    foreach (GridViewRow rm in grdDetail2.Rows)
                    {

                        CheckBox chk2 = (CheckBox)rm.FindControl("CheckBox1");
                        TextBox txt4 = (TextBox)rm.FindControl("txtsale");
                        TextBox txt5 = (TextBox)rm.FindControl("txtrate");
                        TextBox txt6 = (TextBox)rm.FindControl("txtsupplr");
                        if (chk2.Checked)
                        {
                            cmd = new SqlCommand("jct_ops_outscrd_wdrb_mkt_approval_no", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = rw.Cells[4].Text;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }

            }
        }
    }

    //private void SendMail()
    //{
    //    foreach (GridViewRow rw in grdDetail3.Rows)
    //    {
    //        string id;
    //        id = rw.Cells[4].Text;
    //        CheckBox chk1 = (CheckBox)rw.FindControl("chk");
    //        TextBox txt = (TextBox)rw.FindControl("purchase");
    //        TextBox txt2 = (TextBox)rw.FindControl("saleprice");
    //        TextBox txt3 = (TextBox)rw.FindControl("txtpo");
    //        if (chk1.Checked)
    //        {
    //            string @from = null;
    //            string to = null;
    //            string bcc = null;
    //            string cc = null;
    //            string subject = null;
    //            string body = null;


    //            //string sql = "SELECT b.EMPCODE,c.empname,d.E_MailID AS Email FROM jct_ops_outsrd_dyed_fab a INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON CONVERT(VARCHAR,a.RequestID) = b.ID AND a.pending_at=CONVERT(VARCHAR,b.USERLEVEL) INNER JOIN dbo.JCT_EmpMast_Base c ON c.empcode=b.EMPCODE LEFT OUTER JOIN dbo.MISTEL d on d.empcode=b.EMPCODE where CONVERT(VARCHAR,a.RequestID) =" + id + "";
    //            //SqlCommand cmd = new SqlCommand(sql, con);
    //            //SqlDataReader Dr = cmd.ExecuteReader();
    //            //if (Dr.HasRows)
    //            //{
    //            //    while (Dr.Read())
    //            //    {
    //            //        ViewState["PendingAtName"] = Dr["empname"].ToString();
    //            //        ViewState["PendingAtEmpCode"] = Dr["empcode"].ToString();
    //            //        ViewState["PendingAtEmail"] = Dr["Email"].ToString();
    //            //    }
    //            //}
    //            //Dr.Close();

    //            string sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(sql, con);
    //            //con.Open();

    //            SqlDataReader Dr = cmd.ExecuteReader();

    //            //Dr = cmd.ExecuteReader();
    //            if (Dr.HasRows)
    //            {
    //                while (Dr.Read())
    //                {
    //                    ViewState["RequestBy"] = Dr["empname"].ToString();
    //                    ViewState["RequestByEmail"] = Dr["email"].ToString();
    //                }
    //            }
    //            else
    //            {
    //                ViewState["RequestBy"] = "";
    //                ViewState["RequestByEmail"] = "jatindutta@jctltd.com";
    //            }

    //            Dr.Close();

    //            StringBuilder sb = new StringBuilder();

    //            sb.AppendLine("<html>");
    //            sb.AppendLine("<head>");
    //            sb.AppendLine("<style type=\"text/css\">");
    //            sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
    //            sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
    //            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
    //            sb.AppendLine("</style>");
    //            sb.AppendLine("</head>");

    //            sb.AppendLine("Hi,<br/>");
    //            sb.AppendLine("Outsourced Fabric Request has been approved and P.O  has been genrated by : " + Session["Empcode"] + "<br/><br/>");
    //            sb.AppendLine("RequestID for your request is : " + id + " <br/><br/>");
    //            //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
    //            sb.AppendLine("Details are Shown below : <br/><br/>");
    //            sb.AppendLine("<table class=gridtable>");

    //            sql = "jct_ops_outsrd_dyed_fab_mail";
    //            cmd = new SqlCommand(sql, con);

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = id;
    //            Dr = cmd.ExecuteReader();
    //            if ((Dr.HasRows))
    //            {
    //                while ((Dr.Read()))
    //                {

    //                    sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
    //                    sb.AppendLine("<tr><td colspan='4'> GENERAL MANAGER - RAW MATERIAL</td></tr> ");
    //                    sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED DYED FABRIC</td> </tr>");
    //                    // sb.AppendLine("<tr><td colspan='4'> Request has been approved!!! Please Float The Same for Authorization</td> </tr>");
    //                    sb.AppendLine("<tr><td> CONSTRUCTION</td>  <td> &nbsp;</td><td> &nbsp;</td><td>  &nbsp;</td>  </tr>");
    //                    sb.AppendLine("<tr><td>   QUANTITY REQUIRED</td> <td>" + Dr["QuantityRequired"].ToString() + "</td>    <td> JCT NEW NUMBER</td><td>" + Dr["Number"].ToString() + "</td></tr>");
    //                    sb.AppendLine("<tr><td> ENDS/INCH</td> <td> " + Dr["Ends/Inch"].ToString() + "</td> <td> FINISH FABRIC CUST NAME</td><td>" + Dr["CustName"].ToString() + "</td></tr>");
    //                    sb.AppendLine("<tr><td> WARP COUNT</td><td> " + Dr["WarpCount"].ToString() + "</td><td> REFERENCE MKT EXEC</td><td>" + Dr["MarkExec"].ToString() + "</td></tr>");
    //                    sb.AppendLine("<tr><td> WIDTH</td><td>" + Dr["Width"].ToString() + "</td> <td>  &nbsp;</td><td> &nbsp;</td> </tr>");
    //                    sb.AppendLine("<tr> <td>BLEND</td> <td> " + Dr["Blend"].ToString() + "</td><td> &nbsp;</td><td> &nbsp;</td> </tr>");
    //                    sb.AppendLine("<tr><td>WEAVE</td><td>" + Dr["Weave"].ToString() + "</td><td>&nbsp;</td><td> &nbsp;</td> </tr>");
    //                    sb.AppendLine("<tr> <td>  PIECE LENGTH</td><td> " + Dr["PeiceLength"] + "</td> <td>&nbsp;</td> <td> &nbsp;</td> </tr>");
    //                    sb.AppendLine("<tr><td>  DELIVERY UPTO</td><td> </td> <td>" + Dr["DeliveryTerm"].ToString() + "</td>  <td>&nbsp;</td> </tr>");
    //                    sb.AppendLine("<tr><td>JCT PARALLEL SORT NO. (IF ANY)</td> <td> " + Dr["ParallelSort"].ToString() + "</td><td>&nbsp;</td><td>&nbsp;</td> </tr>");
    //                    sb.AppendLine("<tr> <td> ANY SPECIAL SPECIFICATION</td><td> &nbsp;</td> <td>  &nbsp;</td> <td>  &nbsp;</td></tr>");
    //                    sb.AppendLine("<tr><td colspan='2'>   PURCHASE</td> <td colspan='2'>" + txt.Text + "</td></tr>");
    //                    sb.AppendLine("<tr><td colspan='2'>FINISH SALE PRICE</td><td colspan='2'>" + txt2.Text + "</td></tr>");

    //                }
    //            }

    //            Dr.Close();
    //            con.Close();
    //            sb.AppendLine("</table>");

    //            sb.AppendLine("<br /><br/>");

    //            //sb.Append("<a href=''> Click here to float and freeze the request for authorization!!! </a><br />");

    //            sb.AppendLine("</table><br />");

    //            sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
    //            sb.AppendLine("Thank you<br />");
    //            sb.AppendLine("</html>");


    //            body = sb.ToString();
    //            @from = "noreply@jctltd.com";

    //            to = ViewState["RequestByEmail"].ToString();

    //            //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
    //            bcc = "shwetaloria@jctltd.com";
    //            subject = "Outsourced Fabric Request - " + id;
    //            MailMessage mail = new MailMessage();
    //            mail.From = new MailAddress(@from);
    //            if (to.Contains(","))
    //            {
    //                string[] tos = to.Split(',');
    //                for (int i = 0; i <= tos.Length - 1; i++)
    //                {
    //                    mail.To.Add(new MailAddress(tos[i]));
    //                }
    //            }
    //            else
    //            {
    //                mail.To.Add(new MailAddress(to));
    //            }

    //            if (!string.IsNullOrEmpty(bcc))
    //            {
    //                if (bcc.Contains(","))
    //                {
    //                    string[] bccs = bcc.Split(',');
    //                    for (int i = 0; i <= bccs.Length - 1; i++)
    //                    {
    //                        mail.Bcc.Add(new MailAddress(bccs[i]));
    //                    }
    //                }
    //                else
    //                {
    //                    mail.Bcc.Add(new MailAddress(bcc));
    //                }
    //            }
    //            //If Not String.IsNullOrEmpty(cc) Then
    //            //    If cc.Contains(",") Then
    //            //        Dim ccs As String() = cc.Split(","c)
    //            //        For i As Integer = 0 To ccs.Length - 1
    //            //            mail.CC.Add(New MailAddress(ccs(i)))
    //            //        Next
    //            //    Else
    //            //        mail.CC.Add(New MailAddress(bcc))
    //            //    End If
    //            //    mail.CC.Add(New MailAddress(cc))
    //            //End If

    //            mail.Subject = subject;
    //            mail.Body = body;
    //            mail.IsBodyHtml = true;
    //            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //            SmtpClient SmtpMail = new SmtpClient("exchange2007");

    //            //SmtpMail.SmtpServer = "exchange2007";
    //            SmtpMail.Send(mail);
    //            //return mail;
    //        }

    //    }
    //}

    protected void grdDetail2_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt7 = (TextBox)e.Row.FindControl("txtwdrbPO");
            if (rdlst.SelectedIndex == 0)
            {
                txt7.Enabled = true;
            }
            if (rdlst.SelectedIndex == 0)
            {
                txt7.Enabled = true;
            }
            if (rdlst.SelectedIndex == 0)
            {
                TextBox txt4 = (TextBox)e.Row.FindControl("txtsale");
                TextBox txt5 = (TextBox)e.Row.FindControl("txtrate");
                TextBox txt6 = (TextBox)e.Row.FindControl("txtsupplr");
                txt4.Enabled = false;
                txt5.Enabled = false;
                txt6.Enabled = false;

            }
        }
    }

    //private void SendMail2()
    //{
    //    foreach (GridViewRow rm in grdDetail2.Rows)
    //    {
    //        string id;
    //        id = rm.Cells[5].Text;
    //        CheckBox chk2 = (CheckBox)rm.FindControl("CheckBox1");
    //        TextBox txt4 = (TextBox)rm.FindControl("txtsale");
    //        TextBox txt5 = (TextBox)rm.FindControl("txtrate");
    //        TextBox txt6 = (TextBox)rm.FindControl("txtsupplr");
    //        if (chk2.Checked)
    //        {
    //            string @from = null;
    //            string to = null;
    //            string bcc = null;
    //            string cc = null;
    //            string subject = null;
    //            string body = null;

    //            string sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a left outer join mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";

    //            SqlCommand cmd = new SqlCommand(sql, con);
    //            con.Open();
    //            SqlDataReader Dr = cmd.ExecuteReader();
    //            if (Dr.HasRows)
    //            {
    //                while (Dr.Read())
    //                {
    //                    ViewState["RequestBy"] = Dr["empname"].ToString();
    //                    ViewState["RequestByEmail"] = Dr["email"].ToString();
    //                }
    //            }
    //            else
    //            {
    //                ViewState["RequestBy"] = "";
    //                ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
    //            }


    //            sql = "select empname,e_mailid from jct_empmast_base a join  jct_ops_outsourced_wardrobe b on  a.empcode=b.enteredby join mistel c  on  c.empcode=b.enteredby    where b.reqid=@requestid  ";
    //            cmd = new SqlCommand(sql, con);
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 20).Value = id;

    //            con.Open();
    //            Dr = cmd.ExecuteReader();

    //            if (Dr.HasRows)
    //            {
    //                while (Dr.Read())
    //                {
    //                    ViewState["Reqgenrator"] = Dr["empname"].ToString();
    //                    ViewState["EmailGenrator"] = Dr["email"].ToString();
    //                }
    //                Dr.Close();

    //                StringBuilder sb = new StringBuilder();

    //                sb.AppendLine("<html>");
    //                sb.AppendLine("<head>");
    //                sb.AppendLine("<style type=\"text/css\">");
    //                sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
    //                sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
    //                sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
    //                sb.AppendLine("</style>");
    //                sb.AppendLine("</head>");

    //                sb.AppendLine("Hi,<br/>");
    //                sb.AppendLine("Outsourced Fabric Request has been approved in OPS and Po has been generated by : " + ViewState["RequestBy"] + "<br/><br/>");
    //                sb.AppendLine("RequestID for your request is : " + id + " <br/><br/>");
    //                //sb.AppendLine("Approval Pending At : " + ViewState["PendingAtName"] + " <br/><br/>");
    //                sb.AppendLine("Details are Shown below : <br/><br/>");
    //                sb.AppendLine("<table class=gridtable>");

    //                sql = "jct_ops_outsourced_select";
    //                cmd = new SqlCommand(sql, con);

    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.Add("@Reqid", SqlDbType.VarChar, 10).Value = id;
    //                //ViewState["RequestID"].ToString();
    //                Dr = cmd.ExecuteReader();
    //                if ((Dr.HasRows))
    //                {
    //                    while ((Dr.Read()))
    //                    {

    //                        sb.AppendLine("<tr><td align='center' colspan='4'> JCT LTD, PHAGWARA</td></tr> ");
    //                        sb.AppendLine("<tr><td colspan='4'> GENERAL MANAGER - MARKETING</td></tr> ");
    //                        sb.AppendLine("<tr><td colspan='4'>SUBJECT - OUTSOURCED FABRIC (WardRobe)</td> </tr>");
    //                        sb.AppendLine("<tr><td> CONSTRUCTION</td>  <td>   </tr>");
    //                        sb.AppendLine("<tr><td>RequestID </td> <td>" + Dr["reqid"].ToString() + "</td>  </tr>");
    //                        sb.AppendLine("<tr><td>Request By </td> <td>" + Dr["purchase_by"].ToString() + "</td>  </tr>");
    //                        sb.AppendLine("<tr><td>Sort no/td> <td> " + Dr["sort_no"].ToString() + "</td> </tr>");
    //                        //sb.AppendLine("<tr><td> Designs no</td><td> " + Dr["Designs_no"].ToString() + "</td> </tr>");
    //                        sb.AppendLine("<tr><td> Totqty</td><td>" + Dr["totqty"].ToString() + "</td> </tr>");
    //                        sb.AppendLine("<tr> <td>Rate(per_mts)</td> <td> " + Dr["rateper_mts"].ToString() + "</td> </tr>");
    //                        sb.AppendLine("<tr><td>Sale(Per_mts)</td><td>" + Dr["sale_per_mts"].ToString() + "</td> </tr>");
    //                        sb.AppendLine("<tr> <td>Supplier</td><td> " + Dr["supplier"] + "</td> </tr>");


    //                    }
    //                }

    //                Dr.Close();
    //                con.Close();
    //                sb.AppendLine("</table>");

    //                sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>");
    //                sb.AppendLine("Thank you<br />");
    //                sb.AppendLine("</html>");


    //                body = sb.ToString();
    //                @from = "noreply@jctltd.com";

    //                to = ViewState["RequestByEmail"].ToString() + "," + ViewState["EmailGenrator"].ToString() + ",pkchhabra@jctltd.com";

    //                //bcc = "jatindutta@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
    //                bcc = "shwetaloria@jctltd.com,jatindutta@jctltd.com";
    //                subject = "Outsourced Fabric Request - " + id;
    //                MailMessage mail = new MailMessage();
    //                mail.From = new MailAddress(@from);
    //                if (to.Contains(","))
    //                {
    //                    string[] tos = to.Split(',');
    //                    for (int i = 0; i <= tos.Length - 1; i++)
    //                    {
    //                        mail.To.Add(new MailAddress(tos[i]));
    //                    }
    //                }
    //                else
    //                {
    //                    mail.To.Add(new MailAddress(to));
    //                }

    //                if (!string.IsNullOrEmpty(bcc))
    //                {
    //                    if (bcc.Contains(","))
    //                    {
    //                        string[] bccs = bcc.Split(',');
    //                        for (int i = 0; i <= bccs.Length - 1; i++)
    //                        {
    //                            mail.Bcc.Add(new MailAddress(bccs[i]));
    //                        }
    //                    }
    //                    else
    //                    {
    //                        mail.Bcc.Add(new MailAddress(bcc));
    //                    }
    //                }
    //                //If Not String.IsNullOrEmpty(cc) Then
    //                //    If cc.Contains(",") Then
    //                //        Dim ccs As String() = cc.Split(","c)
    //                //        For i As Integer = 0 To ccs.Length - 1
    //                //            mail.CC.Add(New MailAddress(ccs(i)))
    //                //        Next
    //                //    Else
    //                //        mail.CC.Add(New MailAddress(bcc))
    //                //    End If
    //                //    mail.CC.Add(New MailAddress(cc))
    //                //End If

    //                mail.Subject = subject;
    //                mail.Body = body;
    //                mail.IsBodyHtml = true;
    //                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //                SmtpClient SmtpMail = new SmtpClient("exchange2007");

    //                //SmtpMail.SmtpServer = "exchange2007";
    //                SmtpMail.Send(mail);
    //                //return mail;
    //            }
    //        }
    //    }
    //}
}


 



