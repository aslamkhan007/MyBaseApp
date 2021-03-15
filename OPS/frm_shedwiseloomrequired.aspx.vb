Imports System.Data
Imports System.Data.SqlClient
Partial Class frm_shedwiseloomrequired
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim obj As New Connection
    Dim obj2 As New Functions
    Dim sqlpass, sno2 As String
    Dim scrpt_str As String
    Dim Ash, sno1 As Integer
    Public CstModule As New CostModule
    Dim order_no, order_qty, location As String

    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        'Dim Sqlpass As String
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_ops_pp_shedwise_looms_required '" & Right(ddlyrmth.Text, 6) & "','" & ddlshed.SelectedItem.Text & "', '" & ddlsaleteam.SelectedItem.Text & "','" & ddlsaleperson.SelectedItem.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        sqlpass = ""
        BindData1()
    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            yearmonth()
            saleteam()
            saleperson()
        End If
    End Sub

    Protected Sub grdGrid1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowCreated
        'e.Row.Cells(2).Width = "1000px"
    End Sub
    Protected Sub grdGrid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Dim status As String = DataBinder.Eval(e.Row.DataItem, "Status")
            'If Trim(status) = "D" Then
            '    ' color the forecolor of the row red
            '    e.Row.ForeColor = Drawing.Color.Red
            'End If
        End If
    End Sub
    Protected Sub grdGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGrid1.SelectedIndexChanged
        'Session("sql") = ""
        ''Session("sql") = "select fs_stock_no as [Stock No.],fs_stock_variant [Variant],Price,convert(varchar(12),fs_tran_Date) as [Tran Date],current_mkt_price as [Current Mkt Price],convert(varchar(12),purchase_date) as [Current Mkt Price Date],fs_uom as [UOM],vendor_no as [Vendor No.],vendor_name as [Vendor Name],account_no as [Account No.] from  jct_cst_raw_material_price_master where status<>'D' and fs_stock_no='" & grdGrid.SelectedRow.Cells(1).Text & "' and fs_stock_variant='" & grdGrid.SelectedRow.Cells(2).Text & "' and company_code='" & Session("Companycode") & "' order by fs_stock_no "
    End Sub
    'for show paging no in grid result 
    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        'Dim Sqlpass As String
        'Sqlpass = "SELECT section_code,loom_no,loom_size,sort_no,day1,day2,day3,day4,day5,day6,day7,day8,day9,day10,day11,day12,day13,day14,day15,day16,day17,day18,day19,day20,day21,day22,day23,day24,day25,day26,day27,day28,day29,day30,day31   FROM jct_pp_shed_wise_looms_available where monthyr = '" & yrmth.Text & "' and  ( (location = '" & ddlshed.Text & "' or '" & ddlshed.Text & "' = 'ALL') order by shed,loom_no "
        'obj2.FillGrid(Sqlpass, grdGrid1)
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
        'Me.grdGrid1.SelectedIndex = -1
    End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        Sqlpass = "SELECT shade_name 'Shed',sale_person 'SalePerson',order_no 'OrderNo',item_no 'SortNo', plan_qty 'Qty', alloted_looms 'Alloted_looms', wvgcompletiondays 'Tentative_Wvg_Days' FROM jct_ops_pp_shedwise_looms_alloted  where yearmonth = '" & Right(ddlyrmth.Text, 6) & "' and  (shade_name = '" & ddlshed.SelectedItem.Text & "'or '" & ddlshed.SelectedItem.Text & "' = '') and (team_code = '" & ddlsaleteam.SelectedItem.Text & "' or '" & ddlsaleteam.SelectedItem.Text & "' = ' ')  and (sale_person = '" & ddlsaleperson.SelectedItem.Text & "' or '" & ddlsaleperson.SelectedItem.Text & "' = ' ')  order by shade_name,sale_person "
        CstModule.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
        'Try
        GridViewExportUtil.Export("shedwise_loomprog.xls", Me.grdGrid1)
        'Catch ex As Exception

        'MsgBox(ex.Message)
        ' End Try

    End Sub

    Public Sub yearmonth()
        sqlpass = "select distinct yearmonth from dbo.JCT_OPS_MONTHLY_PLANNING  where mode = 'Freezed' order by yearmonth"
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlyrmth.Items.Clear()
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlyrmth.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
            Dr.Close()
        End Try
        'CstModule.FillGrid(sqlpass, grdGrid1)
    End Sub
    Public Sub saleteam()
        sqlpass = "select distinct team_description from MISERP.SOM.DBO.jct_team_master order by team_description "
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlsaleteam.Items.Clear()
                ddlsaleteam.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlsaleteam.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try

    End Sub

    Public Sub saleperson()
        sqlpass = "select distinct b.group_desc from MISERP.SOM.DBO.jct_team_saleperson_mapping a,miserp.som.dbo.m_cust_group b where a.status  ='O' and   a.sale_person_code =  b.group_no and   b.group_type  ='SALESP' and b.status <>'D'  order by b.group_desc "
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlsaleperson.Items.Clear()
                ddlsaleperson.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlsaleperson.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try

    End Sub
    Protected Sub ddlyrmth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlyrmth.SelectedIndexChanged
       
    End Sub
 
    'graph 

End Class

