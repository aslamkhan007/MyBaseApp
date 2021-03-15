using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class OPS_budgetReport : System.Web.UI.Page
{
    SqlConnection obj = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ReportDBConnectionString"].ConnectionString);
    Connection con = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
     
        if (!IsPostBack)
        {
           
            if (!obj1.CheckRecordExistInTransaction("SELECT * FROM dbo.JCT_EmpMast_Base a WHERE a.subdept_code='MIS' and a.subdept_name='" + Session["EmpCode"].ToString() + "'") )
            {
                ListItem items;
                sql = " Select '' as Deptname,'' as DeptCode Union SELECT distinct a.subdept_name as DeptName, a.subdept_code as DEPTCODE FROM dbo.JCT_EmpMast_Base a WHERE a.empcode='" + Session["Empcode"].ToString() +"'";
                //ddldept.Items.Clear();
                SqlDataReader dr = obj1.FetchReader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        items = new ListItem();
                        items.Value=dr["DeptCode"].ToString();
                        items.Text =dr["DeptName"].ToString();
                        ddldept.Items.Add(items);
                    }
                }
                dr.Close();
            }
            else
            {
                //sql = "SELECT DEPTCODE,DEPTNAME FROM dbo.DEPTMAST";
                //obj1.FillList(ddldept, sql);
            }
        }

        if (Session["EmpCode"].ToString() == "R-03619")
        {
            ListItem items;
            sql = " Select '' as Deptname,'' as DeptCode Union SELECT distinct a.subdept_name as DeptName, a.subdept_code as DEPTCODE FROM dbo.JCT_EmpMast_Base a  where subdept_name <>''";
            //ddldept.Items.Clear();
            SqlDataReader dr = obj1.FetchReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    items = new ListItem();
                    items.Value = dr["DeptCode"].ToString();
                    items.Text = dr["DeptName"].ToString();
                    ddldept.Items.Add(items);
                }
            }
            dr.Close();
        }
    }

    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {
        //sql = "SELECT distinct a.empcode,a.empname from  test2k.jctdev.dbo.JCT_EmpMast_Base a join  test2k.jctdev.dbo.JCT_Emp_Catg_Desg_Mapping b on  a.catg=b.catg where a.active='Y' and a.company_code='JCT00LTD' and a.catg='SM1' and deptcode= '" + ddldept.SelectedItem.Value + "'";
        sql = "SELECT distinct a.empcode,a.empname from JCT_EmpMast_Base a join JCT_Emp_Catg_Desg_Mapping b on  a.catg=b.catg where a.active='Y' and a.company_code='JCT00LTD' and a.catg='SM1' and a.subdept_code= '" + ddldept.SelectedItem.Value + "'";
        obj1.FillList(ddlhod, sql);
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        obj.Open();

        SqlCommand cmd =  new SqlCommand("jct_ops_budget_report",obj);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@hod", SqlDbType.VarChar,20).Value = ddlhod.SelectedValue;
        if(txtefffrom.Text!=string.Empty || !string.IsNullOrEmpty(txtefffrom.Text))
        {
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrom.Text);
        }
        if(txtefffrom.Text!=string.Empty || !string.IsNullOrEmpty(txtefffrom.Text))
        {
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
        }
        
        cmd.Parameters.Add("@dept_name", SqlDbType.VarChar, 20).Value = ddldept.SelectedValue;
        cmd.Parameters.Add("@budget_type", SqlDbType.VarChar, 20).Value = ddltype.SelectedItem.Text;
    
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        obj.Close();
    }

    protected void lbexcel_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_budget_report", obj);
        cmd.CommandType = CommandType.StoredProcedure;
        obj.Open();
        cmd.Parameters.Add("@hod", SqlDbType.VarChar, 20).Value = ddlhod.SelectedValue;
        if (txtefffrom.Text != string.Empty || !string.IsNullOrEmpty(txtefffrom.Text))
        {
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrom.Text);
        }
        if (txtefffrom.Text != string.Empty || !string.IsNullOrEmpty(txtefffrom.Text))
        {
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
        }

        cmd.Parameters.Add("@dept_name", SqlDbType.VarChar, 20).Value = ddldept.SelectedValue;
        cmd.Parameters.Add("@budget_type", SqlDbType.VarChar, 20).Value = ddltype.SelectedItem.Text;

        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();


        DataTable dt = ds.Tables[0];
        string attachment = "attachment; Budget Report.xls";
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

        obj.Close();
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("budgetentry.aspx");
    }
}