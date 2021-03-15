using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class OPS_StockMaster : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Sr_no"] = 0;
        }
    }
    protected void grdStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdStock.PageIndex = e.NewPageIndex;
        grdStock.DataSource = SqlDataSource1;
        grdStock.DataBind();
    }
    protected void lnkSave_Click(object sender, EventArgs e)
    {
        SqlDataSource1.InsertParameters["Shed"].DefaultValue = ddlShed.SelectedItem.Value;
        SqlDataSource1.InsertParameters["Weave"].DefaultValue = txtWeave.Text;
        SqlDataSource1.InsertParameters["Reed_Count"].DefaultValue = txtReedCount.Text;
        SqlDataSource1.InsertParameters["Size"].DefaultValue = txtReedSize.Text;
        SqlDataSource1.InsertParameters["Stock"].DefaultValue = txtStock.Text;
        SqlDataSource1.InsertParameters["type"].DefaultValue = ddlStock.SelectedItem.Text;
        SqlDataSource1.InsertParameters["Stock_ToBe_Use"].DefaultValue = txtStockTobeUse.Text;
        SqlDataSource1.Insert();
        String script = "alert('Record Saved.');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        txtReedCount.Text = "";
        txtReedSize.Text = "";
        txtStock.Text = "";
        txtStockTobeUse.Text = "";
        txtWeave.Text = "";
        ddlShed.Items.IndexOf(ddlShed.Items.FindByText("Select"));
    }
    protected void txtReedCount_TextChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlShed.SelectedItem.Value.Substring(0, 1) == "R")
            {
                if (txtReedSize.Text != "")
                {
                    sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + " and Size=" + txtReedSize.Text + "  ";
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                            txtWeave.Text = dr[1].ToString();
                            txtReedSize.Text = dr[3].ToString();
                            txtStock.Text = dr[4].ToString();
                            ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                            txtStockTobeUse.Text = dr[6].ToString();

                        }
                    }
                    else
                    {
                        String script = "alert('No Stock For Reed Count - " + txtReedCount.Text + " and ReedSize - " + txtReedSize.Text + " of Shed=" + ddlShed.SelectedItem.Text + " ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
                else
                {
                    String script = "alert('Please Enter Reed Size.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }

            }
            else if (ddlShed.SelectedItem.Value.Substring(0, 1) == "S")
            {
                if (ddlStock.SelectedItem.Text == "Reed")
                {
                    if (txtReedSize.Text != "")
                    {
                        sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + " and Size=" + txtReedSize.Text + "  ";
                        SqlDataReader dr = obj1.FetchReader(sql);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                                txtWeave.Text = dr[1].ToString();
                                txtReedSize.Text = dr[3].ToString();
                                txtStock.Text = dr[4].ToString();
                                ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                                txtStockTobeUse.Text = dr[6].ToString();

                            }
                        }
                        else
                        {
                            String script = "alert('No Stock For Reed Count - " + txtReedCount.Text + " and ReedSize - " + txtReedSize.Text + " of Shed=" + ddlShed.SelectedItem.Text + " ');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        }
                    }
                    else
                    {
                        String script = "alert('Please Enter Reed Size.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
                else if (ddlStock.SelectedItem.Text == "Cam")
                {

                    sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Weave='" + txtWeave.Text + "'  ";
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                            txtWeave.Text = dr[1].ToString();
                            txtReedSize.Text = dr[3].ToString();
                            txtStock.Text = dr[4].ToString();
                            ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                            txtStockTobeUse.Text = dr[6].ToString();

                        }
                    }
                    else
                    {
                        String script = "alert('No Stock For Cam Weave - " + txtWeave.Text + "  of Shed=" + ddlShed.SelectedItem.Text + " ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }

                }
            }
            else if (ddlShed.SelectedItem.Value.Substring(0, 1) == "A")
            {
                if (ddlStock.SelectedItem.Text == "Reed")
                {
                    sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + " ";
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                            txtWeave.Text = dr[1].ToString();
                            txtReedSize.Text = dr[3].ToString();
                            txtStock.Text = dr[4].ToString();
                            ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                            txtStockTobeUse.Text = dr[6].ToString();

                        }
                    }
                    else
                    {
                        String script = "alert('No Stock For Reed Count - " + txtReedCount.Text + " and ReedSize - " + txtReedSize.Text + " of Shed=" + ddlShed.SelectedItem.Text + " ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
                else if (ddlStock.SelectedItem.Text == "Cam")
                {
                    sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Weave='" + txtWeave.Text + "'  ";
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                            txtWeave.Text = dr[1].ToString();
                            txtReedSize.Text = dr[3].ToString();
                            txtStock.Text = dr[4].ToString();
                            ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                            txtStockTobeUse.Text = dr[6].ToString();

                        }
                    }
                    else
                    {
                        String script = "alert('No Stock For Cam Weave - " + txtWeave.Text + "  of Shed=" + ddlShed.SelectedItem.Text + " ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }
            }

        }

        catch (Exception ex)
        {
            String script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    protected void lnkFirst_Click(object sender, EventArgs e)
    {
        sql = "Select Shed,Isnull(Weave,'') as Weave,Reed_Count,Size as [ReedSize],Stock,Type,Stock_ToBe_Use,SrNo from jct_ops_weaving_reed_tappered_stock where Status='A' and srno=(Select min(srno) from jct_ops_weaving_reed_tappered_stock where status='A' ) ";
        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                txtWeave.Text = dr[1].ToString();
                txtReedCount.Text = dr[2].ToString();
                txtReedSize.Text = dr[3].ToString();
                txtStock.Text = dr[4].ToString();
                ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                txtStockTobeUse.Text = dr[6].ToString();
                int SrNo = int.Parse(dr[7].ToString());
                ViewState["Sr_no"] = SrNo;
            }
        }
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        sql = "Select Shed,Isnull(Weave,'') as Weave,Reed_Count,Size as [ReedSize],Stock,Type,Stock_ToBe_Use,SrNo from jct_ops_weaving_reed_tappered_stock where Status='A' and srno=" + ViewState["Sr_no"] + " + 1 ";
        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                txtWeave.Text = dr[1].ToString();
                txtReedCount.Text = dr[2].ToString();
                txtReedSize.Text = dr[3].ToString();
                txtStock.Text = dr[4].ToString();
                ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                txtStockTobeUse.Text = dr[6].ToString();
                int SrNo = int.Parse(ViewState["Sr_no"].ToString()) + 1;
                ViewState["Sr_no"] = SrNo;
            }
        }
    }
    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        sql = "Select Shed,Isnull(Weave,'') as Weave,Reed_Count,Size as [ReedSize],Stock,Type,Stock_ToBe_Use,SrNo from jct_ops_weaving_reed_tappered_stock where Status='A' and srno=" + ViewState["Sr_no"] + " - 1 ";
        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                txtWeave.Text = dr[1].ToString();
                txtReedCount.Text = dr[2].ToString();
                txtReedSize.Text = dr[3].ToString();
                txtStock.Text = dr[4].ToString();
                ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                txtStockTobeUse.Text = dr[6].ToString();
                int SrNo = int.Parse(ViewState["Sr_no"].ToString()) - 1;
                ViewState["Sr_no"] = SrNo.ToString();
            }
        }
    }
    protected void lnkLast_Click(object sender, EventArgs e)
    {
        sql = "Select Shed,Isnull(Weave,'') as Weave,Reed_Count,Size as [ReedSize],Stock,Type,Stock_ToBe_Use,SrNo from jct_ops_weaving_reed_tappered_stock where Status='A' and srno=(Select max(srno) from jct_ops_weaving_reed_tappered_stock where status='A' ) ";
        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                txtWeave.Text = dr[1].ToString();
                txtReedCount.Text = dr[2].ToString();
                txtReedSize.Text = dr[3].ToString();
                txtStock.Text = dr[4].ToString();
                ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                txtStockTobeUse.Text = dr[6].ToString();
                int SrNo = int.Parse(dr[7].ToString());
                ViewState["Sr_no"] = SrNo.ToString();
            }
        }
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        if (lnkEdit.Text == "Edit")
        {
            lnkEdit.Text = "Update";
            lnkSave.Enabled = false;

        }
        else if (lnkEdit.Text == "Update")
        {
            if (ddlShed.SelectedItem.Value.Substring(0, 1) == "R")
            {
                sql = "Update jct_ops_weaving_reed_tappered_stock set Status='U',Eff_to=getdate() where Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + " and Size=" + txtReedSize.Text + "  ";
                obj1.UpdateRecord(sql);
            }
            else if (ddlShed.SelectedItem.Value.Substring(0, 1) == "S")
            {
                if (ddlStock.SelectedItem.Text == "Reed")
                {
                    sql = "Update jct_ops_weaving_reed_tappered_stock set Status='U',Eff_to=getdate() where Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + " and Size=" + txtReedSize.Text + "  ";
                    obj1.UpdateRecord(sql);
                }
                else if (ddlStock.SelectedItem.Text == "Cam")
                {
                    sql = "Update jct_ops_weaving_reed_tappered_stock set Status='U',Eff_to=getdate() where Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Weave='" + txtWeave.Text + "'  ";
                    obj1.UpdateRecord(sql);
                }
            }
            else if (ddlShed.SelectedItem.Value.Substring(0, 1) == "A")
            {
                if (ddlStock.SelectedItem.Text == "Reed")
                {
                    sql = "Update jct_ops_weaving_reed_tappered_stock set Status='U',Eff_to=getdate() where Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + "  ";
                    obj1.UpdateRecord(sql);
                }
                else if (ddlStock.SelectedItem.Text == "Cam")
                {
                    sql = "Update jct_ops_weaving_reed_tappered_stock set Status='U',Eff_to=getdate() where Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Weave='" + txtWeave.Text + "'  ";
                    obj1.UpdateRecord(sql);
                }
            }

            SqlDataSource1.InsertParameters["Shed"].DefaultValue = ddlShed.SelectedItem.Value;
            SqlDataSource1.InsertParameters["Weave"].DefaultValue = txtWeave.Text;
            SqlDataSource1.InsertParameters["Reed_Count"].DefaultValue = txtReedCount.Text;
            SqlDataSource1.InsertParameters["Size"].DefaultValue = txtReedSize.Text;
            SqlDataSource1.InsertParameters["Stock"].DefaultValue = txtStock.Text;
            SqlDataSource1.InsertParameters["type"].DefaultValue = ddlStock.SelectedItem.Text;
            SqlDataSource1.InsertParameters["Stock_ToBe_Use"].DefaultValue = txtStockTobeUse.Text;
            SqlDataSource1.Insert();

            String script = "alert('Record Updated.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void txtWeave_TextChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlShed.SelectedItem.Value.Substring(0, 1) == "A" || ddlShed.SelectedItem.Value.Substring(0, 1) == "S")
            {


                if (ddlStock.SelectedItem.Text == "Cam")
                {

                    sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Weave='" + txtWeave.Text + "'  ";
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                            txtWeave.Text = dr[1].ToString();
                            txtStock.Text = dr[4].ToString();
                            ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                            txtStockTobeUse.Text = dr[6].ToString();

                        }
                    }
                    else
                    {
                        String script = "alert('No Stock For Cam Weave - " + txtWeave.Text + "  of Shed=" + ddlShed.SelectedItem.Text + " ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }

                }
            }



        }

        catch (Exception ex)
        {

            String script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


    }
    protected void txtReedSize_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlShed.SelectedItem.Value.Substring(0, 1) == "R")
            {
                if (txtReedCount.Text != "")
                {
                    sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + " and Size=" + txtReedSize.Text + "  ";
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                            txtWeave.Text = dr[1].ToString();
                            txtReedSize.Text = dr[3].ToString();
                            txtStock.Text = dr[4].ToString();
                            ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                            txtStockTobeUse.Text = dr[6].ToString();

                        }
                    }
                    else
                    {
                        String script = "alert('No Stock For Reed Count - " + txtReedCount.Text + " and ReedSize - " + txtReedSize.Text + " of Shed=" + ddlShed.SelectedItem.Text + " ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }

                }
                else
                {
                    String script = "alert('Please Enter Reed Size.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }

            }
            else if (ddlShed.SelectedItem.Value.Substring(0, 1) == "S")
            {
                if (ddlStock.SelectedItem.Text == "Reed")
                {
                    if (txtReedCount.Text != "")
                    {
                        sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + " and Size=" + txtReedSize.Text + "  ";
                        SqlDataReader dr = obj1.FetchReader(sql);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                                txtWeave.Text = dr[1].ToString();
                                txtReedSize.Text = dr[3].ToString();
                                txtStock.Text = dr[4].ToString();
                                ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                                txtStockTobeUse.Text = dr[6].ToString();

                            }
                        }
                        else
                        {
                            String script = "alert('No Stock For Reed Count - " + txtReedCount.Text + " and ReedSize - " + txtReedSize.Text + " of Shed=" + ddlShed.SelectedItem.Text + " ');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        }
                    }
                    else
                    {
                        String script = "alert('Please Enter Reed Size.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }

            }
            else if (ddlShed.SelectedItem.Value.Substring(0, 1) == "A")
            {
                if (ddlStock.SelectedItem.Text == "Reed")
                {
                    sql = "Select Shed,Isnull(Weave,'') as Weave,isnull(Reed_Count,0) as Read_Count,Isnull(Size,0) as [ReedSize],isnull(Stock,0) as Size,Type,isnull(Stock_ToBe_Use,0) as Stock_ToBe_Use from jct_ops_weaving_reed_tappered_stock where Status='A' and Shed='" + ddlShed.SelectedItem.Value + "' and Type ='" + ddlStock.SelectedItem.Text + "' and Reed_Count=" + txtReedCount.Text + " ";
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ddlShed.SelectedIndex = ddlShed.Items.IndexOf(ddlShed.Items.FindByValue(dr[0].ToString()));
                            txtWeave.Text = dr[1].ToString();
                            txtReedSize.Text = dr[3].ToString();
                            txtStock.Text = dr[4].ToString();
                            ddlStock.SelectedIndex = ddlStock.Items.IndexOf(ddlStock.Items.FindByValue(dr[5].ToString()));
                            txtStockTobeUse.Text = dr[6].ToString();

                        }
                    }
                    else
                    {
                        String script = "alert('No Stock For Reed Count - " + txtReedCount.Text + " and ReedSize - " + txtReedSize.Text + " of Shed="+ ddlShed.SelectedItem.Text +" ');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    }
                }

            }
        }


        catch (Exception ex)
        {
            String script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
}