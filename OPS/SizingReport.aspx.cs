using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_SizingReport : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    Decimal Allocated = 0;
    Decimal BeamLength =0;
    Decimal SizingDone = 0;
    Decimal GreighReq = 0;
    Decimal GreighAdj = 0;
    Decimal SizingReq = 0;
    Decimal SizingComplete = 0;
    String script;
    GridViewExportUtil gridviewexportutil;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        Div1.Visible = false;
        //sql = "JCT_OPS_SIZING_REPORT";
        sql="JCT_OPS_SIZING_REPORT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;
        //cmd.Parameters.Add("@DATEFROM", SqlDbType.DateTime).Value =Convert.ToDateTime(txtDateFrom.Text);
        //cmd.Parameters.Add("@DATETO", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text);
        cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar,10).Value =txtSortNo.Text;
        //cmd.Parameters.Add("@BeamNo", SqlDbType.VarChar,10).Value = txtBeamNo.Text;
        //cmd.Parameters.Add("@FLAG", SqlDbType.Char, 1).Value = ddlType.SelectedItem.Text;
        //cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Value;
        //cmd.Parameters.Add("@ISSUENO", SqlDbType.VarChar, 20).Value = txtIssueNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdSizing.DataSource = ds;
            grdSizing.DataBind();
        }
        else
        {
            script = "alert('No Record present for selected options..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
      
    }
    protected void grdSizing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Div1.Visible = true;
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int RowIndex = gvRow.RowIndex;

           // sql = "SELECT  orderno , sort_no , ISS_NO , mc_type ,  beam_no , Flag , AllocatedLength ,  Length AS [BeamLength] ,  CONVERT(VARCHAR, Mappingdate, 103) AS [Date] ,  b.empname AS [Mapped By] FROM    dbo.JCT_OPS_BEAM_SALEORDER_MAPPING a INNER JOIN dbo.JCT_EmpMast_Base b ON a.Mapped_by = b.empcode WHERE   b.Active = 'Y' AND a.STATUS='A' AND orderno=@OrderNo order by Mappingdate";
            sql = "JCT_OPS_SIZING_REPORT_DETAIL";

            //obj1.FillGrid(sql, ref grdSizingDetail);
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateFrom.Text);
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text);
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = grdSizing.Rows[RowIndex].Cells[1].Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.Int).Value = grdSizing.Rows[RowIndex].Cells[2].Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdSizingDetail.DataSource = ds;
            grdSizingDetail.DataBind();
        }
    }
    protected void grdSizingDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            Allocated = Allocated + Convert.ToDecimal(e.Row.Cells[6].Text);
            BeamLength = BeamLength + Convert.ToDecimal(e.Row.Cells[7].Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[5].Text = "Total";
            e.Row.Cells[6].Text = Convert.ToString(Allocated);
            e.Row.Cells[7].Text = Convert.ToString(BeamLength);
        }
    }
    protected void grdSizing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            GreighReq = GreighReq + Convert.ToDecimal(e.Row.Cells[3].Text);
            GreighAdj = GreighAdj + Convert.ToDecimal(e.Row.Cells[4].Text);
            SizingReq = SizingReq + Convert.ToDecimal(e.Row.Cells[5].Text);
            SizingComplete = SizingComplete + Convert.ToDecimal(e.Row.Cells[6].Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = "Total";
            e.Row.Cells[3].Text = Convert.ToString(GreighReq);
            e.Row.Cells[4].Text = Convert.ToString(GreighAdj);
            e.Row.Cells[5].Text = Convert.ToString(SizingReq);
            e.Row.Cells[6].Text = Convert.ToString(SizingComplete);
        }
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SizingReport.aspx");
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        sql = "JCT_OPS_SIZING_REPORT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 180;
        //cmd.Parameters.Add("@DATEFROM", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateFrom.Text);
        //cmd.Parameters.Add("@DATETO", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTo.Text);
        cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 10).Value = txtSortNo.Text;
        //cmd.Parameters.Add("@BeamNo", SqlDbType.VarChar, 10).Value = txtBeamNo.Text;
        //cmd.Parameters.Add("@FLAG", SqlDbType.Char, 1).Value = ddlType.SelectedItem.Text;
        //cmd.Parameters.Add("@SHED", SqlDbType.VarChar, 20).Value = ddlShed.SelectedItem.Value;
        //cmd.Parameters.Add("@ISSUENO", SqlDbType.VarChar, 20).Value = txtIssueNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        CreateExcelFile(dt);
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("SizingReport.xls")));
        Response.AppendHeader("Content-Disposition", "attachment; filename=FreezedPlan.xls");
        Response.TransmitFile(Server.MapPath("SizingReport.xls"));
        Response.End();
        obj.ConClose();
    }

    public bool CreateExcelFile(DataTable dt)
    {
        bool bFileCreated = false;
        string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Freezed Plan</TH></TR>";
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
        string sExcelFile = Server.MapPath("SizingReport.xls");
        oExcelWrite = System.IO.File.CreateText(sExcelFile);
        oExcelWrite.WriteLine(sTable);
        oExcelWrite.Close();
        bFileCreated = true;
        return bFileCreated;

    }
}