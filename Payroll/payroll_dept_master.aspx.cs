using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PayRoll_payroll_dept_master : System.Web.UI.Page
{

    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ddlcat.SelectedItem.Text == "Department")
            {

                bindgriddept();
            }
            if (ddlcat.SelectedItem.Text == "SubDepartment")
            {
                bindgridsubdept();
            }
            txteff_to_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
        }

    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        if (ddlcat.SelectedItem.Text == "Department")
        {
            try
            {
                GenerateDeptCode();
                //JCT_payroll_location_master
                sql = "JCT_payroll_department_master_insert_del_update";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Department_code", SqlDbType.VarChar, 10).Value = ViewState["deptcode"];
                cmd.Parameters.Add("@Department_Long_Description", SqlDbType.VarChar, 100).Value = txtname.Text;
                cmd.Parameters.Add("@Department_Short_Description", SqlDbType.VarChar, 20).Value = txtshrtdesc.Text;
                cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_frm.Text);
                cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
                cmd.Parameters.Add("@creared_by", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
                cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
                cmd.ExecuteNonQuery();
                bindgriddept();
                string script = "alert('Record saved.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            catch (Exception ex)
            {
                string script = "alert('some error occurred!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }
        if (ddlcat.SelectedItem.Text == "SubDepartment")
        {
            try
            {
                GenerateSubDeptCode();
                //JCT_payroll_location_master
                sql = "JCT_payroll_Subdepartment_master_insert_del_update";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Department_code", SqlDbType.VarChar, 10).Value = ddldept.SelectedItem.Value;
                cmd.Parameters.Add("@SubDepartment_code", SqlDbType.VarChar, 20).Value = ViewState["subdeptcode"];
                cmd.Parameters.Add("@Subdepartment_Long_Description", SqlDbType.VarChar, 100).Value = txtname.Text;
                cmd.Parameters.Add("@SubDepartment_Short_Description", SqlDbType.VarChar, 20).Value = txtshrtdesc.Text;
                cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_frm.Text);
                cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
                cmd.Parameters.Add("@creared_by", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
                cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
                cmd.ExecuteNonQuery();
                bindgridsubdept();
                string script = "alert('Record saved.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                lbcode.Text = "SubdeptCode";
                lbcode.Visible = true;
                lbid.Text = ViewState["subdeptcode"].ToString();
                lbid.Visible = true;
               
            }
            catch (Exception ex)
            {
                string script = "alert('some error occurred!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }

    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        if (ddlcat.SelectedItem.Text == "Department")
        {
            try
            {
                
                //JCT_payroll_location_master
                sql = "JCT_payroll_department_master_insert_del_update";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Department_code", SqlDbType.VarChar, 10).Value =grdDetail.SelectedRow.Cells[1].Text;
                cmd.Parameters.Add("@Department_Long_Description", SqlDbType.VarChar, 100).Value = txtname.Text;
                cmd.Parameters.Add("@Department_Short_Description", SqlDbType.VarChar, 20).Value = txtshrtdesc.Text;
                cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_frm.Text);
                cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
                cmd.Parameters.Add("@creared_by", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
                cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
                cmd.ExecuteNonQuery();
                bindgriddept();
                string script = "alert('Record updated.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            catch (Exception ex)
            {
                string script = "alert('some error occurred!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }
        if (ddlcat.SelectedItem.Text == "SubDepartment")
        {
            try
            {
                
                //JCT_payroll_location_master
                sql = "JCT_payroll_Subdepartment_master_insert_del_update";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Department_code", SqlDbType.VarChar, 10).Value = ddldept.SelectedItem.Value;
                cmd.Parameters.Add("@SubDepartment_code", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[2].Text;
                cmd.Parameters.Add("@Subdepartment_Long_Description", SqlDbType.VarChar, 100).Value = txtname.Text;
                cmd.Parameters.Add("@SubDepartment_Short_Description", SqlDbType.VarChar, 20).Value = txtshrtdesc.Text;
                cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_frm.Text);
                cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
                cmd.Parameters.Add("@creared_by", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
                cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
                cmd.ExecuteNonQuery();
                bindgridsubdept();
                string script = "alert('Record saved.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                lbcode.Text = "SubdeptCode";
                lbcode.Visible = true;
                lbid.Text = ViewState["subdeptcode"].ToString();
                lbid.Visible = true;

            }
            catch (Exception ex)
            {
                string script = "alert('some error occurred!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        if (ddlcat.SelectedItem.Text == "Department")
        {
            try
            {

                //JCT_payroll_location_master
                sql = "JCT_payroll_department_master_insert_del_update";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Department_code", SqlDbType.VarChar, 10).Value = grdDetail.SelectedRow.Cells[1].Text;
                cmd.Parameters.Add("@Department_Long_Description", SqlDbType.VarChar, 100).Value = txtname.Text;
                cmd.Parameters.Add("@Department_Short_Description", SqlDbType.VarChar, 20).Value = txtshrtdesc.Text;
                cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_frm.Text);
                cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
                cmd.Parameters.Add("@creared_by", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
                cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
                cmd.ExecuteNonQuery();
                bindgriddept();
                string script = "alert('Record updated!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            catch (Exception ex)
            {
                string script = "alert('some error occurred!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }

        }
        if (ddlcat.SelectedItem.Text == "SubDepartment")
        {
            try
            {

                //JCT_payroll_location_master
                sql = "JCT_payroll_Subdepartment_master_insert_del_update";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                //con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Department_code", SqlDbType.VarChar, 10).Value = ddldept.SelectedItem.Value;
                cmd.Parameters.Add("@SubDepartment_code", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[2].Text;
                cmd.Parameters.Add("@Subdepartment_Long_Description", SqlDbType.VarChar, 100).Value = txtname.Text;
                cmd.Parameters.Add("@SubDepartment_Short_Description", SqlDbType.VarChar, 20).Value = txtshrtdesc.Text;
                cmd.Parameters.Add("@eff_from", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_frm.Text);
                cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteff_to.Text);
                cmd.Parameters.Add("@creared_by", SqlDbType.VarChar, 20).Value = "s-13823";//Session["EmpCode"];
                cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
                cmd.ExecuteNonQuery();
                bindgridsubdept();
                string script = "alert('Record updated.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                lbcode.Text = "SubdeptCode";
                lbcode.Visible = true;
                lbid.Text = ViewState["subdeptcode"].ToString();
                lbid.Visible = true;

            }
            catch (Exception ex)
            {
                string script = "alert('some error occurred!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }

    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_dept_master.aspx");
    }
    protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddlcat.SelectedItem.Text == "SubDepartment")
        {
            lbdept.Visible = true;
            ddldept.Visible = true;
            bindgridsubdept();
        }
        if (ddlcat.SelectedItem.Text == "Department")
        {

            //SqlCommand cmd = new SqlCommand("SELECT distinct Department_Long_Description AS[Department] ,Department_code AS [Deptcode] FROM JCT_payroll_department_master WHERE STATUS='A'", obj.Connection());
            //cmd.CommandType = CommandType.Text;

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //ddldept.DataSource = ds;
            //ddldept.DataTextField = "department";
            //ddldept.DataValueField = "deptcode";
            ddldept.DataBind();
            lbdept.Visible = false;
            ddldept.Visible = false;
            bindgriddept();
        }
    }
    protected void GenerateDeptCode()
    {
        #region Serial No. Code

        string str;
        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(Department_code ),CHARINDEX('-',max(Department_code ))+1,len(max(Department_code ))+4) from JCT_payroll_department_master", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["deptcode"] = "100";
                    ViewState["deptcode"] = "Dept-" + ViewState["deptcode"];
                }
                else
                {
                    ViewState["deptcode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["deptcode"] = "Dept-" + ViewState["deptcode"];
                }
            }

        }

        dr.Close();

        #endregion
    }

    protected void GenerateSubDeptCode()
    {
        #region Serial No. Code

        string str;
        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(SubDepartment_code ),CHARINDEX('-',max(SubDepartment_code ))+1,len(max(SubDepartment_code ))+8) from JCT_payroll_Subdepartment_master", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["subdeptcode"] = "100";
                    ViewState["subdeptcode"] = "SubDept-" + ViewState["subdeptcode"];
                }
                else
                {
                    ViewState["subdeptcode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["subdeptcode"] = "SubDept-" + ViewState["subdeptcode"];
                }
            }

        }

        dr.Close();
        //con.Close();

        #endregion
    }
    private void bindgriddept()
    {
        sql = " SELECT  Department_code AS [Deptcode] ,  Department_Long_Description AS[Department] ,Department_Short_Description  AS [ShortDesc],eff_from AS [EffectiveFrom],eff_to AS [EffectiveTo]  FROM JCT_payroll_department_master WHERE STATUS='A'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
    private void bindgridsubdept()
    {
        sql = "JCT_payroll_Subdepartment_master_select";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldept.Visible == true)
        {
            ddlcat.SelectedIndex = ddlcat.Items.IndexOf(ddlcat.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text));
            ddldept.SelectedIndex = ddldept.Items.IndexOf(ddldept.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text));

            txteff_frm.Text = grdDetail.SelectedRow.Cells[5].Text;
            txteff_to.Text = grdDetail.SelectedRow.Cells[6].Text;
            txtname.Text= grdDetail.SelectedRow.Cells[3].Text;
            txtshrtdesc.Text= grdDetail.SelectedRow.Cells[4].Text;
            lbcode.Text = "SubdeptCode";
            lbcode.Visible = true;
            lbid.Text = grdDetail.SelectedRow.Cells[2].Text;
            lbid.Visible = true;
        }
        else
        {
             ddlcat.SelectedIndex = ddlcat.Items.IndexOf(ddlcat.Items.FindByText(grdDetail.SelectedRow.Cells[1].Text));
            

            txteff_frm.Text = grdDetail.SelectedRow.Cells[4].Text;
            txteff_to.Text = grdDetail.SelectedRow.Cells[5].Text;
            txtname.Text= grdDetail.SelectedRow.Cells[2].Text;
            txtshrtdesc.Text = grdDetail.SelectedRow.Cells[3].Text;
            lbcode.Text = "DeptCode";
            lbcode.Visible = true;
            lbid.Text = grdDetail.SelectedRow.Cells[1].Text;
            lbid.Visible = true;
        }

    }
}