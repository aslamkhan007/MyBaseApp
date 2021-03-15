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
            cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.ExecuteNonQuery();
            lnkUpdate.Text = "Update";
            obj1.Alert("Record Updated Successfully...!!");
        }
    }
    protected void lnkSearchRecieptNo_Click(object sender, EventArgs e)
    {
        sql = "Select Courier_Service,Dept,Reciept_No,Amount from jct_courier_ReciptNo_Entry where Status='A' and Reciept_No='"+ txtSearchRecieptNo.Text +"'";
        obj1.FillGrid(sql, ref GridView1);
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCourier.SelectedIndex = ddlCourier.Items.IndexOf(((ListItem)ddlCourier.Items.FindByText(GridView2.SelectedRow.Cells[1].Text)));
       // ddlCourier.SelectedItem.Text  = GridView1.SelectedRow.Cells[1].Text;
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
        cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = txtAmount.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "A";
        cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
        cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmd.ExecuteNonQuery();
        obj1.Alert("Record Inserted Successfully...!!");
        }
        catch (Exception ex)
        {
            obj1.Alert("Duplicate Record Cannot be added.");
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
        //ddlCourier.SelectedItem.Text = GridView2.SelectedRow.Cells[1].Text;
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
}