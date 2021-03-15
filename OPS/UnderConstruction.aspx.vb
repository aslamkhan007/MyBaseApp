Imports System.IO
Partial Class Default4
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("login.aspx")
        End If

        'If Not Page.IsPostBack Then
        '    'Programmatically pick a random image from the ~/Images directory
        '    ImgBck.ImageUrl = PickImageFromDirectory("\\90.0.1.251\WebApplications\FusionApps\EmpGateway\UnderConstruction\Under")
        'End If
    End Sub


    'Returns the virtual path to a randomly-selected image in the specified directory
    Private Function PickImageFromDirectory(ByVal directoryPath As String) As String
        Dim dirInfo As New DirectoryInfo(directoryPath)
        Dim fileList() As FileInfo = dirInfo.GetFiles()
        Dim numberOfFiles As Integer = fileList.Length

        'Pick a random image from the list
        Dim rnd As New Random
        Dim randomFileIndex As Integer = rnd.Next(numberOfFiles)

        Dim imageFileName As String = fileList(randomFileIndex).Name
        Dim fullImageFileName As String = Path.Combine(directoryPath, imageFileName)

        Return fullImageFileName
    End Function

End Class
