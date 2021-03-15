Imports System.Data
Imports System.Data.SqlClient
Partial Class OPS_Order_Panel_Section
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim ObjFun As Functions = New Functions

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Qry = "SELECT module_name,module_name FROM production..modules WHERE Web_Flag='T' AND module_name<>'' ORDER BY module_name "
            ObjFun.FillList(ddlModule, Qry)
        End If

    End Sub

    Protected Sub ddlModule_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlModule.SelectedIndexChanged
        Qry = "SELECT DISTINCT RIGHT(Page_Name,LEN(Page_Name)-2) as Page_Name FROM dbo.JCT_Menu_Form_Mapping WHERE Module='" & ddlModule.SelectedItem.Value & "' order by page_name"
        ObjFun.FillList(ddlPageName, Qry)
    End Sub

    Protected Sub CmdSave_Click(sender As Object, e As System.EventArgs) Handles CmdSave.Click
        Dim ID As Integer
        ID = 0
        Qry = "Select max(ID) from Jct_Ops_OrderPanel_Sections "
        ID = ObjFun.FetchValue(Qry)
        Qry = "Insert into Jct_Ops_OrderPanel_Sections(UserCode ,Page_Name ,MODULE ,SECTION_Name ,CreatedDate ,Default_Seq ,host_IP,STATUS ,ID ,ProcedureUsed) values('" & Session("EmpCode") & "','" & ddlPageName.SelectedItem.Value & "','" & ddlModule.SelectedItem.Text & "','" & txtSectionName.Text & "',getdate(),'" & txtSeq.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','A'," & ID & ",'" & txtProcedureUsed.Text & "')"
        ObjFun.InsertRecord(Qry)

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        ddlModule.SelectedItem.Text = GridView1.SelectedRow.Cells(1).Text
        Qry = "SELECT DISTINCT RIGHT(Page_Name,LEN(Page_Name)-2) as Page_Name FROM dbo.JCT_Menu_Form_Mapping WHERE Module='" & GridView1.SelectedRow.Cells(1).Text & "' order by page_name"
        ObjFun.FillList(ddlPageName, Qry)
        ddlPageName.SelectedIndex = ddlPageName.Items.IndexOf(ddlPageName.Items.FindByText(GridView1.SelectedRow.Cells(3).Text)) 'GridView1.SelectedRow.Cells(3).Text
        txtSectionName.Text = GridView1.SelectedRow.Cells(2).Text
        txtProcedureUsed.Text = GridView1.SelectedRow.Cells(4).Text
        txtSeq.Text = GridView1.SelectedRow.Cells(5).Text
        CmdUpdate.Enabled = True

    End Sub

    Protected Sub CmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdUpdate.Click
        Qry = "Update Jct_Ops_OrderPanel_Sections set Status='U',Modified_By_User='J-01945',Modified_On_Date=getdate() where Module='" + GridView1.SelectedRow.Cells(1).Text + "' and page_name='" + GridView1.SelectedRow.Cells(3).Text + "' and section_name='" + GridView1.SelectedRow.Cells(2).Text + "' and ProcedureUsed='" + GridView1.SelectedRow.Cells(4).Text + "' and Default_Seq=" + GridView1.SelectedRow.Cells(5).Text + " and status='A'"
        ObjFun.UpdateRecord(Qry)

        Qry = "Select max(ID) from Jct_Ops_OrderPanel_Sections "
        ID = ObjFun.FetchValue(Qry)
        Qry = "Insert into Jct_Ops_OrderPanel_Sections(UserCode ,Page_Name ,MODULE ,SECTION_Name ,CreatedDate ,Default_Seq ,host_IP,STATUS ,ID ,ProcedureUsed) values('J-01945','" & ddlPageName.SelectedItem.Value & "','" & ddlModule.SelectedItem.Text & "','" & txtSectionName.Text & "',getdate(),'" & txtSeq.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','A'," & ID & ",'" & txtProcedureUsed.Text & "')"
        ObjFun.InsertRecord(Qry)
        Dim script1 As String = "alert('Record Updated.');"
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script1, True)
        GridView1.DataBind()
    End Sub

    Protected Sub CmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdDelete.Click
        Qry = "Update Jct_Ops_OrderPanel_Sections set Status='D',Modified_By_User='J-01945',Modified_On_Date=getdate() where Module='" + GridView1.SelectedRow.Cells(1).Text + "' and page_name='" + GridView1.SelectedRow.Cells(3).Text + "' and section_name='" + GridView1.SelectedRow.Cells(2).Text + "' and ProcedureUsed='" + GridView1.SelectedRow.Cells(4).Text + "' and Default_Seq=" + GridView1.SelectedRow.Cells(5).Text + " and status='A'"
        ObjFun.UpdateRecord(Qry)
        Dim script1 As String = "alert('Record Deleted.');"
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script1, True)
        GridView1.DataBind()
    End Sub
End Class
