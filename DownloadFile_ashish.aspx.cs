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
        String filepath = "~\\docs\\news\\RevisedVisionary.mp4"; //Request.QueryString["filepath"];
        String filename = "RevisedVisionary.mp4";// Request.QueryString["FileName"];
           String     strFileName = filename;
                strFileName = strFileName.Replace(" ", "%20");
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName) ;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.WriteFile(filepath);
                HttpContext.Current.Response.End();
    }
}