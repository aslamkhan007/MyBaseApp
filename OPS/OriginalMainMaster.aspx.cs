using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_MainMaster : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql = "Select 'None' as parameter , 'None' as parameter Union Select PARAMETER_CODE,parameter from  JCT_OPS_MULTI_MASTER where status='A' and Parent_category = 'None' ";
            obj1.FillList(ddlParentCategory, sql);
        }
    }
    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
          
                    sql = "Insert into JCT_OPS_MULTI_MASTER (UserCode,Parent_Category,Parameter_Code,Parameter,Description,Remarks,Status,EntryDate) values(@userCode,@Parent_Category,@ParameterCode,@Parameter,@Description,@remarks,@Status,@EntryDate)";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = "J-01945"; //Session["EmpCode"];
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Value = txtDescription.Text;
                    cmd.Parameters.Add("@Parent_Category", SqlDbType.VarChar,30).Value = ddlParentCategory.SelectedItem.Value;
                    cmd.Parameters.Add("@ParameterCode", SqlDbType.VarChar,30).Value = txtParamCode.Text;
                    cmd.Parameters.Add("@Parameter", SqlDbType.VarChar, 30).Value = txtParameter.Text;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
                    cmd.Parameters.Add("@STATUS", SqlDbType.Char).Value = 'A';
                    cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();
                    FMsg.CssClass = "errormsg";
                    FMsg.Message = "Record Added Successfully..!!";
                    FMsg.Display();
                    obj1.Alert("Record Added Successfully..!!");
        }
        catch (Exception ex)
        {
            FMsg.CssClass = "errormsg";
            FMsg.Message = "Error occured while adding record..!!";
            FMsg.Display();
            obj1.Alert("Error occured while adding record..!!");
        }
       
                
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainMaster.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       // ddlParentCategory.SelectedItem.Text = GridView1.SelectedRow.Cells[1].Text;
        ddlParentCategory.SelectedIndex =  ddlParentCategory.Items.IndexOf(ddlParentCategory.Items.FindByText(GridView1.SelectedRow.Cells[1].Text));
       // ddlParentCategory.Selectedindex = GridView1.SelectedRow.Cells[1].Text;
        txtParamCode.Text = GridView1.SelectedRow.Cells[2].Text;
        txtParameter.Text = GridView1.SelectedRow.Cells[3].Text;
        txtDescription.Text = GridView1.SelectedRow.Cells[4].Text;
        txtRemarks.Text = GridView1.SelectedRow.Cells[5].Text;
        lnkUpdate.Enabled = true;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        SqlTransaction transaction;
        SqlConnection db = new SqlConnection();
        db = obj.Connection();
        transaction = db.BeginTransaction();
        try
        {
            sql = "Update JCT_OPS_MULTI_MASTER set Status='U' where Parent_Category=@Parent_Category and Parameter_Code=@ParameterCode and status='A'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection(),transaction);
            cmd.Parameters.Add("@Parent_Category", SqlDbType.VarChar, 30).Value = GridView1.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@ParameterCode", SqlDbType.VarChar, 20).Value = txtParamCode.Text;
            cmd.ExecuteNonQuery();

            sql = "Insert into JCT_OPS_MULTI_MASTER (UserCode,Parent_Category,Parameter_Code,Parameter,Description,Remarks,Status,EntryDate) values(@userCode,@Parent_Category,@ParameterCode,@Parameter,@Description,@remarks,@Status,@EntryDate)";
            cmd = new SqlCommand(sql, obj.Connection(),transaction);
            cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = "J-01945"; //Session["EmpCode"];
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Value = txtDescription.Text;
            cmd.Parameters.Add("@Parent_Category", SqlDbType.VarChar, 30).Value = GridView1.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@ParameterCode", SqlDbType.VarChar, 30).Value = txtParamCode.Text;
            cmd.Parameters.Add("@Parameter", SqlDbType.VarChar, 30).Value = txtParameter.Text;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text;
            cmd.Parameters.Add("@STATUS", SqlDbType.Char).Value = 'A';
            cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            String script1 = "alert('Record Updated.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
            GridView1.DataBind();

        }
        catch (SqlException sqlError)
        {
            transaction.Rollback();
            String script1 = "alert('Error occured while updating record.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);

        }
        finally
        {
            obj.ConClose();
        }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        sql = "Update JCT_OPS_MULTI_MASTER set Status='D' where Parent_Category=@Parent_Category and Parameter_Code=@ParameterCode and status='A'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@Parent_Category", SqlDbType.VarChar, 30).Value = ddlParentCategory.SelectedItem.Text;
        cmd.Parameters.Add("@ParameterCode", SqlDbType.VarChar, 20).Value = txtParamCode.Text;
        cmd.ExecuteNonQuery();
        String script1 = "alert('Record Deleted.');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
        GridView1.DataBind();
        txtDescription.Text = "";
        txtParamCode.Text = "";
        txtParameter.Text = "";
        txtRemarks.Text = "";
        ddlParentCategory.SelectedItem.Text = "None";

    }
}