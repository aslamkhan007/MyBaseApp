Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class Payroll_jct_hr_employee_history
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim ObjFun As Functions = New Functions
    Dim sqlpass, sno2 As String
    Public obj As New HelpDeskClass
    Dim Ash, sno1 As Integer
    Private _script As String

    Private Property Script As String
        Get
            Return _script
        End Get
        Set(ByVal value As String)
            _script = value
        End Set
    End Property

    Protected Sub lnk_fetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_fetch.Click
        If LTrim(RTrim(Me.txtempcode.Text)) = "" Then
            Dim script As String = "alert(Put Proper Empcode!!');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
        End If

        obj.opencn()
        'If txtperiod.SelectedItem.Text = "ALL" Then
        'End If

        sqlpass = "exec jct_hr_employee_history_report'" & RTrim(Me.txtempcode.Text) & "','" & _
                        LTrim(RTrim(Me.txtperiod.Text)) & "','" & _
                        UCase(LTrim(RTrim(Session("empcode")))) & "'"

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)
        Da.SelectCommand.CommandTimeout = 100000
        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()
        Catch ex As Exception
            obj.closecn()
            'FMsg.Message = (ex.Message)
            'FMsg.CssClass = "addmsg"
            'FMsg.Display()
            Script = "alert(' + ex.Message + " ');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Script, True)
        Finally
            obj.closecn()
        End Try
    End Sub

    Protected Sub lnk_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_excel.Click
        GridViewExportUtil.Export("Employee_History.xls", Me.GridView2)
    End Sub

    Public Sub period()
        sql = "Select 'ALL' as period union select distinct  period from jct_hr_employee_increment "
        ObjFun.FillList(txtperiod, sql)
       
       
    End Sub

    Protected Sub txtperiod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtperiod.SelectedIndexChanged

    End Sub

    Private Sub SqlDataAdapter(ByVal p1 As Object)
        Throw New NotImplementedException
    End Sub

    Private Sub DataSet(ByVal p1 As Object)
        Throw New NotImplementedException
    End Sub

    Private Sub SqlCommand(ByVal p1 As Object)
        Throw New NotImplementedException
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           period()
        End If
    End Sub
End Class
