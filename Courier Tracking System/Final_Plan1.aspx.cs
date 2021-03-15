using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_Planning_Final_Plan : System.Web.UI.Page
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
        sql = "Select * from JCT_OPS_MONTHLY_PLANNING where yearmonth =" + yearMonth() + " and Location='" + ddlPlant.SelectedItem.Text + "' and ( Cloth_Type ='" + ddlCotSyn.SelectedItem.Text + "' or '" + ddlCotSyn.SelectedItem.Text + "'='All') and PlanStart_Date is not null and PlanEnd_Date is not null ";
        if (obj1.CheckRecordExistInTransaction(sql))
        {
            //script = "alert('Plan has been generated previously. Please Click 'FETCH' button to retreive the plan.');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            obj1.Alert("Plan has been generated previously. Please Click 'FETCH' button to retreive the plan.");
            FMsg.CssClass = "errormsg";
            FMsg.Message="Plan has been generated previously. Please Click 'FETCH' button to retreive the plan.";
            FMsg.FadeOutDuration=5000;
            FMsg.Display();


            //return;
        }
        else
        { 
         sql = " exec jct_ops_monthly_generate_plan '"+ txtEffecFrom.Text +"','"+ txtEffecTo.Text +"','"+ ddlPlant.SelectedItem.Text +"','"+ ddlCotSyn.SelectedItem.Text +"',"+ yearMonth() +"";
         obj1.FillGrid(sql, ref GridView1);
         CheckWvgCompeletionDate(GridView1);
        }
       
     
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
            TextBox Shed = (TextBox)grd.Rows[i].FindControl("txtShed");
            TextBox RPM = (TextBox)grd.Rows[i].FindControl("txtRPM");
            TextBox Efficiency = (TextBox)grd.Rows[i].FindControl("txtEfficiency");
            TextBox LoomAllot = (TextBox)grd.Rows[i].FindControl("txtLoomAllot");
            Label WvgCompletionDt = (Label)grd.Rows[i].FindControl("lblWvgCompletionDt");

            sql = " EXEC JCT_OPS_DELAY_ORDERS '" + orderno.Text + "','" + Sort.Text + "'," + LineItem.Text + ",'"+ txtEffecFrom.Text +"'";
            if (obj1.FetchValue(sql).ToString() == "TRUE")
            {
                 grd.SelectedRowStyle.BackColor=System.Drawing.Color.Red;
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


        sql = "Select * from JCT_OPS_MONTHLY_PLANNING where yearmonth=" + yearMonth() + " and Location='" + ddlPlant.SelectedItem.Text + "' and ( Cloth_Type ='" + ddlCotSyn.SelectedItem.Text + "' or '" + ddlCotSyn.SelectedItem.Text + "'='All') and mode='Freezed' ";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                 script = "alert('Plan Cannot be modified once Freezed. If you want to change the current plan, please UnFreeze it first.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }

        CheckBox cbHeader = (CheckBox)GridView1.HeaderRow.FindControl("Update");

        if (cbHeader.Checked == true)
        {
            //SqlTransaction Tran;
            //SqlConnection conn = new SqlConnection();
            //Tran = conn.BeginTransaction();

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                try
                {
                    Label orderno = (Label)GridView1.Rows[i].FindControl("lblorderno");
                    Label Sort = (Label)GridView1.Rows[i].FindControl("lblSort");
                    Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                    Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                    TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                    TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
                    TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                    TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                    TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                    TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                    Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                    TextBox Reed = (TextBox)GridView1.Rows[i].FindControl("txtReed");
                    TextBox Cam = (TextBox)GridView1.Rows[i].FindControl("txtTapperet");
                    Shed.Text = Shed.Text.TrimStart();
                    sql = "Exec jct_ops_save_planning_detail '" + ddlPlant.SelectedItem.Text + "','" + ddlCotSyn.SelectedItem.Text + "'," + yearMonth() + ", '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "' ," + LineItem.Text + "," + PlanQty.Text + "," + Sizing.Text + ",'" + Shed.Text + "'," + RPM.Text + "," + Efficiency.Text + "," + LoomAllot.Text + "," + WvgCompletionDt.Text + " ,"+ Reed.Text +","+ Cam.Text +"";
                    obj1.UpdateRecord(sql);
                }
                catch (SqlException ex)
                {
                    //FMsg.CssClass = "errormsg";
                    //FMsg.Message = ex.Message;
                    //FMsg.Display();
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
                        Label variant = (Label)GridView1.Rows[i].FindControl("lblVariant");
                        Label LineItem = (Label)GridView1.Rows[i].FindControl("lblLineItem");
                        TextBox PlanQty = (TextBox)GridView1.Rows[i].FindControl("txtPlanQty");
                        TextBox Sizing = (TextBox)GridView1.Rows[i].FindControl("txtSizing");
                        TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                        TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                        TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                        TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                        Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                        TextBox Reed = (TextBox)GridView1.Rows[i].FindControl("txtReed");
                        TextBox Cam = (TextBox)GridView1.Rows[i].FindControl("txtTapperet");
                        Shed.Text = Shed.Text.TrimStart();
                        sql = "Exec jct_ops_save_planning_detail '" + ddlPlant.SelectedItem.Text + "','" + ddlCotSyn.SelectedItem.Text + "'," + yearMonth() + ", '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "' ," + LineItem.Text + "," + PlanQty.Text + "," + Sizing.Text + ",'" + Shed.Text + "'," + RPM.Text + "," + Efficiency.Text + "," + LoomAllot.Text + "," + WvgCompletionDt.Text + ","+ Reed.Text +","+ Cam.Text +" ";
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
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
          
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;

            TextBox Looms = (TextBox)e.Row.FindControl("txtLoomAllot");
            Label WvgCompletionDt = (Label)e.Row.FindControl("lblWvgCompletionDt");
                if (Looms.Text != "")
                {
                    sumLooms = sumLooms + int.Parse(Looms.Text);
                }
            ToatalWvgDays = ToatalWvgDays + float.Parse(WvgCompletionDt.Text);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Text = sumLooms.ToString();
           e.Row.Cells[20].Text = ToatalWvgDays.ToString();
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
                 TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
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
                     //String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>You are receiving this email on the behalf of Planning Dept. It has been found that your  </p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3> Your Planned Quantity:  " + dr[7].ToString() + "</H3> </p><p> <H3>Planned Quantity by Planning Dept. : " + dr[8].ToString() + "</H3></p></br><p>This  Freezed plan for this order as per freezed date :"+ dr[9].ToString() +" by planning dept. </p><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                     String body = "<p>Plan has been freezed for the next month . You can find the plan in the attached file. </p>";
                  //   Sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Change in Planed Quantity", body);
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
                     TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
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
            TextBox Shed = (TextBox)grd.Rows[i].FindControl("txtShed");
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
        Label variant = (Label)gridRow.FindControl("lblVariant");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        Label lblReqdt = (Label)gridRow.FindControl("lblReqdt");
        Label lblWvgCompletionDt = (Label)gridRow.FindControl("lblWvgCompletionDt");
        sql = "SELECT  DISTINCT  CASE WHEN LOCATION = '" + Plant.Text + "'   THEN " + PlanQty.Text + " + " + PlanQty.Text + " * 0.12  ELSE " + PlanQty.Text + " + " + PlanQty.Text + " * 0.15  END AS [Sizing]  FROM      dbo.JCT_OPS_MONTHLY_PLANNING      WHERE item_no='" + Sort.Text + "' and variant='" + variant.Text + "' and order_srl_no=" + LineItem.Text + " and  yearmonth = " + yearMonth() + " ";
        if (obj1.CheckRecordExistInTransaction(sql))
        {
            Sizing.Text = obj1.FetchValue(sql).ToString();
            sql = "Exec jct_ops_update_weaving_completion_date '"+ Orderno.Text + "' , " + PlanQty.Text + " ,'" + Sort.Text + "','" + LineItem.Text + "'," + yearMonth() + ",'"+ txtEffecFrom.Text +"'";
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
         CountRapierReed = 0;
         CountAirjetReed = 0;
         CountSulzerReed = 0;
         CountAirjetCam = 0;
         CountSulzerCam = 0;
        try
        {

            //  sql = " exec jct_OPS_VIEW_MONTHLY_PLAN '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "'," + ddlRevisionNo.SelectedItem.Text + "";
            sql = " exec jct_OPS_VIEW_MONTHLY_PLAN  '"+ txtEffecFrom.Text +"','" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter(sql, obj.Connection());
            Da.SelectCommand.CommandTimeout = 0;
            Da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
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
                TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
                TextBox RPM = (TextBox)GridView1.Rows[i].FindControl("txtRPM");
                TextBox Efficiency = (TextBox)GridView1.Rows[i].FindControl("txtEfficiency");
                TextBox LoomAllot = (TextBox)GridView1.Rows[i].FindControl("txtLoomAllot");
                Label WvgCompletionDt = (Label)GridView1.Rows[i].FindControl("lblWvgCompletionDt");
                hdfWvgCompletionDt.Value = WvgCompletionDt.Text;
                sql = " EXEC JCT_OPS_DELAY_ORDERS '" + orderno.Text + "','" + Sort.Text + "'," + LineItem.Text + ",'"+ txtEffecFrom.Text +"'";
                if (obj1.FetchValue(sql).ToString() == "TRUE")
                {
                    GridView1.Rows[i].CssClass = "FooterStyleRed";
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
                TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
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
                        TextBox Shed = (TextBox)GridView1.Rows[i].FindControl("txtShed");
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
        sql = "SELECT yearmonth,team_code,order_no,order_dt,item_no,order_srl_no,amend_no,variant,blend,req_dt,req_qty,sel_qty,SHED,EFFICIENCY,RPM,LOOMS_REQUIRED,SIZING,LOCATION,CLOTH_TYPE,Freeze_Dt,WvgCompletionDate AS [WvgCompletionDays] FROM dbo.JCT_OPS_MONTHLY_PLANNING WHERE mode='Freezed'";
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
        Label Orderno = (Label)gridRow.FindControl("lblOrderno");
        Label ClothType = (Label)gridRow.FindControl("lblClothType");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        DropDownList Shed = (DropDownList)gridRow.FindControl("ddlShed");
        Label Sort = (Label)gridRow.FindControl("lblSort");
        Label variant = (Label)gridRow.FindControl("lblVariant");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        Label lblReqdt = (Label)gridRow.FindControl("lblReqdt");
        TextBox Reed = (TextBox)gridRow.FindControl("txtReed");
        TextBox Cam = (TextBox)gridRow.FindControl("txtTapperet");

        Label lblWvgCompletionDt = (Label)gridRow.FindControl("lblWvgCompletionDt");
        sql = "SELECT  CONVERT(NUMERIC(5, 2), ROUND(( "+ Plan_Qty.Text +" / ( MAX(Prod_shifts) * 3 * ( CASE WHEN ISNULL(" + txtLoomAllot.Text + ", 1) = 0 THEN 1  ELSE ISNULL(" + txtLoomAllot.Text + ",   1)  END ) ) ), 1)) AS [CompletionDays] FROM    production..jct_fab_results WHERE   sort_no = SUBSTRING('"+ Sort.Text +"', 4, LEN('"+ Sort.Text +"'))";
        lblWvgCompletionDt.Text = obj1.FetchValue(sql).ToString();
        sql = "Select case when Convert(datetime,'"+ txtEffecFrom.Text +"') + "+ lblWvgCompletionDt.Text +" < Convert(datetime,'"+ lblReqdt.Text +"',103) then 'True' else 'False' END";
        if (obj1.FetchValue(sql) == "True")
        {
            gridRow.ForeColor = System.Drawing.Color.Gray; 
        }
        else
        {
            gridRow.ForeColor = System.Drawing.Color.Red;
        }

        if (Shed.SelectedItem.Value == "R")
        {
            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + Sort.Text + "','" + Shed.Text + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountRapierReed + ",0";
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
            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + Sort.Text + "','" + Shed.Text + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountAirjetReed + "," + CountAirjetCam+ "";
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
        
            sql = "Exec JCT_OPS_WEAVEING_REED_STOCK '" + Sort.Text + "','" + Shed.SelectedItem.Value.Substring(0, 1) + "','" + txtLoomAllot.Text + "'," + yearMonth() + "," + CountSulzerReed + "," + CountSulzerCam + "";
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
        TextBox Greigh = (TextBox)gridRow.FindControl("txtGreigh");
        Label OrderQty = (Label)gridRow.FindControl("lblOrderQty");
        if (GreighReq.SelectedIndex == 0)
        {
            sql = "Select  variationAllowd from production..JCT_Process_Greigh_Request_Variation WHERE GETDATE() BETWEEN Eff_From AND Eff_To and " + Plan_Qty.Text + " between MtrFrom and MtrUpto and CaseType='" + GreighReq.SelectedItem.Text + "' ";
            sql = "Select " + OrderQty.Text + " + " + OrderQty.Text + " * " + obj1.FetchValue(sql).ToString() + " /100";
            Greigh.Text = obj1.FetchValue(sql).ToString();
        }
        else
        {
            sql = "Select variationAllowd from production..JCT_Process_Greigh_Request_Variation WHERE GETDATE() BETWEEN Eff_From AND Eff_To and CaseType='" + GreighReq.SelectedItem.Text + "' ";
            sql = "Select " + OrderQty.Text + " + " + OrderQty.Text + " * " + obj1.FetchValue(sql).ToString() +" /100" ;
            Greigh.Text = obj1.FetchValue(sql).ToString();

        }
     
    }

    protected void lnkSaveRow_Click(object sender, EventArgs e)
    {
      

        LinkButton Save = (LinkButton)sender;
        GridViewRow gridRow = (GridViewRow)Save.Parent.Parent;
        Label orderno = (Label)gridRow.FindControl("lblorderno");
        Label Sort = (Label)gridRow.FindControl("lblSort");
        Label variant = (Label)gridRow.FindControl("lblVariant");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        TextBox PlanQty = (TextBox)gridRow.FindControl("txtPlanQty");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        TextBox Shed = (TextBox)gridRow.FindControl("txtShed");
        TextBox RPM = (TextBox)gridRow.FindControl("txtRPM");
        TextBox Efficiency = (TextBox)gridRow.FindControl("txtEfficiency");
        TextBox LoomAllot = (TextBox)gridRow.FindControl("txtLoomAllot");
        Label WvgCompletionDt = (Label)gridRow.FindControl("lblWvgCompletionDt");
        TextBox Reed = (TextBox)gridRow.FindControl("txtReed");
        TextBox Cam = (TextBox)gridRow.FindControl("txtTapperet");
        sql = "Exec jct_ops_save_planning_detail '" + ddlPlant.SelectedItem.Text + "','" + ddlCotSyn.SelectedItem.Text + "'," + yearMonth() + ", '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "' ," + LineItem.Text + "," + PlanQty.Text + "," + Sizing.Text + ",'" + Shed.Text + "'," + RPM.Text + "," + Efficiency.Text + "," + LoomAllot.Text + "," + WvgCompletionDt.Text + ","+ Reed.Text +","+ Cam.Text +" ";
        obj1.UpdateRecord(sql);
        CountReedCam();
    }

   
}