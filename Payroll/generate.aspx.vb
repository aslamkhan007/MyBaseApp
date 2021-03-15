Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Data
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Namespace HTMLtoPDF
    Partial Public Class ConvertHTMLtoPDF
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Protected Sub btnClick_Click(ByVal sender As Object, ByVal e As EventArgs)
            DownloadAsPDF()
        End Sub

        Public Sub DownloadAsPDF()
            Try
                Dim strHtml As String = String.Empty
                Dim pdfFileName As String = Request.PhysicalApplicationPath & "\files\" & "GenerateHTMLTOPDF.pdf"
                Dim sw As StringWriter = New StringWriter()
                Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
                dvHtml.RenderControl(hw)
                Dim sr As StringReader = New StringReader(sw.ToString())
                strHtml = sr.ReadToEnd()
                sr.Close()
                'CreatePDFFromHTMLFile(strHtml, pdfFileName)
                Response.ContentType = "application/x-download"
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename=""{0}""", "GenerateHTMLTOPDF.pdf"))
                Response.WriteFile(pdfFileName)
                Response.Flush()
                Response.[End]()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        'Public Sub CreatePDFFromHTMLFile(ByVal HtmlStream As String, ByVal FileName As String)
        '    Try
        '        Dim TargetFile As Object = FileName
        '        Dim ModifiedFileName As String = String.Empty
        '        Dim FinalFileName As String = String.Empty
        '        Dim builder As GeneratePDF.HtmlToPdfBuilder = New GeneratePDF.HtmlToPdfBuilder(iTextSharp.text.PageSize.A4)
        '        Dim first As GeneratePDF.HtmlPdfPage = builder.AddPage()
        '        first.AppendHtml(HtmlStream)
        '        Dim file As Byte() = builder.RenderPdf()
        '        File.WriteAllBytes(TargetFile.ToString(), file)
        '        Dim reader As iTextSharp.text.pdf.PdfReader = New iTextSharp.text.pdf.PdfReader(TargetFile.ToString())
        '        ModifiedFileName = TargetFile.ToString()
        '        ModifiedFileName = ModifiedFileName.Insert(ModifiedFileName.Length - 4, "1")
        '        iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, New FileStream(ModifiedFileName, FileMode.Append), iTextSharp.text.pdf.PdfWriter.STRENGTH128BITS, "", "", iTextSharp.text.pdf.PdfWriter.AllowPrinting)
        '        reader.Close()
        '        If File.Exists(TargetFile.ToString()) Then File.Delete(TargetFile.ToString())
        '        FinalFileName = ModifiedFileName.Remove(ModifiedFileName.Length - 5, 1)
        '        File.Copy(ModifiedFileName, FinalFileName)
        '        If File.Exists(ModifiedFileName) Then File.Delete(ModifiedFileName)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub

        Private Function dvHtml() As Object
            Throw New NotImplementedException
        End Function

    End Class
End Namespace
