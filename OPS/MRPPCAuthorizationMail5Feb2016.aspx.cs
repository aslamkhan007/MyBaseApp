using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class OPS_MRPPCAuthorizationMail : System.Web.UI.Page
{
    string sanctionNoteId = string.Empty;
    string empcode = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;
    string returntype = string.Empty;

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["jctdevConnectionString"].ConnectionString);
    Connection obj = new Connection();
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        sanctionNoteId = string.Empty;
        empcode = string.Empty;
        empcode = Request.QueryString["EmpCode"].ToString();
        sanctionNoteId = Request.QueryString["SanctionID"];
        lblSanctionNoteId.Text = sanctionNoteId;
       
sql = @"SELECT  E.empname AS sales_person ,R.customer AS customer , CASE WHEN P.PPCStatus = 'PPCOPEN' THEN 'Authorize'   WHEN P.PPCStatus = 'C' THEN 'Cancel'   END AS Status
               FROM    jct_ops_material_request R (NOLOCK) JOIN jct_ops_MRPPC P (NOLOCK) ON R.RequestID=P.RequestID JOIN  JCT_EmpMast_Base E (NOLOCK) ON R.sales_person=REPLACE(E.empcode,'-','')
            WHERE   R.RequestID = '" + sanctionNoteId + "'";


        cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                lblSalePerson.Text = dr[0].ToString();
                lblCustomer.Text = dr[1].ToString();
                lblStatus.Text = dr[2].ToString();

            }
        }
        dr.Close();



        FillData();
        fillSecondGrid();

    }
    protected void FillData()
    {
        try
        {

            sql = "Jct_Ops_Mr_PPCMR_Detail_Mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = sanctionNoteId;
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
    protected void fillSecondGrid()
    {
        sql = "Select Category,OrderNo FROM  jct_ops_MRPPC  WHERE  RequestID  = '" + sanctionNoteId + "' ";

        cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                lblCategory.Text = dr[0].ToString();
              


            }
        }
        dr.Close();


        //try
        //{

        //    sql = "Jct_Ops_Mr_PPCMR_Detail_Mail";
        //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = sanctionNoteId;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    grdItemDetail.DataSource = ds;
        //    grdItemDetail.DataBind();
        //    grdItemDetail.Visible = true;
        //}
        //catch (Exception ex)
        //{
        //    string script2 = "alert('" + ex.Message + "');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        //    return;
        //}
    }


}