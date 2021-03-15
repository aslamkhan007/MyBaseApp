<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="YearMaster.aspx.cs" Inherits="Courier_Tracking_System_YearMaster" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                <asp:Label ID="Label18" runat="server" Text="Year Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label19" runat="server" Text="Start Year"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtPrefix" runat="server" CssClass="NormalText" MaxLength="20"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtPrefix_FilteredTextBoxExtender" 
                    runat="server" FilterType="Numbers" TargetControlID="txtPrefix" 
                    ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtPrefix" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label20" runat="server" Text="End Year"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtPostfix" runat="server" CssClass="NormalText"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtPostfix_FilteredTextBoxExtender" 
                    runat="server" FilterType="Numbers" TargetControlID="txtPostfix" 
                    ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPostfix" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="NormalText" Width="300px"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="buttonc">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="buttonc">Edit</asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc">Delete</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:LinkButton ID="lnkFirst" runat="server" CssClass="buttonc">First</asp:LinkButton>
                <asp:LinkButton ID="lnkNext" runat="server" CssClass="buttonc">Next</asp:LinkButton>
                <asp:LinkButton ID="lnkPrevious" runat="server" CssClass="buttonc">Previous</asp:LinkButton>
                <asp:LinkButton ID="lnkLast" runat="server" CssClass="buttonc">Last</asp:LinkButton>
                <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc">Search</asp:LinkButton>
            </td>
        </tr>
    </table>

    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="3">
                <asp:Panel ID="Panel1" runat="server" CssClass="panelbg">
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridView" 
                        EnableModelValidation="True">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

