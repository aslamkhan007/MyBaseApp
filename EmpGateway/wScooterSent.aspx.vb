Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic

Partial Class Scooter
    Inherits System.Web.UI.Page
    Public Obj As Connection = New Connection
    Public Cmd As New SqlCommand
    Public SqlPass As String
    Public CurMon As Date
    Dim ofn As New Functions
    Dim sm As New SendMail
    Public Scooter As Boolean = False, Car As Boolean = False, BothScooter As Boolean = False, BothCar As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            '  Mon.Text = Today.ToString("MMMM")
            Dim m As Integer

            If Today.Month = 1 Then
                m = 12
            Else
                m = Today.Month
            End If
            Mon.Text = MonthName(m)
            Yr.Text = DateTime.Now.Year
            ChkScooter_CheckedChanged(e, Nothing)
            ChkCar_CheckedChanged(e, Nothing)
        End If
            If (Session("Empcode").ToString <> "") Then
                'empcode = Session("Empcode")
            Else
                Response.Redirect("~/login.aspx")
            End If

    End Sub
    Protected Sub cmdapply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdApply.Click

        ChkScooter_CheckedChanged(e, Nothing)

        ChkCar_CheckedChanged(e, Nothing)

        Dim A, B, c As String
        A = Mon.SelectedIndex + 1
        B = Yr.SelectedValue

        If CInt(A) < 10 Then
            A = "0" + A
            c = Trim(B + A)
        Else
            c = Trim(B + A)
        End If



        If Me.ChkScooter.Checked = True And Scooter = False Then

            If Obj.Connection.State = ConnectionState.Closed Then
                Obj.Connection.Open()
            End If

            Try
                SqlPass = "Insert InTo JCT_Emp_Salary_Update select distinct 'JCT00LTD','" & Session("Empcode") & "','" & c & "',Catg,'" & Trim(Me.DateScooter.SelectedDate) & "',EmpCode,NULL,NULL,'ALL' from JCTDEV..JCT_EmpMast_Base Where Active='Y' and  Catg in('JM1','JM2','MM3')"
                Cmd = New SqlCommand(SqlPass, Obj.Connection)
                Cmd.ExecuteNonQuery()
                BothScooter = True
                Me.ChkScooter.Enabled = False
                Me.DateScooter.Enabled = False
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Scooter", "<Script Language = JavaScript>alert('Scooter Allowance Updated')</script>")
            Catch ex As Exception
                BothScooter = False
            Finally
                Obj.ConClose()
            End Try
            SendConveyenceSmS("('JM1','JM2','MM3')")
        End If


        If Me.ChkCar.Checked = True And Car = False Then

            If Obj.Connection.State = ConnectionState.Closed Then
                Obj.Connection.Open()
            End If

            Try
                SqlPass = "Insert InTo JCT_Emp_Salary_Update Select distinct 'JCT00LTD','" & Session("Empcode") & "','" & c & "',Catg,'" & Trim(Me.DateCar.SelectedDate) & "',EmpCode,NULL,NULL,'ALL' from JCTDEV..JCT_EmpMast_Base Where Active='Y' and  Catg in('MM1','MM2','SM3')"
                Cmd = New SqlCommand(SqlPass, Obj.Connection)
                Cmd.ExecuteNonQuery()
                BothCar = True
                Me.ChkCar.Enabled = False
                Me.DateCar.Enabled = False
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Car", "<Script Language = JavaScript>alert('Car Allowance Updated')</script>")
            Catch ex As Exception
                BothCar = False
            Finally
                Obj.ConClose()
            End Try
            SendConveyenceSmS("('MM1','MM2','SM3')")
        End If


        If BothScooter = True And BothCar = True Then
            CmdApply.Enabled = False
            CmdClear.Enabled = False
        End If

    End Sub
    Protected Sub Cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Me.ChkScooter.Checked = False
        Me.ChkCar.Checked = False
    End Sub
    Protected Sub ChkScooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkScooter.CheckedChanged
        Dim A, B, C As String
        A = Mon.SelectedIndex + 1
        B = Yr.SelectedValue

        If CInt(A) < 10 Then

            A = "0" + A

            C = Trim(B + A)

        Else

            C = Trim(B + A)

        End If

        SqlPass = "Select MonthYear From JCTDEV..JCT_Emp_Salary_Update Where MonthYear='" & C & "'and Catg in('JM1','JM2','MM3') and Type='ALL' "

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        If Dr.HasRows = True Then

            Me.DateScooter.Enabled = False
            Me.ChkScooter.Checked = True
            Me.ChkScooter.Enabled = False
            Scooter = True
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Scooter1", "<Script Language = JavaScript>alert('Scooter Allowance For This MonthYear Already Updated')</script>")

        Else

            Scooter = False

        End If

        Dr.Close()
        Obj.ConClose()



    End Sub
    Protected Sub ChkCar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCar.CheckedChanged

        Dim A, B, C As String

        A = Mon.SelectedIndex + 1

        B = Yr.SelectedValue

        If CInt(A) < 10 Then

            A = "0" + A

            C = Trim(B + A)

        Else

            C = Trim(B + A)

        End If

        If Obj.Connection.State = ConnectionState.Closed Then

            Obj.Connection.Open()

        End If

        SqlPass = "Select MonthYear From JCTDEV..JCT_Emp_Salary_Update Where MonthYear='" & C & "'and Catg in('MM1','MM2','SM3') and Type='ALL' "

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        If Dr.HasRows = True Then

            Me.DateCar.Enabled = False
            Me.ChkCar.Checked = True
            Me.ChkCar.Enabled = False
            Car = True

            ClientScript.RegisterClientScriptBlock(Me.GetType, "Car1", "<Script Language = JavaScript>alert('Car Allowance For This MonthYear Already Updated')</script>")

        Else

            Car = False

        End If

        Dr.Close()

        Obj.ConClose()

    End Sub
    Protected Sub Mon_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mon.SelectedIndexChanged
        ChkScooter_CheckedChanged(e, Nothing)
        ChkCar_CheckedChanged(e, Nothing)
    End Sub
    Protected Sub Yr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Yr.SelectedIndexChanged
        ChkScooter_CheckedChanged(e, Nothing)
        ChkCar_CheckedChanged(e, Nothing)
    End Sub
    Protected Sub SendConveyenceSmS(ByVal catg As String)

        Dim receiver As String = ""
        Dim msg As String = " Your Allowance has been sent for the month of " & Mon.SelectedItem.Text & " - " & Yr.SelectedItem.Text & " . The amount has been sent to your bank account."

        Dim sql As String = "select distinct a.empcode,c.name,c.mobile as [mobile],b.designation,b.catg from jct_empmast_base a inner join jct_emp_catg_desg_mapping b on a.catg=b.catg and a.company_code=b.company_code inner join mistel c on a.empcode=c.empcode and b.company_code=c.company_code where  c.mobile <>'' and c.mobile is not null and len(c.mobile)=10 and a.active='Y' and b.catg in " & catg & " order by b.catg"
        Dim dr As SqlDataReader
        dr = ofn.FetchReader(sql)
        If dr.HasRows = True Then
            While dr.Read()
                receiver += dr("mobile") + ","

            End While
            receiver = receiver.Remove(receiver.LastIndexOf(","c), 1)
            sm.SendSMS("JCT00LTD", "sys", receiver, msg, "Conveyence Allowance Sent")
        End If
        dr.Close()
    End Sub
End Class
