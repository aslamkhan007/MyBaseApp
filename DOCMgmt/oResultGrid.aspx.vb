
Partial Class ResultGrid
    Inherits System.Web.UI.Page
    Dim qry As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("EmpCode") = "N-02632"
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        qry = "select empname as UploadBy, '~/upd/' + filepath as url,filepath as filename,case when right(filepath,4) in ('docx','.doc') then '~/upd/icon-ms-word.gif' when right(filepath,4) in ('xlsx','.xls') then '~/upd/icon-ms-excel.gif' when right(filepath,4) in ('pptx','.ppt') then '~/upd/icon-ms-powerpoint.gif'" & _
            "  when right(filepath,4) in ('mdbx','.mdb') then '~/upd/icon-ms-access.gif' when right(filepath,4)='.png' then '~/upd/Accessories-text-editor.png' WHEN right(filepath,4)='.jpg' THEN  '~/upd/forms.jpg'  else '~/upd/' + filepath end as img, convert(varchar(10),EnteredDt,101) as CreatedDt, KeyInfo,filerefno,transno, convert(varchar(10),FileRefDate,101) as FileRefDate from JCT_DMS_Trans_Upload a, jct_empmast_base b where a.empcode=b.empcode and b.active='y' and a.empcode='" & Session("EmpCode") & "' and status='' "
        FillGrid(qry, GrdResult)

    End Sub

    Protected Sub GrdResult_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdResult.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grd As GridView = CType(e.Row.FindControl("GrdFileDtl"), GridView)
            Dim lnk As HyperLink = CType(e.Row.FindControl("LnkTrans"), HyperLink)
            qry = "select fileno, filename,description, '~/upd/' + filename as url, '~/ResultFileDetail.aspx?TransNo=" & lnk.Text & "&flno=' + convert(varchar(5),fileno) as flurl from JCT_DMS_Trans_Upload_files where status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=" & lnk.Text & " order by fileno"
            FillGrid(qry, grd)
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='whitesmoke';this.style.cursor='pointer';")
        End If
    End Sub

    Protected Sub ImgExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Response.Redirect("search.aspx")
    End Sub
End Class
