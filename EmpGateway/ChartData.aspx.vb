Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Partial Class EmpGateway_ChartData
    Inherits System.Web.UI.Page
    Dim obj1 As New CostModule
    Dim Obj As Connection = New Connection
    Dim Ds As DataSet
    Dim Cmd As SqlCommand
    Dim qry As String
    Public field3, field4 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim field1 As String = Session("field1")
        'Dim field2 As String = Session("field2")

        Dim field1 As String = Session("field1")
        Dim field2 As String = Session("field2")
        Dim field3 As String = Session("field3")
        Dim field4 As String = Session("field4")
        lbl_Survey1.Text = field3
        lbl_QuestionNumber.Text = field4
        Session.Remove("field1")
        Session.Remove("field2")
        Session.Remove("field3")
        Session.Remove("field4")
        Dim series As New Series("ChartData")
        series.ChartType = SeriesChartType.Line
        SetAxisInterval(Chart1.ChartAreas("ChartArea1").AxisY, 5)
        qry = "select parametername AS rating , case when QnCatg='R' THEN SUM(CASE WHEN isnumeric(a.rating)=1 THEN CONVERT(INT,a.rating) ELSE 1 end) ELSE COUNT(a.rating) end as Votes  from jct_emp_survey_trans a, JCT_EMP_SURVEY_QUEST_MASTER b , JCT_EMP_SURVEY_QUEST_PARAMETER c where a.surveyno=b.survey_no and a.quest_no=b.quest_no and a.surveyno=c.survey_no and a.quest_no=c.quest_no AND a.ParameterSeqNo=c.SEQUENCE_NO and a.surveyno= " & field1 & " and a.quest_no=" & field2 & " group by parametername,c.sequence_no ,qncatg order by c.SEQUENCE_NO"
        Dim Cmd As SqlCommand = New SqlCommand(qry, Obj.Connection)
        Dim Dr As SqlDataReader = Cmd.ExecuteReader
        Chart1.DataBindTable(Dr, Trim("Rating"))
        Dr.Close()
        Obj.ConClose()
        Chart1.Series(0).XValueMember = "Parameters"
        Chart1.Series(0).YValueMembers = "Votes"
        HoverText()
    End Sub
    Protected Sub HoverText()
        Dim series As Series
        For Each series In Chart1.Series
            Dim pointIndex As Integer
            For pointIndex = 0 To series.Points.Count - 1

                Dim toolTip As String = ""
                toolTip = "<div align=center><IMG width = 90px height = 120px  SRC=" + "Image/" + Replace(Trim(series.Points(pointIndex).AxisLabel), " ", "-") + ".jpg><br/><font face=verdana  color=red size=0.5>" & Mid(series.ToString, 8, Len(series.ToString)) & " = " & series.Points(pointIndex).YValues.GetValue(0).ToString & " </font></div>"
                series.Points(pointIndex).MapAreaAttributes = "onmouseover=""DisplayTooltip('" + toolTip + "');"" onmouseout=""DisplayTooltip('');"""
            Next
        Next
    End Sub
    Public Sub SetAxisInterval(ByVal axis As Axis, ByVal interval As Double)
        axis.Interval = interval
    End Sub
    Protected Sub Chart1_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart1.Click
        Dim Sql As String = "SELECT f.PARAMETERNAME as Parameter , a.Rating as Rating , a.coments as Comments FROM    dbo.Jct_Emp_Survey_Trans a INNER JOIN dbo.Jct_Epor_Master_Employee b ON a.usercode = b.emp_code  AND b.status = 'A' AND GETDATE() BETWEEN b.eff_from AND b.eff_to INNER JOIN jct_epor_master_dept c ON c.dept_code = b.dept_code AND c.status = 'A'AND GETDATE() BETWEEN c.eff_from AND c.eff_to left OUTER JOIN jct_epor_div_area_master d ON b.division = d.code  AND d.TYPE = 'DIV' AND d.status = 'A' left outer JOIN jct_epor_div_area_master g ON  b.Area= g.code AND g.TYPE = 'Are' AND g.status = 'A' AND GETDATE() BETWEEN d.eff_from AND d.eff_to INNER JOIN jct_epor_master_designation e ON e.desg_code = b.desg_code AND e.status = 'A' AND GETDATE() BETWEEN e.eff_from AND e.eff_to INNER JOIN jct_emp_survey_quest_parameter f ON f.quest_no = a.quest_no AND a.surveyno=f.SURVEY_NO  AND a.ParameterSeqNo=f.SEQUENCE_NO WHERE   surveyno = " & field3 & ""
        obj1.FillGrid(Sql, grd_chart)
    End Sub
End Class
