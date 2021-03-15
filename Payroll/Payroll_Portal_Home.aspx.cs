using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Payroll_Portal_Home : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string empcode;
    string cardno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            BindDataList();
        }
    }

    public void BindDataList()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PageOrder_Menu_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Group", SqlDbType.Int).Value = 2;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }

    public void OnClickHandler(object sender, EventArgs e)
    {
        var b = string.Empty;
        LinkButton btn = (LinkButton)(sender);
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT PageName FROM Jct_Payroll_PageOrder_Menu WHERE MenuName = '" + btn.Text + "'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                b = dr[0].ToString();
            }
        }
        dr.Close();
        Response.Redirect(b);
    }
}