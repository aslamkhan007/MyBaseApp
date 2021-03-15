using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_Planning_Final_Plan2 : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    String script;
    String mon;
    Char Flag;
    SendMail Sm = new SendMail();
    DropDownList ddlRevisionNo = new DropDownList();
    float sumLooms=0;
    float LoomsperDayTotal = 0;
    float ToatalWvgDays = 0;
    float CountRapierReed = 0;
    float CountAirjetReed = 0;
    float CountSulzerReed = 0;
    float CountAirjetCam = 0;
    float CountSulzerCam = 0;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            sql = "Select distinct   Revision_no from  JCT_OPS_MONTHLY_PLANNING where yearmonth=" + yearMonth() + " and Location='" + ddlPlant.SelectedItem.Text + "' and ( Cloth_Type ='" + ddlCotSyn.SelectedItem.Text + "' or '" + ddlCotSyn.SelectedItem.Text + "'='All')  ";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                ddlRevisionNo.Items.Insert(0, obj1.FetchValue(sql).ToString());
            }
         
        }
        sql = "Select * from  JCT_OPS_MONTHLY_PLANNING where mode='Freezed' and yearmonth=" + yearMonth() + " and Location='" + ddlPlant.SelectedItem.Text + "' and ( Cloth_Type ='" + ddlCotSyn.SelectedItem.Text + "' or '" + ddlCotSyn.SelectedItem.Text + "'='All')  ";
        if (obj1.CheckRecordExistInTransaction(sql))
        {
            lnkUnFreeze.Enabled = true;
            lnkToExcel.Visible = true;
        }
    }

    protected void lnkGenerate_Click(object sender, EventArgs e)
    {
        //sql = "Select * from JCT_OPS_MONTHLY_PLANNING where yearmonth =" + yearMonth() + " and Location='" + ddlPlant.SelectedItem.Text + "' and ( Cloth_Type ='" + ddlCotSyn.SelectedItem.Text + "' or '" + ddlCotSyn.SelectedItem.Text + "'='All') and PlanStart_Date is not null and PlanEnd_Date is not null ";
        //if (obj1.CheckRecordExistInTransaction(sql))
        //{

        //    obj1.Alert("Plan has been generated previously. Please Click 'FETCH' button to retreive the plan.");
        //    FMsg.CssClass = "errormsg";
        //    FMsg.Message="Plan has been generated previously. Please Click 'FETCH' button to retreive the plan.";
        //    FMsg.FadeOutDuration=5000;
        //    FMsg.Display();


        //    //return;
        //}
        //else
        //{ 
         sql = " exec jct_ops_monthly_generate_plan '"+ txtEffecFrom.Text +"','"+ txtEffecTo.Text +"','"+ ddlPlant.SelectedItem.Text +"','"+ ddlCotSyn.SelectedItem.Text +"',"+ yearMonth() +"";
         obj1.FillGrid(sql, ref GridView1);
         CheckWvgCompeletionDate(GridView1);
       // }
       
     
    }

    protected void CheckWvgCompeletionDate(GridView grd)
    {


        for (int i = 0; i <= grd.Rows.Count - 1; i++)
        {

            Label orderno = (Label)grd.Rows[i].FindControl("lblorderno");
            Label Sort = (Label)grd.Rows[i].FindControl("lblSort");
            Label variant = (Label)grd.Rows[i].FindControl("lblVariant");
            Label LineItem = (Label)grd.Rows[i].FindControl("lblLineItem");
            TextBox PlanQty = (TextBox)grd.Rows[i].FindControl("txtPlanQty");
            TextBox Sizing = (TextBox)grd.Rows[i].FindControl("txtSizing");
            //TextBox Shed = (TextBox)grd.Rows[i].FindControl("txtShed");
            DropDownList Shed = (DropDownList)GridView1.Rows[i].FindControl("ddlShed");
            TextBox RPM = (TextBox)grd.Rows[i].FindControl("txtRPM");
            TextBox Efficiency = (TextBox)grd.Rows[i].FindControl("txtEfficiency");
            TextBox LoomAllot = (TextBox)grd.Rows[i].FindControl("txtLoomAllot");
            Label WvgCompletionDt = (Label)grd.Rows[i].FindControl("lblWvgCompletionDt");

            sql = " EXEC JCT_OPS_DELAY_ORDERS '" + orderno.Text + "','" + Sort.Text + "'," + LineItem.Text + ",'"+ txtEffecFrom.Text +"'";
            if (obj1.FetchValue(sql).ToString() == "TRUE")
            {
                 grd.SelectedRowStyle.BackColor=System.Drawing.Color.Red;
                 grd.SelectedRowStyle.CssClass = "GridItem";
            }
            
            
             
        }
    }

    protected int yearMonth()
    {
        sql = "Select month('" + txtEffecFrom.Text + "')";
        mon = obj1.FetchValue(sql).ToString();
        int mon1 = int.Parse(mon);
        if (mon1 < 10)
        {
            mon = "0" + mon;
        }
        sql = "Select year('" + txtEffecFrom.Text + "')";
        String year = obj1.FetchValue(sql).ToString();
        String yearmonth = year + mon;
        int year_month = int.Parse(yearmonth);
        return year_month;
    }

    protected void Update_CheckedChanged2(object sender, System.EventArgs e)
    {
        CheckBox cbHeader = (CheckBox)GridView1.HeaderRow.FindControl("Update");
        if (cbHeader.Checked == true)
        {
            for (int k = 0; k <= GridView1.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)GridView1.Rows[k].FindControl("Update");
                myCheckBox.Checked = true;
            }
        }
        else if (cbHeader.Checked == false)
        {
            for (int k = 0; k <= GridView1.Rows.Count - 1; k++)
            {
                CheckBox myCheckBox = (CheckBox)GridView1.Rows[k].FindControl("Update");
                myCheckBox.Checked = false;
            }
        }
    }


    //protected void ddlPlant_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    sql = "Select distinct   Revision_no from  JCT_OPS_MONTHLY_PLANNING where yearmonth=" + yearMonth() + " and Location='" + ddlPlant.SelectedItem.Text + "' and ( Cloth_Type ='" + ddlCotSyn.SelectedItem.Text + "' or 'All'='All') and mode='Freezed' ";
    //    if (obj1.CheckRecordExistInTransaction(sql))
    //    {
    //        ddlRevisionNo.Items.Insert(0, obj1.FetchValue(sql).ToString());
    //    }
    //}

    protected void lnkSave_Click(object sender, EventArgs e)
    {



        CheckBox cbHeader = (CheckBox)GridView1.HeaderRow.FindControl("Update");

        if (cbHeader.Checked == true)
        {
            
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                try
                {
                    Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
                    Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
                    TextBox WeavingSort = (TextBox)GridView1.Rows[i].FindControl("lblSort1");
                    Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                    Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                    TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                    TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
                    DropDownList Casetype = (DropDownList)GridView1.Rows[i].FindControl("ddlGreigh");
                    //TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                    DropDownList Shed = (DropDownList)GridView1.Rows[i].FindControl("ddlShed");
                    Label LoomsPerday = (Label)GridView1.Rows[i].FindControl("lblLoomsPerDay");
                    TextBox Greigh = (TextBox)GridView1.Rows[i].FindControl("txtGreigh");
                    TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                    TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                    TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                    Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                    TextBox Reed = (TextBox)GridView1.Rows[i].FindControl("txtReed");
                    TextBox Cam = (TextBox)GridView1.Rows[i].FindControl("txtTapperet");
                    Label Grey_ReqDt = (Label)GridView1.Rows[i].FindControl("lblGreyReqdt");
                    TextBox Grey_Adj = (TextBox)GridView1.Rows[i].FindControl("txtGreyAdjustment");
                    Label Grey_Rem = (Label)GridView1.Rows[i].FindControl("lblGreyRemaining");
                   // Shed.Text = Shed.Text.TrimStart();
                    sql = "Exec jct_ops_save_planning_detail '" + ddlPlant.SelectedItem.Text + "','" + ddlCotSyn.SelectedItem.Text + "'," + yearMonth() + ", '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "' ," + LineItem.Text + "," + PlanQty.Text + "," + Sizing.Text + ",'" + Shed.SelectedItem.Value + "'," + RPM.Text + "," + Efficiency.Text + "," + LoomAllot.Text + "," + WvgCompletionDt.Text + " ," + Reed.Text + "," + Cam.Text + "," + Greigh.Text + ",'" + Casetype.SelectedItem.Text + "','" + WeavingSort.Text + "','" + Grey_ReqDt.Text + "'," + Grey_Adj.Text + ","+ LoomsPerday.Text +"";
                    obj1.UpdateRecord(sql);
                }
                catch (SqlException ex)
                {
                     script = "alert('"+ ex.Message +"');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                finally
                {

                }

            }

             script = "alert('Plan has been successfully saved.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else
        {

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                if (GridView1.Rows[i].RowType != DataControlRowType.Header)
                { 
                      CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("Update");
                if (cb.Checked == true)
                {
                    try
                    {
                        Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
                        Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
                        TextBox WeavingSort = (TextBox)GridView1.Rows[i].FindControl("lblSort1");
                        Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                        Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                        TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                        DropDownList Casetype = (DropDownList)GridView1.Rows[i].FindControl("ddlGreigh");
                        TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
                       // TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                        DropDownList Shed = (DropDownList)GridView1.Rows[i].FindControl("ddlShed");
                        Label LoomsPerday = (Label)GridView1.Rows[i].FindControl("lblLoomsPerDay");
                        TextBox Greigh = (TextBox)GridView1.Rows[i].FindControl("txtGreigh");
                        TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                        TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                        TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                        Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                        TextBox Reed = (TextBox)GridView1.Rows[i].FindControl("txtReed");
                        TextBox Cam = (TextBox)GridView1.Rows[i].FindControl("txtTapperet");
                        Label Grey_ReqDt = (Label)GridView1.Rows[i].FindControl("lblGreyReqdt");
                        TextBox Grey_Adj = (TextBox)GridView1.Rows[i].FindControl("txtGreyAdjustment");
                        Label Grey_Rem = (Label)GridView1.Rows[i].FindControl("lblGreyRemaining");
                        // Shed.Text = Shed.Text.TrimStart();
                        sql = "Exec jct_ops_save_planning_detail '" + ddlPlant.SelectedItem.Text + "','" + ddlCotSyn.SelectedItem.Text + "'," + yearMonth() + ", '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "' ," + LineItem.Text + "," + PlanQty.Text + "," + Sizing.Text + ",'" + Shed.SelectedItem.Value + "'," + RPM.Text + "," + Efficiency.Text + "," + LoomAllot.Text + "," + WvgCompletionDt.Text + " ," + Reed.Text + "," + Cam.Text + "," + Greigh.Text + ",'" + Casetype.SelectedItem.Text + "','" + WeavingSort.Text + "','" + Grey_ReqDt.Text + "'," + Grey_Adj.Text + "," + LoomsPerday.Text + "";
                        obj1.UpdateRecord(sql);
                    }
                    catch (SqlException ex)
                    {
                         script = "alert('" + ex.Message + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                    finally
                    {

                    }
                }
               
                }
              
            }
            script = "alert('Plan has been successfully saved.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

   // protected void txtShed_TextChanged(object sender, EventArgs e)
   //{
   //    TextBox shed = (TextBox)sender;
   //    GridViewRow gridRow = (GridViewRow) shed.Parent.Parent.Parent.Parent;
   //    Label Sort = (Label)gridRow.FindControl("lblSort");
   //    TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");
   //    sql = " exec jct_ops_shed_efficiency '" + Sort.Text.Trim() + "', '" + shed.Text.Trim() + "'";
   //    if (obj1.CheckRecordExistInTransaction(sql))
   //    {
   //        Efficiency.Text = obj1.FetchValue(sql).ToString();

   //    }
   //    else
   //    {
   //        Efficiency.Text = "";
   //    }

   //     //sql = "Select * from  JCT_OPS_MONTHLY_PLANNING where yearmonth="+ yearMonth() +" and location= '"+ ddlPlant.SelectedItem.Text +"' and Cloth_type='"+ ddlCotSyn.SelectedItem.Text +"'";
        
        
   //     //for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
   //     //{ 
   //     //Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
   //     //Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
   //     //TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
   //     //TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
   //     //if (txtShed.Text != "")
   //     //{

   //     //    sql = " exec jct_ops_shed_efficiency '" + Sort.Text + "', '" + Shed.Text + "'";
   //     //    if (obj1.CheckRecordExistInTransaction(sql))
   //     //    {
   //     //        Efficiency.Text = obj1.FetchValue(sql).ToString();

   //     //    }
   //     //    else
   //     //    {
   //     //        Efficiency.Text = "";
   //     //    }

   //     //}
   //     //else
   //     //{
           
   //     //}

     
   //     //}
        
   // }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[23].Visible = false;
            e.Row.Cells[24].Visible = false;
          
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            //e.Row.ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[23].Visible = false;
            e.Row.Cells[24].Visible = false;
            Label orderno = (Label)e.Row.FindControl("lblorderno");
            Label Sort = (Label)e.Row.FindControl("lblSort");
            Label variant = (Label)e.Row.FindControl("lblVariant");
            DropDownList Casetype = (DropDownList)e.Row.FindControl("ddlGreigh");
            Label LineItem = (Label)e.Row.FindControl("lblLineItem");
            DropDownList Shed = (DropDownList)e.Row.FindControl("ddlShed");
            ImageButton img = (ImageButton)e.Row.FindControl("ImageButton2");

            sql = "JCT_OPS_CHECK_SPLIT_ORDER_SHEDWISE_RECORD ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = orderno.Text;
            cmd.Parameters.Add("@sort", SqlDbType.VarChar, 20).Value = Sort.Text;
            cmd.Parameters.Add("@lineitem", SqlDbType.Int).Value = LineItem.Text;
            cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = 'A';
            SqlDataReader dr1;
            dr1 = cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                img.ImageUrl = "~/Image/SplitIconGreen.png";
            }
            dr1.Close();
            sql = "Select Shed,isnull(CaseType,'Select') as CaseType from jct_ops_monthly_planning where yearmonth="+ yearMonth() +" and order_no='"+ orderno.Text +"' and item_no='"+ Sort.Text +"' and order_srl_no="+ LineItem.Text +"";
            SqlDataReader dr;
            dr = obj1.FetchReader(sql);
            if (dr.HasRows)

            {
                while (dr.Read())
                { 
                      Shed.SelectedIndex = Shed.Items.IndexOf(Shed.Items.FindByValue(dr[0].ToString()));
                      Casetype.SelectedIndex = Casetype.Items.IndexOf(Casetype.Items.FindByText(dr[1].ToString()));
                }
            }
            dr.Close();
          
            TextBox Looms = (TextBox)e.Row.FindControl("txtLoomAllot");
            Label WvgCompletionDt = (Label)e.Row.FindControl("lblWvgCompletionDt");
            Label LoomsPerDay = (Label)e.Row.FindControl("lblLoomsPerDay");
                if (Looms.Text != "")
                {
                    sumLooms = sumLooms + int.Parse(Looms.Text);
                }
            ToatalWvgDays = ToatalWvgDays + float.Parse(WvgCompletionDt.Text);
            LoomsperDayTotal = LoomsperDayTotal + float.Parse(LoomsPerDay.Text);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[23].Visible = false;
            e.Row.Cells[24].Visible = false;
            e.Row.Cells[25].Text = sumLooms.ToString();
            e.Row.Cells[27].Text = ToatalWvgDays.ToString();
            e.Row.Cells[26].Text = LoomsperDayTotal.ToString();
        }
    }

    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
         CheckBox cbHeader = (CheckBox)GridView1.HeaderRow.FindControl("Update");

         if (cbHeader.Checked == true)
         {   Flag = 'F';
             for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
             {
                 CheckBox cb1 = (CheckBox)GridView1.Rows[i].FindControl("Update");
                 Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
                 Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
                 Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                 Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                 TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                 TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
                 //TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                 DropDownList Shed = (DropDownList)GridView1.Rows[i].FindControl("ddlShed");
                 TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                 TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                 TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                 Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
             sql = "Exec jct_ops_Freeze_UnFreeze_plan '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "','"+ orderno.Text +"','"+ Sort.Text +"',"+ LineItem.Text +",'"+ variant.Text +"','" + Flag + "'";
             String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
             SqlConnection conn = new SqlConnection(ConStr);
             conn.Open();
             SqlCommand cmd = new SqlCommand(sql, conn);
             cmd.ExecuteNonQuery();
             conn.Close();
             sql = "EXEC JCT_OPS_CHECK_CHANGE_SEL_QTY_EMAIL_SALEPERSON '"+ orderno.Text +"','"+ Sort.Text +"','"+ variant.Text +"','"+ yearMonth() +"'";
             SqlDataReader dr = obj1.FetchReader(sql);
             if (dr.HasRows)
             {
                 while (dr.Read())
                 {
                     String email = dr[2].ToString();
                     String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>You are receiving this email on the behalf of Planning Dept. Your order has been planned for the next production plan.</p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3> Your Planned Quantity:  " + dr[7].ToString() + "</H3> </p><p> <H3>Planned Quantity by Planning Dept. : " + dr[8].ToString() + "</H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                     //String body = "<p>Plan has been freezed for the next month . You can find the plan in the attached file. </p>";
                 //    Sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Order Planned for Production" & orderno.Text , body);
                 }
             }
             dr.Close();
             cb1.Enabled = false;
             PlanQty.Enabled = false;
             Shed.Enabled = false;
             Sizing.Enabled = false;
             RPM.Enabled = false;
             Efficiency.Enabled = false;
             LoomAllot.Enabled = false;
             Update_CheckedChanged2(sender, e);
             }
             sql = "Insert into JCT_OPS_FREEZE_UNFREEZE_PLAN_REMARKS(yearmonth,freeze_dt,remarks,freezed_by)values(" + yearMonth() + ",getdate(),'" + txtRemarks.Text + "','" + Session["EmpCode"] + "')";
             obj1.InsertRecord(sql);
             script = "alert('The Plan has been freezed for the selected month.');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }
         else
         {

             for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
             {

                 if (GridView1.Rows[i].RowType != DataControlRowType.Header)
                 { 
                      CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("Update");
                 if (cb.Checked == true)
                 {
                     Flag = 'F';
                     CheckBox cb1 = (CheckBox)GridView1.Rows[i].FindControl("Update");
                     Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
                     Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
                     Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                     Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                     TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                     TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
                    // TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                     DropDownList Shed = (DropDownList)GridView1.Rows[i].FindControl("ddlShed");
                     TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                     TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                     TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                     Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                     sql = "Exec jct_ops_Freeze_UnFreeze_plan '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "','" + orderno.Text + "','" + Sort.Text + "',"+ LineItem.Text +",'" + variant.Text + "','" + Flag + "'";
                     String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
                     SqlConnection conn = new SqlConnection(ConStr);
                     conn.Open();
                     SqlCommand cmd = new SqlCommand(sql, conn);
                     cmd.ExecuteNonQuery();
                     conn.Close();

                     sql = "EXEC JCT_OPS_CHECK_CHANGE_SEL_QTY_EMAIL_SALEPERSON '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "','" + yearMonth() + "'";
                     SqlDataReader dr = obj1.FetchReader(sql);
                     if (dr.HasRows)
                     {
                         while (dr.Read())
                         {
                             String email = dr[2].ToString();
                             String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>You are receiving this email on the behalf of Planning Dept. It has been found that your  </p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3> Your Planned Quantity:  " + dr[7].ToString() + "</H3> </p><p> <H3>Planned Quantity by Planning Dept. : " + dr[8].ToString() + "</H3></p></br><p>This  Freezed plan for this order as per freezed date :" + dr[9].ToString() + " by planning dept. </p><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                             //Sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Change in Planed Quantity", body);
                         }
                     }
                     dr.Close();
                 }
              
                 }
               
             }
                 CheckPlan_Freezed(GridView1);
                 script = "alert('Selected Items have been freezed.');";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CheckPlan_Freezed(GridView grd)
    {

        for (int i = 0; i <= grd.Rows.Count - 1; i++)
        {
            CheckBox cb1 = (CheckBox)grd.Rows[i].FindControl("Update");
            Label orderno = (Label)grd.Rows[i].FindControl("lblorderno");
            Label Sort = (Label)grd.Rows[i].FindControl("lblSort");
            Label variant = (Label)grd.Rows[i].FindControl("lblVariant");
            Label LineItem = (Label)grd.Rows[i].FindControl("lblLineItem");
            TextBox PlanQty = (TextBox)grd.Rows[i].FindControl("txtPlanQty");
            TextBox Sizing = (TextBox)grd.Rows[i].FindControl("txtSizing");
           // TextBox Shed = (TextBox)grd.Rows[i].FindControl("txtShed");
            DropDownList Shed = (DropDownList)GridView1.Rows[i].FindControl("ddlShed");
            TextBox RPM = (TextBox)grd.Rows[i].FindControl("txtRPM");
            TextBox Efficiency = (TextBox)grd.Rows[i].FindControl("txtEfficiency");
            TextBox LoomAllot = (TextBox)grd.Rows[i].FindControl("txtLoomAllot");
            Label WvgCompletionDt = (Label)grd.Rows[i].FindControl("lblWvgCompletionDt");
            sql = "Select * from jct_ops_monthly_planning where mode='Freezed' and yearmonth="+ yearMonth() +" and  order_no='"+ orderno.Text +"' and item_no='"+ Sort.Text +"' and variant='"+ variant.Text +"' and order_srl_no="+ LineItem.Text +" ";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                cb1.Enabled = false;
                PlanQty.Enabled = false;
                Sizing.Enabled = false;
                Shed.Enabled = false;
                RPM.Enabled = false;
                Efficiency.Enabled = false;
                LoomAllot.Enabled = false;
            }
          
        }
        
    }

    protected void lnkUnFreeze_Click(object sender, EventArgs e)
   {
   
//        CheckBox cbHeader = (CheckBox)GridView1.HeaderRow.FindControl("Update");

//        if (cbHeader.Checked == true)
//        {
//            Flag = 'U';
//            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
//            {
//                Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
//                Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
//                Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
//                Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
//                TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
//                TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
//                TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
//                TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
//                TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
//                TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
//                Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
//                sql = "Exec jct_ops_Freeze_UnFreeze_plan '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "','" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "','" + Flag + "'";
//                String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
//                SqlConnection conn = new SqlConnection(ConStr);
//                conn.Open();
//                SqlCommand cmd = new SqlCommand(sql, conn);
//                // cmd.CommandType = CommandType.StoredProcedure;
//                cmd.ExecuteNonQuery();
//                conn.Close();

//                //sql = "EXEC JCT_OPS_CHECK_CHANGE_SEL_QTY_EMAIL_SALEPERSON '"+ orderno.Text +"','"+ Sort.Text +"','"+ variant.Text +"','"+ yearMonth() +"'";
//                //SqlDataReader dr = obj1.FetchReader(sql);
//                //if (dr.HasRows)
//                //{
//                //    while (dr.Read())
//                //    {
//                //        String email = dr[2].ToString();
//                //        String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>You are receiving this email on the behalf of Planning Dept. It has been found that your  </p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3> Your Planned Quantity:  " + dr[7].ToString() + "</H3> </p><p> <H3>Planned Quantity by Planning Dept. : " + dr[8].ToString() + "</H3></p></br><p>This  Freezed plan for this order as per freezed date :"+ dr[9].ToString() +" by planning dept. </p><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
//                //        Sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Change in Planed Quantity", body);
//                //    }
//                //}
//                //dr.Close();
//                //}
//                }
//                GridView1.DataSource = null;
//                GridView1.DataBind();
//                FMsg.CssClass = "errormsg";
//                FMsg.Message = "The Plan has been Unfreezed for the selected month.";
//                FMsg.Display();

           



//        }
//        else
//        {
//            try
//            { 
//            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
//            {
//                CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("Update");
//                if (cb.Checked == true)
//                {

//                    Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
//                    Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
//                    Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
//                    Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
//                    TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
//                    TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
//                    TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
//                    TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
//                    TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
//                    TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
//                    Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
//                    sql = "Exec jct_ops_Freeze_UnFreeze_plan '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "','" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "','" + Flag + "'";
//                    String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
//                    SqlConnection conn = new SqlConnection(ConStr);
//                    conn.Open();
//                    SqlCommand cmd = new SqlCommand(sql, conn);
//                    // cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    conn.Close();

//                    sql = "EXEC JCT_OPS_CHECK_CHANGE_SEL_QTY_EMAIL_SALEPERSON '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "','" + yearMonth() + "'";
//                    SqlDataReader dr = obj1.FetchReader(sql);
//                    if (dr.HasRows)
//                    {
//                        while (dr.Read())
//                        {
//                            String email = dr[2].ToString();
//                            String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>You are receiving this email on the behalf of Planning Dept. It has been found that your  </p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3> Your Planned Quantity:  " + dr[7].ToString() + "</H3> </p><p> <H3>Planned Quantity by Planning Dept. : " + dr[8].ToString() + "</H3></p></br><p>This  Freezed plan for this order as per freezed date :" + dr[9].ToString() + " by planning dept. </p><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
//                            //Sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Change in Planed Quantity", body);
//                        }
//                    }
//                    dr.Close();
//                    cb.Enabled = false;
//                    PlanQty.Enabled = false;
//                    Shed.Enabled = false;
//                    Sizing.Enabled = false;
//                    RPM.Enabled = false;
//                    Efficiency.Enabled = false;
//                    LoomAllot.Enabled = false;
//                }
//            }
//        }
//             catch { 
//            }
        
//        }
  
}
   
    protected void lnkNewSort_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "EXEC JCT_OPS_FETCH_NEW_SORTS '"+ ddlPlant.SelectedItem.Text +"','"+ ddlCotSyn.SelectedItem.Text +"',"+ yearMonth() +",'"+ txtEffecFrom.Text +"','"+ txtEffecTo.Text +"'";
            obj1.FillGrid(sql, ref GridView1);
        }
        catch (Exception ex)

        {
            FMsg.CssClass = "errormsg";
            FMsg.Message = ex.Message;
            FMsg.Display();
            
        }
    }

    protected void txtPlanQty_TextChanged(object sender, EventArgs e)
    {
        TextBox PlanQty = (TextBox)sender;
        GridViewRow gridRow = (GridViewRow)PlanQty.Parent.Parent;
        Label Plant = (Label)gridRow.FindControl("lblPlant");
        Label Orderno = (Label)gridRow.FindControl("lblOrderno");
        Label ClothType = (Label)gridRow.FindControl("lblClothType");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        Label Sort = (Label)gridRow.FindControl("lblSort");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("lblSort1");
        Label variant = (Label)gridRow.FindControl("lblVariant");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        Label lblReqdt = (Label)gridRow.FindControl("lblReqdt");
        Label lblWvgCompletionDt = (Label)gridRow.FindControl("lblWvgCompletionDt");
        sql = "SELECT  DISTINCT  CASE WHEN LOCATION = '" + Plant.Text + "'   THEN " + PlanQty.Text + " + " + PlanQty.Text + " * 0.12  ELSE " + PlanQty.Text + " + " + PlanQty.Text + " * 0.15  END AS [Sizing]  FROM      dbo.JCT_OPS_MONTHLY_PLANNING      WHERE item_no='" + Sort.Text + "' and variant='" + variant.Text + "' and order_srl_no=" + LineItem.Text + " and  yearmonth = " + yearMonth() + " ";
        if (obj1.CheckRecordExistInTransaction(sql))
        {
            Sizing.Text = obj1.FetchValue(sql).ToString();
            sql = "Exec jct_ops_update_weaving_completion_date '" + Orderno.Text + "' , " + PlanQty.Text + " ,'" + WeavingSort.Text + "','" + LineItem.Text + "'," + yearMonth() + ",'" + txtEffecFrom.Text + "'";
            SqlDataReader dr = obj1.FetchReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                             if (dr[0].ToString() == "TRUE")
                                {
                                    gridRow.ForeColor = System.Drawing.Color.Gray;
                                }
                                else
                                {
                                    gridRow.ForeColor = System.Drawing.Color.Red;
                                }
                             lblWvgCompletionDt.Text = dr[1].ToString();
                }
            }
        

        }
        else
        {
            Sizing.Text = "";
        }
    }

    protected void lnkFetch_Click1(object sender, EventArgs e)
    {
        pnlSearch.Visible = true;
         CountRapierReed = 0;
         CountAirjetReed = 0;
         CountSulzerReed = 0;
         CountAirjetCam = 0;
         CountSulzerCam = 0;
        try
        {

            //  sql = " exec jct_OPS_VIEW_MONTHLY_PLAN '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "'," + ddlRevisionNo.SelectedItem.Text + "";

            sql = " Exec jct_OPS_VIEW_MONTHLY_PLAN  '"+ txtEffecFrom.Text +"','" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "'";
            DataSet ds = new DataSet();
          //  DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(sql, obj.Connection());
            Da.SelectCommand.CommandTimeout = 0;
            Da.Fill(ds);
            //dt=ds.Tables["PlanTable"];
           //   foreach(DataRow dr in dt.Rows)
          //  {
                 GridView1.DataSource = ds;
                 GridView1.DataBind();
           // }
           
            CountReedCam();
            sql = " exec jct_OPS_VIEW_MONTHLY_PLAN_Freezed  '" + txtEffecFrom.Text + "','" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "'";
            obj1.FillGrid(sql,ref grdFreezed);
            CheckPlan_Freezed(GridView1);
            //CheckWvgCompeletionDate(GridView1);

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
                Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
                Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
               // TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                DropDownList Shed=(DropDownList)GridView1.Rows[i].FindControl("ddlShed");
                TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                hdfWvgCompletionDt.Value = WvgCompletionDt.Text;
                sql = " EXEC JCT_OPS_DELAY_ORDERS '" + orderno.Text + "','" + Sort.Text + "'," + LineItem.Text + ",'"+ txtEffecFrom.Text +"'";
                if (obj1.FetchValue(sql).ToString() == "TRUE")
                {
                    GridView1.Rows[i].ControlStyle.ForeColor = System.Drawing.Color.Red;
                }


            }
        }
        catch (SqlException ex)
        {
             script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

        
    }

    protected void CountReedCam()
    {


                sql = "Select ISNULL(Sum(isnull(Reed,0)),0)  from jct_ops_monthly_planning where Shed='R' and yearmonth=" + yearMonth() + "";
                CountRapierReed = CountRapierReed + float.Parse(obj1.FetchValue(sql).ToString());
                sql = "Select ISNULL(Sum(isnull(Reed,0)),0)  from jct_ops_monthly_planning where Shed='A' and yearmonth=" + yearMonth() + "";
                CountAirjetReed = CountAirjetReed + float.Parse(obj1.FetchValue(sql).ToString());

                sql = "Select ISNULL(Sum(isnull(Cam,0)),0)  from jct_ops_monthly_planning where Shed='A' and yearmonth=" + yearMonth() + "";
                CountAirjetCam = CountAirjetCam +  float.Parse(obj1.FetchValue(sql).ToString());

                sql = "Select ISNULL(Sum(isnull(Reed,0)),0)  from jct_ops_monthly_planning where Shed='S' and yearmonth=" + yearMonth() + "";
                CountSulzerReed = CountSulzerReed+  float.Parse(obj1.FetchValue(sql).ToString());

                sql = "Select ISNULL(Sum(isnull(Cam,0)),0)  from jct_ops_monthly_planning where Shed='S' and yearmonth=" + yearMonth() + "";
                CountSulzerCam = CountSulzerCam + float.Parse(obj1.FetchValue(sql).ToString());
         
           

    }

    protected void lnkUnFreezePopUp_Click(object sender, EventArgs e)
    {
        CheckBox cbHeader = new CheckBox();
         cbHeader = (CheckBox)GridView1.HeaderRow.FindControl("Update");

        if (cbHeader.Checked == true)
        {
            Flag = 'U';
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
                Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
                Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
               // TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                DropDownList Shed = (DropDownList)GridView1.Rows[i].FindControl("ddlShed");
                TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                sql = "Exec jct_ops_Freeze_UnFreeze_plan '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "','" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "','" + Flag + "'";
                String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                // cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();

               
            }
            sql = "Insert into JCT_OPS_FREEZE_UNFREEZE_PLAN_REMARKS(yearmonth,unfreeze_dt,remarks,unfreezed_by)values(" + yearMonth() + ",getdate(),'" + txtRemarks.Text + "','" + Session["EmpCode"] + "')";
            obj1.InsertRecord(sql);
            GridView1.DataSource = null;
            GridView1.DataBind();
            script = "alert('The Plan has been Unfreezed for the selected month.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else
        {
            try
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("Update");
                    if (cb.Checked == true)
                    {

                        Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
                        Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
                        Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                        Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                        TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                        TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
                       // TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                        DropDownList Shed = (DropDownList)GridView1.Rows[i].FindControl("ddlShed");
                        TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                        TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                        TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                        Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                        sql = "Exec jct_ops_Freeze_UnFreeze_plan '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "','" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "','" + Flag + "'";
                        String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
                        SqlConnection conn = new SqlConnection(ConStr);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        // cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        sql = "EXEC JCT_OPS_CHECK_CHANGE_SEL_QTY_EMAIL_SALEPERSON '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "','" + yearMonth() + "'";
                        SqlDataReader dr = obj1.FetchReader(sql);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                String email = dr[2].ToString();
                                String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>You are receiving this email on the behalf of Planning Dept. It has been found that your  </p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3> Your Planned Quantity:  " + dr[7].ToString() + "</H3> </p><p> <H3>Planned Quantity by Planning Dept. : " + dr[8].ToString() + "</H3></p></br><p>This  Freezed plan for this order as per freezed date :" + dr[9].ToString() + " by planning dept. </p><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                                //Sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Change in Planed Quantity", body);
                            }
                        }
                        dr.Close();
                        cb.Enabled = false;
                        PlanQty.Enabled = false;
                        Shed.Enabled = false;
                        Sizing.Enabled = false;
                        RPM.Enabled = false;
                        Efficiency.Enabled = false;
                        LoomAllot.Enabled = false;
                    }
                    else
                    {
                         script = "alert('Please select record.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
                //sql = "Insert into JCT_OPS_FREEZE_UNFREEZE_PLAN_REMARKS(yearmonth,unfreeze_dt,remarks,unfreezed_by)values(" + yearMonth() + ",getdate(),'" + txtRemarks.Text + "','" + Session["EmpCode"] + "')";
                //obj1.InsertRecord(sql);
            }
            catch
            {
            }

        }
  
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        lnkFetch_Click1(sender, null);
    }

    protected void lnkToExcel_Click(object sender, EventArgs e)
    {
        sql = "SELECT yearmonth,team_code,order_no,order_dt,item_no,Weaving_Sort,order_srl_no,amend_no,variant,blend,req_dt,req_qty,sel_qty,SHED,EFFICIENCY,RPM,LOOMS_REQUIRED,SIZING,LOCATION,CLOTH_TYPE,Freeze_Dt,WvgCompletionDate AS [WvgCompletionDays] FROM dbo.JCT_OPS_MONTHLY_PLANNING WHERE mode='Freezed'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        CreateExcelFile(dt);
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("FreezedPlan.xlsx")));
        Response.AppendHeader("Content-Disposition", "attachment; filename=FreezedPlan.xls");
        Response.TransmitFile(Server.MapPath("FreezedPlan.xlsx"));
        Response.End();
        obj.ConClose();
    }

    public bool CreateExcelFile(DataTable dt)
    {
        bool bFileCreated = false;
        string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Freezed Plan</TH></TR>";
        string sTableEnd = "</TABLE></BODY></HTML>";
        string sTableData = "";
        int nRow = 0;
        int nCol;
        sTableData += "<TR>";
        for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
        {
            sTableData += "<TD><B>" + dt.Columns[nCol].ColumnName + "</B></TD>";
        }
        sTableData += "</TR>";
        for (nRow = 0; nRow <= dt.Rows.Count - 1; nRow++)
        {
            sTableData += "<TR>";
            for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
            {
                sTableData += "<TD>" + dt.Rows[nRow][nCol].ToString() + "</TD>";
            }
            sTableData += "</TR>";
        }
        string sTable = sTableStart + sTableData + sTableEnd;
        System.IO.StreamWriter oExcelWrite = null;
        string sExcelFile = Server.MapPath("FreezedPlan.xlsx");
        oExcelWrite = System.IO.File.CreateText(sExcelFile);
        oExcelWrite.WriteLine(sTable);
        oExcelWrite.Close();
        bFileCreated = true;
        return bFileCreated;

    }

    protected void txtLoomAllot_TextChanged(object sender, EventArgs e)
    {
        TextBox txtLoomAllot = (TextBox)sender;
        GridViewRow gridRow = (GridViewRow)txtLoomAllot.Parent.Parent;
        Label Plant = (Label)gridRow.FindControl("lblPlant");
        TextBox Plan_Qty = (TextBox)gridRow.FindControl("txtPlanQty");
        TextBox Greigh = (TextBox)gridRow.FindControl("txtGreigh");
        TextBox GreighAjdustment = (TextBox)gridRow.FindControl("txtGreyAdjustment");
        Label Orderno = (Label)gridRow.FindControl("lblOrderno");
        Label ClothType = (Label)gridRow.FindControl("lblClothType");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
        Label Sort = (Label)gridRow.FindControl("lblSort");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("lblSort1");
        Label variant = (Label)gridRow.FindControl("lblVariant");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        Label lblReqdt = (Label)gridRow.FindControl("lblReqdt");
        TextBox Reed = (TextBox)gridRow.FindControl("txtReed");
        TextBox Cam = (TextBox)gridRow.FindControl("txtTapperet");

        float GreighReq = float.Parse(Greigh.Text);
        float GreighAjd = float.Parse(GreighAjdustment.Text);
        float GreighRem = GreighReq - GreighAjd;

        Label lblWvgCompletionDt = (Label)gridRow.FindControl("lblWvgCompletionDt");
        sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( "+ GreighRem  +" / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + txtLoomAllot.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + txtLoomAllot.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE   sort_no = SUBSTRING('"+ Sort.Text +"', 4, LEN('"+ Sort.Text +"'))";
        lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
        sql = "Select case when Convert(datetime,'"+ txtEffecFrom.Text +"') + "+ lblWvgCompletionDt.Text +" < Convert(datetime,'"+ lblReqdt.Text +"',103) then 'True' else 'False' END";
        if (obj1.FetchValue(sql) == "True")
        {
            gridRow.ForeColor = System.Drawing.Color.Gray; 
        }
        else
        {
            gridRow.ForeColor = System.Drawing.Color.Red;
            gridRow.CssClass = "GridItem";
        }

        if (Shed.SelectedItem.Value == "R" || Shed.SelectedItem.Value == "W")
        {
            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + WeavingSort.Text + "','" + Shed.Text + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountRapierReed + ",0";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    try
                    {
                        float reed = float.Parse(dr[0].ToString());
                        Reed.Text = dr[0].ToString();
                    }

                    catch (Exception ex)
                    {
                        Reed.Text = "";

                        string script = string.Format("alert('{0}');", dr[0].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

                    }

                    try
                    {
                        float cam = float.Parse(dr[1].ToString());
                        Cam.Text = dr[1].ToString();
                    }

                    catch (Exception ex)
                    {

                        Cam.Text = "";
                        string script = string.Format("alert('{0}');", dr[1].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
                    }

                 
                }
            }
        }
        if (Shed.SelectedItem.Value == "A")
        {
            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + WeavingSort.Text + "','" + Shed.SelectedItem.Value + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountAirjetReed + "," + CountAirjetCam + "";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    try
                    {
                        float reed = float.Parse(dr[0].ToString());
                        Reed.Text = dr[0].ToString();
                    }

                    catch (Exception ex)
                    {
                        Reed.Text = "";

                        string script = string.Format("alert('{0}');", dr[0].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

                    }

                    try
                    {
                        float cam = float.Parse(dr[1].ToString());
                        Cam.Text = dr[1].ToString();
                    }

                    catch (Exception ex)
                    {

                        Cam.Text = "";
                        string script = string.Format("alert('{0}');", dr[1].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
                    }
                  

                }
            }
        }
        if (Shed.SelectedItem.Value.Substring(0,1) == "S")
        {

            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + WeavingSort.Text + "','" + Shed.SelectedItem.Value.Substring(0, 1) + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountSulzerReed + "," + CountSulzerCam + "";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    try
                    {
                        float reed = float.Parse(dr[0].ToString());
                        Reed.Text = dr[0].ToString();
                    }

                    catch (Exception ex)
                    {
                        Reed.Text = "";

                        string script = string.Format("alert('{0}');", dr[0].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

                    }

                    try
                    {
                        float cam = float.Parse(dr[1].ToString());
                        Cam.Text = dr[1].ToString();
                    }

                    catch (Exception ex)
                    {

                        Cam.Text = "";
                        string script = string.Format("alert('{0}');", dr[1].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
                    }
                }
            }
        }
    }

    protected void grdFreezed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
        }
    }

    protected void ddlGreigh_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList GreighReq = (DropDownList)sender;
        GridViewRow gridRow = (GridViewRow)GreighReq.Parent.Parent;
        TextBox Plan_Qty = (TextBox)gridRow.FindControl("txtPlanQty");
        Label Orderno = (Label)gridRow.FindControl("lblOrderno");
        Label Sort = (Label)gridRow.FindControl("lblSort");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("lblSort1");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        TextBox Greigh = (TextBox)gridRow.FindControl("txtGreigh");
        Label lblLoomsPerDay = (Label)gridRow.FindControl("lblLoomsPerDay");
        Label GreighRem = (Label)gridRow.FindControl("lblGreyRemaining");
        Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        TextBox txtLoomAllot = (TextBox)gridRow.FindControl("txtLoomAllot");
        if (GreighReq.SelectedIndex == 1)
        {
            sql = "Select  variationAllowd from production..JCT_Process_Greigh_Request_Variation WHERE GETDATE() BETWEEN Eff_From AND Eff_To and " + Plan_Qty.Text + " between MtrFrom and MtrUpto and CaseType='" + GreighReq.SelectedItem.Text + "' ";
            sql = "Select " + OrderQty.Text + " + " + OrderQty.Text + " * " + obj1.FetchValue(sql).ToString() + " /100";
            Greigh.Text = obj1.FetchValue(sql).ToString();
            double greighRem = double.Parse(Greigh.Text);
            greighRem= Math.Round(greighRem, 2);
            GreighRem.Text = greighRem.ToString();
            Greigh.Text = greighRem.ToString();
            
            sql = "EXEC JCT_OPS_WEAVING_SIZING " + GreighRem.Text + ",  '" + WeavingSort.Text + "','" + Orderno.Text + "'," + LineItem.Text + "";
            Sizing.Text = obj1.FetchValue(sql).ToString();

            sql = "SELECT dbo.udf_GetNumDaysInMonth("+ txtEffecFrom.Text +") NumDaysInMonth";
            float Looms = float.Parse(GreighRem.Text) / float.Parse(obj1.FetchValue(sql).ToString());
            lblLoomsPerDay.Text = Looms.ToString();
            txtLoomAllot.Text = "0";
        }
        else
        {
           
            sql = "Select variationAllowd from production..JCT_Process_Greigh_Request_Variation WHERE GETDATE() BETWEEN Eff_From AND Eff_To and CaseType='" + GreighReq.SelectedItem.Text + "' ";
            sql = "Select " + OrderQty.Text + " + " + OrderQty.Text + " * " + obj1.FetchValue(sql).ToString() +" /100" ;
            Greigh.Text = obj1.FetchValue(sql).ToString();
            double greighRem = double.Parse(Greigh.Text);
            greighRem = Math.Round(greighRem, 2);
            GreighRem.Text = greighRem.ToString();
            Greigh.Text = greighRem.ToString();
            sql = "EXEC JCT_OPS_WEAVING_SIZING " + GreighRem.Text + ", '" + WeavingSort.Text + "','" + Orderno.Text + "'," + LineItem.Text + "";
            Sizing.Text = obj1.FetchValue(sql).ToString();
            sql = "SELECT dbo.udf_GetNumDaysInMonth(" + txtEffecFrom.Text + ") NumDaysInMonth";
            float Looms = float.Parse(GreighRem.Text) / float.Parse(obj1.FetchValue(sql).ToString());
            lblLoomsPerDay.Text = Looms.ToString();
            txtLoomAllot.Text = "0";
        }
     
    }

    protected void lnkSaveRow_Click(object sender, EventArgs e)
    {
      

        LinkButton Save = (LinkButton)sender;
        GridViewRow gridRow = (GridViewRow)Save.Parent.Parent;
        Label orderno = (Label)gridRow.FindControl("lblorderno");
        Label Sort = (Label)gridRow.FindControl("lblSort");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("lblSort1");
        Label variant = (Label)gridRow.FindControl("lblVariant");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        Label LoomsPerday = (Label)gridRow.FindControl("lblLoomsPerDay");
        TextBox PlanQty = (TextBox)gridRow.FindControl("txtPlanQty");
        DropDownList Casetype = (DropDownList)gridRow.FindControl("ddlGreigh");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        TextBox Greigh = (TextBox)gridRow.FindControl("txtGreigh");
       // TextBox Shed = (TextBox)gridRow.FindControl("txtShed");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
        TextBox RPM = (TextBox)gridRow.FindControl("txtRPM");
        TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");
        TextBox LoomAllot = (TextBox)gridRow.FindControl("txtLoomAllot");
        Label WvgCompletionDt = (Label)gridRow.FindControl("lblWvgCompletionDt");
        TextBox Reed = (TextBox)gridRow.FindControl("txtReed");
        TextBox Cam = (TextBox)gridRow.FindControl("txtTapperet");
        Label Grey_ReqDt = (Label)gridRow.FindControl("lblGreyReqdt");
        TextBox Grey_Adj = (TextBox)gridRow.FindControl("txtGreyAdjustment");
        Label Grey_Rem = (Label)gridRow.FindControl("lblGreyRemaining");
        // Shed.Text = Shed.Text.TrimStart();
        sql = "Exec jct_ops_save_planning_detail '" + ddlPlant.SelectedItem.Text + "','" + ddlCotSyn.SelectedItem.Text + "'," + yearMonth() + ", '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "' ," + LineItem.Text + "," + PlanQty.Text + "," + Sizing.Text + ",'" + Shed.SelectedItem.Value + "'," + RPM.Text + "," + Efficiency.Text + "," + LoomAllot.Text + "," + WvgCompletionDt.Text + " ," + Reed.Text + "," + Cam.Text + "," + Greigh.Text + ",'" + Casetype.SelectedItem.Text + "','" + WeavingSort.Text + "','" + Grey_ReqDt.Text + "'," + Grey_Adj.Text + "," + LoomsPerday.Text + "";
        obj1.UpdateRecord(sql);
        CountReedCam();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "OpenPopUp")
        {
            
            DataTable dt = new DataTable();
              
            dt.Columns.Add("Order_no");
            dt.Columns.Add("item_no");
            dt.Columns.Add("Shade");
            dt.Columns.Add("LineItem");
            dt.Columns.Add("Req_dt");
            dt.Columns.Add("WeavingSort");
            dt.Columns.Add("plan_qty");
            dt.Columns.Add("OrderQty");
            dt.Columns.Add("GreighReq");
            dt.Columns.Add("Sizing");
            dt.Columns.Add("LoomAllot");
            dt.Columns.Add("WvgCompletionDate");
            dt.Columns.Add("Reed");
            dt.Columns.Add("Cam");
          


            GridViewRow gv = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            Label orderno = (Label)gv.FindControl("lblorderno");
            Label Sort = (Label)gv.FindControl("lblSort");
            TextBox WeavingSort = (TextBox)gv.FindControl("lblSort1");
            Label Shade = (Label)gv.FindControl("lblShade");
            Label ReqDt = (Label)gv.FindControl("lblReqdt");
            Label variant = (Label)gv.FindControl("lblVariant");
            Label LineItem = (Label)gv.FindControl("lblLineItem");
            TextBox PlanQty = (TextBox)gv.FindControl("txtPlanQty");
            Label OrderQty = (Label)gv.FindControl("lblOrderQty");
            DropDownList Casetype = (DropDownList)gv.FindControl("ddlGreigh");
            TextBox Sizing = (TextBox)gv.FindControl("txtSizing");
            TextBox Greigh = (TextBox)gv.FindControl("txtGreigh");
            // TextBox Shed = (TextBox)gridRow.FindControl("txtShed");
            DropDownList Shed = (DropDownList)gv.FindControl("ddlShed");
            TextBox RPM = (TextBox)gv.FindControl("txtRPM");
            TextBox Efficiency = (TextBox)gv.FindControl("txtEfficiency");
            TextBox LoomAllot = (TextBox)gv.FindControl("txtLoomAllot");
            Label WvgCompletionDt = (Label)gv.FindControl("lblWvgCompletionDt");
            TextBox Reed = (TextBox)gv.FindControl("txtReed");
            TextBox Cam = (TextBox)gv.FindControl("txtTapperet");

            sql = "JCT_OPS_CHECK_SPLIT_ORDER_SHEDWISE_RECORD ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = orderno.Text;
            cmd.Parameters.Add("@sort", SqlDbType.VarChar, 20).Value = Sort.Text;
            cmd.Parameters.Add("@lineitem", SqlDbType.Int).Value = LineItem.Text;
            cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = 'A';
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
             if (dr.HasRows)
                {

                 while (dr.Read())
                {
                    DataRow drow = dt.NewRow();
                    drow["Order_No"] = dr[0].ToString();
                    drow["item_no"] = dr[1].ToString();
                    drow["Shade"] = dr[2].ToString();
                    drow["LineItem"] = dr[3].ToString();
                    drow["Req_dt"] = dr[4].ToString();
                    drow["WeavingSort"] = dr[5].ToString();
                    drow["OrderQty"] = dr[6].ToString();
                    drow["plan_qty"] = dr[7].ToString();
                    drow["GreighReq"] = dr[8].ToString();
                    drow["Sizing"] = dr[9].ToString();
                    drow["LoomAllot"] = dr[10].ToString();
                    drow["WvgCompletionDate"] = dr[11].ToString();
                    drow["Reed"] = dr[12].ToString();
                    drow["Cam"] = dr[13].ToString();
                    dt.Rows.Add(drow);
                    if (ViewState["data"] == null)
                    {
                        ViewState["data"] = dt;
                    }
                    else
                    {
                        ViewState.Add("data", dt);
                    }
                }
              
              
            }
             else
             {

                 DataRow drow = dt.NewRow();
                 drow["Order_No"] = orderno.Text;
                 drow["item_no"] = Sort.Text;
                 drow["Shade"] = Shade.Text;
                 drow["LineItem"] = LineItem.Text;
                 drow["Req_dt"] = ReqDt.Text;
                 drow["WeavingSort"] = WeavingSort.Text;
                 drow["OrderQty"] = OrderQty.Text;
                 drow["plan_qty"] = PlanQty.Text;
                 drow["GreighReq"] = Greigh.Text;
                 drow["Sizing"] = Sizing.Text;
                 drow["LoomAllot"] = LoomAllot.Text;
                 drow["WvgCompletionDate"] = WvgCompletionDt.Text;
                 drow["Reed"] = Reed.Text;
                 drow["Cam"] = Cam.Text;
                 dt.Rows.Add(drow);
                 ViewState["data"] = dt;
             }
             dr.Close();
            //sql = "Select '" + orderno.Text + "' as [Order_No],'" + Sort.Text + "' as [item_no],'" + WeavingSort.Text + "' as [WeavingSort],'" + PlanQty.Text + "' as [plan_qty],'' as GreighReq,'' as Sizing,'' as LoomAllot,'" + WvgCompletionDt.Text + "' as [WvgCompletionDate],'' as Reed,'' as Cam";
            //obj1.FillGrid(sql, ref grdSplit);

            grdSplit.DataSource = ViewState["data"];
            grdSplit.DataBind();

            ModalPopupExtender1.Show();
            
        }
    }
   
    protected void imgAddRow_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton imgAdd = (ImageButton)sender;
            //int TotalSplit = int.Parse(txtSplit.Text) + 1;
            //txtSplit.Text = TotalSplit.ToString();
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["data"];
            DataRow drow = dt.NewRow();
            DataTableReader dtr = new DataTableReader(dt);
            dtr.Read();
            drow["order_No"] = dtr["order_no"];
            drow["item_no"] = dtr["item_no"];
            drow["Shade"] = dtr["Shade"];
            drow["LineItem"]=dtr["LineItem"];
            drow["Req_dt"] = dtr["Req_dt"];
            drow["WeavingSort"] = dtr["WeavingSort"];
            drow["OrderQty"] = dtr["OrderQty"];
            drow["plan_qty"] = dtr["plan_qty"];
            drow["GreighReq"] = dtr["GreighReq"];
            drow["Sizing"] = dtr["Sizing"];
            drow["LoomAllot"] = dtr["LoomAllot"];
            drow["WvgCompletionDate"] = dtr["WvgCompletionDate"];
            drow["Reed"] = dtr["Reed"];
            drow["Cam"] = dtr["Cam"];
            dt.Rows.Add(drow);
            ViewState.Add("data", dt);

            grdSplit.DataSource = dt;
            grdSplit.DataBind();
        }
        catch (Exception ex)
        {
            script = "alert('No Row available.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdSplit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       // int TotalSplit = int.Parse(txtSplit.Text) - 1;
       // txtSplit.Text = TotalSplit.ToString();
        int  row = e.RowIndex;
        DataTable dt= (DataTable)ViewState["data"];
        dt.Rows.RemoveAt(row);
        grdSplit.DataSource = dt;
        grdSplit.DataBind();
        ViewState["data"] = dt;
    }

    protected void lnkSplitCancel_Click(object sender, EventArgs e)
    {
      
        ModalPopupExtender1.Hide();
    }

    protected void lnkSplitOk_Click(object sender, EventArgs e)
    {
       
        ModalPopupExtender1.Hide();
    }

    protected void ddlGreighS_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList GreighReq = (DropDownList)sender;
        GridViewRow gridRow = (GridViewRow)GreighReq.Parent.Parent;
        TextBox Plan_Qty = (TextBox)gridRow.FindControl("txtPlanQtyS");
        Label Orderno = (Label)gridRow.FindControl("lblOrdernoS");
        Label Sort = (Label)gridRow.FindControl("lblSortS");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("lblSort1S");
        Label LineItem = (Label)gridRow.FindControl("lblLineItemS");
        TextBox Greigh = (TextBox)gridRow.FindControl("txtGreighS");
        Label OrderQty = (Label)gridRow.FindControl("lblOrderQtyS");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizingS");
        if (GreighReq.SelectedIndex == 0)
        {
            sql = "Select  variationAllowd from production..JCT_Process_Greigh_Request_Variation WHERE GETDATE() BETWEEN Eff_From AND Eff_To and " + Plan_Qty.Text + " between MtrFrom and MtrUpto and CaseType='" + GreighReq.SelectedItem.Text + "' ";
            sql = "Select " + OrderQty.Text + " + " + OrderQty.Text + " * " + obj1.FetchValue(sql).ToString() + " /100";
            Greigh.Text = obj1.FetchValue(sql).ToString();

            sql = "EXEC JCT_OPS_WEAVING_SIZING " + Greigh.Text + ",  '" + WeavingSort.Text + "','" + Orderno.Text + "'," + LineItem.Text + "";
            Sizing.Text = obj1.FetchValue(sql).ToString();

        }
        else
        {
            sql = "Select variationAllowd from production..JCT_Process_Greigh_Request_Variation WHERE GETDATE() BETWEEN Eff_From AND Eff_To and CaseType='" + GreighReq.SelectedItem.Text + "' ";
            sql = "Select " + OrderQty.Text + " + " + OrderQty.Text + " * " + obj1.FetchValue(sql).ToString() + " /100";
            Greigh.Text = obj1.FetchValue(sql).ToString();
            sql = "EXEC JCT_OPS_WEAVING_SIZING " + Greigh.Text + ", '" + WeavingSort.Text + "','" + Orderno.Text + "'," + LineItem.Text + "";
            Sizing.Text = obj1.FetchValue(sql).ToString();
        }
    }

    protected void txtLoomAllotS_TextChanged(object sender, EventArgs e)
    {
        TextBox txtLoomAllot = (TextBox)sender;
        GridViewRow gridRow = (GridViewRow)txtLoomAllot.Parent.Parent;
        Label Plant = (Label)gridRow.FindControl("lblPlantS");
        TextBox Plan_Qty = (TextBox)gridRow.FindControl("txtPlanQtyS");
        Label Orderno = (Label)gridRow.FindControl("lblOrdernoS");
        Label ReqDt = (Label)gridRow.FindControl("lblReqdtS");
        Label ClothType = (Label)gridRow.FindControl("lblClothTypeS");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizingS");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShedS");
        Label Sort = (Label)gridRow.FindControl("lblSortS");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("lblSort1S");
        Label variant = (Label)gridRow.FindControl("lblVariantS");
        Label LineItem = (Label)gridRow.FindControl("lblLineItemS");
        TextBox Reed = (TextBox)gridRow.FindControl("txtReedS");
        TextBox Cam = (TextBox)gridRow.FindControl("txtTapperetS");
        Label lblWvgCompletionDt = (Label)gridRow.FindControl("lblWvgCompletionDtS");

        sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( " + Plan_Qty.Text + " / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + txtLoomAllot.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + txtLoomAllot.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE   sort_no = SUBSTRING('" + Sort.Text + "', 4, LEN('" + Sort.Text + "'))";
        lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
        sql = "Select case when Convert(datetime,'" + txtEffecFrom.Text + "') + " + lblWvgCompletionDt.Text + " < Convert(datetime,'" + ReqDt.Text + "',103) then 'True' else 'False' END";
        if (obj1.FetchValue(sql) == "True")
        {
            gridRow.ForeColor = System.Drawing.Color.Gray;
        }
        else
        {
            gridRow.ForeColor = System.Drawing.Color.Red;
        }

        if (Shed.SelectedItem.Value.Substring(0, 1) == "R" || Shed.SelectedItem.Value == "W")
        {
            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + WeavingSort.Text + "','" + Shed.Text + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountRapierReed + ",0";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    try
                    {
                        float reed = float.Parse(dr[0].ToString());
                        Reed.Text = dr[0].ToString();
                    }

                    catch (Exception ex)
                    {
                        Reed.Text = "";

                        string script = string.Format("alert('{0}');", dr[0].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

                    }

                    try
                    {
                        float cam = float.Parse(dr[1].ToString());
                        Cam.Text = dr[1].ToString();
                    }

                    catch (Exception ex)
                    {

                        Cam.Text = "";
                        string script = string.Format("alert('{0}');", dr[1].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
                    }


                }
            }
        }
        if (Shed.SelectedItem.Value.Substring(0, 1) == "A")
        {
            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + WeavingSort.Text + "','" + Shed.SelectedItem.Value + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountAirjetReed + "," + CountAirjetCam + "";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    try
                    {
                        float reed = float.Parse(dr[0].ToString());
                        Reed.Text = dr[0].ToString();
                    }

                    catch (Exception ex)
                    {
                        Reed.Text = "";

                        string script = string.Format("alert('{0}');", dr[0].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

                    }

                    try
                    {
                        float cam = float.Parse(dr[1].ToString());
                        Cam.Text = dr[1].ToString();
                    }

                    catch (Exception ex)
                    {

                        Cam.Text = "";
                        string script = string.Format("alert('{0}');", dr[1].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
                    }


                }
            }
        }
        if (Shed.SelectedItem.Value.Substring(0, 1) == "S")
        {

            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + WeavingSort.Text + "','" + Shed.SelectedItem.Value.Substring(0, 1) + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountSulzerReed + "," + CountSulzerCam + "";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    try
                    {
                        float reed = float.Parse(dr[0].ToString());
                        Reed.Text = dr[0].ToString();
                    }

                    catch (Exception ex)
                    {
                        Reed.Text = "";

                        string script = string.Format("alert('{0}');", dr[0].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

                    }

                    try
                    {
                        float cam = float.Parse(dr[1].ToString());
                        Cam.Text = dr[1].ToString();
                    }

                    catch (Exception ex)
                    {

                        Cam.Text = "";
                        string script = string.Format("alert('{0}');", dr[1].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
                    }
                }
            }
        }
    }

    protected void lnkSaveSplit_Click(object sender, EventArgs e)
    {
        try
        {
        LinkButton Save = (LinkButton)sender;
        GridViewRow gridRow = (GridViewRow)Save.Parent.Parent;
        Label orderno = (Label)gridRow.FindControl("lblordernoS");
        Label ReqDt = (Label)gridRow.FindControl("lblReqdtS");
        Label Sort = (Label)gridRow.FindControl("lblSortS");
        Label Shade =(Label)gridRow.FindControl("lblShadeS");
        TextBox WeavingSort = (TextBox)gridRow.FindControl("lblSort1S");
        Label variant = (Label)gridRow.FindControl("lblVariantS");
        Label LineItem = (Label)gridRow.FindControl("lblLineItemS");
        TextBox PlanQty = (TextBox)gridRow.FindControl("txtPlanQtyS");
        Label OrderQty = (Label)gridRow.FindControl("lblOrderQtyS");
        DropDownList Casetype = (DropDownList)gridRow.FindControl("ddlGreighS");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizingS");
        TextBox Greigh = (TextBox)gridRow.FindControl("txtGreighS");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShedS");
        TextBox LoomAllot = (TextBox)gridRow.FindControl("txtLoomAllotS");
        Label WvgCompletionDays = (Label)gridRow.FindControl("lblWvgCompletionDtS");
        TextBox Reed = (TextBox)gridRow.FindControl("txtReedS");
        TextBox Cam = (TextBox)gridRow.FindControl("txtTapperetS");

        //sql = "Select TransNo from JCT_OPS_MONTHLY_PLANNING WHERE ORDER_NO='" + orderno.Text + "' and item_no='" + Sort.Text + "' and order_srl_no='" + LineItem.Text + "' and Status is null    and Mode <> 'Freezed' ";
        //ViewState["TransNo"] = obj1.FetchValue(sql).ToString();
       
        sql = "Exec JCT_OPS_SAVE_SPLIT_ORDER_SHEDWISE_RECORD  @OrderNo,@Sort ,@LineItem,@PlanQty,@Sizing,@Shed,@LoomAllot,@WvgCompletionDays,@Reed,@Cam,@Greigh ,@CaseType,@WeavingSort,@EmpCode,@CompanyCode,@ReqDt,@OrderQty,@Status,@Shade";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = orderno.Text;
        cmd.Parameters.Add("@Sort", SqlDbType.VarChar, 20).Value = Sort.Text;
        cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = LineItem.Text;
        cmd.Parameters.Add("@PlanQty", SqlDbType.Decimal).Value = PlanQty.Text;
        cmd.Parameters.Add("@Sizing", SqlDbType.Decimal).Value =  Sizing.Text;
        cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 2).Value = Shed.Text;
        cmd.Parameters.Add("@LoomAllot", SqlDbType.Decimal).Value = LoomAllot.Text;
        cmd.Parameters.Add("@WvgCompletionDays", SqlDbType.Decimal).Value = WvgCompletionDays.Text;
        cmd.Parameters.Add("@Reed", SqlDbType.Decimal).Value = Reed.Text;
        cmd.Parameters.Add("@Cam", SqlDbType.Decimal).Value = Cam.Text;
        cmd.Parameters.Add("@Greigh", SqlDbType.Decimal).Value =  Greigh.Text;
        cmd.Parameters.Add("@CaseType", SqlDbType.VarChar,20).Value = Casetype.Text;
        cmd.Parameters.Add("@WeavingSort", SqlDbType.Decimal).Value = WeavingSort.Text;
        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar,10).Value = "J-01945";
        cmd.Parameters.Add("@CompanyCode", SqlDbType.VarChar, 10).Value = "JCT00LTD";
        cmd.Parameters.Add("@ReqDt", SqlDbType.DateTime).Value = ReqDt.Text;
        cmd.Parameters.Add("@OrderQty", SqlDbType.Decimal).Value = OrderQty.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
        cmd.Parameters.Add("@Shade", SqlDbType.VarChar,50).Value = Shade.Text;
        cmd.ExecuteNonQuery();
        script = "alert('Record Saved.');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        CountReedCam();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
      
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;



        ModalPopupExtender1.Show();
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/OPS/ShortFall_Plan.aspx");
    }
    protected void txtGreyAdjustment_TextChanged(object sender, EventArgs e)
    {
        TextBox txtGreyAdjustment = sender as TextBox;
        GridViewRow gvrow = (GridViewRow)txtGreyAdjustment.NamingContainer;
        TextBox GreighReq = (TextBox)gvrow.FindControl("txtGreigh");
        Label Grey_Reamining = (Label)gvrow.FindControl("lblGreyRemaining");
        Label Orderno = (Label)gvrow.FindControl("lblOrderno");
        TextBox WeavingSort = (TextBox)gvrow.FindControl("lblSort1");
        Label LineItem = (Label)gvrow.FindControl("lblLineItem");
        TextBox Greigh = (TextBox)gvrow.FindControl("txtGreigh");
        Label lblLoomsPerDay = (Label)gvrow.FindControl("lblLoomsPerDay");
        Label OrderQty = (Label)gvrow.FindControl("lblOrderQty");
        TextBox Sizing = (TextBox)gvrow.FindControl("txtSizing");
        if(GreighReq.Text != "0")
        {
             float Rem = float.Parse(GreighReq.Text) - float.Parse(txtGreyAdjustment.Text);
             Grey_Reamining.Text = Rem.ToString();
             sql = "EXEC JCT_OPS_WEAVING_SIZING " + Grey_Reamining.Text + ",  '" + WeavingSort.Text + "','" + Orderno.Text + "'," + LineItem.Text + "";
             Sizing.Text = obj1.FetchValue(sql).ToString();
             sql = "SELECT dbo.udf_GetNumDaysInMonth(" + txtEffecFrom.Text + ") NumDaysInMonth";
             float Looms = float.Parse(Grey_Reamining.Text) / float.Parse(obj1.FetchValue(sql).ToString());
             lblLoomsPerDay.Text = Looms.ToString();
        }
    }
   
    protected void txtSortSearch_TextChanged(object sender, EventArgs e)
    {
        sql = "jct_OPS_Search_Orders_While_Planning";
        SqlCommand cmd = new SqlCommand(sql,obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EffecFrom", txtEffecFrom.Text);
        cmd.Parameters.AddWithValue("@Plant", ddlPlant.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@year_month", yearMonth());
        cmd.Parameters.AddWithValue("CotSyn", ddlCotSyn.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@orderno", txtorderNo.Text);
        cmd.Parameters.AddWithValue("@Sort", txtSortSearch.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.PageSize = 20;
        GridView1.DataSource = ds;
        GridView1.DataBind();
        
    }
    protected void txtorderNo_TextChanged(object sender, EventArgs e)
    {
        sql = "jct_OPS_Search_Orders_While_Planning";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EffecFrom", txtEffecFrom.Text);
        cmd.Parameters.AddWithValue("@Plant", ddlPlant.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@year_month", yearMonth());
        cmd.Parameters.AddWithValue("CotSyn", ddlCotSyn.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@orderno", txtorderNo.Text);
        cmd.Parameters.AddWithValue("@Sort", txtSortSearch.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.PageSize = 20;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void lnkFetch_Command(object sender, CommandEventArgs e)
    {

    }

    protected void lnkSaved_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        sql = "jct_OPS_VIEW_MONTHLY_PLAN_SAVED";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EffecFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text;
        cmd.Parameters.Add("@Year_Month", SqlDbType.Decimal).Value = yearMonth();
        cmd.Parameters.Add("@CotSyn", SqlDbType.VarChar, 20).Value = ddlCotSyn.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

}