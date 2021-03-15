Imports System
'Imports System.Collections.Generic
'Imports System.Web
Imports System.Web.UI
Imports System.Data.SqlClient
'Imports System.Web.UI.WebControls

Partial Class OPS_Testing_Entry
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objfun As Functions = New Functions
    Dim toEMail As String = "ashish@jctltd.com;jagdeep@jctltd.com;harendra@jctltd.com;rbaksshi@jctltd.com"
    Dim byEmailID As String = "noreply@jctltd.com"
    Dim objSendMail As SendMail = New SendMail
    Dim scrpt As String
    Dim empCode As String
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  txtOrderNo.Attributes.Add("onKeyPress", "doClick('" + BtnFetch.ClientID + "',event)")
            txtOrderNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + BtnFetch.UniqueID + "').click();return false;}} else {return true}; ")
            txtBatchNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + BtnFetch.UniqueID + "').click();return false;}} else {return true}; ")

            'txtOrderNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + cmdSearch.UniqueID + "').click();return false;}} else {return true}; ")
            'txtBatchNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + cmdSearch.UniqueID + "').click();return false;}} else {return true}; ")
            qry = "SELECT Process_Code, process_Desc+'('+Process_Code + ')' FROM production..jct_process_Master WHERE (process_Desc LIKE '%Dry%' OR process_Desc LIKE '%Finish%'  or Process_Code='SHRK') ORDER BY process_Desc"
            objfun.FillList(ddlProcess, qry)
            ddlProcess.Items.Insert(0, "Delivery")
           
        End If
        If Not ViewState("Date") Is Nothing Then
            txtTestDate.Text = ViewState("Date")
        End If
    End Sub



    Protected Sub BtnFetch_Click(sender As Object, e As System.EventArgs) Handles BtnFetch.Click
        Reset()
        'Qry = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        'MsgBox("" & sender.ToString & "---" & e.ToString)
        'If ddlProcess.SelectedItem.Text = "Delivery" Then
        '    If txtOrderNo.Text <> "" Then
        '        qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo,attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated,h.serial FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code   LEFT OUTER JOIN Production..jct_process_issue_finish_folding h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "'  WHERE b.order_no = '" & txtOrderNo.Text & "'  GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE,h.serial ORDER BY ENTERED_DATE desc"
        '        objfun.FillGrid(qry, GrdOrderDetails)
        '        qry = "SELECT a.order_srl_no FROM miserp.som.dbo.t_order_line_nos a(nolock) WHERE a.order_no='" & txtOrderNo.Text & "'  order by a.order_srl_no "
        '        objfun.FillList(ddlLineNo, qry)
        '        ddlLineNo_SelectedIndexChanged(sender, e)
        '    ElseIf txtBatchNo.Text <> "" Then
        '        qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo, attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code  LEFT OUTER JOIN Production..jct_process_issue_finish_folding h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "'  WHERE h.batch_no = '" & txtBatchNo.Text & "' GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE ORDER BY ENTERED_DATE desc, b.order_no asc,e.line_no asc"
        '        objfun.FillGrid(qry, GrdOrderDetails)
        '    ElseIf txtBatchNo.Text = "" And txtOrderNo.Text = "" Then
        '        qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo, attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code  LEFT OUTER JOIN Production..jct_process_issue_finish_folding h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "' WHERE  eNTERED_DATE >=GETDATE() - 3 GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE  ORDER BY ENTERED_DATE desc, b.order_no asc,e.line_no asc"
        '        objfun.FillGrid(qry, GrdOrderDetails)
        '        '  objfun.FillGrid(qry, CoolGridView1)
        '    End If
        'Else
        '    If txtOrderNo.Text <> "" Then
        '        qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo,attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated,h.serial FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code   LEFT OUTER JOIN Production..jct_process_prod_entries h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no and h.process='" & ddlProcess.SelectedItem.Value & "'  INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "'  WHERE b.order_no = '" & txtOrderNo.Text & "'  GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE,h.serial ORDER BY ENTERED_DATE desc"
        '        objfun.FillGrid(qry, GrdOrderDetails)
        '        qry = "SELECT a.order_srl_no FROM miserp.som.dbo.t_order_line_nos a(nolock) WHERE a.order_no='" & txtOrderNo.Text & "'  order by a.order_srl_no "
        '        objfun.FillList(ddlLineNo, qry)
        '        ddlLineNo_SelectedIndexChanged(sender, e)
        '    ElseIf txtBatchNo.Text <> "" Then
        '        qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo, attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code  LEFT OUTER JOIN Production..jct_process_prod_entries h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no  and h.process='" & ddlProcess.SelectedItem.Value & "'  INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "'  WHERE h.batch_no = '" & txtBatchNo.Text & "' GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE ORDER BY ENTERED_DATE desc, b.order_no asc,e.line_no asc"
        '        objfun.FillGrid(qry, GrdOrderDetails)
        '    ElseIf txtBatchNo.Text = "" And txtOrderNo.Text = "" Then
        '        qry = "SELECT  c.cust_name AS CustomerName,REPLACE(ISNULL(RTRIM(g.group_desc), 'N.A'),'', 'N.A') AS SalePerson,b.order_no as OrderNo, attb_discrete AS Shade ,line_no AS [LineNo] ,Item_no AS Item ,convert(numeric(8),Req_Qty) AS OrderQty,SUM(h.mtrs) AS Mtrs,h.batch_no as BatchNo,CONVERT(VARCHAR(10),h.ENTERED_DATE,101) AS Dated FROM    miserp.som.dbo.t_order_hdr b ( NOLOCK ) INNER JOIN MISERP.som.dbo.m_customer c ( NOLOCK ) ON b.ord_cust_no = c.cust_no LEFT OUTER JOIN miserp.som.dbo.jct_so_team_catg d ( NOLOCK ) ON b.order_no = d.order_no INNER JOIN miserp.som.dbo.t_order_line_nos_attrb e ( NOLOCK ) ON b.order_no = e.order_no AND e.attb_code = 'Shade1' INNER JOIN miserp.som.dbo.t_order_line_nos f ( NOLOCK ) ON e.order_no = f.order_no AND e.line_no = f.order_srl_no left outer join MISERP.SOM.dbo.m_cust_group g (Nolock) on g.group_no = d.sale_person_code  LEFT OUTER JOIN Production..jct_process_prod_entries h ON e.order_no=h.po_number AND e.line_no=h.po_litem_no and h.process='" & ddlProcess.SelectedItem.Value & "' INNER JOIN production..jct_process_issue_gry i ON h.lot_no=i.lot_no AND i.warehouse='" & ddlPlantType.SelectedItem.Text & "' WHERE  eNTERED_DATE >=GETDATE() - 3 GROUP BY c.cust_name ,g.group_desc,b.order_no,attb_discrete,line_no ,Item_no,Req_Qty,h.batch_no,h.ENTERED_DATE  ORDER BY ENTERED_DATE desc, b.order_no asc,e.line_no asc"
        '        objfun.FillGrid(qry, GrdOrderDetails)
        '        '  objfun.FillGrid(qry, CoolGridView1)
        '    End If
        'End If



        qry = "Exec Jct_Ops_Quality_Testing_SearchData '" & txtOrderNo.Text & "','" & txtBatchNo.Text & "','" & ddlProcess.SelectedItem.Value & "','" & ddlPlantType.SelectedItem.Value & "' "
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
        Dim ProdSerial As Int32 = lblSerial.Text
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

            If ddlProcess.SelectedItem.Value = "Delivery" Then
                qry = "SELECT isnull(batch_No,0) FROM production..jct_process_issue_finish_folding WHERE po_number='" & txtOrderNo.Text & "' AND po_litem_no='" & ddlLineNo.SelectedItem.Text & "' AND batch_no='" & txtBatchNo.Text & "'"
            Else
                qry = "SELECT isnull(batch_No,'Dummy') FROM production..jct_process_prod_entries a,production..jct_process_prod_entries_detail b WHERE a.po_number='" & txtOrderNo.Text & "' AND  a.serial=b.serial and a.serial=" & lblSerial.Text & "  AND po_litem_no='" & ddlLineNo.SelectedItem.Text & "' AND batch_no='" & txtBatchNo.Text & "'"
            End If
            If objfun.CheckRecordExistInTransaction(qry) = True Then
                If empCode = "0" Then
                    objfun.Alert("Batch No Does Not Exist for this Order !!! ")

                    Exit Sub
                Else
                    ' If IsNumeric(objfun.FetchValue(qry)) = True And objfun.FetchValue(qry) <> "0" Then
                    If objfun.FetchValue(qry) <> "0" Then
                        txtBatchNo.Text = objfun.FetchValue(qry)
                    Else
                        objfun.Alert("Batch No Does Not Exist for this Order !!! ")
                        Exit Sub
                    End If
                End If
            Else
                objfun.Alert("Unable To Continue !!! ")
                Exit Sub
            End If


            If Trim(ddlResult.SelectedItem.Text) = "" Then
                scrpt = "alert('Please Select a valid Reason !!!.')"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                Exit Sub
            End If
            Dim transID As Int32 = 0
            Dim body As String
            If ddlResult.SelectedItem.Text = "Pass" Then
                body = "<p>Hello ,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your order was Tested in JCT Test Lab which led to its result as <B> " & ddlResult.SelectedItem.Text & "</B> At<B> " & ddlStage.SelectedItem.Text & " </b>Stage.</p> Test Was Conducted by " & txtTestConductedBy.Text & "  with Details </p> <H3>Order No. " & txtOrderNo.Text & "  </H3>  </p> <p> <H3>  Sort No. " & lblSort.Text & " .</p> <p>  Shade " & lblShade.Text & " With Line No " & ddlLineNo.SelectedItem.Text & " </H3>  </p> <p><H3> Test Was Conducted on  Date:  " & txtTestDate.Text & "</H3> </p><p> <H3> Additional Info :-<br><br> Customer " & GrdOrderDetails.SelectedRow.Cells(1).Text & "</br>   SalePerson " & GrdOrderDetails.SelectedRow.Cells(2).Text & "</p></H3></br><p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
            Else
                body = "<p>Hello,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your order was Tested in JCT Test Lab which led to its result as <B>  " & ddlResult.SelectedItem.Text & "</B> </font> At<B> " & ddlStage.SelectedItem.Text & " </b>Stage.</p> Test Was Conducted by " & txtTestConductedBy.Text & "  with Details </p> <H3>Order No. " & txtOrderNo.Text & "  </H3>  </p> <p> <H3>  Sort No. " & lblSort.Text & " .</p> <p>  Shade " & lblShade.Text & " With Line No " & ddlLineNo.SelectedItem.Text & " </H3>  </p> <p><H3> Test Was Conducted on  Date:  " & txtTestDate.Text & "</H3> </p><p> <H3> Additional Info :-<br><br> Customer " & GrdOrderDetails.SelectedRow.Cells(1).Text & "</br>   SalePerson " & GrdOrderDetails.SelectedRow.Cells(2).Text & "</p></H3></br><p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
            End If
            qry = "Select isnull(max(TransID),0)+1 from  Jct_Ops_QA_Feedback_Entry"
            transID = Val(objfun.FetchValue(qry))
            If Trim(txtBatchNo.Text) = "" Then
                qry = "Insert into Jct_Ops_QA_Feedback_Entry(UserCode,OrderNo ,LineItem,SortNo ,TestConductedBy,TestConductedOn,MetersTested,Result,Reason,Remarks,CreatedDate,STATUS,CreatedOnHost,TransID,Stage,TestType,shade,Process,ProdSerialNo,RemarksForReason ) values('" & Session("EmpCode") & "','" & txtOrderNo.Text & "','" & ddlLineNo.SelectedItem.Text & "','" & Trim(lblSort.Text) & "','" & empCode & "','" & txtTestDate.Text & "','" & txtSampleMtrs.Text & "','" & ddlResult.SelectedItem.Text & "','" & txtReason.Text & "','" & txtRemarks.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "'," & transID & ",'" & ddlStage.SelectedItem.Value & "','" & ddlTestType.SelectedItem.Text & "','" & lblShade.Text & "','" & ddlProcess.SelectedItem.Value & "'," & ProdSerial & ",'" & txtSplRemark.Text & "')"
            Else
                qry = "Insert into Jct_Ops_QA_Feedback_Entry(UserCode,OrderNo ,LineItem,SortNo ,TestConductedBy,TestConductedOn,MetersTested,Result,Reason,Remarks,CreatedDate,STATUS,CreatedOnHost,TransID,Stage,BatchNo,TestType,shade,Process,ProdSerialNo,RemarksForReason ) values('" & Session("EmpCode") & "','" & txtOrderNo.Text & "','" & ddlLineNo.SelectedItem.Text & "','" & Trim(lblSort.Text) & "','" & empCode & "','" & txtTestDate.Text & "','" & txtSampleMtrs.Text & "','" & ddlResult.SelectedItem.Text & "','" & txtReason.Text & "','" & txtRemarks.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "'," & transID & ",'" & ddlStage.SelectedItem.Value & "'," & txtBatchNo.Text & ",'" & ddlTestType.SelectedItem.Text & "','" & lblShade.Text & "','" & ddlProcess.SelectedItem.Value & "'," & ProdSerial & ",'" & txtSplRemark.Text & "')"
            End If
            If objfun.InsertRecord(qry) = True Then
                scrpt = "alert('Record Saved Sucessfully !!!.')"
                'objSendMail.SendMail(toEMail, byEmailID, "Your Order was Tested in the Lab and resulted " & ddlResult.SelectedItem.Text & " .....!!!!", body)
                qry = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" & txtOrderNo.Text & "'"
                Dim SalePersonCode As String = ""
                Dim SalerPersonEmail As String = ""
                SalePersonCode = objfun.FetchValue(qry)
                SalePersonCode = Left(SalePersonCode, 1) & "-" & Right(SalePersonCode, Len(SalePersonCode) - 1)

                qry = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & SalePersonCode & "' "
                SalerPersonEmail = objfun.FetchValue(qry)
                If SalerPersonEmail = "" Then
                    SalerPersonEmail = "mkt-Group@jctltd.ccom"
                End If
                objfun.SendMailOPS(body, "", SalerPersonEmail, Session("Empcode"), "arwinder@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your Order no '" & txtOrderNo.Text & "' was Tested in the Lab and resulted " & ddlResult.SelectedItem.Text & " .....!!!!")





                GrdSavedRecords.DataSource = Nothing
                GrdSavedRecords.DataBind()

                GrdSavedRecords.DataSourceID = "SqlDataSource1"
                GrdSavedRecords.DataBind()
            End If
        Catch
            scrpt = "alert('Unable to Complete the Transaction !!! ')"
            'Objfun.Alert("Unable to Complete the Transaction !!! ")
        Finally
            objfun.Alert("" & scrpt)

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        End Try
    End Sub

    Protected Sub GrdSavedRecords_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdSavedRecords.RowCommand
        If e.CommandName = "Remove" Then
            Dim TransStatus As Boolean = False
            Dim Scrpt As String = ""
            qry = "Update Jct_Ops_QA_Feedback_Entry SET STATUS='D',DeletedOnHost='" & Request.ServerVariables("REMOTE_ADDR") & "',DeletionDate=getdate(),DeletedByUser='" & Session("Empcode") & "' where transid=" & e.CommandArgument
            TransStatus = objfun.UpdateRecord(qry)

            If TransStatus = False Then
                Scrpt = "alert('Unable to Update Record')"
                objfun.Alert("" & Scrpt)
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
            End If
        Else
            scrpt = "alert(' Record Deleted..  ')"
            objfun.Alert("" & scrpt)
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        End If
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
            qry = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "

            objfun.FillGrid(qry, GrdOrderDetails)


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
        e.Row.Cells(1).Wrap = False
        If e.Row.RowType = DataControlRowType.DataRow And Trim(e.Row.Cells(12).Text) = "Y" Then
            e.Row.CssClass = "GridRowBlue"
        End If
    End Sub

    Protected Sub GrdOrderDetails_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdOrderDetails.SelectedIndexChanged
        With GrdOrderDetails
            txtOrderNo.Text = Trim(.SelectedRow.Cells(3).Text)
            ddlLineNo.Items.Clear()
            ddlLineNo.Items.Add(.SelectedRow.Cells(5).Text)
            ddlLineNo.SelectedIndex = 0
            GetLineDetail(txtOrderNo.Text)
            'GetLineDetail(txtOrderNo.Text, .SelectedRow.Cells(5).Text)
            txtBatchNo.Text = Trim(.SelectedRow.Cells(9).Text)
            lblSerial.Text = Val(Trim(.SelectedRow.Cells(11).Text))
            ddlLineNo_SelectedIndexChanged(sender, e)
        End With

    End Sub
    Private Sub GetLineDetail(ByVal ordrNo As String)
        'If LineNo <> 999 Then
        qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & ordrNo & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlLineNo.SelectedItem.Value
        lblShade.Text = objfun.FetchValue(qry)
        qry = "SELECT distinct  a.item_no FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & ordrNo & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlLineNo.SelectedItem.Value
        lblSort.Text = objfun.FetchValue(qry)
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

    Protected Sub ddlProcess_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlProcess.SelectedIndexChanged
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
