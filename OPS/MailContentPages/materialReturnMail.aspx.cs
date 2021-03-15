using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_MailContentPages_materialReturnMail : System.Web.UI.Page
{
     Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    bool color = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                string transid = Request.QueryString["transid"].ToString();
                string requestid = Request.QueryString["requestid"].ToString();

                //sql = "SELECT REASON FROM JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS WHERE STATUS='A'  and Plant = 'COTTON' order by Sr_No";
                ////obj1.FillList(ddlReason_ins, sql);

                sql = "jct_ops_material_return_inspection_select";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sr_no", SqlDbType.Int).Value = transid;
                cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = requestid;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // Request Data Fill
                        lblRequestID.Text = requestid;
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
                        lbmr.Text = dr["MrNo"].ToString();
                    }
                    dr.Close();
                    // Inspection Data Fill


                    sql = "jct_ops_material_return_inspection_select2";
                    cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                
                    cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = requestid;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            lblRequestID.Text = requestid;
                            lblPartyName_ins.Text= dr["Customer"].ToString();
                            lblInvoiceNo_ins.Text = dr["invoice_no"].ToString();
                            lblSortNo_ins.Text = dr["item_no"].ToString();
                             lblShade_ins.Text = dr["shade"].ToString();
                             lblInvoiceQty_ins.Text = dr["invoice_qty"].ToString();
                             lbinsdate.Text = dr["InspectionDate"].ToString();
                                      
                     
                            lbreturnqtyins.Text = dr["RETURN_QTY"].ToString();
                            lbrollsins.Text = dr["ROLLS"].ToString();
                            lbReasonins.Text = dr["Reason"].ToString();
                            lbinsremarks.Text = dr["REASON_DESCRIPTION"].ToString();
                            //ddlReason_ins.SelectedIndex = ddlReason_ins.Items.IndexOf(ddlReason_ins.Items.FindByText(dr["Reason"].ToString()));

                            lblInvoiceDate_ins.Text = dr["invoice_date"].ToString();
                            lblSalesPerson_ins.Text = dr["sales_person"].ToString();
                            lblPlant_ins.Text = dr["plant"].ToString();
                            lblFreightPaidBy_ins.Text = dr["freightpaidby"].ToString();
                            lblFreightValue_ins.Text = dr["freightvalue"].ToString();

                            sql = "Select b.empname as AuthorizedBy,a.auth_dateTime as AuthorizedDate,a.Remarks from jct_ops_sanctionnote_authorization_listing a inner join jct_empmast_base b on a.empcode=b.empcode where a.id='" + requestid + "' order by userlevel";
                            obj1.FillGrid(sql, ref grdAuthorizationHistory);

                            sql = "Select empname from jct_empmast_base where empcode='J-01945'";//'"+ Session["EmpCode"].ToString() +"'";
                            lblInspectionDoneBy_ins.Text = obj1.FetchValue(sql).ToString();


                        }
                    }
                }
        
            }
            catch
            {
                // run now
            }




        }
    }
}