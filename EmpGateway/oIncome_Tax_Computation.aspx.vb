
Partial Class EmpGateway_Income_Tax_Computation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Filename As String = "ITaxComputationFiles/" & Session("Empcode").ToString() & ".txt"    ' file to read
        'Const ForReading = 1, ForWriting = 2, ForAppending = 3
        'Const TristateUseDefault = -2, TristateTrue = -1, TristateFalse = 0

        ' Create a filesystem object
        Dim fso As Object
        fso = Server.CreateObject("Scripting.FileSystemObject")

        ' Map the logical path to the physical system path
        Dim Filepath, textstream As Object
        Filepath = Server.MapPath(Filename)

        If fso.FileExists(Filepath) Then
            textstream = fso.OpenTextFile(Filepath, 1, False, -2)
            ' Read file in one hit
            Dim Contents As String
            Contents = textstream.ReadAll
            Label1.Text = "<Font family = Tahoma><pre>" & Contents & "</pre></font><hr>"
            textstream.Close()
            textstream = Nothing

        Else
            Label1.Text = "<font color = Red>Your Income Tax Computation is not available yet.</font>"
            'Response.Write("<h3><i><font color=red> File " & Filename & _
            '" does not exist</font></i></h3>")

        End If
    End Sub
End Class
