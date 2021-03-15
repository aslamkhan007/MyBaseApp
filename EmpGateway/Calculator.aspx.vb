Imports System.IO
Partial Class Calculator
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Programmatically pick a random image from the ~/Images directory
            ImgBck.ImageUrl = PickImageFromDirectory("\\test2k\WebApplications\EmpGateway\UnderConstruction")
        End If
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
