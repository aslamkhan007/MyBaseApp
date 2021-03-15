<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="frm_Order_Status.aspx.vb" Inherits="OPS_frm_Order_Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Order Life Cycle
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Sales Team
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" AutoPostBack="True" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
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
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Customer
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" CssClass="textbox"
                    Width="200px"></asp:TextBox>
                <div id="divwidth" style="display: none;">
                    <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                        CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtCustomer">
                    </cc1:AutoCompleteExtender>
                </div>
            </td>
            <td class="NormalText" style="width: 127px">
                Order No
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" AutoPostBack="True" 
                            EnableViewState="False"></asp:TextBox>
                          <cc1:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="pnlSaleOrder"
                            TargetControlID="txtOrderNo" Position="Bottom">
                        </cc1:PopupControlExtender>
                      
                      
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
    <tr>
    <td style="width: 114px">
        <asp:Label ID="Label1" runat="server" Text="Order Life Cycle"></asp:Label>
    </td >
    <td>
    
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    
    </td>
    </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="100%" 
                            CssClass="panelbg">
                            <asp:GridView ID="GridOrderDetail" runat="server" 
                                            EmptyDataText="No Data Available" 
                                            Width="100%">
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td style="width: 114px">
        <asp:Label ID="Label2" runat="server" Text="Greigh QC Detail"></asp:Label>
            </td>
            <td>
    
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/loading.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    
            </td>
          
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Width="100%" 
                            CssClass="panelbg">
                            <asp:GridView ID="GrdQCDetail" runat="server" 
                                            EmptyDataText="No Data Available" 
                                            Width="100%">
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
          
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td style="width: 114px">
        <asp:Label ID="Label3" runat="server" Text="Finish QC Detail"></asp:Label>
            </td>
            <td>
    
        <asp:UpdateProgress ID="UpdateProgress3" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/loading.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    
            </td>
          
        </tr>
        <tr>
            <td colspan="2">
                            <asp:GridView ID="GrdFabricDetail" runat="server" 
                                            EmptyDataText="No Data Available" 
                                            Width="100%">
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
            </td>
          
        </tr>
        <tr>
            <td style="width: 114px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
          
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:Panel ID="pnlSaleOrder" runat="server" CssClass="panelbg" Width="200px" Height="400px" Style="display: none;"
                ScrollBars="Vertical">
                <asp:RadioButtonList ID="rblSaleOrder" CssClass="textbox" runat="server" AutoPostBack="True">
                </asp:RadioButtonList>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
