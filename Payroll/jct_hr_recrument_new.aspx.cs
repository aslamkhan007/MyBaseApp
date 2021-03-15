using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
public partial class Payroll_jct_hr_recrument_new : System.Web.UI.Page
{ 
    Connection obj = new Connection();
    string sql = string.Empty;

    // ------------------------- page load
    protected void Page_Load(object sender, EventArgs e)
    {
        departmentbind();
        Designationbind();

        if (!IsPostBack)
        {
            bindgrid();

        }

    }

    // ------------------------- Department/Designation Binding
    
    public void departmentbind()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT Department_Long_Description FROM   JCT_payroll_department_master WHERE  STATUS='A'", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
         
        dddepartment.DataSource = ds;
        dddepartment.DataTextField = "Department_Long_Description";
        dddepartment.DataValueField = "Department_Long_Description";
        dddepartment.DataBind();
        con.Close();
    }

     public void Designationbind()
     {
         string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
         SqlConnection con = new SqlConnection(qry);
         con.Open();
         SqlCommand sqlCmd = new SqlCommand("SELECT Desg_Long_Description FROM   JCT_payroll_designation_master WHERE  STATUS='A' order by Desg_Long_Description ", con);
         sqlCmd.CommandType = CommandType.Text;
         SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
         DataSet ds = new DataSet();
         da.Fill(ds);
         ddldesg.DataSource = ds;
         ddldesg.DataTextField = "Desg_Long_Description";
         ddldesg.DataValueField = "Desg_Long_Description";
         ddldesg.DataBind();
         con.Close();
     }

    // -------------------------Insert

     protected void lnkadd_Click1(object sender, EventArgs e)
     {
         try
         {

             sql = "jct_hr_recrument";
             SqlCommand cmd = new SqlCommand(sql, obj.Connection());
             //con.Open();
             cmd.CommandType = CommandType.StoredProcedure;
             // cmd.Parameters.Add("@name", SqlDbType.VarChar, 10).Value = ViewState["deptcode"];
             cmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = txtname.Text;
             cmd.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = txtaddress.Text;
             cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 30).Value = txtqualification.Text;
             cmd.Parameters.Add("@organisation", SqlDbType.VarChar, 30).Value = txtorganisation.Text;
             cmd.Parameters.Add("@experience", SqlDbType.VarChar,30).Value = ddlexperience.Text;
             cmd.Parameters.Add("@contactno", SqlDbType.VarChar, 15).Value = txtcontactno.Text;
             cmd.Parameters.Add("@referance", SqlDbType.VarChar, 30).Value = txtreferance.Text;

             cmd.Parameters.Add("@mailid", SqlDbType.VarChar, 30).Value = txtmail.Text;
             cmd.Parameters.Add("@invdate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
             cmd.Parameters.Add("@department", SqlDbType.VarChar, 30).Value = dddepartment.SelectedValue;
             cmd.Parameters.Add("@designation", SqlDbType.VarChar, 30).Value = ddldesg.SelectedValue;
             cmd.Parameters.Add("@status", SqlDbType.VarChar, 25).Value = txtstatus.Text;
             cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
             cmd.ExecuteNonQuery();
             bindgrid();
             string script = "alert('Record saved.!!');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }
         catch (Exception ex)
         {
             string script = "alert('some error occurred!');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }

     }

     // -------------------------Update

     protected void lnkupdate_Click(object sender, EventArgs e)
     {
         try
         {

             //JCT_payroll_location_master
             sql = "jct_hr_recrument";
             SqlCommand cmd = new SqlCommand(sql, obj.Connection());
             //con.Open();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = txtname.Text;
             cmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = txtname.Text;
             cmd.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = txtaddress.Text;
             cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 30).Value = txtqualification.Text;
             cmd.Parameters.Add("@organisation", SqlDbType.VarChar, 30).Value = txtorganisation.Text;
             cmd.Parameters.Add("@experience", SqlDbType.VarChar, 30).Value = ddlexperience.Text;
             cmd.Parameters.Add("@contactno", SqlDbType.VarChar, 15).Value = txtcontactno.Text;
             cmd.Parameters.Add("@referance", SqlDbType.VarChar, 30).Value = txtreferance.Text;

             cmd.Parameters.Add("@mailid", SqlDbType.VarChar, 30).Value = txtmail.Text;
             cmd.Parameters.Add("@invdate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
             cmd.Parameters.Add("@department", SqlDbType.VarChar, 30).Value = dddepartment.SelectedValue;
             cmd.Parameters.Add("@designation", SqlDbType.VarChar, 30).Value = ddldesg.SelectedValue;
             cmd.Parameters.Add("@status", SqlDbType.VarChar, 25).Value = txtstatus.Text;
             cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Upd";
             cmd.ExecuteNonQuery();
             bindgrid();
             string script = "alert('Record updated.!!');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }
         catch (Exception ex)
         {
             string script = "alert('some error occurred!');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }
     }

   
    // -------------------------Delete
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
           try
            {

                //JCT_payroll_location_master
                sql = "jct_hr_recrument";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = txtname.Text;
                 cmd.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = txtaddress.Text;
                 cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 30).Value = txtqualification.Text;
                 cmd.Parameters.Add("@organisation", SqlDbType.VarChar,30).Value =  txtorganisation.Text;
                 cmd.Parameters.Add("@experience", SqlDbType.VarChar,30).Value = ddlexperience.Text;
                 cmd.Parameters.Add("@contactno", SqlDbType.VarChar, 15).Value = txtcontactno.Text;
                 cmd.Parameters.Add("@referance", SqlDbType.VarChar,30).Value = txtreferance.Text;

                 cmd.Parameters.Add("@mailid", SqlDbType.VarChar,30).Value = txtmail.Text;
                 cmd.Parameters.Add("@invdate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
                 cmd.Parameters.Add("@department", SqlDbType.VarChar,30).Value = dddepartment.SelectedValue;
                 cmd.Parameters.Add("@designation", SqlDbType.VarChar,30).Value = ddldesg.SelectedValue;
                 cmd.Parameters.Add("@status", SqlDbType.VarChar, 25).Value = txtstatus.Text;
                cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
                cmd.ExecuteNonQuery();
                bindgrid();
                string script = "alert('Record Update!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            catch (Exception ex)
            {
                string script = "alert('some error occurred!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }
      
       // -------------------------reset

        protected void lnkreset_Click(object sender, EventArgs e)
            {
                Response.Redirect("Payroll_jct_hr_recrument_new.aspx");
            }
    
     // ------------------------- grid bind

      private void bindgrid()
        {
            sql = " SELECT  Personname AS [Name] ,  ADDRESS AS[Address] ,Qualification  AS [Qualification],Organisation AS [Organisation],Experiance AS [Experiance]  ,ContactNo AS [ContactNo], Referance AS [Referance],Mailid as [Mailid],convert(varchar(10),Invdate,103) as [Interview Date],Department as [Department],Designation as [Designation],STATUS as [STATUS] FROM jct_hr_recrument_details WHERE entry_status='A'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridDetail.DataSource = ds.Tables[0];
            GridDetail.DataBind();
            Panel1.Visible = true;
        }


      protected void grdDetail_SelectedIndex(object sender, EventArgs e)
           
             {

                 txtname.Text = GridDetail.SelectedRow.Cells[1].Text;
                 txtaddress.Text = GridDetail.SelectedRow.Cells[2].Text;
                 txtqualification.Text = GridDetail.SelectedRow.Cells[3].Text;
                 txtorganisation.Text = GridDetail.SelectedRow.Cells[4].Text;
                 
                 ddlexperience.SelectedIndex = ddlexperience.Items.IndexOf(ddlexperience.Items.FindByText(GridDetail.SelectedRow.Cells[5].Text));

                 txtcontactno.Text = GridDetail.SelectedRow.Cells[6].Text;
                 txtreferance.Text = GridDetail.SelectedRow.Cells[7].Text;
                 txtmail.Text = GridDetail.SelectedRow.Cells[8].Text;
                 txtdate.Text = GridDetail.SelectedRow.Cells[9].Text;
                 
                 dddepartment.SelectedIndex = dddepartment.Items.IndexOf(dddepartment.Items.FindByText(GridDetail.SelectedRow.Cells[10].Text));
                 ddldesg.SelectedIndex = ddldesg.Items.IndexOf(ddldesg.Items.FindByText(GridDetail.SelectedRow.Cells[11].Text));
                 txtstatus.Text = GridDetail.SelectedRow.Cells[12].Text;

             }


       

         //private void If(string p)
         //{
         //    throw new NotImplementedException();
         //}
         protected void txtname_TextChanged(object sender, EventArgs e)
         {

         }
         protected void grdDetail_SelectedInd(object sender, EventArgs e)
         {
             txtname.Text = GridDetail.SelectedRow.Cells[1].Text;
             txtaddress.Text = GridDetail.SelectedRow.Cells[2].Text;
             txtqualification.Text = GridDetail.SelectedRow.Cells[3].Text;
             txtorganisation.Text = GridDetail.SelectedRow.Cells[4].Text;

             ddlexperience.SelectedIndex = ddlexperience.Items.IndexOf(ddlexperience.Items.FindByText(GridDetail.SelectedRow.Cells[5].Text));

             txtcontactno.Text = GridDetail.SelectedRow.Cells[6].Text;
             txtreferance.Text = GridDetail.SelectedRow.Cells[7].Text;
             txtmail.Text = GridDetail.SelectedRow.Cells[8].Text;
             txtdate.Text = GridDetail.SelectedRow.Cells[9].Text;

             dddepartment.SelectedIndex = dddepartment.Items.IndexOf(dddepartment.Items.FindByText(GridDetail.SelectedRow.Cells[10].Text));
             ddldesg.SelectedIndex = ddldesg.Items.IndexOf(ddldesg.Items.FindByText(GridDetail.SelectedRow.Cells[11].Text));
             txtstatus.Text = GridDetail.SelectedRow.Cells[12].Text;

         }
         //protected void lnkadd_Click1(object sender, EventArgs e)
         //{
         //    try
         //    {

         //        sql = "jct_hr_recrument";
         //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
         //        //con.Open();
         //        cmd.CommandType = CommandType.StoredProcedure;
         //        // cmd.Parameters.Add("@name", SqlDbType.VarChar, 10).Value = ViewState["deptcode"];
         //        cmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = txtname.Text;
         //        cmd.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = txtaddress.Text;
         //        cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 20).Value = txtqualification.Text;
         //        cmd.Parameters.Add("@organisation", SqlDbType.VarChar, 25).Value = txtorganisation.Text;
         //        cmd.Parameters.Add("@experience", SqlDbType.VarChar).Value = ddlexperience.Text;
         //        cmd.Parameters.Add("@contactno", SqlDbType.VarChar, 20).Value = txtcontactno.Text;
         //        cmd.Parameters.Add("@referance", SqlDbType.VarChar, 25).Value = txtreferance.Text;

         //        cmd.Parameters.Add("@mailid", SqlDbType.VarChar, 25).Value = txtmail.Text;
         //        cmd.Parameters.Add("@invdate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
         //        cmd.Parameters.Add("@department", SqlDbType.VarChar, 25).Value = dddepartment.SelectedValue;
         //        cmd.Parameters.Add("@designation", SqlDbType.VarChar, 25).Value = ddldesg.SelectedValue;
         //        cmd.Parameters.Add("@status", SqlDbType.VarChar,25).Value = txtstatus.Text;
         //        cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
         //        cmd.ExecuteNonQuery();
         //        bindgrid();
         //        string script = "alert('Record saved.!!');";
         //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         //    }
         //    catch (Exception ex)
         //    {
         //        string script = "alert('some error occurred!');";
         //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         //    }

         //}


         protected void lnkupdate_Click1(object sender, EventArgs e)
         {

             try
             {

                 //JCT_payroll_location_master
                 sql = "jct_hr_recrument";
                 SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                 //con.Open();
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = txtname.Text;                
                 cmd.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = txtaddress.Text;
                 cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 30).Value = txtqualification.Text;
                 cmd.Parameters.Add("@organisation", SqlDbType.VarChar, 30).Value = txtorganisation.Text;
                 cmd.Parameters.Add("@experience", SqlDbType.VarChar, 30).Value = ddlexperience.Text;
                 cmd.Parameters.Add("@contactno", SqlDbType.VarChar, 15).Value = txtcontactno.Text;
                 cmd.Parameters.Add("@referance", SqlDbType.VarChar, 30).Value = txtreferance.Text;

                 cmd.Parameters.Add("@mailid", SqlDbType.VarChar, 30).Value = txtmail.Text;
                 cmd.Parameters.Add("@invdate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
                 cmd.Parameters.Add("@department", SqlDbType.VarChar, 30).Value = dddepartment.SelectedValue;
                 cmd.Parameters.Add("@designation", SqlDbType.VarChar, 30).Value = ddldesg.SelectedValue;
                 cmd.Parameters.Add("@status", SqlDbType.VarChar, 25).Value = txtstatus.Text;
                 cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Upd";
                 cmd.ExecuteNonQuery();
                 bindgrid();
                 string script = "alert('Record updated.!!');";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
             }
             catch (Exception ex)
             {
                 string script = "alert('some error occurred!');";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
             }

         }


         protected void lnkdelete_Click1(object sender, EventArgs e)
         {
             try
             {

                 //JCT_payroll_location_master
                 sql = "jct_hr_recrument";
                 SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                 //con.Open();
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = txtname.Text;
                 cmd.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = txtaddress.Text;
                 cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 30).Value = txtqualification.Text;
                 cmd.Parameters.Add("@organisation", SqlDbType.VarChar, 30).Value = txtorganisation.Text;
                 cmd.Parameters.Add("@experience", SqlDbType.VarChar, 30).Value = ddlexperience.Text;
                 cmd.Parameters.Add("@contactno", SqlDbType.VarChar, 15).Value = txtcontactno.Text;
                 cmd.Parameters.Add("@referance", SqlDbType.VarChar, 30).Value = txtreferance.Text;

                 cmd.Parameters.Add("@mailid", SqlDbType.VarChar, 30).Value = txtmail.Text;
                 cmd.Parameters.Add("@invdate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
                 cmd.Parameters.Add("@department", SqlDbType.VarChar, 30).Value = dddepartment.SelectedValue;
                 cmd.Parameters.Add("@designation", SqlDbType.VarChar, 30).Value = ddldesg.SelectedValue;
                 cmd.Parameters.Add("@status", SqlDbType.VarChar, 25).Value = txtstatus.Text;
                 cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
                 cmd.ExecuteNonQuery();
                 bindgrid();
                 string script = "alert('Record Update!!');";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
             }
             catch (Exception ex)
             {
                 string script = "alert('some error occurred!');";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
             }
         }
}
