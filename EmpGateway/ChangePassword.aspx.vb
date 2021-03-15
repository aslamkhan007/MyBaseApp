Imports System.Data.sqlclient
Partial Class Default6
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim Dr As SqlDataReader
    Public ob As New HelpDeskClass
    Public cmd As New SqlCommand
    Public qry As String
    Protected Sub cmdApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        If Trim(Me.txtcurrpwd.Text) = "" Then
            Me.lblMessage.Visible = True
            Me.lblMessage.Text = "Please Specify Your Current Password!!"
            Exit Sub
        End If
        If Trim(Me.txtNewpwd.Text) = "" Then
            Me.lblNew.Visible = True
            'Me.lblNew.Text = "Please Specify Your Current Password!!"
            Exit Sub
        End If
        SqlPass = "select empname  from jct_login_emp where empcode='" & Session("Empcode") & "' and active = 'Y' and ((convert(varchar(8),dateofbirth,112)='" & Trim(Me.txtcurrpwd.Text) & " ' and  new_pass is null)  or (new_pass is not null and new_pass=convert(varchar(30),convert(varbinary,'" & Trim(Me.txtcurrpwd.Text) & "'))))"
        Dr = Obj.FetchReader(SqlPass)

        Try
            While Dr.Read()
                If Dr.HasRows = False Then
                    Me.lblMessage.Visible = True
                    Me.lblMessage.Text = "Incorrect Password!!"
                    Exit Sub
                Else
                    Session("Empname") = Dr.Item(0)
                End If
            End While
            Dr.Close()
            SqlPass = "update jctdev..JCT_login_emp set new_pass=convert(varbinary,'" & Trim(Me.txtNewpwd.Text) & "') where empcode='" & Session("Empcode") & "' and empname= '" & Session("Empname") & "'"
            ob.opencn()
            cmd = New SqlCommand(SqlPass, ob.cn)
            cmd.ExecuteNonQuery()
            ob.closecn()
            Response.Write("<script>alert('Password Changed Successfully!!')</script>")
            Response.Redirect("default.aspx")
        Catch

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        If (Session("Empcode").ToString <> "") Then
            'empcode = Session("Empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then
            Me.cmdCancel.Visible = False
            Me.lblMessage.Visible = False
            Me.lblNew.Visible = False
        End If

    End Sub

    Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Response.Redirect("default.aspx")
    End Sub
End Class
