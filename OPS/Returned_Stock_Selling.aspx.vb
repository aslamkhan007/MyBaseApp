Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net

Partial Class OPS_Returned_Stock_Selling
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objfun As Functions = New Functions
    Dim toEMail As String = "ashish@jctltd.com"
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
    Dim Meters As Double = 0.0
    Dim TmpMeters As Double = 0.0
    'Dim qry1 As String = ConfigurationManager.ConnectionStrings("miserptest2").ToString()
    'Dim con1 As SqlConnection = New SqlConnection(qry1)

    Protected Sub CmdSearchData_Click(sender As Object, e As System.EventArgs) Handles CmdSearchData.Click
        Try
            Dim Dbase As String
            Dbase = "SHP"

            Dim Proc As String = "Jct_Ops_RetunedGoods_Fetch"

            Dim Cn As String = ""




            Cn = "Data Source=Miserp;Initial Catalog=" & Dbase & ";Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 0;"
            qry = "exec " & Proc & " '" & txtSearchSort.Text & "','" & txtSearchVariant.Text & "'"


            Dim SqlCon As SqlConnection = New SqlConnection(Cn)

            Dim ds As DataSet = New DataSet()
            Dim Da As SqlDataAdapter = New SqlDataAdapter(qry, SqlCon)


            Da.SelectCommand.CommandTimeout = 0
            Da.Fill(ds)
            'Grd.DataSource = ds
            GrdBasicDetail.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
            GrdBasicDetail.DataBind()
        Catch ex As Exception

        Finally

        End Try

    End Sub
    Protected Sub ChkOrderSelAll_CheckedChanged(sender As Object, e As System.EventArgs)
        With GrdPackedForOrder
            For i = 0 To GrdPackedForOrder.Rows.Count - 1
                CType(.Rows(i).FindControl("ChkOrderItems"), CheckBox).Checked = CType(.HeaderRow.FindControl("ChkOrderSelAll"), CheckBox).Checked
            Next
        End With
    End Sub

    Protected Sub ChkBasicDetail_SelAll_CheckedChanged(sender As Object, e As System.EventArgs)
        'ChkBasicDetail_SelAll
        With GrdBasicDetail
            For i = 0 To GrdBasicDetail.Rows.Count - 1
                CType(.Rows(i).FindControl("chkBox"), CheckBox).Checked = CType(.HeaderRow.FindControl("ChkBasicDetail_SelAll"), CheckBox).Checked
            Next
        End With

    End Sub

    'Protected Sub CmdSearchClear_Click(sender As Object, e As System.EventArgs) Handles CmdSearchClear.Click
    '    ddlShipmentAddress.Items.Clear()
    '    LblAddress.Text = ""
    'End Sub

    Protected Sub imgAddRow_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgAddRow.Click
        Dim i As Integer

        'obj.Connection.Open()
        'Tran = obj.Connection.BeginTransaction

        With GrdBasicDetail


            For i = 0 To .Rows.Count - 1
                If CType(.Rows(i).FindControl("chkBox"), CheckBox).Checked = True Then
                    qry = "exec Jct_Ops_Return_Goods_Intermidate_insert '" & Session("empcode") & "','" & Trim(.Rows(i).Cells(6).Text) & "','" & Trim(.Rows(i).Cells(7).Text) & "','" & Trim(.Rows(i).Cells(8).Text) & "'," & Trim(.Rows(i).Cells(9).Text) & ",'" & Request.ServerVariables("REMOTE_ADDR") & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & Trim(.Rows(i).Cells(4).Text) & "'"
                    cmd = New SqlCommand(qry, obj.Connection)
                    cmd.ExecuteNonQuery()
                End If

            Next
        End With
        qry = "Select Sort,var as Variant,BaleNo,Qty,InvoicedIn ,Actual_SalePrice as SalePrice from Jct_Ops_Returned_Goods_Sanction_Intermidiate where hostIP='" & Request.ServerVariables("REMOTE_ADDR") & "'"
        Dim ds As DataSet = New DataSet()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(qry, obj.Connection)


        Da.SelectCommand.CommandTimeout = 0
        Da.Fill(ds)
        'Grd.DataSource = ds
        GrdTempValues.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
        GrdTempValues.DataBind()


        qry = "Select Sort,var as Variant,Sum(Qty) as Qty from Jct_Ops_Returned_Goods_Sanction_Intermidiate where hostIP='" & Request.ServerVariables("REMOTE_ADDR") & "' group by Sort,var"
        ds = New DataSet()
        Da = New SqlDataAdapter(qry, obj.Connection)


        Da.SelectCommand.CommandTimeout = 0
        Da.Fill(ds)
        'Grd.DataSource = ds
        GrdCostDetail.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
        GrdCostDetail.DataBind()

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            qry = "Delete from Jct_Ops_Returned_Goods_Sanction_Intermidiate where hostIP='" & Request.ServerVariables("REMOTE_ADDR") & "'"
            cmd = New SqlCommand(qry, obj.Connection)
            cmd.ExecuteNonQuery()

            ddlPlant_SelectedIndexChanged(sender, e)
            'qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy a ,dbo.JCT_EmpMast_Base C WHERE  areacode=1058 AND c.empcode = a.empcode AND a.plant = '" & ddlPlant.SelectedItem.Text & "'  ORDER BY AuthLevel"
            'objfun.FillGrid(qry, GrdEmployee)
        End If
    End Sub

    Protected Sub ImgDelRows_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImgDelRows.Click
        Dim i As Integer
        For i = 0 To GrdTempValues.Rows.Count - 1
            If CType(GrdTempValues.Rows(i).FindControl("ChkDelete"), CheckBox).Checked = True And GrdTempValues.Rows(i).RowType = DataControlRowType.DataRow Then
                qry = "Delete from Jct_Ops_Returned_Goods_Sanction_Intermidiate where BaleNo='" & GrdTempValues.Rows(i).Cells(3).Text & "'"
                cmd = New SqlCommand(qry, obj.Connection)
                cmd.ExecuteNonQuery()
            End If
        Next
        qry = "Select Sort,var as Variant,BaleNo,Qty from Jct_Ops_Returned_Goods_Sanction_Intermidiate where hostIP='" & Request.ServerVariables("REMOTE_ADDR") & "'"
        Dim ds As DataSet = New DataSet()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(qry, obj.Connection)


        Da.SelectCommand.CommandTimeout = 0
        Da.Fill(ds)
        'Grd.DataSource = ds
        GrdTempValues.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
        GrdTempValues.DataBind()


        qry = "Select Sort,var as Variant,Sum(Qty) as Qty from Jct_Ops_Returned_Goods_Sanction_Intermidiate where hostIP='" & Request.ServerVariables("REMOTE_ADDR") & "' group by Sort,var"
        ds = New DataSet()
        Da = New SqlDataAdapter(qry, obj.Connection)


        Da.SelectCommand.CommandTimeout = 0
        Da.Fill(ds)
        'Grd.DataSource = ds
        GrdCostDetail.DataSource = IIf(ds.Tables.Count > 0, ds, Nothing)
        GrdCostDetail.DataBind()

    End Sub

    Protected Sub cmdApply_Click(sender As Object, e As System.EventArgs) Handles cmdApply.Click
        Dim SanctionID As String
        Dim Area As Int16
        Dim i As Integer

        Dim ParmCode As String = ""

        Dim ddlVal As String = ""
        Dim EmpCode As String
        Dim index As Int16 = 0
        Dim EmpName As String = ""
        EmpCode = Trim(Session("Empcode"))
        Dim Genratedby_Email As String = "", GenratedByName As String = ""
        Dim Cmd2 As SqlCommand = New SqlCommand
        Dim Str As String
        Dim body As String = ""
        Dim ParmName As String = ""
        Dim ToList As String = ""



        Area = 1058
        Tran = obj.Connection.BeginTransaction
        Try

            qry = "SELECT TOP 1 Num FROM JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL"
            SanctionID = objfun.FetchValue(qry, obj.Connection, Tran)

            qry = " exec Jct_Ops_ReInvoicing_SanctionNote_Insert '" & Session("Empcode") & "','" & SanctionID & "','" & Area & "','" & txtSubject.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & ddlPlant.SelectedItem.Text & "',''"
            objfun.InsertRecord(qry, Tran, obj.Connection)
            'Jct_Ops_ReInvoicing_Insert


            Dim EmpLevelCount As Int16 = 0



            If GrdEmployee.Rows.Count > 1 Then


                qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL)  SELECT '" & SanctionID & "', UserCode ,AreaCode, EmpCode, AuthLevel FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy WHERE AreaCode=" & Area & " AND Plant='" & ddlPlant.SelectedItem.Text & "' ORDER BY AuthLevel"
                cmd = New SqlCommand(qry, obj.Connection)
                cmd.Transaction = Tran
                cmd.ExecuteNonQuery()

            Else
                objfun.Alert("No valid Authorization Hierarchy Present !!")
            End If


            qry = "UPDATE  JCT_OPS_SanctionNote_Codes SET IsConsumed = 'Y',DateConsumed = GETDATE() WHERE   Num = '" & SanctionID & "'  "
            objfun.UpdateRecord(qry, Tran, obj.Connection)



            qry = " exec Jct_Ops_ReInvoicing_Bale_Detail_Insert '" & SanctionID & "','" & Request.ServerVariables("REMOTE_ADDR") & "'"
            objfun.InsertRecord(qry, Tran, obj.Connection)


            With GrdCostDetail
                For i = 0 To .Rows.Count - 1
                    Dim txtSellingPrice As TextBox = CType(.Rows(i).FindControl("txtProposedSellingPrice"), TextBox)
                    Dim ddlRateUom As DropDownList = CType(.Rows(i).FindControl("ddlRateUom"), DropDownList)
                    qry = " exec Jct_Ops_Reinvoicing_Sort_Wise_Rate_Insert '" & SanctionID & "','" & Trim(.Rows(i).Cells(0).Text) & "','" & Trim(.Rows(i).Cells(1).Text) & "','" & txtSellingPrice.Text & "','" & ddlRateUom.SelectedItem.Text & "'"
                    objfun.InsertRecord(qry, Tran, obj.Connection)

                Next
            End With
            Tran.Commit()
            cmdApply.Enabled = False
            '--Jct_Ops_Reinvoicing_Sort_Wise_Rate_Insert()

            objfun.Alert("Record Saved Sucessfully !!")
            lblID.Text = SanctionID
        Catch ex As Exception
            Tran.Rollback()
            objfun.Alert("Some error Occured :  " & ex.Message)
        Finally
            obj.ConClose()
        End Try


        'Dim subject As String = ""
        Dim body_to As String = ""
        ' subject = "ReInvoicing Request with SanctionID " & lblID.Text & " has been done by " + Session("EmpName").ToString '+ " : " + Session("EmpCode").ToString
        ' body_to = "Quotation # <a href = 'http://misdev/fusionapps/ops/Returned_Stock_Selling_Preview.aspx?SanctionID=" & lblID.Text & "'> " & lblID.Text & "</a> has been Authorised successfully! " + Session("EmpName").ToString + "<br/> Click on Quotation Number to view details."
        body_to = GetPage("Returned_Stock_Selling_Preview.aspx?SanctionID=" & lblID.Text)




        'SanctionID = "AXRA8S8V"
        'EmpCode = "A-00098"





        If lblID.Text = "" Then
            objfun.Alert("Unable to Send mail !!")
            Exit Sub
        End If

        Try
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
            'End If




            qry = "SELECT a.EmpCode ,Name,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE UserLevel=1  AND STATUS IS null and AreaCode='1058' and a.EmpCode=b.empcode and id='" & lblID.Text & "' "
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Genratedby_Email = Genratedby_Email & "," & dr.Item(2)
                'Body3 = "<br><br><hr> This is Pending At <b>" & dr.Item(1) & " </b> "
            End If
            dr.Close()
            obj.ConClose()



            'Genratedby_Email = Genratedby_Email & "," & objFun.FetchValue(qry)
            Dim NotifyEmailGroup As String = "Noreply@jctltd.com"
            qry = "SELECT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='" & lblID.Text & "'"
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
                End While
            End If
            'If Right(NotifyEmailGroup, 1) = "," Then
            '    NotifyEmailGroup=
            'End If
            GenrateMail(body_to, lblID.Text, Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your SanctionNote No :-" & lblID.Text & " has been genrated ")

        Catch
            objfun.Alert("Unable to Send Email..... ")
        End Try
















        'SanctionID1 = SanctionID
    End Sub

    Protected Sub ddlPlant_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPlant.SelectedIndexChanged
        qry = "SELECT  UPPER(a.EmpCode) AS EmpCode ,c.Empname ,a.AuthLevel FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy a ,dbo.JCT_EmpMast_Base C WHERE  areacode=1058 AND c.empcode = a.empcode AND a.plant = '" & ddlPlant.SelectedItem.Text & "'  ORDER BY AuthLevel"
        objfun.FillGrid(qry, GrdEmployee)
    End Sub



    Private Sub GenrateMail(Body As String, OrderNo As String, SalesPerson_Email As String, [to] As String, cc As String, bcc As String, Subject As String)
        Dim from As String ', body__2 As String
        from = "noreply@jctltd.com"
        Dim query As String = ""
        Dim SenderEmail As String = ""
        Dim mail As New MailMessage()
        mail.From = New MailAddress(from)
        mail.Subject = Subject
        mail.Body = Body
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2k7")


        '[to] = "shwetaloria@jctltd.com"
        '[cc] = "ashish@jctltd.com"

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

       


        SmtpMail.Send(mail)
    End Sub

    Protected Function GetPage(page_name As String) As String

        Dim myclient As WebClient = New WebClient()
        Dim myPageHTML As String
        Dim requestHTML As Byte()
        Dim currentPageUrl As String

     
        ''''''''''''''''''''''''''''''
        currentPageUrl = "http://misdev/FusionApps/OPS/Returned_Stock_Selling_Preview.aspx?SanctionID=" & lblID.Text
        'currentPageUrl = "http://localhost:2987/FusionApps/OPS/Returned_Stock_Selling_Preview.aspx?SanctionID=" & lblID.Text

        Dim utf8 As UTF8Encoding = New UTF8Encoding()



        requestHTML = myclient.DownloadData(currentPageUrl)
        myPageHTML = utf8.GetString(requestHTML)



        Return myPageHTML

    End Function

    Protected Sub cmdClear_Click(sender As Object, e As System.EventArgs) Handles cmdClear.Click
        qry = "Delete from Jct_Ops_Returned_Goods_Sanction_Intermidiate where hostIP='" & Request.ServerVariables("REMOTE_ADDR") & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        cmd.ExecuteNonQuery()

        GrdBasicDetail.DataSource = Nothing
        GrdBasicDetail.DataBind()

        GrdCostDetail.DataSource = Nothing
        GrdCostDetail.DataBind()

        GrdPackedForOrder.DataSource = Nothing
        GrdPackedForOrder.DataBind()

        txtSubject.Text = ""
        txtDescription.Text = ""
        txtSearchSort.Text = ""
        txtSearchVariant.Text = ""
        lblID.Text = ""
        cmdApply.Enabled = True
    End Sub
End Class
