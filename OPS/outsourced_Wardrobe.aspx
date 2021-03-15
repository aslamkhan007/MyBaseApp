<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_Wardrobe.aspx.cs" Inherits="OPS_outsourced_Wardrobe" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="3">
                Wardrobe Items</td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:RadioButtonList ID="rdlst" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="rdlst_SelectedIndexChanged" CssClass="combobox" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="Marketing">Request by Mkt</asp:ListItem>
                    <asp:ListItem Value="Rawmaterial">Request by Raw material</asp:ListItem>
                </asp:RadioButtonList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="NormalText">
                <asp:Label ID="lbreq" runat="server" Text="RequestID" Visible="False"></asp:Label>
            </td>
            <td  class="NormalText">
                <asp:Label ID="lbID" runat="server" Text="ID" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  class="NormalText"  colspan="3">
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" onrowdatabound="grdDetail_RowDataBound" 
                    onrowcommand="grdDetail_RowCommand">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Remove" 
                                                ImageUrl="~/Image/Icons/close.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SortNo/DesignNo">
                            <ItemTemplate>
                                <asp:TextBox ID="txtsort" runat="server" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shade">
                            <ItemTemplate>
                                <asp:TextBox ID="txtshade" runat="server" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ReqQty">
                            <ItemTemplate>
                                <asp:TextBox ID="txttotqty" runat="server" CssClass="textbox"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txttotqty_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="txttotqty" 
                                    ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate/(mtrs)">
                            <ItemTemplate>
                                <asp:TextBox ID="txtrate" runat="server" CssClass="textbox"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtrate_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtrate" 
                                    ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="sale/(mtrs)">
                            <ItemTemplate>
                                <asp:TextBox ID="txtsale" runat="server" CssClass="textbox"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtsale_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtsale" 
                                    ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier">
                            <ItemTemplate>
                                <asp:TextBox ID="txtsuppplr" runat="server" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox" Height="50px" 
                                    TextMode="MultiLine" Width="150px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PaymentTerms">
                            <ItemTemplate>
                                <asp:TextBox ID="txtpayterm" runat="server" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FrieghtPaidBy">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlfreight" runat="server" CssClass="combobox">
                                    <asp:ListItem>Mill</asp:ListItem>
                                    <asp:ListItem>Customer</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EmptyDataTemplate>
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="Griditem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:LinkButton ID="lnkaddrw" runat="server" CssClass="buttonc" 
                    onclick="lnkaddrw_Click">AddRow</asp:LinkButton>
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnk_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkclear" runat="server" CssClass="buttonc" 
                    onclick="lnkclear_Click">Clear</asp:LinkButton>
            </td>
        </tr>
        </table>
</asp:Content>

