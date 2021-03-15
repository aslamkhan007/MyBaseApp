Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Data
Imports System.Data.SqlClient
Imports vb = Microsoft.VisualBasic
Imports System.Collections.Generic

<WebService(Namespace:="http://misdev/costingsystemtest")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Script.Services.ScriptService()> _
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
   Public Function ExpGetCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()

        'Dim emp As ArrayList = New ArrayList()
        Dim constr As String = "data source = misdev; initial catalog = jctdev; user id = itgrp; password = power"
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim sql As String
        'sql = "Select convert(varchar(5),Mapping_code) + ' - ' + description from JCT_cst_mapping_master where status=''"
        If UCase(contextKey) = "F" Then
            sql = "select distinct FinalInvNo from jctdev..JCT_EXP_FinalInv_Mapping where status ='' and FinalInvNo not in (select InvoiceNo from jctdev..JCT_EXP_FinalInv_Mapping where status ='' and flag in ('f')) and Finalinvno like '" & Trim(prefixText) & "%'"
        ElseIf UCase(contextKey) = "B" Then
            sql = "Select ltrim(rtrim(invoice_no)) from miserp.ardb.dbo.dms_t_invoice_hdr where invoice_dt between getdate()-300 and getdate() and invoice_no not in (select InvoiceNo from jctdev..JCT_EXP_FinalInv_Mapping where status ='' and flag in ('p')) and invoice_no like '" & Trim(prefixText) & "%'"
        ElseIf UCase(contextKey) = "P" Then
            sql = "Select ltrim(rtrim(invoice_no)) from miserp.ardb.dbo.dms_t_invoice_hdr where invoice_dt between getdate()-300 and getdate() and invoice_no not in (select InvoiceNo from jctdev..JCT_EXP_FinalInv_Mapping where status ='' and flag in ('p','b')) and invoice_no like '" & Trim(prefixText) & "%'"
        End If

        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        'emp.Clear()
        'Dim arr(10) As String
        Dim data As New List(Of String)()
        While dr.Read
            data.Add(dr.Item(0).ToString)
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function

