using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_payroll_emp_Deductions : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string empcode;
    string cardno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            ViewState["cardno"] = Request.QueryString["cardno"].ToString();
            ViewState["empcode"] = Request.QueryString["empcode"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT b.Desg_Long_Description,b.Designation_code FROM dbo.JCT_payroll_employees_master a JOIN JCT_payroll_designation_master b ON a.Designation=b.Designation_code WHERE b.STATUS='A' and a.status = 'A'  AND a.Active='Y' AND EmployeeCode='" + ViewState["empcode"] + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ddldesigin.DataSource = ds;
            ddldesigin.DataTextField = "Desg_Long_Description";
            ddldesigin.DataValueField = "Designation_code";
            ddldesigin.DataBind();
            ddldesigin_SelectedIndexChanged1(sender, null);
        }
    }

    public void BindDataList()
    {
        SqlCommand cmd = new SqlCommand("Jct_Payroll_Deduction_Components_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@desgination", SqlDbType.VarChar, 30).Value = ddldesigin.SelectedItem.Value;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }

    public void CheckParameters(string empcode)
    {
        BindDataList();
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label allowances = (Label)e.Item.FindControl("lballw");
        Label prmid = (Label)e.Item.FindControl("lbprmID");
        TextBox txtallowances = (TextBox)e.Item.FindControl("txtallw");
        DropDownList ddlallw = (DropDownList)e.Item.FindControl("ddlallw");

        if (e.Item.ItemType == ListItemType.Item ||
          e.Item.ItemType == ListItemType.AlternatingItem)
        {
            System.Data.DataRowView drv =
            (System.Data.DataRowView)(e.Item.DataItem);
            string AllowanceName = drv.Row["allowances"].ToString();
            int AllowanceID = int.Parse(drv.Row["Sr_no"].ToString());

            string subparam = subparamtr(AllowanceID);
            if (string.IsNullOrEmpty(subparam))
            {
                txtallowances.Visible = true;
            }
            else
            {
                ddlallw.Visible = true;
                sql = "SELECT    ISNULL(SrNo, 0) ,value FROM      dbo.Jct_Payroll_SubComponents WHERE     ComponentParameterCode = '" + AllowanceID + "' AND STATUS = 'A' AND DesignationCode = '" + ddldesigin.SelectedItem.Value + "' UNION SELECT  ISNULL(SrNo, 0) ,ISNULL(value, 0) FROM    dbo.Jct_Payroll_SubComponents WHERE   ComponentParameterCode = '" + AllowanceID + "' AND DesignationCode = 'DSG-100' AND STATUS = 'A'";
                obj1.FillList(ddlallw, sql);
            }


            // Comment Aslam Today
            //sql = "SELECT  ISNULL(SrNo, 0) ,value FROM    dbo.Jct_Payroll_SubComponents WHERE   ComponentParameterCode = '" + AllowanceID + "' AND DesignationCode = '" + ddldesigin.SelectedItem.Value + "' AND STATUS = 'A' union SELECT  ISNULL(SrNo, 0) ,value FROM    dbo.Jct_Payroll_SubComponents WHERE   ComponentParameterCode = '" + AllowanceID + "' AND DesignationCode = 'DSG-100' AND STATUS = 'A'";            
            sql = "SELECT  ISNULL(value, 0)  FROM    dbo.Jct_Payroll_SubComponents WHERE   ComponentParameterCode = '" + AllowanceID + "' AND DesignationCode = '" + ddldesigin.SelectedItem.Value + "' AND STATUS = 'A' union SELECT  ISNULL(value, 0) FROM    dbo.Jct_Payroll_SubComponents WHERE   ComponentParameterCode = '" + AllowanceID + "' AND DesignationCode = 'DSG-100' AND STATUS = 'A'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                if (txtallowances.Visible == true)
                {
                    txtallowances.Text = obj1.FetchValue(sql).ToString();
                }
                else if (ddlallw.Visible == true)
                {
                    ddlallw.SelectedIndex = ddlallw.Items.IndexOf(ddlallw.Items.FindByValue(obj1.FetchValue(sql).ToString()));
                }
            }


            //sql = "select  Convert(numeric,isnull(ComponentValue,0)) as allowance_value from jct_payroll_Deduction_detail where EmployeeCode='" + ViewState["empcode"] + "' and status='A' and ComponentName ='" + AllowanceName + "'";
            sql = "SELECT  ComponentValue AS allowance_value FROM  jct_payroll_Deduction_detail where EmployeeCode='" + ViewState["empcode"] + "' and status='A' and ComponentName ='" + AllowanceName + "'";           
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                if (txtallowances.Visible == true)
                {
                    txtallowances.Text = obj1.FetchValue(sql).ToString();
                    lnksave.Text = "Update";
                }
                else if (ddlallw.Visible == true)
                {
                    //ddlallw.SelectedIndex = ddlallw.Items.IndexOf(ddlallw.Items.FindByText(obj1.FetchValue(sql).ToString()));
                    ddlallw.SelectedIndex = ddlallw.Items.IndexOf(ddlallw.Items.FindByText(obj1.FetchValue(sql).ToString().Trim()));
                    lnksave.Text = "Update";

                }
            }
        }
    }

    public string subparamtr(int AllowanceId)
    {// prob in allownces
        string sparameter = string.Empty;

        SqlCommand cmd = new SqlCommand("jct_payroll_Textbox_Visible_False", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ComponentParameterCode", SqlDbType.Int).Value = AllowanceId;
        cmd.Parameters.Add("@desig", SqlDbType.VarChar, 10).Value = ddldesigin.SelectedItem.Value;
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

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            if (lnksave.Text == "Save")
            {
                foreach (DataListItem dli in DataList1.Items)
                {
                    SqlCommand cmd = new SqlCommand("jct_payroll_Deduction_detail_insert", obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desigination_code", SqlDbType.VarChar, 10).Value = ddldesigin.SelectedItem.Value;
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
                    cmd.Parameters.Add("@createdby", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
                    TextBox txtallowances = (TextBox)dli.FindControl("txtallw");
                    DropDownList ddlallw = (DropDownList)dli.FindControl("ddlallw");
                    string allowncname = ((Label)dli.FindControl("lballw")).Text;
                    int prmid = Convert.ToInt32(((Label)dli.FindControl("lbprmID")).Text);
                    string allowanceval = ((TextBox)dli.FindControl("txtallw")).Text;
                    string allwanceddval = ((DropDownList)dli.FindControl("ddlallw")).Text;

                    cmd.Parameters.Add("@allownc_id", SqlDbType.VarChar, 30).Value = prmid;
                    cmd.Parameters.Add("@allowance_name", SqlDbType.VarChar, 30).Value = allowncname;
                    if (txtallowances.Visible == true)
                    {
                        cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = allowanceval;
                    }
                    if (ddlallw.Visible == true)
                    {
                        cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = ((DropDownList)dli.FindControl("ddlallw")).SelectedItem.Text;
                    }
                    if (!string.IsNullOrEmpty(allwanceddval))
                    {
                        cmd.Parameters.Add("@Allownce_sub_id", SqlDbType.Int).Value = Convert.ToInt32(((DropDownList)dli.FindControl("ddlallw")).SelectedValue);
                    }
                    cmd.ExecuteNonQuery();
                    string script = "alert('Record Saved Successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    lnksave.Enabled = false;
                }
            }
            else if (lnksave.Text == "Update")
            {
                foreach (DataListItem dli in DataList1.Items)
                {
                    SqlCommand cmd = new SqlCommand("jct_payroll_Deduction_detail_Update", obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desigination_code", SqlDbType.VarChar, 10).Value = ddldesigin.SelectedItem.Value;
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
                    cmd.Parameters.Add("@createdby", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);
                    TextBox txtallowances = (TextBox)dli.FindControl("txtallw");
                    DropDownList ddlallw = (DropDownList)dli.FindControl("ddlallw");
                    string allowncname = ((Label)dli.FindControl("lballw")).Text;
                    int prmid = Convert.ToInt32(((Label)dli.FindControl("lbprmID")).Text);
                    string allowanceval = ((TextBox)dli.FindControl("txtallw")).Text;
                    string allwanceddval = ((DropDownList)dli.FindControl("ddlallw")).Text;

                    cmd.Parameters.Add("@allownc_id", SqlDbType.VarChar, 30).Value = prmid;
                    cmd.Parameters.Add("@allowance_name", SqlDbType.VarChar, 30).Value = allowncname;
                    if (txtallowances.Visible == true)
                    {
                        cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = allowanceval;
                    }
                    if (ddlallw.Visible == true)
                    {
                        cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = ((DropDownList)dli.FindControl("ddlallw")).SelectedItem.Text;
                    }
                    if (!string.IsNullOrEmpty(allwanceddval))
                    {
                        cmd.Parameters.Add("@Allownce_sub_id", SqlDbType.Int).Value = Convert.ToInt32(((DropDownList)dli.FindControl("ddlallw")).SelectedValue);
                    }
                    cmd.ExecuteNonQuery();
                }
                string script = "alert('Record updated Successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                lnksave.Enabled = false;
            }
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void ddldesigin_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //lbtxtall.Visible = true;
        CheckParameters(empcode);
    }

    protected void ImageOfficial_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Payroll_Official_Detail.aspx?cardno=" + ViewState["cardno"] + "&empcode=" + ViewState["empcode"]);
    }

    protected void ImagePersonal_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("payroll_personal_detail.aspx?cardno=" + ViewState["cardno"] + "&empcode=" + ViewState["empcode"]);
    }

    protected void ImageEarnings_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("payroll_emp_earnings.aspx?cardno=" + ViewState["cardno"] + "&empcode=" + ViewState["empcode"]);
    }

    protected void ImageDeductions_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("payroll_emp_Deductions.aspx?cardno=" + ViewState["cardno"] + "&empcode=" + ViewState["empcode"]);
    }
}
