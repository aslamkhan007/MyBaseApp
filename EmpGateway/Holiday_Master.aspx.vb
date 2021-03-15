Imports System.Threading.Thread
Imports System.Data
Imports System.Data.SqlClient
Partial Class Holiday_Master
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim Obj2 As Functions = New Functions
    Dim SqlPass As String
    Dim Dr As SqlDataReader
    Dim Ds As New DataSet
    Dim MaxRows As Integer
    Dim Exists As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        If Not Page.IsPostBack = True Then
            Obj2.CheckPermission(Obj2.GetCurrentPageName(), CmdAdd, CmdEdit, CmdDeActive, Session("Empcode"), "Employee Gateway")
            'Disable_Buttons(CmdSearch)
        End If

    End Sub

    Protected Sub Grdhelp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PopupExp.Commit(GrdHelp.SelectedRow.Cells(1).Text.ToString())
        Me.TxtSerial.Text = Replace(GrdHelp.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
        Me.TxtHolidayName.Text = Replace(GrdHelp.SelectedRow.Cells(2).Text.ToString, "&nbsp;", "")
        Me.TxtDate.Text = Replace(GrdHelp.SelectedRow.Cells(4).Text.ToString, "&nbsp;", "")
        Me.TxtEffFrom.Text = Replace(GrdHelp.SelectedRow.Cells(5).Text.ToString, "&nbsp;", "")
        Me.TxtEffTo.Text = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
        Me.TxtCode.Text = Replace(GrdHelp.SelectedRow.Cells(7).Text.ToString, "&nbsp;", "")
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
            e.Row.Attributes.Add("OnClick", Me.Page.ClientScript.GetPostBackEventReference(e.Row.Cells(0).FindControl("LinkButton3"), String.Empty))
        End If
    End Sub
    Protected Sub LoadGrid()
        If CmdAdd.Text <> "Save" Then
            SqlPass = "SELECT    ser_num as [Serial Number] , [Holiday Name]=Holidays,[Day]=Holiday_Day, [Holiday Date]=convert(varchar(11),Holiday_Date,101),convert(varchar(11),Eff_From,101) as [Eff. From],convert(varchar(11),Eff_To,101) as [Eff. To],Code from jctdev..jct_holiday_calender WHERE status<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0 order by ser_num "
            Obj2.FillGrid(SqlPass, GrdHelp)
        End If
    End Sub
    Protected Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '-----------------------------------------
        If CmdAdd.Text = "Save" And Obj2.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = True Then
            If TxtCode.Text = "" Then
                TxtCode.Text = Left(TxtHolidayName.Text, 3) & Genrate()
            End If

            SqlPass = "SELECT CASE CODE WHEN '' THEN 'X' ELSE EXP_CODE END  FROM jct_holiday_calenderWHERE  CODE='" & Trim(TxtCode.Text) & "' AND STATUS<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0"
            If Obj2.SelectRecord(SqlPass) = True Then
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Record Already Exists.."
                FMsg.Display()
            Else
                SqlPass = "INSERT INTO jct_holiday_calender(COMPANY_CODE,user_CODE,code,ser_num,holidays,holiday_date,holiday_day,EFF_FROM,EFF_TO,STATUS,created_dt) VALUES('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.TxtCode.Text & "'," & Trim(TxtSerial.Text) & ",'" & Replace(Trim(Me.TxtHolidayName.Text), "&", "and") & "','" & Me.TxtDate.Text & "',DATENAME(Weekday,'" & TxtDate.Text & "'),'" & TxtEffFrom.Text & "' ,'" & TxtEffTo.Text & "','A',GETDATE())"
                If Obj2.InsertRecord(SqlPass) = False Then
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Transaction not Commited"
                    FMsg.Display()
                Else
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Records Added Succesfully"
                    FMsg.Display()
                    Obj2.CheckAddEnableDisable(CmdAdd, CmdEdit, CmdDeActive, CmdClose, CmdSearch)
                    Obj2.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDeActive)
                    Obj2.TextBoxDisable(TxtHolidayName, TxtSerial, TxtEffFrom, TxtEffTo, TxtDate, TxtDate)
                    TextBoxBlank()
                    LoadGrid()
                End If
            End If
        ElseIf CmdAdd.Text = "Add" Then
            TextBoxBlank()
            Obj2.CheckAddEnableDisable(CmdAdd, CmdEdit, CmdDeActive, CmdClose, CmdSearch)
            Obj2.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDeActive)
            Obj2.TextBoxEnable(TxtHolidayName, TxtSerial, TxtEffFrom, TxtEffTo, TxtDate, TxtDate)
            SetFocus(TxtHolidayName)
        ElseIf CmdAdd.Text = "Save" And Obj2.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = False Then
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Effective To Should be Greater than Effective From"
            FMsg.Display()
            Panel2.Visible = False
        End If
        '-----------------------------------------
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If TxtHolidayName.Text <> "" And TxtEffFrom.Text = "" Then
            If Trim(TxtCode.Text) = "" Then
                TxtCode.Text = Left(TxtHolidayName.Text, 3) & Genrate()
            End If
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtEffFrom)
        ElseIf TxtHolidayName.Text <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text = "" Then
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(TxtEffTo)
        ElseIf TxtHolidayName.Text <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text <> "" Then
            Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
            Script.SetFocus(CmdAdd)
        End If
    End Sub

    Protected Function Genrate() As Integer
        Dim FrmName As String = "HOLIDAYS", Type As String = "HLD", Modules As String = "Employee Gateway"
        SqlPass = "SELECT MAX(SERIAL) FROM JCTGEN..JCT_COMMON_SERIAL_MASTER WHERE COMPANY_CODE='" & Session("Companycode") & "' AND FRMNAME='" & FrmName & "' AND  TYPE='" & Type & "' AND MODULE ='" & Modules & "'"


        If Obj2.AutoGenrate(SqlPass) = 201 Then
            SqlPass = "INSERT INTO JCTGEN..JCT_COMMON_SERIAL_MASTER(COMPANY_CODE,FRMNAME,SERIAL,TYPE,MODULE)VALUES('" & Session("Companycode") & "','" & FrmName & "','101','" & Type & "','" & Modules & "' )"
            If (Obj2.InsertRecord(SqlPass) = True) Then
                TxtCode.Text = 201
            End If
        Else
            SqlPass = "UPDATE JCTGEN..JCT_COMMON_SERIAL_MASTER SET SERIAL= SERIAL +1  WHERE COMPANY_CODE='" & Session("Companycode") & "' AND FRMNAME='" & FrmName & "' AND  TYPE='" & Type & "' AND MODULE ='" & Modules & "'  "
            Obj2.UpdateRecord(SqlPass)
        End If
        SqlPass = "SELECT MAX(SERIAL)-1 FROM JCTGEN..JCT_COMMON_SERIAL_MASTER WHERE COMPANY_CODE='" & Session("Companycode") & "' AND FRMNAME='" & FrmName & "' AND  TYPE='" & Type & "' AND MODULE ='" & Modules & "'"
        Genrate = Obj2.AutoGenrate(SqlPass)
    End Function

    Protected Sub CmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadGrid()
    End Sub

    Public Sub TextBoxBlank()
        TxtCode.Text = Nothing
        TxtHolidayName.Text = Nothing
        TxtEffFrom.Text = Nothing
        TxtEffTo.Text = Nothing
        Me.TxtSerial.Text = Nothing
        Me.TxtDate.Text = Nothing
    End Sub

    Protected Sub CmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If CmdEdit.Text = "Update" And Obj2.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = True Then

            SqlPass = "UPDATE jct_holiday_calender SET STATUS='D' ,CREATED_DT=GETDATE() WHERE   CODE=UPPER('" & (Trim(Me.TxtCode.Text) & "')")

            If Obj2.UpdateRecord(SqlPass) = False Then
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Update Transaction not Commited"
                FMsg.Display()
            Else
                SqlPass = "INSERT INTO jct_holiday_calender(COMPANY_CODE,user_CODE,code,ser_num,holidays,holiday_date,holiday_day,EFF_FROM,EFF_TO,STATUS,created_dt) VALUES('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.TxtCode.Text & "'," & Trim(TxtSerial.Text) & ",'" & Replace(Trim(Me.TxtHolidayName.Text), "&", "and") & "','" & Me.TxtDate.Text & "',DATENAME(Weekday,'" & TxtDate.Text & "'),'" & TxtEffFrom.Text & "' ,'" & TxtEffTo.Text & "','A',GETDATE())"
                If Obj2.InsertRecord(SqlPass) = True Then
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Updated Record Succesfully"
                    FMsg.Display()
                    Obj2.CheckEditEnableDisable(CmdEdit, CmdAdd, CmdDeActive, CmdClose, CmdSearch)
                    Obj2.TextBoxDisable(TxtHolidayName, TxtSerial, TxtEffFrom, TxtEffTo, TxtDate, TxtDate)
                    Obj2.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDeActive)
                    TextBoxBlank()
                    LoadGrid()
                Else
                    Obj2.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDeActive)
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Update Transaction not Commited"
                    FMsg.Display()
                    SqlPass = "UPDATE jct_holiday_calender SET STATUS='A' WHERE   CODE=UPPER('" & (Trim(Me.TxtCode.Text) & "')")
                    Obj2.UpdateRecord(SqlPass)
                    Obj2.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDeActive)
                    LoadGrid()
                End If

            End If

        ElseIf CmdEdit.Text = "Edit" Then
            Obj2.TextBoxEnable(TxtHolidayName, TxtSerial, TxtEffFrom, TxtEffTo, TxtDate, TxtDate)
            Obj2.CheckEditEnableDisable(CmdEdit, CmdAdd, CmdDeActive, CmdClose, CmdSearch)
            Obj2.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDeActive)

        ElseIf CmdEdit.Text = "Update" And Obj2.CheckDateFromTo(TxtEffFrom.Text, TxtEffTo.Text) = False Then
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Effective To Should be Greater than Effective From"
            FMsg.Display()
        End If

    End Sub

    Protected Sub CmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If CmdClose.Text = "Close" Then
            Response.Redirect("Default.aspx")
        Else
            Obj2.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDeActive)
            Obj2.CheckCloseEnableDisable(CmdClose, CmdAdd, CmdEdit, CmdDeActive, CmdSearch)
            Obj2.TextBoxDisable(TxtHolidayName, TxtSerial, TxtEffFrom, TxtEffTo, TxtDate, TxtDate)
            TextBoxBlank()
        End If

    End Sub
    Protected Sub CmdDeActive_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Obj2.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDeActive)
        If Trim(Me.TxtCode.Text) <> "" And Trim(Me.TxtHolidayName.Text) <> "" And TxtEffFrom.Text <> "" And TxtEffTo.Text <> "" Then

            If CmdDeActive.Text = "DeActive" Then

                'SqlPass = "SELECT DISTINCT CATEGORY   FROM JCTDEV..JCT_EPOR_MASTER_DESIGNATION WHERE CATEGORY=UPPER('" & Trim(Me.TxtShortDesc.Text) & "') AND STATUS='A' "
                'If CheckRecordExistInTransaction(SqlPass) = False Then
                SqlPass = "UPDATE jct_holiday_calender SET  STATUS='D' ,CREATED_DT=GETDATE() WHERE    CODE=UPPER('" & (Trim(Me.TxtCode.Text) & "') ")

                If Obj2.UpdateRecord(SqlPass) = False Then
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Dleted Transaction not Commited"
                    FMsg.Display()
                Else
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Record DeActived Succesfully"
                    FMsg.Display()
                    Obj2.CheckDeActiveEnableDisable(CmdDeActive, CmdAdd, CmdEdit, CmdClose)
                    Obj2.TextBoxDisable(TxtHolidayName, TxtSerial, TxtEffFrom, TxtEffTo, TxtDate, TxtDate)
                    Obj2.ButtonValidationDisable(CmdAdd, CmdEdit, CmdDeActive)
                    TextBoxBlank()
                    LoadGrid()
                End If
                'Else
                '    Me.UpdateProgress1.AssociatedUpdatePanelID = Add.ID
                '    FMsg.CssClass = "errormsg"
                '    FMsg.Message = "This Record Used In Transactions Record So Please DeActive from Designation "
                '    FMsg.Display()
                'End If

            End If
        Else
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Fields value required"
            FMsg.Display()
        End If

    End Sub
    Protected Sub CmdFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFirst.Click
        If MaxRows <= 0 Then
            SqlPass = "SELECT    ser_num as [Serial Number] , [Holiday Name]=Holidays,[Day]=Holiday_Day, [Holiday Date]=Holiday_Date,Eff_From,Eff_To,CODE from jctdev..jct_holiday_calender WHERE status<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0 order by ser_num"
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
            SqlPass = "SELECT    ser_num as [Serial Number] , [Holiday Name]=Holidays,[Day]=Holiday_Day, [Holiday Date]=Holiday_Date,Eff_From,Eff_To from jctdev..jct_holiday_calender WHERE status<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0 order by ser_num "
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
            SqlPass = "SELECT    ser_num as [Serial Number] , [Holiday Name]=Holidays,[Day]=Holiday_Day, [Holiday Date]=Holiday_Date,Eff_From,Eff_To from jctdev..jct_holiday_calender WHERE status<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0 order by ser_num "
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
            SqlPass = "SELECT    ser_num as [Serial Number] , [Holiday Name]=Holidays,[Day]=Holiday_Day, [Holiday Date]=Holiday_Date,Eff_From,Eff_To,CODE from jctdev..jct_holiday_calender WHERE status<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0 order by ser_num "
            AdapterRecord(SqlPass, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        Navigation(MaxRows - 1)
        ViewState("Count") = MaxRows - 1
        CmdLast.Enabled = False
        CmdNext.Enabled = False
        CmdFirst.Enabled = True
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.Rows.Count() - 1
    End Sub
    Protected Sub Navigation(ByVal i As Integer)
        Try
            TxtSerial.Text = Ds.Tables(0).Rows(i).Item(0)
            TxtHolidayName.Text = Ds.Tables(0).Rows(i).Item(1)
            TxtDate.Text = Ds.Tables(0).Rows(i).Item(3)
            TxtEffFrom.Text = Ds.Tables(0).Rows(i).Item(4)
            TxtEffTo.Text = Ds.Tables(0).Rows(i).Item(5)
            TxtCode.Text = Ds.Tables(0).Rows(i).Item(6)
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
    Protected Sub CmdAmendment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAmendment.Click
    End Sub
    Protected Sub CmdAuthorize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAuthorize.Click
    End Sub
End Class