using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Samples_User_Controls_DirectionsAPI_Sample : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //The following block of code loads an example directions
        //When the page is initially loaded
        //You should delete it in case you use this control in production
        if (!IsPostBack)
        {
            txtfromCityStateZip.Text = "Orlando";
            txttoCityStateZip.Text = "Miami";
            Page.Validate(); //Workaround
            btnLoad_Click(null, null);
        }

    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //Build the from and to addresses from user input

            string fromAddress = txtfromCityStateZip.Text;
            if (txtfromStreet.Text.Length > 0)
                fromAddress = txtfromStreet.Text + ", " + fromAddress;


            string toAddress = txttoCityStateZip.Text;
            if (txttoStreet.Text.Length > 0)
                toAddress = txttoStreet.Text + ", " + toAddress;

            //Assign them to the directions control
            gdirections.FromAddress = fromAddress;
            gdirections.ToAddress = toAddress;
            gdirections.AutoLoad = true; //load directions automatically
            //Thats it!
        }
        else
            gdirections.AutoLoad = false; //not enough input, do not try loading directions
    }
}
