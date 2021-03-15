using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class OPS_PerformanceReview : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    string cust_code;
    String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SOMConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql = " Select '' as [team_code],'' as [team_description] Union  SELECT team_code,team_description FROM MISERP.SOM.DBO.jct_team_mASter  where team_code not in ('Wardrobe','Domestic','Sales Team') ORDER BY team_code   ";
            //sql = " Select '' as [team_code],'' as [team_description] Union Select group_no as [team_code], group_desc as [team_description] from miserp.som.dbo.jct_sales_person_view c";
            obj1.FillList(ddlSalesTeam, sql);
            if (ddlSalesTeam.SelectedItem.Text == "")
            {
                sql = "SELECT  '' as group_desc, '' as group_no Union Select group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE in ('SALESP')  AND status ='o'";
                obj1.FillList(ddlSalesPerson, sql);


            }
            else
            {
                ddlSalesPerson.Items.Clear();
                sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  left Outer JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type in ('SalesP') and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
                obj1.FillList(ddlSalesPerson, sql);
            }
            FillOrders_RadioButtonList(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            Performance_Review(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
    }

    protected void ddlSalesTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSalesTeam.SelectedItem.Text == "")
        {
            ddlSalesPerson.Items.Clear();
            //sql = "Select '' as group_no, '' as group_desc Union SELECT group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
            sql = " Select '' as [sale_person_code],'' as [group_desc] Union Select group_no as [group_desc], group_desc as [group_desc] from miserp.som.dbo.jct_sales_person_view ";
            obj1.FillList(ddlSalesPerson, sql);
            FillOrders_RadioButtonList(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            Performance_Review(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
          
        }
        else
        {
            ddlSalesPerson.Items.Clear();
            sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a Left Outer JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type in ('SalesP') and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
            obj1.FillList(ddlSalesPerson, sql);
            FillOrders_RadioButtonList(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            Performance_Review(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
    }

    protected string Customer_Code()
    {
        if (txtCustomer.Text != "")
        {
            sql = " SELECT  REPLACE(SUBSTRING('" + txtCustomer.Text + "',CHARINDEX('~','" + txtCustomer.Text + "',0),1000),'~','')";
            cust_code = obj1.FetchValue(sql).ToString();
        }
        return cust_code;
    }

    protected void Performance_Review(TextBox customer, TextBox orderno, DropDownList SalesTeam, DropDownList SalesPerson)
    {
        sql = "Exec jct_ops_get_Performance_Values  '" + Customer_Code() + "' ,'" + orderno.Text + "','" + SalesPerson.SelectedItem.Value + "' ,'" + SalesTeam.SelectedItem.Text + "' ";
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (dr.HasRows)
            {
            lblTotalSales.Text = dr[0].ToString();

            

               // lblTotalSales.Text = "Rs" + lblTotalSales;
                //lblMargin.Text = dr[2].ToString();
                sql = "Select  CONVERT(DECIMAL(5, 2), ROUND(" + dr[2] + ",2))";
                lblMargin.Text = obj1.FetchValue(sql).ToString();
                if (float.Parse(lblMargin.Text) > 0)
                {
                    lblMargin.ForeColor = Color.Green;
                }
                else
                {
                    lblMargin.ForeColor = Color.Red;
                }
               // lblAvgMarginYear.Text = dr[2].ToString();
                lblTotalSaleProfit.Text = dr[1].ToString();
                if (float.Parse(lblTotalSaleProfit.Text) > 0)
                {
                    lblTotalSaleProfit.ForeColor = Color.Green;
                }
                else
                {
                    lblTotalSaleProfit.ForeColor = Color.Red;
                }
            }
        }
        dr.Close();
    }

    protected void FillGrids(TextBox customer, TextBox orderno, DropDownList SalesTeam, DropDownList SalesPerson)
    {
        //Customer_Code();
        // sql = "Exec jct_ops_performance_review_jatin '" + customer.Text + "','" + txtOrderNo.Text + "','" + ddlSalesTeam.SelectedItem.Text + "','" + ddlSalesPerson.SelectedItem.Value + "','08/18/2012','08/18/2012'";
        //sql = "SELECT customer_code as [Customer_Name],orderno as [order_no],invoice_no,item_no as [Item_No],variant,quantity,CONVERT(VARCHAR,dispatch_date,106) AS [Dispatch_Date],quoted_cost,actual_cost,sales_price,quoted_margin,actual_margin FROM jct_ops_performance_review ";
        //sql = "SELECT DISTINCT customer_code as [Customer_Name],orderno as [order_no],item_no as [Item_No],invoice_no,variant,quantity,CONVERT(VARCHAR,dispatch_date,106) AS [Dispatch_Date],quoted_cost,actual_cost,sales_price,quoted_margin,actual_margin FROM jct_ops_performance_review where (sales_person_code='" + SalesPerson.SelectedItem.Value + "' or '" + SalesPerson.SelectedItem.Value + "'='') and (orderno='"+ orderno.Text +"' or '"+ orderno.Text +"'='') and (cust_code='"+ Customer_Code() +"' or '"+ Customer_Code() +"'='') and (orderno='"+ orderno.Text +"' or '"+ orderno.Text +"'='') and (team_code='"+ SalesTeam.SelectedItem.Text +"' or '"+ SalesTeam.SelectedItem.Text +"'='') ";
        sql = "Exec jct_ops_performance_review_Grid '"+ orderno.Text +"','"+ ddlSalesPerson.SelectedItem.Value +"','"+ Customer_Code() +"','"+ ddlSalesTeam.SelectedItem.Text +"' ";
        obj1.FillGrid(sql, ref grdPerformance);
        //SqlConnection conn = new SqlConnection(ConStr);
        //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //grdPerformance.DataSource = dt;
        //grdPerformance.DataBind();

    }

    protected void rblSaleOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSaleOrder.SelectedItem.Selected == true)
        {
            txtOrderNo.Text = rblSaleOrder.SelectedItem.Text;
            FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            Performance_Review(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }

    }

    protected void grdPerformance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPerformance.PageIndex = e.NewPageIndex;
        FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
    }

    protected void ddlSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillOrders_RadioButtonList(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        Performance_Review(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);

    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        Performance_Review(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
    }

    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        Performance_Review(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
    }

    protected void FillOrders_RadioButtonList(TextBox Customer,TextBox OrderNo,DropDownList SaleTeam, DropDownList SalePerson)
    {
        //sql = "Exec miserp.som.dbo.jct_ops_performance_review_Fetch_OrderNos '" + Customer_Code() + "','" + OrderNo.Text + "','" + ddlSalesTeam.SelectedItem.Text + "','" + ddlSalesPerson.SelectedItem.Text + "','08/18/2012','08/18/2012'";
        sql = "SELECT DISTINCT orderno FROM jct_ops_performance_review WHERE (sales_person_code='"+ ddlSalesPerson.SelectedItem.Value +"' or '"+ ddlSalesPerson.SelectedItem.Value +"'='') and (team_code='" + ddlSalesTeam.SelectedItem.Text +"' or '"+ ddlSalesTeam.SelectedItem.Text +"'='') ";
        obj1.FillList(rblSaleOrder, sql);

        //SqlConnection conn = new SqlConnection(ConStr);
        //SqlCommand command = new SqlCommand("jct_ops_performance_review_Fetch_OrderNos", conn);
        //command.CommandType = CommandType.StoredProcedure;
        //command.Parameters.Add("@CustomerCode", SqlDbType.VarChar, 10).Value = Customer_Code();
        //command.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
        //command.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 30).Value = SaleTeam.SelectedItem.Text;
        //command.Parameters.Add("@SalePerson", SqlDbType.VarChar, 50).Value = SalePerson.SelectedItem.Value;
        //command.Parameters.Add("@EffecFrom", SqlDbType.DateTime).Value = "08/18/2012";
        //command.Parameters.Add("@EffecTo", SqlDbType.DateTime).Value = "08/18/2012";
        ////command.Parameters.Add(new SqlParameter("@CustomerCode", SqlDbType.VarChar,10)).Value = Customer_Code();
        ////command.Parameters.Add(new SqlParameter("@OrderNo", SqlDbType.VarChar,20)).Value = OrderNo.Text;
        ////command.Parameters.Add(new SqlParameter("@SaleTeam", SqlDbType.VarChar,30)).Value = SaleTeam.SelectedItem.Text;
        ////command.Parameters.Add(new SqlParameter("@SalePerson", SqlDbType.VarChar,50)).Value = SalePerson.SelectedItem.Value;
        ////command.Parameters.Add(new SqlParameter("@EffecFrom", SqlDbType.DateTime)).Value = "08/18/2012";
        ////command.Parameters.Add(new SqlParameter("@EffecTo", SqlDbType.DateTime)).Value = "08/18/2012";
        //conn.Open();
        //rblSaleOrder.Items.Clear();
        //SqlDataAdapter da = new SqlDataAdapter(command);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //rblSaleOrder.DataSource = ds;
        //rblSaleOrder.DataBind();
    }
    protected void lnkToExcel_Click(object sender, EventArgs e)
    {
        sql = "Exec jct_ops_performance_review_Grid '" + txtOrderNo.Text + "','" + ddlSalesPerson.SelectedItem.Value + "','" + Customer_Code() + "','" + ddlSalesTeam.SelectedItem.Text + "' ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        CreateExcelFile(dt);
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("PeformanceReview.xlsx")));
        Response.AppendHeader("Content-Disposition", "attachment; filename=Detailed_Courier_Cost.xls");
        Response.TransmitFile(Server.MapPath("PeformanceReview.xlsx"));
        Response.End();
        obj.ConClose();
    }
    public bool CreateExcelFile(DataTable dt)
    {
        bool bFileCreated = false;
        string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>PeformanceReview</TH></TR>";
        string sTableEnd = "</TABLE></BODY></HTML>";
        string sTableData = "";
        int nRow = 0;
        int nCol;
        sTableData += "<TR>";
        for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
        {
            sTableData += "<TD><B>" + dt.Columns[nCol].ColumnName + "</B></TD>";
        }
        sTableData += "</TR>";
        for (nRow = 0; nRow <= dt.Rows.Count - 1; nRow++)
        {
            sTableData += "<TR>";
            for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
            {
                sTableData += "<TD>" + dt.Rows[nRow][nCol].ToString() + "</TD>";
            }
            sTableData += "</TR>";
        }
        string sTable = sTableStart + sTableData + sTableEnd;
        System.IO.StreamWriter oExcelWrite = null;
        string sExcelFile = Server.MapPath("PeformanceReview.xlsx");
        oExcelWrite = System.IO.File.CreateText(sExcelFile);
        oExcelWrite.WriteLine(sTable);
        oExcelWrite.Close();
        bFileCreated = true;
        return bFileCreated;

    }
}