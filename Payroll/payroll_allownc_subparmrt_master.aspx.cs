using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class PayRoll_payroll_subparmrt_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //bindgrid();
            Designationbind();
            txteff_to_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
            Componentlist();
            bindgrid();
        }
    }

    protected void GenerateCode()
    {
        #region Serial No. Code
        string str;
        SqlCommand cmd = new SqlCommand("SELECT SUBSTRING(MAX(SubComponentCode),CHARINDEX('-', MAX(SubComponentCode)) + 1,LEN(MAX(SubComponentCode)) + 3) FROM   dbo.Jct_Payroll_SubComponents", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["SUBCOM"] = "100";
                    ViewState["SUBCOM"] = "SUBCOM-" + ViewState["SUBCOM"];
                }
                else
                {
                    ViewState["SUBCOM"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["SUBCOM"] = "SUBCOM-" + ViewState["SUBCOM"];
                }
            }
        }
        dr.Close();
        #endregion
    }

    public void Designationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT 'DSG-100' AS Designation_code , 'All' AS Desg_Long_Description UNION SELECT   Designation_code,Desg_Long_Description FROM JCT_payroll_designation_master WHERE  STATUS='A' Order by Desg_Long_Description", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldesignation.DataSource = ds;
        ddldesignation.DataTextField = "Desg_Long_Description";
        ddldesignation.DataValueField = "Designation_code";
        ddldesignation.DataBind();        
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["SUBCOM"] = "";
            GenerateCode();
            sql = "Jct_Payroll_SubComponents_Insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubComponentCode", SqlDbType.VarChar, 40).Value = ViewState["SUBCOM"];
            cmd.Parameters.Add("@ComponentParameterCode", SqlDbType.Int).Value = ddlparamtr.SelectedItem.Value;
            cmd.Parameters.Add("@SubComponentName", SqlDbType.VarChar, 50).Value = txtsubparamtr.Text;
            cmd.Parameters.Add("@SubComponentDescription", SqlDbType.VarChar, 100).Value = txtdesc.Text;
            cmd.Parameters.Add("@UnitOfComponent", SqlDbType.VarChar, 30).Value = ddlUOC.SelectedItem.Text;
            cmd.Parameters.Add("@Value", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtvalue.Text);             
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.DateTime).Value = txteff_frm.Text;
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = txteff_to.Text;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@DesignationCode", SqlDbType.VarChar, 20).Value = ddldesignation.SelectedItem.Value;
            cmd.Parameters.Add("@ValuationFactor", SqlDbType.VarChar, 20).Value = ddldeductionOn.SelectedItem.Text;
            cmd.Parameters.Add("@ComponentType", SqlDbType.VarChar, 15).Value = ddlComponentType.SelectedItem.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  Saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextboxes();
        }
        catch (Exception ex)
        {
            string script = "alert('error occurred!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Jct_Payroll_SubComponents_Update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubComponentCode", SqlDbType.VarChar, 40).Value = lbcodeid.Text;
            cmd.Parameters.Add("@ComponentParameterCode", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[2].Text;            
            cmd.Parameters.Add("@SubComponentName", SqlDbType.VarChar, 50).Value = txtsubparamtr.Text;
            cmd.Parameters.Add("@SubComponentDescription", SqlDbType.VarChar, 100).Value = txtdesc.Text;
            cmd.Parameters.Add("@UnitOfComponent", SqlDbType.VarChar, 30).Value = ddlUOC.SelectedItem.Text;
            cmd.Parameters.Add("@Value", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtvalue.Text); 
            cmd.Parameters.Add("@EffectiveFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_frm.Text);
            cmd.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@DesignationCode", SqlDbType.VarChar, 20).Value = ddldesignation.SelectedItem.Value;
            cmd.Parameters.Add("@ValuationFactor", SqlDbType.VarChar, 20).Value = ddldeductionOn.SelectedItem.Text;
            cmd.Parameters.Add("@ComponentType", SqlDbType.VarChar, 15).Value = ddlComponentType.SelectedItem.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextboxes();
        }
        catch (Exception ex)
        {
            string script = "alert('error occurred!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Jct_Payroll_SubComponents_Delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubComponentCode", SqlDbType.VarChar, 40).Value = lbcodeid.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record  Deleted .!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            cleartextboxes();
        }
        catch (Exception ex)
        {
            string script = "alert('error occurred!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_allownc_subparmrt_master.aspx");
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlComponentType.SelectedIndex = ddlComponentType.Items.IndexOf(ddlComponentType.Items.FindByValue(grdDetail.SelectedRow.Cells[1].Text));
        ddlparamtr.SelectedIndex = ddlparamtr.Items.IndexOf(ddlparamtr.Items.FindByValue(grdDetail.SelectedRow.Cells[2].Text));
        txtsubparamtr.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[3].Text);
        txtdesc.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[4].Text);
        lbcodeid.Text = grdDetail.SelectedRow.Cells[5].Text; 
        ddlUOC.SelectedIndex =ddlUOC.Items.IndexOf(ddlUOC.Items.FindByText(grdDetail.SelectedRow.Cells[6].Text));
        txtvalue.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[7].Text);
        txteff_frm.Text=grdDetail.SelectedRow.Cells[8].Text;
        txteff_to.Text = grdDetail.SelectedRow.Cells[9].Text;        
        ddldeductionOn.SelectedIndex = ddldeductionOn.Items.IndexOf(ddldeductionOn.Items.FindByValue(grdDetail.SelectedRow.Cells[10].Text));
        ddldesignation.SelectedIndex = ddldesignation.Items.IndexOf(ddldesignation.Items.FindByValue(grdDetail.SelectedRow.Cells[11].Text));
        lbcodeid.Visible = true;
        lblCode.Visible = true;
    }

    private void bindgrid()
    {
        sql = "Jct_Payroll_SubComponents_Select";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ComponentType", SqlDbType.VarChar,15).Value = ddlComponentType.SelectedItem.Value;
        cmd.Parameters.Add("@Component", SqlDbType.Int).Value = ddlparamtr.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
    private void cleartextboxes()
    {
        txtdesc.Text = "";
        txteff_frm.Text = "";
        txteff_to.Text = "";
        txtsubparamtr.Text = "";
        txtvalue.Text = "";
        lbcodeid.Visible = false;
        lblCode.Visible = false;
    }
    protected void ddldesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ddlComponentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Componentlist();
        bindgrid();

    }
    protected void ddlparamtr_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
    private void Componentlist()
    {
        sql = "Jct_Payroll_Parameter_List";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@component_type", SqlDbType.VarChar,15).Value = ddlComponentType.SelectedItem.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlparamtr.DataSource = ds;
        ddlparamtr.DataTextField = "ComponentName";
        ddlparamtr.DataValueField = "SrNo";
        ddlparamtr.DataBind();  
    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
}