using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_CustomerProspectDetail : System.Web.UI.Page
{
    string sql;
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Insert into JCT_OPS_PROSPECT_DETAIL (cust_name,address,city,state,country,concerned_person ,contact_no,product_category,status) values " +
                                                      " (@cust_name,@address,@city,@state,@country,@concerned_person,@contact_no,@product_category,@status) ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@cust_name", SqlDbType.VarChar, 50).Value = txtName.Text;
            cmd.Parameters.Add("@address", SqlDbType.VarChar, 500).Value = txtAddress.Text;
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = txtCity.Text;
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = txtState.Text;
            cmd.Parameters.Add("@country", SqlDbType.VarChar, 50).Value = txtCountry.Text;
            cmd.Parameters.Add("@concerned_person", SqlDbType.Char, 100).Value = txtConcPerson.Text;
            cmd.Parameters.Add("@contact_no", SqlDbType.VarChar, 50).Value = txtContactNo.Text;
            cmd.Parameters.Add("@product_category", SqlDbType.VarChar, 50).Value = txtProductCategory.Text;
            cmd.Parameters.Add("@status", SqlDbType.Char).Value = 'A';
            cmd.ExecuteNonQuery();
            FMsg.CssClass = "errormsg";
            FMsg.Message = "Request for Customer generated successfully..!!";
            FMsg.Display();
            String script = "alert('Request for Customer generated successfully..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            FMsg.CssClass = "errormsg";
            FMsg.Message = "Record not added ..!!";
            FMsg.Display();
        }
        
    }
}