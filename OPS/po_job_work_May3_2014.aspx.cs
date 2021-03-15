using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class OPS_po_job_work : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Empcode"] == "")
            {
                Response.Redirect("~/Login.aspx");

            }
        }
        {
            SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_po_select", con);
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

//        ----------- check purchase order ----validation pending

//select * from miserp.pomdb.dbo.pur_po_header where po_date >= '2014-03-01 00:00:00.000' and  left(po_no,2) = 'HF'  

//----------- check gatepass 

//select * from jctdev..jct_gatepass_header where gatepass_date >= '2014-04-01 00:00:00.000'
//and left(gatepass_no,3) = 'RGP' and gatepass_status = 'A'

        foreach (GridViewRow rw in grdDetail.Rows)
        {
             
                CheckBox chk1 = (CheckBox)rw.FindControl("chk");

                if (chk1.Checked)
                {
                    TextBox txt1 = (TextBox)rw.FindControl("txtpo");
                    TextBox txt2 = (TextBox)rw.FindControl("txtgatepass");
                    if (txt1.Text != string.Empty)
                    {
                        SqlCommand cmd = new SqlCommand("jct_ops_outsourced_job_work_po_gen", con);

                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@reqid", SqlDbType.VarChar, 10).Value = rw.Cells[1].Text;
                        cmd.Parameters.Add("@po_no", SqlDbType.VarChar, 30).Value = txt1.Text;
                        cmd.Parameters.Add("@gatepassno", SqlDbType.VarChar, 50).Value = txt2.Text;
                        cmd.Parameters.Add("@po_enterby", SqlDbType.VarChar, 30).Value = "S-13823"; //Session["Empcode"];

                        cmd.ExecuteNonQuery();
                        con.Close();
                        string script2 = "alert(' record saved sucesfully.!! ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                    }
                }
        }

    }
    protected void lnkclear_Click(object sender, EventArgs e)
    {

    }
   
    protected void chksel_CheckedChanged1(object sender, EventArgs e)
    {
        CheckBox sel = (CheckBox)grdDetail.HeaderRow.FindControl("chksel");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");



            if (cb != null)
            {

                if (sel.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
    }
}