using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Courier_Tracking_System_Courier_Personal : System.Web.UI.Page
{

    Connection obj = new Connection();
    String sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_COURIER_GET_PersonalCouriers";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtFrom.Text;
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtTo.Text;
            

            if (string.IsNullOrEmpty(DdlCouriertype0.SelectedItem.Text))
            {
                DdlCouriertype0.SelectedItem.Text = "";
            }
            else
            {
                cmd.Parameters.Add("@REQUESTBY", SqlDbType.VarChar, 30).Value = DdlCouriertype0.SelectedItem.Text;
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds;
            grdDetail.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
}