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
Partial Class OPS_frm_Order_Status
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Qry As String
    Protected Sub lnkFetch_Click(sender As Object, e As System.EventArgs) Handles lnkFetch.Click
        Qry = "Exec production..Jct_OPS_ProductionTracking '" & txtOrderNo.Text & "','<<All>>','<<All>>',1000"
        ObjFun.FillGrid(Qry, GridOrderDetail)
        FillGrid()
    End Sub
    Protected Sub FillGrid()
        Qry = "EXEC dbo.jct_ops_grey_inspection_fromTBL @order = '" + txtOrderNo.Text + "', @CustomerCode = '-All-', @SalePerson = '-All-', @Records = 0, @UserCode = '-All-', @Team = '-All-' "
        ObjFun.FillGrid(Qry, GrdQCDetail)
        Qry = "EXEC dbo.jct_ops_fab_test_result_fromTBL @order = '" + txtOrderNo.Text + "', @CustomerCode = '-All-', @SalePerson = '-All-', @Records = 0, @UserCode = '-All-', @Team = '-All-' "
        ObjFun.FillGrid(Qry, GrdFabricDetail)
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

    Protected Sub txtCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged
        Try
            txtCustomer.Text = txtCustomer.Text.Split("~")(1).ToString()
            FillOrders()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

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

            '  CmdFetch_Click(sender, e)
        End If
    End Sub
    Private Sub FillOrders()
        Qry = "select distinct a.order_no from miserp.som.dbo.t_order_hdr a where a.status IN ('A','O') and a.ord_cust_no='" + txtCustomer.Text + "'  AND a.order_dt >='04/01/2011' and ( a.order_no like '%" + txtOrderNo.Text + "%'  OR '" + txtOrderNo.Text + "'='') order by a.order_no "
        ObjFun.FillList(rblSaleOrder, Qry)
    End Sub

    Protected Sub txtOrderNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderNo.TextChanged
        FillOrders()
    End Sub

    Protected Sub rblSaleOrder_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblSaleOrder.SelectedIndexChanged
        txtOrderNo.Text = rblSaleOrder.SelectedItem.Text
    End Sub
End Class
