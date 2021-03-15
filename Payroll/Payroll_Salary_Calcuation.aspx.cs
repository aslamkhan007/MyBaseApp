using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Payroll_Payroll_Salary_Calcuation : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            enabledisable();
            AttendenceDate();
            Plantbind();
            Locationbind();
        }
    }

    //protected void LinkButton11_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        sql = "JCT_Payroll_Salary_Unfreeze";
    //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandTimeout = 0;
    //        cmd.Parameters.Add("@CalculationType", SqlDbType.VarChar, 10).Value = ddlReporttype.SelectedItem.Value;
    //        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
    //        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddllocation.SelectedItem.Value;
    //        cmd.Parameters.Add("@Yearmonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
    //        cmd.ExecuteNonQuery();
    //        string script = "alert('Record Unfreezed Successfully..');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //        //SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        //DataSet ds = new DataSet();
    //        //da.Fill(ds);
    //        //grdDetail.DataSource = ds.Tables[0];
    //        //grdDetail.DataBind();


    //        Panel1.Visible = true;
    //    }

    //    catch (Exception ex)
    //    {
    //        string script2 = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
    //        return;
    //    }

    //}


    public void enabledisable()
    {
        if (ddlReporttype.SelectedItem.Text == "Salary")
        {
            lblName.Visible = false;
            txtEmployee.Visible = false;         
        }
        if (ddlReporttype.SelectedItem.Text == "Seprate Voucher")
        {
            lblName.Visible = true;
            txtEmployee.Visible = true;                        
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


    public void Plantbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "plant_description";
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
        ddllocation.DataSource = ds;
        ddllocation.DataTextField = "Location_description";
        ddllocation.DataValueField = "Location_code";
        ddllocation.DataBind();
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        if (ddlReporttype.SelectedItem.Text == "Salary")
        {
            try
            {
                sql = "Jct_Payroll_Salary_Cal";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
                cmd.ExecuteNonQuery();
                SalaryTally();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //grdDetail.DataSource = ds.Tables[0];
                //grdDetail.DataBind();
                //Panel1.Visible = true;
            }

            catch (Exception ex)
            {
                string script2 = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                return;
            }
        }


        if (ddlReporttype.SelectedItem.Text == "Seprate Voucher")
        {
            try
            {

                sql = "Jct_Payroll_Salary_Cal_SepVch";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
                if (txtEmployee.Text != "")
                {
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
                }
                else
                {
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "All";
                }   
                cmd.ExecuteNonQuery();

                SalaryTally1();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //grdDetail.DataSource = ds.Tables[0];
                //grdDetail.DataBind();
                //Panel1.Visible = true;
            }

            catch (Exception ex)
            {
                string script2 = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                return;
            }
        }
    }


    public void txtEmployee_TextChanged(object sender, EventArgs e)
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

    public void SalaryTally()
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            sql = "SalaryCheck";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            con.Close();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


    public void SalaryTally1()
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            sql = "Jct_Payroll_Salary_Check_SepVch";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
            if (txtEmployee.Text != "")
            {
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
            }
            else
            {
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "All";
            }   
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            con.Close();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Salary_Calcuation.aspx");
    }

    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        if (ddlReporttype.SelectedItem.Text == "Salary")
        {
            try
            {
                sql = "Jct_Payroll_Salary_Cal_Freeze";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
                cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                Panel1.Visible = true;
            }

            catch (Exception ex)
            {
                string script2 = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                return;
            }
        }

        if (ddlReporttype.SelectedItem.Text == "Seprate Voucher")
        {
            try
            {
                sql = "Jct_Payroll_Salary_Cal_Freeze_SepVoc";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
                cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
                if (txtEmployee.Text != "")
                {
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
                }
                else
                {
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "All";
                }   
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                Panel1.Visible = true;
            }

            catch (Exception ex)
            {
                string script2 = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                return;
            }

        }
    }
    protected void ddlReporttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        enabledisable();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        try
        {
            sql = "Jct_Payroll_NonProcess_Salary";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;            
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }
}