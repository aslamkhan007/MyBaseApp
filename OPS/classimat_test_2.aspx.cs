using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_classimat_test_2 : System.Web.UI.Page
{
    GridViewExportUtil gdv = new GridViewExportUtil();

  
   // SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=Trainee;User ID=trainee ;password=trainee");

    Connection obj = new Connection();
    Functions obj1 = new Functions();

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {

        if (ddlfdfualts.SelectedItem.Text == "AllFaults")
        {

            excel1.Visible = true;
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=Trainee;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_classimat_grd2", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrom.Text;
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
            cmd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
            cmd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
            //con.Open();
            cmd.ExecuteNonQuery();
            //con.Close();


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail1.DataSource = ds.Tables[0];
            grdDetail1.DataBind();

            //excel2.Visible = true;

            //SqlCommand sql = new SqlCommand("jct_ops_classimat_grd2", con);
            //sql.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter ada = new SqlDataAdapter(sql);
            //sql.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
            //DataSet dss = new DataSet();
            //ada.Fill(dss);
            //grdDetail2.DataSource = dss.Tables[0];
            //grdDetail2.DataBind();
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();


        }
        else

        {
            if (ddlfdfualts.SelectedItem.Text == "Fd Faults")
            excel3.Visible = true;
            //SqlConnection conn = new SqlConnection("Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;Password=trainee");

            SqlCommand cmdd = new SqlCommand("jct_ops_classimate_fd_cuts_new ", obj.Connection());
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrom.Text;
            cmdd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
            cmdd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
            cmdd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
            SqlDataAdapter adad = new SqlDataAdapter(cmdd);
            DataSet dsss = new DataSet();
            adad.Fill(dsss);
            grdDetail3.DataSource = dsss.Tables[0];
            grdDetail3.DataBind();


        }
    }
    protected void txtdatefrom_TextChanged(object sender, EventArgs e)
    {

    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
    }
        
        protected void lnkExcel_Click(object sender, EventArgs e)
    {
     
         //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=Trainee;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_classimat_grd2", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrom.Text;
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
            cmd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
            cmd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
            //con.Open();
            cmd.ExecuteNonQuery();
            //con.Close();


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail1.DataSource = ds.Tables[0];
            grdDetail1.DataBind();

            DataTable dt = ds.Tables[0];
        string attachment = "attachment; classimat_test_result.xls";
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

        //con.Close();
    }



        protected void excel2_Click(object sender, ImageClickEventArgs e)
        {
           
        }
        protected void excel3_Click(object sender, ImageClickEventArgs e)
        {
            //SqlConnection conn = new SqlConnection("Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;Password=trainee");

            SqlCommand cmdd = new SqlCommand("jct_ops_classimate_fd_cuts_new ", obj.Connection());
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrom.Text;
            cmdd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
            cmdd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
            cmdd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
            SqlDataAdapter adad = new SqlDataAdapter(cmdd);
            DataSet dsss = new DataSet();
            adad.Fill(dsss);
            grdDetail3.DataSource = dsss.Tables[0];
            grdDetail3.DataBind();

            DataTable dt = dsss.Tables[0];
            string attachment = "attachment; classimat_test_result.xls";
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

            //con.Close();
        }
        protected void excel1_Click(object sender, ImageClickEventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=Trainee;User ID=trainee ;password=trainee");
            SqlCommand cmd = new SqlCommand("jct_ops_classimat_grd2", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrom.Text;
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
            cmd.Parameters.Add("@count_1", SqlDbType.VarChar, 20).Value = txtcount.Text;
            cmd.Parameters.Add("@source", SqlDbType.VarChar, 30).Value = txtsource.Text;
            //con.Open();
            cmd.ExecuteNonQuery();
            //con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail1.DataSource = ds.Tables[0];
            grdDetail1.DataBind();

            DataTable dt = ds.Tables[0];
        string attachment = "attachment; classimat_test_result.xls";
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

        //con.Close();
        SqlCommand sql = new SqlCommand("jct_ops_classimat_grd2", obj.Connection());
        SqlDataAdapter ada = new SqlDataAdapter(sql);
        DataSet dss = new DataSet();
        ada.Fill(dss);
        grdDetail2.DataSource = dss.Tables[0];
        grdDetail2.DataBind();

        DataTable dtt = dss.Tables[0];
        string attachment2 = "attachment; classimat_test_result.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment2);
        Response.ContentType = "application/vnd.ms-excel";
        string tab1 = "";
        foreach (DataColumn dc in dtt.Columns)
        {
            Response.Write(tab1 + dc.ColumnName);
            tab1 = "\t";
        }
        Response.Write("\n");
        int a;
        foreach (DataRow dr in dtt.Rows)
        {
            tab = "";
            for (a = 0; a < dt.Columns.Count; a++)
            {
                Response.Write(tab + dr[a].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

        //con.Close();
        }

}