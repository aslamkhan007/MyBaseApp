Imports vb = Microsoft.VisualBasic
Partial Class User_Screen_Sample
    Inherits System.Web.UI.Page
   
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        'Label14.Text = Request.ServerVariables("HTTP_USER_AGENT").
        Dim strAgent As String
        strAgent = Request.ServerVariables("HTTP_USER_AGENT")
        Label14.Text = InStr(strAgent, "Windows98")

        Label14.Text = strAgent
        Label14.Text = InStr(strAgent, "Windows NT 6.1")

        If InStr(strAgent, "Windows98") > 0 Or InStr(strAgent, "Windows NT 5.0") > 0 Then
            Label14.Text = "Old Platform"
        Else
            Label14.Text = "New Platform"
        End If

    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click

        System.Diagnostics.Process.Start("\\test2k\RamcoFE\ap\ap.exe", "\\test2k\RamcoFE\ap")

        System.Diagnostics.Process.Start("\\test2k\applications\production\Project Shikhar.exe")
        'System.Diagnostics.ProcessStartInfo()
        Dim p As System.Diagnostics.Process = New System.Diagnostics.Process()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim p As System.Diagnostics.Process = New System.Diagnostics.Process()
        p.StartInfo.WorkingDirectory = "\\test2k\RamcoFe\ap"
        'p.StartInfo.EnvironmentVariables.Add("path", "\\test2k\RamcoFe\ap")
        p.StartInfo.FileName = "ap.exe"
        'System.Diagnostics.Process.Start("\\test2k\RamcoFe\ap\ap.exe")

    End Sub
End Class
