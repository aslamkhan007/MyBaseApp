Imports AjaxControlToolkit
Imports System.IO
Imports System.Data.SqlClient
Partial Class ResultGrid
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim qry1 As String


    Dim obj1 As Functions = New Functions()

    Dim dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        Dim qry As String
        'Dim storepath As String = Server.MapPath("~\DocMgmt\Upd\") & Session("Empcode") & "\"
        Dim storepath As String = Server.MapPath("~\dms\") & Session("Empcode") & "\"

        If Not Directory.Exists(storepath) Then
            Directory.CreateDirectory(storepath)
        End If
        Dim Dire() As DirectoryInfo
        Dim file() As FileInfo
        Dim i As Integer

        If storepath <> "" Then
            Dim dir As New DirectoryInfo(storepath)
            Dire = dir.GetDirectories()
            file = dir.GetFiles()
            If Dire.Length > 0 Then
                For i = 0 To Dire.Length - 1
                    Dire(i).Delete(True)
                Next
            End If
            If file.Length > 0 Then
                For i = 0 To file.Length - 1
                    file(i).Delete()
                Next
            End If
        End If


        ''To copy selected files to server to view them.
        qry = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','',' Select * from #t1 '"
        dr = FetchReader(qry)
        If dr.HasRows = True Then
            While dr.Read
                System.IO.File.Copy(dr(0), storepath & dr(1))
            End While
        End If
        dr.Close()

        'qry = "JCT_DMS_Search_File_Typewise '" & "~\DocMgmt\Upd\" & Session("Empcode") & "\','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','',' Select * from #t1 '"
        qry = "JCT_DMS_Search_File_Typewise '" & "d:\dms\" & Session("Empcode") & "\','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','',' Select * from #t1 '"

        FillGrid(qry, GrdResult)


    End Sub
    Public Function fileNameWithoutThePath(ByVal b As String) As String
        Dim j As Int16

        j = Convert.ToInt16(b.LastIndexOf("\"))
        Return b.Substring(j + 1)

    End Function

    Protected Sub GrdResult_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdResult.RowDataBound

        Dim storepath As String = "~\DocMgmt\Upd\" & Session("Empcode") & "\"
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grd As GridView = CType(e.Row.FindControl("GrdFileDtl"), GridView)
            Dim lnk As HyperLink = CType(e.Row.FindControl("LnkTrans"), HyperLink)
            qry = "select fileno, filename,description, '" & storepath & "' + filename as url, 'ResultFileDetail.aspx?TransNo=' + convert(varchar(10),a.transno) + '&flno=' + convert(varchar(5),fileno) + '&catg=" & Request.QueryString("catg") & "' as flurl from JCT_DMS_Trans_Upload_files a, JCT_DMS_Trans_Upload b where a.transno=b.transno and a.status='' and b.status='' and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and autofileno='" & lnk.Text & "' order by fileno"
            FillGrid(qry, grd)
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='whitesmoke';this.style.cursor='pointer';")
        End If
    End Sub

    Protected Sub ImgExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Response.Redirect("search.aspx")
    End Sub

    Protected Sub GrdResult_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdResult.SelectedIndexChanged

        qry = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','',' Select path from #t1 '"
        'qry1 = "JCT_DMS_Search_File_Move '" & "d:\dms\" & "','','','','','','" & Session("Empcode") & "','" & Request.QueryString("catg") & "','',' Select filename from #t1 '"""

        Dim filepath As String = obj1.FetchValue(qry)
        Dim filename As String = System.IO.Path.GetFileName(filepath)

        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename = {0}", System.IO.Path.GetFileName(filepath)))
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & System.IO.Path.GetFileName(filepath) & "")
        Response.TransmitFile(filepath)
        Response.End()


    End Sub
End Class
