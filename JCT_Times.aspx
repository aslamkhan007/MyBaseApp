<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="JCT_Times.aspx.vb" Inherits="JCT_Times" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 100%; height : 0px;" cellspacing="0">
    <tr>
        <td style="text-align: left">
            <table style="width:100%;" class="NormalText" cellspacing="0">
                <tr>
                    <td colspan="2" 
                        
                        
                        
                        
                        
                        style="background-image: url('Image/Headers/JCT_Times_Header.png'); background-repeat: no-repeat; background-position: center bottom; height: 97px; text-align: right; font-size: xx-small;">
                        <asp:Label ID="Label4" runat="server" style="font-size: small">Select Issue</asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlIssue" runat="server" AutoPostBack="True" 
                            Width="150px">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
            <asp:DataList ID="dlsNewsMain" runat="server" Width="100%">
                <ItemTemplate>
                    <table style="width:100%; " cellpadding="0" cellspacing="0">
                        <tr>
                            <td rowspan="2" style="width: 400px">
                                <asp:Image ID="imgNewsMain" runat="server" Height="300px" Width="400px" 
                                    AlternateText='<%# Eval("Title") %>' ImageUrl='<%# Eval("iconimage") %>' />
                            </td>
                            <td rowspan="2" 
                                style="background-position: left bottom; width: 10px; background-image: url('Image/Background/Right_Shadow.png'); background-repeat: no-repeat;">
                                &nbsp;</td>
                            <td class="frameheader" style="height: 37px;">
                                <asp:Label ID="lblNewsTitleMain" runat="server" 
                                    style="font-size: small; color: #333333;" Text='<%# Eval("Title") %>'></asp:Label>
                                &nbsp;&nbsp;
                                <asp:Label ID="lblNewsDateMain" runat="server" style="font-size: xx-small" 
                                    Text='<%# Eval("CreatedDt") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; ">
                                <table style="width:100%;" cellpadding="5" cellspacing="0">
                                    <tr>
                                        <td style="background-position: center top; height: 263px; vertical-align: top; background-image: url('Image/Plain_Footer.png'); background-repeat: no-repeat;">
                                            <asp:Label ID="lblNewsDetailMain" runat="server" style="color: #333333" 
                                                Text='<%# Eval("Description") %>' Font-Bold="False" Font-Size="9pt"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td 
                        
                        
                        style="background-image: url('Image/Frame/Footer_Frame_Large.png'); background-repeat: no-repeat; background-position: left top">
                        &nbsp;</td>
                    <td 
                        
                        
                        style="background-image: url('Image/Frame/Footer_Frame_Large.png'); background-repeat: no-repeat; background-position: right top">
                        &nbsp;</td>
                </tr>
                </table>
            <table style="width:100%;" class="NormalText" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="vertical-align: top; width: 40%;">
            <asp:DataList ID="dlsNewsLeft" runat="server" Width="100%" CellPadding="0">
                <ItemTemplate>
                    <table style="width:100%; height: 37px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="frameheader">
                                &nbsp;
                                <asp:Label ID="lblNewsTitleLeft" runat="server" 
                                    style="font-size: small; color: #333333;" Text='<%# Eval("Title") %>'></asp:Label>
                                &nbsp;
                                <asp:Label ID="lblNewsDateLeft" runat="server" style="font-size: xx-small" 
                                    Text='<%# Eval("CreatedDt") %>' Visible="False"></asp:Label>
                            </td>
                            <td style="background-image: url('Image/Frame/Frame_Right.png'); background-position: left -4px; background-repeat: no-repeat; width: 28px;">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table cellpadding="5" cellspacing="0" style="width:100%; height: 150px;">
                        <tr style="background-image: url('Image/Plain_Footer.png'); background-position: center top; background-repeat: no-repeat">
                            <td style="width: 106px; vertical-align: top;">
                                <asp:Image ID="imgNewsLeft" runat="server" Height="90px" Width="120px" 
                                    AlternateText='<%# Eval("Title") %>' ImageUrl='<%# Eval("IconImage") %>' />
                            </td>
                            <td style="vertical-align: top; ">
                                <asp:HiddenField ID="HiddenField1" runat="server" 
                                    Value='<%# Eval("NewsCode") %>' />
                                <asp:DataList ID="dlsNewsUpd" runat="server" Width="100%">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" style="color: #333333; font-family: Tahoma;" 
                                            Text='<%# Eval("Title") %>'></asp:Label>
                                        &nbsp;<asp:Label ID="Label1" runat="server" 
                                            style="color: #333333; font-family: Arial, Helvetica, sans-serif;" 
                                            Text='<%# Eval("CreatedDt") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label2" runat="server" style="color: #333333" 
                                            Text='<%# Eval("Description") %>' Font-Bold="False"></asp:Label>
                                        <br />
                                        <img src="Image/Frame/line_home.gif" style="width: 168px; height: 12px" />
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td style="background-position: left bottom; vertical-align: top; width: 5px; background-image: url('Image/Background/Right_Shadow.png'); background-repeat: no-repeat;">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" style="width:100%; height: 10px;">
                        <tr>
                            <td style="background-position: left top; width: 50%; vertical-align: top; height: 10px; background-image: url('Image/Frame/Frame_Bottom.png'); background-repeat: no-repeat;">
                            </td>
                            <td style="background-position: right top; height: 10px; vertical-align: top; width: 50%; background-image: url('Image/Frame/Frame_Bottom.png'); background-repeat: no-repeat;">
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
                    </td>
                    <td style="vertical-align: top">
            <asp:DataList ID="dlsNewsRight" runat="server" Width="100%" CellPadding="0">
                <ItemTemplate>
                    <table style="width:100%; height: 37px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png'); background-repeat: no-repeat;">
                                &nbsp;</td>
                            <td class="frameheader">
                                &nbsp;
                                <asp:Label ID="lblNewsTitleRight" runat="server" 
                                    style="font-size: small; color: #333333;" Text='<%# Eval("Title") %>'></asp:Label>
                                &nbsp;
                                <asp:Label ID="lblNewsDateRight" runat="server" style="font-size: xx-small" 
                                    Text='<%# Eval("CreatedDt") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="5" cellspacing="0" style="width:100%; height: 150px;">
                        <tr style="background-image: url('Image/Plain_Footer.png'); background-position: center top; background-repeat: no-repeat">
                            <td style="background-position: right bottom; width: 5px; vertical-align: top; background-image: url('Image/Background/Left%20Shadow.png'); background-repeat: no-repeat;">
                                &nbsp;</td>
                            <td style="width: 160px; vertical-align: top;">
                                <asp:Image ID="imgNewsRight" runat="server" 
                                    AlternateText='<%# Eval("Title") %>' Height="120px" 
                                    ImageUrl='<%# Eval("IconImage") %>' Width="160px" />
                            </td>
                            <td style="vertical-align: top; ">
                                <asp:Label ID="Label1" runat="server" style="color: #333333" 
                                    Text='<%# Eval("Description") %>' Font-Bold="False"></asp:Label>
                            </td>
                            <td 
                                
                                style="background-position: left bottom; width: 10px; background-image: url('Image/Background/Right_Shadow.png');">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" style="width:100%; height: 8px;">
                        <tr>
                            <td style="background-position: left top; width: 50%; vertical-align: top; height: 10px; background-image: url('Image/Frame/Footer_Frame_Large.png'); background-repeat: no-repeat;">
                            </td>
                            <td style="background-position: right top; height: 10px; vertical-align: top; width: 50%; background-image: url('Image/Frame/Footer_Frame_Large.png'); background-repeat: no-repeat;">
                            </td>
                            <td style="background-position: left bottom; width: 10px; background-image: url('Image/Background/Right_Shadow.png');">
                                &nbsp;</td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center;" colspan="2">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Back</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
        </td>
    </tr>
</table>

</asp:Content>
