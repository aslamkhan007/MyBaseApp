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
Imports System.Net.Mail

Partial Class OPS_outstandingreasons
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim Qry, Sql As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand
    Dim Con As SqlConnection = New SqlConnection
    Dim Sm As SendMail = New SendMail()
    Dim enclosureslist As String
    Dim script As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)

        End If
    End Sub

    Protected Sub lnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFetch.Click
        Dim CustCode As String, SalePerson As String
        ' PlantType As String
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

        If txtCustomer.Text <> "" And txtInvoiceNo.Text = "" Then
            Qry = "select  basic_amt,frt_amt,invoice_amt,outstanding_amt from miserp.shp.dbo.combine_invoice_ops_detail where salepersoncode = '" & CustCode & "'and  custname = '" & SalePerson & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Dr = Cmd.ExecuteReader
            Dr.Read()
            If Dr.HasRows = True Then
                txtbasicamt.Text = Dr.Item("basic_amt")
                txtfreight.Text = Dr.Item("frt_amt")
                txtinvamt.Text = Dr.Item("invoice_amt")
                txtoutstanding.Text = Dr.Item("outstanding_amt")
            End If
        ElseIf txtCustomer.Text = "" And txtInvoiceNo.Text <> "" Then
            Qry = "select  basic_amt,frt_amt,invoice_amt,outstanding_amt from miserp.shp.dbo.combine_invoice_ops_detail where invoice_no = '" & txtInvoiceNo.Text & "' "
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Dr = Cmd.ExecuteReader
            Dr.Read()
            If Dr.HasRows = True Then
                txtbasicamt.Text = Dr.Item("basic_amt")
                txtfreight.Text = Dr.Item("frt_amt")
                txtinvamt.Text = Dr.Item("invoice_amt")
                txtoutstanding.Text = Dr.Item("outstanding_amt")
            End If

        End If

        'Qry = "select '' as Reason, '' as Date, '' as Amount, '' as DrCr union select '' as Reason, '' as Date, '' as Amount, '' as DrCr "
        'Cmd = New SqlCommand(Qry, Obj.Connection)
        'Dim dt As DataTable = New DataTable
        'Dim da As SqlDataAdapter = New SqlDataAdapter
        'da.Fill(dt)




    End Sub


    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub
    'Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand

    '    If (e.CommandName = "Save") Then

    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex
    '            Dim Freight As DropDownList = DirectCast(GridView2.Rows(rowIndex).Cells(1).FindControl("ddlFreight"), DropDownList)
    '            Dim reason As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(2).FindControl("txtReason"), TextBox)
    '            Dim ReturnQty As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(3).FindControl("txtReturnQty"), TextBox)
    '            Dim bales As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(4).FindControl("txtbales"), TextBox)
    '            Dim qty As String = GridView2.Rows(rowIndex).Cells(5).Text
    '            Dim item_no As String = GridView2.Rows(rowIndex).Cells(6).Text
    '            Dim invoice_no As String = GridView2.Rows(rowIndex).Cells(7).Text
    '            Dim inv_date As String = GridView2.Rows(rowIndex).Cells(8).Text
    '            Dim cust_name As String = GridView2.Rows(rowIndex).Cells(9).Text



    '            If (reason.Text.ToString() <> "") Then

    '                'ViewState("Customer") = cust_name.ToString()
    '                'ViewState("Invoice") = invoice_no.ToString()
    '                'ViewState("ReturnVal") = ReturnQty.Text.ToString()
    '                'ViewState("Item") = item_no.ToString()
    '                'ViewState("Reason") = reason.Text
    '                ' ------------ save return entry in table 
    '                'Qry = "insert into jct_ops_material_request( invoice_no , invoice_date ,  sales_person ,  customer ,  item_no ,  invoice_qty ,   Freight_by ,  reason , userid ,  gr_no , mr_status , ret_qty , tran_date, instructions, bales ) values('" & invoice_no & "',  CONVERT(VARCHAR, CONVERT(DATETIME,'" + inv_date + "',103),101), '" & Me.ddlSalesPerson.SelectedValue & "','" & cust_name & "', '" & item_no & "', '" & qty & "', '" & Freight.SelectedValue & "',   '" & reason.Text & "','" & Session("Empcode") & "', ' ','O',  " & ReturnQty.Text & ",getdate(), '" & Me.txtinstructions.Text & "' , '" & bales.Text & "')"
    '                Qry = "JCT_OPS_MATERIAL_RETURN_REQUEST_GENERATE"
    '                Cmd = New SqlCommand(Qry, Obj.Connection())
    '                Cmd.CommandType = CommandType.StoredProcedure

    '                Cmd.Parameters.Add("@Freight", SqlDbType.VarChar, 20).Value = Freight.SelectedItem.Text
    '                Cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 200).Value = reason.Text
    '                Cmd.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = Convert.ToDecimal(ReturnQty.Text)
    '                Cmd.Parameters.Add("@Bales", SqlDbType.Decimal).Value = Convert.ToDecimal(bales.Text)
    '                Cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(qty)
    '                Cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 200).Value = item_no
    '                Cmd.Parameters.Add("@Invoice_no", SqlDbType.VarChar, 30).Value = invoice_no
    '                Cmd.Parameters.Add("@Inv_date", SqlDbType.DateTime).Value = Convert.ToDateTime(inv_date)
    '                Cmd.Parameters.Add("@Cust_name", SqlDbType.VarChar, 100).Value = cust_name
    '                Cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 100).Value = ddlSalesPerson.SelectedItem.Value
    '                Cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    '                Cmd.Parameters.Add("@Instruction", SqlDbType.VarChar, 200).Value = txtinstructions.Text

    '                Cmd.ExecuteNonQuery()
    '                Dim script As String = "alert('Record Added.');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '                ' ------------ mail generation 
    '                Dim body As String = "<p>Hello ,</p> <p>You are receiving this email on the behalf of Mktg. Dept, Material Rerurn From Party.</p> </p> <H3>Customer :" + cust_name + "</H3> </p> <p> <H3> Item No :" + item_no + "</H3>  </p> <p><h3>InvoiceNo :" + invoice_no + " </h3></p><p><H3> Return Quantity: " + ReturnQty.Text + " </H3></p><p><H3> Reason: " + reason.Text + " </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
    '                ' Sm.SendMail("rajan@jctltd.com", "noreply@jctltd.com", "Material Return From Party : " + cust_name, body)
    '                Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Material Return From Party : " + cust_name, body)
    '                '  Sm.SendMail("mikeops@jctltd.com", "noreply@jctltd.com", "Material Return From Party : " + cust_name, body)

    '            Else
    '                Dim script As String = "alert('Please Enter Reason for Material Return..!!');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '            End If


    '        Catch ex As Exception

    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '        End Try

    '    End If
    'End Sub


    'Protected Sub grdAuthorize_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAuthorize.RowCommand
    '    Dim Customer, Invoice, returnVal, Item, Reason As String
    '    If e.CommandName = "Authorize" Then

    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex

    '            Dim ID As String = grdAuthorize.Rows(rowIndex).Cells(3).Text
    '            Dim Remarks As TextBox = DirectCast(grdAuthorize.Rows(rowIndex).FindControl("txtRemarks"), TextBox)

    '            Qry = "SELECT sr_no,customer,sales_person ,invoice_no,item_no,invoice_qty,reason,ret_qty,invoice_date FROM dbo.jct_ops_material_request WHERE mr_status='O' AND sr_no =" + ID + ""
    '            Dim Cmd As SqlCommand = New SqlCommand(Qry, Obj.Connection())
    '            Dim dr As SqlDataReader = Cmd.ExecuteReader()
    '            If (dr.HasRows) Then
    '                While (dr.Read())
    '                    Customer = dr("customer").ToString()
    '                    Invoice = dr("invoice_no").ToString()
    '                    returnVal = dr("ret_qty").ToString()
    '                    Item = dr("item_no").ToString()
    '                    Reason = dr("reason").ToString()
    '                End While
    '            Else

    '                Customer = ""
    '                Invoice = ""
    '                returnVal = ""
    '                Item = ""
    '                Reason = ""

    '            End If
    '            dr.Close()

    '            Qry = "JCT_OPS_MATERIAL_REQUEST_AUTHORIZE"
    '            Cmd = New SqlCommand(Qry, Obj.Connection())
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(ID)
    '            Cmd.Parameters.Add("@AUTH_USERCODE", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    '            Cmd.Parameters.Add("@AUTH_Remarks", SqlDbType.VarChar, 200).Value = Remarks.Text
    '            Cmd.ExecuteNonQuery()

    '            Dim body As String = "<p>Hello ,</p> <p> The Material Return Request has been authorized by Mr.Charanamrit Singh. Please do the needful at your end now. Details of the request are as follows : </p> </p> <H3>Customer :" + Customer + "</H3> </p> <p> <H3> Item No :" + Item + "</H3>  </p> <p><h3>InvoiceNo :" + Invoice + " </h3></p><p><H3> Return Quantity: " + returnVal + " </H3></p><p><H3> Remarks: " + Remarks.Text + " </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
    '            Sm.SendMail("pgmohan@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)
    '            Sm.SendMail("mrsood@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)
    '            Sm.SendMail("rameshs@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)
    '            Sm.SendMail("charanamrit.singh@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)
    '            Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)

    '            Qry = "EXEC JCT_OPS_MATERIAL_RETURN_FETCH"
    '            ObjFun.FillGrid(Qry, grdAuthorize)

    '            Dim script As String = "alert('Record Authorized');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '        Catch ex As Exception

    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)


    '        Finally

    '            Obj.ConClose()

    '        End Try



    '    ElseIf e.CommandName = "Cancel" Then


    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex

    '            Dim ID As String = grdAuthorize.Rows(rowIndex).Cells(1).Text
    '            Dim empcode As String = ObjFun.FetchValue("SELECT sales_person FROM  jct_ops_material_request WHERE sr_no=" + ID + " ").ToString()
    '            Dim Sales_PersonEmail As String = ObjFun.FetchValue("SELECT isnull(E_MailID,'rajan@jctltd.com') FROM dbo.MISTEL WHERE REPLACE(empcode,'-','')='" + empcode + "'").ToString()
    '            Qry = "JCT_OPS_MATERIAL_REQUEST_CANCEL"
    '            Dim Cmd As SqlCommand = New SqlCommand(Qry, Obj.Connection())
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(ID)
    '            Cmd.Parameters.Add("@AUTH_USERCODE", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    '            Cmd.ExecuteNonQuery()

    '            Dim body As String = "<p>Hello ,</p> <p> The Material Return Request has been cancelled by Mr.Charanamrit Singh. Please do the needful at your end now. Details of the request are as follows : </p> </p> <H3>Customer :" + ViewState("Customer") + "</H3> </p> <p> <H3> Item No :" + ViewState("Item") + "</H3>  </p> <p><h3>InvoiceNo :" + ViewState("Invoice") + " </h3></p><p><H3> Return Quantity: " + ViewState("ReturnVal") + " </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

    '            Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Cancellation - Material Return From Party", body)
    '            Sm.SendMail("mikeops@jctltd.com", "noreply@jctltd.com", "Cancellation - Material Return From Party", body)
    '            Sm.SendMail("charanamrit.singh@jctltd.com", "noreply@jctltd.com", "Cancellation - Material Return From Party", body)

    '            Sm.SendMail(Sales_PersonEmail, "noreply@jctltd.com", "Cancellation - Material Return From Party", body)

    '            Qry = "EXEC JCT_OPS_MATERIAL_RETURN_FETCH"
    '            ObjFun.FillGrid(Qry, grdAuthorize)

    '            Dim script As String = "alert('Material Request Cancelled..!!');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '        Catch ex As Exception

    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)


    '        Finally

    '            Obj.ConClose()

    '        End Try


    '    End If

    'End Sub


    'Protected Sub grdGrNo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdGrNo.RowCommand

    '    If e.CommandName = "SaveGrNo" Then

    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex

    '            Dim ID As String = grdGrNo.Rows(rowIndex).Cells(4).Text
    '            Dim GrNo As TextBox = DirectCast(grdGrNo.Rows(rowIndex).FindControl("txtGrNo"), TextBox)
    '            Dim GrDate As TextBox = DirectCast(grdGrNo.Rows(rowIndex).FindControl("txtGrDate"), TextBox)
    '            Dim Transport As DropDownList = DirectCast(grdGrNo.Rows(rowIndex).FindControl("ddlTransport"), DropDownList)
    '            Dim Enclouser As TextBox = DirectCast(grdGrNo.Rows(rowIndex).FindControl("txtenclouser"), TextBox)

    '            Qry = "JCT_OPS_MATERIAL_REQUEST_AUTHORIZE_GR_No"
    '            Dim Cmd As SqlCommand = New SqlCommand(Qry, Obj.Connection())
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(ID)
    '            Cmd.Parameters.Add("@AUTH_USERCODE", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    '            Cmd.Parameters.Add("@GrNo", SqlDbType.VarChar, 20).Value = GrNo.Text
    '            Cmd.Parameters.Add("@GrDate", SqlDbType.DateTime).Value = GrDate.Text
    '            Cmd.Parameters.Add("@Transport", SqlDbType.VarChar, 20).Value = Transport.SelectedItem.Text
    '            Cmd.Parameters.Add("@Enclouser", SqlDbType.VarChar, 20).Value = Enclouser.Text
    '            Cmd.ExecuteNonQuery()

    '            Qry = "EXEC JCT_OPS_MATERIAL_RETURN_FETCH_ADD_GR_NO"
    '            ObjFun.FillGrid(Qry, grdAuthorize)

    '            Dim script As String = "alert('Details Added to Record..!!');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '        Catch ex As Exception
    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
    '        End Try

    '    End If

    'End Sub



    'Protected Sub chbEnclosures_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbEnclosures.SelectedIndexChanged

    '    For i As Integer = 0 To chbEnclosures.Items.Count - 1
    '        If chbEnclosures.Items(i).Selected Then

    '            If chbEnclosures.Items(i).Text = "Other" Then

    '                txtEnclosures.Visible = True
    '            End If

    '        Else

    '            If chbEnclosures.Items(i).Text = "Other" Then

    '                txtEnclosures.Visible = False

    '            End If

    '        End If
    '    Next


    'End Sub

    'Protected Function ListOfElcosures() As String

    '    Dim enclosures As List(Of String) = New List(Of String)
    '    For i As Integer = 0 To chbEnclosures.Items.Count - 1

    '        If chbEnclosures.Items(i).Selected Then

    '            If chbEnclosures.Items(i).Text = "Other" Then

    '                enclosures.Add(txtEnclosures.Text)
    '            Else

    '                enclosures.Add(chbEnclosures.Items(i).Text)

    '            End If


    '        End If


    '    Next

    '    'enclosureslist.Join(",", enclosures.ToArray)
    '    enclosureslist = String.Join(",", enclosures.ConvertAll(Of String)(Function(i As String) i.ToString()).ToArray).TrimEnd(",").TrimStart(",")

    '    Return enclosureslist

    'End Function

    ''Protected Sub lnkSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSave.Click

    ''    Dim cbHeader As CheckBox = DirectCast(GridView2.HeaderRow.FindControl("ChbSelectAll"), CheckBox)
    ''    Dim RequestId As Int16

    ''    If (cbHeader.Checked = True) Then

    ''        For i As Integer = 0 To GridView2.Rows.Count - 1


    ''            Dim Freight As DropDownList = DirectCast(GridView2.Rows(i).FindControl("ddlFreight"), DropDownList)
    ''            Dim reason As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtReason"), TextBox)
    ''            Dim ReturnQty As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtReturnQty"), TextBox)
    ''            Dim bales As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtbales"), TextBox)
    ''            Dim qty As String = GridView2.Rows(i).Cells(5).Text
    ''            Dim item_no As String = GridView2.Rows(i).Cells(6).Text
    ''            Dim invoice_no As String = GridView2.Rows(i).Cells(7).Text
    ''            Dim inv_date As String = GridView2.Rows(i).Cells(8).Text
    ''            Dim cust_name As String = GridView2.Rows(i).Cells(9).Text

    ''            Dim list As String = ListOfElcosures()

    ''            Try
    ''                Qry = "JCT_OPS_MATERIAL_REQUEST_GENERATE_REQUESTID"
    ''                Cmd = New SqlCommand(Qry, Obj.Connection())
    ''                Cmd.CommandType = CommandType.StoredProcedure
    ''                Dim dr As SqlDataReader = Cmd.ExecuteReader
    ''                If (dr.HasRows) Then

    ''                    While (dr.Read())

    ''                        RequestId = Convert.ToInt16(dr(0).ToString())
    ''                        ViewState("RequestID") = RequestId
    ''                    End While

    ''                End If
    ''                dr.Close()

    ''                If (reason.Text.ToString() <> "") Then


    ''                    Qry = "JCT_OPS_MATERIAL_RETURN_REQUEST_GENERATE"
    ''                    Cmd = New SqlCommand(Qry, Obj.Connection())
    ''                    Cmd.CommandType = CommandType.StoredProcedure

    ''                    Cmd.Parameters.Add("@Freight", SqlDbType.VarChar, 20).Value = Freight.SelectedItem.Text
    ''                    Cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 200).Value = reason.Text
    ''                    Cmd.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = Convert.ToDecimal(ReturnQty.Text)
    ''                    Cmd.Parameters.Add("@Bales", SqlDbType.Decimal).Value = Convert.ToDecimal(bales.Text)
    ''                    Cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(qty)
    ''                    Cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 200).Value = item_no
    ''                    Cmd.Parameters.Add("@Invoice_no", SqlDbType.VarChar, 30).Value = invoice_no
    ''                    Cmd.Parameters.Add("@Inv_date", SqlDbType.VarChar, 20).Value = inv_date
    ''                    Cmd.Parameters.Add("@Cust_name", SqlDbType.VarChar, 100).Value = cust_name
    ''                    Cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 100).Value = ddlSalesPerson.SelectedItem.Value
    ''                    Cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    ''                    Cmd.Parameters.Add("@Instruction", SqlDbType.VarChar, 200).Value = txtinstructions.Text
    ''                    Cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = RequestId
    ''                    Cmd.Parameters.Add("@Enclosures", SqlDbType.VarChar, 100).Value = list
    ''                    Cmd.ExecuteNonQuery()


    ''                Else
    ''                    Dim script As String = "alert('Please Enter Reason for Material Return..!!');"
    ''                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    ''                End If

    ''            Catch ex As Exception

    ''                script = "alert('" + ex.Message + "');"
    ''                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    ''            End Try

    ''        Next

    ''        script = "alert('MR Request has been generated with ID -' " + RequestId + ". Now It has been sent for authorization..!!);"
    ''        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    ''        GridView2.DataSource = Nothing
    ''        GridView2.DataBind()
    ''        pnlGridview2.Visible = False

    ''    Else

    ''        Qry = "JCT_OPS_MATERIAL_REQUEST_GENERATE_REQUESTID"
    ''        Cmd = New SqlCommand(Qry, Obj.Connection())
    ''        Cmd.CommandType = CommandType.StoredProcedure
    ''        Dim dr As SqlDataReader = Cmd.ExecuteReader
    ''        If (dr.HasRows) Then

    ''            While (dr.Read())

    ''                RequestId = Convert.ToInt16(dr(0).ToString())

    ''            End While

    ''        End If
    ''        dr.Close()


    ''        For i As Integer = 0 To GridView2.Rows.Count - 1

    ''            Dim cbSelect As CheckBox = DirectCast(GridView2.Rows(i).FindControl("ChbSelect"), CheckBox)


    ''            If cbSelect.Checked = True Then



    ''                Dim Freight As DropDownList = DirectCast(GridView2.Rows(i).FindControl("ddlFreight"), DropDownList)
    ''                Dim reason As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtReason"), TextBox)
    ''                Dim ReturnQty As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtReturnQty"), TextBox)
    ''                Dim bales As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtbales"), TextBox)
    ''                Dim qty As String = GridView2.Rows(i).Cells(5).Text
    ''                Dim item_no As String = GridView2.Rows(i).Cells(6).Text
    ''                Dim invoice_no As String = GridView2.Rows(i).Cells(7).Text
    ''                Dim inv_date As String = GridView2.Rows(i).Cells(8).Text
    ''                Dim cust_name As String = GridView2.Rows(i).Cells(9).Text

    ''                Dim list As String = ListOfElcosures()

    ''                Try


    ''                    If (reason.Text.ToString() <> "") Then

    ''                        Qry = "JCT_OPS_MATERIAL_RETURN_REQUEST_GENERATE"
    ''                        Cmd = New SqlCommand(Qry, Obj.Connection())
    ''                        Cmd.CommandType = CommandType.StoredProcedure

    ''                        Cmd.Parameters.Add("@Freight", SqlDbType.VarChar, 20).Value = Freight.SelectedItem.Text
    ''                        Cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 200).Value = reason.Text
    ''                        Cmd.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = Convert.ToDecimal(ReturnQty.Text)
    ''                        Cmd.Parameters.Add("@Bales", SqlDbType.Decimal).Value = Convert.ToDecimal(bales.Text)
    ''                        Cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(qty)
    ''                        Cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 20).Value = item_no
    ''                        Cmd.Parameters.Add("@Invoice_no", SqlDbType.VarChar, 30).Value = invoice_no
    ''                        Cmd.Parameters.Add("@Inv_date", SqlDbType.VarChar, 20).Value = inv_date
    ''                        Cmd.Parameters.Add("@Cust_name", SqlDbType.VarChar, 100).Value = cust_name
    ''                        Cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 100).Value = ddlSalesPerson.SelectedItem.Value
    ''                        Cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    ''                        Cmd.Parameters.Add("@Instruction", SqlDbType.VarChar, 200).Value = txtinstructions.Text
    ''                        Cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = RequestId
    ''                        Cmd.Parameters.Add("@Enclosures", SqlDbType.VarChar, 100).Value = list
    ''                        Cmd.ExecuteNonQuery()

    ''                    Else
    ''                        script = "alert('Please Enter Reason for Material Return..!!');"
    ''                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
    ''                        Return
    ''                    End If


    ''                Catch ex As Exception

    ''                    script = "alert('" + ex.Message + "');"
    ''                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    ''                End Try


    ''            End If


    ''        Next

    ''        script = "alert('MR Request has been generated with ID -' " + RequestId + ". Now It has been sent for authorization..!!);"
    ''        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    ''        GridView2.DataSource = Nothing
    ''        GridView2.DataBind()
    ''        pnlGridview2.Visible = False
    ''        ' ------------ mail generation 
    ''        ' Dim body As String = "<p>Hello ,</p> <p>You are receiving this email on the behalf of Mktg. Dept, Material Rerurn From Party.</p> </p> <H3>Customer :" + cust_name + "</H3> </p> <p> <H3> Item No :" + item_no + "</H3>  </p> <p><h3>InvoiceNo :" + invoice_no + " </h3></p><p><H3> Return Quantity: " + ReturnQty.Text + " </H3></p><p><H3> Reason: " + reason.Text + " </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
    ''        '  Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Material Return From Party : " + cust_name, body)


    ''    End If


    ''End Sub

    ''Private Sub SendMail_SaleOrderAdjustment()
    ''    Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String


    ''    Dim sb As New StringBuilder()


    ''    sb.AppendLine("<html>")
    ''    sb.AppendLine("<head>")
    ''    sb.AppendLine("<style type=""text/css"">")
    ''    sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
    ''    sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
    ''    sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
    ''    sb.AppendLine("</style>")
    ''    sb.AppendLine("</head>")



    ''    ' sb.Append("<head>");
    ''    sb.AppendLine("Hi,<br/>")
    ''    sb.AppendLine("Material Return Request has been generated in OPS.<br/><br/>")
    ''    sb.AppendLine("Details are Shown below : <br/>")
    ''    sb.AppendLine("<table class=""gridtable"">")
    ''    sb.AppendLine("<tr><th> Sale Person</th> <th> Invoice No</th></th> <th>Invoice Item</th>  <th>Invoice Qty</th> <th> Return Qty</th> <th>Invoice Date</th> <th>Freight By</th> </tr>")
    ''    Sql = "SELECT ACTUAL_SALEORDER AS [OrderNo],ACTUAL_SORT AS [Sort],ACTUAL_WEAVINGSORT AS [WeavingSort],ACTUAL_QTY AS [QTY],ACTUAL_GREIGHREQ AS [GreighReq],ISNULL(AdjustedQty,0) AS [AdjustedQty],Remarks FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTMENT WHERE SanctionID ='" + ViewState("SanctionID") & "'"
    ''    Dr = ObjFun.FetchReader(Sql)
    ''    If Dr.HasRows Then
    ''        While Dr.Read()

    ''            sb.AppendLine("<tr> <td>  " & Dr(0).ToString() & " </td> <td>  " & Dr(1).ToString() & " </td>  <td> " & Dr(2).ToString() & "</td>  <td> " & Dr(3).ToString() & "</td>  <td> " & Dr(4).ToString() & "</td>  <td>" & Dr(5).ToString() & "</td><td>" & Dr(6).ToString() & "</td>  </tr> ")
    ''        End While
    ''    End If
    ''    sb.AppendLine("</table>")
    ''    sb.AppendLine("<br />")
    ''    sb.AppendLine("Adjusted Order Details : <br/>")
    ''    Dr.Close()
    ''    sb.AppendLine("<table class=""gridtable""><tr><th> Order No</th> <th> Sort</th> <th> Line Item</th> <th> Shade</th> <th>QTY</th> <th>  Greigh Req</th>  <th>Adjusted Qty</th>   </tr> ")
    ''    Sql = "SELECT SALEORDER AS [OrderNo],SORT,LineItem,Shade,QTY,GREIGHREQ,AdjustedQty FROM dbo.JCT_OPS_PLANNING_SALEORDER_ADJUSTED_ORDERS  WHERE SanctionID ='" + ViewState("SanctionID") & "'"
    ''    Dr = ObjFun.FetchReader(Sql)
    ''    If Dr.HasRows Then
    ''        While Dr.Read()


    ''            sb.AppendLine("<tr> <td>  " & Dr(0).ToString() & " </td> <td>  " & Dr(1).ToString() & " </td>  <td> " & Dr(2).ToString() & "</td>  <td> " & Dr(3).ToString() & "</td>  <td> " & Dr(4).ToString() & "</td>  <td>" & Dr(5).ToString() & "</td><td>" & Dr(6).ToString() & "</td>  </tr> ")
    ''        End While
    ''    End If

    ''    sb.AppendLine("</table><br />")

    ''    sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply. ")
    ''    sb.AppendLine("Thank you<br />")
    ''    sb.AppendLine("</html>")


    ''    body = sb.ToString()
    ''    from = "noreply@jctltd.com"
    ''    'Email Address of Sender
    ''    'to = "jatindutta@jctltd.com";
    ''    [to] = ("neeraj@jctltd.com,karanjitsaini@jctltd.com,bipansharma@jctltd.com," + ViewState("ActualOrder_EmailID") & ",") + ViewState("Adjusted_EmailID")
    ''    'Email Address of Receiver
    ''    bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"
    ''    cc = "sobti@jctltd.com,rkkapoor@jctltd.com,mikeops@jctltd.com"
    ''    subject = "Request - Sale Order Adjustment"
    ''    Dim mail As New MailMessage()
    ''    mail.From = New MailAddress(from)
    ''    If [to].Contains(",") Then
    ''        Dim tos As String() = [to].Split(","c)
    ''        For i As Integer = 0 To tos.Length - 1
    ''            mail.[To].Add(New MailAddress(tos(i)))
    ''        Next
    ''    Else
    ''        mail.[To].Add(New MailAddress([to]))
    ''    End If

    ''    If Not String.IsNullOrEmpty(bcc) Then
    ''        If bcc.Contains(",") Then
    ''            Dim bccs As String() = bcc.Split(","c)
    ''            For i As Integer = 0 To bccs.Length - 1
    ''                mail.Bcc.Add(New MailAddress(bccs(i)))
    ''            Next
    ''        Else
    ''            mail.Bcc.Add(New MailAddress(bcc))
    ''        End If
    ''    End If
    ''    If Not String.IsNullOrEmpty(cc) Then
    ''        If cc.Contains(",") Then
    ''            Dim ccs As String() = cc.Split(","c)
    ''            For i As Integer = 0 To ccs.Length - 1
    ''                mail.CC.Add(New MailAddress(ccs(i)))
    ''            Next
    ''        Else
    ''            mail.CC.Add(New MailAddress(bcc))
    ''        End If
    ''        mail.CC.Add(New MailAddress(cc))
    ''    End If

    ''    mail.Subject = subject
    ''    mail.Body = body
    ''    mail.IsBodyHtml = True
    ''    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
    ''    Dim SmtpMail As New SmtpClient("exchange2007")

    ''    'SmtpMail.SmtpServer = "exchange2007";
    ''    SmtpMail.Send(mail)
    ''    'return mail;
    ''End Sub

    'Protected Sub chbSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim cbHeader As CheckBox = DirectCast(GridView2.HeaderRow.FindControl("ChbSelectAll"), CheckBox)
    '    If cbHeader.Checked = True Then
    '        For k As Integer = 0 To GridView2.Rows.Count - 1
    '            Dim myCheckBox As CheckBox = DirectCast(GridView2.Rows(k).FindControl("ChbSelect"), CheckBox)
    '            myCheckBox.Checked = True
    '        Next
    '    ElseIf cbHeader.Checked = False Then
    '        For k As Integer = 0 To GridView2.Rows.Count - 1
    '            Dim myCheckBox As CheckBox = DirectCast(GridView2.Rows(k).FindControl("ChbSelect"), CheckBox)
    '            myCheckBox.Checked = False
    '        Next
    '    End If

    'End Sub

    
    


    
End Class
