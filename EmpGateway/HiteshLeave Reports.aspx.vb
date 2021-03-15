Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class LeaveReports
    Inherits System.Web.UI.Page
    Dim Obj As New Connection
    Dim SqlPass As String, Sqlpass1 As String, Check1 As Boolean = False, Check2 As Boolean = False, Str As String, StrHit As String
    Dim rpt As ReportDocument
    
    Protected Sub bindReport()
        If RadioButtonList1.Items(1).Selected = True Then
            If Nature.Text = "All" Then

                If Status.Text = "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE NOT IN ('W1','W2','W3') AND  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  AND NATURELEAVE NOT IN ('Short Leave','Official Duty','Tour')  AND (PRINTFLAG NOT IN ('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                ElseIf Status.Text <> "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE NOT IN ('W1','W2','W3') AND  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND NATURELEAVE NOT IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "' AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                ElseIf Status.Text = "Pending" And Department.Text <> "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE NOT IN ('W1','W2','W3') AND  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' AND NATURELEAVE NOT IN ('Short Leave','Official Duty','Tour') AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                Else
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE NOT IN ('W1','W2','W3') AND  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' AND NATURELEAVE NOT IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "' AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                End If

            Else

                If Status.Text = "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE NOT IN ('W1','W2','W3') AND  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' And NatureLeave='" & Nature.Text & "'  AND NATURELEAVE  NOT IN ('Short Leave','Official Duty','Tour') AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                ElseIf Status.Text <> "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE NOT IN ('W1','W2','W3') AND MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  And NatureLeave='" & Nature.Text & "' AND NATURELEAVE  NOT IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "' AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                ElseIf Status.Text = "Pending" And Department.Text <> "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE NOT IN ('W1','W2','W3') AND  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' And NatureLeave='" & Nature.Text & "' AND NATURELEAVE  NOT IN ('Short Leave','Official Duty','Tour')AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                Else
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE NOT IN ('W1','W2','W3') AND  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' And NatureLeave='" & Nature.Text & "' AND NATURELEAVE  NOT IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "' AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                End If

            End If
        ElseIf RadioButtonList1.Items(0).Selected = True Then
            If Nature.Text = "All" Then

                If Status.Text = "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE IN ('W1','W2','W3') AND MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  AND NATURELEAVE NOT IN ('Short Leave','Official Duty','Tour') AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                ElseIf Status.Text <> "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE IN ('W1','W2','W3') AND MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND NATURELEAVE NOT IN ('Short Leave','Official Duty','Tour')  and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "'  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                ElseIf Status.Text = "Pending" And Department.Text <> "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE IN ('W1','W2','W3') AND MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' AND NATURELEAVE NOT IN ('Short Leave','Official Duty','Tour')  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                Else
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE IN ('W1','W2','W3') AND  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' AND NATURELEAVE NOT IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "'  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                End If

            Else

                If Status.Text = "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE IN ('W1','W2','W3') AND MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' And NatureLeave='" & Nature.Text & "'  AND NATURELEAVE  NOT IN ('Short Leave','Official Duty','Tour') AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                ElseIf Status.Text <> "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE IN ('W1','W2','W3') AND MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  And NatureLeave='" & Nature.Text & "' AND NATURELEAVE  NOT IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "'  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                ElseIf Status.Text = "Pending" And Department.Text <> "All" Then
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE IN ('W1','W2','W3') AND MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' And NatureLeave='" & Nature.Text & "' AND NATURELEAVE  NOT IN ('Short Leave','Official Duty','Tour')  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                Else
                    SqlPass = "SELECT A.* FROM JCTDEV..JCT_EMPG_LEAVE A, JCTDEV..JCT_EMPMAST_BASE B WHERE A.EMPCODE=B.EMPCODE AND SALARYTYPE IN ('W1','W2','W3') AND MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' And NatureLeave='" & Nature.Text & "' AND NATURELEAVE  NOT IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "'  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY A.CARDNO"
                End If

            End If

        ElseIf RadioButtonList1.Items(2).Selected = True Then
            If Nature.Text = "All" Then

                If Status.Text = "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT * FROM JCTDEV..JCT_EMPG_LEAVE where  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM)) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  AND NATURELEAVE  IN ('Short Leave','Official Duty','Tour')  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY CARDNO"
                ElseIf Status.Text <> "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT * FROM JCTDEV..JCT_EMPG_LEAVE WHERE  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND NATURELEAVE  IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "'    AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY CARDNO"
                ElseIf Status.Text = "Pending" And Department.Text <> "All" Then
                    SqlPass = "SELECT * FROM JCTDEV..JCT_EMPG_LEAVE  WHERE  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' AND NATURELEAVE  IN ('Short Leave','Official Duty','Tour')  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY CARDNO"
                Else
                    SqlPass = "SELECT * FROM JCTDEV..JCT_EMPG_LEAVE WHERE  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' AND NATURELEAVE  IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "'  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY CARDNO"
                End If

            Else

                If Status.Text = "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT  *  FROM JCTDEV..JCT_EMPG_LEAVE where  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' And NatureLeave='" & Nature.Text & "'  AND NATURELEAVE   IN ('Short Leave','Official Duty','Tour') AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY CARDNO"
                ElseIf Status.Text <> "Pending" And Department.Text = "All" Then
                    SqlPass = "SELECT *  FROM JCTDEV..JCT_EMPG_LEAVE  where  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "'  And NatureLeave='" & Nature.Text & "' AND NATURELEAVE   IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "'  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY CARDNO"
                ElseIf Status.Text = "Pending" And Department.Text <> "All" Then
                    SqlPass = "SELECT *  FROM JCTDEV..JCT_EMPG_LEAVE where MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LEAVEFROM)) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' And NatureLeave='" & Nature.Text & "' AND NATURELEAVE   IN ('Short Leave','Official Duty','Tour')  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY CARDNO"
                Else
                    SqlPass = "SELECT *  FROM JCTDEV..JCT_EMPG_LEAVE where  MainFlag=Left('" & Status.Text & "',1)  AND convert(smalldatetime,convert(char(12),LASTTIME )) BETWEEN '" & Format(LeaveFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveTo.SelectedDate, "MM/dd/yyyy") & "' AND Department='" & Department.Text & "' And NatureLeave='" & Nature.Text & "' AND NATURELEAVE  IN ('Short Leave','Official Duty','Tour') and convert(smalldatetime,convert(char(12),LEAVEFROM )) BETWEEN '" & Format(LeaveDateFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(LeaveDateTo.SelectedDate, "MM/dd/yyyy") & "'  AND (PRINTFLAG NOT IN('P') OR PRINTFLAG IS NULL)  ORDER BY CARDNO"
                End If

            End If
        End If

        If Session("deptcode") = "MIS" Then
            SqlPass = Mid(SqlPass, 1, InStr(SqlPass, "PRINTFLAG") - 6) & " " & "ORDER BY a.CARDNO"
        End If


        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Dim ds As DataSet = New DataSet()
        Obj.ConClose()
        ds.Clear()
        Da.Fill(ds)
        '        Dim rpt As ReportDocument = New ReportDocument()
        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("rptLeave.rpt"))
        rpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = rpt
        rpt.SetParameterValue("fromdt", Format(LeaveFrom.SelectedDate, "dd/MM/yyyy"))
        rpt.SetParameterValue("todt", Format(LeaveTo.SelectedDate, "dd/MM/yyyy"))
        rpt.SetParameterValue("CompanyName", Session("Company"))
        rpt.SetParameterValue("Location", Session("Location"))

        CrystalReportViewer1.Height = 600
        CrystalReportViewer1.Width = 726

        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New ExcelFormatOptions
        CrDiskFileDestinationOptions.DiskFileName = "c:\crystalExport.xls"
        CrExportOptions = rpt.ExportOptions
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.Excel
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With

        Obj.ConClose()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Me.Department.SelectedIndex = 4
        End If

        If Page.IsPostBack Then
            rpstatuscheck()
            '    If Status.Text = "Pending" Then

            '        bindReport()
            '    Else
            '        CheckDateTo()
            '        CheckDateFromTo()
            '    End If
            'End If

            'If Status.Text <> "Pending" Then
            '    If Check1 = True And Check2 = True Then

            '        bindReport()
            '    Else
            '        ClientScript.RegisterClientScriptBlock(Me.GetType, "P", "<script language = javascript>alert('Please check date & Date Should be less than today & from is less than To')</script>")
            '    End If
            bindReport()
        End If
    End Sub


    Private Sub Page_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload

        If (Not rpt Is Nothing) Then
            If rpt.IsLoaded = True Then

                rpt.Close()
                rpt.Dispose()

            End If
        End If

    End Sub


    Public Sub CheckDateTo()

        Dim SqlPass = "SELECT  DateDiff(DD,GETDATE(),'" & LeaveTo.SelectedDate & "') as Difference"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Dr.Item(0) < 0 Then
                        Check1 = True
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Public Sub CheckDateFromTo()

        Dim SqlPass = "SELECT  DateDiff(DD,'" & LeaveFrom.SelectedDate & "','" & LeaveTo.SelectedDate & "') as Difference"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Dr.Item(0) > -1 Then
                        Check2 = True
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Print.Click
        rpt.SetDatabaseLogon("itgrp", "power", "misdev", "jctdev")
        rpt.PrintToPrinter(1, True, 0, 0)

        If Session("deptcode") <> "MIS" Then

            Str = Replace(SqlPass, "", "'")
            Str = Mid(SqlPass, InStr(SqlPass, "FROM"), Len(SqlPass))
            Str = Left(Str, InStr(Str, "ORDER BY") - 1)
            SqlPass = "UPDATE JCTDEV..JCT_EMPG_LEAVE SET PRINTFLAG='P'" & Str
            Obj.FetchReader1(SqlPass)

        End If

    End Sub

    Protected Sub Status_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Status.SelectedIndexChanged
        rpstatuscheck()
    End Sub
    Protected Sub rpstatuscheck()
        If Me.Status.Text <> "Pending" Then
            Me.LeaveFrom.Enabled = True
            Me.LeaveTo.Enabled = True
        Else
            Me.LeaveFrom.Enabled = False
            Me.LeaveTo.Enabled = False
        End If
    End Sub

    
     
End Class
