
Partial Class CostingSystemTest_SampleTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub Unnamed1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        GoogleDrivingDirections1.FromAddress = t1.Text
        GoogleDrivingDirections1.ToAddress = t2.Text

    End Sub
End Class
