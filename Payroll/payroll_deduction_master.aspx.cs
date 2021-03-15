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

public partial class Payroll_payroll_deduction_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            txteffto_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
        }
    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateCode();
            string qry = "JCT_payroll_deduction_master_ins_upd_del";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Deduction_code", SqlDbType.VarChar, 10).Value = ViewState["DeductCode"];
            cmd.Parameters.Add("@Deduction_Short_Description", SqlDbType.VarChar, 20).Value = txtDeducshortdescrip.Text;
            cmd.Parameters.Add("@Deduction_Long_Description", SqlDbType.VarChar, 100).Value = txtDeducLongdescrip.Text;
            cmd.Parameters.Add("@uom", SqlDbType.VarChar, 20).Value = ddluom.SelectedValue;
            cmd.Parameters.Add("@unitvalue", SqlDbType.Decimal,18).Value = txtUnitValue.Text;
            cmd.Parameters.Add("@Deduction_On", SqlDbType.VarChar, 20).Value = ddldeductionOn.SelectedValue;
            cmd.Parameters.Add("@Deduction_Type", SqlDbType.VarChar, 20).Value = ddlDeductionType.SelectedValue;         
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = "ADD";
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);                   
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lblDeductionCode.Visible = true;
            lbcodeid.Visible = true;
 	    
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    private void bindgrid()
    {
        string qry = " SELECT ltrim(rtrim(Deduction_code)) as DeductionCode,Deduction_Short_Description,Deduction_Long_Description,uom,unitvalue,rtrim(ltrim(Deduction_On))as DeductionOn,Deduction_Type,CONVERT(VARCHAR(10),eff_from,101) AS EffectiveFrom,CONVERT(VARCHAR(10),eff_to,101) AS EffectiveTo FROM JCT_payroll_deduction_master WHERE  status='A' order by Deduction_code";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string  qry = "JCT_payroll_deduction_master_ins_upd_del";
            SqlCommand cmd = new SqlCommand(qry,obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Deduction_code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Deduction_Short_Description", SqlDbType.VarChar, 20).Value = txtDeducshortdescrip.Text;
            cmd.Parameters.Add("@Deduction_Long_Description", SqlDbType.VarChar, 100).Value = txtDeducLongdescrip.Text;
            cmd.Parameters.Add("@uom", SqlDbType.VarChar, 20).Value = ddluom.SelectedValue;
            cmd.Parameters.Add("@unitvalue", SqlDbType.Decimal,18).Value = txtUnitValue.Text;
            cmd.Parameters.Add("@Deduction_On", SqlDbType.VarChar, 20).Value = ddldeductionOn.SelectedValue;
            cmd.Parameters.Add("@Deduction_Type", SqlDbType.VarChar, 20).Value = ddlDeductionType.SelectedValue;  
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = "UPD";
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text); 
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();                                                                           
            string script = "alert('Record  Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "JCT_payroll_deduction_master_ins_upd_del";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Deduction_code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Deduction_Short_Description", SqlDbType.VarChar, 20).Value = txtDeducshortdescrip.Text;
            cmd.Parameters.Add("@Deduction_Long_Description", SqlDbType.VarChar, 100).Value = txtDeducLongdescrip.Text;
            cmd.Parameters.Add("@uom", SqlDbType.VarChar, 20).Value = ddluom.SelectedValue;
            cmd.Parameters.Add("@unitvalue", SqlDbType.Decimal,18).Value = txtUnitValue.Text;
            cmd.Parameters.Add("@Deduction_On", SqlDbType.VarChar, 20).Value = ddldeductionOn.SelectedValue;
            cmd.Parameters.Add("@Deduction_Type", SqlDbType.VarChar, 20).Value = ddlDeductionType.SelectedValue;  
            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = "DEL";
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text); 
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbcodeid.Text = grdDetail.SelectedRow.Cells[1].Text;
        txtDeducshortdescrip.Text = grdDetail.SelectedRow.Cells[2].Text;
        txtDeducLongdescrip.Text = grdDetail.SelectedRow.Cells[3].Text;
        ddluom.SelectedValue = grdDetail.SelectedRow.Cells[4].Text;
        txtUnitValue.Text = grdDetail.SelectedRow.Cells[5].Text;
        if (grdDetail.SelectedRow.Cells[6].Text == "Percentage")
        {
            lblDeductionOn.Visible = true;
            ddldeductionOn.Visible = true;      
            ddldeductionOn.SelectedValue = grdDetail.SelectedRow.Cells[6].Text;
        }
        ddlDeductionType.SelectedIndex = ddlDeductionType.Items.IndexOf(ddlDeductionType.Items.FindByText(grdDetail.SelectedRow.Cells[7].Text));
        txtefffrm.Text = grdDetail.SelectedRow.Cells[8].Text;
        txteffto.Text = grdDetail.SelectedRow.Cells[9].Text;
        lbcodeid.Visible = true;
        lblDeductionCode.Visible = true;
        if (!string.IsNullOrEmpty(grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "")))
        {
            ddldeductionOn.Visible = true;
            lblDeductionOn.Visible = true;
        }
        
    }   
    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;
        //string qry = ConfigurationManager.ConnectionStrings["misdev"].ToString();
        ////SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        //SqlConnection con = new SqlConnection(qry);
        //con.Open();

        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(Deduction_code),CHARINDEX('-',max(Deduction_code))+1,len(max(Deduction_code))+3) from JCT_payroll_deduction_master ", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["DeductCode"] = "100";
                    ViewState["DeductCode"] = "DED-" + ViewState["DeductCode"];
                }
                else
                {
                    ViewState["DeductCode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["DeductCode"] = "DED-" + ViewState["DeductCode"];
                }
            }

        }

        dr.Close();
        //con.Close();

        #endregion
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_deduction_master.aspx");
    }
    protected void ddluom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddluom.SelectedValue == "PERCENTAGE")
        {
            lblDeductionOn.Visible = true;
            ddldeductionOn.Visible = true;
        }
        else if (ddluom.SelectedValue == "RUPEES")
        {
            lblDeductionOn.Visible = false;
            ddldeductionOn.Visible = false;
            ddldeductionOn.SelectedIndex = 0;
        }
    }
    private void ClearTextBoxes()
    {
        ddldeductionOn.ClearSelection();
        ddlDeductionType.ClearSelection();
        ddluom.ClearSelection();
        txtDeducLongdescrip.Text = "";
        txtDeducshortdescrip.Text = "";
        txtefffrm.Text = "";
        txteffto.Text = "";
        txtUnitValue.Text = "";
        lbcodeid.Visible = false;
        lblDeductionCode.Visible = false;
    }

}