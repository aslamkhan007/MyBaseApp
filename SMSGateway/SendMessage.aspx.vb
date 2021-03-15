Imports System.Data
Imports System.Data.SqlClient

Partial Class SMSLive_SendMessage
    Inherits System.Web.UI.Page

    Dim ob As New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sql As String = "select subject from jct_sms_message_templates where status = 'A' and MsgBehaviour = 'User'"
            ob.FillList(ddlSubject, sql)
            ddlSubject.Items.Add("")
            ddlSubject.Text = ""
        End If

    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        Dim sql As String = "select msg from jct_sms_message_templates where status = 'A' and subject = '" & ddlSubject.SelectedValue & "'"
        txtMessageText.Text = ob.FetchValue(sql)

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("PlaceHolder")
        dt.Columns.Add("Value")
        'Dim lst As New List(Of String)

        Dim msgarr() As String = txtMessageText.Text.Split("|"c)
        Dim i As Integer = 0
        For Each Val As String In msgarr
            If i Mod 2 = 1 Then
                Dim drow As DataRow = dt.NewRow
                drow(0) = msgarr(i)
                dt.Rows.Add(drow)
            End If
            i += 1
        Next

        dlsValues.DataSource = dt
        dlsValues.DataBind()

        ViewState("data") = dt

    End Sub

    Protected Sub cmdSendMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSendMessage.Click

        Dim contacts As String = ""
        Dim c As Integer

        If grdGroupContacts.Rows.Count > 0 Then
            For Each row As GridViewRow In grdGroupContacts.Rows
                If row.Cells(6).Text <> "&nbsp;" Then
                    If c = 0 Then
                        contacts += row.Cells(4).Text
                        c += 1
                    Else
                        contacts += "," + row.Cells(4).Text
                    End If
                End If
            Next
        End If

        If grdContacts.Rows.Count > 0 Then
            For Each row As GridViewRow In grdContacts.Rows
                If row.Cells(5).Text <> "&nbsp;" Then
                    If c = 0 Then
                        contacts += row.Cells(3).Text
                        c += 1
                    Else
                        contacts += "," + row.Cells(3).Text
                    End If
                End If
            Next
        End If

        'Dim client As New smscountry.Service
        'client.SendTextSMS("JCTLTD", "jct@147", "919878649707", TextBox2.Text, "JCTLTD")

        Dim result As String = ""

        If txtTo.Text <> "" AndAlso grdContacts.Rows.Count > 0 Then
            contacts += "," + txtTo.Text

        ElseIf txtTo.Text <> "" AndAlso grdContacts.Rows.Count = 0 Then
            contacts = txtTo.Text

        End If

        If contacts <> "" Then
            Dim sm As New SendMail
            result = sm.SendSMS("JCT00LTD", Session("EmpCode"), contacts, txtMessageText.Text, ddlSubject.Text)

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scr", "<script language = javascript> alert('No Contact Selected or Specified in To Box')</script>", False)
        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scr", "<script language = javascript> alert('Message Sent Successfuly to " & contacts & " with transaction id " & result & ".') </script>", False)

    End Sub

    Protected Sub cblContacts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cblContacts.SelectedIndexChanged

        GetContacts()

    End Sub

    Protected Sub grdContacts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdContacts.RowCommand

        If e.CommandName = "Remove" Then

            Dim li As ListItem = cblContacts.Items.FindByValue(e.CommandArgument)
            li.Selected = False

            GetContacts()
            'grdContacts.DataBind()
        End If

    End Sub

    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        GetContacts()
        
    End Sub

    Protected Sub GetContacts()
        Dim contacts As String = ""
        Dim c As Integer
        For Each li As ListItem In cblContacts.Items
            If li.Selected And c = 0 Then
                contacts += "'" & li.Value & "'"
                c += 1
            ElseIf li.Selected And c > 0 Then
                contacts += "," + "'" & li.Value & "'"
            End If
        Next

        Dim sql As String = "select empcode as contactid, Name as contactname, Mobile as mobileno, E_mailid as EmailAddress, " & _
                            "case when mobile is null then 0 else 1 end as smsmode, case when E_mailid is null then 0 else 1 end as emailmode from mistel where empcode in (" & contacts & ")"
        ' Dim dr As SqlDataReader = ob.FetchReader(sql)

        grdContacts.DataSource = ob.FetchReader(sql)
        grdContacts.DataBind()

    End Sub

    Protected Sub GetGroupContacts()
        Dim groups As String = ""
        Dim c As Integer
        For Each li As ListItem In cblGroups.Items
            If li.Selected And c = 0 Then
                groups += "'" & li.Value & "'"
                c += 1
            ElseIf li.Selected And c > 0 Then
                groups += "," + "'" & li.Value & "'"
            End If
        Next

        Dim sql As String = "select b.groupid, empcode as contactid, Name as contactname, Mobile as mobileno, E_mailid as EmailAddress, " & _
                            "case when mobile is null then 0 else 1 end as smsmode, case when E_mailid is null then 0 else 1 end as emailmode from mistel a " & _
                            "inner join jct_sms_group_members b on a.empcode = b.contactid " & _
                            "where b.status='A' and b.groupid in(" & groups & ")"

        ' Dim contactlist As List(Of Contact) = New List(Of Contact)

        grdGroupContacts.DataSource = ob.FetchReader(sql)
        grdGroupContacts.DataBind()

    End Sub

    Protected Sub ddlContactType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlContactType.SelectedIndexChanged
        ob.FillList(cblContacts, "Select ContactID, ContactID + ':' + ContactName as ContactName from jct_sms_contactmaster where status = 'A' and contacttype = '" & ddlContactType.SelectedItem.Text & "'")
        grdContacts.DataSource = Nothing
        grdContacts.DataBind()

    End Sub

    Protected Sub cmdPreviewMsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPreviewMsg.Click
        Dim dt As DataTable = ViewState("Data")
        Dim i As Integer = 0
        For Each item As DataListItem In dlsValues.Items
            dt.Rows(i).Item(1) = CType(item.FindControl("txtValue"), TextBox).Text
        Next

    End Sub

    Protected Sub cmdAddGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddGroup.Click
        GetGroupContacts()

    End Sub

    Protected Sub grdGroupContacts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdGroupContacts.RowCommand

        If e.CommandName = "Remove" Then

            'Dim li As ListItem = cblGroups.Items.FindByValue(e.CommandArgument)
            'li.Selected = False
            ViewState.Add("Excluded", e.CommandArgument)
            'GetGroupContacts()
            'grdContacts.DataBind()
        End If

    End Sub

