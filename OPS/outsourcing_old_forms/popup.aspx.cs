using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_popup : System.Web.UI.Page
{

    SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["test"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string reqid = string.Empty;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        reqid = Request.QueryString["Reqid"];
        if (IsNumeric(reqid.ToString()))
        {
            cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON_FAB", conjctgen);
            cmd.CommandType = CommandType.StoredProcedure;
            conjctgen.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            grddetail.DataSource = ds.Tables[0];
            grddetail.DataBind();
        }
        else
        {
            cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON", conjctgen);
            cmd.CommandType = CommandType.StoredProcedure;
            conjctgen.Open();
            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = reqid;

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            grddetail.DataSource = ds.Tables[0];
            grddetail.DataBind();
        }
    }

    public static System.Boolean IsNumeric(System.Object Expression)
    {
        if (Expression == null || Expression is DateTime)
            return false;

        if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
            return true;

        try
        {
            if (Expression is string)
                Double.Parse(Expression as string);
            else
                Double.Parse(Expression.ToString());
            return true;
        }
        catch { } // just dismiss errors but return false
        return false;
    }
}



