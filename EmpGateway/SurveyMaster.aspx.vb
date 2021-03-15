Imports System.Data.SqlClient
Imports System.IO
Partial Class SurveyMaster
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Public SurveyNo, SurveyNo1 As Integer, MaxQuestNo, Quest_No As Integer
    Public Dt As Date
    Dim FName As String, Ext As String
    Dim Check As Integer, MinParam As Integer
    Dim FileToCopy As String, empcode As String
    Dim NewCopy As String ', ReplyBack As String, SurveyStatus As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SurveyNo = 0
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
            empcode = Session("Empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Me.OptionEdit.Checked = True Then
            Me.BtnAddParameter.Visible = False
            Me.Panel1.Visible = True
        Else
            Me.BtnAddParameter.Visible = True
            Me.Panel1.Visible = False
        End If

        If Not IsPostBack = True Then
            'MinParam = 1
            SurveyNo = 0
            obj.opencn()
            qry = "select deptcode,deptname from Deptmast where company_code='" & session("Companycode") & "' order by deptname"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    Me.DepList.Items.Add(dr(0) & " ~~ " & dr(1))
                End While
            End If
            dr.Close()
            obj.closecn()
            Dt = Now.Date()
            Dt = Dt.AddDays(30)
            Me.TXTLastDate.selecteddate = Dt
            '----------------------------------Reply
            Dim deptName As String
            If (Request.QueryString.Get("reply")) = 1 And (Request.QueryString.Get("Surveyno") > 0) Then 'Or Request.QueryString.Get("reply")) Then 'And (Request.QueryString.Get("task") = 1 Or Request.QueryString.Get("reply")) Then
                ImgNameLbL.Visible = True
                txtReason.Visible = True
                lblComents.Visible = True
                txtReason.Focus()
                ApplyBtn.Enabled = False
                CancleBtn.Enabled = False
                AuthBtn.Visible = True
                CancelAuthBtn.Visible = True
                obj.opencn()
                qry = "select dept_code,subject,Image_name,Last_date,confidential_flag,user_code from jct_emp_survey_Master where survey_no=" & Request.QueryString.Get("Surveyno") & " "
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                        Response.Write("<script>alert('No Survey For Authorization')</script>")
                    Else
                        deptName = dr(0)
                        txtSubject.Text = dr(1)
                        FileUpload1.Enabled = False
                        txtlastdate.SelectedDate = dr(3)
                        Session("UserCode") = dr(5)
                        txtSubject.Enabled = False
                        FileUpload1.Enabled = False
                        TXTLastDate.enabled = False
                        DrpConfidential.Enabled = False
                    End If
                Else
                    ' Response.Write("<script>alert('No Survey For Authorization')</script>")
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "No Survey For Authorization"
                    FMsg.Display()
                End If
                dr.Close()
                qry = "select deptcode,deptname from Deptmast where deptcode='" & deptName & "' order by deptname"
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                        Response.Write("<script>alert('No Survey For Authorization')</script>")
                    Else
                        Me.DepList.SelectedValue = dr(0) & " ~~ " & dr(1)

                        DepList.Enabled = False
                    End If
                Else
                End If
                dr.Close()

                qry = "select e_mailid from mistel where empcode='" & Session("UserCode") & "'"
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read()
                        Session("ReplyBack") = dr(0)
                    End While
                End If
                dr.Close()
                obj.closecn()

                '---------------------------------------
            End If
        End If

       
    End Sub

    Protected Sub ApplyBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplyBtn.Click
        Dim I As Integer, J As Integer, Seq As Integer
        Seq = 1
        Try
            If OptionCreate.Checked = True Then
                txtlastdate.Enabled = False
                DrpConfidential.Enabled = True
                txtReason.Enabled = True
                SaveRecords()
                ImageRename2()
                Quest()
                obj.opencn()

                'qry = "Insert into JCT_Emp_survey_Quest_Master(SURVEY_NO,QUEST_NO,QUEST,IMAGENAME,STATUS,EMPCODE) VALUES(" & SurveyNo & ",1,'" & Replace(TxtSurveyQuest.Text, "'", "''") & "','" & "Sur-" & SurveyNo & "Q No- " & MaxQuestNo & Ext & "','','" & Session("Empcode") & "')"
                'Above Commented and Below added by Neha on 29th March 2010 to add Ranking Qn Category
                Dim rate As Char
                If RblQnType.SelectedValue = "Single Selection" Then
                    rate = "N"
                ElseIf RblQnType.SelectedValue = "Multiple Selection" Then
                    rate = "M"
                ElseIf RblQnType.SelectedValue = "Ranking" Then
                    rate = "R"
                End If
                qry = "Insert into JCT_Emp_survey_Quest_Master(SURVEY_NO,QUEST_NO,QUEST,IMAGENAME,STATUS,EMPCODE,QnCatg,Remflag) VALUES(" & SurveyNo & ",1,'" & Replace(TxtSurveyQuest.Text, "'", "''") & "','" & "Sur-" & SurveyNo & "Q No- " & MaxQuestNo & Ext & "','','" & Session("Empcode") & "','" & rate & "','" & Trim(Me.RadioRemarksQuestion.SelectedValue.ToString) & "')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.ExecuteNonQuery()
                Seq = 1
                For J = 0 To LstChoiceList.Items.Count - 1

                    Dim remarks_option() As String = LstChoiceList.Items.Item(J).Text.Split("~~")
                    'If Left(LstChoiceList.Items.Item(J).Text, (InStr(LstChoiceList.Items.Item(J).Text, "Q NO - " & Seq) + Len(Seq.ToString) + 5)) = "Q NO - " & Seq Then
                    qry = "Insert into JCT_EMP_SURVEY_QUEST_PARAMETER(SURVEY_NO,QUEST_NO,PARAMETERNAME,SEQUENCE_NO,Reamflag) VALUES(" & SurveyNo & "," & MaxQuestNo & ",'" & Replace(Right(LstChoiceList.Items.Item(J).Text, Len(LstChoiceList.Items.Item(J).Text) - Len(Seq.ToString) - 7), "'", "''") & "'," & Seq & ",'" & remarks_option(1) & "')"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.ExecuteNonQuery()
                    Seq = Seq + 1
                    'End If
                Next J
                obj.closecn()
                Reset()
            ElseIf OptionUpload.Checked = True Then
                SaveRecords()
                Reset()
            ElseIf OptionAddQuest.Checked = True Then
                txtlastdate.Enabled = True
                DrpConfidential.Enabled = False
                txtReason.Enabled = False
                Quest()
                'LstMultiQuest.Visible = True

                ImageRename2()
                obj.opencn()
                qry = "select survey_no from jct_emp_survey_master where user_code='" & Session("Empcode") & "' and subject='" & CboQuestions.SelectedValue & "' "
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read()
                        SurveyNo = dr(0)
                    End While
                End If
                dr.Close()

                'qry = "Insert into JCT_Emp_survey_Quest_Master(SURVEY_NO,QUEST_NO,QUEST,IMAGENAME,STATUS,empcode) VALUES(" & SurveyNo & "," & MaxQuestNo & ",'" & TxtSurveyQuest.Text & "','" & "Sur-" & SurveyNo & "Q No- " & MaxQuestNo & Ext & "','','" & Session("Empcode") & "')"
                'Above Commented and Below added by Neha on 29th March 2010 to add Ranking Qn Category
                Dim rate As Char
                If RblQnType.SelectedValue = "Single Selection" Then
                    rate = "N"
                ElseIf RblQnType.SelectedValue = "Multiple Selection" Then
                    rate = "M"
                ElseIf RblQnType.SelectedValue = "Ranking" Then
                    rate = "R"
                End If
                qry = "Insert into JCT_Emp_survey_Quest_Master(SURVEY_NO,QUEST_NO,QUEST,IMAGENAME,STATUS,empcode, QnCatg,Remflag) VALUES(" & SurveyNo & "," & MaxQuestNo & ",'" & Replace(TxtSurveyQuest.Text, "'", "''") & "','" & "Sur-" & SurveyNo & "Q No- " & MaxQuestNo & Ext & "','','" & Session("Empcode") & "','" & rate & "','" & Me.RadioRemarksQuestion.SelectedValue.ToString & "')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.ExecuteNonQuery()
                Seq = 1
                For J = 0 To LstChoiceList.Items.Count - 1
                    Dim remarks_option1() As String = LstChoiceList.Items.Item(J).Text.Split("~~")
                    qry = "Insert into JCT_EMP_SURVEY_QUEST_PARAMETER(SURVEY_NO,QUEST_NO,PARAMETERNAME,SEQUENCE_NO,Remflag) VALUES(" & SurveyNo & "," & MaxQuestNo & ",'" & Replace(Right(LstChoiceList.Items.Item(J).Text, Len(LstChoiceList.Items.Item(J).Text) - Len(Seq.ToString) - 7), "'", "''") & "'," & Seq & ",'" & remarks_option1(1) & "')"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.ExecuteNonQuery()
                    Seq = Seq + 1
                Next J
                obj.closecn()
                FMsg.CssClass = "addmsg"
                FMsg.Message = "Inserted Successfully !!!!!"
                FMsg.Display()
                Reset()
            ElseIf Me.OptionEdit.Checked = True Then

                obj.opencn()

                If Me.LstMultiQuest.SelectedIndex >= 0 Or Me.TxtSurveyQuest.Text <> "" Then
                    Dim quest_no() As String = Me.LstMultiQuest.SelectedItem.Text.Split("-")
                    qry = "update JCT_Emp_survey_Quest_Master set quest='" & Replace(Trim(Me.TxtSurveyQuest.Text), "'", "''") & "', remflag='" & Me.RadioRemarksQuestion.SelectedValue.ToString & "' where survey_no=" & ViewState("SurveyNo") & " and quest_no=" & quest_no(0) & " and empcode='" & Session("Empcode") & "'"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.ExecuteNonQuery()
                End If

                '--------Update Choices-----------------------------
                If Me.LstChoiceList.SelectedIndex >= 0 Or Me.TxtChoice.Text <> "" Then
                    Dim quest_no() As String = Me.LstMultiQuest.SelectedItem.Text.Split("-")
                    Dim choice_no() As String = Me.LstChoiceList.SelectedItem.Text.Split("#")
                    qry = "update JCT_EMP_SURVEY_QUEST_PARAMETER set parametername='" & Replace(Trim(Me.TxtChoice.Text), "'", "''") & "' , remflag='" & Me.RadioRemarksOption.SelectedValue.ToString & "'  where survey_no=" & ViewState("SurveyNo") & " and quest_no=" & quest_no(0) & " and sequence_no='" & choice_no(0) & "'"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.ExecuteNonQuery()
                End If

                '--------------------
                If Me.RadioButtonList1.SelectedValue.ToString = "Y" Then
                    Me.CboQuestions_SelectedIndexChanged(sender, e)
                    Me.TxtSurveyQuest.Text = ""
                Else

                End If
               
                '----------------------
                Dim Selected_Quest() As String = Me.LstMultiQuest.SelectedItem.Text.Split("-")
                Me.TxtSurveyQuest.Text = Selected_Quest(1)

                '-------Get options related to selected question------------
                LstChoiceList.Items.Clear()
                obj.opencn()
                qry = "select sequence_no,parametername from JCT_EMP_SURVEY_QUEST_PARAMETER where survey_no=" & ViewState("SurveyNo") & " and quest_no='" & Selected_Quest(0) & "'  order by quest_no"
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read()
                        If Me.OptionEdit.Checked = True Then
                            LstChoiceList.Items.Add(dr(0) & "#" & dr(1))
                        End If
                        LstChoiceList.Visible = True
                        TxtChoice.Text = ""
                    End While
                    dr.Close()
                End If

                '----------------------
                Me.TxtChoice.Text = ""
                obj.closecn()
                FMsg.CssClass = "addmsg"
                FMsg.Message = "Updated Successfully !!!!!"
                FMsg.Display()
            End If

            'If Check = 1 Then Reset()
        Catch exp As Exception
            Response.Write(exp.ToString())
        End Try
    End Sub
    Public Function Quest()
        obj.opencn()
        qry = "select max(a.quest_no),max(b.survey_no) from jct_emp_survey_quest_master a,jct_emp_survey_master b where a.survey_no=b.survey_no and a.empcode='" & Session("Empcode") & "' and b.subject='" & Replace(CboQuestions.SelectedValue, "'", "''") & "'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                MaxQuestNo = 1
            Else
                MaxQuestNo = dr(0) + 1
                SurveyNo = dr(1)
            End If
        Else
            MaxQuestNo = 1
        End If

        dr.Close()
        obj.closecn()
    End Function
    Protected Sub CancleBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancleBtn.Click
        Reset()
    End Sub
    Private Sub Reset()
        Me.txtSubject.Text = ""
        TXTLastDate.selecteddate = now.date()
        Me.ImgNameLbL.Text = "Image Name"
        Me.txtReason.Text = ""
        Me.TxtSurveyQuest.Text = ""
        Me.LstChoiceList.Items.Clear()
    End Sub
    Public Function fill()
        If Trim(Me.txtSubject.Text) = "" Then
            Response.Write("<script>alert('Please enter Subject of Survey!!')</script>")
            Me.txtSubject.Focus()
            fill = 1
            Exit Function
        End If
        If OptionUpload.Checked = False Then
            If Trim(Me.LstChoiceList.Items.Count) = "0" Then
                Response.Write("<script>alert('Please Make a selection from Parameters of Survey!!')</script>")
                Me.txtSubject.Focus()
                fill = 1
                Exit Function
            End If
        End If
        If CDate(Trim(TXTLastDate.selecteddate)) <= Now.Date Then
            Response.Write("<script>alert('Invalid Date !!')</script>")
            Me.txtSubject.Focus()
            fill = 1
            Exit Function
        End If
    End Function
    Function ThumbnailCallback() As Boolean
        Return False
    End Function
    Public Sub GetImageResized()
        Dim dummyCallBack As System.Drawing.Image.GetThumbnailImageAbort
        dummyCallBack = New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
        Dim fullSizeImg As System.Drawing.Image
        fullSizeImg = System.Drawing.Image.FromFile(FileUpload1.PostedFile.FileName)
        Dim thumbNailImg As System.Drawing.Image
        thumbNailImg = fullSizeImg.GetThumbnailImage(800, 800, dummyCallBack, IntPtr.Zero)
        thumbNailImg.Save(Server.MapPath("~\EmpGateway\Survey\Sur-") & SurveyNo & Ext)
        'NewCopy = "D:/WebApplications/EmpGateway/Survey/Sur-" & SurveyNo & Ext
    End Sub
    Public Sub SendMail(ByVal From As String, ByVal Too As String)
        Dim MailSmpt As New Mail.MailMessage

        With MailSmpt
            obj.opencn()
            qry = "select e_mailid from mistel where empcode='" & Session("Empcode") & "'"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                    .From = From '"dummy@jctltd.com"
                Else
                    .From = dr.Item(0)
                End If
            Else
                .From = From '"dummy@jctltd.com"
            End If
            dr.Close()
            obj.closecn()
            .To = Trim(Too) '"neha.srivastava@jctltd.com" '"rbaksshi@jctltd.com"
            '.Bcc = "rbaksshi@jctltd.com"
            'Modify Person:- Kulwinder Date:- 5/May/2009 
            'Added Disclaimer in body tag
            If Session("ReplyBack") = "" Then
                .Body = Session("empname") & " has added a Survey with Subject: " & Me.txtSubject.Text & vbCrLf & "Needs Your Authorization !!!!" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
            Else
                If Session("SurveyStatus") = "A" Then
                    .Body = Session("empname") & " has authorized your Survey with Subject: " & Me.txtSubject.Text & vbCrLf & " His/Her Remarks are :-" & txtReason.Text & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
                Else
                    .Body = Session("empname") & " has Cancled your Survey with Subject: " & Me.txtSubject.Text & vbCrLf & " His/Her Remarks are :-" & txtReason.Text & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
                End If
                .Subject = "Survey Authorized By" & Session("empname") & " of " & Session("Deptname") & " department"
            End If

            Mail.SmtpMail.SmtpServer = "exchange2007"
            Mail.SmtpMail.Send(MailSmpt)
            MailSmpt = Nothing
        End With

    End Sub

    Protected Sub AuthBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AuthBtn.Click
        If Trim(Me.txtReason.Text) = "" Then
            Response.Write("<script>alert('Please Give Reason behind Rejection ??')</script>")
            Me.txtReason.Focus()
            Exit Sub
        Else
            obj.opencn()
            Session("SurveyStatus") = "A"
            qry = "update jct_emp_survey_master set auth_flag='A',auth_by='" & Session("Empcode") & "',auth_date=getdate(),Reason='" & txtReason.Text & "' where survey_no=" & Request.QueryString.Get("Surveyno") & ""
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            'SendMail("dummy@jctltd.com", Session("ReplyBack"))
            SendMail("dummy@jctltd.com", Session("ReplyBack"))
            AuthBtn.Enabled = False
            CancelAuthBtn.Enabled = False
            'Response.Write("<script>alert('Survey Authorized')</script>")
            FMsg.CssClass = "addmsg"
            FMsg.Message = "Survey Authorized !!!!!"
            FMsg.Display()
            Reset()
        End If
        'AuthSurvey()

    End Sub

    Protected Sub CancelAuthBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelAuthBtn.Click
        'Two Authorization flaga are used A:-Authorized and C:-Cancled
        If Trim(Me.txtReason.Text) = "" Then
            'Response.Write("<script>alert('Please Give Reason behind Rejection ??')</script>")
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Please Give Reason behind Rejection ?? !!!!!"
            FMsg.Display()
            Me.txtReason.Focus()
            Exit Sub
        Else
            obj.opencn()
            Session("SurveyStatus") = "C"
            'SendMail("dummy@jctltd.com", Session("ReplyBack"))
            SendMail("dummy@jctltd.com", Session("ReplyBack"))
            qry = "update jct_emp_survey_master set auth_flag='C',auth_by='" & Session("Empcode") & "',auth_date=getdate(),ReasonFor='" & txtReason.Text & "' where survey_no=" & Request.QueryString.Get("Surveyno") & ""
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            'Response.Write("<script>alert('Surey Authorization Rejected')</script>")
            AuthBtn.Enabled = False
            CancelAuthBtn.Enabled = False
            'Response.Write("<script>alert('Surey Cancled')</script>")
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Surey Cancled ?? !!!!!"
            FMsg.Display()
            Reset()
        End If
    End Sub


    Protected Sub BtnNewQuest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNewQuest.Click
        'If MinParam >= 2 Then
        If Trim(TxtSurveyQuest.Text) <> "" Then

            'LstMultiQuest.Items.Add(TxtSurveyQuest.Text)
            'LstMultiQuest.Visible = True
            txtSubject.Text = ""
            'txtSubject.Focus()
            TxtChoice.Focus()
            BtnNewQuest.Enabled = False
            BtnAddParameter.Enabled = True
            TxtChoice.Enabled = True
        Else
            ' Response.Write("<script>alert('Cannot Add Empty Question')</script>")
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Cannot Add Empty Question !!!!!"
            FMsg.Display()
        End If
        'Else
        '    Response.Write("<script>alert('Invalid Parameter List For Current Question')</script>")
        'End If
    End Sub
    Protected Sub BtnAddParameter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddParameter.Click
        'MinParam = 0
        If Trim(TxtChoice.Text) <> "" Then
            Quest()
            Session("minparam") = Session("minparam") + 1
            LstChoiceList.Items.Add("Q NO - " & MaxQuestNo & TxtChoice.Text & "~~" & Me.RadioRemarksOption.SelectedValue.ToString)
            LstChoiceList.Visible = True
            TxtChoice.Text = ""
            TxtChoice.Focus()
            If Session("minparam") >= 2 Then
                BtnNewQuest.Enabled = True
                Session("minparam") = 0
            End If
        Else
            'MinParam = 2
            ' Response.Write("<script>alert('Cannot Add Empty Parameter')</script>")
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Cannot Add Empty Question !!!!!"
            FMsg.Display()
        End If
    End Sub
    Public Sub SaveRecords()
        Check = fill()
        If Check = 1 Then Exit Sub
        FName = Trim(FileUpload1.FileName)
        If FName <> "" Then
            ImgNameLbL.Text = FName
            Ext = Trim(Right(FileUpload1.FileName, 4))
        Else
            ImgNameLbL.Text = "No Image Selected"
            Ext = "No Image"
        End If
        'If lcase(Ext) = ".jpg" Or lcase(Ext) = ".ipg" Or Ext = ".bmp" Or Ext = ".png" Or Ext = ".gif" Or Ext = ".jpeg"   Then
        If LCase(Ext) = ".jpg" Or LCase(Ext) = ".ipg" Or LCase(Ext) = ".bmp" Or LCase(Ext) = ".png" Or LCase(Ext) = ".gif" Or LCase(Ext) = ".jpeg" Then
            obj.opencn()
            qry = "select max(survey_no) from jct_emp_survey_Master"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                    SurveyNo = 1
                Else
                    SurveyNo = dr(0) + 1
                End If
            Else
                SurveyNo = 1
            End If
            dr.Close()
            If Trim(TXTLastDate.selecteddate) <> "" Then
                If OptionCreate.Checked = True Then
                    qry = "insert into JCT_Emp_survey_Master(Company_Code,User_Code,Dept_Code,Subject,Image_Name,Last_Date,status,survey_no,Auth_Flag,Auth_Date,Auth_By,Confidential_Flag,Reason,Flag) values ('JCT00LTD','" & Session("Empcode") & "','" & Left(DepList.Text, 4) & "','" & Replace(txtSubject.Text, "'", "''") & "','" & FName & "','" & txtlastdate.SelectedDate & "',''," & Me.SurveyNo & ",'U',null,'','" & Left(DrpConfidential.SelectedValue, 1) & "','','S')"
                ElseIf OptionUpload.Checked = True Then
                    qry = "insert into JCT_Emp_survey_Master(Company_Code,User_Code,Dept_Code,Subject,Image_Name,Last_Date,status,survey_no,Auth_Flag,Auth_Date,Auth_By,Confidential_Flag,Reason,Flag) values ('JCT00LTD','" & Session("Empcode") & "','" & Left(DepList.Text, 4) & "','" & Replace(txtSubject.Text, "'", "''") & "','" & FName & "','" & txtlastdate.SelectedDate & "',''," & Me.SurveyNo & ",'U',null,'','" & Left(DrpConfidential.SelectedValue, 1) & "','','R')"
                End If
            ElseIf Trim(TXTLastDate.selecteddate) = "" Then
                If OptionCreate.Checked = True Then
                    qry = "insert into JCT_Emp_survey_Master(Company_Code,User_Code,Dept_Code,Subject,Image_Name,Last_Date,status,survey_no,Auth_Flag,Auth_Date,Auth_By,Confidential_Flag,Reason,Flag) values ('JCT00LTD','" & Session("Empcode") & "','" & Left(DepList.Text, 4) & "','" & Replace(txtSubject.Text, "'", "''") & "','" & FName & "','" & Dt & "',''," & SurveyNo & ",'U',null,'','" & Left(DrpConfidential.SelectedValue, 1) & "','','S')"
                Else
                    qry = "insert into JCT_Emp_survey_Master(Company_Code,User_Code,Dept_Code,Subject,Image_Name,Last_Date,status,survey_no,Auth_Flag,Auth_Date,Auth_By,Confidential_Flag,Reason,Flag) values ('JCT00LTD','" & Session("Empcode") & "','" & Left(DepList.Text, 4) & "','" & Replace(txtSubject.Text, "'", "''") & "','" & FName & "','" & Dt & "',''," & SurveyNo & ",'U',null,'','" & Left(DrpConfidential.SelectedValue, 1) & "','','R')"
                End If
            End If
            '        End If
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            If FName <> "" Then
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~\EmpGateway\Survey\") + FName)
                'GetImageResized()
            End If
            ImageRename()
            obj.opencn()
            qry = "update jct_emp_survey_Master set Image_name='" & "Sur-" & SurveyNo & Ext & "' where survey_no=" & SurveyNo & ""
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendMail("dummy@jctltd.com", "rbaksshi@jctltd.com")
            'SendMail("dummy@jctltd.com", "test@jctltd.com")
            Response.Write("<script>alert('Survey Created')</script>")

        ElseIf Ext = "No Image" Then
            'Try
            obj.opencn()
            qry = "select max(survey_no) from jct_emp_survey_Master"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                    SurveyNo = 1
                Else
                    SurveyNo = dr(0) + 1
                End If
            Else
                SurveyNo = 1
            End If
            dr.Close()

            If Trim(txtlastdate.SelectedDate) <> "" Then
                If OptionCreate.Checked = True Then
                    qry = "insert into JCT_Emp_survey_Master(Company_Code,User_Code,Dept_Code,Subject,Image_Name,Last_Date,status,survey_no,Auth_Flag,Auth_Date,Auth_By,Confidential_Flag,Reason,Flag) values ('JCT00LTD','" & Session("Empcode") & "','" & Left(DepList.Text, 4) & "','" & Replace(txtSubject.Text, "'", "''") & "','','" & txtlastdate.SelectedDate & "',''," & Me.SurveyNo & ",'U',null,'','" & Left(DrpConfidential.SelectedValue, 1) & "','','S')"
                ElseIf OptionUpload.Checked = True Then
                    qry = "insert into JCT_Emp_survey_Master(Company_Code,User_Code,Dept_Code,Subject,Image_Name,Last_Date,status,survey_no,Auth_Flag,Auth_Date,Auth_By,Confidential_Flag,Reason,Flag) values ('JCT00LTD','" & Session("Empcode") & "','" & Left(DepList.Text, 4) & "','" & Replace(txtSubject.Text, "'", "''") & "','','" & txtlastdate.SelectedDate & "',''," & Me.SurveyNo & ",'U',null,'','" & Left(DrpConfidential.SelectedValue, 1) & "','','R')"
                End If
            ElseIf Trim(txtlastdate.SelectedDate) = "" Then
                If OptionCreate.Checked = True Then
                    qry = "insert into JCT_Emp_survey_Master(Company_Code,User_Code,Dept_Code,Subject,Image_Name,Last_Date,status,survey_no,Auth_Flag,Auth_Date,Auth_By,Confidential_Flag,Reason, Flag) values ('JCT00LTD','" & Session("Empcode") & "','" & Left(DepList.Text, 4) & "','" & Replace(txtSubject.Text, "'", "''") & "','','" & Dt & "',''," & SurveyNo & ",'U',null,'','" & Left(DrpConfidential.SelectedValue, 1) & "','','S')"
                ElseIf OptionUpload.Checked = True Then
                    qry = "insert into JCT_Emp_survey_Master(Company_Code,User_Code,Dept_Code,Subject,Image_Name,Last_Date,status,survey_no,Auth_Flag,Auth_Date,Auth_By,Confidential_Flag,Reason, Flag) values ('JCT00LTD','" & Session("Empcode") & "','" & Left(DepList.Text, 4) & "','" & Replace(txtSubject.Text, "'", "''") & "','','" & Dt & "',''," & SurveyNo & ",'U',null,'','" & Left(DrpConfidential.SelectedValue, 1) & "','','R')"
                End If
            End If
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            'SendMail("dummy@jctltd.com", "neha.srivastava@jctltd.com")
            'SendMail("dummy@jctltd.com", "test@jctltd.com")
            SendMail("dummy@jctltd.com", "rbaksshi@jctltd.com")
            'Catch exp As Exception
            'Response.Write(exp.ToString())
            'End Try
        Else
            'Response.Write("<script>alert('Not A Valid Image File!!')</script>")
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Not A Valid Image File !!!!!"
            FMsg.Display()
        End If
        '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "m", "confirm('Do You Want To Add More Questions To The Survey?')", True)
    End Sub
    Public Sub ImageRename()
        'Edited By Neha on 26th March 2010 to give relative path
        FileToCopy = Server.MapPath("~\EmpGateway\Survey\" + FName) '"D:/WebApplications/EmpGateway/Survey/" + FName
        NewCopy = Server.MapPath("~\EmpGateway\Survey\" & "Sur-" & SurveyNo & Ext) '"D:/WebApplications/EmpGateway/Survey/" & "Sur-" & SurveyNo & Ext
        '''''''''''             Ends Here
        If System.IO.File.Exists(FileToCopy) = True Then
            System.IO.File.Copy(FileToCopy, NewCopy)
        End If
        Dim FileToDelete As String
        FileToDelete = FileToCopy
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
    End Sub


    Protected Sub OptionAddQuest_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptionAddQuest.CheckedChanged
        Reset()
        Label2.Visible = True
        TxtSurveyQuest.Visible = True
        TxtChoice.Visible = True
        Dt = Now.Date()
        Dt = Dt.AddDays(30)
        TXTLastDate.selecteddate = Dt
        DrpConfidential.Enabled = False
        TXTLastDate.enabled = False
        CboQuestions.Visible = True
        txtSubject.Visible = False
        obj.opencn()
        CboQuestions.Items.Clear()
        qry = "select subject from jct_emp_survey_Master where user_code='" & Session("Empcode") & "' and dept_code='" & Left(DepList.Text, 4) & "' and auth_flag='U'  order by subject"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                CboQuestions.Items.Add(dr(0))
                CboQuestions.Visible = True
            End While
        End If
        dr.Close()
        obj.closecn()
    End Sub

    Protected Sub OptionUpload_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptionUpload.CheckedChanged
        Label2.Visible = False
        TxtSurveyQuest.Visible = False
        TxtChoice.Visible = False
        LstChoiceList.Visible = False
        Dt = Now.Date()
        Dt = Dt.AddDays(30)
        TXTLastDate.selecteddate = Dt
        CboQuestions.Visible = False
        txtSubject.Visible = True
    End Sub

    Protected Sub OptionCreate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptionCreate.CheckedChanged
        Label2.Visible = True
        TxtSurveyQuest.Visible = True
        TxtChoice.Visible = True
        Dt = Now.Date()
        Dt = Dt.AddDays(30)
        TXTLastDate.selecteddate = Dt
        DrpConfidential.Enabled = True
        TXTLastDate.enabled = True
        CboQuestions.Visible = False
        txtSubject.Visible = True
    End Sub

    Protected Sub CboQuestions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboQuestions.SelectedIndexChanged
        obj.opencn()
        LstMultiQuest.Items.Clear()
        qry = "select a.Quest,b.survey_no, QnCatg,quest_no from jct_emp_survey_Quest_Master a, jct_emp_survey_master b where b.survey_no=a.survey_no and a.empcode='" & Session("Empcode") & "' and b.subject='" & CboQuestions.SelectedValue & "'  order by a.quest_no"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If Me.OptionEdit.Checked = True Then
                    LstMultiQuest.Items.Add(dr(3) & "-" & dr(0))
                Else
                    LstMultiQuest.Items.Add(dr(0))
                End If
                SurveyNo = dr(1)
                Me.ViewState.Add("SurveyNo", dr(1))
                LstMultiQuest.Visible = True
                LstChoiceList.Items.Clear()
                TxtChoice.Text = ""
                If dr(2) = "N" Then
                    RblQnType.SelectedIndex = 0
                ElseIf dr(2) = "M" Then
                    RblQnType.SelectedIndex = 1
                ElseIf dr(2) = "R" Then
                    RblQnType.SelectedIndex = 2
                End If
            End While
        Else
            LstMultiQuest.Visible = False
        End If
        dr.Close()
        obj.closecn()

    End Sub
    Public Sub ImageRename2()
        Quest()
        FName = Trim(FileUpload1.FileName)
        If FName <> "" Then
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~\EmpGateway\Survey\") + FName)
        End If
        If FName <> "" Then
            ImgNameLbL.Text = FName
            Ext = Trim(Right(FileUpload1.FileName, 4))
        Else
            ImgNameLbL.Text = "No Image Selected"
            Ext = "No Image"
        End If
        If Ext = ".jpg" Or Ext = ".ipg" Or Ext = ".bmp" Or Ext = ".png" Or Ext = ".gif" Or Ext = ".jpeg" Then
            FileToCopy = Server.MapPath("~\EmpGateway\Survey\") + FName
            NewCopy = Server.MapPath("~\EmpGateway\Survey\") & "Sur-" & SurveyNo & "Q No- " & MaxQuestNo & Ext
            If System.IO.File.Exists(FileToCopy) = True Then
                If System.IO.File.Exists(NewCopy) <> True Then
                    System.IO.File.Copy(FileToCopy, NewCopy)
                End If
            End If
            Dim FileToDelete As String
            FileToDelete = FileToCopy
            If System.IO.File.Exists(FileToDelete) = True Then
                System.IO.File.Delete(FileToDelete)
            End If
        Else
            'Response.Write("<script>'Not A Valid Image File'</script>")
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Not A Valid Image File"
            FMsg.Display()
        End If
    End Sub
    Protected Sub DepList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepList.SelectedIndexChanged
        If OptionCreate.Checked = True Then
            OptionCreate_CheckedChanged(sender, Nothing)
        ElseIf OptionAddQuest.Checked = True Then
            OptionAddQuest_CheckedChanged(sender, Nothing)
        Else
            OptionUpload_CheckedChanged(sender, Nothing)
        End If
    End Sub
    Protected Sub RadioRemarksQuestion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioRemarksQuestion.SelectedIndexChanged
        If Me.RadioRemarksQuestion.Items(0).Selected = True Then
            Me.RadioRemarksOption.Items(0).Selected = True
            Me.RadioRemarksOption.Items(1).Selected = False
            Me.RadioRemarksOption.Enabled = False

        Else
            Me.RadioRemarksOption.Items(0).Selected = False
            Me.RadioRemarksOption.Items(1).Selected = True
            Me.RadioRemarksOption.Enabled = True
        End If
    End Sub

    Protected Sub LstMultiQuest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstMultiQuest.SelectedIndexChanged

        Dim Selected_Quest() As String = Me.LstMultiQuest.SelectedItem.Text.Split("-")
        Me.TxtSurveyQuest.Text = Selected_Quest(1)

        '-------Get options related to selected question------------
        LstChoiceList.Items.Clear()
        obj.opencn()
        qry = "select sequence_no,parametername from JCT_EMP_SURVEY_QUEST_PARAMETER where survey_no=" & ViewState("SurveyNo") & " and quest_no='" & Selected_Quest(0) & "'  order by quest_no"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If Me.OptionEdit.Checked = True Then
                    LstChoiceList.Items.Add(dr(0) & "#" & dr(1))
                End If
                LstChoiceList.Visible = True
                TxtChoice.Text = ""
            End While
            dr.Close()
        End If

        '-------------------Get Remarks Flag of selected question-----------

        qry = "select Remflag from  jct_emp_survey_Quest_Master where survey_no=" & ViewState("SurveyNo") & " and quest_no='" & Selected_Quest(0) & "'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then

            While dr.Read()
                If dr(0) = "Y" Then
                    Me.RadioRemarksQuestion.Items(0).Selected = True
                    Me.RadioRemarksQuestion.Items(1).Selected = False
                Else
                    Me.RadioRemarksQuestion.Items(1).Selected = True
                    Me.RadioRemarksQuestion.Items(0).Selected = False
                End If
            End While

            dr.Close()
        End If
        '--------------------------------------------------
        RadioRemarksQuestion_SelectedIndexChanged(sender, e)
        '--------------------------------------------------
        obj.closecn()
        '--------------------------------------------------

    End Sub
    Protected Sub OptionEdit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptionEdit.CheckedChanged
        Reset()
        Label2.Visible = True
        TxtSurveyQuest.Visible = True
        TxtChoice.Visible = True
        Dt = Now.Date()
        Dt = Dt.AddDays(30)
        txtlastdate.SelectedDate = Dt
        DrpConfidential.Enabled = False
        txtlastdate.Enabled = False
        CboQuestions.Visible = True
        txtSubject.Visible = False
        obj.opencn()
        CboQuestions.Items.Clear()
        qry = "select subject from jct_emp_survey_Master where user_code='" & Session("Empcode") & "' and dept_code='" & Left(DepList.Text, 4) & "' and auth_flag='U'  order by subject"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                CboQuestions.Items.Add(dr(0))
                CboQuestions.Visible = True
            End While
        End If
        dr.Close()
        obj.closecn()
        CboQuestions_SelectedIndexChanged(sender, Nothing)
    End Sub
    Protected Sub LstChoiceList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstChoiceList.SelectedIndexChanged
        Dim Selected_Choice() As String = Me.LstChoiceList.SelectedItem.Text.Split("#")
        Me.TxtChoice.Text = Selected_Choice(1)
        '--------Update Choices-----------------------------

        Dim quest_no() As String = Me.LstMultiQuest.SelectedItem.Text.Split("-")
        Dim choice_no() As String = Me.LstChoiceList.SelectedItem.Text.Split("#")

        obj.opencn()

        qry = "select Remflag from JCT_EMP_SURVEY_QUEST_PARAMETER  where survey_no=" & ViewState("SurveyNo") & " and quest_no=" & quest_no(0) & " and sequence_no='" & choice_no(0) & "'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If dr(0) IsNot DBNull.Value Then
                    If dr(0) = "Y" Then
                        Me.RadioRemarksOption.Items(0).Selected = True
                        Me.RadioRemarksOption.Items(1).Selected = False
                    Else
                        Me.RadioRemarksOption.Items(1).Selected = True
                        Me.RadioRemarksOption.Items(0).Selected = False
                    End If
                End If
              
            End While
        End If

        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedValue.ToString = "Y" Then
            TxtSurveyQuest.Enabled = True
        Else
            TxtSurveyQuest.Enabled = False
        End If

    End Sub
End Class
