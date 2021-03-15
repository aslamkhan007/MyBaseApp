Imports System.Data
Imports System.Data.SqlClient


Partial Class Default3
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        Dim SqlPass = "select Months as [Month],monthyear AS [Year Month] ,isnull(ob,0) as [Opening Balance],isnull(ENTITLE,0)   as [Entitlement],ISNULL(last_reimb,0)  as [Last Reimbursement+ Dispensary],ISNULL(Curr_reimb,0) as [Current Reimbursement(Bill)],ISNULL(disp,0) as [Current Dispensary Cost],ISNULL(Balance,0) as [Available Balance] from jctdev..medmast where empcode='" & Session("Empcode") & "' ORDER BY monthyear DESC "
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
            Else
                Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('You are not entitled for medical !!')</script>")
            End If
        Catch ex As Exception
            Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        If Not (Page.IsPostBack) Then
            BindData()
        End If
    End Sub

    
End Class
