using System;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            sql = "JCT_OPS_PLANNING_FREEZED_PLAN";
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
            pnlSummary.Visible = false;
            sql = "JCT_OPS_PLANNING_FREEZED_PLAN";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;
            cmd.Parameters.Add("@Mode", SqlDbType.VarChar,30).Value = ddlMode.SelectedItem.Text;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value =yearMonth();
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = txtSort.Text;
            cmd.Parameters.Add("@CustNo", SqlDbType.VarChar, 20).Value = txtCustomer.Text;
            cmd.Parameters.Add("@SalesPersonCode", SqlDbType.VarChar, 20).Value = ddlSalesPerson.SelectedItem.Value;
            cmd.Parameters.Add("@SalesTeam", SqlDbType.VarChar, 20).Value = ddlSalesTeam.SelectedItem.Text;
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            }
            else if (ddlShortfall.SelectedIndex == 1)
            {
                sql = "SELECT CONVERT(varchar,'" + txtStartDate.Text + "',103)";
                String dt1 = obj1.FetchValue(sql).ToString();
                sql = "SELECT CONVERT(varchar,'" + txtEndDate.Text + "',103)";
                String dt2 = obj1.FetchValue(sql).ToString();
                pnlDetail.Visible = true;
                sql = "JCT_OPS_SHORTFALL_REQUESTS_DETAIL";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 180;
                cmd.Parameters.Add("@DATEFROM", SqlDbType.DateTime).Value = Convert.ToDateTime(dt1).Date;
                cmd.Parameters.Add("@DATETO", SqlDbType.DateTime).Value = Convert.ToDateTime(dt2).Date;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
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
}