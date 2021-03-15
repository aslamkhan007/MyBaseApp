using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Drawing;

public partial class Payroll_Jct_Payroll_LostLien : System.Web.UI.Page
{
    Connection obj = new Connection();
    string qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ddlReporttype.SelectedItem.Value == "LostLien")
            {
                txtfromdate.Visible = true;
                txttodate.Visible = false;
            }
            else if (ddlReporttype.SelectedItem.Value == "Restore")
            {
                txtfromdate.Visible = false;
                txttodate.Visible = true;
            }
        }
    }


    protected void lnkSave_Click(object sender, EventArgs e)
    {        
        try
        {
            qry = "Jct_Payroll_LostLien_Restore_Apply";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Action", SqlDbType.VarChar, 10).Value = ddlReporttype.SelectedItem.Text;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtCardNo.Text;

            if (txtfromdate.Visible == true)
            {
                cmd.Parameters.Add("@MarkingDt", SqlDbType.DateTime).Value = txtfromdate.Text; 
            }

            if (txttodate.Visible == true)
            {
                cmd.Parameters.Add("@RestoreDt", SqlDbType.DateTime).Value = txttodate.Text;
            }

            cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 40).Value = TxtOvertimeReason.Text;           

            cmd.ExecuteNonQuery();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            EmptyControls();        
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }        
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_LostLien.aspx");
    }  

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {  
    }

    public void EmptyControls()
    {
        lblname.Text = "";
        lblDesignation.Text = "";
        lbldepartment.Text = "";        
    }

    protected void txtCardNo_TextChanged(object sender, EventArgs e)
    {        
        try
        {           
            string sqlqry = "Jct_Payroll_LostLien_Restore_Fetch";
            SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Action", SqlDbType.VarChar, 10).Value =  ddlReporttype.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtCardNo.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    lblname.Text = dr["EmployeeName"].ToString();
                    lblDesignation.Text = dr["FatherHusbandName"].ToString();
                    lbldepartment.Text = dr["Department"].ToString();
                }
            }
            dr.Close();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }       
    }
  
    protected void ddlReporttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReporttype.SelectedItem.Value == "LostLien")
        {
            txtfromdate.Visible = true;
            txttodate.Visible = false;
        }
        else if (ddlReporttype.SelectedItem.Value == "Restore")
        {
            txtfromdate.Visible = false;
            txttodate.Visible = true;
        }
    }

    protected void lnkreset0_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_LostLien_Report.aspx");
        
    }
}