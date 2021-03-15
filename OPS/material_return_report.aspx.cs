using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using System.Net.Mail;

public partial class OPS_material_return_report : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex == 1)
        {
            lbdatefrm.Text = "Request DateFrom";
            lbdateto.Text = "Request DateTo";
           
        }
    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        if (ddlreason.SelectedItem.Text == "" && ddlstatus.SelectedItem.Text == "" && txtcustomer.Text == "" && txtdatefrom.Text == "" && txtdateto.Text == "" && txtreqraised.Text == "" && txtgrno.Text=="" && txtmrno.Text=="")
        {
            string script = "alert('Please Fill some Parameters then Fetch!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }

        try
        {

            SqlCommand cmd = new SqlCommand("jct_ops_material_return_report_shweta_updated", obj.Connection());


            cmd.CommandType = CommandType.StoredProcedure;

            if (!string.IsNullOrEmpty(txtdatefrom.Text))
               
            {
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdatefrom.Text);
            }
        

            if (!string.IsNullOrEmpty(txtdateto.Text))
            {
                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdateto.Text);
            }

            cmd.Parameters.Add("@grno", SqlDbType.VarChar, 200).Value = txtgrno.Text;
            cmd.Parameters.Add("@mrno", SqlDbType.VarChar, 200).Value = txtmrno.Text;
            cmd.Parameters.Add("@authstatus", SqlDbType.VarChar, 200).Value = ddlstatus.SelectedItem.Text;
            cmd.Parameters.Add("@customer", SqlDbType.VarChar, 200).Value = txtcustomer.Text.Split('~')[0].ToString();
            cmd.Parameters.Add("@reason", SqlDbType.VarChar, 200).Value = ddlreason.SelectedItem.Text;
            if (!string.IsNullOrEmpty(txtreqraised.Text))
            {
                string empcode = string.Empty;
                empcode = txtreqraised.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@raisedby", SqlDbType.VarChar, 200).Value = empcode.Split('~')[0].ToString();
            }
            else
            {
                cmd.Parameters.Add("@raisedby", SqlDbType.VarChar, 200).Value = "";
            }

            cmd.Parameters.Add("@flag", SqlDbType.VarChar, 10).Value = RadioButtonList1.SelectedItem.Value;
            //VISHAL BHARDWAJ|V-04349~MARKETING
       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail2.DataSource = ds.Tables[0];
            grdDetail2.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
   
    }

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        if (ddlreason.SelectedItem.Text == "" && ddlstatus.SelectedItem.Text == "" && txtcustomer.Text == "" && txtdatefrom.Text == "" && txtdateto.Text == "" && txtreqraised.Text == "")
        {
            string script = "alert('Please Fill some Parameters then Fetch!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            return;
        }

        SqlCommand cmd = new SqlCommand("jct_ops_material_return_report_shweta_updated", obj.Connection());


        cmd.CommandType = CommandType.StoredProcedure;

        if (!string.IsNullOrEmpty(txtdatefrom.Text))
        {
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdatefrom.Text);
        }


        if (!string.IsNullOrEmpty(txtdateto.Text))
        {
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdateto.Text);
        }
        cmd.Parameters.Add("@grno", SqlDbType.VarChar, 200).Value = txtgrno.Text;
        cmd.Parameters.Add("@mrno", SqlDbType.VarChar, 200).Value = txtmrno.Text;
        cmd.Parameters.Add("@authstatus", SqlDbType.VarChar, 200).Value = ddlstatus.SelectedItem.Text;
        cmd.Parameters.Add("@customer", SqlDbType.VarChar, 200).Value = txtcustomer.Text.Split('~')[0].ToString();
        cmd.Parameters.Add("@reason", SqlDbType.VarChar, 20).Value = ddlreason.SelectedItem.Text;
        cmd.Parameters.Add("@raisedby", SqlDbType.VarChar, 20).Value = txtreqraised.Text.Split('-')[0].ToString(); ;
        cmd.Parameters.Add("@flag", SqlDbType.VarChar, 10).Value = RadioButtonList1.SelectedItem.Value;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail2.DataSource = ds.Tables[0];
        grdDetail2.DataBind();

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; printerDetail.xls";
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


    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("material_return_report.aspx");
    }
}