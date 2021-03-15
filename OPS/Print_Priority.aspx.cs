using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_Print_Priority : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String From, To;
        String Plant;
        Connection obj = new Connection();
        Functions obj1 = new Functions();
        String sql;
        if (!IsPostBack)
        {
            From = Request.QueryString["From"];
            lblFrom.Text = From;
            To = Request.QueryString["To"];
            lblTo.Text = To;
            Plant = Request.QueryString["Plant"];
            sql = "JCT_OPS_PLANNING_PRIORITY_PRINT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DATEFROM", SqlDbType.DateTime).Value = Convert.ToDateTime(From).GetDateTimeFormats('g')[3];
            cmd.Parameters.Add("@DATETO", SqlDbType.DateTime).Value = Convert.ToDateTime(To).GetDateTimeFormats('g')[3];
            cmd.Parameters.Add("@PLANT", SqlDbType.VarChar, 20).Value = Plant;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
    }
}