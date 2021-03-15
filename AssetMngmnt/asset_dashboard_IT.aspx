<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="asset_dashboard_IT.aspx.vb" Inherits="AssetMngmnt_asset_dashboard_IT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="FlashControl" Namespace="Bewise.Web.UI.WebControls" TagPrefix="Bewise" %>
<%@ Register assembly="obout_Show_Net" namespace="OboutInc.Show" tagprefix="obshow" %>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%--     <td class="labelcells">
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
            </td>--%>
        <table width="100%">
        <tr>
        <td colspan="4" class="tableheader">
            <asp:Label ID="Label18" runat="server" Text="Asset DashBoard" Width="14%"></asp:Label>
            <asp:Label ID="lbsrno" runat="server" style="text-align:right" Text="Label" 
                Width="85%"></asp:Label>
            </td>
        
        </tr>
        <tr>
        <td colspan="4"> </td></tr>
        <tr style="height:40px">
       
        <td  class="textcells_s"; style="font-size:medium">Processors</td>
        <td   colspan="2" class="textcells_s" ; style="font-size:medium">Printers</td>
       
        
        </tr>
        <tr>
        <td style="width:40%";>
            <asp:Panel ID="Panel1" runat="server" Height="200px" 
               ScrollBars="Vertical">
                <asp:GridView ID="grdDetail" runat="server"
                    Width="95%" 
                  >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>
        </td>
        <td colspan="3" style="width:70%";>
            <asp:Panel ID="Panel2" runat="server" Height="200px"  
                ScrollBars="Vertical">
                <asp:GridView ID="grdDetail2" runat="server"
                    Width="97%" 
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
            <tr style="height:30px">
        <td  class="textcells_s" ; style="font-size:medium">Total Assets</td>
        <td  class="textcells_s" ; style="font-size:medium">Scanners</td>
        <td colspan="1" class="textcells_s" ; style="font-size:medium">Others</td>
        </tr>
        <tr>
        <td style="width:40%";>
            <asp:Panel ID="Panel4" runat="server" Height="200px" 
                ScrollBars="Vertical" >
                <asp:GridView ID="grdDetail4" runat="server"
                    Width="95%" 
                  >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>
        </td>
        <td style="width:40%";>
            <asp:Panel ID="Panel5" runat="server" Height="200px" 
                ScrollBars="Vertical">
                <asp:GridView ID="grdDetail5" runat="server"
                    Width="95%" 
                  >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>
        </td>
        <td style="width:20%";>
                      <asp:Panel ID="Panel6" runat="server" Height="200px"  
                          ScrollBars="Vertical">
                          <asp:GridView ID="grdDetail6" runat="server"
                    Width="90%" 
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
             <td   colspan="3" class="textcells_s" ; style="font-size:medium">E-Bin</td>
        
        </tr>
       <tr>
              <td colspan="3" style="width:70%"; >
                      <asp:Panel ID="Panel3" runat="server" Height="200px"  
                          ScrollBars="Vertical">
                          <asp:GridView ID="grdDetail8" runat="server"
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
       <%--     <td class="labelcells">
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
            </td>--%>
        </tr>
        </table>



</asp:Content>

