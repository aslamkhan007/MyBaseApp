Imports System
Imports System.Data.SqlClient


Partial Class OPS_AreaForSanctionNote
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection


    Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        qry = "SELECT empcode,empname+'~'+b.DEPTNAME FROM JCT_EmpMast_Base a,DEPTMAST b WHERE empname LIKE '" & txtEmployee.Text & "%' AND Active='y' AND a.deptcode=b.DEPTCODE ORDER BY empname"
        objFun.FillList(ChkEmpList, qry)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            txtEmployee.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + cmdSearch.UniqueID + "').click();return false;}} else {return true}; ")
            qry = "SELECT AreaCode,AreaName FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' ORDER BY AreaName"
            objFun.FillList(ddlParentArea, qry)
            ddlParentArea.Items.Insert(0, "None")
            qry = "SELECT  isnull(CONVERT(VARCHAR(10),ParentArea),'')  as ParentArea ,AreaCode,AreaName ,AreaDetail ,Qualitative ,DateValidation,CONVERT(VARCHAR,Eff_From,101) AS ValidFrom ,CONVERT(VARCHAR,Eff_To,101) AS ValidUpto FROM Jct_Ops_SanctioNote_Area_Master where status='A' order by AreaCode"
            objFun.FillGrid(qry, grdSavedRecords)

        End If
    End Sub

    Protected Sub btnTransfer_Click(sender As Object, e As System.EventArgs) Handles btnTransfer.Click
        
        Dim litem As ListItem
        For i As Int16 = 0 To ChkEmpList.Items.Count - 1
            If ChkEmpList.Items(i).Selected = True Then
                litem = New ListItem(ChkEmpList.Items(i).Text, ChkEmpList.Items(i).Value)
                lstSortedEmployees.Items.Add(litem)
            End If
        Next
    End Sub

    Protected Sub cmdClear_Click(sender As Object, e As System.EventArgs) Handles cmdClear.Click
        lstSortedEmployees.Items.Clear()
    End Sub

    Protected Sub cmdApply_Click(sender As Object, e As System.EventArgs) Handles cmdApply.Click
        Dim ID As Int32
        ID = 1000
        Dim scrpt As String = ""
        Dim tran As SqlTransaction
        Try
            qry = "Select isnull(max(AreaCode)+1,1001) from Jct_Ops_SanctioNote_Area_Master "
            ID = objFun.FetchValue(qry)
            tran = obj.Connection.BeginTransaction
            If ddlParentArea.SelectedItem.Value = "None" Then
                qry = "Insert into Jct_Ops_SanctioNote_Area_Master(UserCode,AreaCode ,AreaName ,AreaDetail ,Qualitative ,DateValidation ,STATUS ,Eff_From ,Eff_To ,CreatedOnHost) values('" & Session("empcode") & "'," & ID & ",'" & txtAreaName.Text & "','" & txtDescription.Text & "','" & ddlQualitative.SelectedItem.Value & "','" & ddlDurationSpecific.SelectedItem.Value & "','A',getdate(),'12/31/2020','" & Request.ServerVariables("REMOTE_ADDR") & "')"

            Else
                qry = "Insert into Jct_Ops_SanctioNote_Area_Master(UserCode,ParentArea ,AreaCode ,AreaName ,AreaDetail ,Qualitative ,DateValidation ,STATUS ,Eff_From ,Eff_To ,CreatedOnHost) values('" & Session("empcode") & "','" & ddlParentArea.SelectedItem.Value & "'," & ID & ",'" & txtAreaName.Text & "','" & txtDescription.Text & "','" & ddlQualitative.SelectedItem.Value & "','" & ddlDurationSpecific.SelectedItem.Value & "','A',getdate(),'12/31/2020','" & Request.ServerVariables("REMOTE_ADDR") & "')"
            End If

            cmd = New SqlCommand(qry, obj.Connection)
            cmd.Transaction = tran
            cmd.ExecuteNonQuery()
            For i As Int16 = 0 To lstSortedEmployees.Items.Count - 1
                qry = "Insert into Jct_Ops_SanctioNote_Area_Emp_Auth_Listing(UserCode ,AreaCode ,EmpCode ,UserLevel ,STATUS ,Eff_From ,Eff_To ,CreatedOnHost,PLANT ) values('" & Session("empcode") & "'," & ID & ",'" & lstSortedEmployees.Items(i).Value & "'," & i + 1 & ",'A',getdate(),'12/31/2020','" & Request.ServerVariables("REMOTE_ADDR") & "','" & ddlPlant.SelectedItem.Text & "' )"
                cmd = New SqlCommand(qry, obj.Connection)
                cmd.Transaction = tran
                cmd.ExecuteNonQuery()
            Next
            scrpt = "Record Insert Successfully !!"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            scrpt = "Unable to Insert  !!"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        Finally
            obj.Connection.Close()
        End Try
    End Sub

    Protected Sub cmdReset_Click(sender As Object, e As System.EventArgs) Handles cmdReset.Click
        txtAreaName.Text = ""
        txtDescription.Text = ""
        txtEmployee.Text = ""
        ChkEmpList.Items.Clear()
        lstSortedEmployees.Items.Clear()
    End Sub

    Protected Sub grdSavedRecords_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdSavedRecords.SelectedIndexChanged
        qry = "SELECT upper(a.EmpCode) as EmpCode,c.Empname,a.UserLevel FROM dbo.Jct_Ops_SanctioNote_Area_Emp_Auth_Listing a,Jct_Ops_SanctioNote_Area_Master b,dbo.JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS='A' AND a.STATUS=b.STATUS AND c.empcode=a.empcode AND a.AreaCode=" & grdSavedRecords.SelectedRow.Cells(2).Text & " and a.plant='" & ddlPlant.SelectedItem.Text & "' ORDER BY UserLevel"
        objFun.FillGrid(qry, GrdEmployee)
    End Sub
End Class
