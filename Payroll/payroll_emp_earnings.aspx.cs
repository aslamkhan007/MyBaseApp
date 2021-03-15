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
    SqlTransaction tran;
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
            SqlCommand cmd = new SqlCommand("SELECT b.Desg_Long_Description,b.Designation_code FROM dbo.JCT_payroll_employees_master a JOIN JCT_payroll_designation_master b ON a.Designation=b.Designation_code WHERE b.STATUS='A' AND a.Active='Y' and a.status = 'A' AND EmployeeCode='" + ViewState["empcode"] + "'", obj.Connection());
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
            UnmappedPending();
        }
    }

    public void BindDataList()
    {
        //SqlCommand cmd = new SqlCommand(" SELECT   DISTINCT Allownce_Short_Description as allowances, allownce_sr_no  as Sr_no  FROM JCT_payroll_designation_parameter_master  a  JOIN   dbo.jct_payroll_earnings_detail b ON a.Designation_code=b.desigination_code  JOIN JCT_payroll_designation_master c ON  a.Designation_code=c.designation_code WHERE   a.STATUS='A' AND B.STATUS='A' AND a.Designation_code='" + ddldesigin.SelectedItem.Value + "'", obj.Connection());
        SqlCommand cmd = new SqlCommand("Jct_Payroll_Earnings_Components_Fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@desgination", SqlDbType.VarChar, 30).Value = ddldesigin.SelectedItem.Value;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }

    private void FillDataListItemValues(string empcode)
    {
        //Comment aslam Today
        //SqlCommand cmd = new SqlCommand("select a.allownce_short_description as allowances,isnull(b.allowance_value,0) as allowance_value,a.allownce_sr_no as Sr_No from JCT_payroll_designation_parameter_master a left outer join jct_payroll_earnings_detail b on a.allownce_sr_no=b.allownc_id and a.status=b.status and b.empcode='" + empcode + "' where a.designation_code= '" + ddldesigin.SelectedItem.Value + "' and a.status='A' ", obj.Connection());
        //Before changing Table 
        //SqlCommand cmd = new SqlCommand("SELECT  c.DESCRIPTION AS allowances ,ISNULL(b.allowance_value, 0) AS allowance_value ,a.paramtr_id AS Sr_No FROM    jct_payroll_allownc_subparamtr a LEFT OUTER JOIN jct_payroll_earnings_detail b ON a.paramtr_id = b.allownc_id AND a.status = b.status AND b.empcode = '" + empcode + "' LEFT OUTER JOIN dbo.jct_payroll_allownc_paramtr AS c ON a.paramtr_id = c.sr_no WHERE   a.designation_code = '" + ddldesigin.SelectedItem.Value + "' AND a.status = 'A' AND c.STATUS = 'A'", obj.Connection());
        SqlCommand cmd = new SqlCommand("SELECT  c.ComponentName AS allowances ,ISNULL(b.ComponentValue, 0) AS allowance_value ,a.ComponentParameterCode AS Sr_No FROM    dbo.Jct_Payroll_SubComponents a LEFT OUTER JOIN jct_payroll_earnings_detail b ON a.ComponentParameterCode = b.ComponentSrNo AND a.status = b.status AND b.EmployeeCode = '" + empcode + "' LEFT OUTER JOIN dbo.Jct_Payroll_Components AS c ON a.ComponentParameterCode = c.SrNo WHERE   a.DesignationCode = '" + ddldesigin.SelectedItem.Value + "' AND a.status = 'A' AND c.STATUS = 'A'", obj.Connection());
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
            //SqlCommand cmd = new SqlCommand("SELECT Allownce_Short_Description as allowances,allownce_sr_no  AS Sr_no FROM dbo.JCT_payroll_designation_parameter_master a JOIN JCT_payroll_designation_master b  ON a.Designation_code=b.designation_code WHERE a.Allownce_Short_Description<>'" + ExcludeAllowanceType + "'  and a.STATUS='A' AND B.STATUS='A' AND a.Designation_code='" + ddldesigin.SelectedItem.Value + "'", obj.Connection());
            //SqlCommand cmd = new SqlCommand("jct_payroll_allowance_Reimbursement_Fetch_Param");
            SqlCommand cmd = new SqlCommand("Jct_Payroll_Earnings_Components_Fetch_Param", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@desgination", SqlDbType.VarChar, 30).Value = ddldesigin.SelectedItem.Value;
            cmd.Parameters.Add("@Allownce_Short_Description", SqlDbType.VarChar, 30).Value = ExcludeAllowanceType;
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
            //FillDataListItemValues(empcode);
        }
        else
        {
            checkHouse = CheckHouseAllotment(empcode);

            if (string.IsNullOrEmpty(checkHouse))
            {
                // If no house is alloted, then HRA is given and no Colony Allowance is given
                ExcludeAllowanceType = "ColonyAllowance";
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

                //Comment on 27 dec 2016 for including sub_id in earning detail
                //sql = "SELECT value  FROM dbo.jct_payroll_allownc_subparamtr WHERE paramtr_id='" + AllowanceID + "' AND STATUS='A'";
                sql = "SELECT    ISNULL(SrNo, 0) ,value FROM      dbo.Jct_Payroll_SubComponents WHERE     ComponentParameterCode = '" + AllowanceID + "' AND STATUS = 'A' AND DesignationCode = '" + ddldesigin.SelectedItem.Value + "' union SELECT  ISNULL(SrNo, 0) ,value FROM    dbo.Jct_Payroll_SubComponents WHERE   ComponentParameterCode = '" + AllowanceID + "' AND STATUS = 'A' AND DesignationCode = 'DSG-100' ";
                obj1.FillList(ddlallw, sql);
            }


            // Comment Aslam Earlier

            //sql = "SELECT  ISNULL(SrNo, 0) ,value FROM    dbo.Jct_Payroll_SubComponents WHERE   ComponentParameterCode = '" + AllowanceID + "' AND DesignationCode = '"+ ddldesigin.SelectedItem.Value +"' AND STATUS = 'A'";
            ////obj1.FillList(ddlallw, sql);

            //if (obj1.CheckRecordExistInTransaction(sql))
            //{
            //    if (txtallowances.Visible == true)
            //    {
            //        txtallowances.Text = obj1.FetchValue(sql).ToString();                    
            //    }
            //    else if (ddlallw.Visible == true)
            //    {
            //        ddlallw.SelectedIndex = ddlallw.Items.IndexOf(ddlallw.Items.FindByValue(obj1.FetchValue(sql).ToString()));                  
            //    }
            //}


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

            //sql = "SELECT  CONVERT(NUMERIC, ISNULL(ComponentValue, 0)) AS allowance_value FROM    jct_payroll_earnings_detail WHERE   EmployeeCode = '" + ViewState["empcode"] + "' AND status = 'A' AND ComponentName = '" + AllowanceName + "'";
            sql = "SELECT  ComponentValue AS allowance_value FROM    jct_payroll_earnings_detail WHERE   EmployeeCode = '" + ViewState["empcode"] + "' AND status = 'A' AND ComponentName = '" + AllowanceName + "'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                if (txtallowances.Visible == true)
                {
                    txtallowances.Text = obj1.FetchValue(sql).ToString();
                    lnksave.Text = "Update";
                }
                else if (ddlallw.Visible == true)
                {
                    ddlallw.SelectedIndex = ddlallw.Items.IndexOf(ddlallw.Items.FindByText(obj1.FetchValue(sql).ToString().Trim()));
                    lnksave.Text = "Update";
                }
            }
        }
    }

    public bool CheckHouseSharing(string empcode)
    {
        bool sharing = false;

        SqlCommand cmd = new SqlCommand("SELECT distinct houseno,shared FROM JCT_payroll_employees_master WHERE employeecode=@empcode and status = 'A' and  active='Y'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (dr["shared"].ToString() == "Yes")
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
        SqlCommand cmd = new SqlCommand("SELECT distinct houseno FROM JCT_payroll_employees_master WHERE employeecode= @empcode and active='Y' And status = 'A'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (string.IsNullOrEmpty(dr["houseno"].ToString()))
                {
                    dr.Close();
                    return house;
                }
                else
                {
                    house = dr["houseno"].ToString();
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

    //public string subparamtr(int AllowanceId)
    //{// prob in allownces
    //    string sparameter = string.Empty;

    //    SqlCommand cmd = new SqlCommand("SELECT value  FROM dbo.Jct_Payroll_SubComponents WHERE ComponentParameterCode='" + AllowanceId + "' AND STATUS='A'", obj.Connection());
    //    cmd.CommandType = CommandType.Text;
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    if (dr.HasRows)
    //    {
    //        while (dr.Read())
    //        {
    //            if ((dr["value"].ToString() == "0"))
    //            {
    //                return sparameter;
    //            }
    //            else
    //            {
    //                sparameter = dr["value"].ToString();
    //            }
    //        }
    //    }

    //    dr.Close();
    //    return sparameter;
    //}

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
            tran = obj.Connection().BeginTransaction();
            //string cardno = Request.QueryString["cardno"].ToString();
            //string empcode = Request.QueryString["empcode"].ToString();
            //string empcode = "S-13823";
            //string cardno = "1386";
            if (lnksave.Text == "Save")
            {
                foreach (DataListItem dli in DataList1.Items)
                {
                    SqlCommand cmd = new SqlCommand("Jct_Payroll_Earnings_Detail_Insert", obj.Connection(), tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
                    cmd.Parameters.Add("@desigination_code", SqlDbType.VarChar, 10).Value = ddldesigin.SelectedItem.Value;
                    
                    //cmd.Parameters.Add("@BASIC", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtbasic.Text);
                    //cmd.Parameters.Add("@conveyance_scooter_allowance", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtscooterallowance.Text);
                    
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
                        //Comment on 27 dec 2016 for including sub_id in earning detail
                        //cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = allwanceddval;
                        cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = ((DropDownList)dli.FindControl("ddlallw")).SelectedItem.Text;
                    }


                    cmd.Parameters.Add("@createdby", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);

                    //Comment on 27 dec 2016 for including sub_id in earning detail
                    //New Line Added
                    if (!string.IsNullOrEmpty(allwanceddval))
                    {
                        cmd.Parameters.Add("@Allownce_sub_id", SqlDbType.Int).Value = Convert.ToInt32(((DropDownList)dli.FindControl("ddlallw")).SelectedValue);
                    }

                    cmd.ExecuteNonQuery();
                    string script = "alert('Record Saved Successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    lnksave.Enabled = false;
                   
                }
                tran.Commit();
                UnmappedPending();
            }
            else if (lnksave.Text == "Update")
            {
                foreach (DataListItem dli in DataList1.Items)
                {
                    SqlCommand cmd = new SqlCommand("Jct_Payroll_Earnings_Detail_Update", obj.Connection(), tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
                    cmd.Parameters.Add("@desigination_code", SqlDbType.VarChar, 10).Value = ddldesigin.SelectedItem.Value;
                    
                    //cmd.Parameters.Add("@BASIC", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtbasic.Text);
                    //cmd.Parameters.Add("@conveyance_scooter_allowance", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtscooterallowance.Text);
                    
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
                        //Comment on 27 dec 2016 for including sub_id in earning detail
                        //cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = allwanceddval;
                        cmd.Parameters.Add("@allowance_value", SqlDbType.Decimal, 2).Value = ((DropDownList)dli.FindControl("ddlallw")).SelectedItem.Text;
                    }

                    cmd.Parameters.Add("@createdby", SqlDbType.VarChar, 30).Value = (Session["Empcode"]);

                    //Comment on 27 dec 2016 for including sub_id in earning detail
                    //New Line Added
                    if (!string.IsNullOrEmpty(allwanceddval))
                    {
                        cmd.Parameters.Add("@Allownce_sub_id", SqlDbType.Int).Value = Convert.ToInt32(((DropDownList)dli.FindControl("ddlallw")).SelectedValue);
                    }

                    cmd.ExecuteNonQuery();

                }
                string script = "alert('Record updated Successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
             
                tran.Commit();
                UnmappedPending();
                lnksave.Enabled = false;
            }
        }
        catch (Exception exception)
        {
            tran.Rollback();
            //tran.Rollback();
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
        finally
        {
            obj.Connection().Close();
        }

    }

    protected void ddldesigin_SelectedIndexChanged1(object sender, EventArgs e)
    {
        empcode = ViewState["empcode"].ToString();
        //SqlCommand cmd = new SqlCommand("SELECT DISTINCT Basic ,StandardSpecialAllowance FROM    dbo.jct_payroll_earnings_detail WHERE   EmployeeCode= @empcode AND Status = 'A'", obj.Connection());
        //cmd.CommandType = CommandType.Text;
        //cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
        //SqlDataReader dr = cmd.ExecuteReader();
        //if (dr.HasRows)
        //{
        //    while (dr.Read())
        //    {
        //        txtbasic.Text = dr[0].ToString();
        //        txtscooterallowance.Text = dr[1].ToString();
        //    }
        //}
        //dr.Close();      
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



    ///////////////////New Code ////////////////////

    public void UnmappedUpdate()
    {
        foreach (GridViewRow gvRow in GridExtTask.Rows)
        {
            string AutoID = string.Empty;
            string comValue = string.Empty;
            string comName = string.Empty;
            int rowIndex = (int)gvRow.RowIndex;
            //RequestAmt = gvRow.Cells[6].Text.Replace("&nbsp;", "");
            comName = gvRow.Cells[0].Text.Replace("&nbsp;", "");
            comValue = gvRow.Cells[1].Text.Replace("&nbsp;", "");
            AutoID = gvRow.Cells[2].Text.Replace("&nbsp;", "");
            string sql = "Jct_Payroll_empEarning_UnmappedRecords_delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar, 20).Value = comName;
            cmd.Parameters.Add("@ComponentValue", SqlDbType.VarChar, 20).Value = comValue;
            cmd.Parameters.Add("@ComponentSrNo", SqlDbType.Int).Value = Convert.ToInt32(AutoID);
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = ViewState["empcode"];
            cmd.Parameters.Add("@updateBy", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            cmd.ExecuteNonQuery();
            string script = "alert('Record Deleted !!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            Panel1.Visible = false;
        }

    }



    public void UnmappedPending()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_empEarning_UnmappedRecords";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = ViewState["empcode"];
        Cmd.Parameters.Add("@desig", SqlDbType.VarChar, 10).Value = ddldesigin.SelectedItem.Value;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataTable dt = new DataTable();
        Da.Fill(dt);
        GridExtTask.DataSource = dt;
        GridExtTask.DataBind();

        if (dt.Rows.Count == 0)
        {
            Panel1.Visible = false;
            lnkapply.Enabled = false;
        }
        else
        {            
            Panel1.Visible = true;
            lnkapply.Enabled = true;
        }
    }

    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            UnmappedUpdate();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            return;
        }
    }
}
