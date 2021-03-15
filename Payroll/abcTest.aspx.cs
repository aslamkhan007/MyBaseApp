using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Text;

public partial class abcTest : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions objFun = new Functions();
    string qry;
    string sql;
    SqlConnection con;
    Connection cn;
    string Yearmonthstore;
    string abc;
    string MyPathFound;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack == true)
        {
            HtmlForm frm = new HtmlForm();
            frm = (HtmlForm)this.Master.FindControl("form1");
            frm.Enctype = "multipart/form-data";
        }
    }


    public string pathfind()
    {

        SqlCommand cmd = new SqlCommand("Jct_Payroll_Custom_Path_Find", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            MyPathFound = dr[0].ToString();
        }
        else
        {
            string script = "alert('No Record Found !! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        dr.Close();

        return MyPathFound;
    }

    protected void btnUpload_Click(object sender, ImageClickEventArgs e)
    {
        SqlTransaction tran = default(SqlTransaction);
        try
        {
            //string CodeYearmonth = "";
            //CodeYearmonth = Session["empcode"].ToString().Trim() + DrpLvStatus.SelectedItem.Value.Trim();
            int i = 0;
            for (i = 0; i <= Request.Files.Count - 1; i++)
            {
                HttpPostedFile PostedFilesk = Request.Files[i];
                if (PostedFilesk.ContentLength == 0)
                {
                    string message = "alert('Empty File OR No File Selected..')";
                    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                    return;
                }
            }
            if (Request.Files.Count == 0)
            {
                string message = "alert('No File Selected For Uploading..')";
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                return;
            }


            for (i = 0; i <= Request.Files.Count - 1; i++)
            {
                HttpPostedFile PostedFile = Request.Files[i];
                string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                FileName = FileName.Replace("#", "");
                FileName = FileName.Replace("@", "");
                FileName = FileName.Replace("$", "");
                FileName = FileName.Replace("&", "");
                FileName = FileName.Replace("^", "");
                FileName = FileName.Replace("%", "");
                FileName = FileName.Replace("..", ".");
                //string filepath = "\\EmpPortal\\Upload\\" + Session["empcode"].ToString().Trim() + "\\ " + DrpLvStatus.SelectedItem.Value.Trim() + "\\";
                ////string filepath = "\\Upload\\";
                string filepath = pathfind();
                //string filepath = "\\Upload\\";

                if (!string.IsNullOrEmpty(FileName) & !string.IsNullOrEmpty(filepath))
                {
                    uploadDoc(i);
                }
                else
                {
                    string message = "alert('Please try again .File Uploading not completed.')";
                    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                }
            }

            string message10 = "alert('File Uploading Completed ')";
            ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message10, true);

        }
        catch (Exception ex)
        {
            if (ViewState["SanctionID"] == null)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
            }
            else
            {
                tran.Rollback();
            }
        }
    }

    protected void uploadDoc(int i)
    {
        try
        {
            HttpPostedFile PostedFile = Request.Files[i];
            if (PostedFile.ContentLength > 0)
            {
                string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                //string filepath = Server.MapPath("Upload\\");                
                string abc = pathfind();

                // string filepath = Server.MapPath("' + abc+");
                string filepath = Server.MapPath(abc);
                //string filepath = "\\Upload\\";              

                FileName = FileName.Replace("#", "");
                FileName = FileName.Replace("@", "");
                FileName = FileName.Replace("$", "");
                FileName = FileName.Replace("&", "");
                FileName = FileName.Replace("^", "");
                FileName = FileName.Replace("%", "");
                FileName = FileName.Replace("..", ".");
                PostedFile.SaveAs(filepath + FileName.Replace(" ", ""));
            }
        }
        catch
        {
            throw new Exception();
        }
    }

    protected void DropDownList20_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DrpLvStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnksave_Click(object sender, EventArgs e)
    {

    }
}