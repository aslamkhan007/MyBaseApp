using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;

public partial class Payroll_JCT_Payroll_Tax_Master_Update : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string cardno;
    string empcode;
    string FlagCheck = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlantList();
            Locationbind();
            AttendenceDate();
        }
    }


    protected void ddldedtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldedtype.SelectedItem.Value == "Tax Salary Details")
        {
            Response.Redirect("JCT_Payroll_Tax_Master_Update.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "Comparision")
        {
            Response.Redirect("JCT_Payroll_Tax_Master_Update_Comparision.aspx");
        }

        if (ddldedtype.SelectedItem.Value == "HRA Affidavit")
        {
            Response.Redirect("Jct_Payroll_TaxHra_Exemption.aspx");
        }

    }


    public void AttendenceDate()
    {
        string sqlqry = "Jct_Payroll_Tax_Current_FIYear";
        SqlCommand cmd = new SqlCommand(sqlqry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
                txttodate.Text = dr["FIYear"].ToString();
            }
            dr.Close();
        }
    }

    private void PlantList()
    {
        sql = "Jct_Payroll_Plantlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "LongDescription";
        ddlplant.DataValueField = "PlantCode";
        ddlplant.DataBind();

    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Locationbind();
        grdDetail.DataSource = null;
        grdDetail.DataBind();
    }

    public void Locationbind()
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" + ddlplant.SelectedItem.Value + "'", obj.Connection());
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "Location_description";
        ddlLocation.DataValueField = "Location_code";
        ddlLocation.DataBind();
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
            grdDetail.DataSource = null;
            grdDetail.DataBind();
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecord();
            Panel4.Visible = true;
            Panel1.Visible = true;
            lnkapply.Enabled = true;
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


    public void FetchRecord()
    {
        SqlCommand cmd = new SqlCommand("JCT_Payroll_Tax_Master", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
        cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 10).Value = txttodate.Text;
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        grdDetail.DataSource = dt;
        grdDetail.DataBind();

        if (dt.Rows.Count == 0)
        {
            cmd = new SqlCommand("JCT_Payroll_Tax_Master_NoRecordGridview", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grdDetail.DataSource = dt;
            grdDetail.DataBind();

        }
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                //TextBox txt1 = (TextBox)rw.FindControl("txtAccnum");
                TextBox txt1 = (TextBox)gvRow.FindControl("txtAccnum");
                TextBox txtSal_04 = (TextBox)gvRow.FindControl("txtSal_04");
                TextBox txtSal05 = (TextBox)gvRow.FindControl("txtSal05");
                TextBox txtSal06 = (TextBox)gvRow.FindControl("txtSal06");
                TextBox txtSal07 = (TextBox)gvRow.FindControl("txtSal07");
                TextBox txtSal08 = (TextBox)gvRow.FindControl("txtSal08");
                TextBox txtSal09 = (TextBox)gvRow.FindControl("txtSal09");
                TextBox txtSal10 = (TextBox)gvRow.FindControl("txtSal10");
                TextBox txtSal11 = (TextBox)gvRow.FindControl("txtSal11");
                TextBox txtSal12 = (TextBox)gvRow.FindControl("txtSal12");
                TextBox txtSal13 = (TextBox)gvRow.FindControl("txtSal13");
                TextBox txtSal14 = (TextBox)gvRow.FindControl("txtSal14");
                TextBox txtSal_15 = (TextBox)gvRow.FindControl("txtSal_15");
                TextBox txtHra04 = (TextBox)gvRow.FindControl("txtHra04");
                TextBox txtHra05 = (TextBox)gvRow.FindControl("txtHra05");
                TextBox txtHra06 = (TextBox)gvRow.FindControl("txtHra06");
                TextBox txtHra07 = (TextBox)gvRow.FindControl("txtHra07");
                TextBox txtHra08 = (TextBox)gvRow.FindControl("txtHra08");
                TextBox txtHra09 = (TextBox)gvRow.FindControl("txtHra09");
                TextBox txtHra10 = (TextBox)gvRow.FindControl("txtHra10");
                TextBox txtHra111 = (TextBox)gvRow.FindControl("txtHra11");
                TextBox txtHra12 = (TextBox)gvRow.FindControl("txtHra12");
                TextBox txtHra13 = (TextBox)gvRow.FindControl("txtHra13");
                TextBox txtHra14 = (TextBox)gvRow.FindControl("txtHra14");
                TextBox txtHra15 = (TextBox)gvRow.FindControl("txtHra15");


                TextBox txtFa04 = (TextBox)gvRow.FindControl("txtFa04");
                TextBox txtFa05 = (TextBox)gvRow.FindControl("txtFa05");
                TextBox txtFa06 = (TextBox)gvRow.FindControl("txtFa06");
                TextBox txtFa07 = (TextBox)gvRow.FindControl("txtFa07");
                TextBox txtFa08 = (TextBox)gvRow.FindControl("txtFa08");
                TextBox txtFa09 = (TextBox)gvRow.FindControl("txtFa09");
                TextBox txtFa10 = (TextBox)gvRow.FindControl("txtFa10");
                TextBox txtFa11 = (TextBox)gvRow.FindControl("txtFa11");
                TextBox txtFa12 = (TextBox)gvRow.FindControl("txtFa12");
                TextBox txtFa13 = (TextBox)gvRow.FindControl("txtFa13");
                TextBox txtFa14 = (TextBox)gvRow.FindControl("txtFa14");
                TextBox txtFa15 = (TextBox)gvRow.FindControl("txtFa15");


                TextBox txtUni04 = (TextBox)gvRow.FindControl("txtUni04");
                TextBox txtUni05 = (TextBox)gvRow.FindControl("txtUni05");
                TextBox txtUni06 = (TextBox)gvRow.FindControl("txtUni06");
                TextBox txtUni07 = (TextBox)gvRow.FindControl("txtUni07");
                TextBox txtUni08 = (TextBox)gvRow.FindControl("txtUni08");
                TextBox txtUni09 = (TextBox)gvRow.FindControl("txtUni09");
                TextBox txtUni10 = (TextBox)gvRow.FindControl("txtUni10");
                TextBox txtUni11 = (TextBox)gvRow.FindControl("txtUni11");
                TextBox txtUni12 = (TextBox)gvRow.FindControl("txtUni12");
                TextBox txtUni13 = (TextBox)gvRow.FindControl("txtUni13");
                TextBox txtUni14 = (TextBox)gvRow.FindControl("txtUni14");
                TextBox txtUni15 = (TextBox)gvRow.FindControl("txtUni15");



                TextBox txtPf04 = (TextBox)gvRow.FindControl("txtPf04");
                TextBox txtPf05 = (TextBox)gvRow.FindControl("txtPf05");
                TextBox txtPf06 = (TextBox)gvRow.FindControl("txtPf06");
                TextBox txtPf07 = (TextBox)gvRow.FindControl("txtPf07");
                TextBox txtPf08 = (TextBox)gvRow.FindControl("txtPf08");
                TextBox txtPf09 = (TextBox)gvRow.FindControl("txtPf09");
                TextBox txtPf10 = (TextBox)gvRow.FindControl("txtPf10");
                TextBox txtPf11 = (TextBox)gvRow.FindControl("txtPf11");
                TextBox txtPf12 = (TextBox)gvRow.FindControl("txtPf12");
                TextBox txtPf13 = (TextBox)gvRow.FindControl("txtPf13");
                TextBox txtPf14 = (TextBox)gvRow.FindControl("txtPf14");
                TextBox txtPf15 = (TextBox)gvRow.FindControl("txtPf15");



                TextBox txtIt04 = (TextBox)gvRow.FindControl("txtIt04");
                TextBox txtIt05 = (TextBox)gvRow.FindControl("txtIt05");
                TextBox txtIt06 = (TextBox)gvRow.FindControl("txtIt06");
                TextBox txtIt07 = (TextBox)gvRow.FindControl("txtIt07");
                TextBox txtIt08 = (TextBox)gvRow.FindControl("txtIt08");
                TextBox txtIt09 = (TextBox)gvRow.FindControl("txtIt09");
                TextBox txtIt10 = (TextBox)gvRow.FindControl("txtIt10");
                TextBox txtIt11 = (TextBox)gvRow.FindControl("txtIt11");
                TextBox txtIt12 = (TextBox)gvRow.FindControl("txtIt12");
                TextBox txtIt13 = (TextBox)gvRow.FindControl("txtIt13");
                TextBox txtIt14 = (TextBox)gvRow.FindControl("txtIt14");
                TextBox txtIt15 = (TextBox)gvRow.FindControl("txtIt15");


                TextBox txtPanno = (TextBox)gvRow.FindControl("txtPanno");

                TextBox txtTaxConveyanceAmt = (TextBox)gvRow.FindControl("txtTaxConveyanceAmt");
                TextBox txtYrTaxableConveyance = (TextBox)gvRow.FindControl("txtYrTaxableConveyance");
                TextBox txtWaterRate = (TextBox)gvRow.FindControl("txtWaterRate");
                TextBox txtPerkAccomdation = (TextBox)gvRow.FindControl("txtPerkAccomdation");
                TextBox txtPerkFurniture = (TextBox)gvRow.FindControl("txtPerkFurniture");


                TextBox txtPrf04 = (TextBox)gvRow.FindControl("txtPrf04");
                TextBox txtPrf05 = (TextBox)gvRow.FindControl("txtPrf05");
                TextBox txtPrf06 = (TextBox)gvRow.FindControl("txtPrf06");
                TextBox txtPrf07 = (TextBox)gvRow.FindControl("txtPrf07");
                TextBox txtPrf08 = (TextBox)gvRow.FindControl("txtPrf08");
                TextBox txtPrf09 = (TextBox)gvRow.FindControl("txtPrf09");
                TextBox txtPrf10 = (TextBox)gvRow.FindControl("txtPrf10");
                TextBox txtPrf11 = (TextBox)gvRow.FindControl("txtPrf11");
                TextBox txtPrf12 = (TextBox)gvRow.FindControl("txtPrf12");
                TextBox txtPrf13 = (TextBox)gvRow.FindControl("txtPrf13");
                TextBox txtPrf14 = (TextBox)gvRow.FindControl("txtPrf14");
                TextBox txtPrf15 = (TextBox)gvRow.FindControl("txtPrf15");

                //if (string.IsNullOrEmpty(txt1.Text))
                //{
                //    string script = "alert('Please Enter Account Number.!! ');";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //    return;
                //}
                //else
                //{
                sql = "JCT_Payroll_Tax_Master_Insert";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 10).Value = txttodate.Text;
                cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
                cmd.Parameters.Add("@Sal_04", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal_04.Text);
                cmd.Parameters.Add("@Hra_04", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra04.Text);
                cmd.Parameters.Add("@Fa_04", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa04.Text);
                cmd.Parameters.Add("@Uni_04", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni04.Text);
                cmd.Parameters.Add("@PF_04", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf04.Text);
                cmd.Parameters.Add("@IT_04", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt04.Text);




                cmd.Parameters.Add("@Sal_05", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal05.Text);
                cmd.Parameters.Add("@Hra_05", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra05.Text);
                cmd.Parameters.Add("@Fa_05", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa05.Text);
                cmd.Parameters.Add("@Uni_05", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni05.Text);
                cmd.Parameters.Add("@PF_05", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf05.Text);
                cmd.Parameters.Add("@IT_05", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt05.Text);


                cmd.Parameters.Add("@Sal_06", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal06.Text);
                cmd.Parameters.Add("@Hra_06", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra06.Text);
                cmd.Parameters.Add("@Fa_06", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa06.Text);
                cmd.Parameters.Add("@Uni_06", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni06.Text);
                cmd.Parameters.Add("@PF_06", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf06.Text);
                cmd.Parameters.Add("@IT_06", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt06.Text);


                cmd.Parameters.Add("@Sal_07", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal07.Text);
                cmd.Parameters.Add("@Hra_07", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra07.Text);
                cmd.Parameters.Add("@Fa_07", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa07.Text);
                cmd.Parameters.Add("@Uni_07", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni07.Text);
                cmd.Parameters.Add("@PF_07", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf07.Text);
                cmd.Parameters.Add("@IT_07", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt07.Text);

                cmd.Parameters.Add("@Sal_08", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal08.Text);
                cmd.Parameters.Add("@Hra_08", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra08.Text);
                cmd.Parameters.Add("@Fa_08", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa08.Text);
                cmd.Parameters.Add("@Uni_08", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni08.Text);
                cmd.Parameters.Add("@PF_08", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf08.Text);
                cmd.Parameters.Add("@IT_08", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt08.Text);

                cmd.Parameters.Add("@Sal_09", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal09.Text);
                cmd.Parameters.Add("@Hra_09", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra09.Text);
                cmd.Parameters.Add("@Fa_09", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa09.Text);
                cmd.Parameters.Add("@Uni_09", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni09.Text);
                cmd.Parameters.Add("@PF_09", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf09.Text);
                cmd.Parameters.Add("@IT_09", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt09.Text);

                cmd.Parameters.Add("@Sal_10", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal10.Text);
                cmd.Parameters.Add("@Hra_10", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra10.Text);
                cmd.Parameters.Add("@Fa_10", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa10.Text);
                cmd.Parameters.Add("@Uni_10", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni10.Text);
                cmd.Parameters.Add("@PF_10", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf10.Text);
                cmd.Parameters.Add("@IT_10", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt10.Text);

                cmd.Parameters.Add("@Sal_11", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal11.Text);
                cmd.Parameters.Add("@Hra_11", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra111.Text);
                cmd.Parameters.Add("@Fa_11", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa11.Text);
                cmd.Parameters.Add("@Uni_11", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni11.Text);
                cmd.Parameters.Add("@PF_11", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf11.Text);
                cmd.Parameters.Add("@IT_11", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt11.Text);

                cmd.Parameters.Add("@Sal_12", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal12.Text);
                cmd.Parameters.Add("@Hra_12", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra12.Text);
                cmd.Parameters.Add("@Fa_12", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa12.Text);
                cmd.Parameters.Add("@Uni_12", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni12.Text);
                cmd.Parameters.Add("@PF_12", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf12.Text);
                cmd.Parameters.Add("@IT_12", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt12.Text);

                cmd.Parameters.Add("@Sal_13", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal13.Text);
                cmd.Parameters.Add("@Hra_13", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra13.Text);
                cmd.Parameters.Add("@Fa_13", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa13.Text);
                cmd.Parameters.Add("@Uni_13", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni13.Text);
                cmd.Parameters.Add("@PF_13", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf13.Text);
                cmd.Parameters.Add("@IT_13", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt13.Text);


                cmd.Parameters.Add("@Sal_14", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal14.Text);
                cmd.Parameters.Add("@Hra_14", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra14.Text);
                cmd.Parameters.Add("@Fa_14", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa14.Text);
                cmd.Parameters.Add("@Uni_14", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni14.Text);
                cmd.Parameters.Add("@PF_14", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf14.Text);
                cmd.Parameters.Add("@IT_14", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt14.Text);

                cmd.Parameters.Add("@Sal_15", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtSal_15.Text);
                cmd.Parameters.Add("@Hra_15", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtHra15.Text);
                cmd.Parameters.Add("@Fa_15", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtFa15.Text);
                cmd.Parameters.Add("@Uni_15", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtUni15.Text);
                cmd.Parameters.Add("@PF_15", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPf15.Text);
                cmd.Parameters.Add("@IT_15", SqlDbType.Decimal, 10).Value = Convert.ToDecimal(txtIt15.Text);


                cmd.Parameters.Add("@Panno", SqlDbType.VarChar, 30).Value = txtPanno.Text;
                cmd.Parameters.Add("@Current_Conveyance", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtTaxConveyanceAmt.Text);
                cmd.Parameters.Add("@Perk_TaxConveyance", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtYrTaxableConveyance.Text);
                cmd.Parameters.Add("@Water_Rate", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtWaterRate.Text);
                cmd.Parameters.Add("@Perk_Accomdation", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPerkAccomdation.Text);
                cmd.Parameters.Add("@Perk_Furniture", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPerkFurniture.Text);

                //cmd.Parameters.Add("@Empname", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(gvRow.Cells[1].Text.Replace("&nbsp;", ""));
                //cmd.Parameters.Add("@Housetype", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(gvRow.Cells[3].Text.Replace("&nbsp;", ""));


                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["Empcode"];

                cmd.Parameters.Add("@trpt_04", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf04.Text);
                cmd.Parameters.Add("@trpt_05", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf05.Text);
                cmd.Parameters.Add("@trpt_06", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf06.Text);
                cmd.Parameters.Add("@trpt_07", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf07.Text);
                cmd.Parameters.Add("@trpt_08", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf08.Text);
                cmd.Parameters.Add("@trpt_09", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf09.Text);
                cmd.Parameters.Add("@trpt_10", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf10.Text);
                cmd.Parameters.Add("@trpt_11", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf11.Text);
                cmd.Parameters.Add("@trpt_12", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf12.Text);
                cmd.Parameters.Add("@trpt_13", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf13.Text);
                cmd.Parameters.Add("@trpt_14", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf14.Text);
                cmd.Parameters.Add("@trpt_15", SqlDbType.Decimal, 8).Value = Convert.ToDecimal(txtPrf15.Text);

                cmd.ExecuteNonQuery();
                //bindgrid();

                //}

            }

            if (lnkapply.Text == "Save")
            {
                string script = "alert('Record  Saved.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //lnkapply.Enabled = false;
            }


            else if (lnkapply.Text == "Update")
            {
                string script = "alert('Record  Updated.!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                //lnkapply.Enabled = false;
            }
            grdDetail.DataSource = null;
            grdDetail.DataBind();
        }
        catch (Exception ex)
        {
            string script = "alert(''" + ex.Message + "'');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("JCT_Payroll_Tax_Master_Update.aspx");
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        Excel();
    }

    public void Excel()
    {
        string SqlPass = null;
        SqlCommand Cmd = new SqlCommand();
        SqlPass = "JCT_Payroll_Tax_Master";
        Cmd = new SqlCommand(SqlPass, obj.Connection());
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
        Cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;

        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        Da.Fill(ds);



        //SqlCommand cmd = new SqlCommand("JCT_Payroll_Tax_Master", obj.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        ////cmd.Parameters.Add("@FIYear", SqlDbType.VarChar, 10).Value = txttodate.Text;
        //cmd.Parameters.Add("@plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
        //cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        //cmd.ExecuteNonQuery();        


        DataTable dt = ds.Tables[0];
        string attachment = "attachment; filename=Employee.xls";
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jct_Payroll_Earning_Tax_Report.aspx");
    }
}