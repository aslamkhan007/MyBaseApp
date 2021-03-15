using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;

public partial class OPS_TPM_Summary : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();

    #region ConnectionString

    String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shpConnectionString"].ConnectionString;

    #endregion

    #region variable declaration

    private string sql;
    private double pckgTdy = 0.0;
    private double PckgUTD = 0.0;
    private double DisTdy = 0.0;
    private double DisTdyVal = 0.0;
    private double DisUTDVal = 0.0;
    private double nsr = 0.0;
    private double DisUTD = 0.0;

#endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConStr);

        if (Request.QueryString["summary"] == "yes")
        {
            
            try
            {
                conn.Open();

                sql = "SELECT  MainGroup,ISNULL(CONVERT(VARCHAR,PckgTdy),'') AS [Pckg Today],ISNULL(CONVERT(VARCHAR,PckgUTD),'') [Pckg UptoDate],ISNULL(CONVERT(VARCHAR,DisTdy),'') [Dispatch Today],ISNULL(CONVERT(VARCHAR,DisTdyVal),'') AS [Dispatch TodayVal],ISNULL(CONVERT(VARCHAR,DisUTD),'') AS [Dispatch UptoDate Qty],ISNULL(CONVERT(VARCHAR,DisUTDVal),'') AS [Dispatch Uptodate Value],ISNULL(CONVERT(VARCHAR,NSR),'') AS NSR,CONVERT(VARCHAR,FromDate,101) AS FromDate,CONVERT(VARCHAR,ToDate,101) AS ToDate FROM    [JCT_NEW_TPM_SUMMARY] ORDER BY SNo";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                RadGrid1.DataSource = ds;
                RadGrid1.DataBind();

            }

            catch (Exception ex)
            {
                string script = "alert('There was some error in reading record..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

            finally
            {
                conn.Close();
            }
        }

      
        
    }

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridHeaderItem)
        {
            /* Visibility false for columns headers - PckgTdy , DisTdy, DisTdyVal, FromDate,ToDate */

            e.Item.Cells[3].Visible = false;
            e.Item.Cells[5].Visible = false;
            e.Item.Cells[6].Visible = false;
            e.Item.Cells[10].Visible = false;
            e.Item.Cells[11].Visible = false;

        }
        if (e.Item is GridDataItem )
        {
            GridDataItem dataitem = e.Item as GridDataItem;

            

            if (dataitem.Cells[2].Text != "[Total]" && dataitem.Cells[2].Text != "[Remanants Total]" && dataitem.Cells[2].Text != "[Total Fabrics]")
            {
                /* Sub-Totals that are included in the table by defaukt are being excluded here. */

                 //pckgTdy += double.Parse(dataitem.Cells[3].Text); //double.Parse(dataitem["Pckg Today"].Text);
                 //PckgUTD += double.Parse(e.Item.Cells[4].Text == "" ? "0" : e.Item.Cells[4].Text);
                 //DisTdy += double.Parse(e.Item.Cells[5].Text == "" ? "0" : e.Item.Cells[5].Text);
                 //DisTdyVal += double.Parse(e.Item.Cells[6].Text == "" ? "0" : e.Item.Cells[6].Text);
                 //DisUTD += double.Parse(e.Item.Cells[7].Text == "" ? "0" : e.Item.Cells[7].Text);
                 DisUTDVal += double.Parse(e.Item.Cells[8].Text == "" ? "0" : e.Item.Cells[8].Text);
            
            //nsr += 
            }

            if (dataitem.Cells[2].Text == "[Total]" || dataitem.Cells[2].Text == "[Remanants Total]" || dataitem.Cells[2].Text == "[Total Fabrics]")
            {
                /* Change row color and font color for the sub-total rows. */

                GridDataItem item = e.Item as GridDataItem;

                item.BackColor = System.Drawing.Color.DimGray;
                item.ForeColor = System.Drawing.Color.White;

            }

            /* Visibility false for column items - PckgTdy , DisTdy, DisTdyVal, FromDate,ToDate */
             
            e.Item.Cells[3].Visible = false;
            e.Item.Cells[5].Visible = false;
            e.Item.Cells[6].Visible = false;
            e.Item.Cells[10].Visible = false;
            e.Item.Cells[11].Visible = false;
           
        }

        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = e.Item as  GridFooterItem;

            item.Cells[2].Text = "GRAND TOTAL";
            //item.Cells[3].Text = pckgTdy.ToString();
            //item.Cells[4].Text = PckgUTD.ToString();
            //item.Cells[5].Text = DisTdy.ToString();
            //item.Cells[6].Text = DisTdyVal.ToString();
            //item.Cells[7].Text = DisUTD.ToString();
            item.Cells[8].Text = DisUTDVal.ToString();

            /* Change row color and font color for the sub-total row footers. */

            item.BackColor = System.Drawing.Color.DimGray;
            item.ForeColor = System.Drawing.Color.White;

            /* Visibility false for column footer PckgTdy , DisTdy, DisTdyVal, FromDate,ToDate */

            e.Item.Cells[3].Visible = false;
            e.Item.Cells[5].Visible = false;
            e.Item.Cells[6].Visible = false;
            e.Item.Cells[10].Visible = false;
            e.Item.Cells[11].Visible = false;

        }
    }

    protected void radbtnExcel_Click(object sender, EventArgs e)
    {
        /* Export the grid contents to excel. */

        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.UseItemStyles = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;
        RadGrid1.MasterTableView.ExportToExcel();
    }

   


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        RadGrid1.AllowPaging = false;
        RadGrid1.Rebind();
        //RadAjaxPanel1.ResponseScripts.Add("PrintRadGrid('" + RadGrid1.ClientID + "')");
    }

    protected void radbtnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "PopUp", "PopUp();", true);
    }

     
}