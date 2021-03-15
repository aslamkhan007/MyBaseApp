Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim empcode As String
    Dim i, cnt As Integer
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Public cmd As New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then
            Dim marquee As New Literal()
            Dim mytext, mytext1, monthyear, txt As String
            obj.opencn()
            qry = "select replace(FileName,' ','&nbsp'),FileExt,transaction_no,replace(Department,' ','&nbsp'),replace(description,' ','%20'), replace(headline,' ','&nbsp') from jct_empg_News where headline is not null and getdate() between news_start_date and news_start_date + 15 and getdate() between news_start_date and news_end_date"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()

                    '-----------------------for few times hitesh
                    'txt = txt & "&nbsp&nbsp<a style =""color:White"" href=""PhotoGallery.aspx?Transaction=100008&Flag=P"">" & dr.Item(5) & "</a>&nbsp~~"
                    txt = txt & "&nbsp&nbsp<a style =""color:White"" href=""PhotoGallery.aspx?Transaction=100008&Flag=P"">News Text</a>&nbsp~~"
                    '-----------------------------
                    'txt = txt & "&nbsp&nbsp<a href=NewsDetail.aspx?description=" & dr.Item(4) & "&Transac=" & dr.Item(2) & "&path=News\" & dr.Item(3) & "\Ext\" & dr.Item(0) & dr.Item(1) & """>" & dr.Item(5) & "</a>&nbsp&nbsp"
                End While
            End If
            dr.Close()
            obj.closecn()

            obj.opencn()
            qry = "JCT_Emp_Marquee_All '" & Session("Location") & "'"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    If monthyear <> dr.Item(1) Then

                        If Trim(mytext1) <> "" Then
                            mytext1 = mytext1 & " has been transferred  In your Bank A/c for the month of  " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ". Allowance Of " & dr.Item(0)
                        Else
                            mytext1 = mytext1 & "~~ Allowance of " & dr.Item(0)
                        End If
                        monthyear = dr.Item(1)
                    Else
                        mytext1 = mytext1 & " , " & dr.Item(0)
                    End If
                End While
                mytext1 = mytext1 & " has been transferred In your Bank A/c for the month of   " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ".~~"
            End If
            dr.Close()
            obj.closecn()
            monthyear = ""
            obj.opencn()
            qry = "JCT_Emp_Marquee '" & Session("Location") & "'"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    If monthyear <> dr.Item(1) Then
                        If Trim(mytext) <> "" Then
                            mytext = mytext & " has been transferred for the month of " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ". Salary Of " & dr.Item(0)
                        Else
                            mytext = mytext & "~~ Salary Of " & dr.Item(0)
                        End If
                        monthyear = dr.Item(1)
                    Else
                        mytext = mytext & " , " & dr.Item(0)
                    End If
                End While
                mytext = mytext & " has been transferred for the month of " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ".~~"
            End If
            dr.Close()
            obj.closecn()
            mytext = mytext1 + mytext
            obj.opencn()
            qry = "select b.shortdesc, a.fullname from jct_epor_master_employee a, JCT_EPOR_MASTER_SALUATION b  where a.salute=b.salt_code and a.active_flag='y' and month(dob) =month(getdate()) and day(dob)=day(getdate())  and a.status='a' and b.status='a' and getdate() between a.eff_from and a.eff_to "
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            Dim bday As String

            If dr.HasRows = True Then
                While dr.Read()
                    If Trim(bday) = "" Then
                        bday = " ~~ JCT Family Sends Heartiest Greetings To " & dr.Item(0) & " " & dr.Item(1)
                    Else
                        bday = bday & ", " & dr.Item(0) & " " & dr.Item(1)
                    End If
                End While
                bday = bday & " On BirthDay!! ~~"
            End If
            dr.Close()
            obj.closecn()
            'mytext = "Hi This Is Neha"
            '----Hitesh 16-Oct-2008 mytext = mytext & txt & "~~ " & "Your Salary Details will be updated on 6th of Every Month (7th in case of holiday on 5th) And Provident Fund will be updated on 13th of every month (14th in case of holiday on 12th) ~~ " & bday
            'marquee.Text = "<font color=white><marquee align=center width=70% height=100% scrolldelay=1 scrollamount=2 style = ""background-image : url(image/blackbar.png)"">" & mytext & "</marquee>"

            Dim news As String = ""
            'Photographs of Kaizen Programme for Spinning and R&D are available on JCT News -> Dept Wise -> Admin Dept ~~

            mytext = news & bday & mytext & "~~ Please keep your Contact Detail up to date in JCTians ~~"

            'Previous Code----------------------------------------------------
            '-----------------------------------------------------------------

            'Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'If (Session("empcode").ToString <> "") Then
            '    empcode = Session("empcode")
            'Else
            '    Response.Redirect("login.aspx")
            'End If


            'If Not IsPostBack Then
            '    Dim marquee As New Literal()
            '    Dim mytext, monthyear As String

            '    obj.opencn()
            '    qry = "JCT_Emp_Marquee"
            '    cmd = New SqlCommand(qry, obj.cn)
            '    dr = cmd.ExecuteReader
            '    If dr.HasRows = True Then
            '        While dr.Read()
            '            If monthyear <> dr.Item(1) Then

            '                If Trim(mytext) <> "" Then
            '                    mytext = mytext & " has been transferred for the month of " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ". Salary Of " & dr.Item(0)
            '                Else
            '                    mytext = mytext & " Salary Of " & dr.Item(0)
            '                End If
            '                monthyear = dr.Item(1)
            '            Else
            '                mytext = mytext & " , " & dr.Item(0)
            '            End If
            '        End While
            '        mytext = mytext & " has been transferred for the month of " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & "."
            '    End If
            '    dr.Close()
            '    obj.closecn()

            '    obj.opencn()
            '    qry = "select * from jct_empmast_base  where  Month(dob) = Month(getdate()) and day(dob)=day(getdate()) and active = 'y' "
            '    cmd = New SqlCommand(qry, obj.cn)
            '    dr = cmd.ExecuteReader
            '    Dim bday As String
            '    If dr.HasRows = True Then
            '        While dr.Read()
            '            If Trim(bday) = "" Then
            '                bday = "  JCT Family Wishes Heartiest Greetings To " & dr.Item("mr_mrs") & " " & dr.Item("empname")
            '            Else
            '                bday = bday & ", " & dr.Item("mr_mrs") & " " & dr.Item("empname")
            '            End If
            '        End While
            '        bday = bday & " On BirthDay!!"
            '    End If
            '    dr.Close()
            '    obj.closecn()
            '---------------------------------------------------------------------------------
            'mytext = mytext & bday & "This is sample text for Marquee"

            'marquee.Text = "<marquee width = 100% scrolldelay=1 scrollamount = 2 style= ""height:23px;padding:0px;filter:shadow(color:black,strength:2,direction:135);""> " & mytext & "</marquee>"

            'Me.Panel1.Controls.Add(marquee)

            mytext = "<DIV style = filter:shadow(color:black,strength:2,direction:135);><nobr>" & mytext & "</nobr></DIV>"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "m", "marqueecontent='" & mytext & "'", True)
            'If (Now().Date.Day = "14") Then
            '    FlashControl1.MovieUrl = "~/JanamAsh2New.swf"
            '    FlashControl1.AlternativeImage = "~/JanamAsht1.jpg"
            'Else
            'FlashControl1.MovieUrl = "~/ind2new.swf"
            'FlashControl1.AlternativeImage = "~/ind.jpg"
            'End If

        End If
    End Sub
End Class
