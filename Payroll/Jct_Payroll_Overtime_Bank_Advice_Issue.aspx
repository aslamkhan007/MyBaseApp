<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Overtime_Bank_Advice_Issue.aspx.cs" Inherits="Payroll_Jct_Payroll_Overtime_Bank_Advice_Issue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td class="tableheader" colspan="6">
                Bank Advice
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtMonth" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    AutoPostBack="True" MaxLength="10" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMonth"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <%--    <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" Width="200px" 
                    onselectedindexchanged="ddlplant_SelectedIndexChanged">
                     </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlplant" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                        <%--<asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox" 
                    AutoPostBack="True" Width="200px" 
                    onselectedindexchanged="ddlLocation_SelectedIndexChanged">
                     </asp:DropDownList>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLocation"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Bank
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlbank" runat="server" CssClass="combobox" AutoPostBack="True"
                    Width="200px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlbank"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="LnkExcel" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="LnkExcel_Click" Enabled="False">Excel</asp:LinkButton>
                <asp:LinkButton ID="lnkPrint" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkPrint_Click">Print</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%" PageSize="30">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <%-- <tr>
            <td class="NormalText" colspan="6">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                        <Columns>
                            <asp:HyperLinkField HeaderText="Preview" Text="Preview" DataNavigateUrlFields="Srno"
                                DataNavigateUrlFormatString="Jct_Payroll_Conveyance_Voucher_Print.aspx?requestid={0}" DataTextField="Srno"
                                DataTextFormatString="Preview" Target="_blank" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>--%>
    </table>
</asp:Content>
