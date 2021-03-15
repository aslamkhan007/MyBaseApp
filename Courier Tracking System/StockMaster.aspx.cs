using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_StockMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grdStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdStock.PageIndex = e.NewPageIndex;
        grdStock.DataSource = SqlDataSource1;
        grdStock.DataBind();
    }
    protected void lnkSave_Click(object sender, EventArgs e)
    {
        SqlDataSource1.InsertParameters["Shed"].DefaultValue = ddlShed.SelectedItem.Value;
        SqlDataSource1.InsertParameters["Weave"].DefaultValue = txtWeave.Text;
        SqlDataSource1.InsertParameters["Reed_Count"].DefaultValue = txtReedCount.Text;
        SqlDataSource1.InsertParameters["Size"].DefaultValue = txtReedSize.Text;
        SqlDataSource1.InsertParameters["Stock"].DefaultValue = txtStock.Text;
        SqlDataSource1.InsertParameters["type"].DefaultValue = ddlStock.SelectedItem.Text;
        SqlDataSource1.InsertParameters["Stock_ToBe_Use"].DefaultValue = txtStockTobeUse.Text;
        SqlDataSource1.Insert();
        String script = "alert('Record Saved.');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        txtReedCount.Text = "";
        txtReedSize.Text = "";
        txtStock.Text = "";
        txtStockTobeUse.Text = "";
        txtWeave.Text = "";
        ddlShed.Items.IndexOf(ddlShed.Items.FindByText("Select"));
    }
}