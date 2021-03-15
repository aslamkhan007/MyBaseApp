Imports System.Data
Imports System.Data.SqlClient
Partial Class Default6
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim i, length As Integer
    Dim formname As String
    Dim ext As String
    Dim J As Integer

    Public Sub BindData()

        Dim SqlPass = "Select FileName,isnull(FileExt,'') as Fileext,navurl from jct_empg_forms a where int_ext='E' and type='F' and a.deptcode='" & Trim(Mid(DDL1.Text, 1, 3)) & "' and a.CompanyCode='" & Session("Companycode") & "' and auth_flag='A'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        Try
            If Dr.HasRows = True Then
                J = 1
                While Dr.Read()
                    formname = Dr.Item("FileName")
                    ext = Dr.Item("Fileext")
                    Dim hyper As New HyperLink
                    hyper.Text = J & ". " + Dr.Item("FileName") + "<BR>"
                    'hyper.NavigateUrl = "Downloadfile.aspx?filepth=E:\EmpGateway\Leave\" & formname & ext
                    If Dr(2) Is System.DBNull.Value Then
                        hyper.NavigateUrl = "Downloadfile.aspx?filepth=D:\WebApplications\FusionApps\EmpGateway\Leave\" & formname & ext
                    Else
                        hyper.NavigateUrl = Dr(2)
                    End If

                    Me.BothBox.Controls.Add(hyper)
                    J = J + 1
                End While
                Dr.Close()
                'PictureBox1.ImageUrl = "emp_images\" & Trim(DetailsView1.Rows(0).Cells(1).Text) & ".jpg"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Page.IsPostBack Then
            length = Len(DDL1.Text)
            If Trim(Session("deptname")) = Mid(DDL1.Text, 7, length) And RadioButtonList1.Items(0).Selected = True Then
                BindDataInternal()
            ElseIf RadioButtonList1.Items(1).Selected = True Then
                BindData()
            End If
        Else
            DDL1BindData()
        End If
    End Sub

    Public Sub BindDataInternal()

        Dim SqlPass = "Select FileName,isnull(FileExt,'') as Fileext,navurl from jct_empg_forms a   where  int_ext='I' and type='F' and a.CompanyCode='" & Session("Companycode") & "' and auth_flag='A'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        Try
            If Dr.HasRows = True Then
                J = 1
                While Dr.Read()
                    formname = Dr.Item("FileName")
                    Dim hyper As New HyperLink
                    hyper.Text = J & ". " + Dr.Item("FileName") + "<BR>"
                    ext = Dr.Item("Fileext")
                    ''hyper.NavigateUrl = "Downloadfile.aspx?filepth=E:\EmpGateway\Leave\" & formname & ext
                    If Dr(2) Is System.DBNull.Value Then
                        hyper.NavigateUrl = "Downloadfile.aspx?filepth=D:\WebApplications\EmpGateway\Leave\" & formname & ext
                    Else
                        hyper.NavigateUrl = Dr(2)
                    End If
                    Me.BothBox.Controls.Add(hyper)
                    J = J + 1
                End While
                Dr.Close()
                'PictureBox1.ImageUrl = "emp_images\" & Trim(DetailsView1.Rows(0).Cells(1).Text) & ".jpg"
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Public Sub DDL1BindData()

        Dim SqlPass = "SELECT distinct a.DEPTCODE + ' - ' + b.DEPTNAME AS 'deptname' from jct_empg_forms a , DEPTMAST b where a.deptcode=b.deptcode and a.CompanyCode='" & Session("Companycode") & "' and a.auth_flag='A'   "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                'i = 0
                'While Dr.Read()
                '    DDL1.Items(i).Text = Dr.Item("Deptname")
                '    i = i + 1
                'End While
                While Dr.Read
                    ddl1.Items.Add(Dr.Item("Deptname"))
                End While
                Dr.Close()
                Dr.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try
    End Sub

End Class



