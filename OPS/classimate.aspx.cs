using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class OPS_classimate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtSearchItem_TextChanged(object sender, EventArgs e)
    {

        try
        {
            txtSearchItem.Text = txtSearchItem.Text.Split('~')[1].ToString();

            Get_Fabric_Particulars(txtSearchItem.Text);
            grdDetails.DataSource = SqlDataSource1;
            grdDetails.DataBind();
            grdDetails2.DataSource = SqlDataSource2;
            grdDetails2.DataBind();
            grdDetails.Visible = true;
            grdDetails2.Visible = true;
            grdFileUploadDetails.DataSource = SqlDataSource3;
            grdFileUploadDetails.DataBind();
            grdFileUploadDetails.Visible = true;
        }
        //catch (Exception exception)
        //{
        //    //Response.Write("<script>alert('" + exception.Message + "');</script>");
        //    lblErrMachineNo.Text = "Error Occured";//exception.Message;

        //}
        catch (Exception exception)
        {
            lblErrMachineNo.Message = "INVALID SORT NO : PLEASE ENTER ONLY NUMERIC VALUES UPTO 3 DIGITS"; 
            lblErrMachineNo.Display();
            //Response.Write("<script>alert('your record not found');</script>");
            txtSearchItem.Text = "";
            txtBlend.Text = "";
            txtEPI.Text = "";
            txtPPI.Text = "";
            txtWeight.Text = "";
            txtWeave.Text = "";
            txtWidth.Text = "";
            grdDetails.Visible = false;
            grdDetails2.Visible = false;
            grdFileUploadDetails.Visible = false;

        }
        
    
    }

    protected void Get_Fabric_Particulars(string @sort)
    {

        SqlConnection con = new SqlConnection("Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;password=trainee");
        con.Open();
        SqlCommand cmd = new SqlCommand("jct_ops_get_fabric_param", con);
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add  ("@sort",SqlDbType.NVarChar,8).Value =   txtSearchItem.Text;
        cmd.Parameters.Add("@sort", SqlDbType.Int,5).Value=txtSearchItem.Text;
        //cmd.Parameters.Add("@enq", SqlDbType.Int, 5).Value = txtSearchItem.Text;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
           
        {
            if (reader.HasRows)
            {
                txtBlend.Text = reader["blend"].ToString();
                txtEPI.Text = reader["epi_fin"].ToString();
                txtPPI.Text = reader["picks"].ToString();
                txtWeave.Text = reader["weave"].ToString();
                txtWidth.Text = reader["fin_width"].ToString();
                txtWeight.Text = reader["gsm"].ToString();
            }
            else
            {
                Response.Write("<script>alert('your record not found');</script>");
            }
        }
        
        reader.Close();
        con.Close();
    
    }
    protected void grdFileUploadDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            string filepath = Server.MapPath("~\\OPS\\FabricParticularFiles\\" + e.CommandArgument.ToString());
            if (File.Exists(filepath) == false)
            {
                string script = "alert('No File Found..!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                Response.ClearContent();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(e.CommandArgument.ToString())));
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument.ToString() + "");
                Response.TransmitFile(Server.MapPath("~\\OPS\\FabricParticularFiles\\" + e.CommandArgument.ToString()));
                Response.End();

            }
        }
    }
}