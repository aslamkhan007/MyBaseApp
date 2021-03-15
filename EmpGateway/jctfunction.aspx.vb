Imports System.Data.SqlClient

Partial Class jctfunction
    Inherits System.Web.UI.Page
    Dim obj As New Connection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim qry, qry1, qry2 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode") <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If
    End Sub
    Protected Sub btnsub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsub.Click
        obj.ConOpen()
        qry = "select functionname,parametername from JCT_Emp_Function_Parameter_Master where functionname='" & Me.ddlfnname.SelectedItem.Text & "' and parametername='" & Me.ddlparamtrname.SelectedItem.Text & "' and parametervalue='" & Me.txtparamtrvalue.Text & "'"
        cmd = New SqlCommand(qry, obj.Connection)

        dr = cmd.ExecuteReader
        If dr.HasRows = True Then

            qry1 = " update JCT_Emp_Function_Parameter_Master set status= 'd' , effto= getdate() where functionname='" & Me.ddlfnname.SelectedItem.Text & "' and parametername='" & Me.ddlparamtrname.SelectedItem.Text & "' and parametervalue='" & Me.txtparamtrvalue.Text & "'"
            cmd = New SqlCommand(qry1, obj.Connection)
            dr.Close()
            cmd.ExecuteNonQuery()
        Else
            dr.Close()
            qry2 = " insert into JCT_Emp_Function_Parameter_Master values('','" & Session("empcode") & "','" & Me.ddlfnname.SelectedItem.Text & "','" & Me.ddlparamtrname.SelectedItem.Text & "','" & Me.txtparamtrvalue.Text & "',getdate(),'12/31/3000','','',convert(varchar(10),''))"
            cmd = New SqlCommand(qry2, obj.Connection)
            cmd.ExecuteNonQuery()
        End If
        dr.Close()
    End Sub

   
End Class
