Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class OPS_frm_ims_current_stock
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass, sno2 As String
    Public obj As New HelpDeskClass
    Dim Ash, sno1 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Not IsPostBack Then

            ''txt_tranno.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btn_enter.UniqueID + "').click();return false;}} else {return true}; ")
            'txt_tranno.Attributes.Add("onkeypress", "return clickButton(event,'" + btn_enter.ClientID + "')")


            ''-----Fill Warehouse Combo Box
            'sqlpass = "select distinct a.wh_no " & _
            '        "from miserp.common.dbo.ims_warehouse_master a " & _
            '        "where ltrim(rtrim(a.company_no)))='" & LTrim(RTrim(Session("Companycode"))) & "' " & _
            '        "order by a.wh_no "

            'obj.opencn()
            'cmd = New SqlCommand(sqlpass, obj.cn)
            'dr = cmd.ExecuteReader

            'If dr.HasRows = True Then
            '    While dr.Read
            '        Me.ddl_warehouse.Items.Add(dr.Item(0))
            '    End While
            '    Me.ddl_warehouse.SelectedIndex = 0
            'Else
            '    FMsg.Message = "Warehouse not defined in Master file"
            '    FMsg.CssClass = "errormsg"
            '    FMsg.Display()
            '    Me.ddl_warehouse.Focus()
            '    dr.Close()
            '    Exit Sub
            'End If
            'dr.Close()
            'obj.closecn()
            Me.ddl_warehouse.Items.Add("JCTMNSTR")


            ''-----Fill Zone Combo Box
            sqlpass = "select distinct a.zone_no " & _
                    "from miserp.common.dbo.ims_zone_master a " & _
                    "where ltrim(rtrim(a.wh_no)) = '" & LTrim(RTrim(Me.ddl_warehouse.Text)) & "' " & _
                    "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' " & _
                    "order by a.zone_no "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_zone.Items.Add(dr.Item(0))
                End While
                Me.ddl_zone.Items.Add("ALL")
                Me.ddl_zone.SelectedIndex = 0
            Else
                'FMsg.Message = "Zone not defined in Master file"
                'FMsg.CssClass = "errormsg"
                'FMsg.Display()
                'Me.ddl_zone.Focus()
                'dr.Close()
                'Exit Sub
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Bin Combo Box
            sqlpass = "select distinct a.bin_no " & _
                    "from miserp.common.dbo.ims_bin_master a " & _
                    "where ltrim(rtrim(a.wh_no)) = '" & LTrim(RTrim(Me.ddl_warehouse.Text)) & "' " & _
                    "and ltrim(rtrim(a.zone_no)) = '" & LTrim(RTrim(Me.ddl_zone.Text)) & "' " & _
                    "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' " & _
                    "order by a.bin_no "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_bin.Items.Add(dr.Item(0))
                End While
                Me.ddl_bin.Items.Add("ALL")
                Me.ddl_bin.SelectedIndex = 0
            Else
                'FMsg.Message = "Bin not defined in Master file"
                'FMsg.CssClass = "errormsg"
                'FMsg.Display()
                'Me.ddl_bin.Focus()
                'dr.Close()
                'Exit Sub
            End If
            dr.Close()
            obj.closecn()

        End If

    End Sub

    Protected Sub ddl_warehouse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_warehouse.SelectedIndexChanged

        Me.ddl_zone.Items.Clear()

        ''-----Fill Zone Combo Box
        sqlpass = "select distinct a.zone_no " & _
                "from miserp.common.dbo.ims_zone_master a " & _
                "where ltrim(rtrim(a.wh_no)) = '" & LTrim(RTrim(Me.ddl_warehouse.Text)) & "' " & _
                "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' " & _
                "order by a.zone_no "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            While dr.Read
                Me.ddl_zone.Items.Add(dr.Item(0))
            End While
            Me.ddl_zone.Items.Add("ALL")
            Me.ddl_zone.SelectedIndex = 0
        Else
            FMsg.Message = "Zone not defined in Master file"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_zone.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()




        Me.ddl_bin.Items.Clear()

        ''-----Fill Bin Combo Box
        sqlpass = "select distinct a.bin_no " & _
                "from miserp.common.dbo.ims_bin_master a " & _
                "where ltrim(rtrim(a.wh_no)) = '" & LTrim(RTrim(Me.ddl_warehouse.Text)) & "' " & _
                "and ltrim(rtrim(a.zone_no)) = '" & LTrim(RTrim(Me.ddl_zone.Text)) & "' " & _
                "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' " & _
                "order by a.bin_no "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            While dr.Read
                Me.ddl_bin.Items.Add(dr.Item(0))
            End While
            Me.ddl_bin.Items.Add("ALL")
            Me.ddl_bin.SelectedIndex = 0
        Else
            FMsg.Message = "Bin not defined in Master file"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_bin.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub ddl_zone_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_zone.SelectedIndexChanged

        Me.ddl_bin.Items.Clear()

        ''-----Fill Bin Combo Box
        If UCase(LTrim(RTrim(Me.ddl_zone.Text))) <> "ALL" Then
            sqlpass = "select distinct a.bin_no " & _
                    "from miserp.common.dbo.ims_bin_master a " & _
                    "where ltrim(rtrim(a.wh_no)) = '" & LTrim(RTrim(Me.ddl_warehouse.Text)) & "' " & _
                    "and ltrim(rtrim(a.zone_no)) = '" & LTrim(RTrim(Me.ddl_zone.Text)) & "' " & _
                    "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' " & _
                    "order by a.bin_no "
        Else
            sqlpass = "select distinct a.bin_no " & _
                    "from miserp.common.dbo.ims_bin_master a " & _
                    "where ltrim(rtrim(a.wh_no)) = '" & LTrim(RTrim(Me.ddl_warehouse.Text)) & "' " & _
                    "/*and ltrim(rtrim(a.zone_no)) = '" & LTrim(RTrim(Me.ddl_zone.Text)) & "'*/ " & _
                    "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' " & _
                    "order by a.bin_no "
        End If


        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            While dr.Read
                Me.ddl_bin.Items.Add(dr.Item(0))
            End While
            Me.ddl_bin.Items.Add("ALL")
            Me.ddl_bin.SelectedIndex = 0
        Else
            FMsg.Message = "Bin not defined in Master file"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_bin.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub lnk_fetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_fetch.Click


        ''-----Item Code Validation check
        If LTrim(RTrim(Me.txt_itemcode.Text)) <> "" Then

            sqlpass = "select distinct a.stock_no " & _
                    "from miserp.common.dbo.ims_stock_master a " & _
                    "where ltrim(rtrim(a.stock_no)) = '" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                    "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = False Then
                FMsg.Message = "Invalid Item code"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_itemcode.Focus()
                dr.Close()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()

        End If

        If LTrim(RTrim(Me.txt_itemcode.Text)) <> "" And LTrim(RTrim(Me.txt_variant.Text)) <> "" Then

            ''-----Variant Validation check
            sqlpass = "select distinct a.variant_no " & _
                    "from miserp.common.dbo.ims_variant_master a " & _
                    "where ltrim(rtrim(a.stock_no)) = '" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                    "and ltrim(rtrim(a.variant_no)) = '" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                    "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = False Then
                FMsg.Message = "Invalid Variant"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_variant.Focus()
                dr.Close()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()

        End If

        If LTrim(RTrim(Me.txt_itemcode.Text)) = "" And LTrim(RTrim(Me.txt_variant.Text)) <> "" Then
            FMsg.Message = "Pl. enter Item Code/Variant"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If

        obj.opencn()

        ''Dim Sqlpass = "exec jct_pp_required_material_fetch '" & Me.ddl_yearmonth.Text & "','" & Me.ddl_revno.Text & "','" & UCase(LTrim(RTrim(Session("empcode")))) & "','" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

        sqlpass = "exec jct_ops_items_movement_before_transaction_report '" & RTrim(Me.txt_itemcode.Text) & "','" & _
                    LTrim(RTrim(Me.txt_variant.Text)) & "','" & _
                    LTrim(RTrim(Me.ddl_warehouse.Text)) & "','" & _
                    LTrim(RTrim(Me.ddl_zone.Text)) & "','" & _
                    LTrim(RTrim(Me.ddl_bin.Text)) & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "'"


        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()
        Catch ex As Exception
            obj.closecn()
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try

    End Sub

    Protected Sub txt_itemcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_itemcode.TextChanged

        ''-----Item Code Validation check
        sqlpass = "select distinct a.stock_no " & _
                "from miserp.common.dbo.ims_stock_master a " & _
                "where ltrim(rtrim(a.stock_no)) = '" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = False Then
            FMsg.Message = "Invalid Item code"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_itemcode.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub txt_variant_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_variant.TextChanged

        ''-----Variant Validation check
        sqlpass = "select distinct a.variant_no " & _
                "from miserp.common.dbo.ims_variant_master a " & _
                "where ltrim(rtrim(a.stock_no)) = '" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                "and ltrim(rtrim(a.variant_no)) = '" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                "and ltrim(rtrim(a.company_no))='" & LTrim(RTrim(Session("Companycode"))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = False Then
            FMsg.Message = "Invalid Variant"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_variant.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub lnk_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_excel.Click

        GridViewExportUtil.Export("current_stock.xls", Me.GridView1)
        'Dim filename As String = LTrim(RTrim(Me.ddl_reporttype.Text)) + "_" + Right(RTrim(Me.ddl_yearmonth.Text), 6) + "-" + LTrim(RTrim(Me.ddl_revno.Text)) + ".xls"
        'GridViewExportUtil.Export(filename, Me.GridView1)

    End Sub

    Protected Sub lnk_close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

End Class
