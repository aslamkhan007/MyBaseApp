using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_payroll_personal_detail : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string cardno;
    string empcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Empcode"] == "")
        //{
        //    Response.Redirect("~/Login.aspx");
        //}

        // ddlstate.DataBind();
        if (!IsPostBack)
        {
            cardno = Request.QueryString["cardno"].ToString();
            empcode = Request.QueryString["empcode"].ToString();
            ViewState["cardno"] = cardno;
            ViewState["empcode"] = empcode;
            try
            {
                Bankmaster();
                //ddlstate.DataBind();
                string sql = "SELECT * FROM  jct_payroll_emp_address_detail  WHERE EmployeeCode = @salarycode AND cardno=@cardno and status='A'  and AddressType = '" + ddlAddressType.SelectedItem.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.Parameters.Add("@cardno", SqlDbType.VarChar, 30).Value = ViewState["cardno"];
                cmd.Parameters.Add("@salarycode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ddlAddressType.SelectedIndex = ddlAddressType.Items.IndexOf(ddlAddressType.Items.FindByText(dr["AddressType"].ToString()));
                        TxtAddress1.Text = dr["Address1"].ToString();
                        TxtAddress2.Text = dr["Address2"].ToString();
                        TxtAddress3.Text = dr["Address3"].ToString();
                        ddlcoutry.SelectedIndex = ddlcoutry.Items.IndexOf(ddlcoutry.Items.FindByText(dr["Country"].ToString()));
                        txtstate.Text = dr["State"].ToString();
                        txtcity.Text = dr["City"].ToString();
                        TxtPri_Mobile.Text = dr["PrimaryMobileNo"].ToString();
                        txtlandline.Text = dr["PrimaryLandlineNo"].ToString();
                        TxtSecondaryLandline.Text = dr["SecondaryLandlineNo"].ToString();
                        TxtEmailID.Text = dr["EmailID"].ToString();
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                string script = "alert(''" + ex.Message + "'');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
    }

    public void Bankmaster()
    {
        sql = "Jct_Payroll_Bank_EmployeeWIse_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    //protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    sql = "SELECT  DISTINCT City FROM JCTGEN..JCT_EPOR_STATE_MASTER   WHERE state  like '" + ddlstate.SelectedItem.Value + "'";
    //    obj1.FillList(ddlcity, sql);
    //    //SqlCommand sqlCmd = new SqlCommand("SELECT  DISTINCT City FROM JCTGEN..JCT_EPOR_STATE_MASTER   WHERE state  like '" + ddlstate.SelectedItem.Value + "'", obj.Connection());
    //    //sqlCmd.CommandType = CommandType.Text;

    //    //SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
    //    //DataSet ds = new DataSet();
    //    //da.Fill(ds);
    //    //ddlcity.DataSource = ds;
    //    //ddlcity.DataTextField = "city";
    //    //ddlcity.DataValueField = "city";
    //    //ddlcity.DataBind();
    //}
    
    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_payroll_emp_address_detail_insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cardno", SqlDbType.VarChar, 10).Value = ViewState["cardno"];
            cmd.Parameters.Add("@salarycode", SqlDbType.VarChar, 10).Value = ViewState["empcode"];
            cmd.Parameters.Add("@addrestype", SqlDbType.VarChar, 30).Value = ddlAddressType.SelectedItem.Text;
            cmd.Parameters.Add("@addressline1", SqlDbType.VarChar, 30).Value = TxtAddress1.Text;
            cmd.Parameters.Add("@addressline2", SqlDbType.VarChar, 30).Value = TxtAddress2.Text;
            cmd.Parameters.Add("@addressline3", SqlDbType.VarChar, 30).Value = TxtAddress3.Text;
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
            cmd.Parameters.Add("@mob_no", SqlDbType.VarChar, 10).Value = TxtPri_Mobile.Text;
            cmd.Parameters.Add("@landln_no", SqlDbType.VarChar, 12).Value = txtlandline.Text;
            cmd.Parameters.Add("@secondarylandln_no", SqlDbType.VarChar, 12).Value = TxtSecondaryLandline.Text;
            cmd.Parameters.Add("@email_ID", SqlDbType.VarChar, 25).Value = TxtEmailID.Text;
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 30).Value = txtcity.Text;
            cmd.Parameters.Add("@STATE", SqlDbType.VarChar, 30).Value = txtstate.Text;
            cmd.Parameters.Add("@country", SqlDbType.VarChar, 30).Value = ddlcoutry.SelectedItem.Text;
            cmd.ExecuteNonQuery();
            //bindgrid();
            string script = "alert('Record  Saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void lnkbnksave_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow rw in grdDetail.Rows)
            {
                TextBox txt1 = (TextBox)rw.FindControl("txtAccnum");
                CheckBox chb = (CheckBox)rw.FindControl("chk");
                RadioButtonList rb = (RadioButtonList)rw.FindControl("rblChoices");

                if (chb.Checked == true)
                {
                    if (string.IsNullOrEmpty(txt1.Text))
                    {
                        string script = "alert('Please Enter Account Number.!! ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }
                    else
                    {
                        sql = "jct_payroll_emp_bank_detail_insert";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        //con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@cardno", SqlDbType.VarChar, 10).Value = ViewState["cardno"];
                        cmd.Parameters.Add("@salarycode", SqlDbType.VarChar, 10).Value = ViewState["empcode"];
                        cmd.Parameters.Add("@bank", SqlDbType.VarChar, 30).Value = rw.Cells[2].Text;
                        cmd.Parameters.Add("@bankcode", SqlDbType.VarChar, 10).Value = rw.Cells[3].Text;
                        cmd.Parameters.Add("@accountNum", SqlDbType.VarChar, 15).Value = txt1.Text;
                        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                        cmd.Parameters.Add("@BankCategory", SqlDbType.VarChar, 10).Value = rb.SelectedItem.Text;
                        cmd.ExecuteNonQuery();
                        //bindgrid();
                        string script = "alert('Record  Saved.!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
                else
                {
                    string script1 = "alert('Please Select The Record First.!! ');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
                }
            }
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                string bank = gvRow.Cells[2].Text;
                //string bank = e.Row.Cells[2].Text;
                string bankcode = gvRow.Cells[3].Text;
                TextBox txt1 = (TextBox)gvRow.FindControl("txtAccnum");               
                RadioButtonList rblChoices = (RadioButtonList)gvRow.Cells[1].FindControl("rblChoices");
                string sql = "SELECT BankName,Bankcode,AccountNo,AccountCategory  FROM dbo.jct_payroll_emp_bank_detail WHERE EmployeeCode = '" + ViewState["empcode"] + "' AND CardNo='" + ViewState["cardno"] + "' and BankName = @bank and status='A' and Bankcode =@bankcode";
                //string sql = "SELECT   bank,bankcode,accountNum  FROM dbo.jct_payroll_emp_bank_detail WHERE salarycode= '" + ViewState["empcode"] + "' AND cardno='" + ViewState["cardno"] + "' and status='A'";
                
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.Parameters.Add("@bank", SqlDbType.VarChar, 30).Value = bank;
                cmd.Parameters.Add("@bankcode", SqlDbType.VarChar, 30).Value = bankcode;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txt1.Text = dr["AccountNo"].ToString();
                        rblChoices.SelectedIndex = rblChoices.Items.IndexOf(rblChoices.Items.FindByValue(dr["AccountCategory"].ToString()));
                    }
                }
                dr.Close();
            }
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void ddlAddressType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string sql = "SELECT * FROM  jct_payroll_emp_address_detail  WHERE salarycode=@salarycode AND cardno=@cardno and status='A'  and addresType= '" + ddlAddressType.SelectedItem.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@cardno", SqlDbType.VarChar, 30).Value = ViewState["cardno"];
            cmd.Parameters.Add("@salarycode", SqlDbType.VarChar, 30).Value = ViewState["empcode"];
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ddlAddressType.SelectedIndex = ddlAddressType.Items.IndexOf(ddlAddressType.Items.FindByText(dr["AddressType"].ToString()));
                    TxtAddress1.Text = dr["Address1"].ToString();
                    TxtAddress2.Text = dr["Address2"].ToString();
                    TxtAddress3.Text = dr["Address3"].ToString();
                    ddlcoutry.SelectedIndex = ddlcoutry.Items.IndexOf(ddlcoutry.Items.FindByText(dr["Country"].ToString()));
                    txtstate.Text = dr["State"].ToString();
                    txtcity.Text = dr["City"].ToString();
                    TxtPri_Mobile.Text = dr["PrimaryMobileNo"].ToString();
                    txtlandline.Text = dr["PrimaryLandlineNo"].ToString();
                    TxtSecondaryLandline.Text = dr["SecondaryLandlineNo"].ToString();
                    TxtEmailID.Text = dr["EmailID"].ToString();
                }
            }
            else
            {
                ddlcoutry.SelectedIndex = 0;
                txtstate.Text = "";
                txtcity.Text = "";
                TxtAddress1.Text = "";
                TxtAddress2.Text = "";
                TxtAddress3.Text = "";
                TxtPri_Mobile.Text = "";
                txtlandline.Text = "";
                TxtEmailID.Text = "";
            }
            dr.Close();
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {

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