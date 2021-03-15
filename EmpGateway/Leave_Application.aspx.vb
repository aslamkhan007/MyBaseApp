Imports System.Data.SqlClient
Imports System.Net.Mail.MailMessage
Imports System.Net.Mail.SmtpClient
Imports System.Data
Imports System.Net.Mail

Partial Class Default9
    Inherits System.Web.UI.Page
    Dim strTo As String, strFrom As String, strSubject As String, SqlPass As String, Sqlpass1 As String, con As String
    Dim EmailTO, EmailTO1, EmailFrom, EmailCc, EmailBcc, EmailBcc1, Checkflag, Checkflag1 As String
    Dim CheckError As Boolean = False, CheckRecord As Boolean = False, CheckDate As Boolean = False
    Dim Auto1 As Int64, Difference As Integer, CountMail As Integer = 0
    Dim Obj As New Connection
    Dim Cmd As New SqlCommand
    Dim obj1 As Functions = New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.Cache.SetExpires(Now.AddSeconds(-1))
        'Response.Cache.SetNoStore()
        'Response.AppendHeader("Pragma", "no-cache")
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If
        If IsPostBack = False Then
            'If Session("Empcode") = "r-03348" Then
            '    Dim mytext As String = "Leaves"
            '    mytext = "<DIV style = filter:shadow(color:black,strength:2,direction:135);><nobr>" & mytext & "</nobr></DIV>"
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "m", "marqueecontent='" & mytext & "'", True)
            'End If

            ModalPopupExtender1.Enabled = False
            ModalPopupExtender1.Hide()

            If mapping_check() = False Then

                ClientScript.RegisterClientScriptBlock(Me.GetType, "Day", "<script language = javascript>alert('Dear User ,You are not mapped under your concerned Head.As per Employee Gateway Leave requirements, our employee gateway system requires mapping of employee with his/her concerned Head for leave authorization. So please forward a mail to IT Help Desk from your concerned Head to map you under him/her . Also, this mail would include yours and your Head’s salary codes. The CC of that mail should be done through your Head Of Department. Incase of any problem, please contact 4226')</script>")
                Me.Label16.Visible = True
                Me.LinkButton4.Visible = True
                LinkButton4.PostBackUrl = "Guest_Book.aspx?trans1=y"

            Else

                Me.LinkButton4.Visible = False
                Me.Label16.Visible = False


                '------------------------------------Punch-----------------------

                If Request.QueryString.Get("trans1") = Nothing Then
                    LinkButton3.Visible = False
                    LinkButton3.PostBackUrl = "Punch.aspx"
                Else

                    LinkButton3.Visible = True
                    Dim a As String = Left(Request.QueryString.Get("trans1"), 12)
                    a = Right(a, 10)
                    Me.TxtLeaveFrom.SelectedDate = a
                    Me.TxtLeaveTo.SelectedDate = a
                    LinkButton3.Text = "Back"
                    LinkButton3.PostBackUrl = Nothing
                    LinkButton3.OnClientClick = "javascript:window.history.go(-1);return false;"

                End If


                '------------------------------End Punch-------------------------



            End If

            LeaveMsg()

        End If
    End Sub
    Public Function mapping_check() As Boolean
        Obj.ConOpen()
        Dim s1 As String = "select * from jct_emp_hod where emp_code='" & Trim(Session("Empcode")) & "' and status is null"
        Cmd = New SqlCommand(s1, Obj.Connection())
        Dim dr As SqlDataReader = Cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows = True Then
            mapping_check = True
        Else
            mapping_check = False
        End If
        dr.Close()
        Obj.ConClose()
        Return mapping_check
    End Function
    Public Function Check_Is_Empty_Flag_Inserted() As Boolean
        Obj.ConOpen()
        Dim s2 As String = "select * from jct_empg_leave where mainflag='p' and flaghc='' and empcode='" & Trim(Session("Empcode")) & "'"
        Cmd = New SqlCommand(s2, Obj.Connection())
        Dim dr As SqlDataReader = Cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows = True Then
            Check_Is_Empty_Flag_Inserted = True
        Else
            Check_Is_Empty_Flag_Inserted = False
        End If
        dr.Close()
        Obj.ConClose()
        Return Check_Is_Empty_Flag_Inserted

    End Function

    Public Function OtherLeaveChecking() As Boolean
        If Trim(ddlleave.Text) = "Short Leave" Or Trim(ddlleave.Text) = "Sick Leave" Or Trim(ddlleave.Text) = "Priviledge Leave" Or Trim(ddlleave.Text) = "Casual Leave" Or Trim(ddlleave.Text) = "Compensatry Leave" Then

            'Dim SqlPass4 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND  ( ( LeaveFrom = '" & Trim(TxtLeaveFrom.SelectedDate) & "' AND LeaveTo ='" & Trim(TxtLeaveTo.SelectedDate) & "'  ) OR LeaveFrom = '" & Trim(TxtLeaveFrom.SelectedDate) & "'  OR LeaveTo ='" & Trim(TxtLeaveTo.SelectedDate) & "')    AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )"


            '****04 Nov 2015**********************************************************
            Dim SqlPass5 As String = "SELECT  Count(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'    AND  ( ( LeaveFrom = '" & Trim(TxtLeaveFrom.SelectedDate) & "' AND LeaveTo ='" & Trim(TxtLeaveTo.SelectedDate) & "'  ) OR LeaveFrom = '" & Trim(TxtLeaveFrom.SelectedDate) & "'  OR LeaveTo ='" & Trim(TxtLeaveTo.SelectedDate) & "')    AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' ) AND  NatureLeave='Official Duty' "

            Dim Dr5 As SqlDataReader = Obj.FetchReader(SqlPass5)
            Try
                If Dr5.HasRows = True Then
                    While Dr5.Read()
                        If Dr5.Item(0) > 0 Then
                            OtherLeaveChecking = True
                            Exit Function


                        Else
                            'ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveAlreExist2", "<script language = javascript>alert('Leave already apply for same day ')</script>")
                            OtherLeaveChecking = False
                            'Exit Function
                           
                        End If
                    End While

                End If
                Dr5.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try

            '*****04 Nov 2015 End ******************************************************************






            Dim SqlPass4 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'    AND  ( ( LeaveFrom = '" & Trim(TxtLeaveFrom.SelectedDate) & "' AND LeaveTo ='" & Trim(TxtLeaveTo.SelectedDate) & "'  ) OR LeaveFrom = '" & Trim(TxtLeaveFrom.SelectedDate) & "'  OR LeaveTo ='" & Trim(TxtLeaveTo.SelectedDate) & "')    AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )"

            Dim Dr4 As SqlDataReader = Obj.FetchReader(SqlPass4)
            Try
                If Dr4.HasRows = True Then
                    While Dr4.Read()
                        If Dr4.Item(0) > 0 Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveAlreExist2", "<script language = javascript>alert('Leave already apply for same day ')</script>")
                            OtherLeaveChecking = False
                        Else
                            OtherLeaveChecking = True
                        End If
                    End While

                End If
                Dr4.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
        End If
    End Function

    Public Function ShortLeaveChecking() As Boolean

        If Trim(ddlleave.Text) = "Short Leave" Then

            Dim SqlPass5 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND   MONTH( LeaveFrom) = MONTH('" & Trim(TxtLeaveFrom.SelectedDate) & "')  AND   YEAR( LeaveFrom) = YEAR  ('" & Trim(TxtLeaveFrom.SelectedDate) & "')   AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )"
            Dim Dr5 As SqlDataReader = Obj.FetchReader(SqlPass5)
            Try
                If Dr5.HasRows = True Then
                    While Dr5.Read()
                        If Dr5.Item(0) > 0 Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveAlreExist2", "<script language = javascript>alert('One Short Leave already apply for month ')</script>")
                            ShortLeaveChecking = False
                        Else
                            ShortLeaveChecking = True
                        End If
                    End While

                End If
                Dr5.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
        End If

    End Function

    Public Function LeaveFromToDaysDiffeChecking() As Boolean


        If Trim(TxtLeaveFrom.SelectedDate) <> Trim(TxtLeaveTo.SelectedDate) Then

            Dim SqlPass55 As String = "SELECT    DATEDIFF(dd,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "') + 1  "
            Dim Dr55 As SqlDataReader = Obj.FetchReader(SqlPass55)
            Try
                If Dr55.HasRows = True Then
                    While Dr55.Read()
                        If Dr55.Item(0) <> Val(Txtdays.Text) Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType, "EnterDays", "<script language = javascript>alert('Please Check the enter days ')</script>")
                            LeaveFromToDaysDiffeChecking = False
                        Else
                            LeaveFromToDaysDiffeChecking = True
                        End If
                    End While

                End If
                Dr55.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try


        Else
            LeaveFromToDaysDiffeChecking = True

        End If
    End Function


    Public Function CasualLeaveChecking() As Boolean

        If Trim(ddlleave.Text) = "Casual Leave" Then

            Dim SqlPass6 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND  MONTH( LeaveFrom) = MONTH('" & Trim(TxtLeaveFrom.SelectedDate) & "')  AND  YEAR( LeaveFrom) = YEAR('" & Trim(TxtLeaveFrom.SelectedDate) & "')     AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )  AND Days IN ( '0.5', '1.5', '.5', '2.5' )"
            Dim Dr6 As SqlDataReader = Obj.FetchReader(SqlPass6)
            Try
                If Dr6.HasRows = True Then
                    While Dr6.Read()
                        If Dr6.Item(0) >= 2 Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType, "CasualLeaveeAlreExist2", "<script language = javascript>alert('2 Half Casual Leave already apply for this month  ')</script>")
                            CasualLeaveChecking = False
                        Else
                            CasualLeaveChecking = True
                        End If
                    End While

                End If
                Dr6.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
        End If

    End Function


    Public Function CompensatoryChecking() As Boolean
        '------------------------------------------------------------------------------------------------------------------------------
        'Check Compensatory is exists ot not
        '------------------------------------------------------------------------------------------------------------------------------
        Dim comTrueFalse As Boolean = False
        If Trim(ddlleave.Text) = "Compensatry Leave" Then
            Dim SqlPass2 As String = "SELECT leave_earned_date FROM savior..Jct_comp_leave  WHERE paycode='" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "' AND leave_earned_date= '" & Trim(TxtCoDtAgian.SelectedDate) & "' AND status IS NULL "
            Dim Dr2 As SqlDataReader = Obj.FetchReader(SqlPass2)
            Try
                If Dr2.HasRows = True Then

                    comTrueFalse = True
                    CompensatoryChecking = True

                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType, "Leavenotavailabled", "<script language = javascript>alert('Compensatry leave has not credited in your account please check your Leave')</script>")
                    comTrueFalse = False
                    CompensatoryChecking = False
                End If
                Dr2.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try


            If comTrueFalse = True Then

                Dim SqlPass1 As String = "SELECT  DateDiff(DD,'" & TxtCoDtAgian.SelectedDate & "', CAST(GETDATE() AS SMALLDATETIME)) as Difference"
                Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
                Try
                    If Dr1.HasRows = True Then
                        While Dr1.Read()
                            If Dr1.Item(0) >= 91 Then
                                ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveExist", "<script language = javascript>alert('Compensatry leave More than 90 days old')</script>")
                                CompensatoryChecking = False
                            Else
                                CompensatoryChecking = True
                            End If
                        End While
                        Dr1.Close()
                    End If
                Catch ex As Exception
                Finally
                    Obj.ConClose()
                End Try
            End If


            If comTrueFalse = True Then
                Dim SqlPass3 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'    AND CompAgainTime ='" & Trim(TxtCoDtAgian.SelectedDate) & "'      AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )"
                Dim Dr3 As SqlDataReader = Obj.FetchReader(SqlPass3)
                Try
                    If Dr3.HasRows = True Then
                        While Dr3.Read()
                            If Dr3.Item(0) > 0 Then
                                ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveAlreExist1", "<script language = javascript>alert('Compensatry  already availed  ')</script>")
                                comTrueFalse = False
                                CompensatoryChecking = False
                            Else
                                comTrueFalse = True
                                CompensatoryChecking = True
                            End If
                        End While

                    End If
                    Dr3.Close()
                Catch ex As Exception
                Finally
                    Obj.ConClose()
                End Try
            End If




        End If




        '------------------------------------------------------------------------------------------------------------------------------


    End Function


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdapply.Click


        Try

       
        '------------------------------------------------------------------------------------------------------------------------------
        If Txtdays.Text = "" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Day", "<script language = javascript>alert('Please fill the leave days')</script>")
            Txtdays.Focus()
            Exit Sub
        End If
        'hITESH  30/JUNE
        'SameDate()
        'If CheckRecord = True Then
        '    ClientScript.RegisterClientScriptBlock(Me.GetType, "Reocrd", "<script language = javascript>alert('Record Already Exists')</script>")
        '    Exit Sub
        'End If
        '----





        If Val(Txtdays.Text) > 1 And ddlleave.Text = "Compensatry Leave" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Leave", "<script language = javascript>alert('More than 1  Compensatry leave is not allowed')</script>")
            Txtdays.Focus()
            Exit Sub

        End If


        If ddlleave.Text = "Compensatry Leave" Then


            If CompensatoryChecking() = False Then
                Exit Sub
            End If


        End If




        If ddlleave.Text <> "Tour" Then
            If ddlleave.Text <> "Official Duty" Then

                If OtherLeaveChecking() = False Then
                    Exit Sub
                Else
                    If Trim(ddlleave.Text) = "Short Leave" Then
                        If ShortLeaveChecking() = False Then
                            Exit Sub
                        End If
                    End If

                End If
            End If
        End If



        If ddlleave.Text = "Casual Leave" And (Txtdays.Text = "0.5" Or Txtdays.Text = ".5" Or Txtdays.Text = "1.5") Then


            If CasualLeaveChecking() = False Then
                Exit Sub
            End If


        End If


            If LeaveFromToDaysDiffeChecking() = False Then
                Exit Sub
            End If




            If ddlleave.Text <> "Tour" Then

                If ddlleave.Text <> "Official Duty" Then

                    If ddlleave.Text = "Short Leave" And dlleavetype.Text <> "Hours" Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "Hours", "<script language = javascript>alert('Please choose hours')</script>")
                        Exit Sub
                    End If

                    If ddlleave.Text <> "Short Leave" And dlleavetype.Text.Contains("Half") = True And Trim(Txtdays.Text) >= "1" Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "Full", "<script language = javascript>alert('Please fill 0.5 day agaisnt Half Day')</script>")
                        Exit Sub
                    End If


                    If ddlleave.Text <> "Short Leave" And dlleavetype.Text = "Multiple Days" And Trim(Txtdays.Text) <= "1" Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "Full", "<script language = javascript>alert('Please fill more than 1 day')</script>")
                        Exit Sub
                    End If

                    If ddlleave.Text <> "Short Leave" And dlleavetype.Text = "Hours" Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "Sh", "<script language = javascript>alert('Please hours leave not allowed')</script>")
                        Exit Sub
                    End If

                End If
            End If


            CheckDateGreater()
            If CheckDate = True Then
                ClientScript.RegisterClientScriptBlock(Me.GetType, "R4", "<script language = javascript>alert('LeaveFrom Date should be less than LeaveTo')</script>")
                Exit Sub
            End If
            '------------------------------------------------------------------------------------------------------------------------------
            EmailIDFrom()

            '------------------------------------------------------------------------------------------------------------------------------
            'Define the Class
            '------------------------------------------------------------------------------------------------------------------------------

            Dim Client As New Net.Mail.SmtpClient
            Dim Message As New Net.Mail.MailMessage

            '------------------------------------------------------------------------------------------------------------------------------


            '------------------------------------------------------------------------------------------------------------------------------
            'Severe Name & Prot number
            '------------------------------------------------------------------------------------------------------------------------------
            Client.Host = "EXCHANGE2k7"
            Client.Port = 25
            '------------------------------------------------------------------------------------------------------------------------------


            If EmailFrom <> "" Then
                Dim From As New Net.Mail.MailAddress(EmailFrom)
                Message.From = From
            End If


            '------------------------------------------------------------------------------------------------------------------------------
            'Send message for To
            '------------------------------------------------------------------------------------------------------------------------------

            Dim SqlPass = "SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and Days=0 and a.Company_Code='" & Session("Companycode") & "'  UNION SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and days between 0 and " & Txtdays.Text & " and a.Company_Code='" & Session("Companycode") & "' "

            Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
            Try
                If Dr.HasRows = True Then

                    While Dr.Read()

                        If Not (Dr.Item(0) Is System.DBNull.Value) Then

                            EmailTO = Dr.Item(0)

                            Dim qry As String = "SELECT * FROM dbo.JCT_OPS_EMAIL_APPROVAL_AUTHORITY_LIST WHERE EmailID='" + EmailTO + "' AND STATUS='A' AND EMAILAPPROVAL='Y'"
                            Dim ConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
                            Dim conn As SqlConnection = New SqlConnection(ConStr)

                            conn.Open()

                            Dim cmd As SqlCommand = New SqlCommand(qry, conn)
                            Dim sqldr As SqlDataReader = cmd.ExecuteReader()
                            If (sqldr.HasRows) Then
                                Message.From = New Net.Mail.MailAddress("approvals@jctltd.com")
                            End If
                            sqldr.Close()
                            conn.Close()
                            EmailFrom = Dr.Item(0)

                            Message.CC.Add(ViewState("EmployeeFrom"))

                            Message.To.Add(EmailTO)

                        End If
                    End While

                    If Val(Txtdays.Text) > 3 And ddlleave.Text = "Sick Leave" Then
                        Message.To.Add("saini@jctltd.com")
                        Message.To.Add("reception@jctltd.com")
                    End If

                    Dr.Close()


