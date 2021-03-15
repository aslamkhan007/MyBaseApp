Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Partial Class OPS_SanctionNote_Preview
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions


    Dim conjctgen As New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctgen").ConnectionString)

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim SanctionNoteID As String = Request.QueryString("SID")
        Dim sqlstr As String = "Jct_Ops_SanctionNote_Detail '" + SanctionNoteID + "',1"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, conjctgen)
        conjctgen.Open()
        Dim dr As SqlDataReader
        Try
            dr = cmd.ExecuteReader() 'ObjFun.FetchReader(sqlstr)
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
            sqlstr = "Exec Jct_Ops_SanctionNote_Detail '" + SanctionNoteID + "',2 "
            cmd = New SqlCommand(sqlstr, conjctgen)
            Dim ds As DataSet = New DataSet()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(ds)

            If (lblQuotationNo.Text.StartsWith("900") Or lblQuotationNo.Text.StartsWith("WR")) Then
                DataList1.DataSource = ds.Tables(0)
                DataList1.DataBind()
            Else
                GridView1.DataSource = ds.Tables(0)
                GridView1.DataBind()
            End If

            'ObjFun.FillGrid(sqlstr, GridView1)
            sqlstr = "Exec Jct_Ops_SanctionNote_Detail '" + SanctionNoteID + "',3 "
            cmd = New SqlCommand(sqlstr, conjctgen)
            ds = New DataSet()
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
            conjctgen.Close()

            'ObjFun.FillGrid(sqlstr, GridView2)

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
