Imports System.Data.SqlClient
Imports System.Data
Imports System.Net
Partial Class OPS_QuotationProd_Details_new
    Inherits System.Web.UI.Page
    Dim ofn As New Functions

    Dim QTno As String
    'Protected Sub grdUnauthorisedQuotes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdUnauthorisedQuotes.SelectedIndexChanged

    '    lblQuotationNo.Text = grdUnauthorisedQuotes.SelectedDataKey.Value.ToString
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Empcode") Is Nothing Then

            Response.Redirect("Login.aspx")
            ' Do whatever you were going to do.

        End If
        bindgrid()
        'bindgridAuth()

    End Sub
    Protected Sub cmdAuthorise_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub
    Protected Sub cmdsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdsubmit.Click
        '-------Used For Grieg and Finish Date --------------
        Dim strVal As String = lblQuotationNo.Text
        Dim Action As String = ""
        If String.IsNullOrEmpty(strVal) Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Select Quotation Number');", True)
        Else
            Try


                Dim cn As New Connection
                Dim Ip As String = Request.ServerVariables("REMOTE_ADDR").ToString
                Dim sqlstr As String = "jct_ops_get_team_quotations_for_internal_planning_auth_new"
                Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("@Quotation_No").Value = Trim(lblQuotationNo.Text)
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10)
                cmd.Parameters("@UserCode").Value = Session("Empcode").ToString
                cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 15)
                cmd.Parameters("@Ip").Value = Ip
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20)
                'cmd.Parameters("@Type").Value = ddlType.SelectedItem.Value

                cmd.Parameters.Add("@Target_Date", SqlDbType.DateTime)
                'cmd.Parameters("@Target_Date").Value = txtdate.Text

                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000)
                'cmd.Parameters("@Remarks").Value = txtRemarks.Text

                cmd.Parameters.Add("@Action_Type", SqlDbType.VarChar, 2000)
                cmd.Parameters("@Action_Type").Value = "A"

                cmd.Parameters.Add("@GreighQty", SqlDbType.Int, 200)
                'cmd.Parameters("@GreighQty").Value = txtGreighQty.Text

                cmd.ExecuteNonQuery()
                ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Recored Save');", True)
                'txtdate.Text = ""
                'txtRemarks.Text = ""
                'txtGreighQty.Text = ""
                'ddlType.SelectedIndex = -1
                'Action = "completion date of Quotation No. " & lblQuotationNo.Text & " has been finalize by  " + Session("EmpName").ToString

                'EmailCreate(strVal, Action)
                bindgrid()
                bindgridAuth()
                GreighDateBind(lblQuotationNo.Text)
                lblQuotationNo.Text = ""
            Catch ex As Exception
                ofn.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub GridViewLevel2_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewLevel2.SelectedIndexChanged

        QTno = GridViewLevel2.SelectedDataKey.Value.ToString
        lblQuotationNo.Text = GridViewLevel2.SelectedDataKey.Value.ToString
        'lblQuotationNo1.Text = GridViewLevel2.SelectedDataKey.Value.ToString
        bindDispatch(lblQuotationNo.Text)

        GreighDateBind(lblQuotationNo.Text)

    End Sub

    Protected Function GetPage(ByVal page_name As String) As String

        Dim myclient As WebClient = New WebClient()
        Dim myPageHTML As String
        Dim requestHTML As Byte()
        Dim currentPageUrl As String
        Dim baseurl As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"

        currentPageUrl = baseurl + "ops/" + page_name

        Dim utf8 As UTF8Encoding = New UTF8Encoding()

        requestHTML = myclient.DownloadData(currentPageUrl)
        myPageHTML = utf8.GetString(requestHTML)
        'Response.Write(myPageHTML)
        Return myPageHTML

    End Function
    '-----------Email Create and Approve-------------------
    Private Sub EmailCreate(ByVal Quotation As String, ByVal Subj As String)

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
            sqlstr = "jct_ops_Quotation_planning_email_new"
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
                        cc = dr("e_mailid").ToString + ","
                    End If
                End While
            End If
            dr.Close()

            cc = cc & "hitesh@jctltd.com,rbaksshi@jctltd.com,hiren@jctltd.com,sandeepr@jctltd.com"
            bcc = "hitesh@jctltd.com; hiren@jctltd.com; sandeepr@jctltd.com"
            sm.SendMail2(recipients, cc, bcc, "noreply@jctltd.com", subject, body_to)
        Catch ex As Exception
            Throw New Exception("Error in sendding email")
        End Try
    End Sub
    '-----------Email Cancel -----------------------------------
    Private Sub EmailToCancel(ByVal quotation As String, ByVal Subj As String, ByVal status As String, ByVal Remark As String)

        Dim sm As New SendMail
        Dim str, body_to, subject As String
        Dim Qtname As String

        Qtname = "Grieg Date"

        str = ""
        body_to = ""
        subject = Subj
        Dim cn As New Connection
        Dim sqlstr As String
        Try

            body_to = Qtname & " of Quotation No." & quotation & " has been Canceled  by" & Session("EmpName").ToString
            body_to += "<br/>"
            body_to += "Remarks :- " & Remark
            body_to += GetPage("Quotation_Detail_Email.aspx?quot=" & quotation)
            sqlstr = "jct_ops_Quotation_planning_email_new"
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
                        cc = dr("e_mailid").ToString + ";"
                    End If
                End While
            End If
            dr.Close()

            cc = cc & "; hitesh@jctltd.com;"
            bcc = "hiren@jctltd.com, sandeepr@jctltd.com"
            sm.SendMail2(recipients, cc, bcc, "noreply@jctltd.com", subject, body_to)
        Catch ex As Exception
            Throw New Exception("Error in sendding email")
        End Try
    End Sub

    'Protected Sub ddlType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlType.SelectedIndexChanged
    '    If ddlType.SelectedValue = "-- Select --" Then
    '        lblstatus.Text = ""
    '    Else
    '        lblstatus.Text = "For " & ddlType.SelectedValue
    '    End If

    '    bindgrid()
    'End Sub
    Private Sub bindDispatch(ByVal Quotation As String)
        grdDispatchDetail.DataSource = Nothing
        grdDispatchDetail.DataBind()

        Dim cn As New Connection
        Dim sql As String = "jct_ops_get_quote_dispatch_sch_2"
        Dim cmd As New SqlCommand(sql, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16).Value = Quotation
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                'If ds.Tables(0).Rows.Count <> 0 Then
                grdDispatchDetail.DataSource = ds
                grdDispatchDetail.DataBind()
            End If

        Else

            grdDispatchDetail.DataSource = Nothing
            grdDispatchDetail.DataBind()

        End If

    End Sub
    Private Sub GreighDateBind(ByVal Quotation As String)
        GridVewGreigh.DataSource = Nothing
        GridVewGreigh.DataBind()

        Dim cn As New Connection
        Dim sql As String = "JCT_OPS_GET_QUOTATION_GREIGH_DATE"
        Dim cmd As New SqlCommand(sql, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16).Value = Quotation
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                GridVewGreigh.DataSource = ds
                GridVewGreigh.DataBind()

            End If

        Else
            GridVewGreigh.DataSource = Nothing
            GridVewGreigh.DataBind()
        End If

    End Sub
    Private Sub bindgrid()
        GridViewLevel2.DataSource = Nothing
        GridViewLevel2.DataBind()
        Dim UserCode As String = Session("Empcode").Replace("-", "")
        Dim cn As New Connection
        Dim sql As String = "sp_jct_ops_Get_prod_Detailby_planning_level_new"
        Dim cmd As New SqlCommand(sql, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("Type", SqlDbType.VarChar, 510).Value = "Greige"
        cmd.Parameters.Add("UserCode", SqlDbType.VarChar, 16).Value = UserCode
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                'If ds.Tables(0).Rows.Count <> 0 Then
                GridViewLevel2.DataSource = ds
                GridViewLevel2.DataBind()

            End If

        Else
            GridViewLevel2.DataSource = String.Empty
            GridViewLevel2.DataBind()
        End If
    End Sub
    Private Sub bindgridAuth()
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        Dim cn As New Connection
        Dim sql As String = "jct_ops_Get_planning_internal_process"
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
    End Sub

    Protected Sub GridViewLevel2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridViewLevel2.PageIndexChanging
        GridViewLevel2.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        bindgridAuth()
    End Sub



    Protected Sub lnkSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSubmit.Click
        Dim strVal As String = lblQuotationNo.Text
        Dim Action As String = ""

        Dim tr As SqlTransaction
        Dim cn As New Connection

        If String.IsNullOrEmpty(strVal) Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Select Quotation Number');", True)
        Else

            Try

                tr = cn.Connection.BeginTransaction

                For Each row As GridViewRow In grdDispatchDetail.Rows

                    Dim chk As Boolean = CType(row.FindControl("chkSelect"), CheckBox).Checked
                    If (chk = True) Then

                        Dim iEnteredQty As Integer = row.Cells(7).Text
                        Dim iQty As Integer = row.Cells(3).Text

                        If (iEnteredQty >= iQty) Then
                            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Quantity Already Completed');", True)
                            Exit Sub
                        End If

                        Dim Ip As String = Request.ServerVariables("REMOTE_ADDR").ToString
                        Dim sqlstr As String = "jct_ops_get_team_quotations_for_internal_planning_auth_new"
                        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)

                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16).Value = row.Cells(0).Text
                        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 16).Value = Session("Empcode").ToString
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 16).Value = Ip

                        Dim strStage As String = CType(row.FindControl("ddlStage"), DropDownList).SelectedValue
                        cmd.Parameters.Add("@Type", SqlDbType.VarChar, 16).Value = strStage

                        Dim TargetDt As String = CType(row.FindControl("txtdate"), TextBox).Text
                        cmd.Parameters.Add("@Target_Date", SqlDbType.VarChar, 16).Value = TargetDt

                        'Dim strRemark As String = CType(row.FindControl("txtdate"), TextBox).Text
	       
	      Dim strRemark As String = CType(row.FindControl("txtGreighRemark"), TextBox).Text
                        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 16).Value = strRemark

                        'cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 16).Value = row.Cells(6).Text
                        cmd.Parameters.Add("@Action_Type", SqlDbType.VarChar, 16).Value = "A"

                        Dim EnterQty As Integer = CType(row.FindControl("txtGreighQty"), TextBox).Text
                        EnterQty = CType(row.FindControl("txtGreighQty"), TextBox).Text
                        cmd.Parameters.Add("@GreighQty", SqlDbType.Int, 16).Value = EnterQty

                        cmd.Parameters.Add("@Line_No", SqlDbType.Int, 16).Value = Convert.ToString(row.Cells(1).Text)

                        cmd.ExecuteNonQuery()

                    End If

                Next

                tr.Commit()

                ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Recored Save');", True)

                Dim sql As String = "jct_ops_Quotation_prod_details_Status"
                Dim cmd1 As SqlCommand = New SqlCommand(sql, cn.Connection, tr)

                cmd1.CommandType = CommandType.StoredProcedure
                cmd1.Parameters.Add("@QuotNo", SqlDbType.VarChar, 16).Value = lblQuotationNo.Text

                cmd1.ExecuteNonQuery()
                Action = "completion date of Quotation No. " & lblQuotationNo.Text & " has been finalize by  " + Session("EmpName").ToString

                EmailCreate(strVal, Action)
                bindgrid()
                bindDispatch(lblQuotationNo.Text)
                GreighDateBind(lblQuotationNo.Text)

            Catch ex As Exception
                tr.Rollback()
                'ofn.Alert(ex.Message)


            End Try
        End If
    End Sub
End Class
