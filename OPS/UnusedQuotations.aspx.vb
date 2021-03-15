Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI


Partial Class OPS_UnusedQuotations
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objfun As Functions = New Functions
    'Dim toEMail As String = "ashish@jctltd.com;jagdeep@jctltd.com;harendra@jctltd.com;rbaksshi@jctltd.com"
    'Dim byEmailID As String = "noreply@jctltd.com"
    'Dim objSendMail As SendMail = New SendMail
    Dim scrpt As String
    Dim empCode As String

    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
        qry = "SELECT  a.Quotation_No AS QuotaionNo, a.Customer_Code AS CustCode ,a.Customer_Name AS CustomerName ,a.Sales_Person_Code AS SPCode ,a.Sales_Person_Name AS SPName,a.Product_Catg AS Catg ,a.Item_Code AS Item ,a.Item_Desc AS Description,CONVERT(VARCHAR(10),a.Quot_Date,101) AS QuotDate FROM jct_ops_quotation_hdr a WHERE   a.Quotation_No NOT IN(SELECT Quotation_No FROM miserp.som.dbo.jct_quotations_order b where b.quotation_no=a.Quotation_No) ORDER BY Quot_Date desc"
        objfun.FillGrid(qry, GrdRecords)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
            objfun.FillList(ddlSalesPerson, qry)
        End If
    End Sub

    Protected Sub GrdRecords_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdRecords.RowCreated
       
    End Sub

    Protected Sub GrdRecords_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdRecords.RowDataBound

    End Sub

    Protected Sub GrdRecords_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdRecords.SelectedIndexChanged
        Response.Redirect("~\OPS\Quotation_main.aspx?quot=" & GrdRecords.SelectedRow.Cells(1).Text)
        '  
    End Sub
End Class
