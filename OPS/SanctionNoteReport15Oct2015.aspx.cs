using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class OPS_SanctionNoteReport : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    Decimal GreighReq = 0, AdjustedQty = 0, AuthAdjustedQty = 0;
    GridViewExportUtil export = new GridViewExportUtil();

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        grdMaster.DataSource = null;
        grdMaster.DataBind();
        GridSummary.DataSource = null;
        GridSummary.DataBind();

        grdChild.DataSource = null;
        grdChild.DataBind();
        GrdAuthHistory.DataSource = null;
        GrdAuthHistory.DataBind();

        // if (ddlAuthBy.SelectedIndex == 1 || ddlAuthBy.SelectedIndex == 2)
        if (ddlAuthBy.SelectedIndex == 0 && ddlArea.SelectedItem.Value != "1006" && ddlArea.SelectedItem.Value != "1042" && ddlArea.SelectedItem.Value != "1057" && ddlArea.SelectedItem.Value != "1044")
        {
       
            sql = "JCT_OPS_SANCTION_NOTE_AUTHORIZATION";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtDateFrom.Text;
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtDateTo.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value =ddlAuthBy.SelectedItem.Value;
            cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = ddlArea.SelectedItem.Value;
            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = txtSanctionID.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = ddlStatus.SelectedItem.Text;
            cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 10).Value = txtRequestBy.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdMaster.DataSource = ds;
            grdMaster.DataBind();
        }

        else
        {
            sql = "JCT_OPS_SANCTION_REPORT";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtDateFrom.Text;
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtDateTo.Text;
            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = txtSanctionID.Text;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlStatus.SelectedItem.Value;
            cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = ddlArea.SelectedItem.Value;
            cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 10).Value = txtRequestBy.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdMaster.DataSource = ds;
            grdMaster.DataBind();
        }
    }

    protected void grdMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        pnlChild.Visible = true;
        String SanctionID;
        if (ddlArea.SelectedItem.Value=="1006")
        {
        SanctionID = grdMaster.SelectedRow.Cells[2].Text;
        sql = "SELECT SALEORDER AS [Order No],SORT,LineItem,Shade,QTY,CaseType,GREIGHREQ AS [Greigh Req],isnull(AdjustedQty,0) as AdjustedQty,isnull(Authorized_Adjusted_Qty,0)  AS [Auth Adj Qty] FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTED_ORDERS WHERE SanctionID=@SanctionID ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = SanctionID;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdChild.DataSource = ds;
        grdChild.DataBind();
        }
        else
        {
           SanctionID = grdMaster.SelectedRow.Cells[5].Text;
           sql = "Jct_Ops_Pending_Authorization_Fetch_Detail";// '" + grdMaster.SelectedRow.Cells[4].Text + "','" + ddlArea.SelectedItem.Value + "'";
           SqlCommand cmd = new SqlCommand(sql, obj.Connection());
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@ID", SqlDbType.VarChar, 10).Value = SanctionID;
           cmd.Parameters.Add("@Areacode", SqlDbType.VarChar, 10).Value = ddlArea.SelectedItem.Value;
           SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdChild.DataSource = ds;
            grdChild.DataBind();

            sql = "exec Jct_Ops_SanctionNote_Authrization_Detail '" +  grdMaster.SelectedRow.Cells[5].Text + "'";
            obj1.FillGrid(sql,ref GrdAuthHistory);

            pnlGrdAuth.Visible = true;

            sql = "   SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + SanctionID + "'";
            cmd = new SqlCommand(sql, obj.Connection());
             da = new SqlDataAdapter(cmd);
             ds = new DataSet();
            da.Fill(ds);
            dtlAttachment.DataSource = ds.Tables[0];
            dtlAttachment.DataBind();


        }
    }

    protected void grdMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddlArea.SelectedItem.Value != "1006")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
                grdMaster.DataKeyNames.Equals("SanctionID");
                String SanctionID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionID"));

                GridView GridViewNested = (GridView)e.Row.FindControl("nestedGridView");
                GridViewNested.DataKeyNames.Equals("Description");
                sql = "Select Description from Jct_Ops_SanctionNote_HDR where sanctionNoteID='" + SanctionID + "'";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridViewNested.DataSource = ds.Tables[0];
                GridViewNested.DataBind();


            }
        }
     
        }
    

    protected void grdChild_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddlArea.SelectedItem.Value == "1006")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GreighReq = GreighReq + Convert.ToDecimal(e.Row.Cells[6].Text);
                AdjustedQty = AdjustedQty + Convert.ToDecimal(e.Row.Cells[7].Text);
                AuthAdjustedQty = AuthAdjustedQty + Convert.ToDecimal(e.Row.Cells[8].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "Total";
                e.Row.Cells[6].Text = Convert.ToString(GreighReq);
                e.Row.Cells[7].Text = Convert.ToString(AdjustedQty);
                e.Row.Cells[8].Text = Convert.ToString(AuthAdjustedQty);
            }
        }
     
    }
    protected void lnkSummary_Click(object sender, EventArgs e)
    {
        pnlMaster.Visible = true;
        sql = "JCT_OPS_SANCTION_NOTE_GREIGH_TRANSFER_SUMMARY";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 20).Value = ddlArea.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdMaster.DataSource = ds;
        grdMaster.DataBind();
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("GreigeTransfer.xls", grdMaster);
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlArea.SelectedItem.Value == "1006")
        {
            lnkSummary.Visible = true;
        }
        else
        {
            lnkSummary.Visible = false;
        }
    }



    // protected void dtlAttachment_ItemCommand(object source, DataListCommandEventArgs e)
    //{
    //      If e.CommandName == "Download" Then
    //    {
    //        String filepath  = Server.MapPath("~\Ops\Upload\" + e.CommandArgument.ToString());

    //        If File.Exists(filepath) = False Then
    //        {
    //            String Scrpt As  = "alert('File Not Found. Please contact IT-HelpDesk @4212');";
    //            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True);
    //        }
    //        Else
    //        {

    //            String strFileName  = ""
    //            strFileName = e.CommandArgument
               
    //            Response.Redirect("DownloadFile.aspx?filepath=" + filepath + "&FileName=" + strFileName);
    //        }
    //    }
        
    //}
    protected void dtlAttachment_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            string filepath = Server.MapPath("~\\Ops\\Upload\\" + e.CommandArgument.ToString());


            if ((File.Exists(filepath) == false))
            {
                string Scrpt = "alert('File Not Found. Please contact IT-HelpDesk @4212');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);

            }
            else
            {

                string strFileName = "";
                strFileName = (string)e.CommandArgument;

                Response.Redirect("DownloadFile.aspx?filepath=" + filepath + "&FileName=" + strFileName);





            }

        }

    }
    protected void lnkReset0_Click(object sender, EventArgs e)
    {
               string Scrpt = "";


        if (grdMaster.SelectedIndex==-1)
        {
             Scrpt = "alert('No SanctionNote Selected For Printing');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);

        }
        else
        {

            Response.Redirect("SanctionNote_Preview.aspx?SID=" +  grdMaster.SelectedRow.Cells[5].Text);
        }
    }

    protected void txtRequestBy_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRequestBy.Text = txtRequestBy.Text.Split('|')[1].ToString();

        }

        catch
        {

        }
    }
    protected void lnkSanctionSumaary_Click(object sender, EventArgs e)
    {
        GridSummary.DataSource = null;
        GridSummary.DataBind();


        grdMaster.DataSource = null;
            grdMaster.DataBind();

        grdChild.DataSource = null;
        grdChild.DataBind();
        GrdAuthHistory.DataSource = null;
        GrdAuthHistory.DataBind();

        // if (ddlAuthBy.SelectedIndex == 1 || ddlAuthBy.SelectedIndex == 2)
        if (ddlAuthBy.SelectedIndex == 0 && ddlArea.SelectedItem.Value != "1006" && ddlArea.SelectedItem.Value != "1042" && ddlArea.SelectedItem.Value != "1057" && ddlArea.SelectedItem.Value != "1044")
        {

            sql = "JCT_OPS_SANCTION_NOTE_AUTHORIZATION_Summary";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtDateFrom.Text;
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtDateTo.Text;
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = ddlAuthBy.SelectedItem.Value;
            cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = ddlArea.SelectedItem.Value;
            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = txtSanctionID.Text;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = ddlStatus.SelectedItem.Text;
            cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 10).Value = txtRequestBy.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridSummary.DataSource = ds;
            GridSummary.DataBind();
        }

        else
        {
            sql = "JCT_OPS_SANCTION_REPORT_summary";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtDateFrom.Text;
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtDateTo.Text;
            cmd.Parameters.Add("@SanctionID", SqlDbType.VarChar, 10).Value = txtSanctionID.Text;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = txtOrderNo.Text;
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlStatus.SelectedItem.Value;
            cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 10).Value = ddlArea.SelectedItem.Value;
            cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 10).Value = txtRequestBy.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridSummary.DataSource = ds;
            GridSummary.DataBind();
        }
    }
}