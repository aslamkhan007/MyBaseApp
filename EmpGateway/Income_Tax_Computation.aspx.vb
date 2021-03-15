
Partial Class EmpGateway_Income_Tax_Computation
    Inherits System.Web.UI.Page
    Dim ofn As Functions = New Functions
    Dim emp_code As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        Dim emp_name As String
        If (Session("empcode").ToString <> "") Then

            emp_code = Session("Empcode").ToString()
            emp_name = IIf(ofn.FetchValue("Select Fullname from JCT_EPOR_MASTER_EMPLOYEE where Emp_Code = '" & emp_code & "'") Is Nothing, emp_code, ofn.FetchValue("Select Fullname from JCT_EPOR_MASTER_EMPLOYEE where Emp_Code = '" & emp_code & "'"))
            txtEmpName.Attributes.Add("onFocus", "JavaScript:this.select();")
        Else
            Response.Redirect("~/login.aspx")
        End If

        

        AutoCompleteExtender1.ContextKey = Session("Companycode")
        'ParamTab.Visible = False
        ofn.CheckPermission("Employee Gateway", ofn.GetCurrentPageName, ParamTab, "admin", emp_code)

        'If (emp_code = "J-01838") Then
        '    ParamTab.Visible = True
        'Else
        '    ParamTab.Visible = False
        'End If

        FetchITComputation(emp_code, emp_name)

        'Dim Filename As String = "ITaxComputationFiles/" & Session("Empcode").ToString() & ".txt"    ' file to read
        ''Const ForReading = 1, ForWriting = 2, ForAppending = 3
        ''Const TristateUseDefault = -2, TristateTrue = -1, TristateFalse = 0

        '' Create a filesystem object
        'Dim fso As Object
        'fso = Server.CreateObject("Scripting.FileSystemObject")

        '' Map the logical path to the physical system path
        'Dim Filepath, textstream As Object
        'Filepath = Server.MapPath(Filename)

        'If fso.FileExists(Filepath) Then
        '    textstream = fso.OpenTextFile(Filepath, 1, False, -2)
        '    ' Read file in one hit
        '    Dim Contents As String
        '    Contents = textstream.ReadAll
        '    Label1.Text = "<Font family = Tahoma><pre>" & Contents & "</pre></font><hr>"
        '    textstream.Close()
        '    textstream = Nothing

        'Else
        '    Label1.Text = "<font color = Red>You Income Tax Computation is not available yet.</font>"
        '    'Response.Write("<h3><i><font color=red> File " & Filename & _
        '    '" does not exist</font></i></h3>")


    End Sub

    Protected Sub lnkView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkView.Click
        FetchEmployee()

    End Sub

    Protected Sub FetchITComputation(ByVal EmpCode As String, ByVal EmpName As String)
        Dim Filename As String = "ITaxComputationFiles/" & EmpCode & ".txt"    ' file to read
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
            Label1.Text = "Income Tax Computation for<font color = Red> " & EmpName & " : " & EmpCode & "</font> is not available yet."
            'Response.Write("<h3><i><font color=red> File " & Filename & _
            '" does not exist</font></i></h3>")

        End If
    End Sub

    Protected Sub txtEmpName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpName.TextChanged
        FetchEmployee()
    End Sub


    Protected Sub FetchEmployee()
        If txtEmpName.Text <> "" Then
            Try
                FetchITComputation(Trim(txtEmpName.Text.Substring(txtEmpName.Text.IndexOf(":") + 1, 8)), Trim(txtEmpName.Text.Substring(0, txtEmpName.Text.IndexOf(":"))))
            Catch
                Label1.Text = "<font color = Red>Invalid Employee... Please Retype again or select from list.</font>"
            End Try

        Else
            Label1.Text = "Please Select Employee from list or Type Employee Name to view record."

        End If
    End Sub

End Class
