Imports System.Data.SqlClient
Imports System.Data.Sqltypes
Imports System
Imports Microsoft.VisualBasic

Public Class ExportClass
    Dim constr As String = "Data source = misdev;initial catalog = jctdev;user id = itgrp; password = power; connect timeout=0"
    Public cn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim qry As String
    Public Var As String

    Public Sub New()
        cn = New SqlConnection(constr)
    End Sub

    Public Sub opencn()
        If cn.State = Data.ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub

    Public Sub closecn()
        cn.Close()
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

    Public Sub Disable_Buttons(ByVal btn As LinkButton)
        btn.Enabled = False
        btn.CssClass = "buttondisable"
    End Sub

    Public Sub Enable_Buttons(ByVal btn As LinkButton)
        btn.Enabled = True
        btn.CssClass = "buttonc"
    End Sub
    Public Function GetCurrentPageName() As String
        Dim sPath As String = System.Web.HttpContext.Current.Request.Url.AbsolutePath
        Dim oInfo As System.IO.FileInfo = New System.IO.FileInfo(sPath)
        Dim sRet As String = oInfo.Name
        Return sRet
    End Function
    Public Function IsBlankNumeric(ByVal a As String)

        If Trim(a) = "" Then
            Return -50
            'Return SqlInt32.Null
        Else
            Return a
        End If
    End Function
    Public Function IsToDt(ByVal a As String)
        If Trim(a) = "" Then
            Return "12/12/3000"
        Else
            Return a
        End If
    End Function
    Public Function IsFromDt(ByVal a As String)
        If Trim(a) = "" Then
            Return "01/01/1900"
        Else
            Return a
        End If
    End Function
    Public Function IsDt(ByVal a As String)
        If Trim(a) = "1/1/1900" Then
            Return ""
        Else
            Return a
        End If
    End Function
    Public Function IsFromStr(ByVal a As String)
        If Trim(a) = "" Or Trim(a) = "[All]" Then
            Return ""
        Else
            Return a
        End If
    End Function
    Public Function IsToStr(ByVal a As String)
        If Trim(a) = "" Or Trim(a) = "[All]" Then
            Return "ZZZZZZZZZZZZZZZZZZZZ"
        Else
            Return a
        End If
    End Function
    Public Function IsFiftyToBlank(ByVal a As String)
        If Trim(a) = "-50.00" Then
            Return ""
        Else
            Return a
        End If
    End Function
    Public Function IsValNull(ByVal a As Object)
        If a Is System.DBNull.Value Then
            Return ""
        Else
            Return a
        End If
    End Function

    Public Function IfExist(ByVal tbl As String, ByVal TransNo As Integer) As Integer
        opencn()
        qry = "select * from " & tbl & " where Trans_No = " & TransNo & " and status=''"
        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Close()
            closecn()
            Return 1
        Else
            dr.Close()
            closecn()
            Return 0
        End If
        
    End Function

End Class

