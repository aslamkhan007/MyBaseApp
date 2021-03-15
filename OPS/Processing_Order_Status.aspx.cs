using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_Processing_Order_Status : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    string cust_code;
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
                    sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
                    obj1.FillList(ddlSalesPerson, sql);
                }
                sql = "SELECT Customer,orderno,Item,LineItem,Blend,ReqQty,Planqty,Issuedmtrs,SalePerson FROM jct_ops_processing_schedule_orders ";
                obj1.FillGrid(sql, ref GridView1);
                sql = "SELECT Customer,orderno,Item,LineItem,Blend,ReqQty,Planqty,Issuedmtrs,SalePerson,Convert(varchar,ScheduleDt,106) as [ScheduleDt],DyeingQty,FinishedQty,Convert (varchar,FinishedOn,106) as [FinishedOn],Convert(varchar,DyedOn,106) as [DyedOn],OverDue,Convert(varchar,ExpectedDeilvery,106) as [ExpectedDeilvery] FROM  dbo.jct_ops_processing_overDueOrders";
                obj1.FillGrid(sql, ref GridView2);

               // FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);

            }

            if (Request.QueryString["OrderNo"] != "")
            {
                TextBox Orderno = new TextBox();
                txtOrderNo.Text = Request.QueryString["OrderNo"];
               // FillGrids(txtCustomer, Orderno, ddlSalesTeam, ddlSalesPerson);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected string Customer_Code()
    {
        if (txtCustomer.Text != "")
        {
            sql = " SELECT  REPLACE(SUBSTRING('" + txtCustomer.Text + "',CHARINDEX('-','" + txtCustomer.Text + "',0),1000),'~','')";
            cust_code = obj1.FetchValue(sql).ToString();
        }
        return cust_code;
    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        if (txtCustomer.Text != "")
        {
           // FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
        else
        {
            //FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
    }
    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
       // FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
    }
    protected void ddlSalesTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSalesTeam.SelectedItem.Text == "")
        {
            ddlSalesPerson.Items.Clear();
            sql = "Select '' as group_no, '' as group_desc Union SELECT group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
            obj1.FillList(ddlSalesPerson, sql);
        
          //  FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
        else
        {

            ddlSalesPerson.Items.Clear();
            sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
            obj1.FillList(ddlSalesPerson, sql);
        


           // FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
    }
    protected void ddlSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////SetContextKey();
        //FillCheckBox(ddlSalesTeam, ddlSalesPerson);
        //FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
    }

    protected void rblSaleOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSaleOrder.SelectedItem.Selected == true)
        {
            txtOrderNo.Text = rblSaleOrder.SelectedItem.Text;
            //FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }

    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        sql = "SELECT Customer,orderno,Item,LineItem,Blend,ReqQty,Planqty,Issuedmtrs,SalePerson FROM jct_ops_processing_schedule_orders ";
        obj1.FillGrid(sql, ref GridView1);
        sql = "SELECT Customer,orderno,Item,LineItem,Blend,ReqQty,Planqty,Issuedmtrs,SalePerson,Convert(varchar,ScheduleDt,106) as [ScheduleDt],DyeingQty,FinishedQty,Convert (varchar,FinishedOn,106) as [FinishedOn],Convert(varchar,DyedOn,106) as [DyedOn],OverDue,Convert(varchar,ExpectedDeilvery,106) as [ExpectedDeilvery] FROM  dbo.jct_ops_processing_overDueOrders";
        obj1.FillGrid(sql, ref GridView2);
    }
}