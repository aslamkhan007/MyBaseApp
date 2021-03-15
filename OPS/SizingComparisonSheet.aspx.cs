using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class OPS_SizingComparisonSheet : System.Web.UI.Page
{
    string ConStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["productionConnectionString1"].ConnectionString;
    Connection obj = new Connection();
    SqlConnection conn;
    
    Functions obj1 = new Functions();
    String sql;


    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(ConStr);
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        pnlSizing.Visible = true;
        if (conn.State == System.Data.ConnectionState.Closed)
        {
            conn.Open();
        }

        sql = "JCT_OPS_SIZING_COMPARISON";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtSizingFrom.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtSizingTo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar,10).Value = txtSortNo.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdSizing.DataSource = ds.Tables[0];
        grdSizing.DataBind();
    }

    protected void grdSizing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            pnlSizing.Visible = true;
            String SortNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SortNo"));
            String IssueNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IssueNo"));
            String Split = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Split"));
            String SizeMtrs = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SizeMtrs"));
            String Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status"));
            char[] sort = new char[SortNo.Length];
            string sortno;
            if (SortNo.Contains(" "))
            {
                SortNo.Replace(" ", string.Empty);
                int i = 0;

                foreach (char c in SortNo.ToCharArray())
                {
                    if (Char.IsDigit(c))
                    {
                        sort[i] = c;
                        i++;
                    }
                }

                sortno = new string(sort);
                sortno = sortno.Replace("\0", string.Empty);
            }
            else
            {
                sortno = SortNo;
            }



            GridView GridViewNested = (GridView)e.Row.FindControl("nestedGridView");

            sql = "JCT_OPS_SIZING_COMPARISON_DETAIL";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SORTNO", SqlDbType.VarChar, 10).Value = sortno;
            cmd.Parameters.Add("@ISSUENO", SqlDbType.VarChar, 15).Value = IssueNo;
            cmd.Parameters.Add("@SPLIT", SqlDbType.VarChar, 10).Value = Split;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridViewNested.DataSource = ds.Tables[0];
            GridViewNested.DataBind();
            //SqlDataSource sqlDataSourceNestedGrid = new SqlDataSource();
            //sqlDataSourceNestedGrid.ConnectionString = ConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
            //sqlDataSourceNestedGrid.SelectCommand = "JCT_OPS_SIZING_COMPARISON_DETAIL";// '" + sortno + "' ,'" + IssueNo + "','" + Split + "'";
            //sqlDataSourceNestedGrid.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            //sqlDataSourceNestedGrid.SelectParameters.Add("@SORTNO", sortno);
            //sqlDataSourceNestedGrid.SelectParameters.Add("@ISSUENO", IssueNo);
            //sqlDataSourceNestedGrid.SelectParameters.Add("@SPLIT", Split);
            
            //GridViewNested.DataSource = sqlDataSourceNestedGrid.Select(DataSourceSelectArguments.Empty);
            //GridViewNested.DataBind();
        }
    }
}