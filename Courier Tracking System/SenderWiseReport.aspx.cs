using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_SenderWiseReport : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions Obj1 = new Functions();
    string sql;
    double sum = 0.0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmpCode"] == "")
            {
                Response.Redirect("~/Login.aspx");
            }
            if (ddlSelectType.SelectedItem.Text == "Customer")
            {
                sql = "Select '  All  ' as [cust_no],'  All  ' as [cust_name] Union select cust_no,cust_name from m_customer_address";
                Obj1.FillList(ddlName, sql);
            }
            else if (ddlSelectType.SelectedItem.Text == "Supplier")
            {
                sql = "Select '  All  ' as [vendor_code],'  All  ' as [vendor_name] Union SELECT vendor_code,vendor_name FROM dbo.jct_courier_vendor_master";
                Obj1.FillList(ddlName, sql);
            }
            else if (ddlSelectType.SelectedItem.Text =="Other")
            {
                sql = "Select '  All  ' as [PartyName] Union SELECT PartyName FROM dbo.jct_courier_other_address";
                Obj1.FillList(ddlName, sql);
            }
            else if (ddlSelectType.SelectedItem.Text == "HO")
            {
                sql = "Select '  All  ' as [Head Office],'  All  ' as [Head Office] Union SELECT 'Head Office' ,'Head Office' ";
                Obj1.FillList(ddlName, sql);
            }
            else if (ddlSelectType.SelectedItem.Text == "Hoshiarpur JCT")
            {
                sql = "Select '  All  ' as [Hoshiarpur JCT],'  All  ' as [Hoshiarpur JCT] Union SELECT 'Hoshiarpur JCT' ,'Hoshiarpur JCT' ";
                Obj1.FillList(ddlName, sql);
            }
            else if (ddlSelectType.SelectedItem.Text == "  All  ")
            {
                sql = "Select '  All  ','  All  '  ";
                Obj1.FillList(ddlName, sql);
            }
            
        }
    }
    protected void ddlSelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectType.SelectedItem.Text == "Customer")
        {
            sql = "Select '  All  ' as [cust_no],'  All  ' as [cust_name] Union select cust_no,cust_name from m_customer_address";
            Obj1.FillList(ddlName, sql);
        }
        else if (ddlSelectType.SelectedItem.Text == "Supplier")
        {
            sql = "Select '  All  ' as [vendor_code],'  All  ' as [vendor_name] Union SELECT vendor_code,vendor_name FROM dbo.jct_courier_vendor_master";
            Obj1.FillList(ddlName, sql);
        }
        else if (ddlSelectType.SelectedItem.Text == "Other")
        {
            sql = "Select '  All  ' as [PartyName] Union SELECT PartyName FROM dbo.jct_courier_other_address";
            Obj1.FillList(ddlName, sql);
        }
        else if (ddlSelectType.SelectedItem.Text == "HO")
        {
            sql = "Select '  All  ' as [Head Office],'  All  ' as [Head Office] Union SELECT 'Head Office' ,'Head Office' ";
            Obj1.FillList(ddlName, sql);
        }
        else if (ddlSelectType.SelectedItem.Text == "Hoshiarpur JCT")
        {
            sql = "Select '  All  ' as [Hoshiarpur JCT],'  All  ' as [Hoshiarpur JCT] Union SELECT 'Hoshiarpur JCT' ,'Hoshiarpur JCT' ";
            Obj1.FillList(ddlName, sql);
        }
        else if (ddlSelectType.SelectedItem.Text == "  All  ")
        {
            sql = "Select '  All  ','  All  '  ";
            Obj1.FillList(ddlName, sql);
        }  
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        sql = "Exec jct_courier_Sender_Wise_Report '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDelivery.SelectedItem.Text + "','" + ddlName.SelectedItem.Text + "','" + ddlCourierService.SelectedItem.Text + "'   ,'" + ddlCourierType.SelectedItem.Text + "' ,'"+ ddlSelectType.SelectedItem.Text +"'";
        Obj1.FillGrid(sql, ref GridView1);
        Session["DateFrom"] = txtDateFrom.Text;
        Session["DateTo"] = txtDateTo.Text;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        sql = "Exec jct_courier_Sender_Wise_Report '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDelivery.SelectedItem.Text + "','" + ddlName.SelectedItem.Text + "','" + ddlCourierService.SelectedItem.Text + "'   ,'" + ddlCourierType.SelectedItem.Text + "' ,'" + ddlSelectType.SelectedItem.Text + "'";
        Obj1.FillGrid(sql, ref GridView1);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblCost = (Label)e.Row.Cells[3].FindControl("lblCost");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            sum = sum + int.Parse(lblCost.Text);
        }
       
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = "Total (in Rupees)";
            e.Row.Cells[3].Text = sum.ToString();
        }
    }

   

    public bool CreateExcelFile(DataTable dt)
    {
        bool bFileCreated = false;
        string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Detailed List of Courier receiving party   between '" + txtDateFrom.Text + "' and '" + txtDateTo.Text + "'</TH></TR>";
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
        string sExcelFile = Server.MapPath("Party_Summary.xls");
        oExcelWrite = System.IO.File.CreateText(sExcelFile);
        oExcelWrite.WriteLine(sTable);
        oExcelWrite.Close();
        bFileCreated = true;
        return bFileCreated;

    }

    protected void lnkExcel_Click1(object sender, EventArgs e)
    {
        sql = "Exec jct_courier_Sender_Wise_Report '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDelivery.SelectedItem.Text + "','" + ddlName.SelectedItem.Text + "','" + ddlCourierService.SelectedItem.Text + "'   ,'" + ddlCourierType.SelectedItem.Text + "' ,'" + ddlSelectType.SelectedItem.Text + "'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        CreateExcelFile(dt);
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("Party_Summary.xls")));
        Response.AppendHeader("Content-Disposition", "attachment; filename=Party_Summary.xls");
        Response.TransmitFile(Server.MapPath("Party_Summary.xls"));
        Response.End();
        obj.ConClose();
    }
    protected void lnkSummary_Click(object sender, EventArgs e)
    {
        string sql = string.Empty;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        sql = "jct_courier_request_count";
        cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString();
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text).ToShortDateString();
        //cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = txtEmployeeCode.Text;
        //cmd.Parameters.Add("@DeptCode", SqlDbType.VarChar, 20).Value = ddlDept.SelectedItem.Value;
        cmd.Parameters.Add("@CourierService", SqlDbType.VarChar, 200).Value = ddlCourierService.SelectedItem.Value;
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        grdCourierCount.DataSource = ds.Tables[0];
        grdCourierCount.DataBind();
    }
}