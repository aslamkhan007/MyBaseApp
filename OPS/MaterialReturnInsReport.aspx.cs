using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_MaterialReturnInsReport : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {

        sql = "jct_ops_material_return_inspection_report_new";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 20).Value = txtID.Text;
        cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtdatefrm.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtdateto.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdMaterialRequest.DataSource = ds;
        grdMaterialRequest.DataBind();
        // jct_ops_material_return_inspection_report_new 
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}