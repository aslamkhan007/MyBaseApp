using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_Courier_Delivery_Type : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        string sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
        string empname = obj1.FetchValue(sql).ToString();

        sql = "Insert into jct_courier_Delivery_Type(UserCode,UserName,DeliveryType,DESCRIPTION,Remarks,STATUS,EntryDate,EffecFrom,EffecTo,LongDesc ) values(@UserCode,@UserName,@DeliveryType,@Description,@Remarks,@Status,@EntryDate,@EffecFrom,@EffecTo,@LongDesc)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = empname;
        cmd.Parameters.Add("@DeliveryType", SqlDbType.VarChar, 100).Value = txtDeliveryType.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100).Value = txtShortDescription.Text;
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
        cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
        cmd.Parameters.Add("@EffecFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
        cmd.Parameters.Add("@EffecTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
        cmd.Parameters.Add("@LongDesc", SqlDbType.VarChar, 500).Value = txtLongDescription.Text;
        cmd.ExecuteNonQuery();
        ShowAlertMsg("Record Inserted Successfuly.");
    }
    public void ShowAlertMsg(string error1)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            // error1 = error1.Replace("'", "'")
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error1 + "');", true);
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Sr_no = GridView1.SelectedRow.Cells[1].Text.ToString()  ;
        lnkEdit.Text = "Update";
        //string sql = "Update jct_courier_Delivery_Type set status='D' , DeletedDate=getdate(),Deleted_UserCode='" + Session["EmpCode"] + "' where Status='A' and Sr_no='"+ Sr_no +"' ";
        // obj1.UpdateRecord(sql);
        string sql = "Select DeliveryType, Description,Isnull(LongDesc,'') as [LongDesc], Isnull(EffecFrom,'') as [EffecFrom],Isnull(EffecTo,'') as [EffecTo],Isnull(Remarks,'') as [ Remarks] from jct_courier_Delivery_Type where status='A' and Sr_no='" + Sr_no + "' ";
        SqlDataReader dr1 = obj1.FetchReader(sql);
        if (dr1.HasRows)
        {
            while (dr1.Read())
            {
                txtDeliveryType.Text = dr1[0].ToString();
                txtShortDescription.Text = dr1[1].ToString();
                txtLongDescription.Text = dr1[2].ToString();
                txtEffecFrom.Text = dr1[3].ToString();
                txtEffecTo.Text = dr1[4].ToString();
                txtRemarks.Text = dr1[5].ToString();

            }
        }

    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        if (lnkEdit.Text == "Update")
        {
            string Sr_no = GridView1.SelectedRow.Cells[1].Text;
            int Sr_no1 = int.Parse(Sr_no);
            if (lnkEdit.Text == "Update")
            {
                string sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
                string empname = obj1.FetchValue(sql).ToString();
                sql = "Update jct_courier_Type_Master Set Status='D' ,DeletedDate=getdate(),Deleted_UserCode='" + Session["EmpCode"] + "' where Sr_no=" + Sr_no1 + "  ";
                obj1.UpdateRecord(sql);

                sql = "Insert into jct_courier_Delivery_Type(UserCode,UserName,DeliveryType,DESCRIPTION,Remarks,STATUS,EntryDate,EffecFrom,EffecTo,LongDesc ) values(@UserCode,@UserName,@DeliveryType,@Description,@Remarks,@Status,@EntryDate,@EffecFrom,@EffecTo,@LongDesc)";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = empname;
                cmd.Parameters.Add("@DeliveryType", SqlDbType.VarChar, 100).Value = txtDeliveryType.Text;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100).Value = txtShortDescription.Text;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
                cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
                cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@EffecFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
                cmd.Parameters.Add("@EffecTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
                cmd.Parameters.Add("@LongDesc", SqlDbType.VarChar, 500).Value = txtLongDescription.Text;
                cmd.ExecuteNonQuery();
                ShowAlertMsg("Record Updated Successfuly.");
                lnkEdit.Text = "Edit";
            }
        }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        string Sr_no = GridView1.SelectedRow.Cells[1].Text;
        int Sr_no1 = int.Parse(Sr_no);
        string sql = "Update jct_courier_Delivery_Type Set Status='D' ,DeletedDate=getdate(),Deleted_UserCode='" + Session["EmpCode"] + "' where Sr_no=" + Sr_no1 + "  ";
        obj1.UpdateRecord(sql);
        ShowAlertMsg("Record Deleted");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }
}