using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
public partial class Payroll_JCT_Payroll_PF_OpeningBalance : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string cardno;
    string empcode;
    string FlagCheck = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();
            Locationbind();
        }
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
    public void Plantbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "Plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();
    }
    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
    }
    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Current_FIYear";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodate.Text = dr["FIYear"].ToString();
            }
            dr.Close();
        }
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecord();
            Panel4.Visible = true;
            Panel1.Visible = true;
            lnkapply.Enabled = true;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("JCT_Payroll_PF_OpeningBalance_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@FYPeriod", SqlDbType.VarChar, 10).Value = txttodate.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
        /*         
         



         */
        if (dt.Rows.Count == 0)
        {
            string script = "alert('No Record Found.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                TextBox txtNominee = (TextBox)gvRow.FindControl("txtNominee");
                TextBox txtDtFmlyPen = (TextBox)gvRow.FindControl("txtDtFmlyPen");
                TextBox txtDtPfjoin = (TextBox)gvRow.FindControl("txtDtPfjoin");
                TextBox txtDtPfTaken = (TextBox)gvRow.FindControl("txtDtPfTaken");
                TextBox txtOwnPFAmt = (TextBox)gvRow.FindControl("txtOwnPFAmt");
                TextBox txtEmpPFAmt = (TextBox)gvRow.FindControl("txtEmpPFAmt");
                TextBox txtOwnIntAmt = (TextBox)gvRow.FindControl("txtOwnIntAmt");
                TextBox txtEMPIntAmt = (TextBox)gvRow.FindControl("txtEMPIntAmt");
                TextBox txtVPFAmt = (TextBox)gvRow.FindControl("txtVPFAmt");
                TextBox txtVPFInt = (TextBox)gvRow.FindControl("txtVPFInt");
                TextBox txtFPFAmt = (TextBox)gvRow.FindControl("txtFPFAmt");
                TextBox txtCLSOwnPFAmt = (TextBox)gvRow.FindControl("txtCLSOwnPFAmt");
                TextBox txtCLSEmpPFAmt = (TextBox)gvRow.FindControl("txtCLSEmpPFAmt");
                TextBox txtCLSOwnIntAmt = (TextBox)gvRow.FindControl("txtCLSOwnIntAmt");
                TextBox txtCLSEMPIntAmt = (TextBox)gvRow.FindControl("txtCLSEMPIntAmt");
                TextBox txtCLSVPFAmt = (TextBox)gvRow.FindControl("txtCLSVPFAmt");
                TextBox txtCLSVPFInt = (TextBox)gvRow.FindControl("txtCLSVPFInt");
                TextBox txtCLSFPFAmt = (TextBox)gvRow.FindControl("txtCLSFPFAmt");

                if (txtDtFmlyPen.Text == "")
                {
                    txtDtFmlyPen.Text = ("09/09/9999");
                }
                if (txtDtPfTaken.Text == "")
                {
                    txtDtPfTaken.Text = ("09/09/9999");
                }
                /*
                

                 */
                sql = "JCT_Payroll_PF_OpeningBalance_Apply";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FYPeriod", SqlDbType.VarChar, 7).Value = txttodate.Text;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                cmd.Parameters.Add("@Nominee", SqlDbType.VarChar, 30).Value = txtNominee.Text;
                cmd.Parameters.Add("@DtPfjoin", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDtPfjoin.Text);
                cmd.Parameters.Add("@DtFmlyPen", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDtFmlyPen.Text);
                cmd.Parameters.Add("@DtPfTaken", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDtPfTaken.Text);
                cmd.Parameters.Add("@OwnPFAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtOwnPFAmt.Text);
                cmd.Parameters.Add("@EmpPFAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtEmpPFAmt.Text);
                cmd.Parameters.Add("@OwnIntAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtOwnIntAmt.Text);
                cmd.Parameters.Add("@EMPIntAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtEMPIntAmt.Text);
                cmd.Parameters.Add("@VPFAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtVPFAmt.Text);
                cmd.Parameters.Add("@VPFInt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtVPFInt.Text);
                cmd.Parameters.Add("@FPFAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtFPFAmt.Text);
                cmd.Parameters.Add("@CLSOwnPFAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtCLSOwnPFAmt.Text);
                cmd.Parameters.Add("@CLSEmpPFAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtCLSEmpPFAmt.Text);
                cmd.Parameters.Add("@CLSOwnIntAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtCLSOwnIntAmt.Text);
                cmd.Parameters.Add("@CLSEMPIntAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtCLSEMPIntAmt.Text);
                cmd.Parameters.Add("@CLSVPFAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtCLSVPFAmt.Text);
                cmd.Parameters.Add("@CLSVPFInt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtCLSVPFInt.Text);
                cmd.Parameters.Add("@CLSFPFAmt", SqlDbType.Decimal, 12).Value = Convert.ToDecimal(txtCLSFPFAmt.Text);
                //cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                cmd.ExecuteNonQuery();
                string script = "alert('Record  Updated.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                if (txtDtFmlyPen.Text == "09/09/9999")
                {
                    txtDtFmlyPen.Text = "";
                }
                if (txtDtPfTaken.Text == "09/09/9999")
                {
                    txtDtPfTaken.Text = "";
                }

            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Input string was not in a correct format.")
            {
                string script1 = "alert('Error,Some Field Left Blank.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
            }
            else
            {
                string script = "alert(''" + ex.Message + "'');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_PF_OpeningBalance.aspx");
    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_PF_OpeningBalance_Report.aspx");
    }
}