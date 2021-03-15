Imports System.Data
Imports System.Data.SqlClient
Partial Class Office
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim i, length As Integer
    Dim formname As String
    Dim ext As String
    Dim J As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then

        Else
            Response.Redirect("~/login.aspx")
        End If

        'If Page.IsPostBack Then
        '    length = Len(DDL1.Text)
        '    BindData()
        'Else
        '    DDL1BindData()
        'End If
        If Not Page.IsPostBack Then
            DDL1BindData()
        End If


        length = Len(DDL1.Text)
        BindData()
    End Sub
    Public Sub BindData()

        Dim SqlPass = " Select FileName,FileExt from  jct_empg_Order a where a.deptcode='" & Trim(Mid(DDL1.Text, 1, 4)) & "' and CompanyCode='" & Session("Companycode") & "' and auth_flag='A' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                J = 1
                While Dr.Read()
                    formname = Dr.Item("FileName")
                    Dim hyper As New HyperLink
                    hyper.Text = J & ". " + Dr.Item("FileName") + "<BR>"
                    ext = Dr.Item("Fileext")
                    hyper.NavigateUrl = "Downloadfile.aspx?filepth=D:\WebApplications\FusionApps\EmpGateway\Order\" & formname & ext
                    Me.BothBox.Controls.Add(hyper)
                    J = J + 1
                End While
                Dr.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Public Sub DDL1BindData()
        Dim SqlPass = "SELECT distinct a.DEPTCODE + ' - ' + b.DEPTNAME AS 'deptname' from JCT_Empg_Order a , DEPTMAST b where a.deptcode=b.deptcode and a.CompanyCode='" & Session("Companycode") & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                'Commented by Jagdeep 17Feb2009
                'i = 0
                'While Dr.Read()
                '    DDL1.Items(i).Text = Dr.Item("Deptname")
                '    i = i + 1
                'End While

                While Dr.Read
                    ddl1.Items.Add(Dr.Item("Deptname"))
                End While
                Dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Sub

End Class







