Imports System.Data.SqlClient
Imports System.Data
Imports System.Net

Partial Class OPS_QuotationProd_Details
    Inherits System.Web.UI.Page
    Dim ofn As New Functions

    Protected Sub grdUnauthorisedQuotes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdUnauthorisedQuotes.SelectedIndexChanged

        lblQuotationNo.Text = grdUnauthorisedQuotes.SelectedDataKey.Value.ToString
    End Sub

    Protected Function GetAuthLevel() As String
        Dim auth_level As String
        auth_level = ""
        Dim sqlstr As String = "Select [level] from Jct_ops_planning_internal_hierarchy where Empcode = '" + Session("EmpCode").ToString + "'"
        Dim cn As New Connection
        Dim dr As SqlDataReader
        Try
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            dr.Read()
            auth_level = dr("level").ToString

        Catch ex As Exception

            auth_level = ""

        End Try

        Return auth_level

    End Function

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Session("Empcode") Is Nothing Then
            Response.Redirect("Login.aspx")
            ' Do whatever you were going to do.
        Else
            If GetAuthLevel() = "3" Then
                pnlDetail.Visible = True
                pnlForm.Visible = False
                main.Visible = True
                pnlAuth.Visible = True
                cmdCancel.Visible = False
            ElseIf GetAuthLevel() = "1" Then
                main.Visible = True
                pnlForm.Visible = True
                pnlDetail.Visible = False
                pnlAuth.Visible = False
                cmdCancel.Visible = False
            ElseIf GetAuthLevel() = "2" Then
                Panellevel2.Visible = True
                pnlDetail.Visible = False
                pnlForm.Visible = True
                pnlAuth.Visible = False
                cmdCancel.Visible = True

            Else
                pnlDetail.Visible = False
            End If

        End If
       

    End Sub
    Protected Sub cmdAuthorise_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub
    Protected Sub cmdsubmit_Click(sender As Object, e As System.EventArgs) Handles cmdsubmit.Click
        '-------Used For Grieg and Finish Date --------------
        Dim strVal As String = lblQuotationNo.Text
        Dim Action As String = ""
        If String.IsNullOrEmpty(strVal) Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Select Quotation Number');", True)
        Else
            Try
                Dim cn As New Connection
                Dim Ip As String = Request.ServerVariables("REMOTE_ADDR").ToString
                Dim sqlstr As String = "jct_ops_get_team_quotations_for_internal_planning_auth"
                Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("@Quotation_No").Value = Trim(lblQuotationNo.Text)
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10)
                cmd.Parameters("@UserCode").Value = Session("Empcode").ToString
                cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 15)
                cmd.Parameters("@Ip").Value = Ip
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20)
                cmd.Parameters("@Type").Value = ddlType.SelectedItem.Value
                cmd.Parameters.Add("@Target_Date", SqlDbType.DateTime)
                cmd.Parameters("@Target_Date").Value = txtdate.Text
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000)
                cmd.Parameters("@Remarks").Value = txtRemarks.Text
                cmd.Parameters.Add("@Action_Type", SqlDbType.VarChar, 2000)
                cmd.Parameters("@Action_Type").Value = "A"
                cmd.ExecuteNonQuery()
                ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Recored Save');", True)
                txtdate.Text = ""
                txtRemarks.Text = ""
                If GetAuthLevel() = "3" Then
                    pnlDetail.Visible = True
                    cmdCancel.Visible = False
                ElseIf GetAuthLevel() = "1" Then
                    main.Visible = True
                    pnlDetail.Visible = False
                    pnlForm.Visible = True
                    cmdCancel.Visible = False
                    grdUnauthorisedQuotes.DataSource = Nothing
                    grdUnauthorisedQuotes.DataBind()
                    Action = "Greige completion date of Quotation No. " & lblQuotationNo.Text & " has been finalize by  " + Session("EmpName").ToString
                    EmailCreate(strVal, Action)
                ElseIf GetAuthLevel() = "2" Then
                    Panellevel2.Visible = True
                    pnlDetail.Visible = False
                    pnlForm.Visible = True
                    cmdCancel.Visible = True
                    GridViewLevel2.DataSource = Nothing
                    GridViewLevel2.DataBind()
                    Action = "Finish completion date of Quotation No. " & lblQuotationNo.Text & " has been finalize by  " + Session("EmpName").ToString
                    EmailCreate(strVal, Action)

                Else
                    pnlDetail.Visible = False
                End If
            Catch ex As Exception
                ofn.Alert(ex.Message)
            End Try
        End If


    End Sub


    Protected Sub GridViewLevel2_SelectedIndexChanged1(sender As Object, e As System.EventArgs) Handles GridViewLevel2.SelectedIndexChanged

        lblQuotationNo.Text = GridViewLevel2.SelectedDataKey.Value.ToString
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        '-------Used For Authorization --------------
        Dim strVal As String = ddlLevel.SelectedValue

        Dim Action As String = ""
        If strVal = "Accept" Then

            strVal = "A"
        Else
            strVal = "C"


        End If
        Dim Remarks As String = txtRemark.Text
        Dim quotation As String = Trim(lblQut.Text)
        If String.IsNullOrEmpty(lblQut.Text) Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Select Quotation Number');", True)
        Else
            Try

                Dim cn As New Connection
                Dim Ip As String = Request.ServerVariables("REMOTE_ADDR").ToString
                Dim sqlstr As String = "jct_ops_get_team_quotations_for_internal_planning_auth"
                Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("@Quotation_No").Value = Trim(lblQut.Text)
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10)
                cmd.Parameters("@UserCode").Value = Session("Empcode").ToString
                cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 15)
                cmd.Parameters("@Ip").Value = Ip
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20)
                cmd.Parameters("@Type").Value = strVal
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000)
                cmd.Parameters("@Remarks").Value = txtRemark.Text
                cmd.Parameters.Add("@Action_Type", SqlDbType.VarChar, 2000)
                cmd.Parameters("@Action_Type").Value = strVal

                cmd.ExecuteNonQuery()
                ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Recored Save');", True)
                txtdate.Text = ""
                txtRemark.Text = ""
                lblQut.Text = ""
                If GetAuthLevel() = "3" Then
                    pnlDetail.Visible = True
                    pnlForm.Visible = False
                    main.Visible = True
                    grdPendingQuotes.DataSource = Nothing
                    grdPendingQuotes.DataBind()
                    If strVal = "A" Then
                        Action = "Final completion date of Quotation No. " & lblQuotationNo.Text & " has been authorized  by  " + Session("EmpName").ToString
                        EmailCreate(quotation, Action)
                    Else

                        Action = "Final completion date of Quotation No. " & lblQuotationNo.Text & " has been canceled  by  " + Session("EmpName").ToString
                        EmailToCancel(quotation, Action, strVal, Remarks)


                    End If

                ElseIf GetAuthLevel() = "1" Then
                    main.Visible = True
                    pnlDetail.Visible = False
                    pnlForm.Visible = True
                    cmdCancel.Visible = False
                    grdUnauthorisedQuotes.DataSource = Nothing
                    grdUnauthorisedQuotes.DataBind()


                ElseIf GetAuthLevel() = "2" Then
                    Panellevel2.Visible = True
                    pnlDetail.Visible = False
                    pnlForm.Visible = True
                    cmdCancel.Visible = True
                    GridViewLevel2.DataSource = Nothing
                    GridViewLevel2.DataBind()


                Else
                    pnlDetail.Visible = False

                End If
            Catch ex As Exception
                ofn.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub grdPendingQuotes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdPendingQuotes.SelectedIndexChanged
        lblQut.Text = grdPendingQuotes.SelectedDataKey.Value.ToString
    End Sub


    Protected Function GetPage(page_name As String) As String

        Dim myclient As WebClient = New WebClient()
        Dim myPageHTML As String
        Dim requestHTML As Byte()
        Dim currentPageUrl As String

        'string currentPageUrl = "http://www.yahoo.com"; //Request.Url.ToString();
        'currentPageUrl = "http://localhost:52841/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=QT/004014/2014";

        'currentPageUrl = "http://misdev/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=" & lblQuotationNo.Text

        ''''''''''''''''''''''''''''''
        'currentPageUrl = Request.Url.AbsoluteUri

        'currentPageUrl = currentPageUrl.Replace("Quotation_Main.aspx", page_name)

        ''''''''''''''''''''''''''''''

        '-------- currentPageUrl = "http://misdev/FusionApps/OPS/
        ''-- currentPageUrl = "http://localhost:1730/FusionApps-old-18%20dec/OPS/Quotation_Detail_Preview.aspx?quot=" & lblQuotationNo.Text

        ''--   currentPageUrl = "http://localhost:1730/FusionApps-old-18%20dec/OPS/" & page_name

        currentPageUrl = "http://misdev/FusionApps/OPS/" & page_name

        Dim utf8 As UTF8Encoding = New UTF8Encoding()

        'UTF8Encoding utf8 = new UTF8Encoding();

        requestHTML = myclient.DownloadData(currentPageUrl)
        myPageHTML = utf8.GetString(requestHTML)
        'Response.Write(myPageHTML)
        Return myPageHTML

    End Function
    '-----------Email Create and Approve-------------------
    Private Sub EmailCreate(Quotation As String, Subj As String)

        Dim sm As New SendMail
        Dim str, body_to, subject As String

        str = ""
        body_to = ""
        subject = Subj

        Dim cn As New Connection
        Dim sqlstr As String
        Try

            'Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
            ' subject = "Authorisation of Quotation No. " & lblQuotationNo.Text & " has been done by " + Session("EmpName").ToString '+ " : " + Session("EmpCode").ToString
           
            body_to = GetPage("Quotation_Detail_Email.aspx?quot=" & Quotation)
            sqlstr = "jct_ops_Quotation_planning_email"
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
            cmd.Parameters("Quotation_No").Value = Quotation
            cmd.Parameters.Add("Usercode", SqlDbType.VarChar, 10)
            cmd.Parameters("Usercode").Value = Session("EmpCode").ToString

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Dim recipients, m_sender, sender_name, recipient_name, bcc, cc As String
            recipients = ""
            m_sender = ""
            sender_name = ""
            recipient_name = ""
            cc = ""

            If dr.HasRows Then
                While dr.Read
                    If dr(2).ToString = "To" Then
                        recipients += dr("E_Mailid").ToString + ";"
                        recipient_name += dr("empname").ToString + ","
                    ElseIf dr(2).ToString = "From" Then
                        m_sender = dr("E_Mailid").ToString
                        sender_name = dr("empname").ToString
                    ElseIf dr(2).ToString = "CC" Then
                        cc += dr("e_mailid").ToString + ";"
                    End If
                End While
            End If
            dr.Close()

            cc = cc & "; ashish@jctltd.com;"
            bcc = "manishk@jctltd.com, Ashish@jctltd.com"
            sm.SendMail2(recipients, cc, bcc, "noreply@jctltd.com", subject, body_to)
        Catch ex As Exception
            Throw New Exception("Error in sendding email")
        End Try
    End Sub
    '-----------Email Cancel -----------------------------------
    Private Sub EmailToCancel(quotation As String, Subj As String, status As String, Remark As String)

        Dim sm As New SendMail
        Dim str, body_to, subject As String
        Dim Qtname As String
        If GetAuthLevel() = "2" Then
            Qtname = "Grieg Date"
        Else
            Qtname = "Finish Date"
        End If

        str = ""
        body_to = ""
        subject = Subj
        Dim cn As New Connection
        Dim sqlstr As String
        Try

            'Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
            ' subject = "Authorisation of Quotation No. " & lblQuotationNo.Text & " has been done by " + Session("EmpName").ToString '+ " : " + Session("EmpCode").ToString

            body_to = Qtname & " of Quotation No." & quotation & " has been Canceled  by" & Session("EmpName").ToString
            body_to += "<br/>"
            body_to += "Remarks :- " & Remark
            body_to += GetPage("Quotation_Detail_Email.aspx?quot=" & quotation)
            sqlstr = "jct_ops_Quotation_planning_email"
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
            cmd.Parameters("Quotation_No").Value = quotation
            cmd.Parameters.Add("Usercode", SqlDbType.VarChar, 10)
            cmd.Parameters("Usercode").Value = Session("EmpCode").ToString

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Dim recipients, m_sender, sender_name, recipient_name, bcc, cc As String
            recipients = ""
            m_sender = ""
            sender_name = ""
            recipient_name = ""
            cc = ""

            If dr.HasRows Then
                While dr.Read
                    If dr(2).ToString = "To" Then
                        recipients += dr("E_Mailid").ToString + ";"
                        recipient_name += dr("empname").ToString + ","
                    ElseIf dr(2).ToString = "From" Then
                        m_sender = dr("E_Mailid").ToString
                        sender_name = dr("empname").ToString
                    ElseIf dr(2).ToString = "CC" Then
                        cc += dr("e_mailid").ToString + ";"
                    End If
                End While
            End If
            dr.Close()

            cc = cc & "; ashish@jctltd.com;"
            bcc = "manishk@jctltd.com, Ashish@jctltd.com"
            sm.SendMail2(recipients, cc, bcc, "noreply@jctltd.com", subject, body_to)
        Catch ex As Exception
            Throw New Exception("Error in sendding email")
        End Try
    End Sub

    Protected Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        '--------------Level 2 Cancel ----------Event -------
        Dim strVal As String = lblQuotationNo.Text
        Dim Subject As String = ""
        Dim Action As String = "C"
        Dim Remark As String = txtRemarks.Text
        If String.IsNullOrEmpty(strVal) Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Select Quotation Number');", True)
        Else
            Try
                Dim cn As New Connection
                Dim Ip As String = Request.ServerVariables("REMOTE_ADDR").ToString
                Dim sqlstr As String = "jct_ops_get_team_quotations_for_internal_planning_auth"
                Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("@Quotation_No").Value = Trim(lblQuotationNo.Text)
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10)
                cmd.Parameters("@UserCode").Value = Session("Empcode").ToString
                cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 15)
                cmd.Parameters("@Ip").Value = Ip
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20)
                cmd.Parameters("@Type").Value = ddlType.SelectedItem.Value
                cmd.Parameters.Add("@Target_Date", SqlDbType.DateTime)
                cmd.Parameters("@Target_Date").Value = txtdate.Text
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000)
                cmd.Parameters("@Remarks").Value = txtRemarks.Text
                cmd.Parameters.Add("@Action_Type", SqlDbType.VarChar, 1)
                cmd.Parameters("@Action_Type").Value = "C"
                cmd.ExecuteNonQuery()
                ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Recored Save');", True)
                txtdate.Text = ""
                txtRemarks.Text = ""
                If GetAuthLevel() = "2" Then
                    Panellevel2.Visible = True
                    pnlDetail.Visible = False
                    pnlForm.Visible = True
                    cmdCancel.Visible = True
                    GridViewLevel2.DataSource = Nothing
                    GridViewLevel2.DataBind()
                    Subject = "Greig completion date of Quotation No. " & lblQuotationNo.Text & " has been canceled by  " + Session("EmpName").ToString
                    EmailToCancel(strVal, Subject, Action, Remark)

                Else
                    pnlDetail.Visible = False
                End If
            Catch ex As Exception
                ofn.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
