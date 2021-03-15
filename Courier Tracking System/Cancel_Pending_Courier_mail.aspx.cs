using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Courier_Tracking_System_Cancel_Pending_Courier_mail : System.Web.UI.Page
{
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["GetSerialNo"] = Request.QueryString["SerialNo"].ToString();      
            bindGrid();
        }
    }
    public void bindGrid()
    {

        string sqlpass = "JCT_COURIER_CANCEl_MAIL_CONTENT";   
        SqlCommand cmd = new SqlCommand(sqlpass, obj.Connection());
        //cmd.Parameters.Add("@COURIERID", SqlDbType.VarChar, 20).Value = "ACT/1000313/2014";
        cmd.Parameters.Add("@COURIERID", SqlDbType.VarChar, 20).Value = ViewState["GetSerialNo"];
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        da.Fill(ds);
        //da.Fill(dt);
        
        //grdDetail.DataSource = dt;
        grdDetail.DataSource = ds;
        grdDetail.DataBind();
    }
}