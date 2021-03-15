﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="JCT_Payroll_Worker_Portal_PF.aspx.cs" Inherits="Payroll_JCT_Payroll_Worker_Portal_PF" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">                
                Worker PF :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <%--       <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" style="width: 105px">
                <asp:TextBox ID="txtOtherRequest" runat="server" CssClass="textbox" 
                     MaxLength="17" Width="300px" ToolTip="i.e    June-2019"></asp:TextBox>
            </td>
        </tr>
        <%--        <tr>
            <td class="labelcells">
                Designation
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldesignation" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>--%>
        <%--                <tr>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>--%>
        <%--      <tr>
            <td class="labelcells">
                Search Emplyoee Name
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee"
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="labelcells">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr--%>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>


