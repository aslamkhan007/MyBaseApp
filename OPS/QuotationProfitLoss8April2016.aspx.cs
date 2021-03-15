using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Text;

public partial class OPS_QuotationProfitLoss : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    double MarginPerc=0.00;
    double SumQuantity = 0.00;
    double WeightedAverage = 0.00;
    double SumTheoreticalMargin = 0.00;
    List<String> SaleTeam = new List<String>();
    List<String> SalePerson = new List<String>();
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void radFetch_Click(object sender, EventArgs e)
    {
      SaleTeam=  ShowCheckedItems(radSaleTeam,SaleTeam);
      SalePerson= ShowCheckedItems(radSalePerson, SalePerson);
      BindGrid();
       
    }

    public List<String>  ShowCheckedItems(RadComboBox comboBox,List<String> Items)
    {
       
        var collection = comboBox.CheckedItems;

        if (collection.Count != 0)
        {
            foreach (var item in collection)
            {
                Items.Add(item.Value);
            }
        }
        else
        {
            Items.Add("");
        }
        return Items;
    }

    
 
    protected void BindGrid()
    {
        //sql = "JCT_OPS_QUOTATION_PPL_REPORT";
        sql = "JCT_OPS_QUOTATION_PPL_REPORT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@QuotDateFrom", SqlDbType.VarChar, 30).Value = Convert.ToString(radQuotDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radQuotDateFrom.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@QuotDateTo", SqlDbType.VarChar, 30).Value = Convert.ToString(radQuotDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radQuotDateTo.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@QuotationNo", SqlDbType.VarChar, 30).Value = radQuotationNo.Text;
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 30).Value = radQuotationStatus.SelectedItem.Value;
        cmd.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 500).Value = string.Join(",", SaleTeam.ToArray());
        cmd.Parameters.Add("@SalePersonCode", SqlDbType.VarChar, 500).Value = string.Join(",", SalePerson.ToArray());
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = radtxtOrderNo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = radDDLPlant.SelectedItem.Text;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        RadGrid1.DataSource = ds.Tables[0];
        RadGrid1.DataBind();   
    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

       // sql = "JCT_OPS_QUOTATION_PPL_REPORT";
        sql = "JCT_OPS_QUOTATION_PPL_REPORT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@QuotDateFrom", SqlDbType.VarChar, 30).Value = Convert.ToString(radQuotDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radQuotDateFrom.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@QuotDateTo", SqlDbType.VarChar, 30).Value = Convert.ToString(radQuotDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radQuotDateTo.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@QuotationNo", SqlDbType.VarChar, 30).Value = radQuotationNo.Text;
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 30).Value = radQuotationStatus.SelectedItem.Text;
        cmd.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 500).Value = string.Join(",", SaleTeam.ToArray());
        cmd.Parameters.Add("@SalePersonCode", SqlDbType.VarChar, 500).Value = string.Join(",", SalePerson.ToArray());
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = radtxtOrderNo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = radDDLPlant.SelectedItem.Text;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        RadGrid1.DataSource = ds.Tables[0];
    }

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item.OwnerTableView.DataMember == "Master")
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataitem = e.Item as GridDataItem;
                double SumMrginPerc = double.Parse(dataitem["MarginPerc"].Text) * double.Parse(dataitem["Quantity"].Text);
                double SumQty = double.Parse(dataitem["Quantity"].Text);
                MarginPerc += SumMrginPerc;
                SumQuantity += SumQty;

                double TheoreticalMargin =double.Parse(dataitem["ThereticalMargin"].Text)*double.Parse(dataitem["Quantity"].Text);
                SumTheoreticalMargin += TheoreticalMargin;
            }

            if (e.Item is GridGroupFooterItem)
            {

                GridGroupFooterItem item = e.Item as GridGroupFooterItem;
               
                item["MarginPerc"].Text = "WeightedAvg. : " + Math.Round((MarginPerc / SumQuantity), 2).ToString();
                item["ThereticalMargin"].Text = "WeightedAvg : " + Math.Round((SumTheoreticalMargin / SumQuantity), 2).ToString();
                item.Visible = true;
                MarginPerc = 0;
                SumQuantity = 0;
            }
            

            if (e.Item is GridFooterItem)
            {
                GridFooterItem footeritem = e.Item as GridFooterItem;
                footeritem["MarginPerc"].Text = "WeightedAvg. : " +  Math.Round((MarginPerc / SumQuantity),2).ToString();
                footeritem["ThereticalMargin"].Text = "WeightedAvg. : " + Math.Round((SumTheoreticalMargin / SumQuantity), 2).ToString();
                //footeritem["DnvCost"].Text = Math.Round(Convert.ToDecimal(footeritem["DnvCost"].Text), 2).ToString();
            }

            
            
        }

    
        else if (e.Item.OwnerTableView.DataSourceID == "SqlDataSource2")
        {
               
        }
    }
    
    protected void radSaleTeam_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
       // radSalePerson.DataBind();
    }
    protected void radReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/QuotationProfitLoss.aspx");
    }
     
    protected void radExcel_Click1(object sender, EventArgs e)
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;
        RadGrid1.MasterTableView.ExportToExcel();
    }
}