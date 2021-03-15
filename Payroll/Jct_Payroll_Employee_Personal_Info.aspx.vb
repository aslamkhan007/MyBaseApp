Imports System.Data
Imports System.Data.SqlClient
Partial Class Payroll_Jct_Payroll_Employee_Personal_Info
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        'Dim SqlPass = "select convert(char,Date,103) as [Date of Loan],LOANSANC as [Loan Amount],INST_AMT as [Installment Amount],INST_TOTAL as [Total Installment],INST_PAID as [Installment Paid],INST_LEFT as [Installment Left],LOAN_PAID as [Amount Paid],AMT_DUE as [Balance Amount] from Jctdev..pfloan where empcode='" & Session("Empcode") & "'"        
        SqlPass = "Jct_Payroll_Employee_Personal_Info"
        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection())
        cmd.CommandType = CommandType.StoredProcedure
        'cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
        cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = "9000000334"
        'Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Dr As SqlDataReader
        Dr = cmd.ExecuteReader

        Dim Da As SqlDataAdapter = New SqlDataAdapter(cmd)
        'cmd.CommandType = CommandType.StoredProcedure
        'cmd.Parameters.Add("@employeecode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
        'cmd.ExecuteNonQuery()

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
