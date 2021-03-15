Imports System.Data.SqlClient
Imports system.Data
Partial Class survey_results
    Inherits System.Web.UI.Page
    Dim db As Connection = New Connection
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim emp_code As String
    Dim dept_no As String
    Dim comp_code As String = "JCT00LTD"
    Dim empcode, qry As String
    Dim check, i, n, Survey_number As Integer
    Public obj As New HelpDeskClass
    Dim dept As String
    Dim cmnt As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack = True Then


            RadioButtonList1.Items(2).Selected = True
            BindDataBoth()

            DropDownList1.Items.Add("All")
            sql = "select distinct rtrim(ltrim(Dept_code)) + ' -' + rtrim(ltrim(Deptname)) from jct_emp_survey_master a,deptmast b where a.dept_code=b.deptcode"

            cmd = New SqlCommand(sql, db.Connection())
            db.ConOpen()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else

                        DropDownList1.Items.Add(dr(0))
                    End If
                End While

            End If

            dr.Close()
            db.ConClose()

        End If

        If Page.IsPostBack Then
            If RadioButtonList1.Items(0).Selected = True Then
                If DropDownList1.SelectedValue = "All" Then
                    BindDataIntALL()
                Else
                    BindDataInt()
                End If
            ElseIf RadioButtonList1.Items(1).Selected = True Then
                If DropDownList1.SelectedValue = "All" Then
                    BindDataExtALL()
                Else

                    BindDataExt()
                End If
            ElseIf RadioButtonList1.Items(2).Selected = True Then
                BindDataBoth()
            End If
        End If


    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged

    End Sub
    Public Sub BindDataBoth()
        'Dim SqlPass = " Select distinct subject from jctdev..jct_emp_survey_master a where  Confidential_flag='N' union select subject from jct_emp_survey_master a, jct_empmast_base b where a.dept_code= b.deptcode and b.empcode='" & Session("empcode") & "'"
        Dim SqlPass = "Select distinct subject,Survey_no,flag from jctdev..jct_emp_survey_master a where  Confidential_flag='N' and Auth_Flag='A'  union select subject,Survey_no,flag from jct_emp_survey_master a, jct_empmast_base b where a.dept_code= b.deptcode and b.empcode='" & Session("empcode") & "' and Auth_Flag='A'"

        cmd = New SqlCommand(SqlPass, db.Connection())
        db.ConOpen()
        dr = cmd.ExecuteReader
        'department='" & Mid(DropDownList1.SelectedValue, 1, 4) & "' and
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    
                    Dim hyper As New HyperLink
                    hyper.Text = dr.Item(0) + "<BR>"
                    Survey_number = dr.Item("Survey_no")
                    If dr(2) = "R" Then
                        hyper.NavigateUrl = "Surveyresult.ASPX?Survey_num=" & Survey_number & ""
                        'hyper.NavigateUrl = "surveyresult.ASPX?survey=" & Request.QueryString.Get("Survey_num") & "&Qno=" & dr(1)
                    Else
                        'hyper.NavigateUrl = "Surveychart.ASPX?survey=" & Request.QueryString.Get("Survey_num") & "&Qno=" & dr(1)
                        hyper.NavigateUrl = "Surveychart.ASPX?Survey_num=" & Survey_number & ""
                        'hyper.NavigateUrl = "surveyresult.ASPX?"
                    End If

                    'hyper.NavigateUrl = "Nevg_Survey_Result.aspx?Survey_num= " & Survey_number & ""
                    ' hyper.NavigateUrl = "NewsDetail.aspx?path=News\" & Dept & "\Ext\" & formname & Extension
                    Panel1.Controls.Add(hyper)
                    'Downloadfile.aspx?filepth=e:\empgateway\Leave\" & formname & ext
                End While
                dr.Close()
            Else
                Response.Write("<script>alert('VALUE IS NOT PRESENT !!'  )</script>")

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            db.ConClose()
        End Try

    End Sub
    Public Sub BindDataInt()
        'If DropDownList1.SelectedValue = "All" Then
        '    BindDataBoth()
        'End If
        Dim SqlPass = " select subject,Survey_no,flag from jct_emp_survey_master a, jct_empmast_base b where a.dept_code= b.deptcode and b.empcode='" & Session("empcode") & "' and a.dept_code='" & Mid(DropDownList1.SelectedValue, 1, 4) & " '  and  Confidential_flag='Y' and Auth_Flag='A'  "
        cmd = New SqlCommand(SqlPass, db.Connection())
        db.ConOpen()
        dr = cmd.ExecuteReader
        'department='" & Mid(DropDownList1.SelectedValue, 1, 4) & "' and
        Try
            If dr.HasRows = True Then
                While dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else

                        Dim hyper As New HyperLink
                        hyper.Text = dr.Item(0) + "<BR>"

                        Survey_number = dr.Item("Survey_no")
                        If dr(2) = "R" Then

                            'hyper.NavigateUrl = "surveyresult.ASPX?survey=" & dr(1) & "&Qno=" & dr(1)
                            hyper.NavigateUrl = "surveyresult.ASPX?Survey_num= " & Survey_number & ""
                        Else
                            'hyper.NavigateUrl = "Surveychart.ASPX?survey=" & Request.QueryString.Get("Survey_num") & "&Qno=" & dr(1)
                            hyper.NavigateUrl = "Surveychart.ASPX?Survey_num= " & Survey_number & ""
                            'hyper.NavigateUrl = "surveyresult.ASPX?"
                        End If

                        'hyper.NavigateUrl = "Nevg_Survey_Result.aspx?Survey_num= " & Survey_number & ""
                        ' hyper.NavigateUrl = "NewsDetail.aspx?path=News\" & Dept & "\Ext\" & formname & Extension
                        Panel1.Controls.Add(hyper)
                    End If    'Downloadfile.aspx?filepth=e:\empgateway\Leave\" & formname & ext
                End While
                dr.Close()
            Else
                Response.Write("<script>alert('VALUE IS NOT PRESENT !!'  )</script>")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            db.ConClose()
        End Try

    End Sub
    Public Sub BindDataExt()
        Dim SqlPass = " select subject,survey_no,flag from jct_emp_survey_master a, jct_empmast_base b where a.dept_code= b.deptcode and b.empcode='" & Session("empcode") & "' and a.dept_code='" & Mid(DropDownList1.SelectedValue, 1, 4) & " ' and  Confidential_flag='N' AND Auth_Flag='A' "
        cmd = New SqlCommand(SqlPass, db.Connection())
        db.ConOpen()
        dr = cmd.ExecuteReader
        'department='" & Mid(DropDownList1.SelectedValue, 1, 4) & "' and
        Try
            If dr.HasRows = True Then
                While dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else

                        Dim hyper As New HyperLink
                        hyper.Text = dr.Item(0) + "<BR>"

                        Survey_number = dr.Item("Survey_no")
                        If dr(2) = "R" Then
                            hyper.NavigateUrl = "surveyresult.ASPX?Survey_num= " & Survey_number & ""
                            'hyper.NavigateUrl = "surveyresult.ASPX?survey=" & Request.QueryString.Get("Survey_num") & "&Qno=" & dr(1)
                        Else
                            hyper.NavigateUrl = "Surveychart.ASPX?Survey_num= " & Survey_number & ""
                            'hyper.NavigateUrl = "Surveychart.ASPX?survey=" & Request.QueryString.Get("Survey_num") & "&Qno=" & dr(1)
                        End If

                        'hyper.NavigateUrl = "Nevg_Survey_Result.aspx?Survey_num= " & Survey_number & ""
                        ' hyper.NavigateUrl = "NewsDetail.aspx?path=News\" & Dept & "\Ext\" & formname & Extension
                        Panel1.Controls.Add(hyper)

                    End If 'Downloadfile.aspx?filepth=e:\empgateway\Leave\" & formname & ext
                End While
                dr.Close()
            Else
                Response.Write("<script>alert('VALUE IS NOT PRESENT !!'  )</script>")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            db.ConClose()
        End Try
    End Sub
    Public Sub BindDataIntALL()
        'If DropDownList1.SelectedValue = "All" Then
        '    BindDataBoth()
        'End If
        Dim SqlPass = " select subject,Survey_no,flag from jct_emp_survey_master a, jct_empmast_base b where a.dept_code= b.deptcode and b.empcode='" & Session("empcode") & "' and  Confidential_flag='Y' and Auth_Flag='A'  "
        cmd = New SqlCommand(SqlPass, db.Connection())
        db.ConOpen()
        dr = cmd.ExecuteReader
        'department='" & Mid(DropDownList1.SelectedValue, 1, 4) & "' and
        Try
            If dr.HasRows = True Then
                While dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else

                        Dim hyper As New HyperLink
                        hyper.Text = dr.Item(0) + "<BR>"

                        Survey_number = dr.Item("Survey_no")
                        If dr(2) = "R" Then

                            'hyper.NavigateUrl = "surveyresult.ASPX?survey=" & dr(1) & "&Qno=" & dr(1)
                            hyper.NavigateUrl = "surveyresult.ASPX?Survey_num= " & Survey_number & ""
                        Else
                            'hyper.NavigateUrl = "Surveychart.ASPX?survey=" & Request.QueryString.Get("Survey_num") & "&Qno=" & dr(1)
                            hyper.NavigateUrl = "Surveychart.ASPX?Survey_num= " & Survey_number & ""
                            'hyper.NavigateUrl = "surveyresult.ASPX?"
                        End If

                        'hyper.NavigateUrl = "Nevg_Survey_Result.aspx?Survey_num= " & Survey_number & ""
                        ' hyper.NavigateUrl = "NewsDetail.aspx?path=News\" & Dept & "\Ext\" & formname & Extension
                        Panel1.Controls.Add(hyper)
                    End If    'Downloadfile.aspx?filepth=e:\empgateway\Leave\" & formname & ext
                End While
                dr.Close()
            Else
                Response.Write("<script>alert('VALUE IS NOT PRESENT !!'  )</script>")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            db.ConClose()
        End Try

    End Sub
    Public Sub BindDataExtALL()
        'If DropDownList1.SelectedValue = "All" Then
        '    BindDataBoth()
        'End If
        Dim SqlPass = " select distinct subject,survey_no,flag from jct_emp_survey_master a, jct_empmast_base b where a.dept_code= b.deptcode and   Confidential_flag='N' AND Auth_Flag='A' "
        cmd = New SqlCommand(SqlPass, db.Connection())
        db.ConOpen()
        dr = cmd.ExecuteReader
        'department='" & Mid(DropDownList1.SelectedValue, 1, 4) & "' and
        Try
            If dr.HasRows = True Then
                While dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else

                        Dim hyper As New HyperLink
                        hyper.Text = dr.Item(0) + "<BR>"

                        Survey_number = dr.Item("Survey_no")
                        If dr(2) = "R" Then

                            'hyper.NavigateUrl = "surveyresult.ASPX?survey=" & dr(1) & "&Qno=" & dr(1)
                            hyper.NavigateUrl = "surveyresult.ASPX?Survey_num= " & Survey_number & ""
                        Else
                            'hyper.NavigateUrl = "Surveychart.ASPX?survey=" & Request.QueryString.Get("Survey_num") & "&Qno=" & dr(1)
                            hyper.NavigateUrl = "Surveychart.ASPX?Survey_num= " & Survey_number & ""
                            'hyper.NavigateUrl = "surveyresult.ASPX?"
                        End If

                        'hyper.NavigateUrl = "Nevg_Survey_Result.aspx?Survey_num= " & Survey_number & ""
                        ' hyper.NavigateUrl = "NewsDetail.aspx?path=News\" & Dept & "\Ext\" & formname & Extension
                        Panel1.Controls.Add(hyper)
                    End If    'Downloadfile.aspx?filepth=e:\empgateway\Leave\" & formname & ext
                End While
                dr.Close()
            Else
                Response.Write("<script>alert('VALUE IS NOT PRESENT !!'  )</script>")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            db.ConClose()
        End Try

    End Sub
End Class
