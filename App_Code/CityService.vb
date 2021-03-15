Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Data
Imports System.Data.SqlClient
Imports vb = Microsoft.VisualBasic
Imports System.Collections.Generic

<WebService(Namespace:="http://misdev/EmployeePortal")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Script.Services.ScriptService()> _
Public Class CityService
    Inherits System.Web.Services.WebService
    Dim ConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Dim Cn As SqlConnection = New SqlConnection(ConStr)
    <WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Function GetState(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT Distinct state FROM JCTGEN..JCT_EPOR_STATE_MASTER WHERE State LIKE '" & prefixText & "%' "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function
    <WebMethod()> _
    <System.Web.Script.Services.ScriptMethod()> _
    Public Function GetCity(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        Sql = "SELECT City FROM JCTGEN..JCT_EPOR_STATE_MASTER WHERE CITY LIKE '" & prefixText & "%' and state = '" & contextKey & "'"
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function

    <WebMethod()> _
    <System.Web.Script.Services.ScriptMethod()> _
    Public Function GetParentDepartment(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT  distinct b.longdesc  FROM JCTDEV..JCT_Epor_MASTER_Dept a,JCTDEV..JCT_Epor_MASTER_Dept b where a.parentdept=b.dept_code and a.LongDesc LIKE '" & prefixText & "%' and  a.status='A' and  b.status='A'"
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function
    <WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Function GetDepartment(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String

        If contextKey <> "ALL" Then
            Sql = "SELECT  distinct a.longdesc  FROM JCTDEV..JCT_Epor_MASTER_Dept a,JCTDEV..JCT_Epor_MASTER_Dept b where a.parentdept=b.dept_code and b.LongDesc LIKE '" & prefixText & "%' and (b.LongDesc = '" & contextKey & "' or '" & contextKey & "'='' or '" & contextKey & "'='ALL') and a.status='A' and b.status='A'"

        Else
            Sql = "SELECT  distinct longdesc  FROM JCTDEV..JCT_Epor_MASTER_Dept   where  LongDesc LIKE '" & prefixText & "%' and status='A' "
        End If

        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function

    <WebMethod()> _
   <System.Web.Script.Services.ScriptMethod()> _
   Public Function GetDesg(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT LongDesc FROM JCTDEV.. JCT_Epor_MASTER_designation WHERE LongDesc LIKE '" & prefixText & "%' and status='A'  "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function
    <WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Function GetCatg(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT Category FROM JCTDEV.. JCT_Epor_MASTER_designation WHERE   Category LIKE '" & prefixText & "%' and (  longdesc='" & contextKey & "' or '" & contextKey & "'='All' or  '" & contextKey & "'='') and status='A' "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function

    <WebMethod()> _
 <System.Web.Script.Services.ScriptMethod()> _
 Public Function GetDiv(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT Description FROM JCTDEV..Jct_Epor_Div_Area_Master WHERE type='DIV' and Description LIKE '" & prefixText & "%' and status='A' "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function

    <WebMethod()> _
 <System.Web.Script.Services.ScriptMethod()> _
 Public Function GetCard(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT  CardNo FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE     CardNo LIKE '" & prefixText & "%'  and status='A' order by cardno "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
Public Function GetEmpCode(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT  EMP_CODE FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE     EMP_CODE LIKE '" & prefixText & "%' and status='A' order by EMP_CODE "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
   Public Function GetArea(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT Description FROM JCTDEV..Jct_Epor_Div_Area_Master WHERE type='ARE' and Description LIKE '" & prefixText & "%' and status='A' "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function OPS_Customer(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String

        Sql = "SELECT DISTINCT LTRIM(RTRIM(cust_name +'~'+bill_cust_no)) [Customer Code] from MISERP.SHP.DBO.JCT_OPS_ALL_TRACKING where cust_name like '" + prefixText + "%'"
        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
        cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        cn.Close()
        Return Data.ToArray
    End Function
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function OPS_ORDER(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String

        If contextKey <> "" Then
            Sql = "SELECT DISTINCT RTRIM(order_no) AS ORDER_NO       FROM MISERP.SHP.DBO.JCT_OPS_ALL_TRACKING WHERE  (bill_cust_no= '" & contextKey & "' or '" & contextKey & "'='ALL') AND  order_no like '" + prefixText + "%'    "

        Else
            Sql = "SELECT DISTINCT RTRIM(order_no) AS ORDER_NO       FROM MISERP.SHP.DBO.JCT_OPS_ALL_TRACKING WHERE order_no like '" + prefixText + "%'  "
        End If

        Dim Cmd As SqlCommand = New SqlCommand(Sql, Cn)
        Cn.Open()
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        Cn.Close()
        Return Data.ToArray
    End Function
End Class
