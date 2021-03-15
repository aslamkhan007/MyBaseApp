<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Fabrics_Particulars_FileUpload.aspx.cs" Inherits="Fabrics_Particulars_FileUpload" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td class="tableheader" colspan="4">
            <asp:Label ID="lblItemCode0" runat="server" 
                Text="Upload File  - Fabric Particular"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 85px">
            <asp:Label ID="lblItemCode" runat="server" Text="ITEM CODE "></asp:Label>
        </td>
        <td class="NormalText" style="width: 228px">
            <asp:TextBox ID="txtItemCode" runat="server" AutoPostBack="True" 
                ontextchanged="txtItemCode_TextChanged" 
                ToolTip="type atleast 2 digits to search an item from list" 
                CssClass="textbox"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="txtItemCode_AutoCompleteExtender" runat="server" 
                MinimumPrefixLength="2" ServiceMethod="OPS_Fabric_Items" ServicePath="~/webservice.asmx" 
                TargetControlID="txtItemCode">
            </cc1:AutoCompleteExtender>
        </td>
        <td class="NormalText" style="width: 65px">
            <asp:Label ID="lblDocType" runat="server" Text="DOC TYPE"></asp:Label>
        </td>
        <td class="NormalText">
            <asp:DropDownList ID="ddlDocType" runat="server" 
                ToolTip="Select a Value From The List" CssClass="combobox">
                <asp:ListItem>Specification</asp:ListItem>
                <asp:ListItem>Test Reports</asp:ListItem>
                <asp:ListItem>Process Charts</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 85px">
            <asp:Label ID="lblDocNo" runat="server" Text="DOC NO"></asp:Label>
        </td>
        <td class="NormalText" style="width: 228px">
            <asp:TextBox ID="txtDocNo" runat="server" ToolTip="Enter Numeric Values Only" 
                CssClass="textbox"></asp:TextBox>
        </td>
        <td class="NormalText" style="width: 65px">
            <asp:Label ID="lblRemark" runat="server" Text="REMARK"></asp:Label>
        </td>
        <td class="NormalText">
            <asp:TextBox ID="txtRemark" runat="server" ToolTip="Words less than 15 " 
                CssClass="textbox" ontextchanged="txtRemark_TextChanged"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 85px">
            <asp:Label ID="lblUploadFile" runat="server" Text="UPLOAD FILE"></asp:Label>
        </td>
        <td class="NormalText" style="width: 228px">
            <asp:FileUpload ID="FileUpload1" runat="server" 
                ToolTip="Browse to Select The To Upload" />
        </td>
        <td class="NormalText" style="width: 65px">
            &nbsp;</td>
        <td class="NormalText">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="buttonbackbar" colspan="4">
            <asp:LinkButton ID="lnkUpload" runat="server" CssClass="buttonc" 
                onclick="lnkUpload_Click">Upload</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td colspan="4" class="NormalText">
            <asp:GridView ID="grdfileUploadList" runat="server" Width="100%">
                <HeaderStyle CssClass="GridHeader" />
                <PagerStyle CssClass="PageStyle" />
                <RowStyle CssClass="GridItem" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 85px">
            &nbsp;</td>
        <td class="NormalText" style="width: 228px">
            &nbsp;</td>
        <td class="NormalText" style="width: 65px">
            &nbsp;</td>
        <td class="NormalText">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

