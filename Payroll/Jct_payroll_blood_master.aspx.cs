using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class Payroll_Jct_payroll_blood_master : System.Web.UI.Page
{
    Connection obj = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
           
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
     
            GenerateCode();
            //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string  qry = "JCT_payroll_blood_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Group_code", SqlDbType.VarChar, 10).Value = ViewState["GrpCode"];
            cmd.Parameters.Add("@Group_name", SqlDbType.VarChar, 20).Value = txtGroupName.Text;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = "Add";
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lblGroupCode.Visible = true;
            //lbcodeid.Text = ViewState["locCode"];
            lbcodeid.Visible = true;
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    /*
           
          */

    private void bindgrid()
    {
        //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
        //SqlConnection con = new SqlConnection(qry);
        //con.Open();
        string  qry = " SELECT Group_code , Group_name , created_by  FROM JCT_payroll_blood_master WHERE  status='A'";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        //con.Close();
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string  qry = "JCT_payroll_blood_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Group_code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Group_name", SqlDbType.VarChar, 20).Value = txtGroupName.Text;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = "upd";
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record  Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    /*


     */
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string qry = "JCT_payroll_blood_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Group_code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Group_name", SqlDbType.VarChar, 20).Value = txtGroupName.Text;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = "Del";
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbcodeid.Text = grdDetail.SelectedRow.Cells[1].Text;
        txtGroupName.Text = grdDetail.SelectedRow.Cells[2].Text;
        lbcodeid.Visible = true;
        lblGroupCode.Visible = true;
    }

    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;
        //string qry = ConfigurationManager.ConnectionStrings["test"].ToString();
        ////SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        //SqlConnection con = new SqlConnection(qry);
        //con.Open();

        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(Group_code),CHARINDEX('-',max(Group_code))+1,len(max(Group_code))+3) from JCT_payroll_blood_master ", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["GrpCode"] = "100";
                    ViewState["GrpCode"] = "GRP-" + ViewState["GrpCode"];
                }
                else
                {
                    ViewState["GrpCode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["GrpCode"] = "GRP-" + ViewState["GrpCode"];
                }
            }

        }

        dr.Close();
        //con.Close();

        #endregion
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_payroll_blood_master.aspx");
    }
}