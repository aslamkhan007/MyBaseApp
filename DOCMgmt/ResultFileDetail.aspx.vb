Imports System.Data.SqlClient
Imports System.IO
Partial Class ResultFileDetail
    Inherits System.Web.UI.Page
    Dim SqlPass As String
    Dim Dr As SqlDataReader
    Dim Exists As Boolean = False
    Dim obj As New Connection
    Dim MaxRows As Integer
    Dim ds As New Data.DataSet
    Dim qry As String
    Protected Sub CmdFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFirst.Click
        'If MaxRows <= 0 Then
        '    SqlPass = "select fileno, filename,description, '~/upd/' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
        '    AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        'End If
        'ViewState("Count") = 0

        'Navigation(0)
        'CmdFirst.Enabled = False
        'CmdNext.Enabled = True
        'CmdPrevious.Enabled = True
        'CmdLast.Enabled = True
        MoveFirst()
    End Sub

    Protected Sub CmdNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdNext.Click
        'If maxrows <= 0 Then
        '    SqlPass = "select fileno, filename,description, '~/upd/' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
        '    AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        'End If
        'ViewState("Count") = ViewState("Count") + 1

        'If ViewState("Count") < maxrows - 1 And ViewState("Count") <> maxrows Then
        '    CmdPrevious.Enabled = True
        '    CmdFirst.Enabled = True
        'Else
        '    CmdNext.Enabled = False
        '    CmdLast.Enabled = False
        '    CmdFirst.Enabled = True
        '    CmdPrevious.Enabled = True
        'End If
        'Navigation(ViewState("Count"))
        'MoveNext(CmdFirst, CmdPrevious, CmdLast, CmdNext)
        MoveNext()
    End Sub

    Protected Sub CmdPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrevious.Click
        'If maxrows <= 0 Then
        '    SqlPass = "select fileno, filename,description, '~/upd/' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
        '    AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        'End If
        'ViewState("Count") = ViewState("Count") - 1

        'If ViewState("Count") < maxrows - 1 And ViewState("Count") <> 0 Then
        '    CmdNext.Enabled = True
        '    CmdLast.Enabled = True
        'Else
        '    CmdPrevious.Enabled = False
        '    CmdFirst.Enabled = False
        '    CmdNext.Enabled = True
        '    CmdLast.Enabled = True
        'End If

        'Navigation(ViewState("Count"))
        MovePrevious()
    End Sub

    Protected Sub CmdLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdLast.Click
        'If maxrows <= 0 Then

        '    SqlPass = "select fileno, filename,description, '~/upd/' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
        '    AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        'End If
        'Navigation(MaxRows - 1)
        'ViewState("Count") = maxrows - 1
        'CmdLast.Enabled = False
        'CmdNext.Enabled = False
        'CmdPrevious.Enabled = True
        'CmdFirst.Enabled = True
        MoveLast()
    End Sub

    Protected Sub Navigation(ByVal i As Integer)
        Try
            'TxtCode.Text = Ds.Tables(0).Rows(i).Item(0)
            'TxtParent.Text = Ds.Tables(0).Rows(i).Item(1)
            'TxtShortDesc.Text = Ds.Tables(0).Rows(i).Item(2)
            'TxtLongDesc.Text = Ds.Tables(0).Rows(i).Item(3)
            'TxtEffFrom.Text = Ds.Tables(0).Rows(i).Item(4)
            'TxtEffTo.Text = Ds.Tables(0).Rows(i).Item(5)
            Me.Img.ImageUrl = ds.Tables(0).Rows(i).Item(3)

        Catch ex As Exception
        Finally
            'Dr.Close()
            Obj.ConClose()
        End Try

    End Sub

    Public Function AdapterRecord(ByVal Sqlpass As String, ByVal CmdFirst As LinkButton, ByVal CmdNext As LinkButton, ByVal CmdPrev As LinkButton, ByVal CmdLast As LinkButton) As Integer
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())
        Dr.Close()
        Ds.Clear()
        Da.Fill(Ds)
        MaxRows = Ds.Tables(0).Rows.Count
        If Ds.Tables(0).Rows.Count = 1 Then
            CmdNext.Enabled = False
            CmdPrev.Enabled = False
            CmdFirst.Enabled = False
            CmdLast.Enabled = False
            MaxRows = 1
        End If
        Dr.Close()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        If Not Page.IsPostBack = True Then
            'CheckPermission(GetCurrentPageName(), CmdAdd, CmdEdit, CmdDelete, Session("Empcode"))
            'Disable_Buttons(CmdSearch)
            LoadGridParent()
        End If
    End Sub
    Protected Sub LoadGridParent()
        '  qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        Dim storepath As String = "~\DocMgmt\Upd\" & Session("Empcode") & "\" 'Server.MapPath("~") + "/Upd"
        If Not Directory.Exists(storepath) Then
            FMsg.Message = "No such folder Exists!!"
            FMsg.Display()
        End If
        'If CmdAdd.Text <> "Save" Then
        SqlPass = "select fileno, filename,description, '" & storepath & "' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno") & " and  fileno=" & Request.QueryString("flno")
        Dr = obj.FetchReader(SqlPass)
        If Dr.HasRows = True Then
            Dr.Read()
            Me.Img.ImageUrl = Dr(3)
        End If
        Dr.Close()
        'FillGrid(SqlPass, )
        'End If
    End Sub

    Protected Sub CmdFirst0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFirst0.Click
        MoveFirst()
    End Sub

    Protected Sub CmdPrevious0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrevious0.Click
        MovePrevious()
    End Sub

    Protected Sub CmdNext0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdNext0.Click
        MoveNext()
    End Sub

    Protected Sub CmdLast0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdLast0.Click
        MoveLast()
    End Sub
    Private Sub MoveFirst()
        'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        Dim storepath As String = "~\DocMgmt\Upd\" & Session("Empcode") & "\" 'Server.MapPath("~") + "/Upd"
        If Not Directory.Exists(storepath) Then
            FMsg.Message = "No such folder Exists!!"
            FMsg.Display()
        End If
        If MaxRows <= 0 Then
            SqlPass = "select fileno, filename,description, '" & storepath & "' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = 0
        Navigation(0)
        CmdFirst.Enabled = False
        CmdNext.Enabled = True
        CmdPrevious.Enabled = True
        CmdLast.Enabled = True
        ' Me.GrdHelp.SelectedIndex = 0
    End Sub
    Private Sub MoveLast()
        'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        Dim storepath As String = "~\DocMgmt\Upd\" & Session("Empcode") & "\" 'Server.MapPath("~") + "/Upd"
        If Not Directory.Exists(storepath) Then
            FMsg.Message = "No such folder Exists!!"
            FMsg.Display()
        End If
        If MaxRows <= 0 Then
            'SqlPass = "SELECT   [Code]=catg,Parentcatg , [Short Desc]=ShortDesc,[Long Desc]=LONGDESC ,EffFrom,EffTo from JCTDEV..JCT_DMS_Master_Category  WHERE status<>'D'  "
            SqlPass = "select fileno, filename,description, '" & storepath & "' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        Navigation(MaxRows - 1)
        ViewState("Count") = MaxRows - 1
        CmdLast.Enabled = False
        CmdNext.Enabled = False
        CmdPrevious.Enabled = True
        CmdFirst.Enabled = True
        'Me.grdhelp.SelectedIndex = Me.grdhelp.Rows.Count() - 1
    End Sub
    Private Sub MovePrevious()
        'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        Dim storepath As String = "~\DocMgmt\Upd\" & Session("Empcode") & "\" 'Server.MapPath("~") + "/Upd"
        If Not Directory.Exists(storepath) Then
            FMsg.Message = "No such folder Exists!!"
            FMsg.Display()
        End If
        If MaxRows <= 0 Then
            'SqlPass = "SELECT   [Code]=catg,Parentcatg , [Short Desc]=ShortDesc,[Long Desc]=LONGDESC ,EffFrom,EffTo from JCTDEV..JCT_DMS_Master_Category  WHERE status<>'D'  "
            SqlPass = "select fileno, filename,description, '" & storepath & "' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = ViewState("Count") - 1

        If ViewState("Count") < MaxRows - 1 And ViewState("Count") <> 0 Then
            CmdNext.Enabled = True
            CmdLast.Enabled = True
        Else
            CmdPrevious.Enabled = False
            CmdFirst.Enabled = False
            CmdNext.Enabled = True
            CmdLast.Enabled = True
        End If

        Navigation(ViewState("Count"))
        'Me.grdhelp.SelectedIndex = Me.grdhelp.SelectedIndex - 1
    End Sub
    Private Sub MoveNext()
        'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        Dim storepath As String = "~\DocMgmt\Upd\" & Session("Empcode") & "\" 'Server.MapPath("~") + "/Upd"
        If Not Directory.Exists(storepath) Then
            FMsg.Message = "No such folder Exists!!"
            FMsg.Display()
        End If
        If MaxRows <= 0 Then
            SqlPass = "select fileno, filename,description, '" & storepath & "' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = ViewState("Count") + 1

        If ViewState("Count") < MaxRows - 1 And ViewState("Count") <> MaxRows Then
            CmdPrevious.Enabled = True
            CmdFirst.Enabled = True
        Else
            CmdNext.Enabled = False
            CmdLast.Enabled = False
            CmdFirst.Enabled = True
            CmdPrevious.Enabled = True
        End If
        Navigation(ViewState("Count"))

    End Sub
    'Private Sub MoveNext(ByVal BtnToEnable As LinkButton, ByVal BtnToEnable1 As LinkButton, ByVal BtnToDisable As LinkButton, ByVal BtnToDisable1 As LinkButton)
    '    If MaxRows <= 0 Then
    '        'SqlPass = "SELECT   [Code]=catg,Parentcatg , [Short Desc]=ShortDesc,[Long Desc]=LONGDESC ,EffFrom,EffTo from JCTDEV..JCT_DMS_Master_Category  WHERE status<>'D'  "
    '        SqlPass = "select fileno, filename,description, '~/upd/' + filename as url from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & Request.QueryString("Transno")
    '        AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
    '    End If
    '    ViewState("Count") = ViewState("Count") + 1

    '    If ViewState("Count") < MaxRows - 1 And ViewState("Count") <> MaxRows Then
    '        BtnToEnable.Enabled = True
    '        BtnToEnable1.Enabled = True
    '    Else
    '        BtnToDisable.Enabled = False
    '        BtnToDisable1.Enabled = False
    '        BtnToEnable.Enabled = True
    '        BtnToEnable.Enabled = True
    '    End If
    '    Navigation(ViewState("Count"))

    '    'Me.grdhelp.SelectedIndex = Me.grdhelp.SelectedIndex + 1
    'End Sub

    Protected Sub cmdBack1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack1.Click
        Response.Redirect("ResultGrid.aspx?catg=" & Request.QueryString("catg"))
    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Response.Redirect("ResultGrid.aspx?catg=" & Request.QueryString("catg"))
    End Sub
End Class
