Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net
Partial Class OPS_Returned_Stock_Selling_Preview
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objfun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblQuotationNo.Text = Request.QueryString("SanctionID").ToString()

            qry = "SELECT a.SUBJECT,a.DESCRIPTION,b.empname,CreatedDate FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.JCT_EmpMast_Base b WHERE SanctionNoteID='" & Request.QueryString("SanctionID").ToString() & "' AND a.UserCode=b.empcode "
            cmd = New SqlCommand(qry, obj.Connection)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                lblSubject.Text = dr(0).ToString
                lblDescription.Text = dr(1).ToString
                lblCustomerName.Text = dr(2).ToString
                lblCurrentDate.Text = dr(3).ToString

            End If
            dr.Close()
            obj.ConClose()
        End If
    End Sub
End Class
