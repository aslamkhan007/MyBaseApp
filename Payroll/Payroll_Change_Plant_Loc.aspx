<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Payroll_Change_Plant_Loc.aspx.cs" Inherits="Payroll_Payroll_Change_Plant_Loc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="6">
                Employee 
                Relocate:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updateplant" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                            onselectedindexchanged="ddlplant_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatelocation" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Name</td>
            <td class="labelcells">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                Card No</td>
            <td class="labelcells">
                <asp:Label ID="lblCardNo" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                EmployeeCode</td>
            <td class="labelcells">
                <asp:Label ID="lblEmployeeCode" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkChange" runat="server" CssClass="buttonc" OnClick="lnkChange_Click"
                            ValidationGroup="A">Apply</asp:LinkButton>
                        <%--<asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                            OnClick="lnkreset_Click">Reset</asp:LinkButton>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
