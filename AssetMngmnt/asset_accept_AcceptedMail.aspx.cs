using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using System.Net.Mail;


public partial class AssetMngmnt_asset_accept_AcceptedMail : System.Web.UI.Page
{
    string requestID = string.Empty;
    string usercode = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    int requestid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            requestid = Convert.ToInt16(Request.QueryString["requestid"]);
            usercode = Request.QueryString["Empcode"];
            //requestid = 2625;
            //usercode = "S-13823";
            AcceptedItems();
            TotalItems();
            EmployeeDetail();
        }

    }

    protected void EmployeeDetail()
    {       
        sql = "SELECT  DISTINCT b.Usercode ,b.UserName,b.Sublocation,b.Location FROM  dbo.jct_asset_item_details AS a INNER JOIN jct_asset_Employee_Location_map AS b ON a.sub_location = b.Sublocation WHERE   a.item_id = '" + requestid + "' AND a.module_usedby = 'Gen' AND a.status = 'A' AND b.module_usedby = 'Gen' AND b.STATUS = 'A' and b.usercode = '"+ usercode +"' ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dsItem = new DataSet();
        da.Fill(dsItem);
        GridView1.DataSource = dsItem;
        GridView1.DataBind();

    }


    protected void TotalItems()
    {
        try
        {
            sql = "Jct_Asset_Accept_TotalItems_Mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Request_id", SqlDbType.Int).Value = requestid;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdtotalItems.DataSource = ds.Tables[0];
            grdtotalItems.DataBind();
            grdtotalItems.Visible = true;
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void AcceptedItems()
    {
        try
        {
            sql = "Jct_Asset_Accept_AcceptedItems_Mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Request_id", SqlDbType.Int).Value = requestid;
            cmd.Parameters.Add("@Usercode", SqlDbType.VarChar,50).Value = usercode;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdAcceptedItems.DataSource = ds.Tables[0];
            grdAcceptedItems.DataBind();
            grdAcceptedItems.Visible = true;
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

}