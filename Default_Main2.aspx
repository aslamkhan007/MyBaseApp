<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default_Main2.aspx.vb" Inherits="Default_Main" %>



<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

        <div runat="server" id="ParentDiv" 
        
            style="background-position: center top; width: 100%;
            height: 546px; vertical-align: middle; text-align: center; background-repeat: no-repeat;">
            <table cellpadding="0" cellspacing="0" style="width: 100%; height: 594px;">
                <tr>
                    <td colspan="3" 
                        
                        
                        
                        
                        style="background-image: url('Image/Plain_Header.png'); background-repeat: no-repeat; background-position: center bottom; height: 25px;">
                                    <table cellpadding="0" cellspacing="0" 
                                        
                            style="background-position: center top; width: 419px; height: 198px; background-image: url('Image/Frame3.png'); background-repeat: no-repeat;">
                                        <tr>
                                            <td colspan="2" style="height: 47px">
                                                <asp:Label ID="Label1" runat="server" 
                                                    style="font-family: Tahoma; font-size: 8pt; font-weight: 700" 
                                                    Text="Sample Title"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 107px; text-align: right; width: 173px">
                                                <asp:Image ID="Image1" runat="server" Height="112px" Width="112px" />
                                            </td>
                                            <td style="text-align: left; height: 107px" valign="top">
                                                <div style="width: 197px; height: 106px; font-size: xx-small; font-family: Tahoma;">
                                                    Sample Text Sample Text Sample Text Sample Text Sample Text Sample Text Sample 
                                                    Text Sample Text Sample Text Sample Text
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 173px">
                                                &nbsp;</td>
                                            <td style="text-align: left" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 144px; width: 194px;">
                    </td>
                    <td style="height: 144px; width: 800px">
                        &nbsp;</td>
                    <td style="height: 144px; width: 170px;">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3"                         
                        
                        
                        
                        style="background-position: center top; background-image: url('Image/Plain_Footer.png'); background-repeat: no-repeat; text-align: right; height: 111px;">
                                    <div style="height: 200px; background-image: url('Image/Frame3.png');">
                                        <div style="height: 150px; text-align: left;">
                                            <div style="height: 100%; width: 100%;">
                                            </div>
                                        </div>
                                    </div>
                        </td>
                </tr>
            </table>
        </div>
    
</asp:Content>
