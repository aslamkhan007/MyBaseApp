﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_PlanningProgram : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    GridViewExportUtil ex = new GridViewExportUtil();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlPlanID.DataSource = SqlDataSource1;
            ddlPlanID.DataBind();
            sql = "Select planid from JCT_OPS_PLANNING_GENERATE_PLANID where Activated='Y' and Plant='"+ ddlPlant.SelectedItem.Text +"'";
            ddlPlanID.SelectedIndex = ddlPlanID.Items.IndexOf(ddlPlanID.Items.FindByValue(obj1.FetchValue(sql).ToString()));

            sql = " Select '' as [team_code],'' as [team_description] Union  SELECT team_code,team_description FROM MISERP.SOM.DBO.jct_team_mASter where team_code not in ('Wardrobe','Domestic','Sales Team')  ORDER BY team_code   ";
            obj1.FillList(ddlSalesTeam, sql);

            sql = "Select '' as PARAMETER_CODE,'' as PARAMETER union SELECT PARAMETER_CODE,PARAMETER FROM dbo.jct_ops_multi_master WHERE PARENT_CATEGORY='ShedDays' AND Status='A'";
            obj1.FillList(ddlShed, sql);
            if (ddlSalesTeam.SelectedItem.Text == "")
            {
                sql = "SELECT  '' as group_desc, '' as group_no Union Select group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
                obj1.FillList(ddlSalesPerson, sql);

            }
            else
            {
                ddlSalesPerson.Items.Clear();
                sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
                obj1.FillList(ddlSalesPerson, sql);
            }
          

        }
    }

    protected int yearMonth()
    {
        string mon;
        sql = "Select month('" + txtStartDate.Text + "')";
        mon = obj1.FetchValue(sql).ToString();
        int mon1 = int.Parse(mon);
        if (mon1 < 10)
        {
            mon = "0" + mon;
        }
        sql = "Select year('" + txtEndDate.Text + "')";
        String year = obj1.FetchValue(sql).ToString();
        String yearmonth = year + mon;
        int year_month = int.Parse(yearmonth);
        return year_month;
    }

    protected void rblOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblOption.SelectedIndex == 1)
        {
            pnlSummary.Visible = true;
            pnlDetail.Visible = false;
            sql = "JCT_OPS_PLANNING_ORDERS_SUMMARY";
            SqlCommand cmd = new SqlCommand(sql,obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
          
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblOrder.Text = dr["TotalOrders"].ToString();
                    lblItem.Text = dr["TotalItems"].ToString();
                    lblProfit.Text = dr["Margin"].ToString();
                }
            }
            dr.Close();
        }
        else if (rblOption.SelectedIndex==0)
        {
            pnlDetail.Visible = true;
            pnlSummary.Visible = false;
            pnlSubTotal.Visible = false;
            sql = "JCT_OPS_PLANNING_FREEZED_PLAN_NewPlan";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = ddlMode.SelectedItem.Text;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value = yearMonth();
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = txtSort.Text;
            cmd.Parameters.Add("@Cust_No", SqlDbType.VarChar, 20).Value = txtCustomer.Text;
            cmd.Parameters.Add("@SalesPersonCode", SqlDbType.VarChar, 20).Value = ddlSalesPerson.SelectedItem.Value;
            cmd.Parameters.Add("@SalesTeam", SqlDbType.VarChar, 20).Value = ddlSalesTeam.SelectedItem.Text;
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Value;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
        }
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        
        try
        {
            if (ddlShortfall.SelectedIndex == 0)
            { 
            pnlDetail.Visible = true;
            pnlSubTotal.Visible = false;
            pnlSummary.Visible = false;
            sql = "JCT_OPS_PLANNING_FREEZED_PLAN_NewPlan";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;
            cmd.Parameters.Add("@Mode", SqlDbType.VarChar,30).Value = ddlMode.SelectedItem.Text;
            // cmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value =yearMonth();
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = txtSort.Text;
            cmd.Parameters.Add("@CustNo", SqlDbType.VarChar, 20).Value = txtCustomer.Text;
            cmd.Parameters.Add("@SalesPersonCode", SqlDbType.VarChar, 20).Value = ddlSalesPerson.SelectedItem.Value;
            cmd.Parameters.Add("@SalesTeam", SqlDbType.VarChar, 20).Value = ddlSalesTeam.SelectedItem.Text;
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Value;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            }
            else if (ddlShortfall.SelectedIndex == 1)
            {

                pnlDetail.Visible = true;
                pnlSubTotal.Visible = true;
                sql = "JCT_OPS_SHORTFALL_REQUESTS_DETAIL";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 180;
                cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 20).Value = txtStartDate.Text;
                cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 20).Value = txtEndDate.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                sql = "JCT_OPS_SHORTFALL_REQUESTS_SUMMARY";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 180;
                cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 20).Value = txtStartDate.Text;
                cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 20).Value = txtEndDate.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblGreigh.Text = dr[0].ToString();
                        lblSizing.Text = dr[1].ToString();
                        Orders.Text = dr[2].ToString();
                    }
                }
                
                }
        }

        catch (Exception ex)
        {
            string script;
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            
        }

    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
      
        if (txtCustomer.Text != "")
        {
         
            txtCustomer.Text = txtCustomer.Text.Split('~')[1].ToString();
        }
        else
        {
           
        }


    }

    protected void ddlSalesTeam_SelectedIndexChanged(object sender, EventArgs e)
    { 
        if (ddlSalesTeam.SelectedItem.Text == "")
        {
            ddlSalesPerson.Items.Clear();
            sql = "Select '' as group_no, '' as group_desc Union SELECT group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
            obj1.FillList(ddlSalesPerson, sql);
        }
        else
        {

            ddlSalesPerson.Items.Clear();
            sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
            obj1.FillList(ddlSalesPerson, sql);
        }

  
    }

    protected void lnkExcel_Click(object sender, EventArgs e)
    {

        sql = "JCT_OPS_PLANNING_FREEZED_PLAN_NewPlan";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = ddlMode.SelectedItem.Text;
        //cmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value = yearMonth();
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = txtSort.Text;
        cmd.Parameters.Add("@CustNo", SqlDbType.VarChar, 20).Value = txtCustomer.Text;
        cmd.Parameters.Add("@SalesPersonCode", SqlDbType.VarChar, 20).Value = ddlSalesPerson.SelectedItem.Value;
        cmd.Parameters.Add("@SalesTeam", SqlDbType.VarChar, 20).Value = ddlSalesTeam.SelectedItem.Text;
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Value;
        cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        
        DataTable dt = ds.Tables[0];


        string attachment = "attachment; filename=Freezed_ProductionPlan.xls";
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string order_no = e.Row.Cells[3].Text;

            string lastTwoChars = order_no.Substring(order_no.Length - 2);
            if (lastTwoChars == "/S")
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
                e.Row.BackColor = System.Drawing.Color.Red;

            }
          
        }
    }
    protected void ddlPlant_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPlanID.DataSource = SqlDataSource1;
        ddlPlanID.DataBind();
        sql = "Select planid from JCT_OPS_PLANNING_GENERATE_PLANID where Activated='Y' and Plant='" + ddlPlant.SelectedItem.Text + "'";
        ddlPlanID.SelectedIndex = ddlPlanID.Items.IndexOf(ddlPlanID.Items.FindByValue(obj1.FetchValue(sql).ToString()));
    }
}