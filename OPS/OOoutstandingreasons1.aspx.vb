Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Imports System.Net.Mail

Partial Class OPS_outstandingreasons1
    Inherits System.Web.UI.Page
    Dim Qry, Sql As String
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim Sm As SendMail = New SendMail()
    Dim Dr As SqlDataReader

    Dim dt As New Data.DataTable
    Dim sqlpass As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Custname As String, SalePerson As String

        ' 1) for saleperson code & name 

        Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
        'ObjFun.FillList(ddlsaleperson, Qry)

        If Not IsPostBack Then
            Dim cl(5) As String
            Dim k As Integer
            cl(0) = "Reason"
            cl(1) = "Date"
            cl(2) = "Amount"
            cl(3) = "Dr/Cr"
            cl(4) = "Remarks"

            For k = 0 To 4
                Dim dc As New Data.DataColumn
                dc.ColumnName = cl(k)
                dt.Columns.Add(dc)
            Next
            ViewState("dt") = dt

            ''-----Fill Action Combo Box
            'sqlpass = "select b.action,b.mnuname,b.description,parent_menu,case b.action when 'ADD' then '1' when 'MODIFY' then '2' when 'VIEW' then '3' when 'AUTHORIZE' then '4' end /*b.seq*/ " & _
            '    " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
            '    " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
            '    " inner join production..role_user_mapping e on a.role=e.role " & _
            '    " where a.module ='OPS' and e.uname='" & Session("empcode") & "' " & _
            '    "and a.mnuname='Outstanding Reasons' and a.action<>'Load'" & _
            '    " order by b.parent_menu,b.mnuname,case b.action when 'ADD' then '1' when 'MODIFY' then '2' when 'VIEW' then '3' when 'AUTHORIZE' then '4' end /*b.seq*/ "

            'Obj.ConOpen()
            'Dim Cmd As SqlCommand
            'Cmd = New SqlCommand(sqlpass, Obj.Connection)
            'Dr = Cmd.ExecuteReader

            'If Dr.HasRows = True Then
            '    While Dr.Read
            '        Me.ddl_action.Items.Add(Dr.Item(0))
            '    End While
            '    Me.ddl_action.SelectedIndex = 0
            'End If
            'Dr.Close()
            'Obj.ConClose()



        End If

        If Not IsPostBack Then
            grdbnd()

            If Session("EmpCode") = "M-02504" Or Session("EmpCode") = "M-02521" Or Session("EmpCode") = "M-02711" Or Session("EmpCode") = "S-13738" Or Session("EmpCode") = "A-00217" Then

                GridView1.Visible = True
                GridView2.Visible = False

            Else  'If Session("EmpCode") = "R-03584" Then

                'GridView1.Visible = True
                GridView2.Visible = True

                Qry = "EXEC jct_ops_outstanding_reasons_FETCH_ADD_mktg_remarks '" & Session("EmpCode") & "' "
                'Qry = "EXEC jct_ops_outstanding_reasons_FETCH_ADD_mktg_remarks"
                ObjFun.FillGrid(Qry, GridView2)

            End If
        End If

        '' 2) for customer name on selection of saleperson 
        'If ddlsaleperson.SelectedItem.Text = "" Then
        '    SalePerson = ""
        'Else
        '    SalePerson = ddlsaleperson.SelectedItem.Value
        'End If

        'If SalePerson <> "" Then
        '    Qry = "SELECT ' ' as custname union select custname FROM miserp.shp.dbo.combine_invoice_ops_detail (Nolock) where outstanding_amt >0 and salepersoncode = SalePerson"
        '    txtcustomer.Text = ObjFun.FetchValue(Sql)
        'Else
        '    Qry = "SELECT ' ' as custname union select custname FROM miserp.shp.dbo.combine_invoice_ops_detail (Nolock) where outstanding_amt >0  "
        '    txtcustomer.Text = ObjFun.FetchValue(Sql)
        'End If

        ' 3) for selectiong outstanding invoice  ( with saleperson & customer) 

        'If txtcustomer.Text = "" Then
        '    Custname = ""
        'Else
        '    Custname = txtcustomer.Text
        'End If

        'If Custname <> "" Then
        '    Qry = "SELECT invoice_no FROM miserp.shp.dbo.combine_invoice_ops_detail (Nolock) where outstanding_amt >0  and custname = '" + Custname + "'"
        '    txtinvoice.Text = ObjFun.FetchValue(Qry)
        'Else
        '    Qry = "SELECT invoice_no FROM miserp.shp.dbo.combine_invoice_ops_detail (Nolock) where outstanding_amt >0 "
        '    txtinvoice.Text = ObjFun.FetchValue(Qry)
        'End If
    End Sub

    Protected Sub lnkfetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkfetch1.Click


        If LTrim(RTrim(Me.txtinvoice.Text)) = "" Then
            Fmsg.Message = "Pl. Select Invoice No "
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Me.txtinvoice.Focus()
            Exit Sub
        End If

        'If Me.ddl_action.Text = "ADD" Then
        Dim Cmd As SqlCommand
        Qry = "select invoice_no, invoice_dt,frt_amt,invoice_net_amt as invoice_amt,outstanding_amt from miserp.shp.dbo.combine_invoice_ops_detail where    isnull(outstanding_amt,0) > 0 and ( invoice_no='" + txtinvoice.Text + "' or '" + txtinvoice.Text + "'='') and invoice_no not in ( select distinct invoice_no from jct_ops_outstanding_invoice_reasons where invoice_no = '" + txtinvoice.Text + "' or '" + txtinvoice.Text + "'='') "
        Cmd = New SqlCommand(Qry, Obj.Connection)
        Dr = Cmd.ExecuteReader
        Dr.Read()
        If Dr.HasRows Then
            txtinvoice.Text = Dr.Item("invoice_no")
            txtinvdate.Text = Dr.Item("invoice_dt")
            txtfreight.Text = Math.Round(Dr.Item("frt_amt"), 2)
            txtinvamt.Text = Math.Round(Dr.Item("invoice_amt"), 2)
            txtoutstanding.Text = Math.Round(Dr.Item("outstanding_amt"), 2)
        Else
            Fmsg.Message = "Invalid Invoice or Invoice Already Exist"
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Dr.Close()
            Obj.ConClose()
        End If
        Me.txtinvoice.Focus()
        ' End If

    End Sub

    Protected Sub Lnkclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    ' for show grid at page load

    Sub grdbnd()

        '  If Me.ddl_action.Text = "ADD" Then

        sqlpass = " select 'CD' 'Reason',Convert(varchar(12), getdate(), 101) 'Date', 0.00 'Amount', 'Dr' 'Dr/Cr', '' 'Remarks'"
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter(sqlpass, Obj.Connection)
        adp.Fill(ds)
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()
        ViewState("dt") = ds.Tables(0)

        '  End If

    End Sub

    Protected Sub GridView1_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBinding

    End Sub

    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

    '    Dim CustCode As String, SalePerson As String, invoice As String

    '    If txtcustomer.Text = "" Then
    '        CustCode = ""
    '    Else
    '        CustCode = Right(txtcustomer.Text, Len(txtcustomer.Text) - InStr(txtcustomer.Text, "~")) 'txtCustomer.Text
    '    End If
    '    If ddlsaleperson.SelectedItem.Text = "" Then
    '        SalePerson = ""
    '    Else
    '        SalePerson = Trim(ddlsaleperson.SelectedItem.Value)
    '    End If

    '    If txtinvoice.Text = "" Then
    '        invoice = ""
    '    Else
    '        invoice = txtinvoice.Text
    '    End If

    '    If e.CommandName = "saveactreason" Then
    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex

    '            Dim ID As String = GridView1.Rows(rowIndex).Cells(4).Text
    '            Dim Reason As TextBox = DirectCast(GridView1.Rows(rowIndex).FindControl("ddlreason"), TextBox)
    '            Dim ReasonDate As TextBox = DirectCast(GridView1.Rows(rowIndex).FindControl("txtdate"), TextBox)
    '            Dim Amount As DropDownList = DirectCast(GridView1.Rows(rowIndex).FindControl("txtamount"), DropDownList)
    '            Dim Drcr As TextBox = DirectCast(GridView1.Rows(rowIndex).FindControl("ddldrcr"), TextBox)


    '            Qry = "insert into jct_ops_outstanding_invoice_reasons ( invoice_no,basic_amt,freight_amt,invoice_net_amt,outstanding_amt,SalePersonCode,CustNo,act_reason_descrp,act_reason_date,act_reason_amount,act_reason_drcr,act_comment_date,wip_status,inv_out_status,sale_reason_remarks,sale_reason_dt,sale_comment_date,party_act_adjust_dt,Host_name) select  invoice_no, basic_amt, frt_amt ,invoice_net_amt ,outstanding_amt , SalePerson , CustCode ,  Reason  , ReasonDate ,Amount , Drcr , getdate(),'A',' ', ' ',null,null,null, '" & Session("Empcode") & "' ) from miserp.shp.dbo.combine_invoice_ops_detail where outstanding_amt >0 and invoice_no = '" & txtinvoice.Text & "' "
    '            Cmd = New SqlCommand(Qry, Obj.Connection)
    '            Cmd.ExecuteNonQuery()

    '            Dim body As String = "<p>Hello ,</p> <p> The Outstansing Comments are put by Account Section. Please do the needful at your end now. Details of the request are as follows : </p> </p> <H3>Customer :" + Customer + "</H3> </p> <p> <H3> Item No :" + invoice + "+ </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
    '            Sm.SendMail("rajan@jctltd.com", "noreply@jctltd.com", "Outstanding Comments From Accounts", body)

    '        Catch ex As Exception
    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '        End Try
    '    End If
    'End Sub




    'Protected Sub txtcustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcustomer.TextChanged

    '    txtcustomer.Text = txtcustomer.Text.Split("~")(1).ToString()

    'End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    ' for insert row in grid 

    Protected Sub imb_insertrow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_insertrow.Click

        dt = ViewState("dt")
        dt.Rows.Clear()
        Dim rw As Data.DataRow

        For i As Integer = 0 To Me.GridView1.Rows.Count - 1
            rw = dt.NewRow
            rw("Reason") = CType(GridView1.Rows(i).FindControl("ddlreason"), DropDownList).SelectedItem.Text
            rw("Date") = CType(GridView1.Rows(i).FindControl("txtdate"), TextBox).Text
            rw("Amount") = CType(GridView1.Rows(i).FindControl("txtamount"), TextBox).Text
            rw("Dr/Cr") = CType(GridView1.Rows(i).FindControl("ddldrcr"), DropDownList).SelectedItem.Text
            rw("Remarks") = CType(GridView1.Rows(i).FindControl("txtremarks"), TextBox).Text
            dt.Rows.Add(rw)
        Next
        Dim rw1 As Data.DataRow
        rw1 = dt.NewRow
        rw1("Reason") = "CD"
        ' format for given date value rajan 
        'rw1("Date") = "02/01/2013"
        rw1("Date") = Date.Now.ToString("MM/dd/yyyy")
        rw1("Amount") = "0.00"
        rw1("Dr/Cr") = "Dr"
        rw1("Remarks") = ""
        dt.Rows.Add(rw1)
        Me.GridView1.DataSource = dt
        Me.GridView1.DataBind()

    End Sub

    ' action true/falese on followings actions 
    'Protected Sub ddl_action_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_action.SelectedIndexChanged

    '    Me.lbt_add.Text = "ADD"
    '    Me.lbt_modify.Text = "MODIFY"
    '    Me.lbt_view.Text = "VIEW"
    '    Me.lbt_authorize.Text = "AUTHORIZE"
    '    Me.lbt_delete.Text = "DELETE"

    '    If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then

    '        If Me.lbt_add.Text = "ADD" Then


    '            Me.txtinvoice.Enabled = True
    '            Me.txt_tranno.Enabled = False


    '            Me.GridView1.DataSource = Nothing
    '            GridView1.DataBind()

    '            Me.lnkfetch1.Enabled = True
    '            Me.Lnkclose.Enabled = True

    '            Me.imb_insertrow.Enabled = True
    '            Me.imb_tran_fetch.Enabled = False





    '            Me.lbt_add.Text = "SAVE"

    '        ElseIf Me.lbt_add.Text = "SAVE" Then

    '            Me.ddl_action.SelectedIndex = 0
    '            Me.lbt_apply_Click(sender, e)

    '        End If
    '    End If


    '    If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then
    '        If Me.lbt_modify.Text = "MODIFY" Then


    '            Me.txtinvoice.Enabled = True
    '            Me.txt_tranno.Enabled = True


    '            Me.GridView1.DataSource = Nothing
    '            GridView1.DataBind()

    '            Me.lnkfetch1.Enabled = True
    '            Me.Lnkclose.Enabled = True

    '            Me.imb_insertrow.Enabled = True
    '            Me.imb_tran_fetch.Enabled = True



    '            Me.lbt_modify.Text = "UPDATE"

    '        ElseIf Me.lbt_modify.Text = "UPDATE" Then

    '            Me.ddl_action.SelectedIndex = 1
    '            Me.lbt_apply_Click(sender, e)

    '        End If
    '    End If

    '    If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "VIEW" Then

    '        Me.txtinvoice.Enabled = False
    '        Me.txt_tranno.Enabled = True


    '        Me.GridView1.DataSource = Nothing
    '        GridView1.DataBind()

    '        Me.lnkfetch1.Enabled = False
    '        Me.Lnkclose.Enabled = False

    '        Me.imb_insertrow.Enabled = False
    '        Me.imb_tran_fetch.Enabled = True



    '    End If

    '    If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then
    '        If Me.lbt_authorize.Text = True Then

    '            Me.txtinvoice.Enabled = False
    '            Me.txt_tranno.Enabled = True


    '            Me.GridView1.DataSource = Nothing
    '            GridView1.DataBind()

    '            Me.lnkfetch1.Enabled = False
    '            Me.Lnkclose.Enabled = False

    '            Me.imb_insertrow.Enabled = False
    '            Me.imb_tran_fetch.Enabled = True

    '            Me.lbt_authorize.Text = "UPDATE"

    '        ElseIf lbt_authorize.Text = "UPDATE" Then

    '            Me.ddl_action.SelectedIndex = 3
    '            Me.lbt_apply_Click(sender, e)

    '        End If
    '    End If

    'End Sub


    'Protected Sub lbt_apply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_apply.Click
    '    Dim srno As Integer = 0

    '    If LTrim(RTrim(Me.txtinvoice.Text)) = "" Then

    '        Me.txtinvoice.Focus()
    '        Exit Sub
    '    End If


    '    Dim btran As SqlTransaction

    '    If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then

    '        Obj.ConOpen()

    '        sqlpass = "select tran_no,isnull(inv_out_status,'') from jct_ops_outstanding_invoice_reasons where invoice_no ='" & Me.txtinvoice.Text & "' and inv_out_status = 'O'"
    '        Dim Cmd As SqlCommand
    '        Cmd = New SqlCommand(sqlpass, Obj.Connection)
    '        Dr = Cmd.ExecuteReader

    '        If Dr.HasRows = True Then
    '            Dr.Read()
    '            Fmsg.Message = "Tran.No. " & Dr.Item(0) & " of above invoice already exists in OPEN status, Pl. first AUTHORIZE the Tran.No. "
    '            Fmsg.CssClass = "errormsg"
    '            Fmsg.Display()
    '            Dr.Close()
    '            Obj.ConClose()

    '            Me.txtinvoice.Focus()
    '            Exit Sub
    '        End If
    '        Dr.Close()
    '        Obj.ConClose()




    '        Obj.ConOpen()
    '        btran = Obj.Connection.BeginTransaction

    '        Try

    '            '--SERIAL NUMBER GENERATION

    '            sqlpass = "select isnull(count_value,0)+1,ltrim(rtrim(prefix))+" & _
    '             "case len(ltrim(rtrim(convert(char,isnull(count_value,0)+1)))) when 1 then '0000'" & _
    '             "when 2 then '000' when 3 then '00' when 4 then '0' end + ltrim(rtrim(convert(char,isnull(count_value,0)+1))) " & _
    '             "+ltrim(rtrim(suffix)) from jct_outstanding_serial_mumber_master   " & _
    '             "where convert(datetime,convert(char(12),getdate())) between convert(datetime,convert(char(12),eff_from)) and convert(datetime,convert(char(12),eff_to)) """

    '            Cmd = New SqlCommand(sqlpass, Obj.Connection)
    '            Cmd.Transaction = btran
    '            Dr = Cmd.ExecuteReader

    '            If Dr.HasRows = True Then
    '                Dr.Read()
    '                Me.txt_tranno.Text = Dr.Item(1)
    '                ViewState("TranNo") = Dr.Item(1)
    '            End If
    '            Dr.Close()

    '            Dim i As Integer = 0

    '            For i = 0 To GridView1.Rows.Count - 1
    '                sqlpass = "exec jct_invoice_outstanding_reason_entry " & _
    '                                     LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
    '                                     srno & ",'" & Now() & "','" & _
    '                                     LTrim(RTrim(Me.txt_tranno.Text)) & " ','" & _
    '                                     LTrim(RTrim(Me.txtinvoice.Text)) & "','" & _
    '                                     CType(GridView1.Rows(i).FindControl("ddlreason"), DropDownList).SelectedItem.Text & "','" & _
    '                                     CType(GridView1.Rows(i).FindControl("txtdate"), TextBox).Text & ",'" & _
    '                                     CType(GridView1.Rows(i).FindControl("txtamount"), TextBox).Text & ",'" & _
    '                                     CType(GridView1.Rows(i).FindControl("ddldrcr"), DropDownList).SelectedItem.Text & "'"""

    '                Cmd = New SqlCommand(sqlpass, Obj.Connection)
    '                Cmd.Transaction = btran
    '                Cmd.ExecuteNonQuery()

    '            Next

    '            btran.Commit()
    '            Dr.Close()
    '            Obj.ConClose()

    '            Fmsg.Message = "Success"
    '            Fmsg.CssClass = "addmsg"
    '            Fmsg.Display()

    '        Catch ex As Exception

    '            btran.Rollback()
    '            Dr.Close()
    '            Obj.ConClose()

    '            Fmsg.Message = (ex.Message)
    '            Fmsg.CssClass = "addmsg"
    '            Fmsg.Display()
    '            Me.lbt_close_Click(sender, e)
    '            Exit Sub

    '        End Try
    '    End If
    '    '------------- End of ADD mode ----------------

    '    If (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") Then
    '        Dim sysdate As Date

    '        If LTrim(RTrim(Me.txt_tranno.Text)) = "" Then
    '            Fmsg.Message = "Pl. enter valid Tran No."
    '            Fmsg.CssClass = "addmsg"
    '            Fmsg.Display()
    '            Me.txt_tranno.Focus()
    '            Exit Sub
    '        End If

    '        ''DELETION OF EXISTING TRANSACTION
    '        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then

    '            sqlpass = "select top 1 act_comment_date " & _
    '                            "from jct_ops_outstanding_invoice_reasons " & _
    '                            "where ltrim(rtrim(tran_no))='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
    '                            "and left(upper(ltrim(rtrim(inv_out_status))),1)='O' "" order by act_comment_date "
    '            Dim Cmd As SqlCommand
    '            Cmd = New SqlCommand(sqlpass, Obj.Connection)
    '            Cmd.Transaction = btran
    '            Dr = Cmd.ExecuteReader

    '            If Dr.HasRows = True Then
    '                Dr.Read()
    '                sysdate = Dr.Item(0)
    '            Else
    '                Fmsg.Message = "Invalid Tran. No."
    '                Fmsg.CssClass = "errormsg"
    '                Fmsg.Display()
    '                Dr.Close()
    '                Obj.ConClose()
    '                Me.txt_tranno.Focus()
    '                Exit Sub
    '            End If
    '            Dr.Close()


    '            sqlpass = "delete from jct_ops_outstanding_invoice_reasons " & _
    '                    "where ltrim(rtrim(tran_no))='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
    '                    "and left(upper(ltrim(rtrim(inv_out_status ))),1)='O' "" "

    '            Cmd = New SqlCommand(sqlpass, Obj.Connection)
    '            Cmd.Transaction = btran
    '            Cmd.ExecuteNonQuery()

    '        End If

    '        Dim i As Integer = 0

    '        For i = 0 To GridView1.Rows.Count - 1

    '            sqlpass = "exec jct_invoice_outstanding_reason_entry " & _
    '                                     LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
    '                                     srno & ",'" & sysdate & "','" & _
    '                                     LTrim(RTrim(Me.txt_tranno.Text)) & " ','" & _
    '                                     LTrim(RTrim(Me.txtinvoice.Text)) & "','" & _
    '                                     CType(GridView1.Rows(i).FindControl("ddlreason"), DropDownList).SelectedItem.Text & "','" & _
    '                                     CType(GridView1.Rows(i).FindControl("txtdate"), TextBox).Text & ",'" & _
    '                                     CType(GridView1.Rows(i).FindControl("txtamount"), TextBox).Text & ",'" & _
    '                                     CType(GridView1.Rows(i).FindControl("ddldrcr"), DropDownList).SelectedItem.Text & "'"""

    '        Next

    '        btran.Commit()
    '        Dr.Close()
    '        Obj.ConClose()

    '        ''''''''''Meaasage'''''''''''''
    '        Fmsg.Message = "Success"
    '        Fmsg.CssClass = "addmsg"
    '        Fmsg.Display()


    '    End If


    'End Sub

    Protected Sub imb_tran_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_tran_fetch.Click

        ' code for fetch records in case of modify / authorise uet to be added


        'If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "VIEW" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

        sqlpass = "select case isnull(a.inv_out_status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' end " & _
                      "from jct_ops_outstanding_invoice_reasons   a " & _
                      "where a.tran_no='" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "'"

        Obj.ConOpen()
        Dim Cmd As SqlCommand
        Cmd = New SqlCommand(sqlpass, Obj.Connection)
        Dr = Cmd.ExecuteReader

        If Dr.HasRows = False Then
            Dr.Read()

            Fmsg.Message = "Invalid Tran. No."
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Me.GridView1.DataSource = Nothing
            GridView1.DataBind()
            Me.txtinvoice.Text = ""
            Me.txt_tranno.Focus()
            Dr.Close()
            Obj.ConClose()

            Exit Sub
        End If
        Obj.ConClose()


        sqlpass = "select a.tran_no, a.invoice_no, " & _
                 "case isnull(a.inv_out_status ,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' end 'inv_out_status' " & _
                 "from jct_ops_outstanding_invoice_reasons  a " & _
                 "where a.tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                 "order by a.invoice_no "

        Obj.ConOpen()

        Cmd = New SqlCommand(sqlpass, Obj.Connection)
        Dr = Cmd.ExecuteReader

        If Dr.HasRows = True Then
            Dr.Read()
            Me.txtinvoice.Text = Dr.Item(1)
            ViewState("InvoiceNo") = Dr.Item(1)
            Dr.Close()
            Obj.ConClose()

            sqlpass = "exec jct_outstanding_fetch  '" & LTrim(RTrim(Me.txt_tranno.Text)) & "'"

            Obj.ConOpen()
            Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, Obj.Connection)
            Try

                Dim ds As DataSet = New DataSet()
                Da.Fill(ds)
                ViewState("dt") = ds.Tables(0)
                GridView1.DataSource = ds
                GridView1.DataBind()

            Catch ex As Exception
                Obj.ConClose()
                Fmsg.Message = (ex.Message)
                Fmsg.CssClass = "addmsg"
                Fmsg.Display()
            Finally
                Obj.ConClose()
            End Try
        End If
        Me.txt_tranno.Focus()
        'End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If (e.CommandName = "Remove") Then

            Dim gvr As GridViewRow = CType(CType(e.CommandSource, ImageButton).NamingContainer, GridViewRow)
            Dim Row As Integer = gvr.RowIndex
            Dim dt1 As DataTable = New DataTable()
            dt1 = CType(ViewState("dt"), DataTable)
            dt1.Rows.RemoveAt(Row)
            GridView1.DataSource = dt1
            GridView1.DataBind()
            ViewState("dt") = dt1

        End If

    End Sub
    Protected Sub lbt_close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_close.Click

        Response.Redirect("default.aspx")
        Me.Visible = False

    End Sub

    Protected Sub lbt_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_delete.Click

        'If lbt_delete.Text = "DELETE" Then

        '    Me.ddl_action.SelectedIndex = 4
        '    ddl_action_SelectedIndexChanged(sender, e)

        'End If

        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_close.Text = "CLOSE"

        'Me.ddl_action.SelectedIndex = 4
        'ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_modify.Click

        Me.lbt_add.Text = "ADD"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"

        Dim btran As SqlTransaction

        Dim sysdate As Date

        If LTrim(RTrim(Me.txt_tranno.Text)) = "" Then
            Fmsg.Message = "Pl.Enter Vaild Trans.No"
            Fmsg.CssClass = "addmsg"
            Fmsg.Display()
            Me.txt_tranno.Focus()
            Exit Sub
        End If
        btran = Obj.Connection.BeginTransaction

        ''DELETION OF EXISTING TRANSACTION
        'If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then

        sqlpass = "select top 1 act_comment_date from jct_ops_outstanding_invoice_reasons where ltrim(rtrim(tran_no))= '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' and   upper(ltrim(rtrim(inv_out_status))) ='O' "
        Dim Cmd As SqlCommand
        Cmd = New SqlCommand(sqlpass, Obj.Connection)
        Cmd.Transaction = btran
        Dr = Cmd.ExecuteReader

        If Dr.HasRows = True Then
            Dr.Read()
            sysdate = Dr.Item(0)
        Else
            Fmsg.Message = "Invalid TranNo./Authorise"
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Dr.Close()
            Obj.ConClose()
            Me.txt_tranno.Focus()
            Exit Sub
        End If
        Dr.Close()

        sqlpass = "delete from jct_ops_outstanding_invoice_reasons " & _
                      "where ltrim(rtrim(tran_no))='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                      "and left(upper(ltrim(rtrim(inv_out_status ))),1)='O'"

        Cmd = New SqlCommand(sqlpass, Obj.Connection)
        Cmd.Transaction = btran
        Cmd.ExecuteNonQuery()

        Dim i As Integer = 0

        For i = 0 To GridView1.Rows.Count - 1

            sqlpass = "exec jct_invoice_outstanding_modification  '" & LTrim(RTrim(Me.txt_tranno.Text)) & "', '" & LTrim(RTrim(Me.txtinvoice.Text)) & "','" & CType(GridView1.Rows(i).FindControl("ddlreason"), DropDownList).SelectedItem.Text & "','" & CType(GridView1.Rows(i).FindControl("txtdate"), TextBox).Text & "','" & CType(GridView1.Rows(i).FindControl("txtamount"), TextBox).Text & "','" & CType(GridView1.Rows(i).FindControl("ddldrcr"), DropDownList).SelectedItem.Text & "', '" & UCase(LTrim(RTrim(Session("empcode")))) & "','" & CType(GridView1.Rows(i).FindControl("txtremarks"), TextBox).Text & "' "
            Cmd = New SqlCommand(sqlpass, Obj.Connection)
            Cmd.Transaction = btran
            Cmd.ExecuteNonQuery()

        Next

        btran.Commit()
        Dr.Close()
        Obj.ConClose()

        ''''''''''Meaasage'''''''''''''
        Fmsg.Message = "Update"
        Fmsg.CssClass = "addmsg"
        Fmsg.Display()



    End Sub

    Protected Sub lbt_authorize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_authorize.Click
        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"
        Dim Cmd As SqlCommand
        If LTrim(RTrim(Me.txt_tranno.Text)) = "" Then
            Fmsg.Message = "Pl. Enter Vaild Trans.No "
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Me.txt_tranno.Focus()
            Exit Sub
        End If

        Obj.ConOpen()

        Try
            Dim i As Integer = 0

            For i = 0 To GridView1.Rows.Count - 1
                sqlpass = "exec jct_invoice_outstanding_authorise_entry '" & LTrim(RTrim(Me.txt_tranno.Text)) & "'"

                Cmd = New SqlCommand(sqlpass, Obj.Connection)

                Cmd.ExecuteNonQuery()
            Next

            Obj.ConClose()

            Fmsg.Message = "Trans.Authorised"
            Fmsg.CssClass = "addmsg"
            Fmsg.Display()

        Catch ex As Exception

            'Dr.Close()
            'Obj.ConClose()
            'Fmsg.Message = (ex.Message)
            'Fmsg.CssClass = "addmsg"
            'Fmsg.Display()
            'Me.lbt_close_Click(sender, e)

        End Try
        ' -------------------- Mail to concerned 
        Dim Customer, Invoice, invoicedate, outstanding As String

        Qry = "SELECT distinct custname,invoice_no,Convert(varchar(10),invoice_dt,103) 'invoice_dt',outstanding_amt FROM dbo.jct_ops_outstanding_invoice_reasons  WHERE tran_no = '" & LTrim(RTrim(Me.txt_tranno.Text)) & "'"

        Cmd = New SqlCommand(Qry, Obj.Connection())
        Dim dr As SqlDataReader = Cmd.ExecuteReader()
        If (dr.HasRows) Then
            While (dr.Read())
                Customer = dr("custname").ToString()
                Invoice = dr("invoice_no").ToString()
                invoicedate = dr("invoice_dt").ToString()
                outstanding = Math.Round(dr.Item("outstanding_amt"), 2)
            End While
        Else
            Customer = ""
            Invoice = ""
            invoicedate = ""
            outstanding = ""
            txtinvoice.Text = ""
        End If

        txtinvoice.Text = ""
        txt_tranno.Text = ""
        'Me.txtinvoice.Focus()

        'Grid intilized  
        Me.GridView1.DataSource = Nothing
        Me.GridView1.DataBind()
        dr.Close()

        ' ------------ for show blank row in grid 
        sqlpass = " select 'CD' 'Reason',Convert(varchar(12), getdate(), 101) 'Date', 0.00 'Amount', 'Dr' 'Dr/Cr', '' 'Remarks'"
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter(sqlpass, Obj.Connection)
        adp.Fill(ds)
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()
        ViewState("dt") = ds.Tables(0)
        ' ------------ end 

        ' mail goes to concerned sale executive 
        'Dim body As String = "<p>Hello ,</p> <p> The Invoice Outstanding Reasons Freezed by A/C Section.Please put remarks at your end now. Details are as follows : </p> </p> <H3>Customer :" + Customer + " </H3> </p> <p> <H3> InvoiceNo :" + Invoice + "</H3>  </p> <p><h3>InvoiceDt :" + invoicedate + " </h3></p><p><H3> Outstanding: " + outstanding + " </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
        'Sm.SendMail("rajan@jctltd.com", "noreply@jctltd.com", "Cancellation - Invoice Outstanding Reasons", body)
        SendMail()
        ' -------------------- End Mail generation 

    End Sub

    ' Send mail to multiple person
    Private Sub SendMail()
        Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String
        Dim sb As New StringBuilder()
        Dim email1, email2 As String

        ' Sql = " Select distinct b.e_mailid  from  dbo.jct_ops_outstanding_invoice_reasons a,  mistel b where a.invoice_no = (SELECT invoice_no FROM jct_ops_outstanding_invoice_reasons WHERE tran_no='" + txt_tranno.Text + "') and a.salepersoncode = Replace(b.empcode,'-','') "
        Sql = " select distinct b.e_mailid  from  dbo.jct_ops_outstanding_invoice_reasons a,  mistel b where a.invoice_no = '" & ViewState("InvoiceNo") & "' and a.salepersoncode = Replace(b.empcode,'-','') "
        'where empcode='" + FlagAuth + "'"
        If (ObjFun.CheckRecordExistInTransaction(Sql)) Then
            email1 = ObjFun.FetchValue(Sql)
            'email1 = "rajan@jctltd.com"
        Else
            email1 = "rajan@jctltd.com"
        End If

        Sql = "Select e_mailid from mistel where empcode = '" & Session("EmpCode") & "' "
        'where empcode='" + Session("EmpCode") + "'"
        If (ObjFun.CheckRecordExistInTransaction(Sql)) Then
            email2 = ObjFun.FetchValue(Sql)
            'email2 = "rajan@jctltd.com"
        Else
            email2 = "rajan@jctltd.com"
        End If

        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<style type=""text/css"">")
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head>")



        ' sb.Append("<head>");
        sb.AppendLine("Hi,<br/><br/>")
        sb.AppendLine("Outstanding Reasons Entered by A/C section in OPS. Put your Remarks <br/><br/>")
        'sb.AppendLine("invoiceNo is : " + ViewState("RequestID") + " <br/><br/>")
        sb.AppendLine("Details are Shown below : <br/><br/>")



        '---------- shown fields in mail
        Dim Customer, Invoice, invoicedate, outstanding As String
        Qry = "SELECT distinct custname,invoice_no,Convert(varchar(10),invoice_dt,103) 'invoice_dt',outstanding_amt FROM dbo.jct_ops_outstanding_invoice_reasons  WHERE tran_no = '" & ViewState("TranNo") & "'"

        Dim cmd1 As SqlCommand = New SqlCommand(Qry, Obj.Connection())
        Dim dr As SqlDataReader = cmd1.ExecuteReader()
        If (dr.HasRows) Then
            While (dr.Read())
                Customer = dr("custname").ToString()
                Invoice = dr("invoice_no").ToString()
                invoicedate = dr("invoice_dt").ToString()
                outstanding = Math.Round(dr.Item("outstanding_amt"), 2)
            End While
        Else
            Customer = ""
            Invoice = ""
            invoicedate = ""
            outstanding = ""
        End If
        dr.Close()


        sb.AppendLine("Customer : " + Customer)
        sb.AppendLine("<br/> <br/>")
        sb.AppendLine("Invoice No : " + Invoice)
        sb.AppendLine("<br/> <br/>")
        sb.AppendLine("Invoice Date : " + invoicedate)
        sb.AppendLine("<br/> <br/>")
        sb.AppendLine("Outstanding Amt. : " + outstanding)
        sb.AppendLine("<br/> <br/>")

        dr.Close()
        sb.AppendLine("</table>")

        'sb.AppendLine("<br /><br/>")
        'sb.AppendLine("Detailed Description (Entered by Marketing Executive) : " + txtDescription.Text.ToUpper())
        'sb.AppendLine("<br /><br />")
        'sb.AppendLine("Reason : " + eReasonslist)
        'sb.AppendLine("<br /><br/>")


        sb.AppendLine("</table><br />")

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br />")
        sb.AppendLine("</html>")


        body = sb.ToString()
        from = "noreply@jctltd.com"
        'If (ViewState("PendingAt") = "") Then
        '    '[to] = email1 + "," + email2
        '    [to] = "jatindutta@jctltd.com"
        'Else
        '    [to] = "charanamrit.singh@jctltd.com,mikeops@jctltd.com," + email2
        'End If
        [to] = email1 + "," + email2
        bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,harendra@jctltd.com"

        subject = " Outstanding Reasons"
        Dim mail As New MailMessage()
        mail.From = New MailAddress(from)
        If [to].Contains(",") Then
            Dim tos As String() = [to].Split(","c)
            For i As Integer = 0 To tos.Length - 1
                mail.[To].Add(New MailAddress(tos(i)))
            Next
        Else
            mail.[To].Add(New MailAddress([to]))
        End If

        If Not String.IsNullOrEmpty(bcc) Then
            If bcc.Contains(",") Then
                Dim bccs As String() = bcc.Split(","c)
                For i As Integer = 0 To bccs.Length - 1
                    mail.Bcc.Add(New MailAddress(bccs(i)))
                Next
            Else
                mail.Bcc.Add(New MailAddress(bcc))
            End If
        End If

        mail.Subject = subject
        mail.Body = body
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2007")

        'SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail)
        'return mail;
    End Sub

    Protected Sub lbt_view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_view.Click
        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"

        'Me.ddl_action.SelectedIndex = 1
        'Me.ddl_action_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub lbt_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_add.Click

        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"

        'If Me.lbt_add.Text = "ADD" Then

        'Dim srno As Integer = 0
        Dim sno1 As Integer = 0
        Dim sno2 As String = ""

        If LTrim(RTrim(Me.txtinvoice.Text)) = "" Then
            Fmsg.Message = "Pl. Enter/Select Invoice No "
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Me.txtinvoice.Focus()
            Exit Sub
        End If


        Dim btran As SqlTransaction

        'If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then

        Obj.ConOpen()

        sqlpass = "select tran_no,isnull(inv_out_status,'') from jct_ops_outstanding_invoice_reasons where invoice_no ='" & Me.txtinvoice.Text & "' and inv_out_status = 'O'"
        Dim Cmd As SqlCommand
        Cmd = New SqlCommand(sqlpass, Obj.Connection)
        Dr = Cmd.ExecuteReader

        If Dr.HasRows = True Then
            Dr.Read()
            Fmsg.Message = "Tran.No. " & Dr.Item(0) & " of above invoice already exists in OPEN status, Pl. first AUTHORIZE the Tran.No. "
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Dr.Close()
            Obj.ConClose()

            Me.txtinvoice.Focus()
            Exit Sub
        End If
        Dr.Close()
        Obj.ConClose()

        Obj.ConOpen()
        btran = Obj.Connection.BeginTransaction

        Try

            '--SERIAL NUMBER GENERATION

            'sqlpass = "select isnull(count_value,0)+1 'count_value',ltrim(rtrim(prefix))+" & _
            ' "case len(ltrim(rtrim(convert(char,isnull(count_value,0)+1)))) when 1 then '0000'" & _
            ' "when 2 then '000' when 3 then '00' when 4 then '0' end + ltrim(rtrim(convert(char,isnull(count_value,0)+1))) " & _
            ' "+ltrim(rtrim(suffix)) 'srno' from jct_outstanding_serial_mumber_master   " & _
            ' "where convert(datetime,convert(char(12),getdate())) between convert(datetime,convert(char(12),eff_from)) and convert(datetime,convert(char(12),eff_to)) """
            sqlpass = "exec jct_out_generate_serialno"
            Cmd = New SqlCommand(sqlpass, Obj.Connection)
            Cmd.Transaction = btran
            Dr = Cmd.ExecuteReader

            If Dr.HasRows = True Then
                Dr.Read()
                sno1 = Dr.Item(0)
                sno2 = Dr.Item(1)
                Me.txt_tranno.Text = Dr.Item(1)
                ViewState("TranNo") = Dr.Item(1)
            End If
            Dr.Close()

            Dim i As Integer = 0
            Dim trndt As Date

            For i = 0 To GridView1.Rows.Count - 1

                sqlpass = "select convert(datetime,'" & CType(GridView1.Rows(i).FindControl("txtdate"), TextBox).Text & "',101) "

                Cmd = New SqlCommand(sqlpass, Obj.Connection)
                Cmd.Transaction = btran
                Dr = Cmd.ExecuteReader

                If Dr.HasRows = True Then
                    Dr.Read()
                    trndt = Dr.Item(0)
                End If
                Dr.Close()


                sqlpass = "exec jct_invoice_outstanding_reason_entry  " & _
                                     sno1 & ",'" & Now() & "','" & _
                                     LTrim(RTrim(Me.txt_tranno.Text)) & " ','" & _
                                     LTrim(RTrim(Me.txtinvoice.Text)) & "','" & _
                                     CType(GridView1.Rows(i).FindControl("ddlreason"), DropDownList).SelectedItem.Text & "','" & _
                                     trndt & "'," & _
                                     CType(GridView1.Rows(i).FindControl("txtamount"), TextBox).Text & ",'" & _
                                     CType(GridView1.Rows(i).FindControl("txtremarks"), TextBox).Text & "','" & _
                                     UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                     CType(GridView1.Rows(i).FindControl("ddldrcr"), DropDownList).SelectedItem.Text & "'"

                Cmd = New SqlCommand(sqlpass, Obj.Connection)

                Cmd.Transaction = btran
                Cmd.ExecuteNonQuery()

            Next

            btran.Commit()
            Dr.Close()
            Obj.ConClose()

            Fmsg.Message = "Success"
            Fmsg.CssClass = "addmsg"
            Fmsg.Display()

        Catch ex As Exception

            btran.Rollback()
            Dr.Close()
            Obj.ConClose()

            Fmsg.Message = (ex.Message)
            Fmsg.CssClass = "addmsg"
            Fmsg.Display()
        End Try
        '------------ blank fields 
        Me.txtinvoice.Text = ""
        Me.txtinvdate.Text = ""
        Me.txtfreight.Text = ""
        Me.txtinvamt.Text = ""
        Me.txtoutstanding.Text = ""

        'Grid intilized  
        Me.GridView1.DataSource = Nothing
        Me.GridView1.DataBind()

        '---------------   
        'Me.lbt_close_Click(sender, e)

        ' End If
        '------------- End of ADD mode ---------------- 


    End Sub

    Protected Sub lnkfetch_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkfetch.Click
        If LTrim(RTrim(Me.txtinvoice.Text)) = "" Then
            Fmsg.Message = "Pl. Select Invoice No "
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Me.txtinvoice.Focus()
            Exit Sub
        End If

        'If Me.ddl_action.Text = "ADD" Then
        Dim Cmd As SqlCommand
        Qry = "select invoice_no, invoice_dt,frt_amt,invoice_net_amt as invoice_amt,outstanding_amt from miserp.shp.dbo.combine_invoice_ops_detail where    isnull(outstanding_amt,0) > 0 and ( invoice_no='" + txtinvoice.Text + "' or '" + txtinvoice.Text + "'='') and invoice_no not in ( select distinct invoice_no from jct_ops_outstanding_invoice_reasons where invoice_no = '" + txtinvoice.Text + "' or '" + txtinvoice.Text + "'='') "
        Cmd = New SqlCommand(Qry, Obj.Connection)
        Dr = Cmd.ExecuteReader
        Dr.Read()
        If Dr.HasRows Then
            txtinvoice.Text = Dr.Item("invoice_no")
            txtinvdate.Text = Dr.Item("invoice_dt")
            txtfreight.Text = Math.Round(Dr.Item("frt_amt"), 2)
            txtinvamt.Text = Math.Round(Dr.Item("invoice_amt"), 2)
            txtoutstanding.Text = Math.Round(Dr.Item("outstanding_amt"), 2)
        Else
            Fmsg.Message = "Invalid Invoice or Invoice Already Exist"
            Fmsg.CssClass = "errormsg"
            Fmsg.Display()
            Dr.Close()
            Obj.ConClose()
        End If
        Me.txtinvoice.Focus()
        'End If
    End Sub

    Protected Sub imb_close_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand

        If e.CommandName = "SaveRemarks" Then

            Try

                Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
                Dim rowIndex As Integer = gvr.RowIndex

                Dim invoiceno As String = GridView2.Rows(rowIndex).Cells(2).Text
                Dim tranno As String = GridView2.Rows(rowIndex).Cells(9).Text
                Dim actreason As String = GridView2.Rows(rowIndex).Cells(3).Text
                Dim remarks As TextBox = DirectCast(GridView2.Rows(rowIndex).FindControl("txtremarks"), TextBox)

                Qry = "jct_ops_outstanding_mktg_remarks"
                Dim Cmd As SqlCommand = New SqlCommand(Qry, Obj.Connection())
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.Add("@invoiceno", SqlDbType.Char, 18).Value = invoiceno
                Cmd.Parameters.Add("@tran_no", SqlDbType.Char, 15).Value = tranno
                Cmd.Parameters.Add("@act_reason", SqlDbType.VarChar, 20).Value = actreason
                Cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = remarks.Text
                Cmd.ExecuteNonQuery()

                '------- add for refresh grid
                'Qry = "EXEC jct_ops_outstanding_reasons_FETCH_ADD_mktg_remarks"
                Qry = "EXEC jct_ops_outstanding_reasons_FETCH_ADD_mktg_remarks '" & Session("EmpCode") & "' "
                ObjFun.FillGrid(Qry, GridView2)

            Catch ex As Exception

            End Try

        End If

    End Sub

    Protected Sub txtremarks_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)


    End Sub
End Class
