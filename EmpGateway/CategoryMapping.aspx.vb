Imports System.Data.SqlClient
Imports System.IO
Partial Class CategoryMapping
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Dim i As Integer

    Protected Sub cmdMap_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMap.Click
        For i = 0 To Me.CheckBoxList1.Items.Count - 1
            If Me.CheckBoxList1.Items(i).Selected = True Then
                obj.opencn()
                qry = "insert into JCT_Emp_Catg_Desg_Mapping values ('JCT00LTD','" & Session("empcode") & "','" & Trim(Me.CheckBoxList1.Items(0).Text) & "','" & Trim(Me.DrpDesig.Text) & "','','08/01/2008','12/31/3000')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.ExecuteNonQuery()
                obj.closecn()
            End If
        Next
       
        Response.Write("<script>alert('Record Added Successfully..')</script>")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            obj.opencn()
            qry = "select distinct catg from jct_empmast_base where catg is not null and catg not in (select catg from JCT_Emp_Catg_Desg_Mapping where status='')"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            Me.CheckBoxList1.Items.Clear()
            If dr.HasRows = True Then
                While dr.Read()
                    Me.CheckBoxList1.Items.Add(Trim(dr.Item(0)))
                End While
            End If
            dr.Close()
            obj.closecn()
        End If
    End Sub
End Class
