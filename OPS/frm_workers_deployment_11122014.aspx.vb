Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class OPS_frm_workers_deployment
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass, sno2 As String
    Public obj As New HelpDeskClass
    Dim Ash, sno1 As Integer

    Protected Sub lnk_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_excel.Click

        If Me.GridView1.Visible = True Then
            GridViewExportUtil.Export("workers_deployment_detail.xls", Me.GridView1)
            'Dim filename As String = LTrim(RTrim(Me.ddl_reporttype.Text)) + "_" + Right(RTrim(Me.ddl_yearmonth.Text), 6) + "-" + LTrim(RTrim(Me.ddl_revno.Text)) + ".xls"
            'GridViewExportUtil.Export(filename, Me.GridView1)
        End If

        If Me.GridView2.Visible = True Then
            GridViewExportUtil.Export("workers_deployment_summary.xls", Me.GridView2)
            'Dim filename As String = LTrim(RTrim(Me.ddl_reporttype.Text)) + "_" + Right(RTrim(Me.ddl_yearmonth.Text), 6) + "-" + LTrim(RTrim(Me.ddl_revno.Text)) + ".xls"
            'GridViewExportUtil.Export(filename, Me.GridView2)
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("Companycode") = "JCT00LTD"
        Session("Empcode") = "C-00509"

        If Not IsPostBack Then

            Me.GridView1.Visible = False
            Me.GridView2.Visible = False

            Me.txt_fdate.Text = Now.Date
            Me.txt_tdate.Text = Now.Date

        End If

    End Sub

    Protected Sub imb_close_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub lnk_fetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_fetch.Click

        If LTrim(RTrim(Me.txt_fdate.Text)) = "" And LTrim(RTrim(Me.txt_tdate.Text)) <> "" Then
            FMsg.Message = "Pl. enter From/To Date"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If

        Me.GridView1.Visible = True
        Me.GridView2.Visible = False

        obj.opencn()

        ''Dim Sqlpass = "exec jct_pp_required_material_fetch '" & Me.ddl_yearmonth.Text & "','" & Me.ddl_revno.Text & "','" & UCase(LTrim(RTrim(Session("empcode")))) & "','" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

        sqlpass = "exec jct_workers_deployment_report '" & RTrim(Me.txt_fdate.Text) & "','" & _
                    LTrim(RTrim(Me.txt_tdate.Text)) & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()
        Catch ex As Exception
            obj.closecn()
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try

    End Sub

    Protected Sub lnk_fetch_summary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_fetch_summary.Click

        If LTrim(RTrim(Me.txt_fdate.Text)) = "" And LTrim(RTrim(Me.txt_tdate.Text)) <> "" Then
            FMsg.Message = "Pl. enter From/To Date"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If

        Me.GridView1.Visible = False
        Me.GridView2.Visible = True

        obj.opencn()

        ''Dim Sqlpass = "exec jct_pp_required_material_fetch '" & Me.ddl_yearmonth.Text & "','" & Me.ddl_revno.Text & "','" & UCase(LTrim(RTrim(Session("empcode")))) & "','" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

        sqlpass = "exec jct_workers_deployment_report_summary '" & RTrim(Me.txt_fdate.Text) & "','" & _
                    LTrim(RTrim(Me.txt_tdate.Text)) & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

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

End Class
