﻿Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_Quotation_Qty
    Inherits System.Web.UI.Page

    Dim dt As DataTable = New DataTable
    Dim ofn As New Functions

    Protected Sub ibtAddShade_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtAddShade.Click

        If Not ViewState("data") Is Nothing Then
            dt = ViewState("data")

        Else

            dt.Columns.Add("Shade Code")
            dt.Columns.Add("DnV Cost")
            dt.Columns.Add("Shade Depth")
            dt.Columns.Add("DyeType")
            dt.Columns.Add("FinishCode")
            dt.Columns.Add("Finish")
            dt.Columns.Add("PrintingType")
            dt.Columns.Add("PeachingType")
            dt.Columns.Add("Quantity")
            dt.Columns.Add("Shade Cost")
            dt.Columns.Add("Length Upcharge %")
            dt.Columns.Add("Length Upcharge")
            dt.Columns.Add("Final DnV Cost")
            dt.Columns.Add("ShadeCatg")

        End If
        Dim Isyarn As String = Request.QueryString("Isyarn")
        'Dim charge As Double
        'For Each row As GridViewRow In grdShades.Rows
        '    If txtShade.Text = row.Cells(1).Text Then
        '        lblMessage.Text = txtShade.Text + " Shade Already Exists. Please remove existing one to add new quantity for " + txtShade.Text

        '        Exit Sub

        '    End If
        'Next

        'Try
        '    Dim sqlstr As String = "jct_ops_get_length_upcharge " & Val(txtQuantity.Text)
        '    charge = ofn.FetchValue(sqlstr)

        'Catch ex As Exception
        '    lblMessage.Text = ex.Message

        'End Try

        'Dim drow As DataRow = dt.NewRow
        'drow("ShadeCode") = txtShade.Text 'ddlShade.SelectedItem.Value
        'drow("ShadeDepth") = ddlShadeDepth.SelectedItem.Text
        ''drow("DyeType") = ddlDyeType.SelectedItem.Text
        ''drow("FinishCode") = ddlFinish.SelectedItem.Value
        ''drow("Finish") = ddlFinish.SelectedItem.Text
        ''drow("PrintingType") = ddlPrintingType.SelectedItem.Text
        'drow("Quantity") = txtQuantity.Text
        'drow("LengthUpCharge%") = charge
        'dt.Rows.Add(drow)

        Try
            Dim sqlstr As String = ""  '"jct_ops_calculate_quote_shade_qty_cost "

            'If ddlShadeDepth.SelectedItem.Text = "-" Then
            sqlstr = "jct_ops_calculate_cost_detail "
            'Else
            '    sqlstr = ""

            'End If

            Dim cn As New Connection
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            cmd.CommandType = CommandType.StoredProcedure

            'cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
            'cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30)
            'cmd.Parameters.Add("@Quantity", SqlDbType.Float, 100)
            'cmd.Parameters.Add("@Shade_Depth", SqlDbType.VarChar, 20)

            'cmd.Parameters("@Quotation_no").Value = lblQuotationNo.Text
            'cmd.Parameters("@Shade").Value = txtShade.Text
            'cmd.Parameters("@Quantity").Value = txtQuantity.Text
            'cmd.Parameters("@Shade_Depth").Value = ddlShadeDepth.SelectedItem.Value

            cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@Quantity", SqlDbType.Float, 100)
            cmd.Parameters.Add("@finish_code", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@dye_type", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@intensity", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@printing_type", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@peaching_type", SqlDbType.VarChar, 20)

            cmd.Parameters("@Quotation_no").Value = lblQuotationNo.Text

            If Isyarn = "True" Then
                cmd.Parameters("@Shade").Value = ddlsort.Text + "-" + txtShade.Text
            Else
                cmd.Parameters("@Shade").Value = txtShade.Text
            End If
            cmd.Parameters("@Quantity").Value = txtQuantity.Text
            cmd.Parameters("@finish_code").Value = IIf(ddlFinish.SelectedItem.Text = "", "-", ddlFinish.SelectedItem.Value)
            cmd.Parameters("@dye_type").Value = ddlDyeType.SelectedItem.Text
            cmd.Parameters("@intensity").Value = ddlShadeDepth.SelectedItem.Value
            cmd.Parameters("@printing_type").Value = ddlPrintingType.SelectedItem.Value
            cmd.Parameters("@peaching_type").Value = ddlPeachingType.SelectedItem.Value

            Dim dr As SqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                Dim dtrow As DataRow = dt.NewRow
                dtrow("Shade Code") = dr("Shade").ToString
                dtrow("Shade Depth") = dr("Shade Depth").ToString
                dtrow("Quantity") = dr("Quantity").ToString
                dtrow("DyeType") = ddlDyeType.SelectedItem.Text
                dtrow("FinishCode") = ddlFinish.SelectedItem.Value
                dtrow("Finish") = ddlFinish.SelectedItem.Text
                dtrow("PrintingType") = ddlPrintingType.SelectedItem.Text
                dtrow("PeachingType") = ddlPeachingType.SelectedItem.Text
                dtrow("Length Upcharge %") = dr("Length Upcharge %")
                dtrow("Length Upcharge") = dr("Length Upcharge")
                dtrow("Shade Cost") = dr("Shade Charge")
                dtrow("DnV Cost") = dr("DnV_Cost")
                dtrow("Final DnV Cost") = dr("Final DnV Cost")
                dtrow("ShadeCatg") = ddlShadeCat.SelectedItem.Value

                dt.Rows.Add(dtrow)

            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

        ViewState.Add("data", dt)
        grdShades.DataSource = dt
        grdShades.DataBind()

        CalculateTotalQty()

    End Sub

    Protected Sub CalculateTotalQty()

        Dim tot_qty As Decimal = 0.0

        For Each row As GridViewRow In grdShades.Rows
            tot_qty = tot_qty + Val(row.Cells(4).Text)
        Next

        txtEstOrderQty.Text = tot_qty

    End Sub

    Protected Sub ibtSave_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click
        If grdShades.Rows.Count < 1 Then
            lblMessage.Text = "No item found in the list to be saved. Please fill particulars and add item to the list and try again."
        ElseIf grdShades.Rows.Count >= 1 Then
            Dim tr As SqlTransaction
            Dim cn As New Connection
            Dim sqlstr As String = "jct_ops_create_quote_qty"
            tr = cn.Connection.BeginTransaction

            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@Quantity", SqlDbType.Float, 100)
            cmd.Parameters.Add("@Length_Upcharge_Perc", SqlDbType.Float)
            cmd.Parameters.Add("@Shade_Depth", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@DyeType", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@Finish_Code", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@Finish_Desc", SqlDbType.VarChar, 100)
            cmd.Parameters.Add("@Printing_Type", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@Peaching_Type", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@Init_DnV_Cost", SqlDbType.Float)
            cmd.Parameters.Add("@Shade_Cost", SqlDbType.Float)
            cmd.Parameters.Add("@Length_Upcharge_Val", SqlDbType.Float)
            cmd.Parameters.Add("@Final_DnV_Cost", SqlDbType.Float)
            cmd.Parameters.Add("@Uom", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000)
            cmd.Parameters.Add("@Sale_Notes", SqlDbType.VarChar, 5000)
            cmd.Parameters.Add("@Shade_Catg", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@ClearFlag", SqlDbType.VarChar, 1) 'Flag used to manage and perform modifications and maintain revisions of Qty.

            Try
                Dim cf As String = "1"
                For Each row As GridViewRow In grdShades.Rows
                    cmd.Parameters("@ClearFlag").Value = cf
                    cmd.Parameters("@Quotation_no").Value = Request.QueryString("quot")
                    cmd.Parameters("@Shade").Value = IIf(row.Cells(1).Text.Trim() = "&nbsp;", "", row.Cells(1).Text.Trim())
                    cmd.Parameters("@Shade_Depth").Value = IIf(row.Cells(3).Text.Trim() = "&nbsp;", "", row.Cells(3).Text.Trim()) 'row.Cells(3).Text
                    cmd.Parameters("@DyeType").Value = IIf(row.Cells(9).Text.Trim() = "&nbsp;", "", row.Cells(9).Text.Trim()) ' row.Cells(9).Text
                    cmd.Parameters("@Finish_Code").Value = IIf(row.Cells(10).Text.Trim() = "&nbsp;", "", row.Cells(10).Text.Trim()) 'row.Cells(10).Text
                    cmd.Parameters("@Finish_Desc").Value = IIf(row.Cells(11).Text.Trim() = "&nbsp;", "", row.Cells(11).Text.Trim()) 'row.Cells(11).Text
                    cmd.Parameters("@Printing_Type").Value = IIf(row.Cells(12).Text.Trim() = "&nbsp;", "", row.Cells(12).Text.Trim()) 'row.Cells(12).Text
                    cmd.Parameters("@Peaching_Type").Value = IIf(row.Cells(13).Text.Trim() = "&nbsp;", "", row.Cells(13).Text.Trim())  'row.Cells(13).Text
                    cmd.Parameters("@Quantity").Value = Val(row.Cells(4).Text)
                    cmd.Parameters("@Init_DnV_Cost").Value = Val(row.Cells(2).Text)
                    cmd.Parameters("@Length_Upcharge_Perc").Value = Val(row.Cells(6).Text)
                    cmd.Parameters("@Shade_Cost").Value = Val(row.Cells(5).Text)
                    cmd.Parameters("@Length_Upcharge_Val").Value = Val(row.Cells(7).Text)
                    cmd.Parameters("@Final_DnV_Cost").Value = Val(row.Cells(8).Text)
                    cmd.Parameters("@UOM").Value = ddlUom.SelectedItem.Text
                    cmd.Parameters("@Remarks").Value = txtRemarks.Text
                    cmd.Parameters("@Sale_Notes").Value = txtSaleNotes.Text
                    cmd.Parameters("@Shade_Catg").Value = row.Cells(14).Text

                    cmd.ExecuteNonQuery()
                    cf = "0"

                Next
                tr.Commit()
                lblMessage.Text = "Quantities for Quotation No " & lblQuotationNo.Text & " has been Saved Successfully!"
            Catch ex As Exception
                tr.Rollback()
                'ofn.Alert(ex.Message)
                lblMessage.Text = ex.Message

            Finally
                cn.ConClose()

            End Try

        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        lblMessage.Text = ""
        lblQuotationNo.Text = Request.QueryString("quot")
        ddlQuotationType.Text = Request.QueryString("Quotype")
        Dim isyan As String
        isyan = Request.QueryString("Isyarn")


        If Not ViewState("data") Is Nothing Then

            dt = ViewState("data")
        Else
            dt.Columns.Add("Shade Code")
            dt.Columns.Add("DnV Cost")
            dt.Columns.Add("Shade Depth")
            dt.Columns.Add("Quantity")
            dt.Columns.Add("Shade Cost")
            dt.Columns.Add("Length Upcharge %")
            dt.Columns.Add("Length Upcharge")
            dt.Columns.Add("Final DnV Cost")
            dt.Columns.Add("DyeType")
            dt.Columns.Add("FinishCode")
            dt.Columns.Add("Finish")
            dt.Columns.Add("PrintingType")
            dt.Columns.Add("PeachingType")
            dt.Columns.Add("ShadeCatg")

        End If

        If Not IsPostBack Then

            If isyan = "True" Then
                ddlsort.Visible = True
                RequiredFieldValidator03.Enabled = True
                txtsortremark.Visible = True
                sortdesc.Visible = True
                lblsub.Visible = True
                GetSortNo()
            End If


            Dim sqlstr As String = "jct_ops_get_quote_qty '" & lblQuotationNo.Text & "'"
            Dim cn As New Connection
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    Dim dtrow As DataRow = dt.NewRow
                    dtrow("Shade Code") = dr("Shade")
                    dtrow("DnV Cost") = dr("Init_Dnv_Cost")
                    dtrow("Shade Depth") = dr("Shade_Depth")
                    dtrow("Quantity") = dr("Quantity")
                    dtrow("Shade Cost") = dr("Shade_Cost")
                    dtrow("Length Upcharge %") = dr("Length_Upcharge_Perc")
                    dtrow("Length Upcharge") = dr("Length_Upcharge_Val")
                    dtrow("Final DnV Cost") = dr("Final_Dnv_Cost")
                    dtrow("DyeType") = dr("DyeType")
                    dtrow("FinishCode") = dr("Finish_Code")
                    dtrow("Finish") = dr("Finish_Desc")
                    dtrow("PrintingType") = dr("Printing_Type")
                    dtrow("PeachingType") = dr("Peaching_Type")
                    dtrow("ShadeCatg") = dr("Shade_Catg")
                    dt.Rows.Add(dtrow)
                    txtSaleNotes.Text = dr("Sale_Notes").ToString
                    txtRemarks.Text = dr("Remarks").ToString

                End While

            End If
            dr.Close()

            ViewState("data") = dt
            grdShades.DataSource = dt
            grdShades.DataBind()

        End If

        CalculateTotalQty()

    End Sub

    Protected Sub cmdDispatchSchedule_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtDispatchDetail.Click
        Response.Redirect("Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text)

    End Sub

    Protected Sub lnkPaymentTerms_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtPayTerms.Click
        Response.Redirect("Quotation_Pay_Terms.aspx?quot=" & lblQuotationNo.Text)

    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtBasicInfo.Click
        Response.Redirect("Quotation_Main.aspx?quot=" & lblQuotationNo.Text)

    End Sub

    Protected Sub grdShades_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdShades.RowDeleting

        lblMessage.Text = ""
        Dim row As String = e.RowIndex 'grdItems.SelectedRow.RowIndex.ToString

        Dim dt As DataTable = CType(ViewState("data"), DataTable)
        dt.Rows.RemoveAt(row)
        grdShades.DataSource = dt
        grdShades.DataBind()
        ViewState("data") = dt
        CalculateTotalQty()

    End Sub

    'Protected Sub chkShadeBreak_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkShadeBreak.CheckedChanged
    '    If chkShadeBreak.Checked Then
    '        txtShade.Enabled = False
    '        txtShade.Text = "Shades Awaited"
    '    ElseIf Not chkShadeBreak.Checked Then
    '        txtShade.Enabled = True
    '    End If

    'End Sub

    'Protected Sub ddlQuotationType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQuotationType.SelectedIndexChanged

    '    If ddlQuotationType.SelectedItem.Text = "Forecast" Then
    '        txtShade.Enabled = False
    '        txtShade.Text = "-"
    '        RequiredFieldValidator1.Enabled = False

    '    ElseIf ddlQuotationType.SelectedItem.Text = "Regular" Then
    '        txtShade.Text = ""
    '        txtShade.Enabled = True
    '        RequiredFieldValidator1.Enabled = True

    '    End If

    'End Sub
    Private Sub GetSortNo()
        Try
            Dim sort_no As String
            Dim cn As New Connection
            Dim cn1 As New Connection
            Dim cmd1 As SqlCommand
            Dim sqlstr As String = "Select item_code from jct_ops_Quotation_hdr where Quotation_no='" & lblQuotationNo.Text & "' "
            cmd1 = New SqlCommand(sqlstr, cn1.Connection)
            Dim dr As SqlDataReader = cmd1.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    sort_no = dr("item_code")
                End While
            End If
            dr.Close()

            bindsort(sort_no)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bindsort(sort_no As String)
        Try
            Dim cn As New Connection
            Dim cn1 As New Connection
            Dim cmd1 As SqlCommand
            'Dim sqlstr As String = "select sort_no from production..jct_fabric_dev_hdr where ref_sort_no='" & temp & "' "

            'jct_ops_fabric_sort

            Dim sqlstr As String = "jct_ops_fabric_sort '" & sort_no & "'"


            cmd1 = New SqlCommand(sqlstr, cn1.Connection)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)

            ddlsort.DataValueField = "sort_no"
            ddlsort.DataTextField = "sort_no"
            ddlsort.DataSource = ds
            ddlsort.DataBind()
            ddlsort.Items.Insert(0, New ListItem([String].Empty, [String].Empty))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddlsort_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlsort.SelectedIndexChanged
        Try
            Dim temp As String
            Dim cn As New Connection
            Dim cn1 As New Connection
            Dim cmd1 As SqlCommand
            Dim sqlstr As String = "select remarks from production..jct_fabric_dev_hdr where sort_no='" & ddlsort.Text & "' "
            cmd1 = New SqlCommand(sqlstr, cn1.Connection)
            Dim dr As SqlDataReader = cmd1.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    txtsortremark.Text = dr("remarks")
                End While
            End If

            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
