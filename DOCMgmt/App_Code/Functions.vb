Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.Text
Imports System.Web.UI

Public Module Message
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
    'Public Function FetchDS(ByVal sql As String) As Data.DataSet
    '    'If Obj.Connection.State = ConnectionState.Closed Then
    '    '    Obj.Connection.Open()
    '    'End If
    '    Obj.ConOpen()
    '    Dim ds As Data.DataSet = New Data.DataSet()
    '    Dim Da As SqlDataAdapter = New SqlDataAdapter(sql, Obj.Connection)
    '    Try
    '        Da.Fill(ds)
    '        Return ds
    '    Catch ex As Exception
    '    Finally
    '        Obj.ConClose()
    '    End Try
    'End Function
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
    Public Sub CheckPermission(ByVal FrmName As String, ByVal BtnAdd As LinkButton, ByVal BtnEdit As LinkButton, ByVal BtnDelete As LinkButton, ByVal Empcode As String)
        Try
            SqlPass = "SELECT RIGHT(LTRIM(RTRIM(b.page_name)),LEN(b.page_name)-2),C.action FROM production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c WHERE a.action<>'load' AND b.module=a.module AND a.mnuname=b.mnuname AND C.mnuname=A.mnuname  AND a.action=c.action AND a.module=c.module AND a.module='docmgmt'AND c.uname='" & Empcode & "' AND RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2)='" & FrmName & "'   union    select RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..role_module_menus_mapping c,production..role_user_mapping d where a.action<>'load' AND b.module=a.module AND a.mnuname=b.mnuname AND a.action=c.action AND c.role=d.role AND C.mnuname=A.mnuname AND a.module=c.module AND a.module='docmgmt'AND  d.uname='" & Empcode & "' AND RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2)='" & FrmName & "' "
            Dr = Obj.FetchReader(SqlPass)

            If Dr.HasRows = True Then

                While Dr.Read()
                    If Dr(1).ToString = "Add" Then
                        Enable_Buttons(BtnAdd)
                    ElseIf Dr(1).ToString = "Edit" Then
                        Enable_Buttons(BtnEdit)
                    ElseIf Dr(1).ToString = "Delete" Then
                        Enable_Buttons(BtnDelete)
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
            Page.ClientScript.RegisterClientScriptBlock(GetType(Message), "alert", Script)
        End If

    End Sub
    'Public Sub AddBlurAtt(ByVal Cntrl As Control)

    '    If Cntrl.Controls.Count > 0 Then
    '        For Each ChildControl As Control In Cntrl.Controls
    '            AddBlurAtt(ChildControl)
    '        Next
    '    End If
    '    If Cntrl.[GetType]() Is GetType(TextBox) Then
    '        Dim TempTextBox As TextBox = DirectCast(Cntrl, TextBox)
    '        TempTextBox.Attributes.Add("onFocus", "DoFocus(this);")
    '        TempTextBox.Attributes.Add("onBlur", "DoBlur(this);")
    '    End If

    'End Sub

    Public Sub FillGrid(ByVal Sql As String, ByVal Grd As GridView)

        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sql, Obj.Connection())
        Try
            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            Grd.DataSource = ds
            Grd.DataBind()
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Function InsertRecord(ByVal Sql As String) As Boolean

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
                    If Dr.Item(0) = "X" Then
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

    'Public Function ScalarRecord(ByVal Sql As String) As String
    '    Try
    '        Obj.ConOpen()
    '        Cmd = New SqlCommand(Sql, Obj.Connection)
    '        ScalarRecord = IIf(Cmd.ExecuteScalar Is Nothing, "", Cmd.ExecuteScalar)
    '    Catch ex As Exception
    '    Finally
    '        Obj.ConClose()
    '    End Try
    'End Function

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

    Public Sub ButtonValidationEnable(ByVal CmdAdd As LinkButton, ByVal CmdEdit As LinkButton, ByVal CmdDelete As LinkButton)
        CmdAdd.CausesValidation = True
        CmdEdit.CausesValidation = True
        'CmdDelete.CausesValidation = True
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
    Public Sub ButtonValidationDisable(ByVal CmdAdd As LinkButton, ByVal CmdEdit As LinkButton, ByVal CmdDelete As LinkButton)
        CmdAdd.CausesValidation = False
        CmdEdit.CausesValidation = False
        CmdDelete.CausesValidation = False
    End Sub
    Public Function AutoGenrate(ByVal Sqlpass As String) As Integer
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        AutoGenrate = Dr.Item(0) + 1
                    Else
                        AutoGenrate = 101
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
    Public Sub FillList(ByVal ddl As DropDownList, ByVal sql As String)
        'Dim cn As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand(sql, Obj.Connection)
        Obj.ConOpen()
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
        If prop = trim(Lcase("Empty")) Then
            If ctrl.[GetType]() Is GetType(TextBox) Then
                CType(ctrl, TextBox).Text = ""
            End If
        ElseIf prop = trim(Lcase("ReadOnlyTrue")) Then
            If ctrl.[GetType]() Is GetType(TextBox) Then
                CType(ctrl, TextBox).ReadOnly = True
            End If
        ElseIf prop = Trim(Lcase("ReadOnlyFalse")) Then
            If ctrl.[GetType]() Is GetType(TextBox) Then
                CType(ctrl, TextBox).ReadOnly = False
            End If
        End If
        If ctrl.[GetType]() Is GetType(TextBox) Then
            CType(ctrl, TextBox).Text = ""
        End If
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

End Module


