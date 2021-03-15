Imports System.Data
Imports System.Data.SqlClient


Partial Class PfLoan
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        Dim SqlPass = "select convert(char,Date,103) as [Date of Loan],LOANSANC as [Loan Amount],INST_AMT as [Installment Amount],INST_TOTAL as [Total Installment],INST_PAID as [Installment Paid],INST_LEFT as [Installment Left],LOAN_PAID as [Amount Paid],AMT_DUE as [Balance Amount] from Jctdev..pfloan where empcode='" & Session("Empcode") & "'"
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
                Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('You have not taken PF Loan')</script>")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            BindData()
        End If
    End Sub


End Class
