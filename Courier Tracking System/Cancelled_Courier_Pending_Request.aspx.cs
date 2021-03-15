using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_Cancelled_Courier_Pending_Request : System.Web.UI.Page
{
    Connection obj = new Connection();
    String sql;
    string script = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_COURIER_GET_CANCELLED_REQ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
            if (txtFrom.Text != string.Empty)
            {
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
            }
            if (txtTo.Text != string.Empty)
            {
                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
            }
            cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
            cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
            cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds;
            grdDetail.DataBind();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TableCell cell = e.Row.Cells[9];
        cell.Width = new Unit("5%");
    }
}