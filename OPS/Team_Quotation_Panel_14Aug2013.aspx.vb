Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_Quotation_Panel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'grdOpenQuotes.DataBind()
        'grdUnauthorisedQuotes.DataBind()
        'grdAuthorisedQuotes.DataBind()

    End Sub

    Protected Sub grdOpenQuotes_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdOpenQuotes.RowDataBound

        'Dim imgValidity As Image = CType(e.Row.FindControl("imgValidity"), Image)
        'Dim imgPL As Image = CType(e.Row.FindControl("imgPL"), Image)
        'imgValidity.ImageUrl = ""
        'imgPL.ImageUrl = ""

    End Sub

    Protected Sub grdUnauthorisedQuotes_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdUnauthorisedQuotes.RowCommand

        Dim sqlstr As String = ""

        If e.CommandName = "Authorise" Then
            sqlstr = "jct_ops_authorise_quote"
        ElseIf e.CommandName = "Reject" Then
            sqlstr = "jct_ops_reject_quote"
        End If

        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)

        cmd.Parameters("@Quotation_no").Value = e.CommandArgument.ToString
        cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
        cmd.Parameters("@User_Type").Value = ""

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()
            grdUnauthorisedQuotes.DataBind()
            grdAuthorisedQuotes.DataBind()

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub

    Protected Sub ibtAuthorise_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs)

        'Dim sqlstr As String = "jct_ops_authorise_quote"
        'Dim cn As New Connection
        'Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        'cmd.CommandType = CommandType.StoredProcedure

        'cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        'cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        'cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)

        'cmd.Parameters("@Quotation_no").Value = e.CommandArgument.ToString
        'cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
        'cmd.Parameters("@User_Type").Value = "SP"

        'Try
        '    cn.ConOpen()
        '    cmd.ExecuteNonQuery()
        '    cn.ConClose()

        'Catch ex As Exception
        '    lblMessage.Text = ex.Message

        'End Try

    End Sub

    Protected Sub ibtReject_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

End Class
