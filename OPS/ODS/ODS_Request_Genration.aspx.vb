Imports System.Data
Imports System.Data.SqlClient


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


    Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        qry = "SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        'qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1'"
        objfun.FillGrid(qry, GridView1)
        qry = "SELECT line_no AS [LineNo],attb_discrete+' :: '+CONVERT(VARCHAR,line_no) FROM miserp.som.dbo.t_order_line_nos a(nolock),miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' order by a.order_srl_no "
        'qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1'"
        objfun.FillList(chkItemList, qry)
    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  txtOrderNo.Attributes.Add("onKeyPress", "doClick('" + BtnFetch.ClientID + "',event)")
            txtOrderNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + cmdSearch.UniqueID + "').click();return false;}} else {return true}; ")
            qry = "Delete from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "'"
            objfun.DeleteRecord(qry)
            qry = "SELECT ProcUsed+convert(varchar,isnull(ReqTypeCode,0)),ReqAreaName FROM Jct_Ops_Request_Area_Master order by ReqTypeCode"
            objfun.FillList(ddlRequestType, qry)
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
        qry = "exec " & Proc & " 'JCT00LTD', 'PHG', 1,  '" & txtSort.Text & "','" & txtVariant.Text & "','" & txtShade.Text & "','" & txtSaleOrder.Text & "'"
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
            qry = "exec Jct_Ops_ODS_Request_GenrateRequestID"
            SanctionID = objfun.FetchValue(qry, obj.Connection, Tran)

            Body1 = Body1 & " <hr> Description :- " & txtDescription.Text & "<hr> "
            qry = " exec Jct_Ops_ODS_Insert_HDR '" & Session("Empcode") & "','1028','" & txtSubject.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & SanctionID & "','" & ddlPlant.SelectedItem.Text & "','" & ddlRequestType.SelectedItem.Text & "'"
            objfun.InsertRecord(qry, Tran, obj.Connection)
            With GrdTempValues
                OrderVar = ""
                qry = ""
                'For i = 0 To .Rows.Count - 1
                '    PackedIn = Trim(.Rows(i).Cells(1).Text)
                '    'PackedInLine = Trim(.Rows(i).Cells(2).Text)
                '    ItemNo = Trim(.Rows(i).Cells(2).Text)
                '    Variant1 = Trim(.Rows(i).Cells(4).Text)
                '    BaleNo = Trim(.Rows(i).Cells(3).Text)
                '    Mtrs = Trim(.Rows(i).Cells(5).Text)



                '    qry = "Exec Jct_Ops_Transfer_Insert_Detail '" & SanctionID & "','" & Session("Empcode") & "','" & ItemNo & "','" & Variant1 & "','" & BaleNo & "'," & Mtrs & ",'" & Request.ServerVariables("REMOTE_ADDR") & "','" & PackedIn & "'"
                '    objfun.InsertRecord(qry, Tran, obj.Connection)


                'Next

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
            lblID.Text = SanctionID
            CmdApply.Enabled = False

        Catch ex As Exception
            FileName = "Unable to Complete Transaction " & ex.InnerException.Message
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

    Protected Sub CmdAddItem_Click(sender As Object, e As System.EventArgs) Handles CmdAddItem.Click
        Dim i As Int16
        Try
            With GrdBasicDetail
                For i = 0 To .Rows.Count - 1
                    If CType(.Rows(i).FindControl("chkBox"), CheckBox).Checked = True Then
                        qry = "Insert into [Jct_Ops_Transfer_Request_Intermediate] values('" & Session("Empcode") & "','" & Trim(.Rows(i).Cells(4).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(3).Text) & "','" & Trim(.Rows(i).Cells(2).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "')"
                        'objfun.InsertRecord(qry)
                        cmd = New SqlCommand(qry, obj.Connection)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End With
        Catch

        Finally
            qry = "SELECT SourceOrder as PackedIn ,Item_no ,Bale_No ,Varaint ,Meters  from Jct_Ops_Transfer_Request_Intermediate where [Usercode]='" & Session("Empcode") & "'"
            objfun.FillGrid(qry, GrdTempValues)
        End Try
    End Sub

    Protected Sub cmdDeleteRows_Click(sender As Object, e As System.EventArgs) Handles cmdDeleteRows.Click
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

    Protected Sub ddlRequestType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlRequestType.SelectedIndexChanged
        Dim ReqCode As Int16 = 0

        GrdBasicDetail.DataSource = Nothing
        GrdBasicDetail.DataBind()

        qry = "SELECT  ReqTypeCode FROM Jct_Ops_Request_Area_Master WHERE ReqAreaName='" & ddlRequestType.SelectedItem.Text & "'"
        ReqCode = objfun.FetchValue(qry)
        qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_Request_Area_Hierarchy a ,dbo.JCT_EmpMast_Base C WHERE  a.reqtypeCode=" & ReqCode & " AND c.empcode = a.empcode AND a.plant = '" & ddlPlant.SelectedItem.Text & "'  ORDER BY AuthLevel"
        objfun.FillGrid(qry, GrdEmployee)

    End Sub
End Class
