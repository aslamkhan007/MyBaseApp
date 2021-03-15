Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports WebChart
Partial Class LostCustomerChart
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Dim I As Integer, J As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("TotalVotes") = Nothing
            GetReasons()
        End If
    End Sub
    Public Sub GetReasons()
        obj.opencn()
        qry = "select distinct reason,count(*) Counts from jct_cust_lost group by reason"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        'Me.DrpCustomers.Items.Clear()
        If dr.HasRows = True Then
            While dr.Read()
                'Me.DrpReason.Items.Add(Trim(dr(0)))
                Session("TotalVotes") = Session("TotalVotes") + dr(1)
                I = I + 1
            End While
        End If
        dr.Close()
        obj.closecn()
        CreateChart()
    End Sub
    Private Sub CreateChart()
        Dim Chart1 As ColumnChart = New ColumnChart
        For J = 0 To I - 1
            Chart1.MaxColumnWidth = 20
            Chart1.Fill.Color = Color.Salmon 'Color.FromName(ColorArray(J).ToString)
            Chart1.Shadow.Visible = True
            Dim reader As IDataReader = GetReader()
            Chart1.DataXValueField = "Reason"
            Chart1.DataYValueField = "Counts"
            Chart1.DataSource = reader
            Chart1.DataBind()
            reader.Close()
            ChartControl1.Charts.Add(Chart1)
        Next J
        ChartControl1.Legend.Position = LegendPosition.Bottom
        ChartControl1.ShowXValues = True
        ChartControl1.GridLines = GridLines.Both
        ChartControl1.ChartTitle.Text = "No. of Lost Customers:-  " & Session("TotalVotes") '"Survey Ratings " & vbCrLf & "No. of Lost Customers:-  " & Session("TotalVotes")
        ChartControl1.Background.ImageUrl = "Image/ChartBackGrnd.jpg"
        ChartControl1.YTitle.Text = "Total No. of Lost Customers"
        ChartControl1.YCustomStart = 0
        '----------------------------------------------------
        ChartControl1.XValuesInterval = 1
        ChartControl1.XTicksInterval = 1
        ChartControl1.XTitle.Text = "Parameters"
        ChartControl1.XAxisFont.StringFormat.Alignment = StringAlignment.Center
        '----------------------------------------------------
        If (Session("TotalVotes") > 0 And Session("TotalVotes") <= 20) Then
            ChartControl1.YValuesInterval = 1
            ChartControl1.YCustomEnd = Session("TotalVotes")
        ElseIf (Session("TotalVotes") > 20 And Session("TotalVotes") <= 50) Then
            ChartControl1.YValuesInterval = 2
            ChartControl1.YCustomEnd = Session("TotalVotes")
        ElseIf (Session("TotalVotes") > 50 And Session("TotalVotes") <= 100) Then
            ChartControl1.YValuesInterval = 5
            ChartControl1.YCustomEnd = Session("TotalVotes")
        ElseIf (Session("TotalVotes") > 100 And Session("TotalVotes") <= 200) Then
            ChartControl1.YValuesInterval = 10
            ChartControl1.YCustomEnd = Session("TotalVotes")
        ElseIf (Session("TotalVotes") > 200 And Session("TotalVotes") <= 300) Then
            ChartControl1.YValuesInterval = 20
            ChartControl1.YCustomEnd = Session("TotalVotes")
        ElseIf (Session("TotalVotes") > 300) Then
            ChartControl1.YValuesInterval = 30
            ChartControl1.YCustomEnd = Session("TotalVotes")
        End If
        ChartControl1.RedrawChart()
    End Sub
    Function GetReader() As IDataReader
        qry = "select distinct reason,count(*) Counts from jct_cust_lost group by reason"
        cmd = New SqlCommand(qry, obj.cn)
        obj.opencn()
        Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
    End Function
End Class
