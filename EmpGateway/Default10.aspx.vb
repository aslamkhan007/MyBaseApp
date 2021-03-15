Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail

Partial Class Default10
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim ECode, CurLeaTime As String
    'Store means Autoid Number
    Dim Store As String
    Dim DateVar As DateTime
    Dim DateMinus As Integer
   

    Public Sub BindData()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,LeaveFrom ,LeaveTo from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='U' and flag='H' and Resp_emp='" & Trim(ECode) & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Public Sub Authorize()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,LeaveFrom ,LeaveTo from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='OK' and flag='H' and Resp_emp='" & Trim(ECode) & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Public Sub Cancle()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature ,Empcode as EmployeeCode,Name,Desgination,Department,LeaveFrom ,LeaveTo from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='C' and flag='H' and Resp_emp='" & Trim(ECode) & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
            BindData()
            If DropDownList1.Text = "Pending" Then
                BindDataAdmin()
                DateDiff()
            End If

            If DateMinus > 0 Then
                mail48()
            End If
        End If
    End Sub

    Public Sub BindDataAdmin()
        Dim SqlPass = "select CurLeaveTime from JCTDEV..JCT_EMPG_LEAVE  where  AuthFlag='U'"
        ' and a.Empcode='" & Trim(Session("Empcode")) & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    CurLeaTime = Dr.Item("CurLeaveTime")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Public Sub DateAdd()
        'SqlPass = "select dateadd(day,2,'" & CurLeaTime & "') as DateAfter "
        SqlPass = "select dateadd(mi,2,'" & CurLeaTime & "') as DateAfter "

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    DateVar = Dr.Item("DateAfter")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Public Sub DateDiff()
        'SqlPass = "select dateadd(day,2,'" & CurLeaTime & "') as DateAfter "
        SqlPass = "select DateDiff(ss,'" & DateVar & "',getdate()) as DateDif "

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    DateMinus = Dr.Item("DateDif")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Sub

    
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        If DropDownList1.Text = "Authorize" Then
            Authorize()
            GridView1.Enabled = False
        ElseIf DropDownList1.Text = "Cancle" Then
            Cancle()
            GridView1.Enabled = False
        ElseIf DropDownList1.Text = "Pending" Then
            BindData()
            GridView1.Enabled = True
        Else

        End If

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If DropDownList1.Text = "Pending" Then
            Session("Store") = GridView1.SelectedRow.Cells(1).Text
            Me.Page.Visible = False
            Response.Redirect("default11.aspx")
            GridView1.Enabled = True
        End If
    End Sub

    Private Sub mail48()
        Dim ObjMail As New Mail.MailMessage
        With ObjMail
            ObjMail.From = "hitesh@jctltd.com"
            ObjMail.To = "kakhan@jctltd.com"
            'ObjMail.Cc = "Kakhan@jctltd.com"
            ''ObjMail.Bcc = "hitesh.infics@yahoo.com"
            ObjMail.BodyFormat = MailFormat.Html
            ObjMail.Priority = MailPriority.High
            ObjMail.Body = "Please Intimate for authorize pending leave !"
            Mail.SmtpMail.SmtpServer = "exchange2003"
            '' Mail.SmtpMail.SmtpServer = "90.0.1.247"
            Mail.SmtpMail.Send(ObjMail)
            ' ObjMail = Nothing
        End With
    End Sub
End Class
