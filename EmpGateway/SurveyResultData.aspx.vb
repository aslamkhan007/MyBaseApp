Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Class EmpGateway_SurveyResultData
    Inherits System.Web.UI.Page
    Dim obj As New CostModule
    Dim Sql As String
    Dim con As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Panel1.Visible = False
        If IsPostBack = False Then

            If Session("empcode").ToString <> "" Then
            Else
                Response.Redirect("~/login.aspx")
            End If
            Me.rbl_Format.Items(1).Selected = True
            'Sql = "select survey_no, subject from jctdev..jct_emp_survey_master where auth_Flag='A'  order by  survey_no desc"
            Sql = "select survey_no, subject from jctdev..jct_emp_survey_master a where  (Confidential_flag='N' or '" & Session("empcode") & "'='R-03339') and Auth_Flag='A'  union select Survey_no,subject from jct_emp_survey_master a, jct_empmast_base b where (a.user_code= b.empcode and b.deptcode in (select e.deptcode from jct_empmast_base e, jct_emp_hod f where e.empcode=f.emp_code and f.status is null and f.resp_emp in (SELECT '" & Session("empcode") & "' UNION SELECT emp_code FROM jct_emp_hod WHERE resp_emp = '" & Session("empcode") & "' or resp_emp in (SELECT emp_code FROM jct_emp_hod WHERE resp_emp = '" & Session("empcode") & "')) ))  and Auth_Flag='A'"
            ddl_Survey.Items.Add("Select")
            obj.fillList(ddl_Survey, Sql)
            AutoCompleteExtender7.ContextKey = "JCT00LTD"
        Else
            'gridfill()
            HeaderStyle.ActiveTabIndex = 0

        End If
    End Sub
    Protected Sub grd_Quest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd_Quest.SelectedIndexChanged
        txt_Quest.Text = grd_Quest.SelectedRow.Cells(2).Text
        txt_QuestNo.Text = grd_Quest.SelectedRow.Cells(1).Text
        ddl_Parameter.Items.Clear()
        If txt_Quest.Text <> "" Then
            Sql = "Select quest_no , parametername from jctdev..jct_emp_survey_quest_parameter where survey_no=" & ddl_Survey.SelectedValue & " and quest_no=" & txt_QuestNo.Text & " order by quest_no"
            Dim lst As New ListItem
            lst.Value = 0
            lst.Text = "Select"
            ddl_Parameter.Items.Add(lst)
            obj.fillList(ddl_Parameter, Sql)
        End If
    End Sub
    Private Sub gridfill()
        If ddl_Survey.SelectedItem.Text <> "Select" Then
            Sql = "Select quest_no, quest From jctdev..jct_emp_survey_quest_master where survey_no = " & ddl_Survey.SelectedItem.Value & " order by quest_no"
            obj.FillGrid(Sql, grd_Quest)
        End If
    End Sub
    Protected Sub ddl_Survey_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_Survey.SelectedIndexChanged
        If ddl_Survey.Text = "Select" Then
            lnk_Quest.CssClass = "buttondisable"
            txt_Quest.Text = ""
            txt_QuestNo.Text = ""
        Else
            lnk_Quest.CssClass = "buttonc"
            lnk_Quest.Enabled = True
        End If
        txt_Quest.Text = ""
        txt_QuestNo.Text = ""
        gridfill()
    End Sub
    Protected Sub rbl_Format_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_Format.SelectedIndexChanged
        If rbl_Format.SelectedItem.Text = "Chart" Then
            lbl_Employee.Visible = True
            txt_Employee.Visible = True
            GrdData.Visible = False
        Else
            lbl_Employee.Visible = False
            txt_Employee.Visible = False
        End If
    End Sub
   
    Protected Sub lnk_View_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If rbl_Format.SelectedItem.Text = "Data" Then
            Sql = "SELECT  b.fullname ,f.PARAMETERNAME as Parameter , a.Rating as Rating , a.coments as Comments,e.LongDesc AS Desg,c.LongDesc AS Dept,'~/EmployeePortal/EmpImages/'+ convert(varchar(10),b.cardno) + '.jpg' as ImgURL FROM    dbo.Jct_Emp_Survey_Trans a INNER JOIN dbo.Jct_Epor_Master_Employee b ON a.usercode = b.emp_code  AND b.status = 'A' AND GETDATE() BETWEEN b.eff_from AND b.eff_to INNER JOIN jct_epor_master_dept c ON c.dept_code = b.dept_code AND c.status = 'A'AND GETDATE() BETWEEN c.eff_from AND c.eff_to left OUTER JOIN jct_epor_div_area_master d ON b.division = d.code  AND d.TYPE = 'DIV' AND d.status = 'A' left outer JOIN jct_epor_div_area_master g ON  b.Area= g.code AND g.TYPE = 'Are' AND g.status = 'A' AND GETDATE() BETWEEN d.eff_from AND d.eff_to INNER JOIN jct_epor_master_designation e ON e.desg_code = b.desg_code AND e.status = 'A' AND GETDATE() BETWEEN e.eff_from AND e.eff_to INNER JOIN jct_emp_survey_quest_parameter f ON f.quest_no = a.quest_no AND a.surveyno=f.SURVEY_NO  AND a.ParameterSeqNo=f.SEQUENCE_NO WHERE   surveyno = " & ddl_Survey.SelectedItem.Value & "  AND (d.Description LIKE '%" & txt_Division.Text & "%' OR 'ALL'='ALL' ) AND(c.longdesc LIKE	'%" & txt_ParentDeptt.Text & "%' OR 'ALL'='ALL') AND (d.description like '%" & txt_Department.Text & "%' OR 'ALL'='All') AND (e.LongDesc LIKE '%" & txt_Designation.Text & "%' OR 'ALL'='ALL') AND(e.Category LIKE '%" & txt_Category.Text & "%' OR 'ALL'='ALL') AND(g.DESCRIPTION LIKE '%" & txt_Area.Text & "%' OR 'ALL'='ALL') AND (b.Fullname LIKE '%" & txt_Employee.Text & "%' OR 'ALL'='ALL') and a.quest_no='" & txt_QuestNo.Text & "' and (f.sequence_no=" & ddl_Parameter.SelectedValue & " or 0=" & ddl_Parameter.SelectedValue & ")"
            obj.FillGrid(Sql, GrdData)
            GrdData.Visible = True
        Else
            Panel1.Visible = True
            GrdData.Visible = True
            Session("X-Parameter") = "rating"
            Session("Heading") = "Survey Result"
            Session("Param1Heading") = "Survey :"
            Session("Param1Value") = ddl_Survey.SelectedItem.Text
            Session("Param2Heading") = "Question :"
            Session("Param2Value") = txt_Quest.Text
            Session("Param3Heading") = "Survey Number :"
            Session("Param3Value") = ddl_Survey.SelectedValue
            Session("Param4Heading") = "Question Number :"
            Session("Param4Value") = txt_QuestNo.Text
            Session("PageType") = "Survey result"
            Session("chart") = "select parametername AS rating , case when QnCatg='R' THEN SUM(CASE WHEN isnumeric(a.rating)=1 THEN CONVERT(INT,a.rating) ELSE 1 end) ELSE COUNT(a.rating) end as Votes  from jct_emp_survey_trans a, JCT_EMP_SURVEY_QUEST_MASTER b , JCT_EMP_SURVEY_QUEST_PARAMETER c where a.surveyno=b.survey_no and a.quest_no=b.quest_no and a.surveyno=c.survey_no and a.quest_no=c.quest_no AND a.ParameterSeqNo=c.SEQUENCE_NO and a.surveyno= " & ddl_Survey.SelectedValue & " and a.quest_no=" & txt_QuestNo.Text & " group by parametername,c.sequence_no ,qncatg order by c.SEQUENCE_NO"
            Dim scrpt_str As String = "<script language='javascript'>window.opener=null;window.open('','_top'); window.open('\PopupChart.aspx','','height=700, width= 900, status=yes, resizable= yes, scrollbars= yes, toolbar= no,location= center, menubar= no'); </script> "
            ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel4, Me.UpdatePanel4.GetType(), "scr", scrpt_str, False)
        End If
    End Sub
End Class
