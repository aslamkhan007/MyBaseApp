Imports System.Data
Imports System.Data.SqlClient

Partial Class FabricTestParticulars
    Inherits System.Web.UI.Page

    Dim ob As New Functions
    Dim sql As String
    Dim constr As String = "Data Source = misdev; Initial Catalog = jctgen; user id = itgrp; password = power; " 'Persist Security Info = true

    Protected Sub cmdView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdView.Click
        sql = "SELECT TOP 1 a.Sort_No as [Sort No], a.Fabric_Desc [Fabric Name], a.Weave, a.cot_p as [Cotton %], a.pol_p as [Polyester %], a.lyc_p as [Lycra %], a.vis_p as [Viscose %], a.nyl_p as [Nylon %], a.oth_p as [Others %] FROM production..jct_fabric_dev_hdr a " & _
                            "WHERE a.Sort_No = '" + txtSortNo.Text + "' AND a.flag = 'A' and rev_no = " & _
                            "(select max(rev_no) from production..jct_fabric_dev_hdr where Sort_No = a.Sort_No and Flag = a.Flag)"
        ob.FillGrid(sql, grdSearchResults)

        sql = "SELECT DISTINCT CASE WHEN Code = 'W' THEN 'WARP' WHEN Code = 'F' THEN 'WEFT' WHEN Code = 'S' THEN 'SELVEDGE' WHEN Code = 'M' THEN 'MONOGRAM' END as Code, CONVERT(VARCHAR, doubling) + '/' + CONVERT(VARCHAR, count_no) as 'Count' , Count_Name as 'Count Desc' " & _
            "FROM Production..jct_warp_weft_dtl WHERE CONVERT(VARCHAR, sort_no) = '" + txtSortNo.Text + "' AND rev_no = " & _
            "(SELECT MAX(rev_no) 'rev_no' FROM production..jct_fabric_dev_hdr WHERE CONVERT(VARCHAR(10), sort_no) = '" + txtSortNo.Text + "' AND flag = 'A')"

        ob.FillGrid(sql, grdWarpWeftDetail)

        If ddlFinish.SelectedValue <> "" Then
            sql = "jctgen..jct_fap_fabric_testing_particulars_merged @SortNo = '" & txtSortNo.Text & "', @Finish = '" & ddlFinish.SelectedValue & "'"
            ob.FillGrid(sql, grdFabricTestDetails)

            'Dim cmd As New SqlCommand(sql, New SqlConnection(constr))
            'Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            'Dim ds As DataSet = New DataSet
            'da.Fill(ds)
            'grdFabricTestDetails.DataSource = ds
            'grdFabricTestDetails.DataBind()
            'cmd.Connection.Open()
            'Dim dr As SqlDataReader = cmd.ExecuteReader()
            'If (dr.HasRows) Then
            '    dr.Read()
            '    txtEPI.Text = dr("EPI")
            '    txtPPI.Text = dr("PPI")
            '    txtWidth.Text = dr("Width")
            '    txtWeight.Text = dr("Weight")

            'End If

        Else
            grdFabricTestDetails.DataSource = Nothing
            grdFabricTestDetails.DataBind()
        End If

    End Sub

    Protected Sub txtSortNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSortNo.TextChanged

        Dim sql As String = "SELECT DISTINCT Finish FROM jct_fab_doc_header where Flag <> 'D' AND Item_Code = '" + txtSortNo.Text + "'"
        ob.FillList(ddlFinish, sql)
        Dim li As ListItem = New ListItem("DYED")
        If ddlFinish.Items.Contains(li) Then
            ddlFinish.Text = li.Text
        End If
        cmdView_Click(sender, Nothing)
        If Not SortExists() Then
            grdSearchResults.DataSource = Nothing
            grdSearchResults.DataBind()
            grdFabricTestDetails.DataSource = Nothing
            grdFabricTestDetails.DataBind()
            grdWarpWeftDetail.DataSource = Nothing
            grdWarpWeftDetail.DataBind()
        End If

        If Not SortTested() Then
            grdFabricTestDetails.DataSource = Nothing
            grdFabricTestDetails.DataBind()

        End If

    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        'Dim sql As String = "select count(Item_Code) from jct_fab_doc_header where flag <> 'D' and item_code = '" & txtSortNo.Text & "'"
        'Dim sql As String = "select count(Sort_No) from production..jct_fabric_dev_hdr where flag = 'A' and Sort_No = '" & txtSortNo.Text & "'"
        args.IsValid = SortExists()

    End Sub

    Protected Sub CustomValidator2_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
        'Dim sql As String = "select count(Item_Code) from jct_fab_doc_header where flag <> 'D' and item_code = '" & txtSortNo.Text & "'"
        'Dim sql As String = "select count(Sort_No) from production..jct_fabric_dev_hdr where flag = 'A' and Sort_No = '" & txtSortNo.Text & "'"
        args.IsValid = SortTested()

    End Sub

    Protected Function SortExists() As Boolean
        Dim sql As String = "select count(Sort_No) from production..jct_fabric_dev_hdr where flag = 'A' and Sort_No = '" & txtSortNo.Text & "'"
        If ob.FetchValue(sql) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Protected Function SortTested() As Boolean
        Dim sql As String = "select count(Item_Code) from jctdev..jct_fab_doc_header where flag <> 'D' and Item_Code = '" & txtSortNo.Text & "'"
        If ob.FetchValue(sql) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Protected Sub ddlFinish_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFinish.SelectedIndexChanged

    End Sub
End Class
