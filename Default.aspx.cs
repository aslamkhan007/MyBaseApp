using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web;
using System.Data;  
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    [WebMethod]
    public static string InsertMethod(string Name, string Email)
    {
        SqlConnection con = new SqlConnection("Data Source=test2k;Initial Catalog=jctdev4;User ID=itgrp;Password=power");
        {
            SqlCommand cmd = new SqlCommand("Insert into TestTable values('" + Name + "', '" + Email + "')", con);
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "True";
            }
        }
    }  
}