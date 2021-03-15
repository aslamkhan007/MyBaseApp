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

public partial class OPS_QuotationPanel1 : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;    
    string cust_code;
    String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SOMConnectionString"].ConnectionString;

    protected string Customer_Code()
    {
        if (txtCustomer.Text != "")
        {
            sql = " SELECT  REPLACE(SUBSTRING('"+ txtCustomer.Text +"',CHARINDEX('-','"+ txtCustomer.Text +"',0),1000),'~','')";
            cust_code=obj1.FetchValue(sql).ToString();
        }
        return cust_code;
    }

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
                FillCheckBox(ddlSalesTeam, ddlSalesPerson);
                // SetContextKey();

                FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);

            }

            if (Request.QueryString["OrderNo"] != "")
            {
                TextBox Orderno = new TextBox();
                txtOrderNo.Text = Request.QueryString["OrderNo"];
                FillGrids(txtCustomer, Orderno, ddlSalesTeam, ddlSalesPerson);
            }
        }
        catch (Exception ex)

        { 
        
        }
      
       
    }

    protected void FillGrids(TextBox customer,TextBox orderno,DropDownList SalesTeam, DropDownList SalesPerson)
    {
        Customer_Code();
        sql = "Exec jct_ops_indicative_quotes '"+ cust_code +"','"+ orderno.Text +"','"+ SalesTeam.SelectedItem.Text +"','"+ SalesPerson.SelectedItem.Value +"'";
        obj1.FillGrid(sql, ref grdIndicativeQuote);
        sql = "Exec jct_ops_Finalized_quotes '" + cust_code + "','" + orderno.Text + "','" + SalesTeam.SelectedItem.Text + "','" + SalesPerson.SelectedItem.Value + "'";
        obj1.FillGrid(sql, ref grdFinalizedQuote);
        sql = "Exec jct_ops_get_unauthorised_quotes";
        obj1.FillGrid(sql, ref grdHODAuth);
        sql = "Exec JCT_Ops_Lab_Dip_Details  '" + cust_code + "','" + orderno.Text + "','" + SalesTeam.SelectedItem.Text + "','" + SalesPerson.SelectedItem.Value + "'";
        obj1.FillGrid(sql, ref grdLabDip);
        //sql = "Exec jct_ops_sample_detail '" + cust_code + "','" + orderno.Text + "','" + SalesTeam.SelectedItem.Text + "','" + SalesPerson.SelectedItem.Value + "'";
sql = "Exec jct_ops_sample_detail '" + cust_code + "','" + orderno.Text + "','" + SalesTeam.SelectedItem.Text + "','" + SalesPerson.SelectedItem.Value + "' ,'" + Session["empcode"].ToString() + "'";
        SqlConnection conn = new SqlConnection(ConStr);
        SqlDataAdapter Da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        Da.Fill(dt);
        grdSample.DataSource = dt;
        grdSample.DataBind();

    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        if (txtCustomer.Text != "")
        {
            FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
        else
        {
            FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
    }
    protected void ddlSalesTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSalesTeam.SelectedItem.Text == "")
        {
            ddlSalesPerson.Items.Clear();
            sql = "Select '' as group_no, '' as group_desc Union SELECT group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
            obj1.FillList(ddlSalesPerson, sql);
            FillCheckBox(ddlSalesTeam, ddlSalesPerson);
            FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
        else
        {
            
            ddlSalesPerson.Items.Clear();
            sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
            obj1.FillList(ddlSalesPerson, sql);
            FillCheckBox(ddlSalesTeam, ddlSalesPerson);
        
 
            FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
        
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {

    }
    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
    }
    protected void ddlSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SetContextKey();
        FillCheckBox(ddlSalesTeam, ddlSalesPerson);
        FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
    }


    protected void grdIndicativeQuote_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int index = grdCustSearch.SelectedIndex + 1;
            GridViewRow row = grdIndicativeQuote.Rows[index];
            string quotation = row.Cells[1].Text;
            int rev_no =int.Parse(row.Cells[6].Text);
            sql = "update jct_ops_quotation_hdr set status='QuotClose', Deleted_Dt = getdate() where quotation_no='"+ quotation +"' and rev_no="+ rev_no +" ";
            obj1.UpdateRecord(sql);
            String script1 = "alert('Quotation Deleted Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
           // FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            Response.Redirect("QuotationPanel1.aspx");
        }
        else if (e.CommandName == "Auth")
        {
            int index = grdCustSearch.SelectedIndex + 1 ;
            //int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grdIndicativeQuote.Rows[index];
            string quotation = row.Cells[1].Text;
            int rev_no = int.Parse(row.Cells[6].Text);
            sql = "update jct_ops_quotation_hdr set status='QuotAuth',Auth_Dt= getdate(),Rev_Date=getdate() where quotation_no='" + quotation + "' and rev_no=" + rev_no + " ";
            obj1.UpdateRecord(sql);
            sql = "Insert into jct_ops_quote_status_log (username,Quotation_no,rev_No,Status,Action_date)values ('J-01945','"+ quotation +"',"+ rev_no +",'QuotAuth',getdate())";
            obj1.InsertRecord(sql);
            String script1 = "alert('Quotation Authorized.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
            //FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
            Response.Redirect("QuotationPanel1.aspx");
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        sql = "Select cust_no [Customer Code],cust_name as [Customer Name] from miserp.som.dbo.m_customer where cust_name like '%" + txtCustSearch.Text + "%'";
        obj1.FillGrid(sql, ref grdCustSearch);
    }
    protected void grdCustSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCustomer.Text = grdCustSearch.SelectedRow.Cells[1].Text;
    }
    protected void grdCustSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCustSearch.PageIndex = e.NewPageIndex;
        sql = "Select cust_no [Customer Code],cust_name as [Customer Name] from miserp.som.dbo.m_customer where cust_name like '%" + txtCustSearch.Text + "%'";
        obj1.FillGrid(sql, ref grdCustSearch);
        pnlSearch.Visible = false;
        grdCustSearch.DataSource = null;
        grdCustSearch.DataBind();
    }
    protected  void FillCheckBox(DropDownList SaleTeam,DropDownList SalePerson)
    {
        sql = "SELECT DISTINCT a.SaleOrder FROM    JCT_OPS_QUOTE_SALEORDER_MAPPING a INNER JOIN  miserp.som.dbo.jct_so_team_catg b  ON a.SaleOrder=b.order_no WHERE   a.Status = 'A'  AND (b.sale_person_code='" + SalePerson.SelectedItem.Value + "' or '" + SalePerson.SelectedItem.Value + "'='')  and ( b.team_code='" + SaleTeam.SelectedItem.Text   + "' or '" + SaleTeam.SelectedItem.Text + "'='' ) ";
        obj1.FillList(rblSaleOrder, sql);
    }

    //private void SetContextKey()
    //{
       
    //    //AjaxControlToolkit.AutoCompleteExtender modal1 = (AjaxControlToolkit.AutoCompleteExtender)txtOrderNo.FindControl("txtOrderNo_AutoCompleteExtender");
    //    if (ddlSalesPerson.SelectedItem.Text != "")
    //    {
    //        txtOrderNo_AutoCompleteExtender.ContextKey = ddlSalesPerson.SelectedItem.Value.ToString();
    //    }
    //    else if (ddlSalesTeam.SelectedItem.Text != "")
    //    {
    //        txtOrderNo_AutoCompleteExtender.ContextKey = ddlSalesTeam.SelectedItem.Value.ToString();
    //    }
    //    else
    //    {
    //        txtOrderNo_AutoCompleteExtender.ContextKey = "";
    //    }
        
    //}
    protected void rblSaleOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSaleOrder.SelectedItem.Selected == true)
        { 
          txtOrderNo.Text = rblSaleOrder.SelectedItem.Text;
          FillGrids(txtCustomer, txtOrderNo, ddlSalesTeam, ddlSalesPerson);
        }
      
    }


    protected void grdLabDip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdLabDip.PageIndex = e.NewPageIndex;
        sql = "Exec JCT_Ops_Lab_Dip_Details  '" + Customer_Code() + "','" + txtOrderNo.Text + "','" + ddlSalesTeam.SelectedItem.Text + "','" + ddlSalesPerson.SelectedItem.Value + "'";
        obj1.FillGrid(sql, ref grdLabDip);
    }
}