There are 7 boxes which are colored with different colors – White, Blue, Yellow, Green, Red, Brown and Pink. They are placed one above the other. And contain different flavored cupcakes – Mint Oreo, Chocolate, Blueberry, Mango, Lemon, Apple Pie and Cranberry, but not necessarily in the same order.
Further information is as follows:
(i) Boxes containing Either Mango or Cranberry cupcake is on the top or first place respectively.

(ii) The brown box is placed on 5th place from bottom.
(iii) The boxes containing Chocolate and Apple Pie cupcakes are placed consecutively.
(iv) White and Red colored boxes contain Mint Oreo and Lemon cupcakes respectively.
(v) Yellow and Brown boxes are placed at consecutive places.
(vi) Blue box, which contains Chocolate cupcake, and White box have one box in between them.
(vii) Yellow box, which contains Blueberry cupcake is placed just above the box containing Apple Pie cupcake.


There are 8 boxes which are colored with different colors – white, pink, green, blue, yellow, red, orange and brown. Each of them contains a number written on them from 1 to 8 according to which they are placed one above the other. The box containing number 1 is at the lowest place. Each box has different sweets namely – Rasgulla, Laddu, Peda, Nankhatai, Jalebi, Gulab Jamun, Petha and Burfi but not necessarily in the same order.
Only one box is there between pink box and the one which contains Jalebi. Number 4 is written on the brown box. The number on red colored box is odd and is placed somewhere above the box numbered four.
There are three boxes between blue box and the one which contains Gulab Jamun. The number written on Green box is odd and is placed above the box which contains Gulab Jamun.The box which contains Petha is placed immediately above orange colored box, which contains neither Gulab jamun nor Rasgulla. The yellow box does not contain Petha. There are three boxes placed between orange and white boxes. The box which contains Burfi is placed immediately above the one which contains Laddu, but not at the topmost position. Only one box is there between red colored box and the one which contains Peda. The number of boxes placed above red colored box is same as the number of boxes placed between blue and red colored boxes. Only one box is there between the one which contains Burfi and brown colored box. Two boxes are placed between green colored box and the one which contains Rasgulla.


There are eight boxes viz. A, B, C, D, E, F, G and H. All the box are arranged from top to bottom. There are four box between C and H. There are two box between H and A. There are three box between A and F. There are two box between F and B. There is only one box between B and D. The box D is not placed immediately above or immediately below the F. There are gap of two box between E and G. The box E is placed one of the above on H but not on the top.

P, Q, R, S, T, U, and V are seven different boxes of different colors i.e. Black, Orange, Red, Pink, Yellow, White, and Green but not necessarily in the same order.
Box Q is not placed below S. Box which is of Black color is immediately above P. There are only two boxes between S and the box which is of Black color and Box S is above the Black color box. The box which is of Red color is above S but not immediately above S. Only three boxes are between R and the box which is of Red color. The box which is of Green color is immediately above R. The box which is of Pink color is immediately above box V. Only one box is there between Q and T. Neither box Q nor P is of Yellow color. P is not of Orange color.

Seven boxes-A,B,C,D,E,F and G are kept one above the other, but not necessarily in the same order. Each Box has a different number Viz. 11,14,15,17,18,19 and 22 but not necessarily in the same order. Only. three boxes are kept between G and box number 19. Only two boxes are kept between G and B . B is kept at one of the positions below box number 19. Only one box is kept between B and box number 14. E is kept immediately below box number 22.E is kept at one of the places above box number 19. There is only one box between E and the box having number less than E . E’s box number is neither 17 or 18 .Only two boxes are kept between box number 15 and F . Thee difference between F and the box immediately below it is less than four .C is not the topmost box. C’s box number is not 4 . Only two boxes are kept between C and A.


Eight boxes A, B, C, E, F, G, M and N are placed one above the another but not necessarily in the same order. Each of them has different colours i.e. Black, Orange, Red, Green, Yellow, Purple, Blue and Brown.
Like Us : Facebook.com/GovernmentAdda Join Us: Telegram.me/GovtAdda
Daily Visit | GovernmentAdda.com (A Complete Hub for Government Exams Preparation) 7
1. There are only three boxes between B and M. 2. Yellow and black coloured boxes are not on the consecutive places. 3. A box which is immediate above yellow coloured box is neither blue nor purple coloured box. 4. G is an orange coloured box but not on the top. 5. There are only two boxes below red coloured box. 6. Blue coloured box is above purple coloured box. 7. Neither M nor F is a purple coloured box. 8. There are only two boxes between orange and black coloured box. 9. Number of boxes between A and F is same as the number of boxes between A and N. 10. Yellow coloured box is one place above box C. 11. Box B and box G are on the consecutive places. 12. Green coloured box is immediate below box M. 13. Orange and Black coloured boxes are above Red coloured box.


A, B, C, D, E, F and G are seven different boxes of different colours i.e. Black, Orange, Red,
Pink, Yellow,
White and Green but not necessarily in the same order.
Box B is not placed below D. Box which is of Black colour is immediately above A. There are
Only two box between D and the box which is of Black colour and Box D is above the Black
colour box. Box which is of Red colour is above D but not immediately above D. Only three box
are between C and the box which is of Red colour. The box which is of Green colour is
immediately above C. The box which is of Pink colour is immediately above box G. Only one box
is there between B and E. Neither box B nor A is of Yellow colour. A is not of Orange colour.



There are eight employees A, B, C, D, E, F, G and H of the same company. They all have to take a leave on different dates in the months of
September and October but not necessarily in the same order. In each month, they will take a leave on dates 2nd, 11th, 19th and 23rd of the
month. (Only one employee will take a leave on these given dates). A will take a leave neither on 2nd nor 23rd of any of the given month.
Three employees will take a leave between A and H. Two employees will take a leave between H and B. One employee will take a leave between B
and G. G will take a leave on either 19th or 23rd of any of the given month. Three employees will take a leave between G and C. 
Two employees will take a leave between C and F. Two employees will take a leave between E and D. D will not take a leave on 2nd October.


Directions (1-5): Study the following information carefully and answer the question given below: 

There are eight employees A, B, C, D, E, F, G and H of the same company. They all have to take a leave on different dates in the months of September and October but not necessarily in the same order. In each month, they will take a leave on dates 2nd, 11th, 19th and 23rd of the month. (Only one employee will take a leave on these given dates). A will take a leave neither on 2nd nor 23rd of any of the given month. Three employees will take a leave between A and H. Two employees will take a leave between H and B. One employee will take a leave between B and G. G will take a leave on either 19th or 23rd of any of the given month. Three employees will take a leave between G and C. Two employees will take a leave between C and F. Two employees will take a leave between E and D. D will not take a leave on 2nd October.



Directions (11-15): Study the following information carefully and answer the questions given below: 

Eight people P, Q, R, S, T, U, V and W are sitting around a square table facing outside the centre. Four of them are sitting at the corners and four are sitting along the side. They are also from different countries — India, US, PAK, UK, Bangladesh, UAE, Brazil and Nepal. Q is not an immediate neighbour of W. The person who is from PAK sits third to the right of the one who is from Bangladesh. V, who is from US sits second to the left of U, who is from India. V who sits at one of the corners also sits third to the left of the one who is from UK. There are 3 people sit between P and R, who is from Nepal. S is not an immediate neighbour of both P and Q, who is from UK. T sits opposite to the one who is from US. Q sits second to the left of P, who is from Brazil.








