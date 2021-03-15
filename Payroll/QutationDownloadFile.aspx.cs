using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DownloadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            String filepath = Request.QueryString["filepath"];
            String filename = Request.QueryString["FileName"];
            String strFileName = filename;
            strFileName = strFileName.Replace(" ", "");
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.WriteFile(filepath + strFileName);
            HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('There is some problem while downloading file.plz contact at 4226');", true);
        }
    }
}