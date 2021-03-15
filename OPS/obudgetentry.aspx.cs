﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class OPS_budgetentry : System.Web.UI.Page
{
     
    //Connection obj = new Connection();

    //SqlConnection obj = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TestReportDBConnectionString"].ConnectionString);
    SqlConnection obj = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ReportDBConnectionString"].ConnectionString);
    SqlTransaction Tran;
Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    { 
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            obj.Open();
            FillGrid();
            obj.Close();
        }
    }

    protected void FillGrid()
    {
        SqlCommand cmd = new SqlCommand("select budgetID as [BudgetID],entry_by as [EnteredBy],convert(varchar,budget_entry_dt,101) as [Dated],convert(varchar,eff_from,101) as [effective from],convert(varchar,eff_to,101) as [effective To],dept_name as [Department],budget_amt as [budget amount],BUDGET_TYPE AS BudgetType,hod as [HOD],balance_budget_amt as [balance Amount] from jct_ops_budget_entry where status='A'", obj);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    private void generatecode()
    {

        #region Serial No. Code

        string str;
        obj.Open();
        SqlCommand cmd = new SqlCommand("Select SUBSTRING(max(BudgetID),CHARINDEX('-',max( BudgetID))+1,len(max(BudgetID))+2) from jct_ops_budget_entry", obj);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["BudgetID"] = "100";
                    ViewState["BudgetID"] = "BUD-" + ViewState["BudgetID"];
                }
                else
                {
                    ViewState["BudgetID"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["BudgetID"] = "BUD-" + ViewState["BudgetID"];
                }
            }
        }
        
        dr.Close();
        obj.Close();
        //con.Close();

        #endregion
    }
     
    protected void lnkadd_Click(object sender, EventArgs e)
    {
string ret_value = string.Empty;
        SqlCommand cmd = new SqlCommand("jct_ops_budget_date_validation", obj);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
        cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
        obj.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ret_value = dr[0].ToString();
            }
        }

        if (ret_value.ToString() == "1")
        {
            string script2 = "alert('Select a Valid Date');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            dr.Close();
            obj.Close();
            return;
        }
        dr.Close();
        obj.Close();
        try
        {
            if (txtbdgamt.Text == "" || txtefffrm.Text == "" || txteffto.Text == "")
            {
                string script2 = "alert('error occured!!! All fields are Compulsory');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }
            else
            {
			    generatecode();
                obj.Open();
                //Tran = obj.BeginTransaction();

                string budget_no = string.Empty;

                cmd = new SqlCommand("jct_ops_budget_insert", obj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@budgetID", SqlDbType.VarChar, 20).Value = ViewState["BudgetID"];
                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = txteffto.Text;
                cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = txtefffrm.Text;
                cmd.Parameters.Add("@dept_name", SqlDbType.VarChar, 30).Value = ddldept.SelectedItem.Value;
                cmd.Parameters.Add("@budget_amt", SqlDbType.Decimal).Value = txtbdgamt.Text;
                cmd.Parameters.Add("@hod", SqlDbType.VarChar, 30).Value = ddlhod.SelectedItem.Value;
                //cmd.Parameters.Add("@budget_no", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@budget_type", SqlDbType.VarChar,30).Value = ddlBudgetType.SelectedItem.Text;
                //cmd.Parameters.Add("@period", SqlDbType.VarChar, 30).Value = ddlselect.SelectedItem.Text;
                //cmd.Parameters.Add("@period_desc", SqlDbType.VarChar, 30).Value = ddlperioddesc.Items.Count <=0 ? null : ddlperioddesc.SelectedItem.Text;
                //cmd.Parameters.Add("@period_value", SqlDbType.Int).Value = ddlperioddesc.Items.Count <=0 ? null : ddlperioddesc.SelectedItem.Value;
                //cmd.Transaction = Tran;
                cmd.ExecuteNonQuery();
                //budget_no = cmd.Parameters["@budget_no"].Value.ToString();
                for (int i = 0; i <= chklist.Items.Count - 1; i++)
                {
                    if (chklist.Items[i].Selected == true)
                    {
                        cmd = new SqlCommand("jct_ops_indenter_tab_insert", obj);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@budgetID", SqlDbType.VarChar, 30).Value = ViewState["BudgetID"];
                        cmd.Parameters.Add("@indenter_code", SqlDbType.VarChar, 30).Value = chklist.Items[i].Value;
                       // cmd.Transaction = Tran;
                        cmd.ExecuteNonQuery();
                    }
                }

                cmd = new SqlCommand("select budgetID as [BudgetID],c.empname as [EnteredBy],convert(varchar,budget_entry_dt,101) as [Dated],convert(varchar,eff_to,101) as [effective To],convert(varchar,eff_from,101) as [effective from],dept_name as [Department],budget_amt as [budget amount],b.empname as [HOD],balance_budget_amt as [balance Amount] from jct_ops_budget_entry a join test2k.jctdev.dbo.jct_empmast_base b on a.hod=b.empcode join test2k.jctdev.dbo.jct_empmast_base c on c.empcode=a.entry_by  where a.status='a'", obj);
                cmd.CommandType = CommandType.Text;
                //cmd.Transaction = Tran;
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                //Tran.Commit();

                FillGrid();
                obj.Close();

                string script2 = "alert('Record Saved Successfully.!!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            }
		        txtbdgamt.Text="";
                txtefffrm.Text="";
                txteffto.Text="";
                ddlhod.DataSource = null;
                ddlhod.DataBind();
                ddldept.DataSource = null;
                ddldept.DataBind();
        }
        catch (Exception ex)
        {
            //Tran.Rollback();
            string script2 = "alert('error occured!!! " + ex.Message + " ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }
    }

    protected void ddldept_TextChanged(object sender, EventArgs e)
    {
        obj.Open();
        SqlCommand cmd = new SqlCommand("select distinct c.req_emp_no,a.empname from test2k.jctdev.dbo.jct_empmast_base  a join test2k.jctdev.dbo.deptmast b on a.deptcode=b.deptcode join test2k.jctdev.dbo.jct_indentor_code c  on replace(a.empcode,'-','')= c.req_emp_no where a.active='Y' and a.company_code='JCT00LTD' and  a.deptcode= '" + ddldept.SelectedItem.Value + "'", obj);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        chklist.DataSource = ds.Tables[0];
        chklist.DataTextField = "empname";
        chklist.DataValueField = "req_emp_no";
        chklist.DataBind();
 
		for (int i = 0; i <= chklist.Items.Count - 1; i++)
        { 
            chklist.Items[i].Selected = true;
        }
 
        ddlhod.DataSourceID = "SqlDataSource2";
        ddlhod.DataBind();
        obj.Close();
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
      ViewState["ID"] = grdDetail.SelectedRow.Cells[1].Text;
      txteffto.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""); 
      txtefffrm.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
      ddldept.SelectedIndex = ddldept.Items.IndexOf(ddldept.Items.FindByValue(grdDetail.SelectedRow.Cells[6].Text));
      ddlhod.SelectedIndex = ddlhod.Items.IndexOf(ddlhod.Items.FindByText(grdDetail.SelectedRow.Cells[8].Text));
      txtbdgamt.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

      obj.Open();
      SqlCommand cmd = new SqlCommand("select distinct c.req_emp_no,a.empname from test2k.jctdev.dbo.jct_empmast_base  a join test2k.jctdev.dbo.deptmast b on a.deptcode=b.deptcode join test2k.jctdev.dbo.jct_indentor_code c  on replace(a.empcode,'-','')= c.req_emp_no where a.active='Y' and a.company_code='JCT00LTD' and  a.deptcode= '" + ddldept.SelectedItem.Value + "'", obj);
      cmd.CommandType = CommandType.Text;
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      da.Fill(ds);
      chklist.DataSource = ds.Tables[0];
      chklist.DataTextField = "empname";
      chklist.DataValueField = "req_emp_no";
      chklist.DataBind();
      obj.Close();
       
      for (int i = 0; i <= chklist.Items.Count - 1; i++)
      { 
        chklist.Items[i].Selected = true;
      }
        lnkadd.Enabled = false;
    }
   
    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        string sql = string.Empty;
        string return_val = string.Empty;
        SqlCommand cmd;

        sql = "jct_ops_budget_update";
        cmd = new SqlCommand(sql, obj);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@budgetID", SqlDbType.VarChar, 10).Value = ViewState["ID"];
        cmd.Parameters.Add("@updated_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
        cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = txteffto.Text;
        cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = txtefffrm.Text;
        cmd.Parameters.Add("@dept_code", SqlDbType.VarChar, 30).Value = ddldept.SelectedItem.Value;
        cmd.Parameters.Add("@budget_amt", SqlDbType.Decimal).Value = txtbdgamt.Text;
        cmd.Parameters.Add("@hod", SqlDbType.VarChar, 30).Value = ddlhod.SelectedItem.Value;
        //cmd.Parameters.Add("@return_val", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@budget_type", SqlDbType.VarChar,50).Value = ddlBudgetType.SelectedItem.Text;

        try
        {
            obj.Open();
            cmd.ExecuteNonQuery();
        }
        catch
        { }

        //return_val = cmd.Parameters["@return_val"].Value.ToString();
 
        for (int i = 0; i <= chklist.Items.Count - 1; i++)
        {
            if (chklist.Items[i].Selected == true)
            {
                cmd = new SqlCommand("jct_ops_indenter_tab_insert", obj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@budgetID", SqlDbType.VarChar, 30).Value = ViewState["ID"];
                cmd.Parameters.Add("@indenter_code", SqlDbType.VarChar, 30).Value = chklist.Items[i].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                { 
                }
                
            }
        }

        cmd = new SqlCommand("select  budget_no as [BudgetNo],entry_by as [EnteredBy],convert(varchar,budget_entry_dt,101) as [Dated],convert(varchar,eff_to,101) as [effective To],convert(varchar,eff_from,101) as [effective from],dept_name as [Department],budget_amt as [budget amount],hod as [HOD],balance_budget_amt as [balance Amount] from jct_ops_budget_entry where status='a'", obj);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        FillGrid();

        obj.Close();

        string script2 = "alert('Record Updated Successfully !');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
         
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        try
        {
            string sql;

            obj.Open();
            SqlCommand cmd;
            sql = "jct_ops_budget_delete";
            cmd = new SqlCommand(sql, obj);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@budgetID", SqlDbType.VarChar, 20).Value = ViewState["ID"];
            cmd.Parameters.Add("@deleted_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("select budget_no as [BudgetNo],entry_by as [EnteredBy],convert(varchar,budget_entry_dt,101) as [Dated],convert(varchar,eff_to,101) as [effective To],convert(varchar,eff_from,101) as [effective from],dept_name as [Department],budget_amt as [budget amount],hod as [HOD],balance_budget_amt as [balance Amount] from jct_ops_budget_entry where status='a'", obj);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();

            FillGrid();
            obj.Close();
            string script2 = "alert('Record Deleted Successfully !');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }
        catch
        { 
        
        }
 
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("budgetentry.aspx");
    }
}
    