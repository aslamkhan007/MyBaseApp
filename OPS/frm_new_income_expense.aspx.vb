Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting

Partial Class frm_new_income_expense
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
    Dim sum As Decimal = 0
    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        'Dim Sqlpass As String
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_ops_act_gl_expense_income '" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "','" & ddlincexp.SelectedItem.Text & "','" & ddlelement.SelectedItem.Text & "','" & ddlccname.SelectedItem.Text & "' ,'" & ddllocation.SelectedItem.Text & "'"
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
   
    Protected Sub grdGrid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sum = sum + Decimal.Parse(e.Row.Cells(5).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(2).Text = "Total"
            e.Row.Cells(5).Text = sum / 2
        End If
    End Sub

    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
    End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        'Sqlpass = "SELECT  Type 'GroupName',location 'Location',fs_account_no 'AccountCode',pay_description 'CostCenter',element_descp 'Group',convert(numeric(15,2),sum(fs_post_amt))'Amount' FROM jct_ops_gl_exp_inc where fs_tran_date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and type = '" & ddlincexp.SelectedItem.Text & "'  and (element_descp =  '" & ddlelement.SelectedItem.Text & "' or '" & ddlelement.SelectedItem.Text & "' = '') and (pay_description =  '" & ddlccname.SelectedItem.Text & "' or '" & ddlccname.SelectedItem.Text & "' = '') and (location =  '" & ddllocation.SelectedItem.Text & "' or '" & ddllocation.SelectedItem.Text & "' = '') group by  type,location,fs_account_no,pay_description,element_descp  order by type,location,fs_account_no,pay_description,element_descp "
        Sqlpass = "SELECT  Type 'GroupName',location 'Location',fs_account_no 'AccountCode',pay_description 'CostCenter',element_descp 'Group',convert(numeric(15,2),fs_post_amt)'Amount' FROM jct_ops_gl_exp_inc where fs_tran_date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and type = '" & ddlincexp.SelectedItem.Text & "'  and (element_descp =  '" & ddlelement.SelectedItem.Text & "' or '" & ddlelement.SelectedItem.Text & "' = '') and (pay_description =  '" & ddlccname.SelectedItem.Text & "' or '" & ddlccname.SelectedItem.Text & "' = '') and (location =  '" & ddllocation.SelectedItem.Text & "' or '" & ddllocation.SelectedItem.Text & "' = '') order by type,location,fs_account_no,pay_description,element_descp "
        obj2.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click

        GridViewExportUtil.Export("inc_exp.xls", Me.grdGrid1)

    End Sub
    Public Sub group()
        Dim SqlPass As String = "select distinct ma_element_sdesc  from miserp.mac.dbo.mac_cost_element   order by ma_element_sdesc"
        Dim Dr As SqlDataReader = obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                Me.ddlelement.Items.Clear()
                ddlelement.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlelement.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try

    End Sub

    Public Sub costcenter()
        Dim SqlPass As String = "select distinct ma_center_sdesc   from   miserp.mac.dbo.mac_cost_center   order by ma_center_sdesc"
        Dim Dr As SqlDataReader = obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                Me.ddlccname.Items.Clear()
                ddlccname.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlccname.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            group()
            costcenter()
        End If
    End Sub
End Class

