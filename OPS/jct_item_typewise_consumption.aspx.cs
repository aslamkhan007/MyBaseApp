using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class OPS_jct_item_typewise_consumption : System.Web.UI.Page
{
    string qry = ConfigurationManager.ConnectionStrings["POMCoonectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkbtnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = true;
      
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "jct_item_type_wise_consumption_rpt";

            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@company_code", SqlDbType.VarChar, 20).Value = "JCT00LTD";
            cmd.Parameters.Add("@locn_no", SqlDbType.VarChar, 16).Value = "PHG";
            cmd.Parameters.Add("@Lang_id", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@from_date", SqlDbType.DateTime).Value = txtFromdate.Text;
            cmd.Parameters.Add("@to_date", SqlDbType.DateTime).Value = txtTodate.Text;
            cmd.Parameters.Add("@item_type", SqlDbType.VarChar).Value = txtitemtype.Text;
            //cmd.ExecuteNonQuery();                       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grdfreezedate.DataSource = ds;
            Grdfreezedate.DataBind();
            con.Close();
            //lnkbtnexcel.Visible = true;
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
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "jct_item_type_wise_consumption_rpt";

            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@company_code", SqlDbType.VarChar, 20).Value = "JCT00LTD";
            cmd.Parameters.Add("@locn_no", SqlDbType.VarChar, 16).Value = "PHG";
            cmd.Parameters.Add("@Lang_id", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@from_date", SqlDbType.DateTime).Value = txtFromdate.Text;
            cmd.Parameters.Add("@to_date", SqlDbType.DateTime).Value = txtTodate.Text;
            cmd.Parameters.Add("@item_type", SqlDbType.VarChar).Value = txtitemtype.Text;
            //cmd.ExecuteNonQuery();                       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grdfreezedate.DataSource = ds;
            Grdfreezedate.DataBind();
            con.Close();
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
          
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "jct_item_type_wise_consumption_rpt";

            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@company_code", SqlDbType.VarChar, 20).Value = "JCT00LTD";
            cmd.Parameters.Add("@locn_no", SqlDbType.VarChar, 16).Value = "PHG";
            cmd.Parameters.Add("@Lang_id", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@from_date", SqlDbType.DateTime).Value = txtFromdate.Text;
            cmd.Parameters.Add("@to_date", SqlDbType.DateTime).Value = txtTodate.Text;
            cmd.Parameters.Add("@item_type", SqlDbType.VarChar).Value = txtitemtype.Text;
            //cmd.ExecuteNonQuery();                       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grdfreezedate.DataSource = ds;
            Grdfreezedate.DataBind();
            //con.Close();
            DataTable dt = ds.Tables[0];

            string attachment = "attachment; ItemWiseConsumption.xls";
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

            con.Close();
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