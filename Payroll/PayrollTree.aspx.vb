Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Payroll_PayrollTree
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String, Concat As String, SqlPass1 As String, Sqlpass2 As String, Sqlpass3 As String, Sqlpass4 As String, Sqlpass5 As String, Sqlpass6 As String, Dept As String
    Dim row As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
        Else
            Response.Redirect("~\login.aspx")
        End If

        If Not Page.IsPostBack Then
            Image1.ImageUrl = "..\EmployeePortal\EmpImages\0006.jpg"
            Label1.Text = "Mr. Kamal Bhasin"
            Label2.Text = "Business Head"

            Dim Sqlpass As String = "SELECT  DISTINCT  RESP_EMP,DESG_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.RESP_EMP = B.EMPCODE) AND  FLAG='1H' AND STATUS IS NULL AND ACTIVE='Y' AND RESP_EMP='K-02171' and a.Company_Code='" & Session("Companycode") & "' ORDER BY  DESG_CODE DESC"
            'Dim SqlPass = "SELECT  DISTINCT TOP 1 RESP_EMP,DESG_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.RESP_EMP = B.EMPCODE) AND DEPTCODE='ACT'  AND FLAG='1H' AND STATUS IS NULL ORDER BY  DESG_CODE DESC "
            ' Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)

            Dim daHod As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

            ' Dr.Close()
            Dim objDS As New DataSet
            daHod.Fill(objDS, "dtHod")

            Obj.ConClose()

            Dim nodeResp, nodeUnder, nodeUnder2, nodeUnder3, nodeUnder4, nodeUnder5, nodeUnder6 As TreeNode
            Dim rowResp, rowUnder, rowUnder2, rowUnder3, rowUnder4, rowUnder5, rowUnder6 As DataRow
            Dim ID1 As String
            For Each rowResp In objDS.Tables("dtHod").Rows

                nodeResp = New TreeNode
                'nodeResp.Text = rowResp("EMPNAME") + " " + ":" + " " + "R-03437"
                'nodeResp.Text = rowResp("EMPNAME") + " " + ":" + " " + "M-00063"
                nodeResp.Text = rowResp("EMPNAME") + " " + ":" + " " + "K-02171"
                ID1 = rowResp("RESP_EMP")
                TreeView1.Nodes.Add(nodeResp)

                '---------------Paent Node-----------------------
                'Dim SqlPass1 As String = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE)  AND  FLAG='1H' AND STATUS IS NULL AND ACTIVE='Y' AND Resp_Emp='" & ID1 & " ' AND a.Company_Code='" & Session("Companycode") & "' "
                Dim SqlPass1 As String = "SELECT DISTINCT RequsterCode AS EMP_CODE , ReqEmpName AS EMPNAME FROM dbo.Jct_Payroll_WorkFlow_Request WHERE Status = 'A' AND AreaApply =  'Leave' AND Plant = 'Pln-100' AND ActionTakenBy = '9000000806' order by ReqEmpName  "
                '" & Session("Location") & "' "
                'Dim SqlPass1 = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE) AND DEPTCODE='ACT' AND  FLAG='1H' AND STATUS IS NULL AND Resp_Emp='" & ID1 & " '  "
                Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
                Dim daUnder As SqlDataAdapter = New SqlDataAdapter(SqlPass1, Obj.Connection())

                Dr1.Close()
                Dim objDS1 As New DataSet
                daUnder.Fill(objDS1, "dtUnder")
                Dim ID2 As String
                For Each rowUnder In objDS1.Tables("dtUnder").Rows

                    nodeUnder = New TreeNode
                    nodeUnder.Text = rowUnder("EMPNAME") + " " + ":" + " " + rowUnder("EMP_CODE")
                    ID2 = rowUnder("EMP_CODE")
                    nodeResp.ChildNodes.Add(nodeUnder)
                    'Dim SqlPass2 As String = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE)  AND  FLAG='1H' AND STATUS IS NULL AND ACTIVE='Y' AND Resp_Emp='" & ID2 & " ' AND a.Company_Code='" & Session("Companycode") & "'"
                    Dim SqlPass2 As String = "SELECT DISTINCT RequsterCode AS EMP_CODE , ReqEmpName AS EMPNAME FROM dbo.Jct_Payroll_WorkFlow_Request WHERE Status = 'A' AND AreaApply =  'Leave' AND Plant = 'Pln-100' AND ActionTakenBy = '" & ID2 & "' order by  ReqEmpName "

                    'Dim SqlPass2 = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE) AND DEPTCODE='ACT' AND  FLAG='1H' AND STATUS IS NULL AND Resp_Emp='" & ID2 & " '  "
                    Dim Dr2 As SqlDataReader = Obj.FetchReader(SqlPass2)
                    Dim daUnder2 As SqlDataAdapter = New SqlDataAdapter(SqlPass2, Obj.Connection())
                    Dr2.Close()

                    Dim objDS2 As New DataSet
                    daUnder2.Fill(objDS2, "dtUnder2")

                    Dim ID3 As String
                    For Each rowUnder2 In objDS2.Tables("dtUnder2").Rows

                        nodeUnder2 = New TreeNode
                        nodeUnder2.Text = rowUnder2("EMPNAME") + " " + ":" + " " + rowUnder2("EMP_CODE")
                        ID3 = rowUnder2("EMP_CODE")
                        nodeUnder.ChildNodes.Add(nodeUnder2)

                        '----------------------------Level 4----------------------
                        Dim SqlPass3 As String = "Jct_Payroll_WorkFlow_Hierarchy_Rowwise '" & ID3 & "'"
                        'Dim SqlPass2 = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE) AND DEPTCODE='ACT' AND  FLAG='1H' AND STATUS IS NULL AND Resp_Emp='" & ID2 & " '  "
                        Dim Dr3 As SqlDataReader = Obj.FetchReader(SqlPass3)
                        Dim daUnder3 As SqlDataAdapter = New SqlDataAdapter(SqlPass3, Obj.Connection())
                        Dr3.Close()
                        Dim objDS3 As New DataSet
                        daUnder3.Fill(objDS3, "dtUnder3")

                        Dim ID4 As String
                        For Each rowUnder3 In objDS3.Tables("dtUnder3").Rows
                            nodeUnder3 = New TreeNode
                            nodeUnder3.Text = rowUnder3("ActionFlag1") + " " + ":" + "    " + rowUnder3("ActionTakenBy1") + "    " + rowUnder3("ActionFlag2") + " " + ":" + " " + rowUnder3("ActionTakenBy2") + " " + rowUnder3("ActionFlag3") + " " + ":" + " " + rowUnder3("ActionTakenBy3")
                            'ID4 = rowUnder3("ActionTakenBy1")
                            nodeUnder2.ChildNodes.Add(nodeUnder3)
                            '    '----------------------------------------------------Level 5--------------------------------
                            '    Dim SqlPass4 As String = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE)  AND  FLAG='1H' AND STATUS IS NULL AND ACTIVE='Y' AND Resp_Emp='" & ID4 & " ' AND a.Company_Code='" & Session("Companycode") & "'   "
                            '    'Dim SqlPass2 = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE) AND DEPTCODE='ACT' AND  FLAG='1H' AND STATUS IS NULL AND Resp_Emp='" & ID2 & " '  "
                            '    Dim Dr4 As SqlDataReader = Obj.FetchReader(SqlPass4)
                            '    Dim daUnder4 As SqlDataAdapter = New SqlDataAdapter(SqlPass4, Obj.Connection())
                            '    Dr4.Close()

                            '    Dim objDS4 As New DataSet
                            '    daUnder4.Fill(objDS4, "dtUnder4")

                            '    Dim ID5 As String
                            '    For Each rowUnder4 In objDS4.Tables("dtUnder4").Rows

                            '        nodeUnder4 = New TreeNode
                            '        nodeUnder4.Text = rowUnder4("EMPNAME") + " " + ":" + " " + rowUnder4("EMP_CODE")
                            '        ID5 = rowUnder4("EMP_CODE")
                            '        nodeUnder3.ChildNodes.Add(nodeUnder4)
                            '        '----------------------------------------------------Level 6--------------------------------
                            '        Dim SqlPass5 As String = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE)  AND  FLAG='1H' AND STATUS IS NULL AND ACTIVE='Y' AND Resp_Emp='" & ID5 & " '  AND a.Company_Code='" & Session("Companycode") & "' "
                            '        'Dim SqlPass2 = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE) AND DEPTCODE='ACT' AND  FLAG='1H' AND STATUS IS NULL AND Resp_Emp='" & ID2 & " '  "
                            '        Dim Dr5 As SqlDataReader = Obj.FetchReader(SqlPass5)
                            '        Dim daUnder5 As SqlDataAdapter = New SqlDataAdapter(SqlPass5, Obj.Connection())
                            '        Dr5.Close()

                            '        Dim objDS5 As New DataSet
                            '        daUnder5.Fill(objDS5, "dtUnder5")

                            '        Dim ID6 As String
                            '        For Each rowUnder5 In objDS5.Tables("dtUnder5").Rows

                            '            nodeUnder5 = New TreeNode
                            '            nodeUnder5.Text = rowUnder5("EMPNAME") + " " + ":" + " " + rowUnder5("EMP_CODE")
                            '            ID6 = rowUnder5("EMP_CODE")
                            '            nodeUnder4.ChildNodes.Add(nodeUnder5)
                            '            '----------------------------------------------------Level 7--------------------------------
                            '            Dim SqlPass6 As String = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE)  AND  FLAG='1H' AND STATUS IS NULL AND ACTIVE='Y' AND Resp_Emp='" & ID6 & " ' AND a.Company_Code='" & Session("Companycode") & "'  "
                            '            'Dim SqlPass2 = "SELECT  DISTINCT EMP_CODE,EMPNAME FROM JCT_EMP_HOD A, JCT_EMPMAST_BASE B  WHERE(A.EMP_CODE = B.EMPCODE) AND DEPTCODE='ACT' AND  FLAG='1H' AND STATUS IS NULL AND Resp_Emp='" & ID2 & " '  "
                            '            Dim Dr6 As SqlDataReader = Obj.FetchReader(SqlPass6)
                            '            Dim daUnder6 As SqlDataAdapter = New SqlDataAdapter(SqlPass6, Obj.Connection())
                            '            Dr6.Close()

                            '            Dim objDS6 As New DataSet
                            '            daUnder6.Fill(objDS6, "dtUnder6")

                            '            Dim ID7 As String
                            '            For Each rowUnder6 In objDS6.Tables("dtUnder6").Rows

                            '                nodeUnder6 = New TreeNode
                            '                nodeUnder6.Text = rowUnder6("EMPNAME") + " " + ":" + " " + rowUnder6("EMP_CODE")
                            '                ID7 = rowUnder6("EMP_CODE")
                            '                nodeUnder5.ChildNodes.Add(nodeUnder6)
                            '            Next
                            '            daUnder6.Dispose()
                            '            '-------------------------------------------------------------------------------------------
                            '        Next
                            '        daUnder5.Dispose()
                            '        '-------------------------------------------------------------------------------------------
                            '    Next
                            '    daUnder4.Dispose()
                            '    '-------------------------------------------------------------------------------------------
                        Next
                        daUnder3.Dispose()
                        '---------------------------------------------------------

                    Next
                    daUnder2.Dispose()
                Next

                daUnder.Dispose()

                'objDS.Dispose()

                'daHod.Dispose()
            Next
            'clean up
            objDS.Dispose()

            daHod.Dispose()

            Obj.ConClose()

        End If

    End Sub
    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged
        Try
            If LCase(Session("Companycode")) = "jct00ltd" Then 'Session("Location") = "JCT00LTD" Then
                'SqlPass = "SELECT Top 1 CardNo,EmpName,Desg,deptcode,Mr_Mrs FROM  JCTDEV..JCT_EmpMast_Base where EmpCode='" & Right(Trim(TreeView1.SelectedNode.Text), 7) & "' "
                SqlPass = "SELECT TOP 1 a.CardNo AS CardNo , a.EmployeeName AS EmpName , b.Desg_Long_Description AS Desg , c.Department_Long_Description AS deptcode , Salutation AS Mr_Mrs FROM    dbo.JCT_payroll_employees_master AS a INNER JOIN dbo.JCT_payroll_designation_master AS b ON a.Designation = b.Designation_code INNER JOIN dbo.JCT_payroll_department_master AS c ON a.Department = c.Department_code WHERE   a.NewEmployeeCode = '" & Right(Trim(TreeView1.SelectedNode.Text), 10) & "'  AND b.STATUS = 'A' AND a.STATUS = 'A' AND a.Active = 'Y' AND a.STATUS = 'A'"

            Else
                SqlPass = "SELECT Top 1 CardNo,EmpName,Desg,deptcode,Mr_Mrs FROM  JCTDEV..JCT_EmpMast_Base where EmpCode='" & RTrim(LTrim(Right(Trim(Replace(TreeView1.SelectedNode.Text, ":", "")), 6))) & "' "
            End If
            Dim Dr11 As SqlDataReader = Obj.FetchReader(SqlPass)
            If Dr11.HasRows = True Then
                While Dr11.Read()
                    Image1.ImageUrl = "..\EmployeePortal\EmpImages\" & Trim(Dr11.Item("CardNo")) & ".jpg"
                    Label1.Text = Dr11.Item("Mr_Mrs") + " " + Dr11.Item("EmpName")
                    Label2.Text = Dr11.Item("Desg")
                    Dept = Dr11.Item("Deptcode")
                    Label3.Text = Dept
                End While

            End If
            Dr11.Close()
        Finally
            Obj.ConClose()
        End Try

        'Try
        '    SqlPass1 = "SELECT DeptNAME,DEPTCODE FROM  JCTDEV..Deptmast where Deptcode='" & Dept & "' "
        '    Dim Dr12 As SqlDataReader = Obj.FetchReader(SqlPass1)
        '    If Dr12.HasRows = True Then
        '        While Dr12.Read()
        '            Label3.Text = Dr12.Item(0)
        '        End While

        '    End If
        '    Dr12.Close()
        'Finally
        '    Obj.ConClose()
        'End Try


    End Sub
End Class
