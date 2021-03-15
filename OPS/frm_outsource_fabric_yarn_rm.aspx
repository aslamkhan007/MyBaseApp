<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_outsource_fabric_yarn_rm.aspx.vb" Inherits="frm_outsource_fabric_yarn_rm"Title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;" >
        <tr>
            <td class="tableheader" colspan="4" >
                Material Recieved (RM)</td>
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
                &nbsp;</td>
            <td style="width: 202px">
                &nbsp;</td>
            <td class="NormalText" style="width: 117px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;" >
        <tr>
            <td class="buttonbackbar" >
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" Width="65px" 
                    >Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc"
                            onclick="cmdclose_Click" Width="65px" >Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
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
                                     Style="margin-top: 9px" ShowFooter="True" EnableModelValidation="True">
                                <RowStyle CssClass="GridItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Location ">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddllocation" runat="server" Font-Size="Smaller">
                                                <asp:ListItem>Cotton</asp:ListItem>
                                                <asp:ListItem>Taffeta</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DocuRcvd">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddldocument" runat="server" Font-Size="Smaller">
                                                <asp:ListItem>N</asp:ListItem>
                                                <asp:ListItem>Y</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QtyRcvd">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtqtyrcvd" runat="server" Width="85px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtqtyrcvd_FilteredTextBoxExtender" 
                                                runat="server" TargetControlID="txtqtyrcvd" ValidChars="0123456789.">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
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
        <tr>
            <td class="buttonbackbar">
              
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkapply" runat="server" 
    CssClass="buttonc" Visible="False">Apply</asp:LinkButton>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
               
            </td>
        </tr>
    </table>
        
</asp:Content>


