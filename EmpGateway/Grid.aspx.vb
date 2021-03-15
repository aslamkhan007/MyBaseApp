Imports System.Data
Imports System.Data.SqlClient
Partial Class Grid
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        Dim SqlPass = "Select a.Empcode,a.Empname,a.Desg From Empmast a,Deptmast b where b.deptcode='" + Mid(DDLDeptname.Text, 1, 4) + "' and  a.deptcode='" + Mid(DDLDeptname.Text, 1, 4) + "'"
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
                Label1.Text = "No Record"
                GridView1.DataSource = Nothing
                GridView1.DataBind()
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
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        BindData()
    End Sub

    Protected Sub DDLDeptname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLDeptname.SelectedIndexChanged
        If (IsPostBack) Then
            BindData()
        End If
    End Sub
End Class
