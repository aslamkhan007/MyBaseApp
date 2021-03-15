
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Web.Services

Partial Class OPS_SanctionNoteConversation
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("EmpCode") = String.Empty Then
                Response.Redirect("~/login.aspx")
            End If
            Dim frm As New HtmlForm()
            frm = DirectCast(Me.Master.FindControl("form1"), HtmlForm)
            frm.Enctype = "multipart/form-data"
        End If

        ' DataList2.DataBind()
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As ImageClickEventArgs) Handles imgUpload.Click
        If txtSanctionID.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Please Enter Quotation and press Enter key Properly in Basic Screen');", True)
        Else

            Dim sm As New SendMail
            Dim str As String = txtSanctionID.Text

            Dim body_to As String = "File Uploading Done by"
            Dim cn As New Connection()
            Dim tran As SqlTransaction
            tran = cn.Connection().BeginTransaction()
            Try
                For i As Integer = 0 To Request.Files.Count - 1
                    Dim PostedFile As HttpPostedFile = Request.Files(i)
                    Dim FileName As String = System.IO.Path.GetFileName(PostedFile.FileName)
                    FileName = FileName.Replace("#", "")
                    FileName = FileName.Replace("@", "")
                    FileName = FileName.Replace("$", "")
                    FileName = FileName.Replace("&", "")
                    FileName = FileName.Replace("^", "")
                    FileName = FileName.Replace("%", "")
                    FileName = FileName.Replace("..", ".")
                    Dim filepath As String = "\OPS\Files\" + txtSanctionID.Text + "\"

                    If FileName <> "" And filepath <> "" Then

                        Dim cmd As New SqlCommand("jct_ops_upload_ref_docs_sanction", cn.Connection(), tran)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("BaseDocType", SqlDbType.VarChar, 30).Value = ddlDocType.SelectedItem.Text
                        cmd.Parameters.Add("BaseDocNo", SqlDbType.VarChar, 20).Value = txtSanctionID.Text
                        cmd.Parameters.Add("RefDocFilePath", SqlDbType.VarChar, 2000).Value = filepath
                        cmd.Parameters.Add("RefDocActFileName", SqlDbType.VarChar, 500).Value = FileName.Replace(" ", "")
                        Dim ext As String() = PostedFile.FileName.Split("."c)
                        '[PostedFile.FileName.LastIndexOf('.') + 1];
                        Dim fileext As String = ext(ext.Length - 1)
                        cmd.Parameters.Add("RefDocFileExt", SqlDbType.VarChar, 4).Value = fileext
                        cmd.Parameters.Add("UserId", SqlDbType.VarChar, 10).Value = Session("EmpCode").ToString()
                        cmd.Parameters.Add("HostId", SqlDbType.VarChar, 50).Value = Request.UserHostName
                        cmd.ExecuteNonQuery()
                        uploadDoc(i)
                        Dim bcc As String = "hitesh@jctltd.com;"
                        sm.SendMail2("hitesh@jctltd.com;hiren@jctltd.com;sandeepr@jctltd.com", "", bcc, "noreply@jctltd.com", "File Uploading ", body_to & str)
                        Dim message As String = "alert('Uploading File Done.!! Now Press Submit Button.')"


                        ScriptManager.RegisterClientScriptBlock(TryCast(sender, Control), Me.[GetType](), "alert", message, True)

                    Else
                        Dim message As String = "alert('Please try again .File Uploading not completed.')"
                        ScriptManager.RegisterClientScriptBlock(TryCast(sender, Control), Me.[GetType](), "alert", message, True)
                        'ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert( 'Please try again .File Uploading not completed');", True)

                    End If
                Next
                tran.Commit()

            Catch ex As Exception
                tran.Rollback()
                lblError.Text = ex.Message
                body_to = ex.Message.ToString
                str = ""
                Dim bcc As String = ""
                sm.SendMail2("hitesh@jctltd.com;hiren@jctltd.com;sandeepr@jctltd.com", "", bcc, "noreply@jctltd.com", "File Uploading ", body_to & str)
                ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('" + ex.Message + "');", True)
            End Try
        End If
    End Sub
    Protected Sub uploadDoc(i As Integer)
        Try
            'for (int i = 0; i < Request.Files.Count; i++)
            '{
            Dim PostedFile As HttpPostedFile = Request.Files(i)
            If PostedFile.ContentLength > 0 Then
                Dim FileName As String = System.IO.Path.GetFileName(PostedFile.FileName)
                Dim filepath As String = Server.MapPath("Files\") + txtSanctionID.Text + "\"
                'PostedFile.SaveAs(Server.MapPath(filepath));
                If Not Directory.Exists(filepath) Then
                    Directory.CreateDirectory(filepath)
                End If
                FileName = FileName.Replace("#", "")
                FileName = FileName.Replace("@", "")
                FileName = FileName.Replace("$", "")
                FileName = FileName.Replace("&", "")
                FileName = FileName.Replace("^", "")
                FileName = FileName.Replace("%", "")
                FileName = FileName.Replace("..", ".")
                PostedFile.SaveAs(filepath & FileName.Replace(" ", ""))
                '}
            End If
        Catch
            Throw New Exception()
        End Try
    End Sub


    Protected Sub cmdSubmit_Click(sender As Object, e As System.EventArgs) Handles cmdSubmit.Click
        Try
            Dim cn As New Connection()
            Dim cmd As New SqlCommand("Jct_Ops_SanctionNote_Conversation_sp", cn.Connection())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("UserCode", SqlDbType.VarChar, 10).Value = Session("EmpCode").ToString()
            cmd.Parameters.Add("SanctionNoteID", SqlDbType.VarChar, 20).Value = txtSanctionID.Text
            cmd.Parameters.Add("Conversattiob_text", SqlDbType.VarChar, -1).Value = txtDescription.Text
            cmd.Parameters.Add("ReplyBy", SqlDbType.VarChar, 50).Value = txtPerson.Text
            cmd.Parameters.Add("ReplyDate", SqlDbType.DateTime).Value = txtDateFrom.Text
            cmd.ExecuteNonQuery()
            ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Record Saved Sucessfully ');", True)
        Catch
            ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Problem In Record Saving ');", True)
            Throw New Exception()
        End Try
    End Sub

  







End Class
