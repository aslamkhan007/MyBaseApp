Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Image
Imports System.Drawing.Imaging
Partial Class SurveyResult
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Dim empcode As String

    Public Sub GetSurvey()
        obj.opencn()
        'qry = "select subject,confidential_flag from jct_emp_survey_Master where auth_Flag='A' and survey_no not in (select surveyno from jct_emp_survey_trans where usercode='" & Session("empcode") & "') and last_date>=getdate() and flag='R' order by subject"
        qry = "select subject,confidential_flag from jct_emp_survey_Master where auth_Flag='A' and survey_no not in (select surveyno from jct_emp_survey_trans where usercode='" & Session("empcode") & "') and last_date>=getdate() and survey_no='" & Me.Request.QueryString("Survey_num").ToString() & "' and flag='R' order by subject"

        cmd = New SqlCommand(qry, obj.cn)
        Me.LstResult.Items.Clear()
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            'Me.LstResult.Items.Add("")
            While dr.Read()
                Me.LstResult.Items.Add(dr(0))
                'Conf_Flag = dr(1)
            End While
        End If
        dr.Close()
        obj.closecn()
        GetParameters()

    End Sub
    Public Sub GetParameters()
        'qry = "select c.quest,a.survey_no from jct_emp_survey_quest_parameter a,jct_emp_survey_master b,jct_emp_survey_quest_master c where a.survey_no=b.survey_no and a.survey_no=c.survey_no and a.quest_no=c.quest_no and a.quest_no=" & Session("CurQuest") & " and b.subject='" & Me.LstResult.SelectedValue & "' and b.quest='" & LstQuest.SelectedValue & "' order by a.sequence_no"
        LstQuest.Items.Clear()
        'qry = "select c.quest,a.survey_no,c.imagename from jct_emp_survey_quest_parameter a,jct_emp_survey_master b,jct_emp_survey_quest_master c where a.survey_no=b.survey_no and a.survey_no=c.survey_no and a.quest_no=c.quest_no and b.subject='" & LstResult.SelectedValue & "' order by C.Quest"
        'LstQuest.Items.Add("")
        ' qry = "select c.quest,b.survey_no,c.quest_no from jct_emp_survey_master b,jct_emp_survey_quest_master c where b.survey_no=c.survey_no and b.subject='" & LstResult.SelectedValue & "'  group by b.survey_no,c.Imagename,c.quest order by c.Quest_no"
        qry = "select c.quest,b.survey_no,c.quest_no from jct_emp_survey_master b,jct_emp_survey_quest_master c where b.survey_no=c.survey_no and b.subject='" & LstResult.SelectedValue & "'  order by c.Quest_no"

        obj.opencn()

        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Try
            If dr.HasRows = True Then
                While dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else
                        LstQuest.Items.Add(dr(0))
                        'If dr(2) <> "" Then
                        '    SurImage.ImageUrl = "Survey/" + dr(2) '"D:/WebApplications/EmpGateway/Survey/" + dr(0)
                        '    CollapsablePanel1.Collapsed = False
                        '    CollapsablePanel1.Height = SurImage.Height
                        'Else
                        '    SurImage.ImageUrl = ""
                        '    CollapsablePanel1.Collapsed = True
                        'End If
                        Session("surveyno") = dr(1)

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

    Protected Sub LstQuest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstQuest.SelectedIndexChanged
        'GetParameters()
        GetImage()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("login.aspx")
        End If
        If Not IsPostBack = True Then
            GetSurvey()
            LstQuest_SelectedIndexChanged(sender, Nothing)
        End If
    End Sub

    Protected Sub LstResult_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstResult.SelectedIndexChanged
        GetParameters()
        LstQuest_SelectedIndexChanged(sender, Nothing)
    End Sub
    Private Sub GetImage()

        'Fname = "No Image"
        obj.opencn()
        'qry = "select c.imagename,a.survey_no from jct_emp_survey_quest_parameter a,jct_emp_survey_master b,jct_emp_survey_quest_master c where a.survey_no=b.survey_no and a.survey_no=c.survey_no and b.subject='Testing'   group by a.survey_no,c.Imagename,c.quest order by C.Quest"
        qry = "select c.imagename,b.survey_no from jct_emp_survey_master b,jct_emp_survey_quest_master c where b.survey_no=c.survey_no and b.subject='" & LstResult.SelectedValue & "' and c.quest='" & LstQuest.SelectedValue & "'  order by C.Quest"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                'Image1.ImageUrl = "D:/WebApplications/EmpGateway/Survey/" + dr(0)
                SurImage.ImageUrl = "Survey/" + dr(0) '"D:/WebApplications/EmpGateway/Survey/" + dr(0)
                Session("surveyno") = dr(1)
            End While
            CollapsablePanel1.Collapsed = False
            CollapsablePanel1.Height = SurImage.Height
        Else
            'Fname = ""
            SurImage.ImageUrl = ""
            CollapsablePanel1.Collapsed = True
        End If
        dr.Close()
        obj.closecn()
    End Sub

End Class
