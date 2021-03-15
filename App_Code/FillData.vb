Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
Public Class FillData
    Inherits System.Web.Services.WebService
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String

    Public dr As SqlDataReader
    ''<WebMethod()> _
    '' Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
    ''    If cbo.Text = "<<All>>" Then
    ''        qry = "select account_no from reportdb..contribution_gl_cost_mapping_new where glsubc not in (select std_name from jct_cst_standard_master where status='') and account_no not in (select type_no from jct_cst_subgroup_mapping)  order by glsubc"
    ''    Else
    ''        qry = "select account_no from reportdb..contribution_gl_cost_mapping_new where glsubc not in (select std_name from jct_cst_standard_master where status='') and account_no not in (select type_no from jct_cst_subgroup_mapping) and glsubc='" & Trim(Me.cboParentGrp.Text) & "' order by glsubc"
    ''    End If

    ''    obj.opencn()
    ''    cmd = New SqlCommand(qry, obj.cn)
    ''    dr = cmd.ExecuteReader
    ''    cboAcctNo.Items.Clear()
    ''    If dr.HasRows = True Then
    ''        While dr.Read
    ''            Me.cboAcctNo.Items.Add(dr.Item(0))
    ''        End While
    ''    End If
    ''    dr.Close()

    ''    qry = "select gl_description from reportdb..contribution_glsubc_master where glsubc = '" & Trim(Me.cboParentGrp.Text) & "'  "
    ''    cmd = New SqlCommand(qry, obj.cn)
    ''    Me.txtParentGrpDescr.Text = cmd.ExecuteScalar
    ''    con.Close()
    ''    If Me.cboAcctNo.Items.Count > 0 Then
    ''        Me.cboAcctNo.SelectedIndex = 0
    ''    End If
    ''    Dim c1 As Char
    ''    Dim c2 As Char
    ''    Dim c3 As Char

    ''    If (count = 0) Then
    ''        count = 10
    ''    End If

    ''    Dim rnd As New Random()

    ''    Dim items As New List(Of String)

    ''    For i As Integer = 1 To count

    ''        c1 = CStr(rnd.Next(65, 90))
    ''        c2 = CStr(rnd.Next(97, 122))
    ''        c3 = CStr(rnd.Next(97, 122))

    ''        items.Add(prefixText + c1 + c2 + c3)
    ''    Next i

    ''    Return items.ToArray()
    ''End Function


End Class
