Imports System.Data.SqlClient
Imports System.Data
Partial Class SMSGateway_SMS_Report
    Inherits System.Web.UI.Page
    Dim ofn As Functions = New Functions
    Dim arr(11) As String
    Dim sql As String
   
     
    Public Sub New()
        arr(0) = "Message In Queue"
        arr(1) = "Submitted To Carrier"
        arr(2) = "UnDelivered"
        arr(3) = "Delivered"
        arr(4) = "Expired"
        arr(8) = "Rejected"
        arr(9) = "Message Sent"
        arr(10) = "Opted Out"
        arr(11) = "Invalid Number"
      
       
        '1 - Submitted To Carrier
        '2 - Un Delivered
        '3 – Delivered
        '4 – Expired
        '8 – Rejected
        '9 – Message Sent
        '10 – Opted Out Mobile Number
        '11 – Invalid Mobile Number
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
     
        If Not IsPostBack Then
            sql = "Select distinct Subject,subject from jct_sms_sentsms_log "
            ofn.FillList(ddlSubject, sql)
        End If

    End Sub

    Protected Sub lnkReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkReport.Click
        Dim table As New DataTable("TestData")
        Dim c1 As New DataColumn("Mobile No", GetType(String))
        Dim c2 As New DataColumn("Code", GetType(String))
        Dim c3 As New DataColumn("Date", GetType(String))
        Dim c4 As New DataColumn("Status", GetType(String))
        Table.Columns.Add(c1)
        Table.Columns.Add(c2)
        Table.Columns.Add(c3)
        Table.Columns.Add(c4)
        If (ddlSubject.Text <> "" And txtDate.Text <> "") Then
            sql = "select smsid from jct_sms_sentsms_log where subject ='" & ddlSubject.SelectedItem.Text & "' and smsdate=" & Trim(txtDate.Text) & ""
        ElseIf txtDate.Text <> "" Then
            sql = "select smsid from jct_sms_sentsms_log where smsdate ='" & txtDate.Text & "' "
        ElseIf ddlSubject.Text <> "" Then
            sql = "select smsid from jct_sms_sentsms_log where subject ='" & ddlSubject.SelectedItem.Text & "'"
        End If
        Dim dr As SqlDataReader
        dr = ofn.FetchReader(sql)
        If dr.HasRows = True Then
            While dr.Read
                Dim sm As New SendMail
                Dim str As String = sm.GetDeliveryStatus(dr(0))
                If str.Equals("0") Then
                    Dim row As DataRow = table.NewRow
                    table.Columns(0).ColumnName = "SMSID"
                    row(0) = dr(0)
                    row(1) = str
                    row(2) = "No Status Available"
                    row(3) = "No Status Available"
                    table.Rows.Add(row)
                End If
                If str.Contains(",") Then
                    Dim str1() As String = str.Split(",")
                    Dim i As Integer = 0
                    For Each s In str1
                        Dim row As DataRow = table.NewRow()
                        row(0) = s.Split("-").GetValue(0)
                        row(1) = s.Split("-").GetValue(1)
                        row(2) = s.Split("-").GetValue(2)
                        Dim j As Integer = row(1)
                        row(3) = arr(j)
                        table.Rows.Add(row)
                    Next
                End If
                If str.Contains("-") And Not str.Contains(",") Then
                    Dim str2() As String = str.Split("-")
                    ' Dim s As String
                    Dim i As Integer = 0
                    Dim row As DataRow = table.NewRow()
                    row(0) = str2(0)
                    row(1) = str2(1)
                    row(2) = str2(2)
                    Dim j As Integer = row(1)
                    row(3) = arr(j)
                    table.Rows.Add(row)
                End If
            End While
            grdReport.DataSource = table
            grdReport.DataBind()
            grdReport.Visible = True
        End If

    End Sub
    'Protected Sub GetreportData(ByVal str As String)
    '    If str.Contains(",") Then
    '        Dim str1() As String = str.Split(",")
    '        For Each s In str1
    '            Dim row As DataRow = table.NewRow()
    '            row(0) = s.Split("-").GetValue(0)
    '            row(1) = s.Split("-").GetValue(1)
    '            row(2) = s.Split("-").GetValue(2)
    '            Dim i As Integer = row(1)
    '            row(3) = arr(i)
    '            table.Rows.Add(row)
    '        Next
    '    Else
    '        Dim str2() As String = str.Split("-")

    '        Dim row As DataRow = table.NewRow()
    '        If str2(0) = 0 Then
    '            row(0) = "No Status Available"
    '            grdReport.DataSource = table
    '            grdReport.DataBind()
    '            Exit Sub
    '        Else
    '            row(0) = str2(0)
    '        End If
    '        row(1) = str2(1)
    '        row(2) = str2(2)
    '        Dim i As Integer = row(1)
    '        row(3) = arr(i)
    '        table.Rows.Add(row)
    '    End If
    '    grdReport.DataSource = table
    '    grdReport.DataBind()
    '    grdReport.Visible = True
    'End Sub
    Protected Sub grdReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdReport.RowDataBound

    End Sub
End Class
