Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class NewsMaster
    Inherits System.Web.UI.Page
    Dim obj As New Connection
    Dim sqlpass, sqlpass1, sqlpass2, sqlpass3, sqlpass4, sqlpass5, sqlgetemail As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("login.aspx")
        End If
        If Page.IsPostBack = False Then

            ViewState("act") = Request.QueryString("act")
            obj.ConOpen()

            Panel3.Visible = False
            FileUpload1.Visible = False
            ViewState("trans") = Request.QueryString("trans")

            If Session("Empcode") = "R-03339" Then
                Me.Rauth.Enabled = True
            Else
                Me.Rauth.Enabled = False
            End If

            If ViewState("act") = "A" Then
                Me.Rauth.Checked = True
            ElseIf ViewState("act") = "Ad" Then
                Me.Radd.Checked = True
            ElseIf ViewState("act") = "U" Then
                Me.Rupd.Checked = True
            Else
                Me.Radd.Checked = True
            End If

            sqlpass1 = "select distinct deptcode,deptname from jctdev..Deptmast"
            Dim dr As SqlDataReader = obj.FetchReader(sqlpass1)

            While dr.Read()

                Me.ddldept.Items.Add(dr.Item(1))
                Me.ddldept.Items(Me.ddldept.Items.Count - 1).Text = dr.Item(0) & " ~ " & dr.Item(1)
                Me.ddldept.Items(Me.ddldept.Items.Count - 1).Value = dr.Item(0)

            End While
            dr.Close()
            action()
            newsdisplay(ViewState("trans"))

            obj.ConClose()
        End If
        grdbind()
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()

    End Sub

    Protected Sub btnIns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIns.Click
        Dim len As Integer
        Dim fname, fext As String

        len = StrReverse(FileUpload1.FileName).Length
        fname = StrReverse(Mid(StrReverse(FileUpload1.FileName), 5, len))
        fext = StrReverse(Mid(StrReverse(FileUpload1.FileName), 1, 4))

        obj.ConOpen()

        '---------------------------add news------------------------------------------------------------
        If Me.Radd.Checked = True Then
            sqlpass2 = "select max(transaction_no) from jct_empg_news"
            Dim cmd As New SqlCommand(sqlpass2, obj.Connection)
            Dim trans As Integer = cmd.ExecuteScalar + 1

            Try
                uploadfile()
                sqlpass1 = "insert into jct_empg_news(companycode,UserCode,OutdatedFlag,Auth_flag,Department,FileName,News_End_date,Description,FileExt,transaction_no,Int_Ext_Flag,headline,news_start_date) values('" & Session("Companycode") & "','" & Session("Empcode") & "','N','P','" & ddldept.SelectedValue & "','" & fname & "','" & Me.DateEnd.SelectedDate & "','" & Me.txtdesc.Text & "','" & fext & "'," & trans & ",'" & Me.RLtype.SelectedValue & "','" & Me.txthead.Text & "','" & Me.datestart.SelectedDate & "')"
                InsertRecord(sqlpass1)
                obj.ConClose()
                ViewState("trans") = trans
                ViewState("reply") = "N"
                sendmail("dummy@jctltd.com", "rbaksshi@jctltd.com")
                Response.Redirect("NewsDetailMaster.aspx?trans=" & trans & "&dept=" & ddldept.SelectedValue & "&flag=" & RLtype.SelectedValue)

            Catch ex As Exception

            Finally

            End Try


            '---------------------------Update news------------------------------------------------------------
        ElseIf Me.Rupd.Checked = True Then
            If lblnews.Text <> "" Then
                sqlpass = "select auth_flag from jct_empg_news where transaction_no='" & lblnews.Text & "'"
                Dim cmd As New SqlCommand(sqlpass, obj.Connection)
                Dim authflag As String = cmd.ExecuteScalar

                If authflag <> "A" Then
                    If FileUpload1.HasFile Then
                        uploadfile()
                        sqlpass3 = "update jct_empg_news set Department='" & ddldept.SelectedValue & "',Int_Ext_flag='" & RLtype.SelectedValue & "',FileName='" & fname & "',News_End_date='" & Me.DateEnd.SelectedDate & "',Description='" & Me.txtdesc.Text & "',FileExt='" & fext & "',headline='" & Me.txthead.Text & "',news_start_date='" & Me.datestart.SelectedDate & "' where transaction_no='" & lblnews.Text & "'"
                        UpdateRecord(sqlpass3)
                        Response.Write("<script>alert('News Updated!!')</script>")
                        grdbind()
                    Else
                        sqlpass3 = "update jct_empg_news set Department='" & ddldept.SelectedValue & "',Int_Ext_flag='" & RLtype.SelectedValue & "',News_End_date='" & Me.DateEnd.SelectedDate & "',Description='" & Me.txtdesc.Text & "',headline='" & Me.txthead.Text & "',news_start_date='" & Me.datestart.SelectedDate & "' where transaction_no='" & lblnews.Text & "'"
                        UpdateRecord(sqlpass3)
                        Response.Write("<script>alert('News Updated!!')</script>")
                        grdbind()
                    End If
                Else
                    Response.Write("<script>alert('News Cannot be Updated!!')</script>")
                End If
            Else
                Response.Write("<script>alert('Please select a News!!')</script>")
            End If

            '---------------------------Authorize news------------------------------------------------------------
        ElseIf Me.Rauth.Checked = True Then

            If lblnews.Text <> "" Then
                sqlpass = "select auth_flag,usercode from jct_empg_news where transaction_no=" & lblnews.Text
                Dim dr As SqlDataReader = obj.FetchReader(sqlpass)
                dr.Read()
                Dim authflag As String = dr(0)

                If authflag <> "A" Then
                    Dim replyto As String = IIf(dr(1) Is System.DBNull.Value, "", dr(1))
                    dr.Close()

                    sqlpass4 = "Update jct_empg_news set auth_flag='A' where transaction_no=" & lblnews.Text
                    UpdateRecord(sqlpass4)
                    Response.Write("<script>alert('News Authorized!!')</script>")

                    obj.ConOpen()
                    sqlgetemail = "select e_mailid from mistel where empcode='" & replyto & "'"
                    Dim cmd1 As New SqlCommand(sqlgetemail, obj.Connection)
                    replyto = IIf(cmd1.ExecuteScalar Is System.DBNull.Value, "", cmd1.ExecuteScalar)

                    ViewState("reply") = "Y"
                    sendmail("rbaksshi@jctltd.com", replyto)
                    grdbind()
                Else
                    dr.Close()
                    Response.Write("<script>alert('News is already Authorized!!')</script>")
                End If
            Else
                Response.Write("<script>alert('Please select a News!!')</script>")
            End If

        End If

    End Sub
    Protected Sub lnkaddimg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkaddimg.Click
        If FileUpload1.Visible = False Then
            FileUpload1.Visible = True
            lnkaddimg.Text = "Cancel"
        ElseIf FileUpload1.Visible = True Then
            FileUpload1.Visible = False
            lnkaddimg.Text = "Attach File"
        End If
    End Sub
    Private Sub grdbind()
        obj.ConOpen()
        sqlpass1 = "select transaction_no,isnull(headline,'-') as headline,description,filename,fileExt,convert(varchar(20),news_start_date,103) as DOS,convert(varchar(20),news_End_date,103) as DOE from jct_empg_news where Department='" & ddldept.SelectedValue & "' and Int_Ext_flag='" & RLtype.SelectedValue & "' and OutdatedFlag='N' and Auth_Flag='" & ddlnews.SelectedValue & "'"
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter(sqlpass1, obj.Connection)
        adp.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()

    End Sub

    Protected Sub ddlnews_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlnews.SelectedIndexChanged
        'grdbind()
        'newsdisplay()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim trans As LinkButton = CType(e.Row.FindControl("lnknews"), LinkButton)
            Dim detail As LinkButton = CType(e.Row.FindControl("lnkdetail"), LinkButton)
            Dim transno As String = trans.Text
            detail.PostBackUrl = "~/NewsDetailMaster.aspx?trans=" & transno & "&dept=" & ddldept.SelectedValue & "&flag=" & RLtype.SelectedValue
        End If
    End Sub
    '----------------------------------------------------------------------------------------------
    'Diplays selected news in the form
    '----------------------------------------------------------------------------------------------
    Private Sub newsdisplay(ByVal trans As Integer)

        obj.ConOpen()
        sqlpass1 = "select * from jct_empg_news where transaction_no=" & trans
        Dim dr As SqlDataReader = obj.FetchReader(sqlpass1)
        If dr.HasRows Then

            dr.Read()
            Me.ddldept.SelectedValue = dr.Item("Department")
            Me.RLtype.SelectedValue = dr.Item("Int_Ext_Flag")
            Me.lblnews.Text = dr("transaction_no")
            Me.txthead.Text = IIf(dr.Item("headline") Is System.DBNull.Value, "", dr.Item("headline"))
            Me.datestart.SelectedDate = dr.Item("news_start_date")
            Me.DateEnd.SelectedDate = dr.Item("News_End_date")
            Me.txtdesc.Text = IIf(dr.Item("Description") Is System.DBNull.Value, "", dr.Item("Description"))
            Me.ddlnews.SelectedValue = dr("Auth_Flag")

        End If
        dr.Close()
        obj.ConClose()

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        obj.ConOpen()
        Dim transdel As Integer = CType(GridView1.Rows(e.RowIndex).FindControl("lnknews"), LinkButton).Text
        sqlpass1 = "update jct_empg_news set OutdatedFlag='Y' where transaction_no=" & transdel
        sqlpass2 = "update jct_empg_news_detail set status='D' where transaction_no=" & transdel
        UpdateRecord(sqlpass1)
        UpdateRecord(sqlpass2)
        'newsdisplay()
        grdbind()
        obj.ConClose()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim transno As Integer = CType(GridView1.SelectedRow.FindControl("lnknews"), LinkButton).Text
        ViewState("trans") = transno
        newsdisplay(ViewState("trans"))
        Panel2.Visible = True

    End Sub
    '--------------------------------------------------------------------------------------------
    'Upload file in a folder and create a folder if doesnt exist
    '--------------------------------------------------------------------------------------------
    Private Sub uploadfile()

        If FileUpload1.HasFile Then
            Dim flag1 As String = RLtype.SelectedValue

            If flag1 = "I" Then
                If Directory.Exists("D:\WebApplications\Empgateway\News\" & ddldept.SelectedValue & "\Int") Then
                    FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\News\" & ddldept.SelectedValue & "\Int\" & FileUpload1.FileName)
                Else
                    Directory.CreateDirectory("D:\WebApplications\Empgateway\News\" & ddldept.SelectedValue & "\Int")
                    FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\News\" & ddldept.SelectedValue & "\Int\" & FileUpload1.FileName)
                End If

            ElseIf flag1 = "E" Then

                If Directory.Exists("D:\WebApplications\Empgateway\News\" & ddldept.SelectedValue & "\Ext") Then
                    FileUpload1.PostedFile.SaveAs("D:\Empgateway\News\" & ddldept.SelectedValue & "\Ext\" & FileUpload1.FileName)
                Else
                    Directory.CreateDirectory("D:\WebApplications\Empgateway\News\" & ddldept.SelectedValue & "\Ext")
                    FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\News\" & ddldept.SelectedValue & "\Ext\" & FileUpload1.FileName)
                End If

            End If
        End If

    End Sub

    Protected Sub Radd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radd.CheckedChanged
        action()
    End Sub

    Protected Sub Rupd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rupd.CheckedChanged
        action()
    End Sub

    Protected Sub Rauth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rauth.CheckedChanged
        action()
    End Sub
    Private Sub action()
        If Me.Radd.Checked = True Then
            Panel1.Visible = True
            Panel2.Visible = True
            btnIns.Text = "Add"
            btndet.Visible = False
            lblnews.Visible = False
            ViewState("act") = "Ad"
            lblnews.Text = ""
            clear()
        ElseIf Me.Rupd.Checked = True Then
            Panel1.Visible = True
            If Request.QueryString("det") = 1 Then
                Panel2.Visible = True
            Else
                Panel2.Visible = False
            End If
            btnIns.Text = "Update"
            btndet.Visible = True
            'lblnews.Text = ViewState("trans")
            lblnews.Visible = True
            ViewState("act") = "U"
        ElseIf Me.Rauth.Checked = True Then
            Panel1.Visible = True
            Panel2.Visible = True
            btnIns.Text = "Authorize"
            btndet.Visible = True
            'lblnews.Text = ViewState("trans")
            lblnews.Visible = True
            ViewState("act") = "A"
        End If
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        If Panel3.Visible = False Then
            Panel3.Visible = True
            btnview.Text = "Hide All"
        ElseIf Panel3.Visible = True Then
            Panel3.Visible = False
            btnview.Text = "View All"
        End If

    End Sub

    Protected Sub btndet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndet.Click
        If lblnews.Text <> "" Then
            Response.Redirect("NewsDetailMaster.aspx?trans=" & lblnews.Text & "&dept=" & ddldept.SelectedValue & "&flag=" & RLtype.SelectedValue & "&act=" & ViewState("act"))
        Else
            Response.Write("<script>alert('Please select a News!!')</script>")
        End If
    End Sub
    Private Sub sendmail(ByVal From As String, ByVal Too As String)
        Dim MailSmpt As New Mail.MailMessage
        With MailSmpt
            obj.ConOpen()
            sqlpass = "select e_mailid from mistel where empcode='" & Session("Empcode") & "'"
            Dim dr As SqlDataReader = obj.FetchReader(sqlpass)
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
            obj.ConOpen()
            .To = Trim(Too)
            If ViewState("reply") = "N" Then
                .Body = Session("empname") & " has added a News with Subject: " & Me.txthead.Text & vbCrLf & ", Needs Your Authorization !!!!" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
                .Subject = "News Authorization Request By" & Session("empname") & " of " & Session("Deptname") & " department"
            Else
                .Body = Session("empname") & " has authorized your News with Subject: " & Me.txthead.Text & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
                .Subject = "News Authorized By" & Session("empname") & " of " & Session("Deptname") & " department"
            End If
            Mail.SmtpMail.SmtpServer = "exchange2007"
            If Too <> "" Then
                Mail.SmtpMail.Send(MailSmpt)
                MailSmpt = Nothing
            End If
        End With

    End Sub
    Private Sub clear()
        Me.ddldept.SelectedValue = "ABH1"
        Me.datestart.SelectedDate = Date.Today
        Me.DateEnd.SelectedDate = Date.Today
        Me.txtdesc.Text = ""
        Me.txthead.Text = ""
        Me.RLtype.SelectedValue = "I"
        FileUpload1.Visible = False
        lnkaddimg.Text = "Attach File"
        ddlnews.SelectedValue = "P"
        grdbind()
    End Sub
End Class

'We can add neww news ,update existing news  
' Authorization :- In Case of Mr. Rajeev Baksshi Login 
' In this page only data for News header 
' After that this page redirect to news detail page where we can  add/delete related news

