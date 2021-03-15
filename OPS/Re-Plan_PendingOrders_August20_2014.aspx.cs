using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_Re_Plan_PendingOrders : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlPlanID.DataSourceID = "SqlDataSource2";
            ddlPlanID.DataBind();

            ddlNewPlan.DataSourceID = "SqlDataSource1";
            ddlNewPlan.DataBind();
        }
            
          
       
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_PLANNING_PENDING_ORDERS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PlanID", SqlDbType.Decimal).Value = ddlPlanID.SelectedItem.Value;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar,25).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 25).Value = txtWeavingSort.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlPlant.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdRePlan.DataSource = ds.Tables[0];
        grdRePlan.DataBind();

        for (int n = 0; n <= grdRePlan.Rows.Count - 1; n++)
        {
            Label ID = (Label)grdRePlan.Rows[n].FindControl("lblID");
            Label OrderNo = (Label)grdRePlan.Rows[n].FindControl("lblOrderNo");
            TextBox WeavingSort = (TextBox)grdRePlan.Rows[n].FindControl("txtWeavingSort");

            //sql = "Select * from JCT_OPS_PLANNING_ORDER_Jatin where TransNo=" + ID.Text + " and RePlan='Y' ";
            sql = "Select * from JCT_OPS_PLANNING_ORDER where order_no='" + OrderNo.Text + "' AND Weaving_Sort=" + WeavingSort.Text + " and  RePlan='Y' and Status='A' and planid=" + ddlNewPlan.SelectedItem.Value + "   ";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                grdRePlan.Rows[n].Enabled = false;
            }
        }
    }

    protected void grdRePlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            grdRePlan.PageIndex = e.NewPageIndex;
            sql = "JCT_OPS_PLANNING_PENDING_ORDERS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlanID", SqlDbType.Decimal).Value = ddlPlanID.SelectedItem.Value;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 25).Value = txtWeavingSort.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlPlant.SelectedItem.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdRePlan.DataSource = ds.Tables[0];
            grdRePlan.DataBind();

            for (int n = 0; n <= grdRePlan.Rows.Count - 1; n++)
            {
                Label ID = (Label)grdRePlan.Rows[n].FindControl("lblID");
                Label OrderNo = (Label)grdRePlan.Rows[n].FindControl("lblOrderNo");
                TextBox WeavingSort = (TextBox)grdRePlan.Rows[n].FindControl("txtWeavingSort");

                //sql = "Select * from JCT_OPS_PLANNING_ORDER_Jatin where TransNo=" + ID.Text + " and RePlan='Y' ";
                sql = "Select * from JCT_OPS_PLANNING_ORDER where order_no='" + OrderNo.Text + "' AND Weaving_Sort=" + WeavingSort.Text + " and  RePlan='Y' and Status='A' and planid=" + ddlNewPlan.SelectedItem.Value + "   ";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    grdRePlan.Rows[n].Enabled = false;
                }
            }
            
        }
        catch { 
            
        }
    
    }
    
    protected void chbSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbHeader = (CheckBox)grdRePlan.HeaderRow.FindControl("chbSelectAll");
        if (cbHeader.Checked == true)
        {
            for (int k = 0; k <= grdRePlan.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)grdRePlan.Rows[k].FindControl("chbSelect");
                myCheckBox.Checked = true;
            }
        }
        else if (cbHeader.Checked == false)
        {
            for (int k = 0; k <= grdRePlan.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)grdRePlan.Rows[k].FindControl("chbSelect");
                myCheckBox.Checked = false;
            }
        }
    }

    protected void txtLoomAllot_TextChanged(object sender, EventArgs e)
    {
        try
        {

            TextBox Looms = (TextBox)sender;

            GridViewRow gridRow = (GridViewRow)Looms.Parent.Parent;
            Label PlanID = (Label)gridRow.FindControl("lblPlanID");
            Label ID = (Label)gridRow.FindControl("lblID");
            Label Plan_Qty = (Label)gridRow.FindControl("lblPlanQty");
            Label Orderno = (Label)gridRow.FindControl("lblOrderNo");
            TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
            Label SizingDone = (Label)gridRow.FindControl("lblSizingDone");
            TextBox SizingRem = (TextBox)gridRow.FindControl("lblSizingRem");
            DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
            TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
            Label WvgDays = (Label)gridRow.FindControl("lblWvgDays");
            TextBox RPM = (TextBox)gridRow.FindControl("txtRPM");
            TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");


            if (decimal.Parse(Looms.Text) != 0)
            {

             
                float SizingRemaninig = float.Parse(SizingRem.Text);    



                sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(WeavingSort.Text);
                cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
                cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(Efficiency.Text == "" ? 0 : Convert.ToDecimal(Efficiency.Text));
                cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(RPM.Text == "" ? 0 : Convert.ToDecimal(RPM.Text));
                cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(Looms.Text == "" ? 1 : Convert.ToDecimal(Looms.Text));
                cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(SizingRem.Text == "" ? 0 : Convert.ToDecimal(SizingRem.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        WvgDays.Text = dr[6].ToString();
                    }
                }
                else
                {
                    WvgDays.Text = "0";
                    string script = "alert('No data found for sortno - " + WeavingSort.Text + " to be weaved in " + Shed.SelectedItem.Text + " Loom Shed.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }
                dr.Close();

            }
            else
            {


            }
        }
        catch (Exception ex)
        {
            string script = string.Format("alert('{0}');", "Please Select Shed Name First..!!");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
            return;
        }
    }

    protected void ddlShed_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList Shed = (DropDownList)sender;
            GridViewRow gridRow = (GridViewRow)Shed.Parent.Parent;
            Label Plan_Qty = (Label)gridRow.FindControl("lblPlanQty");
            Label Orderno = (Label)gridRow.FindControl("lblOrderNo");
            TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
            Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
            TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");

            Label WvgDays = (Label)gridRow.FindControl("lblWvgDays");
            TextBox Looms = (TextBox)gridRow.FindControl("txtLoomAllot");
            TextBox RPM = (TextBox)gridRow.FindControl("txtRPM");
            TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");
            Label SizingDone = (Label)gridRow.FindControl("lblSizingDone");
            TextBox SizingRem = (TextBox)gridRow.FindControl("lblSizingRem");


            sql = "SELECT loom_rpm,efficiency FROM production..jct_fabric_dev_hdr WHERE loom_sec=left('" + Shed.SelectedItem.Value + "',1) AND sort_no='" + WeavingSort.Text + "' AND rev_no =(SELECT MAX(rev_no) FROM production..jct_fabric_dev_hdr where loom_sec=left('" + Shed.SelectedItem.Value + "',1) AND sort_no='" + WeavingSort.Text + "' )";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    RPM.Text = dr[0].ToString();
                    Efficiency.Text = dr[1].ToString();
                }
            }
            dr.Close();

            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(WeavingSort.Text);
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(Efficiency.Text == "" ? 0 : Convert.ToDecimal(Efficiency.Text));
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(RPM.Text == "" ? 0 : Convert.ToDecimal(RPM.Text));
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(Looms.Text == "" ? 1 : Convert.ToDecimal(Looms.Text));
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(SizingRem.Text == "" ? 0 : Convert.ToDecimal(SizingRem.Text));
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    WvgDays.Text = dr[6].ToString();
                    if (WvgDays.Text == "0")
                    {
                      string  script = "alert('No data found for this sort to be weaved in Selected Loom Shed.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }

                    RPM.Text = dr[1].ToString();
                    Efficiency.Text = dr[4].ToString();
                    Looms.Text = "1";
                }
            }
            else
            {
                WvgDays.Text = "0";
                string  script = "alert('No data found for sortno - " + WeavingSort.Text + " to be weaved in " + Shed.SelectedItem.Text + " Loom Shed.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
                //RPM.Text = "0";
                // Efficiency.Text = "0";

            }
            dr.Close();



        }
        catch (Exception ex)
        {
           string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void txtRPM_TextChanged(object sender, EventArgs e)
    {
        TextBox RPM = (TextBox)sender;
        GridViewRow gridRow = (GridViewRow)RPM.Parent.Parent;

        Label Plan_Qty = (Label)gridRow.FindControl("lblPlanQty");
        Label Orderno = (Label)gridRow.FindControl("lblOrderNo");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
        Label SizingDone = (Label)gridRow.FindControl("lblSizingDone");
        TextBox SizingRem = (TextBox)gridRow.FindControl("lblSizingRem");
        TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");
        TextBox Looms = (TextBox)gridRow.FindControl("txtLoomAllot");
        Label WvgDays = (Label)gridRow.FindControl("lblWvgDays");


        if (decimal.Parse(Looms.Text) != 0)
        {
            
            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(WeavingSort.Text);
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(Efficiency.Text == "" ? 0 : Convert.ToDecimal(Efficiency.Text));
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(RPM.Text == "" ? 0 : Convert.ToDecimal(RPM.Text));
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(Looms.Text == "" ? 1 : Convert.ToDecimal(Looms.Text));
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(SizingRem.Text == "" ? 0 : Convert.ToDecimal(SizingRem.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    WvgDays.Text = dr[6].ToString();
                }
            }
            else
            {
                WvgDays.Text = "0";
              string  script = "alert('No data found for sortno - " + WeavingSort.Text + " to be weaved in " + Shed.SelectedItem.Text + " Loom Shed.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
            dr.Close();

        }
    }

    protected void txtEfficiency_TextChanged(object sender, EventArgs e)
    {
        TextBox Efficiency = (TextBox)sender;

        GridViewRow gridRow = (GridViewRow)Efficiency.Parent.Parent;


        Label Plan_Qty = (Label)gridRow.FindControl("lblPlanQty");
        
        
        Label Orderno = (Label)gridRow.FindControl("lblOrderNo");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
        Label SizingDone = (Label)gridRow.FindControl("lblSizingDone");
        Label SizingRem = (Label)gridRow.FindControl("lblSizingRem");
        TextBox RPM = (TextBox)gridRow.FindControl("txtRPM");
        TextBox Looms = (TextBox)gridRow.FindControl("txtLoomAllot");
        Label WvgDays = (Label)gridRow.FindControl("lblWvgDays");


        if (decimal.Parse(Looms.Text) != 0)
        {
            
            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(WeavingSort.Text);
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = Shed.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(Efficiency.Text == "" ? 0 : Convert.ToDecimal(Efficiency.Text));
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(RPM.Text == "" ? 0 : Convert.ToDecimal(RPM.Text));
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(Looms.Text == "" ? 1 : Convert.ToDecimal(Looms.Text));
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(SizingRem.Text == "" ? 0 : Convert.ToDecimal(SizingRem.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    WvgDays.Text = dr[6].ToString();
                }
            }
            else
            {
                WvgDays.Text = "0";
                string script = "alert('No data found for sortno - " + WeavingSort.Text + " to be weaved in " + Shed.SelectedItem.Text + " Loom Shed.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
            dr.Close();

        }
    }

    protected void lnkRePlan_Click(object sender, EventArgs e)
    {
    
        try
        {

            for (int n = 0; n <= grdRePlan.Rows.Count - 1; n++)
            {
                if (grdRePlan.Rows[n].Enabled == true)
                {
                    CheckBox chb = (CheckBox)grdRePlan.Rows[n].FindControl("chbSelect");
                    if (chb.Checked == true)
                    {
                        Label PlanID = (Label)grdRePlan.Rows[n].FindControl("lblPlanID");
                        Label ID = (Label)grdRePlan.Rows[n].FindControl("lblID");
                        Label OrderNo = (Label)grdRePlan.Rows[n].FindControl("lblOrderNo");
                        Label SizingDone = (Label)grdRePlan.Rows[n].FindControl("lblSizingDone");
                        TextBox SizingReq = (TextBox)grdRePlan.Rows[n].FindControl("txtSizing");
                        TextBox SizingRem = (TextBox)grdRePlan.Rows[n].FindControl("lblSizingRem");
                        DropDownList Shed = (DropDownList)grdRePlan.Rows[n].FindControl("ddlShed");
                        TextBox WeavingSort = (TextBox)grdRePlan.Rows[n].FindControl("txtWeavingSort");
                        Label WvgDays = (Label)grdRePlan.Rows[n].FindControl("lblWvgDays");
                        TextBox RPM = (TextBox)grdRePlan.Rows[n].FindControl("txtRPM");
                        TextBox Efficiency = (TextBox)grdRePlan.Rows[n].FindControl("txtEfficiency");
                        TextBox Looms = (TextBox)grdRePlan.Rows[n].FindControl("txtLoomAllot");
                        TextBox GreigeRem = (TextBox)grdRePlan.Rows[n].FindControl("txtGreigeRem");

                        sql = "JCT_OPS_PLANNING_REPLAN_PENDING_ORDERS";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@PlanID", SqlDbType.VarChar, 20).Value = ddlNewPlan.SelectedItem.Text;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID.Text;
                        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = OrderNo.Text;
                        cmd.Parameters.Add("@Sizing", SqlDbType.Decimal).Value = SizingReq.Text;
                        cmd.Parameters.Add("@SizingDone", SqlDbType.Decimal).Value = SizingDone.Text;
                        cmd.Parameters.Add("@UnSized", SqlDbType.Decimal).Value = SizingRem.Text;
                        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = WeavingSort.Text;
                        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 50).Value = Shed.SelectedItem.Value;
                        cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = RPM.Text;
                        cmd.Parameters.Add("@Efficiency", SqlDbType.Decimal).Value = Efficiency.Text;
                        cmd.Parameters.Add("@Looms", SqlDbType.Decimal).Value = 0;//Looms.Text;
                        cmd.Parameters.Add("@WvgDays", SqlDbType.Decimal).Value = WvgDays.Text;
                        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                        cmd.Parameters.Add("@NewPlanID", SqlDbType.VarChar, 10).Value = ddlNewPlan.SelectedItem.Value;
                        cmd.Parameters.Add("@GreigeRem", SqlDbType.Decimal).Value = GreigeRem.Text;
                        cmd.ExecuteNonQuery();

                        grdRePlan.Rows[n].Enabled = false;

                    }
                }
            }
            
            string script = "alert('Items Re-Planned Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }

        catch(Exception ex) {

            string script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        
    }

    protected void lnkStop_Click(object sender, EventArgs e)
    {
        LinkButton Stop = (LinkButton)sender;

        GridViewRow gridRow = (GridViewRow)Stop.Parent.Parent;
        Label ID = (Label)gridRow.FindControl("lblID");
        Label Plan_Qty = (Label)gridRow.FindControl("lblPlanQty");
        Label Orderno = (Label)gridRow.FindControl("lblOrderNo");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("txtWeavingSort");
        Label SizingDone = (Label)gridRow.FindControl("lblSizingDone");
        TextBox SizingRem = (TextBox)gridRow.FindControl("lblSizingRem");
        TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");
        TextBox Looms = (TextBox)gridRow.FindControl("txtLoomAllot");
        Label WvgDays = (Label)gridRow.FindControl("lblWvgDays");

        sql = "Update jct_ops_planning_order set Status='S' where TransNo="+ ID;
        obj1.UpdateRecord(sql);

        string script = "alert('Order Closed. No More Sizing will be done..!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    protected void ddlPlant_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_PLANNING_PENDING_ORDERS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PlanID", SqlDbType.Decimal).Value = ddlPlanID.SelectedItem.Value;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 25).Value = txtWeavingSort.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlPlant.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable dt = ds.Tables[0];


        string attachment = "attachment; filename=PendingOrders.xls";
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
}