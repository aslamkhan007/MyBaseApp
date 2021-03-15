Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net

Partial Class TransportRequisition
    Inherits System.Web.UI.Page
    Dim obj As New Connection
    Dim cmd As New SqlCommand
    Dim qry, qry1, qry2 As String
    Dim dr As SqlDataReader
    Dim OBJ1 As New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode") <> "") Then

        Else
            Response.Redirect("~\login.aspx")
        End If

        If Not IsPostBack Then
            obj.ConOpen()
            qry2 = "select empname from jct_empmast_base where empcode='" & Session("empcode") & "' and active='Y'"

            cmd = New SqlCommand(qry2, obj.Connection)
            Me.Txtrequiredby.Text = IIf(cmd.ExecuteScalar Is Nothing, "", cmd.ExecuteScalar)
            ' qry2 = "select VEHICLE_No,VEHICLE_Name from JCT_EMP_TRANSPORTATION_VEHICLES where STATUS<>'d' ORDER BY VEHICLE_Name"
            qry2 = "select VEHICLE_No,VEHICLE_Name from JCT_EMP_TRANSPORTATION_VEHICLES where STATUS='' AND Eff_To IS null ORDER BY VEHICLE_Name"

            OBJ1.FillList(DdlVehicle, qry2)
            DdlVehicle.Items.Add("")

            OBJ1.FillList(DdlVehicleAllocated, qry2)
            DdlVehicleAllocated.Items.Add("")


            If UCase(Session("Empcode")) = "R-03339" Then
                If Request.QueryString("AutoID") <> "" Then
                    'qry = "select Place, OnDate, OnTime, Purpose, ReturnDate, ReturnTime, Chargeable, ReportPlace,AuthFlag,Status,No_of_Persons,Vehicle_Prefrence from jct_emp_transport_request where companycode='" & Session("Companycode") & "' and AutoID=" & Request.QueryString("AutoID") & "'"
                    qry = "SELECT AutoID,b.empname AS RequestBy,Place AS PlaceToVisit,Purpose,No_of_Persons,isnull(Vehicle_Prefrence,'') AS Requested_Vehicle,OnDate,OnTime AS At,isnull(ReportPlace,'') AS MadeAvailableAt ,ReturnDate,ReturnTime FROM jct_emp_transport_request a,dbo.jct_empmast_base b WHERE a.Status<>'D' AND AuthFLAG='P' AND b.Status='A' and a.UserCode=b.EmpCode and a.companycode=b.companycode and a.companycode='" & Session("Companycode") & "' and AutoID=" & Request.QueryString("AutoID") & " ORDER BY AutoID"
                    Dim Dr As SqlDataReader = obj.FetchReader(qry)
                    'Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, obj.Connection())
                    Dr.Read()
                    Try
                        If Dr.HasRows = True Then
                            'Dr.Close()
                            'Dim ds As DataSet = New DataSet()
                            'ds.Clear()
                            'Da.Fill(ds)
                            'GrdTransport.DataSource = ds
                            'GrdTransport.DataBind()
                            Txtslno.Text = Dr.Item("AutoID")
                            Txtslno.Enabled = False

                            Txtrequiredby.Text = Dr.Item("RequestBy")
                            Txtrequiredby.Enabled = False

                            Txtplace.Text = Dr.Item("PlaceToVisit")
                            Txtplace.Enabled = False

                            Txtpurpose.Text = Dr.Item("Purpose")
                            Txtpurpose.Enabled = False

                            txtNo_of_Persons.Text = Dr.Item("No_of_Persons")
                            txtNo_of_Persons.Enabled = False

                            DdlVehicle.Text = Dr.Item("Requested_Vehicle")
                            DdlVehicle.Enabled = False

                            CadReq.Text = Dr.Item("OnDate")
                            CadReq.Enabled = False

                            txtrequiredtime.Text = Dr.Item("At")
                            txtrequiredtime.Enabled = False

                            txtreport.Text = Dr.Item("MadeAvailableAt")
                            txtreport.Enabled = False

                            cadreturn.Text = Dr.Item("ReturnDate")
                            cadreturn.Enabled = False

                            txtreturntime.Text = Dr.Item("ReturnTime")
                            txtreturntime.Enabled = False

                            Dr.Close()
                            Panel1.Visible = True
                            BtnBack.Text = "Authorize"
                            btnsub.Text = "UnAutorize"

                        Else

                        End If
                    Catch Ex As Exception
                        Ex.ToString()
                    End Try
                End If
            Else


            End If
        End If
    End Sub

    Protected Sub btnsub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsub.Click

        Dim script2 As String

        Try
            If btnsub.Text = "Submit" Then
                obj.ConOpen()
                qry1 = "select max(autoid) from jct_emp_transport_request" 'where empcode='" & Session("empcode") & "' "
                cmd = New SqlCommand(qry1, obj.Connection)
                Me.Txtslno.Text = IIf(cmd.ExecuteScalar Is Nothing, " ", cmd.ExecuteScalar)
                obj.ConClose()
                obj.ConOpen()

                If (rblcharge.SelectedItem.Text = "No") Then

                    If (String.IsNullOrEmpty(txtNo_of_Persons.Text)) Then
                        script2 = "alert('Please Enter no. of Persons.');"
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script2, True)
                        Return
                    End If

                Else
                    txtNo_of_Persons.Text = 0
                End If

                'CompanyCode, UserCode, HostIP, EntryTime, AutoID, EmpCode, Place, OnDate, OnTime, Purpose, ReturnDate, ReturnTime, Chargeable, ReportPlace
                'qry = "insert into jct_emp_transport_request values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Request.ServerVariables("REMOTE_ADDR") & "',GETDATE()," & Txtslno.Text & ",'" & Me.Txtplace.Text & "','" & Me.Cadreq.SelectedDate & "','" & Right(Trim(txtrequiredtime.SelectedValue), 11) & "','" & Me.Txtpurpose.Text & "','" & Me.cadreturn.SelectedDate & "','" & Right(Trim(txtreturntime.SelectedValue), 11) & "','" & Me.rblcharge.SelectedValue & "','" & Me.txtreport.Text & "','','',convert(varchar(10),null),'','',convert(varchar(10),null),convert(varchar(10),null),convert(varchar(10),null),'','',convert(varchar(10),null))"
                qry = "Insert into jct_emp_transport_request(CompanyCode, UserCode, HostIP, EntryTime, Place, OnDate, OnTime, Purpose, ReturnDate, ReturnTime, ReportPlace,AuthFlag,Status,No_of_Persons,Vehicle_Prefrence,chargeable,required_by) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Request.ServerVariables("REMOTE_ADDR") & "',GETDATE(),'" & Me.Txtplace.Text & "','" & Me.CadReq.SelectedDate & "','" & Right(Trim(txtrequiredtime.SelectedValue), 11) & "','" & Me.Txtpurpose.Text & "','" & Me.cadreturn.SelectedDate & "','" & Right(Trim(txtreturntime.SelectedValue), 11) & "','" & Me.txtreport.Text & "','P',''," & txtNo_of_Persons.Text & ",'" & DdlVehicle.SelectedItem.Text & "','" & rblcharge.SelectedItem.Text & "','" & Txtrequiredby.Text & "')"
                cmd = New SqlCommand(qry, obj.Connection)
                cmd.ExecuteNonQuery()
                obj.ConClose()
                script2 = "alert('Record Saved Successfully.');"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script2, True)
                SendMail()
                'SendMail(GetEmailID(Session("Empcode")), GetEmailID("R-03339"), "", "", "Transportation Request", Txtrequiredby.Text & " had requested " & DdlVehicle.SelectedItem.Text & " due to the following reason " & Txtpurpose.Text & ". To Visit " & Txtplace.Text & " On date " & Me.CadReq.SelectedDate & " At " & Right(Trim(txtrequiredtime.SelectedValue), 11))
            ElseIf btnsub.Text = "UnAutorize" Then
                obj.ConOpen()
                qry = "Update jct_emp_transport_request set AuthFlag='U',AuthBy='" & Session("Empcode") & "',authDate=getdate(),AuthRemarks='" & txtRemarks.Text & "'  where companycode='" & Session("Companycode") & "' and AutoID=" & Request.QueryString("AutoID") & ""
                cmd = New SqlCommand(qry, obj.Connection)
                cmd.ExecuteNonQuery()
                obj.ConClose()
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Record Saved Sucessfully"
                FMsg.Display()
            End If
        Catch ex As Exception
           script2 = "alert('Transaction Not Completed');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script2, True)
        End Try
    End Sub


    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Try
            If BtnBack.Text = "Authorize" Then
                obj.ConOpen()
                qry = "Update jct_emp_transport_request set AuthFlag='A',AuthBy='" & Session("Empcode") & "',authDate=getdate(),Chargeable='" & Me.rblcharge.SelectedItem.Value & "',Vehicle_Allocated='" & DdlVehicleAllocated.SelectedItem.Text & "',AuthRemarks='" & txtRemarks.Text & "' where companycode='" & Session("Companycode") & "' and AutoID=" & Request.QueryString("AutoID") & ""
                cmd = New SqlCommand(qry, obj.Connection)
                cmd.ExecuteNonQuery()
                obj.ConClose()
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Record Saved Sucessfully"
                FMsg.Display()
            Else
                Response.Redirect("~\EmpGateway\form.aspx")
            End If
        Catch Ex As Exception
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Transaction Not Completed"
            FMsg.Display()
        End Try
    End Sub

    Protected Sub DdlVehicleAllocated_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlVehicleAllocated.SelectedIndexChanged

        'If UCase(Session("Empcode")) = "R-03339" Then
        '    If Request.QueryString("AutoID") <> "" Then
        txtCarAllocated.Text = DdlVehicleAllocated.SelectedItem.Value
        '    End If
        'End If

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Response.Redirect("TransportRequisition.aspx")
    End Sub

    Private Sub SendMail()
        Try
            Dim sql As String = String.Empty
            Dim [to] As String = String.Empty
            Dim from As String = String.Empty
            Dim bcc As String = String.Empty
            Dim cc As String = String.Empty
            Dim subject As String = String.Empty
            Dim body__1 As String = String.Empty
            Dim url As String = String.Empty
            Dim querystring As String = String.Empty
            Dim Body__2 As String = String.Empty
            Dim sb As New StringBuilder()

            sql = "select max(autoid) as Autoid from JCT_Emp_Transport_Request"
            ViewState("RequestID") = OBJ1.FetchValue(sql)

            subject = "Transport Requisition Request - " + ViewState("RequestID").ToString()

            'subject = "Transport Requisition"
            'Body__2 = "Transport Requisition has been submitted."

            [to] = "saini@jctltd.com,jctadmin@jctltd.com"
            bcc = "jatindutta@jctltd.com"
            from = "noreply@jctltd.com"

            sb.AppendLine("<html>")
            sb.AppendLine("<head>")
            sb.AppendLine("<style type=""text/css"">")
            sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
            sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
            sb.AppendLine("</style>")
            sb.AppendLine("</head>")

            ' sb.Append("<head>");
            sb.AppendLine("Hi,<br/><br/>")
            sb.AppendLine("Transport Requisition Request generated.<br/><br/>")
            sb.AppendLine("RequestID for your request is : " + ViewState("RequestID").ToString() + " <br/><br/>")
            sb.AppendLine("Details are Shown below : <br/><br/>")
            sb.AppendLine("<table class=gridtable>")
            sb.AppendLine("<tr><th> Vehicle Required By</th> <th> " + Txtrequiredby.Text + "</th></tr>")
            sb.AppendLine("<tr><th> Place To Be Visited</th> <th> " + Txtplace.Text + "</th></tr>")
            sb.AppendLine("<tr><th> Date Required</th> <th> " + CadReq.SelectedDate + "</th></tr>")
            sb.AppendLine("<tr><th> Time Required</th> <th> " + txtrequiredtime.SelectedTime.ToShortTimeString() + "</th></tr>")
            sb.AppendLine("<tr><th> Purpose</th> <th> " + Txtpurpose.Text + "</th></tr>")
            sb.AppendLine("<tr><th> No.Of.Persons</th> <th> " + txtNo_of_Persons.Text + "</th></tr>")
            sb.AppendLine("<tr><th> Vehicle Alloted</th> <th> " + DdlVehicleAllocated.SelectedItem.Text + "</th></tr>")
            sb.AppendLine("<tr><th> Return Date</th> <th> " + cadreturn.SelectedDate + "</th></tr>")
            sb.AppendLine("<tr><th> Return Time</th> <th> " + txtreturntime.SelectedTime.ToShortTimeString() + "</th></tr>")
            sb.AppendLine("<tr><th> Report Place</th> <th> " + txtreport.Text + "</th></tr>")
            sb.AppendLine("<tr><th> Chargeable</th> <th> " + rblcharge.SelectedItem.Value + "</th></tr>")
            sb.AppendLine("</table>")
            sb.AppendLine("</html><br/><br/>")

            Dim mail As New MailMessage()
            mail.From = New MailAddress(from)
            If [to].Contains(",") Then
                Dim tos As String() = [to].Split(","c)
                For i As Integer = 0 To tos.Length - 1
                    mail.[To].Add(New MailAddress(tos(i)))
                Next
            Else
                mail.[To].Add(New MailAddress([to]))
            End If

            If Not String.IsNullOrEmpty(cc) Then
                If cc.Contains(",") Then
                    Dim ccs As String() = cc.Split(","c)
                    For i As Integer = 0 To ccs.Length - 1
                        mail.CC.Add(New MailAddress(ccs(i)))
                    Next
                Else
                    mail.CC.Add(New MailAddress(cc))
                End If
            End If

            If Not String.IsNullOrEmpty(bcc) Then
                If bcc.Contains(",") Then
                    Dim bccs As String() = bcc.Split(","c)
                    For i As Integer = 0 To bccs.Length - 1
                        mail.Bcc.Add(New MailAddress(bccs(i)))
                    Next
                Else
                    mail.Bcc.Add(New MailAddress(bcc))
                End If
            End If

            mail.Subject = subject

            mail.Body = sb.ToString()
            mail.IsBodyHtml = True
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            Dim SmtpMail As New SmtpClient("exchange2007")
            SmtpMail.Send(mail)
        Catch ex As Exception
            'lblError.Text = "Error : " + ex.Message;
            Return
        End Try

    End Sub

End Class
