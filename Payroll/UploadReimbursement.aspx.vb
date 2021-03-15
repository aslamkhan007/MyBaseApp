Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI
Imports System.Net.Mail
Imports System.IO
Partial Class Payroll_UploadReimbursement
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction
    Public SanctionID As String = ""

    '24 March 2017
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim FileName As String = ""
        'qry = "SELECT TOP 1 Num FROM JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL"
        'SanctionID = objFun.FetchValue(qry, obj.Connection, Tran)

        If Request.Files.Count > 0 Then
            For i = 0 To Request.Files.Count - 1
                Dim PostedFile As HttpPostedFile = Request.Files(i)
                If PostedFile.ContentLength > 0 Then
                    FileName = System.IO.Path.GetFileName(PostedFile.FileName)
                    FileName = FileName.Replace(" ", "_")
                    FileName = SanctionID & "_" & FileName

                    PostedFile.SaveAs(Server.MapPath("Upload\") & FileName)
                    qry = "INSERT INTO Jct_Payroll_Reimbursement_Attachments( EmployeeCode,Yearmonth ,ImgName ,STATUS ,UploadedOn) VALUES  ( 'm-02467',201904 , '" & FileName & "' , 'A' , GETDATE())"
                    objFun.InsertRecord(qry, Tran, obj.Connection)
                End If
            Next

        End If
        'qry = "   SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM  Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + SanctionID + "'"
        'objFun.FillObj(dtlAttachment, qry)
        Dim cn As New Connection
        Dim cn1 As New Connection
        Dim cmd1 As SqlCommand
        Dim sqlstr As String = "SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM  Jct_Payroll_Reimbursement_Attachments  WHERE   EmployeeCode = 'm-02467'"
        cmd1 = New SqlCommand(sqlstr, cn1.Connection)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        dtlAttachment.DataSource = ds.Tables(0)
        dtlAttachment.DataBind()

    End Sub

    Protected Sub dtlAttachment_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlAttachment.ItemCommand
        Dim filepath As String = ""
        Dim Scrpt As String = ""
        Dim strFileName As String = ""
        If e.CommandName = "Download" Then
            filepath = Server.MapPath("~\\Payroll\\Upload\\" + e.CommandArgument.ToString())
        End If
        If File.Exists(filepath) = False Then
            Scrpt = "alert('File Not Found. Please contact IT-HelpDesk @4212');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
        Else
            strFileName = e.CommandArgument.ToString()
            Response.Redirect("DownloadFile.aspx?filepath=" + filepath + "&FileName=" + strFileName)
        End If
    End Sub
    '24 March 2017

End Class