Directions (1-5): Study the following information carefully and answer the questions given below: 
Seven friends P, Q, R, S, T, U, and V played different games i.e. Hockey, Chess, Snooker, Disc Throw, Badminton, Football, Basketball in different months of the year i.e. January, March, April, May, June, September, December (but not necessarily in the same order). U plays a Basketball in that month which has 30 days. R does not play Snooker. P plays a game in a month which has 31 days but he doesn’t play Snooker and Disc Throw. Q plays a game in March and T plays Football. Badminton game played in September. Chess game played in a month which has 30 days. S plays a game in September. V plays in a month which comes just after the month in which Q plays. P plays a game in a month which comes after March. R plays a game in a month which comes just before the month in which U plays a game.



Directions (1-5): Study the following information carefully and answer the questions given below: 
Seven friends P, Q, R, S, T, U, and V played different games i.e. Hockey, Chess, Snooker, Disc Throw, Badminton, Football, Basketball in different months of the year i.e. January, March, April, May, June, September, December (but not necessarily in the same order). U plays a Basketball in that month which has 30 days. R does not play Snooker. P plays a game in a month which has 31 days but he doesn’t play Snooker and Disc Throw. Q plays a game in March and T plays Football. Badminton game played in September. Chess game played in a month which has 30 days. S plays a game in September. V plays in a month which comes just after the month in which Q plays. P plays a game in a month which comes after March. R plays a game in a month which comes just before the month in which U plays a game.


Seven presentations on different subjects viz. Chemistry, Physics, Mathematics, Hindi, Punjabi, English and Economics were scheduled to be held in Pune, Bangalore, Amritsar, Chennai, Hyderabad, Lucknow and Surat on one day in a week starting from Monday and ending on Sunday not necessarily in the same order. Only one conference was held between conference on Punjabi and Physics. Conference on Chemistry was held immediately after Mathematics but immediately before Economics. Conference on Punjabi was held in Chennai on Friday. Conference on Mathematics was not held in Amritsar. The conference held on Monday was held in Amritsar. Only one conference was held between conferences on Economics and the conference held in Pune. Conference in Bangalore was held immediately before conference in Hyderabad. Conference on Hindi was not held on Monday. Conference on Chemistry was not held in Hyderabad. Conference in Surat was not held after conference in Pune.





             * 
Two people attend workshop on the days between the days on which one who likes Green and the one who likes Pink attend workshop. 
S, who likes Pink does not attend workshop in Accenture or TCS and attends workshop on the next day of the day on which T attends workshop, 
who attends the workshop in Tech Mahindra. The one who likes Black attends workshop on the day just before the day on which R attends the workshop and
three people attend the workshop on the days between the days on which the one who likes Red and the one who likes Yellow attend the workshop.
The one who likes Orange attends workshop just before the day on which the one who likes Red attends the workshop. 
The one who likes Blue attends workshop after the day on which the persons who likes Red attends the workshop.                           
Seven persons P, Q, R, S, T, U and V attend workshop for developing managerial skills in seven different companies namely Accenture, HCL, TCS, Infosys, Tata, 
Tech Mahindra and Amdocs on a different days of the week from Monday to Sunday and also they like some colour viz.- Red, Black, Green, Orange, Yellow, Pink and Blue. 
The order of persons, companies, colour and days of the week are not necessarily in the same order.
R attends workshop in company Accenture but not on Tuesday. V attends workshop on Monday but not in TCS and Amdocs. U attends workshop in Tata on Friday.
The one who works in Accenture likesGreen. Q attends workshop in Infosys on Wednesday. 
Two people attend workshop on the days between the days on which one who likes Green and the one who likes Pink attend workshop. S, who likes Pink does not attend workshop in Accenture or TCS and attends workshop on the next day of the day on which T attends workshop, who attends the workshop in Tech Mahindra. The one who likes Black attends workshop on the day just before the day on which R attends the workshop and three people attend the workshop on the days between the days on which the one who likes Red and the one who likes Yellow attend the workshop. The one who likes Orange attends workshop just before the day on which the one who likes Red attends the workshop. The one who likes Blue attends workshop after the day on which the persons who likes Red attends the workshop.             
             * 
Eight persons – A, B, C, D, E, F, G and H are living in an eight storey building and are from different professions among Singer, Dancer, Teacher, Actor, Boxer, Politician, Engineer and Scientist but not necessarily in the same order.
G lives on the first floor and E lives on the third to the floor of G. The person who is a Singer is an immediate neighbour of E and E is not a Scientist. Neither B nor H is an immediate neighbour of E. C is an Actor. F is an Engineer and lives on the floor third to the floor of the person who is a Singer. H lives four floors above the floor of B. There is one floor between the person who is a Teacher and who is an Engineer. A is a Politician lives between F and H. The person who is a Boxer lives on the floor second to the floor of E. The persons who is an Actor and who is a Dancer are immediate neighbours.             
             * 
             * 
 Eight delegates – P, Q, R, S, T, U, V and W are sitting around a circular table, but not necessarily in the same order. 
Some are facing inside while some are facing outside. Each of them belongs to different countries viz. India, Pakistan, China, America, Canada, New Zealand, Australia and Bangladesh. 
U does not sit immediately next to P. Only two persons sit between V and W. The person to the immediate left of P is from Pakistan, who faces the centre.
U and T are facing the same side and only two persons are sitting between them. The one who is from New Zealand sits immediately next to the one who is from Australia
but not faces the one who is from China. T sits second to the left of P. The one who is from Canada faces the one who is from Bangladesh. 
S sits diagonally opposite to Q who sits to the immediate right of T and both of them are facing each other. The one who is from China sits between U and Q. 
The one who is from India does not sit immediately next to U. P and R are facing outward direction but not as U. R sits second to the left of V.
The one who is from Bangladesh sits second to the right of the one who is from China.

             * 










Seven sports persons Abhishek, Bhanu, Gautam, Hemant, Latika, Mayank , Zeba sit on a bench, facing North, not necessarily in the same order. Each of them plays a different game among Hockey, Rugby, Golf, Soccer, Badminton, Cricket, and Tennis. The following information as follow
(i) Abhishek sits third to the left of the person, who plays Soccer and third to the right of Hemant.
(ii) Only two persons sit between Latika and the person who plays Tennis. The person who plays tennis is neither second to the left of the one who plays Soccer nor second to the right of Hemant.The person who plays Soccer is not adjacent to the one who plays Tennis.
(iii) The person who plays Golf sits second to the left of the person who plays Tennis but is not adjacent to either Gautam or Zeba.
(iv) Bhanu is neither adjacent to Abhishek nor plays Golf.
(v) Only two persons sit between Mayank and the person who plays Badminton.
(vi) Gautam does not play Cricket or Golf.
(vii) Hemant does not play Cricket or Rugby.

             * 
             * 
Direction: Study the information given below and answer the questions based on it.
A, B, C, D, E, F, G and H are eight students of an institute and getting marks in three different ranges viz. 
below 50, 50-80, and above 80 with not more than three of them in the given range. Each of them like different sports viz football, cricket, volleyball, badminton, lawn tennis, basketball, hockey and table tennis not necessarily in the same order.

D score 60 marks and does not like either football or cricket. F score more than 40 but less than 50 with only A who also score same marks as well as likes table tennis. 
E and H do not score in the range as D but they both are distinction student.
C likes hockey and does not score above 80. G does not score in the range of 50-80 and does not like either cricket or badminton.
One of those who score in 50-80 marks likes football. The one who likes volleyball score less than 50.
None of those who score in 50-80 marks like either badminton or lawn tennis. H does not like cricket. The person who likes hockey scores exactly 50 marks.






M, N, O, P, Q, R, S and T are studying in VIII, IX and X classes. Not more than three students are there in one class. Each of them has a favourite subjects, viz, Hindi, Computer, English, History, Mathematics, Sanskrit, Science and Gk, but not necessarily in the same order. 

N is not in the IX class. Q and M are students of in a same class but not with N. O and R are students of the same class. The students who study in the VIII class do not like Science and Mathematics. R likes Computer. P likes Sanskrit and is in X class only with T. O does not like Hindi. History is the favourite subject of M. S does not like Science. The one who studies in the X class likes Engli
sh.



Directions: Study the following information carefully and answer the questions given below: 
Eight friends A, B, C, D, E, F, G and H like different colors namely Red, Blue, Black, Pink, White, Brown, Yellow and Green. Every person likes only one color but not necessarily in the same order. All these eight people are sitting in a row facing North direction. It is known that A is sitting four places away from C who likes Brown. None of these two is sitting at the extreme position. F likes White and sitting to the immediate right of H. Only E is sitting to the left of D, who doesn't like Red or Yellow. G likes Black and is sitting at the extreme end but not adjacent to the person who likes Brown. B, who likes Green, is not sitting between F and H. A likes Pink. D is not sitting adjacent to the person who likes Red.



                    Home()
Bank & Insurance
                    Reasoning(Ability)
                    Quiz()
Time Left - 07 : 42 sec

IBPS: Seating Arrangement & Input - Output: 04.09.2018
Attempt now to get your rank among 4761 students!

                    Question(1)

Directions: Study the following information to answer the given questions. 
A word and number arrangement machine when given an input line of words and numbers rearranges them following a particular rule. The following is an illustration of input and rearrangement. (Single digit numbers are preceded by a zero. All other numbers are two digit numbers) 
Input : when 19 will you 07 be 40 coming 62 home 100 89 
Step I : be when 19 will you 07 40 coming 62 home 100 89 
Step II : be 07 when 19 will you 40 coming 62 home 100 89 
Step III : be 07 coming when 19 will you 40 62 home 100 89 
Step IV : be 07 coming 19 when will you 40 62 home 100 89 
Step V:be 07 coming 19 home when will you 40 62 100 89 
Step VI : be 07 coming 19 home 40 when will you 62 100 89 
Step VII : be 07 coming 19 home 40 when 62 will you 100 89 
Step VIII : be 07 coming 19 home 40 when 62 will 89 you 100 
Step VIII is the last step of the arrangement of the above input as the intended arrangement is obtained. 
As per the rules followed in the above steps, find out in each of the following questions the appropriate steps for the given input.
Input : next 57 problem 82 14 trend 02 purchase growth 41 
How many steps would be needed to complete the arrangement?
                    a()
                    V()
                    b()
                    VI()
                    c()
                    VIII()
                    d()
                    VII()
                    e()
Cannot be determined
                    Question(2)

Directions: Study the following information to answer the given questions. 
A word and number arrangement machine when given an input line of words and numbers rearranges them following a particular rule. The following is an illustration of input and rearrangement. (Single digit numbers are preceded by a zero. All other numbers are two digit numbers) 
Input : when 19 will you 07 be 40 coming 62 home 100 89 
Step I : be when 19 will you 07 40 coming 62 home 100 89 
Step II : be 07 when 19 will you 40 coming 62 home 100 89 
Step III : be 07 coming when 19 will you 40 62 home 100 89 
Step IV : be 07 coming 19 when will you 40 62 home 100 89 
Step V:be 07 coming 19 home when will you 40 62 100 89 
Step VI : be 07 coming 19 home 40 when will you 62 100 89 
Step VII : be 07 coming 19 home 40 when 62 will you 100 89 
Step VIII : be 07 coming 19 home 40 when 62 will 89 you 100 
Step VIII is the last step of the arrangement of the above input as the intended arrangement is obtained. 
As per the rules followed in the above steps, find out in each of the following questions the appropriate steps for the given input.
Input : next 57 problem 82 14 trend 02 purchase growth 41 
Which of the following would be the final arrangement?
                    a()
growth 02 next 14 problem 41 purchase 57 82 trend
                    b()
growth next problem purchase trend 02 14 41 57 82
                    c()
growth 02 next 14 problem 41 purchase 57 trend 82
                    d()
growth 82 next 57 purchase 41 problem 14 next 02
                    e()
None of the above
                    Question(3)

Which of the following would be step I ?
                    a()
41 purchase 02 trend 14 82 problem 57 next growth
                    b()
growth 02 next 57 problem 82 14 trend purchase 41
                    c()
41 growth next 57 problem 82 14 trend 02 purchase
                    d()
growth next 57 problem 82 14 trend 02 purchase 41
                    e()
growth next 57 purchase 82 14 trend 02 problem 41
                    Question(4)

