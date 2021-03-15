using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Collections.Generic;

public partial class Payroll_JqueryAjaxJsonGridview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindColumnToGridview();
        }
    }
    /// <summary>
    /// This method is used to bind dummy row to gridview to bind data using JQuery
    /// </summary>
    private void BindColumnToGridview()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("UserId");
        dt.Columns.Add("UserName");
        dt.Columns.Add("Location");
        dt.Rows.Add();
        gvDetails.DataSource = dt;
        gvDetails.DataBind();
        gvDetails.Rows[0].Visible = false;
    }

    [WebMethod]
    public static UserDetails[] BindDatatable()
    {
        DataTable dt = new DataTable();
        List<UserDetails> details = new List<UserDetails>();

        using (SqlConnection con = new SqlConnection("Data Source=test2k;Initial Catalog=jctdev4;User ID=itgrp;Password=power"))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Plant_code AS UserId, Plant_Name AS UserName, Plant_description AS Location FROM  dbo.jct_payroll_Plant_Master WHERE Status = 'A'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dtrow in dt.Rows)
                {
                    UserDetails user = new UserDetails();
                    user.UserId = dtrow["UserId"].ToString();
                    user.UserName = dtrow["UserName"].ToString();
                    user.Location = dtrow["Location"].ToString();
                    details.Add(user);
                }
            }
        }
        return details.ToArray();
    }
    public class UserDetails
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
    }
}