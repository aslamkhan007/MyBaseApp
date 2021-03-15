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


public partial class OPS_Material_Return_ClosureMail : System.Web.UI.Page
{
    string sanctionNoteId = string.Empty;
    string empcode = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;
    string returntype = string.Empty;

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sanctionNoteId = string.Empty;
            empcode = string.Empty;

            empcode = Request.QueryString["EmpCode"].ToString();
            sanctionNoteId = Request.QueryString["SanctionID"];

            //sanctionNoteId = "1589";
            //empcode = "A-00098";

            Header();
            Detail();
            UserName();
                     
        }

    }

    public void UserName()
    {

        sql = "SELECT empname FROM dbo.JCT_EmpMast_Base WHERE empcode = '" + empcode + "' AND Active = 'y'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                lblCreatedBy.Text = Dr[0].ToString();

            }
        }
        Dr.Close();
    }


    protected void Header()
    {
        try
        {
            sql = "Jct_Ops_Mr_Closure_Header_Fetch_Mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 14).Value = empcode;
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = sanctionNoteId;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dsItem = new DataSet();           
            da.Fill(dsItem);
            GridView1.DataSource = dsItem; 
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


    protected void Detail()
    {
        sql = "Jct_Ops_Mr_Closure_Detail_Fetch_Mail";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;      
        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 20).Value = sanctionNoteId;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dsItem = new DataSet();
        da.Fill(dsItem);
        String str = dsItem.Tables[0].Rows[0]["Remarks"].ToString();
        lblRemarks.Text = str;
        grdItemDetail.DataSource = dsItem;
        grdItemDetail.DataBind();

    }


}