Directions: Study the following information to answer the given questions. 
A word and number arrangement machine when given an input line of words and numbers rearranges them following a particular rule. The following is an illustration of input and rearrangement. (Single digit numbers are preceded by a zero. All other numbers are two digit numbers) 
Input : when 19 will you 07 be 40 coming 62 home 100 89 
Step I : be when 19 will you 07 40 coming 62 home 100 89 
Step II : be 07 when 19 will you 40 coming 62 home 100 89 
Step III : be 07 coming when 19 will you 40 62 home 100 89 
Step IV : be 07 coming 19 when will you 40 62 home 100 89 
Step V:be 07 coming 19 home when will you 40 62 100 89 
Step VI : be 07 coming 19 home 40 when will you 62 100 89 
Step VII : be 07 coming 19 home 40 when 62 will you 100 89 
Step VIII : be 07 coming 19 home 40 when 62 will 89 you 100 
Step VIII is the last step of the arrangement of the above input as the intended arrangement is obtained. 
As per the rules followed in the above steps, find out in each of the following questions the appropriate steps for the given input.
Input : next 57 problem 82 14 trend 02 purchase growth 41 
Which word/number would be the sixth position from the left end in step III ?
                    a()
                    purchase()
                    b()
14:
                    c()
                    problem()
                    d()
41:
                    e()
                    trend()
                    Question(5)

Directions: Study the following information to answer the given questions. 
A word and number arrangement machine when given an input line of words and numbers rearranges them following a particular rule. The following is an illustration of input and rearrangement. (Single digit numbers are preceded by a zero. All other numbers are two digit numbers) 
Input : when 19 will you 07 be 40 coming 62 home 100 89 
Step I : be when 19 will you 07 40 coming 62 home 100 89 
Step II : be 07 when 19 will you 40 coming 62 home 100 89 
Step III : be 07 coming when 19 will you 40 62 home 100 89 
Step IV : be 07 coming 19 when will you 40 62 home 100 89 
Step V:be 07 coming 19 home when will you 40 62 100 89 
Step VI : be 07 coming 19 home 40 when will you 62 100 89 
Step VII : be 07 coming 19 home 40 when 62 will you 100 89 
Step VIII : be 07 coming 19 home 40 when 62 will 89 you 100 
Step VIII is the last step of the arrangement of the above input as the intended arrangement is obtained. 
As per the rules followed in the above steps, find out in each of the following questions the appropriate steps for the given input.
Input : next 57 problem 82 14 trend 02 purchase growth 41 
Input : just 14 and value 22 time 5 15 
Which word/number would be at position 5 from the right end in step III ?
                    a()
and
                    b()
15:
                    c()
                    just()
                    d()
14:
                    e()
                    time()
                    Question(6)

Direction: Study the information given below and answer the questions based on it. 

U, V, W, X, Y, Z, A and B are seated in a straight line but not necessarily in the same order. Some of them are facing South while some are facing North. U sits fourth to left of Z. Z sits at one of the extreme ends of the line. Both the immediate neighbours of U face North. V sits second to left of B. B is not an immediate neighbor of U. Neither B nor W sits at the extreme end of the line. W faces opposite direction to X. Both the immediate neighbors of W face North. Y sits to immediate left of A. Immediate neighbours of X face opposite directions (i.e. if one neighbour of X faces North then the other faces South and vice-versa). Immediate neighbours of V face opposite directions (i.e. if one neighbor of V faces North then the other faces South and vice-versa). People sitting at the extreme ends face the opposite directions (i.e. if one person faces North then the other faces South and vice-versa). X faces to south direction.
Which of the following seated at both ends?
                    a()
                    Z, a
                    b()
                    X, a
                    c()
                    W, V
                    d()
                    a, b
                    e()
None of these
                    Question(7)

Direction: Study the information given below and answer the questions based on it. 

U, V, W, X, Y, Z, A and B are seated in a straight line but not necessarily in the same order. Some of them are facing South while some are facing North. U sits fourth to left of Z. Z sits at one of the extreme ends of the line. Both the immediate neighbours of U face North. V sits second to left of B. B is not an immediate neighbor of U. Neither B nor W sits at the extreme end of the line. W faces opposite direction to X. Both the immediate neighbors of W face North. Y sits to immediate left of A. Immediate neighbours of X face opposite directions (i.e. if one neighbour of X faces North then the other faces South and vice-versa). Immediate neighbours of V face opposite directions (i.e. if one neighbor of V faces North then the other faces South and vice-versa). People sitting at the extreme ends face the opposite directions (i.e. if one person faces North then the other faces South and vice-versa). X faces to south direction.
How many person(s) are seated between V and Z?
                    a()
                    Four()
                    b()
More than four
                    c()
                    One()
                    d()
                    Three()
                    e()
                    Two()
                    Question(8)

Direction: Study the information given below and answer the questions based on it. 

U, V, W, X, Y, Z, A and B are seated in a straight line but not necessarily in the same order. Some of them are facing South while some are facing North. U sits fourth to left of Z. Z sits at one of the extreme ends of the line. Both the immediate neighbours of U face North. V sits second to left of B. B is not an immediate neighbor of U. Neither B nor W sits at the extreme end of the line. W faces opposite direction to X. Both the immediate neighbors of W face North. Y sits to immediate left of A. Immediate neighbours of X face opposite directions (i.e. if one neighbour of X faces North then the other faces South and vice-versa). Immediate neighbours of V face opposite directions (i.e. if one neighbor of V faces North then the other faces South and vice-versa). People sitting at the extreme ends face the opposite directions (i.e. if one person faces North then the other faces South and vice-versa). X faces to south direction.
Who among the following sit second to the left of X?
                    a()
                    U()
                    b()
                    a()
                    c()
                    b()
                    d()
                    Y()
                    e()
None of these
                    Question(9)

Direction: Study the information given below and answer the questions based on it. 

U, V, W, X, Y, Z, A and B are seated in a straight line but not necessarily in the same order. Some of them are facing South while some are facing North. U sits fourth to left of Z. Z sits at one of the extreme ends of the line. Both the immediate neighbours of U face North. V sits second to left of B. B is not an immediate neighbor of U. Neither B nor W sits at the extreme end of the line. W faces opposite direction to X. Both the immediate neighbors of W face North. Y sits to immediate left of A. Immediate neighbours of X face opposite directions (i.e. if one neighbour of X faces North then the other faces South and vice-versa). Immediate neighbours of V face opposite directions (i.e. if one neighbor of V faces North then the other faces South and vice-versa). People sitting at the extreme ends face the opposite directions (i.e. if one person faces North then the other faces South and vice-versa). X faces to south direction.
Who amongst the following sits exactly between B and V?
                    a()
                    a()
                    b()
                    X()
                    c()
                    Y()
                    d()
                    W()
                    e()
None of these
                    Question(10)

Direction: Study the information given below and answer the questions based on it. 

U, V, W, X, Y, Z, A and B are seated in a straight line but not necessarily in the same order. Some of them are facing South while some are facing North. U sits fourth to left of Z. Z sits at one of the extreme ends of the line. Both the immediate neighbours of U face North. V sits second to left of B. B is not an immediate neighbor of U. Neither B nor W sits at the extreme end of the line. W faces opposite direction to X. Both the immediate neighbors of W face North. Y sits to immediate left of A. Immediate neighbours of X face opposite directions (i.e. if one neighbour of X faces North then the other faces South and vice-versa). Immediate neighbours of V face opposite directions (i.e. if one neighbor of V faces North then the other faces South and vice-versa). People sitting at the extreme ends face the opposite directions (i.e. if one person faces North then the other faces South and vice-versa). X faces to south direction.


Time Left - 09 : 55 sec

Super 7 IBPS PO: Puzzles & Seating Arrangement
Attempt now to get your rank among 8176 students!

                    Question(1)

Direction: Read the following information carefully to answer the following questions.

M, N, O, P, Q, R, S and T are studying in VIII, IX and X classes. Not more than three students are there in one class. Each of them has a favourite subjects, viz, Hindi, Computer, English, History, Mathematics, Sanskrit, Science and Gk, but not necessarily in the same order. 

N is not in the IX class. Q and M are students of in a same class but not with N. O and R are students of the same class. The students who study in the VIII class do not like Science and Mathematics. R likes Computer. P likes Sanskrit and is in X class only with T. O does not like Hindi. History is the favourite subject of M. S does not like Science. The one who studies in the X class likes English.



Directions: Study the following information carefully and answer the questions given below: 
Eight friends A, B, C, D, E, F, G and H like different colors namely Red, Blue, Black, Pink, White, Brown, Yellow and Green. Every person likes only one color but not necessarily in the same order. All these eight people are sitting in a row facing North direction. It is known that A is sitting four places away from C who likes Brown. None of these two is sitting at the extreme position. F likes White and sitting to the immediate right of H. Only E is sitting to the left of D, who doesn't like Red or Yellow. G likes Black and is sitting at the extreme end but not adjacent to the person who likes Brown. B, who likes Green, is not sitting between F and H. A likes Pink. D is not sitting adjacent to the person who likes Red.


Directions: Study the following information and answer the questions.
Nilesh, Sneha, Mohan, Sushil, Teena, Aman, Varun and Vikas are sitting in a straight line but not necessarily in the same order. Some of them are facing south while the remaining are facing north.
Sneha and Aman face opposite directions and Aman sits fourth to the right of Sneha. Varun sits second to the left of Teena. The immediate neighbour of Sushil face same direction as Sushil. Nilesh sits second to the left of Aman. The immediate neighbour of Nilesh faces the same direction as Varun. Vikas is not an immediate neighbour of Varun. Both the immediate neighbours of Sneha face opposite directions. One of the immediate neighbour of Vikas faces north. Teena is not third from the right end if we face north. Mohan is at the fourth position with respect to Nilesh. Vikas is not facing south. Both the immediate neighbours of Varun face same direction. Varun is third to the right of Sneha. Mohan is not facing north.

Eight people J, K, L, M, N, P, Q and O are sitting in a circle facing the center. All of them are CEO of different companies — A, B, C, D, E, F, G and H. They are not necessarily seated in the mentioned order. Two persons sit between the one who is CEO of company D and N. K is CEO of company C. J is CEO of company A and sits opposite to N. The one who is CEO of company E sits opposite to M. O is CEO of company G and sits second to the right of the one who is CEO of company D. L is CEO of company E. L is an immediate neighbor of the person who is CEO of company F. Q sits third right to K. M is CEO of company D. The person who is CEO of company H sits adjacent to the one who is CEO of company D. N is CEO of company B.



Twelve persons attended a meeting on either 19th or 28th in six different months of the same year from January to June. B and A attended meeting in same month having 31 days. C attended meeting before F and both of them attended meeting on same date but not in consecutive months. Two persons attended between E and G and both of them attended before K. The number of persons attending between E and B is same as between B and H. K attended on 19th April. L and J attended in same month. H did not attend meeting in June. B did not attend on even date. The number of persons attending meeting before I is same as the number of persons attending meeting after D. The number of persons between I and F is double the number of persons between F and L.

Eight persons are sitting around a square table such that two persons sit on each side of the table. Each of them either have 9 or 10 toffees. B who has 10 toffees sits 4th left to A. None of the persons having 9 toffees sit together. Not more than one person sit between H and E. Not less than three persons have same number of toffees. F faces C and both have same toffees as A. Only one person sit between F and G. G is not neighbor of B. D has odd number of toffees. E is not 3rd right to A. Two persons sit between B and H.

Seven persons are born in different months of the same year starting from January and ending in July. They like either apple or mango. None of the persons liking apple are born in consecutive months. Two persons are born between A and D, who is born after A. A is not born in march. Three persons were born between E and B. G was born in one of the months before C. Not more than one person is born between A and E. F was born in June and likes apple. D is not born in may. D and A like same fruit but opposite to the one who was born in may.


A certain number of persons are standing in a row facing north. Q stands at one of the end of the row. As many persons are standing between Rand T as between S and R. Eight persons are standing between S and P. Only 1 person stands between Q and S.P is 3rd from one of the end. L is 5th to the left of R. More than 6 persons are standing between Q and T. Not more than 5 persons are standing between P and L.
Eight persons are sitting in two parallel rows as per the following arrangement.

