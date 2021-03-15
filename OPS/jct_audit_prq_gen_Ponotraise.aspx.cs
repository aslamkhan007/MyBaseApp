using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_jct_audit_prq_gen_Ponotraise : System.Web.UI.Page
{
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkbtnFetch_Click(object sender, EventArgs e)
    {

        try
        {
            Panel1.Visible = true;
            //string qry = ConfigurationManager.ConnectionStrings["testerp"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "jct_audit_prq_gen_Ponotraise";
            SqlCommand cmd = new SqlCommand(strqry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@company_code", SqlDbType.VarChar, 20).Value = "JCT00LTD";
            cmd.Parameters.Add("@locn_no", SqlDbType.VarChar, 16).Value = "PHG";
            cmd.Parameters.Add("@Lang_id", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtFromdate.Text;
            cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txtTodate.Text;
           
            //cmd.ExecuteNonQuery();                       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grdfreezedate.DataSource = ds;
            Grdfreezedate.DataBind();
            //con.Close();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    public void fillgridview()
    {
        try
        {
            //string qry = ConfigurationManager.ConnectionStrings["testerp"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "jct_audit_prq_gen_Ponotraise";
            SqlCommand cmd = new SqlCommand(strqry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@company_code", SqlDbType.VarChar, 20).Value = "JCT00LTD";
            cmd.Parameters.Add("@locn_no", SqlDbType.VarChar, 16).Value = "PHG";
            cmd.Parameters.Add("@Lang_id", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtFromdate.Text;
            cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txtTodate.Text;
            //cmd.ExecuteNonQuery();                       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grdfreezedate.DataSource = ds;
            Grdfreezedate.DataBind();
            //con.Close();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkbtnexcel_Click(object sender, EventArgs e)
    {
        try
        {
            //string qry = ConfigurationManager.ConnectionStrings["testerp"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "jct_audit_prq_gen_Ponotraise";
            SqlCommand cmd = new SqlCommand(strqry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@company_code", SqlDbType.VarChar, 20).Value = "JCT00LTD";
            cmd.Parameters.Add("@locn_no", SqlDbType.VarChar, 16).Value = "PHG";
            cmd.Parameters.Add("@Lang_id", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtFromdate.Text;
            cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txtTodate.Text;
  
            //cmd.ExecuteNonQuery();                       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grdfreezedate.DataSource = ds;
            Grdfreezedate.DataBind();
            //con.Close();
            DataTable dt = ds.Tables[0];

            string attachment = "attachment; Prq Generated Po Not Raised.xls";
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

            //con.Close();
        }
        //catch
        //{
        //    string script = "alert('Unable to fetch data!');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //}

        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

}