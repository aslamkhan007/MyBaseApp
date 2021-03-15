using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_Jct_Payroll_Tax_Calculation : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            plantList();
            AttendenceDate();
            Plantbind();
            //Locationbind();
            //Departmentbind();
            AttendenceDates();
        }
    }


    public void AttendenceDates()
    {
        string sqlqry = "Jct_Payroll_Current_FIYear";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodates.Text = dr["FIYear"].ToString();
            }
            dr.Close();
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

    //public void Locationbind()
    //{
    //    SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
    //    sqlCmd.CommandType = CommandType.Text;
    //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlLocation.DataSource = ds;
    //    ddlLocation.DataTextField = "Location_description";
    //    ddlLocation.DataValueField = "Location_code";
    //    ddlLocation.DataBind();
    //}

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Jct_Payroll_Tax_Calculation_Freeze";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            //cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            cmd.Parameters.Add("@Installment", SqlDbType.Int).Value = TxtInstallment.Text;
            //cmd.Parameters.Add("@action", SqlDbType.VarChar, 10).Value = "Freeze";
            cmd.Parameters.Add("@host", SqlDbType.VarChar, 10).Value = Request.ServerVariables["REMOTE_ADDR"];
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
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Tax_Calculation.aspx");
    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        if (ddlReporttype.SelectedItem.Text == "Calculation")
        {
            //try
            //{
                sql = "Jct_Payroll_Tax_Calculation";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@FIYear", SqlDbType.VarChar,10).Value = txttodates.Text;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
                //cmd.Parameters.Add("@Empcode", SqlDbType.VarChar,10).Value = txtEmployee.Text;
                if (txtEmployee.Text != "")
                {
                    cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
                }
                else
                {
                    cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 50).Value = "All";
                }

                cmd.Parameters.Add("@Installment", SqlDbType.Int).Value = TxtInstallment.Text;
                //cmd.Parameters.Add("@action", SqlDbType.VarChar, 10).Value = "";
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }
                else
                {
                    grdDetail.DataSource = ds.Tables[0];
                    grdDetail.DataBind();
                    Panel1.Visible = true;
                }
                //lnkexcel.Enabled = true;
                //lnkFreeze0.Enabled = true;
            //}
            //catch (Exception ex)
            //{
            //    string script2 = "alert('" + ex.Message + "');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            //    return;
            //}
        }
        if (ddlReporttype.SelectedItem.Text == "Freeze")
        {
            try
            {
                //sql = "Jct_Payroll_Tax_Calculation_Freeze";
                //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 0;
                //cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                //cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
                ////cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                //cmd.Parameters.Add("@Installment", SqlDbType.Int).Value = TxtInstallment.Text;
                //cmd.Parameters.Add("@host", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                ////cmd.Parameters.Add("@action", SqlDbType.VarChar, 10).Value = "Freeze";


                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Jct_Payroll_Tax_Calculation_Freeze", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
                //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;
                cmd.Parameters.Add("@Installment", SqlDbType.Int).Value = TxtInstallment.Text;
                cmd.Parameters.Add("@host", SqlDbType.VarChar, 10).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();

                string script11 = "alert('Updated Successfully..');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script11, true);

                //cmd.ExecuteNonQuery();       
                //string script3 = "alert('Updated Successfully.!!');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script3, true);
            }

            catch (Exception ex)
            {
                string script2 = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                return;
            }
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
    public void plantList()
    {
        sql = "Jct_Payroll_Plantlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "ShortDescription";
        ddlplant.DataValueField = "PlantCode";
        ddlplant.DataBind();
    }
    //protected void LocationList()
    //{
    //    sql = "Jct_Payroll_Locationlist_Fetch";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlLocation.DataSource = ds;
    //    ddlLocation.DataTextField = "LocationDescription";
    //    ddlLocation.DataValueField = "LocationCode";
    //    ddlLocation.DataBind();
    //}

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LocationList();
    }
  
    protected void ddlLocation_SelectedIndexChanged1(object sender, EventArgs e)
    {
        txtEmployee.Text = "";
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }
}