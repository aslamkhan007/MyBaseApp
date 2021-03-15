<%@ Page Title="Income Tax Computations" Language="VB" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="false"
    CodeFile="Income_Tax_Computation.aspx.vb" Inherits="EmpGateway_Income_Tax_Computation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%; height: 10px;" class="NormalText">
        <tr>
            <td class="tableheader">
                Income Tax Computation<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>
            </td>
        </tr>
        </table>
    <table id = "ParamTab" style="width: 100%; height: 10px;" class="NormalText" 
        runat = "server">
        <tr>
            <td valign="top" style="width: 137px; height: 20px">
                <asp:Label ID="Label16" runat="server" Text="Employee Name &amp; Code"></asp:Label>
            </td>
            <td valign="top" style="height: 20px; width: 253px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmpName" runat="server" CssClass="textbox" MaxLength="30" 
                            Width="100%" AutoPostBack="True"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                            CompletionListCssClass="autocomplete_ListItem " ContextKey="" MinimumPrefixLength="0"
                            ServiceMethod="GetEmployeeName" ServicePath="~/WebService.asmx" 
                            TargetControlID="txtEmpName" FirstRowSelected="True">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" valign="top" style="height: 20px">
                        &nbsp;
                        <asp:LinkButton ID="lnkView" runat="server" CssClass="buttonc">View</asp:LinkButton>
            </td>
            <td class="NormalText" valign="top" style="height: 20px">
            </td>
        </tr>
        </table>
    <table style="width: 100%;" class="NormalText">
        <tr>
            <td class="NormalText" valign="top">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkView" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="txtEmpName" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
