using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_Jct_Payroll_Yearly_Annexture : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ExgratiaDate();
            //AttendenceDate();
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
        Response.Redirect("Jct_Payroll_Tax_Annexture.aspx");
    }

    private void bindgrid()
    {
        sql = "Jct_Payroll_Yearly_TaxReturnData_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@FromYrMth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@ToYrMth", SqlDbType.Int).Value = txtSerialNo.Text;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        //cmd.Parameters.Add("@AssesmentYrBh", SqlDbType.Int).Value = txtBHAssmentYr.Text;
        //cmd.Parameters.Add("@FinancialYrBh", SqlDbType.Int).Value = txtBHFinancialYr.Text;
        //cmd.Parameters.Add("@PeriodBh", SqlDbType.Char, 2).Value = ddYearQtr.SelectedItem.Value;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
        }
        else
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
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


}