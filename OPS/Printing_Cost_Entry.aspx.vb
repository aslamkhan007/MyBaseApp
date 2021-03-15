Imports System.Data
Imports System.Data.SqlClient
Partial Class OPS_Printing_Cost_Entry
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim ObjFun As Functions = New Functions

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            Qry = "SELECT  PARAMETER_CODE , parameter FROM    JCT_OPS_MULTI_MASTER a  WHERE   a.status = 'A' AND UserCode='" & Session("EmpCode") & "'"
            ObjFun.FillList(ddlPrintingType, Qry)
            FillGrid()
        End If
    End Sub

    Protected Sub CmdApply_Click(sender As Object, e As System.EventArgs) Handles CmdApply.Click
        Qry = "Insert into JCt_OPS_Printing_Cost_TBL(UserCode ,ParameterCode ,Sort ,Cost ,Eff_From ,Eff_To ,STATUS) values('" & Session("EmpCode") & "','" & ddlPrintingType.SelectedItem.Value & "','" & TxtSort.Text & "'," & TxtCost.Text & ",Convert(Varchar(10),getdate(),101),'12/31/2030','A') "
        ObjFun.InsertRecord(Qry)
        FillGrid()
    End Sub
    Private Sub FillGrid()
        'Qry = "SELECT  ParameterCode as Category,Sort ,Cost ,Convert(varchar(10),Eff_From,101) EffectiveFrom ,Convert(varchar(10),Eff_To,101) as EffectiveTo FROM JCt_OPS_Printing_Cost_TBL order by Sort"
        'ObjFun.FillGrid(Qry, GrdDetail)
        GrdDetail.DataSource = SqlDataSource1
        GrdDetail.DataBind()
    End Sub
End Class
