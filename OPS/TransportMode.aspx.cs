using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class exportdoc_TransportMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblSrNo.Visible = false;
        fillgridview();  
    }
    protected void grdTransportMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //txtSrNo.Text = GridView1.SelectedRow.Cells[1].Text;
            lblserialno.Text = grdTransportMode.SelectedRow.Cells[1].Text;
            txtModeCode.Text = grdTransportMode.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtDescription.Text = grdTransportMode.SelectedRow.Cells[3].Text;
            txtTransModeCode.Text = grdTransportMode.SelectedRow.Cells[4].Text;
            txteffefrom.Text = grdTransportMode.SelectedRow.Cells[5].Text;
            txtEfecTo.Text = grdTransportMode.SelectedRow.Cells[6].Text;
            txtModeCode.Enabled = true;
            lblSrNo.Enabled = true;
            lblSrNo.Visible = true;
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }      
    }
    protected void lnkbtnEditUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "JCT_ExpDoc_TransportMode_Update";
            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Trans_Code", SqlDbType.VarChar).Value = txtModeCode.Text;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text;
            cmd.Parameters.Add("@Transmodecode", SqlDbType.VarChar).Value = txtTransModeCode.Text;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@ModifiedIp", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@Srno", SqlDbType.Int).Value = Convert.ToInt16(lblserialno.Text);
            cmd.Parameters.Add("@EffFrom", SqlDbType.DateTime).Value = txteffefrom.Text;
            cmd.Parameters.Add("@EffTo", SqlDbType.DateTime).Value = txtEfecTo.Text;
            cmd.ExecuteNonQuery();
            string strqry1 = "JCT_ExpDoc_TransportMode_Select";
            cmd = new SqlCommand(strqry1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdTransportMode.DataSource = ds;
            grdTransportMode.DataBind();
            string script = "alert('Record Successfully Updated');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            con.Close();
            //txtSrNo.Text = "";
            lblserialno.Text = "";
            txtModeCode.Text = "";
            txtDescription.Text = "";
            txtTransModeCode.Text = "";
            txteffefrom.Text = "";
            txtEfecTo.Text = "";
            txtModeCode.Enabled = true;
        }

        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "JCT_ExpDoc_TransportMode_Insert";
            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Trans_Code", SqlDbType.VarChar).Value = txtModeCode.Text;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text;
            cmd.Parameters.Add("@Transmodecode", SqlDbType.VarChar).Value = txtTransModeCode.Text;
            cmd.Parameters.Add("@EffFrom", SqlDbType.DateTime).Value = txteffefrom.Text;
            cmd.Parameters.Add("@EffTo", SqlDbType.DateTime).Value = txtEfecTo.Text;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@CreatedIp", SqlDbType.VarChar).Value = address;
            cmd.ExecuteNonQuery();
            string strqry1 = "JCT_ExpDoc_TransportMode_Select";
            cmd = new SqlCommand(strqry1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdTransportMode.DataSource = ds;
            grdTransportMode.DataBind();
            string script = "alert('Record Successfully Inserted');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            con.Close();
            //txtSrNo.Text = "";    
            txtModeCode.Text = "";
            txtDescription.Text = "";
            txtTransModeCode.Text = "";
            txteffefrom.Text = "";
            txtEfecTo.Text = "";
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
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            string strqry = "JCT_ExpDoc_TransportMode_Select";
            SqlCommand cmd = new SqlCommand(strqry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdTransportMode.DataSource = ds;
            grdTransportMode.DataBind();
            con.Close();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkBtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "JCT_ExpDoc_TransportMode_Delete";
            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Srno", SqlDbType.Int).Value = Convert.ToInt16(lblserialno.Text);
            cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@DeletedIp", SqlDbType.VarChar).Value = address;
            cmd.ExecuteNonQuery();
            string strqry1 = "JCT_ExpDoc_TransportMode_Select";
            cmd = new SqlCommand(strqry1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdTransportMode.DataSource = ds;
            grdTransportMode.DataBind();
            string script = "alert('Record Successfully Deleted');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            con.Close();
            //txtSrNo.Text = "";
            lblserialno.Text = "";
            txtModeCode.Text = "";
            txtDescription.Text = "";
            txtTransModeCode.Text = "";
            txteffefrom.Text = "";
            txtEfecTo.Text = "";
            txtModeCode.Enabled = true;
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkbtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("TransportMode.aspx");
    }
}