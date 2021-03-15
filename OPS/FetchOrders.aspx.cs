using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_FetchOrders : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected Decimal YearMonth()
    {
        String yearmonth = ddlYear.SelectedItem.Text + ddlMonth.SelectedItem.Value;
        Decimal ym = decimal.Parse(yearmonth);
        return ym;
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        if (txtOrderNo.Text != "")
        {
            sql = "Select ISNULL(dEPT,'NUL') AS DEPT from MISERP.SOM.DBO.JCT_SO_SALE_NOTE WHERE order_no= '" + txtOrderNo.Text + "'";
            string flag = obj1.FetchValue(sql).ToString();
            if (flag == "NUL")
            {
                string script1 = "alert('Not Mentioned By Marketing Person whether this order is for weaving or it is a ready..!! Please advice them to enter details in ramco first..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
            }
            else
            {


                sql = "Select yearmonth from JCT_OPS_MONTHLY_PLANNING WHERE Status is null and  ORDER_NO = '" + txtOrderNo.Text + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    string script1 = "alert('Order Already Planned in Previous Production Plan..!! For Modification Please Check Modify Plan Screen.!!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
                }
                else
                {
                    pnlOrders.Visible = true;
                    //sql = "JCT_OPS_FETCH_SaleOrders";
                    //cmd = new SqlCommand(sql, obj.Connection());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtDateFrom.Text;
                    //cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtDateTo.Text;
                    //cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds);
                    chbOrderList.DataSourceID = "SqlDataSource1";
                    chbOrderList.DataBind();
                }
            }
        }
        else
        {
            pnlOrders.Visible = true;
            chbOrderList.DataSourceID = "SqlDataSource1";
            chbOrderList.DataBind();
        }

    
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
           Connection obj3 = new Connection();
        for (int i = 0; i <= chbOrderList.Items.Count - 1; i++)
        {
            if (chbOrderList.Items[i].Selected == true)
            {
                sql = "JCT_OPS_TEMP_SALEORDER_PROC";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = chbOrderList.Items[i].Text;
                cmd.ExecuteNonQuery();
            }
          
        }
        
       
        sql = "JCT_OPS_FETCH_SALEORDER_IN_PLANNING_Version1";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.ExecuteNonQuery();
        sql = " SELECT * FROM FebPlan";
        cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();

        try
        {

            if ((dr.HasRows))
            {

                while ((dr.Read()))
                {
                    sql = "jct_ops_sales_team_budget_entry";
                    SqlCommand sqlcmd = new SqlCommand(sql, obj3.Connection());
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandTimeout = 500;
                    sqlcmd.Parameters.Add("@action", SqlDbType.VarChar, 20).Value = "Add";
                    sqlcmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value = Convert.ToDecimal(YearMonth());
                    sqlcmd.Parameters.Add("@Orderno", SqlDbType.VarChar, 20).Value = dr["order_no"].ToString();
                    sqlcmd.Parameters.Add("@Orderdt", SqlDbType.DateTime).Value = Convert.ToDateTime(dr["order_dt"].ToString());
                    sqlcmd.Parameters.Add("@amendno", SqlDbType.Int).Value = dr["amend_no"].ToString();
                    sqlcmd.Parameters.Add("@serialno", SqlDbType.Int).Value = dr["order_srl_no"].ToString();
                    sqlcmd.Parameters.Add("@item_code", SqlDbType.VarChar, 20).Value = dr["item_no"].ToString();
                    sqlcmd.Parameters.Add("@variant", SqlDbType.VarChar, 20).Value = dr["variant"].ToString();
                    sqlcmd.Parameters.Add("@blend", SqlDbType.VarChar, 20).Value = dr["blend"].ToString();
                    sqlcmd.Parameters.Add("@req_date", SqlDbType.DateTime).Value = Convert.ToDateTime(dr["req_dt"].ToString());
                    sqlcmd.Parameters.Add("@order_qty", SqlDbType.Decimal).Value = Convert.ToDecimal(dr["req_qty"].ToString());
                    sqlcmd.Parameters.Add("@sel_qty", SqlDbType.Decimal).Value = Convert.ToDecimal(dr["sel_qty"].ToString());
                    sqlcmd.Parameters.Add("@userid", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                    sqlcmd.Parameters.Add("@company_code", SqlDbType.VarChar, 20).Value = "JCT00LTD";
                    sqlcmd.ExecuteNonQuery();
                    obj3.ConClose();
                }
            }
            chbOrderList.DataSource = null;
            chbOrderList.DataBind();
            pnlOrders.Visible = false;
            string script1 = "alert('Orders added in the plan..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);

        }
        catch (Exception ex)
        {
            string script1 = "alert('Error Occured -  " + ex.Message + " ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);

        }
    }
    protected void chbOrderList_SelectedIndexChanged(object sender, EventArgs e)
    {
            pnlItems.Visible = true;
           
            chbItems.DataSourceID = "SqlDataSource2";
            chbItems.DataBind();
            if (chbItems.Items.Count > 0)
            { 

              for (int i = 0; i <= chbItems.Items.Count - 1; i++)
            {
                chbItems.Items[i].Selected = true;
            }
            }
    }
    protected void chbOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chbOption.Items[0].Selected ==true && chbOption.Items[1].Selected==true)
        {
            pnlOrders.Visible = true;
            pnlItems.Visible = true;
        }
        else if (chbOption.Items[0].Selected == true && chbOption.Items[1].Selected == false)
        {
            pnlItems.Visible = false;

        }
        else if (chbOption.Items[0].Selected == false && chbOption.Items[1].Selected == false)
        {
            pnlOrders.Visible = false;
            pnlItems.Visible = false;
        }
    }
}