Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.Text
Imports System.Web.UI

Public Module Message1
    Dim SqlPass As String
    Dim Obj As Connection = New Connection
    Dim Cmd As New SqlCommand
    ' Public Insert As Boolean = False, Update As Boolean = False
    Dim Dr As SqlDataReader

    Public Function CheckNullSpace(ByVal ObjItem As Object) As Object
        If ObjItem Is System.DBNull.Value Then
            CheckNullSpace = ""
        Else
            CheckNullSpace = ObjItem
        End If
    End Function
    Public Function GetCurrentPageName() As String
        Dim SPath As String = System.Web.HttpContext.Current.Request.Url.AbsolutePath
        Dim OInfo As System.IO.FileInfo = New System.IO.FileInfo(SPath)
        Dim SRet As String = OInfo.Name
        Return SRet
    End Function
    Public Sub Disable_Buttons(ByVal btn As LinkButton)
        btn.Enabled = False
        btn.CssClass = "buttondisable"
    End Sub

    Public Sub Enable_Buttons(ByVal btn As LinkButton)
        btn.Enabled = True
        btn.CssClass = "buttonc"
    End Sub

    Public Sub CheckAddEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton, ByVal Button5 As LinkButton, ByVal Button6 As LinkButton, ByVal Button7 As LinkButton)
        If Button1.Text = "Add" Then
            Button1.Text = "Save"
            Disable_Buttons(Button2)
            Disable_Buttons(Button3)
            Disable_Buttons(Button5)
            Disable_Buttons(Button6)
            Disable_Buttons(Button7)
            Button4.Text = "Cancel"
        Else : Button1.Text = "Save"
            Button1.Text = "Add"
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button5)
            Enable_Buttons(Button6)
            Enable_Buttons(Button7)
            Button4.Text = "Close"
        End If
    End Sub

    Public Sub CheckCloseEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton, ByVal Button5 As LinkButton, ByVal Button6 As LinkButton, ByVal Button7 As LinkButton)

        If Button1.Text = "Cancel" Then

            Button1.Text = "Close"
            Button2.Text = "Add"

            If Trim(Button6.Text) = "Amendment" Or Trim(Button6.Text) = "Amendment." Or Trim(Button3.Text) = "Update" Then
                Button6.Text = "Amendment"
                Button3.Text = "Edit"
            End If
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button4)
            Enable_Buttons(Button5)
            Enable_Buttons(Button6)
            Enable_Buttons(Button7)
        Else
            Button1.Text = "Close"
            Button2.Text = "Add"

            If Trim(Button6.Text) = "Amendment" Or Trim(Button6.Text) = "Amendment." Or Trim(Button3.Text) = "Update" Then
                Button6.Text = "Amendment"
                Button3.Text = "Edit"
            End If

            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button4)
            Enable_Buttons(Button5)
            Enable_Buttons(Button6)
            Enable_Buttons(Button7)
        End If

    End Sub

    Public Sub CheckEditEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton, ByVal Button5 As LinkButton, ByVal Button6 As LinkButton, ByVal Button7 As LinkButton)

        If Button1.Text = "Edit" Then
            Button1.Text = "Update"
            Disable_Buttons(Button2)
            Disable_Buttons(Button3)
            Disable_Buttons(Button5)
            Disable_Buttons(Button6)
            Disable_Buttons(Button7)
            Button4.Text = "Cancel"

        Else : Button1.Text = "Update"
            Button1.Text = "Edit"
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button5)
            Enable_Buttons(Button6)
            Enable_Buttons(Button7)
            Button4.Text = "Close"
        End If

    End Sub
    Public Sub CheckAmendmentEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton, ByVal Button5 As LinkButton, ByVal Button6 As LinkButton, ByVal Button7 As LinkButton)

        If Button1.Text = "Amendment" Then
            Button1.Text = "Amendment."
            Disable_Buttons(Button2)
            Disable_Buttons(Button3)
            Disable_Buttons(Button5)
            Disable_Buttons(Button6)
            Disable_Buttons(Button7)
            Button4.Text = "Cancel"

        Else : Button1.Text = "Amendment."
            Button1.Text = "Amendment"
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button5)
            Enable_Buttons(Button6)
            Enable_Buttons(Button7)
            Button4.Text = "Close"
        End If

    End Sub
    Public Sub CheckDeActiveEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton, ByVal Button5 As LinkButton, ByVal Button6 As LinkButton, ByVal Button7 As LinkButton)

        If Button1.Text = "DeActive" Then
            Button1.Text = "DeActive"
            Button2.Text = "Add"
            Button3.Text = "Edit"
            Button4.Text = "Close"
            Enable_Buttons(Button1)
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button4)

        End If
    End Sub

    Public Sub CheckDeleteEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton)

        If Button1.Text = "Delete" Then
            Button1.Text = "Delete"
            Button2.Text = "Add"
            Button3.Text = "Edit"
            Button4.Text = "Close"
            Enable_Buttons(Button1)
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button4)
        End If
    End Sub

    Public Sub CheckPermission(ByVal FrmName As String, ByVal BtnAdd As LinkButton, ByVal BtnEdit As LinkButton, ByVal BtnDeActive As LinkButton, ByVal Empcode As String, ByVal ModuleName As String)
        Try
            SqlPass = "SELECT RIGHT(LTRIM(RTRIM(b.page_name)),LEN(b.page_name)-2),C.action FROM production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c WHERE a.action<>'load' AND b.module=a.module AND a.mnuname=b.mnuname AND C.mnuname=A.mnuname  AND a.action=c.action AND a.module=c.module AND a.module= '" & ModuleName & "' AND c.uname='" & Empcode & "' AND RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2)='" & FrmName & "'   union    select RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..role_module_menus_mapping c,production..role_user_mapping d where a.action<>'load' AND b.module=a.module AND a.mnuname=b.mnuname AND a.action=c.action AND c.role=d.role AND C.mnuname=A.mnuname AND a.module=c.module AND a.module= '" & ModuleName & "' AND  d.uname='" & Empcode & "' AND RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2)='" & FrmName & "' "
            Dr = Obj.FetchReader(SqlPass)

            If Dr.HasRows = True Then

                While Dr.Read()
                    If Dr(1).ToString = "Add" Then
                        Enable_Buttons(BtnAdd)
                    ElseIf Dr(1).ToString = "Edit" Then
                        Enable_Buttons(BtnEdit)
                    ElseIf (Dr(1).ToString = "DeActive") Or LCase(Dr(1).ToString) = "delete" Then
                        Enable_Buttons(BtnDeActive)
                    End If
                End While

            End If
        Catch ex As Exception

        Finally

            Dr.Close()
            Obj.ConClose()

        End Try

    End Sub
    Public Sub CheckPermission(ByVal FrmName As String, ByVal BtnAdd As LinkButton, ByVal BtnEdit As LinkButton, ByVal BtnDeActive As LinkButton, ByVal BtnAmendment As LinkButton, ByVal BtnAuthorize As LinkButton, ByVal Empcode As String, ByVal ModuleName As String)
        Try
            SqlPass = "SELECT RIGHT(LTRIM(RTRIM(b.page_name)),LEN(b.page_name)-2),C.action FROM production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c WHERE a.action<>'load' AND b.module=a.module AND a.mnuname=b.mnuname AND C.mnuname=A.mnuname  AND a.action=c.action AND a.module=c.module AND a.module='" & ModuleName & "' AND c.uname='" & Empcode & "' AND RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2)='" & FrmName & "'   union    select RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..role_module_menus_mapping c,production..role_user_mapping d where a.action<>'load' AND b.module=a.module AND a.mnuname=b.mnuname AND a.action=c.action AND c.role=d.role AND C.mnuname=A.mnuname AND a.module=c.module AND a.module='" & ModuleName & "' AND  d.uname='" & Empcode & "' AND RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2)='" & FrmName & "' "
            Dr = Obj.FetchReader(SqlPass)

            If Dr.HasRows = True Then

                While Dr.Read()
                    If Dr(1).ToString = "Add" Then
                        Enable_Buttons(BtnAdd)
                    ElseIf Dr(1).ToString = "Edit" Then
                        Enable_Buttons(BtnEdit)
                    ElseIf Dr(1).ToString = "Amendment" Then
                        Enable_Buttons(BtnAmendment)
                    ElseIf Dr(1).ToString = "Authorize" Then
                        Enable_Buttons(BtnAuthorize)
                    ElseIf (Dr(1).ToString = "DeActive") Or LCase(Dr(1).ToString) = "delete" Then
                        Enable_Buttons(BtnDeActive)
                    End If
                End While

            End If
        Catch ex As Exception

        Finally

            Dr.Close()
            Obj.ConClose()

        End Try

    End Sub

    Public Sub DisableReqdField(ByVal Ctr1 As RequiredFieldValidator, ByVal CallOut As AjaxControlToolkit.ValidatorCalloutExtender)

        Ctr1.Enabled = False
        CallOut.Enabled = False

    End Sub

    Public Sub EnableReqdField(ByVal Ctrl As RequiredFieldValidator, ByVal CallOut As AjaxControlToolkit.ValidatorCalloutExtender)

        Ctrl.Enabled = True
        CallOut.Enabled = True

    End Sub


    Public Sub Alert(ByVal Message As String)

        ' Cleans the message to allow single quotation marks 
        Dim CleanMessage As String = Message.Replace("'", "'")
        Dim Script As String = "<script language=JavaScript>" & "alert('" + CleanMessage + "')" & "</script>"

        ' Gets the executing web page 
        Dim Page As Page = TryCast(HttpContext.Current.CurrentHandler, Page)

        ' Checks if the handler is a Page and that the script isn't allready on the Page 
        If Page IsNot Nothing AndAlso Not Page.ClientScript.IsClientScriptBlockRegistered("alert") Then
            Page.ClientScript.RegisterClientScriptBlock(GetType(Message1), "alert", Script)
        End If

    End Sub

    Public Sub AddBlurAtt(ByVal Cntrl As Control)

        If Cntrl.Controls.Count > 0 Then
            For Each ChildControl As Control In Cntrl.Controls
                AddBlurAtt(ChildControl)
            Next
        End If
        If Cntrl.[GetType]() Is GetType(TextBox) Then
            Dim TempTextBox As TextBox = DirectCast(Cntrl, TextBox)
            TempTextBox.Attributes.Add("onFocus", "DoFocus(this);")
            TempTextBox.Attributes.Add("onBlur", "DoBlur(this);")
        End If

    End Sub

    Public Sub FillGrid(ByVal Sql As String, ByVal Grd As GridView)

        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sql, Obj.Connection())
        Try
            Dim ds As DataSet = New DataSet()
            Da.SelectCommand.CommandTimeout = 0
            Da.Fill(ds)
            Grd.DataSource = ds
            Grd.DataBind()
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Function InsertRecord(ByVal Sql As String) As Boolean

        'Code Causing Errors

        Dim Tran As SqlTransaction
        If Obj.Connection.State = ConnectionState.Closed Then
            Obj.Connection.Open()
        End If
        Tran = Obj.Connection.BeginTransaction
        Try
            Cmd = New SqlCommand(Sql, Obj.Connection)
            Cmd.Transaction = Tran
            Cmd.ExecuteNonQuery()
            Tran.Commit()
            InsertRecord = True 'Function
            '  Insert = True ' Variabale
        Catch ex As Exception
            Tran.Rollback()
            InsertRecord = False
            '  Insert = False
        End Try

       

    End Function



    Public Function UpdateRecord(ByVal Sql As String) As Boolean

        Dim Tran As SqlTransaction
        If Obj.Connection.State = ConnectionState.Closed Then
            Obj.Connection.Open()
        End If
        Tran = Obj.Connection.BeginTransaction
        Try
            Cmd = New SqlCommand(Sql, Obj.Connection)
            Cmd.Transaction = Tran
            Cmd.ExecuteNonQuery()
            Tran.Commit()
            UpdateRecord = True 'Function
            'Update = True ' Variabale
        Catch ex As Exception
            Tran.Rollback()
            UpdateRecord = False
            ' Update = False
        End Try

    End Function

    Public Function SelectRecord(ByVal Sql As String) As Boolean
        Try
            Dr = Obj.FetchReader(Sql)
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Dr.Item(0) = "X" Or Dr.Item(0) = "NULL" Then
                        SelectRecord = False
                    Else
                        SelectRecord = True
                    End If
                End While
            Else
                SelectRecord = False
            End If
        Catch ex As Exception
        Finally
            Dr.Close()
            Obj.ConClose()
        End Try
    End Function

    Public Function FetchRecords(ByVal sql As String) As DataTable
        Dim dt As DataTable = New DataTable()
        Try
            If Obj.Connection.State = ConnectionState.Closed Then
                Obj.Connection.Open()
            End If
            Dim da As SqlDataAdapter = New SqlDataAdapter(sql, Obj.Connection)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Return dt
        Finally

        End Try

    End Function

    Public Function FetchValue(ByVal sql As String) As Object
        Dim val As Object = New Object
        Dim dtr As DataTableReader = New DataTableReader(FetchRecords(sql))
        If dtr.HasRows Then
            dtr.Read()
            val = dtr(0)
        End If
        Return val
    End Function

    Public Function CheckDateFromTo(ByVal EffFrom As String, ByVal EffTo As String) As Boolean

        Dim SqlPass = "SELECT  DateDiff(DD,'" & EffFrom & "','" & EffTo & "') as Difference"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Dr.Item(0) >= 0 Then
                        CheckDateFromTo = True
                    Else
                        CheckDateFromTo = False
                    End If
                End While
            End If
        Catch ex As Exception
        Finally
            Dr.Close()
            Obj.ConClose()
        End Try

    End Function

    Public Sub ButtonValidationEnable(ByVal CmdAdd As LinkButton, ByVal CmdEdit As LinkButton, ByVal CmdDeActive As LinkButton)
        CmdAdd.CausesValidation = True
        CmdEdit.CausesValidation = True
        'CmdDeActive.CausesValidation = True
    End Sub
    Public Sub ButtonValidationEnable(ByVal CmdAdd As LinkButton, ByVal CmdEdit As LinkButton, ByVal CmdDeActive As LinkButton, ByVal CmdAmendment As LinkButton)
        CmdAdd.CausesValidation = True
        CmdEdit.CausesValidation = True
        CmdAmendment.CausesValidation = True
    End Sub
    Public Sub ButtonValidationDisable(ByVal CmdAdd As LinkButton, ByVal CmdEdit As LinkButton, ByVal CmdDeActive As LinkButton, ByVal CmdAmendment As LinkButton, ByVal CmdAuthorize As LinkButton)
        CmdAdd.CausesValidation = False
        CmdEdit.CausesValidation = False
        CmdDeActive.CausesValidation = False
        CmdAmendment.CausesValidation = False
        CmdAuthorize.CausesValidation = False
    End Sub
    Public Sub ButtonValidationDisable(ByVal CmdAdd As LinkButton, ByVal CmdEdit As LinkButton, ByVal CmdDeActive As LinkButton)
        CmdAdd.CausesValidation = False
        CmdEdit.CausesValidation = False
        CmdDeActive.CausesValidation = False
    End Sub
    Public Sub TextBoxEnable(ByVal Tetxbox1 As TextBox, ByVal Tetxbox2 As TextBox, ByVal Tetxbox3 As TextBox, ByVal Tetxbox4 As TextBox, ByVal Tetxbox5 As TextBox, ByVal Tetxbox6 As TextBox)
        Tetxbox1.Enabled = True
        Tetxbox2.Enabled = True
        Tetxbox3.Enabled = True
        Tetxbox4.Enabled = True
        Tetxbox5.Enabled = True
        Tetxbox6.Enabled = True
    End Sub
    Public Sub TextBoxDisable(ByVal Tetxbox1 As TextBox, ByVal Tetxbox2 As TextBox, ByVal Tetxbox3 As TextBox, ByVal Tetxbox4 As TextBox, ByVal Tetxbox5 As TextBox, ByVal Tetxbox6 As TextBox)
        Tetxbox1.Enabled = False
        Tetxbox2.Enabled = False
        Tetxbox3.Enabled = False
        Tetxbox4.Enabled = False
        Tetxbox5.Enabled = False
        Tetxbox6.Enabled = False
    End Sub
    Public Sub TextBoxEnable(ByVal Tetxbox1 As TextBox, ByVal Tetxbox2 As TextBox, ByVal Tetxbox3 As TextBox, ByVal Tetxbox4 As TextBox)
        Tetxbox1.Enabled = True
        Tetxbox2.Enabled = True
        Tetxbox3.Enabled = True
        Tetxbox4.Enabled = True
    End Sub
    Public Sub TextBoxDisable(ByVal Tetxbox1 As TextBox, ByVal Tetxbox2 As TextBox, ByVal Tetxbox3 As TextBox, ByVal Tetxbox4 As TextBox)
        Tetxbox1.Enabled = False
        Tetxbox2.Enabled = False
        Tetxbox3.Enabled = False
        Tetxbox4.Enabled = False
    End Sub

    Public Function AutoGenrate(ByVal Sqlpass As String) As Integer
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        AutoGenrate = Dr.Item(0) + 1
                    Else
                        AutoGenrate = 201
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            Obj.ConClose()
        End Try
    End Function

    Public Sub FillList(ByVal ddl As DropDownList, ByVal sql As String)
        'Dim cn As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand(sql, Obj.Connection)
        Obj.ConOpen()
        ddl.Items.Clear()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                Dim li As New ListItem
                li.Value = dr.Item(0)
                li.Text = dr.Item(1)
                ddl.Items.Add(li)
            End While
        End If
        Obj.ConClose()
    End Sub

    Public Sub TextBoxControl(ByVal ctrl As Control, ByVal prop As String)
        If Trim(LCase(prop)) = Trim(LCase("Empty")) Then
            If ctrl.[GetType]() Is GetType(TextBox) Then
                CType(ctrl, TextBox).Text = ""
            End If
        ElseIf Trim(LCase(prop)) = Trim(LCase("ReadOnlyTrue")) Then
            If ctrl.[GetType]() Is GetType(TextBox) Then
                CType(ctrl, TextBox).ReadOnly = True
            End If
        ElseIf Trim(LCase(prop)) = Trim(LCase("ReadOnlyFalse")) Then
            If ctrl.[GetType]() Is GetType(TextBox) Then
                CType(ctrl, TextBox).ReadOnly = False
            End If
        End If
        'If ctrl.[GetType]() Is GetType(TextBox) Then
        '    CType(ctrl, TextBox).Text = ""
        'End If
        For Each ctrl2 As Control In ctrl.Controls
            TextBoxControl(ctrl2, prop)
        Next
    End Sub


    Public Sub GetAddressType(ByVal ddl As DropDownList)
        ddl.Items.Add("Current")
        ddl.Items.Add("Permanent")
        ddl.Items.Add("Correspondence")
    End Sub

    Public Function CheckRecordExistInTransaction(ByVal Sql As String) As Boolean
        Try
            Dr = Obj.FetchReader(Sql)
            If Dr.HasRows = True Then
                While Dr.Read()
                    CheckRecordExistInTransaction = True
                End While
            Else
                CheckRecordExistInTransaction = False
            End If
        Catch ex As Exception
        Finally
            Dr.Close()
            Obj.ConClose()
        End Try
    End Function
    Public Function DeActiveRecord(ByVal Sql As String) As Boolean

        Dim Tran As SqlTransaction
        If Obj.Connection.State = ConnectionState.Closed Then
            Obj.Connection.Open()
        End If
        Tran = Obj.Connection.BeginTransaction
        Try
            Cmd = New SqlCommand(Sql, Obj.Connection)
            Cmd.Transaction = Tran
            Cmd.ExecuteNonQuery()
            Tran.Commit()
            DeActiveRecord = True 'Function
            '  Insert = True ' Variabale
        Catch ex As Exception
            Tran.Rollback()
            DeActiveRecord = False
            '  Insert = False
        End Try

    End Function

    Public Sub CheckAddEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton, ByVal Button5 As LinkButton)

        If Button1.Text = "Add" Then
            Button1.Text = "Save"
            Disable_Buttons(Button2)
            Disable_Buttons(Button3)
            Disable_Buttons(Button5)
            Button4.Text = "Cancel"

        Else : Button1.Text = "Save"
            Button1.Text = "Add"
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button5)
            Button4.Text = "Close"
        End If
    End Sub

    Public Sub CheckCloseEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton, ByVal Button5 As LinkButton)

        If Button1.Text = "Cancel" Then

            Button1.Text = "Close"
            Button2.Text = "Add"
            Button3.Text = "Edit"
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button4)
            Enable_Buttons(Button5)
        Else
            Button1.Text = "Close"
            Button2.Text = "Add"
            Button3.Text = "Edit"
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button4)
            Enable_Buttons(Button5)
        End If

    End Sub

    Public Sub CheckEditEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton, ByVal Button5 As LinkButton)

        If Button1.Text = "Edit" Then
            Button1.Text = "Update"
            Disable_Buttons(Button2)
            Disable_Buttons(Button3)
            Enable_Buttons(Button5)
            Button4.Text = "Cancel"

        Else : Button1.Text = "Update"
            Button1.Text = "Edit"
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button5)
            Button4.Text = "Close"
        End If

    End Sub

    Public Sub CheckDeActiveEnableDisable(ByVal Button1 As LinkButton, ByVal Button2 As LinkButton, ByVal Button3 As LinkButton, ByVal Button4 As LinkButton)

        If Button1.Text = "DeActive" Then
            Button1.Text = "DeActive"
            Button2.Text = "Add"
            Button3.Text = "Edit"
            Button4.Text = "Close"
            Enable_Buttons(Button1)
            Enable_Buttons(Button2)
            Enable_Buttons(Button3)
            Enable_Buttons(Button4)
        End If

    End Sub

    Public Function RuntimeCheckBox(ByVal Sqlpass As String) As System.String()

        Dim Cmd As SqlCommand = New SqlCommand(Sqlpass, Obj.Connection)
        Obj.ConOpen()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Obj.ConClose()
        Return Data.ToArray

    End Function

    'To save user hits on applications

    'Public Function RegAppHit(ByVal CompCode As String, ByVal User As String, ByVal AppName As String, ByVal HostIP As String) As Boolean
    '    Dim ob As Functions = New Functions
    '    Dim sql As String = "insert into jct_fap_application_hits (CompanyCode, UserCode, AppHit, PageHit, HitDT, HostIP) " & _
    '    "values('" & CompCode & "','" & User & "','" & AppName & "','" & GetCurrentPageName() & "',getdate(),'" & HostIP & "')"
    '    If ob.InsertRecord(sql) Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function

    Public Function AuthenticateUserPageWise(ByVal User As String, ByVal AppName As String, ByVal page As String) As Boolean
        Dim sql As String = "select 'X' from production..user_module_menus_mapping a inner join" & _
        "production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join " & _
        "jctdev..JCT_Menu_Form_Mapping c on b.mnuname=c.mnuname where a.module ='" & AppName & "' and uname= '" & User & _
        "' and page_name='" & page & "' " & _
        "union" & _
        "select 'X' from production..role_module_menus_mapping a inner join " & _
        "production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e " & _
        "on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.mnuname=c.mnuname where a.module ='" & _
        AppName & "' and uname='" & User & "' and page_name='" & page & "'"

        Return True

    End Function

    Public Function AuthenticateUserAtLogin(ByVal User As String, ByVal password As String) As Integer
        Dim sql As String = "select active from jct_login_emp where empcode = '" & User & "' and active = 'Y'"

        If CheckRecordExistInTransaction(sql) Then

            sql = "select empname  from jct_login_emp where empcode='" & user & "' and active = 'Y' and ((convert(varchar(8),dateofbirth,112)='" & Trim(password) & " ' and  new_pass is null)  or (new_pass is not null and new_pass=convert(varchar(30),convert(varbinary,'" & Trim(password) & "')))) "

            If CheckRecordExistInTransaction(sql) Then
                Return 2
            End If

            Return 1

        Else
            Return 0
        End If

    End Function

    Public Function Greet() As String

        If DateTime.Now.Hour < 12 Then
            Greet = "Good Morning"
        ElseIf DateTime.Now.Hour >= 12 And DateTime.Now.Hour < 16 Then
            Greet = "Good Afternoon"
        Else 'If DateTime.Now.Hour >= 16 And DateTime.Now.Hour < 24 Then
            Greet = "Good Evening"
        End If

    End Function

    Public Function CheckDateFromToIdentification(ByVal EffFrom As String, ByVal EffTo As String, ByVal Identification As String) As Boolean
        If Identification = "DAILY" Then

            If DateDiff(DateInterval.Day, CDate(EffFrom), CDate(EffTo)) + 1 = 1 Then
                CheckDateFromToIdentification = True
            Else
                CheckDateFromToIdentification = False
            End If

        ElseIf Identification = "WEEKLY" Then

            If DateDiff(DateInterval.Day, CDate(EffFrom), CDate(EffTo)) + 1 = 7 Then
                CheckDateFromToIdentification = True
            Else
                CheckDateFromToIdentification = False
            End If

        ElseIf Identification = "FORTNIGHTLY" Then

            If DateDiff(DateInterval.Day, CDate(EffFrom), CDate(EffTo)) + 1 = 15 Then
                CheckDateFromToIdentification = True
            Else
                CheckDateFromToIdentification = False
            End If

        ElseIf Identification = "MONTHLY" Then

            If DateDiff(DateInterval.Month, CDate(EffFrom), CDate(EffTo)) + 1 = "1" And DatePart(DateInterval.Day, CDate(EffFrom)) = "1" And (DatePart(DateInterval.Day, DateSerial(Year(CDate(EffTo)), Month(CDate(EffTo)) + 1, 1 - 1)) = DatePart(DateInterval.Day, CDate(EffTo))) Then
                CheckDateFromToIdentification = True
            Else
                CheckDateFromToIdentification = False
            End If

        ElseIf Identification = "QUARTERLY" Then

            If DateDiff(DateInterval.Month, CDate(EffFrom), CDate(EffTo)) + 1 = "3" And DatePart(DateInterval.Day, CDate(EffFrom)) = "1" And (DatePart(DateInterval.Day, DateSerial(Year(CDate(EffTo)), Month(CDate(EffTo)) + 1, 1 - 1)) = DatePart(DateInterval.Day, CDate(EffTo))) Then
                CheckDateFromToIdentification = True
            Else
                CheckDateFromToIdentification = False
            End If

        ElseIf Identification = "HALF YEARLY" Then

            If DateDiff(DateInterval.Month, CDate(EffFrom), CDate(EffTo)) + 1 = "6" And DatePart(DateInterval.Day, CDate(EffFrom)) = "1" And (DatePart(DateInterval.Day, DateSerial(Year(CDate(EffTo)), Month(CDate(EffTo)) + 1, 1 - 1)) = DatePart(DateInterval.Day, CDate(EffTo))) Then
                CheckDateFromToIdentification = True
            Else
                CheckDateFromToIdentification = False
            End If


        ElseIf Identification = "YEARLY" Then

            If DateDiff(DateInterval.Month, CDate(EffFrom), CDate(EffTo)) + 1 = "12" And DatePart(DateInterval.Day, CDate(EffFrom)) = "1" And (DatePart(DateInterval.Day, DateSerial(Year(CDate(EffTo)), Month(CDate(EffTo)) + 1, 1 - 1)) = DatePart(DateInterval.Day, CDate(EffTo))) Then
                CheckDateFromToIdentification = True
            Else
                CheckDateFromToIdentification = False
            End If


        End If

    End Function

    Public Function DeleteRecord(ByVal Sql As String) As Boolean

        Dim Tran As SqlTransaction
        If Obj.Connection.State = ConnectionState.Closed Then
            Obj.Connection.Open()
        End If
        Tran = Obj.Connection.BeginTransaction
        Try
            Cmd = New SqlCommand(Sql, Obj.Connection)
            Cmd.Transaction = Tran
            Cmd.ExecuteNonQuery()
            Tran.Commit()
            DeleteRecord = True 'Function
            '  Insert = True ' Variabale
        Catch ex As Exception
            Tran.Rollback()
            DeleteRecord = False
            '  Insert = False
        End Try

    End Function

    Public Sub GetMartialStatus(ByVal DDl As DropDownList)
        DDl.Items.Add("Married")
        DDl.Items.Add("Unmarried")
        DDl.Items.Add("Divorcee")
        DDl.Items.Add("Widow")
        DDl.Items.Add("Widower")
        'DDl.Items.Add("Mr.")
        'DDl.Items.Add("Mr.")
    End Sub

    Public Sub GetBloodGroups(ByVal DDl As DropDownList)
        DDl.Items.Add("A+")
        DDl.Items.Add("A-")
        DDl.Items.Add("B+")
        DDl.Items.Add("B-")
        DDl.Items.Add("O+")
        DDl.Items.Add("O-")
        DDl.Items.Add("AB+")
        DDl.Items.Add("AB-")
    End Sub

    Public Function FetchDS(ByVal sql As String) As Data.DataSet
        'If Obj.Connection.State = ConnectionState.Closed Then
        '    Obj.Connection.Open()
        'End If
        Obj.ConOpen()
        Dim ds As Data.DataSet = New Data.DataSet()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sql, Obj.Connection)
        Try
            Da.Fill(ds)
            Return ds
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
    End Function

    Public Function NBlankZero(ByVal val As String) As Double
        If val = "" Then
            Return 0
        Else
            Return CDbl(val)
        End If
    End Function
    Public Function CheckFinDates(ByVal periodfrom As String, ByVal periodto As String) As Boolean

        Dim SqlPass = "SELECT * from JCT_SAS_FIN_MASTER where ('" & periodfrom & "' between fin_year_from and fin_year_to) and ('" & periodto & "' between fin_year_from and fin_year_to)    "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                CheckFinDates = True
            Else
                CheckFinDates = False
            End If
        Catch ex As Exception
        Finally
            Dr.Close()
            Obj.ConClose()
        End Try
    End Function
    Public Function FetchReader(ByVal sql As String) As SqlDataReader

        Try
            Cmd = New SqlCommand(sql, Obj.Connection)
            'GetConn()
            If Obj.Connection.State = ConnectionState.Closed Then Obj.ConOpen()
            dr = cmd.ExecuteReader()
            If dr.IsDBNull(0) Or dr.HasRows Then
                Cmd = New SqlCommand("Select 'No Data Found'", Obj.Connection)
                dr = cmd.ExecuteReader()
                Return dr
            Else
                Return dr
            End If
        Catch ex As Exception
            Return dr
            'MsgBox(ex.Message)
        End Try

    End Function
    Public Function Get_CardNumber(ByVal empcode As String, ByVal company As String) As Integer
        Try
            'Dim SqlPass1 = "select a.deptcode,mobile,housetype,housedesc,cardno,b.deptname,a.Empcode,empname,dob,desg  from jctdev..empmast a, jctdev..deptmast b,jctdev..mistel c  where a.deptcode=b.deptcode and  a.empcode='" & Trim(Me.txtusername.Text) & "' and a.empcode=c.empcode "
            Dim SqlPass1 = "select top 1 a.deptcode,house_no,cardno,b.deptname,a.Empcode,empname,dob,replace(replace(desg,'<',''),'>','') as desg,Mr_Mrs  from jctdev..jct_empmast_base a, jctdev..deptmast b  where a.deptcode=b.deptcode and  a.empcode='" & empcode & "' and  a.Company_Code='" & company & " ' and b.Company_Code='" & company & " '"
            Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
            If Dr1.HasRows = True Then
                While Dr1.Read()
                    Get_CardNumber = Dr1.Item("cardno")
                End While
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Function
    Public Function Get_Desg(ByVal empcode As String, ByVal company As String) As String
        Try
            'Dim SqlPass1 = "select a.deptcode,mobile,housetype,housedesc,cardno,b.deptname,a.Empcode,empname,dob,desg  from jctdev..empmast a, jctdev..deptmast b,jctdev..mistel c  where a.deptcode=b.deptcode and  a.empcode='" & Trim(Me.txtusername.Text) & "' and a.empcode=c.empcode "
            Dim SqlPass1 = "select top 1 a.deptcode,house_no,cardno,b.deptname,a.Empcode,empname,dob,replace(replace(desg,'<',''),'>','') as desg,Mr_Mrs  from jctdev..jct_empmast_base a, jctdev..deptmast b  where a.deptcode=b.deptcode and  a.empcode='" & empcode & "' and  a.Company_Code='" & company & " ' and b.Company_Code='" & company & " '"
            Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
            If Dr1.HasRows = True Then
                While Dr1.Read()
                    Get_Desg = Dr1.Item("Desg")
                End While
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Function
    Public Function Get_dept(ByVal empcode As String, ByVal company As String) As String
        Try
            'Dim SqlPass1 = "select a.deptcode,mobile,housetype,housedesc,cardno,b.deptname,a.Empcode,empname,dob,desg  from jctdev..empmast a, jctdev..deptmast b,jctdev..mistel c  where a.deptcode=b.deptcode and  a.empcode='" & Trim(Me.txtusername.Text) & "' and a.empcode=c.empcode "
            Dim SqlPass1 = "select top 1 a.deptcode,house_no,cardno,b.deptname,a.Empcode,empname,dob,replace(replace(desg,'<',''),'>','') as desg,Mr_Mrs  from jctdev..jct_empmast_base a, jctdev..deptmast b  where a.deptcode=b.deptcode and  a.empcode='" & empcode & "' and  a.Company_Code='" & company & " ' and b.Company_Code='" & company & " '"
            Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
            If Dr1.HasRows = True Then
                While Dr1.Read()
                    Get_dept = Dr1.Item("DeptName")
                End While
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Function
    Public Function Get_dob(ByVal empcode As String, ByVal company As String) As String
        Try
            'Dim SqlPass1 = "select a.deptcode,mobile,housetype,housedesc,cardno,b.deptname,a.Empcode,empname,dob,desg  from jctdev..empmast a, jctdev..deptmast b,jctdev..mistel c  where a.deptcode=b.deptcode and  a.empcode='" & Trim(Me.txtusername.Text) & "' and a.empcode=c.empcode "
            Dim SqlPass1 = "select top 1 a.deptcode,house_no,cardno,b.deptname,a.Empcode,empname,dob,replace(replace(desg,'<',''),'>','') as desg,Mr_Mrs  from jctdev..jct_empmast_base a, jctdev..deptmast b  where a.deptcode=b.deptcode and  a.empcode='" & empcode & "' and  a.Company_Code='" & company & " ' and b.Company_Code='" & company & " '"
            Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
            If Dr1.HasRows = True Then
                While Dr1.Read()
                    Get_dob = Dr1.Item("Dob")
                End While
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Function
    Public Function Get_empname(ByVal empcode As String, ByVal company As String) As String
        Try
            'Dim SqlPass1 = "select a.deptcode,mobile,housetype,housedesc,cardno,b.deptname,a.Empcode,empname,dob,desg  from jctdev..empmast a, jctdev..deptmast b,jctdev..mistel c  where a.deptcode=b.deptcode and  a.empcode='" & Trim(Me.txtusername.Text) & "' and a.empcode=c.empcode "
            Dim SqlPass1 = "select top 1 a.deptcode,house_no,cardno,b.deptname,a.Empcode,empname,dob,replace(replace(desg,'<',''),'>','') as desg,Mr_Mrs  from jctdev..jct_empmast_base a, jctdev..deptmast b  where a.deptcode=b.deptcode and  a.empcode='" & empcode & "' and  a.Company_Code='" & company & " ' and b.Company_Code='" & company & " '"
            Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
            If Dr1.HasRows = True Then
                While Dr1.Read()
                    Get_empname = Dr1.Item("empname")
                End While
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Function

    Public Function RedirectToReferer() As String

        ' do all of your processing here
        ' now, get the URI of the referrer

        Dim uriReferrer As System.Uri
        uriReferrer = System.Web.HttpContext.Current.Request.UrlReferrer

        ' test to make sure the visitor actually came from somewhere,
        ' (rather than simply typed in the URL of this page)
        ' if they did come from somewhere, return them there

        Dim strWhereToGoNow As String
        If uriReferrer Is Nothing Then
            strWhereToGoNow = "default.aspx"
        Else
            strWhereToGoNow = uriReferrer.AbsoluteUri
        End If

        ' now, send them to the page specified
        'Response.Redirect(strWhereToGoNow)

        Return strWhereToGoNow

    End Function
    Public Sub sorting(ByVal sql1 As String, ByVal Grd As GridView, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs)
        Obj.ConOpen()
        Dim ds As DataSet = New DataSet
        Dim Da As SqlDataAdapter
        Da = New SqlDataAdapter(sql1, Obj.Connection)
        Da.Fill(ds)
        grd.DataSource = ds
        grd.DataBind()
        Dim dv As DataView = New DataView(ds.Tables(0))
        dv.Sort = e.SortExpression & " ASC"
        grd.DataSource = dv
        grd.DataBind()
        Obj.ConClose()
        grd.SelectedIndex = -1
    End Sub





 Function GetEmailID(ByVal EmpCode As String) As String
        Dim Qry As String = ""
        Qry = "select e_mailid from mistel where empcode='" & EmpCode & "'"
        Dr = Obj.FetchReader(Qry)
        If Dr.HasRows = True Then
            Dr.Read()
            If Dr(0) Is System.DBNull.Value Then
                GetEmailID = "dummy@jctltd.com"
            Else
                GetEmailID = Dr(0)
            End If
        Else
            GetEmailID = "dummy@jctltd.com"
        End If
        Dr.Close()
        Obj.ConClose()


    End Function

    Public Sub SendMail(ByVal fromAd As String, ByVal toAd As String, ByVal CCAd As String, ByVal BCCAd As String, ByVal Subject As String, ByVal Body As String)
        Dim Client As New Net.Mail.SmtpClient
        Dim Message As New Net.Mail.MailMessage
        'Message.IsBodyHtml = True

        If Trim(toAd) <> "" Then
            Message.To.Add(toAd)
        End If

        If Trim(CCAd) <> "" Then
            Message.CC.Add(CCAd)
        End If

        If Trim(BCCAd) <> "" Then
            Message.Bcc.Add(BCCAd)
        End If
        Message.Subject = Subject
        Message.Body = Body

        Dim From As New Net.Mail.MailAddress(fromAd)
        Message.From = From

        Client.Host = "EXCHANGE2003"
        Client.Port = 25
        Client.Send(Message)
    End Sub



    'Public Sub Sorting(ByVal Sql1 As String, ByVal Grd As GridView, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs)

    '    Obj.ConOpen()

    '    Dim ds As DataSet = New DataSet

    '    Dim Da As SqlDataAdapter

    '    Da = New SqlDataAdapter(sql1, Obj.Connection)

    '    Da.Fill(ds)

    '    Grd.DataSource = ds

    '    Grd.DataBind()

    '    Dim dv As DataView = New DataView(ds.Tables(0))

    '    Dim session1 As HttpSessionState = HttpContext.Current.Session

    '    If session1("a") = False Then

    '        dv.Sort = e.SortExpression & " ASC"

    '        session1("b") = False

    '        session1("a") = True

    '    ElseIf session1("b") = False Then

    '        dv.Sort = e.SortExpression & " DESC"

    '        session1("a") = False

    '        session1("b") = True

    '    End If

    '    Grd.DataSource = dv

    '    Grd.DataBind()

    '    Obj.ConClose()

    '    Grd.SelectedIndex = -1

    'End Sub
End Module