Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System

Public Class Connection
    Dim ConStr As String = "Password= power; Persist Security Info=True; User ID= ITGRP ; Connection TimeOut=0; Initial Catalog=jctdev; Data Source=Misdev;"
    Dim Conn As SqlConnection
    Dim Cmd, Cmd1 As SqlCommand
    Dim Dr, Dr1 As SqlDataReader

    Public Sub New()
        Conn = New SqlConnection(ConStr)
    End Sub

    Public Function Connection() As SqlConnection
        Return Conn
    End Function
    Public Sub ExecQry(ByVal str As String)
        Dim cmd As SqlCommand
        ConOpen()
        cmd = New SqlCommand(str, Connection())
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        ConClose()
    End Sub

    Public Function FetchReader(ByVal Sql As String) As SqlDataReader

        Cmd = New SqlCommand(Sql, Conn)
        Try
            ConOpen()
            Dr = Cmd.ExecuteReader()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Return Dr
    End Function
    Public Function FetchReader1(ByVal Sql As String) As SqlDataReader

        Cmd1 = New SqlCommand(Sql, Conn)
        Try
            ConOpen()
            Cmd1.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Return Dr
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

   
End Class

