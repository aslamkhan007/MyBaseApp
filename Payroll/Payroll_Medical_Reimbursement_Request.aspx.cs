using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using System.Net.Mail;

public partial class Payroll_Payroll_Medical_Reimbursement_Request : System.Web.UI.Page
{
    string sql = string.Empty;
    Connection obj = new Connection();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AttendenceDate();
            toshowfirstrow();            
        }
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Medical_Reimbursement_Request.aspx");
    }

    public void ClearControls()
    {
        lblEmployeeName.Text = "";
    }

    public void ClearGroupControls()
    {
        lblEmployeeName.Text = "";
        lbdept.Text = "";
        lbdesign.Text = "";
        lblbasic.Text = "";
    }

    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Medical_Attendence_Month";
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

    protected void lnkaddrow_Click(object sender, EventArgs e)
    {
        fun2();
    }

    private void fun2()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                RadTextBox txtnoofitems = (RadTextBox)grdDetail.Rows[rowIndex].Cells[0].FindControl("txtCashMemoNumber");
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow[0] = txtnoofitems.Text;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                grdDetail.DataSource = dtCurrentTable;
                grdDetail.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
    }

    private void toshowfirstrow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("AssetDescription", typeof(string)));
        dt.Columns.Add(new DataColumn("NoOfItems", typeof(string)));
        dt.Columns.Add(new DataColumn("AllocationDate", typeof(string)));
        if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
        {
            dr = dt.NewRow();
            dr["AssetDescription"] = string.Empty;
            dr["NoOfItems"] = string.Empty;
            dr["AllocationDate"] = string.Empty;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
        }
        else
        {
            for (int i = 0; i <= 0; i++)
            {
                dr = dt.NewRow();
                dr["AssetDescription"] = string.Empty;
                dr["NoOfItems"] = string.Empty;
                dr["AllocationDate"] = string.Empty;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
        }

        ViewState["CurrentTable"] = dt;
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
    }

    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rowIndex++;
                }
            }
        }
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ClearGroupControls();
            CheckDesignation();
            BindGrid();
        }
        catch (Exception exception)
        {
            lblEmployeeName.Text = "";
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void CheckDesignation()
    {
        string employeecode = txtEmployee.Text.Split('|')[1].ToString();
        txtEmployee.Text = employeecode;
        string sql = "Jct_Payroll_MedicalFile_Detail_Employee_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ClearGroupControls();
                lblEmployeeName.Text = dr[1].ToString();
                lbdept.Text = dr[2].ToString();
                lbdesign.Text = dr[3].ToString();
                lblbasic.Text = dr[4].ToString();
            }
            dr.Close();
        }
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //RadTextBox txtnoofitems = (RadTextBox)e.Row.FindControl("txtNoOfItems");
            //string txtnoOfItemsValue = txtnoofitems.Text;           
            //RadDatePicker txtAcqDt = (RadDatePicker)e.Row.FindControl("txtAcqDt");         
            //txtnoofitems.Text = txtnoOfItemsValue.ToString();

        }
    }

    protected void grdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                rowIndex = gvr.RowIndex;
                dt.Rows.RemoveAt(rowIndex);
                grdDetail.DataSource = dt;
                grdDetail.DataBind();
                SetPreviousData();
                ViewState["CurrentTable"] = dt;
                if (dt.Rows.Count == 0)
                {

                }
            }
        }
    }

    protected void lnkApply_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                RadTextBox txtCashMemoNumbers = (RadTextBox)gvRow.FindControl("txtCashMemoNumber");
                RadDatePicker txtAcqDts = (RadDatePicker)gvRow.FindControl("txtAcqDt");
                RadNumericTextBox txtAmounts = (RadNumericTextBox)gvRow.FindControl("txtAmount");
                SqlCommand cmd = new SqlCommand("Jct_Payroll_MedicalFile_Detail_Insert", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                cmd.Parameters.Add("@CashMemoNumber", SqlDbType.VarChar, 65).Value = txtCashMemoNumbers.Text;                
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = txtAcqDts.SelectedDate;                
                cmd.Parameters.Add("@Amount", SqlDbType.Decimal, 2).Value = Convert.ToDecimal(txtAmounts.Text);
                cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                cmd.Parameters.Add("@HostID", SqlDbType.VarChar, 20).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();
            }
            BindGrid();
            toshowfirstrow();
            string script = "alert('Records Saved!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    public void BindGrid()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "Jct_Payroll_MedicalFile_Detail_Fetch";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32(txttodate.Text);
        Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        Panel1.Visible = true;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "deleterow")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(row.Cells[1].Text);
                sql = "Jct_Payroll_MedicalFile_Detail_Delete";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = txtEmployee.Text;
                cmd.Parameters.Add("@Srno", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                string script = "alert('Records Deleted !!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }
}