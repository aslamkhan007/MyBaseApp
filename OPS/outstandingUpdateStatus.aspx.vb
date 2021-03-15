Imports System.Data
Imports System.Data.SqlClient
Partial Class OutstandingUpdateStatus
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim SqlPass, Qry, Cust As String
    Dim ObjFun As Functions = New Functions
    Public AutoStr As String
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim AId As Integer, I As Integer, Tot As String
    Dim Fun As Functions

    'Public Sub BindData()

    '    If Len(Trim(TxtCustomer.Text)) > 0 Then
    '        Cust = Trim(Mid(TxtCustomer.Text, 1, TxtCustomer.Text.IndexOf("~")))
    '    Else
    '        Cust = ""
    '    End If


    '    If rblSelection.Text = "Pack Stock" Then 'And Trim(txtRemarks.Text) = "" 

    '        SqlPass = "SELECT  ISNULL(Status,'') AS Status ,item_group_no AS ItemGroupNo , stock_no AS StockNo , variant_no AS Variant ,  lot_no AS LotNo , CONVERT(NUMERIC(10,2),qty_recd) AS Qty ,  CONVERT(VARCHAR,recd_date,103) AS PackDate ,  wh_no AS WhNo , " & _
    '                     " CASE WHEN order_no = 'sample' THEN 'SAMPLE'   WHEN order_no = '' THEN 'WITHOUT ORDER'   WHEN LEFT(order_no, 3) = 'REJ' THEN 'WRONG ORDER'  ELSE order_no  END AS OrderNo ," & _
    '                     " CASE WHEN order_no = 'sample' THEN 'SAMPLE'       WHEN order_no = '' THEN 'WITHOUT ORDER'    WHEN LEFT(order_no, 3) = 'REJ' THEN 'WRONG ORDER' ELSE CustomerName END AS CustomerName , " & _
    '                    " Shade , ItemDescription , CASE WHEN order_no = 'sample' THEN 'SAMPLE'    WHEN order_no = '' THEN 'WITHOUT ORDER'    WHEN LEFT(order_no, 3) = 'REJ' THEN 'WRONG ORDER'   WHEN wh_no='g-99' THEN 'SUNIL JOSHI'  ELSE TeamHead  END AS TeamHead " & _
    '                    " From JCT_Pack_Stock_UptoDate_MIS_OPS" & _
    '                    " WHERE   ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )         AND ( CustomerName =   '" & Cust & "'  OR   '" & Cust & "' = ''   )    AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )  " & _
    '                    " AND LOT_NO NOT IN ( SELECT LOT_NO FROM JCT_Pack_Stock_UptoDate_MIS_Status)"

    '    ElseIf rblSelection.Text = "Comments" Then 'And Trim(txtRemarks.Text) <> ""

    '        SqlPass = "SELECT  ISNULL(Status,'') AS Status ,item_group_no AS ItemGroupNo , stock_no AS StockNo , variant_no AS Variant ,  S.lot_no AS LotNo , CONVERT(NUMERIC(10,2),qty_recd) AS Qty ,  CONVERT(VARCHAR,recd_date,103) AS PackDate ,  wh_no AS WhNo , " & _
    '                    " CASE WHEN order_no = 'sample' THEN 'SAMPLE'   WHEN order_no = '' THEN 'WITHOUT ORDER'   WHEN LEFT(order_no, 3) = 'REJ' THEN 'WRONG ORDER'  ELSE order_no  END AS OrderNo ," & _
    '                    " CASE WHEN order_no = 'sample' THEN 'SAMPLE'       WHEN order_no = '' THEN 'WITHOUT ORDER'    WHEN LEFT(order_no, 3) = 'REJ' THEN 'WRONG ORDER' ELSE CustomerName END AS CustomerName , " & _
    '                   " Shade , ItemDescription , CASE WHEN order_no = 'sample' THEN 'SAMPLE'    WHEN order_no = '' THEN 'WITHOUT ORDER'    WHEN LEFT(order_no, 3) = 'REJ' THEN 'WRONG ORDER'   WHEN wh_no='g-99' THEN 'SUNIL JOSHI'  ELSE TeamHead  END AS TeamHead " & _
    '                   " From JCT_Pack_Stock_UptoDate_MIS_Status S  JOIN ( SELECT   lot_no , MAX(UpdateTime) AS UpdateTime       FROM     JCT_Pack_Stock_UptoDate_MIS_Status     GROUP BY lot_no   ) AS SS ON S.lot_no = SS.lot_no    AND S.UpdateTime = SS.UpdateTime " & _
    '                   " WHERE  ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )    AND ( ISNULL(Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = 'ALL'   )    AND ( CustomerName =   '" & Cust & "'  OR   '" & Cust & "' = ''   )    AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )  "

    '    End If


    '    Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
    '    Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

    '    Try
    '        If Dr.HasRows = True Then
    '            Dr.Close()
    '            Dim ds As DataSet = New DataSet()
    '            ds.Clear()
    '            Da.Fill(ds)
    '            GridView1.DataSource = ds
    '            GridView1.DataBind()
    '            Dr.Close()
    '        Else
    '            GridView1.DataSource = Nothing
    '            GridView1.DataBind()
    '            Dr.Close()
    '        End If


    '    Catch ex As Exception

    '    Finally
    '        Obj.ConClose()
    '    End Try


    'End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'If (Session("empcode").ToString <> "") Then
        '    'empcode = Session("empcode")
        'Else
        '    Response.Redirect("~/login.aspx")
        'End If
        'If Not IsPostBack Then
        '    BindData()
        'End If




    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        'Dim remarks As DropDownList
        'Dim atLeastOneRowDeleted As Boolean = False
        'Dim i As Long = 1
        'For Each row As GridViewRow In GridView1.Rows

        '    Dim cb As CheckBox = row.FindControl("CheckBox1")
        '    If cb IsNot Nothing AndAlso cb.Checked Then
        '        atLeastOneRowDeleted = True

        '        Dim ID As String = Trim(Convert.ToString(GridView1.Rows(row.RowIndex).Cells(5).Text))

        '        If i = 1 Then
        '            AutoStr += "'" & ID & "'"
        '        Else
        '            AutoStr += "," & "'" & ID & "'"
        '        End If


        '        i = i + 1
        '    End If
        'Next
        'If AutoStr <> "" Then


        '    If rblSelection.Text = "Pack Stock" And Trim(txtRemarks.Text) = "" Then
        '        SqlPass = " INSERT JCT_Pack_Stock_UptoDate_MIS_Status   SELECT item_group_no ,	stock_no ,	variant_no ,	lot_no ,	qty_recd ,	recd_date ,	sdate ,	edate ,	wh_no ,	order_no ,	rate ,	Currency ,	UOM ,	SalePerson ,	CustomerCode ,	CustomerName ,	Shade ,	ItemDescription ,	DnvCostMkt ,	DnvCostCst ,	Warp ,	Weft ,	Reed ,	Picks ,	GSM ,	TeamCode ,	TeamHead ,	Status ,	StatusDate ,	IncompletePacking ,	PartiallyPacking ,	PendingAuthorization ,	 UpdateTime ,	OrderSrlNo ,	OrderQty ,	Flag,TotalPacking,ReadyToDispatch,StatusBackDate,DispatchDate,IP_OUT_DATE,PP_OUT_DATE,PA_OUT_DATE,RTD_OUT_DATE,CLOSEMONTH FROM   JCT_Pack_Stock_UptoDate_MIS_OPS  WHERE   lot_no IN (" & AutoStr & " ) "

        '        Obj.FetchReader(SqlPass)
        '        Obj.ConClose()

        '        SqlPass = "UPDATE   JCT_Pack_Stock_UptoDate_MIS_Status SET UpdateTime=GETDATE(), StatusDate='" & txtDate.Text & "' , Status=  '" & txtRemarksToUpdate.Text & "'  WHERE   lot_no IN (" & AutoStr & " )      "
        '        Obj.FetchReader(SqlPass)
        '        Obj.ConClose()
        '        BindData()

        '    ElseIf rblSelection.Text = "Comments" And Trim(txtRemarks.Text) <> "" Then


        '        If txtRemarksToUpdate.Text <> "READY FOR DESPATCH" Then

        '            SqlPass = "UPDATE   JCT_Pack_Stock_UptoDate_MIS_Status SET   StatusBackDate='" & txtDate.Text & "'    WHERE   lot_no IN (" & AutoStr & " )     AND UpdateTime IN ( SELECT  MAX(UpdateTime) FROM   JCT_Pack_Stock_UptoDate_MIS_Status  WHERE   lot_no IN (" & AutoStr & " ) ) "
        '            Obj.FetchReader(SqlPass)
        '            Obj.ConClose()
        '            BindData()

        '        End If

        '        SqlPass = " INSERT JCT_Pack_Stock_UptoDate_MIS_Status  SELECT  item_group_no ,	stock_no ,	variant_no ,	lot_no ,	qty_recd ,	recd_date ,	sdate ,	edate ,	wh_no ,	order_no ,	rate ,	Currency ,	UOM ,	SalePerson ,	CustomerCode ,	CustomerName ,	Shade ,	ItemDescription ,	DnvCostMkt ,	DnvCostCst ,	Warp ,	Weft ,	Reed ,	Picks ,	GSM ,	TeamCode ,	TeamHead ,	Status ,	StatusDate ,	IncompletePacking ,	PartiallyPacking ,	PendingAuthorization ,	  GETDATE() ,	OrderSrlNo ,	OrderQty ,	Flag,TotalPacking,ReadyToDispatch,NULL,DispatchDate,IP_OUT_DATE,PP_OUT_DATE,PA_OUT_DATE,RTD_OUT_DATE,CLOSEMONTH FROM   JCT_Pack_Stock_UptoDate_MIS_Status  WHERE   lot_no IN (" & AutoStr & " )   " & _
        '                  " AND UpdateTime IN ( SELECT  MAX(UpdateTime) FROM   JCT_Pack_Stock_UptoDate_MIS_Status  WHERE   lot_no IN (" & AutoStr & " ) ) "
        '        Obj.FetchReader(SqlPass)
        '        Obj.ConClose()
        '        BindData()


        '        SqlPass = "UPDATE   JCT_Pack_Stock_UptoDate_MIS_Status SET UpdateTime=GETDATE(), StatusDate='" & txtDate.Text & "' , Status=  '" & txtRemarksToUpdate.Text & "'  WHERE   lot_no IN (" & AutoStr & " )     AND UpdateTime IN ( SELECT  MAX(UpdateTime) FROM   JCT_Pack_Stock_UptoDate_MIS_Status  WHERE   lot_no IN (" & AutoStr & " ) ) "
        '        Obj.FetchReader(SqlPass)
        '        Obj.ConClose()
        '        BindData()
        '    End If
        'End If
    End Sub

    Private Sub ToggleCheckState(ByVal checkState As Boolean)

        'For Each row As GridViewRow In GridView1.Rows
        '    Dim cb As CheckBox = row.FindControl("Checkbox1")
        '    If cb IsNot Nothing Then
        '        cb.Checked = checkState
        '    End If
        'Next

    End Sub

    Protected Sub Check_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Check.Click
        '   ToggleCheckState(True)
    End Sub


    Protected Sub UnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UnCheck.Click
        '  ToggleCheckState(False)
    End Sub

    Protected Sub GridView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        'GridView1.PageIndex = e.NewPageIndex
        'BindData()
    End Sub

    Protected Sub BtnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGet.Click
        ' BindData()
    End Sub






End Class