Imports System.Data
Imports System.Data.SqlClient

Partial Class SMSLive_MessagingGroups
    Inherits System.Web.UI.Page
    Dim ob As New Functions

    Protected Sub cmdCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        Dim sql As String = "insert into jct_sms_messaging_groups (CompanyCode,UserCode,GroupID,GroupName,CreatedDt,Status) values('" & Session("CompanyCode") & "', '" & Session("EmpCode") & "', '" & txtGroupCode.Text & "', '" & txtGroupName.Text & "',getdate(),'A')"
        ob.InsertRecord(sql)
        lstGroups.DataBind()
    End Sub

    Protected Sub ddlContactType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlContactType.SelectedIndexChanged
        'SqlAllContacts.SelectCommand = "select ContactId, ContactName from jct_sms_contactmaster where status = 'A' and contacttype = '" & ddlContactType.SelectedValue & "'"
        'cblContacts.DataSource = SqlAllContacts
        ''cblContacts.DataTextField = "ContactName"
        ''cblContacts.DataValueField = "ContactID"
        'cblContacts.DataBind()

    End Sub

    Protected Sub ddlGroups_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGroups.SelectedIndexChanged

        lblGroupName.Text = lstGroups.SelectedItem.Text
        cblContacts.Enabled = True
        cblContacts.DataBind()

    End Sub

    Protected Sub cmdAddItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddItems.Click

        Dim arr As ArrayList = New ArrayList
        Dim li As New ListItem
        For Each li In cblContacts.Items
            If li.Selected Then
                cblNewContacts.Items.Add(li)
                arr.Add(li)
            End If
        Next

        For Each arrli As ListItem In arr
            If cblContacts.Items.Contains(arrli) Then
                cblContacts.Items.Remove(arrli)
            End If
        Next

        'For i As Integer = 1 To cblContacts.Items.Count - 1
        '    Dim li As New ListItem
        '    If i <= cblContacts.Items.Count - 1 Then
        '        If cblContacts.Items(i).Selected Then
        '            cblNewContacts.Items.Add(cblContacts.Items(i))
        '            cblContacts.Items.RemoveAt(i)
        '            i -= 1
        '        End If
        '    End If
        'Next

    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Dim ob As New Connection
        Dim tr As SqlTransaction = ob.Connection().BeginTransaction()
        Try
            For Each li As ListItem In cblNewContacts.Items
                Dim sql As String
                sql = "insert jct_sms_group_members (CompanyCode, UserCode, ContactID, GroupID, CreatedDt, Status)" & _
                                "values('" & Session("CompanyCode") & "','" & Session("EmpCode") & "','" + li.Value + "','" + lstGroups.SelectedValue + "',getdate(),'A')"
                Dim cmd As SqlCommand = New SqlCommand(sql, ob.Connection)
                cmd.Transaction = tr
                cmd.ExecuteNonQuery()
            Next
            tr.Commit()
            cblNewContacts.Items.Clear()
            lblMessage.Text = "Contacts Assigned to Group"

            cblGroupContacts.DataBind()
        Catch ex As Exception
            tr.Rollback()
            lblMessage.Text = "Error Occured: " & ex.Message
        End Try

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim arr As ArrayList = New ArrayList
        Dim li As New ListItem
        For Each li In cblNewContacts.Items
            If li.Selected Then
                arr.Add(li)
            End If
        Next

        For Each arrli As ListItem In arr
            If cblNewContacts.Items.Contains(arrli) Then
                cblNewContacts.Items.Remove(arrli)
            End If
        Next



    End Sub

End Class
