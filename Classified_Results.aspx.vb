
Partial Class Classified_Results
    Inherits System.Web.UI.Page
    Dim ob As CostModule = New CostModule
    Dim obFunction As Functions = New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obFunction.RegAppHit("JCT00LTD", "Anonymous", "Classifieds", Request.UserHostAddress)

            Dim sql As String = "jct_fap_classified_results 'JCT00LTD'" '"select Emp_Code 'EmpName', ComentDate 'Date', Coments 'Feedback' from jct_emp_feedback where flag = 'U' and status is null and company_code = 'JCT00LTD' and LTrim(RTrim(coments)) <> '' order by comentdate desc"
            dlFeedbacks.DataSource = ob.FetchDS(sql) '.Tables(0)
            dlFeedbacks.DataBind()


        End If
    End Sub
End Class
