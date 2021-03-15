Imports System
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Partial Class OPS_SanctionNoteExceptionSendMail
    Inherits System.Web.UI.Page

    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction
    Dim ObjSendMail As SendMail

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
      
        Dim AreaName As String = ""
        If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then

            AreaName = Request.QueryString("AreaName")
            GrdSanctionNoteDetail.DataSource = Nothing
            GrdSanctionNoteDetail.DataBind()
            'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "' and a.UserCode='" & ddlAuthBy.selecteditem.value & "'"
            qry = "Jct_Ops_Pending_Authorization_Fetch '" & ddlAuthBy.selecteditem.value & "','" & AreaName & "'"
            objFun.FillGrid(qry, GridView1)

            ' remove query string
            Dim isreadonly As PropertyInfo = _
            GetType(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance Or BindingFlags.NonPublic)

            ' make collection editable
            isreadonly.SetValue(Me.Request.QueryString, False, Nothing)

            ' remove
            Me.Request.QueryString.Remove("AreaName")


        End If





        'If ddlAuthBy.selecteditem.value = "A-00098" Or ddlAuthBy.selecteditem.value = "P-03055" Then
        '    Panel2.Visible = True
        'Else
        '    Panel2.Visible = False
        'End If
    End Sub

  


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Comented on 31-Dec-2012   qry = "SELECT b.ParmName,b.ParmDesc,a.Val as [Values] FROM dbo.Jct_Ops_SanctionNote_Dtl a,dbo.Jct_Ops_SanctionNote_Parameters b WHERE SanctionNoteID='" & Trim(GridView1.SelectedRow.Cells(1).Text) & "' AND b.STATUS='A' AND GETDATE() BETWEEN b.Eff_From AND b.Eff_To  AND a.ParamCode=b.ParamCode"
        Try
            qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "','" & Trim(GridView1.SelectedRow.Cells(3).Text) & "'"
            objFun.FillGrid(qry, GrdSanctionNoteDetail)
            qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
            objFun.FillGrid(qry, GrdAuthHistory)
            qry = "   SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + Trim(GridView1.SelectedRow.Cells(2).Text) + "'"
            Dim cmd As SqlCommand = New SqlCommand(qry, obj.Connection())
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
          
        Catch ex As Exception
            MsgBox("" & ex.ToString)

        End Try

        'If Trim(GridView1.SelectedRow.Cells(3).Text) = "Exception" Then
        '    Panel1.Visible = True
        'Else
        '    Panel1.Visible = False
        'End If
    End Sub

    Protected Sub CmdAuthorize_Click(sender As Object, e As System.EventArgs) Handles CmdSendMail.Click

        Try


            Dim NextAuthLevel As String = "None"
            Dim MaxAuthLevel As String = "None"
            Dim CurrentUserLevel As String = ""
            Dim AreaCode As String = ""
            Dim SanctionNote As String = ""
            Dim SalePersonCode As String = ""
            Dim SalePersonEmail As String = "hitesh@jctltd.com"
            Dim Body As String = ""
            Dim Body3 As String = ""
            Dim AuthorizedBy As String, SendMailTo As String, Shade As String, Lineno As Int16 = 0
            Dim Subject As String = ""
            Dim Qty As Int32 = 0
            Dim Reqd_Date As String = ""
            Dim Area As String = ""
            Dim CurrentUserName As String = ""
            Dim RaisedByUserName As String = ""
            Dim Scrpt As String = ""
            Dim AuthMob As String = ""


            CurrentUserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & ddlAuthBy.SelectedItem.Value & "'")
            AuthorizedBy = objFun.FetchValue("SELECT E_MailID FROM MISTEL WHERE empcode='" & ddlAuthBy.SelectedItem.Value & "'")

            If AuthMob Is Nothing Then
                AuthMob = 0
            End If

            Dim FinalNotify As String = ""
            SendMailTo = ""
            Shade = ""
            Lineno = 0
            Try

                With GridView1

                    'If .SelectedIndex > -1 Then
                    'If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
                    SanctionNote = Trim(txtSanctionNote.Text)
                    RaisedByUserName = objFun.FetchValue("SELECT b.empname FROM Jct_Ops_SanctionNote_HDR a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND a.SanctionNoteID='" & SanctionNote & "'")
                    AreaCode = Trim(lblarea.Text)
                    Subject = Trim(lblsubject.Text)
                    qry = "SELECT AreaName FROM dbo.Jct_Ops_SanctioNote_Area_Master WHERE Status='A' AND ParentArea='1015' AND AreaCode='" & AreaCode & "'"
                    Area = objFun.FetchValue(qry)
                    ViewState("ID") = SanctionNote



                    Tran = obj.Connection.BeginTransaction
                    con = obj.Connection
                    If AreaCode = 9999 Then
                        Area = Trim(.SelectedRow.Cells(6).Text)
                        Area = Area.Substring(Area.IndexOf("~ ") + 2, Area.IndexOf(" -") - Area.IndexOf("~ ") - 2)

                        'OrderNo = GrdSanctionNoteDetail.Rows(0).Cells(1).Text
                        'Sort = GrdSanctionNoteDetail.Rows(0).Cells(2).Text
                        Shade = GrdSanctionNoteDetail.Rows(0).Cells(4).Text
                        Lineno = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
                        Qty = GrdSanctionNoteDetail.Rows(0).Cells(6).Text
                        Reqd_Date = GrdSanctionNoteDetail.Rows(0).Cells(7).Text
                    End If
                    If AreaCode <> 9999 Then

                        If AreaCode = 1014 Then
                            qry = "SELECT e_mailid  from jct_ops_material_request a inner join mistel b on a.userid=b.empcode  where requestid=" + ViewState("ID") + ""
                            FinalNotify = objFun.FetchValue(qry, con, Tran)
                        Else
                            'qry = "SELECT STUFF((SELECT ',' + s.E_MailID FROM (SELECT 1 ID,E_MailID from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode UNION  SELECT  1 ID ,E_MailID FROM    dbo.Jct_Ops_SanctionNote_Notify a ,MISTEL c WHERE   SanctionID = '" & SanctionNote & "' AND a.Usercode = c.empcode UNION SELECT    1 ID ,         E_MailID    FROM      MISTEL c WHERE     c.empcode = 'P-03055' ) s WHERE s.id = t.id FOR XML PATH('')),1,1,'') AS CSV FROM (SELECT 1 ID,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode ) AS t GROUP BY t.id"
                            qry = "SELECT STUFF((SELECT ',' + s.E_MailID FROM (SELECT 1 ID,E_MailID from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode UNION  SELECT  1 ID ,E_MailID FROM    dbo.Jct_Ops_SanctionNote_Notify a ,MISTEL c WHERE   SanctionID = '" & SanctionNote & "' AND a.Usercode = c.empcode ) s WHERE s.id = t.id FOR XML PATH('')),1,1,'') AS CSV FROM (SELECT 1 ID,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_HDR a,MISTEL c  WHERE SanctionNoteID='" & SanctionNote & "' AND a.UserCode=c.empcode ) AS t GROUP BY t.id"
                            FinalNotify = objFun.FetchValue(qry, con, Tran)
                        End If

                        qry = "Select isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and id='" & SanctionNote & "' and empcode='" & ddlAuthBy.SelectedItem.Value & "'"
                        CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

                        If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"


                        If CurrentUserLevel <> "None" Then
                            qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and empcode<>'" & ddlAuthBy.SelectedItem.Value & "' and userlevel>'" & Val(CurrentUserLevel) & "' order by userlevel"
                            NextAuthLevel = objFun.FetchValue(qry, con, Tran)
                        Else
                            objFun.Alert("Unable to Your Authoirze...!!!")

                            Tran.Rollback()
                            Exit Sub
                        End If

                        qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.empcode<>'" & ddlAuthBy.SelectedItem.Value & "' and userlevel>'" & Val(CurrentUserLevel) & "' and a.empcode=b.empcode order by userlevel"
                        SendMailTo = objFun.FetchValue(qry, obj.Connection, Tran)


                        qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and  id='" & SanctionNote & "'  AND STATUS is NULL"
                        MaxAuthLevel = objFun.FetchValue(qry, con, Tran)


                        'Added on  Jan -8 to include  P.G Mohan authorization 

                        'If CurrentUserLevel = MaxAuthLevel And "a" = "p-03055" Then
                        '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & ddlAuthBy.selecteditem.value & "','','" & lblTransport.Text & "','" & ddlFinalMode.SelectedItem.Value & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
                        '    objFun.InsertRecord(qry, Tran, obj.Connection)
                        '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & ddlAuthBy.selecteditem.value & "','','" & lblFreightVal.Text & "','" & txtFinalFreightVal.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
                        '    objFun.InsertRecord(qry, Tran, obj.Connection)
                        'End If Removed on 30-jan-2013

                        If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
                            NextAuthLevel = "None"
                            objFun.Alert("Unable to Your Peform Action...!!!")
                            'Tran.Rollback()
                            Exit Sub

                        ElseIf NextAuthLevel <> "None" And CurrentUserLevel <> MaxAuthLevel And Left(ddlAction.SelectedItem.Text, 1) = "A" Then


                            If CurrentUserLevel = MaxAuthLevel Then
                                Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            Else
                                Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            End If
                        Else ' Else part will be executed in case when either maxauthlevel is achevied or some one wants to cancel any sanctionnote


                            'If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                            '    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,AUTH_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & ddlAuthBy.selecteditem.value & "','" & AreaCode & "','" & ddlAuthBy.selecteditem.value & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                            'Else
                            '    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & ddlAuthBy.selecteditem.value & "','" & AreaCode & "','" & ddlAuthBy.selecteditem.value & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                            'End If


                            If Left(ddlAction.SelectedItem.Text, 1) = "A" Then

                                If (AreaCode = 1014) Then

                                End If
                            Else

                                If (AreaCode = 1014) Then

                                End If
                            End If


                            '  If CurrentUserLevel = MaxAuthLevel Then
                            'Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            'Else
                            Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            ' End If
                        End If
                    Else '-----Will be executed when Exceptions are ment to be authorised or Unauthorized

                        ''Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

                        Body = "<p>Hello.....,</p>This Order has been approved for re-scheduling in " & Area & " is <B>Pending At Planning's Approval </b><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)", obj.Connection, Tran)) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & CurrentUserName & "  </h3>  <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"


                    End If
                    Tran.Commit()

                    If (Left(ddlAction.SelectedItem.Text, 1) = "A") Then

                        Scrpt = "alert('SanctionNote has been Authorized..!!');"
                    Else
                        Scrpt = "alert('SanctionNote has been Cancelled..!!');"

                    End If

                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                    If (Left(ddlAction.SelectedItem.Text, 1) = "A") Then

                        objFun.Alert("SanctionNote has been Authorized..!!")

                    Else
                        objFun.Alert("SanctionNote has been Cancelled..!!")
                    End If

                    'Scrpt = "alert('SanctionNote ' + '" + ddlAction.SelectedItem.Text + "'+'ed...!!!');"
                    'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                    'objFun.Alert("SanctionNote " & ddlAction.SelectedItem.Text & "ed...!!!")
                    Try
                        Dim sm As New SendMail
                        If CurrentUserLevel = MaxAuthLevel Then
                            'Code To Send SMS to SalePerson Raising the Sanction Note
                            AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a WHERE a.Usercode=b.empcode  AND a.ID='" & SanctionNote & "'")
                        Else

                            AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a WHERE a.EMPCODE=b.empcode AND a.userlevel=" & NextAuthLevel & " AND a.ID='" & SanctionNote & "'")
                        End If

                        Dim msg As String = "Sanction Note " & SanctionNote & " is due for approval. It was last approved by " & CurrentUserName & " and raised by " & RaisedByUserName

                        'If Len(AuthMob) >= 10 Then
                        '    sm.SendSMS(Session("CompanyCode"), ddlAuthBy.SelectedItem.Value, AuthMob, msg, "SanctionNote " & ddlAction.SelectedItem.Text & "ation Sent")
                        'End If
                    Catch
                        Scrpt = "alert('Unable to Send SMS Alert...!!!');"
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                    End Try

                    If AreaCode = 9999 Then
                        ' objFun.SendMailOPS(Body, "", SalePersonEmail, ddlAuthBy.selecteditem.value, "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-""  SortNo :-  ""' Shade :-  " & Shade & " was Reequested be Re-Planned in " & Area & " section and the request was generated by  " & UserName)
                    Else ' Else part executed for all sanction note other than Exceptions
                        Try
                            qry = "SELECT DESCRIPTION FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" & SanctionNote & "' AND STATUS='A'"
                            Dim Body1 As String = "Subject Mentioned :- " & Subject & " <hr><br><br> Under Area :-" & Area & " <BR> <HR> <b>With below detailed Info :-</b>" & objFun.FetchValue(qry) & " <hr>"
                            Dim Val1 As String = ""
                            Dim ParmName As String = ""
                            For i = 0 To GrdSanctionNoteDetail.Rows.Count - 1
                                ParmName = GrdSanctionNoteDetail.Rows(i).Cells(0).Text
                                Val1 = GrdSanctionNoteDetail.Rows(i).Cells(1).Text
                                Body1 = Body1 & "<p> <b>" & ParmName & " :-</b> " & Val1 & " </p> "
                            Next
                            Body3 = "<br/><a href='http://misdev/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

                            If (AreaCode = 1014) Then
                                '     SendMail("", SendMailTo, AuthorizedBy, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,jatindutta@jctltd.com", "SanctionNote :-" & SanctionNote & "  has been " & ddlAction.SelectedItem.Text & "", SanctionNote, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text)
                            Else
                                SendMail(Body, Body1, Body3, "", SendMailTo, AuthorizedBy, "hitesh@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,hiren@jctltd.com,sandeepr@jctltd.com", "This SanctionNote :-" & SanctionNote & "  has been " & ddlAction.SelectedItem.Text & "", SanctionNote, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text)
                            End If

                        Catch
                            Scrpt = "alert('Unable to Send E-Mail Alert...!!!');"
                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                        End Try
                    End If
                    RefreshLists()

                    'Else
                    '    Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');"
                    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
                    '    objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
                    '    Exit Sub
                    'End If
                    'Else
                    'Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');"
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
                    'objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
                    'Exit Sub
                    'End If
                End With
            Catch ex As Exception
                Scrpt = "alert('Unable to Complete Transaction...');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
                objFun.Alert("Unable to Complete Transaction...")
                ' ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
                Tran.Rollback()
            End Try

        Catch ex As Exception

            Dim Scrpt As String = "alert('" + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)

        End Try

    End Sub

    Private Sub RefreshLists()
       

        GridView1.DataSource = Nothing
        GridView1.DataBind()

        GrdSanctionNoteDetail.DataSource = Nothing
        GrdSanctionNoteDetail.DataBind()
    End Sub



    Private Sub SendMail(Body__1 As String, Body2 As String, body3 As String, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String, CurrentLevel As Int16, MaxLevel As Int16, NotifyAllList As String, Action As String)
        Try
            Dim from As String
            from = "noreply@jctltd.com"
            Dim query As String = ""
            Dim SenderEmail As String = ""

            If RaisedBy_Email Is Nothing Then
                RaisedBy_Email = ""
            End If

            'query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
            SenderEmail = [to] 'objFun.FetchValue(query)
            If SenderEmail Is Nothing Then SenderEmail = ""

            If SenderEmail <> "" Then

                'Email Address of Receiver
                [to] = SenderEmail '& " Comented by Ashish on 2nd Feb," & RaisedBy_Email
                '[to] = "jatindutta@jctltd.com"
                ' "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com"
                'Else
                '    'Email Address of Receiver
                '    [to] = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com," & Convert.ToString(SalesPerson_Email)
            Else
                [to] = RaisedBy_Email
                '[to] = "jatindutta@jctltd.com"
            End If
            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                [to] = NotifyAllList
                '[to] = "jatindutta@jctltd.com"
            End If

            bcc = "hitesh@jctltd@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,hiren@jctltd.com,sandeepr@jctltd.com"
            ' cc = "jatindutta@jctltd.com"
            '    subject = "Authorized Shortfall Request - " & Convert.ToString(OrderNo)

            'StringBuilder sb = new StringBuilder();
            'sb.Append("Hi,<br/>");
            'sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
            'sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
            'sb.Append("<br/>");
            'sb.Append("Thanking you<br/>");
            'sb.Append("IT");

            'body__2 = Body__1 

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
            mail.Body = Body__1 & " " & Body2 & " " & body3
            mail.IsBodyHtml = True
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            '       MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
            '/* Attach the newly created email attachment */      
            'mailMessage.Attachments.Add(attach);
            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                qry = "SELECT ImgName FROM Jct_Ops_SanctionNote_Attachments WHERE STATUS='A' AND SanctionNoteID='" & SanctionNote & "'"
                cmd = New SqlCommand(qry, obj.Connection)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read
                        Dim Atchment As Attachment = New Attachment(Server.MapPath("~\OPS\Upload\") & dr.Item(0))
                        mail.Attachments.Add(Atchment)
                    End While
                End If
                dr.Close()

            End If






            Dim SmtpMail As New SmtpClient("exchange2K7")

            '
            SmtpMail.Send(mail)
        Catch ex As Exception
            Dim Scrpt As String = "alert('" + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
        End Try
    End Sub



    Protected Sub CmdCancel_Click(sender As Object, e As System.EventArgs) Handles CmdCancel.Click
        RefreshLists()
      
    End Sub

   

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
       

        If e.Row.RowType = DataControlRowType.DataRow Then

            GridView1.DataKeyNames.Equals("SanctionNoteID")
            Dim SanctionID As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionNoteID"))

            Dim GridViewNested As GridView = DirectCast(e.Row.FindControl("nestedGridView"), GridView)
            GridViewNested.DataKeyNames.Equals("Description")
            qry = "Select Description from Jct_Ops_SanctionNote_HDR where status='A' and AuthFlag='P' and  sanctionNoteID ='" & SanctionID & "'"
            Dim cmd As New SqlCommand(qry, obj.Connection())
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            GridViewNested.DataSource = ds.Tables(0)
            GridViewNested.DataBind()


            Dim GridViewNested_MultipleID As GridView = DirectCast(e.Row.FindControl("nestedGridView_MultipleID"), GridView)
            GridViewNested_MultipleID.DataKeyNames.Equals("SanctionNoteID")
            qry = "SELECT COUNT(*) AS count FROM dbo.jct_ops_material_request WHERE RequestID='" & SanctionID & "'"
            Dim i As Int16 = objFun.FetchValue(qry)

            If i > 1 Then
                Dim lbl As Label = DirectCast(e.Row.FindControl("lbl"), Label)
                lbl.Visible = True
                lbl.ToolTip = "More than one invoices are in this request number. Expand to view Details..!!"
                qry = " SELECT invoice_no AS Invoice,item_no AS Sort,customer AS Customer,b.empname AS SalesPerson,invoice_qty AS InvoiceQty,ret_qty AS ReturnQty,reason AS Reason FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person = REPLACE(b.empcode, '-', '')   WHERE RequestID='" & SanctionID & "' "
                cmd = New SqlCommand(qry, obj.Connection())
                da = New SqlDataAdapter(cmd)
                ds = New DataSet()
                da.Fill(ds)
                GridViewNested_MultipleID.DataSource = ds.Tables(0)
                GridViewNested_MultipleID.DataBind()
            Else
                GridViewNested_MultipleID.DataSource = Nothing
                GridViewNested_MultipleID.DataBind()
            End If


        End If
    End Sub

    Protected Sub GrdAuthHistory_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdAuthHistory.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            GridView1.DataKeyNames.Equals("SanctionID")
            Dim SanctionID As [String] = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionID"))
            Dim UserLevel As [String] = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserLevel"))

            Dim GridViewNested As GridView = DirectCast(e.Row.FindControl("nestedRemarks"), GridView)
            GridViewNested.DataKeyNames.Equals("Remarks")
            qry = "SELECT ISNULL(Remarks,'No Remarks Given..!! or it may be pending for approval') as Remarks FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE ID='" + SanctionID + "' AND USERLEVEL=" + UserLevel + ""
            Dim cmd As New SqlCommand(qry, obj.Connection())
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            GridViewNested.DataSource = ds.Tables(0)

            GridViewNested.DataBind()
        End If

    End Sub

   

    Protected Sub cmdFetch_Click(sender As Object, e As System.EventArgs) Handles cmdFetch.Click
        qry = "SELECT b.EMPCODE,a.empname FROM  JCT_OPS_SanctionNote_AUTHORIZATION_LISTING b,dbo.JCT_EmpMast_Base a WHERE ID='" & txtSanctionNote.Text & "' AND a.empcode=b.EMPCODE"
        objFun.FillList(ddlAuthBy, qry)
        qry = "SELECT AreaCode,subject FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" & txtSanctionNote.Text & "'"
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            lblarea.Text = dr.Item(0)
            lblsubject.Text = dr.Item(1)
        End If
        dr.Close()
        'lblarea.Text = objFun.FetchValue(qry)

        qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" & txtSanctionNote.Text & "','" & lblarea.Text & "'"
        objFun.FillGrid(qry, GrdSanctionNoteDetail)
        qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & txtSanctionNote.Text & "'"
        objFun.FillGrid(qry, GrdAuthHistory)
    End Sub

    Protected Sub ddlAuthBy_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAuthBy.SelectedIndexChanged
        qry = "SELECT Remarks FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE ID='" & txtSanctionNote.Text & "' and empcode='" & ddlAuthBy.SelectedItem.Value & "' "
        txtRemarks.Text = objFun.FetchValue(qry)
    End Sub
End Class
