<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_originwise_demage.aspx.vb" Inherits="frm_originwise_demage"Title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;" >
        <tr>
            <td class="tableheader" colspan="4" >
                &nbsp;More Grey Required</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 104px">
                <asp:Label ID="Label2" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td style="width: 202px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                 <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="textbox" Width="62px" 
                        MaxLength="10"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtEffecFrom_FilteredTextBoxExtender" 
                        runat="server" FilterInterval="10" InvalidChars="a-z" 
                        TargetControlID="txtEffecFrom" ValidChars="1,2,3,4,5,6,7,8,9,0,/">
                    </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom" >
                </cc1:CalendarExtender>
                </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
            <td class="NormalText" style="width: 117px">
                <asp:Label ID="Label3" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEffecTo" runat="server" CssClass="textbox" 
                            AutoPostBack="True" Width="71px" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtEffecTo_FilteredTextBoxExtender" 
                            runat="server" InvalidChars="a-z" TargetControlID="txtEffecTo" 
                            ValidChars="1,2,3,4,5,6,7,8,9,0,/">
                        </cc1:FilteredTextBoxExtender>
                        <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                          TargetControlID="txtEffecTo">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 104px">
                <asp:Label ID="label14" runat="server" CssClass=" " Text="Location" 
                    style="text-align: left"></asp:Label>
            </td>
            <td style="width: 202px" >
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddllocation" runat="server" 
                                    CssClass="combobox" Height="18px" Width="80px">
                                    <asp:ListItem>Cotton</asp:ListItem>
                                    <asp:ListItem>Taffeta</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtEffecTo" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 117px" >
                &nbsp;</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                 
                </asp:UpdatePanel>
               </td>
        </tr>
        </table>
    <table style="width:100%;" >
        <tr>
            <td class="buttonbackbar" >
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" 
                    >Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc"
                            onclick="cmdclose_Click" >Close</asp:LinkButton>
                        <asp:LinkButton ID="lnkchart" runat="server" CssClass="buttonc" Visible="False">Chart</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" 
                   >Excel</asp:LinkButton><uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel5">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                           ImageUrl="~/Image/loading.gif" />
                        &nbsp;
                        <br />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
              
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                             <asp:Panel ID="Panel2" CssClass="panelbg" runat="server">
                            <asp:GridView ID="grdGrid1" runat="server"
                                     Width="100%" PageSize="5" 
                                     Style="margin-top: 9px" ShowFooter="True">
                                <RowStyle CssClass="GridItem" />
                                <EmptyDataTemplate>
                                   
                                </EmptyDataTemplate>
                                <SelectedRowStyle CssClass="selectedrow" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GridAI" />
                            </asp:GridView> 
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
               
            </td>
        </tr>
    </table>
    <table class="tableback">
    <tr>
    <td class="NormalText">
   
    </td>
    </tr>
    </table>
    
</asp:Content>


