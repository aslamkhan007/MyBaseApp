
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

            If Not Session("EmpCode") = "" Then

                Session("EmpName") = FetchValue("select FullName from jct_epor_master_employee where status = 'A' and emp_code ='" & Session("EmpCode").ToString & "'")
                lblGreeting.Text = Greet()
                lblUser.Text = Session("EmpName")
                lnkMyArea.Visible = True
                lnkLogin.Text = "Logout"

            Else
                lblUser.Text = "JCTians"
                lnkMyArea.Visible = False
                lnkLogin.Text = "Login"
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

End Class
