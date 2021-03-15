using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_location_update : System.Web.UI.Page
{

    Connection con = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {

            planidlist();
        }

    }



    protected void Searchbtn_Click(object sender, ImageClickEventArgs e)
    {
        if (txtorderNo.Text == "")
        {
            string script = "alert('Please enter Order number');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else
        {
            SqlCommand cmd = new SqlCommand("ops_plan_order_select", con.Connection());
            con.ConOpen();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@order", SqlDbType.VarChar, 20).Value = txtorderNo.Text;

            cmd.Parameters.Add("@planid", SqlDbType.VarChar, 20).Value = ddlplnlist.SelectedItem.Text;
            cmd.ExecuteNonQuery();
            con.ConClose();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();

           

        }
    }
    protected void lnkappply_Click(object sender, EventArgs e)
    {
        SqlTransaction tran;
    
        tran = con.Connection().BeginTransaction();
        try
        {

            SqlCommand cmd = new SqlCommand("ops_plan_order_location_insert_log", con.Connection(),tran);
            con.ConOpen();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@newlocation", SqlDbType.VarChar, 20).Value = ddlnewloc.SelectedItem.Text;
            cmd.Parameters.Add("@Oldlocation", SqlDbType.VarChar, 20).Value = txtcurrentloc.Text;
            cmd.Parameters.Add("@transno", SqlDbType.VarChar, 20).Value = ViewState["transno"];
            cmd.Parameters.Add("@updated_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("update JCT_OPS_PLANNING_ORDER set LOCATION = '" + ddlnewloc.SelectedItem.Text +"' where transno= '" + ViewState["transno"] + "' and  order_no='" + hdnorder.Value + "'", con.Connection(), tran);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            tran.Commit();
            

            string script = "alert('Record Updated!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }

        catch (Exception ex)
        {
            tran.Rollback();
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
        finally
        {
            con.ConClose();
        }

    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("location_update.aspx");
    }

    private void planidlist()
    {

        string Sql = ("SELECT  DISTINCT TOP  10  planid as planid FROM JCT_OPS_PLANNING_ORDER WHERE STATUS='A'");
        SqlCommand cmd = new SqlCommand(Sql, con.Connection());
        cmd.CommandType = CommandType.Text;
        //SqlDataReader dr = cmd.ExecuteReader();
        con.ConOpen();
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());

        ddlplnlist.DataSource = dt;
        ddlplnlist.DataTextField = "planid";
        //ddlplnlist.DataTextField = dr[0].ToString();

        ddlplnlist.DataBind();
        //List<planid> Data = new List<planid>();

        //    dr.Read();
        //    if (dr.HasRows == true)
        //    {
        //        planid plid = new planid();
        //        plid.planidlist = dr[0].ToString();
        //    }
        con.ConClose();

    }
    protected void ddlplnlist_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["transno"] = grdDetail.SelectedRow.Cells[1].Text;
        hdnorder.Value = grdDetail.SelectedRow.Cells[2].Text;
        
        SqlCommand cmd = new SqlCommand("SELECT LOCATION FROM  JCT_OPS_PLANNING_ORDER WHERE TransNo=@TransNo AND status='A'", con.Connection());
        cmd.CommandType = CommandType.Text;
        con.ConOpen();
        cmd.Parameters.Add("@transno", SqlDbType.VarChar, 20).Value = grdDetail.SelectedRow.Cells[1].Text;

        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            txtcurrentloc.Text = dr[0].ToString();
        }
        con.ConClose();



    }
}

