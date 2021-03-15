﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_MailContentPages_excessbudgetmail : System.Web.UI.Page
{


    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    bool color = false;

    SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);

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

                SqlCommand cmd = new SqlCommand("Select a.budgetID,c.empname,c.subdept_name as deptname,b.balance_budget_amt,b.budget_amt,a.excess_amt,a.indent_amt from jct_ops_excess_bdget_amt a join jct_ops_budget_entry b  on a.budgetID = b.budgetID join  jct_empmast_base c on b.hod=c.empcode  and c.subdept_code=b.dept_name  where  a.budgetID='" + lbbudgetid.Text + "'", obj.Connection());
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    lbIndentNo.Text = dr["indent_no"].ToString();
                    lbHod.Text = dr[1].ToString();
                    lbdept.Text = dr[2].ToString();
                    lbbalamt.Text = dr[3].ToString();
                    lbbudgetamt.Text = dr[4].ToString();
                    lbexcessamt.Text = dr[5].ToString();
                    lbindentamt.Text = dr[6].ToString();
                }
                dr.Close();

                sql = "select b.stock_no as [StockNo],a.stock_variant as [Stock Variant],b.short_description as [Short Desc],a.purchase_uom as [Uom],ROUND(CAST(a.required_qty_puom AS numeric(12,2)), 2)as[ReqQty], ROUND(CAST(a.total_value AS numeric(12,2)), 2) as[Tot Value],ROUND(CAST(a.unit_cost AS numeric(12,2)), 2) as [Unit cost],a.remarks as [Remarks] from miserp.pomdb.dbo.pur_indent_detail a join  miserp.common.dbo.ims_stock_master b  on a.stock_no=b.stock_no where  a.indent_no='" + indentno + "'";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
   
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

            }
            catch
            {
            }


        }
    }
}

            
                
            
        

            
           


               
    
