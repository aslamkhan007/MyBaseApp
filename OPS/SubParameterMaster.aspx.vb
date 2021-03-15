Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Class OPS_SubParameterMaster
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim Obj As Functions = New Functions


    Protected Sub ChkCopyValues_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChkCopyValues.CheckedChanged
        If ChkCopyValues.Checked = True Then
            TxtValue2.Text = TxtValue1.Text
            TxtValue2.Enabled = False
        Else
            TxtValue2.Text = ""
            TxtValue2.Enabled = True
        End If
    End Sub

    Protected Sub CmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Try
            Dim SubItem As String
            If DdlSubParam.Items.Count = 0 Then


                SubItem = ""
            Else
                SubItem = DdlSubParam.SelectedItem.Value

            End If

            If ddlType.SelectedIndex = 0 Then
                Qry = "exec JCT_OPS_Insert_Multi_Param_Values '" & ddlType.SelectedItem.Text & "','" & Session("EmpCode") & "','" & ddlParameter.SelectedItem.Value & "','" & SubItem & "',0,0,'" & TxtRemarks.Text & "','" & TxtEffFrom.Text & "','" & TxtEffTo.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & TxtValue1.Text & "' "
            Else
                Qry = "exec JCT_OPS_Insert_Multi_Param_Values '" & ddlType.SelectedItem.Text & "','" & Session("EmpCode") & "','" & ddlParameter.SelectedItem.Value & "','" & SubItem & "'," & TxtValue1.Text & "," & TxtValue2.Text & ",'" & TxtRemarks.Text & "','" & TxtEffFrom.Text & "','" & TxtEffTo.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','A' "
            End If
            Obj.InsertRecord(Qry)
            Dim script As String = "alert('Record Added Successfully.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
        Catch ex As Exception
            Dim script As String = "alert('" + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Qry = "SELECT PARAMETER_CODE,PARAMETER FROM JCT_OPS_MULTI_MASTER WHERE Status='A' AND PARENT_CATEGORY='None' order by parameter"
            Obj.FillList(ddlParameter, Qry)
        End If
    End Sub

    Protected Sub ddlParameter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlParameter.SelectedIndexChanged
        Qry = "SELECT PARAMETER_CODE,PARAMETER FROM JCT_OPS_MULTI_MASTER WHERE Status='A' AND PARENT_CATEGORY<>'None' and PARENT_CATEGORY='" & ddlParameter.SelectedItem.Value & "' order by parameter"
        Obj.FillList(DdlSubParam, Qry)
        If DdlSubParam.Items.Count = 0 Then
            DdlSubParam.Items.Add(" ")
        End If
    End Sub

   
    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        If ddlType.SelectedIndex = 0 Then
            Label7.Visible = False
            TxtValue2.Visible = False
            ChkCopyValues.Visible = False
        Else

            Label7.Visible = True
            TxtValue2.Visible = True
            ChkCopyValues.Visible = True

        End If

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        ddlParameter.SelectedIndex = ddlParameter.Items.IndexOf(ddlParameter.Items.FindByText(GridView1.SelectedRow.Cells(1).Text))
        If (GridView1.SelectedRow.Cells(2).Text = "") Then
            DdlSubParam.SelectedItem.Text = ""
        Else
            '  DdlSubParam.SelectedItem.Text = GridView1.SelectedRow.Cells(2).Text
        End If
            TxtValue1.Text = GridView1.SelectedRow.Cells(4).Text


        TxtValue2.Text = GridView1.SelectedRow.Cells(5).Text
        TxtRemarks.Text = GridView1.SelectedRow.Cells(6).Text
        TxtEffFrom.Text = GridView1.SelectedRow.Cells(7).Text
        TxtEffTo.Text = GridView1.SelectedRow.Cells(8).Text
        CmdUPdate.Enabled = True


    End Sub

    Protected Sub CmdUPdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdUPdate.Click
        Dim SubItem As String
        If DdlSubParam.Items.Count = 0 Then
            SubItem = ""
        Else
            SubItem = DdlSubParam.SelectedItem.Value
        End If
        Qry = "Update [JCt_OPS_Sub_Parameters] set Status='U',DeletionDate=getdate(),Deleting_User='J-01945' where ParamCode='" + ddlParameter.SelectedItem.Text + "'and SubParamCode='" + SubItem + "' and value1=" + TxtValue1.Text + " and value2=" + TxtValue2.Text + " and Status='A'"
        Obj.UpdateRecord(Qry)
        If ddlType.SelectedIndex = 0 Then
            Qry = "exec JCT_OPS_Insert_Multi_Param_Values '" & ddlType.SelectedItem.Text & "','J-01945','" & GridView1.SelectedRow.Cells(1).Text & "','" & SubItem & "',0,0,'" & TxtRemarks.Text & "','" & TxtEffFrom.Text & "','" & TxtEffTo.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & TxtValue1.Text & "' "
        Else
            Qry = "exec JCT_OPS_Insert_Multi_Param_Values '" & ddlType.SelectedItem.Text & "','J-01945','" & GridView1.SelectedRow.Cells(1).Text & "','" & SubItem & "'," & TxtValue1.Text & "," & TxtValue2.Text & ",'" & TxtRemarks.Text & "','" & TxtEffFrom.Text & "','" & TxtEffTo.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','A' "
        End If
        Obj.InsertRecord(Qry)
        Dim script1 As String = "alert('Record Updated.');"
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script1, True)
        GridView1.DataBind()
    End Sub

    Protected Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim SubItem As String
        If DdlSubParam.Items.Count = 0 Then
            SubItem = ""
        Else
            SubItem = DdlSubParam.SelectedItem.Value
        End If
        Qry = "Update [Jct_OPS_Sub_Parameters] set Status='D',DeletionDate=getdate(),Deleting_User='J-01945' where ParamCode='" + ddlParameter.SelectedItem.Text + "' and SubParamCode='" + SubItem + "' and value1 = " + TxtValue1.Text + " and value2 = " + TxtValue2.Text + " and Status='A'"
        Obj.UpdateRecord(Qry)
        Dim script1 As String = "alert('Record Deleted.');"
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script1, True)
        GridView1.DataBind()
    End Sub
End Class
