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

public partial class AssetMngmnt_AssetMngtMail : System.Web.UI.Page
{
    string requestID = string.Empty;
    //string oldrequestID = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    int requestid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["EmpCode"] == string.Empty)
        //{
        //    Response.Redirect("~/login.aspx");
        //}

        string empcode = Request.QueryString["EmpCode"].ToString();
        string generatedby = Request.QueryString["Generatedby"].ToString();
        requestid = Convert.ToInt16(Request.QueryString["requestid"]);
        //requestid = 1721;

        sql = "SELECT empname FROM dbo.JCT_EmpMast_Base WHERE empcode = '" + empcode + "' AND Active = 'y'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                lblGeneratedfor.Text = Dr[0].ToString();

            }
        }
        Dr.Close();



        //sql = "SELECT empname FROM dbo.JCT_EmpMast_Base WHERE empcode = '" + Session["Empcode"] + "' AND Active = 'y'";
        //cmd = new SqlCommand(sql, obj.Connection());
        //cmd.CommandType = CommandType.Text;
        //Dr = cmd.ExecuteReader();
        //if (Dr.HasRows)
        //{
        //    while (Dr.Read())
        //    {
        //        lblGeneratedby.Text = Dr[0].ToString();

        //    }
        //}
        //Dr.Close();
        //FillData();





        sql = "SELECT empname FROM dbo.JCT_EmpMast_Base WHERE empcode = '" + generatedby + "' AND Active = 'y'";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        Dr = cmd.ExecuteReader();
        if (Dr.HasRows)
        {
            while (Dr.Read())
            {

                lblGeneratedby.Text = Dr[0].ToString();
            }
        }
        Dr.Close();
        FillData();



    

    }

    protected void FillData()
    {
        try
        {
            //requestid = Convert.ToInt16(Request.QueryString["requestid"]);
            sql = "jct_asset_item_furniture_detail_select_furniture_mail";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;

            //if (requestID != string.Empty)

            //{
            //cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = Convert.ToInt16(requestID);
            cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = requestid;
            //}


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dsItem = new DataSet();
            da.Fill(dsItem);

            foreach (DataRow dr in dsItem.Tables[0].Rows)
            {
                //if (dsItem.Tables["empcode"].ToString() == "")
                if (string.IsNullOrEmpty(dr["empcode"].ToString()))
                {
                    //lblEmployeeCode.Text = "DepartmentCode";
                    //lblLocation.Text = "Location";
                    //lblEmployeeCode.Text = dr["fur_dept"].ToString();
                    lblLocation.Text = dr["deptloc"].ToString();

                    lblsubLocation.Text = dr["sub_location"].ToString();
                    //ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindItemByText(dr["assetstate"].ToString()));

                    //ddlShadred.SelectedIndex = ddlShadred.Items.IndexOf(ddlShadred.Items.FindItemByText(dr["plant"].ToString()));

                    //ddlCapital.SelectedIndex = ddlCapital.Items.IndexOf(ddlCapital.Items.FindItemByValue(dr["capitalitem"].ToString()));

                    //txtRemarks.Text = dr["itemdescription"].ToString();

                    //if (string.IsNullOrEmpty(dr["acquisitiondate"].ToString()))
                    //{
                    //    txtAcqDt.Text = string.Empty;
                    ////}
                    //else
                    //{
                    //    txtacqdt_CalendarExtender.SelectedDate = Convert.ToDateTime(dr["acquisitiondate"].ToString()).Date;
                    //}

                    ViewState["RequestID"] = dr["item_id"].ToString();
                }
                else
                {
                    //lblEmployeeCode.Text = "EmployeeCode";
                    //lblLocation.Text = "Location";

                    //lblEmployeeCode.Text = dr["empcode"].ToString();
                    lblLocation.Text = dr["deptloc"].ToString();

                    lblsubLocation.Text = dr["sub_location"].ToString();

                    //ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindItemByText(dr["assetstate"].ToString()));

                    //ddlShadred.SelectedIndex = ddlShadred.Items.IndexOf(ddlShadred.Items.FindItemByText(dr["plant"].ToString()));

                    //ddlCapital.SelectedIndex = ddlCapital.Items.IndexOf(ddlCapital.Items.FindItemByValue(dr["capitalitem"].ToString()));

                    //txtRemarks.Text = dr["itemdescription"].ToString();

                    //if (string.IsNullOrEmpty(dr["acquisitiondate"].ToString()))
                    //{
                    //    txtAcqDt.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    txtacqdt_CalendarExtender.SelectedDate = Convert.ToDateTime(dr["acquisitiondate"].ToString()).Date;
                    //}

                    ViewState["RequestID"] = dr["item_id"].ToString();
                }
            }

            //grdDetail.DataSource = dsItem.Tables[1];
            //grdDetail.DataBind();


            ViewState["dtgridItems"] = dsItem.Tables[1];
            grdItemDetail.DataSource = dsItem.Tables[1];
            grdItemDetail.DataBind();
            grdItemDetail.Visible = true;
            lblRequestId.Text = requestid.ToString();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


}