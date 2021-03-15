Imports System.Data
Imports System.Data.SqlClient
Partial Class book_allowance
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        Dim SqlPass = "select isnull(OB,0) as [Opening Balance],isnull(Entitle,0)  as [Entitlement],isnull(last_reimb,0)  as [Last Reimbursement],isnull(Curr_reimb,0) as [Current Reimbursement],isnull(Balance,0) as [Available Balance] from jctdev..bokmast  where empcode='" & Session("Empcode") & "'"
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
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('You are not entitled for Book Allowance')</script>")
            End If
        Catch ex As Exception

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
