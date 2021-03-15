using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_FormB : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string requestID;
    string jctsr_no;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            requestID = Request.QueryString["requestid"].ToString();
            string sql = ("SELECT jctSR_NO FROM dbo.jct_asset_item_details WHERE item_id= '" + requestID + "' AND status='A'");
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //jctsr_no = dr[0].ToString();
                    //lblsrno.Text = dr[0].ToString();
                }
            }
            dr.Close();



            sql = "jct_asset_item_detail_print";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = requestID;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    //lblcomptype.Text = dr["computer_type"].ToString();
                    //lblCurrentDate.Text = dr["Dated"].ToString();
                    //lblissuedto.Text = dr["IssueTo"].ToString();
                    //lbldept.Text = dr["Department"].ToString();
                    //lblmodelno.Text = dr["ModelNo"].ToString();
                   

                }
            }
            else
            {
                string script = "alert(Noooooooooooooooo data available!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            dr.Close();
        }
    }
}