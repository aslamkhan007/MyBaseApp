<%@ Page Language="C#" AutoEventWireup="true" CodeFile="genpdf.aspx.cs" Inherits="Payroll_genpdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<div id="content">
    <h3>Sample h3 tag</h3>
    <p>Sample pararaph</p>
</div>
<div id="editor"></div>
<button id="cmd">Generate PDF</button>
<!--Add External Libraries - JQuery and jspdf 
check out url - https://scotch.io/@nagasaiaytha/generate-pdf-from-html-using-jquery-and-jspdf
-->
<script src="https://code.jquery.com/jquery-1.12.3.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/0.9.0rc1/jspdf.min.js"></script>