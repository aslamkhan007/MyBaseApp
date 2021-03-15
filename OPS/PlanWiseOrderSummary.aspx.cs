using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

public partial class OPS_PlanWiseOrderSummary : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    double totalSizingDone=0.00;
    double totalGreighProd = 0.00;
    double totalSizingRemaining = 0.00;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radgrdOrderSummary.DataBind();    
            
        }
        
    }

    //protected void radgrdOrderSummary_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    //{
    //    radgrdOrderSummary.DataBind();
    //}
 
    protected void radgrdOrderSummary_ItemDataBound1(object sender, GridItemEventArgs e)
    {

        if (e.Item.OwnerTableView.DataSourceID == "SqlDataSource1")
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                double sumSizing = double.Parse(dataItem["SizingDone"].Text);
                totalSizingDone += sumSizing;
                double sumGreighProd = double.Parse(dataItem["GreighProd"].Text);
                totalGreighProd += sumGreighProd;

                double sumSizingRemaining = double.Parse(dataItem["SizingRemaining"].Text);
                totalSizingRemaining += sumSizingRemaining;
            }
            if (e.Item is GridFooterItem)
            {
                GridFooterItem footerItem = e.Item as GridFooterItem;
                footerItem["SizingDone"].Text = totalSizingDone.ToString();
                footerItem["GreighProd"].Text = totalGreighProd.ToString();
                footerItem["SizingRemaining"].Text = totalSizingRemaining.ToString();
            }
        }

        else if (e.Item.OwnerTableView.DataSourceID == "SqlDataSource2")
        {

        }

        //if (e.Item is GridGroupHeaderItem)
        //{
        //    GridGroupHeaderItem item = (GridGroupHeaderItem)e.Item;

        //    DataRowView groupDataRow = (DataRowView)e.Item.DataItem;

        //    item.DataCell.Text += "; Sizing: ";
        //    item.DataCell.Text += 0;//((System.Decimal)groupDataRow[]).ToString();

        //    item.DataCell.Text += "; Greigh Prod: ";
        //    item.DataCell.Text += 0;//((System.Decimal)groupDataRow["GreighProd"]).ToString();
        //}
    }
}