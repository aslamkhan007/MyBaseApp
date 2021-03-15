
Partial Class RegisterUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillList(ddlCompany, "select companyname, companyname from jctgen..jct_company_master")
        FillList(ddlLocation, "select location, location from jctgen..jct_company_master")
    End Sub

    Protected Sub lnkRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRegister.Click

        'TODO
        'Generate User ID

        Dim sql As String = "insert into jct_fap_reg_users (CompanyCode, UserID, UserName, Password, Comments, Status, HostIP, EffFrom) " & _
        " values('','temp101','" & txtUserName.Text & "',Convert(varbinary,'" & txtPassword.Text & "'),'" & txtComments.Text & "','','" & Request.UserHostAddress & "',getdate())"

        If Not InsertRecord(sql) Then
            lblError.Text = "Error occured in Registeration. Please Try Again."
        Else
            'Response.Redirect("Login.aspx")
            lblError.Text = "Congrats!!! Registration Successful."
        End If

    End Sub

End Class
