using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_exchangerate : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
    Functions objfun = new Functions();
    Connection obj = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataAdapter da = new SqlDataAdapter("select currency_code,currency_desc, exchange_rate,eff_from,eff_to from jct_ops_exchange_rate where status='A' ", obj.Connection());

            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        }
    }
    protected void add_Click(object sender, EventArgs e)
    {
        if (txteff_from.Text == "" || txteff_to.Text == "" || txtexchangerate.Text == "" || txtcurrencydesc.Text == "" || ddlcurrencycode.SelectedIndex==0) 
        {
        }
        {

            SqlCommand cmd = new SqlCommand("jct_exchange_rate_insert", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@currency_code", SqlDbType.VarChar, 5).Value = ddlcurrencycode.SelectedItem.Text;
            cmd.Parameters.Add("@currency_desc", SqlDbType.VarChar, 30).Value = ddlcurrencycode.SelectedItem.Value;
            cmd.Parameters.Add("@exchange_rate", SqlDbType.Decimal).Value = txtexchangerate.Text;
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = txteff_from.Text;
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = txteff_to.Text;
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
           // con.Open();
            cmd.ExecuteNonQuery();
           // con.Close();
            select();
        
        }

    }
    protected void ddlcurrencycode_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtcurrencydesc.Text = ddlcurrencycode.SelectedItem.Value;

    }
    protected void txteff_from_TextChanged(object sender, EventArgs e)
    {
  

        txteff_to.Text = objfun.FetchValue("Select dateadd(yy,4,'" + txteff_from.Text + "')").ToString();


    }

    protected void lnkClear_Click(object sender, EventArgs e)
    {
        txtcurrencydesc.Text = " ";
        txtexchangerate.Text = " ";
        txteff_from.Text = " ";
        txteff_to.Text = " ";
        txtexchangerate.Text = " ";
        ddlcurrencycode.SelectedIndex = 0;
    }
    private void select()
    {
        SqlDataAdapter da = new SqlDataAdapter("select currency_code,currency_desc,exchange_rate ,eff_from,eff_to from jct_ops_exchange_rate where status='A'", obj.Connection());

        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }



}



