Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class DocumentUpload
    Inherits System.Web.UI.Page
    Dim sqlpass, sqlpass1 As String
    Dim obj As New Connection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
        Else
            Response.Redirect("login.aspx")
        End If
        If Page.IsPostBack = False Then
            sqlpass1 = "select distinct deptcode,deptname from jctdev..Deptmast"
            Dim dr As SqlDataReader = obj.FetchReader(sqlpass1)

            While dr.Read()

                Me.ddldept.Items.Add(dr.Item(1))
                Me.ddldept.Items(Me.ddldept.Items.Count - 1).Text = dr.Item(0) & " ~ " & dr.Item(1)
                Me.ddldept.Items(Me.ddldept.Items.Count - 1).Value = dr.Item(0)

            End While
            dr.Close()
        End If
    End Sub

    Protected Sub btnsub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsub.Click
        Dim len As Integer
        Dim fname, fext As String

        len = StrReverse(FileUpload1.FileName).Length
        fname = StrReverse(Mid(StrReverse(FileUpload1.FileName), 5, len))
        fext = StrReverse(Mid(StrReverse(FileUpload1.FileName), 1, 4))

        obj.ConOpen()
        If Me.ddldoc.SelectedValue = "F" Then
            sqlpass = "INSERT INTO jct_empg_forms VALUES('" & Session("Location") & "','" & Session("empcode") & "','F','" & Me.ddldept.SelectedValue & "','" & Me.RLtype.SelectedValue & "','" & fname & "','" & fext & "','P')"
            InsertRecord(sqlpass)
            fileupload("Leave")
        ElseIf Me.ddldoc.SelectedValue = "O" Then
            sqlpass = "INSERT INTO jct_empg_order(CompanyCode,UserCode,Type,Deptcode,FileName,FileExt) VALUES('" & Session("Location") & "','" & Session("empcode") & "','','" & Me.ddldept.SelectedValue & "','" & fname & "','" & fext & "','P')"
            InsertRecord(sqlpass)
            fileupload("Order")
        ElseIf Me.ddldoc.SelectedValue = "T" Then
            sqlpass = "INSERT INTO jct_empg_trainee VALUES('" & Session("Location") & "','" & Session("empcode") & "','','" & Me.ddldept.SelectedValue & "','" & Me.RLtype.SelectedValue & "','" & fname & "','" & fext & "','P')"
            InsertRecord(sqlpass)
            fileupload("Training")
        End If
        sendmail("dummy@jctltd.com", "rbaksshi@jctltd.com")
        Response.Write("<script>alert('Document Added!!')</script>")
        obj.ConClose()

    End Sub
    Private Sub fileupload(ByVal loc As String)

        If FileUpload1.HasFile Then
            FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\" & loc & "\" & FileUpload1.FileName)
        End If

    End Sub
    Private Sub sendmail(ByVal From As String, ByVal Too As String)
        Dim MailSmpt As New Mail.MailMessage
        With MailSmpt
            obj.ConOpen()
            sqlpass = "select e_mailid from mistel where empcode='" & Session("empcode") & "'"
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

            .Body = Session("empname") & " of department : " & Session("Deptname") & " has uploaded a document of type : " & Me.ddldoc.SelectedItem.Text & vbCrLf & vbCrLf & ", Needs Your Authorization !!!!" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
            .Subject = "Document Authorization Request By" & Session("empname") & " of " & Session("Deptname") & " department"

            Mail.SmtpMail.SmtpServer = "exchange2007"
            If Too <> "" Then
                Mail.SmtpMail.Send(MailSmpt)
                MailSmpt = Nothing
            End If
        End With

    End Sub
End Class
