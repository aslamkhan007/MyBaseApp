<%@ Page Title="" Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="ResultFileDetail.aspx.vb" Inherits="ResultFileDetail" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar" style="border-style: none; padding: 0px; width: 2%">
                <asp:LinkButton ID="cmdBack" runat="server" BorderStyle="None" 
                    CssClass="buttonc">&lt;&lt; Back</asp:LinkButton>
            </td>
            <td width="30%" align="center" class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdFirst0" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="5" 
    BorderStyle="None">First</asp:LinkButton>
                        <asp:LinkButton ID="CmdPrevious0" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="7" 
    BorderStyle="None">Move Prev</asp:LinkButton>
                        <asp:LinkButton ID="CmdNext0" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="6" 
    BorderStyle="None">Move Next</asp:LinkButton>
                        <asp:LinkButton ID="CmdLast0" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="8" 
    BorderStyle="None">Last</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#CCCCCC" colspan="2" height="500px" valign="top" 
                width="500px" style="border: 1px solid #000000">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Image ID="Img" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdFirst0" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdLast0" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdPrevious0" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="cmdBack1" runat="server" BorderStyle="None" 
                    CssClass="buttonc">&lt;&lt; Back</asp:LinkButton>
            </td>
            <td align="center" class="buttonbackbar">
                            <asp:LinkButton ID="CmdFirst" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="5" BorderStyle="None">First</asp:LinkButton>
                            <asp:LinkButton ID="CmdPrevious" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="7" BorderStyle="None">Move Prev</asp:LinkButton>
                            <asp:LinkButton ID="CmdNext" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="6" BorderStyle="None">Move Next</asp:LinkButton>
                            <asp:LinkButton ID="CmdLast" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="8" BorderStyle="None">Last</asp:LinkButton>
                        </td>
        </tr>
        <tr>
            <td colspan="2">
                 <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="True" Message="test" 
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" /></td>
        </tr>
    </table>
</asp:Content>

