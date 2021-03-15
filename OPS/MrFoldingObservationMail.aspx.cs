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

public partial class OPS_MrFoldingObservationMail : System.Web.UI.Page
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
             returntype = string.Empty;


             //returntype = "Normal Return";

             //returntype = "Excess Return";

             empcode = Request.QueryString["EmpCode"].ToString();

             sanctionNoteId = Request.QueryString["SanctionID"];
             returntype = Request.QueryString["Returntype"];

             lblRequest.Text = returntype;
             lblSanctionNoteId.Text = sanctionNoteId;
             //sanctionNoteId = "1587";
             
            //sanctionNoteId = "1589";

            //empcode = "A-00098";
            

            if (returntype == "Normal Return")
            {
                HeaderDetail() ;
            }
            else

            if (returntype == "Excess Return")
            {
                //HeaderDetail1();
                HeaderDetail();
            }

            else 
                if (returntype == "Short Return")
            {
                HeaderDetail() ;
            }

            FillData();

            //HeaderDetail();

            //HeaderDetail1();
        }
    }

    protected void HeaderDetail()
    {
        //sql = "Jct_Ops_Mr_Closure_Header_Fetch_Mail";
        sql = "Jct_Ops_Mr_Folding_Observation_NormalReturn_Fetch_Mail";

        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;        
        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 14).Value = empcode;
        cmd.Parameters.Add("@AreaName", SqlDbType.VarChar, 100).Value = "Material Return";
        cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = sanctionNoteId; 
               
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dsItem = new DataSet();
        da.Fill(dsItem);
        GridView1.DataSource = dsItem;
        GridView1.DataBind();

    }


    protected void HeaderDetail1()
    {
        sql = "JCT_OPS_Mr_Folding_Observation_Excess_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        

        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime("01/01/2014");
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime("01/01/2020");
        cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 10).Value = "";
        cmd.Parameters.Add("@AREACODE", SqlDbType.VarChar, 100).Value = "1014";
        cmd.Parameters.Add("@SANCTIONID", SqlDbType.VarChar, 20).Value = sanctionNoteId;

        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = "";
        cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 10).Value = "";
      


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dsItem = new DataSet();
        da.Fill(dsItem);
        GridView1.DataSource = dsItem;
        GridView1.DataBind();

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


  
}