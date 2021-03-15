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

public partial class OPS_MRCostingFeedBackMail : System.Web.UI.Page
{
    string sanctionNoteId = string.Empty;
    string empcode = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;
    string returntype = string.Empty;

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["jctdevConnectionString"].ConnectionString);
    Connection obj = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            sanctionNoteId = string.Empty;
            empcode = string.Empty;
            empcode = Request.QueryString["EmpCode"].ToString();
            sanctionNoteId = Request.QueryString["SanctionID"];
            lblSanctionNoteId.Text = sanctionNoteId;
            FillData();
            FillSecondGrid();
        }
    }
    protected void FillData()
    {
        try
        {

            sql = "Jct_Ops_Mr_Folding_Observation_Excess_Fetch_Mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.Int).Value = sanctionNoteId;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdItemDetail.DataSource = ds;
            grdItemDetail.DataBind();
            grdItemDetail.Visible = true;
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }
    protected void FillSecondGrid()
    {
        try
        {

            sql = "Jct_Ops_Mr_Costing_FeedBack_Fetch_Mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.Int).Value = sanctionNoteId;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            GridView2.Visible = true;
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


}