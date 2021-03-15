Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports Microsoft.VisualBasic

Public Class LabDipClass
    Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misProd").ConnectionString
    'Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("productionConnectionString1").ConnectionString
    Public cn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Public Var As String
    Dim a As Integer
    Public Sub New()
        cn = New SqlConnection(constr)
    End Sub
    Public Function TextBoxControl(ByVal ctrl As Control, ByVal prop As String) As Integer
        If prop = Trim(LCase("Empty")) Then
            If ctrl.[GetType]() Is GetType(TextBox) Then

                If CType(ctrl, TextBox).Text = Nothing Then
                    a = a + 1
                End If
            ElseIf ctrl.[GetType]() Is GetType(DropDownList) Then
                If CType(ctrl, DropDownList).Text = Nothing Then
                    a = a + 1
                End If
            End If
        End If
        Return a
        'If ctrl.[GetType]() Is GetType(TextBox) Then
        '    CType(ctrl, TextBox).Text = ""
        'End If
        For Each ctrl2 As Control In ctrl.Controls
            TextBoxControl(ctrl2, prop)
        Next
    End Function

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
    Public Sub ExecQry(ByVal str As String)
        Dim cmd As SqlCommand
        opencn()
        cmd = New SqlCommand(str, cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        closecn()
    End Sub

    Public Function FetchReader(ByVal Sql As String) As SqlDataReader

        cmd = New SqlCommand(Sql, cn)
        Try
            opencn()
            Dr = Cmd.ExecuteReader()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Return Dr
    End Function
    Public Function FetchDS(ByVal sql As String) As DataSet
        opencn()
        Dim ds As DataSet = New DataSet()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        Try
            Da.Fill(ds)
            Return ds
        Catch ex As Exception
            Return New DataSet
        Finally
            closecn()
        End Try

    End Function
    Public Sub FillList(ByVal ddl As DropDownList, ByVal sql As String)
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        ddl.Items.Clear()
        'ddl.Items.Add("All")
        ddl.Items.Add("")
        ddl.SelectedIndex = 0
        If dr.HasRows Then
            While dr.Read
                Dim li As New ListItem
                li.Value = dr.Item(0)
                li.Text = dr.Item(1)
                ddl.Items.Add(li)
            End While
        End If
        cn.Close()

    End Sub
End Class
