using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_OrderPPL : System.Web.UI.Page
{


    Functions obj1 = new Functions();
    Connection obj = new Connection();
    string sql;
    string script;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        txtCustomer.Text = txtCustomer.Text.Split('~')[1].ToString();
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        fillgrid();
         
        
    }

    protected void fillgrid()
    {
        try
        {
            sql = "JCT_OPS_COSTING_PPL_SELECT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@SORTNO", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar, 20).Value = txtCustomer.Text;
            cmd.Parameters.Add("@PLANID", SqlDbType.VarChar, 20).Value = ddlPlanID.SelectedItem.Value;
            cmd.Parameters.Add("@PLANT", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdPPL.DataSource = ds.Tables[0];
            grdPPL.DataBind();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdPPL_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPPL.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    protected void chbSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbHeader = (CheckBox)grdPPL.HeaderRow.FindControl("chbSelectAll");
        if (cbHeader.Checked == true)
        {
            for (int k = 0; k <= grdPPL.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)grdPPL.Rows[k].FindControl("chbSelect");
                myCheckBox.Checked = true;
            }
        }
        else if (cbHeader.Checked == false)
        {
            for (int k = 0; k <= grdPPL.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)grdPPL.Rows[k].FindControl("chbSelect");
                myCheckBox.Checked = false;
            }
        }
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {

        CheckBox cbHeader = (CheckBox)grdPPL.HeaderRow.FindControl("chbSelectAll");


        if (cbHeader.Checked == true)
        {

            for (int k = 0; k <= grdPPL.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)grdPPL.Rows[k].FindControl("chbSelect");

                if (myCheckBox.Checked == true)
                {
                    try
                    {
                        Label ID = (Label)grdPPL.Rows[k].FindControl("lblID");
                        Label OrderNo = (Label)grdPPL.Rows[k].FindControl("lblOrderNo");
                        Label SortNo = (Label)grdPPL.Rows[k].FindControl("lblSortNo");
                        Label Customer = (Label)grdPPL.Rows[k].FindControl("lblCustomer");
                        //Label SalePerson = (Label)grdPPL.Rows[k].FindControl("lblSalePerson");
                        Label SaleTeam = (Label)grdPPL.Rows[k].FindControl("lblSaleTeam");
                        Label Qty = (Label)grdPPL.Rows[k].FindControl("lblQty");
                        //Label Greigh = (Label)grdPPL.Rows[k].FindControl("lblGreigh");
                        TextBox DnV = (TextBox)grdPPL.Rows[k].FindControl("txtDnV");
                        TextBox FixedOverhead = (TextBox)grdPPL.Rows[k].FindControl("txtFixedOverhead");
                        TextBox Depreciation = (TextBox)grdPPL.Rows[k].FindControl("txtDepreciation");
                        TextBox RPM = (TextBox)grdPPL.Rows[k].FindControl("txtRPM");
                        TextBox Efficiency = (TextBox)grdPPL.Rows[k].FindControl("txtEfficiency");

                        sql = "JCT_OPS_COSTING_PPL_INSERT";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = ID.Text;
                        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = SortNo.Text;
                        cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 500).Value = Customer.Text;
                        //cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 100).Value = SalePerson.Text;
                        cmd.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 30).Value = SaleTeam.Text;
                        cmd.Parameters.Add("@OrderQty", SqlDbType.VarChar, 20).Value = Qty.Text;
                        //cmd.Parameters.Add("@Greigh", SqlDbType.VarChar, 20).Value = Greigh.Text;
                        cmd.Parameters.Add("@DnV", SqlDbType.VarChar, 20).Value = DnV.Text;
                        cmd.Parameters.Add("@FixedOverhead", SqlDbType.VarChar, 20).Value = FixedOverhead.Text;
                        cmd.Parameters.Add("@Depreciation", SqlDbType.VarChar, 20).Value = Depreciation.Text;
                        cmd.Parameters.Add("@RPM", SqlDbType.VarChar, 20).Value = RPM.Text;
                        cmd.Parameters.Add("@Efficiency", SqlDbType.VarChar, 20).Value = Efficiency.Text;
                        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                        cmd.ExecuteNonQuery();
                        script = "alert('Record saved successfully..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }

                    catch (Exception ex)
                    {
                        script = "alert('" + ex.Message + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }

                }
            }

        }

        else
        {
            for (int k = 0; k <= grdPPL.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)grdPPL.Rows[k].FindControl("chbSelect");

                if (myCheckBox.Checked == true)
                {
                    try
                    {
                        Label ID = (Label)grdPPL.Rows[k].FindControl("lblID");
                        Label OrderNo = (Label)grdPPL.Rows[k].FindControl("lblOrderNo");
                        Label SortNo = (Label)grdPPL.Rows[k].FindControl("lblSortNo");
                        Label Customer = (Label)grdPPL.Rows[k].FindControl("lblCustomer");
                        //Label SalePerson = (Label)grdPPL.Rows[k].FindControl("lblSalePerson");
                        Label SaleTeam = (Label)grdPPL.Rows[k].FindControl("lblSaleTeam");
                        Label Qty = (Label)grdPPL.Rows[k].FindControl("lblQty");
                        //Label Greigh = (Label)grdPPL.Rows[k].FindControl("lblGreigh");
                        TextBox DnV = (TextBox)grdPPL.Rows[k].FindControl("txtDnV");
                        TextBox FixedOverhead = (TextBox)grdPPL.Rows[k].FindControl("txtFixedOverhead");
                        TextBox Depreciation = (TextBox)grdPPL.Rows[k].FindControl("txtDepreciation");
                        TextBox RPM = (TextBox)grdPPL.Rows[k].FindControl("txtRPM");
                        TextBox Efficiency = (TextBox)grdPPL.Rows[k].FindControl("txtEfficiency");

                        sql = "JCT_OPS_COSTING_PPL_INSERT";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = ID.Text;
                        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = SortNo.Text;
                        cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 500).Value = Customer.Text;
                        //cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 100).Value = SalePerson.Text;
                        cmd.Parameters.Add("@SaleTeam", SqlDbType.VarChar, 30).Value = SaleTeam.Text;
                        cmd.Parameters.Add("@OrderQty", SqlDbType.VarChar, 20).Value = Qty.Text;
                        //cmd.Parameters.Add("@Greigh", SqlDbType.VarChar, 20).Value = Greigh.Text;
                        cmd.Parameters.Add("@DnV", SqlDbType.VarChar, 20).Value = DnV.Text;
                        cmd.Parameters.Add("@FixedOverhead", SqlDbType.VarChar, 20).Value = FixedOverhead.Text;
                        cmd.Parameters.Add("@Depreciation", SqlDbType.VarChar, 20).Value = Depreciation.Text;
                        cmd.Parameters.Add("@RPM", SqlDbType.VarChar, 20).Value = RPM.Text;
                        cmd.Parameters.Add("@Efficiency", SqlDbType.VarChar, 20).Value = Efficiency.Text;
                        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar,10).Value = Session["EmpCode"];
                        cmd.ExecuteNonQuery();
                        script = "alert('Record saved successfully..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }

                    catch (Exception ex)
                    {
                        script = "alert('" + ex.Message + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
            }
        }
        
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OrderPPL.aspx");
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {

        //sql = "JCT_OPS_PLANNING_FREEZED_PLAN_DETAILS";
        sql = "JCT_OPS_PLANNING_FREEZED_PLAN_DETAILS_CostingPPL";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable dt = ds.Tables[0];


        string attachment = "attachment; filename=Freezed_ProductionPlan.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

        obj.ConClose();
    }

    protected void lnkCalc_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_OPS_PLANNING_FREEZED_PLAN_DETAILS_Fresh_PPL";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = "";
            cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = "";
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = "";
            cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = "";
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];


            string attachment = "attachment; filename=PPL.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();

            obj.ConClose();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
      

    }

}