Imports System.Data
Imports System.Data.SqlClient

Partial Class FabricTestResults
    Inherits System.Web.UI.Page

    Dim ob As New Functions
    Dim sql As String
    Dim constr As String = "Data Source = misdev; Initial Catalog = jctgen; user id = itgrp; password = power; " 'Persist Security Info = true

    Protected Sub cmdView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim sql As String = "jct_fab_standard_actual_norm_comparison '" & txtSortNo.Text & "','" & ddlFinish.Text & "','" & txtDate.Text & "'"
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        DataList1.DataSource = cmd.ExecuteReader
        DataList1.DataBind()
        cn.Close()
        
    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound

        Dim sort_no As String = CType(e.Item.FindControl("lblSortNo"), Label).Text
        Dim finish As String = CType(e.Item.FindControl("lblFinish"), Label).Text
        Dim grd As GridView = CType(e.Item.FindControl("grdResults"), GridView)
        Dim grd2 As GridView = CType(e.Item.FindControl("grdNorms"), GridView)
        Dim grd_merged As GridView = CType(e.Item.FindControl("grdMerged"), GridView)

        'For getting Testing Data
        Dim sql As String = "jct_fab_standard_actual_norm_comparison2 '" & sort_no & "','" & finish & "','" & txtDate.Text & "'"
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dt1 As DataTable = New DataTable
        dt1.Load(cmd.ExecuteReader, LoadOption.OverwriteChanges)
        grd.DataSource = dt1
        grd.DataBind()
        cn.Close()

        'For getting Average for Testing data with conditions
        sql = "jct_fap_fabric_testing_particulars_merged"
        cmd = New SqlCommand(sql, cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 6).Value = sort_no
        cmd.Parameters.Add("@Finish", SqlDbType.VarChar, 10).Value = finish
        cn.Open()
        Dim ds As DataSet = New DataSet
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        da.Fill(ds)
        Dim rec_count As Short = 0
        Dim dt2 As DataTable = New DataTable
        Dim dtCount As DataTable = New DataTable
        If ds.Tables.Count > 1 Then
            dt2 = ds.Tables(0)
            dtCount = ds.Tables(1)
            rec_count = Val(dtCount.Rows(0).Item(0))
        End If

        'ds.Load(cmd.ExecuteReader, LoadOption.OverwriteChanges)
        'grd2.DataSource = dt2
        'grd2.DataBind()
        cn.Close()

        dt1.Columns.Add(New DataColumn("eVar%"))
        dt1.Columns.Add(New DataColumn("pVar%"))
        dt1.Columns.Add(New DataColumn("wtVar%"))
        dt1.Columns.Add(New DataColumn("wdVar%"))
        dt1.Columns.Add(New DataColumn("WhWtVar%"))
        dt1.Constraints.Clear()

        dt1.Columns("eVar%").SetOrdinal(dt1.Columns.IndexOf("EPI") + 1)
        dt1.Columns("pVar%").SetOrdinal(dt1.Columns.IndexOf("PPI") + 1)
        dt1.Columns("wtVar%").SetOrdinal(dt1.Columns.IndexOf("Weight") + 1)
        dt1.Columns("wdVar%").SetOrdinal(dt1.Columns.IndexOf("Width") + 1)
        dt1.Columns("WhWtVar%").SetOrdinal(dt1.Columns.IndexOf("Width") + 3)

        Dim drowFabTestStd As DataRow = dt1.NewRow
        drowFabTestStd.Item("Doc No") = "RnD Stds" & " (" & rec_count & ")"

        'For getting Fabric Particulars from Project Shikhar Data
        sql = "jct_fab_fabric_particulars"
        cmd = New SqlCommand(sql, cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 6).Value = sort_no
        cn.Open()
        Dim dt3 As DataTable = New DataTable
        dt3.Load(cmd.ExecuteReader, LoadOption.OverwriteChanges)
        cn.Close()

        Dim drowFabPart As DataRow = dt1.NewRow
        drowFabPart.Item("Doc No") = "Development Stds"

        'Display Averages for Testing Data
        If (dt2.Rows.Count > 0) Then
            drowFabTestStd.Item("EPI") = dt2.Rows(0).Item("EPI")
            drowFabTestStd.Item("PPI") = dt2.Rows(0).Item("PPI")
            drowFabTestStd.Item("Weight") = dt2.Rows(0).Item("Weight")
            drowFabTestStd.Item("Width") = dt2.Rows(0).Item("Width")
        End If

        'Display Fabric Particular Standards
        If (dt3.Rows.Count > 0) Then
            drowFabPart.Item("EPI") = dt3.Rows(0).Item("Std_EPI")
            drowFabPart.Item("PPI") = dt3.Rows(0).Item("Std_PPI")
            drowFabPart.Item("Weight") = dt3.Rows(0).Item("Std_Weight")
            drowFabPart.Item("Width") = dt3.Rows(0).Item("Std_Width")
        End If

        'Dim epi, ppi, weight, width As Double

        'If dt2.Rows.Count > 0 Then
        '    epi = dt2.Rows(0).Item("EPI")
        'Else
        '    epi = Nothing
        'End If

        'ppi = IIf(dt2.Rows.Count = 0, DBNull.Value, dt2.Rows(0).Item("PPI"))
        'weight = IIf(dt2.Rows.Count = 0, DBNull.Value, dt2.Rows(0).Item("Weight"))
        'width = IIf(dt2.Rows.Count = drowFabTestStd, DBNull.Value, dt2.Rows(0).Item("Width"))

        dt1.Rows.InsertAt(drowFabTestStd, 0)
        dt1.Rows.InsertAt(drowFabPart, 0)

        For i As Integer = 0 To dt1.Rows.Count - 1
            If (dt2.Rows.Count > 0) Then
                dt1.Rows(i).Item("eVar%") = Math.Round((Val(dt1.Rows(i).Item("EPI")) - Val(dt2.Rows(0).Item("EPI"))) / Val(dt2.Rows(0).Item("EPI")) * 100, 3)
                dt1.Rows(i).Item("pVar%") = Math.Round((Val(dt1.Rows(i).Item("PPI")) - Val(dt2.Rows(0).Item("PPI"))) / Val(dt2.Rows(0).Item("PPI")) * 100, 3)
                dt1.Rows(i).Item("wtVar%") = Math.Round((Val(dt1.Rows(i).Item("Weight")) - Val(dt2.Rows(0).Item("Weight"))) / Val(dt2.Rows(0).Item("Weight")) * 100, 3)
                dt1.Rows(i).Item("wdVar%") = Math.Round((Val(dt1.Rows(i).Item("Width")) - Val(dt2.Rows(0).Item("Width"))) / Val(dt2.Rows(0).Item("Width")) * 100, 3)

            End If
        Next

        For i As Integer = 2 To dt1.Rows.Count - 1

            dt1.Rows(i).Item("WhWtVar%") = Math.Round((Val(dt1.Rows(i).Item("Weight")) - Val(dt1.Rows(i).Item("WhWeight"))) / Val(dt1.Rows(i).Item("WhWeight")) * 100, 3)

            'Dim temp, temp2 As String
            'temp = dt1.Rows(i).Item("Weight")
            'temp2 = dt1.Rows(i).Item("WhWeight")

        Next



        grd_merged.DataSource = dt1
        grd_merged.DataBind()

        For Each row As GridViewRow In grd_merged.Rows
            If row.RowType = DataControlRowType.DataRow And row.Cells(1).Text <> "&nbsp;" Then
                If Val(row.Cells(7).Text) >= 5 Or Val(row.Cells(7).Text) <= -5 Then
                    row.Cells(7).CssClass = "GridRowRed"
                    row.Cells(7).BackColor = Drawing.Color.DarkRed
                End If

                If Val(row.Cells(9).Text) >= 5 Or Val(row.Cells(9).Text) <= -5 Then
                    row.Cells(9).CssClass = "GridRowRed"
                    row.Cells(9).BackColor = Drawing.Color.DarkRed
                End If

                If Val(row.Cells(11).Text) >= 5 Or Val(row.Cells(11).Text) <= -5 Then
                    row.Cells(11).CssClass = "GridRowRed"
                    row.Cells(11).BackColor = Drawing.Color.DarkRed
                End If

                If Val(row.Cells(13).Text) >= 5 Or Val(row.Cells(13).Text) <= -5 Then
                    row.Cells(13).CssClass = "GridRowRed"
                    row.Cells(13).BackColor = Drawing.Color.DarkRed
                End If

                If Val(row.Cells(15).Text) >= 5 Or Val(row.Cells(15).Text) <= -5 Then
                    row.Cells(15).CssClass = "GridRowRed"
                    row.Cells(15).BackColor = Drawing.Color.DarkRed
                End If

            End If
        Next

        'grd_merged.Rows(0).ForeColor = Drawing.Color.DarkGreen
        'grd_merged.Rows(1).ForeColor = Drawing.Color.DarkSlateBlue

        grd_merged.Rows(1).CssClass = "GridRowBlue"
        grd_merged.Rows(0).CssClass = "GridRowGreen"
        'grd_merged.Rows(2).CssClass = "GridRowOrange"

        'Next

        'grd_merged.Rows(grd_merged.Rows.Count - 3).Cells(8).CssClass = "GridRowRed"

        'Dim css As CssStyleCollection

        'grd_merged.Rows(0).Style.Add("background-image", "image/green_bar.png")
        'grd_merged.Rows(0).Style.Add("background-repeat", "repeat-x")
        'grd_merged.Rows(0).Style.Add("font-family", "Tahoma")
        'grd_merged.Rows(0).Style.Add("font-size", "8pt")
        'grd_merged.Rows(0).Style.Add("color", "white")
        'grd_merged.Rows(0).Style.Add("font-weight", "bold")
        'grd_merged.Rows(0).Style.Add("height", "20px")

        'grd_merged.Rows(1).Style.Add("background-image", "image/blue_bar.png")
        'grd_merged.Rows(1).Style.Add("background-repeat", "repeat-x")
        'grd_merged.Rows(1).Style.Add("font-family", "Tahoma")
        'grd_merged.Rows(1).Style.Add("font-size", "8pt")
        'grd_merged.Rows(1).Style.Add("color", "white")
        'grd_merged.Rows(1).Style.Add("font-weight", "bold")
        'grd_merged.Rows(1).Style.Add("height", "20px")

    End Sub

    Protected Sub txtSortNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSortNo.TextChanged

        Dim sql As String = "SELECT DISTINCT Finish FROM jct_fab_doc_header where Flag <> 'D' AND Item_Code = '" + txtSortNo.Text + "'"
        ob.FillList(ddlFinish, sql)
        ddlFinish.Items.Insert(0, "")
        DataList1.DataBind()

        'Dim li As ListItem = New ListItem("DYED")
        'If ddlFinish.Items.Contains(li) Then
        '    ddlFinish.Text = li.Text
        'End If
        'cmdView_Click(sender, Nothing)

        'If Not SortTested() Then
        '    DataList1.DataSource = Nothing
        '    DataList1.DataBind()

        'End If

    End Sub

    Protected Function SortTested() As Boolean

        Dim sql As String = "select count(Item_Code) from jctdev..jct_fab_doc_header where flag <> 'D' and Item_Code = '" & txtSortNo.Text & "'"
        If ob.FetchValue(sql) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim sql As String = "exec test"
        'Dim ds As DataSet = New DataSet
        'Dim da As SqlDataAdapter = New SqlDataAdapter(sql, New SqlConnection(constr))
        'da.Fill(ds)

        'grdTest1.DataSource = ds.Tables(0)
        'grdTest2.DataSource = ds.Tables(1)
        'grdTest1.DataBind()
        'grdTest2.DataBind()

    End Sub

End Class
