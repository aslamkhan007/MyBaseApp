using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class AssetMngmnt_Asset_accept_reject_report : System.Web.UI.Page
{
     Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        sql = " SELECT   count(  distinct a.Usercode) FROM   dbo.jct_asset_item_details a JOIN jct_empmast_base b ON a.usercode = b.empcode  WHERE  Usercode+jctSR_NO NOT IN (SELECT DISTINCT usercode+CONVERT(varchar,JctsrNo) FROM    dbo.jct_asset_acceptance WHERE   Acceptance IN ( 'A', 'R' ) )AND(Usercode <> ''or usercode is null) AND a.status = 'A' AND module_usedby = 'MiS'  AND Active='Y'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataReader Dr = cmd.ExecuteReader();

        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                lblpending.Text = Dr[0].ToString();
            }
        }
        Dr.Close();

        sql = "   SELECT COUNT( DISTINCT usercode)  FROM dbo.jct_asset_acceptance  WHERE  Acceptance='R' ";
        cmd = new SqlCommand(sql, obj.Connection());
        Dr = cmd.ExecuteReader();

        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                lblreject.Text = Dr[0].ToString();
            }
        }
        Dr.Close();

        sql = "   SELECT COUNT( DISTINCT JctsrNo)  FROM dbo.jct_asset_acceptance  WHERE  Acceptance='R' ";
        cmd = new SqlCommand(sql, obj.Connection());
        Dr = cmd.ExecuteReader();

        if (Dr.HasRows)
        {
            while (Dr.Read())
            {

                lblassetsrejected.Text = Dr[0].ToString();
            }
        }
        Dr.Close();




        sql = "  SELECT COUNT( DISTINCT usercode)  FROM dbo.jct_asset_acceptance  WHERE  Acceptance='A' ";
        cmd = new SqlCommand(sql, obj.Connection());
        Dr = cmd.ExecuteReader();

        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                lblaccept.Text = Dr[0].ToString();
            }
        }
        Dr.Close();



        sql = "select count ( jctSR_NO) AS jctSrno  FROM   dbo.jct_asset_item_details a JOIN jct_empmast_base b ON a.usercode = b.empcode WHERE  Usercode+jctSR_NO NOT IN (SELECT DISTINCT usercode+CONVERT(varchar,JctsrNo)FROM    dbo.jct_asset_acceptance WHERE   Acceptance IN ( 'A', 'R' ) ) AND(Usercode <> ''or usercode is null)AND a.status = 'A'AND module_usedby = 'MiS'AND Active='Y'";
        cmd = new SqlCommand(sql, obj.Connection());
        Dr = cmd.ExecuteReader();

        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
                lblassetpending.Text = Dr[0].ToString();
            }
        }
        Dr.Close();



        sql = "SELECT COUNT (DISTINCT jctSR_NO) FROM dbo.jct_asset_item_details WHERE acceptance_by_email='A' AND module_usedby='mis' AND status='A'";
        cmd = new SqlCommand(sql, obj.Connection());
        Dr = cmd.ExecuteReader();

        if (Dr.HasRows)
        {
            while (Dr.Read())
            {
              lblassetsaccepted.Text = Dr[0].ToString();
            }
        }
        Dr.Close();


    }
               
 
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        string empcodeserc = null;
    
        sql = "jct_asset_accept_reject_reprt";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;


         if (!string.IsNullOrEmpty(txtempname.Text))
             {
                 if (txtempname.Text.Contains('|'))
                 {
                     empcodeserc = txtempname.Text.Split('|')[1].ToString();
                      cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = empcodeserc.Trim();
                      cmd.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
                 }
         }
        else
         {
             cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = "";
        cmd.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
           }
    

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

    }
    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text.Equals("Pending"))
            {
                e.Row.Cells[5].ForeColor = Color.Red;
            }
            if (e.Row.Cells[5].Text.Equals("Rejected"))
            {
                e.Row.Cells[5].ForeColor = Color.Magenta;
            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
         string empcodeserc = null;

        sql = "jct_asset_accept_reject_reprt";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;


        if (!string.IsNullOrEmpty(txtempname.Text))
        {
            if (txtempname.Text.Contains('|'))
            {
                empcodeserc = txtempname.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = empcodeserc.Trim();
                cmd.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
            }
        }
        else
        {
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value = "";
            cmd.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = ddlstatus.SelectedItem.Value;
        }


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();


        DataTable dt = ds.Tables[0];
        string attachment = "attachment; Status.xls";
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
    protected void LinkButton2_Click1(object sender, EventArgs e)
    {
    }
}