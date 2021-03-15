using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class PayRoll_payroll_emp_earnings : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string empcode ;
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
         
            SqlCommand cmd = new SqlCommand("SELECT b.Desg_Long_Description,b.Designation_code FROM dbo.JCT_payroll_employees_master a JOIN JCT_payroll_designation_master b ON a.Designation=b.Designation_code WHERE b.STATUS='A' AND a.Active='Y' AND Employee_Code='" + ViewState["empcode"] + "'", obj.Connection());
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

    //protected void ddldesigin_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string empcode = "S-13823";
    //    lbtxtall.Visible = true;
    //    CheckParameters(empcode);

        
    //    //BindDataList();
    //}

    public void BindDataList()
    {
        SqlCommand cmd = new SqlCommand(" SELECT   DISTINCT Allownce_Short_Description as allowances, allownce_sr_no  as Sr_no  FROM JCT_payroll_designation_parameter_master  a  JOIN   dbo.jct_payroll_earnings_detail b ON a.Designation_code=b.desigination_code  JOIN JCT_payroll_designation_master c ON  a.Designation_code=c.designation_code WHERE   a.STATUS='A' AND B.STATUS='A' AND a.Designation_code='" + ddldesigin.SelectedItem.Value + "'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }

    private void FillDataListItemValues(string empcode)
    {
     
       // SqlCommand cmd = new SqlCommand("select a.allownce_short_description as allowances,isnull(b.allowance_value,0) as allowance_value,a.allownce_sr_no as Sr_No from JCT_payroll_designation_parameter_master a left outer join jct_payroll_earnings_detail b on a.allownce_sr_no=b.allownc_id and a.status=b.status and b.empcode='" + empcode + "' where a.designation_code=(select distinct designation from JCT_payroll_employees_master where employee_code='" + empcode + "' and active='Y') and a.status='A' ", obj.Connection());
        SqlCommand cmd = new SqlCommand("select a.allownce_short_description as allowances,isnull(b.allowance_value,0) as allowance_value,a.allownce_sr_no as Sr_No from JCT_payroll_designation_parameter_master a left outer join jct_payroll_earnings_detail b on a.allownce_sr_no=b.allownc_id and a.status=b.status and b.empcode='" + empcode + "' where a.designation_code= '"+ddldesigin.SelectedItem.Value + "' and a.status='A' ", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }
        
        
    }

    public void BindDataList(string ExcludeAllowanceType)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT Allownce_Short_Description as allowances,allownce_sr_no  AS Sr_no FROM dbo.JCT_payroll_designation_parameter_master a JOIN JCT_payroll_designation_master b  ON a.Designation_code=b.designation_code WHERE a.Allownce_Short_Description<>'" + ExcludeAllowanceType + "'  and a.STATUS='A' AND B.STATUS='A' AND a.Designation_code='" + ddldesigin.SelectedItem.Value + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckParameters(string empcode)
    {
        bool checkShared = false;
        string checkHouse = string.Empty;
        string ExcludeAllowanceType = string.Empty;

        checkShared = CheckHouseSharing(empcode);

        if (checkShared)
        {
            BindDataList();

            // Fill record if already exists.
            FillDataListItemValues(empcode);
        }
        else
        {
            checkHouse = CheckHouseAllotment(empcode);

            if (string.IsNullOrEmpty(checkHouse))
            {
                // If no house is alloted, then HRA is given and no Colony Allowance is given
                ExcludeAllowanceType = "Colony Allowance";
                BindDataList(ExcludeAllowanceType);
                // Fill record if already exists.
            }
            else
            {
                // If house is alloted, then HRA is not given and Colony Allowance is given
                ExcludeAllowanceType = "HRA";
                BindDataList(ExcludeAllowanceType);
                // Fill record if already exists.
            }

        }
    }
 
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
      // string empcode = "S-13823";
        //ViewState["empcode"] = empcode;
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
               sql = "SELECT value  FROM dbo.jct_payroll_allownc_subparamtr WHERE paramtr_id='" + AllowanceID + "' AND STATUS='A'";
               obj1.FillList(ddlallw, sql);
           }

           sql = "select  Convert(numeric,isnull(allowance_value,0)) as allowance_value from jct_payroll_earnings_detail where empcode='" + ViewState["empcode"] + "' and status='A' and allowance_name='" + AllowanceName + "'";
          
           if (obj1.CheckRecordExistInTransaction(sql))
           {
               if (txtallowances.Visible == true)
               {
                   txtallowances.Text = obj1.FetchValue(sql).ToString();
                   lnksave.Text = "Update";
               }
               else if (ddlallw.Visible == true)
               {
                       //obj1.FillList(ddlallw, sql);
                       ddlallw.SelectedIndex = ddlallw.Items.IndexOf(ddlallw.Items.FindByValue(obj1.FetchValue(sql).ToString()));
                       lnksave.Text = "Update";
                 
               }
           }

           
        

       }
    }

    public bool CheckHouseSharing(string empcode)
    {
        bool sharing = false;

        SqlCommand cmd = new SqlCommand("SELECT distinct house_no,shared FROM JCT_payroll_employees_master WHERE employee_code=@empcode and active='Y'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (dr["shared"].ToString() == "YES")
                {
                    sharing = true;
                }
            }
        }
       
        dr.Close();
        return sharing;
    }

    public string CheckHouseAllotment(string empcode)
    {
        string house = string.Empty;

        SqlCommand cmd = new SqlCommand("SELECT distinct house_no FROM JCT_payroll_employees_master WHERE employee_code= @empcode and active='Y'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (string.IsNullOrEmpty(dr["house_no"].ToString()))
                {
                    dr.Close();
                    return house;
                }
                else
                {
                    house = dr["house_no"].ToString();
                }
            }
        }

        dr.Close();
        return house;
    }

    //public void ChecksubParameters(string empcode)
    //{

    //      string subparamrtname=subparamtr(empcode);
    //      if (string.IsNullOrEmpty(subparamrtname))
    //    {
          
    //       //find controls textbox (true)
          
    //         //dropdown false
    //    }
    //    else
    //    {
    //        //find controls dropdown (true)
    //          //dropdown true 
    //          //binddropdown
          

    //    }
    //}

    public string subparamtr(int AllowanceId)
    {// prob in allownces
        string sparameter = string.Empty;

        SqlCommand cmd = new SqlCommand("SELECT value  FROM dbo.jct_payroll_allownc_subparamtr WHERE paramtr_id='" + AllowanceId + "' AND STATUS='A'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (string.IsNullOrEmpty(dr["value"].ToString()))
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
            //string cardno = Request.QueryString["cardno"].ToString();
            //string empcode = Request.QueryString["empcode"].ToString();
            //string empcode = "S-13823";
            //string cardno = "1386";

            if (lnksave.Text == "Save")
            {
                foreach (DataListItem dli in DataList1.Items)
                {
                    SqlCommand cmd = new SqlCommand("jct_payroll_earnings_detail_insert", obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@desigination_code", SqlDbType.VarChar, 10).Value = ddldesigin.SelectedItem.Value;
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
                    cmd.Parameters.Add("@BASIC", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtbasic.Text);
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
                        cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = allwanceddval;
                    }
                    cmd.ExecuteNonQuery();
                    string script = "alert('Record Saved Successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                }
            }
            else if (lnksave.Text == "Update")
            {
                foreach (DataListItem dli in DataList1.Items)
                {
                    SqlCommand cmd = new SqlCommand("jct_payroll_earnings_detail_update", obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@desigination_code", SqlDbType.VarChar, 10).Value = ddldesigin.SelectedItem.Value;
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
                    cmd.Parameters.Add("@BASIC", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtbasic.Text);
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
                        cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = allwanceddval;
                    }
                    cmd.ExecuteNonQuery();

                }
                string script = "alert('Record updated Successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                
            }
            

            
            
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_emp_earnings.aspx");

    }
    //protected void lnkbtnbasicdetails_Click(object sender, EventArgs e)
    //{

    //}
    //protected void lnkbtnpersonal_Click(object sender, EventArgs e)
    //{

    //}
    //protected void lnkbtnearning_Click(object sender, EventArgs e)
    //{

    //}
    //protected void lnkbtndeduction_Click(object sender, EventArgs e)
    //{

    //}

    protected void ddldesigin_SelectedIndexChanged1(object sender, EventArgs e)
    {
        empcode = ViewState["empcode"].ToString();
   
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT basic FROM dbo.jct_payroll_earnings_detail WHERE empcode= @empcode AND STATUS='A'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtbasic.Text = dr[0].ToString();
                
            }
        }
        dr.Close();
        lbtxtall.Visible = true;
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
