Imports System.Data.SqlClient
Imports system.Math
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.CrystalReports.Engine
Partial Class ActivityChart
    Inherits System.Web.UI.Page

    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Dim i As Integer
    Dim yr, dys As Integer
    Public dr As SqlDataReader
    Public dt As New Data.DataTable
    Dim cl(70) As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            'Me.CollapsablePanel1.Collapsed = True
            obj.opencn()
            qry = "select cust_name from miserp.som.dbo.m_customer  where cust_status='o' and company_no='jct00ltd' and locn_no='phg' order by cust_name"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            Me.DrpCust.Items.Clear()
            If dr.HasRows = True Then
                Me.DrpCust.Items.Add("[[All]]")
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
            Me.DrpSalePer.Items.Clear()
            Me.DrpSalePer.Items.Add("[[All]]")
            If dr.HasRows = True Then
                While dr.Read()
                    Me.DrpSalePer.Items.Add(Trim(dr.Item(0)))
                End While
            End If
            dr.Close()
            obj.closecn()
        Else
            'Table1 = ViewState("vtable1")
            'Table2 = ViewState("vtable2")
        End If

    End Sub




    Protected Sub DrpSalePer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpSalePer.SelectedIndexChanged
        obj.opencn()
        If Trim(Me.DrpSalePer.Text) <> "[[All]]" Then
            qry = "select cust_name from miserp.som.dbo.m_customer a, miserp.som.dbo.m_cust_mapping b, miserp.som.dbo.m_cust_group c where a.company_no=b.company_no and a.locn_no=b.locn_no and a.company_no=c.company_no and a.locn_no=c.locn_no and a.company_no='jct00ltd' and a.locn_no='phg' and a.cust_no= b.cust_no and b.group_type='salesp' and b.group_no=c.group_no and c.group_type='salesp' and b.control_grp_flag=c.control_grp_flag and  b.control_grp_flag=1 and c.status='o' and cust_nature='o' and ( '" & Trim(Me.DrpSalePer.Text) & "' = '[[All]]' or group_desc = '" & Trim(Me.DrpSalePer.Text) & "' ) order by group_desc,cust_name"
        Else
            qry = "select cust_name from miserp.som.dbo.m_customer  where cust_status='o' and company_no='jct00ltd' and locn_no='phg' order by cust_name"
        End If
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.DrpCust.Items.Clear()
        If dr.HasRows = True Then
            Me.DrpCust.Items.Add("[[All]]")
            While dr.Read()
                Me.DrpCust.Items.Add(Trim(dr.Item(0)))
            End While
        End If
        dr.Close()
        obj.closecn()
    End Sub

    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        Dim ds As New Data.DataSet
        Dim drow As Data.DataRow
        Dim drow2 As Data.DataRow
        dt = New Data.DataTable
        'Me.CollapsablePanel1.Collapsed = False
        Dim cust As String = ""
        Dim sp As String = ""
        Dim j As Integer
        'lblFrom.Text = Me.DrpMnthFrm.SelectedIndex + 1 & "/" & Trim(Me.DrpDayFrm.Text) & "/" & Trim(Me.DrpYrFrm.Text)
        'lblto.Text = Me.DrpMnthTo.SelectedIndex + 1 & "/" & Trim(Me.DrpDayTo.Text) & "/" & Trim(Me.DrpYrTo.Text)
        'Response.Write(Me.lblFrom.Text & "---" & Me.lblto.Text)

        Dim dat As Date
        Dim i As Integer
        cl(0) = "Sale Person"
        cl(1) = "Customer Name"
        cl(2) = "Cust.Code"
        cl(3) = ""
        For i = 0 To 2
            Dim dc As New Data.DataColumn
            dc.ColumnName = cl(i)
            dt.Columns.Add(dc)
        Next
        i = 3
        j = Year(Me.CldFrom.SelectedDate) & Right("0" & Month(Me.CldFrom.SelectedDate), 2)
        dat = Me.CldFrom.SelectedDate
        While j <= Year(Me.CldTo.SelectedDate) & Right("0" & Month(Me.CldTo.SelectedDate), 2)
            
            cl(i) = Left(Trim(MonthName(Right(j, 2))), 3) & Mid(j, 3, 2) & "Qty(Unit)"
            cl(i + 1) = Trim(j)

            Dim dc As New Data.DataColumn
            Dim dc2 As New Data.DataColumn
            dc.ColumnName = cl(i)
            dc2.ColumnName = cl(i + 1)
            dt.Columns.Add(dc)
            dt.Columns.Add(dc2)
            i = i + 2
            dat = DateAdd(DateInterval.Month, 1, dat)
            j = Year(dat) & Right("0" & Month(dat), 2)
        End While

        obj.opencn()

        qry = "exec miserp.reportdb.dbo.JCT_Cust_Activity_Chart '" & Me.CldFrom.SelectedDate & "','" & Me.CldTo.SelectedDate & "','" & Trim(Me.DrpSalePer.Text) & "','" & Trim(Me.DrpCust.Text) & "'"
        cmd = New SqlCommand(qry, obj.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        'Dim i As Integer
        'cl(0) = "Sale Person"
        'cl(1) = "Customer Name"
        'cl(2) = "Cust.Code"
        'cl(3) = ""
        'For i = 0 To 2
        '    Dim dc As New Data.DataColumn
        '    dc.ColumnName = cl(i)
        '    dt.Columns.Add(dc)
        'Next
        i = 0
        If dr.HasRows = True Then
            While dr.Read()
                If sp <> Trim(dr.Item(0)) And cust <> Trim(dr.Item(1)) Then
                    drow = dt.NewRow()
                    drow2 = dt.NewRow()
                    dt.Rows.Add(drow)
                    dt.Rows.Add(drow2)
                    drow(0) = Trim(dr.Item(0))
                    drow(1) = Trim(dr.Item(1))
                    drow(2) = Trim(dr.Item(2))
                    sp = Trim(dr.Item(0))
                    cust = Trim(dr.Item(1))

                ElseIf cust <> Trim(dr.Item(1)) Then
                    drow = dt.NewRow()
                    drow2 = dt.NewRow()
                    dt.Rows.Add(drow)
                    dt.Rows.Add(drow2)
                    drow(1) = Trim(dr.Item(1))
                    drow(2) = Trim(dr.Item(2))
                    cust = Trim(dr.Item(1))
                End If
                For i = 3 To dt.Columns.Count - 1 Step 2
                    If UCase(Trim(dr.Item(4)) & "Qty(Unit)" & Trim(dr.Item(3))) = UCase(Trim(cl(i)) & Trim(cl(i + 1))) Then
                        Exit For
                    End If
                Next
                'If i >= dt.Columns.Count Then
                '    cl(i) = Trim(dr.Item(4)) & "Qty(Unit)"
                '    cl(i + 1) = Trim(dr.Item(3))
                '    Dim dc As New Data.DataColumn
                '    Dim dc2 As New Data.DataColumn
                '    dc.ColumnName = cl(i)
                '    dc2.ColumnName = cl(i + 1)
                '    dt.Columns.Add(dc)
                '    dt.Columns.Add(dc2)
                'End If

                drow(i) = Round(dr.Item(5), 0)
                drow(i + 1) = Round(dr.Item(7), 0)
                drow2(i) = "(" & Trim(dr.Item(6)) & ")"
                drow2(i + 1) = "(" & Round(dr.Item(8), 4) & ")"
            End While
        End If

        GridView1.DataSource = dt
        'Dim bcl As BoundField = New BoundField()
        'Dim b As BoundColumn = New BoundColumn()
        'GridView1.AutoGenerateColumns = False
        'bcl.DataField = "c1"
        'bcl.SortExpression = "c1"
        'bcl.DataField = "c1"
        'bcl.SortExpression = "c1"

        GridView1.DataBind()
        'Me.GridView1.Columns(0).SortExpression = "c1"
        dr.Close()
        obj.closecn()

    End Sub

    
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            'For i = 0 To e.Row.Cells.Count - 1
            For Each cell As TableCell In e.Row.Cells
                If IsNumeric(cell.Text) Then cell.Text = "Amt.(Cont)"
                ' Me.GridView1.Columns(i).HeaderText = ""
            Next
        End If

    End Sub



    
    Protected Sub cmdExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        GridViewExportUtil.Export("Customers.xls", Me.GridView1)
    End Sub
End Class
