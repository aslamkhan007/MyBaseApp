<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Employee_Image_Upload.aspx.cs" Inherits="Payroll_Jct_Payroll_Employee_Image_Upload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
        <tr>
            <td class="tableheader" colspan="3">
                Employee Image Upload:
            </td>
        </tr>
        <tr>
           <td class="labelcells"> 
            </td>
             <td class="labelcells">
            </td>
        </tr>
          <tr>
            <td class="labelcells">
                <asp:Label ID="SrCode" runat="server" Text="Sr No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells" style="width: 188px">
                <asp:Label ID="SrId" runat="server" Visible="False"></asp:Label>
            </td>
       
        </tr>
        <tr>
            <td class="labelcells">
                Employee Code:
            </td>
            <td class="NormalText" style="width: 188px">
                <asp:TextBox ID="txtEmpCode" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    OnTextChanged="txtEmpCode_TextChanged" AutoPostBack="True" MaxLength="7"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpCode"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            </tr>
          
        <tr>
         <td class="labelcells">
                Browse File:
            </td>
        <td class="labelcells">
        <asp:FileUpload ID="FileUpload1" runat="server"/>
        </td>
        </tr>
        <tr>
         <td class="buttonbackbar" colspan="2">
          <asp:LinkButton ID="lnkUpload" runat="server" CssClass="buttonc" 
                 ValidationGroup="A" onclick="lnkUpload_Click">Upload</asp:LinkButton>
          <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                 OnClick="lnkdelete_Click" Enabled="False" Visible="False">Delete</asp:LinkButton>
           <asp:LinkButton ID="lnkDownload" runat="server" CssClass="buttonc" 
                 Enabled="False" onclick="lnkDownload_Click">Download</asp:LinkButton>
          <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton></td>
        </tr>
           <tr>
           <td class="labelcells"> 
            </td>
             <td class="labelcells">
            </td>
        </tr>
        <tr>
         <td class="labelcells" colspan="2">
       <asp:Image ID="Image1" runat="server" Visible="False" Height="50px" Width="50px" />
       </td>
        </tr>
        </table>
</asp:Content>

