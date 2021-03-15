using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_Jct_payroll_PortalMenuRights : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Rigths();
            enabledisss();
            FetchMYRecords();
        }
    }

    public void enabledisss()
    {
        if (rblChoices.SelectedValue.ToString() == "RoleBased")
        {
            ddlplant.Visible = true;
            txtEmployee.Visible = false;
            lblrole.Visible = true;
            lblemployeename.Visible = false;
        }
        else
        {
            ddlplant.Visible = false;
            txtEmployee.Visible = true;
            lblemployeename.Visible = true;
            lblrole.Visible = false;
        }
    }

    public void Rigths()
    {
        string sql = "Jct_Payroll_PortalMenuRights";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.Items.Clear();
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "Role_Descr";
        ddlplant.DataValueField = "role";
        ddlplant.DataBind();
    }

    protected void chksel_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox sel = (CheckBox)grdDetail.HeaderRow.FindControl("chksel");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkbx");

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

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkall = (CheckBox)grdDetail.HeaderRow.FindControl("chkall");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");

            if (cb != null)
            {

                if (chkall.Checked)
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

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {
            SaveRecord();
            FetchMYRecords();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
            FetchMYRecords();
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void SaveRecord()
    {
        string OK = string.Empty;
        foreach (GridViewRow gvRow1 in grdDetail.Rows)
        {
            CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chk");
            if (chkRemove1.Checked == true)
            {
                OK = "OK";
            }
        }
        if (OK == "OK")
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                string mytype = gvRow.Cells[1].Text;
                CheckBox chkRemove10 = (CheckBox)gvRow.FindControl("chk");
                if (chkRemove10.Checked == true)
                {     
                    SqlCommand cmd = new SqlCommand("Jct_Payroll_PortalMenuRights_InsertRole", obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Param", SqlDbType.VarChar, 10).Value = rblChoices.SelectedItem.Text;
                    if (ddlplant.Visible == true)
                    {
                        cmd.Parameters.Add("@role", SqlDbType.Int).Value = ddlplant.SelectedItem.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@UName", SqlDbType.VarChar, 10).Value = txtEmployee.Text;                    
                    }                    
                    cmd.Parameters.Add("@MenuName", SqlDbType.VarChar, 50).Value = mytype;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        else
        {
            string script2 = "alert('Please Select The Record First.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
        string script10 = "alert('Role Granted Successfully..');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script10, true);
        return;       
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_payroll_PortalMenuRights.aspx");
    }
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchMYRecords();
    }

    public void FetchMYRecords()
    {
        try
        {
            string sql = "Jct_Payroll_PortalMenuRights_RoleRecords";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            if (ddlplant.Visible == true)
            {
                cmd.Parameters.Add("@Param", SqlDbType.VarChar, 10).Value = rblChoices.SelectedItem.Text;
                cmd.Parameters.Add("@role", SqlDbType.VarChar, 50).Value = ddlplant.SelectedItem.Value;
            }
            else
            {
                cmd.Parameters.Add("@Param", SqlDbType.VarChar, 10).Value = rblChoices.SelectedItem.Text;
                cmd.Parameters.Add("@role", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
            }
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void rblChoices_SelectedIndexChanged(object sender, EventArgs e)
    {
        enabledisss();
        grdDetail.DataSource = null;
        grdDetail.DataBind();
        txtEmployee.Text = "";
        Rigths();
    }
}