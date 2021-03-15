Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI
Imports System.Net.Mail
Imports System.IO


Partial Class OPS_RaiseSanctionNote
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction


    Protected Sub ddlarea_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlarea.SelectedIndexChanged
      
        If (ddlarea.SelectedItem.Text = "Greigh Transfer") Or (ddlarea.SelectedItem.Text = "PHouse Greigh Transfer") Or (ddlarea.SelectedItem.Text = "Greigh Transfer Taffeta") Then

            Response.Redirect("SaleOrderAdjustment10.aspx?Type=" & ddlarea.SelectedItem.Text)
        ElseIf (ddlarea.SelectedItem.Text = "New Sample Request") Then
            Response.Redirect("Sample_Request.aspx")
        ElseIf (ddlarea.SelectedItem.Text = "ODS Request") Then
            Response.Redirect("ODS_Request_Genration.aspx")
        Else
            '  qry = "Select ParamCode ,ParmDesc,isnull(MultiValues,'')+'-'+isnull(ProcName,'') as Val FROM Jct_Ops_SanctionNote_Parameters where status='A' and AreaCode=" & ddlarea.SelectedItem.Value
            qry = "Select ParamCode ,ParmDesc,isnull(MultiValues,'')+'-'+isnull(ProcName,'') as Val,Postback,Reqd_Flag FROM Jct_Ops_SanctionNote_Parameters where status='A' and AreaCode=" & ddlarea.SelectedItem.Value & " order by ParamCode "
            objFun.FillGrid(qry, grdParameters)
            'qry = "SELECT upper(a.EmpCode) as EmpCode,c.Empname,a.UserLevel FROM dbo.Jct_Ops_SanctioNote_Area_Emp_Auth_Listing a,Jct_Ops_SanctioNote_Area_Master b,dbo.JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS='A' AND a.STATUS=b.STATUS AND c.empcode=a.empcode AND a.AreaCode=" & ddlarea.SelectedItem.Value & " and a.plant='" & ddlplant.SelectedItem.Text & "' ORDER BY UserLevel"
            'objFun.FillGrid(qry, GrdEmployee)
            If ddlplant.SelectedItem.Text = "Purchase By Mkt" Then
                qry = "SELECT upper(a.EmpCode) as EmpCode,c.Empname,a.UserLevel FROM dbo.Jct_Ops_SanctioNote_Area_Emp_Auth_Listing a,Jct_Ops_SanctioNote_Area_Master b,dbo.JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS='A' AND a.STATUS=b.STATUS AND c.empcode=a.empcode AND a.AreaCode=" & ddlarea.SelectedItem.Value & " and a.plant='" & ddlplant.SelectedItem.Text & "' ORDER BY UserLevel"
                objFun.FillGrid(qry, GrdEmployee)

            End If
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'qry = "Select 0 as [AreaCode],'--Select--' as [AreaName] Union SELECT AreaCode,AreaName FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' and parentarea=1015 and areacode not in (1015,1018,1019,1020,1021,1014,1024,1023,1029,1033,1047,1049,1050,1053) ORDER BY AreaName"
            qry = "Select 0 as [AreaCode],'--Select--' as [AreaName] Union SELECT AreaCode,AreaName FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' and parentarea=1015 and  AreaCode IN (1011,1010,1012,1009,1059,1022) ORDER BY AreaName"

            objFun.FillList(ddlarea, qry)
        End If '
    End Sub

    Protected Sub cmdApply_Click(sender As Object, e As System.EventArgs) Handles cmdApply.Click
        Dim FileName As String = ""

        Dim i As Int16
        i = 0
        Dim ParmCode As String = ""
        Dim SanctionID As String = ""
        Dim ddlVal As String = ""
        Dim EmpCode As String
        Dim index As Int16 = 0
        Dim EmpName As String = ""
        EmpCode = Trim(Session("Empcode"))
        Dim Genratedby_Email As String = "", GenratedByName As String = ""
        Dim Cmd2 As SqlCommand = New SqlCommand
        Dim Str As String
        Dim body As String, Body1 As String, Body2 As String = "", Body3 As String = ""
        Dim ParmName As String = ""
        Dim ToList As String = ""

        Dim AuthMob As String = ""
        Dim ReasonCode As Int16

        Tran = obj.Connection.BeginTransaction
        Try
            qry = "SELECT TOP 1 Num FROM JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL"
            SanctionID = objFun.FetchValue(qry, obj.Connection, Tran)

            Body1 = " <hr> Description :- " & txtDescription.Text & "<hr> "

            qry = " exec Jct_Ops_SanctionNote_Insert_HDR_Import '" & Session("Empcode") & "','" & ddlarea.SelectedItem.Value & "','" & txtSubject.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & SanctionID & "','" & ddlplant.SelectedItem.Text & "','" & RadioButtonList1.SelectedItem.Value & "','" & txtImportSanctionNote.Text & "'"
            objFun.InsertRecord(qry, Tran, obj.Connection)
            With grdParameters
                For i = 0 To .Rows.Count - 1
                    ParmCode = .Rows(i).Cells(0).Text
                    ParmName = Trim(.Rows(i).Cells(1).Text)
                    Dim ddlValueList As DropDownList = CType(.Rows(i).FindControl("ddlValueList"), DropDownList)
                    Dim txtValue As TextBox = CType(.Rows(i).FindControl("txtValue"), TextBox)

                    If ddlValueList.Visible = True Then
                        qry = "Exec Jct_Ops_SanctionNote_Insert_Dtl '" & SanctionID & "','" & ParmCode & "','" & ddlValueList.SelectedItem.Text & "'"
                        If LCase(ParmName) = LCase("reason") Then
                            ReasonCode = ddlValueList.SelectedItem.Value
                        End If
                        Body1 = Body1 & "<p> <b>" & ParmName & " :-</b> " & ddlValueList.SelectedItem.Text & " </p> "
                    Else
                        qry = "Exec Jct_Ops_SanctionNote_Insert_Dtl '" & SanctionID & "','" & ParmCode & "','" & txtValue.Text & "'"
                        Body1 = Body1 & "<p> <b>" & ParmName & " :- </b> " & txtValue.Text & " </p> "
                    End If
                    objFun.InsertRecord(qry, Tran, obj.Connection)
                Next

                qry = "UPDATE  JCT_OPS_SanctionNote_Codes SET IsConsumed = 'Y',DateConsumed = GETDATE() WHERE   Num = '" & SanctionID & "'  "
                objFun.UpdateRecord(qry, Tran, obj.Connection)



                If Request.Files.Count > 0 Then
                    For i = 0 To Request.Files.Count - 1
                        Dim PostedFile As HttpPostedFile = Request.Files(i)
                        If PostedFile.ContentLength > 0 Then
                            FileName = System.IO.Path.GetFileName(PostedFile.FileName)
                            PostedFile.SaveAs(Server.MapPath("Upload\") & FileName)
                            qry = "INSERT INTO Jct_Ops_SanctionNote_Attachments( SanctionNoteID ,ImgName ,STATUS ,UploadedOn) VALUES  ( '" & SanctionID & "' , '" & FileName & "' , 'A' , GETDATE())"
                            objFun.InsertRecord(qry, Tran, obj.Connection)
                        End If
                    Next

                End If

                Dim EmpLevelCount As Int16 = 0
                EmpLevelCount = ChkDynamicListing.Items.Count



                For i = 0 To ChkDynamicListing.Items.Count - 1
                    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL,ImportedUser) values('" & SanctionID & "','" & Session("empcode") & "','" & ddlarea.SelectedItem.Value & "','" & ChkDynamicListing.Items(i).Value & "'," & i + 1 & ",'Y')"
                    cmd = New SqlCommand(qry, obj.Connection)
                    cmd.Transaction = Tran
                    cmd.ExecuteNonQuery()
                Next


                qry = "exec Jct_Ops_SanctionNote_InsertDynamic_User_ReasonWise '" & SanctionID & "','" & Session("empcode") & "','" & ddlarea.SelectedItem.Value & "'," & EmpLevelCount & ",'" & ddlplant.SelectedItem.Text & "'," & ReasonCode & ""
                objFun.InsertRecord(qry, Tran, obj.Connection)



                For i = 0 To chkNotify.Items.Count - 1
                    qry = "INSERT INTO dbo.Jct_Ops_SanctionNote_Notify( Usercode ,SanctionID ,NotifyUser , CreatedDate) values('" & Session("Empcode") & "','" & SanctionID & "','" & chkNotify.Items(i).Value & "',getdate())"
                    cmd = New SqlCommand(qry, obj.Connection)
                    cmd.Transaction = Tran
                    cmd.ExecuteNonQuery()
                Next


            End With
            Tran.Commit()
            objFun.Alert("Record Saved Sucessfully !!")
            lblID.Text = SanctionID
            cmdApply.Enabled = False

        Catch ex As Exception
            Tran.Rollback()
            objFun.Alert("Unable to Complete Transaction " & ex.Message.ToString)
            Exit Sub
        End Try
        'qry = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" & OrderNo & "'"
        'Dim SalePersonCode As String = ""
        'Dim SalePersonEmail As String = "mkt-group@jctltd.com"
        'SalePersonCode = objFun.FetchValue(qry)
        'If SalePersonCode Is Nothing Then SalePersonCode = ""
        'If SalePersonCode <> "mkt-group@jctltd.com" And CStr(SalePersonCode) <> "" Then
        '    SalePersonCode = Left(SalePersonCode, 1) & "-" & Right(SalePersonCode, Len(SalePersonCode) - 1)

        Try




            qry = "SELECT isnull(E_MailID,''),name FROM dbo.MISTEL WHERE empcode='" & EmpCode & "' "
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                Genratedby_Email = dr.Item(0)
                GenratedByName = dr.Item(1)
            End If
            dr.Close()
            obj.ConClose()
            'End If
            body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br>Sanction Note with ID <b>" & SanctionID & " </b> has been genrated  With Following Detail "
            Body1 = Body1 & "<hr>"
            Body2 = "<Br><br> The Sanction Note is genrated by " & GenratedByName & " <Hr> <br> <b>With Description :-</b><hr>"




            qry = "SELECT a.EmpCode ,Name,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE UserLevel=1  AND STATUS IS null and AreaCode='" & ddlarea.SelectedItem.Value & "' and a.EmpCode=b.empcode and id='" & SanctionID & "' "
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Genratedby_Email = Genratedby_Email & "," & dr.Item(2)
                Body3 = "<br><br><hr> This is Pending At <b>" & dr.Item(1) & " </b> "
            End If
            dr.Close()
            obj.ConClose()


            Body3 = Body3 & " <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
            'Genratedby_Email = Genratedby_Email & "," & objFun.FetchValue(qry)
            Dim NotifyEmailGroup As String = "Noreply@jctltd.com"
            qry = "SELECT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='" & SanctionID & "'"
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
                End While
            End If
            'If Right(NotifyEmailGroup, 1) = "," Then
            '    NotifyEmailGroup=
            'End If
            GenrateMail(body, Body1, Body2, Body3, SanctionID, Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your SanctionNote No :-" & SanctionID & " has been genrated ")

        Catch
            objFun.Alert("Unable to Send Email..... ")
        End Try

        Try
            AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a WHERE a.empcode=b.empcode  AND a.ID='" & SanctionID & "' and a.Userlevel='1' ")
            If AuthMob Is Nothing Then
                AuthMob = 0
            End If
            Dim RaisedByUserName As String = ""
            Dim sm As New SendMail
            RaisedByUserName = objFun.FetchValue("SELECT b.empname FROM Jct_Ops_SanctionNote_HDR a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND a.SanctionNoteID='" & SanctionID & "'")
            Dim msg As String = "Sanction Note " & SanctionID & " is due for approval. It was last approved by None  and raised by " & RaisedByUserName
            If Len(AuthMob) >= 10 Then
                sm.SendSMS(Session("CompanyCode"), Session("EmpCode"), AuthMob, msg, "SanctionNote Raised")
            End If
        Catch ex As Exception
            objFun.Alert("Unable to Send SmS..... ")
        End Try


        qry = "update Jct_Ops_SanctionNote_Notify Set Notified='Y',NotifiedOn=getdate() where SanctionID='" & SanctionID & "'"
        objFun.UpdateRecord(qry)



    End Sub

    Protected Sub grdParameters_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdParameters.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim HdnFld As String = CType(e.Row.FindControl("HiddenField1"), HiddenField).Value
            Dim ddlValue As DropDownList = CType(e.Row.FindControl("ddlValueList"), DropDownList)
            Dim Req_DataValidation As RequiredFieldValidator = CType(e.Row.FindControl("Req_DataValidation"), RequiredFieldValidator)
            Dim Validator_Extnd As AjaxControlToolkit.FilteredTextBoxExtender = CType(e.Row.FindControl("txtValue_FilteredTextBoxExtender"), AjaxControlToolkit.FilteredTextBoxExtender)
            If LCase(e.Row.Cells(5).Text) = "y" Then
                Req_DataValidation.Enabled = True
                Validator_Extnd.Enabled = True
                'txtValue_FilteredTextBoxExtender
            End If

            If LCase(e.Row.Cells(4).Text) = "y" Then
                ddlValue.AutoPostBack = True
                'Dim ddl As DropDownList = CType(sender, DropDownList)
                'Dim Tgr As AsyncPostBackTrigger = New AsyncPostBackTrigger
                'Tgr.ControlID = ddlValue.ID
                'Tgr.EventName = "SelectedIndexChanged"
                'UpdatePanel11.Triggers.Add(Tgr)
            End If
            If Trim(HdnFld) <> "-" Then
                Try
                    qry = "Exec " & HdnFld.Substring(2)
                    objFun.FillList(ddlValue, qry)
                    ddlValue.Visible = True
                    If ddlValue.AutoPostBack = True Then
                        qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy a ,Jct_Ops_SanctioNote_Area_Master b ,dbo.JCT_EmpMast_Base C WHERE   a.AreaCode = b.AreaCode AND a.STATUS = 'A' AND a.STATUS = b.STATUS AND c.empcode = a.empcode AND a.AreaCode = '" & ddlarea.SelectedItem.Value & "' AND a.plant = '" & ddlplant.SelectedItem.Text & "' AND ReasonCode='" & ddlValue.Items(0).Value & "' and a.eff_to is null ORDER BY AuthLevel"
                        objFun.FillGrid(qry, GrdEmployee)
                    End If
                    CType(e.Row.FindControl("txtValue"), TextBox).Visible = False
                Catch ex As Exception
                    objFun.Alert("Unable To Fetch Values for " & e.Row.Cells(0).Text & "parameter")
                End Try
            End If
            If ddlplant.SelectedItem.Text = "Purchase By Mkt" Then
                qry = "SELECT upper(a.EmpCode) as EmpCode,c.Empname,a.UserLevel FROM dbo.Jct_Ops_SanctioNote_Area_Emp_Auth_Listing a,Jct_Ops_SanctioNote_Area_Master b,dbo.JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS='A' AND a.STATUS=b.STATUS AND c.empcode=a.empcode AND a.AreaCode=" & ddlarea.SelectedItem.Value & " and a.plant='" & ddlplant.SelectedItem.Text & "' ORDER BY UserLevel"
                objFun.FillGrid(qry, GrdEmployee)

            End If
        End If
    End Sub
    Private Sub GenrateMail(Body As String, Body1 As String, Body2 As String, Body3 As String, OrderNo As String, SalesPerson_Email As String, [to] As String, cc As String, bcc As String, Subject As String)
        Dim from As String ', body__2 As String
        from = "noreply@jctltd.com"
        Dim query As String = ""
        Dim SenderEmail As String = ""

        'If SalesPerson_Email Is Nothing Then
        '    SalesPerson_Email = ""
        'End If

        'query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
        'SenderEmail = objFun.FetchValue(query)
        'If SenderEmail <> "" Then

        '    'Email Address of Receiver
        '    [to] = SenderEmail & "," & SalesPerson_Email ' "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com"
        '    'Else
        '    '    'Email Address of Receiver
        '    '    [to] = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com," & Convert.ToString(SalesPerson_Email)
        'End If


        'bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"
        'cc = "arwinder@jctltd.com"
        '    subject = "Authorized Shortfall Request - " & Convert.ToString(OrderNo)

        'StringBuilder sb = new StringBuilder();
        'sb.Append("Hi,<br/>");
        'sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
        'sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
        'sb.Append("<br/>");
        'sb.Append("Thanking you<br/>");
        'sb.Append("IT");

        'body__2 = Body__1

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
        If Not String.IsNullOrEmpty(cc) Then
            If cc.Contains(",") Then
                Dim ccs As String() = cc.Split(","c)
                For i As Integer = 0 To ccs.Length - 1
                    mail.CC.Add(New MailAddress(ccs(i)))
                Next
                'Else
                '    mail.CC.Add(New MailAddress(bcc))
            End If
            mail.CC.Add(New MailAddress(cc))
        End If


        'qry = "SELECT ImgName FROM Jct_Ops_SanctionNote_Attachments WHERE STATUS='A' AND SanctionNoteID='" & OrderNo & "'"
        'cmd = New SqlCommand(qry, obj.Connection)
        'dr = cmd.ExecuteReader
        'If dr.HasRows = True Then
        '    While dr.Read
        '        Dim Atchment As Attachment = New Attachment(Server.MapPath("~\OPS\Upload\") & dr.Item(0))
        '        mail.Attachments.Add(Atchment)
        '    End While
        'End If
        'dr.Close()

        mail.Subject = Subject
        mail.Body = Body & Body1 & Body2 & Body3
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2k7")


        SmtpMail.Send(mail)
    End Sub
    'Public Sub UploadAttachments()
    '    Dim FName As String, Ext As String
    '    Dim FileToCopy As String
    '    Dim NewCopy As String ', ReplyBack As String, SurveyStatus As String
    '    FName = Trim(FileUpload1.FileName)
    '    If FName <> "" Then
    '        FileUpload1.PostedFile.SaveAs(Server.MapPath("~\EmpGateway\Survey\") + FName)
    '    End If
    '    If FName <> "" Then
    '        ImgNameLbL.Text = FName
    '        Ext = Trim(Right(FileUpload1.FileName, 4))
    '    Else
    '        ImgNameLbL.Text = "No Image Selected"
    '        Ext = "No Image"
    '    End If
    '    'If Ext = ".jpg" Or Ext = ".ipg" Or Ext = ".bmp" Or Ext = ".png" Or Ext = ".gif" Or Ext = ".jpeg" Then
    '    FileToCopy = Server.MapPath("~\EmpGateway\Survey\") + FName
    '    'NewCopy = Server.MapPath("~\EmpGateway\Survey\") & "Sur-" & SurveyNo & "Q No- " & MaxQuestNo & Ext
    '    If System.IO.File.Exists(FileToCopy) = True Then
    '        If System.IO.File.Exists(NewCopy) <> True Then
    '            System.IO.File.Copy(FileToCopy, NewCopy)
    '        End If
    '    End If
    '    Dim FileToDelete As String
    '    FileToDelete = FileToCopy
    '    If System.IO.File.Exists(FileToDelete) = True Then
    '        System.IO.File.Delete(FileToDelete)
    '    End If

    '    'Else

    '    'End If
    'End Sub
    'Protected Sub btnTransfer_Click(sender As Object, e As System.EventArgs) Handles btnTransfer.Click

    '    Dim litem As ListItem
    '    For i As Int16 = 0 To ChkEmpList.Items.Count - 1
    '        If ChkEmpList.Items(i).Selected = True Then
    '            litem = New ListItem(ChkEmpList.Items(i).Text, ChkEmpList.Items(i).Value)
    '            ChkDynamicListing.Items.Add(litem)
    '        End If
    '    Next
    'End Sub
    'Protected Sub imgRemoveItem_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgRemoveItem.Click
    '    Dim i As Int16 = 0
    '    Dim CountItems As Int16 = ChkDynamicListing.Items.Count - 1
    '    For i = 0 To CountItems
    '        If ChkDynamicListing.Items(i).Selected = True Then
    '            ChkDynamicListing.Items.RemoveAt(i)
    '            CountItems -= 1
    '        End If
    '        'MsgBox("" & ChkUploadedItems.Items(i).ch)
    '    Next
    'End Sub
    'Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
    '    qry = "SELECT empcode,empname+'~'+b.DEPTNAME FROM JCT_EmpMast_Base a,DEPTMAST b WHERE empname LIKE '" & txtEmployee.Text & "%' AND Active='y' AND a.deptcode=b.DEPTCODE ORDER BY empname"
    '    objFun.FillList(ChkEmpList, qry)
    'End Sub
    'Protected Sub ibtAddFile_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtAddFile.Click
    '    Dim Fname As String
    '    Dim litem As ListItem
    '    If FileUpload1.FileName <> "" Then
    '        Fname = Trim(FileUpload1.PostedFile.FileName)
    '        'If FName <> "" Then
    '        '  FileUpload1.PostedFile.SaveAs(Server.MapPath("~\EmpGateway\Survey\") + FName)

    '        litem = New ListItem(Fname, FileUpload1.FileName)
    '        'ChkUploadedItems.Items.Add(litem)

    '        'Panel1_CollapsiblePanelExtender.Collapsed = False
    '        'Panel1_CollapsiblePanelExtender.AutoExpand = True
    '    End If
    'End Sub

    Protected Sub cmdReset_Click(sender As Object, e As System.EventArgs) Handles cmdReset.Click
        'Dim i As Int16
        'For i=0 to FlashUpload1.
        '    MsgBox(" A" & FlashUpload1)
        'FlashUpload1.
        GrdEmployee.DataSource = Nothing
        GrdEmployee.DataBind()

        grdParameters.DataSource = Nothing
        grdParameters.DataBind()

        ChkDynamicListing.Items.Clear()
        ChkEmpList.Items.Clear()
        chkNotify.Items.Clear()

        txtDescription.Text = ""
        txtSubject.Text = ""

        cmdApply.Enabled = True
      
    End Sub

    'Public Sub ProcessRequest(context As HttpContext)
    '    ' Example of using a passed in value in the query string to set a categoryId
    '    ' Now you can do anything you need to witht the file.
    '    'int categoryId = 0;
    '    'if (!string.IsNullOrEmpty(context.Request.QueryString["CategoryID"]))
    '    '{
    '    '    int.TryParse(context.Request.QueryString["CategoryID"],out categoryId);
    '    '}
    '    'if (categoryId > 0)
    '    '{
    '    '}

    '    'string temp = context.Session["temp"].ToString();

    '    'string EncryptString = context.Request.QueryString["User"];
    '    'FormsAuthenticationTicket UserTicket = FormsAuthentication.Decrypt(EncryptString);

    '    If context.Request.Files.Count > 0 Then
    '        ' get the applications path

    '        Dim uploadPath As String = context.Server.MapPath(Convert.ToString(context.Request.ApplicationPath) & "/OPS/Upload")
    '        ' loop through all the uploaded files
    '        For j As Integer = 0 To context.Request.Files.Count - 1
    '            ' get the current file
    '            Dim uploadFile As HttpPostedFile = context.Request.Files(j)
    '            ' if there was a file uploded
    '            If uploadFile.ContentLength > 0 Then
    '                ' save the file to the upload directory

    '                'use this if testing from a classic style upload, ie. 

    '                ' <form action="Upload.axd" method="post" enctype="multipart/form-data">
    '                '    <input type="file" name="fileUpload" />
    '                '    <input type="submit" value="Upload" />
    '                '</form>

    '                ' this is because flash sends just the filename, where the above 
    '                'will send the file path, ie. c:\My Pictures\test1.jpg
    '                'you can use Test.thm to test this page.
    '                'string filename = uploadFile.FileName.Substring(uploadFile.FileName.LastIndexOf("\\"));
    '                'uploadFile.SaveAs(string.Format("{0}{1}{2}", tempFile, "Upload\\", filename));

    '                ' use this if using flash to upload

    '                ' HttpPostedFile has an InputStream also.  You can pass this to 
    '                ' a function, or business logic. You can save it a database:

    '                'byte[] fileData = new byte[uploadFile.ContentLength];
    '                'uploadFile.InputStream.Write(fileData, 0, fileData.Length);
    '                ' save byte array into database.

    '                ' something I do is extract files from a zip file by passing
    '                ' the inputStream to a function that uses SharpZipLib found here:
    '                ' http://www.icsharpcode.net/OpenSource/SharpZipLib/
    '                ' and then save the files to disk.                    
    '                uploadFile.SaveAs(Path.Combine(uploadPath, uploadFile.FileName))
    '            End If
    '        Next
    '    End If
    '    ' Used as a fix for a bug in mac flash player that makes the 
    '    ' onComplete event not fire
    '    HttpContext.Current.Response.Write(" ")
    'End Sub

    Protected Sub btnTransfer_Click(sender As Object, e As System.EventArgs) Handles btnTransfer.Click
        Dim litem As ListItem
        For i As Int16 = 0 To ChkEmpList.Items.Count - 1
            If ChkEmpList.Items(i).Selected = True Then
                litem = New ListItem(ChkEmpList.Items(i).Text, ChkEmpList.Items(i).Value)
                ChkDynamicListing.Items.Add(litem)
            End If
        Next
    End Sub
   
    Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        qry = "SELECT distinct empcode,empname+'~'+b.DEPTNAME FROM JCT_EmpMast_Base a,DEPTMAST b WHERE empname LIKE '%" & txtEmployee.Text & "%' AND Active='y' AND a.deptcode=b.DEPTCODE and empcode not in ('R-01111','U-04005')  ORDER BY empname+'~'+b.DEPTNAME"
        objFun.FillList(ChkEmpList, qry)
    End Sub

    Protected Sub cmdCC_Click(sender As Object, e As System.EventArgs) Handles cmdCC.Click
        Dim litem As ListItem
        For i As Int16 = 0 To ChkEmpList.Items.Count - 1
            If ChkEmpList.Items(i).Selected = True Then
                litem = New ListItem(ChkEmpList.Items(i).Text, ChkEmpList.Items(i).Value)
                chkNotify.Items.Add(litem)
            End If
        Next
    End Sub

   
    Protected Sub imgRemoveItem_Click(sender As Object, e As System.EventArgs) Handles imgRemoveItem.Click
     
        Dim i As Int16 = 0
        Dim CountItems As Int16 = ChkDynamicListing.Items.Count
        For i = 0 To CountItems - 1
            If CountItems > 0 Then
                If ChkDynamicListing.Items(i).Selected = True Then
                    ChkDynamicListing.Items.RemoveAt(i)
                    CountItems -= 1
                    Exit For
                End If
            End If
            'MsgBox("" & ChkUploadedItems.Items(i).ch)
        Next

        CountItems = 0
        CountItems = chkNotify.Items.Count
        For i = 0 To CountItems - 1
            If CountItems > 0 Then
                If chkNotify.Items(i).Selected = True Then
                    chkNotify.Items.RemoveAt(i)
                    CountItems -= 1
                    Exit For
                End If
            End If
            'MsgBox("" & ChkUploadedItems.Items(i).ch)
        Next

    End Sub

    Protected Sub ddlplant_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlplant.SelectedIndexChanged
        'qry = "SELECT upper(a.EmpCode) as EmpCode,c.Empname,a.UserLevel FROM dbo.Jct_Ops_SanctioNote_Area_Emp_Auth_Listing a,Jct_Ops_SanctioNote_Area_Master b,dbo.JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS='A' AND a.STATUS=b.STATUS AND c.empcode=a.empcode AND a.AreaCode=" & ddlarea.SelectedItem.Value & " and a.plant='" & ddlplant.SelectedItem.Text & "' ORDER BY UserLevel"
        'objFun.FillGrid(qry, GrdEmployee)
        ddlarea_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub cmdRetreive_Click(sender As Object, e As System.EventArgs) Handles cmdRetreive.Click
        qry = "SELECT AreaCode,AreaName FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' and parentarea=1015 and areacode IN (SELECT AreaCode FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" & txtImportSanctionNote.Text & "') "
        ddlarea.Items.Clear()
        objFun.FillList(ddlarea, qry)
        ddlarea_SelectedIndexChanged(sender, e)
        qry = "SELECT Val FROM Jct_Ops_SanctionNote_Dtl WHERE SanctionNoteID='" & txtImportSanctionNote.Text & "' ORDER BY ParamCode"
        With grdParameters
            For i As Int16 = 0 To .Rows.Count - 1
                qry = "SELECT Val FROM dbo.Jct_Ops_SanctionNote_Dtl WHERE SanctionNoteID='" & txtImportSanctionNote.Text & "' AND ParamCode='" & .Rows(i).Cells(0).Text & "' ORDER BY ParamCode"
                CType(.Rows(i).FindControl("txtValue"), TextBox).Text = objFun.FetchValue(qry)
            Next
        End With
        qry = "SELECT SUBJECT,DESCRIPTION FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" & txtImportSanctionNote.Text & "'"
        dr = objFun.FetchReader(qry)
        dr.Read()
        If dr.HasRows = True Then
            txtSubject.Text = dr.Item(0)
            txtDescription.Text = dr.Item(1)
        End If
        dr.Close()
    End Sub

    Protected Sub grdParameters_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdParameters.SelectedIndexChanged

    End Sub

    Protected Sub ddlValueList_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        ' qry = "SELECT upper(a.EmpCode) as EmpCode,c.Empname,a.UserLevel FROM dbo.Jct_Ops_SanctionNote_Area_Reason_Hiearchy a,Jct_Ops_SanctioNote_Area_Master b,dbo.JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS='A' AND a.STATUS=b.STATUS AND c.empcode=a.empcode AND a.AreaCode=" & ddlarea.SelectedItem.Value & " and a.plant='" & ddlplant.SelectedItem.Text & "' ORDER BY UserLevel"
        Dim Str As String = ""
        'Str=e.
        Dim ddl As DropDownList = CType(sender, DropDownList)
        Str = ddl.Text

     
        'Dim Tgr As AsyncPostBackTrigger = New AsyncPostBackTrigger



        'Tgr.ControlID = ddl.ID
        'Tgr.EventName = "SelectedIndexChanged"

        'UpdatePanel11.Triggers.Add(Tgr)
       
        qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy a ,Jct_Ops_SanctioNote_Area_Master b ,dbo.JCT_EmpMast_Base C WHERE   a.AreaCode = b.AreaCode AND a.STATUS = 'A' AND a.STATUS = b.STATUS AND c.empcode = a.empcode AND a.AreaCode = '" & ddlarea.SelectedItem.Value & "' AND a.plant = '" & ddlplant.SelectedItem.Text & "' AND ReasonCode='" & ddl.SelectedItem.Value & "' and a.eff_To is null ORDER BY AuthLevel"
        objFun.FillGrid(qry, GrdEmployee)
    End Sub
End Class
