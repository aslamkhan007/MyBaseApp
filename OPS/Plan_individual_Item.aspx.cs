using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_Plan_individual_Item : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                String OrderNo = Request.QueryString["OrderNo"];

                String LineItem = Request.QueryString["LineItem"];
                string PlanID = Request.QueryString["PlanID"];
                ViewState["ID"] = Convert.ToInt16(Request.QueryString["ID"]);

                string sql = "SELECT [PLANID],[Description] FROM [JCT_OPS_PLANNING_GENERATE_PLANID] WHERE ([STATUS] = 'A') and PlanID='" + PlanID + "'";
                obj1.FillList(ddlPlanID, sql);

                //ddlPlanID.DataSourceID = "SqlDataSource2";
                //ddlPlanID.DataTextField = "Description";
                //ddlPlanID.DataValueField = "PlanID";
                //ddlPlanID.DataBind();

                sql = "JCT_OPS_PLANNING_INDIVIDUAL_ITEMS";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 30).Value = OrderNo;
                cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = LineItem;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblOrder_PlanItem.Text = dr["OrderNo"].ToString();
                        lblSort_PlanItem.Text = dr["SortNo"].ToString();
                        lblLineItem_PlanItem.Text = dr["LineItem"].ToString();
                        txtWeavingSort_PlanItem.Text = dr["WeavingSort"].ToString();
                        lblShade_PlanItem.Text = dr["Shade"].ToString();
                        lblDeliveryDate_PlanItem.Text = dr["DeliveryDt"].ToString();
                        txtExpectedDelivery_PlanItem.Text = dr["Expected_DeliveryDt"].ToString();
                        txtGreighDate_PlanItem.Text = dr["Greigh_ReqDt"].ToString();
                        lblOrderQty_PlanItem.Text = dr["OrderQty"].ToString();
                        txtPlanQty_PlanItem.Text = dr["PlanQty"].ToString();
                        ddlGreigh_PlanItem.SelectedIndex = ddlGreigh_PlanItem.Items.IndexOf(ddlGreigh_PlanItem.Items.FindByText(dr["CaseType"].ToString()));
                        txtGreighReq_PlanItem.Text = dr["GreighReq"].ToString();
                        txtGreighAdj_PlanItem.Text = dr["GreighAdj"].ToString();
                        txtGreighRem_PlanItem.Text = dr["GreighRem"].ToString();
                        txtSizing_PlanItem.Text = dr["Sizing"].ToString();
                        ddlShed_PlanItem.SelectedIndex = ddlShed_PlanItem.Items.IndexOf(ddlShed_PlanItem.Items.FindByValue(dr["Shed"].ToString()));
                        txtLooms_PlanItem.Text = dr["Looms"].ToString();
                        lblWvgDays_PlanItem.Text = dr["WvgDays"].ToString();
                        lblSplit_PlanItem.Text = dr["Split"].ToString();
                        lblIPlan_PlanItem.Text = dr["IndividualPlan"].ToString();
                        txtRPM_PlanItem.Text = dr["RPM"].ToString();
                        txtEfficiency_PlanItem.Text = dr["Efficiency"].ToString();

                    }
                }
                dr.Close();
                obj.ConClose();
            }
        }

        catch(Exception ex) {
           string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
      
    }
    protected void txtExpectedDelivery_PlanItem_TextChanged(object sender, EventArgs e)
    {
        try
        {
            sql = "Select Convert(varchar,'" + txtExpectedDelivery_PlanItem.Text + "' -15,101)";
            txtGreighDate_PlanItem.Text = obj1.FetchValue(sql).ToString();
        }
        catch
        {

        }

    }
    protected void ddlGreigh_PlanItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGreigh_PlanItem.SelectedIndex == 1)
        {
            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPlanQty_PlanItem.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = ddlGreigh_PlanItem.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(lblOrderQty_PlanItem.Text);

            if (txtGreighAdj_PlanItem.Text != string.Empty)
            {
                cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGreighAdj_PlanItem.Text);
            }
            
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtGreighReq_PlanItem.Text = dr["Greigh"].ToString();
                    txtSizing_PlanItem.Text = dr["Sizing"].ToString();
                    txtGreighAdj_PlanItem.Text = "0.0";
                    double greighRem = double.Parse(txtGreighReq_PlanItem.Text);
                    greighRem = Math.Round(greighRem, 2);
                    txtGreighRem_PlanItem.Text = greighRem.ToString();
                }
            }
            dr.Close();


            //sql = "EXEC JCT_OPS_WEAVING_SIZING " + txtGreighRem_PlanItem.Text + ",  '" + txtWeavingSort_PlanItem.Text + "','" + lblOrder_PlanItem.Text + "'," + lblLineItem_PlanItem.Text + ",'N'";
            //txtSizing_PlanItem.Text = obj1.FetchValue(sql).ToString();
            //txtGreighRem_PlanItem.Text = txtSizing_PlanItem.Text;
            //sql = "SELECT dbo.udf_GetNumDaysInMonth(getdate()) NumDaysInMonth";
            //float Looms = float.Parse(txtGreighRem_PlanItem.Text) / float.Parse(obj1.FetchValue(sql).ToString());
            //txtLooms_PlanItem.Text = Looms.ToString();

            txtLooms_PlanItem.Text = "0";


        }
        else
        {

            sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPlanQty_PlanItem.Text);
            cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = ddlGreigh_PlanItem.SelectedItem.Text;
            cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(lblOrderQty_PlanItem.Text);

            if (txtGreighAdj_PlanItem.Text != string.Empty)
            {
                cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGreighAdj_PlanItem.Text);
            }

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtGreighReq_PlanItem.Text = dr["Greigh"].ToString();
                    txtSizing_PlanItem.Text = dr["Sizing"].ToString();
                    txtGreighAdj_PlanItem.Text = "0.0";

                    double greighRem = double.Parse(txtGreighReq_PlanItem.Text);

                    greighRem = Math.Round(greighRem, 2);
                    txtGreighRem_PlanItem.Text = greighRem.ToString();
                    txtGreighReq_PlanItem.Text = greighRem.ToString();
                }
            }
            dr.Close();


            //sql = "EXEC JCT_OPS_WEAVING_SIZING " + txtGreighRem_PlanItem.Text + ",  '" + txtWeavingSort_PlanItem.Text + "','" + lblOrder_PlanItem.Text + "'," + lblLineItem_PlanItem.Text + ",'N'";
            //txtSizing_PlanItem.Text = obj1.FetchValue(sql).ToString();
            //txtGreighRem_PlanItem.Text = txtSizing_PlanItem.Text;
            //sql = "SELECT dbo.udf_GetNumDaysInMonth(getdate()) NumDaysInMonth";
            //float Looms = float.Parse(txtGreighRem_PlanItem.Text) / float.Parse(obj1.FetchValue(sql).ToString());
            //txtLooms_PlanItem.Text = Looms.ToString();

            txtLooms_PlanItem.Text = "0";

        }

    }
    protected void ddlShed_PlanItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            sql = "SELECT loom_rpm,efficiency FROM production..jct_fabric_dev_hdr WHERE loom_sec=left('" + ddlShed_PlanItem.SelectedItem.Value + "',1) AND sort_no='" + txtWeavingSort_PlanItem.Text + "' AND rev_no =(SELECT MAX(rev_no) FROM production..jct_fabric_dev_hdr where loom_sec=left('" + ddlShed_PlanItem.SelectedItem.Value + "',1) AND sort_no='" + txtWeavingSort_PlanItem.Text + "' )";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtRPM_PlanItem.Text = dr[0].ToString();
                    txtEfficiency_PlanItem.Text = dr[1].ToString();
                }
            }
            dr.Close();

            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtWeavingSort_PlanItem.Text);
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = ddlShed_PlanItem.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(txtEfficiency_PlanItem.Text);
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRPM_PlanItem.Text);
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(txtLooms_PlanItem.Text);
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGreighRem_PlanItem.Text);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblWvgDays_PlanItem.Text = dr[6].ToString();
                    txtRPM_PlanItem.Text = dr[1].ToString();
                    txtEfficiency_PlanItem.Text = dr[4].ToString();
                }
            }
            else
            {
                lblWvgDays_PlanItem.Text = "0";
                //RPM.Text = "0";
                // Efficiency.Text = "0";

            }
            dr.Close();

        }
        catch
        {

        }
    }
    protected void txtLooms_PlanItem_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (decimal.Parse(txtLooms_PlanItem.Text) != 0)
            {

                float GreighReq = float.Parse(txtGreighReq_PlanItem.Text);
                float GreighAdj = txtGreighAdj_PlanItem.Text == "" ? 0 : float.Parse(txtGreighAdj_PlanItem.Text);

                float GreighRem = float.Parse(txtGreighRem_PlanItem.Text);

                sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtWeavingSort_PlanItem.Text);
                cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = ddlShed_PlanItem.SelectedItem.Value;
                cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = Convert.ToDecimal(txtEfficiency_PlanItem.Text);
                cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRPM_PlanItem.Text);
                cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = Convert.ToDecimal(txtLooms_PlanItem.Text);
                cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = GreighRem;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblWvgDays_PlanItem.Text = dr[6].ToString();
                    }
                }
                else
                {
                    lblWvgDays_PlanItem.Text = "0";
                }
                dr.Close();
            }
        }
        catch
        {

        }

    }
    protected void txtRPM_PlanItem_TextChanged(object sender, EventArgs e)
    {
        if (decimal.Parse(txtLooms_PlanItem.Text) != 0)
        {

            float GreighReq = float.Parse(txtGreighReq_PlanItem.Text);
            float GreighAjd = float.Parse(txtGreighAdj_PlanItem.Text);
            //float GreighRem = float.Parse(Sizing.Text) - GreighAjd;
            float GreighRem = float.Parse(txtGreighRem_PlanItem.Text);
            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = txtWeavingSort_PlanItem.Text;
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = ddlShed_PlanItem.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = txtEfficiency_PlanItem.Text;
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = txtRPM_PlanItem.Text;
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = txtLooms_PlanItem.Text;
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = GreighRem;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblWvgDays_PlanItem.Text = dr[6].ToString();
                }
            }
            else
            {
                lblWvgDays_PlanItem.Text = "0";
            }
            dr.Close();

        }
    }
    protected void txtEfficiency_PlanItem_TextChanged(object sender, EventArgs e)
    {
        if (decimal.Parse(txtLooms_PlanItem.Text) != 0)
        {

            float GreighReq = float.Parse(txtGreighReq_PlanItem.Text);
            float GreighAjd = float.Parse(txtGreighAdj_PlanItem.Text);
            //float GreighRem = float.Parse(Sizing.Text) - GreighAjd;
            float GreighRem = float.Parse(txtGreighRem_PlanItem.Text);
            sql = "JCT_OPS_WEAVING_COMPLETION_DAYS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORT", SqlDbType.Decimal).Value = txtWeavingSort_PlanItem.Text;
            cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 10).Value = ddlShed_PlanItem.SelectedItem.Value;
            cmd.Parameters.Add("@EFFICIENCY", SqlDbType.Decimal).Value = txtEfficiency_PlanItem.Text;
            cmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = txtRPM_PlanItem.Text;
            cmd.Parameters.Add("@LOOMS", SqlDbType.Decimal).Value = txtLooms_PlanItem.Text;
            cmd.Parameters.Add("@GREIGHREQUIRED", SqlDbType.Decimal).Value = GreighRem;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblWvgDays_PlanItem.Text = dr[6].ToString();
                }
            }
            else
            {
                lblWvgDays_PlanItem.Text = "0";
            }
            dr.Close();

        }
    }
    protected void txtGreighAdj_PlanItem_TextChanged(object sender, EventArgs e)
    {
        if (txtGreighReq_PlanItem.Text != "0")
        {

            if (ddlGreigh_PlanItem.SelectedIndex == 1)
            {
                sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPlanQty_PlanItem.Text);
                cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = ddlGreigh_PlanItem.SelectedItem.Text;
                cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(lblOrderQty_PlanItem.Text);

                if (txtGreighAdj_PlanItem.Text != string.Empty)
                {
                    cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGreighAdj_PlanItem.Text);
                }

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtGreighReq_PlanItem.Text = dr["Greigh"].ToString();
                        txtSizing_PlanItem.Text = dr["Sizing"].ToString();

                        double greighRem = double.Parse(txtGreighReq_PlanItem.Text) - double.Parse(txtGreighAdj_PlanItem.Text);
                        greighRem = Math.Round(greighRem, 2);
                        txtGreighRem_PlanItem.Text = greighRem.ToString();
                    }
                }
                dr.Close();
                txtLooms_PlanItem.Text = "0";


            }
            else
            {

                sql = "JCT_OPS_PLANNING_GREIGH_REQUEST_VARIANTION";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PLANQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPlanQty_PlanItem.Text);
                cmd.Parameters.Add("@CASETYPE", SqlDbType.VarChar, 30).Value = ddlGreigh_PlanItem.SelectedItem.Text;
                cmd.Parameters.Add("@ORDERQTY", SqlDbType.Decimal).Value = Convert.ToDecimal(lblOrderQty_PlanItem.Text);

                if (txtGreighAdj_PlanItem.Text != string.Empty)
                {
                    cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGreighAdj_PlanItem.Text);
                }

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtGreighReq_PlanItem.Text = dr["Greigh"].ToString();
                        txtSizing_PlanItem.Text = dr["Sizing"].ToString();

                        double greighRem = double.Parse(txtGreighReq_PlanItem.Text) - double.Parse(txtGreighAdj_PlanItem.Text);
                        greighRem = Math.Round(greighRem, 2);
                        txtGreighRem_PlanItem.Text = greighRem.ToString();
                        //txtGreighReq_PlanItem.Text = greighRem.ToString();
                    }
                }
                dr.Close();
                txtLooms_PlanItem.Text = "0";
            }
        }
    }

    protected void txtPlanQty_PlanItem_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox PlanQty = (TextBox)sender;
            //GridViewRow gvRow = (GridViewRow)PlanQty.Parent.Parent;

            //Label Split = (Label)gvRow.FindControl("lblSplit_PlanItem");
            //Label IndividualPlan = (Label)gvRow.FindControl("lblIPlan_PlanItem");

            decimal OrderQty = Convert.ToDecimal(lblOrderQty_PlanItem.Text);
            decimal planQty = Convert.ToDecimal(PlanQty.Text);

            if (OrderQty > planQty)
            {
                lblSplit_PlanItem.Text = "Y";
                lblIPlan_PlanItem.Text = "Y";
            }
            else if (OrderQty == planQty)
            {
                lblSplit_PlanItem.Text = "N";
                lblIPlan_PlanItem.Text = "N";
            }
            else if (OrderQty < planQty)
            {
                PlanQty.Text = "";
                string script = "alert('PlanQty is greater than Order Qty..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }
        catch
        {

        }
    }

    protected void lnkSubmit_PlanItem_Click(object sender, EventArgs e)
    {
        try
        {

            sql = "JCT_OPS_PLANING_ORDER_ITEMS_INSERT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = lblOrder_PlanItem.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = lblSort_PlanItem.Text;
            cmd.Parameters.Add("@LineItem", SqlDbType.VarChar, 30).Value = lblLineItem_PlanItem.Text;
            cmd.Parameters.Add("@Qty", SqlDbType.VarChar, 30).Value = lblOrderQty_PlanItem.Text;
            cmd.Parameters.Add("@PlanQty", SqlDbType.VarChar, 30).Value = txtPlanQty_PlanItem.Text;
            cmd.Parameters.Add("@CaseType", SqlDbType.VarChar, 30).Value = ddlGreigh_PlanItem.SelectedItem.Text;
            cmd.Parameters.Add("@GreighReq", SqlDbType.VarChar, 30).Value = txtGreighReq_PlanItem.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@Plan_ID", SqlDbType.VarChar, 20).Value = ddlPlanID.SelectedItem.Value;
            cmd.Parameters.Add("@DeliveryDt", SqlDbType.VarChar, 50).Value = txtExpectedDelivery_PlanItem.Text;
            cmd.Parameters.Add("@Shade1", SqlDbType.VarChar, 50).Value = lblShade_PlanItem.Text;
            cmd.Parameters.Add("@Split", SqlDbType.Char, 1).Value = lblSplit_PlanItem.Text;
            cmd.Parameters.Add("@IndividualPlan", SqlDbType.Char, 1).Value = lblIPlan_PlanItem.Text;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(ViewState["ID"]);
            cmd.Parameters.Add("@ParentID", SqlDbType.Char, 20).Value = "";
            if (txtSizing_PlanItem.Text != string.Empty)
            {
                cmd.Parameters.Add("@sizing", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSizing_PlanItem.Text);
            }
            else
            {
                return;
            }

            if (txtGreighAdj_PlanItem.Text != string.Empty)
            {
                cmd.Parameters.Add("@greigh_adj", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGreighAdj_PlanItem.Text);
            }
            cmd.ExecuteNonQuery();
            
            sql = "JCT_OPS_PLANNING_ORDER_INSERT";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Char, 10).Value = "";
            cmd.Parameters.Add("@PLANID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value;
            cmd.Parameters.Add("@Orderno", SqlDbType.VarChar, 25).Value = lblOrder_PlanItem.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 25).Value = lblSort_PlanItem.Text;
            cmd.Parameters.Add("@WeavingSort", SqlDbType.Int).Value = txtWeavingSort_PlanItem.Text;
            cmd.Parameters.Add("@OrderQty", SqlDbType.Decimal).Value = Convert.ToDecimal(lblOrderQty_PlanItem.Text);
            cmd.Parameters.Add("@PlanQty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPlanQty_PlanItem.Text);
            cmd.Parameters.Add("@DeliveryDt", SqlDbType.VarChar, 20).Value = lblDeliveryDate_PlanItem.Text;
            cmd.Parameters.Add("@ExpectedDeliveryDt", SqlDbType.VarChar, 20).Value = txtExpectedDelivery_PlanItem.Text;
            cmd.Parameters.Add("@GreighReqDt", SqlDbType.VarChar, 20).Value = txtGreighDate_PlanItem.Text;
            cmd.Parameters.Add("@GreighReq", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGreighReq_PlanItem.Text);
            cmd.Parameters.Add("@GreighAdj", SqlDbType.Decimal).Value = Convert.ToDecimal((txtGreighAdj_PlanItem.Text == "" ? 0 : Convert.ToDecimal(txtGreighAdj_PlanItem.Text)));
            cmd.Parameters.Add("@GreighRem", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGreighRem_PlanItem.Text);
            cmd.Parameters.Add("@Sizing", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSizing_PlanItem.Text);
            cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ddlShed_PlanItem.SelectedItem.Value;
            cmd.Parameters.Add("@Efficiency", SqlDbType.Int).Value = Convert.ToInt16(txtEfficiency_PlanItem.Text);
            cmd.Parameters.Add("@RPM", SqlDbType.Int).Value = Convert.ToInt16(txtRPM_PlanItem.Text);
            cmd.Parameters.Add("@Looms", SqlDbType.Decimal).Value = Convert.ToDecimal(txtLooms_PlanItem.Text);
            cmd.Parameters.Add("@WvgDays", SqlDbType.Decimal).Value = Convert.ToDecimal(lblWvgDays_PlanItem.Text);
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@LineItem", SqlDbType.VarChar, 10).Value = lblLineItem_PlanItem.Text;
            cmd.ExecuteNonQuery();

            string script = "alert('Order Item Planned Successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch (Exception ex)
        {
            string script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
      
    }
}
