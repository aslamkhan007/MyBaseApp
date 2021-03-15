using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_Training_Details : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Training_Detail_Insert ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar,20).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@TrainingType", SqlDbType.VarChar,40).Value = RadioButtonList5.SelectedItem.Text;
            cmd.Parameters.Add("@TrainingName", SqlDbType.VarChar, 70).Value = TxtTrainingName.Text;
            cmd.Parameters.Add("@Area", SqlDbType.VarChar,80).Value = TxtArea.Text;
            cmd.Parameters.Add("@Organisation", SqlDbType.VarChar, 80).Value = TxtOrg.Text;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 60).Value = TxtLocation.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 30).Value = ddlcountry.SelectedItem.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = txtstate.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = txtcity.Text;
            cmd.Parameters.Add("@Pin", SqlDbType.VarChar, 10).Value = TxtPin.Text;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtFrom.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtTo.Text);
            cmd.Parameters.Add("@FacultyName", SqlDbType.VarChar, 80).Value = TxtFacluty.Text;
            cmd.Parameters.Add("@FacultyOrganisation", SqlDbType.VarChar,60).Value = TxtFaclutyOrg.Text;
            cmd.Parameters.Add("@FacultyAddress", SqlDbType.VarChar,80).Value = TxtFacultyAddress.Text;
            cmd.Parameters.Add("@RemarksType", SqlDbType.VarChar, 20).Value = DrpRemarksType.SelectedItem.Text;
            cmd.Parameters.Add("@Marks", SqlDbType.VarChar, 20).Value = TxtMarks.Text;
            cmd.Parameters.Add("@Certified", SqlDbType.VarChar, 5).Value = RadioCertification.SelectedItem.Text;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar,80).Value = TxtRemarks.Text;
            cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Training_Detail_Update ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 20).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@TrainingType", SqlDbType.VarChar, 40).Value = RadioButtonList5.SelectedItem.Text;
            cmd.Parameters.Add("@TrainingName", SqlDbType.VarChar, 70).Value = TxtTrainingName.Text;
            cmd.Parameters.Add("@Area", SqlDbType.VarChar, 80).Value = TxtArea.Text;
            cmd.Parameters.Add("@Organisation", SqlDbType.VarChar, 80).Value = TxtOrg.Text;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 60).Value = TxtLocation.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 30).Value = ddlcountry.SelectedItem.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = txtstate.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = txtcity.Text;
            cmd.Parameters.Add("@Pin", SqlDbType.VarChar, 10).Value = TxtPin.Text;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtFrom.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(TxtTo.Text);
            cmd.Parameters.Add("@FacultyName", SqlDbType.VarChar, 80).Value = TxtFacluty.Text;
            cmd.Parameters.Add("@FacultyOrganisation", SqlDbType.VarChar,60).Value = TxtFaclutyOrg.Text;
            cmd.Parameters.Add("@FacultyAddress", SqlDbType.VarChar,80).Value = TxtFacultyAddress.Text;
            cmd.Parameters.Add("@RemarksType", SqlDbType.VarChar, 20).Value = DrpRemarksType.SelectedItem.Text;
            cmd.Parameters.Add("@Marks", SqlDbType.VarChar, 20).Value = TxtMarks.Text;
            cmd.Parameters.Add("@Certified", SqlDbType.VarChar, 5).Value = RadioCertification.SelectedItem.Text;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar,80).Value = TxtRemarks.Text;
            cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "Jct_Payroll_Training_Detail_Delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 7).Value = txtEmpCode.Text;
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            string script = "alert('some error occurred!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Training_Details.aspx");
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkdelete.Enabled = true;
        lnkupdate.Enabled = true;
        SrCode.Visible = true;
        SrId.Visible = true;
        SrId.Text = grdDetail.SelectedRow.Cells[1].Text;
        txtEmpCode.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[2].Text);
        RadioButtonList5.ClearSelection();
        RadioButtonList5.SelectedIndex = RadioButtonList5.Items.IndexOf(RadioButtonList5.Items.FindByValue(grdDetail.SelectedRow.Cells[3].Text));
        //RadioButtonList5.SelectedItem.Text = grdDetail.SelectedRow.Cells[3].Text;
        TxtTrainingName.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[4].Text);
        TxtArea.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[5].Text);
        TxtOrg.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[6].Text);
        TxtLocation.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[7].Text);
        ddlcountry.SelectedIndex = ddlcountry.Items.IndexOf(ddlcountry.Items.FindByText(grdDetail.SelectedRow.Cells[8].Text));
        txtstate.Text=grdDetail.SelectedRow.Cells[9].Text;
         txtcity.Text=grdDetail.SelectedRow.Cells[10].Text;
        TxtPin.Text = grdDetail.SelectedRow.Cells[11].Text;
        TxtFrom.Text = grdDetail.SelectedRow.Cells[12].Text;
        TxtTo.Text = grdDetail.SelectedRow.Cells[13].Text;
        TxtFacluty.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[14].Text);
        TxtFaclutyOrg.Text = grdDetail.SelectedRow.Cells[15].Text;
        TxtFacultyAddress.Text = grdDetail.SelectedRow.Cells[16].Text;
        DrpRemarksType.SelectedIndex = DrpRemarksType.Items.IndexOf(DrpRemarksType.Items.FindByText(grdDetail.SelectedRow.Cells[17].Text));
        TxtMarks.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[18].Text);
        RadioCertification.ClearSelection();
        RadioCertification.SelectedIndex = RadioCertification.Items.IndexOf(RadioCertification.Items.FindByValue(grdDetail.SelectedRow.Cells[19].Text));
        //RadioCertification.SelectedItem.Text = grdDetail.SelectedRow.Cells[19].Text;
        TxtRemarks.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[20].Text);
    }
    protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    {
        bindgrid();
    }

    private void bindgrid()
    { 
        sql = "Jct_Payroll_Training_Details_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        //Panel1.Visible = true;
    }
    private void ClearTextBoxes()
    {
        txtEmpCode.Text = "";
        TxtOrg.Text = "";
        TxtArea.Text = "";
        TxtFacluty.Text = "";
        TxtFaclutyOrg.Text = "";
        TxtLocation.Text = "";
        TxtFrom.Text = "";
        TxtTo.Text = "";
        TxtTrainingName.Text = "";
        TxtMarks.Text = "";
        TxtRemarks.Text = "";
        TxtPin.Text = "";
        TxtFacultyAddress.Text = "";
        SrCode.Visible = false;
        SrId.Visible = false;
        txtcity.Text = "";
        ddlcountry.ClearSelection();
        txtstate.Text = "";
    }
}