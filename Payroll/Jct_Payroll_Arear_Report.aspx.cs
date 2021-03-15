using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_Jct_Payroll_Arear_Report : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //AttendenceDate();
            AttendenceDate1();
            Plantbind();
            Locationbind();
        }
    }


    public void AttendenceDate1()
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


    //protected void txtefffrm_TextChanged(object sender, EventArgs e)
    //{
    //    DateTime origDT = Convert.ToDateTime(txtefffrm.Text);
    //    DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
    //    txteffto_CalendarExtender.SelectedDate = lastDate;
    //}            
      



 

//EDM (Entity Data Model): EDM consists of three main parts - Conceptual model, Mapping and Storage model.

//Conceptual Model: The conceptual model contains the model classes and their relationships. This will be independent from your database table design.

//Storage Model: The storage model is the database design model which includes tables, views, stored procedures, and their relationships and keys.

//Mapping: Mapping consists of information about how the conceptual model is mapped to the storage model.

//LINQ to Entities: LINQ-to-Entities (L2E) is a query language used to write queries against the object model. It returns entities, which are defined in the conceptual model. You can use your LINQ skills here.

//Entity SQL: Entity SQL is another query language (For EF 6 only) just like LINQ to Entities. However, it is a little more difficult than L2E and the developer will have to learn it separately.

//Object Service: Object service is a main entry point for accessing data from the database and returning it back. Object service is responsible for materialization, which is the process of converting data returned from an entity client data provider (next layer) to an entity object structure.

//Entity Client Data Provider: The main responsibility of this layer is to convert LINQ-to-Entities or Entity SQL queries into a SQL query which is understood by the underlying database. It communicates with the ADO.Net data provider which in turn sends or retrieves data from the database.

//ADO.Net Data Provider: This layer communicates with the database using standard ADO.Net.


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

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
    }

    public void ClearControls()
    {
        //lblEmployeeName.Text = "";
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecord();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddldedtype.SelectedItem.Value == "PayDays")
        //{
        //    Response.Redirect("Payroll_Arear_PayDay_Entry.aspx");
        //}

        //if (ddldedtype.SelectedItem.Value == "Fda")
        //{
        //    Response.Redirect("Payroll_Arear_Fda_Entry.aspx");
        //}

        //if (ddldedtype.SelectedItem.Value == "Increment")
        //{
        //    Response.Redirect("Payroll_Arear_Increment_Entry.aspx");
        //}
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Arear_Report.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    //protected void lnkFreeze_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
    //        SqlConnection con = new SqlConnection(qry);
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("Jct_Payroll_FDA_Arrear_Fetch_Freeze", con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@ArrearType", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value;
    //        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
    //        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
    //        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        string script2 = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
    //        return;
    //    }
    //}


    public void FetchRecord()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_Arrear_Report";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;        
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        Cmd.Parameters.Add("@ArerarType", SqlDbType.VarChar, 25).Value = ddldedtype.SelectedItem.Text;

        //Cmd.Parameters.Add("@deptcode", SqlDbType.VarChar, 50).Value = ddlDepartment.SelectedItem.Value;
        //if (txtEmployee.Text != "")
        //{
        //    Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
        //}
        //else
        //{
        //    Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "All";
        //}
        //Cmd.Parameters.Add("@Paymode", SqlDbType.VarChar, 10).Value = ddlPaymode.SelectedItem.Value;
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
    

}