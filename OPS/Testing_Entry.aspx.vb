Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Linq
'Imports System.Web
Imports System.Web.UI
'Imports System.Web.UI.WebControls

Partial Class OPS_Testing_Entry
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objfun As Functions = New Functions
    Dim toEMail As String = "ashish@jctltd.com;jagdeep@jctltd.com;harendra@jctltd.com;rbaksshi@jctltd.com"
    Dim byEmailID As String = "noreply@jctltd.com"
    Dim objSendMail As SendMail = New SendMail
    '//Dim ObjCon a
    Dim scrpt As String
    Dim empCode As String
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  txtOrderNo.Attributes.Add("onKeyPress", "doClick('" + BtnFetch.ClientID + "',event)")
            txtOrderNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + BtnFetch.UniqueID + "').click();return false;}} else {return true}; ")
            txtBatchNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + BtnFetch.UniqueID + "').click();return false;}} else {return true}; ")

            qry = "SELECT Process_Code, process_Desc+'('+Process_Code + ')' FROM production..jct_process_Master WHERE (process_Desc LIKE '%Dry%' OR process_Desc LIKE '%Finish%'  or Process_Code='SHRK') ORDER BY process_Desc"
            objfun.FillList(ddlprocess, qry)
            ddlprocess.Items.Insert(0, "Delivery")

        End If
        If Not ViewState("Date") Is Nothing Then
            txtTestDate.Text = ViewState("Date")
        End If
    End Sub



    Protected Sub BtnFetch_Click(sender As Object, e As System.EventArgs) Handles BtnFetch.Click
        'Qry = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        'MsgBox("" & sender.ToString & "---" & e.ToString)
        'If txtOrderNo.Text <> "" Then
        '    qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo,attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code   LEFT OUTER JOIN Production..jct_process_issue_finish_folding h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "'  WHERE b.order_no = '" & txtOrderNo.Text & "' GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE ORDER BY ENTERED_DATE desc"
        '    objfun.FillGrid(qry, GrdOrderDetails)
        '    qry = "SELECT a.order_srl_no FROM miserp.som.dbo.t_order_line_nos a(nolock) WHERE a.order_no='" & txtOrderNo.Text & "'  order by a.order_srl_no "
        '    objfun.FillList(ddlLineNo, qry)
        '    ddlLineNo_SelectedIndexChanged(sender, e)
        'ElseIf txtBatchNo.Text <> "" Then
        '    qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo, attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code  LEFT OUTER JOIN Production..jct_process_issue_finish_folding h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "'  WHERE h.batch_no = '" & txtBatchNo.Text & "' GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE ORDER BY ENTERED_DATE desc, b.order_no asc,e.line_no asc"
        '    objfun.FillGrid(qry, GrdOrderDetails)
        'ElseIf txtBatchNo.Text = "" And txtOrderNo.Text = "" Then
        '    qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo, attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code  LEFT OUTER JOIN Production..jct_process_issue_finish_folding h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "' WHERE  eNTERED_DATE >=GETDATE() - 3 GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE  ORDER BY ENTERED_DATE desc, b.order_no asc,e.line_no asc"
        '    objfun.FillGrid(qry, GrdOrderDetails)
        'End If
        Reset()
        qry = "Exec Jct_Ops_Quality_Testing_SearchData '" & txtOrderNo.Text & "','" & txtBatchNo.Text & "','" & ddlprocess.SelectedItem.Value & "','" & ddlPlantType.SelectedItem.Value & "' "
        objfun.FillGrid(qry, GrdOrderDetails)
        If txtOrderNo.Text <> "" Then
            qry = "SELECT a.order_srl_no FROM miserp.som.dbo.t_order_line_nos a(nolock) WHERE a.order_no='" & txtOrderNo.Text & "'  order by a.order_srl_no "
            objfun.FillList(ddlLineNo, qry)
        End If
    End Sub


    Protected Sub ddlLineNo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlLineNo.SelectedIndexChanged
        'qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlLineNo.SelectedItem.Value
        'lblShade.Text = objfun.FetchValue(qry)
        'qry = "SELECT distinct  a.item_no FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlLineNo.SelectedItem.Value
        'lblSort.Text = objfun.FetchValue(qry)
        GetLineDetail(Trim(txtOrderNo.Text))
    End Sub

    Protected Sub lnkApply_Click(sender As Object, e As System.EventArgs) Handles lnkApply.Click
        scrpt = ""
        empCode = ""
        Try

            Dim index As Int16 = 0
            empCode = Trim(txtTestConductedBy.Text)

            Dim Str() As String
            index = empCode.IndexOf("|")
            'MsgBox("" & index)
            If index <= 0 Then
                objfun.Alert("Employee Does Not Exist. Please select employee from List !!! ")
                Exit Sub

            End If
            Str = empCode.Split("|")
            empCode = Str(1)


            ' MsgBox("Part 1" & Str(0) & "---Part 2 " & Str(1))
            qry = "SELECT isnull(empcode,0)  FROM dbo.JCT_EmpMast_Base WHERE Active='Y' AND empcode LIKE '%" & empCode & "%' "
            If objfun.CheckRecordExistInTransaction(qry) = True Then
                If empCode = "0" Then
                    objfun.Alert("Employee Does Not Exist. Please select employee from List !!! ")
                    Exit Sub
                Else
                    empCode = objfun.FetchValue(qry)
                End If
            Else
                objfun.Alert("Unable To Continue !!! ")
            End If

            Dim Serial As Int64 = 0

            qry = "SELECT isnull(ProdSerialNo,0)  FROM Jct_Ops_QA_Feedback_Entry WHERE status='A' AND ProdSerialNo='" & lblSerial.Text & "%' and Stage='" & ddlStage.SelectedItem.Text & "' and TestType='" & ddlTestType.SelectedItem.Text & "' and Process='" & ddlprocess.SelectedItem.Value & "' "
            If objfun.CheckRecordExistInTransaction(qry) = True Then
                If Serial = 0 Then
                    objfun.Alert("Record Already Exist !!! Production Serial Already Tested !!! ")
                    scrpt = "alert('Record Already Exist !!! Production Serial Already Tested !!! ')"
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                    Exit Sub
                Else
                    Serial = objfun.FetchValue(qry)
                End If
            Else
                ' objfun.Alert("Unable To Continue !!! ")
                'scrpt = "alert('Record Already Exist !!! Production Serial Already Tested !!! ')"
                'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                'Exit Sub

                'if record does not exist in the transaction that means it is a fresh serial to be inserted in the record
            End If






            ' qry = "SELECT isnull(batch_No,0) FROM production..jct_process_issue_finish_folding WHERE po_number='" & txtOrderNo.Text & "' AND po_litem_no='" & ddlLineNo.SelectedItem.Text & "' AND batch_no='" & txtBatchNo.Text & "'"
            If ddlProcess.SelectedItem.Value = "Delivery" Then
                qry = "SELECT isnull(batch_No,0) FROM production..jct_process_issue_finish_folding WHERE po_number='" & txtOrderNo.Text & "' AND po_litem_no='" & ddlLineNo.SelectedItem.Text & "' AND batch_no='" & txtBatchNo.Text & "'"
            Else
                qry = "SELECT isnull(batch_No,'Dummy') FROM production..jct_process_prod_entries a,production..jct_process_prod_entries_detail b WHERE a.po_number='" & txtOrderNo.Text & "' AND  a.serial=b.serial and a.serial=" & lblSerial.Text & "  AND po_litem_no='" & ddlLineNo.SelectedItem.Text & "' AND batch_no='" & txtBatchNo.Text & "'"
            End If
            If objfun.CheckRecordExistInTransaction(qry) = True Then
                If empCode = "0" Then
                    objfun.Alert("Batch No Does Not Exist for this Order !!! ")
                    Scrpt = "alert('Batch No Does Not Exist for this Order !!!')"
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)



                Exit Sub
            Else
                If IsNumeric(objfun.FetchValue(qry)) = True And objfun.FetchValue(qry) <> "0" Then
                    txtBatchNo.Text = objfun.FetchValue(qry)
                Else
                        objfun.Alert("Batch No Does Not Exist for this Order !!! ")
                        Scrpt = "alert('Batch No Does Not Exist for this Order !!!')"
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                    Exit Sub
                End If
            End If
            Else

                ' objfun.Alert("Unable To Continue !!! ")

                If ddlprocess.SelectedItem.Value = "Delivery" Then
                    scrpt = "alert('Some Problem occured in fetching Issue to Folding Data !!!.')"
                Else
                    scrpt = "alert('Either Batch No. not valid or Some other Problem occured in fetching Production Data !!!.')"
                End If

                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                Exit Sub
            End If


            If Trim(ddlResult.SelectedItem.Text) = "" Then
                Scrpt = "alert('Please Select a valid Reason !!!.')"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                Exit Sub
            End If
            Dim transID As Int32 = 0
            Dim body As String
            If ddlResult.SelectedItem.Text = "Pass" Then
                body = "<p>Hello,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your order was Tested in JCT Test Lab which led to its result as  " & ddlResult.SelectedItem.Text & " At<B> " & ddlStage.SelectedItem.Text & " </b>Stage.</p> Test Was Conducted by " & txtTestConductedBy.Text & "  with Details </p> <H3>Order No. " & txtOrderNo.Text & "  </H3>  </p> <p> <H3>  Sort No. " & lblSort.Text & " .</p> <p>  Shade " & lblShade.Text & " With Line No " & ddlLineNo.SelectedItem.Text & " </H3>  </p> <p><H3> Test Was Conducted on  Date:  " & txtTestDate.Text & "</H3> </p><p> <H3> Additional Info :-<br><br> Customer " & GrdOrderDetails.Rows(0).Cells(0).Text & "</br>   SalePerson " & GrdOrderDetails.Rows(0).Cells(1).Text & "</p></H3></br><p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
            Else
                body = "<p>Hello,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your order was Tested in JCT Test Lab which led to its result as <font color=red>  " & ddlResult.SelectedItem.Text & " </font> At<B> " & ddlStage.SelectedItem.Text & " </b>Stage.</p> Test Was Conducted by " & txtTestConductedBy.Text & "  with Details </p> <H3>Order No. " & txtOrderNo.Text & "  </H3>  </p> <p> <H3>  Sort No. " & lblSort.Text & " .</p> <p>  Shade " & lblShade.Text & " With Line No " & ddlLineNo.SelectedItem.Text & " </H3>  </p> <p><H3> Test Was Conducted on  Date:  " & txtTestDate.Text & "</H3> </p><p> <H3> Additional Info :-<br><br> Customer " & GrdOrderDetails.Rows(0).Cells(0).Text & "</br>   SalePerson " & GrdOrderDetails.Rows(0).Cells(1).Text & "</p></H3></br><p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
            End If
            qry = "Select isnull(max(TransID),0)+1 from  Jct_Ops_QA_Feedback_Entry"
            transID = Val(objfun.FetchValue(qry))
            qry = "Insert into Jct_Ops_QA_Feedback_Entry(UserCode,OrderNo ,LineItem,SortNo ,TestConductedBy,TestConductedOn,MetersTested,Result,Reason,Remarks,CreatedDate,STATUS,CreatedOnHost,TransID,Stage,BatchNo,TestType,ProdSerialNo,process) values('" & Session("EmpCode") & "','" & txtOrderNo.Text & "','" & ddlLineNo.SelectedItem.Text & "','" & Trim(lblSort.Text) & "','" & empCode & "','" & txtTestDate.Text & "','" & txtSampleMtrs.Text & "','" & ddlResult.SelectedItem.Text & "','" & txtReason.Text & "','" & txtRemarks.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "'," & transID & ",'" & ddlStage.SelectedItem.Value & "'," & txtBatchNo.Text & ",'" & ddlTestType.SelectedItem.Text & "','" & lblSerial.Text & "','" & ddlProcess.SelectedItem.Value & "')"
            If objfun.InsertRecord(qry) = True Then
                ViewState("Date") = txtTestDate.Text
                scrpt = "alert('Record Saved Sucessfully !!!.')"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                'objSendMail.SendMail(toEMail, byEmailID, "Your Order was Tested in the Lab and resulted " & ddlResult.SelectedItem.Text & " .....!!!!", body)
                qry = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" & txtOrderNo.Text & "'"
                Dim SalePersonCode As String = ""
                Dim SalerPersonEmail As String = ""
                SalePersonCode = objfun.FetchValue(qry)
                If SalePersonCode Is Nothing Then
                    SalePersonCode = ""
                    SalerPersonEmail = "mkt-Group@jctltd.ccom"
                Else
                    SalePersonCode = Left(SalePersonCode, 1) & "-" & Right(SalePersonCode, Len(SalePersonCode) - 1)
                    qry = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & SalePersonCode & "' "
                    SalerPersonEmail = objfun.FetchValue(qry)
                    If SalerPersonEmail = "" Then
                        SalerPersonEmail = "mkt-Group@jctltd.ccom"
                    End If
                End If
                'objfun.SendMailOPS(body, "", SalerPersonEmail, Session("Empcode"), "arwinder@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your Order no '" & txtOrderNo.Text & "' was Tested in the Lab and resulted " & ddlResult.SelectedItem.Text & " .....!!!!")
                If LCase(ddlPlantType.SelectedItem.Text) = "taffeta" Then
                    SalerPersonEmail = SalerPersonEmail & "," & "kamlesh@jctltd.com"
                    objfun.SendMailOPS(body, "", SalerPersonEmail, Session("Empcode"), "arwinder@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your Order no '" & txtOrderNo.Text & "' was Tested in the Lab and resulted " & ddlResult.SelectedItem.Text & " .....!!!!")
                Else
                    objfun.SendMailOPS(body, "", SalerPersonEmail, Session("Empcode"), "arwinder@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your Order no '" & txtOrderNo.Text & "' was Tested in the Lab and resulted " & ddlResult.SelectedItem.Text & " .....!!!!")
                End If
            
                GrdSavedRecords.DataSource = Nothing
                GrdSavedRecords.DataBind()

                GrdSavedRecords.DataSourceID = "SqlDataSource1"
                GrdSavedRecords.DataBind()
            End If
        Catch ex As Exception
            scrpt = "alert('Some Error Occured !!!. If you have not recieved message of (Successfull Transaction) then it is posible that your record is not Saved.  Unable to Send E-Mail Due to :' + '" + ex.Message + "')"
            'Objfun.Alert("Unable to Complete the Transaction !!! ")
        Finally


            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        End Try
    End Sub

    Protected Sub GrdSavedRecords_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdSavedRecords.SelectedIndexChanged
        With GrdSavedRecords
            'If ViewState("ID") Is Nothing Then
            txtOrderNo.Text = .SelectedRow.Cells(1).Text
            ddlLineNo.Items.Clear()
            ddlLineNo.Items.Add(.SelectedRow.Cells(2).Text)
            txtTestConductedBy.Text = Trim(.SelectedRow.Cells(5).Text) & "|" & Trim(.SelectedRow.Cells(4).Text)
            txtTestDate.Text = Trim(.SelectedRow.Cells(6).Text)
            txtSampleMtrs.Text = Trim(.SelectedRow.Cells(7).Text)
            ddlResult.SelectedIndex = ddlResult.Items.IndexOf(ddlResult.Items.FindByText(Trim(.SelectedRow.Cells(8).Text)))
            txtReason.Text = Trim(.SelectedRow.Cells(9).Text)
            txtRemarks.Text = Trim(.SelectedRow.Cells(10).Text)
            txtBatchNo.Text = .SelectedRow.Cells(13).Text
            lblSerial.Text = .SelectedRow.Cells(14).Text
            'qry = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "

            'objfun.FillGrid(qry, GrdOrderDetails)
           

            ddlLineNo_SelectedIndexChanged(sender, e)

            ViewState("ID") = .SelectedRow.Cells(12).Text
            'Else

            '            End If
        End With
    End Sub

    Protected Sub CmdDelete_Click(sender As Object, e As System.EventArgs) Handles CmdDelete.Click
        Try
            qry = "Update Jct_Ops_QA_Feedback_Entry set Status='D',DeletedOnHost='" & Request.ServerVariables("REMOTE_ADDR") & "',DeletionDate=getdate(),DeletedByUser='" & Session("EmpCode") & "' where TransID=" & ViewState("ID").ToString
            scrpt = "alert('Record Deleted Sucessfully !!! ')"
            If objfun.UpdateRecord(qry) = False Then
                scrpt = "alert('Unable to Complete the Transaction !!! ')"
            End If
            GrdSavedRecords.DataSource = Nothing
            GrdSavedRecords.DataBind()

            GrdSavedRecords.DataSourceID = "SqlDataSource1"
            GrdSavedRecords.DataBind()
        Catch ex As Exception
            scrpt = "alert('Unable to Complete the Transaction !!! ')"
        Finally
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        End Try
    End Sub

    Protected Sub GrdOrderDetails_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdOrderDetails.RowDataBound
        '        If e.Row.RowType = DataControlRowType.DataRow Then

        ' End If
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(1).Wrap = False
                If e.Row.RowType = DataControlRowType.DataRow And Trim(e.Row.Cells(12).Text) = "Y" And Trim(e.Row.Cells(14).Text) = "Physical" Then
                    e.Row.CssClass = "GridRowBlue" '----For Physical Class is blue
                ElseIf e.Row.RowType = DataControlRowType.DataRow And Trim(e.Row.Cells(12).Text) = "Y" And Trim(e.Row.Cells(14).Text) = "Chemmical" Then
                    e.Row.CssClass = "GridRowPurple" '----For Physical Class is blue
                End If
            End If
        Catch ex As Exception
            MsgBox("Error " & ex.ToString)
        End Try
    End Sub

    Protected Sub GrdOrderDetails_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdOrderDetails.SelectedIndexChanged
        With GrdOrderDetails
            txtOrderNo.Text = Trim(.SelectedRow.Cells(3).Text)
            ddlLineNo.Items.Clear()
            ddlLineNo.Items.Add(.SelectedRow.Cells(5).Text)
            ddlLineNo.SelectedIndex = 0
            GetLineDetail(txtOrderNo.Text)
            'GetLineDetail(txtOrderNo.Text, .SelectedRow.Cells(5).Text)
            txtBatchNo.Text = Val(Trim(.SelectedRow.Cells(9).Text))
            If ddlprocess.SelectedItem.Text = "Delivery" Then
                lblSerial.Text = Trim(.SelectedRow.Cells(11).Text)
            Else
                lblSerial.Text = Trim(.SelectedRow.Cells(11).Text)
            End If
        End With

    End Sub
    Private Sub GetLineDetail(ByVal ordrNo As String)
        'If LineNo <> 999 Then
        Dim Con As SqlClient.SqlConnection
        Con = New SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MisSom").ConnectionString)
        qry = "SELECT distinct  b.attb_discrete FROM t_order_line_nos a(nolock),t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & ordrNo & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlLineNo.SelectedItem.Value
        lblShade.Text = objfun.FetchValue(qry, Con)
        qry = "SELECT distinct  a.item_no FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & ordrNo & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlLineNo.SelectedItem.Value
        lblSort.Text = objfun.FetchValue(qry, Con)
        'Else

        'End If
    End Sub

    Protected Sub txtOrderNo_TextChanged(sender As Object, e As System.EventArgs) Handles txtOrderNo.TextChanged
        '  txtBatchNo.Text = ""
    End Sub

    Protected Sub txtBatchNo_TextChanged(sender As Object, e As System.EventArgs) Handles txtBatchNo.TextChanged
        '   txtOrderNo.Text = ""
    End Sub

    Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        BtnFetch_Click(sender, e)
    End Sub
    Private Function Validations() As Boolean
        empCode = ""
        qry = "SELECT isnull(empcode,0)  FROM dbo.JCT_EmpMast_Base WHERE Active='Y' AND empcode LIKE '%" & empCode & "%' "
        If objfun.CheckRecordExistInTransaction(qry) = True Then
            If empCode = "0" Then
                objfun.Alert("Employee Does Not Exist. Please select employee from List !!! ")
                Return False
                Exit Function
            Else
                empCode = objfun.FetchValue(qry)
                Return True
            End If
        Else
            Return False
        End If


        qry = "SELECT ISNULL(1,0) FROM jct_process_issue_finish_folding WHERE po_number='" & txtOrderNo.Text & "' AND po_litem_no='" & ddlLineNo.SelectedItem.Text & "' AND batch_no='" & txtBatchNo.Text & "'"
        If objfun.CheckRecordExistInTransaction(qry) = True Then
            If empCode = "0" Then
                objfun.Alert("Batch No Does Not Exist for this Order !!! ")
                Return False
                Exit Function
            Else
                empCode = objfun.FetchValue(qry)
                Return True
            End If
        Else
            Return False
        End If


    End Function

    Protected Sub ddlprocess_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlprocess.SelectedIndexChanged
        Reset()
    End Sub
    Private Sub Reset()
        GrdOrderDetails.DataSource = Nothing
        GrdOrderDetails.DataBind()
        lblShade.Text = ""
        lblSerial.Text = "0000"
        lblSort.Text = ""
        ddlLineNo.Items.Clear()
    End Sub
End Class
