
Imports System.Data.SqlClient
Partial Class LostCustomerAnalysis
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Dim i As Integer, Check As Integer
    Public dr As SqlDataReader


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            DrpStatus.Items.Add("Lost")
            DrpStatus.Items.Add("Redeemable")
            Me.txtCust.Enabled = False
            obj.opencn()
            qry = "select  cust_name from miserp.som.dbo.m_customer where cust_status='o' and cust_no='" & Request.QueryString.Get("CustNo") & "'"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            'Me.DrpCustomers.Items.Clear()
            If dr.HasRows = True Then
                While dr.Read()
                    'Me.DrpCustomers.Items.Add(Trim(dr.Item(0)))
                    Me.txtCust.Text = Trim(dr(0))
                End While
            End If
            dr.Close()
            obj.closecn()

            obj.opencn()
            qry = "select distinct reason from jct_cust_lost_reason"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            'Me.DrpCustomers.Items.Clear()
            If dr.HasRows = True Then
                While dr.Read()
                    'Me.DrpCustomers.Items.Add(Trim(dr.Item(0)))
                    Me.DrpReason.Items.Add(Trim(dr(0)))
                End While
            End If
            dr.Close()
            obj.closecn()




            obj.opencn()
            qry = "select Mr_Mrs + empname + ':' + a.custstatus + ':' + convert(varchar(10),a.createddt,103),reason + ':' + ActionPlan  from Jct_Cust_Lost a, jct_empmast_base b where a.empcode=b.empcode and b.active='y' and  custno='" & Request.QueryString.Get("CustNo") & "'"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            'Me.DrpCustomers.Items.Clear()
            If dr.HasRows = True Then
                While dr.Read()
                    'Me.DrpCustomers.Items.Add(Trim(dr.Item(0)))
                    Me.txtHistory.Text = Me.txtHistory.Text & Environment.NewLine & dr(0) & " " & Environment.NewLine & dr(1)
                End While
            End If
            dr.Close()
            obj.closecn()
        End If
    End Sub

    Protected Sub cmdApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Check = fill()
        If Check = 1 Then Exit Sub
        obj.opencn()
        qry = "Insert into JCT_cust_lost(Companycode,empcode,custno,custstatus,reason,actionplan,createdDt,status) VALUES('JCT00LTD','" & Session("empcode") & "','" & Request.QueryString.Get("CustNo") & "','" & DrpStatus.SelectedValue & "','" & DrpReason.SelectedValue & "','" & txtAction.Text & "',getdate(),'')"
        cmd = New SqlCommand(qry, obj.cn)
        cmd.ExecuteNonQuery()
        obj.closecn()
    End Sub

    Public Function fill()
        If Trim(Me.txtAction.Text) = "" Then
            Response.Write("<script>alert('Please enter Subject of Survey!!')</script>")
            Me.txtAction.Focus()
            fill = 1
            Exit Function
        End If
        '' '' '' ''If Trim(Me.txtHistory.Text) = "" Then
        '' '' '' ''    Response.Write("<script>alert('Please enter Subject of Survey!!')</script>")
        '' '' '' ''    Me.txtHistory.Focus()
        '' '' '' ''    fill = 1
        '' '' '' ''    Exit Function
        '' '' '' ''End If
    End Function
End Class
