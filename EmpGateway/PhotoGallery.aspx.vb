Imports System.Data
Imports System.Data.SqlClient



Partial Class Default6
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass, IntExt As String
    Public count As Integer = 0
    Public Video As String

    Public Sub BindData()
        Video = Request.QueryString.Get("Flag")
        Dim SqlPass = "select Department,int_ext_flag,a.Description as Description,fileext,File_name from jctdev..jct_empg_news_detail  a ,jctdev..jct_empg_news  b where   a.transaction_no= " & Request.QueryString.Get("Transaction") & " and  b.transaction_no= " & Request.QueryString.Get("Transaction") & " and Flag='" & Request.QueryString.Get("Flag") & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            '-----------
            'If Video = "A" Then
            '    DetailsView1.HeaderText = "Attendence List"
            'ElseIf Video = "V" Then
            '    DetailsView1.HeaderText = "Video"
            'ElseIf Video = "P" Then
            '    DetailsView1.HeaderText = "Photo Gallery"
            'ElseIf Video = "F" Then
            '    DetailsView1.HeaderText = "Feed Back"
            'End If
            If Video = "A" Then
                DetailsView1.HeaderText = "Attendence List"
                Me.lblheader.Text = "Attendence List"
            ElseIf Video = "V" Then
                DetailsView1.HeaderText = "Video"
                Me.lblheader.Text = "Video"
            ElseIf Video = "P" Then
                DetailsView1.HeaderText = "Photo Gallery"
                Me.lblheader.Text = "Photo Gallery"
            ElseIf Video = "F" Then
                DetailsView1.HeaderText = "Feedback"
                Me.lblheader.Text = "Feedback"
            End If

            '-----------
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                DetailsView1.DataSource = ds
                DetailsView1.DataBind()

                If DetailsView1.Rows(1).Cells(1).Text = "I" Then

                    IntExt = "Int"
                    If Video <> "V" Then
                        PictureBox1.ImageUrl = "News\" & Trim(DetailsView1.Rows(0).Cells(1).Text & "\" & IntExt & "\" & Trim(Trim(DetailsView1.Rows(4).Cells(1).Text) & Trim(DetailsView1.Rows(3).Cells(1).Text)))
                    End If
                Else
                    IntExt = "Ext"
                    If Video <> "V" Then
                        PictureBox1.ImageUrl = "News\" & Trim(DetailsView1.Rows(0).Cells(1).Text & "\" & IntExt & "\" & Trim(Trim(DetailsView1.Rows(4).Cells(1).Text) & Trim(DetailsView1.Rows(3).Cells(1).Text)))
                    End If

                    If Video = "V" Then
                        PictureBox1.ImageUrl = ""
                        'System.Diagnostics.Process.Start("D:\WebApplications\EmpGateway\News\" & Trim(DetailsView1.Rows(0).Cells(1).Text & "\" & IntExt & "\" & Trim(Trim(DetailsView1.Rows(4).Cells(1).Text) & ".dat")))
                        Dim hyper As New HyperLink
                        hyper.Text = DetailsView1.Rows(2).Cells(1).Text + "<BR>"
                        'hyper.NavigateUrl = "Downloadfile.aspx?filepth=D:\WebApplications\EmpGateway\news\" & Trim(DetailsView1.Rows(0).Cells(1).Text & "\" & IntExt & "\" & Trim(Trim(DetailsView1.Rows(4).Cells(1).Text) & ".dat"))
                        MPC1.Height = 300
                        MPC1.Width = 400
                        MPC1.MovieURL = "News\" & Trim(DetailsView1.Rows(0).Cells(1).Text & "\" & IntExt & "\" & Trim(Trim(DetailsView1.Rows(4).Cells(1).Text) & ".dat"))
                        PictureBox1.Visible = False
                        Me.Panel1.Controls.Add(hyper)
                    End If
                End If
                Dr.Close()
                '                PictureBox1.ImageUrl = "News\" & Trim(DetailsView1.Rows(0).Cells(1).Text & "\" & IntExt & "\" & Trim(Trim(DetailsView1.Rows(4).Cells(1).Text) & Trim(DetailsView1.Rows(3).Cells(1).Text)))
                '----
            
                '----
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("login.aspx")
        End If

        If Not (Page.IsPostBack) Then
            Session("count") = -1
            BindData()
            If DetailsView1.Rows.Count > 0 Then
                DetailsView1.Rows(0).Visible = False
                DetailsView1.Rows(1).Visible = False
                DetailsView1.Rows(3).Visible = False
                DetailsView1.Rows(4).Visible = False

            End If
        End If


        'Back.OnClientClick = "javascript:window.history.go(" & Session("count") & ");return false;"

        Back.OnClientClick = "javascript:window.history.go(" & -1 & ");return false;"
        ' Back.Attributes.Add("onClick", "window.history.go(newsdetail.aspx)")
        ' <a href=taskmanagement.aspx></a>

    End Sub

    Protected Sub DetailsView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewPageEventArgs) Handles DetailsView1.PageIndexChanging
        DetailsView1.PageIndex = e.NewPageIndex
        BindData()
        DetailsView1.Rows(0).Visible = False
        DetailsView1.Rows(1).Visible = False
        DetailsView1.Rows(3).Visible = False
        DetailsView1.Rows(4).Visible = False
        Session("count") = Session("count") - 1
        Back.OnClientClick = "javascript:window.history.go(" & Session("count") & ");return false;"
    End Sub

    Protected Sub Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back.Click

        '  Back.Attributes.Add("onClick", "window.history.go(-1)")
        '<a href="newsdetail.aspx"></a>


    End Sub
   



End Class