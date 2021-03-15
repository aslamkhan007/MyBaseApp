Imports System.Data.SqlClient
Imports System.IO
Partial Class Search
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim obj As New Connection
    Dim objfun As New Functions

    Protected Shared intColCount As Integer
    Protected Shared Rowindex As Integer
    Protected Shared ColCnt As Int16
    Protected txtBox As System.Web.UI.WebControls.TextBox
    Protected DDl As System.Web.UI.WebControls.DropDownList
    Protected RowLbl As System.Web.UI.WebControls.Label
    Dim Cmd As SqlCommand, Cmd1 As SqlCommand
    Dim dr As SqlDataReader
    Dim dr1 As SqlDataReader
    Dim FldName(100) As String
    Dim CtrlType(100) As String
    Dim ProcName(100) As String
    Dim Tooltip(100) As String
    Protected Sub LnkSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSearch.Click
        Dim pg, amt As String
        Dim ds As Data.DataSet
        pg = Trim(Me.txtPgNo.Text)
        amt = Trim(Me.txtAmt.Text)

        If Trim(DdlFileType.SelectedValue) <> "" Then

            'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
            Dim storepath As String = Server.MapPath("~\DocMgmt\Upd\") & Session("Empcode") & "\" 'Server.MapPath("~") + "/Upd"
            Dim script As String
            If Not Directory.Exists(storepath) Then
                Directory.CreateDirectory(storepath)
            End If
            Dim Dire() As DirectoryInfo
            Dim file() As FileInfo
            Dim i As Integer
            Dim cnt As Integer = 2
            'If storepath <> "" Then
            '    Dim dir As New DirectoryInfo(storepath)
            '    Dire = dir.GetDirectories()
            '    file = dir.GetFiles()
            '    If Dire.Length > 0 Then
            '        For i = 0 To Dire.Length - 1
            '            Dire(i).Delete(True)
            '        Next
            '    End If
            '    If file.Length > 0 Then

            '        For i = 0 To file.Length - 1
            '            If System.IO.File.Exists(file(i).FullName) Then


            '                script = "alert(' files exists!!" + file(i).FullName + "');"
            '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
            '                file(i).Delete()


            '                '    file(i).Delete()
            '            End If
            '        Next
            '    End If
            'End If
            Dim FldName As String = ""
            Dim Final As String = ""
            Dim ParamName As String = "", Value As String = "", DescText As String = ""
            'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
            'Dim path As String = "\\its-neha\dms\" & FetchValue(qry) & "\" & Right(Trim(Me.DdlFileType.Text), Len(Trim(Me.DdlFileType.Text)) - InStr(Trim(Me.DdlFileType.Text), "-->") - 2) & "\" & Session("Empcode") & "\"
            'If Directory.Exists(path) Then



            '''''''''''''This is to copy all files from one directory.
            '' But in this case I need to copy selected files. i.e why Commented.
            'Dim fl As String
            'For Each fl In Directory.GetFiles(path)
            '    System.IO.File.Copy(fl, storepath & fileNameWithoutThePath(fl))
            'Next




            For Each ctrl As Control In PlaceHolder1.Controls

                For Each Ctrl1 As Control In ctrl.Controls
                    Final = Final & FldName
                    FldName = ""
                    For Each ctrl2 As Control In Ctrl1.Controls
                        For Each ctrl3 As Control In ctrl2.Controls
                            If ctrl3.GetType() Is GetType(TextBox) Then
                                Dim txt As TextBox = ctrl3
                                If Trim(txt.Text) <> "" Then
                                    FldName = FldName & "''" & txt.Text & "''" '& "," 'Trim(FldName) & ctrl3.ID & "=" & ctrl3.ID  '    CType(ctrl, TextBox).Text = 
                                    cnt += 1
                                Else
                                    FldName = ""
                                End If
                            ElseIf ctrl3.GetType() Is GetType(DropDownList) Then
                                Dim ddl As DropDownList = ctrl3
                                If Trim(ddl.SelectedItem.Text) <> "" Then
                                    FldName = FldName & "''" & ddl.SelectedItem.Text & "''" '& "," & "'" & ddl.SelectedItem.Text & "'" & "," 'Trim(FldName) & ctrl3.ID & "=" & ctrl3.ID  '    CType(ctrl, TextBox).Text = 
                                    cnt += 1
                                Else
                                    FldName = ""
                                End If
                            ElseIf ctrl3.GetType() Is GetType(Label) Then
                                Dim Lbl As Label = ctrl3
                                FldName = FldName & " select a.* into #t" & CStr(cnt) & " from  #t" & CStr(cnt - 1) & " a, jct_dms_trans_upload_param b where a.transno=b.transno and paramname=''" & Lbl.Text & "'' and descriptiontext ="

                            End If
                        Next
                    Next
                Next
            Next
            If cnt > 1 Then
                Final = Final & FldName  '30/july/2013
            End If
            Final = Final & " Select * from #t" & cnt - 1  '30/july/2013

            If ViewState("i") Is Nothing Then
                ViewState("i") = 0
            End If
            Me.DataList1.Visible = False
            DataList2.Visible = False
            Me.GrdResult.Visible = True

            'qry = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','" & Trim(txtFileRef.Text) & "','" & Trim(txtKeyInfo.Text) & "','" & Trim(txtPgNo.Text) & "','" & Trim(txtRefDate.Text) & "','" & Trim(txtDate.Text) & "','" & Session("Empcode") & "','" & Right(Trim(DdlFileType.SelectedValue), Len(Trim(DdlFileType.SelectedValue)) - InStr(DdlFileType.SelectedValue, "-->") - 2) & "','" & Trim(txtAutoFileNo.Text) & "','" & Final & "'"
            'dr = objfun.FetchReader(qry)
            'If dr.HasRows = True Then
            '    While dr.Read
            '        System.IO.File.Copy(dr(0), storepath & dr(1))
            '    End While
            'End If
            'dr.Close()
            qry = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','" & Trim(txtFileRef.Text) & "','" & Trim(txtKeyInfo.Text) & "','" & Trim(txtPgNo.Text) & "','" & Trim(txtRefDate.Text) & "','" & Trim(txtDate.Text) & "','" & Session("Empcode") & "','" & Right(Trim(DdlFileType.SelectedValue), Len(Trim(DdlFileType.SelectedValue)) - InStr(DdlFileType.SelectedValue, "-->") - 2) & "','" & Trim(txtAutoFileNo.Text) & "','" & Final & "'"
            dr = objfun.FetchReader(qry)
            Dim MissingFiles As String = ""
            If dr.HasRows = True Then
                While dr.Read
                    'If 
                    If System.IO.File.Exists(storepath & dr(1).ToString) = True Then
                        System.IO.File.Copy(dr(0), storepath & dr(1))
                    Else
                        MissingFiles = MissingFiles & "," & dr(1).ToString
                    End If
                End While
            End If
            dr.Close()
            script = ""
            'Dim script As String = ""
            If MissingFiles.Length > 1 Then
                script = "alert(' some files are missing!!" + MissingFiles + "');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
            End If

            qry = "JCT_DMS_Search_File_Typewise '" & "~\DocMgmt\Upd\" & Session("Empcode") & "\" & "','" & Trim(txtFileRef.Text) & "','" & Trim(txtKeyInfo.Text) & "','" & Trim(txtPgNo.Text) & "','" & Trim(txtRefDate.Text) & "','" & Trim(txtDate.Text) & "','" & Session("Empcode") & "','" & Right(Trim(DdlFileType.SelectedValue), Len(Trim(DdlFileType.SelectedValue)) - InStr(DdlFileType.SelectedValue, "-->") - 2) & "','" & Trim(txtAutoFileNo.Text) & "','" & Final & "'"
            objfun.FillGrid(qry, GrdResult)

        ElseIf Trim(Me.DdlFileType.SelectedValue) = "" Then
            'Me.DataList2.Visible = True
            'If Me.RadioButtonList1.Items(0).Selected = True Then
            '    qry = "select shortdesc as catg, count(*) as cnt, 'SearchResult.aspx?catg=' + filetype as lnk from JCT_DMS_Master_Category a,JCT_DMS_Trans_Upload b where a.parentcatg+a.catg =b.filetype and a.status=b.status and a.status='' and b.empcode='" & Session("Empcode") & "' group by filetype,shortdesc"
            'ElseIf Me.RadioButtonList1.Items(1).Selected = True Then
            Me.DataList2.Visible = True
            GrdResult.Visible = False
            qry = "JCT_DMS_Search_File 'ResultGrid.aspx?catg=','" & Trim(txtFileRef.Text) & "','" & Trim(txtKeyInfo.Text) & "','" & Trim(txtPgNo.Text) & "','" & Trim(txtRefDate.Text) & "','" & Trim(txtDate.Text) & "','" & Session("Empcode") & "','" & Trim(txtAutoFileNo.Text) & "'"
            'End If
            ds = objfun.FetchDS(qry)
            DataList2.DataSource = ds
            DataList2.DataBind()
            'obj.ConClose()
        End If
        'If txtPgNo.Text = 0 Then txtPgNo.Text = ""
        'If txtDate.Text = "01/01/1900" Then txtDate.Text = ""
        'If txtRefDate.Text = "01/01/1900" Then txtRefDate.Text = ""
    End Sub
    Public Function fileNameWithoutThePath(ByVal b As String) As String
        Dim j As Int16

        j = Convert.ToInt16(b.LastIndexOf("\"))
        Return b.Substring(j + 1)

    End Function
    Protected Sub GrdResult_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdResult.RowDataBound
        'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        'Dim filename As String = File2.PostedFile.FileName
        'Dim i As Integer
        If ViewState("i") Is Nothing Then
            ViewState("i") = 0
        End If

        'Dim storepath As String = "~\DocMgmt\Upd\" & FetchValue(qry) & "\" & Session("Empcode") & "\" 'Server.MapPath("~") + "/Upd"
        Dim storepath As String = "~\DocMgmt\Upd\" & Session("Empcode") & "\"
        If Not Directory.Exists(storepath) Then
            FMsg.Message = "No such folder Exists!!"
            FMsg.Display()
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grd As GridView = CType(e.Row.FindControl("GrdFileDtl"), GridView)
            Dim lnk As HyperLink = CType(e.Row.FindControl("LnkTrans"), HyperLink)
            'qry = "select fileno, filename,description, '" & storepath & "' + filename as  url, 'ResultFileDetail.aspx?TransNo=" & lnk.Text & "&flno=' + convert(varchar(5),fileno) as flurl from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & lnk.Text & " order by fileno"
            qry = "select fileno, filename,description, '" & storepath & "' + filename as url, 'ResultFileDetail.aspx?TransNo=' + convert(varchar(10),a.transno) + '&flno=' + convert(varchar(5),fileno) + '&catg=" & Right(Trim(DdlFileType.SelectedValue), Len(Trim(DdlFileType.SelectedValue)) - InStr(DdlFileType.SelectedValue, "-->") - 2) & "' as flurl from JCT_DMS_Trans_Upload_files a, JCT_DMS_Trans_Upload b where a.transno=b.transno and a.status='' and b.status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and autofileno='" & lnk.Text & "' order by fileno"

            objfun.FillGrid(qry, grd)
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='whitesmoke';this.style.cursor='pointer';")
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        If Not IsPostBack Then
            Me.RadioButtonList1.Items(0).Selected = True
            Me.RadioButtonList2.Items(0).Selected = True
            qry = "SELECT deptcode,deptname FROM Deptmast WHERE Company_Code= '" & Session("Companycode") & "' order by deptname"
            'Comented on 29July2013 qry = "SELECT dept_code,LongDesc FROM JCT_Epor_MASTER_Dept WHERE Company_Code='" & Session("Companycode") & "' and status='A'  order by longdesc"
            objfun.FillList(DrpDept, qry)
            qry = "SELECT a.deptname FROM Deptmast a, jct_empmast_base b WHERE b.EmpCode='" & Session("EmpCode") & "' AND b.DeptCode=a.DeptCode"
            'Comented on 29July2013qry = "SELECT A.LONGDESC FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("EmpCode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A'"
            DrpDept.SelectedItem.Text = objfun.FetchValue(qry).ToString()


            qry = "select shortdesc + '-->' + isnull(parentcatg,'') + catg, shortdesc + '-->' + isnull(parentcatg,'') + catg from JCT_DMS_Master_Category where status='' union select '', ''"
            objfun.FillList(DdlFileType, qry)
        Else
            If DdlFileType.Text = "" Then Exit Sub
            qry = "Select count(*) from JCT_DMS_Master_type_parameters where status='' and filetype=right('" & Trim(DdlFileType.SelectedValue) & "',len('" & Trim(DdlFileType.SelectedValue) & "')-charindex('-->','" & Trim(DdlFileType.SelectedValue) & "')-2)"
            obj.ConOpen()
            Cmd1 = New SqlCommand(qry, obj.Connection)
            dr1 = Cmd1.ExecuteReader
            If dr1.HasRows Then
                dr1.Read()
                'CreateLabelControls(4, dr1(0))
                If dr1(0) = 1 Then
                    ColCnt = dr1(0)
                    ReDim FldName(1)
                    ReDim CtrlType(1)
                    ReDim ProcName(1)
                ElseIf dr1(0) > 1 Then
                    ColCnt = System.Math.Round((dr1(0)))
                    ReDim FldName(dr1(0) + 1)
                    ReDim CtrlType(dr1(0) + 1)
                    ReDim ProcName(dr1(0) + 1)
                Else
                    ColCnt = 1
                    ReDim FldName(1)
                    ReDim CtrlType(1)
                    ReDim ProcName(1)
                End If

            End If
            dr1.Close()
            obj.ConClose()
            If ColCnt > 1 Then
                CreateLabelControls(2, ColCnt - 1)
            End If
        End If
    End Sub

    Protected Sub DdlFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlFileType.SelectedIndexChanged
        If DdlFileType.SelectedValue <> "" Then
            'qry = "Select count(*) from JCT_DMS_Master_type_parameters where status='' and filetype=right('" & Trim(DdlFileType.SelectedValue) & "',len('" & Trim(DdlFileType.SelectedValue) & "')-charindex('-->','" & Trim(DdlFileType.SelectedValue) & "')-2)"
            'obj.ConOpen()
            'Cmd1 = New SqlCommand(qry, obj.Connection)
            'dr1 = Cmd1.ExecuteReader
            'If dr1.HasRows Then
            '    dr1.Read()
            '    'CreateLabelControls(4, dr1(0))
            '    If dr1(0) = 1 Then
            '        ColCnt = dr1(0)
            '        ReDim FldName(1)
            '        ReDim CtrlType(1)
            '        ReDim ProcName(1)
            '    ElseIf dr1(0) > 1 Then
            '        ColCnt = System.Math.Round((dr1(0) + 1) / 2)
            '        ReDim FldName(dr1(0) + 1)
            '        ReDim CtrlType(dr1(0) + 1)
            '        ReDim ProcName(dr1(0) + 1)
            '    Else
            '        ColCnt = 1
            '        ReDim FldName(1)
            '        ReDim CtrlType(1)
            '        ReDim ProcName(1)
            '    End If

            'End If
            'dr1.Close()
            'obj.ConClose()
            'If ColCnt > 1 Then
            '    CreateLabelControls(2, ColCnt + 1)
            'End If
        End If

    End Sub
    Private Sub CreateLabelControls(ByVal ColCount As Int16, ByVal RowCount As Integer)
        intColCount = ColCount 'Convert.ToInt32(7)
        Dim N As Integer = 0
        Dim Ct As Integer = 0
        If DdlFileType.SelectedValue = "" Then Exit Sub
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
            'cH.Text = "Table Heading"
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
        'qry = "SELECT Parameter,paramType,ProcName FROM JCT_DMS_Master_type_parameters where status=''"
        qry = "SELECT Parameter,paramType,ProcName,description FROM JCT_DMS_Master_type_parameters where status='' and filetype=right('" & Trim(DdlFileType.SelectedValue) & "',len('" & Trim(DdlFileType.SelectedValue) & "')-charindex('-->','" & Trim(DdlFileType.SelectedValue) & "')-2) order by seqno"
        Cmd = New SqlCommand(qry, obj.Connection)
        dr = Cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                FldName(i) = dr(0)
                CtrlType(i) = dr(1)
                ProcName(i) = dr(2)
                Tooltip(i) = dr(3)
                i += 1
            End While
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
                        CreateTextBoxControls(r, rWeight, rID, i, RowLbl.ID, FldName(N).ToString, Tooltip(N).ToString)
                    ElseIf LCase(CtrlType(N)) = "dropdownlist" Then
                        CreateDropDownControls(r, rWeight, rID, i, ProcName(N).ToString, RowLbl.ID, FldName(N).ToString, Tooltip(N).ToString)
                    Else
                        CreateTextBoxControls(r, rWeight, rID, i, RowLbl.ID, FldName(N).ToString, Tooltip(N).ToString)
                    End If
                    'Ct += 1
                    'i += 1

                    'If LCase(dr(1)) = "textbox" Then
                    'If Ct = 0 Then
                    '    CreateTextBoxControls(r, rWeight, rID, c, i)
                    '    'ElseIf LCase(dr(1)) = "dropdownlist" Then
                    'ElseIf Ct = 1 Then
                    '    CreateDropDownControls(r, rWeight, rID, c, i)
                    'Else
                    '    CreateTextBoxControls(r, rWeight, rID, c, i)
                    'End If
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

    Protected Sub GrdResult_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdResult.SelectedIndexChanged
        'qry = "JCT_DMS_Search_File_Move '" & Server.MapPath("~\DOCmgmt\upd\") & "','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','" & CType(GrdResult.SelectedRow.FindControl("LnkTrans"), HyperLink).Text & "',' Select path from #t1 '"
        ''qry = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','" & CType(GrdResult.SelectedRow.FindControl("LnkTrans"), HyperLink).Text & "',' Select path from #t1 '"
        '' ''qry1 = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','',' Select filename from #t1 '"""

        'Dim filepath As String = objfun.FetchValue(qry)
        'Dim filename As String = System.IO.Path.GetFileName(filepath)

        'Response.ContentType = "application/octet-stream"
        'Response.AddHeader("Content-Disposition", String.Format("attachment; filename = {0}", System.IO.Path.GetFileName(filepath)))
        'Response.AppendHeader("Content-Disposition", "attachment; filename=" & System.IO.Path.GetFileName(filepath) & "")
        'Response.TransmitFile(filepath)
        'Response.End()

    End Sub
    '30/july

    Protected Sub LinkBtn_Click(sender As Object, e As System.EventArgs)

        Dim lnk As LinkButton = DirectCast(sender, LinkButton)

        Dim gvRow As GridViewRow = lnk.Parent.Parent


        Dim lblName As Label = DirectCast(gvRow.FindControl("lblName"), Label)

        'qry = "JCT_DMS_Search_File_Move '" & Server.MapPath("~\DOCmgmt\upd\") & "','','','','','','" & Session("Empcode") & "','" & Trim(txtFileRef.Text) & "','" & CType(gvRow.FindControl("LnkTrans"), HyperLink).Text & "',' Select path from #t1 '"
        qry = "JCT_DMS_Search_File_Move_Test '" & Server.MapPath("~\DOCmgmt\upd\") & "','','','','','','" & Session("Empcode") & "','" & Trim(txtFileRef.Text) & "','" & CType(gvRow.FindControl("LnkTrans"), HyperLink).Text & "',' Select path from #t1 ','" + lblName.Text + "'"


        ''qry = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','" & CType(GrdResult.SelectedRow.FindControl("LnkTrans"), HyperLink).Text & "',' Select path from #t1 '"
        '' ''qry1 = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','',' Select filename from #t1 '"""

        Dim filepath As String = objfun.FetchValue(qry)
        Dim filename As String = System.IO.Path.GetFileName(filepath)

        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename = {0}", System.IO.Path.GetFileName(filepath)))
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & System.IO.Path.GetFileName(filepath) & "")
        Response.TransmitFile(filepath)
        Response.End()
    End Sub
End Class
