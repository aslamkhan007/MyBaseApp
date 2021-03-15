Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.StreamWriter

Partial Class SalesAnalysisSystem_Dispatch_Details
    Inherits System.Web.UI.Page

    Dim obj1 As Functions = New Functions
    Dim sm As SendMail = New SendMail
    ' Dim obj As Connection = New Connection
    Dim ConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("SOMConnectionString").ConnectionString
    'Dim constr2 As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Dim conn As SqlConnection = New SqlConnection(ConStr)

    Protected Sub lnkGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGet.Click

        If (conn.State = Data.ConnectionState.Closed) Then
            conn.Open()
        End If

        Dim sql As String
        sql = "Exec jct_sas_sales_order_detail_dnv_edit_fetch '" & txtSDate.Text & "', '" & txtEDate.Text & "','" & DropDownList1.SelectedItem.Value & "' "
        Dim cmd As SqlCommand = New SqlCommand(sql, conn)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)
        CreateExcelFile(dt)
        'lnkReport.Visible = True
        'lnkReport.Text = "Click here to download the Dispatch detail for Period '" & txtSDate.Text & "' - '" & txtEDate.Text & "'"
        'Response.ClearContent()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename = {0}", System.IO.Path.GetFileName("DispatchDetail.xls")))
        Response.AppendHeader("Content-Disposition", "attachment; filename=DispatchDetail.xls")
        Response.TransmitFile(Server.MapPath("DispatchDetail.xls"))
        Response.End()
        conn.Close()

    End Sub

    Function CreateExcelFile(ByVal dt As DataTable) As Boolean

        Dim bFileCreated As Boolean = False
        Dim sTableStart As String = "<HTML><BODY><TABLE Border=1><TR><TH>Dispatch Details Between '" & txtSDate.Text & "' AND '" & txtEDate.Text & "' </TH></TR>"
        Dim sTableEnd As String = "</TABLE></BODY></HTML>"
        Dim sTableData As String = ""
        Dim nRow As Long
        sTableData &= "<TR>"
        For nCol = 0 To dt.Columns.Count - 1
            sTableData &= "<TD><B>" & dt.Columns(nCol).ColumnName & "</B></TD>"
        Next
        sTableData &= "</TR>"
        For nRow = 0 To dt.Rows.Count - 1
            sTableData &= "<TR>"
            For nCol = 0 To dt.Columns.Count - 1
                sTableData &= "<TD>" & dt.Rows(nRow).Item(nCol).ToString & "</TD>"
            Next
            sTableData &= "</TR>"
        Next
        Dim sTable As String = sTableStart & sTableData & sTableEnd
        '  Dim oExcelFile As System.IO.File
        Dim oExcelWrite As System.IO.StreamWriter
        Dim sExcelFile As String = Server.MapPath("DispatchDetail.xls")
        oExcelWrite = IO.File.CreateText(sExcelFile)
        oExcelWrite.WriteLine(sTable)
        oExcelWrite.Close()
        bFileCreated = True
        Return bFileCreated

    End Function

    Protected Sub lnkReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkReset.Click
        txtSDate.Text = ""
        txtEDate.Text = ""

    End Sub

    Protected Sub lnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFetch.Click
        'If (conn.State = Data.ConnectionState.Closed) Then
        '    conn.Open()
        'End If
        'Dim sql As String
        'sql = "Exec jct_sas_sales_dispatch_detail_dnv '" & txtSDate.Text & "', '" & txtEDate.Text & "' "
        'Dim cmd As SqlCommand = New SqlCommand(sql, conn)
        'Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        'Dim ds As DataSet = New DataSet
        'da.Fill(ds)
        'Dim dt As DataTable = ds.Tables(0)
        ' grdOrderDetail.DataSource = SqlDataSource1

        'grdOrderDetail.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub grdOrderDetail_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles grdOrderDetail.RowUpdated

        'SqlDataSource1.UpdateParameters.Item("dnv_actual").DefaultValue = e.NewValues("dnv_actual")
        'SqlDataSource1.UpdateParameters.Item("order_no").DefaultValue = e.NewValues("order_no")
        'SqlDataSource1.UpdateParameters.Item("order_srl_no").DefaultValue = e.NewValues("order_srl_no")
        'SqlDataSource1.UpdateParameters.Item("Item_no").DefaultValue = e.NewValues("Item_no")
        'SqlDataSource1.UpdateParameters.Item("variant").DefaultValue = e.NewValues("variant")
        'SqlDataSource1.UpdateParameters.Item("control_serial_no").DefaultValue = e.NewValues("control_serial_no")
        'SqlDataSource1.UpdateParameters.Item("date_c_no").DefaultValue = e.NewValues("date_c_no")

        'SqlDataSource1.Update()

        If e.AffectedRows > 0 Then

            Dim order_no As String = SqlDataSource1.UpdateParameters.Item("order_no").DefaultValue
            Dim order_srl_no As String = SqlDataSource1.UpdateParameters.Item("order_srl_no").DefaultValue
            Dim Item_no As String = SqlDataSource1.UpdateParameters.Item("Item_no").DefaultValue
            Dim variant_no As String = SqlDataSource1.UpdateParameters.Item("variant").DefaultValue
            Dim control_serial_no As String = SqlDataSource1.UpdateParameters.Item("control_serial_no").DefaultValue
            Dim date_c_no As String = SqlDataSource1.UpdateParameters.Item("date_c_no").DefaultValue
            Dim dnv_actual As String = SqlDataSource1.UpdateParameters.Item("dnv_actual").DefaultValue
            Dim dnv_mkt As String = e.NewValues("dnv_cost")

            If dnv_actual = "" Then
                dnv_actual = "NULL"
            End If

            Dim sql As String = "insert jct_sas_dnv_revision_log (CompanyCode,Location,user_code,Order_No,order_srl_no,Item_No,variant,control_serial_no,date_c_no,dnv_mkt,dnv_actual, revision_date) " & _
                                "values('JCT00LTD','PHG','" & Session("EmpCode") & "','" & order_no & "'," & order_srl_no & ",'" & Item_no & "','" & variant_no & "','" & control_serial_no & "','" & date_c_no & "'," & dnv_mkt & "," & dnv_actual & ",getdate())"

            If obj1.InsertRecord(sql) Then
                grdOrderDetail.Caption = "DnV Updated Successfully!!"
            Else
                grdOrderDetail.Caption = "DnV Updated Successfully!! But revision record not created."
            End If

            Dim dnv As String = "DnV for Order " & order_no & _
                                " " & Item_no & " " & variant_no & " Control No " & _
                                " " & control_serial_no & _
                                " " & date_c_no & " updated to " & dnv_actual
            blsActionHistory.Items.Add(dnv)
            sm.SendMail("jagdeep@jctltd.com", "dummy@jctltd.com", dnv, dnv)

        Else
            grdOrderDetail.Caption = "Error"

        End If

    End Sub

    Protected Sub grdOrderDetail_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdOrderDetail.RowUpdating

        SqlDataSource1.UpdateParameters.Item("order_no").DefaultValue = CType(grdOrderDetail.Rows(e.RowIndex).FindControl("lblOrderNo"), Label).Text
        SqlDataSource1.UpdateParameters.Item("order_srl_no").DefaultValue = CType(grdOrderDetail.Rows(e.RowIndex).FindControl("lblorder_litem_no"), Label).Text
        SqlDataSource1.UpdateParameters.Item("Item_no").DefaultValue = CType(grdOrderDetail.Rows(e.RowIndex).FindControl("lblItem_no"), Label).Text
        SqlDataSource1.UpdateParameters.Item("variant").DefaultValue = CType(grdOrderDetail.Rows(e.RowIndex).FindControl("lblvariant"), Label).Text
        SqlDataSource1.UpdateParameters.Item("control_serial_no").DefaultValue = CType(grdOrderDetail.Rows(e.RowIndex).FindControl("lblcontrol_serial_no"), Label).Text
        SqlDataSource1.UpdateParameters.Item("date_c_no").DefaultValue = CType(grdOrderDetail.Rows(e.RowIndex).FindControl("lbldate_c_no"), Label).Text
        SqlDataSource1.UpdateParameters.Item("dnv_actual").DefaultValue = CType(grdOrderDetail.Rows(e.RowIndex).FindControl("txtdnv_actual"), TextBox).Text

        'SqlDataSource1.UpdateParameters.Item("dnv_actual").DefaultValue = e.NewValues("dnv_actual")
        'SqlDataSource1.UpdateParameters.Item("order_no").DefaultValue = e.NewValues("order_no")
        'SqlDataSource1.UpdateParameters.Item("order_srl_no").DefaultValue = e.NewValues("order_srl_no")
        'SqlDataSource1.UpdateParameters.Item("Item_no").DefaultValue = e.NewValues("Item_no")
        'SqlDataSource1.UpdateParameters.Item("variant").DefaultValue = e.NewValues("variant")
        'SqlDataSource1.UpdateParameters.Item("control_serial_no").DefaultValue = e.NewValues("control_serial_no")
        'SqlDataSource1.UpdateParameters.Item("date_c_no").DefaultValue = e.NewValues("date_c_no")

        Dim i As Integer = SqlDataSource1.Update()
        blsActionHistory.Items.Add(i)

        'grdOrderDetail.Caption = e.NewValues("dnv_actual")

        'Dim sql As String = SqlDataSource1.UpdateCommand

    End Sub

End Class
