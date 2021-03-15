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
Partial Class OPS_ReviseSaleOrderSchedule
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim Qry As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand
    Protected Sub txtOrderNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderNo.TextChanged
        'Qry = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        'ObjFun.FillGrid(Qry, GridOrderDetail)
        Qry = "SELECT LINE_NO AS [LineNo],Sort,1500 AS AcutalQty,PlannedQty ,PlannedQty ,CONVERT(VARCHAR(10),PlannedForDt,101) AS PlannedForDt ,STATUS ,TokenNo ,RevisedFlag,RevisionNo ,ISNULL(RevisedByUser,'') as RevisedBy FROM JCT_Ops_Planned_Orders_Detail where order_no='" & txtOrderNo.Text & "' order by [Line_No]"
        ObjFun.FillGrid(Qry, GridOrderDetail0)
        Qry = "SELECT DISTINCT b.cust_name AS CustomerName ,e.group_desc AS SalePerson FROM  production..jct_process_issue_gry_det a LEFT OUTER JOIN miserp.som.dbo.t_order_hdr c ON a.po_num = c.order_no LEFT OUTER JOIN miserp.som.dbo.m_customer b ON c.bill_cust_no = b.cust_no INNER JOIN miserp.som.dbo.jct_so_team_catg d on c.order_no=d.order_no LEFT OUTER JOIN miserp.som.dbo.m_cust_group e ON e.group_no=d.sale_person_code WHERE   a.po_num LIKE '" & txtOrderNo.Text & "'"
        Cmd = New SqlCommand(Qry, Obj.Connection)
        Dr = Cmd.ExecuteReader
        Dr.Read()
        If Dr.HasRows = True Then
            lblSalePerson.Text = Dr.Item("SalePerson")
            lblCustomerName.Text = Dr.Item("CustomerName")
        End If
    End Sub



    Protected Sub GridOrderDetail0_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridOrderDetail0.RowDataBound
        If e.Row.RowType <> DataControlRowType.Header And e.Row.RowType <> DataControlRowType.Footer Then
            'Dim txt As TextBox
            'txt.Text = e.Row.

        End If
    End Sub


End Class
