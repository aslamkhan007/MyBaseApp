Imports System.Data
Imports System.Data.SqlClient

Imports System.Net.Mail


Partial Class OPS_ODS_Request_Genration
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objfun As Functions = New Functions
    Dim toEMail As String = "ashish@jctltd.com;jagdeep@jctltd.com;harendra@jctltd.com;rbaksshi@jctltd.com"
    Dim byEmailID As String = "noreply@jctltd.com"
    Dim objSendMail As SendMail = New SendMail
    Dim scrpt As String
    Dim empCode As String

    Dim obj As Connection = New Connection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction
    Dim Meters As Double, yards As Double, gr_wt As Double, net_wt As Double = 0.0
    Dim TmpMeters As Double = 0.0



    Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        'qry = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        ''''''''''qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1'"
        'objfun.FillGrid(qry, GridView1)
        'qry = "SELECT line_no AS [LineNo],attb_discrete+' :: '+CONVERT(VARCHAR,line_no) FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        '''''''''''''''qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1'"
        'objfun.FillList(chkItemList, qry)
        qry = "Exec JCT_OPS_FETCH_NEW_SALEORDER_DETAILS '" & txtOrderNo.Text & "'"
        objfun.FillGrid(qry, GridView1)

        Dim Dbase As String
        Dbase = ddlRequestType.SelectedItem.Value
        Dbase = Dbase.Substring(0, Dbase.IndexOf(".."))
        Dim Proc As String = ddlRequestType.SelectedItem.Value
        Dim I As Int16 = Proc.IndexOf("..") + 2
        Proc = Proc.Substring(I, Len(Proc) - I - 1)
        Dim Cn As String = ""

        Cn = "Data Source=Miserp;Initial Catalog=" & Dbase & ";Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 0;"

        Dim SqlCon As SqlConnection = New SqlConnection(Cn)
        qry = "exec " & Proc & " 'JCT00LTD', 'PHG', 1,  '','','','" & txtOrderNo.Text & "','Y' "
        Dim ds As DataSet = New DataSet()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(qry, SqlCon)


        Da.SelectCommand.CommandTimeout = 0
        Da.Fill(ds)
        'Grd.DataSource = ds
        GrdPackedForOrder.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
        GrdPackedForOrder.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  txtOrderNo.Attributes.Add("onKeyPress", "doClick('" + BtnFetch.ClientID + "',event)")
            txtOrderNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + cmdSearch.UniqueID + "').click();return false;}} else {return true}; ")
            qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "'"
            objfun.DeleteRecord(qry)
            qry = "SELECT ProcUsed+convert(varchar,isnull(ReqTypeCode,0)),ReqAreaName FROM Jct_Ops_Request_Area_Master order by ReqTypeCode"
            objfun.FillList(ddlRequestType, qry)
            ddlRequestType_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Protected Sub CmdSearchData_Click(sender As Object, e As System.EventArgs) Handles CmdSearchData.Click
        'Dim Con As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("IMSDBConnectionString").ConnectionString
        Dim Dbase As String
        Dbase = ddlRequestType.SelectedItem.Value
        Dbase = Dbase.Substring(0, Dbase.IndexOf(".."))
        Dim Proc As String = ddlRequestType.SelectedItem.Value
        Dim I As Int16 = Proc.IndexOf("..") + 2
        Proc = Proc.Substring(I, Len(Proc) - I - 1)
        Dim Cn As String = ""

        Cn = "Data Source=Miserp;Initial Catalog=" & Dbase & ";Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 0;"

        Dim SqlCon As SqlConnection = New SqlConnection(Cn)
        If txtSaleOrder.Text = "" Then
            qry = "exec " & Proc & " 'JCT00LTD', 'PHG', 1,  '" & txtSort.Text & "','" & txtVariant.Text & "','" & txtShade.Text & "','" & txtOrderNo.Text & "','N'"
        Else
            qry = "exec " & Proc & " 'JCT00LTD', 'PHG', 1,  '" & txtSort.Text & "','" & txtVariant.Text & "','" & txtShade.Text & "','" & txtSaleOrder.Text & "','N'"
        End If
        Dim ds As DataSet = New DataSet()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(qry, SqlCon)


        Da.SelectCommand.CommandTimeout = 0
        Da.Fill(ds)
        'Grd.DataSource = ds
        GrdBasicDetail.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
        GrdBasicDetail.DataBind()
    End Sub

    Protected Sub CmdApply_Click(sender As Object, e As System.EventArgs) Handles CmdApply.Click
        Dim FileName As String = ""

        Dim i As Int16
        i = 0
        Dim ParmCode As String = ""
        Dim SanctionID As String = ""
        Dim ddlVal As String = ""
        Dim EmpCode As String
        Dim index As Int16 = 0
        Dim EmpName As String = ""
        EmpCode = Trim(Session("Empcode"))
        Dim Genratedby_Email As String = "", GenratedByName As String = ""
        Dim Cmd2 As SqlCommand = New SqlCommand
        Dim Str As String
        Dim body As String, Body1 As String, Body2 As String = "", Body3 As String = ""
        Dim ParmName As String = ""
        Dim ToList As String = ""
        Dim Mtrs As Int64

        Dim PackedIn As String
        '--, PackedInLine As String
        Dim ItemNo As String, BaleNo As String, Variant1 As String, Remarks As String, OrderVar As String

        'Dim CurrentSellingPrice As Double
        Dim TransID As Int32 = 0
        Dim AuthMob As String = ""

        Tran = obj.Connection.BeginTransaction
        Try
            If LCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "ods" And GrdEmployee.Rows.Count = 0 Then
                Throw New Exception("No Authorization hierarchy is Present for: - " & ddlRequestType.SelectedItem.Text)
            End If
            qry = "exec Jct_Ops_ODS_Request_GenrateRequestID"
            SanctionID = objfun.FetchValue(qry, obj.Connection, Tran)

            Body1 = Body1 & " <hr> Description :- " & txtDescription.Text & "<hr> "
            qry = " exec Jct_Ops_ODS_Insert_HDR '" & Session("Empcode") & "','1028','" & txtSubject.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & SanctionID & "','" & ddlPlant.SelectedItem.Text & "','" & ddlRequestType.SelectedItem.Text & "','" & ddlMode.SelectedItem.Text & "','" & ddlFreightType.SelectedItem.Text & "','" & ddlDocsSentTo.SelectedItem.Text & "'"
            objfun.InsertRecord(qry, Tran, obj.Connection)
            With GrdTempValues
                OrderVar = ""
                qry = ""

                Dim EmpLevelCount As Int16 = 0
                EmpLevelCount = ChkDynamicListing.Items.Count

                If GrdEmployee.Rows.Count > 1 Then

                    For i = 0 To ChkDynamicListing.Items.Count - 1
                        qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_TEST(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL) values('" & SanctionID & "','" & Session("empcode") & "','1028','" & ChkDynamicListing.Items(i).Value & "'," & i + 1 & ")"
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.Transaction = Tran
                        cmd.ExecuteNonQuery()
                    Next


                    


                    qry = "exec Jct_Ops_Request_InsertDynamic_User '" & SanctionID & "','" & Session("empcode") & "',1028," & EmpLevelCount & ",'" & ddlPlant.SelectedItem.Text & "'," & Right(ddlRequestType.SelectedItem.Value, 1) & ""
                    objfun.InsertRecord(qry, Tran, obj.Connection)



                    For i = 0 To chkNotify.Items.Count - 1
                        qry = "INSERT INTO dbo.Jct_Ops_SanctionNote_Notify_Test( Usercode ,SanctionID ,NotifyUser , CreatedDate) values('" & Session("Empcode") & "','" & SanctionID & "','" & chkNotify.Items(i).Value & "',getdate())"
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.Transaction = Tran
                        cmd.ExecuteNonQuery()
                    Next
                End If
            End With
            Tran.Commit()

            objfun.Alert("Record Saved Sucessfully !!")

            qry = "Select SourceOrder as PackedIn, Item_no as SortNo, Bale_no as BaleNo,Variant,Meters from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("empcode") & "' "
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Body1 = "<br>Space(10) "
                '-- Genratedby_Email = Genratedby_Email & "," & dr.Item(2)
                'Body3 = "<br><br><hr> This is Pending At <b>" & dr.Item(1) & " </b> "
            End If
            dr.Close()
            obj.ConClose()


            qry = "SELECT isnull(E_MailID,''),name FROM dbo.MISTEL WHERE empcode='" & EmpCode & "' "
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                Genratedby_Email = dr.Item(0)
                GenratedByName = dr.Item(1)
            End If
            dr.Close()
            obj.ConClose()

            'SELECT DISTINCT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='100000'
            Dim NotifyEmailGroup As String = "Noreply@jctltd.com"
            qry = "SELECT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='" & SanctionID & "'"
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
                End While
            End If
            body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br> " & ddlRequestType.SelectedItem.Text & " with ID <b>" & SanctionID & " </b> has been genrated  With Following Detail "
            'GenrateMail(body, Body1, Body2, Body3, SanctionID, GenratedByName, Genratedby_Email, NotifyEmailGroup, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your " & ddlRequestType.SelectedItem.Text & " No :-" & SanctionID & " has been genrated ", SanctionID, "a")
            GenrateMail("hi", "a", "a", "a", "a", "a", "a", "a", "a", "a", "100008", "Ashish", ddlMode.SelectedItem.Text, ddlFreightType.SelectedItem.Text, ddlDocsSentTo.SelectedItem.Text, GenratedByName)

            lblID.Text = SanctionID
            CmdApply.Enabled = False

        Catch ex As Exception
            FileName = "Unable to Complete Transaction " & ex.Message
            objfun.Alert(FileName)
            Tran.Rollback()
            'MessageBox1.ShowError("Unable to Complete Transaction " & ex.ToString)

            Exit Sub
        End Try
   


    End Sub

    Protected Sub cmdSearchEmployee_Click(sender As Object, e As System.EventArgs) Handles cmdSearchEmployee.Click
        qry = "SELECT empcode,empname+'~'+b.DEPTNAME FROM JCT_EmpMast_Base a,DEPTMAST b WHERE empname LIKE '%" & txtEmployee.Text & "%' AND Active='y' AND a.deptcode=b.DEPTCODE ORDER BY empname"
        objfun.FillList(ChkEmpList, qry)
    End Sub
    Protected Sub btnTransfer_Click(sender As Object, e As System.EventArgs) Handles btnTransfer.Click
        Dim litem As ListItem
        For i As Int16 = 0 To ChkEmpList.Items.Count - 1
            If ChkEmpList.Items(i).Selected = True Then
                litem = New ListItem(ChkEmpList.Items(i).Text, ChkEmpList.Items(i).Value)
                ChkDynamicListing.Items.Add(litem)
            End If
        Next
    End Sub
    Protected Sub cmdCC_Click(sender As Object, e As System.EventArgs) Handles cmdCC.Click
        Dim litem As ListItem
        For i As Int16 = 0 To ChkEmpList.Items.Count - 1
            If ChkEmpList.Items(i).Selected = True Then
                litem = New ListItem(ChkEmpList.Items(i).Text, ChkEmpList.Items(i).Value)
                chkNotify.Items.Add(litem)
            End If
        Next
    End Sub

    'Protected Sub CmdAddItem_Click(sender As Object, e As System.EventArgs) Handles CmdAddItem.Click
    '    Dim i As Int16
    '    Try
    '        With GrdBasicDetail
    '            For i = 0 To .Rows.Count - 1
    '                If CType(.Rows(i).FindControl("chkBox"), CheckBox).Checked = True Then
    '                    qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate] values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "')"
    '                    'objfun.InsertRecord(qry)
    '                    cmd = New SqlCommand(qry, obj.Connection)
    '                    cmd.ExecuteNonQuery()
    '                End If
    '            Next
    '        End With
    '        With GrdPackedForOrder
    '            For i = 0 To .Rows.Count - 1
    '                If CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked = True Then
    '                    qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate] values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "')"
    '                    'objfun.InsertRecord(qry)
    '                    cmd = New SqlCommand(qry, obj.Connection)
    '                    cmd.ExecuteNonQuery()
    '                End If
    '            Next
    '            .DataSource = Nothing
    '            .DataBind()
    '        End With

    '    Catch

    '    Finally
    '        qry = "SELECT SourceOrder as PackedIn ,Item_no ,Bale_No ,Varaint ,Meters  from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "'"
    '        objfun.FillGrid(qry, GrdTempValues)
    '    End Try
    'End Sub

    'Protected Sub cmdDeleteRows_Click(sender As Object, e As System.EventArgs) Handles cmdDeleteRows.Click
    '    Dim i As Int16
    '    Try
    '        With GrdTempValues
    '            For i = 0 To .Rows.Count - 1
    '                If CType(.Rows(i).FindControl("ChkDelete"), CheckBox).Checked = True Then
    '                    qry = "Delete from  Jct_Ops_Transfer_Request_Intermediate where UserCode='" & Session("Empcode") & "' and bale_no='" & Trim(.Rows(i).Cells(3).Text) & "' "
    '                    'objfun.InsertRecord(qry)
    '                    cmd = New SqlCommand(qry, obj.Connection)
    '                    cmd.ExecuteNonQuery()
    '                End If
    '            Next
    '        End With
    '    Catch

    '    Finally
    '        qry = "Select  SourceOrder as PackedIn ,Item_no ,Bale_No ,Varaint ,Meters from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "' "
    '        objfun.FillGrid(qry, GrdTempValues)
    '    End Try
    'End Sub

    Protected Sub ddlRequestType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlRequestType.SelectedIndexChanged
        Dim ReqCode As Int16 = 0

        GrdBasicDetail.DataSource = Nothing
        GrdBasicDetail.DataBind()

        qry = "SELECT  ReqTypeCode FROM Jct_Ops_Request_Area_Master WHERE ReqAreaName='" & ddlRequestType.SelectedItem.Text & "'"
        ReqCode = objfun.FetchValue(qry)
        qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_Request_Area_Hierarchy a ,dbo.JCT_EmpMast_Base C WHERE  a.reqtypeCode=" & ReqCode & " AND c.empcode = a.empcode AND a.plant = '" & ddlPlant.SelectedItem.Text & "'  ORDER BY AuthLevel"
        objfun.FillGrid(qry, GrdEmployee)

    End Sub

    Private Sub GenrateMail(Body As String, Body1 As String, Body2 As String, Body3 As String, OrderNo As String, SalesPerson_Name As String, [to] As String, cc As String, bcc As String, Subject As String, ID As String, PendingAt As String, DespatchMode As String, FreightType As String, DocsLocation As String, GenratedBy As String)
        Dim from As String ', body__2 As String
        from = "noreply@jctltd.com"
        Dim query As String = ""
        Dim sb As New StringBuilder()
        Dim SenderEmail As String = ""
        ' toastr.info('Are you the 6 fingered man?')
        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<style type=""text/css"">")
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head>")


        sb.AppendLine("Hi,<i>You are receiving this email on the behalf of Automated E-Mail Alert System.</i><br/><br/>")
        sb.AppendLine("Request for " + ddlRequestType.SelectedItem.Text + " has been genrated by <b> Mr/Ms/Mrs. " & GenratedBy & " <br/><br/> on the behalf of Mr/Ms/Mrs <b>" + SalesPerson_Name + "</b> ")
        sb.AppendLine("RequestID for your request is : " + ID + " <br/><br/>")



        sb.AppendLine("<B>Request Raise For </b>")

        sb.AppendLine("<table class=gridtable>")
        Dim J As Int16 = 0
        'body__2 = Body__1
        With GridView1


            For i = 0 To GridView1.Rows.Count - 1
                'If i = 0 Then
                query = "<tr>"
                If (.Rows(i).RowType = DataControlRowType.Header) Then
                    query += "<th>Ashish</th>"
                End If
               


                'Else
                '    query = "<tr>"
                'End If
                For J = 1 To 10 '.Columns.Count
                    If i = 0 Then
                        query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                    Else
                        query += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                    End If
                Next

                'If i = 0 Then
                '    sb.AppendLine(query & " </tr>")
                'Else
                '    sb.AppendLine(query & " </tr>")
                'End If
                sb.AppendLine(query & " </tr>")
            Next
        End With
        sb.AppendLine("</table>")
        sb.AppendLine("<br />")
        '  sb.AppendLine("<tr><th> OrderNo</th> <th> SaleP.Code</th> <th> SalePCode</th> <th> SalePersonName</th> <th> Sort</th>   <th> Line</th> <th> SHade</th>  </tr>")

        sb.AppendLine("" & DespatchMode & "<br/><br/>")
        sb.AppendLine("<b>Customer Name :-</b>")
        sb.AppendLine("" & FreightType & "<br/><br/>")
        sb.AppendLine("<B> Request for Order No :- </B>")
        sb.AppendLine("" & DocsLocation & "<br/><br/>")




        sb.AppendLine("Details are Shown below : *       <br/><br/>")
        sb.AppendLine("<table class=gridtable>")

        'body__2 = Body__1
        sb.AppendLine("<tr><th> PackedIn</th> <th> SortNo</th> <th> BaleNo</th> <th> Variant</th> <th> Meters</th>   <th> Auth. Pending At</th> </tr>")
        qry = "Select SourceOrder as PackedIn, Item_no as SortNo, Bale_no as BaleNo,Varaint as Variant,Meters from Jct_Ops_Transfer_Request_Intermediate where Usercode='R-03339'" 'Usercode='" & Session("empcode") & "' "
        cmd = New SqlCommand(qry, obj.Connection) '
        dr = cmd.ExecuteReader
        While (dr.Read())
            If Left(LCase(ddlRequestType.SelectedItem.Text), 3) = "ods" Then
                sb.AppendLine("<tr> <td> " & dr(0).ToString & " </td> <td> " & dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  <td>" & dr(3).ToString & " </td>  <td>" & dr(4).ToString & " </td><td>Ashish</td> </tr> ")
            Else
                sb.AppendLine("<tr><th> PackedIn</th> <th> SortNo</th> <th> BaleNo</th> <th> Variant</th> <th> Meters</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")
                ' sb.AppendLine("<tr> <td> " & dr(0).ToString & " </td> <td> " & dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  <td>" & dr(3).ToString & " </td>  <td>" & dr(4).ToString & " </td>  <td>" & dr(5).ToString & "</td>  <td>" & Pending & "</td> </tr> ")
            End If
            '-- Genratedby_Email = Genratedby_Email & "," & dr.Item(2)
            'Body3 = "<br><br><hr> This is Pending At <b>" & dr.Item(1) & " </b> "
        End While
        dr.Close()
        obj.ConClose()
        sb.AppendLine("</table>")
        sb.AppendLine("<br />")
        sb.AppendLine("<B>Mode of Despatch :-</b>")
        sb.AppendLine("" & DespatchMode & "<br/><br/>")
        sb.AppendLine("<b>Freight Type :-</b>")
        sb.AppendLine("" & FreightType & "<br/><br/>")
        sb.AppendLine("<B>Documents to be Sent to :- </B>")
        sb.AppendLine("" & DocsLocation & "<br/><br/>")
        sb.AppendLine("This request is genrated by <b> " & GenratedBy & "</b><br/><br/>")

        sb.AppendLine("</table><br />")
        sb.Append("<a href='http://misdev/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br />")
        sb.AppendLine("<i>This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br /></i>")
        sb.AppendLine("</html>")


        sb.AppendLine("<br/><br />")
        [to] = "ashish@jctltd.com," & [to]
        bcc = "ashish@jctltd.com"
        cc = "ashish@jctltd.com,rbaksshi@jctltd.com"
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
        mail.Body = sb.ToString 'Body & Body1 & Body2 & Body3
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2007")


        SmtpMail.Send(mail)
    End Sub

    Protected Sub GrdPackedForOrder_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdPackedForOrder.RowDataBound
        With GrdPackedForOrder
            If e.Row.RowType = DataControlRowType.DataRow Then

                Meters += Val(e.Row.Cells(7).Text)
                yards += Val(e.Row.Cells(8).Text)
                gr_wt += Val(e.Row.Cells(9).Text)
                net_wt += Val(e.Row.Cells(10).Text)
            ElseIf e.Row.RowType = DataControlRowType.Footer Then

                'Dim lblGryMtrs As Label
                ' CType(e.Row.FindControl("lblGryMtrs"), Label).Text = Meters
                e.Row.Cells(6).Text = "Total"
                e.Row.Cells(7).Text = Meters
                e.Row.Cells(8).Text = yards
                e.Row.Cells(9).Text = gr_wt
                e.Row.Cells(10).Text = net_wt
            End If
        End With
    End Sub

    Protected Sub GrdTempValues_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdTempValues.RowDataBound
        With GrdTempValues
            If e.Row.RowType = DataControlRowType.DataRow Then

                TmpMeters += Val(e.Row.Cells(5).Text)
                'yards += Val(e.Row.Cells(8).Text)
                'gr_wt += Val(e.Row.Cells(9).Text)
                'net_wt += Val(e.Row.Cells(10).Text)
            ElseIf e.Row.RowType = DataControlRowType.Footer Then

                'Dim lblGryMtrs As Label
                ' CType(e.Row.FindControl("lblGryMtrs"), Label).Text = Meters
                e.Row.Cells(4).Text = "Total"
                e.Row.Cells(5).Text = TmpMeters
                
            End If
        End With
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click

        Dim NotifyEmailGroup As String = "Noreply@jctltd.com"
        qry = "SELECT DISTINCT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='100000'"
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read
                NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
            End While
        End If
        dr.Close()

        GenrateMail("hi", "a", "a", "a", "a", "a", NotifyEmailGroup, "a", "a", "Your Request has been Genrated ", "100008", "Ashish", ddlMode.SelectedItem.Text, ddlFreightType.SelectedItem.Text, ddlDocsSentTo.SelectedItem.Text, "Ashish Sharma")
    End Sub

   
    Protected Sub imgAddRow_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgAddRow.Click
        Dim i As Int16
        Try
            With GrdBasicDetail
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("chkBox"), CheckBox).Checked = True Then
                        qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate] values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(10).Text) & "','A')"
                        'objfun.InsertRecord(qry)
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End With
            With GrdPackedForOrder
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked = True Then
                        qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate] values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(10).Text) & "','A')"
                        'objfun.InsertRecord(qry)
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                    End If
                Next
                .DataSource = Nothing
                .DataBind()
            End With

        Catch

        Finally
            qry = "SELECT SourceOrder as PackedIn ,Item_no ,Bale_No ,Varaint ,Meters  from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "'"
            objfun.FillGrid(qry, GrdTempValues)
        End Try
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim i As Int16
        Try
            With GrdTempValues
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("ChkDelete"), CheckBox).Checked = True Then
                        qry = "Delete from  Jct_Ops_Transfer_Request_Intermediate where UserCode='" & Session("Empcode") & "' and bale_no='" & Trim(.Rows(i).Cells(3).Text) & "' "
                        'objfun.InsertRecord(qry)
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End With
        Catch

        Finally
            qry = "Select  SourceOrder as PackedIn ,Item_no ,Bale_No ,Varaint ,Meters from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "' "
            objfun.FillGrid(qry, GrdTempValues)
        End Try
    End Sub
End Class
