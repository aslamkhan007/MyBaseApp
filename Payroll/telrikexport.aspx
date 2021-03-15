<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="telrikexport.aspx.cs" Inherits="Payroll_telrikexport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<telerik:RadEditor ID="RadEditor1" runat="server">
    <ExportSettings FileName="RadEditorExport" OpenInNewWindow="true"></ExportSettings>
</telerik:RadEditor>
<telerik:RadButton ID="ExportButton" Text="Export to pdf" OnClick="ExportButton_Click" runat="server"></telerik:RadButton>

</asp:Content>

