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
Partial Class OPS_HoldOrder
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim Qry As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand
    Dim Con As SqlConnection
    Dim ObjSendMail As SendMail = New SendMail
    Dim Scrpt As String = ""
    Dim ToEMail As String, ByEmailID As String
    Dim Status As Boolean = False

    Protected Sub txtOrderNo_TextChanged(sender As Object, e As System.EventArgs) Handles txtOrderNo.TextChanged
        'Dim Constr As String
        'Constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MisSom").ConnectionString
        'Con = New SqlConnection(Constr)

      
    End Sub

    Protected Sub ddlItems_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlItems.SelectedIndexChanged
        Qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlItems.SelectedItem.Value
        lblLineNo.Text = ObjFun.FetchValue(Qry)
        Qry = "SELECT distinct  a.item_no FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlItems.SelectedItem.Value
        lblSort.Text = ObjFun.FetchValue(Qry)
    End Sub

    Protected Sub CmdHold_Click(sender As Object, e As System.EventArgs) Handles CmdHold.Click
        Scrpt = ""
        Dim ToEMail As String, ByEmailID As String
        Dim CCList As String = ""
        ToEMail = "ashish@jctltd.com;jagdeep@jctltd.com;harendra@jctltd.com"
        ByEmailID = "noreply@jctltd.com"

        Dim body As String = "<p>Hello,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your order has been put on the Hold from the production Cycle.</p> Hold Order Request is genrated by " & Session("empname") & "  with </p> <H3>Order No. " & txtOrderNo.Text & "  </H3>  </p> <p> <H3>  Sort No. " & lblSort.Text & " .</p> <p>  Shade " & lblLineNo.Text & " </H3>  </p> <H3> Quantity :- " & txtHoldMeters.Text & " Mtrs</H3> <p><h3>Reason For Holding :  " & txtReason.Text & "</h3></p><p><H3> Hold till Date:  " & txtDate.Text & "</H3> </p><p> <H3> Additional Info :-<br><br> Customer " & lblCustomerName.Text & "</br>   SalePerson " & lblSalePerson.Text & "</p></H3></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"


       
        If ddlHoldBy.SelectedItem.Text = "Processing" And ddlPlant.SelectedItem.Text = "Taffeta" Then
            CCList = "husanlal@jctltd.com,ramjiban@jctltd.com,nandi@jctltd.com,trivendermehta@jctltd.com "
        ElseIf ddlHoldBy.SelectedItem.Text = "Marketing" Then
            CCList = "nandi@jctltd.com,trivendermehta@jctltd.com,suniljoshi@jctltd.com"
        ElseIf ddlHoldBy.SelectedItem.Text = "Planning" And ddlPlant.SelectedItem.Text = "Taffeta" Then
            CCList = "nandi@jctltd.com,trivendermehta@jctltd.com"
        ElseIf ddlHoldBy.SelectedItem.Text = "Quality Assurance" And ddlPlant.SelectedItem.Text = "Taffeta" Then
            CCList = "nandi@jctltd.com,trivendermehta@jctltd.com"
        ElseIf ddlHoldBy.SelectedItem.Text = "WareHouse" And ddlPlant.SelectedItem.Text = "Taffeta" Then
            CCList = "nandi@jctltd.com,trivendermehta@jctltd.com"
        ElseIf ddlHoldBy.SelectedItem.Text = "Processing" And ddlPlant.SelectedItem.Text = "Cotton" Then
            CCList = "Khushwinder@jctltd.com,rashpal@jctltd.com,Neeraj@jctltd.com,sobti@jtdltd.com"
        ElseIf ddlHoldBy.SelectedItem.Text = "Processing" And ddlPlant.SelectedItem.Text = "Cotton" Then
            CCList = "neeraj@jctltd.com,sobti@jctltd.com "
        ElseIf ddlHoldBy.SelectedItem.Text = "Marketing" And ddlPlant.SelectedItem.Text = "Cotton" Then
            CCList = "neeraj@jctltd.com,sobti@jctltd.com "
        ElseIf ddlHoldBy.SelectedItem.Text = "Planning" And ddlPlant.SelectedItem.Text = "Cotton" Then
            CCList = "neeraj@jctltd.com,sobti@jctltd.com "
        ElseIf ddlHoldBy.SelectedItem.Text = "Quality Assurance" And ddlPlant.SelectedItem.Text = "Cotton" Then
            CCList = "neeraj@jctltd.com,sobti@jctltd.com "
        ElseIf ddlHoldBy.SelectedItem.Text = "WareHouse" And ddlPlant.SelectedItem.Text = "Cotton" Then
            CCList = "neeraj@jctltd.com,sobti@jctltd.com "
        End If


        Dim SPerson As String
        SPerson = ObjFun.FetchValue("SELECT E_MailID FROM mistel WHERE empcode IN (SELECT  RTRIM(LEFT(sale_person_code,1)+'-' + SUBSTRING(sale_person_code,2,LEN(sale_person_code))) FROM    miserp.som.dbo.jct_so_team_catg a ( NOLOCK ) WHERE   a.order_no = '" & txtOrderNo.Text & "')")



        Dim Status As Boolean = False
        Try


            If ddlHoldState.SelectedIndex = 0 Then
                Qry = "Insert into Jct_Ops_Hold_Orders(UserCode,OrderNo,Item,LINEItem,Shade,Stage,HoldBy,HoldFlag,HoldTillDate,HoldDate ,HoldOnHost ,Reason ,STATUS,HoldMeters,HoldState) values('" & Session("EmpCode") & "','" & txtOrderNo.Text & "','" & Trim(lblSort.Text) & "','" & ddlItems.SelectedItem.Text & "','" & lblLineNo.Text & "','" & DdlHOldAt.SelectedItem.Text & "','" & ddlHoldBy.SelectedItem.Text & "','T','" & txtDate.Text & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtReason.Text & "','A'," & txtHoldMeters.Text & ",'" & Left(ddlHoldState.SelectedItem.Text, 1) & "')"
            Else
                Qry = "Insert into Jct_Ops_Hold_Orders(UserCode,OrderNo,Item,LINEItem,Shade,Stage,HoldBy,HoldFlag,HoldTillDate,HoldDate ,HoldOnHost ,Reason ,STATUS,HoldMeters,HoldState) values('" & Session("EmpCode") & "','" & txtOrderNo.Text & "','" & Trim(lblSort.Text) & "','" & ddlItems.SelectedItem.Text & "','" & lblLineNo.Text & "','" & DdlHOldAt.SelectedItem.Text & "','" & ddlHoldBy.SelectedItem.Text & "','T','" & txtDate.Text & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtReason.Text & "','A'," & txtHoldMeters.Text & ",'" & Left(ddlHoldState.SelectedItem.Text, 1) & "')"
            End If
            Status = ObjFun.InsertRecord(Qry)
            If Status = False Then Throw New Exception
            Scrpt = "Your Order " & txtOrderNo.Text & " with Item " & Trim(lblSort.Text) & " have been put on hold. For Furhter Details Check OPS"
            Qry = "SELECT E_MailID,'' FROM mistel WHERE empcode IN ('a-00098')"
            ' ObjSendMail.SendMail(ToEMail, ByEmailID, "Your Order Put On Hold .....!!!!", "Your Order " & txtOrderNo.Text & " with Item " & lblSort.Text & " have been put on hold. For Furhter Details Check OPS ")
            ' ObjSendMail.SendMail(ToEMail, ByEmailID, "Your Order Put On Hold .....!!!!", body)
            SendMail(body, SPerson, Session("Empcode"), CCList, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your Order " & txtOrderNo.Text & " with Item " & lblSort.Text & " have been put on hold. For Furhter Details Check OPS ")
            GrdSavedOrders.DataSource = Nothing
            GrdSavedOrders.DataBind()

            GrdSavedOrders.DataSourceID = "SqlDataSource1"
            GrdSavedOrders.DataBind()
        Catch ex As Exception
            Scrpt = "Some Error Occured !! Record Not Saved"

        Finally
            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
            ObjFun.Alert(Scrpt)

        End Try
    End Sub

    Protected Sub CmdRelease_Click(sender As Object, e As System.EventArgs) Handles CmdRelease.Click
        Try
            Qry = "Update Jct_Ops_Hold_Orders set HoldFlag='F',ReleaseFlag='T',ReleasedOn=getdate(),ReleasedByUser='" & Session("Empcode") & "',ReleasedOnHost='" & Request.ServerVariables("RMOTE_ADDR") & "' where orderno='" & txtOrderNo.Text & "' and lineitem=" & ddlItems.SelectedItem.Text & " and item='" & lblSort.Text & "'"
            Status = ObjFun.UpdateRecord(Qry)
            ToEMail = "ashish@jctltd.com;jagdeep@jctltd.com;harendra@jctltd.com"
            ByEmailID = "noreply@jctltd.com"

            Dim body As String = "<p>Hello,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your order has been Released for the production Cycle.</p> Release Order Request is genrated by " & Session("empname") & "  with </p> <H3>Order No. " & txtOrderNo.Text & "  </H3>  </p> <p> <H3>  Sort No. " & lblSort.Text & " .</p> <p>  Shade " & lblLineNo.Text & " </H3>  </p> <p></p><p><H3> It was Held till Date:  " & txtDate.Text & "</H3> </p><p> <H3> Additional Info :-<br><br> Customer " & lblCustomerName.Text & "</br>   SalePerson " & lblSalePerson.Text & "</p></H3></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

            If Status = False Then Throw New Exception
            Scrpt = "Your Order " & txtOrderNo.Text & " with Item " & Trim(lblSort.Text) & " have been put on hold. For Furhter Details Check OPS"
            Qry = "SELECT E_MailID,'' FROM mistel WHERE empcode IN ('a-00098')"
            ' ObjSendMail.SendMail(ToEMail, ByEmailID, "Your Order Put On Hold .....!!!!", "Your Order " & txtOrderNo.Text & " with Item " & lblSort.Text & " have been put on hold. For Furhter Details Check OPS ")
            ObjSendMail.SendMail(ToEMail, ByEmailID, "Your Order is Released .....!!!!", body)
            GrdSavedOrders0.DataSource = Nothing
            GrdSavedOrders0.DataBind()

            GrdSavedOrders0.DataSourceID = "SqlDataSource1"
            GrdSavedOrders0.DataBind()
        Catch ex As Exception
            Scrpt = "Some Error Occured !! Record Not Saved"

        End Try
    End Sub

    Protected Sub GrdSavedOrders_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdSavedOrders.SelectedIndexChanged
        With GrdSavedOrders
            txtOrderNo.Text = .SelectedRow.Cells(1).Text
            txtReason.Text = .SelectedRow.Cells(9).Text
            txtDate.Text = .SelectedRow.Cells(7).Text
            ' txtOrderNo_TextChanged(sender, e)

            Qry = "SELECT distinct line_no,Line_no FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' AND a.item_no='" & .SelectedRow.Cells(2).Text & "' AND b.line_no='" & .SelectedRow.Cells(3).Text & "' "
            ObjFun.FillList(ddlItems, Qry)

            Qry = "SELECT DISTINCT b.cust_name AS CustomerName ,e.group_desc AS SalePerson FROM  production..jct_process_issue_gry_det a LEFT OUTER JOIN miserp.som.dbo.t_order_hdr c ON a.po_num = c.order_no LEFT OUTER JOIN miserp.som.dbo.m_customer b ON c.bill_cust_no = b.cust_no INNER JOIN miserp.som.dbo.jct_so_team_catg d on c.order_no=d.order_no LEFT OUTER JOIN miserp.som.dbo.m_cust_group e ON e.group_no=d.sale_person_code WHERE   a.po_num LIKE '" & txtOrderNo.Text & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Dr = Cmd.ExecuteReader
            Dr.Read()
            If Dr.HasRows = True Then
                lblSalePerson.Text = Dr.Item("SalePerson")
                lblCustomerName.Text = Dr.Item("CustomerName")
            End If
            ddlItems_SelectedIndexChanged(Nothing, Nothing)



        End With

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  txtOrderNo.Attributes.Add("onKeyPress", "doClick('" + BtnFetch.ClientID + "',event)")
            txtOrderNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + BtnFetch.UniqueID + "').click();return false;}} else {return true}; ")
        End If
    End Sub

    Protected Sub BtnFetch_Click(sender As Object, e As System.EventArgs) 'Handles BtnFetch.Click
        Qry = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "

        ObjFun.FillGrid(Qry, GridView1)
        'Con.Open()
        'Dim ds As DataSet = New DataSet()
        'Dim Da As SqlDataAdapter = New SqlDataAdapter(Qry, Con)
        'Da.SelectCommand.CommandTimeout = 0
        'Da.Fill(ds)
        'GridOrderDetail.DataSource = ds.Tables(0)
        'GridOrderDetail.DataBind()

        '--Item FetchQry = "SELECT  Item_no,Item_no FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        Qry = "SELECT distinct line_no,Line_no FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' "
        ObjFun.FillList(ddlItems, Qry)

        Qry = "SELECT DISTINCT b.cust_name AS CustomerName ,e.group_desc AS SalePerson FROM  production..jct_process_issue_gry_det a LEFT OUTER JOIN miserp.som.dbo.t_order_hdr c(nolock) ON a.po_num = c.order_no LEFT OUTER JOIN miserp.som.dbo.m_customer b ON c.bill_cust_no = b.cust_no INNER JOIN miserp.som.dbo.jct_so_team_catg d on c.order_no=d.order_no LEFT OUTER JOIN miserp.som.dbo.m_cust_group e ON e.group_no=d.sale_person_code WHERE   a.po_num LIKE '" & txtOrderNo.Text & "'"
        Cmd = New SqlCommand(Qry, Obj.Connection)
        Dr = Cmd.ExecuteReader
        Dr.Read()
        If Dr.HasRows = True Then
            lblSalePerson.Text = Dr.Item("SalePerson")
            lblCustomerName.Text = Dr.Item("CustomerName")
        End If
        ddlItems_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub ddlHoldState_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlHoldState.SelectedIndexChanged
        If ddlHoldState.SelectedIndex = 0 Then
            MEV6.Enabled = True
        Else
            MEV6.Enabled = False
        End If
    End Sub

     Private Sub SendMail(Body As String, Sperson As String, [to] As String, cc As String, bcc As String, Subject As String)
        Try
            Dim from As String
            from = "noreply@jctltd.com"
            Dim query As String = ""
            Dim SenderEmail As String = ""

            If Sperson Is Nothing Then
                Sperson = ""
            End If

            query = "SELECT isnull(E_MailID,'') FROM MISTEL WHERE empcode='" & Session("EmpCode") & "' "
            SenderEmail = ObjFun.FetchValue(query)

            If SenderEmail Is Nothing Then SenderEmail = ""

            If SenderEmail <> "" Then

                'Email Address of Receiver
                [to] = SenderEmail & "," & Sperson

            Else
                [to] = Sperson

            End If


            bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"


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
            If Not String.IsNullOrEmpty(cc) Then
                If cc.Contains(",") Then
                    Dim ccs As String() = cc.Split(","c)
                    For i As Integer = 0 To ccs.Length - 1
                        mail.CC.Add(New MailAddress(ccs(i)))
                    Next
                    'Else
                    '    mail.CC.Add(New MailAddress(bcc))
                End If
                mail.CC.Add(New MailAddress(cc))
            End If

            mail.Subject = Subject
            mail.Body = Body
            mail.IsBodyHtml = True
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            '       MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
            '/* Attach the newly created email attachment */      
            'mailMessage.Attachments.Add(attach);






            Dim SmtpMail As New SmtpClient("exchange2007")

            '
            SmtpMail.Send(mail)
        Catch ex As Exception
            Dim Scrpt As String = "alert('" + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
        End Try
    End Sub
End Class
