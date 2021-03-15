using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_MailContentPages_asset_sendmail_new : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string requestID;
    string jctsr_no;
    string usercode;
    protected void Page_Load(object sender, EventArgs e)
    {
        requestID =Request.QueryString["requestid"].ToString();
            string sql = ("SELECT jctSR_NO FROM dbo.jct_asset_item_details WHERE item_id= '" + requestID + "' AND status='A' and module_usedby='MIS'");
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    jctsr_no = dr[0].ToString();
                    //lblsrno.Text = dr[0].ToString();
                   
                }
            }
            dr.Close();
            HardwareConfig();
            softwareConfig();
            printerConfig();
            //BindDataList();
        

            sql = "jct_asset_item_detail_print";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = requestID;

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    //lblcomptype.Text = dr["computer_type"].ToString();
                    lblCurrentDate.Text = dr["Dated"].ToString();
                    lblissuedto.Text = dr["IssueTo"].ToString();
                    lbldept.Text = dr["Department"].ToString();
                    lblmodelno.Text = dr["ModelNo"].ToString();
                    //lblsrno.Text = dr["jctSR_NO"].ToString();

                }

            }
            else
            {
                string script = "alert(Noooooooooooooooo data available!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);


            }

            dr.Close();


            sql = "jct_asset_item_detail_print2";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = requestID;


            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    lblitemname.Text = dr["item_name"].ToString();
                    //lblDop.Text = dr["DOP"].ToString();
                    //lblipaddress.Text = dr["IP_address"].ToString();

                }

            }
            dr.Close();


        }
      
    

    public void BindDataList()
    {
        //SqlCommand cmd = new SqlCommand("SELECT  DISTINCT c.item_name,c.asset_id   FROM jct_asset_item_details  a  JOIN  jct_asset_type_item_detail b ON a.item_id=b.request_id  JOIN jct_asset_master c ON b.asset_id=c.asset_id  WHERE a.jctSR_NO= '" + jctsr_no + "' AND a.status='a' ", obj.Connection());
        //cmd.CommandType = CommandType.Text;
        //DataSet ds = new DataSet();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(ds);
        //DataList1.DataSource = ds;
        //DataList1.DataBind();


    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    GridView gv = (GridView)e.Item.FindControl("GridView1");
        //    Label lbh = (Label)e.Item.FindControl("Labelhead");

        //    int asset_id = (int)DataList1.DataKeys[e.Item.ItemIndex];
        //    if (gv != null)
        //    {

        //        string qry = "  SELECT  a.asset_type_name AS [Components], a.item_desc AS [Description]   FROM dbo.jct_asset_type_item_detail  a JOIN  dbo.jct_asset_item_details b  ON b.item_id=a.request_id   JOIN  dbo.jct_asset_master c ON a.asset_id=c.asset_id   WHERE   b.status='A' AND jctSR_NO= '" + jctsr_no + "' AND c.asset_id='" + asset_id + "'";
        //        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        gv.DataSource = ds.Tables[0];
        //        gv.DataBind();



  //              SELECT  a.asset_type_name AS [Components], a.item_desc AS [Description]   FROM dbo.jct_asset_type_item_detail  a JOIN  dbo.jct_asset_item_details b  ON b.item_id=a.request_id   JOIN  dbo.jct_asset_master c ON a.asset_id=c.asset_id   WHERE   b.status='A' AND jctSR_NO= '323' AND c.item_name='Hardware' AND c.module_usedby='MIS' AND c.status='A'
  //SELECT  a.asset_type_name AS [Components], a.item_desc AS [Description]   FROM dbo.jct_asset_type_item_detail  a JOIN  dbo.jct_asset_item_details b  ON b.item_id=a.request_id   JOIN  dbo.jct_asset_master c ON a.asset_id=c.asset_id   WHERE   b.status='A' AND jctSR_NO= '323' AND c.item_name='Software' AND c.module_usedby='MIS' AND c.status='A'
  // SELECT  printer_type  AS [Components] , model   AS [Description] FROM dbo.jct_asset_printer_scanner_network WHERE module_usedby='MIS'AND status='A' AND jct_machine_ID='323'

        //    }


        //}

    }
    private void HardwareConfig()
    {
        string qry = "  SELECT  a.asset_type_name AS [Components], a.item_desc AS [Description]   FROM dbo.jct_asset_type_item_detail  a JOIN  dbo.jct_asset_item_details b  ON b.item_id=a.request_id   JOIN  dbo.jct_asset_master c ON a.asset_id=c.asset_id   WHERE   b.status='A' AND jctSR_NO= '" + jctsr_no + "' AND c.item_name='Hardware' AND c.module_usedby='MIS' AND c.status='A'";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail1.DataSource = ds.Tables[0];
        grdDetail1.DataBind();

    }

    private void softwareConfig()
    {
        string qry = "SELECT  a.asset_type_name AS [Components], a.item_desc AS [Description]   FROM dbo.jct_asset_type_item_detail  a JOIN  dbo.jct_asset_item_details b  ON b.item_id=a.request_id   JOIN  dbo.jct_asset_master c ON a.asset_id=c.asset_id   WHERE   b.status='A' AND jctSR_NO=  '" + jctsr_no + "'  AND c.item_name='Software' AND c.module_usedby='MIS' AND c.status='A'";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail2.DataSource = ds.Tables[0];
        grdDetail2.DataBind();

    }

    private void printerConfig()
    {
        string qry = "SELECT  asset_type AS [TYPE], printer_type  AS [Components] , model   AS [Description] FROM dbo.jct_asset_printer_scanner_network WHERE module_usedby='MIS'AND status='A' AND jct_machine_ID= '" + jctsr_no + "' ";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail3.DataSource = ds.Tables[0];
        grdDetail3.DataBind();

    }
}