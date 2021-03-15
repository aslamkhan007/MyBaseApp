﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="PlanningProgram.aspx.cs" Inherits="OPS_PlanningProgram" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Sale Order Planning Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 136px">
                <asp:Label ID="Label17" runat="server" Text="Plan Start Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 209px">
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                    TargetControlID="txtStartDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtStartDate" ErrorMessage="**Required"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 158px">
                <asp:Label ID="Label19" runat="server" Text="Plan End Date"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtEndDate" ErrorMessage="**Required"></asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                    TargetControlID="txtEndDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 136px">
                <asp:Label ID="Label18" runat="server" Text="Sales Team"></asp:Label>
            </td>
            <td class="NormalText" style="width: 209px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" AutoPostBack="True" 
                            CssClass="combobox" 
                            onselectedindexchanged="ddlSalesTeam_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 158px">
                <asp:Label ID="Label20" runat="server" Text="Sales Person"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesPerson" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 136px">
                <asp:Label ID="Label21" runat="server" Text="Customer"></asp:Label>
            </td>
            <td class="NormalText" style="width: 209px">
                <asp:TextBox ID="txtCustomer" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtCustomer_TextChanged" Width="200px"></asp:TextBox>
                   <div id="divwidth" style="display:none;">   
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_Customer"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                        </div>
            </td>
            <td class="NormalText" style="width: 158px">
                <asp:Label ID="Label22" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 136px">
                <asp:Label ID="Label23" runat="server" Text="Sort"></asp:Label>
            </td>
            <td class="NormalText" style="width: 209px">
                <asp:TextBox ID="txtSort" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 158px">
                <asp:Label ID="Label28" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 136px">
                <asp:Label ID="Label29" runat="server" Text="Select Plan Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 209px">
                <asp:DropDownList ID="ddlMode" runat="server" AutoPostBack="True">
                    <asp:ListItem>Freezed</asp:ListItem>
                    <asp:ListItem>UnFreezed</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 158px">
                <asp:Label ID="Label30" runat="server" Text="Shed"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlShed" runat="server" AutoPostBack="True">
                    <asp:ListItem>Freezed</asp:ListItem>
                    <asp:ListItem>UnFreezed</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 136px">
                <asp:Label ID="Label31" runat="server" Text="Shortfall Request"></asp:Label>
            </td>
            <td class="NormalText" style="width: 209px">
                <asp:DropDownList ID="ddlShortfall" runat="server" AutoPostBack="True">
                    <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>Shortfall Orders</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 158px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="width: 289px">
                &nbsp;</td>
            <td class="NormalText" style="width: 157px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblOption" runat="server" AutoPostBack="True" 
                            RepeatDirection="Horizontal" 
                            onselectedindexchanged="rblOption_SelectedIndexChanged" CssClass="panelbg" 
                            Visible="False">
                            <asp:ListItem>Detail</asp:ListItem>
                            <asp:ListItem>Summary</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="height: 17px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlSummary" runat="server" Visible="false" Width="300px" 
                            CssClass="panelbg">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="tableheader" colspan="2">
                                            <asp:Label ID="Label27" runat="server" Text="Order Planning Summary"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label24" runat="server" Text="Total Orders Planned"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblOrder" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label25" runat="server" Text="Total Items Planned"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblItem" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label26" runat="server" Text="Total Profit"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProfit" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rblOption" 
                            EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="4">
              
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlDetail" runat="server" Width="1000px" Height="500px" ScrollBars="Both">
                            <asp:GridView ID="GridView1" runat="server" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rblOption" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
               
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 136px;">
                &nbsp;</td>
            <td class="NormalText" style="width: 209px;">
                &nbsp;</td>
            <td class="NormalText" style="width: 158px;">
                &nbsp;</td>
            <td class="NormalText" >
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>

