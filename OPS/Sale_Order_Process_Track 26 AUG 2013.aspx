﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Sale_Order_Process_Track.aspx.cs" Inherits="OPS_Sale_Order_Process_Track" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Sale Order Process Track</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:Label ID="Label18" runat="server" Text="Period Basis"></asp:Label>
            </td>
            <td class="NormalText" style="width: 166px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <telerik:RadDropDownList ID="radDDLPeriodBasis" runat="server" 
                            SelectedText="Dispatch" Width="100px" 
                            onselectedindexchanged="radDDLPeriodBasis_SelectedIndexChanged" 
                            AutoPostBack="True">
                            <Items>
                                <telerik:DropDownListItem runat="server" Selected="True" Text="Dispatch" />
                                <telerik:DropDownListItem runat="server" Text="Packing" />
                            </Items>
                        </telerik:RadDropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 133px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                <ContentTemplate>
                 <asp:Label ID="lblDateTypeFrom" runat="server"></asp:Label>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radDDLPeriodBasis" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
               
                <asp:Label ID="Label16" runat="server" Text=" Dt From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 166px">
                <telerik:RadDatePicker ID="radDtPckrStartFrom" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px" FocusedDate="2013-08-26">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td class="NormalText" style="width: 133px">
              <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="lblDateTypeTo" runat="server"></asp:Label>
                </ContentTemplate>
                  <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="radDDLPeriodBasis" 
                          EventName="SelectedIndexChanged" />
                  </Triggers>
                </asp:UpdatePanel>
              
                <asp:Label ID="Label17" runat="server" Text=" Dt To"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="radDtEndDate" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px" FocusedDate="2013-08-26">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 155px">
                &nbsp;</td>
            <td class="NormalText" style="width: 166px">
                &nbsp;</td>
            <td class="NormalText" style="width: 133px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <telerik:RadButton ID="radbtnFetch" runat="server" Text="Fetch" 
                            onclick="radbtnFetch_Click">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <telerik:RadButton ID="radbtnExcel" runat="server" Text="Excel" 
                            onclick="radbtnExcel_Click">
                        </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid1" runat="server" 
                            onneeddatasource="RadGrid1_NeedDataSource">
                        </telerik:RadGrid>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radbtnFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

