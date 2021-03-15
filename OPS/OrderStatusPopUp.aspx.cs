using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class OrderStatusPopUp : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Request.QueryString["OrderNo"] == null)
        {
            //DetailsView1.DefaultMode = DetailsViewMode.Insert;
        }
        else
        {
            //DetailsView1.DefaultMode = DetailsViewMode.Edit;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "JCT_OPS_PLANNING_CHECK_ORDER_STATUS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 22).Value = Request.QueryString["OrderNo"];
        cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = Convert.ToInt16(Request.QueryString["PlanID"]);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        grdPopUp.DataSource = ds.Tables[0];
        grdPopUp.DataBind();


         
    }

    protected void radRePlan_Click(object sender, EventArgs e)
    {
        int i = 0;
        i = grdPopUp.MasterTableView.Items.Count;

        foreach(GridDataItem item in grdPopUp.MasterTableView.Items)
        {
            string TransNo = item["TransNo"].Text;
            string OrderNo = item["OrderNo"].Text;

            string sql = "JCT_OPS_PLANNING_REPLAN_PENDING_ORDERS_PopUp";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandTimeout = 10000000;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(TransNo);
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar,20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@NewPlanID", SqlDbType.Int).Value =Convert.ToInt16(Request.QueryString["PlanID"]);
            cmd.ExecuteNonQuery();

        }

        string script = "alert('Order Re-Planned Successfully..!! Please close the order pop up.');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        
    }
}
