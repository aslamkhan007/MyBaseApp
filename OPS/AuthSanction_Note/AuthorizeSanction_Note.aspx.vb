Imports System
Imports System.Data.SqlClient
Imports System.Reflection

Partial Class OPS_AuthorizeSanction_Note
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
        If (Session("empcode").ToString = "") Then
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then

        End If

        Dim AreaName As String = ""
        If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then

            AreaName = Request.QueryString("AreaName")
            GrdSanctionNoteDetail.DataSource = Nothing
            GrdSanctionNoteDetail.DataBind()
            qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
            objFun.FillGrid(qry, GridView1)

            ' remove query string
            Dim isreadonly As PropertyInfo = _
            GetType(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance Or BindingFlags.NonPublic)

            ' make collection editable
            isreadonly.SetValue(Me.Request.QueryString, False, Nothing)

            ' remove
            Me.Request.QueryString.Remove("AreaName")


        End If

    End Sub

    Protected Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Dim AreaName As String = ""
        If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then
            AreaName = Request.QueryString("AreaName")
            GrdSanctionNoteDetail.DataSource = Nothing
            GrdSanctionNoteDetail.DataBind()
            'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
            qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "
            objFun.FillGrid(qry, GridView1)
            objFun.FillGrid(qry, GridView1)
            Request.QueryString.Clear()
        Else

            If e.CommandName = "Select" Then
                AreaName = CType(e.Item.FindControl("cmdArea"), LinkButton).Text
                If AreaName <> "" And AreaName <> "Greigh Transfer" Then
                    GrdSanctionNoteDetail.DataSource = Nothing
                    GrdSanctionNoteDetail.DataBind()
                    'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
                    qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "
                    objFun.FillGrid(qry, GridView1)

                Else
                    Response.Redirect("AuthorizeSanctionNote10.aspx")
                End If
            End If

        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        qry = "SELECT b.ParmName,b.ParmDesc,a.Val as [Values] FROM dbo.Jct_Ops_SanctionNote_Dtl a,dbo.Jct_Ops_SanctionNote_Parameters b WHERE SanctionNoteID='" & Trim(GridView1.SelectedRow.Cells(1).Text) & "' AND b.STATUS='A' AND GETDATE() BETWEEN b.Eff_From AND b.Eff_To  AND a.ParamCode=b.ParamCode"
        objFun.FillGrid(qry, GrdSanctionNoteDetail)
    End Sub

    Protected Sub CmdAuthorize_Click(sender As Object, e As System.EventArgs) Handles CmdAuthorize.Click
        Dim NextAuthLevel As String = "None"
        Dim MaxAuthLevel As String = "None"
        Dim CurrentUserLevel As String = ""
        Dim AreaCode As String = ""
        Dim SanctionNote As String = ""
        Try

            With GridView1

                If .SelectedIndex > -1 Then
                    If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
                        SanctionNote = Trim(.SelectedRow.Cells(1).Text)
                        AreaCode = Trim(.SelectedRow.Cells(2).Text)
                        Tran = obj.Connection.BeginTransaction
                        con = obj.Connection


                        qry = "Select isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To and empcode='" & Session("Empcode") & "'"
                        CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

                        If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"

                        If CurrentUserLevel <> "None" Then
                            qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and GETDATE() BETWEEN Eff_From AND Eff_To and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' order by userlevel"
                            NextAuthLevel = objFun.FetchValue(qry, con, Tran)
                        Else
                            objFun.Alert("Unable to Your Authoirze...!!!")

                            Tran.Rollback()
                            Exit Sub
                        End If

                        qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To AND STATUS='a'"
                        MaxAuthLevel = objFun.FetchValue(qry, con, Tran)



                        If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
                            NextAuthLevel = "None"
                            objFun.Alert("Unable to Your Authoirze...!!!")
                            Tran.Rollback()
                            Exit Sub

                        ElseIf NextAuthLevel <> "None" And CurrentUserLevel <> MaxAuthLevel Then
                            qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='P',PendingAt='" & NextAuthLevel & "',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A' and AuthFlag='P'"
                            objFun.UpdateRecord(qry, Tran, con)
                            qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,AUTH_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                            objFun.InsertRecord(qry, Tran, con)
                        Else
                            qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='A',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
                            objFun.UpdateRecord(qry, Tran, con)
                            qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,AUTH_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                            objFun.InsertRecord(qry, Tran, con)
                        End If



                        'qry = "SELECT isnull(MAX(USERLEVEL)+1,999) FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  WHERE id='" & SanctionNote & "' AND AREACODE='" & AreaCode & "' AND STATUS IS null"
                        'CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

                        Tran.Commit()
                        RefreshLists()
                        objFun.Alert("SanctionNote Authorized...!!!")

                    Else
                        objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
                        Exit Sub
                    End If
                Else
                    objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            objFun.Alert("Unable to Complete Transaction...")
            ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
            Tran.Rollback()
        End Try
    End Sub

    Private Sub RefreshLists()
        DataList1.DataSource = Nothing
        DataBind()

        DataList1.DataSource = SqlDataSource2
        DataBind()

        GridView1.DataSource = Nothing
        GridView1.DataBind()

        GrdSanctionNoteDetail = Nothing
        GrdSanctionNoteDetail.DataBind()
    End Sub
End Class
