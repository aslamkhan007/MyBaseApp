Imports System.Data
Imports System.Data.SqlClient
Partial Class LeaveMaster
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim Cmd As New SqlCommand
    Dim SqlPass As String
    Public AutoStr As String
    Dim AId As Integer, I As Integer, Tot As String
    Dim Fun As Functions

    Public Sub BindData()
        Dim SqlPass = "Select [Id]=Autoid ,[Name]=name,Department,Desgination,[Card No]=cardno,[Leave Name]=NatureLeave,convert(char,leavefrom,103) as [ From ] ,convert(char,leaveto,103) as [ To ],[Leave Type]=LeaveType  from jct_empg_leave where  mainflag='p' and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' order by department,natureleave,cardno"
        '        Dim SqlPass = "Select [Auto Id]=Autoid ,[Salary Code]=Empcode,[Name]=name,Department,Desgination,[Card No]=cardno,[Leave Name]=NatureLeave,[Leave From]=LeaveFrom,[Leave To]=Leaveto,[Leave Type]=LeaveType  from jct_empg_leave where mainflag='p'"

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
            End If


        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then
            '  BindData()
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

         Dim remarks As TextBox
        Dim atLeastOneRowDeleted As Boolean = False
        Dim i As Long = 1
        For Each row As GridViewRow In GridView1.Rows

            Dim cb As CheckBox = row.FindControl("CheckBox1")
            If cb IsNot Nothing AndAlso cb.Checked Then
                atLeastOneRowDeleted = True

                Dim ID As Integer = Convert.ToInt32(GridView1.Rows(row.RowIndex).Cells(2).Text)
                remarks = row.FindControl("txtRemarks")
                If i = 1 Then
                    AutoStr += ID
                Else
                    AutoStr += "," & ID
                End If


                i = i + 1
            End If
        Next
        If AutoStr <> "" Then
            SqlPass = "update  jctdev..jct_empg_leave set mainflag='A' ,lasttime=getdate(),EntryMater='" & Session("Empname") & "',FlagHC='Sign',ActionDone_PermisssionBY='" & remarks.Text & "'  where  autoid in(" & AutoStr & ") "
            Obj.FetchReader(SqlPass)
            Obj.ConClose()
            BindData()
        End If
    End Sub

    Private Sub ToggleCheckState(ByVal checkState As Boolean)

        For Each row As GridViewRow In GridView1.Rows
            Dim cb As CheckBox = row.FindControl("Checkbox1")
            If cb IsNot Nothing Then
                cb.Checked = checkState
            End If
        Next

    End Sub

    Protected Sub Check_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Check.Click
        ToggleCheckState(True)
    End Sub


    Protected Sub UnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UnCheck.Click
        ToggleCheckState(False)
    End Sub

    Protected Sub GridView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        BindData()
    End Sub

    Protected Sub BtnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGet.Click
        BindData()
    End Sub

     
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        SqlPass = "Select [Id]=Autoid ,[Name]=name,Department,Desgination,[Card No]=cardno,[Leave Name]=NatureLeave,convert(char,leavefrom,103) as [ From ] ,convert(char,leaveto,103) as [ To ],[Leave Type]=LeaveType  from jct_empg_leave where  mainflag='p' and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' "
        Fun.Sorting(SqlPass, GridView1, e)
    End Sub
    Protected Sub CmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
	  Dim remarks As TextBox
        Dim atLeastOneRowDeleted As Boolean = False
        Dim i As Long = 1
        For Each row As GridViewRow In GridView1.Rows

            Dim cb As CheckBox = row.FindControl("CheckBox1")
            If cb IsNot Nothing AndAlso cb.Checked Then
                atLeastOneRowDeleted = True

                Dim ID As Integer = Convert.ToInt32(GridView1.Rows(row.RowIndex).Cells(2).Text)
                remarks = row.FindControl("txtRemarks")

                If i = 1 Then
                    AutoStr += ID
                Else
                    AutoStr += "," & ID
                End If


                i = i + 1
            End If
        Next
        If AutoStr <> "" Then
            SqlPass = "update  jctdev..jct_empg_leave set mainflag='C' ,lasttime=getdate(),EntryMater='" & Session("Empname") & "',FlagHC='Sign',ActionDone_PermisssionBY='" & remarks.Text & "'  where  autoid in(" & AutoStr & ") "
            Obj.FetchReader(SqlPass)
            Obj.ConClose()
            BindData()
        End If


    End Sub
End Class