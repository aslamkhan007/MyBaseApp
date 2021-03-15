Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_Quotation_Action_Panel
    Inherits System.Web.UI.Page
    Dim con As New Connection
    Protected Sub grdUnauthorisedQuotes_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdUnauthorisedQuotes.RowCommand

        'Dim sqlstr As String = ""

        'If e.CommandName = "Authorise" Then
        '    sqlstr = "jct_ops_authorise_quote"
        'ElseIf e.CommandName = "Reject" Then
        '    'sqlstr = "jct_ops_reject_quote"
        '    Exit Sub
        'End If

        'Dim cn As New Connection
        'Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        'cmd.CommandType = CommandType.StoredProcedure

        'cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        'cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        'cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)

        'cmd.Parameters("@Quotation_no").Value = e.CommandArgument.ToString
        'cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
        'cmd.Parameters("@User_Type").Value = ""

        'Try
        '    cn.ConOpen()
        '    cmd.ExecuteNonQuery()
        '    cn.ConClose()
        '    grdUnauthorisedQuotes.DataBind()

        '    'grdAuthorisedQuotes.DataBind()

        'Catch ex As Exception
        '    'lblMessage.Text = ex.Message

        'End Try

    End Sub

    Protected Sub grdUnauthorisedQuotes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdUnauthorisedQuotes.SelectedIndexChanged
        lblQuotationNo.Text = grdUnauthorisedQuotes.SelectedDataKey.Value.ToString

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdAdvise_Click(sender As Object, e As System.EventArgs) Handles cmdAdvise.Click
        Dim sql As String = "jct_ops_set_quot_advised_schedule"
        Dim tran As SqlTransaction
        tran = con.Connection.BeginTransaction()
        Try

            For Each row As GridViewRow In grdDispatchDetail.Rows

                Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection, tran)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Shade", SqlDbType.VarChar, 100)
                cmd.Parameters.Add("Quantity", SqlDbType.Float, 100)
                cmd.Parameters.Add("Advised_Date", SqlDbType.DateTime)
                cmd.Parameters.Add("Remark", SqlDbType.VarChar, 2000)

                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters("Shade").Value = row.Cells(0).Text
                cmd.Parameters("Quantity").Value = row.Cells(1).Text
                Dim adv_date As String = CType(row.FindControl("txtAdvisedDate"), TextBox).Text
                cmd.Parameters("Advised_Date").Value = adv_date
                Dim remark As String = CType(row.FindControl("txtRemarks"), TextBox).Text
                cmd.Parameters("Remark").Value = remark
                cmd.ExecuteNonQuery()

            Next
            tran.Commit()
            lblMessage.Text = "Advise submitted successfuly for Quotation No. " & lblQuotationNo.Text
            
            Try

                Dim sm As New SendMail
                Dim subject As String = "Advise of Dispatch Schedule of Quotation No. " + lblQuotationNo.Text
                Dim body As String = "You have got advice for dispatch schedule of Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a>. Now you can proceed further to review your dispatch dates as per the advice. <br/> Click on Quotation Number to view details."
                sm.SendMail("rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)

            Catch ex As Exception

            End Try
            grdUnauthorisedQuotes.DataBind()
            grdDispatchDetail.DataBind()
        Catch ex As Exception
            tran.Rollback()

        End Try

    End Sub

    Protected Sub cmdApprove_Click(sender As Object, e As System.EventArgs) Handles cmdApprove.Click

        'Dim sql As String = "jct_ops_set_quot_schedule_status"
        ' Dim con As New Connection
        ' Dim tran As SqlTransaction
        ' tran = con.Connection.BeginTransaction()
        ' Try

        '     For Each row As GridViewRow In grdDispatchDetail.Rows

        '         Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection, tran)
        '         cmd.CommandType = CommandType.StoredProcedure

        '         cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 20)
        '         cmd.Parameters.Add("Approval_Status", SqlDbType.VarChar, 20)
        '         cmd.Parameters.Add("Approval_Authority", SqlDbType.VarChar, 20)

        '         cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
        '         cmd.Parameters("Approval_Status").Value = "PPCAuth"
        '         cmd.Parameters("Approval_Authority").Value = Session("EmpCode").ToString()

        '         cmd.ExecuteNonQuery()

        '     Next
        '     tran.Commit()
        ' Catch ex As Exception
        '     tran.Rollback()

        ' End Try

        Dim sql As String = "jct_ops_forward_quot_dispatch_sch"
        Dim con As New Connection
        Dim tran As SqlTransaction
        tran = con.Connection.BeginTransaction()
        Try

            For Each row As GridViewRow In grdDispatchDetail.Rows

                Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection, tran)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Shade", SqlDbType.VarChar, 100)
                cmd.Parameters.Add("Quantity", SqlDbType.Float, 100)
                cmd.Parameters.Add("Dispatch_Date", SqlDbType.DateTime)
                cmd.Parameters.Add("Action_Status", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Remark", SqlDbType.VarChar, 2000)

                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters("Shade").Value = row.Cells(0).Text
                cmd.Parameters("Quantity").Value = row.Cells(1).Text
                Dim adv_date As String = CType(row.FindControl("txtAdvisedDate"), TextBox).Text
                cmd.Parameters("Dispatch_Date").Value = adv_date
                cmd.Parameters("Action_Status").Value = "PPCAuth"
                Dim remark As String = CType(row.FindControl("txtRemarks"), TextBox).Text
                cmd.Parameters("Remark").Value = remark

                cmd.ExecuteNonQuery()
            Next
            tran.Commit()
            lblMessage.Text = "Approval submitted successfuly for Quotation No. " & lblQuotationNo.Text

            Try
                Dim sm As New SendMail
                Dim subject As String = "Approval of Dispatch Schedule of Quotation No. " + lblQuotationNo.Text
                Dim body As String = "Dispatch Schedule of Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a> has been approved by PPC Dept. Now you can proceed further for its authorisation. <br/> Click on Quotation Number to view details."
                sm.SendMail("rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)

            Catch ex As Exception

            End Try
            grdUnauthorisedQuotes.DataBind()
            grdDispatchDetail.DataBind()
        Catch ex As Exception
            tran.Rollback()

        End Try

    End Sub

End Class
