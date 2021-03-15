<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="ConvertHTMLtoPDF.aspx.cs" Inherits="Payroll_ConvertHTMLtoPDF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div id="dvHtml" runat="server" style="margin: 0 0 0 0;">
        <div>
            <b>CODE SCRATCHER</b><br />
            <br />
            Dear candidate,<br />
            <br />
            <b>After get material don't forget to Like on FB :</b> <a href="https://www.facebook.com/thecodescratcher"
                target="_blank" style="color: #292929; text-decoration: none;">https://www.facebook.com/thecodescratcher</a><br />
            <b>Visit this website:</b> <a href="http://www.codescratcher.com" target="_blank"
                style="color: #292929; text-decoration: none;">http://www.codescratcher.com</a><br />
            <br />
            You can get the different solutions with demo example source code from <a href="http://www.codescratcher.com"
                target="_blank" style="color: #292929; text-decoration: none;"><b>CODE SCRATCHER</b></a>. We will always with you, so share your problem with us and we will give you best
            solutions as soon as possible.<br />
            <br />
            Complete project download section comming soon.<br />
            <br />
            <b>Material with the download links are listed below.</b><br />
            <b>ASP.NET :</b><a href="http://www.codescratcher.com/asp-net-interview-questions"
                target="_blank" style="color: #292929; text-decoration: none;">http://www.codescratcher.com/asp-net-interview-questions</a><br />
            <b>C++ Language :</b> <a href="http://www.codescratcher.com/c-language-interview-questions-2"
                target="_blank" style="color: #292929; text-decoration: none;">http://www.codescratcher.com/c-language-interview-questions-2</a>
            <br />
            <b>C Language :</b> <a href="http://www.codescratcher.com/c-language-interview-questions"
                target="_blank" style="color: #292929; text-decoration: none;">http://www.codescratcher.com/c-language-interview-questions</a>
            <br />
            <b>SQL Server :</b><a href="http://www.codescratcher.com/sql-server-interview-questions"
                target="_blank" style="color: #292929; text-decoration: none;">http://www.codescratcher.com/sql-server-interview-questions</a><br />
            <b>HR Interview :</b> <a href="http://www.codescratcher.com/hr-interview-questions"
                target="_blank" style="color: #292929; text-decoration: none;">http://www.codescratcher.com/hr-interview-questions</a>
            <br />
            <br />
            <b>Like us on facebook :</b> <a href="https://www.facebook.com/thecodescratcher"
                target="_blank" style="color: #292929; text-decoration: none;">https://www.facebook.com/thecodescratcher</a><br />
            <b>Follow on Twitter :</b> <a href="https://twitter.com/codescratcher" target="_blank"
                style="color: #292929; text-decoration: none;">https://twitter.com/codescratcher</a><br />
            <b>Follow on Google+ :</b> <a href="https://plus.google.com/+Codescratcher" target="_blank"
                style="color: #292929; text-decoration: none;">https://plus.google.com/+Codescratcher</a><br />
            <br />
            <b>Thanks,<br /> Code Scratcher Team</b>
        </div>
    </div>
    <br />
    <br />
    <center>
        <asp:Button ID="btnClick" runat="server" OnClick="btnClick_Click" style="Height:30px" Text="HTML Download as PDF" />
    </center>
    </form>
</body>
</html>
</asp:Content>

