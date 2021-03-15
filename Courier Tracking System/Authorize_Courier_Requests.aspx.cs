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
using System.Text;
using System.Net.Mail;

public partial class Courier_Tracking_System_Authorize_Courier_Requests : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    string sql;
    ArrayList CheckBoxArray;
    ArrayList TextBoxValue;
    SendMail sm=new SendMail();
    SqlTransaction Tran;
    String script;

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
    //            sql = "Select Courier_Service from jct_Courier_request where Serial_no='" + lblSerialNo.Text + "' and Cost_Center='"+ ddlDepartment.SelectedItem.Value +"' ";
    //            ddlCourierService.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //            sql = "SELECT Courier_Type FROM jct_Courier_request WHERE Serial_no='" + lblSerialNo.Text + "' and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
    //            ddlCourierType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //            sql = "Select Delivery_Type from jct_Courier_request where Serial_no='" + lblSerialNo.Text + "'  and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
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
    //        sql = "Select Courier_Service from jct_Courier_request where Serial_no='" + lblSerialNo.Text + "' and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
    //        ddlCourierService.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //        sql = "SELECT Courier_Type FROM jct_Courier_request WHERE Serial_no='" + lblSerialNo.Text + "' and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
    //        ddlCourierType.SelectedItem.Text = obj1.FetchValue(sql).ToString();
    //        sql = "Select Delivery_Type from jct_Courier_request where Serial_no='" + lblSerialNo.Text + "'  and Cost_Center='" + ddlDepartment.SelectedItem.Value + "' ";
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
                ddlCourierService.SelectedIndex = ddlCourierService.Items.IndexOf(ddlCourierService.Items.FindByText(obj1.FetchValue(sql).ToString()));
                sql = "SELECT Courier_Type FROM jct_courier_request WHERE Serial_no='" + lblSerialNo.Text + "' and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlCourierType.SelectedIndex = ddlCourierType.Items.IndexOf(ddlCourierType.Items.FindByText(obj1.FetchValue(sql).ToString()));
                sql = "Select Delivery_Type from jct_courier_request where Serial_no='" + lblSerialNo.Text + "'  and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlDeliveryType.SelectedIndex = ddlDeliveryType.Items.IndexOf(ddlDeliveryType.Items.FindByText(obj1.FetchValue(sql).ToString()));
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
        else if (ddlSelectType.SelectedItem.Text == "Authorized")
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSerialNo = (Label)e.Row.Cells[1].FindControl("lblSerial");
                DropDownList ddlCourierType = (DropDownList)e.Row.Cells[7].FindControl("ddlCourierType");
                DropDownList ddlCourierService = (DropDownList)e.Row.Cells[8].FindControl("ddlCourierService");
                DropDownList ddlDeliveryType = (DropDownList)e.Row.Cells[9].FindControl("ddlDeliveryType");
                sql = "Select Authorized_Courier_Service from jct_courier_request where Serial_no='" + lblSerialNo.Text + "' and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlCourierService.SelectedIndex = ddlCourierService.Items.IndexOf(ddlCourierService.Items.FindByText(obj1.FetchValue(sql).ToString()));
                sql = "SELECT Courier_Type FROM jct_courier_request WHERE Serial_no='" + lblSerialNo.Text + "' and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlCourierType.SelectedIndex = ddlCourierType.Items.IndexOf(ddlCourierType.Items.FindByText(obj1.FetchValue(sql).ToString()));
                sql = "Select Authorized_Delivery_Type from jct_courier_request where Serial_no='" + lblSerialNo.Text + "'  and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlDeliveryType.SelectedIndex = ddlDeliveryType.Items.IndexOf(ddlDeliveryType.Items.FindByText(obj1.FetchValue(sql).ToString()));
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
                ddlCourierService.SelectedIndex = ddlCourierService.Items.IndexOf(ddlCourierService.Items.FindByText(obj1.FetchValue(sql).ToString()));
                sql = "SELECT Courier_Type FROM jct_courier_request WHERE Serial_no='" + lblSerialNo.Text + "' and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlCourierType.SelectedIndex = ddlCourierType.Items.IndexOf(ddlCourierType.Items.FindByText(obj1.FetchValue(sql).ToString()));
                sql = "Select Delivery_Type from jct_courier_request where Serial_no='" + lblSerialNo.Text + "'  and ( Dept_Code='" + ddlDepartment.SelectedItem.Value + "' or 'All'='All') ";
                ddlDeliveryType.SelectedIndex = ddlDeliveryType.Items.IndexOf(ddlDeliveryType.Items.FindByText(obj1.FetchValue(sql).ToString()));
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
        //if (ddlSelectType.SelectedItem.Text == "Pending")
        //{
        //    // CheckBox cb = (CheckBox)GridView1.FindControl("chk");
        //    for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        //    {
        //        GridViewRow grv = GridView1.Rows[i];
        //        CheckBox cb = (CheckBox)grv.FindControl("chk");
        //        Label lblSerial = (Label)grv.FindControl("lblSerial");
        //        TextBox Slip_No = (TextBox)grv.FindControl("txtSlipNo");
        //        TextBox Cost = (TextBox)grv.FindControl("txtCost");
        //        Label Send_To = (Label)grv.FindControl("lblRequestedBy");
        //        TextBox User_RefNo = (TextBox)grv.FindControl("txtUserRefNo");
        //        HtmlAnchor Serial_no = (HtmlAnchor)grv.FindControl("lnkRefNo");
        //        Label Cost_Center = (Label)grv.FindControl("lblCostCenter");
        //        DropDownList CourierType = (DropDownList)grv.FindControl("ddlCourierType");
        //        DropDownList CourierService = (DropDownList)grv.FindControl("ddlCourierService");
        //        DropDownList DeliveryType = (DropDownList)grv.FindControl("ddlDeliveryType");
        //        if (cb.Checked == true && cb.Enabled == true)
        //        {
        //            try
        //            {
        //                obj.ConOpen();
        //              //  Tran = obj.Connection().BeginTransaction();
        //                if (Cost.Text == "")
        //                {
        //                    sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Dept_Code,Authorize_Date,Authorize_By,Status,User_RefNo)values(@Serial_No,@Slip_No,@Dept_Code,@Authorize_Date,@Authorize_By,@Status,@User_RefNo) ";
        //                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //                    cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
        //                    cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text;
        //                    cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
        //                    cmd.Parameters.Add("@Authorize_Date", SqlDbType.DateTime).Value = DateTime.Today;
        //                    cmd.Parameters.Add("@Authorize_By", SqlDbType.VarChar, 30).Value = Session["EmpName"];
        //                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
        //                    cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 20).Value = User_RefNo.Text;
        //                    cmd.ExecuteNonQuery();
        //                }
        //                else
        //                {
        //                    sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Cost,Dept_Code,Authorize_Date,Authorize_By,Status,User_RefNo)values(@Serial_No,@Slip_No,@Cost,@Dept_Code,@Authorize_Date,@Authorize_By,@Status,@User_RefNo) ";
        //                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //                    cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
        //                    cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text;
        //                    cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = Cost.Text;
        //                    cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
        //                    cmd.Parameters.Add("@Authorize_Date", SqlDbType.DateTime).Value = DateTime.Today;
        //                    cmd.Parameters.Add("@Authorize_By", SqlDbType.VarChar, 30).Value = Session["EmpName"];
        //                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
        //                    cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 20).Value = User_RefNo.Text;
        //                    cmd.ExecuteNonQuery();
        //                }

        //                CourierType.Enabled = false;
        //                CourierService.Enabled = false;
        //                DeliveryType.Enabled = false;
        //                cb.Enabled = false;
        //                Cost.Enabled = false;
        //                Slip_No.Enabled = false;
        //                User_RefNo.Enabled = false;
        //                sql = "Update jct_courier_request set Status='A' , Authorized_Date='" + System.DateTime.UtcNow + "',Authorized_By='" + Session["EmpCode"] + "',Courier_Type='" + CourierType.SelectedItem.Text + "',Courier_Service='" + CourierService.SelectedItem.Text + "',Delivery_Type='" + DeliveryType.SelectedItem.Text + "' where Serial_no='" + lblSerial.Text + "'";// Serial_no.InnerText.Trim() + "'";
        //               // SqlCommand cmd1 = new SqlCommand(sql, obj.Connection(), Tran);
        //                //cmd1.ExecuteNonQuery();
        //              //  Tran.Commit();

        //                  obj1.UpdateRecord(sql);

        //                //sql = "Select empcode from jct_empmast_base where empname='" + Send_To.Text + "'";
        //                sql = "Select isnull(empcode,'') from jct_courier_request where Serial_No='" + lblSerial.Text + "'";
        //                string SendMailTo = obj1.FetchValue(sql).ToString();
        //                sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = '" + SendMailTo + "' and company_code ='JCT00LTD'";
        //                string SendmailTo1 = obj1.FetchValue(sql).ToString();

        //                string MailTo = "";
        //                string MailCC = "";
        //                sql = "Select isnull(MailTo,''),isnull(MailCC,'') from jct_courier_request where Serial_No='" + lblSerial.Text + "'";
        //                SqlDataReader dr = obj1.FetchReader(sql);
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        MailTo = dr[0].ToString();
        //                        MailCC = dr[1].ToString();
        //                    }
        //                }
        //                dr.Close();

        //                SendMailCourier(SendmailTo1, CourierService.SelectedItem.Text, CourierType.SelectedItem.Text, DeliveryType.SelectedItem.Text, lblSerial.Text, Slip_No.Text, Send_To.Text, MailTo, MailCC);
        //                cb.Attributes.Add("onclick", "setRowBackColor(this,'" + grv.RowState.ToString() + "');");
        //                FillGrid();

        //            }
        //            catch (Exception ex)
        //            {

        //             //   Tran.Rollback();
        //                string script = string.Format("alert('{0}');", ex.Message);
        //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

        //            }
        //            finally
        //            {
        //                obj.ConClose();
        //            }


        //        }
        //    }
        //}


        if (ddlSelectType.SelectedItem.Text == "Pending")
        {
            // CheckBox cb = (CheckBox)GridView1.FindControl("chk");
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
                TextBox DispatchDt = (TextBox)grv.FindControl("txtDispatchDt");
                if (cb.Checked == true && cb.Enabled == true)
                {
                    try
                    {
                        obj.ConOpen();
                        Tran = obj.Connection().BeginTransaction();
                        if (Cost.Text == "")
                        {
                            sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Dept_Code,Authorize_Date,Authorize_By,Status,User_RefNo,DispatchDt)values(@Serial_No,@Slip_No,@Dept_Code,@Authorize_Date,@Authorize_By,@Status,@User_RefNo,@DispatchDt) ";
                            SqlCommand cmd = new SqlCommand(sql, obj.Connection(), Tran);
                            cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
                            cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text;
                            cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
                            cmd.Parameters.Add("@Authorize_Date", SqlDbType.DateTime).Value = DateTime.Today;
                            cmd.Parameters.Add("@Authorize_By", SqlDbType.VarChar, 30).Value = Session["EmpName"];
                            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
                            cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 20).Value = User_RefNo.Text;
                            cmd.Parameters.Add("@DispatchDt", SqlDbType.VarChar, 20).Value = DispatchDt.Text;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Cost,Dept_Code,Authorize_Date,Authorize_By,Status,User_RefNo,DispatchDt)values(@Serial_No,@Slip_No,@Cost,@Dept_Code,@Authorize_Date,@Authorize_By,@Status,@User_RefNo,@DispatchDt) ";
                            SqlCommand cmd = new SqlCommand(sql, obj.Connection(), Tran);
                            cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
                            cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text;
                            cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = Cost.Text;
                            cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
                            cmd.Parameters.Add("@Authorize_Date", SqlDbType.DateTime).Value = DateTime.Today;
                            cmd.Parameters.Add("@Authorize_By", SqlDbType.VarChar, 30).Value = Session["EmpName"];
                            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
                            cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 20).Value = User_RefNo.Text;
                            cmd.Parameters.Add("@DispatchDt", SqlDbType.VarChar, 20).Value = DispatchDt.Text;
                            cmd.ExecuteNonQuery();
                        }

                        CourierType.Enabled = false;
                        CourierService.Enabled = false;
                        DeliveryType.Enabled = false;
                        cb.Enabled = false;
                        Cost.Enabled = false;
                        Slip_No.Enabled = false;
                        User_RefNo.Enabled = false;
                        sql = "Update jct_courier_request set Status='A' , Authorized_Date='" + System.DateTime.Now + "',Authorized_By='" + Session["EmpCode"] + "',Courier_Type='" + CourierType.SelectedItem.Text + "',Authorized_Courier_Service='" + CourierService.SelectedItem.Text + "',Authorized_Delivery_Type='" + DeliveryType.SelectedItem.Text + "' where Serial_no='" + lblSerial.Text + "'";// Serial_no.InnerText.Trim() + "'";
                        SqlCommand cmd1 = new SqlCommand(sql, obj.Connection(), Tran);
                        cmd1.ExecuteNonQuery();
                        Tran.Commit();
                        // obj1.UpdateRecord(sql);
                        //sql = "Select empcode from jct_empmast_base where empname='" + Send_To.Text + "'";



                    }
                    catch (Exception ex)
                    {

                        Tran.Rollback();
                        string script = string.Format(ex.Message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

                    }

                    try
                    {
                        sql = "Select isnull(empcode,'') from jct_courier_request where Serial_No='" + lblSerial.Text + "'";
                        string SendMailTo = obj1.FetchValue(sql).ToString();
                        sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = '" + SendMailTo + "' and company_code ='JCT00LTD'";
                        string SendmailTo1 = obj1.FetchValue(sql).ToString();

                        string MailTo = "";
                        string MailCC = "";
                        sql = "Select isnull(MailTo,''),isnull(MailCC,'') from jct_courier_request where Serial_No='" + lblSerial.Text + "'";
                        SqlDataReader dr = obj1.FetchReader(sql);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                MailTo = dr[0].ToString();
                                MailCC = dr[1].ToString();
                            }
                        }
                        dr.Close();

                        SendMailCourier(SendmailTo1, CourierService.SelectedItem.Text, CourierType.SelectedItem.Text, DeliveryType.SelectedItem.Text, lblSerial.Text, Slip_No.Text, Send_To.Text, MailTo, MailCC);
                        cb.Attributes.Add("onclick", "setRowBackColor(this,'" + grv.RowState.ToString() + "');");
                       
                    }
                    catch (Exception ex)
                    {
                        string script = string.Format(ex.Message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
                    }
                    finally
                    {
                        obj.ConClose();
                    }



                }
            }
            //FillGrid();
        }
        else if (ddlSelectType.SelectedItem.Text == "Authorized")
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
                TextBox DispatchDt = (TextBox)grv.FindControl("txtDispatchDt");

                if (cb.Checked == true && cb.Enabled == true)
                {
                    try
                    {
                        sql = "JCT_COURIER_CHECK_AUTHORIZED_REQUESTS";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtFromDate.Text;
                        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtToDate.Text;
                        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 20).Value = CourierService.SelectedItem.Text;
                        cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = Cost.Text;
                        cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
                        cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 20).Value = Slip_No.Text;
                        cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 100).Value = User_RefNo.Text;
                        cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 20).Value = DeliveryType.SelectedItem.Text;
                        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
                        cmd.Parameters.Add("@DispatchDt", SqlDbType.VarChar, 20).Value = DispatchDt.Text;
                        cmd.ExecuteNonQuery();
                        cb.Attributes.Add("onclick", "setRowBackColor(this,'" + grv.RowState.ToString() + "');");
                        CourierType.Enabled = false;
                        CourierService.Enabled = false;
                        DeliveryType.Enabled = false;
                        cb.Enabled = false;
                        Cost.Enabled = false;
                        Slip_No.Enabled = false;
                        User_RefNo.Enabled = false;

                    }
                    catch (Exception ex)
                    {

                        string script = string.Format(ex.Message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

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

    //protected void SendMailCourier(String SendTo, String Courier_Service, String Courier_Type, String Delivery_Type, String Serial_No, String SlipNo, String RequestBy, string MailTo, string MailCC)
    //{
    //    #region SendMail

    //    string sender_email;
       
    //    // sm.SendMail("jctadmin@jctltd.com", "", "Courier Request- " + txtRefNo.Text + " ", "Courier Request has been generated with reference ID - '"+ txtRefNo.Text +"' on "+System.DateTime.Today+". It will be visible in the Pending List of Couriers in the Courier tracking system.");
    //    sql = "Select isnull(party_name,'') as party_name from jct_courier_request   where serial_no='" + Serial_No + "'";
    //    String partyname = obj1.FetchValue(sql).ToString();
    //    sql = "SELECT isnull(WebSite,'') as Website FROM dbo.jct_Courier_Service_Master where status='A' and Courier_Service=(Select Courier_Service from jct_courier_request  where serial_no='" + Serial_No + "') ";
    //    String WebSite = "";
    //    SqlDataReader dr1 = obj1.FetchReader(sql);
    //    if (dr1.HasRows)
    //    {
    //        while (dr1.Read())
    //        {
    //            WebSite = dr1[0].ToString();

    //        }
    //    }
    //    dr1.Close();
    //    string empcode = Session["EmpCode"].ToString();
    //    sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = @empcode and company_code ='JCT00LTD'";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = empcode;
    //    SqlDataReader dr;
    //    dr = cmd.ExecuteReader();
    //    if (dr.HasRows)
    //    {
    //        while (dr.Read())
    //        {
    //            //sql = "Select party_name from jct_courier_request where serial_no='"+ Serial_No +"'";
    //            //string partyname = obj1.FetchValue(sql).ToString();
    //            sender_email = dr[0].ToString();
    //            //sql = "SELECT WebSite FROM dbo.jct_Courier_Service_Master where status='A' and Courier_Service=(Select Courier_Service from jct_courier_request   where serial_no='" + Serial_No + "') ";
    //            //String WebSite = obj1.FetchValue(sql).ToString(); 
    //            // sm.SendMail(SendTo, sender_email, "Courier Send - " + Serial_No + " ", "Courier Request has been Authroized and sent through Courier Service :'"+ Courier_Service +"' , Delivery : '"+ Delivery_Type +"', Courier_Type='"+ Courier_Type +"' . You can track you courier at '"+ Courier_Service +"' website using Courier Slip No. : '"+ SlipNo +"'. ");
    //            String msg = "<html><body><Table><tr><td>Hello " + RequestBy + ",</td></tr><tr><td>Your courier has been sent.</td></tr><tr><td>Details of the your courier are :</td></tr><tr><td><b> Courier ID : " + Serial_No + " </b></td></tr><tr><td>Party Name : " + partyname + "</td></tr><tr><td> Courier Service : " + Courier_Service + "</td></tr><tr><td>Courier Type : " + Courier_Type + "</td></tr> <tr><td> Delivery Type : " + Delivery_Type + "</td></tr><tr><td>Tracking ID :  <a href=" + WebSite + ">" + SlipNo + "</a></td></tr><tr><td> Dispatch Date : " + txtToDate.Text + " </tr></td> </br><tr><td></td></tr> <tr><td>Thanks..!!</td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";
    //            sm.SendMail(SendTo, "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
    //            //sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
    //            if (MailTo != "")
    //            {
    //                sm.SendMail(MailTo, "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
    //              //  sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
    //            }
    //            if (MailCC != "")
    //            {
    //                string[] values = MailCC.Split(',').Select(sValue => sValue.Trim()).ToArray();
    //                foreach (string cc in values)
    //                {
    //                    sm.SendMail(cc, "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
    //                   // sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
    //                }

    //            }
    //           // sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Courier Sent - " + Serial_No + " ", msg);
    //        }
    //           // sm.SendMail(SendTo, sender_email, "Courier Send ", "Courier Request has been Authroized and sent through Courier Service ");
           
            
    //    }
    //    else
    //    { }
    //    dr.Close();
    //    #endregion
    //}

    private void SendMailCourier(String SendTo, String Courier_Service, String Courier_Type, String Delivery_Type, String Serial_No, String SlipNo, String RequestBy, string MailTo, string MailCC)
    {


        string from, to, bcc, cc, subject, body;

        string RequestBy_Email = "", partyname = "", AccountNo = "", BookingNo = "", Subject = "", Remarks = "", Address="";


        //sql = "Select isnull(party_name,'') as party_name , ISnull(AccountNo,'') as AccountNo,isnull(BookingNo,'') as BookingNo,SUBJECT,Remarks from jct_courier_request   where serial_no='" + Serial_No + "'";
        sql = "Select isnull(party_name,'') as party_name,Address1 +', '+Address2+', '+Address3+', '+ City +', '+State +', '+Country AS Address , ISnull(AccountNo,'') as AccountNo,isnull(BookingNo,'') as BookingNo,SUBJECT,Remarks from jct_courier_request  where serial_no='" + Serial_No + "'";
        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                partyname = dr["party_name"].ToString();
                AccountNo = dr["AccountNo"].ToString();
                BookingNo = dr["BookingNo"].ToString();
                Address = dr["Address"].ToString();
                if (!string.IsNullOrEmpty(dr["Subject"].ToString()))
                {
                    Subject = dr["Subject"].ToString();
                }
                else
                {
                    Subject = "No Subject Mentioned";
                }
                if (!string.IsNullOrEmpty(dr["Remarks"].ToString()))
                {
                    Remarks = dr["Remarks"].ToString();
                }
                else
                {
                    Remarks = "No Remarks Mentioned";

                }

            }
        }
        dr.Close();


      

        //sql = "Select isnull(party_name,'') as party_name , ISnull(AccountNo,'') as AccountNo,isnull(BookingNo,'') as BookingNo,SUBJECT,Remarks from jct_courier_request   where serial_no='" + Serial_No + "'";
        //SqlDataReader dr = obj1.FetchReader(sql);
        //if (dr.HasRows)
        //{
        //    while (dr.Read())
        //    {
        //        partyname = dr[0].ToString();
        //        AccountNo = dr[1].ToString();
        //        BookingNo = dr[2].ToString();
        //        if (!string.IsNullOrEmpty(dr[3].ToString()))
        //        {
        //            Subject = dr[3].ToString();
        //        }
        //        else
        //        {
        //            Subject = "No Subject Mentioned";
        //        }
        //        if (!string.IsNullOrEmpty(dr[4].ToString()))
        //        {
        //            Remarks = dr[4].ToString();
        //        }
        //        else
        //        {
        //            Remarks = "No Remarks Mentioned";

        //        }

        //    }
        //}
        //dr.Close();
        //String partyname = obj1.FetchValue(sql).ToString();



        sql = "SELECT isnull(Replace(WebSite,'POD','"+ SlipNo +"'),'') as Website FROM dbo.jct_Courier_Service_Master where status='A' and Courier_Service=(Select Courier_Service from jct_courier_request  where serial_no='" + Serial_No + "') ";
        String WebSite = "";
        SqlDataReader dr1 = obj1.FetchReader(sql);
        if (dr1.HasRows)
        {
            while (dr1.Read())
            {
                WebSite = dr1[0].ToString();

            }
        }
        dr1.Close();

        sql = "SELECT isnull(Convert(varchar,a.DispatchDt,103),Convert(varchar,b.Request_Date,103)) as DispatchDt FROM dbo.jct_courier_request_authorized a inner join jct_courier_Request b on a.serial_no=b.serial_no WHERE a.Serial_No='" + Serial_No + "'";
        string DispatchDt = obj1.FetchValue(sql).ToString();

        string empcode = Session["EmpCode"].ToString();
        sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = @empcode and company_code ='JCT00LTD'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = empcode;
        //SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                RequestBy_Email = dr[0].ToString();
            }
        }
        else
        {
            RequestBy_Email = "it.helpDesk@jctltd.com";
        }
        dr.Close();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");


       

        // sb.Append("<head>");
        sb.AppendLine("Hello " + RequestBy + ",<br/><br/>");
        sb.AppendLine("Your courier has been dispatched from JCT .<br/><br/>");
        sb.AppendLine("Details of the your courier are :<br/><br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> Courier ID </th> <th> Receiver Name </th><th> Receiver Address </th> <th> Courier Service </th> <th> Material Sent </th> <th> Delivery Type </th> <th> Tracking ID</th>  <th> Dispatch Date</th>  <th> Booking No</th><th>Account No </th> </tr>");
        //sb.AppendLine("<tr> <td>  " + Serial_No + " </td> <td>  " + partyname + " </td>  <td>  " + Address + " </td> <td> " + Courier_Service + "</td>  <td> " + Courier_Type + "</td>  <td> " + Delivery_Type + "</td>  <td> <a href=" + WebSite + ">" + SlipNo + "</a> </td><td>" + txtToDate.Text + "</td> <td>" + BookingNo + "</td> <td>" + AccountNo + "</td>  </tr> ");
        sb.AppendLine("<tr> <td>  " + Serial_No + " </td> <td>  " + partyname + " </td>  <td>  " + Address + " </td> <td> " + Courier_Service + "</td>  <td> " + Courier_Type + "</td>  <td> " + Delivery_Type + "</td>  <td> <a href=" + WebSite  + ">" + SlipNo + "</a> </td><td>" + DispatchDt + "</td> <td>" + BookingNo + "</td> <td>" + AccountNo + "</td>  </tr> ");
        sb.AppendLine("</table>");
        sb.AppendLine("<br/><br/>");
        sb.AppendLine(" Subject : " + Subject + "<br/><br/>");
        sb.AppendLine(" Remarks : " + Remarks + "<br/>");
        sb.AppendLine("<br />");
        sb.AppendLine("This is a system generated mail, please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com";
        if (!string.IsNullOrEmpty(MailTo))
        {
            to = SendTo + ',' + MailTo;
        }
        else
        {
            to = SendTo;
        }

        //to = "jatindutta@jctltd.com";
        //MailCC = MailCC + ",mukulb@jctltd.com";
        bcc = "mukulb@jctltd.com";
        //bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com";
        subject = "Courier Dispatched - " + Serial_No;
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
        //mail.Bcc

        if (!string.IsNullOrEmpty(MailCC))
        {
            cc = MailCC;
            if (!string.IsNullOrEmpty(cc))
            {
                if (cc.Contains(","))
                {
                    string[] ccs = cc.Split(',');
                    for (int i = 0; i < ccs.Length; i++)
                    {
                        mail.CC.Add(new MailAddress(ccs[i]));
                    }
                }
                else
                {
                    mail.CC.Add(new MailAddress(cc));
                }
                mail.CC.Add(new MailAddress(cc));
            }
        }
        else
        {

        }


        //cc="jatindutta@jctltd.com";

        if (to.Contains(","))
        {
            string[] tos = to.Split(',');
            for (int i = 0; i < tos.Length; i++)
            {
                mail.To.Add(new MailAddress(tos[i]));
            }
        }
        else
        {
            mail.To.Add(new MailAddress(to));
        }

        if (!string.IsNullOrEmpty(bcc))
        {
            if (bcc.Contains(","))
            {
                string[] bccs = bcc.Split(',');
                for (int i = 0; i < bccs.Length; i++)
                {
                    mail.Bcc.Add(new MailAddress(bccs[i]));
                }
            }
            else
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
        }


        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");

        //SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail);
        //return mail;
    }

    protected void ddlSelectType_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillGrid();

       // GridView1_RowDataBound(sender,null);
   
    }

    protected void ddlCourierType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtCourierID.Text == "")
        {
            FillGrid();
        }
        else if (txtCourierID.Text != "")
        {

            sql = "jct_courier_fetch_request_With_CourierID";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DeliveryType", SqlDbType.VarChar, 20).Value = "All";
            cmd.Parameters.AddWithValue("@SelectType", ddlSelectType.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text);
            cmd.Parameters.AddWithValue("@ToDate", txtToDate.Text);
            cmd.Parameters.AddWithValue("@Dept", "All");
            if (!string.IsNullOrEmpty(txtCourierID.Text))
            {
                cmd.Parameters.AddWithValue("@SerialNo", txtCourierID.Text);
            }
            cmd.Parameters.AddWithValue("@CourierService", ddlCourierService.SelectedItem.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        
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

        if (ddlCourierService.SelectedItem.Text == "")
        {
            if (txtCourierID.Text == "")
            {
                FillGrid();
            }
            else
            {
                sql = "jct_courier_fetch_request_With_CourierID";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DeliveryType", SqlDbType.VarChar, 20).Value = "All";
                cmd.Parameters.AddWithValue("@SelectType", ddlSelectType.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text);
                cmd.Parameters.AddWithValue("@ToDate", txtToDate.Text);
                cmd.Parameters.AddWithValue("@Dept", "All");
                if (!string.IsNullOrEmpty(txtCourierID.Text))
                {
                    cmd.Parameters.AddWithValue("@SerialNo", txtCourierID.Text);
                }
                cmd.Parameters.AddWithValue("@CourierService", ddlCourierService.SelectedItem.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        else
        {
            sql = "jct_courier_fetch_request_With_CourierID";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DeliveryType", SqlDbType.VarChar, 20).Value = "All";
            cmd.Parameters.AddWithValue("@SelectType", ddlSelectType.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text);
            cmd.Parameters.AddWithValue("@ToDate", txtToDate.Text);
            cmd.Parameters.AddWithValue("@Dept", "All");
            if (!string.IsNullOrEmpty(txtCourierID.Text))
            {
                cmd.Parameters.AddWithValue("@SerialNo", txtCourierID.Text);
            }
            cmd.Parameters.AddWithValue("@CourierService", ddlCourierService.SelectedItem.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }

    protected void lnkAddCost_Click(object sender, EventArgs e)
    {
        sql = "exec jct_courier_fetch_Authorized_request '" + ddlCourierType.SelectedItem.Text + "','" + txtFromDate.Text + "','" + txtToDate.Text + "','" + ddlDepartment.SelectedItem.Value + "'";
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
                    Tran = obj.Connection().BeginTransaction();
                    sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Dept_Code,Cancel_Date,Cancel_By,Status,User_RefNo)values(@Serial_No,@Slip_No,@Dept_Code,@Cancel_Date,@Cancel_By,@Status,@User_RefNo) ";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection(),Tran);
                    cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
                    cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text;
                    cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
                    cmd.Parameters.Add("@Cancel_Date", SqlDbType.DateTime).Value = DateTime.Today;
                    cmd.Parameters.Add("@Cancel_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
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
                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection(), Tran);
                    cmd1.ExecuteNonQuery();
                    Tran.Commit();
                    // obj1.UpdateRecord(sql);
                    cb.Attributes.Add("onclick", "setRowBackColor(this,'" + grv.RowState.ToString() + "');");
                    ShowAlertMsg("Courier Cancelled..!!");
                }
            }
        }
        catch (Exception ex)
        {
            Tran.Rollback();
            string script = string.Format("alert('{0}');", ex.Message);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
        }

    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton Save = (LinkButton)sender;
            GridViewRow grv = (GridViewRow)Save.Parent.Parent.Parent.Parent;
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
            sql = "Insert into jct_courier_request_authorized(Serial_No,Slip_No,Cost,Dept_Code,Authorize_Date,Authorize_By,Status,User_RefNo)values(@Serial_No,@Slip_No,@Cost,@Dept_Code,@Authorize_Date,@Authorize_By,@Status,@User_RefNo) ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = lblSerial.Text;
            cmd.Parameters.Add("@Slip_No", SqlDbType.VarChar, 30).Value = Slip_No.Text;
            cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = Cost.Text;
            cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 10).Value = Cost_Center.Text;
            cmd.Parameters.Add("@Authorize_Date", SqlDbType.DateTime).Value = DateTime.Today;
            cmd.Parameters.Add("@Authorize_By", SqlDbType.VarChar, 30).Value = Session["EmpName"];
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
            cmd.Parameters.Add("@User_RefNo", SqlDbType.VarChar, 20).Value = User_RefNo.Text;
            cmd.ExecuteNonQuery();

            sql = "Update jct_courier_request_test set Status='A' , Authorized_Date='" + System.DateTime.UtcNow + "',Authorized_By='" + Session["EmpCode"] + "',Courier_Type='" + CourierType.SelectedItem.Text + "',Courier_Service='" + CourierService.SelectedItem.Text + "',Delivery_Type='" + DeliveryType.SelectedItem.Text + "' where Serial_no='" + lblSerial.Text + "'";// Serial_no.InnerText.Trim() + "'";
            obj1.UpdateRecord(sql);
            sql = "Select isnull(empcode,'') from jct_courier_request_test where Serial_No='" + lblSerial.Text + "'";
            string SendMailTo = obj1.FetchValue(sql).ToString();
            sql = "Select isnull(E_mailID,'') from mistel where empcode = '" + SendMailTo + "' ";
            string SendmailTo1 = obj1.FetchValue(sql).ToString();
         //   SendMailCourier(SendmailTo1, CourierService.SelectedItem.Text, CourierType.SelectedItem.Text, DeliveryType.SelectedItem.Text, lblSerial.Text, Slip_No.Text, Send_To.Text);


            string script = string.Format("alert('{0}');", "Record Saved.");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);

            FillGrid();
        }
        catch (Exception ex)
        {
            string script = string.Format("alert('{0}');", "Error Occured.");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key_name", script, true);
        }

    }

  
}