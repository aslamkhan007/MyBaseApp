using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;


public partial class OPS_TPMSummary_Crystal : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;

    ReportDocument rpt;

    

    private void Page_Unload(System.Object sender, System.EventArgs e)
    {
        try
        {
            if (((rpt != null)))
            {
                if (rpt.IsLoaded == true)
                {
                    rpt.Close();
                    rpt.Dispose();
                }
            }
        }
        catch
        { 
        
        }

        
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        Fill();
    
    }

    protected void Fill()
    {
        try
        {
            sql = "SELECT  MainGroup,ISNULL(CONVERT(VARCHAR,PckgTdy),'') AS [Pckg Today],ISNULL(CONVERT(VARCHAR,PckgUTD),'') [Pckg UptoDate],ISNULL(CONVERT(VARCHAR,DisTdy),'') [Dispatch Today],ISNULL(CONVERT(VARCHAR,DisTdyVal),'') AS [Dispatch TodayVal],ISNULL(CONVERT(VARCHAR,DisUTD),'') AS [Dispatch UptoDate Qty],ISNULL(CONVERT(VARCHAR,DisUTDVal),'') AS [Dispatch Uptodate Value],ISNULL(CONVERT(VARCHAR,NSR),'') AS NSR,CONVERT(VARCHAR,FromDate,101) AS FromDate,CONVERT(VARCHAR,ToDate,101) AS ToDate FROM    [JCT_NEW_TPM_SUMMARY] ORDER BY SNo";

            TpmSummary ts = new TpmSummary();
            DataTable dt = new DataTable();
            dt = getRecord();
            ts.Tables[0].Merge(dt);

            rpt = new ReportDocument();
            rpt.Load(Server.MapPath("TpmSummary.rpt"));
            rpt.SetDataSource(ts);
            CrystalReportViewer1.ReportSource = rpt;

            CrystalReportViewer1.Height = 600;
            CrystalReportViewer1.Width = 820;
        }
        catch
        { 
        
        }
       
 
    }

    public DataTable getRecord()
    {
        #region ConnectionString

        String ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shpConnectionString"].ConnectionString;

        #endregion

        SqlConnection Con = new SqlConnection(ConStr);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = null;
        SqlDataAdapter adapter;
        try
        {
            Con.Open();
            //Stored procedure calling. It is already in sample db.
            //cmd.CommandText = "SELECT  MainGroup,PckgTdy,PckgUTD,DisTdy,DisTdyVal,DisUTD,DisUTDVal, NSR,FromDate AS FromDate,ToDate AS ToDate FROM    [JCT_NEW_TPM_SUMMARY] ORDER BY SNo";
            cmd.CommandText = "JCT_OPS_NEW_TPM_SUMMARY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            cmd.Connection = Con;
            ds = new DataSet();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "records");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            cmd.Dispose();
            if (Con.State != ConnectionState.Closed)
                Con.Close();
        }
        return ds.Tables[0];
    }

    protected void CrystalReportSource1_Load(object sender, EventArgs e)
    {
        try
        {
            CrystalReportSource1.ReportDocument.SetDatabaseLogon("ITGRP", "power");
        }
        catch
        { 
        
        }
        
    }
    protected void lnkRefresh_Click(object sender, EventArgs e)
    {
        //Fill();
    }
}
