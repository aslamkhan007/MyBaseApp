Imports System.Data
Imports System.Data.SqlClient
Partial Class Payroll_Jct_Payroll_Left_Employees
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Public Sub BindData()


        'SqlPass = "SELECT distinct a.CARDNO ,( a.Mr_Mrs + ' ' + A.empname ) AS [Employee Name] , RTRIM(LTRIM(a.Desg)) AS [Designation] , c.DEPTNAME AS [Department] , CONVERT(CHAR, DOB, 103) AS [Date Of Birth] ," & _
        '          " CONVERT(CHAR, DOJ, 103) AS [Date Of Joining] , CONVERT(CHAR, DOL, 103) AS [Date Of leaving] FROM    JCT_EmpMast_Base A , dbo.DEPTMAST C , JCTDEV..mistel G  " & _
        '          "WHERE   A.empcode*=G.EMPCODE        AND A.DEPTCODE = C.DEPTCODE AND A.COMPANY_CODE = G.COMPANY_CODE AND A.ACTIVE = 'N'   AND DATEDIFF(day, A.DOL, GETDATE()) <= 240 ORDER BY A.DOL DESC   "


        SqlPass = "Jct_Payroll_LeftEmployees_Portal_Report"
        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection())
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@employeecode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
        'Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Dr As SqlDataReader
        Dr = cmd.ExecuteReader
        Dim Da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                DetailsView1.DataSource = ds
                DetailsView1.DataBind()
                Dr.Close()
                PictureBox1.ImageUrl = "..\EmployeePortal\EmpImages\" & Trim(DetailsView1.Rows(0).Cells(1).Text) & ".jpg"
            End If
        Catch ex As Exception
            Throw ex
            'MsgBox(ex.Message)
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

        If Not (Page.IsPostBack) Then
            ' DetailsView1.Fields(1).Visible = False
            BindData()
            If DetailsView1.Rows.Count > 0 Then
                DetailsView1.Rows(0).Visible = False
            End If

        End If
    End Sub

    Protected Sub DetailsView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewPageEventArgs) Handles DetailsView1.PageIndexChanging
        DetailsView1.PageIndex = e.NewPageIndex
        BindData()
        DetailsView1.Rows(0).Visible = False
    End Sub

    Protected Sub DetailsView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetailsView1.PreRender

    End Sub
End Class
