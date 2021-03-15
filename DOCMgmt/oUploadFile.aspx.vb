Imports System.Data.SqlClient
Imports System.Math
Imports Microsoft
Imports Microsoft.Win32
Imports Microsoft.Win32.Registry
Imports System.Collections
Imports System.IO
Imports System.Threading
Imports System.Web.Services.WebService
Partial Class UploadFile
    Inherits System.Web.UI.Page
    Protected Shared intColCount As Integer
    Protected Shared Str As String
    Protected Shared Rowindex As Integer
    Protected Shared ColCnt As Int16
    Protected txtBox As System.Web.UI.WebControls.TextBox
    Protected DDl As System.Web.UI.WebControls.DropDownList
    Protected RowLbl As System.Web.UI.WebControls.Label
    Protected cmdAdd As System.Web.UI.WebControls.LinkButton
    Protected CmdUpdate As System.Web.UI.WebControls.LinkButton
    Public Shared HifList As New ArrayList()
    Dim obj As New Connection
    Dim objfun As New Functions
    Dim qry As String
    Dim i As Integer
    Dim Cmd As SqlCommand, Cmd1 As SqlCommand
    Dim dr As SqlDataReader
    Dim dr1 As SqlDataReader
    Dim FldName(100) As String
    Dim CtrlType(100) As String
    Dim ProcName(100) As String
    Dim ToolTip(100) As String
    Dim sql As String
    Protected Sub UpdateFile()
        Dim i As Integer

        sql = "update JCT_DMS_Trans_Upload set status='D', DeletionDt=getdate(), DeletedBy='" & Session("Empcode") & "' where status='' and transno=" & Request.QueryString("TransNo")

        objfun.UpdateRecord(sql)

        sql = "update JCT_DMS_Trans_Upload_Files set status='D', DeletionDt=getdate(), DeletedBy='" & Session("Empcode") & "' where status='' and transno=" & Request.QueryString("TransNo")
        objfun.UpdateRecord(sql)

        sql = "update JCT_DMS_Trans_Upload_Param set status='D' where status='A' and transno=" & Request.QueryString("TransNo")
        objfun.UpdateRecord(sql)


        qry = "Insert into JCT_DMS_Trans_Upload values ('" & Session("CompanyCode") & "','" & Session("Empcode") & "',getdate(),'" & Trim(Me.txtFileRef.Text) & "',right('" & Trim(Me.txtFileType.Text) & "',len('" & Trim(Me.txtFileType.Text) & "')-charindex('-->','" & Trim(Me.txtFileType.Text) & "')-2),'" & Trim(Me.txtRefDate.Text) & "','','" & Trim(Me.DrpDept.SelectedItem.Text) & "','','" & Trim(Me.txtKeyInfo.Text) & "'," & objfun.NBlankZero((Me.txtPgNo.Text)) & "," & objfun.NBlankZero(Trim(Me.txtAmt.Text)) & ",'',null,null,'U',null,null,null,'" & Request.QueryString("DocNo") & "')"
        If objfun.InsertRecord(qry) = True Then
            FMsg.Message = "Information Updated."
        Else
            FMsg.Message = "Not Added"
        End If

        qry = "select max(TransNo) from JCT_DMS_Trans_Upload where empcode='" & Session("Empcode") & "'"
        Dim trans As Integer = objfun.FetchValue(qry)
        FMsg.Display()

        For i = 0 To ViewState("j")
            If Session("OSeq" + CStr(i)) Is Nothing Then
            Else
                qry = "insert into JCT_DMS_Trans_Upload_Files values ('" & Session("CompanyCode") & "','" & Session("Empcode") & "'," & trans & "," & Session("OSeq" + CStr(i)) & ",'" + Session("Oupd" + CStr(i)) & "','','" & Session("ODesc" + CStr(i)) & "','A','A','',null,null)"
                objfun.InsertRecord(qry)
            End If
        Next

        UploadFiles(trans)
        GenerateInsertSql(PlaceHolder1, trans)
        Wizard1.ActiveStepIndex = 0
    End Sub
    Protected Sub UploadFiles(ByVal trans As Integer)

        i = 0
        'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        qry = "select deptcode from jct_empmast_base where empcode ='" & Session("Empcode") & "'"

        'Dim storepath As String = "d:\dms\" & objfun.FetchValue(qry) & "\" & Right(Trim(Me.txtFileType.Text), Len(Trim(Me.txtFileType.Text)) - InStr(Trim(Me.txtFileType.Text), "-->") - 2) & "\" & Session("EmpCode") & "\"

        Dim storepath As String = Server.MapPath("~\DOCMgmt\Upd\" & objfun.FetchValue(qry) & "\" & Right(Trim(Me.txtFileType.Text), Len(Trim(Me.txtFileType.Text)) - InStr(Trim(Me.txtFileType.Text), "-->") - 2) & "\" & Session("EmpCode") & "\")


        System.IO.Directory.CreateDirectory(storepath)

        For Each HIF As System.Web.UI.HtmlControls.HtmlInputFile In HifList

            Try

                Dim fn As String = System.IO.Path.GetFileName(HIF.PostedFile.FileName)

                Dim HODAuth, ITAuth As Char
                HIF = Session("upd" + CStr(i))
                If HIF Is Nothing Then
                    i += 1
                Else
                    'If HIF.PostedFile.ContentLength / 1024 < 1024 Then
                    HIF.PostedFile.SaveAs(storepath + "\(" & trans & ")" + Path.GetFileName(HIF.PostedFile.FileName))

                    ''''''''For Checking which files to be sent for authorization.
                    If Path.GetExtension(HIF.PostedFile.FileName).ToLower = ".jpg" Or Path.GetExtension(HIF.PostedFile.FileName).ToLower = ".png" Or Path.GetExtension(HIF.PostedFile.FileName).ToLower = ".bmp" Then
                        HODAuth = "R"
                        ITAuth = "R"
                    Else
                        HODAuth = "R"
                        ITAuth = "R"
                    End If

                    qry = "insert into JCT_DMS_Trans_Upload_Files values ('" & Session("CompanyCode") & "','" & Session("Empcode") & "'," & trans & "," & Session("Seq" + CStr(i)) & ",'(" & trans & ")" + Path.GetFileName(HIF.PostedFile.FileName) & "','','" & Session("Desc" + CStr(i)) & "','" & HODAuth & "','" & ITAuth & "','',null,null)"

                    If objfun.InsertRecord(qry) = True Then

                        qry = "update JCT_DMS_Trans_Upload set filepath='(" & trans & ")" + Path.GetFileName(HIF.PostedFile.FileName) & "' where status='' and transno=" & trans
                        objfun.UpdateRecord(qry)
                    Else
                    End If
                    i += 1
                    'End If
                End If
            Catch err As Exception

                Dim script As String = "alert('" + err.Message + "');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

            End Try
        Next
    End Sub

    Protected Sub Block()
        Dim i As Integer
        Me.txtFileType.Enabled = False
        ' txtDesc.Enabled = False
        'txtSeq.Enabled = False
        'LnkAttach.Enabled = True
        'LnkDel.Enabled = True
        LnkUpload.Enabled = False
        LnkUpdate.Enabled = True
        ''qry to fetch record and display
        qry = "select a.shortdesc + '-->' + b.filetype,filerefno,convert(varchar(10),filerefdate,101),department,keyinfo,pagescnt from JCT_DMS_Master_Category a,JCT_DMS_Trans_Upload b where a.parentcatg+a.catg =b.filetype  and a.status=b.status and a.status='' and b.transno=" & Request.QueryString("TransNo")
        dr = objfun.FetchReader(qry)
        If dr.HasRows = True Then
            dr.Read()
            txtFileType.Text = dr(0)
            txtFileRef.Text = dr(1)
            txtRefDate.Text = dr(2)
            txtKeyInfo.Text = dr(4)
            txtPgNo.Text = dr(5)
        End If
        dr.Close()

        ''To display Old Added files in List
        qry = "select Fileno,FileName,Description from JCT_DMS_Trans_Upload_Files where status='' and transno=" & Request.QueryString("TransNo")
        dr = objfun.FetchReader(qry)
        If dr.HasRows = True Then
            i = 0
            While dr.Read()
                Dim lst As New ListItem
                lst.Value = dr(1)
                lst.Text = dr(1)
                Me.ListBox1.Items.Add(lst)
                Session("Oupd" + CStr(i)) = dr(1)
                Session("ODesc" + CStr(i)) = dr(2)
                Session("OSeq" + CStr(i)) = dr(0)
                i += 1
            End While
        End If
        dr.Close()
        ViewState("j") = i

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If

        If Not IsPostBack Then
            If Request.QueryString("Catg") <> "" Then
                If Request.QueryString("upd") = "NoAccess" Then
                    Response.Redirect("ResultGrid.aspx?catg=" & Request.QueryString("Catg"))
                ElseIf Request.QueryString("upd") = "Update" Then
                    Block()
                End If
                cmdBack.Enabled = True
            End If
            Wizard1.ActiveStepIndex = 0
            Panel4.Visible = False
        End If
        ViewState("Stage") = 1
        'qry = "SELECT dept_code,LongDesc FROM JCT_Epor_MASTER_Dept WHERE Company_Code='" & Session("CompanyCode") & "' and status='A'  order by longdesc"
        qry = "select a.deptcode,a.deptname from   deptmast a join jct_empmast_base b on a.deptcode=b.deptcode and b.empcode='" & Session("Empcode") & "' "

        objfun.FillList(DrpDept, qry)
        'qry = "SELECT A.LONGDESC FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A'"
        qry = "select a.deptname from   deptmast a join jct_empmast_base b on a.deptcode=b.deptcode and b.empcode='" & Session("Empcode") & "' "
        DrpDept.SelectedItem.Text = objfun.FetchValue(qry).ToString

        IntilizeControls()

    End Sub
    Protected Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick

        ClearAll()
        UploadFile()

    End Sub
    Protected Sub UploadFile()
        Response.Redirect("Default.aspx")
    End Sub

    Public abort As Boolean
    ' Returns the sum of the files in the folder.
    ' dPath: Path of the directory
    ' include subfolders: set if include subfolders ;)
    Function GetFolderSize(ByVal DirPath As String, ByVal includeSubFolders As Boolean) As Long
        Try
            Dim size As Long = 0
            Dim diBase As New DirectoryInfo(DirPath)
            Dim files() As FileInfo
            If includeSubFolders Then
                files = diBase.GetFiles("*", SearchOption.AllDirectories)
            Else
                files = diBase.GetFiles("*", SearchOption.TopDirectoryOnly)
            End If
            Dim ie As IEnumerator = files.GetEnumerator
            While ie.MoveNext And Not abort
                size += DirectCast(ie.Current, FileInfo).Length
            End While
            Return size
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            Return -1
        End Try
    End Function
    Protected Function CheckSeqReq(ByVal i As Integer) As Boolean

        If i > 0 And (Me.txtSeq.Text = "" Or Me.txtDesc.Text = "") Then
            FMsg.Message = "Both Sequence No and Description are Compulsory in Case of Multiple Files Upload!!"
            FMsg.Display()
            CheckSeqReq = False
        Else
            CheckSeqReq = True
        End If

    End Function

    Protected Function CheckSeqExist(ByVal i As Integer) As Boolean

        While i > 0
            If Session("Seq" + CStr(i)) = Trim(Me.txtSeq.Text) Then
                FMsg.Message = "This Sequence No. already exists. Please Check."
                FMsg.Display()
                CheckSeqExist = False
                Exit While
            Else
                i = i - 1
            End If
        End While
        CheckSeqExist = True

    End Function
    Protected Function CheckFileType() As Boolean
        If Path.GetExtension(File2.PostedFile.FileName).ToLower = ".exe" Then
            CheckFileType = False
        Else
            CheckFileType = True
        End If
    End Function
    Protected Sub LnkAttach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkAttach.Click
        If ViewState("i") Is Nothing Then
            ViewState("i") = 0
        End If
        If CheckSeqReq(ViewState("i")) = True And CheckSeqExist(ViewState("i")) = True And CheckFileType = True Then
            'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
            qry = "select a.deptcode from   deptmast a join jct_empmast_base b on a.deptcode=b.deptcode and b.empcode='" & Session("Empcode") & "' "
            Dim filename As String = File2.PostedFile.FileName
            Dim i As Integer
            Dim storepath As String = "d:\dms\" & objfun.FetchValue(qry).ToString

            If Not Directory.Exists(storepath) Then
                Directory.CreateDirectory(storepath)
            End If
            storepath += "\" & Right(Trim(Me.txtFileType.Text), Len(Trim(Me.txtFileType.Text)) - InStr(Trim(Me.txtFileType.Text), "-->") - 2)
            If Not Directory.Exists(storepath) Then
                Directory.CreateDirectory(storepath)
            End If
            storepath += "\" & Session("Empcode") & "\"
            If Not Directory.Exists(storepath) Then
                Directory.CreateDirectory(storepath)
            End If

            'If ViewState("Size") Is Nothing Then
            '    ViewState("Size") = GetFolderSize(storepath, True) / 1024
            'End If

            If filename <> String.Empty Then
                Dim lst As New ListItem
                lst.Value = File2.PostedFile.FileName 'Me.txtDesc.Text
                lst.Text = File2.PostedFile.FileName
                ViewState("Size") += File2.PostedFile.ContentLength / 1024
                'If ViewState("Size") > 1024 Then
                '    FMsg.Message = "File Size exceeding Set Limit!!"
                '    FMsg.Display()
                '    Exit Sub
                'Else
                HifList.Add(File2)

                Me.ListBox1.Items.Add(lst)
                i = CInt(ViewState("i"))

                Session("upd" + CStr(i)) = File2
                Session("Desc" + CStr(i)) = Me.txtDesc.Text
                Session("Seq" + CStr(i)) = Me.txtSeq.Text

                Me.txtSeq.Text = CInt(CInt(Trim(Me.txtSeq.Text)) + 10)
                i += 1
                ViewState("i") = i
                ' End If
            End If
        End If
    End Sub

    Protected Sub LnkDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkDel.Click
        Dim flidx As Integer
        If ListBox1.SelectedIndex > -1 Then
            flidx = ListBox1.SelectedIndex
            If Request.QueryString("Upd") = "Update" Then
                If flidx < ViewState("j") Then
                    Session.Remove("ODesc" + CStr(flidx - 1))
                    Session.Remove("OSeq" + CStr(flidx - 1))
                    Session.Remove("Oupd" + CStr(flidx - 1))
                Else
                    Session.Remove("upd" + CStr(flidx - ViewState("j")))
                    Session.Remove("Desc" + CStr(flidx - ViewState("j")))
                    Session.Remove("Seq" + CStr(flidx - ViewState("j")))
                End If
            Else
                Session.Remove("upd" + CStr(flidx - 1))
                Session.Remove("Desc" + CStr(flidx - 1))
                Session.Remove("Seq" + CStr(flidx - 1))
            End If
            ListBox1.Items.RemoveAt(flidx)
        End If

    End Sub
    Protected Sub SessionClear()
        Dim i As Integer
        For i = 0 To ViewState("i")
            Session.Remove("upd" + CStr(i))
            Session.Remove("Desc" + CStr(i))
            Session.Remove("Seq" + CStr(i))
        Next

        For i = 0 To ViewState("j")
            Session.Remove("Oupd" + CStr(i))
            Session.Remove("ODesc" + CStr(i))
            Session.Remove("OSeq" + CStr(i))
        Next
    End Sub
    Protected Sub LnkUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkUpload.Click
        Dim cnt As Integer = ViewState("i")
        Dim qry As String
        Dim fltype As String
        Dim sr As Integer
        qry = "SELECT a.deptcode FROM deptmast a, jct_empmast_base b WHERE b.EmpCode='" & Session("Empcode") & "' AND b.DeptCode=a.DeptCode AND  b.active='y'"
        'Comented on 29-July-2013 qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        ' Dim storepath As String = "\\its-shweta\dms\" & objfun.FetchValue(qry) & "\" & Right(Trim(Me.txtFileType.Text), Len(Trim(Me.txtFileType.Text)) - InStr(Trim(Me.txtFileType.Text), "-->") - 2) & "\" & Session("EmpCode") & "\"  'Server.MapPath("~") + "/Upd"


        Dim storepath As String = Server.MapPath("~\DOCMgmt\Upd\" & objfun.FetchValue(qry) & "\" & Right(Trim(Me.txtFileType.Text), Len(Trim(Me.txtFileType.Text)) - InStr(Trim(Me.txtFileType.Text), "-->") - 2) & "\" & Session("EmpCode") & "\")



        ''''''''''''Code For Serial No Generation
        fltype = Right(Trim(txtFileType.Text), Len(Trim(txtFileType.Text)) - InStr(txtFileType.Text, "-->") - 2)
        qry = "select sr_no from production..common_serial_master where frmname='UploadFile' and sr_type='" & fltype & "'"
        dr = objfun.FetchReader(qry)
        If dr.HasRows = True Then
            dr.Read()
            If dr(0) Is System.DBNull.Value Then
                sr = 0
            Else
                sr = dr(0)
            End If
        Else
            sr = 0
        End If
        dr.Close()

        If sr = 0 Then
            qry = "insert into production..common_serial_master values('UploadFile',1,'','" & fltype & "')"
        Else
            qry = "update production..common_serial_master set sr_no= sr_no+1 where frmname='UploadFile' and sr_type='" & fltype & "'"
        End If
        objfun.InsertRecord(qry)

        sr = sr + 1

        qry = "Insert into JCT_DMS_Trans_Upload values ('" & Session("CompanyCode") & "','" & Session("Empcode") & "',getdate(),'" & Trim(Me.txtFileRef.Text) & "',right('" & Trim(Me.txtFileType.Text) & "',len('" & Trim(Me.txtFileType.Text) & "')-charindex('-->','" & Trim(Me.txtFileType.Text) & "')-2),'" & Trim(Me.txtRefDate.Text) & "','','" & Trim(Me.DrpDept.SelectedItem.Text) & "','','" & Trim(Me.txtKeyInfo.Text) & "'," & objfun.NBlankZero((Me.txtPgNo.Text)) & "," & objfun.NBlankZero(Trim(Me.txtAmt.Text)) & ",'',null,null,'U',null,null,null,'" & fltype & sr & "')"
        If objfun.InsertRecord(qry) = True Then
            FMsg.Message = "Information Added!!"
        Else
            FMsg.Message = "Not Added"
        End If
        FMsg.Display()

        qry = "select max(TransNo) from JCT_DMS_Trans_Upload where empcode='" & Session("Empcode") & "'"
        Dim trans As Integer = objfun.FetchValue(qry)

        UploadFiles(trans)
        GenerateInsertSql(PlaceHolder1, trans)
        ClearAll()

        qry = "select count(*) from JCT_DMS_Trans_Upload where empcode='" & Session("Empcode") & "' and status=''"
        lblFileCount.Text = objfun.FetchValue(qry)
        qry = "select count(*) from JCT_DMS_Trans_Upload where empcode='" & Session("Empcode") & "' and status='' and convert(varchar(15),entereddt,101)=convert(varchar(15),getdate(),101)"
        lblTodayFileCount.Text = objfun.FetchValue(qry)

        Me.lblMessage.Text = "File Uploaded with Auto File Ref No :- " & fltype & sr
        Panel4.Visible = True
        ModalPopupExtender1.Enabled = True
        ModalPopupExtender1.Show()

    End Sub
    Protected Sub ClearAll()

        ListBox1.Items.Clear()
        txtSeq.Text = ""
        txtDesc.Text = ""
        txtAmt.Text = ""
        txtFileRef.Text = ""
        txtFileType.Text = ""
        txtKeyInfo.Text = ""
        txtPgNo.Text = ""
        txtRefDate.Text = ""
        File2.Disabled = True

        HifList.Clear()

        SessionClear()
        ViewState.Remove("Size")
        ViewState.Remove("i")
        ViewState.Remove("j")

    End Sub
    Private Sub CreateDropDownControls(ByVal r As TableRow, ByVal rWeight As TableRow, ByVal rID As TableRow, ByVal I As Integer, ByVal TblName As String, ByVal CtrlName As String, ByVal fldname As String, ByVal tooltip As String)
        Dim rowCount As Integer = 1
        For rowIndex As Integer = 0 To 0

            For clIndex As Integer = 0 To 0 'intColCount - 1
                Dim c As New TableCell()

                DDl = New DropDownList
                If DDl.[GetType]().ToString().Equals("System.Web.UI.WebControls.DropDownList") AndAlso PlaceHolder1.FindControl("ddl" & CtrlName) Is Nothing Then
                    DDl.ID = "ddl" & CtrlName
                    DDl.Width = Unit.Pixel(345)
                    DDl.CssClass = "combobox"
                    DDl.ToolTip = tooltip
                    qry = "Select * from " & TblName
                    objfun.FillList(DDl, qry)
                    If Request.QueryString("TransNo") <> "" Then
                        qry = "select descriptiontext from JCT_DMS_Trans_Upload_Param where paramname='" & fldname & "' and status='A' and transno=" & Request.QueryString("TransNo")
                        dr = objfun.FetchReader(qry)
                        If dr.HasRows = True Then
                            dr.Read()
                            DDl.SelectedItem.Text = dr(0)
                        End If
                        dr.Close()
                    End If
                    c.BorderWidth = Unit.Pixel(1)
                    c.Width = Unit.Pixel(1580)
                    c.Controls.Add(DDl)
                    r.Cells.Add(c)

                End If
            Next
        Next
    End Sub

    Private Sub Createdatecontrol(ByVal r As TableRow, ByVal rWeight As TableRow, ByVal rID As TableRow, ByVal I As Integer, ByVal CtrlName As String, ByVal fldname As String, ByVal tooltip As String)


        Dim rowCount As Integer = 1
        For rowIndex As Integer = 0 To 0 'rowCount

            For clIndex As Integer = 0 To 0 'intColCount - 1
                Dim c As New TableCell()
                Dim CalExtender As AjaxControlToolkit.CalendarExtender = New AjaxControlToolkit.CalendarExtender
                txtBox = New TextBox()

                If txtBox.[GetType]().ToString().Equals("System.Web.UI.WebControls.TextBox") AndAlso PlaceHolder1.FindControl("txt" & CtrlName) Is Nothing Then
                    txtBox.ID = "txt" & CtrlName
                    CalExtender.ID = "Cal" & txtBox.ID
                    CalExtender.TargetControlID = txtBox.ID
                    txtBox.Width = Unit.Pixel(100)
                    txtBox.CssClass = "textbox"
                    txtBox.ToolTip = tooltip
                    If Request.QueryString("TransNo") <> "" Then
                        qry = "select descriptiontext from JCT_DMS_Trans_Upload_Param where paramname='" & fldname & "' and status='A' and transno=" & Request.QueryString("TransNo")
                        dr = objfun.FetchReader(qry)
                        If dr.HasRows = True Then
                            dr.Read()
                            txtBox.Text = dr(0)
                        End If
                        dr.Close()
                    End If
                    c.BorderWidth = Unit.Pixel(1)
                    c.Width = Unit.Pixel(800)
                    c.Controls.Add(txtBox)
                    c.Controls.Add(CalExtender)

                    r.Cells.Add(c)
                End If
            Next
        Next

    End Sub


    Private Sub CreateTextBoxControls(ByVal r As TableRow, ByVal rWeight As TableRow, ByVal rID As TableRow, ByVal I As Integer, ByVal CtrlName As String, ByVal fldname As String, ByVal tooltip As String)
        Dim rowCount As Integer = 1

        For rowIndex As Integer = 0 To 0 'rowCount

            For clIndex As Integer = 0 To 0 'intColCount - 1
                Dim c As New TableCell()
                txtBox = New TextBox()
                If txtBox.[GetType]().ToString().Equals("System.Web.UI.WebControls.TextBox") AndAlso PlaceHolder1.FindControl("txt" & CtrlName) Is Nothing Then
                    txtBox.ID = "txt" & CtrlName
                    txtBox.Width = Unit.Pixel(100)
                    txtBox.CssClass = "textbox"
                    txtBox.ToolTip = tooltip
                    If Request.QueryString("TransNo") <> "" Then
                        qry = "select descriptiontext from JCT_DMS_Trans_Upload_Param where paramname='" & fldname & "' and status='A' and transno=" & Request.QueryString("TransNo")
                        dr = objfun.FetchReader(qry)
                        If dr.HasRows = True Then
                            dr.Read()
                            txtBox.Text = dr(0)
                        End If
                        dr.Close()
                    End If
                    c.BorderWidth = Unit.Pixel(1)
                    c.Width = Unit.Pixel(800)
                    c.Controls.Add(txtBox)
                    r.Cells.Add(c)
                End If
            Next
        Next

    End Sub
    Private Sub CreateDropDownControlsYN(ByVal r As TableRow, ByVal rWeight As TableRow, ByVal rID As TableRow, ByVal I As Integer, ByVal TblName As String, ByVal CtrlName As String, ByVal fldname As String, ByVal tooltip As String)
        Dim rowCount As Integer = 1
        For rowIndex As Integer = 0 To 0

            For clIndex As Integer = 0 To 0 'intColCount - 1
                Dim c As New TableCell()

                DDl = New DropDownList
                If DDl.[GetType]().ToString().Equals("System.Web.UI.WebControls.DropDownList") AndAlso PlaceHolder1.FindControl("ddl" & CtrlName) Is Nothing Then
                    DDl.ID = "ddl" & CtrlName
                    DDl.Width = Unit.Pixel(345)
                    DDl.CssClass = "combobox"
                    DDl.ToolTip = tooltip
                    DDl.Items.Add("Yes")
                    DDl.Items.Add("NO")

                    '    'qry = "Select * from " & TblName
                    '    'objfun.FillList(DDl, qry)
                    '    'If Request.QueryString("TransNo") <> "" Then
                    '    '    qry = "select descriptiontext from JCT_DMS_Trans_Upload_Param where paramname='" & fldname & "' and status='A' and transno=" & Request.QueryString("TransNo")
                    '    '    dr = objfun.FetchReader(qry)
                    '    '    If dr.HasRows = True Then
                    '    '        dr.Read()
                    '    DDl.SelectedItem.Text = dr(0)
                    'End If
                    'dr.Close()
                    '    End If
                    c.BorderWidth = Unit.Pixel(1)
                    c.Width = Unit.Pixel(1580)
                    c.Controls.Add(DDl)
                    r.Cells.Add(c)

                End If
            Next
        Next
    End Sub

    Private Sub CreateLabelControls(ByVal ColCount As Int16, ByVal RowCount As Integer)
        intColCount = ColCount 'Convert.ToInt32(7)
        Dim N As Integer = 0
        Dim Ct As Integer = 0
        If txtFileType.Text = "" Then Exit Sub
        Dim tblHead As New Table()
        If tblHead.[GetType]().ToString().Equals("System.Web.UI.WebControls.Table") AndAlso PlaceHolder1.FindControl("tblHead") Is Nothing Then
            tblHead.ID = "tblHead"
            tblHead.EnableViewState = True
            tblHead.BorderWidth = Unit.Pixel(0)
            tblHead.CellSpacing = 0
            tblHead.CssClass = "labelcells"
            tblHead.CellPadding = 1
            tblHead.Width = Unit.Percentage(96)
            Dim rH As New TableRow()
            Dim cH As New TableCell()
            cH.Font.Bold = True
            rH.Cells.Add(cH)
            tblHead.Rows.Add(rH)
            PlaceHolder1.Controls.Add(tblHead)
            If intColCount > 0 Then
                rH.Visible = True
            Else
                rH.Visible = False
            End If
        End If


        Dim tblHelp As New Table()
        If tblHelp.[GetType]().ToString().Equals("System.Web.UI.WebControls.Table") AndAlso PlaceHolder1.FindControl("tblHelp") Is Nothing Then
            tblHelp.ID = "tblHelp"
        End If
        tblHelp.EnableViewState = True
        tblHelp.BorderWidth = Unit.Pixel(1)
        tblHelp.CellSpacing = 0
        tblHelp.CellPadding = 1
        tblHelp.BorderWidth = Unit.Pixel(1)
        tblHelp.Width = Unit.Percentage(96)
        Dim i As Integer
        i = 0
        obj.ConOpen()
        qry = "SELECT Parameter,paramType,ProcName,description FROM JCT_DMS_Master_type_parameters where status='' and filetype=right('" & Trim(Me.txtFileType.Text) & "',len('" & Trim(Me.txtFileType.Text) & "')-charindex('-->','" & Trim(Me.txtFileType.Text) & "')-2) order by Seqno"
        Cmd = New SqlCommand(qry, obj.Connection)
        dr = Cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                FldName(i) = dr(0)
                CtrlType(i) = dr(1)
                ProcName(i) = dr(2)
                ToolTip(i) = dr(3)
                i += 1
            End While
        Else
            'Wizard1.ActiveStepIndex = 2
            Exit Sub
        End If
        dr.Close()
        obj.ConClose()
        i = 0
        For rowIndex As Integer = 0 To RowCount
            Dim r As New TableRow()
            Dim rWeight As New TableRow()

            Dim rID As New TableRow()


            For clIndex As Integer = 0 To intColCount - 1
                Dim c As New TableCell()
                RowLbl = New Label()
                If RowLbl.[GetType]().ToString().Equals("System.Web.UI.WebControls.Label") AndAlso PlaceHolder1.FindControl("lbl" & (clIndex + 1).ToString() & rowIndex) Is Nothing Then
                    RowLbl.ID = "lbl" & (clIndex + 1).ToString() & rowIndex
                    RowLbl.Width = Unit.Pixel(245)
                    If FldName(N) <> "" Then
                        RowLbl.Text = FldName(N).ToString
                    End If
                    RowLbl.CssClass = "labelcells"
                    c.BorderWidth = Unit.Pixel(1)
                    c.Width = Unit.Pixel(580)
                    c.Controls.Add(RowLbl)
                    r.Cells.Add(c)


                    If LCase(CtrlType(N)) = "textbox" Then
                        CreateTextBoxControls(r, rWeight, rID, i, RowLbl.ID, FldName(N).ToString, ToolTip(N).ToString)
                    ElseIf LCase(CtrlType(N)) = "dropdownlist" Then
                        CreateDropDownControls(r, rWeight, rID, i, ProcName(N).ToString, RowLbl.ID, FldName(N).ToString, ToolTip(N).ToString)
                    ElseIf LCase(CtrlType(N)) = "date" Then
                        Createdatecontrol(r, rWeight, rID, i, RowLbl.ID, FldName(N).ToString, ToolTip(N).ToString)
                    ElseIf LCase(CtrlType(N)) = "yesno" Then
                        CreateDropDownControlsYN(r, rWeight, rID, i, ProcName(N).ToString, RowLbl.ID, FldName(N).ToString, ToolTip(N).ToString)
                    Else

                        CreateTextBoxControls(r, rWeight, rID, i, RowLbl.ID, FldName(N).ToString, ToolTip(N).ToString)
                    End If
                    Ct += 1
                    i += 1
                    Exit For
                End If

            Next
            N += 1
            tblHelp.Rows.Add(r)
        Next

        PlaceHolder1.Controls.Add(tblHelp)

    End Sub

    Private Sub GenerateInsertSql(ByVal PlaceHolderCtrl As PlaceHolder, ByVal Trans As Integer)
        Dim SQL As String
        Dim FldName As String = " "
        Dim Final As String = ""
        Dim ParamName As String = "", Value As String = "", DescText As String = ""
        For Each ctrl As Control In PlaceHolder1.Controls
            For Each Ctrl1 As Control In ctrl.Controls
                FldName = ""
                For Each ctrl2 As Control In Ctrl1.Controls
                    For Each ctrl3 As Control In ctrl2.Controls
                        If ctrl3.GetType() Is GetType(TextBox) Then
                            Dim txt As TextBox = ctrl3
                            If txt.Text <> "" Then
                                FldName = Trim(FldName) & "'','" & txt.Text & "'" & ","
                            Else
                                FldName = ""
                            End If
                        ElseIf ctrl3.GetType() Is GetType(DropDownList) Then
                            Dim ddl As DropDownList = ctrl3
                            If ddl.SelectedItem.Text <> "" Then
                                FldName = Trim(FldName) & "'" & ddl.SelectedItem.Value & "'" & "," & "'" & ddl.SelectedItem.Text & "'" & ","
                            Else
                                FldName = ""
                            End If
                        ElseIf ctrl3.GetType() Is GetType(Label) Then
                            Dim Lbl As Label = ctrl3
                            FldName = Trim(FldName) & "'" & Lbl.Text & "'" & ","
                        End If
                    Next
                Next
                If Len(FldName) > 2 Then Final = Left(FldName, Len(FldName) - 1)
                If Final = "" Then Continue For
                SQL = "insert into jct_dms_trans_upload_param values('" & Session("CompanyCode") & "','" & Session("Empcode") & "'," & Trans & "," & Final & ",'A')"
                objfun.InsertRecord(SQL)
                Final = ""
            Next

        Next
        SQL = ""

    End Sub
    Public Sub IntilizeControls()
        Str = txtFileType.Text
        If Trim(Str) = String.Empty Then Exit Sub
        qry = "Select count(*) from JCT_DMS_Master_type_parameters where   status=''  and filetype=right('" & Trim(Str) & "',len('" & Trim(Str) & "')-charindex('-->','" & Trim(Str) & "')-2)"
        obj.ConOpen()
        Cmd1 = New SqlCommand(qry, obj.Connection)
        dr1 = Cmd1.ExecuteReader
        If dr1.HasRows Then
            dr1.Read()

            If dr1(0) = 1 Then
                ColCnt = dr1(0)
                ReDim FldName(1)
                ReDim CtrlType(1)
                ReDim ProcName(1)
                ReDim ToolTip(1)
            ElseIf dr1(0) > 1 Then
                ColCnt = System.Math.Round((dr1(0)))
                ReDim FldName(dr1(0))
                ReDim CtrlType(dr1(0))
                ReDim ProcName(dr1(0))
                ReDim ToolTip(dr1(0))
            Else
                ColCnt = 1
                ReDim FldName(1)
                ReDim CtrlType(1)
                ReDim ProcName(1)
                ReDim ToolTip(1)
            End If

        End If
        dr1.Close()
        obj.ConClose()
        If ColCnt > 1 Then
            CreateLabelControls(2, ColCnt - 1)
        Else

        End If
    End Sub

    Protected Sub txtFileType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFileType.TextChanged
        Str = txtFileType.Text
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

    End Sub

    Protected Sub Wizard1_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.NextButtonClick
        If Trim(txtFileType.Text) <> "" Then
            If Wizard1.ActiveStepIndex = 0 Then
                qry = "SELECT Parameter,paramType,ProcName FROM JCT_DMS_Master_type_parameters where status='' and stage = 1 and filetype=right('" & Trim(Me.txtFileType.Text) & "',len('" & Trim(Me.txtFileType.Text) & "')-charindex('-->','" & Trim(Me.txtFileType.Text) & "')-2)"
                Cmd = New SqlCommand(qry, obj.Connection)
                dr = Cmd.ExecuteReader
                If dr.HasRows = False Then
                    Wizard1.ActiveStepIndex = Wizard1.WizardSteps.Count - 1
                End If
            End If
        Else
            Wizard1.ActiveStepIndex = 0
        End If
        Me.txtSeq.Text = 10
    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        ClearAll()
        Response.Redirect("ResultGrid.aspx?catg=" & Request.QueryString("Catg"))
    End Sub

    Protected Sub LnkUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkUpdate.Click
        UpdateFile()
        ClearAll()
    End Sub

    Protected Sub LnkCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkCancel.Click
        Wizard1.ActiveStepIndex = 0
    End Sub

End Class
