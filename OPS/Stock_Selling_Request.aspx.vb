Imports System
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports System.Web
Partial Class OPS_Stock_Selling_Request
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim tran As SqlTransaction
    'Dim Tran As SqlTransaction
    'Dim ObjSendMail As SendMail
    Protected Sub CmdSearchData_Click(sender As Object, e As System.EventArgs) Handles CmdSearchData.Click
        ClearAllGrid()
        txtSearchCustomer.Text = ""
        ddlShipmentAddress.Items.Clear()
        LblAddress.Text = ""
        txtRemarks.Text = ""
        qry = "Exec Jct_Ops_Devlopment_Fetch_ODS_Bales '" & txtSearchSaleOrder.Text & "','" & txtSearchSort.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "','','" & Session("EmpCode") & "'"
        objFun.FillGrid(qry, GrdBasicDetail)


    End Sub

    'Protected Sub imgAddRow_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgAddRow.Click

    'End Sub
    Protected Sub imgAddRow_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgAddRow.Click
       
        Dim i As Int16
        Try
            With GrdBasicDetail
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("chkSelection"), CheckBox).Checked = True Then
                        'Dim str() As String
                        'str = ddlRequestType.SelectedItem.Text.Split("~")
                        qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "'," & Trim(.Rows(i).Cells(6).Text) & ",'I'"

                        'If str(0).ToUpper <> "EXCESS STOCK" Then
                        '    qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "' and Bale_No='" & Trim(.Rows(i).Cells(3).Text) & "'"
                        'Else
                        '    qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "' and Bale_No='" & Trim(.Rows(i).Cells(4).Text) & "'"
                        'End If
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()

                        'If ddlRequestType.SelectedItem.Text = "ODS Stock Sell~1033" Then
                        '    qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate](Usercode ,SourceOrder ,Item_no ,Bale_No ,Varaint ,Meters) values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(8).Text) & "')"
                        'ElseIf str(0).ToUpper = "EXCESS STOCK" Then
                        '    qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate](Usercode ,SourceOrder ,Item_no ,Bale_No ,Varaint ,Meters,Shade) values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(8).Text) & "','" & Trim(.Rows(i).Cells(4).Text) & "')"
                        'Else

                        '    qry = "exec Jct_Ops_Transfer_Request_Intermediate_Insert '" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(10).Text) & "','A'"
                        'End If

                        'cmd = New SqlCommand(qry, obj.Connection)
                        'cmd.ExecuteNonQuery()
                    End If
                Next
            End With


        Catch

        Finally
            qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'R'"
            objFun.FillGrid(qry, GrdTempValuesBaleDEtail)
            'R stand for Read Data
            qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'C'"
            objFun.FillGrid(qry, GrdTempValues)
            qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'S'"
            objFun.FillGrid(qry, GrdSummary)
            'If LCase(ddlRequestType.SelectedItem.Text) = "excess stock~1041" Then
            '    qry = "Exec Jct_Ops_Get_Excess_Stock_Items '" & Session("empcode") & "'"
            '    objFun.FillGrid(qry, GrdCostDetail)
            'End If
        End Try
    End Sub

    Protected Sub CmdSearchCust0_Click(sender As Object, e As System.EventArgs) Handles CmdSearchCust0.Click
        ''''''LblAddress.Text = ""
        '''''''If txtSearchCustomer.Text.Substring(
        ''''''If txtSearchCustomer.Text <> "" Then
        ''''''    Dim Cust As String() = txtSearchCustomer.Text.Split("~")
        ''''''    qry = "SELECT   b.cust_no,address_1 + ' , ' + address_2 +' , ' + address_3 + ' , ' +  state +  ' , ' + country FROM  miserp.som.dbo.m_cust_address b(nolock) WHERE  b.cust_no='" & Cust(1).ToString & "'  "
        ''''''    objFun.FillList(ddlShipmentAddress, qry)
        ''''''    ddlShipmentAddress_SelectedIndexChanged(sender, e)
        ''''''Else

        ''''''End If




        LblAddress.Text = ""
        'If txtSearchCustomer.Text.Substring(
        If txtSearchCustomer.Text <> "" Then
            Dim Cust As String() = txtSearchCustomer.Text.Split("~")
            'If txtSearchCustomer.Text.Substring(0, 1) = "~" ThentxtSearchCustomer.Text.Contains("~")
            If txtSearchCustomer.Text.Contains("~") = True Then
                qry = "SELECT   b.cust_no,address_1 + ' , ' + address_2 +' , ' + address_3 + ' , ' +  state +  ' , ' + country FROM  miserp.som.dbo.m_cust_address b(nolock) WHERE  b.cust_no='" & Cust(1).ToString & "'  "
                objFun.FillList(ddlShipmentAddress, qry)
                ddlShipmentAddress_SelectedIndexChanged(sender, e)
            Else

                qry = "SELECT   b.cust_no,address_1 + ' , ' + address_2 +' , ' + address_3 + ' , ' +  state +  ' , ' + country FROM  miserp.som.dbo.m_cust_address b(nolock) WHERE  b.cust_no='" & txtSearchCustomer.Text & "'  "
                objFun.FillList(ddlShipmentAddress, qry)

                qry = "SELECT  b.cust_name + '~' + b.cust_no FROM    miserp.som.dbo.m_customer b ( NOLOCK ) WHERE   b.cust_no='" & txtSearchCustomer.Text & "'  "
                txtSearchCustomer.Text = objFun.FetchValue(qry)

                ddlShipmentAddress_SelectedIndexChanged(sender, e)

            End If
        Else
            ddlShipmentAddress.Items.Clear()
        End If

    End Sub

    Protected Sub ddlShipmentAddress_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlShipmentAddress.SelectedIndexChanged
        LblAddress.Text = ddlShipmentAddress.SelectedItem.Value
    End Sub

    Protected Sub CmdSearchClear_Click(sender As Object, e As System.EventArgs) Handles CmdSearchClear.Click
        ddlShipmentAddress.Items.Clear()
        LblAddress.Text = ""
    End Sub

    Protected Sub CmdApply_Click(sender As Object, e As System.EventArgs) Handles CmdApply.Click
        Dim scrpt As String

        If ddlShipmentAddress.Items.Count < 1 Then
            scrpt = "alert('Please Click search button. Near Customer Name  ...');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            Return
        End If


        If GrdTempValues.Rows.Count < 1 Then
            scrpt = "alert('Invalid Data ...');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            Return
        End If





        If txtSearchCustomer.Text <> "" Then
            Dim Cust As String() = txtSearchCustomer.Text.Split("~")
            Dim CustomerName As String = ""
            qry = "SELECT ISNULL(cust_name,'') AS Cust FROM miserp.som.dbo.m_customer WHERE cust_no='" & Cust(1).ToString & "'"
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                scrpt = "alert('Invalid Customer ...');"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                Return
            End If
            obj.ConClose()

            If GrdTempValuesBaleDEtail.Rows.Count <= 0 Then
                scrpt = "alert('Please select bales to proceed......');"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                Return
            End If

            'Dim RequestID As Integer = 0
            obj.ConOpen()
            tran = obj.Connection.BeginTransaction

            'qry = " SELECT  isnull(MAX(RequestID) + 1,1001) FROM    Jct_Ops_Excess_Stock_Selling_Request_t"
            'cmd = New SqlCommand(qry, obj.Connection, tran)
            'dr = cmd.ExecuteReader
            'If dr.HasRows = True Then
            '    dr.Read()
            '    RequestID = dr.Item(0)
            '    dr.Close()
            'Else
            '    RequestID = 1001
            'End If





            Dim SanctionID As String

            Try


                qry = "SELECT TOP 1 Num FROM jctdev..JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL"
                SanctionID = objFun.FetchValue(qry, obj.Connection, tran)


                qry = "Insert into Jct_Ops_SanctionNote_HDR ( UserCode,SanctionNoteID, AreaCode,SUBJECT,DESCRIPTION,STATUS,AuthFlag,CreatedDate,CreatedOnHost,PendingAt,Plant )    " & _
                "Values('" & Session("EmpCode") & "','" & SanctionID & "',1053,'Excess Stock Selling Request','Excess Stock Selling Request','A','P',Getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','1','Cotton')"
                objFun.InsertRecord(qry, tran, obj.Connection)

                qry = "exec jctdev..Jct_Ops_SanctionNote_InsertDynamic_User_ReasonWise '" & SanctionID & "','" & Session("EmpCode") & "','1053',1,'Cotton',111"
                objFun.InsertRecord(qry, tran, obj.Connection)

                qry = " INSERT INTO JCT_OPS_SanctionNote_AUTHORIZATION_LISTING (ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL,  CREATED_ONHOST) VALUES('" & SanctionID & "','" & Session("EmpCode") & "',1053,'U-04002',1,'" & Request.ServerVariables("REMOTE_ADDR") & "')"
                objFun.InsertRecord(qry, tran, obj.Connection)


                With GrdTempValuesBaleDEtail
                    For i As Int16 = 0 To .Rows.Count - 1

                        If i = 0 Then

                            qry = "exec Jct_Ops_Excess_Stock_Sell_Generate_Request '" & SanctionID & "', '" & Session("EmpCode") & "','" & .Rows(i).Cells(1).Text & "','" & .Rows(i).Cells(2).Text & "','" & .Rows(i).Cells(5).Text & "','" & .Rows(i).Cells(3).Text & "','" & .Rows(i).Cells(4).Text & "'," & .Rows(i).Cells(6).Text & ",'" & Cust(1).ToString & "','" & Cust(0).ToString & "','" & ddlMode.SelectedItem.Text & "','" & ddlFreightType.SelectedItem.Text & "','" & ddlDocsSentTo.SelectedItem.Text & "','" & ddlShipmentAddress.SelectedItem.Value & "','" & txtTransportDetail.Text & "','" & txtRemarks.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','D'"
                            objFun.InsertRecord(qry, tran, obj.Connection)

                        End If

                        qry = "exec Jct_Ops_Excess_Stock_Sell_Generate_Request '" & SanctionID & "', '" & Session("EmpCode") & "','" & .Rows(i).Cells(1).Text & "','" & .Rows(i).Cells(2).Text & "','" & .Rows(i).Cells(5).Text & "','" & .Rows(i).Cells(3).Text & "','" & .Rows(i).Cells(4).Text & "'," & .Rows(i).Cells(6).Text & ",'" & Cust(1).ToString & "','" & Cust(0).ToString & "','" & ddlMode.SelectedItem.Text & "','" & ddlFreightType.SelectedItem.Text & "','" & ddlDocsSentTo.SelectedItem.Text & "','" & ddlShipmentAddress.SelectedItem.Value & "','" & txtTransportDetail.Text & "','" & txtRemarks.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','B'"
                        objFun.InsertRecord(qry, tran, obj.Connection)


                    Next
                End With



                qry = "UPDATE  jctdev..JCT_OPS_SanctionNote_Codes SET IsConsumed = 'Y',DateConsumed = GETDATE() WHERE   Num = '" & SanctionID & "'  "
                objFun.UpdateRecord(qry, tran, obj.Connection)




                With GrdTempValues
                    For i As Int16 = 0 To .Rows.Count - 1
                        Dim Rate_per_Mtr As String = ""
                        Dim shadeCatg As Char = ""
                        shadeCatg = (CType(.Rows(i).FindControl("ddlShadeCatg"), DropDownList).SelectedItem.Text).Trim()
                        Rate_per_Mtr = (CType(.Rows(i).FindControl("txtRate"), TextBox).Text).Trim()
                        qry = "Insert into Jct_Ops_Excess_Stock_Selling_Request_Cost_Details values('" & SanctionID & "','" & .Rows(i).Cells(0).Text & "','" & .Rows(i).Cells(1).Text & "'," & CType(Rate_per_Mtr, Double) & ",'" & shadeCatg & "')"
                        objFun.InsertRecord(qry, tran, obj.Connection)
                    Next

                End With

                qry = "Exec Production..Jct_Ops_Excess_Stock_Log_insert '','','" & Session("Empcode") & "','" & Request.ServerVariables("REMOTE_ADDR") & "','Stock Sold' ,'Z','" & SanctionID & "',''"
                cmd = New SqlCommand(qry, obj.Connection, tran)
                cmd.ExecuteNonQuery()





                tran.Commit()
                CmdApply.Enabled = False

                GrdBasicDetail.DataSource = Nothing
                GrdBasicDetail.DataBind()

                ' scrpt = "alert('Record Saved Scuessfully ...Your RequestID is '" + SanctionID + "');"
                scrpt = "alert('Record Saved Scuessfully ...');"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)


                Dim NotifyEmailGroup As String = ""

                qry = "exec Jct_Ops_Ods_GetSale_Persons '" & Session("Empcode") & "',''"
                cmd = New SqlCommand(qry, obj.Connection)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read
                        NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
                    End While
                End If
                dr.Close()

                Try

                
                GenrateMail("hi", "a", "a", "a", "a", "a", "it@jctltd.com", "a", "a", "Your Request has been Genrated ", SanctionID, "Ashish", ddlMode.SelectedItem.Text, ddlFreightType.SelectedItem.Text, ddlDocsSentTo.SelectedItem.Text) ', "Ashish Sharma", "a")
                Catch ex As Exception

                End Try






            Catch ex As Exception
                tran.Rollback()
                scrpt = "alert('Unable to save record(s) ...');"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            Finally
                obj.ConClose()
            End Try




        Else
            scrpt = "alert('Invalid Customer ...');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            Return
        End If
        qry = ""
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim i As Int16
        Try
            With GrdTempValues
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("ChkDelete"), CheckBox).Checked = True Then
                        qry = "Delete from  Jct_Ops_Transfer_Request_Intermediate where UserCode='" & Session("Empcode") & "' and bale_no='" & Trim(.Rows(i).Cells(4).Text) & "' "
                        'objfun.InsertRecord(qry)
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End With
        Catch

        Finally
            qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'R'"
            objFun.FillGrid(qry, GrdTempValuesBaleDEtail)
            'R stand for Read Data
            qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'C'"
            objFun.FillGrid(qry, GrdTempValues)
            qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'S'"
            objFun.FillGrid(qry, GrdSummary)
        End Try
    End Sub


    Private Sub GenrateMail(Body As String, Body1 As String, Body2 As String, Body3 As String, OrderNo As String, SalesPerson_Name As String, [to] As String, cc As String, bcc As String, Subject As String, ID As String, PendingAt As String, DespatchMode As String, FreightType As String, DocsLocation As String)
        Dim from As String ', body__2 As String
        Dim GenratedBy As String, GenratedbyEmail As String
        qry = "SELECT name,E_MailID FROM dbo.MISTEL WHERE empcode='" & Session("Empcode") & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read
                GenratedBy = dr.Item(0)
                GenratedbyEmail = dr.Item(1)
            End While
            dr.Close()
        End If

        from = "ods@jctltd.com"
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

        sb.AppendLine("Request for ODS Selling Stock  has been genrated by <b> Mr/Ms " & GenratedBy & " <br/><br/>  ")


        sb.AppendLine("RequestID for your request is : " + ID + " <br/><br/>")


        Dim GridHeader As String = ""
        Dim J As Int16 = 0
        Dim No_Of_Cols As Int16 = 0


        'If LCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "inv" Then
        sb.AppendLine("<table class=gridtable>")

        'body__2 = Body__1
        With GrdTempValues

            No_Of_Cols = 7
            For i = 0 To .Rows.Count - 1
                'If CType(.Rows(i).FindControl("chkSelection"), CheckBox).Checked = True Then
                'If i = 0 Then
                query = "<tr>"
                'This if is used to Fetch Header from Gridview
                If i = 0 Then
                    For J = 1 To No_Of_Cols '.Columns.Count in Grid Header row system is not able to find number of Columns in grid

                        GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"

                    Next
                    sb.AppendLine(GridHeader & " </tr>")
                End If

                'This loops feteches data from each cell of grid
                For J = 1 To No_Of_Cols '.Columns.Count
                    '  If i = 0 Then
                    'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                    If J = 3 Then
                        Dim Rate As Double = 0
                        Rate = CType(.Rows(i).FindControl("txtRate"), TextBox).Text
                        GridHeader += "<th> " & Rate & "</th>"
                        query += "<td>" & Rate & "</td>"
                    ElseIf J = 4 Then
                        Dim ShadeCatg As String = ""
                        ShadeCatg = CType(.Rows(i).FindControl("ddlShadeCatg"), DropDownList).SelectedItem.Text
                        GridHeader += "<th> " & ShadeCatg & "</th>"

                        query += "<td>" & ShadeCatg & "</td>"
                    Else
                        GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                        query += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                    End If

                Next
                sb.AppendLine(query & " </tr>")


              
            Next
        End With
        sb.AppendLine("</table>")
        'End If
        sb.AppendLine("<br /><br/>")
        '  sb.AppendLine("<tr><th> OrderNo</th> <th> SaleP.Code</th> <th> SalePCode</th> <th> SalePersonName</th> <th> Sort</th>   <th> Line</th> <th> SHade</th>  </tr>")






        sb.AppendLine("Details for this request is  Shown below :  <br/><br/>")
        sb.AppendLine("<table class=gridtable>")
        'If LCase(ddlRequestType.SelectedItem.Text) <> "excess stock~1041" Then
        'body__2 = Body__1

        sb.AppendLine("<tr><th> SourceOrder</th> <th> SortNo</th> <th> BaleNo</th> <th> Variant</th> <th> Shade</th> <th> Meters</th> </tr>")
        
        qry = "Select SourceOrder as PackedIn, Item_no as SortNo, Bale_no as BaleNo,Varaint as Variant,Shade,Meters from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("empcode") & "' "
        cmd = New SqlCommand(qry, obj.Connection) '
        dr = cmd.ExecuteReader
        While (dr.Read())

            sb.AppendLine("<tr> <td> " & dr(0).ToString & " </td> <td> " & dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  <td>" & dr(3).ToString & " </td>  <td>" & dr(4).ToString & " </td><td>" & dr(5).ToString & " </td></tr> ")
            
            '-- Genratedby_Email = Genratedby_Email & "," & dr.Item(2)
            'Body3 = "<br><br><hr> This is Pending At <b>" & dr.Item(1) & " </b> "
        End While
        dr.Close()
        obj.ConClose()
        sb.AppendLine("</table>")
        sb.AppendLine("<br />")

        sb.AppendLine("<B>Customer Code & Name :-</b>")
        sb.AppendLine("" & txtSearchCustomer.Text & "<br/><br/>")


        sb.AppendLine("<B>Mode of Despatch :-</b>")
        sb.AppendLine("" & DespatchMode & "<br/><br/>")
        sb.AppendLine("<b>Freight Type :-</b>")
        sb.AppendLine("" & FreightType & "<br/><br/>")
        sb.AppendLine("<B>Documents to be Sent to :- </B>")
        sb.AppendLine("" & DocsLocation & "<br/><br/>")

        sb.AppendLine("<B>Shippment Address:- </B>")
        sb.AppendLine("" & ddlShipmentAddress.SelectedItem.Text & "<br/><br/>")

        sb.AppendLine("<B>Prefered Logistics :- </B>")
        sb.AppendLine("" & txtTransportDetail.Text & "<br/><br/>")

        sb.AppendLine("<B>Shipping Address :- </B>")
        sb.AppendLine("" & LblAddress.Text & "<br/><br/>")


        sb.AppendLine("<B>Remarks :- </B>")
        sb.AppendLine("" & txtRemarks.Text & "<br/><br/>")

       

        sb.AppendLine("<br />")
      

        'sb.AppendLine("This request is genrated by <b> " & GenratedBy & "</b><br/><br/>")

        sb.AppendLine("</table><br />")
        'sb.Append("<a href='http://misdev/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br />")
        sb.AppendLine("<i>This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br /></i>")
        sb.AppendLine("</html>")


        sb.AppendLine("<br/><br />")
        If GenratedbyEmail.Length > 10 Then
            [to] = [to] & "," & GenratedbyEmail & ",UPPAL@JCTLTD.COM,kaushal@jctltd.com"
        End If

        Dim scrpt As String
        scrpt = "alert('Unable to save record(s) ...'" + [to] + "' );"
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)

        '[to] = "ashish@jctltd.com"

        ' [to] = "ashish@jctltd.com"
        bcc = "ashish@jctltd.com,rbaksshi@jctltd.com"
        cc = "noreply@jctltd.com"
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
        Dim SmtpMail As New SmtpClient("exchange2k7")


        SmtpMail.Send(mail)
    End Sub

 
    Protected Sub imgClear_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgClear.Click
        DeleteTempRecords()
        ClearAllGrid()
    End Sub
    Private Sub DeleteTempRecords()
        qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        cmd.ExecuteNonQuery()

        ClearAllGrid()
        If IsPostBack Then
            Dim scrpt As String = ""
            scrpt = "alert('All Data Cleared ...');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        End If
    End Sub
    Private Sub ClearAllGrid()
        GrdSummary.DataSource = Nothing
        GrdSummary.DataBind()

        GrdTempValues.DataSource = Nothing
        GrdTempValues.DataBind()

        GrdTempValuesBaleDEtail.DataSource = Nothing
        GrdTempValuesBaleDEtail.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If (Session("Empcode").ToString = "") Then
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then
            DeleteTempRecords()
        End If
    End Sub

    Protected Sub CmdClear_Click(sender As Object, e As System.EventArgs) Handles CmdClear.Click
        GrdBasicDetail.DataSource = Nothing
        GrdBasicDetail.DataBind()
        ddlShipmentAddress.Items.Clear()
        LblAddress.Text = ""
        ClearAllGrid()
        DeleteTempRecords()
        CmdApply.Enabled = False
        txtSearchCustomer.Text = ""
        txtSearchSaleOrder.Text = ""
        txtSearchShade.Text = ""
        txtSearchSort.Text = ""
        txtSearchVariant.Text = ""
        CmdApply.Enabled = True
    End Sub
End Class
