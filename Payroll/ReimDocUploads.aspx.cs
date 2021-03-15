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

public partial class Payroll_ReimDocUploads : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions objFun = new Functions();
    string qry;
    string sql;
    SqlConnection con;
    Connection cn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack == true)
        {

            string CodeYearmonth = "";
            string sqlqry3 = "Jct_Payroll_SalaryCal_Attendence_Month";
            SqlCommand cmd10 = new SqlCommand(sqlqry3, obj.Connection());
            cmd10.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr10 = cmd10.ExecuteReader();
            if (dr10.HasRows == true)
            {
                while (dr10.Read())
                {
                    CodeYearmonth = Session["empcode"].ToString() + dr10["ToDate"].ToString();
                }
                dr10.Close();
            }
            BindUploadedDocs(CodeYearmonth);

            HtmlForm frm = new HtmlForm();
            frm = (HtmlForm)this.Master.FindControl("form1");
            frm.Enctype = "multipart/form-data";
        }
    }
    protected void btnUpload_Click(object sender, ImageClickEventArgs e)
    {
        SqlTransaction tran = default(SqlTransaction);
        try
        {
            int i = 0;

            string CodeYearmonth = "";
            string sqlqry2 = "Jct_Payroll_SalaryCal_Attendence_Month";
            SqlCommand cmd1 = new SqlCommand(sqlqry2, obj.Connection());
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                {
                    CodeYearmonth = Session["empcode"].ToString() + dr1["ToDate"].ToString();
                }
                dr1.Close();
            }

            string sanctionid = CodeYearmonth;
            tran = obj.Connection().BeginTransaction();
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
                string filepath = "\\Payroll\\Upload\\" + sanctionid + "\\";

                if (!string.IsNullOrEmpty(FileName) & !string.IsNullOrEmpty(filepath))
                {
                    uploadDoc(i, sanctionid);
                    SqlCommand cmd = new SqlCommand("Jct_Portal_Reimbursement_Doc_Insert", obj.Connection(), tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("BaseDocNo", SqlDbType.VarChar, 20).Value = sanctionid;
                    cmd.Parameters.Add("RefDocFilePath", SqlDbType.VarChar, 2000).Value = filepath;
                    cmd.Parameters.Add("RefDocActFileName", SqlDbType.VarChar, 500).Value = FileName.Replace(" ", "");
                    string[] ext = PostedFile.FileName.Split('.');
                    //[PostedFile.FileName.LastIndexOf('.') + 1];
                    string fileext = ext[ext.Length - 1];
                    cmd.Parameters.Add("RefDocFileExt", SqlDbType.VarChar, 4).Value = fileext;
                    cmd.Parameters.Add("UserId", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
                    cmd.Parameters.Add("HostId", SqlDbType.VarChar, 50).Value = Request.UserHostName;
                    cmd.ExecuteNonQuery();                    
                    string message = "alert('UPloading File Completed ')";
                    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                }
                else
                {
                    string message = "alert('Please try again .File Uploading not completed.')";
                    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                }
            }
            tran.Commit();
            BindUploadedDocs(sanctionid);
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

    protected void uploadDoc(int i, string Sanctionid)
    {
        try
        {
            HttpPostedFile PostedFile = Request.Files[i];
            if (PostedFile.ContentLength > 0)
            {
                string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                string filepath = Server.MapPath("Upload\\") + Sanctionid + "\\";
                //PostedFile.SaveAs(Server.MapPath(filepath));
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                FileName = FileName.Replace("#", "");
                FileName = FileName.Replace("@", "");
                FileName = FileName.Replace("$", "");
                FileName = FileName.Replace("&", "");
                FileName = FileName.Replace("^", "");
                FileName = FileName.Replace("%", "");
                FileName = FileName.Replace("..", ".");
                PostedFile.SaveAs(filepath + FileName.Replace(" ", ""));
                //}
            }
        }
        catch
        {
            throw new Exception();
        }
    }

    public void BindUploadedDocs(string sanctionid)
    {
        qry = "Jct_Portal_Reimbursement_Doc_Bind";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DocNo", SqlDbType.VarChar, 20).Value = sanctionid;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        DataList2.DataSource = dt;
        DataList2.DataBind();
    }

    protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            string filepath = Server.MapPath("Upload\\") + ViewState["SanctionID"] + "\\";

            string strFileName = "";
            strFileName = e.CommandArgument.ToString();

            Response.Redirect("QutationDownloadFile.aspx?filepath=" + filepath + "&FileName=" + strFileName);
        }
    }
}