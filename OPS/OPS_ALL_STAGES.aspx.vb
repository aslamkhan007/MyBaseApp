
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting


Partial Class OPS_OPS_ALL_STAGES
    Inherits System.Web.UI.Page
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim SqlPass As String, SqlChartParm As String
    Dim sum As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

       
        If Not (Page.IsPostBack) Then


            BindDropDownProcess("SELECT DISTINCT UPPER(PROCSTAGE_GROUP) AS PROCSTAGE_GROUP FROM MISERP.SHP.DBO.jct_ops_procstage_group_mapping ORDER BY PROCSTAGE_GROUP")

            BindDropDownCatg("SELECT DISTINCT UPPER(Category) AS Category   FROM    MISERP.SHP.DBO.JCT_OPS_STAGE_WISE_ALL_DATA  ORDER BY Category")

            BindDropDownFinYear("SELECT DISTINCT UPPER(FinYear) AS FinYear   FROM    MISERP.SHP.DBO.JCT_OPS_STAGE_WISE_ALL_DATA  ORDER BY FinYear")

            BindCbUserSelection("SELECT ShortName FROM JCT_OPS_QUERY_SAVE WHERE UserCode= '" & Session("EmpCode") & "'")

            Dim SqlPass As String = "SELECT Query FROM JCT_OPS_QUERY_SAVE WHERE UserCode= '" & Session("EmpCode") & "' AND Defaults='Y' "
            Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)


            If Dr.HasRows Then
                While Dr.Read()
                    SqlPass = Dr.Item(0)
                End While
            End If

            Dr.Close()
            Obj.ConClose()

            SqlPass = Replace(Replace(SqlPass, "@", "'"), "|", ",")


            BindGrid(SqlPass)


            ViewState("Query") = ""



        End If
    End Sub

    Public Sub BindCbUserSelection(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                ddlChoice.DataTextField = ds.Tables(0).Columns("ShortName").ToString()
                ddlChoice.DataValueField = ds.Tables(0).Columns("ShortName").ToString()

                ddlChoice.DataSource = ds
                ddlChoice.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")

        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Sub BindGrid(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                grdStage.DataSource = ds
                grdStage.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Sub BindDropDownProcessStage(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                ddlProcess.DataTextField = ds.Tables(0).Columns("ProcStage").ToString()
                ddlProcess.DataValueField = ds.Tables(0).Columns("ProcStage").ToString()

                ddlProcess.DataSource = ds.Tables(0)
                ddlProcess.DataBind()


                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Sub BindDropDownProcess(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                ddlMapProcess.DataTextField = ds.Tables(0).Columns("PROCSTAGE_GROUP").ToString()
                ddlMapProcess.DataValueField = ds.Tables(0).Columns("PROCSTAGE_GROUP").ToString()

                ddlMapProcess.DataSource = ds.Tables(0)
                ddlMapProcess.DataBind()


                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Sub BindDropDownCatg(ByVal SqlPass As String)


        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                ddlCategory.DataTextField = ds.Tables(0).Columns("Category").ToString()
                ddlCategory.DataValueField = ds.Tables(0).Columns("Category").ToString()

                ddlCategory.DataSource = ds.Tables(0)
                ddlCategory.DataBind()


                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Sub BindDropDownFinYear(ByVal SqlPass As String)


        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                ddlFinYear.DataTextField = ds.Tables(0).Columns("FinYear").ToString()
                ddlFinYear.DataValueField = ds.Tables(0).Columns("FinYear").ToString()



                ddlFinYear.DataSource = ds.Tables(0)
                ddlFinYear.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub ddlProcess_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProcess.SelectedIndexChanged
        Dim OrderColumn As String = ""
        For Each OrderItem As ListItem In ddlProcess.Items

            If OrderItem.Selected = True Then
                OrderColumn = OrderColumn & ",'" & OrderItem.Text & "'"
            End If

        Next

        OrderColumn = Mid(Trim(OrderColumn), 2)

        If Not OrderColumn = "" Then

            If ddlPlant.Text = "ALL" Then
                BindDropDownCatg("SELECT DISTINCT UPPER(Category) AS Category   FROM    MISERP.SHP.DBO.JCT_OPS_STAGE_WISE_ALL_DATA WHERE   ProcStage in (" & OrderColumn & ") AND PLANT IN ( 'COTTON','TAFFETA' ) ORDER BY Category")
            Else
                BindDropDownCatg("SELECT DISTINCT UPPER(Category) AS Category   FROM    MISERP.SHP.DBO.JCT_OPS_STAGE_WISE_ALL_DATA WHERE   ProcStage in (" & OrderColumn & ") AND PLANT IN ( '" & ddlPlant.Text & " ' ) ORDER BY Category")
            End If

        Else
            ddlCategory.Items.Clear()
        End If
    End Sub

    Protected Sub lnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFetch.Click
        Try

       
        grdStage.DataSource = Nothing
        grdStage.DataBind()

            Dim RetColumns As String = "", FinColumn As String = "", OrderColumn As String = "", RetGroup As String = "", RetGroupBy As String = "", RetTotalGroupBy As String = "", RetTotalGroupByTemp As String = "", RetGroupByFirstSelect As String = ""
        For Each Item As ListItem In ddlPeriod.Items

            If ddlPeriod.Items(0).Text = Item.Text Then
                If Item.Selected = True Then
                    RetColumns = Item.Text
                End If
            Else
                If Item.Selected = True Then
                    RetColumns = RetColumns & "," & Item.Text
                End If
            End If

        Next
        RetGroup = RetColumns
            ' RetColumns = InstrCount(Mid(Trim(RetColumns), 1))
            RetColumns = SumCount(Mid(Trim(RetColumns), 1))
        RetGroup = SumCount(Mid(Trim(RetGroup), 1))

        For Each FinItem As ListItem In ddlFinYear.Items

            If ddlPeriod.Items(0).Text = FinItem.Text Then
                If FinItem.Selected = True Then
                    FinColumn = "'" & FinItem.Text & "'"
                End If
            Else
                If FinItem.Selected = True Then
                    FinColumn = FinColumn & "'" & FinItem.Text & "',"
                End If
            End If

        Next

        FinColumn = Mid(Trim(FinColumn), 1, Len(Trim(FinColumn)) - 1)

        For Each OrderItem As ListItem In ddlOrderBy.Items

            If ddlPeriod.Items(0).Text = OrderItem.Text Then
                If OrderItem.Selected = True Then
                    OrderColumn = OrderItem.Text
                End If
            Else
                If OrderItem.Selected = True Then
                    OrderColumn = OrderColumn & "," & OrderItem.Text
                End If
            End If

        Next

        If Trim(OrderColumn) = "" Then
            OrderColumn = "ProcStage"
        Else
            OrderColumn = ColumnOrder(OrderColumn)
        End If

        '-------------------------------------------
        RetTotalGroupBy = RetGroup
        For Each Item As ListItem In ddlGroupBy.Items
            Dim Check As String = ""

            Select Case Item.Text

                Case "PROCESS STAGE"

                    Check = "PROCSTAGE"

                    Exit Select

                Case "FINANCIAL YEAR"

                    Check = "FINYEAR"

                    Exit Select

                Case "CATEGORY"

                    Check = "CATEGORY"

                    Exit Select

                Case "UOM"

                    Check = "UOM"

                    Exit Select
            End Select




            If Not Item.Selected Then

                RetGroup = Replace(RetGroup, Check, "'[ TOTAL ]'")
            Else
                RetGroupBy = RetGroupBy & "," & Check
            End If


            RetTotalGroupBy = Replace(RetTotalGroupBy, Check, "'[~G.TOTAL~]'")

        Next

        If Len(Trim(RetGroupBy)) > 0 Then
            RetGroupBy = (Mid(Trim(RetGroupBy), 2))
            RetGroupBy = " GROUP BY " & RetGroupBy
        Else

            For Each GroupItem As ListItem In ddlGroupBy.Items

                RetGroupBy = RetGroupBy & "," & GroupItem.Text

            Next
            RetGroupBy = ColumnOrder(Mid(Trim(RetGroupBy), 1))
            RetGroupBy = " GROUP BY " & RetGroupBy
        End If
            '-------------------------------------------



            '---------------------------------
            For Each Item As ListItem In ddlOrderBy.Items
                Dim Check As String = ""

                Select Case Item.Text

                    Case "PROCESS STAGE"

                        Check = "PROCSTAGE"

                        Exit Select

                    Case "FINANCIAL YEAR"

                        Check = "FINYEAR"

                        Exit Select

                    Case "CATEGORY"

                        Check = "CATEGORY"

                        Exit Select

                    Case "UOM"

                        Check = "UOM"

                        Exit Select
                End Select


                RetGroupByFirstSelect = RetGroupByFirstSelect & "," & Check
                
            Next

            If Len(Trim(RetGroupBy)) > 0 Then
                RetGroupByFirstSelect = (Mid(Trim(RetGroupByFirstSelect), 2))
                RetGroupByFirstSelect = " GROUP BY " & RetGroupByFirstSelect
            End If
            '---------------------------------




            Dim SqlPass As String = ""

            If ddlPlant.Text = "ALL" Then


                SqlPass = " SELECT   " & RetColumns & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                       "WHERE    ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")    AND    FinYear in (  " & FinColumn & ") " & RetGroupByFirstSelect & "  " & _
                               "UNION SELECT   " & RetGroup & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                       "WHERE      ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")  AND    FinYear in (  " & FinColumn & ")   " & RetGroupBy & " " & _
                          "UNION SELECT   " & RetTotalGroupBy & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                       "WHERE   ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")  AND    FinYear in (  " & FinColumn & ")   " & _
                       "ORDER BY " & OrderColumn & "    "


            Else

                '----------------------------------------------------------------
                SqlPass = " SELECT   " & RetColumns & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                                "WHERE    ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")    AND    FinYear in (  " & FinColumn & ")  AND PLANT IN ('" & ddlPlant.Text & "') " & RetGroupByFirstSelect & " " & _
                                        "UNION SELECT   " & RetGroup & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                                "WHERE      ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")  AND    FinYear in (  " & FinColumn & ")  AND PLANT IN ('" & ddlPlant.Text & "')  " & RetGroupBy & " " & _
                                   "UNION SELECT   " & RetTotalGroupBy & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                                "WHERE   ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")  AND    FinYear in (  " & FinColumn & ") AND PLANT IN ('" & ddlPlant.Text & "')  " & _
                                "ORDER BY " & OrderColumn & "    "
            End If

            ViewState("Query") = ""

            ViewState("Query") = SqlPass

            BindGrid(SqlPass)

            Chart1.DataSource = Nothing
            Chart1.DataBind()


        Catch ex As Exception

            ClientScript.RegisterClientScriptBlock(GetType(Page), "Errors", "<script language = javascript>alert('Please Choose Valid Options !')</script>")
        End Try


    End Sub

    Protected Function ListBindIn(ByVal List As CheckBoxList) As String
        Dim RetColumns As String = ""

        For Each Item As ListItem In List.Items

            If Item.Selected = True Then
                RetColumns = RetColumns & "'" & Item.Text & "',"
            End If

        Next


        RetColumns = Mid(Trim(RetColumns), 1, Len(Trim(RetColumns)) - 1)
        Return RetColumns




    End Function

    Protected Function ListBindTrueFalse(ByVal List As CheckBoxList) As Boolean
        Dim ListCount As Integer = 0

        For Each Item As ListItem In List.Items

            If Item.Selected = True Then
                ListCount += 1
            End If

        Next

        If ListCount > 0 Then
            ListBindTrueFalse = True
        Else
            ListBindTrueFalse = False
        End If


    End Function

    Protected Function ListBind(ByVal List As CheckBoxList) As String

        Dim RetColumns As String = ""
        For Each Item As ListItem In List.Items

            If Item.Selected = True Then
                RetColumns = RetColumns & "," & Item.Text
            End If


        Next

        Return Mid(Trim(RetColumns), 2)
    End Function

    Protected Sub grdStage_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdStage.PageIndexChanging

        grdStage.PageIndex = e.NewPageIndex


        grdStage.DataSource = Nothing
        grdStage.DataBind()

        Dim RetColumns As String = "", FinColumn As String = "", OrderColumn As String = "", RetGroup As String = "", RetGroupBy As String = "", RetTotalGroupBy As String = "", RetTotalGroupByTemp As String = "", RetGroupByFirstSelect As String = ""
        For Each Item As ListItem In ddlPeriod.Items

            If ddlPeriod.Items(0).Text = Item.Text Then
                If Item.Selected = True Then
                    RetColumns = Item.Text
                End If
            Else
                If Item.Selected = True Then
                    RetColumns = RetColumns & "," & Item.Text
                End If
            End If

        Next
        RetGroup = RetColumns
        ' RetColumns = InstrCount(Mid(Trim(RetColumns), 1))
        RetColumns = SumCount(Mid(Trim(RetColumns), 1))
        RetGroup = SumCount(Mid(Trim(RetGroup), 1))

        For Each FinItem As ListItem In ddlFinYear.Items

            If ddlPeriod.Items(0).Text = FinItem.Text Then
                If FinItem.Selected = True Then
                    FinColumn = "'" & FinItem.Text & "'"
                End If
            Else
                If FinItem.Selected = True Then
                    FinColumn = FinColumn & "'" & FinItem.Text & "',"
                End If
            End If

        Next

        FinColumn = Mid(Trim(FinColumn), 1, Len(Trim(FinColumn)) - 1)

        For Each OrderItem As ListItem In ddlOrderBy.Items

            If ddlPeriod.Items(0).Text = OrderItem.Text Then
                If OrderItem.Selected = True Then
                    OrderColumn = OrderItem.Text
                End If
            Else
                If OrderItem.Selected = True Then
                    OrderColumn = OrderColumn & "," & OrderItem.Text
                End If
            End If

        Next

        If Trim(OrderColumn) = "" Then
            OrderColumn = "ProcStage"
        Else
            OrderColumn = ColumnOrder(OrderColumn)
        End If

        '-------------------------------------------
        RetTotalGroupBy = RetGroup
        For Each Item As ListItem In ddlGroupBy.Items
            Dim Check As String = ""

            Select Case Item.Text

                Case "PROCESS STAGE"

                    Check = "PROCSTAGE"

                    Exit Select

                Case "FINANCIAL YEAR"

                    Check = "FINYEAR"

                    Exit Select

                Case "CATEGORY"

                    Check = "CATEGORY"

                    Exit Select

                Case "UOM"

                    Check = "UOM"

                    Exit Select
            End Select




            If Not Item.Selected Then

                RetGroup = Replace(RetGroup, Check, "'[ TOTAL ]'")
            Else
                RetGroupBy = RetGroupBy & "," & Check
            End If


            RetTotalGroupBy = Replace(RetTotalGroupBy, Check, "'[~G.TOTAL~]'")

        Next

        If Len(Trim(RetGroupBy)) > 0 Then
            RetGroupBy = (Mid(Trim(RetGroupBy), 2))
            RetGroupBy = " GROUP BY " & RetGroupBy
        Else

            For Each GroupItem As ListItem In ddlGroupBy.Items

                RetGroupBy = RetGroupBy & "," & GroupItem.Text

            Next
            RetGroupBy = ColumnOrder(Mid(Trim(RetGroupBy), 1))
            RetGroupBy = " GROUP BY " & RetGroupBy
        End If
        '-------------------------------------------



        '---------------------------------
        For Each Item As ListItem In ddlOrderBy.Items
            Dim Check As String = ""

            Select Case Item.Text

                Case "PROCESS STAGE"

                    Check = "PROCSTAGE"

                    Exit Select

                Case "FINANCIAL YEAR"

                    Check = "FINYEAR"

                    Exit Select

                Case "CATEGORY"

                    Check = "CATEGORY"

                    Exit Select

                Case "UOM"

                    Check = "UOM"

                    Exit Select
            End Select


            RetGroupByFirstSelect = RetGroupByFirstSelect & "," & Check

        Next

        If Len(Trim(RetGroupBy)) > 0 Then
            RetGroupByFirstSelect = (Mid(Trim(RetGroupByFirstSelect), 2))
            RetGroupByFirstSelect = " GROUP BY " & RetGroupByFirstSelect
        End If
        '---------------------------------




        Dim SqlPass As String = ""

        If ddlPlant.Text = "ALL" Then


            SqlPass = " SELECT   " & RetColumns & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                   "WHERE    ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")    AND    FinYear in (  " & FinColumn & ") " & RetGroupByFirstSelect & "  " & _
                           "UNION SELECT   " & RetGroup & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                   "WHERE      ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")  AND    FinYear in (  " & FinColumn & ")   " & RetGroupBy & " " & _
                      "UNION SELECT   " & RetTotalGroupBy & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                   "WHERE   ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")  AND    FinYear in (  " & FinColumn & ")   " & _
                   "ORDER BY " & OrderColumn & "    "


        Else

            '----------------------------------------------------------------
            SqlPass = " SELECT   " & RetColumns & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                            "WHERE    ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")    AND    FinYear in (  " & FinColumn & ")  AND PLANT IN ('" & ddlPlant.Text & "') " & RetGroupByFirstSelect & " " & _
                                    "UNION SELECT   " & RetGroup & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                            "WHERE      ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")  AND    FinYear in (  " & FinColumn & ")  AND PLANT IN ('" & ddlPlant.Text & "')  " & RetGroupBy & " " & _
                               "UNION SELECT   " & RetTotalGroupBy & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                            "WHERE   ProcStage IN  (  " & ListBindIn(ddlProcess) & ") AND    Category IN ( " & ListBindIn(ddlCategory) & ")  AND    FinYear in (  " & FinColumn & ") AND PLANT IN ('" & ddlPlant.Text & "')  " & _
                            "ORDER BY " & OrderColumn & "    "
        End If
        ViewState("Query") = ""

        ViewState("Query") = SqlPass

        BindGrid(SqlPass)




    End Sub

    Public Function SumCount(ByVal txtValue As String) As String
        Dim builder As New StringBuilder()

        Dim Columns As String = ""
        Dim split As String() = Trim(txtValue).Split(","c)
        For Each item As String In split
            Select Case item


                Case "PROCESS STAGE"

                    Columns = "PROCSTAGE AS [PROCESS STAGE],"


                    Exit Select

                Case "CATEGORY"

                    Columns = "CATEGORY,"


                    Exit Select

                Case "FINANCIAL YEAR"

                    Columns = "FINYEAR AS [FINANCIAL YEAR],"

                    Exit Select

                Case "UOM"

                    Columns = "UOM,"


                    Exit Select

                Case "JAN"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(JAN,2)))) ,'') AS  JAN,"


                    Exit Select

                Case "FEB"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(FEB,2)))) ,'') AS  FEB,"


                    Exit Select

                Case "MAR"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(MAR,2)))) ,'') AS  MAR,"


                    Exit Select

                Case "APR"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(APR,2)))) ,'') AS  APR,"

                    Exit Select

                Case "MAY"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(MAY,2)))) ,'') AS  MAY,"

                    Exit Select

                Case "JUN"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(JUN,2)))) ,'') AS  JUN,"

                    Exit Select

                Case "JUL"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(JUL,2))) ),'') AS  JUL,"

                    Exit Select

                Case "AUG"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(AUG,2)))) ,'') AS  AUG,"

                    Exit Select

                Case "SEP"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(SEP,2)))) ,'') AS  SEP,"

                    Exit Select

                Case "OCT"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(OCT,2))) ),'') AS  OCT,"

                    Exit Select

                Case "NOV"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(NOV,2))) ),'') AS  NOV,"

                    Exit Select

                Case "DEC"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(DEC,2)))) ,'') AS  DEC,"

                    Exit Select

                Case "Q1"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(Q1,2)))) ,'') AS  Q1,"

                    Exit Select

                Case "Q2"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(Q2,2)))) ,'') AS  Q2,"

                    Exit Select

                Case "Q3"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(Q3,2)))) ,'') AS  Q3,"

                    Exit Select

                Case "Q4"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(Q4,2)))) ,'') AS  Q4,"

                    Exit Select

                Case "YEAR"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(YEARS,2)))) ,'') AS  YEAR,"

                    Exit Select

                Case "TDY"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(NUMERIC,ROUND(TDY,2)))) ,'') AS  TDY,"

                    Exit Select

            End Select
            builder.Append(Columns)

        Next
        Return Mid(Trim(builder.ToString()), 1, Len(builder.ToString()) - 1)
    End Function

    Public Function InstrCount(ByVal txtValue As String) As String
        Dim builder As New StringBuilder()
        Dim Arr As New ArrayList()
        Arr.Clear()
        Dim Columns As String = ""
        Dim split As String() = Trim(txtValue).Split(","c)
        For Each item As String In split
            Select Case item


                Case "PROCESS STAGE"

                    Columns = "PROCSTAGE AS [PROCESS STAGE],"


                    Exit Select

                Case "CATEGORY"

                    Columns = "CATEGORY,"


                    Exit Select

                Case "FINANCIAL YEAR"

                    Columns = "FINYEAR AS [FINANCIAL YEAR],"

                    Exit Select

                Case "UOM"

                    Columns = "UOM,"


                    Exit Select

                Case "JAN"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(JAN,2))) ,'') AS  JAN,"


                    Exit Select

                Case "FEB"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(FEB,2))) ,'') AS  FEB,"


                    Exit Select

                Case "MAR"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(MAR,2))) ,'') AS  MAR,"


                    Exit Select

                Case "APR"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(APR,2))) ,'') AS  APR,"

                    Exit Select

                Case "MAY"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(MAY,2))) ,'') AS  MAY,"

                    Exit Select

                Case "JUN"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(JUN,2))) ,'') AS  JUN,"

                    Exit Select

                Case "JUL"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(JUL,2))) ,'') AS  JUL,"

                    Exit Select

                Case "AUG"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(AUG,2))) ,'') AS  AUG,"

                    Exit Select

                Case "SEP"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(SEP,2))) ,'') AS  SEP,"

                    Exit Select

                Case "OCT"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(OCT,2))) ,'') AS  OCT,"

                    Exit Select

                Case "NOV"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(NOV,2))) ,'') AS  NOV,"

                    Exit Select

                Case "DEC"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(DEC,2))) ,'') AS  DEC,"

                    Exit Select

                Case "Q1"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(Q1,2))) ,'') AS  Q1,"

                    Exit Select

                Case "Q2"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(Q2,2))) ,'') AS  Q2,"

                    Exit Select

                Case "Q3"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(Q3,2))) ,'') AS  Q3,"

                    Exit Select

                Case "Q4"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(Q4,2))) ,'') AS  Q4,"

                    Exit Select

                Case "YEAR"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(YEARS,2))) ,'') AS  YEAR,"

                    Exit Select

                Case "TDY"

                    Columns = "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC,ROUND(TDY,2))) ,'') AS  TDY,"

                    Exit Select

            End Select

            builder.Append(Columns)

        Next
        Return Mid(Trim(builder.ToString()), 1, Len(builder.ToString()) - 1)


    End Function

    Public Function ColumnOrder(ByVal txtValue As String) As String
        Dim builder As New StringBuilder()

        If txtValue.Length > 0 Then



            Dim Columns As String = ""
            Dim split As String() = Trim(txtValue).Split(","c)
            For Each item As String In split





                Select Case item


                    Case "PROCESS STAGE"

                        Columns = "PROCSTAGE,"

                        Exit Select

                    Case "CATEGORY"

                        Columns = "CATEGORY,"

                        Exit Select

                    Case "FINANCIAL YEAR"

                        Columns = "FINYEAR,"

                        Exit Select
                    Case "UOM"

                        Columns = "UOM,"

                        Exit Select

                    Case "JAN"

                        Columns = "JAN,"

                        Exit Select

                    Case "FEB"

                        Columns = "FEB,"

                        Exit Select

                    Case "MAR"

                        Columns = "MAR,"

                        Exit Select

                    Case "APR"

                        Columns = "APR,"

                        Exit Select

                    Case "MAY"

                        Columns = "MAY,"

                        Exit Select

                    Case "JUN"

                        Columns = "JUN,"

                        Exit Select

                    Case "JUL"

                        Columns = "JUL,"

                        Exit Select

                    Case "AUG"

                        Columns = "AUG,"

                        Exit Select

                    Case "SEP"

                        Columns = "SEP,"

                        Exit Select

                    Case "OCT"

                        Columns = "OCT,"

                        Exit Select

                    Case "NOV"

                        Columns = "NOV,"

                        Exit Select

                    Case "DEC"

                        Columns = "DEC,"

                        Exit Select

                    Case "Q1"

                        Columns = "Q1,"

                        Exit Select

                    Case "Q2"

                        Columns = "Q2,"

                        Exit Select

                    Case "Q3"

                        Columns = "Q3,"

                        Exit Select

                    Case "Q4"

                        Columns = "Q4,"

                        Exit Select

                    Case "YEARS"

                        Columns = "YEAR,"

                        Exit Select

                    Case "TDY"

                        Columns = "TDY,"

                        Exit Select

                End Select
                builder.Append(Columns)

            Next

            Return Mid(Trim(builder.ToString()), 1, Len(builder.ToString()) - 1)

        End If

        Return "FinYear,ProcStage,Category"

    End Function

    Protected Sub lnkExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExcel.Click
        GridViewExportUtil.Export("ProcessStage.xls", Me.grdStage)
    End Sub

    Protected Sub lnkSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSave.Click
        Try

      
        Dim SqlPass As String = "SELECT Query FROM JCT_OPS_QUERY_SAVE WHERE UserCode= '" & Session("EmpCode") & "' AND ShortName='" & txtShort.Text & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)


        If Dr.HasRows Then
            ClientScript.RegisterClientScriptBlock(GetType(Page), "asd", "<script language = javascript>alert('Short Name is Already Exists')</script>")
            Exit Sub
        Else
            Dr.Close()
            Obj.ConClose()
        End If





        If ViewState("Query") <> "" Then
            Dim Chk As Char
            If cbDefalut.Checked = True Then
                Chk = "Y"
            Else
                Chk = "N"
            End If

            ViewState("Query") = Replace(Replace(ViewState("Query"), ",", "|"), "'", "@")
            SqlPass = "INSERT JCT_OPS_QUERY_SAVE(UserCode, Query,ShortName,LongName,EntryTime, IPAddress ,Defaults ) " & _
                      " VALUES ('" & Session("EmpCode") & "','" & ViewState("Query") & "'   ,'" & txtShort.Text & "' , '" & txtLong.Text & "' ,GETDATE(), '" & Request.UserHostAddress & "','" & Chk & "')"
            Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection)
            Obj.ConOpen()
            Try
                cmd.ExecuteNonQuery()
                BindCbUserSelection("SELECT ShortName FROM JCT_OPS_QUERY_SAVE WHERE UserCode= '" & Session("EmpCode") & "'")
                ClientScript.RegisterClientScriptBlock(GetType(Page), "asd", "<script language = javascript>alert('Query has been Saved !')</script>")
                ViewState("Query") = ""
            Catch ex As Exception
                ViewState("Query") = ""
            End Try
            End If

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "asd", "<script language = javascript>alert('Please Choose Valid Options !')</script>")
        End Try

    End Sub

    Protected Sub ddlPeriod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPeriod.SelectedIndexChanged

        ddlGroupBy.Items.Clear()
        ddlOrderBy.Items.Clear()

        For Each OrderItem As ListItem In ddlPeriod.Items

            If OrderItem.Selected Then

                If OrderItem.Text = "PROCESS STAGE" Or OrderItem.Text = "CATEGORY" Or OrderItem.Text = "FINANCIAL YEAR" Or OrderItem.Text = "UOM" Then
                    ddlGroupBy.Items.Add(OrderItem.Text)
                    ddlOrderBy.Items.Add(OrderItem.Text)
                End If

            End If

        Next


    End Sub

    Protected Sub lnkSaveQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSaveQuery.Click
        Dim SqlPass As String = "SELECT Query FROM JCT_OPS_QUERY_SAVE WHERE UserCode= '" & Session("EmpCode") & "' AND ShortName='" & ddlChoice.Text & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)


        If Dr.HasRows Then
            While Dr.Read()
                SqlPass = Dr.Item(0)
            End While
        End If

        Dr.Close()
        Obj.ConClose()

        SqlPass = Replace(Replace(SqlPass, "@", "'"), "|", ",")


        BindGrid(SqlPass)

    End Sub

    

   
    Protected Sub lnkChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkChart.Click
        Dim RetColumnsGraph As String = "", FinColumnGraph As String = "", OrderColumnGraph As String = "", RetGroupGraph As String = "", RetGroupByGraph As String = "", RetTotalGroupByGraph As String = "", RetTotalGroupByTempGraph As String = ""





        Try
            For Each Item As ListItem In ddlPeriod.Items

                If ddlPeriod.Items(0).Text = Item.Text Then
                    If Item.Selected = True Then
                        RetColumnsGraph = Item.Text
                    End If
                Else
                    If Item.Selected = True Then
                        RetColumnsGraph = RetColumnsGraph & "," & Item.Text
                    End If
                End If

            Next

            If RetColumnsGraph.Length > 0 Then
                RetColumnsGraph = GraphCount(Mid(Trim(RetColumnsGraph), 1))
            End If

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "Err", "<script language = javascript>alert('" & ex.Message.ToString() & "!!')</script>")
        End Try









        Try
            For Each FinItem As ListItem In ddlFinYear.Items

                If ddlPeriod.Items(0).Text = FinItem.Text Then
                    If FinItem.Selected = True Then
                        FinColumnGraph = "'" & FinItem.Text & "'"
                    End If
                Else
                    If FinItem.Selected = True Then
                        FinColumnGraph = FinColumnGraph & "'" & FinItem.Text & "',"
                    End If
                End If

            Next
            If FinColumnGraph.Length > 0 Then
                FinColumnGraph = Mid(Trim(FinColumnGraph), 1, Len(Trim(FinColumnGraph)) - 1)
            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scrsd", "<script language = javascript>alert('" & ex.Message.ToString() & "!!')</script>")
        End Try


        'For Each OrderItem As ListItem In ddlOrderBy.Items

        '    If ddlPeriod.Items(0).Text = OrderItem.Text Then
        '        If OrderItem.Selected = True Then
        '            OrderColumnGraph = OrderItem.Text
        '        End If
        '    Else
        '        If OrderItem.Selected = True Then
        '            OrderColumnGraph = OrderColumnGraph & "," & OrderItem.Text
        '        End If
        '    End If

        'Next

        'If Trim(OrderColumnGraph) = "" Then
        '    OrderColumnGraph = "ProcStage"
        'Else
        '    OrderColumnGraph = ColumnOrder(OrderColumnGraph)
        'End If


        Try

       

        Dim ProcessBind As String = ListBindIn(ddlProcess)
        Dim CategoryBind As String = ListBindIn(ddlCategory)

            If Len(ProcessBind) > 0 And Len(CategoryBind) > 0 And Len(FinColumnGraph) > 0 And Len(RetColumnsGraph) > 0 Then


                If ddlPlant.Text = "ALL" Then

                    SqlChartParm = " SELECT " & ddlXaxis.Text & ",  " & RetColumnsGraph & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                               "WHERE    ProcStage IN  (  " & ProcessBind & ") AND    Category IN ( " & CategoryBind & ")    AND    FinYear IN (  " & FinColumnGraph & ")   GROUP BY " & ddlXaxis.Text & "  "
                Else
                    SqlChartParm = " SELECT " & ddlXaxis.Text & ",  " & RetColumnsGraph & "      FROM JCT_OPS_STAGE_WISE_ALL_DATA " & _
                               "WHERE    ProcStage IN  (  " & ProcessBind & ") AND    Category IN ( " & CategoryBind & ")    AND    FinYear IN (  " & FinColumnGraph & ")  AND PLANT IN ('" & ddlPlant.Text & "')    GROUP BY " & ddlXaxis.Text & "  "
                End If


                Dim cmd As SqlCommand = New SqlCommand(SqlChartParm, Obj.Connection())
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                Dim ds As New DataSet
                da.Fill(ds, SqlChartParm)
                Dim row As DataRow
                For Each row In ds.Tables(SqlChartParm).Rows
                    Dim series As String = row(ddlXaxis.Text).ToString()
                    Chart1.Series.Add(series)
                    If ddlChartType.Text = "Area" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Area

                    ElseIf ddlChartType.Text = "Bar" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Bar

                    ElseIf ddlChartType.Text = "BoxPlot" Then
                        Chart1.Series(series).ChartType = SeriesChartType.BoxPlot

                    ElseIf ddlChartType.Text = "Bubble" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Bubble

                    ElseIf ddlChartType.Text = "Candlestick" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Candlestick

                    ElseIf ddlChartType.Text = "Column" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Column

                    ElseIf ddlChartType.Text = "Doughnut" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Doughnut

                    ElseIf ddlChartType.Text = "ErrorBar" Then
                        Chart1.Series(series).ChartType = SeriesChartType.ErrorBar

                    ElseIf ddlChartType.Text = "FastLine" Then
                        Chart1.Series(series).ChartType = SeriesChartType.FastLine

                    ElseIf ddlChartType.Text = "Funnel" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Funnel

                    ElseIf ddlChartType.Text = "Kagi" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Kagi

                    ElseIf ddlChartType.Text = "Line" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Line

                    ElseIf ddlChartType.Text = "Pie" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Pie

                    ElseIf ddlChartType.Text = "Point" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Point

                    ElseIf ddlChartType.Text = "PointAndFigure" Then
                        Chart1.Series(series).ChartType = SeriesChartType.PointAndFigure

                    ElseIf ddlChartType.Text = "Polar" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Polar

                    ElseIf ddlChartType.Text = "Pyramid" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Pyramid

                    ElseIf ddlChartType.Text = "RangeBar" Then
                        Chart1.Series(series).ChartType = SeriesChartType.RangeBar

                    ElseIf ddlChartType.Text = "RangeColumn" Then
                        Chart1.Series(series).ChartType = SeriesChartType.RangeColumn

                    ElseIf ddlChartType.Text = "Spline" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Spline

                    ElseIf ddlChartType.Text = "Pyramid" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Pyramid

                    ElseIf ddlChartType.Text = "RangeColumn" Then
                        Chart1.Series(series).ChartType = SeriesChartType.RangeColumn

                    ElseIf ddlChartType.Text = "Spline" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Spline

                    ElseIf ddlChartType.Text = "StackedArea" Then
                        Chart1.Series(series).ChartType = SeriesChartType.StackedArea

                    ElseIf ddlChartType.Text = "StackedBar" Then
                        Chart1.Series(series).ChartType = SeriesChartType.StackedBar

                    ElseIf ddlChartType.Text = "StepLine" Then
                        Chart1.Series(series).ChartType = SeriesChartType.StepLine

                    ElseIf ddlChartType.Text = "Stock" Then
                        Chart1.Series(series).ChartType = SeriesChartType.Stock
                    End If


                    Chart1.Series(series).BorderWidth = 2
                    Chart1.Series(series)("PointWidth") = "0.8"
                    Chart1.Series(series)("DrawingStyle") = "Cylinder"

                    Dim colIndex As Integer

                    For colIndex = 1 To (ds.Tables(SqlChartParm).Columns.Count) - 1

                        Dim columnName As String = ds.Tables(SqlChartParm).Columns(colIndex).ColumnName
                        Dim YVal As Integer = CInt(row(columnName))

                        Chart1.Series(series).ToolTip = "  #VAL million "
                        Chart1.Series(series).IsValueShownAsLabel = True

                        Chart1.Series(series).Points.AddXY(columnName, YVal)

                    Next colIndex

                Next row

            End If

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "ASDFSF", "<script language = javascript>alert('" & ex.Message.ToString() & "!!')</script>")
        End Try





    End Sub

    Public Sub SetAxisInterval(ByVal axis As Axis, ByVal interval As Double)
        axis.Interval = interval
    End Sub

    Public Function GraphCount(ByVal txtValue As String) As String
        Dim builder As New StringBuilder()
        Dim Arr As New ArrayList()
        Arr.Clear()
        Dim Columns As String = ""
        Dim split As String() = Trim(txtValue).Split(","c)
        For Each item As String In split
            Select Case item



                Case "JAN"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(JAN)))/1000000) ,'0') AS  JAN,"


                    Exit Select

                Case "FEB"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(FEB)))/1000000) ,'0') AS  FEB,"


                    Exit Select

                Case "MAR"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(MAR)))/1000000) ,'0') AS  MAR,"


                    Exit Select

                Case "APR"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(APR)))/1000000) ,'0') AS  APR,"

                    Exit Select

                Case "MAY"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(MAY)))/1000000) ,'0') AS  MAY,"

                    Exit Select

                Case "JUN"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(JUN)))/1000000) ,'0') AS  JUN,"

                    Exit Select

                Case "JUL"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(JUL)))/1000000 ),'0') AS  JUL,"

                    Exit Select

                Case "AUG"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(AUG)))/1000000) ,'0') AS  AUG,"

                    Exit Select

                Case "SEP"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(SEP)))/1000000) ,'0') AS  SEP,"

                    Exit Select

                Case "OCT"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(OCT)))/1000000 ),'0') AS  OCT,"

                    Exit Select

                Case "NOV"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(NOV))) /1000000),'0') AS  NOV,"

                    Exit Select

                Case "DEC"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(DEC)))/1000000) ,'0') AS  DEC,"

                    Exit Select

                Case "Q1"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(Q1)))/1000000) ,'0') AS  Q1,"

                    Exit Select

                Case "Q2"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(Q2)))/1000000) ,'0') AS  Q2,"

                    Exit Select

                Case "Q3"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(Q3)))/1000000) ,'0') AS  Q3,"

                    Exit Select

                Case "Q4"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(Q4)))/1000000) ,'0') AS  Q4,"

                    Exit Select

                Case "YEAR"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(YEARS)))/1000000) ,'0') AS  YEAR,"

                    Exit Select

                Case "TDY"

                    Columns = "ISNULL(CONVERT(VARCHAR,SUM(CONVERT(FLOAT,(TDY)))/1000000) ,'0') AS  TDY,"


                    Exit Select

            End Select

            builder.Append(Columns)

        Next
        Return Mid(Trim(builder.ToString()), 1, Len(builder.ToString()) - 1)


    End Function

    Protected Sub ddlMapProcess_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMapProcess.SelectedIndexChanged


        If ListBindTrueFalse(ddlMapProcess) = True Then
            BindDropDownProcessStage("SELECT DISTINCT UPPER(ProcStage) AS ProcStage   FROM    MISERP.SHP.DBO.jct_ops_procstage_group_mapping WHERE PROCSTAGE_GROUP IN (SELECT DISTINCT PROCSTAGE_GROUP FROM MISERP.SHP.DBO.jct_ops_procstage_group_mapping WHERE  PROCSTAGE_GROUP IN (  " & ListBindIn(ddlMapProcess) & ") ) ORDER BY ProcStage")
        End If


    End Sub

   
End Class