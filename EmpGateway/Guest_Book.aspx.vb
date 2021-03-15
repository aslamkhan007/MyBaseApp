Imports System.Data.SqlClient
Imports system.Data
Partial Class Guest_Book
    Inherits System.Web.UI.Page
    Dim db As Connection = New Connection
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim emp_code As String
    Dim dept_no As String
    Dim comp_code As String = "JCT00LTD"
    Dim empcode, qry As String
    Dim check, i, n As Integer
    Public obj As New HelpDeskClass
    Dim dept As String
    Dim cmnt As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack = True Then
            sql = "select Deptcode,Deptname from Deptmast where company_code='" & Session("Companycode") & "' order by Deptname"
            cmd = New SqlCommand(sql, db.Connection())
            db.ConOpen()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    DrpArea.Items.Add(dr(0) & " ~~" & dr(1))
                End While
            End If
            dr.Close()



            sql = "select a.deptcode + ' ~~' + b.deptname from jct_empmast_base a, Deptmast b where a.deptcode=b.deptcode and a.empcode='" & Trim(Session("Empcode")) & "'"
            cmd = New SqlCommand(sql, db.Connection())
            Me.DrpArea.SelectedValue = cmd.ExecuteScalar()
            db.ConClose()

            DrpArea_SelectedIndexChanged(sender, Nothing)

            If Request.QueryString("trans1") = Nothing Then

            Else
                Me.txtprob.Text = "Problem during leave application"
                Me.txtsub.Text = "Need organization hierarchy mapping for leave authorization"
                Me.txtremarks.Text = "Respected Sir/Mam, " & Environment.NewLine & "As per Employee Gateway Leave requirements, our employee gateway system entails mapping of employee with his/her concerned Head for leave authorization. So please forward a mail to IT Help Desk to map me under you .The CC of that mail should go through My Head of Department. Also, this mail would include mine and yours salary codes."
            End If
            db.ConClose()
            DrpArea_SelectedIndexChanged(sender, Nothing)
        End If
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim commentno As Integer

        cmnt = "Select max(comment_no)+1 from jct_emp_guestbook"
        obj.opencn()
        cmd = New SqlCommand(cmnt, obj.cn)
        cmd.CommandTimeout = 0

        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                commentno = 1
            Else
                commentno = dr.Item(0)
            End If
        Else
            commentno = 1
        End If
        dr.Close()



        dept = Trim(Left(DrpArea.SelectedItem.Text, 4))
        
        Dim toVal, SubVal, bodyVal, fromVal, ccval As String
        Dim MailSmpt As New Mail.MailMessage
        check = fill()
        If check = 1 Then Exit Sub

        sql = "insert into jct_emp_guestbook (company_code,user_code,created_dt,topic,area,point,remarks,comment_no) values('" & comp_code & "','" & Session("empcode") & "',getdate(),'" & Replace(txtsub.Text, "'", "''") & "','" & dept & "','" & Replace(txtprob.Text, "'", "''") & "','" & Replace(txtremarks.Text, "'", "''") & "'," & commentno & ")"
        Dim trans As SqlTransaction = obj.cn.BeginTransaction
        Try
            'obj.opencn()

            cmd = New SqlCommand(sql, obj.cn)
            cmd.Transaction = trans
            Dim n As Integer = cmd.ExecuteNonQuery()
            For i = 0 To Me.ChkTo.Items.Count - 1
                'obj.opencn()
                qry = "select e_mailid,name,empcode from mistel where empcode=ltrim('" & Left(Me.ChkTo.Items(i).Text, InStr(Me.ChkTo.Items(i).Text, ":-") - 1) & "')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = trans
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else
                        If Trim(toVal) = "" Then
                            toVal = Trim(dr.Item(0))
                        Else
                            toVal = toVal & ";" & Trim(dr.Item(0))
                        End If

                    End If

                End If
                dr.Close()
                'obj.closecn()
                'obj.opencn()

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                qry = "Insert into jct_emp_guestbook_trans values(" & commentno & ",'" & Left(Me.ChkTo.Items(i).Text, InStr(Me.ChkTo.Items(i).Text, ":-") - 1) & "')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()

                'obj.closecn()

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
            trans.Commit()
            obj.closecn()
            With MailSmpt
                obj.opencn()
                qry = "select e_mailid from mistel where empcode='" & Session("empcode") & "'"
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                        .From = "dummy@jctltd.com"
                    Else
                        .From = dr.Item(0)
                    End If
                Else
                    .From = "dummy@jctltd.com"
                End If
                dr.Close()
                obj.closecn()
                .To = toVal
                ' .Bcc = "rbaksshi@jctltd.com"
                'Modify Person:- Kulwinder Date:- 5/May/2009 
                'Added Disclaimer in body tag
                .Body = Session("empname") & " has added remarks for you which says: " & Environment.NewLine & Environment.NewLine & Me.txtremarks.Text & "." & Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine & " For more details, Please check comments in   Fussion Apps > Employee Gateway > My Consent Area > Comments For Me." & Environment.NewLine & Environment.NewLine & "  DISCLAIMER: This email has been generated through Employee Gateway Package. " & Environment.NewLine & " Kindly do not reply as you will not receive a response."
                .Subject = Me.txtsub.Text
                Mail.SmtpMail.SmtpServer = "exchange2007"
                Mail.SmtpMail.Send(MailSmpt)
                MailSmpt = Nothing
            End With


            ''''''''''''''''''''''''''''''

            Response.Write("<script>alert('Thanks For Your Comments !!'  )</script>")
            Reset()

            ''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            trans.Rollback()
            'Label2.Text = ex.Message
        Finally
            db.ConClose()
        End Try
        'End If
    End Sub

    Private Sub Reset()
        Me.txtprob.Text = ""
        Me.txtremarks.Text = ""
        Me.txtsub.Text = ""
    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Reset()
    End Sub
    Public Function fill()


        If Trim(Me.txtsub.Text) = "" Then
            Response.Write("<script>alert('Please enter Subject!!')</script>")
            Me.txtsub.Focus()
            fill = 1
            Exit Function
        End If

        If Trim(Me.txtprob.Text) = "" Then
            Response.Write("<script>alert('Please enter point of problem!!')</script>")
            Me.txtprob.Focus()
            fill = 1
            Exit Function
        End If

        If Trim(Me.txtremarks.Text) = "" Then
            Response.Write("<script>alert('Please Write Remarks!!')</script>")
            Me.txtremarks.Focus()
            fill = 1
            Exit Function
        End If



    End Function

   
   

    Protected Sub cmdTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTo.Click
        For i = 0 To Me.ChkFrom.Items.Count - 1
            If i <= Me.ChkFrom.Items.Count - 1 Then
                If Me.ChkFrom.Items(i).Selected = True Then
                    Me.ChkTo.Items.Add(Me.ChkFrom.Items(i).Text)
                    Me.ChkFrom.Items.RemoveAt(i)
                    i = i - 1
                End If
            End If
        Next
    End Sub
    Protected Sub cmdDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        For i = 0 To Me.ChkTo.Items.Count - 1
            If i <= Me.ChkTo.Items.Count - 1 Then
                If Me.ChkTo.Items(i).Selected = True And Me.ChkTo.Items(i).Value <> "N" Then
                    Me.ChkFrom.Items.Add(Me.ChkTo.Items(i).Text)
                    Me.ChkTo.Items.RemoveAt(i)
                    i = i - 1
                End If
            End If
        Next
    End Sub
    Protected Sub DrpArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpArea.SelectedIndexChanged
        dept = Trim(Left(DrpArea.SelectedItem.Text, 4))
        qry = "select a.empcode + ':-' + empname,'a' as seq from jct_empmast_base a where  a.active='y' and deptcode='" & dept & "' and company_code='" & Session("Companycode") & "'  union select empcode+ ':-' + empname , 'b' from jct_empmast_base where deptcode <> '" & dept & "'and company_code='" & Session("Companycode") & "' order by seq,a.empcode + ':-' + empname"
        cmd = New SqlCommand(qry, db.Connection())
        db.ConOpen()
        dr = cmd.ExecuteReader
        Me.ChkFrom.Items.Clear()
        If dr.HasRows = True Then
            While dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                Else
                    Me.ChkFrom.Items.Add(Trim(dr.Item(0)))
                    ' Me.ChkFrom.Items(Me.ChkFrom.Items.Count - 1).Value = "N"
                End If

            End While
        End If
        dr.Close()
        db.ConClose()
    End Sub
End Class
