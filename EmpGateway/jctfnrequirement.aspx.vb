Imports System.Data.SqlClient
Imports System.Data
Partial Class jctfnrequirement
    Inherits System.Web.UI.Page
    Dim obj As New Connection
    Dim cmd As New SqlCommand
    Dim qry, qry1, qry2, qry3, qry4 As String
    Dim dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode") <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If

        If IsPostBack = False Then
            obj.ConOpen()
            qry = "select distinct itemname from jct_emp_function_requirement_master "
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    Dim lst As New ListItem
                    lst.Text = dr(0)
                    Me.ddlItemname.Items.Add(lst)
                End While
            End If
            dr.Close()
            Me.ddlItemname.Items.Add("Others")

            qry4 = "select distinct uom from jct_emp_function_requirement_master "
            cmd = New SqlCommand(qry4, obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    Dim lst As New ListItem
                    lst.Text = dr(0)
                    Me.ddluom.Items.Add(lst)
                End While
            End If
            dr.Close()
            Me.ddluom.Items.Add("Others")
        End If
    End Sub
    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click

        obj.ConOpen()
        qry1 = "select functionname,itemname,uom,rate,seq from jct_emp_function_requirement_master where functionname='" & Me.ddlfnname.SelectedItem.Text & "'and itemname='" & Me.ddlItemname.SelectedItem.Text & "'and uom='" & Me.ddluom.SelectedItem.Text & "'"
        cmd = New SqlCommand(qry1, obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then

            dr.Close()
            qry2 = " update jct_emp_function_requirement_master set status='d',effto=getdate()where functionname='" & Me.ddlfnname.SelectedItem.Text & "'and itemname='" & Me.ddlItemname.SelectedItem.Text & "' and uom='" & Me.ddluom.SelectedItem.Text & "'"
            cmd = New SqlCommand(qry2, obj.Connection)
            cmd.ExecuteNonQuery()
        Else
            dr.Close()

            qry3 = "insert into jct_emp_function_requirement_master values('','" & Session("empcode") & "','" & Me.ddlfnname.SelectedItem.Text & "','" & Me.txtothers.Text & "','" & Me.Txtuom.Text & "','" & Me.txtrate.Text & "','" & Me.txtseq.Text & "',getdate(),'12/31/3000','','',convert(varchar(10),''))"
            cmd = New SqlCommand(qry3, obj.Connection)
            cmd.ExecuteNonQuery()
        End If
        dr.Close()

    End Sub

   
    Protected Sub ddlItemname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemname.SelectedIndexChanged
        If Me.ddlItemname.SelectedItem.Text = "Others" Then
            Me.txtothers.Visible = True
        End If

    End Sub

    Protected Sub ddluom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddluom.SelectedIndexChanged
        If Me.ddluom.SelectedItem.Text = "Others" Then
            Me.Txtuom.Visible = True

        End If
    End Sub
End Class
