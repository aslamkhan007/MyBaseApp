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
Partial Class OPS_CurrentProcessPlan
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

            Qry = "Select '' as Location,'' union  SELECT DISTINCT LOCATION,Location FROM JCT_OPS_MONTHLY_PLANNING order by  location"
            ObjFun.FillList(ddlPlant, Qry)

            Qry = "Delete from Jct_Ops_Temp_Insert " 'usercode='" & Session("Empcode") & "' and hostip='" & Request.ServerVariables("REMOTE_ADDR") & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Cmd.ExecuteNonQuery()

            txtEff_From.Text = Now.Date
            txtEff_To.Text = Now.Date
        End If
    End Sub

    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
        Dim OrdNo As String, CustCode As String, SaleTeam As String, SalePerson As String
        Dim HiddenField2 As HiddenField = New HiddenField
        'HiddenField2.Value = 0
        'HiddenField2 = CType(e.Item.FindControl("HiddenField2"), HiddenField)
        OrdNo = "0"
        CustCode = ""
        SaleTeam = ""
        SalePerson = ""

        If txtOrderNo.Text = "" Then
            OrdNo = "-All-"
        Else
            OrdNo = txtOrderNo.Text
        End If

        If txtCustomer.Text = "" Then
            CustCode = "-All-"
        Else
            CustCode = Right(txtCustomer.Text, Len(txtCustomer.Text) - InStr(txtCustomer.Text, "~")) 'txtCustomer.Text
        End If

        If ddlSalesPerson.SelectedItem.Text = "" Then
            SalePerson = "-All-"
        Else
            SalePerson = Trim(ddlSalesPerson.SelectedItem.Value)
        End If


      
        Qry = "SELECT OrderNo,LINEItem,Item,Shade,OrderQty,ReqDyngQty,Convert(Varchar(10),ReqDyngDate,101) as ReqDyngDate,Remarks,ReqFinishQty,Convert(Varchar(10),ReqFinishDate,101) as ReqFinishDate,FinsihRemarks,TransID FROM Jct_Ops_Planned_Processing_Orders a WHERE STATUS='A' and ReqDyngDate between '" & txtEff_From.Text & "' and '" & txtEff_To.Text & "' and Type='" & Left(ddlOPtion.SelectedItem.Text, 1) & "'"
        ObjFun.fillGrid(Qry, GridView1)
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim scrpt As String = ""
        Dim OrderNo As String, Item As String, Shade As String
        Dim OrderDate As String, ReqDyngDate As String, ReqFinishDate As String, Sort As String = ""
        Dim Line As Int16
        Dim OrderQty As Int64, IssuedMtr As Int64, DyngQty As Int64, FinsihQty As Int64, BalDyngQty As Int64, BalFinishQty As Int64
        Dim SalePersonCode As String = ""
        Dim SalePersonEmail As String = "mkt-group@jctltd.com"
        Dim Removedby As String = ""

        







        If e.CommandName = "Remove" Then
            Dim TransStatus As Boolean = False
            Dim EmpCode As String
            Dim index As Int16 = 0
            EmpCode = Trim(Session("Empcode"))

            Dim Str As String = ""
            Dim body As String = ""
            Qry = "exec JCt_Ops_Fetch_Order_ProcessPlan " & e.CommandArgument & ",'" & EmpCode & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Dr = Cmd.ExecuteReader
            If Dr.HasRows = True Then
                Dr.Read()
                OrderNo = Dr.Item(0)
                Line = Dr.Item(1)
                Sort = Dr.Item(2)
                Shade = Dr.Item(3)
                OrderQty = Dr.Item(4)
                DyngQty = Dr.Item(5)
                ReqDyngDate = Dr.Item(6)
                FinsihQty = Dr.Item(7)
                ReqFinishDate = Dr.Item(8)
                Removedby = Dr.Item("RemovedBy")
                SalePersonEmail = Dr.Item("EmailID")
                body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> '" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Sort & "' <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                Qry = "SELECT isnull(empcode,0)  FROM dbo.JCT_EmpMast_Base WHERE Active='Y' AND empcode LIKE '%" & EmpCode & "%' "
                If ObjFun.CheckRecordExistInTransaction(Qry) = True Then
                    If EmpCode = "0" Then
                        ObjFun.Alert("Employee Does Not Exist. Please select employee from List !!! ")
                        Exit Sub
                    Else
                        EmpCode = ObjFun.FetchValue(Qry)
                    End If
                Else
                    ObjFun.Alert("Unable To Continue !!! ")
                End If





                Qry = "Update Jct_Ops_Planned_Processing_Orders SET STATUS='D',DeletedOnHost='" & Request.ServerVariables("REMOTE_ADDR") & "',DeleteOnDate=getdate(),DeletedByUser='" & Session("Empcode") & "' where transid=" & e.CommandArgument
                TransStatus = ObjFun.UpdateRecord(Qry)

                If TransStatus = False Then


                    scrpt = "alert('Unable to Update Record')"
                    ObjFun.Alert("" & scrpt)
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
                End If
            Else
                Try
                    ObjFun.SendMailOPS(body, OrderNo, SalePersonEmail, Session("Empcode"), "rahuljindal@jctltd.com,rashpal@jctltd.com,karunarora@jctltd.com,khushwinder@jctltd.com,neeraj@jctltd.com,sobti@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Removed from  Dyeing & Finishing Plan")
                    scrpt = "alert(' Record Deleted..  ')"
                Catch ex As Exception
                    scrpt = "alert(' Record Deleted.. but Unable to Send Mail ')"
                End Try
                scrpt = "alert(' Record Deleted..  ')"
                ObjFun.Alert("" & scrpt)
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            End If
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class
