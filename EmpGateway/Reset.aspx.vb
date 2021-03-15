Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reset
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String, Concat As String
    Dim DOB As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If

    End Sub

   
    Protected Sub BtnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGet.Click

        If RadioButtonList1.Items(0).Selected = True Then

            Try
                SqlPass = "SELECT a.empcode,dateofbirth,a.EmpName,b.CardNo FROM  JCTDEV..jCT_login_emp a,JCTDEV..JCT_EmpMast_Base b  WHERE  a.EmpCode=b.EmpCode and a.empcode='" & Card.Text & "' and a.active='y' "

                Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
                If Dr.HasRows = True Then
                    While Dr.Read
                        Name.Text = Dr.Item("EmpName")
                        DOB = Dr.Item("DateOfBirth")
                        If DOB.Month <= 9 And DOB.Day <= 9 Then
                            Password.Text = DOB.Year & "0" & DOB.Month & "0" & DOB.Day
                        ElseIf DOB.Month <= 9 And DOB.Day > 9 Then
                            Password.Text = DOB.Year & "0" & DOB.Month & DOB.Day
                        ElseIf DOB.Month > 9 And DOB.Day <= 9 Then
                            Password.Text = DOB.Year & DOB.Month & "0" & DOB.Day
                        Else
                            Password.Text = DOB.Year & DOB.Month & DOB.Day
                        End If
                        PictureBox1.ImageUrl = "~\employeeportal\empimages\" & Trim(Dr.Item("CardNo")) & ".jpg"
                    End While
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType, "Portr", "<script language = javascript>alert('Please Check Salary Code')</script>")
                End If
                Dr.Close()
            Finally
                Obj.ConClose()
            End Try
           

           
        ElseIf RadioButtonList1.Items(1).Selected = True Then

            Try
                SqlPass = "SELECT a.empcode,dateofbirth,a.EmpName,b.CardNo FROM  JCTDEV..jCT_login_emp a,JCTDEV..JCT_EmpMast_Base b  WHERE  a.EmpCode=b.EmpCode and Cardno='" & Card.Text & "' and a.active='y' "
                Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
                If Dr.HasRows = True Then
                    While Dr.Read
                        Card.Text = Dr.Item("EmpCode")
                        Name.Text = Dr.Item("EmpName")
                        DOB = Dr.Item("DateOfBirth")
                        If DOB.Month <= 9 And DOB.Day <= 9 Then
                            Password.Text = DOB.Year & "0" & DOB.Month & "0" & DOB.Day
                        ElseIf DOB.Month <= 9 And DOB.Day > 9 Then
                            Password.Text = DOB.Year & "0" & DOB.Month & DOB.Day
                        ElseIf DOB.Month > 9 And DOB.Day <= 9 Then
                            Password.Text = DOB.Year & DOB.Month & "0" & DOB.Day
                        Else
                            Password.Text = DOB.Year & DOB.Month & DOB.Day
                        End If
                        PictureBox1.ImageUrl = "~\employeeportal\empimages\" & Trim(Dr.Item("CardNo")) & ".jpg"
                    End While
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('Please Check Card Number')</script>")
                End If
                Dr.Close()
            Finally
                Obj.ConClose()
            End Try

        End If

    End Sub

    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        Try
            SqlPass = "update jctdev..jct_login_emp set new_pass=null where empcode='" & Card.Text & "'"
            Obj.FetchReader(SqlPass)
            ClientScript.RegisterClientScriptBlock(Me.GetType, "P", "<script language = javascript>alert('Succesfully Password Reset')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        Card.Text = ""
        Name.Text = ""
        Password.Text = ""
    End Sub
End Class
