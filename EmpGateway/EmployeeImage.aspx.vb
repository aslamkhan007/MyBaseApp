Imports System.Data
Imports System.Data.SqlClient

Partial Class EmployeeImage
    Inherits System.Web.UI.Page
    Dim obj As New Connection
    Dim str, compcode As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
        Else
            Response.Redirect("login.aspx")
        End If

        If Page.IsPostBack = False Then

            obj.ConOpen()
            Dim card As String = Request.QueryString("card")
            lblcard.Text = card
            imgemp.ImageUrl = "~/emp_images/" + lblcard.Text & ".jpg"

            str = "select company_code from JCT_EmpMast_Base where cardno='" & card & "'"
            Dim cmd3 As New SqlCommand(str, obj.Connection)
            compcode = cmd3.ExecuteScalar

            If compcode = Session("location").ToString Then
                FileUpload1.Enabled = True
            Else
                FileUpload1.Enabled = False
            End If
            obj.ConClose()
        End If
        LinkButton1.OnClientClick = "javascript:window.history.go(-1);return false;"
    End Sub

    Protected Sub btnsub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsub.Click


        If FileUpload1.HasFile Then

            'If Session("Location") = "JCT01LTD" Then
            Dim ext, st As String
            'Dim st As String = StrReverse(FileUpload1.FileName)
            '            ext = StrReverse(st.Substring(0, 3))

            'Dim st1() As String = FileUpload1.FileName.ToString.Split(".")
            'Dim name As String = st1(0)
            'Dim ext As String = st1(1)
            'fileupload1.FileName.Substring(strreverse(fileupload1.FileName)
            ext = Me.FileUpload1.PostedFile.FileName
            st = System.IO.Path.GetFileName(ext)
            'System.IO.File.Delete("D:/WebApplications/EmpGateway/emp_images\" + lblcard.Text & ".jpg")
            'FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\emp_images\" + Trim(lblcard.Text) + ".jpg")
            'FileUpload1.PostedFile.SaveAs(Server.MapPath("~\emp_images\") + fileupload1.FileName)
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~\emp_images\") + Trim(lblcard.Text) + ".jpg")
            'FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\emp_images\" + fileupload1.FileName)

            imgemp.ImageUrl = Nothing
            imgemp.ImageUrl = "~\emp_images\" + Trim(lblcard.Text) + ".jpg"

            FMsg.Message = "Image Uploaded"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            'End If

        End If
    End Sub

    
End Class
