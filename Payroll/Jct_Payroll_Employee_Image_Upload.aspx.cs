using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public partial class Payroll_Jct_Payroll_Employee_Image_Upload : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string qry;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkUpload_Click(object sender, EventArgs e)
    {
        StartUpLoad();
    }

    private void StartUpLoad()
    {
        try
        {
            string imgName =FileUpload1.FileName;
            int imgSize = FileUpload1.PostedFile.ContentLength;
            string FileExtension = imgName.Substring(imgName.LastIndexOf('.') + 1).ToLower();
            string filename = txtEmpCode.Text + "." + FileExtension;
            if (FileUpload1.HasFile)
            {
                //if (FileExtension == "jpg" || FileExtension == "jpeg" || FileExtension == "png" || FileExtension == "gif")
                if (FileExtension == "jpg" || FileExtension == "jpeg" || FileExtension == "png" || FileExtension == "gif")
                {
                    if (FileUpload1.PostedFile.ContentLength > 300240)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too big.')", true);
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("EmployeeImages\\") +filename);
                        string sql = "Jct_Payroll_Employee_Image_Upload";
                        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
                        cmd.Parameters.Add("@EmployeeImage", SqlDbType.VarChar, 40).Value =filename;
                        cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
                        cmd.ExecuteNonQuery();
                        Image1.Visible = true;
                        Image1.ImageUrl = "EmployeeImages/"+filename;
                       
                        string script = "alert('File Uploaded Successfully.!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                        lnkdelete.Enabled = true;
                        lnkDownload.Enabled = true;
                    }
                }
                else
                {
                    string script = "alert('File Type Not Supported.!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
               
            }
            else
            {
                string script = "alert('Sorry !!!! No File Uploaded');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        }
        catch (Exception ex)
        {
            string script = "alert('some error occurred!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }


      protected void txtEmpCode_TextChanged(object sender, EventArgs e)
      {
          //sql = "Jct_Payroll_Employee_Image_Preview";
          //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
          //cmd.CommandType = CommandType.StoredProcedure;
          //cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
          //SqlDataAdapter da = new SqlDataAdapter(cmd);
          //DataSet ds = new DataSet();
          //da.Fill(ds);
          //if (ds.Tables[0].Rows.Count == 0)
          //{              
          //    string imgPath = null;
          //    Image1.ImageUrl = imgPath;
          //    string script = "alert('Image Does Not Exist For This Employee.!!');";
          //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
          //}
          //else 
          //{
              try
              {
                  SrCode.Visible = true;
                  SrId.Visible = true;
                  //SrId.Text = Convert.ToString(ds.Tables[0].Rows[0]["SrNo"]);
                  //string imgfile = Convert.ToString(ds.Tables[0].Rows[0]["EmployeeImage"]);
                  //string imgPath = "EmployeeImages/"+imgfile;
                  string imgPath = "EmployeeImages/" + txtEmpCode.Text + ".jpg";
                  Image1.Visible = true;
                  Image1.ImageUrl = imgPath;

                  lnkdelete.Enabled = true;
                  lnkDownload.Enabled = true;
              }
             catch (Exception ex)
          {
              string script = "alert('some error occurred!');";
              ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
          }  
          //}

      }
      protected void lnkreset_Click(object sender, EventArgs e)
      {
          Response.Redirect("Jct_Payroll_Employee_Image_Upload.aspx");
      }
      protected void lnkdelete_Click(object sender, EventArgs e)
      {
          try
          {
              string filename = Image1.ImageUrl.ToString();
              string imageFilePath = Server.MapPath(filename);
              System.IO.File.Delete(imageFilePath);

              string sql = "Jct_Payroll_Employee_Image_Delete  ";
              SqlCommand cmd = new SqlCommand(sql, obj.Connection());
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar,10).Value = txtEmpCode.Text;
              cmd.Parameters.Add("@srno", SqlDbType.Int).Value = SrId.Text;
              cmd.ExecuteNonQuery();

              string script = "alert('Image deleted.!!');";
              ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
              cleartextboxes();
          }
          catch (Exception ex)
          {
              string script = "alert('some error occurred!');";
              ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
          }
      }
      private void cleartextboxes()
      {
          Image1.Visible = false;
          SrId.Visible = false;
          SrCode.Visible = false;
      }

      protected void lnkDownload_Click(object sender, EventArgs e)
      {
          String filename = Image1.ImageUrl.ToString();
          String filepath = Server.MapPath(filename);        
          HttpContext.Current.Response.ContentType = "application/octet-stream";
          HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
          HttpContext.Current.Response.Clear();
          HttpContext.Current.Response.WriteFile(filepath);
          HttpContext.Current.Response.End();
      }
}
