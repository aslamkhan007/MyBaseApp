Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient


Partial Class OPS_Jct_DyeChecmical_Consumption_Comparision
    Inherits System.Web.UI.Page
    Dim Obj As Functions
    Dim Con As SqlConnection = New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("IMSDBConnectionString").ConnectionString.ToString())
    Dim Qry As String
    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
        Dim Optn As Int16 = 0

        If ddlReportType.SelectedItem.Text.ToLower = "summary" Then
            Optn = 1
        ElseIf ddlReportType.SelectedItem.Text.ToLower = "detail" Then
            Optn = 2
        Else
            Optn = 3
        End If

        'If chkIgnoreDate.Checked = True Then
        '    Qry = "exec Jct_Ops_SubStore_Issue_Vs_Actual_AddOn '01/01/2001','01/01/2011','" & txtOrderNo.Text & "','Y'," & Optn & " "
        'Else
        '    Qry = "exec Jct_Ops_SubStore_Issue_Vs_Actual_AddOn '" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "','" & txtOrderNo.Text & "','N'," & Optn & " "
        'End If
        If chkActualPrice.Checked = False Then
            If chkIgnoreDate.Checked = True Then
                Qry = "exec Jct_Ops_SubStore_Issue_Vs_Actual_AddOn_With3rdOption '01/01/2001','01/01/2011','" & txtOrderNo.Text & "','Y'," & Optn & " "
            Else
                Qry = "exec Jct_Ops_SubStore_Issue_Vs_Actual_AddOn_With3rdOption '" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "','" & txtOrderNo.Text & "','N'," & Optn & " "
            End If
        Else
            If chkIgnoreDate.Checked = True Then
                Qry = "exec Jct_Ops_SubStore_Issue_Vs_Actual_AddOn_With3rdOption_WithActualRates '01/01/2001','01/01/2011','" & txtOrderNo.Text & "','Y'," & Optn & " "
            Else
                Qry = "exec Jct_Ops_SubStore_Issue_Vs_Actual_AddOn_With3rdOption_WithActualRates '" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "','" & txtOrderNo.Text & "','N'," & Optn & " "
            End If
        End If
        Con.Open()
        Dim ds As DataSet = New DataSet()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Qry, Con)
        Try

            Da.SelectCommand.CommandTimeout = 0
            Da.Fill(ds)
            'Grd.DataSource = ds
            RadGrid1.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
            RadGrid1.DataBind()

        Catch ex As Exception

        Finally
            Con.Close()
            ds.Dispose()
        End Try

        'System.Threading.Thread.Sleep(5000)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdXL_Click(sender As Object, e As System.EventArgs) Handles cmdXL.Click
        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.ExportSettings.IgnorePaging = True
        RadGrid1.ExportSettings.OpenInNewWindow = True
        RadGrid1.ExportSettings.UseItemStyles = True
        RadGrid1.MasterTableView.ExportToExcel()

    End Sub
End Class
