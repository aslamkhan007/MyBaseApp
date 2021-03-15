using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class OPS_Jct_Ops_InputUserData : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            citylist();
            Districtlist();
            bindgrid();
        }
    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "jct_employee_address_Insert";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = txtadd1.Text;
            cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = txtadd2.Text;
            cmd.Parameters.Add("@Address3", SqlDbType.VarChar, 50).Value = txtadd3.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = ddlCity.SelectedItem.Text;
            cmd.Parameters.Add("@District", SqlDbType.VarChar, 25).Value = ddlDistrict.SelectedItem.Text;            
            cmd.Parameters.Add("@Pincode", SqlDbType.VarChar, 8).Value = txtPin.Text;
            cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@CreatedBY", SqlDbType.VarChar, 50).Value = Session["EmpCode"];            
            //cmd.Parameters.Add("@srno", SqlDbType.Int).Value = 0;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);            
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "jct_employee_address_Update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = txtadd1.Text;
            cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = txtadd2.Text;
            cmd.Parameters.Add("@Address3", SqlDbType.VarChar, 50).Value = txtadd3.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = ddlCity.SelectedItem.Text;
            cmd.Parameters.Add("@District", SqlDbType.VarChar, 25).Value = ddlDistrict.SelectedItem.Text;            
            cmd.Parameters.Add("@Pincode", SqlDbType.VarChar, 8).Value = txtPin.Text;
            cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@CreatedBY", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = lbsrid.Text;
            //cmd.Parameters.Add("@srno", SqlDbType.Int).Value = 0;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record Updated.!!');";
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

        txtadd1.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        txtadd2.Text = grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
        txtadd3.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByText(grdDetail.SelectedRow.Cells[4].Text));
        ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByText(grdDetail.SelectedRow.Cells[5].Text));        
        txtPin.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        lbsrid.Text = grdDetail.SelectedRow.Cells[10].Text;        
        lblSrNo.Visible = true;
        lbsrid.Visible = true;        
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Ops_InputUserData.aspx");
    }

    private void bindgrid()
    {
        //string qry = "SELECT Address1 ,Address2 ,Address3 ,City ,state ,Pincode ,HostID ,CreatedBY ,createdDate,srno   FROM jct_employee_address WHERE STATUS = 'A' and  empcode ='" + Session["EmpCode"] +"'";
        string qry = "jct_employee_address_Fetch";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;

    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        citylist();
        Districtlist();
    }

    private void citylist()
    {
        SqlCommand cmd = new SqlCommand("SELECT  DISTINCT City FROM JCTGEN..JCT_EPOR_STATE_MASTER", obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlCity.DataSource = ds;
        ddlCity.DataTextField = "City";
        ddlCity.DataValueField = "City";
        ddlCity.DataBind();
    }

    private void Districtlist()
    {
        SqlCommand cmd = new SqlCommand("SELECT  DISTINCT City FROM JCTGEN..JCT_EPOR_STATE_MASTER", obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlDistrict.DataSource = ds;
        ddlDistrict.DataTextField = "City";
        ddlDistrict.DataValueField = "City";
        ddlDistrict.DataBind();
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }

    private void ClearTextBoxes()
    {      
        txtadd3.Text = "";             
        ddlCity.ClearSelection();       
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }
}