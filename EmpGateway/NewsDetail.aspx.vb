Imports System.Data
Imports System.Data.SqlClient


Partial Class Default6
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim i As Integer = 1


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            ''empcode = Session("empcode")
        Else
            Response.Redirect("login.aspx")
        End If

        Image1.ImageUrl = Request.QueryString.Get("Path")
        Me.lbldescription.Text = Request.QueryString.Get("Description")
        BindData()
        Back.OnClientClick = "javascript:window.history.go(-1);return false;"
    End Sub

    Public Sub BindData()

        Dim SqlPass = " Select distinct(Flag) from jctdev..jct_empg_news_detail a   where  transaction_no=" & Request.QueryString.Get("Transac") & "  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        Try
            If Dr.HasRows = True Then

                While Dr.Read()
                    If Dr.Item("Flag") = "P" Then
                        Dim hyper As New HyperLink
                        hyper.Text = i & ". " & " Photo Gallery" + "<BR>"
                        hyper.NavigateUrl = "PhotoGallery.aspx?Transaction=" & Request.QueryString.Get("Transac") & "&Flag=P"
                        Panel1.Controls.Add(hyper)

                    ElseIf Dr.Item("Flag") = "A" Then
                        Dim hyper As New HyperLink
                        hyper.Text = i & ". " & " Attendence List" + "<BR>"
                        hyper.NavigateUrl = "PhotoGallery.aspx?Transaction=" & Request.QueryString.Get("Transac") & "&Flag=A"
                        Panel1.Controls.Add(hyper)

                    ElseIf Dr.Item("Flag") = "C" Then
                        Dim hyper As New HyperLink
                        hyper.Text = i & ". " & "Circular" + "<BR>"
                        hyper.NavigateUrl = "PhotoGallery.aspx?Transaction=" & Request.QueryString.Get("Transac") & "&Flag=C"
                        Panel1.Controls.Add(hyper)

                    ElseIf Dr.Item("Flag") = "F" Then
                        Dim hyper As New HyperLink
                        hyper.Text = i & ". " & "FeedBack" + "<BR>"
                        hyper.NavigateUrl = "PhotoGallery.aspx?Transaction=" & Request.QueryString.Get("Transac") & "&Flag=F"
                        Panel1.Controls.Add(hyper)

                    ElseIf Dr.Item("Flag") = "V" Then
                        Dim hyper As New HyperLink
                        hyper.Text = i & ". " & "Video" + "<BR>"
                        hyper.NavigateUrl = "PhotoGallery.aspx?Transaction=" & Request.QueryString.Get("Transac") & "&Flag=V"
                        Panel1.Controls.Add(hyper)

                    End If
                    i = i + 1

                End While
                Dr.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Sub
End Class


