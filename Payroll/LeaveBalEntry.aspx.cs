using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payroll_LeaveBalEntry : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Plantbind();
        }
    }

    protected void chksel_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox sel = (CheckBox)grdDetail.HeaderRow.FindControl("chksel");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkbx");

            if (cb != null)
            {

                if (sel.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
    }

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkall = (CheckBox)grdDetail.HeaderRow.FindControl("chkall");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");

            if (cb != null)
            {

                if (chkall.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
    }

    public void Plantbind()
    {
        string sql = "SELECT LeaveType,LeaveType FROM Jct_Payroll_LeaveCategory_Portal";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter Da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        FetchMYRecords();
    }

    public void FetchMYRecords()
    {
        try
        {
            string sql = "Jct_Payroll_LeaveBalance_Fetch";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            cmd.Parameters.Add("@Year", SqlDbType.Decimal, 4).Value = DropDownList1.SelectedItem.Value;
            cmd.Parameters.Add("@Action", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            Label5.Visible = true;
            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert('No Record Found');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    /*
Eight persons S, T, U, V, W, X, Y and Z are attending the seminar on 13thand 26th of the four different months viz., March, April, June and July of the same year.
They all like different games viz., Cricket, Chess, Golf, Hockey, Badminton, Squash, Tennis and Rugby but not necessary in the same 
Only three persons are attend the seminars between the one who likes Squash and S, who does not attend the seminar on even numbered date. 
S does not attend the seminar in the month which has odd number of days. U attends the seminar immediately after the one who likes Squash.
 The one who likes Badminton attend the seminar immediately before W. As many persons attend the seminar before W is same as after the one who likes Rugby.
 S does not like Badminton. Only one person attend the seminar between W and Z. Two persons are attend the seminar between Y and the one who likes Cricket, 
 who was attend before Y. Only one person attends the seminar between V and the one who likes Cricket. V does not like Rugby. 
  Only one person attends the seminar between the one who likes Golf and the one who likes Chess. W does not like Chess. 
 As many persons attend the seminars between T and the one who likes Squash is same as between Z and the one who likes Tennis. 
 The one who likes Tennis does not attend the seminar in June.
 
     */
    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            SaveRecord();
            lnkapply.Enabled = true;
            FetchMYRecords();
            string script = "alert('Record  Saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);            
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void SaveRecord()
    {
        string OK = string.Empty;
        foreach (GridViewRow gvRow1 in grdDetail.Rows)
        {
            CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chk");
            if (chkRemove1.Checked == true)
            {
                OK = "OK";
            }
        }
        if (OK == "OK")
        {
            /*
                                
Eight friends J, K, L, M, N, O, P, Q attended marriage party in the months of January, July, September, and 
November. In each month, the party will be conducted on 6th and 13th of the month. Not more than two 
attend the marriage party on same month. Only one person attends the party on one date of one month. O 
attended the party on 6th of the month which has only 30 days. There are four friends have attended party 
between O and K. The number of persons attended party between L and O is the same as the number of 
persons attended party between J and N. Q attended party before P. M and L attended party in the same 
date, but M attended before L. Two person attended party between O and J. L and N attended the party on 
6th of July and 13th of November respectively.
             */
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                string mytype = gvRow.Cells[1].Text;                 
                TextBox txt1 = (TextBox)gvRow.FindControl("txtPanno");
                CheckBox chkRemove10 = (CheckBox)gvRow.FindControl("chk");

                if (chkRemove10.Checked == true)
                {
                    if (string.IsNullOrEmpty(txt1.Text))
                    {
                        string script = "alert('Value Cannot Be Emply.!! ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }                                              
                SqlCommand cmd = new SqlCommand("Jct_Payroll_LeaveBalance_Insert_Update_new", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                cmd.Parameters.Add("@Year", SqlDbType.Decimal, 4).Value = DropDownList1.SelectedItem.Value;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
                cmd.Parameters.Add("@LeaveType", SqlDbType.VarChar, 2).Value = mytype;
                cmd.Parameters.Add("@Amount", SqlDbType.Decimal, 6).Value = Convert.ToDecimal(txt1.Text);
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
                cmd.ExecuteNonQuery();
                //DataTable dt = new DataTable();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(dt);
                //grdDetail.DataSource = dt;
                //grdDetail.DataBind();
                } 
            }
        }
        else
        {
            string script2 = "alert('Please Select The Record First.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }
    }


    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("LeaveBalEntry.aspx");
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchMYRecords();
    }
}