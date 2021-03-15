Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient

<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService
    Dim constr As String = "data source = misdev; initial catalog = jctdev; user id = itgrp; password = power"
    Dim cn As SqlConnection = New SqlConnection(constr)
    Dim qry As String
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim i As Integer
    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    <System.Web.Script.Services.ScriptMethod()> _
    Public Function GetParentCatg(ByVal prefixText As String, ByVal count As Integer) As String()
        qry = "select shortdesc + '-->' + isnull(parentcatg,'') + catg from JCT_DMS_Master_Category where shortdesc + parentcatg + catg like '%" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
        cn.Open()
        dr = cmd.ExecuteReader()
        Dim data As New List(Of String)()
        While dr.Read()
            data.Add(dr.Item(0).ToString)
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function

    <WebMethod()> _
   <System.Web.Script.Services.ScriptMethod()> _
   Public Function GetEmpName(ByVal prefixText As String, ByVal count As Integer) As String()
        qry = "select distinct empname from jct_empmast_base a, JCT_DMS_Trans_Upload b where a.empcode=b.empcode and active='y' and empname like '%" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
        cn.Open()
        dr = cmd.ExecuteReader()
        Dim data As New List(Of String)()
        While dr.Read()
            data.Add(dr.Item(0).ToString)
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function
End Class
