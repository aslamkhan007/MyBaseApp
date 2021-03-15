
Partial Class OPS_Payment_Terms
    Inherits System.Web.UI.Page
    Dim ofn As New Functions

    Protected Sub ibtSave_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click

        Dim sqlstr As String = "jct_ops_create_quote @Customer_Code = '" & txtCustomer.Text & "'," & _
          "@Customer_Name = '" & lblCustomerName.Text & "'," & _
          "@Sales_Person_Code	='" & Session("EmpName") & "'," & _
          "@Sales_Person_Name	='" & Session("EmpName") & "'," & _
          "@Product_Catg =	'" & ddlProductCatg.SelectedItem.Text & "'," & _
          "@Plant	= '" & ddlPlant.SelectedItem.Text & "'," & _
          "@Item_Type	= '" & ddlItemType.SelectedItem.Text & "'," & _
          "@Item_Code	='" & txtItemCode.Text & "'," & _
          "@Item_Desc	='" & lblItemDescription.Text & "'," & _
          "@Blend	='" & txtBlend.Text & "'," & _
          "@Epi	=" & txtEPI.Text & "," & _
          "@Ppi	=" & txtPPI.Text & "," & _
          "@Gsm	=" & txtWeightGSM.Text & "," & _
          "@Weave	='" & txtWeave.Text & "'," & _
          "@Width	=	" & txtWidth.Text & "," & _
          "@DNV_Cost	=" & lblDnVCost.Text & "," & _
          "@User_Code	=	'" & Session("EmpName") & "'," & _
          "@Host_Ip	= '" & " " & "'," & _
          "@Revision_Remark= '" & txtRemark.Text & "'," & _
          "@Remark	= '" & txtRemark.Text & "'"

        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cn.ConOpen()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ofn.Alert(ex.Message)
        End Try
    End Sub

End Class
