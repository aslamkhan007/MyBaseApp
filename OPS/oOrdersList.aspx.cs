using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_OrdersList : System.Web.UI.Page
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

        sql = "JCT_OPS_ORDER_PREVIEW";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar, 30).Value = txtDateFrom.Text;
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, 30).Value = txtDateTo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GrdOrders.DataSource = ds.Tables[0];
        GrdOrders.DataBind();

        //if (txtOrderNo.Text != "")
        //{
        //    sql = "Select ISNULL(dEPT,'NUL') AS DEPT from MISERP.SOM.DBO.JCT_SO_SALE_NOTE WHERE order_no= '" + txtOrderNo.Text + "'";
        //    string flag = obj1.FetchValue(sql).ToString();
        //    if (flag == "NUL")
        //    {
        //        string script1 = "alert('Not Mentioned By Marketing Person whether this order is for weaving or it is a ready..!! Please advice them to enter details in ramco first..!!');";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
        //    }
        //    else

        //    {

        //        sql="SELECT * FROM dbo.JCT_OPS_PLANNING_ORDER WHERE order_no='"+ txtOrderNo.Text +"' AND STATUS='A' ";
        //        if(obj1.CheckRecordExistInTransaction(sql))
        //        {
        //             string script1 = "alert('Order Already Freezed in Production Plan..!! For Modification Please Check Modify Plan Screen.!!!');";
        //             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);  
        //        }
                
              

        //        //sql = "Select yearmonth from JCT_OPS_MONTHLY_PLANNING WHERE Status is null and  ORDER_NO = '" + txtOrderNo.Text + "'";
        //        //if (obj1.CheckRecordExistInTransaction(sql))
        //        //{
        //        //    sql = "Select case when yearmonth =201301 then 'January' when yearmonth=201302 then 'Frebraury',isnull(mode,'nul') as mode from JCT_OPS_MONTHLY_PLANNING WHERE Status is null and  ORDER_NO = '" + txtOrderNo.Text + "'";
        //        //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //        //    SqlDataReader dr = cmd.ExecuteReader();
        //        //    if (dr.HasRows)
        //        //    {
        //        //        while (dr.Read())
        //        //        {
        //        //            if (dr[1].ToString() == "Freezed")
        //        //            {
        //        //                string script1 = "alert('Order Already Freezed in " + dr[0].ToString() + " Production Plan..!! For Modification Please Check Modify Plan Screen.!!!');";
        //        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
        //        //            }
        //        //            else
        //        //            {
        //        //                string script1 = "alert('Order is UnFreezed in "+ dr[0].ToString() + " Production Plan..!! To Freeze this order Please Check Final Plan Screen.!!!');";
        //        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
        //        //            }
                          
        //        //        }

        //        //    }
        //        //    dr.Close();

                
        //        else
        //        {
        //            pnlOrders.Visible = true;
        //            //sql = "JCT_OPS_FETCH_SaleOrders";
        //            //cmd = new SqlCommand(sql, obj.Connection());
        //            //cmd.CommandType = CommandType.StoredProcedure;
        //            //cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtDateFrom.Text;
        //            //cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtDateTo.Text;
        //            //cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        //            //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            //DataSet ds = new DataSet();
        //            //da.Fill(ds);

        //            sql = "JCT_OPS_FETCH_SaleOrders";
        //            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtDateFrom.Text;
        //            cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtDateTo.Text;
        //            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
        //            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
        //            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            chbOrderList.DataSource = ds.Tables[0];
        //            chbOrderList.DataBind();
        //            //chbOrderList.DataSourceID = "SqlDataSource1";
        //            //chbOrderList.DataBind();
        //        }
        //    }
        //}
        //else
        //{
        //    pnlOrders.Visible = true;
        //    sql = "JCT_OPS_FETCH_SaleOrders";
        //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtDateFrom.Text;
        //    cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtDateTo.Text;
        //    cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
        //    cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
        //    cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    chbOrderList.DataSource = ds.Tables[0];
        //    chbOrderList.DataBind();

        //    //chbOrderList.DataSourceID = "SqlDataSource1";
        //    //chbOrderList.DataBind();
        //}

    
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

    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_ORDER_PREVIEW_EXCEL";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar, 30).Value = txtDateFrom.Text;
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, 30).Value = txtDateTo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable dt = ds.Tables[0];


        string attachment = "attachment; filename=OrderList.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

        obj.ConClose();
    }
}