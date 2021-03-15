﻿<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="customer_ledger.aspx.vb" Inherits="OPS_customer_ledger" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="4">
                Customer Ledger</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Customer"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                    CssClass="textbox" Width="200px"></asp:TextBox>
               

                   <div id="divWidth" style="display:none;">   
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                            TargetControlID="txtStartDate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="To Date "></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                            TargetControlID="txtEndDate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
<img alt="" src="../Image/loading.gif" 
    style="width: 70px; height: 10px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center" class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="LnkView" runat="server" CssClass="buttonc">View</asp:LinkButton>
                        <asp:LinkButton ID="LnkClose" runat="server" CssClass="buttonc">Close </asp:LinkButton>
                        <asp:LinkButton ID="LnkExcel" runat="server" CssClass="buttonc">Excel</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                    <asp:PostBackTrigger ControlID="LnkExcel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">
               
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" Width="100%">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
              
            </td>
        </tr>
    </table>
</asp:Content>

