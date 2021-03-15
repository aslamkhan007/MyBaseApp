using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class EmpGateway_ApplyCompensatoryLeave : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)

            if (Session["Empcode"] == "")
            {
                Response.Redirect("~/Login.aspx");
            }

        SqlCommand cmd = new SqlCommand("select a.empname, a.desg ,b.deptname,a.catg from jct_empmast_base a join deptmast b on a.deptcode=b.deptcode where a.empcode='" + Session["Empcode"] + "' and  a.catg in ('MM3' , '001' , '002' , 'JM1' , 'JM2' , 'MM2') ", con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            txtemp.Text = dr[0].ToString();
            txtdesig.Text = dr["desg"].ToString();
            txtdept.Text = dr["deptname"].ToString();
        }
        else
        {
            lnkapply.Enabled = false;
            string script = "alert('You are not allowed to Apply Compensatory Leave!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        dr.Close();
        con.Close();
    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            gencode();
            SqlCommand cmd = new SqlCommand("jct_empg_compensatory_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();

            cmd.Parameters.Add("@leave", SqlDbType.VarChar, 50).Value = ddlnature.Text;

            cmd.Parameters.Add("@leaveType", SqlDbType.VarChar, 50).Value = ddltype.Text;

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(ViewState["ID"]);

            cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 10).Value = Session["Empcode"];

            cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
            cmd.Parameters.Add("@Dept", SqlDbType.VarChar,100).Value = txtdept.Text;

            cmd.Parameters.Add("@leaveDate", SqlDbType.DateTime).Value = txtdate.Text;
            cmd.Parameters.Add("@desig", SqlDbType.VarChar,100).Value = txtdesig.Text;
            cmd.Parameters.Add("@empname", SqlDbType.VarChar, 100).Value = txtemp.Text;
            cmd.Parameters.Add("@days", SqlDbType.VarChar, 10).Value = txtdays.Text;
            cmd.Parameters.Add("@purpose", SqlDbType.VarChar, 100).Value = txtpurpose.Text;

            cmd.ExecuteNonQuery();

            con.Close();

            string script = "alert('Leave Applied Successfully.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }



    }

    private void gencode()
    {
        string str;

        con.Open();

        SqlCommand cmd = new SqlCommand("select max(isnull(id,100)) from jct_empg_compensatory_leave", con);
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["ID"] = "100";
                    ViewState["ID"] = ViewState["ID"];
                }
                else
                {
                    ViewState["ID"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["ID"] = ViewState["ID"];
                }
            }

        }

        dr.Close();
        con.Close();
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedItem.Text == "Full day")
        {
            txtdays.Text = "1";
        }
        if (ddltype.SelectedItem.Text == "1st Half")
        {
            txtdays.Text = "0.5";
        }
        if (ddltype.SelectedItem.Text == "2nd Half")
        {
            txtdays.Text = "0.5";
        }
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplyCompensatoryLeave.aspx");
    }
}