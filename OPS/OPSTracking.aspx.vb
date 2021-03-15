
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Threading
Partial Class OPS_OPSTracking
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Qry As String
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim SqlPass As String
 
    Protected Sub CmdXl_Click(sender As Object, e As System.EventArgs) Handles CmdXl.Click
        GridViewExportUtil.Export("Plan" & ".xls", grdTracking)
    End Sub
   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Qry = " SELECT '' AS [team_code],'' AS  [team_description] UNION  SELECT  UPPER(RTRIM(team_code)), UPPER(RTRIM(team_description)) FROM MISERP.SOM.DBO.jct_team_mASter  ORDER BY team_code   "
            ObjFun.FillList(ddlSalesTeam, Qry)
            If ddlSalesTeam.SelectedItem.Text = "" Then

                Qry = "SELECT  '' AS group_desc, '' AS group_no UNION SELECT  UPPER(RTRIM(group_no)), UPPER(RTRIM(group_desc)) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
                ObjFun.FillList(ddlSalesPerson, Qry)

            Else

                ddlSalesPerson.Items.Clear()
                Qry = "SELECT '' AS  [sale_person_code] ,'' AS  [group_desc] UNION SELECT DISTINCT  UPPER(RTRIM(a.sale_person_code)), UPPER(RTRIM(b.group_desc)) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
                ObjFun.FillList(ddlSalesPerson, Qry)
            End If

            '  CmdFetch_Click(sender, e)
        End If
    End Sub
 

    Protected Sub ddlSalesTeam_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSalesTeam.SelectedIndexChanged
        If ddlSalesTeam.SelectedItem.Text = "" Then

            ddlSalesPerson.Items.Clear()
            Qry = "SELECT '' AS group_no, '' AS  group_desc UNION SELECT  UPPER(RTRIM(group_no)), UPPER(RTRIM(group_desc)) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        Else
            ddlSalesPerson.Items.Clear()
            Qry = "SELECT '' AS [sale_person_code] ,'' AS [group_desc] UNION SELECT DISTINCT  UPPER(RTRIM(a.sale_person_code)), UPPER(RTRIM(b.group_desc)) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        End If
    End Sub


 
    Protected Sub TxtCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCustomer.TextChanged
        If Me.TxtCustomer.Text = "ALL" Then
            OrderExt.ContextKey = "ALL"
        Else
            OrderExt.ContextKey = Me.TxtCustomer.Text.Split("~")(1).ToString()

        End If

    End Sub

    Protected Sub lnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFetch.Click
        SqlPass = "SELECT  order_no AS OrderNo,  team_code AS Team ,sale_person_code AS SalePerCode , group_desc AS SalePerson ,sale_catg AS Category , segment AS Segment ,   end_cust AS EndCust,   bill_cust_no AS  CustNo ,  cust_name AS CustName , order_srl_no AS SrlNo,   item_no AS ItemNo  ,variant AS Variant,  ISNULL(Shade, '') AS Shade ,order_dt AS OrderDate, req_dt AS ReqDt ,unit_price AS UP , sales_price AS SP , ISNULL(DnvMkt, '') AS DnvMkt , " & _
  "ISNULL(DnvCost, '') AS DnvCost ,req_qty AS ReqQty, des_qty AS DesQty , ISNULL(CH, '') AS CH ,    ISNULL(FN, '') AS FN ,    ISNULL(FR, '') AS FR ,  ISNULL(RG, '') AS RG , ISNULL(SA, '') AS SA ,ISNULL(SF, '') AS SF , ISNULL(SLP, '') AS SLP ,  ISNULL(SLT, '') AS SLT ,ISNULL(SM, '') AS SM , ISNULL(SO, '') AS SO ,  ISNULL(SP, '') AS SP ,ISNULL(ST, '') AS ST ,ISNULL(SW, '') AS SW ,item_value ,Tolerance ," & _
  "status ,ISNULL(DaysOverdue, '') AS DaysOverdue ," & _
        "ISNULL(PackInGodown, '') AS PackInGodown ,ISNULL(CHGodown, '') AS CHGodown ,  ISNULL(FNGodown, '') AS FNGodown ,    ISNULL(FRGodown, '') AS FRGodown ,ISNULL(RGGodown, '') AS RGGodown ,  ISNULL(SAGodown, '') AS SAGodown ," & _
        "ISNULL(SFGodown, '') AS SFGodown ,  ISNULL(SLPGodown, '') AS SLPGodown ,ISNULL(SLTGodown, '') AS SLTGodown , ISNULL(SMGodown, '') AS SMGodown ,ISNULL(SOGodown, '') AS SOGodown ,  ISNULL(SPGodown, '') AS SPGodown ,        ISNULL(STGodown, '') AS STGodown ,ISNULL(SWGodown, '') AS SWGodown ," & _
  "ISNULL(CHODS, '') AS CHODS , ISNULL(FNODS, '') AS FNODS ,  ISNULL(FRODS, '') AS FRODS ,   ISNULL(RGODS, '') AS RGODS , ISNULL(SAODS, '') AS SAODS ,  ISNULL(SFODS, '') AS SFODS ,  ISNULL(SLPODS, '') AS SLPODS , ISNULL(SLTODS, '') AS SLTODS ," & _
  "ISNULL(SMODS, '') AS SMODS ,  ISNULL(SOODS, '') AS SOODS ,  ISNULL(SPODS, '') AS SPODS , ISNULL(STODS, '') AS STODS ,ISNULL(SWODS, '') AS SWODS ," & _
        "ISNULL(CHUNIS, '') AS CHUNIS ,  ISNULL(FNODS, '') AS FNUNIS ,ISNULL(FRUNIS, '') AS FRUNIS ,   ISNULL(RGUNIS, '') AS RGUNIS ,  ISNULL(SAUNIS, '') AS SAUNIS ,  ISNULL(SFUNIS, '') AS SFUNIS ,  ISNULL(SLPUNIS, '') AS SLPUNIS ," & _
  "ISNULL(SLTUNIS, '') AS SLTUNIS ,ISNULL(SMUNIS, '') AS SMUNIS ,        ISNULL(SOUNIS, '') AS SOUNIS ,ISNULL(SPUNIS, '') AS SPUNIS ,ISNULL(STUNIS, '') AS STUNIS ,  ISNULL(SWUNIS, '') AS SWUNIS , ISNULL(MRQty, '') AS MRQty ," & _
  "ISNULL(ODSDispatchOrder, '') AS ODSDispatchOrder ,ISNULL(ODSDispatchQty, '') AS ODSDispatchQty ,ISNULL(ODSDispatchSP, '') AS ODSDispatchSP ,   ISNULL(ODSDispatchDNV, '') AS ODSDispatchDNV , ISNULL(ODSDispatchInvoiceNo, '') AS ODSDispatchInvoiceNo ,  " & _
  "ISNULL(WODSDispatchOrder, '') AS WODSDispatchOrder ,   ISNULL(WODSDispatchQty, '') AS WODSDispatchQty , ISNULL(WODSDispatchSP, '') AS WODSDispatchSP , ISNULL(WODSDispatchDNV, '') AS WODSDispatchDNV ,     ISNULL(WODSDispatchInvoiceNo, '') AS WODSDispatchInvoiceNo, " & _
  "ISNULL(InvoiceNo, '') AS InvoiceNo ,        ISNULL(InvoiceSP, '') AS InvoiceSP ,ISNULL(InvoiceQty, '') AS InvoiceQty ,  ISNULL(InvoiceDate, '') AS InvoiceDate ," & _
        "ISNULL(TotalInvoiceAmt, '') AS TotalInvoiceAmt ,  ISNULL(GetAmount, '') AS GetAmount ,        ISNULL(OutStandingAmt, '') AS OutStandingAmt ,   ISNULL(CreditNoteAmt, '') AS CreditNoteAmt " & _
  "FROM    JCT_OPS_ALL_TRACKING WHERE   order_dt BETWEEN '" & TxtEffFrom.Text & "' AND '" & TxtEffTo.Text & " '  AND (Order_no= '" & TxtOrder.Text & "' OR '" & TxtOrder.Text & "'='')  ORDER BY order_dt ,   order_no ,       order_srl_no"

        'AND (team_code= '" & ddlSalesTeam.SelectedItem.Text & "' OR '" & ddlSalesTeam.SelectedItem.Text & "'='')  AND    (group_desc= '" & ddlSalesPerson.SelectedItem.Text & "' OR '" & ddlSalesPerson.SelectedItem.Text & "'='')   
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                grdTracking.DataSource = ds
                grdTracking.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try
    End Sub
End Class


