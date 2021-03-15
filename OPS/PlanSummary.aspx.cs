using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class OPS_PlanSummary : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

  
    protected void grdPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label PlanId = (Label)e.Row.FindControl("lblPlanID");

            string sql = "Select * from JCT_OPS_PLANNING_GENERATE_PLANID where Status='A' and Planid=" + PlanId.Text + "  and activated='Y'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                LinkButton activate = (LinkButton)e.Row.FindControl("lnkActivate");
                activate.Enabled = false;
                e.Row.ToolTip = "Plan under Execution.";
            }

            else
            {
                sql = "Select * from JCT_OPS_PLANNING_GENERATE_PLANID where Status='A' and Planid=" + PlanId.Text + " and DeactivationDate is not null and DeactivatedBy is not null ";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    LinkButton activate = (LinkButton)e.Row.FindControl("lnkActivate");
                    activate.Enabled = false;
                    LinkButton deactivate = (LinkButton)e.Row.FindControl("lnkDeactivate");
                    deactivate.Enabled = false;
                    e.Row.ToolTip = "Plan has been Executed - It was " + obj1.FetchValue("Select Upper(Description) as Description from JCT_OPS_PLANNING_GENERATE_PLANID where Status='A' and Planid=" + PlanId.Text + "") + "";
                }
                else
                {
                    LinkButton deactivate = (LinkButton)e.Row.FindControl("lnkDeactivate");
                    deactivate.Enabled = false;
                    e.Row.ToolTip = "Plan not started yet.";
                }
            }
        }
    }

    protected void grdPlan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // chart.Series.Clear();

            Label PlanID = (Label)grdPlan.SelectedRow.FindControl("lblPlanID");

            string sql = "JCT_OPS_PLANNING_WEAVING_SUMMARY";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = PlanID.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
 
            RadHtmlChart1.DataSource = ds;
            RadHtmlChart1.DataBind();

            obj.ConClose();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            obj.ConClose();
        }
 
    }

    protected void grdPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string sql;

        try
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label PlanID = (Label)gvRow.FindControl("lblPlanID");

            if (e.CommandName == "Activate")
            {
                sql = "JCT_OPS_ACTIVATE_DEACTIVATE_WEAVE_PLAN";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = PlanID.Text;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                cmd.ExecuteNonQuery();
 
                string script = "alert('Plan activated successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            }
            else if (e.CommandName == "Deactivate")
            {
                sql = " UPDATE  dbo.JCT_OPS_PLANNING_GENERATE_PLANID SET DeactivationDate=GETDATE(),DeactivatedBy=@EmpCode WHERE PLANID=@PlanID";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                cmd.Parameters.Add("@PlanID", SqlDbType.VarChar, 20).Value = PlanID.Text;
                cmd.ExecuteNonQuery();

                string script = "alert('Plan de-activated successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }

        catch (Exception ex)
        {
            string script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

       
    }
 
    protected void btnSummary_Click(object sender, EventArgs e)
    {
        string sql = "SELECT PLANID ,UPPER(DESCRIPTION) AS Description,CONVERT(VARCHAR,PLANSTARTDATE,103) AS StartDate,CONVERT(VARCHAR,PLANENDDATE,103) AS EndDate,ISNULL(Activated,'N') AS Activated FROM dbo.JCT_OPS_PLANNING_GENERATE_PLANID WHERE STATUS='A' AND Plant=@Plant order by planid desc";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        
        grdPlan.DataSource = ds.Tables[0];
        grdPlan.DataBind();
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OPS/PlanSummary.aspx");
    }

    protected void btnChart_Click(object sender, EventArgs e)
    {
        try
        {
            // chart.Series.Clear();

           

            string sql = "JCT_OPS_PLANNING_WEAVING_SUMMARY";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlPlant.SelectedItem.Text;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = 1005;//PlanID.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            RadHtmlChart1.DataSource = ds;
            RadHtmlChart1.DataBind();

            obj.ConClose();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            obj.ConClose();
        }
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        string SeriesName = RadHtmlChart1.PlotArea.Series[0].Name;

        if (SeriesName == "Info")
        { 
            
        }

    }
}