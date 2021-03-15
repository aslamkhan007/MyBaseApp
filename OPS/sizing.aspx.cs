using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class sizing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string txtfromdate = (txtFromDate.Text);
            string txttodate = (txtToDate.Text);
            DateTime a = Convert.ToDateTime(txtfromdate);
            DateTime b = Convert.ToDateTime(txttodate);
            if (a > b)
            {
                //throw new ApplicationException("from date can't be more than todate");
                string script = "alert('FROMDATE CANNOT BE GREATER THAN TODATE');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        catch (Exception exception)
        {
            // Response.Write("<script>alert('" + exception.Message + "');</script>");
             string script = "alert('" + exception.Message + "');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        grdBeamInfo.Visible = false;

    }
    protected void grdBeamInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButton selectButton = (RadioButton)sender;
        GridViewRow row = (GridViewRow)selectButton.Parent.Parent;
        int a = row.RowIndex;
        String cellText = this.grdBeamInfo.SelectedRow.Cells[1].Text;
        foreach (GridViewRow rw in grdBeamInfo.Rows)
        {
            if (selectButton.Checked)
            {
                if (rw.RowIndex != a)
                {
                    RadioButton rd = rw.FindControl("rdbtnBeamInfo") as RadioButton;
                    rd.Checked = false;
                }
            }

        }
    }
    protected void rdbtnBeamInfo_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton selectButton = (RadioButton)sender;
        GridViewRow row = (GridViewRow)selectButton.Parent.Parent;
        int a = row.RowIndex;
        foreach (GridViewRow rw in grdBeamInfo.Rows)
        {
            if (selectButton.Checked)
            {
                if (rw.RowIndex != a)
                {
                    RadioButton rd = rw.FindControl("rdbtnBeamInfo") as RadioButton;
                    rd.Checked = false; 
                }
            }
            string con = "Data Source=misdev;Initial Catalog=production;User ID=itgrp;Password=power";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();
            string sqlquery1 = "sizing_consumption";
            SqlCommand cmd1 = new SqlCommand(sqlquery1, sqlcon);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdSizingInfo.DataSource = ds;
            grdSizingInfo.DataBind();
            sqlcon.Close();
            //btnSave.Visible = true;  
            lnkBtnSave.Visible = true;
        }

    }

    protected void ChkBeamSizinfo_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow rw in grdSizingInfo.Rows)
        {
            CheckBox chk = (CheckBox)rw.FindControl("ChkBeamSizinfo");
            TextBox txtname = (TextBox)rw.FindControl("txtgridsizinginfo");
            if (chk.Checked)
            {
                txtname.Focus();
                txtname.Enabled = true;
            }
            else
            {
                txtname.Enabled = false;
            }
        }
    }
 
    public void BindThirdGrid()
    {
        string con = "Data Source=misdev;Initial Catalog=production;User ID=itgrp;Password=power";
        SqlConnection sqlcon = new SqlConnection(con);
        sqlcon.Open();
        SqlTransaction tran = sqlcon.BeginTransaction();
        try
        {
            foreach (GridViewRow rw in grdBeamInfo.Rows)
            {
                RadioButton rb = (RadioButton)rw.FindControl("rdbtnBeamInfo");
                if (rb.Checked)
                {
                    string iss_no = rw.Cells[1].Text;
                    string job_no = rw.Cells[2].Text;
                    string length = rw.Cells[3].Text;
                    int sort_no = Convert.ToInt16(rw.Cells[4].Text);
                    int mc_no = Convert.ToInt16(rw.Cells[5].Text);
                    string machinetype = rw.Cells[6].Text;
                    string iss_dt = rw.Cells[7].Text;


                    foreach (GridViewRow rw1 in grdSizingInfo.Rows)
                    {
                        CheckBox chkbox = (CheckBox)rw1.FindControl("ChkBeamSizinfo");
                        TextBox txtname = (TextBox)rw1.FindControl("txtgridsizinginfo");
                        string abc = txtname.Text;
                        if (chkbox.Checked == true)
                        {
                            string issue = rw1.Cells[2].Text;
                            string unitprice = rw1.Cells[4].Text;
                            string totqty = rw1.Cells[5].Text;
                            string consumed = rw1.Cells[6].Text;
                            string balance = rw1.Cells[7].Text;
                            string i = rw1.Cells[7].Text;
                            decimal var = Convert.ToDecimal(i);
                            if (abc == "")
                            {
                                throw new ApplicationException("no value in textbox selected!!!!!");
                                //string script2 = "alert('no value in textbox selected!!!!!');";
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                            }
                            string textname = txtname.Text;
                            decimal textnameid;
                            if (!decimal.TryParse(textname, out textnameid))
                            {
                                throw new ApplicationException("please enter correct quantity!!!!!");
                                //string script1 = "alert('please enter correct quantity!!!!!');";
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
                            }
                            else
                            {
                                decimal var2 = Convert.ToDecimal(txtname.Text);
                                if (var2 > var)
                                {
                                    throw new ApplicationException("consumption cannot be greater than total balance!!!!!");
                                    //string script2 = "alert('consumption cannot be greater than total balance!!!!!');";
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                                }
                                else if (var2 == 0)
                                {
                                    throw new ApplicationException("Zero or Null Value Cannot be Inserted !!!!!");
                                    //string script3 = "alert('Zero or Null Value Cannot be Inserted !!!!!');";
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script3, true);
                                }
                                else
                                {

                                    decimal length1 = Convert.ToDecimal(length);
                                    decimal textbox = Convert.ToDecimal(abc);
                                    decimal totqtys = Convert.ToDecimal(totqty);
                                    decimal unitprices = Convert.ToDecimal(unitprice);
                                    decimal consumedd = Convert.ToDecimal(consumed);
                                    decimal balances = Convert.ToDecimal(balance);
                                    //cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName.Text;
                                    //string sqlquery2 = "insert into szg_warp_beam_dtl_copy (Current_consumption,ISSUE,totqty,unitprice,consumed,balance,status,insertion_date,iss_no,sort_no,mc_no,mc_type,job_no,Cost)" +
                                    //" values ( '" + textbox + "'," +
                                    //"  '" + issue + "' ,  '" + totqtys + "','" + unitprices + "','" + consumedd + "','" + balances + "','A',getdate(),'" + iss_no + "','" + sort_no + "','" + mc_no + "' ,'" + machinetype + "','" + job_no + "','"+ unitprices * textbox+"' ) ";
                                    string sqlquery2 = " szg_warp_beam_dtl_copy_INSERT_UPDATE";
                                    SqlCommand cmd2 = new SqlCommand(sqlquery2, sqlcon, tran);
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.CommandText = "szg_warp_beam_dtl_copy_INSERT_UPDATE";
                                    cmd2.Parameters.Add("@Currentconsumption", SqlDbType.Decimal).Value = textbox;
                                    cmd2.Parameters.Add("@ISSUE", SqlDbType.VarChar).Value = issue;
                                    cmd2.Parameters.Add("@totqty", SqlDbType.Decimal).Value = totqtys;
                                    cmd2.Parameters.Add("@unitprice", SqlDbType.Decimal).Value = unitprices;
                                    cmd2.Parameters.Add("@consumed", SqlDbType.Decimal).Value = consumedd;
                                    cmd2.Parameters.Add("@balance", SqlDbType.Decimal).Value = balances;
                                    cmd2.Parameters.Add("@status", SqlDbType.VarChar).Value = 'A';
                                    cmd2.Parameters.Add("@issno", SqlDbType.VarChar).Value = iss_no;
                                    cmd2.Parameters.Add("@sortno", SqlDbType.Int).Value = sort_no;
                                    cmd2.Parameters.Add("@mcno", SqlDbType.SmallInt).Value = mc_no;
                                    cmd2.Parameters.Add("@mctype", SqlDbType.VarChar).Value = machinetype;
                                    cmd2.Parameters.Add("@jobno", SqlDbType.VarChar).Value = job_no;
                                    cmd2.Parameters.Add("@Cost", SqlDbType.Decimal).Value = unitprices * textbox;
                                    SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                                    DataSet ds1 = new DataSet();
                                    da1.Fill(ds1);
                                    //cmd2.ExecuteNonQuery();
                                    //throw new ApplicationException("record  successfully inserted  !!!!!");
                                    //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('record  successfully inserted  ' );", true);
                                    //string script = "alert('record  successfully inserted !!!!!');";
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);                                                

                                }
                            }
                        }
                    }
                }
            }

            tran.Commit();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('record  successfully inserted  ' );", true);
            // RadioButton1_CheckedChanged1(sender, null);
            sqlcon.Close();
            string sqlquery1 = "sizing_consumption";
            sqlcon.Open();
            SqlCommand cmd1 = new SqlCommand(sqlquery1, sqlcon);
            cmd1.ExecuteNonQuery();
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdSizingInfo.DataSource = ds;
            grdSizingInfo.DataBind();
            sqlcon.Close();
            //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('record  successfully inserted ' );", true);
            sqlcon.Open();
            string sqlquery3 = "sizingentry";
            SqlCommand cmd3 = new SqlCommand(sqlquery3, sqlcon);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtFromDate.Text.ToString();
            cmd3.Parameters.Add("@todate", SqlDbType.DateTime).Value = txtToDate.Text.ToString();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            grdBeamInfo.DataSource = ds2;
            grdBeamInfo.DataBind();
            bindmethod();
            //throw new ApplicationException("record  successfully inserted !!!!!");
            ////  third grid to see the inserted records
            //string script = "alert('record  successfully inserted !!!!!');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch (ApplicationException exception)
        {
            tran.Rollback();
            //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Some error occured ' );", true);

            Response.Write("<script>alert('" + exception.Message + "');</script>");
        }

        catch (SqlException ex)
        {
            tran.Rollback();
            //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Some error occured ' );", true);
            Response.Write("<script>alert('" + ex.Message + "');</script>");           
        }
        finally
        {
            sqlcon.Close();
        }
    }

    private void bindmethod()
    {
        string con = "Data Source=misdev;Initial Catalog=production;User ID=itgrp;Password=power";
        SqlConnection sqlcon = new SqlConnection(con);
        sqlcon.Open();
        string querygrid3 = "select top 10  a.*,b.BatchNo from szg_warp_beam_dtl_copy a , jctdev..jct_ops_sizing_recipe_unitprice_t b where a.issue=b.issueno order by insertion_date desc  ";
        SqlCommand cmdgrid3 = new SqlCommand(querygrid3, sqlcon);
        SqlDataAdapter dagrid3 = new SqlDataAdapter(cmdgrid3);
        DataSet dsgrid3 = new DataSet();
        dagrid3.Fill(dsgrid3);
        grdRecentRecords.DataSource = dsgrid3;
        grdRecentRecords.DataBind();
        sqlcon.Close();
        foreach (GridViewRow rw in grdRecentRecords.Rows)
        {
            string a = Convert.ToString(rw.Cells[8].Text);
            if (a == "F")
            {       
                rw.Cells[0].Enabled = false;
                rw.Cells[1].Enabled = false;
                rw.Cells[2].Enabled = false;
                rw.Cells[3].Enabled = false;
                rw.Cells[4].Enabled = false;
                rw.Cells[5].Enabled = false;
                rw.Cells[6].Enabled = false;
                rw.Cells[7].Enabled = false;
                rw.Cells[8].Enabled = false;
                rw.Cells[9].Enabled = false;
                rw.Cells[10].Enabled = false;
                rw.Cells[11].Enabled = false;
             
            }
        }
    }
    protected void grdRecentRecords_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FREEZE")
        {
            // update status to f(freeze) when freeze button clicked 
            string con = "Data Source=misdev;Initial Catalog=production;User ID=itgrp;Password=power";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int selIndex = row.RowIndex;
            string issueno2 = row.Cells[5].Text.ToString();
            string issue = row.Cells[2].Text.ToString();
            //string serialno = row.Cells[6].Text.ToString();                         // issueno2 to ISSUE                                 //  issue to  SrNo
            //string sqlquery = "update  szg_warp_beam_dtl_copy set  status = 'F' where  ISSUE='" + issueno2 + "'  and SrNo ='" + issue + "'";
            string sqlquery = "update  szg_warp_beam_dtl_copy set  status = 'F' where  iss_no = '" + issue + "' ";
            SqlCommand cmd = new SqlCommand(sqlquery, sqlcon);
            cmd.ExecuteNonQuery();
            LinkButton delete = (LinkButton)row.FindControl("lnkfreeze");
            delete.Enabled = false;
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Record Freezed Now This Record cannot be Deleted ' );", true);
            bindmethod();
        }
        if (e.CommandName == "DELETE")
        {
            string con = "Data Source=misdev;Initial Catalog=production;User ID=itgrp;Password=power";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int selIndex = row.RowIndex;
            string issueno2 = row.Cells[5].Text.ToString();
            string issue = row.Cells[2].Text.ToString();                
            //string sqlquery = "delete from szg_warp_beam_dtl_copy where SrNo = '" + issue + "' and ISSUE='" + issueno2 + "' ";
            string sqlquery = "delete from szg_warp_beam_dtl_copy where iss_no = '" + issue + "'  ";
            SqlCommand cmd = new SqlCommand(sqlquery, sqlcon);
            cmd.ExecuteNonQuery();
            // gridview2 data updated again because one row has been deleted from gridview4( table szg_warp_beam_dtl_copy)
            string sqlquery1 = "sizing_consumption";
            SqlCommand cmd1 = new SqlCommand(sqlquery1, sqlcon);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdSizingInfo.DataSource = ds;
            grdSizingInfo.DataBind();
            //gridview4 again refreshed 
            bindmethod();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('deletion  successful ' );", true);
            sqlcon.Close();
            // gridview1 need again an updation otherwise deleted beam will not be visible in gridview1
            string cona = "Data Source=misdev;Initial Catalog=production;User ID=itgrp;Password=power";
            SqlConnection sqlcon1 = new SqlConnection(cona);
            sqlcon1.Open();
            string sqlquery2 = "sizingentry";
            SqlCommand cmd2 = new SqlCommand(sqlquery2, sqlcon1);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtFromDate.Text.ToString();
            cmd2.Parameters.Add("@todate", SqlDbType.DateTime).Value = txtToDate.Text.ToString();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            grdBeamInfo.DataSource = ds2;
            grdBeamInfo.DataBind();
            sqlcon.Close();
            grdBeamInfo.Visible = true;
            sqlcon1.Close();

        }
    }
    protected void grdRecentRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void lnkBtnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            string con = "Data Source=misdev;Initial Catalog=production;User ID=itgrp;Password=power";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();
            string txtfromdate = (txtFromDate.Text);
            string txttodate = (txtToDate.Text);
            DateTime a = Convert.ToDateTime(txtfromdate);
            DateTime b = Convert.ToDateTime(txttodate);
            if (a > b)
            {
                string script = "alert('FROMDATE CANNOT BE GREATER THAN TODATE');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            string sqlquery1 = "sizingentry";
            SqlCommand cmd1 = new SqlCommand(sqlquery1, sqlcon);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtfromdate;
            cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = txttodate;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdBeamInfo.DataSource = ds;
            grdBeamInfo.DataBind();
            grdBeamInfo.Visible = true;
            sqlcon.Close();
            sqlcon.Open();
            string querygrid3 = "select top 10  a.*,b.BatchNo from szg_warp_beam_dtl_copy a , jctdev..jct_ops_sizing_recipe_unitprice_t b where a.issue=b.issueno order by insertion_date desc";
            SqlCommand cmdgrid3 = new SqlCommand(querygrid3, sqlcon);
            SqlDataAdapter dagrid3 = new SqlDataAdapter(cmdgrid3);
            DataSet dsgrid3 = new DataSet();
            dagrid3.Fill(dsgrid3);
            grdRecentRecords.DataSource = dsgrid3;
            grdRecentRecords.DataBind();
            sqlcon.Close();
            PnlGrdBeamInfo.Visible = true;
            foreach (GridViewRow rw in grdRecentRecords.Rows)
            {
                string a1 = Convert.ToString(rw.Cells[8].Text);
                if (a1 == "F")
                {
                    rw.Cells[0].Enabled = false;
                    rw.Cells[1].Enabled = false;
                    rw.Cells[2].Enabled = false;
                    rw.Cells[3].Enabled = false;
                    rw.Cells[4].Enabled = false;
                    rw.Cells[5].Enabled = false;
                    rw.Cells[6].Enabled = false;
                    rw.Cells[7].Enabled = false;
                    rw.Cells[8].Enabled = false;
                    rw.Cells[9].Enabled = false;
                    rw.Cells[10].Enabled = false;
                    rw.Cells[11].Enabled = false;
                }
            }
        }
        catch (Exception exception)
        {
            // Response.Write("<script>alert('" + exception.Message + "');</script>");
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        BindThirdGrid();
        //try
        //{
        //    BindThirdGrid();
        //}
        //catch (Exception ex)
        //{

        //}
    }
}