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

public partial class Payroll_JCT_Payroll_PF_Contribution : System.Web.UI.Page
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

    /*


  */
    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("JCT_Payroll_PF_Contribution_Fetch", obj.Connection());
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
                TextBox txtAPRPF = (TextBox)gvRow.FindControl("txtAPRPF");
                TextBox APRVPF = (TextBox)gvRow.FindControl("txtAPRVPF");
                TextBox txtAPRSAL = (TextBox)gvRow.FindControl("txtAPRSAL");
                TextBox txtAPRPFR = (TextBox)gvRow.FindControl("txtAPRPFR");
                TextBox txtAPREPS = (TextBox)gvRow.FindControl("txtAPREPS");
                TextBox txtMAYPF = (TextBox)gvRow.FindControl("txtMAYPF");
                TextBox txtMAYVPF = (TextBox)gvRow.FindControl("txtMAYVPF");
                TextBox txtMAYSAL = (TextBox)gvRow.FindControl("txtMAYSAL");
                TextBox txtMAYPFR = (TextBox)gvRow.FindControl("txtMAYPFR");
                TextBox txtMAYEPS = (TextBox)gvRow.FindControl("txtMAYEPS");
                TextBox txtJUNPF = (TextBox)gvRow.FindControl("txtJUNPF");
                TextBox txtJUNVPF = (TextBox)gvRow.FindControl("txtJUNVPF");
                TextBox txtJUNSAL = (TextBox)gvRow.FindControl("txtJUNSAL");
                TextBox txtJUNPFR = (TextBox)gvRow.FindControl("txtJUNPFR");
                TextBox txtJUNEPS = (TextBox)gvRow.FindControl("txtJUNEPS");
                TextBox txtJULPF = (TextBox)gvRow.FindControl("txtJULPF");
                TextBox txtJULVPF = (TextBox)gvRow.FindControl("txtJULVPF");
                TextBox txtJULSAL = (TextBox)gvRow.FindControl("txtJULSAL");
                TextBox txtJULPFR = (TextBox)gvRow.FindControl("txtJULPFR");
                TextBox txtJULEPS = (TextBox)gvRow.FindControl("txtJULEPS");
                TextBox txtAUGPF = (TextBox)gvRow.FindControl("txtAUGPF");
                TextBox txtAUGVPF = (TextBox)gvRow.FindControl("txtAUGVPF");
                TextBox txtAUGSAL = (TextBox)gvRow.FindControl("txtAUGSAL");
                TextBox txtAUGPFR = (TextBox)gvRow.FindControl("txtAUGPFR");
                TextBox txtAUGEPS = (TextBox)gvRow.FindControl("txtAUGEPS");
                TextBox txtSEPPF = (TextBox)gvRow.FindControl("txtSEPPF");
                TextBox txtSEPVPF = (TextBox)gvRow.FindControl("txtSEPVPF");
                TextBox txtSEPSAL = (TextBox)gvRow.FindControl("txtSEPSAL");
                TextBox txtSEPPFR = (TextBox)gvRow.FindControl("txtSEPPFR");
                TextBox txtSEPEPS = (TextBox)gvRow.FindControl("txtSEPEPS");
                TextBox txtOCTPF = (TextBox)gvRow.FindControl("txtOCTPF");
                TextBox txtOCTVPF = (TextBox)gvRow.FindControl("txtOCTVPF");
                TextBox txtOCTSAL = (TextBox)gvRow.FindControl("txtOCTSAL");
                TextBox txtOCTPFR = (TextBox)gvRow.FindControl("txtOCTPFR");
                TextBox txtOCTEPS = (TextBox)gvRow.FindControl("txtOCTEPS");
                TextBox txtNOVPF = (TextBox)gvRow.FindControl("txtNOVPF");
                TextBox txtNOVVPF = (TextBox)gvRow.FindControl("txtNOVVPF");
                TextBox txtNOVSAL = (TextBox)gvRow.FindControl("txtNOVSAL");
                TextBox txtNOVPFR = (TextBox)gvRow.FindControl("txtNOVPFR");
                TextBox txtNOVEPS = (TextBox)gvRow.FindControl("txtNOVEPS");
                TextBox txtDECPF = (TextBox)gvRow.FindControl("txtDECPF");
                TextBox txtDECVPF = (TextBox)gvRow.FindControl("txtDECVPF");
                TextBox txtDECSAL = (TextBox)gvRow.FindControl("txtDECSAL");
                TextBox txtDECPFR = (TextBox)gvRow.FindControl("txtDECPFR");
                TextBox txtDECEPS = (TextBox)gvRow.FindControl("txtDECEPS");
                TextBox txtJANPF = (TextBox)gvRow.FindControl("txtJANPF");
                TextBox txtJANVPF = (TextBox)gvRow.FindControl("txtJANVPF");
                TextBox txtJANSAL = (TextBox)gvRow.FindControl("txtJANSAL");
                TextBox txtJANPFR = (TextBox)gvRow.FindControl("txtJANPFR");
                TextBox txtJANEPS = (TextBox)gvRow.FindControl("txtJANEPS");
                TextBox txtFEBPF = (TextBox)gvRow.FindControl("txtFEBPF");
                TextBox txtFEBVPF = (TextBox)gvRow.FindControl("txtFEBVPF");
                TextBox txtFEBSAL = (TextBox)gvRow.FindControl("txtFEBSAL");
                TextBox txtFEBPFR = (TextBox)gvRow.FindControl("txtFEBPFR");
                TextBox txtFEBEPS = (TextBox)gvRow.FindControl("txtFEBEPS");
                TextBox txtMARPF = (TextBox)gvRow.FindControl("txtMARPF");
                TextBox txtMARVPF = (TextBox)gvRow.FindControl("txtMARVPF");
                TextBox txtMARSAL = (TextBox)gvRow.FindControl("txtMARSAL");
                TextBox txtMARPFR = (TextBox)gvRow.FindControl("txtMARPFR");
                TextBox txtMAREPS = (TextBox)gvRow.FindControl("txtMAREPS");
                TextBox txtPFMAR2 = (TextBox)gvRow.FindControl("txtPFMAR2");
                TextBox txtVPFMAR2 = (TextBox)gvRow.FindControl("txtVPFMAR2");
                TextBox txtMARSAL2 = (TextBox)gvRow.FindControl("txtMARSAL2");
                TextBox txtPFRMAR2 = (TextBox)gvRow.FindControl("txtPFRMAR2");
                TextBox txtEPSMAR2 = (TextBox)gvRow.FindControl("txtEPSMAR2");
                TextBox txtSapCode1 = (TextBox)gvRow.FindControl("txtSapCode");
                TextBox txtPFNo1 = (TextBox)gvRow.FindControl("txtPFNo");
                TextBox txtFPFNo1 = (TextBox)gvRow.FindControl("txtFPFNo");

                sql = "JCT_Payroll_PF_Contribution_Apply";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FYPeriod", SqlDbType.VarChar, 7).Value = txttodate.Text;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                cmd.Parameters.Add("@APRPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAPRPF.Text);
                cmd.Parameters.Add("@APRVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(APRVPF.Text);
                cmd.Parameters.Add("@APRSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAPRSAL.Text);
                cmd.Parameters.Add("@APRPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAPRPFR.Text);
                cmd.Parameters.Add("@APREPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAPREPS.Text);
                cmd.Parameters.Add("@MAYPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMAYPF.Text);
                cmd.Parameters.Add("@MAYVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMAYPF.Text);
                cmd.Parameters.Add("@MAYSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMAYSAL.Text);
                cmd.Parameters.Add("@MAYPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMAYPFR.Text);
                cmd.Parameters.Add("@MAYEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJUNPF.Text);
                cmd.Parameters.Add("@JUNPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJUNPF.Text);
                cmd.Parameters.Add("@JUNVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJUNVPF.Text);
                cmd.Parameters.Add("@JUNSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJUNSAL.Text);
                cmd.Parameters.Add("@JUNPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJUNPFR.Text);
                cmd.Parameters.Add("@JUNEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJUNEPS.Text);
                cmd.Parameters.Add("@JULPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJULPF.Text);
                cmd.Parameters.Add("@JULVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJULVPF.Text);
                cmd.Parameters.Add("@JULSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJULSAL.Text);
                cmd.Parameters.Add("@JULPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJULPFR.Text);
                cmd.Parameters.Add("@JULEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJULEPS.Text);
                cmd.Parameters.Add("@AUGPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAUGPF.Text);
                cmd.Parameters.Add("@AUGVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAUGVPF.Text);
                cmd.Parameters.Add("@AUGSAL ", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAUGSAL.Text);
                cmd.Parameters.Add("@AUGPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAUGPFR.Text);
                cmd.Parameters.Add("@AUGEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtAUGEPS.Text);
                cmd.Parameters.Add("@SEPPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSEPPF.Text);
                cmd.Parameters.Add("@SEPVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSEPVPF.Text);
                cmd.Parameters.Add("@SEPSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSEPSAL.Text);
                cmd.Parameters.Add("@SEPPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSEPPFR.Text);
                cmd.Parameters.Add("@SEPEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSEPEPS.Text);
                cmd.Parameters.Add("@OCTPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtOCTPF.Text);
                cmd.Parameters.Add("@OCTVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtOCTVPF.Text);
                cmd.Parameters.Add("@OCTSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtOCTSAL.Text);
                cmd.Parameters.Add("@OCTPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtOCTPFR.Text);
                cmd.Parameters.Add("@OCTEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtOCTEPS.Text);
                cmd.Parameters.Add("@NOVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtNOVPF.Text);
                cmd.Parameters.Add("@NOVVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtNOVVPF.Text);
                cmd.Parameters.Add("@NOVSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtNOVSAL.Text);
                cmd.Parameters.Add("@NOVPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtNOVPFR.Text);
                cmd.Parameters.Add("@NOVEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtNOVEPS.Text);
                cmd.Parameters.Add("@DECPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtDECPF.Text);
                cmd.Parameters.Add("@DECVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtDECVPF.Text);
                cmd.Parameters.Add("@DECSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtDECSAL.Text);
                cmd.Parameters.Add("@DECPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtDECPFR.Text);
                cmd.Parameters.Add("@DECEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtDECEPS.Text);
                cmd.Parameters.Add("@JANPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJANPF.Text);
                cmd.Parameters.Add("@JANVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJANVPF.Text);
                cmd.Parameters.Add("@JANSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJANSAL.Text);
                cmd.Parameters.Add("@JANPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJANPFR.Text);
                cmd.Parameters.Add("@JANEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtJANEPS.Text);
                cmd.Parameters.Add("@FEBPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFEBPF.Text);
                cmd.Parameters.Add("@FEBVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFEBVPF.Text);
                cmd.Parameters.Add("@FEBSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFEBSAL.Text);
                cmd.Parameters.Add("@FEBPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFEBPFR.Text);
                cmd.Parameters.Add("@FEBEPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFEBEPS.Text);
                cmd.Parameters.Add("@MARPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMARPF.Text);
                cmd.Parameters.Add("@MARVPF", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMARVPF.Text);
                cmd.Parameters.Add("@MARSAL", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMARSAL.Text);
                cmd.Parameters.Add("@MARPFR", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMARPFR.Text);
                cmd.Parameters.Add("@MAREPS", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMAREPS.Text);
                cmd.Parameters.Add("@PFMAR2", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPFMAR2.Text);
                cmd.Parameters.Add("@VPFMAR2", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtVPFMAR2.Text);
                cmd.Parameters.Add("@MARSAL2", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtMARSAL2.Text);
                cmd.Parameters.Add("@PFRMAR2", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPFRMAR2.Text);
                cmd.Parameters.Add("@EPSMAR2", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtEPSMAR2.Text);
                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                cmd.Parameters.Add("@PFNO", SqlDbType.VarChar, 10).Value = Convert.ToDecimal(txtPFNo1.Text);
                cmd.Parameters.Add("@FPFNO", SqlDbType.VarChar, 10).Value = Convert.ToDecimal(txtFPFNo1.Text);
                cmd.Parameters.Add("@SapEmployeeCode", SqlDbType.VarChar, 10).Value = Convert.ToDecimal(txtSapCode1.Text); 
                cmd.ExecuteNonQuery();
                string script = "alert('Record  Updated.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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
        Response.Redirect("JCT_Payroll_PF_Contribution.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        Excel();
    }
    public void Excel()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "JCT_Payroll_PF_Contribution_Fetch_ExportData";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; filename=Employee.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {

                Response.Write(tab + dr[i].ToString());

                tab = "\t";
            }

            Response.Write("\n");
        }
        Response.End();
    }

   
}