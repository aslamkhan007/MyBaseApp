using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

public partial class jQueryAjaxData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Response.Write(Request.QueryString["txtArea1"]);
        // return;


        if (Request.QueryString["ag"] != null && Request.QueryString["bg"] != null)
        {
            int a = int.Parse(Request.QueryString["ag"]);
            int b = int.Parse(Request.QueryString["bg"]);
            int sum = a + b;
            Response.Write("The Sum is " + sum);
        }

        if (Request.Form["a"] != null && Request.Form["b"] != null)
        {
            int a = int.Parse(Request.Form["a"]);
            int b = int.Parse(Request.Form["b"]);
            int sum = a + b;
            Response.Write("The Sum is " + sum);
            System.Threading.Thread.Sleep(1000);
        }

        // json
        if (Request.QueryString["comingFrom"] != null)
        {
            string data = " [ { \"FirstName\": \"Sheo\", \"LastName\": \"Narayan\", \"City\": \"Hyderabad\" }, " + 
                "{ \"FirstName\": \"Jack\", \"LastName\": \"Jeel\", \"City\": \"NY\" } ]";
            Response.Write(data);
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetFullName()
    {
        string data = " [ { \"FirstName\": \"Sheo\", \"LastName\": \"Narayan\", \"City\": \"Hyderabad\" }, " +
                "{ \"FirstName\": \"Jack\", \"LastName\": \"Jeel\", \"City\": \"NY\" } ]";
        return data;
    }
    [WebMethod]
    public static string GetData()
    {
        string resp = string.Empty;
        string sql;
        sql = "Select * from jct_empmast_base where empcode in () ";
        resp += "<p>This content is dynamically appended to the existing content on scrolling.</p>";
        return resp;
    }
}