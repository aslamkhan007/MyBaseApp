Imports System.Data.SqlClient
Imports System.Data
Imports System.Net
Partial Class OPS_QuotationProd_Details_new
    Inherits System.Web.UI.Page
    Dim ofn As New Functions

    'Protected Sub grdUnauthorisedQuotes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdUnauthorisedQuotes.SelectedIndexChanged

    '    lblQuotationNo.Text = grdUnauthorisedQuotes.SelectedDataKey.Value.ToString
    'End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Session("Empcode") Is Nothing Then
            Response.Redirect("Login.aspx")
            ' Do whatever you were going to do.

        End If
        bindgridAuth()
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
                Action = ddlType.SelectedValue & "completion date of Quotation No. " & lblQuotationNo.Text & " has been finalize by  " + Session("EmpName").ToString
                EmailCreate(strVal, Action)
                bindgrid()
                bindgridAuth()
				lblQuotationNo.Text=""
            Catch ex As Exception
                ofn.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub GridViewLevel2_SelectedIndexChanged1(sender As Object, e As System.EventArgs) Handles GridViewLevel2.SelectedIndexChanged

        lblQuotationNo.Text = GridViewLevel2.SelectedDataKey.Value.ToString
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

        ''currentPageUrl = "http://localhost:4377/FusionApps-old-18%20dec/OPS/" & page_name

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
                        cc = dr("e_mailid").ToString + ";"
                    End If
                End While
            End If
            dr.Close()

            cc = cc & "; ashish@jctltd.com;rbaksshi@jctltd.com"
            bcc = "manishk@jctltd.com; Ashish@jctltd.com"
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

            cc = cc & "; ashish@jctltd.com;"
            bcc = "manishk@jctltd.com, Ashish@jctltd.com"
            sm.SendMail2(recipients, cc, bcc, "noreply@jctltd.com", subject, body_to)
        Catch ex As Exception
            Throw New Exception("Error in sendding email")
        End Try
    End Sub

    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        If ddlType.SelectedValue = "-- Select --" Then
            lblstatus.Text = ""
        Else
            lblstatus.Text = "For " & ddlType.SelectedValue
        End If

        bindgrid()
    End Sub

    Private Sub bindgrid()
        GridViewLevel2.DataSource = Nothing
        GridViewLevel2.DataBind()
        Dim cn As New Connection
        Dim sql As String = "sp_jct_ops_Get_prod_Detailby_planning_level_new"
        Dim cmd As New SqlCommand(sql, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("Type", SqlDbType.VarChar, 510).Value = ddlType.SelectedValue
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
End Class