'Public Function GetSampleProcessDetail(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    '        If contextKey.Equals("DevNo") Then
    '            qry = "SELECT DISTINCT a.DevNo FROM    dbo.JCT_Sample_Process_Trials a INNER JOIN dbo.JCT_Sample_Process_Trans b ON a.Status = b.Status AND a.DevNo = b.DevNo AND a.TrialNo = b.TrialNo WHERE   a.Status = 'A' and a.DevNo like '" & prefixText & "%'"
    '        ElseIf contextKey.Equals("SortNo") Then
    '            qry = "SELECT DISTINCT a.SortNo FROM    dbo.JCT_Sample_Process_Trials a INNER JOIN dbo.JCT_Sample_Process_Trans b ON a.Status = b.Status AND a.DevNo = b.DevNo AND a.TrialNo = b.TrialNo WHERE   a.Status = 'A'  AND a.SortNo >= " & prefixText & ""
    '        ElseIf contextKey.Equals("OrderNo") Then
    '            qry = "SELECT DISTINCT a.OrderNo FROM    dbo.JCT_Sample_Process_Trials a INNER JOIN dbo.JCT_Sample_Process_Trans b ON a.Status = b.Status AND a.DevNo = b.DevNo AND a.TrialNo = b.TrialNo WHERE   a.Status = 'A'  AND a.OrderNo like '" & prefixText & "%' "
    '        ElseIf contextKey.Equals("Customer") Then
    '            qry = "SELECT DISTINCT a.Customer FROM    dbo.JCT_Sample_Process_Trials a INNER JOIN dbo.JCT_Sample_Process_Trans b ON a.Status = b.Status AND a.DevNo = b.DevNo AND a.TrialNo = b.TrialNo WHERE   a.Status = 'A'  AND a.Customer LIKE '" & prefixText & "%' "
    '        End If
    '        Dim Cmd As SqlCommand = New SqlCommand(qry, cn)
    '        cn.Open()
    '        Dim Dr As SqlDataReader = Cmd.ExecuteReader
    '        Dim i As Integer = 0
    '        Dim Data As New List(Of String)()
    '        While Dr.Read
    '            Data.Add(Dr.Item(0).ToString)
    '            i += 1
    '        End While
    '        cn.Close()
    '        Return Data.ToArray
    '    End Function
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function GetSampleProcessDetail(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        If contextKey.Equals("DevNo") Then
            qry = "SELECT DISTINCT a.DevNo FROM    dbo.JCT_Sample_Process_Trials a  WHERE   a.Status = 'A' and a.DevNo like '" & prefixText & "%'"
        ElseIf contextKey.Equals("SortNo") Then
            qry = "SELECT DISTINCT a.SortNo FROM    dbo.JCT_Sample_Process_Trials a  WHERE   a.Status = 'A'  AND a.SortNo >= " & prefixText & " "
        ElseIf contextKey.Equals("OrderNo") Then
            qry = "SELECT DISTINCT a.OrderNo FROM    dbo.JCT_Sample_Process_Trials a WHERE   a.Status = 'A'  AND a.OrderNo like '" & prefixText & "%' "
        ElseIf contextKey.Equals("Customer") Then
            qry = "SELECT DISTINCT a.Customer FROM    dbo.JCT_Sample_Process_Trials a  WHERE   a.Status = 'A'  AND a.Customer LIKE '" & prefixText & "%' "
        End If
        Dim Cmd As SqlCommand = New SqlCommand(qry, cn)
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
    Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer) As System.String()
        'Dim emp As ArrayList = New ArrayList()
        Dim sql As String
        sql = "Select convert(varchar(5),Mapping_code)  from JCT_cst_mapping_master where status=''"
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        'emp.Clear()
        'Dim arr(10) As String
        Dim data As New List(Of String)()
        While dr.Read
            data.Add(dr.Item(0).ToString)
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function

    <WebMethod()> _
       <System.Web.Script.Services.ScriptMethod()> _
       Public Function GetCompletionList1(ByVal prefixText As String, ByVal count As Integer) As System.String()
        '        Dim constr As String = "data source = miserp; initial catalog = jctdev; user id = itgrp; password = power"
        '        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim sql As String
        sql = "Select description from JCT_cst_mapping_master where description like '" & prefixText & "%' and status<>'D'"
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        'emp.Clear()
        'Dim arr(10) As String
        Dim data As New List(Of String)()
        While dr.Read
            data.Add(dr.Item(0).ToString)
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function

    <WebMethod()> _
      <System.Web.Script.Services.ScriptMethod()> _
      Public Function GetMappingProc(ByVal prefixText As String, ByVal count As Integer) As System.String()
        '        Dim constr As String = "data source = miserp; initial catalog = jctdev; user id = itgrp; password = power"
        '        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim sql As String
        sql = "Sp_objects '" & prefixText & "',p"
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = 0
        'emp.Clear()
        'Dim arr(10) As String
        Dim data As New List(Of String)()
        While dr.Read
            data.Add(dr.Item(0).ToString)
            i += 1
        End While
        'Return Item(0).ToArray()
        cn.Close()
        Return data.ToArray
        ' ''Dim dt As New System.Data.DataTable

        ' ''adp.Fill(dt)

        ' ''Dim items As New List(Of String)

        ' ''For i As Integer = 0 To dt.Rows.Count

        ' ''    Dim datafile

        ' ''    datafile = UCase(dt.Rows(i).Item("RecMerk"))

        ' ''    i += 1

        ' ''    items.Add(datafile)

        ' ''Next
    End Function

    <WebMethod()> _
     <System.Web.Script.Services.ScriptMethod()> _
     Public Function GetFinYear(ByVal prefixText As String, ByVal count As Integer) As System.String()
        '        Dim constr As String = "data source = miserp; initial catalog = jctdev; user id = itgrp; password = power"
        '        Dim cn As SqlConnection = New SqlConnection(constr)
        'To Be Used In sub Group Mapping
        Dim sql As String, TempAppend As String, Fin As String
        sql = "select right(ltrim(rtrim(fs_description)),4) from fms..fs_accounting_period where fin_yr_code >= '10' and acc_prd_code = '01' order by fin_yr_code"
        'sql = "Sp_objects '" & prefixText & "',u"
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        Dim data As New List(Of String)()
        While dr.Read
            TempAppend = vb.Right(dr.Item(0), 2)
            TempAppend = CStr(CInt(TempAppend) + 1)
            If Len(TempAppend) = 1 Then
                TempAppend = " - 0" & TempAppend
            Else
                TempAppend = " - " & TempAppend
            End If
            Fin = dr.Item(0) & TempAppend
            'cboYear.Items.Add(dr.Item(0) & TempAppend)
            data.Add(Fin)
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function

    <WebMethod()> _
    <System.Web.Script.Services.ScriptMethod()> _
    Public Function GetAccountNo(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim sql As String
        If contextKey = "ALL" Then
            sql = "select account_no from reportdb..contribution_gl_cost_mapping_new where glsubc not in (select std_name from jct_cst_standard_master where status='') and account_no not in (select type_no from jct_cst_subgroup_mapping)  order by glsubc"
        Else
            sql = "select account_no from reportdb..contribution_gl_cost_mapping_new where glsubc not in (select std_name from jct_cst_standard_master where status='') and account_no not in (select type_no from jct_cst_subgroup_mapping) and glsubc='" & contextKey & "' order by glsubc"
        End If

        'sql = "Sp_objects '" & prefixText & "',u"
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        Dim data As New List(Of String)()
        While dr.Read
            data.Add(dr.Item(0).ToString)
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function

    Function GetIPAddress(ByVal CompName As String) As String
        Dim oAddr As System.Net.IPAddress
        Dim sAddr As String
        With System.Net.Dns.GetHostEntry(CompName)
            oAddr = New System.Net.IPAddress(.AddressList(0).Address)
            sAddr = oAddr.ToString
        End With
        GetIPAddress = sAddr
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
    '-----------------------------------------------------------
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
    Public Function GetCountryList(ByVal prefixText As String, ByVal count As Integer) As String()
        qry = "  SELECT CountryName AS Country FROM jctgen.dbo.JCT_EPOR_COUNTRYNAME where countryname like '%" & prefixText & "%'"
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
    Public Function Jct_Payroll_State_List(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT  DISTINCT  STATE AS State  FROM    JCTGEN..JCT_EPOR_STATE_MASTER where state like '%" + prefixText + "%'ORDER BY State"
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
    Public Function Jct_Payroll_City_List(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT  DISTINCT  City  FROM JCTGEN..JCT_EPOR_STATE_MASTER where city like '%" + prefixText + "%'ORDER BY City"
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
   Public Function GetEmployeeName(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        'Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT DISTINCT empname + ' : ' + empcode as FullName FROM JCTDEV..jct_empmast_base WHERE empname LIKE '" & prefixText & "%' and active='Y' and (dol is null or dol<getdate()) and Company_Code =  '" & contextKey & "' order by FullName "
        SQL = "SELECT  empname + ' : ' + empcode AS FullName FROM    JCTDEV..JCT_EmpMast_Base WHERE   empname LIKE '" & prefixText & "%' AND Active = 'Y' AND ( DOL IS NULL OR DOL < GETDATE()  ) AND Company_Code = '" & contextKey & "' ORDER BY empname "
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
Public Function GetEmployeeName1(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT Fullname + '#' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate()) order by FullName "
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
    <WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Function GetItems(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        qry = contextKey
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
    '''Add this Service by Hitesh on 9/Jan/2010
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
Public Function GetProceduredUsedInEvaluator(ByVal prefixText As String, ByVal count As Integer) As String()
        qry = "SELECT NAME FROM SYSOBJECTS WHERE NAME like '%" & prefixText & "%'"
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
Public Function GetCustomer_For_Labdip(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        qry = "select cust_name + ':-' +  rtrim(ltrim(cust_no))   from miserp.som.dbo.m_customer where cust_no like '%" & contextKey & "%' and cust_name like '" & prefixText & "%'  union select customer + ':-' + convert(varchar(5),transno) from misdev.production.dbo.JCT_Process_Lab_Dip_Cust_Master where (status<>'D' or status is null) and transno like '%" & contextKey & "%' and customer like '" & prefixText & "%' "
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
Public Function GetCustomer_For_Labdip_Param_Report(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select customer + ':-' +  rtrim(ltrim(customercode))   from production..jct_process_lab_dip_master  where customercode like '%" & contextKey & "%' and customer like '" & prefixText & "%' and (status<>'D' or status is null)  "
        cmd = New SqlCommand(qry, cn)
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
Public Function Get_shade_code_for_lab_final_rpt(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select distinct description   from production..jct_temp_filter_for_labdip_finalrpt  where description like '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
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
Public Function Get_RefNo_for_lab_final_rpt(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select distinct labdiprefno   from production..jct_temp_filter_for_labdip_finalrpt  where labdiprefno like '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
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
Public Function Get_ColorFast_for_lab_final_rpt(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select distinct colorfast   from production..jct_temp_filter_for_labdip_finalrpt  where colorfast like '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
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
Public Function Get_Blend_for_lab_final_rpt(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select description + '|' + convert(varchar(5),transno)  from production..JCT_PROCESS_LAB_DIP_BLEND_MASTER where status ='' and description like '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
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
Public Function Get_shadefamily_for_lab_final_rpt(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select distinct shade_name + '|' + shade_code from production..JCT_PROCESS_LAB_DIP_SHADE_MASTER where (status<>'D' or status is null) and shade_name like '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
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
Public Function GetCustomer_For_Labdip_Final_Report1(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select distinct rtrim(ltrim(customercode)) + '~' + rtrim(ltrim(customer)) from production..jct_process_lab_dip_request where customercode like '" & prefixText & "%' and (status<>'D' or status is null) and groupleader like '" & contextKey & "%' order by rtrim(ltrim(customercode)) + '~' + rtrim(ltrim(customer))"
        cmd = New SqlCommand(qry, cn)
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
Public Function GetCustomer_For_Labdip_Final_Report2(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select distinct rtrim(ltrim(customer)) + '~' + rtrim(ltrim(customercode)) from production..jct_process_lab_dip_request where customer like '" & prefixText & "%' and (status<>'D' or status is null) and groupleader like '" & contextKey & "%' order by rtrim(ltrim(customer)) + '~' + rtrim(ltrim(customercode))"
        cmd = New SqlCommand(qry, cn)
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
Public Function GetLeader_For_Labdip_Final_Report(ByVal prefixText As String, ByVal count As Integer) As String()
        cn.Open()
        qry = "select distinct groupleader from production..jct_process_lab_dip_request where (status<>'D' or status is null) and groupleader like '" & prefixText & "%' order by groupleader"
        cmd = New SqlCommand(qry, cn)
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
Public Function Customer_For_ExportDoc_Logistic_Report(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select '[All]'  union select buyer + '~' + custcode from jct_exp_finalinv_header where status<>'d' and buyer like '" & prefixText & "%' and (salep like '" & contextKey & "%' or '" & contextKey & "' = '[All]')   order by 1 desc"
        cmd = New SqlCommand(qry, cn)
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
Public Function Destination_For_ExportDoc_Logistic_Report(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select '[All]' as destination union select destination from jct_exp_finalinv_header where status<>'d' and (buyer like '" & contextKey & "%' or '" & contextKey & "' = '[All]' ) and destination like '" & prefixText & "%' order by 1 desc"
        cmd = New SqlCommand(qry, cn)
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
Public Function SaleP_For_ExportDoc_Logistic_Report(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select '[All]' as group_desc union select group_desc from miserp.som.dbo.m_cust_group where group_type='salesp' and status='o' and company_no='jct00ltd' and locn_no='phg' and control_grp_flag=1 and group_desc like '" & prefixText & "%' order by 1 desc"
        cmd = New SqlCommand(qry, cn)
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
Public Function Performa_InvNo_For_ExportDoc_Logistic_Report(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select finalinvno from jct_exp_finalinv_mapping where flag='p' and status='' and finalinvno like '" & prefixText & "%' "
        cmd = New SqlCommand(qry, cn)
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
Public Function InvNo_For_ExportDoc_Logistic_Report(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select finalinvno from jct_exp_finalinv_mapping where flag='f' and status='' and invoiceno like '" & prefixText & "%' "
        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader()
        Dim data As New List(Of String)()
        While dr.Read()
            data.Add(dr.Item(0).ToString)
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function
    '''''''''''''''''''''''   WebMethods Added For Sample Development Application By Neha on 5th May 2010 ''''''''''''''''''''''''''''''''

    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
Public Function GetOrders(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        If contextKey = "ALL" Then
            qry = "select distinct order_no from production..pro_temp1 where order_no like '%" & prefixText & "%'  order by order_no"
        Else
            qry = "select distinct orderno from JCT_Sample_Process_Trials where orderno like '" & prefixText & "%'  AND Status<>'d'   order by orderno"
        End If
        cmd = New SqlCommand(qry, cn)
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
    Public Function GetShadesAll(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select distinct attb_value from production..pro_temp1 where order_no like '%" & contextKey & "%' and attb_code='shade1' and attb_value like '" & prefixText & "%' order by attb_value"
        cmd = New SqlCommand(qry, cn)
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
    Public Function GetShadesTrials(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select distinct Shade from JCT_Sample_Process_Trials where orderno like '%" & contextKey & "%' and shade like '" & prefixText & "%' order by shade"
        cmd = New SqlCommand(qry, cn)
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
    Public Function GetCustomerTrials(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        cn.Open()
        qry = "select distinct Customer from JCT_Sample_Process_Trials where orderno like '%" & contextKey & "%' and shade like '" & prefixText & "%' order by shade"
        cmd = New SqlCommand(qry, cn)
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
Public Function GetTranno(ByVal prefixText As String, ByVal count As Integer) As System.String()
        cn.Open()
        ''qry = "select distinct Shade from JCT_Sample_Process_Trials where orderno like '%" & contextKey & "%' and shade like '" & prefixText & "%' order by shade"
        qry = "select 'T'+ltrim(rtrim(a.tran_no)) " & _
        "from jct_pp_forecast_detail a " & _
        "where upper(ltrim(rtrim(status))) not in ('C','S','F') " & _
       "and a.tran_no like '%" & prefixText & "%' " & _
        "order by a.tran_no "

        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader()

        Dim data As New List(Of String)()

        While dr.Read()
            If i < 2000 Then
                data.Add(dr.Item(0).ToString)
                i += 1
            End If
        End While

        cn.Close()
        Return data.ToArray

    End Function

    '''''''''''''''''''''''   WebMethods For Sample Development Application Ends Here  ''''''''''''''''''''''''''''''''
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
  Public Function GetEmployeeName_for_rights(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT Fullname + '  :  ' + b.longdesc + '  :  ' + a.Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE a, JCT_Epor_MASTER_Dept$ b  WHERE FullName LIKE '" & prefixText & "%' and a.status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and a.Company_Code = '" & contextKey & "' and a.dept_code=b.dept_code union select uname as [FullName] from production..user_master where uname LIKE '" & prefixText & "%' order by FullName "
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
Public Function GetSono(ByVal prefixText As String, ByVal count As Integer) As System.String()
        cn.Open()

        qry = "select distinct a.order_no " & _
        "from miserp.som.dbo.t_order_hdr a " & _
        "where a.status IN ('A','O') " & _
        "and a.order_dt between dateadd(mm,-6,convert(datetime,convert(varchar(11),getdate()))) " & _
        "and convert(datetime,convert(varchar(11),getdate())) " & _
        "and a.order_no like '%" & prefixText & "%' " & _
        "order by a.order_no "

        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader()

        Dim data As New List(Of String)()

        While dr.Read()
            If i < 2000 Then
                data.Add(dr.Item(0).ToString)
                i += 1
            End If
        End While

        cn.Close()
        Return data.ToArray

    End Function
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
Public Function Get_Univ(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select board_univ_name from JCT_EPor_Board_Univ_Master WHERE status<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0    and board_univ_name like '" & prefixText & "%' union select univ_name from JCT_Epor_Professional_Qualification_Detail WHERE status<>'D' and univ_name like '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
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
Public Function Get_Inst(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select inst_name  from JCT_EPOR_inst_master WHERE status<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0    and inst_name like '" & prefixText & "%' union select distinct institute from JCT_Epor_Professional_Qualification_Detail where status='A' and institute like '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
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
Public Function Get_Tech(ByVal prefixText As String) As String()
        cn.Open()
        qry = "select rtrim(ltrim(Technology_name))  from JCT_Epor_technology_master WHERE status<>'D' AND DateDiff(DD,GETDATE(),EFF_TO)>=0    and Technology_name like '" & prefixText & "%' union select distinct rtrim(ltrim(technology)) from JCT_Epor_Skill_Detail where technology like '" & prefixText & "%' and status='A' union select distinct rtrim(ltrim(skill)) from JCT_Epor_Skill_Detail where skill like '" & prefixText & "%' and status='A' union select distinct rtrim(ltrim(area)) from JCT_Epor_training_detail where area like '" & prefixText & "%' and status='A' union select distinct rtrim(ltrim(area_of_sp)) from JCT_Epor_Experience_Detail where area_of_sp like '" & prefixText & "%' and status='A'  union select distinct rtrim(ltrim(technology_used)) from JCT_Epor_project_detail where technology_used like '" & prefixText & "%' and status='A' and  DateDiff(DD,GETDATE(),EFF_TO)>=0  union select distinct rtrim(ltrim(area)) from JCT_EPOR_CERTIFICATION_DETAIL where area like '" & prefixText & "%' and status='A'"
        cmd = New SqlCommand(qry, cn)
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
Public Function Getsalesorts(ByVal prefixText As String, ByVal count As Integer) As String()
        qry = "SELECT DISTINCT item_no from miserp.som.dbo.t_order_line_nos  WHERE item_no like '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
        cn.Open()
        dr = cmd.ExecuteReader()
        Dim data As New List(Of String)()
        While dr.Read()
            If i < 50 Then
                data.Add(dr.Item(0).ToString)
                i += 1
            End If
        End While
        cn.Close()
        Return data.ToArray
    End Function
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function Getfabricsorts(ByVal prefixText As String, ByVal count As Integer) As String()
        qry = "SELECT DISTINCT sort_no from production..jct_fab_results WHERE sort_no like '%" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
        cn.Open()
        dr = cmd.ExecuteReader()
        Dim data As New List(Of String)()
        While dr.Read()
            If i < 500 Then
                data.Add(dr.Item(0).ToString)
                i += 1
            End If
        End While
        cn.Close()
        Return data.ToArray
    End Function


    <WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
    Public Function Get_fabric_catg(ByVal prefixText As String, ByVal count As Integer) As String()

        qry = "select distinct left(ltrim(a.stock_no),3) " & _
"from miserp.common.dbo.ims_variant_master a, " & _
"miserp.common.dbo.ims_stock_master b " & _
"where left(ltrim(a.stock_no),3) like '" & prefixText & "%'" & _
"and a.stock_no = b.stock_no " & _
"and a.variant_no not in ('##','FN','RG','CH') " & _
"and a.company_no = 'JCT00LTD' " & _
"and a.company_no = b.company_no " & _
"and b.stock_type in (2,3) " & _
"and a.stock_no not in " & _
"(select item_no from miserp.som.dbo.m_item_mapping " & _
"where upper(left(item_group_no,3))='GRM' " & _
"and company_no = a.company_no) " & _
"order by left(ltrim(a.stock_no),3)"

        cmd = New SqlCommand(qry, cn)
        cn.Open()
        dr = cmd.ExecuteReader()

        Dim data As New List(Of String)()

        While dr.Read()
            If i < 500 Then
                data.Add(dr.Item(0).ToString)
                i += 1
            End If
        End While

        cn.Close()
        Return data.ToArray

    End Function

    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function GetEmployee_jatin(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
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
    Public Function GuestName(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "Select distinct Name from jct_Guest_Internet_Request where status='A' and Name like '%" & prefixText & "%'"
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
    Public Function GuestMobile(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "Select distinct Mobile from jct_Guest_Internet_Request where status='A' and mobile like '%" & prefixText & "%' "
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
    Public Function GuestCompany(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "Select distinct Company from jct_Guest_Internet_Request where status='A' and company like '%" & prefixText & "%' "
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
    Public Function Guest_VisitingEmployee(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "Select distinct Visiting_Employee from jct_Guest_Internet_Request where status='A' and Visiting_Employee like '%" & prefixText & "%' "
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
    Public Function CustomerAddress_CourierSystem(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "Select distinct cust_name from m_customer_address where  cust_name like '%" & prefixText & "%' or cust_no like '%" & prefixText & "%' "
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
    Public Function SupplierAddress_CourierSystem(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "Select distinct vendor_name from miserp.apdb.dbo.ap_vendor_master where  vendor_name like '%" & prefixText & "%' or vendor_code like '%" & prefixText & "%' "
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
    Public Function OtherPartyAddress_CourierSystem(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "Select distinct PartyName from jct_courier_other_Address where  PartyName like '%" & prefixText & "%' "
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

    '    <WebMethod()> _
    '<System.Web.Script.Services.ScriptMethod()> _
    '    Public Function OPS_Customer(ByVal prefixText As String, ByVal count As Integer) As System.String()
    '        Dim Sql As String
    '        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
    '        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
    '        Sql = "Select LTRIM(RTRIM(cust_name +'~'+cust_no)) [Customer Code] from miserp.som.dbo.m_customer where cust_name like '%" + prefixText + "%'"
    '        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
    '        cn.Open()
    '        Dim Dr As SqlDataReader = Cmd.ExecuteReader
    '        Dim i As Integer = 0
    '        Dim Data As New List(Of String)()
    '        While Dr.Read
    '            Data.Add(Dr.Item(0).ToString)
    '            i += 1
    '        End While
    '        cn.Close()
    '        Return Data.ToArray
    '    End Function

    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function OPS_Customer(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "Select LTRIM(RTRIM(cust_name +'~'+cust_no)) [Customer Code] from miserp.som.dbo.m_customer where cust_name like '%" + prefixText + "%' union " & _
            "select LTRIM(RTRIM(cust_name +'~'+cust_name)) [Customer Code] from JCT_OPS_PROSPECT_DETAIL where status = 'A' and cust_name like '%" + prefixText + "%'"
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
    Public Function OPS_outstanding_invoice_rajan(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        'Sql = "Select invoice_no from miserp.shp.dbo.Combine_Invoice_OPS_Detail  where isnull(outstanding_amt, 0) > 0   and invoice_no like '%" + prefixText + "%'"
        Sql = "Select invoice_no from miserp.shp.dbo.Combine_Invoice_OPS_Detail  where isnull(outstanding_amt, 0) > 0 and invoice_no  not in ( select invoice_no from jct_ops_outstanding_invoice_reasons)    AND invoice_no LIKE '" + prefixText + "%'"
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
    Public Function OPS_Fetch_Shade(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "SELECT DISTINCT a.attb_discrete FROM miserp.som.dbo.t_order_line_nos_attrb a INNER JOIN miserp.som.dbo.t_order_hdr b ON a.order_no=b.order_no WHERE b.order_dt > '01/01/2011' AND a.attb_code ='Shade1' and a.attb_discrete like '" + prefixText + "%'"

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
    Public Function OPS_Fetch_ItemType(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "SELECT DISTINCT	 LEFT(item_no,3) AS ItemType FROM miserp.som.dbo.t_order_line_nos  where item_no like '" + prefixText + "%' "

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
    Public Function OPS_Agents(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim sqlstr As String
        'sqlstr = "Select LTRIM(RTRIM(cust_name +'~'+cust_no)) [Customer Code] from miserp.som.dbo.m_customer where cust_name like '%" + prefixText + "%'"
        sqlstr = "select LTRIM(RTRIM(sales_person_name)) + '|' + LTRIM(RTRIM(sales_person_no)) from miserp.som.dbo.m_sales_person where sales_person_name like '%" + prefixText + "%' and sales_person_status = 'O' and getdate() between effective_dt and expiry_dt"

        Dim Cmd As SqlCommand = New SqlCommand(sqlstr, cn)
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
    Public Function GetEmployee_OPS(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        Sql = "SELECT	DISTINCT  (a.empname + '|' + a.empcode) as Employee FROM jct_empmast_base a	WHERE a.empname LIKE '" & prefixText & "%' and (a.DOL is null or a.DOL<getdate())   "
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
    Public Function GetEmployeeDepartment(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        Sql = "SELECT	DISTINCT  (a.empname + '|' + a.empcode + '~ ' + b.deptname) as Employee FROM jct_empmast_base a inner join deptmast b on a.deptcode=b.deptcode	WHERE a.empname LIKE '%" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
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
    Public Function CostCenter(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT	DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b 	on a.deptcode = b.deptcode	WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "select ma_Center_ldesc +'~'+ ma_center_no from miserp.common.dbo.mac_cost_center where ma_effective_date<=getdate() and ma_expiry_date>=GETDATE() and  ma_center_ldesc like '%" + prefixText + "%'"
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
    Public Function Email_IDs(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT distinct   a.Name +'~' + c.DEPTNAME +'~'+ a.empcode FROM dbo.MISTEL a INNER JOIN dbo.JCT_EmpMast_Base b ON a.empcode=b.empcode  INNER JOIN dbo.DEPTMAST c ON b.deptcode=c.DEPTCODE  where a.name like '%" + prefixText + "%'"
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
    Public Function OPS_Fabric_Items(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim sqlstr As String
        'sqlstr = "Select LTRIM(RTRIM(cust_name +'~'+cust_no)) [Customer Code] from miserp.som.dbo.m_customer where cust_name like '%" + prefixText + "%'"
        sqlstr = "select fabric_desc + '~' + convert(varchar,sort_no) + '~' + convert(varchar,enq_no) + '~' + convert(varchar,dev_no) from production..jct_fabric_dev_hdr where (fabric_desc like '%" + prefixText + "%' or sort_no like '" + prefixText + "%' or enq_no like '" + prefixText + "%' or dev_no like '" + prefixText + "%')"

        Dim Cmd As SqlCommand = New SqlCommand(sqlstr, cn)
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
    Public Function faults(prefixText As String, count As Integer) As System.String()

        Dim cmd As SqlCommand = New SqlCommand(" SELECT  LEFT(( count_name + ' - ' + mixing_name ), 35)FROM    production..spg_mixing_count_mapping a ,production..spg_mixing_header b ,    production..common_count_master c  WHERE(a.mixing_code = b.mixing_code) AND c.status IS null AND a.count_code = c.count_code AND a.status IS NULL and count_name + ' - ' + mixing_name like '" + prefixText + "%' ", cn)

        cn.Open()
        Dim Dr As SqlDataReader = cmd.ExecuteReader
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
    Public Function machineno(prefixText As String, count As Integer) As System.String()
        '  Dim connn As SqlConnection = New SqlConnection("Data Source=test2k;Initial Catalog=trainee;User ID=trainee;Password=trainee")


        Dim cmddd As SqlCommand = New SqlCommand("select process_unit from production..Common_Process_unit where process_center in ('Autcon','TFO') and status=' 'and process_unit  like '" & prefixText & "%' ", cn)


        cn.Open()
        Dim Dr As SqlDataReader = cmddd.ExecuteReader
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
    Public Function GetItemcode(ByVal prefixText As String, ByVal count As Integer) As System.String()
        cn.Open()

        qry = "select   Ltrim(Rtrim(a.stock_no)) +' - '+ ltrim(rtrim(a.description)) " & _
        "from miserp.common.dbo.ims_stock_master a " & _
        "where a.stock_type = '0' " & _
        "and a.stock_no like '" & prefixText & "%' " & _
        "order by a.stock_no "

        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader()

        Dim data As New List(Of String)()

        While dr.Read()
            If i < 2000 Then
                data.Add(dr.Item(0).ToString)
                i += 1
            End If
        End While

        cn.Close()
        Return data.ToArray

    End Function


    <WebMethod()> _
     <System.Web.Script.Services.ScriptMethod()> _
    Public Function GetVariant(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        cn.Open()

        qry = "select  LTRIM(RTRIM(a.variant_no)) +' - '+ ltrim(rtrim(b.description)) +' , ' + ltrim(rtrim(a.short_description)) " & _
        "from miserp.common.dbo.ims_variant_master a, miserp.common.dbo.ims_stock_master b " & _
        "where b.stock_type = '0' " & _
                "and b.stock_no = '" & contextKey & "' " & _
                "and a.stock_no = b.stock_no " & _
        "and a.variant_no like '" & prefixText & "%' " & _
        "order by a.variant_no "

        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader()

        Dim data As New List(Of String)()

        While dr.Read()
            If i < 2000 Then
                data.Add(dr.Item(0).ToString)
                i += 1
            End If
        End While

        cn.Close()
        Return data.ToArray

    End Function





    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function GetPaytermcode(ByVal prefixText As String, ByVal count As Integer) As System.String()
        cn.Open()


        qry = "select ltrim(rtrim(a.pay_term_no)) +' - ' + ltrim(rtrim(a.pay_term_desc)) " & _
           "from miserp.common.dbo.pur_payterm_header a " & _
           "where a.pay_term_no like '" & prefixText & "%' " & _
           "and convert(datetime,convert(varchar(11),getdate())) between a.effective_date and a.expiry_date " & _
           "union " & _
           "select ltrim(rtrim(a.pay_term_no)) +' - ' + ltrim(rtrim(a.pay_term_desc)) " & _
           "from jct_ops_pay_term_header a " & _
           "where a.pay_term_no like '" & prefixText & "%' " & _
           "and convert(datetime,convert(varchar(11),getdate())) between a.effective_date and a.expiry_date " & _
           "order by ltrim(rtrim(a.pay_term_no)) +' - ' + ltrim(rtrim(a.pay_term_desc)) "



        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader()

        Dim data As New List(Of String)()

        While dr.Read()
            If i < 2000 Then
                data.Add(dr.Item(0).ToString)
                i += 1
            End If
        End While

        cn.Close()
        Return data.ToArray

    End Function

    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function issueNotest(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim connn As SqlConnection = New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("IMSDBConnectionString").ConnectionString)
        'Dim Qry As String = "select  distinct  a.issue_no from ims_issue_header a  join ims_issue_account_detail b on  a.issue_no=b.issue_no  and  b.cc_no like '%YSmt%' and a.issue_no  like  '" & prefixText & "%' "
        'Dim connn As SqlConnection = New SqlConnection("Data Source=miserptest2;Initial Catalog=IMSDB;User ID= trainee;Password= trainee")
        'Dim cmddd As SqlCommand = New SqlCommand("select  distinct  a.issue_no from ims_issue_header a  join ims_issue_account_detail b on  a.issue_no=b.issue_no  and  b.cc_no like '%YSmt%' and a.issue_no  like  '" & prefixText & "%' ", connn)

        Dim cmddd As SqlCommand = New SqlCommand("select  distinct top 100 a.issue_no from ims_issue_header a  join ims_issue_account_detail b on  a.issue_no=b.issue_no  and  b.cc_no like '%YSmt%' and a.issue_no  like   '" & prefixText & "%" & "' and a.issue_date>='04/01/2013' order by a.issue_no desc", connn)

        connn.Open()
        Dim Dr As SqlDataReader = cmddd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        connn.Close()

        Return Data.ToArray

    End Function

    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function mktnames(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim connn As SqlConnection = New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString)
        'Dim Qry As String = "select  distinct  a.issue_no from ims_issue_header a  join ims_issue_account_detail b on  a.issue_no=b.issue_no  and  b.cc_no like '%YSmt%' and a.issue_no  like  '" & prefixText & "%' "
        'Dim connn As SqlConnection = New SqlConnection("Data Source=miserptest2;Initial Catalog=IMSDB;User ID= trainee;Password= trainee")

        'Dim cmd As SqlCommand = New SqlCommand("select firstname from jct_sales_person_v  where firstname like '" & prefixText & "%' ", connn)

        Dim cmd As SqlCommand = New SqlCommand("SELECT a.empname+'~'+ a.empcode FROM dbo.JCT_EmpMast_Base a INNER JOIN dbo.jct_sales_person_v b ON REPLACE(a.empcode,'-','')=b.EmployeeID   where a.empname like '" & prefixText & "%' ", connn)


        connn.Open()
        Dim Dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        connn.Close()


        Return Data.ToArray



    End Function


    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function vendornames(ByVal prefixText As String, ByVal count As Integer) As System.String()
        ' Dim connn As SqlConnection = New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("jctdevConnectionString").ConnectionString)
        'Dim Qry As String = "select  distinct  a.issue_no from ims_issue_header a  join ims_issue_account_detail b on  a.issue_no=b.issue_no  and  b.cc_no like '%YSmt%' and a.issue_no  like  '" & prefixText & "%' "
        Dim connn As SqlConnection = New SqlConnection("Data Source=miserp;Initial Catalog=COMMON;User ID= itgrp;Password= power")

        Dim cmd As SqlCommand = New SqlCommand("select distinct vendor_name  +'~'+ vendor_code from common..ap_vendor_detail where ven_acct_group='Yarn' and vendor_name like '" & prefixText & "%' ", connn)

        connn.Open()
        Dim Dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        connn.Close()


        Return Data.ToArray



    End Function

    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function vendorfab(ByVal prefixText As String, ByVal count As Integer) As System.String()
        ' Dim connn As SqlConnection = New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("jctdevConnectionString").ConnectionString)
        'Dim Qry As String = "select  distinct  a.issue_no from ims_issue_header a  join ims_issue_account_detail b on  a.issue_no=b.issue_no  and  b.cc_no like '%YSmt%' and a.issue_no  like  '" & prefixText & "%' "
        Dim connn As SqlConnection = New SqlConnection("Data Source=miserp;Initial Catalog=COMMON;User ID= itgrp;Password=power")

        Dim cmd As SqlCommand = New SqlCommand("select distinct vendor_name  +'~'+ vendor_code from common..ap_vendor_detail where ven_acct_group='FAB' and vendor_name like '" & prefixText & "%' ", connn)

        connn.Open()
        Dim Dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        connn.Close()

        Return Data.ToArray

    End Function

    <WebMethod()> _
    <System.Web.Script.Services.ScriptMethod()> _
    Public Function OPS_Brands(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim sqlstr As String
        'sqlstr = "select fabric_desc + '~' + convert(varchar,sort_no) + '~' + convert(varchar,enq_no) + '~' + convert(varchar,dev_no) from production..jct_fabric_dev_hdr where (fabric_desc like '%" + prefixText + "%' or sort_no like '" + prefixText + "%' or enq_no like '" + prefixText + "%' or dev_no like '" + prefixText + "%')"
        sqlstr = "jct_ops_get_brands"
        Dim Cmd As SqlCommand = New SqlCommand(sqlstr, cn)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@prefix", SqlDbType.VarChar, 50).Value = prefixText
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
    Public Function transportport(ByVal prefixText As String, ByVal count As Integer) As System.String()
        'Dim cn As SqlConnection = New SqlConnection("Data Source=test2k;Initial Catalog=jctdev;User ID=trainee;Password=trainee")
        cn.Open()
        'qry = "select distinct  top " + count.ToString() + " city  FROM JCT_ExpDoc_PortDetails  where city like  '" & prefixText & "%'"
        qry = "select distinct  top " + count.ToString() + " (city + ',' + state + ',' + Country ) as city  FROM JCT_ExpDoc_PortDetails  where city like  '" & prefixText & "%'"
        cmd = New SqlCommand(qry, cn)
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
    Public Function jobworkinvoicelist(ByVal prefixText As String, ByVal count As Integer) As System.String()
        'Dim cn As SqlConnection = New SqlConnection("Data Source=test2k;Initial Catalog=jctdev;User ID=trainee;Password=trainee")
        cn.Open()
        qry = "SELECT DISTINCT  TOP  " + count.ToString() + "  InvoiceNo  from  jct_ops_jobwork_common_Invoice  where InvoiceNo  LIKE  '" & prefixText & "%' and status = 'A'"
        cmd = New SqlCommand(qry, cn)
        dr = cmd.ExecuteReader()
        Dim data As New List(Of String)()
        While dr.Read()
            data.Add(dr.Item(0).ToString())
            i += 1
        End While
        cn.Close()
        Return data.ToArray
    End Function

    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function GetEmployee_sh(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT  (a.empname + '|' + a.empcode) as Employee FROM jct_empmast_base a   WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
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
    Public Function GetEmployeeDepartment_test(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "

        Sql = "jct_asset_webservice_proc_sh"
        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@context_key", SqlDbType.VarChar, 20).Value = contextKey.ToString()
        Cmd.Parameters.Add("@prefix_text", SqlDbType.VarChar, 20).Value = prefixText.ToString()

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
    Public Function GetEmployeeName_shweta(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String

        Sql = "SELECT DISTINCT empname + ' | ' + EmpCode as FullName FROM JCTDEV..JCT_EmpMast_Base WHERE empname LIKE '" & prefixText & "%' and Active='y'   and Company_Code = '" & contextKey & "' order by FullName"
        ''  Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
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
    Public Function OPS_Bank(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim constr As String = "data source = misdev; initial catalog = production; user id = itgrp; password = power"
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim Sql As String

        Sql = "SELECT Distinct BankCode FROM JCT_BANK_MASTER"
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
    Public Function OPS_Collection(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim constr As String = "data source = misdev; initial catalog = production; user id = itgrp; password = power"
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim Sql As String

        Sql = "SELECT Distinct CashCode FROM JCT_COLLECTION_MASTER"

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
    Public Function OPS_Segment(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim constr As String = "data source = misdev; initial catalog = production; user id = itgrp; password = power"
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim Sql As String

        Sql = "SELECT Distinct SegmentCode FROM jct_segment_master"

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
    Public Function GetEmployeeDepartment_test_aslam(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "

        Sql = "jct_asset_webservice_proc_aslam"
        Dim cn As SqlConnection = New SqlConnection("Data Source=MISDEV;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()


        If contextKey = Nothing Then
            contextKey = ""
        End If

        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@context_key", SqlDbType.VarChar, 20).Value = contextKey.ToString()
        Cmd.Parameters.Add("@prefix_text", SqlDbType.VarChar, 20).Value = prefixText.ToString()

        'cn.Open()
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
    Public Function GetEmpTransport(ByVal prefixText As String, ByVal count As Integer) As String()
        qry = "SELECT DISTINCT empname FROM JCTDEV..jct_empmast_base a (NOLOCK)  where  active='y' and empname like '%" & prefixText & "%'"
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
    Public Function GetDriverName(ByVal prefixText As String, ByVal count As Integer) As String()
        qry = "SELECT EmpName FROM Driver_Master WHERE IsActive='Y' and EmpName like '%" & prefixText & "%'"
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
    Public Function Get_grNo(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String

        Sql = "select grno from JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION where status='A' and grno LIKE '" & prefixText & "%' order by grno"
        ''  Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
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
    Public Function Get_mrNo(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String

        Sql = "select mrno from JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION where status='A' and mrno LIKE '" & prefixText & "%' order by grno"
        ''  Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
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
    Public Function GetEmployeeNameForSantioNote(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        'Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT DISTINCT empname + ' : ' + empcode as FullName FROM JCTDEV..jct_empmast_base WHERE empname LIKE '" & prefixText & "%' and active='Y' and (dol is null or dol<getdate()) and Company_Code =  '" & contextKey & "' order by FullName "
        Sql = "SELECT  empname + ' : ' + empcode AS FullName FROM    JCTDEV..JCT_EmpMast_Base WHERE   empname LIKE '" & prefixText & "%' AND Active = 'Y' AND ( DOL IS NULL OR DOL < GETDATE()  )  ORDER BY empname "
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
    Public Function OPS_Fabric_Items_Quot(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim sqlstr As String
        'sqlstr = "Select LTRIM(RTRIM(cust_name +'~'+cust_no)) [Customer Code] from miserp.som.dbo.m_customer where cust_name like '%" + prefixText + "%'"
        sqlstr = "select fabric_desc + '~' + convert(varchar,sort_no) + '~' + convert(varchar,enq_no) + '~' + convert(varchar,dev_no) from production..jct_fabric_dev_hdr where (fabric_desc like '%" + prefixText + "%' or sort_no like '" + prefixText + "%' or enq_no like '" + prefixText + "%' or dev_no like '" + prefixText + "%') AND fabric_desc LIKE '%grey%' "

        Dim Cmd As SqlCommand = New SqlCommand(sqlstr, cn)
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
    Public Function OPS_Fetch_ItemType_Quot(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        ' Sql = "SELECT DISTINCT Fullname + ' : ' + Emp_Code as FullName FROM JCTDEV..JCT_EPOR_MASTER_EMPLOYEE WHERE FullName LIKE '" & prefixText & "%' and status='A' and (Date_of_Leaving is null or Date_of_Leaving<getdate())  and Company_Code = '" & contextKey & "' order by FullName "
        ' Sql = "SELECT    DISTINCT  a.empname + ' :    '+ a.Desg + '     : ' + b.Deptname as FullName FROM jct_empmast_base a inner join deptmast b   on a.deptcode = b.deptcode WHERE a.empname LIKE '" & prefixText & "%' and a.active='Y' and (a.DOL is null or a.DOL<getdate())   "
        Sql = "SELECT DISTINCT    LEFT(item_no,3) AS ItemType FROM miserp.som.dbo.t_order_line_nos  where item_no like '" + prefixText + "%' AND item_no like 'GRY%' "

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
	'20 April 2017
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function GetDeptEmployeeName(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        Sql = "SELECT  empname + ' : ' + empcode AS FullName FROM    JCTDEV..JCT_EmpMast_Base B ( NOLOCK )JOIN JCTDEV..jct_ops_sales_team_hierarchy S ( NOLOCK ) ON REPLACE(B.empcode,'-', '') = S.Sale_Person_Code WHERE   empname LIKE '" & prefixText & "%' AND Active = 'Y' AND ( DOL IS NULL OR DOL < GETDATE()  ) AND B.Company_Code = '" & contextKey & "'  AND deptcode IN ( 'SAL' )AND S.Status = 'A' AND S.Team_Code = 'Sales' ORDER BY empname "
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
    '20 April 2017

    <WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
    Public Function GetSalePersonForCustomer(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Sql = "SELECT DISTINCT empname + ' : ' + empcode AS FullName FROM  JCTDEV..JCT_OPS_CUSTOMER_HIERARCHY b INNER JOIN JCT_EmpMast_Base c ON REPLACE(c.empcode, '-', '') = b.sale_person_code WHERE  empname LIKE '" & prefixText & "%' AND  c.Active = 'Y' "
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
    Public Function StockItemList(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Dim cn1 As SqlConnection = New SqlConnection("Data Source=miserp;Initial Catalog=COMMON;User ID=itgrp;Password=power")
        cn1.Open()        
        'Sql = "Select (a.stock_no + b.variant_no) 'item', a.stock_no ,b.variant_no,a.description 'stock_description',b.description 'variant_description' from ims_stock_master a, ims_variant_master b  where a.stock_type not in ( '2','3', '0') and a.stock_no = b.stock_no   AND  a.stock_no LIKE '" & prefixText & "%'  order by a.stock_no,b.variant_no"
        Sql = "Select  RTRIM(LTRIM(a.stock_no))  + '/' + RTRIM(LTRIM(b.variant_no)) from ims_stock_master a, ims_variant_master b  where a.stock_type not in ( '2','3') and a.stock_no = b.stock_no   AND  a.stock_no LIKE '" & prefixText & "%'  order by a.stock_no,b.variant_no"
        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn1)
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Dim i As Integer = 0
        Dim Data As New List(Of String)()
        While Dr.Read
            Data.Add(Dr.Item(0).ToString)
            i += 1
        End While
        cn1.Close()
        Return Data.ToArray
    End Function
	
		
    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function LocationWIse_Employee(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        Sql = "Jct_Payroll_LocationWIse_Employee"
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()

        If contextKey = Nothing Then
            contextKey = ""
        End If

        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@context_key", SqlDbType.VarChar, 20).Value = contextKey.ToString()
        Cmd.Parameters.Add("@prefix_text", SqlDbType.VarChar, 20).Value = prefixText.ToString()

        'cn.Open()
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
    Public Function LocationWIse_Employee_Sapcode(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        Sql = "Jct_Payroll_LocationWIse_Employee_sapCode"
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()

        If contextKey = Nothing Then
            contextKey = ""
        End If

        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@context_key", SqlDbType.VarChar, 20).Value = contextKey.ToString()
        Cmd.Parameters.Add("@prefix_text", SqlDbType.VarChar, 20).Value = prefixText.ToString()

        'cn.Open()
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
    Public Function GetPayrollCity(ByVal prefixText As String, ByVal count As Integer) As System.String()     
        Dim Sql As String        
        Sql = "Jct_Payroll_City"
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()
        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
        Cmd.CommandType = CommandType.StoredProcedure        
        Cmd.Parameters.Add("@prefix_text", SqlDbType.VarChar, 20).Value = prefixText.ToString()
        'cn.Open()
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
    Public Function LocationWIse_Employee_Bill(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String

        Sql = "Jct_Payroll_LocationWIse_Employee_bill"
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()

        If contextKey = Nothing Then
            contextKey = ""
        End If

        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@context_key", SqlDbType.VarChar, 20).Value = contextKey.ToString()
        Cmd.Parameters.Add("@prefix_text", SqlDbType.VarChar, 20).Value = prefixText.ToString()

        'cn.Open()
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
    Public Function GetEmployee_sh_Common(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()
        Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.EmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
        'Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.NewEmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
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
    Public Function GetEmployee_sh_Common_Active(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()
        Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.EmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active  in  ('Y') AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) AND a.STATUS in ('A') "
        'Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.EmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) AND a.STATUS = 'A' "
        'Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.NewEmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) AND STATUS = 'A'"        

        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
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
    Public Function GetEmployee_sh_Common_Left(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()
        Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.EmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active in ('Y','N') and status  in ('A','x') AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
        'Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.NewEmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
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


    '    <WebMethod()> _
    '<System.Web.Script.Services.ScriptMethod()> _
    '    Public Function GetEmployee_sh_Common(ByVal prefixText As String, ByVal count As Integer) As System.String()
    '        Dim Sql As String
    '        Dim cn As SqlConnection = New SqlConnection("Data Source=test2k;Initial Catalog=jctdev;User ID=itgrp;Password=power")
    '        cn.Open()
    '        Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.EmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
    '        'Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.NewEmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) AND STATUS = 'A'"        

    '        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
    '        Dim Dr As SqlDataReader = Cmd.ExecuteReader
    '        Dim i As Integer = 0
    '        Dim Data As New List(Of String)()
    '        While Dr.Read
    '            Data.Add(Dr.Item(0).ToString)
    '            i += 1
    '        End While
    '        cn.Close()
    '        Return Data.ToArray
    '    End Function


    <WebMethod()> _
<System.Web.Script.Services.ScriptMethod()> _
    Public Function GetEmployee_sh_Common_CardNo(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()
        Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.cardno ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
        'Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.NewEmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
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
    Public Function GetEmployee_sh_Common_Sap(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()
        Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.NewEmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
        'Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.NewEmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) AND STATUS = 'A'"        

        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
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
    Public Function GetEmployee_sh_Common_Employeecodewise(ByVal prefixText As String, ByVal count As Integer) As System.String()
        Dim Sql As String
        Dim cn As SqlConnection = New SqlConnection("Data Source=test2k;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()
        Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.EmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeCode LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) "
        'Sql = "SELECT DISTINCT( a.EmployeeName + '|' + a.NewEmployeeCode ) AS Employee FROM   dbo.JCT_payroll_employees_master a WHERE   a.EmployeeName LIKE '" & prefixText & "%' AND a.active = 'Y' AND ( a.DOLeaving IS NULL OR a.DOLeaving < GETDATE()) AND STATUS = 'A'"        

        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
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
    Public Function LocationWIse_Employee_Left(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As System.String()
        Dim Sql As String
        Sql = "Jct_Payroll_LocationWIse_Employee_Left"
        Dim cn As SqlConnection = New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp;Password=power")
        cn.Open()

        If contextKey = Nothing Then
            contextKey = ""
        End If

        Dim Cmd As SqlCommand = New SqlCommand(Sql, cn)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@context_key", SqlDbType.VarChar, 20).Value = contextKey.ToString()
        Cmd.Parameters.Add("@prefix_text", SqlDbType.VarChar, 20).Value = prefixText.ToString()

        'cn.Open()
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

End Class
