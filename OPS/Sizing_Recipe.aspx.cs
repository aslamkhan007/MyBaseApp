using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class OPS_Sizing_Recipe : System.Web.UI.Page
{
    decimal price = 0;
    decimal totqty = 0;
    SqlConnection con = new SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID= itgrp;Password= power");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand(" select top 10 ID,IssueNo,Unitprice,Totqty,batchno  from jct_ops_sizing_recipe_unitprice_t where status='a' order by enterddate desc ", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);
            grdDetailselect.DataSource = ds.Tables[0];
            grdDetailselect.DataBind();
            //lnkclose.Visible = true;

        }
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {

     
            SqlCommand cmd = new SqlCommand("jct_ops_sizing_recipe ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@issue_no", SqlDbType.VarChar).Value = txtissue.Text;
            //cmd.Parameters.Add("@datefrm", SqlDbType.DateTime).Value = txtdatefrm.Text;
            //cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = Txtdateto.Text;

            DataSet ds = new DataSet();

            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            grdDetail.Visible = true;




            //SqlDataReader dr = new SqlDataReader();
            //string sql = "select isnull(issueno,'') from sizing_recipe where issueno='" + txtissue.Text + "' and status='A'";
            cmd = new SqlCommand("select isnull(issueno,'') as issueno,status from jct_ops_sizing_recipe_t where issueno=@issueno and status in ('A','F')", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@issueno", SqlDbType.VarChar).Value = txtissue.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();




            dr.Read();
            if (dr.HasRows == true)
            {
                string cal;
                string status;
                cal = dr[0].ToString();
                status = dr[1].ToString();
                if (cal.Trim() == txtissue.Text.Trim() && status == "F")
                {
                    foreach (GridViewRow row in grdDetail.Rows)
                    {
                        TextBox solid = (TextBox)(row.Cells[8].FindControl("solid")); lnkcal.Visible = false;
                        lnkedit.Visible = false;
                        lnksave.Visible = false;
                        solid.Enabled = false;


                    }
                }


                else if (cal.Trim() == txtissue.Text.Trim() && status == "A")
                {
                    lnkcal.Visible = false;
                    lnkedit.Visible = false;
                    lnksave.Visible = false;

                }
                else
                {
                    lnkcal.Visible = true;
                    lnksave.Visible = true;
                    lnkclose.Visible = true;
                }
            }
            else
            {
                lnkcal.Visible = true;

            }
            con.Close();
        }
    
    protected void lnkcal_Click(object sender, EventArgs e)
    {
        try
        {
            totqty = 0;
            foreach (GridViewRow rw in grdDetail.Rows)
            {

                Label lb = (Label)rw.FindControl("lbnewqty");
                Label lb1 = (Label)rw.FindControl("lbrate");
                Label lb2 = (Label)rw.FindControl("lbval");
                Label lb3 = (Label)rw.FindControl("lbv");
                Label lb4 = (Label)rw.FindControl("lbtotqty");
                TextBox txt = (TextBox)rw.FindControl("solid");
                TextBox txt2 = (TextBox)rw.FindControl("Textbox2");


                lb.Text = (Math.Round((Convert.ToDecimal(txt.Text) / 100) * (Convert.ToDecimal(rw.Cells[7].Text)), 2)).ToString();
                decimal newqty = (Math.Round((Convert.ToDecimal(txt.Text) / 100) * (Convert.ToDecimal(rw.Cells[7].Text)), 2));
                decimal qty = Convert.ToDecimal(rw.Cells[7].Text);
                decimal val = Convert.ToDecimal(rw.Cells[8].Text);

                decimal newrate = (Convert.ToDecimal(Math.Round(val / qty, 2)));
                lb1.Text = newrate.ToString();

                //decimal newval = Math.Round((Convert.ToDecimal(lb.Text) * Convert.ToDecimal(lb1.Text)), 2);
                //lb2.Text = newval.ToString();
                if (rw.RowType == DataControlRowType.DataRow)
                {

                    price = price + val;
                    totqty = totqty + newqty;
                }


                //'grdDetail.FooterRow.Cells
                lb3 = (Label)grdDetail.FooterRow.FindControl("lbv");
                lb3.Text = price.ToString();
                lb4 = (Label)grdDetail.FooterRow.FindControl("lbtotqty");
                lb4.Text = totqty.ToString();
                lbunit.Visible = true;
                lblbatch.Visible = true;
                txtunit.Visible = true;
                txtbatch.Visible = true;
                txtunit.Text = Math.Round(price / totqty, 2).ToString();
                lnkcal.Visible = false;
                lnksave.Visible = true;
                lnkclose.Visible = true;
                lnkedit.Visible = false;

            
            }
        }
        catch
        {
            throw;
        }

    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetail_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }

    protected void lnksave_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("select isnull(ID,0) from jct_ops_sizing_recipe_t where issueno=@issueno ", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@issueno", SqlDbType.VarChar).Value = txtissue.Text;
        con.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();


        if (dr.HasRows == true)
        {
            string transid;

            transid = dr[0].ToString();

            if (transid == "0" || transid == null)
            {
                con.Close();
            }
            else
            {
                string script = "alert(' record already exists.!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                con.Close();
                return;
            }

        }
        con.Close();




        foreach (GridViewRow rw in grdDetail.Rows)
        {

            Label lb = (Label)rw.FindControl("lbnewqty");
            Label lb1 = (Label)rw.FindControl("lbrate");
            Label lb2 = (Label)rw.FindControl("lbval");
            Label lb3 = (Label)rw.FindControl("lbv");
            Label lb4 = (Label)rw.FindControl("lbtotqty");
            TextBox txt = (TextBox)rw.FindControl("solid");

            TextBox txt2 = (TextBox)rw.FindControl("Textbox2");

            //'grdDetail.FooterRow.Cells
            lb3 = (Label)grdDetail.FooterRow.FindControl("lbv");
            lb3.Text = price.ToString();
            lb4 = (Label)grdDetail.FooterRow.FindControl("lbtotqty");
            lb4.Text = totqty.ToString();

            lb.Text = (Math.Round((Convert.ToDecimal(txt.Text) / 100) * (Convert.ToDecimal(rw.Cells[7].Text)), 2)).ToString();
            decimal newqty = (Math.Round((Convert.ToDecimal(txt.Text) / 100) * (Convert.ToDecimal(rw.Cells[7].Text)), 2));
            decimal qty = Convert.ToDecimal(rw.Cells[7].Text);
            decimal val = Convert.ToDecimal(rw.Cells[8].Text);

            decimal newrate = (Convert.ToDecimal(Math.Round(val / qty, 2)));
            lb1.Text = newrate.ToString();

            //decimal newval = Math.Round((Convert.ToDecimal(lb.Text) * Convert.ToDecimal(lb1.Text)), 2);
            //lb2.Text = newval.ToString();
            if (rw.RowType == DataControlRowType.DataRow)
            {

                price = price + val;
                totqty = totqty + newqty;
            }

            lb3 = (Label)grdDetail.FooterRow.FindControl("lbv");
            lb3.Text = price.ToString();
            lb4 = (Label)grdDetail.FooterRow.FindControl("lbtotqty");
            lb4.Text = totqty.ToString();
            lbunit.Visible = true;
            lblbatch.Visible = true;
            txtunit.Visible = true;
            txtbatch.Visible = true;
            txtunit.Text = Math.Round(price / totqty, 2).ToString();

            ViewState["txtunit"] = txtunit.Text;
            ViewState["totqty"] = totqty;
            ViewState["issueno"] = (rw.Cells[0].Text);
            //SqlConnection con = new SqlConnection("Data Source=miserptest2;Initial Catalog=IMSDB;User ID= trainee;Password= trainee");
            cmd = new SqlCommand("jct_ops_sizing_recipe_insert ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            cmd.Parameters.Add("@issue_No", SqlDbType.VarChar, 20).Value = txtissue.Text;//(rw.Cells[2].Text);
            cmd.Parameters.Add("@issuedate", SqlDbType.DateTime).Value = (rw.Cells[3].Text);
            cmd.Parameters.Add("@stockNo", SqlDbType.VarChar, 20).Value = (rw.Cells[4].Text);
            cmd.Parameters.Add("@variantNo", SqlDbType.Int).Value = (rw.Cells[5].Text);
            cmd.Parameters.Add("@tran_uom", SqlDbType.VarChar, 20).Value = (rw.Cells[6].Text);
            cmd.Parameters.Add("@Qty_stock_UOM", SqlDbType.Decimal, 2).Value = (rw.Cells[7].Text);
            cmd.Parameters.Add("@value", SqlDbType.Decimal, 2).Value = (rw.Cells[8].Text);
            cmd.Parameters.Add("@solidPercent", SqlDbType.Decimal, 2).Value = txt.Text;
            cmd.Parameters.Add("@NewQty", SqlDbType.Decimal, 2).Value = lb.Text;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal, 2).Value = lb1.Text;
            //cmd.Parameters.Add("@NewValue", SqlDbType.Decimal, 2).Value = lb2.Text;

            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
            cmd.Parameters.Add("@totqty", SqlDbType.VarChar, 10).Value = lb4.Text;
            cmd.ExecuteNonQuery();

            con.Close();
            string script = "alert(' record saved sucesfully.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        string sql = "jct_ops_sizing_recipe_unitprice_insert";
        SqlCommand cmd1 = new SqlCommand(sql, con);
        cmd1.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd1.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
        cmd1.Parameters.Add("@issueno", SqlDbType.VarChar, 20).Value = txtissue.Text; //ViewState["issueno"];
        cmd1.Parameters.Add("@unitprice", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["txtunit"]);
        cmd1.Parameters.Add("@totqty", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState["totqty"]);
        cmd1.Parameters.Add("@batchno", SqlDbType.VarChar, 20).Value = txtbatch.Text;
        cmd1.ExecuteNonQuery();
        con.Close();
  

    }

    protected void lnkedit_Click(object sender, EventArgs e)
    {

        //SqlCommand cmd = new SqlCommand("jct_sizing_recipe_select", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //cmd.Parameters.Add("@issueNo", SqlDbType.VarChar, 20).Value = txtissue.Text;
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //grdDetail2.DataSource = ds.Tables[0];
        //grdDetail2.DataBind();
        //lnkedit.Visible = false;
        //lnksave.Visible = false;
        //grdDetail.Visible = false;



    }

    protected void grdDetail2_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdDetail2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //totqty = 0;

        //TextBox solid = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[9].Controls[0]));
        //TextBox stk2 = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[4].Controls[0]));
        //TextBox vrnt = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[5].Controls[0]));
        //TextBox qtytxt = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[7].Controls[0]));
        //TextBox valtxt = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[8].Controls[0]));
        //TextBox newqtytxt = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[10].Controls[0]));
        //TextBox newratetxt = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[11].Controls[0]));
        //TextBox newvaltxt = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[12].Controls[0]));
        //TextBox ID = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[1].Controls[0]));
        //TextBox issueno = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[2].Controls[0]));
        //TextBox issuedate = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[3].Controls[0]));
        //TextBox tran_uom = ((TextBox)(grdDetail2.Rows[e.RowIndex].Cells[6].Controls[0]));






        //decimal newqty = (Math.Round((Convert.ToDecimal(solid.Text) / 100) * (Convert.ToDecimal(qtytxt.Text)), 2));
        //decimal qty = Convert.ToDecimal(qtytxt.Text);
        //decimal val = Convert.ToDecimal(valtxt.Text);

        //decimal newrate = (Convert.ToDecimal(Math.Round(val / qty, 2)));


        //decimal newval = Math.Round((Convert.ToDecimal(newrate) * Convert.ToDecimal(newqty)), 2);

        ////  Updating the selected row..
        //SqlCommand cmd = new SqlCommand("sizing_recipe_update", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //SqlDataAdapter da = new SqlDataAdapter(cmd);



        //cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = ID.Text;
        //cmd.Parameters.Add("@issueNo", SqlDbType.VarChar, 20).Value = issueno.Text;
        //cmd.Parameters.Add("@issuedate", SqlDbType.DateTime).Value = issuedate.Text;
        //cmd.Parameters.Add("@stockNo", SqlDbType.VarChar, 20).Value = stk2.Text;
        //cmd.Parameters.Add("@variantNo", SqlDbType.Int).Value = vrnt.Text;
        //cmd.Parameters.Add("@tran_uom", SqlDbType.VarChar, 20).Value = tran_uom.Text;
        //cmd.Parameters.Add("@Qty_stock_UOM", SqlDbType.Decimal, 2).Value = qtytxt.Text;
        //cmd.Parameters.Add("@value", SqlDbType.Decimal, 2).Value = valtxt.Text;
        //cmd.Parameters.Add("@solidPercent", SqlDbType.Decimal, 2).Value = solid.Text;
        //cmd.Parameters.Add("@NewQty", SqlDbType.Decimal, 2).Value = newqty;
        //cmd.Parameters.Add("@Rate", SqlDbType.Decimal, 2).Value = newrate;
        //cmd.Parameters.Add("@NewValue", SqlDbType.Decimal, 2).Value = newval;
        ////cmd.Parameters.Add("@unitprice", SqlDbType.Decimal, 2).Value = 0;
        //cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["Empcode"];


        //con.Open();
        //cmd.ExecuteNonQuery();
        //grdDetail2.EditIndex = -1;
        //grdDetail2.DataBind();
        //con.Close();
        //cmd = new SqlCommand(" select   top 10 ID,IssueNo,Unitprice,Totqty  from sizing_recipe_unitprice where status='a' order by enterddate desc ", con);
        //cmd.CommandType = CommandType.Text;
        //SqlDataAdapter da1 = new SqlDataAdapter(cmd);

        //DataSet ds = new DataSet();

        //da1.Fill(ds);
        //grdDetailselect.DataSource = ds.Tables[0];
        //grdDetailselect.DataBind();

        //string script = "alert(' record updated sucesfully.!! ');";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);



    }

    protected void lnkclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("sizing_recipe.aspx");
    }

    protected void grdDetailselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtissue.Text = grdDetailselect.SelectedRow.Cells[2].Text;
        txtbatch.Text = grdDetailselect.SelectedRow.Cells[5].Text;
        txtbatch.Visible = true;
        if (txtbatch.Text=="&nbsp;")
        {
            txtbatch.Text = "";
        }
        lblbatch.Visible = true;
        fetch();

    }
    private void fetch()
    {
        SqlCommand cmd = new SqlCommand("jct_ops_sizing_recipe ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@issue_no", SqlDbType.VarChar).Value = txtissue.Text;
            //cmd.Parameters.Add("@datefrm", SqlDbType.DateTime).Value = txtdatefrm.Text;
            //cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = Txtdateto.Text;

            DataSet ds = new DataSet();

            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
            grdDetail.Visible = true;




            //SqlDataReader dr = new SqlDataReader();
            //string sql = "select isnull(issueno,'') from sizing_recipe where issueno='" + txtissue.Text + "' and status='A'";
            cmd = new SqlCommand("select isnull(issueno,'') as issueno,status from jct_ops_sizing_recipe_t where issueno=@issueno and status in ('A','F')", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@issueno", SqlDbType.VarChar).Value = txtissue.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();




            dr.Read();
            if (dr.HasRows == true)
            {
                string cal;
                string status;
                cal = dr[0].ToString();
                status = dr[1].ToString();
                if (cal.Trim() == txtissue.Text.Trim() && status == "F")
                {
                    foreach (GridViewRow row in grdDetail.Rows)
                    {
                        TextBox solid = (TextBox)(row.Cells[8].FindControl("solid")); lnkcal.Visible = false;
                        lnkedit.Visible = false;
                        lnksave.Visible = false;
                        solid.Enabled = false;


                    }
                }


                else if (cal.Trim() == txtissue.Text.Trim() && status == "A")
                {
                    lnkcal.Visible = false;
                    lnkedit.Visible = false;
                    lnksave.Visible = false;

                }
                else
                {
                    lnkcal.Visible = true;
                    lnksave.Visible = true;
                    lnkclose.Visible = true;
                }
            }
            else
            {
                lnkcal.Visible = true;

            }
            con.Close();
        }

    protected void chksel_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox sel = (CheckBox)grdDetail.HeaderRow.FindControl("chksel");

        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkbx");



            if (cb != null)
            {

                if (sel.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }


    }

    private void update()
    {
        totqty = 0;
        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkbx");
            if (cb.Checked == true)
            {
                
                TextBox solid = (TextBox)(row.Cells[9].FindControl("solid"));
                string solid1 = solid.Text;
                string stk2 = row.Cells[4].Text;
                string vrnt = row.Cells[5].Text;
                string qtytxt = row.Cells[7].Text;
                string valtxt = row.Cells[8].Text;
                string newqtytxt = row.Cells[10].Text;
                string newratetxt = row.Cells[11].Text;
                //string newvaltxt = row.Cells[12].Text;
                string ID = row.Cells[1].Text;
                string issueno = row.Cells[2].Text;
                string issuedate = row.Cells[3].Text;
                string tran_uom = row.Cells[6].Text;





                decimal newqty = (Math.Round((Convert.ToDecimal(solid.Text) / 100) * (Convert.ToDecimal(qtytxt)), 2));
                decimal qty = Convert.ToDecimal(qtytxt);
                decimal val = Convert.ToDecimal(valtxt);

                decimal newrate = (Convert.ToDecimal(Math.Round(val / qty, 2)));


                //decimal newval = Math.Round((Convert.ToDecimal(newrate) * Convert.ToDecimal(newqty)), 2);

                //  Updating the selected row..
                SqlCommand cmd = new SqlCommand("jct_ops_sizing_recipe_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);



                cmd.Parameters.Add("@ID", SqlDbType.Int, 20).Value = ID;
                cmd.Parameters.Add("@issueNo", SqlDbType.VarChar, 20).Value = issueno;
                cmd.Parameters.Add("@issuedate", SqlDbType.DateTime).Value = issuedate;
                cmd.Parameters.Add("@stockNo", SqlDbType.VarChar, 20).Value = stk2;
                cmd.Parameters.Add("@variantNo", SqlDbType.Int).Value = vrnt;
                cmd.Parameters.Add("@tran_uom", SqlDbType.VarChar, 20).Value = tran_uom;
                cmd.Parameters.Add("@Qty_stock_UOM", SqlDbType.Decimal, 2).Value = qtytxt;
                cmd.Parameters.Add("@value", SqlDbType.Decimal, 2).Value = valtxt;
                cmd.Parameters.Add("@solidPercent", SqlDbType.Decimal, 2).Value = solid.Text;
                cmd.Parameters.Add("@NewQty", SqlDbType.Decimal, 2).Value = newqty;
                cmd.Parameters.Add("@Rate", SqlDbType.Decimal, 2).Value = newrate;
                //cmd.Parameters.Add("@NewValue", SqlDbType.Decimal, 2).Value = newval;
                //cmd.Parameters.Add("@unitprice", SqlDbType.Decimal, 2).Value = 0;
                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["Empcode"];
                cmd.Parameters.Add("@batchno", SqlDbType.VarChar, 20).Value = txtbatch.Text;

                con.Open();
                cmd.ExecuteNonQuery();
                grdDetail2.EditIndex = -1;
                grdDetail2.DataBind();
                con.Close();
                cmd = new SqlCommand(" select   top 10 ID,IssueNo,Unitprice,Totqty,batchno  from jct_ops_sizing_recipe_unitprice_t where status='a' order by enterddate desc ", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da1.Fill(ds);
                grdDetailselect.DataSource = ds.Tables[0];
                grdDetailselect.DataBind();

                string script = "alert(' record updated sucesfully.!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                fetch();
            }
        }

    }

    protected void lnkupd_Click(object sender, EventArgs e)
    {
        update();
    }


    protected void lnkfreeze_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in grdDetail.Rows)
        {
            TextBox solid = (TextBox)(row.Cells[9].FindControl("solid"));

            SqlCommand cmd = new SqlCommand("jct_ops_sizing_freeze ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@issue_no", SqlDbType.VarChar).Value = txtissue.Text;
            cmd.Parameters.Add("@freezeby", SqlDbType.VarChar).Value = Session["Empcode"];

            //DataSet ds = new DataSet();
            con.Open();
            //da.Fill(ds);
            //grdDetail.DataSource = ds.Tables[0];
            //grdDetail.DataBind();
            //grdDetail.Visible = true;
            cmd.ExecuteNonQuery();
            con.Close();
            solid.Enabled = false;
            lnkclose.Visible = true;

            //fetch();

        }

        string script = "alert(' record freeze u cant change!! ');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
 
}



    

      


 

       

