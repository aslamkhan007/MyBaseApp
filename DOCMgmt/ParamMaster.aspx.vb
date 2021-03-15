Imports System.Threading.Thread
Imports System.Data
Imports System.Data.SqlClient
Partial Class ParamMaster
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass, qry As String
    Dim Dr As SqlDataReader
    Dim Exists As Boolean = False
    Dim Ds As New DataSet
    Dim objfun As Functions = New Functions


    Dim MaxRows As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("Empcode") = "" Then
        '    Response.Redirect("~/Login.aspx")
        'End If
        If Not Page.IsPostBack = True Then
            objfun.CheckPermission(objfun.GetCurrentPageName(), CmdAdd, CmdEdit, CmdDelete, Session("Empcode"), "DocMgmt")
            'Disable_Buttons(CmdSearch)
            Me.TxtEffFrom.Text = Now.Date()
            Me.TxtEffTo.Text = "01/01/3000"
        End If
    End Sub
    Protected Sub Grdhelp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PopupExp0.Commit(GrdHelp.SelectedRow.Cells(1).Text.ToString())
        'TxtParemeter.Text = Replace(GrdHelp.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
        'Me.TxtDesc.Text = Replace(GrdHelp.SelectedRow.Cells(2).Text.ToString, "&nbsp;", "")
        'Me.TxtStoredProc.Text = Replace(GrdHelp.SelectedRow.Cells(3).Text.ToString, "&nbsp;", "")
        'Me.TxtEffFrom.Text = Replace(GrdHelp.SelectedRow.Cells(4).Text.ToString, "&nbsp;", "")
        'Me.TxtEffTo.Text = Replace(GrdHelp.SelectedRow.Cells(5).Text.ToString, "&nbsp;", "")
        'Me.txtFileType.Text = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
        'Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
        'Script.SetFocus(txtFileType)
        '----------------
        txtFileType.Text = Replace(GrdHelp.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
        TxtParemeter.Text = Replace(GrdHelp.SelectedRow.Cells(2).Text.ToString, "&nbsp;", "")
        TxtDesc.Text = Replace(GrdHelp.SelectedRow.Cells(3).Text.ToString, "&nbsp;", "")
        DrpParamType.Text = Trim(Replace(GrdHelp.SelectedRow.Cells(4).Text.ToString, "&nbsp;", ""))
        DrpMandatory.SelectedValue = Trim(Replace(GrdHelp.SelectedRow.Cells(5).Text.ToString, "&nbsp;", ""))
        TxtStoredProc.Text = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
        TxtEffFrom.Text = Replace(GrdHelp.SelectedRow.Cells(7).Text.ToString, "&nbsp;", "")
        TxtEffTo.Text = Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", "")
        Txtseq.Text = Replace(GrdHelp.SelectedRow.Cells(9).Text.ToString, "&nbsp;", "")
        Lbltrans.Text = Replace(GrdHelp.SelectedRow.Cells(10).Text.ToString, "&nbsp;", "")
    End Sub
    Protected Sub GrdHelp_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdHelp.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow And (e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate) Then
            'e.Row.Attributes.Add("onmouseover", e.Row.Cells(0).Text)
            e.Row.Attributes.Add("onmouseover", "this.className='highlightrow'")
            e.Row.Attributes.Add("onmouseout", "this.className='normalrow'")
            e.Row.TabIndex = -1
            e.Row.Attributes("onclick") = String.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex)
            e.Row.Attributes("onkeydown") = "javascript:return SelectSibling(event);"
            e.Row.Attributes("onselectstart") = "javascript:return false;"
        End If

    End Sub
    Protected Sub Grdhelp_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdHelp.RowDataBound
        If CmdAdd.Text <> "Save" Then
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Exit Sub
            End If
            e.Row.Cells(4).Visible = False
            GrdHelp.HeaderRow.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            GrdHelp.HeaderRow.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            GrdHelp.HeaderRow.Cells(6).Visible = False
            e.Row.Attributes.Add("OnClick", Me.Page.ClientScript.GetPostBackEventReference(e.Row.Cells(0).FindControl("LinkButton3"), String.Empty))
        End If
    End Sub
    Protected Sub LoadGrid()
        If CmdAdd.Text <> "Save" Then
            SqlPass = "SELECT   [File Type]=filetype,Parameter , Description,[Parm Type]=ParamType,Mandatory,[Proc Name]=ProcName,[EffFrom]=createddt,[EffTo]=deletiondt,[Seq No.]=seqno,[Trans No.]=TransNo from jct_dms_master_type_parameters   WHERE status<>'D'  "
            objfun.FillGrid(SqlPass, GrdHelp)
        End If
    End Sub

    Protected Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '-----------------------------------------
        If CmdAdd.Text = "Save" And objfun.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = True Then
            'If TxtCode.Text = "" Then
            '    TxtCode.Text = Left(TxtLongDesc.Text, 3) & Genrate()
            'End If
            'SqlPass = "SELECT CASE Catg WHEN '' THEN 'X' ELSE Catg END  FROM JCT_DMS_Master_Category  WHERE catg='" & Trim(TxtParemeter.Text) & "' AND parentcatg='" & Trim(Me.TxtParemeter.Text) & "' and STATUS<>'D'"
            'If SelectRecord(SqlPass) = True Then
            '    FMsg.CssClass = "errormsg"
            '    FMsg.Message = "Record Already Exists.."
            '    FMsg.Display()
            'Else
            If DrpParamType.SelectedItem.Text = "DropDownList" Then
                SqlPass = "select  name   from sysobjects where type='v' and name ='" + TxtStoredProc.Text + "'"
                If objfun.SelectRecord(SqlPass) = False Then
                    FMsg.Message = "Give a Valid View Name"
                    Exit Sub
                End If


            End If

            SqlPass = "INSERT INTO jct_dms_master_type_parameters(CompanyCode,UserCode,HostIp,FileType ,Parameter ,Description,ParamType,Mandatory,ProcName,Status,CreatedDt,DeletionDt,DeletedBy,SeqNo, Stage) VALUES ('" & Session("CompanyCode") & "','" & Session("Empcode") & "','" & Request.UserHostAddress & "',right('" & Trim(Me.txtFileType.Text) & "',len('" & Trim(Me.txtFileType.Text) & "')-charindex('-->','" & Trim(Me.txtFileType.Text) & "')-2),UPPER('" & Trim(Me.TxtParemeter.Text) & "'),UPPER('" & Trim(Me.TxtDesc.Text) & "'),'" & DrpParamType.SelectedValue & "' ,'" & DrpMandatory.SelectedValue & "','" & Me.TxtStoredProc.Text & "','','" & Me.TxtEffFrom.Text & "','" & Me.TxtEffTo.Text & "',''," & Txtseq.Text & "," & txtStage.Text & " )"
            If objfun.InsertRecord(SqlPass) = False Then
                System.Threading.Thread.Sleep(1200)
                Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Transaction not Commited"
                FMsg.Display()
            Else
                System.Threading.Thread.Sleep(1200)
                Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Records Added Succesfully"
                FMsg.Display()
                objfun.CheckAddEnableDisable(CmdAdd, CmdEdit, CmdDelete, CmdClose, CmdSearch)
                objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
                objfun.TextBoxDisable(TxtDesc, TxtStoredProc, TxtEffFrom, TxtEffTo)
                TextBoxBlank()
                TextParentDisable()

                'End If
            End If
        ElseIf CmdAdd.Text = "Add" Then
            TextParentEnable()
            TextBoxBlank()
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(txtFileType)
            objfun.CheckAddEnableDisable(CmdAdd, CmdEdit, CmdDelete, CmdClose, CmdSearch)
            objfun.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDelete)
            objfun.TextBoxEnable(TxtDesc, TxtStoredProc, TxtEffFrom, TxtEffTo)
        ElseIf CmdAdd.Text = "Save" And objfun.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = False Then
            System.Threading.Thread.Sleep(1200)
            Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Effective To Should be Greater than Effective From"
            FMsg.Display()
            Panel2.Visible = False
        End If
        '-----------------------------------------
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If TxtDesc.Text <> "" And TxtStoredProc.Text = "" Then
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtStoredProc)
        ElseIf TxtDesc.Text <> "" And TxtStoredProc.Text <> "" And TxtEffFrom.Text = "" Then
            'TxtCode.Text = Left(TxtLongDesc.Text, 3) & Genrate()
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtEffFrom)
        ElseIf TxtDesc.Text <> "" And TxtStoredProc.Text <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text = "" Then
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtEffTo)
        ElseIf TxtDesc.Text <> "" And TxtStoredProc.Text <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text <> "" Then
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(CmdAdd)
        End If
    End Sub
    'Protected Function Genrate() As Integer
    '    Dim FrmName As String = "Department", Type As String = "DEPT", Modules As String = "Employee Portal"
    '    SqlPass = "SELECT MAX(SERIAL) FROM JCTGEN..JCT_COMMON_SERIAL_MASTER WHERE COMPANY_CODE='" & Session("Location") & "' AND FRMNAME='" & FrmName & "' AND  TYPE='" & Type & "' AND MODULE ='" & Modules & "'"


    '    If AutoGenrate(SqlPass) = 101 Then
    '        SqlPass = "INSERT INTO JCTGEN..JCT_COMMON_SERIAL_MASTER(COMPANY_CODE,FRMNAME,SERIAL,TYPE,MODULE)VALUES('" & Session("Location") & "','" & FrmName & "','101','" & Type & "','" & Modules & "' )"
    '        If (InsertRecord(SqlPass) = True) Then
    '            TxtCode.Text = 101
    '        End If
    '    Else
    '        SqlPass = "UPDATE JCTGEN..JCT_COMMON_SERIAL_MASTER SET SERIAL= SERIAL +1  WHERE COMPANY_CODE='" & Session("Location") & "' AND FRMNAME='" & FrmName & "' AND  TYPE='" & Type & "' AND MODULE ='" & Modules & "'  "
    '        UpdateRecord(SqlPass)
    '    End If
    '    SqlPass = "SELECT MAX(SERIAL)-1 FROM JCTGEN..JCT_COMMON_SERIAL_MASTER WHERE COMPANY_CODE='" & Session("Location") & "' AND FRMNAME='" & FrmName & "' AND  TYPE='" & Type & "' AND MODULE ='" & Modules & "'"
    '    Genrate = AutoGenrate(SqlPass)
    'End Function

    Protected Sub CmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        LoadGrid()
    End Sub

    Public Sub TextBoxBlank()
        TxtParemeter.Text = Nothing
        Txtseq.Text = Nothing
        TxtDesc.Text = Nothing
        TxtStoredProc.Text = Nothing
        Me.txtFileType.Text = Nothing
        Me.TxtEffFrom.Text = Now.Date()
        Me.TxtEffTo.Text = "01/01/3000"
        Me.Lbltrans.Text = ""
    End Sub
    Protected Sub CmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        TextParentDisable()
        If CmdEdit.Text = "Update" And objfun.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = True Then
            SqlPass = "UPDATE jct_dms_master_type_parameters  SET STATUS='D',deletedby='" & Session("Empcode") & "' WHERE   transno=" & Lbltrans.Text & ""

            If objfun.UpdateRecord(SqlPass) = False Then
                System.Threading.Thread.Sleep(1200)
                Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Update Transaction not Commited"
                FMsg.Display()
            Else
                SqlPass = "INSERT INTO jct_dms_master_type_parameters(CompanyCode,UserCode,HostIp,FileType ,Parameter ,Description,ParamType,Mandatory,ProcName,Status,CreatedDt,DeletionDt,DeletedBy,SeqNo, Stage) VALUES ('" & Session("CompanyCode") & "','" & Session("Empcode") & "','" & Request.UserHostAddress & "','" & Trim(Me.txtFileType.Text) & "',UPPER('" & Trim(Me.TxtParemeter.Text) & "'),UPPER('" & Trim(Me.TxtDesc.Text) & "'),'" & DrpParamType.SelectedValue & "' ,'" & DrpMandatory.SelectedValue & "','" & Me.TxtStoredProc.Text & "','','" & Me.TxtEffFrom.Text & "','" & Me.TxtEffTo.Text & "',''," & Txtseq.Text & " ," & txtStage.Text & ")"
                If objfun.InsertRecord(SqlPass) = True Then
                    System.Threading.Thread.Sleep(1200)
                    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Updated Record Succesfully"
                    FMsg.Display()
                    objfun.CheckEditEnableDisable(CmdEdit, CmdAdd, CmdDelete, CmdClose, CmdSearch)
                    objfun.TextBoxDisable(TxtDesc, TxtStoredProc, TxtEffFrom, TxtEffTo)
                    Me.TxtParemeter.Enabled = False
                    objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
                    TextBoxBlank()

                Else
                    objfun.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDelete)
                    System.Threading.Thread.Sleep(1200)
                    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Update Transaction not Commited"
                    FMsg.Display()
                    SqlPass = "UPDATE jct_dms_master_type_parameters   SET  STATUS='',deletedby='' WHERE transno=" & Lbltrans.Text
                    objfun.UpdateRecord(SqlPass)
                    objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)

                End If

            End If

        ElseIf CmdEdit.Text = "Edit" Then
            objfun.TextBoxEnable(TxtDesc, TxtStoredProc, TxtEffFrom, TxtEffTo)
            Me.TxtParemeter.Enabled = True
            'Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            'Script.SetFocus(txtFileType)
            objfun.CheckEditEnableDisable(CmdEdit, CmdAdd, CmdDelete, CmdClose, CmdSearch)
            objfun.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDelete)
        ElseIf CmdEdit.Text = "Update" And objfun.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = False Then
            System.Threading.Thread.Sleep(1200)
            Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Effective To Should be Greater than Effective From"
            FMsg.Display()
        End If

    End Sub
    Protected Sub CmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        TextParentDisable()
        If CmdClose.Text = "Close" Then
            Response.Redirect("~/Default.aspx")
        Else
            objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
            objfun.CheckCloseEnableDisable(CmdClose, CmdAdd, CmdEdit, CmdDelete, CmdSearch)
            objfun.TextBoxDisable(TxtDesc, TxtStoredProc, TxtEffFrom, TxtEffTo)
            Me.TxtParemeter.Enabled = False
            TextBoxBlank()
        End If
    End Sub
    Protected Sub CmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        TextParentDisable()
        objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
        If Trim(Me.TxtParemeter.Text) <> "" And Trim(Me.TxtDesc.Text) <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text <> "" Then

            If CmdDelete.Text = "Delete" Then
                'SqlPass = "SELECT DISTINCT ParentCatg + Catg   FROM JCTDEV..Jct_Epor_Master_Employee WHERE ParentCatg + Catg=UPPER('" & Trim(Me.TxtParemeter.Text) & Trim(Me.TxtParemeter.Text) & "') AND STATUS='A' "
                'If CheckRecordExistInTransaction(SqlPass) = False Then

                SqlPass = "UPDATE jct_dms_master_type_parameters   SET  STATUS='D' ,createddt=GETDATE(),deletedby='" & Session("Empcode") & "' WHERE transno=" & Lbltrans.Text & ""

                If objfun.UpdateRecord(SqlPass) = False Then
                    System.Threading.Thread.Sleep(1200)
                    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Deleted Transaction not Commited"
                    FMsg.Display()
                Else
                    System.Threading.Thread.Sleep(1200)
                    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Record Deleted Succesfully"
                    FMsg.Display()
                    objfun.CheckDeleteEnableDisable(CmdDelete, CmdAdd, CmdEdit, CmdClose)
                    objfun.TextBoxDisable(TxtDesc, TxtStoredProc, TxtEffFrom, TxtEffTo)
                    objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
                    TextBoxBlank()

                End If
                'Else
                '    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                '    FMsg.CssClass = "errormsg"
                '    FMsg.Message = "This Record Used In Transactions Record So Please Delete from Transaction "
                '    FMsg.Display()
                'End If
            End If
        Else
            System.Threading.Thread.Sleep(1200)
            Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Fields value required"
            FMsg.Display()
        End If

    End Sub
    Protected Sub TextParentEnable()
        TxtParemeter.Enabled = True
    End Sub
    Protected Sub TextParentDisable()
        TxtParemeter.Enabled = False
    End Sub
    Protected Sub CmdFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFirst.Click
        If MaxRows <= 0 Then
            SqlPass = "SELECT   [File Type]=filetype,Parameter , Description,[Parm Type]=ParamType,Mandatory,[Proc Name]=ProcName,[EffFrom]=createddt,[EffTo]=deletiondt,[Seq No.]=seqno,[Trans No.]=transno from jct_dms_master_type_parameters   WHERE status<>'D'  "
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = 0
        Navigation(0)
        CmdFirst.Enabled = False
        CmdNext.Enabled = True
        CmdPrevious.Enabled = True
        CmdLast.Enabled = True
        Me.GrdHelp.SelectedIndex = 0
    End Sub

    Protected Sub CmdNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdNext.Click
        If maxrows <= 0 Then
            SqlPass = "SELECT   [File Type]=filetype,Parameter , Description,[Parm Type]=ParamType,Mandatory,[Proc Name]=ProcName,[EffFrom]=createddt,[EffTo]=deletiondt,[Seq No.]=seqno,[Trans No.]=transno  from jct_dms_master_type_parameters   WHERE status<>'D'  "
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = ViewState("Count") + 1

        If ViewState("Count") < maxrows - 1 And ViewState("Count") <> maxrows Then
            CmdPrevious.Enabled = True
            CmdFirst.Enabled = True
        Else
            CmdNext.Enabled = False
            CmdLast.Enabled = False
            CmdFirst.Enabled = True
            CmdPrevious.Enabled = True
        End If
        Navigation(ViewState("Count"))

        Me.grdhelp.SelectedIndex = Me.grdhelp.SelectedIndex + 1
    End Sub

    Protected Sub CmdPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrevious.Click
        If maxrows <= 0 Then
            SqlPass = "SELECT   [File Type]=filetype,Parameter , Description,[Parm Type]=ParamType,Mandatory,[Proc Name]=ProcName,[EffFrom]=createddt,[EffTo]=deletiondt,[Seq No.]=seqno,[Trans No.]=transno  from jct_dms_master_type_parameters   WHERE status<>'D'  "
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = ViewState("Count") - 1

        If ViewState("Count") < maxrows - 1 And ViewState("Count") <> 0 Then
            CmdNext.Enabled = True
            CmdLast.Enabled = True
        Else
            CmdPrevious.Enabled = False
            CmdFirst.Enabled = False
            CmdNext.Enabled = True
            CmdLast.Enabled = True
        End If

        Navigation(ViewState("Count"))
        Me.grdhelp.SelectedIndex = Me.grdhelp.SelectedIndex - 1
    End Sub

    Protected Sub CmdLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdLast.Click
        If maxrows <= 0 Then
            SqlPass = "SELECT   [File Type]=filetype,Parameter , Description,[Parm Type]=ParamType,Mandatory,[Proc Name]=ProcName,[EffFrom]=createddt,[EffTo]=deletiondt,[Seq No.]=seqno,[Trans No.]=transno  from jct_dms_master_type_parameters   WHERE status<>'D'  "
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        Navigation(MaxRows - 1)
        ViewState("Count") = maxrows - 1
        CmdLast.Enabled = False
        CmdNext.Enabled = False
        CmdPrevious.Enabled = True
        CmdFirst.Enabled = True
        Me.grdhelp.SelectedIndex = Me.grdhelp.Rows.Count() - 1
    End Sub

    Protected Sub Navigation(ByVal i As Integer)
        Try
            txtFileType.Text = Ds.Tables(0).Rows(i).Item(0)
            TxtParemeter.Text = Ds.Tables(0).Rows(i).Item(1)
            TxtDesc.Text = Ds.Tables(0).Rows(i).Item(2)
            DrpParamType.Text = Ds.Tables(0).Rows(i).Item(3)
            DrpMandatory.SelectedValue = Ds.Tables(0).Rows(i).Item(4)
            TxtStoredProc.Text = Ds.Tables(0).Rows(i).Item(5)
            TxtEffFrom.Text = Ds.Tables(0).Rows(i).Item(6)
            TxtEffTo.Text = Ds.Tables(0).Rows(i).Item(7)
            Txtseq.Text = Ds.Tables(0).Rows(i).Item(8)
            Lbltrans.Text = Ds.Tables(0).Rows(i).Item(9)
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

    Protected Sub DrpParamType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpParamType.SelectedIndexChanged
        If DrpParamType.SelectedValue = "YesNo" Then
            'Me.TxtStoredProc.Text = "JCT_DMS_YesNo"

        Else

            Me.TxtStoredProc.Text = ""
        End If

        If DrpParamType.SelectedItem.Text = "DropDownList" Then
            reqSP.Enabled = True
        Else
            reqSP.Enabled = False

        End If
    End Sub
End Class
