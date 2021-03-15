Imports System.Data.SqlClient
Imports System.IO
Partial Class SearchResult
    Inherits System.Web.UI.Page

    Dim obj As New Connection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        Dim qry As String
        qry = "SELECT a.shortdesc FROM JCT_Epor_MASTER_Dept a, jct_epor_master_employee b WHERE b.Emp_Code='" & Session("Empcode") & "' AND b.Dept_Code=a.Dept_Code AND a.Status=b.Status AND a.Status='A' "
        Dim storepath As String = Server.MapPath("~\DocMgmt\Upd\") & FetchValue(qry) & "\" & Session("Empcode") & "\" 'Server.MapPath("~") + "/Upd"
        If Not Directory.Exists(storepath) Then
            'FMsg.Message = "No such folder Exists!!"
            FMsg.Display()
        End If
        obj.ConOpen()

        qry = "select '" & storepath & "' + filename as url,case when right(filename,4) in ('docx','.doc') then 'DocMgmt/Image/Icons/icon-ms-word.gif' when right(filename,4) in ('xlsx','.xls') then 'DocMgmt/Image/Icons/icon-ms-excel.gif' when right(filename,4) in ('pptx','.ppt') then 'DocMgmt/Image/Icons/icon-ms-powerpoint.gif'" & _
            "  when right(filename,4) in ('mdbx','.mdb') then 'DocMgmt/Image/Icons/icon-ms-access.gif' else '" & storepath & "' + filename end as imgurl, filename as name from JCT_DMS_Trans_Upload a inner join JCT_DMS_Trans_Upload_Files b on a.transno=b.transno and a.status='' and b.status='' inner join jct_empmast_base c on a.empcode=c.empcode and c.active='Y' " & _
            "  where empname like '%" & Session("Empname") & "%' and a.filetype='" & Trim(Request.QueryString("catg")) & "'"
        Dim ds As Data.DataSet = FetchDS(qry)
        DataList1.DataSource = ds
        DataList1.DataBind()
        obj.ConClose()
    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Response.Redirect("Search.aspx")
    End Sub
End Class
