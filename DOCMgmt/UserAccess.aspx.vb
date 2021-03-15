Imports System.Data.SqlClient
Partial Class DOCMgmt_UserAccess
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim dr As SqlDataReader
    Dim i As Integer
    Dim objfun As Functions = New Functions
    Dim Str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If

        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If

        If IsPostBack = False Then
            'str = objfun.FetchValue("SELECT a.catg  FROM dbo.JCT_EmpMast_Base a join  JCT_Emp_Catg_Desg_Mapping b on a.catg=b.catg WHERE a.empcode='" & Session("Empcode") & "' AND Active='Y'")
            'If str = "SM1" Then

            'qry = "select a.emp_code,isnull(b.longdesc,'') + ' - ' + isnull(a.fullname,'')  from JCTDEV..JCT_EPOR_MASTER_EMPLOYEE a left outer join jctdev..JCT_Epor_MASTER_Dept b on a.dept_code=b.dept_code and b.status='a' where a.status='A' and a.active_flag='y' and getdate() between a.eff_from and a.eff_to order by b.longdesc,fullname"
            qry = "select a.empcode,isnull(b.deptname,'') + ' - ' + isnull(a.empname,'')  from JCTDEV..JCT_empmast_base a left outer join jctdev..Deptmast b on a.deptcode=b.deptcode  where a.active='y' order by b.deptname,a.empname"
            dr = objfun.FetchReader(qry)
            If dr.HasRows = True Then
                While dr.Read()
                    Dim lst As New ListItem
                    lst.Text = dr(1)
                    lst.Value = dr(0)
                    Me.chkUsers.Items.Add(lst)
                End While
            End If

            'Else
            '    'qry = "select a.emp_code,isnull(b.longdesc,'') + ' - ' + isnull(a.fullname,'')  from JCTDEV..JCT_EPOR_MASTER_EMPLOYEE a left outer join jctdev..JCT_Epor_MASTER_Dept b on a.dept_code=b.dept_code and b.status='a' where a.status='A' and a.active_flag='y' and getdate() between a.eff_from and a.eff_to order by b.longdesc,fullname"
            '    qry = "select a.empcode,isnull(b.deptname,'') + ' - ' + isnull(a.empname,'')  from JCTDEV..JCT_empmast_base a left outer join jctdev..Deptmast b  on  a.deptcode=b.deptcode  where  a.deptcode=( select b.deptcode from jct_empmast_base a join deptmast b on  a.deptcode=b.deptcode and a.empcode='" & Session("Empcode") & "') and a.active='y' and a.empcode not in ('SPGUSR','MKTUSR','GRYUSR','RSHUSR','WVGUSR','PHSUSR','RMGUSR','SYNUSR','TFTUSR','GenUser','" & Session("Empcode") & "')"
            '    dr = objfun.FetchReader(qry)
            '    If dr.HasRows = True Then
            '        While dr.Read()
            '            Dim lst As New ListItem
            '            lst.Text = dr(1)
            '            lst.Value = dr(0)
            '            Me.chkUsers.Items.Add(lst)
            '        End While
            '    End If
            'End If

            dr.Close()
            qry = "select shortdesc + '-->' + isnull(parentcatg,'') + catg, shortdesc + '-->' + isnull(parentcatg,'') + catg from JCT_DMS_Master_Category where status='' union select '', ''"
            objfun.FillList(DDLFileType, qry)
            Gridfill()
        End If



        'If IsPostBack = False Then
        '    'qry = "select a.emp_code,isnull(b.longdesc,'') + ' - ' + isnull(a.fullname,'')  from JCTDEV..JCT_EPOR_MASTER_EMPLOYEE a left outer join jctdev..JCT_Epor_MASTER_Dept b on a.dept_code=b.dept_code and b.status='a' where a.status='A' and a.active_flag='y' and getdate() between a.eff_from and a.eff_to order by b.longdesc,fullname"
        '    qry = "select a.empcode,isnull(b.deptname,'') + ' - ' + isnull(a.empname,'')  from JCT_empmast_base a left outer join Deptmast b on a.deptcode=b.deptcode  where a.active='y' order by b.deptname,a.empname"
        '    dr = objfun.FetchReader(qry)
        '    If dr.HasRows = True Then
        '        While dr.Read()
        '            Dim lst As New ListItem
        '            lst.Text = dr(1)
        '            lst.Value = dr(0)
        '            Me.chkUsers.Items.Add(lst)
        '        End While
        '    End If
        '    dr.Close()
        '    qry = "select shortdesc + '-->' + isnull(parentcatg,'') + catg, shortdesc + '-->' + isnull(parentcatg,'') + catg from JCT_DMS_Master_Category where status='' union select '', ''"
        '    objfun.FillList(DDLFileType, qry)
        '    Gridfill()
        'End If
    End Sub
    Protected Sub Gridfill()
        Dim fltype As String
        'qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        If DDLFileType.SelectedValue <> "" Then
            fltype = Right(Trim(DDLFileType.SelectedValue), Len(Trim(DDLFileType.SelectedValue)) - InStr(DDLFileType.SelectedValue, "-->") - 2)
        Else
            fltype = ""
        End If
        Dim storepath As String = "~\DocMgmt\Upd\" & Session("Empcode") & "\"
        'qry = "select b.fileno, a.transno, fullname as UploadBy, '" & storepath & "' + filename as url,filename as filename,case when right(filename,4) in ('docx','.doc') then 'Image/Icons/icon-ms-word.gif' when right(filename,4) in ('xlsx','.xls') then 'Image/Icons/icon-ms-excel.gif' when right(filename,4) in ('pptx','.ppt') then 'Image/Icons/icon-ms-powerpoint.gif'" & _
        '    "  when right(filename,4) in ('mdbx','.mdb') then 'Image/Icons/icon-ms-access.gif'  else '" & storepath & "' + filename end as img, convert(varchar(10),EnteredDt,101) as CreatedDt, KeyInfo,filerefno,a.transno, convert(varchar(10),FileRefDate,101) as FileRefDate, a.Autofileno from JCT_DMS_Trans_Upload a, JCT_DMS_Trans_Upload_files b, jct_epor_master_employee c where a.empcode=c.emp_code and a.transno=b.transno and c.active_flag='y' and a.empcode='" & Session("Empcode") & "' and a.status='' and b.status='' and c.status='A' and getdate() between c.eff_from and c.eff_to " & _
        '    " and a.filetype like '" & fltype & "' + '%' order by a.transno,b.fileno"

        qry = " select b.fileno, a.transno,c.empname as UploadBy, '" & storepath & "'  + filename as url," & _
