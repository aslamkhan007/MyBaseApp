Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class OPS_PunchtimeWise_Worker_Deoployment
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass, sno2 As String
    Public obj As New HelpDeskClass
    Dim Ash, sno1 As Integer

    Protected Sub lnk_fetch_Click(sender As Object, e As System.EventArgs) Handles lnk_fetch.Click

        If LTrim(RTrim(Me.txt_fdate.Text)) = "" And LTrim(RTrim(Me.txt_tdate.Text)) <> "" Then
            FMsg.Message = "Pl. enter From/To Date"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If
        obj.opencn()

        ''Dim Sqlpass = "exec jct_pp_required_material_fetch '" & Me.ddl_yearmonth.Text & "','" & Me.ddl_revno.Text & "','" & UCase(LTrim(RTrim(Session("empcode")))) & "','" & UCase(LTrim(RTrim(Session("companycode")))) & "'"
        If ddlreporttype.SelectedItem.Text = "PunchtimeWise" Then

            sqlpass = "exec jct_workers_deployment_report_savior_timewise'" & RTrim(Me.txt_fdate.Text) & "','" & _
                        LTrim(RTrim(Me.txt_tdate.Text)) & "','" & _
                        UCase(LTrim(RTrim(Session("empcode")))) & "'"
        End If

        If ddlreporttype.SelectedItem.Text = "DesignationWise" Then

            sqlpass = "exec jct_workers_deployment_report_designation_wise_30012015'" & RTrim(Me.txt_fdate.Text) & "','" & _
                        LTrim(RTrim(Me.txt_tdate.Text)) & "','" & _
                        UCase(LTrim(RTrim(Session("empcode")))) & "'"
        End If

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
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'Me.GridView2.Visible = False

            Me.txt_fdate.Text = Now.Date
            Me.txt_tdate.Text = Now.Date

        End If
    End Sub

    Protected Sub imb_close_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click
        Me.Dispose()
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub lnk_excel_Click(sender As Object, e As System.EventArgs) Handles lnk_excel.Click
        GridViewExportUtil.Export("workers_deployment_summary.xls", Me.GridView2)
    End Sub

    Protected Sub ddlreporttype_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlreporttype.SelectedIndexChanged
        GridView2.DataSource = Nothing
        GridView2.DataBind()
    End Sub
End Class
