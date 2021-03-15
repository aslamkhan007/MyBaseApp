using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using System.Net.Mail;


public partial class OPS_testpage : System.Web.UI.Page
{
    string a = string.Empty;
    //string oldrequestID = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        a = Request.QueryString["querystring"];
    }
}