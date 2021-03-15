Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Threading
Imports System.Net.Mail
Imports System.IO

Partial Class frm_outsource_fabric_yarn_rm
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim obj As New Connection
    Dim obj2 As New Functions
    Dim sqlpass, sno2, qry As String
    Dim scrpt_str As String
    Dim Ash, sno1 As Integer
    Dim dt As New Data.DataTable
    Dim ObjFun As Functions = New Functions

    Dim var_location, var_document, var_vendname, var_waybill, var_stockno, var_variant, var_stockname, var_unloadno, var_unloaddt, var_pono As String
    Dim var_bales As Decimal = 0
    Dim var_qtyrcvd As String = 0
    Dim var_balqty As Decimal = 0
    Dim var_entryno As Decimal = 0
    Dim var_orderqty As Decimal = 0



    Public CstModule As New CostModule
    
    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)


        sqlpass = "exec jct_ops_outsorce_fabric_yarn_unloading  '" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        sqlpass = ""
        BindData1()
        lnkapply.Visible = True




    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
    End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        Sqlpass = "select convert(numeric(5),bales_rcvd)'BalesRcvd',convert(numeric(10,3),bal_qty) 'BalQty' ,vendor_name 'Vendor',waybillno 'Waybillno', stockno 'StockNo', variant 'Variant',stock_name 'StockName',unloadno 'UnloadNo',convert(varchar(10),unloaddate,103) 'UnloadDt',Entryno 'EntryNo', pono 'PoNo', convert(numeric(10,3),order_qty) 'OrderQty'   from jct_ops_rm_fabric_unload  order by unloaddate , vendor_name  "
        obj2.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Empcode") <> "" Then
                Session("Empcode") = Session("Empcode")
                'Else
                '   Response.Redirect("login.aspx")
            End If
            'BindData1()
        End If
    End Sub

    Protected Sub grdGrid1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdGrid1.RowCommand

    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkapply.Click
        For i As Integer = 0 To Me.grdGrid1.Rows.Count - 1

            If grdGrid1.Rows(i).RowType = DataControlRowType.DataRow Then

                var_location = CType(grdGrid1.Rows(i).FindControl("ddllocation"), DropDownList).SelectedItem.Text
                var_document = CType(grdGrid1.Rows(i).FindControl("ddldocument"), DropDownList).SelectedItem.Text

                var_qtyrcvd = CType(grdGrid1.Rows(i).FindControl("txtqtyrcvd"), TextBox).Text
                If var_qtyrcvd <> "" Then

                    var_bales = grdGrid1.Rows(i).Cells(3).Text
                    var_balqty = grdGrid1.Rows(i).Cells(4).Text
                    var_vendname = grdGrid1.Rows(i).Cells(5).Text
                    var_waybill = grdGrid1.Rows(i).Cells(6).Text
                    var_stockno = grdGrid1.Rows(i).Cells(7).Text
                    var_variant = grdGrid1.Rows(i).Cells(8).Text
                    var_stockname = grdGrid1.Rows(i).Cells(9).Text
                    var_unloadno = grdGrid1.Rows(i).Cells(10).Text
                    var_unloaddt = grdGrid1.Rows(i).Cells(11).Text
                    var_entryno = grdGrid1.Rows(i).Cells(12).Text
                    var_pono = grdGrid1.Rows(i).Cells(13).Text
                    var_orderqty = grdGrid1.Rows(i).Cells(14).Text

                    qry = "insert into  jct_ops_rm_rcvd_outsorc_material(plant,Vendor_name,waybillno,document_rcvd,Bales_rcvd,UnloadNo,unloadDate,EntryNO,StockNo,variant,Stock_name,PONo,Order_Qty,Bal_qty,Host_id,entry_date,material_status) values( '" & var_location & "',  '" & var_vendname & "', '" & var_waybill & "', '" & var_document & "', '" & var_bales & "', '" & var_qtyrcvd & "', '" & var_unloadno & "', '" & var_unloaddt & "','" & var_entryno & "', '" & var_stockno & "', '" & var_variant & "', '" & var_stockname & "', '" & var_pono & "','" & var_orderqty & "', '" & var_balqty & "', '" & Session("Empcode") & "', getdate(), 'R' ) "
                    cmd = New SqlCommand(qry, obj.Connection)
                    cmd.ExecuteNonQuery()
                    SendMail()


                End If
            End If
        Next
    End Sub
    Private Sub SendMail()
        Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String


        Dim sb As New StringBuilder()
        Dim email1, email2 As String
        'Dim FlagAuth As String
        ''FlagAuth = FlagAuth.Split(",")(0)
        ''Sql = "Select e_mailid from mistel where empcode='" + FlagAuth + "'"
        'If (ObjFun.CheckRecordExistInTransaction(Sql)) Then

        '    'email1 = ObjFun.FetchValue(Sql)

        'Else

        '    email1 = "shwetaloria@jctltd.com"

        'End If

        Sql = "Select e_mailid from mistel where empcode='" + Session("EmpCode") + "'"
        'If (ObjFun.CheckRecordExistInTransaction(Sql)) Then

        '    'email2 = ObjFun.FetchValue(Sql)

        'Else

        '    email2 = "jatindutta@jctltd.com"

        'End If

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
        sb.AppendLine("Following material has been outsourced OPS.<br/><br/>")
        'sb.AppendLine("RequestID for your request is : " + ViewState("RequestID") + " <br/><br/>")
        sb.AppendLine("Details are Shown below : <br/><br/>")
        sb.AppendLine("<table class=gridtable>")


        'sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")
        'Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")
        'Sql = "JCT_OPS_SANCTION_PENDING_AT_MATERIAL_RETURN"
        'Dim cmd As SqlCommand = New SqlCommand(Sql, Obj.Connection())
        'cmd.CommandType = CommandType.StoredProcedure
        'cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState("RequestID")
        'Dim Dr As SqlDataReader = cmd.ExecuteReader()
        'If (Dr.HasRows) Then
        '    While (Dr.Read())
        '        ViewState("PendingAt") = ""
        '        If (Dr(6).ToString = "" Or Dr(6).ToString() = "CEO") Then
        '            ViewState("PendingAt") = Dr(6).ToString()
        sb.AppendLine("<tr><th> PONo</th> <th>Vendor Name</th>  <th> StockNo</th> <th>StockName</th><th> QtyRecieved</th> ")
        For Each row As GridViewRow In grdGrid1.Rows


            Dim QtyRcvd As TextBox = CType(row.Cells(2).FindControl("txtqtyrcvd"), TextBox)
            Dim vendr As String = row.Cells(5).Text
            Dim poNo As String = row.Cells(13).Text
            Dim stockno As String = row.Cells(7).Text
            Dim stockname As String = row.Cells(9).Text
            Dim ddlloc As DropDownList = CType(row.Cells(2).FindControl("ddllocation"), DropDownList)

            If ddlloc.SelectedItem.Text = "Cotton" Then
                [to] = "shwetaloria@jctltd.com,rajan@jctltd.com"
                '[to] = "naresh2@jctltd.com, pkchhabra@jctltd.com,sobti@jctltd.com,ypsharma@jctltd.com,dpbadhwar@jctltd.com"
                If ddlloc.SelectedItem.Text = "Taffeta" Then
                    '[to] = "whg@jctltd.com , pillai@jctltd.com ,chandwani@jctltd.com"

                    '[to] = "shwetaloria@jctltd.com,rajan@jctltd.com"

                    [to] = "jatindutta@jctltd.com"
                End If
            End If







            sb.AppendLine("<tr> <td> " + poNo + " </td> <td> " + vendr + "</td>    <td>" + stockno + " </td>  <td>" + stockname + " </td><td> " + QtyRcvd.Text + "</td> </tr>")
            'sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td> CEO </td> </tr> ")
            'End If
            'sql = "Select empname from jct_empmast_base where active='Y' and  empcode='" + dr(6).ToString().Split(",")(0) + "'"
            'Dim empname As String = ""
            'Dim obj2 As Connection = New Connection
            'cmd = New SqlCommand(sql, obj2.Connection())
            'Dim dr1 As SqlDataReader = cmd.ExecuteReader
            'If (dr1.HasRows()) Then

            '    While (dr1.Read)

            '        empname = dr1(0).ToString

            '    End While

            'End If
            'dr1.Close()
            'obj2.ConClose()



            'dr.Close()
            sb.AppendLine("</table>")

            sb.AppendLine("<br /><br/>")
            'sb.AppendLine("Detailed Description (Entered by Marketing Executive) : " + txtDescription.Text.ToUpper())
            sb.AppendLine("<br /><br />")

            sb.AppendLine("<br /><br/>")
            'sb.Append("<a href='http://testerp/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details... </a><br />")

            sb.AppendLine("</table><br />")

            sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
            sb.AppendLine("Thank you<br />")
            sb.AppendLine("</html>")


            body = sb.ToString()
            from = "noreply@jctltd.com"
            'If (ViewState("PendingAt") = "") Then
            '[to] = email1 + "," + email2



            'Else
            '' [to] = "charanamrit.singh@jctltd.com,mikeops@jctltd.com," + email2
            'End If

            ' bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com"
            '[to] = ("jatindutta@jctltd.com")
            'Email Address of Receiver
            'cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
            subject = "outsourced Material" 'Material Return Request - " + ViewState("Cust"
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

            'If Not String.IsNullOrEmpty(bcc) Then
            '    If bcc.Contains(",") Then
            '        Dim bccs As String() = bcc.Split(","c)
            '        For i As Integer = 0 To bccs.Length - 1
            '            mail.Bcc.Add(New MailAddress(bccs(i)))
            '        Next
            '    Else
            '        mail.Bcc.Add(New MailAddress(bcc))
            '    End If
            'End If
            'If Not String.IsNullOrEmpty(cc) Then
            '    If cc.Contains(",") Then
            '        Dim ccs As String() = cc.Split(","c)
            '        For i As Integer = 0 To ccs.Length - 1
            '            mail.CC.Add(New MailAddress(ccs(i)))
            '        Next
            '    Else
            '        mail.CC.Add(New MailAddress(bcc))
            '    End If
            '    mail.CC.Add(New MailAddress(cc))
            'End If

            mail.Subject = subject
            mail.Body = body
            mail.IsBodyHtml = True
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            Dim SmtpMail As New SmtpClient("exchange2007")

            'SmtpMail.SmtpServer = "exchange2007";
            SmtpMail.Send(mail)
            'return mail;
        Next

        
    End Sub
    Private Sub fun()

        For Each row As GridViewRow In grdGrid1.Rows


            Dim QtyRcvd As TextBox = CType(row.Cells(2).FindControl("txtqtyrcvd"), TextBox)
            Dim vendr As String = row.Cells(5).Text
            Dim poNo As String = row.Cells(13).Text
            Dim stockno As String = row.Cells(7).Text
            Dim stockname As String = row.Cells(9).Text
            Dim ddlloc As DropDownList = CType(row.Cells(2).FindControl("ddllocation"), DropDownList)


        Next
    End Sub

End Class

