Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Partial Class OPS_SanctionNote_Preview
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim SanctionNoteID As String = Request.QueryString("SanctionID")
        Dim sqlstr As String = "Jct_Ops_SanctionNote_Detail '5KEARF16',1"
        Dim dr As SqlDataReader
        Try
            dr = ObjFun.FetchReader(sqlstr)
            If dr.HasRows() Then
                dr.Read()
                lblQuotationNo.Text = dr("SanctionNoteID")
                lblCurrentDate.Text = dr("CreatedOn")
                lblRaisedByCode.Text = dr("RaisedByCode")
                lblRaisedByEmpName.Text = dr("RaisedBy")
                lblDepartment.Text = dr("DEPTNAME")
                lblSubject.Text = dr("WithSubject")
                LblDescription.Text = dr("DESCRIPTION")
                lblPrintedOn.Text = dr("FetchedOn")
                'lblEpi.Text = dr("epi")
                'lblPpi.Text = dr("ppi")
                'lblGsm.Text = dr("gsm")
                'lblWidth.Text = dr("width") 
                'lblWeave.Text = dr("weave")
                'lblUnitPrice.Text = dr("sale_price")
                'lblDiscount.Text = dr("discount")
                'lblDiscountPc.Text = dr("discount_perc")
                'lblCurrency.Text = dr("currency")
                'lblNetUnitPrice.Text = Val(lblUnitPrice.Text) - Val(lblDiscount.Text)
            End If
            dr.Close()
            sqlstr = "Exec Jct_Ops_SanctionNote_Detail '5KEARF16',2 "
            ObjFun.FillGrid(sqlstr, GridView1)
            sqlstr = "Exec Jct_Ops_SanctionNote_Detail '5KEARF16',3 "
            ObjFun.FillGrid(sqlstr, GridView2)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmdXportPDF_Click(sender As Object, e As System.EventArgs) Handles cmdXportPDF.Click
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        Me.Page.RenderControl(hw)
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.[End]()
    End Sub
End Class