The persons are at different designations in a company i.e. GM, DGM, AGM, CM, SM, manager, officer, clerk. The designation mentioned are in decreasing order of seniority. The persons who are immediate senior or immediate junior do not sit in same row or face each other. The senior most person faces the 3rd most junior person. The 2nd most junior faces the 4th most senior person. Only one person sits between the one who is CM and the one who is DGM. The junior most person neither faces south nor sits at any end. The ones sitting at right ends are at immediate designation to each other. The one who is officer is 3rd from the left end.
Seven friends – P, Q, R, S, T, U and V have seated in a square table having 8 seats. Some of them are seated at the corner of the table while some of them have seated at the centre of the table. One seat is vacant. Some of them face towards the centre and some faces away from the centre. The friends are from different states viz. Jaipur, Rajasthan, Chennai, Pune, Punjab, Delhi and Hyderabad and have different hobbies viz. Singing, Reading, Dancing, Writing, Painting, Colouring and Cooking but not necessarily in the same order.
The persons from Chennai and Jaipur sit together and U does not belong to any of these states. The one from Rajasthan sits second to the left of U who likes Reading. Q sits immediate left of R but does not sit on any of the corner. S faces the direction similar to that of V but opposite to that of P. R is from either Hyderabad or Punjab. The one who likes Singing sits immediate right of the one who likes Reading. Neither V nor P is from Chennai. The one from Punjab sits third to the left of Q. U and V sit opposite to each other and faces away from each other. The one who is from Chennai likes Colouring. The one who likes Cooking sits fourth to the right of the one who likes Dancing. T is from Delhi and faces towards the centre and is the only one sitting between P and S on a side. The one who likes Dancing sits immediate left of S. V does not like Painting. The person from Punjab sits diagonally opposite to the one who likes painting.

Eight persons – A, B, C, D, E, F, G and H are living in an eight storey building and are from different professions among Singer, Dancer, Teacher, Actor, Boxer, Politician, Engineer and Scientist but not necessarily in the same order.
G lives on the first floor and E lives on the third to the floor of G. The person who is a Singer is an immediate neighbour of E and E is not a Scientist. Neither B nor H is an immediate neighbour of E. C is an Actor. F is an Engineer and lives on the floor third to the floor of the person who is a Singer. H lives four floors above the floor of B. There is one floor between the person who is a Teacher and who is an Engineer. A is a Politician lives between F and H. The person who is a Boxer lives on the floor second to the floor of E. The persons who is an Actor and who is a Dancer are immediate neighbours.

             * 
U, V, W, X, Y, Z, A and B are seated in a straight line but not necessarily in the same order. Some of them are facing South while some are facing North. 
U sits fourth to left of Z. Z sits at one of the extreme ends of the line. Both the immediate neighbours of U face North. V sits second to left of B. 
B is not an immediate neighbor of U. Neither B nor W sits at the extreme end of the line. W faces opposite direction to X.
Both the immediate neighbors of W face North. Y sits to immediate left of A. Immediate neighbours of X face opposite directions (i.e. if one neighbour of X faces North then the other faces South and vice-versa).
Immediate neighbours of V face opposite directions (i.e. if one neighbor of V faces North then the other faces South and vice-versa).
People sitting at the extreme ends face the opposite directions (i.e. if one person faces North then the other faces South and vice-versa).
* X faces to south direction.
How many person(s) are seated between V and Z?

             * 
There are two seats between Q and the vacant seat. Q does not like White, Red and Purple. E is not an
immediate neighbor of C. B likes Grey. Vacant seat of row 1 is not opposite to S and is also not at any of
the extreme ends of Row-1.The one who likes Black sits opposite to the one, who sits third to the right of
the seat, which is opposite to S. C is not an immediate neighbor of D. T, who likes neither White nor Blue,
does not face vacant seat. D faces R. The vacant seats are not opposite to each other. Two seats are
there between C and B, who sits third right of the seat, on which the person who likes Brown is sitting. S
sits third to the right of seat on which R sits and likes Yellow. The one who likes Pink faces the one who
likes Yellow. The persons who like Red and Purple are adjacent to each other. The vacant seat in row 1 is
not adjacent to D.Q sits at one of the extreme ends. E neither likes Pink nor faces the seat which is
adjacent to the one who likes Blue. The one who likes White is not to the immediate right of the one who
likes Yellow. The person who likes Green doesn’t face the person who likes Purple.            

Directions (1 – 5): Answer the questions on the basis of the information given below.
Ten friends are sitting on twelve seats in two parallel rows containing five people each, in such a way that
there is an equal distance between adjacent persons. In Row 1: A, B, C, D and E are seated and all of
them are facing south, and in Row 2: P, Q, R, S and T are sitting and all of them are facing north. One
seat is vacant in each row. Therefore, in the given seating arrangement each member seated in a row
faces another member of the other row.
All of them like different colors – Red, Green, Black, Yellow, White, Blue, Brown, Purple, Pink and Grey,
but not necessarily in the same order.             
             * *              
             * 
Eight people – Swati, Prachi, Richa, Kavya, Sheena, Charu, Malika and Naira are sitting in a straight line
facing North. They have different ages – 10, 13, 15, 18, 25, 26, 31 and 40 but not necessarily in the same
order.
There are 2 persons sitting between Swati and the one whose age is 18 years. Neither of them is sitting at
an extreme end. The difference between the ages of Kavya and Malika is 3 years. Richa is sitting second
to right of one having age 18 years. Prachi is sitting third to left of one having age 31 years. There are
three girls sitting between Kavya and whose age is 18 years old. Prachi and Malika are immediate
neighbors. Richa is not 31 years old. There are at least 4 persons sitting to the right of Kavya. Naira and
the one having age 18 years are immediate neighbors. The one who is 31 years old is not sitting at
second position from any end. Sheena is 3 years older than Swati. Charu is one year older than Richa.             
             * 
The persons are at different designations in a company i.e. GM, DGM, AGM, CM, SM, manager, officer, clerk. The designation mentioned are in decreasing order of 
seniority. The persons who are immediate senior or immediate junior do not sit in same row or face each other.
 The senior most person faces the 3rd most junior person. The 2nd most junior faces the 4th most senior person. 
  Only one person sits between the one who is CM and the one who is DGM. 
   The junior most person neither faces south nor sits at any end. The ones sitting at right ends are at immediate designation to each other. 
  The one who is officer is 3rd from the left end.
Seven friends – P, Q, R, S, T, U and V have seated in a square table having 8 seats. Some of them are seated at the corner of the table while some of them have seated at the centre of the table. One seat is vacant. Some of them face towards the centre and some faces away from the centre. The friends are from different states viz. Jaipur, Rajasthan, Chennai, Pune, Punjab, Delhi and Hyderabad and have different hobbies viz. Singing, Reading, Dancing, Writing, Painting, Colouring and Cooking but not necessarily in the same order.
The persons from Chennai and Jaipur sit together and U does not belong to any of these states. The one from Rajasthan sits second to the left of U who likes Reading. Q sits immediate left of R but does not sit on any of the corner. S faces the direction similar to that of V but opposite to that of P. R is from either Hyderabad or Punjab. The one who likes Singing sits immediate right of the one who likes Reading. Neither V nor P is from Chennai. The one from Punjab sits third to the left of Q. U and V sit opposite to each other and faces away from each other. The one who is from Chennai likes Colouring. The one who likes Cooking sits fourth to the right of the one who likes Dancing. T is from Delhi and faces towards the centre and is the only one sitting between P and S on a side. The one who likes Dancing sits immediate left of S. V does not like Painting. The person from Punjab sits diagonally opposite to the one who likes painting.

             * 
Eight persons – A, B, C, D, E, F, G and H are living in an eight storey building and are from different professions among Singer, Dancer, Teacher, Actor, Boxer, 
Politician, Engineer and Scientist but not necessarily in the same order.
G lives on the first floor and E lives on the third to the floor of G. The person who is a Singer is an immediate neighbour of E and E is not a Scientist.
Neither B nor H is an immediate neighbour of E. C is an Actor. F is an Engineer and lives on the floor third to the floor of the person who is a Singer. 
H lives four floors above the floor of B. There is one floor between the person who is a Teacher and who is an Engineer.
A is a Politician lives between F and H. The person who is a Boxer lives on the floor second to the floor of E.
The persons who is an Actor and who is a Dancer are immediate neighbours.             
             * 
Twelve people are sitting in two parallel rows containing six people each in such a way that there is an equal distance between adjacent persons.
In row 1, A, B, C, D, E and F are sitting and all of them are facing South. In row 2, P, Q, R, S, T and V are sitting and all of them are facing North.
Therefore, in the given seating arrangement, each member of a row faces another member of the other row. V sits third to the right of S.
S faces F and F does not sit at any of the extreme ends of the lines. D sits third to the right of C. R faces E. The one facing E sits third to the right of P. 
B and P do not sit at the extreme ends of the lines. T is not an immediate neighbour of S and F is not an immediate neighbour of D.              
             * 
 M, N, O, P, J, I, G and H eight person lives on eight different floors of a building, but not necessarily in the same order. The lower most floor of the building is numbered 1, the one above that is numbered 2 and so on till the topmost floor is numbered 8. Each one of them likes different fruit i.e. Banana, Orange, Apple, Pear, Mango, Peach, Pineapple and Cherry, but not necessarily in the same order.
P lives above to the one who likes Pear but does not lives immediately above the one who likes Pear.
The one who likes Banana lives immediately below the one who likes Cherry.
The one who likes Apple lives immediately above O.
Only four persons lives between O and the one who likes Orange.
Only four persons lives between M and the one who likes Apple.
The one who likes Pineapple lives immediately above M.
O does not likes Cherry. The one who likes Mango lives immediately between H and G.
Neither H nor G lives topmost or ground floor.
Only three person lives between N and J. N lives on one of the floor below to J.             
             * 
A certain number of persons are standing in a row facing north. Q stands at one of the end of the row. As many persons are standing between Rand T as between S and R. 
Eight persons are standing between S and P. Only 1 person stands between Q and S.P is 3rd from one of the end. L is 5th to the left of R. More than 6 persons are standing between Q and T.
Not more than 5 persons are standing between P and L.
             * 

             * 
Eight Cetking students Ameer, Sally, Nalini, Madie, Ruchi, Omkar, Phani and Tanmay are sitting around a circular table. Three of them are facing the centre.
Ruchi is not an immediate neighbor of Madie or Nalini. The one who sits exactly between Madie and Omkar, who is not facing the centre. 
Phani is third to the right of Ameer and is facing the centre. Nalini is third to the left of Madie and both are facing the centre. 
Omkar is immediate neighbor of Ruchi but not the neighbor of Ameer. Sally is the neighbour of Omkar.                          
             * 
* Eight people J, K, L, M, N, P, Q and O are sitting in a circle facing the center. 
All of them are CEO of different companies — A, B, C, D, E, F, G and H. They are not necessarily seated in the mentioned order. 
Two persons sit between the one who is CEO of company D and N. K is CEO of company C. J is CEO of company A and sits opposite to N.
The one who is CEO of company E sits opposite to M. O is CEO of company G and sits second to the right of the one who is CEO of company D. 
L is CEO of company E. L is an immediate neighbor of the person who is CEO of company F. Q sits third right to K. M is CEO of company D.
The person who is CEO of company H sits adjacent to the one who is CEO of company D. N is CEO of company B.             
             * 

• C sits third to the left of H, who works at the Footwear stall, and both are facing the same direction.
• G sits on the immediate right of B, who works at the Cloth stall.
• C and B are not facing the same direction but C is an immediate neighbor of E, who is fourth to the left of G
• E and G both are facing opposite directions but both work at the same stall.
• Those who work at the Cloth stall sit adjacent to each other but face opposite directions.
• The person, who work at the Food stall sit opposite each other.
• The immediate neighbour of E are not facing outward.
• a person who works at the Footwear stall is an immediate neighbour of the both persons who work at the Book stall.
• D and F are immediate neighbour of H.
• D is not facing the centre and works at the Book stall.
• The one who is on the immediate left of F is not facing the centre. F sits second to the right of C.
Q1. Who among the following work at             
             * 

             * 

             * Eight people J, K, L, M, N, P, Q and O are sitting in a circle facing the center. All of them are CEO of different companies — A, B, C, D, E, F, G and H. They are not necessarily seated in the mentioned order. Two persons sit between the one who is CEO of company D and N. K is CEO of company C. J is CEO of company A and sits opposite to N. The one who is CEO of company E sits opposite to M. O is CEO of company G and sits second to the right of the one who is CEO of company D. L is CEO of company E. L is an immediate neighbor of the person who is CEO of company F. Q sits third right to K. M is CEO of company D. The person who is CEO of company H sits adjacent to the one who is CEO of company D. N is CEO of company B.



