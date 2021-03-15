
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'Top.Attributes.Add("style", "background-position: center bottom; width: 100%; height: 100px;" & _
        '                   "background-image: url('Image/Header_Background_Glassy.png'); background-repeat: no-repeat;" & _
        '                   "text-align: center;")
        'min_width.Attributes.Add("style", "background-position: center; width: 780px; height: 100%;" & _
        '                         "background-image: url('Image/Header_Background_Glassy.png')" & _
        '                         "background-repeat: no-repeat; text-align: right; vertical-align: bottom;")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblDateTime.Text = DateTime.Today.ToString("dddd, dd-MMMM-yyyy")
            'DatePart(DateInterval.Weekday) & ", " & DatePart(DateInterval.Day)

            If Not Session("Empcode") = "" Then
                Dim sql As String = "select FullName from jct_epor_master_employee where status = 'A' and emp_code ='" & Session("Empcode").ToString & "' union select empname from jct_login_emp where active = 'Y' and empcode ='" & Session("Empcode").ToString & "'"
                Session("Empname") = FetchValue(sql)
                lblGreeting.Text = Greet()
                lblUser.Text = IIf(Session("Empname") Is DBNull.Value, "User", Session("Empname"))
                lnkMyArea.Visible = True
                lnkLogin.Text = "Sign Out"

            Else
                lblUser.Text = "JCTians"
                lnkMyArea.Visible = False
                lnkLogin.Text = "Sign In"
            End If

            '--Init Greet and Username
            lblGreeting.Text = Greet()
            lblUser.Text += "!"
        End If
    End Sub

    'Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
    '    Dim ctrl1 As HtmlGenericControl = CType(Master.FindControl("Top"), HtmlGenericControl)
    '    Dim ctrl2 As HtmlGenericControl = CType(Master.FindControl("Min_Width"), HtmlGenericControl)
    '    ctrl1.Attributes.Add("style", "background-position: center bottom; width: 100%; height: 96px;" & _
    '                    "background-image: url('Image/Headers/App_Header_Radiant_White.png'); background-repeat: repeat-x;" & _
    '                    "text-align: center;")
    '    ctrl2.Attributes.Add("style", "background-position: center; width: 780px; height: 100%;" & _
    '                             "background-image: url('Image/Headers/App_Header_Radiant_White.png')" & _
    '                             "background-repeat: repeat-x; text-align: right; vertical-align: bottom;")
    'End Sub

    Protected Sub lnkLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogin.Click
        Session.Abandon()
        'If Not Session("Empcode") = "" Then
        '    Session("Empcode") = ""
        '    Session("Companycode") = ""
        'End If
        Response.Redirect("Login.aspx")

    End Sub
End Class
