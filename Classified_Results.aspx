<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Classified_Results.aspx.vb" Inherits="Classified_Results" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="text-align: left">
                <table class="NormalText" cellpadding="0" cellspacing="0" style="width: 100%; height: 37px;"
                    __designer:mapid="b6">
                    <tr __designer:mapid="b7">
                        <td rowspan="4" style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                            background-repeat: no-repeat;" __designer:mapid="b8">
                        </td>
                        <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                            height: 37px; font-size: 3pt;" valign="middle" __designer:mapid="b9">
                            <br __designer:mapid="ba" />
                            <asp:Label ID="Label7" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                font-weight: 700;" Text="JCT Classifieds"></asp:Label>
                        </td>
                        <td rowspan="4" style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                            background-position: left -4px; width: 28px;">
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 51px;" id="tblMenu"
                    class="NormalText">
                    <tr>
                        <td style="background-position: right bottom; background-image: url('Image/Background/Left%20Shadow.png');
                            background-repeat: repeat-y; width: 16px;">
                        </td>
                        <td style="background-position: center top; vertical-align: top; background-image: url('Image/Plain_Footer.png');
                            background-repeat: no-repeat;">
                            <asp:DataList ID="dlFeedbacks" runat="server" CellPadding="5" RepeatColumns="1" 
                                Width="100%">
                                <AlternatingItemStyle BackColor="#E8E8E8" />
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 42px;">
                                        <tr>
                                            <td style="text-align: left; height: 12px; width: 100%;" valign="top">
                                                <asp:Label ID="lblSDesc" runat="server" Text='<%# Eval("SDescription") %>'></asp:Label>
                                                &nbsp;-&nbsp;<asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                                                &nbsp;-&nbsp;<asp:Label
                                                    ID="lblDept" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblDateTime" runat="server"
                                                        Font-Bold="False" ForeColor="#666666" Style="font-size: 7pt" 
                                                    Text='<%# Eval("CreatedDt") %>'></asp:Label>
                                                &nbsp;</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 100%; vertical-align: top;" valign="top">
                                                <div style="height: 100%; width: 100%; font-weight: normal; overflow: hidden; vertical-align: top;">
                                                    <%--<asp:Label ID="Label3" runat="server" Text="This is sample text. This is sample text. This is sample text. This is sample text. This is sample text. "></asp:Label>--%>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("LDescription") %>'></asp:Label></div>
                                            </td>
                                             <td style="text-align: left; width: 100%; vertical-align: top;" valign="top">
                                                 <asp:Image ID="Image1" runat="server" Height="120px" Width="160px" 
                                                     ImageUrl='<%# Bind("Url") %>' />
                                            </td>
                                            
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td style="background-image: url('Image/Background/Right_Shadow.png'); background-repeat: repeat-y;
                            background-position: left bottom; width: 16px;">
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td style="background-position: left top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                            background-repeat: no-repeat; width: 50%;">
                            &nbsp;</td>
                        <td style="background-position: right top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                            background-repeat: no-repeat; width: 50%;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 0px; text-align: center;" class="NormalText" colspan="2">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Back</asp:HyperLink>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
