using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Payroll_Payroll_Arear_PayDay_Entry : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            Plantbind();
            Locationbind();
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
    /*
     
     
     list-employees.component.ts
     
    import {Component, Oninit} from '@angular/core';
    import {Employee} from './models/employee.model';
    
     @Component({
     
     selector: 'app-list-employees' ;
     templateURl: 'list-employees.component.html';
     styleURLs: 'list-employees.component.css';
    
     })
     * 
    
    export class ListEmployeesComponent implements Oninit  {    
    employees: Employee[] = [
     {
     id: 1,
     name: 'abc',
     dateOfBirth: new Date('10/25/2020'),
     isActive: true, 
     
     }, 
     {
     id: 2, 
     name: 'def', 
     dateOfBirth: new Date('12/05/2020'), 
     isActive: false, 
     salary: 125855,           
     } ,
     
     {
     id: 3, 
     name: 'khf', 
     dateOfBirth:  new Date('02/25/2020'),
     isActive: false, 
     salary: 454423
     }      
     constructor () {}      
      
     ngOnInit(){
    
     }                   
    
     ];
    
     
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     ----------------
     * 
   list-employees.component.html
     * 
     * 
    <div class = "panel panel-primary" *ngFor = "let employee of employees">
            <div class = "panel-heading">
             <h3 class = "panel-title">EmployeesList </h3>
            </div>
             * 
    <div class = "panel-body"  >
     <div class = "col-xs-10" >
        <div class = "row vertical-align" >
     
            <div class = "col-xs-4">
             <img class = "imageclass" [src] = "employee.photopath" />
            </div>
    
    
            <div class = "col-xs-8">
               
              <div class = "row" >
     
                     <div class = "col-xs-6">
     
                    Gender
    
                     </div>
     
      
                     <div class= "col-xs-6">
     
                      : {{employee.gender}}
                       
                      </div>                             
     
              </div>                                 
     
      
         <div class = "row" >
    
                 <div class = "col-xs-6" >
     
                 Date Of Birth 
     
                 </div>
     
        
                 <div class = "col-xs-6">
              
                  : {{employee.dateOfBirth ! date}}
             
                 </div>
     
         </div>
                               
            </div>
    
    
        </div>
    </div>
     </div>
    
      
     
     * 
     
     * 
    ---------
    list-employees.component.css
    
     * 
    
      
     .imageClass 
      {
         widhth: 200 px;
        height: 100 px; 
     
      }
     * 
    
     .vertical-align
     {
     display: flex;
     align-items: center; 
      }
            
     
     }
     * 
     * 
     * 
    
     * 
    app.component.html
     * 
     
      <div class = "container">     
     <app-list-employees></app-list-employees>
     </div>
      
      
      
     *
     * 
     * 
     
     * 
    
   
     
     
     */

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
            ClearControls();
            CheckDesignation();
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckDesignation()
    {
        string sql = "Jct_Payroll_CommonDetail_Employee_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                lblEmployeeName.Text = dr[1].ToString();
            }
            dr.Close();
        }
    }


    /*

     app.module.ts
  
  
 
     import {BrowserModule} from  '@angular/browser-module'
     import {RouterModule,Routes}  from  '@angular/router';
 
 
 
     * 

     const Approutes: Routes = [
    {path: 'list', component: ListEmployeeComponent }, 
    {path: 'create', component: CreateEmployeeComponent}, 
    {path: '' , redirectTo: '/list', pathMatch:'full'}
      ];
  
 
 
  
     @NgModule({ 
     declaration: [
         ListEmployeeComponent,
         CreateEmployeeComponent 
     ],
     Import:[
            BrowserModule,
            RouterModule.forRoot(Approutes)
     ],
  
     providers:[],
     bootstrap: [AppComponent] 
      })
  
     export class AppModule {}
 

     * 
     * 
     App.Module.html
     * 
     * 
 
 
     <div class = "container">
        <nav class = "navbar navbar-default">
           <ul class = "nav navbar-nav">
                <li>
                      <a routerLink = "list">List  </a>
                </li>
                <li>
                     <a routerLink = "Create" >Create </a>
                </li>
 
           </ul>
        </nav>
   
      <router-outlet> </router-outlet>  
 
     </div>
  

     */
    public void ClearControls()
    {
        lblEmployeeName.Text = "";
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("Jct_Payroll_PayDays_Arrear_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ArrearType", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
            cmd.Parameters.Add("@DaysAmount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtdedamount.Text);
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
            cmd.ExecuteNonQuery();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            Panel1.Visible = true;
            con.Close();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtype.SelectedItem.Value == "PayDays")
        {
            Response.Redirect("Payroll_Arear_PayDay_Entry.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Fda")
        {
            Response.Redirect("Payroll_Arear_Fda_Entry.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Increment")
        {
            Response.Redirect("Payroll_Arear_Increment_Entry.aspx");
        }
        if (ddldedtype.SelectedItem.Value == "Confirm")
        {
            Response.Redirect("Payroll_Arear_Confirm_Entry.aspx");
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Arear_PayDay_Entry.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    /*
    create-employee.component.html
    
     * 
    <form #employeeform = "ngForm" (ngSubmit) = "saveEmployee(employeeform)" >
   <div class = "panel panel-primary">
    
       <div class = "panel-heading"> 
           <h3 class = "panel-title"> Create EMployee  </h3>
       </div>
      
      
        <div class = "panel-body"> 
           
            <div class = "form-group"> 
               <lable for = "name"> Name  </lable> 
               <input type = "text" name = "Name" id = "Name"  class = "form-control"  [(ngModel)] = "Name" >      
            </div> 
       
     
            <div class = "form-group">
                    <lable for = "email"> Email  </lable>
                    <input type = "text" name = "Email" id = "Email"  class = "form-control" [(ngModel)] = "Email"  > 
            </div>
    
     
            <div class = "form-group"> 
     
               <lable for = "phone"> PhoneNo  </lable>
                <input type = "text" class = "form-control" name = "phone" [(ngModel)] = "phone" >
        
           </div> 
     
     
           
    <div class = "form-group">  
           <lable> Contact Preference </lable>
            
         <div class = "form-control"> 
             
            <lable class = "radio-inline"> 
         
               <input type  = "radio" class= "form-control" name = "contactPreference" value = "Phone" [(ngModel)]= "contactPreference" >
                Phone     
            </lable> 
      
     
             <lable class = "radio-inline"> 
                <input type =  "radio" class = "form-control" name = "ContactPreference" value = "email"   [(ngModel)]  = "contactPreference" > 
                Email 
            </lable>  
             
            
        </div>        
          
    </div> 
     
     
       <div class = "form-group"> 
               <lable > Gender  </lable>       
             <div class = "form-control"> 
                    <label class = "radio-inline">
                    <input type = "radio" class = "form-control" name = "gender" value = "male"  [(ngModel)] = "gender"   > 
                    Male
                    </lable>
              
      
                    <lable class = "radio-inline">
                    <input type = "radio" name =  "gender" value = "female" class = "form-control"  [(ngModel)] = "gender"  >  
                    Female
                    </lable>
        
            </div>      
       </div> 
     
      
     
 <div class = "form-group"> 
            <lable for = "department">Department </lable>   
            <select id = "department" name = "department" class = "form-control" [(ngModel)] = "departments">      
             <option *ngFor = "let dept of departments" [value] = "dept.id" > {{dept.name}} </option>
             </select>      
 </div>
     
     
      
      
     
     
 </div>
     
     
    
     
        <div class= "panel-footer">
            <button type = "submit" class = "btn btn-primary" >Create  </button>
        </div>
     
   </div>
     
    </form>
    
    employee model form generated:   {{ employeeform.value | json   }}
     
    
     */



    /*
     create-employee.component.ts
         
    import {Department} from '../models/department.model'; 
    
     departments: Department[] = [
     {id:1,name: 'HRA'} , 
     {id:2, name: 'Payroll'}, 
     {id:3, name: 'dev'}     
     ];
     
              
     saveEmployee(employeeform : NgForm) {
 
     console.log(employeeform);
      }
 

 
 
     */



    /*
department.model.ts 
     
     
    export class Department {
     id: number;
     name: string ;      
     }
             
    
     */


    protected void lnkFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = ConfigurationManager.ConnectionStrings["misjctgen"].ToString();
            SqlConnection con = new SqlConnection(qry);
            con.Open();
            SqlCommand cmd = new SqlCommand("Jct_Payroll_PayDays_Arrear_Fetch_Freeze", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ArrearType", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value;
            cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }

    public void Excel()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_PayDays_Arrear_Fetch_Table", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ArrearType", SqlDbType.VarChar, 30).Value = ddldedtype.SelectedItem.Value;
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter Da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; AssetReport.xls";
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


}