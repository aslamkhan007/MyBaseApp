Imports System.Data.SqlClient
Imports System.Data
Partial Class AssetMngmnt_asset_dashboard_IT
    Inherits System.Web.UI.Page

    Dim empcode As String
    Dim i, cnt As Integer
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Public cmd As New SqlCommand

    Dim obj1 As Connection = New Connection()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim conjctgen As New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctgen").ConnectionString)
        'If Not Page.IsPostBack Then
        '    Panel7.Visible = True
        '    ModalPopUp_PageLoad.Show()
        'End If

        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

       




        Dim sql As String = "jct_asset_type_summary_report"
        Dim cmd As New SqlCommand(sql, obj1.Connection())
        cmd.CommandType = CommandType.StoredProcedure


        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        grdDetail.DataSource = ds.Tables(0)
        grdDetail.DataBind()



        sql = "jct_asset_summary_items"
        cmd = New SqlCommand(sql, obj1.Connection())
        cmd.CommandType = CommandType.StoredProcedure
        Dim Dr As SqlDataReader = cmd.ExecuteReader


        If Dr.HasRows Then
            While Dr.Read
                lbsrno.Text = Dr(0).ToString()
            End While
        End If
        Dr.Close()





        sql = "jct_asset_printer_total "
        cmd = New SqlCommand(sql, obj1.Connection())
        cmd.CommandType = CommandType.StoredProcedure

        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds)
        grdDetail2.DataSource = ds.Tables(0)
        grdDetail2.DataBind()

 
        sql = "jct_asset_type_summary_report_discarded_standby "
        cmd = New SqlCommand(sql, conjctgen)
        cmd.CommandType = CommandType.StoredProcedure

        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds)
        grdDetail8.DataSource = ds.Tables(0)
        grdDetail8.DataBind()



            sql = "jct_asset_type_summary_report_desktop_server"
            cmd = New SqlCommand(sql, obj1.Connection())
            cmd.CommandType = CommandType.StoredProcedure
            da = New SqlDataAdapter(cmd)
            ds = New DataSet()
            da.Fill(ds)
            grdDetail4.DataSource = ds.Tables(0)
            grdDetail4.DataBind()

        sql = "select  asset_type,printer_type,Count(asset_type) as [Count] from jct_asset_printer_scanner_network where  asset_type LIKE '%scanner%' AND status='A'  AND state IN ('In Use','Stand By') group by asset_type,printer_type "
            cmd = New SqlCommand(sql, obj1.Connection())
            cmd.CommandType = CommandType.Text

            da = New SqlDataAdapter(cmd)
            ds = New DataSet()
            da.Fill(ds)
            grdDetail5.DataSource = ds.Tables(0)
            grdDetail5.DataBind()

            sql = "select  asset_type,printer_type,Count(asset_type) as [Count] from jct_asset_printer_scanner_network where status='A'  AND asset_type  NOT LIKE '%scanner%'and printer_type is null   group by asset_type,printer_type "
            cmd = New SqlCommand(sql, obj1.Connection())
            cmd.CommandType = CommandType.Text

            da = New SqlDataAdapter(cmd)
            ds = New DataSet()
            da.Fill(ds)
            grdDetail6.DataSource = ds.Tables(0)
            grdDetail6.DataBind()

    End Sub


    'Protected Sub rblType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblType.SelectedIndexChanged
    '    If rblType.SelectedIndex = 0 Then
    '        ModalPopUp_PageLoad.Hide()
    '    End If
    '    If rblType.SelectedIndex = 1 Then

    '        Response.Redirect("AssetCategory.aspx")
    '    End If
    'End Sub
End Class
