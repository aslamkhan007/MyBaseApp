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
Partial Class OPS_Exception_By_PHouse
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim Qry As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand
    Dim Con As SqlConnection = New SqlConnection
    Dim ObjSendMail As SendMail = New SendMail
    Dim Tran As SqlTransaction
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~\Login.aspx")
        End If
        If Not IsPostBack Then

            Qry = " Select '' as [team_code],'' as [team_description] Union  SELECT rtrim(team_code),rtrim(team_description) FROM MISERP.SOM.DBO.jct_team_mASter  ORDER BY team_code   "
            ObjFun.FillList(ddlSalesTeam, Qry)
            If ddlSalesTeam.SelectedItem.Text = "" Then

                Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
                ObjFun.FillList(ddlSalesPerson, Qry)

            Else

                ddlSalesPerson.Items.Clear()
                Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT rtrim(a.sale_person_code),rtrim(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
                ObjFun.FillList(ddlSalesPerson, Qry)
            End If

            'Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            'ObjFun.FillList(ddlSalesPerson, Qry)

            'Qry = "Select '' as Location,'' union  SELECT DISTINCT LOCATION,Location FROM JCT_OPS_MONTHLY_PLANNING order by  location"
            'ObjFun.FillList(ddlPlant, Qry)

            Qry = "Delete from Jct_Ops_Temp_Insert " 'usercode='" & Session("Empcode") & "' and hostip='" & Request.ServerVariables("REMOTE_ADDR") & "'"
            Cmd = New SqlCommand(Qry, Obj.Connection)
            Cmd.ExecuteNonQuery()

            txtDateFrom.Text = Now.Date
            txtDateTo.Text = Now.Date
        End If
    End Sub
    Protected Sub lnkFetch_Click(sender As Object, e As System.EventArgs) Handles lnkFetch.Click
        Try
            Dim CustCode As String, SalePerson As String, OrderNo As String, Process As String, SaleTeam As String
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
            If ddlProcess.SelectedItem.Text = "" Then
                Process = ""
            Else
                Process = ddlProcess.SelectedItem.Text
            End If
            If ddlSalesTeam.SelectedItem.Text = "" Then
                SaleTeam = ""
            Else
                SaleTeam = Trim(ddlSalesTeam.SelectedItem.Value)
            End If
            ' Qry = "SELECT OrderNo,LINEItem,Item,Shade,OrderQty,ReqDyngQty,Convert(Varchar(10),ReqDyngDate,101) as ReqDyngDate,Remarks,ReqFinishQty,Convert(Varchar(10),ReqFinishDate,101) as ReqFinishDate,FinsihRemarks,TransID FROM Jct_Ops_Planned_Processing_Orders a WHERE STATUS='A' and ReqDyngDate between '" & txtDateFrom.Text & "' and '" & txtDateTo.Text & "' and Type='" & ddlProcess.SelectedItem.Text & "'"
            Qry = "Jct_Ops_Process_Plan_Exception_Fetch '" & SaleTeam & "','" & OrderNo & "','" & CustCode & "','" & SalePerson & "','','" & txtDateFrom.Text & "','" & txtDateTo.Text & "','" & Process & "' "
            ObjFun.FillGrid(Qry, GridView1)
        Catch ex As Exception
            ObjFun.Alert("Unable to Fetch Data....Some Error Occured..." & ex.ToString)
        
        End Try
    End Sub

    Protected Sub cmdApply_Click(sender As Object, e As System.EventArgs) Handles cmdApply.Click
        Dim ExceptionID As Int64
        Dim PlannedID As Int64
        Dim Scrpt As String = ""
        With GridView1
            If .SelectedIndex <> -1 Then
                Try
                    PlannedID = .SelectedRow.Cells(9).Text
                    Tran = Obj.Connection.BeginTransaction

                    Qry = "Select isnull(max(ExceptionID),7000)+1 from Jct_Ops_Process_Plan_Exception  "
                    Cmd = New SqlCommand(Qry, Obj.Connection, Tran)
                    Cmd.Transaction = Tran
                    ExceptionID = Cmd.ExecuteScalar
                    'If Dr.HasRows = True Then
                    '    Dr.Read()
                    '    ExceptionID = Dr.Item(0)
                    'End If


                    Qry = "Exec Jct_Ops_Process_Plan_Exception_Insert '" & Session("Empcode") & "','" & PlannedID & "','" & ExceptionID & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "','" & ddlProcess.SelectedItem.Text & "'"
                    Cmd = New SqlCommand(Qry, Obj.Connection, Tran)
                    Cmd.Transaction = Tran
                    Cmd.ExecuteNonQuery()
                    Scrpt = "Request Genrated Sucessfully...Status:- ---Pending For Approval---- "
                    Tran.Commit()

                Catch ex As Exception
                    Scrpt = "Some Error Occured !!!" & ex.ToString
                    Tran.Rollback()
                Finally
                    ObjFun.Alert(Scrpt)
                End Try
            Else
                Scrpt = "Please Select a record before proceding..."
                ObjFun.Alert(Scrpt)
            End If
        End With
    End Sub
    Protected Sub ddlSalesTeam_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSalesTeam.SelectedIndexChanged
        If ddlSalesTeam.SelectedItem.Text = "" Then

            ddlSalesPerson.Items.Clear()
            Qry = "Select '' as group_no, '' as group_desc Union SELECT RTRIM(group_no),RTRIM(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        Else
            ddlSalesPerson.Items.Clear()
            Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT RTRIM(a.sale_person_code),RTRIM(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        End If
    End Sub
 
End Class
