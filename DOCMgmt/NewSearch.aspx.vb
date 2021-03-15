Imports System.Data.SqlClient
Partial Class Search
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim obj As New Connection
    Protected Sub LnkSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSearch.Click
        Dim pg, amt As String
        Dim ds As Data.DataSet
        'If Trim(Me.txtPgNo.Text) = "" Then
        '    pg = 0
        'Else
        pg = Trim(Me.txtPgNo.Text)
        'End If

        'If Trim(Me.txtAmt.Text) = "" Then
        '    amt = 0
        'Else
        amt = Trim(Me.txtAmt.Text)
        'End If
        '" where empname like '%" & Trim(Me.txtEmp.Text) & "%' and filerefno like '%" & Trim(Me.txtFileRef.Text) & "%' and filetype like '%' + right('" & Trim(Me.txtFileType.Text) & "',len('" & Trim(Me.txtFileType.Text) & "')-charindex('-->','" & Trim(Me.txtFileType.Text) & "')-2) + '%'" & " and department like '%" & Trim(Me.DrpDept.SelectedValue) & "%' " & _
        If Trim(Me.txtFileType.Text) <> "" Then
            qry = "select '~/upd/' + filename as url,case when right(filename,4) in ('docx','.doc') then '~/upd/icon-ms-word.gif' when right(filename,4) in ('xlsx','.xls') then '~/upd/icon-ms-excel.gif' when right(filename,4) in ('pptx','.ppt') then '~/upd/icon-ms-powerpoint.gif'" & _
                        "when right(filename,4) in ('mdbx','.mdb') then '~/upd/icon-ms-access.gif' else '~/upd/' + filename end as imgurl, filename as name from JCT_DMS_Trans_Upload a inner join JCT_DMS_Trans_Upload_Files b on a.transno=b.transno and a.status='' and b.status='' inner join jct_empmast_base c on a.empcode=c.empcode and c.active='Y' " & _
                        " where empname like '%" & Trim(Me.txtEmp.Text) & "%' and filerefno like '%" & Trim(Me.txtFileRef.Text) & "%' and filetype like '%' + right('" & Trim(Me.txtFileType.Text) & "',len('" & Trim(Me.txtFileType.Text) & "')-charindex('-->','" & Trim(Me.txtFileType.Text) & "')-2) + '%'" & " and department like '%" & Trim(Me.DrpDept.SelectedValue) & "%' " & _
                        " and (pagescnt='" & pg & "' or '" & pg & "'='') and (Amtinv='" & amt & "' or '" & amt & "'='') and filename like '%" & Trim(Me.txtFileName.Text) & "%' and description like '%" & Trim(Me.txtFileDesc.Text) & "%'" & _
                        " and (''='' or filerefdate='" & Trim(Me.txtRefDate.Text) & "')"

            ' Session("qry") = qry
            ds = FetchDS(qry)
            DataList1.DataSource = ds
            DataList1.DataBind()
            obj.ConClose()
        Else
            If Me.chkAll.Checked = True Then
                qry = "select shortdesc as catg, count(*) as cnt, '~/SearchResult.aspx?catg=' + filetype as lnk from JCT_DMS_Master_Category a,JCT_DMS_Trans_Upload b,JCT_DMS_Trans_Upload_files c where a.parentcatg+a.catg =b.filetype and a.status=b.status and a.status=c.status and b.status=c.status and a.status='' and b.transno=c.transno group by filetype,shortdesc"
            ElseIf Me.chkCatgWise.Checked = True Then
                qry = "select shortdesc as catg, count(*) as cnt, '~/ResultGrid.aspx?catg=' + filetype as lnk from JCT_DMS_Master_Category a,JCT_DMS_Trans_Upload b, JCT_DMS_Trans_Upload_files c where a.parentcatg+a.catg =b.filetype  and a.status=b.status and a.status=c.status and b.status=c.status and a.status='' and b.transno=c.transno group by filetype,shortdesc"
            End If

            ds = FetchDS(qry)
            DataList2.DataSource = ds
            DataList2.DataBind() '
            obj.ConClose()
        End If
        'Response.Redirect("SearchResult.aspx?qry=" & qry)
    End Sub

    Protected Sub chkCatgWise_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCatgWise.CheckedChanged
        If chkCatgWise.Checked = True Then
            chkAll.Checked = False
        End If
    End Sub

    Protected Sub chkAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked = True Then
            chkCatgWise.Checked = False
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
    End Sub
End Class
