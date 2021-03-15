Imports System
Imports System.Data.SqlClient

Partial Class OPS_Reason_Wise_Hierarchy
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection

    Protected Sub ddlarea_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlarea.SelectedIndexChanged
        qry = "SELECT ReasonCode,ReasonDesc + ' ' +Convert(varchar,ReasonCode) FROM dbo.Jct_Ops_Reason_Master WHERE SubArea='" & ddlarea.SelectedItem.Value & "'  AND STATUS='A'"
        objFun.FillList(ddlReason, qry)
        ddlReason_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            qry = "Select 0 as [AreaCode],'--Select--' as [AreaName] Union SELECT AreaCode,AreaName FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' and parentarea=1015 and areacode not in (1015,1018,1019,1020,1021,1014,1024,1023,1029) ORDER BY AreaName"
            objFun.FillList(ddlarea, qry)
        End If '
    End Sub

    Protected Sub ddlReason_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlReason.SelectedIndexChanged
        qry = "SELECT isnull(MAX(AuthLevel),0) FROM Jct_Ops_SanctionNote_Area_Reason_Hiearchy WHERE AreaCode='" & ddlarea.SelectedItem.Value & "' AND ReasonCode='" & ddlReason.SelectedItem.Value & "'"
        Label1.Text = objFun.FetchValue(qry)
        txtLevel.Text = Val(Label1.Text) + 1
        qry = "SELECT  c.AreaName,a.ReasonCode,b.ReasonDesc,a.EmpCode,d.empname,a.AuthLevel FROM    Jct_Ops_SanctionNote_Area_Reason_Hiearchy a,dbo.Jct_Ops_Reason_Master b,dbo.Jct_Ops_SanctioNote_Area_Master c,JCT_EmpMast_Base  d WHERE a.ReasonCode=b.ReasonCode  AND a.AreaCode=b.SubArea AND a.AreaCode=c.AreaCode AND c.STATUS='A' AND a.EmpCode=d.empcode  AND a.AreaCode='" & ddlarea.SelectedItem.Value & "' AND a.ReasonCode='" & ddlReason.SelectedItem.Value & "' and a.plant='" & ddlPlant.SelectedItem.Text & "'   ORDER BY CreatedDt"
        objFun.FillGrid(qry, GridView1)
    End Sub

    Protected Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        qry = "Insert into Jct_Ops_SanctionNote_Area_Reason_Hiearchy(UserCode,AreaCode,ReasonCode,EmpCode,AuthLevel,STATUS,CreatedDt,Plant) values ('" & Session("Empcode") & "','" & ddlarea.SelectedItem.Value & "','" & ddlReason.SelectedItem.Value & "','" & txtEmpcode.Text & "'," & txtLevel.Text & ",'A',GETDATE(),'" & ddlPlant.SelectedItem.Text & "')"
        cmd = New SqlCommand(qry, obj.Connection)
        cmd.ExecuteNonQuery()
        qry = "SELECT  c.AreaName,a.ReasonCode,b.ReasonDesc,d.empname,a.AuthLevel FROM    Jct_Ops_SanctionNote_Area_Reason_Hiearchy a,dbo.Jct_Ops_Reason_Master b,dbo.Jct_Ops_SanctioNote_Area_Master c,JCT_EmpMast_Base  d WHERE a.ReasonCode=b.ReasonCode  AND a.AreaCode=c.AreaCode AND c.STATUS='A' AND a.EmpCode=d.empcode  AND a.AreaCode='" & ddlarea.SelectedItem.Value & "' AND a.ReasonCode='" & ddlReason.SelectedItem.Value & "'   ORDER BY CreatedDt"
        objFun.FillGrid(qry, GridView1)
    End Sub

    Protected Sub ddlPlant_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPlant.SelectedIndexChanged
        qry = "SELECT  c.AreaName,a.ReasonCode,b.ReasonDesc,a.EmpCode,d.empname,a.AuthLevel FROM    Jct_Ops_SanctionNote_Area_Reason_Hiearchy a,dbo.Jct_Ops_Reason_Master b,dbo.Jct_Ops_SanctioNote_Area_Master c,JCT_EmpMast_Base  d WHERE a.ReasonCode=b.ReasonCode  AND a.AreaCode=b.SubArea AND a.AreaCode=c.AreaCode AND c.STATUS='A' AND a.EmpCode=d.empcode  AND a.AreaCode='" & ddlarea.SelectedItem.Value & "' AND a.ReasonCode='" & ddlReason.SelectedItem.Value & "' and a.plant='" & ddlPlant.SelectedItem.Text & "'   ORDER BY CreatedDt"
        objFun.FillGrid(qry, GridView1)
    End Sub
End Class
