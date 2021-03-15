using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_Dispatched_Courier : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    float Sum = 0;
    float Total;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlSubpartytype.Items.Clear();
            if (ddlPartyType.SelectedItem.Text == "Sales Office")
            {
                sql = "SELECT 'All' as PartyCode , 'All' AS Description UNION SELECT PartyCode,Description  from jct_courier_other_address where SaleOffice='Y' and status='A'";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ddlSubpartytype.DataSource = ds;
                ddlSubpartytype.DataTextField = "Description";
                ddlSubpartytype.DataValueField = "PartyCode";
                ddlSubpartytype.DataBind();
             
            }
            else
            {
                ddlSubpartytype.Items.Add(new ListItem("All", "All"));
            }
        }
    }

    protected void ddlPartyType_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlSubpartytype.Items.Clear();
        if (ddlPartyType.SelectedItem.Text == "Sales Office")
        {
        sql = "SELECT 'All' as PartyCode , 'All' AS Description UNION SELECT PartyCode,Description  from jct_courier_other_address where SaleOffice='Y' and status='A'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlSubpartytype.DataSource = ds;
        ddlSubpartytype.DataTextField = "Description";
        ddlSubpartytype.DataValueField = "PartyCode";
        ddlSubpartytype.DataBind();
             
        }
        else
        {
            ddlSubpartytype.Items.Add(new ListItem("All", "All"));
        }


    }

     protected void txtRequestBy_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRequestBy.Text = txtRequestBy.Text.Split('~')[2].ToString();
        }
        catch (Exception ex)
        {

        }
    }

    
    protected void BindGridWithOutDates()
    {
        sql = "JCT_COURIER_GET_STATUS_Dispatched";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = "09/10/2012";
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Now;
        cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = "";
        cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
        //cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = "All";
        cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = ddlPartyType.SelectedItem.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
        cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
        cmd.Parameters.Add("@SubSendtype", SqlDbType.VarChar, 20).Value = ddlSubpartytype.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandTimeout = 100000;
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
       
    }

    protected void BindGridWithDates()
    {
        sql = "JCT_COURIER_GET_STATUS_Dispatched";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
        cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = "";
        cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
        //cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = "All";
        cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = ddlPartyType.SelectedItem.Text;

        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
        cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
        cmd.Parameters.Add("@SubSendtype", SqlDbType.VarChar, 20).Value = ddlSubpartytype.SelectedItem.Value; 
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandTimeout = 100000;
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void BindGrid()
    {

    sql = "JCT_COURIER_GET_STATUS_Dispatched";
    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtFrom.Text;
    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtTo.Text;
    cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = "";
    cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = "";
    cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
    //cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = "All";
    cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = ddlPartyType.SelectedItem.Text;
    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
    cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
    cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
    cmd.Parameters.Add("@SubSendtype", SqlDbType.VarChar, 20).Value = ddlSubpartytype.SelectedItem.Value; 
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.SelectCommand.CommandTimeout = 100000;
    DataSet ds = new DataSet();
    da.Fill(ds);
    GridView1.DataSource = ds;
    GridView1.DataBind();

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        if (txtFrom.Text == "" || txtTo.Text == "")
        {
            BindGridWithOutDates();
        }
        else
        {
            BindGridWithDates();
        }
        
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    public void ShowAlertMsg(string error1)
    {
        #region msg
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            // error1 = error1.Replace("'", "'")
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error1 + "');", true);
        }
        #endregion

    }


    protected void txtPartyCode_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
   
    }

    protected void txtSupplierName_TextChanged(object sender, EventArgs e)
    {
 
    }
    protected void txtOtherParty_TextChanged(object sender, EventArgs e)
    {
    }
    protected void rblSaleOffices_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", GridView1);
    }
}