Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient

Imports System.IO.StreamWriter
Imports Telerik.Web.UI

Partial Class Sale_Order_Process_Track
    Inherits System.Web.UI.Page

    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim SqlPass As String, SqlChartParm As String
    Dim Xl As GridViewExportUtil = New GridViewExportUtil
    Dim sum As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")


        If Not IsPostBack Then



            'rdpFrom.SelectedDate =
            rdpFrom.SelectedDate = Now.AddDays(-2)
            rdpTo.SelectedDate = DateTime.Today


        End If




    End Sub



    Public Sub BindGrid(ByVal SqlPass As String)


        Dim cmd As New SqlCommand(SqlPass, Obj.Connection())
        cmd.CommandTimeout = 0
        Dim Da As SqlDataAdapter = New SqlDataAdapter(cmd)

        Try

            Dim ds As DataSet = New DataSet()
            ds.Clear()
            Da.Fill(ds)

            RadDispatch.DataSource = ds
            RadDispatch.DataBind()




        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub





    Protected Sub ItemGroup()

        'SqlPass = "EXEC UnAssortAssort '" & rdpFrom.SelectedDate.Value & "', '" & rdpTo.SelectedDate.Value & "'  "
        SqlPass = "   EXEC JCT_PACKING_DISPATCH_FOR_MONTH  '" & rdpFrom.SelectedDate.Value & "' , '" & rdpTo.SelectedDate.Value & "'  "
        If SqlPass <> "" Then
            BindGrid(SqlPass)
        End If
    End Sub


    Protected Sub CallToBind()


        ' SqlPass = "EXEC UnAssortAssort '" & rdpFrom.SelectedDate.Value & "', '" & rdpTo.SelectedDate.Value & "'  "
        SqlPass = "   EXEC JCT_PACKING_DISPATCH_FOR_MONTH  '" & rdpFrom.SelectedDate.Value & "' , '" & rdpTo.SelectedDate.Value & "'  "
        If SqlPass <> "" Then
            Dim cmd As New SqlCommand(SqlPass, Obj.Connection())
            cmd.CommandTimeout = 0
            Dim Da As SqlDataAdapter = New SqlDataAdapter(cmd)


            Try
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                RadDispatch.DataSource = ds

            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
            Finally
                Obj.ConClose()
            End Try

        End If



    End Sub

    Protected Sub RadButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1.Click

        ItemGroup()

    End Sub

    Protected Sub RadButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2.Click


        SqlPass = "   EXEC JCT_PACKING_DISPATCH_FOR_MONTH  '" & rdpFrom.SelectedDate.Value & "' , '" & rdpTo.SelectedDate.Value & "'  "



        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection())
        cmd.CommandTimeout = 0
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)

        Dim dt As DataTable = ds.Tables(0)


        Dim attachment As String = "attachment; filename=HiteshExcel.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim tab As String = ""
        For Each dc As DataColumn In dt.Columns
            Response.Write(tab + dc.ColumnName)
            tab = vbTab
        Next
        Response.Write(vbLf)
        Dim i As Integer
        For Each dr As DataRow In dt.Rows
            tab = ""
            For i = 0 To dt.Columns.Count - 1
                Response.Write(tab & dr(i).ToString())
                tab = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.[End]()

        Obj.ConClose()



    End Sub

End Class
