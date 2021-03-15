using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_MailContentPages_excessbudgetmail : System.Web.UI.Page
{


    //Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    bool color = false;

    //SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);
    //SqlConnection obj = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TestReportDBConnectionString"].ConnectionString);
    SqlConnection obj = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ReportDBConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
   {
        if (!IsPostBack)
        {
            try
            {
                string approvedby = Request.QueryString["EmpCode"].ToString();
                string indentno = Request.QueryString["indent_no"].ToString();
                sql = "Select empname from jct_empmast_base where empcode='" + approvedby + "'";
                lbempname.Text = obj1.FetchValue(sql).ToString();

                lbbudgetid.Text = Request.QueryString["budgetID"].ToString();
//                SqlCommand cmd = new SqlCommand("SELECT DISTINCT a.budgetID , c.empname AS HOD,c.subdept_name as deptname,b.balance_budget_amt ,b.budget_amt ,a.excess_amt ,a.indent_amt ,f.empname AS PendingAt,a.PO_UPR as indent_no FROM jct_ops_excess_bdget_amt a INNER JOIN jct_ops_budget_entry b ON a.budgetID = b.budgetID INNER JOIN misdev.jctdev.dbo.jct_empmast_base c ON b.hod = replace(c.empcode,'-','') INNER JOIN MISDEV.jctdev.dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING e ON e.userlevel = a.pending_at AND e.ID=a.budgetID INNER JOIN  misdev.jctdev.dbo.jct_empmast_base f ON e.empcode = REPLACE(f.empcode,'-','') WHERE a.Status='A' and b.Status='A'  and authflag='P' and a.PO_UPR='" + indentno + "' AND  a.budgetID='" + lbbudgetid.Text + "'", obj);

//                SqlCommand cmd = new SqlCommand("SELECT DISTINCT a.budgetID , c.empname AS HOD,c.subdept_name as deptname,b.balance_budget_amt ,b.budget_amt ,a.excess_amt ,a.indent_amt ,f.empname AS PendingAt,a.PO_UPR as indent_no FROM jct_ops_excess_bdget_amt a INNER JOIN jct_ops_budget_entry b ON a.budgetID = b.budgetID INNER JOIN misdev.jctdev.dbo.jct_empmast_base c ON b.hod = replace(c.empcode,'-','') INNER JOIN MISDEV.jctdev.dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING e ON e.userlevel = a.pending_at AND e.ID=a.budgetID INNER JOIN  misdev.jctdev.dbo.jct_empmast_base f ON e.empcode = f.empcode WHERE a.Status='A' and b.Status='A'  and authflag='P' and a.PO_UPR='" + indentno + "' AND  a.budgetID='" + lbbudgetid.Text + "'", obj);
SqlCommand cmd = new SqlCommand("SELECT DISTINCT a.budgetID ,c.empname AS HOD ,c.subdept_name AS deptname ,b.balance_budget_amt ,b.budget_amt ,a.excess_amt ,a.indent_amt ,f.empname AS PendingAt ,a.PO_UPR AS indent_no FROM    miserp.reportdb.dbo.jct_ops_excess_bdget_amt a INNER JOIN miserp.reportdb.dbo.jct_ops_budget_entry b ON a.budgetID = b.budgetID INNER JOIN misdev.jctdev.dbo.jct_empmast_base c ON b.hod = REPLACE(c.empcode,'-', '') INNER JOIN MISDEV.jctdev.dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING e ON e.userlevel = a.pending_at AND e.ID = a.PO_UPR AND e.STATUS IS NULL INNER JOIN misdev.jctdev.dbo.jct_empmast_base f ON e.empcode = f.empcode WHERE a.Status='A' and b.Status='A'  and authflag='P' and a.PO_UPR='" + indentno + "' AND  a.budgetID='" + lbbudgetid.Text + "'", obj);
                cmd.CommandType = CommandType.Text;
                obj.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    lbIndentNo.Text = dr["indent_no"].ToString().ToUpper();
                    lbHod.Text = dr[1].ToString();
                    lbdept.Text = dr[2].ToString();
                    lbbalamt.Text = dr[3].ToString();
                    lbbudgetamt.Text = dr[4].ToString();
                    lbexcessamt.Text = dr[5].ToString();
                    lbindentamt.Text = dr[6].ToString();
                    lbpending.Text = dr[7].ToString();
                }

                dr.Close();
                //obj.Close();

                sql = "select b.subdept_name from jct_ops_budget_entry a inner join misdev.jctdev.dbo.jct_empmast_base b on a.dept_name=b.subdept_code  where a.budgetid='" + indentno + "' and a.status='A'";
                cmd = new SqlCommand(sql, obj);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    lbdept.Text = dr["subdept_name"].ToString();
                }

                dr.Close();

                //sql = "select b.stock_no as [StockNo],a.stock_variant as [Stock Variant],b.short_description as [Short Desc],a.purchase_uom as [Uom],ROUND(CAST(a.required_qty_puom AS numeric(12,2)), 2)as[ReqQty], ROUND(CAST(a.total_value AS numeric(12,2)), 2) as[Tot Value],ROUND(CAST(a.unit_cost AS numeric(12,2)), 2) as [Unit cost],a.remarks as [Remarks] from miserp.pomdb.dbo.pur_indent_detail a join  miserp.common.dbo.ims_stock_master b  on a.stock_no=b.stock_no where  a.indent_no='" + indentno + "'";
                sql = "select b.stock_no as [StockNo],a.stock_variant as [Stock Variant],b.short_description as [Short Desc],a.purchase_uom as [Uom],ROUND(CAST(a.required_qty_puom AS numeric(12,2)), 2)as[ReqQty],a.remarks as [Remarks] from miserp.pomdb.dbo.pur_indent_detail a join  miserp.common.dbo.ims_stock_master b  on a.stock_no=b.stock_no where  a.indent_no='" + indentno + "'";
                cmd = new SqlCommand(sql, obj);
                cmd.CommandType = CommandType.Text;
                //obj.Open();

                cmd.ExecuteNonQuery();
                obj.Close();
   
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
                return;
            }


        }
    }
}

            
                
            
        

            
           


               
    
