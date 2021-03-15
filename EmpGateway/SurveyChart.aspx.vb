Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports WebChart
Partial Class SurveyChart
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String, empcode As String, ParamList(50) As String, votes(50) As String
    Public dr As SqlDataReader
    Dim GD As Integer = 0
    Dim Avg As Integer = 0
    Dim BAvg As Integer = 0
    Public I As Integer
    Dim J As Integer
    Dim ColorArray(50) As String
    Dim BarName As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        
        If Not IsPostBack Then
            If (Request.QueryString.Get("Survey_num")) >= 1 Then 'And (Request.QueryString.Get("Surveyno") > 0) Then 'Or Request.QueryString.Get("reply")) Then 'And (Request.QueryString.Get("task") = 1 Or Request.QueryString.Get("reply")) Then
                HyperLink1.Visible = True
                HyperLink2.Visible = True
            Else
                HyperLink1.Visible = False
                HyperLink2.Visible = False
            End If
            GetQuest()
            LstQuest_SelectedIndexChanged(sender, Nothing)
            J = 0
        End If
    End Sub
    Private Sub CreateChart()
        Dim Chart1 As ColumnChart = New ColumnChart
        For J = 0 To I - 1
            Chart1.MaxColumnWidth = 20
            'Chart1.Fill.Color = Color.FromArgb(100, 150, 0, (J + 10) * 5)
            Chart1.Fill.Color = Color.Red  'Color.FromName(ColorArray(J).ToString)
            'color.FromArgb(255 ColorArray(J).ToString ' EF5F49 'Color.FromArgb(200, 0, 0, 150)
            Chart1.Shadow.Visible = True

            Dim reader As IDataReader = GetReader()
            Chart1.DataXValueField = "Rating"
            Chart1.DataYValueField = "Votes"
            Chart1.DataSource = reader
            Chart1.DataBind()
            reader.Close()
            ChartControl1.Charts.Add(Chart1)
        Next J
        'ChartControl1.HasChartLegend = False
        ChartControl1.Legend.Position = LegendPosition.Bottom
        'ChartControl1.Legend.Width = 60
        'ChartControl1.ShowYValues = True 
        ChartControl1.ShowXValues = True
        ChartControl1.GridLines = GridLines.Both
        ChartControl1.ChartTitle.Text = "Survey Ratings " & vbCrLf & "Total Ratings:-  " & ViewState("TotalRating")
        ChartControl1.Background.ImageUrl = "Image/ChartBackGrnd.jpg"
        ChartControl1.YTitle.Text = "Votes"

        ' ChartControl1.XTicksInterval = 1
        'ChartControl1.RenderHorizontally = True ' To Display IT Horizontally
        ChartControl1.YCustomStart = 0
        '----------------------------------------------------
        'ChartControl1.ShowXValues = True
        'ChartControl1.XTicksInterval = 10
        ChartControl1.XValuesInterval = 1
        ChartControl1.XTicksInterval = 1
        ChartControl1.XTitle.Text = "Parameters"

        ChartControl1.XAxisFont.StringFormat.Alignment = StringAlignment.Center

        '----------------------------------------------------
        If (ViewState("TotalVotes") > 0 And ViewState("TotalVotes") <= 20) Then
            ChartControl1.YValuesInterval = 1
            'ChartControl1.YValuesInterval = 1
            ChartControl1.YCustomEnd = ViewState("TotalVotes")
        ElseIf (ViewState("TotalVotes") > 20 And ViewState("TotalVotes") <= 50) Then
            ChartControl1.YValuesInterval = 2
            ChartControl1.YCustomEnd = ViewState("TotalVotes")
        ElseIf (ViewState("TotalVotes") > 50 And ViewState("TotalVotes") <= 100) Then
            ChartControl1.YValuesInterval = 5
            ChartControl1.YCustomEnd = ViewState("TotalVotes")
        ElseIf (ViewState("TotalVotes") > 100 And ViewState("TotalVotes") <= 200) Then
            ChartControl1.YValuesInterval = 10
            ChartControl1.YCustomEnd = ViewState("TotalVotes")
        ElseIf (ViewState("TotalVotes") > 200 And ViewState("TotalVotes") <= 300) Then
            ChartControl1.YValuesInterval = 20
            ChartControl1.YCustomEnd = ViewState("TotalVotes")
        ElseIf (ViewState("TotalVotes") > 300) Then
            ChartControl1.YValuesInterval = 30
            ChartControl1.YCustomEnd = ViewState("TotalVotes")
        End If
        ChartControl1.RedrawChart()

    End Sub

    Public Sub GetQuest()
        LstQuest.Items.Clear()
        'older than 26-sep qry = "select c.quest,b.survey_no,c.quest_no from jct_emp_survey_master b,jct_emp_survey_quest_master c where b.survey_no=c.survey_no and b.subject='" & LstResult.SelectedValue & "'  order by c.Quest_no"

        If (Request.QueryString.Get("Survey_num")) >= 1 Then 'And (Request.QueryString.Get("Surveyno") > 0) Then 'Or Request.QueryString.Get("reply")) Then 'And (Request.QueryString.Get("task") = 1 Or Request.QueryString.Get("reply")) Then
            'till 4-12008qry = "select distinct a.quest,b.subject from jct_emp_survey_quest_master a,jct_emp_survey_master b where a.survey_no=b.survey_no and a.survey_no=" & Request.QueryString.Get("Survey_num") & " group by a.quest,b.subject " '& " and a.quest='" & LstQuest.SelectedValue & "'"
            qry = "select distinct a.quest,b.subject,a.quest_no from jct_emp_survey_quest_master a,jct_emp_survey_master b,jct_emp_survey_quest_parameter c where a.survey_no=b.survey_no and a.survey_no=c.survey_no and a.survey_no=" & Request.QueryString.Get("Survey_num") & " and a.quest_no=c.quest_no group by a.quest,b.subject,a.quest_no order by a.quest_no"
        End If
        obj.opencn()
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Try
            If dr.HasRows = True Then
                While dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else
                        Dim lst As New ListItem
                        lst.Value = dr(2)
                        lst.Text = dr(0)
                        LstQuest.Items.Add(lst)
                        Label2.Text = "Survey Results for """ & dr(1) & """"
                        '                        Session("surveyno") = dr(1)
                    End If    'Downloadfile.aspx?filepth=e:\empgateway\Leave\" & formname & ext

                End While
                dr.Close()
            End If
        Catch exp As Exception
            Response.Write(exp.ToString())
        Finally
            obj.closecn()
        End Try
    End Sub
    Public Sub GetUserdata()
        If (Request.QueryString.Get("reply")) = 1 And (Request.QueryString.Get("Survey_num") > 0) Then 'Or Request.QueryString.Get("reply")) Then 'And (Request.QueryString.Get("task") = 1 Or Request.QueryString.Get("reply")) Then
            obj.opencn()
            'qry = "select distinct a.quest from jct_emp_survey_quest_master a, jct_emp_survey_trans b where b.surveyno=" & Request.QueryString.Get("Survey_num") & " and a.quest='" & LstQuest.SelectedValue & "'"
            qry = "select dept_code,subject,Image_name,Last_date,confidential_flag,user_code from jct_emp_survey_Master where survey_no=" & Request.QueryString.Get("Surveyno") & " "
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                    Response.Write("<script>alert('Nothing To Display')</script>")
                Else
                    'Label2.Text = "Survey Results for the survey """ & dr(1) & """"
                End If
            Else
                'Response.Write("<script>alert('No Survey For Authorization')</script>")
                Response.Write("<script>alert('Nothing To Display')</script>")
            End If
            dr.Close()
            obj.closecn()
        End If
        '---------------------------------------
    End Sub

    Protected Sub LstQuest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstQuest.SelectedIndexChanged
        obj.opencn()
        ViewState("TotalVotes") = 0
        ViewState("TotalRating") = 0
        I = 0

        ' qry = "select distinct a.rating,count(*) from jct_emp_survey_trans a,jct_emp_survey_quest_master b where a.surveyno=b.survey_no and a.quest_no=b.quest_no and a.surveyno=" & Request.QueryString.Get("Survey_num") & " and b.quest='" & Replace(LstQuest.SelectedValue, "'", "''") & "' group by a.rating"
        'Above Commented and Below Code Added By Neha on 30th March 2010
        qry = "select parametername AS rating , case when QnCatg='R' THEN SUM(CASE WHEN isnumeric(a.rating)=1 THEN CONVERT(INT,a.rating) ELSE 1 end) ELSE COUNT(a.rating) end as Votes, COUNT(a.rating) as Rate, QnCatg  from jct_emp_survey_trans a, JCT_EMP_SURVEY_QUEST_MASTER b , JCT_EMP_SURVEY_QUEST_PARAMETER c where a.surveyno=b.survey_no and a.quest_no=b.quest_no and a.surveyno=c.survey_no and a.quest_no=c.quest_no AND a.ParameterSeqNo=c.SEQUENCE_NO and a.surveyno=" & Request.QueryString.Get("Survey_num") & " and a.quest_no=" & LstQuest.SelectedValue & " group by parametername,c.sequence_no ,qncatg order by c.SEQUENCE_NO"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                ParamList.SetValue(dr(0), I)
                votes.SetValue(CStr(dr(1)), I)
                If dr(3) = "R" Then
                    ViewState("TotalRating") = dr(2)
                Else
                    ViewState("TotalRating") = ViewState("TotalRating") + dr(2)
                End If
                ViewState("TotalVotes") = ViewState("TotalVotes") + dr(1)
                I = I + 1
            End While
        End If
        dr.Close()
        obj.closecn()

        '' '' '' ''Getcolor()
        CreateChart()
    End Sub
    
    Function GetReader() As IDataReader
        ' qry = "select distinct a.Rating,count(*) Votes from jct_emp_survey_trans a,jct_emp_survey_quest_master b where a.surveyno=b.survey_no and a.quest_no=b.quest_no and a.surveyno=" & Request.QueryString.Get("Survey_num") & " and b.quest='" & Replace(LstQuest.SelectedValue, "'", "''") & "' group by a.rating order by rating desc"
        'Above Commented and Below Code Added By Neha on 30th March 2010
        qry = "select parametername AS rating , case when QnCatg='R' THEN SUM(CASE WHEN isnumeric(a.rating)=1 THEN CONVERT(INT,a.rating) ELSE 1 end) ELSE COUNT(a.rating) end as Votes, COUNT(a.rating) as Rate, QnCatg  from jct_emp_survey_trans a, JCT_EMP_SURVEY_QUEST_MASTER b , JCT_EMP_SURVEY_QUEST_PARAMETER c where a.surveyno=b.survey_no and a.quest_no=b.quest_no and a.surveyno=c.survey_no and a.quest_no=c.quest_no AND a.ParameterSeqNo=c.SEQUENCE_NO and a.surveyno=" & Request.QueryString.Get("Survey_num") & " and a.quest_no=" & LstQuest.SelectedValue & " group by parametername,c.sequence_no ,qncatg order by c.SEQUENCE_NO"
        cmd = New SqlCommand(qry, obj.cn)
        obj.opencn()

        Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
    End Function
End Class
