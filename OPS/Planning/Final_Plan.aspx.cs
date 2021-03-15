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
                //string rowID = String.Empty;
                //rowID = "row" + i;

                //grd.Rows[i].Attributes.Add("id", "row" + i);

                //grd.Rows[i].Attributes.Add("onclick", "ChangeRowColor(" + "'" + rowID + "'" + ")");
                 grd.SelectedRowStyle.BackColor=System.Drawing.Color.Red;
                //grd.Rows[i].Attributes.Add("onclick", "ChangeRowColor('" + grd.Rows[i].ClientID + " ')");
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
                    sql = "Exec jct_ops_save_planning_detail '" + ddlPlant.SelectedItem.Text + "','" + ddlCotSyn.SelectedItem.Text + "'," + yearMonth() + ", '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "' ," + LineItem.Text + "," + PlanQty.Text + "," + Sizing.Text + ",'" + Shed.Text + "'," + RPM.Text + "," + Efficiency.Text + "," + LoomAllot.Text + "," + WvgCompletionDt.Text + " ";
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
                        sql = "Exec jct_ops_save_planning_detail '" + ddlPlant.SelectedItem.Text + "','" + ddlCotSyn.SelectedItem.Text + "'," + yearMonth() + ", '" + orderno.Text + "','" + Sort.Text + "','" + variant.Text + "' ," + LineItem.Text + "," + PlanQty.Text + "," + Sizing.Text + ",'" + Shed.Text + "'," + RPM.Text + "," + Efficiency.Text + "," + LoomAllot.Text + ",'" + WvgCompletionDt.Text + "' ";
                        obj1.UpdateRecord(sql);
                    }
                    catch (SqlException ex)
                    {
                        //FMsg.CssClass = "errormsg";
                        //FMsg.Message = ex.Message;
                        //FMsg.Display();
                         script = "alert('" + ex.Message + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                    finally
                    {

                    }
                }
                else
                {
                     script = "alert('Please select record.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script,true);
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ForeColor = System.Drawing.Color.Red;
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

             sql = "Exec jct_ops_Freeze_UnFreeze_plan '" + ddlPlant.SelectedItem.Text + "'," + yearMonth() + ",'" + ddlCotSyn.SelectedItem.Text + "','"+ orderno.Text +"','"+ Sort.Text +"','"+ variant.Text +"','" + Flag + "'";
             String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
             SqlConnection conn = new SqlConnection(ConStr);
             conn.Open();
             SqlCommand cmd = new SqlCommand(sql, conn);
             // cmd.CommandType = CommandType.StoredProcedure;
             cmd.ExecuteNonQuery();
             conn.Close();
         
             sql = "EXEC JCT_OPS_CHECK_CHANGE_SEL_QTY_EMAIL_SALEPERSON '"+ orderno.Text +"','"+ Sort.Text +"','"+ variant.Text +"','"+ yearMonth() +"'";
             SqlDataReader dr = obj1.FetchReader(sql);
             if (dr.HasRows)
             {
                 while (dr.Read())
                 {
                     String email = dr[2].ToString();
                     String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>You are receiving this email on the behalf of Planning Dept. It has been found that your  </p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3> Your Planned Quantity:  " + dr[7].ToString() + "</H3> </p><p> <H3>Planned Quantity by Planning Dept. : " + dr[8].ToString() + "</H3></p></br><p>This  Freezed plan for this order as per freezed date :"+ dr[9].ToString() +" by planning dept. </p><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                     Sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Change in Planed Quantity", body);
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
             //CheckPlan_Freezed(GridView1);
             //FMsg.CssClass = "errormsg";
             //FMsg.Message = "The Plan has been freezed for the selected month.";
             //FMsg.Display();

              script = "alert('The Plan has been freezed for the selected month.');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }
         else
         {

             for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
             {
                 CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("Update");
                 if (cb.Checked == true)
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
                     //cb1.Enabled = false;
                     //PlanQty.Enabled = false;
                     //Shed.Enabled = false;
                     //Sizing.Enabled = false;
                     //RPM.Enabled = false;
                     //Efficiency.Enabled = false;
                     //LoomAllot.Enabled = false;

                 }
                 else
                 {
                      script = "alert('Please select record.');";
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                 }
             }
             CheckPlan_Freezed(GridView1);
                 //FMsg.CssClass = "errormsg";
                 //FMsg.Message = "Selected Items have been freezed.";
                 //FMsg.Display();
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
        Label ClothType = (Label)gridRow.FindControl("lblClothType");
        TextBox Sizing = (TextBox)gridRow.FindControl("txtSizing");
        Label Sort = (Label)gridRow.FindControl("lblSort");
        Label variant = (Label)gridRow.FindControl("lblVariant");
        Label LineItem = (Label)gridRow.FindControl("lblLineItem");
        sql = " SELECT  DISTINCT  CASE WHEN LOCATION = '" + Plant.Text + "'   THEN " + PlanQty.Text + " + " + PlanQty.Text + " * 0.12  ELSE " + PlanQty.Text + " + " + PlanQty.Text + " * 0.15  END AS [Sizing]  FROM      dbo.JCT_OPS_MONTHLY_PLANNING      WHERE item_no='" + Sort.Text + "' and variant='" + variant.Text + "' and order_srl_no=" + LineItem.Text + " and  yearmonth = " + yearMonth() + " ";
        if (obj1.CheckRecordExistInTransaction(sql))
        {
            Sizing.Text = obj1.FetchValue(sql).ToString();

        }
        else
        {
            Sizing.Text = "";
        }
    }
    protected void lnkFetch_Click1(object sender, EventArgs e)
    {
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

                sql = " EXEC JCT_OPS_DELAY_ORDERS '" + orderno.Text + "','" + Sort.Text + "'," + LineItem.Text + ",'"+ txtEffecFrom.Text +"'";
                if (obj1.FetchValue(sql).ToString() == "TRUE")
                {
                    GridView1.Rows[i].CssClass = "FooterStyleRed";
                }

            }
        }
        catch (SqlException ex)
        {
            //FMsg.CssClass = "errormsg";
            //FMsg.Message = ex.Message;
            //FMsg.Display();
             script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }

        
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

                //sql = "EXEC JCT_OPS_CHECK_CHANGE_SEL_QTY_EMAIL_SALEPERSON '"+ orderno.Text +"','"+ Sort.Text +"','"+ variant.Text +"','"+ yearMonth() +"'";
                //SqlDataReader dr = obj1.FetchReader(sql);
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        String email = dr[2].ToString();
                //        String body = "<p>Hello " + dr[3].ToString() + ",</p> <p>You are receiving this email on the behalf of Planning Dept. It has been found that your  </p> </p> <H3>Order No. :" + dr[5].ToString() + " </H3> </p> <p> <H3> Sort No. : " + dr[4].ToString() + "</H3>  </p> <p><h3>Variant :  " + dr[6].ToString() + "</h3></p><p><H3> Your Planned Quantity:  " + dr[7].ToString() + "</H3> </p><p> <H3>Planned Quantity by Planning Dept. : " + dr[8].ToString() + "</H3></p></br><p>This  Freezed plan for this order as per freezed date :"+ dr[9].ToString() +" by planning dept. </p><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>";
                //        Sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Change in Planed Quantity", body);
                //    }
                //}
                //dr.Close();
                //}
               
            }
            sql = "Insert into JCT_OPS_FREEZE_UNFREEZE_PLAN_REMARKS(yearmonth,unfreeze_dt,remarks,unfreezed_by)values(" + yearMonth() + ",getdate(),'" + txtRemarks.Text + "','" + Session["EmpCode"] + "')";
            obj1.InsertRecord(sql);
            GridView1.DataSource = null;
            GridView1.DataBind();
            //FMsg.CssClass = "errormsg";
            //FMsg.Message = "The Plan has been Unfreezed for the selected month.";
            //FMsg.Display();
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
}