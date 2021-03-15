<%@ Page Title="" Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="SearchResult.aspx.vb" Inherits="SearchResult" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" style="width: 100%;">
    <tr>
        <td class="tableheader" colspan="4">
            Search Result</td>
    </tr>
    <tr>
        <td colspan="4" bgcolor="#CCCCCC">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:DataList ID="DataList1" runat="server" BorderStyle="Groove" 
                BorderWidth="2px" RepeatColumns="3" 
    RepeatDirection="Horizontal" Width="100%" CssClass="panelcells">
                        <EditItemStyle HorizontalAlign="Center" 
                    VerticalAlign="Bottom" />
                        <ItemTemplate>
                            <table style="width: 100%; height: 39px;" class="panelcells">
                                <tr>
                                    <td align="center">
                                        <asp:Image ID="Image4" runat="server" ImageUrl='<%# eval("imgurl") %>' 
                                            Width="16px" />
                                        <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" PopDelay="5" 
                                            PopupControlID="Panel3" TargetControlID="Image4" PopupPosition="Left">
                                        </cc1:HoverMenuExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:HyperLink ID="LnkFile" runat="server" NavigateUrl='<%# eval("url") %>' 
                                    Text='<%# eval("name") %>'></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Panel ID="Panel3" runat="server"  
                                            BorderStyle="Groove" BorderWidth="3px">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td class="gridheader">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# eval("name") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="Image5" runat="server" ImageUrl='<%# eval("imgurl") %>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="labelcells" colspan="4">
             <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="True" Message="test" 
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" /></td>
    </tr>
    <tr>
        <td class="labelcells" width="20%">
            &nbsp;</td>
        <td class="textcells" width="30%">
            &nbsp;</td>
        <td class="labelcells" width="20%">
            &nbsp;</td>
        <td class="textcells" width="30%">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

