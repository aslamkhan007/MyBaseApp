Imports System.Data
Imports System.Data.SqlClient
Partial Class Login
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim ObjFUn As Functions = New Functions
    Dim SqlPass As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub

    Protected Sub lnkLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogin.Click

        Dim Host_IP As String = Request.ServerVariables("REMOTE_ADDR")

        'RegAppHit(comp_code, txtUserName.Text, "FusionApps", Host_IP)

        'Dim Host_IP As String = Request.UserHostName

        'Write Feedback to Database------------
        'SqlPass = "INSERT INTO Jct_Emp_Feedback(Company_Code,Emp_Code,ComentDate,Coments,Flag) VALUES('" & Session("Companycode") & "','" & Session("Empcode") & "', GETDATE() ,"",  '" & Trim(Me.txtComments.Text & "'),'U')")

        lblError.Text = ""
        SqlPass = "SELECT EMPCODE FROM JCT_LOGIN_EMP WHERE ACTIVE='Y' AND EMPCODE='" & Trim(TxtCode.Text) & "'"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        If Dr.HasRows = True Then
            Dr.Close()
            Obj.ConClose()
            SqlPass = "INSERT INTO Jct_Emp_Feedback(Company_Code,Emp_Code,ComentDate,Coments,Flag) VALUES('JCT00LTD','" & Trim(TxtCode.Text) & "', GETDATE() , '" & Replace(Trim(Me.txtComments.Text), "'", "") & "','U' )"
            If objfun.InsertRecord(SqlPass) = True Then
                Response.Redirect("emp_home.aspx")
            End If
        Else
            lblError.Text = "User doesn't exists"
        End If
        '--------------------------------------

    End Sub

    Protected Sub LnkBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBack.Click
        'LnkBack.OnClientClick = "javascript:window.history.go(-1);return false;"
    End Sub

End Class
