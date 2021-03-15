using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_Criminal_Record : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdDetail.Visible = true;
        }
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow rw in grdDetail.Rows)
            {
                TextBox txt1 = (TextBox)rw.FindControl("txtAnswer");

                        sql = "jct_payroll_employee_criminal_detail_insert";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        //con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@employeecode", SqlDbType.VarChar, 10).Value =txtEmpCode.Text;
                        cmd.Parameters.Add("@question", SqlDbType.Int).Value = Convert.ToInt32(rw.Cells[0].Text);
                        cmd.Parameters.Add("@answer", SqlDbType.VarChar,80).Value = txt1.Text;
                        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                        cmd.ExecuteNonQuery();
                        string script = "alert('Record  Saved.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
            }

        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {

    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
         Session["ViewState"] = null; 
        Response.Redirect("Jct_Payroll_Criminal_Record.aspx");
    }

    public void CriminalRecord()
    {
        try
        {         
            sql = "Jct_Payroll_CriminalRecord_Fetch";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Employeecode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;


            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

            //DataTable table = new DataTable();
            //table.Load(cmd.ExecuteReader());
            //GridView1.DataSource = table;
            //GridView1.DataBind();
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    //protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    //{
    //   
    //}


    //protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        int SrNo =  Convert.ToInt32(e.Row.Cells[1].Text);
    //        string Questions = e.Row.Cells[2].Text;
    //        TextBox txt1 = (TextBox)e.Row.FindControl("txtAnswer");

    //        string sql = "SELECT SrNo,Questions FROM jctdev4.dbo.Jct_Payroll_Criminal_Questions WHERE SrNo between '1'and '10'";
    //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        if (dr.HasRows)
    //        {
    //            while (dr.Read())
    //            {

    //                //txt1.Text = dr["answer"].ToString();


    //            }
    //        }
    //        dr.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        string script = "alert(''" + ex.Message + "'');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }
    //}
    protected void txtEmpCode_TextChanged1(object sender, EventArgs e)
    {
        CriminalRecord();
    }
}