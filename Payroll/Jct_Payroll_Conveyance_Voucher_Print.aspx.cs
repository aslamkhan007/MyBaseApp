using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_Conveyance_Voucher_Print : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    int requestID;
    int CheckEligile = 0;
    string jctsr_no;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["YEARMONTH"] = Request.QueryString["YEARMONTH"].ToString();
            ViewState["empcode"] = Request.QueryString["empcode"].ToString();

            //ViewState["YEARMONTH"] = "201803";
            //ViewState["empcode"] = "R-03339";

            //requestID = Convert.ToInt32(Request.QueryString["requestid"]);
            //CheckEligibility();
            if (CheckEligile == 0)
            {
                string sql = "Jct_Payroll_Converyance_Voucher_Header_Print";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@Srno", SqlDbType.Int).Value = requestID;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = ViewState["YEARMONTH"];
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = ViewState["empcode"];                
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //lblPlant.Text = dr["Plant"].ToString();
                        //lblLocation.Text = dr["Location"].ToString();
                        lblDepartment.Text = dr["Department"].ToString();
                        lbldesignation.Text = dr["Designation"].ToString();
                        lblEmployeeName.Text = dr["EmployeeName"].ToString();
                        lblEmployeecode.Text = dr["EmployeeCode"].ToString();
                        //lblCardNo.Text = dr["CardNo"].ToString();
                        lblPrintdate.Text = dr["PrintDate"].ToString();
                        lblFromp.Text = dr["FromDate"].ToString();
                        lblTodatep.Text = dr["ToDate"].ToString();
                    }
                }
                else
                {
                    string script = "alert(No data available!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }
                dr.Close();
                BindLIst();
            }
        }
    }

    public void CheckEligibility()
    {
        try
        {
            string sql = "Jct_Payroll_Designation_Wise_Voucher";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = ViewState["YEARMONTH"];
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = ViewState["empcode"]; 
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                }
            }
            dr.Close();
        }
        catch (Exception ex)
        {
            CheckEligile = 1;
            string Scrpt = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", Scrpt, true);
        }
    }

    public void BindLIst()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_Converyance_Voucher_Detail_Print", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = ViewState["YEARMONTH"];
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = ViewState["empcode"]; 
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Width = new Unit("150px");
            e.Row.Cells[1].Width = new Unit("200px");
            e.Row.Cells[2].Width = new Unit("200px");
            //e.Row.Cells[3].Width = new Unit("150px");
        }
    }
}