<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="User_Screen_Sample.aspx.vb" Inherits="User_Screen_Sample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 242px;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 200px; vertical-align: top; height: 216px;">
                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 200px;" 
                    __designer:mapid="2f">
                    <tr __designer:mapid="30">
                        <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                                            background-repeat: no-repeat;" rowspan="6" 
                            __designer:mapid="31">
                        </td>
                        <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                                            height: 37px; font-size: 3pt;" 
                            valign="middle" colspan="2" __designer:mapid="32">
                            <br __designer:mapid="33" />
                            <asp:Label ID="Label15" runat="server" 
                                style="font-size: small; font-family: 'Trebuchet MS'; font-weight: 700" 
                                Text="Main Menu"></asp:Label>
                        </td>
                        <td 
                            style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                                            background-position: left -4px; width: 28px;" 
                            rowspan="6" __designer:mapid="35">
                        </td>
                    </tr>
                    <tr __designer:mapid="36">
                        <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');"
                                                            valign="top" colspan="2" 
                            __designer:mapid="37">
                            <div style="height: 143px; font-size: small;" __designer:mapid="38" dir="ltr">
                                &nbsp;
                                <asp:Menu ID="Menu1" runat="server" Height="112px" 
                                    style="text-align: left; font-family: Tahoma; font-size: 8pt; font-weight: 700" 
                                    Width="100%">
                                    <Items>
                                        <asp:MenuItem Text="Home" Value="Home"></asp:MenuItem>
                                        <asp:MenuItem Text="Masters" Value="Masters"></asp:MenuItem>
                                        <asp:MenuItem Text="Transactions" Value="Transactions"></asp:MenuItem>
                                        <asp:MenuItem Text="Reports" Value="Reports"></asp:MenuItem>
                                        <asp:MenuItem Text="Queries" Value="Queries"></asp:MenuItem>
                                    </Items>
                                </asp:Menu>
                                <asp:DataList ID="dlsEmpArea" runat="server" CellPadding="0" Height="31px" RepeatColumns="1"
                                                                    Width="100%">
                                    <ItemTemplate>
                                        <div class="NormalText" style="width: 100%; text-align: center; height: 25px;">
                                            <div id="Item0" runat="server" onclick="window.location.href = 'Default.aspx';" style="display: inline-block;
                                                                                text-align: center; width: 100%;">
                                                <table cellpadding="0" cellspacing="0" 
                                                    style="width: 100%; height: 9px; vertical-align: top;">
                                                    <tr>
                                                        <td style="text-align: left; height: 12px; width: 7%;" valign="top">
                                                            <asp:Image ID="imgIcon" runat="server" Height="16px" Width="16px" 
                                                                ImageUrl='<%# Eval("Icon") %>' />
                                                        </td>
                                                        <td style="text-align: left">
                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                            <asp:LinkButton ID="LinkButton3" runat="server" 
                                                                Text='<%# Eval("Data") %>' ToolTip="Click Here To View Details" PostBackUrl='<%# Eval("Url") %>'></asp:LinkButton>
                                                                                            &nbsp;
                                                                                            <asp:Label ID="Label4" runat="server" 
                                                                Font-Bold="False" ForeColor="#666666" Style="font-size: 7pt"
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
                    <tr __designer:mapid="45">
                        <td style="background-position: left top; height: 30px; background-image: url('Image/Frame/Frame_Bottom.png');
                                                            background-repeat: no-repeat;" 
                            __designer:mapid="46">
                                                            &nbsp;
                                                        </td>
                        <td style="background-position: right top; height: 30px; background-image: url('Image/Frame/Frame_Bottom.png');
                                                            background-repeat: no-repeat;" 
                            __designer:mapid="47">
                                                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top; text-align: left; height: 216px;">
        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 1%;" 
            class="NormalText" __designer:mapid="4a">
            <tr __designer:mapid="4b">
                <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                                    background-repeat: no-repeat;" rowspan="6" 
                    __designer:mapid="4c">
                </td>
                <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                                    height: 37px; font-size: 3pt;" 
                    valign="middle" colspan="2" __designer:mapid="4d">
                    <br __designer:mapid="4e" />
                    <asp:Label ID="Label14" runat="server" 
                        style="font-size: small; font-family: 'Trebuchet MS'" Text="Employee Detail"></asp:Label>
                </td>
                <td 
                    style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                                    background-position: left -4px; width: 28px;" 
                    rowspan="6" __designer:mapid="50">
                </td>
            </tr>
            <tr __designer:mapid="51">
                <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');"
                                                    valign="top" colspan="2" 
                    __designer:mapid="52">
                    <table cellpadding="0" cellspacing="0" style="width:100%;">
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label6" runat="server" Text="Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox1" runat="server" Width="239px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Age"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox2" runat="server" Width="211px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label8" runat="server" Text="Gender"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox3" runat="server" Width="181px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Date of Birth"></asp:Label>
                                .</td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox8" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label9" runat="server" Text="Father Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox4" runat="server" Width="214px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Mother Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox7" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Permanent
                                <asp:Label ID="Label10" runat="server" Text="Address"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox5" runat="server" Width="244px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Phone"></asp:Label>
                            &nbsp;No.</td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox6" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Current Address </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox9" runat="server" Width="240px"></asp:TextBox>
                            </td>
                            <td>
                                Qualifications</td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox10" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="buttonc">LinkButton</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton5" runat="server" CssClass="buttonc">LinkButton</asp:LinkButton>
                            </td>
                            <td style="width: 269px">
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="47px" Width="61px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
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
            </td>
        </tr>
        <tr>
            <td style="width: 200px">
                                &nbsp;
                            </td>
            <td>
                                &nbsp;
                            <table cellpadding="0" cellspacing="0" style="width: 100%; height: 1%;" 
            class="NormalText" __designer:mapid="4a">
            <tr __designer:mapid="4b">
                <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                                    background-repeat: no-repeat;" rowspan="6" 
                    __designer:mapid="4c">
                </td>
                <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                                    height: 37px; font-size: 3pt;" 
                    valign="middle" colspan="2" __designer:mapid="4d">
                    <br __designer:mapid="4e" />
                    <asp:Label ID="Label16" runat="server" 
                        style="font-size: small; font-family: 'Trebuchet MS'" Text="Employee Detail"></asp:Label>
                </td>
                <td 
                    style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                                    background-position: left -4px; width: 28px;" 
                    rowspan="6" __designer:mapid="50">
                </td>
            </tr>
            <tr __designer:mapid="51">
                <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');"
                                                    valign="top" colspan="2" 
                    __designer:mapid="52">
                    <table cellpadding="0" cellspacing="0" style="width:100%;">
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label17" runat="server" Text="Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox11" runat="server" Width="239px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="Age"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox12" runat="server" Width="211px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label19" runat="server" Text="Gender"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox13" runat="server" Width="181px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="Date of Birth"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox14" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label21" runat="server" Text="Father Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox15" runat="server" Width="214px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="Mother Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox16" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Permanent
                                <asp:Label ID="Label23" runat="server" Text="Address"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox17" runat="server" Width="244px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="Phone"></asp:Label>
                            &nbsp;No.</td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox18" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Current Address </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox19" runat="server" Width="240px"></asp:TextBox>
                            </td>
                            <td>
                                Qualifications</td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox20" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton6" runat="server" CssClass="buttonc">LinkButton</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton7" runat="server" CssClass="buttonc">LinkButton</asp:LinkButton>
                            </td>
                            <td style="width: 269px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
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
                            </td>
        </tr>
        <tr>
            <td style="width: 200px">
                                &nbsp;
                            </td>
            <td>
                                &nbsp;
                            <table cellpadding="0" cellspacing="0" style="width: 100%; height: 1%;" 
            class="NormalText" __designer:mapid="4a">
            <tr __designer:mapid="4b">
                <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                                    background-repeat: no-repeat;" rowspan="6" 
                    __designer:mapid="4c">
                </td>
                <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                                    height: 37px; font-size: 3pt;" 
                    valign="middle" colspan="2" __designer:mapid="4d">
                    <br __designer:mapid="4e" />
                    <asp:Label ID="Label25" runat="server" 
                        style="font-size: small; font-family: 'Trebuchet MS'" Text="Employee Detail"></asp:Label>
                </td>
                <td 
                    style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                                    background-position: left -4px; width: 28px;" 
                    rowspan="6" __designer:mapid="50">
                </td>
            </tr>
            <tr __designer:mapid="51">
                <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');"
                                                    valign="top" colspan="2" 
                    __designer:mapid="52">
                    <table cellpadding="0" cellspacing="0" style="width:100%;">
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label26" runat="server" Text="Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox21" runat="server" Width="239px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label27" runat="server" Text="Age"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox22" runat="server" Width="211px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label28" runat="server" Text="Gender"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox23" runat="server" Width="181px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label29" runat="server" Text="Date of Birth"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox24" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                <asp:Label ID="Label30" runat="server" Text="Father Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox25" runat="server" Width="214px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label31" runat="server" Text="Mother Name"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox26" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Permanent
                                <asp:Label ID="Label32" runat="server" Text="Address"></asp:Label>
                            </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox27" runat="server" Width="244px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label33" runat="server" Text="Phone"></asp:Label>
                            &nbsp;No.</td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox28" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Current Address </td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox29" runat="server" Width="240px"></asp:TextBox>
                            </td>
                            <td>
                                Qualifications</td>
                            <td style="width: 269px">
                                <asp:TextBox ID="TextBox30" runat="server" Width="239px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton8" runat="server" CssClass="buttonc">LinkButton</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton9" runat="server" CssClass="buttonc">LinkButton</asp:LinkButton>
                            </td>
                            <td style="width: 269px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 269px">
                                &nbsp;</td>
                            <td>
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
                            </td>
        </tr>
    </table>
</asp:Content>

