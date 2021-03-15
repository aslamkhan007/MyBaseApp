Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Partial Class OPS_Stock_Status_Marking
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objfun As Functions = New Functions
    Dim toEMail As String = "ashish@jctltd.com;jagdeep@jctltd.com;harendra@jctltd.com;rbaksshi@jctltd.com"
    Dim byEmailID As String = "ODS@jctltd.com"
    Dim objSendMail As SendMail = New SendMail
    Dim scrpt As String
    Dim empCode As String

    Dim obj As Connection = New Connection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction
    Protected Sub CmdTransfer_Click(sender As Object, e As System.EventArgs) Handles CmdTransfer.Click

        lblSanctionID.Text = ""
        Dim Cn As String = ""
        Dim SanctionID As String = ""

        Cn = "Data Source=Misdev;Initial Catalog=Production;Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 0;"
        con = New SqlConnection(Cn)

        con.Open()


        qry = "Select Usercode from Jctdev..Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "'"
        cmd = New SqlCommand(qry, con)
        dr = cmd.ExecuteReader
        dr.Read()


        If dr.HasRows = False Then
            scrpt = "alert('Please Search for any bale to transfer & then click (+) to shortlist...before proceeding !!!');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            con.Close()
            Exit Sub
        Else
            con.Close()
        End If

        con.Open()

        Tran = con.BeginTransaction
        Try
            qry = "SELECT TOP 1 Num FROM jctdev..JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL"
            SanctionID = objfun.FetchValue(qry, con, Tran)

            qry = " exec jctdev..Jct_Ops_SanctionNote_Insert_HDR_Import '" & Session("Empcode") & "','" & RdoStotckToSearch.SelectedItem.Value & "','" & ddlSubject.SelectedItem.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & SanctionID & "','" & ddlplant.SelectedItem.Text & "','N',''"
            objfun.InsertRecord(qry, Tran, con)


            ''Comented and code added in the Jct_Ops_SanctionNote_Insert_HDR_Import
            ''With GrdPackedForOrder
            ''    Dim i As Int16
            ''    For i = 0 To .Rows.Count - 1
            ''        Dim ChkSelection As Boolean = CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked
            ''        If ChkSelection = True And Trim(.Rows(i).Cells(4).Text.Replace("&nbsp;", "")) <> "" And Trim(.Rows(i).Cells(3).Text.Replace("&nbsp;", "")) <> "" Then
            ''            Dim Mtrs As Integer
            ''            Mtrs = 0
            ''            Mtrs = .Rows(i).Cells(6).Text
            ''            qry = "exec Jct_Ops_Excess_Stock_Bale_Transfer_Proc '" & Session("EmpCode") & "','" & .Rows(i).Cells(1).Text & "','" & .Rows(i).Cells(3).Text & "','" & .Rows(i).Cells(2).Text & "','" & .Rows(i).Cells(4).Text & "','" & .Rows(i).Cells(5).Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','T'," & Mtrs & ",'" & SanctionID & "','" & ddlOfferedToCust.SelectedItem.Text.Substring(0, 1).ToString & "' "
            ''            'objfun.InsertRecord(qry)
            ''            cmd = New SqlCommand(qry, con, Tran)
            ''            cmd.ExecuteNonQuery()
            ''        End If
            ''    Next
            ''End With
            qry = "exec Jct_Ops_Excess_Stock_Bale_Transfer_Proc '" & Session("EmpCode") & "','" & GrdTempValuesBaleDEtail.Rows(0).Cells(1).Text & "','" & GrdTempValuesBaleDEtail.Rows(0).Cells(3).Text & "','" & GrdTempValuesBaleDEtail.Rows(0).Cells(2).Text & "','" & GrdTempValuesBaleDEtail.Rows(0).Cells(4).Text & "','" & GrdTempValuesBaleDEtail.Rows(0).Cells(5).Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','T',0,'" & SanctionID & "','" & ddlOfferedToCust.SelectedItem.Text.Substring(0, 1).ToString & "' "
            'objfun.InsertRecord(qry)
            cmd = New SqlCommand(qry, con, Tran)
            cmd.ExecuteNonQuery()


            qry = "UPDATE  jctdev..JCT_OPS_SanctionNote_Codes SET IsConsumed = 'Y',DateConsumed = GETDATE() WHERE   Num = '" & SanctionID & "'  "
            objfun.UpdateRecord(qry, Tran, con)


            qry = "INSERT INTO jctdev..Jct_Ops_SanctionNote_Notify( Usercode ,SanctionID ,NotifyUser , CreatedDate)   " & _
                "Select '" & Session("empcode") & "','" & SanctionID & "','M-02509',Getdate()  "
            objfun.InsertRecord(qry, Tran, con)

            qry = "INSERT INTO jctdev..Jct_Ops_SanctionNote_Notify( Usercode ,SanctionID ,NotifyUser , CreatedDate)   " & _
                "Select '" & Session("empcode") & "','" & SanctionID & "','A-00131',Getdate()  "
            objfun.InsertRecord(qry, Tran, con)

            Dim EmpLevelCount As Int16 = 0
            EmpLevelCount = ChkDynamicListing.Items.Count

            For i = 0 To ChkDynamicListing.Items.Count - 1
                qry = "Insert into jctdev..JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL) values('" & SanctionID & "','" & Session("empcode") & "','1047','" & ChkDynamicListing.Items(i).Value & "'," & i + 1 & ")"
                cmd = New SqlCommand(qry, con)
                cmd.Transaction = Tran
                cmd.ExecuteNonQuery()
            Next

            qry = "exec jctdev..Jct_Ops_SanctionNote_InsertDynamic_User_ReasonWise '" & SanctionID & "','" & Session("empcode") & "','1047'," & EmpLevelCount & ",'" & ddlplant.SelectedItem.Text & "',111"
            objfun.InsertRecord(qry, Tran, con)

            For i = 0 To chkNotify.Items.Count - 1
                qry = "INSERT INTO jctdev..Jct_Ops_SanctionNote_Notify( Usercode ,SanctionID ,NotifyUser , CreatedDate) values('" & Session("Empcode") & "','" & SanctionID & "','" & chkNotify.Items(i).Value & "',getdate())"
                cmd = New SqlCommand(qry, con)
                cmd.Transaction = Tran
                cmd.ExecuteNonQuery()
            Next
            CmdTransfer.Enabled = False
            Tran.Commit()
            lblSanctionID.Text = SanctionID
            scrpt = "alert('Excess Stock Transfer Request genrated with ID  " + SanctionID + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            Try
                Sendmail(SanctionID)
            Catch ex As Exception

            End Try

        Catch ex As Exception
            Tran.Rollback()
            'objfun.Alert("Unable to Complete the transaction..Some records might not be saved !!")
            'scrpt = "alert('Unable to Continue..." + ex.Message.ToString + "');"
            scrpt = "alert('Unable to Save ...');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            Return
        Finally
            con.Close()
        End Try
    End Sub

    Protected Sub CmdSearchData_Click(sender As Object, e As System.EventArgs) Handles CmdSearchData.Click
        Try
            Dim Cn As String = ""
            Cn = "Data Source=Misdev;Initial Catalog=Production;Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 0;"
            ' If RdoStotckToSearch.SelectedIndex = 0 Then
            If RdoStotckToSearch.SelectedItem.Text = "Fresh Stock" Then
                'comented on 31-July2014  qry = "Exec Jct_Ops_Excess_Stock_Bales_Listing '" & txtSearchSaleOrder.Text & "','" & txtSearchSort.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "','" & Session("empcode") & "'"
                'qry = "Exec Jct_Ops_Excess_Stock_Bales_Listing '" & txtSearchSaleOrder.Text & "','" & txtSearchSort.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "','" & Session("empcode") & "'"
                qry = "Exec Jct_Ops_Excess_Stock_Bales_Listing_WithBale '" & txtSearchSaleOrder.Text & "','" & txtSearchSort.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "','" & Session("empcode") & "'"

                Dim SqlCon As SqlConnection = New SqlConnection(Cn)
                Status("")
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
                GrdPackedForOrder.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
                GrdPackedForOrder.DataBind()
                GrdHeldBales.DataSource = Nothing
                GrdHeldBales.DataBind()
            Else
                'If RdoStotckToSearch.SelectedIndex = 2 Then
                If RdoStotckToSearch.SelectedItem.Text = "Transfered Stock" Then
                    qry = "Exec Jct_Ops_Devlopment_Fetch_ODS_Bales '" & txtSearchSaleOrder.Text & "','" & txtSearchSort.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "','','" & Session("EmpCode") & "'"
                    Status("")
                Else
                    qry = "Exec Jct_Ops_Devlopment_Fetch_ODS_Bales '" & txtSearchSaleOrder.Text & "','" & txtSearchSort.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "','H','" & Session("EmpCode") & "'"
                    Status("f")
                End If
                'Dim SqlCon As SqlConnection = New SqlConnection(Cn)
                'If txtSearchSaleOrder.Text = "" Then
                '    qry = "exec " & Proc & " 'JCT00LTD', 'PHG', 1,  '" & txtSearchSort.Text & "','" & txtSearchVariant.Text & "','" & txtSearchShade.Text & "','" & txtOrderNo.Text & "','N'"
                'Else
                '    qry = "exec " & Proc & " '" & txtSearchSort.Text & "','" & txtSearchVariant.Text & "','" & txtSearchShade.Text & "','" & txtSearchSaleOrder.Text & "','N'"
                'End If



                Dim ds As DataSet = New DataSet()
                Dim Da As SqlDataAdapter = New SqlDataAdapter(qry, obj.Connection)


                Da.SelectCommand.CommandTimeout = 0
                Da.Fill(ds)
                'Grd.DataSource = ds
                GrdHeldBales.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
                GrdHeldBales.DataBind()

                GrdPackedForOrder.DataSource = Nothing
                GrdPackedForOrder.DataBind()

            End If
        Catch ex As Exception
            scrpt = "alert('  " + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        End Try
    End Sub
    Protected Sub ChkOrderSelAll_CheckedChanged(sender As Object, e As System.EventArgs)
        'ChkBasicDetail_SelAll
        With GrdPackedForOrder
            For i = 0 To GrdPackedForOrder.Rows.Count - 1
                CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked = CType(.HeaderRow.FindControl("ChkOrderSelAll"), CheckBox).Checked
            Next
        End With

    End Sub

    Protected Sub GrdPackedForOrder_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdPackedForOrder.RowDataBound
        If RdoStotckToSearch.SelectedIndex = 0 Then
            If GrdPackedForOrder.Rows.Count > 1 Then
                If e.Row.RowType = DataControlRowType.DataRow And Right(Trim(e.Row.Cells(1).Text), 5) = "Total" Then
                    e.Row.CssClass = "GridRowGreen"
                End If
            End If
        End If
    End Sub

    Protected Sub GrdPackedForOrder_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdPackedForOrder.SelectedIndexChanged

    End Sub

    Protected Sub ddlStatus_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlStatus.SelectedIndexChanged
        Action()
    End Sub
    Private Sub Action()
        If ddlStatus.SelectedItem.Text.ToUpper() = "HOLD" Then
            lblHold.Visible = True
            txtHoldUpto.Enabled = True
            txtHoldUpto.Visible = True
            txtReasonForHolding.Visible = True
            lblResonForHolding.Visible = True
            MEV1.Enabled = True
            MEE1.Enabled = True

        Else
            lblHold.Visible = False
            txtHoldUpto.Visible = False
            txtHoldUpto.Enabled = False
            txtReasonForHolding.Visible = False
            lblResonForHolding.Visible = False
            MEV1.Enabled = False
            MEE1.Enabled = False

        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Action()
            RdoStotckToSearch.SelectedIndex = 0
            RdoStotckToSearch_SelectedIndexChanged(sender, e)
            DeleteTempRecords()
            'ddlStatus.
            If Session("empcode").ToString.ToLower = "a-00098" Then
                UpdatePanel33.Visible = True
                cmdSendMail.Visible = True
            End If
        End If
    End Sub

    Protected Sub CmdApply_Click(sender As Object, e As System.EventArgs) Handles CmdApply.Click
        Dim Cn As String = ""
        Cn = "Data Source=Misdev;Initial Catalog=Production;Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 0;"
        con = New SqlConnection(Cn)
        con.Open()
        Tran = con.BeginTransaction
        Dim SanctionID As String = ""
        Try

            qry = "SELECT TOP 1 Num FROM jctdev..JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL"
            SanctionID = objfun.FetchValue(qry, con, Tran)
            qry = " exec jctdev..Jct_Ops_SanctionNote_Insert_HDR_Import '" & Session("Empcode") & "','" & RdoStotckToSearch.SelectedItem.Value & "','" & ddlSubject.SelectedItem.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & SanctionID & "','" & ddlplant.SelectedItem.Text & "','N',''"
            objfun.InsertRecord(qry, Tran, con)

            With GrdHeldBales
                Dim i As Int16
                For i = 0 To .Rows.Count - 1
                    Dim ChkSelection As Boolean = CType(.Rows(i).FindControl("ChkOrderItems0"), CheckBox).Checked
                    If ChkSelection = True And .Rows(i).Cells(4).Text <> "" Then
                        Dim Mtrs As Integer
                        Mtrs = 0
                        Mtrs = .Rows(i).Cells(6).Text
                        qry = "exec Jct_Ops_Devlopment_Change_Status '" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Session("EmpCode") & "','" & ddlStatus.SelectedItem.Text.Substring(0, 1).ToString & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "','" & txtHoldUpto.Text & "','" & txtReasonForHolding.Text & "','" & SanctionID & "'"
                        cmd = New SqlCommand(qry, con, Tran)
                        cmd.ExecuteNonQuery()

                    End If
                Next
            End With


            qry = "UPDATE  jctdev..JCT_OPS_SanctionNote_Codes SET IsConsumed = 'Y',DateConsumed = GETDATE() WHERE   Num = '" & SanctionID & "'  "
            objfun.UpdateRecord(qry, Tran, con)


            Dim EmpLevelCount As Int16 = 0
            EmpLevelCount = ChkDynamicListing.Items.Count



            For i = 0 To ChkDynamicListing.Items.Count - 1
                qry = "Insert into jctdev..JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL) values('" & SanctionID & "','" & Session("empcode") & "','" & RdoStotckToSearch.SelectedItem.Value & "','" & ChkDynamicListing.Items(i).Value & "'," & i + 1 & ")"
                cmd = New SqlCommand(qry, con)
                cmd.Transaction = Tran
                cmd.ExecuteNonQuery()
            Next

            qry = "exec jctdev..Jct_Ops_SanctionNote_InsertDynamic_User_ReasonWise '" & SanctionID & "','" & Session("empcode") & "','" & RdoStotckToSearch.SelectedItem.Value & "'," & EmpLevelCount & ",'" & ddlplant.SelectedItem.Text & "',111"
            objfun.InsertRecord(qry, Tran, con)

            For i = 0 To chkNotify.Items.Count - 1
                qry = "INSERT INTO jctdev..Jct_Ops_SanctionNote_Notify( Usercode ,SanctionID ,NotifyUser , CreatedDate) values('" & Session("Empcode") & "','" & SanctionID & "','" & chkNotify.Items(i).Value & "',getdate())"
                cmd = New SqlCommand(qry, con)
                cmd.Transaction = Tran
                cmd.ExecuteNonQuery()
            Next
            CmdApply.Enabled = False
            Tran.Commit()

            Try
                Sendmail(SanctionID, txtReasonForHolding.Text, txtHoldUpto.Text, txtRemarks.Text)
            Catch ex As Exception

            End Try

            txtHoldUpto.Text = ""
            txtReasonForHolding.Text = ""
            txtRemarks.Text = ""
            scrpt = "alert('Record(s) Saved Sucessfully with ID  " + SanctionID + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            'Return

        Catch ex As Exception
            Tran.Rollback()
            'objfun.Alert("Unable to Complete the transaction..Some records might not be saved !!")
            'scrpt = "alert('Unable to Continue..." + ex.Message.ToString + "');"
            scrpt = "alert('Unable to Save ...');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            'Return
        Finally
            con.Close()
        End Try
    End Sub

    Protected Sub ChkOrderSelAll0_CheckedChanged(sender As Object, e As System.EventArgs)
        'ChkBasicDetail_SelAll
        With GrdHeldBales
            For i = 0 To GrdHeldBales.Rows.Count - 1
                CType(.Rows(i).FindControl("ChkOrderItems0"), CheckBox).Checked = CType(.HeaderRow.FindControl("ChkOrderSelAll0"), CheckBox).Checked
            Next
        End With

    End Sub
    Private Sub Status(Flag As Char)
        If Flag = "f" Then
            ddlStatus.Items.Clear()
            ddlStatus.Items.Add("Release")

        ElseIf Flag = "H" Then
            ddlStatus.Items.Clear()
            ddlStatus.Items.Add("Hold")
        ElseIf Flag = "H" Then
            ddlStatus.Items.Clear()
            ddlStatus.Items.Add("Release")
        End If
    End Sub

    Protected Sub RdoStotckToSearch_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RdoStotckToSearch.SelectedIndexChanged
        GrdPackedForOrder.DataSource = Nothing
        GrdPackedForOrder.DataBind()
        ClearSanctionNoteFields()
        qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy a ,Jct_Ops_SanctioNote_Area_Master b ,dbo.JCT_EmpMast_Base C WHERE   a.AreaCode = b.AreaCode AND a.STATUS = 'A' AND a.STATUS = b.STATUS AND c.empcode = a.empcode AND a.AreaCode = '1047' AND a.plant = '" & ddlplant.SelectedItem.Text & "' AND ReasonCode='111' and a.eff_to is null ORDER BY AuthLevel"
        objfun.FillGrid(qry, GrdEmployee)
        'If RdoStotckToSearch.SelectedIndex = 0 Then
        If RdoStotckToSearch.SelectedItem.Text = "Fresh Stock" Then
            Status("")
            lblOffered.Visible = True
            ddlOfferedToCust.Visible = True
            reqdOfferedToCust.Visible = True
            Panel2.Visible = False
            'qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy a ,Jct_Ops_SanctioNote_Area_Master b ,dbo.JCT_EmpMast_Base C WHERE   a.AreaCode = b.AreaCode AND a.STATUS = 'A' AND a.STATUS = b.STATUS AND c.empcode = a.empcode AND a.AreaCode = '1047' AND a.plant = '" & ddlplant.SelectedItem.Text & "' AND ReasonCode='111' ORDER BY AuthLevel"
            'objfun.FillGrid(qry, GrdEmployee)
            CmdTransfer.Visible = True
            CmdClear.Visible = True
            RequiredFieldValidator1.ValidationGroup = "GrpApply"
            'Panel4.Visible = True
        Else '--If RdoStotckToSearch.SelectedIndex = 1 Then
            lblOffered.Visible = False
            ddlOfferedToCust.Visible = False
            reqdOfferedToCust.Visible = False
            RequiredFieldValidator1.ValidationGroup = "GrpRelease"
            If RdoStotckToSearch.SelectedItem.Text = "Transfered Stock" Then
                Status("H")

                txtReasonForHolding.Visible = True
                lblResonForHolding.Visible = True
                lblHold.Visible = True
                txtHoldUpto.Enabled = True
                MEV1.Enabled = True
                MEE1.Enabled = True

                MEV1.Visible = True
                txtHoldUpto.Visible = True
            Else
                Status("f")
                txtReasonForHolding.Visible = False
                lblResonForHolding.Visible = False
                lblHold.Visible = False
                txtHoldUpto.Visible = False
            End If
            Panel2.Visible = True
            CmdTransfer.Visible = False
            CmdClear.Visible = False
            '  Panel4.Visible = False
            'pnl()
            'Panel4.Visible = False

        End If
        'scrpt = "alert('Unable to Save ...'" + RdoStotckToSearch.SelectedItem.Value + "' );"
        'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
    End Sub

    Protected Sub ddlplant_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlplant.SelectedIndexChanged
        qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy a ,Jct_Ops_SanctioNote_Area_Master b ,dbo.JCT_EmpMast_Base C WHERE   a.AreaCode = b.AreaCode AND a.STATUS = 'A' AND a.STATUS = b.STATUS AND c.empcode = a.empcode AND a.AreaCode = '1047' AND a.plant = '" & ddlplant.SelectedItem.Text & "' AND ReasonCode='111' ORDER BY AuthLevel"
        objfun.FillGrid(qry, GrdEmployee)
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

    Protected Sub imgRemoveItem_Click(sender As Object, e As System.EventArgs) Handles imgRemoveItem.Click

        Dim i As Int16 = 0
        Dim CountItems As Int16 = ChkDynamicListing.Items.Count
        For i = 0 To CountItems - 1
            If CountItems > 0 Then
                If ChkDynamicListing.Items(i).Selected = True Then
                    ChkDynamicListing.Items.RemoveAt(i)
                    CountItems -= 1
                    Exit For
                End If
            End If
            'MsgBox("" & ChkUploadedItems.Items(i).ch)
        Next

        CountItems = 0
        CountItems = chkNotify.Items.Count
        For i = 0 To CountItems - 1
            If CountItems > 0 Then
                If chkNotify.Items(i).Selected = True Then
                    chkNotify.Items.RemoveAt(i)
                    CountItems -= 1
                    Exit For
                End If
            End If
            'MsgBox("" & ChkUploadedItems.Items(i).ch)
        Next
    End Sub

    Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        qry = "SELECT distinct empcode,empname+'~'+b.DEPTNAME FROM JCT_EmpMast_Base a,DEPTMAST b WHERE empname LIKE '%" & txtEmployee.Text & "%' AND Active='y' AND a.deptcode=b.DEPTCODE ORDER BY empcode,empname+'~'+b.DEPTNAME"
        objfun.FillList(ChkEmpList, qry)
    End Sub

    Private Sub Sendmail(SanctionNote As String)
        Dim Sql As String = ""
        Sql = "Select empname from jct_empmast_base where empcode='" + Session("EmpCode") + "'"
        Dim EmpName As String = objfun.FetchValue(Sql)
        Dim from As String = "ODS@jctltd.com"
        Dim [to] As String = ""
        Dim [bcc] As String = ""
        Dim subject As String = ""
        Dim [cc] As String
        Dim sb As New StringBuilder()
        Dim PendingAt As String = ""
        qry = "SELECT a.EmpCode ,Name,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE UserLevel=1  AND STATUS IS null and AreaCode='" & RdoStotckToSearch.SelectedItem.Value & "' and a.EmpCode=b.empcode and id='" & SanctionNote & "' "
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            [to] = dr.Item(2)
            PendingAt = dr.Item(1)
        End If
        dr.Close()
        obj.ConClose()

        qry = "SELECT a.EmpCode ,Name,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE UserLevel=1  AND STATUS IS null and AreaCode='" & RdoStotckToSearch.SelectedItem.Value & "' and a.EmpCode=b.empcode and id='" & SanctionNote & "' "
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            [to] = dr.Item(2)
            PendingAt = dr.Item(1)
        End If
        dr.Close()
        obj.ConClose()

        Dim Genratedby_Email As String = ""

        qry = "SELECT isnull(E_MailID,''),name FROM dbo.MISTEL WHERE empcode='" & Session("EmpCode") & "' "
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows = True Then
            Genratedby_Email = dr.Item(0)
        End If
        dr.Close()
        obj.ConClose()

        ' [to] = "ashish@jctltd.com"

        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<style type=""text/css"">")
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head>")


        sb.AppendLine("<h3>Hi,</h3>")
        sb.AppendLine("<h3>Stock Transfer Request has been initiated (ODS Stock Transfer) by " + EmpName + ".</h3> and is pending at <b>" & PendingAt & "'s</b> end for authorization <br/><br/>")
        sb.AppendLine("RequestID for your request is : <b>" + SanctionNote + "</b> <br/><br/>")
        sb.AppendLine("This request is generated with   <b>"" " + ddlSubject.SelectedItem.Text + " ""</b> as subject  <br/><br/>")
        sb.AppendLine("And following description :- <br/></h> <b>" + txtDescription.Text + "</b> <br/></h>")
        sb.AppendLine("For Plant : <b> " + ddlplant.Text + "</b> <br/><br/>")
        sb.AppendLine("Details are Shown below : <br/><br/>")
        sb.AppendLine("<table class=gridtable>")
        Dim Q As String = ""
        If RdoStotckToSearch.SelectedItem.Text = "Fresh Stock" Then
            sb.AppendLine("<tr><th> PackedFor</th> <th> SortNo</th> <th> BaleNo</th> <th> Grade</th><th>Shade</th> <th> Meters</th>  </tr>")
            Q = ""
            With GrdTempValuesBaleDEtail
                Dim i As Int16
                Dim j As Int16

                For i = 0 To .Rows.Count - 1
                    'Dim ChkSelection As Boolean = CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked
                    'If ChkSelection = True Then

                    Q += "<tr>"

                    For j = 1 To 6

                        Q += "<td><b>" & .Rows(i).Cells(j).Text & "</b></td>"


                        'Q += "<td>" & dr.Item(1).ToString & "</td>"
                        'Q += "<td>" & dr.Item(2).ToString & "</td>"
                        'Q += "<td>" & dr.Item(3).ToString & "</td>"
                        'Q += "<td>" & dr.Item(4).ToString & "</td></tr>"
                    Next

                    Q += "</tr>"

                    'End If
                Next
            End With
        Else

            With GrdHeldBales
                sb.AppendLine("<tr><th> PackedFor</th><th>Shade</th> <th> SortNo</th> <th> BaleNo</th> <th> Grade</th> <th> Meters</th>  </tr>")
                Q = ""
                Dim i As Int16
                Dim j As Int16

                For i = 0 To .Rows.Count - 1
                    Dim ChkSelection As Boolean = CType(.Rows(i).FindControl("ChkOrderItems0"), CheckBox).Checked
                    If ChkSelection = True Then

                        Q += "<tr>"

                        For j = 1 To 6

                            Q += "<td><b>" & .Rows(i).Cells(j).Text & "</b></td>"


                            'Q += "<td>" & dr.Item(1).ToString & "</td>"
                            'Q += "<td>" & dr.Item(2).ToString & "</td>"
                            'Q += "<td>" & dr.Item(3).ToString & "</td>"
                            'Q += "<td>" & dr.Item(4).ToString & "</td></tr>"
                        Next

                        Q += "</tr>"

                    End If
                Next
            End With


        End If
        sb.AppendLine("" & Q)
        sb.AppendLine("</table>")
        sb.AppendLine("<br />")
        sb.AppendLine("<b>Offered to Customer :</b> " & ddlOfferedToCust.SelectedItem.Text)



        sb.AppendLine("<br/><a href='http://misdev/fusionapps/OPS/Sotck_Movement_Authorization.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>")

        sb.AppendLine("<i>This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br /></i>")
        sb.AppendLine("</html>")


        'sb.Append([to].ToString())

        bcc = "ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"
        cc = Genratedby_Email
        Dim mail As New MailMessage()
        mail.From = New MailAddress(from)

