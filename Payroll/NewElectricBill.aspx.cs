using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_NewElectricBill : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string loantype;
    string eleccode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            ComponentsLIst();
        }
    }

    public void ComponentsLIst()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_Variable_Components_List_electric", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldedtype.DataSource = ds;
        ddldedtype.DataTextField = "ComponentName";
        ddldedtype.DataValueField = "ComponentCode";
        ddldedtype.DataBind();

    }


    /*

Compile or Transpile?
The term transpiling has been around since the last century, but there is some confusion about its meaning. In
particular, there has been some confusion between the terms compilation and transpilation. Compilation describes
the process of taking source code written in one language and converting it into another language. Transpilation
is a specific kind of compilation and describes the process of taking source code written in one language and
transforming it into another language with a similar level of abstraction. So you might compile a high-level language
into an assembly language, but you would transpile TypeScript to JavaScript as they are similarly abstracted.
Other common examples of transpilation include C++ to C, CoffeeScript to JavaScript, Dart to JavaScript, and
PHP to C++.
Which Problems Does TypeScript Solve?
Since its first beta release in 1995, JavaScript (or LiveScript as it was known at the time it was released) has spread
like wildfire. Nearly every computer in the world has a JavaScript interpreter installed. Although it is perceived as
a browser-based scripting language, JavaScript has been running on web servers since its inception, supported
on Netscape Enterprise Server, IIS (since 1996), and recently on Node. JavaScript can even be used to write native
applications on operating systems such as Windows 8 and Firefox OS.
Despite its popularity, it hasn’t received much respect from developers—possibly because it contains many
snares and traps that can entangle a large program much like the tar pit pulling the mammoth to its death, as
described by Fred Brooks (1975). If you are a professional programmer working with large applications written in
JavaScript, you will almost certainly have rubbed up against problems once your program chalked up a few thousand
lines. You may have experienced naming conflicts, substandard programming tools, complex modularization,
unfamiliar prototypal inheritance that makes it hard to re-use common design patterns easily, and difficulty keeping a
readable and maintainable code base. These are the problems that TypeScript solves.
Because JavaScript has a C-like syntax, it looks familiar to a great many programmers. This is one of JavaScript’s
key strengths, but it is also the cause of a number of surprises, especially in the following areas:
• Prototypal inheritance
• Equality and type juggling
• Management of modules
• Scope
• Lack of types
Typescript solves or eases these problems in a number of ways. Each of these topics is discussed in this introduction.
Prototypal Inheritance
Prototype-based programming is a style of object-oriented programming that is mainly found in interpreted dynamic
languages. It was first used in a language called Self, created by David Ungar and Randall Smith in 1986, but it
has been used in a selection of languages since then. Of these prototypal languages, JavaScript is by far the most
widely known, although this has done little to bring prototypal inheritance into the mainstream. Despite its validity,
prototype-based programming is somewhat esoteric; class-based object orientation is far more commonplace and
will be familiar to most programmers.
TypeScript solves this problem by adding classes, modules, and interfaces. This allows programmers to transfer
their existing knowledge of objects and code structure from other languages, including implementing interfaces,
inheritance, and code organization. Classes and modules are an early preview of JavaScript proposals and because
TypeScript can compile to earlier versions of JavaScript it allows you to use these features independent of support for
the ECMAScript 6 specification. All of these features are described in detail in Chapter 1.  
     */


    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Visible_Invisible();
            CheckParameter();
            CheckExistingRecords();
            CheckDesignation();
        }
        catch (Exception exception)
        {
            lbdept.Text = "";
            lbdesign.Text = "";
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void AttendenceDate()
    {
        DateTime origDT = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        origDT = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(-1);
        txtefffrm.Text = Convert.ToDateTime(origDT).ToShortDateString();
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txteffto_CalendarExtender.SelectedDate = lastDate;
    }

    public void CheckDesignation()
    {
        string employeecode = txtEmployee.Text.Split('|')[1].ToString();
        string sql = "Jct_Payroll_Variable_Designation_Detail";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = employeecode;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                string desigination;
                string department;
                desigination = dr["Desg_Long_Description"].ToString();
                department = dr["Department_Long_Description"].ToString();
                lbdesign.Visible = true;
                lbdept.Visible = true;
                lbdept.Text = department;
                lbdesign.Text = desigination;
            }
            dr.Close();
        }
    }

    public void CheckExistingRecords()
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            string sql = "Jct_Payroll_Variable_Deduction_Fetch_electric";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@deduction_type", SqlDbType.VarChar, 10).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = employeecode;
            cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (txtdedamount.Visible == true)
                    {
                        txtdedamount.Text = dr[0].ToString();
                    }
                    if (ddldedamount.Visible == true)
                    {
                        CheckParameter();
                        ddldedamount.SelectedIndex = ddldedamount.Items.IndexOf(ddldedamount.Items.FindByText(dr[0].ToString().Trim()));
                    }
                    //txtefffrm.Text = dr[1].ToString();
                    //txteffto.Text = dr[2].ToString();
                    lnkUpdate.Visible = true;
                    lnkUpdate.Enabled = true;
                }
            }
            else
            {
                ClearControls();
                //string script = "alert('No Record Exists For This Month');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            dr.Close();
        }

        catch (Exception exception)
        {
            lbdept.Text = "";
            lbdesign.Text = "";
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    public void ClearControls()
    {
        lbdept.Text = "";
        lbdesign.Text = "";
        txtdedamount.Text = "";
    }


    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            SqlCommand cmd = new SqlCommand("jct_payroll_variable_deduction_insert_electric", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@deduction_type", SqlDbType.VarChar, 10).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = employeecode;
            if (txtdedamount.Visible == true)
            {
                cmd.Parameters.Add("@deduction_amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtdedamount.Text);
            }
            if (ddldedamount.Visible == true)
            {
                cmd.Parameters.Add("@deduction_amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(ddldedamount.SelectedItem.Text);
            }

            cmd.Parameters.Add("@Rate", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtdedamount0.Text);
            cmd.Parameters.Add("@amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtdedamount1.Text);

            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Saved Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lbdept.Text = "";
            lbdesign.Text = "";
            txtdedamount.Text = "";
            txtEmployee.Text = "";
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void Visible_Invisible()
    {
        ddldedamount.Visible = false;
        txtdedamount.Visible = false;
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {

        //if (ddldedtype.SelectedItem.Value == "COM-140")
        //{
        //    Response.Redirect("payroll_electricity_bill.aspx?eleccode= " + ddldedtype.SelectedItem.Value);
        //}

        Visible_Invisible();
        CheckParameter();
        //CheckExistingRecords();

    }

    public void CheckParameter()
    {
        string CheckValue = string.Empty;
        CheckValue = ddldedtype.SelectedItem.Value;
        string subparam = subparamtr(CheckValue);
        if (string.IsNullOrEmpty(subparam))
        {
            txtdedamount.Visible = true;
        }
        else
        {
            ddldedamount.Visible = true;
            string sql = "exec Jct_Payroll_Variable_Deduction_SubcomponentsLists  '" + CheckValue + "' ";
            obj1.FillList(ddldedamount, sql);
        }
    }

    public string subparamtr(string AllowanceId)
    {
        string sparameter = string.Empty;
        SqlCommand cmd = new SqlCommand("jct_payroll_Variable_Textbox_Visible_False", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ComponentParameterCode", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if ((dr["value"].ToString() == "0"))
                {
                    return sparameter;
                }
                else
                {
                    sparameter = dr["value"].ToString();
                }
            }
        }
        dr.Close();
        return sparameter;
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewElectricBill.aspx");
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            SqlCommand cmd = new SqlCommand("jct_payroll_variable_deduction_Update_electric", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@deduction_type", SqlDbType.VarChar, 10).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = employeecode;
            if (txtdedamount.Visible == true)
            {
                cmd.Parameters.Add("@deduction_amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtdedamount.Text);
            }
            if (ddldedamount.Visible == true)
            {
                cmd.Parameters.Add("@deduction_amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(ddldedamount.SelectedItem.Text);
            }


            cmd.Parameters.Add("@Rate", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtdedamount0.Text);
            cmd.Parameters.Add("@amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtdedamount1.Text);

            cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            string script = "alert('Record Updated Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lnkUpdate.Enabled = false;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void txtefffrm_TextChanged(object sender, EventArgs e)
    {
        DateTime origDT = Convert.ToDateTime(txtefffrm.Text);
        DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
        txteffto_CalendarExtender.SelectedDate = lastDate;
    }
    protected void LnkAuth_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_payroll_electricity_bill_FreezeStatus_electric", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
        cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = txteffto.Text;
        cmd.ExecuteNonQuery();
        string script = "alert('Record Freezed Sucesfully.!! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
}