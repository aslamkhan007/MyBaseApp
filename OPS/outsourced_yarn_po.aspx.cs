﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_outsourced_yarn_po : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    string sql = null;
    SqlDataReader dr = default(SqlDataReader);
    SqlCommand cmd = default(SqlCommand);
    Connection obj = new Connection();
    Functions obj2 = new Functions();
    string sqlpass = null;
    string sno2 = null;
    string qry = null;
    string scrpt_str = null;
    int sno1 = 0;
    DataTable dt = new DataTable();
    Functions ObjFun = new Functions();

    string var_location = null;
    string var_document = null;
    string var_vendname = null;
    string var_waybill = null;
    string var_stockno = null;
    string var_variant = null;
    string var_stockname = null;
    string var_unloadno = null;
    string var_unloaddt = null;
    string var_pono = null;
    decimal var_bales = 0;
    string var_qtyrcvd = null;
    decimal var_balqty = 0;
    decimal var_entryno = 0;
    decimal var_orderqty = 0;
    string var_challanNo = null;
    string var_challandt = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (rdlist.SelectedIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("jct_ops_yarn_selct_for_po", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = lbid.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                grdDetail.Visible = true;
                lnksave.Visible = true;
                lnkclr.Visible = true;
                buttonbackbar.Visible = false;
                buttonbackbar2.Visible = true;
                lbefffrm.Visible = false;
                lbeffto.Visible = false;
                txtefffrm.Visible = false;
                txteffto.Visible = false;

            }
            if (rdlist.SelectedIndex == 1)
            {

                lbefffrm.Visible = true;
                lbeffto.Visible = true;
                txtefffrm.Visible = true;
                txteffto.Visible = true;
                grdDetail.Visible = false;
                lnksave.Visible = false;
                lnkclr.Visible = false;
                lnkfetch.Visible = true;
                lnkclose.Visible = true;
                buttonbackbar.Visible = true;
                buttonbackbar2.Visible = false;

            }
        }
    }


    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdlist.SelectedIndex == 0)
        {

            SqlCommand cmd = new SqlCommand("jct_ops_yarn_selct_for_po", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = lbid.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            grdDetail.Visible = true;
            lnksave.Visible = true;
            lnkclr.Visible = true;
            buttonbackbar.Visible = false;
            buttonbackbar2.Visible = true;
            lbefffrm.Visible = false;
            lbeffto.Visible = false;
            txtefffrm.Visible = false;
            txteffto.Visible = false;
        }
        if (rdlist.SelectedIndex == 1)
        {

            lbefffrm.Visible = true;
            lbeffto.Visible = true;
            txtefffrm.Visible = true;
            txteffto.Visible = true;
            grdDetail.Visible = false;
            lnksave.Visible = false;
            lnkclr.Visible = false;
            lnkfetch.Visible = true;
            lnkclose.Visible = true;
            buttonbackbar.Visible = true;
            buttonbackbar2.Visible = false;


        }
    }
    




    protected void lnksave_Click(object sender, EventArgs e)
    {
        if (rdlist.SelectedIndex == 0)
        {
            try
            {
                foreach (GridViewRow rw in grdDetail.Rows)
                {
                    TextBox txt1 = (TextBox)rw.FindControl("txtpo");
                    CheckBox chb = (CheckBox)rw.FindControl("chbSelect");

                    if (txt1.Text != string.Empty)
                    {
                        if (chb.Checked == true)
                        {
                            SqlCommand cmd = new SqlCommand("jct_ops_yarn_po_genrate", con);
                            con.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = rw.Cells[2].Text;
                            cmd.Parameters.Add("@po_no", SqlDbType.VarChar, 30).Value = txt1.Text;
                            cmd.Parameters.Add("@po_createdby", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                string script = "alert('PO Generated Successfully..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            catch (Exception ex)
            {
                string script = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        if (rdlist.SelectedIndex == 1)
            // to be modified  challan date and number has to be added//
        {
            for (int i = 0; i <= this.grdGrid1.Rows.Count - 1; i++)
            {

                if (grdGrid1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    var_location = ((DropDownList)grdGrid1.Rows[i].FindControl("ddllocation")).SelectedItem.Text;
                    var_document = ((DropDownList)grdGrid1.Rows[i].FindControl("ddldocument")).SelectedItem.Text;

                    var_qtyrcvd = ((TextBox)grdGrid1.Rows[i].FindControl("txtqtyrcvd")).Text;
                    var_challanNo = ((TextBox)grdGrid1.Rows[i].FindControl("txtchallanno")).Text;
                    var_challandt = ((TextBox)grdGrid1.Rows[i].FindControl("txtchallandt")).Text;

              

                    if (!string.IsNullOrEmpty(var_qtyrcvd))
                    {
                        var_bales = Convert.ToDecimal(grdGrid1.Rows[i].Cells[7].Text);
                        var_balqty = Convert.ToDecimal(grdGrid1.Rows[i].Cells[17].Text);
                        var_vendname = grdGrid1.Rows[i].Cells[4].Text;
                        var_waybill = grdGrid1.Rows[i].Cells[5].Text;
                        var_stockno = grdGrid1.Rows[i].Cells[12].Text;
                        var_variant = grdGrid1.Rows[i].Cells[13].Text;
                        var_stockname = grdGrid1.Rows[i].Cells[14].Text;
                        var_unloadno = grdGrid1.Rows[i].Cells[9].Text;
                        var_unloaddt = grdGrid1.Rows[i].Cells[10].Text;
                        var_entryno = Convert.ToDecimal(grdGrid1.Rows[i].Cells[11].Text);
                        var_pono = grdGrid1.Rows[i].Cells[15].Text;
                        var_orderqty = Convert.ToDecimal(grdGrid1.Rows[i].Cells[16].Text);

                        qry = "insert into  jct_ops_rm_rcvd_outsorc_material(plant,Vendor_name,waybillno,document_rcvd,Bales_rcvd,Qty_rcvd,UnloadNo,unloadDate,EntryNO,StockNo,variant,Stock_name,PONo,Order_Qty,Bal_qty,Host_id,entry_date,material_status,challan_no,challan_date) values( '" + var_location + "',  '" + var_vendname + "', '" + var_waybill + "', '" + var_document + "', '" + var_bales + "','" + var_qtyrcvd + "', '" + var_unloadno + "', '" + var_unloaddt + "','" + var_entryno + "', '" + var_stockno + "', '" + var_variant + "', '" + var_stockname + "', '" + var_pono + "','" + var_orderqty + "', '" + var_balqty + "', '" + Session["Empcode"] + "', getdate(), 'R','" + var_challanNo + "','" + var_challandt + "' ) ";
                        cmd = new SqlCommand(qry, obj.Connection());
                        cmd.ExecuteNonQuery();
                        string script = "alert('Record inserted Successfully..!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        
                        grdGrid1.Visible = true;
                        string sql = "exec jct_ops_outsorce_fabric_yarn_unloading  '" + txtefffrm.Text + "','" + txteffto.Text + "' ";

                        cmd = new SqlCommand(sql, con);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        grdGrid1.DataSource = ds.Tables[0];
                        grdGrid1.DataBind();
                        lnkclose.Visible = true;
                        lnksave.Visible = true;
                        buttonbackbar2.Visible = true;

                    }
                }
            }

        }
    }

    protected void lnkclr_Click(object sender, EventArgs e)
    {
        Response.Redirect("outsourced_yarn_po.aspx");
    }

    protected void chbSelect_CheckedChanged(object sender, EventArgs e)
    {
      
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        grdGrid1.Visible = true;
        string sql = "exec jct_ops_outsorce_fabric_yarn_unloading  '" + txtefffrm.Text + "','" + txteffto.Text + "' ";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandTimeout = 0;
        con.Open();
        cmd.ExecuteNonQuery();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdGrid1.DataSource = ds.Tables[0];
        grdGrid1.DataBind();
        lnkclose.Visible = true;
        lnksave.Visible = true;
        buttonbackbar2.Visible = true;
    }

    protected void lnkApply_Click(object sender, EventArgs e)
    {
      
    }

        
    protected void  chbSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chbSelectAll = grdDetail.HeaderRow.FindControl("chbSelectAll") as CheckBox;
        if (chbSelectAll.Checked == false)
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                CheckBox chbSelect = (CheckBox)gvRow.FindControl("chbSelect");
                chbSelect.Checked = false;
            }
        }
        else if (chbSelectAll.Checked == true)
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                CheckBox chbSelect = (CheckBox)gvRow.FindControl("chbSelect");
                chbSelect.Checked = true;
            }
        }
        
    }




    protected void lnkclose_Click(object sender, EventArgs e)
    {

        Response.Redirect("default.aspx");
    }
    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetail.PageIndex = e.NewPageIndex;
        SqlCommand cmd = new SqlCommand("jct_ops_yarn_selct_for_po", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 30).Value = lbid.Text;
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }
}