" filename as filename,case when right(filename,4) in ('docx','.doc') then 'Image/Icons/icon-ms-word.gif' when right(filename,4) in " & _
"('xlsx','.xls') then 'Image/Icons/icon-ms-excel.gif' when right(filename,4) in ('pptx','.ppt') then 'Image/Icons/icon-ms-powerpoint.gif'" & _
"when right(filename,4) in ('mdbx','.mdb') then 'Image/Icons/icon-ms-access.gif'  else '" & storepath & "' + filename end as img, convert(varchar(10),EnteredDt,101) as CreatedDt, KeyInfo,filerefno,a.transno, convert(varchar(10),FileRefDate,101) as FileRefDate, a.Autofileno from JCT_DMS_Trans_Upload a, JCT_DMS_Trans_Upload_files b, jct_empmast_base c " & _
"where a.empcode=c.empcode and a.transno=b.transno and c.active='y' and a.empcode='" & Session("Empcode") & "' and a.status='' and b.status=''" & _
"and a.filetype like '" & fltype & "' + '%' order by a.transno,b.fileno"




        objfun.FillGrid(qry, GrdResult)
    End Sub
    Protected Sub LnkGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkGet.Click
        'qry = "select a.emp_code,a.fullname, b.longdesc from JCTDEV..JCT_EPOR_MASTER_EMPLOYEE a inner join jctdev..JCT_Epor_MASTER_Dept b " & _
        '    "on a.dept_code=b.dept_code and b.status='a' and longdesc like '%" & txtDept.Text & "%' " & _
        '    "left outer join production..role_user_mapping c on a.emp_code = c.uname and role=''" & _
        '    "where a.status='A' and a.active_flag='y' and getdate() between a.eff_from and a.eff_to and a.fullname + '-->' + a.emp_code like '%" & Trim(Me.txtEmployee.Text) & "%' order by b.longdesc,a.fullname"


        qry = "select a.empcode,a.empname, b.deptname from JCTDEV..jct_empmast_base a inner join jctdev..deptmast b on a.deptcode=b.deptcode and b.deptname like '%INFORMATION TECHNOLOGY%' left outer join production..role_user_mapping c on a.empcode = c.uname and role=''where a.active='y' and a.empname + '-->' + a.empcode like '%" & Trim(Me.txtEmployee.Text) & "%' order by b.deptname,a.empname"

        dr = objfun.FetchReader(qry)
        If dr.HasRows = True Then
            If ViewState("i") Is Nothing Then ViewState("i") = 0
            While dr.Read()
                For i = ViewState("i") To Me.chkUsers.Items.Count - 1
                    If chkUsers.Items(i).Value = dr(0) Then
                        chkUsers.Items(i).Selected = True
                        ViewState("i") = i
                        Exit For
                    End If
                Next
            End While
        End If
        dr.Close()
        ModalPopupExtender1.Hide()
    End Sub

    Protected Sub RbSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSelect.SelectedIndexChanged
        Dim i As Integer
        If Me.RbSelect.Items(0).Selected = True Then
            For i = 0 To chkAction.Items.Count - 1
                chkAction.Items(i).Selected = True
            Next
        Else
            For i = 0 To chkAction.Items.Count - 1
                chkAction.Items(i).Selected = False
            Next
        End If
    End Sub


    Protected Sub chkAllFiles_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cbHeader As CheckBox = CType(GrdResult.HeaderRow.FindControl("chkAllFiles"), CheckBox)
        Dim i As Integer
        If cbHeader.Checked = True Then
            For i = 0 To GrdResult.Rows.Count - 1
                Dim chk As CheckBox = CType(GrdResult.Rows(i).FindControl("chkFile"), CheckBox)
                chk.Checked = True
            Next
        Else
            For i = 0 To GrdResult.Rows.Count - 1
                Dim chk As CheckBox = CType(GrdResult.Rows(i).FindControl("chkFile"), CheckBox)
                chk.Checked = False
            Next
        End If
    End Sub

    Protected Sub LnkSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSubmit.Click
        Dim i As Integer
        Dim UserCode(500) As String
        Dim userCount As Integer = 0
        Dim fileTransNo As Integer
        Dim fileNo As Integer
        Dim rec As Boolean
        Dim fltype As String

        For i = 0 To chkUsers.Items.Count - 1
            If chkUsers.Items(i).Selected = True Then
                UserCode(userCount) = chkUsers.Items(i).Value
                userCount += 1
            End If
        Next
        If DDLFileType.SelectedValue <> "" Then
            fltype = Right(Trim(DDLFileType.SelectedValue), Len(Trim(DDLFileType.SelectedValue)) - InStr(DDLFileType.SelectedValue, "-->") - 2)
        Else
            fltype = ""
        End If
        If RBLAccessType.Items(0).Selected = True Then
            
            For j = 0 To chkAction.Items.Count - 1
                If chkAction.Items(j).Selected = True Then
                    For k = 0 To userCount - 1
                        If CheckExist(Session("Empcode"), UserCode(k), 0, 0, fltype, chkAction.Items(j).Text) = True Then
                            FMsg.Message = "Record(s) already exist(s)!!"
                            Exit For
                        End If
                        qry = "insert into JCT_DMS_User_Access (CompanyCode,EmpCode,OwnerCode,UserCode,FileTransNo,FileNo,FileType,Access,Status,EffFrom,EffTo,DeletedBy) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Session("Empcode") & "','" & UserCode(k) & "',0,0,'" & fltype & "','" & chkAction.Items(j).Text & "','',getdate(),'12/31/3000',null)"
                        If objfun.InsertRecord(qry) = True Then rec = True
                    Next
                End If
            Next
        Else

            For i = 0 To Me.GrdResult.Rows.Count - 1
                If GrdResult.Rows(i).RowType = DataControlRowType.DataRow Then
                    Dim chk As CheckBox = CType(GrdResult.Rows(i).FindControl("chkFile"), CheckBox)
                    If chk.Checked = True Then
                        fileTransNo = GrdResult.Rows(i).Cells(2).Text
                        fileNo = GrdResult.Rows(i).Cells(3).Text
                        For j = 0 To chkAction.Items.Count - 1
                            If chkAction.Items(j).Selected = True Then
                                For k = 0 To userCount - 1
                                    If CheckExist(Session("Empcode"), UserCode(k), fileTransNo, fileNo, fltype, chkAction.Items(j).Text) = True Then
                                        FMsg.Message = "Record(s) already exist(s)!!"
                                        Exit For
                                    End If
                                    qry = "insert into JCT_DMS_User_Access (CompanyCode,EmpCode,OwnerCode,UserCode,FileTransNo,FileNo,FileType,Access,Status,EffFrom,EffTo,DeletedBy) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Session("Empcode") & "','" & UserCode(k) & "'," & fileTransNo & "," & fileNo & ",'" & fltype & "','" & chkAction.Items(j).Text & "','',getdate(),'12/31/3000',null)"
                                    If objfun.InsertRecord(qry) = True Then rec = True
                                Next
                            End If
                        Next
                    End If
                End If
            Next
        End If
        If rec = True Then FMsg.Message = "Record(s) added Successfully!!"
        FMsg.Display()
    End Sub
    Protected Function CheckExist(ByVal owner As String, ByVal User As String, ByVal filetransno As Integer, ByVal fileno As Integer, ByVal filetype As String, ByVal access As String) As Boolean
        qry = "select * from jct_dms_user_access where ownercode='" & owner & "' and usercode='" & User & "' and filetransno=" & filetransno & " and fileno=" & fileno & " and filetype='" & filetype & "' and access='" & access & "'"
        dr = objfun.FetchReader(qry)
        If dr.HasRows = True Then
            CheckExist = True
        Else
            CheckExist = False
        End If
        dr.Close()
    End Function

    Protected Sub chkAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAction.SelectedIndexChanged
        If chkAction.Items(0).Selected = False Then
            chkAction.Items(1).Selected = False
            chkAction.Items(2).Selected = False
        ElseIf chkAction.Items(1).Selected = False Then
            chkAction.Items(2).Selected = False
        ElseIf chkAction.Items(2).Selected = True Then
            chkAction.Items(1).Selected = True
            chkAction.Items(0).Selected = True
        ElseIf chkAction.Items(1).Selected = True Then
            chkAction.Items(0).Selected = True
        End If
    End Sub

    Protected Sub DDLFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLFileType.SelectedIndexChanged

        Gridfill()

    End Sub
End Class
