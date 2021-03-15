using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;

public partial class OPS_PartyBankDetail : System.Web.UI.Page
{
    public BankParty cc;
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["productionConnectionString1"].ConnectionString;
    string result;
    public string sKey;
    public string strhost;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        cc = new BankParty(jctdevConnectionString);
       
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
       
        if (!IsPostBack)
        {
            strhost = Request.UserHostAddress;
            txtPartyCode.Focus();
            DateTime d1 = DateTime.Now;
            d1 = d1.AddDays(-1);
        //  message.Text = strhost;
            txt_receiptDate.Text = d1.ToShortDateString();
            lnkModify.Enabled = false;
        }
        DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        strhost = Request.UserHostAddress;
        cc.customer = txtPartyCode.Text;
        cc.segment = txtSegment.Text;
        cc.bankcode = txtBank.Text;
        cc.collectiontype = txtCashtype.Text;
        cc.receiptdate = txt_receiptDate.Text;
        cc.entrydate = System.DateTime.Now;   
        cc.amount =Convert.ToDouble(txtamount.Text);
        cc.ModifyDate = "NULL";
        cc.StrHost = strhost;
        result = cc.ExecuteAdd(strhost);
        message.Text = result;
        txtPartyCode.Focus();
        BindDataafterAddition();
     }
    private void DataBind()
    {
        grdView.DataSource = null;

        ds = cc.BindData();
        grdView.DataSource = ds;
        grdView.DataBind();
       
    }
    private void BindDataafterAddition()
    {
        grdView.DataSource = null;

        ds = cc.BindDataafterAddition();
        grdView.DataSource = ds;
        grdView.DataBind();

    }
    protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkModify.Enabled = true;
        lnkSave.Enabled = false;
        message.Text = "";
        GridViewRow row = grdView.SelectedRow;
      //  sKey = grdView.SelectedDataKey.Value.ToString();
        // txt_efffrom.Text = row.Cells[6].Text;
        sKey = row.Cells[1].Text;
        txtPartyCode.Text = row.Cells[2].Text;
        txtSegment.Text = row.Cells[3].Text;
        txtBank.Text = row.Cells[4].Text;
        txtCashtype.Text = row.Cells[5].Text;
        txt_receiptDate.Text = row.Cells[6].Text;
        txtamount.Text = row.Cells[8].Text;
    }
    protected void lnkModify_Click(object sender, EventArgs e)
    {
        GridViewRow row = grdView.SelectedRow;
        sKey = grdView.SelectedDataKey.Value.ToString();
        // txt_efffrom.Text = row.Cells[6].Text;
        //sKey = row.Cells[1].Text;
        cc.customer = txtPartyCode.Text;
        cc.segment = txtSegment.Text;
        cc.bankcode = txtBank.Text;
        cc.collectiontype = txtCashtype.Text;
        cc.receiptdate = txt_receiptDate.Text;
        cc.entrydate = System.DateTime.Now;
        cc.amount = Convert.ToDouble(txtamount.Text);
      
        result=cc.ExecuteModify(sKey);
        message.Text = result;
        txtPartyCode.Focus();
        BindDataafterAddition();
        
    }
    protected void lnkRefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/PartyBankDetail.aspx");
    }
    protected void lnkReport_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/OPS/PartyBankReport.aspx");
    }
}