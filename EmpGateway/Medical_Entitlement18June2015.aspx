<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Medical_Entitlement.aspx.cs" Inherits="EmpGateway_Medical_Entitlement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="Medical Entitlement"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells" style="width: 125px">
                <asp:Label runat="server" Text="Effective From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 248px">
                <%--                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>--%>
                <asp:TextBox ID="txtFrom" runat="server" CssClass="textbox" Columns="10" MaxLength="10"></asp:TextBox>
                <cc11:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="txtFrom">
                </cc11:MaskedEditExtender>
                <cc11:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                    ControlToValidate="txtFrom" Display="Dynamic" EmptyValueMessage="ENTER DATE!!"
                    InvalidValueMessage="INVALID DATE" ValidationGroup="mandatory"></cc11:MaskedEditValidator>
                <cc11:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" TargetControlID="txtFrom">
                </cc11:CalendarExtender>
                <%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFrom"
                    ErrorMessage="**" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells" style="width: 93px; height: 16px;">
                <asp:Label ID="Label24" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Columns="10" MaxLength="10"
                    Width="68px"></asp:TextBox>
                <cc11:CalendarExtender ID="txtTo_CalendarExtender" runat="server" TargetControlID="txtTo">
                </cc11:CalendarExtender>
                <cc11:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="txtTo">
                </cc11:MaskedEditExtender>
                <cc11:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender1"
                    ControlToValidate="txtTo" Display="Dynamic" EmptyValueMessage="ENTER DATE!!"
                    InvalidValueMessage="INVALID DATE" ValidationGroup="mandatory"></cc11:MaskedEditValidator>
                <cc11:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo">
                </cc11:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTo"
                    ErrorMessage="**" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                <%--   <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" onclick="lnkExcel_Click">Excel</asp:LinkButton>--%>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" 
                    Text="Type Designation ..."></asp:Label>
            </td>
        </tr>
        <tr>
            <%--   <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" onclick="lnkExcel_Click">Excel</asp:LinkButton>--%>
        </tr>
        <tr>
            <td valign="top">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtDesignation" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                                    <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="16px"
                                        Width="16px" OnClick="cmdSearch_Click"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Both" Width="450px">
                                        <asp:CheckBoxList ID="ChkEmpList" runat="server" CellPadding="0" CellSpacing="0"
                                            Height="99px" RepeatColumns="1" Width="502px">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="labelcells" style="width: 125px">
                <asp:Label ID="Label25" runat="server" Text="Entitlement Amount"></asp:Label>
            </td>
            <td class="NormalText" style="width: 248px">
                <asp:TextBox ID="txtAmount" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                <cc11:FilteredTextBoxExtender ID="txtAmount_FilteredTextBoxExtender" runat="server"
                    FilterType="Custom" TargetControlID="txtAmount" ValidChars="0123456789">
                </cc11:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount"
                    ErrorMessage="**" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells" style="width: 83px; height: 16px;">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText" style="width: 166px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 78px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkAdd" runat="server" CssClass="buttonc" OnClick="lnkSearch_Click"
                            ValidationGroup="mandatory">Add</asp:LinkButton>
                        <asp:LinkButton ID="cmdReset" runat="server" BorderStyle="None" CssClass="buttonc"
                            OnClick="cmdReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--   <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" onclick="lnkExcel_Click">Excel</asp:LinkButton>--%>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" Height="300px" ScrollBars="Vertical">
                            <asp:GridView ID="grdDetail" runat="server" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="GirdItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
