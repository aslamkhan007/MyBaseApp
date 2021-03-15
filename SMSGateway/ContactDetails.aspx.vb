Imports System.Data
Imports System.Data.SqlClient
Partial Class SMSLive_ContactDetails
    Inherits System.Web.UI.Page
    Dim network As Devices.Network = New Microsoft.VisualBasic.Devices.Network()
    Dim Query As String
    Dim Obj As Connection = New Connection
    Dim Obj1 As Connection = New Connection
    Dim ObjFun As Functions = New Functions
    Dim Sql As String, Dept As String
    Dim Cmd As New SqlCommand
    Dim Dr As SqlDataReader
    Dim Trans_ID As Integer
    Dim New_Trans As Integer
    Dim Tran As SqlTransaction
    Dim Exists As Boolean = False
    Dim TransID As String = ""
    Dim TransNo As Integer = 1
    Dim Type As String = ""

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtContactCode.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Button3.UniqueID + "').click();return false;}} else {return true}; ")
        txtContactName.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Button3.UniqueID + "').click();return false;}} else {return true}; ")
    End Sub

    Protected Sub CmdAdd_Click(sender As Object, e As System.EventArgs) Handles CmdAdd.Click

        Try
            If CmdAdd.Text = "Save" Then

                If ddlContactType.SelectedItem.Text = "Customer" Then
                    Type = "Cust"
                ElseIf ddlContactType.SelectedItem.Text = "Employee" Then
                    Type = "Emp"
                ElseIf ddlContactType.SelectedItem.Text = "Supplier" Then
                    Type = "Sup"
                ElseIf ddlContactType.SelectedItem.Text = "Other" Then
                    Type = "Oth"
                End If
                Sql = "Select ISNULL(Max(Convert(INT,Right(ContactID,len(ContactID)-4))),0) from jct_SMS_ContactMaster where left(ContactID,4)='" & Type & "' "
                Obj.ConOpen()
                Cmd = New SqlCommand(Sql, Obj.Connection)
                Dr = Cmd.ExecuteReader
                Dr.Read()
                If Dr.HasRows = True Then
                    If Dr.Item(0) = "0" Then

                        TransID = "1"
                    Else
                        TransID = Dr.Item(0) + 1
                    End If
                Else

                End If
                Obj.ConClose()
                Type = Type & TransID
                Sql = "Select Isnull(max(TransNo),0) from jct_SMS_ContactMaster "
                Obj.ConOpen()
                Cmd = New SqlCommand(Sql, Obj.Connection)
                Dr = Cmd.ExecuteReader
                Dr.Read()
                If Dr.HasRows = True Then
                    If Dr.Item(0) = 0 Then

                        TransNo = 1
                    Else
                        TransNo = Dr.Item(0) + 1
                    End If
                Else
                    TransNo = 1
                End If
                Obj.ConClose()
                'SqlPass = "INSERT INTO JCT_Epor_Employee_Address_Trans VALUES('" & Session("Companycode") & "','" & Session("Empcode") & "',Upper('" & Trim(ddlCompany.SelectedItem.Value) & "'),upper('" & Trim(Me.txtEmpCode.Text) & "'),'" & ddlAddressType.SelectedItem.Text & "',upper('" & Trim(Me.TxtAddress1.Text) & "'), upper('" & Trim(TxtAddress2.Text) & "'),Upper('" & Trim(TxtAddress3.Text) & "'),Upper('" & Trim(TxtCity.Text) & "'),Upper('" & Trim(TxtPin.Text) & "'),Upper('" & Trim(TxtState.Text) & "'),Upper('" & Trim(txtCountry.Text) & "'),'" & Trim(PriLLNo) & "','" & Trim(SecLLNo) & "','" & Trim(TxtPri_Mobile.Text) & "','" & Trim(TxtSecMob.Text) & "','" & Trim(TxtEmailID.Text) & "','A','" & Request.UserHostAddress & "',getdate(),NULL,NULL,'" & txtCardNo.Text & "')"
                Sql = "INSERT INTO jct_SMS_ContactMaster( ContactID ,ContactName ,ContactType ,AddressLine1 ,AddressLine2 ,AddressLine3 ,City ,State ,Country ,MobileNo, EmailAddress, " & _
                    "SMSMode ,EmailMode, STATUS ,CreatedDate ,CreatedByUser ,CreatedByIP,TransNo,DateOFBirth,DateOfAniv) Values ('" & Type & "','" & txtContactName.Text & "','" & ddlContactType.Text & "','" & txtAddressLine1.Text & "','" & txtAddressLine2.Text & "','" & txtAddressLine3.Text & "', " & _
                    " '" & txtCity.Text & "','" & txtState.Text & "','" & txtCountry.Text & "','" & txtMobille.Text & "','" & txtEmail.Text & "','" & ChkSms.Checked & "','" & ChkEmail.Checked & "','A',Getdate(),'" & Session("EmpCode") & "','" & Request.ServerVariables("REMOTE_ADDR") & "', " & _
                    " " & TransNo & ",'" & TxtDOB.Text & "','" & TxtAniv.Text & "' )"

                If Obj.Connection.State = ConnectionState.Closed Then
                    '    Obj.Connection.Open()
                    'Else
                    '    Obj.ConClose()
                    Obj.Connection.Open()
                End If

                Tran = Obj.Connection.BeginTransaction
                Cmd = New SqlCommand(Sql, Obj.Connection)
                Cmd.Transaction = Tran
                Cmd.ExecuteNonQuery()
                Tran.Commit()
                txtContactCode.Text = Type
                ObjFun.Alert("Record Added Sucessfully..")
                'DisplayTransactionStatus("addmsg", "Record Added Sucessfully..")
                'ddlAddressType_SelectedIndexChanged(sender, e)
                'End If
            ElseIf CmdAdd.Text = "Update" Then
                Sql = "Update jct_SMS_ContactMaster set status='D' where TransNo=" & TransID & " and status='A'"
                If Obj.Connection.State = ConnectionState.Closed Then
                    Obj.Connection.Open()
                End If
                Tran = Obj.Connection.BeginTransaction
                Cmd = New SqlCommand(Sql, Obj.Connection)
                Cmd.Transaction = Tran
                Cmd.ExecuteNonQuery()
                Sql = "INSERT INTO jct_SMS_ContactMaster( ContactID ,ContactName ,ContactType ,AddressLine1 ,AddressLine2 ,AddressLine3 ,City ,State ,Country ,MobileNo, EmailAddress, " & _
                    "SMSMode ,EmailMode, STATUS ,CreatedDate ,CreatedByUser ,CreatedByIP,TransNo) Values ('" & txtContactCode.Text & "','" & txtContactName.Text & "','" & ddlContactType.Text & "','" & txtAddressLine1.Text & "','" & txtAddressLine2.Text & "','" & txtAddressLine3.Text & "', " & _
                    " '" & txtCity.Text & "','" & txtState.Text & "','" & txtCountry.Text & "','" & txtMobille.Text & "','" & txtEmail.Text & "','" & ChkSms.Checked & "','" & ChkEmail.Checked & "', 'A',Getdate(),'" & Session("UserCode") & "')"
                Cmd = New SqlCommand(Sql, Obj.Connection)
                Cmd.Transaction = Tran
                Cmd.ExecuteNonQuery()
                Tran.Commit()
                'Obj.ConClose()
                'CmdAdd.Text = "Add"
                'ModalPopupExtender2.Enabled = True
                'ModalPopupExtender2.TargetControlID = "CmdEdit"
                'LblMessage.CssClass = "errormsg"
                'LblMessage.Text = "Record Updated Successfully"
                ObjFun.Alert("Record Updated Successfully..")
            ElseIf CmdAdd.Text = "Add" Then
                TextBoxBlank()
                If ddlContactType.SelectedItem.Text = "Other" Then
                    txtContactCode.Enabled = False
                    Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
                    Script.SetFocus(txtContactName)
                Else
                    txtContactCode.Enabled = True
                    Dim Script As ScriptManager = Page.Master.FindControl("ScriptManager1")
                    Script.SetFocus(txtContactCode)
                End If
                
                ObjFun.CheckAddEnableDisable(CmdAdd, CmdEdit, CmdDeActive, CmdClose, cmdSearch)
                ObjFun.ButtonValidationEnable(CmdAdd, CmdEdit, CmdDeactive)
                'Obj2.TextBoxEnable(txtContactName, TxtLongDesc, TxtEffFrom, TxtEffTo, txtRemarks, txtRemarks)
            End If
        Catch ex As Exception
            Tran.Rollback()
            ObjFun.Alert("Unable to update this record")
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Protected Sub ddlContactType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlContactType.SelectedIndexChanged

        If ddlContactType.SelectedItem.Text = "Other" Then
            txtContactCode.Enabled = False
        Else
            txtContactCode.Enabled = True
        End If
        If ddlContactType.SelectedItem.Text = "Customer" Then
            Type = "Cust"
        ElseIf ddlContactType.SelectedItem.Text = "Employee" Then
            Type = "Emp"
        ElseIf ddlContactType.SelectedItem.Text = "Supplier" Then
            Type = "Sup"
        ElseIf ddlContactType.SelectedItem.Text = "Other" Then
            Type = "Oth"
        End If
        Sql = "Select ISNULL(Max(Convert(INT,Right(ContactID,len(ContactID)-4))),0) from jct_SMS_ContactMaster where left(ContactID,4)='" & Type & "' "
        Obj.ConOpen()
        Cmd = New SqlCommand(Sql, Obj.Connection)
        Dr = Cmd.ExecuteReader
        Dr.Read()
        If Dr.HasRows = True Then
            If Dr.Item(0) = "0" Then

                TransID = "1"
            Else
                TransID = Dr.Item(0) + 1
            End If
        Else

        End If
        Obj.ConClose()
        txtContactCode.Text = Type & TransID
    End Sub
    Private Sub TextBoxBlank()
        TextBoxProp("Empty")
        ChkEmail.Checked = False
        ChkSms.Checked = False
    End Sub
    Private Sub TextBoxProp(ByVal Prop As String)
        For Each ctrl As Control In Me.Page.Controls

            If LCase(Prop) = Trim(LCase("Empty")) Then
                If ctrl.[GetType]() Is GetType(TextBox) Then
                    CType(ctrl, TextBox).Text = ""
                End If
            ElseIf LCase(Prop) = Trim(LCase("ReadOnlyTrue")) Then
                If ctrl.[GetType]() Is GetType(TextBox) Then
                    CType(ctrl, TextBox).ReadOnly = True
                End If
            ElseIf LCase(Prop) = Trim(LCase("ReadOnlyFalse")) Then
                If ctrl.[GetType]() Is GetType(TextBox) Then
                    CType(ctrl, TextBox).ReadOnly = False
                End If
            ElseIf LCase(Prop) = Trim(LCase("EnabledTrue")) Then
                If ctrl.[GetType]() Is GetType(TextBox) Then
                    CType(ctrl, TextBox).Enabled = True
                End If
            ElseIf LCase(Prop) = Trim(LCase("EnabledFalse")) Then
                If ctrl.[GetType]() Is GetType(TextBox) Then
                    CType(ctrl, TextBox).Enabled = False
                End If
            End If
            '            ObjFun.TextBoxControl(ctrl, Prop)
        Next
    End Sub

    Protected Sub CmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        TextBoxProp("Empty")
    End Sub

    Protected Sub CmdImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdImport.Click

    End Sub
End Class
