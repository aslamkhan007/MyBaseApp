Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading.Thread
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class MedicalReports
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim Fun As Functions = New Functions
    Dim SqlPass As String, SqlPass1 As String, Dr As SqlDataReader, Ds As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If

        If Page.IsPostBack Then
            REPORT()
            Session("RadioButton") = "a"
        End If

        DepartmentExt.ContextKey = "ALL"
    End Sub

    Protected Sub REPORT()
        Session("SqlPass1") = ""
        SqlPass = "EXEC   JCTDEV..JCT_EPOR_FAMILY_DETAIL"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dr.Close()


        Session("SqlPass1") = "SELECT * FROM JCT_EPOR_FAMILY WHERE " & _
                           "(COMPANY='" & TxtCompany.Text & "'                 OR  '" & TxtCompany.Text & "'=''           OR '" & TxtCompany.Text & "'='ALL' OR ' " & TxtCompany.Text & " '='JCT LIMITED') AND " & _
                           "(AREA='" & TxtArea.Text & "'                       OR  '" & TxtArea.Text & "'=''               OR '" & TxtArea.Text & "'='ALL'                  ) AND " & _
                           "(Division='" & TxtDivision.Text & "'               OR  '" & TxtDivision.Text & "'=''           OR '" & TxtDivision.Text & "'='ALL'              ) AND " & _
                           "(PARENT_DEPT='" & TxtParentDepartment.Text & "'    OR  '" & TxtParentDepartment.Text & "'=''   OR '" & TxtParentDepartment.Text & "'='ALL'      ) AND " & _
                           "(SUB_DEPT='" & TxtDepartment.Text & "'             OR  '" & TxtDepartment.Text & "'=''         OR '" & TxtDepartment.Text & "'='ALL'            ) AND " & _
                           "(DESIGNATION='" & TxtDesignation.Text & "'         OR  '" & TxtDesignation.Text & "'=''        OR '" & TxtDesignation.Text & "'='ALL'           ) AND " & _
                           "(FLAG='" & TxtDependent.Text & "'         OR  '" & TxtDependent.Text & "'=''        OR '" & TxtDependent.Text & "'='ALL'           ) AND " & _
                           "(SHORTDESC='" & TxtCategory.Text & "'              OR  '" & TxtCategory.Text & "'=''           OR '" & TxtCategory.Text & "'='ALL'              ) AND " & _
                           "(CARDNO BETWEEN '" & TxtCardFrom.Text & "' AND '" & TxtCardTo.Text & "'                        OR '" & TxtCardFrom.Text & "'=''                OR '" & TxtCardTo.Text & "'='')  AND " & _
                           "(DOB BETWEEN '" & TxtDOBFR.Text & "'       AND '" & TxtDOBTO.Text & "'                         OR '" & TxtDOBFR.Text & "'=''                   OR '" & TxtDOBTO.Text & "'='') AND " & _
                           "(DOR BETWEEN '" & TxtDORFr.Text & "'       AND '" & TxtDORTo.Text & "'                         OR '" & TxtDORFr.Text & "'=''                   OR '" & TxtDORTo.Text & "'=''  OR DOR <='" & TxtDORFr.Text & "') AND " & _
                           "(DATE_OF_CONFIRM BETWEEN '" & TxtConFr.Text & "'       AND '" & TxtConTo.Text & "'                         OR '" & TxtConFr.Text & "'=''                   OR '" & TxtConTo.Text & "'='') And " & _
                           "(DOJ BETWEEN '" & TxtEffFrom.Text & "'     AND '" & TxtEffTo.Text & "' OR '" & TxtEffFrom.Text & "'=''OR '" & TxtEffTo.Text & "'='')   " & _
                            "ORDER BY CARDNO"



    End Sub

    Protected Sub CmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdOK.Click
        Dim scrpt_str As String
        scrpt_str = "<script language='javascript'>window.opener=null;window.open('','_top'); window.open('\CrystalPopUp.aspx','','height=630, width= 810, status=yes, resizable= no, scrollbars= no, toolbar= no,location= center, menubar= no'); </script> "
        ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel1, Me.UpdatePanel1.GetType(), "scr", scrpt_str, False)
    End Sub


    Protected Sub TxtParentDepartment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtParentDepartment.TextChanged
        If Me.TxtParentDepartment.Text = "" Or Me.TxtParentDepartment.Text = "ALL" Then
            DepartmentExt.ContextKey = "ALL"
        Else
            DepartmentExt.ContextKey = Me.TxtParentDepartment.Text
        End If

    End Sub
    Protected Sub TxtDesignation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDesignation.TextChanged
        TxtCategory_AutoCompleteExtender.ContextKey = Me.TxtDesignation.Text
    End Sub

    Protected Sub CmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        TxtCompany.Text = Nothing
        TxtDivision.Text = Nothing
        TxtArea.Text = Nothing
        TxtDivision.Text = Nothing
        TxtParentDepartment.Text = Nothing
        TxtDepartment.Text = Nothing
        TxtDesignation.Text = Nothing
        TxtCategory.Text = Nothing
        TxtCardFrom.Text = Nothing
        TxtCardTo.Text = Nothing
        TxtDOBFR.Text = Nothing
        TxtDOBTO.Text = Nothing
        TxtEffFrom.Text = Nothing
        TxtEffTo.Text = Nothing
        TxtConFr.Text = Nothing
        TxtConTo.Text = Nothing
        TxtDORFr.Text = Nothing
        TxtDORTo.Text = Nothing
    End Sub
End Class