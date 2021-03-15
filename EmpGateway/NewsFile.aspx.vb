Imports System.Data
Imports System.Data.SqlClient
Partial Class NewsFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dept As String = Request.QueryString("dept")
        Dim file As String = Request.QueryString("file")
        Dim flag As String = Request.QueryString("flag")
        Dim type As String = Request.QueryString("type")

        If type <> "V" Then

            If flag = "I" Then
                Image1.ImageUrl = "News\" & dept & "\Int\" & file & ".jpg"
            ElseIf flag = "E" Then
                Image1.ImageUrl = "News\" & dept & "\Ext\" & file & ".jpg"
            End If

        End If

    End Sub
End Class
