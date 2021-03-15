Imports System.Data.SqlClient
Partial Class LostCustomers
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Dim i As Integer
    Public dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Me.txtfrm.Value = Left(DateAdd(DateInterval.Year, -3, Now()), 10)
            Me.txtTo.Value = Left(Now(), 10)
            obj.opencn()
            qry = "select cust_name from miserp.som.dbo.m_customer  where cust_status='o' and company_no='jct00ltd' and locn_no='phg' order by cust_name"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            Me.DrpCust.Items.Clear()
            If dr.HasRows = True Then
                Me.DrpCust.Items.Add("[All]")
                While dr.Read()
                    Me.DrpCust.Items.Add(Trim(dr.Item(0)))
                End While
            End If
            dr.Close()
            obj.closecn()
            obj.opencn()
            qry = "select group_desc from miserp.som.dbo.m_cust_group where group_type='salesp' and status='o' and company_no='jct00ltd' and locn_no='phg' order by group_desc"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            Me.DrpSaleP.Items.Clear()
            Me.DrpSaleP.Items.Add("[All]")
            If dr.HasRows = True Then
                While dr.Read()
                    Me.DrpSaleP.Items.Add(Trim(dr.Item(0)))
                End While
            End If
            dr.Close()
            obj.closecn()
            Me.DrpCountry.Items.Clear()
            obj.opencn()
            qry = "select distinct country from miserp.som.dbo.m_cust_address  order by country"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            Me.DrpCountry.Items.Clear()
            If dr.HasRows = True Then
                Me.DrpCountry.Items.Add("[All]")
                While dr.Read()
                    Me.DrpCountry.Items.Add(Trim(dr.Item(0)))
                End While
            End If
            dr.Close()
            obj.closecn()

            DrpCountry_SelectedIndexChanged(sender, Nothing)
            Me.ChkLastBusiness.Checked = False
            ChkLastBusiness_CheckedChanged(sender, Nothing)
            Me.TxtFromB.Value = "01/01/1951"
            Me.txtToB.Value = "12/31/2999"
        End If
    End Sub

    Protected Sub DrpSaleP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpSaleP.SelectedIndexChanged
        obj.opencn()
        If Trim(Me.DrpSaleP.Text) <> "[All]" Then
            qry = "select cust_name from miserp.som.dbo.m_customer a, miserp.som.dbo.m_cust_mapping b, miserp.som.dbo.m_cust_group c where a.company_no=b.company_no and a.locn_no=b.locn_no and a.company_no=c.company_no and a.locn_no=c.locn_no and a.company_no='jct00ltd' and a.locn_no='phg' and a.cust_no= b.cust_no and b.group_type='salesp' and b.group_no=c.group_no and c.group_type='salesp' and b.control_grp_flag=c.control_grp_flag and  b.control_grp_flag=1 and c.status='o' and cust_nature='o' and ( '" & Trim(Me.DrpSaleP.Text) & "' = '[All]' or group_desc = '" & Trim(Me.DrpSaleP.Text) & "' ) order by group_desc,cust_name"
        Else
            qry = "select cust_name from miserp.som.dbo.m_customer  where cust_status='o' and company_no='jct00ltd' and locn_no='phg' order by cust_name"
        End If
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.DrpCust.Items.Clear()
        If dr.HasRows = True Then
            Me.DrpCust.Items.Add("[All]")
            While dr.Read()
                Me.DrpCust.Items.Add(Trim(dr.Item(0)))
            End While
        End If
        dr.Close()
        obj.closecn()
    End Sub

    Protected Sub DrpCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpCountry.SelectedIndexChanged
        obj.opencn()
        If Trim(Me.DrpSaleP.Text) <> "[All]" Then
            If Trim(Me.DrpCountry.Text) <> "[All]" Then
                qry = "select cust_name from miserp.som.dbo.m_customer a, miserp.som.dbo.m_cust_mapping b, miserp.som.dbo.m_cust_group c,miserp.som.dbo.m_cust_address d where a.company_no=b.company_no and a.locn_no=b.locn_no and a.company_no=c.company_no and a.locn_no=c.locn_no and a.company_no='jct00ltd' and a.cust_no=d.cust_no and a.locn_no='phg' and a.cust_no= b.cust_no and b.group_type='salesp' and b.group_no=c.group_no and c.group_type='salesp' and b.control_grp_flag=c.control_grp_flag and  b.control_grp_flag=1 and c.status='o' and cust_nature='o' and ( '" & Trim(Me.DrpSaleP.Text) & "' = '[All]' or group_desc = '" & Trim(Me.DrpSaleP.Text) & "' ) order by group_desc,state,cust_name"
            Else
                qry = "select cust_name from miserp.som.dbo.m_customer a, miserp.som.dbo.m_cust_mapping b, miserp.som.dbo.m_cust_group c where a.company_no=b.company_no and a.locn_no=b.locn_no and a.company_no=c.company_no and a.locn_no=c.locn_no and a.company_no='jct00ltd' and a.locn_no='phg' and a.cust_no= b.cust_no and b.group_type='salesp' and b.group_no=c.group_no and c.group_type='salesp' and b.control_grp_flag=c.control_grp_flag and  b.control_grp_flag=1 and c.status='o' and cust_nature='o' and ( '" & Trim(Me.DrpSaleP.Text) & "' = '[All]' or group_desc = '" & Trim(Me.DrpSaleP.Text) & "' ) order by group_desc,cust_name"
            End If
        Else
            If Trim(Me.DrpCountry.Text) = "[All]" Then
                qry = "select cust_name from miserp.som.dbo.m_customer   where cust_status='o' and company_no='jct00ltd' and locn_no='phg' order by cust_name"
            Else
                qry = "select cust_name from miserp.som.dbo.m_customer a,miserp.som.dbo.m_cust_address b  where a.cust_no=b.cust_no and cust_status='o' and a.company_no='jct00ltd' and a.locn_no='phg' and country = '" & Trim(Me.DrpCountry.Text) & "' order by cust_name"
            End If
        End If
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.DrpCust.Items.Clear()
        If dr.HasRows = True Then
            Me.DrpCust.Items.Add("[All]")
            While dr.Read()
                Me.DrpCust.Items.Add(Trim(dr.Item(0)))
            End While
        End If
        dr.Close()
        obj.closecn()

        Me.DrpState.Items.Clear()
        If Trim(Me.DrpCountry.Text) <> "[All]" Then
            qry = "select distinct state from miserp.som.dbo.m_cust_address where country='" & Trim(Me.DrpCountry.Text) & "' order by state"
        Else
            qry = "select distinct state from miserp.som.dbo.m_cust_address  order by state"
        End If
        obj.opencn()
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.DrpState.Items.Clear()
        If dr.HasRows = True Then
            Me.DrpState.Items.Add("[All]")
            While dr.Read()
                Me.DrpState.Items.Add(Trim(dr.Item(0)))
            End While
        End If
        dr.Close()
        obj.closecn()
        DrpState_SelectedIndexChanged(sender, Nothing)
    End Sub

    Protected Sub DrpState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpState.SelectedIndexChanged
        Me.DrpCity.Items.Clear()
        If Trim(Me.DrpState.Text) <> "[All]" Then
            qry = "select distinct city from miserp.som.dbo.m_cust_address where state='" & Trim(Me.DrpState.Text) & "' order by city"
        Else
            qry = "select distinct city from miserp.som.dbo.m_cust_address  order by city"
        End If
        obj.opencn()
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.DrpCity.Items.Clear()
        If dr.HasRows = True Then
            Me.DrpCity.Items.Add("[All]")
            While dr.Read()
                Me.DrpCity.Items.Add(Trim(dr.Item(0)))
            End While
        End If
        dr.Close()
        obj.closecn()
        DrpCity_SelectedIndexChanged(sender, Nothing)
    End Sub

    Protected Sub DrpCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpCity.SelectedIndexChanged
        obj.opencn()
        If Trim(Me.DrpSaleP.Text) <> "[All]" Then
            qry = "select cust_name from miserp.som.dbo.m_customer a, miserp.som.dbo.m_cust_mapping b, miserp.som.dbo.m_cust_group c,miserp.som.dbo.m_cust_address d where a.company_no=b.company_no and a.locn_no=b.locn_no and a.company_no=c.company_no and a.locn_no=c.locn_no and a.company_no='jct00ltd' and a.cust_no=d.cust_no and a.locn_no='phg' and a.cust_no= b.cust_no and b.group_type='salesp' and b.group_no=c.group_no and c.group_type='salesp' and b.control_grp_flag=c.control_grp_flag and  b.control_grp_flag=1 and c.status='o' and cust_nature='o' and ( '" & Trim(Me.DrpSaleP.Text) & "' = '[All]' or group_desc = '" & Trim(Me.DrpSaleP.Text) & "' ) and (state='" & Trim(Me.DrpState.Text) & "' or '" & Trim(Me.DrpState.Text) & "' = '[All]') and (city='" & Trim(Me.DrpCity.Text) & "' or '" & Trim(Me.DrpCity.Text) & "' = '[All]') and (country='" & Trim(Me.DrpCountry.Text) & "' or '" & Trim(Me.DrpCountry.Text) & "' = '[All]') order by group_desc,country,state,city,cust_name"
        Else
            qry = "select cust_name from miserp.som.dbo.m_customer a,miserp.som.dbo.m_cust_address b  where a.cust_no=b.cust_no and cust_status='o' and a.company_no='jct00ltd' and a.locn_no='phg'  and (state='" & Trim(Me.DrpState.Text) & "' or '" & Trim(Me.DrpState.Text) & "' = '[All]') and (city='" & Trim(Me.DrpCity.Text) & "' or '" & Trim(Me.DrpCity.Text) & "' = '[All]') and (country='" & Trim(Me.DrpCountry.Text) & "' or '" & Trim(Me.DrpCountry.Text) & "' = '[All]') order by country,state,city,cust_name"
        End If
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.DrpCust.Items.Clear()
        If dr.HasRows = True Then
            Me.DrpCust.Items.Add("[All]")
            While dr.Read()
                Me.DrpCust.Items.Add(Trim(dr.Item(0)))
            End While
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub ChkLastBusiness_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLastBusiness.CheckedChanged
        If Me.ChkLastBusiness.Checked = True Then
            Me.TxtFromB.Visible = True
            Me.txtToB.Visible = True
        Else
            Me.TxtFromB.Visible = False
            Me.txtToB.Visible = False
        End If
    End Sub

    Protected Sub BtnFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFetch.Click
        Dim ds As New Data.DataSet
        Dim drow As Data.DataRow

        Dim dt As New Data.DataTable
        Dim cl(11) As String
        Dim cust, po, shd As String
        obj.opencn()
        Me.Panel1.Height = 400
        If Trim(Me.txtfrm.Value) = "" Then

        End If
        'Me.PnlGrid.Collapsed = False
        qry = "exec miserp.reportdb.dbo.JCT_Cust_lost_customers '" & (Me.txtfrm.Value) & "','" & (Me.txtTo.Value) & "','" & Trim(Me.DrpSaleP.Text) & "','" & Trim(Me.DrpCust.Text) & "' ,'" & Trim(Me.DrpCity.Text) & "','" & Trim(Me.DrpState.Text) & "' ,'" & Trim(Me.DrpCountry.Text) & "','" & Trim(Me.TxtFromB.Value) & "','" & Trim(Me.txtToB.Value) & "'"
        cmd = New SqlCommand(qry, obj.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        Dim i As Integer
        cl(0) = "SalePerson"
        cl(1) = "Customer No"
        cl(2) = "Customer Name"
        cl(3) = "Appointed Date"
        cl(4) = "Last Business"
        cl(5) = "City"
        cl(6) = "State"
        cl(7) = "Country"
        cl(8) = "Phone No"
        cl(9) = "Flag"

        For i = 0 To 9
            Dim dc As New Data.DataColumn
            dc.ColumnName = cl(i)
            dt.Columns.Add(dc)
        Next

        If dr.HasRows = True Then
            While dr.Read()
                drow = dt.NewRow()
                dt.Rows.Add(drow)
                For i = 0 To 9
                    drow(i) = dr(i)
                Next
                'If dt.Rows.Count = 1 Then
                '    drow(0) = Trim(dr.Item(0))
                '    drow(10) = Trim(dr.Item("invoice_net_amt"))
                'End If
                'drow(5) = Trim(dr.Item("lot_no"))
                'drow(6) = Trim(dr.Item("item_no"))
                'drow(7) = Trim(dr.Item("variant"))
                'If dr.Item("class") Is System.DBNull.Value Then
                'Else
                '    drow(8) = Trim(dr.Item("class"))
                'End If

                'drow(9) = dr.Item("meters")

                'If cust <> Trim(dr.Item("cust_name")) Then
                '    drow(1) = Trim(dr.Item("cust_name"))
                '    drow(2) = Trim(dr.Item("city")) & "," & Trim(dr.Item("state"))
                '    cust = Trim(dr.Item("cust_name"))
                'End If
                'If cust <> Trim(dr.Item("cust_name")) Or po <> Trim(dr.Item("order_no")) Then
                '    drow(3) = Trim(dr.Item("order_no"))
                '    po = Trim(dr.Item("order_no"))
                'End If
                'If cust <> Trim(dr.Item("cust_name")) Or po <> Trim(dr.Item("order_no")) Or shd <> Trim(dr.Item("shade_design")) Then
                '    drow(4) = Trim(dr.Item("shade_design"))
                '    shd = Trim(dr.Item("shade_design"))
                'End If
            End While
        End If
        GridView1.DataSource = dt
        GridView1.DataBind()
        dr.Close()
        obj.closecn()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(1).Text = "<a href='LostCustomerAnalysis.aspx?CustNo=" & e.Row.DataItem(1) & "'>" & e.Row.DataItem(1) & "</a>"
            If e.Row.Cells(9).Text = "L" Then
                e.Row.BackColor = Drawing.Color.WhiteSmoke   ''Color.FromName("#FAF7DA")
            End If
        End If
    End Sub
End Class
