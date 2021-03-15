Imports System.Data
Imports System.Data.SqlClient
Imports System.Net

Partial Class OPS_Quotation_Panel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        hfdSalesPerson.Value = Session("EmpCode").ToString.Replace("-", "")

    End Sub
    Protected Function GetAttachments(quot_no As String) As Integer

        Dim ofn As Functions = New Functions

        Dim sql As String

        sql = "select isnull(count(*),0) from jct_ops_ref_docs where status='A' and basedocno = '" & quot_no & "'"
        Dim n As Integer = ofn.FetchValue(sql)

        Return n

    End Function
    Protected Sub cmdAuthorise_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs)

        Dim ofn As New Functions



        If Session("EmpCode").ToString = "" Then
            Exit Sub
        End If
        Dim quot_no As String = e.CommandArgument.ToString
        Dim count As Int32 = 0
        count = GetAttachments(quot_no).ToString
        If count = 0 Then 'And lblStatus.Text = "QuotOpen" Then
            ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Please Attach Document Before Authorization');", True)
        Else
            Dim sqlstr As String = "jct_ops_authorise_quote"
            Dim cn As New Connection
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            cmd.CommandType = CommandType.StoredProcedure

            ' Dim quot_no As String = e.CommandArgument.ToString

            cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
            cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)

            cmd.Parameters("@Quotation_no").Value = quot_no
            cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
            cmd.Parameters("@User_Type").Value = "SP"

            'Try
            '    cn.ConOpen()
            '    cmd.ExecuteNonQuery()
            '    cn.ConClose()

            'Catch ex As Exception
            '    lblMessage.Text = ex.Message

            'End Try

            Dim sm As New SendMail
            Dim str, body_to, subject As String

            str = ""
            body_to = ""
            subject = ""

            Try
                cn.ConOpen()
                cmd.ExecuteNonQuery()
                cn.ConClose()
                lblMessage.Text = "Quotation # " + quot_no + " has been authorised by " + Session("EmpName").ToString + " : " + Session("EmpCode").ToString

                Try
					 Dim baseurl As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
					 Dim baseurl1	 As String = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) + "/"
					 baseurl=baseurl + "ops/Quotation_Main.aspx?quot=" + quot_no
                    Dim bcc As String = "rbaksshi@jctltd.com; ashish@jctltd.com; harendra@jctltd.com"
                    subject = "Authorisation of Quotation No. " & quot_no & " has been done by " + Session("EmpName").ToString '+ " : " + Session("EmpCode").ToString
                   ' body_to = "Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Main.aspx?quot=" & quot_no & "'> " & quot_no & "</a> has been Authorised successfully! " + Session("EmpName").ToString + "<br/> Click on Quotation Number to view details."					
					body_to = "Quotation # <a href = '"+baseurl +"'> " & quot_no & "</a> has been Authorised successfully! " + Session("EmpName").ToString + "<br/> Click on Quotation Number to view details."
				   baseurl1=baseurl1 + "OPS/Quotation_Detail_Preview.aspx?quot=" + quot_no
				   body_to +=GetPage(baseurl1)
				  ' body_to += GetPage("http://misdev/FusionApps/OPS/Quotation_Detail_Preview.aspx?quot=" & quot_no)

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

                    Dim recipients, m_sender, sender_name, cc, recipient_name As String
                    recipients = ""
                    m_sender = ""
                    sender_name = ""
                    recipient_name = ""
                    cc = ""

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

                    cc = cc & "rbaksshi@jctltd.com; ashish@jctltd.com;"
                    sm.SendMail2(recipients, cc, "", "approvals@jctltd.com", subject, body_to)
                Catch ex As Exception
                    lblMessage.Text = "Error sending email to concerned person(s)."
                End Try

            Catch ex As Exception
                sm.SendMail2("ashish@jctltd.com", "", "", "approvals@jctltd.com", "Error occurred while authorising Quotation:" + quot_no, ex.Message)

                ofn.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub grdOpenQuotes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdOpenQuotes.SelectedIndexChanged

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