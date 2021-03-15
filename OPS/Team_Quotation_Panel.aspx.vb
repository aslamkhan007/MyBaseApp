Imports System.Data
Imports System.Data.SqlClient
Imports System.Net

Partial Class OPS_Quotation_Panel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'grdOpenQuotes.DataBind()
        'grdUnauthorisedQuotes.DataBind()
        'grdAuthorisedQuotes.DataBind()

    End Sub

    Protected Sub grdOpenQuotes_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdOpenQuotes.RowDataBound

        'Dim imgValidity As Image = CType(e.Row.FindControl("imgValidity"), Image)
        'Dim imgPL As Image = CType(e.Row.FindControl("imgPL"), Image)
        'imgValidity.ImageUrl = ""
        'imgPL.ImageUrl = ""

    End Sub

    Protected Sub grdUnauthorisedQuotes_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdUnauthorisedQuotes.RowCommand

        Dim sqlstr As String = ""
        Dim quot_no = e.CommandArgument.ToString
        Dim ofn As New Functions
        Dim sm As New SendMail
        Dim str, body_to, subject, cc As String
        Dim action As String = ""
        Dim action1 As String = ""
        str = ""
        body_to = ""
        subject = ""
        cc = ""

        If e.CommandName = "Authorise" Then
            sqlstr = "jct_ops_authorise_quote"
            action = "authorised"
            action1 = "Authorisation"
        ElseIf e.CommandName = "Reject" Then
            sqlstr = "jct_ops_reject_quote"
            action = "rejected"
            action1 = "Rejection"
        End If

        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)

        cmd.Parameters("@Quotation_no").Value = quot_no
        cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
        cmd.Parameters("@User_Type").Value = ""

        'Try
        '    cn.ConOpen()
        '    cmd.ExecuteNonQuery()
        '    cn.ConClose()
        '    grdUnauthorisedQuotes.DataBind()
        '    grdAuthorisedQuotes.DataBind()

        'Catch ex As Exception
        '    lblMessage.Text = ex.Message

        'End Try

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()
            lblMessage.Text = "Quotation # " + quot_no + " has been " + action + " by " + Session("EmpName").ToString + " : " + Session("EmpCode").ToString
            grdUnauthorisedQuotes.DataBind()
            grdAuthorisedQuotes.DataBind()

            Try
                Dim baseurl As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
                Dim baseurl1 As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
                Dim bcc As String = "rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com;manishk@jctltd.com"
                subject = action1 + " of Quotation No. " & quot_no & " has been done by " + Session("EmpName").ToString '+ " : " + Session("EmpCode").ToString
                baseurl = baseurl + "ops/Quotation_Main.aspx?quot=" + quot_no
                ' body_to = "Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Main.aspx?quot=" & quot_no & "'> " & quot_no & "</a> has been " + action + " successfully by " + Session("EmpName").ToString + "<br/> Click on Quotation Number to view details."
                body_to = "Quotation # <a href = '" + baseurl + "'> " & quot_no & "</a> has been " + action + " successfully by " + Session("EmpName").ToString + "<br/> Click on Quotation Number to view details."

                baseurl1 = baseurl1 + "OPS/Quotation_Detail_Preview.aspx?quot=" + quot_no
                'body_to += GetPage("http://misdev/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=" & quot_no)
                body_to += GetPage(baseurl1)

                sqlstr = "jct_ops_get_quot_mail_recipients"

                cmd = New SqlCommand(sqlstr, cn.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("Quotation_No").Value = quot_no
                cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
                cmd.Parameters("Action").Value = "QuotAuthLM"
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                Dim recipients, m_sender, sender_name, recipient_name As String
                recipients = ""
                m_sender = ""
                sender_name = ""
                recipient_name = ""

                If dr.HasRows Then
                    While dr.Read
                        If dr(0).ToString = "To" Then
                            recipients += dr("e_mailid").ToString + ";"
                            recipient_name += dr("empname").ToString + ","
                        ElseIf dr(0).ToString = "From" Then
                            m_sender = dr("e_mailid").ToString
                            sender_name = dr("empname").ToString
                        ElseIf dr(0).ToString = "CC" Then
                            cc = dr("e_mailid").ToString + ";"
                        End If
                    End While
                End If

                dr.Close()
                cc = cc & ";rbaksshi@jctltd.com; ashish@jctltd.com;manishk@jctltd.com;"
                sm.SendMail2(recipients, cc, "", "approvals@jctltd.com", subject, body_to)

                'Dim cc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com;" + m_sender
                'sm.SendMail2(recipients, cc, "", "approvals@jctltd.com", subject, body_to)

            Catch ex As Exception
                lblMessage.Text = "Error sending email to concerned person(s)."
            End Try

        Catch ex As Exception
            ofn.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub ibtAuthorise_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs)

        'Dim sqlstr As String = "jct_ops_authorise_quote"
        'Dim cn As New Connection
        'Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        'cmd.CommandType = CommandType.StoredProcedure

        'cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        'cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        'cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)

        'cmd.Parameters("@Quotation_no").Value = e.CommandArgument.ToString
        'cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
        'cmd.Parameters("@User_Type").Value = "SP"

        'Try
        '    cn.ConOpen()
        '    cmd.ExecuteNonQuery()
        '    cn.ConClose()

        'Catch ex As Exception
        '    lblMessage.Text = ex.Message

        'End Try

    End Sub

    Protected Sub ibtReject_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub grdAuthorisedQuotes_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAuthorisedQuotes.RowCommand

        Dim sqlstr As String = "jct_ops_request_sale_order"

        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        'cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)

        cmd.Parameters("@Quotation_no").Value = e.CommandArgument.ToString
        cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
        'cmd.Parameters("@User_Type").Value = ""

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()
            Req_SO_Mail(e.CommandArgument.ToString)
            grdAuthorisedQuotes.DataBind()

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub

    'Protected Sub Req_PO_Mail(quot_no As String)

    '    Dim sm As New SendMail

    '    Try

    '        Dim subject As String = "Sale Order Request for Quotation No. " + quot_no + " authorised by " + Session("EmpName").ToString

    '        Dim body As String = "You have got Sale Order Request for Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & quot_no & "'>" & quot_no & "</a>.<br/> Click on Quotation Number to view details."

    '        Dim recipients, m_sender As String
    '        'recipients = "backofficesales@jctltd.com"
    '        recipients = "william@jctltd.com"
    '        m_sender = ""

    '        Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
    '        sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body)
    '        'Dim cc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com;" + m_sender
    '        'sm.SendMail2(recipients, cc, "", "noreply@jctltd.com", subject, body_to)


    '    Catch ex As Exception
    '        sm.SendMail2("jagdeep@jctltd.com", "", "", "noreply@jctltd.com", "Error Occurred while sending mail for Sale Order Request for Quotation # " + quot_no, ex.Message)

    '    End Try

    'End Sub

    Protected Sub Req_SO_Mail(quot_no As String)

        Dim sm As New SendMail

        Try
            Dim baseurl As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
            baseurl = baseurl + "OPS/Quotation_Detail_Preview.aspx?quot=" + quot_no

            Dim subject As String = "Sale Order Request for Quotation No. " + quot_no + " authorised by " + Session("EmpName").ToString

            'Dim body As String = "You have got Sale Order Request for Quotation # <a href = 'http://misdev/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=" & quot_no & "'>" & quot_no & "</a>.<br/> Click on Quotation Number to view details."
            Dim body As String = "You have got Sale Order Request for Quotation # <a href = '" + baseurl + "'>" & quot_no & "</a>.<br/> Click on Quotation Number to view details."

            Dim recipients, m_sender, cc As String

            Dim sql As String
            Dim con As New Connection

            sql = "jct_ops_get_quot_mail_recipients"
            Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
            cmd.Parameters("Quotation_No").Value = quot_no
            cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
            cmd.Parameters("Action").Value = "QuotAuth"
            cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
            cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            recipients = "william@jctltd.com"
            m_sender = ""
            cc = ""

            If dr.HasRows Then
                While dr.Read
                    If dr(0).ToString = "To" Then
                        recipients += dr("e_mailid").ToString + ";"
                        'recipient_name += dr("empname").ToString + ","
                    ElseIf dr(0).ToString = "From" Then
                        m_sender += dr("e_mailid").ToString
                        'sender_name = dr("empname").ToString
                    ElseIf dr(0).ToString = "CC" Then
                        cc += dr("e_mailid").ToString

                    End If
                End While
            End If

            dr.Close()

            Dim bcc As String = "rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com;manishk@jctltd.com"
            sm.SendMail2(recipients, cc, bcc, "noreply@jctltd.com", subject, body)

        Catch ex As Exception
            sm.SendMail2("manishk@jctltd.com", "", "", "noreply@jctltd.com", "Error Occurred while sending mail for Sale Order Request for Quotation # " + quot_no, ex.Message)

        End Try

    End Sub


    Protected Function GetPage(page_path As String) As String

        Dim myclient As WebClient = New WebClient()
        Dim myPageHTML As String
        Dim requestHTML As Byte()
        Dim currentPageUrl As String

        'byte[] requestHTML;
        'string currentPageUrl = "http://www.yahoo.com"; //Request.Url.ToString();
        'currentPageUrl = "http://localhost:52841/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=QT/004014/2014";

        'currentPageUrl = "http://misdev/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=" & lblQuotationNo.Text

        currentPageUrl = page_path

        Dim utf8 As UTF8Encoding = New UTF8Encoding()

        'UTF8Encoding utf8 = new UTF8Encoding();

        requestHTML = myclient.DownloadData(currentPageUrl)
        myPageHTML = utf8.GetString(requestHTML)

        'Response.Write(myPageHTML)

        Return myPageHTML

    End Function

End Class
