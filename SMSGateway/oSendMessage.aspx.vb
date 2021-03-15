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

    End Sub

    Protected Sub cmdSendMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSendMessage.Click
        Dim contacts As String = ""
        Dim c As Integer
        For Each row As GridViewRow In grdContacts.Rows
            If c = 0 Then
                contacts += row.Cells(3).Text
                c += 1
            Else
                contacts += "," + row.Cells(3).Text
            End If

        Next

        Dim client As New smscountry.Service
        'client.SendTextSMS("JCTLTD", "jct@147", "919878649707", TextBox2.Text, "JCTLTD")

        Dim result As String = ""

        If txtTo.Text <> "" AndAlso grdContacts.Rows.Count > 0 Then
            contacts += "," + txtTo.Text
        ElseIf txtTo.Text <> "" AndAlso grdContacts.Rows.Count = 0 Then
            contacts = txtTo.Text
        End If

        If contacts <> "" Then
            'result = client.SendTextSMS("JCTLTD", "jct@147", contacts, txtMessageText.Text, "JCTLTD")
            Dim sm As New SendMail
            result = sm.SendSMS("JCT00LTD", Session("EmpCode"), contacts, txtMessageText.Text, ddlSubject.Text)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scr", "<script language = javascript> alert('No Contact Selected or Specified in To Box')</script>", False)
        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scr", "<script language = javascript> alert('Message Sent Successfuly to " & contacts & " with transaction id " & result & ".') </script>", False)

    End Sub

    Protected Sub cblContacts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cblContacts.SelectedIndexChanged
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
        Dim sql As String = "select ContactID, ContactName, MobileNo, EmailAddress, smsmode, emailmode from jct_sms_contactmaster where status = 'A' and contactid in (" & contacts & ")"
        Dim dr As SqlDataReader = ob.FetchReader(sql)

        'If dr.HasRows = True Then
        '    While dr.Read
        '        grdContacts.ToolTip = dr(0)
        '        'Response.Write(dr(0) + "<br/>")
        '    End While
        'End If

        grdContacts.DataSource = ob.FetchReader(sql)
        grdContacts.DataBind()
        'ScriptManager.RegisterClientScriptBlock(Me, e.GetType, "Scr", "<script language = 'javascript'> alert('" & contacts & "') </script>", False)

    End Sub

    Protected Sub grdContacts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdContacts.RowCommand

        If e.CommandName = "Remove" Then

            Dim li As ListItem = cblContacts.Items.FindByValue(e.CommandArgument)
            li.Selected = False
            cblContacts_SelectedIndexChanged(sender, Nothing)
            'grdContacts.DataBind()
        End If

    End Sub

End Class