Twelve persons attended a meeting on either 19th or 28th in six different months of the same year from January to June. B and A attended meeting in same month having 31 days. C attended meeting before F and both of them attended meeting on same date but not in consecutive months. Two persons attended between E and G and both of them attended before K. The number of persons attending between E and B is same as between B and H. K attended on 19th April. L and J attended in same month. H did not attend meeting in June. B did not attend on even date. The number of persons attending meeting before I is same as the number of persons attending meeting after D. The number of persons between I and F is double the number of persons between F and L.

             * 
Eight persons are sitting around a square table such that two persons sit on each side of the table. Each of them either have 9 or 10 toffees. B who has 10 toffees sits 4th left to A. None of the persons having 9 toffees sit together. Not more than one person sit between H and E. Not less than three persons have same number of toffees. F faces C and both have same toffees as A. Only one person sit between F and G. G is not neighbor of B. D has odd number of toffees. E is not 3rd right to A. Two persons sit between B and H.

Seven persons are born in different months of the same year starting from January and ending in July. They like either apple or mango. None of the persons liking apple are born in consecutive months. Two persons are born between A and D, who is born after A. A is not born in march. Three persons were born between E and B. G was born in one of the months before C. Not more than one person is born between A and E. F was born in June and likes apple. D is not born in may. D and A like same fruit but opposite to the one who was born in may.


A certain number of persons are standing in a row facing north. Q stands at one of the end of the row. As many persons are standing between Rand T as between S and R. Eight persons are standing between S and P. Only 1 person stands between Q and S.P is 3rd from one of the end. L is 5th to the left of R. More than 6 persons are standing between Q and T. Not more than 5 persons are standing between P and L.
Eight persons are sitting in two parallel rows as per the following arrangement.

The persons are at different designations in a company i.e. GM, DGM, AGM, CM, SM, manager, officer, clerk. The designation mentioned are in decreasing order of seniority. The persons who are immediate senior or immediate junior do not sit in same row or face each other. The senior most person faces the 3rd most junior person. The 2nd most junior faces the 4th most senior person. Only one person sits between the one who is CM and the one who is DGM. The junior most person neither faces south nor sits at any end. The ones sitting at right ends are at immediate designation to each other. The one who is officer is 3rd from the left end.
Seven friends – P, Q, R, S, T, U and V have seated in a square table having 8 seats. Some of them are seated at the corner of the table while some of them have seated at the centre of the table. One seat is vacant. Some of them face towards the centre and some faces away from the centre. The friends are from different states viz. Jaipur, Rajasthan, Chennai, Pune, Punjab, Delhi and Hyderabad and have different hobbies viz. Singing, Reading, Dancing, Writing, Painting, Colouring and Cooking but not necessarily in the same order.
The persons from Chennai and Jaipur sit together and U does not belong to any of these states. The one from Rajasthan sits second to the left of U who likes Reading. Q sits immediate left of R but does not sit on any of the corner. S faces the direction similar to that of V but opposite to that of P. R is from either Hyderabad or Punjab. The one who likes Singing sits immediate right of the one who likes Reading. Neither V nor P is from Chennai. The one from Punjab sits third to the left of Q. U and V sit opposite to each other and faces away from each other. The one who is from Chennai likes Colouring. The one who likes Cooking sits fourth to the right of the one who likes Dancing. T is from Delhi and faces towards the centre and is the only one sitting between P and S on a side. The one who likes Dancing sits immediate left of S. V does not like Painting. The person from Punjab sits diagonally opposite to the one who likes painting.

Eight persons – A, B, C, D, E, F, G and H are living in an eight storey building and are from different professions among Singer, Dancer, Teacher, Actor, Boxer, Politician, Engineer and Scientist but not necessarily in the same order.
G lives on the first floor and E lives on the third to the floor of G. The person who is a Singer is an immediate neighbour of E and E is not a Scientist. Neither B nor H is an immediate neighbour of E. C is an Actor. F is an Engineer and lives on the floor third to the floor of the person who is a Singer. H lives four floors above the floor of B. There is one floor between the person who is a Teacher and who is an Engineer. A is a Politician lives between F and H. The person who is a Boxer lives on the floor second to the floor of E. The persons who is an Actor and who is a Dancer are immediate neighbours.

             * 
 M, N, O, P, J, I, G and H eight person lives on eight different floors of a building, but not necessarily in the same order. The lower most floor of the building is numbered 1, the one above that is numbered 2 and so on till the topmost floor is numbered 8. Each one of them likes different fruit i.e. Banana, Orange, Apple, Pear, Mango, Peach, Pineapple and Cherry, but not necessarily in the same order.
P lives above to the one who likes Pear but does not lives immediately above the one who likes Pear.
The one who likes Banana lives immediately below the one who likes Cherry.
The one who likes Apple lives immediately above O.
Only four persons lives between O and the one who likes Orange.
Only four persons lives between M and the one who likes Apple.
The one who likes Pineapple lives immediately above M.
O does not likes Cherry. The one who likes Mango lives immediately between H and G.
Neither H nor G lives topmost or ground floor.
Only three person lives between N and J. N lives on one of the floor below to J.


             * 
Ten friends are sitting on twelve seats in two parallel rows containing five people each, in such a way that
there is an equal distance between adjacent persons. In Row 1: A, B, C, D and E are seated and all of
them are facing south, and in Row 2: P, Q, R, S and T are sitting and all of them are facing north. One
seat is vacant in each row. Therefore, in the given seating arrangement each member seated in a row
faces another member of the other row.
All of them like different colors – Red, Green, Black, Yellow, White, Blue, Brown, Purple, Pink and Grey,
but not necessarily in the same order. 
There are two seats between Q and the vacant seat. Q does not like White, Red and Purple. E is not an
immediate neighbor of C. B likes Grey. Vacant seat of row 1 is not opposite to S and is also not at any of
the extreme ends of Row-1.The one who likes Black sits opposite to the one, who sits third to the right of
the seat, which is opposite to S. C is not an immediate neighbor of D. T, who likes neither White nor Blue,
does not face vacant seat. D faces R. The vacant seats are not opposite to each other. Two seats are
there between C and B, who sits third right of the seat, on which the person who likes Brown is sitting. S
sits third to the right of seat on which R sits and likes Yellow. The one who likes Pink faces the one who
likes Yellow. The persons who like Red and Purple are adjacent to each other. The vacant seat in row 1 is
not adjacent to D.Q sits at one of the extreme ends. E neither likes Pink nor faces the seat which is
adjacent to the one who likes Blue. The one who likes White is not to the immediate right of the one who
likes Yellow. The person who likes Green doesn’t face the person who likes Purple.               
             * 
D is sitting fourth to right of B. The person who likes Yellow sits second to right of D. A is sitting third to
right of C. There is one person sitting between A and B. A does not like Yellow color. Three persons sit
between the person who like Yellow and Pink color. The person who likes Green color sits second to right
of person who like Pink color. D does not like Green color. The person who likes Blue sits third to right of
person who like Green color. C likes Blue color. There are two persons sitting between D and E. There
are three persons between the person who like White and Black color. E does not like White and Black
color. There is one person sitting between the person who like Black and Red color. The person who likes
Yellow color sits third to right of person who like Red color. The person who likes Grey color sits third to
right of person who like Black color. G sits fourth to right of person who like White color. F is not
immediate neighbor of G. The person who like White color sits third to left of person who like Yellow color
and both faces the same direction.(Same direction means if one faces center then other also faces the
center and vice-versa).E faces opposite the center. A likes the Pink color.              
             * 
Eight persons – A, B, C, D, E, F, F, G and H are sitting in a straight line facing North (not necessarily in
the same order). They have different ages – 12, 18, 27, 32, 34, 49, 55 and 63 (not necessarily in the same
order).
B is sitting second to left of one having age 49 years. Two persons are sitting between B and D. One who
is 32 years old is sitting second to right of D. One person is sitting between the persons having ages 32
and 18 years. A is sitting second to left of E. A is sitting somewhere to the left of D. The one who is 63
years old is sitting to immediate left of B. Difference between the ages of B and G is 7 years. Both are not
sitting together. One who is 27 years old is sitting somewhere left of A. C is 6 years younger to D. The one
who is 55 years old and H are immediate neighbors. Same number of persons are sitting between H and
one having age 34 years and between F and one having age 55 years.             
             *              
             * 
             * 

             * 

Eight people – Swati, Prachi, Richa, Kavya, Sheena, Charu, Malika and Naira are sitting in a straight line
facing North. They have different ages – 10, 13, 15, 18, 25, 26, 31 and 40 but not necessarily in the same
order.
There are 2 persons sitting between Swati and the one whose age is 18 years. Neither of them is sitting at
an extreme end. The difference between the ages of Kavya and Malika is 3 years. Richa is sitting second
to right of one having age 18 years. Prachi is sitting third to left of one having age 31 years. There are
three girls sitting between Kavya and whose age is 18 years old. Prachi and Malika are immediate
neighbors. Richa is not 31 years old. There are at least 4 persons sitting to the right of Kavya. Naira and
the one having age 18 years are immediate neighbors. The one who is 31 years old is not sitting at
second position from any end. Sheena is 3 years older than Swati. Charu is one year older than Richa.             
             * 
Eight people – Priya, Isha, Megha, Ruchi, Bhavya, Priti and Trisha are sitting in a straight line facing
North. They have different ages – 12, 16, 18, 21, 26, 33, 45 and 50 but not necessarily in the same order.
Isha is sitting second to left the one who is 33 years old. 2 persons are sitting between Isha and Priti.
Three people are sitting between Priya and the one who is 26 years old. Trisha is immediate neighbor of
Isha. One who is 12 years younger than the one having age 33 years is sitting third to right of her. Bhavya
and Priti have 2 years difference in their respective ages. One person is sitting between Bhavya and Priti.
Ruchi is sitting second to the right of one having age 45 years. Priya is sitting immediate right of the one
who is 18 years old. Age difference between Priya and Trisha is more than 16 years. Shikha is nine years
older than Isha.
1. Who is sitting third to right of Bhavya?
             *
There are two seats between Q and the vacant seat. Q does not like White, Red and Purple. E is not an
immediate neighbor of C. B likes Grey. Vacant seat of row 1 is not opposite to S and is also not at any of
the extreme ends of Row-1.The one who likes Black sits opposite to the one, who sits third to the right of
the seat, which is opposite to S. C is not an immediate neighbor of D. T, who likes neither White nor Blue,
does not face vacant seat. D faces R. The vacant seats are not opposite to each other. Two seats are
there between C and B, who sits third right of the seat, on which the person who likes Brown is sitting. S
sits third to the right of seat on which R sits and likes Yellow. The one who likes Pink faces the one who
likes Yellow. The persons who like Red and Purple are adjacent to each other. The vacant seat in row 1 is
not adjacent to D.Q sits at one of the extreme ends. E neither likes Pink nor faces the seat which is
adjacent to the one who likes Blue. The one who likes White is not to the immediate right of the one who
likes Yellow. The person who likes Green doesn’t face the person who likes Purple.            

Directions (1 – 5): Answer the questions on the basis of the information given below.
Ten friends are sitting on twelve seats in two parallel rows containing five people each, in such a way that
there is an equal distance between adjacent persons. In Row 1: A, B, C, D and E are seated and all of
them are facing south, and in Row 2: P, Q, R, S and T are sitting and all of them are facing north. One
seat is vacant in each row. Therefore, in the given seating arrangement each member seated in a row
faces another member of the other row.
All of them like different colors – Red, Green, Black, Yellow, White, Blue, Brown, Purple, Pink and Grey,
but not necessarily in the same order.             
             * * 

10 friends sitting in a restaurant , five of them i.e. Amar, Vimal, Diwan, Raj and Renu are sitting in a row facing
North and the other five friends Seetha, Padma, Manu, Ramu and Tilak are sitting in row facing south. Each friend
in row is facing exactly one from the other row. One of them likes grapes. Seetha sits opposite the friend who likes
a banana and sits at one of the extremes. The friend who likes kiwi who is not Manu sits second to the right of
Seetha. Tilak sits exactly in the middle of Manu and the friend who likes a cherry who is not Seetha. Vimal who
does not sit at extreme end and likes an orange and sits opposite the friend who likes an apple. The one who likes
pineapple sits opposite the friend who is to the immediate left of Vimal. The friend who likes a strawberry who is
not Diwan sits opposite Ramu. Padma does not sit at any of the extremes but sits opposite the friend who likes a
guava, who is adjacent to Amar and the friend who likes a mango. Raj neither likes a guava nor likes a
strawberry.
16. Who likes             
             * 
             * 
             * 
             * 

           A, B, C, D, E, F, G and H are sitting in a straight line equidistant from each other (but not necessarily in the same
order). Some of them are facing south while some are facing north.
(Note: Facing the same direction means, if one is facing north then the other is also facing north and vice versa.
Facing the opposite directions means if one is facing north then the other is facing south and vice versa.)
H faces north. C sits at one of the extreme ends of the line. A sits third to the left of C. D is not an immediate
neighbor of C. G sits third to the right of A. B sits on the immediate right of G. B does not sit at any of the extreme
ends of the line. Only one person sits between F and D. G sits second to the left of F. E sits second to the right of
B. Both the immediate neighbors of G face the same direction. Both the immediate neighbors of A face the
opposite directions. E faces the same directions as B.
             * 
             * 
             * 
