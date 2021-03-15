Imports System.Data
Imports System.Data.SqlClient
Partial Class SMSGateway_MessageContents
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim obj As Connection = New Connection
    Dim obj1 As Functions = New Functions
    Dim ddltest As DropDownList = New DropDownList
    Dim msgID As String
    Dim dr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EmpCode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        If Not Page.IsPostBack Then
            readOnly1()
            button(lnkFirst, lnkNext, lnkPrevious, lnkLast)
            lnkDelete.Enabled = False
            lnkEdit.Enabled = False
        End If
    End Sub

    Public Sub generateID()
        ' sql = "Select Isnull(Max(Substring('SMS',1,1) + Convert(varchar,100 )), SUBSTRING('SMS',1,1) +CONVERT( VARCHAR,100)) from JCT_SMS_MESSAGE_TEMPLATES where status='A'"

        sql = "Select Isnull(MsgID,(Substring('" & Trim(ddlMsgType.SelectedItem.Text) & "',1,1) + Convert(varchar,100 ))) from JCT_SMS_MESSAGE_TEMPLATES where status='A' and Trans_no=(SELECT MAX(Trans_no) FROM jct_sms_message_templates WHERE STATUS='A')"
        obj1.FillList(ddltest, sql)
        sql = "Select MsgID from JCT_SMS_MESSAGE_TEMPLATES where MsgID like '%" & Trim(ddltest.SelectedItem.Text) & "%' and status='A'"
        If obj1.SelectRecord(sql) = True Then
            sql = "Select CONVERT(INTEGER,Substring('" & Trim(ddltest.SelectedItem.Text) & "',2,4)) +  1 "
            obj1.FillList(ddltest, sql)
            sql = "Select SubString('" & Trim(ddlMsgType.SelectedItem.Text) & "',1,1) + '" & Trim(ddltest.SelectedItem.Text) & "' "
            msgID = obj1.FetchValue(sql)
        Else
            sql = "Select SubString('" & Trim(ddlMsgType.SelectedItem.Text) & "',1,1) + Convert(varchar,100) "
            msgID = obj1.FetchValue(sql)
        End If
    End Sub
    Public Sub readOnly1()
        ddlMsgType.Enabled = False
        ddlMsgBehaviour.Enabled = False
        txtMsg.ReadOnly = True
        txtProc.ReadOnly = True
        txtSubject.ReadOnly = True
    End Sub
    Public Sub writeonly1()
        ddlMsgType.Enabled = True
        ddlMsgBehaviour.Enabled = True
        txtMsg.ReadOnly = False
        txtProc.ReadOnly = False
        txtSubject.ReadOnly = False
    End Sub
    Public Sub button(ByVal lnk1 As LinkButton, ByVal lnk2 As LinkButton, ByVal lnk3 As LinkButton, ByVal lnk4 As LinkButton)
        lnk1.Enabled = True
        lnk2.Enabled = False
        lnk3.Enabled = False
        lnk4.Enabled = True
    End Sub

    Protected Sub lnkEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEdit.Click
        If lnkEdit.Text = "Edit" Then
            lnkEdit.Text = "Update"
            writeonly1()
            txtMsg.ValidationGroup = False
            txtProc.ValidationGroup = False
            txtSubject.ValidationGroup = False
            ddlMsgBehaviour.ValidationGroup = False
            ddlMsgType.ValidationGroup = False
        ElseIf lnkEdit.Text = "Update" Then
            txtMsg.ValidationGroup = True
            txtProc.ValidationGroup = True
            txtSubject.ValidationGroup = True
            ddlMsgBehaviour.ValidationGroup = True
            ddlMsgType.ValidationGroup = True
            If lblMsgID.Text <> "" Then
                sql = "Select * from JCT_SMS_MESSAGE_TEMPLATES WHERE msgId='" & lblMsgID.Text & "' AND STATUS='A'"
                If obj1.SelectRecord(sql) = True Then
                    msgdisplay("Record Already exists..")
                Else
                    sql = "Update JCT_SMS_MESSAGE_TEMPLATES set Status='U' and Deleted_Dt=Getdate() where msgid='" & Trim(lblMsgID.Text) & "' and status='A'  "
                    obj1.InsertRecord(sql)
                    generateID()
                    sql = "INSERT INTO dbo.JCT_SMS_MESSAGE_TEMPLATES( CompanyCode ,UserCode ,Msgtype ,MsgBehaviour ,MsgID ,SUBJECT ,Msg , STATUS ,Created_Dt,Sms_Procedure ) " & _
                                                 " VALUES  ( 'JCTLTD001' , '" & Session("EmpCode") & "' , '" & ddlMsgType.SelectedItem.Text & "' , '" & ddlMsgBehaviour.SelectedItem.Text & "' ,'" & Trim(msgID) & "' ,'" & Trim(txtSubject.Text) & "' ,'" & Trim(txtMsg.Text) & "', 'A' , GETDATE(),'" & Trim(txtProc.Text) & "'  ) "
                    obj1.InsertRecord(sql)
                    msgdisplay("Records updated..")
                    lnkEdit.Text = "Edit"
                    readOnly1()
                    emptytextbox()
                End If
            End If
        End If
    End Sub

    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDelete.Click
        If lblMsgID.Text <> "" Then
            sql = "Update JCT_SMS_MESSAGE_TEMPLATES set status='D' , Deleted_Dt=Getdate() where msgid='" & lblMsgID.Text & "' and status='A'"
            obj1.UpdateRecord(sql)
            msgdisplay("Record deleted..")
            emptytextbox()
            lnkLast.Enabled = True
        Else
            msgdisplay("Please select some record..")
        End If
    End Sub

    Protected Sub lnkReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkReset.Click
        Response.Redirect("~/SMSGateway/MessageContents.aspx")
    End Sub

    Protected Sub lnkFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFirst.Click
        lnkNext.Enabled = True
        lnkAdd.Enabled = False
        lnkPrevious.Enabled = False
        lnkEdit.Enabled = True
        lnkDelete.Enabled = True
        
        sql = "Select * from JCT_SMS_MESSAGE_TEMPLATES where trans_no = (Select Min(Trans_no) from JCT_SMS_MESSAGE_TEMPLATES where status='A')"
        Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection)
        If obj.Connection.State = ConnectionState.Closed Then
            obj.Connection.Open()
        End If
        Dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            ddlMsgType.Text = dr("MsgType")
            ddlMsgBehaviour.Text = dr("MsgBehaviour")
            txtProc.Text = dr("Sms_Procedure")
            lblMsgID.Text = dr("MsgID")
            txtSubject.Text = dr("Subject")
            txtMsg.Text = dr("Msg")
            txtTrans_no.Text = dr("Trans_no")
        Else
            msgdisplay("No Record Found..")
        End If
        obj.Connection.Close()
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        lnkEdit.Enabled = True
        lnkDelete.Enabled = True
        lnkAdd.Enabled = False
        sql = "Select * from JCT_SMS_MESSAGE_TEMPLATES where status='A' and Trans_no > Convert(Int," & txtTrans_no.Text & ") ORDER BY trans_no ASC "
        Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection)
        If obj.Connection.State = ConnectionState.Closed Then
            obj.Connection.Open()
        End If
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            ddlMsgType.Text = dr("MsgType")
            ddlMsgBehaviour.Text = dr("MsgBehaviour")
            txtProc.Text = dr("Sms_Procedure")
            lblMsgID.Text = dr("MsgID")
            txtSubject.Text = dr("Subject")
            txtMsg.Text = dr("Msg")
            txtTrans_no.Text = dr("Trans_no")
        Else
            msgdisplay("No record Found.")
        End If
        obj.Connection.Close()
        sql = "Select * from JCT_SMS_MESSAGE_TEMPLATES where status='A'  and Trans_no > Convert(Int," & txtTrans_no.Text & ")  "
        cmd = New SqlCommand(sql, obj.Connection)
        If obj.Connection.State = ConnectionState.Closed Then
            obj.Connection.Open()
        End If
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            lnkNext.Enabled = True
        Else
            lnkNext.Enabled = False
            lnkLast.Enabled = False
        End If
        obj.Connection.Close()
        lnkFirst.Enabled = True
        lnkPrevious.Enabled = True
    End Sub

    Protected Sub lnkPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrevious.Click
        If txtTrans_no.Text = "" Then
            sql = "SELECT MAX(Trans_no) FROM JCT_SMS_MESSAGE_TEMPLATES WHERE STATUS='A'"
            txtTrans_no.Text = obj1.FetchValue(sql)
        End If

        lnkAdd.Enabled = False
        lnkEdit.Enabled = True
        lnkDelete.Enabled = True
        sql = "Select * from JCT_SMS_MESSAGE_TEMPLATES where status='A' and Trans_no < Convert(Int," & txtTrans_no.Text & ") ORDER BY trans_no DESC   "
        Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection)
        If obj.Connection.State = ConnectionState.Closed Then
            obj.Connection.Open()
        End If
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            ddlMsgType.Text = dr("MsgType")
            ddlMsgBehaviour.Text = dr("MsgBehaviour")
            txtProc.Text = dr("Sms_Procedure")
            lblMsgID.Text = dr("MsgID")
            txtSubject.Text = dr("Subject")
            txtMsg.Text = dr("Msg")
            txtTrans_no.Text = dr("Trans_no")
        Else
            msgdisplay("No record Found.")
        End If
        obj.Connection.Close()
        sql = "Select Trans_no From JCT_SMS_MESSAGE_TEMPLATES where status='A' and Trans_no < Convert(Int," & txtTrans_no.Text & ") "
        cmd = New SqlCommand(sql, obj.Connection)
        If obj.Connection.State = ConnectionState.Closed Then
            obj.Connection.Open()
        End If
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            lnkPrevious.Enabled = True
        Else
            lnkPrevious.Enabled = False
        End If
        obj.Connection.Close()
        lnkFirst.Enabled = True
        lnkNext.Enabled = True
        lnkLast.Enabled = True
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        lnkAdd.Enabled = False
        lnkEdit.Enabled = True
        lnkDelete.Enabled = True
        sql = "Select * from JCT_SMS_MESSAGE_TEMPLATES where status='A' and Trans_no= ( Select Max(Trans_no) from JCT_SMS_MESSAGE_TEMPLATES where status='A') "
        Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection)
        If obj.Connection.State = ConnectionState.Closed Then
            obj.Connection.Open()
        End If
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            ddlMsgType.Text = dr("MsgType")
            ddlMsgBehaviour.Text = dr("MsgBehaviour")
            txtProc.Text = dr("Sms_Procedure")
            lblMsgID.Text = dr("MsgID")
            txtSubject.Text = dr("Subject")
            txtMsg.Text = dr("Msg")
            txtTrans_no.Text = dr("Trans_no")
        Else
            msgdisplay("No record Found.")
        End If
        obj.Connection.Close()
        lnkFirst.Enabled = True
        lnkNext.Enabled = False
        lnkPrevious.Enabled = True
        lnkLast.Enabled = False
    End Sub

    Protected Sub lnkAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdd.Click
        If lnkAdd.Text = "Add" Then
            lnkAdd.Text = "Save"
            writeonly1()
            txtMsg.ValidationGroup = ""
            txtProc.ValidationGroup = ""
            txtSubject.ValidationGroup = ""
        ElseIf lnkAdd.Text = "Save" Then
            txtMsg.ValidationGroup = "Group1"
            txtProc.ValidationGroup = "Group1"
            txtSubject.ValidationGroup = "Group1"
            If ddlMsgType.SelectedItem.Text <> "--Select--" And ddlMsgBehaviour.SelectedItem.Text <> "--Select--" Then
                sql = "SELECT * FROM dbo.JCT_SMS_MESSAGE_TEMPLATES WHERE Msgtype='" & ddlMsgType.SelectedItem.Text & "' AND MsgBehaviour='" & ddlMsgBehaviour.SelectedItem.Text & "' AND SUBJECT='" & Trim(txtSubject.Text) & "' AND Msg='" & Trim(txtMsg.Text) & "' AND Sms_Procedure='" & Trim(txtProc.Text) & "' AND STATUS='A'  "
                If obj1.SelectRecord(sql) = True Then
                    msgdisplay("Record already exists.")
                Else
                    generateID()
                    sql = "INSERT INTO dbo.JCT_SMS_MESSAGE_TEMPLATES( CompanyCode ,UserCode ,Msgtype ,MsgBehaviour ,MsgID ,SUBJECT ,Msg , STATUS ,Created_Dt,Sms_Procedure ) " & _
                                              " VALUES  ( 'JCTLTD001' , '" & Session("EmpCode") & "' , '" & ddlMsgType.SelectedItem.Text & "' , '" & ddlMsgBehaviour.SelectedItem.Text & "' ,' " & Trim(msgID) & "' ,'" & Trim(txtSubject.Text) & "' , '" & Trim(txtMsg.Text) & "' , 'A' , GETDATE(),'" & Trim(txtProc.Text) & "'  ) "
                    obj1.InsertRecord(sql)
                    msgdisplay("Record added successfully.")
                    lnkAdd.Text = "Add"
                    readOnly1()
                    emptytextbox()
                End If
            End If
        End If
    End Sub
    Public Sub emptytextbox()
        txtMsg.Text = ""
        txtProc.Text = ""
        txtSubject.Text = ""
        txtTrans_no.Text = ""
        ddlMsgBehaviour.SelectedIndex = 0
        ddlMsgType.SelectedIndex = 0
        lblMsgID.Text = ""
    End Sub

    Protected Sub lnkClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkClose.Click
        Response.Redirect("~/SMSGateway/MessageContents.aspx")
    End Sub

    Public Sub msgdisplay(ByVal msg As String)
        LblMessage.Text = msg
        ModalPopupExtender1.Enabled = True
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub ddlMsgType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMsgType.SelectedIndexChanged
        If ddlMsgType.SelectedItem.Text = "SMS" Then
            lblChars.Visible = True
            lblChars.Text = "(Maximum 160 Characters)"
            RegularExpressionValidator1.Enabled = True
            RegularExpressionValidator1.ErrorMessage = "Maximum 160 Characters are allowed including spaces"
        Else
            lblChars.Visible = False
            RegularExpressionValidator1.Enabled = False

        End If
    End Sub
End Class
