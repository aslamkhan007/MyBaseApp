Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Image
Imports System.Drawing.Imaging
Partial Class frmInternet_Connection
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Public Sub GetEmpInfo()
        obj.opencn()
        qry = "select empname,deptcode from jct_empmast_base where empcode='" & Session("empcode") & "' "
        'qry = "select empname,deptcode from jct_empmast_base where empcode='A-00098'"

        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                Response.Write("<script>alert('Not A Valid User!!')</script>")
                Exit Sub
            Else
                txtEmpName.Text = dr.Item(0)
                txtDeptt.Text = dr.Item(1)
            End If
        Else

        End If
        dr.Close()
        obj.closecn()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        txtInfo.Text = "We are going to provide Internet connection with following facilities " & Environment.NewLine & "1) 1MBPS Internet Connection." & Environment.NewLine & "2)Unlimited download without any restriction." & Environment.NewLine & "3)Visit any site (no site restriction)" & Environment.NewLine & "4)Unlimited Internet Access " & Environment.NewLine & "--------------------------------------------------------------" & Environment.NewLine & "One Time installation charges depends upon number of users in your area. " & Environment.NewLine & "This amount will be reduced as the number of users increases (Cost of switch and network cable etc.).You can also pay this amount in 2-3 installments. " & Environment.NewLine & "Recurring monthly charges which may vary with number of persons ranging from Rs. 250/- to 300/-.(Minimum users 80 to 100)" & Environment.NewLine & "Interested persons may apply for this facility." & Environment.NewLine & "*Note: By clicking submit button in Employee Gateway, your request will be registered. "
        Dim Count As Int16
        count = 0
        obj.opencn()
        qry = "select count(*) from jct_emp_Internet_request where empcode='" & Session("empcode") & "' and status=''"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                'Response.Write("<script>alert('Not A Valid User!!')</script>")
                'Exit Sub
                Count = 0
            Else
                Count = dr.Item(0)
            End If
        Else
            Count = 1
        End If
        dr.Close()
        obj.closecn()
        If Count >= 2 Then
            Response.Redirect("default.aspx")
        End If
        GetEmpInfo()
    End Sub

    Protected Sub BtnFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFetch.Click
        Dim Trans_no As Int16
        obj.opencn()
        qry = "select max(trans_no) from jct_emp_Internet_request"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                'Response.Write("<script>alert('Not A Valid User!!')</script>")
                'Exit Sub
                Trans_no = 1
            Else
                Trans_no = dr.Item(0) + 1
            End If
        Else
            Trans_no = 1
        End If
        dr.Close()
        obj.closecn()
        obj.opencn()
        qry = "Insert into jct_emp_Internet_request(CompanyCode,Empcode,Need_Connection,query,date,Trans_no,status) values('JCT00LTD','" & Session("Empcode") & "','" & Left(cboChoiceList.SelectedItem.Text, 1) & "','" & txtQuery.Text & "',getdate()," & Trans_no & ",'')"
        cmd = New SqlCommand(qry, obj.cn)
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('Request For Internet Connection Applied !!')</script>")
        'Response.Redirect("default.aspx")
        obj.closecn()
        'Count------------------------
        Dim Count As Int16
        count = 0
        obj.opencn()
        qry = "select count(*) from jct_emp_Internet_request where empcode='" & Session("empcode") & "' and status=''"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                'Response.Write("<script>alert('Not A Valid User!!')</script>")
                'Exit Sub
                Count = 0
            Else
                Count = dr.Item(0)
            End If
        End If
        dr.Close()
        obj.closecn()
        If Count >= 2 Then
            Response.Redirect("default.aspx")
        End If
        ' end count
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class
