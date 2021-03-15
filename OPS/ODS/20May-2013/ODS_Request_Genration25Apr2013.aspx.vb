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
    End Sub

    Protected Sub ddlItems_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlItems.SelectedIndexChanged
        Qry = "SELECT distinct  b.attb_discrete FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlItems.SelectedItem.Value
        lblLineNo.Text = ObjFun.FetchValue(Qry)
        Qry = "SELECT distinct  a.item_no FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b(nolock) WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no='" & txtOrderNo.Text & "' AND b.attb_code='shade1' and a.order_srl_no=" & ddlItems.SelectedItem.Value
        lblSort.Text = ObjFun.FetchValue(Qry)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  txtOrderNo.Attributes.Add("onKeyPress", "doClick('" + BtnFetch.ClientID + "',event)")
            txtOrderNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + cmdSearch.UniqueID + "').click();return false;}} else {return true}; ")
        End If
    End Sub

    Protected Sub CmdSearchData_Click(sender As Object, e As System.EventArgs) Handles CmdSearchData.Click
        Dim Con As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("IMSDBConnectionString").ConnectionString
        Dim SqlCon As SqlConnection = New SqlConnection(Con)
        qry = "exec Jct_Ops_ODS_Request '','" & txtVal.Text & "'"
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

        'Dim i As Int16
        'i = 0
        'Dim ParmCode As String = ""
        'Dim SanctionID As String = ""
        'Dim ddlVal As String = ""
        'Dim EmpCode As String
        'Dim index As Int16 = 0
        'Dim EmpName As String = ""
        'EmpCode = Trim(Session("Empcode"))
        'Dim Genratedby_Email As String = "", GenratedByName As String = ""
        'Dim Cmd2 As SqlCommand = New SqlCommand
        'Dim Str As String
        'Dim body As String, Body1 As String, Body2 As String = "", Body3 As String = ""
        'Dim ParmName As String = ""
        'Dim ToList As String = ""

        'Dim AuthMob As String = ""

        'Tran = obj.Connection.BeginTransaction
        'Try
        '    qry = "exec Jct_Ops_ODS_Request_GenrateRequestID"
        '    SanctionID = objfun.FetchValue(qry, obj.Connection, Tran)

        '    Body1 = Body1 & " <hr> Description :- " & txtDescription.Text & "<hr> "
        '    qry = " exec Jct_Ops_SanctionNote_Insert_HDR '" & Session("Empcode") & "','1028','" & txtSubject.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & SanctionID & "','" & ddlPlant.SelectedItem.Text & "'"
        '    objfun.InsertRecord(qry, Tran, obj.Connection)
        '    With GrdBasicDetail
        '        For i = 0 To .Rows.Count - 1
        '            ParmCode = .Rows(i).Cells(0).Text
        '            ParmName = .Rows(i).Cells(1).Text
        '            Dim chkSelection As CheckBox = CType(.Rows(i).FindControl("chkSelection"), CheckBox)
        '            'Dim txtValue As TextBox = CType(.Rows(i).FindControl("txtValue"), TextBox)

        '            If chkSelection.Checked = True Then
        '                qry = "Exec Jct_Ops_ODS_Insert_Detail '" & SanctionID & "','" & ParmCode & "','" & ddlValueList.SelectedItem.Text & "'"
        '                Body1 = Body1 & "<p> <b>" & ParmName & " :-</b> " & ddlValueList.SelectedItem.Text & " </p> "
        '            Else
        '                qry = "Exec Jct_Ops_SanctionNote_Insert_Dtl '" & SanctionID & "','" & ParmCode & "','" & txtValue.Text & "'"
        '                Body1 = Body1 & "<p> <b>" & ParmName & " :- </b> " & txtValue.Text & " </p> "
        '            End If
        '            objfun.InsertRecord(qry, Tran, obj.Connection)
        '        Next

        '        qry = "UPDATE  JCT_OPS_SanctionNote_Codes SET IsConsumed = 'Y',DateConsumed = GETDATE() WHERE   Num = '" & SanctionID & "'  "
        '        objfun.UpdateRecord(qry, Tran, obj.Connection)



        '        'If Request.Files.Count > 0 Then
        '        '    For i = 0 To Request.Files.Count - 1
        '        '        Dim PostedFile As HttpPostedFile = Request.Files(i)
        '        '        If PostedFile.ContentLength > 0 Then
        '        '            FileName = System.IO.Path.GetFileName(PostedFile.FileName)
        '        '            PostedFile.SaveAs(Server.MapPath("Upload\") & FileName)
        '        '            qry = "INSERT INTO Jct_Ops_SanctionNote_Attachments( SanctionNoteID ,ImgName ,STATUS ,UploadedOn) VALUES  ( '" & SanctionID & "' , '" & FileName & "' , 'A' , GETDATE())"
        '        '            objfun.InsertRecord(qry, Tran, obj.Connection)
        '        '        End If
        '        '    Next

        '        'End If

        '        Dim EmpLevelCount As Int16 = 0
        '        EmpLevelCount = ChkDynamicListing.Items.Count
        '        'Dim MaxFixedLevel As Int16 = 0
        '        'Dim FinalLevel As Int16 = 0

        '        'qry = "Select max(UserLevel) from  Jct_Ops_SanctioNote_Area_Emp_Auth_Listing where areacode=" & ddlarea.SelectedItem.Value & " and status='A'"
        '        'cmd = New SqlCommand(qry, obj.Connection)
        '        'cmd.Transaction = Tran
        '        'dr = cmd.ExecuteReader
        '        'If dr.HasRows = True Then
        '        '    dr.Read()
        '        '    MaxFixedLevel = dr.Item(0)
        '        'End If
        '        'dr.Close()
        '        ''MaxFixedLevel = objFun.FetchValue(qry)
        '        'FinalLevel = EmpLevelCount + MaxFixedLevel
        '        'For i = 0 To FinalLevel

        '        'Next


        '        For i = 0 To ChkDynamicListing.Items.Count - 1
        '            qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL) values('" & SanctionID & "','" & Session("empcode") & "','" & ddlarea.SelectedItem.Value & "','" & ChkDynamicListing.Items(i).Value & "'," & i + 1 & ")"
        '            cmd = New SqlCommand(qry, obj.Connection)
        '            cmd.Transaction = Tran
        '            cmd.ExecuteNonQuery()
        '        Next

        '        'qry = "Select UserLevel,EmpCode from  Jct_Ops_SanctioNote_Area_Emp_Auth_Listing where areacode=" & ddlarea.SelectedItem.Value & " and status='A' order by Userlevel"
        '        'cmd = New SqlCommand(qry, obj.Connection)
        '        'cmd.Transaction = Tran
        '        'dr = cmd.ExecuteReader
        '        'If dr.HasRows = True Then
        '        '    While dr.Read
        '        '        qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL) values('" & SanctionID & "','" & Session("empcode") & "','" & ddlarea.SelectedItem.Value & "','" & dr.Item(1) & "'," & (i + EmpLevelCount) & ")"
        '        '        Cmd2 = New SqlCommand(qry, obj.Connection)
        '        '        Cmd2.Transaction = Tran
        '        '        Cmd2.ExecuteNonQuery()
        '        '        'objFun.InsertRecord(qry, Tran, obj.Connection)
        '        '    End While
        '        'End If
        '        qry = "exec Jct_Ops_SanctionNote_InsertDynamic_User '" & SanctionID & "','" & Session("empcode") & "','" & ddlarea.SelectedItem.Value & "'," & EmpLevelCount & ",'" & ddlPlant.SelectedItem.Text & "'"
        '        objfun.InsertRecord(qry, Tran, obj.Connection)



        '        For i = 0 To chkNotify.Items.Count - 1
        '            qry = "INSERT INTO dbo.Jct_Ops_SanctionNote_Notify( Usercode ,SanctionID ,NotifyUser , CreatedDate) values('" & Session("Empcode") & "','" & SanctionID & "','" & chkNotify.Items(i).Value & "',getdate())"
        '            cmd = New SqlCommand(qry, obj.Connection)
        '            cmd.Transaction = Tran
        '            cmd.ExecuteNonQuery()
        '        Next

        '        'For i = 0 To ChkUploadedItems.Items.Count - 1
        '        '    FileName = ChkUploadedItems.Items(i).Value
        '        '    'qry = "INSERT INTO Jct_Ops_SanctionNote_Attachments( SanctionNoteID ,ImgName ,STATUS ,UploadedOn) VALUES  ( '" & SanctionID & "' , '" & FileName & "' , 'A' , GETDATE())"
        '        '    'objFun.InsertRecord(qry, Tran, obj.Connection)
        '        'Next


        '    End With
        '    Tran.Commit()
        '    objfun.Alert("Record Saved Sucessfully !!")
        '    lblID.Text = SanctionID
        '    CmdApply.Enabled = False

        'Catch ex As Exception
        '    Tran.Rollback()
        '    objfun.Alert("Unable to Complete Transaction " & ex.ToString)
        '    Exit Sub
        'End Try
        ''qry = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" & OrderNo & "'"
        ''Dim SalePersonCode As String = ""
        ''Dim SalePersonEmail As String = "mkt-group@jctltd.com"
        ''SalePersonCode = objFun.FetchValue(qry)
        ''If SalePersonCode Is Nothing Then SalePersonCode = ""
        ''If SalePersonCode <> "mkt-group@jctltd.com" And CStr(SalePersonCode) <> "" Then
        ''    SalePersonCode = Left(SalePersonCode, 1) & "-" & Right(SalePersonCode, Len(SalePersonCode) - 1)

        'Try




        '    qry = "SELECT isnull(E_MailID,''),name FROM dbo.MISTEL WHERE empcode='" & EmpCode & "' "
        '    cmd = New SqlCommand(qry, obj.Connection)
        '    dr = cmd.ExecuteReader
        '    dr.Read()
        '    If dr.HasRows = True Then
        '        Genratedby_Email = dr.Item(0)
        '        GenratedByName = dr.Item(1)
        '    End If
        '    dr.Close()
        '    obj.ConClose()
        '    'End If
        '    body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br>Sanction Note with ID <b>" & SanctionID & " </b> has been genrated  With Following Detail "
        '    Body1 = Body1 & "<hr>"
        '    Body2 = "<Br><br> The Sanction Note is genrated by " & GenratedByName & " <Hr> <br> <b>With Description :-</b><hr>"




        '    qry = "SELECT a.EmpCode ,Name,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE UserLevel=1  AND STATUS IS null and AreaCode='" & ddlarea.SelectedItem.Value & "' and a.EmpCode=b.empcode and id='" & SanctionID & "' "
        '    cmd = New SqlCommand(qry, obj.Connection)
        '    dr = cmd.ExecuteReader
        '    dr.Read()
        '    If dr.HasRows Then
        '        Genratedby_Email = Genratedby_Email & "," & dr.Item(2)
        '        Body3 = "<br><br><hr> This is Pending At <b>" & dr.Item(1) & " </b> "
        '    End If
        '    dr.Close()
        '    obj.ConClose()


        '    Body3 = Body3 & " <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
        '    'Genratedby_Email = Genratedby_Email & "," & objFun.FetchValue(qry)
        '    Dim NotifyEmailGroup As String = "Noreply@jctltd.com"
        '    qry = "SELECT E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,mistel b WHERE  a.NotifyUser=b.empcode AND SanctionID='" & SanctionID & "'"
        '    cmd = New SqlCommand(qry, obj.Connection)
        '    dr = cmd.ExecuteReader
        '    If dr.HasRows = True Then
        '        While dr.Read
        '            NotifyEmailGroup = NotifyEmailGroup & "," & dr.Item(0)
        '        End While
        '    End If
        '    'If Right(NotifyEmailGroup, 1) = "," Then
        '    '    NotifyEmailGroup=
        '    'End If
        '    GenrateMail(body, Body1, Body2, Body3, SanctionID, Genratedby_Email, Genratedby_Email, NotifyEmailGroup, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your SanctionNote No :-" & SanctionID & " has been genrated ")

        'Catch
        '    objfun.Alert("Unable to Send Email..... ")
        'End Try

        'Try
        '    AuthMob = objfun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a WHERE a.empcode=b.empcode  AND a.ID='" & SanctionID & "' and a.Userlevel='1' ")
        '    If AuthMob Is Nothing Then
        '        AuthMob = 0
        '    End If
        '    Dim RaisedByUserName As String = ""
        '    Dim sm As New SendMail
        '    RaisedByUserName = objfun.FetchValue("SELECT b.empname FROM Jct_Ops_SanctionNote_HDR a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND a.SanctionNoteID='" & SanctionID & "'")
        '    Dim msg As String = "Sanction Note " & SanctionID & " is due for approval. It was last approved by None  and raised by " & RaisedByUserName
        '    If Len(AuthMob) >= 10 Then
        '        sm.SendSMS(Session("CompanyCode"), Session("EmpCode"), AuthMob, msg, "SanctionNote Raised")
        '    End If
        'Catch ex As Exception
        '    objfun.Alert("Unable to Send SmS..... ")
        'End Try


        'qry = "update Jct_Ops_SanctionNote_Notify Set Notified='Y',NotifiedOn=getdate() where SanctionID='" & SanctionID & "'"
        'objfun.UpdateRecord(qry)


    End Sub
End Class
