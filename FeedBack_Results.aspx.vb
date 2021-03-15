
Partial Class FeedBack_Results
    Inherits System.Web.UI.Page
    Dim ob As CostModule = New CostModule
    Dim obfunction As Functions = New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obfunction.RegAppHit("JCT00LTD", "Anonymous", "FusionApps", Request.UserHostAddress)
            Dim sql As String = "jct_fap_feedbacks 'JCT00LTD'" '"select Emp_Code 'EmpName', ComentDate 'Date', Coments 'Feedback' from jct_emp_feedback where flag = 'U' and status is null and company_code = 'JCT00LTD' and LTrim(RTrim(coments)) <> '' order by comentdate desc"
            dlFeedbacks.DataSource = ob.FetchDS(sql).Tables(0)
            dlFeedbacks.DataBind()
        End If
    End Sub
End Class
