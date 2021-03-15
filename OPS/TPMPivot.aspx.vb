﻿Imports System
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

Partial Class ops_Pivot
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

        If (Session("empcode").ToString = "") Then
            Response.Redirect("~/login.aspx")
        End If

        If Not IsPostBack Then



            rdpFrom.SelectedDate = Now.AddDays(-2)
            rdpTo.SelectedDate = DateTime.Today


        End If





    End Sub



    Public Sub BindGrid(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                RadDispatch.DataSource = ds
                RadDispatch.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub





    Protected Sub ItemGroup()

        SqlPass = "EXEC JCT_OPS_DISPATCH_DETAIL '" & rdpFrom.SelectedDate.Value & "', '" & rdpTo.SelectedDate.Value & "','" & Session("empcode").ToString & "'  "

        If SqlPass <> "" Then
            BindGrid(SqlPass)
        End If
    End Sub


    Protected Sub CallToBind()


        SqlPass = "EXEC JCT_OPS_DISPATCH_DETAIL '" & rdpFrom.SelectedDate.Value & "', '" & rdpTo.SelectedDate.Value & "','" & Session("empcode").ToString & "'  "

        If SqlPass <> "" Then
            Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
            Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

            Try
                If Dr.HasRows = True Then
                    Dr.Close()
                    Dim ds As DataSet = New DataSet()
                    ds.Clear()



                    Da.Fill(ds)
                    RadDispatch.DataSource = ds



                    Dr.Close()
                Else
                    RadDispatch.DataSource = Nothing
                End If
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



    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

    End Sub
End Class
