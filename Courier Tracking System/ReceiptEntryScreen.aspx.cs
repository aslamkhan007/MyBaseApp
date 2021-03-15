using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_ReceiptEntryScreen : System.Web.UI.Page
{
    private String sql;
    Functions obj1 = new Functions();
    Connection obj = new Connection();
     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate_CalendarExtender.SelectedDate =DateTime.Now.Date;
             //if (lnkUpdate.Text == "Update")
            //{
            //    lnkUpdate.Enabled = false;
            //}
        }
    }
   
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        if (lnkUpdate.Text == "Update")
        //{
        //    lnkUpdate.Text = "Modify";
        //}
        //else
        {
            sql = "Delete from  jct_courier_ReciptNo_Entry  where Reciept_No ='"+ txtRecieptNo.Text +"' and status='A'";
            obj1.DeleteRecord(sql);
            sql = "Insert into jct_courier_ReciptNo_Entry(Reciept_No,Dept,Amount,Status,EntryBy,EntryDate,Courier_Service)values(@Reciept_No,@Dept,@Amount,@Status,@EntryBy,@EntryDate,@Courier_Service)";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@Reciept_No", SqlDbType.VarChar, 20).Value = txtRecieptNo.Text;
            cmd.Parameters.Add("@Dept", SqlDbType.VarChar, 20).Value = ddlDept.SelectedItem.Text;
            cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 20).Value = ddlCourier.SelectedItem.Text;
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = txtAmount.Text;
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
            cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = txtDate.Text;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
            cmd.ExecuteNonQuery();
            lnkUpdate.Text = "Update";
          //  obj1.Alert("Record Updated Successfully...!!");
            FMsg.CssClass = "errormsg";
            FMsg.Message="Record Updated Successfully...!!";
            FMsg.Display();
        }
    }
    protected void lnkSearchRecieptNo_Click(object sender, EventArgs e)
    {
        sql = "Select Courier_Service,Dept,Reciept_No,Amount from jct_courier_ReciptNo_Entry where Status='A' and Reciept_No = '"+ txtSearchRecieptNo.Text +"'";
        obj1.FillGrid(sql, ref GridView1);
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCourier.SelectedIndex = ddlCourier.Items.IndexOf(((ListItem)ddlCourier.Items.FindByText(GridView2.SelectedRow.Cells[1].Text)));
        ddlDept.SelectedIndex = ddlDept.Items.IndexOf(((ListItem)ddlDept.Items.FindByText(GridView2.SelectedRow.Cells[2].Text)));
        txtRecieptNo.Text = GridView1.SelectedRow.Cells[3].Text;
        txtAmount.Text = GridView1.SelectedRow.Cells[4].Text;
        Panel1.Visible = false;
        lnkUpdate.Enabled = true;
        ModalPopupExtender1.Hide();
    }
    protected void lnkSave_Click1(object sender, EventArgs e)
    {
        try
        { 
         sql = "Insert into jct_courier_ReciptNo_Entry(Reciept_No,Dept,Amount,Status,EntryBy,EntryDate,Courier_Service)values(@Reciept_No,@Dept,@Amount,@Status,@EntryBy,@EntryDate,@Courier_Service)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@Reciept_No", SqlDbType.VarChar, 20).Value = txtRecieptNo.Text;
        cmd.Parameters.Add("@Dept", SqlDbType.VarChar, 20).Value = ddlDept.SelectedItem.Text;
        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 20).Value = ddlCourier.SelectedItem.Text;
        cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = txtAmount.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
        cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 20).Value =Session["EmpCode"];
        cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = txtDate.Text;
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
        cmd.ExecuteNonQuery();
        FMsg.CssClass = "errormsg";
        FMsg.Message = "Record Inserted Successfully...!!";
        FMsg.Display();
        }
        catch (Exception ex)
        {
            FMsg.CssClass = "errormsg";
            FMsg.Message = "Duplicate record cannot be inserted..!!";
            FMsg.Display();
        }
       
    }
    protected void lnkShow_Click(object sender, EventArgs e)
    {
        sql = "Select Courier_Service,Dept,Reciept_No,Amount,CONVERT(VARCHAR,Entrydate,106) as [Entry Date] from jct_courier_ReciptNo_Entry where Status='A' and CONVERT(VARCHAR,EntryDate,101) ='" + txtDate.Text + "'  order by Reciept_No Desc";
        obj1.FillGrid(sql, ref GridView2);
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCourier.SelectedIndex = ddlCourier.Items.IndexOf(((ListItem)ddlCourier.Items.FindByText(GridView2.SelectedRow.Cells[1].Text)));
        ddlDept.SelectedIndex = ddlDept.Items.IndexOf(((ListItem)ddlDept.Items.FindByText(GridView2.SelectedRow.Cells[2].Text)));
        txtRecieptNo.Text = GridView2.SelectedRow.Cells[3].Text;
        txtAmount.Text = GridView2.SelectedRow.Cells[4].Text;
        lnkUpdate.Enabled = true;
    }


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        sql = "Select Courier_Service,Dept,Reciept_No,Amount,CONVERT(VARCHAR,Entrydate,106) as [Entry Date] from jct_courier_ReciptNo_Entry where Status='A'  and CONVERT(VARCHAR,EntryDate,101) ='" + txtDate.Text + "' order by Reciept_No Desc";
        obj1.FillGrid(sql, ref GridView2);

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        if (txtRecieptNo.Text != "")
        {
            sql = "update jct_courier_ReciptNo_Entry set Status='D' where status='A' and reciept_no='"+ txtRecieptNo.Text +"'";
            if (obj1.UpdateRecord(sql))
            {
                FMsg.CssClass = "errormsg";
                FMsg.Message = "Record Deleted Successfully";
                FMsg.Display();
                txtRecieptNo.Text = "";
                txtAmount.Text = "";
                
            }
            else
            {
                FMsg.CssClass = "errormsg";
                FMsg.Message = "Record Can't be deleted. Please Contact Mr.Jatin(IT) at 4226.";
                FMsg.Display();
            }

        }
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        sql = "select request_date,serial_no from jct_courier_request where status='A' and serial_no like '%"+ txtCourierID.Text +"%'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtRequestDate.Text = dr["request_date"].ToString();
                txtCourierID.Text = dr["serial_no"].ToString();
            }
        }
        dr.Close();
    }

    protected void imgSaveDate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            sql = "JCT_COURIER_REQUEST_CHANGE_REQUEST_DATE";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@Courier_ID", SqlDbType.VarChar, 30).Value = txtCourierID.Text;
            if (txtChangeRequestDate.Text != string.Empty)
            {
                cmd.Parameters.Add("@New_Request_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(txtChangeRequestDate.Text);
            }
            cmd.ExecuteNonQuery();

            FMsg.CssClass = "errormsg";
            FMsg.Message = "Record updated Successfully...!!";
            FMsg.Display();
        }
        catch (Exception ex)
        {
            FMsg.CssClass = "errormsg";
            FMsg.Message = "Record not updated.!!";
            FMsg.Display();
        }
    }
}