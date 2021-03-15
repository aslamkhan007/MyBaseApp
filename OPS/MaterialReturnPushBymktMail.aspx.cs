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

public partial class OPS_MaterialReturnPushBymktMail : System.Web.UI.Page
{
    string sanctionNoteId = string.Empty;
    string empcode = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;  

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    Functions objFun = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sanctionNoteId = string.Empty;
            empcode = string.Empty;

            empcode = Request.QueryString["EmpCode"].ToString();
            sanctionNoteId = Request.QueryString["SanctionID"];
                      
            HeaderDetail();
            FoldingObservationDetail();
        
            FillData();
            lblSanctionNoteId.Text = sanctionNoteId;
        }
    }

    protected void HeaderDetail()
    {
        sql = "Jct_Ops_PushBy_Mkt_Header_Fetch_Mail";
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


    protected void FoldingObservationDetail()
    {       
        //string qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_Fetch '" + sanctionNoteId + "'";
        string qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_Fetch '"+ sanctionNoteId + "' , 'FOLDING'  ";
        objFun.FillGrid(qry, ref grdFoldingObservation);

    }
    protected void CostingObservationDetail()
    {
        //string qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_Fetch '" + sanctionNoteId + "'";
        string qry = "Jct_Ops_Mr_Mkt_Nofification_Detail_Fetch '" + sanctionNoteId + "' , 'Costing'  ";
      //  objFun.FillGrid(qry, ref grdCostingObservation);

    }

    protected void FillData()
    {
        try
        {
            sql = "Jct_Ops_Mr_PushBy_Mkt_Detail_Fetch_Mail";
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

}