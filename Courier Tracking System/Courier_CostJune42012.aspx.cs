using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Courier_Tracking_System_Courier_Cost : System.Web.UI.Page
{
    string sql;
    int sum = 0;
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == "")
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            sql = "Select '  All  ' as [DeptCode],'  All  ' as [DeptName] Union Select DeptCode,DeptName from deptmast order by Deptcode";
            obj1.FillList(ddlDepartment, sql);
            sql = "Select '  All  ' as [Courier_Service],'  All  ' as [Courier_Service] Union Select Courier_Service,Courier_Service from jct_courier_Service_Master where status='A' order by Courier_Service";
            obj1.FillList(ddlCourierService, sql);
            sql = "Select '  All  ' as [CourierType],'  All  ' as [CourierType] Union Select CourierType,CourierType from jct_courier_type_master where status='A' order by CourierType";
            obj1.FillList(ddlCourierType, sql);
           
        }

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        sql = " Exec jct_courier_TotalCost '"+ txtDateFrom.Text +"','"+ txtDateTo.Text +"','"+ ddlDepartment.SelectedItem.Value  +"','"+ ddlCourierService.SelectedItem.Value +"','"+ ddlCourierType.SelectedItem.Value +"'";
        obj1.FillGrid(sql,ref GridView1);
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            sum = sum + int.Parse(e.Row.Cells[2].Text);
        }
        
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total (in Rupees)";
            e.Row.Cells[2].Text = sum.ToString();
        }
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Courier_Cost.aspx");
    }
}