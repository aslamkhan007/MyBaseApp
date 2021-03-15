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

public partial class AssetMngmnt_AssetMngtEmpMappingMail : System.Web.UI.Page
{
    string sql = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        emptylbl();

        if (Request.QueryString["sr_id"] != null)
        {
            lblmapunmap.Text = "UnMapped";
            string id1 = Request.QueryString["sr_id"].ToString();
            sql = "SELECT id,sublocation,location,username,usercode,created_by FROM jct_asset_Employee_Location_map where id = '" + id1 + "'";
        }
        else if (Request.QueryString["usercode"] != null)
        {
            lblmapunmap.Text = "Mapped";
            string usercode1 = Request.QueryString["usercode"].ToString();
            sql = "SELECT id,sublocation,location,username,usercode,created_by FROM jct_asset_Employee_Location_map where STATUS = 'a' AND usercode  = '" + usercode1 + "'";
        
        }
        else if (Request.QueryString["Sublocation"] != null)
        {
            lblmapunmap.Text = "Mapped";
            string Sublocation1 = Request.QueryString["Sublocation"].ToString();
            sql = "SELECT id,sublocation,location,username,usercode,created_by FROM jct_asset_Employee_Location_map where STATUS = 'a' AND Sublocation  = '" + Sublocation1 + "'";
        }
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {

               lblsrno.Text = Dr[0].ToString();
                lblsubLocation.Text = Dr[1].ToString();
                lblLocation.Text = Dr[2].ToString();
                lblemployeename.Text = Dr[3].ToString();
                lblemployeeCode.Text = Dr[4].ToString();
                lblGeneratedby.Text = Dr[5].ToString();

            }
        }
        Dr.Close();
        MappingDetail();
      
    }
    public void emptylbl()
    {
        lblsrno.Text = "";
        lblsubLocation.Text = "";
        lblLocation.Text = "";
        lblemployeename.Text = "";
        lblemployeeCode.Text = "";
        lblGeneratedby.Text = "";
    }

    public void MappingDetail()
    {

        string sqlpass = "jct_asset_Employee_Location_Mapping_Detail";
        SqlCommand cmd = new SqlCommand(sqlpass, obj.Connection());                
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);        
        DataSet ds = new DataSet();
        da.Fill(ds);               
        grdDetail.DataSource = ds;
        grdDetail.DataBind();
    }

}