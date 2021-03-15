using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_jct_workercell_approval : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=misdev;Initial Catalog=workwages;User ID=itgrp ;password=power");
  
    string sql = string.Empty;

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string requestid;
    ////DateTime efffrom ;
    string efffrom;
    string effto; 
    string jctsr_no;
    protected void Page_Load(object sender, EventArgs e)
    {                    
           requestid = Request.QueryString["requestid"];           
           efffrom = Request.QueryString["fd"];
           effto = Request.QueryString["td"];
           con.Open();

           //string sql = "Jct_Worker_Cell_Approval";
           //SqlCommand cmd = new SqlCommand(sql, con);
           //cmd.CommandType = CommandType.StoredProcedure;
           //cmd.Parameters.Add("@Empcode", SqlDbType.Char, 6).Value = requestid;
           ////cmd.Parameters.Add("@From_date", SqlDbType.Char, 50).Value = efffrom;
           ////cmd.Parameters.Add("@TO_date", SqlDbType.Char, 50).Value = effto;
           //cmd.ExecuteNonQuery();



           BindLables();
           con.Close();           
    }

    public void BindLables()
    {
        SqlCommand cmd = new SqlCommand("Jct_Worker_Cell_Approval_Select",con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Empcode", SqlDbType.Char, 6).Value = requestid;
        //cmd.Parameters.Add("@From_date", SqlDbType.Char, 50).Value = efffrom;
        //cmd.Parameters.Add("@TO_date", SqlDbType.Char, 50).Value = effto;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {

                lblEmpcode.Text = dr["Employee_code"].ToString();
                lblTokenNo.Text = dr["Token_No"].ToString();
                lblDeptcode.Text = dr["Department_code"].ToString();
                lblEnpname.Text = dr["Employee_name"].ToString();
                lblFatherName.Text = dr["Father_name"].ToString();
                lblDesgCode.Text = dr["designation_code"].ToString();
                lblVaildFrom.Text = dr["Vaild_from"].ToString();
                lblVaildTo.Text = dr["Vaild_to"].ToString();
                lblShift.Text = dr["Shift"].ToString();                
            }
                   
        }
        else
        {
            string script = "alert('Record Not Found.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }     
}