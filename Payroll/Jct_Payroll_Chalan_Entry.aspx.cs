using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_Chalan_Entry : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ExgratiaDate();
            //AttendenceDate();
            PageLoadOption();
            PlantList();
        }
    }
   
    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_SalaryCal_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodate.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }

    private void PlantList()
    {
        sql = "Jct_Payroll_Plantlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "LongDescription";
        ddlplant.DataValueField = "PlantCode";
        ddlplant.DataBind();

    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        //lnkexcel.Enabled = true;
        bindgrid();
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Chalan_Entry.aspx");
    }

    private void bindgrid()
    {
        sql = "Jct_Payroll_Tax_Challan_Entry";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = ddlSerialNo.SelectedItem.Value;

        if(txtEductionCess.Text != "")
        cmd.Parameters.Add("@EductionCess", SqlDbType.Decimal,18).Value = txtEductionCess.Text;

        if (txtIntrestPlenty.Text != "")
        cmd.Parameters.Add("@IntrestPlenty", SqlDbType.Decimal, 18).Value = txtIntrestPlenty.Text;

        if (txtFee.Text != "")
        cmd.Parameters.Add("@Fee", SqlDbType.Decimal, 18).Value = txtFee.Text;

        if (txtPlentyOthers.Text != "")
        cmd.Parameters.Add("@PlentyOthers", SqlDbType.Decimal, 18).Value = txtPlentyOthers.Text;


        cmd.Parameters.Add("@BRSCode", SqlDbType.VarChar, 7).Value = txtBRSCode.Text;
        cmd.Parameters.Add("@DateOfDeposit", SqlDbType.DateTime).Value = txtDateOfDeposit.Text;
        cmd.Parameters.Add("@ChallanNo", SqlDbType.VarChar, 5).Value = txtChallanNo.Text;
        cmd.Parameters.Add("@ModeOfDeposit", SqlDbType.VarChar, 3).Value = ddlModeOfDeposit.SelectedItem.Value;

        if (txtIntrestAllocated.Text != "")
        cmd.Parameters.Add("@IntrestAllocated", SqlDbType.Decimal, 18).Value = txtIntrestAllocated.Text;
        cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        cmd.ExecuteNonQuery();
        string script = "alert('Record Saved Successfully');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        clearControl();
        PageLoadOption();
        return;

        //cmd.Parameters.Add("@AssesmentYrBh", SqlDbType.Int).Value = txtBHAssmentYr.Text;
        //cmd.Parameters.Add("@FinancialYrBh", SqlDbType.Int).Value = txtBHFinancialYr.Text;
        //cmd.Parameters.Add("@PeriodBh", SqlDbType.Char, 2).Value = ddYearQtr.SelectedItem.Value;

        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //if (ds.Tables.Count > 0)
        //{
        //    grdDetail.DataSource = ds.Tables[0];
        //    grdDetail.DataBind();
        //    Panel1.Visible = true;
        //}
        //else
        //{
        //    string script = "alert('No Record Found');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //    return;
        //}
    }

    public void ExgratiaDate()
    {
        string sqlqry = "Jct_Payroll_SalaryCal_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                //txtMonth.Text = dr["ToDate"].ToString();
            }
            dr.Close();
        }
    }

    protected void ddlReporttypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        visibleExtra();
    }

    public void visibleExtra()
    {
        if ((ddlReporttypes.SelectedItem.Text == "ChallanEntry"))
        {
            Response.Redirect("Jct_Payroll_Chalan_Entry.aspx");
        }

        else if ((ddlReporttypes.SelectedItem.Text == "ChallanReport"))
        {
            Response.Redirect("Jct_Payroll_Tax_Challan_Report.aspx");
        }

        else if ((ddlReporttypes.SelectedItem.Text == "MissingPanNumber"))
        {
            Response.Redirect("Jct_Payroll_Tax_Missing_PanNo.aspx");
        }

        else if ((ddlReporttypes.SelectedItem.Text == "QtrAnnexture"))
        {
            Response.Redirect("Jct_Payroll_Tax_Annexture.aspx");
        }

        else if ((ddlReporttypes.SelectedItem.Text == "YearlyAnnexture"))
        {
            Response.Redirect("Jct_Payroll_Yearly_Annexture.aspx");
        }

    }
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    public void clearControl()
    {
        txttodate.Text = "";       
        txtEductionCess.Text = "";

        txtIntrestPlenty.Text = "";
        txtFee.Text = "";
        txtPlentyOthers.Text = "";

        txtBRSCode.Text = "";
        txtDateOfDeposit.Text = "";
        txtIntrestAllocated.Text = "";
        txtChallanNo.Text = "";   
    }


    public void PageLoadOption()
    {
        txtEductionCess.Text = "0.00";        
        txtIntrestPlenty.Text = "0.00";
        txtFee.Text = "0.00";
        txtPlentyOthers.Text = "0.00";
        txtIntrestAllocated.Text = "0.00";        
    }

}