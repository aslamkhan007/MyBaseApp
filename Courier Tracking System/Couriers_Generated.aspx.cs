using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

public partial class Courier_Tracking_System_Couriers_Generated : System.Web.UI.Page
{
    string sql;
    float sum = 0;
    float Count = 0;
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
            sql = "Select '--All--' as [ma_center_no],'--All--' as [ma_center_sdesc] Union  SELECT ma_center_no,ma_center_sdesc  FROM miserp.COMMON.dbo.mac_cost_center";
            obj1.FillList(ddlDept, sql);
            sql = "Select '--All--' as [Courier_Service],'--All--' as [Courier_Service] Union Select Courier_Service,Courier_Service from jct_courier_Service_Master where status='A' order by Courier_Service";
            obj1.FillList(ddlCourierService, sql);


        }

    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {
            //Panel3.Visible = true;
            //sum = 0;
            //Session["DateFrom"] = txtDateFrom.Text;
            //Session["DateTo"] = txtDateTo.Text;
            sql = " Exec JCT_COURIER_GET_COURIERS_GENERATED '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlCourierService.SelectedItem.Value + "' , '" +ddlDept.SelectedItem.Value +"'";
            obj1.FillGrid(sql, ref GridView2);
        }
        catch (Exception ex)
        {

        }
  
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", GridView2);
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Couriers_Generated.aspx");
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCourierService_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}