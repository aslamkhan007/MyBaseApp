// using System;
// using System.Configuration;
// using System.Data;
// using System.Linq;
// using System.Web;
// using System.Web.Security;
// using System.Web.UI;
// using System.Web.UI.HtmlControls;
// using System.Web.UI.WebControls;
// using System.Web.UI.WebControls.WebParts;
// using System.Xml.Linq;
// using CrystalDecisions.CrystalReports.Engine;
// using System.Data.Sql;
// using System.Data.SqlClient;
// using CrystalDecisions.Shared;
// using CrystalDecisions.Reporting.WebControls;
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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Sql;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.Reporting.WebControls;


public partial class CrystalView : System.Web.UI.Page
{
    //Connection obj = new Connection();
    ReportDocument rpt = new ReportDocument();

    protected void Page_Unload(object sender, System.EventArgs e)
    {
        if (((rpt != null)))
        {
            if (rpt.IsLoaded == true)
            {
                rpt.Close();
                rpt.Dispose();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rpt.Dispose();
            rpt.Close();
            AttendenceDate1();
            Plantbind();
            Locationbind();
            turncateTable();
			Departmentbind();
			// CrystalReportViewer1.AllowedExportFormats = (int)CrystalDecisions.Shared.ViewerExportFormats.WordFormat;
		    CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
            //ConfigureCrystalReports();
            //CrystalReportViewer1.ReportSource = rpt;
            // CrystalReportViewer1.HasExportButton = false;			
        }
        FetchRecord();  
    }


    /* 
Angular applications are typically written in TypeScript. I introduce TypeScript in Chapter 6 and explain
how it works and why it is useful. TypeScript is a superscript of JavaScript, but one of its main advantages
is that it lets you write code using the latest JavaScript language specification with features that are not yet
supported in all of the browsers that can run Angular applications. One of the packages added to the project
in the previous section was the TypeScript compiler, which I set up to generate browser-friendly JavaScript
files automatically when a change to a TypeScript file is detected. To create a data model for the application,
I added a file called model.ts to the todo/app folder (TypeScript files have the .ts extension) and added the
code shown in Listing 2-7.
Listing 2-7. The Contents of the model.ts File in the todo/app Folder
var model = {
user: "Adam",
items: [{ action: "Buy Flowers", done: false },
{ action: "Get Shoes", done: false },
{ action: "Collect Tickets", done: true },
{ action: "Call Joe", done: false }]
};
One of the most important features of TypeScript is that you can just write “normal” JavaScript code as
though you were targeting the browser directly. In the listing, I used the JavaScript object literal syntax to
assign a value to a global variable called model. The data model object has a user property that provides the
name of the application’s user and an items property, which is set to an array of objects with action and
done properties, each of which represents a task in the to-do list.
When you save the changes to the file, the TypeScript compiler will detect the change and generate a file
called model.js, with the following contents:
var model = {
user: "Adam",
items: [{ action: "Buy Flowers", done: false },
{ action: "Get Shoes", done: false },
{ action: "Collect Tickets", done: true },
{ action: "Call Joe", done: false }]
};
This is the most important aspect of using TypeScript: you don’t have to use the features it provides,
and you can write entire Angular applications using just the JavaScript features that are supported by all
browsers, like the code in Listing 2-7.
But part of the value of TypeScript is that it converts code that uses the latest JavaScript language
features into code that will run anywhere, even in browsers that don’t support those features. Listing 2-8
shows the data model rewritten to use JavaScript features that were added in the ECMAScript 6 standard
(known as ES6).
Listing 2-8. Using ES6 Features in the model.ts File
export class Model {
user;
items;
constructor() {
this.user = "Adam";
this.items = [new TodoItem("Buy Flowers", false), 
     * 
new TodoItem("Get Shoes", false),
new TodoItem("Collect Tickets", false),
new TodoItem("Call Joe", false)]
}
}
export class TodoItem {
action;
done;
constructor(action, done) {
this.action = action;
this.done = done;
}
}
This is still standard JavaScript code, but the class keyword was introduced in a later version of the
language than most web application developers are familiar with because it is not supported by older
browsers. The class keyword is used to define types that can be instantiated with the new keyword to create
objects that have well-defined data and behavior.
Many of the features added in recent versions of the JavaScript language are syntactic sugar to help
programmers avoid some of the most common JavaScript pitfalls, such as the unusual type system. The class
keyword doesn’t change the way that JavaScript handles types; it just makes it more familiar and easier to use
for programmers experienced in other languages, such as C# or Java. I like the JavaScript type system, which
is dynamic and expressive, but I find working with classes more predictable and less error-prone, and they
simplify working with Angular, which has been designed around the latest JavaScript features.
■■Tip Don’t worry if you are not familiar with the features that have been added in recent versions of the
JavaScript specification. Chapters 5 and 6 provide a primer for writing JavaScript using the features that make
Angular easier to work with, and Chapter 6 also describes some useful TypeScript-specific features.
The export keyword relates to JavaScript modules. When using modules, each TypeScript or JavaScript
file is considered to be a self-contained unit of functionality, and the export keyword is used to identity
data or types that you want to use elsewhere in the application. JavaScript modules are used to manage the
dependencies that arise between files in a project and avoid having to manually manage a complex set of
script elements in the HTML file. See Chapter 7 for details of how modules work.
The TypeScript compiler processes the code in Listing 2-8 to generate JavaScript code that uses only
the subset of features that are widely supported by browsers. Even though I used the class and export
keywords, the model.js file generated by the TypeScript compiler produced JavaScript code that will work
in browsers that don’t implement that feature, like this:
"use strict";
var Model = (function () {
function Model() {
this.user = "Adam";
this.items = [new TodoItem("Buy Flowers", false),
new TodoItem("Get Shoes", false),
new TodoItem("Collect Tickets", false),
new TodoItem("Call Joe", false)];
}
return Model;
}());
exports.Model = Model;
var TodoItem = (function () {
function TodoItem(action, done) {
this.action = action;
this.done = done;
}
return TodoItem;
}());
exports.TodoItem = TodoItem;
I won’t keep showing you the code that the TypeScript compiler produces. The important point to
remember is that the compilation process translates new JavaScript features that are not widely supported
by browsers into standard features that are supported.
Creating a Template
I need a way to display the data values in the model to the user. In Angular, this is done using a template,
which is a fragment of HTML that contains instructions that are performed by Angular.
I created an HTML file called app.component.html in the todo/app folder and added the markup shown
in Listing 2-9. The name of the file follows the standard Angular naming conventions, which I explain later.
Listing 2-9. The Contents of the app.component.html File in the todo/app Folder
<h3 class="bg-primary p-a-1">{{getName()}}'s To Do List</h3>
I’ll add more elements to this file shortly, but a single h3 element is enough to get started. Including a
data value in a template is done using double braces—{{ and }}—and Angular evaluates whatever you put
between the double braces to get the value to display.
The {{ and }} characters are an example of a data binding, which means that they create a relationship
between the template and a data value. Data bindings are an important Angular feature, and you will see
more examples of them in this chapter as I add features to the example application and as I describe them
in detail in Part 2. In this case, the data binding tells Angular to invoke a function called getName and use the
result as the contents of the h3 element. The getName function doesn’t exist anywhere in the application at
the moment, but I’ll create it in the next section.
Creating a Component
An Angular component is responsible for managing a template and providing it with the data and logic it
needs. If that seems like a broad statement, it is because components are the parts of an Angular application
that do most of the heavy lifting. As a consequence, they can be used for all sorts of tasks.
At the moment, I have a data model that contains a user property with the name to display, and I have
a template that displays the name by invoking a getName property. What I need is a component to act as the
bridge between them. I added a JavaScript file called app.component.ts to the todo/app folder and added
the code shown in Listing 2-10.     
     */
    public void Departmentbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT 'All'  as DepartmentCode,'All' as  DepartmentLongDescription union SELECT Department_code as DepartmentCode,Department_long_Description as DepartmentLongDescription FROM JCT_payroll_department_master WHERE  STATUS='A'  order by DepartmentLongDescription", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.Items.Clear();
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "DepartmentLongDescription";
        ddldepartment.DataValueField = "DepartmentCode";
        ddldepartment.DataBind();
        con.Close();
    }

    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    //AttendenceDate1();
    //    //Plantbind();
    //    //Locationbind(); 
    //    //AttendenceDate1();
    //    //Plantbind();
    //    //Locationbind();  

