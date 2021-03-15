using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Threading;

public partial class OPS_FutureOrdersQuotations : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;    
    string cust_code;
    string script = "";
    String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SOMConnectionString"].ConnectionString;
     ScriptManager sm = new ScriptManager();
       
    //protected string Customer_Code()
    //{
    //    if (txtCustomer.Text != "")
    //    {
    //        sql = " SELECT  REPLACE(SUBSTRING('"+ txtCustomer.Text +"',CHARINDEX('-','"+ txtCustomer.Text +"',0),1000),'~','')";
    //        cust_code=obj1.FetchValue(sql).ToString();
    //    }
    //    return cust_code;
    //}

    protected void Page_Init(object sender, System.EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                
                sql = " Select '' as [team_code],'' as [team_description] Union  SELECT team_code,team_description FROM MISERP.SOM.DBO.jct_team_mASter where team_code not in ('Wardrobe','Domestic','Sales Team')  ORDER BY team_code   ";
                obj1.FillList(ddlSalesTeam, sql);
                if (ddlSalesTeam.SelectedItem.Text == "")
                {
                    sql = "SELECT  '' as group_desc, '' as group_no Union Select group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
                    obj1.FillList(ddlSalesPerson, sql);

                }
                else
                {
                    ddlSalesPerson.Items.Clear();
                    sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
                    obj1.FillList(ddlSalesPerson, sql);
                }
              
                // SetContextKey();

                //FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);

            }

            //if (Request.QueryString["OrderNo"] != "")
            //{
            //    TextBox Orderno = new TextBox();
            //    txtOrderNo.Text = Request.QueryString["OrderNo"];
            //    FillGrids(txtCustomer, Orderno, ddlSalesTeam, ddlSalesPerson);
            //}
            pnlAll.Visible = false;
           
        }
        catch (Exception ex)

        { 
        
        }
      
       
    }

    protected void FillGrids(TextBox customer,TextBox orderno,DropDownList SalesTeam, DropDownList SalesPerson)
    {
        
        pnlAll.Visible = true;
        sql = "JCT_OPS_ORDER_STATUS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar, 30).Value = txtOrderDateFrom.Text; 
        cmd.Parameters.Add("@ToDATE", SqlDbType.VarChar, 30).Value = txtOrderDateTo.Text;
        cmd.Parameters.Add("@DelFROM", SqlDbType.VarChar, 30).Value = txtDelDateFrom.Text;
        cmd.Parameters.Add("@DelTo", SqlDbType.VarChar, 30).Value = txtDelDateTo.Text;
        cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 30).Value = txtCustomer.Text;
        cmd.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 30).Value = ddlSalesTeam.SelectedItem.Text;
        cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 30).Value = ddlSalesPerson.SelectedItem.Text;
        cmd.Parameters.Add("@Order", SqlDbType.VarChar, 30).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@QuotationNo", SqlDbType.VarChar, 30).Value = txtQuotationNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdFutureOrders.DataSource = ds.Tables[0];
        grdFutureOrders.DataBind();

        //ds.Tables[0].Dispose();
        //sql = "JCT_OPS_ORDER_QUOTATION";
        //cmd = new SqlCommand(sql, obj.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 0;
        //cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 30).Value = "";
        //cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(0);
        //cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 30).Value = txtCustomer.Text;
        //cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 30).Value = ddlSalesPerson.SelectedItem.Text;
        //da = new SqlDataAdapter(cmd);
        //ds = new DataSet();
        //da.Fill(ds);
        //grdFinalizedQuote.DataSource = ds.Tables[0];
        //grdFinalizedQuote.DataBind();

    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtCustomer.Text != "")
            {
                pnlAll.Visible = true;
                txtCustomer.Text = txtCustomer.Text.Split('~')[1].ToString();
            }
        }

        catch { 
            
        }
       
    }

    protected void ddlSalesTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSalesTeam.SelectedItem.Text == "")
        {
            if (pnlAll.Visible == true)
            { 
             pnlAll.Visible = true;
                }
           
            ddlSalesPerson.Items.Clear();
            sql = "Select '' as group_no, '' as group_desc Union SELECT group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
            obj1.FillList(ddlSalesPerson, sql);
           
            //FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
        else
        {
            if (pnlAll.Visible == true)
            {
                pnlAll.Visible = true;
            }
            ddlSalesPerson.Items.Clear();
            sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
            obj1.FillList(ddlSalesPerson, sql);
           
        
 
            //FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
        
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {

        pnlAll.Visible = true;
        FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);

    }
    
    protected void ddlSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (pnlAll.Visible == true)
        {
            pnlAll.Visible = true;
        }
        //FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
    }


    protected void grdFutureOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pnlAll.Visible = true;
            pnlFutureOrders.Visible = true;
            string OrderNo = grdFutureOrders.SelectedRow.Cells[2].Text;
            string LineItem = grdFutureOrders.SelectedRow.Cells[5].Text;

            sql = "JCT_OPS_ORDER_QUOTATION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 30).Value = OrderNo;
            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem);
            cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 30).Value = txtCustomer.Text;
            cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 30).Value = ddlSalesPerson.SelectedItem.Text;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdFinalizedQuote.DataSource = ds.Tables[0];
            grdFinalizedQuote.DataBind();
                        
                
            }
           
        

         catch(Exception ex) {
            pnlFutureOrders.Visible = true;

            script = "alert('" + ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
       
    }


    protected void imgOrders_Click(object sender, ImageClickEventArgs e)
    {
        pnlAll.Visible = true;
        sql = "JCT_OPS_ORDER_STATUS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar, 30).Value = txtOrderDateFrom.Text;
        cmd.Parameters.Add("@ToDATE", SqlDbType.VarChar, 30).Value = txtOrderDateTo.Text;
        cmd.Parameters.Add("@DelFROM", SqlDbType.VarChar, 30).Value = txtDelDateFrom.Text;
        cmd.Parameters.Add("@DelTo", SqlDbType.VarChar, 30).Value = txtDelDateTo.Text;
        cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 30).Value = txtCustomer.Text;
        cmd.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 30).Value = ddlSalesTeam.SelectedItem.Text;
        cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 30).Value = ddlSalesPerson.SelectedItem.Text;
        cmd.Parameters.Add("@Order", SqlDbType.VarChar, 30).Value = txtOrderNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdFutureOrders.DataSource = ds.Tables[0];
        grdFutureOrders.DataBind();
    }


    protected void imgQuotations_Click(object sender, ImageClickEventArgs e)
    {
        pnlAll.Visible = true;
        sql = "JCT_OPS_ORDER_QUOTATION";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 30).Value = "";
        cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(0);
        cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 30).Value = txtCustomer.Text;
        cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 30).Value = ddlSalesPerson.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdFinalizedQuote.DataSource = ds.Tables[0];
        grdFinalizedQuote.DataBind();
    }


    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            GridViewExportUtil.Export("Order-QuotationList", grdFutureOrders);
            //sql = "JCT_OPS_ORDER_STATUS_Excel";
            //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandTimeout = 0;
            //cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar, 30).Value = txtOrderDateFrom.Text;
            //cmd.Parameters.Add("@ToDATE", SqlDbType.VarChar, 30).Value = txtOrderDateTo.Text;
            //cmd.Parameters.Add("@DelFROM", SqlDbType.VarChar, 30).Value = txtDelDateFrom.Text;
            //cmd.Parameters.Add("@DelTo", SqlDbType.VarChar, 30).Value = txtDelDateTo.Text;
            //cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 30).Value = txtCustomer.Text;
            //cmd.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 30).Value = ddlSalesTeam.SelectedItem.Text;
            //cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 30).Value = ddlSalesPerson.SelectedItem.Text;
            //cmd.Parameters.Add("@Order", SqlDbType.VarChar, 30).Value = txtOrderNo.Text;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //DataTable dt = ds.Tables[0];

            //string attachment = "attachment; filename=OrdersList.xls";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/vnd.ms-excel";
            //string tab = "";
            //foreach (DataColumn dc in dt.Columns)
            //{
            //    Response.Write(tab + dc.ColumnName);
            //    tab = "\t";
            //}
            //Response.Write("\n");
            //int i;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    tab = "";
            //    for (i = 0; i < dt.Columns.Count; i++)
            //    {
            //        Response.Write(tab + dr[i].ToString());
            //        tab = "\t";
            //    }
            //    Response.Write("\n");
            //}
            //Response.End();

            //obj.ConClose();
        }
        catch { 
            
        }
      
    }


    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            sql = "JCT_OPS_ORDER_QUOTATION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 30).Value = "";
            cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(0);
            cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 30).Value = txtCustomer.Text;
            cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 30).Value = ddlSalesPerson.SelectedItem.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            string attachment = "attachment; filename=QuotationsList.xls";
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
        catch { 
            
        }
       
    }


    protected void grdFinalizedQuote_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      

    }
    protected void lnlExcel_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_OPS_ORDER_STATUS_Excel";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar, 30).Value = txtOrderDateFrom.Text;
            cmd.Parameters.Add("@ToDATE", SqlDbType.VarChar, 30).Value = txtOrderDateTo.Text;
            cmd.Parameters.Add("@DelFROM", SqlDbType.VarChar, 30).Value = txtDelDateFrom.Text;
            cmd.Parameters.Add("@DelTo", SqlDbType.VarChar, 30).Value = txtDelDateTo.Text;
            cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 30).Value = txtCustomer.Text;
            cmd.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 30).Value = ddlSalesTeam.SelectedItem.Text;
            cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 30).Value = ddlSalesPerson.SelectedItem.Text;
            cmd.Parameters.Add("@Order", SqlDbType.VarChar, 30).Value = txtOrderNo.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            string attachment = "attachment; filename=OrdersList.xls";
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
        catch
        {

        }
      
    }
}