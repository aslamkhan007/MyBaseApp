using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_po_gen_yarn : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("jct_ops_yarn_selct_for_po", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = lbid.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        }

    }
    protected void lnksave_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow rw in grdDetail.Rows)
        {
            TextBox txt1 = (TextBox)rw.FindControl("txtpo");
            if (txt1.Text != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("jct_ops_yarn_po_genrate", con);

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = rw.Cells[1].Text; 
                cmd.Parameters.Add("@po_no", SqlDbType.VarChar, 30).Value = txt1.Text;
                cmd.Parameters.Add("@po_createdby", SqlDbType.VarChar, 30).Value = Session["Empcode"];

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }

    protected void lnkclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("po_gen_yarn.aspx");
        
        //foreach (GridViewRow rw in grdDetail.Rows)
        //{

        //    TextBox txt1 = (TextBox)rw.FindControl("txtpo");
        //    if (txt1.Text != string.Empty)
        //    {
        //        txt1.Text = string.Empty;
        //    }

        //}

    }
}