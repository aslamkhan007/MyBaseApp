Imports System.Data
Imports System.Data.SqlClient
Partial Class EmpGateway_ReMapping
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim obj As Connection = New Connection
    Dim obj1 As Functions = New Functions


    Protected Sub lnkDeactivate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDeactivate.Click
        sql = "update jct_emp_hod set Eff_To = getdate() , Auth_Req='N' , Status='D' WHERE emp_code='" & txtEmpCode.Text & "' and status is null and Auth_req='Y'"
        If obj1.UpdateRecord(sql) = True Then
            lblError.Text = "" & txtEmpCode.Text & " is unmapped successfully."
        Else
            lblError.Text = "Some Error Occurred."
        End If
    End Sub
End Class
