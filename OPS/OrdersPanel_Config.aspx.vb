Imports System.Data
Imports System.Data.SqlClient
Partial Class OPS_OrdersPanel_Config
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim ObjFun As Functions = New Functions
    Dim ObjCon As Connection = New Connection
    Dim Cmd As SqlCommand = New SqlCommand
    Dim Dr As SqlDataReader
    Protected Sub ddlModule_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlModule.SelectedIndexChanged
        Qry = "SELECT DISTINCT RIGHT(Page_Name,LEN(Page_Name)-2) as Page_Name FROM dbo.JCT_Menu_Form_Mapping WHERE Module='" & ddlModule.SelectedItem.Value & "' order by page_name"
        ObjFun.FillList(ddlPageName, Qry)
    End Sub

    Protected Sub CmdSave_Click(sender As Object, e As System.EventArgs) Handles CmdSave.Click
        Dim id As Int16
        id = 0
        Qry = "Select CASE WHEN a.id=b.ID THEN a.User_Seq ELSE 0 END AS Seq from Jct_OPS_OrdersPanel_Config a,Jct_Ops_OrderPanel_Sections b WHERE b.id=" & ddlSection.SelectedItem.Value & " AND MODULE='" & ddlModule.SelectedItem.Value & "' AND Page_Name='" & ddlPageName.SelectedItem.Value & "' and a.id=b.id and a.usercode='" & Session("Empcode") & "' "

        Cmd.CommandText = Qry
        Cmd.Connection = ObjCon.Connection
        Dr = Cmd.ExecuteReader()
        Dr.Read()
        If Dr.HasRows = True Then
            Qry = "Update Jct_OPS_OrdersPanel_Config set user_seq=" & txtCustomSeq.Text & ",no_of_records=" & txtNo_Of_Records.Text & " where id=" & id
            ObjFun.UpdateRecord(Qry)
        Else
            Qry = "Insert into Jct_OPS_OrdersPanel_Config(UserCode ,CreatedDate,ID,User_Seq,No_of_Records,host_IP,STATUS ) values('" & Session("EmpCode") & "',getdate(),'" & ddlSection.SelectedItem.Value & "'," & txtCustomSeq.Text & "," & txtNo_Of_Records.Text & ",'" & Request.ServerVariables("REMOTE_ADDR") & "','A')"
            ObjFun.InsertRecord(Qry)
        End If


    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Qry = "SELECT module_name,module_name FROM production..modules WHERE Web_Flag='T' AND module_name<>'' ORDER BY module_name "
            ObjFun.FillList(ddlModule, Qry)
        End If
    End Sub

    Protected Sub ddlPageName_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPageName.SelectedIndexChanged
        Qry = "SELECT id,SECTION_Name FROM Jct_Ops_OrderPanel_Sections   WHERE Module='" & ddlModule.SelectedItem.Value & "' and page_name='" & ddlPageName.SelectedItem.Value & "' order by page_name"
        ObjFun.FillList(ddlSection, Qry)
    End Sub

    Protected Sub ddlSection_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSection.SelectedIndexChanged
        txtCustomSeq.Text = ""
        Qry = "SELECT Default_Seq FROM Jct_Ops_OrderPanel_Sections  WHERE id=" & ddlSection.SelectedItem.Value & " AND MODULE='" & ddlModule.SelectedItem.Value & "' AND Page_Name='" & ddlPageName.SelectedItem.Value & "'"
        txtActualSeq.Text = ObjFun.FetchValue(Qry)
        Qry = "Select CASE WHEN a.id=b.ID THEN a.User_Seq ELSE b.Default_Seq END AS Seq from Jct_OPS_OrdersPanel_Config a,Jct_Ops_OrderPanel_Sections b WHERE b.id=" & ddlSection.SelectedItem.Value & " AND MODULE='" & ddlModule.SelectedItem.Value & "' AND Page_Name='" & ddlPageName.SelectedItem.Value & "' and a.id=b.id and a.usercode='" & Session("Empcode") & "' "
        Cmd.CommandText = Qry
        Cmd.Connection = ObjCon.Connection
        Dr = Cmd.ExecuteReader()
        Dr.Read()
        If Dr.HasRows = True Then
            txtCustomSeq.Text = Dr.Item(0)
        End If
    End Sub
End Class
