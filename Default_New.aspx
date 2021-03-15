<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="false" CodeFile="Default_New.aspx.vb" Inherits="Default_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%; height: 500px;" cellpadding="0" cellspacing="0">
        <tr>
            <td class="style1" style="height: 500px; vertical-align: top;">
                <asp:DataList ID="DataList2" runat="server" CellPadding="0" RepeatColumns="2" RepeatDirection="Horizontal"
                    HorizontalAlign="Center" Height="16px" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 200px;">
                            <tr>
                                <td rowspan="6" 
                                    style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png'); background-repeat: no-repeat;">
                                </td>
                                <td colspan="2" 
                                    style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png'); height: 37px; font-size: 3pt;" 
                                    valign="middle">
                                    <br />
                                    <asp:Label ID="Label2" runat="server" 
                                        Style="font-family: 'Trebuchet MS'; font-size: small" 
                                        Text='<%# Eval("Data") %>'></asp:Label>
                                </td>
                                <td rowspan="6" 
                                    style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat; background-position: left -4px; width: 28px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" 
                                    style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');" 
                                    valign="top">
                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top">
                                                <%--<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" Style="font-size: 8pt;
                                                            text-align: left;">
                                                            <StaticMenuItemStyle CssClass="frame_tab_item" />
                                                            <DataBindings>
                                                                <asp:MenuItemBinding DataMember="MenuItem" TextField="text" 
                                                                    ToolTipField="text" />
                                                            </DataBindings>
                                                            <Items>
                                                                <asp:MenuItem Text="One" Value="One"></asp:MenuItem>
                                                                <asp:MenuItem Text="Two" Value="Two"></asp:MenuItem>
                                                            </Items>
                                                        </asp:Menu>--%>
                                                <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" 
                                                    Orientation="Horizontal" Style="font-size: 8pt;
                                                            text-align: left;">
                                                    <StaticMenuItemStyle CssClass="frame_tab_item" />
                                                    <DataBindings>
                                                        <asp:MenuItemBinding DataMember="MenuItem" TextField="text" ToolTipField="text" 
                                                            ValueField="value" />
                                                    </DataBindings>
                                                    <Items>
                                                        <asp:MenuItem Text="One" Value="One"></asp:MenuItem>
                                                        <asp:MenuItem Text="Two" Value="Two"></asp:MenuItem>
                                                    </Items>
                                                </asp:Menu>
                                                <asp:HiddenField ID="HiddenField1" runat="server" 
                                                    Value='<%# Eval("itemcode") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top">
                                                <asp:DataList ID="DataList3" runat="server" CellPadding="0" RepeatColumns="1" 
                                                    Width="100%">
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 42px;">
                                                            <tr>
                                                                <td style="text-align: left; height: 12px; width: 100%;" valign="top">
                                                                    <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# Eval("text") %>' 
                                                                        ToolTip="Click Here To View Details" Visible="False"></asp:LinkButton>
                                                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("url") %>' 
                                                                        Text='<%# Eval("text") %>'></asp:HyperLink>
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="False" ForeColor="#666666" 
                                                                        Style="font-size: 7pt" Text='<%# Eval("text") %>' Visible="False"></asp:Label>
                                                                </td>
                                                                <td rowspan="2">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 100%; height: 100px;" valign="top">
                                                                    <div style="height: 100%; width: 100%; font-weight: normal; overflow: hidden;">
                                                                        <%--<asp:Label ID="Label3" runat="server" Text="This is sample text. This is sample text. This is sample text. This is sample text. This is sample text. "></asp:Label>--%>
                                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("desc") %>'> </asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                            <td style="width: 100px;" valign="top">
                                                <asp:Image ID="Image1" runat="server" Height="120px" 
                                                    ImageUrl="~/Image/login_icon.gif" Width="130px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-position: left; height: 20px; background-image: url('Image/Frame/Frame_Bottom.png'); background-repeat: no-repeat;">
                                </td>
                                <td style="background-position: right; height: 20px; background-image: url('Image/Frame/Frame_Bottom.png'); background-repeat: no-repeat;">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

