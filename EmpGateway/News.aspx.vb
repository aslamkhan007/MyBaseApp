Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Default6
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Public i, Transaction As Integer
    Dim formname As String
    Dim Ext, Int, Dept, Extension, Desc As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            ''empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Page.IsPostBack Then

            If RadioButtonList1.Items(0).Selected = True Then
                BindDataInt()
            ElseIf RadioButtonList1.Items(1).Selected = True Then
                BindDataExt()
            End If
        End If
    End Sub

    Public Sub BindDataExt()
        Dim SqlPass = " Select FileName,FileExt,transaction_no,Department,description from jctdev..jct_empg_News a where datediff(day,News_End_date,getdate())<=0 and a.department='" + Mid(DDL1.Text, 1, 4) + "' and int_ext_flag='E' and OutdatedFlag='N' and Auth_Flag='A'  order by  transaction_no desc"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    Desc = IIf(Dr.Item("Description") Is System.DBNull.Value, "", Dr.Item("Description"))
                    Dept = IIf(Dr.Item("Department") Is System.DBNull.Value, "", Dr.Item("Department"))
                    Transaction = Dr.Item("transaction_no")
                    formname = Dr.Item("FileName")
                    Dim hyper As New HyperLink
                    hyper.Text = Dr.Item("description") + "<BR>"
                    Extension = Dr.Item("FileExt")
                    hyper.NavigateUrl = "NewsDetail.aspx?description=" & Desc & "&Transac=" & Transaction & "&path=News\" & Dept & "\Ext\" & formname & Extension
                    ' hyper.NavigateUrl = "NewsDetail.aspx?path=News\" & Dept & "\Ext\" & formname & Extension
                    panel1.Controls.Add(hyper)
                    'Downloadfile.aspx?filepth=e:\empgateway\Leave\" & formname & ext
                End While
                Dr.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub
   
    Public Sub BindDataInt()
        Dim SqlPass = " Select FileName,FileExt,transaction_no,Department from jctdev..jct_empg_News a where datediff(day,News_End_date,getdate())<=0 and a.department='" + Mid(DDL1.Text, 1, 4) + "' and int_ext_flag='I' and OutdatedFlag='N' and Auth_Flag='A'"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    Dept = Dr.Item("Department")
                    Transaction = Dr.Item("transaction_no")
                    formname = Dr.Item("FileName")
                    Dim hyper As New HyperLink
                    hyper.Text = Dr.Item("FileName") + "<BR>"
                    Extension = Dr.Item("FileExt")
                    ' hyper.NavigateUrl = "Downloadfile.aspx?filepth=e:\empgateway\News\" & Dept & "\Int\" & formname & Extension
                    hyper.NavigateUrl = "NewsDetail.aspx?description=" & Desc & "&Transac=" & Transaction & "&path=News\" & Dept & "\Int\" & formname & Extension
                    panel1.Controls.Add(hyper)
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
