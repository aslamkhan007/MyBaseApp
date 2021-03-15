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
Partial Class OPS_New_Order_Scheduling
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim Qry As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand
    Dim Con As SqlConnection = New SqlConnection
    Dim ObjSendMail As SendMail = New SendMail



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Session("Empcode") = "" Then
            Response.Redirect("~\Login.aspx")
        End If
        If Not IsPostBack Then
            Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)

            'Qry = "Select '' as Location,'' union  Select '' as Location,'' union  SELECT DISTINCT LOCATION,Location FROM JCT_OPS_MONTHLY_PLANNING WHERE LOCATION IS not NULL or LOCATION <>'' order by  location"
            Qry = "Select '' as Location,'' union  SELECT DISTINCT LOCATION,Location FROM JCT_OPS_MONTHLY_PLANNING WHERE LOCATION IS not NULL or LOCATION <>'' order by  location"
            ObjFun.FillList(ddlPlant, Qry)

            Qry = "Delete from Jct_Ops_Temp_Insert " 'usercode='" & Session("Empcode") & "' and hostip='" & Request.ServerVariables("REMOTE_ADDR") & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Cmd.ExecuteNonQuery()

            txtEff_From.Text = "04/01/2012"
            txtEff_To.Text = Now.Date
            If UCase(Session("Empcode")) = "N-02633" Then ddlPlant.SelectedIndex = 1
        End If
    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim CheckBox1 As CheckBox = DirectCast(sender, CheckBox)
        Dim grow As GridViewRow = TryCast(TryCast(sender, CheckBox).Parent.Parent, GridViewRow)
        'Dim Finishvalidator As AjaxControlToolkit.MaskedEditValidator = TryCast(grow.FindControl("MEV1"), AjaxControlToolkit.MaskedEditValidator)
        'Dim DyngValidator As AjaxControlToolkit.MaskedEditValidator = TryCast(grow.FindControl("MEV6"), AjaxControlToolkit.MaskedEditValidator)

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
                '    Finishvalidator.ValidationGroup = "ValidGrpSaveDetail"
                '    DyngValidator.ValidationGroup = "ValidGrpSaveDetail"
            Else
                CType(grow.FindControl("ImageButton2"), ImageButton).ImageUrl = "~/Image/SplitIconrED.png"
                CType(grow.FindControl("ImageButton2"), ImageButton).Visible = True
                '    Finishvalidator.ValidationGroup = "None"
                '    DyngValidator.ValidationGroup = "None"
            End If

        Else
            Qry = "Delete from Jct_Ops_Temp_Insert where usercode='" & Session("Empcode") & "' and orderno='" & OrderNo & "' and  lineItem='" & Line & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Cmd.ExecuteNonQuery()
            'Finishvalidator.ValidationGroup = "None"
            'DyngValidator.ValidationGroup = "None"
            CType(grow.FindControl("ImageButton2"), ImageButton).Visible = False
            CType(grow.FindControl("ImageButton2"), ImageButton).ImageUrl = "~/Image/SplitIcon.png"
        End If



    End Sub

    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
        Qry = "Delete from Jct_Ops_Temp_Insert where usercode='" & Session("Empcode") & "' and hostip='" & Request.ServerVariables("REMOTE_ADDR") & "'"
        Cmd = New SqlCommand(Qry, Obj.Connection)
        Cmd.ExecuteNonQuery()
        BindGrids()
    End Sub
    Private Sub BindGrids()

        Dim CustCode As String, SalePerson As String, PlantType As String, OrderNo As String
        If txtOrderNo.Text = "" Then
            OrderNo = ""
        Else
            OrderNo = Trim(txtOrderNo.Text)
        End If
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


        If ddlOPtion.SelectedItem.Text = "Fresh" Then
            Qry = "Exec jct_ops_get_weaving_monthly_plan_Modified '','" & OrderNo & "','" & CustCode & "','" & SalePerson & "','','" & PlantType & "','" & txtEff_From.Text & "','" & txtEff_To.Text & "','U','" & Session("EmpCode") & "' "
        ElseIf ddlOPtion.SelectedItem.Text = "Re-Dyeing" Then
            Qry = "Exec JCT_Ops_get_ReDyng_ShortFall_Data '','" & OrderNo & "','" & CustCode & "','" & SalePerson & "','','" & PlantType & "','" & txtEff_From.Text & "','" & txtEff_To.Text & "','U','" & Session("EmpCode") & "' "
        ElseIf ddlOPtion.SelectedItem.Text = "Normal" Then
            Qry = "Exec jct_ops_get_weaving_monthly_plan_Modified '','" & OrderNo & "','" & CustCode & "','" & SalePerson & "','','" & PlantType & "','" & txtEff_From.Text & "','" & txtEff_To.Text & "','U','" & Session("EmpCode") & "' "
        End If

        'Qry = "Select * from Tbl112"
        ObjFun.FillGrid(Qry, GridView1)

        Dim OrderExist As Boolean = False
        Qry = "SELECT 'X' FROM Jct_Ops_Pending_Processing_Orders_Fetch WHERE UserCode='" & Session("Empcode") & "'"
        OrderExist = ObjFun.CheckRecordExistInTransaction(Qry)
        If txtOrderNo.Text <> "" Then
            If OrderExist = True And txtOrderNo.Text <> "" Then
                Qry = "SELECT 1 FROM Jct_Ops_Planned_Processing_Orders WHERE OrderNo='" & txtOrderNo.Text & "' and PlanStatus='Complete'"
                If ObjFun.CheckRecordExistInTransaction(Qry) = True Then
                    '       HttpContext.Current.Response.Write("<script>alert('" + "Order Planned Already!!!" + "');</script>")
                    ObjFun.Alert("Order Planned Already!!!")
                    'Else
                    '    Qry = "SELECT 1 FROM Jct_Ops_Planned_Processing_Orders WHERE OrderNo='" & txtOrderNo.Text & "' and PlanStatus='Complete'"
                    '    'HttpContext.Current.Response.Write("<script>alert('" + "Unable To Fetch Order Details.. !!!" + "');</script>")
                    '    ObjFun.Alert("Unable To Fetch Order Details.. !!!")
                End If
            Else
                'HttpContext.Current.Response.Write("<script>alert('" + "Unable To Fetch Order Details.. !!!" + "');</script>")
                ObjFun.Alert("Unable To Fetch Order Details.. !!!")
            End If
        End If

    End Sub

    Protected Sub ddlSalesPerson_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSalesPerson.SelectedIndexChanged

    End Sub

    Protected Sub ddlPlant_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPlant.SelectedIndexChanged

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim Btndetails As ImageButton = sender
        Dim GvRow = CType(Btndetails.NamingContainer, GridViewRow)
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
            For Each P As SqlParameter In Cmd.Parameters
                'Qry1 = Qry1 & P.Value
                Qry1 = Qry & P.Value & ","
            Next


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
        Try
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

            ElseIf e.Row.RowType = DataControlRowType.Header And Left(ddlOPtion.SelectedItem.Text, 1) = "R" Then
                GridView1.Columns(13).HeaderText = "DyedQty"
                GridView1.Columns(14).HeaderText = "Re-DyeQty"
                GridView1.Columns(15).HeaderText = "Req-ReDyngDt"
                GridView1.Columns(16).HeaderText = "FinshdQty"
                GridView1.Columns(17).HeaderText = "Req-ReFinsQty"
                '  GridView1.Columns(18).HeaderText = "y"
            End If
        Catch ex As Exception
            MsgBox(" " & ex.ToString & "" & e.Row.RowIndex.ToString)
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

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

        Dim Exp As String

        Dim EmpCode As String

        Dim EmpName As String = ""

        Dim index As Int16 = 0
        EmpCode = Trim(Session("Empcode"))

        Dim Str As String
        Dim body As String
        'Dim Sb As StringBuilder
        'If ddlResult.SelectedItem.Text = "Pass" Then

        


        ' MsgBox("Part 1" & Str(0) & "---Part 2 " & Str(1))
        Qry = "SELECT empname  FROM dbo.JCT_EmpMast_Base WHERE Active='Y' AND empcode LIKE '%" & EmpCode & "%' "
        If ObjFun.CheckRecordExistInTransaction(Qry) = True Then
            If EmpCode = "0" Then
                ObjFun.Alert("Employee Does Not Exist. Please select employee from List !!! ")
                Exit Sub
            Else
                EmpName = ObjFun.FetchValue(Qry)
            End If
        Else
            ObjFun.Alert("Unable To Continue !!! ")
        End If


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
                            Qry = "Exec JCT_OPS_Insert_Planned_Orders '" & Session("Empcode") & "','" & OrderNo & "','" & Item & "','" & Line & "','" & Shade & "'," & OrderQty & "," & IssuedMtr & "," & DyngQty & ",'" & ReqDyngDate & "'," & FinsihQty & ",'" & ReqFinishDate & "'," & BalDyngQty & "," & BalFinishQty & ",'" & Remarks & "','" & HostIP & "','" & FinsRemarks & "','" & Left(ddlOPtion.SelectedItem.Text, 1) & "' "
                        Else
                            Qry = "Exec Jct_Ops_Convert_Split_Orders_To_Freezed '" & Session("Empcode") & "','" & OrderNo & "','" & Item & "','" & Line & "','" & Shade & "'," & OrderQty & "," & IssuedMtr & "," & DyngQty & "," & FinsihQty & ",'" & HostIP & "','" & Left(ddlOPtion.SelectedItem.Text, 1) & "' "
                        End If
                        ObjFun.InsertRecord(Qry, Tran, Obj.Connection)
                        body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> '" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Item & "' <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><B>Remarks For Dyeing :- </B>" & Remarks & "<B><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "' <b>Remarks For Finishing :- " & FinsRemarks & " <h3>This SaleOrder was Put into the Dyeing & Finishing plan by </h3> '" & EmpName & "' <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                        Qry = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" & OrderNo & "'"
                        Dim SalePersonCode As String = ""
                        Dim SalePersonEmail As String = "mkt-group@jctltd.com"
                        SalePersonCode = ObjFun.FetchValue(Qry)
                        'Splecial Case added for Baljinder Kalsi
                        If Trim(SalePersonCode) = "B02806" Then SalePersonCode = "B00347"


                        If SalePersonCode Is Nothing Then SalePersonCode = ""
                        If SalePersonCode <> "mkt-group@jctltd.com" And CStr(SalePersonCode) <> "" Then
                            SalePersonCode = Left(SalePersonCode, 1) & "-" & Right(SalePersonCode, Len(SalePersonCode) - 1)
                            Qry = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & SalePersonCode & "' "
                            SalePersonEmail = ObjFun.FetchValue(Qry)
                        End If
                        'Comented on 10-Jan-2013 ObjFun.SendMailOPS(body, OrderNo, SalePersonEmail, Session("Empcode"), "rahuljindal@jctltd.com,rashpal@jctltd.com,karunarora@jctltd.com,khushwinder@jctltd.com,neeraj@jctltd.com,sobti@jctltd.com,arvindsharma@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Included in Dyeing & Finishing Plan")
                        If LCase(ddlPlant.SelectedItem.Text) = "cotton" Then
                            ObjFun.SendMailOPS(body, OrderNo, SalePersonEmail, Session("Empcode"), "rahuljindal@jctltd.com,rashpal@jctltd.com,karunarora@jctltd.com,khushwinder@jctltd.com,neeraj@jctltd.com,sobti@jctltd.com,arvindsharma@jctltd.com,william@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Included in Dyeing & Finishing Plan")
                        Else
                            ObjFun.SendMailOPS(body, OrderNo, SalePersonEmail, Session("Empcode"), "ramjiban@jctltd.com,husanlal@jctltd.com,trivendermehta@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,william@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Included in Dyeing & Finishing Plan")
                        End If

                        Tran.Commit()
                        Qry = ""


                        OrderCount += 1
                    Catch ex As Exception
                        Exp = ex.ToString
                        ErrorOrderCount += 1
                        Tran.Rollback()
                        ObjFun.Alert("Some Error Occured : Detail " & Exp)
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

    Protected Sub ddlOPtion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlOPtion.SelectedIndexChanged
        GridView1.DataSource = Nothing
        GridView1.DataBind()
    End Sub

    Protected Sub txtOrderNo_TextChanged(sender As Object, e As System.EventArgs) Handles txtOrderNo.TextChanged

    End Sub

    Protected Sub CmdDEtail_Click(sender As Object, e As System.EventArgs) Handles CmdDEtail.Click
        Response.Redirect("CurrentProcessPlan.aspx")
    End Sub
End Class
