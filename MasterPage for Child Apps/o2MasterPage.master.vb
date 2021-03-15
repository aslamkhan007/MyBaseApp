
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

        lblDateTime.Text = DateTime.Today.ToString("dddd, dd-MMMM-yyyy")
        'DatePart(DateInterval.Weekday) & ", " & DatePart(DateInterval.Day)
        lblGreeting.Text = Greet()
        lblUser.Text = Session("EmpCode").ToString


    End Sub

    Protected Function Greet() As String

        If DateTime.Now.Hour < 12 Then
            Greet = "Good Morning"
        ElseIf DateTime.Now.Hour >= 12 And DateTime.Now.Hour < 16 Then
            Greet = "Good Afternoon"
        Else 'If DateTime.Now.Hour >= 16 And DateTime.Now.Hour < 24 Then
            Greet = "Good Evening"
        End If

    End Function

End Class
