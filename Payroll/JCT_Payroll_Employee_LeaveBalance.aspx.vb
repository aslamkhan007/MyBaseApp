Imports System.Data
Imports System.Data.SqlClient
Partial Class Payroll_JCT_Payroll_Employee_LeaveBalance
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        Dim SqlPass As String = Nothing
        Dim Cmd As SqlCommand = New SqlCommand()
        SqlPass = "JCT_Payroll_Employee_LeaveBalance"
        Cmd = New SqlCommand(SqlPass, Obj.Connection())
        Cmd.CommandType = CommandType.StoredProcedure
        'Cmd.Parameters.Add("@employeecode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
        Cmd.Parameters.Add("@employeecode", SqlDbType.VarChar, 10).Value = "9000000537"
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Cmd)
        Dim ds As DataSet = New DataSet()
        Da.Fill(ds)
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

        If ds.Tables(0).Rows.Count = 0 Then
            Dim script As String = "alert('No Record Found');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
            Return
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not (Page.IsPostBack) Then
            BindData()
        End If
    End Sub

End Class


