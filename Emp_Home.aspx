<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false"
    CodeFile="Emp_Home.aspx.vb" Inherits="oEmp_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="background-position: center 0px; width: 100%; vertical-align: middle;
        text-align: center; background-image: url('Image/Plain_Footer.png'); background-repeat: no-repeat;
        height: 2px;" cellpadding="0" cellspacing="0" frame="void">
        <tr>
            <td style="vertical-align: top">
             
              <%--  <table style="width: 100%; height: 200px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 250px; vertical-align: top;">
                            <asp:DataList ID="dlsLeft" runat="server" CellPadding="0" RepeatColumns="1" RepeatDirection="Horizontal"
                                HorizontalAlign="Left" Height="16px" Width="100%">
                                <ItemTemplate>
                                    <div style="height: 205px; width: 100%; text-align: left;">
                                        <div class="NormalText" style="background-position: center bottom; height: 300px;
                                            width: 100%; text-align: left; background-repeat: no-repeat;">
                                            <table cellpadding="0" cellspacing="0" style="width: 100%; height: 200px;">
                                                <tr>
                                                    <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                                        background-repeat: no-repeat;" rowspan="6">
                                                    </td>
                                                    <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                                        height: 37px; font-size: 3pt;" valign="middle" colspan="2">
                                                        <br />
                                                        <asp:Label ID="Label2" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small"
                                                            Text='<%# Eval("Data") %>'></asp:Label>
                                                    </td>
                                                    <td style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                                        background-position: left -4px; width: 28px;" rowspan="6">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');"
                                                        valign="top" colspan="2">
                                                        <div style="height: 140px; font-size: small;">
                                                            <br />
                                                            <asp:DataList ID="dlsEmpArea" runat="server" CellPadding="0" Height="31px" RepeatColumns="1"
                                                                Width="100%">
                                                                <ItemTemplate>
                                                                    <div class="NormalText" style="width: 100%; text-align: center; height: 25px;">
                                                                        <div id="Item" runat="server" style="display: inline-block; text-align: center; width: 100%;">
                                                                            <table cellpadding="0" cellspacing="0" style="width: 100%; height: 9px; vertical-align: top;">
                                                                                <tr>
                                                                                    <td style="text-align: left; height: 12px; width: 7%;" valign="top">
                                                                                        <asp:Image ID="imgIcon" runat="server" Height="16px" Width="16px" ImageUrl='<%# Eval("Icon") %>' />
                                                                                    </td>
                                                                                    <td style="text-align: left">
                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" Text='<%# Eval("Data") %>'
                                                                                            ToolTip="Click Here To View Details" PostBackUrl='<%# Eval("Url") %>'></asp:LinkButton>
                                                                                        &nbsp;
                                                                                        <asp:Label ID="Label4" runat="server" Font-Bold="False" ForeColor="#666666" Style="font-size: 7pt"
                                                                                            Text='<%# Eval("Data") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="background-position: left top; height: 30px; background-image: url('Image/Frame/Frame_Bottom.png');
                                                        background-repeat: no-repeat;">
                                                        &nbsp;
                                                    </td>
                                                    <td style="background-position: right top; height: 30px; background-image: url('Image/Frame/Frame_Bottom.png');
                                                        background-repeat: no-repeat;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td style="vertical-align: top; text-align: left;">
                            <asp:DataList ID="dlsRight" runat="server" CellPadding="0" RepeatColumns="1" HorizontalAlign="Center"
                                Height="16px" Width="100%">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 190px;" class="NormalText">
                                        <tr>
                                            <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                                background-repeat: no-repeat;" rowspan="6">
                                            </td>
                                            <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                                height: 37px; font-size: 3pt;" valign="middle" colspan="2">
                                                <br />
                                                <asp:Label ID="Label5" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small"
                                                    Text='<%# Eval("Data") %>'></asp:Label>
                                            </td>
                                            <td style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                                background-position: left -4px; width: 28px;" rowspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');
                                                vertical-align: top;" colspan="2">
                                                <table cellpadding="0" cellspacing="0" style="background-position: center top; width: 100%;
                                                    height: 140px; vertical-align: top; background-image: url('Image/Plain_Footer.png');
                                                    background-repeat: no-repeat;" frame="void">
                                                    <tr>
                                                        <td style="vertical-align: top; height: 100%;">
                                                            <asp:DataList ID="dlsNested" runat="server" RepeatColumns="5" Width="100%" OnItemCommand="dlsNested_ItemCommand"
                                                                 CellPadding="5" CellSpacing="-1">
                                                                <ItemTemplate>
                                                                    <a runat="server" href='<%# Eval("Url") %>' style="cursor: hand">
                                                                        <div id="Item" runat="server" style="width: 80px; text-align: center">
                                                                            
                                                                            <a id="A1" runat="server" href='<%# Eval("Url") %>' style="cursor: hand">
                                                                                <asp:Image ID="Image2" AlternateText='<%# Eval("Data") %>' runat="server" Height="48px"
                                                                                    ImageUrl='<%# Eval("Image") %>' Width="48px" />
                                                                                <br />
                                                                                <asp:HyperLink ID="LinkButton4" runat="server" Text='<%# Eval("Data") %>' NavigateUrl='<%# Eval("Url") %>'
                                                                                    CommandName="Select">
                                                                                </asp:HyperLink>
                                                                            </a>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("web_flag") %>' />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-position: left top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                                                background-repeat: no-repeat;">
                                            </td>
                                            <td style="background-position: right top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                                                background-repeat: no-repeat;">
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>--%>
            </td>
        </tr>
    </table>
</asp:Content>
