<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="po_job_work.aspx.cs" Inherits="OPS_po_job_work" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td colspan="4" class="tableheader">
                &nbsp;PO Allocation</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chksel" runat="server" AutoPostBack="True" 
                                        oncheckedchanged="chksel_CheckedChanged1" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PoNo">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtpo" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("Po_no") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GatePassNo">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtgatepass" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("gatepassno") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Waste%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtwaste" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("ActualWaste") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkclear" runat="server" CssClass="buttonc" 
                    onclick="lnkclear_Click">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

