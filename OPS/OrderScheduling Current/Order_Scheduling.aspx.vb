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

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
       
        BindGrids()

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)
            Qry = "SELECT DISTINCT yearmonth,yearmonth FROM JCT_OPS_MONTHLY_PLANNING ORDER BY yearmonth desc"
            ObjFun.FillList(ddlOrderScheduling, Qry)
            Qry = "Select '' as Location,'' union  SELECT DISTINCT LOCATION,Location FROM JCT_OPS_MONTHLY_PLANNING order by  location"
            ObjFun.FillList(ddlPlant, Qry)
        End If
    End Sub

    Protected Sub CmdXl_Click(sender As Object, e As System.EventArgs) Handles CmdXl.Click
        GridViewExportUtil.Export("Plan" & ".xls", GridView1)
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType <> DataControlRowType.Header And e.Row.RowType <> DataControlRowType.Footer Then
            Dim IssuedMtr As Int64, BalDyngQty As Int64, BalFinishQty As Int64
            IssuedMtr = Val(Trim(e.Row.Cells(11).Text))
            BalDyngQty = Val(Trim(e.Row.Cells(12).Text))
            If BalDyngQty > 0 Then
                CType(e.Row.FindControl("txtDyeingMtrs"), TextBox).Text = BalDyngQty
                e.Row.Cells(12).CssClass = "GridRowGreen"
                ' e.Row.CssClass = "GridRowGreen"
            Else
                CType(e.Row.FindControl("txtDyeingMtrs"), TextBox).Text = Trim(e.Row.Cells(11).Text)

            End If
            BalFinishQty = Val(Trim(e.Row.Cells(14).Text))

            If BalFinishQty > 0 Then
                CType(e.Row.FindControl("txtFinishMtrs"), TextBox).Text = BalFinishQty
                e.Row.Cells(14).ForeColor = Drawing.Color.YellowGreen
            Else

                CType(e.Row.FindControl("txtFinishMtrs"), TextBox).Text = Trim(e.Row.Cells(11).Text)
            End If


        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub CmdApply_Click(sender As Object, e As System.EventArgs) Handles CmdApply.Click
        Dim OrderNo As String, Item As String, Shade As String
        Dim OrderDate As String, ReqDyngDate As String, ReqFinishDate As String
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

                        HostIP = Request.ServerVariables("REMOTE_ADDR")
                        'Con = Obj.Connection
                        'Tran = Con.BeginTransaction
                        OrderNo = Trim(.Rows(i).Cells(3).Text)
                        Item = Trim(.Rows(i).Cells(5).Text)
                        Shade = Trim(.Rows(i).Cells(6).Text)
                        OrderDate = Trim(.Rows(i).Cells(8).Text)
                        OrderQty = Trim(.Rows(i).Cells(9).Text)
                        IssuedMtr = Trim(.Rows(i).Cells(11).Text)
                        DyngQty = Trim(CType(.Rows(i).FindControl("txtDyeingMtrs"), TextBox).Text)
                        FinsihQty = Trim(CType(.Rows(i).FindControl("txtFinishMtrs"), TextBox).Text)
                        Remarks = Trim(CType(.Rows(i).FindControl("txtRemarks"), TextBox).Text)
                        Line = Trim(.Rows(i).Cells(4).Text)
                        ReqDyngDate = Trim(CType(.Rows(i).FindControl("txtReqDyeingDate"), TextBox).Text)

                        ReqFinishDate = Trim(CType(.Rows(i).FindControl("txtReqFinishDate"), TextBox).Text)


                        '            BalDyngQty = IssuedMtr
                        If Val(Trim(.Rows(i).Cells(12).Text)) = 0 Then
                            BalDyngQty = IssuedMtr - DyngQty
                        Else
                            BalDyngQty = Val(Trim(.Rows(i).Cells(12).Text)) - DyngQty

                        End If

                        If Val(Trim(.Rows(i).Cells(15).Text)) = 0 Then
                            BalFinishQty = IssuedMtr - FinsihQty
                        Else
                            BalFinishQty = Val(Trim(.Rows(i).Cells(15).Text)) - FinsihQty

                        End If
                        'BalFinishQty = Val(Trim(.Rows(i).Cells(15).Text))


                        'Cells(12).Text)
                        Qry = "Exec JCT_OPS_Insert_Planned_Orders '" & Session("EmpCode") & "','" & OrderNo & "','" & Item & "','" & Line & "','" & Shade & "'," & OrderQty & "," & IssuedMtr & "," & DyngQty & ",'" & ReqDyngDate & "'," & FinsihQty & ",'" & ReqFinishDate & "'," & BalDyngQty & "," & BalFinishQty & ",'" & Remarks & "','" & HostIP & "' "
                        'Qry = "INSERT INTO Jct_Ops_Planned_Processing_Orders(UserCode,OrderNo,Item,LINEItem,Shade,OrderQty ,IssuedQty ,ReqDyngQty ,ReqDyngDate ,ReqFinishQty ,ReqFinishDate ,PendingDyngQty ,PendingFinishQty,Remarks ,CreatedDate ,STATUS ,HOST_IP) VALUES('" & Session("EmpCode") & "','" & Trim() & "',,'" & Trim(.SelectedRow.Cells(4).Text) & "',0,'" & Trim(.SelectedRow.Cells(5).Text) & "','" & Trim(.SelectedRow.Cells(9).Text) & "','" & Trim(.SelectedRow.Cells(11).Text) & "')"
                        'ObjFun.InsertRecord(Qry, Tran, Con)
                        ObjFun.InsertRecord(Qry)
                        OrderCount += 1
                    Catch
                        ErrorOrderCount += 1
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
        Qry = "Exec jct_ops_get_weaving_monthly_plan_Modified '','" & OrderNo & "','','','','','','','P' "
        'Qry = "Select * from Tbl112"
        ObjFun.FillGrid(Qry, GridView3)
        CollapsiblePanelExtender3.AutoExpand = True
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim CheckBox1 As CheckBox = DirectCast(sender, CheckBox)
        Dim grow As GridViewRow = TryCast(TryCast(sender, CheckBox).Parent.Parent, GridViewRow)
        Dim Finishvalidator As AjaxControlToolkit.MaskedEditValidator = TryCast(grow.FindControl("MEV1"), AjaxControlToolkit.MaskedEditValidator)
        Dim DyngValidator As AjaxControlToolkit.MaskedEditValidator = TryCast(grow.FindControl("MEV6"), AjaxControlToolkit.MaskedEditValidator)


        If CheckBox1.Checked = True Then
            '  validator.Enabled = True
            Finishvalidator.ValidationGroup = "ValidGrpSaveDetail"
            DyngValidator.ValidationGroup = "ValidGrpSaveDetail"
        Else
            Finishvalidator.ValidationGroup = "None"
            DyngValidator.ValidationGroup = "None"
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
End Class
