using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_audit_report_inv_no_issue : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["testinventory"].ConnectionString);
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {
            excel.Visible = true;
            Panel1.Visible = true;
            //'05/05/2005' ,'05/05/2013' 
            SqlCommand cmd = new SqlCommand("jct_inv_receipt_not_issue",obj.Connection());
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdatefrm.Text);
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdateto.Text);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            //con.Close();
            excel.Visible = true;
        }
        catch (Exception ex)
        {

            string script2 = "alert('Some Error occurred!!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }

   
    }

    private void excelcode()
    {
        SqlCommand cmd = new SqlCommand("jct_inv_receipt_not_issue",obj.Connection());
        //con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdatefrm.Text);
        cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdateto.Text);
        cmd.ExecuteNonQuery();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        //con.Close();
    


        DataTable dt = ds.Tables[0];
        string attachment = "attachment; auditReport.xls";
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

       // con.Close();
    
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        excelcode();
    }
}