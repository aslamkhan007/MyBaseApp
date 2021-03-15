using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

public partial class OPS_SetPriority_WeavePlan : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    String script;
    int Priority = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                sql = " Select '' as [team_code],'' as [team_description] Union  SELECT team_code,team_description FROM MISERP.SOM.DBO.jct_team_mASter where team_code not in ('Wardrobe','Domestic','Sales Team')  ORDER BY team_code   ";
                obj1.FillList(ddlSalesTeam, sql);
                if (ddlSalesTeam.SelectedItem.Text == "")
                {
                    sql = "SELECT  '' as group_desc, '' as group_no Union Select group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
                    obj1.FillList(ddlSalesPerson, sql);
                }
                else
                {
                    ddlSalesPerson.Items.Clear();
                    sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
                    obj1.FillList(ddlSalesPerson, sql);
                }
               FillRadioButton();
               
               //FillGrid();
            }

       
        }
        catch (Exception ex)
        {
            script = "alert(Error : '" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
      
       
    }

    protected void FillRadioButton()
    {
        sql = "SELECT DISTINCT order_no FROM dbo.JCT_OPS_MONTHLY_PLANNING WHERE Mode='Freezed'";
        obj1.FillList(rblSaleOrder,sql);
    }

    protected void FillRblSortNo()
    {
        sql = "SELECT distinct Weaving_Sort FROM dbo.JCT_OPS_MONTHLY_PLANNING WHERE order_no=@Orderno AND Mode =@Mode AND yearmonth=@yearmonth ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("OrderNo", SqlDbType.VarChar, 20).Value = rblSaleOrder.SelectedItem.Text;
        cmd.Parameters.Add("Mode", SqlDbType.VarChar, 20).Value = "Freezed";
        cmd.Parameters.Add("yearmonth", SqlDbType.Int).Value = ddlPlanMonth.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        rblSortNo.DataSource = ds;
        rblSortNo.DataBind();
    }

    protected void rblSaleOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSaleOrder.SelectedItem.Selected == true)
        {
            txtOrderNo.Text = rblSaleOrder.SelectedItem.Text;
            pnlPrioritisedOrders.Visible = true;
            pnlPlannedOrders.Visible = true;
            FillRblSortNo();
           // FillGrid();
        }

    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        pnlPrioritisedOrders.Visible = true;
        pnlPlannedOrders.Visible = true;
        FillGrid();
    }

    protected void FillGrid()
    {
        sql = "JCT_OPS_PLANNING_PRIORITY";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text.Trim();//rblSaleOrder.SelectedItem.Text;//
        cmd.Parameters.Add("@SALETEAM", SqlDbType.VarChar, 20).Value = ddlSalesTeam.SelectedItem.Text;
        cmd.Parameters.Add("@SALEPERSON", SqlDbType.VarChar, 10).Value = ddlSalesPerson.SelectedItem.Value;
        cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar, 20).Value = txtCustomer.Text;
        cmd.Parameters.Add("@SORTNO", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
        cmd.Parameters.Add("@YEARMONTH", SqlDbType.Decimal).Value = decimal.Parse(ddlPlanMonth.SelectedItem.Text);
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar,20).Value = ddlPlant.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grd.DataSource = ds;
        grd.DataBind();

       

    }

    protected void grd_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void ddlSalesTeam_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlSalesTeam.SelectedItem.Text == "")
        {
            ddlSalesPerson.Items.Clear();
            sql = "Select '' as group_no, '' as group_desc Union SELECT group_no,group_desc FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'";
            obj1.FillList(ddlSalesPerson, sql);
            pnlPrioritisedOrders.Visible = true;
            pnlPlannedOrders.Visible = true;
          //  FillGrid();
        }
        else
        {

            ddlSalesPerson.Items.Clear();
            sql = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT a.sale_person_code,b.group_desc FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and team_code not in ('Wardrobe','Domestic','Sales Team') and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'";
            obj1.FillList(ddlSalesPerson, sql);
            pnlPrioritisedOrders.Visible = true;
            pnlPlannedOrders.Visible = true;
           // FillGrid();
        }

    }

    protected void ddlSalesPerson_SelectedIndexChanged1(object sender, EventArgs e)
    {
        pnlPrioritisedOrders.Visible = true;
        pnlPlannedOrders.Visible = true;
      //  FillGrid();
    }

    protected void txtCustomer_TextChanged1(object sender, EventArgs e)
    {
        if (txtCustomer.Text != "")
        {
            txtCustomer.Text = txtCustomer.Text.Split('~')[1].ToString();
            pnlPrioritisedOrders.Visible = true;
            pnlPlannedOrders.Visible = true;
           // FillGrid();
        }
        else
        {
            pnlPrioritisedOrders.Visible = true;
            pnlPlannedOrders.Visible = true;
           // FillGrid();
        }
    }

    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        pnlPrioritisedOrders.Visible = true;
        pnlPlannedOrders.Visible = true;
        FillRblSortNo();
       // FillGrid();
    }

    protected void Chb_CheckedChanged(object sender, EventArgs e)
    {   DataTable dt = new DataTable();

    if (ViewState["Priority"] == null && ViewState["data"]== null)
    {
        ViewState["Priority"] = "0";
        dt.Columns.Add("Priority");
        dt.Columns.Add("Customer");
        dt.Columns.Add("OrderNo");
        dt.Columns.Add("SortNo");
        dt.Columns.Add("LineItem");
        dt.Columns.Add("Shade");
        dt.Columns.Add("OrderQty");
        dt.Columns.Add("PlanQty");
        dt.Columns.Add("GreighReq");
        dt.Columns.Add("ORDER_REQ_DT");
        dt.Columns.Add("GREIGH_REQ_DT");
        dt.Columns.Add("EXPECTED_DELIVERY_DT");
        dt.Columns.Add("Shed");
        dt.Columns.Add("Looms");
        dt.Columns.Add("Days");
        ViewState.Add("data", dt);
    }
    else
    {
        dt = (DataTable)ViewState["data"];
    }

   
    //    CheckBox chb = (CheckBox)row.FindControl("Chb");
       // Image img1 = (Image)row.FindControl("img");
        //Image img = sender as Image;
        CheckBox chb = sender as CheckBox;
        GridViewRow grow = (GridViewRow)chb.NamingContainer;
        Image img = (Image)grow.FindControl("img");

        if (chb.Checked == true && chb.Enabled == true)
        {
           
            img.ImageUrl = "~/Image/AvailabilityTrue.png";
            DataRow drow = dt.NewRow();
            drow["Priority"] = int.Parse(ViewState["Priority"].ToString()) + 1;
            drow["Customer"] = grow.Cells[2].Text;
            drow["OrderNo"] = grow.Cells[3].Text;
            drow["SortNo"] = grow.Cells[4].Text;
            drow["LineItem"] = grow.Cells[5].Text;
            drow["Shade"] = grow.Cells[6].Text;
            drow["OrderQty"] = grow.Cells[7].Text;
            drow["PlanQty"] = grow.Cells[8].Text;
            drow["GreighReq"] = grow.Cells[9].Text;
            drow["ORDER_REQ_DT"] = grow.Cells[10].Text;
            drow["GREIGH_REQ_DT"] = grow.Cells[11].Text;
            drow["EXPECTED_DELIVERY_DT"] = grow.Cells[12].Text;
            drow["Shed"] = grow.Cells[13].Text;
            drow["Looms"] = grow.Cells[14].Text;
            drow["Days"] = grow.Cells[15].Text;
            dt.Rows.Add(drow);
            Priority = int.Parse(ViewState["Priority"].ToString()) + 1;
            
            ViewState["Priority"] = Priority;
            if (ViewState["data"] == null)
            {
                ViewState.Add("data", dt);
            }
            else
            {
                ViewState["data"] = dt;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
          
        }
        else if (chb.Checked == true && chb.Enabled == false)
        {
            img.ImageUrl = "~/Image/AvailabilityTrue.png";
        }
        else
        {
            img.ImageUrl = "~/Image/AvailabilityFalse.png";
        }


  
       
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
        foreach (GridViewRow row in GridView1.Rows)
           {
            
            TextBox priority = (TextBox)row.FindControl("txtPriority");
            //row.Cells[2].Text = row.Cells[2].Text.ToString("DD-MM-YYYY");
            String orderno = row.Cells[2].Text;
            String sort = row.Cells[3].Text;
            int lineitem = int.Parse(row.Cells[4].Text);
           
            //DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
            //dtfi.ShortDatePattern = "MM/dd/yyyy";
            //dtfi.DateSeparator = "/";
            sql = "JCT_OPS_PLANNING_SET_PRIORITY_INSERT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YEARMONTH",SqlDbType.Decimal).Value = decimal.Parse(ddlPlanMonth.SelectedItem.Text);
            cmd.Parameters.Add("@PRIORITY_DATEFROM", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateFrom.Text).GetDateTimeFormats('g')[20];
            cmd.Parameters.Add("@PRIORITY_DATETO", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text).GetDateTimeFormats('g')[20];
            cmd.Parameters.Add("@PRIORITY",SqlDbType.Int).Value=int.Parse(priority.Text);
            cmd.Parameters.Add("@ORDERNO",SqlDbType.VarChar,20).Value=orderno;
            cmd.Parameters.Add("@SORT",SqlDbType.VarChar,20).Value=sort;
            cmd.Parameters.Add("@LINEITEM",SqlDbType.Int).Value=lineitem;
            cmd.Parameters.Add("@EMPCODE",SqlDbType.VarChar,10).Value=Session["EmpCode"];
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd.ExecuteNonQuery();
            }
        script = "alert('Records Added Successfully.');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        
        }
        catch (Exception ex)
        {
            script = "alert(Error : '" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
       
       

    }

    protected void txtPriority_TextChanged(object sender, EventArgs e)
    {
        TextBox this_priority = sender as TextBox;
        GridViewRow grow = (GridViewRow)this_priority.NamingContainer;
        try
        { 
          foreach (GridViewRow row in GridView1.Rows)
             {
                 if (row.RowIndex != grow.RowIndex)
                 { 
                     TextBox priority = (TextBox) row.FindControl("txtPriority");
                  if (this_priority.Text == priority.Text)
                  {
                      this_priority.Text = "";
                      this_priority.Focus();
                      script = "alert('Cannot assign same priority to different items.');";
                      ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                      return;
                  } 
                 }
                
             }
        }
      
        catch(Exception ex)
        {
            script = "alert(Error : '" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String orderno = e.Row.Cells[3].Text;
            String sort = e.Row.Cells[4].Text;
            //int priority = int.Parse(e.Row.Cells[4].Text);
            int lineitem = int.Parse(e.Row.Cells[5].Text);
            Image img = (Image)e.Row.FindControl("img");
            CheckBox chb = (CheckBox)e.Row.FindControl("Chb");

            sql = "Select * from JCT_OPS_PLANNING_SET_PRIORITY where orderno=@orderno and sort=@sort and lineitem=@lineitem and status=@status";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = orderno;
            cmd.Parameters.Add("@sort", SqlDbType.VarChar, 10).Value = sort;
            cmd.Parameters.Add("@lineitem", SqlDbType.Int).Value = lineitem;
            cmd.Parameters.Add("@status", SqlDbType.Char).Value = 'A';
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    img.ImageUrl = "~/Image/AvailabilityTrue.png";
                    chb.Checked = true;
                    chb.Enabled = false;
                }
            }
            dr.Close();

        }
    }

    protected void img_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = sender as ImageButton;
        GridViewRow grow = (GridViewRow)img.NamingContainer;
        TextBox priority = (TextBox)grow.FindControl("txtPriority");
        String orderno = grow.Cells[3].Text;
        String sort = grow.Cells[4].Text;
        int lineitem = int.Parse(grow.Cells[5].Text);

        try
        {
            sql = "Select * from JCT_OPS_PLANNING_SET_PRIORITY WHERE ORDERNO='" + orderno + "' AND SORT='" + sort + "' AND LINEITEM =" + lineitem + " AND PRIORITY_DATEFROM ='" + txtDateFrom.Text + "' AND PRIORITY_DATETO='" + txtDateTo.Text + "' AND STATUS='A'";
            if (obj1.CheckRecordExistInTransaction(sql) == true)
            {

                int index = grow.RowIndex;
                DataTable dt = (DataTable)ViewState["data"];
                dt.Rows.RemoveAt(index);
                sql = "Update JCT_OPS_PLANNING_SET_PRIORITY SET STATUS='D' , UPDATED_BY=@UPDATED_BY ,UPDATED_DATE=@UPDATED_DATE WHERE ORDERNO=@ORDERNO AND SORT=@SORT AND LINEITEM =@LINEiTEM AND PRIORITY_DATEFROM =@DATEFROM AND PRIORITY_DATETO=@DATETO AND STATUS='A'";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.Parameters.Add("@UPDATED_BY", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
                cmd.Parameters.Add("@UPDATED_DATE", SqlDbType.VarChar, 20).Value = DateTime.Now;
                cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = orderno;
                cmd.Parameters.Add("@SORT", SqlDbType.VarChar, 10).Value = sort;
                cmd.Parameters.Add("@LINEITEM", SqlDbType.Int).Value = lineitem;
                cmd.Parameters.Add("@DATEFROM", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateFrom.Text).GetDateTimeFormats('g')[20];
                cmd.Parameters.Add("@DATETO", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text).GetDateTimeFormats('g')[20];
                cmd.ExecuteNonQuery();
                foreach (GridViewRow row in grd.Rows)
                {
                    Image img_grd = (Image)row.FindControl("img");
                    CheckBox chb = (CheckBox)row.FindControl("Chb");
                    String OrderNo_grd = row.Cells[3].Text;
                    String Sort_grd = row.Cells[4].Text;
                    int LineItem_grd = int.Parse(row.Cells[5].Text);
                    if (OrderNo_grd == orderno && Sort_grd == sort && LineItem_grd == lineitem)
                    {
                        img_grd.ImageUrl = "~/Image/AvailabilityFalse.png";
                        chb.Checked = false;
                    }
                    
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Priority = int.Parse(ViewState["Priority"].ToString()) - 1;
                ViewState["Priority"] = Priority;
                ViewState["data"] = dt;
            }
            else
            {

                int index = grow.RowIndex;
                DataTable dt = (DataTable)ViewState["data"];
                dt.Rows.RemoveAt(index);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Priority = int.Parse(ViewState["Priority"].ToString()) - 1;
                ViewState["Priority"] = Priority;
                ViewState["data"] = dt;
                foreach (GridViewRow row in grd.Rows)
                {
                    Image img_grd = (Image)row.FindControl("img");
                    CheckBox chb = (CheckBox)row.FindControl("Chb");
                    String OrderNo_grd = row.Cells[3].Text;
                    String Sort_grd = row.Cells[4].Text;
                    int LineItem_grd = int.Parse(row.Cells[5].Text);
                    if (OrderNo_grd == orderno && Sort_grd == sort && LineItem_grd == lineitem)
                    {
                        img_grd.ImageUrl = "~/Image/AvailabilityFalse.png";
                        chb.Checked = false;

                    }
                  
                }
            }
        }

        catch (Exception ex)
        {
            script = "alert(Error : '" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

      
    }

    protected void lnkFetchPriority_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "JCT_OPS_PLANNING_PRIORITY_SAVED";
            SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text.Trim();//rblSaleOrder.SelectedItem.Text;//
            cmd1.Parameters.Add("@SALETEAM", SqlDbType.VarChar, 20).Value = ddlSalesTeam.SelectedItem.Text;
            cmd1.Parameters.Add("@SALEPERSON", SqlDbType.VarChar, 10).Value = ddlSalesPerson.SelectedItem.Value;
            cmd1.Parameters.Add("@CUSTOMER", SqlDbType.VarChar, 20).Value = txtCustomer.Text;
            cmd1.Parameters.Add("@SORTNO", SqlDbType.VarChar, 20).Value = txtSortNo.Text;
            cmd1.Parameters.Add("@YEARMONTH", SqlDbType.Decimal).Value = decimal.Parse(ddlPlanMonth.SelectedItem.Text);
            cmd1.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
            cmd1.Parameters.Add("@PRIORITY_DATEFROM", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateFrom.Text).GetDateTimeFormats('g')[20];
            cmd1.Parameters.Add("@PRIORITY_DATETO", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text).GetDateTimeFormats('g')[20];
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            DataTable dt = new DataTable();
            da1.Fill(dt);
            ViewState.Add("data",dt);
            foreach (DataRow drow in dt.Rows)
            {
                ViewState.Add("Priority",drow["Priority"]);
            }
            
        }
        catch (Exception ex)
        {
            script = "alert(Error : '" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
    }


    protected void lnkPreview_Click(object sender, EventArgs e)
    {
        Response.Redirect("Print_Priority.aspx?From="+ txtDateFrom.Text +"&To="+ txtDateTo.Text +"&Plant="+ ddlPlant.SelectedItem.Text);
        //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", AdrUrl));
    }
}