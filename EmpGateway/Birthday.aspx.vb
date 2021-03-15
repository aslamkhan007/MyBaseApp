Imports System.Data
Imports System.Data.SqlClient


Partial Class Birthday
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim empcode As String

    Public Sub BindData()
        'INSTEAD OF THIS REPLACE A NEWCODE FROM PORTAL 24/SEP/2009
        '-----
        ''Dim SqlPass = "select a.cardno as [Card No],a.Empname as [Employee Name] , a.Desg as Designation , c.deptname as [Department Name] ,convert(char,A.DOB,103) as  [Date Of Birth], b.Int_Off as [Office No(Intercom)] ,b.Int_Res as [Residence No(Intercom)], b.Epb_Off as [EPBX Office], b.Epb_Res as [EPBX Home]  from JctDev..jct_empmast_base a,  JCTDEV..mistel b, JCTDEV..deptmast  c " & _
        ''"where Month(a.dob) = Month(getdate()) and day(a.dob)=day(getdate()) and a.empcode *=b.empcode and  a.deptcode=c.deptcode and a.active='Y' and a.Company_Code='" & Session("Location") & "' and C.Company_Code='" & Session("Location") & "'"

        '----
        'If Session("empcode").ToString = "A-00098" Or Session("empcode").ToString = "H-01436" Or Session("empcode").ToString = "J-01838" Or Session("empcode").ToString = "R-03339" Then

        Dim SqlPass = "select a.cardno as [Card No],a.Empname as [Employee Name] , a.Desg as Designation , c.deptname as [Department Name] ,convert(char,A.DOB,103) as  [Date Of Birth], b.Int_Off as [Office No(Intercom)] ,b.Int_Res as [Residence No(Intercom)], b.Epb_Off as [EPBX Office], b.Epb_Res as [EPBX Home]  from JctDev..jct_empmast_base a,  JCTDEV..mistel b, JCTDEV..deptmast  c " & _
        "where Month(a.dob) = Month(getdate()) and day(a.dob)=day(getdate()) and a.empcode *=b.empcode and  a.deptcode=c.deptcode and a.active='Y' and a.Company_Code='JCT00LTD' and C.Company_Code='JCT00LTD'"

        'SqlPass = " SELECT a.CARDNO,(E.SHORTDESC +' '+ A.FULLNAME)as Name ,C.LONGDESC AS Department ,RTRIM(LTRIM(D.LONGDESC)) AS [Designation],CONVERT(char, DOB,103) as  [Date Of Birth],CONVERT(char, DOJ,103) as  [Date Of Joining], G.Int_Off as [Office No(Intercom)] ,G.Int_Res as [Residence No(Intercom)], G.Epb_Off as [EPBX Office], G.Epb_Res as [EPBX Home]                     " & _
        '                "FROM Jct_Epor_Master_Employee A,JCT_EPOR_MASTER_CATEGORY B,JCT_Epor_MASTER_Dept  C, JCT_EPOR_MASTER_DESIGNATION D,JCT_EPOR_MASTER_SALUATION E  ,JCTGEN..JCT_Company_Master F, JCTDEV..mistel G            " & _
        '                "WHERE A.SALUTE=E.SALT_CODE AND  A.DEPT_CODE=C.DEPT_CODE AND A.DESG_CODE=D.DESG_CODE AND  D.CATEGORY=B.SHORTDESC  AND A.EMP_CODE*=G.EMPCODE AND  A.COMPANY_CODE=F.COMPANYCODE  AND A.ACTIVE_FLAG='Y'   AND A.STATUS='A' AND B.STATUS='A'  AND C.STATUS='A' AND D..STATUS='A'   AND E.STATUS='A'  AND  Month(dob) = Month(getdate()) and day(dob)=day(getdate())  AND A.EFF_TO>GETDATE() order by A.FULLNAME"
        ''temp - just for showing specific record
        'Dim SqlPass = "select a.cardno as [Card No],a.Empname as [Employee Name] , a.Desg as Designation , c.deptname as [Department Name] ,convert(char,A.DOB,103) as  [Date Of Birth], b.Int_Off as [Office No(Intercom)] ,b.Int_Res as [Residence No(Intercom)], b.Epb_Off as [EPBX Office], b.Epb_Res as [EPBX Home]  from jctdev..empmast a,  jctdev..mistel b, jctdev..deptmast  c " & _
        '"where Month(a.dob) = 8 and day(a.dob)=22 and a.empcode *=b.empcode and  a.deptcode=c.deptcode"

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
                PictureBox1.ImageUrl = "..\EmployeePortal\EmpImages\" & Trim(DetailsView1.Rows(0).Cells(1).Text) & ".jpg"
            Else
                Image1.Visible = True
                PictureBox1.Visible = False
                Image2.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try


        'End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not (Page.IsPostBack) Then
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
End Class
