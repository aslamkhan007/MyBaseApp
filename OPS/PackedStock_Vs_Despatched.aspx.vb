Imports System
Imports System.Data.SqlClient
'Imports System.Reflection
'Imports System.Net.Mail
'Imports System.IO
'Imports System.Data
Partial Class OPS_PackedStock_Vs_Despatched
 
    Inherits System.Web.UI.Page
    Dim con As SqlConnection = New SqlConnection("Data Source=Miserp;Initial Catalog=shp;Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 100000000;")
    'Connection ObjCon=new Connection();
    Dim objFun As Functions = New Functions
    Dim Qry As String = ""

    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
        '  Qry = "Exec Jct_Ops_PackedStock_Vs_Despatched '" & ddlMonthFrom.SelectedItem.Value & "','" & ddlMonthTo.SelectedItem.Value & "','" & Request.ServerVariables("REMOTE_ADDR") & "'"
        'original Qry = "Exec Jct_Ops_PackedStock_Vs_Despatched_New_Test '" & ddlMonthFrom.SelectedItem.Value & "','" & ddlMonthTo.SelectedItem.Value & "','" & Request.ServerVariables("REMOTE_ADDR") & "'"

        Qry = "exec Jct_Ops_PackedStock_Vs_Despatched_New_Final '" & ddlMonthFrom.SelectedItem.Value & "','" & ddlMonthTo.SelectedItem.Value & "','" & Request.ServerVariables("REMOTE_ADDR") & "','N','" & ddlFinYr.SelectedItem.Text & "'"
    
        'Dim Scrpt As String
        'Scrpt = "alert('" + Qry + "');"
        'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
    
        objFun.FillGrid(Qry, GridView1, con)
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'e.Row.Cells(5).Visible = False
        'e.Row.Cells(6).Visible = False s
  
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        With GridView1
            Dim MthYr As String = ""
            MthYr = .SelectedRow.Cells(6).Text & "-" & .SelectedRow.Cells(7).Text
            'Original before 15-Apr-2013 Qry = "exec Jctgen..Jct_Ops_Packed_Vs_Despatched_DayWiseDetail '" & ddlMonthFrom.SelectedItem.Value & "','" & ddlMonthTo.SelectedItem.Value & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & MthYr & "','" & .SelectedRow.Cells(2).Text & "'"
            Qry = "exec Jctgen..Jct_Ops_Packed_Vs_Despatched_DayWiseDetail '" & .SelectedRow.Cells(2).Text & "', '" & .SelectedRow.Cells(6).Text & "','" & .SelectedRow.Cells(7).Text & "'"
            objFun.FillGrid(Qry, GridView2)
            Dim DateFrom As String = "", DateTo As String = ""

            DateFrom = ddlMonthFrom.SelectedItem.Value & "/01/" & ((Now.Date.Year))
            DateTo = ddlMonthTo.SelectedItem.Value & "/" & System.DateTime.DaysInMonth(Now.Date.Year, Val(ddlMonthTo.SelectedItem.Value)) & "/" & ((Now.Date.Year))


            'If Val(ddlMonthFrom.SelectedItem.Value) >= 1 And Val(ddlMonthFrom.SelectedItem.Value) <= 4 Then
            'DateFrom = ddlMonthFrom.SelectedItem.Value & "/01/" & ((Now.Date.Year) - 1)
            '    DateTo = ddlMonthTo.SelectedItem.Value & "/01/" & ((Now.Date.Year) - 1)
            'Else
            '    DateFrom = ddlMonthFrom.SelectedItem.Value & "/01/" & (Now.Date.Year)
            'End If
            Qry = "Exec jctgen..Jct_Ops_Invoice_GateOut_Data_New '" & .SelectedRow.Cells(6).Text & "','" & .SelectedRow.Cells(7).Text & "','N',0"
            'Response.Write("A" & Qry)
            objFun.FillGrid(Qry, GridView3)

            'Qry = "Exec jctgen..Jct_Ops_Invoice_GateOut_Data '" & DateFrom & "','" & DateTo & "','Y',0"
            Qry = "Exec jctgen..Jct_Ops_Invoice_GateOut_Data_New '" & .SelectedRow.Cells(6).Text & "','" & .SelectedRow.Cells(7).Text & "','Y',0"
            objFun.FillGrid(Qry, GridView4)

            '' Qry = "Exec jctgen..Jct_Ops_Invoice_GateOut_Data '" & DateFrom & "','" & DateTo & "','X',0"
            Qry = "Exec jctgen..Jct_Ops_Invoice_GateOut_Data_New '" & .SelectedRow.Cells(6).Text & "','" & .SelectedRow.Cells(7).Text & "','X',0"
            objFun.FillGrid(Qry, XGridView)
        End With
        'EXEC Jct_Ops_Packed_Vs_Despatched_DayWiseDetail '12','01', '192.168.20.28','12-2012','cotton'
    End Sub

    Protected Sub GridView4_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        e.Row.Cells(0).Attributes.Add("style", "white-space: nowrap;")
    End Sub


    Protected Sub XGridView_CellClicked(sender As Object, e As CustomControls.GridViewCellClickedEventArgs) Handles XGridView.CellClicked
        Dim DateFrom As String = "", DateTo As String = ""
        DateFrom = ddlMonthFrom.SelectedItem.Value & "/01/" & ((Now.Date.Year))
        DateTo = ddlMonthTo.SelectedItem.Value & "/" & System.DateTime.DaysInMonth(Now.Date.Year, Val(ddlMonthTo.SelectedItem.Value)) & "/" & ((Now.Date.Year))

        Qry = "Exec jctgen..Jct_Ops_Invoice_GateOut_Data '" & DateFrom & "','" & DateTo & "','C','" & e.HeaderText & "'"
        objFun.FillGrid(Qry, GridView5)
    End Sub
End Class