' If RdoStotckToSearch.SelectedItem.Text = "Fresh Stock" Then
 '           [to] = [to] & ",kaushal@jctltd.com"
  '      End If


[to] = [to] & ",kaushal@jctltd.com"

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
        subject = " Stock Transfer Request Has been Generated with " & SanctionNote
        mail.Subject = subject
        mail.Body = sb.ToString 'Body & Body1 & Body2 & Body3
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2k7")


        SmtpMail.Send(mail)
    End Sub

    Protected Sub CmdClear_Click(sender As Object, e As System.EventArgs) Handles CmdClear.Click
        lblSanctionID.Text = ""


        CmdTransfer.Enabled = True
        GrdPackedForOrder.DataSource = Nothing
        GrdPackedForOrder.DataBind()

        GrdTempValuesBaleDEtail.DataSource = Nothing
        GrdTempValuesBaleDEtail.DataBind()

        ddlSubject.SelectedIndex = 0
        txtDescription.Text = ""
    End Sub


    Private Sub Sendmail(SanctionNote As String, HoldReason As String, HoldUptoDate As String, HoldRemarks As String)
        Dim Sql As String = ""
        Sql = "Select empname from jct_empmast_base where empcode='" + Session("EmpCode") + "'"
        Dim EmpName As String = objfun.FetchValue(Sql)
        Dim from As String = "ODS@jctltd.com"
        Dim [to] As String = "" '"ashish@jctltd.com"
        Dim [bcc] As String = ""
        Dim subject As String = ""
        Dim [cc] As String
        Dim sb As New StringBuilder()
        Dim PendingAt As String = ""
        qry = "SELECT a.EmpCode ,Name,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE UserLevel=1  AND STATUS IS null and AreaCode='1047' and a.EmpCode=b.empcode and id='" & SanctionNote & "' "
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            [to] = dr.Item(2)
            PendingAt = dr.Item(1)
        End If
        dr.Close()
        obj.ConClose()

        qry = "SELECT a.EmpCode ,Name,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE UserLevel=1  AND STATUS IS null and AreaCode='1047' and a.EmpCode=b.empcode and id='" & SanctionNote & "' "
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            [to] = dr.Item(2)
            PendingAt = dr.Item(1)
        End If
        dr.Close()
        obj.ConClose()

        Dim Genratedby_Email As String = ""

        qry = "SELECT isnull(E_MailID,''),name FROM dbo.MISTEL WHERE empcode='" & Session("EmpCode") & "' "
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows = True Then
            Genratedby_Email = dr.Item(0)
        End If
        dr.Close()
        obj.ConClose()



        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<style type=""text/css"">")
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head>")


        sb.AppendLine("<h3>Hi,</h3>")
        Dim RequestType As String = ""
        If RdoStotckToSearch.SelectedItem.Text = "Held Stock" Then
            RequestType = "Release Stock "
        Else
            RequestType = "Hold Stock(s) "
        End If


        sb.AppendLine("<h3> " & RequestType & " Request has been initiated (ODS Stock Transfer) by " + EmpName + ".</h3> and is pending at <b>" & PendingAt & "'s</b> end for authorization <br/><br/>")
        sb.AppendLine(" Your RequestID is : <b>" + SanctionNote + "</b> <br/><br/>")
        sb.AppendLine("This request is generated with   <b>"" " + ddlSubject.SelectedItem.Text + " ""</b> as subject  <br/><br/>")
        sb.AppendLine("And following description :- <br/> <b>" + txtDescription.Text + "</b> <br/>")
        sb.AppendLine("For Plant : <b> " + ddlplant.Text + "</b> <br/><br/>")
        sb.AppendLine("Details are Shown below : <br/><br/>")
        sb.AppendLine("<table class=gridtable>")
        sb.AppendLine("<tr><th> PackedFor</th><th>Shade</th> <th> SortNo</th> <th> BaleNo</th> <th> Grade</th> <th> Meters</th>   <th> CustomerCode</th><th>CustomerName</th> </tr>")
        Dim Q As String = ""
        With GrdPackedForOrder
            Dim i As Int16
            Dim j As Int16

            For i = 0 To .Rows.Count - 1
                Dim ChkSelection As Boolean = CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked
                If ChkSelection = True Then

                    Q += "<tr>"

                    For j = 1 To 8

                        Q += "<td><b>" & .Rows(i).Cells(j).Text & "</b></td>"


                        'Q += "<td>" & dr.Item(1).ToString & "</td>"
                        'Q += "<td>" & dr.Item(2).ToString & "</td>"
                        'Q += "<td>" & dr.Item(3).ToString & "</td>"
                        'Q += "<td>" & dr.Item(4).ToString & "</td></tr>"
                    Next

                    Q += "</tr>"

                    'Dim Mtrs As Integer
                    'Mtrs = 0
                    'Mtrs = .Rows(i).Cells(6).Text

                    '' qry = "exec Jct_Ops_Devlopment_Change_Status '" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "','" & Session("EmpCode") & "','" & ddlStatus.SelectedItem.Text.Substring(0, 1).ToString & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "','" & txtHoldUpto.Text & "','" & txtReasonForHolding.Text & "'"
                    ''objfun.InsertRecord(qry)
                    'con.Open()
                    'cmd = New SqlCommand(qry, con)
                    'cmd.ExecuteNonQuery()
                    'con.Close()
                End If
            Next
        End With
        sb.AppendLine("" & Q)
        sb.AppendLine("</table>")
        sb.AppendLine("<br />")
        sb.AppendLine("<br/><a href='http://misdev/fusionapps/OPS/Sotck_Movement_Authorization.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>")

        sb.AppendLine("<i>This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br /></i>")
        sb.AppendLine("</html>")


        bcc = "ashish@jctltd.com,rbaksshi@jctltd.com"
        cc = Genratedby_Email
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

        mail.Subject = subject
        mail.Body = sb.ToString 'Body & Body1 & Body2 & Body3
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2k7")


        SmtpMail.Send(mail)
    End Sub


    Protected Sub CmdHeldClear_Click(sender As Object, e As System.EventArgs) Handles CmdHeldClear.Click
        lblSanctionID.Text = ""
        CmdApply.Enabled = True
        txtHoldUpto.Text = ""
        txtReasonForHolding.Text = ""
        txtRemarks.Text = ""
    End Sub
    Private Sub ClearSanctionNoteFields()
        'ddlSubject.SelectedItem.Text
        ddlSubject.SelectedIndex = 0
        txtDescription.Text = ""
        txtEmployee.Text = ""
        ChkDynamicListing.Items.Clear()
        chkNotify.Items.Clear()
        GrdEmployee.DataSource = Nothing
        GrdEmployee.DataBind()
        ChkEmpList.Items.Clear()
        CmdApply.Enabled = True
        txtHoldUpto.Text = ""
        txtReasonForHolding.Text = ""
        txtRemarks.Text = ""
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim i As Int16
        Try
            With GrdTempValuesBaleDEtail
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("ChkDelete0"), CheckBox).Checked = True Then
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
            objfun.FillGrid(qry, GrdTempValuesBaleDEtail)
            'R stand for Read Data
            'qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'C'"
            'objfun.FillGrid(qry, GrdTempValuesBaleDEtail)
            'qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'S'"
            'objfun.FillGrid(qry, GrdSummary)
        End Try
    End Sub

    Protected Sub imgAddRow_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgAddRow.Click

        Dim i As Int16
        Try
            With GrdPackedForOrder
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked = True Then
                        qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(5).Text) & "'," & Trim(.Rows(i).Cells(6).Text) & ",'I'"
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End With


        Catch

        Finally
            qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'R'"
            objfun.FillGrid(qry, GrdTempValuesBaleDEtail)
            'R stand for Read Data
            
            'qry = "Exec Jct_Ops_Excess_Stock_Sell_Intermiediate '" & Session("empcode") & "','','','','','',0,'S'"
            'objfun.FillGrid(qry, GrdSummary)
            'If LCase(ddlRequestType.SelectedItem.Text) = "excess stock~1041" Then
            '    qry = "Exec Jct_Ops_Get_Excess_Stock_Items '" & Session("empcode") & "'"
            '    objFun.FillGrid(qry, GrdCostDetail)
            'End If
        End Try
    End Sub
    Private Sub DeleteTempRecords()
        qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where Usercode='" & Session("Empcode") & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        cmd.ExecuteNonQuery()

        'ClearAllGrid()
        If IsPostBack Then
            Dim scrpt As String = ""
            scrpt = "alert('All Data Cleared ...');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        End If
    End Sub
    Private Sub ClearAllGrid()
        GrdPackedForOrder.DataSource = Nothing
        GrdPackedForOrder.DataBind()

       

        GrdTempValuesBaleDEtail.DataSource = Nothing
        GrdTempValuesBaleDEtail.DataBind()
    End Sub

    Protected Sub imgClear_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgClear.Click
        DeleteTempRecords()
        ClearAllGrid()
    End Sub

    Protected Sub cmdGetRequestDEtail_Click(sender As Object, e As System.EventArgs) Handles cmdGetRequestDEtail.Click
        qry = "Exec Jct_Ops_Devlopment_Fetch_ODS_Bales '" & txtSearchSaleOrder.Text & "','" & txtSearchSort.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "','','V-04247','" & txtRequest.Text & "'"
        objfun.FillGrid(qry, GrdTempValuesBaleDEtail)
        qry = "SELECT SUBJECT,DESCRIPTION,CASE b.OfferedToCust WHEN 'N' THEN 'No' ELSE 'Yes' END OfferedToCust,a.Plant FROM Jct_Ops_SanctionNote_HDR a  INNER join   Production..Jct_Ops_Excess_Stock_Status_Log b   ON a.SanctionNoteID=b.transID and SanctionNoteID='" & txtRequest.Text & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            'ddlplant.Items.FindByValue
            ddlSubject.SelectedIndex = ddlSubject.Items.IndexOf(ddlSubject.Items.FindByValue(dr.Item(0).ToString))
            txtDescription.Text = dr.Item(1).ToString()
            ddlOfferedToCust.SelectedIndex = ddlOfferedToCust.Items.IndexOf(ddlOfferedToCust.Items.FindByValue(dr.Item(2).ToString))
            ddlplant.SelectedIndex = ddlplant.Items.IndexOf(ddlplant.Items.FindByValue(dr.Item(3).ToString))
            '  txts
        End If
    End Sub

    Protected Sub cmdSendMail_Click(sender As Object, e As System.EventArgs) Handles cmdSendMail.Click
        Session("EmpCode") = "V-04247"
        Sendmail(txtRequest.Text)
    End Sub
End Class
