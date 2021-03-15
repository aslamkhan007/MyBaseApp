<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Detailed_Info.aspx.vb" Inherits="Detailed_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="ParentDiv" 
        style="background-position: center 0px; width: 100%; height: 100%; vertical-align: middle; text-align: center; background-image: url('Image/Plain_Footer.png'); background-repeat: no-repeat;">
    <asp:DataList ID="dlsDetail" runat="server" CellPadding="0" RepeatColumns="1" RepeatDirection="Horizontal"
                    HorizontalAlign="Center" Height="16px" Width="100%">
        <ItemTemplate>
            <div style="height: 100%; width: 100%; text-align: left;">
                <div class="NormalText" style="background-position: center bottom; height: 100%;
                                width: 100%; text-align: left; background-repeat: no-repeat;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 1%;" 
                        frame="void">
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
                            <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png'); height: 2px;"
                                            valign="top" colspan="2">
                                <table cellpadding="0" cellspacing="0" 
                                                style="width: 100%; height: 1%; vertical-align: top;">
                                    <tr>
                                        <td style="vertical-align: top; font-weight : normal;">
                                            <br />
                                            <asp:Label ID="Label5" runat="server" 
                                                
                                                Text="text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. This is a sample text. "></asp:Label>
                                            <br />
                                        </td>
                                        <td style="width: 100px; text-align: right;" valign="top">
                                            <asp:Image ID="Image1" runat="server" Height="120px" Width="130px" ImageUrl="~/Image/login_icon.gif" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-position: left top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                                            background-repeat: no-repeat;">
                            </td>
                            <td style="background-position: right top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png'); background-repeat: no-repeat;">
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </div>
        </ItemTemplate>
    </asp:DataList>
    </div>
    
    </asp:Content>

