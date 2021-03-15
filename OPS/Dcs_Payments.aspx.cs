using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;

public partial class OPS_Dcs_Payments : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["APDBCoonectionString"].ConnectionString);
    string sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }
    protected void radbtnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlGroupCode.SelectedItem.Text == "Select")
            {

                string sql = "jct_dcs_payment_detail";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (!string.IsNullOrEmpty(radDateTo.SelectedDate.ToString()))
                {
                    cmd.Parameters.Add("@sdate", SqlDbType.DateTime).Value = Convert.ToString(radDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateFrom.SelectedDate).ToShortDateString());
                }
                if (!string.IsNullOrEmpty(radDateTo.SelectedDate.ToString()))
                {
                    cmd.Parameters.Add("@edate", SqlDbType.DateTime).Value = Convert.ToString(radDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateTo.SelectedDate).ToShortDateString());
                }
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[1];
                string attachment = "attachment; filename=DCSPayment.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        Response.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }

            else
            {
                sql = "jct_dcs_payment_detail_Select";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@stock_no", SqlDbType.VarChar, 16).Value = ddlGroupCode.SelectedItem.Text;
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                DataSet ds = new DataSet();
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                string attachment = "attachment; filename=DCSPayment.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        Response.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();

            }

        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }

    }

    protected void radgrdCheckDetail_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        int index = e.NewPageIndex;
        int current = radgrdCheckDetail.CurrentPageIndex;
    }


    protected void radgrdCheckDetail_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                radgrdCheckDetail.DataSource = null;
            }

            else
            {

                sql = "jct_dcs_payment_detail";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@sdate", SqlDbType.VarChar, 30).Value = Convert.ToString(radDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateFrom.SelectedDate).ToShortDateString());
                cmd.Parameters.Add("@edate", SqlDbType.VarChar, 50).Value = Convert.ToString(radDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateTo.SelectedDate).ToShortDateString());
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                radgrdCheckDetail.DataSource = ds.Tables[1];
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }

    }

    protected void radgrdCheckDetail_ItemCreated(object sender, GridItemEventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                radgrdCheckDetail.DataSource = null;
                radgrdCheckDetail.DataBind();
            }

            else
            {

            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }

    }

    protected void radbtnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_dcs_payment_detail";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@sdate", SqlDbType.VarChar, 30).Value = Convert.ToString(radDateFrom.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateFrom.SelectedDate).ToShortDateString());
            cmd.Parameters.Add("@edate", SqlDbType.VarChar, 50).Value = Convert.ToString(radDateTo.SelectedDate.ToString() == "" ? "" : Convert.ToDateTime(radDateTo.SelectedDate).ToShortDateString());
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            RadGrid1.DataSource = ds.Tables[0];
            RadGrid1.DataBind();

            DataTable dt = ds.Tables[0];
            ddlGroupCode.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                RadComboBoxItem myItem = new RadComboBoxItem();
                myItem.Text = dr["Group"].ToString();
                myItem.Value = dr["Group"].ToString();
                ddlGroupCode.Items.Add(myItem);

            }
            ddlGroupCode.Items.Insert(0, new RadComboBoxItem("Select", string.Empty)); 
            radgrdCheckDetail.DataSource = ds.Tables[1];
            radgrdCheckDetail.DataBind();

        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }

    }
    protected void radbtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dcs_Payments.aspx");
    }
    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlGroupCode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        sql = "jct_dcs_payment_detail_Select";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@stock_no", SqlDbType.VarChar, 16).Value = ddlGroupCode.SelectedItem.Text;
        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        radgrdCheckDetail.DataSource = null;
        radgrdCheckDetail.DataSource = ds;
        radgrdCheckDetail.DataBind();
    }
}