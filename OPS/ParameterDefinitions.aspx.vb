Imports System
Imports System.Data.SqlClient
Imports System.Data
Partial Class OPS_ParameterDefinitions
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            qry = "SELECT AreaCode,AreaName FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' ORDER BY AreaName"
            objFun.FillList(ddlArea, qry)
        End If
    End Sub

    Protected Sub cmdReset_Click(sender As Object, e As System.EventArgs) Handles cmdReset.Click
        txtParameterName.Text = ""
        txtDescription.Text = ""
    End Sub

    Protected Sub cmdApply_Click(sender As Object, e As System.EventArgs) Handles cmdApply.Click
        Dim ID As Int16 = 101
        Dim scrpt As String
        qry = "Select isnull(max(ParamCode)+1,101) from Jct_Ops_SanctionNote_Parameters "
        ID = objFun.FetchValue(qry)

        qry = "Insert into Jct_Ops_SanctionNote_Parameters(UserCode ,AreaCode ,ParamCode,ParmName ,ParmDesc ,STATUS ,Eff_From ,Eff_To ,CreatedOnHost,MultiValues,ProcName ) values('" & Session("empcode") & "'," & ddlArea.SelectedItem.Value & "," & ID & ",'" & txtParameterName.Text & "','" & txtDescription.Text & "','A',getdate(),'12/31/2020','" & Request.ServerVariables("REMOTE_ADDR") & "','" & ddlText_Or_Not.SelectedItem.Value & "','" & txtProcedureName.Text & "' )"

        If objFun.InsertRecord(qry) = True Then
            scrpt = "Record Insert Successfully !!"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        Else
            scrpt = "Unable to insert Record !!"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", scrpt, True)
        End If
    End Sub

   
    Protected Sub ddlText_Or_Not_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlText_Or_Not.SelectedIndexChanged
        If ddlText_Or_Not.SelectedItem.Text = "Y" Then
            txtProcedureName.Text = ""
            txtProcedureName.Enabled = True
        Else
            txtProcedureName.Enabled = False
        End If
    End Sub
End Class
