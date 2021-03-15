using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;

public partial class Courier_Tracking_System_CODCashCollection : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hdfCarrierName.Value = "";
            radgrdCheckDetail.DataSource = null;
            radgrdCheckDetail.DataBind();
        }
    }

    protected void radbtnFetch_Click(object sender, EventArgs e)
    {
        sql = "JCT_COURIER_COD_CASH_COLLECTION_SELECT";

        SqlCommand cmd = new SqlCommand(sql, obj.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@AWBNO", SqlDbType.VarChar, 50).Value = radAwbNo.Text;
        cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 30).Value = Convert.ToString(radDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateFrom.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 50).Value = Convert.ToString(radDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateTo.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@CARRIER", SqlDbType.VarChar, 500).Value = RadComboBox1.SelectedItem.Text;

        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();

        da.Fill(ds);

        radgrdCheckDetail.DataSource = ds.Tables[0];
        radgrdCheckDetail.DataBind();
    }

    protected void radbtnSave_Click(object sender, EventArgs e)
    {
        string script = "";
        try
        {
            foreach (GridDataItem item in radgrdCheckDetail.Items)
            {

                CheckBox chb = (CheckBox)item.FindControl("chbSelect");

                if (chb.Checked && chb.Enabled == true)
                {

                    string AWBNo = item["AWBNo"].Text;
                    string Carrier = item["Carrier"].Text;
                    string date = item["date"].Text;
                    string invoiceno = item["InvoiceNo"].Text;

                    RadTextBox ChequeNo = (RadTextBox)item.FindControl("radtxtChequeNo");
                    RadTextBox ChequeAmt = (RadTextBox)item.FindControl("radtxtChequeAmount");
                    RadDatePicker ChequeDate = (RadDatePicker)item.FindControl("raddtpckrChequeDate");

                    sql = "JCT_COURIER_COD_CASH_COLLECTION_INSERT";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 30).Value = invoiceno;
                    cmd.Parameters.Add("@AWBNO", SqlDbType.VarChar, 30).Value = AWBNo;
                    cmd.Parameters.Add("@CHECKNO", SqlDbType.VarChar, 30).Value = ChequeNo.Text;
                    cmd.Parameters.Add("@CHECKAMT", SqlDbType.Float).Value = Convert.ToDecimal(ChequeAmt.Text);
                    cmd.Parameters.Add("@CHECKDATE", SqlDbType.VarChar, 30).Value = Convert.ToDateTime(ChequeDate.SelectedDate).ToShortDateString();
                    cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                    cmd.Parameters.Add("@CARRIER", SqlDbType.VarChar, 500).Value = Carrier;
                    cmd.Parameters.Add("@DATE", SqlDbType.VarChar, 30).Value = date;
                    cmd.ExecuteNonQuery();

                    //CheckNo.Enabled = false;
                    //CheckDate.Enabled = false;
                    //CheckAmt.Enabled = false;
                    //chb.Enabled = false;

                }
                else
                {
                      script = "alert('Please select a record..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }

            }

              script = "alert('Record Submitted Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }

        catch(Exception ex)
        {
              script = "alert('Some error occured..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void radgrdCheckDetail_ItemDataBound(object sender, GridItemEventArgs e)
    { 
            //if (e.Item is GridDataItem)
            //{
            //    string AWBNo = e.Item.Cells[4].Text;

            //    HyperLink Add = (HyperLink)e.Item.FindControl("hlkAddMoreChecks");
            //    RadTextBox CheckNo = (RadTextBox)e.Item.FindControl("radtxtCheckNo");
            //    RadTextBox CheckAmt = (RadTextBox)e.Item.FindControl("radtxtCheckAmount");
            //    RadDatePicker CheckDate = (RadDatePicker)e.Item.FindControl("raddtpckrCheckDate");
            //    CheckBox chbSelect = (CheckBox)e.Item.FindControl("chbSelect");

            //    sql = "SELECT * FROM dbo.JCT_COURIER_COD_CASH_COLLECTION WHERE Status='A' and  AWBNo='" + AWBNo + "'";

            //    if (obj1.CheckRecordExistInTransaction(sql))
            //    {
            //        //e.Item.Enabled = false;
            //        Add.Enabled = true;
            //        CheckNo.Enabled = false;
            //        CheckAmt.Enabled = false;
            //        CheckDate.Enabled = false;
            //        chbSelect.Enabled = false;


            //    }
            //}
 
    }


    protected void RadComboBox1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        hdfCarrierName.Value = RadComboBox1.SelectedItem.Text;
    }

    protected void radgrdCheckDetail_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!IsPostBack)
        {
            radgrdCheckDetail.DataSource = null;
            //radgrdCheckDetail.DataBind();
        }

        else
        { 
          sql = "JCT_COURIER_COD_CASH_COLLECTION_SELECT";

        SqlCommand cmd = new SqlCommand(sql, obj.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@AWBNO", SqlDbType.VarChar, 50).Value = radAwbNo.Text;
        cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 30).Value = Convert.ToString(radDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateFrom.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@DATETO", SqlDbType.VarChar, 50).Value = Convert.ToString(radDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateTo.SelectedDate).ToShortDateString());
        cmd.Parameters.Add("@CARRIER", SqlDbType.VarChar, 500).Value = hdfCarrierName.Value;

        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();

        da.Fill(ds);

        radgrdCheckDetail.DataSource = ds.Tables[0];
        }
      
    }
    protected void radgrdCheckDetail_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {

        int index = e.NewPageIndex;
        int current = radgrdCheckDetail.CurrentPageIndex;

    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            radgrdCheckDetail.MasterTableView.SortExpressions.Clear();
            radgrdCheckDetail.MasterTableView.GroupByExpressions.Clear();
            radgrdCheckDetail.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            radgrdCheckDetail.MasterTableView.SortExpressions.Clear();
            radgrdCheckDetail.MasterTableView.GroupByExpressions.Clear();
            radgrdCheckDetail.MasterTableView.CurrentPageIndex = radgrdCheckDetail.MasterTableView.PageCount - 1;
            radgrdCheckDetail.Rebind();
        }
    }
    protected void radgrdCheckDetail_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (!IsPostBack)
        {
            radgrdCheckDetail.DataSource = null;
            radgrdCheckDetail.DataBind();
        }

        else
        {

            if (e.Item is GridDataItem)
            {
                //HyperLink editLink = (HyperLink)e.Item.FindControl("hlkEdit");
                //editLink.Attributes["href"] = "javascript:void(0)";
                //editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AWBNo"], e.Item.ItemIndex);

                HyperLink AddMoreChecksLink = (HyperLink)e.Item.FindControl("hlkAddMoreCheques");
                AddMoreChecksLink.Attributes["href"] = "javascript:void(0);";
                AddMoreChecksLink.Attributes["onclick"] = String.Format("return ShowInsertForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AWBNo"], e.Item.ItemIndex);
             }

        }
      
    }
    protected void radbtnMail_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "PopUp", "PopUp();", true);
    }
}