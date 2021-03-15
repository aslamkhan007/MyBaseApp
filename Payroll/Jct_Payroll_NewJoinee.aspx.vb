Imports System.Data
Imports System.Data.SqlClient

Partial Class Payroll_Jct_Payroll_NewJoinee
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Public Sub BindData()
        'Dim SqlPass = "select Cardno as [Card Number],Empname as [Name], desg as [Designation],Deptname as [Department] from jctdev..JCT_EmpMast_Base a,jctdev..deptmast b where month(a.doj)=month(getdate())-1 and year(doj)=year(getdate()) and a.deptcode=b.deptcode "
        Dim SqlPass As String '= "select Cardno as [Card Number],Empname as [Employee Name], desg as [Designation],Deptname as [Department],convert(char,A.DOJ,103) as [Date Of Joining] from jctdev..JCT_EmpMast_Base a,jctdev..deptmast b where a.doj between getdate()-90 and getdate() and a.deptcode=b.deptcode and a.active='y' and a.Company_Code='" & Session("Location") & "'  and a.Company_Code='" & Session("Location") & "' and b.Company_Code='" & Session("Location") & "' order by cardno "
        'SqlPass = "SELECT a.CARDNO,(E.SHORTDESC +' '+ A.FULLNAME)as [Employee Name] ,RTRIM(LTRIM(D.LONGDESC)) AS   [Designation],c.LongDesc as [Department], CONVERT(char, DOB,103) as [Date Of Birth],CONVERT(char, DOJ,103) as  [Date Of Joining]" & _
        '          "FROM Jct_Epor_Master_Employee A,JCT_EPOR_MASTER_CATEGORY B,JCT_Epor_MASTER_Dept  C, JCT_EPOR_MASTER_DESIGNATION D,JCT_EPOR_MASTER_SALUATION E  ,JCTGEN..JCT_Company_Master F, JCTDEV..mistel G               " & _
        '          "WHERE A.SALUTE=E.SALT_CODE AND  A.DEPT_CODE=C.DEPT_CODE AND A.DESG_CODE=D.DESG_CODE AND  D.CATEGORY=B.SHORTDESC  AND A.EMP_CODE*=G.EMPCODE AND  A.COMPANY_CODE=F.COMPANYCODE  AND A.ACTIVE_FLAG='Y'   AND A.STATUS='A' " & _
        '          "AND B.STATUS='A'  AND C.STATUS='A' AND D.STATUS='A'   AND E.STATUS='A'AND   doj between GETDATE()-30 and GETDATE()  AND A.EFF_TO>GETDATE() ORDER BY 1 DESC"
        'Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        'Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        'SqlPass = "Jct_Payroll_NewJoinning_Portal_Report"
        SqlPass = "Jct_Payroll_Joinning_Portal_Report"
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

        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then

        Else
            Response.Redirect("~/login.aspx")
        End If

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
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
