Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports Microsoft.VisualBasic

Public Class HelpDeskClass
    Dim constr As String = "Data source = misdev;initial catalog = jctdev;user id = itgrp; password = power"
    Public cn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader

    Public Sub New()
        cn = New SqlConnection(constr)
    End Sub

    Public Sub opencn()
        If cn.State = Data.ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub

    Public Sub closecn()
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function Set_Date() As Date
        Dim qry As String
        qry = "execute common_date_initialize"
        opencn()
        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader()
        dr.Read()
        Set_Date = dr.Item(0)
        dr.Close()
        closecn()

    End Function
End Class
