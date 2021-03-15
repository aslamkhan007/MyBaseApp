using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class Payroll_Payroll_PF_Retrun_Report : System.Web.UI.Page
{
    Connection obj = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();
            Locationbind();
        }
        //FetchRecord();
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_PF_Retrun_Report.aspx");
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        FetchRecord();
    }

    public void FetchRecord()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        //SqlPass = "Jct_Payroll_Salary_PF_Return_Fetch";
        SqlPass = "Jct_payroll_Pf_Esi_Return";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@ReturnType", SqlDbType.VarChar, 5).Value = ddlReturnType.SelectedItem.Text;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        //Cmd.Parameters.Add("@CardNo", SqlDbType.VarChar, 50).Value = txtSaviorcardno.Text;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
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

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        //string SqlPass = null;
        //SqlCommand Cmd = new SqlCommand();
        //SqlPass = "Jct_Payroll_Salary_PF_Return_Fetch";
        //Cmd = new SqlCommand(SqlPass, obj.Connection());
        //Cmd.CommandType = CommandType.StoredProcedure;
        //Cmd.Parameters.Add("@MONTHYEAR", SqlDbType.DateTime).Value = txtfromdate.Text;
        //Cmd.Parameters.Add("@ENDMONTHYEAR", SqlDbType.DateTime).Value = txttodate.Text;
        //Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        //Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        ////Cmd.Parameters.Add("@CardNo", SqlDbType.VarChar, 50).Value = txtSaviorcardno.Text;
        //SqlDataAdapter da = new SqlDataAdapter(Cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //grdDetail.DataSource = ds.Tables[0];
        //grdDetail.DataBind();
        //DataTable dt = ds.Tables[0];
        //string attachment = "attachment; jct_pay_days_cal_shweta.xls";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/vnd.ms-excel";
        //string tab = "";
        //foreach (DataColumn dc in dt.Columns)
        //{
        //    Response.Write(tab + dc.ColumnName);
        //    tab = "\t";
        //}
        //Response.Write("\n");
        //int i;
        //foreach (DataRow dr in dt.Rows)
        //{
        //    tab = "";
        //    for (i = 0; i < dt.Columns.Count; i++)
        //    {
        //        Response.Write(tab + dr[i].ToString());
        //        tab = "\t";
        //    }
        //    Response.Write("\n");
        //}
        //Response.End();
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }
}