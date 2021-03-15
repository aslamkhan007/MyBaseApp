using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_jobwork_warehouse_ins : System.Web.UI.Page
{

    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if(!IsPostBack)
{
    sql = "SELECT b.Requestid,a.Sort_no,Qty,FabRate AS Rate,b.challanno,b.challandt,b.qtyrecvd,b.sr_no FROM dbo.jct_ops_jobwork_common a  JOIN jct_ops_jobwork_common_gatepass b ON a.requestid=b.requestid  WHERE authflag='A' AND b.challandt IS NOT null and shrtfallstatus='N' ";
    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    cmd.CommandType = CommandType.Text;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds);
    grdDetail.DataSource = ds.Tables[0];
    grdDetail.DataBind();
    Panel1.Visible = true;
  
}
        
    }
    protected void lnksaVE_Click(object sender, EventArgs e)
    {

        try
        {
            foreach (GridViewRow rw in grdDetail.Rows)
            {
                TextBox txt1 = (TextBox)rw.FindControl("txtshrtfall");
                TextBox txt2 = (TextBox)rw.FindControl("txtremarks");
                CheckBox chb = (CheckBox)rw.FindControl("chk");

                if (txt1.Text != string.Empty)
                {
                    if (chb.Checked == true)
                    {
                        SqlCommand cmd = new SqlCommand("jct_ops_jobwork_common_shrfal_insert", obj.Connection());
                    
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = rw.Cells[3].Text;
                        cmd.Parameters.Add("@shortfall", SqlDbType.VarChar, 50).Value = txt1.Text;
                        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txt2.Text;
                        cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 20).Value = Session["empcode"];
                        cmd.Parameters.Add("@sr_no", SqlDbType.Int).Value = rw.Cells[10].Text;
                 
                        cmd.ExecuteNonQuery();
                     
                        string script = "alert('Record Saved!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                        //jct_ops_jobwork_common_gatepass
                        cmd = new SqlCommand(" update  jct_ops_jobwork_common_gatepass set shrtfallstatus='Y'  where sr_no = '" + rw.Cells[10].Text + "' ", obj.Connection());

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        bindgrid();
                       
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string script = "alert('some error occured');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

                
    }
    protected void txtchalanno_TextChanged(object sender, EventArgs e)
    {
        sql = "SELECT b.Requestid,a.Sort_no,Qty,FabRate AS Rate,b.challanno,b.challandt,b.qtyrecvd,b.sr_no FROM dbo.jct_ops_jobwork_common a  JOIN jct_ops_jobwork_common_gatepass b ON a.requestid=b.requestid  WHERE authflag='A' AND a.requestID= '"+ txtchalanno.Text  + "' AND b.challandt IS NOT null and shrtfallstatus='N' ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("jobwork_warehouse_ins.aspx");
    }
    private void bindgrid()
    {
        sql = "SELECT b.Requestid,a.Sort_no,Qty,FabRate AS Rate,b.challanno,b.challandt,b.qtyrecvd,b.sr_no FROM dbo.jct_ops_jobwork_common a  JOIN jct_ops_jobwork_common_gatepass b ON a.requestid=b.requestid  WHERE authflag='A' AND b.challandt IS NOT null and shrtfallstatus='N' ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }
}