Imports System
Imports System.Data.SqlClient
Imports System.Data
Partial Class OPS_RaiseSanctionNote
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction

    Protected Sub ddlarea_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlarea.SelectedIndexChanged
        If (ddlarea.SelectedItem.Text = "Greigh Transfer") Or (ddlarea.SelectedItem.Text = "PHouse Greigh Consumption") Then

            Response.Redirect("SaleOrderAdjustment10.aspx?Type=" & ddlarea.SelectedItem.Text)
        Else
            '  qry = "Select ParamCode ,ParmDesc,isnull(MultiValues,'')+'-'+isnull(ProcName,'') as Val FROM Jct_Ops_SanctionNote_Parameters where status='A' and AreaCode=" & ddlarea.SelectedItem.Value
            qry = "Select ParamCode ,ParmDesc,isnull(MultiValues,'')+'-'+isnull(ProcName,'') as Val FROM Jct_Ops_SanctionNote_Parameters where status='A' and AreaCode=" & ddlarea.SelectedItem.Value & " order by ParamCode "
            objFun.FillGrid(qry, grdParameters)
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            qry = "Select 0 as [AreaCode],'--Select--' as [AreaName] Union SELECT AreaCode,AreaName FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' ORDER BY AreaName"
            objFun.FillList(ddlarea, qry)
        End If
    End Sub

    Protected Sub cmdApply_Click(sender As Object, e As System.EventArgs) Handles cmdApply.Click
        Dim i As Int16
        i = 0
        Dim ParmCode As String = ""
        Dim SanctionID As String = ""
        Dim ddlVal As String = ""
        'qry = "SELECT TOP 1 Num FROM JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL"
        'SanctionID = objFun.FetchValue(qry)

        Tran = obj.Connection.BeginTransaction
        Try
            qry = "SELECT TOP 1 Num FROM JCT_OPS_SanctionNote_Codes WHERE   IsConsumed = 'N' AND DateConsumed IS NULL"
            SanctionID = objFun.FetchValue(qry, obj.Connection, Tran)
            

            qry = " exec Jct_Ops_SanctionNote_Insert_HDR '" & Session("Empcode") & "','" & ddlarea.SelectedItem.Value & "','" & txtSubject.Text & "','" & txtDescription.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & SanctionID & "'"
            objFun.InsertRecord(qry, Tran, obj.Connection)
            With grdParameters
                For i = 0 To .Rows.Count - 1
                    ParmCode = .Rows(i).Cells(0).Text
                    Dim ddlValueList As DropDownList = CType(.Rows(i).FindControl("ddlValueList"), DropDownList)
                    Dim txtValue As TextBox = CType(.Rows(i).FindControl("txtValue"), TextBox)

                    If ddlValueList.Visible = True Then
                        qry = "Exec Jct_Ops_SanctionNote_Insert_Dtl '" & SanctionID & "','" & ParmCode & "','" & ddlValueList.SelectedItem.Text & "'"
                    Else
                        qry = "Exec Jct_Ops_SanctionNote_Insert_Dtl '" & SanctionID & "','" & ParmCode & "','" & txtValue.Text & "'"
                    End If
                    objFun.InsertRecord(qry, Tran, obj.Connection)

                Next
                qry = "UPDATE  JCT_OPS_SanctionNote_Codes SET IsConsumed = 'Y',DateConsumed = GETDATE() WHERE   Num = '" & SanctionID & "'  "
                objFun.UpdateRecord(qry, Tran, obj.Connection)



                'body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>Sanction Note with ID  </b>      <b>orderNO :-</b> '" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Item & "' <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><B>Remarks For Dyeing :- </B>" & Remarks & "<B><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "' <b>Remarks For Finishing :- " & FinsRemarks & " <h3>This SaleOrder was Put into the Dyeing & Finishing plan by </h3> '" & EmpName & "' <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                'Qry = "SELECT sale_person_code FROM miserp.som.dbo.jct_so_team_catg WHERE order_no='" & OrderNo & "'"
                'Dim SalePersonCode As String = ""
                'Dim SalePersonEmail As String = "mkt-group@jctltd.com"
                'SalePersonCode = ObjFun.FetchValue(Qry)
                'If SalePersonCode Is Nothing Then SalePersonCode = ""
                'If SalePersonCode <> "mkt-group@jctltd.com" And CStr(SalePersonCode) <> "" Then
                '    SalePersonCode = Left(SalePersonCode, 1) & "-" & Right(SalePersonCode, Len(SalePersonCode) - 1)
                '    Qry = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & SalePersonCode & "' "
                '    SalePersonEmail = ObjFun.FetchValue(Qry)
                'End If
                'ObjFun.SendMailOPS(body, OrderNo, SalePersonEmail, Session("Empcode"), "rahuljindal@jctltd.com,rashpal@jctltd.com,karunarora@jctltd.com,khushwinder@jctltd.com,neeraj@jctltd.com,sobti@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Included in Dyeing & Finishing Plan")

            End With
            Tran.Commit()
            lblID.Text = SanctionID
            objFun.Alert("Record Saved Sucessfully !!")
        Catch ex As Exception
            Tran.Rollback()
            objFun.Alert("Unable to Complete Transaction " & ex.ToString)
        End Try

    End Sub

    Protected Sub grdParameters_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdParameters.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim HdnFld As String = CType(e.Row.FindControl("HiddenField1"), HiddenField).Value
            Dim ddlValue As DropDownList = CType(e.Row.FindControl("ddlValueList"), DropDownList)
            If Trim(HdnFld) <> "-" Then
                Try
                    qry = "Exec " & HdnFld.Substring(2)
                    objFun.FillList(ddlValue, qry)
                    ddlValue.Visible = True
                    CType(e.Row.FindControl("txtValue"), TextBox).Visible = False
                Catch ex As Exception
                    objFun.Alert("Unable To Fetch Values for " & e.Row.Cells(0).Text & "parameter")
                End Try
            End If
        End If
    End Sub
End Class
