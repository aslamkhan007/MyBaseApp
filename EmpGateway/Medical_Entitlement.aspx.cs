using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;  
using System.Data;
public partial class EmpGateway_Medical_Entitlement : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions objFun  = new Functions();        
    String sql;   
    string qry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/login.aspx");
        }

        if (!IsPostBack)
        {
            Bindgrid();
        }
    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd;
            for (int i = 0; i <= ChkEmpList.Items.Count - 1; i++)
            {
                if (ChkEmpList.Items[i].Selected == true)
                {
                    cmd = new SqlCommand("JCT_EmployeeGatway_Entitlement_Mapping", obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Eff_from", SqlDbType.DateTime).Value = txtFrom.Text;
                    cmd.Parameters.Add("@Eff_To", SqlDbType.DateTime).Value = txtTo.Text;
                    cmd.Parameters.Add("@Desg", SqlDbType.NVarChar, 50).Value = ChkEmpList.Items[i].Text;
                    cmd.Parameters.Add("@desg_code", SqlDbType.VarChar, 50).Value = ChkEmpList.Items[i].Value;
                    cmd.Parameters.Add("@EntitlementAmount", SqlDbType.Int).Value = txtAmount.Text;
                    cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["Empcode"];                  
                    cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];                  
                    cmd.ExecuteNonQuery();                    
                }
            }

            SearchDesignation();
            Bindgrid();
            string script = "alert('Record Saved Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        SearchDesignation();
    }

    public void SearchDesignation()
    {
        try
        {
            qry = "Exec JCT_EmployeeGatway_Entitlement_Search_desg '" + txtDesignation.Text + "' ";
            objFun.FillList(ChkEmpList, qry);
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void cmdReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Medical_Entitlement.aspx");
    }

    protected void Bindgrid()
    {
        sql = "JCT_EmployeeGatway_Entitlement_Mapping_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    protected void grdDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            Label id = grdDetail.Rows[e.RowIndex].FindControl("lblSrNo") as Label;
            Label Eff_from = grdDetail.Rows[e.RowIndex].FindControl("lblEffFrom") as Label;
            TextBox Eff_To = grdDetail.Rows[e.RowIndex].FindControl("txtEffTo") as TextBox;
            Label Desg = grdDetail.Rows[e.RowIndex].FindControl("lblDesignation") as Label;
            Label desg_code = grdDetail.Rows[e.RowIndex].FindControl("lblDesgCode") as Label;
            Label Created_date = grdDetail.Rows[e.RowIndex].FindControl("lblCreateDate") as Label;
            TextBox EntitlementAmount = grdDetail.Rows[e.RowIndex].FindControl("txtAmount") as TextBox;

            SqlCommand cmd = new SqlCommand("JCT_EmployeeGatway_Entitlement_Update", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id.Text;
            cmd.Parameters.Add("@Eff_from", SqlDbType.DateTime).Value = Eff_from.Text;
            cmd.Parameters.Add("@Eff_To", SqlDbType.DateTime).Value = Eff_To.Text;
            cmd.Parameters.Add("@Desg", SqlDbType.NVarChar, 50).Value = Desg.Text;
            cmd.Parameters.Add("@desg_code", SqlDbType.VarChar, 50).Value = desg_code.Text;
            cmd.Parameters.Add("@EntitlementAmount", SqlDbType.Int).Value = EntitlementAmount.Text;
            cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["Empcode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            string script = "alert('Record Updated Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            grdDetail.EditIndex = -1;
            Bindgrid();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
        //SqlCommand cmd = new SqlCommand("JCT_EmployeeGatway_Entitlement_Update", obj.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@Eff_from", SqlDbType.DateTime).Value = txtFrom.Text;
        //cmd.Parameters.Add("@Eff_To", SqlDbType.DateTime).Value = txtTo.Text;
        //cmd.Parameters.Add("@Desg", SqlDbType.NVarChar, 50).Value = ChkEmpList.Items[i].Text;
        //cmd.Parameters.Add("@desg_code", SqlDbType.VarChar, 50).Value = ChkEmpList.Items[i].Value;
        //cmd.Parameters.Add("@EntitlementAmount", SqlDbType.Int).Value = txtAmount.Text;
        //cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["Empcode"];
        //cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
        //cmd.ExecuteNonQuery(); 

    }
    protected void grdDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdDetail.EditIndex = e.NewEditIndex;
        Bindgrid();  

    }
    protected void grdDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdDetail.EditIndex = -1;
        Bindgrid();   
    }
}