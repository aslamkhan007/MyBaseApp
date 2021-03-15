using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
public partial class Payroll_Jct_Payroll_SaviorLeaveInitialize_Entry : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string cardno;
    string empcode;
    string FlagCheck = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            Plantbind();
            Locationbind();
        }
    }

    /*
I also want to add a class that will calculate the total price of a collection of Product objects. I added a new class
file to the Models folder called LinqValueCalculator.cs and set the contents to match Listing 6-2.
Listing 6-2. The Contents of the LinqValueCalculator.cs File
using System.Collections.Generic;
using System.Linq;
namespace EssentialTools.Models {
public class LinqValueCalculator {
public decimal ValueProducts(IEnumerable<Product> products) {
return products.Sum(p => p.Price);
}
}
}
The LinqValueCalculator class defines a single method called ValueProducts, which uses the LINQ Sum method
to add together the value of the Price property of each Product object in an enumerable passed to the method
(a nice LINQ feature that I use often).
My final model class is ShoppingCart and it represents a collection of Product objects and uses a
LinqValueCalculator to determine the total value. I created a new class file called ShoppingCart.cs and added the
statements shown in Listing 6-3.
Listing 6-3. The contents of the ShoppingCart.cs File
using System.Collections.Generic;
namespace EssentialTools.Models {
public class ShoppingCart {
     
private LinqValueCalculator calc;
     
public ShoppingCart(LinqValueCalculator calcParam) {
calc = calcParam;
}
public IEnumerable<Product> Products { get; set; }
     
public decimal CalculateProductTotal() {
return calc.ValueProducts(Products);
}
}
}
     */

    public void Headerinfo()
    {
        SqlCommand cmd = new SqlCommand("JCT_Payroll_Initalise_LeaveBalance_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;                
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                headerEmployeeName.Text = dr["EmployeeName"].ToString();
                Headeremployeecode.Text = dr["EmpCode"].ToString();
                headercardno.Text = dr["Cardno"].ToString();
                headerleaveyr.Text = dr["LeaveYear"].ToString();                
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
    protected void txtEmployee_TextChanged(object sender, EventArgs e)
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

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            visibleenable();
            Headerinfo();
            FetchRecord();
            Panel4.Visible = true;
            Panel1.Visible = true;
            lnkapply.Enabled = true;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    public void visibleenable()
    {
        headerEmployeeName.Visible = true;
        Headeremployeecode.Visible = true;
        headercardno.Visible = true;
        headerleaveyr.Visible = true;
        Label153.Visible = true;
        Label152.Visible = true;
        Label150.Visible = true;
        Label151.Visible = true; 
    }

    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("JCT_Payroll_Initalise_LeaveBalance_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        //cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        //FlagCheck = cmd.Parameters["@Flag"].Value.ToString();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();

        //if (FlagCheck == "Old")
        //{
        //    lnkapply.Text = "Update";
        //}
        //else if (FlagCheck == "New")
        //{
        //    lnkapply.Text = "Save";
        //    string script = "alert('No Record Found.!! ');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //}
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                string bank = gvRow.Cells[0].Text;
                TextBox txt1 = (TextBox)gvRow.FindControl("txtAccnum");
                TextBox HandicapEmployee = (TextBox)gvRow.FindControl("txtHandicapEmployee");
                TextBox HandicapDependent = (TextBox)gvRow.FindControl("txtHandicapDependent");
                TextBox PublicProvidentFund = (TextBox)gvRow.FindControl("txtPublicProvidentFund");
                TextBox LifeInsuranceCorporation = (TextBox)gvRow.FindControl("txtLifeInsuranceCorporation");
                TextBox NationalSavingCertificate8 = (TextBox)gvRow.FindControl("txtNationalSavingCertificate8");
                TextBox HouseingLoanPayment = (TextBox)gvRow.FindControl("txtHouseingLoanPayment");
                TextBox INFRA = (TextBox)gvRow.FindControl("txtINFRA");
                TextBox UNITLN = (TextBox)gvRow.FindControl("txtUNITLN");
                TextBox Medical_Insurance = (TextBox)gvRow.FindControl("txtMedical_Insurance");
                TextBox SENIOR = (TextBox)gvRow.FindControl("txtSENIOR");
                TextBox NPS = (TextBox)gvRow.FindControl("txtNPS");


                SqlCommand cmd = new SqlCommand("JCT_Payroll_Initalise_LeaveBalance_Fetch", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        (txt1 as TextBox).Text = dr["L01_ADD"].ToString();
                        (HandicapEmployee as TextBox).Text = dr["L02_ADD"].ToString();
                        (HandicapDependent as TextBox).Text = dr["L03_ADD"].ToString();
                        (PublicProvidentFund as TextBox).Text = dr["L04_ADD"].ToString();
                        (LifeInsuranceCorporation as TextBox).Text = dr["L05_ADD"].ToString();
                        (NationalSavingCertificate8 as TextBox).Text = dr["L06_ADD"].ToString();
                        (HouseingLoanPayment as TextBox).Text = dr["L01"].ToString();
                        (INFRA as TextBox).Text = dr["L02"].ToString();
                        (UNITLN as TextBox).Text = dr["L03"].ToString();
                        (Medical_Insurance as TextBox).Text = dr["L04"].ToString();
                        (SENIOR as TextBox).Text = dr["L05"].ToString();
                        (NPS as TextBox).Text = dr["L06"].ToString();    
                    }
                }
                dr.Close();                
            }
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    
    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {                
                TextBox txt1 = (TextBox)gvRow.FindControl("txtAccnum");
                TextBox HandicapEmployee = (TextBox)gvRow.FindControl("txtHandicapEmployee");
                TextBox HandicapDependent = (TextBox)gvRow.FindControl("txtHandicapDependent");
                TextBox PublicProvidentFund = (TextBox)gvRow.FindControl("txtPublicProvidentFund");
                TextBox LifeInsuranceCorporation = (TextBox)gvRow.FindControl("txtLifeInsuranceCorporation");
                TextBox NationalSavingCertificate8 = (TextBox)gvRow.FindControl("txtNationalSavingCertificate8");
                TextBox HouseingLoanPayment = (TextBox)gvRow.FindControl("txtHouseingLoanPayment");
                TextBox INFRA = (TextBox)gvRow.FindControl("txtINFRA");
                TextBox UNITLN = (TextBox)gvRow.FindControl("txtUNITLN");
                TextBox Medical_Insurance = (TextBox)gvRow.FindControl("txtMedical_Insurance");
                TextBox SENIOR = (TextBox)gvRow.FindControl("txtSENIOR");
                TextBox NPS = (TextBox)gvRow.FindControl("txtNPS");

                    sql = "JCT_Payroll_Initalise_LeaveBalance_Update";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                    cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddllocation.SelectedItem.Value;
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;

                    cmd.Parameters.Add("@L01_ADD", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txt1.Text);
                    cmd.Parameters.Add("@L02_ADD", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(HandicapEmployee.Text);
                    cmd.Parameters.Add("@L03_ADD", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(HandicapDependent.Text);
                    cmd.Parameters.Add("@L04_ADD", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(PublicProvidentFund.Text);
                    cmd.Parameters.Add("@L05_ADD", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(LifeInsuranceCorporation.Text);
                    cmd.Parameters.Add("@L06_ADD", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(NationalSavingCertificate8.Text);
                    cmd.Parameters.Add("@L01", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(HouseingLoanPayment.Text);
                    cmd.Parameters.Add("@L02", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(INFRA.Text);
                    cmd.Parameters.Add("@L03", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(UNITLN.Text);
                    cmd.Parameters.Add("@L04", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(Medical_Insurance.Text);
                    cmd.Parameters.Add("@L05", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(SENIOR.Text);
                    cmd.Parameters.Add("@L06", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(NPS.Text);
                    //cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                    cmd.ExecuteNonQuery();
                    //bindgrid();
                    if (lnkapply.Text == "Save")
                    {
                        string script = "alert('Record  Saved.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        //lnkapply.Enabled = false;
                    }
                    else if (lnkapply.Text == "Update")
                    {
                        string script = "alert('Record  Updated.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        //lnkapply.Enabled = false;
                    }                
            }
        }

        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_SaviorLeaveInitialize_Entry.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        Excel();
    }

    public void Excel()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "JCt_Payroll_TaxComputation_ExportData";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; filename=Employee.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {

                Response.Write(tab + dr[i].ToString());

                tab = "\t";
            }

            Response.Write("\n");
        }
        Response.End();
    }
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Jct_Payroll_Taxdeclaration_Report.aspx");
    //}
}