Imports System.Data.SqlClient
Partial Class Birthday_Card
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public ob As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Dim Obj2 As Functions = New Functions
    Dim i As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblTo.Text = lblTo.Text + " " + StrConv(Trim(obj2.Get_empname(Session("Empcode"), Session("Companycode"))), VbStrConv.ProperCase) + ","
        Me.Lbllocation.Text = Me.Lbllocation.Text + " " + Session("Loc")
        'lblMsg.Text = lblMsg.Text.Insert(8, " 19th August, 2008,")
        Dim DOB As String = Format(CDate(obj2.Get_dob(Session("Empcode"), Session("Companycode"))), "dd MMMM,")
        DOB = DOB + " " + DateTime.Today.Year.ToString + ", "
        lblMsg.Text = lblMsg.Text.Insert(9, DOB)
        If IsPostBack = False Then
            If Session("bflag") = 1 Then
                ob.opencn()
                qry = "update jct_empmast_base set BYear_Flag1=year(getdate()) where empcode='" & Session("Empcode") & "'"
                cmd = New SqlCommand(qry, ob.cn)
                cmd.ExecuteNonQuery()
                ob.closecn()
            ElseIf Session("bflag") = 2 Then
                ob.opencn()
                qry = "update jct_empmast_base set BYear_Flag2=year(getdate()) where empcode='" & Session("Empcode") & "'"
                cmd = New SqlCommand(qry, ob.cn)
                cmd.ExecuteNonQuery()
                ob.closecn()
            End If
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("default.aspx")
    End Sub
End Class
