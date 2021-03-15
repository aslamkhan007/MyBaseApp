Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Connection
    Dim ConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdevDocMgmt").ConnectionString
    Dim Conn As SqlConnection
    Dim Cmd, Cmd1 As SqlCommand
    Dim Dr, Dr1 As SqlDataReader
    Dim SqlPass As String

    Public Sub New()
        Conn = New SqlConnection(ConStr)
    End Sub

    Public Function Connection() As SqlConnection
        Return Conn
    End Function

    Public Function FetchReader(ByVal Sql As String) As SqlDataReader

        Cmd = New SqlCommand(Sql, Conn)
        Try
            ConOpen()
            Dr = Cmd.ExecuteReader()
            Return Dr
        Catch ex As Exception
            Return Dr
            'MsgBox(ex.Message)
        End Try

    End Function

    Public Sub ConOpen()
        Try
            If (Conn.State = Data.ConnectionState.Closed) Then
                Conn.Open()
            End If
        Catch ex As Exception
            'MsgBox("Error in Establishing Database Connection")
        End Try
    End Sub

    Public Sub ConClose()
        Try
            If (Conn.State = Data.ConnectionState.Open) Then
                Conn.Close()
            End If
        Catch ex As Exception
            'MsgBox("Error in Closing Database Connection")
        End Try
    End Sub
    
    Public Sub fillList(ByVal cbl As DropDownList, ByVal sql As String)
        Dim cn As SqlConnection = New SqlConnection(ConStr)
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                Dim li As New ListItem
                li.Value = dr.Item(0)
                li.Text = dr.Item(1)
                cbl.Items.Add(li)
            End While
        End If
        cn.Close()
    End Sub

End Class

