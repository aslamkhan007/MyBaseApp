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
Imports System.Net.Mail
Imports System.IO
Imports System.Text

Partial Class OPS_materialrequest
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim obj2 As Connection = New Connection
    Dim Qry, Sql As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand
    Dim Con As SqlConnection = New SqlConnection
    Dim Sm As SendMail = New SendMail()
    Dim enclosureslist As String
    Dim eReasonslist As String
    Dim emplist As String
    Dim email As String
    Dim script As String
    Dim flag As Integer = 0
    Dim Checked As Integer = 0
    Dim check_data As Integer = 0
    Dim elist As List(Of String) = New List(Of String)
    Dim emaillist As List(Of String) = New List(Of String)
    Dim Reasonlist As List(Of String) = New List(Of String)

    Protected Sub ConfigureNotification(sender As Object, args As System.EventArgs)
        'String
        Dim sb As StringBuilder = New StringBuilder()
        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("</head>")
        sb.AppendLine("<body>")
        sb.AppendLine("<div align='left'>You can import <strong> Pending/Cancelled </strong> sanction-note(MR) by entering sanctionID in <strong>Previous Request textbox </strong> and clicking <strong>Detail</strong> Button..!!</div>")
        sb.AppendLine("</body>")
        sb.AppendLine("</html>")
        RadNotification1.Title = "Notification Alert..!!"
        RadNotification1.Text = sb.ToString()
        RadNotification1.TitleIcon = "info"
        RadNotification1.ContentIcon = "info"
        RadNotification1.ShowSound = "none"

        'Enum
        RadNotification1.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification1.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        RadNotification1.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Auto

        'Unit
        RadNotification1.Width = 330
        RadNotification1.Height = 130

        'Integer
        RadNotification1.OffsetX = 0
        RadNotification1.OffsetY = 0
        RadNotification1.AutoCloseDelay = 15000
        RadNotification1.AnimationDuration = 1000
        RadNotification1.Opacity = 100


        'Boolean
        RadNotification1.Pinned = False
        RadNotification1.EnableRoundedCorners = True
        RadNotification1.EnableShadow = True
        RadNotification1.KeepOnMouseOver = True
        RadNotification1.VisibleTitlebar = True
        RadNotification1.ShowCloseButton = True
    End Sub
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ConfigureNotification(sender, Nothing)
            ViewState("RefreshFlag") = 0
            'Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            'ObjFun.FillList(ddlSalesPerson, Qry)
            Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(Upper(group_no)),rtrim(Upper(group_desc)) FROM miserp.som.dbo.m_cust_group a (Nolock) INNER JOIN dbo.JCT_EmpMast_Base b ON a.group_no=REPLACE(b.empcode,'-','')  WHERE group_TYPE='SALESP'  AND b.Active='Y' AND status ='o'    ORDER BY group_desc"
            ObjFun.FillList(ddlSalesPerson, Qry)




            Qry = "SELECT ACTIONDetail FROM Jct_Ops_Mr_ActionToBeTaken WHERE STATUS='A' ORDER BY ACTIONDetail"
            ObjFun.FillList(ddlActionToBeTaken, Qry)





            Sql = "Select requestid as ID from jct_ops_material_request where AuthStatus='A' and mr_Status='O' and userid='" + Session("EmpCode") + "'"
            Dim cmd As SqlCommand = New SqlCommand(Sql, Obj.Connection())
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            If (dr.HasRows) Then

                While (dr.Read())

                    Dim script As String = "alert('Your Sanction Note for Material Return - " + dr("id").ToString() + " has been authorized and you can now enter Transport details by clicking on Transport Button.!!');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)


                End While


            End If
            dr.Close()


            If (Request.QueryString("RequestID") <> "") Then
                '27 Jan 2016
                Sql = "SELECT Freight_by,reason,ret_qty,bales,invoice_qty,item_no,invoice_no ,invoice_date,customer,sales_person,Instructions,Enclouser,FlagAuth,sales_person,Plant,DESCRIPTION,TentativeRate FROM dbo.jct_ops_material_request WHERE RequestID=" + Request.QueryString("RequestID")
                '27 Jan 2016
                cmd = New SqlCommand(Sql, Obj.Connection())
                dr = cmd.ExecuteReader()
                If (dr.HasRows) Then

                    While (dr.Read())
 
                        txtCustomer.Text = dr("customer").ToString()
                        ddlSalesPerson.SelectedIndex = ddlSalesPerson.Items.IndexOf(ddlSalesPerson.Items.FindByValue(dr("sales_person")))
                        txtinstructions.Text = dr("Instructions").ToString()
                        txtDescription.Text = dr("DESCRIPTION").ToString()
                        txtSanctionID.Text = Request.QueryString("RequestID")
                        ddlPlant.SelectedIndex = ddlPlant.Items.IndexOf(ddlPlant.Items.FindByText(dr("plant").ToString()))
                        ddlPlant_SelectedIndexChanged(sender, Nothing)
                        txtTentative.Text = dr("TentativeRate").ToString()



                        'lnkFetch_Click(sender, Nothing)

                        '27 Jan 2016
                        Dim qry As String = "SELECT invoice_no as InvoiceNo,Freight_by as Freightby,Convert(varchar,invoice_qty) AS Qty,Convert(varchar,ret_qty) as ReturnQty,Convert(varchar,bales) as Bales,item_no as ItemNo,Convert(varchar,invoice_date) as  InvoiceDt,customer as Customer,sales_person as SalesPerson,reason,SalePrice,ValueInvolved,Gr_no As GRNo,Gr_date as GrDate,FreightValue FROM dbo.jct_ops_material_request WHERE RequestID=" + Request.QueryString("RequestID")
                        '27 Jan 2016

                        Dim cmd1 As SqlCommand = New SqlCommand(qry, obj2.Connection())
                        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
                        Dim ds As DataSet = New DataSet
                        da.Fill(ds)
                        ViewState("CurrentTable") = ds.Tables(0)
                        GridView2.DataSource = ds.Tables(0)
                        GridView2.DataBind()

                        Dim lst As Array

                        lst = dr("reason").ToString().Split(",")

                        For i As Integer = 0 To lst.Length - 1

                            chbReasons.SelectedIndex = chbReasons.Items.IndexOf(chbReasons.Items.FindByText(lst(i).ToString()))

                        Next

                    End While

                End If
                dr.Close()
                Obj.ConClose()
            End If

            ddlPlant_SelectedIndexChanged(sender, e)
        End If

       

    End Sub

    Protected Sub CheckRecord()
        flag = 0
        If txtEff_From.Text <> "" Or txtEff_To.Text <> "" Or txtCustomer.Text <> "" Or ddlSalesPerson.SelectedItem.Text <> "" Or txtInvoiceNo.Text <> "" Then

            flag = 1

        End If

    End Sub



    Protected Sub lnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFetch.Click

        'CheckRecord()
        'If (flag = 1) Then
        '    flag = 0
        Dim CustCode As String, SalePerson As String
        ' PlantType As String
        If txtCustomer.Text = "" Then
            CustCode = ""
        Else
            CustCode = Right(txtCustomer.Text, Len(txtCustomer.Text) - InStr(txtCustomer.Text, "~")) 'txtCustomer.Text
        End If
        'If ddlSalesPerson.SelectedItem.Text = "" Then
        '    SalePerson = ""
        'Else
        '    SalePerson = Trim(ddlSalesPerson.SelectedItem.Value)
        'End If

        SetInitialRow()

        'Else

        'Dim script As String = "alert('Please enter some value i.e. Invoice No,Customer, SalePerson etc to fetch the details..!!');"
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

        'End If

    End Sub


    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound

    End Sub

    'Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand

    '    If (e.CommandName = "Save") Then

    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex
    '            Dim Freight As DropDownList = DirectCast(GridView2.Rows(rowIndex).Cells(1).FindControl("ddlFreight"), DropDownList)
    '            Dim reason As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(2).FindControl("txtReason"), TextBox)
    '            Dim ReturnQty As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(3).FindControl("txtReturnQty"), TextBox)
    '            Dim bales As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(4).FindControl("txtbales"), TextBox)
    '            Dim qty As String = GridView2.Rows(rowIndex).Cells(5).Text
    '            Dim item_no As String = GridView2.Rows(rowIndex).Cells(6).Text
    '            Dim invoice_no As String = GridView2.Rows(rowIndex).Cells(7).Text
    '            Dim inv_date As String = GridView2.Rows(rowIndex).Cells(8).Text
    '            Dim cust_name As String = GridView2.Rows(rowIndex).Cells(9).Text



    '            If (reason.Text.ToString() <> "") Then

    '                'ViewState("Customer") = cust_name.ToString()
    '                'ViewState("Invoice") = invoice_no.ToString()
    '                'ViewState("ReturnVal") = ReturnQty.Text.ToString()
    '                'ViewState("Item") = item_no.ToString()
    '                'ViewState("Reason") = reason.Text
    '                ' ------------ save return entry in table 
    '                'Qry = "insert into jct_ops_material_request( invoice_no , invoice_date ,  sales_person ,  customer ,  item_no ,  invoice_qty ,   Freight_by ,  reason , userid ,  gr_no , mr_status , ret_qty , tran_date, instructions, bales ) values('" & invoice_no & "',  CONVERT(VARCHAR, CONVERT(DATETIME,'" + inv_date + "',103),101), '" & Me.ddlSalesPerson.SelectedValue & "','" & cust_name & "', '" & item_no & "', '" & qty & "', '" & Freight.SelectedValue & "',   '" & reason.Text & "','" & Session("Empcode") & "', ' ','O',  " & ReturnQty.Text & ",getdate(), '" & Me.txtinstructions.Text & "' , '" & bales.Text & "')"
    '                Qry = "JCT_OPS_MATERIAL_RETURN_REQUEST_GENERATE"
    '                Cmd = New SqlCommand(Qry, Obj.Connection())
    '                Cmd.CommandType = CommandType.StoredProcedure

    '                Cmd.Parameters.Add("@Freight", SqlDbType.VarChar, 20).Value = Freight.SelectedItem.Text
    '                Cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 200).Value = reason.Text
    '                Cmd.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = Convert.ToDecimal(ReturnQty.Text)
    '                Cmd.Parameters.Add("@Bales", SqlDbType.Decimal).Value = Convert.ToDecimal(bales.Text)
    '                Cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(qty)
    '                Cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 200).Value = item_no
    '                Cmd.Parameters.Add("@Invoice_no", SqlDbType.VarChar, 30).Value = invoice_no
    '                Cmd.Parameters.Add("@Inv_date", SqlDbType.DateTime).Value = Convert.ToDateTime(inv_date)
    '                Cmd.Parameters.Add("@Cust_name", SqlDbType.VarChar, 100).Value = cust_name
    '                Cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 100).Value = ddlSalesPerson.SelectedItem.Value
    '                Cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    '                Cmd.Parameters.Add("@Instruction", SqlDbType.VarChar, 200).Value = txtinstructions.Text

    '                Cmd.ExecuteNonQuery()
    '                Dim script As String = "alert('Record Added.');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '                ' ------------ mail generation 
    '                Dim body As String = "<p>Hello ,</p> <p>You are receiving this email on the behalf of Mktg. Dept, Material Rerurn From Party.</p> </p> <H3>Customer :" + cust_name + "</H3> </p> <p> <H3> Item No :" + item_no + "</H3>  </p> <p><h3>InvoiceNo :" + invoice_no + " </h3></p><p><H3> Return Quantity: " + ReturnQty.Text + " </H3></p><p><H3> Reason: " + reason.Text + " </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
    '                ' Sm.SendMail("rajan@jctltd.com", "noreply@jctltd.com", "Material Return From Party : " + cust_name, body)
    '                Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Material Return From Party : " + cust_name, body)
    '                '  Sm.SendMail("mikeops@jctltd.com", "noreply@jctltd.com", "Material Return From Party : " + cust_name, body)

    '            Else
    '                Dim script As String = "alert('Please Enter Reason for Material Return..!!');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '            End If


    '        Catch ex As Exception

    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '        End Try

    '    End If
    'End Sub

    'Protected Sub grdAuthorize_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAuthorize.RowCommand
    '    Dim Customer, Invoice, returnVal, Item, Reason As String
    '    If e.CommandName = "Authorize" Then

    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex

    '            Dim ID As String = grdAuthorize.Rows(rowIndex).Cells(3).Text
    '            Dim Remarks As TextBox = DirectCast(grdAuthorize.Rows(rowIndex).FindControl("txtRemarks"), TextBox)

    '            Qry = "SELECT sr_no,customer,sales_person ,invoice_no,item_no,invoice_qty,reason,ret_qty,invoice_date FROM dbo.jct_ops_material_request WHERE mr_status='O' AND sr_no =" + ID + ""
    '            Dim Cmd As SqlCommand = New SqlCommand(Qry, Obj.Connection())
    '            Dim dr As SqlDataReader = Cmd.ExecuteReader()
    '            If (dr.HasRows) Then
    '                While (dr.Read())
    '                    Customer = dr("customer").ToString()
    '                    Invoice = dr("invoice_no").ToString()
    '                    returnVal = dr("ret_qty").ToString()
    '                    Item = dr("item_no").ToString()
    '                    Reason = dr("reason").ToString()
    '                End While
    '            Else

    '                Customer = ""
    '                Invoice = ""
    '                returnVal = ""
    '                Item = ""
    '                Reason = ""

    '            End If
    '            dr.Close()

    '            Qry = "JCT_OPS_MATERIAL_REQUEST_AUTHORIZE"
    '            Cmd = New SqlCommand(Qry, Obj.Connection())
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(ID)
    '            Cmd.Parameters.Add("@AUTH_USERCODE", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    '            Cmd.Parameters.Add("@AUTH_Remarks", SqlDbType.VarChar, 200).Value = Remarks.Text
    '            Cmd.ExecuteNonQuery()

    '            'Dim body As String = "<p>Hello ,</p> <p> The Material Return Request has been authorized by Mr.Charanamrit Singh. Please do the needful at your end now. Details of the request are as follows : </p> </p> <H3>Customer :" + Customer + "</H3> </p> <p> <H3> Item No :" + Item + "</H3>  </p> <p><h3>InvoiceNo :" + Invoice + " </h3></p><p><H3> Return Quantity: " + returnVal + " </H3></p><p><H3> Remarks: " + Remarks.Text + " </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
    '            'Sm.SendMail("pgmohan@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)
    '            'Sm.SendMail("mrsood@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)
    '            'Sm.SendMail("rameshs@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)
    '            'Sm.SendMail("charanamrit.singh@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)
    '            'Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Authorization - Material Return From Party", body)


    '            Qry = "EXEC JCT_OPS_MATERIAL_RETURN_FETCH"
    '            ObjFun.FillGrid(Qry, grdAuthorize)

    '            Dim script As String = "alert('Record Authorized');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
    '            SendMail_OnCEOAuthorization(e.CommandName)
    '        Catch ex As Exception

    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)


    '        Finally

    '            Obj.ConClose()

    '        End Try



    '    ElseIf e.CommandName = "Cancel" Then


    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex

    '            Dim ID As String = grdAuthorize.Rows(rowIndex).Cells(1).Text
    '            Dim empcode As String = ObjFun.FetchValue("SELECT sales_person FROM  jct_ops_material_request WHERE sr_no=" + ID + " ").ToString()
    '            Dim Sales_PersonEmail As String = ObjFun.FetchValue("SELECT isnull(E_MailID,'rajan@jctltd.com') FROM dbo.MISTEL WHERE REPLACE(empcode,'-','')='" + empcode + "'").ToString()
    '            Qry = "JCT_OPS_MATERIAL_REQUEST_CANCEL"
    '            Dim Cmd As SqlCommand = New SqlCommand(Qry, Obj.Connection())
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(ID)
    '            Cmd.Parameters.Add("@AUTH_USERCODE", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    '            Cmd.ExecuteNonQuery()

    '            Dim body As String = "<p>Hello ,</p> <p> The Material Return Request has been cancelled by Mr.Charanamrit Singh. Please do the needful at your end now. Details of the request are as follows : </p> </p> <H3>Customer :" + ViewState("Customer") + "</H3> </p> <p> <H3> Item No :" + ViewState("Item") + "</H3>  </p> <p><h3>InvoiceNo :" + ViewState("Invoice") + " </h3></p><p><H3> Return Quantity: " + ViewState("ReturnVal") + " </H3></p></br><p>This mail is a system generated mail and sent to you just for your information.Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

    '            Sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", "Cancellation - Material Return From Party", body)
    '            'Sm.SendMail("mikeops@jctltd.com", "noreply@jctltd.com", "Cancellation - Material Return From Party", body)
    '            'Sm.SendMail("charanamrit.singh@jctltd.com", "noreply@jctltd.com", "Cancellation - Material Return From Party", body)

    '            'Sm.SendMail(Sales_PersonEmail, "noreply@jctltd.com", "Cancellation - Material Return From Party", body)


    '            Qry = "EXEC JCT_OPS_MATERIAL_RETURN_FETCH"
    '            ObjFun.FillGrid(Qry, grdAuthorize)

    '            Dim script As String = "alert('Material Request Cancelled..!!');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
    '            SendMail_OnCEOAuthorization(e.CommandName)
    '        Catch ex As Exception

    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)


    '        Finally

    '            Obj.ConClose()

    '        End Try

    '    ElseIf e.CommandName = "Select" Then

    '        Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '        Dim rowIndex As Integer = gvr.RowIndex
    '        Dim ID As String = grdAuthorize.Rows(rowIndex).Cells(1).Text


    '    End If

    'End Sub

    'Protected Sub grdGrNo_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdGrNo.RowCommand

    '    If e.CommandName = "SaveGrNo" Then

    '        Try

    '            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
    '            Dim rowIndex As Integer = gvr.RowIndex

    '            Dim ID As String = grdGrNo.Rows(rowIndex).Cells(5).Text
    '            Dim GrNo As TextBox = DirectCast(grdGrNo.Rows(rowIndex).FindControl("txtGrNo"), TextBox)
    '            Dim GrDate As TextBox = DirectCast(grdGrNo.Rows(rowIndex).FindControl("txtGrDate"), TextBox)
    '            Dim Transport As DropDownList = DirectCast(grdGrNo.Rows(rowIndex).FindControl("ddlTransport"), DropDownList)
    '            Dim BaleNo As TextBox = DirectCast(grdGrNo.Rows(rowIndex).FindControl("txtBaleNo"), TextBox)

    '            Qry = "JCT_OPS_MATERIAL_REQUEST_AUTHORIZE_GR_No"
    '            Dim Cmd As SqlCommand = New SqlCommand(Qry, Obj.Connection())
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(ID)
    '            Cmd.Parameters.Add("@AUTH_USERCODE", SqlDbType.VarChar, 10).Value = Session("EmpCode")
    '            Cmd.Parameters.Add("@GrNo", SqlDbType.VarChar, 20).Value = GrNo.Text
    '            Cmd.Parameters.Add("@GrDate", SqlDbType.DateTime).Value = GrDate.Text
    '            Cmd.Parameters.Add("@Transport", SqlDbType.VarChar, 20).Value = Transport.SelectedItem.Text
    '            Cmd.Parameters.Add("@BaleNo", SqlDbType.VarChar, 500).Value = BaleNo
    '            Cmd.ExecuteNonQuery()

    '            Qry = "EXEC JCT_OPS_MATERIAL_RETURN_FETCH_ADD_GR_NO"
    '            ObjFun.FillGrid(Qry, grdAuthorize)

    '            Dim script As String = "alert('Details Added to Record..!!');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

    '        Catch ex As Exception
    '            Dim script As String = "alert('" + ex.Message + "');"
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
    '        End Try

    '    End If

    'End Sub

    Protected Sub chbEnclosures_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles chbEnclosures.SelectedIndexChanged

        For i As Integer = 0 To chbEnclosures.Items.Count - 1
            If chbEnclosures.Items(i).Selected Then

                If chbEnclosures.Items(i).Text = "Other" Then

                    txtEnclosures.Visible = True
                End If

            Else

                If chbEnclosures.Items(i).Text = "Other" Then

                    txtEnclosures.Visible = False

                End If

            End If
        Next


    End Sub

   

    Protected Function ListOfConcernedDepts(ByVal chb As RadioButtonList, sqlcon As SqlConnection, sqltran As SqlTransaction) As String


        For i As Integer = 0 To chb.Items.Count - 1

            If chb.Items(i).Selected Then

                Sql = "JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS_MAPPING"
                Dim cmd As SqlCommand = New SqlCommand(Sql, sqlcon)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Transaction = sqltran

                cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 200).Value = Convert.ToString(chb.Items(i).Text)
                cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If (dr.HasRows()) Then
                    While dr.Read
                        For Each item As String In elist
                            If (dr(0).ToString() = item) Then
                                dr.Close()
                                GoTo Check
                            End If

                        Next
                        Reasonlist.Add(chb.Items(i).Text)
                        elist.Add(dr(0).ToString())
                        emaillist.Add(dr(1).ToString())
                    End While
                End If
                dr.Close()

            End If


Check:  Next

        'enclosureslist.Join(",", enclosures.ToArray)
        emplist = String.Join(",", elist.ConvertAll(Of String)(Function(i As String) i.ToString()).ToArray).TrimEnd(",").TrimStart(",")
        email = String.Join(",", emaillist.ConvertAll(Of String)(Function(i As String) i.ToString()).ToArray).TrimEnd(",").TrimStart(",")
        eReasonslist = String.Join(",", Reasonlist.ConvertAll(Of String)(Function(i As String) i.ToString()).ToArray).TrimEnd(",").TrimStart(",")
        Return emplist

    End Function

    Protected Sub CheckReason()


        For i As Integer = 0 To chbReasons.Items.Count - 1

            If chbReasons.Items(i).Selected Then

                flag = 1

            End If


        Next

    End Sub

    Protected Sub CheckData()


        For i As Integer = 0 To GridView2.Rows.Count - 1

            If (Not String.IsNullOrEmpty(GridView2.Rows(i).Cells(5).Text)) Then
                check_data = 1


            Else
                check_data = 0
            End If

        Next


    End Sub

    Protected Sub lnkSave_Click(sender As Object, e As System.EventArgs) Handles lnkSave.Click
        Dim list As String = String.Empty
        Dim FileName As String = ""
        'Dim j As Int16
        CheckReason()
        Dim Sqltran As SqlTransaction
        Sqltran = Obj.Connection.BeginTransaction
        ' CheckData()
        Try
            If (flag = 1) Then
                flag = 0


                If (txtFreightValue.Text <> String.Empty) Then
                    If (IsNumeric(txtFreightValue.Text) = False) Then
                        Dim script As String = "alert('Please enter valid freight charges..!!');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
                        Return

                    End If
                End If

                If (ViewState("RefreshFlag") = 1) Then
                    ViewState("RefreshFlag") = 0
                    Dim RequestId As Int16
                    Qry = "JCT_OPS_MATERIAL_REQUEST_GENERATE_REQUESTID"
                    Cmd = New SqlCommand(Qry, Obj.Connection())
                    Cmd.Transaction = Sqltran
                    Cmd.CommandType = CommandType.StoredProcedure
                    Dim dr As SqlDataReader = Cmd.ExecuteReader
                    If (dr.HasRows) Then

                        While (dr.Read())

                            RequestId = Convert.ToInt16(dr(0).ToString())
                            ViewState("RequestID") = Convert.ToString(RequestId)
                        End While

                    End If
                    dr.Close()




                    Dim EmpLevelCount As Int16 = 0
                    EmpLevelCount = ChkDynamicListing.Items.Count



                    For i = 0 To ChkDynamicListing.Items.Count - 1
                        Qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL,ImportedUser) values('" & RequestId & "','" & Session("empcode") & "','1014','" & ChkDynamicListing.Items(i).Value & "'," & i + 1 & ",'Y')"
                        Cmd = New SqlCommand(Qry, Obj.Connection)
                        Cmd.Transaction = Sqltran
                        Cmd.ExecuteNonQuery()
                    Next


                    'Qry = "exec Jct_Ops_SanctionNote_InsertDynamic_User_ReasonWise '" & RequestId & "','" & Session("empcode") & "','" & ddlarea.SelectedItem.Value & "'," & EmpLevelCount & ",'" & ddlPlant.SelectedItem.Text & "'," & ReasonCode & ""
                    'ObjFun.InsertRecord(Qry, Tran, Obj.Connection)



                    For i = 0 To chkNotify.Items.Count - 1
                        Qry = "INSERT INTO dbo.Jct_Ops_SanctionNote_Notify( Usercode ,SanctionID ,NotifyUser , CreatedDate) values('" & Session("Empcode") & "','" & RequestId & "','" & chkNotify.Items(i).Value & "',getdate())"
                        Cmd = New SqlCommand(Qry, Obj.Connection)
                        Cmd.Transaction = Sqltran
                        Cmd.ExecuteNonQuery()
                    Next





                    If Request.Files.Count > 0 Then
                        For i = 0 To Request.Files.Count - 1
                            Dim PostedFile As HttpPostedFile = Request.Files(i)
                            If PostedFile.ContentLength > 0 Then
                                FileName = System.IO.Path.GetFileName(PostedFile.FileName)
                                PostedFile.SaveAs(Server.MapPath("Upload\MaterialRetrun\") & FileName)
                                Qry = "INSERT INTO Jct_Ops_SanctionNote_Attachments( SanctionNoteID ,ImgName ,STATUS ,UploadedOn) VALUES  ( '" & RequestId & "' , '" & FileName & "' , 'A' , GETDATE())"
                                ObjFun.InsertRecord(Qry, Sqltran, Obj.Connection)
                            End If
                        Next

                    End If





                    'txtGrNo txtGrDate



                    For i As Integer = 0 To GridView2.Rows.Count - 1


                        Dim Freight As DropDownList = DirectCast(GridView2.Rows(i).FindControl("ddlFreight"), DropDownList)
                        Dim ReturnQty As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtReturnQty"), TextBox)
                        Dim bales As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtbales"), TextBox)
                        Dim qty As String = DirectCast(GridView2.Rows(i).FindControl("lblQty"), Label).Text
                        Dim item_no As String = DirectCast(GridView2.Rows(i).FindControl("lblItemNo"), Label).Text
                        Dim invoice_no As String = DirectCast(GridView2.Rows(i).FindControl("txtInvocieNo"), TextBox).Text
                        Dim inv_date As String = DirectCast(GridView2.Rows(i).FindControl("lblInvoiceDt"), Label).Text
                        Dim cust_name As String = DirectCast(GridView2.Rows(i).FindControl("lblCustomer"), Label).Text
                        Dim saleperson As String = DirectCast(GridView2.Rows(i).FindControl("lblSalesPerson"), Label).Text



                        Dim GrNo As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtGrNo"), TextBox)
                        Dim GrDate As TextBox = DirectCast(GridView2.Rows(i).FindControl("txtGrDate"), TextBox)

                        Dim SalePrice As Label = DirectCast(GridView2.Rows(i).FindControl("lblSalePrice"), Label)

                        Dim ValueInvolved As Label = DirectCast(GridView2.Rows(i).FindControl("lblValueInvolved"), Label)

                        Dim GrNoReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(i).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
                        Dim GrDateReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(i).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


                        If ddlRequestType.SelectedItem.Text = "Sale Return" Then
                            GrNoReqdValid.Enabled = False
                            GrDateReqdValid.Enabled = False
                        Else
                            GrNoReqdValid.Enabled = True
                            GrDateReqdValid.Enabled = True
                        End If

                        If saleperson.ToString() = "&nbsp;" Or saleperson.ToString() = "" Then
                            saleperson = ddlSalesPerson.SelectedItem.Value
                        End If

                        list = ListOfElcosures(chbEnclosures, txtEnclosures)
                        Dim FlagAuth As String = ListOfConcernedDepts(chbReasons, Obj.Connection, Sqltran)
                        ViewState("Customer") = cust_name
                        Try


                            If (eReasonslist <> "") Then
                                If (txtSanctionID.Text <> "") Then

                                    PreviousSanctionNotes(Sqltran, Obj.Connection)

                                End If

                                Qry = "JCT_OPS_MATERIAL_RETURN_REQUEST_GENERATE_Ashish"
                                Cmd = New SqlCommand(Qry, Obj.Connection())
                                Cmd.CommandType = CommandType.StoredProcedure

                                Cmd.Transaction = Sqltran

                                Cmd.Parameters.Add("@Freight", SqlDbType.VarChar, 20).Value = Freight.SelectedItem.Text
                                Cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 200).Value = eReasonslist
                                Cmd.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = Convert.ToDecimal(IIf(String.IsNullOrEmpty(ReturnQty.Text), 0, ReturnQty.Text))
                                Cmd.Parameters.Add("@Bales", SqlDbType.Decimal).Value = Convert.ToDecimal(bales.Text)
                                Cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(qty)
                                Cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 200).Value = item_no
                                Cmd.Parameters.Add("@Invoice_no", SqlDbType.VarChar, 30).Value = invoice_no
                                Cmd.Parameters.Add("@Inv_date", SqlDbType.VarChar, 20).Value = inv_date
                                Cmd.Parameters.Add("@Cust_name", SqlDbType.VarChar, 100).Value = cust_name
                                Cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 100).Value = ddlSalesPerson.SelectedItem.Value
                                Cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
                                Cmd.Parameters.Add("@Instruction", SqlDbType.VarChar, 200).Value = txtinstructions.Text
                                Cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = RequestId
                                Cmd.Parameters.Add("@Enclosures", SqlDbType.VarChar, 100).Value = list
                                Cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 20).Value = FlagAuth
                                Cmd.Parameters.Add("@AuthStatus", SqlDbType.VarChar, 2).Value = "P"
                                Cmd.Parameters.Add("@salespersonCode", SqlDbType.VarChar, 200).Value = IIf(String.IsNullOrEmpty(saleperson), ddlSalesPerson.SelectedItem.Text, saleperson)
                                Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = IIf(String.IsNullOrEmpty(ddlPlant.SelectedItem.Text), "No Plant Selected", ddlPlant.SelectedItem.Text)
                                Cmd.Parameters.Add("@Description", SqlDbType.VarChar, 4000).Value = txtDescription.Text
                                Cmd.Parameters.Add("@PreviousRequestID", SqlDbType.VarChar, 10).Value = txtSanctionID.Text
                                If (Not String.IsNullOrEmpty(txtFreightValue.Text)) Then
                                    If ddlRequestType.SelectedItem.Text = "Sale Return" Then txtFreightValue.Text = 0
                                    Cmd.Parameters.Add("@FreightValue", SqlDbType.Decimal, 20).Value = Convert.ToDecimal(txtFreightValue.Text) 'IIf(String.IsNullOrEmpty(txtFreightValue.Text), Nothing, Convert.ToDecimal(txtFreightValue.Text))
                                End If

                                Cmd.Parameters.Add("@Add_Lvl", SqlDbType.Int).Value = EmpLevelCount
                                Cmd.Parameters.Add("@RequestType", SqlDbType.VarChar, 30).Value = ddlRequestType.SelectedItem.Text
                                Cmd.Parameters.Add("@ActionToBe", SqlDbType.VarChar, 30).Value = ddlActionToBeTaken.SelectedItem.Text

                                '27 Jan 2016

                                Cmd.Parameters.Add("@TentativeRate", SqlDbType.VarChar, 30).Value = txtTentative.Text

                                '27 Jan 2016

                                Cmd.Parameters.Add("@FreightAppliedOn", SqlDbType.VarChar, 30).Value = ddlFreightAppliedTo.SelectedItem.Text
                                Cmd.Parameters.Add("@FreightType", SqlDbType.VarChar, 30).Value = ddlFreightType.SelectedItem.Text


                                Cmd.Parameters.Add("@SalePrice", SqlDbType.VarChar, 30).Value = SalePrice.Text
                                Cmd.Parameters.Add("@ValueInvolved", SqlDbType.VarChar, 20).Value = ValueInvolved.Text

                                Cmd.Parameters.Add("@ExpectedArrivalDt", SqlDbType.DateTime).Value = txtExpectedArrDate.Text

                                Cmd.ExecuteNonQuery()

                            Else
                                Sqltran.Rollback()
                                Dim script As String = "alert('Please Enter Reason for Material Return..!!');"
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

                            End If

                            Qry = "JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION_Proc_Ashish"
                            Cmd = New SqlCommand(Qry, Obj.Connection())
                            Cmd.CommandType = CommandType.StoredProcedure

                            Cmd.Transaction = Sqltran


                            list = ListOfElcosures(chbEnclosures, txtEnclosures)
                            Cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = RequestId
                            Cmd.Parameters.Add("@GrNo", SqlDbType.VarChar, 30).Value = GrNo.Text
                            Cmd.Parameters.Add("@GrDate", SqlDbType.VarChar, 20).Value = IIf(String.IsNullOrEmpty(GrDate.Text), DBNull.Value, GrDate.Text) ' (GrDate.Text = "" ? null : GrDate.Text)
                            Cmd.Parameters.Add("@FreightValue", SqlDbType.Decimal).Value = IIf(String.IsNullOrEmpty(txtFreightValue.Text), 0, txtFreightValue.Text) '//Convert.ToDecimal((txtAmount.Text == "" ? "0" : txtAmount.Text));
                            Cmd.Parameters.Add("@FreightPaidBy", SqlDbType.VarChar, 50).Value = ddlFreight.SelectedItem.Text
                            Cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 20).Value = Session("EmpCode")
                            Cmd.Parameters.Add("@PendingAt", SqlDbType.VarChar, 50).Value = "R-03481,P-03055"
                            Cmd.Parameters.Add("@Enclosures", SqlDbType.VarChar, 500).Value = list
                            Cmd.Parameters.Add("@SrNo", SqlDbType.VarChar, 5).Value = ""
                            Cmd.ExecuteNonQuery()




                            '//JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION_Proc

                        Catch ex As Exception
                            Sqltran.Rollback()
                            script = "alert('" + ex.Message + "');"
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

                        End Try

                    Next





                    Sqltran.Commit()
                    'Sqltran.Rollback()
                    script = "alert('MR Request has been generated. Now It has been sent for authorization..!!');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

                    GridView2.DataSource = Nothing
                    GridView2.DataBind()
                    pnlGridview2.Visible = False
                    SendMail()
                    ' SendMailLogistics(RequestId)
                Else
                    Sqltran.Rollback()
                    script = "alert('Please click Refresh button to add details before saving data..!! ');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

                End If




            Else
                Sqltran.Rollback()
                script = "alert('Please Select appropriate Reason from the list..!!');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
                Exit Sub
            End If

        Catch ex As Exception
            Sqltran.Rollback()
            script = "alert('No record added..!! Some error might have occured..!!');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
        End Try




      

    End Sub

    Protected Sub PreviousSanctionNotes(sqltran As SqlTransaction, con As SqlConnection)

        ' In order cancel previous request id if pending.

        Sql = "SELECT AuthStatus FROM dbo.jct_ops_material_request WHERE RequestID=" & txtSanctionID.Text
        Dim status As String = ObjFun.FetchValue(Sql).ToString()

        If (status = "C" Or status = "P") Then

            Try
                Sql = "JCT_OPS_SANCTIONNOTES_IMPORT_ACTION"
                Dim cmd As SqlCommand = New SqlCommand(Sql, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@REQUESTID", SqlDbType.VarChar, 10).Value = txtSanctionID.Text
                cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 20).Value = Session("EmpCode")
                cmd.Transaction = sqltran
                cmd.ExecuteNonQuery()

            Catch ex As Exception

                Dim script As String = "alert('" + ex.Message + "');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
                Throw ex

            End Try


        End If

    End Sub
    'Private Sub SendMail()
    '    Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String


    '    Dim sb As New StringBuilder()
    '    Dim email1, email2 As String
    '    Dim FlagAuth As String = ListOfConcernedDepts(chbReasons)
    '    FlagAuth = FlagAuth.Split(",")(0)
    '    Sql = "Select e_mailid from mistel where empcode='" + FlagAuth + "'"
    '    If (ObjFun.CheckRecordExistInTransaction(Sql)) Then

    '        email1 = ObjFun.FetchValue(Sql)

    '    Else

    '        email1 = "jatindutta@jctltd.com"

    '    End If

    '    Sql = "Select e_mailid from mistel where empcode='" + Session("EmpCode") + "'"
    '    If (ObjFun.CheckRecordExistInTransaction(Sql)) Then

    '        email2 = ObjFun.FetchValue(Sql)

    '    Else

    '        email2 = "jatindutta@jctltd.com"

    '    End If

    '    sb.AppendLine("<html>")
    '    sb.AppendLine("<head>")
    '    sb.AppendLine("<style type=""text/css"">")
    '    sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
    '    sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
    '    sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
    '    sb.AppendLine("</style>")
    '    sb.AppendLine("</head>")



    '    ' sb.Append("<head>");
    '    sb.AppendLine("Hi,<br/><br/>")
    '    sb.AppendLine("Material Return Request has been generated in OPS.<br/><br/>")
    '    sb.AppendLine("RequestID for your request is : " + ViewState("RequestID") + " <br/><br/>")
    '    sb.AppendLine("Details are Shown below : <br/><br/>")
    '    sb.AppendLine("<table class=gridtable>")
    '    sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")
    '    'Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")
    '    Sql = "JCT_OPS_SANCTION_PENDING_AT_MATERIAL_RETURN"
    '    Dim cmd As SqlCommand = New SqlCommand(Sql, Obj.Connection())
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState("RequestID")
    '    Dim Dr As SqlDataReader = cmd.ExecuteReader()
    '    If (Dr.HasRows) Then
    '        While (Dr.Read())
    '            ViewState("PendingAt") = ""
    '            If (Dr(6).ToString = "" Or Dr(6).ToString() = "CEO") Then
    '                ViewState("PendingAt") = Dr(6).ToString()
    '                sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td> CEO </td> </tr> ")
    '            End If
    '            Sql = "Select empname from jct_empmast_base where active='Y' and  empcode='" + Dr(6).ToString().Split(",")(0) + "'"
    '            Dim empname As String = ""
    '            Dim obj2 As Connection = New Connection
    '            cmd = New SqlCommand(Sql, obj2.Connection())
    '            Dim dr1 As SqlDataReader = cmd.ExecuteReader
    '            If (dr1.HasRows()) Then

    '                While (dr1.Read)

    '                    empname = dr1(0).ToString

    '                End While

    '            End If
    '            dr1.Close()
    '            obj2.ConClose()
    '            sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td>" & Dr(5).ToString & "</td>  <td>" & empname & "</td> </tr> ")
    '        End While

    '    End If
    '    Dr.Close()
    '    sb.AppendLine("</table>")

    '    sb.AppendLine("<br /><br/>")
    '    sb.AppendLine("Detailed Description (Entered by Marketing Executive) : " + txtDescription.Text.ToUpper())
    '    sb.AppendLine("<br /><br />")
    '    sb.AppendLine("Reason : " + eReasonslist)
    '    sb.AppendLine("<br /><br/>")
    '    sb.Append("<a href='http://testerp/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details... </a><br />")

    '    sb.AppendLine("</table><br />")

    '    sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
    '    sb.AppendLine("Thank you<br />")
    '    sb.AppendLine("</html>")


    '    body = sb.ToString()
    '    from = "noreply@jctltd.com"
    '    If (ViewState("PendingAt") = "") Then
    '        [to] = email1 + "," + email2
    '        '[to] = "jatindutta@jctltd.com"
    '    Else
    '        [to] = "charanamrit.singh@jctltd.com,mikeops@jctltd.com," + email2
    '    End If

    '    bcc = "jatindutta@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com"
    '    '[to] = ("jatindutta@jctltd.com")
    '    'Email Address of Receiver
    '    'cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
    '    subject = " Material Return Request - " + ViewState("Customer")
    '    Dim mail As New MailMessage()
    '    mail.From = New MailAddress(from)
    '    If [to].Contains(",") Then
    '        Dim tos As String() = [to].Split(","c)
    '        For i As Integer = 0 To tos.Length - 1
    '            mail.[To].Add(New MailAddress(tos(i)))
    '        Next
    '    Else
    '        mail.[To].Add(New MailAddress([to]))
    '    End If

    '    If Not String.IsNullOrEmpty(bcc) Then
    '        If bcc.Contains(",") Then
    '            Dim bccs As String() = bcc.Split(","c)
    '            For i As Integer = 0 To bccs.Length - 1
    '                mail.Bcc.Add(New MailAddress(bccs(i)))
    '            Next
    '        Else
    '            mail.Bcc.Add(New MailAddress(bcc))
    '        End If
    '    End If
    '    'If Not String.IsNullOrEmpty(cc) Then
    '    '    If cc.Contains(",") Then
    '    '        Dim ccs As String() = cc.Split(","c)
    '    '        For i As Integer = 0 To ccs.Length - 1
    '    '            mail.CC.Add(New MailAddress(ccs(i)))
    '    '        Next
    '    '    Else
    '    '        mail.CC.Add(New MailAddress(bcc))
    '    '    End If
    '    '    mail.CC.Add(New MailAddress(cc))
    '    'End If

    '    mail.Subject = subject
    '    mail.Body = body
    '    mail.IsBodyHtml = True
    '    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
    '    Dim SmtpMail As New SmtpClient("exchange2007")

    '    'SmtpMail.SmtpServer = "exchange2007";
    '    SmtpMail.Send(mail)
    '    'return mail;
    'End Sub

    



    Private Sub SendMail()
        Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String


        Dim sb As New StringBuilder()
        Dim email1, email2 As String





        'Comented by Ashish Sharma on 27May 2015 to include dynamically added person for authorization.... Dim FlagAuth As String = ListOfConcernedDepts(chbReasons)
        'Comented by Ashish Sharma on 27May 2015 to include dynamically added person for authorization.... FlagAuth = FlagAuth.Split(",")(0)
        'Comented by Ashish Sharma on 27May 2015 to include dynamically added person for authorization.... Sql = "Select e_mailid from mistel where empcode='" + FlagAuth + "'"
        Sql = "Select distinct e_mailid from mistel a INNER JOIN JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b ON a.empcode=b.EMPCODE AND b.ID='" + ViewState("RequestID") + "' AND USERLEVEL=1 AND STATUS IS null"
        If (ObjFun.CheckRecordExistInTransaction(Sql)) Then

            email1 = ObjFun.FetchValue(Sql)

        Else

            email1 = "ashish@jctltd.com"

        End If

        Sql = "Select e_mailid from mistel where empcode='" + Session("EmpCode") + "'"
        If (ObjFun.CheckRecordExistInTransaction(Sql)) Then

            email2 = ObjFun.FetchValue(Sql)

        Else

            email2 = "ashish@jctltd.com"

        End If

        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<style type=""text/css"">")
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head>")



        ' sb.Append("<head>");
        sb.AppendLine("Hi,<br/><br/>")
        sb.AppendLine("Material Return Request has been generated in OPS.<br/><br/>")
        sb.AppendLine("RequestID for your request is : " + ViewState("RequestID") + " <br/><br/>")


        sb.AppendLine("<h2>Request Type : " + ddlRequestType.SelectedItem.Text + " <br/><br/></h2>")
        sb.AppendLine("Details are Shown below : <br/><br/>")
        sb.AppendLine("<table class=gridtable>")
        'Comented by 17Nov 2015 sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th><th> Invoice Date </th> <th> Return Qty</th>  <th> Auth. Pending At</th> <th> Freight Paid By</th> <th> Sale Price(Per Unit)</th> <th>Value Involved</th> </tr>")
        sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th><th> Invoice Date </th> <th> Return Qty</th>  <th> Auth. Pending At</th> <th> Freight Paid By</th>  </tr>")
        'Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")
        Sql = "JCT_OPS_SANCTION_PENDING_AT_MATERIAL_RETURN"
        Dim cmd As SqlCommand = New SqlCommand(Sql, Obj.Connection())
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState("RequestID")
        Dim Dr As SqlDataReader = cmd.ExecuteReader()
        If (Dr.HasRows) Then
            While (Dr.Read())
                ViewState("PendingAt") = ""
                If (Dr(6).ToString = "" Or Dr(6).ToString() = "CEO") Then
                    ViewState("PendingAt") = Dr(6).ToString()
                    sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td> <td> " & Dr(8).ToString() & " </td><td> CEO </td><td>" & Dr("FreightPaidBy").ToString & " </tr> ")
                End If
                Sql = "Select empname from jct_empmast_base where active='Y' and  empcode='" + Dr(6).ToString().Split(",")(0) + "'"
                Dim empname As String = ""
                Dim obj2 As Connection = New Connection
                cmd = New SqlCommand(Sql, obj2.Connection())
                Dim dr1 As SqlDataReader = cmd.ExecuteReader
                If (dr1.HasRows()) Then

                    While (dr1.Read)

                        empname = dr1(0).ToString

                    End While

                End If
                dr1.Close()
                obj2.ConClose()
                sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr(8).ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>" & empname & "</td> <td>" & Dr("FreightPaidBy").ToString & " </td> </tr> ")
            End While

        End If
        Dr.Close()
        sb.AppendLine("</table>")




        sb.AppendLine("<br/><br/>")


        sb.AppendLine("<b>Freight Paid by :-</b> " + ddlFreight.SelectedItem.Text)


        sb.AppendLine("<br/><br/>")


        sb.AppendLine("<b>Freight Type :- </b>" + ddlFreightType.SelectedItem.Text)





        sb.AppendLine("<br/><br/>")


        sb.AppendLine("<b>Action To Be Taken :-</b> " + ddlActionToBeTaken.SelectedItem.Text)

        '27 Jan 2016
           sb.AppendLine("<b>Tentative Rate :-</b> " + txtTentative.Text)

        '27 Jan 2016

        sb.AppendLine("<br/><br/>")










        sb.AppendLine("<br /><br/>")
        sb.AppendLine("<b>Freight Value:</b> " + txtFreightValue.Text)
        sb.AppendLine("<br /><br />")
        sb.AppendLine("<b>Detailed Description (Entered by Marketing Executive) :</b> " + txtDescription.Text.ToUpper())
        sb.AppendLine("<br /><br />")
        sb.AppendLine("<b>Reason : </b>" + eReasonslist)
        sb.AppendLine("<br /><br/>")
        sb.Append("<a href='http://testerp/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details... </a><br />")

        sb.AppendLine("</table><br />")

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br />")
        sb.AppendLine("</html>")


        body = sb.ToString()
        from = "noreply@jctltd.com"
        If (ViewState("PendingAt") = "") Then
            [to] = email1 + "," + email2

            '   body = body + "To " + [to]
        Else
            [to] = "ashish@jctltd.com," + email2
            '  body = body + "To " + [to]
        End If

        '   [to] = "ashish@jctltd.com"




        ' body = body + "To " + [to]




        bcc = "harendra@jctltd.com,rbaksshi@jctltd.com,hiren@jctltd.com,sandeepr@jctltd.com,hitesh@jctltd.com"
        '[to] = ("jatindutta@jctltd.com")
        'Email Address of Receiver
        'cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
        subject = " Material Return Request - " + ViewState("Customer")




        Dim mail As New MailMessage()

        mail.Body = body '+ " To Lsit " + [to] + " Bcc" + bcc.ToString()



        '[to] = "sandeepr@jctltd.com"
        'cc = "sandeepr@jctltd.com"
        'bcc = "sandeepr@jctltd.com"


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

    

        mail.Subject = subject


        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2k7")


        SmtpMail.Send(mail)

    End Sub



    Protected Sub chbSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim cbHeader As CheckBox = DirectCast(GridView2.HeaderRow.FindControl("ChbSelectAll"), CheckBox)
        If cbHeader.Checked = True Then
            For k As Integer = 0 To GridView2.Rows.Count - 1
                Dim myCheckBox As CheckBox = DirectCast(GridView2.Rows(k).FindControl("ChbSelect"), CheckBox)
                myCheckBox.Checked = True
            Next
        ElseIf cbHeader.Checked = False Then
            For k As Integer = 0 To GridView2.Rows.Count - 1
                Dim myCheckBox As CheckBox = DirectCast(GridView2.Rows(k).FindControl("ChbSelect"), CheckBox)
                myCheckBox.Checked = False
            Next
        End If

    End Sub

    Protected Sub txtSanctionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSanctionID.TextChanged

        '    ChechSanctionID()

    End Sub

    Protected Function ChechSanctionID() As Boolean
        img.Visible = True

        Sql = "SELECT * FROM dbo.Jct_Ops_SanctionNote_HDR where SanctionNoteID='" + txtSanctionID.Text + "'"
        If ObjFun.CheckRecordExistInTransaction(Sql) = True Then
            img.ImageUrl = "~/Image/Availabilitytrue.png"
            Return True
        Else
            img.ImageUrl = "~/Image/AvailabilityFalse.png"
            script = "alert('Sanction ID entered is found unauthorized or incorrect..!!');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
            Return False
            ' lnkSave.Visible = False
        End If
    End Function

    Protected Sub txtCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged

        Try
            txtCustomer.Text = txtCustomer.Text.Split("~")(1).ToString()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub chbReasons_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbReasons.SelectedIndexChanged
        For i As Integer = 0 To chbReasons.Items.Count - 1
            If chbReasons.Items(i).Selected Then

                If chbReasons.Items(i).Text = "Other" Then

                    txtOtherReason.Visible = True
                End If

            Else

                If chbReasons.Items(i).Text = "Other" Then

                    txtOtherReason.Visible = False

                End If

            End If
        Next




    End Sub

    Protected Sub txtReturnQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)


        Try

            Dim ReturnQty As TextBox = CType(sender, TextBox)
            Dim gridRow As GridViewRow = CType(ReturnQty.Parent.Parent, GridViewRow)

            Dim InvoiceQty As Label = DirectCast(gridRow.FindControl("lblQty"), Label)
            Dim ValueInvolved As Label = DirectCast(gridRow.FindControl("lblValueInvolved"), Label)
            Dim SalePrice As Label = DirectCast(gridRow.FindControl("lblSalePrice"), Label)
            ReturnQty.Text = IIf(String.IsNullOrEmpty(ReturnQty.Text), "0", ReturnQty.Text)


            If (Convert.ToDecimal(ReturnQty.Text) > Convert.ToDecimal(InvoiceQty.Text)) Then
                ReturnQty.Text = ""
                script = "alert('Return Qty cannot be greater than invoice qty..!!');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

                Exit Sub
            End If
            ValueInvolved.Text = Convert.ToDecimal(ReturnQty.Text) * Convert.ToDecimal(SalePrice.Text)
        Catch ex As Exception



        End Try



    End Sub

    Protected Sub ddlPlant_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPlant.SelectedIndexChanged
        chbReasons.DataSourceID = "SqlDataSource1"
        chbReasons.DataBind()
    End Sub

    'Protected Sub grdAuthorize_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdAuthorize.SelectedIndexChanged



    'End Sub

    Protected Sub cmdTransport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTransport.Click

        Response.Redirect("MaterialReturnDetail.aspx")

        'Sql = "Select requestid as ID from jct_ops_material_request where AuthStatus='A' and userid='" + Session("EmpCode") + "'"
        'Dim cmd As SqlCommand = New SqlCommand(Sql, Obj.Connection())
        'Dim dr As SqlDataReader = cmd.ExecuteReader()

        'If (dr.HasRows) Then

        '    While (dr.Read())

        '        pnlGrNo.Visible = True
        '        pnlGridview2.Visible = False
        '        lnkFetch.Enabled = False
        '        Qry = "EXEC JCT_OPS_MATERIAL_RETURN_FETCH_ADD_GR_NO"
        '        ObjFun.FillGrid(Qry, grdGrNo)
        '        Dim script As String = "alert('Your Sanction Note for Material Return - " + dr("id").ToString() + " has been authorized and you can now enter Transport details in the list shown.!!');"
        '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)


        '    End While

        'Else

        '    script = "alert('No Data Available. Possible reasosn are : Your request is still pending or there is no request generated by you.');"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

        'End If
    End Sub

    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand



        Try
            Dim gvr As GridViewRow = DirectCast(DirectCast(e.CommandSource, ImageButton).NamingContainer, GridViewRow)

            Dim rowIndex As Integer = gvr.RowIndex

            Dim InvoiceNo As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(1).FindControl("txtInvocieNo"), TextBox)
            Dim ReturnQty As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(3).FindControl("txtReturnQty"), TextBox)
            Dim Bales As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(4).FindControl("txtbales"), TextBox)
            Dim Qty As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(5).FindControl("txtQty"), TextBox)
            Dim ItemNo As Label = DirectCast(GridView2.Rows(rowIndex).Cells(6).FindControl("lblItemNo"), Label)
            Dim InvoiceDt As Label = DirectCast(GridView2.Rows(rowIndex).Cells(7).FindControl("lblInvoiceDt"), Label)
            Dim Customer As Label = DirectCast(GridView2.Rows(rowIndex).Cells(8).FindControl("lblCustomer"), Label)
            Dim SalesPerson As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblSalesPerson"), Label)

            Dim GrNo As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(12).FindControl("txtGrNo"), TextBox)
            Dim GrDate As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(13).FindControl("txtGrDate"), TextBox)

            Dim FreightTypeValue As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(14).FindControl("txtFreightTypeValue"), TextBox)





            Dim SalePrice As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblSalePrice"), Label)
            Dim ValueInvolved As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblValueInvolved"), Label)



            Dim GrNoReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(rowIndex).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
            Dim GrDateReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(rowIndex).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


            If ddlRequestType.SelectedItem.Text = "Sale Return" Then
                GrNoReqdValid.Enabled = False
                GrDateReqdValid.Enabled = False
            End If











            If ddlFreightAppliedTo.SelectedItem.Text = "Combined Value" Then
                FreightTypeValue.Enabled = False
                txtFreightValue.Enabled = True
                ReqdValidFreightValue.Enabled = True
                'txtFreightValue.Text = "0"
                'FreightTypeValue.Text = "0"
                GrDate.Enabled = False
                GrNo.Enabled = False
            Else
                FreightTypeValue.Enabled = True
                txtFreightValue.Enabled = False
                ReqdValidFreightValue.Enabled = False
                GrDate.Enabled = True
                GrNo.Enabled = True
                'txtFreightValue.Text = "0"
            End If


            'Dim GrDate As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(11).FindControl("txtGrDate"), TextBox)
            'FreightValue()

            If e.CommandName = "Remove" Then


                Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                dt.Rows.RemoveAt(rowIndex)
                GridView2.DataSource = dt
                GridView2.DataBind()
                ViewState("data") = dt



                For i = 0 To GridView2.Rows.Count - 1
                    FreightTypeValue = DirectCast(GridView2.Rows(i).Cells(14).FindControl("txtFreightTypeValue"), TextBox)

                    GrNoReqdValid = DirectCast(GridView2.Rows(i).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
                    GrDateReqdValid = DirectCast(GridView2.Rows(i).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


                    If ddlRequestType.SelectedItem.Text = "Sale Return" Then
                        GrNoReqdValid.Enabled = False
                        GrDateReqdValid.Enabled = False
                    End If
                Next

                'FreightTypeValue = DirectCast(GridView2.Rows(rowIndex).Cells(14).FindControl("txtFreightTypeValue"), TextBox)
                'GrNoReqdValid = DirectCast(GridView2.Rows(rowIndex).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
                'GrDateReqdValid = DirectCast(GridView2.Rows(rowIndex).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


                'If ddlRequestType.SelectedItem.Text = "Material Return" Then
                '    GrNoReqdValid.Enabled = False
                '    GrDateReqdValid.Enabled = False
                'End If








            ElseIf (e.CommandName = "Refresh") Then

                ViewState("RefreshFlag") = 1
                If ViewState("CurrentTable") IsNot Nothing Then
                    Dim dtCurrentTable As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)

                    Dim drCurrentRow As DataRow = Nothing

                    'Sql = "jct_ops_sales_return_MR"
                    Sql = "JCT_OPS_MR_Fetch_Invoice_Detail"
                    Dim cmd As New SqlCommand(Sql, Obj.Connection())
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0

                    cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20).Value = InvoiceNo.Text


                    Dim dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.HasRows Then
                        While dr.Read()

                            Dim rowindex__2 As Integer = dtCurrentTable.Rows.Count - 1
                            dtCurrentTable.Rows(rowindex__2).BeginEdit()
                            dtCurrentTable.Rows(rowindex__2)("InvoiceNo") = dr("invoice_no").ToString()
                            dtCurrentTable.Rows(rowindex__2)("ReturnQty") = String.Empty
                            dtCurrentTable.Rows(rowindex__2)("Bales") = String.Empty
                            dtCurrentTable.Rows(rowindex__2)("Qty") = dr("invoice_qty").ToString()
                            dtCurrentTable.Rows(rowindex__2)("ItemNo") = dr("item_no").ToString()
                            dtCurrentTable.Rows(rowindex__2)("InvoiceDt") = dr("invoice_dt").ToString()
                            dtCurrentTable.Rows(rowindex__2)("Customer") = dr("cust_name").ToString()
                            dtCurrentTable.Rows(rowindex__2)("SalesPerson") = IIf(String.IsNullOrEmpty(dr("SalesPersonCode").ToString()), ddlSalesPerson.SelectedItem.Value, dr("SalesPersonCode").ToString())

                            dtCurrentTable.Rows(rowindex__2)("GrNo") = GrNo.Text
                            dtCurrentTable.Rows(rowindex__2)("GrDate") = GrDate.Text
                            dtCurrentTable.Rows(rowindex__2)("FreightValue") = GrDate.Text

                            dtCurrentTable.Rows(rowindex__2)("SalePrice") = dr("SalePrice").ToString()
                            dtCurrentTable.Rows(rowindex__2)("ValueInvolved") = 0


                            'dtCurrentTable.Rows(rowindex__2)("GrNo") = dr("GrNo").ToString()
                            'dtCurrentTable.Rows(rowindex__2)("GrDate") = dr("GrDate").ToString()

                            dtCurrentTable.Rows(rowindex__2).EndEdit()
                            dtCurrentTable.AcceptChanges()


                            ' Add New Row In Datatable
                            drCurrentRow = dtCurrentTable.NewRow()
                            drCurrentRow("InvoiceNo") = String.Empty
                            drCurrentRow("ReturnQty") = String.Empty
                            drCurrentRow("Bales") = String.Empty
                            drCurrentRow("Qty") = String.Empty
                            drCurrentRow("ItemNo") = String.Empty
                            drCurrentRow("InvoiceDt") = String.Empty
                            drCurrentRow("Customer") = String.Empty
                            drCurrentRow("SalesPerson") = String.Empty

                            drCurrentRow("GrNo") = String.Empty
                            drCurrentRow("GrDate") = String.Empty
                            drCurrentRow("FreightValue") = String.Empty
                            drCurrentRow("SalePrice") = String.Empty
                            drCurrentRow("ValueInvolved") = String.Empty

                            dtCurrentTable.Rows.Add(drCurrentRow)

                            'FreightTypeValue = DirectCast(GridView2.Rows(rowindex__2).Cells(14).FindControl("txtFreightTypeValue"), TextBox)
                            'GrNoReqdValid = DirectCast(GridView2.Rows(rowindex__2).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
                            'GrDateReqdValid = DirectCast(GridView2.Rows(rowindex__2).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


                            If ddlRequestType.SelectedItem.Text = "Sale Return" Then
                                GrNoReqdValid.Enabled = False
                                GrDateReqdValid.Enabled = False
                            End If

                        End While
                    End If



                    GridView2.DataSource = dtCurrentTable 'ViewState("CurrentTable")
                    GridView2.DataBind()






                End If


















            End If

            ddlFreightAppliedTo_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            script = "alert('" + ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
        End Try



    End Sub

    Private Sub SetInitialRow()
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("InvoiceNo", GetType(String)))
            dt.Columns.Add(New DataColumn("ReturnQty", GetType(String)))
            dt.Columns.Add(New DataColumn("Bales", GetType(String)))
            dt.Columns.Add(New DataColumn("Qty", GetType(String)))
            dt.Columns.Add(New DataColumn("ItemNo", GetType(String)))
            dt.Columns.Add(New DataColumn("InvoiceDt", GetType(String)))
            dt.Columns.Add(New DataColumn("Customer", GetType(String)))
            dt.Columns.Add(New DataColumn("SalesPerson", GetType(String)))

            dt.Columns.Add(New DataColumn("GrNo", GetType(String)))
            dt.Columns.Add(New DataColumn("GrDate", GetType(String)))
            dt.Columns.Add(New DataColumn("FreightValue", GetType(String)))

            dt.Columns.Add(New DataColumn("SalePrice", GetType(String)))
            dt.Columns.Add(New DataColumn("ValueInvolved", GetType(String)))

            dr = dt.NewRow()
            dr("InvoiceNo") = String.Empty
            dr("ReturnQty") = String.Empty
            dr("Bales") = String.Empty
            dr("Qty") = String.Empty
            dr("ItemNo") = String.Empty
            dr("InvoiceDt") = String.Empty
            dr("Customer") = String.Empty
            dr("SalesPerson") = String.Empty

            dr("GrNo") = String.Empty
            dr("GrDate") = String.Empty

            dr("FreightValue") = String.Empty
            dr("SalePrice") = String.Empty
            dr("ValueInvolved") = String.Empty

            dt.Rows.Add(dr)
            'dr = dt.NewRow();

            'Store the DataTable in ViewState
            ViewState("CurrentTable") = dt

            'Sql = "Select 'BY Mill' as FreightBy, '" + dr("InvoiceNo") + "'  as InvoiceNo , '" + dr("ReturnQty") + "' as ReturnQty,'" + dr("Bales") + "' as Bales ,'" + dr("Qty") + "' as Qty ,'" + dr("ItemNo") + "' as ItemNo,'" + dr("InvoiceDt") + "' as InvoiceDt,'" + dr("Customer") + "' as Customer,'" + dr("SalesPerson") + "' as SalesPerson"
            'Dim cmd1 As SqlCommand = New SqlCommand(Sql, obj2.Connection())
            'Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
            'Dim ds As DataSet = New DataSet
            'da.Fill(ds)
            'GridView2.DataSource = ds.Tables(0)
            'GridView2.DataBind()
            GridView2.DataSource = dt 'ViewState("CurrentTable")
            GridView2.DataBind()

            Dim FreightTypeValue As TextBox = DirectCast(GridView2.Rows(0).Cells(14).FindControl("txtFreightTypeValue"), TextBox)
            Dim GrDate As TextBox = DirectCast(GridView2.Rows(0).Cells(13).FindControl("txtGrDate"), TextBox)
            Dim GrNo As TextBox = DirectCast(GridView2.Rows(0).Cells(12).FindControl("txtGrNo"), TextBox)


            Dim GrNoReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(0).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
            Dim GrDateReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(0).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


            If ddlRequestType.SelectedItem.Text = "Sale Return" Then
                GrNoReqdValid.Enabled = False
                GrDateReqdValid.Enabled = False
            End If




            If ddlFreightAppliedTo.SelectedItem.Text = "Combined Value" Then
                FreightTypeValue.Text = 0
                FreightTypeValue.Enabled = False
                txtFreightValue.Enabled = True
                txtFreightValue.Text = "0"
                ReqdValidFreightValue.Enabled = True
                GrDate.Enabled = False
                GrNo.Enabled = False
            Else
                FreightTypeValue.Enabled = True
                txtFreightValue.Enabled = False
                ReqdValidFreightValue.Enabled = False
                GrDate.Enabled = True
                GrNo.Enabled = True
            End If

        Catch ex As Exception
            script = "alert('" + ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
        End Try

    End Sub

    Private Sub AddNewRowToGrid()

        Try
            Dim rowIndex As Integer = 0

            If ViewState("CurrentTable") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 0 To dtCurrentTable.Rows.Count - 1

                        Dim InvoiceNo As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(1).FindControl("txtInvocieNo"), TextBox)
                        Dim ReturnQty As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(3).FindControl("txtReturnQty"), TextBox)
                        Dim Bales As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(4).FindControl("txtbales"), TextBox)
                        Dim Qty As Label = DirectCast(GridView2.Rows(rowIndex).Cells(5).FindControl("lblQty"), Label)
                        Dim ItemNo As Label = DirectCast(GridView2.Rows(rowIndex).Cells(6).FindControl("lblItemNo"), Label)
                        Dim InvoiceDt As Label = DirectCast(GridView2.Rows(rowIndex).Cells(7).FindControl("lblInvoiceDt"), Label)
                        Dim Customer As Label = DirectCast(GridView2.Rows(rowIndex).Cells(8).FindControl("lblCustomer"), Label)
                        Dim SalesPerson As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblSalesPerson"), Label)


                        Dim GrNo As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(12).FindControl("txtGrNo"), TextBox)
                        Dim GrDate As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(13).FindControl("txtGrDate"), TextBox)
                        Dim FreightTypeValue As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(14).FindControl("txtFreightTypeValue"), TextBox)

                        Dim SalePrice As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblSalePrice"), Label)
                        Dim ValueInvolved As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblValueInvolved"), Label)

                        Dim GrNoReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(rowIndex).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
                        Dim GrDateReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(rowIndex).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


                        If ddlRequestType.SelectedItem.Text = "Sale Return" Then
                            GrNoReqdValid.Enabled = False
                            GrDateReqdValid.Enabled = False
                        End If

                        

                        If ddlFreightAppliedTo.SelectedItem.Text = "Combined Value" Then
                            FreightTypeValue.Enabled = False
                            txtFreightValue.Enabled = True
                            txtFreightValue.Text = "0"
                            FreightTypeValue.Text = "0"
                            ReqdValidFreightValue.Enabled = True
                            GrDate.Enabled = False
                            GrNo.Enabled = False
                        Else
                            FreightTypeValue.Enabled = True
                            txtFreightValue.Enabled = False
                            txtFreightValue.Text = "0"
                            ReqdValidFreightValue.Enabled = False
                            GrDate.Enabled = True
                            GrNo.Enabled = True
                        End If




                        drCurrentRow = dtCurrentTable.NewRow()

                        dtCurrentTable.Rows(i)("InvoiceNo") = InvoiceNo.Text
                        dtCurrentTable.Rows(i)("ReturnQty") = ReturnQty.Text
                        dtCurrentTable.Rows(i)("Bales") = Bales.Text
                        dtCurrentTable.Rows(i)("Qty") = Qty.Text
                        dtCurrentTable.Rows(i)("ItemNo") = ItemNo.Text
                        dtCurrentTable.Rows(i)("InvoiceDt") = InvoiceDt.Text
                        dtCurrentTable.Rows(i)("Customer") = Customer.Text
                        dtCurrentTable.Rows(i)("SalesPerson") = SalesPerson.Text


                        dtCurrentTable.Rows(i)("GrNo") = GrNo.Text
                        dtCurrentTable.Rows(i)("GrDate") = SalesPerson.Text

                        dtCurrentTable.Rows(i)("FreightValue") = FreightTypeValue.Text






                        dtCurrentTable.Rows(i)("SalePrice") = FreightTypeValue.Text
                        dtCurrentTable.Rows(i)("ValueInvolved") = FreightTypeValue.Text

                        dtCurrentTable.Rows.Add(drCurrentRow)
                        rowIndex += 1
                    Next
                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("CurrentTable") = dtCurrentTable

                    ' Dim i As Int16
                    Dim ColName As String = ""
                    Dim FInalSql As String = ""
                    For i = 0 To dtCurrentTable.Columns.Count
                        ColName = dtCurrentTable.Columns(i).ColumnName.ToString()
                        If i = dtCurrentTable.Columns.Count Then

                            FInalSql = FInalSql + "dtCurrentTable.Columns(" + ColName + ") as " + ColName
                        Else
                            'ColName = dtCurrentTable.Columns(i).ColumnName.ToString() + ","
                            FInalSql = FInalSql + "dtCurrentTable.Columns(" + ColName + ") as " + ColName + ","
                        End If
                    Next

                    'Comented on 27-Oct-2015 Sql = "Select '" + dtCurrentTable.Columns("InvoiceNo").ToString() + "' as InvoiceNo,'" + dtCurrentTable.Columns("ReturnQty").ToString() + "' as ReturnQty,'" + dtCurrentTable.Columns("Bales").ToString() + "' as Bales,'" + dtCurrentTable.Columns("Qty").ToString() + "','" + dtCurrentTable.Columns("ItemNo").ToString() + "' as ItemNo,'" + dtCurrentTable.Columns("InvoiceDt").ToString() + "' as InvoiceDt,'" + dtCurrentTable.Columns("Customer").ToString() + "' as Customer,'" + dtCurrentTable.Columns("SalesPerson").ToString() + "' as SalesPerson,'" + dtCurrentTable.Columns("GrNo").ToString() + "' as GrNo,'" + dtCurrentTable.Columns("GrDate").ToString() + "' as GrDate,'" + dtCurrentTable.Columns("FreightValue").ToString() + "' as FreightValue"
                    'Sql = "Select '" + dtCurrentTable.Columns("InvoiceNo").ToString() + "' as InvoiceNo,'" + dtCurrentTable.Columns("ReturnQty").ToString() + "' as ReturnQty,'" + dtCurrentTable.Columns("Bales").ToString() + "' as Bales,'" + dtCurrentTable.Columns("Qty").ToString() + "','" + dtCurrentTable.Columns("ItemNo").ToString() + "' as ItemNo,'" + dtCurrentTable.Columns("InvoiceDt").ToString() + "' as InvoiceDt,'" + dtCurrentTable.Columns("Customer").ToString() + "' as Customer,'" + dtCurrentTable.Columns("SalesPerson").ToString() + "' as SalesPerson,'" + dtCurrentTable.Columns("GrNo").ToString() + "' as GrNo,'" + dtCurrentTable.Columns("GrDate").ToString() + "' as GrDate,'" + dtCurrentTable.Columns("FreightValue").ToString() + "' as FreightValue"
                    Sql = "Select " + FInalSql
                    Dim cmd As SqlCommand = New SqlCommand(Sql, Obj.Connection())
                    Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    GridView2.DataSource = ds.Tables(0) 'dtCurrentTable
                    GridView2.DataBind()
                End If
            Else
                Response.Write("ViewState is null")
            End If

            'Set Previous Data on Postbacks

            SetPreviousData()
        Catch ex As Exception
            script = "alert('" + ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
        End Try


    End Sub


    Private Sub SetPreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("CurrentTable") IsNot Nothing Then

                Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1

                        Dim InvoiceNo As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(1).FindControl("txtInvocieNo"), TextBox)
                        Dim ReturnQty As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(3).FindControl("txtReturnQty"), TextBox)
                        Dim Bales As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(4).FindControl("txtbales"), TextBox)
                        Dim Qty As Label = DirectCast(GridView2.Rows(rowIndex).Cells(5).FindControl("lblQty"), Label)
                        Dim ItemNo As Label = DirectCast(GridView2.Rows(rowIndex).Cells(6).FindControl("lblItemNo"), Label)
                        Dim InvoiceDt As Label = DirectCast(GridView2.Rows(rowIndex).Cells(7).FindControl("lblInvoiceDt"), Label)
                        Dim Customer As Label = DirectCast(GridView2.Rows(rowIndex).Cells(8).FindControl("lblCustomer"), Label)
                        Dim SalesPerson As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblSalesPerson"), Label)



                        Dim GrNo As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(12).FindControl("txtGrNo"), TextBox)
                        Dim GrDate As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(13).FindControl("txtGrDate"), TextBox)

                        Dim FreightTypeValue As TextBox = DirectCast(GridView2.Rows(rowIndex).Cells(14).FindControl("txtFreightTypeValue"), TextBox)

                        Dim GrNoReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(rowIndex).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
                        Dim GrDateReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(rowIndex).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


                        If ddlRequestType.SelectedItem.Text = "Sale Return" Then
                            GrNoReqdValid.Enabled = False
                            GrDateReqdValid.Enabled = False
                        End If



                        Dim SalePrice As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblSalePrice"), Label)
                        Dim ValueInvolved As Label = DirectCast(GridView2.Rows(rowIndex).Cells(9).FindControl("lblValueInvolved"), Label)


                        If ddlFreightAppliedTo.SelectedItem.Text = "Combined Value" Then
                            FreightTypeValue.Enabled = False
                            txtFreightValue.Enabled = True
                            txtFreightValue.Text = "0"
                            FreightTypeValue.Text = "0"
                            ReqdValidFreightValue.Enabled = True
                            GrDate.Enabled = False
                            GrNo.Enabled = False
                        Else
                            FreightTypeValue.Enabled = True
                            txtFreightValue.Enabled = False
                            txtFreightValue.Text = "0"
                            ReqdValidFreightValue.Enabled = False
                            GrDate.Enabled = True
                            GrNo.Enabled = True
                        End If



                        InvoiceNo.Text = dt.Rows(i)("InvoiceNo").ToString()
                        ReturnQty.Text = dt.Rows(i)("ReturnQty").ToString()
                        Bales.Text = dt.Rows(i)("Bales").ToString()
                        Qty.Text = dt.Rows(i)("Qty").ToString()
                        ItemNo.Text = dt.Rows(i)("ItemNo").ToString()
                        InvoiceDt.Text = dt.Rows(i)("InvoiceDt").ToString()
                        Customer.Text = dt.Rows(i)("Customer").ToString()
                        SalesPerson.Text = dt.Rows(i)("SalesPerson").ToString()


                        GrNo.Text = dt.Rows(i)("GrNo").ToString()
                        GrDate.Text = dt.Rows(i)("GrDate").ToString()

                        FreightTypeValue.Text = dt.Rows(i)("txtFreightTypeValue").ToString()

                        SalePrice.Text = dt.Rows(i)("lblSalePrice").ToString()
                        ValueInvolved.Text = dt.Rows(i)("lblValueInvolved").ToString()



                        rowIndex += 1
                    Next
                End If

            End If

        Catch ex As Exception
            script = "alert('" + ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
        End Try


    End Sub

    Protected Sub cmdreset_Click(sender As Object, e As System.EventArgs) Handles cmdreset.Click
        Response.Redirect("~/materialrequest.aspx")
    End Sub

    Protected Sub lnkDetail_Click(sender As Object, e As System.EventArgs) Handles lnkDetail.Click
        'btnPopUp_Click(Nothing, Nothing)
        'ScriptManager.RegisterClientScriptBlock(Me, GetType(System.Web.UI.Page), "PopUp", "PopUp();", True)
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
        Qry = "SELECT distinct empcode,empname+'~'+b.DEPTNAME FROM JCT_EmpMast_Base a,DEPTMAST b WHERE empname LIKE '%" & txtEmployee.Text & "%' AND Active='y' AND a.deptcode=b.DEPTCODE  and empcode not in ('R-01111','U-04005')   ORDER BY empname+'~'+b.DEPTNAME"
        ObjFun.FillList(ChkEmpList, Qry)
    End Sub


    'Protected Function ListOfElcosures(chb As CheckBoxList, txt As TextBox) As String

    '    Dim enclosures As New List(Of String)()

    '    For i As Integer = 0 To chbEnclosures.Items.Count - 1

    '        If chb.Items(i).Selected Then

    '            If chb.Items(i).Text = "Other" Then

    '                enclosures.Add(txt.Text)
    '            Else

    '                enclosures.Add(chb.Items(i).Text)


    '            End If


    '        End If
    '    Next

    '    'enclosureslist.Join(",", enclosures.ToArray)
    '    enclosureslist = String.Join(",", New List(Of String)(enclosures).ToArray())

    '    Return enclosureslist

    'End Function

    Protected Function ListOfElcosures(ByVal chb As CheckBoxList, ByVal txt As TextBox) As String

        Dim enclosures As List(Of String) = New List(Of String)
        For i As Integer = 0 To chbEnclosures.Items.Count - 1

            If chb.Items(i).Selected Then

                If chb.Items(i).Text = "Other" Then

                    enclosures.Add(txt.Text)
                Else

                    enclosures.Add(chb.Items(i).Text)

                End If


            End If


        Next

        'enclosureslist.Join(",", enclosures.ToArray)
        enclosureslist = String.Join(",", enclosures.ConvertAll(Of String)(Function(i As String) i.ToString()).ToArray).TrimEnd(",").TrimStart(",")

        Return enclosureslist

    End Function

    Protected Sub ddlFreightAppliedTo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlFreightAppliedTo.SelectedIndexChanged
        For i = 0 To GridView2.Rows.Count - 1
            Dim FreightTypeValue As TextBox = DirectCast(GridView2.Rows(i).Cells(14).FindControl("txtFreightTypeValue"), TextBox)

            Dim GrNoReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(i).Cells(12).FindControl("RequiredFieldValidatorGrNo"), RequiredFieldValidator)
            Dim GrDateReqdValid As RequiredFieldValidator = DirectCast(GridView2.Rows(i).Cells(13).FindControl("RequiredFieldValidatorGrDate"), RequiredFieldValidator)


            If ddlRequestType.SelectedItem.Text = "Sale Return" Then
                GrNoReqdValid.Enabled = False
                GrDateReqdValid.Enabled = False
            End If


            If ddlFreightAppliedTo.SelectedItem.Text = "Combined Value" Then
                FreightTypeValue.Enabled = False
                txtFreightValue.Enabled = True
                txtFreightValue.Text = "0"
                FreightTypeValue.Text = "0"
                ReqdValidFreightValue.Enabled = True
            Else
                FreightTypeValue.Enabled = True
                txtFreightValue.Enabled = False
                txtFreightValue.Text = "0"
                ReqdValidFreightValue.Enabled = False

            End If
        Next i
    End Sub


    Private Sub SendMailLogistics(ByVal RequestID As String)
        Dim from As String = Nothing
        Dim [to] As String = Nothing
        Dim bcc As String = Nothing
        Dim cc As String = Nothing
        Dim subject As String = Nothing
        Dim body As String = Nothing

        Dim obj1 As Functions = New Functions()
        Dim sb As New StringBuilder()




        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<style type=""text/css"">")
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head>")



        ' sb.Append("<head>");
        sb.AppendLine("Hi,<br/><br/>")
        sb.AppendLine("Material Return Request is pending at your end. Please follow details below :<br/><br/>")
        sb.AppendLine("RequestID for your request is : " + RequestID + " <br/><br/>")
        sb.AppendLine("Details are Shown below : <br/><br/>")
        sb.AppendLine("<table class=gridtable>")
        sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th><th> Invoice Qty</th><th> No. of Bales/Rolls</th> <th> Return Qty</th>  <th> Status</th> </tr>")
        'Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + RequestID



        Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(convert(varchar,bales),'') as Bales,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty,isnull(SalePrice,0) as SalePrice,ValueInvloved  FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') and a.RequestID=" + RequestID
        Dim Customer As String = ""
        Dim obj2 As Connection = New Connection
        Cmd = New SqlCommand(Sql, obj2.Connection())
        Dr = Cmd.ExecuteReader

        If Dr.HasRows = True Then
            While Dr.Read()
                sb.AppendLine("<tr> <td> " + Dr(0).ToString() + " </td> <td> " + Dr(1).ToString() + "  </td>  <td> " + Dr(2).ToString() + "</td>  <td>" + Dr(3).ToString() + " </td>  <td>" + Dr(4).ToString() + " </td>  <td>" + Dr(5).ToString() + " </td> <td> " + Dr(6).ToString() + "<td> Authorized </td> </tr> ")
                Customer = Dr(2).ToString()
            End While

            Dr.Close()
        End If
        obj2.ConClose()
        sb.AppendLine("</table>")

        sb.AppendLine("<br/><br/>")


        sb.AppendLine("<b>Freight Paid by :-</b> " + ddlFreight.SelectedItem.Text)


        sb.AppendLine("<br/><br/>")


        sb.AppendLine("<b>Freight Type :- </b>" + ddlFreightType.SelectedItem.Text)





        sb.AppendLine("<br/><br/>")


        sb.AppendLine("<b>Action To Be Taken :-</b> " + ddlActionToBeTaken.SelectedItem.Text)

        '27 Jan 2016
        sb.AppendLine("<b>Tentative Rate :-</b> " + txtTentative.Text)

        '27 Jan 2016


        sb.AppendLine("<br/><br/>")
















        'sb.AppendLine("<br/><br/>")


        'sb.AppendLine("Freight Paid by :- " + ddlFreight.SelectedItem.Text)


        'sb.AppendLine("<br/><br/>")


        'sb.AppendLine("Freight Type :- " + ddlFreightType.SelectedItem.Text)





        'sb.AppendLine("<br/><br/>")


        'sb.AppendLine("Action To Be Taken :- " + ddlActionToBeTaken.SelectedItem.Text)




        'sb.AppendLine("<br/><br/>")

        sb.AppendLine("<table class=gridtable>")
        sb.AppendLine("<tr> <th> Gr No </th> <th> Gr Date </th><th> Freight Value </th> </tr>")
        'Sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(a.FlagAuth,'') as FlagAuth FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("RequestID")

        Sql = "SELECT  GrNo ,GrDate ,FreightValue FROM JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION WHERE STATUS='A' AND REQUESTID=" + RequestID
        Cmd = New SqlCommand(Sql, obj2.Connection())
        Dr = Cmd.ExecuteReader
        If Dr.HasRows = True Then


            While Dr.Read()
                sb.AppendLine("<tr><td> " + Dr(0).ToString() + " </td> <td> " + Dr(1).ToString() + "  </td>  <td>" + Dr(2).ToString() + " </td>  </tr> ")
            End While
            Dr.Close()
        End If
        obj2.ConClose()

        sb.AppendLine("</table>")

        sb.AppendLine("<br /><br/>")
        sb.Append("<a href='http://testerp/fusionapps/OPS/MaterialReturnFinalAuth.aspx'> Click here to view detail... </a><br />")

        sb.AppendLine("</table><br /><br />")

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br />")
        sb.AppendLine("</html>")



        from = "noreply@jctltd.com"
        Sql = "SELECT isnull(b.E_MailID,'ashish@jctltd.com') as email FROM dbo.jct_ops_material_request a INNER JOIN dbo.MISTEL b ON a.userid=b.empcode WHERE  a.RequestID= " + RequestID + ""
        cc = "ashish@jctltd.com"
        '''''''''''''''''''''''''''''''''''''''''''''''cc = "" + obj1.FetchValue(Sql).ToString() + ""
        ''''''''''''''''''''''''''''''''''''''''''''''[to] = "pgmohan@jctltd.com,ranjitsaini@jctltd.com"
        [to] = "ashish@jctltd.com"
        bcc = "harendra@jctltd.com,rbaksshi@jctltd.com,ashish@jctltd.com"
        '[to] = ("jatindutta@jctltd.com")
        'Email Address of Receiver
        'cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
        subject = " Material Return Request Authorized- " + Customer
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
            Else
                mail.CC.Add(New MailAddress(cc))
            End If
            mail.CC.Add(New MailAddress(cc))
        End If
        body = sb.ToString()
        mail.Subject = subject
        mail.Body = body
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2k7")

        'SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail)
        'return mail;
    End Sub

    Protected Sub ddlRequestType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlRequestType.SelectedIndexChanged
        FreightValidation(ddlRequestType.SelectedItem.Text)
    End Sub

    Private Sub FreightValidation(ByVal RequestType As String)
        ddlFreightType.Items.Clear()
        
        If ddlRequestType.SelectedItem.Text = "Sale Return" Then
            ddlFreightAppliedTo.SelectedIndex = 0
            ddlFreightAppliedTo.Enabled = False
            ddlFreightType.Items.Add("None")
            txtFreightValue.Text = 0
            txtFreightValue.Enabled = False
            ddlFreightAppliedTo.SelectedIndex = 0
            ddlFreightAppliedTo.Enabled = False
            ddlFreight.SelectedIndex = 0
            ddlFreight.Enabled = False

        Else

            ddlFreightAppliedTo.Enabled = True
            ddlFreightType.Items.Add("Return Only")
            ddlFreightType.Items.Add("To & Fro")
            txtFreightValue.Enabled = True
            ddlFreightAppliedTo.Enabled = True
            ddlFreight.Enabled = True
        End If
    End Sub

End Class
