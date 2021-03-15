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

Partial Class OPS_Order_Scheduling
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim Qry As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand
    Dim Con As SqlConnection = New SqlConnection
    Dim ObjSendMail As SendMail = New SendMail

    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
        Qry = "Delete from Jct_Ops_Temp_Insert where usercode='" & Session("Empcode") & "' and hostip='" & Request.ServerVariables("REMOTE_ADDR") & "'"
        Cmd = New SqlCommand(Qry, Obj.Connection)
        Cmd.ExecuteNonQuery()
        BindGrids()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)
           
            Qry = "Select '' as Location,'' union  SELECT DISTINCT LOCATION,Location FROM JCT_OPS_MONTHLY_PLANNING order by  location"
            ObjFun.FillList(ddlPlant, Qry)

            Qry = "Delete from Jct_Ops_Temp_Insert " 'usercode='" & Session("Empcode") & "' and hostip='" & Request.ServerVariables("REMOTE_ADDR") & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Cmd.ExecuteNonQuery()

            txtEff_From.Text = "08/01/2012"
            txtEff_To.Text = "08/31/2012"
        End If
    End Sub

    Protected Sub CmdXl_Click(sender As Object, e As System.EventArgs) Handles CmdXl.Click
        GridViewExportUtil.Export("Plan" & ".xls", GridView1)
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "OpenPopUp" Then
            Qry = "jct_ops_get_Issued_Orders_Final"
            Dim Gv As GridViewRow = CType(e.CommandSource, ImageButton).NamingContainer
            Dim CurRowIndex As Int16 = Gv.RowIndex
            Dim LineItemNo As Int16 = 999
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@team_code", SqlDbType.VarChar, 20).Value = ""
            Cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 20).Value = Trim(GridView1.Rows(CurRowIndex).Cells(4).Text)
            Cmd.Parameters.Add("@custcode", SqlDbType.VarChar, 20).Value = ""
            Cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 20).Value = ""
            Cmd.Parameters.Add("@yearmonth", SqlDbType.VarChar, 20).Value = ""
            Cmd.Parameters.Add("@PlantType", SqlDbType.VarChar, 20).Value = ""
            Cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtEff_From.Text
            Cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtEff_To.Text
            Cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = "U"
            LineItemNo = Val(Trim(GridView1.Rows(CurRowIndex).Cells(5).Text))
            Cmd.Parameters.Add("@line", SqlDbType.SmallInt).Value = LineItemNo 'Val(Trim(GridView1.Rows(CurRowIndex).Cells(5).Text))

            Dim Dt As DataTable = New DataTable
            'Dr = Cmd.ExecuteReader
            Dim Qry1 As String = Cmd.CommandText
            'For Each P As SqlParameter In Cmd.Parameters
            '    'Qry1 = Qry1 & P.Value
            '    Qry1 = Qry & P.Value & ","
            'Next


            'ViewState("Row") = Gv.RowIndex

            Dim Da As SqlDataAdapter = New SqlDataAdapter
            Da.SelectCommand = Cmd
            Cmd.CommandTimeout = 100000000
            Da.Fill(Dt)


            If ViewState("data") Is Nothing Then
                ViewState("data") = Dt
            Else
                ViewState.Add("data", Dt)
            End If
            grdSplit.DataSource = ViewState("data")
            grdSplit.DataBind()



            'MsgBox("" & Cmd.CommandText)
            'Dt = ObjFun.FetchRecords(Cmd.CommandText)
            'GridViewRow gv = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer)

            'MsgBox("" & GridView1.Rows(Gv.RowIndex).Cells(4).Text & Gv.RowIndex)
            'Qry = "Exec jct_ops_get_weaving_monthly_plan_Modified '','','" & CustCode & "','" & SalePerson & "','','" & PlantType & "','" & txtEff_From.Text & "','" & txtEff_To.Text & "','U' "
            ModalPopupExtender1.Show()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IssuedMtr As Int64, BalDyngQty As Int64, BalFinishQty As Int64
            IssuedMtr = Val(Trim(e.Row.Cells(12).Text))
            BalDyngQty = Val(Trim(e.Row.Cells(13).Text))

            If BalDyngQty > 0 And IssuedMtr <> BalDyngQty Then
                CType(e.Row.FindControl("txtDyeingMtrs"), TextBox).Text = BalDyngQty
                e.Row.Cells(13).CssClass = "GridRowGreen"
                ' e.Row.CssClass = "GridRowGreen"
            Else
                CType(e.Row.FindControl("txtDyeingMtrs"), TextBox).Text = Trim(e.Row.Cells(12).Text)

            End If
            BalFinishQty = Val(Trim(e.Row.Cells(16).Text))

            If BalFinishQty > 0 And IssuedMtr <> BalFinishQty Then
                CType(e.Row.FindControl("txtFinishMtrs"), TextBox).Text = BalFinishQty
                'e.Row.Cells(15).ForeColor = Drawing.Color.YellowGreen
                e.Row.Cells(16).CssClass = "GridRowGreen"
            Else

                CType(e.Row.FindControl("txtFinishMtrs"), TextBox).Text = Trim(e.Row.Cells(12).Text)
            End If


        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub CmdApply_Click(sender As Object, e As System.EventArgs) Handles CmdApply.Click
        Dim OrderNo As String, Item As String, Shade As String
        Dim OrderDate As String, ReqDyngDate As String, ReqFinishDate As String, FinsRemarks As String
        Dim Line As Int16
        Dim OrderQty As Int64, IssuedMtr As Int64, DyngQty As Int64, FinsihQty As Int64, BalDyngQty As Int64, BalFinishQty As Int64
        Dim Remarks As String, HostIP As String
        Dim i As Int16
        Dim ErrorOrderCount As Int32
        Dim OrderCount As Int32
        OrderCount = 0
        Dim Tran As SqlTransaction
        Dim ChkBox As CheckBox
        With GridView1
            For i = 0 To GridView1.Rows.Count - 1
                ChkBox = CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox)
                If ChkBox.Checked = True Then
                    Try
                        Tran = Obj.Connection.BeginTransaction
                        HostIP = Request.ServerVariables("REMOTE_ADDR")
                        'Con = Obj.Connection
                        'Tran = Con.BeginTransaction
                        OrderNo = Trim(.Rows(i).Cells(4).Text)
                        Item = Trim(.Rows(i).Cells(6).Text)
                        Shade = Trim(.Rows(i).Cells(7).Text)
                        OrderDate = Trim(.Rows(i).Cells(8).Text)
                        OrderQty = Trim(.Rows(i).Cells(10).Text)
                        IssuedMtr = Trim(.Rows(i).Cells(12).Text)
                        DyngQty = Trim(CType(.Rows(i).FindControl("txtDyeingMtrs"), TextBox).Text)
                        FinsihQty = Trim(CType(.Rows(i).FindControl("txtFinishMtrs"), TextBox).Text)
                        Remarks = Trim(CType(.Rows(i).FindControl("txtRemarks"), TextBox).Text)
                        Line = Trim(.Rows(i).Cells(5).Text)
                        ReqDyngDate = Trim(CType(.Rows(i).FindControl("txtReqDyeingDate"), TextBox).Text)

                        ReqFinishDate = Trim(CType(.Rows(i).FindControl("txtReqFinishDate"), TextBox).Text)



                        FinsRemarks = Trim(CType(.Rows(i).FindControl("txtFinsRemarks"), TextBox).Text)

                        '            BalDyngQty = IssuedMtr
                        If Val(Trim(.Rows(i).Cells(13).Text)) = 0 Then
                            BalDyngQty = IssuedMtr - DyngQty
                        Else
                            BalDyngQty = Val(Trim(.Rows(i).Cells(13).Text)) - DyngQty

                        End If

                        If Val(Trim(.Rows(i).Cells(16).Text)) = 0 Then
                            BalFinishQty = IssuedMtr - FinsihQty
                        Else
                            BalFinishQty = Val(Trim(.Rows(i).Cells(16).Text)) - FinsihQty

                        End If
                        'BalFinishQty = Val(Trim(.Rows(i).Cells(15).Text))


                        'Cells(12).Text)
                        Dim Split As Boolean
                        Split = False
                        Qry = "Select 1 from Jct_Ops_Temp_Insert where orderno='" & OrderNo & "' and  lineItem='" & Line & "'"
                        Split = ObjFun.CheckRecordExistInTransaction(Qry)
                        If Split = False Then
                            Qry = "Exec JCT_OPS_Insert_Planned_Orders '" & Session("EmpCode") & "','" & OrderNo & "','" & Item & "','" & Line & "','" & Shade & "'," & OrderQty & "," & IssuedMtr & "," & DyngQty & ",'" & ReqDyngDate & "'," & FinsihQty & ",'" & ReqFinishDate & "'," & BalDyngQty & "," & BalFinishQty & ",'" & Remarks & "','" & HostIP & "','" & FinsRemarks & "' "
                        Else
                            Qry = "Exec Jct_Ops_Convert_Split_Orders_To_Freezed '" & Session("EmpCode") & "','" & OrderNo & "','" & Item & "','" & Line & "','" & Shade & "'," & OrderQty & "," & IssuedMtr & "," & DyngQty & "," & FinsihQty & ",'" & HostIP & "'"
                        End If
                        'Qry = "INSERT INTO Jct_Ops_Planned_Processing_Orders(UserCode,OrderNo,Item,LINEItem,Shade,OrderQty ,IssuedQty ,ReqDyngQty ,ReqDyngDate ,ReqFinishQty ,ReqFinishDate ,PendingDyngQty ,PendingFinishQty,Remarks ,CreatedDate ,STATUS ,HOST_IP) VALUES('" & Session("EmpCode") & "','" & Trim() & "',,'" & Trim(.SelectedRow.Cells(4).Text) & "',0,'" & Trim(.SelectedRow.Cells(5).Text) & "','" & Trim(.SelectedRow.Cells(9).Text) & "','" & Trim(.SelectedRow.Cells(11).Text) & "')"
                        'ObjFun.InsertRecord(Qry, Tran, Con)
                        ObjFun.InsertRecord(Qry, Tran, Obj.Connection)
                        Tran.Commit()
                        Qry = ""


                        OrderCount += 1
                    Catch
                        ErrorOrderCount += 1
                        Tran.Rollback()
                    End Try
                End If
            Next
            If OrderCount > 0 Then
                FMsg.CssClass = "errormsg"
                FMsg.Message = OrderCount & " Orders   Freezed Sucessfully !!."
                FMsg.FadeOutDuration = 5000
                FMsg.Display()
            Else
                FMsg.CssClass = "errormsg"
                FMsg.Message = ErrorOrderCount & "Records  Cannot be Freezed !!"
                FMsg.FadeOutDuration = 5000
                FMsg.Display()
            End If
        End With
    End Sub
    Private Sub BindGrids()
        Dim CustCode As String, SalePerson As String, PlantType As String
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
        If ddlPlant.SelectedItem.Text = "" Then
            PlantType = ""
        Else
            PlantType = Trim(ddlPlant.SelectedItem.Value)
        End If
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        GridView2.DataSource = Nothing
        GridView2.DataBind()
        'Qry = "exec  jct_ops_get_weaving_monthly_plan '','','" & CustCode & "','" & SalePerson & "','" & ddlOrderScheduling.SelectedItem.Value & "','" & PlantType & "' "
        Qry = "Exec jct_ops_get_weaving_monthly_plan_Modified '','','" & CustCode & "','" & SalePerson & "','','" & PlantType & "','" & txtEff_From.Text & "','" & txtEff_To.Text & "','U' "
        'Qry = "Select * from Tbl112"
        ObjFun.FillGrid(Qry, GridView1)

        Qry = "Exec jct_ops_get_weaving_monthly_plan_Modified '','','" & CustCode & "','" & SalePerson & "','','" & PlantType & "','" & txtEff_From.Text & "','" & txtEff_To.Text & "','F' "
        ' Qry = "Select * from Tbl112"
        ObjFun.FillGrid(Qry, GridView2)




    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        Dim OrderNo As String '= Trim(e.(i).Cells(3).Text)
        OrderNo = GridView2.SelectedRow.Cells(1).Text
        Qry = "Exec jct_ops_get_weaving_monthly_plan_Modified '','" & OrderNo & "','','','','','" & txtEff_From.Text & "','" & txtEff_To.Text & "','P' "
        'Qry = "Select * from Tbl112"
        ObjFun.FillGrid(Qry, GridView3)
        CollapsiblePanelExtender3.AutoExpand = True
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim CheckBox1 As CheckBox = DirectCast(sender, CheckBox)
        Dim grow As GridViewRow = TryCast(TryCast(sender, CheckBox).Parent.Parent, GridViewRow)
        Dim Finishvalidator As AjaxControlToolkit.MaskedEditValidator = TryCast(grow.FindControl("MEV1"), AjaxControlToolkit.MaskedEditValidator)
        Dim DyngValidator As AjaxControlToolkit.MaskedEditValidator = TryCast(grow.FindControl("MEV6"), AjaxControlToolkit.MaskedEditValidator)

        Dim OrderNo As String, Item As String ', Shade As String
        Dim Line As Int16
        OrderNo = grow.Cells(4).Text
        Item = grow.Cells(6).Text
        Line = Val(grow.Cells(5).Text)


        Dim Split As Boolean
        Split = False




        ViewState("Row") = grow.RowIndex






        Qry = "Select 1 from Jct_Ops_Temp_Insert where orderno='" & OrderNo & "' and  lineItem='" & Line & "'"
        Split = ObjFun.CheckRecordExistInTransaction(Qry)

        If CheckBox1.Checked = True Then
            '  validator.Enabled = True
            If Split = False Then
                CType(grow.FindControl("ImageButton2"), ImageButton).Visible = True
                'CType(grow.FindControl("ImageButton2"), ImageButton).Visible = True
                Finishvalidator.ValidationGroup = "ValidGrpSaveDetail"
                DyngValidator.ValidationGroup = "ValidGrpSaveDetail"
            Else
                CType(grow.FindControl("ImageButton2"), ImageButton).ImageUrl = "~/Image/SplitIconrED.png"
                CType(grow.FindControl("ImageButton2"), ImageButton).Visible = True
                Finishvalidator.ValidationGroup = "None"
                DyngValidator.ValidationGroup = "None"
            End If

        Else
            Qry = "Delete from Jct_Ops_Temp_Insert where usercode='" & Session("Empcode") & "' and orderno='" & OrderNo & "' and  lineItem='" & Line & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Cmd.ExecuteNonQuery()
            Finishvalidator.ValidationGroup = "None"
            DyngValidator.ValidationGroup = "None"
            CType(grow.FindControl("ImageButton2"), ImageButton).Visible = False
            CType(grow.FindControl("ImageButton2"), ImageButton).ImageUrl = "~/Image/SplitIcon.png"
        End If




        'Dim ddlParameter As DropDownList = DirectCast(sender, DropDownList)
        'Dim gridRow As GridViewRow = TryCast(TryCast(sender, DropDownList).Parent.Parent, GridViewRow)
        'Dim ddlUOM As DropDownList = DirectCast(gridRow.FindControl("ddlUOM"), DropDownList)
        'Sql = "select UOM from jct_cst_parameter_master where status <> 'D' and param_code = '" & Trim(ddlParameter.SelectedItem.Text) & "'"
        'Dim ds As DataSet = ob.FetchDS(Sql)
        'ddlUOM.DataSource = ds.Tables(0)
        'ddlUOM.DataTextField = "UOM"
        'ddlUOM.DataBind()

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        ' ImageButton btndetails = sender as ImageButton
        'GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer
        Dim Btndetails As ImageButton = sender
        Dim GvRow = CType(Btndetails.NamingContainer, GridViewRow)
        ' ModalPopupExtender1.show()
    End Sub

    Protected Sub imgAddRow_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim Scrpt As String
        Try
            Dim ImgAdd As ImageButton = CType(sender, ImageButton)
            Dim Dt As DataTable = New DataTable
            Dt = CType(ViewState("data"), DataTable)
            Dim drow = Dt.NewRow()

            Dim dtr As DataTableReader = New DataTableReader(Dt)
            dtr.Read()

            drow("OrderNo") = dtr("OrderNo")
            drow("item") = dtr("item")
            drow("Shade") = dtr("Shade")
            drow("LineNo") = dtr("LineNo")
            drow("IssuedMeters") = dtr("IssuedMeters")
            drow("PendingDyngQty") = dtr("PendingDyngQty")
            drow("PendingFinishQty") = dtr("PendingFinishQty")
            drow("OrderQty") = dtr("OrderQty")
            drow("OrderReqdate") = dtr("OrderReqdate")
            'drow("Sizing") = dtr("Sizing")
            'drow("LoomAllot") = dtr("LoomAllot")
            'drow("WvgCompletionDate") = dtr("WvgCompletionDate")
            'drow("Reed") = dtr("Reed")
            'drow("Cam") = dtr("Cam")
            Dt.Rows.Add(drow)
            ViewState.Add("data", Dt)

            grdSplit.DataSource = Dt
            grdSplit.DataBind()

        Catch ex As Exception

            Scrpt = "alert('No Row available.')"
            'ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", "bac", True)
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
        End Try
    End Sub

    Protected Sub grdSplit_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdSplit.RowDeleting
        Dim row As Int16 = e.RowIndex
        Dim Dt As DataTable = CType(ViewState("data"), DataTable)
        'DataTable dt= (DataTable)ViewState["data"];
        Dt.Rows.RemoveAt(row)
        grdSplit.DataSource = Dt
        grdSplit.DataBind()
        ViewState("data") = Dt
    End Sub

    Protected Sub lnkSplitOk_Click(sender As Object, e As System.EventArgs) Handles lnkSplitOk.Click
        Dim OrderNo As String, Item As String, Shade As String

        Dim ReqDyngDate As String, ReqFinishDate As String, FinsRemarks As String
        Dim Line As Int16
        'Dim OrderQty As Int64, IssuedMtr As Int64,
        Dim DyngQty As Int64, FinsihQty As Int64 ', BalDyngQty As Int64, BalFinishQty As Int64
        Dim Remarks As String ', HostIP As String
        Dim Scrpt As String
        Dim Tran As SqlTransaction


        Try
            With grdSplit
                For i As Int16 = 0 To .Rows.Count - 1
                    Tran = Obj.Connection.BeginTransaction
                    OrderNo = Trim(.Rows(i).Cells(1).Text)
                    Item = Trim(.Rows(i).Cells(2).Text)
                    Shade = Trim(.Rows(i).Cells(3).Text)
                    Line = Trim(.Rows(i).Cells(4).Text)

                    DyngQty = Trim(CType(.Rows(i).FindControl("txtPopDyeingMtrs"), TextBox).Text)
                    ReqDyngDate = Trim(CType(.Rows(i).FindControl("txtPopDyngDate"), TextBox).Text)
                    Remarks = Trim(CType(.Rows(i).FindControl("txtPopDyngRemarks"), TextBox).Text)

                    FinsihQty = Trim(CType(.Rows(i).FindControl("txtPopFinMtrs"), TextBox).Text)
                    ReqFinishDate = Trim(CType(.Rows(i).FindControl("txtPopFinDate"), TextBox).Text)
                    FinsRemarks = Trim(CType(.Rows(i).FindControl("txtPopFinsRemarks"), TextBox).Text)

                    Qry = "Insert into Jct_Ops_Temp_Insert(Usercode,HostIP,Orderno,LineItem,DyngMtrs,DyngDate,FinsMtrs,FinsDate,DyngRemarks,FinsRemarks,UpdtInBase_Status,CreatedDate,Item) " & _
                        " Values('" & Session("Empcode") & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & OrderNo & "','" & Line & "'," & DyngQty & ",'" & ReqDyngDate & "'," & FinsihQty & ",'" & ReqFinishDate & "','" & Remarks & "','" & FinsRemarks & "','P',Getdate(),'" & Item & "')"

                    ObjFun.InsertRecord(Qry, Tran, Obj.Connection)
                    Tran.Commit()
                Next
                'GridView1.Rows(ViewState("row")).FindControl()
                Dim Rw As Int16 = 0
                Dim ImgBtn As ImageButton
                With GridView1
                    Rw = ViewState("Row")
                    Dim Finishvalidator As AjaxControlToolkit.MaskedEditValidator = TryCast(.Rows(Rw).FindControl("MEV1"), AjaxControlToolkit.MaskedEditValidator)
                    Dim DyngValidator As AjaxControlToolkit.MaskedEditValidator = TryCast(.Rows(Rw).FindControl("MEV6"), AjaxControlToolkit.MaskedEditValidator)
                    ImgBtn = CType(.Rows(Rw).FindControl("ImageButton2"), ImageButton)
                    ImgBtn.ImageUrl = "~/Image/SplitIconrED.png"
                    Finishvalidator.ValidationGroup = "None"
                    DyngValidator.ValidationGroup = "None"
                End With

                ModalPopupExtender1.Hide()
            End With
        Catch ex As Exception

            Scrpt = "alert('Some Error Occured.')"
            'ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", "bac", True)
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
            Tran.Rollback()


        End Try
    End Sub

    Private Sub DeleteTempData()
        Qry = "Delete from Jct_Ops_Temp_Insert where orderno= " 'usercode='" & Session("Empcode") & "' and hostip='" & Request.ServerVariables("REMOTE_ADDR") & "'"
        Cmd = New SqlCommand(Qry, Obj.Connection)
        Cmd.ExecuteNonQuery()
    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
    End Sub

End Class
