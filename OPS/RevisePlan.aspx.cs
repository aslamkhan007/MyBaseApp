using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class OPS_RevisePlan : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        if (txtCustomer.Text != "")
        {

            txtCustomer.Text = txtCustomer.Text.Split('~')[1].ToString();
        }
        else
        {

        }
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        Fillgrid();

    }

    protected void Fillgrid()
    {
        sql = "JCT_OPS_PLANNING_FREEZED_PLAN_DETAILS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@OrderNo", SqlDbType.Decimal).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = txtWeavingSort.Text;
        cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = txtPlanID.Text;
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Value;
        cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = txtCustomer.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdPlan.DataSource = ds.Tables[0];
        grdPlan.DataBind();
    }

    protected void grdPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPlan.PageIndex = e.NewPageIndex;
        Fillgrid();
    }
}