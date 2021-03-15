<%@ Page Language="VB" MasterPageFile="MasterPage_Default.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="Asset Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="FlashControl" Namespace="Bewise.Web.UI.WebControls" TagPrefix="Bewise" %>
<%@ Register assembly="obout_Show_Net" namespace="OboutInc.Show" tagprefix="obshow" %>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<%--    assetmngmnt_masterpage_default_master'.--%>


    <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%">
        <tr>
            <td style="font-family: 'Trebuchet MS'; font-size: 10pt; font-weight: bold; color: #CC0000; text-align: center;  height: 380px;">

<obshow:show ID="Show1" runat="server" Height="100%"
                    ImagesShowPath="../image/quotes" TransitionType="Fading" Width="100%"
                    FadingStep="2" FixedScrolling="True" StopScrolling="True"
                    TimeBetweenPanels="5000" CSSPath="ob_show_panel" FadeFirstPanel="True" 
                    StartTimeDelay="5000">
<Changer Type="Arrow" ArrowType="Side1" Position="Bottom" VerticalAlign="Middle" HorizontalAlign="Center"></Changer>
                </obshow:show>
            
                </td>
        </tr>
        </table>
    <%--    <table>
        <tr>
        <td colspan="4" class="tableheader">
            Asset Dasboard</td>
        
        </tr>
        <tr>
        <td>
            <asp:Panel ID="Panel1" runat="server" Height="200px" 
                ScrollBars="Vertical">
                <asp:GridView ID="grdDetail" runat="server"
                    Width="100%" 
                  >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>
        </td>
        <td>
            <asp:Panel ID="Panel2" runat="server" Height="200px"  
                ScrollBars="Vertical">
                <asp:GridView ID="grdDetail2" runat="server"
                    Width="100%" 
                  >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>
        </td>
        <td>
            <asp:Panel ID="Panel3" runat="server" Height="200px"  
                ScrollBars="Vertical">
                <asp:GridView ID="grdDetail3" runat="server"
                    Width="100%" 
                  >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>

        </td>
        </tr>
        <tr>
        <td>
            <asp:Panel ID="Panel4" runat="server" Height="200px" Width="250px"  
                ScrollBars="Vertical" >
                <asp:GridView ID="grdDetail4" runat="server"
                    Width="100%" 
                  >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>
        </td>
        <td>
            <asp:Panel ID="Panel5" runat="server" Height="200px" Width="250px"  
                ScrollBars="Vertical">
                <asp:GridView ID="grdDetail5" runat="server"
                    Width="100%" 
                  >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>
        </td>
        <td>
                      <asp:Panel ID="Panel6" runat="server" Height="200px" Width="250px"  
                          ScrollBars="Vertical">
                          <asp:GridView ID="grdDetail6" runat="server"
                    Width="100%" 
                  >
                              <AlternatingRowStyle CssClass="GridAI" />
                              <HeaderStyle CssClass="GridHeader" />
                              <PagerStyle CssClass="PagerStyle" />
                              <RowStyle CssClass="GridItem" />
                              <SelectedRowStyle CssClass="GridRowGreen" />
                          </asp:GridView>
                      </asp:Panel>
        </td>

        </tr>
                     
        </table>
        <table cellpadding="0" cellspacing="0" style="height: 100%">
       
        <tr>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel7" runat="server" Width="644px" CssClass="panelbg" 
                            Visible="False" >
                            <table style="width:100%;" cellpadding="1px" cellspacing="1px" border="1px">
                                <tr>
                                    <td align="left" colspan="1" height="10px">
                                        <asp:Label ID="Label18" runat="server" Font-Bold="True" 
                                            Text="Module Selection"></asp:Label>
                                        <cc1:ModalPopupExtender ID="ModalPopUp_PageLoad" runat="server" 
                                            BackgroundCssClass="modalBackground" 
                                            PopupControlID="Panel7" TargetControlID="Label18">
                                        </cc1:ModalPopupExtender>
                                     
                                    </td>
                                    <td align="left" height="10px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="labelcells" style="width: 177px; height: 20px;">
                                        <asp:Label ID="Label17" runat="server" Text="Module Used By:"></asp:Label>
                                    </td>
                                    <td align="left" class="labelcells" style="height: 20px">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblType" runat="server" CssClass="combobox" 
                                                    RepeatDirection="Horizontal" 
                                                    Width="247px" AutoPostBack="True">
                                                    <asp:ListItem>IT</asp:ListItem>
                                                    <asp:ListItem>ADMIN</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
--%>


</asp:Content>

