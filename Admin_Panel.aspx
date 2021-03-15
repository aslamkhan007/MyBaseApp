<%@ Page Title="" Language="VB" MasterPageFile="~/User_Screen.master" AutoEventWireup="false" CodeFile="Admin_Panel.aspx.vb" Inherits="Admin_Panel" MaintainScrollPositionOnPostback="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 1%;" 
            class="NormalText" __designer:mapid="4a" frame="void">
    <tr __designer:mapid="4b">
        <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                                    height: 37px; font-size: 3pt;" 
                    valign="middle" colspan="2" __designer:mapid="4d">
            <br __designer:mapid="4e" />
            <asp:Label ID="Label14" runat="server" 
                        style="font-size: small; font-family: 'Trebuchet MS'" 
                Text="Area Details"></asp:Label>
            </td>
    </tr>
    <tr __designer:mapid="51">
        <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');"
                                                    valign="top" colspan="2" 
                    __designer:mapid="52">
            <table cellpadding="0" cellspacing="0" style="width:100%;">
                <tr>
                    <td style="width: 106px">
                                &nbsp;</td>
                    <td style="width: 167px">
                                &nbsp;</td>
                    <td style="width: 127px">
                                &nbsp;</td>
                    <td style="width: 269px">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                    </td>
                </tr>
                <tr>
                    <td style="width: 106px">
                        <asp:Label ID="Label6" runat="server" Text="Area"></asp:Label>
                    </td>
                    <td style="width: 167px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Width="119px" CssClass="textbox"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 127px">
                        <asp:Label ID="Label7" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td style="width: 269px">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 106px">
                        &nbsp;</td>
                    <td style="width: 167px">
                        &nbsp;</td>
                    <td style="width: 127px">
                        &nbsp;</td>
                    <td style="width: 269px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 106px; vertical-align: top;">
                                <asp:Label ID="Label19" runat="server" Text="Existing Areas"></asp:Label>
                    </td>
                    <td style="width: 167px">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="164px">
                                </asp:CheckBoxList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 127px">
                                &nbsp;</td>
                    <td style="width: 269px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 106px">
                                &nbsp;</td>
                    <td style="width: 167px">
                                &nbsp;</td>
                    <td style="width: 127px">
                        &nbsp;</td>
                    <td style="width: 269px">
                                &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center;" colspan="4">
                        <asp:LinkButton ID="LinkButton7" runat="server" CssClass="buttonc">Add</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="buttonc">Save</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton6" runat="server" CssClass="buttonc">View</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 106px">
                                &nbsp;</td>
                    <td style="width: 167px">
                                &nbsp;</td>
                    <td style="width: 127px">
                                &nbsp;</td>
                    <td style="width: 269px">
                                &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr __designer:mapid="5c">
        <td style="background-position: left top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                                                    background-repeat: no-repeat;" 
                    __designer:mapid="5d">
        </td>
        <td style="background-position: right top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                                                    background-repeat: no-repeat;" 
                    __designer:mapid="5e">
        </td>
    </tr>
</table>



    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 1%;" 
            class="NormalText" __designer:mapid="4a" frame="void">
    <tr __designer:mapid="4b">
        <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                                    height: 37px; font-size: 3pt;" 
                    valign="middle" colspan="2" __designer:mapid="4d">
            <br __designer:mapid="4e" />
            <asp:Label ID="Label15" runat="server" 
                        style="font-size: small; font-family: 'Trebuchet MS'" 
                Text="Sub Area Details"></asp:Label>
        </td>
    </tr>
    <tr __designer:mapid="51">
        <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');"
                                                    valign="top" colspan="2" 
                    __designer:mapid="52">
            <table cellpadding="0" cellspacing="0" style="width:100%;">
                <tr>
                    <td style="width: 115px">
                                &nbsp;</td>
                    <td style="width: 128px">
                                &nbsp;</td>
                    <td style="width: 103px">
                                &nbsp;</td>
                    <td style="width: 269px">
                                &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 115px">
                        <asp:Label ID="Label16" runat="server" Text="Sub Area"></asp:Label>
                    </td>
                    <td style="width: 128px">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 103px">
                        <asp:Label ID="Label17" runat="server" Text="Area"></asp:Label>
                    </td>
                    <td style="width: 269px">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownList2" runat="server" 
    style="margin-left: 0px" Width="173px" CssClass="combobox">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 115px">
                        <asp:Label ID="Label18" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td style="width: 128px">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 103px">
                        &nbsp;</td>
                    <td style="width: 269px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 115px">
                                &nbsp;</td>
                    <td style="width: 128px">
                                &nbsp;</td>
                    <td style="width: 103px">
                        &nbsp;</td>
                    <td style="width: 269px">
                                &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 115px">
                                &nbsp;</td>
                    <td style="width: 128px">
                                &nbsp;</td>
                    <td style="width: 103px">
                        &nbsp;</td>
                    <td style="width: 269px">
                                &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 115px">
                                &nbsp;</td>
                    <td style="width: 128px">
                                &nbsp;</td>
                    <td style="width: 103px">
                        &nbsp;</td>
                    <td style="width: 269px">
                                &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center;" colspan="4">
                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="buttonc">New</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton9" runat="server" CssClass="buttonc">Save</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton10" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton11" runat="server" CssClass="buttonc">View</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 115px">
                                &nbsp;</td>
                    <td style="width: 128px">
                                &nbsp;</td>
                    <td style="width: 103px">
                                &nbsp;</td>
                    <td style="width: 269px">
                                &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr __designer:mapid="5c">
        <td style="background-position: left top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                                                    background-repeat: no-repeat;" 
                    __designer:mapid="5d">
        </td>
        <td style="background-position: right top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                                                    background-repeat: no-repeat;" 
                    __designer:mapid="5e">
        </td>
    </tr>
</table>



    </asp:Content>

