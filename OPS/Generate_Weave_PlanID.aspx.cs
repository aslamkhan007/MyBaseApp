using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_Generate_Weave_PlanID : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    string script;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdPlanID.DataSourceID = "SqlDataSource1";
            grdPlanID.DataBind();
        }
        
    }
    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_OPS_PLANNING_GENERATE_PLANID_INSERT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlanStartDate", SqlDbType.VarChar, 20).Value = txtPlanStartDate.Text;
            cmd.Parameters.Add("@PlanEndDate", SqlDbType.VarChar, 20).Value = txtPlanEndDate.Text;
            cmd.Parameters.Add("@PLANTYPE", SqlDbType.VarChar, 50).Value = ddlPlanType.SelectedItem.Text;
            cmd.Parameters.Add("@REMARKS", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value =ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Value = txtDescription.Text;
            cmd.Parameters.Add("@ExpectedDelivery", SqlDbType.VarChar, 20).Value = txtExpectedDelivery.Text;

            cmd.ExecuteNonQuery();
            grdPlanID.DataSourceID = "SqlDataSource1";
            grdPlanID.DataBind();
            script = "alert('Plan Generated Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch(Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
       
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/Generate_Weave_PlanID.aspx");
    }
}