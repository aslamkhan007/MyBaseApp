<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="ViewDetail.aspx.vb" Inherits="OPS_ViewDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 123px">
                Sales Team
            </td>
            <td class="NormalText" style="width: 121px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" AutoPostBack="True" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 127px">
                Sales Person
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td rowspan="2">
               <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" 
                    onclientclick="window.history.go(-1);return false;">&lt;&lt; Back</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 123px">
                Customer
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" CssClass="textbox"
                    Width="200px" ToolTip="Please give Customer Code or Select Customer from the List "></asp:TextBox>
                <div id="divwidth" style="display: none;">
                    <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                        CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtCustomer">
                    </cc1:AutoCompleteExtender>
                </div>
            </td>
            <td class="labelcells" style="width: 127px">
                Order No
            </td>
            <td>
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
<img src="../Image/loading.gif" 
    style="width: 70px; height: 10px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td colspan="4" class="panelbg">
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="1000px">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdDetail" runat="server" AllowPaging="True" 
                                AlternatingRowStyle-CssClass="AltRowStyle" AutoGenerateColumns="true" 
                                CssClass="GridViewStyle" EnableModelValidation="True" 
                                FooterStyle-CssClass="SelectedRowStyle" GridLines="None" 
                                HeaderStyle-CssClass="HeaderStyle" Height="100px" 
                                PagerStyle-CssClass="PagerStyle" PageSize="100" RowStyle-CssClass="RowStyle" 
                                ShowFooter="True" Width="128%">
                                <HeaderStyle CssClass="HeaderStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
