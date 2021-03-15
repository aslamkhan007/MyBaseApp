Imports System.Threading.Thread
Imports System.Data
Imports System.Data.SqlClient
Partial Class CatgMaster
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass, qry As String
    Dim Dr As SqlDataReader
    Dim Exists As Boolean = False
    Dim Ds As New DataSet
    Dim objfun As New Functions
    Dim MaxRows As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        TxtCode.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")
        TxtShortDesc.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")
        TxtLongDesc.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")
        TxtEffFrom.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")
        TxtEffTo.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")

        If Not Page.IsPostBack = True Then
            objfun.CheckPermission(objfun.GetCurrentPageName(), CmdAdd, CmdEdit, CmdDelete, Session("Empcode"), "DocMgmt")
            'Disable_Buttons(CmdSearch)
            LoadGridParent()
        End If
        'qry = "SELECT dept_code,LongDesc FROM JCT_Epor_MASTER_Dept WHERE Company_Code='" & Session("Companycode") & "' and status='A'  order by longdesc"
        qry = "select deptcode,deptname from deptmast"
        objfun.FillList(DrpDept, qry)
        'qry = "SELECT A.LONGDESC FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A'"
        qry = "select deptname  from jct_empmast_base a join deptmast b on a.deptcode=b.deptcode and a.empcode='" & Session("Empcode") & "'"
        DrpDept.SelectedItem.Text = objfun.FetchValue(qry) 'FetchValue("SELECT A.DEPT_CODE FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("EmoCode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A'")
    End Sub

    Protected Sub Grdhelp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PopupExp.Commit(GrdHelp.SelectedRow.Cells(1).Text.ToString())
        TxtCode.Text = Replace(GrdHelp.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
        Me.TxtShortDesc.Text = Replace(GrdHelp.SelectedRow.Cells(2).Text.ToString, "&nbsp;", "")
        Me.TxtLongDesc.Text = Replace(GrdHelp.SelectedRow.Cells(3).Text.ToString, "&nbsp;", "")
        Me.TxtEffFrom.Text = Replace(GrdHelp.SelectedRow.Cells(4).Text.ToString, "&nbsp;", "")
        Me.TxtEffTo.Text = Replace(GrdHelp.SelectedRow.Cells(5).Text.ToString, "&nbsp;", "")
        Me.TxtParent.Text = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
        Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
        Script.SetFocus(TxtShortDesc)
    End Sub

    Protected Sub GridViewParent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.TxtParent.Text = GridViewParent.SelectedRow.Cells(1).Text.ToString
        Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")

    End Sub

    Protected Sub GrdHelp_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdHelp.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Attributes.Add("onmouseover", e.Row.Cells(0).Text)
            e.Row.Attributes.Add("onmouseover", "this.className='highlightrow'")
            e.Row.Attributes.Add("onmouseout", "this.className='normalrow'")
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

    Protected Sub GridViewParent_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewParent.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Attributes.Add("onmouseover", e.Row.Cells(0).Text)
            e.Row.Attributes.Add("onmouseover", "this.className='highlightrow'")
            e.Row.Attributes.Add("onmouseout", "this.className='normalrow'")
        End If
    End Sub

    Protected Sub GridViewParent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewParent.RowDataBound
        If CmdAdd.Text <> "Save" Then
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Exit Sub
            End If
            e.Row.Attributes.Add("OnClick", Me.Page.ClientScript.GetPostBackEventReference(e.Row.Cells(0).FindControl("LinkButtonParent"), String.Empty))
        End If
    End Sub

    Protected Sub LoadGrid()
        If CmdAdd.Text <> "Save" Then
            SqlPass = "SELECT [Catg]=Catg, [Short Desc]=ShortDesc,[Long Desc]=LONGDESC ,EffFrom,EffTo,ParentCatg  from jctdev..JCT_DMS_Master_Category WHERE status<>'D'   "
            objfun.FillGrid(SqlPass, GrdHelp)
        End If
    End Sub

    Protected Sub LoadGridParent()
        If CmdAdd.Text <> "Save" Then
            SqlPass = "SELECT     [Catg]=Catg, [Short Desc]=ShortDesc,[Long Desc]=LONGDESC    from jctdev..JCT_DMS_Master_Category  WHERE status<>'D'   "
            objfun.FillGrid(SqlPass, GridViewParent)
        End If
    End Sub

    Protected Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        '-----------------------------------------
        '-----------------------------------------
        If CmdAdd.Text = "Save" And objfun.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = True Then
            'If TxtCode.Text = "" Then
            '    TxtCode.Text = Left(TxtLongDesc.Text, 3) & Genrate()
            'End If
            SqlPass = "SELECT CASE Catg WHEN '' THEN 'X' ELSE Catg END  FROM JCT_DMS_Master_Category  WHERE catg='" & Trim(TxtCode.Text) & "' AND parentcatg='" & Trim(Me.TxtParent.Text) & "' and STATUS<>'D'"
            If objfun.SelectRecord(SqlPass) = True Then
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Record Already Exists.."
                FMsg.Display()
            Else
                SqlPass = "INSERT INTO JCT_DMS_Master_Category (CompanyCode,EmpCode, Catg ,ShortDesc , LongDesc ,EffFrom, EffTo,Host_Ip, Status , Entry_Time,ParentCatg) VALUES ('" & Session("CompanyCode") & "','" & Session("Empcode") & "',UPPER('" & (Trim(Me.TxtCode.Text) & "'),UPPER('" & Trim(Me.TxtShortDesc.Text) & "'),UPPER('" & Trim(Me.TxtLongDesc.Text) & "'),'" & TxtEffFrom.Text & "' ,'" & TxtEffTo.Text & "','" & Request.UserHostAddress & "','',GETDATE(),'" & TxtParent.Text & "' )")
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
                    objfun.TextBoxDisable(TxtShortDesc, TxtLongDesc, TxtEffFrom, TxtEffTo)
                    TextBoxBlank()
                    'TextParentDisable()
                    'LoadGridParent()
                End If
            End If
        ElseIf CmdAdd.Text = "Add" Then
            TextParentEnable()
            TextBoxBlank()
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtShortDesc)
            objfun.CheckAddEnableDisable(CmdAdd, CmdEdit, CmdDelete, CmdClose, CmdSearch)
            'ButtonValidationEnable(CmdAdd, CmdEdit, CmdDelete)
            objfun.TextBoxEnable(TxtShortDesc, TxtLongDesc, TxtEffFrom, TxtEffTo)
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
        If TxtShortDesc.Text <> "" And TxtLongDesc.Text = "" Then
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtLongDesc)
        ElseIf TxtShortDesc.Text <> "" And TxtLongDesc.Text <> "" And TxtEffFrom.Text = "" Then
            'TxtCode.Text = Left(TxtLongDesc.Text, 3) & Genrate()
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtEffFrom)
        ElseIf TxtShortDesc.Text <> "" And TxtLongDesc.Text <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text = "" Then
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtEffTo)
        ElseIf TxtShortDesc.Text <> "" And TxtLongDesc.Text <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text <> "" Then
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(CmdAdd)
        End If
    End Sub
    '    If CmdAdd.Text = "Save" And objfun.objfun.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = True Then
    '        'If TxtCode.Text = "" Then
    '        '    TxtCode.Text = Left(TxtLongDesc.Text, 3) & Genrate()
    '        'End If
    '        SqlPass = "SELECT CASE Catg WHEN '' THEN 'X' ELSE Catg END  FROM JCT_DMS_Master_Category  WHERE catg='" & Trim(TxtCode.Text) & "' AND parentcatg='" & Trim(Me.TxtParent.Text) & "' and STATUS<>'D'"
    '        If objfun.SelectRecord(SqlPass) = True Then
    '            FMsg.CssClass = "errormsg"
    '            FMsg.Message = "Record Already Exists.."
    '            FMsg.Display()
    '        Else
    '            SqlPass = "INSERT INTO JCT_DMS_Master_Category (CompanyCode,EmpCode, Catg ,ShortDesc , LongDesc ,EffFrom, EffTo,Host_Ip, Status , Entry_Time,ParentCatg) VALUES ('" & Session("CompanyCode") & "','" & Session("Empcode") & "',UPPER('" & (Trim(Me.TxtCode.Text) & "'),UPPER('" & Trim(Me.TxtShortDesc.Text) & "'),UPPER('" & Trim(Me.TxtLongDesc.Text) & "'),'" & TxtEffFrom.Text & "' ,'" & TxtEffTo.Text & "','" & Request.UserHostAddress & "','',GETDATE(),'" & TxtParent.Text & "' )")
    '            If objfun.InsertRecord(SqlPass) = False Then
    '                System.Threading.Thread.Sleep(1200)
    '                Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
    '                FMsg.CssClass = "errormsg"
    '                FMsg.Message = "Transaction not Commited"
    '                FMsg.Display()
    '            Else
    '                System.Threading.Thread.Sleep(1200)
    '                Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
    '                FMsg.CssClass = "errormsg"
    '                FMsg.Message = "Records Added Succesfully"
    '                FMsg.Display()
    '                objfun.CheckAddEnableDisable(CmdAdd, CmdEdit, CmdDelete, CmdClose, CmdSearch)
    '                objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
    '                objfun.TextBoxDisable(TxtShortDesc, TxtLongDesc, TxtEffFrom, TxtEffTo)
    '                TextBoxBlank()
    '                TextParentDisable()
    '                LoadGridParent()
    '            End If
    '        End If
    '    ElseIf CmdAdd.Text = "Add" Then
    '        TextParentEnable()
    '        TextBoxBlank()
    '        Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
    '        Script.SetFocus(TxtShortDesc)
    '        objfun.CheckAddEnableDisable(CmdAdd, CmdEdit, CmdDelete, CmdClose, CmdSearch)
    '        objfun.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDelete)
    '        objfun.TextBoxEnable(TxtShortDesc, TxtLongDesc, TxtEffFrom, TxtEffTo)
    '    ElseIf CmdAdd.Text = "Save" And objfun.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = False Then
    '        System.Threading.Thread.Sleep(1200)
    '        Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
    '        FMsg.CssClass = "errormsg"
    '        FMsg.Message = "Effective To Should be Greater than Effective From"
    '        FMsg.Display()
    '        Panel2.Visible = False
    '    End If
    '    '-----------------------------------------
    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If TxtShortDesc.Text <> "" And TxtLongDesc.Text = "" Then
    '        Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
    '        Script.SetFocus(TxtLongDesc)
    '    ElseIf TxtShortDesc.Text <> "" And TxtLongDesc.Text <> "" And TxtEffFrom.Text = "" Then
    '        'TxtCode.Text = Left(TxtLongDesc.Text, 3) & Genrate()
    '        Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
    '        Script.SetFocus(TxtEffFrom)
    '    ElseIf TxtShortDesc.Text <> "" And TxtLongDesc.Text <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text = "" Then
    '        Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
    '        Script.SetFocus(TxtEffTo)
    '    ElseIf TxtShortDesc.Text <> "" And TxtLongDesc.Text <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text <> "" Then
    '        Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
    '        Script.SetFocus(CmdAdd)
    '    End If
    'End Sub

    '--------------------------------------------------------------




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
        TxtParent.Text = Nothing
        TxtCode.Text = Nothing
        TxtShortDesc.Text = Nothing
        TxtLongDesc.Text = Nothing
        TxtEffFrom.Text = Nothing
        TxtEffTo.Text = Nothing
    End Sub

    Protected Sub CmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        TextParentDisable()
        If CmdEdit.Text = "Update" And objfun.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = True Then
            SqlPass = "UPDATE JCT_DMS_Master_Category  SET STATUS='D' ,ENTRY_TIME=GETDATE() WHERE   catg=UPPER('" & Trim(Me.TxtCode.Text) & "')"

            If objfun.UpdateRecord(SqlPass) = False Then
                System.Threading.Thread.Sleep(1200)
                Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Update Transaction not Commited"
                FMsg.Display()
            Else
                SqlPass = "INSERT INTO JCT_DMS_Master_Category (CompanyCode,EmpCode, Catg ,ShortDesc , LongDesc ,EffFrom, EffTo,Host_Ip, Status , Entry_Time,ParentCatg) VALUES ('" & Session("CompanyCode") & "','" & Session("Empcode") & "',UPPER('" & (Trim(Me.TxtCode.Text) & "'),UPPER('" & Trim(Me.TxtShortDesc.Text) & "'),UPPER('" & Trim(Me.TxtLongDesc.Text) & "'),'" & TxtEffFrom.Text & "' ,'" & TxtEffTo.Text & "','" & Request.UserHostAddress & "','',GETDATE(),'" & TxtParent.Text & "' )")
                If objfun.InsertRecord(SqlPass) = True Then
                    System.Threading.Thread.Sleep(1200)
                    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Updated Record Succesfully"
                    FMsg.Display()
                    objfun.CheckEditEnableDisable(CmdEdit, CmdAdd, CmdDelete, CmdClose, CmdSearch)
                    objfun.TextBoxDisable(TxtShortDesc, TxtLongDesc, TxtEffFrom, TxtEffTo)
                    objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
                    TextBoxBlank()
                    LoadGridParent()
                Else
                    objfun.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDelete)
                    System.Threading.Thread.Sleep(1200)
                    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Update Transaction not Commited"
                    FMsg.Display()
                    SqlPass = "UPDATE JCT_DMS_Master_Category  SET  STATUS='',ENTRY_TIME=GETDATE() WHERE DEPT_CODE=UPPER('" & (Trim(Me.TxtCode.Text) & "') ")
                    objfun.UpdateRecord(SqlPass)
                    objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
                    LoadGridParent()
                End If

            End If

        ElseIf CmdEdit.Text = "Edit" Then

            objfun.TextBoxEnable(TxtShortDesc, TxtLongDesc, TxtEffFrom, TxtEffTo)
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtShortDesc)
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
            objfun.TextBoxDisable(TxtShortDesc, TxtLongDesc, TxtEffFrom, TxtEffTo)
            TextBoxBlank()
        End If

    End Sub

    Protected Sub CmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        TextParentDisable()
        objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
        If Trim(Me.TxtCode.Text) <> "" And Trim(Me.TxtShortDesc.Text) <> "" And Trim(Me.TxtLongDesc.Text) <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text <> "" Then

            If CmdDelete.Text = "Delete" Then
                SqlPass = "SELECT DISTINCT ParentCatg + Catg   FROM JCTDEV..Jct_Epor_Master_Employee WHERE ParentCatg + Catg=UPPER('" & Trim(Me.TxtParent.Text) & Trim(Me.TxtCode.Text) & "') AND STATUS='A' "
                If objfun.CheckRecordExistInTransaction(SqlPass) = False Then

                    SqlPass = "UPDATE JCT_DMS_Master_Category  SET  STATUS='D' ,ENTRY_TIME=GETDATE() WHERE ParentCatg + Catg=UPPER('" & Trim(Me.TxtParent.Text) & Trim(Me.TxtCode.Text) & "')"

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
                        objfun.TextBoxDisable(TxtShortDesc, TxtLongDesc, TxtEffFrom, TxtEffTo)
                        objfun.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDelete)
                        TextBoxBlank()
                        LoadGridParent()
                    End If
                Else
                    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "This Record Used In Transactions Record So Please Delete from Transaction "
                    FMsg.Display()
                End If
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
        TxtParent.Enabled = True
    End Sub

    Protected Sub TextParentDisable()
        TxtParent.Enabled = False
    End Sub

    Protected Sub CmdFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFirst.Click
        If MaxRows <= 0 Then
            SqlPass = "SELECT   [Code]=catg,Parentcatg , [Short Desc]=ShortDesc,[Long Desc]=LONGDESC ,EffFrom,EffTo from JCTDEV..JCT_DMS_Master_Category  WHERE status<>'D'  "
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
        If MaxRows <= 0 Then
            SqlPass = "SELECT   [Code]=catg,Parentcatg , [Short Desc]=ShortDesc,[Long Desc]=LONGDESC ,EffFrom,EffTo from JCTDEV..JCT_DMS_Master_Category  WHERE status<>'D'  "
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

        Me.GrdHelp.SelectedIndex = Me.GrdHelp.SelectedIndex + 1
    End Sub

    Protected Sub CmdPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrevious.Click
        If MaxRows <= 0 Then
            SqlPass = "SELECT   [Code]=catg,Parentcatg , [Short Desc]=ShortDesc,[Long Desc]=LONGDESC ,EffFrom,EffTo from JCTDEV..JCT_DMS_Master_Category  WHERE status<>'D'  "
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
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.SelectedIndex - 1
    End Sub

    Protected Sub CmdLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdLast.Click
        If MaxRows <= 0 Then
            SqlPass = "SELECT   [Code]=catg,Parentcatg , [Short Desc]=ShortDesc,[Long Desc]=LONGDESC ,EffFrom,EffTo from JCTDEV..JCT_DMS_Master_Category  WHERE status<>'D'  "
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        Navigation(MaxRows - 1)
        ViewState("Count") = MaxRows - 1
        CmdLast.Enabled = False
        CmdNext.Enabled = False
        CmdPrevious.Enabled = True
        CmdFirst.Enabled = True
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.Rows.Count() - 1
    End Sub

    Protected Sub Navigation(ByVal i As Integer)
        Try
            TxtCode.Text = Ds.Tables(0).Rows(i).Item(0)
            TxtParent.Text = Ds.Tables(0).Rows(i).Item(1)
            TxtShortDesc.Text = Ds.Tables(0).Rows(i).Item(2)
            TxtLongDesc.Text = Ds.Tables(0).Rows(i).Item(3)
            TxtEffFrom.Text = Ds.Tables(0).Rows(i).Item(4)
            TxtEffTo.Text = Ds.Tables(0).Rows(i).Item(5)
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

    Protected Sub Button1_Click1(sender As Object, e As System.EventArgs) Handles Button1.Click

    End Sub

    Protected Sub CmdAdd_Click1(sender As Object, e As System.EventArgs) Handles CmdAdd.Click

    End Sub

    Protected Sub TxtParent_TextChanged(sender As Object, e As System.EventArgs) Handles TxtParent.TextChanged

    End Sub
End Class