    //    //string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
    //    //SqlConnection con = new SqlConnection(qry);
    //    //con.Open();
    //    //con.Close();

    //    if (!IsPostBack)
    //    {
    //        AttendenceDate1();
    //        Plantbind();
    //        Locationbind();
            
    //    }
    //    //FetchConnection();
    //    FetchRecord();  
    //}



    //private void ConfigureCrystalReports()
    //{
    //    rpt = new ReportDocument();
    //    rpt.Load(Server.MapPath("Payroll_Salary_Sheet.rpt"));
    //    rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctgen");
    //    CrystalReportViewer1.ReportSource = rpt;
    //    //string reportPath = Server.MapPath("reportname.rpt");
    //    //rpt.Load(reportPath);
    //    //ConnectionInfo connectionInfo = new ConnectionInfo();
    //    //connectionInfo.DatabaseName = "Northwind";
    //    //connectionInfo.UserID = "sa";
    //    //connectionInfo.Password = "pwd";
    //    //SetDBLogonForReport(connectionInfo, rpt);
    //    //CrystalReportViewer1.ReportSource = rpt;
    //}


    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("CrystalView.aspx");
    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        FetchRecord();    
    }
    public void FetchRecord()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        //SqlPass = "Jct_Payroll_Salary_Sheet_Cal";
        SqlPass = "Jct_Payroll_Monthly_Salary_Process_Print";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        //Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = "PLN-101";
        //Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = "LOC-111";
        //Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = 201801;
        //if (ddlplant.SelectedItem.Value == null)
        //{
        //}
        Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
		Cmd.Parameters.Add("@Department", SqlDbType.VarChar, 30).Value = ddldepartment.SelectedItem.Text;
        Cmd.Parameters.Add("@PaymentMode", SqlDbType.VarChar, 30).Value = ddlPaymode.SelectedItem.Text;
      
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        rpt.Load(Server.MapPath("Payroll_Salary_Sheet.rpt"));
        rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctgen");
        rpt.SetDataSource(ds.Tables[0]);
        rpt.SetDataSource(ds);
        CrystalReportViewer1.ReportSource = rpt;
        ds.Clear();
        con.Close();
    }
		
	public void turncateTable()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlPass = "Jct_Payroll_Monthly_Salary_Process_Print_Truncate";
        Cmd = new SqlCommand(SqlPass, con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.ExecuteNonQuery();     
        //SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        //DataSet ds = new DataSet();
        //Da.Fill(ds);
        //rpt.Load(Server.MapPath("Payroll_Salary_Sheet.rpt"));
        //rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctgen");
        //rpt.SetDataSource(ds.Tables[0]);
        //rpt.SetDataSource(ds);
        //CrystalReportViewer1.ReportSource = rpt;
        //ds.Clear();
        con.Close();
    }
	


    public void AttendenceDate1()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        string sqlqry = "Jct_Payroll_SalaryCal_Attendence_Month";
        SqlCommand cmd = new SqlCommand(sqlqry, con);
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
        con.Close();
    }





    //public void AttendenceDate()
    //{
    //    string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
    //    SqlConnection con = new SqlConnection(qry);
    //    con.Open();
    //    string sqlqry = "Jct_Payroll_Attendence_Month";
    //    SqlCommand cmd = new SqlCommand(sqlqry, con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    if (dr.HasRows == true)
    //    {
    //        while (dr.Read())
    //        {
    //            txtfromdate.Text = dr["FromDate"].ToString();
    //            txttodate.Text = dr["ToDate"].ToString();
    //        }
    //        dr.Close();
    //    }
    //    con.Close();
    //}

    //protected void txtfromdate_TextChanged(object sender, EventArgs e)
    //{
    //    DateTime origDT = Convert.ToDateTime(txtfromdate.Text);
    //    DateTime lastDate = new DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1);
    //    txttodate_CalendarExtender.SelectedDate = lastDate;
    //}


    public void Plantbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "plant_description";
        ddlplant.DataValueField = "plant_code";
        ddlplant.DataBind();        
        con.Close();
    }

    public void Locationbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT '' Location_description,'' Location_code union SELECT  Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();        
        con.Close();
    }


    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
				        if (ddlplant.SelectedItem.Value == "PLN-101")
        {
            Response.Redirect("CrystalViewhsp.aspx");
			// ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByValue(dr["PLN-100"].ToString().Trim()));
			// Plantbind();
			ddlplant.SelectedItem.Value = "PLN-101";
        }
        else
        {
 
        }
        Locationbind();
        //FetchRecord();
    }

    //protected void ExportPDF(object sender, EventArgs e)
    //{
    //    //ReportDocument crystalReport = new ReportDocument();
    //    //BindReport(crystalReport);
    //    string SqlPass = null;
    //    SqlCommand Cmd = new SqlCommand();
    //    string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
    //    SqlConnection con = new SqlConnection(qry);
    //    con.Open();
    //    SqlPass = "Jct_Payroll_Salary_Sheet_Cal";
    //    Cmd = new SqlCommand(SqlPass, con);
    //    Cmd.CommandType = CommandType.StoredProcedure;
    //    Cmd.Parameters.Add("@MONTHYEAR", SqlDbType.DateTime).Value = txttodate.Text;
    //    Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
    //    Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlLocation.SelectedItem.Value;
    //    SqlDataAdapter Da = new SqlDataAdapter(Cmd);
    //    DataSet ds = new DataSet();
    //    Da.Fill(ds);
    //    rpt.Load(Server.MapPath("Payroll_Salary_Sheet.rpt"));
    //    rpt.SetDatabaseLogon("itdev", "power", "misdev", "jctdev");
    //    rpt.SetDataSource(ds.Tables[0]);
    //    rpt.SetDataSource(ds);
    //    CrystalReportViewer1.ReportSource = rpt;
    //    ds.Clear();
    //    con.Close();

    //    //rpt.PrintOptions.PaperSize = PaperSize.

    //    //ExportFormatType formatType = ExportFormatType.NoFormat;
    //    //switch (rbFormat.SelectedItem.Value)
    //    //{
    //    //    case "Word":
    //    //        formatType = ExportFormatType.WordForWindows;
    //    //        break;
    //    //    case "PDF":
    //    //        formatType = ExportFormatType.PortableDocFormat;
    //    //        break;
    //    //    case "Excel":
    //    //        formatType = ExportFormatType.Excel;
    //    //        break;

    //    //    case "Text":
    //    //        formatType = ExportFormatType.Text;
    //    //        break;
    //    //}
    //    //rpt.ExportToHttpResponse(formatType, Response, true, "Crystal");       
    //    //Response.End();
    //}
 
}