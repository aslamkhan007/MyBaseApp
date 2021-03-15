Imports System.Data.SqlClient

Partial Class SalaryMsg
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public ob As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Dim i As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            ob.opencn()
            qry = "select monthyear,left(monthyear,4),right(monthyear,2) from jct_emp_Salary_Update  where (convert(varchar(10),upddate,102)=convert(varchar(10),getdate(),102) or convert(varchar(10),upddate,102)=convert(varchar(10),getdate()-1,102)) and (flag1 is null or flag2 is null) and emp_code='" & Session("Empcode") & "'"
            cmd = New SqlCommand(qry, ob.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    Session("MnthYr") = dr.Item(0)
                    If Trim(Me.Label1.Text) = "" Then
                        Me.Label1.Text = MonthName(dr.Item(2)) & " " & Trim(dr.Item(1))
                    Else
                        Me.Label1.Text = Me.Label1.Text & " And " & MonthName(dr.Item(2)) & " " & Trim(dr.Item(1))
                    End If
                End While
            End If
            dr.Close()
            ob.closecn()

            ob.opencn()
            qry = "select distinct designation from jct_emp_Salary_Update a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and b.status='' and monthyear='" & Session("MnthYr") & "' and a.type='sal'"
            cmd = New SqlCommand(qry, ob.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()

                    If Trim(Me.Label2.Text) = "" Then
                        Me.Label2.Text = dr.Item(0)
                    Else
                        Me.Label2.Text = Me.Label2.Text & ", " & dr.Item(0)
                    End If
                End While
            End If
            dr.Close()
            ob.closecn()
            If Session("flag1") = 1 Then
                ob.opencn()
                qry = "update jct_emp_Salary_Update set flag1=getdate() where flag1 is null and monthyear='" & Session("MnthYr") & "' and emp_code='" & Session("Empcode") & "' and type='sal'"
                cmd = New SqlCommand(qry, ob.cn)
                cmd.ExecuteNonQuery()
                ob.closecn()
            ElseIf Session("flag2") = 1 Then
                ob.opencn()
                qry = "update jct_emp_Salary_Update set flag2=getdate() where flag2 is null and monthyear='" & Session("MnthYr") & "' and emp_code='" & Session("Empcode") & "' and type='sal'"
                cmd = New SqlCommand(qry, ob.cn)
                cmd.ExecuteNonQuery()
                ob.closecn()
            End If


        End If

    End Sub
    Protected Sub Lnk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk.Click
        If Session("Birth_Flag") = 1 Then
            Response.Redirect("Birthday_Card.aspx")
        Else
            Response.Redirect("emp_home.aspx")
        End If
    End Sub
End Class
