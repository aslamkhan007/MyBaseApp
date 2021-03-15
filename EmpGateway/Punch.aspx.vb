Imports System.Data
Imports System.Data.SqlClient

Partial Class Punch
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim Cmd As New SqlCommand
    Dim SqlPass As String
    Public AutoStr As String
    Dim AId As Integer, I As Integer, Tot As String

    Dim leave_date As String

    Public Sub BindData()

        ' Added for Uppal on April 16,2014 to show punch record for all employees
        If Session("Empcode") = "R-03339" Or Session("Empcode") = "H-01436" Or Session("Empcode") = "U-04002" And Trim(txtEmpName.Text) <> "" Then
            SqlPass = "exec misdev.savior.dbo.JCT_EMPG_Savior_new  '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "'   , '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  ,'" & Right(Trim(txtEmpName.Text), 7) & "' "
        Else
            SqlPass = "exec misdev.savior.dbo.JCT_EMPG_Savior_new  '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "'   , '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  , '" & Session("Empcode") & "' "
        End If
		
		'20 April 2017
        If Session("Empcode") = "P-03062" And Trim(txtDeptEmpName.Text) <> "" Then
            SqlPass = "exec misdev.savior.dbo.JCT_EMPG_Savior_new  '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "'   , '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  ,'" & Right(Trim(txtDeptEmpName.Text), 7) & "' "
        End If
        '20 April 2017

		
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Dim ds As DataSet = New DataSet()
        Try
            Da.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()

        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try


    End Sub
    Public Function applied() As Boolean
        Obj.ConOpen()
        If Session("Empcode") = "R-03339" Or Session("Empcode") = "H-01436" Or Session("Empcode") = "U-04002" And Trim(txtEmpName.Text) <> "" Then
            SqlPass = "select * from jct_empg_leave where empcode='" & Right(Trim(txtEmpName.Text), 7) & "' and '" & leave_date & "' between leavefrom and leaveto and mainflag<>'c'"

        Else
            SqlPass = "select * from jct_empg_leave where empcode='" & Session("Empcode") & "' and '" & leave_date & "' between leavefrom and leaveto and mainflag<>'c'"
        End If
		
		'20 April 2017
        If Session("Empcode") = "P-03062" And Trim(txtDeptEmpName.Text) <> "" Then
            SqlPass = "select * from jct_empg_leave where empcode='" & Right(Trim(txtDeptEmpName.Text), 7) & "' and '" & leave_date & "' between leavefrom and leaveto and mainflag<>'c'"
        End If
        '20 April 2017

		
        'SqlPass = "select * from jct_empg_leave where empcode='" & Session("Empcode") & "' and '" & leave_date & "' between leavefrom and leaveto and mainflag<>'c'"
        Cmd = New SqlCommand(SqlPass, Obj.Connection)
        Dim Dr As SqlDataReader = Cmd.ExecuteReader()
        If Dr.HasRows = True Then
            applied = True
        Else
            applied = False
        End If
        Obj.ConClose()
        Return applied
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")

            If Session("Empcode") = "R-03339" Or Session("Empcode") = "H-01436" Or Session("Empcode") = "U-04002" Then
                txtEmpName.Visible = True
                txtDeptEmpName.Visible = False
            Else

                '20 April 2017
                If Session("Empcode") = "P-03062" Then
                    txtDeptEmpName.Visible = True
                    txtEmpName.Visible = False
                Else
                    txtDeptEmpName.Visible = False
                    txtEmpName.Visible = False

                End If
            End If


            '20 April 2017

        Else
            Response.Redirect("~/login.aspx")
        End If


    End Sub

    
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        BindData()
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim status As String = DataBinder.Eval(e.Row.DataItem, "Status")
            Dim trans As LinkButton = CType(e.Row.FindControl("LinkButton1"), LinkButton)
            Dim Leave_Status As LinkButton = CType(e.Row.FindControl("Leave_Status"), LinkButton)
            Dim applied1 As Label = CType(e.Row.FindControl("Lblapplied"), Label)


            leave_date = Trim(Left(e.Row.Cells(0).Text.ToString(), 10))
            If status = "PRESENT" Or status = "WEEKLY OFF" Or status = "HOLIDAY" Or status Is System.DBNull.Value Or leave_date = now.date() Or status = "PRESENT ON WEEKLY OFF" Or status = "PRESENT ON HOLIDAY" Or status = "PRESENT ON WORK HOLIDAY Then" Then
                trans.Visible = False
                applied1.Visible = False
                Leave_Status.Visible = False
            Else
                If applied() = True Then
                    applied1.Visible = True
                    Leave_Status.Visible = True
                    trans.Visible = False
                Else
                    applied1.Visible = False
                    Leave_Status.Visible = False
                    trans.Visible = True
                End If
            End If
            '--------------------------------------------------------------------------------------------------------
            trans.PostBackUrl = "Leave_Application.aspx?trans1='" & Trim(Left(e.Row.Cells(0).Text.ToString(), 10)) & "'"
            Leave_Status.PostBackUrl = "Default2.aspx?trans1=Y"
        End If
    End Sub

    Protected Sub BtnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGet.Click
        If IsPostBack Then
            BindData()
        End If
    End Sub
End Class
