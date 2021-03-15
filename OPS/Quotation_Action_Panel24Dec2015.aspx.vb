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
        dlsRefDocs.DataBind()
        Dim Quotation As String = grdUnauthorisedQuotes.SelectedDataKey.Value.ToString

        If CheckQutation(Quotation) = True Then
            lblQuotationNo.Text = grdUnauthorisedQuotes.SelectedDataKey.Value.ToString
            dlsRefDocs.DataBind()
        Else

            ScriptManager.RegisterStartupScript(TryCast(sender, Control), Me.GetType(), "redirect", "alert('The Quotation Greige Date  not authorized yet'); window.location='" + Request.ApplicationPath + "/OPS/Quotation_Action_Panel.aspx';", True)

        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If GetAuthLevel() = "DEV" Then
            cmdApprove.Visible = False
            cmdAdvise.Visible = False
            grdDispatchDetail.Visible = False
            cmdDevApprove.Visible = True
            cmdReject.Visible = True

        ElseIf GetAuthLevel() = "PPC" Then
            cmdApprove.Visible = True
            cmdAdvise.Visible = True
            grdDispatchDetail.Visible = True
            cmdDevApprove.Visible = False
            cmdReject.Visible = True
            bindgridAuth()

        Else
            cmdApprove.Visible = False
            cmdAdvise.Visible = False
            grdDispatchDetail.Visible = False
            cmdDevApprove.Visible = False
            cmdReject.Visible = False

        End If

    End Sub

    Protected Sub cmdAdvise_Click(sender As Object, e As System.EventArgs) Handles cmdAdvise.Click

        'If grdDispatchDetail.Rows.Count = 0 Then
        '    lblMessage.Text = "Please select a quotation to view its dispatch date."
        '    Exit Sub
        'End If

        'Dim sql As String = "jct_ops_set_quot_advised_schedule"
        'Dim tran As SqlTransaction
        'tran = con.Connection.BeginTransaction()
        'Try

        '    For Each row As GridViewRow In grdDispatchDetail.Rows

        '        Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection, tran)
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 20)
        '        cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 20)
        '        cmd.Parameters.Add("Shade", SqlDbType.VarChar, 100)
        '        cmd.Parameters.Add("Quantity", SqlDbType.Float, 100)
        '        cmd.Parameters.Add("Advised_Date", SqlDbType.DateTime)
        '        cmd.Parameters.Add("Remark", SqlDbType.VarChar, 2000)

        '        cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
        '        cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
        '        cmd.Parameters("Shade").Value = row.Cells(0).Text
        '        cmd.Parameters("Quantity").Value = row.Cells(1).Text
        '        Dim adv_date As String = CType(row.FindControl("txtAdvisedDate"), TextBox).Text
        '        cmd.Parameters("Advised_Date").Value = adv_date
        '        Dim remark As String = CType(row.FindControl("txtRemarks"), TextBox).Text
        '        cmd.Parameters("Remark").Value = remark
        '        cmd.ExecuteNonQuery()

        '    Next
        '    tran.Commit()
        '    lblMessage.Text = "Advise submitted successfuly for Quotation No. " & lblQuotationNo.Text

        '    ResetGrids()

        '    Dim sm As New SendMail

        '    Try

        '        Dim subject As String = "Advise of Dispatch Schedule of Quotation No. " + lblQuotationNo.Text
        '        Dim body As String = "You have got advice for dispatch schedule of Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a>. Now you can proceed further to review your dispatch dates as per the advice. <br/> Click on Quotation Number to view details."

        '        'sm.SendMail("rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)
        '        sql = "jct_ops_get_quot_mail_recipients"
        '        Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection)
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
        '        cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
        '        cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
        '        cmd.Parameters("Action").Value = "PPCAdvise"
        '        cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
        '        cmd.Parameters("User_Code").Value = Session("EmpCode").ToString

        '        Dim dr As SqlDataReader
        '        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        '        Dim recipients, m_sender, sender_name, recipient_name As String
        '        recipients = ""
        '        m_sender = ""
        '        sender_name = ""
        '        recipient_name = ""

        '        If dr.HasRows Then
        '            While dr.Read
        '                If dr(0).ToString = "To" Then
        '                    recipients += dr("e_mailid").ToString + ";"
        '                    recipient_name += dr("empname").ToString + ","
        '                ElseIf dr(0).ToString = "From" Then
        '                    m_sender = dr("e_mailid").ToString
        '                    sender_name = dr("empname").ToString
        '                End If
        '            End While
        '        End If
        '        dr.Close()

        '        Dim bcc As String = "rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com"
        '        'sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body)

        '    Catch ex As Exception
        '        sm.SendMail2("ashish@jctltd.com", "", "", "noreply@jctltd.com", "Error Occurred while sending mail at PPC Advise", ex.Message)
        '    End Try
        '    lblQuotationNo.Text = ""
        'Catch ex As Exception
        '    tran.Rollback()

        'End Try

        If grdDispatchDetail.Rows.Count = 0 Then
            lblMessage.Text = "Please select a quotation to view its dispatch date."
            Exit Sub
        End If

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
                cmd.Parameters.Add("Line_Item_No", SqlDbType.Int)

                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters("Shade").Value = row.Cells(0).Text
                cmd.Parameters("Quantity").Value = row.Cells(1).Text
                Dim adv_date As String = CType(row.FindControl("txtAdvisedDate"), TextBox).Text
                cmd.Parameters("Advised_Date").Value = adv_date
                Dim remark As String = CType(row.FindControl("txtRemarks"), TextBox).Text
                cmd.Parameters("Remark").Value = remark
                cmd.Parameters("Line_Item_No").Value = row.RowIndex + 1

                cmd.ExecuteNonQuery()

            Next
            tran.Commit()
            lblMessage.Text = "Advise submitted successfuly for Quotation No. " & lblQuotationNo.Text

            ResetGrids()

            Dim sm As New SendMail
			    Dim baseurl As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
            Try
			     baseurl = baseurl + "ops/Quotation_Dispatch_Sch.aspx?quot=" + lblQuotationNo.Text

                Dim subject As String = "Advise of Dispatch Schedule of Quotation No. " + lblQuotationNo.Text
                'Dim body As String = "You have got advice for dispatch schedule of Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a>. Now you can proceed further to review your dispatch dates as per the advice. <br/> Click on Quotation Number to view details."
				Dim body As String = "You have got advice for dispatch schedule of Quotation # <a href = '" + baseurl + "'>" & lblQuotationNo.Text & "</a>. Now you can proceed further to review your dispatch dates as per the advice. <br/> Click on Quotation Number to view details."
                'sm.SendMail("rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)
                sql = "jct_ops_get_quot_mail_recipients"
                Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
                cmd.Parameters("Action").Value = "PPCAdvise"
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim recipients, m_sender As String
                recipients = ""
                m_sender = ""
                If dr.HasRows Then
                    While dr.Read
                        If dr(0).ToString = "To" Then
                            recipients += dr("e_mailid").ToString + ";"
                        ElseIf dr(0).ToString = "From" Then
                            m_sender = dr("e_mailid").ToString
                        End If
                    End While
                End If
                dr.Close()
                Dim bcc As String = "rbaksshi@jctltd.com; manishk@jctltd.com; harendra@jctltd.com"
                sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body)

            Catch ex As Exception
                sm.SendMail("manishk@jctltd.com", "noreply@jctltd.com", "Error Occurred ", "Error Occurred <br/>" & ex.Message)

            End Try
            lblQuotationNo.Text = ""

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

		  Dim baseurl As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
        If grdDispatchDetail.Rows.Count = 0 Then
            lblMessage.Text = "Please select a quotation to view its dispatch date."
            Exit Sub
        End If

        Dim sqlstr As String = "jct_ops_forward_quot_dispatch_sch"
        Dim con As New Connection
        Dim tran As SqlTransaction
        tran = con.Connection.BeginTransaction()
        Try

            For Each row As GridViewRow In grdDispatchDetail.Rows

                Dim cmd As SqlCommand = New SqlCommand(sqlstr, con.Connection, tran)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Shade", SqlDbType.VarChar, 100)
                cmd.Parameters.Add("Quantity", SqlDbType.Float, 100)
                cmd.Parameters.Add("Dispatch_Date", SqlDbType.DateTime)
                cmd.Parameters.Add("Action_Status", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Remark", SqlDbType.VarChar, 2000)
                cmd.Parameters.Add("Line_No", SqlDbType.Int)

                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters("Shade").Value = row.Cells(0).Text
                cmd.Parameters("Quantity").Value = row.Cells(1).Text
                Dim adv_date As String = CType(row.FindControl("txtAdvisedDate"), TextBox).Text
                cmd.Parameters("Dispatch_Date").Value = adv_date
                cmd.Parameters("Action_Status").Value = "PPCAuth"
                Dim remark As String = CType(row.FindControl("txtRemarks"), TextBox).Text
                cmd.Parameters("Remark").Value = remark
                cmd.Parameters("Line_No").Value = row.RowIndex + 1

                cmd.ExecuteNonQuery()

            Next
            tran.Commit()
            lblMessage.Text = "Approval submitted successfuly for Quotation No. " & lblQuotationNo.Text

            ResetGrids()

            Dim sm As New SendMail
            Try
                baseurl = baseurl + "ops/Quotation_Dispatch_Sch.aspx?quot=" + lblQuotationNo.Text
                Dim subject As String = "Approval of Dispatch Schedule of Quotation No. " + lblQuotationNo.Text
               ' Dim body As String = "Dispatch Schedule of Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a> has been approved by PPC Dept. Now you can proceed further for its authorisation. <br/> Click on Quotation Number to view details."
			      Dim body As String = "Dispatch Schedule of Quotation # <a href = '" + baseurl + "'>" & lblQuotationNo.Text & "</a> has been approved by PPC Dept. Now you can proceed further for its authorisation. <br/> Click on Quotation Number to view details."
			   
                'sm.SendMail("rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)

                sqlstr = "jct_ops_get_quot_mail_recipients"
                Dim cmd As SqlCommand = New SqlCommand(sqlstr, con.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
                cmd.Parameters("Action").Value = "PPCAuth"
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim recipients, m_sender As String
                recipients = ""
                m_sender = ""

                If dr.HasRows Then
                    While dr.Read
                        If dr(0).ToString = "To" Then
                            recipients += dr("e_mailid").ToString + ";"
                        ElseIf dr(0).ToString = "From" Then
                            m_sender = dr("e_mailid").ToString
                        End If
                    End While
                End If

                dr.Close()

                Dim bcc As String = "rbaksshi@jctltd.com; ashish@jctltd.com;manishk@jctltd.com; harendra@jctltd.com"
                sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body)

            Catch ex As Exception
                sm.SendMail("ashish@jctltd.com;manishk@jctltd.com", "noreply@jctltd.com", "Error Occurred ", "Error Occurred <br/>" & ex.Message)

            End Try
            lblQuotationNo.Text = ""

        Catch ex As Exception
            tran.Rollback()

        End Try

    End Sub

    Protected Sub cmdReject_Click(sender As Object, e As System.EventArgs) Handles cmdReject.Click

        Dim sqlstr As String = "jct_ops_reject_quote"

        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
        'cmd.Parameters.Add("User_Type", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("Auth_Type", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("Remarks", SqlDbType.VarChar, 2000)

        cmd.Parameters("Quotation_no").Value = lblQuotationNo.Text
        cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
        cmd.Parameters("Auth_Type").Value = "PPC"
        cmd.Parameters("Remarks").Value = txtRejectionRemarks.Text

        Dim sm As New SendMail

        Try

            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()
            grdUnauthorisedQuotes.DataBind()

            'grdAuthorisedQuotes.DataBind()

            Try
			 Dim baseurl As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
                Dim body As String = ""

                If GetAuthLevel() = "DEV" Then
				  baseurl = baseurl + "ops/Quotation_Dispatch_Sch.aspx?quot=" + lblQuotationNo.Text
                   ' body = "Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a> has been rejected by Development Dept (" + Session("EmpName").ToString + "). You may make changes in it as per the suggestions. " & _
				    body = "Quotation # <a href = '+ baseurl +'>" & lblQuotationNo.Text & "</a> has been rejected by Development Dept (" + Session("EmpName").ToString + "). You may make changes in it as per the suggestions. " & _
                    "<br/>. <br/> Remarks: " & txtRejectionRemarks.Text

                ElseIf GetAuthLevel() = "PPC" Then
				    baseurl = baseurl + "ops/Quotation_Dispatch_Sch.aspx?quot=" + lblQuotationNo.Text
                   ' body = "Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a> has been rejected by PPC Dept (" + Session("EmpName").ToString + "). You may make changes in it as per the suggestions. " & _
				    body = "Quotation # <a href = '" + baseurl + "'>" & lblQuotationNo.Text & "</a> has been rejected by PPC Dept (" + Session("EmpName").ToString + "). You may make changes in it as per the suggestions. " & _
                   "<br/>. <br/> Remarks: " & txtRejectionRemarks.Text

                End If

                Dim subject As String = "Rejection of Quotation No. " + lblQuotationNo.Text

                'sm.SendMail("rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)

                sqlstr = "jct_ops_get_quot_mail_recipients"
                cmd = New SqlCommand(sqlstr, con.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
                cmd.Parameters("Action").Value = "PPCRej"
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim recipients, m_sender As String
                recipients = ""
                m_sender = ""

                If dr.HasRows Then
                    While dr.Read
                        If dr(0).ToString = "To" Then
                            recipients += dr("e_mailid").ToString + ";"
                        ElseIf dr(0).ToString = "From" Then
                            m_sender = dr("e_mailid").ToString
                        End If
                    End While
                End If

                dr.Close()

                Dim bcc As String = "rbaksshi@jctltd.com; ashish@jctltd.com;manishk@jctltd.com; harendra@jctltd.com"
                sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body)

            Catch ex As Exception
                sm.SendMail("ashish@jctltd.com;manishk@jctltd.com", "noreply@jctltd.com", "Error Occurred while sending email ", "Error Occurred while sending email <br/>" & ex.Message)

            End Try

        Catch ex As Exception
            'lblMessage.Text = ex.Message
            sm.SendMail("ashish@jctltd.com;manishk@jctltd.com", "noreply@jctltd.com", "Error Occurred ", "Error Occurred <br/>" & ex.Message)

        End Try

    End Sub

    Protected Sub ResetGrids()

        grdUnauthorisedQuotes.DataBind()
        grdUnauthorisedQuotes.SelectedIndex = -1

        grdDispatchDetail.DataSource = Nothing
        grdDispatchDetail.DataBind()

        dlsRefDocs.DataSource = Nothing
        dlsRefDocs.DataBind()

    End Sub

    Protected Sub grdUnauthorisedQuotes_DataBound(sender As Object, e As System.EventArgs) Handles grdUnauthorisedQuotes.DataBound
        If CType(sender, GridView).Rows.Count = 0 Then
            cmdAdvise.Visible = False
            cmdApprove.Visible = False
            cmdDevApprove.Visible = False
            cmdReject.Visible = False

        End If

    End Sub

    Protected Sub cmdDevApprove_Click(sender As Object, e As System.EventArgs) Handles cmdDevApprove.Click
        'jct_ops_approve_dev_quote
        Dim sqlstr As String = "jct_ops_approve_dev_quote"

        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)

        'cmd.Parameters.Add("Auth_Type", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("Remarks", SqlDbType.VarChar, 2000)

        cmd.Parameters("Quotation_no").Value = lblQuotationNo.Text
        cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
        'cmd.Parameters("Auth_Type").Value = "PPC"
        cmd.Parameters("Remarks").Value = txtRejectionRemarks.Text

        Dim sm As New SendMail

        Try
			  Dim baseurl As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()
            grdUnauthorisedQuotes.DataBind()

            'grdAuthorisedQuotes.DataBind()

            Try
                   baseurl = baseurl + "ops/Quotation_Dispatch_Sch.aspx?quot=" + lblQuotationNo.Text
                Dim subject As String = "Approval of Quotation No. " + lblQuotationNo.Text
                'Dim body As String = "Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a> has been approved by Development Dept. (" + Session("EmpName").ToString + ")." & _
				 Dim body As String = "Quotation # <a href = '" + baseurl + "'>" & lblQuotationNo.Text & "</a> has been approved by Development Dept. (" + Session("EmpName").ToString + ")." & _
                    "<br/>. <br/> Remarks: " & txtRejectionRemarks.Text

                'sm.SendMail("rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)

                sqlstr = "jct_ops_get_quot_mail_recipients"
                cmd = New SqlCommand(sqlstr, con.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim recipients, m_sender As String
                recipients = ""
                m_sender = ""

                If dr.HasRows Then
                    While dr.Read
                        If dr(0).ToString = "To" Then
                            recipients += dr("e_mailid").ToString + ";"
                        ElseIf dr(0).ToString = "From" Then
                            m_sender = dr("e_mailid").ToString
                        End If
                    End While
                End If

                dr.Close()

                Dim bcc As String = "rbaksshi@jctltd.com; ashish@jctltd.com;manishk@jctltd.com; harendra@jctltd.com"
                sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body)

            Catch ex As Exception
                sm.SendMail("ashish@jctltd.com;manishk@jctltd.com", "noreply@jctltd.com", "Error Occurred while sending email ", "Error Occurred while sending email <br/>" & ex.Message)

            End Try

        Catch ex As Exception
            'lblMessage.Text = ex.Message
            sm.SendMail("ashish@jctltd.com", "noreply@jctltd.com", "Error Occurred ", "Error Occurred <br/>" & ex.Message)

        End Try

    End Sub

    Protected Function GetAuthLevel() As String

        Dim auth_level As String
        auth_level = ""
        Dim sqlstr As String = "select Auth_Level from jct_ops_sales_team_hierarchy where sale_person_code = '" + Replace(Session("EmpCode").ToString, "-", "") + "' and status = 'A'"
        Dim cn As New Connection
        Dim dr As SqlDataReader

        Try

            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            dr.Read()
            auth_level = dr("Auth_Level").ToString

        Catch ex As Exception

            lblMessage.Text = ex.Message
            auth_level = ""

        End Try

        Return auth_level

    End Function


    Protected Function CheckQutation(Quotation As String) As Boolean
        Dim Auth_status As String
        Auth_status = ""
        Dim sqlstr As String = "Select Auth_status from jct_ops_check_Qutaion_planningstatus  where quotation_no = '" + Quotation + "' and Auth_status = 'A' and [Type]='Greige'"
        Dim cn As New Connection
        Dim dr As SqlDataReader

        Try

            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            dr.Read()
            Auth_status = dr("Auth_status").ToString
            If Auth_status = "A" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

            lblMessage.Text = ex.Message
            Auth_status = ""
            Return False
        End Try
    End Function
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        bindgridAuth()
    End Sub

    Private Sub bindgridAuth()
        Try
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            Dim cn As New Connection
            Dim sql As String = "jct_ops_Get_planning_internal_process_action"
            Dim cmd As New SqlCommand(sql, cn.Connection)
            cmd.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    'If ds.Tables(0).Rows.Count <> 0 Then
                    GridView1.DataSource = ds
                    GridView1.DataBind()

                End If

            Else


                GridView1.DataSource = Nothing
                GridView1.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