Eight friends Heena, Chandan, Nita, Gaurav, Bhavesh, Pranav, Dinesh and Isha are sitting in a row facing north.
All of them like different colours, viz Red, Pink, Orange, Green, Yellow, Black, Violet and Blue.
· There is only one person between Nita and the one who likes violet.
· Dinesh is neither an immediate neighbor of Nita nor he likes Green.
· Heena sits fourth to the left of the one who likes Violet but she does not like Pink
· The person who likes Black is third to the right of the one who likes Green and sits on the immediate right of
Heena.
· The one who likes Green sits at one of the extreme ends of the row. Chandan does not like Green.
· Pranav is an immediate neighbor of both Dinesh and Nita.
· Isha sits at one of the extreme ends of the row but she does not like Green
· The one who likes Blue sits second to the right of the one who likes Orange.
· The ones who like Black and Pink are immediate neighbours
· Bhavesh sits third to the left of Nita and likes Yellow.
· There is only one person between the persons who like Yellow and Black.



             * 

        Eight people J, K, L, M, N, P, Q and O are sitting in a circle facing the center. 
         All of them are CEO of different companies — A, B, C, D, E, F, G and H. They are not necessarily seated in the mentioned order. 
         Two persons sit between the one who is CEO of company D and N. K is CEO of company C. J is CEO of company A and sits opposite to N. 
          The one who is CEO of company E sits opposite to M. O is CEO of company G and sits second to the right of the one who is CEO of company D.
          L is CEO of company E. L is an immediate neighbor of the person who is CEO of company F. Q sits third right to K. M is CEO of company D. 
          The person who is CEO of company H sits adjacent to the one who is CEO of company D. N is CEO of company B.

             * 
              -
       -              -

     -                  -      

       -      -       -             
             *
             */
            for (int r = 0; r <= GridView1.Rows.Count - 1; r++)
            {
                if (GridView1.Rows[r].RowType == DataControlRowType.DataRow)
                {

                    CheckBox cb1 = (CheckBox)GridView1.Rows[r].FindControl("chk");
                    TextBox Slip_No = (TextBox)GridView1.Rows[r].FindControl("txtSlipNo");
                    TextBox Cost = (TextBox)GridView1.Rows[r].FindControl("txtCost");
                    Label Cost_Center = (Label)GridView1.Rows[r].FindControl("lblCostCenter");
                    TextBox User_RefNo = (TextBox)GridView1.Rows[r].FindControl("txtUserRefNo");
                    cb1.Enabled = false;
                    ddlCourierType.Enabled = false;
                    ddlCourierService.Enabled = false;
                    ddlDeliveryType.Enabled = false;
                    Slip_No.Enabled = false;
                    Cost.Enabled = false;
                    User_RefNo.Enabled = false;
                }
            }
        }
    }
    /*

   Ten persons P, Q, R, S, T, U, V, W, X and Y stay on a 9-floor building where only one person stays on each floor except on third floor but not necessary in the same order.
 Their flats are painted with different colour I.e. White, Black, Red, Pink, Yellow, Green, Violet, Blue, and Brown.
 But not necessary in the same order. The colour of the floor on which a person lives and his favourite colour are same, 
 (he likes the same colour as his flat is painted)

R stays on an odd number floor below the floor number 5 and 5th floor is painted with white colour. 
 There are three floors between white colour and Green colour. P stay above R and does not stay on odd number floor and like brown colour.
 Y stay on 8th floor and there are three floors between Y and the flat which is painted by Black colour. 
 T does not stay on an even number floor and neither like white colour nor like violet colour.
 Q lives below R and his flat painted with Green colour. P does not stay immediate above or below Y who does not like blue and yellow colour. 
 S stays above the floor of Q and below P. S does not like Black and Violet colour. R’s floor does not painted with violet colour.
 S and U stay on consecutive floors. There are three floors between yellow and Red colour flat.
 Pink colour flat is just above yellow colour flat. W and V stay alone. T doesn’t stay on top floor and doesn’t like red colour painted flat.

     Directions (11-16): Study the following information carefully and answer the questions given below
Eight friends Heena, Chandan, Nita, Gaurav, Bhavesh, Pranav, Dinesh and Isha are sitting in a row facing north.
All of them like different colours, viz Red, Pink, Orange, Green, Yellow, Black, Violet and Blue.
· There is only one person between Nita and the one who likes violet.
· Dinesh is neither an immediate neighbor of Nita nor he likes Green.
· Heena sits fourth to the left of the one who likes Violet but she does not like Pink
· The person who likes Black is third to the right of the one who likes Green and sits on the immediate right of
Heena.
· The one who likes Green sits at one of the extreme ends of the row. Chandan does not like Green.
· Pranav is an immediate neighbor of both Dinesh and Nita.
· Isha sits at one of the extreme ends of the row but she does not like Green
· The one who likes Blue sits second to the right of the one who likes Orange.
· The ones who like Black and Pink are immediate neighbours
· Bhavesh sits third to the left of Nita and likes Yellow.
· There is only one person between the persons who like Yellow and Black.
     * 
     * 
     * 
     * 
 Ten persons P, Q, R, S, T, U, V, W, X and Y stay on a 9-floor building where only one person stays on each floor except on third floor but not necessary in the same order.
 Their flats are painted with different colour I.e. White, Black, Red, Pink, Yellow, Green, Violet, Blue, and Brown.
 But not necessary in the same order. The colour of the floor on which a person lives and his favourite colour are same, 
 (he likes the same colour as his flat is painted)

R stays on an odd number floor below the floor number 5 and 5th floor is painted with white colour. 
 There are three floors between white colour and Green colour. P stay above R and does not stay on odd number floor and like brown colour.
 Y stay on 8th floor and there are three floors between Y and the flat which is painted by Black colour. 
 T does not stay on an even number floor and neither like white colour nor like violet colour.
 Q lives below R and his flat painted with Green colour. P does not stay immediate above or below Y who does not like blue and yellow colour. 
 S stays above the floor of Q and below P. S does not like Black and Violet colour. R’s floor does not painted with violet colour.
 S and U stay on consecutive floors. There are three floors between yellow and Red colour flat.
 Pink colour flat is just above yellow colour flat. W and V stay alone. T doesn’t stay on top floor and doesn’t like red colour painted flat.

     * 
     A, B, C, D, E, F, G and H are sitting around a square table in Maharaja Hotel in Delhi for breakfast in such a way
that four of them sit at four corners of the square table while other four sit in the middle of each of the four sides of
table. The one who sits at the four corners faces towards the center of the table while those who sit in the middle
of the sides face outside. Each of them ordered a different food items, viz Coffee, Tea, Halwa, Kulfi, Barfi,
Samosa, Jalebi and Rasmalai but not necessarily in the same order. C sits third to the left of the one who orders
Rasmalai . The one who orders Rasmalai faces outside. Only two persons sit between C and H. The one who
orders Coffee sits on the immediate right of H. The one who orders Barfi sits second to the right of G. G is neither
an immediate neighbour of H nor of C. G does not order Rasmalai . Only one person sits between A and the one
     who orders Barfi . D sits on the immediate left of the one who orders Samosa. G does not order Samosa. E orders
Jalebi. E is not an immediate neighbour of A. The one who orders Tea is an immediate neighbour of E. The one
who orders Kulfi is an immediate neighbour of F.
     * 
     * 
     * 
In a college, there are 8 professors, P, Q, R, S, T, U, V and W of 8 different subjects, philosophy, psychology, geography, economics, algebra, French, German, 
    and Arabic not necessarily in the same order. 
They are sitting around a circular table facing the centre of the circle at an equal distance.
U is third to the left of the professor of economics, who is opposite to one who is second to the right from R.
The professor of German is not near to P but near the one who is opposite to R.
W and Q are adjacent to each other but both of them are not professor of French. 
The professor of philosophy is second to the left of the professor of Arabic, who is next to the professor of German and V. 
the professor of French is seated opposite to V. The professor of geography is neither S nor near to R.
The professor of Psychology is third to the right of W






     There are eight members A, B, C, D, E, F, G, H, all are seated in row and facing to north (but not
necessarily in the same order). They like different numbers i.e. 60, 55, 121, 36, 18, 30, 37, and 17 (but not
necessarily n the same order).
The one, who likes a prime number, sits third from left end of the row and F is the immediate neighbour
of the person who sits third from the left end. A and C are immediate neighbors of each other. H, sits
2:
nd to the left of B. The one, who sits 2nd to the right of the one, who likes 36 number, likes the
palindrome number which is divisible by 11. The one who likes 60 sits 5th left of the one, who likes 121.
B sits at extreme end of the row. F likes a number which is a perfect square but not a palindrome
number. The number which is liked by A is double of the number which is liked by C. B sits 4th to the
right of F. G likes the number which is half of the number, which is liked by F. G sits left of both B and
H. B likes a palindrome number which is divisible by both 11 and 5. D sits right of F and D does not
like the prime number which is less than 35.


     Eight friends A, B, C, D, E, F, G and H are sitting around a circular table, but not necessarily in the same
order. All friends are facing the centre. Each person has different salaries i.e.1400, 1600, 1500, 76641,
25547, 86543, 87000, and 91000 but not necessarily in the same order.
F sits at 135 ? clockwise direction to B. Salary of the one, who sits 2nd to right of B is an odd number
which is divisible by 3. There is an angle of 135 ?between A and G. B’s salary is average of H’s and D’s
salary. There is an angle of 90 ?between A and H. D is not an immediate neighbor of the one whose
salary is 76641. G’s salary is 1/3rd of A’s salary. There is an angle of 180 ?between B and the one whose
salary is perfect square. H is not an immediate neighbor of the one, whose salary is 25547. C’s salary is
2:
nd largest salary among all the salaries. There is an angle of 180 ?between F and E, whose salary is an
odd number. B sits at 90 ?clockwise direction of A. 


     Seven persons namely P, Q, R, S, T, U and V are planning to go for vacation on the different months
i.e. July, May, August, September, June, February and December, but not necessarily in the same order
also each of them want to see different-different location of Manali i.e. Solang Valley, Hadimba Temple,
Beas Kund, Old Manali, Vashisht Baths, Rohtang Pass and Adventure Activity, but not necessarily in
the same order. All persons are arranged in an order from top to bottom.
There are two persons sit between the person who wants to see Vashisht Baths and the one who is
immediate above the one, who is planning to go on December. The person, who is planning to go on
December, is not immediate above the person, who is planning to go on May. Four persons sit between
R and S. Neither V nor T is planning to go on December and May. The person who wants to see
Hadimba Temple is planning to go on June. The person, who wants to see Rohtang Pass is above the
person, who wants to see Old Manali (but not immediate above). Q sits below R and one person sits
between Q and U. Only One person sits between the person, who wants to see Solang Valley and the
person, who wants to see Vashisht Baths, who is planning to go on July. There are three person sit
between the one who is planning to go on June and V. The person, who wants to see Beas Kund is
planning to go on May and sits immediate above the person, who wants to see Vashisht Baths. U wants
to see Rohtang Pass and he is not planning to go on August and September. V is planning to go on
September and he does not want to see Solang Valley. Two persons sit between U and T. T does not
want to see that location, which is immediate below the person, who is planning to go on July. 
     */


                            'Else
                            '    ClientScript.RegisterClientScriptBlock(Me.GetType, "Potttr", "<script language = javascript>alert('No any Email Id, Please Contact With IT')</script>")
                            '    Dr.Close()
                            '    Obj.ConClose()
                            '    Exit Sub

                        End If

            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
            '------------------------------------------------------------------------------------------------------------------------------


            '------------------------------------------------------------------------------------------------------------------------------

            '------------------------------------------------------------------------------------------------------------------------------

            '------------------------------------------------------------------------------------------------------------------------------
            'Send the Bcc
            '------------------------------------------------------------------------------------------------------------------------------

            Dim SqlPass1 = "SELECT e_mailid from jctdev..jct_emp_hod a,JCTDEV..mistel b WHERE  b.empcode=a.resp_emp AND emp_code='" & Session("Empcode") & "' and flag in('B') AND Auth_Req='Y' and status is null and a.Company_Code='" & Session("Companycode") & "' "
            Dim Dr1 As SqlDataReader = Obj.FetchReader(Sqlpass1)
            Try
                If Dr1.HasRows = True Then
                    While Dr1.Read()
                        If Not (Dr1.Item(0) Is System.DBNull.Value) Then
                            EmailBcc1 = Dr1.Item(0)
                            Message.Bcc.Add(EmailBcc1)
                        End If
                    End While
                    Dr.Close()
                End If
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
            '------------------------------------------------------------------------------------------------------------------------------




            Message.IsBodyHtml = True
            Message.Priority = Net.Mail.MailPriority.High

            'Modify-Ramandeep Singh  Date 4-May-2009
            'Add Disclaimer in Mail

            If ddlleave.Text = "Short Leave" Then
                Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from" + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(txttimefrom.SelectedValue), 11) + " " + "to day time" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(TxtTimeTo.SelectedValue), 11) & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/> <br />Kindly do not reply as you will not receive a response. <br /><br /> Thank You..!!"
            ElseIf ddlleave.Text = "Official Duty" Then
                Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from day time " + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(txttimefrom.SelectedValue), 11) + " " + "to day time" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(TxtTimeTo.SelectedValue), 11) + " " + "for" + " " + Trim(Txtdays.Text) + " " + "day" + "(" + dlleavetype.Text + ")" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package.<br /> <br/>Kindly do not reply as you will not receive a response. <br /> Thank You..!!"
            Else
                Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from" + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + "to" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + ", " + " " + "for" + " " + Trim(Txtdays.Text) + " " + "day" + "(" + dlleavetype.Text + ")" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/><br />Kindly do not reply as you will not receive a response. <br /> Thank You..!!"
            End If

            AutoGenrate()

            Message.Subject = "Application for Leave :- " & ViewState("AutoID")



            If EmailTO <> "" And EmailFrom <> "" And CheckError = False Then
                Client.Send(Message)
            End If


            '--------------------------------------------------------------------
            Me.Txtdays.Text = ""
            Me.txtcompleave.Text = ""
            Me.txtphoneleave.Text = ""
            Me.txtpurleave.Text = ""
            Me.txtaddleave.Text = ""
            Me.ddlleave.Text = "Casual Leave"
            Me.ddlshift.Text = "Genral Shift"
            Me.dlleavetype.Text = "Full Day"
            Me.TxtCoDtAgian.SelectedValue = Now()
            Me.TxtLeaveFrom.SelectedValue = Now()
            Me.TxtLeaveTo.SelectedValue = Now()
            Me.txttimefrom.SelectedValue = Now()
            Me.TxtTimeTo.SelectedValue = Now()
            txttimefrom.Enabled = False
            TxtTimeTo.Enabled = False


            If mapping_check() = False Then
                Me.ModalPopupExtender1.Enabled = True
                Panel1.Visible = True
                Me.ModalPopupExtender1.TargetControlID = "cmdapply"
                Me.ModalPopupExtender1.PopupControlID = "Panel1"
                ModalPopupExtender1.Show()
                Exit Sub
            End If
            If Check_Is_Empty_Flag_Inserted() = True Then
                Me.ModalPopupExtender1.Enabled = True
                Panel1.Visible = True
                Me.ModalPopupExtender1.TargetControlID = "cmdapply"
                Me.ModalPopupExtender1.PopupControlID = "Panel1"
                ModalPopupExtender1.Show()
                Exit Sub
            End If


            ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('Leave Applied Successfully, Please check your leave status.')</script>")

            LeaveMsg()




        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType, "hhh", "<script language = javascript>alert('Error Coming.')</script>")


        Finally

        End Try

    End Sub




    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        txtname.Text = obj1.Get_empname(Session("Empcode"), Session("Companycode"))
        TextBox6.Text = obj1.Get_Desg(Session("Empcode"), Session("Companycode"))
        txtdept.Text = obj1.Get_dept(Session("Empcode"), Session("Companycode"))
    End Sub

    Public Sub AutoGenrate()
        Dim SqlPass = "SELECT MAX(autoid) FROM jctdev..jct_empg_leave"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Auto1 = Dr.Item(0) + 1
                        ViewState("AutoID") = Auto1
                    Else
                        Auto1 = 1001
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
        '---------------------
        'Dim SqlPass1 = "select cardno FROM jct_epor_master_employee WHERE Emp_Code=@empcode AND Status='A' AND GETDATE() BETWEEN eff_from AND Eff_To  "
        'Dim SqlPass1 = "select cardno FROM jct_epor_master_employee WHERE Emp_Code='" & Session("Empcode") & "' AND Status='A' AND GETDATE() BETWEEN eff_from AND Eff_To  "
        Dim SqlPass1 = "select cardno FROM jct_empmast_base WHERE empcode='" & Session("Empcode") & "' AND active='Y' "
        Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
        Try
            If Dr1.HasRows = True Then
                While Dr1.Read()
                    Session("CardNo") = Dr1(0)
                End While
                Dr1.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
        '------------------------

        If Txtdays.Text = "" Then
            Txtdays.Text = 0
        End If

        CheckHC()

        Dim Tran As SqlTransaction
        If Obj.Connection.State = ConnectionState.Closed Then
            Obj.Connection.Open()
        End If
        Tran = Obj.Connection.BeginTransaction
        Try

            If ddlleave.Text = "Compensatry Leave" Then
                SqlPass = "INSERT INTO  jctdev..jct_empg_leave(Usercode,CompanyCode,Cardno,autoid,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,CompAgainTime,FlagHC,mainflag )  VALUES('" & Trim(Session("Empcode")) & "','" & Session("Companycode") & "' ,'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "'," & Auto1 & ",'" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Trim(TxtCoDtAgian.SelectedDate) & "','" & Checkflag & "','P')"
            ElseIf ddlleave.Text = "Short Leave" Or ddlleave.Text = "Official Duty" Then
                SqlPass = "INSERT INTO jctdev..jct_empg_leave(Usercode,CompanyCode,autoid,Cardno,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,timefrom,timeto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,FlagHC,mainflag)  VALUES('" & Trim(Session("Empcode")) & "', '" & Session("Companycode") & "' ," & Auto1 & ",'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "','" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Right(Trim(txttimefrom.SelectedValue), 11) & "','" & Right(Trim(TxtTimeTo.SelectedValue), 11) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Checkflag & "','P')"

            Else
                SqlPass = "INSERT INTO jctdev..jct_empg_leave(Usercode,CompanyCode,Cardno,autoid,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,FlagHC,mainflag )  VALUES('" & Trim(Session("Empcode")) & "', '" & Session("Companycode") & "' ,'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "'," & Auto1 & ",'" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Checkflag & "','P')"
            End If


            Cmd = New SqlCommand(SqlPass, Obj.Connection)
            Cmd.Transaction = Tran
            Cmd.ExecuteNonQuery()
            Tran.Commit()

        Catch ex As Exception
            Tran.Rollback()
            CheckError = True
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('Please Insert Proper data')</script>")
            Exit Sub
        Finally
            Obj.ConClose()
        End Try
        Dr.Close()
    End Sub

    Public Sub EmailIDFrom()
        Dim SqlPass = "SELECT E_mailID FROM  JCTDEV..Mistel b  WHERE b.empcode='" & Session("Empcode") & "' and Company_Code='" & Session("Companycode") & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        EmailFrom = Dr.Item(0)
                        ViewState("EmployeeFrom") = EmailFrom
                    Else
                        EmailFrom = "dummy@jctltd.com"
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Sub DisComp()

        If ddlleave.Text = "Compensatry Leave" Then
            txtcompleave.Enabled = True
            TxtCoDtAgian.Enabled = True
        Else
            txtcompleave.Enabled = False
            TxtCoDtAgian.Enabled = False
            TxtCoDtAgian.Text = ""
        End If

        If ddlleave.Text = "Short Leave" Or ddlleave.Text = "Official Duty" Then

            txttimefrom.Enabled = True
            TxtTimeTo.Enabled = True

            If ddlleave.Text = "Short Leave" Then
                Txtdays.Text = "0"
                Txtdays.Enabled = False
            ElseIf ddlleave.Text = "Official Duty" Then
                Txtdays.Text = "0"
                Txtdays.Enabled = True
            Else
                Txtdays.Text = ""
                Txtdays.Enabled = True
            End If

        Else
            txttimefrom.Enabled = False
            TxtTimeTo.Enabled = False
            Txtdays.Text = ""
            Txtdays.Enabled = True
        End If

    End Sub

    Protected Sub ddlleave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlleave.SelectedIndexChanged
        DisComp()
    End Sub

    Public Sub CheckHC()

        'Dim SqlPass = "SELECT flag FROM jctdev..jct_emp_hod  WHERE emp_code='" & Session("Empcode") & "' AND Flag in ('H','T','C','B1','B2','B3','B4','B5') AND Auth_Req='Y' and " & Txtdays.Text & " =0 and " & Txtdays.Text & " >=days  "
        Dim SqlPass = "SELECT FLAG from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') AND  status is null AND Auth_Req='Y'and Days=0 and a.Company_Code='" & Session("Companycode") & "' UNION SELECT FLAG from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and days between 0 and " & Txtdays.Text & " and a.Company_Code='" & Session("Companycode") & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Checkflag1 = Dr.Item(0)
                    End If
                    Checkflag += Trim(Checkflag1) + "-"
                End While
                Checkflag = Mid(Checkflag, 1, Checkflag.Length - 1)
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Public Sub SameDate()
        Dim SqlPass = "SELECT *  from JCTDEV..jct_empg_leave WHERE EmpCode='" & Session("Empcode") & "' and NATURELEAVE='" & ddlleave.Text & "' AND LEAVETYPE='" & Me.dlleavetype.Text & "' AND convert(smalldatetime,convert(char(12),LEAVEFROM )) = '" & Format(TxtLeaveFrom.SelectedDate, "MM/dd/yyyy") & "'  AND convert(smalldatetime,convert(char(12),LEAVETO )) = '" & Format(TxtLeaveTo.SelectedDate, "MM/dd/yyyy") & "' and mainflag not in('C')  and CompanyCode='" & Session("Companycode") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    CheckRecord = True
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Public Sub CheckDateGreater()
        Dim SqlPass = "SELECT  DateDiff(DD,'" & TxtLeaveFrom.SelectedDate & "','" & TxtLeaveTo.SelectedDate & "') as Difference"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Dr.Item(0) < 0 Then
                        CheckDate = True
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Protected Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Me.Txtdays.Text = ""
        Me.txtcompleave.Text = ""
        Me.txtphoneleave.Text = ""
        Me.txtpurleave.Text = ""
        Me.txtaddleave.Text = ""
        Me.ddlleave.Text = "Casual Leave"
        Me.ddlshift.Text = "Genral Shift"
        Me.dlleavetype.Text = "Full Day"
        Me.TxtCoDtAgian.SelectedValue = Now()
        Me.TxtLeaveFrom.SelectedValue = Now()
        Me.TxtLeaveTo.SelectedValue = Now()
        Me.txttimefrom.SelectedValue = Now()
        Me.TxtTimeTo.SelectedValue = Now()

    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("Default2.aspx")
    End Sub
    Public Sub LeaveMsg()
        Obj.ConOpen()
        SqlPass = "select count(*) from jct_empg_leave where empcode='" & Session("Empcode") & "' and mainflag='p'"
        Cmd = New SqlCommand(SqlPass, Obj.Connection())

        Dim count As Integer = Cmd.ExecuteScalar()
        If count <> 0 Then
            Me.lblmsg.Visible = True
            Me.lblmsg.Text = "The number of leave applications pending in your account:  " & count & " .  For more detail, please check your Leave Status."
        Else
            Me.lblmsg.Visible = False
        End If
        Obj.ConOpen()
    End Sub

    Protected Sub lnkcomp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkcomp.Click
        Response.Redirect("applycompensatoryleave.aspx")
    End Sub


End Class
'Leave Application Code File Also Available E:\c backup 30 july 08\hitesh\Desktop\master
'Leave Application Code File update 16/sep.2006 in \\test2k\webapplication with hiteshLeave