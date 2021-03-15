Imports System.Data
Imports System.Data.SqlClient
Partial Class InvoiceUpdateStatus
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

        If rblSelection.Text = "Invoice" Then


            If rblPlant.Text = "Cotton" Then

                SqlPass = "SELECT '' AS Status,CustNo ,CustName ,OrderNo ,UPPER(SalePersonName) AS SalePersonName ,invoice_no AS InvoiceNo , CONVERT(VARCHAR, invoice_dt, 106) AS InvoiceDate ,CASE WHEN invoice_net_amt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, invoice_net_amt)) ELSE '' END AS InvoiceAmt ," & _
                            "CASE WHEN GetAmount > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, GetAmount)) ELSE '' END AS TotalAmtRec ,  CASE WHEN OthAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, OthAmt))  ELSE '' END AS BankReceipt ,  CASE WHEN CredAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, CredAmt)) " & _
                            "Else ''END AS CredAmt ,CASE WHEN outstanding_amt > 0  THEN CONVERT(VARCHAR,  CONVERT(NUMERIC, outstanding_amt)) ELSE ''  END AS Outstanding FROM    shp..Combine_Invoice_OPS_Detail WHERE   invoice_no NOT IN ( SELECT  invoice_no  FROM    InvoiceToComments ) AND ISNULL(outstanding_amt, 0) > 0  " & _
                            "AND invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( SalePersonName ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL')  AND ( CustName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''  )    AND ( OrderNo =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )" & _
                            " AND LEFT(invoice_no,1) NOT IN ('N')  ORDER BY invoice_dt ,CustNo "


                Qry = "SELECT SUM( ISNULL(outstanding_amt,0)) FROM    shp..Combine_Invoice_OPS_Detail WHERE   invoice_no NOT IN ( SELECT  invoice_no  FROM    InvoiceToComments ) AND ISNULL(outstanding_amt, 0) > 0  " & _
                           " AND invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( SalePersonName ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL')  AND ( CustName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''  )    AND ( OrderNo =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )" & _
                           " AND LEFT(invoice_no,1) NOT IN ('N')  "



            ElseIf rblPlant.Text = "Tafetta" Then

                SqlPass = "SELECT   ''  AS Status,CustNo ,CustName ,OrderNo ,UPPER(SalePersonName) AS SalePersonName ,invoice_no AS InvoiceNo , CONVERT(VARCHAR, invoice_dt, 106) AS InvoiceDate ,CASE WHEN invoice_net_amt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, invoice_net_amt)) ELSE '' END AS InvoiceAmt ," & _
                                "CASE WHEN GetAmount > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, GetAmount)) ELSE '' END AS TotalAmtRec ,  CASE WHEN OthAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, OthAmt))  ELSE '' END AS BankReceipt ,  CASE WHEN CredAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, CredAmt)) " & _
                                "Else ''END AS CredAmt ,CASE WHEN outstanding_amt > 0  THEN CONVERT(VARCHAR,  CONVERT(NUMERIC, outstanding_amt)) ELSE ''  END AS Outstanding FROM    shp..Combine_Invoice_OPS_Detail WHERE   invoice_no NOT IN ( SELECT  invoice_no  FROM    InvoiceToComments ) AND ISNULL(outstanding_amt, 0) > 0  " & _
                                "AND  invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( SalePersonName ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL')  AND ( CustName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''  )    AND ( OrderNo =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )" & _
                                " AND LEFT(invoice_no,1)  IN ('N')  ORDER BY invoice_dt ,CustNo "


                Qry = "SELECT  SUM( ISNULL(outstanding_amt,0)) AS OutstandingAmount   FROM    shp..Combine_Invoice_OPS_Detail WHERE   invoice_no NOT IN ( SELECT  invoice_no  FROM    InvoiceToComments ) AND ISNULL(outstanding_amt, 0) > 0  " & _
                           " AND invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND  ( SalePersonName ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL')  AND ( CustName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''  )    AND ( OrderNo =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )" & _
                           " AND LEFT(invoice_no,1)  IN ('N') "



            End If




        ElseIf rblSelection.Text = "Comments" Then


            If rblPlant.Text = "Cotton" Then

                SqlPass = "SELECT  ISNULL(Status,'') AS Status ,S.CustNo ,S.CustName ,S.OrderNo ,UPPER(S.SalePersonName) AS SalePersonName ,S.invoice_no AS InvoiceNo , CONVERT(VARCHAR, S.invoice_dt, 106) AS InvoiceDate ,CASE WHEN S.invoice_net_amt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, S.invoice_net_amt)) ELSE '' END AS InvoiceAmt ," & _
                            "CASE WHEN S.GetAmount > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, S.GetAmount)) ELSE '' END AS TotalAmtRec ,  CASE WHEN S.OthAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, S.OthAmt))  ELSE '' END AS BankReceipt ,  CASE WHEN S.CredAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, S.CredAmt)) " & _
                            "Else ''END AS CredAmt ,CASE WHEN S.outstanding_amt > 0  THEN CONVERT(VARCHAR,  CONVERT(NUMERIC, S.outstanding_amt)) ELSE ''  END AS Outstanding FROM InvoiceToComments S  JOIN ( SELECT   invoice_no , MAX(UpdateTime) AS UpdateTime       FROM     InvoiceToComments     GROUP BY invoice_no   ) AS SS ON S.invoice_no = SS.invoice_no    AND S.UpdateTime = SS.UpdateTime " & _
                          "  WHERE   ISNULL(S.StatusBackDate,'') ='' AND     ( S.SalePersonName ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND S.invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "'   AND ( ISNULL(S.Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = ''   )    AND ( S.CustName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''    )   AND ( S.orderno =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )   AND LEFT(S.invoice_no,1)  NOT IN ('N')  ORDER BY S.invoice_dt ,S.CustNo "

                Qry = "SELECT  SUM( ISNULL(outstanding_amt,0)) AS OutstandingAmount FROM InvoiceToComments S  JOIN ( SELECT   invoice_no , MAX(UpdateTime) AS UpdateTime       FROM     InvoiceToComments     GROUP BY invoice_no   ) AS SS ON S.invoice_no = SS.invoice_no    AND S.UpdateTime = SS.UpdateTime " & _
                          "  WHERE    ISNULL(S.StatusBackDate,'') ='' AND  ( S.SalePersonName ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND S.invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "'   AND ( ISNULL(S.Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = ''   )    AND ( S.CustName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''    )   AND (S. orderno =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )   AND LEFT(S.invoice_no,1)  NOT IN ('N')   "

            ElseIf rblPlant.Text = "Tafetta" Then

                SqlPass = "SELECT  ISNULL(Status,'') AS Status ,S.CustNo ,S.CustName ,S.OrderNo ,UPPER(S.SalePersonName) AS SalePersonName ,S.invoice_no AS InvoiceNo , CONVERT(VARCHAR, S.invoice_dt, 106) AS InvoiceDate ,CASE WHEN S.invoice_net_amt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, S.invoice_net_amt)) ELSE '' END AS InvoiceAmt ," & _
                              "CASE WHEN S.GetAmount > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, S.GetAmount)) ELSE '' END AS TotalAmtRec ,  CASE WHEN S.OthAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, S.OthAmt))  ELSE '' END AS BankReceipt ,  CASE WHEN S.CredAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, S.CredAmt)) " & _
                              "Else ''END AS CredAmt ,CASE WHEN S.outstanding_amt > 0  THEN CONVERT(VARCHAR,  CONVERT(NUMERIC, S.outstanding_amt)) ELSE ''  END AS Outstanding FROM InvoiceToComments S  JOIN ( SELECT   invoice_no , MAX(UpdateTime) AS UpdateTime       FROM     InvoiceToComments     GROUP BY invoice_no   ) AS SS ON S.invoice_no = SS.invoice_no    AND S.UpdateTime = SS.UpdateTime " & _
                            "  WHERE   ISNULL(S.StatusBackDate,'') ='' AND   ( SalePersonName ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "'   AND ( ISNULL(Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = ''   )    AND ( CustName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''    )   AND ( orderno =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )   AND LEFT(invoice_no,1)   IN ('N')   ORDER BY S.invoice_dt ,S.CustNo "

                Qry = "SELECT  SUM( ISNULL(outstanding_amt,0)) AS OutstandingAmount FROM InvoiceToComments S  JOIN ( SELECT   invoice_no , MAX(UpdateTime) AS UpdateTime       FROM     InvoiceToComments     GROUP BY invoice_no   ) AS SS ON S.invoice_no = SS.invoice_no    AND S.UpdateTime = SS.UpdateTime " & _
                          "  WHERE    ISNULL(S.StatusBackDate,'') ='' AND  ( SalePersonName ='" & txtSalePerson.Text & "' OR '" & txtSalePerson.Text & "'='ALL' OR '" & txtSalePerson.Text & "'=' ') AND invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "'   AND ( ISNULL(Status,'' ) = '" & Trim(txtRemarks.Text) & "'       OR '" & Trim(txtRemarks.Text) & "' = ''   )    AND ( CustName =   '" & Trim(txtCustomer.Text) & "'         OR   '" & Trim(txtCustomer.Text) & "'        = ''    )   AND ( orderno =   '" & TxtOrder.Text & "'  OR   '" & TxtOrder.Text & "' = ''   )   AND LEFT(invoice_no,1)   IN ('N')    "

            

            End If



        End If




        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())


        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.SelectCommand.CommandTimeout = 0
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
        Dim Da1 As SqlDataAdapter = New SqlDataAdapter(Qry, Obj.Connection())

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


                Dim ID As String = Trim(Convert.ToString(GridView1.Rows(row.RowIndex).Cells(6).Text))
             

            If i = 1 Then
                AutoStr += "'" & ID & "'"
            Else
                AutoStr += "," & "'" & ID & "'"
            End If


            i = i + 1
            End If
        Next
        If AutoStr <> "" Then


            If rblSelection.Text = "Invoice" And Trim(txtRemarks.Text) = "" Then
                SqlPass = " INSERT InvoiceToComments   SELECT CustNo ,CustName ,invoice_no ,invoice_dt , basic_amt ,tax_amt , charge_amt ,discount_amt , frt_amt ,invoice_amt ,invoice_net_amt ,GetAmount ,outstanding_amt ,CredAmt ,OthAmt ,HostId ,Type ,OrderNo ,SalePersonCode , SalePersonName,'',NULL,NULL,'',NULL FROM   SHP..Combine_Invoice_OPS_Detail         WHERE   invoice_no IN (" & AutoStr & " ) "

                Obj.FetchReader(SqlPass)
                Obj.ConClose()

                SqlPass = "UPDATE   InvoiceToComments SET UpdateTime=GETDATE(), StatusDate='" & txtDate.Text & "' , Status=  '" & txtRemarksToUpdate.Text & "' , Remarks='" & TxtComments.Text & "'  WHERE   invoice_no IN (" & AutoStr & " )      "
                Obj.FetchReader(SqlPass)
                Obj.ConClose()
                BindData()

            ElseIf rblSelection.Text = "Comments" And Trim(txtRemarks.Text) <> "" Then


                If txtRemarksToUpdate.Text <> "RECEIVED" Then


                    SqlPass = "UPDATE   InvoiceToComments SET   StatusBackDate='" & txtDate.Text & "'    WHERE   invoice_no IN (" & AutoStr & " )     AND UpdateTime IN ( SELECT  MAX(UpdateTime) FROM   InvoiceToComments  WHERE   invoice_no IN (" & AutoStr & " ) ) "
                    Obj.FetchReader(SqlPass)
                    Obj.ConClose()


                End If

                SqlPass = " INSERT InvoiceToComments  SELECT  CustNo ,CustName ,invoice_no ,invoice_dt , basic_amt ,tax_amt , charge_amt ,discount_amt , frt_amt ,invoice_amt ,invoice_net_amt ,GetAmount ,outstanding_amt ,CredAmt ,OthAmt ,HostId ,Type ,OrderNo ,SalePersonCode , SalePersonName,NULL ,NULL ,NULL , Remarks,NULL FROM   SHP..InvoiceToComments  WHERE   invoice_no IN (" & AutoStr & " )   " & _
                          " AND UpdateTime IN ( SELECT  MAX(UpdateTime) FROM   SHP..InvoiceToComments  WHERE   invoice_no IN (" & AutoStr & " ) ) "
                Obj.FetchReader(SqlPass)
                Obj.ConClose()


                SqlPass = "UPDATE    SHP..InvoiceToComments  SET UpdateTime=GETDATE(), StatusDate='" & txtDate.Text & "' , Status=  '" & txtRemarksToUpdate.Text & "'  WHERE   invoice_no IN (" & AutoStr & " ) AND StatusDate IS NULL  "
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
        Dim sExcelFile As String = Server.MapPath("Invoice.xls")
        oExcelWrite = IO.File.CreateText(sExcelFile)
        oExcelWrite.WriteLine(sTable)
        oExcelWrite.Close()
        bFileCreated = True
        Return bFileCreated

    End Function


    Protected Sub BtnExcel_Click(sender As Object, e As System.EventArgs) Handles BtnExcel.Click
        GridViewExportUtil.Export("Invoice.xls", GridView1)
    End Sub

    Protected Sub txtRemarksToUpdate_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles txtRemarksToUpdate.SelectedIndexChanged

        SqlPass = "SELECT  Definitions  FROM MISDEV.JCTDEV.DBO.JCT_OPS_INVOICE_REASON WHERE UPPER(Catogories)='" & txtRemarksToUpdate.Text & "'"
        'SqlPass = "SELECT  Definitions  FROM MISDEV.JCTDEV.DBO.JCT_OPS_PACKED_STOCK_REASON WHERE UPPER(Catogories) + '--' + UPPER(SubCatogories)='" & txtRemarksToUpdate.Text & "'"
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

                txtCustomer.DataTextField = ds.Tables(0).Columns("CustName").ToString()
                txtCustomer.DataValueField = ds.Tables(0).Columns("CustName").ToString()

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



    Protected Sub txtSalePerson_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles txtSalePerson.SelectedIndexChanged

        BindDropDownCustomer("SELECT '' AS CustName UNION ALL SELECT DISTINCT CustName FROM SHP..Combine_Invoice_OPS_Detail  WHERE ( SalePersonName='" & txtSalePerson.Text & "'  OR '" & txtSalePerson.Text & "' ='ALL') AND invoice_dt BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' ")
      
    End Sub

    Protected Sub txtRemarks_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles txtRemarks.SelectedIndexChanged
        If txtRemarks.Text = "RECEIVED" Then
            btnUpdate.Enabled = False
        Else
            btnUpdate.Enabled = True
        End If

    End Sub
End Class