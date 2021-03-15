using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_payroll_Contact_Information : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string cardno;
    string empcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cardno = Session["Empcode"].ToString();                        
            try
            {
                string sql = "jct_payroll_Contact_InfoFetch";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = Session["Empcode"].ToString(); 
                //cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = "9000000334";
                
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {                        
                        TxtPri_Mobile.Text = dr["PrimaryMobileNo"].ToString();
                        txtlandline.Text = dr["PrimaryLandlineNo"].ToString();
                        TxtSecondaryLandline.Text = dr["SecondaryLandlineNo"].ToString();
                        TxtEmailID.Text = dr["EmailID"].ToString();
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                string script = "alert(''" + ex.Message + "'');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_payroll_Contact_InfoUpdate";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["Empcode"].ToString();
            //cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = "9000000334";
            cmd.Parameters.Add("@PrimaryMobileNo", SqlDbType.VarChar, 12).Value = TxtPri_Mobile.Text;
            cmd.Parameters.Add("@PrimaryLandlineNo", SqlDbType.VarChar, 12).Value = txtlandline.Text;
            cmd.Parameters.Add("@SecondaryLandlineNo", SqlDbType.VarChar, 12).Value = TxtSecondaryLandline.Text;
            cmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 35).Value = TxtEmailID.Text;
            cmd.ExecuteNonQuery();
            //bindgrid();
            string script = "alert('Record  Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }       
    protected void lnkreset_Click(object sender, EventArgs e)
    {
    }   
}