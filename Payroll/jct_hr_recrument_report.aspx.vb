Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class Payroll_jct_hr_recrument_report
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
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



        If LTrim(RTrim(Me.txt_fdate.Text)) = "" And LTrim(RTrim(Me.txt_tdate.Text)) <> "" Then
            Dim script As String = "alert(Pl.Put Poper Dates!!');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
        End If

        obj.opencn()
        sqlpass = "exec jct_hr_recrument_report'" & RTrim(Me.txt_fdate.Text) & "','" & _
                        LTrim(RTrim(Me.txt_tdate.Text)) & "','" & _
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.txt_fdate.Text = Now.Date
            Me.txt_tdate.Text = Now.Date

        End If

    End Sub
    Protected Sub imb_close_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click
        Me.Dispose()
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub lnk_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_excel.Click
        GridViewExportUtil.Export("Recrument_Report.xls", Me.GridView2)

    End Sub
End Class
