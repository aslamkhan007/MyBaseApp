using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class Courier_Tracking_System_Courier_Type_Master : System.Web.UI.Page
{
    string sql;
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    int _startRowIndex = 0;
    int _pageSize = 20;
    int _thisPage = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and active='Y' ";
        string empname = obj1.FetchValue(sql).ToString();
        sql = "Insert into jct_courier_Type_Master(UserCode,UserName,CourierType,DESCRIPTION,STATUS,EntryDate,EffecFrom,EffecTo,LongDesc) values(@UserCode,@UserName,@CourierType,@Description,@Status,@EntryDate,@EffecFrom,@Effecto,@LongDesc)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = empname;
        cmd.Parameters.Add("@CourierType", SqlDbType.VarChar, 100).Value = txtCourierType.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = txtDescription.Text;
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
        cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
        cmd.Parameters.Add("@EffecFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
        cmd.Parameters.Add("@EffecTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
        cmd.Parameters.Add("@LongDesc", SqlDbType.VarChar, 200).Value = txtLongDescription.Text;
        cmd.ExecuteNonQuery();
        FMsg.CssClass = "errormsg";
        FMsg.Message = "Record Added Successfully..!!";
        FMsg.Display();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkEdit.Text = "Update";
        string Sr_no = GridView1.SelectedRow.Cells[1].Text;
        int Sr_no1 = int.Parse(Sr_no);
        hd1.Value = Sr_no;
        sql = "Select CourierType,Description,Isnull(LongDesc,''),Isnull(EffecFrom,''),Isnull(EffecTo,''),Isnull(remarks,'') from jct_courier_Type_Master where status='A' and Sr_no ="+ Sr_no1 +"";
        SqlDataReader dr1 = obj1.FetchReader(sql);
        if (dr1.HasRows)
        {
            while (dr1.Read())
            {
                txtCourierType.Text = dr1[0].ToString();
                txtDescription.Text = dr1[1].ToString();
                txtLongDescription.Text = dr1[2].ToString();
                txtEffecFrom.Text = dr1[3].ToString();
                txtEffecTo.Text = dr1[4].ToString();
                txtRemarks.Text = dr1[5].ToString();
            }
        
        }
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
          string Sr_no = GridView1.SelectedRow.Cells[1].Text;
        int Sr_no1 = int.Parse(Sr_no);
        if (lnkEdit.Text == "Update")
        {
            sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
            string empname = obj1.FetchValue(sql).ToString();
            sql = "Update jct_courier_Type_Master Set Status='D' ,DeletedDate=getdate(),Deleted_UserCode='"+ Session["EmpCode"] +"' where Sr_no="+ Sr_no1 +"  ";
            obj1.UpdateRecord(sql);
            sql = "Insert into jct_courier_Type_Master(UserCode,UserName,CourierType,DESCRIPTION,STATUS,EntryDate,EffecFrom,EffecTo,LongDesc) values(@UserCode,@UserName,@CourierType,@Description,@Status,@EntryDate,@EffecFrom,@Effecto,@LongDesc)";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = empname;
            cmd.Parameters.Add("@CourierType", SqlDbType.VarChar, 100).Value = txtCourierType.Text;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = txtDescription.Text;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
            cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
            cmd.Parameters.Add("@EffecFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
            cmd.Parameters.Add("@EffecTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
            cmd.Parameters.Add("@LongDesc", SqlDbType.VarChar, 200).Value = txtLongDescription.Text;
            cmd.ExecuteNonQuery();
            FMsg.CssClass = "errormsg";
            FMsg.Message = "Record Updated Successfully..!!";
            FMsg.Display();
        
        }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        sql = "Update jct_courier_Type_Master Set Status='D' ,DeletedDate=getdate(),Deleted_UserCode='" + Session["EmpCode"] + "' where Sr_no=" + hd1.Value + "  ";
        obj1.UpdateRecord(sql);
        FMsg.CssClass = "errormsg";
        FMsg.Message = "Record Updated Successfully..!!";
        FMsg.Display();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }
}