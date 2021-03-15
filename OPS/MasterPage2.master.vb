
Partial Class MasterPage2
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddBlurAtt(ContentPlaceHolder1)
    End Sub

    Public Sub AddBlurAtt(ByVal Cntrl As Control)

        If Cntrl.Controls.Count > 0 Then
            For Each ChildControl As Control In Cntrl.Controls
                AddBlurAtt(ChildControl)
            Next
        End If
        If Cntrl.[GetType]() Is GetType(TextBox) Then
            Dim TempTextBox As TextBox = DirectCast(Cntrl, TextBox)
            TempTextBox.Attributes.Add("onFocus", "DoFocus(this);")
            TempTextBox.Attributes.Add("onBlur", "DoBlur(this);")
        End If

    End Sub
End Class

