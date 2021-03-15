using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class OPS_ReferenceDocs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlForm frm = new HtmlForm();
        frm = (HtmlForm)this.Master.FindControl("form1");
        frm.Enctype = "multipart/form-data";
        if (IsPostBack)
        {
            lblDocType.Text = ddlDocType.SelectedItem.Text;
        }
    }

    //protected void btnUpload_Click(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < Request.Files.Count; i++)
    //    {
    //        HttpPostedFile PostedFile = Request.Files[i];
    //        if (PostedFile.ContentLength > 0)
    //        {
    //            string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
    //            PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);
    //        }
    //    }
    //}

    protected void btnUpload_Click(object sender, ImageClickEventArgs e)
    {
        Connection cn = new Connection();
        SqlTransaction tran;
        tran = cn.Connection().BeginTransaction();
        if (ddlDocType.Text == "MR Request")
        {
             try
            {
                        if (Request.Files.Count > 0) {
	                    for (int i = 0; i <= Request.Files.Count - 1; i++) 
                        {
		                    HttpPostedFile PostedFile = Request.Files[i];
		                    if (PostedFile.ContentLength > 0) {
			                     string FileName  = System.IO.Path.GetFileName(PostedFile.FileName);
			                    PostedFile.SaveAs(Server.MapPath("Upload\\") + FileName);
			                    string qry = "INSERT INTO Jct_Ops_SanctionNote_Attachments( SanctionNoteID ,ImgName ,STATUS ,UploadedOn) VALUES  ( '" + txtBaseDocNo.Text + "' , '" + FileName + "' , 'A' , GETDATE())";
			                     SqlCommand cmd = new SqlCommand(qry, cn.Connection(), tran);
                                cmd.CommandType = CommandType.Text;
                                cmd.ExecuteNonQuery();


		                    }
	                    }

                    }



                //for (int i = 0; i < Request.Files.Count; i++)
                //{
                //    HttpPostedFile PostedFile = Request.Files[i];
                //    string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                //  //  string filepath = "\\OPS\\Files\\" + ddlDocType.SelectedItem.Text + "\\" + txtBaseDocNo.Text.Replace('/', '-').Replace('\\', '-') + "\\";
                //    PostedFile.SaveAs
                //    SqlCommand cmd = new SqlCommand("jct_ops_upload_ref_docs", cn.Connection(), tran);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.Add("BaseDocType", SqlDbType.VarChar, 30).Value = ddlDocType.SelectedItem.Text;
                //    cmd.Parameters.Add("BaseDocNo", SqlDbType.VarChar, 20).Value = txtBaseDocNo.Text;
                //    cmd.Parameters.Add("RefDocFilePath", SqlDbType.VarChar, 2000).Value = filepath;
                //    cmd.Parameters.Add("RefDocActFileName", SqlDbType.VarChar, 500).Value = FileName;
                //    string[] ext = PostedFile.FileName.Split('.'); //[PostedFile.FileName.LastIndexOf('.') + 1];
                //    string fileext = ext[ext.Length - 1];
                //    cmd.Parameters.Add("RefDocFileExt", SqlDbType.VarChar, 4).Value = fileext;
                //    cmd.Parameters.Add("UserId", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
                //    cmd.Parameters.Add("HostId", SqlDbType.VarChar, 50).Value = Request.UserHostName;
                //    cmd.ExecuteNonQuery();
                //    uploadDoc(i);
                //}
                tran.Commit();
                string message = "alert('Uploading File Done.!! ')";
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
            }


            catch (Exception ex)
            {
                tran.Rollback();
                lblError.Text = ex.Message;
            }

        }
        else
        {


            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile PostedFile = Request.Files[i];
                    string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                    string filepath = "\\OPS\\Files\\" + ddlDocType.SelectedItem.Text + "\\" + txtBaseDocNo.Text.Replace('/', '-').Replace('\\', '-') + "\\";
                    SqlCommand cmd = new SqlCommand("jct_ops_upload_ref_docs", cn.Connection(), tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("BaseDocType", SqlDbType.VarChar, 30).Value = ddlDocType.SelectedItem.Text;
                    cmd.Parameters.Add("BaseDocNo", SqlDbType.VarChar, 20).Value = txtBaseDocNo.Text;
                    cmd.Parameters.Add("RefDocFilePath", SqlDbType.VarChar, 2000).Value = filepath;
                    cmd.Parameters.Add("RefDocActFileName", SqlDbType.VarChar, 500).Value = FileName;
                    string[] ext = PostedFile.FileName.Split('.'); //[PostedFile.FileName.LastIndexOf('.') + 1];
                    string fileext = ext[ext.Length - 1];
                    cmd.Parameters.Add("RefDocFileExt", SqlDbType.VarChar, 4).Value = fileext;
                    cmd.Parameters.Add("UserId", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
                    cmd.Parameters.Add("HostId", SqlDbType.VarChar, 50).Value = Request.UserHostName;
                    cmd.ExecuteNonQuery();
                    uploadDoc(i);
                }
                tran.Commit();
                string message = "alert('Uploading File Done.!! ')";
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
            }


            catch (Exception ex)
            {
                tran.Rollback();
                lblError.Text = ex.Message;
            }
        }
    }
   public bool InsertRecord(string Sql, SqlTransaction Tran, SqlConnection Con)
   {
       SqlCommand cmd =new SqlCommand();
	   bool functionReturnValue = false;

	try {
		cmd = new SqlCommand(Sql, Con);
		cmd.Transaction = Tran;
		//Response.Write("<script>alert('Thanks For Your Coments !!')</script>")
		// ClientScript.RegisterClientScriptBlock(Me.GetType, "P", "<script language = javascript>alert('test')</script>")
		cmd.ExecuteNonQuery();

		functionReturnValue = true;
		//Function
	//  Insert = True ' Variabale
	} catch (Exception ex) {
		//Response.Write("<script>alert('Exception !!')</script>")
		functionReturnValue = false;
		throw ex;
		//  Insert = False
	}
	return functionReturnValue;

}
    protected void ddlDocType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblDocType.Text = ddlDocType.SelectedItem.Text;
    }

    protected void uploadDoc(int i)
    {
        try
        {
                //for (int i = 0; i < Request.Files.Count; i++)
                //{
                    HttpPostedFile PostedFile = Request.Files[i];
                    if (PostedFile.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        string filepath = Server.MapPath("Files\\") + ddlDocType.SelectedItem.Text + "\\" + txtBaseDocNo.Text.Replace('/', '-') + "\\";
                        //PostedFile.SaveAs(Server.MapPath(filepath));
                        if (!Directory.Exists(filepath))
                        {
                            Directory.CreateDirectory(filepath);
                        }
                        PostedFile.SaveAs(filepath + FileName);
                    }
                //}
        }
        catch
        {
            throw new Exception();
        }
    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        lblDocNo.Text = txtBaseDocNo.Text;
        DataList2.DataBind();
    }

    protected void txtBaseDocNo_TextChanged(object sender, EventArgs e)
    {
        lblDocNo.Text = txtBaseDocNo.Text;
        DataList2.DataBind();
    }
}
