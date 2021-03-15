using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_Jct_Payroll_Workflow_Request_Report : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Plantbind();
            Locationbind();
            LevelBind();
            BindItemListGridview();
        }
    }

    public void LevelBind()
    {
        SqlCommand sqlCmd = new SqlCommand("select 'All' as Level, 'All' as Level union  SELECT Level,Level FROM Jct_PayrollPortal_LevelMaster WHERE  STATUS='A' ORDER BY Level desc ", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "Level";
        DropDownList2.DataValueField = "Level";
        DropDownList2.DataBind();
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

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
        BindItemListGridview();
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
            ClearControls();
            CheckDesignation();
            BindItemListGridview();
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

    public void CheckDesignation1()
    {
        string sql = "Jct_Payroll_CommonDetail_Employee_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = TextBox1.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Label2.Text = dr[1].ToString();
            }
            dr.Close();
        }
    }

    /*             

     */

    public void BindItemListGridview()
    {
        string sql = "Jct_Payroll_WorkFlowGridview_FetchReport";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddlLocation.SelectedItem.Value;

        if (txtEmployee.Text != "")
        {
            cmd.Parameters.Add("@RequsterCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        }
        else
        {
            cmd.Parameters.Add("@RequsterCode", SqlDbType.VarChar, 10).Value = "All";
        }


        if (TextBox1.Text != "")
        {
            cmd.Parameters.Add("@AuthCode", SqlDbType.VarChar, 30).Value = TextBox1.Text;
        }
        else
        {
            cmd.Parameters.Add("@AuthCode", SqlDbType.VarChar, 30).Value = "All";
        }

        if (DropDownList2.SelectedItem.Text == "All")
        {
            cmd.Parameters.Add("@Level", SqlDbType.VarChar, 20).Value = "All";
        }
        else
        {
            cmd.Parameters.Add("@Level", SqlDbType.VarChar, 20).Value = DropDownList2.SelectedItem.Value;
        }
        cmd.ExecuteNonQuery();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Panel1.Visible = true;
        if (ds.Tables[0].Rows.Count == 0)
        {
            string script = "alert('No Record Found');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
    }

    public void ClearControls()
    {
        lblEmployeeName.Text = "";
    }

    public void ClearControls1()
    {
        Label2.Text = "";
    }

    //protected void lnksave_Click(object sender, EventArgs e)
    //{
    //    SqlCommand cmd;
    //    try
    //    {
    //        cmd = new SqlCommand("Jct_Payroll_WorkFlowGridview_Insert", obj.Connection());
    //        cmd.CommandType = CommandType.StoredProcedure;

    //        if (DropDownList2.Visible == true)
    //        {
    //            cmd.Parameters.Add("@Level", SqlDbType.Int).Value = DropDownList2.SelectedItem.Value;
    //        }
    //        else
    //        {
    //            cmd.Parameters.Add("@Level", SqlDbType.Int).Value = 0;
    //        }
    //        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 30).Value = ddlplant.SelectedItem.Value;
    //        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlLocation.SelectedItem.Value;
    //        cmd.Parameters.Add("@RequsterCode", SqlDbType.VarChar, 30).Value = txtEmployee.Text;
    //        if (DropDownList2.Visible == true)
    //        {
    //            cmd.Parameters.Add("@AuthCode", SqlDbType.VarChar, 30).Value = TextBox1.Text;
    //        }
    //        else
    //        {
    //            cmd.Parameters.Add("@AuthCode", SqlDbType.VarChar, 30).Value = "";
    //        }
    //        cmd.Parameters.Add("@AreaApply", SqlDbType.VarChar, 40).Value = DropDownList1.SelectedItem.Value;
    //        cmd.Parameters.Add("@EnterBy", SqlDbType.VarChar, 50).Value = Session["EmpCode"];
    //        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
    //        cmd.ExecuteNonQuery();
    //        string script = "alert('Records Saved Successfully !!!!!');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

    //    }
    //    catch (Exception ex)
    //    {
    //        string script2 = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
    //        return;
    //    }
    //    BindItemListGridview();
    //}

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Workflow_Request_Entry.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", GridView1);
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = TextBox1.Text.Split('|')[1].ToString();
            TextBox1.Text = employeecode;
            ClearControls1();
            CheckDesignation1();
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    protected void lnkFreeze0_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Workflow_Request_Report.aspx");
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindItemListGridview();
    }
    protected void lnkFreeze2_Click(object sender, EventArgs e)
    {
        BindItemListGridview();
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        BindItemListGridview();
    }

    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtype.SelectedItem.Value == "LeaveHierarchy")
        {
            Response.Redirect("Jct_Payroll_Workflow_RequestDeptwise_Report.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "LeaveHierarchy With Others WorkFlow")
        {
            Response.Redirect("Jct_Payroll_Workflow_Request_Report.aspx");
        }
    }
}