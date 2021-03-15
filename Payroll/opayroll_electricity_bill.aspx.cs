using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class PayRoll_payroll_electricity_bill : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

        sql = "jct_payroll_ECE_bill";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@house_type", SqlDbType.VarChar).Value = ddlhousetype.SelectedItem.Text;
        if (!string.IsNullOrEmpty(txtEmployee.Text))
        {
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = txtEmployee.Text;
        }
        
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;

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
    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {



    }




    protected void lnksave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdDetail.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk");
            if (cb.Checked == true)
            {
                TextBox amount = (TextBox)(row.Cells[8].FindControl("txtamount"));
                TextBox unitrate = (TextBox)(row.Cells[7].FindControl("txtunitrate"));
                TextBox units = (TextBox)(row.Cells[6].FindControl("txtunits"));

                SqlCommand cmd = new SqlCommand("jct_payroll_electricity_bill_detail_insert", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 20).Value = (row.Cells[1].Text);
                cmd.Parameters.Add("@Dept_code", SqlDbType.VarChar,20).Value = (row.Cells[2].Text);
                cmd.Parameters.Add("@Desigination", SqlDbType.VarChar, 20).Value = (row.Cells[3].Text);
                cmd.Parameters.Add("@House_type", SqlDbType.VarChar,20).Value = (row.Cells[4].Text);
                cmd.Parameters.Add("@House_no", SqlDbType.VarChar,20).Value = (row.Cells[5].Text);
                cmd.Parameters.Add("@units", SqlDbType.Decimal).Value = units.Text;
                cmd.Parameters.Add("@unitrate", SqlDbType.Decimal, 2).Value = unitrate.Text;
                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar,20).Value = Session["Empcode"];
                cmd.Parameters.Add("@amount", SqlDbType.Decimal, 2).Value = amount.Text;
                cmd.ExecuteNonQuery();
                string script = "alert(' record saved sucesfully.!! ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            }
        }
    }
    protected void txtunits_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdDetail.Rows)
        {
             CheckBox cb = (CheckBox)row.FindControl("chk");
             if (cb.Checked == true)
             {

                 TextBox amount = (TextBox)(row.Cells[8].FindControl("txtamount"));
                  TextBox unitrate = (TextBox)(row.Cells[7].FindControl("txtunitrate"));
                 TextBox units = (TextBox)(row.Cells[6].FindControl("txtunits"));

                 amount.Text = Convert.ToDecimal(Convert.ToDecimal(unitrate.Text) * Convert.ToDecimal(units.Text)).ToString();
             }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
         string employeecode =txtEmployee.Text.Split('|')[1].ToString();
        sql = "jct_payroll_ECE_bill";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(ddlhousetype.Text))
        {
            cmd.Parameters.Add("@house_type", SqlDbType.VarChar).Value = ddlhousetype.SelectedItem.Text;
        }
        
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = employeecode;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
          
    }
}
