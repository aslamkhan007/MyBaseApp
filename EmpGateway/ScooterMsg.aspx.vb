Imports System.Data
Imports System.Data.SqlClient

Partial Class ScooterMsg
    Inherits System.Web.UI.Page
    Public Obj As Connection = New Connection
    Public Cmd As New SqlCommand
    Public SqlPass As String
    Public MonYr As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            If Session("Catg") = "JM1" Or Session("Catg") = "JM2" Or Session("Catg") = "MM3" Then
                Car.ImageUrl = "Image\Scooter.Jpg"
            ElseIf Session("Catg") = "MM1" Or Session("Catg") = "MM2" Or Session("Catg") = "SM3" Then
                Car.ImageUrl = "Image\Car.Jpg"
            End If

            Dim Tran As SqlTransaction

            If Obj.Connection.State = ConnectionState.Closed Then
                Obj.Connection.Open()
            End If

            Tran = Obj.Connection.BeginTransaction
            Try
                If Session("Allowance") = 1 Then

                    'Me.AllMonth.Text = Session("MonthYear")
                    MonYr = Mid(Session("MonthYear"), 5, 6)
                    Me.AllMonth.Text = MonthName(MonYr) + "," + Mid(Session("MonthYear"), 1, 4)

                    If Session("AllFlag1") = 1 Then

                        SqlPass = "Update JCT_Emp_Salary_Update Set Flag1=GetDate() Where Flag1 Is Null and MonthYear='" & Session("MonthYear") & "' and Emp_Code='" & Session("EmpCode") & "'"
                        Cmd = New SqlCommand(SqlPass, Obj.Connection)
                        Cmd.Transaction = Tran
                        Cmd.ExecuteNonQuery()
                        Tran.Commit()

                    ElseIf Session("Allflag2") = 1 Then

                        SqlPass = "Update JCT_Emp_Salary_Update Set Flag2=GetDate() Where Flag2 Is Null and MonthYear='" & Session("MonthYear") & "' and Emp_Code='" & Session("EmpCode") & "'"
                        Cmd = New SqlCommand(SqlPass, Obj.Connection)
                        Cmd.Transaction = Tran
                        Cmd.ExecuteNonQuery()
                        Tran.Commit()

                    End If

                End If

            Catch ex As Exception
                Tran.Rollback()
            Finally
                Obj.ConClose()
            End Try
            
        End If

    End Sub

    Protected Sub Lnk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk.Click

        If Session("Sal_Flag") = 1 Then
            Response.Redirect("SalaryMsg.aspx")
        ElseIf Session("Birth_Flag") = 1 Then
            Response.Redirect("Birthday_Card.aspx")
        Else
            Response.Redirect("default.aspx")
        End If

    End Sub
End Class
