Imports System.Data
Imports System.Data.SqlClient
Partial Class PackingUpdateStatus
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim SqlPass, Qry, Cust As String
    Dim ObjFun As Functions = New Functions
    Public AutoStr As String
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim AId As Integer, I As Integer, Tot As String
    Dim Xl As GridViewExportUtil = New GridViewExportUtil
    Dim Fun As Functions

    Public Sub BindData()

        'If Len(Trim(txtCustomer.Text)) > 0 Then
        '    Cust = Trim(Mid(txtCustomer.Text, 1, txtCustomer.Text.IndexOf("~")))
        'Else
        '    Cust = ""
        'End If


        If rblSelection.Text = "Pack Stock" Then 'And Trim(txtRemarks.Text) = "" 

            If TxtDateFrom.Text = "" Then


                SqlPass = "SELECT  ISNULL(Status,'') AS Status ,item_group_no AS ItemGroupNo , stock_no AS StockNo , variant_no AS Variant ,  lot_no AS LotNo , CONVERT(NUMERIC(10,2),qty_recd) AS Qty ,  CONVERT(VARCHAR,recd_date,103) AS PackDate ," & _
                            " ISNULL(SalePerson, '') AS SalePerson ,ISNULL(order_no, '') AS OrderNo , ISNULL(CustomerName, '') AS CustomerName , ISNULL(Shade, '') AS Shade ,  ISNULL(ItemDescription, '') AS ItemDescription " & _
                            " From JCT_Pack_Stock_UptoDate_MIS_OPS WHERE   ( SalePerson ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND  ( DispatchDate IS NULL    OR ISNULL(DispatchDate,'')='' ) AND " & _
                            "     ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )         AND ( CustomerName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''    )    AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )  " & _
                            " AND  ( Shade='" & txtShade.Text & "' OR '" & txtShade.Text & "' ='' ) AND ( variant_no='" & txtVariant.Text & "' OR '" & txtVariant.Text & "' ='' ) AND LOT_NO NOT IN ( SELECT LOT_NO FROM JCT_Pack_Stock_UptoDate_MIS_Status) ORDER BY recd_date"


                Qry = "SELECT SUM(QTY_RECD) AS QTY_RECD  From JCT_Pack_Stock_UptoDate_MIS_OPS WHERE   ( SalePerson ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND  ( DispatchDate IS NULL    OR ISNULL(DispatchDate,'')='' ) AND " & _
                            "     ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )         AND ( CustomerName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''  )    AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )  " & _
                            " AND  ( Shade='" & txtShade.Text & "' OR '" & txtShade.Text & "' ='' )   AND ( variant_no='" & txtVariant.Text & "' OR '" & txtVariant.Text & "' ='' ) AND LOT_NO NOT IN ( SELECT LOT_NO FROM JCT_Pack_Stock_UptoDate_MIS_Status)"

            Else

                SqlPass = "SELECT  ISNULL(Status,'') AS Status ,item_group_no AS ItemGroupNo , stock_no AS StockNo , variant_no AS Variant ,  lot_no AS LotNo , CONVERT(NUMERIC(10,2),qty_recd) AS Qty ,  CONVERT(VARCHAR,recd_date,103) AS PackDate ," & _
                           " ISNULL(SalePerson, '') AS SalePerson ,ISNULL(order_no, '') AS OrderNo , ISNULL(CustomerName, '') AS CustomerName , ISNULL(Shade, '') AS Shade ,  ISNULL(ItemDescription, '') AS ItemDescription " & _
                           " From JCT_Pack_Stock_UptoDate_MIS_OPS WHERE recd_date BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( SalePerson ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL') AND  ( DispatchDate IS NULL    OR ISNULL(DispatchDate,'')='' ) AND " & _
                           "     ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )         AND ( CustomerName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''  )    AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )  " & _
                           "  AND  ( Shade='" & txtShade.Text & "' OR '" & txtShade.Text & "' ='' ) AND ( variant_no='" & txtVariant.Text & "' OR '" & txtVariant.Text & "' ='' ) AND LOT_NO NOT IN ( SELECT LOT_NO FROM JCT_Pack_Stock_UptoDate_MIS_Status) ORDER BY recd_date"


                Qry = " SELECT SUM(QTY_RECD) AS QTY_RECD FROM  JCT_Pack_Stock_UptoDate_MIS_OPS WHERE recd_date BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( SalePerson ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL') AND  ( DispatchDate IS NULL    OR ISNULL(DispatchDate,'')='' ) AND " & _
                           "     ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )         AND ( CustomerName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''    )    AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )  " & _
                           "  AND  ( Shade='" & txtShade.Text & "' OR '" & txtShade.Text & "' ='' ) AND ( variant_no='" & txtVariant.Text & "' OR '" & txtVariant.Text & "' ='' ) AND LOT_NO NOT IN ( SELECT LOT_NO FROM JCT_Pack_Stock_UptoDate_MIS_Status) "

            End If

        ElseIf rblSelection.Text = "Comments" Then 'And Trim(txtRemarks.Text) <> ""

            If TxtDateFrom.Text = "" Then

                SqlPass = "SELECT  ISNULL(Status,'') AS Status ,item_group_no AS ItemGroupNo , stock_no AS StockNo , variant_no AS Variant ,  S.lot_no AS LotNo , CONVERT(NUMERIC(10,2),qty_recd) AS Qty ,  CONVERT(VARCHAR,recd_date,103) AS PackDate ,  wh_no AS WhNo , " & _
                            " ISNULL(SalePerson, '') AS SalePerson ,ISNULL(order_no, '') AS OrderNo , ISNULL(CustomerName, '') AS CustomerName , ISNULL(Shade, '') AS Shade ,  ISNULL(ItemDescription, '') AS ItemDescription " & _
                           " From JCT_Pack_Stock_UptoDate_MIS_Status S  JOIN ( SELECT   lot_no , MAX(UpdateTime) AS UpdateTime       FROM     JCT_Pack_Stock_UptoDate_MIS_Status     GROUP BY lot_no   ) AS SS ON S.lot_no = SS.lot_no    AND S.UpdateTime = SS.UpdateTime " & _
                           " WHERE     ( Shade='" & txtShade.Text & "' OR '" & txtShade.Text & "' ='' ) AND ( SalePerson ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )    AND ( ISNULL(Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = ''   )    AND ( CustomerName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''   )    AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   ) AND ( variant_no='" & txtVariant.Text & "' OR '" & txtVariant.Text & "' ='' ) AND  ( S.DispatchDate IS NULL    OR ISNULL(S.DispatchDate,'')='' )   ORDER BY recd_date"

                Qry = " SELECT SUM(QTY_RECD) AS QTY_RECD  From JCT_Pack_Stock_UptoDate_MIS_Status S  JOIN ( SELECT   lot_no , MAX(UpdateTime) AS UpdateTime       FROM     JCT_Pack_Stock_UptoDate_MIS_Status     GROUP BY lot_no   ) AS SS ON S.lot_no = SS.lot_no    AND S.UpdateTime = SS.UpdateTime " & _
                           " WHERE     ( Shade='" & txtShade.Text & "' OR '" & txtShade.Text & "' ='' )  AND ( SalePerson ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )    AND ( ISNULL(Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = ''   )    AND ( CustomerName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''    )    AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   ) AND ( variant_no='" & txtVariant.Text & "' OR '" & txtVariant.Text & "' ='' ) AND  ( S.DispatchDate IS NULL    OR ISNULL(S.DispatchDate,'')='' )  "


            Else
                SqlPass = "SELECT  ISNULL(Status,'') AS Status ,item_group_no AS ItemGroupNo , stock_no AS StockNo , variant_no AS Variant ,  S.lot_no AS LotNo , CONVERT(NUMERIC(10,2),qty_recd) AS Qty ,  CONVERT(VARCHAR,recd_date,103) AS PackDate ,  wh_no AS WhNo , " & _
                           " ISNULL(SalePerson, '') AS SalePerson ,ISNULL(order_no, '') AS OrderNo , ISNULL(CustomerName, '') AS CustomerName , ISNULL(Shade, '') AS Shade ,  ISNULL(ItemDescription, '') AS ItemDescription " & _
                          " From JCT_Pack_Stock_UptoDate_MIS_Status S  JOIN ( SELECT   lot_no , MAX(UpdateTime) AS UpdateTime       FROM     JCT_Pack_Stock_UptoDate_MIS_Status     GROUP BY lot_no   ) AS SS ON S.lot_no = SS.lot_no    AND S.UpdateTime = SS.UpdateTime " & _
                          "  WHERE      ( Shade='" & txtShade.Text & "' OR '" & txtShade.Text & "' ='' )  AND ( SalePerson ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND recd_date BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )    AND ( ISNULL(Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = ''   )    AND ( CustomerName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''    )   AND ( variant_no='" & txtVariant.Text & "' OR '" & txtVariant.Text & "' ='' ) AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )  AND  ( S.DispatchDate IS NULL    OR ISNULL(S.DispatchDate,'')='' )   ORDER BY recd_date"

                Qry = "  SELECT SUM(QTY_RECD) AS QTY_RECD From JCT_Pack_Stock_UptoDate_MIS_Status S  JOIN ( SELECT   lot_no , MAX(UpdateTime) AS UpdateTime       FROM     JCT_Pack_Stock_UptoDate_MIS_Status     GROUP BY lot_no   ) AS SS ON S.lot_no = SS.lot_no    AND S.UpdateTime = SS.UpdateTime " & _
                          "  WHERE     ( Shade='" & txtShade.Text & "' OR '" & txtShade.Text & "' ='' )  AND ( SalePerson ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND recd_date BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( item_group_no = '" & Trim(txtItemGroup.Text) & "'      OR '" & Trim(txtItemGroup.Text) & "'  = ''   )    AND ( ISNULL(Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = ''   )    AND ( CustomerName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''   )   AND ( variant_no='" & txtVariant.Text & "' OR '" & txtVariant.Text & "' ='' ) AND ( order_no =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )  AND  ( S.DispatchDate IS NULL    OR ISNULL(S.DispatchDate,'')='' )  "

            End If

        End If


        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                Dr.Close()
            End If


        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try



        Dim Dr1 As SqlDataReader = Obj.FetchReader(Qry)
        Dim Da1 As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr1.HasRows = True Then
                While Dr1.Read
                    txtTotal.Text = Dr1.Item(0)
                End While
                Dr1.Close()

            End If


        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then

            txtRemarksToUpdate_SelectedIndexChanged(sender, e)
            BindData()

        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim remarks As DropDownList
        Dim atLeastOneRowDeleted As Boolean = False
        Dim i As Long = 1
        For Each row As GridViewRow In GridView1.Rows

            Dim cb As CheckBox = row.FindControl("CheckBox1")
            If cb IsNot Nothing AndAlso cb.Checked Then
                atLeastOneRowDeleted = True

                Dim ID As String = Trim(Convert.ToString(GridView1.Rows(row.RowIndex).Cells(5).Text))

                If i = 1 Then
                    AutoStr += "'" & ID & "'"
                Else
                    AutoStr += "," & "'" & ID & "'"
                End If


                i = i + 1
            End If
        Next
        If AutoStr <> "" Then


            If rblSelection.Text = "Pack Stock" And Trim(txtRemarks.Text) = "" Then
                SqlPass = " INSERT JCT_Pack_Stock_UptoDate_MIS_Status   SELECT item_group_no ,	stock_no ,	variant_no ,	lot_no ,	qty_recd ,	recd_date ,	sdate ,	edate ,	wh_no ,	order_no ,	rate ,	Currency ,	UOM ,	SalePerson ,	CustomerCode ,	CustomerName ,	Shade ,	ItemDescription ,	DnvCostMkt ,	DnvCostCst ,	Warp ,	Weft ,	Reed ,	Picks ,	GSM ,	TeamCode ,	TeamHead ,	Status ,	StatusDate ,	IncompletePacking ,	PartiallyPacking ,	PendingAuthorization ,	 UpdateTime ,	OrderSrlNo ,	OrderQty ,	Flag,TotalPacking,ReadyToDispatch,StatusBackDate,DispatchDate,IP_OUT_DATE,PP_OUT_DATE,PA_OUT_DATE,RTD_OUT_DATE,CLOSEMONTH,Remarks FROM   JCT_Pack_Stock_UptoDate_MIS_OPS  WHERE   lot_no IN (" & AutoStr & " ) "

                Obj.FetchReader(SqlPass)
                Obj.ConClose()

                SqlPass = "UPDATE   JCT_Pack_Stock_UptoDate_MIS_Status SET UpdateTime=GETDATE(), StatusDate='" & txtDate.Text & "' , Status=  '" & txtRemarksToUpdate.Text & "' , Remarks='" & TxtComments.Text & "'  WHERE   lot_no IN (" & AutoStr & " )      "
                Obj.FetchReader(SqlPass)
                Obj.ConClose()
                BindData()

            ElseIf rblSelection.Text = "Comments" And Trim(txtRemarks.Text) <> "" Then


                If txtRemarksToUpdate.Text <> "COMPLETE PACKING--READY FOR DISPATCH" Then
                    'READY FOR DESPATCH" Then

                    SqlPass = "UPDATE   JCT_Pack_Stock_UptoDate_MIS_Status SET   StatusBackDate='" & txtDate.Text & "'    WHERE   lot_no IN (" & AutoStr & " )     AND UpdateTime IN ( SELECT  MAX(UpdateTime) FROM   JCT_Pack_Stock_UptoDate_MIS_Status  WHERE   lot_no IN (" & AutoStr & " ) ) "
                    Obj.FetchReader(SqlPass)
                    Obj.ConClose()
                    'BindData()

                End If

                SqlPass = " INSERT JCT_Pack_Stock_UptoDate_MIS_Status  SELECT  item_group_no ,	stock_no ,	variant_no ,	lot_no ,	qty_recd ,	recd_date ,	sdate ,	edate ,	wh_no ,	order_no ,	rate ,	Currency ,	UOM ,	SalePerson ,	CustomerCode ,	CustomerName ,	Shade ,	ItemDescription ,	DnvCostMkt ,	DnvCostCst ,	Warp ,	Weft ,	Reed ,	Picks ,	GSM ,	TeamCode ,	TeamHead ,	Status ,	StatusDate ,	IncompletePacking ,	PartiallyPacking ,	PendingAuthorization ,	  GETDATE() ,	OrderSrlNo ,	OrderQty ,	Flag,TotalPacking,ReadyToDispatch,NULL,DispatchDate,IP_OUT_DATE,PP_OUT_DATE,PA_OUT_DATE,RTD_OUT_DATE,CLOSEMONTH,Remarks FROM   JCT_Pack_Stock_UptoDate_MIS_Status  WHERE   lot_no IN (" & AutoStr & " )   " & _
                          " AND UpdateTime IN ( SELECT  MAX(UpdateTime) FROM   JCT_Pack_Stock_UptoDate_MIS_Status  WHERE   lot_no IN (" & AutoStr & " ) ) "
                Obj.FetchReader(SqlPass)
                Obj.ConClose()
                ' BindData()


                SqlPass = "UPDATE   JCT_Pack_Stock_UptoDate_MIS_Status SET UpdateTime=GETDATE(), StatusDate='" & txtDate.Text & "' , Status=  '" & txtRemarksToUpdate.Text & "'  WHERE   lot_no IN (" & AutoStr & " )     AND UpdateTime IN ( SELECT  MAX(UpdateTime) FROM   JCT_Pack_Stock_UptoDate_MIS_Status  WHERE   lot_no IN (" & AutoStr & " ) ) "
                Obj.FetchReader(SqlPass)
                Obj.ConClose()
                BindData()
            End If
        End If
    End Sub

    Private Sub ToggleCheckState(ByVal checkState As Boolean)

        For Each row As GridViewRow In GridView1.Rows
            Dim cb As CheckBox = row.FindControl("Checkbox1")
            If cb IsNot Nothing Then
                cb.Checked = checkState
            End If
        Next

    End Sub

    Protected Sub Check_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Check.Click
        ToggleCheckState(True)
    End Sub


    Protected Sub UnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UnCheck.Click
        ToggleCheckState(False)
    End Sub

    Protected Sub GridView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        BindData()
    End Sub

    Protected Sub BtnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGet.Click
        BindData()
    End Sub



    Function CreateExcelFile(ByVal dt As DataTable) As Boolean

        Dim bFileCreated As Boolean = False
        Dim sTableStart As String = "<HTML><BODY><TABLE Border=1><TR><TH>Packed Stock UptoDate </TH></TR>"
        Dim sTableEnd As String = "</TABLE></BODY></HTML>"
        Dim sTableData As String = ""
        Dim nRow As Long
        sTableData &= "<TR>"
        For nCol = 0 To dt.Columns.Count - 1
            sTableData &= "<TD><B>" & dt.Columns(nCol).ColumnName & "</B></TD>"
        Next
        sTableData &= "</TR>"
        For nRow = 0 To dt.Rows.Count - 1
            sTableData &= "<TR>"
            For nCol = 0 To dt.Columns.Count - 1
                sTableData &= "<TD>" & dt.Rows(nRow).Item(nCol).ToString & "</TD>"
            Next
            sTableData &= "</TR>"
        Next
        Dim sTable As String = sTableStart & sTableData & sTableEnd
        '  Dim oExcelFile As System.IO.File
        Dim oExcelWrite As System.IO.StreamWriter
        Dim sExcelFile As String = Server.MapPath("DnV_Detail.xls")
        oExcelWrite = IO.File.CreateText(sExcelFile)
        oExcelWrite.WriteLine(sTable)
        oExcelWrite.Close()
        bFileCreated = True
        Return bFileCreated

    End Function


    Protected Sub BtnExcel_Click(sender As Object, e As System.EventArgs) Handles BtnExcel.Click
        GridViewExportUtil.Export("PackedStock.xls", GridView1)
    End Sub

    Protected Sub txtRemarksToUpdate_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles txtRemarksToUpdate.SelectedIndexChanged


        SqlPass = "SELECT  Definitions  FROM MISDEV.JCTDEV.DBO.JCT_OPS_PACKED_STOCK_REASON WHERE UPPER(Catogories) + '--' + UPPER(SubCatogories)='" & txtRemarksToUpdate.Text & "'"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    Label1.Text = Dr.Item(0)
                End While
            End If
            Dr.Close()
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub



    Protected Sub BtnClear_Click(sender As Object, e As System.EventArgs) Handles BtnClear.Click
        TxtDateFrom.Text = ""
        txtDateTo.Text = ""

        txtItemGroup.Text = ""
        txtRemarks.Text = ""
        txtCustomer.Text = ""
        TxtOrder.Text = ""
        txtRemarksToUpdate.Text = ""
        TxtComments.Text = ""
        txtDate.Text = ""
    End Sub

    Protected Sub rblSelection_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblSelection.SelectedIndexChanged
        If rblSelection.Text = "Comments" Then
            txtRemarks.Enabled = True
        Else
            txtRemarks.Enabled = False
        End If
    End Sub


    Public Sub BindDropDownCustomer(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                'ds.Clear()
                Da.Fill(ds)

                txtCustomer.DataTextField = ds.Tables(0).Columns("CustomerName").ToString()
                txtCustomer.DataValueField = ds.Tables(0).Columns("CustomerName").ToString()

                txtCustomer.DataSource = ds.Tables(0)
                txtCustomer.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Public Sub BindDropDownVariant(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                'ds.Clear()
                Da.Fill(ds)

                txtVariant.DataTextField = ds.Tables(0).Columns("variant_no").ToString()
                txtVariant.DataValueField = ds.Tables(0).Columns("variant_no").ToString()

                txtVariant.DataSource = ds.Tables(0)
                txtVariant.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Public Sub BindDropDownShade(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                'ds.Clear()
                Da.Fill(ds)

                txtShade.DataTextField = ds.Tables(0).Columns("Shade").ToString()
                txtShade.DataValueField = ds.Tables(0).Columns("Shade").ToString()

                txtShade.DataSource = ds.Tables(0)
                txtShade.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Protected Sub txtSalePerson_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles txtSalePerson.SelectedIndexChanged

        BindDropDownCustomer("SELECT '' AS CustomerName UNION ALL SELECT DISTINCT CustomerName FROM JCT_Pack_Stock_UptoDate_MIS_OPS WHERE ( SalePerson='" & txtSalePerson.Text & "'  OR '" & txtSalePerson.Text & "' ='ALL') AND recd_date BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "'  AND  ( DispatchDate IS NULL    OR ISNULL(DispatchDate,'')='' ) ")
        BindDropDownVariant("SELECT '' AS variant_no UNION ALL SELECT DISTINCT ISNULL(variant_no,'') AS variant_no FROM JCT_Pack_Stock_UptoDate_MIS_OPS WHERE ( SalePerson='" & txtSalePerson.Text & "'  OR '" & txtSalePerson.Text & "' ='ALL') AND recd_date BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( DispatchDate IS NULL    OR ISNULL(DispatchDate,'')='' ) ")
        BindDropDownShade("SELECT '' AS Shade UNION ALL SELECT DISTINCT ISNULL(Shade,'') AS Shade FROM JCT_Pack_Stock_UptoDate_MIS_OPS WHERE ( SalePerson='" & txtSalePerson.Text & "'  OR '" & txtSalePerson.Text & "' ='ALL') AND recd_date BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( DispatchDate IS NULL    OR ISNULL(DispatchDate,'')='' ) ")

    End Sub

    Protected Sub txtRemarks_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles txtRemarks.SelectedIndexChanged
        If txtRemarks.Text = "COMPLETE PACKING--READY FOR DISPATCH" Then
            btnUpdate.Enabled = False
        Else
            btnUpdate.Enabled = True
        End If

    End Sub
End Class