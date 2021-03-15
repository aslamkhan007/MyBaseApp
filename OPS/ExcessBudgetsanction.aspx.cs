using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Data;
using System.IO;

public partial class OPS_ExcessBudgetsanction : System.Web.UI.Page
{

    string budamt = string.Empty;
    string balamt = string.Empty;
    string deptcode = string.Empty;
    string hod = string.Empty;
    string budgetID = string.Empty;
    string budgetno = string.Empty;

    Functions obj1 = new Functions();
    //SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TestReportDBConnectionString"].ConnectionString);
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ReportDBConnectionString"].ConnectionString);
    // Connection obj = new Connection();

    protected void Page_Load(object sender, EventArgs e)
   {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        try
       {
            if (!IsPostBack)
            {
                //string sql = "SELECT DISTINCT  a.deptcode,b.deptname from misdev.jctdev.dbo.jct_empmast_base a join misdev.jctdev.dbo.deptmast b on a.deptcode= b.deptcode   where a.company_code='JCT00LTD' and a.active='Y' and a.empcode='" + Session["Empcode"] + "'";// '" + Session["Empcode"] + "'";// and empcode= '" + Session["Empcode"] + "'";
                //obj1.FillList(ddldept, sql);
                ListItem li= null;
                string sql = "SELECT distinct replace(a.empcode,'-','') as empcode,a.empname from misdev.jctdev.dbo.JCT_EmpMast_Base a join misdev.jctdev.dbo.JCT_Emp_Catg_Desg_Mapping b on  a.catg=b.catg join jct_ops_budget_entry  c on c.dept_name=a.deptcode where a.active='Y' and a.company_code='JCT00LTD' and a.catg='SM1' and empcode= '" + Session["Empcode"] + "' union Select 'N02639' as empcode,'Nipun Chandok' as empname  union Select 'A00047' as empcode,'ARWINDER SINGH' as empname union Select 'B00319' as empcode,'Bhagat Ram Saini' as empname union Select 'K02046' as empcode,'KHUSHWINDER SINGH DHILLON' as empname union  Select 'H01526' as empcode,'Husan Lal' as empname";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        li = new ListItem();
                        li.Value = dr["empcode"].ToString();
                        li.Text = dr["empname"].ToString();
                        ddlhod.Items.Add(li);
                    }
                }
                dr.Close();
                string empcode = Session["EmpCode"].ToString().Replace("-", "");
                //sql = "select subdept_code,subdept_name from misdev.jctdev.dbo.jct_empmast_base  where company_code='JCT00LTD' and active='Y' and empcode='A-00120'";// '" + Session["Empcode"] + "'";// and empcode= '" + Session["Empcode"] + "'";
                sql = "SELECT DISTINCT b.subdept_code , b.subdept_name FROM dbo.jct_ops_budget_entry a INNER JOIN misdev.jctdev.dbo.JCT_EmpMast_Base b ON a.dept_name=b.subdept_code WHERE status='A' AND HOD= REPLACE('" + Session["EmpCode"].ToString() + "','-','') order by b.subdept_name";
                cmd = new SqlCommand(sql, con);
                //con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        li = new ListItem();
                        li.Value = dr["subdept_code"].ToString();
                        li.Text = dr["subdept_name"].ToString();
                        ddlsubdept.Items.Add(li);
                        ddlhod.SelectedIndex = ddlhod.Items.IndexOf(ddlhod.Items.FindByValue(empcode));
                        
                    }
                }

                dr.Close();
                con.Close();
                FindBudgetID();

            }
            
        }
        catch
        {
            Lnkapply.Enabled = false;
            string script2 = "alert('You are not authorized to generate Excess Budget request.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
            
    }

    protected void FindBudgetID()
    {
//'string sql = "SELECT  max(budgetID) as budgetID FROM dbo.jct_ops_budget_entry WHERE status='A' AND dept_name = '" + ddlsubdept.SelectedItem.Value + "' AND budget_type ='" + ddltype.SelectedItem.Text + "' and month(eff_to)= month(getdate()) and year(eff_to)= year(getdate())";
        string sql = "SELECT  max(budgetID) as budgetID FROM dbo.jct_ops_budget_entry WHERE status='A' AND dept_name = '" + ddlsubdept.SelectedItem.Value + "' AND budget_type ='" + ddltype.SelectedItem.Text + "'   AND GETDATE() BETWEEN eff_from AND eff_to";

        SqlCommand cmd = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblBudgetID.Text = dr["budgetid"].ToString();
            }
        }
        dr.Close();
        
        //string sql = "select budget_amt,balance_budget_amt,budgetID from jct_ops_budget_entry  where hod='" + ddlhod.SelectedItem.Value + "' and status='A' and  dept_name= '" + ddldept.SelectedItem.Value + "' and  Budget_type= '" + ddltype.SelectedItem.Text + "'";
        sql = "select budget_amt,balance_budget_amt,budgetID from jct_ops_budget_entry  where status='A' and budgetid='"+lblBudgetID.Text +"' and  Budget_type= '" + ddltype.SelectedItem.Text + "'";
        cmd = new SqlCommand(sql, con);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while(dr.Read())
            { 
                budamt = dr[0].ToString();
                balamt = dr[1].ToString();
                budgetID = dr[2].ToString();
                txtbudamt.Text = budamt;
                txtbalamt.Text = balamt;
                //ViewState["budgetID"] = budgetID;
                txtbalamt.Enabled = false;
                txtbudamt.Enabled = false;   
            }
        }
        else
        {
            dr.Close();
            string script2 = "alert('You are not authorized to generate Excess Budget request.!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
        dr.Close();
       
    }
 

    protected void ddldept_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           //string sql = "SELECT distinct a.empcode,a.empname from misdev.jctdev.dbo.JCT_EmpMast_Base a join misdev.jctdev.dbo.JCT_Emp_Catg_Desg_Mapping b on  a.catg=b.catg join jct_ops_budget_entry  c on c.dept_name=a.deptcode where a.active='Y' and a.company_code='JCT00LTD' and a.catg='SM1' and subdept_code= '" + ddldept.SelectedItem.Value + "'";
           //obj1.FillList(ddlhod, sql);

           FindBudgetID();
        }
        catch { }
    }

    protected void Lnkapply_Click(object sender, EventArgs e)
    {
        

        bool CurrentStatus;
        CurrentStatus = false;

        string sql = "select authflag from jct_ops_excess_bdget_amt  where budgetID= ' " + lblBudgetID.Text + "' and authflag in ('A','P')";
        if (obj1.CheckRecordExistInTransaction(sql))
        {
            CurrentStatus = true;    
        }


        SqlTransaction tran;
        con.Open();

        tran = con.BeginTransaction();
        try
        {
            if (txtexcessamt.Text == "")
            {
                string script2 = "alert('Error occured!! Please fill the indent amount ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }
            else
            {
                //string sql = "select authflag from jct_ops_excess_bdget_amt  where budgetID= ' " + lblBudgetID.Text + "' and authflag in ('A','P')";
                if (CurrentStatus==true)
                {
                    Lnkapply.Enabled = false;
                    string script2 = "alert('The above Sanction is already Pending/Authorized. You can not create a new sanction transaction.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                }
                else
                {
                    sql = "jct_ops_excess_budget_entry";

                    SqlCommand cmd = new SqlCommand(sql, con, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BudgetID", SqlDbType.VarChar, 20).Value = lblBudgetID.Text;
                    cmd.Parameters.Add("@Excess_amt", SqlDbType.Decimal).Value = txtexcessamt.Text;
                    cmd.Parameters.Add("@Entry_by", SqlDbType.VarChar, 20).Value = Session["Empcode"].ToString();
                    cmd.Parameters.Add("@HOD", SqlDbType.VarChar, 100).Value = ddlhod.SelectedItem.Value;
                    cmd.Parameters.Add("@indent_amt", SqlDbType.Decimal).Value = txtindentamt.Text == "" ? null : txtindentamt.Text;
                    cmd.Parameters.Add("@PO_UPR", SqlDbType.VarChar, 50).Value = txtindentno.Text;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtremarks.Text;
                    if (Request.Files.Count > 0)
                    {
                        cmd.Parameters.Add("@FileAttached", SqlDbType.VarChar, 200).Value = "Yes";
                    }
                    else
                    {
                        cmd.Parameters.Add("@FileAttached", SqlDbType.VarChar, 200).Value = "No";
                    }

                    //cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtremarks.Text;
                    //cmd.Parameters.Add("@hod", SqlDbType.VarChar, 200).Value = ddlhod.SelectedItem.Value;
                    cmd.Parameters.Add("@group_code", SqlDbType.VarChar, 10).Value = ddlgroupcode.SelectedItem.Value;
                    cmd.ExecuteNonQuery();
                    uploadfile(tran,con);
                    
                   
                    GenerateSanction(txtindentno.Text, tran,con);
                    
                    tran.Commit();
 sendmail();
clearform();
                    string script2 = "alert('Record Saved Succesfully.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);

                }
            }

        }
        catch (SqlException sqlex)
        {
            string script2 = "alert('" + sqlex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            tran.Rollback();
            return;
        }
        finally
        {
            con.Close();
        }
    }

    protected void clearform()
    {
        txtbudamt.Text = string.Empty;
        txtexcessamt.Text = string.Empty;
        txtindentamt.Text = string.Empty;
       // txtindentno.Text = string.Empty;
        txtremarks.Text = string.Empty;
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }

    protected void txtindentno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string sql;
 
            //sql = "select b.stock_no as [StockNo],a.stock_variant as [Stock Variant],b.short_description as [Short Desc],a.purchase_uom as [Uom],ROUND(CAST(a.required_qty_puom AS numeric(12,2)), 2)as[ReqQty],ROUND(CAST(a.unit_cost AS numeric(12,2)), 2) as [Unit cost],a.remarks as [Remarks] from miserp.pomdb.dbo.pur_indent_detail a join  miserp.common.dbo.ims_stock_master b  on a.stock_no=b.stock_no where  a.indent_no='" + txtindentno.Text + "'";
            sql = "select b.stock_no as [StockNo],a.stock_variant as [Stock Variant],b.short_description as [Short Desc],a.purchase_uom as [Uom],ROUND(CAST(a.required_qty_puom AS numeric(12,2)), 2)as[ReqQty],a.remarks as [Remarks] from miserp.pomdb.dbo.pur_indent_detail a join  miserp.common.dbo.ims_stock_master b  on a.stock_no=b.stock_no where  a.indent_no='" + txtindentno.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert('Indent No. invalid !!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();

            sql = "SELECT * FROM dbo.jct_ops_excess_bdget_amt WHERE PO_UPR ='" + txtindentno.Text + "' AND status IN ('A') AND authflag IN ('A','P')";
            cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Lnkapply.Enabled = false;
                string script = "alert('Request already generated for this Indent No. Please enter a new indent no.!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
            dr.Close();

            if (Lnkapply.Enabled == false)
            {
                Lnkapply.Enabled = true;
            }

            sql = "select round(sum(CAST( approximate_indent_value AS decimal(12,2))),2) from miserp.pomdb.dbo.jct_indent_location where indent_no='" + txtindentno.Text + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            //con.Open();

            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows == true)
            {
                //txtindentamt.Text = dr[0].ToString();
                txtexcessamt.Text = dr[0].ToString();
                txtindentamt.Enabled = false;
            }
           
            dr.Close();

            sql = "select round(sum(CAST( total_value AS decimal(12,2))),2) from miserp.pomdb.dbo.pur_indent_detail where indent_no='" + txtindentno.Text + "'";
            //sql = "select round(sum(CAST( approximate_indent_amt AS decimal(12,2))),2) from miserp.pomdb.dbo.jct_indent_location where indent_no='" + txtindentno.Text + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows == true)
            {
                txtindentamt.Text = dr[0].ToString();
                //txtexcessamt.Text = dr[0].ToString();
                txtindentamt.Enabled = false;
            }
            con.Close();
            dr.Close();

        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string sql;
        sql = "select b.stock_no as [StockNo],a.stock_variant as [Stock Variant],b.short_description as [Short Desc],a.purchase_uom as [Uom],ROUND(CAST(a.required_qty_puom AS numeric(12,2)), 2)as[ReqQty], ROUND(CAST(a.total_value AS numeric(12,2)), 2) as[Tot Value],ROUND(CAST(a.unit_cost AS numeric(12,2)), 2) as [Unit cost],a.remarks as [Remarks] from miserp.pomdb.dbo.pur_indent_detail a join  miserp.common.dbo.ims_stock_master b  on a.stock_no=b.stock_no where  a.indent_no='" + txtindentno.Text + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        sql = "select round(sum(CAST( total_value AS decimal(12,2))),2) from miserp.pomdb.dbo.pur_indent_detail where indent_no='" + txtindentno.Text + "'";
        cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        con.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            txtindentamt.Text = dr[0].ToString();
        }
        con.Close();
    }
 
    protected void Lnkcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("excessbudgetsanction.aspx");
    }
 
    private void sendmail()
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
            string indent_no = string.Empty;


            sql = "Select a.empname,b.e_mailid as email from  misdev.jctdev.dbo.jct_empmast_base a left outer join  misdev.jctdev.dbo.mistel b on a.empcode=b.empcode where a.empcode='" + Session["Empcode"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
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
                ViewState["RequestByEmail"] = "rajan@jctltd.com";
            }

            Dr.Close();


            subject = "Excess Budget Sanction";// + lblBudgetID.Text;// ddlsubdept.SelectedItem.Value;//ViewState["budgetID");
            //querystring = "RequestID=" + ViewState["RequestID");
            querystring = "EmpCode=" + Session["EmpCode"].ToString() + "&budgetID=" + lblBudgetID.Text + "&indent_no=" + txtindentno.Text;
             
            //url = "http://localhost:2547/FusionApps1/OPS/MailContentPages/excessbudgetmail.aspx?" + querystring;
            // url = "http://test2k/FusionApps/OPS/MailContentPages/excessbudgetmail.aspx?" + querystring;

             url = "http://testerp/FusionApps/OPS/MailContentPages/excessbudgetmail.aspx?" + querystring;

            @from = "noreply@jctltd.com";

            //sql = "SELECT b.E_MailID FROM dbo.jct_ops_excess_bdget_amt a INNER JOIN dbo.MISTEL b ON a.entry_by=b.empcode WHERE a.budgetID='" + ViewState["budgetID"] + "' AND status='A'";
            sql =  "SELECT  DISTINCT b.E_MailID " +
                    "FROM dbo.jct_ops_excess_bdget_amt a " +
                    "INNER JOIN dbo.jct_ops_indenter_tab c ON a.budgetID = c.budgetID "+
                    "INNER JOIN MISDEV.JCTDEV.DBO.jct_indentor_code_test d ON c.indenter_code=d.req_emp_no "+
                    "INNER JOIN MISDEV.JCTDEV.dbo.MISTEL b ON d.Level1 = REPLACE(b.empcode,'-','') "+
                    "WHERE a.budgetID = '"+ lblBudgetID.Text +"' "+
                    "AND a.status = 'A' "+
                    "AND d.Level1 IS NOT NULL";
            try
            {
                cmd = new SqlCommand(sql, con);
                //con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        to = dr["E_MailID"].ToString();
                        cc = ViewState["RequestByEmail"].ToString();
                     
                    }
                }
                dr.Close();
                //con.Close();
                cc =cc+ ",ranjeetk@jctltd.com";
                bcc = "rajan@jctltd.com,rbaksshi@jctltd.com";
            }
            catch {
                to = "ashish@jctltd.com";
            //to = "ashish@jctltd.com,shwetaloria@jctltd.com";
            bcc = "rajan@jctltd.com";
            }

            //to = "ashish@jctltd.com,shwetaloria@jctltd.com";
            // bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com";
            // bcc = "ashish@jctltd.com,shwetaloria@jctltd.com,rajan@jctltd.com,rbaksshi@jctltd.com";
            // cc = "laxman@jctltd.com,arvindsharma@jctltd.com,dpbadhwar@jctltd.com";

            string Body = GetPage(url);

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
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
            SmtpMail.Send(mail);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return;
        }

    }

    protected string GetPage(string page_name)
    {
        WebClient myclient = new WebClient();
        string myPageHTML = null;
        byte[] requestHTML = null;
        string currentPageUrl = null;

        currentPageUrl = Request.Url.AbsoluteUri;
        currentPageUrl = page_name;

        UTF8Encoding utf8 = new UTF8Encoding();

        requestHTML = myclient.DownloadData(currentPageUrl);
        myPageHTML = utf8.GetString(requestHTML);

        //Response.Write(myPageHTML)

        return myPageHTML;

    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        FindBudgetID();
        string sql;

        //string sql = "select excess_flag from jct_ops_budget_entry  where budgetID = '" + ddlsubdept.SelectedItem.Value + "' and excess_flag='Y'";
        //SqlCommand cmd = new SqlCommand(sql, con);
        //cmd.CommandType = CommandType.Text;
        //con.Open();
        //SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        //if (dr.HasRows == true)
        //{
        //    Lnkapply.Enabled = false;
        //    string script2 = "alert('Budget Sanction Already Authorised.');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        //}
        //else
        //{

            sql = "select budget_amt,balance_budget_amt,budgetID from jct_ops_budget_entry where status='A' and budgetid='"+ lblBudgetID.Text +"' and  Budget_type= '" + ddltype.SelectedItem.Text + "'";
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd2 = new SqlCommand(sql, con);
            cmd2.CommandType = CommandType.Text;
            //con.Open();
            SqlDataReader dr1 = cmd2.ExecuteReader();

            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                {
                    budamt = dr1[0].ToString();
                    balamt = dr1[1].ToString();
                    budgetno = dr1[2].ToString();
                    txtbudamt.Text = budamt;
                    txtbalamt.Text = balamt;
                    //ViewState["budgetID"] = budgetno;
                    txtbalamt.Enabled = false;
                    txtbudamt.Enabled = false;
                }
            }
            dr1.Close();
            con.Close();
        //}

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        uploadfile();
    } 




    private void uploadfile(SqlTransaction tran,SqlConnection con)
    {
        string contenttype = string.Empty;
        string filename = string.Empty;
        string ext = string.Empty;

        try
        {
            if (Request.Files.Count > 0)
            {
                List<String> Files = new List<String>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile PostedFile = Request.Files[i];
                    if (PostedFile.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        PostedFile.SaveAs(Server.MapPath("Docs\\") + FileName);
                        Files.Add(FileName);
                    }

                }

            }


            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile PostedFile = Request.Files[i];
                    if (PostedFile.ContentLength > 0)
                    {
                        filename = System.IO.Path.GetFileName(PostedFile.FileName);
                        ext = System.IO.Path.GetExtension(PostedFile.FileName);
                        SqlCommand cmd1 = new SqlCommand("select mimetype from misdev.jctdev.dbo.Jct_Upload_FIle_ContentTypes where extension=@ext", con,tran);

                        cmd1.Parameters.Add("@ext", SqlDbType.VarChar).Value = ext.Replace(".", "");
                        SqlDataReader dr = cmd1.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                contenttype = dr["mimetype"].ToString();
                            }
                        }
                        dr.Close();

                        //string contenttype = ((string)cmd1.ExecuteScalar());

                        if (contenttype != String.Empty && contenttype != null)
                        {

                            Stream fs = PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            SqlCommand cmd = new SqlCommand("jct_ops_budget_file_upload_detail", con,tran);

                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.Parameters.Add("@FileContent", SqlDbType.VarBinary).Value = bytes;

                            cmd.Parameters.Add("@DocName", SqlDbType.VarChar).Value = filename;

                            cmd.Parameters.Add("@DocExt", SqlDbType.VarChar).Value = ext;
                            cmd.Parameters.Add("@Contenttype", SqlDbType.VarChar).Value = contenttype;
                            cmd.Parameters.Add("@usercode", SqlDbType.VarChar).Value = Session["Empcode"];
                            cmd.Parameters.Add("@budgetid", SqlDbType.VarChar).Value = lblBudgetID.Text;//"bud-100";// ViewState["budgetID");
                            //function bolean
                            cmd.ExecuteNonQuery();

                            //InsertUpdateData(cmd);

                            string script = "alert('File uploaded !! ');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                            // return;
                        }
                    }
                    //con.Close();

                }


            }
        }
        catch (Exception exr)
        {
            Response.Write(exr.Message);
        }
    }


    private void uploadfile()
    {
        string contenttype = string.Empty;
        string filename = string.Empty;
        string ext = string.Empty;

        try
        {
            if (Request.Files.Count > 0)
            {
                List<String> Files = new List<String>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile PostedFile = Request.Files[i];
                    if (PostedFile.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        PostedFile.SaveAs(Server.MapPath("Docs\\") + FileName);
                        Files.Add(FileName);
                    }

                }

            }


            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile PostedFile = Request.Files[i];
                    if (PostedFile.ContentLength > 0)
                    {
                        filename = System.IO.Path.GetFileName(PostedFile.FileName);
                        ext = System.IO.Path.GetExtension(PostedFile.FileName);
                        SqlCommand cmd1 = new SqlCommand("select mimetype from misdev.jctdev.dbo.Jct_Upload_FIle_ContentTypes where extension=@ext", con);

                        cmd1.Parameters.Add("@ext", SqlDbType.VarChar).Value = ext.Replace(".", "");
                        SqlDataReader dr = cmd1.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                contenttype = dr["mimetype"].ToString();
                            }
                        }
                        dr.Close();

                        //string contenttype = ((string)cmd1.ExecuteScalar());

                        if (contenttype != String.Empty && contenttype != null)
                        {

                            Stream fs = PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            SqlCommand cmd = new SqlCommand("jct_ops_budget_file_upload_detail", con);

                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.Parameters.Add("@FileContent", SqlDbType.VarBinary).Value = bytes;

                            cmd.Parameters.Add("@DocName", SqlDbType.VarChar).Value = filename;

                            cmd.Parameters.Add("@DocExt", SqlDbType.VarChar).Value = ext;
                            cmd.Parameters.Add("@Contenttype", SqlDbType.VarChar).Value = contenttype;
                            cmd.Parameters.Add("@usercode", SqlDbType.VarChar).Value = Session["Empcode"];
                            cmd.Parameters.Add("@budgetid", SqlDbType.VarChar).Value = lblBudgetID.Text;//"bud-100";// ViewState["budgetID");
                            //function bolean
                            cmd.ExecuteNonQuery();

                            //InsertUpdateData(cmd);

                            string script = "alert('File uploaded !! ');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                            // return;
                        }
                    }
                    //con.Close();

                }


            }
        }
        catch (Exception exr)
        {
            Response.Write(exr.Message);
        }
    }

    protected void ddlsubdept_SelectedIndexChanged(object sender, EventArgs e)
    {
        FindBudgetID();
        string sql;
        //string sql = "select excess_flag from jct_ops_budget_entry  where budgetID= '" + ddlsubdept.SelectedItem.Value + "' and excess_flag='Y'";
        //SqlCommand cmd = new SqlCommand(sql, con);
        //cmd.CommandType = CommandType.Text;
        ////con.Open();
        //SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        //if (dr.HasRows == true)
        //{
        //    Lnkapply.Enabled = false;
        //    string script2 = "alert('Budget Sanction Already Authorised  ');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        //}
        //else
        //{
            Lnkapply.Enabled = true;
            sql = "select budget_amt,balance_budget_amt,budgetID from jct_ops_budget_entry  where   status='A' and  budgetid='"+ ddlsubdept.SelectedItem.Value +"' and  Budget_type= '" + ddltype.SelectedItem.Text + "'";
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd2 = new SqlCommand(sql, con);
            cmd2.CommandType = CommandType.Text;
            //con.Open();
            SqlDataReader dr1 = cmd2.ExecuteReader();

            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                {
                    budamt = dr1[0].ToString();
                    balamt = dr1[1].ToString();
                    budgetno = dr1[2].ToString();
                    txtbudamt.Text = budamt;
                    txtbalamt.Text = balamt;
                    //ViewState["budgetID"] = budgetno;
                    txtbalamt.Enabled = false;
                    txtbudamt.Enabled = false;
                }
            }
            dr1.Close();
            con.Close();
        //}

    }

    protected void GenerateSanction(string SanctionID, SqlTransaction Tran,SqlConnection con)
    {


        Functions objFun = new Functions();
        //Connection obj = new Connection();
  
        string qry = null;

        SqlCommand cmd = new SqlCommand();
        //SqlConnection con = new SqlConnection();
       
    

        string EmpCode = null;
        EmpCode = Session["Empcode"].ToString();
 
        
        try
        {


            qry = " exec Jct_Ops_Excess_SanctionNote_Insert_HDR_Import '" + Session["Empcode"] + "',1048,'Excess Budget Sanction','Excess Budget Sanction','" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "','" + SanctionID + "','Cotton','No',''";
            objFun.InsertRecord(qry, Tran, con);

            qry = "Exec Jct_Ops_Excess_SanctionNote_Insert_Dtl '" + SanctionID + "','0','0'";
            objFun.InsertRecord(qry, Tran, con);
            

           
           // objFun.Alert("Record Saved Sucessfully !!");
            

        }
        catch (Exception ex)
        {
            throw ex;
            //Tran.Rollback();
            //objFun.Alert("Unable to Complete Transaction " + ex.Message.ToString());
            //return;
        }
        




    }
}
   


