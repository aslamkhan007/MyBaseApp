﻿using System;
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

public partial class AssetMngmnt_Asset_Alloc_Intimate_Mail_Common : System.Web.UI.Page
{
    string requestID = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    int requestid;  
    protected void Page_Load(object sender, EventArgs e)
    {
        requestid = Convert.ToInt16(Request.QueryString["requestid"]);
        //requestid = 2461;
       
        EmployeeDetail();

    }
    protected void EmployeeDetail()
    {
        sql = "SELECT  DISTINCT b.Usercode ,b.UserName,b.Sublocation,b.Location FROM  dbo.jct_asset_item_details AS a INNER JOIN jct_asset_Employee_Location_map AS b ON a.sub_location = b.Sublocation WHERE   a.item_id = '" + requestid + "' AND a.module_usedby = 'Gen' AND a.status = 'A' AND b.module_usedby = 'Gen' AND b.STATUS = 'A'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dsItem = new DataSet();
        da.Fill(dsItem);
        GridView1.DataSource = dsItem;
        GridView1.DataBind();

    }
}