Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Image
Imports System.Drawing.Imaging
Partial Class Survey
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    '----------------
    Public SurveyNo As Integer, TransNo As Integer, Check As Integer, MaxQestNo As Integer, MinQestNo As Integer
    Dim I As Integer, CurQuest As Integer
    Public UserChoice(1) As String

    Dim Fname As String, Conf_Flag As String, empcode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack = True Then

            Me.CollapsablePanel1.Collapsed = True

            GetSurvey()
            SurveyList_SelectedIndexChanged(sender, Nothing)
            LstType_SelectedIndexChanged(sender, Nothing)
            

        End If
        'If Session("Empcode") = "N-02632" Then
        '    lblSurveyType.Visible = True
        '    LstType.Visible = True
        '    Label7.Visible = True
        '    txtSearch.Visible = True
        '    LstName.Visible = True
        'End If
        
    End Sub

    Protected Sub ApplyBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplyBtn.Click
        If RdoList.Items.Count > 0 Then
            If RdoList.SelectedValue = "" Then
                Response.Write("<script>alert('Please make your choice! Before Proceeding Further..')</script>")
                Exit Sub
            End If
        End If

        If Check = 1 Then Exit Sub
        'Commented By Neha on 29th March 2010 as this is not required. we already have survey No in Dropdown
        'obj.opencn()
        'qry = "select survey_no from jct_emp_survey_Master where Subject='" & SurveyList.SelectedItem.Text & "' "
        'cmd = New SqlCommand(qry, obj.cn)
        'dr = cmd.ExecuteReader
        'If dr.HasRows = True Then
        '    dr.Read()
        '    If dr.Item(0) Is System.DBNull.Value Then
        '        Response.Write("<script>alert('Invalid Survey Name Selected!!')</script>")
        '        Exit Sub
        '    Else
        '        SurveyNo = dr(0)
        '    End If
        'Else
        '    SurveyNo = 0
        'End If
        'dr.Close()
        'obj.closecn()
        'obj.opencn()

        SurveyNo = SurveyList.SelectedValue
        obj.opencn()
        qry = "select max(Trans_No) from Jct_Emp_Survey_Trans"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                TransNo = 1
            Else
                TransNo = dr(0) + 1
            End If
        Else
            TransNo = 1
        End If
        dr.Close()
        obj.closecn()


        Dim qn, Pm As Boolean
        obj.opencn()
        qry = "select * from JCT_EMP_SURVEY_QUEST_MASTER where survey_no=" & SurveyNo & " and quest_no=" & lblQno.Text & " and remflag='y'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            qn = True
        Else
            qn = False
        End If
        dr.Close()
        obj.opencn()
        qry = "select * from JCT_EMP_SURVEY_QUEST_parameter where survey_no=" & SurveyNo & " and quest_no=" & lblQno.Text & " and parametername = '" & RdoList.SelectedValue & "' and remflag='y'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            Pm = True
        Else
            Pm = False
        End If
        dr.Close()
        If (qn = True Or Pm = True) And Trim(Me.txtComents.Text) = "" Then
            Response.Write("<script>alert('Please Add your Comments in Comment Box. It is mandatory!!')</script>")
            Exit Sub
        End If

        If SurveyNo > "0" Then
            obj.opencn()
            'If Session("Empcode") = "N-02632" Then
            'qry = "Insert into jct_emp_survey_Trans(CompanyCode,UserCode,RatedOn,Rating,Coments,SurveyNo,status,Flag,Trans_No,quest_no) values('JCT00LTD','" & txtSearch.Text & "',getdate(),'" & RdoList.SelectedValue & "','" & txtComents.Text & "'," & SurveyNo & ",'',''," & TransNo & "," & Session("CurQuest") & ")"
            'Else
            'Added By Neha on 29th March 2010 to facilitate Survey screen to select Multiple Options and also to handle Ranking Questions
            If Label3.Text = "Arrange These" Then
                For sq = 0 To RdoList.Items.Count - 1

                    qry = "Insert into jct_emp_survey_Trans(CompanyCode,UserCode,RatedOn,Rating,Coments,SurveyNo,status,Flag,Trans_No,quest_no, ParameterSeqNo) values('JCT00LTD','" & Session("Empcode") & "',getdate(),'" & sq + 1 & "','" & Replace(txtComents.Text, "'", "''") & "'," & SurveyNo & ",'',''," & TransNo & "," & lblQno.Text & "," & RdoList.Items(sq).Value & " )"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.ExecuteNonQuery()

                Next
            ElseIf Label3.Text = "Check Choice(s)" Then
                For sq = 0 To ChkList.Items.Count - 1
                    If ChkList.Items(sq).Selected = True Then
                        qry = "Insert into jct_emp_survey_Trans(CompanyCode,UserCode,RatedOn,Rating,Coments,SurveyNo,status,Flag,Trans_No,quest_no, ParameterSeqNo) values('JCT00LTD','" & Session("Empcode") & "',getdate(),'" & ChkList.Items(sq).Text & "','" & Replace(txtComents.Text, "'", "''") & "'," & SurveyNo & ",'',''," & TransNo & "," & lblQno.Text & "," & ChkList.Items(sq).Value & " )"
                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            ElseIf Label3.Text = "Select One" Then
                qry = "Insert into jct_emp_survey_Trans(CompanyCode,UserCode,RatedOn,Rating,Coments,SurveyNo,status,Flag,Trans_No,quest_no, ParameterSeqNo) values('JCT00LTD','" & Session("Empcode") & "',getdate(),'" & RdoList.SelectedItem.Text & "','" & Replace(txtComents.Text, "'", "''") & "'," & SurveyNo & ",'',''," & TransNo & "," & lblQno.Text & "," & RdoList.SelectedValue & " )"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.ExecuteNonQuery()
            End If
            '''''''''''''''''''''       Code By Neha Ends Here   ''''''''''''''''''''''''''''''

            Session("SurveyNo") = SurveyNo
            Session("SurveySubject") = SurveyList.SelectedItem.Text
            maxQuest()
            If UnansweredQuest() = 0 Then

                Reset()
                lblQno.Text = "0"
                Response.Write("<script>alert('Thanks For Your Ratings. You Have Completed This Survey!!')</script>")
                Session("SurveyNo") = ""
                Session("SurveySubject") = ""

            Else
                Response.Write("<script>alert('Thanks For Rating!! Moving To Next Unanswered Question of this survey')</script>")
                txtComents.Text = ""
                'GetSurvey()
                GetCurQuestNo(UnansweredQuest)
                'GetParameters()
            End If

        Else
            Response.Write("<script>alert('Invalid Survey Name Selected!!')</script>")
        End If

    End Sub
    'Commented By Neha on 31st March 2010 as this is being handled in GetCurQuest.. Finding image separately is not required
    'Private Sub GetImage()

    '    obj.opencn()
    '    'qry = "select Image_Name,survey_No from jct_emp_survey_Master  where subject='" & SurveyList.SelectedItem.ToString() & "' and image_name <> '' "
    '    'comented on 26-sep-08 qry = "select a.parametername,c.quest,c.imagename,a.survey_no from jct_emp_survey_quest_parameter a,jct_emp_survey_master b,jct_emp_survey_quest_master c where a.survey_no=b.survey_no and a.survey_no=c.survey_no and a.quest_no=c.quest_no and a.quest_no=" & Session("CurQuest") & " and b.subject='" & Me.SurveyList.SelectedValue & "' order by a.sequence_no"
    '    qry = "select c.imagename,c.survey_no from jct_emp_survey_master b,jct_emp_survey_quest_master c where c.quest_no=" & lblQno.Text & " and b.subject='" & Me.SurveyList.SelectedValue & "' and b.survey_no=c.survey_no order by c.survey_no"
    '    cmd = New SqlCommand(qry, obj.cn)
    '    dr = cmd.ExecuteReader
    '    If dr.HasRows = True Then
    '        While dr.Read()

    '            SurImage.ImageUrl = "Survey/" + dr(0)
    '        End While
    '        CollapsablePanel1.Collapsed = False
    '        CollapsablePanel1.Height = SurImage.Height
    '    Else
    '        SurImage.ImageUrl = ""
    '        CollapsablePanel1.Collapsed = True
    '    End If
    '    dr.Close()
    '    obj.closecn()

    '    '       qry = "select c.quest,a.survey_no,c.imagename from jct_emp_survey_quest_parameter a,jct_emp_survey_master b,jct_emp_survey_quest_master c where a.survey_no=b.survey_no and a.survey_no=c.survey_no and b.subject='Testing'   group by a.survey_no,c.Imagename,c.quest order by C.Quest"
    'End Sub

    Protected Sub SurveyList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SurveyList.SelectedIndexChanged
        maxQuest()
        Me.lblQno.Text = 0
        GetCurQuestNo(UnansweredQuest)
        'GetParameters()
    End Sub
    
    Private Sub Reset()
        Me.txtComents.Text = ""
        SurImage.ImageUrl = ""
        LblQuest.Text = ""
        lblQno.Text = "0"
        RdoList.Items.Clear()
        RdoList.Visible = False
        ChkList.Items.Clear()
        LnkMoveAt.Visible = False
        LnkMoveDn.Visible = False
        LnkMoveUp.Visible = False
        Label3.Visible = False
        Me.SurveyList.Items.Clear()
        GetSurvey()
        BLSeq.Items.Clear()
    End Sub
    

    Protected Sub ResetBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub
    Public Sub GetSurvey()
        obj.opencn()

        qry = "select distinct subject,confidential_flag, a.survey_no from jct_emp_survey_master a, jct_emp_survey_quest_master b where a.flag='S' and a.auth_flag='A' and getdate() between auth_date and last_date  and a.survey_no=b.survey_no and convert(varchar(5),b.survey_no)+ convert(varchar(5),b.quest_no)    not in (select convert(varchar(5),surveyno)+ convert(varchar(5),quest_no) from jct_emp_survey_trans where status ='' and usercode='" & Session("empcode") & "')"
        cmd = New SqlCommand(qry, obj.cn)
        If Not IsPostBack Then
            Me.SurveyList.Items.Clear()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    
                    Dim lst As New ListItem
                    lst.Value = dr(2)
                    lst.Text = dr(0)
                    Me.SurveyList.Items.Add(lst)
                    '''''''''''''' Ends Here '''''''''''''''''''
                    Conf_Flag = dr(1)

                End While
            Else

            End If
            dr.Close()
            obj.closecn()
        End If
    End Sub
    
    Public Sub QnCatg(ByVal catg As Char)
        BLSeq.Items.Clear()
        If catg = "N" Then
            RdoList.Items.Clear()
            RdoList.Visible = True
            Label3.Visible = True
            ChkList.Visible = False
            ChkList.Items.Clear()
            LnkMoveDn.Visible = False
            LnkMoveUp.Visible = False
            LnkMoveAt.Visible = False
            DrpMoveAt.Visible = False
            DrpMoveAt.Items.Clear()
            LblRemarks.Visible = False
            Label3.Text = "Select One"
            RdoList.ToolTip = "Select One out of these Options!!"
        ElseIf catg = "M" Then
            RdoList.Items.Clear()
            RdoList.Visible = False
            Label3.Visible = True
            ChkList.Visible = True
            ChkList.Items.Clear()
            LnkMoveDn.Visible = False
            LnkMoveUp.Visible = False
            LnkMoveAt.Visible = False
            DrpMoveAt.Visible = False
            DrpMoveAt.Items.Clear()
            LblRemarks.Visible = False
            Label3.Text = "Check Choice(s)"
            ChkList.ToolTip = "You can Check More than One Option as per Your choice!!"
        ElseIf catg = "R" Then
            RdoList.Items.Clear()
            RdoList.Visible = True
            Label3.Visible = True
            ChkList.Visible = False
            ChkList.Items.Clear()
            LnkMoveDn.Visible = True
            LnkMoveUp.Visible = True
            LnkMoveAt.Visible = True
            DrpMoveAt.Visible = True
            DrpMoveAt.Items.Clear()
            LblRemarks.Visible = True
            Label3.Text = "Arrange These"
            ChkList.ToolTip = "Arrange These as per your Preference. TopMost will be Ranked One!!"
        End If
    End Sub
    Public Sub GetParameters()
        qry = "select a.parametername, c.quest, c.imagename, a.survey_no, a.sequence_no from jct_emp_survey_quest_parameter a,jct_emp_survey_quest_master c where a.survey_no=c.survey_no and a.quest_no=c.quest_no and a.quest_no=" & lblQno.Text & " and a.survey_no=" & Me.SurveyList.SelectedValue & " order by a.sequence_no"
        'qry = "select a.survey_no,a.quest_no,a.quest from jct_emp_survey_quest_master a,jct_emp_survey_trans b where a.quest_no<>b.quest_no and a.survey_no=b.surveyno"
        obj.opencn()


        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Try
            If dr.HasRows = True Then

                While dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else
                        'Added By Neha on 29th March 2010 to facilitate Survey screen to select Multiple Options and also to handle Ranking Questions
                        Dim lst As New ListItem
                        lst.Value = dr(4)
                        lst.Text = dr(0)
                        If Label3.Text = "Arrange These" Then
                            RdoList.Items.Add(lst)
                            DrpMoveAt.Items.Add(RdoList.Items.Count)
                            BLSeq.Items.Add(RdoList.Items.Count)
                        ElseIf Label3.Text = "Check Choice(s)" Then
                            ChkList.Items.Add(lst)
                        ElseIf Label3.Text = "Select One" Then
                            RdoList.Items.Add(lst)
                        End If

                        ''''''''''''''''''       Addition By Neha Ends Here      ''''''''''''''''''''
                        LblQuest.Text = dr(1)

                        

                    End If

                End While
                dr.Close()

            End If

        Catch exp As Exception
            Response.Write(exp.ToString())
        Finally
            obj.closecn()
        End Try
    End Sub
    Public Sub maxQuest()
        'Comented on 26-sep-08qry = "select max(a.quest_no) from jct_emp_survey_quest_parameter a,jct_emp_survey_master b,jct_emp_survey_quest_master c where a.survey_no=b.survey_no and a.survey_no=c.survey_no and a.quest_no=c.quest_no"
        If SurveyList.Items.Count >= 1 Then
            'qry = "select max(quest_no) TotalQuestionsInSurvey  from jct_emp_survey_quest_parameter  where survey_no=" & Session("SurveyNo")
            qry = "select max(quest_no) TotalQuestionsInSurvey  from jct_emp_survey_quest_master  where survey_no=" & SurveyList.SelectedValue
            obj.opencn()
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    MaxQestNo = dr(0)
                End While
            Else
            End If
            dr.Close()
            obj.closecn()
        End If
    End Sub
    Public Function UnansweredQuest() As Integer
        'Added by Neha on 2nd April 2010 to find unanswered questions in survey in case survey has reached last question.
        If SurveyList.Items.Count >= 1 Then
            If lblQno.Text = MaxQestNo Then
                qry = "Select min(b.quest_no) from jct_emp_survey_quest_master b where  b.survey_no=" & SurveyList.SelectedValue & " and convert(varchar(4),b.survey_no)+convert(varchar(4),b.quest_no ) not in (select convert(varchar(4),c.surveyno)+convert(varchar(4),c.quest_no )  from jct_emp_survey_trans c where usercode='" & Session("empcode") & "' and surveyno=" & SurveyList.SelectedValue & " ) "
            Else
                qry = "Select min(b.quest_no) from jct_emp_survey_quest_master b where  b.survey_no=" & SurveyList.SelectedValue & " and b.quest_no > " & lblQno.Text & " and convert(varchar(4),b.survey_no)+convert(varchar(4),b.quest_no ) not in (select convert(varchar(4),c.surveyno)+convert(varchar(4),c.quest_no )  from jct_emp_survey_trans c where usercode='" & Session("empcode") & "' and surveyno=" & SurveyList.SelectedValue & " ) "
            End If
            'qry = "select min(quest_no) from jct_emp_survey_quest_master where survey_no=" & SurveyList.SelectedValue & " and quest_no not in (select quest_no from jct_emp_survey_quest_master  where survey_no=" & SurveyList.SelectedValue & " and usercode='" & Session("Empcode") & "')"
            obj.opencn()
            cmd = New SqlCommand(qry, obj.cn)
            UnansweredQuest = IIf(cmd.ExecuteScalar Is System.DBNull.Value, 0, cmd.ExecuteScalar)
            'dr = cmd.ExecuteReader
            'If dr.HasRows = True Then
            '    While dr.Read()
            '        UnansweredQuest = dr(0)
            '    End While
            'Else
            'End If
            'dr.Close()
            obj.closecn()
        End If
    End Function

    Public Sub GetCurQuestNo(ByVal MaxQuest As Integer)
        ' ''commented on 26-sep-08 qry = "select a.survey_no,a.quest_no,a.quest from jct_emp_survey_quest_master a,jct_emp_survey_trans b,jct_emp_survey_master c where a.quest_no<>b.quest_no and a.survey_no=b.surveyno and c.subject='" & SurveyList.SelectedValue & "' and c.survey_no=a.survey_no and b.usercode='" & Session("empcode") & "'  order by a.survey_no"
        ' ''command replaced on above date
        ' ''qry = "select survey_no,quest_no,quest from jct_emp_survey_quest_master where SURVEY_NO=" & Session("SurveyNo") & " and quest='" & Me.LblQuest.Text & "' and survey_no+quest_no not in (select surveyno+quest_no from jct_emp_survey_trans where usercode='" & Session("empcode") & "')"
        ''qry = "select top 1 b.survey_no,b.quest_no,b.quest, b.QnCatg, b.imagename from jct_emp_survey_quest_master b where  b.survey_no=" & SurveyList.SelectedValue & " and convert(varchar(4),b.survey_no)+convert(varchar(4),b.quest_no ) not in (select convert(varchar(4),c.surveyno)+convert(varchar(4),c.quest_no )  from jct_emp_survey_trans c where usercode='" & Session("empcode") & "' and surveyno=" & SurveyList.SelectedValue & " ) order by  b.survey_no,b.quest_no"
        ' ''If Session("SurveyNo") <> "0" Then
        ' ''qry = "select top 1 b.survey_no,b.quest_no,b.quest from jct_emp_survey_quest_master a,jct_emp_survey_quest_master b where a.quest_no=b.quest_no and a.survey_no = b.survey_no and b.survey_no=" & Session("SurveyNo") & " and convert(varchar(4),b.survey_no)+convert(varchar(4),b.quest_no ) not in (select convert(varchar(4),c.surveyno)+convert(varchar(4),c.quest_no )  from jct_emp_survey_trans c where usercode='" & Session("empcode") & "' and surveyno=" & Session("SurveyNo") & " ) order by  b.survey_no,b.quest_no"


        'Above statements Commented By Neha on 2nd April 2010 and below Qry added..
        If SurveyList.Items.Count > 0 Then
            qry = "Select b.survey_no,b.quest_no,b.quest, b.QnCatg, b.imagename from  jct_emp_survey_quest_master b where b.survey_no=" & SurveyList.SelectedValue & " and b.quest_no =" & MaxQuest

            ''''''''''''''''''         End         ''''''''''''''''''
            obj.opencn()
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    'Session("CurQuest") = dr(1)
                    lblQno.Text = dr(1)
                    LblQuest.Text = dr(2) 'Added on 26-sep-08
                    QnCatg(dr(3))
                    'Added By Neha on 31st Mrch 2010 
                    If Right(dr(4), 8) = "No Image" Then
                        SurImage.ImageUrl = "..\Image\No_Image.gif"
                        CollapsablePanel1.Collapsed = True
                    Else
                        SurImage.ImageUrl = "Survey\" & dr(4)
                        CollapsablePanel1.Collapsed = False
                        CollapsablePanel1.Height = SurImage.Height
                    End If
                    '''''''''''''''       End         ''''''''''''''''
                End While
                dr.Close()
                obj.closecn()
                GetParameters()
            Else
                'lblQno.Text = "No Questions"
                dr.Close()
                obj.closecn()
            End If
        End If


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        lblQno.Text = 0
    End Sub
    Public Sub Search()
        If LstType.SelectedValue = "Customer" Then
            qry = "Select cust_no,cust_name from som..m_customer where cust_no like '%" & txtSearch.Text & "%' or cust_name Like '%" & txtSearch.Text & "%'  "
        ElseIf LstType.SelectedValue = "Employee" Then
            qry = "Select empcode,empname from jct_empmast_base where empcode like '%" & txtSearch.Text & "%' or empname Like '%" & txtSearch.Text & "%'  "
        End If
        obj.opencn()
        LstName.Items.Clear()
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                LstName.Items.Add(dr(0) & "~~" & dr(1))
            End While
            LstName.Visible = True
        Else
            LstName.Visible = False
            Response.Write("<script>alert('Cannot Find Customer Name Or Customer Code')</script>")
        End If
    End Sub

    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text <> "" Then
            Search()
        End If
    End Sub

    Protected Sub LstName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstName.SelectedIndexChanged
        txtSearch.Text = Trim(Left(LstName.SelectedValue, InStr(LstName.SelectedValue, "~~") - 1)) 'LstName.SelectedValue
    End Sub

    Protected Sub LstType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstType.SelectedIndexChanged
        txtSearch.Text = ""
    End Sub
    'Added By Neha on 29th March 2010 to facilitate Survey screen to select move selected Items Up in  Ranking Question
    Protected Sub LnkMoveUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMoveUp.Click
        With RdoList
            Dim i As Int16
            Dim Item1 As ListItem
            For i = 1 To .Items.Count - 1
                If .Items(i).Selected = True Then
                    Item1 = New ListItem(.Items(i).Text, .Items(i).Value)
                    If .Items.IndexOf(Item1) >= 0 Then
                        .Items.Remove(Item1)
                        .Items.Insert(i - 1, Item1)
                        .SelectedIndex = i - 1
                    End If
                    Exit For
                End If
            Next
        End With
    End Sub
    'Added By Neha on 29th March 2010 to facilitate Survey screen to select move selected Items Down in  Ranking Question
    Protected Sub LnkMoveDn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMoveDn.Click
        With RdoList
            Dim i As Int16
            Dim Item1 As ListItem
            For i = 0 To .Items.Count - 2
                If .Items(i).Selected = True Then
                    Item1 = New ListItem(.Items(i).Text, .Items(i).Value)
                    If .Items.IndexOf(Item1) >= 0 Then
                        .Items.Remove(Item1)
                        .Items.Insert(i + 1, Item1)
                        .SelectedIndex = i + 1
                    End If
                    Exit For
                End If
            Next
        End With
    End Sub
    'Added By Neha on 29th March 2010 to facilitate Survey screen to move selected Item at particular location in  Ranking Question
    Protected Sub LnkMoveAt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMoveAt.Click
        With RdoList
            Dim i As Int16
            Dim Item1 As ListItem
            For i = 0 To .Items.Count - 1
                If .Items(i).Selected = True Then
                    Item1 = New ListItem(.Items(i).Text, .Items(i).Value)
                    If .Items.IndexOf(Item1) >= 0 Then
                        .Items.Remove(Item1)
                        .Items.Insert(DrpMoveAt.SelectedIndex, Item1)
                        .SelectedIndex = DrpMoveAt.SelectedIndex
                    End If
                    Exit For
                End If
            Next
        End With
    End Sub

    Protected Sub LnkFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkFirst.Click
        txtComents.Text = ""
        Dim qn As Integer
        If SurveyList.Items.Count >= 1 Then
            qry = "Select min(b.quest_no) from jct_emp_survey_quest_master b where  b.survey_no=" & SurveyList.SelectedValue & " and convert(varchar(4),b.survey_no)+convert(varchar(4),b.quest_no ) not in (select convert(varchar(4),c.surveyno)+convert(varchar(4),c.quest_no )  from jct_emp_survey_trans c where usercode='" & Session("empcode") & "' and surveyno=" & SurveyList.SelectedValue & " )"
            obj.opencn()
            cmd = New SqlCommand(qry, obj.cn)
            qn = IIf(cmd.ExecuteScalar Is System.DBNull.Value, 0, cmd.ExecuteScalar)
            obj.closecn()
        End If
        GetCurQuestNo(qn)
    End Sub

    Protected Sub LnkPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkPrevious.Click
        txtComents.Text = ""
        Dim qn As Integer
        If SurveyList.Items.Count >= 1 Then
            qry = "Select max(b.quest_no) from jct_emp_survey_quest_master b where  b.survey_no=" & SurveyList.SelectedValue & " and b.quest_no < " & lblQno.Text & " and convert(varchar(4),b.survey_no)+convert(varchar(4),b.quest_no ) not in (select convert(varchar(4),c.surveyno)+convert(varchar(4),c.quest_no )  from jct_emp_survey_trans c where usercode='" & Session("empcode") & "' and surveyno=" & SurveyList.SelectedValue & " )"
            obj.opencn()
            cmd = New SqlCommand(qry, obj.cn)
            qn = IIf(cmd.ExecuteScalar Is System.DBNull.Value, 0, cmd.ExecuteScalar)
            obj.closecn()
        End If
        GetCurQuestNo(qn)
    End Sub

    Protected Sub LnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkNext.Click
        txtComents.Text = ""
        Dim qn As Integer
        If SurveyList.Items.Count >= 1 Then
            qry = "Select min(b.quest_no) from jct_emp_survey_quest_master b where  b.survey_no=" & SurveyList.SelectedValue & " and b.quest_no > " & lblQno.Text & " and convert(varchar(4),b.survey_no)+convert(varchar(4),b.quest_no ) not in (select convert(varchar(4),c.surveyno)+convert(varchar(4),c.quest_no )  from jct_emp_survey_trans c where usercode='" & Session("empcode") & "' and surveyno=" & SurveyList.SelectedValue & " ) "
            obj.opencn()
            cmd = New SqlCommand(qry, obj.cn)
            qn = IIf(cmd.ExecuteScalar Is System.DBNull.Value, 0, cmd.ExecuteScalar)
            obj.closecn()
        End If
        GetCurQuestNo(qn)
    End Sub

    Protected Sub LnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkLast.Click
        txtComents.Text = ""
        Dim qn As Integer
        If SurveyList.Items.Count >= 1 Then
            qry = "Select max(b.quest_no) from jct_emp_survey_quest_master b where  b.survey_no=" & SurveyList.SelectedValue & " and convert(varchar(4),b.survey_no)+convert(varchar(4),b.quest_no ) not in (select convert(varchar(4),c.surveyno)+convert(varchar(4),c.quest_no )  from jct_emp_survey_trans c where usercode='" & Session("empcode") & "' and surveyno=" & SurveyList.SelectedValue & " ) "
            obj.opencn()
            cmd = New SqlCommand(qry, obj.cn)
            qn = IIf(cmd.ExecuteScalar Is System.DBNull.Value, 0, cmd.ExecuteScalar)
            obj.closecn()
        End If
        GetCurQuestNo(qn)
    End Sub

    
End Class
