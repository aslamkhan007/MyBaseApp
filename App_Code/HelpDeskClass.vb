Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports Microsoft.VisualBasic

Public Class HelpDeskClass
    Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Public cn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ob As New Functions
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
    Public Function CheckRecordExistInTransaction(ByVal Sql As String) As Boolean
        Try
            dr = ob.FetchReader(Sql)
            If Dr.HasRows = True Then
                While Dr.Read()
                    CheckRecordExistInTransaction = True
                End While
            Else
                CheckRecordExistInTransaction = False
            End If
        Catch ex As Exception
        Finally
            Dr.Close()
            closecn()
        End Try
    End Function
    
End Class
