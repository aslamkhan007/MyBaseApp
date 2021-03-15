using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_Sale_Order_Detail : System.Web.UI.Page
{

    string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ShpConnectionString"].ConnectionString;
    string constr2 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
if (Session["empcode"].ToString() == "")
        {
            Response.Redirect("~/login.aspx");
        }


        if (!IsPostBack)
        {
            fill_ddlSalePerson();
        }
        bindGrid();

        lblTotalOrders.Text = RadGrid1.Items.Count.ToString();

    }

    protected void cmdFetch_Click(object sender, EventArgs e)
    {
        bindGrid();
    }

    protected List<String> GetSalePersons()
    {
        List<String> sp = new List<String>();
        return sp;
    }

    protected void fill_ddlSalePerson()
    {
        //jct_ops_sales_persons
        
        Connection cn = new Connection(constr2);
        string sqlstr = "jct_ops_sales_persons";
        SqlCommand cmd = new SqlCommand(sqlstr, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            while (dr.Read())
            {
                RadComboBoxItem li = new RadComboBoxItem();
                li.Value = dr[0].ToString();
                li.Text = dr[dr.FieldCount - 1].ToString();
                ddlSalePerson.Items.Add(li);
            }
        }

        //ddlSalePerson.DataSource = cmd.ExecuteReader();
        //ddlSalePerson.DataBind();

    }

    protected void bindGrid()
    {

        Connection cn = new Connection(constr);
        Functions obj = new Functions();
        DataTable dt = new DataTable();
        string sqlstr = "reportdb..jct_ops_sale_orders";
        SqlCommand cmd = new SqlCommand(sqlstr, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        if ((rdpStartDate.SelectedDate.ToString() != String.Empty) && (rdpEndDate.SelectedDate.ToString() != String.Empty))
        {
            cmd.Parameters.Add("FromDt", SqlDbType.DateTime).Value = rdpStartDate.SelectedDate.ToString();
            cmd.Parameters.Add("ToDt", SqlDbType.DateTime).Value = rdpEndDate.SelectedDate.ToString();
            cmd.Parameters.Add("SalePerson", SqlDbType.VarChar, 30).Value = ddlSalePerson.SelectedItem.Value;
		cmd.Parameters.Add("EmpCode", SqlDbType.VarChar, 30).Value = Session["empcode"].ToString();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
        }

    }


    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        Connection cn = new Connection(constr);
        Functions obj = new Functions();
        DataTable dt = new DataTable();
        string sqlstr = "reportdb..jct_ops_sale_orders";
        SqlCommand cmd = new SqlCommand(sqlstr, cn.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        if ((rdpStartDate.SelectedDate.ToString() != String.Empty) && (rdpEndDate.SelectedDate.ToString() != String.Empty))
        {
            cmd.Parameters.Add("FromDt", SqlDbType.DateTime).Value = rdpStartDate.SelectedDate.ToString();
            cmd.Parameters.Add("ToDt", SqlDbType.DateTime).Value = rdpEndDate.SelectedDate.ToString();
            cmd.Parameters.Add("SalePerson", SqlDbType.VarChar, 30).Value = ddlSalePerson.SelectedItem.Value;
cmd.Parameters.Add("EmpCode", SqlDbType.VarChar, 30).Value = Session["empcode"].ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();       

        
        string attachment = "attachment; Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }

        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

        }

    }
        
}

