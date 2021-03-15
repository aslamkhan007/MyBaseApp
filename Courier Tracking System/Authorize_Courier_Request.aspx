<%@ Page Title="" Language="VB" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="false" CodeFile="Authorize_Courier_Request.aspx.vb" Inherits="Courier_Tracking_System_Authorize_Courier_Request" %>

<%@ Register Assembly="RichTextEditor" Namespace="AjaxControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label18" runat="server" Text="Authorize Courier Requests"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                <asp:Label ID="Label19" runat="server" Text="Select Courier Type"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Prepaid</asp:ListItem>
                    <asp:ListItem>COD</asp:ListItem>
                    <asp:ListItem>To Pay</asp:ListItem>
                    <asp:ListItem>To Pay COD</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                <asp:Label ID="Label20" runat="server" Text="Select Type"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Authorized</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="2">
                <asp:Panel ID="Panel1" runat="server" CssClass="panelbg">
                    <asp:GridView ID="GridView1" runat="server" 
    CssClass="GridViewStyle" EnableModelValidation="True" PageSize="5" AllowPaging="True" 
                        AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ref. No">
                                <ItemTemplate>
                                    <asp:Label ID="Label21" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Party Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label23" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Party Address">
                                <ItemTemplate>
                                    <asp:Label ID="Label22" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Courier Type">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="combobox">
                                        <asp:ListItem>Sample</asp:ListItem>
                    <asp:ListItem>Document</asp:ListItem>
                    <asp:ListItem>Lab Dip</asp:ListItem>
                    <asp:ListItem>Invoice</asp:ListItem>
                    <asp:ListItem>Purchase order</asp:ListItem>
                    <asp:ListItem>Item Repair</asp:ListItem>
                    <asp:ListItem>Credit Note</asp:ListItem>
                    <asp:ListItem>other</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Courier Service">
                             
                            
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="combobox">
                                     <asp:ListItem>DHL</asp:ListItem>
                    <asp:ListItem>First Flight</asp:ListItem>
                    <asp:ListItem>Blue Dart</asp:ListItem>
                    <asp:ListItem>UPS</asp:ListItem>
                    <asp:ListItem>TNT</asp:ListItem>
                    <asp:ListItem>TrackOn</asp:ListItem>
                    <asp:ListItem>On Dot</asp:ListItem>
                    <asp:ListItem>Fedex</asp:ListItem>
                    <asp:ListItem>Overnite</asp:ListItem>
                    <asp:ListItem>Other..</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                           
                            
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delivery Type">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="combobox">
                                      <asp:ListItem>Prepaid</asp:ListItem>
                    <asp:ListItem>Cash on Delivery</asp:ListItem>
                    <asp:ListItem>To Pay</asp:ListItem>
                    <asp:ListItem>To Pay COD</asp:ListItem>
                                   
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Courier Slip No.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSlipNo" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtSlipNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCost" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtCost" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle CssClass="FooterStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

