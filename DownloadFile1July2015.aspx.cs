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
        string str = string.Empty;
        string filepath = string.Empty;

         filepath = "http://testerp/fusionapps/Docs/News_sh/RevisedVisionary.wmv";
        ////filepath = Server.MapPath("~/MediaPlayer/files/Butterfly.wmv");
    

         //filepath = Server.MapPath("~/mediaplayer/files/RevisedVisionary.wmv");
         //RevisedVisionary.wmv
        str = "<OBJECT ID='MediaPlayer' WIDTH='800' HEIGHT='600'  CLASSID='CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95' STANDBY='Loading Windows Media Player components...' TYPE='application/x-oleobject' VIEWASTEXT> <PARAM name='FileName' VALUE='" + filepath + "' > <PARAM name='autostart' VALUE='false'> <PARAM name='ShowControls' VALUE='true'> <param name='ShowStatusBar' value='true'> <PARAM name='ShowDisplay' VALUE='false'> <EMBED TYPE='application/x-mplayer2' NAME='MediaPlayer'></EMBED></OBJECT>";
     
        ltrlMediaPlayer.Text = str;
     
        

    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}