Imports System.Data
Imports System.Data.SqlClient

Partial Class Default4
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Public Sub BindData()
        'Dim SqlPass = "select Cardno as [Card Number],Empname as [Name], desg as [Designation],Deptname as [Department] from jctdev..JCT_EmpMast_Base a,jctdev..deptmast b where month(a.doj)=month(getdate())-1 and year(doj)=year(getdate()) and a.deptcode=b.deptcode "
        'Dim SqlPass As String = "SELECT a.CARDNO,(E.SHORTDESC +' '+ A.FULLNAME)as Name ,C.LONGDESC AS Department ,RTRIM(LTRIM(D.LONGDESC)) AS [Designation],CONVERT(char, DOB,103) as  [Date Of Birth],CONVERT(char, DOJ,103) as  [Date Of Joining], G.Int_Off as [Office No(Intercom)] ,G.Int_Res as [Residence No(Intercom)], G.Epb_Off as [EPBX Office], G.Epb_Res as [EPBX Home]                     " & _
        '                "FROM Jct_Epor_Master_Employee A,JCT_EPOR_MASTER_CATEGORY B,JCT_Epor_MASTER_Dept  C, JCT_EPOR_MASTER_DESIGNATION D,JCT_EPOR_MASTER_SALUATION E  ,JCTGEN..JCT_Company_Master F, JCTDEV..mistel G            " & _
        '                "WHERE A.SALUTE=E.SALT_CODE AND  A.DEPT_CODE=C.DEPT_CODE AND A.DESG_CODE=D.DESG_CODE AND  D.CATEGORY=B.SHORTDESC  AND A.EMP_CODE*=G.EMPCODE AND  A.COMPANY_CODE=F.COMPANYCODE  AND A.ACTIVE_FLAG='Y'   AND A.STATUS='A' AND B.STATUS='A'  AND C.STATUS='A' AND D..STATUS='A'   AND E.STATUS='A'    AND A.EFF_TO>GETDATE() and  FULLNAME like '%" & TxtName.Text & "%' "



        Dim SqlPass As String = "SELECT  a.CARDNO , a.empname AS [NAME] ,Desg AS [Designation] ,CONVERT(CHAR, DOB, 103) AS [Date Of Birth] ,CONVERT(CHAR, DOJ, 103) AS [Date Of Joining] ,G.Int_Off AS [Office No(Intercom)] , " & _
                        "			 G.Int_Res AS [Residence No(Intercom)] ,G.Epb_Off AS [EPBX Office] ,G.Epb_Res AS [EPBX Home] " & _
                        "       FROM    JCT_EmpMast_Base A ,  JCTDEV..mistel G  WHERE   A.EMPCODE*=G.EMPCODE  AND A.COMPANY_CODE = G.COMPANY_CODE  AND ACTIVE = 'Y'  AND empname  like '%" & TxtName.Text & "%' "

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                DetailsView1.DataSource = ds
                DetailsView1.DataBind()
                Dr.Close()
                DetailsView1.Visible = True
                PictureBox1.Visible = True
                If Trim(DetailsView1.Rows(0).Cells(1).Text) <> "" Then
                    PictureBox1.ImageUrl = "..\EmployeePortal\EmpImages\" & Trim(DetailsView1.Rows(0).Cells(1).Text) & ".jpg"
                Else
                    PictureBox1.ImageUrl = "..\EmployeePortal\EmpImages\2.gif"
                End If
            Else
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                DetailsView1.Visible = False
                PictureBox1.Visible = False
            End If
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then

        Else
            Response.Redirect("~/login.aspx")
        End If

        DetailsView1.Visible = False
        PictureBox1.Visible = False
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        TxtName.Attributes.Add("onkeypress", "return clickButton(event,'" + Button2.ClientID + "')")
        'If Not (Page.IsPostBack) Then
        '    ' DetailsView1.Fields(1).Visible = False
        '    BindData()
        '    If DetailsView1.Rows.Count > 0 Then
        '        DetailsView1.Rows(0).Visible = False
        '    End If
        'End If
    End Sub

    Protected Sub DetailsView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewPageEventArgs) Handles DetailsView1.PageIndexChanging
        DetailsView1.PageIndex = e.NewPageIndex
        BindData()
        DetailsView1.Rows(0).Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' If Not (Page.IsPostBack) Then
        ' DetailsView1.Fields(1).Visible = False
        BindData()
        If DetailsView1.Rows.Count > 0 Then
            DetailsView1.Rows(0).Visible = False
        End If
        'End If
    End Sub
    Protected Sub TxtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged
        'Button1_Click(e, Nothing)
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        BindData()
        If DetailsView1.Rows.Count > 0 Then
            DetailsView1.Rows(0).Visible = False
        End If
    End Sub
End Class
