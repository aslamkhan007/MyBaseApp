Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class OPS_rpt_items_movement_before_transaction
    Inherits System.Web.UI.Page
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass As String
    Public obj As New HelpDeskClass
    Dim Rpt As ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Page.IsPostBack Then
            'obj.ApplyBtnStyle(btnfetch)
            BindReport()
        End If

    End Sub

    Protected Sub lnk_fetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_fetch.Click

        BindReport()

    End Sub

    Protected Sub BindReport()

        If LTrim(RTrim(Me.txt_entryno.Text)) <> "" Then

            sqlpass = "select * from jct_ops_items_movement_before_transaction_header " & _
                    "where entry_no = " & Me.txt_entryno.Text & _
                    " and company_code = '" & LTrim(RTrim(Session("Companycode"))) & "' " & _
                    "order by grupr_no,item_serial "

        Else

            sqlpass = "select * from jct_ops_items_movement_before_transaction_header " & _
                    "where convert(datetime,convert(varchar(11),system_date)) between  '" & _
                    Me.txt_datefrom.Text & "' and '" & _
                    Me.txt_dateto.Text & "' " & _
                    "and company_code = '" & LTrim(RTrim(Session("Companycode"))) & "' " & _
                    "order by grupr_no,item_serial "

        End If

        obj.opencn()

        Dim cmd As SqlCommand = New SqlCommand(sqlpass, obj.cn)
        cmd.CommandTimeout = 0

        Dim Da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim Ds As DataSet = New DataSet()
        Da.Fill(Ds)

        Rpt = New ReportDocument()
        Rpt.Load(Server.MapPath("crpt_items_movement_before_transaction_issue_slip.rpt"))
        Rpt.SetDataSource(Ds.Tables(0))
        CrystalReportViewer1.ReportSource = Rpt
        Rpt.SetParameterValue("fromdate", Me.txt_datefrom.Text)
        Rpt.SetParameterValue("todate", Me.txt_dateto.Text)
        'Rpt.SetParameterValue("entryno", Me.txt_entryno.Text)
        'CrystalReportViewer1.Refresh()
        CrystalReportViewer1.Height = 300
        CrystalReportViewer1.Width = 820

        obj.closecn()

    End Sub

    'Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    '    If (Not Rpt Is Nothing) Then
    '        If Rpt.IsLoaded = True Then
    '            Rpt.Close()
    '            Rpt.Dispose()
    '        End If
    '    End If
    'End Sub

    Private Sub Page_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload

        If Not (rpt Is Nothing) Then
            If rpt.IsLoaded = True Then

                rpt.Close()
                rpt.Dispose()

            End If
        End If

    End Sub

End Class
