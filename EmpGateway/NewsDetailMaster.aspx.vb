Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class NewsDetailMaster
    Inherits System.Web.UI.Page
    Dim obj As New Connection
    Dim sqlpass1, sqlpass2 As String
    Shared dept, flag, act As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ViewState("trans") = Request.QueryString("trans")
        grdbind()

        If Page.IsPostBack = False Then
            dept = Request.QueryString("dept")
            flag = Request.QueryString("flag")
            act = Request.QueryString("act")
            lblnews.Text = ViewState("trans").ToString

            obj.ConOpen()
            sqlpass1 = "select auth_flag from jct_empg_news where transaction_no=" & ViewState("trans")
            Dim cmd As New SqlCommand(sqlpass1, obj.Connection)
            Dim auth As String = cmd.ExecuteScalar

            If auth = "A" Then
                btnadd.Enabled = False
                GridView1.Columns(4).Visible = False
            Else
                btnadd.Enabled = True
                GridView1.Columns(4).Visible = True
            End If
            obj.ConClose()
        End If

    End Sub

    Private Sub grdbind()

        obj.ConOpen()
        sqlpass1 = "select * from jct_empg_news_detail where transaction_no=" & ViewState("trans") & " and (status<>'D' or status is null)"
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter(sqlpass1, obj.Connection)
        adp.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        obj.ConClose()

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Dim trans As Integer = CType(Me.GridView1.Rows(e.RowIndex).FindControl("lblnews"), Label).Text
        Dim type As String = CType(Me.GridView1.Rows(e.RowIndex).FindControl("lbltype"), Label).Text
        Dim file As String = CType(Me.GridView1.Rows(e.RowIndex).FindControl("lnkfile"), LinkButton).Text
        Dim desc As String = CType(Me.GridView1.Rows(e.RowIndex).FindControl("lbldesc"), Label).Text
        sqlpass1 = "update jct_empg_news_detail set status='D' where transaction_no=" & trans & " and flag='" & type & "' and file_name='" & file & "' and description='" & desc & "'"
        obj.ExecQry(sqlpass1)
        grdbind()

    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        Dim fname As String
        Dim len As Integer

        len = StrReverse(FileUpload1.FileName).Length
        fname = StrReverse(Mid(StrReverse(FileUpload1.FileName), 5, len))

        uploadfile()

        sqlpass1 = "insert into jct_empg_news_detail(Transaction_no,Flag,file_name,Description) values(" & ViewState("trans") & ",'" & RLAtt.SelectedValue & "','" & fname & "','" & Me.txtdesc.Text & "') "
        obj.ExecQry(sqlpass1)
        grdbind()

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        Response.Redirect("NewsMaster.aspx?trans=" & ViewState("trans") & "&act=" & act & "&det=1")

    End Sub

    Public Shared Sub Opennewwindow(ByVal Opener As System.Web.UI.WebControls.WebControl, ByVal PagePath As String)
        Dim Clientscript As String
        Clientscript = "window.open('" & PagePath & "')"
        Opener.Attributes.Add("Onclick", Clientscript)
    End Sub


    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim filepath As String
            Dim type As String = CType(e.Row.FindControl("lbltype"), Label).Text
            Dim btn As LinkButton = CType(e.Row.FindControl("lnkfile"), LinkButton)
            Dim file As String = btn.Text
            'If flag = "I" Then
            '    If type = "V" Then
            '        filepath = "D:\EmpGateway\News\" & dept & "\Int\" & file & ".dat"
            '    Else
            '        filepath = "D:\EmpGateway\News\" & dept & "\Int\" & file & ".jpg"
            '    End If
            'Else
            '    If type = "V" Then
            '        filepath = "D:\EmpGateway\News\" & dept & "\Ext\" & file & ".dat"
            '    Else
            '        filepath = "D:\EmpGateway\News\" & dept & "\Ext\" & file & ".jpg"
            '    End If

            'End If
            'btn.PostBackUrl = "DownloadFile.aspx?filepth=" & filepath
            Dim imgpath As String = "NewsFile.aspx?file=" & file & "&dept=" & dept & "&flag=" & flag & "&type=" & type
            Opennewwindow(btn, imgpath)

        End If

    End Sub

    Private Sub uploadfile()

        If FileUpload1.HasFile Then
            If flag = "I" Then
                If Directory.Exists("D:\WebApplications\Empgateway\News\" & dept & "\Int") Then
                    FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\News\" & dept & "\Int\" & FileUpload1.FileName)
                Else
                    Directory.CreateDirectory("D:\WebApplications\Empgateway\News\" & dept & "\Int")
                    FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\News\" & dept & "\Int\" & FileUpload1.FileName)
                End If
            ElseIf flag = "E" Then
                If Directory.Exists("D:\WebApplications\Empgateway\News\" & dept & "\Ext") Then
                    FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\News\" & dept & "\Ext\" & FileUpload1.FileName)
                Else
                    Directory.CreateDirectory("D:\WebApplications\Empgateway\News\" & dept & "\Ext")
                    FileUpload1.PostedFile.SaveAs("D:\WebApplications\Empgateway\News\" & dept & "\Ext\" & FileUpload1.FileName)
                End If
            End If
        End If
    End Sub
End Class
