using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_MaterialReturnInspection : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql = "jct_ops_material_return_inspection_data";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdInspection.DataSource = ds.Tables[0];
            grdInspection.DataBind();
        }
    }

    protected void grdInspection_SelectedIndexChanged(object sender, EventArgs e)
    {
        int srno = Convert.ToInt16(grdInspection.SelectedRow.Cells[1].Text);
        int requestid = Convert.ToInt16(grdInspection.SelectedRow.Cells[2].Text);
        lblRequestID.Text = requestid.ToString() ;

        sql = "SELECT REASON FROM JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS WHERE STATUS='A'  and Plant = 'COTTON' order by Sr_No";
        obj1.FillList(ddlReason_ins, sql);

        sql = "jct_ops_material_return_inspection_select";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@sr_no", SqlDbType.Int).Value = srno;
        cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = requestid;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                // Request Data Fill
                lblPartyName.Text = dr["Customer"].ToString();
                lblInvoiceNo.Text = dr["invoice_no"].ToString();
                lblSortNo.Text = dr["item_no"].ToString();
                lblShade.Text = dr["shade"].ToString();
                lblInvoiceQty.Text = dr["invoice_qty"].ToString();
                lblReturnQty.Text = dr["Logistics_ReturnQty"].ToString();
                lblRolls.Text = dr["Logistics_BaleNo"].ToString();
                lblReason.Text = dr["Reason"].ToString();
                lblInvoiceDate.Text = dr["invoice_date"].ToString();
                lblSalesPerson.Text = dr["sales_person"].ToString();
                lblPlant.Text = dr["plant"].ToString();
                lblFreightPaidBy.Text = dr["freightpaidby"].ToString();
                lblFreightValue.Text = dr["freightvalue"].ToString();

                // Inspection Data Fill

                lblPartyName_ins.Text = dr["customer"].ToString();
                lblInvoiceNo_ins.Text = dr["invoice_no"].ToString();
                lblSortNo_ins.Text = dr["item_no"].ToString();
                lblShade_ins.Text = dr["shade"].ToString();
                lblInvoiceQty_ins.Text = dr["invoice_qty"].ToString();
                txtReturnQty_ins.Text = dr["Logistics_ReturnQty"].ToString();
                txtRolls_ins.Text = dr["Logistics_BaleNo"].ToString();
                //lblReason_ins.Text = dr["Reason"].ToString();

                ddlReason_ins.SelectedIndex= ddlReason_ins.Items.IndexOf(ddlReason_ins.Items.FindByText(dr["Reason"].ToString()));

                lblInvoiceDate_ins.Text = dr["invoice_date"].ToString();
                lblSalesPerson_ins.Text = dr["sales_person"].ToString();
                lblPlant_ins.Text = dr["plant"].ToString();
                lblFreightPaidBy_ins.Text = dr["freightpaidby"].ToString();
                lblFreightValue_ins.Text = dr["freightvalue"].ToString();

            }
        }
        dr.Close();
        obj.ConClose();

        sql = "Select b.empname as AuthorizedBy,a.userlevel,a.auth_dateTime as AuthorizedDate,a.Remarks from jct_ops_sanctionnote_authorization_listing a inner join jct_empmast_base b on a.empcode=b.empcode where a.id='" + grdInspection.SelectedRow.Cells[2].Text + "' order by userlevel";
        obj1.FillGrid(sql, ref grdAuthorizationHistory);

        sql = "Select empname from jct_empmast_base where empcode='J-01945'";//'"+ Session["EmpCode"].ToString() +"'";
        lblInspectionDoneBy_ins.Text = obj1.FetchValue(sql).ToString();

    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaterialReturnInspection.aspx");
    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        // submit code 
        // table name - select * from JCT_OPS_MATERIAL_RETURN_INSPECTION
        // send mail code
    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        sql = "jct_ops_material_return_inspection_data";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(txtSanctionID.Text))
        {
            cmd.Parameters.Add("@sanctionid", SqlDbType.Int).Value = Convert.ToInt16(txtSanctionID.Text);
        }
        if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
        {
            cmd.Parameters.Add("@invoice_no", SqlDbType.VarChar, 30).Value = txtInvoiceNo.Text;
        }
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdInspection.DataSource = ds.Tables[0];
        grdInspection.DataBind();
    }
}