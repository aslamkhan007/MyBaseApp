using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Globalization;
using System.IO;

public partial class Courier_Tracking_System_Authorize_Courier_Requests10 : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    string sql;
    ArrayList CheckBoxArray;
    ArrayList TextBoxValue;
    SendMail sm=new SendMail();
    protected void Page_Load(object sender, EventArgs e)
        {

           // Response.Cache.SetNoStore();
          //  ViewState.Clear();
     
    }

    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

      
    //  if (ddlSelectType.SelectedItem.Text == "Pending")
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            Label lblSerialNo = (Label)e.Row.Cells[1].FindControl("lblSerial");
    //            DropDownList ddlCourierType = (DropDownList)e.Row.Cells[7].FindControl("ddlCourierType");
    //            DropDownList ddlCourierService = (DropDownList)e.Row.Cells[8].FindControl("ddlCourierService");
    //            DropDownList ddlDeliveryType = (DropDownList)e.Row.Cells[9].FindControl("ddlDeliveryType");
    //            sql = "Select Courier_Service from jct_courier_request_test where Serial_no='" + lblSerialNo.Text + "' and Cost_Center='"+ ddlDepartment.SelectedItem.Value +"' ";
    //            ddlCourierService.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //            sql = "SELECT Courier_Type FROM jct_courier_request_test WHERE Serial_no='" + lblSerialNo.Text + "' and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
    //            ddlCourierType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //            sql = "Select Delivery_Type from jct_courier_request_test where Serial_no='" + lblSerialNo.Text + "'  and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
    //            ddlDeliveryType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //        }
    //                for (int r = 0; r <= GridView1.Rows.Count - 1; r++)
    //                {
    //                    if (GridView1.Rows[r].RowType == DataControlRowType.DataRow)
    //                    {
    //                        // add onclick attribute for checkbox to change row back color
    //                        CheckBox cb = (CheckBox)GridView1.Rows[r].FindControl("Chk");
    //                        cb.Attributes.Add("onclick", "setRowBackColor(this,'" + GridView1.Rows[r].RowState.ToString() + "');");
    //                    }
    //                  }
    //    }
    //    else
    //    {
          
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            Label lblSerialNo = (Label)e.Row.Cells[1].FindControl("lblSerial");
    //            DropDownList ddlCourierType = (DropDownList)e.Row.Cells[7].FindControl("ddlCourierType");
    //            DropDownList ddlCourierService = (DropDownList)e.Row.Cells[8].FindControl("ddlCourierService");
    //            DropDownList ddlDeliveryType = (DropDownList)e.Row.Cells[9].FindControl("ddlDeliveryType");
    //        sql = "Select Courier_Service from jct_courier_request_test where Serial_no='" + lblSerialNo.Text + "' and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
    //        ddlCourierService.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //        sql = "SELECT Courier_Type FROM jct_courier_request_test WHERE Serial_no='" + lblSerialNo.Text + "' and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
    //        ddlCourierType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //        sql = "Select Delivery_Type from jct_courier_request_test where Serial_no='" + lblSerialNo.Text + "'  and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
    //        ddlDeliveryType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //        CheckBox cb1 = (CheckBox)e.Row.FindControl("chk");
    //        TextBox Slip_No = (TextBox)e.Row.FindControl("txtSlipNo");
    //        TextBox Cost = (TextBox)e.Row.FindControl("txtCost");
    //        Label Cost_Center = (Label)e.Row.FindControl("lblCostCenter");
    //        TextBox User_RefNo = (TextBox)e.Row.FindControl("txtUserRefNo");
    //        cb1.Enabled = false;
    //        ddlCourierType.Enabled = false;
    //        ddlCourierService.Enabled = false;
    //        ddlDeliveryType.Enabled = false;
    //        Slip_No.Enabled = false;
    //        Cost.Enabled = false;
    //        User_RefNo.Enabled = false;
    //        }

    //        //for (int r = 0; r <= GridView1.Rows.Count - 1; r++)
    //        //{
    //        //    if (GridView1.Rows[r].RowType == DataControlRowType.DataRow)
    //        //    {

    //        //        CheckBox cb1 = (CheckBox)GridView1.Rows[r].FindControl("chk");
    //        //        TextBox Slip_No = (TextBox)GridView1.Rows[r].FindControl("txtSlipNo");
    //        //        TextBox Cost = (TextBox)GridView1.Rows[r].FindControl("txtCost");
    //        //        Label Cost_Center = (Label)GridView1.Rows[r].FindControl("lblCostCenter");
    //        //        TextBox User_RefNo = (TextBox)GridView1.Rows[r].FindControl("txtUserRefNo");
    //        //        cb1.Enabled = false;
    //        //        ddlCourierType.Enabled = false;
    //        //        ddlCourierService.Enabled = false;
    //        //        ddlDeliveryType.Enabled = false;
    //        //        Slip_No.Enabled = false;
    //        //        Cost.Enabled = false;
    //        //        User_RefNo.Enabled = false;
    //        //    }
    //        //}
    //    }
    //}

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (ddlSelectType.SelectedItem.Text == "Pending")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSerialNo = (Label)e.Row.Cells[1].FindControl("lblSerial");
                DropDownList ddlCourierType = (DropDownList)e.Row.Cells[7].FindControl("ddlCourierType");
                DropDownList ddlCourierService = (DropDownList)e.Row.Cells[8].FindControl("ddlCourierService");
                DropDownList ddlDeliveryType = (DropDownList)e.Row.Cells[9].FindControl("ddlDeliveryType");
                sql = "Select Courier_Service from jct_courier_request where Serial_no='" + lblSerialNo.Text + "' and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlCourierService.SelectedItem.Text = obj1.FetchValue(sql).ToString();
                sql = "SELECT Courier_Type FROM jct_courier_request WHERE Serial_no='" + lblSerialNo.Text + "' and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlCourierType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
                sql = "Select Delivery_Type from jct_courier_request where Serial_no='" + lblSerialNo.Text + "'  and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlDeliveryType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
            }
            for (int r = 0; r <= GridView1.Rows.Count - 1; r++)
            {
                if (GridView1.Rows[r].RowType == DataControlRowType.DataRow)
                {
                    // add onclick attribute for checkbox to change row back color
                    CheckBox cb = (CheckBox)GridView1.Rows[r].FindControl("Chk");
                    cb.Attributes.Add("onclick", "setRowBackColor(this,'" + GridView1.Rows[r].RowState.ToString() + "');");
                }
            }
        }
        else
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSerialNo = (Label)e.Row.Cells[1].FindControl("lblSerial");
                DropDownList ddlCourierType = (DropDownList)e.Row.Cells[7].FindControl("ddlCourierType");
                DropDownList ddlCourierService = (DropDownList)e.Row.Cells[8].FindControl("ddlCourierService");
                DropDownList ddlDeliveryType = (DropDownList)e.Row.Cells[9].FindControl("ddlDeliveryType");
                sql = "Select Courier_Service from jct_courier_request where Serial_no='" + lblSerialNo.Text + "' and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlCourierService.SelectedItem.Text = obj1.FetchValue(sql).ToString();
                sql = "SELECT Courier_Type FROM jct_courier_request WHERE Serial_no='" + lblSerialNo.Text + "' and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlCourierType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
                sql = "Select Delivery_Type from jct_courier_request where Serial_no='" + lblSerialNo.Text + "'  and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlDeliveryType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
                CheckBox cb1 = (CheckBox)e.Row.FindControl("chk");
                TextBox Slip_No = (TextBox)e.Row.FindControl("txtSlipNo");
                TextBox Cost = (TextBox)e.Row.FindControl("txtCost");
                Label Cost_Center = (Label)e.Row.FindControl("lblCostCenter");
                TextBox User_RefNo = (TextBox)e.Row.FindControl("txtUserRefNo");
                cb1.Enabled = false;
                ddlCourierType.Enabled = false;
                ddlCourierService.Enabled = false;
                ddlDeliveryType.Enabled = false;
                Slip_No.Enabled = false;
                Cost.Enabled = false;
                User_RefNo.Enabled = false;
            }

          
        }
    }

    protected void lnkAuthorize_Click(object sender, EventArgs e)
    {
        if (ddlSelectType.SelectedItem.Text == "Pending")
        {
       // CheckBox cb = (CheckBox)GridView1.FindControl("chk");
        for (int i = 0; i <= GridView1.Rows.Count -1 ; i++)
        {
            GridViewRow grv = GridView1.Rows[i];
            CheckBox cb = (CheckBox)grv.FindControl("chk");
            Label lblSerial = (Label)grv.FindControl("lblSerial");
            TextBox Slip_No = (TextBox)grv.FindControl("txtSlipNo");
            TextBox Cost = (TextBox)grv.FindControl("txtCost");
            Label Send_To = (Label)grv.FindControl("lblRequestedBy");
            TextBox User_RefNo = (TextBox)grv.FindControl("txtUserRefNo");
            HtmlAnchor Serial_no = (HtmlAnchor)grv.FindControl("lnkRefNo");
            Label Cost_Center = (Label)grv.FindControl("lblCostCenter");
            DropDownList CourierType = (DropDownList)grv.FindControl("ddlCourierType");
            DropDownList CourierService = (DropDownList)grv.FindControl("ddlCourierService");
            DropDownList DeliveryType = (DropDownList)grv.FindControl("ddlDeliveryType");
           if (cb.Checked==true && cb.Enabled==true)
           {
               try 
               {   
                   obj.ConOpen();
                   if (Cost.Text == "")
                   {
                       sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Dept_Code,Authorize_Date,Authorize_By,Status,User_RefNo)values(@Serial_No,@Slip_No,@Dept_Code,@Authorize_Date,@Authorize_By,@Status,@User_RefNo) ";
                       SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                       cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
                       cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text;
                       cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
                       cmd.Parameters.Add("@Authorize_Date", SqlDbType.DateTime).Value = DateTime.Today;
                       cmd.Parameters.Add("@Authorize_By", SqlDbType.VarChar, 30).Value = Session["EmpName"];
                       cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
                       cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 20).Value = User_RefNo.Text;
                       cmd.ExecuteNonQuery();
                   }
                   else
                   { 
                    sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Cost,Dept_Code,Authorize_Date,Authorize_By,Status,User_RefNo)values(@Serial_No,@Slip_No,@Cost,@Dept_Code,@Authorize_Date,@Authorize_By,@Status,@User_RefNo) ";
                   SqlCommand cmd = new SqlCommand(sql,obj.Connection());
                   cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
                   cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text ;
                   cmd.Parameters.Add("@Cost", SqlDbType.Float).Value =  Cost.Text;
                   cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
                   cmd.Parameters.Add("@Authorize_Date", SqlDbType.DateTime).Value = DateTime.Today;
                   cmd.Parameters.Add("@Authorize_By", SqlDbType.VarChar, 30).Value = Session["EmpName"];
                   cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
                   cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 20).Value = User_RefNo.Text;
                   cmd.ExecuteNonQuery();
                   }
                  
                   CourierType.Enabled = false;
                   CourierService.Enabled = false;
                   DeliveryType.Enabled = false;
                   cb.Enabled = false;
                   Cost.Enabled = false;
                   Slip_No.Enabled = false;
                   User_RefNo.Enabled = false;
                   sql = "Update jct_courier_request set Status='A' , Authorized_Date='" + System.DateTime.UtcNow + "',Authorized_By='"+ Session["EmpCode"] +"',Courier_Type='"+ CourierType.SelectedItem.Text +"',Courier_Service='"+ CourierService.SelectedItem.Text +"',Delivery_Type='"+ DeliveryType.SelectedItem.Text +"' where Serial_no='" + lblSerial.Text +"'";// Serial_no.InnerText.Trim() + "'";
                   obj1.UpdateRecord(sql);
                   sql = "Select empcode from jct_empmast_base where empname='" + Send_To.Text + "'";
                   string SendMailTo = obj1.FetchValue(sql).ToString();
                   sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = '" + SendMailTo + "' and company_code ='JCT00LTD'";
                   string SendmailTo1 = obj1.FetchValue(sql).ToString();
                   SendMailCourier(SendmailTo1, CourierService.SelectedItem.Text, CourierType.SelectedItem.Text, DeliveryType.SelectedItem.Text, lblSerial.Text, Slip_No.Text, Send_To.Text);
                   cb.Attributes.Add("onclick", "setRowBackColor(this,'" + grv.RowState.ToString() + "');");

               }
               catch(Exception ex)
               {
                   ex.ToString();
               }
               finally
               {
               obj.ConClose();
               }
            
         
           }
        }
        }
    }
 /*   protected void ddlSelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "exec jct_courier_fetch_request @DeliveryType,@SelectType ";
        //SqlConnection Con = new SqlConnection(obj.ConOpen());
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@DeliveryType", SqlDbType.VarChar, 30).Value = ddlCourierType.SelectedItem.Text;
        cmd.Parameters.Add("@SelectType", SqlDbType.VarChar, 30).Value = ddlSelectType.SelectedItem.Text;
        obj.ConOpen();
       SqlDataReader   dr = cmd.ExecuteReader();
        //GridView1.DataSource = dr;
       // GridView1.DataBind();
        TextBox Slip_No = (TextBox)GridView1.FindControl("txtSlipNo");
        TextBox Cost = (TextBox)GridView1.FindControl("txtCost");
        LinkButton Serial_no = (LinkButton)GridView1.FindControl("lnkRefNo");
        Label Cost_Center = (Label)GridView1.FindControl("lblCostCenter");
        DropDownList CourierType = (DropDownList)GridView1.FindControl("ddlCourierType");
        DropDownList CourierService = (DropDownList)GridView1.FindControl("ddlCourierService");
        DropDownList DeliveryType = (DropDownList)GridView1.FindControl("ddlDeliveryType");
        Label RequestBy = (Label)GridView1.FindControl("lblRequestedBy");
        Label PartyName = (Label)GridView1.FindControl("lblPartyName");
        Label Subject = (Label)GridView1.FindControl("lblSubject");
        Label PartyAddress = (Label)GridView1.FindControl("lblPartyAddress");
        Label RequestedDate = (Label)GridView1.FindControl("lblRequestedDate");
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
               
                Slip_No.Text = dr[10].ToString();
                Cost.Text = dr[11].ToString();
                Serial_no.Text = dr[0].ToString();
                Cost_Center.Text = dr[8].ToString();
                CourierService.SelectedItem.Text = dr[6].ToString();
                CourierType.SelectedItem.Text = dr[5].ToString();
                DeliveryType.SelectedItem.Text = dr[7].ToString();
                RequestBy.Text = dr[1].ToString();
                PartyName.Text = dr[2].ToString();
                Subject.Text = dr[3].ToString();
                PartyAddress.Text = dr[4].ToString();
                RequestedDate.Text = dr[9].ToString();

            }
        }

    } */

    protected void SendMailCourier(String SendTo,String Courier_Service, String Courier_Type, String Delivery_Type, String Serial_No,String SlipNo,String RequestBy)
    {
        #region SendMail

        string sender_email;

        // sm.SendMail("jctadmin@jctltd.com", "", "Courier Request- " + txtRefNo.Text + " ", "Courier Request has been generated with reference ID - '"+ txtRefNo.Text +"' on "+System.DateTime.Today+". It will be visible in the Pending List of Couriers in the Courier tracking system.");

        string empcode = Session["EmpCode"].ToString();
        sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = @empcode and company_code ='JCT00LTD'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = empcode;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sql = "Select party_name from jct_courier_request where serial_no='" + Serial_No + "'";
                string partyname = obj1.FetchValue(sql).ToString();
                sender_email = dr[0].ToString();
                // sm.SendMail(SendTo, sender_email, "Courier Send - " + Serial_No + " ", "Courier Request has been Authroized and sent through Courier Service :'"+ Courier_Service +"' , Delivery : '"+ Delivery_Type +"', Courier_Type='"+ Courier_Type +"' . You can track you courier at '"+ Courier_Service +"' website using Courier Slip No. : '"+ SlipNo +"'. ");
                String msg = "<html><body><Table><tr><td>Hello " + RequestBy + ",</td></tr><tr><td>Your courier has been sent.</td></tr><tr><td>Details of the your courier are :</td></tr><tr><td><b> Courier ID : " + Serial_No + " </b></td></tr><tr><td>Party Name : " + partyname + "</td></tr><tr><td> Courier Service : " + Courier_Service + "</td></tr><tr><td>Courier Type : " + Courier_Type + "</td></tr> <tr><td> Delivery Type : " + Delivery_Type + "</td></tr><tr><td>Tracking ID : " + SlipNo + "</td></tr><tr><td> Dispatch Date : " + txtToDate.Text + " </tr></td> </br><tr><td></td></tr> <tr><td>Thanks..!!</td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";
                sm.SendMail(SendTo, "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
              //  sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
            }
            // sm.SendMail(SendTo, sender_email, "Courier Send ", "Courier Request has been Authroized and sent through Courier Service ");


        }
        else
        { }
        #endregion
    }
    

    protected void ddlSelectType_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillGrid();

       // GridView1_RowDataBound(sender,null);
   
    }
    protected void ddlCourierType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }

    public void FillGrid()
    {
        DataTable dt = new DataTable();
        sql = "exec jct_courier_fetch_request @CourierType,@SelectType,'"+ txtFromDate.Text +"','"+ txtToDate.Text +"','"+ ddlDepartment.SelectedValue +"'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@CourierType", SqlDbType.VarChar, 30).Value = ddlCourierType.SelectedItem.Text;
        cmd.Parameters.Add("@SelectType", SqlDbType.VarChar, 30).Value = ddlSelectType.SelectedItem.Text;
        obj.ConOpen();
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);

        sqlDa.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            //SHOW GRIDVIEW
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
 
    
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RememberOldValues();
        GridView1.PageIndex = e.NewPageIndex;
         sql = "exec jct_courier_fetch_request '" + ddlCourierType.SelectedItem.Text + "','" + ddlSelectType.SelectedItem.Text + "','" + txtFromDate.Text + "','" + txtToDate.Text + "','"+ ddlDepartment.SelectedValue +"' ";
        obj1.FillGrid(sql, ref GridView1);
        ReturnOldValues();
      
    }

    private void RememberOldValues()
    {
      
        if (ViewState["CheckBoxArray"] != null)
        {
            CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
          //  TextBoxValue =(ArrayList)ViewState["TextBoxValue"];
        }
        else
        {
            CheckBoxArray = new ArrayList();
          //  TextBoxValue = new ArrayList();
        }
        if (IsPostBack)
        {
            int CheckBoxIndex;
            bool CheckAllWasChecked = false;
            
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk =
                    (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                    CheckBoxIndex = GridView1.PageSize * GridView1.PageIndex + (i + 1);
                  //  TextBox txt = (TextBox)GridView1.Rows[i].Cells[0].FindControl("txtCost");
                    if (chk.Checked)
                    {
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) == -1
                            && !CheckAllWasChecked)
                        {
                            CheckBoxArray.Add(CheckBoxIndex);
                        //    TextBoxValue.Add(txt);
                        }
                    }
                    else
                    {
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1
                            || CheckAllWasChecked)
                        {
                            CheckBoxArray.Remove(CheckBoxIndex);
                        //    TextBoxValue.Remove(txt);
                        }
                    }
                }
            }
        }
         ViewState["CheckBoxArray"] = CheckBoxArray;
        // ViewState["TextBoxValue"] = TextBoxValue;
    }   
    
    private void ReturnOldValues()
    {
        ArrayList CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
       // ArrayList textboxvalue = (ArrayList)ViewState["TextBoxValue"];
        string checkAllIndex = "chkAll-" + GridView1.PageIndex;

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
            {
                if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                {
                    CheckBox chk =
                     (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                    TextBox txt = (TextBox)GridView1.Rows[i].Cells[0].FindControl("txtCost");
                    chk.Checked = true;
                   // string cost = (string)ViewState["TextBoxValue"];
                   // txt.Text = cost;
                   // GridView1.Rows[i].Attributes.Add("style", "background-color:aqua");
                    chk.Attributes.Add("onclick", "setRowBackColor(this,'" + GridView1.Rows[i].RowState.ToString() + "');");
                }
                else
                {
                    int CheckBoxIndex = GridView1.PageSize * (GridView1.PageIndex) + (i + 1);
                    if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1)
                    {
                        CheckBox chk =
                        (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                       
                        chk.Checked = true;
                       // GridView1.Rows[i].Attributes.Add("style", "background-color:aqua");
                        chk.Attributes.Add("onclick", "setRowBackColor(this,'" + GridView1.Rows[i].RowState.ToString() + "');");
                    }
                }
            }
        }
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void lnkAddCost_Click(object sender, EventArgs e)
    {
        sql = "exec jct_courier_fetch_Authorized_request '"+ ddlCourierType.SelectedItem.Text +"','"+ txtFromDate.Text +"','"+ txtToDate.Text +"','"+ ddlDepartment.SelectedItem.Value +"'";
        obj1.FillGrid(sql, ref GridView1);
    }
   
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
      
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            //GridView1.SelectedRow.FindControl("lnkFile");
           
              
                string filepath = Server.MapPath("~\\Courier Tracking System\\Attached_Files\\" + e.CommandArgument.ToString());
                if (File.Exists(filepath) == false)
                {
                    ShowAlertMsg("File Not Found.Please contact IT-HelpDesk @4212.");
                }
                else
                {
                    Response.ClearContent();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(e.CommandArgument.ToString())));
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument.ToString() + "");
                    Response.TransmitFile(Server.MapPath("~\\Courier Tracking System\\Attached_Files\\" + e.CommandArgument.ToString()));
                    Response.End();
          
                }
                
             
           
        }
    }
    public void ShowAlertMsg(string error1)
    {
        #region msg
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            // error1 = error1.Replace("'", "'")
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error1 + "');", true);
        }
        #endregion
    }
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridViewRow grv = GridView1.Rows[i];
                CheckBox cb = (CheckBox)grv.FindControl("chk");
                Label lblSerial = (Label)grv.FindControl("lblSerial");
                TextBox Slip_No = (TextBox)grv.FindControl("txtSlipNo");
                TextBox Cost = (TextBox)grv.FindControl("txtCost");
                Label Send_To = (Label)grv.FindControl("lblRequestedBy");
                TextBox User_RefNo = (TextBox)grv.FindControl("txtUserRefNo");
                HtmlAnchor Serial_no = (HtmlAnchor)grv.FindControl("lnkRefNo");
                Label Cost_Center = (Label)grv.FindControl("lblCostCenter");
                DropDownList CourierType = (DropDownList)grv.FindControl("ddlCourierType");
                DropDownList CourierService = (DropDownList)grv.FindControl("ddlCourierService");
                DropDownList DeliveryType = (DropDownList)grv.FindControl("ddlDeliveryType");
                if (cb.Checked == true && cb.Enabled == true)
                {
                    sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Dept_Code,Cancel_Date,Cancel_By,Status,User_RefNo)values(@Serial_No,@Slip_No,@Dept_Code,@Cancel_Date,@Cancel_By,@Status,@User_RefNo) ";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
                    cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text;
                    cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
                    cmd.Parameters.Add("@Cancel_Date", SqlDbType.DateTime).Value = DateTime.Today;
                    cmd.Parameters.Add("@Cancel_By", SqlDbType.VarChar, 30).Value = Session["EmpName"];
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "D";
                    cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 20).Value = User_RefNo.Text;
                    cmd.ExecuteNonQuery();
                    CourierType.Enabled = false;
                    CourierService.Enabled = false;
                    DeliveryType.Enabled = false;
                    cb.Enabled = false;
                    Cost.Enabled = false;
                    Slip_No.Enabled = false;
                    User_RefNo.Enabled = false;
                    sql = "Update jct_courier_request set Status='D' , Deleted_Date='" + DateTime.Now + "',Deleted_userCode='" + Session["EmpCode"] + "',Courier_Type='" + CourierType.SelectedItem.Text + "',Courier_Service='" + CourierService.SelectedItem.Text + "',Delivery_Type='" + DeliveryType.SelectedItem.Text + "' where Serial_no='" + lblSerial.Text + "'";// Serial_no.InnerText.Trim() + "'";
                    obj1.UpdateRecord(sql);
                    cb.Attributes.Add("onclick", "setRowBackColor(this,'" + grv.RowState.ToString() + "');");
                    ShowAlertMsg("Courier Cancelled..!!");
                }
            }
        }
        catch (Exception ex)
        {
            ShowAlertMsg("Error Occured.");
        }

    }
}