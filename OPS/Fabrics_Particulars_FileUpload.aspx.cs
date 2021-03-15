using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Fabrics_Particulars_FileUpload : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
   

    }
    protected void txtItemCode_TextChanged(object sender, EventArgs e)
    {
     
        txtItemCode.Text = txtItemCode.Text.Split('~')[1].ToString();
    }
   
   
    protected void txtRemark_TextChanged(object sender, EventArgs e)
    {

    }
    protected void lnkUpload_Click(object sender, EventArgs e)
    {
        try
        {
         
            //string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            SqlConnection con = new SqlConnection("Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee;password=trainee");
            con.Open();
            SqlCommand cmd = new SqlCommand("jct_ops_get_fabric_param_fileUpload", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemCode", SqlDbType.Int, 5).Value = txtItemCode.Text;
            cmd.Parameters.Add("@DocType", SqlDbType.VarChar, 30).Value = ddlDocType.SelectedValue;
            cmd.Parameters.Add("@DocNo", SqlDbType.VarChar, 30).Value = txtDocNo.Text;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar, 30).Value = txtRemark.Text;
            cmd.Parameters.Add("@UploadFile", SqlDbType.VarChar, 30).Value = FileUpload1.FileName;
           
            if (FileUpload1.HasFile)
            {
                string FileName = System.IO.Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("FabricParticularFiles\\") + FileName);
                //DataSet ds = new DataSet();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(ds);
                cmd.ExecuteNonQuery();
                //grdfileUploadList.DataSource = ds;
                //grdfileUploadList.DataBind();
                con.Close();
                txtDocNo.Text = "";
                txtItemCode.Text = "";
                txtRemark.Text = "";
                ddlDocType.Text = "";
                string script;
                script = "alert('File Uploaded Successfully.!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
            else
            {
                throw new ApplicationException("Sorry !!!! No File Uploaded");
            }
          
        }
        catch (Exception ex)
        {
            string script;
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }
}