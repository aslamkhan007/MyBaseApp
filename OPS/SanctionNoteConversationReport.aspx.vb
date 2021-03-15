Imports System.Data.SqlClient
Imports System.Data

Partial Class OPS_SanctionNoteConversationReport
    Inherits System.Web.UI.Page


    Protected Sub dtlAttachment_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlAttachment.ItemCommand

        If e.CommandName = "Download" Then

            Dim filepath As String = Server.MapPath("~\\Ops\\Files\\" + txtSanctionID.Text + "\\")

            Dim strFileName As String = ""
            strFileName = e.CommandArgument

            Response.Redirect("QutationDownloadFile.aspx?filepath=" + filepath + "&FileName=" + strFileName)

            'End If

        End If

    End Sub
    Private Sub binddoc()
        Dim cn As New Connection
        Dim cn1 As New Connection
        Dim cmd1 As SqlCommand
        Dim sqlstr As String = " select RecordId,'Attachments' AS Attachment ,RefDocActFileName AS AttachedFile from jct_ops_ref_docs where basedocno = '" & txtSanctionID.Text & "' and status='A'"
        cmd1 = New SqlCommand(sqlstr, cn1.Connection)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        dtlAttachment.DataSource = ds.Tables(0)
        dtlAttachment.DataBind()
    End Sub

    Protected Sub cmdSubmit_Click(sender As Object, e As System.EventArgs) Handles cmdSubmit.Click
        If txtSanctionID.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Please Enter Sanction Note ID To View Documents');", True)
        Else
            binddoc()
        End If
    End Sub
End Class
