Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Partial Class OPS_ODS_Modify_Despatch_Instruction
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objfun As Functions = New Functions
    Dim toEMail As String = "aslam@jctltd.com"
    Dim byEmailID As String = "noreply@jctltd.com"
    Dim objSendMail As SendMail = New SendMail
    Dim scrpt As String
    Dim empCode As String
    Dim SanctionID1 As String
    Dim obj As Connection = New Connection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction
    Dim Meters As Double, yards As Double, gr_wt As Double, net_wt As Double = 0.0
    Dim TmpMeters As Double = 0.0
    Dim qry1 As String = ConfigurationManager.ConnectionStrings("miserptest2").ToString()
    Dim con1 As SqlConnection = New SqlConnection(qry1)

    Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        'qry  = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        ''''''''''qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1'"
        'objfun.FillGrid(qry, GridView1)
        'qry = "SELECT line_no AS [LineNo],attb_discrete+' :: '+CONVERT(VARCHAR,line_no) FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        '''''''''''''''qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1'"
        'objfun.FillList(chkItemList, qry)
        Try
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
            txtOrderNo.Enabled = False
            qry = "SELECT   bill_cust_no,address_1 + ' , ' + address_2 +' , ' + address_3 + ' , ' +  state +  ' , ' + country FROM miserp.som.dbo.t_order_hdr a(nolock), miserp.som.dbo.m_cust_address b(nolock) WHERE order_no='" & txtOrderNo.Text & "' AND a.bill_cust_no=b.cust_no  "
            objfun.FillList(ddlShipmentAddress, qry)
            ddlShipmentAddress_SelectedIndexChanged(sender, e)

            ' new code 
            qry = "SELECT   a.bill_cust_no,b.address_1 + ' , ' + b.address_2 +' , ' + b.address_3 + ' , ' +  b.state +  ' , ' + b.country,d.crr_name as Transportar FROM miserp.som.dbo.t_order_hdr a(nolock), miserp.som.dbo.m_cust_address b(nolock),miserp.som.dbo.m_customer c , miserp.som.dbo.dms_m_carrier_hdr d WHERE   a.bill_cust_no=b.cust_no and b.cust_no=c.cust_no and c.carrier_no=d.crr_no and order_no= '" & txtOrderNo.Text & "' "

            Dim cmd As SqlCommand = New SqlCommand(qry, obj.Connection)
            obj.ConOpen()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read
                    txtCarrierName.Text = dr.Item(2)
                End While
            End If
            obj.ConClose()
        Catch ex As Exception
            objfun.Alert("Unable To Fetch Data...!!!")
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  txtOrderNo.Attributes.Add("onKeyPress", "doClick('" + BtnFetch.ClientID + "',event)")
            txtOrderNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + cmdSearch.UniqueID + "').click();return false;}} else {return true}; ")
            qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "'"
            objfun.DeleteRecord(qry)
            ' qry = "SELECT ProcUsed+convert(varchar,isnull(ReqTypeCode,0)),ReqAreaName FROM Jct_Ops_Request_Area_Master order by ReqTypeCode"
            qry = "SELECT ProcUsed+convert(varchar,isnull(ReqTypeCode,0)),ReqAreaName+'~'+CONVERT(VARCHAR,a.AreaCode) FROM dbo.Jct_Ops_SanctioNote_Area_Master a,Jct_Ops_Request_Area_Master b WHERE a.AreaName=ReqAreaName and a.status='a' and b.status='a' order by ReqAreaName"
            objfun.FillList(ddlRequestType, qry)
            ddlRequestType_SelectedIndexChanged(sender, e)
            Pnl_OtherCust.Visible = False

            qry = "SELECT DISTINCT Trans_code,DESCRIPTION , TransModeCode  FROM JCT_ExpDoc_TransportMode "
            cmd = New SqlCommand(qry, obj.Connection())
            dr = cmd.ExecuteReader()
            If dr.HasRows = True Then
                While (dr.Read())
                    Me.ddlMode.Items.Add(dr.Item(0))
                    Me.ddlModeDescription.Items.Add(dr.Item(1))
                    'txtModeCode.Text = dr.Item("TransModeCode")
                End While
            End If

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

        Dim str() As String
        str = ddlRequestType.SelectedItem.Text.Split("~")

        ' If ddlRequestType.SelectedItem.Text <> "ODS Stock Sell" And Left(ddlRequestType.SelectedItem.Text, 3).ToUpper <> "ODS" Then
        If str(0).ToUpper <> "EXCESS STOCK" And str(0).ToUpper <> "ODS STOCK SELL" Then
            Cn = "Data Source=Miserp;Initial Catalog=" & Dbase & ";Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 0;"
            qry = "exec " & Proc & " 'JCT00LTD', 'PHG', 1,  '" & txtSearchSort.Text & "','" & txtSearchVariant.Text & "','" & txtSearchShade.Text & "','" & txtOrderNo.Text & "','N'"
        Else
            Cn = "Data Source=Misdev;Initial Catalog=" & Dbase & ";Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 0;"
            qry = "exec " & Proc & " '', '" & txtSearchSort.Text & "','" & txtSearchSaleOrder.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "'"
        End If

        Dim SqlCon As SqlConnection = New SqlConnection(Cn)
        'If txtSearchSaleOrder.Text = "" Then
        '    qry = "exec " & Proc & " 'JCT00LTD', 'PHG', 1,  '" & txtSearchSort.Text & "','" & txtSearchVariant.Text & "','" & txtSearchShade.Text & "','" & txtOrderNo.Text & "','N'"
        'Else
        '    qry = "exec " & Proc & " '" & txtSearchSort.Text & "','" & txtSearchVariant.Text & "','" & txtSearchShade.Text & "','" & txtSearchSaleOrder.Text & "','N'"
        'End If



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
        Dim SelctionStatus As Boolean = False
        Dim AreaSelected As String()
        Dim Area As Int16
        AreaSelected = ddlRequestType.SelectedItem.Text.Split("~")
        Area = CType(AreaSelected(1), Int16)



        Try

            If (LCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "ods" Or LCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "exc") And GrdEmployee.Rows.Count = 0 Then
                Throw New Exception("No Authorization hierarchy is Present for: - " & ddlRequestType.SelectedItem.Text & " Unable to proceed ")
            End If

            If LCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "exc" And LblAddress.Text = "" Then
                Throw New Exception("No Shipment Address for: - " & ddlRequestType.SelectedItem.Text & " Unable to proceed ")
            End If

            If LCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "inv" Then
                For i = 0 To GridView1.Rows.Count - 1
                    If CType(GridView1.Rows(i).FindControl("chkSelection"), CheckBox).Checked = True Then
                        SelctionStatus = True
                    End If
                Next
                If SelctionStatus = False Then
                    'objfun.Alert("Please Select at atleast one Item ")

                    Dim script1 As String = "alert('Please Select at atleast one Item !!');"
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script1, True)
                    Exit Sub
                End If
            End If

            qry = "exec Jct_Ops_ODS_Request_GenrateRequestID_Update '" & txtSearchRequestId.Text & "' "
            cmd = New SqlCommand(qry, obj.Connection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Transaction = Tran
            'cmd.Connection = obj.Connection
            'cmd.ExecuteNonQuery()
            SanctionID1 = txtSearchRequestId.Text
            SanctionID = txtSearchRequestId.Text
            Body1 = Body1 & " <hr> Description :- " & txtDescription.Text & "<hr> "
            If ddlRequestType.SelectedItem.Text = "ODS" Then
                qry = " exec Jct_Ops_ODS_Insert_HDR_UPDATE '" & Session("Empcode") & "','" & Area & "','" & txtSubject.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & SanctionID & "','" & ddlPlant.SelectedItem.Text & "','" & ddlRequestType.SelectedItem.Text & "','" & ddlMode.SelectedItem.Text & "','" & ddlFreightType.SelectedItem.Text & "','" & ddlDocsSentTo.SelectedItem.Text & "','" & LblAddress.Text & "','" & txtTransportDetail.Text & "','" & txtRemarks.Text & "'"
            Else
                qry = " exec Jct_Ops_ODS_Insert_HDR_UPDATE '" & Session("Empcode") & "','" & Area & "','" & txtSubject.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtSearchRequestId.Text & "','" & ddlPlant.SelectedItem.Text & "','" & ddlRequestType.SelectedItem.Text & "','" & ddlMode.SelectedItem.Text & "','" & ddlFreightType.SelectedItem.Text & "','" & ddlDocsSentTo.SelectedItem.Text & "','" & LblAddress.Text & "','" & txtTransportDetail.Text & "','" & txtRemarks.Text & "'"
            End If
            objfun.InsertRecord(qry, Tran, obj.Connection)
            'qry = "exec Jct_Ops_Expdoc_Insert_request_generate   '" & Session("Empcode") & "','" & SanctionID & "','" & txtOrderNo.Text & "', '" & txtNotifyName.Text & "' , '" & txtNotifyAdd1.Text & "' , '" & txtNotifyAdd2.Text & "' , '" & txtNotifyAdd3.Text & "' , '" & txtNotifyCity.Text & "' , '" & txtNotifyState.Text & "' , '" & txtNotifyCountry.Text & "' "
            'objfun.InsertRecord(qry, Tran, obj.Connection)
            With GrdTempValues
                OrderVar = ""
                qry = ""
                Dim EmpLevelCount As Int16 = 0
                If AreaSelected(0).ToUpper <> "EXCESS STOCK" Then


                    qry = "Jct_Ops_Ods_Request_SalePersonHierarchy_Insert_update"
                    'cmd = New SqlCommand(qry, obj.Connection)
                    cmd.Transaction = Tran
                    cmd.Connection = obj.Connection
                    cmd.CommandText = qry
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.Add(New SqlParameter("@SanctionNote", SqlDbType.VarChar, 15)).Value = txtSearchRequestId.Text
                    cmd.Parameters.Add(New SqlParameter("@UserCode", SqlDbType.VarChar, 10)).Value = Session("Empcode")
                    cmd.Parameters.Add(New SqlParameter("@Areacode", SqlDbType.Int)).Value = Area


                    Dim Param As SqlParameter
                    Param = cmd.Parameters.Add("@MaxID", SqlDbType.SmallInt)
                    cmd.Parameters("@MaxID").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    EmpLevelCount = cmd.Parameters("@MaxID").Value
                End If
                'cmd.Dispose()
                'cmd.
                'Comented by Ashish EmpLevelCount = ChkDynamicListing.Items.Count
                'ElseIf AreaSelected(0).ToUpper <> "EXCESS STOCK" Then
                Dim StarIDForDynamicUser As Int16 = 0
                StarIDForDynamicUser = EmpLevelCount + ChkDynamicListing.Items.Count
                'If GrdEmployee.Rows.Count > 1 Then

                '    For i = 0 To ChkDynamicListing.Items.Count - 1
                '        qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_TEST(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL) values('" & SanctionID & "','" & Session("empcode") & "','" & Area & "','" & ChkDynamicListing.Items(i).Value & "'," & i + 1 + EmpLevelCount & ")"
                '        cmd = New SqlCommand(qry, obj.Connection)
                '        cmd.Transaction = Tran
                '        cmd.ExecuteNonQuery()
                '    Next

                '    qry = "exec Jct_Ops_Request_InsertDynamic_User '" & SanctionID & "','" & Session("empcode") & "','" & Area & "'," & StarIDForDynamicUser & ",'" & ddlPlant.SelectedItem.Text & "'," & Right(ddlRequestType.SelectedItem.Value, 1) & ""
                '    objfun.InsertRecord(qry, Tran, obj.Connection)

                '    If AreaSelected(0).ToUpper <> "EXCESS STOCK" Then
                '        For i = 0 To chkNotify.Items.Count - 1
                '            qry = "INSERT INTO dbo.Jct_Ops_SanctionNote_Notify_Test( Usercode ,SanctionID ,NotifyUser , CreatedDate) values('" & Session("Empcode") & "','" & SanctionID & "','" & chkNotify.Items(i).Value & "',getdate())"
                '            cmd = New SqlCommand(qry, obj.Connection)
                '            cmd.Transaction = Tran
                '            cmd.ExecuteNonQuery()
                '        Next
                '    ElseIf AreaSelected(0).ToUpper = "EXCESS STOCK" Then


                '        With GrdCostDetail
                '            For i = 0 To .Rows.Count - 1
                '                cmd = New SqlCommand()
                '                cmd.Connection = obj.Connection
                '                Dim txtSellingPrice As TextBox = CType(.Rows(i).FindControl("txtProposedSellingPrice"), TextBox)
                '                Dim ddlRateUom As DropDownList = CType(.Rows(i).FindControl("ddlRateUom"), DropDownList)
                '                ' qry = "INSERT INTO dbo.Jct_Ops_SanctionNote_CostDetail ( Usercode ,SanctionNoteID ,UserLevel ,ItemNo ,Variant ,SellingPrice ,Remarks ,STATUS ,CreatedDate , UserIP) 
                '                'values ('" & Session("Empcode") & "','" & SanctionID & "',0,'" & .Rows(i).Cells(0).Text & "','" & .Rows(i).Cells(1).Text & "'," & txtSellingPrice.Text & ",'" & txtRemarks.Text & "','A',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "') "
                '                cmd.CommandText = "Jct_Ops_SanctionNote_ExcessStock_Sell_Insert_CostDetail"
                '                cmd.CommandType = CommandType.StoredProcedure
                '                cmd.Parameters.AddWithValue("@Usercode", Session("Empcode"))
                '                cmd.Parameters.AddWithValue("@SanctionNote", SanctionID)
                '                cmd.Parameters.AddWithValue("@UserLevel", 0)
                '                cmd.Parameters.AddWithValue("@ItemCode", .Rows(i).Cells(0).Text)
                '                cmd.Parameters.AddWithValue("@Variant", .Rows(i).Cells(1).Text)
                '                cmd.Parameters.AddWithValue("@SellingPrice", txtSellingPrice.Text)
                '                cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text)
                '                cmd.Parameters.AddWithValue("@UserIP", Request.ServerVariables("REMOTE_ADDR"))
                '                cmd.Parameters.AddWithValue("@RateUom", ddlRateUom.SelectedItem.Text)

                '                cmd.Transaction = Tran
                '                cmd.ExecuteNonQuery()
                '            Next
                '        End With

                '        qry = "Jct_Ops_ODS_Import_Cost_For_AllUsers '" & SanctionID & "'"
                '        cmd = New SqlCommand
                '        cmd.Connection = obj.Connection
                '        cmd.CommandType = CommandType.StoredProcedure
                '        cmd.Transaction = Tran
                '        cmd.CommandText = "Jct_Ops_ODS_Import_Cost_For_AllUsers"
                '        cmd.Parameters.AddWithValue("@SanctionNote", SanctionID)
                '        cmd.ExecuteNonQuery()

                '    End If
                'End If
            End With


            qry = "Jct_Ops_Expdoc_Insert_request_generate_Update"
            con1.Open()

            'cmd.CommandText = "Jct_Ops_Expdoc_Insert_request_generate"
            'qry = "exec Jct_Ops_Expdoc_Insert_request_generate   '" & Session("Empcode") & "','" & SanctionID & "','" & txtOrderNo.Text & "', '" & txtNotifyName.Text & "' , '" & txtNotifyAdd1.Text & "' , '" & txtNotifyAdd2.Text & "' , '" & txtNotifyAdd3.Text & "' , '" & txtNotifyCity.Text & "' , '" & txtNotifyState.Text & "' , '" & txtNotifyCountry.Text & "' , '" & txtBuyerPo.Text & "' , '" & ddlMode.Text & "'  "
            cmd = New SqlCommand(qry, con1)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10).Value = Session("Empcode")
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = txtSearchRequestId.Text
            cmd.Parameters.Add("@po_no", SqlDbType.VarChar, 50).Value = txtOrderNo.Text
            cmd.Parameters.Add("@notifyname", SqlDbType.VarChar, 50).Value = txtNotifyName.Text
            cmd.Parameters.Add("@notifyadd1", SqlDbType.VarChar, 50).Value = txtNotifyAdd1.Text
            cmd.Parameters.Add("@notifyadd2", SqlDbType.VarChar, 50).Value = txtNotifyAdd2.Text
            cmd.Parameters.Add("@notifyadd3", SqlDbType.VarChar, 50).Value = txtNotifyAdd3.Text
            cmd.Parameters.Add("@notifycity", SqlDbType.VarChar, 50).Value = txtNotifyCity.Text
            cmd.Parameters.Add("@notifystate", SqlDbType.VarChar, 50).Value = txtNotifyState.Text
            cmd.Parameters.Add("@notifycountry", SqlDbType.VarChar, 50).Value = txtNotifyCountry.Text
            cmd.Parameters.Add("@buyerPo", SqlDbType.VarChar, 20).Value = txtBuyerPo.Text
            cmd.Parameters.Add("@TransMode", SqlDbType.VarChar, 20).Value = ddlMode.Text
            cmd.Parameters.Add("@PaymentTerm", SqlDbType.VarChar, 20).Value = txtPayTerm.Text

            If txtDestinationPort.Visible = True Then
                cmd.Parameters.Add("@DestinationPort", SqlDbType.VarChar, 20).Value = txtDestinationPort.Text
            Else
                cmd.Parameters.Add("@DestinationPort", SqlDbType.VarChar, 20).Value = ""
            End If
            If txtDespatchPort.Visible = True Then
                cmd.Parameters.Add("@DespatchPort", SqlDbType.VarChar, 20).Value = txtDespatchPort.Text
            Else
                cmd.Parameters.Add("@DespatchPort", SqlDbType.VarChar, 20).Value = ""
            End If

            cmd.Parameters.Add("@TransDescrip", SqlDbType.VarChar, 20).Value = ddlModeDescription.Text
            cmd.Parameters.Add("@Transmodecode", SqlDbType.VarChar, 20).Value = txtModeCode.Text
            cmd.Parameters.Add("@CarrierName", SqlDbType.VarChar, 50).Value = txtCarrierName.Text
            cmd.ExecuteNonQuery()
            con1.Close()


            qry = "Jct_Ops_Transfer_Request_Intermediate_sumry"
            'con1.Open()

            cmd = New SqlCommand(qry, obj.Connection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10).Value = Session("Empcode")
            cmd.Transaction = Tran
            cmd.ExecuteNonQuery()
            'cmd.ExecuteReader()
            'con1.Close()


            Tran.Commit()

            'objfun.Alert("Record Saved Sucessfully !!")

            Dim script As String = "alert('Record Updated Sucessfully !!');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)


            lblID.Text = SanctionID
            CmdApply.Enabled = False

        Catch ex As Exception
            'FileName = "Unable to Complete Transaction " & ex.Message
            'objfun.Alert(FileName)
            'objfun.Alert("Unable To Complete Transaction !!")
            Dim script As String = "alert('Unable to Complete Transaction !!');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
            Tran.Rollback()
            'MessageBox1.ShowError("Unable to Complete Transaction " & ex.ToString)

            Exit Sub
        End Try

        qry = "Select SourceOrder as PackedIn, Item_no as SortNo, Bale_no as BaleNo,Varaint,Meters from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("empcode") & "' "
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
        dr.Close()


        Dim RequestGenratedFor As String = "Noreply@jctltd.com"
        qry = "SELECT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='" & SanctionID & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read
                NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
            End While
        End If
        dr.Close()

        body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br> " & ddlRequestType.SelectedItem.Text & " with ID <b>" & SanctionID & " </b> has been genrated  With Following Detail "
        'GenrateMail(body, Body1, Body2, Body3, SanctionID, GenratedByName, Genratedby_Email, NotifyEmailGroup, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your " & ddlRequestType.SelectedItem.Text & " No :-" & SanctionID & " has been genrated ", SanctionID, "a")
        'Newly Added Code start from below line' GenrateMail("hi", "a", "a", "a", "a", "a", "a", "a", "a", "a", "100008", "Ashish", ddlMode.SelectedItem.Text, ddlFreightType.SelectedItem.Text, ddlDocsSentTo.SelectedItem.Text, GenratedByName)










        'NotifyEmailGroup = "Noreply@jctltd.com"
        'qry = "exec Jct_Ops_Ods_GetSale_Persons '" & Session("Empcode") & "',''"
        'cmd = New SqlCommand(qry, obj.Connection)
        'dr = cmd.ExecuteReader
        'If dr.HasRows = True Then
        '    While dr.Read
        '        NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
        '    End While
        'End If
        'dr.Close()

        qry = "SELECT DISTINCT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='" & SanctionID & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read
                NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
            End While
        End If
        dr.Close()

        'GenrateMail("hi", "a", "a", "a", "a", "a", NotifyEmailGroup, "a", "a", "Your Despatch Instruction has been Genrated ", SanctionID, "Ashish", ddlMode.SelectedItem.Text, ddlFreightType.SelectedItem.Text, ddlDocsSentTo.SelectedItem.Text, GenratedByName, Genratedby_Email)

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

        ClearAll()
        Dim AreaSelected As String()

        Dim Area As Int16
        AreaSelected = ddlRequestType.SelectedItem.Text.Split("~")
        Area = CType(AreaSelected(1), Int16)

        'AreaSelected = ddlRequestType.SelectedItem.Text.Split("~")

        Dim ReqCode As Int16 = 0
        GrdBasicDetail.DataSource = Nothing
        GrdBasicDetail.DataBind()


        qry = "SELECT  ReqTypeCode FROM Jct_Ops_Request_Area_Master WHERE ReqAreaName='" & AreaSelected(0) & "'"
        ReqCode = 0
        ReqCode = objfun.FetchValue(qry)
        qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_Request_Area_Hierarchy a ,dbo.JCT_EmpMast_Base C WHERE  a.reqtypeCode=" & ReqCode & " AND c.empcode = a.empcode AND a.plant = '" & ddlPlant.SelectedItem.Text & "'  ORDER BY AuthLevel"
        objfun.FillGrid(qry, GrdEmployee)

        RblSearch_Cust.Items(0).Selected = True
        If UCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "ODS" Or UCase(Left(ddlRequestType.SelectedItem.Text, 4)) = "UNIS" Then 'Or UCase(Left(ddlRequestType.SelectedItem.Text, 4)) = "EXCE" Then

            lblDestination.Visible = False
            txtDestinationPort.Visible = False
            lblPortofDispatch.Visible = False
            txtDespatchPort.Visible = False

            txtOrderNo.Text = "N/A"
            txtOrderNo.Enabled = False
            cmdSearch.Visible = False
            'PnlAuthorization.Visible = True
            Pnl_Emplyee_Hierarchy.Visible = True
            Pnl_DepatchDetail.Visible = False
            Label2.Visible = True

            GetODSImpact(False)
            qry = "Select ReasonCode,ReasonDesc from Jct_Ops_Reason_Master where status='A' and area='1015' and subarea='" & Area & "'"

            objfun.FillList(ddlReason, qry)
        Else
            lblDestination.Visible = False
            txtDestinationPort.Visible = False
            lblPortofDispatch.Visible = False
            txtDespatchPort.Visible = False

            Label2.Visible = False
            lblReason.Visible = False
            ddlReason.Visible = False
            Pnl_Emplyee_Hierarchy.Visible = False
            PnlAuthorization.Visible = False
            Pnl_DepatchDetail.Visible = True
            txtOrderNo.Text = ""
            txtOrderNo.Enabled = True
            cmdSearch.Visible = True
            GetODSImpact(True)
            If UCase(Left(ddlRequestType.SelectedItem.Text, 4)) = "EXCE" Then
                ReqdVariant.Enabled = False
                RblSearch_Cust.Items(1).Selected = True
                Pnl_Emplyee_Hierarchy.Visible = True
                txtOrderNo.Enabled = False
            End If
        End If
        If ddlRequestType.SelectedItem.Text = "ODS Stock Sell~1033" Then
            Lbl_Search_SaleOrder.Text = "RequestID"
            Lbl_Shade.Text = "OrderNO"
            ReqdVariant.Enabled = False
            lblReason.Visible = False
            ddlReason.Visible = False
        ElseIf UCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "ODS" Or UCase(Left(ddlRequestType.SelectedItem.Text, 4)) = "UNIS" Then
            Lbl_Shade.Text = "Shade"
            lblReason.Visible = True
            ddlReason.Visible = True
            ReqdVariant.Enabled = True
            Lbl_Search_SaleOrder.Text = "Order No."
            lblDestination.Visible = False
            txtDestinationPort.Visible = False
            lblPortofDispatch.Visible = False
            txtDespatchPort.Visible = False

        End If

        If ddlRequestType.SelectedItem.Text = "Invoice Export~1038" Then

            lblPortofDispatch.Visible = True
            txtDespatchPort.Visible = True
        ElseIf ddlRequestType.SelectedItem.Text = "Invoice Domestic~1040" Then

            lblDestination.Visible = True
            txtDestinationPort.Visible = True

        End If


    End Sub

    Public Sub GenrateMail(Body As String, Body1 As String, Body2 As String, Body3 As String, OrderNo As String, SalesPerson_Name As String, [to] As String, cc As String, bcc As String, Subject As String, ID As String, PendingAt As String, DespatchMode As String, FreightType As String, DocsLocation As String, GenratedBy As String, GenratedbyEmail As String)
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
        If LCase(ddlRequestType.SelectedItem.Text) <> "excess stock~1041" Then
            sb.AppendLine("Request for " + ddlRequestType.SelectedItem.Text + " has been genrated by <b> Mr/Ms " & GenratedBy & " <br/><br/> on the behalf of Mr/Ms/Mrs <b>" + GridView1.Rows(0).Cells(3).Text + "</b> ")
        Else
            sb.AppendLine("Request for " + ddlRequestType.SelectedItem.Text + " has been genrated by <b> Mr/Ms " & GenratedBy & " <br/><br/>  ")
        End If
        sb.AppendLine("RequestID for your request is : " + ID + " <br/><br/>")


        sb.AppendLine("SUBJECT : " + txtSubject.Text + " <br/><br/>")
        sb.AppendLine("DESCRIPTION: " + txtDescription.Text + " <br/><br/>")


        Dim GridHeader As String = ""
        Dim J As Int16 = 0
        Dim No_Of_Cols As Int16 = 0
        sb.AppendLine("<B>Request Raise For </b>")

        'If LCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "inv" Then
        sb.AppendLine("<table class=gridtable>")

        'body__2 = Body__1
        With GridView1

            No_Of_Cols = 10
            For i = 0 To GridView1.Rows.Count - 1
                If CType(GridView1.Rows(i).FindControl("chkSelection"), CheckBox).Checked = True Then

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
                        If i = 0 Then
                            'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                            GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                        End If
                        query += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                    Next
                    sb.AppendLine(query & " </tr>")
                    'For i = 0 To GrdTempValues.Rows.Count - 1
                    '    If CType(GrdTempValues.Rows(i).FindControl("ChkDelete"), CheckBox).Checked = True Then

                    '        'If i = 0 Then
                    '        query = "<tr>"
                    '        'This if is used to Fetch Header from Gridview
                    '        If i = 0 Then
                    '            For J = 1 To 10 '.Columns.Count

                    '                GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"

                    '            Next
                    '            sb.AppendLine(GridHeader & " </tr>")
                    '        End If

                    '        'This loops feteches data from each cell of grid
                    '        For J = 1 To 10 '.Columns.Count
                    '            If i = 0 Then
                    '                'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                    '                GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                    '            End If
                    '            query += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                    '        Next
                    '        sb.AppendLine(query & " </tr>")
                End If
            Next
        End With
        sb.AppendLine("</table>")
        'End If
        sb.AppendLine("<br />")
        '  sb.AppendLine("<tr><th> OrderNo</th> <th> SaleP.Code</th> <th> SalePCode</th> <th> SalePersonName</th> <th> Sort</th>   <th> Line</th> <th> SHade</th>  </tr>")






        'sb.AppendLine("Details for " & ddlRequestType.SelectedItem.Text & " are Shown below : *       <br/><br/>")
        'sb.AppendLine("<table class=gridtable>")
        'If LCase(ddlRequestType.SelectedItem.Text) <> "excess stock~1041" Then
        '    'body__2 = Body__1
        '    If (ddlRequestType.SelectedIndex = 0 Or ddlRequestType.SelectedIndex = 1) Then
        '        sb.AppendLine("<tr><th> PackedIn</th> <th> SortNo</th> <th> BaleNo</th> <th> Variant</th> <th> Meters</th>   <th> Auth. Pending At</th> </tr>")
        '    Else
        '        sb.AppendLine("<tr><th> PackedIn</th> <th> SortNo</th> <th> BaleNo</th> <th> Variant</th> <th> Meters</th> </tr>")
        '    End If
        '    qry = "Select SourceOrder as PackedIn, Item_no as SortNo, Bale_no as BaleNo,Varaint as Variant,Meters from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("empcode") & "' "
        '    cmd = New SqlCommand(qry, obj.Connection) '
        '    dr = cmd.ExecuteReader
        '    While (dr.Read())
        '        If Left(LCase(ddlRequestType.SelectedItem.Text), 3) = "ods" Or Left(LCase(ddlRequestType.SelectedItem.Text), 3) = "inv" Then
        '            sb.AppendLine("<tr> <td> " & dr(0).ToString & " </td> <td> " & dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  <td>" & dr(3).ToString & " </td>  <td>" & dr(4).ToString & " </td></tr> ")
        '        Else
        '            sb.AppendLine("<tr><th> PackedIn</th> <th> SortNo</th> <th> BaleNo</th> <th> Variant</th> <th> Meters</th> <th> Return Qty</th> </tr>")
        '            ' sb.AppendLine("<tr> <td> " & dr(0).ToString & " </td> <td> " & dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  <td>" & dr(3).ToString & " </td>  <td>" & dr(4).ToString & " </td>  <td>" & dr(5).ToString & "</td>  <td>" & Pending & "</td> </tr> ")
        '        End If
        '        '-- Genratedby_Email = Genratedby_Email & "," & dr.Item(2)
        '        'Body3 = "<br><br><hr> This is Pending At <b>" & dr.Item(1) & " </b> "
        '    End While
        '    dr.Close()
        '    obj.ConClose()
        '    sb.AppendLine("</table>")
        '    sb.AppendLine("<br />")
        '    If LCase(Left(ddlRequestType.SelectedItem.Text, 3)) = "inv" Then
        '        sb.AppendLine("<B>Mode of Despatch :-</b>")
        '        sb.AppendLine("" & DespatchMode & "<br/><br/>")
        '        sb.AppendLine("<b>Freight Type :-</b>")
        '        sb.AppendLine("" & FreightType & "<br/><br/>")
        '        sb.AppendLine("<B>Documents to be Sent to :- </B>")
        '        sb.AppendLine("" & DocsLocation & "<br/><br/>")

        '        sb.AppendLine("<B>Shippment Address:- </B>")
        '        sb.AppendLine("" & ddlShipmentAddress.SelectedItem.Text & "<br/><br/>")

        '        sb.AppendLine("<B>Prefered Logistics :- </B>")
        '        sb.AppendLine("" & txtTransportDetail.Text & "<br/><br/>")
        '    End If
        '    'sb.AppendLine("This request is genrated by <b> " & GenratedBy & "</b><br/><br/>")
        'Else

        '    sb.AppendLine("<table class=gridtable>")
        '    GridHeader = ""
        '    j = 0

        '    With GrdTempValues


        '        For i = 0 To GrdTempValues.Rows.Count - 1

        '            query = "<tr>"
        '            'This if is used to Fetch Header from Gridview
        '            If i = 0 Then
        '                For J = 1 To 6 '.Columns.Count
        '                    GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
        '                Next
        '                sb.AppendLine(GridHeader & " </tr>")
        '            End If

        '            'This loops feteches data from each cell of grid
        '            For J = 1 To 6 '.Columns.Count
        '                If i = 0 Then
        '                    'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
        '                    GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
        '                End If
        '                query += "<td>" & .Rows(i).Cells(J).Text & "</td>"
        '            Next
        '            sb.AppendLine(query & " </tr>")

        '        Next
        '    End With
        '    sb.AppendLine("</table><br/>")

        'End If


        sb.AppendLine("Notifer Details : * <br/><br/>")
        sb.AppendLine("<table class=gridtable>")
        sb.AppendLine("<tr><th> NOTIER NAME </th> <th> ADDRESS1 </th> <th> ADDRESS2 </th> <th> ADDRESS3 </th> <th> CITY </th>   <th> STATE </th>  <th> COUNTRY </th> <th> BUYERS PO </th> <th> PAYMENT TERM </th> <th> DESTINATION COUNTRY </th>  <th> DESPATCH COUNTRY </th> <th> CARRIER NAME </th>  </tr>")
        qry = "Select notifyname, notifyadd1, notifyadd2,notifyadd3,notifycity,notifystate,notifycountry,buyerPo,PaymentTerm,DestinationPort,DespatchPort,CarrierName  from Jct_Ops_Expdoc_request_generate where SanctionNoteID ='" & SanctionID1 & "' "
        con1.Open()
        cmd = New SqlCommand(qry, con1)
        dr = cmd.ExecuteReader
        While (dr.Read())
            sb.AppendLine("<tr> <td> " & dr(0).ToString & " </td> <td> " & dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  <td>" & dr(3).ToString & " </td>  <td>" & dr(4).ToString & " </td> <td>" & dr(5).ToString & " </td> <td>" & dr(6).ToString & " </td> <td>" & dr(7).ToString & " </td> <td>" & dr(8).ToString & " </td> <td>" & dr(9).ToString & " </td> <td>" & dr(10).ToString & " </td> <td>" & dr(11).ToString & " </td> </tr> ")
        End While
        dr.Close()
        con1.Close()
        sb.AppendLine("</table>")



        sb.AppendLine("Summary Details : * <br/><br/>")
        sb.AppendLine("<table class=gridtable>")
        sb.AppendLine("<tr><th>ORDER ITEM </th> <th> SHADE </th> <th> BALE </th></tr>")
        qry = "Select order_item,shade ,bale1  from jct_ops_order_bale where hostid ='" & Session("Empcode") & "' "
        'con1.Open()
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        While (dr.Read())
            sb.AppendLine("<tr> <td> " & dr(0).ToString & " </td> <td> " & dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  </tr> ")
        End While
        dr.Close()
        'con1.Close()
        sb.AppendLine("</table>")




        sb.AppendLine("<br />")
        sb.AppendLine("<B>Mode of Despatch :-</b>")
        sb.AppendLine("" & DespatchMode & "<br/><br/>")
        sb.AppendLine("<b>Freight Type :-</b>")
        sb.AppendLine("" & FreightType & "<br/><br/>")
        sb.AppendLine("<B>Documents to be Sent to :- </B>")
        sb.AppendLine("" & DocsLocation & "<br/><br/>")

        sb.AppendLine("<B>Shippment Address:- </B>")
        sb.AppendLine("" & ddlShipmentAddress.SelectedItem.Text & "<br/><br/>")

        sb.AppendLine("<B>Carrier Name:- </B>")
        sb.AppendLine("" & txtCarrierName.Text & "<br/><br/>")

        sb.AppendLine("This request is genrated by <b> " & GenratedBy & "</b><br/><br/>")

        sb.AppendLine("</table><br />")
        sb.Append("<a href='http://misdev/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br />")
        sb.AppendLine("<i>This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br /></i>")
        sb.AppendLine("</html>")


        sb.AppendLine("<br/><br />")
        If GenratedbyEmail.Length > 10 Then
            [to] = [to] & "," & GenratedbyEmail
        End If
        ' [to] = "ashish@jctltd.com"
        bcc = "aslam@jctltd.com"
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
            If e.Row.RowType = DataControlRowType.DataRow And Right(Trim(e.Row.Cells(2).Text), 5) <> "Total" Then

                TmpMeters += Val(e.Row.Cells(6).Text)
                'yards += Val(e.Row.Cells(8).Text)
                'gr_wt += Val(e.Row.Cells(9).Text)
                'net_wt += Val(e.Row.Cells(10).Text)
            ElseIf e.Row.RowType = DataControlRowType.DataRow And Right(Trim(e.Row.Cells(2).Text), 5) = "Total" Then
                e.Row.CssClass = "GridAI"
            ElseIf e.Row.RowType = DataControlRowType.Footer Then

                'Dim lblGryMtrs As Label 
                ' CType(e.Row.FindControl("lblGryMtrs"), Label).Text = Meters
                e.Row.Cells(5).Text = "Total"
                e.Row.Cells(6).Text = TmpMeters
                e.Row.CssClass = "GridRowGreen"

            End If
        End With
        'With GrdTempValues
        '    If e.Row.RowType = DataControlRowType.DataRow Then

        '        TmpMeters += Val(e.Row.Cells(5).Text)
        '        'yards += Val(e.Row.Cells(8).Text)
        '        'gr_wt += Val(e.Row.Cells(9).Text)
        '        'net_wt += Val(e.Row.Cells(10).Text)
        '    ElseIf e.Row.RowType = DataControlRowType.Footer Then

        '        'Dim lblGryMtrs As Label
        '        ' CType(e.Row.FindControl("lblGryMtrs"), Label).Text = Meters
        '        e.Row.Cells(4).Text = "Total"
        '        e.Row.Cells(5).Text = TmpMeters

        '    End If
        'End With
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        'Dim NotifyEmailGroup As String = "Noreply@jctltd.com"
        'Try

        '    qry = "exec Jct_Ops_Ods_GetSale_Persons '" & Session("Empcode") & "',''"
        '    cmd = New SqlCommand(qry, obj.Connection)
        '    dr = cmd.ExecuteReader
        '    If dr.HasRows = True Then
        '        While dr.Read
        '            NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
        '        End While
        '    End If
        '    dr.Close()

        '    qry = "exec Jct_Ops_Ods_GetSale_Persons '','" & txtOrderNo.Text & "'"
        '    cmd = New SqlCommand(qry, obj.Connection)
        '    dr = cmd.ExecuteReader
        '    If dr.HasRows = True Then
        '        While dr.Read
        '            NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
        '        End While
        '    End If
        '    dr.Close()

        '    qry = "SELECT DISTINCT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='100000'"
        '    cmd = New SqlCommand(qry, obj.Connection)
        '    dr = cmd.ExecuteReader
        '    If dr.HasRows = True Then
        '        While dr.Read
        '            NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
        '        End While
        '    End If
        '    dr.Close()
        'Catch ex As Exception
        '    objfun.Alert(ex.Message.ToString)
        'End Try
        'GenrateMail("hi", "a", "a", "a", "a", "a", "it@jctltd.com", "a", "a", "Your Despatch Instruction has been Genrated ", "100008", "Ashish", ddlMode.SelectedItem.Text, ddlFreightType.SelectedItem.Text, ddlDocsSentTo.SelectedItem.Text, "Ashish Sharma", "a")
    End Sub


    Protected Sub imgAddRow_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgAddRow.Click
        Dim i As Int16
        Try
            With GrdBasicDetail
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("chkBox"), CheckBox).Checked = True Then
                        Dim str() As String
                        str = ddlRequestType.SelectedItem.Text.Split("~")

                        ' If ddlRequestType.SelectedItem.Text <> "ODS Stock Sell" And Left(ddlRequestType.SelectedItem.Text, 3).ToUpper <> "ODS" Then
                        If str(0).ToUpper <> "EXCESS STOCK" Then
                            qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "' and Bale_No='" & Trim(.Rows(i).Cells(3).Text) & "'"
                        Else
                            qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "' and Bale_No='" & Trim(.Rows(i).Cells(4).Text) & "'"
                        End If
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                        'Dim str() As String
                        'str = ddlRequestType.SelectedItem.Text.Split("~")


                        'If str(0).ToUpper <> "EXCESS STOCK" Then
                        If ddlRequestType.SelectedItem.Text = "ODS Stock Sell~1033" Then
                            qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate](Usercode ,SourceOrder ,Item_no ,Bale_No ,Varaint ,Meters) values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(8).Text) & "')"
                        ElseIf str(0).ToUpper = "EXCESS STOCK" Then
                            qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate](Usercode ,SourceOrder ,Item_no ,Bale_No ,Varaint ,Meters,Shade) values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(8).Text) & "','" & Trim(.Rows(i).Cells(4).Text) & "')"
                        Else
                            ' qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate] values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(10).Text) & "','A')"
                            qry = "exec Jct_Ops_Transfer_Request_Intermediate_Insert '" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(10).Text) & "','A','" & Trim(.Rows(i).Cells(11).Text) & "'"
                        End If
                        'objfun.InsertRecord(qry)
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End With
            With GrdPackedForOrder
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked = True Then


                        Dim str() As String
                        str = ddlRequestType.SelectedItem.Text.Split("~")

                        ' If ddlRequestType.SelectedItem.Text <> "ODS Stock Sell" And Left(ddlRequestType.SelectedItem.Text, 3).ToUpper <> "ODS" Then
                        If str(0).ToUpper <> "EXCESS STOCK" Then
                            qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "' and Bale_No='" & Trim(.Rows(i).Cells(3).Text) & "'"
                        Else
                            qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "' and Bale_No='" & Trim(.Rows(i).Cells(4).Text) & "'"
                        End If
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                        'Dim str() As String
                        'str = ddlRequestType.SelectedItem.Text.Split("~")


                        If ddlRequestType.SelectedItem.Text = "ODS Stock Sell~1033" Then
                            qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate](Usercode ,SourceOrder ,Item_no ,Bale_No ,Varaint ,Meters) values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(8).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(10).Text) & "','A')"
                        Else
                            ' qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate] values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(10).Text) & "','A')"
                            qry = "exec Jct_Ops_Transfer_Request_Intermediate_Insert '" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(10).Text) & "','A','" & Trim(.Rows(i).Cells(11).Text) & "'"

                        End If
                        'objfun.InsertRecord(qry)
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                    End If
                Next
                '.DataSource = Nothing
                '.DataBind()
            End With

        Catch

        Finally
            '  qry = "SELECT SourceOrder as PackedIn ,Item_no as ItemNo,Bale_No as BaleNo ,Varaint ,Meters  from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "'"
            qry = "Exec Jct_Ops_ODS_Intermediate_Fetch '" & Session("empcode") & "'"
            objfun.FillGrid(qry, GrdTempValues)
            ' new code added 
            'qry = "Exec Jct_Ops_Get_Excess_Stock_Items '" & Session("empcode") & "'"
            'objfun.FillGrid(qry, GrdCostDetail)
            If LCase(ddlRequestType.SelectedItem.Text) = "excess stock~1041" Then
                qry = "Exec Jct_Ops_Get_Excess_Stock_Items '" & Session("empcode") & "'"
                objfun.FillGrid(qry, GrdCostDetail)
            End If
        End Try
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
            ' qry = "Select  SourceOrder as PackedIn ,Item_no ,Bale_No ,Varaint ,Meters from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "' "
            qry = "Exec Jct_Ops_ODS_Intermediate_Fetch '" & Session("empcode") & "'"
            objfun.FillGrid(qry, GrdTempValues)
            'qry = "Exec Jct_Ops_Get_Excess_Stock_Items '" & Session("empcode") & "'"
            'objfun.FillGrid(qry, GrdCostDetail)
        End Try
    End Sub

    Private Sub GetODSImpact(Ods As Boolean)
        If Ods = True Then
            ddlDocsSentTo.Enabled = True
            ddlFreightType.Enabled = True
            ddlMode.Enabled = True
        Else
            ddlDocsSentTo.Enabled = False
            ddlFreightType.Enabled = False
            ddlMode.Enabled = False
        End If
    End Sub

    Protected Sub CmdRefresh_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles CmdRefresh.Click
        ClearAll()
    End Sub

    Private Sub ClearAll()
        GridView1.DataSource = Nothing
        GridView1.DataBind()

        GrdPackedForOrder.DataSource = Nothing
        GrdPackedForOrder.DataBind()

        GrdTempValues.DataSource = Nothing
        GrdTempValues.DataBind()

        GrdBasicDetail.DataSource = Nothing
        GrdBasicDetail.DataBind()


        qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        cmd.ExecuteNonQuery()

        ChkDynamicListing.Items.Clear()
        ChkEmpList.Items.Clear()
        chkNotify.Items.Clear()

        txtOrderNo.Enabled = True
        txtSearchSaleOrder.Text = ""
        txtSearchSort.Text = ""
        txtSearchShade.Text = ""
    End Sub

    Protected Sub ddlShipmentAddress_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlShipmentAddress.SelectedIndexChanged
        LblAddress.Text = ddlShipmentAddress.SelectedItem.Value
    End Sub

    Protected Sub ChkBasicDetail_SelAll_CheckedChanged(sender As Object, e As System.EventArgs)
        'ChkBasicDetail_SelAll
        With GrdBasicDetail
            For i = 0 To GrdBasicDetail.Rows.Count - 1
                CType(.Rows(i).FindControl("chkBox"), CheckBox).Checked = CType(.HeaderRow.FindControl("ChkBasicDetail_SelAll"), CheckBox).Checked
            Next
        End With

    End Sub

    Protected Sub GrdPackedForOrder_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdPackedForOrder.SelectedIndexChanged

    End Sub

    Protected Sub CmdSearchCust0_Click(sender As Object, e As System.EventArgs) Handles CmdSearchCust0.Click
        LblAddress.Text = ""
        If txtSearchCustomer.Text <> "" Then
            Dim Cust As String() = txtSearchCustomer.Text.Split("~")
            qry = "SELECT   b.cust_no,address_1 + ' , ' + address_2 +' , ' + address_3 + ' , ' +  state +  ' , ' + country FROM  miserp.som.dbo.m_cust_address b(nolock) WHERE  b.cust_no='" & Cust(1).ToString & "'  "
            objfun.FillList(ddlShipmentAddress, qry)
            ddlShipmentAddress_SelectedIndexChanged(sender, e)
        Else

        End If
    End Sub

    'Protected Sub cmdChooseCust_Click(sender As Object, e As System.EventArgs) Handles cmdChooseCust.Click
    '    If Pnl_OtherCust.Visible = True Then
    '        Pnl_OtherCust.Visible = False
    '    Else
    '        Pnl_OtherCust.Visible = True
    '    End If
    'End Sub

    Protected Sub CmdSearchClear_Click(sender As Object, e As System.EventArgs) Handles CmdSearchClear.Click
        ddlShipmentAddress.Items.Clear()
        LblAddress.Text = ""
    End Sub

    Protected Sub RblSearch_Cust_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RblSearch_Cust.SelectedIndexChanged

        If RblSearch_Cust.SelectedIndex = 1 Then
            Pnl_OtherCust.Visible = True
        Else
            Pnl_OtherCust.Visible = False
        End If

    End Sub

    Protected Sub ddlMode_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMode.SelectedIndexChanged
        ddlModeDescription.Items.Clear()
        txtModeCode.Text = ""
        qry = "SELECT DISTINCT DESCRIPTION , Transmodecode  FROM JCT_ExpDoc_TransportMode WHERE  TRANS_CODE = '" & ddlMode.Text & "' "
        cmd = New SqlCommand(qry, obj.Connection())
        dr = cmd.ExecuteReader()
        If dr.HasRows = True Then
            While (dr.Read())
                Me.ddlModeDescription.Items.Add(dr.Item(0))
                txtModeCode.Text = dr.Item("Transmodecode")
            End While
        End If
        'If ddlMode.Text = "AIR" Then
        '    txtModeCode.Text = "AWB NO"
        'End If
        'If ddlMode.Text = "ROAD" Then
        '    txtModeCode.Text = "TRNO"
        'End If

        'If ddlMode.Text = "SEA" Then
        '    txtModeCode.Text = "BLNO"
        'End If
    End Sub


    'Protected Sub imgTransportmode_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgTransportmode.Click
    '    Dim url As String = "TransportMode.aspx"
    '    Dim s As String = "window.open('" & url & "', 'popup_window', 'width=800,height=600,left=350,top=100,resizable=yes,scrollbars=yes');"
    '    ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

    'End Sub

    'Protected Sub imgTransportmode_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgTransportmode.Click
    '    Dim url As String = "TransportMode.aspx"
    '    Dim s As String = "window.open('" & url & "', 'popup_window', 'width=800,height=600,left=350,top=100,resizable=yes,scrollbars=yes');"
    '    ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    'End Sub


    Protected Sub ChkOrderSelAll_CheckedChanged(sender As Object, e As System.EventArgs)
        With GrdPackedForOrder
            For i = 0 To GrdPackedForOrder.Rows.Count - 1
                CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked = CType(.HeaderRow.FindControl("ChkOrderSelAll"), CheckBox).Checked
            Next
        End With
    End Sub


    Protected Sub CmdClear_Click(sender As Object, e As System.EventArgs) Handles CmdClear.Click
        Response.Redirect("Modify Despatch Instruction.aspx")
    End Sub



    Protected Sub Retrive_Click(sender As Object, e As System.EventArgs) Handles Retrive.Click

        Try

            qry = "Jct_Ops_Expdoc_request_generate_fetch"
            con1.Open()
            cmd = New SqlCommand(qry, con1)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 14).Value = txtSearchRequestId.Text
            dr = cmd.ExecuteReader()
            If (dr.HasRows = True) Then
                While dr.Read()
                    ddlMode.SelectedIndex = ddlMode.Items.IndexOf(ddlMode.Items.FindByText(dr("TransMode").ToString))
                    ddlModeDescription.SelectedIndex = ddlModeDescription.Items.IndexOf(ddlModeDescription.Items.FindByText(dr("TransDescrip").ToString))
                    txtModeCode.Text = dr.Item("Transmodecode")
                    txtNotifyName.Text = dr.Item("notifyname")
                    txtNotifyAdd1.Text = dr.Item("notifyadd1")
                    txtNotifyAdd2.Text = dr.Item("notifyadd2")
                    txtNotifyAdd3.Text = dr.Item("notifyadd3")
                    txtNotifyCity.Text = dr.Item("notifycity")
                    txtNotifyState.Text = dr.Item("notifystate")
                    txtNotifyCountry.Text = dr.Item("notifycountry")
                    txtBuyerPo.Text = dr.Item("buyerPo")
                    txtPayTerm.Text = dr.Item("PaymentTerm")
                    txtDestinationPort.Text = dr.Item("DestinationPort")
                    txtDespatchPort.Text = dr.Item("DespatchPort")
                    txtCarrierName.Text = dr.Item("CarrierName")
                    txtSubject.Text = dr.Item("SUBJECT")
                    txtDescription.Text = dr.Item("DESCRIPTION")
                    txtOrderNo.Text = dr.Item("po_no")
                    ddlFreightType.SelectedIndex = ddlFreightType.Items.IndexOf(ddlFreightType.Items.FindByText(dr("FreightType").ToString))
                    ddlDocsSentTo.SelectedIndex = ddlDocsSentTo.Items.IndexOf(ddlDocsSentTo.Items.FindByText(dr("DestinationLocation").ToString))
                    txtTransportDetail.Text = dr.Item("Prefred_Logistic")
                    txtRemarks.Text = dr.Item("Spl_Remarks")
                    ddlPlant.SelectedIndex = ddlPlant.Items.IndexOf(ddlPlant.Items.FindByText(dr("Plant").ToString))
                    ddlRequestType.SelectedIndex = ddlRequestType.Items.IndexOf(ddlRequestType.Items.FindByText(dr("RequestType").ToString))
                    lblID.Text = dr.Item("SanctionNoteID")

                End While
            End If
            con1.Close()

            qry = "Exec JCT_OPS_FETCH_NEW_SALEORDER_DETAILS '" & txtOrderNo.Text & "'"
            objfun.FillGrid(qry, GridView1)

            qry = "SELECT   bill_cust_no,address_1 + ' , ' + address_2 +' , ' + address_3 + ' , ' +  state +  ' , ' + country FROM miserp.som.dbo.t_order_hdr a(nolock), miserp.som.dbo.m_cust_address b(nolock) WHERE order_no='" & txtOrderNo.Text & "' AND a.bill_cust_no=b.cust_no  "
            objfun.FillList(ddlShipmentAddress, qry)
            ddlShipmentAddress_SelectedIndexChanged(sender, e)

            qry = "Exec Jct_Ops_ODS_Intermediate_Fetch_Update '" & txtSearchRequestId.Text & "'"
            objfun.FillGrid(qry, GrdTempValues)

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub CmdSendRequest_Click(sender As Object, e As System.EventArgs) Handles CmdSendRequest.Click
        Try

            Dim SanctionID As String = ""

            SanctionID = txtSearchRequestId.Text
            SanctionID1 = SanctionID
            Dim FileName As String = ""
            Dim i As Int16
            i = 0
            Dim ParmCode As String = ""
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

            qry = "Select SourceOrder as PackedIn, Item_no as SortNo, Bale_no as BaleNo,Varaint,Meters from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("empcode") & "' "
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
            dr.Close()


            Dim RequestGenratedFor As String = "Noreply@jctltd.com"
            qry = "SELECT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='" & SanctionID & "'"
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
                End While
            End If
            dr.Close()

            body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br> " & ddlRequestType.SelectedItem.Text & " with ID <b>" & SanctionID & " </b> has been genrated  With Following Detail "
            'GenrateMail(body, Body1, Body2, Body3, SanctionID, GenratedByName, Genratedby_Email, NotifyEmailGroup, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your " & ddlRequestType.SelectedItem.Text & " No :-" & SanctionID & " has been genrated ", SanctionID, "a")
            'Newly Added Code start from below line' GenrateMail("hi", "a", "a", "a", "a", "a", "a", "a", "a", "a", "100008", "Ashish", ddlMode.SelectedItem.Text, ddlFreightType.SelectedItem.Text, ddlDocsSentTo.SelectedItem.Text, GenratedByName)

            qry = "SELECT DISTINCT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='" & SanctionID & "'"
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
                End While
            End If
            dr.Close()
            Dim script As String = "alert('Mail Sent !!');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
            GenrateMail("hi", "a", "a", "a", "a", "a", NotifyEmailGroup, "a", "a", "Your Despatch Instruction has been Genrated ", SanctionID, "Ashish", ddlMode.SelectedItem.Text, ddlFreightType.SelectedItem.Text, ddlDocsSentTo.SelectedItem.Text, GenratedByName, Genratedby_Email)
            CmdSendRequest.Enabled = False
            CmdApply.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
End Class