End Class


'Public Class Contact

'    Private _group As String
'    Public Property Group() As String
'        Get
'            Return _group
'        End Get
'        Set(ByVal value As String)
'            _group = value
'        End Set
'    End Property

'    Private _contactid As String
'    Public Property ContactID() As String
'        Get
'            Return _contactid
'        End Get
'        Set(ByVal value As String)
'            _contactid = value
'        End Set
'    End Property

'    Private _contactname As String
'    Public Property ContactName() As String
'        Get
'            Return _contactname
'        End Get
'        Set(ByVal value As String)
'            _contactname = value
'        End Set
'    End Property

'    Private _mobile As String
'    Public Property Mobile() As String
'        Get
'            Return _mobile
'        End Get
'        Set(ByVal value As String)
'            _mobile = value
'        End Set
'    End Property

'    Private _email As String
'    Public Property Email() As String
'        Get
'            Return _email
'        End Get
'        Set(ByVal value As String)
'            _email = value
'        End Set
'    End Property

'    Private _smsmode As Integer
'    Public Property SMSMode() As Integer
'        Get
'            Return _smsmode
'        End Get
'        Set(ByVal value As Integer)
'            _smsmode = value
'        End Set
'    End Property

'    Private _emailmode As Integer
'    Public Property EmailMode() As Integer
'        Get
'            Return _emailmode
'        End Get
'        Set(ByVal value As Integer)
'            _emailmode = value
'        End Set
'    End Property



'End Class
