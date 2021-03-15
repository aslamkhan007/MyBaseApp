Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading.Thread
Imports System.Web.UI.DataVisualization.Charting
Partial Class SalesAnalysisSystem_popupChart
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection, Cmd As SqlCommand, Ds As New DataSet
    Dim SqlPass As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim series As New Series("Actual Payment")
        series.ChartType = SeriesChartType.Line
        SetAxisInterval(Chart1.ChartAreas("ChartArea1").AxisY, 5)
        Dim Cmd As SqlCommand = New SqlCommand(Session("Chart"), Obj.Connection)
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Chart1.DataBindTable(Dr, Session("X-Parameter"))
        Me.heading.Text = Session("Heading")
        Me.Param1Heading.Text = Session("Param1Heading")
        Me.Param1Value.Text = Session("Param1Value")
        Me.Param2Heading.Text = Session("Param2Heading")
        Me.Param2Value.Text = Session("Param2Value")
        Me.Param3Heading.Text = Session("Param3Heading")
        Me.Param3Value.Text = Session("Param3Value")
        Me.Param4Heading.Text = Session("Param4Heading")
        Me.Param4Value.Text = Session("Param4Value")
        Me.lbldate.Text = Now.Date()
        Dr.Close()
        Obj.ConClose()
        HoverImages()

    End Sub

    Public Sub SetAxisInterval(ByVal axis As Axis, ByVal interval As Double)
        axis.Interval = interval
    End Sub

    Protected Sub HoverImages()
        Dim series As Series
        For Each series In Chart1.Series
            Dim pointIndex As Integer
            For pointIndex = 0 To series.Points.Count - 1

                Dim toolTip As String = ""
                If Session("PageType") = "Hits" Then
                    If Session("X-Parameter") = "Application Name" Then
                        toolTip = "<div align=center><IMG width = 250px height = 250px  SRC=" + "Image/" + Replace(Trim(series.Points(pointIndex).AxisLabel), " ", "-") + ".jpg><br/><font face=verdana  color=red size=0.5>" & Mid(series.ToString, 8, Len(series.ToString)) & " = " & series.Points(pointIndex).YValues.GetValue(0).ToString & " </font></div>"
                    Else
                        toolTip = "<div align=center><br/><font face=verdana  color=red size=0.5>" & Mid(series.ToString, 8, Len(series.ToString)) & " = " & series.Points(pointIndex).YValues.GetValue(0).ToString & " </font></div>"
                    End If
                ElseIf Session("PageType") = "Survey result" Then
                    toolTip = "<div align=center><br/><font face=verdana  color=red size=0.5>" & Mid(series.ToString, 8, Len(series.ToString)) & " = " & series.Points(pointIndex).YValues.GetValue(0).ToString & " </font></div>"

                Else
                    toolTip = "<div align=center><br/><font face=verdana  color=red size=0.5>" & Mid(series.ToString, 8, Len(series.ToString)) & " = " & series.Points(pointIndex).YValues.GetValue(0).ToString & " </font></div>"
                End If



                series.Points(pointIndex).MapAreaAttributes = "onmouseover=""DisplayTooltip('" + toolTip + "');"" onmouseout=""DisplayTooltip('');"""
            Next
        Next







    End Sub
End Class
