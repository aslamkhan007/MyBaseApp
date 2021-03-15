'Imports System.Data
Imports System.Data.SqlClient
Imports System
'Imports System.Configuration
'Imports System.Collections
'Imports System.Web
'Imports System.Web.Security
'Imports System.Web.UI
'Imports System.Web.UI.WebControls
'Imports System.Web.UI.WebControls.WebParts
'Imports System.Web.UI.HtmlControls
'Imports System.Threading
Partial Class OPS_Standard_Vs_Actual_PlanForProcessing
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    ' Dim ObjERP As 
    Dim Qry As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand

    Protected Sub lnkFetch_Click(sender As Object, e As System.EventArgs) Handles lnkFetch.Click
        Dim CustCode As String, SalePerson As String, OrderNo As String, SalesTeam As String
        If txtOrderNo.Text = "" Then
            OrderNo = ""
        Else
            OrderNo = Trim(txtOrderNo.Text)
        End If
        If txtCustomer.Text = "" Then
            CustCode = ""
        Else
            CustCode = Right(txtCustomer.Text, Len(txtCustomer.Text) - InStr(txtCustomer.Text, "~")) 'txtCustomer.Text
        End If
        If ddlSalesPerson.SelectedItem.Text = "" Then
            SalePerson = ""
        Else
            SalePerson = Trim(ddlSalesPerson.SelectedItem.Value)
        End If


        If ddlSalesTeam.SelectedItem.Text = "" Then
            SalePerson = ""
        Else
            SalePerson = Trim(ddlSalesTeam.SelectedItem.Value)
        End If

        If ChkIgnoreDates.Checked = True Then
            Qry = "EXEC Jct_Proc_Standard_Vs_Planned_Schedule '" & SalePerson & "','" & txtOrderNo.Text & "','" & CustCode & "','','','','04/01/2010','04/01/2020','" & ddlProcess.SelectedItem.Text & "','" & ddlPlant.SelectedItem.Text & "'"
        Else
            Qry = "EXEC Jct_Proc_Standard_Vs_Planned_Schedule '" & SalePerson & "','" & txtOrderNo.Text & "','" & CustCode & "','','','','" & txtDateFrom.Text & "','" & txtDateTo.Text & "','" & ddlProcess.SelectedItem.Text & "','" & ddlPlant.SelectedItem.Text & "'"
        End If
        ObjFun.FillGrid(Qry, GridView1)
    End Sub

    Protected Sub ddlSalesTeam_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSalesTeam.SelectedIndexChanged
        If ddlSalesTeam.SelectedItem.Text = "" Then

            ddlSalesPerson.Items.Clear()
            Qry = "Select '' as group_no, '' as group_desc Union SELECT RTRIM(group_no),RTRIM(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        Else
            ddlSalesPerson.Items.Clear()
            Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT RTRIM(a.sale_person_code),RTRIM(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        End If
    End Sub

    Protected Sub ddlSalesPerson_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSalesPerson.SelectedIndexChanged

    End Sub

    Protected Sub rblSaleOrder_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblSaleOrder.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'If e.Row.RowType <> DataControlRowType.Header Then
        '    If Val(e.Row.Cells(9).Text) > Val(e.Row.Cells(12).Text) Then
        '        e.Row.Cells(12).CssClass = "GridRowRed"
        '    ElseIf Val(e.Row.Cells(9).Text) < Val(e.Row.Cells(12).Text) Then
        '        e.Row.Cells(12).CssClass = "GridRowGreen"
        '    End If
        'End If
        e.Row.Cells(1).Wrap = False
        e.Row.Cells(12).Wrap = False
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If GridView1.SelectedRow.RowType = DataControlRowType.DataRow Then
            Qry = "exec MISERP.SOM.DBO.jct_Ops_Order_Processing_Info 'JCT00LTD', 'PHG', 1, '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "', 5,'T','" & Trim(GridView1.SelectedRow.Cells(12).Text) & "'"

            DataList1.DataSource = ObjFun.FetchDS(Qry)
            DataList1.DataBind()
            Qry = "exec MISERP.SOM.DBO.jct_Ops_Order_Processing_Info 'JCT00LTD', 'PHG', 1, '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "', 5,'F','" & Trim(GridView1.SelectedRow.Cells(12).Text) & "'"
            ObjFun.FillGrid(Qry, GrdOrderinfo)
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)

            Qry = " Select '' as [team_code],'' as [team_description] Union  SELECT rtrim(team_code),rtrim(team_description) FROM MISERP.SOM.DBO.jct_team_mASter  ORDER BY team_code   "
            ObjFun.FillList(ddlSalesTeam, Qry)
            If ddlSalesTeam.SelectedItem.Text = "" Then

                Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
                ObjFun.FillList(ddlSalesPerson, Qry)

            Else

                ddlSalesPerson.Items.Clear()
                Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT rtrim(a.sale_person_code),rtrim(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
                ObjFun.FillList(ddlSalesPerson, Qry)
            End If
        End If
    End Sub

    Protected Sub txtOrderNo_TextChanged(sender As Object, e As System.EventArgs) Handles txtOrderNo.TextChanged
        Qry = "SELECT  DISTINCT B.po_num AS Order_no  FROM    production..jct_process_issue_gry a ( NOLOCK ),production..jct_process_issue_gry_det b ( NOLOCK ) ,production..JCT_Issue_PHouse c ( NOLOCK )  where a.lot_no = b.lot_no  AND a.lot_no = c.Issue_No  AND c.operation = ''  AND c.folding_Code IN ( 'FCT', 'FSY', 'FDC', 'GWT' ) AND b.po_num LIKE  Order BY B.po_num "

    End Sub

    Protected Sub ChkIgnoreDates_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChkIgnoreDates.CheckedChanged
        If ChkIgnoreDates.Checked = False Then
            MEV6.Enabled = False
            MaskedEditValidator1.Enabled = False
        Else
            MEV6.Enabled = True
            MaskedEditValidator1.Enabled = True

        End If
    End Sub

    Protected Sub CmdXl_Click(sender As Object, e As System.EventArgs) Handles CmdXl.Click
        GridViewExportUtil.Export("Plan" & ".xls", GridView1)
    End Sub
End Class
